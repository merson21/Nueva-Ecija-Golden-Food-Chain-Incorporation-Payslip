Public Class frmloading
    Dim LD As Integer
    Private Sub frmloading_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LD += 1
        If LD = 1 Then
            ProgressBar.Value = 10

        ElseIf LD = 2 Then
            Loading.Text = "Authenticating..."
            ProgressBar.Value = ProgressBar.Value + 10

        ElseIf LD = 3 Then
            Loading.Text = "Loading Components..."
            ProgressBar.Value = ProgressBar.Value + 10

        ElseIf LD = 5 Then
            Loading.Text = "Check connections..."
            ProgressBar.Value = ProgressBar.Value + 20

        ElseIf LD = 6 Then
            Loading.Text = "Finalizing..."
            ProgressBar.Value = ProgressBar.Value + 20

        ElseIf LD = 8 Then
            Loading.Text = "Initializing Panel..."
            ProgressBar.Value = ProgressBar.Value + 10

        ElseIf LD = 10 Then
            ProgressBar.Value = ProgressBar.Value + 20
            Me.Cursor = Cursors.WaitCursor
            For i As Integer = 0 To 2 * 100
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
            Next
            Me.Cursor = Cursors.Default
            frmLogin.Show()
            Me.Close()
            Me.Dispose()

        End If
    End Sub
End Class