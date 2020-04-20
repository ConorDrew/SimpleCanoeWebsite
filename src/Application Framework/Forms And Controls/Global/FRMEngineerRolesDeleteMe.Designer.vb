<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRMEngineerRolesDeleteMe
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tabEngineerRole = New System.Windows.Forms.TabControl()
        Me.tabPgCreateEngineerRole = New System.Windows.Forms.TabPage()
        Me.txtHourlyCostToCompany = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblHrlyCostToCompany = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.tabPgAssignEngineerRole = New System.Windows.Forms.TabPage()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.lblEngineerName = New System.Windows.Forms.Label()
        Me.lblRoleToAssign = New System.Windows.Forms.Label()
        Me.cboEngineer = New System.Windows.Forms.ComboBox()
        Me.cboRoleToAssign = New System.Windows.Forms.ComboBox()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.dgrdEngineerRoles = New System.Windows.Forms.DataGrid()
        Me.tabEngineerRole.SuspendLayout()
        Me.tabPgCreateEngineerRole.SuspendLayout()
        Me.tabPgAssignEngineerRole.SuspendLayout()
        CType(Me.dgrdEngineerRoles, System.ComponentModel.ISupportInitialize).BeginInit()

        'tabEngineerRole
        '
        Me.tabEngineerRole.Controls.Add(Me.tabPgCreateEngineerRole)
        Me.tabEngineerRole.Controls.Add(Me.tabPgAssignEngineerRole)
        Me.tabEngineerRole.Location = New System.Drawing.Point(12, 12)
        Me.tabEngineerRole.Name = "tabEngineerRole"
        Me.tabEngineerRole.SelectedIndex = 0
        Me.tabEngineerRole.Size = New System.Drawing.Size(691, 547)
        Me.tabEngineerRole.TabIndex = 0
        '
        'tabPgCreateEngineerRole
        '
        Me.tabPgCreateEngineerRole.Controls.Add(Me.dgrdEngineerRoles)
        Me.tabPgCreateEngineerRole.Controls.Add(Me.cmdSave)
        Me.tabPgCreateEngineerRole.Controls.Add(Me.txtDescription)
        Me.tabPgCreateEngineerRole.Controls.Add(Me.lblDescription)
        Me.tabPgCreateEngineerRole.Controls.Add(Me.txtHourlyCostToCompany)
        Me.tabPgCreateEngineerRole.Controls.Add(Me.txtName)
        Me.tabPgCreateEngineerRole.Controls.Add(Me.lblHrlyCostToCompany)
        Me.tabPgCreateEngineerRole.Controls.Add(Me.lblName)
        Me.tabPgCreateEngineerRole.Location = New System.Drawing.Point(4, 22)
        Me.tabPgCreateEngineerRole.Name = "tabPgCreateEngineerRole"
        Me.tabPgCreateEngineerRole.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPgCreateEngineerRole.Size = New System.Drawing.Size(683, 521)
        Me.tabPgCreateEngineerRole.TabIndex = 0
        Me.tabPgCreateEngineerRole.Text = "Create Engineer Role"
        Me.tabPgCreateEngineerRole.UseVisualStyleBackColor = True
        '
        'txtHourlyCostToCompany
        '
        Me.txtHourlyCostToCompany.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHourlyCostToCompany.Location = New System.Drawing.Point(92, 52)
        Me.txtHourlyCostToCompany.Name = "txtHourlyCostToCompany"
        Me.txtHourlyCostToCompany.Size = New System.Drawing.Size(162, 20)
        Me.txtHourlyCostToCompany.TabIndex = 4
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(92, 26)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(494, 20)
        Me.txtName.TabIndex = 3
        '
        'lblHrlyCostToCompany
        '
        Me.lblHrlyCostToCompany.AutoSize = True
        Me.lblHrlyCostToCompany.Location = New System.Drawing.Point(22, 56)
        Me.lblHrlyCostToCompany.Name = "lblHrlyCostToCompany"
        Me.lblHrlyCostToCompany.Size = New System.Drawing.Size(61, 13)
        Me.lblHrlyCostToCompany.TabIndex = 1
        Me.lblHrlyCostToCompany.Text = "Hourly Cost"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(22, 29)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(60, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Role Name"
        '
        'tabPgAssignEngineerRole
        '
        Me.tabPgAssignEngineerRole.Controls.Add(Me.cmdApply)
        Me.tabPgAssignEngineerRole.Controls.Add(Me.cboRoleToAssign)
        Me.tabPgAssignEngineerRole.Controls.Add(Me.cboEngineer)
        Me.tabPgAssignEngineerRole.Controls.Add(Me.lblRoleToAssign)
        Me.tabPgAssignEngineerRole.Controls.Add(Me.lblEngineerName)
        Me.tabPgAssignEngineerRole.Location = New System.Drawing.Point(4, 22)
        Me.tabPgAssignEngineerRole.Name = "tabPgAssignEngineerRole"
        Me.tabPgAssignEngineerRole.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPgAssignEngineerRole.Size = New System.Drawing.Size(683, 521)
        Me.tabPgAssignEngineerRole.TabIndex = 1
        Me.tabPgAssignEngineerRole.Text = "Assign Engineer Role"
        Me.tabPgAssignEngineerRole.UseVisualStyleBackColor = True
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(22, 78)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(60, 13)
        Me.lblDescription.TabIndex = 5
        Me.lblDescription.Text = "Description"
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(91, 78)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(495, 88)
        Me.txtDescription.TabIndex = 6
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(600, 143)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(67, 23)
        Me.cmdSave.TabIndex = 7
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'lblEngineerName
        '
        Me.lblEngineerName.AutoSize = True
        Me.lblEngineerName.Location = New System.Drawing.Point(28, 25)
        Me.lblEngineerName.Name = "lblEngineerName"
        Me.lblEngineerName.Size = New System.Drawing.Size(80, 13)
        Me.lblEngineerName.TabIndex = 0
        Me.lblEngineerName.Text = "Engineer Name"
        '
        'lblRoleToAssign
        '
        Me.lblRoleToAssign.AutoSize = True
        Me.lblRoleToAssign.Location = New System.Drawing.Point(31, 55)
        Me.lblRoleToAssign.Name = "lblRoleToAssign"
        Me.lblRoleToAssign.Size = New System.Drawing.Size(79, 13)
        Me.lblRoleToAssign.TabIndex = 1
        Me.lblRoleToAssign.Text = "Role To Assign"
        '
        'cboEngineer
        '
        Me.cboEngineer.FormattingEnabled = True
        Me.cboEngineer.Location = New System.Drawing.Point(110, 25)
        Me.cboEngineer.Name = "cboEngineer"
        Me.cboEngineer.Size = New System.Drawing.Size(302, 21)
        Me.cboEngineer.TabIndex = 2
        '
        'cboRoleToAssign
        '
        Me.cboRoleToAssign.FormattingEnabled = True
        Me.cboRoleToAssign.Location = New System.Drawing.Point(110, 55)
        Me.cboRoleToAssign.Name = "cboRoleToAssign"
        Me.cboRoleToAssign.Size = New System.Drawing.Size(302, 21)
        Me.cboRoleToAssign.TabIndex = 3
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(337, 82)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(75, 23)
        Me.cmdApply.TabIndex = 4
        Me.cmdApply.Text = "Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'dgrdEngineerRoles
        '
        Me.dgrdEngineerRoles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgrdEngineerRoles.DataMember = ""
        Me.dgrdEngineerRoles.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgrdEngineerRoles.Location = New System.Drawing.Point(25, 185)
        Me.dgrdEngineerRoles.Name = "dgrdEngineerRoles"
        Me.dgrdEngineerRoles.Size = New System.Drawing.Size(642, 316)
        Me.dgrdEngineerRoles.TabIndex = 9
        '

    End Sub

    Friend WithEvents tabEngineerRole As TabControl
    Friend WithEvents tabPgCreateEngineerRole As TabPage
    Friend WithEvents lblHrlyCostToCompany As Label
    Friend WithEvents lblName As Label
    Friend WithEvents tabPgAssignEngineerRole As TabPage
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtHourlyCostToCompany As TextBox
    Friend WithEvents cmdSave As Button
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents cmdApply As Button
    Friend WithEvents cboRoleToAssign As ComboBox
    Friend WithEvents cboEngineer As ComboBox
    Friend WithEvents lblRoleToAssign As Label
    Friend WithEvents lblEngineerName As Label
    Friend WithEvents dgrdEngineerRoles As DataGrid
End Class
