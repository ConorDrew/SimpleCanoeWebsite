Public Class FRMBatchVisitCosts : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
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
    Friend WithEvents grpEngineerVisits As System.Windows.Forms.GroupBox
    Friend WithEvents dgVisits As System.Windows.Forms.DataGrid
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnShowdata As System.Windows.Forms.Button
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnUnselect As System.Windows.Forms.Button
    Friend WithEvents grpFilter As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpEngineerVisits = New System.Windows.Forms.GroupBox()
        Me.dgVisits = New System.Windows.Forms.DataGrid()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.btnShowdata = New System.Windows.Forms.Button()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnUnselect = New System.Windows.Forms.Button()
        Me.grpFilter = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpEngineerVisits.SuspendLayout()
        CType(Me.dgVisits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpEngineerVisits
        '
        Me.grpEngineerVisits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpEngineerVisits.Controls.Add(Me.dgVisits)
        Me.grpEngineerVisits.Location = New System.Drawing.Point(8, 121)
        Me.grpEngineerVisits.Name = "grpEngineerVisits"
        Me.grpEngineerVisits.Size = New System.Drawing.Size(784, 340)
        Me.grpEngineerVisits.TabIndex = 2
        Me.grpEngineerVisits.TabStop = False
        Me.grpEngineerVisits.Text = "Double Click To View / Edit"
        '
        'dgVisits
        '
        Me.dgVisits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgVisits.DataMember = ""
        Me.dgVisits.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgVisits.Location = New System.Drawing.Point(8, 18)
        Me.dgVisits.Name = "dgVisits"
        Me.dgVisits.Size = New System.Drawing.Size(768, 314)
        Me.dgVisits.TabIndex = 14
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(16, 467)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(96, 23)
        Me.btnExport.TabIndex = 37
        Me.btnExport.Text = "Export"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(76, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "From"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(279, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "To"
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(116, 21)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(144, 21)
        Me.dtpFrom.TabIndex = 12
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(319, 21)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(144, 21)
        Me.dtpTo.TabIndex = 13
        '
        'btnShowdata
        '
        Me.btnShowdata.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowdata.Location = New System.Drawing.Point(679, 51)
        Me.btnShowdata.Name = "btnShowdata"
        Me.btnShowdata.Size = New System.Drawing.Size(96, 23)
        Me.btnShowdata.TabIndex = 35
        Me.btnShowdata.Text = "Show Data"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectAll.Location = New System.Drawing.Point(11, 51)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(96, 23)
        Me.btnSelectAll.TabIndex = 36
        Me.btnSelectAll.Text = "Select All"
        '
        'btnUnselect
        '
        Me.btnUnselect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUnselect.Location = New System.Drawing.Point(113, 51)
        Me.btnUnselect.Name = "btnUnselect"
        Me.btnUnselect.Size = New System.Drawing.Size(96, 23)
        Me.btnUnselect.TabIndex = 37
        Me.btnUnselect.Text = "Unselect All"
        '
        'grpFilter
        '
        Me.grpFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilter.Controls.Add(Me.Label1)
        Me.grpFilter.Controls.Add(Me.btnUnselect)
        Me.grpFilter.Controls.Add(Me.btnSelectAll)
        Me.grpFilter.Controls.Add(Me.btnShowdata)
        Me.grpFilter.Controls.Add(Me.dtpTo)
        Me.grpFilter.Controls.Add(Me.dtpFrom)
        Me.grpFilter.Controls.Add(Me.Label9)
        Me.grpFilter.Controls.Add(Me.Label8)
        Me.grpFilter.Location = New System.Drawing.Point(8, 32)
        Me.grpFilter.Name = "grpFilter"
        Me.grpFilter.Size = New System.Drawing.Size(784, 83)
        Me.grpFilter.TabIndex = 1
        Me.grpFilter.TabStop = False
        Me.grpFilter.Text = "Filter"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Visit Date"
        '
        'FRMBatchVisitCosts
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(800, 494)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.grpEngineerVisits)
        Me.Controls.Add(Me.grpFilter)
        Me.MinimumSize = New System.Drawing.Size(808, 528)
        Me.Name = "FRMBatchVisitCosts"
        Me.Text = "Batch Visit Costs Data Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpFilter, 0)
        Me.Controls.SetChildIndex(Me.grpEngineerVisits, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.grpEngineerVisits.ResumeLayout(False)
        CType(Me.dgVisits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFilter.ResumeLayout(False)
        Me.grpFilter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        SetupVisitDataGrid()
        PopulateDatagrid()
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

    Private _dvVisits As DataView
    Private Property VisitsDataview() As DataView
        Get
            Return _dvVisits
        End Get
        Set(ByVal value As DataView)
            _dvVisits = value
            _dvVisits.AllowNew = False
            _dvVisits.AllowEdit = True
            _dvVisits.AllowDelete = False
            _dvVisits.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString
            Me.dgVisits.DataSource = VisitsDataview
        End Set
    End Property

    Private ReadOnly Property SelectedVisitDataRow() As DataRow
        Get
            If Not Me.dgVisits.CurrentRowIndex = -1 Then
                Return VisitsDataview(Me.dgVisits.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Private Sub SetupVisitDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgVisits.TableStyles(0)

        Dim tick As New DataGridBoolColumn
        tick.HeaderText = ""
        tick.MappingName = "tick"
        tick.ReadOnly = False
        tick.Width = 25

        tbStyle.GridColumnStyles.Add(tick)

        Dim StartDateTime As New DataGridLabelColumn
        StartDateTime.Format = ""
        StartDateTime.FormatInfo = Nothing
        StartDateTime.HeaderText = "StartDateTime"
        StartDateTime.MappingName = "StartDateTime"
        StartDateTime.ReadOnly = True
        StartDateTime.Width = 150
        StartDateTime.NullText = ""
        tbStyle.GridColumnStyles.Add(StartDateTime)

        Dim VisitStatus As New DataGridLabelColumn
        VisitStatus.Format = ""
        VisitStatus.FormatInfo = Nothing
        VisitStatus.HeaderText = "VisitStatus"
        VisitStatus.MappingName = "VisitStatus"
        VisitStatus.ReadOnly = True
        VisitStatus.Width = 150
        VisitStatus.NullText = ""
        tbStyle.GridColumnStyles.Add(VisitStatus)

        Dim NotesToEngineer As New DataGridLabelColumn
        NotesToEngineer.Format = ""
        NotesToEngineer.FormatInfo = Nothing
        NotesToEngineer.HeaderText = "NotesToEngineer"
        NotesToEngineer.MappingName = "NotesToEngineer"
        NotesToEngineer.ReadOnly = True
        NotesToEngineer.Width = 150
        NotesToEngineer.NullText = ""
        tbStyle.GridColumnStyles.Add(NotesToEngineer)

        Dim NotesFromEngineer As New DataGridLabelColumn
        NotesFromEngineer.Format = ""
        NotesFromEngineer.FormatInfo = Nothing
        NotesFromEngineer.HeaderText = "NotesFromEngineer"
        NotesFromEngineer.MappingName = "NotesFromEngineer"
        NotesFromEngineer.ReadOnly = True
        NotesFromEngineer.Width = 150
        NotesFromEngineer.NullText = ""
        tbStyle.GridColumnStyles.Add(NotesFromEngineer)

        Dim OutcomeDetails As New DataGridLabelColumn
        OutcomeDetails.Format = ""
        OutcomeDetails.FormatInfo = Nothing
        OutcomeDetails.HeaderText = "OutcomeDetails"
        OutcomeDetails.MappingName = "OutcomeDetails"
        OutcomeDetails.ReadOnly = True
        OutcomeDetails.Width = 150
        OutcomeDetails.NullText = ""
        tbStyle.GridColumnStyles.Add(OutcomeDetails)

        Dim VisitOutcome As New DataGridLabelColumn
        VisitOutcome.Format = ""
        VisitOutcome.FormatInfo = Nothing
        VisitOutcome.HeaderText = "VisitOutcome"
        VisitOutcome.MappingName = "VisitOutcome"
        VisitOutcome.ReadOnly = True
        VisitOutcome.Width = 150
        VisitOutcome.NullText = ""
        tbStyle.GridColumnStyles.Add(VisitOutcome)

        Dim Customer As New DataGridLabelColumn
        Customer.Format = ""
        Customer.FormatInfo = Nothing
        Customer.HeaderText = "Customer"
        Customer.MappingName = "Customer"
        Customer.ReadOnly = True
        Customer.Width = 150
        Customer.NullText = ""
        tbStyle.GridColumnStyles.Add(Customer)

        Dim ForSageAccountCode As New DataGridLabelColumn
        ForSageAccountCode.Format = ""
        ForSageAccountCode.FormatInfo = Nothing
        ForSageAccountCode.HeaderText = "ForSageAccountCode"
        ForSageAccountCode.MappingName = "ForSageAccountCode"
        ForSageAccountCode.ReadOnly = True
        ForSageAccountCode.Width = 150
        ForSageAccountCode.NullText = ""
        tbStyle.GridColumnStyles.Add(ForSageAccountCode)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Site"
        Site.MappingName = "Site"
        Site.ReadOnly = True
        Site.Width = 100
        Site.NullText = ""
        tbStyle.GridColumnStyles.Add(Site)

        Dim Postcode As New DataGridLabelColumn
        Postcode.Format = ""
        Postcode.FormatInfo = Nothing
        Postcode.HeaderText = "Postcode"
        Postcode.MappingName = "SitePostcode"
        Postcode.ReadOnly = True
        Postcode.Width = 75
        Postcode.NullText = ""
        tbStyle.GridColumnStyles.Add(Postcode)

        Dim JobID As New DataGridLabelColumn
        JobID.Format = ""
        JobID.FormatInfo = Nothing
        JobID.HeaderText = "JobID"
        JobID.MappingName = "JobID"
        JobID.ReadOnly = True
        JobID.Width = 75
        JobID.NullText = ""
        tbStyle.GridColumnStyles.Add(JobID)

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "Job Number"
        JobNumber.MappingName = "JobNumber"
        JobNumber.ReadOnly = True
        JobNumber.Width = 75
        JobNumber.NullText = ""
        tbStyle.GridColumnStyles.Add(JobNumber)

        Dim JobDefinition As New DataGridLabelColumn
        JobDefinition.Format = ""
        JobDefinition.FormatInfo = Nothing
        JobDefinition.HeaderText = "JobDefinition"
        JobDefinition.MappingName = "JobDefinition"
        JobDefinition.ReadOnly = True
        JobDefinition.Width = 75
        JobDefinition.NullText = ""
        tbStyle.GridColumnStyles.Add(JobDefinition)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 75
        Type.NullText = ""
        tbStyle.GridColumnStyles.Add(Type)

        Dim Engineer As New DataGridLabelColumn
        Engineer.Format = ""
        Engineer.FormatInfo = Nothing
        Engineer.HeaderText = "Engineer"
        Engineer.MappingName = "Engineer"
        Engineer.ReadOnly = True
        Engineer.Width = 75
        Engineer.NullText = ""
        tbStyle.GridColumnStyles.Add(Engineer)

        Dim VisitCharge As New DataGridLabelColumn
        VisitCharge.Format = ""
        VisitCharge.FormatInfo = Nothing
        VisitCharge.HeaderText = "VisitCharge"
        VisitCharge.MappingName = "VisitCharge"
        VisitCharge.ReadOnly = True
        VisitCharge.Width = 75
        VisitCharge.NullText = ""
        tbStyle.GridColumnStyles.Add(VisitCharge)

        Dim EngineerCost As New DataGridLabelColumn
        EngineerCost.Format = ""
        EngineerCost.FormatInfo = Nothing
        EngineerCost.HeaderText = "EngineerCost"
        EngineerCost.MappingName = "EngineerCost"
        EngineerCost.ReadOnly = True
        EngineerCost.Width = 75
        EngineerCost.NullText = ""
        tbStyle.GridColumnStyles.Add(EngineerCost)

        Dim PartProductCost As New DataGridLabelColumn
        PartProductCost.Format = ""
        PartProductCost.FormatInfo = Nothing
        PartProductCost.HeaderText = "PartProductCost"
        PartProductCost.MappingName = "PartProductCost"
        PartProductCost.ReadOnly = True
        PartProductCost.Width = 75
        PartProductCost.NullText = ""
        tbStyle.GridColumnStyles.Add(PartProductCost)

        Dim PartsToFit As New DataGridLabelColumn
        PartsToFit.Format = ""
        PartsToFit.FormatInfo = Nothing
        PartsToFit.HeaderText = "PartsToFit"
        PartsToFit.MappingName = "PartsToFit"
        PartsToFit.ReadOnly = True
        PartsToFit.Width = 75
        PartsToFit.NullText = ""
        tbStyle.GridColumnStyles.Add(PartsToFit)

        Dim SupInvoice As New DataGridLabelColumn
        SupInvoice.Format = ""
        SupInvoice.FormatInfo = Nothing
        SupInvoice.HeaderText = "SupInvoice"
        SupInvoice.MappingName = "SupInvoice"
        SupInvoice.ReadOnly = True
        SupInvoice.Width = 75
        SupInvoice.NullText = ""
        tbStyle.GridColumnStyles.Add(SupInvoice)

        Dim Credit As New DataGridLabelColumn
        'DefectCount.Format = "C"
        Credit.FormatInfo = Nothing
        Credit.HeaderText = "Credit"
        Credit.MappingName = "Credit"
        Credit.ReadOnly = True
        Credit.Width = 100
        Credit.NullText = ""
        tbStyle.GridColumnStyles.Add(Credit)

        Dim ContractType As New DataGridLabelColumn
        'DefectCount.Format = "C"
        ContractType.FormatInfo = Nothing
        ContractType.HeaderText = "ContractType"
        ContractType.MappingName = "ContractType"
        ContractType.ReadOnly = True
        ContractType.Width = 100
        ContractType.NullText = ""
        tbStyle.GridColumnStyles.Add(ContractType)

        Dim Jobitems As New DataGridLabelColumn
        'DefectCount.Format = "C"
        Jobitems.FormatInfo = Nothing
        Jobitems.HeaderText = "Jobitems"
        Jobitems.MappingName = "Jobitems"
        Jobitems.ReadOnly = True
        Jobitems.Width = 100
        Jobitems.NullText = ""
        tbStyle.GridColumnStyles.Add(Jobitems)

        'dt.Columns.Add("ExceptionAppMake")
        Dim Department As New DataGridLabelColumn
        'DefectCount.Format = "C"
        Department.FormatInfo = Nothing
        Department.HeaderText = "Department"
        Department.MappingName = "Department"
        Department.ReadOnly = True
        Department.Width = 100
        Department.NullText = ""
        tbStyle.GridColumnStyles.Add(Department)

        'dt.Columns.Add("ExceptionAppModel")
        Dim NominalCode As New DataGridLabelColumn
        'DefectCount.Format = "C"
        NominalCode.FormatInfo = Nothing
        NominalCode.HeaderText = "NominalCode"
        NominalCode.MappingName = "NominalCode"
        NominalCode.ReadOnly = True
        NominalCode.Width = 100
        NominalCode.NullText = ""
        tbStyle.GridColumnStyles.Add(NominalCode)

        'dt.Columns.Add("ExceptionAppLLAppliance")
        Dim JobValue As New DataGridLabelColumn
        'DefectCount.Format = "C"
        JobValue.FormatInfo = Nothing
        JobValue.HeaderText = "JobValue"
        JobValue.MappingName = "JobValue"
        JobValue.ReadOnly = True
        JobValue.Width = 100
        JobValue.NullText = ""
        tbStyle.GridColumnStyles.Add(JobValue)

        tbStyle.ReadOnly = False
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString
        Me.dgVisits.TableStyles.Add(tbStyle)
    End Sub

    Public ReadOnly Property SelectedJobRow() As DataRow
        Get

            If Not Me.dgVisits.CurrentRowIndex = -1 Then
                Return VisitsDataview(Me.dgVisits.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Events"

    Private Sub FRMVisitManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ResetFilters()
    End Sub

    Private Sub btnShowdata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowdata.Click
        RunFilter()
    End Sub

    Private Sub dgVisits_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgVisits.MouseUp
        'Dim HitTestInfo As DataGrid.HitTestInfo
        'HitTestInfo = dgVisits.HitTest(e.X, e.Y)
        'If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
        '    If HitTestInfo.Column = 0 Then
        '        Dim selected As Boolean = Not Entity.Sys.Helper.MakeBooleanValid(SelectedVisitDataRow.Item("tick"))
        '        SelectedVisitDataRow.Item("Tick") = selected
        '    End If
        'End If
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        For Each dr As DataRow In VisitsDataview.Table.Rows
            dr("tick") = True
        Next dr
    End Sub

    Private Sub btnUnselect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnselect.Click
        For Each dr As DataRow In VisitsDataview.Table.Rows
            dr("tick") = False
        Next dr

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        'Dim dtExport As New DataTable
        'dtExport.Columns.Add("Customer")
        'dtExport.Columns.Add("Site")
        'dtExport.Columns.Add("JobNumber")
        'dtExport.Columns.Add("Definition")
        'dtExport.Columns.Add("Type")
        'dtExport.Columns.Add("Status")
        'dtExport.Columns.Add("Outcome")
        'dtExport.Columns.Add("ScheduledDate")
        'dtExport.Columns.Add("Engineer")
        'dtExport.Columns.Add("TypeMakeModel")
        'dtExport.Columns.Add("ExceptionType")
        'dtExport.Columns.Add("ExceptionAppLocation")
        'dtExport.Columns.Add("ExceptionAppType")
        'dtExport.Columns.Add("ExceptionAppMake")
        'dtExport.Columns.Add("ExceptionAppModel")
        'dtExport.Columns.Add("ExceptionAppLLAppliance")
        'dtExport.Columns.Add("ExceptionAppServicedOrInspected")
        'dtExport.Columns.Add("ExceptionAppSafe")
        'dtExport.Columns.Add("ExceptionAppFlueSatisfactory")
        'dtExport.Columns.Add("ExceptionAppFlueVisual")
        'dtExport.Columns.Add("ExceptionAppFlueFlowTest")
        'dtExport.Columns.Add("ExceptionAppFlueSpillageTest")
        'dtExport.Columns.Add("ExceptionAppVentilationSatisfactory")
        'dtExport.Columns.Add("ExceptionAppSafetyOperation")
        'dtExport.Columns.Add("ExceptionAppInletStaticPressure")
        'dtExport.Columns.Add("ExceptionAppInletWorkingPressure")
        'dtExport.Columns.Add("ExceptionAppHeatInput")
        'dtExport.Columns.Add("ExceptionAppMaxBurnerPressure")
        'dtExport.Columns.Add("ExceptionAppCO2")
        'dtExport.Columns.Add("ExceptionAppCo2CoRatio")

        'Dim nr As DataRow

        'For Each dr As DataRow In VisitsDataview.Table.Rows
        '    If dr("Tick") = True Then

        '        Dim nr As DataRow
        '        nr = dtExport.NewRow
        '        nr("Customer") = dr("Customer")
        '        nr("Site") = dr("Site")
        '        nr("JobNumber") = dr("JobNumber")
        '        nr("Definition") = dr("Definition")
        '        nr("Type") = dr("Type")
        '        nr("Status") = dr("Status")
        '        nr("Outcome") = dr("Outcome")
        '        nr("ScheduledDate") = dr("ScheduledDate")
        '        nr("Engineer") = dr("Engineer")
        '        nr("TypeMakeModel") = dr("TypeMakeModel")
        '        nr("ExceptionType") = dr("ExceptionType")
        '        nr("ExceptionAppLocation") = dr("ExceptionAppLocation")
        '        nr("ExceptionAppType") = dr("ExceptionAppType")
        '        nr("ExceptionAppMake") = dr("ExceptionAppMake")
        '        nr("ExceptionAppModel") = dr("ExceptionAppModel")
        '        nr("ExceptionAppLLAppliance") = dr("ExceptionAppLLAppliance")
        '        nr("ExceptionAppServicedOrInspected") = dr("ExceptionAppServicedOrInspected")
        '        nr("ExceptionAppSafe") = dr("ExceptionAppSafe")
        '        nr("ExceptionAppFlueSatisfactory") = dr("ExceptionAppFlueSatisfactory")
        '        nr("ExceptionAppFlueVisual") = dr("ExceptionAppFlueVisual")
        '        nr("ExceptionAppFlueFlowTest") = dr("ExceptionAppFlueFlowTest")
        '        nr("ExceptionAppFlueSpillageTest") = dr("ExceptionAppFlueSpillageTest")
        '        nr("ExceptionAppVentilationSatisfactory") = dr("ExceptionAppVentilationSatisfactory")
        '        nr("ExceptionAppSafetyOperation") = dr("ExceptionAppSafetyOperation")
        '        nr("ExceptionAppInletStaticPressure") = dr("ExceptionAppInletStaticPressure")
        '        nr("ExceptionAppInletWorkingPressure") = dr("ExceptionAppInletWorkingPressure")
        '        nr("ExceptionAppHeatInput") = dr("ExceptionAppHeatInput")
        '        nr("ExceptionAppMaxBurnerPressure") = dr("ExceptionAppMaxBurnerPressure")
        '        nr("ExceptionAppCO2") = dr("ExceptionAppCO2")
        '        nr("ExceptionAppCo2CoRatio") = dr("ExceptionAppCo2CoRatio")
        '        dtExport.Rows.Add(nr)
        '    End If
        'Next
        'If Not dtExport.Rows.Count = 0 Then
        '    Dim exporter As New Entity.Sys.Exporting(dtExport, "Gas Summary Spec")
        '    exporter = Nothing
        'End If
        Export()

    End Sub

#End Region

#Region "Functions"

    Public Sub PopulateDatagrid()
        Try
            ResetFilters()
            If GetParameter(0) Is Nothing Then

            Else
                VisitsDataview = GetParameter(0)
                Me.grpFilter.Enabled = False
            End If
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetFilters()

        Me.dtpFrom.Value = Today.AddDays(-1)
        Me.dtpTo.Value = Today.AddMonths(-1)
        Me.dtpFrom.Enabled = True
        Me.dtpTo.Enabled = True

        Me.grpFilter.Enabled = True
    End Sub

    Private Sub RunFilter()
        Dim whereClause As String

        'If Me.chkVisitDate.Checked Then
        whereClause = "WHERE tblEngineerVisit.Deleted = 0 AND tblJobOfWork.Deleted = 0 AND tblJob.Deleted = 0 AND (tblInvoiceToBeRaised.InvoiceTypeID = 260 OR tblInvoiceToBeRaised.InvoiceTypeID is null) AND (DATEADD(dd, 0, DATEDIFF(dd, 0, tblEngineerVisit.StartDateTime))>= CONVERT(DATETIME, '" & Format(Me.dtpFrom.Value, "yyyy-MM-dd 00:00:00") & "', 102)) AND (DATEADD(dd, 0, DATEDIFF(dd, 0, tblEngineerVisit.StartDateTime))<= CONVERT(DATETIME, '" & Format(Me.dtpTo.Value, "yyyy-MM-dd 23:59:59") & "', 102)) AND (tblEngineerVisit.Deleted = 0)"
        'End If

        VisitsDataview = DB.Reports.Reports_BatchVisitCosts(whereClause)

        Me.grpEngineerVisits.Text = "Visits: " & VisitsDataview.Table.Rows.Count
    End Sub

    Public Sub Export()

        Dim exportData As New DataTable
        'exportData.Columns.Add("Customer")
        'exportData.Columns.Add("Site")
        'exportData.Columns.Add("SitePostcode")
        'exportData.Columns.Add("JobNumber")
        'exportData.Columns.Add("PONumber")
        'exportData.Columns.Add("JobDefinition")
        'exportData.Columns.Add("Type")
        'exportData.Columns.Add("VisitStatus")
        'exportData.Columns.Add("StartDateTime")
        'exportData.Columns.Add("Engineer")
        'exportData.Columns.Add("VisitValue", GetType(Double))
        'exportData.Columns.Add("VisitCharge")
        'exportData.Columns.Add("EngineerCost", GetType(Double))
        'exportData.Columns.Add("PartProductCost", GetType(Double))

        exportData.Columns.Add("StartDateTime", GetType(Date))
        exportData.Columns.Add("VisitStatus")
        exportData.Columns.Add("NotesToEngineer")
        exportData.Columns.Add("NotesFromEngineer")
        exportData.Columns.Add("OutcomeDetails")
        exportData.Columns.Add("VisitOutcome")
        exportData.Columns.Add("Customer")
        exportData.Columns.Add("ForSageAccountCode")
        exportData.Columns.Add("Site")
        exportData.Columns.Add("Postcode")
        exportData.Columns.Add("JobID")
        exportData.Columns.Add("JobNumber")
        exportData.Columns.Add("JobDefinition")
        exportData.Columns.Add("Type")
        exportData.Columns.Add("Engineer")
        exportData.Columns.Add("VisitCharge", GetType(Double))
        exportData.Columns.Add("EngineerCost")
        exportData.Columns.Add("PartProductCost")
        exportData.Columns.Add("PartsToFit")
        exportData.Columns.Add("SupInvoice")
        exportData.Columns.Add("Credit")
        exportData.Columns.Add("ContractType")
        exportData.Columns.Add("Jobitems")
        exportData.Columns.Add("Department")
        exportData.Columns.Add("NominalCode")
        exportData.Columns.Add("JobValue", GetType(Double))
        exportData.Columns.Add("WorkingHours")
        exportData.Columns.Add("TravelingHours")


        For itm As Integer = 0 To CType(dgVisits.DataSource, DataView).Count - 1
            dgVisits.CurrentRowIndex = itm

            Dim newRw As DataRow
            newRw = exportData.NewRow

            'newRw("Customer") = SelectedVisitDataRow("Customer")
            'newRw("Site") = SelectedVisitDataRow("Site")
            'newRw("SitePostcode") = SelectedVisitDataRow("SitePostcode")
            'newRw("JobNumber") = SelectedVisitDataRow("JobNumber")
            'newRw("PONumber") = SelectedVisitDataRow("PONumber")
            'newRw("JobDefinition") = SelectedVisitDataRow("JobDefinition")
            'newRw("Type") = SelectedVisitDataRow("Type")
            'newRw("VisitStatus") = SelectedVisitDataRow("VisitStatus")
            'newRw("StartDateTime") = SelectedVisitDataRow("StartDateTime")
            'newRw("Engineer") = SelectedVisitDataRow("Engineer")
            'newRw("VisitValue") = SelectedVisitDataRow("VisitValue")
            'newRw("VisitCharge") = SelectedVisitDataRow("VisitCharge")
            'newRw("EngineerCost") = SelectedVisitDataRow("EngineerCost")
            'newRw("PartProductCost") = SelectedVisitDataRow("PartProductCost")

            newRw("StartDateTime") = SelectedVisitDataRow("StartDateTime")
            newRw("VisitStatus") = SelectedVisitDataRow("VisitStatus")
            newRw("NotesToEngineer") = SelectedVisitDataRow("NotesToEngineer")
            newRw("NotesFromEngineer") = SelectedVisitDataRow("NotesFromEngineer")
            newRw("OutcomeDetails") = SelectedVisitDataRow("OutcomeDetails")
            newRw("VisitOutcome") = SelectedVisitDataRow("VisitOutcome")
            newRw("Customer") = SelectedVisitDataRow("Customer")
            newRw("ForSageAccountCode") = SelectedVisitDataRow("ForSageAccountCode")
            newRw("Site") = SelectedVisitDataRow("Site")
            newRw("Postcode") = SelectedVisitDataRow("Postcode")
            newRw("JobID") = SelectedVisitDataRow("JobID")
            newRw("JobNumber") = SelectedVisitDataRow("JobNumber")
            newRw("JobDefinition") = SelectedVisitDataRow("JobDefinition")
            newRw("Type") = SelectedVisitDataRow("Type")
            newRw("Engineer") = SelectedVisitDataRow("Engineer")
            newRw("VisitCharge") = SelectedVisitDataRow("VisitCharge")
            newRw("EngineerCost") = SelectedVisitDataRow("EngineerCost")
            newRw("PartProductCost") = SelectedVisitDataRow("PartProductCost")
            newRw("PartsToFit") = SelectedVisitDataRow("PartsToFit")
            newRw("SupInvoice") = SelectedVisitDataRow("SupInvoice")
            newRw("Credit") = SelectedVisitDataRow("Credit")
            newRw("ContractType") = SelectedVisitDataRow("ContractType")
            newRw("Jobitems") = SelectedVisitDataRow("Jobitems")
            newRw("Department") = SelectedVisitDataRow("Department")
            newRw("NominalCode") = SelectedVisitDataRow("NominalCode")
            newRw("JobValue") = SelectedVisitDataRow("JobValue")
            newRw("WorkingHours") = SelectedVisitDataRow("WorkingHours")
            newRw("TravelingHours") = SelectedVisitDataRow("TravelingHours")

            exportData.Rows.Add(newRw)

            dgVisits.UnSelect(itm)
        Next itm
        Dim exporter As New Entity.Sys.Exporting(exportData, "Batch Visit Costs Report")
        exporter = Nothing
    End Sub

#End Region

End Class
