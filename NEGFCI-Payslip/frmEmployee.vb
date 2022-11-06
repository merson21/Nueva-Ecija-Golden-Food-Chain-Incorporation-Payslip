Imports System.Data.OleDb
Imports System.IO

Public Class frmEmployee
    Dim accountID As Integer
    Dim readyfrm As Boolean = False

    'IMAGE FILES TRANFER CODE
    Dim newFileName As String   '// File name of Image (New)
    Dim orgPicName As String    '// Orginal of Image
    Dim streamPic As Stream     '// Use Steam instead IO.
    '// Data Path 
    Public strPathData As String = MyPath(Application.StartupPath)
    '// Images Path
    Public strPathImages As String = MyPath(Application.StartupPath) & "images\"

    Function MyPath(ByVal AppPath As String) As String
        '/ MessageBox.Show(AppPath);
        AppPath = AppPath.ToLower()
        '/ Return Value
        MyPath = AppPath.Replace("\bin\debug", "\").Replace("\bin\release", "\")
        '// If not found folder then put the \ (BackSlash) at the end.
    End Function


    ' / Get Filename + Extesnsion only, not Path
    Private Function GetFileImages() As String
        '// Get the Filename + Extension only
        Dim iArr() As String
        iArr = Split(newFileName, "\")
        GetFileImages = iArr(UBound(iArr))
        '//
        '// If same original and new
        If orgPicName = newFileName Then Return GetFileImages
        '// Remove original picture
        If orgPicName IsNot Nothing Or orgPicName <> "" Then
            If System.IO.File.Exists(orgPicName) = True Then
                System.IO.File.Delete(orgPicName)
            End If
        End If

        ' Determine whether the source file is real or not.
        If System.IO.File.Exists(newFileName) = True Then
            ' Trap Error in the case source = destination
            If LCase(strPathImages + GetFileImages) <> LCase(newFileName) Then
                ' Copy the Source file (newFileName) to the Destination (DestFile). 
                ' If the same file is found, overwrite (OverWrite = True).
                System.IO.File.Copy(newFileName, strPathImages + GetFileImages, True)
            End If
        End If
    End Function

    Private Sub ShowPicture(ByVal PicName As String)
        Dim imgDB As Image
        Try
            If PicName.ToString <> "" Then

                If System.IO.File.Exists(strPathImages & PicName.ToString) Then

                    streamPic = File.OpenRead(strPathImages & PicName.ToString)
                    imgDB = Image.FromStream(streamPic)
                    PicData.Image = imgDB

                    orgPicName = strPathImages & PicName.ToString
                    newFileName = orgPicName

                End If
            Else
                'streamPic = File.OpenRead(strPathImages & "")

                'imgDB = Image.FromStream(streamPic)
                'PicData.Image = imgDB
                PicData.Image = My.Resources.Resources.NO_IMAGE_AVAILABLE_2

                orgPicName = ""
                newFileName = ""

            End If
            '//
            streamPic.Dispose()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        
        CenterPanel()
        Load_Department()
        Load_Position()
        'load_GridData()
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub CenterPanel()
        Me.pnlCenter.Left = (Me.Width - Me.pnlCenter.Width) / 2
        Me.pnlCenter.Top = (pnlBody.Height - Me.pnlCenter.Height) / 2
    End Sub

    Private Sub frmEmployee_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim x As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim y As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Width = x
        Me.Height = y - 50
        Me.Top = 0
        Me.Left = 0
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Cursor = Cursors.WaitCursor
        frmMain.load_DataMain()
        Me.Close()
        Me.Dispose()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        btnDepartmentClick()
    End Sub

    Public Sub btnDepartmentClick()
        DepartmentForm = True
        frmModal.ShowDialog()
        DepartmentForm = False
    End Sub

    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles BunifuImageButton2.Click
        PositionForm = True
        frmModal.ShowDialog()
        PositionForm = False
    End Sub

    Public Sub Load_Department()
        Me.Cursor = Cursors.WaitCursor

        Dim count As Integer = 0
        Try
            dbcon.Open()
            cmd = New OleDbCommand("SELECT name FROM tbldepartment WHERE deleted_at IS NULL ORDER BY name ASC", dbcon)
            Params.ForEach(Sub(x) cmd.Parameters.Add(x))
            Params.Clear()
            Reader = cmd.ExecuteReader
            txtDepartment.Items.Clear()

            Do While Reader.Read = True
                txtDepartment.Items.Add(Reader(0))
            Loop
            dbcon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            dbcon.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub Load_Position()
        Me.Cursor = Cursors.WaitCursor

        Dim count As Integer = 0
        Try
            dbcon.Open()
            cmd = New OleDbCommand("SELECT name FROM tblposition WHERE deleted_at IS NULL ORDER BY name ASC", dbcon)
            Params.ForEach(Sub(x) cmd.Parameters.Add(x))
            Params.Clear()
            Reader = cmd.ExecuteReader
            txtposition.Items.Clear()

            Do While Reader.Read = True
                txtposition.Items.Add(Reader(0))
            Loop
            dbcon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            dbcon.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BunifuImageButton3_Click(sender As Object, e As EventArgs) Handles btnSide.Click
        btnSideClick()
    End Sub

    Public Sub btnSideClick()
        If pnlList.Width = "57" Then
            pnlList.Width = "747"
        Else
            pnlList.Width = "57"
        End If
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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then
            saved()
        Else
            updated()
        End If
    End Sub

    Private Function validationSave() As Boolean
        If txtDepartment.Text = Nothing Or
            txtposition.Text = Nothing Or
            txtFullName.Text = Nothing Or
            txtStatus.Text = Nothing Or
            txtTag.Text = Nothing Or
            txtGender.Text = Nothing Or
            txtAddress.Text = Nothing Or
            txtContact.Text = Nothing Then

            MsgBox("Invalid empty value.", vbCritical, "Message")
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

            AddParam("@position", txtposition.Text)
            PK("SELECT * FROM tblposition WHERE `name` = @position AND deleted_at IS NULL")

            AddParam("@department", txtDepartment.Text)
            AddParam("@position", PrimaryKey)
            AddParam("@hired", txthired.Value.ToShortDateString)
            AddParam("@fullName", txtFullName.Text)
            AddParam("@tag", txtTag.Text)
            AddParam("@status", txtStatus.Text)
            AddParam("@bdate", txtBdate.Value.ToShortDateString)
            AddParam("@gender", txtGender.Text)
            AddParam("@address", txtAddress.Text)
            AddParam("@contact", txtContact.Text)
            AddParam("@others", txtOthers.Text)
            AddParam("@image", GetFileImages)
            AddParam("@date", DateTime.Now.ToShortDateString)

            DoSQL("INSERT INTO tblemployee(`department`, `position_id`, `hired`, `name`, `nameTag`, `status`, `birthDate`, `gender`, `address`, `contact`, `others`, `image`, `created_at`) VALUES " & _
                  "(@department, @position, @hired, @fullName, @tag, @status, @bdate, @gender, @address, @contact, @others, @image, @date)")

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
            Me.Cursor = Cursors.WaitCursor

            AddParam("@position", txtposition.Text)
            PK("SELECT * FROM tblposition WHERE `name` = @position AND deleted_at IS NULL")

            AddParam("@department", txtDepartment.Text)
            AddParam("@position", PrimaryKey)
            AddParam("@hired", txthired.Value.ToShortDateString)
            AddParam("@fullName", txtFullName.Text)
            AddParam("@tag", txtTag.Text)
            AddParam("@status", txtStatus.Text)
            AddParam("@bdate", txtBdate.Value.ToShortDateString)
            AddParam("@gender", txtGender.Text)
            AddParam("@address", txtAddress.Text)
            AddParam("@contact", txtContact.Text)
            AddParam("@others", txtOthers.Text)
            AddParam("@image", GetFileImages)
            AddParam("@date", DateTime.Now.ToShortDateString)

            DoSQL("UPDATE tblemployee SET `department`=@department, `position_id`=@position, `hired`=@hired, `name`=@fullName, `nameTag`=@tag, `status`=@status, " & _
                  "`birthDate`=@bdate, `gender`=@gender, `address`=@address, `contact`=@contact, `others`=@others, `image`=@image, `created_at`=@date WHERE id = " & accountID & "")

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
        txtDepartment.Text = Nothing
        txtposition.Text = Nothing
        txthired.Value = DateTime.Now.ToShortDateString
        txtFullName.Text = Nothing
        txtStatus.Text = Nothing
        txtTag.Text = Nothing
        txtBdate.Value = DateTime.Now.ToShortDateString
        txtGender.Text = Nothing
        txtAddress.Text = Nothing
        txtContact.Text = Nothing
        txtOthers.Text = Nothing

        pnlList.Width = "57"
        btnSave.Text = "Save"
        load_GridData()
    End Sub

    Public Sub load_GridData()
        Me.Cursor = Cursors.WaitCursor
        Dim filterData As String = Nothing
        If txtFilter.Text = "ALL" Then
            filterData = "%%"
        Else
            filterData = txtFilter.Text
        End If
        AddParam("@status", filterData)
        Load_GridView("SELECT a.id, a.name, a.department, b.name, a.hired, a.nameTag, a.status, a.birthDate, a.gender, a.address, a.contact, a.others, a.image, b.rate  " & _
                      "FROM tblemployee a INNER JOIN tblposition b ON b.id=a.position_id WHERE a.status LIKE @status AND a.deleted_at IS NULL ORDER BY a.name ASC")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        clear()
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
                GridView.Rows.Add(Nothing, Nothing, "Select", Reader(0), count,
                                    Reader(1).ToString,
                                    Reader(2).ToString,
                                    Reader(3).ToString,
                                    Reader(4).ToString,
                                    Reader(5).ToString,
                                    Reader(6).ToString,
                                    Reader(7).ToString,
                                    Reader(8).ToString,
                                    Reader(9).ToString,
                                    Reader(10).ToString,
                                    Reader(11).ToString,
                                    Reader(12).ToString,
                                    Reader(13).ToString)
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

            accountID = row1.Cells(3).Value.ToString

            confirm = MsgBox("Delete employee name """ & row1.Cells(5).Value & """?", vbQuestion + vbYesNo, "Message")
            If confirm = vbYes Then
                AddParam("@date", DateTime.Now.ToShortDateString)
                DoSQL("UPDATE tblemployee SET deleted_at = @date WHERE id=" & accountID & "")
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

            accountID = row1.Cells(3).Value.ToString
            txtFullName.Text = row1.Cells(5).Value.ToString
            txtDepartment.Text = row1.Cells(6).Value.ToString
            txtposition.Text = row1.Cells(7).Value.ToString
            txthired.Value = row1.Cells(8).Value.ToString
            txtTag.Text = row1.Cells(9).Value.ToString
            txtStatus.Text = row1.Cells(10).Value.ToString
            txtBdate.Value = row1.Cells(11).Value.ToString
            txtGender.Text = row1.Cells(12).Value.ToString
            txtAddress.Text = row1.Cells(13).Value.ToString
            txtContact.Text = row1.Cells(14).Value.ToString
            txtOthers.Text = row1.Cells(15).Value.ToString
            ShowPicture(row1.Cells(16).Value.ToString)

            btnSave.Text = "Update"
            btnCancel.Text = "Cancel"
            pnlList.Width = "747"



            Me.Cursor = Cursors.Default
        End If

        If e.ColumnIndex = 2 Then
            'clear()
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
                pnlCenter.Controls.Add(frmGenerate)
                .BringToFront()
                .Show()
            End With
            Dim TRate As Double
            frmGenerate.lblName.Text = row1.Cells(5).Value.ToString
            frmGenerate.lblDepartment.Text = row1.Cells(6).Value.ToString
            frmGenerate.lblPosition.Text = row1.Cells(7).Value.ToString
            TRate = row1.Cells(17).Value.ToString
            frmGenerate.lblRate.Text = TRate.ToString("#,###.00")

            Me.Cursor = Cursors.Default
        End If
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
                load_GridData()
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Search()
        Me.Cursor = Cursors.WaitCursor
        Dim filterData As String = Nothing
        If txtFilter.Text = "ALL" Then
            filterData = "%%"
        Else
            filterData = txtFilter.Text
        End If
        AddParam("@status", filterData)
        AddParam("@Search", "%" + txtSearch.Text + "%")
        Load_GridView("SELECT a.id, a.name, a.department, b.name, a.hired, a.nameTag, a.status, a.birthDate, a.gender, a.address, a.contact, a.others, a.image, b.rate FROM tblemployee a INNER JOIN tblposition b ON b.id=a.position_id " & _
                      "WHERE a.name like @search AND a.status=@status AND a.deleted_at IS NULL OR " & _
                      "a.department like @search AND a.status=@status AND a.deleted_at IS NULL OR " & _
                      "b.name like @search AND a.status=@status AND a.deleted_at IS NULL OR " & _
                      "a.hired like @search AND a.status=@status AND a.deleted_at IS NULL OR " & _
                      "a.nameTag like @search AND a.status=@status AND a.deleted_at IS NULL OR " & _
                      "a.status like @search AND a.status=@status AND a.deleted_at IS NULL OR " & _
                      "a.birthDate like @search AND a.status=@status AND a.deleted_at IS NULL OR " & _
                      "a.gender like @search AND a.status=@status AND a.deleted_at IS NULL OR " & _
                      "a.address like @search AND a.status=@status AND a.deleted_at IS NULL OR " & _
                      "a.contact like @search AND a.status=@status AND a.deleted_at IS NULL OR " & _
                      "a.others like @search AND a.status=@status AND a.deleted_at IS NULL " & _
                      "ORDER BY a.name ASC")

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmEmployee_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        readyfrm = True
        If EmployeeActive = True Then
            txtFilter.SelectedIndex = 1
        Else
            txtFilter.SelectedIndex = 0
        End If
        If PaySlipRecod = True Then
            Me.Cursor = Cursors.WaitCursor
            With frmPaySlip
                .TopLevel = False
                pnlCenter.Controls.Add(frmPaySlip)
                .BringToFront()
                .Show()
                .load_data()
            End With
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim dlgImage As OpenFileDialog = New OpenFileDialog()

        ' / Open File Dialog
        With dlgImage
            '.InitialDirectory = strPathImages
            .Title = "Select images"
            .Filter = "Images types (*.jpg;*.png;*.gif;*.bmp)|*.jpg;*.png;*.gif;*.bmp"
            .FilterIndex = 1
            .RestoreDirectory = True
        End With
        'Select OK after Browse ...
        If dlgImage.ShowDialog() = DialogResult.OK Then
            '// New Image
            newFileName = dlgImage.FileName
            PicData.Image = Image.FromFile(newFileName)
        End If
    End Sub


    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        PicData.Image = My.Resources.Resources.NO_IMAGE_AVAILABLE_2
        newFileName = ""
    End Sub

    Private Sub txtContact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContact.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "+" Or e.KeyChar = "-" Or e.KeyChar = ".")
        End If
    End Sub


    Private Sub btnEmployee_Click(sender As Object, e As EventArgs) Handles btnEmployee.Click
        'frmDeduction.ShowDialog()
        Me.Cursor = Cursors.WaitCursor
        With frmDeduction
            .TopLevel = False
            pnlCenter.Controls.Add(frmDeduction)
            .BringToFront()
            .Show()
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Cursor = Cursors.WaitCursor
        With frmIncentive
            .TopLevel = False
            pnlCenter.Controls.Add(frmIncentive)
            .BringToFront()
            .Show()
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.Cursor = Cursors.WaitCursor
        With frmGenerate
            .TopLevel = False
            pnlCenter.Controls.Add(frmGenerate)
            .BringToFront()
            .Show()
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            frmDeduction.Hide()
            frmIncentive.Hide()
            frmGenerate.Hide()
            frmPaySlip.Hide()
            Me.Cursor = Cursors.Default
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor
        With frmPaySlip
            .TopLevel = False
            pnlCenter.Controls.Add(frmPaySlip)
            .BringToFront()
            .Show()
            .load_data()
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pnlBody_Paint(sender As Object, e As PaintEventArgs) Handles pnlBody.Paint

    End Sub

    Private Sub txtFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtFilter.SelectedIndexChanged
        If readyfrm = True Then
            load_GridData()
        End If
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub
End Class