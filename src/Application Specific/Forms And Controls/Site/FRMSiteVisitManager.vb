Imports FSM.Entity.Sys

Public Class FRMSiteVisitManager : Inherits FSM.FRMBaseForm : Implements IForm

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

    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtJobNumber As System.Windows.Forms.TextBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cboDefinition As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents chkVisitDate As System.Windows.Forms.CheckBox
    Friend WithEvents grpEngineerVisits As System.Windows.Forms.GroupBox
    Friend WithEvents dgVisits As System.Windows.Forms.DataGrid
    Friend WithEvents btnfindEngineer As System.Windows.Forms.Button
    Friend WithEvents txtEngineer As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboOutcome As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpEngineerVisits = New System.Windows.Forms.GroupBox
        Me.dgVisits = New System.Windows.Forms.DataGrid
        Me.btnExport = New System.Windows.Forms.Button
        Me.grpFilter = New System.Windows.Forms.GroupBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboOutcome = New System.Windows.Forms.ComboBox
        Me.btnfindEngineer = New System.Windows.Forms.Button
        Me.txtEngineer = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtpTo = New System.Windows.Forms.DateTimePicker
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker
        Me.txtJobNumber = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.chkVisitDate = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboType = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cboDefinition = New System.Windows.Forms.ComboBox
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnReset = New System.Windows.Forms.Button
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
        Me.grpEngineerVisits.Location = New System.Drawing.Point(8, 173)
        Me.grpEngineerVisits.Name = "grpEngineerVisits"
        Me.grpEngineerVisits.Size = New System.Drawing.Size(976, 407)
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
        Me.dgVisits.Location = New System.Drawing.Point(8, 20)
        Me.dgVisits.Name = "dgVisits"
        Me.dgVisits.Size = New System.Drawing.Size(960, 379)
        Me.dgVisits.TabIndex = 14
        '
        'btnExport
        '
        Me.btnExport.AccessibleDescription = "Export Job List To Excel"
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(8, 586)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(56, 23)
        Me.btnExport.TabIndex = 15
        Me.btnExport.Text = "Export"
        '
        'grpFilter
        '
        Me.grpFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilter.Controls.Add(Me.btnSearch)
        Me.grpFilter.Controls.Add(Me.Label12)
        Me.grpFilter.Controls.Add(Me.cboOutcome)
        Me.grpFilter.Controls.Add(Me.btnfindEngineer)
        Me.grpFilter.Controls.Add(Me.txtEngineer)
        Me.grpFilter.Controls.Add(Me.Label5)
        Me.grpFilter.Controls.Add(Me.dtpTo)
        Me.grpFilter.Controls.Add(Me.dtpFrom)
        Me.grpFilter.Controls.Add(Me.txtJobNumber)
        Me.grpFilter.Controls.Add(Me.Label9)
        Me.grpFilter.Controls.Add(Me.Label8)
        Me.grpFilter.Controls.Add(Me.chkVisitDate)
        Me.grpFilter.Controls.Add(Me.Label6)
        Me.grpFilter.Controls.Add(Me.cboType)
        Me.grpFilter.Controls.Add(Me.Label11)
        Me.grpFilter.Controls.Add(Me.cboDefinition)
        Me.grpFilter.Controls.Add(Me.cboStatus)
        Me.grpFilter.Controls.Add(Me.Label3)
        Me.grpFilter.Controls.Add(Me.Label10)
        Me.grpFilter.Location = New System.Drawing.Point(8, 32)
        Me.grpFilter.Name = "grpFilter"
        Me.grpFilter.Size = New System.Drawing.Size(976, 135)
        Me.grpFilter.TabIndex = 1
        Me.grpFilter.TabStop = False
        Me.grpFilter.Text = "Filter"
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(898, 106)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(70, 23)
        Me.btnSearch.TabIndex = 33
        Me.btnSearch.Text = "Run Filter"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(304, 77)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 22)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Outcome"
        '
        'cboOutcome
        '
        Me.cboOutcome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOutcome.Location = New System.Drawing.Point(377, 74)
        Me.cboOutcome.Name = "cboOutcome"
        Me.cboOutcome.Size = New System.Drawing.Size(184, 21)
        Me.cboOutcome.TabIndex = 32
        '
        'btnfindEngineer
        '
        Me.btnfindEngineer.BackColor = System.Drawing.Color.White
        Me.btnfindEngineer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfindEngineer.Location = New System.Drawing.Point(258, 20)
        Me.btnfindEngineer.Name = "btnfindEngineer"
        Me.btnfindEngineer.Size = New System.Drawing.Size(32, 23)
        Me.btnfindEngineer.TabIndex = 29
        Me.btnfindEngineer.Text = "..."
        Me.btnfindEngineer.UseVisualStyleBackColor = False
        '
        'txtEngineer
        '
        Me.txtEngineer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEngineer.Location = New System.Drawing.Point(68, 20)
        Me.txtEngineer.Name = "txtEngineer"
        Me.txtEngineer.ReadOnly = True
        Me.txtEngineer.Size = New System.Drawing.Size(184, 21)
        Me.txtEngineer.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(7, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 16)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Engineer"
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(621, 78)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(155, 21)
        Me.dtpTo.TabIndex = 13
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(621, 47)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(155, 21)
        Me.dtpFrom.TabIndex = 12
        '
        'txtJobNumber
        '
        Me.txtJobNumber.Location = New System.Drawing.Point(377, 20)
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Size = New System.Drawing.Size(184, 21)
        Me.txtJobNumber.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(565, 79)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "To"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(565, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "From"
        '
        'chkVisitDate
        '
        Me.chkVisitDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkVisitDate.UseVisualStyleBackColor = True
        Me.chkVisitDate.Location = New System.Drawing.Point(567, 18)
        Me.chkVisitDate.Name = "chkVisitDate"
        Me.chkVisitDate.Size = New System.Drawing.Size(80, 24)
        Me.chkVisitDate.TabIndex = 11
        Me.chkVisitDate.Text = "Visit Date"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(304, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Job Number"
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Location = New System.Drawing.Point(377, 47)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(184, 21)
        Me.cboType.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 77)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 22)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Status"
        '
        'cboDefinition
        '
        Me.cboDefinition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDefinition.Location = New System.Drawing.Point(68, 47)
        Me.cboDefinition.Name = "cboDefinition"
        Me.cboDefinition.Size = New System.Drawing.Size(184, 21)
        Me.cboDefinition.TabIndex = 6
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Location = New System.Drawing.Point(68, 74)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(184, 21)
        Me.cboStatus.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Definition"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(304, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 22)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Type"
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(72, 586)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(56, 23)
        Me.btnReset.TabIndex = 16
        Me.btnReset.Text = "Reset"
        '
        'FRMSiteVisitManager
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Controls.Add(Me.grpFilter)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.grpEngineerVisits)
        Me.Controls.Add(Me.btnReset)
        Me.MinimumSize = New System.Drawing.Size(1000, 528)
        Me.Name = "FRMSiteVisitManager"
        Me.Text = "Site Visit Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.btnReset, 0)
        Me.Controls.SetChildIndex(Me.grpEngineerVisits, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.grpFilter, 0)
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
        Combo.SetUpCombo(Me.cboDefinition, DynamicDataTables.JobDefinitions, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboOutcome, DynamicDataTables.OutcomeStatuses, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboStatus, DynamicDataTables.VisitStatus_For_Viewing, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        If loggedInUser.Admin = False Then
            Me.btnExport.Enabled = False
        End If
        SiteID = GetParameter(0)
        PopulateDatagrid(True)
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

            If Not VisitsDataview Is Nothing Then
                _dvVisits.AllowNew = False
                _dvVisits.AllowEdit = False
                _dvVisits.AllowDelete = False
                _dvVisits.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString
            End If

            Me.dgVisits.DataSource = VisitsDataview

            If Not VisitsDataview Is Nothing Then
                If VisitsDataview.Table.Rows.Count > 0 Then
                    Me.dgVisits.Select(0)
                End If
            End If
        End Set
    End Property

    Private ReadOnly Property SelectedVisitDataRow() As DataRow
        Get
            If VisitsDataview Is Nothing Then
                Return Nothing
            End If
            If Not Me.dgVisits.CurrentRowIndex = -1 Then
                Return VisitsDataview(Me.dgVisits.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _theEngineer As Entity.Engineers.Engineer

    Public Property theEngineer() As Entity.Engineers.Engineer
        Get
            Return _theEngineer
        End Get
        Set(ByVal Value As Entity.Engineers.Engineer)
            _theEngineer = Value
            If Not _theEngineer Is Nothing Then
                Me.txtEngineer.Text = theEngineer.Name
            Else
                Me.txtEngineer.Text = ""
            End If
        End Set
    End Property

    Private _siteID As Integer = 0

    Private Property SiteID() As Integer
        Get
            Return _siteID
        End Get
        Set(ByVal value As Integer)
            _siteID = value
        End Set
    End Property

#End Region

#Region "Setup"

    Private Sub SetupVisitDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgVisits.TableStyles(0)

        Dim StartDateTime As New DataGridLabelColumn
        StartDateTime.Format = "dd/MM/yy"
        StartDateTime.FormatInfo = Nothing
        StartDateTime.HeaderText = "Visit Date"
        StartDateTime.MappingName = "VisitDate"
        StartDateTime.ReadOnly = True
        StartDateTime.Width = 60
        StartDateTime.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(StartDateTime)

        Dim Engineer As New DataGridLabelColumn
        Engineer.Format = ""
        Engineer.FormatInfo = Nothing
        Engineer.HeaderText = "Engineer"
        Engineer.MappingName = "Engineer"
        Engineer.ReadOnly = True
        Engineer.Width = 75
        Engineer.NullText = ""
        tbStyle.GridColumnStyles.Add(Engineer)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 75
        Type.NullText = Entity.Sys.Enums.ComboValues.Not_Applicable.ToString.Replace("_", " ")
        tbStyle.GridColumnStyles.Add(Type)

        Dim NotesToEngineer As New DataGridLabelColumn
        NotesToEngineer.Format = ""
        NotesToEngineer.FormatInfo = Nothing
        NotesToEngineer.HeaderText = "Notes To Engineer"
        NotesToEngineer.MappingName = "NotesToEngineer"
        NotesToEngineer.ReadOnly = True
        NotesToEngineer.Width = 325
        NotesToEngineer.NullText = ""
        tbStyle.GridColumnStyles.Add(NotesToEngineer)

        Dim NotesFromEngineer As New DataGridLabelColumn
        NotesFromEngineer.Format = ""
        NotesFromEngineer.FormatInfo = Nothing
        NotesFromEngineer.HeaderText = "Notes From Engineer"
        NotesFromEngineer.MappingName = "NotesFromEngineer"
        NotesFromEngineer.ReadOnly = True
        NotesFromEngineer.Width = 325
        NotesFromEngineer.NullText = ""
        tbStyle.GridColumnStyles.Add(NotesFromEngineer)

        Dim VisitCharge As New DataGridLabelColumn
        VisitCharge.Format = "C"
        VisitCharge.FormatInfo = Nothing
        VisitCharge.HeaderText = "Charge"
        VisitCharge.MappingName = "VisitCharge"
        VisitCharge.ReadOnly = True
        VisitCharge.Width = 45
        VisitCharge.NullText = ""
        tbStyle.GridColumnStyles.Add(VisitCharge)

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "Job No"
        JobNumber.MappingName = "JobNumber"
        JobNumber.ReadOnly = True
        JobNumber.Width = 75
        JobNumber.NullText = ""
        tbStyle.GridColumnStyles.Add(JobNumber)

        Dim VisitStatus As New DataGridLabelColumn
        VisitStatus.Format = ""
        VisitStatus.FormatInfo = Nothing
        VisitStatus.HeaderText = "Status"
        VisitStatus.MappingName = "VisitStatus"
        VisitStatus.ReadOnly = True
        VisitStatus.Width = 60
        VisitStatus.NullText = ""
        tbStyle.GridColumnStyles.Add(VisitStatus)

        Dim VisitOutcome As New DataGridLabelColumn
        VisitOutcome.Format = ""
        VisitOutcome.FormatInfo = Nothing
        VisitOutcome.HeaderText = "Outcome"
        VisitOutcome.MappingName = "VisitOutcome"
        VisitOutcome.ReadOnly = True
        VisitOutcome.Width = 60
        VisitOutcome.NullText = ""
        tbStyle.GridColumnStyles.Add(VisitOutcome)

        Dim PartsToFit As New BitToStringDescriptionColumn
        PartsToFit.Format = ""
        PartsToFit.FormatInfo = Nothing
        PartsToFit.HeaderText = "Parts To Fit"
        PartsToFit.MappingName = "PartsToFit"
        PartsToFit.ReadOnly = True
        PartsToFit.Width = 60
        PartsToFit.NullText = ""
        tbStyle.GridColumnStyles.Add(PartsToFit)

        Select Case True
            Case IsRFT
                Dim trade As New DataGridLabelColumn
                trade.Format = ""
                trade.FormatInfo = Nothing
                trade.HeaderText = "Trade"
                trade.MappingName = "Qualification"
                trade.ReadOnly = True
                trade.Width = 85
                trade.NullText = ""
                tbStyle.GridColumnStyles.Add(trade)
        End Select

        Dim VisitValue As New DataGridLabelColumn
        VisitValue.Format = "C"
        VisitValue.FormatInfo = Nothing
        VisitValue.HeaderText = "Visit Value"
        VisitValue.MappingName = "VisitValue"
        VisitValue.ReadOnly = True
        VisitValue.Width = 60
        VisitValue.NullText = ""
        tbStyle.GridColumnStyles.Add(VisitValue)

        Dim EngineerCost As New DataGridLabelColumn
        EngineerCost.Format = "C"
        EngineerCost.FormatInfo = Nothing
        EngineerCost.HeaderText = "Engineer Cost"
        EngineerCost.MappingName = "EngineerCost"
        EngineerCost.ReadOnly = True
        EngineerCost.Width = 60
        EngineerCost.NullText = ""
        tbStyle.GridColumnStyles.Add(EngineerCost)

        Dim PartProductCost As New DataGridLabelColumn
        PartProductCost.Format = "C"
        PartProductCost.FormatInfo = Nothing
        PartProductCost.HeaderText = "Part\Product Cost"
        PartProductCost.MappingName = "PartProductCost"
        PartProductCost.ReadOnly = True
        PartProductCost.Width = 60
        PartProductCost.NullText = ""
        tbStyle.GridColumnStyles.Add(PartProductCost)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString
        Me.dgVisits.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMVisitManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ResetFilters()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

    Private Sub btnfindEngineer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfindEngineer.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblEngineer)
        If Not ID = 0 Then
            theEngineer = DB.Engineer.Engineer_Get(ID)
        End If
    End Sub

    Private Sub chkVisitDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVisitDate.CheckedChanged
        If Me.chkVisitDate.Checked Then
            Me.dtpFrom.Enabled = True
            Me.dtpTo.Enabled = True
        Else
            Me.dtpFrom.Value = Today
            Me.dtpTo.Value = Today
            Me.dtpFrom.Enabled = False
            Me.dtpTo.Enabled = False
        End If
    End Sub

    Private Sub dgVisits_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgVisits.DoubleClick
        If SelectedVisitDataRow Is Nothing Then
            ShowMessage("Please select a visit to view", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim [continue] As Boolean = False

        Select Case CInt(SelectedVisitDataRow.Item("StatusEnumID"))
            Case CInt(Entity.Sys.Enums.VisitStatus.NOT_SET)
                ShowMessage("This visit has not entered a visit life span yet.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case CInt(Entity.Sys.Enums.VisitStatus.Parts_Need_Ordering)
                ShowMessage("Parts Need Ordering for this visit, once ordered and recieved you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case CInt(Entity.Sys.Enums.VisitStatus.Waiting_For_Parts)
                ShowMessage("This visit is waiting for parts, once recieved you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case CInt(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule)
                If ShowMessage("This visit is ready for schedule, would you like to manually complete the visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    [continue] = True
                End If
            Case CInt(Entity.Sys.Enums.VisitStatus.Scheduled)
                If ShowMessage("This visit is scheduled, would you like to manually complete the visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    [continue] = True
                End If
            Case CInt(Entity.Sys.Enums.VisitStatus.Downloaded)
                ShowMessage("This visit is currently with an engineer, once returned you may view the details.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case CInt(Entity.Sys.Enums.VisitStatus.Uploaded)
                [continue] = True
            Case Entity.Sys.Enums.VisitStatus.Not_To_Be_Invoiced
                [continue] = True
            Case Entity.Sys.Enums.VisitStatus.Ready_To_Be_Invoiced
                [continue] = True
            Case Entity.Sys.Enums.VisitStatus.Invoiced
                [continue] = True
        End Select

        If [continue] Then
            ShowForm(GetType(FRMEngineerVisit), True, New Object() {SelectedVisitDataRow.Item("EngineerVisitID")})

            PopulateDatagrid(True)

        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        PopulateDatagrid(True)
    End Sub

#End Region

#Region "Functions"

    Public Sub PopulateDatagrid(ByVal withRun As Boolean)
        Try
            If withRun Then
                Dim whereClause As String = "AND (tblSite.SiteID = " & SiteID

                If Not theEngineer Is Nothing Then
                    whereClause += " AND tblEngineer.EngineerID = " & theEngineer.EngineerID & ""
                End If
                If Not Combo.GetSelectedItemValue(Me.cboDefinition) = 0 Then
                    whereClause += " AND tblJob.JobDefinitionEnumID = " & Combo.GetSelectedItemValue(Me.cboDefinition) & ""
                End If
                If Not Combo.GetSelectedItemValue(Me.cboType) = 0 Then
                    whereClause += " AND tblJob.JobTypeID = " & Combo.GetSelectedItemValue(Me.cboType) & ""
                End If
                If Not Combo.GetSelectedItemValue(Me.cboStatus) = 0 Then
                    whereClause += " AND @THEStatusEnumIDString = " & Combo.GetSelectedItemValue(Me.cboStatus) & ""
                End If
                If Not Combo.GetSelectedItemValue(Me.cboOutcome) = 0 Then
                    whereClause += " AND tblEngineerVisit.OutcomeEnumID = " & Combo.GetSelectedItemValue(Me.cboOutcome) & ""
                End If
                If Not Me.txtJobNumber.Text.Trim.Length = 0 Then
                    whereClause += " AND tblJob.JobNumber LIKE '" & Me.txtJobNumber.Text.Trim & "%'"
                End If
                If Me.chkVisitDate.Checked Then
                    whereClause += " AND tblEngineerVisit.StartDateTime >= '" & Format(Me.dtpFrom.Value, "dd-MMM-yyyy 00:00:00") & "' AND tblEngineerVisit.StartDateTime <= '" & Format(Me.dtpTo.Value, "dd-MMM-yyyy 23:59:59") & "'"
                End If

                whereClause += ")"

                VisitsDataview = DB.EngineerVisits.EngineerVisits_Get_All_ForSite(whereClause)
            Else
                VisitsDataview = Nothing
            End If
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetFilters()

        theEngineer = Nothing
        Combo.SetSelectedComboItem_By_Value(Me.cboDefinition, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboType, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboStatus, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboOutcome, 0)
        Me.txtJobNumber.Text = ""
        Me.chkVisitDate.Checked = False
        Me.dtpFrom.Value = Today
        Me.dtpTo.Value = Today
        Me.dtpFrom.Enabled = False
        Me.dtpTo.Enabled = False
        Me.grpFilter.Enabled = True
    End Sub

    Public Sub Export()
        If VisitsDataview IsNot Nothing Then
            ExportHelper.Export(VisitsDataview.Table, "SiteReport", Enums.ExportType.XLS)
        End If
    End Sub

#End Region

End Class