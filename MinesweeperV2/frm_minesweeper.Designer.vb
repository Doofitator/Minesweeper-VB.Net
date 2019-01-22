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
        Me.grp_field = New System.Windows.Forms.GroupBox()
        Me.btn_status = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'grp_field
        '
        Me.grp_field.Location = New System.Drawing.Point(13, 42)
        Me.grp_field.Name = "grp_field"
        Me.grp_field.Size = New System.Drawing.Size(310, 307)
        Me.grp_field.TabIndex = 0
        Me.grp_field.TabStop = False
        Me.grp_field.Text = "Field"
        '
        'btn_status
        '
        Me.btn_status.Location = New System.Drawing.Point(115, 12)
        Me.btn_status.Name = "btn_status"
        Me.btn_status.Size = New System.Drawing.Size(102, 23)
        Me.btn_status.TabIndex = 1
        Me.btn_status.Text = "Button1"
        Me.btn_status.UseVisualStyleBackColor = True
        '
        'frm_minesweeper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 361)
        Me.Controls.Add(Me.btn_status)
        Me.Controls.Add(Me.grp_field)
        Me.Name = "frm_minesweeper"
        Me.Text = "Minesweeper"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grp_field As GroupBox
    Friend WithEvents btn_status As Button
End Class
