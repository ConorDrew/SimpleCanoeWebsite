Imports System.IO
Imports System.Linq
Imports FSM.Entity.Sys
Imports Newtonsoft.Json.Linq

Public Class UCSite : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Combo.SetUpCombo(Me.cboDefinition, DynamicDataTables.JobDefinitions, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboRegionID, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSourceOfCustomer, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.SourceOfCustomer).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboReasonForContact, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.ReasonsForContact).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboAccomType, DB.Picklists.GetAll(Enums.PickListTypes.AccomType).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSalutation, DynamicDataTables.Salutation, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)

        dtpBuildDate.Value = SqlTypes.SqlDateTime.MinValue
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
    Friend WithEvents tcSites As System.Windows.Forms.TabControl

    Friend WithEvents tabDetails As System.Windows.Forms.TabPage
    Friend WithEvents grpSite As System.Windows.Forms.GroupBox
    Friend WithEvents chkHeadOffice As System.Windows.Forms.CheckBox
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress1 As System.Windows.Forms.Label
    Friend WithEvents txtAddress3 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress3 As System.Windows.Forms.Label
    Friend WithEvents lblCounty As System.Windows.Forms.Label
    Friend WithEvents txtPostcode As System.Windows.Forms.TextBox
    Friend WithEvents lblPostcode As System.Windows.Forms.Label
    Friend WithEvents txtFaxNum As System.Windows.Forms.TextBox
    Friend WithEvents lblFaxNum As System.Windows.Forms.Label
    Friend WithEvents tabDocuments As System.Windows.Forms.TabPage
    Friend WithEvents pnlDocuments As System.Windows.Forms.Panel
    Friend WithEvents tabContacts As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddContact As System.Windows.Forms.Button
    Friend WithEvents btnDeleteContact As System.Windows.Forms.Button
    Friend WithEvents dgContacts As System.Windows.Forms.DataGrid
    Friend WithEvents tabInvoiceAddress As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgInvoiceAddresses As System.Windows.Forms.DataGrid
    Friend WithEvents btnDeleteAddress As System.Windows.Forms.Button
    Friend WithEvents btnAddAddress As System.Windows.Forms.Button
    Friend WithEvents txtAddress5 As System.Windows.Forms.TextBox
    Friend WithEvents tabQuotes As System.Windows.Forms.TabPage
    Friend WithEvents pnlQuotes As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRatesMarkup As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMileageRate As System.Windows.Forms.TextBox
    Friend WithEvents txtPartsMarkup As System.Windows.Forms.TextBox
    Friend WithEvents gpbCharges As System.Windows.Forms.GroupBox
    Friend WithEvents tabCharges As System.Windows.Forms.TabPage
    Friend WithEvents pnlCharges As System.Windows.Forms.Panel
    Friend WithEvents chbAcceptChargeChanges As System.Windows.Forms.CheckBox
    Friend WithEvents btnEmail As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDefinition As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtJobNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgJobs As System.Windows.Forms.DataGrid
    Friend WithEvents btnAddJob As System.Windows.Forms.Button
    Friend WithEvents btnShowAllJobs As System.Windows.Forms.Button
    Friend WithEvents btnRemoveJob As System.Windows.Forms.Button
    Friend WithEvents btnFindCustomer As System.Windows.Forms.Button
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents btnDomestic As System.Windows.Forms.Button
    Friend WithEvents tabContracts As System.Windows.Forms.TabPage
    Friend WithEvents gpbContracts As System.Windows.Forms.GroupBox
    Friend WithEvents btnDeleteContract As System.Windows.Forms.Button
    Friend WithEvents dgContracts As System.Windows.Forms.DataGrid
    Friend WithEvents btnAddContract As System.Windows.Forms.Button
    Friend WithEvents btnCustomerAudit As System.Windows.Forms.Button
    Friend WithEvents btnSendEmailToSite As System.Windows.Forms.Button
    Friend WithEvents chkNoMarketing As System.Windows.Forms.CheckBox
    Friend WithEvents txtContractStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnPrintLetters As System.Windows.Forms.Button
    Friend WithEvents btnShowVisits As System.Windows.Forms.Button
    Friend WithEvents chkOnStop As System.Windows.Forms.CheckBox
    Friend WithEvents tpNotes As System.Windows.Forms.TabPage
    Friend WithEvents gpbNotes As System.Windows.Forms.GroupBox
    Friend WithEvents btnDeleteNote As System.Windows.Forms.Button
    Friend WithEvents dgNotes As System.Windows.Forms.DataGrid
    Friend WithEvents btnAddNote As System.Windows.Forms.Button
    Friend WithEvents gpbNotesDetails As System.Windows.Forms.GroupBox
    Friend WithEvents txtNoteID As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveNote As System.Windows.Forms.Button
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblContractInactive As System.Windows.Forms.Label
    Friend WithEvents chkLeaseHolder As System.Windows.Forms.CheckBox
    Friend WithEvents chkNoService As System.Windows.Forms.CheckBox
    Friend WithEvents chkSolidFuel As System.Windows.Forms.CheckBox
    Friend WithEvents chkCommercialDistrict As System.Windows.Forms.CheckBox
    Private WithEvents btnAddModifyPlan As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress2 As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents cboSalutation As System.Windows.Forms.ComboBox
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtSurname As System.Windows.Forms.TextBox
    Friend WithEvents cboRegionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblRegionID As System.Windows.Forms.Label
    Friend WithEvents txtPolicyNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTelephoneNum As System.Windows.Forms.TextBox
    Friend WithEvents lblTelephoneNum As System.Windows.Forms.Label
    Friend WithEvents txtAddress4 As System.Windows.Forms.TextBox
    Friend WithEvents lblTown As System.Windows.Forms.Label
    Friend WithEvents btnConvCust As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtAsbestos As System.Windows.Forms.TextBox
    Friend WithEvents txtAlert As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents grpSiteFuel As GroupBox
    Friend WithEvents dgSiteFuel As DataGrid
    Friend WithEvents ttSiteFuel As ToolTip
    Friend WithEvents btnMoreInfo As Button
    Friend WithEvents chkVoid As CheckBox
    Friend WithEvents txtLastServiceDate As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cmsJobs As ContextMenuStrip
    Friend WithEvents tsmiMoveJob As ToolStripMenuItem
    Friend WithEvents txtActualServiceDate As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents tabAuthority As TabPage
    Friend WithEvents gpCustAuth As GroupBox
    Friend WithEvents txtCustAuthority As TextBox
    Friend WithEvents grpAudit As GroupBox
    Friend WithEvents dgAuthorityAudit As DataGrid
    Friend WithEvents grpSiteAuth As GroupBox
    Friend WithEvents btnSaveAuth As Button
    Friend WithEvents txtSiteAuth As TextBox
    Friend WithEvents btnSiteReport As Button
    Friend WithEvents tpAdditionalDetails As TabPage
    Friend WithEvents grpAdditionalDetails As GroupBox
    Friend WithEvents lblBuildDate As Label
    Friend WithEvents txtWarrantyPeriod As TextBox
    Friend WithEvents lblWarrantyPeriod As Label
    Friend WithEvents dtpBuildDate As DateTimePicker
    Friend WithEvents txtPropertyVoidDate As TextBox
    Friend WithEvents lblPropertyVoidDate As Label
    Friend WithEvents txtSiteDefects As TextBox
    Friend WithEvents lblSiteDefects As Label
    Friend WithEvents lblHousingOfficer As Label
    Friend WithEvents txtHousingOfficer As TextBox
    Friend WithEvents txtEstateOfficer As TextBox
    Friend WithEvents lblEstateOfficer As Label
    Friend WithEvents txtHousingManager As TextBox
    Friend WithEvents lblHousingManager As Label
    Friend WithEvents dtpDefectEndDate As DateTimePicker
    Friend WithEvents lblDefectEndDate As Label
    Protected WithEvents lblAccomType As Label
    Friend WithEvents cboAccomType As ComboBox
    Friend WithEvents txtDDRef As TextBox
    Friend WithEvents lblDDRef As Label
    Friend WithEvents btnLetterReport As Button
    Friend WithEvents cboReasonForContact As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents cboSourceOfCustomer As ComboBox
    Friend WithEvents TabNewContacts As TabPage
    Friend WithEvents pnlContactsMain As FlowLayoutPanel
    Friend WithEvents lblEmailAddress As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tcSites = New System.Windows.Forms.TabControl()
        Me.tabDetails = New System.Windows.Forms.TabPage()
        Me.grpSiteFuel = New System.Windows.Forms.GroupBox()
        Me.btnMoreInfo = New System.Windows.Forms.Button()
        Me.dgSiteFuel = New System.Windows.Forms.DataGrid()
        Me.grpSite = New System.Windows.Forms.GroupBox()
        Me.txtDDRef = New System.Windows.Forms.TextBox()
        Me.lblDDRef = New System.Windows.Forms.Label()
        Me.cboAccomType = New System.Windows.Forms.ComboBox()
        Me.lblAccomType = New System.Windows.Forms.Label()
        Me.dtpDefectEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblDefectEndDate = New System.Windows.Forms.Label()
        Me.txtSiteDefects = New System.Windows.Forms.TextBox()
        Me.lblSiteDefects = New System.Windows.Forms.Label()
        Me.txtPropertyVoidDate = New System.Windows.Forms.TextBox()
        Me.lblPropertyVoidDate = New System.Windows.Forms.Label()
        Me.txtActualServiceDate = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtLastServiceDate = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.chkVoid = New System.Windows.Forms.CheckBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtAlert = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtAsbestos = New System.Windows.Forms.TextBox()
        Me.btnConvCust = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtSurname = New System.Windows.Forms.TextBox()
        Me.cboRegionID = New System.Windows.Forms.ComboBox()
        Me.txtPolicyNumber = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTelephoneNum = New System.Windows.Forms.TextBox()
        Me.lblTelephoneNum = New System.Windows.Forms.Label()
        Me.txtAddress4 = New System.Windows.Forms.TextBox()
        Me.lblTown = New System.Windows.Forms.Label()
        Me.txtEmailAddress = New System.Windows.Forms.TextBox()
        Me.lblEmailAddress = New System.Windows.Forms.Label()
        Me.cboSalutation = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.lblAddress2 = New System.Windows.Forms.Label()
        Me.btnAddModifyPlan = New System.Windows.Forms.Button()
        Me.chkCommercialDistrict = New System.Windows.Forms.CheckBox()
        Me.chkLeaseHolder = New System.Windows.Forms.CheckBox()
        Me.chkNoService = New System.Windows.Forms.CheckBox()
        Me.chkSolidFuel = New System.Windows.Forms.CheckBox()
        Me.chkOnStop = New System.Windows.Forms.CheckBox()
        Me.txtContractStatus = New System.Windows.Forms.TextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.chkNoMarketing = New System.Windows.Forms.CheckBox()
        Me.btnSendEmailToSite = New System.Windows.Forms.Button()
        Me.btnCustomerAudit = New System.Windows.Forms.Button()
        Me.btnDomestic = New System.Windows.Forms.Button()
        Me.btnFindCustomer = New System.Windows.Forms.Button()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkHeadOffice = New System.Windows.Forms.CheckBox()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.lblAddress1 = New System.Windows.Forms.Label()
        Me.txtAddress3 = New System.Windows.Forms.TextBox()
        Me.lblAddress3 = New System.Windows.Forms.Label()
        Me.txtAddress5 = New System.Windows.Forms.TextBox()
        Me.lblCounty = New System.Windows.Forms.Label()
        Me.txtPostcode = New System.Windows.Forms.TextBox()
        Me.lblPostcode = New System.Windows.Forms.Label()
        Me.txtFaxNum = New System.Windows.Forms.TextBox()
        Me.lblFaxNum = New System.Windows.Forms.Label()
        Me.lblContractInactive = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblRegionID = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnSiteReport = New System.Windows.Forms.Button()
        Me.btnShowVisits = New System.Windows.Forms.Button()
        Me.cboDefinition = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtJobNumber = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgJobs = New System.Windows.Forms.DataGrid()
        Me.btnAddJob = New System.Windows.Forms.Button()
        Me.btnShowAllJobs = New System.Windows.Forms.Button()
        Me.btnRemoveJob = New System.Windows.Forms.Button()
        Me.TabNewContacts = New System.Windows.Forms.TabPage()
        Me.pnlContactsMain = New System.Windows.Forms.FlowLayoutPanel()
        Me.tabCharges = New System.Windows.Forms.TabPage()
        Me.gpbCharges = New System.Windows.Forms.GroupBox()
        Me.chbAcceptChargeChanges = New System.Windows.Forms.CheckBox()
        Me.pnlCharges = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRatesMarkup = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMileageRate = New System.Windows.Forms.TextBox()
        Me.txtPartsMarkup = New System.Windows.Forms.TextBox()
        Me.tabContacts = New System.Windows.Forms.TabPage()
        Me.btnPrintLetters = New System.Windows.Forms.Button()
        Me.btnEmail = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgContacts = New System.Windows.Forms.DataGrid()
        Me.btnDeleteContact = New System.Windows.Forms.Button()
        Me.btnAddContact = New System.Windows.Forms.Button()
        Me.tabInvoiceAddress = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgInvoiceAddresses = New System.Windows.Forms.DataGrid()
        Me.btnDeleteAddress = New System.Windows.Forms.Button()
        Me.btnAddAddress = New System.Windows.Forms.Button()
        Me.tabDocuments = New System.Windows.Forms.TabPage()
        Me.pnlDocuments = New System.Windows.Forms.Panel()
        Me.tabQuotes = New System.Windows.Forms.TabPage()
        Me.pnlQuotes = New System.Windows.Forms.Panel()
        Me.tabContracts = New System.Windows.Forms.TabPage()
        Me.gpbContracts = New System.Windows.Forms.GroupBox()
        Me.btnDeleteContract = New System.Windows.Forms.Button()
        Me.dgContracts = New System.Windows.Forms.DataGrid()
        Me.btnAddContract = New System.Windows.Forms.Button()
        Me.tpNotes = New System.Windows.Forms.TabPage()
        Me.gpbNotesDetails = New System.Windows.Forms.GroupBox()
        Me.txtNoteID = New System.Windows.Forms.TextBox()
        Me.btnSaveNote = New System.Windows.Forms.Button()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.gpbNotes = New System.Windows.Forms.GroupBox()
        Me.btnDeleteNote = New System.Windows.Forms.Button()
        Me.dgNotes = New System.Windows.Forms.DataGrid()
        Me.btnAddNote = New System.Windows.Forms.Button()
        Me.tabAuthority = New System.Windows.Forms.TabPage()
        Me.grpSiteAuth = New System.Windows.Forms.GroupBox()
        Me.btnSaveAuth = New System.Windows.Forms.Button()
        Me.txtSiteAuth = New System.Windows.Forms.TextBox()
        Me.gpCustAuth = New System.Windows.Forms.GroupBox()
        Me.txtCustAuthority = New System.Windows.Forms.TextBox()
        Me.grpAudit = New System.Windows.Forms.GroupBox()
        Me.dgAuthorityAudit = New System.Windows.Forms.DataGrid()
        Me.tpAdditionalDetails = New System.Windows.Forms.TabPage()
        Me.grpAdditionalDetails = New System.Windows.Forms.GroupBox()
        Me.btnLetterReport = New System.Windows.Forms.Button()
        Me.cboReasonForContact = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboSourceOfCustomer = New System.Windows.Forms.ComboBox()
        Me.txtEstateOfficer = New System.Windows.Forms.TextBox()
        Me.lblEstateOfficer = New System.Windows.Forms.Label()
        Me.txtHousingManager = New System.Windows.Forms.TextBox()
        Me.lblHousingManager = New System.Windows.Forms.Label()
        Me.txtHousingOfficer = New System.Windows.Forms.TextBox()
        Me.lblHousingOfficer = New System.Windows.Forms.Label()
        Me.dtpBuildDate = New System.Windows.Forms.DateTimePicker()
        Me.lblBuildDate = New System.Windows.Forms.Label()
        Me.txtWarrantyPeriod = New System.Windows.Forms.TextBox()
        Me.lblWarrantyPeriod = New System.Windows.Forms.Label()
        Me.ttSiteFuel = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmsJobs = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiMoveJob = New System.Windows.Forms.ToolStripMenuItem()
        Me.tcSites.SuspendLayout()
        Me.tabDetails.SuspendLayout()
        Me.grpSiteFuel.SuspendLayout()
        CType(Me.dgSiteFuel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSite.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgJobs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabNewContacts.SuspendLayout()
        Me.tabCharges.SuspendLayout()
        Me.gpbCharges.SuspendLayout()
        Me.tabContacts.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgContacts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabInvoiceAddress.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgInvoiceAddresses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDocuments.SuspendLayout()
        Me.tabQuotes.SuspendLayout()
        Me.tabContracts.SuspendLayout()
        Me.gpbContracts.SuspendLayout()
        CType(Me.dgContracts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpNotes.SuspendLayout()
        Me.gpbNotesDetails.SuspendLayout()
        Me.gpbNotes.SuspendLayout()
        CType(Me.dgNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAuthority.SuspendLayout()
        Me.grpSiteAuth.SuspendLayout()
        Me.gpCustAuth.SuspendLayout()
        Me.grpAudit.SuspendLayout()
        CType(Me.dgAuthorityAudit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpAdditionalDetails.SuspendLayout()
        Me.grpAdditionalDetails.SuspendLayout()
        Me.cmsJobs.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcSites
        '
        Me.tcSites.Controls.Add(Me.tabDetails)
        Me.tcSites.Controls.Add(Me.TabNewContacts)
        Me.tcSites.Controls.Add(Me.tabCharges)
        Me.tcSites.Controls.Add(Me.tabContacts)
        Me.tcSites.Controls.Add(Me.tabInvoiceAddress)
        Me.tcSites.Controls.Add(Me.tabDocuments)
        Me.tcSites.Controls.Add(Me.tabQuotes)
        Me.tcSites.Controls.Add(Me.tabContracts)
        Me.tcSites.Controls.Add(Me.tpNotes)
        Me.tcSites.Controls.Add(Me.tabAuthority)
        Me.tcSites.Controls.Add(Me.tpAdditionalDetails)
        Me.tcSites.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcSites.Location = New System.Drawing.Point(0, 0)
        Me.tcSites.Name = "tcSites"
        Me.tcSites.SelectedIndex = 0
        Me.tcSites.Size = New System.Drawing.Size(1080, 666)
        Me.tcSites.TabIndex = 0
        '
        'tabDetails
        '
        Me.tabDetails.Controls.Add(Me.grpSiteFuel)
        Me.tabDetails.Controls.Add(Me.grpSite)
        Me.tabDetails.Controls.Add(Me.GroupBox4)
        Me.tabDetails.Location = New System.Drawing.Point(4, 22)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Size = New System.Drawing.Size(1072, 640)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "Main Details"
        '
        'grpSiteFuel
        '
        Me.grpSiteFuel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSiteFuel.Controls.Add(Me.btnMoreInfo)
        Me.grpSiteFuel.Controls.Add(Me.dgSiteFuel)
        Me.grpSiteFuel.Location = New System.Drawing.Point(588, 421)
        Me.grpSiteFuel.Margin = New System.Windows.Forms.Padding(0)
        Me.grpSiteFuel.Name = "grpSiteFuel"
        Me.grpSiteFuel.Padding = New System.Windows.Forms.Padding(0)
        Me.grpSiteFuel.Size = New System.Drawing.Size(476, 219)
        Me.grpSiteFuel.TabIndex = 13
        Me.grpSiteFuel.TabStop = False
        Me.grpSiteFuel.Text = "Site Fuel"
        '
        'btnMoreInfo
        '
        Me.btnMoreInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMoreInfo.Location = New System.Drawing.Point(371, 19)
        Me.btnMoreInfo.Name = "btnMoreInfo"
        Me.btnMoreInfo.Size = New System.Drawing.Size(96, 23)
        Me.btnMoreInfo.TabIndex = 12
        Me.btnMoreInfo.Text = "Update Fuels"
        '
        'dgSiteFuel
        '
        Me.dgSiteFuel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSiteFuel.DataMember = ""
        Me.dgSiteFuel.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSiteFuel.Location = New System.Drawing.Point(5, 19)
        Me.dgSiteFuel.Name = "dgSiteFuel"
        Me.dgSiteFuel.Size = New System.Drawing.Size(360, 195)
        Me.dgSiteFuel.TabIndex = 11
        '
        'grpSite
        '
        Me.grpSite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSite.Controls.Add(Me.txtDDRef)
        Me.grpSite.Controls.Add(Me.lblDDRef)
        Me.grpSite.Controls.Add(Me.cboAccomType)
        Me.grpSite.Controls.Add(Me.lblAccomType)
        Me.grpSite.Controls.Add(Me.dtpDefectEndDate)
        Me.grpSite.Controls.Add(Me.lblDefectEndDate)
        Me.grpSite.Controls.Add(Me.txtSiteDefects)
        Me.grpSite.Controls.Add(Me.lblSiteDefects)
        Me.grpSite.Controls.Add(Me.txtPropertyVoidDate)
        Me.grpSite.Controls.Add(Me.lblPropertyVoidDate)
        Me.grpSite.Controls.Add(Me.txtActualServiceDate)
        Me.grpSite.Controls.Add(Me.Label17)
        Me.grpSite.Controls.Add(Me.txtLastServiceDate)
        Me.grpSite.Controls.Add(Me.Label16)
        Me.grpSite.Controls.Add(Me.chkVoid)
        Me.grpSite.Controls.Add(Me.txtFirstName)
        Me.grpSite.Controls.Add(Me.txtAlert)
        Me.grpSite.Controls.Add(Me.Label21)
        Me.grpSite.Controls.Add(Me.Label20)
        Me.grpSite.Controls.Add(Me.txtAsbestos)
        Me.grpSite.Controls.Add(Me.btnConvCust)
        Me.grpSite.Controls.Add(Me.Label19)
        Me.grpSite.Controls.Add(Me.txtSurname)
        Me.grpSite.Controls.Add(Me.cboRegionID)
        Me.grpSite.Controls.Add(Me.txtPolicyNumber)
        Me.grpSite.Controls.Add(Me.Label12)
        Me.grpSite.Controls.Add(Me.txtTelephoneNum)
        Me.grpSite.Controls.Add(Me.lblTelephoneNum)
        Me.grpSite.Controls.Add(Me.txtAddress4)
        Me.grpSite.Controls.Add(Me.lblTown)
        Me.grpSite.Controls.Add(Me.txtEmailAddress)
        Me.grpSite.Controls.Add(Me.lblEmailAddress)
        Me.grpSite.Controls.Add(Me.cboSalutation)
        Me.grpSite.Controls.Add(Me.Label18)
        Me.grpSite.Controls.Add(Me.txtAddress2)
        Me.grpSite.Controls.Add(Me.lblAddress2)
        Me.grpSite.Controls.Add(Me.btnAddModifyPlan)
        Me.grpSite.Controls.Add(Me.chkCommercialDistrict)
        Me.grpSite.Controls.Add(Me.chkLeaseHolder)
        Me.grpSite.Controls.Add(Me.chkNoService)
        Me.grpSite.Controls.Add(Me.chkSolidFuel)
        Me.grpSite.Controls.Add(Me.chkOnStop)
        Me.grpSite.Controls.Add(Me.txtContractStatus)
        Me.grpSite.Controls.Add(Me.lblNotes)
        Me.grpSite.Controls.Add(Me.chkNoMarketing)
        Me.grpSite.Controls.Add(Me.btnSendEmailToSite)
        Me.grpSite.Controls.Add(Me.btnCustomerAudit)
        Me.grpSite.Controls.Add(Me.btnDomestic)
        Me.grpSite.Controls.Add(Me.btnFindCustomer)
        Me.grpSite.Controls.Add(Me.txtCustomer)
        Me.grpSite.Controls.Add(Me.Label10)
        Me.grpSite.Controls.Add(Me.txtName)
        Me.grpSite.Controls.Add(Me.Label3)
        Me.grpSite.Controls.Add(Me.chkHeadOffice)
        Me.grpSite.Controls.Add(Me.txtNotes)
        Me.grpSite.Controls.Add(Me.txtAddress1)
        Me.grpSite.Controls.Add(Me.lblAddress1)
        Me.grpSite.Controls.Add(Me.txtAddress3)
        Me.grpSite.Controls.Add(Me.lblAddress3)
        Me.grpSite.Controls.Add(Me.txtAddress5)
        Me.grpSite.Controls.Add(Me.lblCounty)
        Me.grpSite.Controls.Add(Me.txtPostcode)
        Me.grpSite.Controls.Add(Me.lblPostcode)
        Me.grpSite.Controls.Add(Me.txtFaxNum)
        Me.grpSite.Controls.Add(Me.lblFaxNum)
        Me.grpSite.Controls.Add(Me.lblContractInactive)
        Me.grpSite.Controls.Add(Me.Label14)
        Me.grpSite.Controls.Add(Me.lblRegionID)
        Me.grpSite.Location = New System.Drawing.Point(3, 2)
        Me.grpSite.Name = "grpSite"
        Me.grpSite.Size = New System.Drawing.Size(1061, 416)
        Me.grpSite.TabIndex = 0
        Me.grpSite.TabStop = False
        Me.grpSite.Text = "Main Details"
        '
        'txtDDRef
        '
        Me.txtDDRef.Location = New System.Drawing.Point(855, 195)
        Me.txtDDRef.MaxLength = 100
        Me.txtDDRef.Name = "txtDDRef"
        Me.txtDDRef.Size = New System.Drawing.Size(145, 21)
        Me.txtDDRef.TabIndex = 128
        Me.txtDDRef.Tag = ""
        '
        'lblDDRef
        '
        Me.lblDDRef.Location = New System.Drawing.Point(792, 199)
        Me.lblDDRef.Name = "lblDDRef"
        Me.lblDDRef.Size = New System.Drawing.Size(61, 20)
        Me.lblDDRef.TabIndex = 129
        Me.lblDDRef.Text = "DD Ref"
        Me.lblDDRef.UseMnemonic = False
        '
        'cboAccomType
        '
        Me.cboAccomType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboAccomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccomType.Location = New System.Drawing.Point(789, 225)
        Me.cboAccomType.Name = "cboAccomType"
        Me.cboAccomType.Size = New System.Drawing.Size(145, 21)
        Me.cboAccomType.TabIndex = 122
        Me.cboAccomType.Tag = "Site.RegionID"
        '
        'lblAccomType
        '
        Me.lblAccomType.Location = New System.Drawing.Point(643, 229)
        Me.lblAccomType.Name = "lblAccomType"
        Me.lblAccomType.Size = New System.Drawing.Size(140, 23)
        Me.lblAccomType.TabIndex = 121
        Me.lblAccomType.Text = "Accommodation Type"
        '
        'dtpDefectEndDate
        '
        Me.dtpDefectEndDate.Location = New System.Drawing.Point(855, 383)
        Me.dtpDefectEndDate.Name = "dtpDefectEndDate"
        Me.dtpDefectEndDate.Size = New System.Drawing.Size(151, 21)
        Me.dtpDefectEndDate.TabIndex = 120
        '
        'lblDefectEndDate
        '
        Me.lblDefectEndDate.Location = New System.Drawing.Point(730, 386)
        Me.lblDefectEndDate.Name = "lblDefectEndDate"
        Me.lblDefectEndDate.Size = New System.Drawing.Size(119, 20)
        Me.lblDefectEndDate.TabIndex = 119
        Me.lblDefectEndDate.Text = "Defect End Date"
        '
        'txtSiteDefects
        '
        Me.txtSiteDefects.Location = New System.Drawing.Point(534, 383)
        Me.txtSiteDefects.MaxLength = 100
        Me.txtSiteDefects.Name = "txtSiteDefects"
        Me.txtSiteDefects.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSiteDefects.Size = New System.Drawing.Size(181, 21)
        Me.txtSiteDefects.TabIndex = 118
        Me.txtSiteDefects.Tag = ""
        '
        'lblSiteDefects
        '
        Me.lblSiteDefects.Location = New System.Drawing.Point(419, 386)
        Me.lblSiteDefects.Name = "lblSiteDefects"
        Me.lblSiteDefects.Size = New System.Drawing.Size(119, 20)
        Me.lblSiteDefects.TabIndex = 117
        Me.lblSiteDefects.Text = "Defect Contractor"
        '
        'txtPropertyVoidDate
        '
        Me.txtPropertyVoidDate.BackColor = System.Drawing.SystemColors.Control
        Me.txtPropertyVoidDate.Location = New System.Drawing.Point(534, 225)
        Me.txtPropertyVoidDate.Name = "txtPropertyVoidDate"
        Me.txtPropertyVoidDate.ReadOnly = True
        Me.txtPropertyVoidDate.Size = New System.Drawing.Size(89, 21)
        Me.txtPropertyVoidDate.TabIndex = 116
        Me.txtPropertyVoidDate.Visible = False
        '
        'lblPropertyVoidDate
        '
        Me.lblPropertyVoidDate.AutoSize = True
        Me.lblPropertyVoidDate.Location = New System.Drawing.Point(466, 228)
        Me.lblPropertyVoidDate.Name = "lblPropertyVoidDate"
        Me.lblPropertyVoidDate.Size = New System.Drawing.Size(62, 13)
        Me.lblPropertyVoidDate.TabIndex = 115
        Me.lblPropertyVoidDate.Text = "Void Date"
        Me.lblPropertyVoidDate.Visible = False
        '
        'txtActualServiceDate
        '
        Me.txtActualServiceDate.Location = New System.Drawing.Point(328, 225)
        Me.txtActualServiceDate.MaxLength = 100
        Me.txtActualServiceDate.Name = "txtActualServiceDate"
        Me.txtActualServiceDate.ReadOnly = True
        Me.txtActualServiceDate.Size = New System.Drawing.Size(123, 21)
        Me.txtActualServiceDate.TabIndex = 112
        Me.txtActualServiceDate.Tag = ""
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(244, 229)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(128, 20)
        Me.Label17.TabIndex = 111
        Me.Label17.Text = "Service Date"
        '
        'txtLastServiceDate
        '
        Me.txtLastServiceDate.Location = New System.Drawing.Point(115, 225)
        Me.txtLastServiceDate.MaxLength = 100
        Me.txtLastServiceDate.Name = "txtLastServiceDate"
        Me.txtLastServiceDate.ReadOnly = True
        Me.txtLastServiceDate.Size = New System.Drawing.Size(123, 21)
        Me.txtLastServiceDate.TabIndex = 110
        Me.txtLastServiceDate.Tag = ""
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(3, 229)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(128, 20)
        Me.Label16.TabIndex = 109
        Me.Label16.Text = "Service Due"
        '
        'chkVoid
        '
        Me.chkVoid.AutoCheck = False
        Me.chkVoid.AutoSize = True
        Me.chkVoid.Location = New System.Drawing.Point(630, 199)
        Me.chkVoid.Name = "chkVoid"
        Me.chkVoid.Size = New System.Drawing.Size(103, 17)
        Me.chkVoid.TabIndex = 108
        Me.chkVoid.Text = "Void Property"
        Me.chkVoid.UseVisualStyleBackColor = True
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(328, 42)
        Me.txtFirstName.MaxLength = 255
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(146, 21)
        Me.txtFirstName.TabIndex = 5
        Me.txtFirstName.Tag = ""
        '
        'txtAlert
        '
        Me.txtAlert.Location = New System.Drawing.Point(115, 383)
        Me.txtAlert.MaxLength = 100
        Me.txtAlert.Name = "txtAlert"
        Me.txtAlert.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAlert.Size = New System.Drawing.Size(298, 21)
        Me.txtAlert.TabIndex = 105
        Me.txtAlert.Tag = ""
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(7, 386)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(102, 20)
        Me.Label21.TabIndex = 104
        Me.Label21.Text = "Contact Alerts"
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(7, 335)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(102, 20)
        Me.Label20.TabIndex = 103
        Me.Label20.Text = "Asbestos Details"
        '
        'txtAsbestos
        '
        Me.txtAsbestos.AcceptsReturn = True
        Me.txtAsbestos.Location = New System.Drawing.Point(115, 333)
        Me.txtAsbestos.Multiline = True
        Me.txtAsbestos.Name = "txtAsbestos"
        Me.txtAsbestos.ReadOnly = True
        Me.txtAsbestos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAsbestos.Size = New System.Drawing.Size(891, 45)
        Me.txtAsbestos.TabIndex = 102
        Me.txtAsbestos.Tag = "Site.Notes"
        '
        'btnConvCust
        '
        Me.btnConvCust.Location = New System.Drawing.Point(632, 15)
        Me.btnConvCust.Name = "btnConvCust"
        Me.btnConvCust.Size = New System.Drawing.Size(146, 23)
        Me.btnConvCust.TabIndex = 101
        Me.btnConvCust.Text = "Convert to Customer"
        Me.btnConvCust.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(8, 72)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(77, 20)
        Me.Label19.TabIndex = 84
        Me.Label19.Text = "Surname"
        '
        'txtSurname
        '
        Me.txtSurname.Location = New System.Drawing.Point(115, 67)
        Me.txtSurname.MaxLength = 255
        Me.txtSurname.Name = "txtSurname"
        Me.txtSurname.Size = New System.Drawing.Size(359, 21)
        Me.txtSurname.TabIndex = 6
        Me.txtSurname.Tag = ""
        '
        'cboRegionID
        '
        Me.cboRegionID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboRegionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegionID.Location = New System.Drawing.Point(328, 166)
        Me.cboRegionID.Name = "cboRegionID"
        Me.cboRegionID.Size = New System.Drawing.Size(146, 21)
        Me.cboRegionID.TabIndex = 64
        Me.cboRegionID.Tag = "Site.RegionID"
        '
        'txtPolicyNumber
        '
        Me.txtPolicyNumber.Location = New System.Drawing.Point(632, 122)
        Me.txtPolicyNumber.MaxLength = 100
        Me.txtPolicyNumber.Name = "txtPolicyNumber"
        Me.txtPolicyNumber.Size = New System.Drawing.Size(223, 21)
        Me.txtPolicyNumber.TabIndex = 16
        Me.txtPolicyNumber.Tag = ""
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(509, 125)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 20)
        Me.Label12.TabIndex = 81
        Me.Label12.Text = "Policy No/UPRN"
        '
        'txtTelephoneNum
        '
        Me.txtTelephoneNum.Location = New System.Drawing.Point(632, 69)
        Me.txtTelephoneNum.MaxLength = 50
        Me.txtTelephoneNum.Name = "txtTelephoneNum"
        Me.txtTelephoneNum.Size = New System.Drawing.Size(146, 21)
        Me.txtTelephoneNum.TabIndex = 13
        Me.txtTelephoneNum.Tag = "Site.TelephoneNum"
        '
        'lblTelephoneNum
        '
        Me.lblTelephoneNum.Location = New System.Drawing.Point(509, 71)
        Me.lblTelephoneNum.Name = "lblTelephoneNum"
        Me.lblTelephoneNum.Size = New System.Drawing.Size(107, 20)
        Me.lblTelephoneNum.TabIndex = 79
        Me.lblTelephoneNum.Text = "Tel"
        '
        'txtAddress4
        '
        Me.txtAddress4.Location = New System.Drawing.Point(115, 141)
        Me.txtAddress4.MaxLength = 100
        Me.txtAddress4.Name = "txtAddress4"
        Me.txtAddress4.Size = New System.Drawing.Size(146, 21)
        Me.txtAddress4.TabIndex = 10
        Me.txtAddress4.Tag = "Site.Town"
        '
        'lblTown
        '
        Me.lblTown.Location = New System.Drawing.Point(8, 143)
        Me.lblTown.Name = "lblTown"
        Me.lblTown.Size = New System.Drawing.Size(72, 20)
        Me.lblTown.TabIndex = 73
        Me.lblTown.Text = "Address 4"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Location = New System.Drawing.Point(632, 95)
        Me.txtEmailAddress.MaxLength = 100
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(223, 21)
        Me.txtEmailAddress.TabIndex = 15
        Me.txtEmailAddress.Tag = "Site.EmailAddress"
        '
        'lblEmailAddress
        '
        Me.lblEmailAddress.Location = New System.Drawing.Point(510, 98)
        Me.lblEmailAddress.Name = "lblEmailAddress"
        Me.lblEmailAddress.Size = New System.Drawing.Size(99, 20)
        Me.lblEmailAddress.TabIndex = 71
        Me.lblEmailAddress.Text = "Email Address"
        '
        'cboSalutation
        '
        Me.cboSalutation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboSalutation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSalutation.Location = New System.Drawing.Point(116, 42)
        Me.cboSalutation.Name = "cboSalutation"
        Me.cboSalutation.Size = New System.Drawing.Size(145, 21)
        Me.cboSalutation.TabIndex = 54
        Me.cboSalutation.Tag = "Site.RegionID"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(260, 45)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(72, 20)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "First Name"
        '
        'txtAddress2
        '
        Me.txtAddress2.Location = New System.Drawing.Point(115, 117)
        Me.txtAddress2.MaxLength = 255
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(146, 21)
        Me.txtAddress2.TabIndex = 8
        Me.txtAddress2.Tag = "Site.Address2"
        '
        'lblAddress2
        '
        Me.lblAddress2.Location = New System.Drawing.Point(8, 120)
        Me.lblAddress2.Name = "lblAddress2"
        Me.lblAddress2.Size = New System.Drawing.Size(94, 20)
        Me.lblAddress2.TabIndex = 57
        Me.lblAddress2.Text = "Address 2"
        '
        'btnAddModifyPlan
        '
        Me.btnAddModifyPlan.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.btnAddModifyPlan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddModifyPlan.Location = New System.Drawing.Point(814, 254)
        Me.btnAddModifyPlan.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAddModifyPlan.Name = "btnAddModifyPlan"
        Me.btnAddModifyPlan.Size = New System.Drawing.Size(192, 23)
        Me.btnAddModifyPlan.TabIndex = 68
        Me.btnAddModifyPlan.Text = "Add / Modify Coverplan"
        Me.btnAddModifyPlan.UseVisualStyleBackColor = False
        '
        'chkCommercialDistrict
        '
        Me.chkCommercialDistrict.AutoSize = True
        Me.chkCommercialDistrict.Enabled = False
        Me.chkCommercialDistrict.Location = New System.Drawing.Point(457, 199)
        Me.chkCommercialDistrict.Name = "chkCommercialDistrict"
        Me.chkCommercialDistrict.Size = New System.Drawing.Size(140, 17)
        Me.chkCommercialDistrict.TabIndex = 46
        Me.chkCommercialDistrict.Text = "Commercial/District"
        Me.chkCommercialDistrict.UseVisualStyleBackColor = True
        '
        'chkLeaseHolder
        '
        Me.chkLeaseHolder.AutoSize = True
        Me.chkLeaseHolder.Enabled = False
        Me.chkLeaseHolder.Location = New System.Drawing.Point(328, 199)
        Me.chkLeaseHolder.Name = "chkLeaseHolder"
        Me.chkLeaseHolder.Size = New System.Drawing.Size(100, 17)
        Me.chkLeaseHolder.TabIndex = 45
        Me.chkLeaseHolder.Text = "Lease Holder"
        Me.chkLeaseHolder.UseVisualStyleBackColor = True
        '
        'chkNoService
        '
        Me.chkNoService.AutoCheck = False
        Me.chkNoService.AutoSize = True
        Me.chkNoService.Location = New System.Drawing.Point(216, 199)
        Me.chkNoService.Name = "chkNoService"
        Me.chkNoService.Size = New System.Drawing.Size(88, 17)
        Me.chkNoService.TabIndex = 44
        Me.chkNoService.Text = "No Service"
        Me.chkNoService.UseVisualStyleBackColor = True
        '
        'chkSolidFuel
        '
        Me.chkSolidFuel.AutoSize = True
        Me.chkSolidFuel.Enabled = False
        Me.chkSolidFuel.Location = New System.Drawing.Point(115, 199)
        Me.chkSolidFuel.Name = "chkSolidFuel"
        Me.chkSolidFuel.Size = New System.Drawing.Size(81, 17)
        Me.chkSolidFuel.TabIndex = 43
        Me.chkSolidFuel.Text = "Solid Fuel"
        Me.chkSolidFuel.UseVisualStyleBackColor = True
        '
        'chkOnStop
        '
        Me.chkOnStop.AutoCheck = False
        Me.chkOnStop.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.chkOnStop.Location = New System.Drawing.Point(751, 148)
        Me.chkOnStop.Name = "chkOnStop"
        Me.chkOnStop.Size = New System.Drawing.Size(82, 20)
        Me.chkOnStop.TabIndex = 42
        Me.chkOnStop.Tag = "Site.HeadOffice"
        Me.chkOnStop.Text = "On Stop"
        '
        'txtContractStatus
        '
        Me.txtContractStatus.Location = New System.Drawing.Point(116, 255)
        Me.txtContractStatus.MaxLength = 100
        Me.txtContractStatus.Name = "txtContractStatus"
        Me.txtContractStatus.ReadOnly = True
        Me.txtContractStatus.Size = New System.Drawing.Size(667, 21)
        Me.txtContractStatus.TabIndex = 38
        Me.txtContractStatus.Tag = ""
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(3, 285)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(59, 20)
        Me.lblNotes.TabIndex = 39
        Me.lblNotes.Text = "Notes"
        '
        'chkNoMarketing
        '
        Me.chkNoMarketing.Location = New System.Drawing.Point(847, 146)
        Me.chkNoMarketing.Name = "chkNoMarketing"
        Me.chkNoMarketing.Size = New System.Drawing.Size(103, 24)
        Me.chkNoMarketing.TabIndex = 32
        Me.chkNoMarketing.Text = "No Marketing"
        '
        'btnSendEmailToSite
        '
        Me.btnSendEmailToSite.Location = New System.Drawing.Point(861, 94)
        Me.btnSendEmailToSite.Name = "btnSendEmailToSite"
        Me.btnSendEmailToSite.Size = New System.Drawing.Size(145, 23)
        Me.btnSendEmailToSite.TabIndex = 25
        Me.btnSendEmailToSite.Text = "Email"
        '
        'btnCustomerAudit
        '
        Me.btnCustomerAudit.Location = New System.Drawing.Point(861, 14)
        Me.btnCustomerAudit.Name = "btnCustomerAudit"
        Me.btnCustomerAudit.Size = New System.Drawing.Size(145, 23)
        Me.btnCustomerAudit.TabIndex = 4
        Me.btnCustomerAudit.Text = "Audit"
        '
        'btnDomestic
        '
        Me.btnDomestic.BackColor = System.Drawing.SystemColors.Control
        Me.btnDomestic.Location = New System.Drawing.Point(341, 15)
        Me.btnDomestic.Name = "btnDomestic"
        Me.btnDomestic.Size = New System.Drawing.Size(72, 23)
        Me.btnDomestic.TabIndex = 2
        Me.btnDomestic.Text = "Domestic"
        Me.btnDomestic.UseVisualStyleBackColor = False
        '
        'btnFindCustomer
        '
        Me.btnFindCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindCustomer.Location = New System.Drawing.Point(419, 15)
        Me.btnFindCustomer.Name = "btnFindCustomer"
        Me.btnFindCustomer.Size = New System.Drawing.Size(55, 23)
        Me.btnFindCustomer.TabIndex = 3
        Me.btnFindCustomer.Text = "Search"
        Me.btnFindCustomer.UseVisualStyleBackColor = False
        '
        'txtCustomer
        '
        Me.txtCustomer.Enabled = False
        Me.txtCustomer.Location = New System.Drawing.Point(115, 16)
        Me.txtCustomer.MaxLength = 255
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(210, 21)
        Me.txtCustomer.TabIndex = 1
        Me.txtCustomer.Tag = ""
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 20)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Customer"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(632, 43)
        Me.txtName.MaxLength = 255
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(374, 21)
        Me.txtName.TabIndex = 100
        Me.txtName.Tag = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Primary Contact"
        '
        'chkHeadOffice
        '
        Me.chkHeadOffice.AutoCheck = False
        Me.chkHeadOffice.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.chkHeadOffice.Location = New System.Drawing.Point(630, 148)
        Me.chkHeadOffice.Name = "chkHeadOffice"
        Me.chkHeadOffice.Size = New System.Drawing.Size(104, 20)
        Me.chkHeadOffice.TabIndex = 30
        Me.chkHeadOffice.Tag = "Site.HeadOffice"
        Me.chkHeadOffice.Text = "Head Office"
        '
        'txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(116, 282)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(890, 45)
        Me.txtNotes.TabIndex = 37
        Me.txtNotes.Tag = "Site.Notes"
        '
        'txtAddress1
        '
        Me.txtAddress1.Location = New System.Drawing.Point(115, 93)
        Me.txtAddress1.MaxLength = 255
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(359, 21)
        Me.txtAddress1.TabIndex = 7
        Me.txtAddress1.Tag = "Site.Address1"
        '
        'lblAddress1
        '
        Me.lblAddress1.Location = New System.Drawing.Point(8, 96)
        Me.lblAddress1.Name = "lblAddress1"
        Me.lblAddress1.Size = New System.Drawing.Size(67, 20)
        Me.lblAddress1.TabIndex = 7
        Me.lblAddress1.Text = "Address 1"
        '
        'txtAddress3
        '
        Me.txtAddress3.Location = New System.Drawing.Point(328, 117)
        Me.txtAddress3.MaxLength = 255
        Me.txtAddress3.Name = "txtAddress3"
        Me.txtAddress3.Size = New System.Drawing.Size(146, 21)
        Me.txtAddress3.TabIndex = 9
        Me.txtAddress3.Tag = "Site.Address3"
        '
        'lblAddress3
        '
        Me.lblAddress3.Location = New System.Drawing.Point(261, 120)
        Me.lblAddress3.Name = "lblAddress3"
        Me.lblAddress3.Size = New System.Drawing.Size(64, 20)
        Me.lblAddress3.TabIndex = 11
        Me.lblAddress3.Text = "Address 3"
        '
        'txtAddress5
        '
        Me.txtAddress5.Location = New System.Drawing.Point(328, 141)
        Me.txtAddress5.MaxLength = 100
        Me.txtAddress5.Name = "txtAddress5"
        Me.txtAddress5.Size = New System.Drawing.Size(146, 21)
        Me.txtAddress5.TabIndex = 11
        Me.txtAddress5.Tag = "Site.County"
        '
        'lblCounty
        '
        Me.lblCounty.Location = New System.Drawing.Point(262, 143)
        Me.lblCounty.Name = "lblCounty"
        Me.lblCounty.Size = New System.Drawing.Size(64, 20)
        Me.lblCounty.TabIndex = 15
        Me.lblCounty.Text = "Address 5"
        '
        'txtPostcode
        '
        Me.txtPostcode.Location = New System.Drawing.Point(115, 167)
        Me.txtPostcode.MaxLength = 10
        Me.txtPostcode.Name = "txtPostcode"
        Me.txtPostcode.Size = New System.Drawing.Size(146, 21)
        Me.txtPostcode.TabIndex = 12
        Me.txtPostcode.Tag = "Site.Postcode"
        '
        'lblPostcode
        '
        Me.lblPostcode.Location = New System.Drawing.Point(8, 167)
        Me.lblPostcode.Name = "lblPostcode"
        Me.lblPostcode.Size = New System.Drawing.Size(73, 20)
        Me.lblPostcode.TabIndex = 17
        Me.lblPostcode.Text = "Postcode"
        '
        'txtFaxNum
        '
        Me.txtFaxNum.Location = New System.Drawing.Point(861, 68)
        Me.txtFaxNum.MaxLength = 50
        Me.txtFaxNum.Name = "txtFaxNum"
        Me.txtFaxNum.Size = New System.Drawing.Size(145, 21)
        Me.txtFaxNum.TabIndex = 14
        Me.txtFaxNum.Tag = "Site.FaxNum"
        '
        'lblFaxNum
        '
        Me.lblFaxNum.Location = New System.Drawing.Point(799, 72)
        Me.lblFaxNum.Name = "lblFaxNum"
        Me.lblFaxNum.Size = New System.Drawing.Size(50, 20)
        Me.lblFaxNum.TabIndex = 21
        Me.lblFaxNum.Text = "Mobile"
        '
        'lblContractInactive
        '
        Me.lblContractInactive.BackColor = System.Drawing.Color.Red
        Me.lblContractInactive.Location = New System.Drawing.Point(109, 252)
        Me.lblContractInactive.Name = "lblContractInactive"
        Me.lblContractInactive.Size = New System.Drawing.Size(682, 27)
        Me.lblContractInactive.TabIndex = 31
        Me.lblContractInactive.Visible = False
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(3, 257)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 20)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "Contract"
        '
        'lblRegionID
        '
        Me.lblRegionID.Location = New System.Drawing.Point(261, 166)
        Me.lblRegionID.Name = "lblRegionID"
        Me.lblRegionID.Size = New System.Drawing.Size(62, 20)
        Me.lblRegionID.TabIndex = 63
        Me.lblRegionID.Text = "Region"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.btnSiteReport)
        Me.GroupBox4.Controls.Add(Me.btnShowVisits)
        Me.GroupBox4.Controls.Add(Me.cboDefinition)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.txtJobNumber)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.dtpTo)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.dtpFrom)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.dgJobs)
        Me.GroupBox4.Controls.Add(Me.btnAddJob)
        Me.GroupBox4.Controls.Add(Me.btnShowAllJobs)
        Me.GroupBox4.Controls.Add(Me.btnRemoveJob)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 421)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox4.Size = New System.Drawing.Size(575, 219)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Jobs"
        '
        'btnSiteReport
        '
        Me.btnSiteReport.Location = New System.Drawing.Point(457, 161)
        Me.btnSiteReport.Name = "btnSiteReport"
        Me.btnSiteReport.Size = New System.Drawing.Size(96, 23)
        Me.btnSiteReport.TabIndex = 13
        Me.btnSiteReport.Text = "Site Report"
        Me.btnSiteReport.UseVisualStyleBackColor = True
        '
        'btnShowVisits
        '
        Me.btnShowVisits.Location = New System.Drawing.Point(457, 132)
        Me.btnShowVisits.Name = "btnShowVisits"
        Me.btnShowVisits.Size = New System.Drawing.Size(96, 23)
        Me.btnShowVisits.TabIndex = 12
        Me.btnShowVisits.Text = "Show History"
        Me.btnShowVisits.UseVisualStyleBackColor = True
        '
        'cboDefinition
        '
        Me.cboDefinition.Location = New System.Drawing.Point(200, 40)
        Me.cboDefinition.Name = "cboDefinition"
        Me.cboDefinition.Size = New System.Drawing.Size(104, 21)
        Me.cboDefinition.TabIndex = 7
        Me.cboDefinition.Visible = False
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(152, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 23)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Def.:"
        Me.Label9.Visible = False
        '
        'txtJobNumber
        '
        Me.txtJobNumber.Location = New System.Drawing.Point(350, 16)
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Size = New System.Drawing.Size(84, 21)
        Me.txtJobNumber.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(298, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 23)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Job No:"
        '
        'dtpTo
        '
        Me.dtpTo.Checked = False
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(186, 16)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.ShowCheckBox = True
        Me.dtpTo.Size = New System.Drawing.Size(104, 21)
        Me.dtpTo.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(156, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 23)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "To:"
        '
        'dtpFrom
        '
        Me.dtpFrom.Checked = False
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(48, 16)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.ShowCheckBox = True
        Me.dtpFrom.Size = New System.Drawing.Size(104, 21)
        Me.dtpFrom.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 23)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "From:"
        '
        'dgJobs
        '
        Me.dgJobs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgJobs.DataMember = ""
        Me.dgJobs.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgJobs.Location = New System.Drawing.Point(5, 45)
        Me.dgJobs.Name = "dgJobs"
        Me.dgJobs.Size = New System.Drawing.Size(431, 169)
        Me.dgJobs.TabIndex = 11
        '
        'btnAddJob
        '
        Me.btnAddJob.Location = New System.Drawing.Point(457, 45)
        Me.btnAddJob.Name = "btnAddJob"
        Me.btnAddJob.Size = New System.Drawing.Size(96, 23)
        Me.btnAddJob.TabIndex = 9
        Me.btnAddJob.Text = "Add"
        '
        'btnShowAllJobs
        '
        Me.btnShowAllJobs.Location = New System.Drawing.Point(457, 103)
        Me.btnShowAllJobs.Name = "btnShowAllJobs"
        Me.btnShowAllJobs.Size = New System.Drawing.Size(96, 23)
        Me.btnShowAllJobs.TabIndex = 8
        Me.btnShowAllJobs.Text = "Show All"
        '
        'btnRemoveJob
        '
        Me.btnRemoveJob.Location = New System.Drawing.Point(457, 74)
        Me.btnRemoveJob.Name = "btnRemoveJob"
        Me.btnRemoveJob.Size = New System.Drawing.Size(96, 23)
        Me.btnRemoveJob.TabIndex = 10
        Me.btnRemoveJob.Text = "Delete"
        '
        'TabNewContacts
        '
        Me.TabNewContacts.Controls.Add(Me.pnlContactsMain)
        Me.TabNewContacts.Location = New System.Drawing.Point(4, 22)
        Me.TabNewContacts.Name = "TabNewContacts"
        Me.TabNewContacts.Padding = New System.Windows.Forms.Padding(3)
        Me.TabNewContacts.Size = New System.Drawing.Size(1072, 640)
        Me.TabNewContacts.TabIndex = 13
        Me.TabNewContacts.Text = "Contacts"
        Me.TabNewContacts.UseVisualStyleBackColor = True
        '
        'pnlContactsMain
        '
        Me.pnlContactsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContactsMain.Location = New System.Drawing.Point(3, 3)
        Me.pnlContactsMain.Name = "pnlContactsMain"
        Me.pnlContactsMain.Size = New System.Drawing.Size(1066, 634)
        Me.pnlContactsMain.TabIndex = 0
        '
        'tabCharges
        '
        Me.tabCharges.Controls.Add(Me.gpbCharges)
        Me.tabCharges.Location = New System.Drawing.Point(4, 22)
        Me.tabCharges.Name = "tabCharges"
        Me.tabCharges.Size = New System.Drawing.Size(1072, 640)
        Me.tabCharges.TabIndex = 8
        Me.tabCharges.Text = "Charges"
        '
        'gpbCharges
        '
        Me.gpbCharges.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbCharges.Controls.Add(Me.chbAcceptChargeChanges)
        Me.gpbCharges.Controls.Add(Me.pnlCharges)
        Me.gpbCharges.Controls.Add(Me.Label2)
        Me.gpbCharges.Controls.Add(Me.txtRatesMarkup)
        Me.gpbCharges.Controls.Add(Me.Label4)
        Me.gpbCharges.Controls.Add(Me.Label8)
        Me.gpbCharges.Controls.Add(Me.txtMileageRate)
        Me.gpbCharges.Controls.Add(Me.txtPartsMarkup)
        Me.gpbCharges.Location = New System.Drawing.Point(8, 8)
        Me.gpbCharges.Name = "gpbCharges"
        Me.gpbCharges.Size = New System.Drawing.Size(1056, 626)
        Me.gpbCharges.TabIndex = 60
        Me.gpbCharges.TabStop = False
        Me.gpbCharges.Text = "Charges"
        '
        'chbAcceptChargeChanges
        '
        Me.chbAcceptChargeChanges.BackColor = System.Drawing.SystemColors.Info
        Me.chbAcceptChargeChanges.Location = New System.Drawing.Point(8, 16)
        Me.chbAcceptChargeChanges.Name = "chbAcceptChargeChanges"
        Me.chbAcceptChargeChanges.Size = New System.Drawing.Size(480, 24)
        Me.chbAcceptChargeChanges.TabIndex = 61
        Me.chbAcceptChargeChanges.Text = "Always accept changes to default charges made at customer level"
        Me.chbAcceptChargeChanges.UseVisualStyleBackColor = False
        '
        'pnlCharges
        '
        Me.pnlCharges.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCharges.Location = New System.Drawing.Point(8, 88)
        Me.pnlCharges.Name = "pnlCharges"
        Me.pnlCharges.Size = New System.Drawing.Size(1040, 530)
        Me.pnlCharges.TabIndex = 59
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(296, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 23)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Rates Markup"
        '
        'txtRatesMarkup
        '
        Me.txtRatesMarkup.Location = New System.Drawing.Point(384, 48)
        Me.txtRatesMarkup.Name = "txtRatesMarkup"
        Me.txtRatesMarkup.Size = New System.Drawing.Size(48, 21)
        Me.txtRatesMarkup.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 23)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Labour Markup"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(155, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 23)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "Parts Markup"
        '
        'txtMileageRate
        '
        Me.txtMileageRate.Location = New System.Drawing.Point(104, 48)
        Me.txtMileageRate.Name = "txtMileageRate"
        Me.txtMileageRate.Size = New System.Drawing.Size(48, 21)
        Me.txtMileageRate.TabIndex = 0
        '
        'txtPartsMarkup
        '
        Me.txtPartsMarkup.Location = New System.Drawing.Point(244, 48)
        Me.txtPartsMarkup.Name = "txtPartsMarkup"
        Me.txtPartsMarkup.Size = New System.Drawing.Size(48, 21)
        Me.txtPartsMarkup.TabIndex = 4
        '
        'tabContacts
        '
        Me.tabContacts.Controls.Add(Me.btnPrintLetters)
        Me.tabContacts.Controls.Add(Me.btnEmail)
        Me.tabContacts.Controls.Add(Me.GroupBox1)
        Me.tabContacts.Controls.Add(Me.btnDeleteContact)
        Me.tabContacts.Controls.Add(Me.btnAddContact)
        Me.tabContacts.Location = New System.Drawing.Point(4, 22)
        Me.tabContacts.Name = "tabContacts"
        Me.tabContacts.Size = New System.Drawing.Size(1072, 640)
        Me.tabContacts.TabIndex = 3
        Me.tabContacts.Text = "Associated Contacts"
        '
        'btnPrintLetters
        '
        Me.btnPrintLetters.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintLetters.Location = New System.Drawing.Point(136, 612)
        Me.btnPrintLetters.Name = "btnPrintLetters"
        Me.btnPrintLetters.Size = New System.Drawing.Size(112, 25)
        Me.btnPrintLetters.TabIndex = 6
        Me.btnPrintLetters.Text = "Print Letters"
        '
        'btnEmail
        '
        Me.btnEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEmail.Location = New System.Drawing.Point(72, 612)
        Me.btnEmail.Name = "btnEmail"
        Me.btnEmail.Size = New System.Drawing.Size(56, 25)
        Me.btnEmail.TabIndex = 5
        Me.btnEmail.Text = "Email"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgContacts)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1056, 596)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Contacts"
        '
        'dgContacts
        '
        Me.dgContacts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgContacts.DataMember = ""
        Me.dgContacts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgContacts.Location = New System.Drawing.Point(6, 20)
        Me.dgContacts.Name = "dgContacts"
        Me.dgContacts.Size = New System.Drawing.Size(1045, 568)
        Me.dgContacts.TabIndex = 1
        '
        'btnDeleteContact
        '
        Me.btnDeleteContact.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteContact.Location = New System.Drawing.Point(1008, 612)
        Me.btnDeleteContact.Name = "btnDeleteContact"
        Me.btnDeleteContact.Size = New System.Drawing.Size(56, 25)
        Me.btnDeleteContact.TabIndex = 3
        Me.btnDeleteContact.Text = "Delete"
        '
        'btnAddContact
        '
        Me.btnAddContact.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddContact.Location = New System.Drawing.Point(8, 612)
        Me.btnAddContact.Name = "btnAddContact"
        Me.btnAddContact.Size = New System.Drawing.Size(56, 25)
        Me.btnAddContact.TabIndex = 2
        Me.btnAddContact.Text = "Add"
        '
        'tabInvoiceAddress
        '
        Me.tabInvoiceAddress.Controls.Add(Me.GroupBox2)
        Me.tabInvoiceAddress.Controls.Add(Me.btnDeleteAddress)
        Me.tabInvoiceAddress.Controls.Add(Me.btnAddAddress)
        Me.tabInvoiceAddress.Location = New System.Drawing.Point(4, 22)
        Me.tabInvoiceAddress.Name = "tabInvoiceAddress"
        Me.tabInvoiceAddress.Size = New System.Drawing.Size(1072, 640)
        Me.tabInvoiceAddress.TabIndex = 4
        Me.tabInvoiceAddress.Text = "Invoice Addresses"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dgInvoiceAddresses)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1056, 594)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Invoice Addresses"
        '
        'dgInvoiceAddresses
        '
        Me.dgInvoiceAddresses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgInvoiceAddresses.DataMember = ""
        Me.dgInvoiceAddresses.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgInvoiceAddresses.Location = New System.Drawing.Point(6, 20)
        Me.dgInvoiceAddresses.Name = "dgInvoiceAddresses"
        Me.dgInvoiceAddresses.Size = New System.Drawing.Size(1045, 569)
        Me.dgInvoiceAddresses.TabIndex = 1
        '
        'btnDeleteAddress
        '
        Me.btnDeleteAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteAddress.Location = New System.Drawing.Point(1000, 610)
        Me.btnDeleteAddress.Name = "btnDeleteAddress"
        Me.btnDeleteAddress.Size = New System.Drawing.Size(64, 23)
        Me.btnDeleteAddress.TabIndex = 3
        Me.btnDeleteAddress.Text = "Delete"
        '
        'btnAddAddress
        '
        Me.btnAddAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddAddress.Location = New System.Drawing.Point(8, 610)
        Me.btnAddAddress.Name = "btnAddAddress"
        Me.btnAddAddress.Size = New System.Drawing.Size(58, 23)
        Me.btnAddAddress.TabIndex = 2
        Me.btnAddAddress.Text = "Add"
        '
        'tabDocuments
        '
        Me.tabDocuments.Controls.Add(Me.pnlDocuments)
        Me.tabDocuments.Location = New System.Drawing.Point(4, 22)
        Me.tabDocuments.Name = "tabDocuments"
        Me.tabDocuments.Size = New System.Drawing.Size(1072, 640)
        Me.tabDocuments.TabIndex = 2
        Me.tabDocuments.Text = "Documents"
        '
        'pnlDocuments
        '
        Me.pnlDocuments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDocuments.Location = New System.Drawing.Point(0, 0)
        Me.pnlDocuments.Name = "pnlDocuments"
        Me.pnlDocuments.Size = New System.Drawing.Size(1072, 642)
        Me.pnlDocuments.TabIndex = 1
        '
        'tabQuotes
        '
        Me.tabQuotes.Controls.Add(Me.pnlQuotes)
        Me.tabQuotes.Location = New System.Drawing.Point(4, 22)
        Me.tabQuotes.Name = "tabQuotes"
        Me.tabQuotes.Size = New System.Drawing.Size(1072, 640)
        Me.tabQuotes.TabIndex = 7
        Me.tabQuotes.Text = "Quotes"
        '
        'pnlQuotes
        '
        Me.pnlQuotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlQuotes.Location = New System.Drawing.Point(0, 0)
        Me.pnlQuotes.Name = "pnlQuotes"
        Me.pnlQuotes.Size = New System.Drawing.Size(1072, 640)
        Me.pnlQuotes.TabIndex = 1
        '
        'tabContracts
        '
        Me.tabContracts.Controls.Add(Me.gpbContracts)
        Me.tabContracts.Location = New System.Drawing.Point(4, 22)
        Me.tabContracts.Name = "tabContracts"
        Me.tabContracts.Size = New System.Drawing.Size(1072, 640)
        Me.tabContracts.TabIndex = 9
        Me.tabContracts.Text = "Contracts"
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
        Me.gpbContracts.Size = New System.Drawing.Size(1056, 626)
        Me.gpbContracts.TabIndex = 1
        Me.gpbContracts.TabStop = False
        Me.gpbContracts.Text = "Contract - Double click to view"
        '
        'btnDeleteContract
        '
        Me.btnDeleteContract.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteContract.Location = New System.Drawing.Point(973, 594)
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
        Me.dgContracts.Location = New System.Drawing.Point(8, 20)
        Me.dgContracts.Name = "dgContracts"
        Me.dgContracts.Size = New System.Drawing.Size(1040, 566)
        Me.dgContracts.TabIndex = 1
        '
        'btnAddContract
        '
        Me.btnAddContract.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddContract.Location = New System.Drawing.Point(8, 594)
        Me.btnAddContract.Name = "btnAddContract"
        Me.btnAddContract.Size = New System.Drawing.Size(75, 23)
        Me.btnAddContract.TabIndex = 0
        Me.btnAddContract.Text = "Add"
        Me.btnAddContract.UseVisualStyleBackColor = True
        '
        'tpNotes
        '
        Me.tpNotes.Controls.Add(Me.gpbNotesDetails)
        Me.tpNotes.Controls.Add(Me.gpbNotes)
        Me.tpNotes.Location = New System.Drawing.Point(4, 22)
        Me.tpNotes.Name = "tpNotes"
        Me.tpNotes.Padding = New System.Windows.Forms.Padding(3)
        Me.tpNotes.Size = New System.Drawing.Size(1072, 640)
        Me.tpNotes.TabIndex = 10
        Me.tpNotes.Text = "Notes"
        '
        'gpbNotesDetails
        '
        Me.gpbNotesDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbNotesDetails.Controls.Add(Me.txtNoteID)
        Me.gpbNotesDetails.Controls.Add(Me.btnSaveNote)
        Me.gpbNotesDetails.Controls.Add(Me.txtNote)
        Me.gpbNotesDetails.Controls.Add(Me.Label15)
        Me.gpbNotesDetails.Location = New System.Drawing.Point(6, 451)
        Me.gpbNotesDetails.Name = "gpbNotesDetails"
        Me.gpbNotesDetails.Size = New System.Drawing.Size(1060, 183)
        Me.gpbNotesDetails.TabIndex = 34
        Me.gpbNotesDetails.TabStop = False
        Me.gpbNotesDetails.Text = "Details"
        '
        'txtNoteID
        '
        Me.txtNoteID.Location = New System.Drawing.Point(66, 14)
        Me.txtNoteID.Name = "txtNoteID"
        Me.txtNoteID.Size = New System.Drawing.Size(100, 21)
        Me.txtNoteID.TabIndex = 36
        Me.txtNoteID.TabStop = False
        Me.txtNoteID.Visible = False
        '
        'btnSaveNote
        '
        Me.btnSaveNote.AccessibleDescription = ""
        Me.btnSaveNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveNote.Location = New System.Drawing.Point(975, 154)
        Me.btnSaveNote.Name = "btnSaveNote"
        Me.btnSaveNote.Size = New System.Drawing.Size(79, 23)
        Me.btnSaveNote.TabIndex = 1
        Me.btnSaveNote.Text = "Save"
        '
        'txtNote
        '
        Me.txtNote.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNote.Location = New System.Drawing.Point(6, 37)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNote.Size = New System.Drawing.Size(1048, 111)
        Me.txtNote.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(3, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 23)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "Note:"
        '
        'gpbNotes
        '
        Me.gpbNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbNotes.Controls.Add(Me.btnDeleteNote)
        Me.gpbNotes.Controls.Add(Me.dgNotes)
        Me.gpbNotes.Controls.Add(Me.btnAddNote)
        Me.gpbNotes.Location = New System.Drawing.Point(6, 6)
        Me.gpbNotes.Name = "gpbNotes"
        Me.gpbNotes.Size = New System.Drawing.Size(1060, 439)
        Me.gpbNotes.TabIndex = 31
        Me.gpbNotes.TabStop = False
        Me.gpbNotes.Text = "Notes"
        '
        'btnDeleteNote
        '
        Me.btnDeleteNote.AccessibleDescription = ""
        Me.btnDeleteNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteNote.Location = New System.Drawing.Point(969, 410)
        Me.btnDeleteNote.Name = "btnDeleteNote"
        Me.btnDeleteNote.Size = New System.Drawing.Size(85, 23)
        Me.btnDeleteNote.TabIndex = 3
        Me.btnDeleteNote.Text = "Delete"
        Me.btnDeleteNote.Visible = False
        '
        'dgNotes
        '
        Me.dgNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgNotes.DataMember = ""
        Me.dgNotes.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgNotes.Location = New System.Drawing.Point(6, 20)
        Me.dgNotes.Name = "dgNotes"
        Me.dgNotes.Size = New System.Drawing.Size(1048, 384)
        Me.dgNotes.TabIndex = 1
        '
        'btnAddNote
        '
        Me.btnAddNote.AccessibleDescription = ""
        Me.btnAddNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddNote.Location = New System.Drawing.Point(6, 410)
        Me.btnAddNote.Name = "btnAddNote"
        Me.btnAddNote.Size = New System.Drawing.Size(85, 23)
        Me.btnAddNote.TabIndex = 2
        Me.btnAddNote.Text = "Add"
        '
        'tabAuthority
        '
        Me.tabAuthority.Controls.Add(Me.grpSiteAuth)
        Me.tabAuthority.Controls.Add(Me.gpCustAuth)
        Me.tabAuthority.Controls.Add(Me.grpAudit)
        Me.tabAuthority.Location = New System.Drawing.Point(4, 22)
        Me.tabAuthority.Name = "tabAuthority"
        Me.tabAuthority.Size = New System.Drawing.Size(1072, 640)
        Me.tabAuthority.TabIndex = 11
        Me.tabAuthority.Text = "Authority"
        Me.tabAuthority.UseVisualStyleBackColor = True
        '
        'grpSiteAuth
        '
        Me.grpSiteAuth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSiteAuth.Controls.Add(Me.btnSaveAuth)
        Me.grpSiteAuth.Controls.Add(Me.txtSiteAuth)
        Me.grpSiteAuth.Location = New System.Drawing.Point(3, 117)
        Me.grpSiteAuth.Name = "grpSiteAuth"
        Me.grpSiteAuth.Size = New System.Drawing.Size(1060, 207)
        Me.grpSiteAuth.TabIndex = 37
        Me.grpSiteAuth.TabStop = False
        Me.grpSiteAuth.Text = "Site"
        '
        'btnSaveAuth
        '
        Me.btnSaveAuth.AccessibleDescription = ""
        Me.btnSaveAuth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveAuth.Location = New System.Drawing.Point(969, 178)
        Me.btnSaveAuth.Name = "btnSaveAuth"
        Me.btnSaveAuth.Size = New System.Drawing.Size(85, 23)
        Me.btnSaveAuth.TabIndex = 3
        Me.btnSaveAuth.Text = "Save"
        '
        'txtSiteAuth
        '
        Me.txtSiteAuth.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSiteAuth.Location = New System.Drawing.Point(6, 20)
        Me.txtSiteAuth.Multiline = True
        Me.txtSiteAuth.Name = "txtSiteAuth"
        Me.txtSiteAuth.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSiteAuth.Size = New System.Drawing.Size(1048, 152)
        Me.txtSiteAuth.TabIndex = 0
        '
        'gpCustAuth
        '
        Me.gpCustAuth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpCustAuth.Controls.Add(Me.txtCustAuthority)
        Me.gpCustAuth.Location = New System.Drawing.Point(3, 3)
        Me.gpCustAuth.Name = "gpCustAuth"
        Me.gpCustAuth.Size = New System.Drawing.Size(1060, 108)
        Me.gpCustAuth.TabIndex = 36
        Me.gpCustAuth.TabStop = False
        Me.gpCustAuth.Text = "Customer"
        '
        'txtCustAuthority
        '
        Me.txtCustAuthority.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustAuthority.Location = New System.Drawing.Point(6, 20)
        Me.txtCustAuthority.Multiline = True
        Me.txtCustAuthority.Name = "txtCustAuthority"
        Me.txtCustAuthority.ReadOnly = True
        Me.txtCustAuthority.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCustAuthority.Size = New System.Drawing.Size(1048, 82)
        Me.txtCustAuthority.TabIndex = 0
        '
        'grpAudit
        '
        Me.grpAudit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAudit.Controls.Add(Me.dgAuthorityAudit)
        Me.grpAudit.Location = New System.Drawing.Point(3, 330)
        Me.grpAudit.Name = "grpAudit"
        Me.grpAudit.Size = New System.Drawing.Size(1060, 307)
        Me.grpAudit.TabIndex = 35
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
        Me.dgAuthorityAudit.Size = New System.Drawing.Size(1048, 281)
        Me.dgAuthorityAudit.TabIndex = 1
        '
        'tpAdditionalDetails
        '
        Me.tpAdditionalDetails.BackColor = System.Drawing.SystemColors.Control
        Me.tpAdditionalDetails.Controls.Add(Me.grpAdditionalDetails)
        Me.tpAdditionalDetails.Location = New System.Drawing.Point(4, 22)
        Me.tpAdditionalDetails.Name = "tpAdditionalDetails"
        Me.tpAdditionalDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAdditionalDetails.Size = New System.Drawing.Size(1072, 640)
        Me.tpAdditionalDetails.TabIndex = 12
        Me.tpAdditionalDetails.Text = "Additional Details"
        '
        'grpAdditionalDetails
        '
        Me.grpAdditionalDetails.Controls.Add(Me.btnLetterReport)
        Me.grpAdditionalDetails.Controls.Add(Me.cboReasonForContact)
        Me.grpAdditionalDetails.Controls.Add(Me.Label11)
        Me.grpAdditionalDetails.Controls.Add(Me.Label13)
        Me.grpAdditionalDetails.Controls.Add(Me.cboSourceOfCustomer)
        Me.grpAdditionalDetails.Controls.Add(Me.txtEstateOfficer)
        Me.grpAdditionalDetails.Controls.Add(Me.lblEstateOfficer)
        Me.grpAdditionalDetails.Controls.Add(Me.txtHousingManager)
        Me.grpAdditionalDetails.Controls.Add(Me.lblHousingManager)
        Me.grpAdditionalDetails.Controls.Add(Me.txtHousingOfficer)
        Me.grpAdditionalDetails.Controls.Add(Me.lblHousingOfficer)
        Me.grpAdditionalDetails.Controls.Add(Me.dtpBuildDate)
        Me.grpAdditionalDetails.Controls.Add(Me.lblBuildDate)
        Me.grpAdditionalDetails.Controls.Add(Me.txtWarrantyPeriod)
        Me.grpAdditionalDetails.Controls.Add(Me.lblWarrantyPeriod)
        Me.grpAdditionalDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpAdditionalDetails.Location = New System.Drawing.Point(3, 3)
        Me.grpAdditionalDetails.Name = "grpAdditionalDetails"
        Me.grpAdditionalDetails.Size = New System.Drawing.Size(1066, 634)
        Me.grpAdditionalDetails.TabIndex = 0
        Me.grpAdditionalDetails.TabStop = False
        Me.grpAdditionalDetails.Text = "Additional Details"
        '
        'btnLetterReport
        '
        Me.btnLetterReport.Location = New System.Drawing.Point(586, 29)
        Me.btnLetterReport.Name = "btnLetterReport"
        Me.btnLetterReport.Size = New System.Drawing.Size(145, 23)
        Me.btnLetterReport.TabIndex = 132
        Me.btnLetterReport.Text = "Letter Report"
        '
        'cboReasonForContact
        '
        Me.cboReasonForContact.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboReasonForContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReasonForContact.Location = New System.Drawing.Point(136, 31)
        Me.cboReasonForContact.Name = "cboReasonForContact"
        Me.cboReasonForContact.Size = New System.Drawing.Size(149, 21)
        Me.cboReasonForContact.TabIndex = 131
        Me.cboReasonForContact.Tag = "Site.RegionID"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(315, 34)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 23)
        Me.Label11.TabIndex = 128
        Me.Label11.Text = "Source"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(16, 34)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(129, 23)
        Me.Label13.TabIndex = 130
        Me.Label13.Text = "Reason For Contact"
        '
        'cboSourceOfCustomer
        '
        Me.cboSourceOfCustomer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboSourceOfCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSourceOfCustomer.Location = New System.Drawing.Point(404, 31)
        Me.cboSourceOfCustomer.Name = "cboSourceOfCustomer"
        Me.cboSourceOfCustomer.Size = New System.Drawing.Size(145, 21)
        Me.cboSourceOfCustomer.TabIndex = 129
        Me.cboSourceOfCustomer.Tag = "Site.RegionID"
        '
        'txtEstateOfficer
        '
        Me.txtEstateOfficer.Location = New System.Drawing.Point(404, 114)
        Me.txtEstateOfficer.MaxLength = 100
        Me.txtEstateOfficer.Name = "txtEstateOfficer"
        Me.txtEstateOfficer.Size = New System.Drawing.Size(145, 21)
        Me.txtEstateOfficer.TabIndex = 124
        Me.txtEstateOfficer.Tag = ""
        '
        'lblEstateOfficer
        '
        Me.lblEstateOfficer.Location = New System.Drawing.Point(315, 117)
        Me.lblEstateOfficer.Name = "lblEstateOfficer"
        Me.lblEstateOfficer.Size = New System.Drawing.Size(99, 20)
        Me.lblEstateOfficer.TabIndex = 123
        Me.lblEstateOfficer.Text = "Estate Officer"
        '
        'txtHousingManager
        '
        Me.txtHousingManager.Location = New System.Drawing.Point(136, 154)
        Me.txtHousingManager.MaxLength = 100
        Me.txtHousingManager.Name = "txtHousingManager"
        Me.txtHousingManager.Size = New System.Drawing.Size(149, 21)
        Me.txtHousingManager.TabIndex = 122
        Me.txtHousingManager.Tag = ""
        '
        'lblHousingManager
        '
        Me.lblHousingManager.Location = New System.Drawing.Point(16, 157)
        Me.lblHousingManager.Name = "lblHousingManager"
        Me.lblHousingManager.Size = New System.Drawing.Size(110, 20)
        Me.lblHousingManager.TabIndex = 121
        Me.lblHousingManager.Text = "Housing Manager"
        '
        'txtHousingOfficer
        '
        Me.txtHousingOfficer.Location = New System.Drawing.Point(136, 114)
        Me.txtHousingOfficer.MaxLength = 100
        Me.txtHousingOfficer.Name = "txtHousingOfficer"
        Me.txtHousingOfficer.Size = New System.Drawing.Size(149, 21)
        Me.txtHousingOfficer.TabIndex = 118
        Me.txtHousingOfficer.Tag = ""
        '
        'lblHousingOfficer
        '
        Me.lblHousingOfficer.Location = New System.Drawing.Point(16, 117)
        Me.lblHousingOfficer.Name = "lblHousingOfficer"
        Me.lblHousingOfficer.Size = New System.Drawing.Size(99, 20)
        Me.lblHousingOfficer.TabIndex = 117
        Me.lblHousingOfficer.Text = "Housing Officer"
        '
        'dtpBuildDate
        '
        Me.dtpBuildDate.Location = New System.Drawing.Point(136, 71)
        Me.dtpBuildDate.Name = "dtpBuildDate"
        Me.dtpBuildDate.Size = New System.Drawing.Size(149, 21)
        Me.dtpBuildDate.TabIndex = 116
        Me.dtpBuildDate.Value = New Date(2019, 5, 22, 14, 54, 59, 0)
        '
        'lblBuildDate
        '
        Me.lblBuildDate.Location = New System.Drawing.Point(16, 77)
        Me.lblBuildDate.Name = "lblBuildDate"
        Me.lblBuildDate.Size = New System.Drawing.Size(88, 20)
        Me.lblBuildDate.TabIndex = 115
        Me.lblBuildDate.Text = "Build Date"
        '
        'txtWarrantyPeriod
        '
        Me.txtWarrantyPeriod.Location = New System.Drawing.Point(477, 74)
        Me.txtWarrantyPeriod.MaxLength = 100
        Me.txtWarrantyPeriod.Name = "txtWarrantyPeriod"
        Me.txtWarrantyPeriod.Size = New System.Drawing.Size(72, 21)
        Me.txtWarrantyPeriod.TabIndex = 114
        Me.txtWarrantyPeriod.Tag = ""
        '
        'lblWarrantyPeriod
        '
        Me.lblWarrantyPeriod.Location = New System.Drawing.Point(315, 77)
        Me.lblWarrantyPeriod.Name = "lblWarrantyPeriod"
        Me.lblWarrantyPeriod.Size = New System.Drawing.Size(141, 20)
        Me.lblWarrantyPeriod.TabIndex = 113
        Me.lblWarrantyPeriod.Text = "Warranty Period (mths)"
        '
        'cmsJobs
        '
        Me.cmsJobs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiMoveJob})
        Me.cmsJobs.Name = "cmsJobs"
        Me.cmsJobs.Size = New System.Drawing.Size(126, 26)
        '
        'tsmiMoveJob
        '
        Me.tsmiMoveJob.Name = "tsmiMoveJob"
        Me.tsmiMoveJob.Size = New System.Drawing.Size(125, 22)
        Me.tsmiMoveJob.Text = "Move Job"
        '
        'UCSite
        '
        Me.Controls.Add(Me.tcSites)
        Me.Name = "UCSite"
        Me.Size = New System.Drawing.Size(1080, 666)
        Me.tcSites.ResumeLayout(False)
        Me.tabDetails.ResumeLayout(False)
        Me.grpSiteFuel.ResumeLayout(False)
        CType(Me.dgSiteFuel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSite.ResumeLayout(False)
        Me.grpSite.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgJobs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabNewContacts.ResumeLayout(False)
        Me.tabCharges.ResumeLayout(False)
        Me.gpbCharges.ResumeLayout(False)
        Me.gpbCharges.PerformLayout()
        Me.tabContacts.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgContacts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabInvoiceAddress.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgInvoiceAddresses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDocuments.ResumeLayout(False)
        Me.tabQuotes.ResumeLayout(False)
        Me.tabContracts.ResumeLayout(False)
        Me.gpbContracts.ResumeLayout(False)
        CType(Me.dgContracts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpNotes.ResumeLayout(False)
        Me.gpbNotesDetails.ResumeLayout(False)
        Me.gpbNotesDetails.PerformLayout()
        Me.gpbNotes.ResumeLayout(False)
        CType(Me.dgNotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAuthority.ResumeLayout(False)
        Me.grpSiteAuth.ResumeLayout(False)
        Me.grpSiteAuth.PerformLayout()
        Me.gpCustAuth.ResumeLayout(False)
        Me.gpCustAuth.PerformLayout()
        Me.grpAudit.ResumeLayout(False)
        CType(Me.dgAuthorityAudit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpAdditionalDetails.ResumeLayout(False)
        Me.grpAdditionalDetails.ResumeLayout(False)
        Me.grpAdditionalDetails.PerformLayout()
        Me.cmsJobs.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)

        Me.tcSites.TabPages.Clear()
        Me.tcSites.TabPages.Add(Me.tabDetails)
        If IsGasway Then
            Me.tcSites.TabPages.Add(Me.tabContracts)
            Me.tcSites.TabPages.Add(Me.tabQuotes)
            Me.tcSites.TabPages.Add(Me.tabCharges)
        End If
        Me.tcSites.TabPages.Add(Me.TabNewContacts)
        Me.tcSites.TabPages.Add(Me.tabContacts)
        Me.tcSites.TabPages.Add(Me.tabInvoiceAddress)
        Me.tcSites.TabPages.Add(Me.tabDocuments)
        Me.tcSites.TabPages.Add(Me.tpNotes)
        Me.tcSites.TabPages.Add(Me.tabAuthority)
        Me.tcSites.TabPages.Add(Me.tpAdditionalDetails)

        ContactControl = New UCContacts(CurrentSite)
        Me.pnlContactsMain.Controls.Add(ContactControl)

        SetupContactDataGrid()
        SetupInvoiceAddressDataGrid()
        SetupJobsDataGrid()
        SetupSiteFuelDataGrid()
        SetupContractsDataGrid()
        SetupNotesDataGrid()
        SetupSiteAuthorityAuditDataGrid()
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentSite
        End Get
    End Property

#End Region

#Region "Properties"

    Private DocumentsControl As UCDocumentsList
    Private QuotesControl As UCQuotesList
    Private CustomerScheduleOfRateControl As UCCustomerScheduleOfRate
    Private ContactControl As UCContacts

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _FromForm As Form

    Public Property FromForm() As Form
        Get
            Return _FromForm
        End Get
        Set(ByVal value As Form)
            _FromForm = value
        End Set
    End Property

    Private _currentCustomer As Entity.Customers.Customer

    Public Property CurrentCustomer() As Entity.Customers.Customer
        Get
            Return _currentCustomer
        End Get
        Set(ByVal Value As Entity.Customers.Customer)
            _currentCustomer = Value
            If _currentCustomer Is Nothing Then
                _currentCustomer = New Entity.Customers.Customer
                _currentCustomer.Exists = False
                Dim settings As New Entity.Management.Settings
                settings = DB.Manager.Get()
                _currentCustomer.SetAcceptChargesChanges = True
            End If
            If _currentCustomer.Exists Then
            Else
                Me.gpbContracts.Enabled = False
            End If
        End Set
    End Property

    Private _currentSite As Entity.Sites.Site

    Public Property CurrentSite() As Entity.Sites.Site
        Get
            Return _currentSite
        End Get
        Set(ByVal Value As Entity.Sites.Site)
            _currentSite = Value

            If IsRFT Then
                btnDomestic.Visible = False
                btnConvCust.Visible = False
                btnLetterReport.Visible = False
                chkSolidFuel.Visible = False
                btnAddModifyPlan.Visible = False
                tcSites.TabPages.Remove(tabQuotes)
            End If

            If CurrentSite Is Nothing Then
                _currentSite = New Entity.Sites.Site
                _currentSite.Exists = False
                Dim customerCharges As New Entity.CustomerCharges.CustomerCharge
                customerCharges = DB.CustomerCharge.CustomerCharge_GetForCustomer(CurrentCustomerID)
                If Not customerCharges Is Nothing Then
                    Me.txtMileageRate.Text = customerCharges.MileageRate
                    Me.txtPartsMarkup.Text = customerCharges.PartsMarkup
                    Me.txtRatesMarkup.Text = customerCharges.RatesMarkup
                Else
                    Dim sysCharges As New Entity.Management.Settings
                    sysCharges = DB.Manager.Get
                    Me.txtMileageRate.Text = sysCharges.MileageRate
                    Me.txtPartsMarkup.Text = sysCharges.PartsMarkup
                    Me.txtRatesMarkup.Text = sysCharges.RatesMarkup
                End If

                Me.btnAddAddress.Enabled = False
                Me.btnDeleteAddress.Enabled = False
                Me.btnAddContact.Enabled = False
                Me.btnDeleteContact.Enabled = False
                Me.btnAddJob.Enabled = False
                Me.btnRemoveJob.Enabled = False
                Me.chbAcceptChargeChanges.Checked = True
                If CurrentCustomerID > 0 Then
                    CurrentSite.SetCustomerID = CurrentCustomerID
                    PopulateCustomerField()
                End If
            End If

            If CurrentSite.Exists Then
                CurrentCustomer = DB.Customer.Customer_Get(CurrentSite.CustomerID)
                Populate()
                Me.pnlDocuments.Controls.Clear()
                DocumentsControl = New UCDocumentsList(Entity.Sys.Enums.TableNames.tblSite, CurrentSite.SiteID)
                Me.pnlDocuments.Controls.Add(DocumentsControl)

                Me.pnlQuotes.Controls.Clear()
                QuotesControl = New UCQuotesList(Entity.Sys.Enums.TableNames.tblSite, CurrentSite.CustomerID, CurrentSite.SiteID)
                AddHandler QuotesControl.RefreshJobs, AddressOf PopulateJobs
                Me.pnlQuotes.Controls.Add(QuotesControl)

                Me.pnlCharges.Controls.Clear()
                CustomerScheduleOfRateControl = New UCCustomerScheduleOfRate(Enums.TableNames.tblCustomer, CurrentSite.CustomerID, True)
                Me.pnlCharges.Controls.Add(CustomerScheduleOfRateControl)

                Contracts = DB.ContractOriginal.GetAll_ForSite(CurrentSite.SiteID)
                Me.gpbContracts.Enabled = True

                Me.btnAddAddress.Enabled = True
                Me.btnDeleteAddress.Enabled = True
                Me.btnAddContact.Enabled = True
                Me.btnDeleteContact.Enabled = True
                Me.btnAddJob.Enabled = True
                Me.btnRemoveJob.Enabled = True
                Me.cboSourceOfCustomer.Enabled = False
                Me.cboReasonForContact.Enabled = False

                PopulateSiteNotes()
                Me.gpbNotes.Enabled = True
                Me.gpbNotesDetails.Enabled = True
                Me.btnSaveNote.Enabled = True
                Me.btnAddNote.Enabled = True
                Me.btnDeleteNote.Enabled = True
                Me.btnLetterReport.Enabled = True
            Else
                Me.cboSourceOfCustomer.Enabled = True
                Me.cboReasonForContact.Enabled = True

                Me.gpbNotes.Enabled = False
                Me.gpbNotesDetails.Enabled = False
                Me.btnSaveNote.Enabled = False
                Me.btnAddNote.Enabled = False
                Me.btnDeleteNote.Enabled = False
                Me.btnLetterReport.Enabled = False
            End If

            PopulateContacts()
            PopulateInvoiceAddresses()
            PopulateJobs()
        End Set
    End Property

    Private _dInvoiceTable As DataView = Nothing

    Public Property InvoiceAddressDataView() As DataView
        Get
            Return _dInvoiceTable
        End Get
        Set(ByVal Value As DataView)
            _dInvoiceTable = Value
            _dInvoiceTable.Table.TableName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString
            _dInvoiceTable.AllowNew = False
            _dInvoiceTable.AllowEdit = False
            _dInvoiceTable.AllowDelete = False
            Me.dgInvoiceAddresses.DataSource = InvoiceAddressDataView
        End Set
    End Property

    Private ReadOnly Property SelectedInvoiceAddressDataRow() As DataRow
        Get
            If Not Me.dgInvoiceAddresses.CurrentRowIndex = -1 Then
                Return InvoiceAddressDataView(Me.dgInvoiceAddresses.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _dcontactTable As DataView = Nothing

    Public Property ContactsDataView() As DataView
        Get
            Return _dcontactTable
        End Get
        Set(ByVal Value As DataView)
            _dcontactTable = Value
            _dcontactTable.Table.TableName = Entity.Sys.Enums.TableNames.tblContact.ToString
            _dcontactTable.AllowNew = False
            _dcontactTable.AllowEdit = False
            _dcontactTable.AllowDelete = False
            Me.dgContacts.DataSource = ContactsDataView
        End Set
    End Property

    Private ReadOnly Property SelectedContactDataRow() As DataRow
        Get
            If Not Me.dgContacts.CurrentRowIndex = -1 Then
                Return ContactsDataView(Me.dgContacts.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _jobsTable As DataView = Nothing

    Public Property JobsDataView() As DataView
        Get
            Return _jobsTable
        End Get
        Set(ByVal Value As DataView)
            _jobsTable = Value
            _jobsTable.Table.TableName = Entity.Sys.Enums.TableNames.tblJob.ToString
            _jobsTable.AllowNew = False
            _jobsTable.AllowEdit = False
            _jobsTable.AllowDelete = False
            Me.dgJobs.DataSource = JobsDataView
        End Set
    End Property

    Private ReadOnly Property SelectedJobDataRow() As DataRow
        Get
            If Not Me.dgJobs.CurrentRowIndex = -1 Then
                Return JobsDataView(Me.dgJobs.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _theCustomer As Entity.Customers.Customer

    Private Property theCustomer() As Entity.Customers.Customer
        Get
            Return _theCustomer
        End Get
        Set(ByVal Value As Entity.Customers.Customer)
            _theCustomer = Value
        End Set
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

    Private _SelectedCustomerID As Integer = 0

    Private Property SelectedCustomerID() As Integer
        Get
            Return _SelectedCustomerID
        End Get
        Set(ByVal Value As Integer)
            _SelectedCustomerID = Value
        End Set
    End Property

    Private _oSiteAuthority As Entity.Authority.Authority

    Public Property SiteAuthority() As Entity.Authority.Authority
        Get
            Return _oSiteAuthority
        End Get
        Set(value As Entity.Authority.Authority)
            _oSiteAuthority = value
        End Set
    End Property

    Private FlagShown As Boolean = False

#End Region

#Region "Setup"

    Public Sub SetupContactDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgContacts)
        Dim tStyle As DataGridTableStyle = Me.dgContacts.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim FirstName As New DataGridLabelColumn
        FirstName.Format = ""
        FirstName.FormatInfo = Nothing
        FirstName.HeaderText = "First Name"
        FirstName.MappingName = "FirstName"
        FirstName.ReadOnly = True
        FirstName.Width = 160
        FirstName.NullText = ""
        tStyle.GridColumnStyles.Add(FirstName)

        Dim Surname As New DataGridLabelColumn
        Surname.Format = ""
        Surname.FormatInfo = Nothing
        Surname.HeaderText = "Surname"
        Surname.MappingName = "Surname"
        Surname.ReadOnly = True
        Surname.Width = 160
        Surname.NullText = ""
        tStyle.GridColumnStyles.Add(Surname)

        Dim Email As New DataGridLabelColumn
        Email.Format = ""
        Email.FormatInfo = Nothing
        Email.HeaderText = "Email"
        Email.MappingName = "EmailAddress"
        Email.ReadOnly = True
        Email.Width = 120
        Email.NullText = ""
        tStyle.GridColumnStyles.Add(Email)

        Dim TelephoneNum As New DataGridLabelColumn
        TelephoneNum.Format = ""
        TelephoneNum.FormatInfo = Nothing
        TelephoneNum.HeaderText = "Telephone Number"
        TelephoneNum.MappingName = "TelephoneNum"
        TelephoneNum.ReadOnly = True
        TelephoneNum.Width = 100
        TelephoneNum.NullText = ""
        tStyle.GridColumnStyles.Add(TelephoneNum)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblContact.ToString
        Me.dgContacts.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupInvoiceAddressDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgInvoiceAddresses)
        Dim tStyle As DataGridTableStyle = Me.dgInvoiceAddresses.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Address1 As New DataGridLabelColumn
        Address1.Format = ""
        Address1.FormatInfo = Nothing
        Address1.HeaderText = "Address 1"
        Address1.MappingName = "Address1"
        Address1.ReadOnly = True
        Address1.Width = 100
        Address1.NullText = ""
        tStyle.GridColumnStyles.Add(Address1)

        Dim Address2 As New DataGridLabelColumn
        Address2.Format = ""
        Address2.FormatInfo = Nothing
        Address2.HeaderText = "Address 2"
        Address2.MappingName = "Address2"
        Address2.ReadOnly = True
        Address2.Width = 100
        Address2.NullText = ""
        tStyle.GridColumnStyles.Add(Address2)

        Dim Address3 As New DataGridLabelColumn
        Address3.Format = ""
        Address3.FormatInfo = Nothing
        Address3.HeaderText = "Address 3"
        Address3.MappingName = "Address3"
        Address3.ReadOnly = True
        Address3.Width = 100
        Address3.NullText = ""
        tStyle.GridColumnStyles.Add(Address3)

        Dim Address4 As New DataGridLabelColumn
        Address4.Format = ""
        Address4.FormatInfo = Nothing
        Address4.HeaderText = "Address 4"
        Address4.MappingName = "Address4"
        Address4.ReadOnly = True
        Address4.Width = 100
        Address4.NullText = ""
        tStyle.GridColumnStyles.Add(Address4)

        Dim Address5 As New DataGridLabelColumn
        Address5.Format = ""
        Address5.FormatInfo = Nothing
        Address5.HeaderText = "Address5"
        Address5.MappingName = "Address5"
        Address5.ReadOnly = True
        Address5.Width = 100
        Address5.NullText = ""
        tStyle.GridColumnStyles.Add(Address5)

        Dim Postcode As New DataGridLabelColumn
        Postcode.Format = ""
        Postcode.FormatInfo = Nothing
        Postcode.HeaderText = "Postcode"
        Postcode.MappingName = "Postcode"
        Postcode.ReadOnly = True
        Postcode.Width = 75
        Postcode.NullText = ""
        tStyle.GridColumnStyles.Add(Postcode)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString
        Me.dgInvoiceAddresses.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupJobsDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgJobs)
        Dim tStyle As DataGridTableStyle = Me.dgJobs.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim DateCreated As New DataGridLabelColumn
        DateCreated.Format = "dd/MM/yyyy"
        DateCreated.FormatInfo = Nothing
        DateCreated.HeaderText = "Created"
        DateCreated.MappingName = "DateCreated"
        DateCreated.ReadOnly = True
        DateCreated.Width = 75
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
        Type.Width = 75
        Type.NullText = Entity.Sys.Enums.ComboValues.Not_Applicable.ToString.Replace("_", " ")
        tStyle.GridColumnStyles.Add(Type)

        Dim VisitStatus As New DataGridLabelColumn
        VisitStatus.Format = ""
        VisitStatus.FormatInfo = Nothing
        VisitStatus.HeaderText = "Visit Status"
        VisitStatus.MappingName = "VisitStatus"
        VisitStatus.ReadOnly = True
        VisitStatus.Width = 75
        VisitStatus.NullText = ""
        tStyle.GridColumnStyles.Add(VisitStatus)

        Dim LastVisitDate As New DataGridLabelColumn
        LastVisitDate.Format = "dd/MM/yyyy"
        LastVisitDate.FormatInfo = Nothing
        LastVisitDate.HeaderText = "Last Visit's Date"
        LastVisitDate.MappingName = "LastVisitDate"
        LastVisitDate.ReadOnly = True
        LastVisitDate.Width = 100
        LastVisitDate.NullText = ""
        tStyle.GridColumnStyles.Add(LastVisitDate)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblJob.ToString
        Me.dgJobs.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupSiteFuelDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgSiteFuel)
        Dim tStyle As DataGridTableStyle = Me.dgSiteFuel.TableStyles(0)

        Dim fuelType As New DataGridSiteFuelColumn
        fuelType.Format = ""
        fuelType.FormatInfo = Nothing
        fuelType.HeaderText = "Fuel Type"
        fuelType.MappingName = "FuelType"
        fuelType.ReadOnly = True
        fuelType.Width = 100
        fuelType.NullText = ""
        tStyle.GridColumnStyles.Add(fuelType)

        Dim serviceDue As New DataGridSiteFuelColumn
        serviceDue.Format = "dd/MM/yyyy"
        serviceDue.FormatInfo = Nothing
        serviceDue.HeaderText = "Service Due"
        serviceDue.MappingName = "ServiceDue"
        serviceDue.ReadOnly = True
        serviceDue.Width = 105
        serviceDue.NullText = "N/A"
        tStyle.GridColumnStyles.Add(serviceDue)

        Dim lastServiceDate As New DataGridSiteFuelColumn
        lastServiceDate.Format = "dd/MM/yyyy"
        lastServiceDate.FormatInfo = Nothing
        lastServiceDate.HeaderText = "Service Date"
        lastServiceDate.MappingName = "ActualServiceDate"
        lastServiceDate.ReadOnly = True
        lastServiceDate.Width = 105
        lastServiceDate.NullText = "N/A"
        tStyle.GridColumnStyles.Add(lastServiceDate)

        Dim FuelChargeType As New DataGridSiteFuelColumn
        FuelChargeType.Format = "dd/MM/yyyy"
        FuelChargeType.FormatInfo = Nothing
        FuelChargeType.HeaderText = "Charge Type"
        FuelChargeType.MappingName = "FuelChargeType"
        FuelChargeType.ReadOnly = True
        FuelChargeType.Width = 170
        FuelChargeType.NullText = ""
        tStyle.GridColumnStyles.Add(FuelChargeType)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSiteFuel.ToString
        Me.dgSiteFuel.TableStyles.Add(tStyle)
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
        ContractStatus.Width = 100
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

        Dim PartCosts As New DataGridLabelColumn
        PartCosts.Format = "C"
        PartCosts.FormatInfo = Nothing
        PartCosts.HeaderText = "Material Costs"
        PartCosts.MappingName = "PartCosts"
        PartCosts.ReadOnly = True
        PartCosts.Width = 100
        PartCosts.NullText = ""
        tStyle.GridColumnStyles.Add(PartCosts)

        Dim LabourCosts As New DataGridLabelColumn
        LabourCosts.Format = "C"
        LabourCosts.FormatInfo = Nothing
        LabourCosts.HeaderText = "Labour Costs"
        LabourCosts.MappingName = "LabourCosts"
        LabourCosts.ReadOnly = True
        LabourCosts.Width = 100
        LabourCosts.NullText = ""
        tStyle.GridColumnStyles.Add(LabourCosts)

        Dim ContractPaymentIncome As New DataGridLabelColumn
        ContractPaymentIncome.Format = "C"
        ContractPaymentIncome.FormatInfo = Nothing
        ContractPaymentIncome.HeaderText = "Contract Payment Income"
        ContractPaymentIncome.MappingName = "ContractPaymentIncome"
        ContractPaymentIncome.ReadOnly = True
        ContractPaymentIncome.Width = 120
        ContractPaymentIncome.NullText = ""
        tStyle.GridColumnStyles.Add(ContractPaymentIncome)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblContract.ToString
        Me.dgContracts.TableStyles.Add(tStyle)
    End Sub

    Sub CheckServiceDate()
        If FlagShown = False Then
            If SiteFuelsDataView IsNot Nothing And Not CurrentSite.CommercialDistrict Then

                Dim message As String = String.Empty
                For Each fuel As DataRow In SiteFuelsDataView.Table.Rows
                    message += GenerateServiceMessage(Helper.MakeDateTimeValid(fuel("LastServiceDate")), Helper.MakeStringValid(fuel("FuelType")), message)
                Next

                If Helper.IsStringEmpty(message) Then
                    message += GenerateServiceMessage(Helper.MakeDateTimeValid(CurrentSite.LastServiceDate), Helper.MakeStringValid(CurrentSite.SiteFuel), message)
                End If

                If Not String.IsNullOrEmpty(message) Then
                    ShowMessage(message, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    FlagShown = True
                End If
            End If
        End If
    End Sub

    Private Function GenerateServiceMessage(ByVal serviceDate As DateTime, ByVal fuel As String, ByVal message As String) As String
        Dim nowdate As DateTime = Today
        Dim duedate As DateTime = nowdate.AddMonths(3)
        serviceDate = serviceDate.AddYears(1)
        fuel = If(Helper.IsStringEmpty(fuel), "N/A", fuel)
        If serviceDate >= nowdate And serviceDate <= duedate Then
            If Not String.IsNullOrEmpty(message) Then
                message += vbCrLf & vbCrLf
            End If
            message += fuel & " is due for service within the next 3 months"
        ElseIf (Not serviceDate = Date.MinValue.AddYears(1)) AndAlso DateHelper.IsBetweenDates(Now.AddYears(-3), Now, serviceDate) Then
            If Not String.IsNullOrEmpty(message) Then
                message += vbCrLf & vbCrLf
            End If
            message += fuel & " is Overdue"
        End If
        Return message
    End Function

#End Region

#Region "Events"

    Private Sub btnAddContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddContract.Click
        ShowForm(GetType(FRMContractOriginal), True, New Object() {0, Entity.Sys.Helper.MakeIntegerValid(CurrentSite.CustomerID), Entity.Sys.Helper.MakeIntegerValid(CurrentSite.SiteID)})
        Contracts = DB.ContractOriginal.GetAll_ForSite(CurrentSite.SiteID)
    End Sub

    Private Sub btnDeleteContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteContract.Click
        If SelectedContractDataRow Is Nothing Then
            Exit Sub
        End If

        If ShowMessage("Are you sure you want to delete this contract - any contract jobs not yet downloaded will be remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Dim deleteContract As Boolean = True
        deleteContract = DeleteOption1()

        If deleteContract Then
            Contracts = DB.ContractOriginal.GetAll_ForSite(CurrentSite.SiteID)
        Else
            ShowMessage("Cannot delete the contract - there are active jobs on properties", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub dgContracts_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgContracts.DoubleClick
        If SelectedContractDataRow Is Nothing Then
            Exit Sub
        End If

        ShowForm(GetType(FRMContractOriginal), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedContractDataRow.Item("ContractID")), Entity.Sys.Helper.MakeIntegerValid(CurrentSite.CustomerID)})

        Contracts = DB.ContractOriginal.GetAll_ForSite(CurrentSite.SiteID)
    End Sub

    Private Sub cboDefinition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDefinition.SelectedIndexChanged
        runFilters()
    End Sub

    Private Sub txtJobNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJobNumber.TextChanged
        runFilters()
    End Sub

    Private Sub dtpFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged
        runFilters()
    End Sub

    Private Sub dtpTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.ValueChanged
        runFilters()
    End Sub

    Private Sub btnShowAllJobs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowAllJobs.Click
        JobsDataView = DB.Job.Job_GetTop_For_Site(CurrentSite.SiteID, CurrentSite.CustomerID, 1000)
    End Sub

    Private Sub UCSite_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub dgContacts_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgContacts.DoubleClick
        If SelectedContactDataRow Is Nothing Then
            Exit Sub
        End If

        ShowForm(GetType(FRMContact), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedContactDataRow.Item("ContactID")), CurrentSite.SiteID, Me})
    End Sub

    Private Sub dgInvoiceAddresses_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgInvoiceAddresses.DoubleClick
        If SelectedInvoiceAddressDataRow Is Nothing Then
            Exit Sub
        End If

        ShowForm(GetType(FRMInvoiceAddress), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedInvoiceAddressDataRow.Item("InvoiceAddressID")), CurrentSite.SiteID, Me})
    End Sub

    Private Sub btnAddContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddContact.Click
        ShowForm(GetType(FRMContact), True, New Object() {0, CurrentSite.SiteID, Me})
    End Sub

    Private Sub btnAddAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAddress.Click
        ShowForm(GetType(FRMInvoiceAddress), True, New Object() {0, CurrentSite.SiteID, Me})
    End Sub

    Private Sub btnDeleteContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteContact.Click
        If SelectedContactDataRow Is Nothing Then
            ShowMessage("Please select a contact to delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If ShowMessage("Are you sure you want to delete the selected record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        DB.Contact.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedContactDataRow.Item("ContactID")))
        ContactsDataView = DB.Contact.Contact_GetForSite(CurrentSite.SiteID)
    End Sub

    Private Sub btnDeleteAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAddress.Click
        If SelectedInvoiceAddressDataRow Is Nothing Then
            ShowMessage("Please select an invoice address to delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If ShowMessage("Are you sure you want to delete the selected record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        DB.InvoiceAddress.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedInvoiceAddressDataRow.Item("InvoiceAddressID")))
        InvoiceAddressDataView = DB.InvoiceAddress.InvoiceAddress_GetForSite(CurrentSite.SiteID)
    End Sub

    Private Sub dgJobs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgJobs.Click
        If SelectedJobDataRow Is Nothing Then
            Me.btnRemoveJob.Enabled = False
            Exit Sub
        End If

        Select Case CInt(SelectedJobDataRow.Item("JobDefinitionEnumID"))
            Case CInt(Entity.Sys.Enums.JobDefinition.Quoted)
                Me.btnRemoveJob.Enabled = True
            Case CInt(Entity.Sys.Enums.JobDefinition.Contract)
                Me.btnRemoveJob.Enabled = True
            Case CInt(Entity.Sys.Enums.JobDefinition.Callout)
                Me.btnRemoveJob.Enabled = True
            Case CInt(Entity.Sys.Enums.JobDefinition.Misc)
                Me.btnRemoveJob.Enabled = True
            Case Else
                Me.btnRemoveJob.Enabled = False
        End Select
    End Sub

    Private Sub btnAddJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddJob.Click
        Dim customerStatus As Integer = DB.Customer.Customer_Get(CurrentSite.CustomerID).Status
        Dim ssm As Entity.Sys.Enums.SecuritySystemModules
        ssm = Entity.Sys.Enums.SecuritySystemModules.Finance

        If chkOnStop.Checked And Not loggedInUser.HasAccessToModule(ssm) Then
            Dim msg As String = "This property is on stop and you do not have the necessary security permissions to change this." & vbCrLf
            msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
            Throw New Security.SecurityException(msg)
        ElseIf customerStatus = CInt(Entity.Sys.Enums.CustomerStatus.OnHold) And
            Not loggedInUser.HasAccessToModule(ssm) Then
            Dim msg As String = "The customer is on hold and you do not have the necessary security permissions to change this." & vbCrLf
            msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
            Throw New Security.SecurityException(msg)
        ElseIf chkOnStop.Checked Then
            If ShowMessage("This property is on stop. Do you want to continue?",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
        ElseIf customerStatus = CInt(Entity.Sys.Enums.CustomerStatus.OnHold) Then
            If ShowMessage("The customer is on hold. Do you want to continue?",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
        Else
        End If

        If loggedInUser.UserRegions.Count > 0 Then
            If loggedInUser.UserRegions.Table.Select("RegionID = " & CurrentSite.RegionID).Length < 1 Then
                Dim msg As String = "You do not have the necessary security permissions to add a job." & vbCrLf
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                Throw New Security.SecurityException(msg)
            End If
        ElseIf CurrentSite.RegionID <> loggedInUser.UserID Then
            Dim msg As String = "You do not have the necessary security permissions to add a job." & vbCrLf
            msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
            Throw New Security.SecurityException(msg)
        End If

        If (String.IsNullOrEmpty(CurrentSite.TelephoneNum) And String.IsNullOrEmpty(CurrentSite.FaxNum)) And
            String.IsNullOrEmpty(CurrentSite.EmailAddress) Then
            If ShowMessage("The phone number/email address is missing from site. Do you want to continue?",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
        End If

        If (chkLeaseHolder.Checked Or dtpDefectEndDate.Value >= Now) And Not IsGasway Then
            If ShowMessage("There are warnings against the site!" & vbCrLf & vbCrLf & "Please refer to the notes." & vbCrLf & vbCrLf & "Do you want to continue?",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
        End If
        ShowForm(GetType(FRMLogCallout), True, New Object() {0, CurrentSite.SiteID, Me})
    End Sub

    Private Sub dgJobs_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgJobs.DoubleClick
        If SelectedJobDataRow Is Nothing Then
            Exit Sub
        End If

        ShowForm(GetType(FRMLogCallout), True, New Object() {SelectedJobDataRow.Item("JobID"), CurrentSite.SiteID, Me})

    End Sub

    Private Sub btnRemoveJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveJob.Click
        If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Supervisor) = False Then
            Dim msg As String = "You do not have the necessary security permissions to delete a job." & vbCrLf
            msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
            Throw New Security.SecurityException(msg)
        End If

        If loggedInUser.UserRegions.Count > 0 Then
            If loggedInUser.UserRegions.Table.Select("RegionID = " & CurrentSite.RegionID).Length < 1 Then
                Dim msg As String = "You do not have the necessary security permissions to delete a job." & vbCrLf
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                Throw New Security.SecurityException(msg)
            End If
        ElseIf CurrentSite.RegionID <> loggedInUser.UserID Then
            Dim msg As String = "You do not have the necessary security permissions to delete a job." & vbCrLf
            msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
            Throw New Security.SecurityException(msg)
        End If

        If SelectedJobDataRow Is Nothing Then
            ShowMessage("Please select a job to remove", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.FSMAdmin) = False Then
            If Not CInt(SelectedJobDataRow.Item("StatusEnumID")) = CInt(Entity.Sys.Enums.JobStatus.Open) Then
                ShowMessage("Job has progressed passed 'Open' state so job cannot be deleted.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Not DB.Job.Job_Check_Before_Delete(SelectedJobDataRow.Item("JobID")) Then
                ShowMessage("At least 1 visit has progressed passed 'Ready' state so job cannot be deleted.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        If ShowMessage("Are you sure you want to remove this job from the system?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        DB.Job.Job_Delete(SelectedJobDataRow.Item("JobID"))

        PopulateJobs()
    End Sub

    Private Sub btnEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmail.Click
        If Not SelectedContactDataRow Is Nothing Then

            Dim myProcess As New Process
            myProcess.StartInfo.FileName = "mailto:" & SelectedContactDataRow("EmailAddress")
            myProcess.StartInfo.UseShellExecute = True
            myProcess.StartInfo.RedirectStandardOutput = False
            myProcess.Start()
            myProcess.Dispose()

        End If
    End Sub

    Private Sub btnFindCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCustomer.Click
        If CurrentSite Is Nothing OrElse Not CurrentSite.Exists Then
        Else
            Dim customerType As Integer = DB.Customer.Customer_Get(CurrentSite.CustomerID).CustomerTypeID
            If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Supervisor) = False And
                customerType = CInt(Entity.Sys.Enums.CustomerType.SocialHousing) Then
                Dim msg As String = "You do not have the necessary security permissions to change site to customer." & vbCrLf
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                Throw New Security.SecurityException(msg)
            End If
        End If

        SelectedCustomerID = FindRecord(Entity.Sys.Enums.TableNames.tblCustomer)
        If SelectedCustomerID = 0 Then Exit Sub
        Dim custCheck As Entity.Customers.Customer = DB.Customer.Customer_Get(SelectedCustomerID)
        If Not custCheck Is Nothing Then
            If custCheck.Status = Entity.Sys.Enums.CustomerStatus.OnHold Then
                If Not ShowMessage("Customer On Hold. Do you wish to continue?",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Exit Sub
                End If
            End If
        End If

        If CurrentSite Is Nothing OrElse Not CurrentSite.Exists Then
            PopulateCustomerField()
        Else
            If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Supervisor) = False And
                custCheck.CustomerTypeID = CInt(Entity.Sys.Enums.CustomerType.SocialHousing) Then
                Dim msg As String = "You do not have the necessary security permissions to change site to customer." & vbCrLf
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                Throw New Security.SecurityException(msg)
            End If
            If ShowMessage("Update customer details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                DB.Sites.Update_Customer(CurrentSite.SiteID, CurrentSite.CustomerID, SelectedCustomerID)
                CurrentSite = DB.Sites.Get(CurrentSite.SiteID)
            End If
        End If
    End Sub

    Private Sub btnDomestic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDomestic.Click
        If CurrentSite Is Nothing OrElse Not CurrentSite.Exists Then
            SelectedCustomerID = Entity.Sys.Enums.Customer.Domestic
            PopulateCustomerField()
        Else

            Dim customerType As Integer = DB.Customer.Customer_Get(CurrentSite.CustomerID).CustomerTypeID
            If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Supervisor) = False And
                customerType = CInt(Entity.Sys.Enums.CustomerType.SocialHousing) Then 'social housing
                Dim msg As String = "You do not have the necessary security permissions to change site to customer." & vbCrLf
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                Throw New Security.SecurityException(msg)
            End If
            SelectedCustomerID = Entity.Sys.Enums.Customer.Domestic

            If ShowMessage("Update customer details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                DB.Sites.Update_Customer(CurrentSite.SiteID, CurrentSite.CustomerID, SelectedCustomerID)
                CurrentSite = DB.Sites.Get(CurrentSite.SiteID)
            End If
        End If
    End Sub

    Private Sub btnCustomerAudit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerAudit.Click
        ShowForm(GetType(FRMSiteCustomerAudit), True, New Object() {CurrentSite.SiteID})
    End Sub

    Private Sub btnSendEmailToSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendEmailToSite.Click
        Dim myProcess As New Process
        myProcess.StartInfo.FileName = "mailto:" & CurrentSite.EmailAddress
        myProcess.StartInfo.UseShellExecute = True
        myProcess.StartInfo.RedirectStandardOutput = False
        myProcess.Start()
        myProcess.Dispose()
    End Sub

    Private Sub btnPrintLetters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintLetters.Click
        Dim contactID As Integer = 0
        If SelectedContactDataRow Is Nothing Then
            'ShowMessage("Select a contact", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Exit Sub
        Else
            contactID = SelectedContactDataRow("ContactID")
        End If
        Dim details As New ArrayList
        details.Add(contactID)
        details.Add(CurrentSite.SiteID)
        Dim oPrint As New Entity.Sys.Printing(details, "SiteLetter", Entity.Sys.Enums.SystemDocumentType.SiteLetter)
        'Refresh documents
        Me.pnlDocuments.Controls.Clear()
        DocumentsControl = New UCDocumentsList(Entity.Sys.Enums.TableNames.tblSite, CurrentSite.SiteID)
        Me.pnlDocuments.Controls.Add(DocumentsControl)
    End Sub

    Private Sub btnShowVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowVisits.Click
        ShowForm(GetType(FRMSiteVisitManager), True, New Object() {CurrentSite.SiteID})
    End Sub

    Private Sub btnSiteReport_Click(sender As Object, e As EventArgs) Handles btnSiteReport.Click
        PdfFactory.GenerateSiteHistoryReport(CurrentSite)
    End Sub

    Private Sub chkOnStop_Click(sender As Object, e As EventArgs) Handles chkOnStop.Click
        If ControlLoading = False Then
            ControlLoading = True
            Dim ssm As Entity.Sys.Enums.SecuritySystemModules
            ssm = Entity.Sys.Enums.SecuritySystemModules.Finance
            If loggedInUser.HasAccessToModule(ssm) = False Then
                Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                ControlLoading = False
                Throw New Security.SecurityException(msg)
            Else
                If chkOnStop.Checked Then
                    chkOnStop.Checked = False
                Else
                    chkOnStop.Checked = True
                End If
            End If
            ControlLoading = False
        End If
    End Sub

    Private Sub chkNoService_Click(sender As Object, e As EventArgs) Handles chkNoService.Click
        If Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Servicing) Then
            Dim msg As String = "You do not have the necessary security permissions to adjust this setting." & vbCrLf &
                "Contact your administrator if you think this is wrong or you need the permissions changing."
            Throw New Security.SecurityException(msg)
        End If

        If chkNoService.Checked Then
            chkNoService.Checked = False
        Else
            chkNoService.Checked = True
        End If
    End Sub

    Private Sub ChkVoid_Click(sender As Object, e As EventArgs) Handles chkVoid.Click
        If Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Voids) Then
            Dim msg As String = "You do not have the necessary security permissions to adjust this setting." & vbCrLf &
                                "Contact your administrator if you think this is wrong or you need the permissions changing."
            Throw New Security.SecurityException(msg)
        End If

        If CurrentSite.Exists Then
            If chkVoid.Checked = True Then
                If ShowMessage("This property is void. " & vbCrLf &
                           "Do you want to reinstate?",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                    Exit Sub
                End If
                If ShowMessage("Would you like to use the previous contact information?. ",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Dim dvSiteContacts As DataView = DB.Contact.Contacts_GetAll_ForLink(
                        CInt(Entity.Sys.Enums.TableNames.tblSite), CurrentSite.SiteID, True)
                    If dvSiteContacts.Count > 0 Then
                        Dim drSiteContact As DataRow =
                                (From row In dvSiteContacts.Table.AsEnumerable()
                                 Order By row.Field(Of Integer)("ContactID") Descending
                                 Select row).FirstOrDefault()
                        If drSiteContact.Table.Rows.Count > 0 Then
                            Me.txtTelephoneNum.Text = Entity.Sys.Helper.MakeStringValid(drSiteContact("TelephoneNo"))
                            Me.txtFaxNum.Text = Entity.Sys.Helper.MakeStringValid(drSiteContact("MobileNo"))
                            Me.txtEmailAddress.Text = Entity.Sys.Helper.MakeStringValid(drSiteContact("EmailAddress"))
                            Me.txtName.Text = Entity.Sys.Helper.MakeStringValid(drSiteContact("ContactID"))
                            Combo.SetSelectedComboItem_By_Description(cboSalutation, Entity.Sys.Helper.MakeStringValid(drSiteContact("Title")))
                            Me.txtFirstName.Text = Entity.Sys.Helper.MakeStringValid(drSiteContact("FirstName"))
                            Me.txtSurname.Text = Entity.Sys.Helper.MakeStringValid(drSiteContact("LastName"))
                        End If
                    End If
                End If

                Me.chkVoid.Checked = False
                Me.lblPropertyVoidDate.Visible = False
                Me.txtPropertyVoidDate.Visible = False
                CurrentSite.PropertyVoidDate = Nothing

                Save()
                DB.Sites.SaveSiteNotes(Entity.Sys.Helper.MakeIntegerValid(txtNoteID.Text),
                                       "Site reinstated", loggedInUser.UserID, CurrentSite.SiteID, loggedInUser.UserID)
            Else

                Try
                    If ShowMessage("All contact information will be wiped.".ToUpper() & vbCrLf & vbCrLf &
                               "Do you want to mark this property as void?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                        Exit Sub
                    End If

                    Dim voidDate As DateTime = Nothing

                    Dim f As New FRMContractUpgradeDowngrade()
                    f.Text = "Select Date"
                    f.lblText.Text = "Please select void date"
                    f.ShowDialog()
                    If f.DialogResult = DialogResult.OK Then
                        voidDate = f.EffDate
                    Else
                        Exit Sub
                    End If

                    Dim currentContact As Entity.Contacts.Contact =
                        New Entity.Contacts.Contact With
                        {
                            .SetSalutation = Combo.GetSelectedItemDescription(cboSalutation),
                            .SetFirstName = Entity.Sys.Helper.MakeStringValid(txtFirstName.Text),
                            .SetSurname = Entity.Sys.Helper.MakeStringValid(txtSurname.Text),
                            .SetMobileNo = Entity.Sys.Helper.MakeStringValid(txtFaxNum.Text),
                            .SetTelephoneNum = Entity.Sys.Helper.MakeStringValid(txtTelephoneNum.Text),
                            .SetEmailAddress = Entity.Sys.Helper.MakeStringValid(txtEmailAddress.Text),
                            .SetNoMarketing = Me.chkNoMarketing.Checked,
                            .SetLinkID = CInt(Entity.Sys.Enums.TableNames.tblSite),
                            .SetLinkRef = CurrentSite.SiteID
                        }

                    currentContact.SetContactID = DB.Contact.Contacts_Update(currentContact)
                    Dim dvSiteContacts As DataView = DB.Contact.Contacts_GetAll_ForLink(
                        CInt(Entity.Sys.Enums.TableNames.tblSite), CurrentSite.SiteID)
                    For Each drSiteContact As DataRow In dvSiteContacts.Table.Rows
                        If Not DB.Contact.Contacts_Delete(Entity.Sys.Helper.MakeIntegerValid((drSiteContact("ContactID")))) Then Throw New Exception("Failed to delete!")
                    Next
                    ClearContactForVoid()
                    Me.chkVoid.Checked = True
                    Me.lblPropertyVoidDate.Visible = True
                    Me.txtPropertyVoidDate.Visible = True
                    Me.txtPropertyVoidDate.Text = voidDate.ToString("dd/MM/yyyy")
                    CurrentSite.PropertyVoidDate = voidDate
                    Save()
                    DB.Sites.SaveSiteNotes(Entity.Sys.Helper.MakeIntegerValid(txtNoteID.Text),
                                           "Site marked as void", loggedInUser.UserID, CurrentSite.SiteID, loggedInUser.UserID)
                Catch ex As Exception
                    ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            If chkVoid.Checked Then
                chkVoid.Checked = False
            Else
                chkVoid.Checked = True
            End If
        End If
    End Sub

    Private Sub btnLetterReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLetterReport.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim dtLetters As DataTable = DB.LetterManager.LetterReport(CurrentSite.SiteID)

            If dtLetters.Rows.Count < 3 Then
                ShowMessage("This site has had less than 3 letter visits", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                Dim details As New ArrayList
                details.Add(dtLetters)
                'Public Sub New(detailsToPrintIn,documentNameIn, printTypeIn,multipleDocs, Optional ByVal OrderID As Integer = 0, Optional ByVal isEmail As Boolean = False, Optional ByVal ApptsPerDay As Integer = 13, Optional ByVal CustomerID As Integer = Nothing, Optional ByVal LetterCreationDate As DateTime = Nothing)
                Dim oPrint As New Entity.Sys.Printing(details, "Letter Report", Entity.Sys.Enums.SystemDocumentType.ServiceLetterReport, True, , , , CurrentSite.CustomerID)
            End If
        Catch ex As Exception
            ShowMessage("Error: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

#End Region

#Region "Functions"

    Private Sub runFilters()
        If Not JobsDataView Is Nothing Then

            If Not Combo.GetSelectedItemValue(Me.cboDefinition) = 0 Then
                JobsDataView.RowFilter = "JobDefinitionEnumID = '" & Combo.GetSelectedItemValue(Me.cboDefinition) & "'"
            End If

            If JobsDataView.RowFilter.Length > 0 Then
                JobsDataView.RowFilter += " AND JobNumber LIKE '%" & Me.txtJobNumber.Text & "%'"
            Else
                JobsDataView.RowFilter += "JobNumber LIKE '%" & Me.txtJobNumber.Text & "%'"
            End If

            If Me.dtpFrom.Checked = True Then
                If JobsDataView.RowFilter.Length > 0 Then
                    JobsDataView.RowFilter += " AND DateCreated >= '" & dtpFrom.Value.Date & "'"
                Else
                    JobsDataView.RowFilter += "DateCreated >= '" & dtpFrom.Value.Date & "'"
                End If
            End If

            If Me.dtpTo.Checked = True Then
                If JobsDataView.RowFilter.Length > 0 Then
                    JobsDataView.RowFilter += " AND DateCreated <= '" & dtpTo.Value.Date & "'"
                Else
                    JobsDataView.RowFilter += "DateCreated <= '" & dtpTo.Value.Date & "'"
                End If
            End If
        End If
    End Sub

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        ControlLoading = True
        If Not ID = 0 Then
            CurrentSite = DB.Sites.Get(ID)
        End If

        Dim currentContract As Entity.ContractsOriginal.ContractOriginal = DB.ContractOriginal.Get_Current_ForSite(CurrentSite.SiteID)
        If currentContract Is Nothing Then
            txtContractStatus.Text = "Not on contract"
            Dim allContracts As DataView = DB.ContractOriginal.GetAll_ForSite(CurrentSite.SiteID)
            If allContracts.Table.Rows.Count > 0 Then
                lblContractInactive.Visible = True
            Else
                lblContractInactive.Visible = False
            End If
        Else
            txtContractStatus.Text = currentContract.ContractType & " "

            If currentContract.GasSupplyPipework = True Or currentContract.PlumbingDrainage = True Or currentContract.WindowLockPest = True Then

                If currentContract.GasSupplyPipework = True And currentContract.PlumbingDrainage = True And currentContract.WindowLockPest = True Then
                    txtContractStatus.Text += " + Complete Home Emergency Cover "
                Else
                    If currentContract.GasSupplyPipework = True Then
                        txtContractStatus.Text += " + Gas Supply Pipework "
                    End If

                    If currentContract.PlumbingDrainage = True Then
                        txtContractStatus.Text += " + Plumbing, Drainage and Electrical "
                    End If

                    If currentContract.WindowLockPest = True Then
                        txtContractStatus.Text += " + Window and Pest "
                    End If
                End If
            End If

            txtContractStatus.Text += ", " & CType(currentContract.ContractStatusID, Entity.Sys.Enums.ContractStatus).ToString() & ", " & Format(currentContract.ContractStartDate, "dd/MM/yyyy") & "-" & Format(currentContract.ContractEndDate, "dd/MM/yyyy")

            If currentContract.ContractStatusID = CInt(Entity.Sys.Enums.ContractStatus.Inactive) Or currentContract.ContractStatusID = CInt(Entity.Sys.Enums.ContractStatus.Cancelled) Or CDate(Format(currentContract.ContractEndDate, "dd-MMM-yyyy") & " 23:59:59") < Now Then
                lblContractInactive.Visible = True
            Else
                lblContractInactive.Visible = False
            End If

            Dim dvContractSite As DataView = DB.ContractOriginalSite.GetAll_ContractID2(currentContract.ContractID, 0)
            If dvContractSite.Count > 0 Then
                Dim dvMainApp As DataView = DB.ContractOriginal.GetAssetsForContract(dvContractSite.Table.Rows(0)("ContractSiteID"), True)
                If dvMainApp.Count > 0 Then
                    txtContractStatus.Text += ", Main Apps: " & String.Join(", ", dvMainApp.Table.AsEnumerable().Select(Function(r) r.Field(Of String)("Product")).ToArray())
                End If
                Dim dvSecondApp As DataView = DB.ContractOriginal.GetAssetsForContract(dvContractSite.Table.Rows(0)("ContractSiteID"), False)
                If dvSecondApp.Count > 0 Then
                    txtContractStatus.Text += ", Second Apps: " & String.Join(", ", dvSecondApp.Table.AsEnumerable().Select(Function(r) r.Field(Of String)("Product")).ToArray())
                End If
            End If
        End If

        Combo.SetSelectedComboItem_By_Value(Me.cboRegionID, CurrentSite.RegionID)
        If Not CurrentSite.Exists Or Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Region) Then
            Me.cboRegionID.Enabled = False
        End If

        If CurrentCustomer?.CustomerTypeID = CInt(Entity.Sys.Enums.CustomerType.SocialHousing) And
            Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.SocialHousingSecurity) Then
            Me.chkHeadOffice.Enabled = False
        End If

        Me.chkHeadOffice.Checked = CurrentSite.HeadOffice
        Me.txtNotes.Text = CurrentSite.Notes
        Me.txtAsbestos.Text = CurrentSite.Asbestos
        Me.txtAddress1.Text = CurrentSite.Address1
        Me.txtAddress2.Text = CurrentSite.Address2
        Me.txtAddress3.Text = CurrentSite.Address3
        Me.txtAddress4.Text = CurrentSite.Address4
        Me.txtAddress5.Text = CurrentSite.Address5
        Me.txtPostcode.Text = CurrentSite.Postcode
        If CurrentCustomer?.CustomerTypeID = Enums.CustomerType.SocialHousing Then
            Me.txtAddress1.ReadOnly = True
            Me.txtAddress2.ReadOnly = True
            Me.txtAddress3.ReadOnly = True
            Me.txtAddress4.ReadOnly = True
            Me.txtAddress5.ReadOnly = True
            Me.txtPostcode.ReadOnly = True
        End If
        Me.txtPolicyNumber.Text = CurrentSite.PolicyNumber
        Me.txtDDRef.Text = CurrentSite.DirectDebitRef
        Me.txtTelephoneNum.Text = CurrentSite.TelephoneNum
        Me.txtFaxNum.Text = CurrentSite.FaxNum
        Me.txtEmailAddress.Text = CurrentSite.EmailAddress
        Me.txtName.Text = CurrentSite.Name
        Combo.SetSelectedComboItem_By_Description(cboSalutation, CurrentSite.Salutation)
        Me.txtFirstName.Text = CurrentSite.FirstName
        Me.txtSurname.Text = CurrentSite.Surname
        Me.chbAcceptChargeChanges.Checked = CurrentSite.AcceptChargesChanges
        Combo.SetSelectedComboItem_By_Value(cboSourceOfCustomer, CurrentSite.SourceOfCustomerID)
        Combo.SetSelectedComboItem_By_Value(cboReasonForContact, CurrentSite.ReasonForContactID)
        Combo.SetSelectedComboItem_By_Value(cboAccomType, CurrentSite.AccomTypeID)
        Me.chkNoMarketing.Checked = CurrentSite.NoMarketing
        Me.chkOnStop.Checked = CurrentSite.OnStop
        Me.chkVoid.Checked = CurrentSite.PropertyVoid
        If (CurrentSite.PropertyVoid) Then
            Me.lblPropertyVoidDate.Visible = True
            Me.txtPropertyVoidDate.Visible = True
            If Not IsNothing(CurrentSite.PropertyVoidDate) Then
                Me.txtPropertyVoidDate.Text = Format(CurrentSite.PropertyVoidDate, "dd/MM/yyyy")
            End If
        End If
        Me.txtAlert.Text = CurrentSite.ContactAlerts
        If Trim(txtAlert.Text).Length > 0 Then
            txtAlert.BackColor = Color.Orange
        End If
        Me.txtSiteDefects.Text = CurrentSite.Defects
        If Trim(txtSiteDefects.Text).Length > 0 Then
            txtSiteDefects.BackColor = Color.Yellow
            Me.dtpDefectEndDate.Enabled = False
        End If

        If CurrentSite.DefectEndDate <> Nothing Then Me.dtpDefectEndDate.Value = CurrentSite.DefectEndDate

        Me.chkSolidFuel.Checked = CurrentSite.SolidFuel
        Me.chkNoService.Checked = CurrentSite.NoService
        Me.chkLeaseHolder.Checked = CurrentSite.LeaseHold
        Me.chkCommercialDistrict.Checked = CurrentSite.CommercialDistrict

        If CurrentSite.LastServiceDate <> Nothing Then
            Me.txtLastServiceDate.Text = Format(CurrentSite.LastServiceDate.AddYears(1), "dd/MM/yyyy")
            Me.txtActualServiceDate.Text = Format(CurrentSite.LastServiceDate, "dd/MM/yyyy")
        End If

        If CurrentSite.ActualServiceDate <> Nothing Then
            Me.txtActualServiceDate.Text = Format(CurrentSite.ActualServiceDate, "dd/MM/yyyy")
        End If

        If CurrentSite.BuildDate <> Nothing Then dtpBuildDate.Value = CurrentSite.BuildDate
        txtWarrantyPeriod.Text = CurrentSite.WarrantyPeriodInMonths

        dtpBuildDate.Enabled = loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor)
        txtWarrantyPeriod.ReadOnly = Not loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor)

        txtHousingOfficer.Text = If(String.IsNullOrEmpty(CurrentSite.HousingOfficer), "No Housing Officer Set", CurrentSite.HousingOfficer)
        txtEstateOfficer.Text = If(String.IsNullOrEmpty(CurrentSite.EstateOfficer), "No Estate Officer Set", CurrentSite.EstateOfficer)
        txtHousingManager.Text = If(String.IsNullOrEmpty(CurrentSite.HousingManager), "No Housing Manager Set", CurrentSite.HousingManager)

        PopulateSiteFuels()
        PopulateSiteAuthority()
        CheckServiceDate()

        SelectedCustomerID = CurrentSite.CustomerID
        PopulateCustomerField()
        AddChangeHandlers(Me)
        ControlChanged = False
        ControlLoading = False
        If chkHeadOffice.Checked Then
            btnConvCust.Enabled = False
        End If
        If IsRFT AndAlso CurrentSite.LeaseHold Then
            btnAddJob.Enabled = False
        End If
    End Sub

    Private Sub PopulateCustomerField()
        theCustomer = DB.Customer.Customer_Get(SelectedCustomerID)
        If Not theCustomer Is Nothing Then
            Me.txtCustomer.Text = theCustomer.Name
        Else
            Me.txtCustomer.Text = ""
        End If
    End Sub

    Public Sub PopulateContacts()
        ContactsDataView = DB.Contact.Contact_GetForSite(CurrentSite.SiteID)
    End Sub

    Public Sub PopulateInvoiceAddresses()
        InvoiceAddressDataView = DB.InvoiceAddress.InvoiceAddress_GetForSite(CurrentSite.SiteID)
    End Sub

    Public Sub PopulateJobs()
        JobsDataView = DB.Job.Job_GetTop100_For_Site(CurrentSite.SiteID, CurrentSite.CustomerID)
        If JobsDataView.Count > 0 Then Me.dgJobs.ContextMenuStrip = cmsJobs
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try

            Me.Cursor = Cursors.WaitCursor
            CurrentSite.IgnoreExceptionsOnSetMethods = True

            If Me.chkHeadOffice.Checked Then
                Dim HO As Entity.Sites.Site = DB.Sites.Get(CurrentSite.CustomerID, Entity.Sites.SiteSQL.GetBy.CustomerHq)
                If HO IsNot Nothing AndAlso HO.SiteID <> CurrentSite.SiteID Then
                    Dim msg As String = theCustomer.Name & " has already got a head office against it. '" &
                        HO.Address1 & " " & HO.Postcode & "'" & vbCrLf & vbCrLf &
                        "Please remove the current head office before assigning this site."
                    Throw New Security.SecurityException(msg)
                End If
            End If

            If Not CurrentSite.Exists Or loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Region) Then
                CurrentSite.SetRegionID = Combo.GetSelectedItemValue(Me.cboRegionID)
            End If

            CurrentSite.SetHeadOffice = Me.chkHeadOffice.Checked
            CurrentSite.SetNotes = Me.txtNotes.Text.Trim
            CurrentSite.SetAddress1 = Me.txtAddress1.Text.Trim
            CurrentSite.SetAddress2 = Me.txtAddress2.Text.Trim
            CurrentSite.SetAddress3 = Me.txtAddress3.Text.Trim
            CurrentSite.SetAddress4 = Me.txtAddress4.Text.Trim
            CurrentSite.SetAddress5 = Me.txtAddress5.Text.Trim
            CurrentSite.SetPostcode = Me.txtPostcode.Text.Trim
            CurrentSite.SetTelephoneNum = Me.txtTelephoneNum.Text.Trim
            CurrentSite.SetFaxNum = Me.txtFaxNum.Text.Trim
            CurrentSite.SetEmailAddress = Me.txtEmailAddress.Text.Trim
            CurrentSite.SetAcceptChargesChanges = Me.chbAcceptChargeChanges.Checked
            CurrentSite.SetSourceOfCustomerID = Combo.GetSelectedItemValue(cboSourceOfCustomer)
            CurrentSite.SetPolicyNumber = Me.txtPolicyNumber.Text
            CurrentSite.SetDirectDebitRef = Me.txtDDRef.Text
            CurrentSite.SetReasonForContactID = Combo.GetSelectedItemValue(cboReasonForContact)
            CurrentSite.SetAccomTypeID = Combo.GetSelectedItemValue(Me.cboAccomType)
            CurrentSite.SetNoMarketing = Me.chkNoMarketing.Checked
            CurrentSite.SetOnStop = Me.chkOnStop.Checked
            CurrentSite.SetNoService = Me.chkNoService.Checked
            CurrentSite.SetPropertyVoid = Me.chkVoid.Checked
            If (Me.chkVoid.Checked) Then
                CurrentSite.PropertyVoidDate = Helper.MakeDateTimeValid(Me.txtPropertyVoidDate.Text)
            Else
                CurrentSite.PropertyVoidDate = Nothing
            End If
            If dtpBuildDate.Value > SqlTypes.SqlDateTime.MinValue Then CurrentSite.BuildDate = dtpBuildDate.Value
            CurrentSite.SetWarrantyPeriodInMonths = Helper.MakeIntegerValid(txtWarrantyPeriod.Text)

            Try
                Dim ls As New LocationServices.LocationServices

                Dim json As JObject = ls.GetLongLat(Me.txtPostcode.Text.Trim)
                CurrentSite.SetLongitude = (json.SelectToken("result.longitude").ToString)
                CurrentSite.SetLatitude = (json.SelectToken("result.latitude").ToString)
            Catch ex As Exception

            End Try

            Dim siteName As String = ""
            If Combo.GetSelectedItemValue(cboSalutation) <> "0" Then siteName += Combo.GetSelectedItemDescription(cboSalutation)
            If txtFirstName.Text.Length > 0 Then
                If siteName.Length > 0 Then siteName += " "
                siteName += txtFirstName.Text.Trim
            End If
            If txtSurname.Text.Length > 0 Then
                If siteName.Length > 0 Then siteName += " "
                siteName += txtSurname.Text.Trim
            End If

            If siteName.Length > 0 Then
                CurrentSite.SetName = siteName
            End If

            If Combo.GetSelectedItemValue(cboSalutation) = "Company Name" Then
                CurrentSite.SetName = txtSurname.Text
            End If

            CurrentSite.SetSalutation = Combo.GetSelectedItemDescription(cboSalutation)

            CurrentSite.SetFirstName = Me.txtFirstName.Text.Trim
            CurrentSite.SetSurname = Me.txtSurname.Text.Trim

            'CHECK FOR CUSTOMER CHANGE
            Dim oldCustomerID As Integer = 0
            If SelectedCustomerID <> CurrentSite.CustomerID Then
                oldCustomerID = CurrentSite.CustomerID
            End If

            CurrentSite.SetCustomerID = SelectedCustomerID

            If String.IsNullOrEmpty(CurrentSite.TelephoneNum) And String.IsNullOrEmpty(CurrentSite.FaxNum) And String.IsNullOrEmpty(CurrentSite.EmailAddress) And Not CurrentSite.PropertyVoid Then
                If ShowMessage("The phone number/email address is missing from site. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Return False
                End If
            End If

            CurrentSite.SetContactAlerts = Me.txtAlert.Text.Trim
            CurrentSite.SetDefects = Me.txtSiteDefects.Text.Trim
            CurrentSite.DefectEndDate = Me.dtpDefectEndDate.Value

            Dim cV As New Entity.Sites.SiteValidator
            cV.Validate(CurrentSite)

            If CurrentSite.Exists Then
                DB.Sites.Update(CurrentSite)
            Else
                CurrentSite = DB.Sites.Insert(CurrentSite)
            End If

            If FromForm Is Nothing Then
                MainForm.lblRightTitle.Text = "Manage Property for Customer: " & theCustomer.Name & ", Acc: " & theCustomer.AccountNumber

                If CurrentCustomerID = 0 Then
                    If MainForm.SearchText.Length > 0 Then
                        RaiseEvent RecordsChanged(DB.Sites.Search(MainForm.SearchText, loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Property, True, False, "")
                    Else
                        RaiseEvent RecordsChanged(DB.Sites.GetAll_Light_New(loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Property, True, False, "")
                    End If
                Else
                    CurrentCustomerID = CurrentSite.CustomerID
                    Dim cust As Entity.Customers.Customer
                    cust = DB.Customer.Customer_Get(CurrentCustomerID)

                    If MainForm.SearchText.Length > 0 Then
                        RaiseEvent RecordsChanged(DB.Sites.Search(MainForm.SearchText, loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Property, True, False, "")
                    Else
                        RaiseEvent RecordsChanged(DB.Sites.GetForCustomer_Light(CurrentCustomerID, loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Property, True, False, cust.Name)
                    End If

                End If
                RaiseEvent StateChanged(CurrentSite.SiteID)
                MainForm.RefreshEntity(CurrentSite.SiteID)
            Else
                If Not FromForm.Name.ToLower = GetType(FRMLogCallout).Name.ToLower And Not FromForm.Name.ToLower = GetType(FRMJobWizard).Name.ToLower Then
                    MainForm.lblRightTitle.Text = "Manage Property for Customer: " & theCustomer.Name & ", Acc: " & theCustomer.AccountNumber

                    If CurrentCustomerID = 0 Then
                        RaiseEvent RecordsChanged(DB.Sites.GetAll_Light_New(loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Property, True, False, "")
                    Else
                        CurrentCustomerID = CurrentSite.CustomerID
                        Dim cust As Entity.Customers.Customer
                        cust = DB.Customer.Customer_Get(CurrentCustomerID)
                        RaiseEvent RecordsChanged(DB.Sites.GetForCustomer_Light(CurrentCustomerID, loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Property, True, False, cust.Name)
                    End If
                    RaiseEvent StateChanged(CurrentSite.SiteID)
                    MainForm.RefreshEntity(CurrentSite.SiteID)
                End If
            End If

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

    Private Function DeleteOption1() As Boolean
        'DELETE Visit, Jobs - not sync, Job Assets, PPM Visits, Contract Site Assets, Contract Sites
        Dim sites As New DataView
        sites = DB.ContractOriginalSite.GetAll_ContractID(SelectedContractDataRow.Item("ContractID"), CurrentSite.CustomerID)
        Dim DeleteContract As Boolean = True

        For Each r As DataRow In sites.Table.Select("Tick=1")
            If DB.ContractOriginalSite.Delete(r("ContractSiteID")) > 0 Then
                DeleteContract = False
            End If
        Next r

        If DeleteContract Then
            DB.ContractOriginal.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedContractDataRow.Item("ContractID")))
        End If

        Return DeleteContract

    End Function

    Private Sub ClearContactForVoid()
        Me.txtTelephoneNum.Text = String.Empty
        Me.txtFaxNum.Text = String.Empty
        Me.txtEmailAddress.Text = String.Empty
        Me.txtName.Text = "VOID"
        Combo.SetUpCombo(Me.cboSalutation, DynamicDataTables.Salutation, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        Me.txtFirstName.Text = "VOID"
        Me.txtSurname.Text = "VOID"
    End Sub

#End Region

#Region "Site Notes"

#Region "Notes Properties "

    Private _siteNotes As DataView = Nothing

    Public Property SiteNotesDataView() As DataView
        Get
            Return _siteNotes
        End Get
        Set(ByVal Value As DataView)
            _siteNotes = Value
            _siteNotes.Table.TableName = Entity.Sys.Enums.TableNames.tblSiteNotes.ToString
            _siteNotes.AllowNew = False
            _siteNotes.AllowEdit = False
            _siteNotes.AllowDelete = False
            Me.dgNotes.DataSource = _siteNotes

            If Not _siteNotes Is Nothing Then
                If Not _siteNotes.Table Is Nothing Then
                    If _siteNotes.Table.Rows.Count > 0 Then

                    End If
                End If
            End If
        End Set
    End Property

    Private ReadOnly Property SelectedSiteNoteDataRow() As DataRow
        Get
            If Not Me.dgNotes.CurrentRowIndex = -1 Then
                Return SiteNotesDataView(Me.dgNotes.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region " Notes Setup"

    Public Sub SetupNotesDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgNotes)
        Dim tStyle As DataGridTableStyle = Me.dgNotes.TableStyles(0)

        tStyle.GridColumnStyles.Clear()
        Me.dgNotes.ReadOnly = True

        Dim Note As New DataGridLabelColumn
        Note.Format = ""
        Note.FormatInfo = Nothing
        Note.HeaderText = "Note"
        Note.MappingName = "Note"
        Note.ReadOnly = True
        Note.Width = 250
        Note.NullText = ""
        tStyle.GridColumnStyles.Add(Note)

        Dim CreatedBy As New DataGridLabelColumn
        CreatedBy.Format = ""
        CreatedBy.FormatInfo = Nothing
        CreatedBy.HeaderText = "Created By"
        CreatedBy.MappingName = "CreatedBy"
        CreatedBy.ReadOnly = True
        CreatedBy.Width = 125
        CreatedBy.NullText = ""
        tStyle.GridColumnStyles.Add(CreatedBy)

        Dim DateCreated As New DataGridLabelColumn
        DateCreated.Format = "dd/MMM/yyyy HH:mm:ss"
        DateCreated.FormatInfo = Nothing
        DateCreated.HeaderText = "Created"
        DateCreated.MappingName = "DateCreated"
        DateCreated.ReadOnly = True
        DateCreated.Width = 135
        DateCreated.NullText = ""
        tStyle.GridColumnStyles.Add(DateCreated)

        Dim EditedBy As New DataGridLabelColumn
        EditedBy.Format = ""
        EditedBy.FormatInfo = Nothing
        EditedBy.HeaderText = "Edited By"
        EditedBy.MappingName = "EditedBy"
        EditedBy.ReadOnly = True
        EditedBy.Width = 125
        EditedBy.NullText = ""
        tStyle.GridColumnStyles.Add(EditedBy)

        Dim LastEdited As New DataGridLabelColumn
        LastEdited.Format = "dd/MMM/yyyy HH:mm:ss"
        LastEdited.FormatInfo = Nothing
        LastEdited.HeaderText = "Last Edited"
        LastEdited.MappingName = "LastEdited"
        LastEdited.ReadOnly = True
        LastEdited.Width = 135
        LastEdited.NullText = ""
        tStyle.GridColumnStyles.Add(LastEdited)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSiteNotes.ToString
        Me.dgNotes.TableStyles.Add(tStyle)

        Entity.Sys.Helper.RemoveEventHandlers(Me.dgNotes)
    End Sub

#End Region

#Region " Notes Events"

    Private Sub dgNotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgNotes.Click, dgNotes.CurrentCellChanged
        If SelectedSiteNoteDataRow Is Nothing Then
            Exit Sub
        Else
            PopulateSiteNoteFields()
            Me.txtNote.ReadOnly = True
            Me.btnSaveNote.Enabled = False
        End If
    End Sub

    Private Sub btnAddNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNote.Click
        ClearNotesFields()
    End Sub

    Private Sub btnDeleteNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteNote.Click
        Dim msg As String = "Are you sure you want to delete this note?" & vbCrLf
        msg += "You will not be able to undo the delete if you proceed."

        Dim r As DataRow
        r = SelectedSiteNoteDataRow
        If Not r Is Nothing Then
            If MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                DB.Sites.DeleteSiteNote(CInt(r("SiteNoteID")))
                SiteNotesDataView.Table.Rows.Remove(SelectedSiteNoteDataRow)
                ClearNotesFields()
            End If
        End If
    End Sub

    Private Sub btnSaveNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveNote.Click
        If Me.txtNote.Text.Trim.Length > 0 Then
            SiteNotesDataView = DB.Sites.SaveSiteNotes(Entity.Sys.Helper.MakeIntegerValid(txtNoteID.Text),
                                                   txtNote.Text.Trim, loggedInUser.UserID,
                                                   CurrentSite.SiteID, loggedInUser.UserID)
        End If

        ClearNotesFields()
    End Sub

#End Region

#Region " Notes Functions"

    Private Sub ClearNotesFields()
        txtNoteID.Text = ""
        txtNote.Text = ""
        ActiveControl = txtNote
        Me.txtNote.ReadOnly = False
        txtNote.Focus()
        Me.btnSaveNote.Enabled = True
        tpNotes.Text = "Notes (" & SiteNotesDataView.Table.Rows.Count & ")"
    End Sub

    Private Sub PopulateSiteNoteFields()
        Dim r As DataRow
        r = SelectedSiteNoteDataRow
        If Not r Is Nothing Then
            txtNoteID.Text = CStr(r("SiteNoteID"))
            txtNote.Text = CStr(r("Note"))
        End If

        ActiveControl = txtNote
        txtNote.Focus()
    End Sub

    Private Sub PopulateSiteNotes()
        SiteNotesDataView = DB.Sites.GetSiteNotes(CurrentSite.SiteID)
        tpNotes.Text = "Notes (" & SiteNotesDataView.Table.Rows.Count & ")"
    End Sub

#End Region

#End Region

    Private Sub btnAddModifyPlan_Click(sender As Object, e As EventArgs) Handles btnAddModifyPlan.Click
        ShowForm(GetType(FRMContractWiz), True, New Object() {0, Entity.Sys.Helper.MakeIntegerValid(CurrentSite.CustomerID), Entity.Sys.Helper.MakeIntegerValid(CurrentSite.SiteID)})
        Contracts = DB.ContractOriginal.GetAll_ForSite(CurrentSite.SiteID)
        PopulateJobs()
    End Sub

    Private Sub btnConvCust_Click(sender As Object, e As EventArgs) Handles btnConvCust.Click
        If CurrentSite Is Nothing OrElse Not CurrentSite.Exists Then
        Else
            Dim customerType As Integer = DB.Customer.Customer_Get(CurrentSite.CustomerID).CustomerTypeID
            If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Supervisor) = False And
                    customerType = CInt(Entity.Sys.Enums.CustomerType.SocialHousing) Then
                Dim msg As String = "You do not have the necessary security permissions to change site to customer." & vbCrLf
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                Throw New Security.SecurityException(msg)
            End If
        End If

        'Stop users creating Customers with no Region
        If Combo.GetSelectedItemValue(cboRegionID) < 1 Then
            MsgBox("Please ensure the site has a region selected before converting", MsgBoxStyle.OkOnly, "No Region")
            Exit Sub
        End If

        'Noticed that a customer could be converted with no name!!
        If txtFirstName.Text.Length = 0 AndAlso txtSurname.Text.Length = 0 Then
            MsgBox("Please ensure the site has a Surname or Firstname before converting", MsgBoxStyle.OkOnly, "No Name")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Try

            '   If Not EnterOverridePassword() Then Exit Sub

            Dim domCustomer As Entity.Customers.Customer = DB.Customer.Customer_Get(CInt(Enums.Customer.Domestic))
            Dim img As System.Drawing.Image = System.Drawing.Image.FromFile(Application.StartupPath & "\TEMP\GaswayLogo.bmp")
            Dim bytes As Byte()
            Using ms As New MemoryStream()
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                bytes = ms.ToArray()
            End Using

            CurrentCustomer = New Entity.Customers.Customer
            CurrentCustomer.IgnoreExceptionsOnSetMethods = True

            Dim fName As String = txtFirstName.Text
            If fName.Length > 0 Then fName = fName.Substring(0, 1)
            CurrentCustomer.SetName = Me.txtSurname.Text & " - " & Combo.GetSelectedItemDescription(cboSalutation) & " " & fName
            CurrentCustomer.SetRegionID = Combo.GetSelectedItemValue(cboRegionID)
            CurrentCustomer.SetCustomerTypeID = 518
            CurrentCustomer.SetNotes = "POC ONLY"
            CurrentCustomer.SetAccountNumber = domCustomer?.AccountNumber
            CurrentCustomer.SetStatus = 1
            CurrentCustomer.SetAcceptChargesChanges = Me.chbAcceptChargeChanges.Checked
            CurrentCustomer.SetMainContractorDiscount = 0
            CurrentCustomer.SetPoNumReqd = False
            CurrentCustomer.SetJobPriorityMandatory = False
            CurrentCustomer.SetNominal = 4100
            CurrentCustomer.Logo = bytes
            CurrentSite.SetHeadOffice = False

            Dim cV As New Entity.Customers.CustomerValidator
            cV.Validate(CurrentCustomer)

            Dim count As Integer = DB.ExecuteScalar("Select Count(*) FROM tblCustomer where Deleted = 0 AND Name = '" & CurrentCustomer.Name & "'")
            If count > 0 Then
                If ShowMessage("There is already a Customer with the same Name, Do you Still wish to proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    CurrentCustomer.SetName = Me.txtSurname.Text & " - " & Combo.GetSelectedItemDescription(cboSalutation) & " " & txtFirstName.Text
                Else
                    Exit Sub
                End If
            End If

            If CurrentCustomer.Exists Then
                Dim customerCharges As New Entity.CustomerCharges.CustomerCharge
                customerCharges.SetMileageRate = 1
                customerCharges.SetPartsMarkup = 1
                customerCharges.SetRatesMarkup = 1
                customerCharges.SetCustomerID = CurrentCustomer.CustomerID

                Dim ccV As New Entity.CustomerCharges.CustomerChargeValidator
                ccV.Validate(customerCharges)
                DB.CustomerCharge.Update(customerCharges)
                DB.Customer.Update(CurrentCustomer)
            Else

                Dim customerCharges As New Entity.CustomerCharges.CustomerCharge
                customerCharges.SetMileageRate = 1
                customerCharges.SetPartsMarkup = 1
                customerCharges.SetRatesMarkup = 1
                customerCharges.SetCustomerID = 0
                Dim ccV As New Entity.CustomerCharges.CustomerChargeValidator
                ccV.Validate(customerCharges)
                CurrentSite.SetHeadOffice = True
                CurrentCustomer = DB.Customer.Insert(CurrentCustomer)
                customerCharges.SetCustomerID = CurrentCustomer.CustomerID
                DB.CustomerCharge.Insert(customerCharges)

            End If

            CurrentCustomerID = CurrentCustomer.CustomerID

            ''''SOR
            Dim dt As DataTable = DB.CustomerScheduleOfRate.GetAll_WithoutDefaults(CInt(Entity.Sys.Enums.Customer.Domestic)).Table
            For Each dr As DataRow In dt.Rows

                Dim CurrentCustomerScheduleofRate As New Entity.CustomerScheduleOfRates.CustomerScheduleOfRate
                CurrentCustomerScheduleofRate.SetAllowDeleted = 1
                CurrentCustomerScheduleofRate.SetCustomerID = CurrentCustomerID
                CurrentCustomerScheduleofRate.SetCode = dr("Code")
                CurrentCustomerScheduleofRate.SetDescription = dr("Description")
                CurrentCustomerScheduleofRate.SetPrice = dr("Price")
                CurrentCustomerScheduleofRate.SetTimeInMins = dr("TimeInMins")
                CurrentCustomerScheduleofRate.SetScheduleOfRatesCategoryID = dr("ScheduleOfRatesCategoryID")
                CurrentCustomerScheduleofRate = DB.CustomerScheduleOfRate.Insert(CurrentCustomerScheduleofRate)

            Next

            'INSERT AUDIT RECORD
            Dim scAudit As New Entity.SiteCustomerAudits.SiteCustomerAudit
            scAudit.DateChanged = Now
            scAudit.SetSiteID = CurrentSite.SiteID
            scAudit.SetPreviousCustomerID = CurrentSite.CustomerID
            scAudit.SetUserID = loggedInUser.UserID
            DB.SiteCustomerAudit.Insert(scAudit)

            CurrentSite.SetCustomerID = CurrentCustomerID
            DB.Sites.Update(CurrentSite)

            btnConvCust.Enabled = False

            If FromForm Is Nothing Then
                MainForm.lblRightTitle.Text = "Manage Property for Customer: " & theCustomer.Name & ", Acc: " & theCustomer.AccountNumber

                If CurrentCustomerID = 0 Then
                    If MainForm.SearchText.Length > 0 Then
                        RaiseEvent RecordsChanged(DB.Sites.Search(MainForm.SearchText, loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Property, True, False, "")
                    Else
                        RaiseEvent RecordsChanged(DB.Sites.GetAll_Light_New(loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Property, True, False, "")
                    End If
                Else
                    CurrentCustomerID = CurrentSite.CustomerID
                    Dim cust As Entity.Customers.Customer
                    cust = DB.Customer.Customer_Get(CurrentCustomerID)

                    If MainForm.SearchText.Length > 0 Then
                        RaiseEvent RecordsChanged(DB.Sites.Search(MainForm.SearchText, loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Property, True, False, "")
                    Else
                        RaiseEvent RecordsChanged(DB.Sites.GetForCustomer_Light(CurrentCustomerID, loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Property, True, False, cust.Name)
                    End If

                End If
                RaiseEvent StateChanged(CurrentSite.SiteID)
                MainForm.RefreshEntity(CurrentSite.SiteID)
            Else
                If Not FromForm.Name.ToLower = GetType(FRMLogCallout).Name.ToLower Then
                    MainForm.lblRightTitle.Text = "Manage Property for Customer: " & theCustomer.Name & ", Acc: " & theCustomer.AccountNumber

                    If CurrentCustomerID = 0 Then
                        RaiseEvent RecordsChanged(DB.Sites.GetAll_Light_New(loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Property, True, False, "")
                    Else
                        CurrentCustomerID = CurrentSite.CustomerID
                        Dim cust As Entity.Customers.Customer
                        cust = DB.Customer.Customer_Get(CurrentCustomerID)
                        RaiseEvent RecordsChanged(DB.Sites.GetForCustomer_Light(CurrentCustomerID, loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Property, True, False, cust.Name)
                    End If
                    RaiseEvent StateChanged(CurrentSite.SiteID)
                    MainForm.RefreshEntity(CurrentSite.SiteID)
                End If
            End If
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

#Region "Site Fuel"

    Private _dvSiteFuels As DataView = Nothing

    Public Property SiteFuelsDataView() As DataView
        Get
            Return _dvSiteFuels
        End Get
        Set(ByVal Value As DataView)
            _dvSiteFuels = Value
            _dvSiteFuels.AllowNew = False
            _dvSiteFuels.AllowEdit = False
            _dvSiteFuels.AllowDelete = False
            _dvSiteFuels.Table.TableName = Entity.Sys.Enums.TableNames.tblSiteFuel.ToString
            Me.dgSiteFuel.DataSource = SiteFuelsDataView
        End Set
    End Property

    Private ReadOnly Property SelectedSiteFuelDataRow() As DataRow
        Get
            If Not Me.dgSiteFuel.CurrentRowIndex = -1 Then
                Return SiteFuelsDataView(Me.dgSiteFuel.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private Sub SiteFuelMoreInfo(sender As Object, e As EventArgs) Handles btnMoreInfo.Click
        If CurrentSite Is Nothing OrElse Not CurrentSite.Exists Then
            Exit Sub
        End If

        Dim frmSiteFuel As New FRMSiteFuel(CurrentSite)
        frmSiteFuel.ShowDialog()
        CurrentSite = DB.Sites.Get(CurrentSite.SiteID)
    End Sub

    Private Sub dgSiteFuel_MouseUp(sender As Object, e As MouseEventArgs) Handles dgSiteFuel.MouseUp
        Me.ttSiteFuel.Hide(Me.dgSiteFuel)
        If SelectedSiteFuelDataRow Is Nothing Then
            Exit Sub
        End If
        Dim message As String = ""
        'check for row before we call it
        If SelectedSiteFuelDataRow.Table.Columns.Contains("lastservicedate") Then
            Dim lsd As DateTime = Entity.Sys.Helper.MakeDateTimeValid(SelectedSiteFuelDataRow("lastservicedate"))
            If lsd <> Nothing AndAlso lsd > SqlTypes.SqlDateTime.MinValue.Value.AddYears(1) Then
                If lsd <= Now().AddDays(-365) Then
                    message = "Overdue"
                ElseIf lsd <= Now().AddDays(-352) And lsd > Now().AddDays(-365) Then
                    message = "Third letter stage"
                ElseIf lsd <= Now().AddDays(-330) And lsd > Now().AddDays(-352) Then
                    message = "Second letter stage"
                ElseIf lsd <= Now().AddDays(-309) And lsd > Now().AddDays(-330) Then
                    message = "First letter stage"
                ElseIf lsd <= Now().AddDays(-281) And lsd > Now().AddDays(-309) Then
                    message = "Service due soon"
                Else
                    Exit Sub
                End If
            Else
                message = "No service recorded"
            End If
        End If

        Dim hittest As System.Windows.Forms.DataGrid.HitTestInfo = dgSiteFuel.HitTest(e.X, e.Y)
        If hittest.Type = DataGrid.HitTestType.Cell Then
            If hittest.Row >= 0 Then
                Me.ttSiteFuel.Show(message, Me.dgSiteFuel, e.X, e.Y)
            End If
        End If
    End Sub

    Private Sub PopulateSiteFuels()
        Try
            SiteFuelsDataView = DB.Sites.[SiteFuel_GetAll_ForSite](CurrentSite.SiteID)
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgSiteFuel_Leave(sender As Object, e As EventArgs) Handles dgSiteFuel.Leave
        Me.ttSiteFuel.Hide(Me.dgSiteFuel)
    End Sub

    Private Sub tsmiMoveJob_Click(sender As Object, e As EventArgs) Handles tsmiMoveJob.Click
        If SelectedJobDataRow Is Nothing Then
            ShowMessage("Please select a job", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Cursor.Current = Cursors.WaitCursor
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblSite)
        If Not ID = 0 Then
            Dim oSite As Entity.Sites.Site = DB.Sites.Get(ID)
            If oSite IsNot Nothing AndAlso oSite.Exists Then
                Select Case ShowMessage("Move job '" & SelectedJobDataRow("JobNumber") & "' to " &
                                        oSite.Address1, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes

                        If DB.Job.Job_MoveSite(SelectedJobDataRow("JobID"), CurrentSite.SiteID, ID) Then
                            Dim jA As New Entity.JobAudits.JobAudit
                            jA.SetJobID = SelectedJobDataRow("JobID")
                            jA.SetActionChange = "Job moved from " & CurrentSite.Name & ", " & CurrentSite.Address1 &
                                                 " to " & oSite.Name & ", " & oSite.Address1
                            DB.JobAudit.Insert(jA)
                            ShowMessage("Job successfully moved!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            PopulateJobs()
                        End If
                    Case Else
                        Exit Sub
                End Select
            End If
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnUpdateAlert_Click(sender As Object, e As EventArgs)
        Dim contactAlert As String = txtAlert.Text
        If String.IsNullOrEmpty(contactAlert) Then Exit Sub

        If ShowMessage("Do you want to update the alert?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DB.Sites.Site_Update_ContactAlerts(CurrentSite.SiteID, contactAlert)
            CurrentSite = DB.Sites.Get(CurrentSite.SiteID)
        End If
    End Sub

#End Region

#Region "Site Authority"

    Public Sub SetupSiteAuthorityAuditDataGrid()
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

    Private _dvSiteAuthorityAudit As DataView

    Private Property SiteAuthorityAuditDataView() As DataView
        Get
            Return _dvSiteAuthorityAudit
        End Get
        Set(ByVal value As DataView)
            _dvSiteAuthorityAudit = value
            _dvSiteAuthorityAudit.AllowNew = False
            _dvSiteAuthorityAudit.AllowEdit = False
            _dvSiteAuthorityAudit.AllowDelete = False
            _dvSiteAuthorityAudit.Table.TableName = Entity.Sys.Enums.TableNames.tblAuthority.ToString
            Me.dgAuthorityAudit.DataSource = SiteAuthorityAuditDataView
        End Set
    End Property

    Private Sub PopulateSiteAuthority()
        Try
            Dim oCustomerAuthority As Entity.Authority.Authority =
                DB.Authority.Get(CurrentSite.CustomerID, Entity.Authority.AuthoritySQL.GetBy.CustomerId)

            If oCustomerAuthority IsNot Nothing Then
                Me.txtCustAuthority.Text = oCustomerAuthority.Notes
            End If

            SiteAuthority = DB.Authority.Get(CurrentSite.SiteID, Entity.Authority.AuthoritySQL.GetBy.SiteId)

            If SiteAuthority IsNot Nothing Then
                Me.txtSiteAuth.Text = SiteAuthority.Notes
            End If

            SiteAuthorityAuditDataView = DB.Authority.Audit_Get(CurrentSite.SiteID, Entity.Authority.AuthoritySQL.GetBy.SiteId)
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSaveAuth_Click(sender As Object, e As EventArgs) Handles btnSaveAuth.Click
        If String.IsNullOrEmpty(txtSiteAuth.Text) Then Exit Sub
        If SiteAuthority Is Nothing Then
            SiteAuthority = New Entity.Authority.Authority
            SiteAuthority.SetNotes = txtSiteAuth.Text
            DB.Authority.Insert_Site(CurrentSite.SiteID, SiteAuthority)
        Else
            Dim changes As String = String.Empty
            If SiteAuthority.Notes <> txtSiteAuth.Text Then
                changes += "Changed: " & SiteAuthority.Notes.Replace(vbCr, " ").Replace(vbLf, " ")
            End If
            SiteAuthority.SetNotes = txtSiteAuth.Text
            DB.Authority.Update(SiteAuthority, changes)
        End If
        PopulateSiteAuthority()
    End Sub

    Private Sub chkHeadOffice_Click(sender As Object, e As EventArgs) Handles chkHeadOffice.Click
        Me.chkHeadOffice.Checked = Not chkHeadOffice.Checked
        If Me.chkHeadOffice.Checked Then
            Dim HO As Entity.Sites.Site = DB.Sites.Get(CurrentSite.CustomerID, Entity.Sites.SiteSQL.GetBy.CustomerHq)
            If HO IsNot Nothing AndAlso HO.SiteID <> CurrentSite.SiteID Then
                Dim msg As String = theCustomer.Name & " has already got a head office against it. '" &
                    HO.Address1 & " " & HO.Postcode & "'" & vbCrLf & vbCrLf &
                    "Please remove the current head office before assigning this site."
                Me.chkHeadOffice.Checked = False
                Throw New Security.SecurityException(msg)
            End If
        End If
    End Sub

#End Region

End Class