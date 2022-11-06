Imports System.Data.OleDb
Imports System.IO


Public Class frmPaySlip
    Public payslipID As Integer
    Dim readyfrm As Boolean = False

    Private Sub frmPaySlip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFilter.SelectedIndex = 0
        Me.pnlCenter.Left = (Me.Width - Me.pnlCenter.Width) / 2
        Me.pnlCenter.Top = (Me.Height - Me.pnlCenter.Height) / 2
        'Load_GridView()

        For Each strPrinterName As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            Me.cboPrinterList.Items.Add(strPrinterName)
        Next

        Me.cboPrinterList.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboPrinterList.SelectedIndex = 0
    End Sub

    Public Sub Load_GridView(SQL)
        Me.Cursor = Cursors.WaitCursor
        Dim count As Integer = 0

        Try
            dbcon.Open()
            cmd = New OleDbCommand(SQL, dbcon)
            Params.ForEach(Sub(x) cmd.Parameters.Add(x))
            Params.Clear()
            Reader = cmd.ExecuteReader
            GridView.Rows.Clear()

            Do While Reader.Read = True
                count = count + 1
                GridView.Rows.Add(Nothing, Nothing, Nothing, Reader(0), count,
                                    Reader(1).ToString,
                                    Reader(2).ToString,
                                    Reader(3).ToString,
                                    Reader(4).ToString)
            Loop
            dbcon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            dbcon.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub load_data()
        Load_GridView("SELECT Top " & txtFilter.Text & " `id`, `created_at`, `name`, `department`, `position` FROM (SELECT * FROM tblpayslip ORDER BY `created_at` DESC) " & _
                                   "WHERE deleted_at IS NULL ")
    End Sub


    Dim optionClick As Boolean = False
    Private Sub btnOption_Click(sender As Object, e As EventArgs) Handles btnOption.Click
        Me.Cursor = Cursors.WaitCursor
        If optionClick = True Then
            optionClick = False
            GridView.Columns(0).Visible = False
        Else
            optionClick = True
            GridView.Columns(0).Visible = True
        End If

        GridView.Focus()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridView.CellContentClick
        If e.ColumnIndex = 0 Then
            Me.Cursor = Cursors.WaitCursor

            Dim confirm As Integer
            Dim row1 As DataGridViewRow
            Try
                row1 = GridView.Rows(e.RowIndex)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try

            payslipID = row1.Cells(3).Value.ToString

            confirm = MsgBox("Delete payslip date issued """ & row1.Cells(5).Value & """?", vbQuestion + vbYesNo, "Message")
            If confirm = vbYes Then
                AddParam("@date", DateTime.Now.ToShortDateString)
                DoSQL("UPDATE tblpayslip SET deleted_at = @date WHERE id=" & payslipID & "")
                If MsgErr = Nothing Then
                    MsgBox("Deleted successfully", vbInformation, "Message")
                    load_data()
                End If
            End If
            Me.Cursor = Cursors.Default

        End If
        If e.ColumnIndex = 2 Then
            Me.Cursor = Cursors.WaitCursor

            Dim confirm As Integer
            Dim row1 As DataGridViewRow
            Try
                row1 = GridView.Rows(e.RowIndex)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try

            payslipID = row1.Cells(3).Value.ToString

            confirm = MsgBox("Print preview """ & row1.Cells(5).Value & """?", vbQuestion + vbYesNo, "Message")
            If confirm = vbYes Then

                frmPrint.ShowDialog()

            End If
            Me.Cursor = Cursors.Default

        End If

    End Sub

    Private Sub frmPaySlip_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        readyfrm = True
    End Sub

    Private Sub txtFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtFilter.SelectedIndexChanged
        If readyfrm = True Then
            load_data()
        End If
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyValue = Keys.Enter Then
            Search()
        End If
    End Sub

    Private Sub Search()
        Me.Cursor = Cursors.WaitCursor
        AddParam("@Search", "%" + txtSearch.Text + "%")
        Load_GridView("SELECT Top " & txtFilter.Text & " `id`, `created_at`, `name`, `department`, `position` FROM (SELECT * FROM tblpayslip ORDER BY `created_at` DESC) " & _
                                   "WHERE `name` like @Search AND deleted_at IS NULL OR" & _
                                   "`department` like @Search AND deleted_at IS NULL OR" & _
                                   "`position` like @Search AND deleted_at IS NULL")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtSearch_OnValueChanged(sender As Object, e As EventArgs) Handles txtSearch.OnValueChanged
        If txtSearch.Text = Nothing Then
            If readyfrm = True Then
                Me.Cursor = Cursors.WaitCursor
                load_data()
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            pnlDateRange.Enabled = True
            pnlDefault.Enabled = False
            Load_Range()
        Else
            pnlDateRange.Enabled = False
            pnlDefault.Enabled = True
        End If
    End Sub

    Private Sub Load_Range()
        If readyfrm = False Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim SDate = txtSDate.Value.Date.ToShortDateString
            Dim EDate = txtEDate.Value

            AddParam("@DTime1", SDate)
            AddParam("@DTime2", EDate)
            Load_GridView("SELECT Top " & txtFilter.Text & " `id`, `created_at`, `name`, `department`, `position` " & _
                          "FROM (SELECT * FROM tblpayslip ORDER BY `created_at` DESC) " & _
                          "WHERE `created_at` Between #" & SDate & "# AND #" & EDate & "# AND deleted_at IS NULL")

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Message")
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton2.Checked = True Then
            pnlDateRange.Enabled = True
            pnlDefault.Enabled = False
        Else
            pnlDateRange.Enabled = False
            pnlDefault.Enabled = True
            If readyfrm = True Then
                load_data()
            End If

        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub txtSDate_ValueChanged(sender As Object, e As EventArgs) Handles txtSDate.ValueChanged
        Load_Range()
    End Sub

    Private Sub txtEDate_ValueChanged(sender As Object, e As EventArgs) Handles txtEDate.ValueChanged
        Load_Range()
    End Sub
End Class