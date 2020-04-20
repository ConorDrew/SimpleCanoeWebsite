Public Class FRMEngineerTimesheetReport : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Select Case True
            Case IsGasway
                Combo.SetUpCombo(Me.cboDept, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Department).Table, "Name", "Name", Entity.Sys.Enums.ComboValues.Please_Select_Negative)
            Case Else
                Combo.SetUpCombo(Me.cboDept, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Department).Table, "Name", "Description", Entity.Sys.Enums.ComboValues.Please_Select_Negative)
        End Select

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
    Friend WithEvents txtJobNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnRunReport As System.Windows.Forms.Button
    Friend WithEvents dgEngineers As System.Windows.Forms.DataGrid
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnSummary As System.Windows.Forms.Button
    Friend WithEvents lblDept As System.Windows.Forms.Label
    Friend WithEvents cboDept As System.Windows.Forms.ComboBox
    Friend WithEvents dgTimesheets As System.Windows.Forms.DataGrid

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpJobs = New System.Windows.Forms.GroupBox()
        Me.dgTimesheets = New System.Windows.Forms.DataGrid()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.grpFilter = New System.Windows.Forms.GroupBox()
        Me.cboDept = New System.Windows.Forms.ComboBox()
        Me.lblDept = New System.Windows.Forms.Label()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.dgEngineers = New System.Windows.Forms.DataGrid()
        Me.btnRunReport = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.txtJobNumber = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnSummary = New System.Windows.Forms.Button()
        Me.grpJobs.SuspendLayout()
        CType(Me.dgTimesheets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFilter.SuspendLayout()
        CType(Me.dgEngineers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpJobs
        '
        Me.grpJobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpJobs.Controls.Add(Me.dgTimesheets)
        Me.grpJobs.Location = New System.Drawing.Point(8, 239)
        Me.grpJobs.Name = "grpJobs"
        Me.grpJobs.Size = New System.Drawing.Size(844, 409)
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
        Me.dgTimesheets.Location = New System.Drawing.Point(8, 19)
        Me.dgTimesheets.Name = "dgTimesheets"
        Me.dgTimesheets.Size = New System.Drawing.Size(828, 382)
        Me.dgTimesheets.TabIndex = 14
        '
        'btnExport
        '
        Me.btnExport.AccessibleDescription = "Export Job List To Excel"
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(8, 656)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(56, 23)
        Me.btnExport.TabIndex = 15
        Me.btnExport.Text = "Export"
        '
        'grpFilter
        '
        Me.grpFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilter.Controls.Add(Me.cboDept)
        Me.grpFilter.Controls.Add(Me.lblDept)
        Me.grpFilter.Controls.Add(Me.btnClearAll)
        Me.grpFilter.Controls.Add(Me.btnSelectAll)
        Me.grpFilter.Controls.Add(Me.dgEngineers)
        Me.grpFilter.Controls.Add(Me.btnRunReport)
        Me.grpFilter.Controls.Add(Me.Label4)
        Me.grpFilter.Controls.Add(Me.dtpTo)
        Me.grpFilter.Controls.Add(Me.dtpFrom)
        Me.grpFilter.Controls.Add(Me.txtJobNumber)
        Me.grpFilter.Controls.Add(Me.Label9)
        Me.grpFilter.Controls.Add(Me.Label8)
        Me.grpFilter.Controls.Add(Me.Label6)
        Me.grpFilter.Location = New System.Drawing.Point(8, 32)
        Me.grpFilter.Name = "grpFilter"
        Me.grpFilter.Size = New System.Drawing.Size(844, 201)
        Me.grpFilter.TabIndex = 1
        Me.grpFilter.TabStop = False
        Me.grpFilter.Text = "Filter"
        '
        'cboDept
        '
        Me.cboDept.Location = New System.Drawing.Point(367, 35)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New System.Drawing.Size(126, 21)
        Me.cboDept.TabIndex = 30
        '
        'lblDept
        '
        Me.lblDept.BackColor = System.Drawing.Color.White
        Me.lblDept.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDept.Location = New System.Drawing.Point(364, 16)
        Me.lblDept.Name = "lblDept"
        Me.lblDept.Size = New System.Drawing.Size(103, 16)
        Me.lblDept.TabIndex = 29
        Me.lblDept.Text = "Department"
        '
        'btnClearAll
        '
        Me.btnClearAll.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnClearAll.Location = New System.Drawing.Point(148, 11)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Size = New System.Drawing.Size(64, 23)
        Me.btnClearAll.TabIndex = 28
        Me.btnClearAll.Text = "Clear All"
        Me.btnClearAll.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnSelectAll.Location = New System.Drawing.Point(78, 11)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(64, 23)
        Me.btnSelectAll.TabIndex = 27
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'dgEngineers
        '
        Me.dgEngineers.AllowNavigation = False
        Me.dgEngineers.AlternatingBackColor = System.Drawing.Color.GhostWhite
        Me.dgEngineers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgEngineers.BackgroundColor = System.Drawing.Color.White
        Me.dgEngineers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgEngineers.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.dgEngineers.CaptionForeColor = System.Drawing.Color.White
        Me.dgEngineers.CaptionText = "Engineers"
        Me.dgEngineers.CaptionVisible = False
        Me.dgEngineers.DataMember = ""
        Me.dgEngineers.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.dgEngineers.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgEngineers.GridLineColor = System.Drawing.Color.RoyalBlue
        Me.dgEngineers.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.dgEngineers.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.dgEngineers.HeaderForeColor = System.Drawing.Color.Lavender
        Me.dgEngineers.LinkColor = System.Drawing.Color.Teal
        Me.dgEngineers.Location = New System.Drawing.Point(11, 35)
        Me.dgEngineers.Name = "dgEngineers"
        Me.dgEngineers.ParentRowsBackColor = System.Drawing.Color.Lavender
        Me.dgEngineers.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        Me.dgEngineers.ParentRowsVisible = False
        Me.dgEngineers.RowHeadersVisible = False
        Me.dgEngineers.SelectionBackColor = System.Drawing.Color.Teal
        Me.dgEngineers.SelectionForeColor = System.Drawing.Color.PaleGreen
        Me.dgEngineers.Size = New System.Drawing.Size(350, 141)
        Me.dgEngineers.TabIndex = 26
        '
        'btnRunReport
        '
        Me.btnRunReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRunReport.Location = New System.Drawing.Point(747, 172)
        Me.btnRunReport.Name = "btnRunReport"
        Me.btnRunReport.Size = New System.Drawing.Size(91, 23)
        Me.btnRunReport.TabIndex = 25
        Me.btnRunReport.Text = "Run Report"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Engineers"
        '
        'dtpTo
        '
        Me.dtpTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpTo.Location = New System.Drawing.Point(686, 47)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(144, 21)
        Me.dtpTo.TabIndex = 13
        '
        'dtpFrom
        '
        Me.dtpFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFrom.Location = New System.Drawing.Point(686, 20)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(144, 21)
        Me.dtpFrom.TabIndex = 12
        '
        'txtJobNumber
        '
        Me.txtJobNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJobNumber.Location = New System.Drawing.Point(686, 74)
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Size = New System.Drawing.Size(144, 21)
        Me.txtJobNumber.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Location = New System.Drawing.Point(654, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "To"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.Location = New System.Drawing.Point(592, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Date From"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Location = New System.Drawing.Point(592, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Job Number"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(72, 656)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(56, 23)
        Me.btnReset.TabIndex = 16
        Me.btnReset.Text = "Reset"
        '
        'btnSummary
        '
        Me.btnSummary.AccessibleDescription = "Export Job List To Excel"
        Me.btnSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSummary.Location = New System.Drawing.Point(755, 656)
        Me.btnSummary.Name = "btnSummary"
        Me.btnSummary.Size = New System.Drawing.Size(89, 23)
        Me.btnSummary.TabIndex = 17
        Me.btnSummary.Text = "Summary"
        '
        'FRMEngineerTimesheetReport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(860, 686)
        Me.Controls.Add(Me.btnSummary)
        Me.Controls.Add(Me.grpFilter)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.grpJobs)
        Me.Controls.Add(Me.btnReset)
        Me.MinimumSize = New System.Drawing.Size(808, 528)
        Me.Name = "FRMEngineerTimesheetReport"
        Me.Text = "Engineer Timesheet Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.btnReset, 0)
        Me.Controls.SetChildIndex(Me.grpJobs, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.grpFilter, 0)
        Me.Controls.SetChildIndex(Me.btnSummary, 0)
        Me.grpJobs.ResumeLayout(False)
        CType(Me.dgTimesheets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFilter.ResumeLayout(False)
        Me.grpFilter.PerformLayout()
        CType(Me.dgEngineers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        SetupComboBoxes()
        SetupTimesheetsDataGrid()
        setUpDataGrid()
        PopulateDatagrid()

        EngineersDataView = DB.Engineer.Engineer_GetAll

        Dim c As New DataColumn("Include", GetType(System.Boolean))
        c.DefaultValue = True
        EngineersDataView.Table.Columns.Add(c)
        EngineersDataView.Table.AcceptChanges()
        For Each r As DataRow In EngineersDataView.Table.Rows
            r("Include") = True
        Next
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
            _dvTimesheets.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitTimesheet.ToString
            Me.dgTimesheets.DataSource = TimesheetsDataview
        End Set
    End Property

    Private ReadOnly Property SelectedJobDataRow() As DataRow
        Get
            If Not Me.dgTimesheets.CurrentRowIndex = -1 Then
                Return TimesheetsDataview(Me.dgTimesheets.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _dvEngineer As DataView

    Public Property EngineersDataView() As DataView
        Get
            Return _dvEngineer
        End Get
        Set(ByVal Value As DataView)
            _dvEngineer = Value

            If Not EngineersDataView Is Nothing Then
                If Not EngineersDataView.Table Is Nothing Then
                    _dvEngineer.Table.TableName = "tblEngineers"
                    _dvEngineer.AllowNew = False
                End If
            End If

            dgEngineers.DataSource = EngineersDataView

        End Set
    End Property

#End Region

#Region "Setup"

    Private Sub SetupComboBoxes()
        Dim Departments As New DataTable
        Departments.Columns.Add("Value")
        Departments.Columns.Add("Description")

        Dim DeptRow As DataRow
        DeptRow = Departments.NewRow()
        DeptRow("Value") = 0
        DeptRow("Description") = "ALL"
        Departments.Rows.Add(DeptRow)
        DeptRow = Departments.NewRow()
        DeptRow("Value") = 1
        DeptRow("Description") = "1"
        Departments.Rows.Add(DeptRow)
        DeptRow = Departments.NewRow()
        DeptRow("Value") = 2
        DeptRow("Description") = "2"
        Departments.Rows.Add(DeptRow)
        DeptRow = Departments.NewRow()
        DeptRow("Value") = 4
        DeptRow("Description") = "4"
        Departments.Rows.Add(DeptRow)
        DeptRow = Departments.NewRow()
        DeptRow("Value") = 5
        DeptRow("Description") = "5"
        Departments.Rows.Add(DeptRow)

    End Sub

    Private Sub setUpDataGrid()
        SuspendLayout()

        Entity.Sys.Helper.SetUpDataGrid(dgEngineers)
        Dim tsEngineers As DataGridTableStyle = dgEngineers.TableStyles(0)

        'Set up columns
        tsEngineers.ReadOnly = False
        dgEngineers.ReadOnly = False

        Dim include As New DataGridBoolColumn
        include.HeaderText = "Include"
        include.MappingName = "Include"
        include.ReadOnly = False
        include.Width = 50
        'turn off tristate
        include.AllowNull = False
        tsEngineers.GridColumnStyles.Add(include)

        Dim engineerID As New DataGridLabelColumn
        engineerID.Format = ""
        engineerID.FormatInfo = Nothing
        engineerID.HeaderText = "Engineer ID"
        engineerID.MappingName = "EngineerID"
        engineerID.ReadOnly = True
        engineerID.Width = 75
        tsEngineers.GridColumnStyles.Add(engineerID)

        Dim engineerName As New DataGridLabelColumn
        engineerName.Format = ""
        engineerName.FormatInfo = Nothing
        engineerName.HeaderText = "Engineer Name"
        engineerName.MappingName = "Name"
        engineerName.ReadOnly = True
        engineerName.Width = 200
        tsEngineers.GridColumnStyles.Add(engineerName)

        tsEngineers.MappingName = "tblEngineers"

        Me.dgEngineers.TableStyles.Add(tsEngineers)
        ResumeLayout(True)
    End Sub

    Private Sub SetupTimesheetsDataGrid()

        Dim tbStyle As DataGridTableStyle = Me.dgTimesheets.TableStyles(0)

        Dim Source As New DataGridLabelColumn
        Source.Format = ""
        Source.FormatInfo = Nothing
        Source.HeaderText = "Source"
        Source.MappingName = "Source"
        Source.ReadOnly = True
        Source.Width = 100
        Source.NullText = ""
        tbStyle.GridColumnStyles.Add(Source)

        Dim Engineer As New DataGridLabelColumn
        Engineer.Format = ""
        Engineer.FormatInfo = Nothing
        Engineer.HeaderText = "Engineer"
        Engineer.MappingName = "Engineer"
        Engineer.ReadOnly = True
        Engineer.Width = 150
        Engineer.NullText = ""
        tbStyle.GridColumnStyles.Add(Engineer)

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "Job Number"
        JobNumber.MappingName = "JobNumber"
        JobNumber.ReadOnly = True
        JobNumber.Width = 75
        JobNumber.NullText = ""
        tbStyle.GridColumnStyles.Add(JobNumber)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Property"
        Site.MappingName = "Site"
        Site.ReadOnly = True
        Site.Width = 100
        Site.NullText = ""
        tbStyle.GridColumnStyles.Add(Site)

        Dim VisitDetails As New DataGridLabelColumn
        VisitDetails.Format = ""
        VisitDetails.FormatInfo = Nothing
        VisitDetails.HeaderText = "Visit Details"
        VisitDetails.MappingName = "VisitDetails"
        VisitDetails.ReadOnly = True
        VisitDetails.Width = 100
        VisitDetails.NullText = ""
        tbStyle.GridColumnStyles.Add(VisitDetails)

        Dim DateFrom As New DataGridLabelColumn
        DateFrom.Format = "dd/MM/yyyy"
        DateFrom.FormatInfo = Nothing
        DateFrom.HeaderText = "Date"
        DateFrom.MappingName = "StartDateTime"
        DateFrom.ReadOnly = True
        DateFrom.Width = 75
        DateFrom.NullText = ""
        tbStyle.GridColumnStyles.Add(DateFrom)

        Dim TimeFrom As New DataGridLabelColumn
        TimeFrom.Format = "HH:mm"
        TimeFrom.FormatInfo = Nothing
        TimeFrom.HeaderText = "Start Time"
        TimeFrom.MappingName = "StartTime"
        TimeFrom.ReadOnly = True
        TimeFrom.Width = 75
        TimeFrom.NullText = ""
        tbStyle.GridColumnStyles.Add(TimeFrom)

        Dim TimeTo As New DataGridLabelColumn
        TimeTo.Format = "HH:mm"
        TimeTo.FormatInfo = Nothing
        TimeTo.HeaderText = "End Time"
        TimeTo.MappingName = "EndDateTime"
        TimeTo.ReadOnly = True
        TimeTo.Width = 100
        TimeTo.NullText = ""
        tbStyle.GridColumnStyles.Add(TimeTo)

        Dim TimesheetType As New DataGridLabelColumn
        TimesheetType.Format = ""
        TimesheetType.FormatInfo = Nothing
        TimesheetType.HeaderText = "Timesheet Type"
        TimesheetType.MappingName = "TimesheetType"
        TimesheetType.ReadOnly = True
        TimesheetType.Width = 100
        TimesheetType.NullText = ""
        tbStyle.GridColumnStyles.Add(TimesheetType)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVisitTimesheet.ToString

        Me.dgTimesheets.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub cboDept_Changed(sender As Object, e As EventArgs) Handles cboDept.SelectedIndexChanged
        Dim department As String = Entity.Sys.Helper.MakeStringValid(Combo.GetSelectedItemValue(cboDept))

        If Entity.Sys.Helper.IsValidInteger(department) AndAlso Entity.Sys.Helper.MakeIntegerValid(department) <= -1 Then
            'do nituhg
            Exit Sub
        End If
        EngineersDataView = DB.Engineer.Engineer_GetAllbyDept(department)

        Dim c As New DataColumn("Include", GetType(System.Boolean))
        c.DefaultValue = True
        EngineersDataView.Table.Columns.Add(c)
        EngineersDataView.Table.AcceptChanges()
        For Each r As DataRow In EngineersDataView.Table.Rows
            r("Include") = True
        Next
    End Sub

    Private Sub FRMEngineerTimesheetReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnRunReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunReport.Click
        ShowData()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ResetFilters()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

    Private Sub btnSummary_Click(sender As System.Object, e As System.EventArgs) Handles btnSummary.Click
        ExportSummary()
    End Sub

    Private Sub dgEngineers_Clicks(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgEngineers.Click, dgEngineers.DoubleClick

        Try
            ' this code mainly facilitates single clicks to change the state of a checkbox
            Dim includeColumn As Integer = 0
            Dim pt As Point = Me.dgEngineers.PointToClient(Control.MousePosition)
            Dim hti As DataGrid.HitTestInfo = Me.dgEngineers.HitTest(pt)
            Dim bmb As BindingManagerBase = Me.BindingContext(Me.dgEngineers.DataSource,
                                                        Me.dgEngineers.DataMember)

            If hti.Row < bmb.Count AndAlso hti.Type = DataGrid.HitTestType.Cell AndAlso hti.Column = includeColumn Then
                Dim selected As Boolean = Not CBool(Me.dgEngineers(hti.Row, includeColumn))
                Me.dgEngineers(hti.Row, includeColumn) = selected
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
        End Try

    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        If Not EngineersDataView Is Nothing Then
            If Not EngineersDataView.Table Is Nothing Then
                For Each r As DataRow In EngineersDataView.Table.Rows
                    r("Include") = True
                Next
            End If
        End If
    End Sub

    Private Sub btnClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        If Not EngineersDataView Is Nothing Then
            If Not EngineersDataView.Table Is Nothing Then
                For Each r As DataRow In EngineersDataView.Table.Rows
                    r("Include") = False
                Next
            End If
        End If
    End Sub

#End Region

#Region "Functions"

    Public Sub PopulateDatagrid()
        Try
            ResetFilters()
            If GetParameter(0) Is Nothing Then
            Else
                TimesheetsDataview = GetParameter(0)
                Me.grpFilter.Enabled = False
            End If
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetFilters()
        If Not EngineersDataView Is Nothing Then
            If Not EngineersDataView.Table Is Nothing Then
                For Each r As DataRow In EngineersDataView.Table.Rows
                    r("Include") = True
                Next
            End If
        End If
        Me.txtJobNumber.Text = ""
        Me.dtpFrom.Value = Today.AddDays(-7)
        Me.dtpTo.Value = Today
        Me.grpFilter.Enabled = True
        ShowData()
    End Sub

    Private Sub ShowData()
        Me.Cursor = Cursors.WaitCursor
        Dim whereClause As String = " WHERE TS.StartDateTime >= '" & Format(Me.dtpFrom.Value, "dd/MMM/yyyy 00:00:00") & "' AND TS.EndDateTime <= '" & Format(Me.dtpTo.Value, "dd/MMM/yyyy 23:59:59") & "'"

        Dim engList As String = "0,"
        If Not EngineersDataView Is Nothing Then
            If Not EngineersDataView.Table Is Nothing Then
                For Each r As DataRow In EngineersDataView.Table.Rows
                    If r("Include") Then
                        engList += r("EngineerID") & ","
                    End If
                Next
            End If
        End If

        engList = engList.Substring(0, engList.Length - 1)

        whereClause += " AND tblEngineer.EngineerID IN (" & engList & ")"

        If Not Me.txtJobNumber.Text.Trim.Length = 0 Then
            whereClause += " AND tblJob.JobNumber LIKE '" & Me.txtJobNumber.Text.Trim & "%'"
        End If

        TimesheetsDataview = DB.EngineerVisitsTimeSheet.GetAll(whereClause)

        Cursor = Cursors.Default
    End Sub

    Public Sub Export()
        If TimesheetsDataview.Count <= 0 Then
            ShowMessage("No engineers are being displayed, please change / run filter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim rSel() As DataRow
        Dim cnt As Integer = 0

        Dim exportData As New DataTable
        ' exportData.Columns.Add("Engineer")
        exportData.Columns.Add("JobNumber")
        exportData.Columns.Add("Site")
        exportData.Columns.Add("Visit Details")
        exportData.Columns.Add("Notes From Engineer")
        '   exportData.Columns.Add("Date")
        exportData.Columns.Add("Start Time")
        exportData.Columns.Add("End Time")
        exportData.Columns.Add("Timesheet Type")
        exportData.Columns.Add("Time")

        Dim theDays As New DataTable
        theDays.Columns.Add("Day", GetType(DateTime))

        Dim dates() As DataRow = TimesheetsDataview.Table.Select("", "StartDateTime")
        For Each d As DataRow In dates
            If theDays.Select("Day='" & Format(d("StartDateTime"), "dd/MMM/yyyy") & "'").Length = 0 Then
                Dim dd As DataRow
                dd = theDays.NewRow
                dd("Day") = Format(d("StartDateTime"), "dd/MMM/yyyy")
                theDays.Rows.Add(dd)
            End If
        Next d

        If theDays.Rows.Count > 5 Then
            For datecol As Integer = 6 To theDays.Rows.Count
                exportData.Columns.Add(datecol)
            Next

        End If

        Dim i As Integer = 2
        Dim lastDay As String = ""
        Dim lastEngineer As String = ""
        Dim extraRw As DataRow

        Dim dtTimesheetTypes As New DataTable
        dtTimesheetTypes.Columns.Add("Name")
        Dim rtst As DataRow
        rtst = dtTimesheetTypes.NewRow
        rtst("Name") = "TRAVELLING"
        dtTimesheetTypes.Rows.Add(rtst)
        rtst = dtTimesheetTypes.NewRow
        rtst("Name") = "WORKING"
        dtTimesheetTypes.Rows.Add(rtst)
        rtst = dtTimesheetTypes.NewRow
        rtst("Name") = "LUNCH"
        dtTimesheetTypes.Rows.Add(rtst)
        rtst = dtTimesheetTypes.NewRow
        rtst("Name") = "NON-CHARGEABLE"
        dtTimesheetTypes.Rows.Add(rtst)

        Dim dtTimes As New DataTable
        dtTimes.Columns.Add("Engineer")
        dtTimes.Columns.Add("Day")
        dtTimes.Columns.Add("Type")
        dtTimes.Columns.Add("Time") 'Minutes

        Dim dtStartEnd As New DataTable
        dtStartEnd.Columns.Add("Engineer")
        dtStartEnd.Columns.Add("Day")
        dtStartEnd.Columns.Add("StartDay")
        dtStartEnd.Columns.Add("EndDay")

        Dim dtUnallocated As New DataTable
        dtUnallocated.Columns.Add("Day")
        dtUnallocated.Columns.Add("Time")

        Dim drUnallocated As DataRow

        For itm As Integer = 0 To CType(dgTimesheets.DataSource, DataView).Count - 1
            dgTimesheets.CurrentRowIndex = itm
            Dim newRw As DataRow
            newRw = exportData.NewRow

            'SUMMING UP
            Dim drRw() As DataRow = dtTimes.Select("Engineer='" & SelectedJobDataRow("Engineer") &
                                "' AND Day='" & Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy") &
                                "' AND Type='" & SelectedJobDataRow("TimeSheetType") & "'")
            If drRw.Length > 0 Then
                drRw(0).Item("Time") += DateDiff(DateInterval.Minute,
                                                 CDate(Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy HH:mm")),
                                                  CDate(Format(SelectedJobDataRow("EndDateTime"), "dd/MM/yyyy HH:mm")))
            Else
                Dim nwRw As DataRow
                nwRw = dtTimes.NewRow
                nwRw("Engineer") = SelectedJobDataRow("Engineer")
                nwRw("Day") = Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy")
                nwRw("Type") = SelectedJobDataRow("TimeSheetType")
                nwRw("Time") = DateDiff(DateInterval.Minute,
                                                 CDate(Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy HH:mm")),
                                                  CDate(Format(SelectedJobDataRow("EndDateTime"), "dd/MM/yyyy HH:mm")))
                dtTimes.Rows.Add(nwRw)
            End If
            Dim nwExtra As DataRow
            nwExtra = dtTimes.NewRow
            nwExtra("Engineer") = SelectedJobDataRow("Engineer")
            nwExtra("Day") = Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy")
            nwExtra("Type") = "Total Hours > 17:00"

            Dim dateDifference As Integer = 0
            If CDate(Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy") & " 17:00:00") < SelectedJobDataRow("StartDateTime") Then
                dateDifference = DateDiff(DateInterval.Minute, SelectedJobDataRow("StartDateTime"), SelectedJobDataRow("EndDateTime"))
            Else
                dateDifference = DateDiff(DateInterval.Minute, CDate(Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy") & " 17:00:00"), SelectedJobDataRow("EndDateTime"))
            End If

            If dateDifference > 0 Then
                nwExtra("Time") = dateDifference
            Else
                nwExtra("Time") = 0
            End If

            dtTimes.Rows.Add(nwExtra)

            Dim drStartEnd() As DataRow = dtStartEnd.Select("Engineer='" & SelectedJobDataRow("Engineer") &
                                "' AND Day='" & Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy") & "'")
            If drStartEnd.Length = 0 Then
                Dim nwSE As DataRow
                nwSE = dtStartEnd.NewRow
                nwSE("Engineer") = SelectedJobDataRow("Engineer")
                nwSE("Day") = Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy")
                nwSE("StartDay") = SelectedJobDataRow("StartDateTime")
                nwSE("EndDay") = SelectedJobDataRow("EndDateTime")
                dtStartEnd.Rows.Add(nwSE)
            Else
                If drStartEnd(0).Item("StartDay") > SelectedJobDataRow("StartDateTime") Then
                    drStartEnd(0).Item("StartDay") = SelectedJobDataRow("StartDateTime")
                End If
                If drStartEnd(0).Item("EndDay") < SelectedJobDataRow("EndDateTime") Then
                    drStartEnd(0).Item("EndDay") = SelectedJobDataRow("EndDateTime")
                End If
            End If

            '------------------------------------

            If i = 2 Then
                'START BY PUTTING ENGINEER
                extraRw = exportData.NewRow
                extraRw("JobNumber") = SelectedJobDataRow("Engineer")
                exportData.Rows.Add(extraRw)
                i += 1

                'SPACE
                extraRw = exportData.NewRow
                exportData.Rows.Add(extraRw)
                i += 1

                'DATE
                extraRw = exportData.NewRow
                extraRw("JobNumber") = Format(SelectedJobDataRow("StartDateTime"), "dddd")
                extraRw("Site") = Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy")
                exportData.Rows.Add(extraRw)
                i += 1

                lastDay = Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy")
                lastEngineer = SelectedJobDataRow("Engineer")
            End If

            If lastDay <> Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy") Then

                extraRw = exportData.NewRow
                exportData.Rows.Add(extraRw)
                i += 1
                lastDay = Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy")
                If lastEngineer = SelectedJobDataRow("Engineer") Then
                    'DATE
                    extraRw = exportData.NewRow
                    extraRw("JobNumber") = Format(SelectedJobDataRow("StartDateTime"), "dddd")
                    extraRw("Site") = Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy")
                    exportData.Rows.Add(extraRw)
                    i += 1
                End If

            End If

            If lastEngineer <> SelectedJobDataRow("Engineer") Then
                extraRw = exportData.NewRow
                exportData.Rows.Add(extraRw)
                i += 1
                extraRw = exportData.NewRow
                extraRw("JobNumber") = "SUMMARY"

                cnt = 3
                For Each theDay As DataRow In theDays.Rows
                    extraRw(cnt) = Format(theDay("Day"), "dd/MM")
                    cnt += 1
                Next theDay

                exportData.Rows.Add(extraRw)
                i += 1
                For Each dr As DataRow In dtTimesheetTypes.Rows
                    extraRw = exportData.NewRow
                    extraRw("JobNumber") = dr("Name").ToString.ToUpper
                    cnt = 3
                    For Each theDay As DataRow In theDays.Rows
                        rSel = dtTimes.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") &
                                               "' AND Engineer='" & lastEngineer &
                                               "' AND Type='" & dr("Name").ToString & "'")
                        If rSel.Length > 0 Then
                            extraRw(cnt) = formatTime(rSel(0).Item("Time"))
                        Else
                            extraRw(cnt) = formatTime(0)
                        End If
                        cnt += 1
                    Next theDay

                    exportData.Rows.Add(extraRw)
                    i += 1
                Next
                extraRw = exportData.NewRow
                extraRw("JobNumber") = "Unaccounted".ToUpper
                cnt = 3
                For Each theDay As DataRow In theDays.Rows
                    Dim drUnAl() As DataRow = dtStartEnd.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") &
                                               "' AND Engineer='" & lastEngineer & "'")
                    If drUnAl.Length > 0 Then
                        Dim drAl() As DataRow = dtTimes.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") &
                                               "' AND Engineer='" & lastEngineer & "'")
                        If drAl.Length > 0 Then
                            Dim allTotal As Integer = 0
                            For Each al As DataRow In drAl
                                If al("Type") <> "Total Hours > 17:00" Then
                                    allTotal += al("Time")
                                End If
                            Next

                            extraRw(cnt) = formatTime(DateDiff(DateInterval.Minute,
                                                                 CDate(Format(CDate(drUnAl(0).Item("StartDay")), "dd/MM/yyyy HH:mm")),
                                                  CDate(Format(CDate(drUnAl(0).Item("EndDay")), "dd/MM/yyyy HH:mm"))) - allTotal)
                            drUnallocated = dtUnallocated.NewRow
                            drUnallocated("Day") = Format(theDay("Day"), "dd/MM/yyyy")
                            drUnallocated("Time") = DateDiff(DateInterval.Minute,
                                                                 CDate(Format(CDate(drUnAl(0).Item("StartDay")), "dd/MM/yyyy HH:mm")),
                                                  CDate(Format(CDate(drUnAl(0).Item("EndDay")), "dd/MM/yyyy HH:mm"))) - allTotal
                            dtUnallocated.Rows.Add(drUnallocated)
                        Else
                            extraRw(cnt) = formatTime(DateDiff(DateInterval.Minute,
                                                                 CDate(Format(CDate(drUnAl(0).Item("StartDay")), "dd/MM/yyyy HH:mm")),
                                                  CDate(Format(CDate(drUnAl(0).Item("EndDay")), "dd/MM/yyyy HH:mm"))))
                        End If
                    Else
                        extraRw(cnt) = formatTime(0)
                    End If

                    cnt += 1
                Next
                exportData.Rows.Add(extraRw)
                i += 1
                extraRw = exportData.NewRow
                extraRw("JobNumber") = "Total Hours > 17:00".ToUpper
                cnt = 3
                For Each theDay As DataRow In theDays.Rows
                    rSel = dtTimes.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") &
                                         "' AND Engineer='" & lastEngineer &
                                         "' AND Type='Total Hours > 17:00'")
                    If rSel.Length > 0 Then
                        Dim total As Integer = 0
                        For l As Integer = 0 To rSel.Length - 1
                            total += rSel(l).Item("Time")
                        Next
                        extraRw(cnt) += formatTime(total)
                    Else
                        extraRw(cnt) = formatTime(0)
                    End If

                    cnt += 1
                Next
                exportData.Rows.Add(extraRw)
                i += 1
                extraRw = exportData.NewRow
                exportData.Rows.Add(extraRw)
                i += 1
                extraRw = exportData.NewRow
                exportData.Rows.Add(extraRw)
                i += 1
                lastEngineer = SelectedJobDataRow("Engineer")

                'PUTTING ENGINEER
                extraRw = exportData.NewRow
                extraRw("JobNumber") = SelectedJobDataRow("Engineer")
                exportData.Rows.Add(extraRw)
                i += 1
                'SPACE
                extraRw = exportData.NewRow
                exportData.Rows.Add(extraRw)
                i += 1

                'DATE
                extraRw = exportData.NewRow
                extraRw("JobNumber") = Format(SelectedJobDataRow("StartDateTime"), "dddd")
                extraRw("Site") = Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy")
                exportData.Rows.Add(extraRw)
                i += 1
            End If

            newRw("JobNumber") = SelectedJobDataRow("JobNumber")
            newRw("Site") = SelectedJobDataRow("Site")
            newRw("Visit Details") = SelectedJobDataRow("VisitDetails")
            newRw("Notes From Engineer") = SelectedJobDataRow("NotesFromEngineer")
            newRw("Start Time") = Format(SelectedJobDataRow("StartDateTime"), "HH:mm")
            newRw("End Time") = Format(SelectedJobDataRow("EndDateTime"), "HH:mm")
            newRw("Timesheet Type") = SelectedJobDataRow("TimeSheetType")
            newRw("Time") = SelectedJobDataRow("Duration")

            exportData.Rows.Add(newRw)

            dgTimesheets.UnSelect(itm)
            i += 1
        Next itm

        extraRw = exportData.NewRow
        exportData.Rows.Add(extraRw)
        i += 1
        extraRw = exportData.NewRow
        extraRw("JobNumber") = "SUMMARY"
        cnt = 3
        For Each theDay As DataRow In theDays.Rows
            extraRw(cnt) = Format(theDay("Day"), "dd/MM")
            cnt += 1
        Next
        exportData.Rows.Add(extraRw)
        i += 1

        For Each dr As DataRow In dtTimesheetTypes.Rows
            extraRw = exportData.NewRow
            extraRw("JobNumber") = dr("Name").ToString.ToUpper
            cnt = 3
            For Each theDay As DataRow In theDays.Rows

                rSel = dtTimes.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") &
                                       "' AND Engineer='" & SelectedJobDataRow("Engineer") &
                                       "' AND Type='" & dr("Name").ToString & "'")
                If rSel.Length > 0 Then
                    extraRw(cnt) = formatTime(rSel(0).Item("Time"))
                Else
                    extraRw(cnt) = formatTime(0)
                End If
                cnt += 1
            Next

            exportData.Rows.Add(extraRw)
            i += 1
        Next
        extraRw = exportData.NewRow
        extraRw("JobNumber") = "Unaccounted".ToUpper
        cnt = 3
        For Each theDay As DataRow In theDays.Rows
            Dim drUnAl() As DataRow = dtStartEnd.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") &
                                              "' AND Engineer='" & SelectedJobDataRow("Engineer") & "'")
            If drUnAl.Length > 0 Then
                Dim drAl() As DataRow = dtTimes.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") &
                                       "' AND Engineer='" & SelectedJobDataRow("Engineer") & "'")
                If drAl.Length > 0 Then
                    Dim allTotal As Integer = 0
                    For Each al As DataRow In drAl
                        If al("Type") <> "Total Hours > 17:00" Then
                            allTotal += al("Time")
                        End If
                    Next

                    extraRw(cnt) = formatTime(DateDiff(DateInterval.Minute,
                                                                 CDate(Format(CDate(drUnAl(0).Item("StartDay")), "dd/MM/yyyy HH:mm")),
                                                  CDate(Format(CDate(drUnAl(0).Item("EndDay")), "dd/MM/yyyy HH:mm"))) - allTotal)

                    drUnallocated = dtUnallocated.NewRow
                    drUnallocated("Day") = Format(theDay("Day"), "dd/MM/yyyy")
                    drUnallocated("Time") = DateDiff(DateInterval.Minute,
                                                                 CDate(Format(CDate(drUnAl(0).Item("StartDay")), "dd/MM/yyyy HH:mm")),
                                                  CDate(Format(CDate(drUnAl(0).Item("EndDay")), "dd/MM/yyyy HH:mm"))) - allTotal
                    dtUnallocated.Rows.Add(drUnallocated)
                Else
                    extraRw(cnt) = DateDiff(DateInterval.Minute,
                                                                 CDate(Format(CDate(drUnAl(0).Item("StartDay")), "dd/MM/yyyy HH:mm")),
                                                  CDate(Format(CDate(drUnAl(0).Item("EndDay")), "dd/MM/yyyy HH:mm")))
                End If
            Else
                extraRw(cnt) = formatTime(0)
            End If
            cnt += 1
        Next
        exportData.Rows.Add(extraRw)
        i += 1
        extraRw = exportData.NewRow
        extraRw("JobNumber") = "Total Hours > 17:00".ToUpper
        cnt = 3
        For Each theDay As DataRow In theDays.Rows
            rSel = dtTimes.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") &
                                          "' AND Engineer='" & SelectedJobDataRow("Engineer") &
                                          "' AND Type='Total Hours > 17:00'")
            If rSel.Length > 0 Then
                Dim total As Integer = 0
                For l As Integer = 0 To rSel.Length - 1
                    total += rSel(l).Item("Time")
                Next
                extraRw(cnt) += formatTime(total)
            Else
                extraRw(cnt) = formatTime(0)
            End If
            cnt += 1
        Next
        exportData.Rows.Add(extraRw)
        i += 1
        extraRw = exportData.NewRow
        exportData.Rows.Add(extraRw)
        i += 1
        extraRw = exportData.NewRow
        exportData.Rows.Add(extraRw)
        i += 1

        extraRw = exportData.NewRow
        exportData.Rows.Add(extraRw)
        i += 1
        extraRw = exportData.NewRow
        extraRw("JobNumber") = "MASTER SUMMARY"
        cnt = 3
        For Each theDay As DataRow In theDays.Rows
            extraRw(cnt) = Format(theDay("Day"), "dd/MM")
            cnt += 1
        Next
        exportData.Rows.Add(extraRw)
        i += 1

        For Each dr As DataRow In dtTimesheetTypes.Rows
            extraRw = exportData.NewRow
            extraRw("JobNumber") = dr("Name").ToString.ToUpper
            cnt = 3

            For Each theDay As DataRow In theDays.Rows
                rSel = dtTimes.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") &
                                       "' AND Type='" & dr("Name").ToString & "'")
                If rSel.Length > 0 Then
                    Dim total As Integer = 0
                    For l As Integer = 0 To rSel.Length - 1
                        total += rSel(l).Item("Time")
                    Next
                    extraRw(cnt) = formatTime(total)
                Else
                    extraRw(cnt) = formatTime(0)
                End If
                cnt += 1
            Next
            exportData.Rows.Add(extraRw)
            i += 1
        Next
        extraRw = exportData.NewRow
        extraRw("JobNumber") = "Unaccounted".ToUpper
        cnt = 3
        For Each theDay As DataRow In theDays.Rows
            Dim totalUnallocated As Integer = 0
            Dim drDayUnallocated() As DataRow = dtUnallocated.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") & "'")
            For b As Integer = 0 To drDayUnallocated.Length - 1
                totalUnallocated += drDayUnallocated(b).Item("Time")
            Next b
            extraRw(cnt) = formatTime(totalUnallocated)
            cnt += 1
        Next
        exportData.Rows.Add(extraRw)
        i += 1
        extraRw = exportData.NewRow
        extraRw("JobNumber") = "Total Hours > 17:00".ToUpper
        cnt = 3
        For Each theDay As DataRow In theDays.Rows
            rSel = dtTimes.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") &
                                          "' AND Type='Total Hours > 17:00'")
            If rSel.Length > 0 Then
                Dim total As Integer = 0
                For l As Integer = 0 To rSel.Length - 1
                    total += rSel(l).Item("Time")
                Next
                extraRw(cnt) = formatTime(total)
            Else
                extraRw(cnt) = formatTime(0)
            End If
            cnt += 1
        Next
        exportData.Rows.Add(extraRw)
        i += 1
        extraRw = exportData.NewRow
        exportData.Rows.Add(extraRw)
        i += 1
        extraRw = exportData.NewRow
        exportData.Rows.Add(extraRw)
        i += 1

        Dim exporter As New Entity.Sys.Exporting(exportData, "Timesheet " & Format(dtpFrom.Value, "dd-MM-yy") & " - " & Format(dtpTo.Value, "dd-MM-yy"))
        exporter = Nothing
    End Sub

    Public Sub ExportSummary(Optional ByVal Department As String = Nothing)
        If TimesheetsDataview.Count <= 0 Then
            ShowMessage("No engineers are being displayed, please change / run filter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim rSel() As DataRow
        Dim cnt As Integer = 0

        Dim exportData As New DataTable
        exportData.Columns.Add("Engineer")
        exportData.Columns.Add("Travelling")
        exportData.Columns.Add("Working")
        exportData.Columns.Add("Lunch")
        exportData.Columns.Add("Non Chargeable")
        exportData.Columns.Add("Unallocated")
        exportData.Columns.Add("Total Hours > 17:00")

        Dim theDays As New DataTable
        theDays.Columns.Add("Day", GetType(DateTime))

        Dim dates() As DataRow = TimesheetsDataview.Table.Select("", "StartDateTime")
        For Each d As DataRow In dates
            If theDays.Select("Day='" & Format(d("StartDateTime"), "dd/MMM/yyyy") & "'").Length = 0 Then
                Dim dd As DataRow
                dd = theDays.NewRow
                dd("Day") = Format(d("StartDateTime"), "dd/MMM/yyyy")
                theDays.Rows.Add(dd)
            End If
        Next d

        If theDays.Rows.Count > 5 Then
            For datecol As Integer = 6 To theDays.Rows.Count
                exportData.Columns.Add(datecol)
            Next

        End If

        Dim i As Integer = 2
        Dim lastDay As String = ""
        Dim lastEngineer As String = ""
        Dim extraRw As DataRow

        Dim dtTimesheetTypes As New DataTable
        dtTimesheetTypes.Columns.Add("Name")
        Dim rtst As DataRow
        rtst = dtTimesheetTypes.NewRow
        rtst("Name") = "TRAVELLING"
        dtTimesheetTypes.Rows.Add(rtst)
        rtst = dtTimesheetTypes.NewRow
        rtst("Name") = "WORKING"
        dtTimesheetTypes.Rows.Add(rtst)
        rtst = dtTimesheetTypes.NewRow
        rtst("Name") = "LUNCH"
        dtTimesheetTypes.Rows.Add(rtst)
        rtst = dtTimesheetTypes.NewRow
        rtst("Name") = "NON-CHARGEABLE"
        dtTimesheetTypes.Rows.Add(rtst)

        Dim dtTimes As New DataTable
        dtTimes.Columns.Add("Engineer")
        dtTimes.Columns.Add("Day")
        dtTimes.Columns.Add("Type")
        dtTimes.Columns.Add("Time") 'Minutes

        Dim dtStartEnd As New DataTable
        dtStartEnd.Columns.Add("Engineer")
        dtStartEnd.Columns.Add("Day")
        dtStartEnd.Columns.Add("StartDay")
        dtStartEnd.Columns.Add("EndDay")

        Dim dtUnallocated As New DataTable
        dtUnallocated.Columns.Add("Day")
        dtUnallocated.Columns.Add("Time")

        Dim drUnallocated As DataRow
        Dim MinsTally As Integer = 0

        For itm As Integer = 0 To CType(dgTimesheets.DataSource, DataView).Count - 1
            dgTimesheets.CurrentRowIndex = itm
            Dim newRw As DataRow
            newRw = exportData.NewRow

            'SUMMING UP
            Dim drRw() As DataRow = dtTimes.Select("Engineer='" & SelectedJobDataRow("Engineer") &
                                "' AND Day='" & Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy") &
                                "' AND Type='" & SelectedJobDataRow("TimeSheetType") & "'")
            If drRw.Length > 0 Then
                drRw(0).Item("Time") += DateDiff(DateInterval.Minute,
                                                 CDate(Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy HH:mm")),
                                                  CDate(Format(SelectedJobDataRow("EndDateTime"), "dd/MM/yyyy HH:mm")))
            Else
                Dim nwRw As DataRow
                nwRw = dtTimes.NewRow
                nwRw("Engineer") = SelectedJobDataRow("Engineer")
                nwRw("Day") = Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy")
                nwRw("Type") = SelectedJobDataRow("TimeSheetType")
                nwRw("Time") = DateDiff(DateInterval.Minute,
                                                 CDate(Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy HH:mm")),
                                                  CDate(Format(SelectedJobDataRow("EndDateTime"), "dd/MM/yyyy HH:mm")))
                dtTimes.Rows.Add(nwRw)
            End If
            Dim nwExtra As DataRow
            nwExtra = dtTimes.NewRow
            nwExtra("Engineer") = SelectedJobDataRow("Engineer")
            nwExtra("Day") = Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy")
            nwExtra("Type") = "Total Hours > 17:00"

            Dim dateDifference As Integer = 0
            If CDate(Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy") & " 17:00:00") < SelectedJobDataRow("StartDateTime") Then
                dateDifference = DateDiff(DateInterval.Minute, SelectedJobDataRow("StartDateTime"), SelectedJobDataRow("EndDateTime"))
            Else
                dateDifference = DateDiff(DateInterval.Minute, CDate(Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy") & " 17:00:00"), SelectedJobDataRow("EndDateTime"))
            End If

            If dateDifference > 0 Then
                nwExtra("Time") = dateDifference
            Else
                nwExtra("Time") = 0
            End If

            dtTimes.Rows.Add(nwExtra)

            Dim drStartEnd() As DataRow = dtStartEnd.Select("Engineer='" & SelectedJobDataRow("Engineer") &
                                "' AND Day='" & Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy") & "'")
            If drStartEnd.Length = 0 Then
                Dim nwSE As DataRow
                nwSE = dtStartEnd.NewRow
                nwSE("Engineer") = SelectedJobDataRow("Engineer")
                nwSE("Day") = Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy")
                nwSE("StartDay") = SelectedJobDataRow("StartDateTime")
                nwSE("EndDay") = SelectedJobDataRow("EndDateTime")
                dtStartEnd.Rows.Add(nwSE)
            Else
                If drStartEnd(0).Item("StartDay") > SelectedJobDataRow("StartDateTime") Then
                    drStartEnd(0).Item("StartDay") = SelectedJobDataRow("StartDateTime")
                End If
                If drStartEnd(0).Item("EndDay") < SelectedJobDataRow("EndDateTime") Then
                    drStartEnd(0).Item("EndDay") = SelectedJobDataRow("EndDateTime")
                End If
            End If

            '------------------------------------

            If i = 2 Then
                'START BY PUTTING ENGINEER
                extraRw = exportData.NewRow
                extraRw("Engineer") = SelectedJobDataRow("Engineer")

                lastDay = Format(SelectedJobDataRow("StartDateTime"), "dd/MM/yyyy")
                lastEngineer = SelectedJobDataRow("Engineer")
            End If

            If lastEngineer <> SelectedJobDataRow("Engineer") Then

                For Each dr As DataRow In dtTimesheetTypes.Rows
                    MinsTally = 0
                    For Each theDay As DataRow In theDays.Rows
                        rSel = dtTimes.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") &
                                               "' AND Engineer='" & lastEngineer &
                                               "' AND Type='" & dr("Name").ToString & "'")
                        If rSel.Length > 0 Then
                            MinsTally += rSel(0).Item("Time")
                        End If
                    Next theDay

                    extraRw(cnt) = MinsTally

                    cnt += 1
                Next
                MinsTally = 0
                For Each theDay As DataRow In theDays.Rows

                    Dim drUnAl() As DataRow = dtStartEnd.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") &
                                               "' AND Engineer='" & lastEngineer & "'")
                    If drUnAl.Length > 0 Then
                        Dim drAl() As DataRow = dtTimes.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") &
                                               "' AND Engineer='" & lastEngineer & "'")
                        If drAl.Length > 0 Then
                            Dim allTotal As Integer = 0
                            For Each al As DataRow In drAl
                                If al("Type") <> "Total Hours > 17:00" Then
                                    allTotal += al("Time")
                                End If
                            Next

                            MinsTally += DateDiff(DateInterval.Minute, CDate(Format(CDate(drUnAl(0).Item("StartDay")), "dd/MM/yyyy HH:mm")), CDate(Format(CDate(drUnAl(0).Item("EndDay")), "dd/MM/yyyy HH:mm"))) - allTotal
                            drUnallocated = dtUnallocated.NewRow
                            drUnallocated("Day") = Format(theDay("Day"), "dd/MM/yyyy")
                            drUnallocated("Time") = DateDiff(DateInterval.Minute,
                                                                 CDate(Format(CDate(drUnAl(0).Item("StartDay")), "dd/MM/yyyy HH:mm")),
                                                  CDate(Format(CDate(drUnAl(0).Item("EndDay")), "dd/MM/yyyy HH:mm"))) - allTotal
                            dtUnallocated.Rows.Add(drUnallocated)
                        Else
                            MinsTally += DateDiff(DateInterval.Minute, CDate(Format(CDate(drUnAl(0).Item("StartDay")), "dd/MM/yyyy HH:mm")), CDate(Format(CDate(drUnAl(0).Item("EndDay")), "dd/MM/yyyy HH:mm")))
                        End If
                    End If
                Next

                extraRw(cnt) = MinsTally
                cnt += 1
                MinsTally = 0
                For Each theDay As DataRow In theDays.Rows

                    rSel = dtTimes.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") &
                                         "' AND Engineer='" & lastEngineer &
                                         "' AND Type='Total Hours > 17:00'")
                    If rSel.Length > 0 Then
                        Dim total As Integer = 0
                        For l As Integer = 0 To rSel.Length - 1
                            total += rSel(l).Item("Time")
                        Next
                        MinsTally += total
                    End If
                Next
                extraRw(cnt) = MinsTally
                exportData.Rows.Add(extraRw)
                i += 1
                cnt += 1
                lastEngineer = SelectedJobDataRow("Engineer")

                'PUTTING ENGINEER
                extraRw = exportData.NewRow
                extraRw("Engineer") = SelectedJobDataRow("Engineer")
            End If

            dgTimesheets.UnSelect(itm)
            i += 1
        Next itm
        cnt = 1

        For Each dr As DataRow In dtTimesheetTypes.Rows
            MinsTally = 0
            For Each theDay As DataRow In theDays.Rows

                rSel = dtTimes.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") &
                                       "' AND Engineer='" & SelectedJobDataRow("Engineer") &
                                       "' AND Type='" & dr("Name").ToString & "'")
                If rSel.Length > 0 Then
                    MinsTally += rSel(0).Item("Time")
                End If
            Next
            extraRw(cnt) = MinsTally
            cnt += 1
        Next
        MinsTally = 0
        For Each theDay As DataRow In theDays.Rows
            Dim drUnAl() As DataRow = dtStartEnd.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") &
                                              "' AND Engineer='" & SelectedJobDataRow("Engineer") & "'")
            If drUnAl.Length > 0 Then
                Dim drAl() As DataRow = dtTimes.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") &
                                       "' AND Engineer='" & SelectedJobDataRow("Engineer") & "'")
                If drAl.Length > 0 Then
                    Dim allTotal As Integer = 0
                    For Each al As DataRow In drAl
                        If al("Type") <> "Total Hours > 17:00" Then
                            allTotal += al("Time")
                        End If
                    Next

                    MinsTally += DateDiff(DateInterval.Minute, CDate(Format(CDate(drUnAl(0).Item("StartDay")), "dd/MM/yyyy HH:mm")), CDate(Format(CDate(drUnAl(0).Item("EndDay")), "dd/MM/yyyy HH:mm"))) - allTotal

                    drUnallocated = dtUnallocated.NewRow
                    drUnallocated("Day") = Format(theDay("Day"), "dd/MM/yyyy")
                    drUnallocated("Time") = DateDiff(DateInterval.Minute,
                                                                 CDate(Format(CDate(drUnAl(0).Item("StartDay")), "dd/MM/yyyy HH:mm")),
                                                  CDate(Format(CDate(drUnAl(0).Item("EndDay")), "dd/MM/yyyy HH:mm"))) - allTotal
                    dtUnallocated.Rows.Add(drUnallocated)
                Else
                    MinsTally += DateDiff(DateInterval.Minute, CDate(Format(CDate(drUnAl(0).Item("StartDay")), "dd/MM/yyyy HH:mm")), CDate(Format(CDate(drUnAl(0).Item("EndDay")), "dd/MM/yyyy HH:mm")))
                End If
            End If
        Next
        extraRw(cnt) = MinsTally
        cnt += 1
        MinsTally = 0
        For Each theDay As DataRow In theDays.Rows
            rSel = dtTimes.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") &
                                          "' AND Engineer='" & SelectedJobDataRow("Engineer") &
                                          "' AND Type='Total Hours > 17:00'")
            If rSel.Length > 0 Then
                Dim total As Integer = 0
                For l As Integer = 0 To rSel.Length - 1
                    total += rSel(l).Item("Time")
                Next
                MinsTally += total
            End If
        Next
        extraRw(cnt) = MinsTally
        exportData.Rows.Add(extraRw)
        i += 1
        cnt += 1

        extraRw = exportData.NewRow
        extraRw("Engineer") = "MASTER SUMMARY"
        cnt = 1
        For Each dr As DataRow In dtTimesheetTypes.Rows
            MinsTally = 0
            For Each theDay As DataRow In theDays.Rows
                rSel = dtTimes.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") &
                                       "' AND Type='" & dr("Name").ToString & "'")
                If rSel.Length > 0 Then
                    Dim total As Integer = 0
                    For l As Integer = 0 To rSel.Length - 1
                        total += rSel(l).Item("Time")
                    Next
                    MinsTally += total
                End If
            Next
            extraRw(cnt) = MinsTally
            cnt += 1
        Next
        MinsTally = 0
        For Each theDay As DataRow In theDays.Rows
            Dim totalUnallocated As Integer = 0
            Dim drDayUnallocated() As DataRow = dtUnallocated.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") & "'")
            For b As Integer = 0 To drDayUnallocated.Length - 1
                totalUnallocated += drDayUnallocated(b).Item("Time")
            Next b
            MinsTally += totalUnallocated
        Next
        extraRw(cnt) = MinsTally
        cnt += 1
        MinsTally = 0
        For Each theDay As DataRow In theDays.Rows
            rSel = dtTimes.Select("Day='" & Format(theDay("Day"), "dd/MM/yyyy") &
                                          "' AND Type='Total Hours > 17:00'")
            If rSel.Length > 0 Then
                Dim total As Integer = 0
                For l As Integer = 0 To rSel.Length - 1
                    total += rSel(l).Item("Time")
                Next
                MinsTally += total
            End If
        Next
        extraRw(cnt) = MinsTally
        exportData.Rows.Add(extraRw)
        i += 1
        cnt += 1
        extraRw = exportData.NewRow
        exportData.Rows.Add(extraRw)
        i += 1
        extraRw = exportData.NewRow
        exportData.Rows.Add(extraRw)
        i += 1

        Dim exporter As New Entity.Sys.Exporting(exportData, "TS Summary " & Format(dtpFrom.Value, "dd-MM-yy") & " - " & Format(dtpTo.Value, "dd-MM-yy"))
        exporter = Nothing
    End Sub

    Private Function formatTime(ByVal Minutes As Integer) As String
        If Minutes < 0 Then
            Return "00:00"
        End If

        If Minutes Mod 60 < 10 Then
            Return Math.Floor(Minutes / 60) & ":0" & Minutes Mod 60
        Else
            Return Math.Floor(Minutes / 60) & ":" & Minutes Mod 60
        End If

    End Function

#End Region

End Class