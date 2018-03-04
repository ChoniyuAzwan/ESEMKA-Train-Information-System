Imports System.Windows.Forms

Public Class frmPassanger

    Sub Clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox1.Focus()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmPassanger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Clear()
        Me.StartPosition = FormStartPosition.CenterParent
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If TextBox1.Text.Trim = "" Or TextBox2.Text.Trim = "" Or TextBox3.Text.Trim = "" Then
                Att("You must input all data")
                Exit Sub
            End If
        Catch ex As Exception
            Err(ex.Message)
        End Try

        Try
            Suc("Add 1 data successfully")
            Clear()
            Me.Dispose()
            Repeat = Repeat - 1
            StartRepeat()
        Catch ex As Exception
            Err(ex.Message)
        End Try

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        CheckInteger(e)
    End Sub
End Class
