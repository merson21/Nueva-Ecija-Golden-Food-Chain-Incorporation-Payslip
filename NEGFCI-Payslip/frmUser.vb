Imports System.Data.OleDb
Imports System.IO

Public Class frmUser
    Dim accountID As Integer

    Private Sub frmUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.pnlCenter.Left = (Me.Width - Me.pnlCenter.Width) / 2
        Me.pnlCenter.Top = (Me.Height - Me.pnlCenter.Height) / 2

        Load_GridView("SELECT id, name, username, quotes FROM tbluser WHERE deleted_at IS NULL")
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
        Me.Dispose()
    End Sub


    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles BunifuImageButton2.Click
        If pnlVerify.Visible = True Then
            MsgBox("Please confirm password!", vbCritical, "Message")
            Exit Sub
        End If
        If pnlList.Width = "53" Then
            pnlList.Width = "463"
        Else
            pnlList.Width = "53"
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        If pnlList.Width = "53" Then
            pnlList.Width = "463"
        Else
            pnlList.Width = "53"
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then
            saved()
        Else
            updated()
            Load_userData()
            frmMain.load_userInfo()
        End If
    End Sub

    Private Function validationSave() As Boolean
        If txtname.Text = Nothing Or txtusername.Text = Nothing Or txtpassword.Text = Nothing Then
            MsgBox("Invalid empty value.", vbCritical, "Message")
            Return False
        End If

        If txtpassword.Text <> txtCpassword.Text Then
            MsgBox("Password not match!", vbCritical, "Message")
            Return False
        End If

        Return True
    End Function

    Private Sub saved()

        If validationSave() = False Then
            Exit Sub
        End If

        Try
            Me.Cursor = Cursors.WaitCursor
            AddParam("@name", txtname.Text)
            AddParam("@username", txtusername.Text)
            AddParam("@password", Encrypt(txtpassword.Text, "abc"))
            AddParam("@quotes", txtQuotes.Text)
            AddParam("@date", DateTime.Now.ToShortDateString)

            DoSQL("INSERT INTO tbluser(`name`, `username`, `password`, `quotes`, `created_at`) VALUES (@name, @username, @password, @quotes, @date)")

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
        If txtname.Text = Nothing Or txtusername.Text = Nothing Or txtpassword.Text = Nothing Then
            MsgBox("Invalid empty value.", vbCritical, "Message")
            Return False
        End If

        If txtpassword.Text <> txtCpassword.Text Then
            MsgBox("Password not match!", vbCritical, "Message")
            Return False
        End If

        If accountID <> userID And accountID = 1 Then
            MsgBox("The primary account is invalid to update!", vbExclamation, "Message")
            Return False
        End If

        AddParam("@username", txtusername.Text)
        QRecord("SELECT * FROM tbluser WHERE username = @username AND deleted_at IS NULL AND NOT id = " & accountID & "")
        If Recordcount = 1 Then
            MsgBox("Username already exist!", vbCritical, "Message")
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
            AddParam("@name", txtname.Text)
            AddParam("@username", txtusername.Text)
            AddParam("@password", Encrypt(txtpassword.Text, "abc"))
            AddParam("@quotes", txtQuotes.Text)
            AddParam("@date", DateTime.Now.ToShortDateString)

            DoSQL("UPDATE tbluser SET `name` = @name, `username` = @username, `password` = @password, `quotes` = @quotes, `updated_at` = @date WHERE id = " & accountID & "")

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
        txtname.Text = Nothing
        txtusername.Text = Nothing
        txtpassword.Text = Nothing
        txtCpassword.Text = Nothing
        txtQuotes.Text = Nothing
        btnSave.Text = "Save"

        Load_GridView("SELECT id, name, username, quotes FROM tbluser WHERE deleted_at IS NULL")
    End Sub

    Public Sub Load_GridView(SQL)
        Me.Cursor = Cursors.WaitCursor
        Try
            dbcon.Open()
            cmd = New OleDbCommand(SQL, dbcon)
            Params.ForEach(Sub(x) cmd.Parameters.Add(x))
            Params.Clear()
            Reader = cmd.ExecuteReader
            GridView.Rows.Clear()

            Do While Reader.Read = True
                GridView.Rows.Add(Nothing, Nothing, Reader(0),
                                    Reader(1).ToString,
                                    Reader(2).ToString,
                                    "************",
                                    Reader(3).ToString)
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
            clear()

            Dim confirm As Integer
            Dim row1 As DataGridViewRow
            Try
                row1 = GridView.Rows(e.RowIndex)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try

            accountID = row1.Cells(2).Value.ToString
            If accountID = userID Then
                MsgBox("Invalid to delete!", vbCritical, "Message")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If accountID = 1 Then
                MsgBox("The primary account is invalid to delete!", vbExclamation, "Message")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            confirm = MsgBox("Delete account name """ & row1.Cells(3).Value & """?", vbQuestion + vbYesNo, "Message")
            If confirm = vbYes Then
                AddParam("@date", DateTime.Now.ToShortDateString)
                DoSQL("UPDATE tbluser SET deleted_at = @date WHERE id=" & accountID & "")
                If MsgErr = Nothing Then
                    MsgBox("Deleted successfully", vbInformation, "Message")
                    clear()
                End If
            End If
            Me.Cursor = Cursors.Default

            btnSave.Text = "Update"
            btnCancel.Text = "Cancel"
            pnlList.Width = "53"

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

            accountID = row1.Cells(2).Value.ToString
            txtname.Text = row1.Cells(3).Value.ToString
            txtusername.Text = row1.Cells(4).Value.ToString
            txtQuotes.Text = row1.Cells(6).Value.ToString

            btnSave.Text = "Update"
            btnCancel.Text = "Cancel"
            pnlList.Width = "53"

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        clear()
        btnSave.Text = "Save"
    End Sub

    Private Sub txtpassword_KeyDown(sender As Object, e As KeyEventArgs)
        'txtpassword.isPassword = True
    End Sub

    Private Sub txtpassword_OnValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtCpassword_OnValueChanged(sender As Object, e As EventArgs)
        'txtCpassword.isPassword = True
    End Sub

    Private Sub pnlAddUser_Paint(sender As Object, e As PaintEventArgs) Handles pnlAddUser.Paint

    End Sub

    Private Sub btnProceed_Click(sender As Object, e As EventArgs) Handles btnProceed.Click
        verifyClick()
    End Sub

    Private Sub txtConfirmPass_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyValue = Keys.Enter Then
            verifyClick()
        End If
    End Sub

    Private Sub verifyClick()
        If UserPass <> Encrypt(txtConfirmPass.Text, "abc") Then
            MsgBox("Invalid password!", vbCritical, "Message")
            txtConfirmPass.Focus()
        Else
            pnlVerify.Visible = False
        End If
    End Sub

    Private Sub txtConfirmPass_OnValueChanged(sender As Object, e As EventArgs)
        txtConfirmPass.Focus()
        txtConfirmPass.Focus()
        txtConfirmPass.Focus()
    End Sub

    Private Sub picHide_Click(sender As Object, e As EventArgs)
        txtConfirmPass.PasswordChar = Nothing
        picHide.Visible = False
        picView.Visible = True
    End Sub

    Private Sub picView_Click(sender As Object, e As EventArgs) Handles picView.Click
        txtConfirmPass.PasswordChar = "*"
        picHide.Visible = True
        picView.Visible = False
    End Sub

    Private Sub picHide_Click_1(sender As Object, e As EventArgs) Handles picHide.Click
        txtConfirmPass.PasswordChar = Nothing
        picHide.Visible = False
        picView.Visible = True
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles picHide2.Click
        txtpassword.PasswordChar = Nothing
        picHide2.Visible = False
        picView2.Visible = True
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles picView2.Click
        txtpassword.PasswordChar = "*"
        picHide2.Visible = True
        picView2.Visible = False
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles picHide3.Click
        txtCpassword.PasswordChar = Nothing
        picHide3.Visible = False
        picView3.Visible = True
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles picView3.Click
        txtCpassword.PasswordChar = "*"
        picHide3.Visible = True
        picView3.Visible = False
    End Sub

    Private Sub btnProceed_KeyDown(sender As Object, e As KeyEventArgs) Handles btnProceed.KeyDown
        
    End Sub

    Private Sub btnProceed_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnProceed.KeyPress

    End Sub

    Private Sub txtConfirmPass_KeyDown1(sender As Object, e As KeyEventArgs) Handles txtConfirmPass.KeyDown
        If e.KeyValue = Keys.Enter Then
            verifyClick()
        End If
    End Sub

    Private Sub txtConfirmPass_TextChanged(sender As Object, e As EventArgs) Handles txtConfirmPass.TextChanged
        
    End Sub
End Class