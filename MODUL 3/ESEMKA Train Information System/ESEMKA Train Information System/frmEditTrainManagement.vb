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

    Sub FillData()
        Try
            OpenDB()
            With Cmd
                .Connection = Con
                .CommandText = "select * from trainmanagement where trainnumber = '" & frmTrainManagement.dgvData.SelectedRows(0).Cells(0).Value & "'"
                Dr = .ExecuteReader
            End With
            Dr.Read()
            If Dr.HasRows Then
                TextBox1.Text = Dr(0)
                TextBox2.Text = Dr(1)
                TextBox3.Text = Dr(2)
                DateTimePicker1.Text = Dr(3)
                TextBox5.Text = Dr(4)
                TextBox6.Text = Dr(5)
                TextBox7.Text = Dr(6)
            End If
            Dr.Close()
            CloseDB()
        Catch ex As Exception
            Err(ex.Message)
        End Try
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            OpenDB()
            With Cmd
                .Connection = Con
                .CommandText = "select * from trainmanagement where trainnumber = '" & TextBox1.Text & "' and trainnumber <> '" & frmTrainManagement.dgvData.SelectedRows(0).Cells(0).Value & "'"
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
                .CommandText = "update trainmanagement set TrainNumber = '" & TextBox1.Text & "', TrainType = '" & TextBox2.Text & "', Capacity = '" & TextBox3.Text & "' , Manufacture = '" & DateTimePicker1.Text & "', Speed = '" & TextBox5.Text & "', TravelDistance = '" & TextBox6.Text & "', YearsOld = '" & TextBox7.Text & "' where trainnumber = '" & frmTrainManagement.dgvData.SelectedRows(0).Cells(0).Value & "'"
                R = .ExecuteNonQuery
            End With
            If R > 0 Then
                Suc("Edit 1 data successfully")
            Else
                Att("Failed to edit data")
            End If
            frmTrainManagement.ShowData()
            Clear()
            Me.Close()
            CloseDB()
        Catch ex As Exception
            Err(ex.Message)
        End Try

    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress, TextBox6.KeyPress, TextBox5.KeyPress, TextBox3.KeyPress
        CheckInteger(e)
    End Sub

    Private Sub frmEditTrainManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillData()
    End Sub
End Class
