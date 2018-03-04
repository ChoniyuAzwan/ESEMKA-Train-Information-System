Imports System.Windows.Forms

Public Class frmRouteManagement

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim Q = MsgBox("Are you sure wanna quit from this form ?", VE + VY, T)
        If Q = vbYes Then Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Suc("Refresh data successfully")
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Suc("Delete 1 data successfully")
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        frmAddRouteManagement.ShowDialog()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        frmEditRouteManagement.ShowDialog()
    End Sub
End Class
