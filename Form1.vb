Option Explicit On
Option Strict On

Public Class Form1

#Region "Global Fields"

    Dim _user As User
    Dim _toolTip As New ToolTip
    Dim _frmLogin As LogIn
    Dim _frmReg As NewUser
    Dim _dataCol As New DataCollection

#End Region ' Global Fields

#Region "Form Events"

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me._user = User.CreateUser()

        Me.LoadInitialSettings()
        Me.ChangeControlState(False)

        Me.SetToolTip()

        Me.ToolStripStatusLabel1.Text = "Ready"

    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        Me.tsbLogin_Click(Nothing, Nothing)

    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Me.SaveAppSettings()

    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect

        If e.Node.Level = 0 Then

            Me.ClearTextBoxes()

            Me.ToolStripStatusLabel1.Text = "Category: " & e.Node.Text

        Else

            Dim myData As PasswordData = Me._dataCol.GetRecord(CInt(e.Node.Tag))

            Me.txtDescription.Text = myData.Description
            Me.txtLoginId.Text = myData.LoginId
            Me.txtPwd.Text = myData.Password
            Me.txtWebSite.Text = myData.WebSite
            Me.txtNotes.Text = myData.Notes

            Me.ToolStripStatusLabel1.Text = "Description: " & e.Node.Text

        End If

    End Sub

    Private Sub TreeView1_AfterAndBeforeCollapse(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeView1.BeforeCollapse, TreeView1.BeforeExpand

        If e.Node.Level = 0 Then

            If e.Node.IsExpanded Then
                e.Node.ImageIndex = 0
                e.Node.SelectedImageIndex = 0
            Else
                e.Node.ImageIndex = 1
                e.Node.SelectedImageIndex = 1
            End If

        End If

    End Sub

    Private Sub TreeView1_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick

        If e.Button = Windows.Forms.MouseButtons.Right Then

            Me.TreeView1.SelectedNode = e.Node

            Me.CreateMoveToTSMI()

            Me.ContextMenuStrip1.Show(Me.TreeView1, e.Location)

        End If

        Me.ResetTimer()

    End Sub

    Private Sub TreeView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TreeView1.KeyUp
        If e.KeyValue = 46 Then Me.DeleteNode()
        Me.ResetTimer()
    End Sub

    Friend Sub tsbLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbLogin.Click

        If Me._user.IsLoggedIn Then
            Me.DoLogOut()
        Else

            Me.ToolStripStatusLabel1.Text = "Ready"

            If Me._frmLogin IsNot Nothing AndAlso Not Me._frmLogin.IsDisposed Then
                Me._frmLogin.Focus()
            ElseIf Me._frmReg IsNot Nothing AndAlso Not Me._frmReg.IsDisposed Then
                Me._frmReg.Focus()
            Else
                Me._frmLogin = New LogIn
                Me._frmLogin.Show()
                Me._frmLogin.Focus()
            End If

        End If

    End Sub

    Private Sub txtDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.TextChanged

        Me.btnCopyDescription.Enabled = (Me.txtDescription.Text <> "")

        Me.ResetTimer()

    End Sub

    Private Sub txtLoginId_TextChanged(sender As Object, e As EventArgs) Handles txtLoginId.TextChanged
        Me.btnCopyLoginId.Enabled = (Me.txtLoginId.Text <> "")
    End Sub

    Private Sub txtPwd_TextChanged(sender As Object, e As EventArgs) Handles txtPwd.TextChanged
        Me.btnCopyPassword.Enabled = (Me.txtPwd.Text <> "")
    End Sub

    Private Sub txtWebSite_TextChanged(sender As Object, e As EventArgs) Handles txtWebSite.TextChanged
        Me.btnCopyWebSite.Enabled = (Me.txtWebSite.Text <> "")
        Me.btnBrowseWebSite.Enabled = (Me.txtWebSite.Text.Trim <> "")
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked
        Me.ResetTimer()
    End Sub

    Private Sub tsbNewCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNewCategory.Click

        Dim frm As New Category(Me._user.RecordId)

        If frm.ShowDialog() = GF.DialogResult.OK Then

            Dim myNode As New TreeNode(frm.CategoryName)
            myNode.Tag = frm.CategoryId

            Me.TreeView1.Nodes.Add(myNode)

        End If

        frm.Dispose()

    End Sub

    Private Sub tsbEditUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditUser.Click

        Dim frm As New EditUser

        frm.ShowDialog()

        If frm.UserDeleted Then
            Me.DoLogOut()
        Else
            Me.Text = "Passwords [" & Me._user.UserName & "]"
        End If

        frm.Dispose()
        frm = Nothing

    End Sub

    Private Sub tsbBackup_Click(sender As Object, e As EventArgs) Handles tsbBackup.Click

        Dim frm As New Backup

        frm.ShowDialog()

        frm.Dispose()
        frm = Nothing

        Me.ResetTimer()

    End Sub

    Friend Sub tsbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefresh.Click
        Me.ClearTextBoxes()
        Me.PopulateData()
    End Sub

    Private Sub tsbNewRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNewRecord.Click

        Dim frm As New NewRecord(Me._user.RecordId)

        If frm.ShowDialog = GF.DialogResult.Save Then

            Dim myData As PasswordData = frm.Data
            Dim node As New TreeNode(myData.Description, 2, 2)

            node.Tag = myData.RecordId

            For Each n As TreeNode In Me.TreeView1.Nodes
                If CInt(n.Tag) = myData.Category Then
                    n.Nodes.Add(node)
                    Exit For
                End If
            Next

            Me._dataCol.Add(myData)

            Me.TreeView1.SelectedNode = node

        End If

        frm.Dispose()
        frm = Nothing

    End Sub

    Private Sub tsbAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAbout.Click

        Dim frm As New About

        frm.ShowDialog()

        frm.Dispose()
        frm = Nothing

        Me.ResetTimer()

    End Sub

    Private Sub tsmiEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiEdit.Click

        Dim selNode As TreeNode = Me.TreeView1.SelectedNode

        If selNode.Level = 0 Then

            Dim frm As New Category(Me._user.RecordId, selNode.Text, CInt(selNode.Tag))

            If frm.ShowDialog() = GF.DialogResult.OK Then

                selNode.Text = frm.CategoryName

            End If

            frm.Dispose()
            frm = Nothing

        Else

            Dim myData As PasswordData = Me._dataCol.GetRecord(CInt(selNode.Tag))
            Dim frm As New NewRecord(Me._user.RecordId, True, myData)

            If frm.ShowDialog = GF.DialogResult.Save Then

                selNode.Text = myData.Description
                Me.txtDescription.Text = myData.Description
                Me.txtLoginId.Text = myData.LoginId
                Me.txtPwd.Text = myData.Password
                Me.txtWebSite.Text = myData.WebSite
                Me.txtNotes.Text = myData.Notes

                ' move node to new category
                If CInt(selNode.Parent.Tag) <> myData.Category Then

                    Me.TreeView1.Nodes.Remove(selNode)

                    For Each n As TreeNode In Me.TreeView1.Nodes
                        If CInt(n.Tag) = myData.Category Then
                            n.Nodes.Add(selNode)
                            Exit For
                        End If
                    Next

                    Me.TreeView1.SelectedNode = selNode

                End If

            End If

            frm.Dispose()
            frm = Nothing

        End If

    End Sub

    Private Sub tsmiDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiDelete.Click
        Me.DeleteNode()
    End Sub

    Private Sub btnCopyDescription_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyDescription.Click
        Clipboard.SetText(Me.txtDescription.Text)
        Me.ToolStripStatusLabel1.Text = "Description copied to clipboard"
        Me.ResetTimer()
    End Sub

    Private Sub btnCopyLoginId_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyLoginId.Click
        Clipboard.SetText(Me.txtLoginId.Text)
        Me.ToolStripStatusLabel1.Text = "Login Id copied to clipboard"
        Me.ResetTimer()
    End Sub

    Private Sub btnCopyPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyPassword.Click
        Clipboard.SetText(Me.txtPwd.Text)
        Me.ToolStripStatusLabel1.Text = "Password copied to clipboard"
        Me.ResetTimer()
    End Sub

    Private Sub btnCopyWebSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyWebSite.Click
        Clipboard.SetText(Me.txtWebSite.Text)
        Me.ToolStripStatusLabel1.Text = "Web Site copied to clipboard"
        Me.ResetTimer()
    End Sub

    Private Sub btnBrowseWebSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseWebSite.Click

        Try
            System.Diagnostics.Process.Start("C:\Program Files\Internet Explorer\iexplore.exe", Me.txtWebSite.Text)
        Catch ex As Exception
            MessageBox.Show("Unable to open web site." & vbCrLf & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.ToolStripStatusLabel1.Text = "Done"

        Me.ResetTimer()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        
        If Me._user.IsLoggedIn Then
            Me.ShutDown()
        Else
            Me.Timer1.Stop()
        End If

    End Sub

#End Region ' Form Events

#Region "Methods & Properties"

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)

        Dim val1 As Integer = Me.GroupBox1.Width - 42

        If val1 > 33 Then

            Me.btnCopyDescription.Location = New Point(val1 + 12, 17)
            Me.txtDescription.Width = val1

            Me.btnCopyLoginId.Location = New Point(val1 + 12, 17)
            Me.txtLoginId.Width = val1

            Me.btnCopyPassword.Location = New Point(val1 + 12, 17)
            Me.txtPwd.Width = val1

            Me.btnBrowseWebSite.Location = New Point(val1 + 12, 17)
            Me.btnCopyWebSite.Location = New Point(val1 - 18, 17)
            Me.txtWebSite.Width = val1 - 30

        End If

    End Sub

    Private Sub LoadInitialSettings()

        Me.Icon = Drawing.Icon.FromHandle(My.Resources.key2.GetHicon)

        Me.Width = CInt(GetSetting(My.Application.Info.AssemblyName, "Initial", "FormWidth", "650"))
        Me.Height = CInt(GetSetting(My.Application.Info.AssemblyName, "Initial", "FormHeight", "520"))
        Me.WindowState = CType(CInt(GetSetting(My.Application.Info.AssemblyName, "Initial", "WindowState", "0")), FormWindowState)

    End Sub

    Private Sub SaveAppSettings()

        Me.Cursor = Cursors.WaitCursor

        Dim w As Integer = Me.Width
        Dim h As Integer = Me.Height
        Dim ws As Integer = CInt(Me.WindowState)

        If ws = 0 Then

            If w < 450 Then w = 450
            If h < 350 Then h = 350

            SaveSetting(My.Application.Info.AssemblyName, "Initial", "FormWidth", w.ToString())
            SaveSetting(My.Application.Info.AssemblyName, "Initial", "FormHeight", h.ToString())

        End If

        If ws = 1 Then ws = 0

        SaveSetting(My.Application.Info.AssemblyName, "Initial", "WindowState", ws.ToString())

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ChangeControlState(ByVal Enable As Boolean)

        Me.Cursor = Cursors.WaitCursor

        Dim color As System.Drawing.Color = System.Drawing.SystemColors.Window

        If Not Enable Then

            color = System.Drawing.SystemColors.Control
            Me.TreeView1.Nodes.Clear()
            Me._dataCol.Clear()

            Me.ClearTextBoxes()

        End If

        Me.tsbNewCategory.Enabled = Enable
        Me.tsbNewRecord.Enabled = Enable
        Me.tsbRefresh.Enabled = Enable
        Me.tsbEditUser.Enabled = Enable
        ' Me.tsbDatabase.Enabled = Enable

        Me.txtDescription.Enabled = Enable
        Me.txtLoginId.Enabled = Enable
        Me.txtPwd.Enabled = Enable
        Me.txtPwd.Enabled = Enable
        Me.txtWebSite.Enabled = Enable
        Me.txtNotes.Enabled = Enable

        Me.txtDescription.BackColor = color
        Me.txtLoginId.BackColor = color
        Me.txtPwd.BackColor = color
        Me.txtPwd.BackColor = color
        Me.txtWebSite.BackColor = color
        Me.txtNotes.BackColor = color

        Me.Cursor = Cursors.Default

    End Sub

    Friend Sub DoLogOut()

        Me._user.DoLogOut()
        Me.Text = "Passwords 2.0"
        Me.tsbLogin.Text = "Log In"
        Me.tsbLogin.Image = My.Resources.lockpad4
        Me.ChangeControlState(False)

        Me._frmLogin = New LogIn
        Me._frmLogin.Show()
        Me._frmLogin.Focus()

        Me.ToolStripStatusLabel1.Text = "Logged Out"

    End Sub

    Friend Sub DoLogIn(ByVal result As GF.DialogResult)

        If result = GF.DialogResult.OK Then

            Me.Text = "Passwords 2.0 [" & Me._user.UserName & "]"
            Me.tsbLogin.Text = "Log Out"
            Me.tsbLogin.Image = My.Resources.lockpad3
            Me.ChangeControlState(True)
            Me.PopulateData()

        ElseIf result = GF.DialogResult.Register Then

            Me._frmReg = New NewUser
            Me._frmReg.Show(Me)

        End If

    End Sub

    Private Sub PopulateData()

        Me.ToolStripStatusLabel1.Text = "Retrieving Data..."
        Me.Cursor = Cursors.WaitCursor

        Try

            Dim myConn As New SqlClient.SqlConnection(GF.ConnectionString)
            Dim myCmd As New SqlClient.SqlCommand
            Dim myRd As SqlClient.SqlDataReader

            Me.TreeView1.Nodes.Clear()
            Me._dataCol.Clear()

            myConn.Open()

            myCmd.Connection = myConn
            myCmd.CommandText = "SELECT * FROM [Categories] WHERE [Owner] = " & Me._user.RecordId.ToString & " ORDER BY [Category]"

            myRd = myCmd.ExecuteReader()

            While myRd.Read

                Dim myNode As New TreeNode(myRd("Category").ToString, 0, 0)

                myNode.Tag = myRd("CategoryId")

                Me.TreeView1.Nodes.Add(myNode)

            End While

            myRd.Close()

            myCmd.CommandText = "SELECT * FROM [Passwords] WHERE [User] = " & Me._user.RecordId.ToString

            myRd = myCmd.ExecuteReader

            While myRd.Read

                Dim id As Integer = CInt(myRd("Id"))
                Dim dsc As String = Crypto.TripleDES.Decode(myRd("Description").ToString, GF.EncodingKey)
                Dim lg As String = Crypto.TripleDES.Decode(myRd("LoginId").ToString, GF.EncodingKey)
                Dim pw As String = Crypto.TripleDES.Decode(myRd("Password").ToString, GF.EncodingKey)
                Dim ws As String = ""
                Dim nt As String = ""
                Dim ct As Integer = CInt(myRd("CategoryId"))

                If Not IsDBNull(myRd("WebSite")) Then ws = Crypto.TripleDES.Decode(myRd("WebSite").ToString, GF.EncodingKey)
                If Not IsDBNull(myRd("Notes")) Then nt = Crypto.TripleDES.Decode(myRd("Notes").ToString, GF.EncodingKey)

                Dim pd As New PasswordData(id, dsc, lg, pw, ws, nt, ct)

                Me._dataCol.Add(pd)

                For Each n As TreeNode In Me.TreeView1.Nodes

                    If n.Level = 0 AndAlso CInt(n.Tag) = ct Then

                        Dim myNode As New TreeNode(dsc, 2, 2)

                        myNode.Tag = id

                        n.Nodes.Add(myNode)

                        Exit For

                    End If

                Next

            End While

            myRd.Close()

            If myConn.State = ConnectionState.Open Then myConn.Close()
            myConn.Dispose()
            myConn = Nothing

            myCmd.Dispose()
            myCmd = Nothing

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show("Unable to populate data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.SortTreeView()

        Me.Cursor = Cursors.Default
        Me.ToolStripStatusLabel1.Text = Me._dataCol.Count.ToString & " records"

    End Sub

    Private Sub ClearTextBoxes()

        Me.txtDescription.Text = String.Empty
        Me.txtLoginId.Text = String.Empty
        Me.txtPwd.Text = String.Empty
        Me.txtWebSite.Text = String.Empty
        Me.txtNotes.Text = String.Empty

    End Sub

    Private Sub DeleteNode()

        Dim selNode As TreeNode = Me.TreeView1.SelectedNode

        If selNode IsNot Nothing Then

            If selNode.Level = 0 Then
                ' category
                If selNode.Nodes.Count = 0 Then

                    If MessageBox.Show("The category """ & selNode.Text & """ will be permanently deleted." & vbCrLf & _
                        "Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = _
                        Windows.Forms.DialogResult.Yes Then

                        Dim myConn As New SqlClient.SqlConnection(GF.ConnectionString)
                        Dim myCmd As New SqlClient.SqlCommand

                        Try

                            myCmd.Connection = myConn
                            myCmd.CommandText = "DELETE FROM [Categories] WHERE [CategoryId] = " & selNode.Tag.ToString

                            myConn.Open()

                            myCmd.ExecuteNonQuery()

                            Me.TreeView1.Nodes.Remove(selNode)

                        Catch ex As Exception
                            MessageBox.Show("Unable to delete category: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        If myConn.State = ConnectionState.Open Then myConn.Close()
                        myConn.Dispose()
                        myConn = Nothing

                        myCmd.Dispose()
                        myCmd = Nothing

                    End If

                Else
                    MessageBox.Show("The selected category contains records and cannot be deleted.", "Cannot delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

            Else

                ' record
                If MessageBox.Show("The record """ & selNode.Text & """ will be permanently deleted." & vbCrLf & _
                    "Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then

                    Dim myConn As New SqlClient.SqlConnection(GF.ConnectionString)
                    Dim myCmd As New SqlClient.SqlCommand

                    Try

                        myCmd.Connection = myConn
                        myCmd.CommandText = "DELETE FROM [Passwords] WHERE [Id] = " & selNode.Tag.ToString

                        myConn.Open()

                        myCmd.ExecuteNonQuery()

                        Me.TreeView1.Nodes.Remove(selNode)

                    Catch ex As Exception
                        MessageBox.Show("Unable to delete record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    If myConn.State = ConnectionState.Open Then myConn.Close()
                    myConn.Dispose()
                    myConn = Nothing

                    myCmd.Dispose()
                    myCmd = Nothing

                End If

            End If

        End If

    End Sub

    Private Sub SetToolTip()

        Me._toolTip.SetToolTip(Me.btnCopyDescription, "Copy to Clipboard")
        Me._toolTip.SetToolTip(Me.btnCopyLoginId, "Copy to Clipboard")
        Me._toolTip.SetToolTip(Me.btnCopyPassword, "Copy to Clipboard")
        Me._toolTip.SetToolTip(Me.btnCopyWebSite, "Copy to Clipboard")
        Me._toolTip.SetToolTip(Me.btnBrowseWebSite, "Browse Web Site")

    End Sub

    Private Sub CreateMoveToTSMI()

        Me.tsmiMoveTo.DropDownItems.Clear()

        Dim selNode As TreeNode = Me.TreeView1.SelectedNode
        Dim emptyflag As Boolean = True

        If selNode.Level > 0 Then

            For Each n As TreeNode In Me.TreeView1.Nodes

                If n IsNot selNode.Parent Then

                    Dim tsmi As New ToolStripMenuItem

                    tsmi.Text = n.Text
                    tsmi.Tag = n.Tag
                    tsmi.Image = My.Resources.folder

                    AddHandler tsmi.Click, AddressOf Me.tsmiMoveTo_Click

                    Me.tsmiMoveTo.DropDownItems.Add(tsmi)

                    emptyflag = False

                End If

            Next

        End If

        If emptyflag Then

            Dim EmptyTSMI As New ToolStripMenuItem("(Empty)")

            EmptyTSMI.Enabled = False

            Me.tsmiMoveTo.DropDownItems.Add(EmptyTSMI)

        End If

    End Sub

    Private Sub tsmiMoveTo_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim newCategory As Integer = CInt(DirectCast(sender, ToolStripMenuItem).Tag)
        Dim selNode As TreeNode = Me.TreeView1.SelectedNode
        Dim myConn As New SqlClient.SqlConnection(GF.ConnectionString)
        Dim mycmd As New SqlClient.SqlCommand
        Dim ErrMsg As String = ""
        Dim ErrFlag As Boolean = False

        mycmd.Connection = myConn
        mycmd.CommandText = "UPDATE [Passwords] SET [CategoryId] = " & newCategory.ToString & " WHERE [Id] = " & selNode.Tag.ToString

        Try

            myConn.Open()

            mycmd.ExecuteNonQuery()

        Catch ex As Exception
            ErrMsg = ex.Message
            ErrFlag = True
        End Try

        If myConn.State = ConnectionState.Open Then myConn.Close()
        myConn.Dispose()
        myConn = Nothing

        mycmd.Dispose()
        mycmd = Nothing

        If ErrFlag Then
            MessageBox.Show("Unable to move record. " & ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Me._dataCol.GetRecord(CInt(selNode.Tag)).Category = newCategory

        Me.TreeView1.Nodes.Remove(selNode)

        For Each n As TreeNode In Me.TreeView1.Nodes
            If CInt(n.Tag) = newCategory Then
                n.Nodes.Add(selNode)
                Exit For
            End If
        Next

        Me.TreeView1.SelectedNode = selNode

    End Sub

    Private Sub SortTreeView()

        For Each n As TreeNode In Me.TreeView1.Nodes

            For i As Integer = 0 To n.Nodes.Count - 2

                For j As Integer = i + 1 To n.Nodes.Count - 1

                    If String.Compare(n.Nodes(i).Text, n.Nodes(j).Text) = 1 Then

                        Dim tmpTxt As String = n.Nodes(i).Text
                        Dim tmpTag As Object = n.Nodes(i).Tag

                        n.Nodes(i).Text = n.Nodes(j).Text
                        n.Nodes(i).Tag = n.Nodes(j).Tag

                        n.Nodes(j).Text = tmpTxt
                        n.Nodes(j).Tag = tmpTag

                    End If

                Next j

            Next i

        Next n

    End Sub

    Public Sub ResetTimer()

        Me.Timer1.Stop()
        Me.Timer1.Start()

    End Sub

    Private Sub ShutDown()

        Dim frm As New AutoLogOut

        Me.Timer1.Stop()

        Dim DiaRes As GF.DialogResult = frm.ShowDialog()

        frm.Close()
        frm.Dispose()

        If DiaRes = GF.DialogResult.Logout Then

            For Each f As Form In My.Application.OpenForms

                If Not TypeOf f Is Form1 Then f.Close()

            Next

            Me.DoLogOut()

        Else

            Me.ResetTimer()

        End If

    End Sub

#End Region ' Methods & Properties

End Class
