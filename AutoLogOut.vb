Option Strict On

Public Class AutoLogOut

    Dim _result As GF.DialogResult = GF.DialogResult.Cancel

    Private Sub AutoLogOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Static sec As Integer = 20
        Static tent As Integer = 0

        tent += 1

        Me.ProgressBar1.Value += 1
        
        If tent = 10 Then
            sec -= 1
            tent = 0
        End If

        If sec = 0 Then
            Me._result = GF.DialogResult.Logout
            Me.Close()
        Else
            Me.Label1.Text = "This user will be automatically logged out in " & sec.ToString & " seconds."
        End If

    End Sub

    Public Shadows Function ShowDialog() As GF.DialogResult
        MyBase.ShowDialog(My.Forms.Form1)
        Return Me._result
    End Function

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Me._result = GF.DialogResult.Logout
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class