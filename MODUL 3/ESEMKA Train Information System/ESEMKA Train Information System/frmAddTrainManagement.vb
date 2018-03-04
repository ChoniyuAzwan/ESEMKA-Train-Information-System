Imports System.Windows.Forms

Public Class frmAddTrainManagement

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
            OpenDB()
            With Cmd
                .Connection = Con
                .CommandText = "select * from trainmanagement where trainnumber = '" & TextBox1.Text & "'"
            End With
            Da.SelectCommand = Cmd
            Ds = New DataSet
            Da.Fill(Ds)
            CloseDB()
        Catch ex As Exception
            Err(ex.Message)
        End Try

        Try
            If TextBox1.Text.Trim = "" Or TextBox2.Text.Trim = "" Or TextBox3.Text.Trim = "" Or DateTimePicker1.Text.Trim = "" Or TextBox5.Text.Trim = "" Or TextBox6.Text.Trim = "" Or TextBox7.Text.Trim = "" Then
                Att("You must input all data")
                Exit Sub
            ElseIf TextBox5.Text < 10 Then
                Att("Average travel speed cannot be lower than 10 KM/hour")
                Exit Sub
   
            ElseIf TextBox3.Text < 0 Then
                Att("Train seat capacity cannot be lower than 0")
                Exit Sub
            ElseIf Ds.Tables(0).Rows.Count > 0 Then
                Att("Data alerady exist")
                Exit Sub
            End If
        Catch ex As Exception
            Err(ex.Message)
        End Try

        Try
            OpenDB()
            With Cmd
                .Connection = Con
                .CommandText = "insert into trainmanagement values ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & DateTimePicker1.Text & "', '" & TextBox5.Text & "', '" & TextBox6.Text & "', '" & TextBox7.Text & "')"
                R = .ExecuteNonQuery
            End With
            If R > 0 Then
                Suc("Add 1 data successfully")
            Else
                Att("Failed to add data")
            End If
            frmTrainManagement.ShowData()
            Clear()
            CloseDB()
        Catch ex As Exception
            Err(ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        CheckInteger(e)
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        CheckInteger(e)
    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        CheckInteger(e)
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        CheckInteger(e)
    End Sub

    Private Sub frmAddTrainManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub
End Class
