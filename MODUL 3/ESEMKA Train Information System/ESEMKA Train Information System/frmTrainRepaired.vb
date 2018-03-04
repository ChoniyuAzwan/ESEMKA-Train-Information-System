Imports System.Windows.Forms

Public Class frmTrainRepaired

    Sub ShowData()
        Dt.Columns.Clear()
        dgvData.DataSource = Dt
        Try
            With Cmd
                .Connection = Con
                .CommandText = "select * from TrainBeRepaired"
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

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Dim I As Integer
        For I = 0 To dgvData.ColumnCount - 1
            If dgvData.Columns(I).Visible Then
                If dgvData.Columns(I).Name = cbTitle.SelectedItem Then
                    Try
                        OpenDB()
                        With Cmd
                            .Connection = Con
                            .CommandText = "select * from TrainBeRepaired where " & dgvData.Columns(I).Name & " like '%" & txtSearch.Text & "%'"
                        End With
                        Da.SelectCommand = Cmd
                        Dt.Clear()
                        Da.Fill(Dt)
                        dgvData.DataSource = Dt
                        CloseDB()
                    Catch ex As Exception
                        Err(ex.Message)
                    End Try
                End If
            End If
        Next
    End Sub

    Private Sub btnCanFind_Click(sender As Object, e As EventArgs) Handles btnCanFind.Click
        ShowData()
    End Sub
End Class
