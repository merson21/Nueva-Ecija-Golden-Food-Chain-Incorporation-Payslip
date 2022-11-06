﻿Imports System.Data.OleDb
Imports System.IO

Public Class frmDepartment
    Dim rowID As Integer
    Dim readyfrm As Boolean = False

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtSearch.Text = Nothing Then
            MsgBox("Invalid empty value!", vbCritical, "Message")
            Exit Sub
        End If

        Try
            Me.Cursor = Cursors.WaitCursor
            AddParam("@name", txtSearch.Text)
            AddParam("@date", DateTime.Now.ToShortDateString)

            DoSQL("INSERT INTO tbldepartment(`name`, `created_at`) VALUES (@name, @date)")

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
        txtSearch.Text = Nothing
        Me.Cursor = Cursors.WaitCursor
        Load_GridView("SELECT id, name FROM tbldepartment WHERE deleted_at IS NULL ORDER BY name ASC")
        Me.Cursor = Cursors.Default
        frmEmployee.Load_Department()
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
                GridView.Rows.Add(Nothing, "Select", Reader(0), count,
                                    Reader(1).ToString)
            Loop
            dbcon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            dbcon.Close()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmDepartment_Load(sender As Object, e As EventArgs) Handles Me.Load
        Load_GridView("SELECT `id`, `name` FROM tbldepartment WHERE deleted_at IS NULL ORDER BY name ASC")
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
            Dim row1 As DataGridViewRow
            Try
                row1 = GridView.Rows(e.RowIndex)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try


            rowID = row1.Cells(2).Value.ToString

            Dim confirm = MsgBox("Delete department name """ & row1.Cells(4).Value.ToString & """?", vbQuestion + vbYesNo, "Message")
            If confirm = vbYes Then
                AddParam("@date", DateTime.Now.ToShortDateString)
                DoSQL("UPDATE tbldepartment SET `deleted_at` = @date WHERE id=" & rowID & "")
                If MsgErr = Nothing Then
                    MsgBox("Deleted successfully", vbInformation, "Message")
                    clear()
                End If
            End If
            Me.Cursor = Cursors.Default

        End If
        If e.ColumnIndex = 1 Then

            Me.Cursor = Cursors.WaitCursor
            Dim row1 As DataGridViewRow

            Try
                row1 = GridView.Rows(e.RowIndex)
                rowID = row1.Cells(2).Value.ToString
                frmEmployee.txtDepartment.SelectedIndex = e.RowIndex
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                Me.Close()
                Exit Sub
            End Try

            Me.Close()
            Me.Cursor = Cursors.Default

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
        Load_GridView("SELECT `id`, `name` FROM tbldepartment WHERE name LIKE @Search AND deleted_at IS NULL ORDER BY name ASC")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtSearch_OnValueChanged(sender As Object, e As EventArgs) Handles txtSearch.OnValueChanged
        If txtSearch.Text = Nothing Then
            If readyfrm = True Then
                Me.Cursor = Cursors.WaitCursor
                Load_GridView("SELECT `id`, `name` FROM tbldepartment WHERE deleted_at IS NULL ORDER BY name ASC")
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub frmDepartment_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        readyfrm = True
    End Sub
End Class