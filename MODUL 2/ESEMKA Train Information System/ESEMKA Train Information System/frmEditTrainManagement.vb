Imports System.Windows.Forms

Public Class frmEditTrainManagement
    Sub Clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        DateTimePicker1.Text = Now
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox1.Focus()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            If TextBox1.Text.Trim = "" Or TextBox2.Text.Trim = "" Or TextBox3.Text.Trim = "" Or DateTimePicker1.Text.Trim = "" Or TextBox5.Text.Trim = "" Or TextBox6.Text.Trim = "" Or TextBox7.Text.Trim = "" Then
                Att("You must input all data")
                Exit Sub
            End If
        Catch ex As Exception
            Err(ex.Message)
        End Try

        Suc("Edit 1 data successfully")
        Clear()
        Me.Close()
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress, TextBox6.KeyPress, TextBox5.KeyPress, TextBox3.KeyPress
        CheckInteger(e)
    End Sub
End Class
