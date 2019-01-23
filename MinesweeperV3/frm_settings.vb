Public Class frm_settings
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        frm_main.mines_amount = nud_mines.Value - 1
        frm_main.grid_size = nud_gridSize.Value
        Dim ctrlList As New List(Of Button)
        For Each control In frm_main.Controls
            If Not TypeOf control Is StatusStrip And Not TypeOf control Is Timer Then
                ctrlList.Add(control)
            End If
        Next
        For Each control In ctrlList
            frm_main.Controls.Remove(control)
        Next
        frm_main.frm_main_Load(sender, e)

        Me.Close()
    End Sub

    Private Sub frm_settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nud_gridSize.Value = frm_main.grid_size
        nud_mines.Value = frm_main.mines_amount + 1
    End Sub
End Class