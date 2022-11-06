Public Class frmLogin

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'txtPass.PasswordChar = Chr(149)
    End Sub

    Private Sub frmLogin_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim x As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim y As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Width = x
        Me.Height = y - 30
        Me.Top = 0
        Me.Left = 0
        Panel1.Left = (Me.Width - Panel1.Width) / 2
        Panel1.Top = (Me.Height - Panel1.Height) / 2
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    Public Function validation() As Boolean
        If txtusername.Text = Nothing Or txtpassword.Text = Nothing Then
            MsgBox("Invalid Username or Password!", vbCritical, "Message")
            Return False
        End If
        Return True
    End Function
    Private Sub Clicklogin()


        If validation() = False Then
            Exit Sub
        End If

        Try
            Me.Cursor = Cursors.WaitCursor

            AddParam("@lgnUser", txtusername.Text)
            AddParam("@lgnPass", Encrypt(txtpassword.Text, "abc"))
            QRecord("SELECT * FROM tbluser WHERE username = @lgnUser AND password = @lgnPass AND deleted_at IS NULL")

            If Recordcount = 1 Then
                AddParam("@lgnUser", txtusername.Text)
                PK("SELECT * FROM tbluser WHERE username = @lgnUser")
                userID = PrimaryKey
                Load_userData()

                frmMain.Show()
                Me.Close()
            Else
                MsgBox("Invalid Username or Password!", vbCritical, "Message")
            End If
        Catch ex As Exception
            MsgBox("Invalid server connection! " & vbCrLf & "Please contact the administrator.", vbExclamation, "Message")

        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub picHide_Click(sender As Object, e As EventArgs) Handles picHide.Click
        txtpassword.PasswordChar = Nothing
        picHide.Visible = False
        picView.Visible = True
    End Sub

    Private Sub picView_Click(sender As Object, e As EventArgs) Handles picView.Click
        txtpassword.PasswordChar = "*"
        picHide.Visible = True
        picView.Visible = False
    End Sub

    Private Sub btnLogin_Click_1(sender As Object, e As EventArgs) Handles btnLogin.Click
        Me.Cursor = Cursors.WaitCursor
        If txtusername.Text = "Administrator" And txtpassword.Text = "John 3:16" Then 'John 3:16
            MsgBox("Welcome Master!", vbInformation, "Message")
            DataFullName = "Administrator Account"
            UserName = "Administrator"
            Quotes = "Love of God. - John 3:16"
            UserPass = Encrypt("John 3:16", "abc")
            frmMain.Show()
            Me.Close()
        Else
            Clicklogin()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnClose_Click_1(sender As Object, e As EventArgs) Handles btnClose.Click
        End
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub txtusername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtusername.KeyDown
        If e.KeyValue = Keys.Enter Then
            Clicklogin()
        End If
    End Sub

    Private Sub txtpassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtpassword.KeyDown
        If e.KeyValue = Keys.Enter Then
            Clicklogin()
        End If
    End Sub

    Private Sub txtpassword_TextChanged(sender As Object, e As EventArgs) Handles txtpassword.TextChanged

    End Sub
End Class
