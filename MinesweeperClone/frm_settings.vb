Public Class frm_settings
    Private Sub btn_changeSettings_Click(sender As Object, e As EventArgs) Handles btn_changeSettings.Click
        For Each c As Control In frm_minesweeper.grp_field.Controls
            frm_minesweeper.grp_field.Controls.Remove(c)
        Next

        frm_minesweeper.mines = nud_mines.Value
        frm_minesweeper.cols = nud_columns.Value
        frm_minesweeper.rows = nud_rows.Value
        frm_minesweeper.makePlayingField()
    End Sub
End Class