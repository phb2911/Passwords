Option Explicit On
Option Strict On

Public Class Category

    Dim _userId As Integer
    Dim _categoryId As Integer
    Dim _categoryName As String
    Dim _result As GF.DialogResult
    Dim _addMode As Boolean

    Public Sub New(ByVal UserId As Integer)
        InitializeComponent()
        Me._userId = UserId
        Me._categoryId = -1
        Me._categoryName = ""
        Me._result = GF.DialogResult.Cancel
    End Sub

    Public Sub New(ByVal UserId As Integer, ByVal Name As String, ByVal Id As Integer)
        InitializeComponent()
        Me._userId = UserId
        Me._categoryId = Id
        Me._categoryName = Name
        Me._result = GF.DialogResult.Cancel
    End Sub

    Public Property CategoryId() As Integer
        Get
            Return Me._categoryId
        End Get
        Set(ByVal value As Integer)
            Me._categoryId = value
        End Set
    End Property

    Public Property CategoryName() As String
        Get
            Return Me._categoryName
        End Get
        Set(ByVal value As String)
            Me._categoryName = value
        End Set
    End Property

    Private Sub Category_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Forms.Form1.ResetTimer()
    End Sub

    Private Sub Category_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me._addMode = (Me._categoryId < 0)

        If Me._addMode Then
            Me.Text = "Add New Category"
        Else
            Me.Text = "Rename Category"
            Me.txtCategory.Text = Me._categoryName
        End If

    End Sub

    Public Shadows Function ShowDialog() As GF.DialogResult
        MyBase.ShowDialog()
        Return Me._result
    End Function

    Public Shadows Function ShowDialog(ByVal owner As System.Windows.Forms.IWin32Window) As GF.DialogResult
        MyBase.ShowDialog(owner)
        Return Me._result
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If Me.AddCategory() Then
            Me._result = GF.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Function AddCategory() As Boolean

        Dim result As Boolean = True
        Dim errMsg As String = ""
        Dim len As Integer = Me.txtCategory.Text.Trim.Length

        If len > 0 And len <= 30 Then

            Dim myConn As New SqlClient.SqlConnection(GF.ConnectionString)
            Dim myCmd As New SqlClient.SqlCommand

            ' create parameters and set values
            myCmd.Parameters.Add("@NewCategoryName", SqlDbType.VarChar, 30).Value = Me.txtCategory.Text.Trim
            myCmd.Parameters.Add("@OldCategoryName", SqlDbType.VarChar, 30).Value = Me._categoryName
            myCmd.Parameters.Add("@UserId", SqlDbType.Int).Value = Me._userId
            myCmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = Me._categoryId

            Try

                myConn.Open()
                myCmd.Connection = myConn

                If Me._addMode Then
                    ' add new category

                    ' check if category exists
                    myCmd.CommandText = "SELECT COUNT([CategoryId]) FROM [Categories] WHERE [Category] = @NewCategoryName AND [Owner] = @UserId"

                    If CInt(myCmd.ExecuteScalar) = 0 Then

                        ' insert new category
                        myCmd.CommandText = "INSERT INTO [Categories] ([Category], [Owner]) VALUES (@NewCategoryName, @UserId); SELECT @@IDENTITY"

                        Me._categoryId = CInt(myCmd.ExecuteScalar())
                        Me._categoryName = Me.txtCategory.Text.Trim

                    Else

                        errMsg = "Category already exists. Please select a different name."
                        result = False

                    End If


                Else

                    ' edit existing category

                    ' check if category id exists and if it still has the same name.
                    myCmd.CommandText = "SELECT COUNT([CategoryId]) FROM [Categories] WHERE [CategoryId] = @CategoryId AND [Category] = @OldCategoryName;"

                    If CInt(myCmd.ExecuteScalar) = 0 Then
                        errMsg = "Unable to find selected category. Please try again."
                        Me.Close()
                        My.Forms.Form1.tsbRefresh_Click(Nothing, Nothing)
                        result = False
                    Else

                        ' check if user has category with same name and different id.
                        myCmd.CommandText = "SELECT COUNT([CategoryId]) FROM [Categories] WHERE [Category] = @NewCategoryName AND [Owner] = @UserId AND [CategoryId] <> @CategoryId;"

                        If CInt(myCmd.ExecuteScalar) > 0 Then
                            errMsg = "There's another category with the same name. Please select a different name."
                            result = False
                        Else

                            ' finally change name.
                            myCmd.CommandText = "UPDATE [Categories] SET [Category] = @NewCategoryName WHERE [CategoryId] = @CategoryId;"

                            myCmd.ExecuteNonQuery()

                            Me._categoryName = Me.txtCategory.Text.Trim

                        End If

                    End If

                End If

            Catch ex As Exception
                errMsg = "Unable to finalize operation: " & ex.Message
                result = False
            End Try

            ' clean up
            If myConn.State = ConnectionState.Open Then myConn.Close()
            myConn.Dispose()
            myConn = Nothing

            myCmd.Dispose()
            myCmd = Nothing

        Else

            errMsg = "The category must have at least 1 and a maximum of 30 characters."
            result = False

        End If

        If Not result Then _
            MessageBox.Show(errMsg, "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Return result

    End Function

End Class