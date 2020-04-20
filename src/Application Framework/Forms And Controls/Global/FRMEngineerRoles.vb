Imports FSM.Entity.Sys
Imports FSM.Entity.Settings.Scheduler
Imports System.Collections.Generic
Imports System.Linq
Imports System.Reflection
Imports FSM.Entity.EngineerRoles
Imports FSM.Entity.Engineers

Public Class FRMEngineerRole : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    Friend WithEvents btnClose As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents tabEngineerRole As TabControl
    Friend WithEvents tabPageNewRole As TabPage
    Friend WithEvents grpEngineerRole As GroupBox
    Friend WithEvents nudHourlyCostToCompany As NumericUpDown
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents lblName As Label
    Friend WithEvents lblHourlyCostToCompany As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents grpAssignEngineerRole As GroupBox
    Friend WithEvents dgrdEngineerInRoleList As DataGrid
    Friend WithEvents btnAssign As Button
    Friend WithEvents cboEngineerRole As ComboBox
    Friend WithEvents lblEngRole As Label
    Friend WithEvents lblEngineer As Label
    Friend WithEvents txtRoleId As TextBox
    Friend WithEvents txtEngineerName As TextBox
    Friend WithEvents txtEngineerId As TextBox
    Friend WithEvents grpEngRoles As GroupBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents dgrdEngineerRoles As DataGrid
    Friend WithEvents grpEngineersAssignedToRole As GroupBox
    Friend WithEvents btnUnassign As Button
    Friend WithEvents txtHourlyCostToCompany As TextBox
    Friend WithEvents btnfindEngineer As Button
    Friend WithEvents txtEngineer As TextBox
    Friend WithEvents tabPageAssignRole As TabPage

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRMEngineerRole))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tabEngineerRole = New System.Windows.Forms.TabControl()
        Me.tabPageNewRole = New System.Windows.Forms.TabPage()
        Me.grpEngineerRole = New System.Windows.Forms.GroupBox()
        Me.txtHourlyCostToCompany = New System.Windows.Forms.TextBox()
        Me.grpEngRoles = New System.Windows.Forms.GroupBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.dgrdEngineerRoles = New System.Windows.Forms.DataGrid()
        Me.txtRoleId = New System.Windows.Forms.TextBox()
        Me.nudHourlyCostToCompany = New System.Windows.Forms.NumericUpDown()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblHourlyCostToCompany = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.tabPageAssignRole = New System.Windows.Forms.TabPage()
        Me.grpAssignEngineerRole = New System.Windows.Forms.GroupBox()
        Me.grpEngineersAssignedToRole = New System.Windows.Forms.GroupBox()
        Me.btnUnassign = New System.Windows.Forms.Button()
        Me.dgrdEngineerInRoleList = New System.Windows.Forms.DataGrid()
        Me.txtEngineerId = New System.Windows.Forms.TextBox()
        Me.txtEngineerName = New System.Windows.Forms.TextBox()
        Me.btnAssign = New System.Windows.Forms.Button()
        Me.cboEngineerRole = New System.Windows.Forms.ComboBox()
        Me.lblEngRole = New System.Windows.Forms.Label()
        Me.lblEngineer = New System.Windows.Forms.Label()
        Me.btnfindEngineer = New System.Windows.Forms.Button()
        Me.txtEngineer = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.tabEngineerRole.SuspendLayout()
        Me.tabPageNewRole.SuspendLayout()
        Me.grpEngineerRole.SuspendLayout()
        Me.grpEngRoles.SuspendLayout()
        CType(Me.dgrdEngineerRoles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudHourlyCostToCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPageAssignRole.SuspendLayout()
        Me.grpAssignEngineerRole.SuspendLayout()
        Me.grpEngineersAssignedToRole.SuspendLayout()
        CType(Me.dgrdEngineerInRoleList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(8, 10)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 28)
        Me.btnClose.TabIndex = 15
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 565)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1462, 50)
        Me.Panel1.TabIndex = 16
        '
        'tabEngineerRole
        '
        Me.tabEngineerRole.Controls.Add(Me.tabPageNewRole)
        Me.tabEngineerRole.Controls.Add(Me.tabPageAssignRole)
        Me.tabEngineerRole.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabEngineerRole.Location = New System.Drawing.Point(0, 0)
        Me.tabEngineerRole.Name = "tabEngineerRole"
        Me.tabEngineerRole.SelectedIndex = 0
        Me.tabEngineerRole.Size = New System.Drawing.Size(1462, 565)
        Me.tabEngineerRole.TabIndex = 17
        '
        'tabPageNewRole
        '
        Me.tabPageNewRole.Controls.Add(Me.grpEngineerRole)
        Me.tabPageNewRole.Location = New System.Drawing.Point(4, 22)
        Me.tabPageNewRole.Name = "tabPageNewRole"
        Me.tabPageNewRole.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageNewRole.Size = New System.Drawing.Size(1454, 539)
        Me.tabPageNewRole.TabIndex = 0
        Me.tabPageNewRole.Text = "New Engineer Role"
        Me.tabPageNewRole.UseVisualStyleBackColor = True
        '
        'grpEngineerRole
        '
        Me.grpEngineerRole.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpEngineerRole.Controls.Add(Me.txtHourlyCostToCompany)
        Me.grpEngineerRole.Controls.Add(Me.grpEngRoles)
        Me.grpEngineerRole.Controls.Add(Me.txtRoleId)
        Me.grpEngineerRole.Controls.Add(Me.nudHourlyCostToCompany)
        Me.grpEngineerRole.Controls.Add(Me.txtDescription)
        Me.grpEngineerRole.Controls.Add(Me.lblDescription)
        Me.grpEngineerRole.Controls.Add(Me.btnSave)
        Me.grpEngineerRole.Controls.Add(Me.lblName)
        Me.grpEngineerRole.Controls.Add(Me.lblHourlyCostToCompany)
        Me.grpEngineerRole.Controls.Add(Me.txtName)
        Me.grpEngineerRole.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpEngineerRole.Location = New System.Drawing.Point(16, 21)
        Me.grpEngineerRole.Name = "grpEngineerRole"
        Me.grpEngineerRole.Size = New System.Drawing.Size(1430, 512)
        Me.grpEngineerRole.TabIndex = 13
        Me.grpEngineerRole.TabStop = False
        Me.grpEngineerRole.Text = "Enter New Role Details"
        '
        'txtHourlyCostToCompany
        '
        Me.txtHourlyCostToCompany.Location = New System.Drawing.Point(96, 56)
        Me.txtHourlyCostToCompany.Name = "txtHourlyCostToCompany"
        Me.txtHourlyCostToCompany.Size = New System.Drawing.Size(100, 21)
        Me.txtHourlyCostToCompany.TabIndex = 20
        '
        'grpEngRoles
        '
        Me.grpEngRoles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpEngRoles.Controls.Add(Me.btnDelete)
        Me.grpEngRoles.Controls.Add(Me.btnAddNew)
        Me.grpEngRoles.Controls.Add(Me.dgrdEngineerRoles)
        Me.grpEngRoles.Location = New System.Drawing.Point(96, 180)
        Me.grpEngRoles.Name = "grpEngRoles"
        Me.grpEngRoles.Size = New System.Drawing.Size(1316, 309)
        Me.grpEngRoles.TabIndex = 19
        Me.grpEngRoles.TabStop = False
        Me.grpEngRoles.Text = "Engineer Roles"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(1221, 280)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 21
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddNew.Location = New System.Drawing.Point(1140, 280)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddNew.TabIndex = 20
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'dgrdEngineerRoles
        '
        Me.dgrdEngineerRoles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgrdEngineerRoles.DataMember = ""
        Me.dgrdEngineerRoles.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgrdEngineerRoles.Location = New System.Drawing.Point(18, 20)
        Me.dgrdEngineerRoles.Name = "dgrdEngineerRoles"
        Me.dgrdEngineerRoles.Size = New System.Drawing.Size(1277, 254)
        Me.dgrdEngineerRoles.TabIndex = 19
        '
        'txtRoleId
        '
        Me.txtRoleId.Location = New System.Drawing.Point(96, 151)
        Me.txtRoleId.Name = "txtRoleId"
        Me.txtRoleId.Size = New System.Drawing.Size(68, 21)
        Me.txtRoleId.TabIndex = 16
        Me.txtRoleId.Visible = False
        '
        'nudHourlyCostToCompany
        '
        Me.nudHourlyCostToCompany.DecimalPlaces = 2
        Me.nudHourlyCostToCompany.Location = New System.Drawing.Point(215, 56)
        Me.nudHourlyCostToCompany.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.nudHourlyCostToCompany.Name = "nudHourlyCostToCompany"
        Me.nudHourlyCostToCompany.Size = New System.Drawing.Size(120, 21)
        Me.nudHourlyCostToCompany.TabIndex = 6
        Me.nudHourlyCostToCompany.Visible = False
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(96, 83)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(1316, 62)
        Me.txtDescription.TabIndex = 5
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(13, 92)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(71, 13)
        Me.lblDescription.TabIndex = 4
        Me.lblDescription.Text = "Description"
        '
        'btnSave
        '
        Me.btnSave.AccessibleDescription = ""
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.Location = New System.Drawing.Point(1356, 151)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(56, 23)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(13, 32)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(80, 16)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "Role Name"
        '
        'lblHourlyCostToCompany
        '
        Me.lblHourlyCostToCompany.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHourlyCostToCompany.Location = New System.Drawing.Point(13, 56)
        Me.lblHourlyCostToCompany.Name = "lblHourlyCostToCompany"
        Me.lblHourlyCostToCompany.Size = New System.Drawing.Size(80, 29)
        Me.lblHourlyCostToCompany.TabIndex = 2
        Me.lblHourlyCostToCompany.Text = "Hourly Cost To Company"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(96, 29)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(1316, 21)
        Me.txtName.TabIndex = 1
        '
        'tabPageAssignRole
        '
        Me.tabPageAssignRole.Controls.Add(Me.grpAssignEngineerRole)
        Me.tabPageAssignRole.Location = New System.Drawing.Point(4, 22)
        Me.tabPageAssignRole.Name = "tabPageAssignRole"
        Me.tabPageAssignRole.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageAssignRole.Size = New System.Drawing.Size(1454, 539)
        Me.tabPageAssignRole.TabIndex = 1
        Me.tabPageAssignRole.Text = "Assign Engineer Role"
        Me.tabPageAssignRole.UseVisualStyleBackColor = True
        '
        'grpAssignEngineerRole
        '
        Me.grpAssignEngineerRole.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAssignEngineerRole.BackColor = System.Drawing.Color.White
        Me.grpAssignEngineerRole.Controls.Add(Me.btnfindEngineer)
        Me.grpAssignEngineerRole.Controls.Add(Me.txtEngineer)
        Me.grpAssignEngineerRole.Controls.Add(Me.grpEngineersAssignedToRole)
        Me.grpAssignEngineerRole.Controls.Add(Me.txtEngineerId)
        Me.grpAssignEngineerRole.Controls.Add(Me.txtEngineerName)
        Me.grpAssignEngineerRole.Controls.Add(Me.btnAssign)
        Me.grpAssignEngineerRole.Controls.Add(Me.cboEngineerRole)
        Me.grpAssignEngineerRole.Controls.Add(Me.lblEngRole)
        Me.grpAssignEngineerRole.Controls.Add(Me.lblEngineer)
        Me.grpAssignEngineerRole.Location = New System.Drawing.Point(17, 23)
        Me.grpAssignEngineerRole.Name = "grpAssignEngineerRole"
        Me.grpAssignEngineerRole.Size = New System.Drawing.Size(1421, 510)
        Me.grpAssignEngineerRole.TabIndex = 15
        Me.grpAssignEngineerRole.TabStop = False
        Me.grpAssignEngineerRole.Text = "Assign Engineer Role"
        '
        'grpEngineersAssignedToRole
        '
        Me.grpEngineersAssignedToRole.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpEngineersAssignedToRole.Controls.Add(Me.btnUnassign)
        Me.grpEngineersAssignedToRole.Controls.Add(Me.dgrdEngineerInRoleList)
        Me.grpEngineersAssignedToRole.Location = New System.Drawing.Point(113, 112)
        Me.grpEngineersAssignedToRole.Name = "grpEngineersAssignedToRole"
        Me.grpEngineersAssignedToRole.Size = New System.Drawing.Size(1281, 377)
        Me.grpEngineersAssignedToRole.TabIndex = 78
        Me.grpEngineersAssignedToRole.TabStop = False
        Me.grpEngineersAssignedToRole.Text = "Engineers Assigned To Role"
        '
        'btnUnassign
        '
        Me.btnUnassign.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUnassign.Location = New System.Drawing.Point(1200, 348)
        Me.btnUnassign.Name = "btnUnassign"
        Me.btnUnassign.Size = New System.Drawing.Size(75, 23)
        Me.btnUnassign.TabIndex = 76
        Me.btnUnassign.Text = "Unassign"
        Me.btnUnassign.UseVisualStyleBackColor = True
        '
        'dgrdEngineerInRoleList
        '
        Me.dgrdEngineerInRoleList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgrdEngineerInRoleList.DataMember = ""
        Me.dgrdEngineerInRoleList.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgrdEngineerInRoleList.Location = New System.Drawing.Point(11, 29)
        Me.dgrdEngineerInRoleList.Name = "dgrdEngineerInRoleList"
        Me.dgrdEngineerInRoleList.Size = New System.Drawing.Size(1264, 313)
        Me.dgrdEngineerInRoleList.TabIndex = 75
        '
        'txtEngineerId
        '
        Me.txtEngineerId.Location = New System.Drawing.Point(113, 83)
        Me.txtEngineerId.Name = "txtEngineerId"
        Me.txtEngineerId.Size = New System.Drawing.Size(100, 21)
        Me.txtEngineerId.TabIndex = 77
        Me.txtEngineerId.Visible = False
        '
        'txtEngineerName
        '
        Me.txtEngineerName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEngineerName.Location = New System.Drawing.Point(228, 83)
        Me.txtEngineerName.Name = "txtEngineerName"
        Me.txtEngineerName.Size = New System.Drawing.Size(100, 21)
        Me.txtEngineerName.TabIndex = 76
        Me.txtEngineerName.Text = "--Please Select--"
        Me.txtEngineerName.Visible = False
        '
        'btnAssign
        '
        Me.btnAssign.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAssign.Location = New System.Drawing.Point(1319, 83)
        Me.btnAssign.Name = "btnAssign"
        Me.btnAssign.Size = New System.Drawing.Size(75, 23)
        Me.btnAssign.TabIndex = 74
        Me.btnAssign.Text = "Assign"
        Me.btnAssign.UseVisualStyleBackColor = True
        '
        'cboEngineerRole
        '
        Me.cboEngineerRole.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboEngineerRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEngineerRole.FormattingEnabled = True
        Me.cboEngineerRole.Location = New System.Drawing.Point(113, 56)
        Me.cboEngineerRole.Name = "cboEngineerRole"
        Me.cboEngineerRole.Size = New System.Drawing.Size(1281, 21)
        Me.cboEngineerRole.TabIndex = 73
        '
        'lblEngRole
        '
        Me.lblEngRole.AutoSize = True
        Me.lblEngRole.Location = New System.Drawing.Point(21, 58)
        Me.lblEngRole.Name = "lblEngRole"
        Me.lblEngRole.Size = New System.Drawing.Size(86, 13)
        Me.lblEngRole.TabIndex = 72
        Me.lblEngRole.Text = "Engineer Role"
        '
        'lblEngineer
        '
        Me.lblEngineer.AutoSize = True
        Me.lblEngineer.Location = New System.Drawing.Point(21, 35)
        Me.lblEngineer.Name = "lblEngineer"
        Me.lblEngineer.Size = New System.Drawing.Size(57, 13)
        Me.lblEngineer.TabIndex = 71
        Me.lblEngineer.Text = "Engineer"
        '
        'btnfindEngineer
        '
        Me.btnfindEngineer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnfindEngineer.BackColor = System.Drawing.Color.White
        Me.btnfindEngineer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfindEngineer.Location = New System.Drawing.Point(1362, 29)
        Me.btnfindEngineer.Name = "btnfindEngineer"
        Me.btnfindEngineer.Size = New System.Drawing.Size(32, 23)
        Me.btnfindEngineer.TabIndex = 80
        Me.btnfindEngineer.Text = "..."
        Me.btnfindEngineer.UseVisualStyleBackColor = False
        '
        'txtEngineer
        '
        Me.txtEngineer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEngineer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEngineer.Location = New System.Drawing.Point(113, 29)
        Me.txtEngineer.Name = "txtEngineer"
        Me.txtEngineer.ReadOnly = True
        Me.txtEngineer.Size = New System.Drawing.Size(1243, 21)
        Me.txtEngineer.TabIndex = 79
        '
        'FRMEngineerRole
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(1462, 615)
        Me.Controls.Add(Me.tabEngineerRole)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(0, 208)
        Me.Name = "FRMEngineerRole"
        Me.Text = "Engineer Roles"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.tabEngineerRole, 0)
        Me.Panel1.ResumeLayout(False)
        Me.tabEngineerRole.ResumeLayout(False)
        Me.tabPageNewRole.ResumeLayout(False)
        Me.grpEngineerRole.ResumeLayout(False)
        Me.grpEngineerRole.PerformLayout()
        Me.grpEngRoles.ResumeLayout(False)
        CType(Me.dgrdEngineerRoles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudHourlyCostToCompany, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPageAssignRole.ResumeLayout(False)
        Me.grpAssignEngineerRole.ResumeLayout(False)
        Me.grpAssignEngineerRole.PerformLayout()
        Me.grpEngineersAssignedToRole.ResumeLayout(False)
        CType(Me.dgrdEngineerInRoleList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Private Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
    End Sub

#End Region

#Region "Properties"

    Private _dvEngineerRole As DataView

    Private Property DvEngineerRole() As DataView
        Get
            Return _dvEngineerRole
        End Get
        Set(ByVal value As DataView)
            _dvEngineerRole = value
            _dvEngineerRole.Table.TableName = "EngineerRole"
            Me.dgrdEngineerRoles.DataSource = _dvEngineerRole
        End Set
    End Property

    Private _dvCurrentEngineerRoles As DataView

    Public Property CurrentEngineerRoles() As DataView
        Get
            Return _dvCurrentEngineerRoles
        End Get
        Set(ByVal value As DataView)
            _dvCurrentEngineerRoles = value
            _dvCurrentEngineerRoles.Table.TableName = "EngineerRole"
            _dvCurrentEngineerRoles.AllowNew = False
            _dvCurrentEngineerRoles.AllowEdit = False
            _dvCurrentEngineerRoles.AllowDelete = False
            Me.dgrdEngineerRoles.DataSource = CurrentEngineerRoles
        End Set
    End Property

    Private ReadOnly Property SelectedEngineeRoleDataRow() As DataRow
        Get
            If Not Me.dgrdEngineerRoles.CurrentRowIndex = -1 Then
                Return CurrentEngineerRoles(Me.dgrdEngineerRoles.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _dvEngineerInRoleList As DataView

    Private Property DvEngineerInRoleList() As DataView
        Get
            Return _dvEngineerInRoleList
        End Get
        Set(ByVal value As DataView)
            _dvEngineerInRoleList = value
            _dvEngineerInRoleList.Table.TableName = "EngineerInRoleList"
            Me.dgrdEngineerInRoleList.DataSource = _dvEngineerInRoleList
        End Set
    End Property

    Private _dvCurrentEngineerRoleLinks As DataView

    Public Property CurrentEngineerRoleLinks() As DataView
        Get
            Return _dvCurrentEngineerRoleLinks
        End Get
        Set(ByVal value As DataView)
            _dvCurrentEngineerRoleLinks = value
            _dvCurrentEngineerRoleLinks.Table.TableName = "EngineerInRoleList"
            _dvCurrentEngineerRoleLinks.AllowNew = False
            _dvCurrentEngineerRoleLinks.AllowEdit = False
            _dvCurrentEngineerRoleLinks.AllowDelete = False
            Me.dgrdEngineerInRoleList.DataSource = CurrentEngineerRoleLinks
        End Set
    End Property

    Private ReadOnly Property SelectedEngineerRoleLinkDataRow() As DataRow
        Get
            If Not Me.dgrdEngineerInRoleList.CurrentRowIndex = -1 Then
                Return CurrentEngineerRoleLinks(Me.dgrdEngineerInRoleList.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _engineer As Engineer

    Public Property Engineer() As Engineer
        Get
            Return _engineer
        End Get
        Set
            _engineer = Value
            If Not _engineer Is Nothing Then
                Me.txtEngineer.Text = Engineer.Name
            Else
                Me.txtEngineer.Text = "<Not Set>"
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub FRMEngineerRole_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LoadMe(sender, e)
        SetupDgrdEngineerRoles()
        PopulateEngineerRole()

        Me.SetupdgrdEngineerInRoleList()
        Me.PopulateEngineerInRoleList()

    End Sub

    Private Sub btnSave_Click_1(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim answer As DialogResult = ShowMessage("Are you sure you want to apply changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (answer = DialogResult.No) Then
            Exit Sub
        End If
        If (Me.txtRoleId.Text = String.Empty) Then
            Me.SaveEngineerRole()
        Else
            Me.UpdateEngineerRole()
        End If
        btnAddNew_Click(sender, e)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub dgrdEngineerRoles_Click(sender As Object, e As EventArgs) Handles dgrdEngineerRoles.Click
        If SelectedEngineeRoleDataRow Is Nothing Then
            Exit Sub
        End If
        Me.txtRoleId.Text = SelectedEngineeRoleDataRow.Item("Id")
        Me.txtName.Text = SelectedEngineeRoleDataRow.Item("Name")
        Me.txtHourlyCostToCompany.Text = SelectedEngineeRoleDataRow.Item("HourlyCostToCompany")
        Me.txtDescription.Text = SelectedEngineeRoleDataRow.Item("Description")
    End Sub

    Private Sub dgrdEngineerInRoleList_Click(sender As Object, e As EventArgs) Handles dgrdEngineerInRoleList.Click
        If SelectedEngineerRoleLinkDataRow Is Nothing Then
            Exit Sub
        End If
        '''' set comboboxes, cboEngineer & cboEngineerRole
        Dim engineerID As Integer = Helper.MakeIntegerValid(SelectedEngineerRoleLinkDataRow.Item("EngineerID"))
        Dim roleId As Integer = Helper.MakeIntegerValid(SelectedEngineerRoleLinkDataRow.Item("RoleId"))
        Dim engineerName As String = Helper.MakeStringValid(SelectedEngineerRoleLinkDataRow("EngineerName"))

        Dim dtEngineers As DataTable = DB.EngineerRole.GetEngineersNotAssignedToRole.Table

        Dim dtSelectedEngineer As New DataTable
        dtSelectedEngineer.Columns.Add(New DataColumn("EngineerID", GetType(Integer)))
        dtSelectedEngineer.Columns.Add(New DataColumn("Name", GetType(String)))
        dtSelectedEngineer.Rows.Add(engineerID, engineerName)
        dtEngineers.Merge(dtSelectedEngineer)

        Combo.SetSelectedComboItem_By_Value(cboEngineerRole, roleId)
        Engineer = DB.Engineer.Engineer_Get(engineerID)
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Me.txtRoleId.Text = ""
        Me.txtName.Text = ""
        Me.txtHourlyCostToCompany.Text = ""
        Me.txtDescription.Text = ""
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If SelectedEngineeRoleDataRow Is Nothing Then
            ShowMessage("Please select row to be deleted and try again.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim answer As DialogResult = ShowMessage("Are you sure you want to delete selected engineer role?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (answer = DialogResult.No) Then
            Exit Sub
        End If
        Try
            Dim engineerRoleId As Integer = Helper.MakeIntegerValid(SelectedEngineeRoleDataRow.Item("Id"))

            Dim success As Integer = DB.EngineerRole.Delete(engineerRoleId)
            If success > 0 Then
                Me.PopulateEngineerRole()
            Else
                ShowMessage("The role you are trying to delete is assigned to engineer(s) and therefore cannot be deleted.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Catch ex As Exception
            ShowMessage("The operation failed. Error: " & ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        Try
            If Engineer Is Nothing Then
                ShowMessage("Please select an engineer", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim engineerRoleId As Integer = Combo.GetSelectedItemValue(Me.cboEngineerRole)
            Dim newRoleName As String = Combo.GetSelectedItemDescription(cboEngineerRole)

            Dim engineerRole As EngineerRole = DB.EngineerRole.GetEngineerRoleId(Engineer.EngineerID)
            Dim changeRoleMessage As String
            If (newRoleName = String.Empty) Then
                changeRoleMessage = "Are you sure you want to change current role from " & engineerRole.Name & " to not assigned?"
            Else
                changeRoleMessage = "Are you sure you want to change current role from " & engineerRole.Name & " to " & newRoleName & " ?"
            End If
            If (engineerRole.Id > 0) Then
                Dim answer As DialogResult = ShowMessage(changeRoleMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (answer = DialogResult.No) Then
                    Exit Sub
                End If
            End If
            If (DB.EngineerRole.AssignEngineerToRole(Engineer.EngineerID, engineerRoleId)) Then
                PopulateEngineerInRoleList()
            Else
                ShowMessage("Assign role operation failed due to database issue. Please try again later.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            ShowMessage("Assign role operation failed. Error: " & ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUnassign_Click(sender As Object, e As EventArgs) Handles btnUnassign.Click
        Try
            If Engineer Is Nothing Then Exit Sub
            Dim engineerRoleId As Integer = 0
            Dim engineerRole As EngineerRole = DB.EngineerRole.GetEngineerRoleId(Engineer.EngineerID)
            Dim changeRoleMessage As String
            changeRoleMessage = "Are you sure you want to change current role from " & engineerRole.Name & " to not assigned?"
            Dim answer As DialogResult = ShowMessage(changeRoleMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (answer = DialogResult.No) Then
                Exit Sub
            End If
            If (DB.EngineerRole.AssignEngineerToRole(Engineer.EngineerID, engineerRoleId)) Then
                PopulateEngineerInRoleList()
            Else
                ShowMessage("Assign role operation failed due to database issue. Please try again later.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            ShowMessage("Unssign role operation failed. Error: " & ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtHourlyCostToCompany_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHourlyCostToCompany.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not e.KeyChar = "." AndAlso Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = ""
        End If
    End Sub

#End Region

#Region "Function"

    Private Sub PopulateEngineerRole()
        Dim dt As DataTable = Helper.ToDataTable(DB.EngineerRole.GetAll())
        Dim dv As New DataView(dt)
        DvEngineerRole = dv
        CurrentEngineerRoles = dv
    End Sub

    Private Sub PopulateEngineerInRoleList()
        Engineer = Nothing
        Combo.SetUpCombo(Me.cboEngineerRole, DB.EngineerRole.GetLookupData.Table, "Id", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        Dim dt As DataTable = Helper.ToDataTable(DB.EngineerRole.GetEngineersAssignedToRole())
        Dim dv As New DataView(dt)
        DvEngineerInRoleList = dv
        CurrentEngineerRoleLinks = dv
    End Sub

    Public Sub SaveEngineerRole()
        Try
            Dim engineerRole As New EngineerRole
            engineerRole.Name = Me.txtName.Text.Trim()
            engineerRole.HourlyCostToCompany = Helper.MakeDoubleValid(CDec(Val(Me.txtHourlyCostToCompany.Text)))
            engineerRole.Description = Me.txtDescription.Text.Trim()
            engineerRole = DB.EngineerRole.Insert(engineerRole)
            If (engineerRole.Id > 0) Then
                Me.PopulateEngineerRole()
                Me.PopulateEngineerInRoleList()
            Else
                ShowMessage("Role " & engineerRole.Name & " exists already. Please select role to edit.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Catch ex As Exception
            ShowMessage("The operation failed. Error: " & ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub UpdateEngineerRole()
        Try
            Dim engineerRole As New EngineerRole
            engineerRole.Id = Me.txtRoleId.Text.Trim()
            engineerRole.Name = Me.txtName.Text.Trim()
            engineerRole.HourlyCostToCompany = Helper.MakeDoubleValid(Me.txtHourlyCostToCompany.Text)
            engineerRole.Description = Me.txtDescription.Text.Trim()

            Dim success As Integer = DB.EngineerRole.Update(engineerRole)
            If (success = engineerRole.Id) Then
                Me.PopulateEngineerRole()
            Else
                ShowMessage("The operation failed. Please try again later!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Catch ex As Exception
            ShowMessage("The operation failed. Error: " & ex.Message.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Setup"

    Private Sub SetupDgrdEngineerRoles()
        Helper.SetUpDataGrid(Me.dgrdEngineerRoles)
        Dim dgts As DataGridTableStyle = Me.dgrdEngineerRoles.TableStyles(0)

        Dim roleId As New DataGridJobTypeColumn
        roleId.Format = ""
        roleId.FormatInfo = Nothing
        roleId.HeaderText = "Role Id"
        roleId.MappingName = "Id"
        roleId.ReadOnly = True
        roleId.Width = 0
        roleId.NullText = ""
        dgts.GridColumnStyles.Add(roleId)

        Dim roleName As New DataGridJobTypeColumn
        roleName.Format = ""
        roleName.FormatInfo = Nothing
        roleName.HeaderText = "Role Name"
        roleName.MappingName = "Name"
        roleName.ReadOnly = True
        roleName.Width = 300
        roleName.NullText = ""
        dgts.GridColumnStyles.Add(roleName)

        Dim rate As New DataGridJobTypeColumn
        rate.Format = "C"
        rate.FormatInfo = Nothing
        rate.HeaderText = "Hourly Cost To Company"
        rate.MappingName = "HourlyCostToCompany"
        rate.ReadOnly = True
        rate.Width = 150
        rate.NullText = ""
        dgts.GridColumnStyles.Add(rate)

        Dim description As New DataGridJobTypeColumn
        description.Format = ""
        description.FormatInfo = Nothing
        description.HeaderText = "Description"
        description.MappingName = "Description"
        description.ReadOnly = True
        description.Width = 600
        description.NullText = ""
        dgts.GridColumnStyles.Add(description)

        dgts.ReadOnly = True
        dgts.MappingName = "EngineerRole"
        Me.dgrdEngineerRoles.TableStyles.Add(dgts)

    End Sub

    Private Sub SetupdgrdEngineerInRoleList()
        Helper.SetUpDataGrid(Me.dgrdEngineerInRoleList)
        Dim dgts As DataGridTableStyle = Me.dgrdEngineerInRoleList.TableStyles(0)

        Dim engineerID As New DataGridJobTypeColumn
        engineerID.Format = ""
        engineerID.FormatInfo = Nothing
        engineerID.HeaderText = "Engineer ID"
        engineerID.MappingName = "EngineerID"
        engineerID.ReadOnly = True
        engineerID.Width = 1
        engineerID.NullText = ""
        dgts.GridColumnStyles.Add(engineerID)

        Dim roleId As New DataGridJobTypeColumn
        roleId.Format = ""
        roleId.FormatInfo = Nothing
        roleId.HeaderText = "Role Id"
        roleId.MappingName = "RoleId"
        roleId.ReadOnly = True
        roleId.Width = 1
        roleId.NullText = ""
        dgts.GridColumnStyles.Add(roleId)

        Dim engineerName As New DataGridJobTypeColumn
        engineerName.Format = ""
        engineerName.FormatInfo = Nothing
        engineerName.HeaderText = "Engineer Name"
        engineerName.MappingName = "EngineerName"
        engineerName.ReadOnly = True
        engineerName.Width = 160
        engineerName.NullText = ""
        dgts.GridColumnStyles.Add(engineerName)

        Dim engineerRole As New DataGridJobTypeColumn
        engineerRole.Format = ""
        engineerRole.FormatInfo = Nothing
        engineerRole.HeaderText = "Role Name"
        engineerRole.MappingName = "EngineerRole"
        engineerRole.ReadOnly = True
        engineerRole.Width = 160
        engineerRole.NullText = ""
        dgts.GridColumnStyles.Add(engineerRole)

        Dim description As New DataGridJobTypeColumn
        description.Format = ""
        description.FormatInfo = Nothing
        description.HeaderText = "Description"
        description.MappingName = "Description"
        description.ReadOnly = True
        description.Width = 600
        description.NullText = ""
        dgts.GridColumnStyles.Add(description)

        dgts.ReadOnly = True
        dgts.MappingName = "EngineerInRoleList"
        Me.dgrdEngineerInRoleList.TableStyles.Add(dgts)

    End Sub

    Private Sub btnfindEngineer_Click(sender As Object, e As EventArgs) Handles btnfindEngineer.Click
        FindEngineer()
    End Sub

    Private Sub FindEngineer()
        Dim ID As Integer = FindRecord(Enums.TableNames.tblEngineerRole)
        If Not ID = 0 Then
            Engineer = DB.Engineer.Engineer_Get(ID)
        End If
    End Sub

#End Region

End Class