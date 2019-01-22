Imports System.Text.RegularExpressions

Public Class frm_minesweeper
    Dim minesList As List(Of Integer) = New List(Of Integer)
    Public rows As Integer
    Public cols As Integer
    Public mines As Integer
    Dim alpha() As Char = New Char() {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rows = 16
        cols = 16
        mines = 40

        makePlayingField()
    End Sub

    Private Sub frm_minesweeper_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        grp_field.Width = Me.Width - 40
        grp_field.Height = Me.Height - 72 - btn_status.Height - 25
        btn_status.Left = (Me.Width / 2) - (btn_status.Width / 2)
    End Sub

    Function makePlayingField()
        Dim i As Integer = rows
        While i > 0
            'for every row
            Dim x As Integer = cols
            While x > 0
                'for each column of each row
                Dim btn As New Button
                Dim btnNumber = i & alpha(x - 1)
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
        Dim btn As Button = CType(sender, Button)
        Dim bCoOrds = btn.Name.Replace("field", "").Trim()
        Console.WriteLine(bCoOrds & " - " & CoordinateLocator(bCoOrds))

        'look at surrounds
        Dim sbtns As List(Of Button) = New List(Of Button) 'surrounding buttons

        'CType(grp_field.Controls("field" & cNum), Button)

        Dim btnNum = bCoOrds
        For Each letter As Char In alpha
            btnNum = btnNum.Replace(letter, "")
        Next
        Dim btnAlpha = bCoOrds
        For Each number As Integer In {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16}
            btnAlpha = btnAlpha.Replace(number, "")
        Next

        Dim TL As String = ""
        Dim T As String = ""
        Dim TR As String = ""
        Dim L As String = ""
        Dim R As String = ""
        Dim BL As String = ""
        Dim B As String = ""
        Dim BR As String = ""

        Try
            TL = (btnNum - 1) & alpha(alpha.ToList.LastIndexOf(btnAlpha) - 1)
        Catch
            Console.Write("No TL, ")
        End Try
        Try
            T = (btnNum - 1) & btnAlpha
        Catch
            Console.Write("No T, ")
        End Try
        Try
            TR = (btnNum - 1) & alpha(alpha.ToList.LastIndexOf(btnAlpha) + 1)
        Catch
            Console.Write("No TR, ")
        End Try
        Try
            L = (btnNum) & alpha(alpha.ToList.LastIndexOf(btnAlpha) - 1) 'wot is happening when you hit something in row 10?
        Catch
            Console.Write("No L (" & btnAlpha & ") - (" & btnNum & "), ")
        End Try
        Try
            R = (btnNum) & alpha(alpha.ToList.LastIndexOf(btnAlpha) + 1)
        Catch
            Console.Write("No R, ")
        End Try
        Try
            BL = (btnNum + 1) & alpha(alpha.ToList.LastIndexOf(btnAlpha) - 1)
        Catch
            Console.Write("No BL, ")
        End Try
        Try
            B = (btnNum + 1) & btnAlpha
        Catch
            Console.Write("No B, ")
        End Try
        Try
            BR = (btnNum + 1) & alpha(alpha.ToList.LastIndexOf(btnAlpha) + 1)
        Catch
            Console.Write("No BR, ")
        End Try
        Console.WriteLine()

        If CoordinateLocator(bCoOrds) = "C" Then 'if it's a regular center coordinate

        End If
    End Sub

    Private Function CoordinateLocator(ByVal coordinate As String) As String
        If coordinate = "1a" Then
            Return "TL"
        ElseIf coordinate = "1p" Then
            Return "TR"
        ElseIf coordinate = "16a" Then
            Return "BL"
        ElseIf coordinate = "16p" Then
            Return "BR"
        ElseIf Not Regex.Match(coordinate, ".a").Value = "" Then
            Return "L"
        ElseIf Not Regex.Match(coordinate, ".p").Value = "" Then
            Return "R"
        ElseIf Not Regex.Match(coordinate, "16.").Value = "" Then
            Return "B"
        ElseIf Not Regex.Match(coordinate, "^1[a-z]").Value = "" Then
            Return "T"
        Else
            Return "C"
        End If
    End Function
End Class