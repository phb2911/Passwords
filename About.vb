Option Explicit On
Option Strict On

Public Class About

    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim w As Integer = Me.GroupBox1.Width

        Me.Label1.Left = CInt((w - Me.Label1.Width) / 2)
        Me.LinkLabel1.Left = CInt((w - Me.LinkLabel1.Width) / 2)

    End Sub

    Private Sub About_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Forms.Form1.ResetTimer()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            System.Diagnostics.Process.Start("mailto:phb2911@hotmail.com")
        Catch ex As Exception
            MessageBox.Show("Unable to open E-mail.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class