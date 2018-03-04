Imports System.Windows.Forms

Public Class frmRouteManagement

    Sub ShowData()
        Dt.Columns.Clear()
        dgvData.DataSource = Dt
        Try
            OpenDB()
            With Cmd
                .Connection = Con
                .CommandText = "select * from routemanagement"
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

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim Q = MsgBox("Are you sure wanna quit from this form ?", VE + VY, T)
        If Q = vbYes Then Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        ShowData()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvData.SelectedRows.Count = 0 Then
            Att("You must select the data or data is empty")
            Exit Sub
        End If

        Dim Q = MsgBox("Are you sure wanna delete this data ?", VY + VE, T)
        If Q = vbYes Then
            Try
                OpenDB()
                With Cmd
                    .Connection = Con
                    .CommandText = "delete routemanagement where idroute = '" & dgvData.SelectedRows(0).Cells(0).Value & "'"
                    R = .ExecuteNonQuery
                End With
                If R > 0 Then
                    Suc("Delete 1 data successfully")
                Else
                    Att("Failed to delete data")
                End If
                ShowData()
                CloseDB()
            Catch ex As Exception
                Err(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        frmAddRouteManagement.ShowDialog()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        frmEditRouteManagement.ShowDialog()
    End Sub

    Private Sub frmRouteManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                            .CommandText = "select * from routemanagement where " & dgvData.Columns(I).Name & " like '%" & txtSearch.Text & "%'"
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
