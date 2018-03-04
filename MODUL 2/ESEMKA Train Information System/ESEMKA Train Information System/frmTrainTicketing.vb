Imports System.Windows.Forms

Public Class frmTrainTicketing

    Sub Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        TextBox1.Clear()
        ComboBox1.Focus()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        CheckInteger(e)
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Suc("Please select the availability of route schedule and then click 'Buy' button")
    End Sub

    Private Sub btnBuy_Click(sender As Object, e As EventArgs) Handles btnBuy.Click
        Try
            If ComboBox1.Text.Trim = "" Or ComboBox2.Text.Trim = "" Or ComboBox3.Text.Trim = "" Or TextBox1.Text.Trim = "" Then
                Att("You must input all data")
                Exit Sub
            End If
        Catch ex As Exception
            Err(ex.Message)
        End Try

        Repeat = TextBox1.Text
        StartRepeat()
    End Sub

    Private Sub frmTrainTicketing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Clear()
    End Sub
End Class
