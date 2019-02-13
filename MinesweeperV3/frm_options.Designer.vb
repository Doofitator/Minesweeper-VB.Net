<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_options
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
        Me.nud_gridSize = New System.Windows.Forms.NumericUpDown()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.nud_mines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nud_gridSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'nud_mines
        '
        Me.nud_mines.Location = New System.Drawing.Point(164, 14)
        Me.nud_mines.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.nud_mines.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nud_mines.Name = "nud_mines"
        Me.nud_mines.Size = New System.Drawing.Size(74, 20)
        Me.nud_mines.TabIndex = 0
        Me.nud_mines.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nud_gridSize
        '
        Me.nud_gridSize.Location = New System.Drawing.Point(164, 38)
        Me.nud_gridSize.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.nud_gridSize.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nud_gridSize.Name = "nud_gridSize"
        Me.nud_gridSize.Size = New System.Drawing.Size(74, 20)
        Me.nud_gridSize.TabIndex = 1
        Me.nud_gridSize.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(137, 64)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(101, 23)
        Me.btn_save.TabIndex = 2
        Me.btn_save.Text = "Save && new game"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Mines"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Grid size (square)"
        '
        'frm_options
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(250, 99)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.nud_gridSize)
        Me.Controls.Add(Me.nud_mines)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_options"
        Me.Text = "Options"
        CType(Me.nud_mines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nud_gridSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nud_mines As NumericUpDown
    Friend WithEvents nud_gridSize As NumericUpDown
    Friend WithEvents btn_save As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
