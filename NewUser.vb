Option Explicit On
Option Strict On

Imports System.Text.RegularExpressions

Public Class NewUser

    Dim _user As User
    Dim _result As GF.DialogResult = GF.DialogResult.Cancel

    Private Sub NewUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me._user = User.CreateUser()
        Me._result = GF.DialogResult.Cancel

    End Sub

    Private Sub NewUser_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        GF.DisposeForm(Me)
    End Sub

    Private Sub NewUser_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Forms.Form1.DoLogIn(Me._result)
        My.Forms.Form1.ResetTimer()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Me.Cursor = Cursors.WaitCursor

        Dim ErrMsg As String = ""

        If Me.ValidateFields(ErrMsg) AndAlso Me._user.AddNewUser(-1, Me.txtUserName.Text, Me.txtUserId.Text, Me.txtPwd.Text, ErrMsg) Then
            Me._result = GF.DialogResult.OK
            Me.Close()
        Else
            Me.Cursor = Cursors.Default
            MessageBox.Show(ErrMsg, "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        My.Forms.Form1.tsbLogin_Click(Nothing, Nothing)
    End Sub

    Private Sub txtUserName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUserName.KeyUp
        If e.KeyValue = 13 Then Me.txtUserId.Focus()
    End Sub

    Private Sub txtUserId_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUserId.KeyUp
        If e.KeyValue = 13 Then Me.txtPwd.Focus()
    End Sub

    Private Sub txtPwd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPwd.KeyUp
        If e.KeyValue = 13 Then Me.txtPwd2.Focus()
    End Sub

    Private Sub txtPwd2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPwd2.KeyUp
        If e.KeyValue = 13 Then
            Me.btnOk.Focus()
            Me.btnOk_Click(Nothing, Nothing)
        End If
    End Sub

    Private Function ValidateFields(ByRef ErrorMsg As String) As Boolean

        Dim flag As Boolean = True

        Me.txtUserName.Text = Me.txtUserName.Text.Trim

        If Me.txtUserName.Text.Length < 6 Then
            ErrorMsg = "Invalid User Name."
            flag = False
            Me.txtUserName.Focus()
        ElseIf Not Me.IsValid(Me.txtUserId.Text) Then
            ErrorMsg = "Invalid User Id."
            flag = False
            Me.txtUserId.Focus()
        ElseIf Not Me.IsValid(Me.txtPwd.Text) Then
            ErrorMsg = "Invalid Password."
            flag = False
            Me.txtPwd.Focus()
        ElseIf Me.txtPwd.Text <> Me.txtPwd2.Text Then
            ErrorMsg = "The two passwords must be identical."
            flag = False
            Me.txtPwd.Focus()
        ElseIf Me.txtUserId.Text.ToUpper = Me.txtPwd.Text.ToUpper Then
            ErrorMsg = "The User Id and Password must be different."
            flag = False
            Me.txtUserId.Focus()
        End If

        Return flag

    End Function

    Private Function IsValid(ByVal value As String) As Boolean

        Return value.Length > 5 AndAlso Regex.IsMatch(value, "^(^\w+)$") AndAlso Regex.IsMatch(value, "^(\D)")

    End Function

    Public Shadows Function ShowDialog() As GF.DialogResult
        MyBase.ShowDialog()
        Return Me._result
    End Function

End Class