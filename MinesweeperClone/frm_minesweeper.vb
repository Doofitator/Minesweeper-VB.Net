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
        End While
    End Function

    Private Sub mine(sender As Object, e As MouseEventArgs)
        Dim c As Control = CType(sender, Button)
        Dim cNum As Integer = CInt(c.Name.Replace("field", "").Trim())

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
                If Not isPointOnLeftEdge(cNum) Then
                    btnNames.Add("field" & (cNum + (cols - 1)))
                    btnNames.Add("field" & (cNum - 1))
                    btnNames.Add("field" & (cNum - (cols + 1)))
                End If                                                                  '//TODO: None of this works if you're on the top or bottom edges
                If Not isPointOnRightEdge(cNum) Then
                    btnNames.Add("field" & (cNum + (cols + 1)))
                    btnNames.Add("field" & (cNum + 1))
                    btnNames.Add("field" & (cNum - (cols - 1)))
                End If

                If Not isPointOnTopEdge(cNum) Then btnNames.Add("field" & (cNum + (cols)))
                If Not isPointOnBottomEdge(cNum) Then btnNames.Add("field" & (cNum - (cols)))

                For Each controlName As String In btnNames
                    surrounds.Add(CType(Me.grp_field.Controls(controlName), Button))
                Next
                'now we've got surrounds with all the surrounding whosamawhatsits
                For Each surroundingBtn As Button In surrounds
                    Console.WriteLine(surroundingBtn.Name)

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

    End Function
    Function isPointOnBottomEdge(cNum As Integer)

    End Function

    Function isPointNextToMines(cNum As Integer)
        'todo: this shit
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
End Class
