Imports System.Data.OleDb
Imports System.IO
Imports Microsoft.Office.Interop


Public Class frmBackup

    Private Sub frmBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.pnlCenter.Left = (Me.Width - Me.pnlCenter.Width) / 2
        Me.pnlCenter.Top = (Me.Height - Me.pnlCenter.Height) / 2
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub report_import_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub BunifuImageButton3_Click(sender As Object, e As EventArgs) Handles BunifuImageButton3.Click

        Dim userMsg As String
        userMsg = InputBox("Please verify your password.", "Open server configuration!", "Your password...")
        If UserPass <> Encrypt(userMsg, "abc") Then
            MsgBox("Invalid password!", vbCritical, "Message")
            Exit Sub
        End If


        Dim strPath As String = System.Windows.Forms.Application.StartupPath
        Dim sPath As String
        strPath = IO.Path.GetDirectoryName(Application.ExecutablePath)
        sPath = strPath & "\mydata.accdb"

        Dim saveDialog As New SaveFileDialog()

        saveDialog.InitialDirectory = strPath & "\..\..\export_files\"
        saveDialog.CheckPathExists = True
        saveDialog.FileName = "BACKUP " & Date.Now.ToString("yyyy-MM-dd_hh-mm-sstt") & ".accdb"
        saveDialog.Filter = "Microsoft Access Database (*.accdb)|*.accdb"
        saveDialog.RestoreDirectory = True


        If saveDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim sSource = sPath
            Dim sTarget = saveDialog.FileName

            File.Copy(sSource, sTarget, True)
            MsgBox("Successfully created backup!", vbInformation, "Message")
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Dim userMsg As String
        userMsg = InputBox("Please verify your password.", "Open server configuration!", "Your password...")
        If UserPass <> Encrypt(userMsg, "abc") Then
            MsgBox("Invalid password!", vbCritical, "Message")
            Exit Sub
        End If

        Dim confirm As Integer
        confirm = MsgBox("Are you sure you want to restore database?", vbQuestion + vbYesNo, "Message")
        If confirm = vbYes Then
            Me.Cursor = Cursors.WaitCursor

            Dim strPath As String = System.Windows.Forms.Application.StartupPath
            Dim SaveDb As String
            SaveDb = strPath & "\mydata.accdb"

            Dim openDialog As New OpenFileDialog()

            openDialog.InitialDirectory = strPath & "\..\..\export_files\"
            openDialog.CheckFileExists = True
            openDialog.CheckPathExists = True
            openDialog.Filter = "Microsoft Access Database (*.accdb)|*.accdb"
            openDialog.RestoreDirectory = True

            If openDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                confirm = MsgBox("Warning! The current data will be replace or loss?", vbExclamation + vbYesNo, "WARNING!")
                If confirm = vbYes Then
                    Dim sSource = openDialog.FileName
                    Dim sTarget = SaveDb

                    File.Copy(sSource, sTarget, True)

                    MsgBox("Successfully restored!", vbInformation, "Message")
                    MsgBox("Application restart!", vbInformation, "Message")

                    Me.Cursor = Cursors.Default
                    Application.Restart()
                End If
            End If
        End If
        Me.Cursor = Cursors.Default

    End Sub
End Class