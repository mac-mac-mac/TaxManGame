Option Explicit On

Public Class frmMain

    Dim pile As New List(Of Integer)({1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12})
    Dim pickable As New List(Of Integer)({2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12})

    Dim myStack As New List(Of Integer)()
    Dim taxStack As New List(Of Integer)()

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
    End Sub

    Private Sub btnStartGame_Click(sender As Object, e As EventArgs) Handles btnStartGame.Click
        pile = New List(Of Integer)({1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12})
        pickable = New List(Of Integer)({2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12})

        myStack = New List(Of Integer)()
        taxStack = New List(Of Integer)()

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

        While pickable.Count > 0
            pickable.RemoveAt(0)
        End While

        MsgBox("Done")
    End Sub
End Class
