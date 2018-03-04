Public Class frmEditRouteManagement

    Sub Clear()
        TextBox1.Clear()
        ComboBox1.Text = ""
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox1.Focus()
        TextBox5.Clear()
    End Sub

    Private Sub frmEditRouteManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            If TextBox1.Text.Trim = "" Or ComboBox1.Text.Trim = "" Or TextBox3.Text.Trim = "" Or TextBox4.Text.Trim = "" Or TextBox5.Text.Trim = "" Then
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

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        CheckInteger(e)
    End Sub
End Class