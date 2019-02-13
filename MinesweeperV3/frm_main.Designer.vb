<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_main))
        Me.stp_info = New System.Windows.Forms.StatusStrip()
        Me.tssb_menu = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmi_about = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_settings = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_newGame = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_cheat = New System.Windows.Forms.ToolStripMenuItem()
        Me.tssl_ticker = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssl_remainingMines = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tmr = New System.Windows.Forms.Timer(Me.components)
        Me.stp_info.SuspendLayout()
        Me.SuspendLayout()
        '
        'stp_info
        '
        Me.stp_info.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssb_menu, Me.tssl_ticker, Me.tssl_remainingMines})
        Me.stp_info.Location = New System.Drawing.Point(0, 428)
        Me.stp_info.Name = "stp_info"
        Me.stp_info.Size = New System.Drawing.Size(800, 22)
        Me.stp_info.TabIndex = 0
        Me.stp_info.Text = "StatusStrip1"
        '
        'tssb_menu
        '
        Me.tssb_menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tssb_menu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_about, Me.tsmi_settings, Me.tsmi_newGame, Me.tsmi_cheat})
        Me.tssb_menu.Image = CType(resources.GetObject("tssb_menu.Image"), System.Drawing.Image)
        Me.tssb_menu.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tssb_menu.Name = "tssb_menu"
        Me.tssb_menu.Size = New System.Drawing.Size(51, 20)
        Me.tssb_menu.Text = "Menu"
        '
        'tsmi_about
        '
        Me.tsmi_about.Name = "tsmi_about"
        Me.tsmi_about.Size = New System.Drawing.Size(175, 22)
        Me.tsmi_about.Text = "About"
        '
        'tsmi_settings
        '
        Me.tsmi_settings.Name = "tsmi_settings"
        Me.tsmi_settings.Size = New System.Drawing.Size(175, 22)
        Me.tsmi_settings.Text = "Options"
        '
        'tsmi_newGame
        '
        Me.tsmi_newGame.Name = "tsmi_newGame"
        Me.tsmi_newGame.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.tsmi_newGame.Size = New System.Drawing.Size(175, 22)
        Me.tsmi_newGame.Text = "New Game"
        '
        'tsmi_cheat
        '
        Me.tsmi_cheat.Name = "tsmi_cheat"
        Me.tsmi_cheat.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.tsmi_cheat.Size = New System.Drawing.Size(175, 22)
        Me.tsmi_cheat.Text = "Hint"
        '
        'tssl_ticker
        '
        Me.tssl_ticker.Name = "tssl_ticker"
        Me.tssl_ticker.Size = New System.Drawing.Size(31, 17)
        Me.tssl_ticker.Text = "0000"
        '
        'tssl_remainingMines
        '
        Me.tssl_remainingMines.Name = "tssl_remainingMines"
        Me.tssl_remainingMines.Size = New System.Drawing.Size(31, 17)
        Me.tssl_remainingMines.Text = "0000"
        '
        'tmr
        '
        Me.tmr.Enabled = True
        Me.tmr.Interval = 1000
        '
        'frm_main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.stp_info)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frm_main"
        Me.Text = "Minesweeper"
        Me.stp_info.ResumeLayout(False)
        Me.stp_info.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents stp_info As StatusStrip
    Friend WithEvents tssb_menu As ToolStripDropDownButton
    Friend WithEvents tssl_ticker As ToolStripStatusLabel
    Friend WithEvents tssl_remainingMines As ToolStripStatusLabel
    Friend WithEvents tsmi_settings As ToolStripMenuItem
    Friend WithEvents tsmi_newGame As ToolStripMenuItem
    Friend WithEvents tsmi_about As ToolStripMenuItem
    Friend WithEvents tmr As Timer
    Friend WithEvents tsmi_cheat As ToolStripMenuItem
End Class
