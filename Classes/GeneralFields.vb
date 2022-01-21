Option Explicit On
Option Strict On

Public Class GF

    Private Sub New()

    End Sub

    Public Enum DialogResult As Integer
        OK = 0
        Cancel = 1
        Register = 2
        Save = 4
        Logout = 8
    End Enum

    Public Shared ReadOnly Property ConnectionString() As String
        Get
            ' Return "data source=TOUCHSMART\SQLEXPRESS; user id=sa; password=pert22; initial catalog=Passwords"
            Return "Server=localhost\SQLEXPRESS;Database=Passwords;Trusted_Connection=True;"
        End Get
    End Property

    Public Shared ReadOnly Property EncodingKey() As String
        Get
            Return "SDaflkweru92flSDkei98pOIhd83mx"
        End Get
    End Property

    Public Shared Sub DisposeForm(ByVal TheForm As Form)
        TheForm.Dispose()
        TheForm = Nothing
    End Sub

End Class
