Public Class frmGenerate
    Public positionRate As Double

    Private Sub frmGenerate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.pnlCenter.Left = (Me.Width - Me.pnlCenter.Width) / 2
        Me.pnlCenter.Top = (Me.Height - Me.pnlCenter.Height) / 2
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCompute.Click

        If txtOT.Text = Nothing Or txtOTrate.Text = Nothing Or txtPayPeriod.Text = Nothing Or txtworkHR.Text = Nothing Then
            MsgBox("Invalid empty value!", vbCritical, "Message")
            Exit Sub
        End If

        Dim workHR As Double = 0
        Dim workRate As Double = 0
        Dim workTotal As Double
        Dim OTHR As Double = 0
        Dim OTRate As Double = 0
        Dim OTTOtal As Double
        Dim grandTotal As Double
        Dim NetTotal As Double

        If txtworkHR.Text <> Nothing Then
            workHR = txtworkHR.Text
        End If

        If lblRate.Text <> "--------" Then
            workRate = lblRate.Text
        End If

        If txtOT.Text <> Nothing Then
            OTHR = txtOT.Text
        End If

        If txtOTrate.Text <> Nothing Then
            OTRate = txtOTrate.Text
        End If

        '.ToString("#,##0.00")
        workTotal = Double.Parse(workHR) * Double.Parse(workRate)
        OTTOtal = Double.Parse(OTHR) * Double.Parse(OTRate)
        grandTotal = workTotal + OTTOtal

        lblSalary.Text = grandTotal.ToString("#,##0.00")

        Dim deductSum As Double
        For x = 0 To GridViewDeduct.Rows.Count - 1
            deductSum = deductSum + GridViewDeduct.Rows(x).Cells(3).Value
        Next

        lbldeductTotal.Text = deductSum.ToString("#,##0.00")

        Dim IncentSum As Double
        For x = 0 To GridViewIncent.Rows.Count - 1
            IncentSum = IncentSum + GridViewIncent.Rows(x).Cells(3).Value
        Next

        lblIncentTotal.Text = IncentSum.ToString("#,##0.00")

        NetTotal = (IncentSum + grandTotal) - deductSum
        lblNetPay.Text = NetTotal.ToString("#,##0.00")

    End Sub

    Private Sub GridViewDeduct_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridViewDeduct.CellContentClick
        If e.ColumnIndex = 0 Then
            Me.Cursor = Cursors.WaitCursor
            Dim row1 As DataGridViewRow
            Try
                row1 = GridViewDeduct.Rows(e.RowIndex)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try
            Dim confirm = MsgBox("Delete deduction name """ & row1.Cells(2).Value.ToString & """?", vbQuestion + vbYesNo, "Message")
            If confirm = vbYes Then
                For Each row As DataGridViewRow In GridViewDeduct.SelectedRows
                    GridViewDeduct.Rows.Remove(row)
                Next

                For x = 0 To GridViewDeduct.Rows.Count - 1
                    GridViewDeduct.Rows(x).Cells(1).Value = x + 1
                Next
            End If

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GridViewIncent_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridViewIncent.CellContentClick
        If e.ColumnIndex = 0 Then
            Me.Cursor = Cursors.WaitCursor
            Dim row1 As DataGridViewRow
            Try
                row1 = GridViewIncent.Rows(e.RowIndex)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try
            Dim confirm = MsgBox("Delete deduction name """ & row1.Cells(2).Value.ToString & """?", vbQuestion + vbYesNo, "Message")
            If confirm = vbYes Then
                For Each row As DataGridViewRow In GridViewIncent.SelectedRows
                    GridViewIncent.Rows.Remove(row)
                Next
            End If

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub pnlCenter_Paint(sender As Object, e As PaintEventArgs) Handles pnlCenter.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSaveOnly.Click

        If saveValidation() = True Then
            saved()
        End If

    End Sub

    Private Function saveValidation() As Boolean
        If txtOT.Text = Nothing Or txtOTrate.Text = Nothing Or txtPayPeriod.Text = Nothing Or txtworkHR.Text = Nothing Then
            MsgBox("Invalid empty value!", vbCritical, "Message")
            Return False
        End If

        If lblName.Text = "-------------------" Then
            MsgBox("Select employee!", vbCritical, "Message")
            Return False

        ElseIf lblSalary.Text = "---------------" Then
            MsgBox("Select compute!", vbCritical, "Message")
            Return False
        End If

        Return True

    End Function
    Private Sub saved()
        Try
            Me.Cursor = Cursors.WaitCursor


            AddParam("@name", lblName.Text)
            AddParam("@department", lblDepartment.Text)
            AddParam("@workHour", txtworkHR.Text)
            AddParam("@workRate", lblRate.Text)
            AddParam("@position", lblPosition.Text)
            AddParam("@OTHour", txtOT.Text)
            AddParam("@OTRate", txtOTrate.Text)
            AddParam("@Payperiod", txtPayPeriod.Text)
            AddParam("@grossSalary", "₱" & lblSalary.Text)
            AddParam("@totalDeduct", "₱" & lbldeductTotal.Text)
            AddParam("@totalIncentive", "₱" & lblIncentTotal.Text)
            AddParam("@netpay", "₱" & lblNetPay.Text)

            DoSQL("INSERT INTO tblpayslip(`name`, `department`, `workHour`, `workRate`, `position`, `OTHour`, `OTRate`, `Payperiod`, `grossSalary`, `totalDeduct`, `totalIncentive`, `netpay`) VALUES " & _
                  "(@name, @department, @workHour, @workRate, @position, @OTHour, @OTRate, @Payperiod, @grossSalary, @totalDeduct, @totalIncentive, @netpay)")

            'get last record ID
            PK("select max(id) from tblpayslip")
            frmPaySlip.payslipID = PrimaryKey

            If GridViewDeduct.Rows.Count > 0 Then
                For x = 0 To GridViewDeduct.Rows.Count - 1
                    Dim actDate As DateTime = DateTime.Now

                    AddParam("@payslip", PrimaryKey)
                    AddParam("@name", GridViewDeduct.Rows(x).Cells(2).Value)
                    AddParam("@amount", GridViewDeduct.Rows(x).Cells(3).Value)

                    DoSQL("INSERT INTO tblpayslipRecord(`payslip_id`, `type`, `name`, `amount`) VALUES (@payslip, 'DEDUCTION', @name, @amount)")

                Next
            End If

            If GridViewIncent.Rows.Count > 0 Then
                For x = 0 To GridViewIncent.Rows.Count - 1

                    AddParam("@payslip", PrimaryKey)
                    AddParam("@name", GridViewIncent.Rows(x).Cells(2).Value)
                    AddParam("@amount", GridViewIncent.Rows(x).Cells(3).Value)

                    DoSQL("INSERT INTO tblpayslipRecord(`payslip_id`, `type`, `name`, `amount`) values (@payslip, 'INCENTIVE', @name, @amount)")

                Next
            End If

            If MsgErr = Nothing Then
                MsgBox("Saved successfully!", vbInformation, "Message")
                clear()
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Message")
            Me.Cursor = Cursors.Default
        End Try
        
    End Sub



    Private Sub clear()
        lblName.Text = "-------------------"
        lblDepartment.Text = "-------------------"
        txtworkHR.Text = Nothing
        lblRate.Text = "--------"
        lblPosition.Text = "-------------------"
        txtOT.Text = Nothing
        txtOTrate.Text = Nothing
        txtPayPeriod.Text = Nothing
        lblSalary.Text = "---------------"
        lbldeductTotal.Text = "---------------"
        lblIncentTotal.Text = "---------------"
        lblNetPay.Text = "----------------"

        GridViewDeduct.Rows.Clear()
        GridViewIncent.Rows.Clear()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Private Sub btnSavePrint_Click(sender As Object, e As EventArgs) Handles btnSavePrint.Click
        If saveValidation() = True Then
            saved()
            frmPrint.ShowDialog()
        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            frmDeduction.Hide()
            frmIncentive.Hide()
            Me.Hide()
            frmPaySlip.Hide()
            Me.Cursor = Cursors.Default
        Catch ex As Exception

        End Try
    End Sub
End Class