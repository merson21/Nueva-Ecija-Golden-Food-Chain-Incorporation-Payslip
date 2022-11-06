Public Class frmModal

    Private Sub Modal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If DepartmentForm = True Then
            frmDepartment.ShowDialog()
        ElseIf PositionForm = True Then
            frmPosition.ShowDialog()
        End If

        Me.Close()
        Me.Dispose()
    End Sub
End Class