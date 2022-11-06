Public Class frmabout

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        System.Diagnostics.Process.Start("www.facebook.com/ronell.miguel")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        System.Diagnostics.Process.Start("www.facebook.com/63474672655855676132467762773d3d")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmabout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        'Me.pnlCenter.Left = (Me.ClientSize.Width - Me.pnlCenter.Width) / 2
        Me.pnlCenter.Left = (Me.Width - Me.pnlCenter.Width) / 2
        Me.pnlCenter.Top = (Me.Height - Me.pnlCenter.Height) / 2
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
    End Sub
End Class