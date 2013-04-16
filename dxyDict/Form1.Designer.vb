<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.bgW = New System.ComponentModel.BackgroundWorker()
        Me.tmrGetWord = New System.Windows.Forms.Timer(Me.components)
        Me.wbMain = New System.Windows.Forms.WebBrowser()
        Me.cmOp = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.sbMain = New System.Windows.Forms.StatusStrip()
        Me.lblLink = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmdSet = New System.Windows.Forms.ToolStripDropDownButton()
        Me.mnuCursor = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuClipboard = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblCollapse = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.cmOp.SuspendLayout()
        Me.sbMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtInput
        '
        Me.txtInput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInput.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtInput.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtInput.Location = New System.Drawing.Point(3, 9)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(379, 23)
        Me.txtInput.TabIndex = 0
        '
        'bgW
        '
        '
        'tmrGetWord
        '
        Me.tmrGetWord.Enabled = True
        Me.tmrGetWord.Interval = 700
        '
        'wbMain
        '
        Me.wbMain.AllowWebBrowserDrop = False
        Me.wbMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wbMain.ContextMenuStrip = Me.cmOp
        Me.wbMain.IsWebBrowserContextMenuEnabled = False
        Me.wbMain.Location = New System.Drawing.Point(3, 38)
        Me.wbMain.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbMain.Name = "wbMain"
        Me.wbMain.Size = New System.Drawing.Size(412, 131)
        Me.wbMain.TabIndex = 7
        '
        'cmOp
        '
        Me.cmOp.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCopy})
        Me.cmOp.Name = "cmOp"
        Me.cmOp.Size = New System.Drawing.Size(146, 26)
        '
        'mnuCopy
        '
        Me.mnuCopy.Name = "mnuCopy"
        Me.mnuCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.mnuCopy.Size = New System.Drawing.Size(145, 22)
        Me.mnuCopy.Text = "复制"
        '
        'sbMain
        '
        Me.sbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblLink, Me.cmdSet, Me.lblCollapse})
        Me.sbMain.Location = New System.Drawing.Point(0, 173)
        Me.sbMain.Name = "sbMain"
        Me.sbMain.Size = New System.Drawing.Size(420, 23)
        Me.sbMain.TabIndex = 8
        Me.sbMain.Text = "状态栏"
        '
        'lblLink
        '
        Me.lblLink.IsLink = True
        Me.lblLink.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lblLink.Name = "lblLink"
        Me.lblLink.Size = New System.Drawing.Size(100, 18)
        Me.lblLink.Text = "查看更多例句……"
        '
        'cmdSet
        '
        Me.cmdSet.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCursor, Me.mnuClipboard})
        Me.cmdSet.Image = Global.dxyDict.My.Resources.Resources.hover
        Me.cmdSet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSet.Name = "cmdSet"
        Me.cmdSet.Size = New System.Drawing.Size(85, 21)
        Me.cmdSet.Text = "取词设置"
        '
        'mnuCursor
        '
        Me.mnuCursor.AutoToolTip = True
        Me.mnuCursor.CheckOnClick = True
        Me.mnuCursor.Name = "mnuCursor"
        Me.mnuCursor.Size = New System.Drawing.Size(136, 22)
        Me.mnuCursor.Text = "悬停取词"
        Me.mnuCursor.ToolTipText = "设置是否允许鼠标悬停取词"
        '
        'mnuClipboard
        '
        Me.mnuClipboard.AutoToolTip = True
        Me.mnuClipboard.Checked = True
        Me.mnuClipboard.CheckOnClick = True
        Me.mnuClipboard.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuClipboard.Name = "mnuClipboard"
        Me.mnuClipboard.Size = New System.Drawing.Size(136, 22)
        Me.mnuClipboard.Text = "剪贴板取词"
        Me.mnuClipboard.ToolTipText = "设置是否允许自动进行剪贴板取词"
        '
        'lblCollapse
        '
        Me.lblCollapse.Image = CType(resources.GetObject("lblCollapse.Image"), System.Drawing.Image)
        Me.lblCollapse.IsLink = True
        Me.lblCollapse.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lblCollapse.LinkColor = System.Drawing.Color.Black
        Me.lblCollapse.Name = "lblCollapse"
        Me.lblCollapse.Size = New System.Drawing.Size(102, 18)
        Me.lblCollapse.Text = "迷你窗口(&ESC)"
        '
        'cmdSearch
        '
        Me.cmdSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSearch.Image = CType(resources.GetObject("cmdSearch.Image"), System.Drawing.Image)
        Me.cmdSearch.Location = New System.Drawing.Point(384, 7)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(32, 25)
        Me.cmdSearch.TabIndex = 1
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 196)
        Me.Controls.Add(Me.sbMain)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.wbMain)
        Me.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "丁香词典"
        Me.cmOp.ResumeLayout(False)
        Me.sbMain.ResumeLayout(False)
        Me.sbMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtInput As System.Windows.Forms.TextBox
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents bgW As System.ComponentModel.BackgroundWorker
    Friend WithEvents tmrGetWord As System.Windows.Forms.Timer
    Friend WithEvents wbMain As System.Windows.Forms.WebBrowser
    Friend WithEvents sbMain As System.Windows.Forms.StatusStrip
    Friend WithEvents lblLink As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmdSet As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuCursor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuClipboard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblCollapse As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmOp As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuCopy As System.Windows.Forms.ToolStripMenuItem

End Class
