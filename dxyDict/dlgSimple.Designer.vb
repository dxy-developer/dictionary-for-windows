<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSimple
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblWord = New System.Windows.Forms.Label()
        Me.lblMore = New System.Windows.Forms.Label()
        Me.wbMain = New System.Windows.Forms.WebBrowser()
        Me.bgW = New System.ComponentModel.BackgroundWorker()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblWord
        '
        Me.lblWord.AutoEllipsis = True
        Me.lblWord.BackColor = System.Drawing.Color.Transparent
        Me.lblWord.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblWord.Location = New System.Drawing.Point(5, 8)
        Me.lblWord.Name = "lblWord"
        Me.lblWord.Size = New System.Drawing.Size(249, 20)
        Me.lblWord.TabIndex = 0
        Me.lblWord.Text = "正在连接丁香词典进行翻译……"
        '
        'lblMore
        '
        Me.lblMore.AutoEllipsis = True
        Me.lblMore.BackColor = System.Drawing.Color.Transparent
        Me.lblMore.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblMore.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMore.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.lblMore.Image = Global.dxyDict.My.Resources.Resources.more
        Me.lblMore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMore.Location = New System.Drawing.Point(267, 5)
        Me.lblMore.Name = "lblMore"
        Me.lblMore.Size = New System.Drawing.Size(60, 25)
        Me.lblMore.TabIndex = 1
        Me.lblMore.Text = "详细"
        Me.lblMore.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'wbMain
        '
        Me.wbMain.AllowWebBrowserDrop = False
        Me.wbMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wbMain.IsWebBrowserContextMenuEnabled = False
        Me.wbMain.Location = New System.Drawing.Point(8, 31)
        Me.wbMain.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbMain.Name = "wbMain"
        Me.wbMain.Size = New System.Drawing.Size(355, 161)
        Me.wbMain.TabIndex = 8
        '
        'bgW
        '
        Me.bgW.WorkerSupportsCancellation = True
        '
        'cmdClose
        '
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdClose.Image = Global.dxyDict.My.Resources.Resources.close
        Me.cmdClose.Location = New System.Drawing.Point(331, 0)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(33, 30)
        Me.cmdClose.TabIndex = 9
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'dlgSimple
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.dxyDict.My.Resources.Resources.getwordbg
        Me.ClientSize = New System.Drawing.Size(370, 197)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.wbMain)
        Me.Controls.Add(Me.lblMore)
        Me.Controls.Add(Me.lblWord)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgSimple"
        Me.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblWord As System.Windows.Forms.Label
    Friend WithEvents lblMore As System.Windows.Forms.Label
    Friend WithEvents wbMain As System.Windows.Forms.WebBrowser
    Friend WithEvents bgW As System.ComponentModel.BackgroundWorker
    Friend WithEvents cmdClose As System.Windows.Forms.Button

End Class
