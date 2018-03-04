Imports System.Data.SqlClient

Module control
    Public Con As New SqlConnection("Data Source=.\sqlexpress;Initial Catalog=EsemkaTrain;Integrated Security=True")
    Public Cmd As New SqlCommand
    Public Da As New SqlDataAdapter
    Public Dt As New DataTable
    Public Ds As New DataSet
    Public Dr As SqlDataReader

    Public VI As Integer = vbInformation
    Public VE As Integer = vbExclamation
    Public VC As Integer = vbCritical
    Public VY As Integer = vbYesNo
    Public T As String = "Esemka Train Information System"

    Public Repeat As Integer
    Public R As Integer

    Public Sub Suc(m)
        MsgBox(m, VI, T)
    End Sub

    Public Sub Att(m)
        MsgBox(m, VE, T)
    End Sub

    Public Sub Err(m)
        MsgBox(m, VC, T)
    End Sub

    Public Sub OpenDB()
        Try
            If Con.State = 0 Then Con.Open()
        Catch ex As Exception
            Err(ex.Message)
        End Try
    End Sub

    Public Sub CloseDB()
        If Con.State = 1 Then Con.Close()
    End Sub

    Public Sub CheckInteger(e As KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            If Not e.KeyChar = vbBack Then
                Att("You must input integer data on this textbox")
                e.Handled = True
            End If
        End If
    End Sub

    Public Sub FillCbTitle(cbtitle As ToolStripComboBox, dgvData As DataGridView)
        cbtitle.Items.Clear()
        Dim I As Integer
        Try
            For I = 0 To dgvData.ColumnCount - 1
                If dgvData.Columns(I).Visible Then
                    cbtitle.Items.Add(dgvData.Columns(I).HeaderText)
                End If
            Next
        Catch ex As Exception
            Err(ex.Message)
        End Try
        cbtitle.SelectedIndex = 0
    End Sub

    Public Sub StartRepeat()
        Try
            If Repeat > 0 Then
                frmAddPassanger.ShowDialog()
                frmAddPassanger.StartPosition = FormStartPosition.CenterParent
            Else
                frmTrainTicketing.Clear()
            End If
        Catch ex As Exception
            Err(ex.Message)
        End Try
    End Sub

End Module
