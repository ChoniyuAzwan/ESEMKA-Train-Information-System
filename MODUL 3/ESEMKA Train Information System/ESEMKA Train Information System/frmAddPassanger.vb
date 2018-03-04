Imports System.Windows.Forms

Public Class frmAddPassanger

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
            OpenDB()
            With Cmd
                .Connection = Con
                .CommandText = "insert into TrainTicketing (IDScheduling, FullName, IdentityNumber, PhoneNumber) values ('" & frmTrainTicketing.dgvData.SelectedRows(0).Cells(0).Value & "', '" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "') "
                R = .ExecuteNonQuery
            End With
            If R > 0 Then
                Suc("Add 1 data successfully")
                Clear()
                Me.Dispose()
                Repeat = Repeat - 1
                StartRepeat()
            Else
                Att("Failed to add data")
            End If
            CloseDB()
        Catch ex As Exception
            Err(ex.Message)
        End Try

        'Try
        '    Suc("Add 1 data successfully")
        '    Clear()
        '    Me.Dispose()
        '    Repeat = Repeat - 1
        '    StartRepeat()
        'Catch ex As Exception
        '    Err(ex.Message)
        'End Try

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        CheckInteger(e)
    End Sub
End Class
