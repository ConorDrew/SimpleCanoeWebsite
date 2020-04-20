Imports System.Collections.Generic

Imports System.IO
Imports System.Linq
Imports FSM.Entity.Sys

Public Class UCCustomer : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Combo.SetUpCombo(Me.cboRegionID, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboStatus, DynamicDataTables.CustomerStatus, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.CustomerTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboTerms, DB.Picklists.GetAll(70).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboAlertType, DB.Picklists.GetAll(Enums.PickListTypes.AlertTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        Select Case True
            Case IsGasway
                Combo.SetUpCombo(Me.cboDepartment, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative)
            Case Else
                Combo.SetUpCombo(Me.cboDepartment, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative)
        End Select

        SetupDG()

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

    Friend WithEvents grpCustomer As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents cboRegionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblRegionID As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents txtAccountNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblAccountNumber As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents tabMainDetails As System.Windows.Forms.TabPage
    Friend WithEvents tabDocuments As System.Windows.Forms.TabPage
    Friend WithEvents pnlDocuments As System.Windows.Forms.Panel
    Friend WithEvents tabContracts As System.Windows.Forms.TabPage
    Friend WithEvents pnlContracts As System.Windows.Forms.Panel
    Friend WithEvents tabQuotes As System.Windows.Forms.TabPage
    Friend WithEvents pnlQuotes As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents tabCharges As System.Windows.Forms.TabPage
    Friend WithEvents pnlCharges As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRatesMarkup As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMileageRate As System.Windows.Forms.TextBox
    Friend WithEvents txtPartsMarkup As System.Windows.Forms.TextBox
    Friend WithEvents grbCharges As System.Windows.Forms.GroupBox
    Friend WithEvents gpbContracts As System.Windows.Forms.GroupBox
    Friend WithEvents dgContracts As System.Windows.Forms.DataGrid
    Friend WithEvents btnAddContract As System.Windows.Forms.Button
    Friend WithEvents btnDeleteContract As System.Windows.Forms.Button
    Friend WithEvents cmnuContractOptions As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuContractOpt1 As System.Windows.Forms.MenuItem
    Friend WithEvents chbAcceptChargeChanges As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    Friend WithEvents btnSelectLogoImage As System.Windows.Forms.Button
    Friend WithEvents chkPONumReq As System.Windows.Forms.CheckBox
    Friend WithEvents chkJobPriorityRequired As System.Windows.Forms.CheckBox
    Friend WithEvents txtNominal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tabPriority As System.Windows.Forms.TabPage
    Friend WithEvents cboDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboTerms As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dgRequirements As System.Windows.Forms.DataGrid
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkSuperBooking As System.Windows.Forms.CheckBox
    Friend WithEvents txtServWinter As System.Windows.Forms.TextBox
    Friend WithEvents txtServSummer As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tabParts As System.Windows.Forms.TabPage
    Friend WithEvents dgvParts As System.Windows.Forms.DataGridView
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents dgvPriority As DataGridView
    Friend WithEvents txtAlertEmail As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents tabServiceDates As TabPage
    Friend WithEvents tabCreation As TabPage
    Friend WithEvents btnEngDelete As Button
    Friend WithEvents btnEngAdd As Button
    Friend WithEvents dgRaiseEng As DataGridView
    Friend WithEvents chkMOTService As CheckBox
    Friend WithEvents tabAuthority As TabPage
    Friend WithEvents gpCustAuth As GroupBox
    Friend WithEvents txtCustAuthority As TextBox
    Friend WithEvents btnSaveAuth As Button
    Friend WithEvents grpAudit As GroupBox
    Friend WithEvents dgAuthorityAudit As DataGrid
    Friend WithEvents Label14 As Label
    Friend WithEvents txtPartSearch As TextBox
    Friend WithEvents btnExportSites As Button
    Friend WithEvents cbIsOutOfScope As CheckBox
    Friend WithEvents txtSpendLimit As TextBox
    Friend WithEvents lblJobSpendLimit As Label
    Friend WithEvents chkIsPFH As CheckBox
    Friend WithEvents tabAlerts As TabPage
    Friend WithEvents grpCustomerAlerts As GroupBox
    Friend WithEvents dgCustomerAlerts As DataGrid
    Friend WithEvents grpSite As GroupBox
    Friend WithEvents btnSaveCustomerAlert As Button
    Friend WithEvents cboAlertType As ComboBox
    Friend WithEvents lblCustomerAlertEmailAddress As Label
    Friend WithEvents lblAlertType As Label
    Friend WithEvents txtCustomerAlertEmailAddress As TextBox
    Friend WithEvents lblEmailAddressMsg As Label
    Friend WithEvents btnDeleteCustomerAlert As Button
    Friend WithEvents btnAddCustomerAlert As Button
    Friend WithEvents tt As ToolTip
    Friend WithEvents pnlServiceProcess As Panel
    Friend WithEvents txtMainContractorDiscount As System.Windows.Forms.TextBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.grpCustomer = New System.Windows.Forms.GroupBox()
        Me.chkIsPFH = New System.Windows.Forms.CheckBox()
        Me.cbIsOutOfScope = New System.Windows.Forms.CheckBox()
        Me.btnExportSites = New System.Windows.Forms.Button()
        Me.chkMOTService = New System.Windows.Forms.CheckBox()
        Me.txtAlertEmail = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtServWinter = New System.Windows.Forms.TextBox()
        Me.txtServSummer = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkSuperBooking = New System.Windows.Forms.CheckBox()
        Me.cboTerms = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboDepartment = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtNominal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkJobPriorityRequired = New System.Windows.Forms.CheckBox()
        Me.chkPONumReq = New System.Windows.Forms.CheckBox()
        Me.btnSelectLogoImage = New System.Windows.Forms.Button()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.cboRegionID = New System.Windows.Forms.ComboBox()
        Me.lblRegionID = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.txtAccountNumber = New System.Windows.Forms.TextBox()
        Me.lblAccountNumber = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabMainDetails = New System.Windows.Forms.TabPage()
        Me.tabContracts = New System.Windows.Forms.TabPage()
        Me.pnlContracts = New System.Windows.Forms.Panel()
        Me.gpbContracts = New System.Windows.Forms.GroupBox()
        Me.btnDeleteContract = New System.Windows.Forms.Button()
        Me.dgContracts = New System.Windows.Forms.DataGrid()
        Me.btnAddContract = New System.Windows.Forms.Button()
        Me.tabCharges = New System.Windows.Forms.TabPage()
        Me.grbCharges = New System.Windows.Forms.GroupBox()
        Me.txtSpendLimit = New System.Windows.Forms.TextBox()
        Me.lblJobSpendLimit = New System.Windows.Forms.Label()
        Me.txtMainContractorDiscount = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chbAcceptChargeChanges = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRatesMarkup = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMileageRate = New System.Windows.Forms.TextBox()
        Me.txtPartsMarkup = New System.Windows.Forms.TextBox()
        Me.pnlCharges = New System.Windows.Forms.Panel()
        Me.tabDocuments = New System.Windows.Forms.TabPage()
        Me.pnlDocuments = New System.Windows.Forms.Panel()
        Me.tabQuotes = New System.Windows.Forms.TabPage()
        Me.pnlQuotes = New System.Windows.Forms.Panel()
        Me.tabPriority = New System.Windows.Forms.TabPage()
        Me.dgvPriority = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dgRequirements = New System.Windows.Forms.DataGrid()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tabParts = New System.Windows.Forms.TabPage()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtPartSearch = New System.Windows.Forms.TextBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgvParts = New System.Windows.Forms.DataGridView()
        Me.tabServiceDates = New System.Windows.Forms.TabPage()
        Me.tabCreation = New System.Windows.Forms.TabPage()
        Me.btnEngDelete = New System.Windows.Forms.Button()
        Me.btnEngAdd = New System.Windows.Forms.Button()
        Me.dgRaiseEng = New System.Windows.Forms.DataGridView()
        Me.tabAuthority = New System.Windows.Forms.TabPage()
        Me.grpAudit = New System.Windows.Forms.GroupBox()
        Me.dgAuthorityAudit = New System.Windows.Forms.DataGrid()
        Me.gpCustAuth = New System.Windows.Forms.GroupBox()
        Me.btnSaveAuth = New System.Windows.Forms.Button()
        Me.txtCustAuthority = New System.Windows.Forms.TextBox()
        Me.tabAlerts = New System.Windows.Forms.TabPage()
        Me.grpCustomerAlerts = New System.Windows.Forms.GroupBox()
        Me.grpSite = New System.Windows.Forms.GroupBox()
        Me.btnAddCustomerAlert = New System.Windows.Forms.Button()
        Me.btnDeleteCustomerAlert = New System.Windows.Forms.Button()
        Me.txtCustomerAlertEmailAddress = New System.Windows.Forms.TextBox()
        Me.lblEmailAddressMsg = New System.Windows.Forms.Label()
        Me.btnSaveCustomerAlert = New System.Windows.Forms.Button()
        Me.cboAlertType = New System.Windows.Forms.ComboBox()
        Me.lblCustomerAlertEmailAddress = New System.Windows.Forms.Label()
        Me.lblAlertType = New System.Windows.Forms.Label()
        Me.dgCustomerAlerts = New System.Windows.Forms.DataGrid()
        Me.cmnuContractOptions = New System.Windows.Forms.ContextMenu()
        Me.mnuContractOpt1 = New System.Windows.Forms.MenuItem()
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlServiceProcess = New System.Windows.Forms.Panel()
        Me.grpCustomer.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tabMainDetails.SuspendLayout()
        Me.tabContracts.SuspendLayout()
        Me.pnlContracts.SuspendLayout()
        Me.gpbContracts.SuspendLayout()
        CType(Me.dgContracts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabCharges.SuspendLayout()
        Me.grbCharges.SuspendLayout()
        Me.tabDocuments.SuspendLayout()
        Me.tabQuotes.SuspendLayout()
        Me.tabPriority.SuspendLayout()
        CType(Me.dgvPriority, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgRequirements, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabParts.SuspendLayout()
        CType(Me.dgvParts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabServiceDates.SuspendLayout()
        Me.tabCreation.SuspendLayout()
        CType(Me.dgRaiseEng, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAuthority.SuspendLayout()
        Me.grpAudit.SuspendLayout()
        CType(Me.dgAuthorityAudit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpCustAuth.SuspendLayout()
        Me.tabAlerts.SuspendLayout()
        Me.grpCustomerAlerts.SuspendLayout()
        Me.grpSite.SuspendLayout()
        CType(Me.dgCustomerAlerts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpCustomer
        '
        Me.grpCustomer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCustomer.Controls.Add(Me.chkIsPFH)
        Me.grpCustomer.Controls.Add(Me.cbIsOutOfScope)
        Me.grpCustomer.Controls.Add(Me.btnExportSites)
        Me.grpCustomer.Controls.Add(Me.chkMOTService)
        Me.grpCustomer.Controls.Add(Me.txtAlertEmail)
        Me.grpCustomer.Controls.Add(Me.Label13)
        Me.grpCustomer.Controls.Add(Me.txtServWinter)
        Me.grpCustomer.Controls.Add(Me.txtServSummer)
        Me.grpCustomer.Controls.Add(Me.Label12)
        Me.grpCustomer.Controls.Add(Me.chkSuperBooking)
        Me.grpCustomer.Controls.Add(Me.cboTerms)
        Me.grpCustomer.Controls.Add(Me.Label9)
        Me.grpCustomer.Controls.Add(Me.cboDepartment)
        Me.grpCustomer.Controls.Add(Me.Label8)
        Me.grpCustomer.Controls.Add(Me.txtNominal)
        Me.grpCustomer.Controls.Add(Me.Label7)
        Me.grpCustomer.Controls.Add(Me.chkJobPriorityRequired)
        Me.grpCustomer.Controls.Add(Me.chkPONumReq)
        Me.grpCustomer.Controls.Add(Me.btnSelectLogoImage)
        Me.grpCustomer.Controls.Add(Me.picLogo)
        Me.grpCustomer.Controls.Add(Me.Label6)
        Me.grpCustomer.Controls.Add(Me.cboType)
        Me.grpCustomer.Controls.Add(Me.Label2)
        Me.grpCustomer.Controls.Add(Me.txtName)
        Me.grpCustomer.Controls.Add(Me.lblName)
        Me.grpCustomer.Controls.Add(Me.cboRegionID)
        Me.grpCustomer.Controls.Add(Me.lblRegionID)
        Me.grpCustomer.Controls.Add(Me.txtNotes)
        Me.grpCustomer.Controls.Add(Me.lblNotes)
        Me.grpCustomer.Controls.Add(Me.txtAccountNumber)
        Me.grpCustomer.Controls.Add(Me.lblAccountNumber)
        Me.grpCustomer.Controls.Add(Me.cboStatus)
        Me.grpCustomer.Controls.Add(Me.lblStatus)
        Me.grpCustomer.Location = New System.Drawing.Point(9, 8)
        Me.grpCustomer.Name = "grpCustomer"
        Me.grpCustomer.Size = New System.Drawing.Size(629, 558)
        Me.grpCustomer.TabIndex = 0
        Me.grpCustomer.TabStop = False
        Me.grpCustomer.Text = "Details"
        '
        'chkIsPFH
        '
        Me.chkIsPFH.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIsPFH.AutoSize = True
        Me.chkIsPFH.Location = New System.Drawing.Point(555, 353)
        Me.chkIsPFH.Name = "chkIsPFH"
        Me.chkIsPFH.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkIsPFH.Size = New System.Drawing.Size(62, 17)
        Me.chkIsPFH.TabIndex = 58
        Me.chkIsPFH.Text = "Is PFH"
        Me.chkIsPFH.UseVisualStyleBackColor = True
        '
        'cbIsOutOfScope
        '
        Me.cbIsOutOfScope.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbIsOutOfScope.AutoSize = True
        Me.cbIsOutOfScope.Location = New System.Drawing.Point(516, 376)
        Me.cbIsOutOfScope.Name = "cbIsOutOfScope"
        Me.cbIsOutOfScope.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbIsOutOfScope.Size = New System.Drawing.Size(102, 17)
        Me.cbIsOutOfScope.TabIndex = 57
        Me.cbIsOutOfScope.Text = "Out Of Scope"
        Me.cbIsOutOfScope.UseVisualStyleBackColor = True
        '
        'btnExportSites
        '
        Me.btnExportSites.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExportSites.Location = New System.Drawing.Point(6, 527)
        Me.btnExportSites.Name = "btnExportSites"
        Me.btnExportSites.Size = New System.Drawing.Size(103, 25)
        Me.btnExportSites.TabIndex = 56
        Me.btnExportSites.Text = "Export Sites"
        '
        'chkMOTService
        '
        Me.chkMOTService.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkMOTService.AutoSize = True
        Me.chkMOTService.Location = New System.Drawing.Point(479, 398)
        Me.chkMOTService.Name = "chkMOTService"
        Me.chkMOTService.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkMOTService.Size = New System.Drawing.Size(139, 17)
        Me.chkMOTService.TabIndex = 55
        Me.chkMOTService.Text = "M.O.T Style Service"
        Me.chkMOTService.UseVisualStyleBackColor = True
        '
        'txtAlertEmail
        '
        Me.txtAlertEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAlertEmail.Location = New System.Drawing.Point(120, 261)
        Me.txtAlertEmail.MaxLength = 255
        Me.txtAlertEmail.Name = "txtAlertEmail"
        Me.txtAlertEmail.Size = New System.Drawing.Size(498, 21)
        Me.txtAlertEmail.TabIndex = 54
        Me.txtAlertEmail.Tag = "Customer.Name"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 264)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 20)
        Me.Label13.TabIndex = 53
        Me.Label13.Text = "Alert Email"
        '
        'txtServWinter
        '
        Me.txtServWinter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtServWinter.Location = New System.Drawing.Point(540, 520)
        Me.txtServWinter.MaxLength = 50
        Me.txtServWinter.Name = "txtServWinter"
        Me.txtServWinter.Size = New System.Drawing.Size(77, 21)
        Me.txtServWinter.TabIndex = 52
        Me.txtServWinter.Tag = " "
        '
        'txtServSummer
        '
        Me.txtServSummer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtServSummer.Location = New System.Drawing.Point(415, 520)
        Me.txtServSummer.MaxLength = 50
        Me.txtServSummer.Name = "txtServSummer"
        Me.txtServSummer.Size = New System.Drawing.Size(77, 21)
        Me.txtServSummer.TabIndex = 51
        Me.txtServSummer.Tag = " "
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.Location = New System.Drawing.Point(270, 514)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(113, 27)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "Summer/Winter Servicing P/Month"
        '
        'chkSuperBooking
        '
        Me.chkSuperBooking.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSuperBooking.AutoSize = True
        Me.chkSuperBooking.Location = New System.Drawing.Point(444, 464)
        Me.chkSuperBooking.Name = "chkSuperBooking"
        Me.chkSuperBooking.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkSuperBooking.Size = New System.Drawing.Size(174, 17)
        Me.chkSuperBooking.TabIndex = 49
        Me.chkSuperBooking.Text = "Coordinator Booking Only"
        Me.chkSuperBooking.UseVisualStyleBackColor = True
        '
        'cboTerms
        '
        Me.cboTerms.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTerms.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTerms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTerms.Location = New System.Drawing.Point(120, 227)
        Me.cboTerms.Name = "cboTerms"
        Me.cboTerms.Size = New System.Drawing.Size(498, 21)
        Me.cboTerms.TabIndex = 48
        Me.cboTerms.Tag = "Customer.Status"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 226)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 20)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Terms"
        '
        'cboDepartment
        '
        Me.cboDepartment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDepartment.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartment.Location = New System.Drawing.Point(415, 488)
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(203, 21)
        Me.cboDepartment.TabIndex = 46
        Me.cboDepartment.Tag = "Customer.TypeID"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.Location = New System.Drawing.Point(270, 491)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(139, 23)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Override Department"
        '
        'txtNominal
        '
        Me.txtNominal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNominal.Location = New System.Drawing.Point(120, 193)
        Me.txtNominal.MaxLength = 50
        Me.txtNominal.Name = "txtNominal"
        Me.txtNominal.Size = New System.Drawing.Size(498, 21)
        Me.txtNominal.TabIndex = 11
        Me.txtNominal.Tag = " "
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 196)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 20)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Nominal Code"
        '
        'chkJobPriorityRequired
        '
        Me.chkJobPriorityRequired.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkJobPriorityRequired.AutoSize = True
        Me.chkJobPriorityRequired.Location = New System.Drawing.Point(473, 442)
        Me.chkJobPriorityRequired.Name = "chkJobPriorityRequired"
        Me.chkJobPriorityRequired.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkJobPriorityRequired.Size = New System.Drawing.Size(145, 17)
        Me.chkJobPriorityRequired.TabIndex = 17
        Me.chkJobPriorityRequired.Text = "Job Priority Required"
        Me.chkJobPriorityRequired.UseVisualStyleBackColor = True
        '
        'chkPONumReq
        '
        Me.chkPONumReq.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkPONumReq.AutoSize = True
        Me.chkPONumReq.Location = New System.Drawing.Point(472, 420)
        Me.chkPONumReq.Name = "chkPONumReq"
        Me.chkPONumReq.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkPONumReq.Size = New System.Drawing.Size(146, 17)
        Me.chkPONumReq.TabIndex = 16
        Me.chkPONumReq.Text = "PO Number Required"
        Me.chkPONumReq.UseVisualStyleBackColor = True
        '
        'btnSelectLogoImage
        '
        Me.btnSelectLogoImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectLogoImage.Location = New System.Drawing.Point(263, 416)
        Me.btnSelectLogoImage.Name = "btnSelectLogoImage"
        Me.btnSelectLogoImage.Size = New System.Drawing.Size(31, 23)
        Me.btnSelectLogoImage.TabIndex = 15
        Me.btnSelectLogoImage.Text = "..."
        Me.btnSelectLogoImage.UseVisualStyleBackColor = True
        '
        'picLogo
        '
        Me.picLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picLogo.BackColor = System.Drawing.Color.White
        Me.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picLogo.Location = New System.Drawing.Point(120, 417)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(135, 135)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLogo.TabIndex = 44
        Me.picLogo.TabStop = False
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.Location = New System.Drawing.Point(8, 423)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 20)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Logo"
        '
        'cboType
        '
        Me.cboType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Location = New System.Drawing.Point(120, 57)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(498, 21)
        Me.cboType.TabIndex = 3
        Me.cboType.Tag = "Customer.TypeID"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Type"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(120, 23)
        Me.txtName.MaxLength = 255
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(498, 21)
        Me.txtName.TabIndex = 1
        Me.txtName.Tag = "Customer.Name"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(8, 26)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(53, 20)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name"
        '
        'cboRegionID
        '
        Me.cboRegionID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRegionID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRegionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegionID.Location = New System.Drawing.Point(120, 91)
        Me.cboRegionID.Name = "cboRegionID"
        Me.cboRegionID.Size = New System.Drawing.Size(498, 21)
        Me.cboRegionID.TabIndex = 5
        Me.cboRegionID.Tag = "Customer.RegionID"
        '
        'lblRegionID
        '
        Me.lblRegionID.Location = New System.Drawing.Point(8, 94)
        Me.lblRegionID.Name = "lblRegionID"
        Me.lblRegionID.Size = New System.Drawing.Size(55, 20)
        Me.lblRegionID.TabIndex = 4
        Me.lblRegionID.Text = "Region "
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(120, 295)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(497, 50)
        Me.txtNotes.TabIndex = 13
        Me.txtNotes.Tag = "Customer.Notes"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(8, 298)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(62, 20)
        Me.lblNotes.TabIndex = 12
        Me.lblNotes.Text = "Notes"
        '
        'txtAccountNumber
        '
        Me.txtAccountNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAccountNumber.Location = New System.Drawing.Point(120, 125)
        Me.txtAccountNumber.MaxLength = 50
        Me.txtAccountNumber.Name = "txtAccountNumber"
        Me.txtAccountNumber.Size = New System.Drawing.Size(498, 21)
        Me.txtAccountNumber.TabIndex = 7
        Me.txtAccountNumber.Tag = "Customer.AccountNumber"
        '
        'lblAccountNumber
        '
        Me.lblAccountNumber.Location = New System.Drawing.Point(8, 128)
        Me.lblAccountNumber.Name = "lblAccountNumber"
        Me.lblAccountNumber.Size = New System.Drawing.Size(103, 20)
        Me.lblAccountNumber.TabIndex = 6
        Me.lblAccountNumber.Text = "Account Number"
        '
        'cboStatus
        '
        Me.cboStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Location = New System.Drawing.Point(120, 159)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(498, 21)
        Me.cboStatus.TabIndex = 9
        Me.cboStatus.Tag = "Customer.Status"
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(8, 162)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(65, 20)
        Me.lblStatus.TabIndex = 8
        Me.lblStatus.Text = "Status"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabMainDetails)
        Me.TabControl1.Controls.Add(Me.tabContracts)
        Me.TabControl1.Controls.Add(Me.tabCharges)
        Me.TabControl1.Controls.Add(Me.tabDocuments)
        Me.TabControl1.Controls.Add(Me.tabQuotes)
        Me.TabControl1.Controls.Add(Me.tabPriority)
        Me.TabControl1.Controls.Add(Me.tabParts)
        Me.TabControl1.Controls.Add(Me.tabServiceDates)
        Me.TabControl1.Controls.Add(Me.tabCreation)
        Me.TabControl1.Controls.Add(Me.tabAuthority)
        Me.TabControl1.Controls.Add(Me.tabAlerts)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(653, 600)
        Me.TabControl1.TabIndex = 0
        '
        'tabMainDetails
        '
        Me.tabMainDetails.Controls.Add(Me.grpCustomer)
        Me.tabMainDetails.Location = New System.Drawing.Point(4, 22)
        Me.tabMainDetails.Name = "tabMainDetails"
        Me.tabMainDetails.Size = New System.Drawing.Size(645, 574)
        Me.tabMainDetails.TabIndex = 0
        Me.tabMainDetails.Text = "Main Details"
        '
        'tabContracts
        '
        Me.tabContracts.Controls.Add(Me.pnlContracts)
        Me.tabContracts.Location = New System.Drawing.Point(4, 22)
        Me.tabContracts.Name = "tabContracts"
        Me.tabContracts.Size = New System.Drawing.Size(645, 574)
        Me.tabContracts.TabIndex = 4
        Me.tabContracts.Text = "Contracts"
        '
        'pnlContracts
        '
        Me.pnlContracts.Controls.Add(Me.gpbContracts)
        Me.pnlContracts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContracts.Location = New System.Drawing.Point(0, 0)
        Me.pnlContracts.Name = "pnlContracts"
        Me.pnlContracts.Size = New System.Drawing.Size(645, 574)
        Me.pnlContracts.TabIndex = 1
        '
        'gpbContracts
        '
        Me.gpbContracts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbContracts.Controls.Add(Me.btnDeleteContract)
        Me.gpbContracts.Controls.Add(Me.dgContracts)
        Me.gpbContracts.Controls.Add(Me.btnAddContract)
        Me.gpbContracts.Location = New System.Drawing.Point(8, 8)
        Me.gpbContracts.Name = "gpbContracts"
        Me.gpbContracts.Size = New System.Drawing.Size(632, 555)
        Me.gpbContracts.TabIndex = 0
        Me.gpbContracts.TabStop = False
        Me.gpbContracts.Text = "Contract - Double click to view"
        '
        'btnDeleteContract
        '
        Me.btnDeleteContract.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteContract.Location = New System.Drawing.Point(549, 523)
        Me.btnDeleteContract.Name = "btnDeleteContract"
        Me.btnDeleteContract.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteContract.TabIndex = 2
        Me.btnDeleteContract.Text = "Delete"
        '
        'dgContracts
        '
        Me.dgContracts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgContracts.DataMember = ""
        Me.dgContracts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgContracts.Location = New System.Drawing.Point(8, 16)
        Me.dgContracts.Name = "dgContracts"
        Me.dgContracts.Size = New System.Drawing.Size(616, 499)
        Me.dgContracts.TabIndex = 1
        '
        'btnAddContract
        '
        Me.btnAddContract.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddContract.Location = New System.Drawing.Point(8, 523)
        Me.btnAddContract.Name = "btnAddContract"
        Me.btnAddContract.Size = New System.Drawing.Size(75, 23)
        Me.btnAddContract.TabIndex = 0
        Me.btnAddContract.Text = "Add"
        Me.btnAddContract.UseVisualStyleBackColor = True
        '
        'tabCharges
        '
        Me.tabCharges.Controls.Add(Me.grbCharges)
        Me.tabCharges.Location = New System.Drawing.Point(4, 22)
        Me.tabCharges.Name = "tabCharges"
        Me.tabCharges.Size = New System.Drawing.Size(645, 574)
        Me.tabCharges.TabIndex = 7
        Me.tabCharges.Text = "Charges"
        '
        'grbCharges
        '
        Me.grbCharges.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbCharges.Controls.Add(Me.txtSpendLimit)
        Me.grbCharges.Controls.Add(Me.lblJobSpendLimit)
        Me.grbCharges.Controls.Add(Me.txtMainContractorDiscount)
        Me.grbCharges.Controls.Add(Me.Label5)
        Me.grbCharges.Controls.Add(Me.chbAcceptChargeChanges)
        Me.grbCharges.Controls.Add(Me.Label3)
        Me.grbCharges.Controls.Add(Me.txtRatesMarkup)
        Me.grbCharges.Controls.Add(Me.Label4)
        Me.grbCharges.Controls.Add(Me.Label1)
        Me.grbCharges.Controls.Add(Me.txtMileageRate)
        Me.grbCharges.Controls.Add(Me.txtPartsMarkup)
        Me.grbCharges.Controls.Add(Me.pnlCharges)
        Me.grbCharges.Location = New System.Drawing.Point(8, 0)
        Me.grbCharges.Name = "grbCharges"
        Me.grbCharges.Size = New System.Drawing.Size(633, 571)
        Me.grbCharges.TabIndex = 0
        Me.grbCharges.TabStop = False
        Me.grbCharges.Text = "Charges"
        '
        'txtSpendLimit
        '
        Me.txtSpendLimit.Location = New System.Drawing.Point(122, 70)
        Me.txtSpendLimit.Name = "txtSpendLimit"
        Me.txtSpendLimit.Size = New System.Drawing.Size(64, 21)
        Me.txtSpendLimit.TabIndex = 78
        '
        'lblJobSpendLimit
        '
        Me.lblJobSpendLimit.AutoSize = True
        Me.lblJobSpendLimit.Location = New System.Drawing.Point(8, 73)
        Me.lblJobSpendLimit.Name = "lblJobSpendLimit"
        Me.lblJobSpendLimit.Size = New System.Drawing.Size(108, 13)
        Me.lblJobSpendLimit.TabIndex = 77
        Me.lblJobSpendLimit.Text = "Job Spend Limit £"
        '
        'txtMainContractorDiscount
        '
        Me.txtMainContractorDiscount.Location = New System.Drawing.Point(461, 72)
        Me.txtMainContractorDiscount.Name = "txtMainContractorDiscount"
        Me.txtMainContractorDiscount.Size = New System.Drawing.Size(64, 21)
        Me.txtMainContractorDiscount.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(278, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(176, 21)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Main Contractor Discount %"
        '
        'chbAcceptChargeChanges
        '
        Me.chbAcceptChargeChanges.BackColor = System.Drawing.SystemColors.Info
        Me.chbAcceptChargeChanges.Location = New System.Drawing.Point(8, 16)
        Me.chbAcceptChargeChanges.Name = "chbAcceptChargeChanges"
        Me.chbAcceptChargeChanges.Size = New System.Drawing.Size(480, 24)
        Me.chbAcceptChargeChanges.TabIndex = 0
        Me.chbAcceptChargeChanges.Text = "Always accept changes to default charges made at system level"
        Me.chbAcceptChargeChanges.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(368, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 21)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Rates Markup"
        '
        'txtRatesMarkup
        '
        Me.txtRatesMarkup.Location = New System.Drawing.Point(461, 48)
        Me.txtRatesMarkup.Name = "txtRatesMarkup"
        Me.txtRatesMarkup.Size = New System.Drawing.Size(64, 21)
        Me.txtRatesMarkup.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 21)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Labour Markup"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(210, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 21)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Parts Markup"
        '
        'txtMileageRate
        '
        Me.txtMileageRate.Location = New System.Drawing.Point(122, 48)
        Me.txtMileageRate.Name = "txtMileageRate"
        Me.txtMileageRate.Size = New System.Drawing.Size(64, 21)
        Me.txtMileageRate.TabIndex = 2
        '
        'txtPartsMarkup
        '
        Me.txtPartsMarkup.Location = New System.Drawing.Point(301, 48)
        Me.txtPartsMarkup.Name = "txtPartsMarkup"
        Me.txtPartsMarkup.Size = New System.Drawing.Size(62, 21)
        Me.txtPartsMarkup.TabIndex = 4
        '
        'pnlCharges
        '
        Me.pnlCharges.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCharges.Location = New System.Drawing.Point(8, 97)
        Me.pnlCharges.Name = "pnlCharges"
        Me.pnlCharges.Size = New System.Drawing.Size(617, 466)
        Me.pnlCharges.TabIndex = 9
        '
        'tabDocuments
        '
        Me.tabDocuments.Controls.Add(Me.pnlDocuments)
        Me.tabDocuments.Location = New System.Drawing.Point(4, 22)
        Me.tabDocuments.Name = "tabDocuments"
        Me.tabDocuments.Size = New System.Drawing.Size(645, 574)
        Me.tabDocuments.TabIndex = 2
        Me.tabDocuments.Text = "Documents"
        '
        'pnlDocuments
        '
        Me.pnlDocuments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDocuments.Location = New System.Drawing.Point(0, 0)
        Me.pnlDocuments.Name = "pnlDocuments"
        Me.pnlDocuments.Size = New System.Drawing.Size(645, 574)
        Me.pnlDocuments.TabIndex = 1
        '
        'tabQuotes
        '
        Me.tabQuotes.Controls.Add(Me.pnlQuotes)
        Me.tabQuotes.Location = New System.Drawing.Point(4, 22)
        Me.tabQuotes.Name = "tabQuotes"
        Me.tabQuotes.Size = New System.Drawing.Size(645, 574)
        Me.tabQuotes.TabIndex = 5
        Me.tabQuotes.Text = "Quotes"
        '
        'pnlQuotes
        '
        Me.pnlQuotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlQuotes.Location = New System.Drawing.Point(0, 0)
        Me.pnlQuotes.Name = "pnlQuotes"
        Me.pnlQuotes.Size = New System.Drawing.Size(645, 574)
        Me.pnlQuotes.TabIndex = 1
        '
        'tabPriority
        '
        Me.tabPriority.Controls.Add(Me.dgvPriority)
        Me.tabPriority.Controls.Add(Me.Label11)
        Me.tabPriority.Controls.Add(Me.dgRequirements)
        Me.tabPriority.Controls.Add(Me.Label10)
        Me.tabPriority.Location = New System.Drawing.Point(4, 22)
        Me.tabPriority.Name = "tabPriority"
        Me.tabPriority.Size = New System.Drawing.Size(645, 574)
        Me.tabPriority.TabIndex = 8
        Me.tabPriority.Text = "Priorities / Requirements"
        Me.tabPriority.UseVisualStyleBackColor = True
        '
        'dgvPriority
        '
        Me.dgvPriority.AllowUserToAddRows = False
        Me.dgvPriority.AllowUserToDeleteRows = False
        Me.dgvPriority.AllowUserToResizeColumns = False
        Me.dgvPriority.AllowUserToResizeRows = False
        Me.dgvPriority.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPriority.Location = New System.Drawing.Point(37, 70)
        Me.dgvPriority.MultiSelect = False
        Me.dgvPriority.Name = "dgvPriority"
        Me.dgvPriority.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPriority.Size = New System.Drawing.Size(456, 170)
        Me.dgvPriority.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(34, 294)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 20)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Requirements"
        '
        'dgRequirements
        '
        Me.dgRequirements.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgRequirements.DataMember = ""
        Me.dgRequirements.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgRequirements.Location = New System.Drawing.Point(37, 317)
        Me.dgRequirements.Name = "dgRequirements"
        Me.dgRequirements.Size = New System.Drawing.Size(592, 196)
        Me.dgRequirements.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(34, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 20)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Priorities"
        '
        'tabParts
        '
        Me.tabParts.Controls.Add(Me.Label14)
        Me.tabParts.Controls.Add(Me.txtPartSearch)
        Me.tabParts.Controls.Add(Me.btnDelete)
        Me.tabParts.Controls.Add(Me.btnAdd)
        Me.tabParts.Controls.Add(Me.dgvParts)
        Me.tabParts.Location = New System.Drawing.Point(4, 22)
        Me.tabParts.Name = "tabParts"
        Me.tabParts.Size = New System.Drawing.Size(645, 574)
        Me.tabParts.TabIndex = 9
        Me.tabParts.Text = "Associated Supplier Parts"
        Me.tabParts.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 34)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Search"
        '
        'txtPartSearch
        '
        Me.txtPartSearch.Location = New System.Drawing.Point(82, 31)
        Me.txtPartSearch.Name = "txtPartSearch"
        Me.txtPartSearch.Size = New System.Drawing.Size(560, 21)
        Me.txtPartSearch.TabIndex = 3
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(58, 408)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(61, 23)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(532, 406)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(65, 25)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'dgvParts
        '
        Me.dgvParts.AllowUserToAddRows = False
        Me.dgvParts.AllowUserToDeleteRows = False
        Me.dgvParts.AllowUserToOrderColumns = True
        Me.dgvParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvParts.Location = New System.Drawing.Point(3, 62)
        Me.dgvParts.Name = "dgvParts"
        Me.dgvParts.ReadOnly = True
        Me.dgvParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvParts.ShowCellErrors = False
        Me.dgvParts.Size = New System.Drawing.Size(639, 340)
        Me.dgvParts.TabIndex = 0
        '
        'tabServiceDates
        '
        Me.tabServiceDates.BackColor = System.Drawing.SystemColors.Control
        Me.tabServiceDates.Controls.Add(Me.pnlServiceProcess)
        Me.tabServiceDates.Location = New System.Drawing.Point(4, 22)
        Me.tabServiceDates.Name = "tabServiceDates"
        Me.tabServiceDates.Size = New System.Drawing.Size(645, 574)
        Me.tabServiceDates.TabIndex = 10
        Me.tabServiceDates.Text = "Service Dates"
        '
        'tabCreation
        '
        Me.tabCreation.Controls.Add(Me.btnEngDelete)
        Me.tabCreation.Controls.Add(Me.btnEngAdd)
        Me.tabCreation.Controls.Add(Me.dgRaiseEng)
        Me.tabCreation.Location = New System.Drawing.Point(4, 22)
        Me.tabCreation.Name = "tabCreation"
        Me.tabCreation.Size = New System.Drawing.Size(645, 574)
        Me.tabCreation.TabIndex = 10
        Me.tabCreation.Text = "Engineer Job Creation"
        Me.tabCreation.UseVisualStyleBackColor = True
        '
        'btnEngDelete
        '
        Me.btnEngDelete.Location = New System.Drawing.Point(58, 429)
        Me.btnEngDelete.Name = "btnEngDelete"
        Me.btnEngDelete.Size = New System.Drawing.Size(61, 23)
        Me.btnEngDelete.TabIndex = 5
        Me.btnEngDelete.Text = "Delete"
        Me.btnEngDelete.UseVisualStyleBackColor = True
        '
        'btnEngAdd
        '
        Me.btnEngAdd.Location = New System.Drawing.Point(384, 429)
        Me.btnEngAdd.Name = "btnEngAdd"
        Me.btnEngAdd.Size = New System.Drawing.Size(65, 25)
        Me.btnEngAdd.TabIndex = 4
        Me.btnEngAdd.Text = "Add"
        Me.btnEngAdd.UseVisualStyleBackColor = True
        '
        'dgRaiseEng
        '
        Me.dgRaiseEng.AllowUserToAddRows = False
        Me.dgRaiseEng.AllowUserToDeleteRows = False
        Me.dgRaiseEng.AllowUserToOrderColumns = True
        Me.dgRaiseEng.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRaiseEng.Location = New System.Drawing.Point(3, 83)
        Me.dgRaiseEng.Name = "dgRaiseEng"
        Me.dgRaiseEng.ReadOnly = True
        Me.dgRaiseEng.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgRaiseEng.ShowCellErrors = False
        Me.dgRaiseEng.Size = New System.Drawing.Size(503, 340)
        Me.dgRaiseEng.TabIndex = 3
        '
        'tabAuthority
        '
        Me.tabAuthority.Controls.Add(Me.grpAudit)
        Me.tabAuthority.Controls.Add(Me.gpCustAuth)
        Me.tabAuthority.Location = New System.Drawing.Point(4, 22)
        Me.tabAuthority.Name = "tabAuthority"
        Me.tabAuthority.Size = New System.Drawing.Size(645, 574)
        Me.tabAuthority.TabIndex = 11
        Me.tabAuthority.Text = "Authority"
        Me.tabAuthority.UseVisualStyleBackColor = True
        '
        'grpAudit
        '
        Me.grpAudit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAudit.Controls.Add(Me.dgAuthorityAudit)
        Me.grpAudit.Location = New System.Drawing.Point(3, 236)
        Me.grpAudit.Name = "grpAudit"
        Me.grpAudit.Size = New System.Drawing.Size(639, 335)
        Me.grpAudit.TabIndex = 38
        Me.grpAudit.TabStop = False
        Me.grpAudit.Text = "Audit"
        '
        'dgAuthorityAudit
        '
        Me.dgAuthorityAudit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAuthorityAudit.DataMember = ""
        Me.dgAuthorityAudit.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgAuthorityAudit.Location = New System.Drawing.Point(6, 20)
        Me.dgAuthorityAudit.Name = "dgAuthorityAudit"
        Me.dgAuthorityAudit.Size = New System.Drawing.Size(627, 309)
        Me.dgAuthorityAudit.TabIndex = 1
        '
        'gpCustAuth
        '
        Me.gpCustAuth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpCustAuth.Controls.Add(Me.btnSaveAuth)
        Me.gpCustAuth.Controls.Add(Me.txtCustAuthority)
        Me.gpCustAuth.Location = New System.Drawing.Point(3, 3)
        Me.gpCustAuth.Name = "gpCustAuth"
        Me.gpCustAuth.Size = New System.Drawing.Size(639, 227)
        Me.gpCustAuth.TabIndex = 37
        Me.gpCustAuth.TabStop = False
        Me.gpCustAuth.Text = "Customer"
        '
        'btnSaveAuth
        '
        Me.btnSaveAuth.AccessibleDescription = ""
        Me.btnSaveAuth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveAuth.Location = New System.Drawing.Point(548, 191)
        Me.btnSaveAuth.Name = "btnSaveAuth"
        Me.btnSaveAuth.Size = New System.Drawing.Size(85, 23)
        Me.btnSaveAuth.TabIndex = 4
        Me.btnSaveAuth.Text = "Save"
        '
        'txtCustAuthority
        '
        Me.txtCustAuthority.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustAuthority.Location = New System.Drawing.Point(6, 20)
        Me.txtCustAuthority.Multiline = True
        Me.txtCustAuthority.Name = "txtCustAuthority"
        Me.txtCustAuthority.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCustAuthority.Size = New System.Drawing.Size(627, 156)
        Me.txtCustAuthority.TabIndex = 0
        '
        'tabAlerts
        '
        Me.tabAlerts.Controls.Add(Me.grpCustomerAlerts)
        Me.tabAlerts.Location = New System.Drawing.Point(4, 22)
        Me.tabAlerts.Name = "tabAlerts"
        Me.tabAlerts.Size = New System.Drawing.Size(645, 574)
        Me.tabAlerts.TabIndex = 12
        Me.tabAlerts.Text = "Alerts"
        Me.tabAlerts.UseVisualStyleBackColor = True
        '
        'grpCustomerAlerts
        '
        Me.grpCustomerAlerts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCustomerAlerts.Controls.Add(Me.grpSite)
        Me.grpCustomerAlerts.Controls.Add(Me.dgCustomerAlerts)
        Me.grpCustomerAlerts.Location = New System.Drawing.Point(13, 14)
        Me.grpCustomerAlerts.Margin = New System.Windows.Forms.Padding(0)
        Me.grpCustomerAlerts.Name = "grpCustomerAlerts"
        Me.grpCustomerAlerts.Padding = New System.Windows.Forms.Padding(0)
        Me.grpCustomerAlerts.Size = New System.Drawing.Size(620, 547)
        Me.grpCustomerAlerts.TabIndex = 15
        Me.grpCustomerAlerts.TabStop = False
        Me.grpCustomerAlerts.Text = "Alerts"
        '
        'grpSite
        '
        Me.grpSite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSite.Controls.Add(Me.btnAddCustomerAlert)
        Me.grpSite.Controls.Add(Me.btnDeleteCustomerAlert)
        Me.grpSite.Controls.Add(Me.txtCustomerAlertEmailAddress)
        Me.grpSite.Controls.Add(Me.lblEmailAddressMsg)
        Me.grpSite.Controls.Add(Me.btnSaveCustomerAlert)
        Me.grpSite.Controls.Add(Me.cboAlertType)
        Me.grpSite.Controls.Add(Me.lblCustomerAlertEmailAddress)
        Me.grpSite.Controls.Add(Me.lblAlertType)
        Me.grpSite.Location = New System.Drawing.Point(14, 287)
        Me.grpSite.Name = "grpSite"
        Me.grpSite.Size = New System.Drawing.Size(592, 248)
        Me.grpSite.TabIndex = 115
        Me.grpSite.TabStop = False
        Me.grpSite.Text = "Alert"
        '
        'btnAddCustomerAlert
        '
        Me.btnAddCustomerAlert.AccessibleDescription = ""
        Me.btnAddCustomerAlert.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddCustomerAlert.Location = New System.Drawing.Point(555, 18)
        Me.btnAddCustomerAlert.Name = "btnAddCustomerAlert"
        Me.btnAddCustomerAlert.Size = New System.Drawing.Size(31, 28)
        Me.btnAddCustomerAlert.TabIndex = 131
        Me.btnAddCustomerAlert.Text = "+"
        Me.tt.SetToolTip(Me.btnAddCustomerAlert, "Add new alert")
        '
        'btnDeleteCustomerAlert
        '
        Me.btnDeleteCustomerAlert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteCustomerAlert.Location = New System.Drawing.Point(9, 210)
        Me.btnDeleteCustomerAlert.Name = "btnDeleteCustomerAlert"
        Me.btnDeleteCustomerAlert.Size = New System.Drawing.Size(81, 23)
        Me.btnDeleteCustomerAlert.TabIndex = 130
        Me.btnDeleteCustomerAlert.Text = "Delete"
        Me.btnDeleteCustomerAlert.Visible = False
        '
        'txtCustomerAlertEmailAddress
        '
        Me.txtCustomerAlertEmailAddress.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomerAlertEmailAddress.Location = New System.Drawing.Point(9, 131)
        Me.txtCustomerAlertEmailAddress.Multiline = True
        Me.txtCustomerAlertEmailAddress.Name = "txtCustomerAlertEmailAddress"
        Me.txtCustomerAlertEmailAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCustomerAlertEmailAddress.Size = New System.Drawing.Size(577, 62)
        Me.txtCustomerAlertEmailAddress.TabIndex = 129
        Me.txtCustomerAlertEmailAddress.Tag = "Customer.Notes"
        '
        'lblEmailAddressMsg
        '
        Me.lblEmailAddressMsg.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmailAddressMsg.Location = New System.Drawing.Point(6, 63)
        Me.lblEmailAddressMsg.Name = "lblEmailAddressMsg"
        Me.lblEmailAddressMsg.Size = New System.Drawing.Size(566, 29)
        Me.lblEmailAddressMsg.TabIndex = 128
        Me.lblEmailAddressMsg.Text = "Please seperate each email address with a semi-colon;"
        '
        'btnSaveCustomerAlert
        '
        Me.btnSaveCustomerAlert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveCustomerAlert.Location = New System.Drawing.Point(505, 210)
        Me.btnSaveCustomerAlert.Name = "btnSaveCustomerAlert"
        Me.btnSaveCustomerAlert.Size = New System.Drawing.Size(81, 23)
        Me.btnSaveCustomerAlert.TabIndex = 127
        Me.btnSaveCustomerAlert.Text = "Save"
        '
        'cboAlertType
        '
        Me.cboAlertType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboAlertType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlertType.Location = New System.Drawing.Point(117, 20)
        Me.cboAlertType.Name = "cboAlertType"
        Me.cboAlertType.Size = New System.Drawing.Size(161, 21)
        Me.cboAlertType.TabIndex = 126
        Me.cboAlertType.Tag = ""
        '
        'lblCustomerAlertEmailAddress
        '
        Me.lblCustomerAlertEmailAddress.Location = New System.Drawing.Point(6, 105)
        Me.lblCustomerAlertEmailAddress.Name = "lblCustomerAlertEmailAddress"
        Me.lblCustomerAlertEmailAddress.Size = New System.Drawing.Size(112, 23)
        Me.lblCustomerAlertEmailAddress.TabIndex = 125
        Me.lblCustomerAlertEmailAddress.Text = "Email Address(s):"
        '
        'lblAlertType
        '
        Me.lblAlertType.Location = New System.Drawing.Point(6, 23)
        Me.lblAlertType.Name = "lblAlertType"
        Me.lblAlertType.Size = New System.Drawing.Size(80, 23)
        Me.lblAlertType.TabIndex = 123
        Me.lblAlertType.Text = "Alert Type:"
        '
        'dgCustomerAlerts
        '
        Me.dgCustomerAlerts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgCustomerAlerts.DataMember = ""
        Me.dgCustomerAlerts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgCustomerAlerts.Location = New System.Drawing.Point(14, 19)
        Me.dgCustomerAlerts.Name = "dgCustomerAlerts"
        Me.dgCustomerAlerts.Size = New System.Drawing.Size(592, 262)
        Me.dgCustomerAlerts.TabIndex = 11
        '
        'cmnuContractOptions
        '
        Me.cmnuContractOptions.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuContractOpt1})
        '
        'mnuContractOpt1
        '
        Me.mnuContractOpt1.Index = 0
        Me.mnuContractOpt1.Text = "Contract Opt. 1"
        '
        'pnlServiceProcess
        '
        Me.pnlServiceProcess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlServiceProcess.Location = New System.Drawing.Point(0, 0)
        Me.pnlServiceProcess.Name = "pnlServiceProcess"
        Me.pnlServiceProcess.Size = New System.Drawing.Size(645, 574)
        Me.pnlServiceProcess.TabIndex = 2
        '
        'UCCustomer
        '
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "UCCustomer"
        Me.Size = New System.Drawing.Size(653, 600)
        Me.grpCustomer.ResumeLayout(False)
        Me.grpCustomer.PerformLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tabMainDetails.ResumeLayout(False)
        Me.tabContracts.ResumeLayout(False)
        Me.pnlContracts.ResumeLayout(False)
        Me.gpbContracts.ResumeLayout(False)
        CType(Me.dgContracts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabCharges.ResumeLayout(False)
        Me.grbCharges.ResumeLayout(False)
        Me.grbCharges.PerformLayout()
        Me.tabDocuments.ResumeLayout(False)
        Me.tabQuotes.ResumeLayout(False)
        Me.tabPriority.ResumeLayout(False)
        CType(Me.dgvPriority, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgRequirements, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabParts.ResumeLayout(False)
        Me.tabParts.PerformLayout()
        CType(Me.dgvParts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabServiceDates.ResumeLayout(False)
        Me.tabCreation.ResumeLayout(False)
        CType(Me.dgRaiseEng, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAuthority.ResumeLayout(False)
        Me.grpAudit.ResumeLayout(False)
        CType(Me.dgAuthorityAudit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpCustAuth.ResumeLayout(False)
        Me.gpCustAuth.PerformLayout()
        Me.tabAlerts.ResumeLayout(False)
        Me.grpCustomerAlerts.ResumeLayout(False)
        Me.grpSite.ResumeLayout(False)
        Me.grpSite.PerformLayout()
        CType(Me.dgCustomerAlerts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentCustomer
        End Get
    End Property

#End Region

#Region "Properties"

    Private DocumentsControl As UCDocumentsList
    Private QuotesControl As UCQuotesList
    Private CustomerScheduleOfRateControl As UCCustomerScheduleOfRate
    Private UcServiceProcess As UCCustomerServiceProcess

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _currentCustomer As Entity.Customers.Customer

    Public Property CurrentCustomer() As Entity.Customers.Customer
        Get
            Return _currentCustomer
        End Get
        Set(ByVal Value As Entity.Customers.Customer)
            _currentCustomer = Value

            If IsRFT Then ' RFT dont want these
                TabControl1.TabPages.Remove(tabParts)
                TabControl1.TabPages.Remove(tabQuotes)
            Else
            End If

            If _currentCustomer Is Nothing Then
                _currentCustomer = New Entity.Customers.Customer
                _currentCustomer.Exists = False
                Me.chbAcceptChargeChanges.Checked = True
            End If
            If _currentCustomer.Exists Then
                Populate()
                Me.pnlDocuments.Controls.Clear()
                DocumentsControl = New UCDocumentsList(Entity.Sys.Enums.TableNames.tblCustomer, _currentCustomer.CustomerID)
                Me.pnlDocuments.Controls.Add(DocumentsControl)

                Contracts = DB.Customer.Customer_Contracts_GetAll(_currentCustomer.CustomerID)
                Me.gpbContracts.Enabled = True

                Me.pnlQuotes.Controls.Clear()
                QuotesControl = New UCQuotesList(Entity.Sys.Enums.TableNames.tblCustomer, _currentCustomer.CustomerID, 0)
                AddHandler QuotesControl.RefreshContracts, AddressOf RefreshContractList
                Me.pnlQuotes.Controls.Add(QuotesControl)

                Me.pnlCharges.Controls.Clear()
                CustomerScheduleOfRateControl = New UCCustomerScheduleOfRate(Entity.Sys.Enums.TableNames.tblCustomer, _currentCustomer.CustomerID)
                Me.pnlCharges.Controls.Add(CustomerScheduleOfRateControl)

                Me.pnlServiceProcess.Controls.Clear()
                UcServiceProcess = New UCCustomerServiceProcess(_currentCustomer.CustomerID)
                Me.pnlServiceProcess.Controls.Add(UcServiceProcess)
            Else
                Me.gpbContracts.Enabled = False
            End If
        End Set
    End Property

    Private _Data As DataView

    Public Property Data() As DataView
        Get
            Return _Data
        End Get
        Set(ByVal value As DataView)
            _Data = value
            _Data.AllowNew = False
            _Data.AllowEdit = True
            _Data.AllowDelete = False
            dgvPriority.AutoGenerateColumns = False
            dgvPriority.EditMode = DataGridViewEditMode.EditOnEnter
            Me.dgvPriority.DataSource = Data
        End Set
    End Property

    Private _oCustomerAuthority As Entity.Authority.Authority

    Public Property CustomerAuthority() As Entity.Authority.Authority
        Get
            Return _oCustomerAuthority
        End Get
        Set(value As Entity.Authority.Authority)
            _oCustomerAuthority = value
        End Set
    End Property

    Private _PartsDataView As DataView = Nothing

    Public Property PartsDataView() As DataView
        Get
            Return _PartsDataView
        End Get
        Set(ByVal Value As DataView)
            _PartsDataView = Value
            _PartsDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblWarehouse.ToString
            _PartsDataView.AllowNew = False
            _PartsDataView.AllowEdit = False
            _PartsDataView.AllowDelete = False
            Me.dgvParts.DataSource = PartsDataView
        End Set
    End Property

    Private _EngRaiseView As DataView = Nothing

    Public Property EngRaiseView() As DataView
        Get
            Return _EngRaiseView
        End Get
        Set(ByVal Value As DataView)
            _EngRaiseView = Value
            _EngRaiseView.Table.TableName = Entity.Sys.Enums.TableNames.tblWarehouse.ToString
            _EngRaiseView.AllowNew = False
            _EngRaiseView.AllowEdit = False
            _EngRaiseView.AllowDelete = False
            Me.dgRaiseEng.DataSource = EngRaiseView
        End Set
    End Property

    Private _RequirementDataView As DataView = Nothing

    Public Property RequirementDataView() As DataView
        Get
            Return _RequirementDataView
        End Get
        Set(ByVal Value As DataView)
            _RequirementDataView = Value
            _RequirementDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblWarehouse.ToString
            _RequirementDataView.AllowNew = False
            _RequirementDataView.AllowEdit = False
            _RequirementDataView.AllowDelete = False
            Me.dgRequirements.DataSource = RequirementDataView
        End Set
    End Property

    Private ReadOnly Property SelectedRequirmentDataRow() As DataRow
        Get
            If Not Me.dgRequirements.CurrentRowIndex = -1 Then
                Return RequirementDataView(Me.dgRequirements.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _dvContracts As DataView

    Public Property Contracts() As DataView
        Get
            Return _dvContracts
        End Get
        Set(ByVal value As DataView)
            _dvContracts = value
            _dvContracts.Table.TableName = Entity.Sys.Enums.TableNames.tblContract.ToString
            _dvContracts.AllowNew = False
            _dvContracts.AllowEdit = False
            _dvContracts.AllowDelete = False
            Me.dgContracts.DataSource = Contracts
        End Set
    End Property

    Private ReadOnly Property SelectedContractDataRow() As DataRow
        Get
            If Not Me.dgContracts.CurrentRowIndex = -1 Then
                Return Contracts(Me.dgContracts.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "SetUp"

    Private Sub SetupDG()

        Entity.Sys.Helper.SetUpDataGridView(Me.dgvParts)
        dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvParts.AutoGenerateColumns = False
        dgvParts.Columns.Clear()
        dgvParts.EditMode = DataGridViewEditMode.EditOnEnter

        Dim PartSupplierID As New DataGridViewTextBoxColumn
        PartSupplierID.HeaderText = ""
        PartSupplierID.DataPropertyName = "PartSupplierID"
        PartSupplierID.FillWeight = 1
        PartSupplierID.ReadOnly = True
        PartSupplierID.SortMode = DataGridViewColumnSortMode.Programmatic
        PartSupplierID.Visible = True
        dgvParts.Columns.Add(PartSupplierID)

        Dim PartName As New DataGridViewTextBoxColumn
        PartName.FillWeight = 120
        PartName.HeaderText = "Part Name"
        PartName.DataPropertyName = "PartName"
        PartName.ReadOnly = True
        PartName.Visible = True
        PartName.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvParts.Columns.Add(PartName)

        Dim PartNumber As New DataGridViewTextBoxColumn
        PartNumber.HeaderText = "Part Number"
        PartNumber.DataPropertyName = "PartNumber"
        PartNumber.FillWeight = 50
        PartNumber.ReadOnly = True
        PartNumber.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvParts.Columns.Add(PartNumber)

        Dim SPN As New DataGridViewTextBoxColumn
        SPN.HeaderText = "SPN"
        SPN.DataPropertyName = "PartCode"
        SPN.FillWeight = 40
        SPN.ReadOnly = True
        SPN.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvParts.Columns.Add(SPN)

        Dim Supplier As New DataGridViewTextBoxColumn
        Supplier.HeaderText = "Supplier Name"
        Supplier.DataPropertyName = "SupplierName"
        Supplier.FillWeight = 55
        Supplier.ReadOnly = True
        Supplier.SortMode = DataGridViewColumnSortMode.Programmatic
        Supplier.Visible = True
        dgvParts.Columns.Add(Supplier)

        dgvParts.Sort(Supplier, System.ComponentModel.ListSortDirection.Descending)
    End Sub

    Public Sub SetupPrioritiesDGV()
        Dim Include As New DataGridViewCheckBoxColumn
        Include.FillWeight = 5
        Include.HeaderText = "Tick"
        Include.DataPropertyName = "Tick"
        Include.Name = "Tick"
        Include.ReadOnly = False
        Include.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvPriority.Columns.Add(Include)

        Dim ID As New DataGridViewTextBoxColumn
        ID.HeaderText = "ManagerID"
        ID.DataPropertyName = "ManagerID"
        ID.Name = "ManagerID"
        ID.ReadOnly = True
        ID.Visible = False
        ID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvPriority.Columns.Add(ID)

        Dim InvoiceNo As New DataGridViewTextBoxColumn
        InvoiceNo.HeaderText = "Name"
        InvoiceNo.DataPropertyName = "Name"
        InvoiceNo.FillWeight = 20
        InvoiceNo.ReadOnly = True
        InvoiceNo.Visible = True
        InvoiceNo.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvPriority.Columns.Add(InvoiceNo)

        Dim Location As New DataGridViewTextBoxColumn
        Location.HeaderText = "TargetHours"
        Location.FillWeight = 15
        Location.DataPropertyName = "TargetHours"
        Location.Name = "TargetHours"
        Location.Visible = True
        Location.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvPriority.Columns.Add(Location)

        Dim Include1 As New DataGridViewCheckBoxColumn
        Include1.FillWeight = 5
        Include1.HeaderText = "Include OOH"
        Include1.DataPropertyName = "IncludeOOH"
        Include1.Name = "IncludeOOH"
        Include1.ReadOnly = False
        Include1.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvPriority.Columns.Add(Include1)

        Dim Include2 As New DataGridViewCheckBoxColumn
        Include2.FillWeight = 5
        Include2.HeaderText = "Include Weekends"
        Include2.DataPropertyName = "IncludeWeekends"
        Include2.Name = "IncludeWeekends"
        Include2.ReadOnly = False
        Include2.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvPriority.Columns.Add(Include2)

        Dim Include3 As New DataGridViewCheckBoxColumn
        Include3.FillWeight = 5
        Include3.HeaderText = "Include Bank Holidays"
        Include3.DataPropertyName = "IncludeBH"
        Include3.Name = "IncludeBH"
        Include3.ReadOnly = False
        Include3.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvPriority.Columns.Add(Include3)

    End Sub

    Public Sub SetupRaiseEngDGV()
        Entity.Sys.Helper.SetUpDataGridView(Me.dgRaiseEng)
        dgRaiseEng.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgRaiseEng.AutoGenerateColumns = False
        dgRaiseEng.Columns.Clear()

        Dim ID As New DataGridViewTextBoxColumn
        ID.HeaderText = "EngineerID"
        ID.DataPropertyName = "EngineerID"
        ID.Name = "EngineerID"
        ID.ReadOnly = True
        ID.Visible = False
        ID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgRaiseEng.Columns.Add(ID)

        Dim ID2 As New DataGridViewTextBoxColumn
        ID2.HeaderText = "RaiseJobCustomerEngineerID"
        ID2.DataPropertyName = "RaiseJobCustomerEngineerID"
        ID2.Name = "RaiseJobCustomerEngineerID"
        ID2.ReadOnly = True
        ID2.Visible = False
        ID2.SortMode = DataGridViewColumnSortMode.Programmatic
        dgRaiseEng.Columns.Add(ID2)

        Dim Location As New DataGridViewTextBoxColumn
        Location.HeaderText = "EngineerName"
        Location.FillWeight = 70
        Location.DataPropertyName = "EngineerName"
        Location.Name = "EngineerName"
        Location.Visible = True
        Location.SortMode = DataGridViewColumnSortMode.Programmatic
        dgRaiseEng.Columns.Add(Location)

        Dim Include As New DataGridViewCheckBoxColumn
        Include.FillWeight = 5
        Include.HeaderText = "Super"
        Include.DataPropertyName = "Super"
        Include.Name = "Super"
        Include.ReadOnly = False
        Include.SortMode = DataGridViewColumnSortMode.Programmatic
        dgRaiseEng.Columns.Add(Include)
    End Sub

    Public Sub SetupRequirements()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgRequirements)
        Dim tStyle As DataGridTableStyle = Me.dgRequirements.TableStyles(0)

        tStyle.GridColumnStyles.Clear()
        tStyle.ReadOnly = False
        tStyle.AllowSorting = False
        dgRequirements.ReadOnly = False
        dgRequirements.AllowSorting = False

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

        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblWarehouse.ToString
        Me.dgRequirements.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupContractsDataGrid()
        Dim tStyle As DataGridTableStyle = Me.dgContracts.TableStyles(0)
        tStyle.GridColumnStyles.Clear()

        Dim ContractType As New DataGridLabelColumn
        ContractType.Format = ""
        ContractType.FormatInfo = Nothing
        ContractType.HeaderText = "Contract Type"
        ContractType.MappingName = "Type"
        ContractType.ReadOnly = True
        ContractType.Width = 100
        ContractType.NullText = ""
        tStyle.GridColumnStyles.Add(ContractType)

        Dim ContractReference As New DataGridLabelColumn
        ContractReference.Format = ""
        ContractReference.FormatInfo = Nothing
        ContractReference.HeaderText = "Contract Reference"
        ContractReference.MappingName = "ContractReference"
        ContractReference.ReadOnly = True
        ContractReference.Width = 150
        ContractReference.NullText = ""
        tStyle.GridColumnStyles.Add(ContractReference)

        Dim ContractStatus As New DataGridLabelColumn
        ContractStatus.Format = ""
        ContractStatus.FormatInfo = Nothing
        ContractStatus.HeaderText = "Contract Status"
        ContractStatus.MappingName = "ContractStatus"
        ContractStatus.ReadOnly = True
        ContractStatus.Width = 180
        ContractStatus.NullText = ""
        tStyle.GridColumnStyles.Add(ContractStatus)

        Dim ContractStartDate As New DataGridLabelColumn
        ContractStartDate.Format = "dd/MM/yyyy"
        ContractStartDate.FormatInfo = Nothing
        ContractStartDate.HeaderText = "Start Date"
        ContractStartDate.MappingName = "ContractStartDate"
        ContractStartDate.ReadOnly = True
        ContractStartDate.Width = 100
        ContractStartDate.NullText = "N/A"
        tStyle.GridColumnStyles.Add(ContractStartDate)

        Dim ContractEndDate As New DataGridLabelColumn
        ContractEndDate.Format = "dd/MM/yyyy"
        ContractEndDate.FormatInfo = Nothing
        ContractEndDate.HeaderText = "End Date"
        ContractEndDate.MappingName = "ContractEndDate"
        ContractEndDate.ReadOnly = True
        ContractEndDate.Width = 100
        ContractEndDate.NullText = "N/A"
        tStyle.GridColumnStyles.Add(ContractEndDate)

        Dim ContractPrice As New DataGridLabelColumn
        ContractPrice.Format = "C"
        ContractPrice.FormatInfo = Nothing
        ContractPrice.HeaderText = "Contract Price"
        ContractPrice.MappingName = "ContractPrice"
        ContractPrice.ReadOnly = True
        ContractPrice.Width = 100
        ContractPrice.NullText = ""
        tStyle.GridColumnStyles.Add(ContractPrice)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblContract.ToString
        Me.dgContracts.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub UCCustomer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
        SetupContractsDataGrid()
        SetupPrioritiesDGV()
        SetupRequirements()
        SetupRaiseEngDGV()
        SetupCustomerAuthorityAuditDataGrid()
        SetupCustomerAlertsDataGrid()
    End Sub

    Private Sub btnAddContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddContract.Click
        cmnuContractOptions.Show(btnAddContract, New Point(0, -30))
    End Sub

    Private Sub mnuContractOpt1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuContractOpt1.Click
        ShowForm(GetType(FRMContractOriginal), True, New Object() {0, Entity.Sys.Helper.MakeIntegerValid(CurrentCustomer.CustomerID)})
        Contracts = DB.Customer.Customer_Contracts_GetAll(CurrentCustomer.CustomerID)
    End Sub

    Private Sub btnDeleteContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteContract.Click
        If SelectedContractDataRow Is Nothing Then
            Exit Sub
        End If

        If ShowMessage("Are you sure you want to delete this contract - any contract jobs not yet downloaded will be remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Dim deleteContract As Boolean = True

        If SelectedContractDataRow("ContractType") = Entity.Sys.Enums.QuoteType.Contract_Opt_1.ToString Then
            deleteContract = DeleteOption1()
        ElseIf SelectedContractDataRow("ContractType") = Entity.Sys.Enums.QuoteType.Contract_Opt_2.ToString Then
            deleteContract = DeleteOption2()
        ElseIf SelectedContractDataRow("ContractType") = Entity.Sys.Enums.QuoteType.Contract_Opt_3.ToString Then
            deleteContract = DeleteOption3()
        End If

        If deleteContract Then
            Contracts = DB.Customer.Customer_Contracts_GetAll(CurrentCustomer.CustomerID)
        Else
            ShowMessage("Cannot delete the contract - there are active jobs on properties", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub dgContracts_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgContracts.DoubleClick
        If SelectedContractDataRow Is Nothing Then
            Exit Sub
        End If

        If SelectedContractDataRow("ContractType") = Entity.Sys.Enums.QuoteType.Contract_Opt_1.ToString Then
            ShowForm(GetType(FRMContractOriginal), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedContractDataRow.Item("ContractID")), Entity.Sys.Helper.MakeIntegerValid(CurrentCustomer.CustomerID)})
        End If
        Contracts = DB.Customer.Customer_Contracts_GetAll(CurrentCustomer.CustomerID)
    End Sub

#End Region

#Region "Functions"

    Private Function DeleteOption1() As Boolean
        'DELETE Visit, Jobs - not sync, Job Assets, PPM Visits, Contract Site Assets, Contract Sites
        Dim sites As New DataView
        sites = DB.ContractOriginalSite.GetAll_ContractID(SelectedContractDataRow.Item("ContractID"), CurrentCustomer.CustomerID)
        Dim DeleteContract As Boolean = True

        For Each r As DataRow In sites.Table.Rows
            If DB.ContractOriginalSite.Delete(r("ContractSiteID")) > 0 Then
                DeleteContract = False
            End If
        Next r

        If DeleteContract Then
            DB.ContractOriginal.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedContractDataRow.Item("ContractID")))
        End If

        Return DeleteContract
    End Function

    Private Function DeleteOption2() As Boolean
        'DELETE Visit, Jobs - not sync, Job Assets, PPM Visits, Contract Site Assets, Contract Sites
        Dim sites As New DataView
        sites = DB.ContractAlternativeSite.GetAll_ContractID(SelectedContractDataRow.Item("ContractID"), CurrentCustomer.CustomerID)
        Dim DeleteContract As Boolean = True

        For Each r As DataRow In sites.Table.Rows
            If DB.ContractAlternativeSite.Delete(r("ContractSiteID")) > 0 Then
                DeleteContract = False
            End If
        Next r

        If DeleteContract Then
            DB.ContractAlternative.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedContractDataRow.Item("ContractID")))
        End If

        Return DeleteContract
    End Function

    Private Function DeleteOption3() As Boolean
        'DELETE Visit, Jobs - not sync, Job Assets, PPM Visits, Contract Site Assets, Contract Sites
        Dim sites As New DataView
        sites = DB.ContractOption3Site.ContractOption3Site_GetAll_ForContract(SelectedContractDataRow.Item("ContractID"), CurrentCustomer.CustomerID)
        Dim DeleteContract As Boolean = True

        For Each r As DataRow In sites.Table.Rows
            If DB.ContractOption3Site.Delete(r("ContractSiteID")) > 0 Then
                DeleteContract = False
            End If
        Next r

        If DeleteContract Then
            DB.ContractOption3.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedContractDataRow.Item("ContractID")))
        End If

        Return DeleteContract
    End Function

    Public Sub RefreshContractList()
        Contracts = DB.Customer.Customer_Contracts_GetAll(CurrentCustomer.CustomerID)
    End Sub

    Private Sub PopulateCharges()
        Dim CustomerCharges As New Entity.CustomerCharges.CustomerCharge
        CustomerCharges = DB.CustomerCharge.CustomerCharge_GetForCustomer(CurrentCustomer.CustomerID)

        If CustomerCharges IsNot Nothing Then
            Me.txtMileageRate.Text = CustomerCharges.MileageRate
            Me.txtPartsMarkup.Text = CustomerCharges.PartsMarkup
            Me.txtRatesMarkup.Text = CustomerCharges.RatesMarkup
        Else
            Dim settings As Entity.Management.Settings = DB.Manager.Get()
            Me.txtMileageRate.Text = Helper.MakeDoubleValid(settings?.MileageRate)
            Me.txtPartsMarkup.Text = Helper.MakeDoubleValid(settings?.PartsMarkup)
            Me.txtRatesMarkup.Text = Helper.MakeDoubleValid(settings?.RatesMarkup)
        End If
    End Sub

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        ControlLoading = True
        If Not ID = 0 Then
            CurrentCustomer = DB.Customer.Customer_Get(ID)
        End If
        PopulateCharges()
        If Not loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.CustomerCharges) Then
            TabControl1.TabPages.Remove(tabCharges)
        End If
        Data = DB.Customer.Priorities_Get_For_CustomerID(CurrentCustomer.CustomerID)
        RequirementDataView = DB.Customer.Requirements_Get_For_CustomerID(CurrentCustomer.CustomerID)
        PartsDataView = DB.Part.Customer_Parts_GetAll(CurrentCustomer.CustomerID)
        EngRaiseView = DB.Customer.Customer_EngineerRaise_Get(CurrentCustomer.CustomerID)
        Me.txtName.Text = CurrentCustomer.Name
        Combo.SetSelectedComboItem_By_Value(Me.cboRegionID, CurrentCustomer.RegionID)
        If Not CurrentCustomer.Exists Or Not loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Region) Then
            Me.cboRegionID.Enabled = False
        End If
        Combo.SetSelectedComboItem_By_Value(Me.cboType, CurrentCustomer.CustomerTypeID)
        If CurrentCustomer.CustomerTypeID = CInt(Entity.Sys.Enums.CustomerType.SocialHousing) Then
            Me.cboType.Enabled = loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Supervisor)
        End If
        Me.txtAlertEmail.Text = CurrentCustomer.AlertEmail
        Me.txtNotes.Text = CurrentCustomer.Notes
        Me.txtAccountNumber.Text = CurrentCustomer.AccountNumber
        Combo.SetSelectedComboItem_By_Value(Me.cboStatus, CurrentCustomer.Status)

        Dim ssm As Entity.Sys.Enums.SecuritySystemModules
        ssm = Entity.Sys.Enums.SecuritySystemModules.Finance
        If CurrentCustomer.Status = CInt(Entity.Sys.Enums.CustomerStatus.OnHold) And
            Not loggedInUser.HasAccessToModule(ssm) Then
            cboStatus.Enabled = False
        End If
        PopulateCustomerAuthority()
        PopulateCustomerAlerts()

        Me.chbAcceptChargeChanges.Checked = CurrentCustomer.AcceptChargesChanges
        Me.chkMOTService.Checked = CurrentCustomer.MOTStyleService
        Me.cbIsOutOfScope.Checked = CurrentCustomer.IsOutOfScope
        Me.txtMainContractorDiscount.Text = CurrentCustomer.MainContractorDiscount
        Me.chkPONumReq.Checked = CurrentCustomer.PoNumReqd
        Me.chkJobPriorityRequired.Checked = CurrentCustomer.JobPriorityMandatory
        Me.txtNominal.Text = CurrentCustomer.Nominal
        Combo.SetSelectedComboItem_By_Value(Me.cboDepartment, CurrentCustomer.OverrideDept.Trim())
        Combo.SetSelectedComboItem_By_Value(Me.cboTerms, CurrentCustomer.Terms)
        Me.chkSuperBooking.Checked = CurrentCustomer.SuperBook
        If Not CurrentCustomer.Logo Is Nothing Then
            Dim logoStream As New MemoryStream(CurrentCustomer.Logo)
            picLogo.Image = Image.FromStream(logoStream)
        End If
        Me.txtServSummer.Text = CurrentCustomer.SummerServ
        Me.txtServWinter.Text = CurrentCustomer.WinterServ
        Me.txtSpendLimit.Text = CurrentCustomer.JobSpendLimit
        Me.chkIsPFH.Checked = CurrentCustomer.IsPFH
        AddChangeHandlers(Me)
        ControlChanged = False
        ControlLoading = False
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            CurrentCustomer.IgnoreExceptionsOnSetMethods = True

            CurrentCustomer.SetName = Me.txtName.Text.Trim
            If Not CurrentCustomer.Exists Or loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Region) Then
                CurrentCustomer.SetRegionID = Combo.GetSelectedItemValue(Me.cboRegionID)
            End If
            CurrentCustomer.SetCustomerTypeID = Combo.GetSelectedItemValue(Me.cboType)
            CurrentCustomer.SetNotes = Me.txtNotes.Text.Trim
            CurrentCustomer.SetAccountNumber = Me.txtAccountNumber.Text.Trim
            CurrentCustomer.SetStatus = Combo.GetSelectedItemValue(Me.cboStatus)
            CurrentCustomer.SetAcceptChargesChanges = Me.chbAcceptChargeChanges.Checked
            CurrentCustomer.SetMOTStyleService = Me.chkMOTService.Checked
            CurrentCustomer.SetIsOutOfScope = Me.cbIsOutOfScope.Checked
            CurrentCustomer.SetSuperBook = Me.chkSuperBooking.Checked
            CurrentCustomer.SetAlertEmail = Me.txtAlertEmail.Text
            If Me.txtMainContractorDiscount.Text.Trim.Length = 0 Then
                CurrentCustomer.SetMainContractorDiscount = 0
            Else
                CurrentCustomer.SetMainContractorDiscount = Me.txtMainContractorDiscount.Text
            End If
            CurrentCustomer.SetPoNumReqd = Me.chkPONumReq.Checked
            CurrentCustomer.SetJobPriorityMandatory = Me.chkJobPriorityRequired.Checked
            CurrentCustomer.SetNominal = Me.txtNominal.Text

            CurrentCustomer.SetSummerServ = Me.txtServSummer.Text
            CurrentCustomer.SetWinterServ = Me.txtServWinter.Text
            CurrentCustomer.SetIsPFH = Me.chkIsPFH.Checked
            Dim department As String = Helper.MakeStringValid(Combo.GetSelectedItemValue(cboDepartment))

            If Helper.IsValidInteger(department) AndAlso Not Helper.MakeIntegerValid(department) <= 0 Then
                CurrentCustomer.SetOverrideDept = department
            ElseIf Not IsNumeric(department) Then
                CurrentCustomer.SetOverrideDept = department
            End If

            If Combo.GetSelectedItemValue(cboTerms) > 0 Then
                CurrentCustomer.SetTerms = Combo.GetSelectedItemValue(cboTerms)
            End If

            If Me.txtSpendLimit.Text.Trim.Length > 0 Then CurrentCustomer.SetJobSpendLimit = Helper.MakeDoubleValid(Me.txtSpendLimit.Text.Trim)

            Dim cV As New Entity.Customers.CustomerValidator
            cV.Validate(CurrentCustomer)

            If CurrentCustomer.Exists Then
                DB.Customer.Update(CurrentCustomer)
            Else
                CurrentCustomer = DB.Customer.Insert(CurrentCustomer)
            End If

            Dim customerCharges As Entity.CustomerCharges.CustomerCharge = DB.CustomerCharge.CustomerCharge_GetForCustomer(CurrentCustomer.CustomerID)
            If customerCharges Is Nothing Then customerCharges = New Entity.CustomerCharges.CustomerCharge
            customerCharges.SetMileageRate = Me.txtMileageRate.Text.Trim
            customerCharges.SetPartsMarkup = Me.txtPartsMarkup.Text.Trim
            customerCharges.SetRatesMarkup = Me.txtRatesMarkup.Text.Trim
            customerCharges.SetCustomerID = CurrentCustomer.CustomerID
            Dim ccV As New Entity.CustomerCharges.CustomerChargeValidator
            ccV.Validate(customerCharges)
            If customerCharges.Exists Then
                DB.CustomerCharge.Update(customerCharges)
            Else
                customerCharges = DB.CustomerCharge.Insert(customerCharges)
            End If

            CurrentCustomerID = CurrentCustomer.CustomerID
            DB.Customer.Priorities_Delete_For_Customer(CurrentCustomer.CustomerID)

            For Each dr As DataGridViewRow In dgvPriority.Rows
                If dr.Cells("Tick").Value = True Then
                    DB.Customer.Priorities_Insert_For_Customer(CurrentCustomer.CustomerID, dr.Cells("ManagerID").Value, dr.Cells("TargetHours").Value, dr.Cells("IncludeWeekends").Value, dr.Cells("IncludeBH").Value, dr.Cells("IncludeOOH").Value)
                End If

            Next

            DB.Customer.Requirements_Delete_For_Customer(CurrentCustomer.CustomerID)

            For Each dr As DataRow In RequirementDataView.Table.Rows
                If dr("Tick") = True Then
                    DB.Customer.Requirements_Insert_For_Customer(CurrentCustomer.CustomerID, dr("ManagerID"))
                End If

            Next

            RaiseEvent RecordsChanged(DB.Customer.Customer_GetAll_Light(loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Customer, True, False, "")
            RaiseEvent StateChanged(CurrentCustomer.CustomerID)
            MainForm.RefreshEntity(CurrentCustomer.CustomerID, "CustomerID")

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

    Private Sub btnSelectLogoImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectLogoImage.Click
        Try
            Dim open As New OpenFileDialog
            Dim rawImage As Image

            open.Title = "Set Image File"
            open.Filter = "Image Files|*.bmp;*.Jpg;*.Gif"

            open.FileName = ""

            If open.ShowDialog = DialogResult.Cancel Then
                Exit Sub
            End If

            rawImage = Image.FromFile(open.FileName.ToString())

            Dim scaledImage As New Bitmap(226, 226, Imaging.PixelFormat.Format24bppRgb)
            Dim gfxScaledImage As Graphics = Graphics.FromImage(scaledImage)

            If rawImage.Height > rawImage.Width Then
                'Portrait
                Dim scale As Double = rawImage.Width / rawImage.Height

                Dim width As Integer = rawImage.Width * scale
                Dim height As Integer = 226

                gfxScaledImage.Clear(Color.White)
                gfxScaledImage.DrawImage(rawImage, 113 - (width \ 2), 0, width, height)

            ElseIf rawImage.Height <= rawImage.Width Then
                'Landscape

                Dim scale As Double = rawImage.Width / rawImage.Height

                Dim width As Integer = 226
                Dim height As Integer = rawImage.Height * scale

                gfxScaledImage.Clear(Color.White)

                gfxScaledImage.DrawImage(rawImage, 0, 113 - (height \ 2), width, height)

            End If

            Dim memStreamPhoto As New MemoryStream()

            scaledImage.Save(memStreamPhoto, System.Drawing.Imaging.ImageFormat.Jpeg)

            picLogo.Image = scaledImage

            CurrentCustomer.Logo = memStreamPhoto.GetBuffer
            AnythingChanges(sender, e)
        Catch ex As Exception
            ShowMessage(ErrorMsg.ErrorOccured("Reading logo image"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

    End Sub

    Private Sub dgRequirement_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgRequirements.MouseUp
        Try
            Dim HitTestInfo As DataGrid.HitTestInfo
            HitTestInfo = dgRequirements.HitTest(e.X, e.Y)
            If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
                dgRequirements.CurrentRowIndex = HitTestInfo.Row()
            End If

            If Not HitTestInfo.Column = 0 Then
                Exit Sub
            End If
            If SelectedRequirmentDataRow Is Nothing Then
                Exit Sub
            End If

            Dim selected As Boolean = Not Entity.Sys.Helper.MakeBooleanValid(Me.dgRequirements(Me.dgRequirements.CurrentRowIndex, 0))

            Me.dgRequirements(Me.dgRequirements.CurrentRowIndex, 0) = selected
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If CurrentCustomer.CustomerID = 0 Then
            ShowMessage("You need to save the customer first!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim dialogue1 As FRMFindPart
        dialogue1 = checkIfExists(GetType(FRMFindPart).Name, True)
        If dialogue1 Is Nothing Then
            dialogue1 = Activator.CreateInstance(GetType(FRMFindPart))
        End If
        '  dialogue1.Icon = New Icon(dialogue1.GetType(), "Logo.ico")
        dialogue1.ShowInTaskbar = False
        dialogue1.TableToSearch = Entity.Sys.Enums.TableNames.tblPartSupplier
        dialogue1.ShowDialog()

        Dim datarows() As DataRow = Nothing
        If dialogue1.DialogResult = DialogResult.OK Then
            datarows = dialogue1.Datarows
        Else
            Exit Sub
        End If
        For Each dr As DataRow In datarows
            DB.Customer.Part_Insert_For_Customer(CurrentCustomer.CustomerID, dr("PartSupplierID"))
        Next

        PartsDataView = DB.Part.Customer_Parts_GetAll(CurrentCustomer.CustomerID)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If dgvParts.SelectedRows(0).Index > -1 Then

            For Each dr As DataGridViewRow In dgvParts.SelectedRows
                DB.Customer.Part_Delete_For_Customer(CurrentCustomer.CustomerID, dr.Cells(0).Value)
            Next
            PartsDataView = DB.Part.Customer_Parts_GetAll(CurrentCustomer.CustomerID)
        End If
    End Sub

    Private Sub dgRaiseEng_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgRaiseEng.CellDoubleClick
        If dgRaiseEng.SelectedRows(0).Index > -1 Then
            Using dialogue1 As New FRMEngineerRaiseJob
                Combo.SetSelectedComboItem_By_Value(dialogue1.cboEngineer, dgRaiseEng.SelectedRows(0).Cells("EngineerID").Value)
                dialogue1.chkSuper.Checked = dgRaiseEng.SelectedRows(0).Cells("Super").Value
                dialogue1.ShowDialog()
                If dialogue1.DialogResult = DialogResult.OK Then
                    DB.Customer.Customer_EngineerRaise_Update(CurrentCustomer.CustomerID, Combo.GetSelectedItemValue(dialogue1.cboEngineer), dialogue1.chkSuper.Checked, dgRaiseEng.SelectedRows(0).Cells("RaiseJobCustomerEngineerID").Value)
                End If
            End Using

            EngRaiseView = DB.Customer.Customer_EngineerRaise_Get(CurrentCustomer.CustomerID)
        End If
    End Sub

    Private Sub btnEngAdd_Click(sender As Object, e As EventArgs) Handles btnEngAdd.Click
        If CurrentCustomer.CustomerID = 0 Then
            ShowMessage("You need to save the customer first!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Using dialogue1 As New FRMEngineerRaiseJob
            dialogue1.ShowDialog()
            If dialogue1.DialogResult = DialogResult.OK Then
                DB.Customer.Customer_EngineerRaise_Insert(CurrentCustomer.CustomerID, Combo.GetSelectedItemValue(dialogue1.cboEngineer), dialogue1.chkSuper.Checked)
            End If
        End Using

        EngRaiseView = DB.Customer.Customer_EngineerRaise_Get(CurrentCustomer.CustomerID)
    End Sub

    Private Sub btnEngDelete_Click(sender As Object, e As EventArgs) Handles btnEngDelete.Click
        If dgRaiseEng.SelectedRows(0).Index > -1 Then
            For Each dr As DataGridViewRow In dgRaiseEng.SelectedRows
                DB.Customer.Customer_EngineerRaise_Delete(dgRaiseEng.SelectedRows(0).Cells("RaiseJobCustomerEngineerID").Value)
            Next

            EngRaiseView = DB.Customer.Customer_EngineerRaise_Get(CurrentCustomer.CustomerID)
        End If
    End Sub

    Public Sub SetupCustomerAuthorityAuditDataGrid()
        Dim tStyle As DataGridTableStyle = Me.dgAuthorityAudit.TableStyles(0)
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
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblAuthority.ToString
        Me.dgAuthorityAudit.TableStyles.Add(tStyle)
    End Sub

    Private _dvCustomerAuthorityAudit As DataView

    Private Property CustomerAuthorityAuditDataView() As DataView
        Get
            Return _dvCustomerAuthorityAudit
        End Get
        Set(ByVal value As DataView)
            _dvCustomerAuthorityAudit = value
            _dvCustomerAuthorityAudit.AllowNew = False
            _dvCustomerAuthorityAudit.AllowEdit = False
            _dvCustomerAuthorityAudit.AllowDelete = False
            _dvCustomerAuthorityAudit.Table.TableName = Entity.Sys.Enums.TableNames.tblAuthority.ToString
            Me.dgAuthorityAudit.DataSource = CustomerAuthorityAuditDataView
        End Set
    End Property

    Private Sub PopulateCustomerAuthority()
        Try
            CustomerAuthority = DB.Authority.Get(CurrentCustomer.CustomerID,
                                                 Entity.Authority.AuthoritySQL.GetBy.CustomerId)

            If CustomerAuthority IsNot Nothing Then
                Me.txtCustAuthority.Text = CustomerAuthority.Notes
            End If

            CustomerAuthorityAuditDataView = DB.Authority.Audit_Get(CurrentCustomer.CustomerID,
                                                                    Entity.Authority.AuthoritySQL.GetBy.CustomerId)
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSaveAuth_Click(sender As Object, e As EventArgs) Handles btnSaveAuth.Click
        If String.IsNullOrEmpty(txtCustAuthority.Text) Then Exit Sub
        If CustomerAuthority Is Nothing Then
            CustomerAuthority = New Entity.Authority.Authority
            CustomerAuthority.SetNotes = txtCustAuthority.Text
            DB.Authority.Insert_Customer(CurrentCustomer.CustomerID, CustomerAuthority)
        Else
            Dim changes As String = String.Empty
            If CustomerAuthority.Notes <> txtCustAuthority.Text Then
                changes += "Changed: " & CustomerAuthority.Notes.Replace(vbCr, " ").Replace(vbLf, " ")
            End If
            CustomerAuthority.SetNotes = txtCustAuthority.Text
            DB.Authority.Update(CustomerAuthority, changes)
        End If
        PopulateCustomerAuthority()
    End Sub

    Private Sub txtPartSearch_Change(sender As Object, e As EventArgs) Handles txtPartSearch.TextChanged
        RunFilter()
    End Sub

    Private Sub RunFilter()
        Dim whereClause As String = "0 = 0"
        If Not Me.txtPartSearch.Text.Trim.Length = 0 Then
            whereClause += " AND PartName LIKE '%" & Me.txtPartSearch.Text.Trim & "%' OR PartNumber LIKE '%" & Me.txtPartSearch.Text.Trim &
                                "%' OR PartCode LIKE '%" & Me.txtPartSearch.Text.Trim & "%'"
        End If
        PartsDataView.RowFilter = whereClause
    End Sub

    Private Sub btnExportSites_Click(sender As Object, e As EventArgs) Handles btnExportSites.Click
        Dim dvSites As DataView = DB.Customer.Customer_GetAll_Sites(Helper.MakeIntegerValid(CurrentCustomer?.CustomerID))
        If dvSites.Count > 0 Then
            Entity.Sys.ExportHelper.Export(dvSites.Table, "Sites", Entity.Sys.Enums.ExportType.XLS)
        End If
    End Sub

    Public Property CustomerAlerts As List(Of Entity.Customers.CustomerAlert)
    Public Property CustomerAlert As Entity.Customers.CustomerAlert

    Private _dvCustomerAlerts As DataView = Nothing

    Public Property DvCustomerAlerts() As DataView
        Get
            Return _dvCustomerAlerts
        End Get
        Set(ByVal value As DataView)
            _dvCustomerAlerts = value
            If _dvCustomerAlerts IsNot Nothing Then
                _dvCustomerAlerts.Table.TableName = Enums.TableNames.tblContact.ToString
                _dvCustomerAlerts.AllowNew = False
                _dvCustomerAlerts.AllowEdit = False
                _dvCustomerAlerts.AllowDelete = False
            End If
            Me.dgCustomerAlerts.DataSource = _dvCustomerAlerts
        End Set
    End Property

    Private ReadOnly Property DrSelectedCustomerAlert() As DataRow
        Get
            If dgCustomerAlerts.DataSource IsNot Nothing AndAlso Not dgCustomerAlerts.CurrentRowIndex = -1 Then
                Return DvCustomerAlerts(dgCustomerAlerts.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Sub SetupCustomerAlertsDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgCustomerAlerts)
        Dim tStyle As DataGridTableStyle = Me.dgCustomerAlerts.TableStyles(0)

        tStyle.GridColumnStyles.Clear()
        Me.dgCustomerAlerts.ReadOnly = True

        Dim alertType As New DataGridLabelColumn
        alertType.Format = ""
        alertType.FormatInfo = Nothing
        alertType.HeaderText = "Alert Type"
        alertType.MappingName = "AlertType"
        alertType.ReadOnly = True
        alertType.Width = 150
        alertType.NullText = ""
        tStyle.GridColumnStyles.Add(alertType)

        Dim emailaddress As New DataGridLabelColumn
        emailaddress.Format = ""
        emailaddress.FormatInfo = Nothing
        emailaddress.HeaderText = "Email Address(s)"
        emailaddress.MappingName = "EmailAddress"
        emailaddress.ReadOnly = True
        emailaddress.Width = 400
        emailaddress.NullText = ""
        tStyle.GridColumnStyles.Add(emailaddress)

        tStyle.ReadOnly = True
        tStyle.MappingName = Enums.TableNames.tblContact.ToString
        Me.dgCustomerAlerts.TableStyles.Add(tStyle)

        Helper.RemoveEventHandlers(Me.dgCustomerAlerts)

    End Sub

    Public Sub PopulateCustomerAlerts()
        CustomerAlerts = DB.CustomerAlert.Get_ForCustomer(CurrentCustomer?.CustomerID)
        If CustomerAlerts?.Count > 0 Then
            DvCustomerAlerts = New DataView(Helper.ToDataTable(CustomerAlerts))
        Else
            DvCustomerAlerts = Nothing
        End If
    End Sub

    Private Sub ResetCustomerAlerts()
        CustomerAlert = Nothing
        Me.btnDeleteCustomerAlert.Visible = False
        Me.cboAlertType.Enabled = True
        Me.txtCustomerAlertEmailAddress.Text = String.Empty
        Combo.SetSelectedComboItem_By_Value(cboAlertType, 0)
        PopulateCustomerAlerts()
    End Sub

    Private Sub btnSaveCustomerAlert_Click(sender As Object, e As EventArgs) Handles btnSaveCustomerAlert.Click
        If CurrentCustomer?.CustomerID > 0 Then
            Try
                If CustomerAlert?.Id > 0 Then
                    CustomerAlert.EmailAddress = txtCustomerAlertEmailAddress.Text.Trim()
                    DB.CustomerAlert.Update(CustomerAlert)
                    ResetCustomerAlerts()
                Else

                    CustomerAlert = New Entity.Customers.CustomerAlert
                    With CustomerAlert
                        .CustomerId = CurrentCustomer.CustomerID
                        .AlertTypeId = Combo.GetSelectedItemValue(cboAlertType)
                        .EmailAddress = txtCustomerAlertEmailAddress.Text.Trim()
                    End With
                    If CustomerAlerts?.Where(Function(X) X.AlertTypeId = CustomerAlert.AlertTypeId).ToList().Count > 0 Then
                        ShowMessage("Alert type already exists!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        CustomerAlert = DB.CustomerAlert.Insert(CustomerAlert)
                        ResetCustomerAlerts()
                    End If
                End If
                ShowMessage("Alert saved!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Catch ex As Exception
                ShowMessage(ex.Message & " - " & ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnAddCustomerAlert_Click(sender As Object, e As EventArgs) Handles btnAddCustomerAlert.Click
        CustomerAlert = Nothing
        ResetCustomerAlerts()
    End Sub

    Private Sub dgCustomerAlerts_Click(sender As Object, e As EventArgs) Handles dgCustomerAlerts.Click
        If DrSelectedCustomerAlert Is Nothing Then
            Exit Sub
        Else
            CustomerAlert = DB.CustomerAlert.Get(DrSelectedCustomerAlert("Id"))?.FirstOrDefault()
            If CustomerAlert?.Id > 0 Then
                btnDeleteCustomerAlert.Visible = True
                cboAlertType.Enabled = False
                Combo.SetSelectedComboItem_By_Value(cboAlertType, CustomerAlert.AlertTypeId)
                txtCustomerAlertEmailAddress.Text = CustomerAlert.EmailAddress.Trim()
            End If
        End If
    End Sub

    Private Sub btnDeleteCustomerAlert_Click(sender As Object, e As EventArgs) Handles btnDeleteCustomerAlert.Click
        If CustomerAlert?.Id > 0 Then
            DB.CustomerAlert.Delete(CustomerAlert)
            CustomerAlert = Nothing
            ResetCustomerAlerts()
            ShowMessage("Alert removed!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

End Class