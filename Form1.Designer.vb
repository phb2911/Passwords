<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbNewCategory = New System.Windows.Forms.ToolStripButton()
        Me.tsbNewRecord = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbRefresh = New System.Windows.Forms.ToolStripButton()
        Me.tsbBackup = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditUser = New System.Windows.Forms.ToolStripButton()
        Me.tsbAbout = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbLogin = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnCopyDescription = New System.Windows.Forms.Button()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnCopyLoginId = New System.Windows.Forms.Button()
        Me.txtLoginId = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnCopyPassword = New System.Windows.Forms.Button()
        Me.txtPwd = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnCopyWebSite = New System.Windows.Forms.Button()
        Me.btnBrowseWebSite = New System.Windows.Forms.Button()
        Me.txtWebSite = New System.Windows.Forms.TextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmiMoveTo = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.HideSelection = False
        Me.TreeView1.HotTracking = True
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.Location = New System.Drawing.Point(10, 10)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(171, 418)
        Me.TreeView1.TabIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "folder.ico")
        Me.ImageList1.Images.SetKeyName(1, "folder2.ico")
        Me.ImageList1.Images.SetKeyName(2, "key0.ico")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNewCategory, Me.tsbNewRecord, Me.ToolStripSeparator1, Me.tsbRefresh, Me.tsbBackup, Me.tsbEditUser, Me.tsbAbout, Me.ToolStripSeparator2, Me.tsbLogin})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(640, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbNewCategory
        '
        Me.tsbNewCategory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNewCategory.Image = Global.Password2.My.Resources.Resources.folder
        Me.tsbNewCategory.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNewCategory.Name = "tsbNewCategory"
        Me.tsbNewCategory.Size = New System.Drawing.Size(23, 22)
        Me.tsbNewCategory.Text = "New Category"
        '
        'tsbNewRecord
        '
        Me.tsbNewRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNewRecord.Image = Global.Password2.My.Resources.Resources.key2
        Me.tsbNewRecord.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNewRecord.Name = "tsbNewRecord"
        Me.tsbNewRecord.Size = New System.Drawing.Size(23, 22)
        Me.tsbNewRecord.Text = "New Record"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbRefresh
        '
        Me.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRefresh.Image = Global.Password2.My.Resources.Resources.refresh2
        Me.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefresh.Name = "tsbRefresh"
        Me.tsbRefresh.Size = New System.Drawing.Size(23, 22)
        Me.tsbRefresh.Text = "Refresh"
        '
        'tsbBackup
        '
        Me.tsbBackup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbBackup.Enabled = False
        Me.tsbBackup.Image = Global.Password2.My.Resources.Resources.database_key
        Me.tsbBackup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbBackup.Name = "tsbBackup"
        Me.tsbBackup.Size = New System.Drawing.Size(23, 22)
        Me.tsbBackup.Text = "Backup"
        '
        'tsbEditUser
        '
        Me.tsbEditUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbEditUser.Image = Global.Password2.My.Resources.Resources.user2
        Me.tsbEditUser.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditUser.Name = "tsbEditUser"
        Me.tsbEditUser.Size = New System.Drawing.Size(23, 22)
        Me.tsbEditUser.Text = "Edit User"
        '
        'tsbAbout
        '
        Me.tsbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAbout.Image = Global.Password2.My.Resources.Resources.info
        Me.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAbout.Name = "tsbAbout"
        Me.tsbAbout.Size = New System.Drawing.Size(23, 22)
        Me.tsbAbout.Text = "About"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbLogin
        '
        Me.tsbLogin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbLogin.Image = Global.Password2.My.Resources.Resources.lockpad4
        Me.tsbLogin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLogin.Name = "tsbLogin"
        Me.tsbLogin.Size = New System.Drawing.Size(23, 22)
        Me.tsbLogin.Text = "Log in"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TreeView1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel1.Size = New System.Drawing.Size(191, 438)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(191, 25)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(8)
        Me.Panel2.Size = New System.Drawing.Size(449, 65)
        Me.Panel2.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCopyDescription)
        Me.GroupBox1.Controls.Add(Me.txtDescription)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(433, 49)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Description"
        '
        'btnCopyDescription
        '
        Me.btnCopyDescription.Enabled = False
        Me.btnCopyDescription.Image = Global.Password2.My.Resources.Resources.clipboard
        Me.btnCopyDescription.Location = New System.Drawing.Point(403, 17)
        Me.btnCopyDescription.Name = "btnCopyDescription"
        Me.btnCopyDescription.Size = New System.Drawing.Size(24, 23)
        Me.btnCopyDescription.TabIndex = 1
        Me.btnCopyDescription.UseVisualStyleBackColor = True
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescription.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDescription.Location = New System.Drawing.Point(6, 19)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(391, 20)
        Me.txtDescription.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(191, 90)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(8)
        Me.Panel3.Size = New System.Drawing.Size(449, 65)
        Me.Panel3.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnCopyLoginId)
        Me.GroupBox2.Controls.Add(Me.txtLoginId)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(433, 49)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Login Id"
        '
        'btnCopyLoginId
        '
        Me.btnCopyLoginId.Enabled = False
        Me.btnCopyLoginId.Image = Global.Password2.My.Resources.Resources.clipboard
        Me.btnCopyLoginId.Location = New System.Drawing.Point(403, 17)
        Me.btnCopyLoginId.Name = "btnCopyLoginId"
        Me.btnCopyLoginId.Size = New System.Drawing.Size(24, 23)
        Me.btnCopyLoginId.TabIndex = 3
        Me.btnCopyLoginId.UseVisualStyleBackColor = True
        '
        'txtLoginId
        '
        Me.txtLoginId.BackColor = System.Drawing.SystemColors.Window
        Me.txtLoginId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLoginId.Location = New System.Drawing.Point(6, 19)
        Me.txtLoginId.Name = "txtLoginId"
        Me.txtLoginId.ReadOnly = True
        Me.txtLoginId.Size = New System.Drawing.Size(391, 20)
        Me.txtLoginId.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GroupBox3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(191, 155)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(8)
        Me.Panel4.Size = New System.Drawing.Size(449, 65)
        Me.Panel4.TabIndex = 5
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnCopyPassword)
        Me.GroupBox3.Controls.Add(Me.txtPwd)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(433, 49)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Password"
        '
        'btnCopyPassword
        '
        Me.btnCopyPassword.Enabled = False
        Me.btnCopyPassword.Image = Global.Password2.My.Resources.Resources.clipboard
        Me.btnCopyPassword.Location = New System.Drawing.Point(403, 17)
        Me.btnCopyPassword.Name = "btnCopyPassword"
        Me.btnCopyPassword.Size = New System.Drawing.Size(24, 23)
        Me.btnCopyPassword.TabIndex = 3
        Me.btnCopyPassword.UseVisualStyleBackColor = True
        '
        'txtPwd
        '
        Me.txtPwd.BackColor = System.Drawing.SystemColors.Window
        Me.txtPwd.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPwd.Location = New System.Drawing.Point(6, 19)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.ReadOnly = True
        Me.txtPwd.Size = New System.Drawing.Size(391, 20)
        Me.txtPwd.TabIndex = 2
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.GroupBox4)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(191, 220)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(8)
        Me.Panel5.Size = New System.Drawing.Size(449, 65)
        Me.Panel5.TabIndex = 6
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnCopyWebSite)
        Me.GroupBox4.Controls.Add(Me.btnBrowseWebSite)
        Me.GroupBox4.Controls.Add(Me.txtWebSite)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(433, 49)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Web Site"
        '
        'btnCopyWebSite
        '
        Me.btnCopyWebSite.Enabled = False
        Me.btnCopyWebSite.Image = Global.Password2.My.Resources.Resources.clipboard
        Me.btnCopyWebSite.Location = New System.Drawing.Point(373, 17)
        Me.btnCopyWebSite.Name = "btnCopyWebSite"
        Me.btnCopyWebSite.Size = New System.Drawing.Size(24, 23)
        Me.btnCopyWebSite.TabIndex = 3
        Me.btnCopyWebSite.UseVisualStyleBackColor = True
        '
        'btnBrowseWebSite
        '
        Me.btnBrowseWebSite.Enabled = False
        Me.btnBrowseWebSite.Image = Global.Password2.My.Resources.Resources.browse
        Me.btnBrowseWebSite.Location = New System.Drawing.Point(403, 17)
        Me.btnBrowseWebSite.Name = "btnBrowseWebSite"
        Me.btnBrowseWebSite.Size = New System.Drawing.Size(24, 23)
        Me.btnBrowseWebSite.TabIndex = 4
        Me.btnBrowseWebSite.UseVisualStyleBackColor = True
        '
        'txtWebSite
        '
        Me.txtWebSite.BackColor = System.Drawing.SystemColors.Window
        Me.txtWebSite.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtWebSite.Location = New System.Drawing.Point(6, 19)
        Me.txtWebSite.Name = "txtWebSite"
        Me.txtWebSite.ReadOnly = True
        Me.txtWebSite.Size = New System.Drawing.Size(361, 20)
        Me.txtWebSite.TabIndex = 2
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.GroupBox5)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(191, 285)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(8)
        Me.Panel6.Size = New System.Drawing.Size(449, 178)
        Me.Panel6.TabIndex = 7
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtNotes)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(6, 10, 6, 10)
        Me.GroupBox5.Size = New System.Drawing.Size(433, 162)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Notes"
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.SystemColors.Window
        Me.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNotes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNotes.Location = New System.Drawing.Point(6, 23)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ReadOnly = True
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(421, 129)
        Me.txtNotes.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 463)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(640, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(121, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiEdit, Me.tsmiDelete, Me.ToolStripSeparator3, Me.tsmiMoveTo})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(122, 76)
        '
        'tsmiEdit
        '
        Me.tsmiEdit.Image = Global.Password2.My.Resources.Resources.edit
        Me.tsmiEdit.Name = "tsmiEdit"
        Me.tsmiEdit.Size = New System.Drawing.Size(121, 22)
        Me.tsmiEdit.Text = "Edit"
        '
        'tsmiDelete
        '
        Me.tsmiDelete.Image = Global.Password2.My.Resources.Resources.close
        Me.tsmiDelete.Name = "tsmiDelete"
        Me.tsmiDelete.Size = New System.Drawing.Size(121, 22)
        Me.tsmiDelete.Text = "Delete"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(118, 6)
        '
        'tsmiMoveTo
        '
        Me.tsmiMoveTo.Name = "tsmiMoveTo"
        Me.tsmiMoveTo.Size = New System.Drawing.Size(121, 22)
        Me.tsmiMoveTo.Text = "Move To"
        '
        'Timer1
        '
        Me.Timer1.Interval = 480000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(640, 485)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "Form1"
        Me.Text = "Passwords 2.0"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents btnCopyDescription As System.Windows.Forms.Button
    Friend WithEvents btnCopyLoginId As System.Windows.Forms.Button
    Friend WithEvents txtLoginId As System.Windows.Forms.TextBox
    Friend WithEvents btnCopyPassword As System.Windows.Forms.Button
    Friend WithEvents txtPwd As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowseWebSite As System.Windows.Forms.Button
    Friend WithEvents txtWebSite As System.Windows.Forms.TextBox
    Friend WithEvents btnCopyWebSite As System.Windows.Forms.Button
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents tsbNewRecord As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbEditUser As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbLogin As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbNewCategory As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmiMoveTo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsbAbout As System.Windows.Forms.ToolStripButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents tsbBackup As System.Windows.Forms.ToolStripButton

End Class
