Imports System.Xml
Imports System.Runtime.Serialization.Json
Imports System.Text

Public NotInheritable Class dlgSimple

    Public Property sWord As String
        Set(value As String)
            strSearch = value
        End Set
        Get
            Return strSearch
        End Get
    End Property
    Dim strSearch As String, sResult As String
    Private Sub dlgSimple_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWord.Text = "正在连接丁香词典进行翻译……"
        bgW.RunWorkerAsync()
    End Sub
    'Private Sub HTMLBodyDown(sender As Object, e As HtmlElementEventArgs)
    '    Try
    '        If Me.InvokeRequired Then
    '            Me.BeginInvoke(New EventHandler(AddressOf HTMLBodyDown))
    '        Else
    '            If e.KeyPressedCode = Keys.Escape Then Me.Close()
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Sub lblMore_Click(sender As Object, e As EventArgs) Handles lblMore.Click
        Dim f As frmMain = My.Application.OpenForms("frmMain")
        If f IsNot Nothing Then
            f.txtInput.Text = lblWord.Text
            f.cmdSearch.PerformClick()
        End If
        Me.Close()
    End Sub
    Private Sub bgW_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgW.DoWork
        Try
            Dim sUrl As String = String.Format("http://dict.pubmed.cn/webservices/dict/openapi/d@3sBi91/{0}", strSearch)
            Dim w As New Net.WebClient
            Dim m As IO.Stream = w.OpenRead(sUrl)
            Dim r As New IO.StreamReader(m)
            Dim htmlContent As String = r.ReadToEnd
            r.Close()
            w.Dispose()
            sResult = "<html><body><div style='font-size:14px;'>"
            Dim xR As XmlDictionaryReader = JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(htmlContent), XmlDictionaryReaderQuotas.Max)
            Dim xDoc As New XmlDocument
            xDoc.Load(xR)
            Dim xE As XmlElement
            Dim xNL As XmlNodeList = xDoc.SelectNodes("/root/definition/item")
            For Each xE In xNL
                If xE.HasChildNodes Then
                    xE = xE.ChildNodes(0)
                    If xE.HasAttribute("item") Then
                        sResult &= String.Format("【{0}】<br />{1}<br />", xE.GetAttribute("item"), xE.InnerText)
                    End If
                End If
            Next
            sResult &= "</div></body></html>"
            'sResult &= vbCrLf & vbCrLf & "欢迎访问流式中文网（http://www.flowcyto.cn）讨论、学习流式细胞术"

        Catch ex As Exception
            sResult = "查询时出错：<br />" & vbCrLf & ex.Message
        End Try
    End Sub

    Private Sub wbMain_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wbMain.DocumentCompleted
        wbMain.Document.Write(sResult)
        'AddHandler wbMain.Document.Body.KeyDown, AddressOf HTMLBodyDown
    End Sub

    Private Sub bgW_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgW.RunWorkerCompleted
        Try
            If e.Cancelled Then
                Exit Sub
            Else
                lblWord.Text = strSearch
                wbMain.Navigate("about:blank")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

End Class
