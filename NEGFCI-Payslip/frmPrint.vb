Imports System.Data.OleDb
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmPrint
    Dim ds As New myDatabase
    Dim rpt As New printPaySlip 'Report printPaySlip
    Dim rptIncentive As New printIncentive


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub ReportViewer_Load(sender As Object, e As EventArgs) Handles ReportViewer.Load

    End Sub

    Private Sub frmPrint_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.P Then
            Me.Cursor = Cursors.WaitCursor
            'here goes your code to print the report
            ReportViewer.PrintReport()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub frmPrint_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.KeyPreview = True
        load_data()
        'Load_PaySlipRecord()
    End Sub

    Private Sub load_data()
        Me.Cursor = Cursors.WaitCursor
        Try
            rpt.Load(Application.StartupPath & "\..\..\REPORT\printPaySlip.rpt")

            Dim period As TextObject
            period = rpt.ReportDefinition.ReportObjects("period")

            Dim name As TextObject
            name = rpt.ReportDefinition.ReportObjects("name")

            Dim department As TextObject
            department = rpt.ReportDefinition.ReportObjects("department")

            Dim position As TextObject
            position = rpt.ReportDefinition.ReportObjects("position")

            Dim WorkHours As TextObject
            WorkHours = rpt.ReportDefinition.ReportObjects("WorkHours")

            Dim OverTime As TextObject
            OverTime = rpt.ReportDefinition.ReportObjects("OverTime")

            Dim Gross As TextObject
            Gross = rpt.ReportDefinition.ReportObjects("Gross")

            Dim IncTotal As TextObject
            IncTotal = rpt.ReportDefinition.ReportObjects("IncTotal")

            Dim DeductTotal As TextObject
            DeductTotal = rpt.ReportDefinition.ReportObjects("DeductTotal")

            Dim NetPay As TextObject
            NetPay = rpt.ReportDefinition.ReportObjects("NetPay")

            Dim prepared As TextObject
            prepared = rpt.ReportDefinition.ReportObjects("prepared")

            dbcon.Open()
            cmd = New OleDbCommand("SELECT `Payperiod`, `name`, `department`, `position`, `workHour`, `OTHour`, `grossSalary`, `totalIncentive`, `totalDeduct`, `netpay` FROM tblpayslip WHERE id = " & frmPaySlip.payslipID & " ", dbcon)
            Params.ForEach(Sub(x) cmd.Parameters.Add(x))
            Params.Clear()
            Reader = cmd.ExecuteReader


            Do While Reader.Read = True
                period.Text = Reader(0).ToString
                name.Text = Reader(1).ToString
                department.Text = Reader(2).ToString
                position.Text = Reader(3).ToString
                WorkHours.Text = Reader(4).ToString
                OverTime.Text = Reader(5).ToString
                Gross.Text = Reader(6).ToString
                IncTotal.Text = Reader(7).ToString
                DeductTotal.Text = Reader(8).ToString
                NetPay.Text = Reader(9).ToString
                prepared.Text = frmMain.lblUser.Text
            Loop

            dbcon.Close()

            Load_PaySlipRecord()
            Try
                ReportViewer.ReportSource = rpt
                ReportViewer.RefreshReport()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'rpt.PrintOptions
            'rpt.PrintOptions.PrinterName = frmPaySlip.cboPrinterList.Text
            'rpt.PrintToPrinter(0, False, 1, 1)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Load_PaySlipRecord()
        Me.Cursor = Cursors.WaitCursor
        Try
            'rptIncentive.Load(Application.StartupPath & "\..\..\REPORT\printIncentive.rpt")

            dbcon.Open()

            '=====================REQUIRED LIST ITEM/SERVICE
            SQLDA.SelectCommand = New OleDbCommand("SELECT `ID`,`payslip_id`,`type`,`name`,`amount`,`created_at` FROM tblpayslipRecord WHERE `type`='INCENTIVE' AND `payslip_id`='" & frmPaySlip.payslipID & "'", dbcon)
            SQLDA.Fill(ds, "tblpayslipRecord")

            '=====================SUGGESTION LIST ITEM/SERVICE
            SQLDA.SelectCommand = New OleDbCommand("SELECT `ID`,`payslip_id`,`type`,`name`,`amount`,`created_at` FROM tblpayslipRecord WHERE `type`='DEDUCTION' AND `payslip_id`='" & frmPaySlip.payslipID & "'", dbcon)
            SQLDA.Fill(ds, "tblpayslipRecord1")

            rpt.SetDataSource(ds)
            'rptIncentive.SetDataSource(ds)
            'ReportViewer.ReportSource = rptIncentive
            'ReportViewer.RefreshReport()


            dbcon.Close()

        Catch ex As Exception
            dbcon.Close()
            MsgBox(ex.Message, vbCritical, "Message")
        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub frmPrint_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'rpt.PrintOptions.PrinterName = frmPaySlip.cboPrinterList.Text
        'rpt.PrintToPrinter(0, False, 1, 1)
        wait(1)
        ReportViewer.PrintReport()
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim margins As PageMargins = rpt.PrintOptions.PageMargins
        ''margins.bottomMargin = 200
        'margins.leftMargin = 1
        'margins.rightMargin = 1
        ''margins.topMargin = 100
        'rpt.PrintOptions.ApplyPageMargins(margins)
        ''rpt.PrintOptions.paper()


        'rpt.Refresh()
        'rpt.PrintOptions.PrinterName = frmPaySlip.cboPrinterList.Text
        'rpt.PrintToPrinter(1, False, 0, 0)
    End Sub
End Class