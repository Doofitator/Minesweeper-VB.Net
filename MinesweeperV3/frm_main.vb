Public Class frm_main
    Public button_size As Integer = 30
    Public grid_size As Integer = 20
    Public mines_amount As Integer = 50
    Public arr_btns(grid_size, grid_size) As Button
    Public mine_btns As New List(Of Button)

    Private Sub frm_main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mine_btns.Clear()
        tssl_ticker.Text = 0
        tssl_remainingMines.Text = mines_amount
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
                AddHandler arr_btns(x, y).Click, AddressOf mine     '| this basically causes everything to run twice, but its 2019 
                AddHandler arr_btns(x, y).MouseDown, AddressOf rightClick '| and everyone has 8GB of ram and > 2Ghz processor so I dont really care
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
        Dim btnsList As List(Of Button) = New List(Of Button)
        For Each control In Me.Controls
            If TypeOf control Is Button Then
                btnsList.Add(control)
            End If
        Next
        For i = 0 To mines_amount
            Dim minebtn As Button
tryAgain:
            Randomize()
            Try
                minebtn = btnsList.Item(CInt(Math.Ceiling(Rnd() * (grid_size ^ 2))))
            Catch
                GoTo tryAgain
            End Try

            If mine_btns.Contains(mineBtn) Then
                GoTo tryAgain
            Else
                mine_btns.Add(mineBtn)
            End If
            Console.Write(mineBtn.Name & "  -  ")
        Next
        Console.WriteLine()
    End Function

    Sub addcount(sender As Object, e As EventArgs)
        tssl_ticker.Text += 1
    End Sub

    Sub rightClick(sender As Object, e As MouseEventArgs)
        Dim this As Button = CType(sender, Button)
        If Not this.BackColor = Color.Blue Then

            If e.Button = MouseButtons.Right Then
                this.BackColor = Color.Blue
                tssl_remainingMines.Text -= 1
                Exit Sub
            End If

        Else
            If e.Button = MouseButtons.Right Then this.BackColor = Nothing : this.UseVisualStyleBackColor = True : tssl_remainingMines.Text += 1
        End If
    End Sub

    Function h(i As Integer)
        Console.WriteLine(i)
    End Function

    Sub mine(sender As Object, e As EventArgs)
        Dim this As Button = CType(sender, Button)
        'making sure because i really don't want to deal with this later
        If this.Enabled = False Then Exit Sub

        If Not this.BackColor = Color.Blue Then
            'get x,y
            Dim x As Integer
            Dim y As Integer
            Dim found As Boolean = False
            For y = 0 To grid_size - 1
                For x = 0 To grid_size - 1
                    If sender Is arr_btns(x, y) Then found = True : Exit For
                Next
                If found = True Then Exit For
            Next



            If mine_btns.Contains(this) Then
                'GAME OVER
                this.BackColor = Color.Red
            Else
                'find surrounding items
                Dim lst_surrounds As New List(Of Button)

                'the following are wrapped in individual try/catch because say you click the top left most button on the field - you'll cause an indexoutofrangeexception. There are better ways to handle this, but I've been working on some form of this project all summer, so I really can't be bothered anymore.

                Try
                    lst_surrounds.Add(arr_btns(x - 1, y - 1))   'top left
                Catch
                End Try
                Try
                    lst_surrounds.Add(arr_btns(x, y - 1))       'top
                Catch
                End Try
                Try
                    lst_surrounds.Add(arr_btns(x + 1, y - 1))   'top right
                Catch
                End Try
                Try
                    lst_surrounds.Add(arr_btns(x - 1, y))       'left
                Catch
                End Try
                Try
                    lst_surrounds.Add(arr_btns(x + 1, y))       'right
                Catch
                End Try
                Try
                    lst_surrounds.Add(arr_btns(x - 1, y + 1))   'bottom left
                Catch
                End Try
                Try
                    lst_surrounds.Add(arr_btns(x, y + 1))       'bottom
                Catch
                End Try
                Try
                    lst_surrounds.Add(arr_btns(x + 1, y + 1))   'bottom right
                Catch
                End Try

                'if surrounding items are a bomb
                Dim surroundingBombs As Integer = 0
                For Each surroundingbtn As Button In lst_surrounds
                    If mine_btns.Contains(surroundingbtn) Then
                        surroundingBombs += 1
                    End If
                Next
                '.text = amount of bombs in surrounding items & EXIT SUB
                If Not surroundingBombs = 0 Then
                    this.Text = surroundingBombs
                    Exit Sub
                Else
                    this.Enabled = False
                    For a = x To grid_size - 1
                        arr_btns(a, y).PerformClick() 'Click on arr_btns(a, y)
                        If Not arr_btns(a, y).Text = "" Then Exit For
                    Next 'next

                    For a = x To 0 Step -1
                        arr_btns(a, y).PerformClick() 'Click on arr_btns(a, y)
                        If Not arr_btns(a, y).Text = "" Then Exit For
                    Next

                    For b = y To grid_size - 1
                        arr_btns(x, b).PerformClick() 'lick on arrbtns(x, b)
                        If Not arr_btns(x, b).Text = "" Then Exit For
                    Next

                    For b = y To 0 Step -1
                        arr_btns(x, b).PerformClick() 'Click on arrbtns(x, b)
                        If Not arr_btns(x, b).Text = "" Then Exit For
                    Next

                    Dim for1 As Boolean = False
                    For a = x To grid_size - 1
                        For b = y To grid_size - 1
                            arr_btns(a, b).PerformClick() 'click on arrbtns(a,b)
                            If Not arr_btns(a, b).Text = "" Then for1 = True : Exit For
                        Next
                        If for1 = True Then Exit For
                    Next

                    Dim for2 As Boolean = False
                    For a = x To 0 Step -1
                        For b = y To 0 Step -1
                            arr_btns(a, b).PerformClick() 'click on arrbtns(a,b)
                            If Not arr_btns(a, b).Text = "" Then for2 = True : Exit For
                        Next
                        If for2 = True Then Exit For
                    Next
                End If
            End If
        End If
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

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As MouseEventArgs) Handles AboutToolStripMenuItem.MouseDown

    End Sub
End Class
