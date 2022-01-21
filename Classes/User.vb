Option Explicit On
Option Strict On

Public Class User

    Shared _user As User

    Dim _isLoggedIn As Boolean
    Dim _userName As String
    Dim _userId As String
    Dim _pwd As String
    Dim _recId As Integer

    Private Sub New()

    End Sub

    Public Shared Function CreateUser() As User

        If _user Is Nothing Then

            ' create new object
            _user = New User

            ' set new global variables
            _user._DoLogOut()

        End If

        Return _user

    End Function

    Public ReadOnly Property IsLoggedIn() As Boolean
        Get
            Return _user._isLoggedIn
        End Get
    End Property

    Public ReadOnly Property UserName() As String
        Get
            Return _user._userName
        End Get
    End Property

    Public ReadOnly Property UserId() As String
        Get
            Return _user._userId
        End Get
    End Property

    Public ReadOnly Property Password() As String
        Get
            Return _user._pwd
        End Get
    End Property

    Public ReadOnly Property RecordId() As Integer
        Get
            Return _user._recId
        End Get
    End Property

    Public Function Authenticate(ByVal UsId As String, ByVal Pwd As String, ByRef ErrorMsg As String) As Boolean
        Return _user._Authenticate(UsId, Pwd, ErrorMsg)
    End Function

    Private Function _Authenticate(ByVal UsId As String, ByVal Pwd As String, ByRef ErrorMsg As String) As Boolean

        Dim myConn As New SqlClient.SqlConnection(GF.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand("SELECT * FROM [Users]", myConn)
        Dim myRd As SqlClient.SqlDataReader = Nothing
        Dim result As Boolean = False

        If _user.IsLoggedIn Then Throw New Exception("Already logged in.")

        Try

            myConn.Open()

            myRd = myCmd.ExecuteReader()

            While myRd.Read()
                If myRd("UserId").ToString.ToUpper = UsId.ToUpper And myRd("Password").ToString = Crypto.MD5.HashString(Pwd) Then
                    _user._isLoggedIn = True
                    _user._recId = CInt(myRd("Id"))
                    _user._userName = myRd("Name").ToString
                    _user._userId = myRd("UserId").ToString
                    _user._pwd = Pwd
                    result = True
                    Exit While
                End If
            End While

            If Not result Then
                ErrorMsg = "Invalid User Id or Password."
            End If

        Catch ex As Exception
            result = False
            ErrorMsg = ex.Message
        End Try

        If Not IsNothing(myRd) Then myRd.Close()
        If myConn.State = ConnectionState.Open Then myConn.Close()
        myConn.Dispose()
        myCmd.Dispose()

        Return result

    End Function

    Public Function AddNewUser(ByVal Id As Integer, ByVal UserName As String, ByVal UserId As String, ByVal Password As String, ByRef ErrorMsg As String) As Boolean
        Return _user._AddNewUser(Id, UserName, UserId, Password, ErrorMsg)
    End Function

    Private Function _AddNewUser(ByVal Id As Integer, ByVal UserName As String, ByVal UserId As String, ByVal Password As String, ByRef ErrorMsg As String) As Boolean

        Dim myConn As New SqlClient.SqlConnection(GF.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim result As Boolean = True

        'encrypt
        Password = Crypto.MD5.HashString(Password)

        myCmd.Connection = myConn

        myCmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id
        myCmd.Parameters.Add("@UserName", SqlDbType.VarChar, 15).Value = UserName
        myCmd.Parameters.Add("@UserId", SqlDbType.VarChar, 15).Value = UserId
        myCmd.Parameters.Add("@Password", SqlDbType.VarChar, 24).Value = Password

        myCmd.CommandText = "SELECT COUNT([Id]) FROM [Users] WHERE [UserId] = @UserId AND [Id] <> @ID"

        Try

            myConn.Open()

            If CInt(myCmd.ExecuteScalar()) = 0 Then

                myCmd.CommandText = "EXEC mysp_AddUser @ID, @UserName, @UserId, @Password;"

                _user._recId = CInt(myCmd.ExecuteScalar())
                _user._isLoggedIn = True
                _user._userName = UserName
                _user._userId = UserId
                _user._pwd = Password

            Else
                ErrorMsg = "User Id already exists. Try a different one."
                result = False
            End If

        Catch ex As Exception
            ErrorMsg = "Database Error: " & ex.Message
            result = False
        End Try

        If myConn.State = ConnectionState.Open Then myConn.Close()
        myConn.Dispose()
        myCmd.Dispose()

        Return result

    End Function

    Public Sub DoLogOut()
        _user._DoLogOut()
    End Sub

    Private Sub _DoLogOut()

        _user._isLoggedIn = False
        _user._userName = ""
        _user._userId = ""
        _user._pwd = ""
        _user._recId = -1

    End Sub

    Public Sub Dispose()
        _user._Dispose()
    End Sub

    Private Sub _Dispose()
        _user = Nothing
    End Sub

End Class
