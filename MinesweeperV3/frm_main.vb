Public Class frm_main
    Public button_size As Integer = 30
    Public grid_size As Integer = 20
    Public mines_amount As Integer = 50
    Public arr_btns(grid_size, grid_size) As Button
    Public mine_btns(grid_size, grid_size) As Integer

    Private Sub frm_main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ClientSize = New Size(button_size * grid_size, (button_size * grid_size) + 22)
        loadGrid()
    End Sub

    Function loadGrid()
        For y = 0 To grid_size - 1
            For x = 0 To grid_size - 1
                arr_btns(x, y) = New Button()
                With arr_btns(x, y)
                    .Width = button_size
                    .Height = button_size
                    .Top = x * button_size
                    .Left = y * button_size
                    .TabStop = 0
                    .Name = x & "_" & y
                End With
                Me.Controls.Add(arr_btns(x, y))
                AddHandler arr_btns(x, y).Click, AddressOf mine
            Next
        Next
        loadMines()
        Dim tmr As New Timer
        With tmr
            .Enabled = True
            .Interval = 1000
        End With
        AddHandler tmr.Tick, AddressOf addcount
    End Function

    Function loadMines()
        For y = 0 To grid_size - 1
            For x = 0 To grid_size - 1
                mine_btns(x, y) = New Integer()
                Randomize()

            Next
        Next
    End Function

    Sub addcount(sender As Object, e As EventArgs)
        tssl_ticker.Text += 1
    End Sub

    Sub mine(sender As Object, e As EventArgs)
        Console.WriteLine(CType(sender, Button).Name)
    End Sub

    Private Sub NewGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewGameToolStripMenuItem.Click
        Dim ctrlList As New List(Of Button)
        For Each control In Me.Controls
            If Not TypeOf control Is StatusStrip Then
                ctrlList.Add(control)
            End If
        Next
        For Each control In ctrlList
            Me.Controls.Remove(control)
        Next
        frm_main_Load(sender, e)
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        'show settings form to change grid size and amount of mines
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click

    End Sub
End Class
