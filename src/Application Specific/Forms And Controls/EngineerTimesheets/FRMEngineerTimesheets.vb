Public Class FRMEngineerTimesheets : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents grpFilter As System.Windows.Forms.GroupBox
    Friend WithEvents grpJobs As System.Windows.Forms.GroupBox
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkDateCreated As System.Windows.Forms.CheckBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents dgTimesheets As System.Windows.Forms.DataGrid
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents btnFindRecord As System.Windows.Forms.Button
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtJobNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtaddress As System.Windows.Forms.TextBox
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpJobs = New System.Windows.Forms.GroupBox()
        Me.dgTimesheets = New System.Windows.Forms.DataGrid()
        Me.grpFilter = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtJobNumber = New System.Windows.Forms.TextBox()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnFindRecord = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkDateCreated = New System.Windows.Forms.CheckBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtaddress = New System.Windows.Forms.TextBox()
        Me.grpJobs.SuspendLayout()
        CType(Me.dgTimesheets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpJobs
        '
        Me.grpJobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpJobs.Controls.Add(Me.dgTimesheets)
        Me.grpJobs.Location = New System.Drawing.Point(8, 217)
        Me.grpJobs.Name = "grpJobs"
        Me.grpJobs.Size = New System.Drawing.Size(828, 303)
        Me.grpJobs.TabIndex = 2
        Me.grpJobs.TabStop = False
        Me.grpJobs.Text = "Double Click To View / Edit"
        '
        'dgTimesheets
        '
        Me.dgTimesheets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgTimesheets.DataMember = ""
        Me.dgTimesheets.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgTimesheets.Location = New System.Drawing.Point(8, 30)
        Me.dgTimesheets.Name = "dgTimesheets"
        Me.dgTimesheets.Size = New System.Drawing.Size(812, 265)
        Me.dgTimesheets.TabIndex = 11
        '
        'grpFilter
        '
        Me.grpFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilter.Controls.Add(Me.Label2)
        Me.grpFilter.Controls.Add(Me.txtaddress)
        Me.grpFilter.Controls.Add(Me.Label1)
        Me.grpFilter.Controls.Add(Me.txtJobNumber)
        Me.grpFilter.Controls.Add(Me.btnFind)
        Me.grpFilter.Controls.Add(Me.btnFindRecord)
        Me.grpFilter.Controls.Add(Me.txtSearch)
        Me.grpFilter.Controls.Add(Me.dtpTo)
        Me.grpFilter.Controls.Add(Me.dtpFrom)
        Me.grpFilter.Controls.Add(Me.Label9)
        Me.grpFilter.Controls.Add(Me.Label8)
        Me.grpFilter.Controls.Add(Me.chkDateCreated)
        Me.grpFilter.Controls.Add(Me.lblSearch)
        Me.grpFilter.Controls.Add(Me.Label10)
        Me.grpFilter.Controls.Add(Me.cboType)
        Me.grpFilter.Location = New System.Drawing.Point(8, 40)
        Me.grpFilter.Name = "grpFilter"
        Me.grpFilter.Size = New System.Drawing.Size(828, 171)
        Me.grpFilter.TabIndex = 1
        Me.grpFilter.TabStop = False
        Me.grpFilter.Text = "Filter"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(518, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Job Number"
        '
        'txtJobNumber
        '
        Me.txtJobNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJobNumber.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJobNumber.Location = New System.Drawing.Point(636, 110)
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Size = New System.Drawing.Size(184, 21)
        Me.txtJobNumber.TabIndex = 19
        '
        'btnFind
        '
        Me.btnFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFind.BackColor = System.Drawing.Color.White
        Me.btnFind.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFind.Location = New System.Drawing.Point(728, 140)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(92, 23)
        Me.btnFind.TabIndex = 18
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = False
        '
        'btnFindRecord
        '
        Me.btnFindRecord.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindRecord.BackColor = System.Drawing.Color.White
        Me.btnFindRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindRecord.Location = New System.Drawing.Point(788, 51)
        Me.btnFindRecord.Name = "btnFindRecord"
        Me.btnFindRecord.Size = New System.Drawing.Size(32, 23)
        Me.btnFindRecord.TabIndex = 17
        Me.btnFindRecord.Text = "..."
        Me.btnFindRecord.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(136, 53)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.ReadOnly = True
        Me.txtSearch.Size = New System.Drawing.Size(644, 21)
        Me.txtSearch.TabIndex = 16
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(184, 118)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(224, 21)
        Me.dtpTo.TabIndex = 10
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(184, 86)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(224, 21)
        Me.dtpFrom.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(136, 115)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "To"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(136, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "From"
        '
        'chkDateCreated
        '
        Me.chkDateCreated.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkDateCreated.UseVisualStyleBackColor = True
        Me.chkDateCreated.Location = New System.Drawing.Point(17, 86)
        Me.chkDateCreated.Name = "chkDateCreated"
        Me.chkDateCreated.Size = New System.Drawing.Size(104, 24)
        Me.chkDateCreated.TabIndex = 8
        Me.chkDateCreated.Text = "Date Between"
        '
        'lblSearch
        '
        Me.lblSearch.Location = New System.Drawing.Point(16, 53)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(112, 20)
        Me.lblSearch.TabIndex = 2
        Me.lblSearch.Text = "Engineer"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 20)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Type"
        '
        'cboType
        '
        Me.cboType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Location = New System.Drawing.Point(136, 22)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(684, 21)
        Me.cboType.TabIndex = 1
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(8, 526)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(56, 23)
        Me.btnReset.TabIndex = 13
        Me.btnReset.Text = "Reset"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(772, 526)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(56, 23)
        Me.btnAdd.TabIndex = 14
        Me.btnAdd.Text = "Add"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(70, 526)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(56, 23)
        Me.btnDelete.TabIndex = 15
        Me.btnDelete.Text = "Delete"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(518, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Address"
        '
        'txtaddress
        '
        Me.txtaddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtaddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtaddress.Location = New System.Drawing.Point(636, 83)
        Me.txtaddress.Name = "txtaddress"
        Me.txtaddress.Size = New System.Drawing.Size(184, 21)
        Me.txtaddress.TabIndex = 21
        '
        'FRMEngineerTimesheets
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(844, 558)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.grpFilter)
        Me.Controls.Add(Me.grpJobs)
        Me.Controls.Add(Me.btnReset)
        Me.MinimumSize = New System.Drawing.Size(852, 592)
        Me.Name = "FRMEngineerTimesheets"
        Me.Text = "Engineer General Timesheets Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.btnReset, 0)
        Me.Controls.SetChildIndex(Me.grpJobs, 0)
        Me.Controls.SetChildIndex(Me.grpFilter, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.grpJobs.ResumeLayout(False)
        CType(Me.dgTimesheets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFilter.ResumeLayout(False)
        Me.grpFilter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        SetupTimesheetsDataGrid()
        Combo.SetUpCombo(Me.cboType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.TimeSheetTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)


        ResetFilters()


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

    Private _dvTimesheets As DataView
    Private Property TimesheetsDataview() As DataView
        Get
            Return _dvTimesheets
        End Get
        Set(ByVal value As DataView)
            _dvTimesheets = value
            _dvTimesheets.AllowNew = False
            _dvTimesheets.AllowEdit = False
            _dvTimesheets.AllowDelete = False
            _dvTimesheets.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerTimesheet.ToString
            Me.dgTimesheets.DataSource = TimesheetsDataview
        End Set
    End Property

    Private ReadOnly Property SelectedTimesheetDataRow() As DataRow
        Get
            If Not Me.dgTimesheets.CurrentRowIndex = -1 Then
                Return TimesheetsDataview(Me.dgTimesheets.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _oEngineer As Entity.Engineers.Engineer
    Public Property oEngineer() As Entity.Engineers.Engineer
        Get
            Return _oEngineer
        End Get
        Set(ByVal Value As Entity.Engineers.Engineer)
            _oEngineer = Value
            If Not _oEngineer Is Nothing Then
                Me.txtSearch.Text = oEngineer.Name
            Else
                Me.txtSearch.Text = ""
            End If
        End Set
    End Property


#End Region

#Region "Setup"

    Private Sub SetupTimesheetsDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgTimesheets.TableStyles(0)

        Dim Engineer As New DataGridLabelColumn
        Engineer.Format = ""
        Engineer.FormatInfo = Nothing
        Engineer.HeaderText = "Engineer"
        Engineer.MappingName = "Name"
        Engineer.ReadOnly = True
        Engineer.Width = 250
        Engineer.NullText = ""
        tbStyle.GridColumnStyles.Add(Engineer)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 150
        Type.NullText = ""
        tbStyle.GridColumnStyles.Add(Type)

        Dim Comments As New DataGridLabelColumn
        Comments.Format = ""
        Comments.FormatInfo = Nothing
        Comments.HeaderText = "Comments"
        Comments.MappingName = "Comments"
        Comments.ReadOnly = True
        Comments.Width = 300
        Comments.NullText = ""
        tbStyle.GridColumnStyles.Add(Comments)

        Dim StartDateTime As New DataGridLabelColumn
        StartDateTime.Format = "dd/MM/yyyy HH:mm"
        StartDateTime.FormatInfo = Nothing
        StartDateTime.HeaderText = "Start Date/Time"
        StartDateTime.MappingName = "StartDateTime"
        StartDateTime.ReadOnly = True
        StartDateTime.Width = 150
        StartDateTime.NullText = ""
        tbStyle.GridColumnStyles.Add(StartDateTime)

        Dim EndDateTime As New DataGridLabelColumn
        EndDateTime.Format = "dd/MM/yyyy HH:mm"
        EndDateTime.FormatInfo = Nothing
        EndDateTime.HeaderText = "End Date/Time"
        EndDateTime.MappingName = "EndDateTime"
        EndDateTime.ReadOnly = True
        EndDateTime.Width = 150
        EndDateTime.NullText = ""
        tbStyle.GridColumnStyles.Add(EndDateTime)

        Dim Address As New DataGridLabelColumn
        Address.Format = ""
        Address.FormatInfo = Nothing
        Address.HeaderText = "Address"
        Address.MappingName = "Address"
        Address.ReadOnly = True
        Address.Width = 300
        Address.NullText = ""
        tbStyle.GridColumnStyles.Add(Address)

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "Job Number"
        JobNumber.MappingName = "JobNumber"
        JobNumber.ReadOnly = True
        JobNumber.Width = 300
        JobNumber.NullText = ""
        tbStyle.GridColumnStyles.Add(JobNumber)


        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerTimesheet.ToString
        Me.dgTimesheets.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMOrderManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ResetFilters()
    End Sub

    Private Sub chkDateCreated_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateCreated.CheckedChanged
        If Me.chkDateCreated.Checked Then
            Me.dtpFrom.Enabled = True
            Me.dtpTo.Enabled = True
        Else
            Me.dtpFrom.Value = Today
            Me.dtpTo.Value = Today
            Me.dtpFrom.Enabled = False
            Me.dtpTo.Enabled = False
        End If
    End Sub

    Private Sub dgTimesheets_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgTimesheets.DoubleClick
        If SelectedTimesheetDataRow Is Nothing Then
            Exit Sub
        End If
        ShowForm(GetType(FRMEngineerTimesheet), True, New Object() {SelectedTimesheetDataRow.Item("EngineerTimeSheetID"), SelectedTimesheetDataRow.Item("Source")})
        RunFilter()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ShowForm(GetType(FRMEngineerTimesheet), True, New Object() {0})
        RunFilter()
    End Sub

    Private Sub btnFindRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindRecord.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblEngineer)
        If Not ID = 0 Then
            oEngineer = DB.Engineer.Engineer_Get(ID)
        End If
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        RunFilter()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If SelectedTimesheetDataRow Is Nothing Then
            Exit Sub
        End If
        If ShowMessage("Are you sure you want to delete this timesheet?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) =DialogResult.Yes Then
            DB.EngineerTimesheets.Delete(SelectedTimesheetDataRow("EngineerTimeSheetID"))
        End If
        RunFilter()
    End Sub

#End Region

#Region "Functions"

    Private Sub ResetFilters()

        Combo.SetSelectedComboItem_By_Value(Me.cboType, 0)
        Me.chkDateCreated.Checked = False
        Me.dtpFrom.Value = Today
        Me.dtpFrom.Enabled = False
        Me.dtpTo.Value = Today
        Me.dtpTo.Enabled = False
        Me.grpFilter.Enabled = True
        Me.txtSearch.Text = ""
    End Sub

    Private Sub RunFilter()


        Dim whereClause As String = " WHERE 1=1 "
        Dim whereClause2 As String = ""

        If Not oEngineer Is Nothing Then
            whereClause += " AND tblEngineer.EngineerID = " & oEngineer.EngineerID & ""
        End If



        If Not Combo.GetSelectedItemValue(Me.cboType) = 0 Then
            whereClause += " AND TimeSheetTypeID = " & Combo.GetSelectedItemValue(Me.cboType) & ""
        End If

        If Not txtJobNumber.Text.Length = 0 Then
            whereClause2 += " AND jobNumber = '" & txtJobNumber.Text & "'"
        End If

        If Not txtaddress.Text.Length = 0 Then
            whereClause2 += " AND Address1 LIKE '%" & txtaddress.Text & "%'"
        End If

        If Me.chkDateCreated.Checked Then
            whereClause += " AND TS.StartDateTime >= '" & Format(Me.dtpFrom.Value, "dd/MMM/yyyy 00:00:00") & "' AND TS.EndDateTime <= '" & Format(Me.dtpTo.Value, "dd/MMM/yyyy 23:59:59") & "'"
        End If

        TimesheetsDataview = DB.EngineerTimesheets.GetAll(whereClause, WhereClause2)

    End Sub

#End Region

End Class
