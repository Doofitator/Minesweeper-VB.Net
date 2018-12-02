<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_settings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.nud_mines = New System.Windows.Forms.NumericUpDown()
        Me.nud_rows = New System.Windows.Forms.NumericUpDown()
        Me.nud_columns = New System.Windows.Forms.NumericUpDown()
        Me.btn_changeSettings = New System.Windows.Forms.Button()
        Me.lbl_minesHint = New System.Windows.Forms.Label()
        Me.lbl_rows = New System.Windows.Forms.Label()
        Me.lbl_columns = New System.Windows.Forms.Label()
        CType(Me.nud_mines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nud_rows, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nud_columns, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'nud_mines
        '
        Me.nud_mines.Location = New System.Drawing.Point(86, 12)
        Me.nud_mines.Maximum = New Decimal(New Integer() {320, 0, 0, 0})
        Me.nud_mines.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nud_mines.Name = "nud_mines"
        Me.nud_mines.Size = New System.Drawing.Size(120, 20)
        Me.nud_mines.TabIndex = 0
        Me.nud_mines.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'nud_rows
        '
        Me.nud_rows.Location = New System.Drawing.Point(86, 39)
        Me.nud_rows.Maximum = New Decimal(New Integer() {40, 0, 0, 0})
        Me.nud_rows.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nud_rows.Name = "nud_rows"
        Me.nud_rows.Size = New System.Drawing.Size(120, 20)
        Me.nud_rows.TabIndex = 1
        Me.nud_rows.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'nud_columns
        '
        Me.nud_columns.Location = New System.Drawing.Point(86, 66)
        Me.nud_columns.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.nud_columns.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nud_columns.Name = "nud_columns"
        Me.nud_columns.Size = New System.Drawing.Size(120, 20)
        Me.nud_columns.TabIndex = 2
        Me.nud_columns.Value = New Decimal(New Integer() {16, 0, 0, 0})
        '
        'btn_changeSettings
        '
        Me.btn_changeSettings.Location = New System.Drawing.Point(131, 92)
        Me.btn_changeSettings.Name = "btn_changeSettings"
        Me.btn_changeSettings.Size = New System.Drawing.Size(75, 23)
        Me.btn_changeSettings.TabIndex = 3
        Me.btn_changeSettings.Text = "Set"
        Me.btn_changeSettings.UseVisualStyleBackColor = True
        '
        'lbl_minesHint
        '
        Me.lbl_minesHint.AutoSize = True
        Me.lbl_minesHint.Location = New System.Drawing.Point(13, 14)
        Me.lbl_minesHint.Name = "lbl_minesHint"
        Me.lbl_minesHint.Size = New System.Drawing.Size(38, 13)
        Me.lbl_minesHint.TabIndex = 4
        Me.lbl_minesHint.Text = "Mines:"
        '
        'lbl_rows
        '
        Me.lbl_rows.AutoSize = True
        Me.lbl_rows.Location = New System.Drawing.Point(13, 41)
        Me.lbl_rows.Name = "lbl_rows"
        Me.lbl_rows.Size = New System.Drawing.Size(37, 13)
        Me.lbl_rows.TabIndex = 5
        Me.lbl_rows.Text = "Rows:"
        '
        'lbl_columns
        '
        Me.lbl_columns.AutoSize = True
        Me.lbl_columns.Location = New System.Drawing.Point(13, 68)
        Me.lbl_columns.Name = "lbl_columns"
        Me.lbl_columns.Size = New System.Drawing.Size(50, 13)
        Me.lbl_columns.TabIndex = 6
        Me.lbl_columns.Text = "Columns:"
        '
        'frm_settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(218, 124)
        Me.Controls.Add(Me.lbl_columns)
        Me.Controls.Add(Me.lbl_rows)
        Me.Controls.Add(Me.lbl_minesHint)
        Me.Controls.Add(Me.btn_changeSettings)
        Me.Controls.Add(Me.nud_columns)
        Me.Controls.Add(Me.nud_rows)
        Me.Controls.Add(Me.nud_mines)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_settings"
        Me.Text = "Options"
        CType(Me.nud_mines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nud_rows, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nud_columns, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nud_mines As NumericUpDown
    Friend WithEvents nud_rows As NumericUpDown
    Friend WithEvents nud_columns As NumericUpDown
    Friend WithEvents btn_changeSettings As Button
    Friend WithEvents lbl_minesHint As Label
    Friend WithEvents lbl_rows As Label
    Friend WithEvents lbl_columns As Label
End Class
