Imports System.Windows.Forms

Public Class frmTrainManagement

    Sub ShowData()
        Dt.Clear()
        dgvData.DataSource = Dt
        Try
            OpenDB()
            With Cmd
                .Connection = Con
                .CommandText = "select * from trainmanagement"
            End With
            Da.SelectCommand = Cmd
            Dt.Clear()
            Da.Fill(Dt)
            dgvData.DataSource = Dt
            CloseDB()
        Catch ex As Exception
            Err(ex.Message)
        End Try
    End Sub


    Private Sub frmTrainManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowData()
        FillCbTitle(cbTitle, dgvData)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim Q = MsgBox("Are you sure wanna quit from this form ?", VE + VY, T)
        If Q = vbYes Then Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'If dgvData.SelectedRows.Count = 0 Then
        '    Att("You must select the data or data is empty")
        '    Exit Sub
        'End If

        Try
            Suc("Delete 1 data successfully")
        Catch ex As Exception
            Err(ex.Message)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        frmEditTrainManagement.ShowDialog()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        frmAddTrainManagement.ShowDialog()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Suc("Refresh data successfully")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmTrainRepaired.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmTrainNotBeUsed.ShowDialog()
    End Sub
End Class
