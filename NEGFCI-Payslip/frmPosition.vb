Imports System.Data.OleDb
Imports System.IO

Public Class frmPosition
    Dim rowID As Integer
    Dim readyfrm As Boolean = False

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridView.CellContentClick
        If e.ColumnIndex = 0 Then
            Me.Cursor = Cursors.WaitCursor
            Dim row1 As DataGridViewRow
            Try
                row1 = GridView.Rows(e.RowIndex)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try


            rowID = row1.Cells(3).Value.ToString

            Dim confirm = MsgBox("Delete position name """ & row1.Cells(5).Value.ToString & """?", vbQuestion + vbYesNo, "Message")
            If confirm = vbYes Then
                AddParam("@date", DateTime.Now.ToShortDateString)
                DoSQL("UPDATE tblposition SET `deleted_at` = @date WHERE id=" & rowID & "")
                If MsgErr = Nothing Then
                    MsgBox("Deleted successfully", vbInformation, "Message")
                    clear()
                End If
            End If
            Me.Cursor = Cursors.Default

        End If

        If e.ColumnIndex = 1 Then
            'clear()
            Me.Cursor = Cursors.WaitCursor
            Dim row1 As DataGridViewRow
            Try
                row1 = GridView.Rows(e.RowIndex)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try

            rowID = row1.Cells(3).Value.ToString
            txtposition.Text = row1.Cells(5).Value.ToString
            txtrate.Text = row1.Cells(6).Value.ToString

            btnSave.ButtonText = "Update"
            pnlAdd.Visible = True

            Me.Cursor = Cursors.Default
        End If

        If e.ColumnIndex = 2 Then

            Me.Cursor = Cursors.WaitCursor
            Dim row1 As DataGridViewRow

            Try
                row1 = GridView.Rows(e.RowIndex)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try

            rowID = row1.Cells(3).Value.ToString

            frmEmployee.txtposition.SelectedIndex = e.RowIndex
            Me.Close()
            Me.Cursor = Cursors.Default

        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If pnlAdd.Visible = True Then
            pnlAdd.Visible = False
            btnAdd.ButtonText = "Add"
            clear()
        Else
            pnlAdd.Visible = True
            btnAdd.ButtonText = "List"
        End If

    End Sub

    Private Function validationSave() As Boolean
        If txtposition.Text = Nothing Or txtrate.Text = Nothing Then
            MsgBox("Invalid empty value!", vbCritical, "Message")
            Return False
        End If

        AddParam("@name", txtposition.Text)
        QRecord("SELECT * FROM tblposition WHERE `name` = @name AND deleted_at IS NULL")
        If Recordcount > 0 Then
            MsgBox("Position already exist!", vbCritical, "Message")
            Return False
        End If

        Return True
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If btnSave.ButtonText = "Save" Then
            saved()
        Else
            Updated()
        End If

    End Sub

    Private Sub saved()
        If validationSave() = False Then
            Exit Sub
        End If

        Try
            Me.Cursor = Cursors.WaitCursor
            AddParam("@name", txtposition.Text)
            AddParam("@rate", txtrate.Text)
            AddParam("@date", DateTime.Now.ToShortDateString)

            DoSQL("INSERT INTO tblposition(`name`, `rate`, `created_at`) VALUES (@name, @rate, @date)")

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

    Private Function validationUpdate() As Boolean
        If txtposition.Text = Nothing Or txtrate.Text = Nothing Then
            MsgBox("Invalid empty value!", vbCritical, "Message")
            Return False
        End If

        AddParam("@name", txtposition.Text)
        QRecord("SELECT * FROM tblposition WHERE `name` = @name AND deleted_at IS NULL AND id <> " & rowID & "")
        If Recordcount > 0 Then
            MsgBox("Position already exist!", vbCritical, "Message")
            Return False
        End If

        Return True
    End Function
    Private Sub updated()
        If validationUpdate() = False Then
            Exit Sub
        End If

        Try
            Me.Cursor = Cursors.WaitCursor
            AddParam("@name", txtposition.Text)
            AddParam("@rate", txtrate.Text)
            AddParam("@date", DateTime.Now.ToShortDateString)

            DoSQL("UPDATE tblposition SET `name`=@name, `rate`=@rate, `updated_at`=@date WHERE id = " & rowID & "")

            If MsgErr = Nothing Then
                MsgBox("Updated successfully!", vbInformation, "Message")
                pnlAdd.Visible = False
                frmEmployee.load_GridData()
                clear()
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Message")
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub clear()
        txtSearch.Text = Nothing
        txtposition.Text = Nothing
        txtrate.Text = Nothing
        btnSave.ButtonText = "Save"
        Load_GridView("SELECT `id`, `name`, `rate` FROM tblposition WHERE deleted_at IS NULL ORDER BY name ASC")
        frmEmployee.Load_Position()
    End Sub

    Private Sub Load_GridView(SQL)
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
                GridView.Rows.Add(Nothing, Nothing, "Select", Reader(0), count,
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

    Private Sub frmPosition_Load(sender As Object, e As EventArgs) Handles Me.Load
        Load_GridView("SELECT `id`, `name`, `rate` FROM tblposition WHERE deleted_at IS NULL ORDER BY name ASC")
    End Sub

    Dim optionClick As Boolean = False
    Private Sub btnOption_Click(sender As Object, e As EventArgs) Handles btnOption.Click
        Me.Cursor = Cursors.WaitCursor
        If optionClick = True Then
            optionClick = False
            GridView.Columns(0).Visible = False
            GridView.Columns(1).Visible = False
        Else
            optionClick = True
            GridView.Columns(0).Visible = True
            GridView.Columns(1).Visible = True
        End If

        GridView.Focus()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyValue = Keys.Enter Then
            Search()
        End If
    End Sub

    Private Sub txtSearch_OnValueChanged(sender As Object, e As EventArgs) Handles txtSearch.OnValueChanged
        If txtSearch.Text = Nothing Then
            If readyfrm = True Then
                Me.Cursor = Cursors.WaitCursor
                Load_GridView("SELECT `id`, `name`, `rate` FROM tblposition WHERE deleted_at IS NULL ORDER BY name ASC")
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Search()
        Me.Cursor = Cursors.WaitCursor
        AddParam("@Search", "%" + txtSearch.Text + "%")
        Load_GridView("SELECT `id`, `name`, `rate` FROM tblposition WHERE name LIKE @Search AND deleted_at IS NULL ORDER BY name ASC")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmPosition_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        readyfrm = True
    End Sub

    Private Sub txtrate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtrate.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "+" Or e.KeyChar = "-" Or e.KeyChar = ".")
        End If
    End Sub

    Private Sub txtrate_OnValueChanged(sender As Object, e As EventArgs) Handles txtrate.OnValueChanged

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub pnlAdd_Paint(sender As Object, e As PaintEventArgs) Handles pnlAdd.Paint

    End Sub
End Class