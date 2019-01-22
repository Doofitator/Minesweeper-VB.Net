﻿Public Class frm_main
    Public button_size As Integer = 30
    Public grid_size As Integer = 30
    Public mines_amount As Integer = 10
    Public arr_btns(grid_size, grid_size) As Button
    Public mine_btns As New List(Of Button)
    Public firstStart As Boolean = True

    Public Sub frm_main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mine_btns.Clear()
        tssl_ticker.Text = 0
        tssl_remainingMines.Text = mines_amount + 1
        Me.ClientSize = New Size(button_size * grid_size, (button_size * grid_size) + 22)
        loadGrid()

        If firstStart Then
            firstStart = False
            grid_size = 10
            Dim ctrlList As New List(Of Button)
            For Each control In Me.Controls
                If Not TypeOf control Is StatusStrip And Not TypeOf control Is Timer Then
                    ctrlList.Add(control)
                End If
            Next
            For Each control In ctrlList
                Me.Controls.Remove(control)
            Next
            frm_main_Load(sender, e)
        End If


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
                    .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                    .BackColor = SystemColors.ControlLight
                    .FlatStyle = FlatStyle.Flat
                    .FlatAppearance.BorderColor = Color.Black
                End With
                Me.Controls.Add(arr_btns(x, y))
                AddHandler arr_btns(x, y).Click, AddressOf mine     '| this basically causes everything to run twice, but its 2019 
                AddHandler arr_btns(x, y).MouseDown, AddressOf rightClick '| and everyone has 8GB of ram and > 2Ghz processor so I dont really care
            Next
        Next
        loadMines()
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
        Next
    End Function

    Sub addcount(sender As Object, e As EventArgs) Handles tmr.Tick
        tssl_ticker.Text += 1
    End Sub

    Public Function AreSame(ByVal List1 As List(Of Button), ByVal List2 As List(Of Button)) As Boolean
        If List1.Count <> List2.Count Then
            Return False
        End If

        For i As Integer = 0 To List1.Count - 1

            If Not List2.Contains(List1(i)) Or Not List1.Contains(List2(i)) Then
                Return False
            End If
        Next

        Return True
    End Function

    Sub rightClick(sender As Object, e As MouseEventArgs)
        Dim this As Button = CType(sender, Button)
        If e.Button = MouseButtons.Right Then
            If this.BackColor = Color.Blue Then
                this.BackColor = Color.Cyan
                tssl_remainingMines.Text += 1
            ElseIf this.BackColor = Color.cyan Then
                this.BackColor = SystemColors.ControlLight
            ElseIf this.BackColor = SystemColors.ControlLight Then
                this.BackColor = Color.Blue
                tssl_remainingMines.Text -= 1
            End If

            If tssl_remainingMines.Text <= 0 Then
                Dim SafeList As New List(Of Button)
                For Each control In Me.Controls
                    If TypeOf control Is Button Then
                        If control.backcolor = Color.Blue Then SafeList.Add(control)
                    End If
                Next

                If Not AreSame(SafeList, mine_btns) Then
                    Exit Sub
                End If

                MsgBox("You win!")
                Dim ctrlList As New List(Of Button)
                For Each control In Me.Controls
                    If Not TypeOf control Is StatusStrip And Not TypeOf control Is Timer Then
                        ctrlList.Add(control)
                    End If
                Next
                For Each control In ctrlList
                    Me.Controls.Remove(control)
                Next
                frm_main_Load(sender, e)
            End If
        End If
    End Sub

    Sub mine(sender As Object, e As EventArgs)
        Dim this As Button = CType(sender, Button)
        'making sure because i really don't want to deal with this later
        If this.Enabled = False Then Exit Sub

        If this.BackColor = SystemColors.ControlLight Then
            this.BackColor = Color.FromArgb(254, 254, 254, 254)
            this.FlatStyle = FlatStyle.Flat
            this.FlatAppearance.BorderColor = Color.Black
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
                For Each mineLocation In mine_btns
                    If Not mineLocation.BackColor = Color.Blue Then
                        mineLocation.BackColor = Color.Yellow
                    Else
                        mineLocation.BackColor = Color.LightGreen
                    End If
                Next
                this.BackColor = Color.Red
                MsgBox("You lose!")
                Dim ctrlList As New List(Of Button)
                For Each control In Me.Controls
                    If Not TypeOf control Is StatusStrip And Not TypeOf control Is Timer Then
                        ctrlList.Add(control)
                    End If
                Next
                For Each control In ctrlList
                    Me.Controls.Remove(control)
                Next
                frm_main_Load(sender, e)
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
                    Select Case surroundingBombs
                        Case 1
                            this.ForeColor = Color.Blue
                        Case 2
                            this.ForeColor = Color.Green
                        Case 3
                            this.ForeColor = Color.Red
                        Case 4
                            this.ForeColor = Color.DarkBlue
                        Case 5
                            this.ForeColor = Color.DarkRed
                        Case 6
                            this.ForeColor = Color.DarkCyan
                        Case 7
                            this.ForeColor = Color.Purple
                        Case 8
                            this.ForeColor = Color.Black
                    End Select
                    Exit Sub
                Else
                    this.BackColor = Color.FromArgb(254, 254, 254, 254)
                    this.FlatStyle = FlatStyle.Flat
                    this.FlatAppearance.BorderColor = Color.Black
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
            If Not TypeOf control Is StatusStrip And Not TypeOf control Is Timer Then
                ctrlList.Add(control)
            End If
        Next
        For Each control In ctrlList
            Me.Controls.Remove(control)
        Next
        frm_main_Load(sender, e)
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        frm_settings.ShowDialog()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As MouseEventArgs) Handles AboutToolStripMenuItem.MouseDown
        MsgBox("Minesweeper Clone" & vbCrLf & "Created by Ash Sharkey for VCE Software Development 2018-19.", vbOKOnly + vbInformation, "About")
    End Sub
End Class
