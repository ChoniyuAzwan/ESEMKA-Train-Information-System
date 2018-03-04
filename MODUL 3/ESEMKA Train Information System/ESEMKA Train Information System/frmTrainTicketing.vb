Imports System.Windows.Forms

Public Class frmTrainTicketing

    Sub FillCbOrigin()
        ComboBox1.Items.Clear()
        Try
            OpenDB()
            With Cmd
                .Connection = Con
                .CommandText = "select DepartureRoute from TrainScheduling"
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

    Sub FillCbDestination()
        ComboBox2.Items.Clear()
        Try
            OpenDB()
            With Cmd
                .Connection = Con
                .CommandText = "select ArrivalRoute from TrainScheduling"
                Dr = .ExecuteReader
            End With
            Do While Dr.Read
                ComboBox2.Items.Add(Dr(0))
            Loop
            Dr.Close()
            CloseDB()
        Catch ex As Exception
            Err(ex.Message)
        End Try
        ComboBox2.SelectedIndex = 0
    End Sub

    Sub FillCbDate()
        ComboBox3.Items.Clear()
        Try
            OpenDB()
            With Cmd
                .Connection = Con
                .CommandText = "select DepartureDate from TrainScheduling"
                Dr = .ExecuteReader
            End With
            Do While Dr.Read
                ComboBox3.Items.Add(Dr(0))
            Loop
            Dr.Close()
            CloseDB()
        Catch ex As Exception
            Err(ex.Message)
        End Try
        ComboBox3.SelectedIndex = 0
    End Sub

    Sub ShowData()
        Dt.Columns.Clear()
        dgvData.DataSource = Dt
        Try
            OpenDB()
            With Cmd
                .Connection = Con
                .CommandText = "select * from TrainScheduling"
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

    Sub Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        TextBox1.Clear()
        ComboBox1.Focus()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        CheckInteger(e)
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Try
            If ComboBox1.Text.Trim = "" Or ComboBox2.Text.Trim = "" Or ComboBox3.Text.Trim = "" Then
                Att("You must input Origin, Destination and Data of Departure")
                Exit Sub
            End If
        Catch ex As Exception
            Err(ex.Message)
        End Try

        Try
            OpenDB()
            With Cmd
                .Connection = Con
                .CommandText = "select * from TrainScheduling where DepartureRoute = '" & ComboBox1.Text & "' and arrivalroute = '" & ComboBox2.Text & "' and departuredate = '" & ComboBox3.Text & "'"
            End With
            Da.SelectCommand = Cmd
            Dt.Clear()
            Da.Fill(Dt)
            dgvData.DataSource = Dt
            CloseDB()
            If dgvData.SelectedRows.Count > 0 Then
                Suc("Please select the availability of route schedule and then click Buy button")
            Else
                Att("The route schedule is empty")
            End If
        Catch ex As Exception
            Err(ex.Message)
        End Try
    End Sub

    Private Sub btnBuy_Click(sender As Object, e As EventArgs) Handles btnBuy.Click
        Try
            If TextBox1.Text.Trim = "" Then
                Att("You must input many tickets")
                Exit Sub
            End If
        Catch ex As Exception
            Err(ex.Message)
        End Try

        Repeat = TextBox1.Text
        StartRepeat()
    End Sub

    Private Sub frmTrainTicketing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillCbDate()
        FillCbDestination()
        FillCbOrigin()
        ShowData()
        FillCbTitle(cbTitle, dgvData)
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        ShowData()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim Q = MsgBox("Are you sure wanna quit from this form ?", VE + VY, T)
        If Q = vbYes Then Me.Close()
    End Sub

    Private Sub btnCanFind_Click(sender As Object, e As EventArgs) Handles btnCanFind.Click
        ShowData()
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
                            .CommandText = "select * from TrainScheduling where " & dgvData.Columns(I).Name & " like '%" & txtSearch.Text & "%'"
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

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
