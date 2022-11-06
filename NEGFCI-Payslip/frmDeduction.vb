Imports System.Data.OleDb
Imports System.IO

Public Class frmDeduction
    Dim rowID As Integer
    Dim rowID2 As Integer
    Dim readyfrm As Boolean = False
    Dim groupID As Integer

    Private Sub frmDeduction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.pnlCenter.Left = (Me.Width - Me.pnlCenter.Width) / 2
        Me.pnlCenter.Top = (Me.Height - Me.pnlCenter.Height) / 2
        load_data1()
        load_data2()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btndeduc.Click
        If pnldeduc.Visible = True Then
            pnldeduc.Visible = False
            btndeduc.Text = "Add"
            clear()

        Else
            pnldeduc.Visible = True
            btndeduc.Text = "List"
        End If
    End Sub

    Private Sub pnldeduc_Paint(sender As Object, e As PaintEventArgs) Handles pnldeduc.Paint

    End Sub

    Private Sub btnSave_Click_1(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.ButtonText = "Save" Then
            saved()
        Else
            updated()
        End If
    End Sub

    Private Function validationSave() As Boolean
        If txtDeduc.Text = Nothing Or txtAmount.Text = Nothing Then
            MsgBox("Invalid empty value!", vbCritical, "Message")
            Return False
        End If

        'AddParam("@name", txtDeduc.Text)
        'QRecord("SELECT * FROM tblposition WHERE `name` = @name AND deleted_at IS NULL")
        'If Recordcount > 0 Then
        '    MsgBox("Position already exist!", vbCritical, "Message")
        '    Return False
        'End If

        Return True
    End Function

    Private Sub saved()
        If validationSave() = False Then
            Exit Sub
        End If

        Try
            Me.Cursor = Cursors.WaitCursor
            AddParam("@name", txtDeduc.Text)
            AddParam("@amount", txtAmount.Text)
            AddParam("@date", DateTime.Now.ToShortDateString)


            DoSQL("INSERT INTO tbldeduction(`name`, `amount`, `created_at`) VALUES (@name, @amount, @date)")
            PK("SELECT max(id) as maxid FROM tbldeduction")
            MsgBox(PrimaryKey)
            For x = 0 To GridView2.Rows.Count - 1
                AddParam("@groupID", GridView2.Rows(x).Cells(3).Value)
                AddParam("@deduct_id", PrimaryKey)
                AddParam("@mark", "False")

                DoSQL("INSERT INTO tbldeductGroup(`deduct_id_name`, `deduct_id`, `mark`) VALUES (@groupID, @deduct_id, @mark)")

            Next

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

    Private Sub updated()
        If validationSave() = False Then
            Exit Sub
        End If

        Try
            AddParam("@name", txtDeduc.Text)
            AddParam("@amount", txtAmount.Text)
            AddParam("@date", DateTime.Now.ToShortDateString)


            DoSQL("UPDATE tbldeduction SET `name`=@name, `amount`=@amount, `updated_at`=@date WHERE id = " & rowID & "")

            If MsgErr = Nothing Then
                MsgBox("Updated successfully!", vbInformation, "Message")
                clear()
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Message")
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub clear()
        Me.Cursor = Cursors.WaitCursor
        txtDeduc.Text = Nothing
        txtAmount.Text = Nothing
        btnSave.ButtonText = "Save"
        btndeduc.Text = "Add"
        pnldeduc.Visible = False
        Load_GridView("SELECT `id`, `name`, `amount` FROM tbldeduction WHERE deleted_at IS NULL ORDER BY name ASC")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub load_data1()
        Me.Cursor = Cursors.WaitCursor
        Load_GridView("SELECT `id`, `name`, `amount` FROM tbldeduction WHERE deleted_at IS NULL ORDER BY name ASC")
        Me.Cursor = Cursors.Default
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
                GridView.Rows.Add(Nothing, Nothing, Reader(0), count,
                                    Reader(1).ToString,
                                    Reader(2).ToString, "Select")
            Loop
            dbcon.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            dbcon.Close()
        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Load_GridView3()
        Me.Cursor = Cursors.WaitCursor
        Dim count As Integer = 0
        Try
            dbcon.Open()
            cmd = New OleDbCommand("SELECT `id`, `name`, `amount` FROM tbldeduction WHERE deleted_at IS NULL ORDER BY name ASC", dbcon)
            Params.ForEach(Sub(x) cmd.Parameters.Add(x))
            Params.Clear()
            Reader = cmd.ExecuteReader
            GridView3.Rows.Clear()

            Do While Reader.Read = True
                count = count + 1
                GridView3.Rows.Add(Nothing, Nothing, Nothing, Reader(0), count,
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

    Private Sub GridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridView.CellContentClick
        If e.ColumnIndex = 0 Then
            Me.Cursor = Cursors.WaitCursor
            Dim row1 As DataGridViewRow
            Try
                row1 = GridView.Rows(e.RowIndex)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try

            rowID = row1.Cells(2).Value.ToString

            Dim confirm = MsgBox("Delete deduction name """ & row1.Cells(4).Value.ToString & """?", vbQuestion + vbYesNo, "Message")
            If confirm = vbYes Then
                AddParam("@date", DateTime.Now.ToShortDateString)
                DoSQL("UPDATE tbldeduction SET `deleted_at` = @date WHERE id=" & rowID & "")
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

            rowID = row1.Cells(2).Value.ToString
            txtDeduc.Text = row1.Cells(4).Value.ToString
            txtAmount.Text = row1.Cells(5).Value.ToString

            btnSave.ButtonText = "Update"
            pnldeduc.Visible = True
            btndeduc.Text = "List"

            Me.Cursor = Cursors.Default
        End If

        If e.ColumnIndex = 6 Then
            Me.Cursor = Cursors.WaitCursor
            Dim row1 As DataGridViewRow
            Try
                row1 = GridView.Rows(e.RowIndex)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try

            With frmGenerate
                .TopLevel = False
                frmEmployee.pnlCenter.Controls.Add(frmGenerate)
                .BringToFront()
                .Show()
            End With

            Dim count As Integer = frmGenerate.GridViewDeduct.Rows.Count + 1

            frmGenerate.GridViewDeduct.Rows.Add(Nothing, count, row1.Cells(4).Value.ToString, row1.Cells(5).Value.ToString)

            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyValue = Keys.Enter Then
            Search()
        End If
    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        
    End Sub

    Private Sub txtSearch_OnValueChanged(sender As Object, e As EventArgs) Handles txtSearch.OnValueChanged
        If txtSearch.Text = Nothing Then
            If readyfrm = True Then
                load_data1()
            End If
        End If
    End Sub

    Private Sub Search()
        Me.Cursor = Cursors.WaitCursor
        AddParam("@Search", "%" + txtSearch.Text + "%")
        Load_GridView("SELECT `id`, `name`, `amount` FROM tbldeduction WHERE name LIKE @Search AND deleted_at IS NULL ORDER BY name ASC")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmDeduction_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        readyfrm = True
    End Sub

    Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmount.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "+" Or e.KeyChar = "-" Or e.KeyChar = ".")
        End If
    End Sub

    Private Sub btnSave2_Click(sender As Object, e As EventArgs) Handles btnSave2.Click
        If btnSave2.ButtonText = "Save" Then
            saved2()
        Else
            updated2()
        End If
    End Sub

    Private Function validationSave2() As Boolean
        If txtDeduc2.Text = Nothing Then
            MsgBox("Invalid empty value!", vbCritical, "Message")
            Return False
        End If
        Return True
    End Function

    Private Sub saved2()
        If validationSave2() = False Then
            Exit Sub
        End If
        Try
            Me.Cursor = Cursors.WaitCursor
            AddParam("@name", txtDeduc2.Text)
            AddParam("@date", DateTime.Now.ToShortDateString)

            DoSQL("INSERT INTO tbldeductGroupName(`name`, `created_at`) VALUES (@name,@date)")
            PK("SELECT max(id) as maxid FROM tbldeductGroupName")

            For x = 0 To GridView.Rows.Count - 1
                AddParam("@groupID", PrimaryKey)
                AddParam("@deduct_id", GridView.Rows(x).Cells(2).Value)
                AddParam("@mark", "False")
                DoSQL("INSERT INTO tbldeductGroup(`deduct_id_name`, `deduct_id`, `mark`) VALUES (@groupID, @deduct_id, @mark)")
            Next

            If MsgErr = Nothing Then
                MsgBox("Saved successfully!", vbInformation, "Message")
                clear2()
            End If


            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Message")
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub updated2()

        If validationSave2() = False Then
            Exit Sub
        End If
        Try
            AddParam("@name", txtDeduc2.Text)
            AddParam("@date", DateTime.Now.ToShortDateString)

            DoSQL("UPDATE tbldeductGroupName SET `name`=@name, `updated_at`=@date WHERE id = " & rowID2 & "")
            If MsgErr = Nothing Then
                MsgBox("Updated successfully!", vbInformation, "Message")
                clear2()
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Message")
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub clear2()
        Me.Cursor = Cursors.WaitCursor
        txtDeduc2.Text = Nothing
        pnldeduc2.Visible = False
        load_data2()
        btnSave2.ButtonText = "Save"
        btndeduc2.Text = "Add"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Load_GridView2(SQL)
        Me.Cursor = Cursors.WaitCursor

        Dim count As Integer = 0
        Try
            dbcon.Open()
            cmd = New OleDbCommand(SQL, dbcon)
            Params.ForEach(Sub(x) cmd.Parameters.Add(x))
            Params.Clear()
            Reader = cmd.ExecuteReader
            GridView2.Rows.Clear()

            Do While Reader.Read = True
                count = count + 1
                GridView2.Rows.Add(Nothing, Nothing, Reader(0), count,
                                    Reader(1).ToString, "View List", "Select")
            Loop
            dbcon.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            dbcon.Close()
        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub load_data2()
        Me.Cursor = Cursors.WaitCursor
        Load_GridView2("SELECT `id`, `name` FROM tbldeductGroupName WHERE deleted_at IS NULL ORDER BY name ASC")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btndeduc2.Click

        If pnldeduc2.Visible = True Then
            pnldeduc2.Visible = False
            btndeduc2.Text = "Add"
            clear2()

        Else
            pnldeduc2.Visible = True
            btndeduc2.Text = "List"
        End If

    End Sub

    Dim optionClick2 As Boolean = False
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Cursor = Cursors.WaitCursor
        If optionClick2 = True Then
            optionClick2 = False
            GridView2.Columns(0).Visible = False
            GridView2.Columns(1).Visible = False
        Else
            optionClick2 = True
            GridView2.Columns(0).Visible = True
            GridView2.Columns(1).Visible = True
        End If

        GridView2.Focus()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridView2.CellContentClick
        If e.ColumnIndex = 0 Then
            Me.Cursor = Cursors.WaitCursor
            Dim row1 As DataGridViewRow
            Try
                row1 = GridView2.Rows(e.RowIndex)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try

            rowID2 = row1.Cells(2).Value.ToString
            Dim confirm = MsgBox("Delete group name """ & row1.Cells(4).Value.ToString & """?", vbQuestion + vbYesNo, "Message")
            If confirm = vbYes Then
                AddParam("@date", DateTime.Now.ToShortDateString)
                DoSQL("UPDATE tbldeductGroupName SET `deleted_at` = @date WHERE id=" & rowID2 & "")
                If MsgErr = Nothing Then
                    MsgBox("Deleted successfully", vbInformation, "Message")
                    clear2()
                End If
            End If
            Me.Cursor = Cursors.Default
        End If

        If e.ColumnIndex = 1 Then
            'clear()
            Me.Cursor = Cursors.WaitCursor
            Dim row1 As DataGridViewRow
            Try
                row1 = GridView2.Rows(e.RowIndex)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try

            rowID2 = row1.Cells(2).Value.ToString
            txtDeduc2.Text = row1.Cells(4).Value.ToString

            btnSave2.ButtonText = "Update"
            pnldeduc2.Visible = True
            btndeduc2.Text = "List"

            Me.Cursor = Cursors.Default
        End If

        If e.ColumnIndex = 5 Then
            Me.Cursor = Cursors.WaitCursor
            Dim row1 As DataGridViewRow
            Try
                row1 = GridView2.Rows(e.RowIndex)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try

            groupID = row1.Cells(2).Value.ToString
            pnlViewList.Visible = True
            Load_GridView3()
            reload_Markdata()
        End If

        If e.ColumnIndex = 6 Then
            Me.Cursor = Cursors.WaitCursor
            Dim row1 As DataGridViewRow
            Try
                row1 = GridView2.Rows(e.RowIndex)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try

            With frmGenerate
                .TopLevel = False
                frmEmployee.pnlCenter.Controls.Add(frmGenerate)
                .BringToFront()
                .Show()
            End With

            groupID = row1.Cells(2).Value.ToString

            Dim count As Integer = frmGenerate.GridViewDeduct.Rows.Count

            Try
                dbcon.Open()
                cmd = New OleDbCommand("SELECT name, amount FROM tbldeduction WHERE id IN (SELECT deduct_id FROM tbldeductGroup WHERE deduct_id_name=" & groupID & " AND mark='True')", dbcon)
                Params.ForEach(Sub(x) cmd.Parameters.Add(x))
                Params.Clear()
                Reader = cmd.ExecuteReader

                Do While Reader.Read = True
                    count = count + 1
                    'MsgBox(Reader(1))
                    frmGenerate.GridViewDeduct.Rows.Add(Nothing, count, Reader(0), Reader(1))
                Loop
                dbcon.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
                dbcon.Close()
            End Try

            'frmGenerate.GridViewIncent.Rows.Add(Nothing, count, row1.Cells(4).Value.ToString, row1.Cells(5).Value.ToString)

            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub txtSearch2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch2.KeyDown
        If e.KeyValue = Keys.Enter Then
            Search2()
        End If
    End Sub

    Private Sub txtSearch2_OnValueChanged(sender As Object, e As EventArgs) Handles txtSearch2.OnValueChanged
        If txtSearch2.Text = Nothing Then
            If readyfrm = True Then
                load_data2()
            End If
        End If
    End Sub

    Private Sub Search2()
        Me.Cursor = Cursors.WaitCursor
        AddParam("@Search", "%" + txtSearch2.Text + "%")
        Load_GridView2("SELECT `id`, `name` FROM tbldeductGroupName WHERE name LIKE @Search AND deleted_at IS NULL ORDER BY name ASC")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Search2()
    End Sub

    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs) Handles BunifuThinButton22.Click
        pnlViewList.Visible = False
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click

        Dim deduct_id As Integer
        Dim Mark As String
        Try
            Me.Cursor = Cursors.WaitCursor
            For x = 0 To GridView3.RowCount - 1

                If GridView3.Rows(x).Cells(2).Value = "True" Then
                    Mark = "True"
                Else
                    Mark = "False"
                End If

                deduct_id = GridView3.Rows(x).Cells(3).Value
                AddParam("@mark", Mark)
                DoSQL("UPDATE tbldeductGroup SET `mark`=@mark WHERE deduct_id_name = " & groupID & " AND deduct_id = " & deduct_id & "")

                'QRecord("SELECT * FROM tbldeductGroup WHERE deduct_id_name = " & groupID & " AND deduct_id = " & deduct_id & "")
                'If Recordcount = 1 Then
                '    AddParam("@mark", Mark)
                '    DoSQL("UPDATE tbldeductGroup SET `mark`=@mark WHERE deduct_id_name = " & groupID & " AND deduct_id = " & deduct_id & "")
                'Else
                '    AddParam("@groupID", groupID)
                '    AddParam("@deduct_id", deduct_id)
                '    AddParam("@mark", Mark)
                '    DoSQL("INSERT INTO tbldeductGroup(`deduct_id_name`, `deduct_id`, `mark`) VALUES (@groupID, @deduct_id, @mark)")
                'End If
                'MsgBox(Mark & " :: " & GridView3.Rows(x).Cells(5).Value)
            Next

            If MsgErr = Nothing Then
                MsgBox("Saved successfully!", vbInformation, "Message")
            End If
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Message")
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub reload_Markdata()

        Dim deduct_id As Integer
        Try
            Me.Cursor = Cursors.WaitCursor

           

                Me.Cursor = Cursors.WaitCursor
                Try
                    dbcon.Open()
                    cmd = New OleDbCommand("SELECT `deduct_id`,`mark` FROM tbldeductGroup WHERE deduct_id_name = " & groupID & "", dbcon)
                    Params.ForEach(Sub(x) cmd.Parameters.Add(x))
                    Params.Clear()
                    Reader = cmd.ExecuteReader
                    Do While Reader.Read = True

                    For y = 0 To GridView3.RowCount - 1
                        deduct_id = GridView3.Rows(y).Cells(3).Value

                        If Reader(0) = deduct_id Then

                            If Reader(1) = "True" Then
                                GridView3.Rows(y).Cells(2).Value = "True"
                            Else
                                GridView3.Rows(y).Cells(2).Value = "False"
                            End If

                        End If

                    Next

                Loop
                    dbcon.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    dbcon.Close()
                End Try
                Me.Cursor = Cursors.Default


            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Message")
            Me.Cursor = Cursors.Default
        End Try

    End Sub


    Private Sub GridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridView3.CellContentClick
        If e.ColumnIndex = 2 Then
            btndeduc2.Focus()
        End If
    End Sub

    Private Sub txtAmount_OnValueChanged(sender As Object, e As EventArgs) Handles txtAmount.OnValueChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
End Class