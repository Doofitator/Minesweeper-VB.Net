Public Class frm_minesweeper
    Dim minesList As List(Of Integer) = New List(Of Integer)
    Public rows As Integer
    Public cols As Integer
    Public mines As Integer

    Private Sub frm_minesweeper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btn_status.BackgroundImage = My.Resources.happy
        btn_status.BackgroundImageLayout = ImageLayout.Zoom

        rows = 20
        cols = 16
        mines = 20
        makePlayingField()
    End Sub

    Function makePlayingField()
        Dim i As Integer = rows
        While i > 0
            'for every row
            Dim x As Integer = cols
            While x > 0
                'for each column of each row
                Dim btn As New Button
                Dim btnNumber = ((i - 1) * cols) + x
                btn.Name = "field" & btnNumber
                grp_field.Controls.Add(btn)
                btn.Top = i * 20
                btn.Left = x * 20
                btn.Width = 20
                btn.Height = 20
                btn.BackgroundImageLayout = ImageLayout.Zoom
                AddHandler btn.MouseDown, AddressOf Me.mine
                Me.Height = btn.Top + 40
                x -= 1
            End While
            i -= 1
        End While
        Me.Height = ((rows + 2) * 21) + (40 + btn_status.Height) + 25
        Me.Width = ((cols + 2) * 21) + 20

        ' // now for the mines //
        Dim y = mines
        While y > 0
tryAgain:
            Dim rndNum As Integer = Math.Ceiling(Rnd() * (rows * cols))
            If minesList.Contains(rndNum) Then
                GoTo tryAgain
            Else
                minesList.Add(rndNum)
            End If
            y -= 1
            Randomize()
        End While

        'debugging:
        For Each Location As Integer In minesList
            Console.Write(Location & ", ")
        Next
        Console.WriteLine()
    End Function

    Private Sub mine(sender As Object, e As MouseEventArgs)
        Dim c As Control = CType(sender, Button)
        Dim cNum As Integer = CInt(c.Name.Replace("field", "").Trim())
        If Not c.Text = "" Then Exit Sub
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If c.BackgroundImage IsNot Nothing Then c.BackgroundImage = Nothing : Exit Sub
            c.BackgroundImage = My.Resources.flag
            Exit Sub
        ElseIf e.Button = MouseButtons.Left Then
            If c.BackgroundImage IsNot Nothing Then
                'Console.WriteLine("Can't touch this DURR NURR NURR NURR DUR NUR DUR NUR")
                Exit Sub
            End If
            If minesList.Contains(cNum) Then
                'oops u ded
                'Console.WriteLine("BOOM")
                btn_status.BackgroundImage = My.Resources.dead
                c.BackgroundImage = My.Resources.badMine
                For Each c2 As Control In grp_field.Controls
                    If c2 IsNot c Then
                        If minesList.Contains(CInt(c2.Name.Replace("field", "").Trim())) Then
                            c2.BackgroundImage = My.Resources.goodMine
                        End If
                    End If
                Next
            Else
                'yay u safe
                'Console.WriteLine("Safe")

                Dim surrounds As List(Of Control) = New List(Of Control)
                Dim btnNames As List(Of String) = New List(Of String)
                Dim topLeft As String = "field" & (cNum - (cols + 1))
                Dim top As String = "field" & (cNum - (cols))
                Dim topRight As String = "field" & (cNum - (cols - 1))
                Dim middleLeft As String = "field" & (cNum - 1)
                Dim middleRight As String = "field" & (cNum + 1)
                Dim bottomLeft As String = "field" & (cNum + (cols - 1))
                Dim bottom As String = "field" & (cNum + (cols))
                Dim bottomRight As String = "field" & (cNum + (cols + 1))

                If isPointOnLeftEdge(cNum) Then
                    btnNames.Add(middleRight)
                    If isPointOnTopEdge(cNum) Then
                        btnNames.Add(bottomRight)
                        btnNames.Add(bottom)
                    ElseIf isPointOnBottomEdge(cNum) Then
                        btnNames.Add(topRight)
                        btnNames.Add(top)
                    Else
                        btnNames.Add(bottomRight)
                        btnNames.Add(bottom)
                        btnNames.Add(topRight)
                        btnNames.Add(top)
                    End If
                ElseIf isPointOnRightEdge(cNum) Then
                    btnNames.Add(middleLeft)
                    If isPointOnTopEdge(cNum) Then
                        btnNames.Add(bottomLeft)
                        btnNames.Add(bottom)
                    ElseIf isPointOnBottomEdge(cNum) Then
                        btnNames.Add(topLeft)
                        btnNames.Add(top)
                    Else
                        btnNames.Add(bottomLeft)
                        btnNames.Add(bottom)
                        btnNames.Add(topLeft)
                        btnNames.Add(top)
                    End If
                ElseIf isPointOnBottomEdge(cNum) Then
                    btnNames.Add(middleLeft)
                    btnNames.Add(topLeft)
                    btnNames.Add(top)
                    btnNames.Add(topRight)
                    btnNames.Add(middleRight)
                ElseIf isPointOnTopEdge(cNum) Then
                    btnNames.Add(middleLeft)
                    btnNames.Add(bottomLeft)
                    btnNames.Add(bottom)
                    btnNames.Add(bottomRight)
                    btnNames.Add(middleRight)
                Else
                    btnNames.Add(top)
                    btnNames.Add(topRight)
                    btnNames.Add(middleRight)
                    btnNames.Add(bottomRight)
                    btnNames.Add(bottom)
                    btnNames.Add(bottomLeft)
                    btnNames.Add(middleLeft)
                    btnNames.Add(topLeft)
                End If

                For Each controlName As String In btnNames
                    surrounds.Add(CType(Me.grp_field.Controls(controlName), Button))
                Next

                'now we've got surrounds with all the surrounding whosamawhatsits

                'check the one you clicked first
                If minesNearPoint(cNum) > 0 Then
                    Select Case minesNearPoint(cNum)
                        Case 0
                            c.Enabled = False
                            GoTo surroundsCheck
                        Case 1
                            c.ForeColor = Color.Blue
                            c.Text = 1
                        Case 2
                            c.ForeColor = Color.Green
                            c.Text = 2
                        Case 3
                            c.ForeColor = Color.Red
                            c.Text = 3
                        Case 4
                            c.ForeColor = Color.Orange
                            c.Text = 4
                        Case 5
                            c.ForeColor = Color.Gray
                            c.Text = 5
                        Case 6
                            c.ForeColor = Color.DarkOrange
                            c.Text = 6
                        Case 7
                            c.ForeColor = Color.Purple
                            c.Text = 7
                        Case 8
                            c.ForeColor = Color.Black
                            c.Text = 8
                    End Select
                    Exit Sub
                Else
                    c.Enabled = False
                End If

surroundsCheck:
                For Each surroundingBtn As Button In surrounds
                    Dim surroundingBtnNum As Integer = CInt(surroundingBtn.Name.Replace("field", "").Trim())
                    Dim amountOfMines As Integer = minesNearPoint(surroundingBtnNum)
                    Select Case amountOfMines
                        Case 0
                            surroundingBtn.Enabled = False
                        Case 1
                            surroundingBtn.ForeColor = Color.Blue
                            If Not isPointOnLeftEdge(surroundingBtnNum) And Not isPointOnRightEdge(surroundingBtnNum) Then surroundingBtn.Text = 1 Else surroundingBtn.Enabled = False
                        Case 2
                            surroundingBtn.ForeColor = Color.Green
                            If Not isPointOnLeftEdge(surroundingBtnNum) And Not isPointOnRightEdge(surroundingBtnNum) Then surroundingBtn.Text = 2 Else surroundingBtn.Enabled = False
                        Case 3
                            surroundingBtn.ForeColor = Color.Red
                            If Not isPointOnLeftEdge(surroundingBtnNum) And Not isPointOnRightEdge(surroundingBtnNum) Then surroundingBtn.Text = 3 Else surroundingBtn.Enabled = False
                        Case 4
                            surroundingBtn.ForeColor = Color.Orange
                            If Not isPointOnLeftEdge(surroundingBtnNum) And Not isPointOnRightEdge(surroundingBtnNum) Then surroundingBtn.Text = 4 Else surroundingBtn.Enabled = False
                        Case 5
                            surroundingBtn.ForeColor = Color.Gray
                            If Not isPointOnLeftEdge(surroundingBtnNum) And Not isPointOnRightEdge(surroundingBtnNum) Then surroundingBtn.Text = 5 Else surroundingBtn.Enabled = False
                        Case 6
                            surroundingBtn.ForeColor = Color.DarkOrange
                            If Not isPointOnLeftEdge(surroundingBtnNum) And Not isPointOnRightEdge(surroundingBtnNum) Then surroundingBtn.Text = 6 Else surroundingBtn.Enabled = False
                        Case 7
                            surroundingBtn.ForeColor = Color.Purple
                            If Not isPointOnLeftEdge(surroundingBtnNum) And Not isPointOnRightEdge(surroundingBtnNum) Then surroundingBtn.Text = 7 Else surroundingBtn.Enabled = False
                        Case 8
                            surroundingBtn.ForeColor = Color.Black
                            If Not isPointOnLeftEdge(surroundingBtnNum) And Not isPointOnRightEdge(surroundingBtnNum) Then surroundingBtn.Text = 8 Else surroundingBtn.Enabled = False
                    End Select
                Next
            End If
        End If
    End Sub

    Function isPointOnRightEdge(cNum As Integer)
        Dim isRight = cNum / cols
        If isRight = Int(isRight) Then
            'Console.WriteLine("box is on right edge")
            Return True
        Else
            'Console.WriteLine("box not on edge")
            Return False
        End If
    End Function

    Function isPointOnLeftEdge(cNum As Integer)
        Dim isLeft = (cNum - 1) / cols
        If isLeft = Int(isLeft) Then
            'Console.WriteLine("box is on left edge")
            Return True
        Else
            Return False
        End If
    End Function

    Function isPointOnTopEdge(cNum As Integer)
        If cNum <= cols Then Return True Else Return False
    End Function
    Function isPointOnBottomEdge(cNum As Integer)
        If cNum > ((cols * rows) - cols) Then Return True Else Return False
    End Function

    Function minesNearPoint(cNum As Integer) As Integer
        Dim topLeft As Integer = (cNum - (cols + 1))
        Dim top As Integer = (cNum - (cols))
        Dim topRight As Integer = (cNum - (cols - 1))
        Dim middleLeft As Integer = (cNum - 1)
        Dim middleRight As Integer = (cNum + 1)
        Dim bottomLeft As Integer = (cNum + (cols - 1))
        Dim bottom As Integer = (cNum + (cols))
        Dim bottomRight As Integer = (cNum + (cols + 1))
        Dim cList As List(Of Integer) = New List(Of Integer)
        cList.Add(topLeft)
        cList.Add(top)
        cList.Add(topRight)
        cList.Add(middleLeft)
        cList.Add(middleRight)
        cList.Add(bottomLeft)
        cList.Add(bottom)
        cList.Add(bottomRight)
        Dim amountOfMines As Integer = 0

        For Each mine As Integer In minesList
            For Each possibility As Integer In cList
                If mine = possibility Then
                    amountOfMines += 1
                End If
            Next
        Next

        Return amountOfMines
    End Function

    Private Sub frm_minesweeper_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        grp_field.Width = Me.Width - 40
        grp_field.Height = Me.Height - 72 - btn_status.Height - 25
        lbl_time.Left = Me.Width - lbl_time.Width - 12
        btn_status.Left = (Me.Width / 2) - (btn_status.Width / 2)
    End Sub

    Private Sub tsmi_options_Click(sender As Object, e As EventArgs) Handles tsmi_options.Click
        frm_settings.ShowDialog()
    End Sub

    Private Sub tsmi_about_Click(sender As Object, e As EventArgs) Handles tsmi_about.Click
        MsgBox("Minesweeper Clone" & vbCrLf & "Created by Ash Sharkey for VCE Software Development 2018-19.", vbOKOnly + vbInformation, "About")
    End Sub

    Private Sub tsmi_exit_Click(sender As Object, e As EventArgs) Handles tsmi_exit.Click
        End
    End Sub

    Private Sub btn_status_Click(sender As Object, e As EventArgs) Handles btn_status.Click
        For Each btn As Button In grp_field.Controls
            btn.Enabled = True
            btn.BackgroundImage = Nothing
            btn.Text = ""
        Next
        lbl_mines.Text = "0000"
        lbl_time.Text = "0000"
        minesList.Clear()
        makePlayingField()
        btn_status.Image = My.Resources.happy
    End Sub
End Class
