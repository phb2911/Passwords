Option Explicit On
Option Strict On

Imports System.Text.RegularExpressions

Public Class EditUser

    Dim _user As User
    Dim _deleted As Boolean

    Private Sub EditUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me._user = User.CreateUser
        Me._deleted = False
        Me.Text = "Edit User [" & Me._user.UserName & "]"
    End Sub

    Private Sub EditUser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Forms.Form1.ResetTimer()
    End Sub

    Public ReadOnly Property UserDeleted() As Boolean
        Get
            Return Me._deleted
        End Get
    End Property

    Private Sub cbxUserName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxUserName.CheckedChanged
        Me.Label1.Enabled = Me.cbxUserName.Checked
        Me.txtUserName.Enabled = Me.cbxUserName.Checked
        Me.UpdateOkButton()
    End Sub

    Private Sub cbxUserId_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxUserId.CheckedChanged
        Me.Label2.Enabled = Me.cbxUserId.Checked
        Me.txtUserId.Enabled = Me.cbxUserId.Checked
        Me.UpdateOkButton()
    End Sub

    Private Sub cbxPassword_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxPassword.CheckedChanged
        Me.Label3.Enabled = Me.cbxPassword.Checked
        Me.txtPwd.Enabled = Me.cbxPassword.Checked
        Me.Label4.Enabled = Me.cbxPassword.Checked
        Me.txtPwd2.Enabled = Me.cbxPassword.Checked
        Me.UpdateOkButton()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Dim ErrMsg As String = ""

        Me.Cursor = Cursors.WaitCursor

        Dim UserName As String = Me._user.UserName
        Dim UserId As String = Me._user.UserId
        Dim Pwd As String = Me._user.Password

        If Me.cbxUserName.Checked Then UserName = Me.txtUserName.Text
        If Me.cbxUserId.Checked Then UserId = Me.txtUserId.Text
        If Me.cbxPassword.Checked Then Pwd = Me.txtPwd.Text

        If Me.ValidateFields(ErrMsg) AndAlso Me._user.AddNewUser(Me._user.RecordId, UserName, UserId, Pwd, ErrMsg) Then
            Me.Close()
        Else
            Me.Cursor = Cursors.Default
            MessageBox.Show(ErrMsg, "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Function ValidateFields(ByRef ErrorMessage As String) As Boolean

        Dim result As Boolean = True

        Me.txtUserName.Text = Me.txtUserName.Text.Trim

        If Me.cbxUserName.Checked And Me.txtUserName.Text.Length < 6 Then
            ErrorMessage = "Invalid User Name."
            result = False
            Me.txtUserName.Focus()
        ElseIf Me.cbxUserId.Checked And Not Me.IsValid(Me.txtUserId.Text) Then
            ErrorMessage = "Invalid User Id."
            result = False
            Me.txtUserId.Focus()
        ElseIf Me.cbxPassword.Checked And Not Me.IsValid(Me.txtPwd.Text) Then
            ErrorMessage = "Invalid Password."
            result = False
            Me.txtPwd.Focus()
        ElseIf Me.cbxPassword.Checked And Me.txtPwd.Text <> Me.txtPwd2.Text Then
            ErrorMessage = "The two passwords must be identical."
            result = False
            Me.txtPwd.Focus()
        ElseIf Me.cbxUserId.Checked And Me.cbxPassword.Checked And Me.txtUserId.Text = Me.txtPwd.Text Then
            ErrorMessage = "The User Id and Password must be different."
            result = False
            Me.txtUserId.Focus()
        ElseIf Me.cbxUserId.Checked And Not Me.cbxPassword.Checked And Me.txtUserId.Text = Me._user.Password Then
            ErrorMessage = "The new User Id must be different from the current Password."
            result = False
            Me.txtUserId.Focus()
        ElseIf Not Me.cbxUserId.Checked And Me.cbxPassword.Checked And Me.txtPwd.Text = Me._user.UserId Then
            ErrorMessage = "The new Password must be different from the current User Id."
            result = False
            Me.txtPwd.Focus()
        End If

        Return result

    End Function

    Private Function IsValid(ByVal value As String) As Boolean

        Return value.Length > 5 AndAlso Regex.IsMatch(value, "^(^\w+)$") AndAlso Regex.IsMatch(value, "^(\D)")

    End Function

    Private Sub UpdateOkButton()

        Me.btnOK.Enabled = (Me.cbxUserName.Checked Or Me.cbxUserId.Checked Or Me.cbxPassword.Checked)

    End Sub

    Private Sub btnDeleteUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteUser.Click

        If MessageBox.Show("All data will be lost." & vbCrLf & "Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then

            Me.Cursor = Cursors.WaitCursor

            Dim myConn As New SqlClient.SqlConnection(GF.ConnectionString)
            Dim myCmd As New SqlClient.SqlCommand
            Dim ErrFlag As Boolean = False
            Dim ErrMsg As String = ""

            Try

                myCmd.Connection = myConn
                myCmd.CommandText = "DELETE FROM [Users] WHERE [Id]=" & Me._user.RecordId.ToString

                myConn.Open()

                myCmd.ExecuteNonQuery()

            Catch ex As Exception
                ErrMsg = ex.Message
                ErrFlag = True
            End Try

            If myConn.State = ConnectionState.Open Then myConn.Close()
            myConn.Dispose()
            myCmd.Dispose()

            Me.Cursor = Cursors.Default

            If ErrFlag Then
                MessageBox.Show("Error Deleting User." & vbCrLf & vbCrLf & ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Me._deleted = True
                Me.Close()
            End If

        End If

    End Sub

    Private Sub chkDeleteUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDeleteUser.CheckedChanged
        Me.btnDeleteUser.Enabled = Me.chkDeleteUser.Checked
    End Sub

End Class