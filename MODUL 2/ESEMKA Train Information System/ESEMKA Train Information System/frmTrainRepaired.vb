Imports System.Windows.Forms

Public Class frmTrainRepaired

    Sub ShowData()
        Try
            With Cmd
                .Connection = Con
                .CommandText = "select * from trainmanagement where traveldistance > 10000"
            End With
            Da.SelectCommand = Cmd
            Dt.Clear()
            Da.Fill(Dt)
            dgvData.DataSource = Dt
        Catch ex As Exception
            Err(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmTrainRepaired_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowData()
        FillCbTitle(cbTitle, dgvData)
    End Sub
End Class
