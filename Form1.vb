Option Explicit On

Public Class frmMain

    Dim pile As New List(Of Integer)()
    Dim pickable As New List(Of Integer)()
    Dim leftovers As New List(Of Integer)()

    Dim myStack As New List(Of Integer)()
    Dim taxStack As New List(Of Integer)()

    Dim roundCount As Integer = 1
    Dim myTotal As Integer = 0
    Dim taxTotal As Integer = 0

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btn1.Enabled = False
        btn2.Enabled = False
        btn3.Enabled = False
        btn4.Enabled = False
        btn5.Enabled = False
        btn6.Enabled = False
        btn7.Enabled = False
        btn8.Enabled = False
        btn9.Enabled = False
        btn10.Enabled = False
        btn11.Enabled = False
        btn12.Enabled = False

        lblPlayerScore1.Text = ""
        lblPlayerScore2.Text = ""
        lblPlayerScore3.Text = ""
        lblPlayerScore4.Text = ""
        lblPlayerScore5.Text = ""
        lblPlayerScore6.Text = ""
        lblPlayerRound1.Visible = False
        lblPlayerRound2.Visible = False
        lblPlayerRound3.Visible = False
        lblPlayerRound4.Visible = False
        lblPlayerRound5.Visible = False
        lblPlayerRound6.Visible = False

        lblTaxScore1.Text = ""
        lblTaxScore2.Text = ""
        lblTaxScore3.Text = ""
        lblTaxScore4.Text = ""
        lblTaxScore5.Text = ""
        lblTaxScore6.Text = ""
        lblTaxRound1.Visible = False
        lblTaxRound2.Visible = False
        lblTaxRound3.Visible = False
        lblTaxRound4.Visible = False
        lblTaxRound5.Visible = False
        lblTaxRound6.Visible = False
    End Sub

    Private Sub btnStartGame_Click(sender As Object, e As EventArgs) Handles btnStartGame.Click
        pile = New List(Of Integer)({1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12})
        pickable = New List(Of Integer)({2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12})
        leftovers = New List(Of Integer)()

        myStack = New List(Of Integer)()
        taxStack = New List(Of Integer)()

        roundCount = 1
        myTotal = 0
        taxTotal = 0

        btn2.Enabled = True
        btn3.Enabled = True
        btn4.Enabled = True
        btn5.Enabled = True
        btn6.Enabled = True
        btn7.Enabled = True
        btn8.Enabled = True
        btn9.Enabled = True
        btn10.Enabled = True
        btn11.Enabled = True
        btn12.Enabled = True

        btn1.BackColor = Color.White
        btn2.BackColor = Color.White
        btn3.BackColor = Color.White
        btn4.BackColor = Color.White
        btn5.BackColor = Color.White
        btn6.BackColor = Color.White
        btn7.BackColor = Color.White
        btn8.BackColor = Color.White
        btn9.BackColor = Color.White
        btn10.BackColor = Color.White
        btn11.BackColor = Color.White
        btn12.BackColor = Color.White

        lblPlayerScore1.Text = ""
        lblPlayerScore2.Text = ""
        lblPlayerScore3.Text = ""
        lblPlayerScore4.Text = ""
        lblPlayerScore5.Text = ""
        lblPlayerScore6.Text = ""
        lblPlayerRound1.Visible = False
        lblPlayerRound2.Visible = False
        lblPlayerRound3.Visible = False
        lblPlayerRound4.Visible = False
        lblPlayerRound5.Visible = False
        lblPlayerRound6.Visible = False

        lblTaxScore1.Text = ""
        lblTaxScore2.Text = ""
        lblTaxScore3.Text = ""
        lblTaxScore4.Text = ""
        lblTaxScore5.Text = ""
        lblTaxScore6.Text = ""
        lblTaxRound1.Visible = False
        lblTaxRound2.Visible = False
        lblTaxRound3.Visible = False
        lblTaxRound4.Visible = False
        lblTaxRound5.Visible = False
        lblTaxRound6.Visible = False

        lblPlayerScoreTotal.Text = "0"
        lblTaxScoreTotal.Text = "0"
        lblInfo.Text = "Pick a number from the pile:"

        MsgBox("Reset numbers, ready to start new game")
    End Sub

    Private Sub btnInstructions_Click(sender As Object, e As EventArgs) Handles btnInstructions.Click
        Dim msg As String
        msg = "HOW TO PLAY:" + vbNewLine + vbNewLine
        msg = msg + "Each round, you can choose any number from the pile which also has factors in the pile."
        msg = msg + " (Factors are numbers that divide evenly into a number)" + vbNewLine + vbNewLine
        msg = msg + "After you choose a number, the Tax Man receives all of the factors of that number which are still in the pile." + vbNewLine + vbNewLine
        msg = msg + "When there are no more numbers in the pile which also have factors in the pile, the Tax Man receives all remaining numbers in the pile." + vbNewLine + vbNewLine
        msg = msg + "Your final score is the sum of all of your chosen numbers."
        msg = msg + " Try to get a higher final score than the Tax Man to win!"
        MsgBox(msg)
    End Sub

    Private Sub updateScores(myScore As String, taxScore As String)
        'MsgBox(String.Join(",", pile.ToArray()))
        'MsgBox(String.Join(",", pickable.ToArray()))


        If roundCount = 1 Then
            lblPlayerRound1.Visible = True
            lblPlayerScore1.Text = myScore
            lblTaxRound1.Visible = True
            lblTaxScore1.Text = taxScore
        ElseIf roundCount = 2 Then
            lblPlayerRound2.Visible = True
            lblPlayerScore2.Text = myScore
            lblTaxRound2.Visible = True
            lblTaxScore2.Text = taxScore
        ElseIf roundCount = 3 Then
            lblPlayerRound3.Visible = True
            lblPlayerScore3.Text = myScore
            lblTaxRound3.Visible = True
            lblTaxScore3.Text = taxScore
        ElseIf roundCount = 4 Then
            lblPlayerRound4.Visible = True
            lblPlayerScore4.Text = myScore
            lblTaxRound4.Visible = True
            lblTaxScore4.Text = taxScore
        ElseIf roundCount = 5 Then
            lblPlayerRound5.Visible = True
            lblPlayerScore5.Text = myScore
            lblTaxRound5.Visible = True
            lblTaxScore5.Text = taxScore
        ElseIf roundCount = 6 Then
            lblPlayerRound6.Visible = True
            lblPlayerScore6.Text = myScore
            lblTaxRound6.Visible = True
            lblTaxScore6.Text = taxScore
        End If

        If pickable.Count = 0 Then

            If pile.Contains(1) Then
                taxTotal = taxTotal + 1
                btn1.BackColor = Color.Red
                If Not leftovers.Contains(1) Then
                    leftovers.Add(1)
                End If
            End If

            If pile.Contains(2) Then
                taxTotal = taxTotal + 2
                btn2.BackColor = Color.Red
                If Not leftovers.Contains(2) Then
                    leftovers.Add(2)
                End If
            End If

            If pile.Contains(3) Then
                taxTotal = taxTotal + 3
                btn3.BackColor = Color.Red
                If Not leftovers.Contains(3) Then
                    leftovers.Add(3)
                End If
            End If

            If pile.Contains(4) Then
                taxTotal = taxTotal + 4
                btn4.BackColor = Color.Red
                If Not leftovers.Contains(4) Then
                    leftovers.Add(4)
                End If
            End If

            If pile.Contains(5) Then
                taxTotal = taxTotal + 5
                btn5.BackColor = Color.Red
                If Not leftovers.Contains(5) Then
                    leftovers.Add(5)
                End If
            End If

            If pile.Contains(6) Then
                taxTotal = taxTotal + 6
                btn6.BackColor = Color.Red
                If Not leftovers.Contains(6) Then
                    leftovers.Add(6)
                End If
            End If

            If pile.Contains(7) Then
                taxTotal = taxTotal + 7
                btn7.BackColor = Color.Red
                If Not leftovers.Contains(7) Then
                    leftovers.Add(7)
                End If
            End If

            If pile.Contains(8) Then
                taxTotal = taxTotal + 8
                btn8.BackColor = Color.Red
                If Not leftovers.Contains(8) Then
                    leftovers.Add(8)
                End If
            End If

            If pile.Contains(9) Then
                taxTotal = taxTotal + 9
                btn9.BackColor = Color.Red
                If Not leftovers.Contains(9) Then
                    leftovers.Add(9)
                End If
            End If

            If pile.Contains(10) Then
                taxTotal = taxTotal + 10
                btn10.BackColor = Color.Red
                If Not leftovers.Contains(10) Then
                    leftovers.Add(10)
                End If
            End If

            If pile.Contains(11) Then
                taxTotal = taxTotal + 11
                btn11.BackColor = Color.Red
                If Not leftovers.Contains(11) Then
                    leftovers.Add(11)
                End If
            End If

            If pile.Contains(12) Then
                taxTotal = taxTotal + 12
                btn12.BackColor = Color.Red
                If Not leftovers.Contains(12) Then
                    leftovers.Add(12)
                End If
            End If

            lblTaxRound6.Text = "Leftovers:"
            lblTaxRound6.Visible = True
            lblTaxScore6.Text = String.Join(",", leftovers.ToArray())

            lblPlayerScoreTotal.Text = Str(myTotal)
            lblTaxScoreTotal.Text = Str(taxTotal)

            If myTotal > taxTotal Then
                lblInfo.Text = "You beat the Tax Man! Play again?"
                MsgBox("YOU WIN!")
            Else
                lblInfo.Text = "The Tax Man won! Play again?"
                MsgBox("YOU LOSE.")
            End If
        End If

        lblPlayerScoreTotal.Text = Str(myTotal)
        lblTaxScoreTotal.Text = Str(taxTotal)
    End Sub

    Private Sub updatePickables()
        If Not pile.Contains(1) Then
            btn2.Enabled = False
            btn3.Enabled = False
            btn5.Enabled = False
            btn7.Enabled = False
            btn11.Enabled = False
            pickable.Remove(2)
            pickable.Remove(3)
            pickable.Remove(5)
            pickable.Remove(7)
            pickable.Remove(11)
        End If

        If ((Not pile.Contains(1)) And (Not pile.Contains(2))) Then
            btn4.Enabled = False
            pickable.Remove(4)
        End If

        If ((Not pile.Contains(1)) And (Not pile.Contains(2)) And (Not pile.Contains(3))) Then
            btn6.Enabled = False
            pickable.Remove(6)
        End If

        If ((Not pile.Contains(1)) And (Not pile.Contains(2)) And (Not pile.Contains(4))) Then
            btn8.Enabled = False
            pickable.Remove(8)
        End If

        If ((Not pile.Contains(1)) And (Not pile.Contains(3))) Then
            btn9.Enabled = False
            pickable.Remove(9)
        End If

        If ((Not pile.Contains(1)) And (Not pile.Contains(2)) And (Not pile.Contains(5))) Then
            btn10.Enabled = False
            pickable.Remove(10)
        End If

        If ((Not pile.Contains(1)) And (Not pile.Contains(2)) And (Not pile.Contains(3)) And (Not pile.Contains(4)) And (Not pile.Contains(6))) Then
            btn12.Enabled = False
            pickable.Remove(12)
        End If
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        myStack.Add(2)
        pile.Remove(2)
        pickable.Remove(2)
        myTotal = myTotal + 2
        btn2.BackColor = Color.Green

        Dim myScore As String = "2"
        Dim taxScore As String = ""

        If pile.Contains(1) Then
            taxStack.Add(1)
            pile.Remove(1)
            pickable.Remove(1)
            taxTotal = taxTotal + 1
            taxScore = "1"
            btn1.BackColor = Color.Red
        End If

        updatePickables()
        updateScores(myScore, taxScore)
        roundCount = roundCount + 1
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        myStack.Add(3)
        pile.Remove(3)
        pickable.Remove(3)
        myTotal = myTotal + 3
        btn3.BackColor = Color.Green

        Dim myScore As String = "3"
        Dim taxScore As String = ""

        If pile.Contains(1) Then
            taxStack.Add(1)
            pile.Remove(1)
            pickable.Remove(1)
            taxTotal = taxTotal + 1
            taxScore = "1"
            btn1.BackColor = Color.Red
        End If

        updatePickables()
        updateScores(myScore, taxScore)
        roundCount = roundCount + 1
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        myStack.Add(4)
        pile.Remove(4)
        pickable.Remove(4)
        myTotal = myTotal + 4
        btn4.BackColor = Color.Green

        Dim myScore As String = "4"
        Dim taxScore As String = ""

        If ((pile.Contains(2)) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(2)
            pile.Remove(1)
            pile.Remove(2)
            pickable.Remove(1)
            pickable.Remove(2)
            taxTotal = taxTotal + 3
            taxScore = "1, 2"
            btn1.BackColor = Color.Red
            btn2.BackColor = Color.Red
        ElseIf pile.Contains(2) Then
            taxStack.Add(2)
            pile.Remove(2)
            pickable.Remove(2)
            taxTotal = taxTotal + 2
            taxScore = "2"
            btn2.BackColor = Color.Red
        ElseIf pile.Contains(1) Then
            taxStack.Add(1)
            pile.Remove(1)
            pickable.Remove(1)
            taxTotal = taxTotal + 1
            taxScore = "1"
            btn1.BackColor = Color.Red
        End If

        updatePickables()
        updateScores(myScore, taxScore)
        roundCount = roundCount + 1
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        myStack.Add(5)
        pile.Remove(5)
        pickable.Remove(5)
        myTotal = myTotal + 5
        btn5.BackColor = Color.Green

        Dim myScore As String = "5"
        Dim taxScore As String = ""

        If pile.Contains(1) Then
            taxStack.Add(1)
            pile.Remove(1)
            pickable.Remove(1)
            taxTotal = taxTotal + 1
            taxScore = "1"
            btn1.BackColor = Color.Red
        End If

        updatePickables()
        updateScores(myScore, taxScore)
        roundCount = roundCount + 1
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        myStack.Add(6)
        pile.Remove(6)
        pickable.Remove(6)
        myTotal = myTotal + 6
        btn6.BackColor = Color.Green

        Dim myScore As String = "6"
        Dim taxScore As String = ""

        If ((pile.Contains(3)) And pile.Contains(2) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(2)
            taxStack.Add(3)
            pile.Remove(1)
            pile.Remove(2)
            pile.Remove(3)
            pickable.Remove(1)
            pickable.Remove(2)
            pickable.Remove(3)
            taxTotal = taxTotal + 6
            taxScore = "1, 2, 3"
            btn1.BackColor = Color.Red
            btn2.BackColor = Color.Red
            btn3.BackColor = Color.Red
        ElseIf ((pile.Contains(3)) And pile.Contains(2)) Then
            taxStack.Add(2)
            taxStack.Add(3)
            pile.Remove(2)
            pile.Remove(3)
            pickable.Remove(2)
            pickable.Remove(3)
            taxTotal = taxTotal + 5
            taxScore = "2, 3"
            btn2.BackColor = Color.Red
            btn3.BackColor = Color.Red
        ElseIf ((pile.Contains(3)) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(3)
            pile.Remove(1)
            pile.Remove(3)
            pickable.Remove(1)
            pickable.Remove(3)
            taxTotal = taxTotal + 4
            taxScore = "1, 3"
            btn1.BackColor = Color.Red
            btn3.BackColor = Color.Red
        ElseIf ((pile.Contains(2)) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(2)
            pile.Remove(1)
            pile.Remove(2)
            pickable.Remove(1)
            pickable.Remove(2)
            taxTotal = taxTotal + 3
            taxScore = "1, 2"
            btn1.BackColor = Color.Red
            btn2.BackColor = Color.Red
        ElseIf pile.Contains(3) Then
            taxStack.Add(3)
            pile.Remove(3)
            pickable.Remove(3)
            taxTotal = taxTotal + 3
            taxScore = "3"
            btn3.BackColor = Color.Red
        ElseIf pile.Contains(2) Then
            taxStack.Add(2)
            pile.Remove(2)
            pickable.Remove(2)
            taxTotal = taxTotal + 2
            taxScore = "2"
            btn2.BackColor = Color.Red
        ElseIf pile.Contains(1) Then
            taxStack.Add(1)
            pile.Remove(1)
            pickable.Remove(1)
            taxTotal = taxTotal + 1
            taxScore = "1"
            btn1.BackColor = Color.Red
        End If

        updatePickables()
        updateScores(myScore, taxScore)
        roundCount = roundCount + 1
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        myStack.Add(7)
        pile.Remove(7)
        pickable.Remove(7)
        myTotal = myTotal + 7
        btn7.BackColor = Color.Green

        Dim myScore As String = "7"
        Dim taxScore As String = ""

        If pile.Contains(1) Then
            taxStack.Add(1)
            pile.Remove(1)
            pickable.Remove(1)
            taxTotal = taxTotal + 1
            taxScore = "1"
            btn1.BackColor = Color.Red
        End If

        updatePickables()
        updateScores(myScore, taxScore)
        roundCount = roundCount + 1
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        myStack.Add(8)
        pile.Remove(8)
        pickable.Remove(8)
        myTotal = myTotal + 8
        btn8.BackColor = Color.Green

        Dim myScore As String = "8"
        Dim taxScore As String = ""

        If ((pile.Contains(4)) And pile.Contains(2) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(2)
            taxStack.Add(4)
            pile.Remove(1)
            pile.Remove(2)
            pile.Remove(4)
            pickable.Remove(1)
            pickable.Remove(2)
            pickable.Remove(4)
            taxTotal = taxTotal + 7
            taxScore = "1, 2, 4"
            btn1.BackColor = Color.Red
            btn2.BackColor = Color.Red
            btn4.BackColor = Color.Red
        ElseIf ((pile.Contains(4)) And pile.Contains(2)) Then
            taxStack.Add(2)
            taxStack.Add(4)
            pile.Remove(2)
            pile.Remove(4)
            pickable.Remove(2)
            pickable.Remove(4)
            taxTotal = taxTotal + 6
            taxScore = "2, 4"
            btn2.BackColor = Color.Red
            btn4.BackColor = Color.Red
        ElseIf ((pile.Contains(4)) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(4)
            pile.Remove(1)
            pile.Remove(4)
            pickable.Remove(1)
            pickable.Remove(4)
            taxTotal = taxTotal + 5
            taxScore = "1, 4"
            btn1.BackColor = Color.Red
            btn4.BackColor = Color.Red
        ElseIf ((pile.Contains(2)) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(2)
            pile.Remove(1)
            pile.Remove(2)
            pickable.Remove(1)
            pickable.Remove(2)
            taxTotal = taxTotal + 3
            taxScore = "1, 2"
            btn1.BackColor = Color.Red
            btn2.BackColor = Color.Red
        ElseIf pile.Contains(4) Then
            taxStack.Add(4)
            pile.Remove(4)
            pickable.Remove(4)
            taxTotal = taxTotal + 4
            taxScore = "4"
            btn4.BackColor = Color.Red
        ElseIf pile.Contains(2) Then
            taxStack.Add(2)
            pile.Remove(2)
            pickable.Remove(2)
            taxTotal = taxTotal + 2
            taxScore = "2"
            btn2.BackColor = Color.Red
        ElseIf pile.Contains(1) Then
            taxStack.Add(1)
            pile.Remove(1)
            pickable.Remove(1)
            taxTotal = taxTotal + 1
            taxScore = "1"
            btn1.BackColor = Color.Red
        End If

        updatePickables()
        updateScores(myScore, taxScore)
        roundCount = roundCount + 1
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        myStack.Add(9)
        pile.Remove(9)
        pickable.Remove(9)
        myTotal = myTotal + 9
        btn9.BackColor = Color.Green

        Dim myScore As String = "9"
        Dim taxScore As String = ""

        If ((pile.Contains(3)) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(3)
            pile.Remove(1)
            pile.Remove(3)
            pickable.Remove(1)
            pickable.Remove(3)
            taxTotal = taxTotal + 4
            taxScore = "1, 3"
            btn1.BackColor = Color.Red
            btn3.BackColor = Color.Red
        ElseIf pile.Contains(3) Then
            taxStack.Add(3)
            pile.Remove(3)
            pickable.Remove(3)
            taxTotal = taxTotal + 3
            taxScore = "3"
            btn3.BackColor = Color.Red
        ElseIf pile.Contains(1) Then
            taxStack.Add(1)
            pile.Remove(1)
            pickable.Remove(1)
            taxTotal = taxTotal + 1
            taxScore = "1"
            btn1.BackColor = Color.Red
        End If

        updatePickables()
        updateScores(myScore, taxScore)
        roundCount = roundCount + 1
    End Sub

    Private Sub btn10_Click(sender As Object, e As EventArgs) Handles btn10.Click
        myStack.Add(10)
        pile.Remove(10)
        pickable.Remove(10)
        myTotal = myTotal + 10
        btn10.BackColor = Color.Green

        Dim myScore As String = "10"
        Dim taxScore As String = ""

        If ((pile.Contains(5)) And pile.Contains(2) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(2)
            taxStack.Add(5)
            pile.Remove(1)
            pile.Remove(2)
            pile.Remove(5)
            pickable.Remove(1)
            pickable.Remove(2)
            pickable.Remove(5)
            taxTotal = taxTotal + 8
            taxScore = "1, 2, 5"
            btn1.BackColor = Color.Red
            btn2.BackColor = Color.Red
            btn5.BackColor = Color.Red
        ElseIf ((pile.Contains(5)) And pile.Contains(2)) Then
            taxStack.Add(2)
            taxStack.Add(5)
            pile.Remove(2)
            pile.Remove(5)
            pickable.Remove(2)
            pickable.Remove(5)
            taxTotal = taxTotal + 7
            taxScore = "2, 5"
            btn2.BackColor = Color.Red
            btn5.BackColor = Color.Red
        ElseIf ((pile.Contains(5)) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(5)
            pile.Remove(1)
            pile.Remove(5)
            pickable.Remove(1)
            pickable.Remove(5)
            taxTotal = taxTotal + 6
            taxScore = "1, 5"
            btn1.BackColor = Color.Red
            btn5.BackColor = Color.Red
        ElseIf ((pile.Contains(2)) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(2)
            pile.Remove(1)
            pile.Remove(2)
            pickable.Remove(1)
            pickable.Remove(2)
            taxTotal = taxTotal + 3
            taxScore = "1, 2"
            btn1.BackColor = Color.Red
            btn2.BackColor = Color.Red
        ElseIf pile.Contains(5) Then
            taxStack.Add(5)
            pile.Remove(5)
            pickable.Remove(5)
            taxTotal = taxTotal + 5
            taxScore = "5"
            btn5.BackColor = Color.Red
        ElseIf pile.Contains(2) Then
            taxStack.Add(2)
            pile.Remove(2)
            pickable.Remove(2)
            taxTotal = taxTotal + 2
            taxScore = "2"
            btn2.BackColor = Color.Red
        ElseIf pile.Contains(1) Then
            taxStack.Add(1)
            pile.Remove(1)
            pickable.Remove(1)
            taxTotal = taxTotal + 1
            taxScore = "1"
            btn1.BackColor = Color.Red
        End If

        updatePickables()
        updateScores(myScore, taxScore)
        roundCount = roundCount + 1
    End Sub

    Private Sub btn11_Click(sender As Object, e As EventArgs) Handles btn11.Click
        myStack.Add(11)
        pile.Remove(11)
        pickable.Remove(11)
        myTotal = myTotal + 11
        btn11.BackColor = Color.Green

        Dim myScore As String = "11"
        Dim taxScore As String = ""

        If pile.Contains(1) Then
            taxStack.Add(1)
            pile.Remove(1)
            pickable.Remove(1)
            taxTotal = taxTotal + 1
            taxScore = "1"
            btn1.BackColor = Color.Red
        End If

        updatePickables()
        updateScores(myScore, taxScore)
        roundCount = roundCount + 1
    End Sub

    Private Sub btn12_Click(sender As Object, e As EventArgs) Handles btn12.Click
        myStack.Add(12)
        pile.Remove(12)
        pickable.Remove(12)
        myTotal = myTotal + 12
        btn12.BackColor = Color.Green

        Dim myScore As String = "12"
        Dim taxScore As String = ""

        If ((pile.Contains(6)) And pile.Contains(4) And pile.Contains(3) And pile.Contains(2) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(2)
            taxStack.Add(3)
            taxStack.Add(4)
            taxStack.Add(6)
            pile.Remove(1)
            pile.Remove(2)
            pile.Remove(3)
            pile.Remove(4)
            pile.Remove(6)
            pickable.Remove(1)
            pickable.Remove(2)
            pickable.Remove(3)
            pickable.Remove(4)
            pickable.Remove(6)
            taxTotal = taxTotal + 16
            taxScore = "1, 2, 3, 4, 6"
            btn1.BackColor = Color.Red
            btn2.BackColor = Color.Red
            btn3.BackColor = Color.Red
            btn4.BackColor = Color.Red
            btn6.BackColor = Color.Red
        ElseIf ((pile.Contains(6)) And pile.Contains(4) And pile.Contains(3) And pile.Contains(2)) Then
            taxStack.Add(2)
            taxStack.Add(3)
            taxStack.Add(4)
            taxStack.Add(6)
            pile.Remove(2)
            pile.Remove(3)
            pile.Remove(4)
            pile.Remove(6)
            pickable.Remove(2)
            pickable.Remove(3)
            pickable.Remove(4)
            pickable.Remove(6)
            taxTotal = taxTotal + 15
            taxScore = "2, 3, 4, 6"
            btn2.BackColor = Color.Red
            btn3.BackColor = Color.Red
            btn4.BackColor = Color.Red
            btn6.BackColor = Color.Red
        ElseIf ((pile.Contains(6)) And pile.Contains(4) And pile.Contains(3) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(3)
            taxStack.Add(4)
            taxStack.Add(6)
            pile.Remove(1)
            pile.Remove(3)
            pile.Remove(4)
            pile.Remove(6)
            pickable.Remove(1)
            pickable.Remove(3)
            pickable.Remove(4)
            pickable.Remove(6)
            taxTotal = taxTotal + 14
            taxScore = "1, 3, 4, 6"
            btn1.BackColor = Color.Red
            btn3.BackColor = Color.Red
            btn4.BackColor = Color.Red
            btn6.BackColor = Color.Red
        ElseIf ((pile.Contains(6)) And pile.Contains(4) And pile.Contains(2) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(2)
            taxStack.Add(4)
            taxStack.Add(6)
            pile.Remove(1)
            pile.Remove(2)
            pile.Remove(4)
            pile.Remove(6)
            pickable.Remove(1)
            pickable.Remove(2)
            pickable.Remove(4)
            pickable.Remove(6)
            taxTotal = taxTotal + 13
            taxScore = "1, 2, 4, 6"
            btn1.BackColor = Color.Red
            btn2.BackColor = Color.Red
            btn4.BackColor = Color.Red
            btn6.BackColor = Color.Red
        ElseIf ((pile.Contains(6)) And pile.Contains(3) And pile.Contains(2) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(2)
            taxStack.Add(3)
            taxStack.Add(6)
            pile.Remove(1)
            pile.Remove(2)
            pile.Remove(3)
            pile.Remove(6)
            pickable.Remove(1)
            pickable.Remove(2)
            pickable.Remove(3)
            pickable.Remove(6)
            taxTotal = taxTotal + 12
            taxScore = "1, 2, 3, 6"
            btn1.BackColor = Color.Red
            btn2.BackColor = Color.Red
            btn3.BackColor = Color.Red
            btn6.BackColor = Color.Red
        ElseIf ((pile.Contains(4)) And pile.Contains(3) And pile.Contains(2) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(2)
            taxStack.Add(3)
            taxStack.Add(4)
            pile.Remove(1)
            pile.Remove(2)
            pile.Remove(3)
            pile.Remove(4)
            pickable.Remove(1)
            pickable.Remove(2)
            pickable.Remove(3)
            pickable.Remove(4)
            taxTotal = taxTotal + 10
            taxScore = "1, 2, 3, 4"
            btn1.BackColor = Color.Red
            btn2.BackColor = Color.Red
            btn3.BackColor = Color.Red
            btn4.BackColor = Color.Red
        ElseIf ((pile.Contains(6)) And pile.Contains(4) And pile.Contains(3)) Then
            taxStack.Add(3)
            taxStack.Add(4)
            taxStack.Add(6)
            pile.Remove(3)
            pile.Remove(4)
            pile.Remove(6)
            pickable.Remove(3)
            pickable.Remove(4)
            pickable.Remove(6)
            taxTotal = taxTotal + 13
            taxScore = "3, 4, 6"
            btn3.BackColor = Color.Red
            btn4.BackColor = Color.Red
            btn6.BackColor = Color.Red
        ElseIf ((pile.Contains(6)) And pile.Contains(4) And pile.Contains(2)) Then
            taxStack.Add(2)
            taxStack.Add(4)
            taxStack.Add(6)
            pile.Remove(2)
            pile.Remove(4)
            pile.Remove(6)
            pickable.Remove(2)
            pickable.Remove(4)
            pickable.Remove(6)
            taxTotal = taxTotal + 12
            taxScore = "2, 4, 6"
            btn2.BackColor = Color.Red
            btn4.BackColor = Color.Red
            btn6.BackColor = Color.Red
        ElseIf ((pile.Contains(6)) And pile.Contains(4) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(4)
            taxStack.Add(6)
            pile.Remove(1)
            pile.Remove(4)
            pile.Remove(6)
            pickable.Remove(1)
            pickable.Remove(4)
            pickable.Remove(6)
            taxTotal = taxTotal + 11
            taxScore = "1, 4, 6"
            btn1.BackColor = Color.Red
            btn4.BackColor = Color.Red
            btn6.BackColor = Color.Red
        ElseIf ((pile.Contains(6)) And pile.Contains(3) And pile.Contains(2)) Then
            taxStack.Add(2)
            taxStack.Add(3)
            taxStack.Add(6)
            pile.Remove(2)
            pile.Remove(3)
            pile.Remove(6)
            pickable.Remove(2)
            pickable.Remove(3)
            pickable.Remove(6)
            taxTotal = taxTotal + 11
            taxScore = "2, 3, 6"
            btn2.BackColor = Color.Red
            btn3.BackColor = Color.Red
            btn6.BackColor = Color.Red
        ElseIf ((pile.Contains(6)) And pile.Contains(3) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(3)
            taxStack.Add(6)
            pile.Remove(1)
            pile.Remove(3)
            pile.Remove(6)
            pickable.Remove(1)
            pickable.Remove(3)
            pickable.Remove(6)
            taxTotal = taxTotal + 10
            taxScore = "1, 3, 6"
            btn1.BackColor = Color.Red
            btn3.BackColor = Color.Red
            btn6.BackColor = Color.Red
        ElseIf ((pile.Contains(6)) And pile.Contains(2) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(2)
            taxStack.Add(6)
            pile.Remove(1)
            pile.Remove(2)
            pile.Remove(6)
            pickable.Remove(1)
            pickable.Remove(2)
            pickable.Remove(6)
            taxTotal = taxTotal + 9
            taxScore = "1, 2, 6"
            btn1.BackColor = Color.Red
            btn2.BackColor = Color.Red
            btn6.BackColor = Color.Red
        ElseIf ((pile.Contains(4)) And pile.Contains(3) And pile.Contains(2)) Then
            taxStack.Add(2)
            taxStack.Add(3)
            taxStack.Add(4)
            pile.Remove(2)
            pile.Remove(3)
            pile.Remove(4)
            pickable.Remove(2)
            pickable.Remove(3)
            pickable.Remove(4)
            taxTotal = taxTotal + 9
            taxScore = "2, 3, 4"
            btn2.BackColor = Color.Red
            btn3.BackColor = Color.Red
            btn4.BackColor = Color.Red
        ElseIf ((pile.Contains(4)) And pile.Contains(3) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(3)
            taxStack.Add(4)
            pile.Remove(1)
            pile.Remove(3)
            pile.Remove(4)
            pickable.Remove(1)
            pickable.Remove(3)
            pickable.Remove(4)
            taxTotal = taxTotal + 8
            taxScore = "1, 3, 4"
            btn1.BackColor = Color.Red
            btn3.BackColor = Color.Red
            btn4.BackColor = Color.Red
        ElseIf ((pile.Contains(4)) And pile.Contains(2) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(2)
            taxStack.Add(4)
            pile.Remove(1)
            pile.Remove(2)
            pile.Remove(4)
            pickable.Remove(1)
            pickable.Remove(2)
            pickable.Remove(4)
            taxTotal = taxTotal + 7
            taxScore = "1, 2, 4"
            btn1.BackColor = Color.Red
            btn2.BackColor = Color.Red
            btn4.BackColor = Color.Red
        ElseIf ((pile.Contains(3)) And pile.Contains(2) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(2)
            taxStack.Add(3)
            pile.Remove(1)
            pile.Remove(2)
            pile.Remove(3)
            pickable.Remove(1)
            pickable.Remove(2)
            pickable.Remove(3)
            taxTotal = taxTotal + 6
            taxScore = "1, 2, 3"
            btn1.BackColor = Color.Red
            btn2.BackColor = Color.Red
            btn3.BackColor = Color.Red
        ElseIf ((pile.Contains(6)) And pile.Contains(4)) Then
            taxStack.Add(4)
            taxStack.Add(6)
            pile.Remove(4)
            pile.Remove(6)
            pickable.Remove(4)
            pickable.Remove(6)
            taxTotal = taxTotal + 10
            taxScore = "4, 6"
            btn4.BackColor = Color.Red
            btn6.BackColor = Color.Red
        ElseIf ((pile.Contains(6)) And pile.Contains(3)) Then
            taxStack.Add(3)
            taxStack.Add(6)
            pile.Remove(3)
            pile.Remove(6)
            pickable.Remove(3)
            pickable.Remove(6)
            taxTotal = taxTotal + 9
            taxScore = "3, 6"
            btn3.BackColor = Color.Red
            btn6.BackColor = Color.Red
        ElseIf ((pile.Contains(6)) And pile.Contains(2)) Then
            taxStack.Add(2)
            taxStack.Add(6)
            pile.Remove(2)
            pile.Remove(6)
            pickable.Remove(2)
            pickable.Remove(6)
            taxTotal = taxTotal + 8
            taxScore = "2, 6"
            btn2.BackColor = Color.Red
            btn6.BackColor = Color.Red
        ElseIf ((pile.Contains(6)) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(6)
            pile.Remove(1)
            pile.Remove(6)
            pickable.Remove(1)
            pickable.Remove(6)
            taxTotal = taxTotal + 7
            taxScore = "1, 6"
            btn1.BackColor = Color.Red
            btn6.BackColor = Color.Red
        ElseIf ((pile.Contains(4)) And pile.Contains(3)) Then
            taxStack.Add(3)
            taxStack.Add(4)
            pile.Remove(3)
            pile.Remove(4)
            pickable.Remove(3)
            pickable.Remove(4)
            taxTotal = taxTotal + 7
            taxScore = "3, 4"
            btn3.BackColor = Color.Red
            btn4.BackColor = Color.Red
        ElseIf ((pile.Contains(4)) And pile.Contains(2)) Then
            taxStack.Add(2)
            taxStack.Add(4)
            pile.Remove(2)
            pile.Remove(4)
            pickable.Remove(2)
            pickable.Remove(4)
            taxTotal = taxTotal + 6
            taxScore = "2, 4"
            btn2.BackColor = Color.Red
            btn4.BackColor = Color.Red
        ElseIf ((pile.Contains(4)) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(4)
            pile.Remove(1)
            pile.Remove(4)
            pickable.Remove(1)
            pickable.Remove(4)
            taxTotal = taxTotal + 5
            taxScore = "1, 4"
            btn1.BackColor = Color.Red
            btn4.BackColor = Color.Red
        ElseIf ((pile.Contains(3)) And pile.Contains(2)) Then
            taxStack.Add(2)
            taxStack.Add(3)
            pile.Remove(2)
            pile.Remove(3)
            pickable.Remove(2)
            pickable.Remove(3)
            taxTotal = taxTotal + 5
            taxScore = "2, 3"
            btn2.BackColor = Color.Red
            btn3.BackColor = Color.Red
        ElseIf ((pile.Contains(3)) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(3)
            pile.Remove(1)
            pile.Remove(3)
            pickable.Remove(1)
            pickable.Remove(3)
            taxTotal = taxTotal + 4
            taxScore = "1, 3"
            btn1.BackColor = Color.Red
            btn3.BackColor = Color.Red
        ElseIf ((pile.Contains(2)) And pile.Contains(1)) Then
            taxStack.Add(1)
            taxStack.Add(2)
            pile.Remove(1)
            pile.Remove(2)
            pickable.Remove(1)
            pickable.Remove(2)
            taxTotal = taxTotal + 3
            taxScore = "1, 2"
            btn1.BackColor = Color.Red
            btn2.BackColor = Color.Red
        ElseIf pile.Contains(6) Then
            taxStack.Add(6)
            pile.Remove(6)
            pickable.Remove(6)
            taxTotal = taxTotal + 6
            taxScore = "6"
            btn6.BackColor = Color.Red
        ElseIf pile.Contains(4) Then
            taxStack.Add(4)
            pile.Remove(4)
            pickable.Remove(4)
            taxTotal = taxTotal + 4
            taxScore = "4"
            btn4.BackColor = Color.Red
        ElseIf pile.Contains(3) Then
            taxStack.Add(3)
            pile.Remove(3)
            pickable.Remove(3)
            taxTotal = taxTotal + 3
            taxScore = "3"
            btn3.BackColor = Color.Red
        ElseIf pile.Contains(2) Then
            taxStack.Add(2)
            pile.Remove(2)
            pickable.Remove(2)
            taxTotal = taxTotal + 2
            taxScore = "2"
            btn2.BackColor = Color.Red
        ElseIf pile.Contains(1) Then
            taxStack.Add(1)
            pile.Remove(1)
            pickable.Remove(1)
            taxTotal = taxTotal + 1
            taxScore = "1"
            btn1.BackColor = Color.Red
        End If

        updatePickables()
        updateScores(myScore, taxScore)
        roundCount = roundCount + 1
    End Sub
End Class
