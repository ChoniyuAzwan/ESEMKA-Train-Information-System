Imports System.Windows.Forms

Public Class frmEditTrainScheduling

    Sub FillData()
        Try
            OpenDB()
            With Cmd
                .Connection = Con
                .CommandText = "select * from TrainScheduling where IDScheduling= '" & frmTrainScheduling.dgvData.SelectedRows(0).Cells(0).Value & "'"
                Dr = .ExecuteReader
            End With
            Dr.Read()
            If Dr.HasRows Then
                TextBox1.Text = Dr(0)
                ComboBox1.Text = Dr(1)
                ComboBox2.Text = Dr(2)
                ComboBox3.Text = Dr(3)
                TextBox2.Text = Dr(4)
                TextBox3.Text = Dr(5)
                TextBox5.Text = Dr(6)
                TextBox6.Text = Dr(7)
                DateTimePicker1.Text = Dr(8)
                DateTimePicker2.Text = Dr(9)
                ComboBox4.Text = Dr(10)
                TextBox4.Text = Dr(11)
            End If
            Dr.Close()
            CloseDB()
        Catch ex As Exception
            Err(ex.Message)
        End Try
    End Sub

    Sub FillCbTrainClass()
        ComboBox4.Items.Clear()
        With ComboBox4.Items
            .Add("Executive Class")
            .Add("Business Class")
            .Add("Economy Class")
        End With
        ComboBox4.SelectedIndex = 0
    End Sub

    Sub FillCbDeparture()
        ComboBox1.Items.Clear()
        Try
            OpenDB()
            With Cmd
                .Connection = Con
                .CommandText = "select OriginRoute from RouteManagement"
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

    Sub FillCbArrival()
        ComboBox2.Items.Clear()
        Try
            OpenDB()
            With Cmd
                .Connection = Con
                .CommandText = "select DestinationRoute from RouteManagement"
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

    Sub FillCbTransit()
        ComboBox3.Items.Clear()
        Try
            OpenDB()
            With Cmd
                .Connection = Con
                .CommandText = "select DestinationRoute from RouteManagement"
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

    Sub Clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        DateTimePicker1.Text = Now
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox4.Clear()
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        ComboBox4.SelectedIndex = 0
        DateTimePicker2.Text = Now
        TextBox1.Focus()
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Clear()
        Me.Close()
    End Sub

    Private Sub frmEditTrainScheduling_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillCbTrainClass()
        FillCbArrival()
        FillCbDeparture()
        FillCbTransit()
        FillData()
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress, TextBox2.KeyPress
        CheckInteger(e)
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        Try
            If Not IsNumeric(e.KeyChar) Then
                If Not e.KeyChar = vbBack Then
                    If Not e.KeyChar = ":" Then
                        Att("You must input the time like example (15:15)")
                        e.Handled = True
                    End If
                End If
            End If
        Catch ex As Exception
            Err(ex.Message)
        End Try
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
       
        Try
            OpenDB()
            With Cmd
                .Connection = Con
                .CommandText = "select * from TrainScheduling where IDScheduling = '" & TextBox1.Text & "' and IDScheduling <> '" & frmTrainScheduling.dgvData.SelectedRows(0).Cells(0).Value & "'"
            End With
            Da.SelectCommand = Cmd
            Ds = New DataSet
            Da.Fill(Ds)
            CloseDB()
        Catch ex As Exception
            Err(ex.Message)
        End Try

        Try
            If TextBox1.Text.Trim = "" Or TextBox2.Text.Trim = "" Or TextBox3.Text.Trim = "" Or DateTimePicker1.Text.Trim = "" Or TextBox5.Text.Trim = "" Or TextBox6.Text.Trim = "" Or TextBox4.Text.Trim = "" Or DateTimePicker2.Text.Trim = "" Or ComboBox1.Text.Trim = "" Or ComboBox2.Text.Trim = "" Or ComboBox3.Text.Trim = "" Or ComboBox4.Text.Trim = "" Then
                Att("You must input all data")
                Exit Sub
            ElseIf ComboBox1.Text = ComboBox2.Text Or ComboBox1.Text = ComboBox3.Text Or ComboBox2.Text = ComboBox3.Text Then
                Att("Route for departure (Departure Route), arrival (Arrival Route) and Transit Point cannot be on the same station")
                Exit Sub
            ElseIf TextBox2.Text < 30 Then
                Att("distance cannot be lower than 30 KM")
                Exit Sub
            ElseIf Len(TextBox3.Text) <> 5 Or Len(TextBox5.Text) <> 5 Or Len(TextBox6.Text) <> 5 Then
                Att("You must input the time like example (15:15)")
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
                .CommandText = "update TrainScheduling set IDScheduling = '" & TextBox1.Text & "', DepartureRoute = '" & ComboBox1.Text & "', ArrivalRoute = '" & ComboBox2.Text & "', TransitPoint = '" & ComboBox3.Text & "', DistanceSchedule = '" & TextBox2.Text & "', TravelTime = '" & TextBox3.Text & "', DepartureTime = '" & TextBox5.Text & "', ArrivalTime = '" & TextBox6.Text & "', DepartureDate = '" & DateTimePicker1.Text & "', ArrivalDate = '" & DateTimePicker2.Text & "', TrainClass = '" & ComboBox4.Text & "', TicketPrice = '" & TextBox4.Text & "' where IDScheduling = '" & frmTrainScheduling.dgvData.SelectedRows(0).Cells(0).Value & "' "
                R = .ExecuteNonQuery
            End With
            If R > 0 Then
                Suc("Edit 1 data successfully")
            Else
                Att("Failed to edit data")
            End If
            frmTrainScheduling.ShowData()
            Clear()
            frmInformation.ShowDialog()
            CloseDB()
        Catch ex As Exception
            Err(ex.Message)
        End Try
    End Sub
End Class
