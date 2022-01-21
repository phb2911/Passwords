Option Explicit On
Option Strict On

Public Class LogIn

    Dim _user As User = User.CreateUser()
    Dim _result As GF.DialogResult = GF.DialogResult.Cancel

    Private Sub LogIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub LogIn_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Forms.Form1.DoLogIn(Me._result)
        My.Forms.Form1.ResetTimer()
    End Sub

    Private Sub LogIn_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        GF.DisposeForm(Me)
    End Sub

    Public Shadows Function ShowDialog() As GF.DialogResult
        MyBase.ShowDialog(My.Forms.Form1)
        Return Me._result
    End Function

    Public Shadows Function Show() As GF.DialogResult
        MyBase.Show(My.Forms.Form1)
        Return Me._result
    End Function

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Me.Cursor = Cursors.WaitCursor

        Dim ErrMsg As String = ""

        If Me._user.Authenticate(Me.txtUserId.Text, Me.txtPwd.Text, ErrMsg) Then
            Me._result = GF.DialogResult.OK
            Me.Close()
        Else
            Me.Cursor = Cursors.Default
            MessageBox.Show(ErrMsg, "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegister.Click
        Me._result = GF.DialogResult.Register
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New test
        frm.ShowDialog()
    End Sub
End Class