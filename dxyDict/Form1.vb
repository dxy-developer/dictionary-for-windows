
Imports System.Runtime.InteropServices
Imports System.Runtime.Serialization.Json
Imports System.IO
Imports System.Text
Imports System.Windows.Automation
Imports System.Xml

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Private Const WM_DRAWCLIPBOARD As Integer = &H308
    Private Const WM_CHANGECBCHAIN As Integer = &H30D
    Private mNextClipBoardViewerHWnd As IntPtr
    Dim curPos As System.Drawing.Point, prePos As System.Drawing.Point, strGetPre As String = ""
    Private Event OnClipboardChanged()
    Dim arrList As Dictionary(Of String, String), sInput As String, sResult As String

    <DllImport("user32")> _
    Private Shared Function SetClipboardViewer(ByVal hWnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32")> _
    Private Shared Function ChangeClipboardChain(ByVal hWnd As IntPtr, ByVal hWndNext As IntPtr) As _
<MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32")> _
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, _
ByVal lParam As IntPtr) As IntPtr
    End Function

    Sub New()
        InitializeComponent()
        mNextClipBoardViewerHWnd = SetClipboardViewer(Me.Handle)
        AddHandler Me.OnClipboardChanged, AddressOf ClipBoardChanged
    End Sub
    Protected Overrides Sub WndProc(ByRef m As Message)
        Select Case m.Msg
            Case WM_DRAWCLIPBOARD
                RaiseEvent OnClipboardChanged()
                SendMessage(mNextClipBoardViewerHWnd, m.Msg, m.WParam, m.LParam)

            Case WM_CHANGECBCHAIN
                If m.WParam.Equals(mNextClipBoardViewerHWnd) Then
                    mNextClipBoardViewerHWnd = m.LParam
                Else
                    SendMessage(mNextClipBoardViewerHWnd, m.Msg, m.WParam, m.LParam)
                End If
        End Select
        MyBase.WndProc(m)
    End Sub

    Private Sub ClipBoardChanged()
        If mnuClipboard.Checked Then
            Dim data As String = Clipboard.GetText.Trim
            If data.Length > 0 And data.Length < 50 Then
                Dim Reg As New RegularExpressions.Regex("^([\u4e00-\u9fa5\sA-Za-z0-9-])*$")
                If Reg.IsMatch(data) Then
                    txtInput.Text = data
                    cmdSearch_Click(Me, New System.EventArgs)
                End If

            End If
        End If

    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ChangeClipboardChain(Me.Handle, mNextClipBoardViewerHWnd)
    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtInput.Text = "请输入英文单词"
        Me.Text = String.Format("丁香词典 V{0}.{1}", My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
        lblLink.Visible = False
        lblCollapse.Visible = False
        curPos = New Point(0, 0)
        Me.Width = 360
        Me.Height = 85
        Me.TopMost = True
        Me.Left = My.Computer.Screen.Bounds.Width - 370
        Me.Top = 30
        mnuCursor.Checked = True
        tmrGetWord.Enabled = True
    End Sub
    Private Sub txtInput_GotFocus(sender As Object, e As EventArgs) Handles txtInput.GotFocus
        txtInput.SelectAll()
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        sInput = txtInput.Text.Trim
        If sInput.Length > 0 Then
            If sInput = "请输入英文单词" Then
            Else

                Dim Reg As New RegularExpressions.Regex("^([\u4e00-\u9fa5\sA-Za-z0-9-])*$")
                If Reg.IsMatch(sInput) Then
                    If bgW.IsBusy Then Exit Sub
                    Me.Text = "正在搜索，请稍候……"
                    cmdSearch.Enabled = False
                    txtInput.Enabled = False
                    bgW.RunWorkerAsync()
                Else
                    MessageBox.Show("查询只支持短横、英文字母或汉字。", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            End If
        End If
    End Sub

    Private Sub bgW_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgW.DoWork
        Try
            Dim sUrl As String = String.Format("http://dict.pubmed.cn/webservices/dict/openapi/d@3sBi91/{0}", sInput)
            Dim w As New Net.WebClient
            Dim m As IO.Stream = w.OpenRead(sUrl)
            Dim r As New IO.StreamReader(m)
            Dim htmlContent As String = r.ReadToEnd
            r.Close()
            w.Dispose()
            sResult = "<html><body>"
            Dim xR As XmlDictionaryReader = JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(htmlContent), XmlDictionaryReaderQuotas.Max)
            Dim xDoc As New XmlDocument
            xDoc.Load(xR)

            Dim xE As XmlElement
            xE = xDoc.SelectSingleNode("/root/en_word")
            If xE IsNot Nothing Then sResult &= String.Format("<h1>{0}</h1>", xE.InnerText)
            xE = xDoc.SelectSingleNode("/root/phonetic/item/NAmE")
            If xE IsNot Nothing Then sResult &= String.Format("美式发音：{0}；&nbsp;&nbsp;", xE.InnerText)
            xE = xDoc.SelectSingleNode("/root/phonetic/item/BrE")
            If xE IsNot Nothing Then sResult &= String.Format("英式发音：{0}<br />", xE.InnerText)
            Dim xNL As XmlNodeList = xDoc.SelectNodes("/root/definition/item")
            If xNL.Count = 0 Then
                sResult &= "<h2>找不到释义，请检查是否拼写有误</h2>"
            Else
                sResult &= "<h2>释义</h2><ol>"
                For Each xE In xNL
                    If xE.HasChildNodes Then
                        xE = xE.ChildNodes(0)
                        If xE.HasAttribute("item") Then
                            sResult &= String.Format("<li>【{0}】<br />{1}</li>", xE.GetAttribute("item"), xE.InnerText)
                        End If
                    End If
                Next
                sResult &= "</ol>"
            End If

            xNL = xDoc.SelectNodes("/root/sentences/item")
            If xNL.Count > 0 Then
                sResult &= "<br /><h2>论文例句</h2><ol>"
                For Each xE In xNL
                    If xE.ChildNodes.Count > 1 Then
                        sResult &= String.Format("<li>{0}<br />{1}</li>", xE.ChildNodes(1).InnerText, xE.ChildNodes(0).InnerText)
                    End If
                Next
                sResult &= "</ol>"
            End If
            sResult &= "</body></html>"
            'sResult &= vbCrLf & vbCrLf & "欢迎访问流式中文网（http://www.flowcyto.cn）讨论、学习流式细胞术"

        Catch ex As Exception
            sResult = "查询时出错：<br />" & vbCrLf & ex.Message
        End Try

    End Sub

    Private Sub bgW_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgW.RunWorkerCompleted
        Me.Text = String.Format("丁香词典 V{0}.{1}", My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
        cmdSearch.Enabled = True
        txtInput.Enabled = True
        wbMain.Navigate("about:blank")
        Me.Height = 370
        Me.Width = 600
        lblLink.Visible = True
        lblCollapse.Visible = True
        Me.Left = My.Computer.Screen.Bounds.Width - 610
    End Sub
    Private Sub txtInput_KeyDown(sender As Object, e As KeyEventArgs) Handles txtInput.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                cmdSearch_Click(sender, New System.EventArgs)
            Case Keys.Escape
                If Me.Height = 85 Then Exit Sub
                lblLink.Visible = False
                lblCollapse.Visible = False
                Me.Height = 85
                Me.Width = 360
                Me.Left = My.Computer.Screen.Bounds.Width - 370
        End Select

    End Sub

    Private Sub tmrGetWord_Tick(sender As Object, e As EventArgs) Handles tmrGetWord.Tick
        Try
            curPos = System.Windows.Forms.Cursor.Position
            If prePos = curPos Then
                Exit Sub
            Else
                prePos = curPos
            End If
            Dim cPt As New System.Windows.Point(curPos.X, curPos.Y)
            Dim element As AutomationElement = AutomationElement.FromPoint(cPt)
            If element Is Nothing Then Exit Sub
            Dim pattern As Object = Nothing
            If element.TryGetCurrentPattern(TextPattern.Pattern, pattern) Then
                Dim tP As TextPattern = pattern
                Dim r As Text.TextPatternRange = tP.RangeFromPoint(cPt)
                r.ExpandToEnclosingUnit(Windows.Automation.Text.TextUnit.Word)
                Dim strGet As String = r.GetText(50).Trim
                If strGet.Length = 0 Then
                    Exit Sub
                Else
                    If strGetPre = strGet Then
                        Exit Sub
                    Else
                        strGetPre = strGet
                        Dim Reg As New RegularExpressions.Regex("^([A-Za-z0-9-])*$")
                        If Reg.IsMatch(strGet) Then
                            Dim f As dlgSimple = My.Application.OpenForms("dlgSimple")
                            If f IsNot Nothing Then
                                f.Close()
                            End If
                            f = New dlgSimple
                            f.Left = curPos.X
                            f.Top = curPos.Y
                            f.sWord = r.GetText(50)
                            f.Show()

                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub lblLink_Click(sender As Object, e As EventArgs) Handles lblLink.Click
        Process.Start(String.Format("http://dict.pubmed.cn/sentence.htm?wd={0}", txtInput.Text.Trim))
    End Sub

    Private Sub mnuCursor_CheckStateChanged(sender As Object, e As EventArgs) Handles mnuCursor.CheckStateChanged
        tmrGetWord.Enabled = mnuCursor.Checked
    End Sub

    Private Sub lblCollapse_Click(sender As Object, e As EventArgs) Handles lblCollapse.Click
        If Me.Height = 85 Then Exit Sub
        lblLink.Visible = False
        lblCollapse.Visible = False
        Me.Height = 85
        Me.Width = 360
        Me.Left = My.Computer.Screen.Bounds.Width - 370
    End Sub
    Private Sub HTMLBodyDown(sender As Object, e As HtmlElementEventArgs)
        If e.KeyPressedCode = Keys.Escape Then
            If Me.Height = 85 Then Exit Sub
            lblLink.Visible = False
            lblCollapse.Visible = False
            Me.Height = 85
            Me.Width = 360
            Me.Left = My.Computer.Screen.Bounds.Width - 370
        End If
    End Sub
    Private Sub wbMain_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wbMain.DocumentCompleted
        If wbMain.Url.ToString = "about:blank" Then
            wbMain.Document.Write(sResult)
            AddHandler wbMain.Document.Body.KeyDown, AddressOf HTMLBodyDown
            txtInput.Focus()
        End If
    End Sub
    Private Sub mnuCopy_Click(sender As Object, e As EventArgs) Handles mnuCopy.Click
        Dim d As mshtml.IHTMLDocument2 = wbMain.Document.DomDocument
        Dim cSel As mshtml.IHTMLSelectionObject = d.selection
        If cSel IsNot Nothing Then
            Dim r As mshtml.IHTMLTxtRange = cSel.createRange
            If r IsNot Nothing Then
                If r.text IsNot Nothing Then Clipboard.SetText(r.text)
            End If
        End If
    End Sub

End Class
