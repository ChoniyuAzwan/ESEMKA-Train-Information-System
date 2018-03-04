Imports System.Windows.Forms

Public Class frmAddTrainScheduling

    Sub FillCbTrainClass()
        ComboBox4.Items.Clear()
        With ComboBox4.Items
            .Add("Executive Class")
            .Add("Business Class")
            .Add("Economy Class")
        End With
        ComboBox4.SelectedIndex = 0
    End Sub

    Sub Clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        DateTimePicker1.Text = Now
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox4.Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.SelectedIndex = 0
        DateTimePicker2.Text = Now
        TextBox1.Focus()
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress, TextBox2.KeyPress
        CheckInteger(e)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Clear()
        Me.Close()
    End Sub

    Private Sub frmAddTrainScheduling_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillCbTrainClass()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            If TextBox1.Text.Trim = "" Or TextBox2.Text.Trim = "" Or TextBox3.Text.Trim = "" Or DateTimePicker1.Text.Trim = "" Or TextBox5.Text.Trim = "" Or TextBox6.Text.Trim = "" Or TextBox4.Text.Trim = "" Or DateTimePicker2.Text.Trim = "" Or ComboBox1.Text.Trim = "" Or ComboBox2.Text.Trim = "" Or ComboBox3.Text.Trim = "" Or ComboBox4.Text.Trim = "" Then
                Att("You must input all data")
                Exit Sub
            ElseIf Len(TextBox3.Text) <> 5 Or Len(TextBox5.Text) <> 5 Or Len(TextBox6.Text) <> 5 Then
                Att("You must input the time like example (15:15)")
                Exit Sub
            End If
        Catch ex As Exception
            Err(ex.Message)
        End Try

        Suc("Add 1 data successfully")
        Clear()
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress, TextBox5.KeyPress, TextBox3.KeyPress
        Try
            If Not IsNumeric(e.KeyChar) Then
                If Not e.KeyChar = vbBack Then
                    If Not e.KeyChar = ":" Then
                        Att("You must input the time like example (15:15)")
                        e.Handled = True
                    End If
                End If
            End If
        Catch ex As Exception
            Err(ex.Message)
        End Try
    End Sub
End Class
