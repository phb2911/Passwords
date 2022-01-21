Option Explicit On
Option Strict On

Public Class NewRecord

    Dim _userId As Integer
    Dim _editMode As Boolean
    Dim _pwdData As PasswordData
    Dim _result As GF.DialogResult = GF.DialogResult.Cancel
    Dim _toolTip As New ToolTip

    Public Sub New(ByVal UserId As Integer)

        InitializeComponent()

        Me._userId = UserId
        Me._editMode = False

    End Sub

    Public Sub New(ByVal UserId As Integer, ByVal EditMode As Boolean, ByRef theData As PasswordData)

        InitializeComponent()

        Me._userId = UserId
        Me._editMode = EditMode
        Me._pwdData = theData

        If Me._editMode AndAlso Me._pwdData Is Nothing Then Throw New Exception("Data object not set in Edit Mode.")

    End Sub

    Public ReadOnly Property Data() As PasswordData
        Get
            Return Me._pwdData
        End Get
    End Property

    Private Sub NewRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.cbxCategory.Items.Add("")

        For Each n As TreeNode In My.Forms.Form1.TreeView1.Nodes
            Me.cbxCategory.Items.Add(n.Text)
        Next

        If Me._editMode Then
            Me.Text = "Edit Record"
            Me.PopulateData()
        Else
            Me.cbxCategory.SelectedIndex = 0
        End If

        Me._toolTip.SetToolTip(Me.btnNewCategory, "Create New Category")

    End Sub

    Private Sub NewRecord_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Forms.Form1.ResetTimer()
    End Sub

    Public Shadows Function ShowDialog() As GF.DialogResult
        MyBase.ShowDialog()
        Return Me._result
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim myConn As New SqlClient.SqlConnection(GF.ConnectionString)

        Try
            myConn.Open()
        Catch ex As Exception
            MessageBox.Show("Unable to open connection: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        If Me.ValidateFields() AndAlso Me.ConcurrencyCheck(myConn) Then

            Dim myCmd As New SqlClient.SqlCommand
            Dim myRecId As Integer
            Dim myCategory As Integer
            Dim ErrMsg As String = ""
            Dim ErrFlag As Boolean = False

            myCmd.Parameters.Add("@UserId", SqlDbType.Int).Value = Me._userId
            myCmd.Parameters.Add("@RecId", SqlDbType.Int).Value = -1
            myCmd.Parameters.Add("@Desc", SqlDbType.VarChar, 200).Value = Crypto.TripleDES.Encode(Me.txtDescription.Text, GF.EncodingKey)
            myCmd.Parameters.Add("@LoginId", SqlDbType.VarChar, 200).Value = Crypto.TripleDES.Encode(Me.txtLoginId.Text, GF.EncodingKey)
            myCmd.Parameters.Add("@Password", SqlDbType.VarChar, 200).Value = Crypto.TripleDES.Encode(Me.txtPwd.Text, GF.EncodingKey)
            myCmd.Parameters.Add("@WebSite", SqlDbType.VarChar, 400)
            myCmd.Parameters.Add("@Notes", SqlDbType.VarChar, 3000)
            myCmd.Parameters.Add("@Category", SqlDbType.Int)

            If Me._editMode Then
                myCmd.Parameters("@RecId").Value = Me._pwdData.RecordId
            End If

            If Me.txtWebSite.Text.Trim.Length = 0 Then
                myCmd.Parameters("@WebSite").Value = DBNull.Value
            Else
                myCmd.Parameters("@WebSite").Value = Crypto.TripleDES.Encode(Me.txtWebSite.Text.Trim, GF.EncodingKey)
            End If

            If Me.txtNotes.Text.Length = 0 Then
                myCmd.Parameters("@Notes").Value = DBNull.Value
            Else
                myCmd.Parameters("@Notes").Value = Crypto.TripleDES.Encode(Me.txtNotes.Text, GF.EncodingKey)
            End If

            For Each n As TreeNode In My.Forms.Form1.TreeView1.Nodes

                If n.Text = Me.cbxCategory.Text Then
                    myCategory = CInt(n.Tag)
                    Exit For
                End If

            Next

            myCmd.Parameters("@Category").Value = myCategory

            myCmd.Connection = myConn
            myCmd.CommandText = "EXEC mysp_AddRecord @UserId, @RecId, @Desc, @LoginId, @Password, @WebSite, @Notes, @Category"

            Try

                myRecId = CInt(myCmd.ExecuteScalar())

            Catch ex As Exception
                ErrFlag = True
                ErrMsg = ex.Message
            End Try

            If myConn.State = ConnectionState.Open Then myConn.Close()
            myConn.Dispose()
            myConn = Nothing

            myCmd.Dispose()
            myCmd = Nothing

            Me.AddRecToDataObj(myRecId, myCategory)

            If ErrFlag Then
                MessageBox.Show("Unable to create/modify record." & vbCrLf & vbCrLf & ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Me.Close()
            End If

            Me._result = GF.DialogResult.Save
            
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub AddRecToDataObj(ByVal RecId As Integer, ByVal CategoryId As Integer)

        If Not Me._editMode Then Me._pwdData = New PasswordData

        With Me._pwdData
            .RecordId = RecId
            .Category = CategoryId
            .Description = Me.txtDescription.Text
            .LoginId = Me.txtLoginId.Text
            .Password = Me.txtPwd.Text
            .WebSite = Me.txtWebSite.Text
            .Notes = Me.txtNotes.Text
        End With

    End Sub

    Private Sub PopulateData()

        For Each n As TreeNode In My.Forms.Form1.TreeView1.Nodes

            If CInt(n.Tag) = Me._pwdData.Category Then
                Me.cbxCategory.Text = n.Text
                Exit For
            End If

        Next

        Me.txtDescription.Text = Me._pwdData.Description
        Me.txtLoginId.Text = Me._pwdData.LoginId
        Me.txtPwd.Text = Me._pwdData.Password
        Me.txtWebSite.Text = Me._pwdData.WebSite
        Me.txtNotes.Text = Me._pwdData.Notes

    End Sub

    Private Function ValidateFields() As Boolean

        Dim msg As String = ""
        Dim flag As Boolean = True

        If Me.cbxCategory.SelectedIndex <= 0 Then
            msg = "Please select a category."
            Me.cbxCategory.Focus()
            flag = False
        ElseIf Me.txtDescription.Text.Trim = "" Then
            msg = "Invalid Description"
            Me.txtDescription.Focus()
            flag = False
        ElseIf Me.txtLoginId.Text.Trim = "" Then
            msg = "Invalid Login Id."
            Me.txtLoginId.Focus()
            flag = False
        ElseIf Me.txtPwd.Text.Trim = "" Then
            msg = "Invalid Password."
            Me.txtPwd.Focus()
            flag = False
        End If

        If Not flag Then MessageBox.Show(msg, "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Return flag

    End Function

    Private Function ConcurrencyCheck(ByRef Connection As SqlClient.SqlConnection) As Boolean

        If Not Me._editMode Then Return True

        If Not Connection.State = ConnectionState.Open Then Throw New Exception("Connection must be open.")

        Dim myCmd As New SqlClient.SqlCommand
        Dim myRd As SqlClient.SqlDataReader = Nothing
        Dim Result As Boolean = False
        Dim ErrFlag As Boolean = False
        Dim ErrMsg As String = ""

        myCmd.Parameters.Add("@RecId", SqlDbType.Int).Value = Me._pwdData.RecordId

        myCmd.Connection = Connection
        myCmd.CommandText = "SELECT * FROM [Passwords] WHERE [Id] = @RecId;"

        Try

            myRd = myCmd.ExecuteReader

            If myRd.Read Then

                Dim Dsc As String = Crypto.TripleDES.Decode(myRd("Description").ToString, GF.EncodingKey)
                Dim Log As String = Crypto.TripleDES.Decode(myRd("LoginId").ToString, GF.EncodingKey)
                Dim Pwd As String = Crypto.TripleDES.Decode(myRd("Password").ToString, GF.EncodingKey)
                Dim Web As String = ""
                Dim Nts As String = ""
                Dim Cat As Integer = CInt(myRd("CategoryId"))

                If Not IsDBNull(myRd("WebSite")) Then Web = Crypto.TripleDES.Decode(myRd("WebSite").ToString, GF.EncodingKey)
                If Not IsDBNull(myRd("Notes")) Then Nts = Crypto.TripleDES.Decode(myRd("Notes").ToString, GF.EncodingKey)

                Result = (Dsc = Me._pwdData.Description) And (Log = Me._pwdData.LoginId) _
                    And (Pwd = Me._pwdData.Password) And (Web = Me._pwdData.WebSite) _
                    And (Nts = Me._pwdData.Notes) And (Cat = Me._pwdData.Category)

            End If

            myRd.Close()

        Catch ex As Exception
            ErrFlag = True
            ErrMsg = ex.Message
        End Try

        If ErrFlag Then
            If Connection.State = ConnectionState.Open Then Connection.Close()
            Connection.Dispose()
            MessageBox.Show("Unable to perform concurrency check." & vbCrLf & vbCrLf & ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If Not Result Then
            If Connection.State = ConnectionState.Open Then Connection.Close()
            Connection.Dispose()
            MessageBox.Show("The data was modified by another process. Please try again.", "Concurrency Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            My.Forms.Form1.tsbRefresh_Click(Nothing, Nothing)
            Me.Close()
            Return False
        End If

        Return True

    End Function

    Private Sub btnNewCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewCategory.Click

        Dim frm As New Category(Me._userId)

        If frm.ShowDialog(My.Forms.Form1) = GF.DialogResult.OK Then

            Dim node As New TreeNode(frm.CategoryName)

            node.Tag = frm.CategoryId

            My.Forms.Form1.TreeView1.Nodes.Add(node)

            Me.cbxCategory.Items.Add(frm.CategoryName)
            Me.cbxCategory.SelectedIndex = Me.cbxCategory.Items.Count - 1

        End If

        frm.Dispose()
        frm = Nothing

    End Sub

End Class