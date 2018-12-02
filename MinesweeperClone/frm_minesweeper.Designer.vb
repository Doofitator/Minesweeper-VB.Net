<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_minesweeper
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_minesweeper))
        Me.grp_field = New System.Windows.Forms.GroupBox()
        Me.btn_status = New System.Windows.Forms.Button()
        Me.lbl_mines = New System.Windows.Forms.Label()
        Me.lbl_time = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbtn_menu = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmi_options = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_about = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grp_field
        '
        Me.grp_field.Location = New System.Drawing.Point(12, 91)
        Me.grp_field.Name = "grp_field"
        Me.grp_field.Size = New System.Drawing.Size(285, 251)
        Me.grp_field.TabIndex = 0
        Me.grp_field.TabStop = False
        '
        'btn_status
        '
        Me.btn_status.Location = New System.Drawing.Point(128, 37)
        Me.btn_status.Name = "btn_status"
        Me.btn_status.Size = New System.Drawing.Size(53, 48)
        Me.btn_status.TabIndex = 1
        Me.btn_status.UseVisualStyleBackColor = True
        '
        'lbl_mines
        '
        Me.lbl_mines.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_mines.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mines.ForeColor = System.Drawing.Color.Black
        Me.lbl_mines.Location = New System.Drawing.Point(12, 37)
        Me.lbl_mines.Name = "lbl_mines"
        Me.lbl_mines.Size = New System.Drawing.Size(110, 48)
        Me.lbl_mines.TabIndex = 2
        Me.lbl_mines.Text = "0000"
        Me.lbl_mines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_time
        '
        Me.lbl_time.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_time.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_time.ForeColor = System.Drawing.Color.Black
        Me.lbl_time.Location = New System.Drawing.Point(187, 37)
        Me.lbl_time.Name = "lbl_time"
        Me.lbl_time.Size = New System.Drawing.Size(110, 48)
        Me.lbl_time.TabIndex = 3
        Me.lbl_time.Text = "0000"
        Me.lbl_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtn_menu})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(309, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbtn_menu
        '
        Me.tsbtn_menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtn_menu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_options, Me.tsmi_about, Me.tsmi_exit})
        Me.tsbtn_menu.Image = CType(resources.GetObject("tsbtn_menu.Image"), System.Drawing.Image)
        Me.tsbtn_menu.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtn_menu.Name = "tsbtn_menu"
        Me.tsbtn_menu.Size = New System.Drawing.Size(51, 22)
        Me.tsbtn_menu.Text = "Game"
        '
        'tsmi_options
        '
        Me.tsmi_options.Name = "tsmi_options"
        Me.tsmi_options.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.tsmi_options.Size = New System.Drawing.Size(180, 22)
        Me.tsmi_options.Text = "Options"
        '
        'tsmi_about
        '
        Me.tsmi_about.Name = "tsmi_about"
        Me.tsmi_about.Size = New System.Drawing.Size(180, 22)
        Me.tsmi_about.Text = "About"
        '
        'tsmi_exit
        '
        Me.tsmi_exit.Name = "tsmi_exit"
        Me.tsmi_exit.Size = New System.Drawing.Size(180, 22)
        Me.tsmi_exit.Text = "Exit"
        '
        'frm_minesweeper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(309, 354)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.lbl_time)
        Me.Controls.Add(Me.lbl_mines)
        Me.Controls.Add(Me.btn_status)
        Me.Controls.Add(Me.grp_field)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frm_minesweeper"
        Me.Text = "Minesweeper Clone"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grp_field As GroupBox
    Friend WithEvents btn_status As Button
    Friend WithEvents lbl_mines As Label
    Friend WithEvents lbl_time As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsbtn_menu As ToolStripDropDownButton
    Friend WithEvents tsmi_options As ToolStripMenuItem
    Friend WithEvents tsmi_about As ToolStripMenuItem
    Friend WithEvents tsmi_exit As ToolStripMenuItem
End Class
