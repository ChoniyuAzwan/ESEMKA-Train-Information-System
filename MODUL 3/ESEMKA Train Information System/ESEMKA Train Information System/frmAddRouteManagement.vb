Imports System.Windows.Forms

Public Class frmAddRouteManagement

    Sub FillCbTrain()
        ComboBox1.Items.Clear()
        Try
            OpenDB()
            With Cmd
                .Connection = Con
                .CommandText = "select TrainNumber from TrainUsed"
                Dr = .ExecuteReader
            End With
            Do While Dr.Read
                ComboBox1.Items.Add(Dr(0))
            Loop
            Dr.Close()
            CloseDB()
        Catch ex As Exception
            Err(ex.Message)
        End Try
        ComboBox1.SelectedIndex = 0
    End Sub

    Sub Clear()
        TextBox1.Clear()
        ComboBox1.SelectedIndex = 0
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox1.Focus()
        TextBox5.Clear()
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs)
        CheckInteger(e)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Try
            OpenDB()
            With Cmd
                .Connection = Con
                .CommandText = "select * from RouteManagement where idroute = '" & TextBox1.Text & "'"
            End With
            Da.SelectCommand = Cmd
            Ds = New DataSet
            Da.Fill(Ds)
            CloseDB()
        Catch ex As Exception
            Err(ex.Message)
        End Try


        Try
            If TextBox1.Text.Trim = "" Or ComboBox1.Text.Trim = "" Or TextBox3.Text.Trim = "" Or TextBox4.Text.Trim = "" Or TextBox5.Text.Trim = "" Then
                Att("You must input all data")
                Exit Sub
            ElseIf TextBox3.Text = TextBox4.Text Then
                Att("Route for departure (Origin Route) and arrival (Destination Route) cannot be on the same station")
                Exit Sub
            ElseIf TextBox5.Text < 30 Then
                Att("Route distance cannot be lower than 30 KM")
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
                .CommandText = "insert into routemanagement values ('" & TextBox1.Text & "', '" & ComboBox1.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox5.Text & "')"
                R = .ExecuteNonQuery
            End With
            If R > 0 Then
                Suc("Add 1 data successfully")
            Else
                Att("Failed to add data")
            End If
            frmRouteManagement.ShowData()
            Clear()
            CloseDB()
        Catch ex As Exception
            Err(ex.Message)
        End Try
    End Sub

    Private Sub frmAddRouteManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillCbTrain()
    End Sub

    Private Sub TextBox5_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        CheckInteger(e)
    End Sub
End Class
