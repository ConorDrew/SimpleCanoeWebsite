Imports System.Collections.Generic

Public Class FRMJobSkills : Inherits FSM.FRMBaseForm : Implements IForm

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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents grpJobSkills As System.Windows.Forms.GroupBox

    Friend WithEvents dgSkills As System.Windows.Forms.DataGrid
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents cboJobType As ComboBox
    Friend WithEvents lblJobType As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents cboJobSkill As ComboBox
    Friend WithEvents lblJobSkill As Label
    Friend WithEvents grpSkillMatrix As GroupBox
    Friend WithEvents btnAddTypeSkill As Button
    Friend WithEvents cboTypeSkill As ComboBox
    Friend WithEvents lblTypeSkill As Label
    Friend WithEvents cboSkillType As ComboBox
    Friend WithEvents btnDeleteTypeSkill As Button
    Friend WithEvents lblSkillType As Label
    Friend WithEvents dgSkillMatrix As DataGrid
    Friend WithEvents grpJobImportType As GroupBox
    Friend WithEvents txtSkillTypeName As TextBox
    Friend WithEvents lblSkillTypeName As Label
    Friend WithEvents cboSkillType1 As ComboBox
    Friend WithEvents lblSkillType1 As Label
    Friend WithEvents btnSaveSkillType As Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpJobSkills = New System.Windows.Forms.GroupBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.cboJobSkill = New System.Windows.Forms.ComboBox()
        Me.lblJobSkill = New System.Windows.Forms.Label()
        Me.cboJobType = New System.Windows.Forms.ComboBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.lblJobType = New System.Windows.Forms.Label()
        Me.dgSkills = New System.Windows.Forms.DataGrid()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grpSkillMatrix = New System.Windows.Forms.GroupBox()
        Me.btnAddTypeSkill = New System.Windows.Forms.Button()
        Me.cboTypeSkill = New System.Windows.Forms.ComboBox()
        Me.lblTypeSkill = New System.Windows.Forms.Label()
        Me.cboSkillType = New System.Windows.Forms.ComboBox()
        Me.btnDeleteTypeSkill = New System.Windows.Forms.Button()
        Me.lblSkillType = New System.Windows.Forms.Label()
        Me.dgSkillMatrix = New System.Windows.Forms.DataGrid()
        Me.grpJobImportType = New System.Windows.Forms.GroupBox()
        Me.txtSkillTypeName = New System.Windows.Forms.TextBox()
        Me.lblSkillTypeName = New System.Windows.Forms.Label()
        Me.cboSkillType1 = New System.Windows.Forms.ComboBox()
        Me.lblSkillType1 = New System.Windows.Forms.Label()
        Me.btnSaveSkillType = New System.Windows.Forms.Button()
        Me.grpJobSkills.SuspendLayout()
        CType(Me.dgSkills, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSkillMatrix.SuspendLayout()
        CType(Me.dgSkillMatrix, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpJobImportType.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpJobSkills
        '
        Me.grpJobSkills.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpJobSkills.Controls.Add(Me.btnAdd)
        Me.grpJobSkills.Controls.Add(Me.cboJobSkill)
        Me.grpJobSkills.Controls.Add(Me.lblJobSkill)
        Me.grpJobSkills.Controls.Add(Me.cboJobType)
        Me.grpJobSkills.Controls.Add(Me.btnDelete)
        Me.grpJobSkills.Controls.Add(Me.lblJobType)
        Me.grpJobSkills.Controls.Add(Me.dgSkills)
        Me.grpJobSkills.Location = New System.Drawing.Point(8, 53)
        Me.grpJobSkills.Name = "grpJobSkills"
        Me.grpJobSkills.Size = New System.Drawing.Size(1042, 321)
        Me.grpJobSkills.TabIndex = 1
        Me.grpJobSkills.TabStop = False
        Me.grpJobSkills.Text = "Job Skills"
        '
        'btnAdd
        '
        Me.btnAdd.AccessibleDescription = "Save item"
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.ImageIndex = 1
        Me.btnAdd.Location = New System.Drawing.Point(880, 18)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(154, 23)
        Me.btnAdd.TabIndex = 33
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'cboJobSkill
        '
        Me.cboJobSkill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboJobSkill.FormattingEnabled = True
        Me.cboJobSkill.Location = New System.Drawing.Point(333, 20)
        Me.cboJobSkill.Name = "cboJobSkill"
        Me.cboJobSkill.Size = New System.Drawing.Size(541, 21)
        Me.cboJobSkill.TabIndex = 32
        '
        'lblJobSkill
        '
        Me.lblJobSkill.AutoSize = True
        Me.lblJobSkill.Location = New System.Drawing.Point(296, 23)
        Me.lblJobSkill.Name = "lblJobSkill"
        Me.lblJobSkill.Size = New System.Drawing.Size(31, 13)
        Me.lblJobSkill.TabIndex = 31
        Me.lblJobSkill.Text = "Skill"
        '
        'cboJobType
        '
        Me.cboJobType.FormattingEnabled = True
        Me.cboJobType.Location = New System.Drawing.Point(73, 20)
        Me.cboJobType.Name = "cboJobType"
        Me.cboJobType.Size = New System.Drawing.Size(204, 21)
        Me.cboJobType.TabIndex = 3
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleDescription = "Save item"
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.ImageIndex = 1
        Me.btnDelete.Location = New System.Drawing.Point(880, 292)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(154, 23)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'lblJobType
        '
        Me.lblJobType.AutoSize = True
        Me.lblJobType.Location = New System.Drawing.Point(12, 23)
        Me.lblJobType.Name = "lblJobType"
        Me.lblJobType.Size = New System.Drawing.Size(57, 13)
        Me.lblJobType.TabIndex = 2
        Me.lblJobType.Text = "Job Type"
        '
        'dgSkills
        '
        Me.dgSkills.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSkills.DataMember = ""
        Me.dgSkills.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSkills.Location = New System.Drawing.Point(8, 47)
        Me.dgSkills.Name = "dgSkills"
        Me.dgSkills.Size = New System.Drawing.Size(1026, 239)
        Me.dgSkills.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.AccessibleDescription = "Save item"
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.ImageIndex = 1
        Me.btnClose.Location = New System.Drawing.Point(8, 621)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grpSkillMatrix
        '
        Me.grpSkillMatrix.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSkillMatrix.Controls.Add(Me.btnAddTypeSkill)
        Me.grpSkillMatrix.Controls.Add(Me.cboTypeSkill)
        Me.grpSkillMatrix.Controls.Add(Me.lblTypeSkill)
        Me.grpSkillMatrix.Controls.Add(Me.cboSkillType)
        Me.grpSkillMatrix.Controls.Add(Me.btnDeleteTypeSkill)
        Me.grpSkillMatrix.Controls.Add(Me.lblSkillType)
        Me.grpSkillMatrix.Controls.Add(Me.dgSkillMatrix)
        Me.grpSkillMatrix.Location = New System.Drawing.Point(8, 391)
        Me.grpSkillMatrix.Name = "grpSkillMatrix"
        Me.grpSkillMatrix.Size = New System.Drawing.Size(741, 224)
        Me.grpSkillMatrix.TabIndex = 34
        Me.grpSkillMatrix.TabStop = False
        Me.grpSkillMatrix.Text = "Skills Matrix"
        '
        'btnAddTypeSkill
        '
        Me.btnAddTypeSkill.AccessibleDescription = "Save item"
        Me.btnAddTypeSkill.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddTypeSkill.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddTypeSkill.ImageIndex = 1
        Me.btnAddTypeSkill.Location = New System.Drawing.Point(579, 18)
        Me.btnAddTypeSkill.Name = "btnAddTypeSkill"
        Me.btnAddTypeSkill.Size = New System.Drawing.Size(154, 23)
        Me.btnAddTypeSkill.TabIndex = 33
        Me.btnAddTypeSkill.Text = "Add"
        Me.btnAddTypeSkill.UseVisualStyleBackColor = True
        '
        'cboTypeSkill
        '
        Me.cboTypeSkill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTypeSkill.FormattingEnabled = True
        Me.cboTypeSkill.Location = New System.Drawing.Point(333, 20)
        Me.cboTypeSkill.Name = "cboTypeSkill"
        Me.cboTypeSkill.Size = New System.Drawing.Size(240, 21)
        Me.cboTypeSkill.TabIndex = 32
        '
        'lblTypeSkill
        '
        Me.lblTypeSkill.AutoSize = True
        Me.lblTypeSkill.Location = New System.Drawing.Point(296, 23)
        Me.lblTypeSkill.Name = "lblTypeSkill"
        Me.lblTypeSkill.Size = New System.Drawing.Size(31, 13)
        Me.lblTypeSkill.TabIndex = 31
        Me.lblTypeSkill.Text = "Skill"
        '
        'cboSkillType
        '
        Me.cboSkillType.FormattingEnabled = True
        Me.cboSkillType.Location = New System.Drawing.Point(73, 20)
        Me.cboSkillType.Name = "cboSkillType"
        Me.cboSkillType.Size = New System.Drawing.Size(204, 21)
        Me.cboSkillType.TabIndex = 3
        '
        'btnDeleteTypeSkill
        '
        Me.btnDeleteTypeSkill.AccessibleDescription = "Save item"
        Me.btnDeleteTypeSkill.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteTypeSkill.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDeleteTypeSkill.ImageIndex = 1
        Me.btnDeleteTypeSkill.Location = New System.Drawing.Point(579, 195)
        Me.btnDeleteTypeSkill.Name = "btnDeleteTypeSkill"
        Me.btnDeleteTypeSkill.Size = New System.Drawing.Size(154, 23)
        Me.btnDeleteTypeSkill.TabIndex = 2
        Me.btnDeleteTypeSkill.Text = "Delete"
        Me.btnDeleteTypeSkill.UseVisualStyleBackColor = True
        '
        'lblSkillType
        '
        Me.lblSkillType.AutoSize = True
        Me.lblSkillType.Location = New System.Drawing.Point(7, 23)
        Me.lblSkillType.Name = "lblSkillType"
        Me.lblSkillType.Size = New System.Drawing.Size(62, 13)
        Me.lblSkillType.TabIndex = 2
        Me.lblSkillType.Text = "Skill Type"
        '
        'dgSkillMatrix
        '
        Me.dgSkillMatrix.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSkillMatrix.DataMember = ""
        Me.dgSkillMatrix.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSkillMatrix.Location = New System.Drawing.Point(8, 47)
        Me.dgSkillMatrix.Name = "dgSkillMatrix"
        Me.dgSkillMatrix.Size = New System.Drawing.Size(725, 142)
        Me.dgSkillMatrix.TabIndex = 1
        '
        'grpJobImportType
        '
        Me.grpJobImportType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpJobImportType.Controls.Add(Me.txtSkillTypeName)
        Me.grpJobImportType.Controls.Add(Me.lblSkillTypeName)
        Me.grpJobImportType.Controls.Add(Me.cboSkillType1)
        Me.grpJobImportType.Controls.Add(Me.lblSkillType1)
        Me.grpJobImportType.Controls.Add(Me.btnSaveSkillType)
        Me.grpJobImportType.Location = New System.Drawing.Point(755, 391)
        Me.grpJobImportType.Name = "grpJobImportType"
        Me.grpJobImportType.Size = New System.Drawing.Size(287, 126)
        Me.grpJobImportType.TabIndex = 35
        Me.grpJobImportType.TabStop = False
        Me.grpJobImportType.Text = "Skill Types"
        '
        'txtSkillTypeName
        '
        Me.txtSkillTypeName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSkillTypeName.Location = New System.Drawing.Point(138, 60)
        Me.txtSkillTypeName.MaxLength = 50
        Me.txtSkillTypeName.Name = "txtSkillTypeName"
        Me.txtSkillTypeName.Size = New System.Drawing.Size(142, 21)
        Me.txtSkillTypeName.TabIndex = 18
        Me.txtSkillTypeName.Tag = "SystemScheduleOfRate.Code"
        '
        'lblSkillTypeName
        '
        Me.lblSkillTypeName.Location = New System.Drawing.Point(11, 63)
        Me.lblSkillTypeName.Name = "lblSkillTypeName"
        Me.lblSkillTypeName.Size = New System.Drawing.Size(100, 20)
        Me.lblSkillTypeName.TabIndex = 17
        Me.lblSkillTypeName.Text = "Skill Type Name"
        '
        'cboSkillType1
        '
        Me.cboSkillType1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSkillType1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboSkillType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSkillType1.Location = New System.Drawing.Point(138, 26)
        Me.cboSkillType1.Name = "cboSkillType1"
        Me.cboSkillType1.Size = New System.Drawing.Size(142, 21)
        Me.cboSkillType1.TabIndex = 16
        Me.cboSkillType1.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID"
        '
        'lblSkillType1
        '
        Me.lblSkillType1.Location = New System.Drawing.Point(11, 29)
        Me.lblSkillType1.Name = "lblSkillType1"
        Me.lblSkillType1.Size = New System.Drawing.Size(118, 20)
        Me.lblSkillType1.TabIndex = 15
        Me.lblSkillType1.Text = "Skill Type"
        '
        'btnSaveSkillType
        '
        Me.btnSaveSkillType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveSkillType.Location = New System.Drawing.Point(179, 97)
        Me.btnSaveSkillType.Name = "btnSaveSkillType"
        Me.btnSaveSkillType.Size = New System.Drawing.Size(101, 23)
        Me.btnSaveSkillType.TabIndex = 11
        Me.btnSaveSkillType.Text = "Save"
        '
        'FRMJobSkills
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(1058, 656)
        Me.Controls.Add(Me.grpJobImportType)
        Me.Controls.Add(Me.grpSkillMatrix)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grpJobSkills)
        Me.MinimumSize = New System.Drawing.Size(793, 520)
        Me.Name = "FRMJobSkills"
        Me.Text = "Skills"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpJobSkills, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.grpSkillMatrix, 0)
        Me.Controls.SetChildIndex(Me.grpJobImportType, 0)
        Me.grpJobSkills.ResumeLayout(False)
        Me.grpJobSkills.PerformLayout()
        CType(Me.dgSkills, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSkillMatrix.ResumeLayout(False)
        Me.grpSkillMatrix.PerformLayout()
        CType(Me.dgSkillMatrix, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpJobImportType.ResumeLayout(False)
        Me.grpJobImportType.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        SetupDataGrid()
        SetupSkillMatrixDataGrid()
        Combo.SetUpCombo(Me.cboJobType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSkillType, DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSkillType1, DB.Skills.SkillType_GetAll().Table, "SkillTypeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboJobSkill, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Engineer_Levels).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        UpdateSkillsDropDown()

        JobSkills = New DataView(DB.EngineerLevel.Get_List_For_JobType_GetALL)
        SkillsMatrix = DB.Skills.SkillMatrix_GetAll()
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

    Private _skillType As Entity.Skills.SkillType

    Public Property CurrentSkillType() As Entity.Skills.SkillType
        Get
            Return _skillType
        End Get
        Set(ByVal Value As Entity.Skills.SkillType)
            _skillType = Value

            If CurrentSkillType Is Nothing Then
                CurrentSkillType = New Entity.Skills.SkillType
                CurrentSkillType.Exists = False
            End If
        End Set
    End Property

    Private _JobSkills As DataView

    Private Property JobSkills() As DataView
        Get
            Return _JobSkills
        End Get
        Set(ByVal value As DataView)
            _JobSkills = value
            _JobSkills.AllowNew = False
            _JobSkills.AllowEdit = False
            _JobSkills.AllowDelete = False
            _JobSkills.Table.TableName = "JobSkills"
            Me.dgSkills.DataSource = JobSkills
        End Set
    End Property

    Private _SkillsMatrix As DataView

    Private Property SkillsMatrix() As DataView
        Get
            Return _SkillsMatrix
        End Get
        Set(ByVal value As DataView)
            _SkillsMatrix = value
            _SkillsMatrix.AllowNew = False
            _SkillsMatrix.AllowEdit = False
            _SkillsMatrix.AllowDelete = False
            _SkillsMatrix.Table.TableName = "SkillsMatrix"
            Me.dgSkillMatrix.DataSource = SkillsMatrix
        End Set
    End Property

    Private ReadOnly Property SelectedJobSkillDataRow() As DataRow
        Get
            If Not Me.dgSkills.CurrentRowIndex = -1 Then
                Return JobSkills(Me.dgSkills.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private ReadOnly Property SelectedSkillMatrixDataRow() As DataRow
        Get
            If Not Me.dgSkillMatrix.CurrentRowIndex = -1 Then
                Return SkillsMatrix(Me.dgSkillMatrix.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Private Sub SetupDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgSkills)
        Dim tbStyle As DataGridTableStyle = Me.dgSkills.TableStyles(0)

        Dim JobTypeID As New DataGridLabelColumn
        JobTypeID.Format = ""
        JobTypeID.FormatInfo = Nothing
        JobTypeID.HeaderText = "JobTypeID"
        JobTypeID.MappingName = "JobTypeID"
        JobTypeID.ReadOnly = True

        JobTypeID.Width = 5
        JobTypeID.NullText = ""
        tbStyle.GridColumnStyles.Add(JobTypeID)

        Dim SkillID As New DataGridLabelColumn
        SkillID.Format = ""
        SkillID.FormatInfo = Nothing
        SkillID.HeaderText = "SkillID"
        SkillID.MappingName = "SkillID"
        SkillID.ReadOnly = True
        SkillID.Width = 5
        SkillID.NullText = ""
        tbStyle.GridColumnStyles.Add(SkillID)

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "Job Type"
        JobNumber.MappingName = "JobType"
        JobNumber.ReadOnly = True
        JobNumber.Width = 150
        JobNumber.NullText = ""
        tbStyle.GridColumnStyles.Add(JobNumber)

        Dim FullName As New DataGridLabelColumn
        FullName.Format = ""
        FullName.FormatInfo = Nothing
        FullName.HeaderText = "Skill"
        FullName.MappingName = "Skill"
        FullName.ReadOnly = True
        FullName.Width = 150
        FullName.NullText = ""
        tbStyle.GridColumnStyles.Add(FullName)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = "JobSkills"
        Me.dgSkills.TableStyles.Add(tbStyle)

    End Sub

    Private Sub SetupSkillMatrixDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgSkillMatrix)
        Dim tbStyle As DataGridTableStyle = Me.dgSkillMatrix.TableStyles(0)

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "Skill"
        JobNumber.MappingName = "Skill"
        JobNumber.ReadOnly = True
        JobNumber.Width = 400
        JobNumber.NullText = ""
        tbStyle.GridColumnStyles.Add(JobNumber)

        Dim FullName As New DataGridLabelColumn
        FullName.Format = ""
        FullName.FormatInfo = Nothing
        FullName.HeaderText = "Skill Type"
        FullName.MappingName = "SkillType"
        FullName.ReadOnly = True
        FullName.Width = 200
        FullName.NullText = ""
        tbStyle.GridColumnStyles.Add(FullName)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = "SkillsMatrix"
        Me.dgSkillMatrix.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMJobLocks_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If SelectedJobSkillDataRow Is Nothing Then
            ShowMessage("Please select a line to remove", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If EnterOverridePassword() = True Then
            If ShowMessage("Are you sure you wish to delete this row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If

            Try
                Cursor.Current = Cursors.WaitCursor

                DB.EngineerLevel.EngineerLevel_Delete_For_JobType(SelectedJobSkillDataRow("JobTypeID"), SelectedJobSkillDataRow("SkillID"))
                JobSkills = New DataView(DB.EngineerLevel.Get_List_For_JobType_GetALL)
            Catch ex As Exception
                ShowMessage("Error unlocking job : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor.Current = Cursors.Default
            End Try

        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Combo.GetSelectedItemValue(cboJobSkill) > 0 And Combo.GetSelectedItemValue(cboJobType) > 0 Then
            DB.EngineerLevel.EngineerLevel_Insert_For_JobType(Combo.GetSelectedItemValue(cboJobType), Combo.GetSelectedItemValue(cboJobSkill))
            JobSkills = New DataView(DB.EngineerLevel.Get_List_For_JobType_GetALL)
        End If
    End Sub

    Private Sub btnSaveSkillType_Click(sender As Object, e As EventArgs) Handles btnSaveSkillType.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If CurrentSkillType Is Nothing Then
                CurrentSkillType = New Entity.Skills.SkillType
            End If

            With CurrentSkillType
                .SetName = Me.txtSkillTypeName.Text
            End With

            If CurrentSkillType.Exists Then
                DB.Skills.SkillType_Update(CurrentSkillType)
            Else
                CurrentSkillType = DB.Skills.SkillType_Insert(CurrentSkillType)
            End If
            ShowMessage("Skill Type Saved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CurrentSkillType = Nothing
            Me.txtSkillTypeName.Text = String.Empty
            LoadMe(sender, e)
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnAddTypeSkill_Click(sender As Object, e As EventArgs) Handles btnAddTypeSkill.Click
        Dim skillTypeId As Integer = Entity.Sys.Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboSkillType))
        Dim skillId As Integer = Entity.Sys.Helper.MakeIntegerValid(cboTypeSkill.SelectedValue)

        If skillTypeId = 0 Then Exit Sub
        If skillId = 0 Then Exit Sub

        'check if skill is associated to any other skill
        Dim skillTypeCheck As DataView = DB.Skills.SkillType_Get_BySkill(skillId)
        If skillTypeCheck.Count > 0 Then
            ShowMessage(Combo.GetSelectedItemDescription(cboTypeSkill) & " is linked to " &
                        skillTypeCheck.Table.Rows(0)("Name").ToString() & "!" & vbCrLf & vbCrLf &
                        "Please deleted this link", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            Dim skillMatrixId As Integer = DB.Skills.SkillMatrix_Insert(skillId, skillTypeId)
            If skillTypeId = 0 Then Throw New Exception("Data cannot save")
            SkillsMatrix = DB.Skills.SkillMatrix_GetAll_ByType(skillTypeId)
            UpdateSkillsDropDown()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub btnDeleteTypeSkill_Click(sender As Object, e As EventArgs) Handles btnDeleteTypeSkill.Click
        If SelectedSkillMatrixDataRow Is Nothing Then
            ShowMessage("Please select a line to remove", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim _ssmList As New List(Of Entity.Sys.Enums.SecuritySystemModules)
        _ssmList.Add(Entity.Sys.Enums.SecuritySystemModules.IT)
        _ssmList.Add(Entity.Sys.Enums.SecuritySystemModules.Compliance)

        If loggedInUser.HasAccessToMulitpleModules(_ssmList) = True Then
            If ShowMessage("Are you sure you wish to delete this row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                Exit Sub
            End If

            Try
                Cursor.Current = Cursors.WaitCursor
                DB.Skills.SkillMatrix_Delete(SelectedSkillMatrixDataRow("SkillMatrixID"))
                Combo.SetSelectedComboItem_By_Value(cboSkillType, "0")
                UpdateSkillsDropDown()
            Catch ex As Exception
                ShowMessage("Error deleting: " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor.Current = Cursors.Default
            End Try

        End If
    End Sub

    Private Sub cboSkillType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSkillType.SelectedIndexChanged
        Try
            Dim skillTypeId As Integer = Entity.Sys.Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboSkillType))
            If skillTypeId > 0 Then
                SkillsMatrix = DB.Skills.SkillMatrix_GetAll_ByType(skillTypeId)
            Else
                SkillsMatrix = DB.Skills.SkillMatrix_GetAll()
            End If
        Catch ex As Exception
            ShowMessage("Error" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateSkillsDropDown()
        Me.cboTypeSkill.DataSource = DB.Skills.Skills_GetAllNotAssignedType().Table
        Me.cboTypeSkill.DisplayMember = "Skill"
        Me.cboTypeSkill.ValueMember = "SkillID"
    End Sub

#End Region

End Class