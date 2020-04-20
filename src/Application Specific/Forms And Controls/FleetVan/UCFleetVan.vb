Imports System.Collections.Generic
Imports System.Linq

Public Class UCFleetVan : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(Me.cboVanType, DB.FleetVanType.GetAll().Table, "VanTypeID", "Model", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboFaultType, DB.FleetVanFault.FaultTypes_GetAll().Table, "VanFaultTypeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboProcurementMethod, DynamicDataTables.FleetVanContractProcurementMethod, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)

        Select Case True
            Case IsGasway
                Combo.SetUpCombo(Me.cboDepartment, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Department).Table, "Name", "Name", Entity.Sys.Enums.ComboValues.Please_Select_Negative)
            Case Else
                Combo.SetUpCombo(Me.cboDepartment, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Department).Table, "Name", "Description", Entity.Sys.Enums.ComboValues.Please_Select_Negative)
        End Select

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

    Friend WithEvents tabHistory As TabPage
    Friend WithEvents grpVanAudit As GroupBox
    Friend WithEvents dgVanAudits As DataGrid
    Friend WithEvents tabDetails As TabPage
    Friend WithEvents grpMaintenance As GroupBox
    Friend WithEvents dtpNextServiceDate As DateTimePicker
    Friend WithEvents lblNextServiceDate As Label
    Friend WithEvents dtpLastServiceDate As DateTimePicker
    Friend WithEvents dtpMOTExpiry As DateTimePicker
    Friend WithEvents lblMOT As Label
    Friend WithEvents txtBreakdown As TextBox
    Friend WithEvents lblBreakdownCompany As Label
    Friend WithEvents lblLastService As Label
    Friend WithEvents grpEngineer As GroupBox
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents lblStartDate As Label
    Friend WithEvents lblDepartment As Label
    Friend WithEvents btnfindEngineer As Button
    Friend WithEvents txtEngineer As TextBox
    Friend WithEvents lblEngineer As Label
    Friend WithEvents grpVan As GroupBox
    Friend WithEvents lblReturned As Label
    Friend WithEvents txtAverageMileage As TextBox
    Friend WithEvents lblAverageMileage As Label
    Friend WithEvents txtMileage As TextBox
    Friend WithEvents lblMileage As Label
    Friend WithEvents txtModel As TextBox
    Friend WithEvents lblMdoel As Label
    Friend WithEvents cboVanType As ComboBox
    Friend WithEvents txtMake As TextBox
    Friend WithEvents txtRegistration As TextBox
    Friend WithEvents lblRegistration As Label
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents lblNotes As Label
    Friend WithEvents lblInsuranceDue As Label
    Friend WithEvents lblMake As Label
    Friend WithEvents tcVans As TabControl
    Friend WithEvents dtpTaxExpiry As DateTimePicker
    Friend WithEvents lblRoadTax As Label
    Friend WithEvents btnNextService As Button
    Friend WithEvents txtLastServiceMileage As TextBox
    Friend WithEvents lblMileageLastService As Label
    Friend WithEvents chkReturned As CheckBox
    Friend WithEvents tabFaults As TabPage
    Friend WithEvents grpFaultDetails As GroupBox
    Friend WithEvents cboFaultType As ComboBox
    Friend WithEvents txtEngineerFaultNotes As TextBox
    Friend WithEvents lblEngineerNotes As Label
    Friend WithEvents lblFaultType As Label
    Friend WithEvents grpVanFaultDg As GroupBox
    Friend WithEvents dgVanFaults As DataGrid
    Friend WithEvents txtFaultNotes As TextBox
    Friend WithEvents lblFaultNotes As Label
    Friend WithEvents chkResolved As CheckBox
    Friend WithEvents dtpResolvedDate As DateTimePicker
    Friend WithEvents lblResolvedDate As Label
    Friend WithEvents dtpFaultDate As DateTimePicker
    Friend WithEvents lblFaultDate As Label
    Friend WithEvents btnRemove As Button
    Friend WithEvents tabContract As TabPage
    Friend WithEvents grpContractDetails As GroupBox
    Friend WithEvents cboProcurementMethod As ComboBox
    Friend WithEvents txtContractLength As TextBox
    Friend WithEvents txtLessor As TextBox
    Friend WithEvents lblLessor As Label
    Friend WithEvents lblProcurementMethod As Label
    Friend WithEvents lblContractLength As Label
    Friend WithEvents tabEngineerHistory As TabPage
    Friend WithEvents grpEngineerHistory As GroupBox
    Friend WithEvents dgEngineerHistory As DataGrid
    Friend WithEvents btnNewFault As Button
    Friend WithEvents dtpContractEnd As DateTimePicker
    Friend WithEvents lblContractEnd As Label
    Friend WithEvents dtpContractStart As DateTimePicker
    Friend WithEvents lblContractStart As Label
    Friend WithEvents txtAgreementRef As TextBox
    Friend WithEvents lblAgreementRef As Label
    Friend WithEvents txtContractMileage As TextBox
    Friend WithEvents lblContractMileage As Label
    Friend WithEvents grpFinances As GroupBox
    Friend WithEvents txtMonthlyRental As TextBox
    Friend WithEvents lblMonthlyRental As Label
    Friend WithEvents lblAnnualRental As Label
    Friend WithEvents txtWeeklyRental As TextBox
    Friend WithEvents txtExcessMileageRate As TextBox
    Friend WithEvents lblExcessMileageRate As Label
    Friend WithEvents lblWeeklyRental As Label
    Friend WithEvents txtAnnualRental As TextBox
    Friend WithEvents txtContractNotes As TextBox
    Friend WithEvents lblContractNotes As Label
    Friend WithEvents tabServiceHistory As TabPage
    Friend WithEvents gpServiceHistory As GroupBox
    Friend WithEvents dgServiceHistory As DataGrid
    Friend WithEvents btnRemoveEquipment As Button
    Friend WithEvents btnAddEquipment As Button
    Friend WithEvents dgEquipment As DataGrid
    Friend WithEvents txtForecastExcessCost As TextBox
    Friend WithEvents lblForcastedExcessCost As Label
    Friend WithEvents txtExcessMileageCost As TextBox
    Friend WithEvents lblExcessCost As Label
    Friend WithEvents tabDocuments As TabPage
    Friend WithEvents txtJobRef As TextBox
    Friend WithEvents lblJobRef As Label
    Friend WithEvents txtStatus As TextBox
    Friend WithEvents lblVisitStatus As Label
    Friend WithEvents txtScheduled As TextBox
    Friend WithEvents lblScheduled As Label
    Friend WithEvents grpHistoryDetails As GroupBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblUser As Label
    Friend WithEvents dtpHistoryDate As DateTimePicker
    Friend WithEvents lblDate As Label
    Friend WithEvents txtChange As TextBox
    Friend WithEvents lblChange As Label
    Friend WithEvents txtOutcome As TextBox
    Friend WithEvents lblOutcome As Label
    Friend WithEvents btnEndContract As Button
    Friend WithEvents chkEndDate As CheckBox
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents txtAdditionalNotes As TextBox
    Friend WithEvents lblAddNotes As Label
    Friend WithEvents chkArchive As CheckBox
    Friend WithEvents chkHideArchive As CheckBox
    Friend WithEvents txtStartingMileage As TextBox
    Friend WithEvents lblStartingMileage As Label
    Friend WithEvents txtTyreSize As TextBox
    Friend WithEvents lblTyresSize As Label
    Friend WithEvents dtpBreakdownExpiry As DateTimePicker
    Friend WithEvents lblBreakdownExpiry As Label
    Friend WithEvents dtpWarrantyExpiry As DateTimePicker
    Friend WithEvents lblWarrantyExpiry As Label
    Friend WithEvents btnRemoveContractEndDate As Button
    Friend WithEvents cboDepartment As ComboBox
    Friend WithEvents btnSaveFault As Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tabHistory = New System.Windows.Forms.TabPage()
        Me.grpHistoryDetails = New System.Windows.Forms.GroupBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.dtpHistoryDate = New System.Windows.Forms.DateTimePicker()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.txtChange = New System.Windows.Forms.TextBox()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.grpVanAudit = New System.Windows.Forms.GroupBox()
        Me.dgVanAudits = New System.Windows.Forms.DataGrid()
        Me.tabDetails = New System.Windows.Forms.TabPage()
        Me.grpMaintenance = New System.Windows.Forms.GroupBox()
        Me.dtpBreakdownExpiry = New System.Windows.Forms.DateTimePicker()
        Me.lblBreakdownExpiry = New System.Windows.Forms.Label()
        Me.dtpWarrantyExpiry = New System.Windows.Forms.DateTimePicker()
        Me.lblWarrantyExpiry = New System.Windows.Forms.Label()
        Me.txtLastServiceMileage = New System.Windows.Forms.TextBox()
        Me.lblMileageLastService = New System.Windows.Forms.Label()
        Me.btnNextService = New System.Windows.Forms.Button()
        Me.dtpTaxExpiry = New System.Windows.Forms.DateTimePicker()
        Me.lblRoadTax = New System.Windows.Forms.Label()
        Me.dtpNextServiceDate = New System.Windows.Forms.DateTimePicker()
        Me.lblNextServiceDate = New System.Windows.Forms.Label()
        Me.dtpLastServiceDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpMOTExpiry = New System.Windows.Forms.DateTimePicker()
        Me.lblMOT = New System.Windows.Forms.Label()
        Me.txtBreakdown = New System.Windows.Forms.TextBox()
        Me.lblBreakdownCompany = New System.Windows.Forms.Label()
        Me.lblLastService = New System.Windows.Forms.Label()
        Me.grpEngineer = New System.Windows.Forms.GroupBox()
        Me.cboDepartment = New System.Windows.Forms.ComboBox()
        Me.chkEndDate = New System.Windows.Forms.CheckBox()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.btnfindEngineer = New System.Windows.Forms.Button()
        Me.txtEngineer = New System.Windows.Forms.TextBox()
        Me.lblEngineer = New System.Windows.Forms.Label()
        Me.grpVan = New System.Windows.Forms.GroupBox()
        Me.txtTyreSize = New System.Windows.Forms.TextBox()
        Me.lblTyresSize = New System.Windows.Forms.Label()
        Me.btnRemoveEquipment = New System.Windows.Forms.Button()
        Me.btnAddEquipment = New System.Windows.Forms.Button()
        Me.dgEquipment = New System.Windows.Forms.DataGrid()
        Me.chkReturned = New System.Windows.Forms.CheckBox()
        Me.lblReturned = New System.Windows.Forms.Label()
        Me.txtAverageMileage = New System.Windows.Forms.TextBox()
        Me.lblAverageMileage = New System.Windows.Forms.Label()
        Me.txtMileage = New System.Windows.Forms.TextBox()
        Me.lblMileage = New System.Windows.Forms.Label()
        Me.txtModel = New System.Windows.Forms.TextBox()
        Me.lblMdoel = New System.Windows.Forms.Label()
        Me.cboVanType = New System.Windows.Forms.ComboBox()
        Me.txtMake = New System.Windows.Forms.TextBox()
        Me.txtRegistration = New System.Windows.Forms.TextBox()
        Me.lblRegistration = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.lblInsuranceDue = New System.Windows.Forms.Label()
        Me.lblMake = New System.Windows.Forms.Label()
        Me.tcVans = New System.Windows.Forms.TabControl()
        Me.tabFaults = New System.Windows.Forms.TabPage()
        Me.chkHideArchive = New System.Windows.Forms.CheckBox()
        Me.grpFaultDetails = New System.Windows.Forms.GroupBox()
        Me.chkArchive = New System.Windows.Forms.CheckBox()
        Me.txtAdditionalNotes = New System.Windows.Forms.TextBox()
        Me.lblAddNotes = New System.Windows.Forms.Label()
        Me.txtOutcome = New System.Windows.Forms.TextBox()
        Me.lblOutcome = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.lblVisitStatus = New System.Windows.Forms.Label()
        Me.txtScheduled = New System.Windows.Forms.TextBox()
        Me.lblScheduled = New System.Windows.Forms.Label()
        Me.txtJobRef = New System.Windows.Forms.TextBox()
        Me.lblJobRef = New System.Windows.Forms.Label()
        Me.btnNewFault = New System.Windows.Forms.Button()
        Me.chkResolved = New System.Windows.Forms.CheckBox()
        Me.dtpResolvedDate = New System.Windows.Forms.DateTimePicker()
        Me.lblResolvedDate = New System.Windows.Forms.Label()
        Me.dtpFaultDate = New System.Windows.Forms.DateTimePicker()
        Me.lblFaultDate = New System.Windows.Forms.Label()
        Me.txtFaultNotes = New System.Windows.Forms.TextBox()
        Me.lblFaultNotes = New System.Windows.Forms.Label()
        Me.cboFaultType = New System.Windows.Forms.ComboBox()
        Me.txtEngineerFaultNotes = New System.Windows.Forms.TextBox()
        Me.lblEngineerNotes = New System.Windows.Forms.Label()
        Me.lblFaultType = New System.Windows.Forms.Label()
        Me.grpVanFaultDg = New System.Windows.Forms.GroupBox()
        Me.dgVanFaults = New System.Windows.Forms.DataGrid()
        Me.tabContract = New System.Windows.Forms.TabPage()
        Me.grpFinances = New System.Windows.Forms.GroupBox()
        Me.txtForecastExcessCost = New System.Windows.Forms.TextBox()
        Me.lblForcastedExcessCost = New System.Windows.Forms.Label()
        Me.txtExcessMileageCost = New System.Windows.Forms.TextBox()
        Me.lblExcessCost = New System.Windows.Forms.Label()
        Me.txtAnnualRental = New System.Windows.Forms.TextBox()
        Me.txtMonthlyRental = New System.Windows.Forms.TextBox()
        Me.lblMonthlyRental = New System.Windows.Forms.Label()
        Me.lblAnnualRental = New System.Windows.Forms.Label()
        Me.txtWeeklyRental = New System.Windows.Forms.TextBox()
        Me.txtExcessMileageRate = New System.Windows.Forms.TextBox()
        Me.lblExcessMileageRate = New System.Windows.Forms.Label()
        Me.lblWeeklyRental = New System.Windows.Forms.Label()
        Me.grpContractDetails = New System.Windows.Forms.GroupBox()
        Me.btnRemoveContractEndDate = New System.Windows.Forms.Button()
        Me.txtStartingMileage = New System.Windows.Forms.TextBox()
        Me.lblStartingMileage = New System.Windows.Forms.Label()
        Me.btnEndContract = New System.Windows.Forms.Button()
        Me.txtContractNotes = New System.Windows.Forms.TextBox()
        Me.lblContractNotes = New System.Windows.Forms.Label()
        Me.txtAgreementRef = New System.Windows.Forms.TextBox()
        Me.lblAgreementRef = New System.Windows.Forms.Label()
        Me.txtContractMileage = New System.Windows.Forms.TextBox()
        Me.lblContractMileage = New System.Windows.Forms.Label()
        Me.dtpContractEnd = New System.Windows.Forms.DateTimePicker()
        Me.lblContractEnd = New System.Windows.Forms.Label()
        Me.dtpContractStart = New System.Windows.Forms.DateTimePicker()
        Me.lblContractStart = New System.Windows.Forms.Label()
        Me.cboProcurementMethod = New System.Windows.Forms.ComboBox()
        Me.txtContractLength = New System.Windows.Forms.TextBox()
        Me.txtLessor = New System.Windows.Forms.TextBox()
        Me.lblLessor = New System.Windows.Forms.Label()
        Me.lblProcurementMethod = New System.Windows.Forms.Label()
        Me.lblContractLength = New System.Windows.Forms.Label()
        Me.tabEngineerHistory = New System.Windows.Forms.TabPage()
        Me.grpEngineerHistory = New System.Windows.Forms.GroupBox()
        Me.dgEngineerHistory = New System.Windows.Forms.DataGrid()
        Me.tabServiceHistory = New System.Windows.Forms.TabPage()
        Me.gpServiceHistory = New System.Windows.Forms.GroupBox()
        Me.dgServiceHistory = New System.Windows.Forms.DataGrid()
        Me.tabDocuments = New System.Windows.Forms.TabPage()
        Me.btnSaveFault = New System.Windows.Forms.Button()
        Me.tabHistory.SuspendLayout()
        Me.grpHistoryDetails.SuspendLayout()
        Me.grpVanAudit.SuspendLayout()
        CType(Me.dgVanAudits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDetails.SuspendLayout()
        Me.grpMaintenance.SuspendLayout()
        Me.grpEngineer.SuspendLayout()
        Me.grpVan.SuspendLayout()
        CType(Me.dgEquipment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcVans.SuspendLayout()
        Me.tabFaults.SuspendLayout()
        Me.grpFaultDetails.SuspendLayout()
        Me.grpVanFaultDg.SuspendLayout()
        CType(Me.dgVanFaults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabContract.SuspendLayout()
        Me.grpFinances.SuspendLayout()
        Me.grpContractDetails.SuspendLayout()
        Me.tabEngineerHistory.SuspendLayout()
        Me.grpEngineerHistory.SuspendLayout()
        CType(Me.dgEngineerHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabServiceHistory.SuspendLayout()
        Me.gpServiceHistory.SuspendLayout()
        CType(Me.dgServiceHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabHistory
        '
        Me.tabHistory.Controls.Add(Me.grpHistoryDetails)
        Me.tabHistory.Controls.Add(Me.grpVanAudit)
        Me.tabHistory.Location = New System.Drawing.Point(4, 22)
        Me.tabHistory.Name = "tabHistory"
        Me.tabHistory.Size = New System.Drawing.Size(675, 702)
        Me.tabHistory.TabIndex = 1
        Me.tabHistory.Text = "History"
        Me.tabHistory.UseVisualStyleBackColor = True
        '
        'grpHistoryDetails
        '
        Me.grpHistoryDetails.Controls.Add(Me.txtUsername)
        Me.grpHistoryDetails.Controls.Add(Me.lblUser)
        Me.grpHistoryDetails.Controls.Add(Me.dtpHistoryDate)
        Me.grpHistoryDetails.Controls.Add(Me.lblDate)
        Me.grpHistoryDetails.Controls.Add(Me.txtChange)
        Me.grpHistoryDetails.Controls.Add(Me.lblChange)
        Me.grpHistoryDetails.Location = New System.Drawing.Point(6, 7)
        Me.grpHistoryDetails.Name = "grpHistoryDetails"
        Me.grpHistoryDetails.Size = New System.Drawing.Size(664, 241)
        Me.grpHistoryDetails.TabIndex = 17
        Me.grpHistoryDetails.TabStop = False
        Me.grpHistoryDetails.Text = "History Details"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(372, 24)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.ReadOnly = True
        Me.txtUsername.Size = New System.Drawing.Size(146, 21)
        Me.txtUsername.TabIndex = 68
        '
        'lblUser
        '
        Me.lblUser.Location = New System.Drawing.Point(312, 27)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(44, 20)
        Me.lblUser.TabIndex = 67
        Me.lblUser.Text = "User"
        '
        'dtpHistoryDate
        '
        Me.dtpHistoryDate.Enabled = False
        Me.dtpHistoryDate.Location = New System.Drawing.Point(89, 21)
        Me.dtpHistoryDate.Name = "dtpHistoryDate"
        Me.dtpHistoryDate.Size = New System.Drawing.Size(146, 21)
        Me.dtpHistoryDate.TabIndex = 2
        Me.dtpHistoryDate.Tag = ""
        '
        'lblDate
        '
        Me.lblDate.Location = New System.Drawing.Point(9, 27)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(85, 20)
        Me.lblDate.TabIndex = 65
        Me.lblDate.Text = "Date"
        '
        'txtChange
        '
        Me.txtChange.Location = New System.Drawing.Point(89, 64)
        Me.txtChange.Multiline = True
        Me.txtChange.Name = "txtChange"
        Me.txtChange.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtChange.Size = New System.Drawing.Size(569, 161)
        Me.txtChange.TabIndex = 6
        Me.txtChange.Tag = ""
        '
        'lblChange
        '
        Me.lblChange.Location = New System.Drawing.Point(10, 64)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(59, 20)
        Me.lblChange.TabIndex = 45
        Me.lblChange.Text = "Change"
        '
        'grpVanAudit
        '
        Me.grpVanAudit.Controls.Add(Me.dgVanAudits)
        Me.grpVanAudit.Location = New System.Drawing.Point(3, 254)
        Me.grpVanAudit.Name = "grpVanAudit"
        Me.grpVanAudit.Size = New System.Drawing.Size(664, 553)
        Me.grpVanAudit.TabIndex = 4
        Me.grpVanAudit.TabStop = False
        Me.grpVanAudit.Text = "Van Audit"
        '
        'dgVanAudits
        '
        Me.dgVanAudits.DataMember = ""
        Me.dgVanAudits.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgVanAudits.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgVanAudits.Location = New System.Drawing.Point(3, 17)
        Me.dgVanAudits.Name = "dgVanAudits"
        Me.dgVanAudits.Size = New System.Drawing.Size(658, 533)
        Me.dgVanAudits.TabIndex = 15
        '
        'tabDetails
        '
        Me.tabDetails.Controls.Add(Me.grpMaintenance)
        Me.tabDetails.Controls.Add(Me.grpEngineer)
        Me.tabDetails.Controls.Add(Me.grpVan)
        Me.tabDetails.Location = New System.Drawing.Point(4, 22)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Size = New System.Drawing.Size(675, 702)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "Main Details"
        '
        'grpMaintenance
        '
        Me.grpMaintenance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpMaintenance.Controls.Add(Me.dtpBreakdownExpiry)
        Me.grpMaintenance.Controls.Add(Me.lblBreakdownExpiry)
        Me.grpMaintenance.Controls.Add(Me.dtpWarrantyExpiry)
        Me.grpMaintenance.Controls.Add(Me.lblWarrantyExpiry)
        Me.grpMaintenance.Controls.Add(Me.txtLastServiceMileage)
        Me.grpMaintenance.Controls.Add(Me.lblMileageLastService)
        Me.grpMaintenance.Controls.Add(Me.btnNextService)
        Me.grpMaintenance.Controls.Add(Me.dtpTaxExpiry)
        Me.grpMaintenance.Controls.Add(Me.lblRoadTax)
        Me.grpMaintenance.Controls.Add(Me.dtpNextServiceDate)
        Me.grpMaintenance.Controls.Add(Me.lblNextServiceDate)
        Me.grpMaintenance.Controls.Add(Me.dtpLastServiceDate)
        Me.grpMaintenance.Controls.Add(Me.dtpMOTExpiry)
        Me.grpMaintenance.Controls.Add(Me.lblMOT)
        Me.grpMaintenance.Controls.Add(Me.txtBreakdown)
        Me.grpMaintenance.Controls.Add(Me.lblBreakdownCompany)
        Me.grpMaintenance.Controls.Add(Me.lblLastService)
        Me.grpMaintenance.Location = New System.Drawing.Point(8, 302)
        Me.grpMaintenance.Name = "grpMaintenance"
        Me.grpMaintenance.Size = New System.Drawing.Size(664, 222)
        Me.grpMaintenance.TabIndex = 61
        Me.grpMaintenance.TabStop = False
        Me.grpMaintenance.Text = "Maintenance"
        '
        'dtpBreakdownExpiry
        '
        Me.dtpBreakdownExpiry.Location = New System.Drawing.Point(457, 178)
        Me.dtpBreakdownExpiry.Name = "dtpBreakdownExpiry"
        Me.dtpBreakdownExpiry.Size = New System.Drawing.Size(141, 21)
        Me.dtpBreakdownExpiry.TabIndex = 71
        Me.dtpBreakdownExpiry.Tag = ""
        '
        'lblBreakdownExpiry
        '
        Me.lblBreakdownExpiry.Location = New System.Drawing.Point(325, 184)
        Me.lblBreakdownExpiry.Name = "lblBreakdownExpiry"
        Me.lblBreakdownExpiry.Size = New System.Drawing.Size(117, 20)
        Me.lblBreakdownExpiry.TabIndex = 72
        Me.lblBreakdownExpiry.Text = "Breakdown Expiry"
        '
        'dtpWarrantyExpiry
        '
        Me.dtpWarrantyExpiry.Location = New System.Drawing.Point(457, 138)
        Me.dtpWarrantyExpiry.Name = "dtpWarrantyExpiry"
        Me.dtpWarrantyExpiry.Size = New System.Drawing.Size(141, 21)
        Me.dtpWarrantyExpiry.TabIndex = 69
        Me.dtpWarrantyExpiry.Tag = ""
        '
        'lblWarrantyExpiry
        '
        Me.lblWarrantyExpiry.Location = New System.Drawing.Point(325, 144)
        Me.lblWarrantyExpiry.Name = "lblWarrantyExpiry"
        Me.lblWarrantyExpiry.Size = New System.Drawing.Size(105, 20)
        Me.lblWarrantyExpiry.TabIndex = 70
        Me.lblWarrantyExpiry.Text = "Warranty Expiry"
        '
        'txtLastServiceMileage
        '
        Me.txtLastServiceMileage.Location = New System.Drawing.Point(489, 18)
        Me.txtLastServiceMileage.Name = "txtLastServiceMileage"
        Me.txtLastServiceMileage.Size = New System.Drawing.Size(109, 21)
        Me.txtLastServiceMileage.TabIndex = 10
        Me.txtLastServiceMileage.Tag = " "
        '
        'lblMileageLastService
        '
        Me.lblMileageLastService.Location = New System.Drawing.Point(325, 21)
        Me.lblMileageLastService.Name = "lblMileageLastService"
        Me.lblMileageLastService.Size = New System.Drawing.Size(142, 20)
        Me.lblMileageLastService.TabIndex = 68
        Me.lblMileageLastService.Text = "Mileage at Last Service"
        '
        'btnNextService
        '
        Me.btnNextService.Location = New System.Drawing.Point(328, 56)
        Me.btnNextService.Name = "btnNextService"
        Me.btnNextService.Size = New System.Drawing.Size(270, 21)
        Me.btnNextService.TabIndex = 12
        Me.btnNextService.Text = "Calculate Next Service"
        Me.btnNextService.UseVisualStyleBackColor = True
        '
        'dtpTaxExpiry
        '
        Me.dtpTaxExpiry.Location = New System.Drawing.Point(120, 138)
        Me.dtpTaxExpiry.Name = "dtpTaxExpiry"
        Me.dtpTaxExpiry.Size = New System.Drawing.Size(138, 21)
        Me.dtpTaxExpiry.TabIndex = 15
        Me.dtpTaxExpiry.Tag = "Van.InsuranceDue"
        '
        'lblRoadTax
        '
        Me.lblRoadTax.Location = New System.Drawing.Point(9, 144)
        Me.lblRoadTax.Name = "lblRoadTax"
        Me.lblRoadTax.Size = New System.Drawing.Size(84, 20)
        Me.lblRoadTax.TabIndex = 65
        Me.lblRoadTax.Text = "Tax Expiry"
        '
        'dtpNextServiceDate
        '
        Me.dtpNextServiceDate.Location = New System.Drawing.Point(120, 54)
        Me.dtpNextServiceDate.Name = "dtpNextServiceDate"
        Me.dtpNextServiceDate.Size = New System.Drawing.Size(138, 21)
        Me.dtpNextServiceDate.TabIndex = 11
        Me.dtpNextServiceDate.Tag = "Van.InsuranceDue"
        '
        'lblNextServiceDate
        '
        Me.lblNextServiceDate.Location = New System.Drawing.Point(9, 60)
        Me.lblNextServiceDate.Name = "lblNextServiceDate"
        Me.lblNextServiceDate.Size = New System.Drawing.Size(85, 20)
        Me.lblNextServiceDate.TabIndex = 62
        Me.lblNextServiceDate.Text = "Next Service"
        '
        'dtpLastServiceDate
        '
        Me.dtpLastServiceDate.Location = New System.Drawing.Point(120, 18)
        Me.dtpLastServiceDate.Name = "dtpLastServiceDate"
        Me.dtpLastServiceDate.Size = New System.Drawing.Size(138, 21)
        Me.dtpLastServiceDate.TabIndex = 9
        Me.dtpLastServiceDate.Tag = "Van.InsuranceDue"
        '
        'dtpMOTExpiry
        '
        Me.dtpMOTExpiry.Location = New System.Drawing.Point(120, 99)
        Me.dtpMOTExpiry.Name = "dtpMOTExpiry"
        Me.dtpMOTExpiry.Size = New System.Drawing.Size(138, 21)
        Me.dtpMOTExpiry.TabIndex = 13
        Me.dtpMOTExpiry.Tag = "Van.InsuranceDue"
        '
        'lblMOT
        '
        Me.lblMOT.Location = New System.Drawing.Point(9, 105)
        Me.lblMOT.Name = "lblMOT"
        Me.lblMOT.Size = New System.Drawing.Size(84, 20)
        Me.lblMOT.TabIndex = 58
        Me.lblMOT.Text = "MOT Expiry"
        '
        'txtBreakdown
        '
        Me.txtBreakdown.Location = New System.Drawing.Point(457, 97)
        Me.txtBreakdown.Name = "txtBreakdown"
        Me.txtBreakdown.Size = New System.Drawing.Size(141, 21)
        Me.txtBreakdown.TabIndex = 16
        Me.txtBreakdown.Tag = " "
        '
        'lblBreakdownCompany
        '
        Me.lblBreakdownCompany.Location = New System.Drawing.Point(325, 100)
        Me.lblBreakdownCompany.Name = "lblBreakdownCompany"
        Me.lblBreakdownCompany.Size = New System.Drawing.Size(105, 20)
        Me.lblBreakdownCompany.TabIndex = 53
        Me.lblBreakdownCompany.Text = "Breakdown"
        '
        'lblLastService
        '
        Me.lblLastService.Location = New System.Drawing.Point(8, 24)
        Me.lblLastService.Name = "lblLastService"
        Me.lblLastService.Size = New System.Drawing.Size(85, 20)
        Me.lblLastService.TabIndex = 31
        Me.lblLastService.Text = "Last Service"
        '
        'grpEngineer
        '
        Me.grpEngineer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpEngineer.Controls.Add(Me.cboDepartment)
        Me.grpEngineer.Controls.Add(Me.chkEndDate)
        Me.grpEngineer.Controls.Add(Me.dtpEndDate)
        Me.grpEngineer.Controls.Add(Me.btnRemove)
        Me.grpEngineer.Controls.Add(Me.dtpStartDate)
        Me.grpEngineer.Controls.Add(Me.lblStartDate)
        Me.grpEngineer.Controls.Add(Me.lblDepartment)
        Me.grpEngineer.Controls.Add(Me.btnfindEngineer)
        Me.grpEngineer.Controls.Add(Me.txtEngineer)
        Me.grpEngineer.Controls.Add(Me.lblEngineer)
        Me.grpEngineer.Location = New System.Drawing.Point(8, 524)
        Me.grpEngineer.Name = "grpEngineer"
        Me.grpEngineer.Size = New System.Drawing.Size(664, 152)
        Me.grpEngineer.TabIndex = 45
        Me.grpEngineer.TabStop = False
        Me.grpEngineer.Text = "Engineer"
        '
        'cboDepartment
        '
        Me.cboDepartment.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartment.Location = New System.Drawing.Point(120, 52)
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(146, 21)
        Me.cboDepartment.TabIndex = 50
        Me.cboDepartment.Tag = ""
        '
        'chkEndDate
        '
        Me.chkEndDate.AutoSize = True
        Me.chkEndDate.BackColor = System.Drawing.SystemColors.Control
        Me.chkEndDate.Location = New System.Drawing.Point(328, 89)
        Me.chkEndDate.Name = "chkEndDate"
        Me.chkEndDate.Size = New System.Drawing.Size(78, 17)
        Me.chkEndDate.TabIndex = 65
        Me.chkEndDate.Text = "End Date"
        Me.chkEndDate.UseVisualStyleBackColor = False
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Enabled = False
        Me.dtpEndDate.Location = New System.Drawing.Point(421, 85)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(138, 21)
        Me.dtpEndDate.TabIndex = 63
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(489, 17)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(75, 23)
        Me.btnRemove.TabIndex = 62
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(120, 84)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(138, 21)
        Me.dtpStartDate.TabIndex = 21
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(9, 90)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(84, 20)
        Me.lblStartDate.TabIndex = 58
        Me.lblStartDate.Text = "Start Date"
        '
        'lblDepartment
        '
        Me.lblDepartment.Location = New System.Drawing.Point(9, 55)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(104, 20)
        Me.lblDepartment.TabIndex = 55
        Me.lblDepartment.Text = "Department"
        '
        'btnfindEngineer
        '
        Me.btnfindEngineer.BackColor = System.Drawing.Color.White
        Me.btnfindEngineer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfindEngineer.Location = New System.Drawing.Point(337, 19)
        Me.btnfindEngineer.Name = "btnfindEngineer"
        Me.btnfindEngineer.Size = New System.Drawing.Size(32, 23)
        Me.btnfindEngineer.TabIndex = 18
        Me.btnfindEngineer.Text = "..."
        Me.btnfindEngineer.UseVisualStyleBackColor = False
        '
        'txtEngineer
        '
        Me.txtEngineer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEngineer.Location = New System.Drawing.Point(120, 19)
        Me.txtEngineer.Name = "txtEngineer"
        Me.txtEngineer.ReadOnly = True
        Me.txtEngineer.Size = New System.Drawing.Size(201, 21)
        Me.txtEngineer.TabIndex = 17
        '
        'lblEngineer
        '
        Me.lblEngineer.Location = New System.Drawing.Point(8, 24)
        Me.lblEngineer.Name = "lblEngineer"
        Me.lblEngineer.Size = New System.Drawing.Size(85, 20)
        Me.lblEngineer.TabIndex = 31
        Me.lblEngineer.Text = "Engineer"
        '
        'grpVan
        '
        Me.grpVan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpVan.Controls.Add(Me.txtTyreSize)
        Me.grpVan.Controls.Add(Me.lblTyresSize)
        Me.grpVan.Controls.Add(Me.btnRemoveEquipment)
        Me.grpVan.Controls.Add(Me.btnAddEquipment)
        Me.grpVan.Controls.Add(Me.dgEquipment)
        Me.grpVan.Controls.Add(Me.chkReturned)
        Me.grpVan.Controls.Add(Me.lblReturned)
        Me.grpVan.Controls.Add(Me.txtAverageMileage)
        Me.grpVan.Controls.Add(Me.lblAverageMileage)
        Me.grpVan.Controls.Add(Me.txtMileage)
        Me.grpVan.Controls.Add(Me.lblMileage)
        Me.grpVan.Controls.Add(Me.txtModel)
        Me.grpVan.Controls.Add(Me.lblMdoel)
        Me.grpVan.Controls.Add(Me.cboVanType)
        Me.grpVan.Controls.Add(Me.txtMake)
        Me.grpVan.Controls.Add(Me.txtRegistration)
        Me.grpVan.Controls.Add(Me.lblRegistration)
        Me.grpVan.Controls.Add(Me.txtNotes)
        Me.grpVan.Controls.Add(Me.lblNotes)
        Me.grpVan.Controls.Add(Me.lblInsuranceDue)
        Me.grpVan.Controls.Add(Me.lblMake)
        Me.grpVan.Location = New System.Drawing.Point(8, 8)
        Me.grpVan.Name = "grpVan"
        Me.grpVan.Size = New System.Drawing.Size(664, 288)
        Me.grpVan.TabIndex = 2
        Me.grpVan.TabStop = False
        Me.grpVan.Text = "Details"
        '
        'txtTyreSize
        '
        Me.txtTyreSize.Location = New System.Drawing.Point(477, 160)
        Me.txtTyreSize.MaxLength = 10
        Me.txtTyreSize.Name = "txtTyreSize"
        Me.txtTyreSize.Size = New System.Drawing.Size(161, 21)
        Me.txtTyreSize.TabIndex = 48
        '
        'lblTyresSize
        '
        Me.lblTyresSize.Location = New System.Drawing.Point(363, 163)
        Me.lblTyresSize.Name = "lblTyresSize"
        Me.lblTyresSize.Size = New System.Drawing.Size(81, 20)
        Me.lblTyresSize.TabIndex = 49
        Me.lblTyresSize.Text = "Tyre Size"
        '
        'btnRemoveEquipment
        '
        Me.btnRemoveEquipment.Location = New System.Drawing.Point(367, 121)
        Me.btnRemoveEquipment.Name = "btnRemoveEquipment"
        Me.btnRemoveEquipment.Size = New System.Drawing.Size(75, 23)
        Me.btnRemoveEquipment.TabIndex = 46
        Me.btnRemoveEquipment.Text = "Remove"
        Me.btnRemoveEquipment.UseVisualStyleBackColor = True
        '
        'btnAddEquipment
        '
        Me.btnAddEquipment.Location = New System.Drawing.Point(563, 121)
        Me.btnAddEquipment.Name = "btnAddEquipment"
        Me.btnAddEquipment.Size = New System.Drawing.Size(75, 23)
        Me.btnAddEquipment.TabIndex = 47
        Me.btnAddEquipment.Text = "Add"
        Me.btnAddEquipment.UseVisualStyleBackColor = True
        '
        'dgEquipment
        '
        Me.dgEquipment.DataMember = ""
        Me.dgEquipment.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgEquipment.Location = New System.Drawing.Point(367, 10)
        Me.dgEquipment.Name = "dgEquipment"
        Me.dgEquipment.Size = New System.Drawing.Size(271, 103)
        Me.dgEquipment.TabIndex = 44
        '
        'chkReturned
        '
        Me.chkReturned.AutoSize = True
        Me.chkReturned.BackColor = System.Drawing.SystemColors.Control
        Me.chkReturned.Location = New System.Drawing.Point(478, 194)
        Me.chkReturned.Name = "chkReturned"
        Me.chkReturned.Size = New System.Drawing.Size(34, 17)
        Me.chkReturned.TabIndex = 7
        Me.chkReturned.Text = "  "
        Me.chkReturned.UseVisualStyleBackColor = False
        '
        'lblReturned
        '
        Me.lblReturned.Location = New System.Drawing.Point(364, 195)
        Me.lblReturned.Name = "lblReturned"
        Me.lblReturned.Size = New System.Drawing.Size(81, 20)
        Me.lblReturned.TabIndex = 43
        Me.lblReturned.Text = "Returned"
        '
        'txtAverageMileage
        '
        Me.txtAverageMileage.Enabled = False
        Me.txtAverageMileage.Location = New System.Drawing.Point(120, 195)
        Me.txtAverageMileage.MaxLength = 10
        Me.txtAverageMileage.Name = "txtAverageMileage"
        Me.txtAverageMileage.Size = New System.Drawing.Size(146, 21)
        Me.txtAverageMileage.TabIndex = 6
        '
        'lblAverageMileage
        '
        Me.lblAverageMileage.Location = New System.Drawing.Point(6, 198)
        Me.lblAverageMileage.Name = "lblAverageMileage"
        Me.lblAverageMileage.Size = New System.Drawing.Size(112, 20)
        Me.lblAverageMileage.TabIndex = 42
        Me.lblAverageMileage.Text = "Average Mileage"
        '
        'txtMileage
        '
        Me.txtMileage.Location = New System.Drawing.Point(120, 160)
        Me.txtMileage.MaxLength = 10
        Me.txtMileage.Name = "txtMileage"
        Me.txtMileage.Size = New System.Drawing.Size(146, 21)
        Me.txtMileage.TabIndex = 5
        '
        'lblMileage
        '
        Me.lblMileage.Location = New System.Drawing.Point(6, 163)
        Me.lblMileage.Name = "lblMileage"
        Me.lblMileage.Size = New System.Drawing.Size(81, 20)
        Me.lblMileage.TabIndex = 40
        Me.lblMileage.Text = "Mileage"
        '
        'txtModel
        '
        Me.txtModel.Enabled = False
        Me.txtModel.Location = New System.Drawing.Point(120, 125)
        Me.txtModel.MaxLength = 10
        Me.txtModel.Name = "txtModel"
        Me.txtModel.Size = New System.Drawing.Size(146, 21)
        Me.txtModel.TabIndex = 4
        '
        'lblMdoel
        '
        Me.lblMdoel.Location = New System.Drawing.Point(6, 128)
        Me.lblMdoel.Name = "lblMdoel"
        Me.lblMdoel.Size = New System.Drawing.Size(81, 20)
        Me.lblMdoel.TabIndex = 38
        Me.lblMdoel.Text = "Model"
        '
        'cboVanType
        '
        Me.cboVanType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboVanType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVanType.Location = New System.Drawing.Point(120, 55)
        Me.cboVanType.Name = "cboVanType"
        Me.cboVanType.Size = New System.Drawing.Size(146, 21)
        Me.cboVanType.TabIndex = 2
        Me.cboVanType.Tag = ""
        '
        'txtMake
        '
        Me.txtMake.Enabled = False
        Me.txtMake.Location = New System.Drawing.Point(120, 90)
        Me.txtMake.MaxLength = 10
        Me.txtMake.Name = "txtMake"
        Me.txtMake.Size = New System.Drawing.Size(146, 21)
        Me.txtMake.TabIndex = 3
        '
        'txtRegistration
        '
        Me.txtRegistration.Location = New System.Drawing.Point(120, 20)
        Me.txtRegistration.MaxLength = 20
        Me.txtRegistration.Name = "txtRegistration"
        Me.txtRegistration.Size = New System.Drawing.Size(146, 21)
        Me.txtRegistration.TabIndex = 1
        '
        'lblRegistration
        '
        Me.lblRegistration.Location = New System.Drawing.Point(6, 23)
        Me.lblRegistration.Name = "lblRegistration"
        Me.lblRegistration.Size = New System.Drawing.Size(85, 20)
        Me.lblRegistration.TabIndex = 31
        Me.lblRegistration.Text = "Registration"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(120, 231)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(518, 37)
        Me.txtNotes.TabIndex = 8
        Me.txtNotes.Tag = "Van.Notes"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(6, 234)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(53, 20)
        Me.lblNotes.TabIndex = 31
        Me.lblNotes.Text = "Notes"
        '
        'lblInsuranceDue
        '
        Me.lblInsuranceDue.Location = New System.Drawing.Point(6, 58)
        Me.lblInsuranceDue.Name = "lblInsuranceDue"
        Me.lblInsuranceDue.Size = New System.Drawing.Size(96, 20)
        Me.lblInsuranceDue.TabIndex = 31
        Me.lblInsuranceDue.Text = "Van Type"
        '
        'lblMake
        '
        Me.lblMake.Location = New System.Drawing.Point(6, 93)
        Me.lblMake.Name = "lblMake"
        Me.lblMake.Size = New System.Drawing.Size(81, 20)
        Me.lblMake.TabIndex = 31
        Me.lblMake.Text = "Make"
        '
        'tcVans
        '
        Me.tcVans.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcVans.Controls.Add(Me.tabDetails)
        Me.tcVans.Controls.Add(Me.tabFaults)
        Me.tcVans.Controls.Add(Me.tabContract)
        Me.tcVans.Controls.Add(Me.tabEngineerHistory)
        Me.tcVans.Controls.Add(Me.tabServiceHistory)
        Me.tcVans.Controls.Add(Me.tabHistory)
        Me.tcVans.Controls.Add(Me.tabDocuments)
        Me.tcVans.Location = New System.Drawing.Point(4, 7)
        Me.tcVans.Name = "tcVans"
        Me.tcVans.SelectedIndex = 0
        Me.tcVans.Size = New System.Drawing.Size(683, 728)
        Me.tcVans.TabIndex = 0
        '
        'tabFaults
        '
        Me.tabFaults.BackColor = System.Drawing.SystemColors.Control
        Me.tabFaults.Controls.Add(Me.chkHideArchive)
        Me.tabFaults.Controls.Add(Me.grpFaultDetails)
        Me.tabFaults.Controls.Add(Me.grpVanFaultDg)
        Me.tabFaults.Location = New System.Drawing.Point(4, 22)
        Me.tabFaults.Name = "tabFaults"
        Me.tabFaults.Size = New System.Drawing.Size(675, 702)
        Me.tabFaults.TabIndex = 2
        Me.tabFaults.Text = "Faults"
        '
        'chkHideArchive
        '
        Me.chkHideArchive.AutoSize = True
        Me.chkHideArchive.Checked = True
        Me.chkHideArchive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHideArchive.Location = New System.Drawing.Point(573, 390)
        Me.chkHideArchive.Name = "chkHideArchive"
        Me.chkHideArchive.Size = New System.Drawing.Size(98, 17)
        Me.chkHideArchive.TabIndex = 78
        Me.chkHideArchive.Text = "Hide Archive"
        Me.chkHideArchive.UseVisualStyleBackColor = True
        '
        'grpFaultDetails
        '
        Me.grpFaultDetails.Controls.Add(Me.chkArchive)
        Me.grpFaultDetails.Controls.Add(Me.txtAdditionalNotes)
        Me.grpFaultDetails.Controls.Add(Me.lblAddNotes)
        Me.grpFaultDetails.Controls.Add(Me.txtOutcome)
        Me.grpFaultDetails.Controls.Add(Me.lblOutcome)
        Me.grpFaultDetails.Controls.Add(Me.txtStatus)
        Me.grpFaultDetails.Controls.Add(Me.lblVisitStatus)
        Me.grpFaultDetails.Controls.Add(Me.txtScheduled)
        Me.grpFaultDetails.Controls.Add(Me.lblScheduled)
        Me.grpFaultDetails.Controls.Add(Me.txtJobRef)
        Me.grpFaultDetails.Controls.Add(Me.lblJobRef)
        Me.grpFaultDetails.Controls.Add(Me.btnNewFault)
        Me.grpFaultDetails.Controls.Add(Me.btnSaveFault)
        Me.grpFaultDetails.Controls.Add(Me.chkResolved)
        Me.grpFaultDetails.Controls.Add(Me.dtpResolvedDate)
        Me.grpFaultDetails.Controls.Add(Me.lblResolvedDate)
        Me.grpFaultDetails.Controls.Add(Me.dtpFaultDate)
        Me.grpFaultDetails.Controls.Add(Me.lblFaultDate)
        Me.grpFaultDetails.Controls.Add(Me.txtFaultNotes)
        Me.grpFaultDetails.Controls.Add(Me.lblFaultNotes)
        Me.grpFaultDetails.Controls.Add(Me.cboFaultType)
        Me.grpFaultDetails.Controls.Add(Me.txtEngineerFaultNotes)
        Me.grpFaultDetails.Controls.Add(Me.lblEngineerNotes)
        Me.grpFaultDetails.Controls.Add(Me.lblFaultType)
        Me.grpFaultDetails.Location = New System.Drawing.Point(7, 7)
        Me.grpFaultDetails.Name = "grpFaultDetails"
        Me.grpFaultDetails.Size = New System.Drawing.Size(664, 375)
        Me.grpFaultDetails.TabIndex = 16
        Me.grpFaultDetails.TabStop = False
        Me.grpFaultDetails.Text = "Fault Details"
        '
        'chkArchive
        '
        Me.chkArchive.AutoSize = True
        Me.chkArchive.Location = New System.Drawing.Point(589, 137)
        Me.chkArchive.Name = "chkArchive"
        Me.chkArchive.Size = New System.Drawing.Size(69, 17)
        Me.chkArchive.TabIndex = 77
        Me.chkArchive.Text = "Archive"
        Me.chkArchive.UseVisualStyleBackColor = True
        '
        'txtAdditionalNotes
        '
        Me.txtAdditionalNotes.Location = New System.Drawing.Point(112, 267)
        Me.txtAdditionalNotes.Multiline = True
        Me.txtAdditionalNotes.Name = "txtAdditionalNotes"
        Me.txtAdditionalNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAdditionalNotes.Size = New System.Drawing.Size(546, 62)
        Me.txtAdditionalNotes.TabIndex = 75
        Me.txtAdditionalNotes.Tag = ""
        '
        'lblAddNotes
        '
        Me.lblAddNotes.Location = New System.Drawing.Point(9, 270)
        Me.lblAddNotes.Name = "lblAddNotes"
        Me.lblAddNotes.Size = New System.Drawing.Size(103, 20)
        Me.lblAddNotes.TabIndex = 76
        Me.lblAddNotes.Text = "Additional Notes"
        '
        'txtOutcome
        '
        Me.txtOutcome.Location = New System.Drawing.Point(401, 168)
        Me.txtOutcome.Name = "txtOutcome"
        Me.txtOutcome.ReadOnly = True
        Me.txtOutcome.Size = New System.Drawing.Size(146, 21)
        Me.txtOutcome.TabIndex = 74
        '
        'lblOutcome
        '
        Me.lblOutcome.Location = New System.Drawing.Point(298, 171)
        Me.lblOutcome.Name = "lblOutcome"
        Me.lblOutcome.Size = New System.Drawing.Size(95, 20)
        Me.lblOutcome.TabIndex = 73
        Me.lblOutcome.Text = "Outcome"
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(112, 168)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(146, 21)
        Me.txtStatus.TabIndex = 72
        '
        'lblVisitStatus
        '
        Me.lblVisitStatus.Location = New System.Drawing.Point(9, 171)
        Me.lblVisitStatus.Name = "lblVisitStatus"
        Me.lblVisitStatus.Size = New System.Drawing.Size(95, 20)
        Me.lblVisitStatus.TabIndex = 71
        Me.lblVisitStatus.Text = "Visit Status"
        '
        'txtScheduled
        '
        Me.txtScheduled.Location = New System.Drawing.Point(401, 135)
        Me.txtScheduled.Name = "txtScheduled"
        Me.txtScheduled.ReadOnly = True
        Me.txtScheduled.Size = New System.Drawing.Size(146, 21)
        Me.txtScheduled.TabIndex = 70
        '
        'lblScheduled
        '
        Me.lblScheduled.Location = New System.Drawing.Point(298, 138)
        Me.lblScheduled.Name = "lblScheduled"
        Me.lblScheduled.Size = New System.Drawing.Size(95, 20)
        Me.lblScheduled.TabIndex = 69
        Me.lblScheduled.Text = "Scheduled"
        '
        'txtJobRef
        '
        Me.txtJobRef.Location = New System.Drawing.Point(112, 135)
        Me.txtJobRef.Name = "txtJobRef"
        Me.txtJobRef.ReadOnly = True
        Me.txtJobRef.Size = New System.Drawing.Size(146, 21)
        Me.txtJobRef.TabIndex = 68
        '
        'lblJobRef
        '
        Me.lblJobRef.Location = New System.Drawing.Point(9, 138)
        Me.lblJobRef.Name = "lblJobRef"
        Me.lblJobRef.Size = New System.Drawing.Size(95, 20)
        Me.lblJobRef.TabIndex = 67
        Me.lblJobRef.Text = "Job Reference"
        '
        'btnNewFault
        '
        Me.btnNewFault.Location = New System.Drawing.Point(13, 338)
        Me.btnNewFault.Name = "btnNewFault"
        Me.btnNewFault.Size = New System.Drawing.Size(75, 23)
        Me.btnNewFault.TabIndex = 7
        Me.btnNewFault.Text = "New"
        Me.btnNewFault.UseVisualStyleBackColor = True
        '
        'chkResolved
        '
        Me.chkResolved.AutoSize = True
        Me.chkResolved.Location = New System.Drawing.Point(300, 99)
        Me.chkResolved.Name = "chkResolved"
        Me.chkResolved.Size = New System.Drawing.Size(78, 17)
        Me.chkResolved.TabIndex = 4
        Me.chkResolved.Text = "Resolved"
        Me.chkResolved.UseVisualStyleBackColor = True
        '
        'dtpResolvedDate
        '
        Me.dtpResolvedDate.Enabled = False
        Me.dtpResolvedDate.Location = New System.Drawing.Point(112, 96)
        Me.dtpResolvedDate.Name = "dtpResolvedDate"
        Me.dtpResolvedDate.Size = New System.Drawing.Size(146, 21)
        Me.dtpResolvedDate.TabIndex = 3
        Me.dtpResolvedDate.Tag = ""
        '
        'lblResolvedDate
        '
        Me.lblResolvedDate.Location = New System.Drawing.Point(9, 102)
        Me.lblResolvedDate.Name = "lblResolvedDate"
        Me.lblResolvedDate.Size = New System.Drawing.Size(95, 20)
        Me.lblResolvedDate.TabIndex = 66
        Me.lblResolvedDate.Text = "Resolved Date"
        '
        'dtpFaultDate
        '
        Me.dtpFaultDate.Location = New System.Drawing.Point(112, 60)
        Me.dtpFaultDate.Name = "dtpFaultDate"
        Me.dtpFaultDate.Size = New System.Drawing.Size(146, 21)
        Me.dtpFaultDate.TabIndex = 2
        Me.dtpFaultDate.Tag = ""
        '
        'lblFaultDate
        '
        Me.lblFaultDate.Location = New System.Drawing.Point(8, 66)
        Me.lblFaultDate.Name = "lblFaultDate"
        Me.lblFaultDate.Size = New System.Drawing.Size(85, 20)
        Me.lblFaultDate.TabIndex = 65
        Me.lblFaultDate.Text = "Fault Date"
        '
        'txtFaultNotes
        '
        Me.txtFaultNotes.Location = New System.Drawing.Point(112, 202)
        Me.txtFaultNotes.Multiline = True
        Me.txtFaultNotes.Name = "txtFaultNotes"
        Me.txtFaultNotes.ReadOnly = True
        Me.txtFaultNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtFaultNotes.Size = New System.Drawing.Size(546, 52)
        Me.txtFaultNotes.TabIndex = 6
        Me.txtFaultNotes.Tag = ""
        '
        'lblFaultNotes
        '
        Me.lblFaultNotes.Location = New System.Drawing.Point(10, 205)
        Me.lblFaultNotes.Name = "lblFaultNotes"
        Me.lblFaultNotes.Size = New System.Drawing.Size(96, 20)
        Me.lblFaultNotes.TabIndex = 45
        Me.lblFaultNotes.Text = "Notes"
        '
        'cboFaultType
        '
        Me.cboFaultType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFaultType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFaultType.Location = New System.Drawing.Point(112, 27)
        Me.cboFaultType.Name = "cboFaultType"
        Me.cboFaultType.Size = New System.Drawing.Size(146, 21)
        Me.cboFaultType.TabIndex = 1
        Me.cboFaultType.Tag = ""
        '
        'txtEngineerFaultNotes
        '
        Me.txtEngineerFaultNotes.Location = New System.Drawing.Point(401, 27)
        Me.txtEngineerFaultNotes.Multiline = True
        Me.txtEngineerFaultNotes.Name = "txtEngineerFaultNotes"
        Me.txtEngineerFaultNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEngineerFaultNotes.Size = New System.Drawing.Size(257, 95)
        Me.txtEngineerFaultNotes.TabIndex = 5
        Me.txtEngineerFaultNotes.Tag = ""
        '
        'lblEngineerNotes
        '
        Me.lblEngineerNotes.Location = New System.Drawing.Point(297, 30)
        Me.lblEngineerNotes.Name = "lblEngineerNotes"
        Me.lblEngineerNotes.Size = New System.Drawing.Size(98, 20)
        Me.lblEngineerNotes.TabIndex = 31
        Me.lblEngineerNotes.Text = "Engineer Notes"
        '
        'lblFaultType
        '
        Me.lblFaultType.Location = New System.Drawing.Point(8, 30)
        Me.lblFaultType.Name = "lblFaultType"
        Me.lblFaultType.Size = New System.Drawing.Size(96, 20)
        Me.lblFaultType.TabIndex = 31
        Me.lblFaultType.Text = "Fault Type"
        '
        'grpVanFaultDg
        '
        Me.grpVanFaultDg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpVanFaultDg.Controls.Add(Me.dgVanFaults)
        Me.grpVanFaultDg.Location = New System.Drawing.Point(11, 413)
        Me.grpVanFaultDg.Name = "grpVanFaultDg"
        Me.grpVanFaultDg.Size = New System.Drawing.Size(664, 287)
        Me.grpVanFaultDg.TabIndex = 5
        Me.grpVanFaultDg.TabStop = False
        Me.grpVanFaultDg.Text = "Van Fault History (Double click to view)"
        '
        'dgVanFaults
        '
        Me.dgVanFaults.DataMember = ""
        Me.dgVanFaults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgVanFaults.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgVanFaults.Location = New System.Drawing.Point(3, 17)
        Me.dgVanFaults.Name = "dgVanFaults"
        Me.dgVanFaults.Size = New System.Drawing.Size(658, 267)
        Me.dgVanFaults.TabIndex = 15
        '
        'tabContract
        '
        Me.tabContract.BackColor = System.Drawing.SystemColors.Control
        Me.tabContract.Controls.Add(Me.grpFinances)
        Me.tabContract.Controls.Add(Me.grpContractDetails)
        Me.tabContract.Location = New System.Drawing.Point(4, 22)
        Me.tabContract.Name = "tabContract"
        Me.tabContract.Size = New System.Drawing.Size(675, 702)
        Me.tabContract.TabIndex = 3
        Me.tabContract.Text = "Contract"
        '
        'grpFinances
        '
        Me.grpFinances.Controls.Add(Me.txtForecastExcessCost)
        Me.grpFinances.Controls.Add(Me.lblForcastedExcessCost)
        Me.grpFinances.Controls.Add(Me.txtExcessMileageCost)
        Me.grpFinances.Controls.Add(Me.lblExcessCost)
        Me.grpFinances.Controls.Add(Me.txtAnnualRental)
        Me.grpFinances.Controls.Add(Me.txtMonthlyRental)
        Me.grpFinances.Controls.Add(Me.lblMonthlyRental)
        Me.grpFinances.Controls.Add(Me.lblAnnualRental)
        Me.grpFinances.Controls.Add(Me.txtWeeklyRental)
        Me.grpFinances.Controls.Add(Me.txtExcessMileageRate)
        Me.grpFinances.Controls.Add(Me.lblExcessMileageRate)
        Me.grpFinances.Controls.Add(Me.lblWeeklyRental)
        Me.grpFinances.Location = New System.Drawing.Point(8, 294)
        Me.grpFinances.Name = "grpFinances"
        Me.grpFinances.Size = New System.Drawing.Size(664, 138)
        Me.grpFinances.TabIndex = 75
        Me.grpFinances.TabStop = False
        Me.grpFinances.Text = "Finances"
        '
        'txtForecastExcessCost
        '
        Me.txtForecastExcessCost.Enabled = False
        Me.txtForecastExcessCost.Location = New System.Drawing.Point(498, 99)
        Me.txtForecastExcessCost.MaxLength = 10
        Me.txtForecastExcessCost.Name = "txtForecastExcessCost"
        Me.txtForecastExcessCost.Size = New System.Drawing.Size(146, 21)
        Me.txtForecastExcessCost.TabIndex = 75
        '
        'lblForcastedExcessCost
        '
        Me.lblForcastedExcessCost.Location = New System.Drawing.Point(347, 102)
        Me.lblForcastedExcessCost.Name = "lblForcastedExcessCost"
        Me.lblForcastedExcessCost.Size = New System.Drawing.Size(145, 20)
        Me.lblForcastedExcessCost.TabIndex = 76
        Me.lblForcastedExcessCost.Text = "Forecast Excess Cost"
        '
        'txtExcessMileageCost
        '
        Me.txtExcessMileageCost.Enabled = False
        Me.txtExcessMileageCost.Location = New System.Drawing.Point(159, 99)
        Me.txtExcessMileageCost.MaxLength = 10
        Me.txtExcessMileageCost.Name = "txtExcessMileageCost"
        Me.txtExcessMileageCost.Size = New System.Drawing.Size(146, 21)
        Me.txtExcessMileageCost.TabIndex = 73
        '
        'lblExcessCost
        '
        Me.lblExcessCost.Location = New System.Drawing.Point(8, 102)
        Me.lblExcessCost.Name = "lblExcessCost"
        Me.lblExcessCost.Size = New System.Drawing.Size(126, 20)
        Me.lblExcessCost.TabIndex = 74
        Me.lblExcessCost.Text = "Excess Mileage Cost"
        '
        'txtAnnualRental
        '
        Me.txtAnnualRental.Location = New System.Drawing.Point(498, 60)
        Me.txtAnnualRental.MaxLength = 10
        Me.txtAnnualRental.Name = "txtAnnualRental"
        Me.txtAnnualRental.Size = New System.Drawing.Size(146, 21)
        Me.txtAnnualRental.TabIndex = 12
        '
        'txtMonthlyRental
        '
        Me.txtMonthlyRental.Location = New System.Drawing.Point(159, 60)
        Me.txtMonthlyRental.MaxLength = 10
        Me.txtMonthlyRental.Name = "txtMonthlyRental"
        Me.txtMonthlyRental.Size = New System.Drawing.Size(146, 21)
        Me.txtMonthlyRental.TabIndex = 11
        '
        'lblMonthlyRental
        '
        Me.lblMonthlyRental.Location = New System.Drawing.Point(8, 63)
        Me.lblMonthlyRental.Name = "lblMonthlyRental"
        Me.lblMonthlyRental.Size = New System.Drawing.Size(126, 20)
        Me.lblMonthlyRental.TabIndex = 72
        Me.lblMonthlyRental.Text = "Monthly Rental"
        '
        'lblAnnualRental
        '
        Me.lblAnnualRental.Location = New System.Drawing.Point(347, 63)
        Me.lblAnnualRental.Name = "lblAnnualRental"
        Me.lblAnnualRental.Size = New System.Drawing.Size(126, 20)
        Me.lblAnnualRental.TabIndex = 69
        Me.lblAnnualRental.Text = "Annual Rental"
        '
        'txtWeeklyRental
        '
        Me.txtWeeklyRental.Location = New System.Drawing.Point(498, 20)
        Me.txtWeeklyRental.MaxLength = 10
        Me.txtWeeklyRental.Name = "txtWeeklyRental"
        Me.txtWeeklyRental.Size = New System.Drawing.Size(146, 21)
        Me.txtWeeklyRental.TabIndex = 10
        '
        'txtExcessMileageRate
        '
        Me.txtExcessMileageRate.Location = New System.Drawing.Point(159, 20)
        Me.txtExcessMileageRate.MaxLength = 20
        Me.txtExcessMileageRate.Name = "txtExcessMileageRate"
        Me.txtExcessMileageRate.Size = New System.Drawing.Size(146, 21)
        Me.txtExcessMileageRate.TabIndex = 9
        '
        'lblExcessMileageRate
        '
        Me.lblExcessMileageRate.Location = New System.Drawing.Point(8, 24)
        Me.lblExcessMileageRate.Name = "lblExcessMileageRate"
        Me.lblExcessMileageRate.Size = New System.Drawing.Size(126, 20)
        Me.lblExcessMileageRate.TabIndex = 31
        Me.lblExcessMileageRate.Text = "Excess Mileage Rate"
        '
        'lblWeeklyRental
        '
        Me.lblWeeklyRental.Location = New System.Drawing.Point(347, 23)
        Me.lblWeeklyRental.Name = "lblWeeklyRental"
        Me.lblWeeklyRental.Size = New System.Drawing.Size(100, 20)
        Me.lblWeeklyRental.TabIndex = 31
        Me.lblWeeklyRental.Text = "Weekly Rental"
        '
        'grpContractDetails
        '
        Me.grpContractDetails.Controls.Add(Me.btnRemoveContractEndDate)
        Me.grpContractDetails.Controls.Add(Me.txtStartingMileage)
        Me.grpContractDetails.Controls.Add(Me.lblStartingMileage)
        Me.grpContractDetails.Controls.Add(Me.btnEndContract)
        Me.grpContractDetails.Controls.Add(Me.txtContractNotes)
        Me.grpContractDetails.Controls.Add(Me.lblContractNotes)
        Me.grpContractDetails.Controls.Add(Me.txtAgreementRef)
        Me.grpContractDetails.Controls.Add(Me.lblAgreementRef)
        Me.grpContractDetails.Controls.Add(Me.txtContractMileage)
        Me.grpContractDetails.Controls.Add(Me.lblContractMileage)
        Me.grpContractDetails.Controls.Add(Me.dtpContractEnd)
        Me.grpContractDetails.Controls.Add(Me.lblContractEnd)
        Me.grpContractDetails.Controls.Add(Me.dtpContractStart)
        Me.grpContractDetails.Controls.Add(Me.lblContractStart)
        Me.grpContractDetails.Controls.Add(Me.cboProcurementMethod)
        Me.grpContractDetails.Controls.Add(Me.txtContractLength)
        Me.grpContractDetails.Controls.Add(Me.txtLessor)
        Me.grpContractDetails.Controls.Add(Me.lblLessor)
        Me.grpContractDetails.Controls.Add(Me.lblProcurementMethod)
        Me.grpContractDetails.Controls.Add(Me.lblContractLength)
        Me.grpContractDetails.Location = New System.Drawing.Point(8, 3)
        Me.grpContractDetails.Name = "grpContractDetails"
        Me.grpContractDetails.Size = New System.Drawing.Size(664, 285)
        Me.grpContractDetails.TabIndex = 3
        Me.grpContractDetails.TabStop = False
        Me.grpContractDetails.Text = "Details"
        '
        'btnRemoveContractEndDate
        '
        Me.btnRemoveContractEndDate.Location = New System.Drawing.Point(433, 100)
        Me.btnRemoveContractEndDate.Name = "btnRemoveContractEndDate"
        Me.btnRemoveContractEndDate.Size = New System.Drawing.Size(24, 23)
        Me.btnRemoveContractEndDate.TabIndex = 80
        Me.btnRemoveContractEndDate.Text = "X"
        Me.btnRemoveContractEndDate.UseVisualStyleBackColor = True
        Me.btnRemoveContractEndDate.Visible = False
        '
        'txtStartingMileage
        '
        Me.txtStartingMileage.Location = New System.Drawing.Point(498, 142)
        Me.txtStartingMileage.MaxLength = 10
        Me.txtStartingMileage.Name = "txtStartingMileage"
        Me.txtStartingMileage.Size = New System.Drawing.Size(146, 21)
        Me.txtStartingMileage.TabIndex = 78
        '
        'lblStartingMileage
        '
        Me.lblStartingMileage.Location = New System.Drawing.Point(347, 145)
        Me.lblStartingMileage.Name = "lblStartingMileage"
        Me.lblStartingMileage.Size = New System.Drawing.Size(126, 20)
        Me.lblStartingMileage.TabIndex = 79
        Me.lblStartingMileage.Text = "Starting Mileage"
        '
        'btnEndContract
        '
        Me.btnEndContract.Location = New System.Drawing.Point(498, 99)
        Me.btnEndContract.Name = "btnEndContract"
        Me.btnEndContract.Size = New System.Drawing.Size(146, 23)
        Me.btnEndContract.TabIndex = 77
        Me.btnEndContract.Text = "End Contract"
        Me.btnEndContract.UseVisualStyleBackColor = True
        Me.btnEndContract.Visible = False
        '
        'txtContractNotes
        '
        Me.txtContractNotes.Location = New System.Drawing.Point(159, 185)
        Me.txtContractNotes.Multiline = True
        Me.txtContractNotes.Name = "txtContractNotes"
        Me.txtContractNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtContractNotes.Size = New System.Drawing.Size(485, 75)
        Me.txtContractNotes.TabIndex = 8
        Me.txtContractNotes.Tag = "Van.Notes"
        '
        'lblContractNotes
        '
        Me.lblContractNotes.Location = New System.Drawing.Point(6, 188)
        Me.lblContractNotes.Name = "lblContractNotes"
        Me.lblContractNotes.Size = New System.Drawing.Size(53, 20)
        Me.lblContractNotes.TabIndex = 76
        Me.lblContractNotes.Text = "Notes"
        '
        'txtAgreementRef
        '
        Me.txtAgreementRef.Location = New System.Drawing.Point(159, 142)
        Me.txtAgreementRef.MaxLength = 10
        Me.txtAgreementRef.Name = "txtAgreementRef"
        Me.txtAgreementRef.Size = New System.Drawing.Size(146, 21)
        Me.txtAgreementRef.TabIndex = 7
        '
        'lblAgreementRef
        '
        Me.lblAgreementRef.Location = New System.Drawing.Point(8, 145)
        Me.lblAgreementRef.Name = "lblAgreementRef"
        Me.lblAgreementRef.Size = New System.Drawing.Size(100, 20)
        Me.lblAgreementRef.TabIndex = 74
        Me.lblAgreementRef.Text = "Agreement Ref"
        '
        'txtContractMileage
        '
        Me.txtContractMileage.Location = New System.Drawing.Point(498, 62)
        Me.txtContractMileage.MaxLength = 10
        Me.txtContractMileage.Name = "txtContractMileage"
        Me.txtContractMileage.Size = New System.Drawing.Size(146, 21)
        Me.txtContractMileage.TabIndex = 4
        '
        'lblContractMileage
        '
        Me.lblContractMileage.Location = New System.Drawing.Point(347, 65)
        Me.lblContractMileage.Name = "lblContractMileage"
        Me.lblContractMileage.Size = New System.Drawing.Size(126, 20)
        Me.lblContractMileage.TabIndex = 72
        Me.lblContractMileage.Text = "Contract Mileage"
        '
        'dtpContractEnd
        '
        Me.dtpContractEnd.Enabled = False
        Me.dtpContractEnd.Location = New System.Drawing.Point(498, 99)
        Me.dtpContractEnd.Name = "dtpContractEnd"
        Me.dtpContractEnd.Size = New System.Drawing.Size(146, 21)
        Me.dtpContractEnd.TabIndex = 6
        Me.dtpContractEnd.Tag = ""
        Me.dtpContractEnd.Visible = False
        '
        'lblContractEnd
        '
        Me.lblContractEnd.Location = New System.Drawing.Point(347, 105)
        Me.lblContractEnd.Name = "lblContractEnd"
        Me.lblContractEnd.Size = New System.Drawing.Size(95, 20)
        Me.lblContractEnd.TabIndex = 70
        Me.lblContractEnd.Text = "Contract End"
        Me.lblContractEnd.UseCompatibleTextRendering = True
        '
        'dtpContractStart
        '
        Me.dtpContractStart.Location = New System.Drawing.Point(159, 99)
        Me.dtpContractStart.Name = "dtpContractStart"
        Me.dtpContractStart.Size = New System.Drawing.Size(146, 21)
        Me.dtpContractStart.TabIndex = 5
        Me.dtpContractStart.Tag = ""
        '
        'lblContractStart
        '
        Me.lblContractStart.Location = New System.Drawing.Point(8, 105)
        Me.lblContractStart.Name = "lblContractStart"
        Me.lblContractStart.Size = New System.Drawing.Size(126, 20)
        Me.lblContractStart.TabIndex = 69
        Me.lblContractStart.Text = "Contract Start"
        '
        'cboProcurementMethod
        '
        Me.cboProcurementMethod.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboProcurementMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProcurementMethod.Location = New System.Drawing.Point(498, 20)
        Me.cboProcurementMethod.Name = "cboProcurementMethod"
        Me.cboProcurementMethod.Size = New System.Drawing.Size(146, 21)
        Me.cboProcurementMethod.TabIndex = 2
        Me.cboProcurementMethod.Tag = ""
        '
        'txtContractLength
        '
        Me.txtContractLength.Location = New System.Drawing.Point(159, 59)
        Me.txtContractLength.MaxLength = 10
        Me.txtContractLength.Name = "txtContractLength"
        Me.txtContractLength.Size = New System.Drawing.Size(146, 21)
        Me.txtContractLength.TabIndex = 3
        '
        'txtLessor
        '
        Me.txtLessor.Location = New System.Drawing.Point(159, 20)
        Me.txtLessor.MaxLength = 20
        Me.txtLessor.Name = "txtLessor"
        Me.txtLessor.Size = New System.Drawing.Size(146, 21)
        Me.txtLessor.TabIndex = 1
        '
        'lblLessor
        '
        Me.lblLessor.Location = New System.Drawing.Point(8, 24)
        Me.lblLessor.Name = "lblLessor"
        Me.lblLessor.Size = New System.Drawing.Size(85, 20)
        Me.lblLessor.TabIndex = 31
        Me.lblLessor.Text = "Lessor"
        '
        'lblProcurementMethod
        '
        Me.lblProcurementMethod.Location = New System.Drawing.Point(347, 23)
        Me.lblProcurementMethod.Name = "lblProcurementMethod"
        Me.lblProcurementMethod.Size = New System.Drawing.Size(126, 20)
        Me.lblProcurementMethod.TabIndex = 31
        Me.lblProcurementMethod.Text = "Procurement Method"
        '
        'lblContractLength
        '
        Me.lblContractLength.Location = New System.Drawing.Point(8, 62)
        Me.lblContractLength.Name = "lblContractLength"
        Me.lblContractLength.Size = New System.Drawing.Size(100, 20)
        Me.lblContractLength.TabIndex = 31
        Me.lblContractLength.Text = "Contract Length"
        '
        'tabEngineerHistory
        '
        Me.tabEngineerHistory.Controls.Add(Me.grpEngineerHistory)
        Me.tabEngineerHistory.Location = New System.Drawing.Point(4, 22)
        Me.tabEngineerHistory.Name = "tabEngineerHistory"
        Me.tabEngineerHistory.Size = New System.Drawing.Size(675, 702)
        Me.tabEngineerHistory.TabIndex = 4
        Me.tabEngineerHistory.Text = "Engineer History"
        Me.tabEngineerHistory.UseVisualStyleBackColor = True
        '
        'grpEngineerHistory
        '
        Me.grpEngineerHistory.Controls.Add(Me.dgEngineerHistory)
        Me.grpEngineerHistory.Location = New System.Drawing.Point(5, 6)
        Me.grpEngineerHistory.Name = "grpEngineerHistory"
        Me.grpEngineerHistory.Size = New System.Drawing.Size(664, 801)
        Me.grpEngineerHistory.TabIndex = 5
        Me.grpEngineerHistory.TabStop = False
        Me.grpEngineerHistory.Text = "Engineer History"
        '
        'dgEngineerHistory
        '
        Me.dgEngineerHistory.DataMember = ""
        Me.dgEngineerHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgEngineerHistory.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgEngineerHistory.Location = New System.Drawing.Point(3, 17)
        Me.dgEngineerHistory.Name = "dgEngineerHistory"
        Me.dgEngineerHistory.Size = New System.Drawing.Size(658, 781)
        Me.dgEngineerHistory.TabIndex = 15
        '
        'tabServiceHistory
        '
        Me.tabServiceHistory.Controls.Add(Me.gpServiceHistory)
        Me.tabServiceHistory.Location = New System.Drawing.Point(4, 22)
        Me.tabServiceHistory.Name = "tabServiceHistory"
        Me.tabServiceHistory.Size = New System.Drawing.Size(675, 702)
        Me.tabServiceHistory.TabIndex = 5
        Me.tabServiceHistory.Text = "Service History"
        Me.tabServiceHistory.UseVisualStyleBackColor = True
        '
        'gpServiceHistory
        '
        Me.gpServiceHistory.Controls.Add(Me.dgServiceHistory)
        Me.gpServiceHistory.Location = New System.Drawing.Point(5, 6)
        Me.gpServiceHistory.Name = "gpServiceHistory"
        Me.gpServiceHistory.Size = New System.Drawing.Size(664, 801)
        Me.gpServiceHistory.TabIndex = 6
        Me.gpServiceHistory.TabStop = False
        Me.gpServiceHistory.Text = "Service History"
        '
        'dgServiceHistory
        '
        Me.dgServiceHistory.DataMember = ""
        Me.dgServiceHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgServiceHistory.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgServiceHistory.Location = New System.Drawing.Point(3, 17)
        Me.dgServiceHistory.Name = "dgServiceHistory"
        Me.dgServiceHistory.Size = New System.Drawing.Size(658, 781)
        Me.dgServiceHistory.TabIndex = 15
        '
        'tabDocuments
        '
        Me.tabDocuments.Location = New System.Drawing.Point(4, 22)
        Me.tabDocuments.Name = "tabDocuments"
        Me.tabDocuments.Size = New System.Drawing.Size(675, 702)
        Me.tabDocuments.TabIndex = 6
        Me.tabDocuments.Text = "Documents"
        Me.tabDocuments.UseVisualStyleBackColor = True
        '
        'btnSaveFault
        '
        Me.btnSaveFault.Location = New System.Drawing.Point(583, 338)
        Me.btnSaveFault.Name = "btnSaveFault"
        Me.btnSaveFault.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveFault.TabIndex = 8
        Me.btnSaveFault.Text = "Save"
        Me.btnSaveFault.UseVisualStyleBackColor = True
        '
        'UCFleetVan
        '
        Me.Controls.Add(Me.tcVans)
        Me.Name = "UCFleetVan"
        Me.Size = New System.Drawing.Size(693, 748)
        Me.tabHistory.ResumeLayout(False)
        Me.grpHistoryDetails.ResumeLayout(False)
        Me.grpHistoryDetails.PerformLayout()
        Me.grpVanAudit.ResumeLayout(False)
        CType(Me.dgVanAudits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDetails.ResumeLayout(False)
        Me.grpMaintenance.ResumeLayout(False)
        Me.grpMaintenance.PerformLayout()
        Me.grpEngineer.ResumeLayout(False)
        Me.grpEngineer.PerformLayout()
        Me.grpVan.ResumeLayout(False)
        Me.grpVan.PerformLayout()
        CType(Me.dgEquipment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcVans.ResumeLayout(False)
        Me.tabFaults.ResumeLayout(False)
        Me.tabFaults.PerformLayout()
        Me.grpFaultDetails.ResumeLayout(False)
        Me.grpFaultDetails.PerformLayout()
        Me.grpVanFaultDg.ResumeLayout(False)
        CType(Me.dgVanFaults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabContract.ResumeLayout(False)
        Me.grpFinances.ResumeLayout(False)
        Me.grpFinances.PerformLayout()
        Me.grpContractDetails.ResumeLayout(False)
        Me.grpContractDetails.PerformLayout()
        Me.tabEngineerHistory.ResumeLayout(False)
        Me.grpEngineerHistory.ResumeLayout(False)
        CType(Me.dgEngineerHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabServiceHistory.ResumeLayout(False)
        Me.gpServiceHistory.ResumeLayout(False)
        CType(Me.dgServiceHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)

        SetupDGEquipment()
        SetupDGFault()
        SetupDGEngineerHistory()
        SetupDGServiceHistory()
        SetupDGAudit()
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentVan
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private DocumentsControl As UCDocumentsList

    Private _currentVan As Entity.FleetVans.FleetVan

    Public Property CurrentVan() As Entity.FleetVans.FleetVan
        Get
            Return _currentVan
        End Get
        Set(ByVal Value As Entity.FleetVans.FleetVan)
            _currentVan = Value

            If _currentVan Is Nothing Then
                _currentVan = New Entity.FleetVans.FleetVan
            End If

            If _currentVan.Exists Then
                PopulateVanEquipmentDatagrid()
                PopulateEngineerHistoryDatagrid()
                PopulateVanFaultDatagrid()
                PopulateServiceDatagrid()
                PopulateVanAuditDatagrid()
                DocumentsControl = New UCDocumentsList(Entity.Sys.Enums.TableNames.tblFleetVan,
                                                       _currentVan.VanID)
            Else
                tcVans.TabPages.Remove(tabFaults)
                tcVans.TabPages.Remove(tabEngineerHistory)
                tcVans.TabPages.Remove(tabServiceHistory)
                tcVans.TabPages.Remove(tabHistory)
                DocumentsControl = New UCDocumentsList(Entity.Sys.Enums.TableNames.tblFleetVan,
                                                       DB.FleetVan.Get_NextVanID())
            End If

            Me.tabDocuments.Controls.Add(DocumentsControl)
        End Set
    End Property

    Private _currentVanEngineer As Entity.FleetVans.FleetVanEngineer

    Public Property CurrentVanEngineer() As Entity.FleetVans.FleetVanEngineer
        Get
            Return _currentVanEngineer
        End Get
        Set(ByVal Value As Entity.FleetVans.FleetVanEngineer)
            _currentVanEngineer = Value

            If _currentVanEngineer Is Nothing Then
                _currentVanEngineer = New Entity.FleetVans.FleetVanEngineer
                _currentVanEngineer.Exists = False
            End If
        End Set
    End Property

    Private _currentVanMaintenance As Entity.FleetVans.FleetVanMaintenance

    Public Property CurrentVanMaintenance() As Entity.FleetVans.FleetVanMaintenance
        Get
            Return _currentVanMaintenance
        End Get
        Set(ByVal Value As Entity.FleetVans.FleetVanMaintenance)
            _currentVanMaintenance = Value

            If _currentVanMaintenance Is Nothing Then
                _currentVanMaintenance = New Entity.FleetVans.FleetVanMaintenance
                _currentVanMaintenance.Exists = False
            End If
        End Set
    End Property

    Private _currentVanFault As Entity.FleetVans.FleetVanFault

    Public Property CurrentVanFault() As Entity.FleetVans.FleetVanFault
        Get
            Return _currentVanFault
        End Get
        Set(ByVal Value As Entity.FleetVans.FleetVanFault)
            _currentVanFault = Value

            If _currentVanFault Is Nothing Then
                _currentVanFault = New Entity.FleetVans.FleetVanFault
                _currentVanFault.Exists = False
            End If
        End Set
    End Property

    Private _currentContract As Entity.FleetVans.FleetVanContract

    Public Property CurrentContract() As Entity.FleetVans.FleetVanContract
        Get
            Return _currentContract
        End Get
        Set(ByVal Value As Entity.FleetVans.FleetVanContract)
            _currentContract = Value

            If _currentContract Is Nothing Then
                _currentContract = New Entity.FleetVans.FleetVanContract
                _currentContract.Exists = False
            End If
        End Set
    End Property

    Private _engineer As Entity.Engineers.Engineer

    Public Property Engineer() As Entity.Engineers.Engineer
        Get
            Return _engineer
        End Get
        Set(ByVal Value As Entity.Engineers.Engineer)
            _engineer = Value
            If Not _engineer Is Nothing Then
                Me.txtEngineer.Text = Engineer.Name
            Else
                Me.txtEngineer.Text = "<Not Set>"
            End If
        End Set
    End Property

    Private _dvVanEquipment As DataView

    Private Property VanEquipmentDataview() As DataView
        Get
            Return _dvVanEquipment
        End Get
        Set(ByVal value As DataView)
            _dvVanEquipment = value
            _dvVanEquipment.AllowNew = False
            _dvVanEquipment.AllowEdit = False
            _dvVanEquipment.AllowDelete = False
            _dvVanEquipment.Table.TableName = Entity.Sys.Enums.TableNames.tblFleetVanEquipment.ToString
            Me.dgEquipment.DataSource = VanEquipmentDataview
        End Set
    End Property

    Private ReadOnly Property SelectedEquipmentDataRow() As DataRow
        Get
            If Not Me.dgEquipment.CurrentRowIndex = -1 Then
                Return VanEquipmentDataview(Me.dgEquipment.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _dvVanFaults As DataView

    Private Property VanFaultDataview() As DataView
        Get
            Return _dvVanFaults
        End Get
        Set(ByVal value As DataView)
            _dvVanFaults = value
            _dvVanFaults.AllowNew = False
            _dvVanFaults.AllowEdit = False
            _dvVanFaults.AllowDelete = False
            _dvVanFaults.Table.TableName = Entity.Sys.Enums.TableNames.tblFleetVanFault.ToString
            Me.dgVanFaults.DataSource = VanFaultDataview
        End Set
    End Property

    Private ReadOnly Property SelectedFaultDataRow() As DataRow
        Get
            If Not Me.dgVanFaults.CurrentRowIndex = -1 Then
                Return VanFaultDataview(Me.dgVanFaults.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _dvEngineerHistory As DataView

    Private Property EngineerHistoryDataview() As DataView
        Get
            Return _dvEngineerHistory
        End Get
        Set(ByVal value As DataView)
            _dvEngineerHistory = value
            _dvEngineerHistory.AllowNew = False
            _dvEngineerHistory.AllowEdit = False
            _dvEngineerHistory.AllowDelete = False
            _dvEngineerHistory.Table.TableName = Entity.Sys.Enums.TableNames.tblFleetVanEngineer.ToString
            Me.dgEngineerHistory.DataSource = EngineerHistoryDataview
        End Set
    End Property

    Private _jobsTable As DataView = Nothing

    Public Property ServiceDataView() As DataView
        Get
            Return _jobsTable
        End Get
        Set(ByVal Value As DataView)
            _jobsTable = Value
            _jobsTable.Table.TableName = Entity.Sys.Enums.TableNames.tblJob.ToString
            _jobsTable.AllowNew = False
            _jobsTable.AllowEdit = False
            _jobsTable.AllowDelete = False
            Me.dgServiceHistory.DataSource = ServiceDataView
        End Set
    End Property

    Private ReadOnly Property SelectedServiceDataRow() As DataRow
        Get
            If Not Me.dgServiceHistory.CurrentRowIndex = -1 Then
                Return ServiceDataView(Me.dgServiceHistory.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _dvVanAudits As DataView

    Private Property VanAuditsDataview() As DataView
        Get
            Return _dvVanAudits
        End Get
        Set(ByVal value As DataView)
            _dvVanAudits = value
            _dvVanAudits.AllowNew = False
            _dvVanAudits.AllowEdit = False
            _dvVanAudits.AllowDelete = False
            _dvVanAudits.Table.TableName = Entity.Sys.Enums.TableNames.tblFleetVanAudit.ToString
            Me.dgVanAudits.DataSource = VanAuditsDataview
        End Set
    End Property

    Private ReadOnly Property SelectedVanHistoryDataRow() As DataRow
        Get
            If Not Me.dgVanAudits.CurrentRowIndex = -1 Then
                Return VanAuditsDataview(Me.dgVanAudits.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _equipmentList As New List(Of Integer)

    Private Property EquipmentList() As List(Of Integer)
        Get
            Return _equipmentList
        End Get
        Set(ByVal value As List(Of Integer))
            _equipmentList = value
        End Set
    End Property

#End Region

#Region "Setup"

    Public Sub SetupDGEquipment()
        Dim tStyle As DataGridTableStyle = Me.dgEquipment.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim equipmentName As New DataGridLabelColumn
        equipmentName.Format = ""
        equipmentName.FormatInfo = Nothing
        equipmentName.HeaderText = "Equipment"
        equipmentName.MappingName = "Name"
        equipmentName.ReadOnly = True
        equipmentName.Width = 130
        equipmentName.NullText = ""
        tStyle.GridColumnStyles.Add(equipmentName)

        Dim addedOn As New DataGridLabelColumn
        addedOn.Format = ""
        addedOn.FormatInfo = Nothing
        addedOn.HeaderText = "Added On"
        addedOn.MappingName = "AddedOn"
        addedOn.ReadOnly = True
        addedOn.Width = 137
        addedOn.NullText = ""
        tStyle.GridColumnStyles.Add(addedOn)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblFleetVanEquipment.ToString
        Me.dgEquipment.TableStyles.Add(tStyle)

    End Sub

    Public Sub SetupDGFault()
        Dim tStyle As DataGridTableStyle = Me.dgVanFaults.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim faultType As New DataGridLabelColumn
        faultType.Format = ""
        faultType.FormatInfo = Nothing
        faultType.HeaderText = "Fault"
        faultType.MappingName = "Name"
        faultType.ReadOnly = True
        faultType.Width = 120
        faultType.NullText = ""
        tStyle.GridColumnStyles.Add(faultType)

        Dim faultDate As New DataGridLabelColumn
        faultDate.Format = "dd/MM/yyyy"
        faultDate.FormatInfo = Nothing
        faultDate.HeaderText = "Fault Date"
        faultDate.MappingName = "FaultDate"
        faultDate.ReadOnly = True
        faultDate.Width = 100
        faultDate.NullText = ""
        tStyle.GridColumnStyles.Add(faultDate)

        Dim resolvedDate As New DataGridLabelColumn
        resolvedDate.Format = "dd/MM/yyyy"
        resolvedDate.FormatInfo = Nothing
        resolvedDate.HeaderText = "Resolved Date"
        resolvedDate.MappingName = "ResolvedDate"
        resolvedDate.ReadOnly = True
        resolvedDate.Width = 100
        resolvedDate.NullText = ""
        tStyle.GridColumnStyles.Add(resolvedDate)

        Dim engineerNotes As New DataGridLabelColumn
        engineerNotes.Format = ""
        engineerNotes.FormatInfo = Nothing
        engineerNotes.HeaderText = "Engineer Notes"
        engineerNotes.MappingName = "EngineerNotes"
        engineerNotes.ReadOnly = True
        engineerNotes.Width = 180
        engineerNotes.NullText = ""
        tStyle.GridColumnStyles.Add(engineerNotes)

        Dim lastChanged As New DataGridLabelColumn
        lastChanged.Format = "dd/MM/yyyy"
        lastChanged.FormatInfo = Nothing
        lastChanged.HeaderText = "Last Changed"
        lastChanged.MappingName = "LastChanged"
        lastChanged.ReadOnly = True
        lastChanged.Width = 100
        lastChanged.NullText = ""
        tStyle.GridColumnStyles.Add(lastChanged)

        Dim changedBy As New DataGridLabelColumn
        changedBy.Format = ""
        changedBy.FormatInfo = Nothing
        changedBy.HeaderText = "Changed By"
        changedBy.MappingName = "Fullname"
        changedBy.ReadOnly = True
        changedBy.Width = 100
        changedBy.NullText = ""
        tStyle.GridColumnStyles.Add(changedBy)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblFleetVanFault.ToString
        Me.dgVanFaults.TableStyles.Add(tStyle)

    End Sub

    Public Sub SetupDGEngineerHistory()
        Dim tStyle As DataGridTableStyle = Me.dgEngineerHistory.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim name As New DataGridLabelColumn
        name.Format = ""
        name.FormatInfo = Nothing
        name.HeaderText = "Name"
        name.MappingName = "Name"
        name.ReadOnly = True
        name.Width = 130
        name.NullText = ""
        tStyle.GridColumnStyles.Add(name)

        Dim startDate As New DataGridLabelColumn
        startDate.Format = "dd/MM/yyyy"
        startDate.FormatInfo = Nothing
        startDate.HeaderText = "From"
        startDate.MappingName = "StartDateTime"
        startDate.ReadOnly = True
        startDate.Width = 150
        startDate.NullText = ""
        tStyle.GridColumnStyles.Add(startDate)

        Dim endDate As New DataGridLabelColumn
        endDate.Format = "dd/MM/yyyy"
        endDate.FormatInfo = Nothing
        endDate.HeaderText = "To"
        endDate.MappingName = "EndDateTime"
        endDate.ReadOnly = True
        endDate.Width = 150
        endDate.NullText = ""
        tStyle.GridColumnStyles.Add(endDate)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblFleetVanEngineer.ToString
        Me.dgEngineerHistory.TableStyles.Add(tStyle)

    End Sub

    Public Sub SetupDGServiceHistory()
        Dim tStyle As DataGridTableStyle = Me.dgServiceHistory.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim DateCreated As New DataGridLabelColumn
        DateCreated.Format = "dd/MM/yyyy"
        DateCreated.FormatInfo = Nothing
        DateCreated.HeaderText = "Created"
        DateCreated.MappingName = "DateCreated"
        DateCreated.ReadOnly = True
        DateCreated.Width = 80
        DateCreated.NullText = ""
        tStyle.GridColumnStyles.Add(DateCreated)

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "Job No"
        JobNumber.MappingName = "JobNumber"
        JobNumber.ReadOnly = True
        JobNumber.Width = 75
        JobNumber.NullText = ""
        tStyle.GridColumnStyles.Add(JobNumber)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 145
        Type.NullText = Entity.Sys.Enums.ComboValues.Not_Applicable.ToString.Replace("_", " ")
        tStyle.GridColumnStyles.Add(Type)

        Dim VisitStatus As New DataGridLabelColumn
        VisitStatus.Format = ""
        VisitStatus.FormatInfo = Nothing
        VisitStatus.HeaderText = "Visit Status"
        VisitStatus.MappingName = "VisitStatus"
        VisitStatus.ReadOnly = True
        VisitStatus.Width = 125
        VisitStatus.NullText = ""
        tStyle.GridColumnStyles.Add(VisitStatus)

        Dim VisitOutcome As New DataGridLabelColumn
        VisitOutcome.Format = ""
        VisitOutcome.FormatInfo = Nothing
        VisitOutcome.HeaderText = "Outcome"
        VisitOutcome.MappingName = "VisitOutcome"
        VisitOutcome.ReadOnly = True
        VisitOutcome.Width = 125
        VisitOutcome.NullText = ""
        tStyle.GridColumnStyles.Add(VisitOutcome)

        Dim LastVisitDate As New DataGridLabelColumn
        LastVisitDate.Format = "dd/MM/yyyy"
        LastVisitDate.FormatInfo = Nothing
        LastVisitDate.HeaderText = "Date"
        LastVisitDate.MappingName = "LastVisitDate"
        LastVisitDate.ReadOnly = True
        LastVisitDate.Width = 100
        LastVisitDate.NullText = ""
        tStyle.GridColumnStyles.Add(LastVisitDate)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblJob.ToString
        Me.dgServiceHistory.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupDGAudit()
        Dim tStyle As DataGridTableStyle = Me.dgVanAudits.TableStyles(0)
        tStyle.GridColumnStyles.Clear()

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Action"
        Name.MappingName = "ActionChange"
        Name.ReadOnly = True
        Name.Width = 350
        Name.NullText = ""
        tStyle.GridColumnStyles.Add(Name)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Date"
        Site.MappingName = "ActionDateTime"
        Site.ReadOnly = True
        Site.Width = 100
        Site.NullText = ""
        tStyle.GridColumnStyles.Add(Site)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "User"
        Type.MappingName = "Fullname"
        Type.ReadOnly = True
        Type.Width = 200
        Type.NullText = ""
        tStyle.GridColumnStyles.Add(Type)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblFleetVanAudit.ToString
        Me.dgVanAudits.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub UCFleetVan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub btnEngineerHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowForm(GetType(FRMEngineerHistory), True, New Object() {CurrentVan.VanID})
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        ControlLoading = True
        If Not ID = 0 Then
            CurrentVan = DB.FleetVan.Get(ID)
            CurrentVanEngineer = DB.FleetVanEngineer.Get_ByVanID(CurrentVan.VanID)
            CurrentVanMaintenance = DB.FleetVanMaintenance.Get_ByVanID(CurrentVan.VanID)
            CurrentContract = DB.FleetVanContract.Get_ByVanID(CurrentVan.VanID)
            RunEstimateUpdates()

            Me.txtRegistration.Text = CurrentVan.Registration

            Combo.SetSelectedComboItem_By_Value(cboVanType, CurrentVan.VanTypeID)
            Dim currentVanType As Entity.FleetVans.FleetVanType = DB.FleetVanType.Get(CurrentVan.VanTypeID)

            If currentVanType IsNot Nothing Then
                Me.txtMake.Text = currentVanType.Make
                Me.txtModel.Text = currentVanType.Model
            End If

            Me.txtMileage.Text = CurrentVan.Mileage
            Me.txtAverageMileage.Text = CurrentVan.AverageMileage
            chkReturned.Checked = CurrentVan.Returned
            Me.txtNotes.Text = CurrentVan.Notes
            Me.txtTyreSize.Text = CurrentVan.TyreSize

            Dim department As String = CurrentVan.Department
            If CurrentVanEngineer.Exists Then
                Engineer = DB.Engineer.Engineer_Get(CurrentVanEngineer.EngineerID)
                Me.txtEngineer.Text = Engineer.Name
                department = Engineer.Department.Trim()

                dtpStartDate.Value = CurrentVanEngineer.StartDate
            Else
                Me.txtEngineer.Text = "<Not Set>"
            End If

            Combo.SetSelectedComboItem_By_Value(Me.cboDepartment, department)

            If CurrentVanMaintenance.Exists Then
                With CurrentVanMaintenance
                    dtpLastServiceDate.Value = .LastService
                    dtpNextServiceDate.Value = .NextService
                    Me.txtLastServiceMileage.Text = .LastServiceMileage
                    dtpMOTExpiry.Value = .MOTExpiry
                    dtpTaxExpiry.Value = .RoadTaxExpiry
                    Me.txtBreakdown.Text = .Breakdown
                    If .WarrantyExpiry <> Nothing Then dtpWarrantyExpiry.Value = .WarrantyExpiry
                    If .BreakdownExpiry <> Nothing Then dtpBreakdownExpiry.Value = .BreakdownExpiry
                End With
            End If

            If CurrentContract.Exists Then
                With CurrentContract
                    Me.txtLessor.Text = .Lessor
                    Combo.SetSelectedComboItem_By_Value(cboProcurementMethod, .ProcurementMethod)
                    If CurrentContract.ContractEnd <> Nothing Then
                        dtpContractEnd.Enabled = True
                        dtpContractEnd.Visible = True
                        btnRemoveContractEndDate.Visible = True
                        btnRemoveContractEndDate.Enabled = True
                        btnEndContract.Visible = False
                        btnEndContract.Enabled = False
                    Else
                        If .ProcurementMethod <> Entity.Sys.Enums.FleetVanContractProcurementMethod.Hire Then
                            dtpContractEnd.Enabled = True
                            dtpContractEnd.Visible = True
                            btnRemoveContractEndDate.Visible = True
                            btnRemoveContractEndDate.Enabled = True
                            btnEndContract.Visible = False
                            btnEndContract.Enabled = False
                        Else

                            dtpContractEnd.Enabled = False
                            dtpContractEnd.Visible = False
                            btnRemoveContractEndDate.Visible = False
                            btnRemoveContractEndDate.Enabled = False
                            btnEndContract.Visible = True
                            btnEndContract.Enabled = True
                        End If
                    End If
                    Me.txtContractLength.Text = .ContractLength
                    Me.txtContractMileage.Text = .ContractMileage
                    Me.txtStartingMileage.Text = .StartingMileage
                    Me.dtpContractStart.Value = .ContractStart
                    If .ContractEnd <> Nothing Then
                        Me.dtpContractEnd.Value = .ContractEnd
                    End If
                    Me.txtAgreementRef.Text = .AgreementRef
                    Me.txtContractNotes.Text = .Notes
                    Me.txtExcessMileageRate.Text = .ExcessMileageRate
                    Me.txtWeeklyRental.Text = .WeeklyRental
                    Me.txtMonthlyRental.Text = .MonthlyRental
                    Me.txtAnnualRental.Text = .AnnualRental
                    Me.txtExcessMileageCost.Text = .ExcessMileageCost
                    Me.txtForecastExcessCost.Text = .ForecastExcessMileageCost
                End With
            End If
            PopulateVanEquipmentDatagrid()
            PopulateEngineerHistoryDatagrid()
            PopulateVanFaultDatagrid()
            PopulateServiceDatagrid()
            PopulateVanAuditDatagrid()
        End If
        AddChangeHandlers(Me)
        ControlChanged = False
        ControlLoading = False
    End Sub

    Private Sub PopulateVanEquipmentDatagrid()
        Try
            VanEquipmentDataview = DB.FleetVanEquipment.Get_ByVanID(CurrentVan.VanID)
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PopulateVanFaultDatagrid()
        Try
            VanFaultDataview = DB.FleetVanFault.GetAll_ByVanID(CurrentVan.VanID)
            VanFaultDataview.RowFilter = "Archive = 0"
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PopulateServiceDatagrid()
        Try
            ServiceDataView = DB.FleetVanService.GetServices_ByVanId(CurrentVan.VanID)
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PopulateEngineerHistoryDatagrid()
        Try
            EngineerHistoryDataview = DB.FleetVanEngineer.GetAll_ByVanID(CurrentVan.VanID)
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PopulateVanAuditDatagrid()
        Try
            VanAuditsDataview = DB.FleetVan.VanAudit_Get(CurrentVan.VanID)
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Dim sender As Object = New Object
        Dim e As EventArgs = New EventArgs

        If Not btnSave_Click(sender, e) Then Return False
        If Not btnContractSave_Click(sender, e) Then Return False

        MainForm.RefreshEntity(CurrentVan.VanID)
    End Function

    Private Function btnSave_Click(sender As Object, e As EventArgs)
        Dim detailsSaved As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor
            CurrentVan.IgnoreExceptionsOnSetMethods = True

            Dim change As String = UpdateVanAudit()

            If CurrentVan.Exists = False Then
                btnNextService_Click(sender, e)
            End If

            With CurrentVan
                .SetRegistration = Me.txtRegistration.Text
                .SetVanTypeID = Combo.GetSelectedItemValue(cboVanType)
                .SetMileage = Entity.Sys.Helper.MakeIntegerValid(Me.txtMileage.Text)
                .SetAverageMileage = Entity.Sys.Helper.MakeIntegerValid(Me.txtAverageMileage.Text)
                .SetReturned = chkReturned.Checked
                .SetNotes = Me.txtNotes.Text
                .SetDepartment = Entity.Sys.Helper.MakeStringValid(Combo.GetSelectedItemValue(Me.cboDepartment).Trim())
                .SetTyreSize = Math.Round(Entity.Sys.Helper.MakeDoubleValid(Me.txtTyreSize.Text), 2).ToString()
            End With

            Dim cV As New Entity.FleetVans.FleetVanValidator
            cV.Validate(CurrentVan)
            detailsSaved = True

            If CurrentVan.Exists Then
                DB.FleetVan.Update(CurrentVan)
            Else
                CurrentVan = DB.FleetVan.Insert(CurrentVan)
            End If

            If Not String.IsNullOrEmpty(change) Then DB.FleetVan.VanAudit_Insert(CurrentVan.VanID, change)

            If CurrentVan.VanID > 0 Then

                If CurrentVanMaintenance Is Nothing Then
                    CurrentVanMaintenance = New Entity.FleetVans.FleetVanMaintenance
                End If

                Dim maintainanceChange As String = UpdateVanMaintenanceAudit()

                With CurrentVanMaintenance
                    .SetVanID = CurrentVan.VanID
                    .LastService = dtpLastServiceDate.Value
                    .NextService = dtpNextServiceDate.Value
                    .SetLastServiceMileage = Entity.Sys.Helper.MakeIntegerValid(Me.txtLastServiceMileage.Text)
                    .MOTExpiry = dtpMOTExpiry.Value
                    .RoadTaxExpiry = dtpTaxExpiry.Value
                    .SetBreakdown = Me.txtBreakdown.Text
                    .BreakdownExpiry = dtpBreakdownExpiry.Value
                    .WarrantyExpiry = dtpWarrantyExpiry.Value
                End With

                If CurrentVanEngineer Is Nothing Then
                    CurrentVanEngineer = New Entity.FleetVans.FleetVanEngineer
                End If

                Dim engineerChange As String = UpdateVanEngineerAudit()

                With CurrentVanEngineer
                    If Engineer Is Nothing Then
                        .SetEngineerID = 0
                    Else
                        .SetEngineerID = Engineer.EngineerID
                    End If

                    .SetVanID = CurrentVan.VanID
                    .StartDate = dtpStartDate.Value.Date
                    If chkEndDate.Checked Then
                        .EndDate = dtpEndDate.Value.Date
                    End If
                End With

                Dim cVE As New Entity.FleetVans.FleetVanEngineerValidator
                cVE.Validate(CurrentVanEngineer)

                If CurrentVanEngineer.EngineerID > 0 Then
                    If CurrentVanEngineer.Exists Then
                        DB.FleetVanEngineer.Update(CurrentVanEngineer)
                    Else
                        CurrentVanEngineer = DB.FleetVanEngineer.Insert(CurrentVanEngineer)
                    End If
                End If

                If Not String.IsNullOrEmpty(engineerChange) Then
                    DB.FleetVan.VanAudit_Insert(CurrentVan.VanID, engineerChange)
                End If

                Dim cVM As New Entity.FleetVans.FleetVanMaintenanceValidator
                cVM.Validate(CurrentVanMaintenance)

                If CurrentVanMaintenance.Exists Then
                    DB.FleetVanMaintenance.Update(CurrentVanMaintenance)
                Else
                    CurrentVanMaintenance = DB.FleetVanMaintenance.Insert(CurrentVanMaintenance)
                End If

                If Not String.IsNullOrEmpty(maintainanceChange) Then
                    DB.FleetVan.VanAudit_Insert(CurrentVan.VanID, maintainanceChange)
                End If

            End If

            If EquipmentList.Count > 0 Then
                For Each vanEquipmentID As Integer In EquipmentList
                    DB.FleetVanEquipment.Update(vanEquipmentID, CurrentVan.VanID)
                Next
            End If

            Return True
        Catch vex As ValidationException
            If detailsSaved Then
                Dim msg As String = "Main van details have been saved, please correct the following errors: " & vbNewLine & "{0}{1}"
                msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
                ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Dim msg As String = "Details have NOT been saved, please correct the following errors: " & vbNewLine & "{0}{1}"
                msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
                ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            Return False
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally

            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Function UpdateVanAudit() As String
        'we need to see whats different

        Dim update As Boolean = False
        Dim change As String = ""

        With CurrentVan
            If .Exists Then
                If .VanTypeID <> Combo.GetSelectedItemValue(cboVanType) Then
                    update = True
                    Dim oldVanType As Entity.FleetVans.FleetVanType =
                        DB.FleetVanType.Get(.VanTypeID)
                    Dim newVanType As Entity.FleetVans.FleetVanType =
                        DB.FleetVanType.Get(Combo.GetSelectedItemValue(cboVanType))
                    change += "Type of van changed from: " & oldVanType.Make & " " & oldVanType.Model &
                    " to: " & newVanType.Make & " " & newVanType.Model
                End If

                If .Mileage <> Me.txtMileage.Text Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    change += "Mileage changed from: " & .Mileage & " to: " & Me.txtMileage.Text
                End If

                If .AverageMileage <> Me.txtAverageMileage.Text Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    change += "Average Mileage changed from: " & .AverageMileage &
                        " to: " & Me.txtAverageMileage.Text
                End If

                If .Department <> Combo.GetSelectedItemValue(Me.cboDepartment) Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    change += "Department changed from: " & .Department &
                        " to: " & Combo.GetSelectedItemValue(Me.cboDepartment)
                End If

                If .Returned <> Me.chkReturned.Checked Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    If .Returned Then
                        change += "Van has been returned"
                    End If
                End If

                If .Notes <> txtNotes.Text Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    change += "Notes were updated"
                End If
            End If
        End With
        Return change
    End Function

    Private Function UpdateVanMaintenanceAudit() As String
        'we need to see whats different

        Dim update As Boolean = False
        Dim change As String = Nothing

        With CurrentVanMaintenance
            If .Exists Then
                If .LastService <> Me.dtpLastServiceDate.Value Then
                    update = True
                    change += "Last service date changed from: " & .LastService &
                        " to: " & Me.dtpLastServiceDate.Value
                End If

                If .NextService <> Me.dtpNextServiceDate.Value Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    change += "Next service date changed from: " & .NextService &
                        " to: " & Me.dtpNextServiceDate.Value
                End If

                If Entity.Sys.Helper.MakeIntegerValid(Me.txtLastServiceMileage.Text) Then
                    If .LastServiceMileage <> Me.txtLastServiceMileage.Text Then
                        If update Then
                            change += ", "
                        End If
                        update = True
                        change += "Last service mileage changed from: " & .LastServiceMileage &
                            " to: " & Me.txtLastServiceMileage.Text
                    End If
                Else
                    ShowMessage("Last Service requires a numberical value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

                If .MOTExpiry <> Me.dtpMOTExpiry.Value Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    change += "MOT expiry date changed from: " & .MOTExpiry &
                            " to: " & Me.dtpMOTExpiry.Value
                End If

                If .RoadTaxExpiry <> Me.dtpTaxExpiry.Value Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    change += "Road tax expiry date changed from: " & .RoadTaxExpiry &
                            " to: " & Me.dtpTaxExpiry.Value
                End If

                If .Breakdown <> Me.txtBreakdown.Text Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    change += "Breakdown provider changed from: " & .Breakdown &
                            " to: " & Me.txtBreakdown.Text
                End If
            End If
        End With
        Return change
    End Function

    Private Function UpdateVanEngineerAudit() As String
        'we need to see whats different

        Dim update As Boolean = False
        Dim change As String = ""

        With CurrentVanEngineer
            If .Exists Then
                If .EngineerID <> Engineer.EngineerID Then
                    update = True
                    change += "Engineer changed"
                End If

                If .StartDate <> Me.dtpStartDate.Value Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    change += "Start date changed from: " & .StartDate &
                        " to: " & Me.dtpStartDate.Value
                End If
            End If
        End With
        Return change
    End Function

    Private Function btnSaveFault_Click() As Boolean Handles btnSaveFault.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If CurrentVanFault Is Nothing Then
                CurrentVanFault = New Entity.FleetVans.FleetVanFault
            End If
            CurrentVanFault.IgnoreExceptionsOnSetMethods = True

            With CurrentVanFault
                .SetFaultTypeID = Combo.GetSelectedItemValue(cboFaultType)
                .SetVanID = CurrentVan.VanID
                .FaultDate = dtpFaultDate.Value
                .SetArchive = chkArchive.Checked
                .ResolvedDate = IIf(chkResolved.Checked, dtpResolvedDate.Value, Nothing)
                .SetEngineerNotes = Me.txtEngineerFaultNotes.Text
                If String.IsNullOrEmpty(Me.txtAdditionalNotes.Text) Then
                    .SetNotes = Me.txtFaultNotes.Text
                ElseIf String.IsNullOrEmpty(Me.txtFaultNotes.Text) Then
                    .SetNotes = Me.txtAdditionalNotes.Text
                Else
                    .SetNotes = Me.txtFaultNotes.Text & vbNewLine & vbNewLine & Me.txtAdditionalNotes.Text
                End If

            End With

            Dim cVE As New Entity.FleetVans.FleetVanFaultValidator
            cVE.Validate(CurrentVanFault)

            If CurrentVanFault.Exists Then
                DB.FleetVanFault.Update(CurrentVanFault)
            Else
                CurrentVanFault = DB.FleetVanFault.Insert(CurrentVanFault)
            End If

            PopulateVanFaultDatagrid()

            Return True
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Function btnContractSave_Click(sender As Object, e As EventArgs)
        Dim emsg As String = "Please ensure the main details are saved first!"
        If CurrentVan Is Nothing Then
            ShowMessage(emsg, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If Not CurrentVan.Exists Then
            ShowMessage(emsg, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Try
            Me.Cursor = Cursors.WaitCursor
            If CurrentContract Is Nothing Then
                CurrentContract = New Entity.FleetVans.FleetVanContract
            End If

            Dim change As String = UpdateVanContractAudit()

            With CurrentContract
                .IgnoreExceptionsOnSetMethods = True
                .SetVanID = CurrentVan.VanID
                .SetLessor = Me.txtLessor.Text
                .SetProcurementMethod = Combo.GetSelectedItemValue(cboProcurementMethod)
                .SetContractLength = Me.txtContractLength.Text
                .ContractStart = dtpContractStart.Value
                .ContractEnd = If(dtpContractEnd.Enabled, dtpContractEnd.Value, Nothing)
                .SetContractMileage = Entity.Sys.Helper.MakeIntegerValid(Me.txtContractMileage.Text)
                .SetStartingMileage = Entity.Sys.Helper.MakeIntegerValid(Me.txtStartingMileage.Text)
                .SetExcessMileageRate = Entity.Sys.Helper.MakeDoubleValid(Me.txtExcessMileageRate.Text)
                .SetWeeklyRental = Entity.Sys.Helper.MakeDoubleValid(Me.txtWeeklyRental.Text)
                .SetMonthlyRental = Entity.Sys.Helper.MakeDoubleValid(Me.txtMonthlyRental.Text)
                .SetAnnualRental = Entity.Sys.Helper.MakeDoubleValid(Me.txtAnnualRental.Text)
                .SetAgreementRef = Me.txtAgreementRef.Text
                .SetNotes = Me.txtContractNotes.Text
            End With

            Dim cVE As New Entity.FleetVans.FleetVanContractValidator
            cVE.Validate(CurrentContract)

            If CurrentContract.Exists Then
                DB.FleetVanContract.Update(CurrentContract)
            Else
                CurrentContract = DB.FleetVanContract.Insert(CurrentContract)
            End If
            If Not String.IsNullOrEmpty(change) Then DB.FleetVan.VanAudit_Insert(CurrentVan.VanID, change)
            Return True
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Function UpdateVanContractAudit() As String
        'we need to see whats different

        Dim update As Boolean = False
        Dim change As String = ""

        With CurrentContract
            If .Exists Then
                If .Lessor <> Me.txtLessor.Text Then
                    update = True
                    change += "Lessor changed from: " & .Lessor &
                        " to: " & Me.txtLessor.Text
                End If

                If Entity.Sys.Helper.MakeIntegerValid(Me.txtContractLength.Text) Then
                    If .ContractLength <> Me.txtContractLength.Text Then
                        If update Then
                            change += ", "
                        End If
                        update = True
                        change += "Contract length changed from: " & .ContractLength &
                                " to: " & Me.txtContractLength.Text
                    End If
                Else
                    ShowMessage("Contract Length requires a numberical value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If

            If .ContractStart <> Me.dtpContractStart.Value Then
                If update Then
                    change += ", "
                End If
                update = True
                change += "Contract start changed from: " & .ContractStart &
                        " to: " & Me.dtpContractStart.Value
            End If

            If .ContractEnd <> Me.dtpContractEnd.Value Then
                If update Then
                    change += ", "
                End If
                update = True
                change += "Contract end changed from: " & .ContractEnd &
                        " to: " & Me.dtpContractEnd.Value
            End If

            If Entity.Sys.Helper.MakeIntegerValid(Me.txtContractMileage.Text) Then
                If .ContractMileage <> Me.txtContractMileage.Text Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    change += "Contract mileage changed from: " & .ContractMileage &
                        " to: " & Me.txtContractMileage.Text
                End If
            Else
                ShowMessage("Contract mileage requires a numberical value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            If Entity.Sys.Helper.MakeIntegerValid(Me.txtStartingMileage.Text) Then
                If .StartingMileage <> Me.txtStartingMileage.Text Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    change += "Contract start mileage changed from: " & .StartingMileage &
                        " to: " & Me.txtStartingMileage.Text
                End If
            Else
                ShowMessage("Contract mileage requires a numberical value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            If .ExcessMileageRate <> Me.txtExcessMileageRate.Text Then
                If update Then
                    change += ", "
                End If
                update = True
                change += "Excess mileage rate changed from: " & .ExcessMileageRate &
                        " to: " & Me.txtExcessMileageRate.Text
            End If

            If .ExcessMileageCost <> Me.txtExcessMileageCost.Text Then
                If update Then
                    change += ", "
                End If
                update = True
                change += "Excess mileage cost changed from: " & .ExcessMileageCost &
                        " to: " & Me.txtExcessMileageCost.Text
            End If

            If .ForecastExcessMileageCost <> Me.txtForecastExcessCost.Text Then
                If update Then
                    change += ", "
                End If
                update = True
                change += "Forecast excess mileage cost changed from: " & .ForecastExcessMileageCost &
                        " to: " & Me.txtForecastExcessCost.Text
            End If

            If .WeeklyRental <> Me.txtWeeklyRental.Text Then
                If update Then
                    change += ", "
                End If
                update = True
                change += "Weekly rental rate changed from: " & .WeeklyRental &
                        " to: " & Me.txtWeeklyRental.Text
            End If

            If .MonthlyRental <> Me.txtMonthlyRental.Text Then
                If update Then
                    change += ", "
                End If
                update = True
                change += "Monthly rental rate changed from: " & .MonthlyRental &
                        " to: " & Me.txtMonthlyRental.Text
            End If

            If .AnnualRental <> Me.txtAnnualRental.Text Then
                If update Then
                    change += ", "
                End If
                update = True
                change += "Annual rental rate changed from: " & .AnnualRental &
                        " to: " & Me.txtAnnualRental.Text
            End If
        End With
        Return change
    End Function

    Private Sub RunEstimateUpdates()

        'First we need to calculate the average mileage
        'Get the weeks between now and the last service date
        If Not CurrentVanMaintenance.Exists Then
            Exit Sub
        End If
        Try
            Dim weeks As Integer = DateDiff(DateInterval.WeekOfYear, CurrentVanMaintenance.LastService, Date.Now)
            If weeks < 1 Then
                weeks = 1
            End If
            If CurrentVan.Mileage < 1 Then
                Exit Sub
            End If
            Dim mileageDiff As Integer = CurrentVan.Mileage - CurrentVanMaintenance.LastServiceMileage
            Dim avgMileages As New List(Of Integer)

            'calculate average mileage based on last service
            Dim currentContractLength As Integer = 0
            Dim lastServiceAverageMileage As Double = 0

            'multiple the average mileage by 4
            lastServiceAverageMileage = Math.Round((mileageDiff / weeks) * 4.3, MidpointRounding.AwayFromZero)
            CurrentVan.SetAverageMileage = lastServiceAverageMileage

            If CurrentContract.Exists Then
                If CurrentContract.ContractStart < Date.Now And
                        CurrentContract.ProcurementMethod <> Entity.Sys.Enums.FleetVanContractProcurementMethod.Owned And
                        CurrentContract.ContractLength > 0 Then
                    avgMileages.Add(lastServiceAverageMileage)

                    'calculate the average mileage over the contract period
                    currentContractLength =
                        DateDiff(DateInterval.WeekOfYear, CurrentContract.ContractStart, Date.Now)

                    Dim mileageFromContractStart As Integer = CurrentVan.Mileage - CurrentContract.StartingMileage

                    If currentContractLength > 0 Then
                        Dim currentAverageMileageOverContract As Double =
                            Math.Round((mileageFromContractStart / currentContractLength) * 4.3, MidpointRounding.AwayFromZero)

                        avgMileages.Add(currentAverageMileageOverContract)
                        CurrentVan.SetAverageMileage = CInt(avgMileages.Average)
                    End If
                End If
            End If

            Dim vanType As Entity.FleetVans.FleetVanType =
                DB.FleetVanType.Get(CurrentVan.VanTypeID)

            'next service based on date
            Dim nsDate As Date = CurrentVanMaintenance.LastService.AddMonths(vanType.DateServiceInterval)

            ' lets see how many months it will take to get to next service mileage
            Dim avg As Integer = vanType.MileageServiceInterval / CurrentVan.AverageMileage
            'next service based on mileage
            Dim nsMileage As Date = CurrentVanMaintenance.LastService.AddMonths(avg)

            If nsDate < nsMileage Then
                CurrentVanMaintenance.NextService = nsDate
            Else
                CurrentVanMaintenance.NextService = nsMileage
            End If

            If CurrentContract.ContractMileage = 0 Then
                CurrentContract.SetExcessMileageCost = 0
                CurrentContract.SetForecastExcessMileageCost = CurrentContract.ExcessMileageCost
                Exit Sub
            End If

            'calculate the excess mileage cost
            If CurrentVan.Mileage > CurrentContract.ContractMileage Then
                Dim contractMileageDiff As Integer = CurrentVan.Mileage - CurrentContract.ContractMileage

                Dim excessMileageCost As Double = CurrentContract.ExcessMileageRate * contractMileageDiff
                CurrentContract.SetExcessMileageCost = excessMileageCost
            Else
                CurrentContract.SetExcessMileageCost = 0
            End If

            If CurrentContract.ContractEnd = Nothing Then
                Exit Sub
            End If

            'get contract length
            CurrentContract.SetContractLength = DateDiff(DateInterval.Month, CurrentContract.ContractStart, CurrentContract.ContractEnd)

            Dim remainingLength As Integer =
                Math.Round(CurrentContract.ContractLength - (currentContractLength / 4.3))

            Dim estMileageOverRemainingLength As Double =
                lastServiceAverageMileage * remainingLength

            Dim estContractMileage As Integer =
                estMileageOverRemainingLength + CurrentVan.Mileage

            If estContractMileage > CurrentContract.ContractMileage Then
                Dim contractMileageDiff As Integer = estContractMileage - CurrentContract.ContractMileage

                Dim excessMileageCost As Double = CurrentContract.ExcessMileageRate * contractMileageDiff
                CurrentContract.SetForecastExcessMileageCost = Math.Round(excessMileageCost, 2,
                                                                          MidpointRounding.AwayFromZero)
            Else
                CurrentContract.SetForecastExcessMileageCost = CurrentContract.ExcessMileageCost
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnfindEngineer_Click(sender As Object, e As EventArgs) Handles btnfindEngineer.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblEngineer)
        If Not ID = 0 Then
            'temporaily store engineer
            Dim tempEngineer As Entity.Engineers.Engineer = DB.Engineer.Engineer_Get(ID)
            If tempEngineer IsNot Nothing Then
                'check to see if vehicle of road
                If Not tempEngineer.EngineerID = Entity.Sys.Consts.VOR Then
                    'Lets see if the engineer is assigned to any other van
                    Dim engineerDv As DataView = DB.FleetVanEngineer.GetAll_ByEngineerID(tempEngineer.EngineerID)
                    'if count more than 0 then engineer has been assigned to van and cannot have two
                    If engineerDv.Table.Rows.Count > 0 Then
                        Dim reg As List(Of String) = New List(Of String)
                        Dim vanEngineerID As List(Of Integer) = New List(Of Integer)
                        For Each rowView As DataRowView In engineerDv
                            Dim row As DataRow = rowView.Row
                            reg.Add(row.Item("Registration"))
                            vanEngineerID.Add(row.Item("VanEngineerID"))
                        Next
                        If reg.Count > 0 Then
                            Dim regString As String = String.Join(Environment.NewLine, reg.ToArray())
                            If ShowMessage(tempEngineer.Name & " is currently assigned to the following van(s): " &
                                       regString & ", do you wish to continue?",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                For Each vanId As Integer In vanEngineerID
                                    DB.FleetVanEngineer.Delete(vanId)
                                Next
                                Engineer = tempEngineer
                            End If
                        End If
                    Else
                        Engineer = tempEngineer
                    End If
                Else
                    Engineer = tempEngineer
                End If
            End If
        End If
    End Sub

    Private Sub btnNextService_Click(sender As Object, e As EventArgs) Handles btnNextService.Click

        Dim lastServiceAverageMileage As Integer = 0
        Dim mileage As Integer = 0
        Dim lastServiceMileage As Integer = 0
        Dim lastServiceDate As Date = dtpLastServiceDate.Value

        'Using the current mileage, last service mileage and last service date we can calculate the average mileage
        Try
            If Me.txtMileage.Text.Trim.Length < 1 Then
                Throw New Exception
            End If
            mileage = CInt(Me.txtMileage.Text)
        Catch ex As Exception
            ShowMessage("Please add mileage", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        Try
            If Me.txtLastServiceMileage.Text.Trim.Length < 1 Then
                Throw New Exception
            End If
            lastServiceMileage = CInt(Me.txtLastServiceMileage.Text)
        Catch ex As Exception
            ShowMessage("Please add last service mileage", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        'First we need to calculate the average mileage
        'Get the weeks between now and the last service date
        Dim weeks As Integer = DateDiff(DateInterval.WeekOfYear, lastServiceDate, Date.Now)
        If weeks < 1 Then
            weeks = 1
        End If
        Dim mileageDiff As Integer = mileage - lastServiceMileage
        Dim avgMileages As New List(Of Integer)

        lastServiceAverageMileage = Math.Round((mileageDiff / weeks) * 4.3, MidpointRounding.AwayFromZero)
        Me.txtAverageMileage.Text = lastServiceAverageMileage

        If CurrentContract IsNot Nothing Then
            If CurrentContract.Exists Then
                If CurrentContract.ContractStart < Date.Now And
                    CurrentContract.ProcurementMethod <> Entity.Sys.Enums.FleetVanContractProcurementMethod.Owned And
                    CurrentContract.ContractLength > 0 Then
                    avgMileages.Add(lastServiceAverageMileage)

                    'calculate the average mileage over the contract period
                    Dim currentContractLength As Integer = 0
                    currentContractLength =
                        DateDiff(DateInterval.WeekOfYear, CurrentContract.ContractStart, Date.Now)

                    Dim mileageFromContractStart As Integer = mileage - Entity.Sys.Helper.MakeIntegerValid(Me.txtStartingMileage.Text)

                    If currentContractLength > 0 Then
                        Dim currentAverageMileageOverContract As Double =
                        Math.Round((mileageFromContractStart / currentContractLength) * 4.3, MidpointRounding.AwayFromZero)

                        avgMileages.Add(currentAverageMileageOverContract)
                        Me.txtAverageMileage.Text = CInt(avgMileages.Average)
                    End If
                End If
            End If
        End If

        If Combo.GetSelectedItemValue(cboVanType) = 0 Then
            ShowMessage("Please select van type", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim vanType As Entity.FleetVans.FleetVanType =
            DB.FleetVanType.Get(Combo.GetSelectedItemValue(cboVanType))

        'next service based on date
        Dim nsDate As Date = lastServiceDate.AddMonths(vanType.DateServiceInterval)

        ' lets see how many months it will take to get to next service mileage
        If CInt(Me.txtAverageMileage.Text) > 0 Then
            Dim avg As Integer = vanType.MileageServiceInterval / CInt(Me.txtAverageMileage.Text)
            'next service based on mileage
            Dim nsMileage As Date = lastServiceDate.AddMonths(avg)

            If nsDate < nsMileage Then
                dtpNextServiceDate.Value = nsDate
            Else
                dtpNextServiceDate.Value = nsMileage
            End If
        End If

    End Sub

    Private Sub cboVanType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboVanType.SelectedIndexChanged

        Dim currentVanType As Entity.FleetVans.FleetVanType = DB.FleetVanType.Get(
            Combo.GetSelectedItemValue(cboVanType))
        If currentVanType IsNot Nothing Then
            Me.txtMake.Text = currentVanType.Make
            Me.txtModel.Text = currentVanType.Model
        End If
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        'remove engineer from van
        If CurrentVanEngineer IsNot Nothing Then
            If ShowMessage("Are you sure you want to remove " & txtEngineer.Text &
                       "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If CurrentVanEngineer.Exists Then
                    Dim endDate As DateTime = IIf(chkEndDate.Checked, dtpEndDate.Value.Date, Nothing)
                    DB.FleetVanEngineer.Delete(CurrentVanEngineer.VanEngineerID, endDate)
                    CurrentVanEngineer = Nothing
                    Engineer = Nothing
                    PopulateEngineerHistoryDatagrid()
                    chkEndDate.Checked = False
                    dtpStartDate.Value = Date.Now
                    dtpEndDate.Value = Date.Now
                    ShowMessage("Engineer has been removed from current van.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    CurrentVanEngineer = Nothing
                    Engineer = Nothing
                    PopulateEngineerHistoryDatagrid()
                End If
            End If
        End If
    End Sub

    Private Sub dgVanFaults_Click(sender As Object, e As EventArgs) Handles dgVanFaults.Click, dgVanFaults.CurrentCellChanged
        Try
            If CurrentVan Is Nothing Then
                Exit Sub
            End If
            If Not CurrentVan.Exists Then
                Exit Sub
            End If

            If SelectedFaultDataRow Is Nothing Then
                Exit Sub
            End If
            CurrentVanFault = DB.FleetVanFault.Get(SelectedFaultDataRow.Item("VanFaultID"))
            With CurrentVanFault
                Combo.SetSelectedComboItem_By_Value(cboFaultType, .FaultTypeID)
                dtpFaultDate.Value = .FaultDate
                chkResolved.Checked = False
                chkArchive.Checked = .Archive
                If .ResolvedDate <> Nothing Then
                    dtpResolvedDate.Value = .ResolvedDate
                    chkResolved.Checked = True
                Else
                    dtpResolvedDate.Value = Now
                End If
                dtpResolvedDate.Enabled = chkResolved.Checked
                Me.txtEngineerFaultNotes.Text = .EngineerNotes
                Me.txtFaultNotes.Text = .Notes
                Me.txtAdditionalNotes.Text = String.Empty
                Dim job As Entity.Jobs.Job =
                    DB.Job.Job_Get(.JobID)
                Dim visit As Entity.EngineerVisits.EngineerVisit =
                    DB.EngineerVisits.EngineerVisits_Get_LastForJob(.JobID)
                If job IsNot Nothing And visit IsNot Nothing Then
                    Me.txtJobRef.Text = job.JobNumber
                    If visit.StartDateTime <> Nothing Then
                        Me.txtScheduled.Text = visit.StartDateTime.ToShortDateString
                    End If
                    Me.txtStatus.Text = visit.VisitStatus
                    Me.txtOutcome.Text = visit.VisitOutcome
                Else
                    Me.txtJobRef.Text = ""
                    Me.txtScheduled.Text = ""
                    Me.txtStatus.Text = ""
                    Me.txtOutcome.Text = ""
                End If
            End With
        Catch ex As Exception
            ShowMessage("Error, cannot find fault : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNewFault_Click(sender As Object, e As EventArgs) Handles btnNewFault.Click
        Combo.SetSelectedComboItem_By_Value(cboFaultType, 0)
        CurrentVanFault = Nothing
        dtpFaultDate.Value = Now
        dtpResolvedDate.Value = Now
        chkResolved.Checked = False
        chkArchive.Checked = False
        Me.txtEngineerFaultNotes.Text = String.Empty
        Me.txtFaultNotes.Text = String.Empty
        Me.txtJobRef.Text = ""
        Me.txtScheduled.Text = ""
        Me.txtStatus.Text = ""
        Me.txtOutcome.Text = ""
    End Sub

    Private Sub dgServiceHistory_DoubleClick(sender As Object, e As EventArgs) Handles dgServiceHistory.DoubleClick
        If SelectedServiceDataRow Is Nothing Then
            Exit Sub
        End If

        ShowForm(GetType(FRMLogCallout), True, New Object() {SelectedServiceDataRow.Item("JobID"), SelectedServiceDataRow.Item("SiteID"), Me})

    End Sub

    Private Sub btnRemoveEquipment_Click(sender As Object, e As EventArgs) Handles btnRemoveEquipment.Click
        If ShowMessage("Are you sure you want to remove " & SelectedEquipmentDataRow.Item("Name") &
                       "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DB.FleetVanEquipment.Delete(SelectedEquipmentDataRow.Item("VanEquipmentID"))
            PopulateVanEquipmentDatagrid()
        End If
    End Sub

    Private Sub btnAddEquipment_Click(sender As Object, e As EventArgs) Handles btnAddEquipment.Click
        Dim f As New FRMAddVanEquipment
        f.ShowDialog()
        If DB.FleetVanEquipment.Check(CurrentVan.VanID, Combo.GetSelectedItemValue(f.cboEquipment)) = 0 Then
            Dim vanEquipmentID As Integer =
                DB.FleetVanEquipment.Insert(CurrentVan.VanID, Combo.GetSelectedItemValue(f.cboEquipment))
            If CurrentVan.VanID = 0 Then
                EquipmentList.Add(vanEquipmentID)
            End If
            PopulateVanEquipmentDatagrid()
        Else
            ShowMessage("Equipment already assigned to van", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub chkResolved_CheckedChanged(sender As Object, e As EventArgs) Handles chkResolved.CheckedChanged
        dtpResolvedDate.Enabled = chkResolved.Checked

        If CurrentVanFault IsNot Nothing Then
            If CurrentVanFault.ResolvedDate = Nothing Then dtpResolvedDate.Value = Now
        Else
            dtpResolvedDate.Value = Now
        End If
    End Sub

    Private Sub dgVanFaults_DoubleClick(sender As Object, e As EventArgs) Handles dgVanFaults.DoubleClick
        If CurrentVanFault.Exists Then
            If CurrentVanFault.JobID > 0 Then
                Dim job As Entity.Jobs.Job = DB.Job.Job_Get(CurrentVanFault.JobID)
                If job IsNot Nothing Then
                    ShowForm(GetType(FRMLogCallout), True, New Object() {job.JobID, job.PropertyID, Me})
                End If
            End If
        End If
    End Sub

    Private Sub txtExcessMileageRate_KeyUp(sender As Object, e As KeyEventArgs) Handles txtExcessMileageRate.KeyUp
        If CurrentContract IsNot Nothing Then
            If CurrentContract.Exists Then
                CurrentContract.SetExcessMileageRate = Me.txtExcessMileageRate.Text
                RunEstimateUpdates()
            End If
        End If
    End Sub

    Private Sub txtWeeklyRental_KeyUp(sender As Object, e As KeyEventArgs) Handles txtWeeklyRental.KeyUp
        Try
            Dim weeklyRental As Double = CDbl(Me.txtWeeklyRental.Text)
            'set monthly and annual rental costs
            Me.txtMonthlyRental.Text = Math.Round(weeklyRental * 4.3, MidpointRounding.AwayFromZero)
            Me.txtAnnualRental.Text = Math.Round(weeklyRental * 52, MidpointRounding.AwayFromZero)
        Catch ex As Exception
            ShowMessage("Weekly rental in wrong format", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtMonthlyRental_KeyUp(sender As Object, e As KeyEventArgs) Handles txtMonthlyRental.KeyUp
        Try
            Dim montlyRental As Double = CDbl(Me.txtMonthlyRental.Text)
            'set weekly and annual rental costs
            Me.txtWeeklyRental.Text = Math.Round(montlyRental / 4.3, MidpointRounding.AwayFromZero)
            Me.txtAnnualRental.Text = Math.Round(montlyRental * 12, MidpointRounding.AwayFromZero)
        Catch ex As Exception
            ShowMessage("Monthly rental in wrong format", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtAnnualRental_KeyUp(sender As Object, e As KeyEventArgs) Handles txtAnnualRental.KeyUp
        Try
            Dim annualRental As Double = CDbl(Me.txtAnnualRental.Text)
            'set monthly and annual rental costs
            Me.txtWeeklyRental.Text = Math.Round(annualRental / 52, MidpointRounding.AwayFromZero)
            Me.txtMonthlyRental.Text = Math.Round(annualRental / 12, MidpointRounding.AwayFromZero)
        Catch ex As Exception
            ShowMessage("Annual rental in wrong format", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgVanAudits_Click(sender As Object, e As EventArgs) Handles dgVanAudits.Click
        If SelectedVanHistoryDataRow IsNot Nothing Then
            Me.dtpHistoryDate.Value = SelectedVanHistoryDataRow.Item("ActionDateTime")
            Me.txtUsername.Text = SelectedVanHistoryDataRow.Item("Fullname")
            Me.txtChange.Text = SelectedVanHistoryDataRow.Item("ActionChange")
        End If
    End Sub

    Private Sub btnEndContract_Click(sender As Object, e As EventArgs) Handles btnEndContract.Click
        If ShowMessage("End Contract, Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) =
            DialogResult.OK Then
            If CurrentContract.Exists Then
                CurrentContract.ContractEnd = Date.Now
                DB.FleetVanContract.Update(CurrentContract)

                Dim change As String = "Contract ended"
                If Not String.IsNullOrEmpty(change) Then DB.FleetVan.VanAudit_Insert(CurrentVan.VanID, change)
            End If
        End If
    End Sub

    Private Sub cboProcurementMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProcurementMethod.SelectedIndexChanged
        If Combo.GetSelectedItemValue(cboProcurementMethod) <>
                        Entity.Sys.Enums.FleetVanContractProcurementMethod.Hire Then
            dtpContractEnd.Enabled = True
            dtpContractEnd.Visible = True
            btnEndContract.Visible = False
            btnEndContract.Enabled = False
        Else
            dtpContractEnd.Enabled = False
            dtpContractEnd.Visible = False
            btnEndContract.Visible = True
            btnEndContract.Enabled = True
        End If

        If CurrentContract IsNot Nothing Then
            If CurrentContract.ContractEnd <> Nothing Then
                dtpContractEnd.Enabled = True
                dtpContractEnd.Visible = True
                btnEndContract.Visible = False
                btnEndContract.Enabled = False
            End If
        End If
    End Sub

    Private Sub chkReturned_CheckedChanged(sender As Object, e As EventArgs) Handles chkReturned.CheckedChanged
        If ControlLoading Then
            Exit Sub
        End If
        If chkReturned.Checked Then
            If ShowMessage("Return Vehicle? If yes, contract will end today and engineer shall be removed!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If CurrentVanEngineer IsNot Nothing Then
                    If CurrentVanEngineer.Exists Then
                        DB.FleetVanEngineer.Delete(CurrentVanEngineer.VanEngineerID)
                        CurrentVanEngineer = Nothing
                        Engineer = Nothing
                    End If
                End If
                If CurrentContract.Exists Then
                    CurrentContract.ContractEnd = Date.Now
                    DB.FleetVanContract.Update(CurrentContract)
                End If
                DB.FleetVan.ReturnVan(CurrentVan.VanID)
                Dim change As String = "Van returned"
                If Not String.IsNullOrEmpty(change) Then DB.FleetVan.VanAudit_Insert(CurrentVan.VanID, change)
                Populate(CurrentVan.VanID)
                Save()
                ControlChanged = False
            Else
                chkReturned.Checked = False
            End If
        End If
    End Sub

    Private Sub chkEndDate_CheckedChanged(sender As Object, e As EventArgs) Handles chkEndDate.CheckedChanged
        If ControlLoading Then
            Exit Sub
        End If
        If chkEndDate.Checked Then
            dtpEndDate.Enabled = True
        Else
            dtpEndDate.Enabled = False
        End If
    End Sub

    Private Sub chkHideArchive_CheckedChanged(sender As Object, e As EventArgs) Handles chkHideArchive.CheckedChanged
        If VanFaultDataview Is Nothing Then
            Exit Sub
        End If
        VanFaultDataview.RowFilter = IIf(chkHideArchive.Checked, "Archive = 0", "")
    End Sub

    Private Sub btnRemoveContractEndDate_Click(sender As Object, e As EventArgs) Handles btnRemoveContractEndDate.Click
        If ShowMessage("Are you sure you want to remove the contract end date?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.btnRemoveContractEndDate.Visible = False
            Me.dtpContractEnd.Visible = False
            Me.dtpContractEnd.Enabled = False
            Me.btnEndContract.Visible = True
            Me.btnEndContract.Enabled = True
        End If
    End Sub

    Private Sub btnSaveFault_Click(sender As Object, e As EventArgs) Handles btnSaveFault.Click

    End Sub

#End Region

End Class