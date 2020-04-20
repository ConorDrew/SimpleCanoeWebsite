Public Class UCSystemScheduleOfRate : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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

    Friend WithEvents grpSystemScheduleOfRate As System.Windows.Forms.GroupBox
    Friend WithEvents cboScheduleOfRatesCategoryID As System.Windows.Forms.ComboBox
    Friend WithEvents lblScheduleOfRatesCategoryID As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents dgRates As System.Windows.Forms.DataGrid
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents txtTimeInMins As System.Windows.Forms.TextBox
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents grpSOR As GroupBox
    Friend WithEvents grpJobImportType As GroupBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnRemoveType As Button
    Friend WithEvents cboJobImportType As ComboBox
    Friend WithEvents lblJobImportType As Label
    Friend WithEvents cboJobType As ComboBox
    Friend WithEvents lblJobType As Label
    Friend WithEvents txtJobTypeName As TextBox
    Friend WithEvents lblJobTypeName As Label
    Friend WithEvents btnAddNewType As Button
    Friend WithEvents txtCycle As TextBox
    Friend WithEvents lblCycle As Label
    Friend WithEvents cboSORJobType As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents grpEngineerSkillSOR As GroupBox
    Friend WithEvents txtSOR As TextBox
    Friend WithEvents lblSORName As Label
    Friend WithEvents btnSaveEngineerQual As Button
    Friend WithEvents grpEngineerSkills As GroupBox
    Friend WithEvents dgEngineerQual As DataGrid
    Friend WithEvents btnFindSOR As Button
    Friend WithEvents btnClearAll As Button
    Friend WithEvents btnFindEngineerQual As Button
    Friend WithEvents txtEngineerQual As TextBox
    Friend WithEvents lblEngineerQual As Label
    Friend WithEvents btnAddUpdate As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpSystemScheduleOfRate = New System.Windows.Forms.GroupBox()
        Me.cboSORJobType = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grpSOR = New System.Windows.Forms.GroupBox()
        Me.dgRates = New System.Windows.Forms.DataGrid()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.txtTimeInMins = New System.Windows.Forms.TextBox()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.btnAddUpdate = New System.Windows.Forms.Button()
        Me.cboScheduleOfRatesCategoryID = New System.Windows.Forms.ComboBox()
        Me.lblScheduleOfRatesCategoryID = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.grpJobImportType = New System.Windows.Forms.GroupBox()
        Me.btnFindEngineerQual = New System.Windows.Forms.Button()
        Me.txtEngineerQual = New System.Windows.Forms.TextBox()
        Me.lblEngineerQual = New System.Windows.Forms.Label()
        Me.txtCycle = New System.Windows.Forms.TextBox()
        Me.lblCycle = New System.Windows.Forms.Label()
        Me.btnAddNewType = New System.Windows.Forms.Button()
        Me.cboJobType = New System.Windows.Forms.ComboBox()
        Me.lblJobType = New System.Windows.Forms.Label()
        Me.txtJobTypeName = New System.Windows.Forms.TextBox()
        Me.lblJobTypeName = New System.Windows.Forms.Label()
        Me.cboJobImportType = New System.Windows.Forms.ComboBox()
        Me.lblJobImportType = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnRemoveType = New System.Windows.Forms.Button()
        Me.grpEngineerSkillSOR = New System.Windows.Forms.GroupBox()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.grpEngineerSkills = New System.Windows.Forms.GroupBox()
        Me.dgEngineerQual = New System.Windows.Forms.DataGrid()
        Me.btnFindSOR = New System.Windows.Forms.Button()
        Me.txtSOR = New System.Windows.Forms.TextBox()
        Me.lblSORName = New System.Windows.Forms.Label()
        Me.btnSaveEngineerQual = New System.Windows.Forms.Button()
        Me.grpSystemScheduleOfRate.SuspendLayout()
        Me.grpSOR.SuspendLayout()
        CType(Me.dgRates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpJobImportType.SuspendLayout()
        Me.grpEngineerSkillSOR.SuspendLayout()
        Me.grpEngineerSkills.SuspendLayout()
        CType(Me.dgEngineerQual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpSystemScheduleOfRate
        '
        Me.grpSystemScheduleOfRate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.cboSORJobType)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.Label9)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.grpSOR)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.btnAddNew)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.btnRemove)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.txtTimeInMins)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.lblTime)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.btnAddUpdate)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.cboScheduleOfRatesCategoryID)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.lblScheduleOfRatesCategoryID)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.txtCode)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.lblCode)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.txtDescription)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.lblDescription)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.txtPrice)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.lblPrice)
        Me.grpSystemScheduleOfRate.Location = New System.Drawing.Point(8, 8)
        Me.grpSystemScheduleOfRate.Name = "grpSystemScheduleOfRate"
        Me.grpSystemScheduleOfRate.Size = New System.Drawing.Size(746, 713)
        Me.grpSystemScheduleOfRate.TabIndex = 0
        Me.grpSystemScheduleOfRate.TabStop = False
        Me.grpSystemScheduleOfRate.Text = "Main Details"
        '
        'cboSORJobType
        '
        Me.cboSORJobType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboSORJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSORJobType.Location = New System.Drawing.Point(194, 59)
        Me.cboSORJobType.Name = "cboSORJobType"
        Me.cboSORJobType.Size = New System.Drawing.Size(540, 21)
        Me.cboSORJobType.TabIndex = 27
        Me.cboSORJobType.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(11, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(118, 20)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Job Type"
        '
        'grpSOR
        '
        Me.grpSOR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSOR.Controls.Add(Me.dgRates)
        Me.grpSOR.Location = New System.Drawing.Point(14, 259)
        Me.grpSOR.Name = "grpSOR"
        Me.grpSOR.Size = New System.Drawing.Size(720, 409)
        Me.grpSOR.TabIndex = 14
        Me.grpSOR.TabStop = False
        Me.grpSOR.Text = "Schedule of Rates"
        '
        'dgRates
        '
        Me.dgRates.DataMember = ""
        Me.dgRates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgRates.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgRates.Location = New System.Drawing.Point(3, 17)
        Me.dgRates.Name = "dgRates"
        Me.dgRates.Size = New System.Drawing.Size(714, 389)
        Me.dgRates.TabIndex = 13
        '
        'btnAddNew
        '
        Me.btnAddNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddNew.Location = New System.Drawing.Point(14, 674)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(101, 23)
        Me.btnAddNew.TabIndex = 11
        Me.btnAddNew.Text = "Add New"
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.Location = New System.Drawing.Point(633, 674)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(101, 23)
        Me.btnRemove.TabIndex = 12
        Me.btnRemove.Text = "Remove"
        '
        'txtTimeInMins
        '
        Me.txtTimeInMins.Location = New System.Drawing.Point(512, 96)
        Me.txtTimeInMins.MaxLength = 9
        Me.txtTimeInMins.Name = "txtTimeInMins"
        Me.txtTimeInMins.Size = New System.Drawing.Size(103, 21)
        Me.txtTimeInMins.TabIndex = 7
        Me.txtTimeInMins.Tag = "SystemScheduleOfRate.Price"
        '
        'lblTime
        '
        Me.lblTime.Location = New System.Drawing.Point(428, 99)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(78, 20)
        Me.lblTime.TabIndex = 6
        Me.lblTime.Text = "Time (Mins)"
        '
        'btnAddUpdate
        '
        Me.btnAddUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddUpdate.Location = New System.Drawing.Point(633, 232)
        Me.btnAddUpdate.Name = "btnAddUpdate"
        Me.btnAddUpdate.Size = New System.Drawing.Size(101, 23)
        Me.btnAddUpdate.TabIndex = 10
        Me.btnAddUpdate.Text = "Add/Update"
        '
        'cboScheduleOfRatesCategoryID
        '
        Me.cboScheduleOfRatesCategoryID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboScheduleOfRatesCategoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboScheduleOfRatesCategoryID.Location = New System.Drawing.Point(194, 25)
        Me.cboScheduleOfRatesCategoryID.Name = "cboScheduleOfRatesCategoryID"
        Me.cboScheduleOfRatesCategoryID.Size = New System.Drawing.Size(540, 21)
        Me.cboScheduleOfRatesCategoryID.TabIndex = 1
        Me.cboScheduleOfRatesCategoryID.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID"
        '
        'lblScheduleOfRatesCategoryID
        '
        Me.lblScheduleOfRatesCategoryID.Location = New System.Drawing.Point(11, 25)
        Me.lblScheduleOfRatesCategoryID.Name = "lblScheduleOfRatesCategoryID"
        Me.lblScheduleOfRatesCategoryID.Size = New System.Drawing.Size(179, 20)
        Me.lblScheduleOfRatesCategoryID.TabIndex = 0
        Me.lblScheduleOfRatesCategoryID.Text = "Schedule Of Rates Category"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(279, 96)
        Me.txtCode.MaxLength = 50
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(131, 21)
        Me.txtCode.TabIndex = 3
        Me.txtCode.Tag = "SystemScheduleOfRate.Code"
        '
        'lblCode
        '
        Me.lblCode.Location = New System.Drawing.Point(231, 99)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(42, 20)
        Me.lblCode.TabIndex = 2
        Me.lblCode.Text = "Code"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(95, 145)
        Me.txtDescription.MaxLength = 0
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(639, 79)
        Me.txtDescription.TabIndex = 5
        Me.txtDescription.Tag = "SystemScheduleOfRate.Description"
        '
        'lblDescription
        '
        Me.lblDescription.Location = New System.Drawing.Point(12, 145)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(77, 20)
        Me.lblDescription.TabIndex = 4
        Me.lblDescription.Text = "Description"
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(59, 96)
        Me.txtPrice.MaxLength = 9
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(131, 21)
        Me.txtPrice.TabIndex = 9
        Me.txtPrice.Tag = "SystemScheduleOfRate.Price"
        '
        'lblPrice
        '
        Me.lblPrice.Location = New System.Drawing.Point(11, 99)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(42, 20)
        Me.lblPrice.TabIndex = 8
        Me.lblPrice.Text = "Price"
        '
        'grpJobImportType
        '
        Me.grpJobImportType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpJobImportType.Controls.Add(Me.btnFindEngineerQual)
        Me.grpJobImportType.Controls.Add(Me.txtEngineerQual)
        Me.grpJobImportType.Controls.Add(Me.lblEngineerQual)
        Me.grpJobImportType.Controls.Add(Me.txtCycle)
        Me.grpJobImportType.Controls.Add(Me.lblCycle)
        Me.grpJobImportType.Controls.Add(Me.btnAddNewType)
        Me.grpJobImportType.Controls.Add(Me.cboJobType)
        Me.grpJobImportType.Controls.Add(Me.lblJobType)
        Me.grpJobImportType.Controls.Add(Me.txtJobTypeName)
        Me.grpJobImportType.Controls.Add(Me.lblJobTypeName)
        Me.grpJobImportType.Controls.Add(Me.cboJobImportType)
        Me.grpJobImportType.Controls.Add(Me.lblJobImportType)
        Me.grpJobImportType.Controls.Add(Me.btnSave)
        Me.grpJobImportType.Controls.Add(Me.btnRemoveType)
        Me.grpJobImportType.Location = New System.Drawing.Point(760, 472)
        Me.grpJobImportType.Name = "grpJobImportType"
        Me.grpJobImportType.Size = New System.Drawing.Size(375, 249)
        Me.grpJobImportType.TabIndex = 15
        Me.grpJobImportType.TabStop = False
        Me.grpJobImportType.Text = "Job Import Types"
        '
        'btnFindEngineerQual
        '
        Me.btnFindEngineerQual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindEngineerQual.BackColor = System.Drawing.Color.White
        Me.btnFindEngineerQual.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindEngineerQual.Location = New System.Drawing.Point(336, 126)
        Me.btnFindEngineerQual.Name = "btnFindEngineerQual"
        Me.btnFindEngineerQual.Size = New System.Drawing.Size(32, 23)
        Me.btnFindEngineerQual.TabIndex = 41
        Me.btnFindEngineerQual.Text = "..."
        Me.btnFindEngineerQual.UseVisualStyleBackColor = False
        '
        'txtEngineerQual
        '
        Me.txtEngineerQual.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEngineerQual.Location = New System.Drawing.Point(138, 128)
        Me.txtEngineerQual.MaxLength = 50
        Me.txtEngineerQual.Name = "txtEngineerQual"
        Me.txtEngineerQual.ReadOnly = True
        Me.txtEngineerQual.Size = New System.Drawing.Size(183, 21)
        Me.txtEngineerQual.TabIndex = 40
        Me.txtEngineerQual.Tag = "SystemScheduleOfRate.Code"
        '
        'lblEngineerQual
        '
        Me.lblEngineerQual.Location = New System.Drawing.Point(11, 131)
        Me.lblEngineerQual.Name = "lblEngineerQual"
        Me.lblEngineerQual.Size = New System.Drawing.Size(163, 20)
        Me.lblEngineerQual.TabIndex = 39
        Me.lblEngineerQual.Text = "Engineer Qual"
        '
        'txtCycle
        '
        Me.txtCycle.Location = New System.Drawing.Point(139, 162)
        Me.txtCycle.MaxLength = 50
        Me.txtCycle.Name = "txtCycle"
        Me.txtCycle.Size = New System.Drawing.Size(230, 21)
        Me.txtCycle.TabIndex = 25
        Me.txtCycle.Tag = ""
        '
        'lblCycle
        '
        Me.lblCycle.Location = New System.Drawing.Point(11, 165)
        Me.lblCycle.Name = "lblCycle"
        Me.lblCycle.Size = New System.Drawing.Size(100, 20)
        Me.lblCycle.TabIndex = 24
        Me.lblCycle.Text = "Cycle (Yrs)"
        '
        'btnAddNewType
        '
        Me.btnAddNewType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddNewType.Location = New System.Drawing.Point(152, 210)
        Me.btnAddNewType.Name = "btnAddNewType"
        Me.btnAddNewType.Size = New System.Drawing.Size(101, 23)
        Me.btnAddNewType.TabIndex = 23
        Me.btnAddNewType.Text = "Add New"
        '
        'cboJobType
        '
        Me.cboJobType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJobType.Location = New System.Drawing.Point(138, 94)
        Me.cboJobType.Name = "cboJobType"
        Me.cboJobType.Size = New System.Drawing.Size(230, 21)
        Me.cboJobType.TabIndex = 22
        Me.cboJobType.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID"
        '
        'lblJobType
        '
        Me.lblJobType.Location = New System.Drawing.Point(11, 97)
        Me.lblJobType.Name = "lblJobType"
        Me.lblJobType.Size = New System.Drawing.Size(118, 20)
        Me.lblJobType.TabIndex = 21
        Me.lblJobType.Text = "Job Type"
        '
        'txtJobTypeName
        '
        Me.txtJobTypeName.Location = New System.Drawing.Point(138, 60)
        Me.txtJobTypeName.MaxLength = 50
        Me.txtJobTypeName.Name = "txtJobTypeName"
        Me.txtJobTypeName.Size = New System.Drawing.Size(230, 21)
        Me.txtJobTypeName.TabIndex = 18
        Me.txtJobTypeName.Tag = "SystemScheduleOfRate.Code"
        '
        'lblJobTypeName
        '
        Me.lblJobTypeName.Location = New System.Drawing.Point(11, 63)
        Me.lblJobTypeName.Name = "lblJobTypeName"
        Me.lblJobTypeName.Size = New System.Drawing.Size(100, 20)
        Me.lblJobTypeName.TabIndex = 17
        Me.lblJobTypeName.Text = "Job Type Name"
        '
        'cboJobImportType
        '
        Me.cboJobImportType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboJobImportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJobImportType.Location = New System.Drawing.Point(138, 26)
        Me.cboJobImportType.Name = "cboJobImportType"
        Me.cboJobImportType.Size = New System.Drawing.Size(230, 21)
        Me.cboJobImportType.TabIndex = 16
        Me.cboJobImportType.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID"
        '
        'lblJobImportType
        '
        Me.lblJobImportType.Location = New System.Drawing.Point(11, 29)
        Me.lblJobImportType.Name = "lblJobImportType"
        Me.lblJobImportType.Size = New System.Drawing.Size(118, 20)
        Me.lblJobImportType.TabIndex = 15
        Me.lblJobImportType.Text = "Job Import Type"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(268, 210)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(101, 23)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save"
        '
        'btnRemoveType
        '
        Me.btnRemoveType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveType.Location = New System.Drawing.Point(14, 210)
        Me.btnRemoveType.Name = "btnRemoveType"
        Me.btnRemoveType.Size = New System.Drawing.Size(101, 23)
        Me.btnRemoveType.TabIndex = 12
        Me.btnRemoveType.Text = "Remove"
        '
        'grpEngineerSkillSOR
        '
        Me.grpEngineerSkillSOR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpEngineerSkillSOR.Controls.Add(Me.btnClearAll)
        Me.grpEngineerSkillSOR.Controls.Add(Me.grpEngineerSkills)
        Me.grpEngineerSkillSOR.Controls.Add(Me.btnFindSOR)
        Me.grpEngineerSkillSOR.Controls.Add(Me.txtSOR)
        Me.grpEngineerSkillSOR.Controls.Add(Me.lblSORName)
        Me.grpEngineerSkillSOR.Controls.Add(Me.btnSaveEngineerQual)
        Me.grpEngineerSkillSOR.Location = New System.Drawing.Point(760, 8)
        Me.grpEngineerSkillSOR.Name = "grpEngineerSkillSOR"
        Me.grpEngineerSkillSOR.Size = New System.Drawing.Size(375, 458)
        Me.grpEngineerSkillSOR.TabIndex = 27
        Me.grpEngineerSkillSOR.TabStop = False
        Me.grpEngineerSkillSOR.Text = "Engineer Skills SOR"
        '
        'btnClearAll
        '
        Me.btnClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClearAll.Location = New System.Drawing.Point(14, 419)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Size = New System.Drawing.Size(101, 23)
        Me.btnClearAll.TabIndex = 39
        Me.btnClearAll.Text = "Clear All"
        '
        'grpEngineerSkills
        '
        Me.grpEngineerSkills.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpEngineerSkills.Controls.Add(Me.dgEngineerQual)
        Me.grpEngineerSkills.Location = New System.Drawing.Point(14, 65)
        Me.grpEngineerSkills.Name = "grpEngineerSkills"
        Me.grpEngineerSkills.Size = New System.Drawing.Size(345, 348)
        Me.grpEngineerSkills.TabIndex = 15
        Me.grpEngineerSkills.TabStop = False
        Me.grpEngineerSkills.Text = "Qualifications / Skills"
        '
        'dgEngineerQual
        '
        Me.dgEngineerQual.DataMember = ""
        Me.dgEngineerQual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgEngineerQual.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgEngineerQual.Location = New System.Drawing.Point(3, 17)
        Me.dgEngineerQual.Name = "dgEngineerQual"
        Me.dgEngineerQual.Size = New System.Drawing.Size(339, 328)
        Me.dgEngineerQual.TabIndex = 13
        '
        'btnFindSOR
        '
        Me.btnFindSOR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindSOR.BackColor = System.Drawing.Color.White
        Me.btnFindSOR.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindSOR.Location = New System.Drawing.Point(327, 23)
        Me.btnFindSOR.Name = "btnFindSOR"
        Me.btnFindSOR.Size = New System.Drawing.Size(32, 23)
        Me.btnFindSOR.TabIndex = 38
        Me.btnFindSOR.Text = "..."
        Me.btnFindSOR.UseVisualStyleBackColor = False
        '
        'txtSOR
        '
        Me.txtSOR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSOR.Location = New System.Drawing.Point(182, 25)
        Me.txtSOR.MaxLength = 50
        Me.txtSOR.Name = "txtSOR"
        Me.txtSOR.ReadOnly = True
        Me.txtSOR.Size = New System.Drawing.Size(139, 21)
        Me.txtSOR.TabIndex = 18
        Me.txtSOR.Tag = "SystemScheduleOfRate.Code"
        '
        'lblSORName
        '
        Me.lblSORName.Location = New System.Drawing.Point(15, 28)
        Me.lblSORName.Name = "lblSORName"
        Me.lblSORName.Size = New System.Drawing.Size(162, 20)
        Me.lblSORName.TabIndex = 15
        Me.lblSORName.Text = "System Schedule of Rate"
        '
        'btnSaveEngineerQual
        '
        Me.btnSaveEngineerQual.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveEngineerQual.Location = New System.Drawing.Point(258, 422)
        Me.btnSaveEngineerQual.Name = "btnSaveEngineerQual"
        Me.btnSaveEngineerQual.Size = New System.Drawing.Size(101, 23)
        Me.btnSaveEngineerQual.TabIndex = 11
        Me.btnSaveEngineerQual.Text = "Save"
        '
        'UCSystemScheduleOfRate
        '
        Me.Controls.Add(Me.grpEngineerSkillSOR)
        Me.Controls.Add(Me.grpJobImportType)
        Me.Controls.Add(Me.grpSystemScheduleOfRate)
        Me.Name = "UCSystemScheduleOfRate"
        Me.Size = New System.Drawing.Size(1144, 735)
        Me.grpSystemScheduleOfRate.ResumeLayout(False)
        Me.grpSystemScheduleOfRate.PerformLayout()
        Me.grpSOR.ResumeLayout(False)
        CType(Me.dgRates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpJobImportType.ResumeLayout(False)
        Me.grpJobImportType.PerformLayout()
        Me.grpEngineerSkillSOR.ResumeLayout(False)
        Me.grpEngineerSkillSOR.PerformLayout()
        Me.grpEngineerSkills.ResumeLayout(False)
        CType(Me.dgEngineerQual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)

        Combo.SetUpCombo(cboScheduleOfRatesCategoryID,
                         DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.ScheduleRatesCategories).Table,
                         "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(cboJobType,
                         DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table,
                         "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(cboSORJobType,
                         DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table,
                         "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(cboJobImportType,
                         DB.JobImports.JobImportType_GetAll().Table,
                         "JobImportTypeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Throw New NotImplementedException
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _dvRates As DataView

    Private Property RatesDataview() As DataView
        Get
            Return _dvRates
        End Get
        Set(ByVal value As DataView)
            _dvRates = value
            _dvRates.AllowNew = False
            _dvRates.AllowEdit = False
            _dvRates.AllowDelete = False
            _dvRates.Table.TableName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString
            Me.dgRates.DataSource = RatesDataview
        End Set
    End Property

    Private ReadOnly Property SelectedRatesDataRow() As DataRow
        Get
            If Not Me.dgRates.CurrentRowIndex = -1 Then
                Return RatesDataview(Me.dgRates.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _dvEngineerQuals As DataView

    Private Property EngineerQualsDataview() As DataView
        Get
            Return _dvEngineerQuals
        End Get
        Set(ByVal value As DataView)
            _dvEngineerQuals = value
            _dvEngineerQuals.Table.TableName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString
            Me.dgEngineerQual.DataSource = EngineerQualsDataview
        End Set
    End Property

    Private ReadOnly Property SelectedEngineerQualDataRow() As DataRow
        Get
            If Not Me.dgEngineerQual.CurrentRowIndex = -1 Then
                Return EngineerQualsDataview(Me.dgEngineerQual.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _engineerQualSOR As Entity.SystemScheduleOfRates.SystemScheduleOfRate

    Public Property EngineerQualSOR() As Entity.SystemScheduleOfRates.SystemScheduleOfRate
        Get
            Return _engineerQualSOR
        End Get
        Set(ByVal Value As Entity.SystemScheduleOfRates.SystemScheduleOfRate)
            _engineerQualSOR = Value

            If _engineerQualSOR Is Nothing Then
                _engineerQualSOR = New Entity.SystemScheduleOfRates.SystemScheduleOfRate
                _engineerQualSOR.Exists = False
                Me.txtSOR.Text = String.Empty
            Else
                Me.txtSOR.Text = _engineerQualSOR.Description
            End If
        End Set
    End Property

    Private _engineerQual As Entity.PickLists.PickList

    Public Property EngineerQual() As Entity.PickLists.PickList
        Get
            Return _engineerQual
        End Get
        Set(ByVal Value As Entity.PickLists.PickList)
            _engineerQual = Value

            If _engineerQual Is Nothing Then
                _engineerQual = New Entity.PickLists.PickList
                _engineerQual.Exists = False
                Me.txtEngineerQual.Text = String.Empty
            Else
                Me.txtEngineerQual.Text = _engineerQual.Name
            End If
        End Set
    End Property

    Private _pageState As Entity.Sys.Enums.FormState

    Private Property PageState() As Entity.Sys.Enums.FormState
        Get
            Return _pageState
        End Get
        Set(ByVal Value As Entity.Sys.Enums.FormState)
            _pageState = Value
            PageSetup()
        End Set
    End Property

    Private _currentJobImportType As Entity.JobImport.JobImportType

    Public Property CurrentJobImportType() As Entity.JobImport.JobImportType
        Get
            Return _currentJobImportType
        End Get
        Set(ByVal Value As Entity.JobImport.JobImportType)
            _currentJobImportType = Value

            If _currentJobImportType Is Nothing Then
                _currentJobImportType = New Entity.JobImport.JobImportType
                _currentJobImportType.Exists = False
            End If
        End Set
    End Property

    Private _currentSystemScheduleOfRate As New Entity.SystemScheduleOfRates.SystemScheduleOfRate

    Public Property CurrentSystemScheduleOfRate() As Entity.SystemScheduleOfRates.SystemScheduleOfRate
        Get
            Return _currentSystemScheduleOfRate
        End Get
        Set(ByVal Value As Entity.SystemScheduleOfRates.SystemScheduleOfRate)
            _currentSystemScheduleOfRate = Value
        End Set
    End Property

#End Region

#Region "Setup"

    Public Sub SetupRatesDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgRates.TableStyles(0)

        Dim Category As New DataGridLabelColumn
        Category.Format = ""
        Category.FormatInfo = Nothing
        Category.HeaderText = "Category"
        Category.MappingName = "Category"
        Category.ReadOnly = True
        Category.Width = 100
        Category.NullText = ""
        tbStyle.GridColumnStyles.Add(Category)

        Dim Code As New DataGridLabelColumn
        Code.Format = ""
        Code.FormatInfo = Nothing
        Code.HeaderText = "Code"
        Code.MappingName = "Code"
        Code.ReadOnly = True
        Code.Width = 100
        Code.NullText = ""
        tbStyle.GridColumnStyles.Add(Code)

        Dim Description As New DataGridLabelColumn
        Description.Format = ""
        Description.FormatInfo = Nothing
        Description.HeaderText = "Description"
        Description.MappingName = "Description"
        Description.ReadOnly = True
        Description.Width = 250
        Description.NullText = ""
        tbStyle.GridColumnStyles.Add(Description)

        Dim TimeInMins As New DataGridLabelColumn
        TimeInMins.Format = ""
        TimeInMins.FormatInfo = Nothing
        TimeInMins.HeaderText = "Time (Mins)"
        TimeInMins.MappingName = "TimeInMins"
        TimeInMins.ReadOnly = True
        TimeInMins.Width = 80
        TimeInMins.NullText = ""
        tbStyle.GridColumnStyles.Add(TimeInMins)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Unit Price"
        Price.MappingName = "Price"
        Price.ReadOnly = True
        Price.Width = 80
        Price.NullText = ""
        tbStyle.GridColumnStyles.Add(Price)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString
        Me.dgRates.TableStyles.Add(tbStyle)
    End Sub

    Public Sub SetupEngineerQualDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgEngineerQual.TableStyles(0)

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tbStyle.GridColumnStyles.Add(Tick)

        Dim name As New DataGridLabelColumn
        name.Format = ""
        name.FormatInfo = Nothing
        name.HeaderText = "Name"
        name.MappingName = "Name"
        name.ReadOnly = True
        name.Width = 150
        name.NullText = ""
        tbStyle.GridColumnStyles.Add(name)

        Dim description As New DataGridLabelColumn
        description.Format = ""
        description.FormatInfo = Nothing
        description.HeaderText = "Description"
        description.MappingName = "Description"
        description.ReadOnly = True
        description.Width = 250
        description.NullText = ""
        tbStyle.GridColumnStyles.Add(description)

        Dim percentage As New DataGridLabelColumn
        percentage.Format = ""
        percentage.FormatInfo = Nothing
        percentage.HeaderText = "Percentage"
        percentage.MappingName = "Percentage"
        percentage.ReadOnly = True
        percentage.Width = 80
        percentage.NullText = ""
        tbStyle.GridColumnStyles.Add(percentage)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString
        Me.dgEngineerQual.TableStyles.Add(tbStyle)
    End Sub

    Private Sub PageSetup()
        If PageState = Entity.Sys.Enums.FormState.Insert Then
            btnAddNew.Text = "Cancel Add"
            btnAddUpdate.Text = "Add"
            dgRates.Enabled = False
            btnAddNew.Enabled = True
            btnRemove.Enabled = False
            btnAddUpdate.Enabled = True
            cboScheduleOfRatesCategoryID.Enabled = True
            cboSORJobType.Enabled = True
            txtCode.Enabled = True
            txtDescription.Enabled = True
            txtPrice.Enabled = True
            txtTimeInMins.Enabled = True

        ElseIf PageState = Entity.Sys.Enums.FormState.Update Then
            btnAddNew.Text = "Cancel Update"
            btnAddUpdate.Text = "Update"

            dgRates.Enabled = True
            btnAddNew.Enabled = True
            btnRemove.Enabled = True
            btnAddUpdate.Enabled = True
            If CBool(SelectedRatesDataRow("AllowDeleted")) = False Then
                Combo.SetSelectedComboItem_By_Value(cboScheduleOfRatesCategoryID, 0)
                Combo.SetSelectedComboItem_By_Value(cboSORJobType, 0)
                cboScheduleOfRatesCategoryID.Enabled = False
                cboSORJobType.Enabled = False
                txtCode.Enabled = False
                txtDescription.Enabled = False
            Else
                cboScheduleOfRatesCategoryID.Enabled = True
                cboSORJobType.Enabled = True
                txtCode.Enabled = True
                txtDescription.Enabled = True
            End If

            txtPrice.Enabled = True
            txtTimeInMins.Enabled = True
        Else 'Load
            btnAddNew.Text = "Add New"

            dgRates.Enabled = True
            btnAddNew.Enabled = True
            btnRemove.Enabled = False
            btnAddUpdate.Enabled = False
            cboScheduleOfRatesCategoryID.Enabled = False
            cboSORJobType.Enabled = False
            txtCode.Enabled = False
            txtDescription.Enabled = False
            txtPrice.Enabled = False
            txtTimeInMins.Enabled = False

            Combo.SetSelectedComboItem_By_Value(cboScheduleOfRatesCategoryID, 0)
            Combo.SetSelectedComboItem_By_Value(cboSORJobType, 0)
            Me.txtCode.Text = ""
            Me.txtDescription.Text = ""
            Me.txtPrice.Text = Format(0, "C")
            Me.txtTimeInMins.Text = ""
        End If
    End Sub

#End Region

#Region "Events"

    Private Sub UCSystemScheduleOfRate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        If PageState = Entity.Sys.Enums.FormState.Insert Or PageState = Entity.Sys.Enums.FormState.Update Then
            Populate()
            PageState = Entity.Sys.Enums.FormState.Load
        Else
            PageState = Entity.Sys.Enums.FormState.Insert
        End If
    End Sub

    Private Sub btnAddUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddUpdate.Click
        Save()
    End Sub

    Private Sub dgRates_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgRates.Click
        If Not SelectedRatesDataRow Is Nothing Then
            With SelectedRatesDataRow
                Combo.SetSelectedComboItem_By_Value(cboScheduleOfRatesCategoryID, .Item("ScheduleOfRatesCategoryID"))
                Combo.SetSelectedComboItem_By_Value(cboSORJobType, .Item("JobTypeID"))
                Me.txtCode.Text = .Item("Code")
                Me.txtDescription.Text = .Item("Description")
                Me.txtPrice.Text = Format(.Item("Price"), "C")
                Me.txtTimeInMins.Text = .Item("TimeInMins")
            End With
            PageState = Entity.Sys.Enums.FormState.Update
        Else
            PageState = Entity.Sys.Enums.FormState.Load
        End If

    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If Not SelectedRatesDataRow Is Nothing Then
            DeleteRate()
        Else
            PageState = Entity.Sys.Enums.FormState.Load
        End If
    End Sub

    Private Sub btnSaveEngineerQual_Click(sender As Object, e As EventArgs) Handles btnSaveEngineerQual.Click
        DB.SystemScheduleOfRate.SOREnginerQual_Delete(EngineerQualSOR.SystemScheduleOfRateID)
        For Each dr As DataRow In EngineerQualsDataview.Table.Rows
            If dr("Tick") = True Then
                DB.SystemScheduleOfRate.SOREnginerQual_Insert(EngineerQualSOR.SystemScheduleOfRateID, dr("ManagerID"))
            End If
        Next
    End Sub

    Private Sub btnAddNewType_Click(sender As Object, e As EventArgs) Handles btnAddNewType.Click
        Combo.SetUpCombo(cboJobImportType,
                         DB.JobImports.JobImportType_GetAll().Table,
                         "JobImportTypeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetSelectedComboItem_By_Value(cboJobType, 0)
        Me.txtJobTypeName.Text = String.Empty
        Me.txtEngineerQual.Text = String.Empty
        txtCycle.Text = String.Empty
    End Sub

    Private Sub btnFindSOR_Click(sender As Object, e As EventArgs) Handles btnFindSOR.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate)
        If Not ID = 0 Then
            EngineerQualSOR = DB.SystemScheduleOfRate.SystemScheduleOfRate_Get(ID)
            PopulateEngineerQuals(ID)
        End If
    End Sub

    Private Sub btnFindEngineerQual_Click(sender As Object, e As EventArgs) Handles btnFindEngineerQual.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblEngineerSkills)
        If Not ID = 0 Then
            EngineerQual = DB.Picklists.Get_One_As_Object(ID)
        End If
    End Sub

    Private Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
        For Each dr As DataRow In EngineerQualsDataview.Table.Select(EngineerQualsDataview.RowFilter)
            dr("Tick") = False
        Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If CurrentJobImportType Is Nothing Then
                CurrentJobImportType = New Entity.JobImport.JobImportType
            End If

            With CurrentJobImportType
                .SetJobImportTypeID = Combo.GetSelectedItemValue(cboJobImportType)
                .SetName = Me.txtJobTypeName.Text
                .SetJobTypeID = Combo.GetSelectedItemValue(cboJobType)
                .SetEngineerQualID = IIf(EngineerQual IsNot Nothing, EngineerQual.ManagerID, 0)
                .SetCycle = CInt(txtCycle.Text)
            End With

            Dim cVE As New Entity.JobImport.JobImportTypeValidator
            cVE.Validate(CurrentJobImportType)

            If CurrentJobImportType.Exists Then
                DB.JobImports.JobImportType_Update(CurrentJobImportType)
            Else
                CurrentJobImportType = DB.JobImports.JobImportType_Insert(CurrentJobImportType)
            End If
            ShowMessage("Job Import Type Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Combo.SetSelectedComboItem_By_Value(cboJobImportType, CurrentJobImportType.JobImportTypeID)
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnRemoveType_Click(sender As Object, e As EventArgs) Handles btnRemoveType.Click
        If ShowMessage("Are you sure you want to remove this job type?",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DB.JobImports.JobImportType_Delete(CurrentJobImportType)
            btnAddNewType_Click(sender, e)
        End If
    End Sub

    Private Sub dgEngineerQual_Click(sender As Object, e As EventArgs) Handles dgEngineerQual.Click
        If SelectedEngineerQualDataRow Is Nothing Then
            Exit Sub
        End If

        Dim selected As Boolean = Not CBool(Me.dgEngineerQual(Me.dgEngineerQual.CurrentRowIndex, 0))
        Me.dgEngineerQual(Me.dgEngineerQual.CurrentRowIndex, 0) = selected
    End Sub

    Private Sub cboJobImportType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboJobImportType.SelectedIndexChanged
        If ControlLoading = True Then
            Exit Sub
        End If
        CurrentJobImportType = DB.JobImports.JobImportType_Get(Combo.GetSelectedItemValue(cboJobImportType))

        If CurrentJobImportType.Exists Then
            txtJobTypeName.Text = CurrentJobImportType.Name
            Combo.SetSelectedComboItem_By_Value(cboJobType, CurrentJobImportType.JobTypeID)
            Me.txtEngineerQual.Text = DB.Picklists.Get_One_As_Object(CurrentJobImportType.EngineerQualID).Name
            txtCycle.Text = CurrentJobImportType.Cycle
        Else
            txtJobTypeName.Text = String.Empty
            Combo.SetSelectedComboItem_By_Value(cboJobType, 0)
            Me.txtEngineerQual.Text = String.Empty
            txtCycle.Text = String.Empty
        End If
    End Sub

#End Region

#Region "Functions"

    Public Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        RatesDataview = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll
        PopulateEngineerQuals()
        PageState = Entity.Sys.Enums.FormState.Load
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            If PageState = Entity.Sys.Enums.FormState.Update Then
                CurrentSystemScheduleOfRate.SetAllowDeleted = SelectedRatesDataRow("AllowDeleted")
            Else
                CurrentSystemScheduleOfRate.SetAllowDeleted = 1
            End If

            CurrentSystemScheduleOfRate.SetCode = Me.txtCode.Text.Trim
            CurrentSystemScheduleOfRate.SetDescription = Me.txtDescription.Text.Trim
            CurrentSystemScheduleOfRate.SetPrice = Replace(Me.txtPrice.Text.Trim, "£", "")
            CurrentSystemScheduleOfRate.SetTimeInMins = Me.txtTimeInMins.Text.Trim

            If CurrentSystemScheduleOfRate.AllowDeleted Then
                CurrentSystemScheduleOfRate.SetScheduleOfRatesCategoryID = Combo.GetSelectedItemValue(cboScheduleOfRatesCategoryID)
                CurrentSystemScheduleOfRate.SetJobTypeID = Combo.GetSelectedItemValue(cboSORJobType)
            Else
                CurrentSystemScheduleOfRate.SetScheduleOfRatesCategoryID = -1
                CurrentSystemScheduleOfRate.SetJobTypeID = 0
            End If

            Dim rV As New Entity.SystemScheduleOfRates.SystemScheduleOfRateValidator
            rV.Validate(CurrentSystemScheduleOfRate)

            If PageState = Entity.Sys.Enums.FormState.Update Then
                CurrentSystemScheduleOfRate.SetSystemScheduleOfRateID = SelectedRatesDataRow("SystemScheduleOfRateID")
                DB.SystemScheduleOfRate.Update(CurrentSystemScheduleOfRate)

                With CurrentSystemScheduleOfRate
                    'UPDATE ALL CUSTOMERS WHO ACCEPTS CHANGES
                    DB.CustomerScheduleOfRate.CustomerScheduleOfRates_UpdateForALL(.Price, .Description, .Code, .ScheduleOfRatesCategoryID, .TimeInMins)
                End With
            Else
                CurrentSystemScheduleOfRate = DB.SystemScheduleOfRate.Insert(CurrentSystemScheduleOfRate)
            End If

            Populate()
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Function

    Private Sub DeleteRate()
        Try
            With SelectedRatesDataRow

                If CBool(.Item("AllowDeleted")) Then
                    If MessageBox.Show("DELETE :" & .Item("Description"), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                        DB.SystemScheduleOfRate.Delete(.Item("SystemScheduleOfRateID"))
                        Populate()
                    End If
                Else
                    MessageBox.Show("This rate is a system default and cannot be deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End With
        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Sub PopulateEngineerQuals(Optional ByVal ID As Integer = 0)
        EngineerQualsDataview = DB.SystemScheduleOfRate.SOREnginerQual_Get_ForSOR(ID)
    End Sub

#End Region

End Class