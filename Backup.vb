Option Strict On

Imports System.Xml

Public Class Backup

    Private Sub Backup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click

        Dim dia As New SaveFileDialog

        dia.FileName = "Passwords.xml"
        dia.AddExtension = True
        dia.DefaultExt = "xml"
        dia.OverwritePrompt = False
        dia.Filter = "XML Files | *.xml"

        If dia.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Me.txtSaveTo.Text = dia.FileName

        End If

        dia.Dispose()
        dia = Nothing

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If Me.txtSaveTo.Text.Trim.Length = 0 Then

            MessageBox.Show("The path name is not valid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txtSaveTo.Focus()
            Exit Sub

        End If

        ' check if file exists - prompt if so
        If System.IO.File.Exists(Me.txtSaveTo.Text) AndAlso _
            MessageBox.Show("The file you are about to save already exists." & vbCrLf & "Do you want to continue?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No _
            Then Exit Sub

        Me.CreateBackupFile()

    End Sub

    Private Sub CreateBackupFile()

        Me.Cursor = Cursors.WaitCursor

        Dim myConn As New SqlClient.SqlConnection(GF.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myRd As SqlClient.SqlDataReader
        Dim UserCol As New List(Of User)


        Try

            myCmd.Connection = myConn
            myCmd.CommandText = "SELECT * FROM [Users]"

            myConn.Open()

            myRd = myCmd.ExecuteReader

            While myRd.Read

                Dim usr As New User

                usr.id = CInt(myRd("ID"))
                usr.Name = myRd("Name").ToString
                usr.UserId = myRd("UserId").ToString
                usr.Password = myRd("Password").ToString

                UserCol.Add(usr)

            End While

            myRd.Close()

            Dim xWrt As New System.Xml.XmlTextWriter(Me.txtSaveTo.Text, System.Text.Encoding.UTF8)

            xWrt.WriteStartDocument(True)
            xWrt.Formatting = Xml.Formatting.Indented
            xWrt.Indentation = 5

            xWrt.WriteStartElement("PasswordsBackup")
            xWrt.WriteAttributeString("Version", "2")
            xWrt.WriteAttributeString("Date", Now.ToString)

            For Each u As User In UserCol

                xWrt.WriteStartElement("User")
                xWrt.WriteAttributeString("ID", u.id.ToString)
                xWrt.WriteAttributeString("Name", u.Name)
                xWrt.WriteAttributeString("UserId", u.UserId)
                xWrt.WriteAttributeString("Password", u.Password)

                xWrt.WriteStartElement("Categories")

                myCmd.CommandText = "SELECT * FROM [Categories] WHERE Owner = " & u.id.ToString

                myRd = myCmd.ExecuteReader

                While myRd.Read

                    xWrt.WriteStartElement("Category")

                    xWrt.WriteStartElement("ID")
                    xWrt.WriteString(myRd("CategoryId").ToString)
                    xWrt.WriteEndElement()

                    xWrt.WriteStartElement("Name")
                    xWrt.WriteString(myRd("Category").ToString)
                    xWrt.WriteEndElement()

                    'category
                    xWrt.WriteEndElement()

                End While

                myRd.Close()

                'categories
                xWrt.WriteEndElement()

                xWrt.WriteStartElement("Passwords")

                myCmd.CommandText = "SELECT * FROM [Passwords] WHERE [User] = " & u.id.ToString

                myRd = myCmd.ExecuteReader

                While myRd.Read

                    xWrt.WriteStartElement("Password")

                    xWrt.WriteStartElement("ID")
                    xWrt.WriteString(myRd("Id").ToString)
                    xWrt.WriteEndElement()

                    xWrt.WriteStartElement("Description")
                    xWrt.WriteString(myRd("Description").ToString)
                    xWrt.WriteEndElement()

                    xWrt.WriteStartElement("LoginId")
                    xWrt.WriteString(myRd("LoginId").ToString)
                    xWrt.WriteEndElement()

                    xWrt.WriteStartElement("Pwd")
                    xWrt.WriteString(myRd("Password").ToString)
                    xWrt.WriteEndElement()

                    xWrt.WriteStartElement("WebSite")
                    xWrt.WriteString(myRd("WebSite").ToString)
                    xWrt.WriteEndElement()

                    xWrt.WriteStartElement("Notes")
                    xWrt.WriteString(myRd("Notes").ToString)
                    xWrt.WriteEndElement()

                    xWrt.WriteStartElement("CategoryID")
                    xWrt.WriteString(myRd("CategoryId").ToString)
                    xWrt.WriteEndElement()

                    xWrt.WriteStartElement("LastModified")
                    xWrt.WriteString(myRd("LastModified").ToString)
                    xWrt.WriteEndElement()

                    'password
                    xWrt.WriteEndElement()

                End While

                myRd.Close()

                'passwords
                xWrt.WriteEndElement()

                'user
                xWrt.WriteEndElement()

            Next

            'PasswordBackup
            xWrt.WriteEndElement()

            xWrt.Close()

            Me.Cursor = Cursors.Default

            MessageBox.Show("Backup file saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception

            Me.Cursor = Cursors.Default

            MessageBox.Show("An error occured." & vbCrLf & "Details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        If myConn.State = ConnectionState.Open Then myConn.Close()
        myConn.Dispose()
        myCmd.Dispose()

    End Sub

    Private Class User
        Public id As Integer
        Public Name As String
        Public UserId As String
        Public Password As String
    End Class

    Private Sub btnFindFile_Click(sender As Object, e As EventArgs) Handles btnFindFile.Click

        Dim dia As New OpenFileDialog

        dia.Filter = "XML Files | *.xml"
        dia.DefaultExt = "xml"
        dia.Multiselect = False

        If dia.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtBackupFile.Text = dia.FileName
        End If

        dia.Dispose()

    End Sub

End Class