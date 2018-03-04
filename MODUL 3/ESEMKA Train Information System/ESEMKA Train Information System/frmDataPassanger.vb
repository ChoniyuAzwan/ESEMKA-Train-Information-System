Imports System.Windows.Forms

Public Class frmDataPassanger

    Sub ShowData()
        Dt.Columns.Clear()
        dgvData.DataSource = Dt
        Try
            OpenDB()
            With Cmd
                .Connection = Con
                .CommandText = "select * from TrainTicketing"
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

    Private Sub frmDataPassanger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowData()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim Q = MsgBox("Are you sure wanna quit from this form ?", VE + VY, T)
        If Q = vbYes Then Me.Close()
    End Sub
End Class
