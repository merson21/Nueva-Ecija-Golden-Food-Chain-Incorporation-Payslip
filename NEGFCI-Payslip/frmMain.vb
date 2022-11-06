Imports System.Data.OleDb
Imports System.IO

Public Class frmMain
    Dim rowID As Integer

    Public Sub CenterPanel()
        Me.pnlCenter.Left = (Me.Width - Me.pnlCenter.Width) / 2
        Me.pnlCenter.Top = (pnlBody.Height - Me.pnlCenter.Height) / 2
    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CenterPanel()
        lblDTime.Text = DateTime.Now
        Load_GridView()

        load_userInfo()

    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MsgBox("Are you sure you want to log out?", vbYesNo + vbQuestion, "Message") = vbYes Then

            frmLogin.Show()
            Me.Close()
            Me.Dispose()
        End If
    End Sub

    Private Sub btnEmployee_Click(sender As Object, e As EventArgs) Handles btnEmployee.Click
        frmEmployee.ShowDialog()
    End Sub

    Private Sub BackupFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupFilesToolStripMenuItem.Click
        With frmBackup
            .TopLevel = False
            pnlCenter.Controls.Add(frmBackup)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.Click

    End Sub

    Private Sub AboutUsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutUsToolStripMenuItem.Click
        With frmabout
            .TopLevel = False
            pnlCenter.Controls.Add(frmabout)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub pnlTop_Paint(sender As Object, e As PaintEventArgs) Handles pnlTop.Paint

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDTime.Text = DateTime.Now.ToLongTimeString
    End Sub

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs)

    End Sub

    Private Sub tsTaskbar_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tsTaskbar.ItemClicked

    End Sub

    Private Sub AccountsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountsToolStripMenuItem.Click
        With frmUser
            .TopLevel = False
            pnlCenter.Controls.Add(frmUser)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If pnlNotes.Visible = True Then
            pnlNotes.Visible = False
            btnAdd.Visible = True
        Else
            pnlNotes.Visible = True
            btnAdd.Visible = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then
            Saved()
        Else
            Updated()
        End If
    End Sub

    Private Function validation() As Boolean
        If txtTitle.Text = Nothing Then
            MsgBox("Invalid empty value!", vbCritical, "Message")
            Return False
        End If

        Return True
    End Function

    Private Sub Saved()

        If validation() = False Then
            Exit Sub
        End If


        Try
            Me.Cursor = Cursors.Default
            AddParam("@user_id", userID)
            AddParam("@title", txtTitle.Text)
            AddParam("@content", txtRemarks.Text)
            AddParam("@date", DateTime.Now.ToShortDateString)

            DoSQL("INSERT INTO tblnotes (`user_id`, `title`, `content`, `created_at`) VALUES (@user_id, @title, @content, @date)")

            If MsgErr = Nothing Then
                MsgBox("Saved sucessfully!", vbInformation, "Message")
                clear()
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Message")
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Updated()
        If validation() = False Then
            Exit Sub
        End If

        Try
            Me.Cursor = Cursors.Default
            AddParam("@title", txtTitle.Text)
            AddParam("@content", txtRemarks.Text)
            AddParam("@date", DateTime.Now.ToShortDateString)

            DoSQL("UPDATE tblnotes SET `title` = @title, `content` = @content, `updated_at` = @date WHERE id = " & rowID & "")

            If MsgErr = Nothing Then
                MsgBox("Updated sucessfully!", vbInformation, "Message")
                clear()
            End If
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Message")
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub clear()
        txtTitle.Text = Nothing
        txtRemarks.Text = Nothing
        pnlNotes.Visible = False
        btnSave.Text = "Save"
        Load_GridView()
        btnDelete.Visible = False
        pnlNotes.Visible = False
        btnAdd.Visible = True
    End Sub

    Private Sub Load_GridView()

        Me.Cursor = Cursors.WaitCursor
        Dim count As Integer = 0
        Try
            dbcon.Open()
            cmd = New OleDbCommand("SELECT id, title, content FROM tblnotes WHERE user_id=" & userID & " AND deleted_at IS NULL ORDER BY id DESC", dbcon)
            Params.ForEach(Sub(x) cmd.Parameters.Add(x))
            Params.Clear()
            Reader = cmd.ExecuteReader
            GridView.Rows.Clear()

            Do While Reader.Read = True
                count = count + 1
                GridView.Rows.Add(Nothing, Reader(0), count,
                                    Reader(1).ToString,
                                    Reader(2).ToString)
            Loop
            dbcon.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            dbcon.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridView.CellContentClick
        If e.ColumnIndex = 0 Then
            Me.Cursor = Cursors.WaitCursor

            Dim row1 As DataGridViewRow = GridView.Rows(e.RowIndex)
            rowID = row1.Cells(1).Value.ToString

            txtTitle.Text = row1.Cells(3).Value
            txtRemarks.Text = row1.Cells(4).Value
            btnSave.Text = "Update"
            btnDelete.Visible = True

            pnlNotes.Visible = True
            btnAdd.Visible = False
            Me.Cursor = Cursors.Default

        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Me.Cursor = Cursors.WaitCursor
        Dim confirm = MsgBox("Delete account title """ & txtTitle.Text & """?", vbQuestion + vbYesNo, "Message")
        If confirm = vbYes Then
            AddParam("@date", DateTime.Now.ToShortDateString)
            DoSQL("UPDATE tblnotes SET `deleted_at` = @date WHERE id=" & rowID & "")
            If MsgErr = Nothing Then
                MsgBox("Deleted successfully", vbInformation, "Message")
                clear()
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub load_userInfo()
        lblUser.Text = DataFullName
        lblQ.Text = """" & Quotes & """"
        load_DataMain()
    End Sub

    Public Sub load_DataMain()
        QRecord("SELECT * FROM tblemployee where deleted_at is NULL")
        lblTotalEmp.Text = Recordcount

        QRecord("SELECT * FROM tbldepartment where deleted_at is NULL")
        lblDepart.Text = Recordcount

        QRecord("SELECT * FROM tblemployee WHERE deleted_at is NULL and status='ACTIVE'")
        lblActiveEmp.Text = Recordcount

        QRecord("SELECT * FROM tblpayslip where deleted_at is NULL")
        lblRecord.Text = Recordcount
    End Sub



    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Me.Cursor = Cursors.WaitCursor
        frmEmployee.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Me.Cursor = Cursors.WaitCursor
        frmEmployee.btnDepartmentClick()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Panel4_Click(sender As Object, e As EventArgs) Handles Panel4.Click
        Me.Cursor = Cursors.WaitCursor
        frmEmployee.btnDepartmentClick()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Panel8_Click(sender As Object, e As EventArgs) Handles Panel8.Click
        Me.Cursor = Cursors.WaitCursor
        frmEmployee.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        EmployeeActive = True
        frmEmployee.ShowDialog()
        EmployeeActive = False

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        PaySlipRecod = True
        frmEmployee.ShowDialog()
        PaySlipRecod = False
    End Sub

    Private Sub Panel9_Click(sender As Object, e As EventArgs) Handles Panel9.Click
        EmployeeActive = True
        frmEmployee.ShowDialog()
        EmployeeActive = False
    End Sub

    Private Sub Panel6_Click(sender As Object, e As EventArgs) Handles Panel6.Click
        PaySlipRecod = True
        frmEmployee.ShowDialog()
        PaySlipRecod = False
    End Sub

End Class