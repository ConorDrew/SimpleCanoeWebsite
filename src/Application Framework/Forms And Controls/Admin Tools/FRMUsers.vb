Public Class FRMUsers : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        If loggedInUser.Fullname = "Hayleigh Mann" Then
            btnPopulateNewSecurityModules.Visible = True
        Else
            btnPopulateNewSecurityModules.Visible = False
        End If

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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents btnAddNew As System.Windows.Forms.Button

    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents grpDetails As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFullName As System.Windows.Forms.TextBox
    Friend WithEvents chkEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtConfirm As System.Windows.Forms.TextBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents grpUsers As System.Windows.Forms.GroupBox
    Friend WithEvents dgUsers As System.Windows.Forms.DataGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgSecurityUserModules As System.Windows.Forms.DataGrid
    Friend WithEvents chkAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents btnPopulateNewSecurityModules As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents chkSDV As System.Windows.Forms.CheckBox
    Friend WithEvents cboDEG As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents grpUserRegions As GroupBox
    Friend WithEvents dgUserRegions As DataGrid

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpUsers = New System.Windows.Forms.GroupBox()
        Me.dgUsers = New System.Windows.Forms.DataGrid()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.grpDetails = New System.Windows.Forms.GroupBox()
        Me.cboDEG = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkSDV = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEmailAddress = New System.Windows.Forms.TextBox()
        Me.chkAdmin = New System.Windows.Forms.CheckBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.txtConfirm = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.chkEnabled = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgSecurityUserModules = New System.Windows.Forms.DataGrid()
        Me.btnPopulateNewSecurityModules = New System.Windows.Forms.Button()
        Me.grpUserRegions = New System.Windows.Forms.GroupBox()
        Me.dgUserRegions = New System.Windows.Forms.DataGrid()
        Me.grpUsers.SuspendLayout()
        CType(Me.dgUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetails.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgSecurityUserModules, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpUserRegions.SuspendLayout()
        CType(Me.dgUserRegions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpUsers
        '
        Me.grpUsers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpUsers.Controls.Add(Me.dgUsers)
        Me.grpUsers.Controls.Add(Me.btnAddNew)
        Me.grpUsers.Controls.Add(Me.btnDelete)
        Me.grpUsers.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpUsers.Location = New System.Drawing.Point(8, 40)
        Me.grpUsers.Name = "grpUsers"
        Me.grpUsers.Size = New System.Drawing.Size(312, 547)
        Me.grpUsers.TabIndex = 6
        Me.grpUsers.TabStop = False
        Me.grpUsers.Text = "Users"
        '
        'dgUsers
        '
        Me.dgUsers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgUsers.DataMember = ""
        Me.dgUsers.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgUsers.Location = New System.Drawing.Point(8, 57)
        Me.dgUsers.Name = "dgUsers"
        Me.dgUsers.Size = New System.Drawing.Size(296, 482)
        Me.dgUsers.TabIndex = 2
        '
        'btnAddNew
        '
        Me.btnAddNew.AccessibleDescription = "Add new user"
        Me.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddNew.Location = New System.Drawing.Point(8, 24)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(48, 23)
        Me.btnAddNew.TabIndex = 1
        Me.btnAddNew.Text = "New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleDescription = "Delete user"
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Location = New System.Drawing.Point(62, 24)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(59, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'grpDetails
        '
        Me.grpDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDetails.Controls.Add(Me.cboDEG)
        Me.grpDetails.Controls.Add(Me.Label7)
        Me.grpDetails.Controls.Add(Me.chkSDV)
        Me.grpDetails.Controls.Add(Me.Label6)
        Me.grpDetails.Controls.Add(Me.txtEmailAddress)
        Me.grpDetails.Controls.Add(Me.chkAdmin)
        Me.grpDetails.Controls.Add(Me.btnReset)
        Me.grpDetails.Controls.Add(Me.txtConfirm)
        Me.grpDetails.Controls.Add(Me.txtPassword)
        Me.grpDetails.Controls.Add(Me.txtUserName)
        Me.grpDetails.Controls.Add(Me.chkEnabled)
        Me.grpDetails.Controls.Add(Me.Label4)
        Me.grpDetails.Controls.Add(Me.Label3)
        Me.grpDetails.Controls.Add(Me.Label1)
        Me.grpDetails.Controls.Add(Me.txtFullName)
        Me.grpDetails.Controls.Add(Me.Label2)
        Me.grpDetails.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpDetails.Location = New System.Drawing.Point(328, 40)
        Me.grpDetails.Name = "grpDetails"
        Me.grpDetails.Size = New System.Drawing.Size(457, 244)
        Me.grpDetails.TabIndex = 8
        Me.grpDetails.TabStop = False
        Me.grpDetails.Text = "Details"
        '
        'cboDEG
        '
        Me.cboDEG.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDEG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDEG.Location = New System.Drawing.Point(127, 208)
        Me.cboDEG.Name = "cboDEG"
        Me.cboDEG.Size = New System.Drawing.Size(324, 21)
        Me.cboDEG.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 211)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Default Eng Group"
        '
        'chkSDV
        '
        Me.chkSDV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSDV.Location = New System.Drawing.Point(300, 150)
        Me.chkSDV.Name = "chkSDV"
        Me.chkSDV.Size = New System.Drawing.Size(149, 24)
        Me.chkSDV.TabIndex = 17
        Me.chkSDV.Text = "Scheduler Day View"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 184)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Email"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Location = New System.Drawing.Point(127, 181)
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(322, 21)
        Me.txtEmailAddress.TabIndex = 15
        '
        'chkAdmin
        '
        Me.chkAdmin.Location = New System.Drawing.Point(182, 151)
        Me.chkAdmin.Name = "chkAdmin"
        Me.chkAdmin.Size = New System.Drawing.Size(63, 24)
        Me.chkAdmin.TabIndex = 14
        Me.chkAdmin.Text = "Admin"
        '
        'btnReset
        '
        Me.btnReset.AccessibleDescription = "Reset the users password"
        Me.btnReset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReset.Location = New System.Drawing.Point(399, 86)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(48, 23)
        Me.btnReset.TabIndex = 7
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'txtConfirm
        '
        Me.txtConfirm.Location = New System.Drawing.Point(127, 120)
        Me.txtConfirm.MaxLength = 50
        Me.txtConfirm.Name = "txtConfirm"
        Me.txtConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirm.Size = New System.Drawing.Size(322, 21)
        Me.txtConfirm.TabIndex = 8
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(127, 88)
        Me.txtPassword.MaxLength = 50
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(266, 21)
        Me.txtPassword.TabIndex = 6
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(127, 56)
        Me.txtUserName.MaxLength = 50
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(322, 21)
        Me.txtUserName.TabIndex = 5
        '
        'chkEnabled
        '
        Me.chkEnabled.Checked = True
        Me.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEnabled.Location = New System.Drawing.Point(12, 150)
        Me.chkEnabled.Name = "chkEnabled"
        Me.chkEnabled.Size = New System.Drawing.Size(113, 24)
        Me.chkEnabled.TabIndex = 10
        Me.chkEnabled.Text = "Logon Enabled"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Confirm"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Password"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Username"
        '
        'txtFullName
        '
        Me.txtFullName.Location = New System.Drawing.Point(127, 24)
        Me.txtFullName.MaxLength = 255
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(322, 21)
        Me.txtFullName.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Full Name"
        '
        'btnSave
        '
        Me.btnSave.AccessibleDescription = "Save user details"
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.Location = New System.Drawing.Point(737, 564)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(48, 23)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgSecurityUserModules)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Location = New System.Drawing.Point(326, 504)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(459, 54)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Module Access"
        '
        'dgSecurityUserModules
        '
        Me.dgSecurityUserModules.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSecurityUserModules.DataMember = ""
        Me.dgSecurityUserModules.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSecurityUserModules.Location = New System.Drawing.Point(8, 20)
        Me.dgSecurityUserModules.Name = "dgSecurityUserModules"
        Me.dgSecurityUserModules.Size = New System.Drawing.Size(443, 26)
        Me.dgSecurityUserModules.TabIndex = 2
        '
        'btnPopulateNewSecurityModules
        '
        Me.btnPopulateNewSecurityModules.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPopulateNewSecurityModules.Location = New System.Drawing.Point(536, 564)
        Me.btnPopulateNewSecurityModules.Name = "btnPopulateNewSecurityModules"
        Me.btnPopulateNewSecurityModules.Size = New System.Drawing.Size(195, 23)
        Me.btnPopulateNewSecurityModules.TabIndex = 13
        Me.btnPopulateNewSecurityModules.Text = "Populate New Security Modules"
        Me.btnPopulateNewSecurityModules.UseVisualStyleBackColor = True
        '
        'grpUserRegions
        '
        Me.grpUserRegions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpUserRegions.Controls.Add(Me.dgUserRegions)
        Me.grpUserRegions.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpUserRegions.Location = New System.Drawing.Point(328, 290)
        Me.grpUserRegions.Name = "grpUserRegions"
        Me.grpUserRegions.Size = New System.Drawing.Size(459, 208)
        Me.grpUserRegions.TabIndex = 13
        Me.grpUserRegions.TabStop = False
        Me.grpUserRegions.Text = "User Regions"
        '
        'dgUserRegions
        '
        Me.dgUserRegions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgUserRegions.DataMember = ""
        Me.dgUserRegions.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgUserRegions.Location = New System.Drawing.Point(8, 20)
        Me.dgUserRegions.Name = "dgUserRegions"
        Me.dgUserRegions.Size = New System.Drawing.Size(443, 180)
        Me.dgUserRegions.TabIndex = 2
        '
        'FRMUsers
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(793, 593)
        Me.Controls.Add(Me.grpUserRegions)
        Me.Controls.Add(Me.btnPopulateNewSecurityModules)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpDetails)
        Me.Controls.Add(Me.grpUsers)
        Me.Controls.Add(Me.btnSave)
        Me.MinimumSize = New System.Drawing.Size(800, 576)
        Me.Name = "FRMUsers"
        Me.Text = "Users"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.grpUsers, 0)
        Me.Controls.SetChildIndex(Me.grpDetails, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnPopulateNewSecurityModules, 0)
        Me.Controls.SetChildIndex(Me.grpUserRegions, 0)
        Me.grpUsers.ResumeLayout(False)
        CType(Me.dgUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetails.ResumeLayout(False)
        Me.grpDetails.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgSecurityUserModules, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpUserRegions.ResumeLayout(False)
        CType(Me.dgUserRegions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        If CStr(GetParameter(0)).Trim.Length > 0 Then
            Users = DB.User.User_Search(GetParameter(0))
        Else
            Users = DB.User.GetAll()
        End If

        SetupUsersAndEngineersDataGrid()
        SetupUserModulesDatagrid()
        SetupUserRegionsDatagrid()

        Combo.SetUpCombo(Me.cboDEG, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.EngineerGroup).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)

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

    Private _pageState As Entity.Sys.Enums.FormState

    Private Property PageState() As Entity.Sys.Enums.FormState
        Get
            Return _pageState
        End Get
        Set(ByVal Value As Entity.Sys.Enums.FormState)
            _pageState = Value
        End Set
    End Property

    Private _dvUsers As DataView

    Private Property Users() As DataView
        Get
            Return _dvUsers
        End Get
        Set(ByVal value As DataView)
            _dvUsers = value
            _dvUsers.Table.TableName = Entity.Sys.Enums.TableNames.tblUser.ToString
            _dvUsers.AllowNew = False
            _dvUsers.AllowEdit = False
            _dvUsers.AllowDelete = False
            Me.dgUsers.DataSource = Users
            SetUpPageState(Entity.Sys.Enums.FormState.Load)
            UserModules = Nothing
            UserRegions = Nothing
        End Set
    End Property

    Private ReadOnly Property SelectedUserDataRow() As DataRow
        Get
            If Not Me.dgUsers.CurrentRowIndex = -1 Then
                Return Users(Me.dgUsers.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Private Sub SetupUsersAndEngineersDataGrid()
        Dim tStyle As DataGridTableStyle = Me.dgUsers.TableStyles(0)

        Dim fullName As New DataGridLabelColumn
        fullName.Format = ""
        fullName.FormatInfo = Nothing
        fullName.HeaderText = "Name"
        fullName.MappingName = "FullName"
        fullName.ReadOnly = True
        fullName.Width = 125
        fullName.NullText = ""
        tStyle.GridColumnStyles.Add(fullName)

        Dim userName As New DataGridLabelColumn
        userName.Format = ""
        userName.FormatInfo = Nothing
        userName.HeaderText = "Username"
        userName.MappingName = "UserName"
        userName.ReadOnly = True
        userName.Width = 125
        userName.NullText = ""
        tStyle.GridColumnStyles.Add(userName)

        Dim pdaID As New DataGridLabelColumn
        pdaID.Format = ""
        pdaID.FormatInfo = Nothing
        pdaID.HeaderText = "PDA"
        pdaID.MappingName = "PDAID"
        pdaID.ReadOnly = True
        pdaID.Width = 55
        pdaID.NullText = ""
        tStyle.GridColumnStyles.Add(pdaID)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblUser.ToString

        Me.dgUsers.TableStyles.Add(tStyle)

    End Sub

    Public Sub SetupUserRegionsDatagrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgUserRegions)
        Dim tStyle As DataGridTableStyle = Me.dgUserRegions.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        tStyle.ReadOnly = False
        tStyle.AllowSorting = False
        dgUserRegions.ReadOnly = False
        dgUserRegions.AllowSorting = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tStyle.GridColumnStyles.Add(Tick)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Name"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 300
        Name.NullText = ""
        tStyle.GridColumnStyles.Add(Name)

        Dim Name2 As New DataGridLabelColumn
        Name2.Format = ""
        Name2.FormatInfo = Nothing
        Name2.HeaderText = ""
        Name2.MappingName = "ManagerID"
        Name2.ReadOnly = True
        Name2.Width = 1
        Name2.NullText = ""
        tStyle.GridColumnStyles.Add(Name2)

        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblRegion.ToString
        Me.dgUserRegions.TableStyles.Add(tStyle)

    End Sub

#End Region

#Region "Events"

    Private Sub FRMUsers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        SetUpPageState(Entity.Sys.Enums.FormState.Insert)
    End Sub

    Private Sub dgUsers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgUsers.Click, dgUsers.CurrentCellChanged
        Try
            SetUpPageState(Entity.Sys.Enums.FormState.Update)
            If SelectedUserDataRow Is Nothing Then
                SetUpPageState(Entity.Sys.Enums.FormState.Load)
            End If
        Catch ex As Exception
            ShowMessage("Details cannot load : " & ex.Message, MessageBoxButtons.OK, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ResetPassword()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Delete()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Save()
    End Sub

    Private Sub btnPopulateNewSecurityModules_Click(sender As Object, e As EventArgs) Handles btnPopulateNewSecurityModules.Click
        PopulateNewSecurityModules()
    End Sub

#End Region

#Region "Functions"

    Private Sub SetUpPageState(ByVal state As Entity.Sys.Enums.FormState)
        Entity.Sys.Helper.ClearGroupBox(Me.grpDetails)
        Select Case state
            Case Entity.Sys.Enums.FormState.Load
                Me.btnAddNew.Enabled = True
                Me.btnDelete.Enabled = False
                Me.btnReset.Enabled = False
                Me.grpDetails.Enabled = False
            Case Entity.Sys.Enums.FormState.Insert
                Me.btnAddNew.Enabled = True
                Me.btnDelete.Enabled = False
                Me.btnReset.Enabled = False
                Me.grpDetails.Enabled = True
                Me.txtPassword.ReadOnly = False
                Me.txtConfirm.ReadOnly = False
                Me.chkEnabled.Checked = True
                Me.chkAdmin.Checked = False
                UserModules = DB.User.GetSecurityUserModulesDefaults()
                UserRegions = DB.User.GetUserRegionsDefaults
            Case Entity.Sys.Enums.FormState.Update
                Me.btnAddNew.Enabled = True
                Me.btnDelete.Enabled = True
                Me.btnReset.Enabled = True
                Me.grpDetails.Enabled = True
                Me.txtPassword.ReadOnly = True
                Me.txtConfirm.ReadOnly = True
                PopulateDetails()
        End Select
        PageState = state
    End Sub

    Private Sub PopulateDetails()
        If SelectedUserDataRow.Item("UserID") = TheSystem.Configuration.SuperAdminID And
            loggedInUser.UserID <> TheSystem.Configuration.SuperAdminID Then
            ShowMessage("You may not view this data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            SetUpPageState(Entity.Sys.Enums.FormState.Load)

            Exit Sub
        Else
            Me.txtFullName.Text = Entity.Sys.Helper.MakeStringValid(SelectedUserDataRow.Item("Fullname"))
            Me.txtUserName.Text = Entity.Sys.Helper.MakeStringValid(SelectedUserDataRow.Item("UserName"))
            Me.txtPassword.Text = "**********"
            Me.txtConfirm.Text = "**********"
            Me.chkEnabled.Checked = Entity.Sys.Helper.MakeBooleanValid(SelectedUserDataRow.Item("Enabled"))
            Me.chkAdmin.Checked = Entity.Sys.Helper.MakeBooleanValid(SelectedUserDataRow.Item("Admin"))
            Me.chkSDV.Checked = Entity.Sys.Helper.MakeBooleanValid(SelectedUserDataRow.Item("SchedulerDayView"))
            If Not IsDBNull(SelectedUserDataRow.Item("DefaultSchedulerEngineerGroup")) Then
                Combo.SetSelectedComboItem_By_Value(Me.cboDEG, SelectedUserDataRow.Item("DefaultSchedulerEngineerGroup"))
            End If
            Combo.SetSelectedComboItem_By_Value(Me.cboDEG, Entity.Sys.Helper.MakeIntegerValid(SelectedUserDataRow.Item("DefaultSchedulerEngineerGroup")))
            Me.txtEmailAddress.Text = Entity.Sys.Helper.MakeStringValid(SelectedUserDataRow.Item("EmailAddress"))
            Dim u As Entity.Users.User = DB.User.Get(CInt(SelectedUserDataRow.Item("UserID")))
            UserModules = u.SecurityUserModules
            UserRegions = DB.User.GetUserRegions(SelectedUserDataRow.Item("UserID"))
        End If
    End Sub

    Private Sub Save()
        Dim user As New Entity.Users.User
        user.IgnoreExceptionsOnSetMethods = True
        user.SetFullname = Me.txtFullName.Text.Trim
        user.SetUsername = Me.txtUserName.Text.Trim
        user.SetPassword = Me.txtPassword.Text.Trim
        user.SetEnabled = Me.chkEnabled.Checked
        user.SetAdmin = Me.chkAdmin.Checked
        user.SetEmailAddress = Me.txtEmailAddress.Text.Trim
        user.SetSchedulerDayView = Me.chkSDV.Checked
        user.SetDefaultEngineerGroup = Combo.GetSelectedItemValue(Me.cboDEG)
        If PageState = Entity.Sys.Enums.FormState.Update Then
            user.SetUserID = Entity.Sys.Helper.MakeIntegerValid(SelectedUserDataRow.Item("UserID"))
        End If

        user.SecurityUserModules = UserModules

        Dim validator As New Entity.Users.UserValidator

        Try
            validator.Validate(user)

            Select Case PageState
                Case Entity.Sys.Enums.FormState.Insert
                    user.SetUserID = DB.User.Insert(user)
                Case Entity.Sys.Enums.FormState.Update
                    DB.User.Update(user)
            End Select

            Dim diff As DataTable = UserRegions.Table.GetChanges()
            If diff IsNot Nothing Then
                Dim changes As String = String.Empty
                Dim addAnd As Boolean = False
                For Each dr As DataRow In diff.Rows
                    If addAnd Then changes += " and "
                    changes += Entity.Sys.Helper.MakeStringValid(dr("Name")) & " set to " & Entity.Sys.Helper.MakeStringValid(dr("Tick"))
                    addAnd = True
                Next

                If Not String.IsNullOrEmpty(changes) Then DB.User.UserAccessAudit_Insert(user.UserID, changes)
            End If

            DB.User.UserRegions_Delete(user.UserID)

            For Each dr As DataRow In UserRegions.Table.Rows
                If dr("Tick") = True Then
                    DB.User.UserRegions_Insert(user.UserID, dr("ManagerID"))
                End If

            Next

            Users = DB.User.GetAll()
        Catch ex As ValidationException
            ShowMessage(validator.CriticalMessagesString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("Error Saving : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetPassword()
        Try
            If Not SelectedUserDataRow Is Nothing Then
                If ShowMessage("Are you sure you want to reset the password for """ & SelectedUserDataRow("FullName") & """?", MessageBoxButtons.YesNo, MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    DB.User.UpdatePassword(SelectedUserDataRow("UserID"), "password", True)
                    ShowMessage("Password has been reset to 'password'.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Users = DB.User.GetAll()
                End If
            Else
                ShowMessage("Please select a user to reset password for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            ShowMessage("Error resetting password : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Delete()
        Try
            If Not SelectedUserDataRow Is Nothing Then
                If ShowMessage("Are you sure you want to delete """ & SelectedUserDataRow("FullName") & """?", MessageBoxButtons.YesNo, MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    DB.User.Delete(SelectedUserDataRow("UserID"))
                    Users = DB.User.GetAll()
                End If
            Else
                ShowMessage("Please select a user to delete.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            ShowMessage("Error deleting : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PopulateNewSecurityModules()
        Try
            Users = DB.User.GetAll()
            For u As Integer = 0 To Users.Count - 1
                Dim AllSecurityModules As DataView = DB.User.GetSecurityUserModulesDefaults

                For i As Integer = 0 To AllSecurityModules.Count - 1
                    Dim usersecuritymodules As DataView = DB.User.GetSecurityUserModules(Users.Table().Rows.Item(u).Item(0).ToString)
                    Dim rows() As DataRow = usersecuritymodules.Table.Select(String.Format("SystemModuleID = {0}", CInt(AllSecurityModules.Table().Rows.Item(i).Item(1).ToString)))
                    If rows.Length = 1 Then
                    Else
                        DB.User.InsertNewSecurityUserModules(Users.Table().Rows.Item(u).Item(0).ToString, CInt(AllSecurityModules.Table().Rows.Item(i).Item(1).ToString), False)
                    End If
                Next
            Next
        Catch ex As Exception
            ShowMessage("Error creating security module : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Security"

    Public Sub SetupUserModulesDatagrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgSecurityUserModules)
        Dim tStyle As DataGridTableStyle = Me.dgSecurityUserModules.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Me.dgSecurityUserModules.ReadOnly = False
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False

        Dim ModuleName As New DataGridLabelColumn
        ModuleName.Format = ""
        ModuleName.FormatInfo = Nothing
        ModuleName.HeaderText = "Module"
        ModuleName.MappingName = "ModuleName"
        ModuleName.ReadOnly = True
        ModuleName.Width = 250
        ModuleName.NullText = ""
        tStyle.GridColumnStyles.Add(ModuleName)

        Dim AccessPermitted As New DataGridBoolColumn
        AccessPermitted.HeaderText = "Allow"
        AccessPermitted.MappingName = "AccessPermitted"
        AccessPermitted.ReadOnly = True
        AccessPermitted.Width = 55
        AccessPermitted.NullText = ""
        tStyle.GridColumnStyles.Add(AccessPermitted)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSecurityUserModules.ToString
        Me.dgSecurityUserModules.TableStyles.Add(tStyle)

        Entity.Sys.Helper.RemoveEventHandlers(Me.dgSecurityUserModules)

    End Sub

    Private _userModules As DataView = Nothing

    Public Property UserModules() As DataView
        Get
            Return _userModules
        End Get
        Set(ByVal Value As DataView)
            _userModules = Value
            If Not _userModules Is Nothing Then
                _userModules.Table.TableName = Entity.Sys.Enums.TableNames.tblSecurityUserModules.ToString
                _userModules.AllowNew = False
                _userModules.AllowEdit = False
                _userModules.AllowDelete = False
            End If

            Me.dgSecurityUserModules.DataSource = _userModules
        End Set
    End Property

    Private ReadOnly Property SelectedUserModuleDataRow() As DataRow
        Get
            If Not Me.dgSecurityUserModules.CurrentRowIndex = -1 Then
                Return UserModules(Me.dgSecurityUserModules.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _userRegions As DataView = Nothing

    Public Property UserRegions() As DataView
        Get
            Return _userRegions
        End Get
        Set(ByVal Value As DataView)
            _userRegions = Value
            If Not _userRegions Is Nothing Then
                _userRegions.Table.TableName = Entity.Sys.Enums.TableNames.tblRegion.ToString
                _userRegions.AllowNew = False
                _userRegions.AllowEdit = False
                _userRegions.AllowDelete = False
            End If

            Me.dgUserRegions.DataSource = _userRegions
        End Set
    End Property

    Private ReadOnly Property SelectedUserRegionDataRow() As DataRow
        Get
            If Not Me.dgUserRegions.CurrentRowIndex = -1 Then
                Return UserRegions(Me.dgUserRegions.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private Sub dgSecurityUserModules_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgSecurityUserModules.Click

        If SelectedUserModuleDataRow Is Nothing Then
            Exit Sub
        End If

        If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.IT) Then
            Dim accessPermittedColumn As Integer = 1
            Dim selected As Boolean = Not CBool(Me.dgSecurityUserModules(Me.dgSecurityUserModules.CurrentRowIndex, accessPermittedColumn))
            Me.dgSecurityUserModules(Me.dgSecurityUserModules.CurrentRowIndex, accessPermittedColumn) = selected
        Else
            Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
            msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
            Throw New Security.SecurityException(msg)
        End If
    End Sub

    Private Sub dgUserRegions_Click(sender As Object, e As EventArgs) Handles dgUserRegions.Click
        If SelectedUserRegionDataRow Is Nothing Then
            Exit Sub
        End If

        If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.IT) = False Then
            Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
            msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
            Throw New Security.SecurityException(msg)
        Else
            Dim selected As Boolean = Not CBool(Me.dgUserRegions(Me.dgUserRegions.CurrentRowIndex, 0))
            Me.dgUserRegions(Me.dgUserRegions.CurrentRowIndex, 0) = selected
        End If
    End Sub

#End Region

End Class