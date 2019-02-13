Public Class frm_main
    Public int_btnSize As Integer = 30
    Public int_gridSize As Integer = 30
    Public int_minesAmount As Integer = 10
    Public btnArray_btns(int_gridSize, int_gridSize) As Button
    Public btnArray_mines As New List(Of Button)
    Public bool_InitialLoad As Boolean = True
    Public btn_lastClicked As Button = Nothing

    Public Sub frm_main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnArray_mines.Clear()
        tssl_ticker.Text = 0
        tssl_remainingMines.Text = int_minesAmount + 1
        Me.ClientSize = New Size(int_btnSize * int_gridSize, (int_btnSize * int_gridSize) + 22)
        btn_lastClicked = Nothing
        loadGrid()

        If bool_InitialLoad Then
            bool_InitialLoad = False
            int_gridSize = 10
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
        For y = 0 To int_gridSize - 1
            For x = 0 To int_gridSize - 1
                btnArray_btns(x, y) = New Button()
                With btnArray_btns(x, y)
                    .Width = int_btnSize
                    .Height = int_btnSize
                    .Top = x * int_btnSize
                    .Left = y * int_btnSize
                    .TabStop = 0
                    .Name = x & "_" & y
                    .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                    .BackColor = SystemColors.ControlDark
                    .FlatStyle = FlatStyle.Flat
                    .FlatAppearance.BorderColor = Color.Black
                End With
                Me.Controls.Add(btnArray_btns(x, y))
                AddHandler btnArray_btns(x, y).Click, AddressOf mine     '| this basically causes everything to run twice, but its 2019 
                AddHandler btnArray_btns(x, y).MouseDown, AddressOf rightClick '| and everyone has 8GB of ram and > 2Ghz processor so I dont really care
            Next
        Next
        loadMines()
    End Function

    Function loadMines()
        Dim btnArray_tempButtons As List(Of Button) = New List(Of Button)
        For Each control In Me.Controls
            If TypeOf control Is Button Then
                btnArray_tempButtons.Add(control)
            End If
        Next
        For i = 0 To int_minesAmount
            Dim minebtn As Button
tryAgain:
            Randomize()
            Try
                minebtn = btnArray_tempButtons.Item(CInt(Math.Ceiling(Rnd() * (int_gridSize ^ 2))))
            Catch
                GoTo tryAgain
            End Try

            If btnArray_mines.Contains(minebtn) Then
                GoTo tryAgain
            Else
                btnArray_mines.Add(minebtn)
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
            ElseIf this.BackColor = Color.Cyan Then
                this.BackColor = SystemColors.ControlDark
            ElseIf this.BackColor = SystemColors.ControlDark Then
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

                If Not AreSame(SafeList, btnArray_mines) Then
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
        btn_lastClicked = this
        'making sure because i really don't want to deal with this later
        If this.Enabled = False Then Exit Sub

        If this.BackColor = SystemColors.ControlDark Then
            this.BackColor = Color.FromArgb(254, 254, 254, 254)
            this.FlatStyle = FlatStyle.Flat
            this.FlatAppearance.BorderColor = Color.Black
            'get x,y
            Dim x As Integer
            Dim y As Integer
            Dim found As Boolean = False
            For y = 0 To int_gridSize - 1
                For x = 0 To int_gridSize - 1
                    If sender Is btnArray_btns(x, y) Then found = True : Exit For
                Next
                If found = True Then Exit For
            Next



            If btnArray_mines.Contains(this) Then
                'GAME OVER
                For Each mineLocation In btnArray_mines
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
                    lst_surrounds.Add(btnArray_btns(x - 1, y - 1))   'top left
                Catch
                End Try
                Try
                    lst_surrounds.Add(btnArray_btns(x, y - 1))       'top
                Catch
                End Try
                Try
                    lst_surrounds.Add(btnArray_btns(x + 1, y - 1))   'top right
                Catch
                End Try
                Try
                    lst_surrounds.Add(btnArray_btns(x - 1, y))       'left
                Catch
                End Try
                Try
                    lst_surrounds.Add(btnArray_btns(x + 1, y))       'right
                Catch
                End Try
                Try
                    lst_surrounds.Add(btnArray_btns(x - 1, y + 1))   'bottom left
                Catch
                End Try
                Try
                    lst_surrounds.Add(btnArray_btns(x, y + 1))       'bottom
                Catch
                End Try
                Try
                    lst_surrounds.Add(btnArray_btns(x + 1, y + 1))   'bottom right
                Catch
                End Try

                'if surrounding items are a bomb
                Dim surroundingBombs As Integer = 0
                For Each surroundingbtn As Button In lst_surrounds
                    If btnArray_mines.Contains(surroundingbtn) Then
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
                    For a = x To int_gridSize - 1
                        btnArray_btns(a, y).PerformClick() 'Click on btnArray_btns(a, y)
                        If Not btnArray_btns(a, y).Text = "" Then Exit For
                    Next 'next

                    For a = x To 0 Step -1
                        btnArray_btns(a, y).PerformClick() 'Click on btnArray_btns(a, y)
                        If Not btnArray_btns(a, y).Text = "" Then Exit For
                    Next

                    For b = y To int_gridSize - 1
                        btnArray_btns(x, b).PerformClick() 'lick on arrbtns(x, b)
                        If Not btnArray_btns(x, b).Text = "" Then Exit For
                    Next

                    For b = y To 0 Step -1
                        btnArray_btns(x, b).PerformClick() 'Click on arrbtns(x, b)
                        If Not btnArray_btns(x, b).Text = "" Then Exit For
                    Next

                    Dim for1 As Boolean = False
                    For a = x To int_gridSize - 1
                        For b = y To int_gridSize - 1
                            btnArray_btns(a, b).PerformClick() 'click on arrbtns(a,b)
                            If Not btnArray_btns(a, b).Text = "" Then for1 = True : Exit For
                        Next
                        If for1 = True Then Exit For
                    Next

                    Dim for2 As Boolean = False
                    For a = x To 0 Step -1
                        For b = y To 0 Step -1
                            btnArray_btns(a, b).PerformClick() 'click on arrbtns(a,b)
                            If Not btnArray_btns(a, b).Text = "" Then for2 = True : Exit For
                        Next
                        If for2 = True Then Exit For
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub tsmi_newGame_Click(sender As Object, e As EventArgs) Handles tsmi_newGame.Click
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

    Private Sub tsmi_Settings_Click(sender As Object, e As EventArgs) Handles tsmi_Settings.Click
        frm_options.ShowDialog()
    End Sub

    Private Sub tsmi_About_Click(sender As Object, e As MouseEventArgs) Handles tsmi_about.MouseDown
        MsgBox("Minesweeper Clone" & vbCrLf & "Created by Ash Sharkey for VCE Software Development 2018-19.", vbOKOnly + vbInformation, "About")
    End Sub

    Private Sub tsmi_cheat_Click(sender As Object, e As EventArgs) Handles tsmi_cheat.Click

        'find latest click
        If btn_lastClicked Is Nothing Then
            btn_lastClicked = DirectCast(Controls("0_0"), Button)
        ElseIf CInt(btn_lastClicked.Name.Split("_"c)(0)) > int_gridSize Then
            btn_lastClicked = DirectCast(Controls("0_0"), Button)
        End If

        Dim str_closestName As String = Nothing
        Dim int_closestLen As Integer = Nothing

        'find next closest mine
        For Each btn_mine In btnArray_mines
            Dim str_btnName = btn_mine.Name

            If btn_mine.BackColor = Color.Blue Then
                GoTo nextFor
            End If

            Try
                Dim int_btnName_X As Integer = CInt(str_btnName.Split("_"c)(0))
                Dim int_btnName_Y As Integer = CInt(str_btnName.Split("_"c)(1))
                Dim int_lastClicked_X As Integer = CInt(btn_lastClicked.Name.Split("_"c)(0))
                Dim int_lastClicked_Y As Integer = CInt(btn_lastClicked.Name.Split("_"c)(1))

                Dim int_distance As Integer
                int_distance = Math.Sqrt((int_btnName_X - int_lastClicked_X) ^ 2 + (int_btnName_Y - int_lastClicked_Y) ^ 2)
                If int_distance < int_closestLen Or int_closestLen = Nothing Then
                    int_closestLen = int_distance
                    str_closestName = str_btnName
                End If
            Catch
                Console.WriteLine("Out of buttons!")
            End Try
nextFor:
        Next


        'flash red

        Dim btn_nextMine As Button = Nothing
        Dim btn_temp As Control = Controls(str_closestName)

        If TypeOf btn_temp Is Button Then
            btn_nextMine = DirectCast(btn_temp, Button)
        End If
        Dim bColor = btn_nextMine.BackColor
        btn_nextMine.BackColor = Color.Red
        Dim int_count As Integer = 0
        While int_count < 7
            If int_count Mod 2 = 0 Then
                btn_nextMine.BackColor = bColor
            Else
                btn_nextMine.BackColor = Color.Red
            End If
            Threading.Thread.Sleep(20)
            Me.Refresh()
            int_count += 1
        End While

    End Sub
End Class
