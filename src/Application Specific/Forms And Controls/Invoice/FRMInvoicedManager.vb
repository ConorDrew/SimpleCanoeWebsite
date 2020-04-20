Imports System.Collections.Generic
Imports System.Linq
Imports FSM.Entity.Sys

Public Class FRMInvoicedManager : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'PopulateDatagrid()

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
    Friend WithEvents btnPrintOneItemOneInvoice As System.Windows.Forms.Button

    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents grpFilter As System.Windows.Forms.GroupBox
    Friend WithEvents btnFindCustomer As System.Windows.Forms.Button
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents txtPostcode As System.Windows.Forms.TextBox
    Friend WithEvents lblPostcode As System.Windows.Forms.Label
    Friend WithEvents btnFindSite As System.Windows.Forms.Button
    Friend WithEvents txtSite As System.Windows.Forms.TextBox
    Friend WithEvents txtJobNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblRefNo As System.Windows.Forms.Label
    Friend WithEvents lblProperty As System.Windows.Forms.Label
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents dtpRaisedTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpRaisedFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDateBetween As System.Windows.Forms.Label
    Friend WithEvents lblInvoiceNumber As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents grpInvoices As System.Windows.Forms.GroupBox
    Friend WithEvents lblInvoicePartPayed As System.Windows.Forms.Label
    Friend WithEvents lblInvoicePayed As System.Windows.Forms.Label
    Friend WithEvents lblGreenColour As System.Windows.Forms.Label
    Friend WithEvents lblGoldColour As System.Windows.Forms.Label
    Friend WithEvents lblInvoicedNotPayed As System.Windows.Forms.Label
    Friend WithEvents lblRedColour As System.Windows.Forms.Label
    Friend WithEvents dgInvoices As System.Windows.Forms.DataGrid
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnDeselectAll As System.Windows.Forms.Button
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents cboUser As System.Windows.Forms.ComboBox
    Friend WithEvents txtInvoiceNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnChange As System.Windows.Forms.Button
    Friend WithEvents btnMarkAsNotExported As System.Windows.Forms.Button
    Friend WithEvents cboExported As System.Windows.Forms.ComboBox
    Friend WithEvents lblExported As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblRegion As System.Windows.Forms.Label
    Friend WithEvents cboRegion As System.Windows.Forms.ComboBox
    Friend WithEvents btnGenVal As System.Windows.Forms.Button
    Friend WithEvents lblSageMonth As System.Windows.Forms.Label
    Friend WithEvents txtSageMonth As System.Windows.Forms.TextBox
    Friend WithEvents btnSalesCredit As System.Windows.Forms.Button
    Friend WithEvents cmsValType As ContextMenuStrip
    Friend WithEvents tsmiNCCVal As ToolStripMenuItem
    Friend WithEvents tsmiGenericVal As ToolStripMenuItem
    Friend WithEvents cmsChange As ContextMenuStrip
    Friend WithEvents tsmiPaymentTerms As ToolStripMenuItem
    Friend WithEvents tsmiInvoicedTotal As ToolStripMenuItem
    Friend WithEvents tsmiVatRate As ToolStripMenuItem
    Friend WithEvents cmsSalesCredit As ContextMenuStrip
    Friend WithEvents tsmiIssue As ToolStripMenuItem
    Friend WithEvents tsmiRemove As ToolStripMenuItem
    Friend WithEvents tsmiBatchPrint As ToolStripMenuItem
    Friend WithEvents cmsExportForAccounts As ContextMenuStrip
    Friend WithEvents tsmiSunExport As ToolStripMenuItem
    Friend WithEvents tsmiSageExport As ToolStripMenuItem
    Friend WithEvents btnExportToAccounts As Button
    Friend WithEvents tsmiAccountNumber As ToolStripMenuItem
    Friend WithEvents lblDept As Label
    Friend WithEvents cboDept As ComboBox
    Friend WithEvents tsmiOrderNo As ToolStripMenuItem
    Friend WithEvents dtpExportedOn As DateTimePicker
    Friend WithEvents lblExportedOn As Label
    Friend WithEvents chkExportedOn As CheckBox
    Friend WithEvents tsmiSorVal As ToolStripMenuItem
    Friend WithEvents btnView As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnPrintOneItemOneInvoice = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.grpFilter = New System.Windows.Forms.GroupBox()
        Me.dtpExportedOn = New System.Windows.Forms.DateTimePicker()
        Me.lblExportedOn = New System.Windows.Forms.Label()
        Me.lblDept = New System.Windows.Forms.Label()
        Me.cboDept = New System.Windows.Forms.ComboBox()
        Me.lblSageMonth = New System.Windows.Forms.Label()
        Me.txtSageMonth = New System.Windows.Forms.TextBox()
        Me.lblRegion = New System.Windows.Forms.Label()
        Me.cboRegion = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cboExported = New System.Windows.Forms.ComboBox()
        Me.lblExported = New System.Windows.Forms.Label()
        Me.btnFindCustomer = New System.Windows.Forms.Button()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.txtPostcode = New System.Windows.Forms.TextBox()
        Me.lblPostcode = New System.Windows.Forms.Label()
        Me.btnFindSite = New System.Windows.Forms.Button()
        Me.txtSite = New System.Windows.Forms.TextBox()
        Me.txtJobNumber = New System.Windows.Forms.TextBox()
        Me.lblRefNo = New System.Windows.Forms.Label()
        Me.lblProperty = New System.Windows.Forms.Label()
        Me.lblType = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.lblDateBetween = New System.Windows.Forms.Label()
        Me.dtpRaisedFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpRaisedTo = New System.Windows.Forms.DateTimePicker()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblInvoiceNumber = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.cboUser = New System.Windows.Forms.ComboBox()
        Me.txtInvoiceNumber = New System.Windows.Forms.TextBox()
        Me.chkExportedOn = New System.Windows.Forms.CheckBox()
        Me.grpInvoices = New System.Windows.Forms.GroupBox()
        Me.btnSalesCredit = New System.Windows.Forms.Button()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.dgInvoices = New System.Windows.Forms.DataGrid()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnDeselectAll = New System.Windows.Forms.Button()
        Me.lblInvoicePartPayed = New System.Windows.Forms.Label()
        Me.lblInvoicePayed = New System.Windows.Forms.Label()
        Me.lblGreenColour = New System.Windows.Forms.Label()
        Me.lblGoldColour = New System.Windows.Forms.Label()
        Me.lblInvoicedNotPayed = New System.Windows.Forms.Label()
        Me.lblRedColour = New System.Windows.Forms.Label()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnMarkAsNotExported = New System.Windows.Forms.Button()
        Me.btnGenVal = New System.Windows.Forms.Button()
        Me.cmsValType = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiNCCVal = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiGenericVal = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiSorVal = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsChange = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiPaymentTerms = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiInvoicedTotal = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiVatRate = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAccountNumber = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiOrderNo = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsSalesCredit = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiIssue = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBatchPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsExportForAccounts = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiSunExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiSageExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExportToAccounts = New System.Windows.Forms.Button()
        Me.grpFilter.SuspendLayout()
        Me.grpInvoices.SuspendLayout()
        CType(Me.dgInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsValType.SuspendLayout()
        Me.cmsChange.SuspendLayout()
        Me.cmsSalesCredit.SuspendLayout()
        Me.cmsExportForAccounts.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPrintOneItemOneInvoice
        '
        Me.btnPrintOneItemOneInvoice.AccessibleDescription = "Export Job List To Excel"
        Me.btnPrintOneItemOneInvoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintOneItemOneInvoice.Location = New System.Drawing.Point(125, 594)
        Me.btnPrintOneItemOneInvoice.Name = "btnPrintOneItemOneInvoice"
        Me.btnPrintOneItemOneInvoice.Size = New System.Drawing.Size(141, 23)
        Me.btnPrintOneItemOneInvoice.TabIndex = 27
        Me.btnPrintOneItemOneInvoice.Text = "Regenerate Invoice"
        '
        'btnExport
        '
        Me.btnExport.AccessibleDescription = "Export Job List To Excel"
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(8, 594)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(56, 23)
        Me.btnExport.TabIndex = 25
        Me.btnExport.Text = "Export"
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(67, 594)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(55, 23)
        Me.btnReset.TabIndex = 26
        Me.btnReset.Text = "Reset"
        '
        'grpFilter
        '
        Me.grpFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilter.Controls.Add(Me.dtpExportedOn)
        Me.grpFilter.Controls.Add(Me.lblExportedOn)
        Me.grpFilter.Controls.Add(Me.lblDept)
        Me.grpFilter.Controls.Add(Me.cboDept)
        Me.grpFilter.Controls.Add(Me.lblSageMonth)
        Me.grpFilter.Controls.Add(Me.txtSageMonth)
        Me.grpFilter.Controls.Add(Me.lblRegion)
        Me.grpFilter.Controls.Add(Me.cboRegion)
        Me.grpFilter.Controls.Add(Me.btnSearch)
        Me.grpFilter.Controls.Add(Me.cboExported)
        Me.grpFilter.Controls.Add(Me.lblExported)
        Me.grpFilter.Controls.Add(Me.btnFindCustomer)
        Me.grpFilter.Controls.Add(Me.txtCustomer)
        Me.grpFilter.Controls.Add(Me.lblCustomer)
        Me.grpFilter.Controls.Add(Me.txtPostcode)
        Me.grpFilter.Controls.Add(Me.lblPostcode)
        Me.grpFilter.Controls.Add(Me.btnFindSite)
        Me.grpFilter.Controls.Add(Me.txtSite)
        Me.grpFilter.Controls.Add(Me.txtJobNumber)
        Me.grpFilter.Controls.Add(Me.lblRefNo)
        Me.grpFilter.Controls.Add(Me.lblProperty)
        Me.grpFilter.Controls.Add(Me.lblType)
        Me.grpFilter.Controls.Add(Me.cboType)
        Me.grpFilter.Controls.Add(Me.lblDateBetween)
        Me.grpFilter.Controls.Add(Me.dtpRaisedFrom)
        Me.grpFilter.Controls.Add(Me.dtpRaisedTo)
        Me.grpFilter.Controls.Add(Me.lblDate)
        Me.grpFilter.Controls.Add(Me.cboStatus)
        Me.grpFilter.Controls.Add(Me.lblStatus)
        Me.grpFilter.Controls.Add(Me.lblInvoiceNumber)
        Me.grpFilter.Controls.Add(Me.lblUser)
        Me.grpFilter.Controls.Add(Me.cboUser)
        Me.grpFilter.Controls.Add(Me.txtInvoiceNumber)
        Me.grpFilter.Controls.Add(Me.chkExportedOn)
        Me.grpFilter.Location = New System.Drawing.Point(8, 32)
        Me.grpFilter.Name = "grpFilter"
        Me.grpFilter.Size = New System.Drawing.Size(1123, 236)
        Me.grpFilter.TabIndex = 24
        Me.grpFilter.TabStop = False
        Me.grpFilter.Text = "Filter"
        '
        'dtpExportedOn
        '
        Me.dtpExportedOn.Location = New System.Drawing.Point(541, 163)
        Me.dtpExportedOn.Name = "dtpExportedOn"
        Me.dtpExportedOn.Size = New System.Drawing.Size(186, 21)
        Me.dtpExportedOn.TabIndex = 44
        '
        'lblExportedOn
        '
        Me.lblExportedOn.Location = New System.Drawing.Point(416, 164)
        Me.lblExportedOn.Name = "lblExportedOn"
        Me.lblExportedOn.Size = New System.Drawing.Size(85, 16)
        Me.lblExportedOn.TabIndex = 45
        Me.lblExportedOn.Text = "Exported On"
        '
        'lblDept
        '
        Me.lblDept.AutoSize = True
        Me.lblDept.Location = New System.Drawing.Point(747, 166)
        Me.lblDept.Name = "lblDept"
        Me.lblDept.Size = New System.Drawing.Size(76, 13)
        Me.lblDept.TabIndex = 42
        Me.lblDept.Text = "Cost Centre"
        '
        'cboDept
        '
        Me.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDept.Location = New System.Drawing.Point(845, 164)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New System.Drawing.Size(224, 21)
        Me.cboDept.TabIndex = 43
        '
        'lblSageMonth
        '
        Me.lblSageMonth.Location = New System.Drawing.Point(416, 197)
        Me.lblSageMonth.Name = "lblSageMonth"
        Me.lblSageMonth.Size = New System.Drawing.Size(98, 19)
        Me.lblSageMonth.TabIndex = 40
        Me.lblSageMonth.Text = "Account Month"
        '
        'txtSageMonth
        '
        Me.txtSageMonth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSageMonth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSageMonth.Location = New System.Drawing.Point(520, 195)
        Me.txtSageMonth.Name = "txtSageMonth"
        Me.txtSageMonth.ReadOnly = True
        Me.txtSageMonth.Size = New System.Drawing.Size(207, 21)
        Me.txtSageMonth.TabIndex = 41
        '
        'lblRegion
        '
        Me.lblRegion.Location = New System.Drawing.Point(8, 198)
        Me.lblRegion.Name = "lblRegion"
        Me.lblRegion.Size = New System.Drawing.Size(72, 16)
        Me.lblRegion.TabIndex = 39
        Me.lblRegion.Text = "Region"
        '
        'cboRegion
        '
        Me.cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegion.Location = New System.Drawing.Point(160, 195)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(248, 21)
        Me.cboRegion.TabIndex = 38
        '
        'btnSearch
        '
        Me.btnSearch.AccessibleDescription = "Export Job List To Excel"
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(981, 198)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(88, 23)
        Me.btnSearch.TabIndex = 30
        Me.btnSearch.Text = "Run Filter"
        '
        'cboExported
        '
        Me.cboExported.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExported.Items.AddRange(New Object() {"Show All", "Exported", "Not Exported"})
        Me.cboExported.Location = New System.Drawing.Point(160, 161)
        Me.cboExported.Name = "cboExported"
        Me.cboExported.Size = New System.Drawing.Size(248, 21)
        Me.cboExported.TabIndex = 29
        '
        'lblExported
        '
        Me.lblExported.Location = New System.Drawing.Point(8, 164)
        Me.lblExported.Name = "lblExported"
        Me.lblExported.Size = New System.Drawing.Size(122, 18)
        Me.lblExported.TabIndex = 28
        Me.lblExported.Text = "Exported"
        '
        'btnFindCustomer
        '
        Me.btnFindCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindCustomer.BackColor = System.Drawing.Color.White
        Me.btnFindCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindCustomer.Location = New System.Drawing.Point(1077, 40)
        Me.btnFindCustomer.Name = "btnFindCustomer"
        Me.btnFindCustomer.Size = New System.Drawing.Size(32, 23)
        Me.btnFindCustomer.TabIndex = 2
        Me.btnFindCustomer.Text = "..."
        Me.btnFindCustomer.UseVisualStyleBackColor = False
        '
        'txtCustomer
        '
        Me.txtCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(160, 40)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(909, 21)
        Me.txtCustomer.TabIndex = 1
        '
        'lblCustomer
        '
        Me.lblCustomer.Location = New System.Drawing.Point(8, 40)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(64, 16)
        Me.lblCustomer.TabIndex = 27
        Me.lblCustomer.Text = "Customer"
        '
        'txtPostcode
        '
        Me.txtPostcode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPostcode.Location = New System.Drawing.Point(160, 88)
        Me.txtPostcode.Name = "txtPostcode"
        Me.txtPostcode.Size = New System.Drawing.Size(248, 21)
        Me.txtPostcode.TabIndex = 5
        '
        'lblPostcode
        '
        Me.lblPostcode.Location = New System.Drawing.Point(8, 88)
        Me.lblPostcode.Name = "lblPostcode"
        Me.lblPostcode.Size = New System.Drawing.Size(64, 16)
        Me.lblPostcode.TabIndex = 20
        Me.lblPostcode.Text = "Postcode"
        '
        'btnFindSite
        '
        Me.btnFindSite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindSite.BackColor = System.Drawing.Color.White
        Me.btnFindSite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindSite.Location = New System.Drawing.Point(1077, 64)
        Me.btnFindSite.Name = "btnFindSite"
        Me.btnFindSite.Size = New System.Drawing.Size(32, 23)
        Me.btnFindSite.TabIndex = 4
        Me.btnFindSite.Text = "..."
        Me.btnFindSite.UseVisualStyleBackColor = False
        '
        'txtSite
        '
        Me.txtSite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSite.Location = New System.Drawing.Point(160, 64)
        Me.txtSite.Name = "txtSite"
        Me.txtSite.ReadOnly = True
        Me.txtSite.Size = New System.Drawing.Size(909, 21)
        Me.txtSite.TabIndex = 3
        '
        'txtJobNumber
        '
        Me.txtJobNumber.Location = New System.Drawing.Point(160, 136)
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Size = New System.Drawing.Size(248, 21)
        Me.txtJobNumber.TabIndex = 9
        '
        'lblRefNo
        '
        Me.lblRefNo.Location = New System.Drawing.Point(8, 136)
        Me.lblRefNo.Name = "lblRefNo"
        Me.lblRefNo.Size = New System.Drawing.Size(136, 16)
        Me.lblRefNo.TabIndex = 6
        Me.lblRefNo.Text = "Job/Order/Contract No"
        '
        'lblProperty
        '
        Me.lblProperty.Location = New System.Drawing.Point(8, 64)
        Me.lblProperty.Name = "lblProperty"
        Me.lblProperty.Size = New System.Drawing.Size(64, 16)
        Me.lblProperty.TabIndex = 2
        Me.lblProperty.Text = "Property"
        '
        'lblType
        '
        Me.lblType.Location = New System.Drawing.Point(8, 112)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(48, 16)
        Me.lblType.TabIndex = 4
        Me.lblType.Text = "Type"
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Location = New System.Drawing.Point(160, 112)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(248, 21)
        Me.cboType.TabIndex = 7
        '
        'lblDateBetween
        '
        Me.lblDateBetween.Location = New System.Drawing.Point(416, 16)
        Me.lblDateBetween.Name = "lblDateBetween"
        Me.lblDateBetween.Size = New System.Drawing.Size(48, 16)
        Me.lblDateBetween.TabIndex = 14
        Me.lblDateBetween.Text = "and"
        '
        'dtpRaisedFrom
        '
        Me.dtpRaisedFrom.Location = New System.Drawing.Point(160, 16)
        Me.dtpRaisedFrom.Name = "dtpRaisedFrom"
        Me.dtpRaisedFrom.Size = New System.Drawing.Size(248, 21)
        Me.dtpRaisedFrom.TabIndex = 15
        '
        'dtpRaisedTo
        '
        Me.dtpRaisedTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpRaisedTo.Location = New System.Drawing.Point(520, 16)
        Me.dtpRaisedTo.Name = "dtpRaisedTo"
        Me.dtpRaisedTo.Size = New System.Drawing.Size(549, 21)
        Me.dtpRaisedTo.TabIndex = 16
        '
        'lblDate
        '
        Me.lblDate.Location = New System.Drawing.Point(8, 16)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(136, 16)
        Me.lblDate.TabIndex = 17
        Me.lblDate.Text = "Raised Date Between : "
        '
        'cboStatus
        '
        Me.cboStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Location = New System.Drawing.Point(520, 88)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(549, 21)
        Me.cboStatus.TabIndex = 8
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(416, 90)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(48, 16)
        Me.lblStatus.TabIndex = 5
        Me.lblStatus.Text = "Status"
        '
        'lblInvoiceNumber
        '
        Me.lblInvoiceNumber.Location = New System.Drawing.Point(416, 114)
        Me.lblInvoiceNumber.Name = "lblInvoiceNumber"
        Me.lblInvoiceNumber.Size = New System.Drawing.Size(104, 16)
        Me.lblInvoiceNumber.TabIndex = 10
        Me.lblInvoiceNumber.Text = "Invoice Number"
        '
        'lblUser
        '
        Me.lblUser.BackColor = System.Drawing.Color.White
        Me.lblUser.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.Location = New System.Drawing.Point(416, 138)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(40, 16)
        Me.lblUser.TabIndex = 12
        Me.lblUser.Text = "User"
        '
        'cboUser
        '
        Me.cboUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUser.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUser.ItemHeight = 13
        Me.cboUser.Location = New System.Drawing.Point(520, 136)
        Me.cboUser.Name = "cboUser"
        Me.cboUser.Size = New System.Drawing.Size(549, 21)
        Me.cboUser.TabIndex = 13
        '
        'txtInvoiceNumber
        '
        Me.txtInvoiceNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInvoiceNumber.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceNumber.Location = New System.Drawing.Point(520, 112)
        Me.txtInvoiceNumber.Name = "txtInvoiceNumber"
        Me.txtInvoiceNumber.Size = New System.Drawing.Size(549, 21)
        Me.txtInvoiceNumber.TabIndex = 11
        '
        'chkExportedOn
        '
        Me.chkExportedOn.AutoCheck = False
        Me.chkExportedOn.AutoSize = True
        Me.chkExportedOn.Location = New System.Drawing.Point(520, 166)
        Me.chkExportedOn.Name = "chkExportedOn"
        Me.chkExportedOn.Size = New System.Drawing.Size(30, 17)
        Me.chkExportedOn.TabIndex = 46
        Me.chkExportedOn.Text = " "
        Me.chkExportedOn.UseVisualStyleBackColor = True
        '
        'grpInvoices
        '
        Me.grpInvoices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpInvoices.Controls.Add(Me.btnSalesCredit)
        Me.grpInvoices.Controls.Add(Me.btnChange)
        Me.grpInvoices.Controls.Add(Me.dgInvoices)
        Me.grpInvoices.Controls.Add(Me.btnSelectAll)
        Me.grpInvoices.Controls.Add(Me.btnDeselectAll)
        Me.grpInvoices.Controls.Add(Me.lblInvoicePartPayed)
        Me.grpInvoices.Controls.Add(Me.lblInvoicePayed)
        Me.grpInvoices.Controls.Add(Me.lblGreenColour)
        Me.grpInvoices.Controls.Add(Me.lblGoldColour)
        Me.grpInvoices.Controls.Add(Me.lblInvoicedNotPayed)
        Me.grpInvoices.Controls.Add(Me.lblRedColour)
        Me.grpInvoices.Location = New System.Drawing.Point(8, 274)
        Me.grpInvoices.Name = "grpInvoices"
        Me.grpInvoices.Size = New System.Drawing.Size(1123, 314)
        Me.grpInvoices.TabIndex = 23
        Me.grpInvoices.TabStop = False
        Me.grpInvoices.Text = "Double Click To View / Add Payment Information"
        '
        'btnSalesCredit
        '
        Me.btnSalesCredit.AccessibleDescription = ""
        Me.btnSalesCredit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalesCredit.Location = New System.Drawing.Point(827, 24)
        Me.btnSalesCredit.Name = "btnSalesCredit"
        Me.btnSalesCredit.Size = New System.Drawing.Size(148, 23)
        Me.btnSalesCredit.TabIndex = 35
        Me.btnSalesCredit.Text = "Sales Credit"
        '
        'btnChange
        '
        Me.btnChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChange.Location = New System.Drawing.Point(981, 24)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(136, 23)
        Me.btnChange.TabIndex = 27
        Me.btnChange.Text = "Change"
        '
        'dgInvoices
        '
        Me.dgInvoices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgInvoices.DataMember = ""
        Me.dgInvoices.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgInvoices.Location = New System.Drawing.Point(8, 72)
        Me.dgInvoices.Name = "dgInvoices"
        Me.dgInvoices.Size = New System.Drawing.Size(1109, 232)
        Me.dgInvoices.TabIndex = 14
        '
        'btnSelectAll
        '
        Me.btnSelectAll.AccessibleDescription = "Export Job List To Excel"
        Me.btnSelectAll.Location = New System.Drawing.Point(8, 24)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(88, 23)
        Me.btnSelectAll.TabIndex = 19
        Me.btnSelectAll.Text = "Select All"
        '
        'btnDeselectAll
        '
        Me.btnDeselectAll.Location = New System.Drawing.Point(104, 24)
        Me.btnDeselectAll.Name = "btnDeselectAll"
        Me.btnDeselectAll.Size = New System.Drawing.Size(88, 23)
        Me.btnDeselectAll.TabIndex = 20
        Me.btnDeselectAll.Text = "Deselect All"
        '
        'lblInvoicePartPayed
        '
        Me.lblInvoicePartPayed.Location = New System.Drawing.Point(259, 52)
        Me.lblInvoicePartPayed.Name = "lblInvoicePartPayed"
        Me.lblInvoicePartPayed.Size = New System.Drawing.Size(224, 23)
        Me.lblInvoicePartPayed.TabIndex = 26
        Me.lblInvoicePartPayed.Text = "Invoiced - Some Payments Received"
        '
        'lblInvoicePayed
        '
        Me.lblInvoicePayed.Location = New System.Drawing.Point(515, 52)
        Me.lblInvoicePayed.Name = "lblInvoicePayed"
        Me.lblInvoicePayed.Size = New System.Drawing.Size(120, 23)
        Me.lblInvoicePayed.TabIndex = 25
        Me.lblInvoicePayed.Text = "Invoiced and Paid"
        '
        'lblGreenColour
        '
        Me.lblGreenColour.BackColor = System.Drawing.Color.LightGreen
        Me.lblGreenColour.Location = New System.Drawing.Point(491, 52)
        Me.lblGreenColour.Name = "lblGreenColour"
        Me.lblGreenColour.Size = New System.Drawing.Size(23, 23)
        Me.lblGreenColour.TabIndex = 24
        '
        'lblGoldColour
        '
        Me.lblGoldColour.BackColor = System.Drawing.Color.Gold
        Me.lblGoldColour.Location = New System.Drawing.Point(235, 51)
        Me.lblGoldColour.Name = "lblGoldColour"
        Me.lblGoldColour.Size = New System.Drawing.Size(23, 23)
        Me.lblGoldColour.TabIndex = 23
        '
        'lblInvoicedNotPayed
        '
        Me.lblInvoicedNotPayed.Location = New System.Drawing.Point(35, 52)
        Me.lblInvoicedNotPayed.Name = "lblInvoicedNotPayed"
        Me.lblInvoicedNotPayed.Size = New System.Drawing.Size(200, 23)
        Me.lblInvoicedNotPayed.TabIndex = 22
        Me.lblInvoicedNotPayed.Text = "Invoiced - No Payments Received"
        '
        'lblRedColour
        '
        Me.lblRedColour.BackColor = System.Drawing.Color.Red
        Me.lblRedColour.Location = New System.Drawing.Point(11, 51)
        Me.lblRedColour.Name = "lblRedColour"
        Me.lblRedColour.Size = New System.Drawing.Size(23, 23)
        Me.lblRedColour.TabIndex = 21
        '
        'btnView
        '
        Me.btnView.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnView.Location = New System.Drawing.Point(561, 594)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(59, 23)
        Me.btnView.TabIndex = 29
        Me.btnView.Text = "View"
        '
        'btnMarkAsNotExported
        '
        Me.btnMarkAsNotExported.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMarkAsNotExported.CausesValidation = False
        Me.btnMarkAsNotExported.Location = New System.Drawing.Point(813, 594)
        Me.btnMarkAsNotExported.Name = "btnMarkAsNotExported"
        Me.btnMarkAsNotExported.Size = New System.Drawing.Size(146, 23)
        Me.btnMarkAsNotExported.TabIndex = 31
        Me.btnMarkAsNotExported.Text = "Unmark Exports"
        Me.btnMarkAsNotExported.UseVisualStyleBackColor = True
        '
        'btnGenVal
        '
        Me.btnGenVal.AccessibleDescription = ""
        Me.btnGenVal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGenVal.Location = New System.Drawing.Point(270, 594)
        Me.btnGenVal.Name = "btnGenVal"
        Me.btnGenVal.Size = New System.Drawing.Size(125, 23)
        Me.btnGenVal.TabIndex = 32
        Me.btnGenVal.Text = "Generate Val"
        '
        'cmsValType
        '
        Me.cmsValType.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiNCCVal, Me.tsmiGenericVal, Me.tsmiSorVal})
        Me.cmsValType.Name = "cmsValType"
        Me.cmsValType.Size = New System.Drawing.Size(115, 70)
        '
        'tsmiNCCVal
        '
        Me.tsmiNCCVal.Name = "tsmiNCCVal"
        Me.tsmiNCCVal.Size = New System.Drawing.Size(114, 22)
        Me.tsmiNCCVal.Text = "NCC"
        '
        'tsmiGenericVal
        '
        Me.tsmiGenericVal.Name = "tsmiGenericVal"
        Me.tsmiGenericVal.Size = New System.Drawing.Size(114, 22)
        Me.tsmiGenericVal.Text = "Generic"
        '
        'tsmiSorVal
        '
        Me.tsmiSorVal.Name = "tsmiSorVal"
        Me.tsmiSorVal.Size = New System.Drawing.Size(114, 22)
        Me.tsmiSorVal.Text = "SOR"
        '
        'cmsChange
        '
        Me.cmsChange.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiPaymentTerms, Me.tsmiInvoicedTotal, Me.tsmiVatRate, Me.tsmiAccountNumber, Me.tsmiOrderNo})
        Me.cmsChange.Name = "cmsChange"
        Me.cmsChange.Size = New System.Drawing.Size(167, 114)
        '
        'tsmiPaymentTerms
        '
        Me.tsmiPaymentTerms.Name = "tsmiPaymentTerms"
        Me.tsmiPaymentTerms.Size = New System.Drawing.Size(166, 22)
        Me.tsmiPaymentTerms.Text = "Payment Terms"
        '
        'tsmiInvoicedTotal
        '
        Me.tsmiInvoicedTotal.Name = "tsmiInvoicedTotal"
        Me.tsmiInvoicedTotal.Size = New System.Drawing.Size(166, 22)
        Me.tsmiInvoicedTotal.Text = "Invoiced Total"
        '
        'tsmiVatRate
        '
        Me.tsmiVatRate.Name = "tsmiVatRate"
        Me.tsmiVatRate.Size = New System.Drawing.Size(166, 22)
        Me.tsmiVatRate.Text = "Vat Rate"
        '
        'tsmiAccountNumber
        '
        Me.tsmiAccountNumber.Name = "tsmiAccountNumber"
        Me.tsmiAccountNumber.Size = New System.Drawing.Size(166, 22)
        Me.tsmiAccountNumber.Text = "Account Number"
        '
        'tsmiOrderNo
        '
        Me.tsmiOrderNo.Name = "tsmiOrderNo"
        Me.tsmiOrderNo.Size = New System.Drawing.Size(166, 22)
        Me.tsmiOrderNo.Text = "Order No"
        '
        'cmsSalesCredit
        '
        Me.cmsSalesCredit.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiIssue, Me.tsmiRemove, Me.tsmiBatchPrint})
        Me.cmsSalesCredit.Name = "ContextMenuStrip2"
        Me.cmsSalesCredit.Size = New System.Drawing.Size(197, 70)
        '
        'tsmiIssue
        '
        Me.tsmiIssue.Name = "tsmiIssue"
        Me.tsmiIssue.Size = New System.Drawing.Size(196, 22)
        Me.tsmiIssue.Text = "Issue Sales Credit"
        '
        'tsmiRemove
        '
        Me.tsmiRemove.Name = "tsmiRemove"
        Me.tsmiRemove.Size = New System.Drawing.Size(196, 22)
        Me.tsmiRemove.Text = "Remove Sales Credit"
        '
        'tsmiBatchPrint
        '
        Me.tsmiBatchPrint.Name = "tsmiBatchPrint"
        Me.tsmiBatchPrint.Size = New System.Drawing.Size(196, 22)
        Me.tsmiBatchPrint.Text = "Batch Print Sales Credit"
        '
        'cmsExportForAccounts
        '
        Me.cmsExportForAccounts.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiSunExport, Me.tsmiSageExport})
        Me.cmsExportForAccounts.Name = "cmsExportForAccounts"
        Me.cmsExportForAccounts.Size = New System.Drawing.Size(152, 48)
        '
        'tsmiSunExport
        '
        Me.tsmiSunExport.Name = "tsmiSunExport"
        Me.tsmiSunExport.Size = New System.Drawing.Size(151, 22)
        Me.tsmiSunExport.Text = "Export To Sun"
        '
        'tsmiSageExport
        '
        Me.tsmiSageExport.Name = "tsmiSageExport"
        Me.tsmiSageExport.Size = New System.Drawing.Size(151, 22)
        Me.tsmiSageExport.Text = "Export To Sage"
        '
        'btnExportToAccounts
        '
        Me.btnExportToAccounts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportToAccounts.Location = New System.Drawing.Point(965, 594)
        Me.btnExportToAccounts.Name = "btnExportToAccounts"
        Me.btnExportToAccounts.Size = New System.Drawing.Size(166, 23)
        Me.btnExportToAccounts.TabIndex = 35
        Me.btnExportToAccounts.Text = "Export To Accounts"
        '
        'FRMInvoicedManager
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(1137, 626)
        Me.Controls.Add(Me.btnExportToAccounts)
        Me.Controls.Add(Me.btnGenVal)
        Me.Controls.Add(Me.btnMarkAsNotExported)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnPrintOneItemOneInvoice)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.grpFilter)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.grpInvoices)
        Me.Name = "FRMInvoicedManager"
        Me.Text = "Invoiced Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpInvoices, 0)
        Me.Controls.SetChildIndex(Me.btnReset, 0)
        Me.Controls.SetChildIndex(Me.grpFilter, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.btnPrintOneItemOneInvoice, 0)
        Me.Controls.SetChildIndex(Me.btnView, 0)
        Me.Controls.SetChildIndex(Me.btnMarkAsNotExported, 0)
        Me.Controls.SetChildIndex(Me.btnGenVal, 0)
        Me.Controls.SetChildIndex(Me.btnExportToAccounts, 0)
        Me.grpFilter.ResumeLayout(False)
        Me.grpFilter.PerformLayout()
        Me.grpInvoices.ResumeLayout(False)
        CType(Me.dgInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsValType.ResumeLayout(False)
        Me.cmsChange.ResumeLayout(False)
        Me.cmsSalesCredit.ResumeLayout(False)
        Me.cmsExportForAccounts.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        SetupInvoiceDataGrid()
        ResetFilters()
        Try
            If Not GetParameter(0) Is Nothing Then
                InvoicesDataview = GetParameter(0)

                CType(Me, IBaseForm).SetFormParameters = Nothing
            End If
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private _dvInvoices As DataView

    Private Property InvoicesDataview() As DataView
        Get
            Return _dvInvoices
        End Get
        Set(ByVal value As DataView)
            _dvInvoices = value
            _dvInvoices.AllowNew = False
            _dvInvoices.AllowEdit = True
            _dvInvoices.AllowDelete = False
            _dvInvoices.Table.TableName = Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString
            Me.dgInvoices.DataSource = InvoicesDataview
        End Set
    End Property

    Private ReadOnly Property SelectedInvoiceDataRow() As DataRow
        Get
            If Not Me.dgInvoices.CurrentRowIndex = -1 Then
                Return InvoicesDataview(Me.dgInvoices.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _theCustomer As Entity.Customers.Customer

    Public Property theCustomer() As Entity.Customers.Customer
        Get
            Return _theCustomer
        End Get
        Set(ByVal Value As Entity.Customers.Customer)
            _theCustomer = Value
            theSite = Nothing
            If Not _theCustomer Is Nothing Then
                Me.txtCustomer.Text = theCustomer.Name & " (A/C No : " & theCustomer.AccountNumber & ")"
            Else
                Me.txtCustomer.Text = ""

            End If
        End Set
    End Property

    Private _oSite As Entity.Sites.Site

    Public Property theSite() As Entity.Sites.Site
        Get
            Return _oSite
        End Get
        Set(ByVal Value As Entity.Sites.Site)
            _oSite = Value
            If Not _oSite Is Nothing Then
                Me.txtSite.Text = theSite.Address1 & ", " & theSite.Address2 & ", " & theSite.Postcode
            Else
                Me.txtSite.Text = ""
            End If
        End Set
    End Property

    Private _invoicesToPrint As New ArrayList

    Private Property InvoicesToPrint() As ArrayList
        Get
            Return _invoicesToPrint
        End Get
        Set(ByVal Value As ArrayList)
            _invoicesToPrint = Value
        End Set
    End Property

    Private _IsLoading As Boolean = True

    Private Property IsLoading() As Boolean
        Get
            Return _IsLoading
        End Get
        Set(ByVal Value As Boolean)
            _IsLoading = Value
        End Set
    End Property

#End Region

#Region "Setup"

    Private Sub SetupInvoiceDataGrid()
        Helper.SetUpDataGrid(dgInvoices)
        Dim tbStyle As DataGridTableStyle = Me.dgInvoices.TableStyles(0)

        tbStyle.GridColumnStyles.Clear()
        ' tbStyle.AllowSorting = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tbStyle.GridColumnStyles.Add(Tick)

        Dim PaidStatus As New PaidStatusColourColumn
        PaidStatus.Format = ""
        PaidStatus.FormatInfo = Nothing
        PaidStatus.HeaderText = "Paid"
        PaidStatus.MappingName = "PaidStatus"
        PaidStatus.ReadOnly = True
        PaidStatus.Width = 30
        PaidStatus.NullText = ""
        tbStyle.GridColumnStyles.Add(PaidStatus)

        Dim Customer As New DataGridLabelColumn
        Customer.Format = ""
        Customer.FormatInfo = Nothing
        Customer.HeaderText = "Customer"
        Customer.MappingName = "Customer"
        Customer.ReadOnly = True
        Customer.Width = 75
        Customer.NullText = ""
        tbStyle.GridColumnStyles.Add(Customer)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Property"
        Site.MappingName = "Site"
        Site.ReadOnly = True
        Site.Width = 75
        Site.NullText = ""
        tbStyle.GridColumnStyles.Add(Site)

        Dim InvoiceType As New DataGridLabelColumn
        InvoiceType.Format = ""
        InvoiceType.FormatInfo = Nothing
        InvoiceType.HeaderText = "Inv. Type"
        InvoiceType.MappingName = "InvoiceType"
        InvoiceType.ReadOnly = True
        InvoiceType.Width = 75
        InvoiceType.NullText = ""
        tbStyle.GridColumnStyles.Add(InvoiceType)

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "Job/Ord/Con No."
        JobNumber.MappingName = "JobNumber"
        JobNumber.ReadOnly = True
        JobNumber.Width = 85
        JobNumber.NullText = ""
        tbStyle.GridColumnStyles.Add(JobNumber)

        Dim InvoiceAddressType As New DataGridLabelColumn
        InvoiceAddressType.Format = ""
        InvoiceAddressType.FormatInfo = Nothing
        InvoiceAddressType.HeaderText = "Inv. Addr. Type"
        InvoiceAddressType.MappingName = "InvoiceAddressType"
        InvoiceAddressType.ReadOnly = True
        InvoiceAddressType.Width = 75
        InvoiceAddressType.NullText = ""
        tbStyle.GridColumnStyles.Add(InvoiceAddressType)

        Dim InvoiceAddress As New DataGridLabelColumn
        InvoiceAddress.Format = ""
        InvoiceAddress.FormatInfo = Nothing
        InvoiceAddress.HeaderText = "Invoice Add."
        InvoiceAddress.MappingName = "InvoiceAddress"
        InvoiceAddress.ReadOnly = True
        InvoiceAddress.Width = 75
        InvoiceAddress.NullText = ""
        tbStyle.GridColumnStyles.Add(InvoiceAddress)

        Dim Amount As New DataGridLabelColumn
        Amount.Format = "C"
        Amount.FormatInfo = Nothing
        Amount.HeaderText = "Amount"
        Amount.MappingName = "Amount"
        Amount.ReadOnly = True
        Amount.Width = 75
        Amount.NullText = ""
        tbStyle.GridColumnStyles.Add(Amount)

        Dim VATRate As New DataGridLabelColumn
        VATRate.Format = ""
        VATRate.FormatInfo = Nothing
        VATRate.HeaderText = "VAT Rate"
        VATRate.MappingName = "VATRate"
        VATRate.ReadOnly = True
        VATRate.Width = 75
        VATRate.NullText = ""
        tbStyle.GridColumnStyles.Add(VATRate)

        Dim InvoiceNumber As New DataGridLabelColumn
        InvoiceNumber.Format = "C"
        InvoiceNumber.FormatInfo = Nothing
        InvoiceNumber.HeaderText = "Invoice No"
        InvoiceNumber.MappingName = "InvoiceNumber"
        InvoiceNumber.ReadOnly = True
        InvoiceNumber.Width = 75
        InvoiceNumber.NullText = ""
        tbStyle.GridColumnStyles.Add(InvoiceNumber)

        Dim RaisedOn As New DataGridLabelColumn
        RaisedOn.Format = "dd/MM/yyyy"
        RaisedOn.FormatInfo = Nothing
        RaisedOn.HeaderText = "Raised On"
        RaisedOn.MappingName = "RaisedDate"
        RaisedOn.ReadOnly = True
        RaisedOn.Width = 75
        RaisedOn.NullText = ""
        tbStyle.GridColumnStyles.Add(RaisedOn)

        Dim RaisedBy As New DataGridLabelColumn
        RaisedBy.Format = ""
        RaisedBy.FormatInfo = Nothing
        RaisedBy.HeaderText = "Raised By"
        RaisedBy.MappingName = "Fullname"
        RaisedBy.ReadOnly = True
        RaisedBy.Width = 75
        RaisedBy.NullText = ""
        tbStyle.GridColumnStyles.Add(RaisedBy)

        Dim DateExportedToSage As New DataGridLabelColumn
        DateExportedToSage.Format = "dd/MM/yyyy"
        DateExportedToSage.FormatInfo = Nothing
        DateExportedToSage.HeaderText = "Exported"
        DateExportedToSage.MappingName = "DateExportedToSage"
        DateExportedToSage.ReadOnly = True
        DateExportedToSage.Width = 105
        DateExportedToSage.NullText = ""
        tbStyle.GridColumnStyles.Add(DateExportedToSage)

        Dim SupplierInvoiceID As New DataGridLabelColumn
        SupplierInvoiceID.Format = ""
        SupplierInvoiceID.FormatInfo = Nothing
        SupplierInvoiceID.HeaderText = "Supplier Invoice ID"
        SupplierInvoiceID.MappingName = "SupplierInvoiceID"
        SupplierInvoiceID.ReadOnly = True
        SupplierInvoiceID.Width = 105
        SupplierInvoiceID.NullText = ""
        tbStyle.GridColumnStyles.Add(SupplierInvoiceID)

        Dim CreditAmount As New DataGridLabelColumn
        CreditAmount.Format = "C"
        CreditAmount.FormatInfo = Nothing
        CreditAmount.HeaderText = "Credited Amount"
        CreditAmount.MappingName = "CreditAmount"
        CreditAmount.ReadOnly = True
        CreditAmount.Width = 80
        CreditAmount.NullText = ""
        tbStyle.GridColumnStyles.Add(CreditAmount)

        Dim PaymentTerm As New DataGridLabelColumn
        PaymentTerm.Format = ""
        PaymentTerm.FormatInfo = Nothing
        PaymentTerm.HeaderText = "Payment Term"
        PaymentTerm.MappingName = "PaymentTerm"
        PaymentTerm.ReadOnly = True
        PaymentTerm.Width = 120
        PaymentTerm.NullText = ""
        tbStyle.GridColumnStyles.Add(PaymentTerm)

        Dim PaymentBy As New DataGridLabelColumn
        PaymentBy.Format = ""
        PaymentBy.FormatInfo = Nothing
        PaymentBy.HeaderText = "Payment by"
        PaymentBy.MappingName = "PaymentBy"
        PaymentBy.ReadOnly = True
        PaymentBy.Width = 100
        PaymentBy.NullText = ""
        tbStyle.GridColumnStyles.Add(PaymentBy)

        Dim AccountNumber As New DataGridLabelColumn
        AccountNumber.Format = ""
        AccountNumber.FormatInfo = Nothing
        AccountNumber.HeaderText = "Acc Number"
        AccountNumber.MappingName = "AccountNumber"
        AccountNumber.ReadOnly = True
        AccountNumber.Width = 100
        AccountNumber.NullText = ""
        tbStyle.GridColumnStyles.Add(AccountNumber)

        Dim orderNo As New DataGridEditableTextBoxColumn
        orderNo.Format = ""
        orderNo.FormatInfo = Nothing
        orderNo.HeaderText = "Order No"
        orderNo.MappingName = "OrderNo"
        orderNo.ReadOnly = False
        orderNo.Width = 100
        orderNo.NullText = ""
        tbStyle.GridColumnStyles.Add(orderNo)

        tbStyle.ReadOnly = False
        dgInvoices.ReadOnly = False
        tbStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString
        Me.dgInvoices.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMInvoicedManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        IsLoading = True
        LoadMe(sender, e)
        IsLoading = False
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        view()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ResetFilters()
    End Sub

    Private Sub btnFindCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCustomer.Click
        Dim ID As Integer = FindRecord(Enums.TableNames.tblCustomer)
        If Not ID = 0 Then
            theCustomer = DB.Customer.Customer_Get(ID)
        End If
    End Sub

    Private Sub btnFindSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindSite.Click
        Dim ID As Integer
        If theCustomer Is Nothing Then
            ID = FindRecord(Enums.TableNames.tblSite)
        Else
            ID = FindRecord(Enums.TableNames.tblSite, theCustomer.CustomerID)
        End If
        If Not ID = 0 Then
            theSite = DB.Sites.Get(ID)
        End If
    End Sub

    Private Sub dgInvoices_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgInvoices.MouseUp
        Dim HitTestInfo As DataGrid.HitTestInfo
        HitTestInfo = dgInvoices.HitTest(e.X, e.Y)
        If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
            If HitTestInfo.Column = 0 Then
                Dim selected As Boolean = Not Helper.MakeBooleanValid(SelectedInvoiceDataRow.Item("tick"))
                SelectedInvoiceDataRow.Item("Tick") = selected
            End If
        End If
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        For itm As Integer = 0 To CType(dgInvoices.DataSource, DataView).Count - 1
            dgInvoices.CurrentRowIndex = itm
            SelectedInvoiceDataRow("tick") = 1
        Next
    End Sub

    Private Sub btnDeselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeselectAll.Click
        For itm As Integer = 0 To CType(dgInvoices.DataSource, DataView).Count - 1
            dgInvoices.CurrentRowIndex = itm
            SelectedInvoiceDataRow("tick") = 0
        Next
    End Sub

    Private Sub btnPrintOneItemOneInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintOneItemOneInvoice.Click
        Try
            If Not Check_Supplier_Invoices_And_Continue() Then
                Exit Sub
            End If

            FindPartPayJobs(False)

            Dim drTicked() As DataRow = (From sf In InvoicesDataview.Table.AsEnumerable() Where sf.Field(Of Boolean)("Tick") = True Select sf).ToArray()

            For Each i As DataRow In drTicked

                If i("InvoiceType") = "Sales Credit" Then  ' its a credit
                    Dim amountOfCreditsForInvoice As Integer = (From sf In InvoicesDataview.Table.AsEnumerable()
                                                                Where sf.Field(Of String)("InvoiceType") = "Sales Credit" And sf.Field(Of String)("InvoiceNumber") = i("InvoiceNumber")
                                                                Select sf).Count
                    Dim credit As DataTable = Nothing
                    Dim result As DialogResult = Nothing

                    If amountOfCreditsForInvoice > 1 Then
                        Dim message As String = "Invoice No: " & i("InvoiceNumber") & " has more than one credit." & vbCrLf & vbCrLf & "Do you want merge them together?"
                        result = ShowMessage(message, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    End If

                    If result <> Nothing AndAlso result = DialogResult.Yes Then
                        credit = DB.SalesCredit.InvoicedLines_GetAll_ByInvoicedNumber(i("InvoiceNumber")).Table
                    Else
                        credit = DB.SalesCredit.InvoicedLines_GetAll_ByCreditReference(i("JobNumber")).Table
                    End If
                    credit.Columns.Add("SalesCreditID")
                    credit.Rows(0)("SalesCreditID") = i("LinkID")
                    credit.Columns.Add("CreditReference")
                    credit.Rows(0)("CreditReference") = i("JobNumber")
                    Dim oPrint As New Printing(credit, "Sales Credit", Enums.SystemDocumentType.SalesCredit)
                Else  ' normal

                    If Helper.MakeIntegerValid(i("invoicedID")) = 0 Then
                        Dim inv As New Entity.Invoiceds.Invoiced
                        'AMY IS CHEATING AND USING JOB NUMBER - 5 isn't a job definition!
                        Dim invNum As New JobNumber
                        invNum = DB.Job.GetNextJobNumber(5)
                        inv.SetInvoiceNumber = invNum.Prefix & invNum.JobNumber
                        inv.SetRaisedByUserID = loggedInUser.UserID
                        inv.RaisedDate = Now
                        inv = DB.Invoiced.Insert(inv)

                        Dim invLines As New Entity.InvoicedLiness.InvoicedLines
                        invLines.SetAmount = Helper.MakeDoubleValid(i("Amount"))
                        invLines.SetInvoicedID = inv.InvoicedID
                        invLines.SetInvoiceToBeRaisedID = i("InvoiceToBeRaisedID")
                        invLines = DB.InvoicedLines.Insert(invLines)

                        Dim PrintArray As New ArrayList
                        PrintArray.Add(i("InvoicedID"))
                        PrintArray.Add(i("RegionID"))
                        InvoicesToPrint.Add(PrintArray)
                    Else
                        Dim exists As Boolean = False
                        For Each al As ArrayList In InvoicesToPrint
                            If al(0) = i("InvoicedID") Then ' check if the invoice id is already in....
                                exists = True
                            End If
                        Next

                        If exists = False Then ' if not add it.
                            Dim PrintArray As New ArrayList
                            PrintArray.Add(i("InvoicedID"))
                            PrintArray.Add(i("RegionID"))
                            InvoicesToPrint.Add(PrintArray)
                        End If

                    End If
                End If
            Next

            Print()
            PopulateDatagrid()
        Catch ex As Exception
            MessageBox.Show("An Error has occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnPrintManyItemsOnOneInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Not Check_Supplier_Invoices_And_Continue() Then
                Exit Sub
            End If

            FindPartPayJobs(True)

            Dim dtDone As New DataTable
            dtDone.Columns.Add("AddressTypeID")
            dtDone.Columns.Add("AddressID")

            For Each i As DataRow In InvoicesDataview.Table.Rows
                If Helper.MakeBooleanValid(i("tick")) = True Then

                    If Helper.MakeIntegerValid(i("invoicedID")) = 0 Then
                        If dtDone.Select("AddressTypeID=" & i("AddressTypeID") & " AND AddressID=" & i("AddressID")).Length = 0 Then
                            Dim drInv() As DataRow = InvoicesDataview.Table.Select("AddressTypeID=" & i("AddressTypeID") & " AND AddressID=" & i("AddressID") & " AND Tick = 1")
                            Dim inv As New Entity.Invoiceds.Invoiced
                            Dim invNum As New JobNumber
                            invNum = DB.Job.GetNextJobNumber(5)
                            inv.SetInvoiceNumber = invNum.Prefix & invNum.JobNumber
                            inv.SetRaisedByUserID = loggedInUser.UserID
                            inv.RaisedDate = Now
                            inv = DB.Invoiced.Insert(inv)

                            For j As Integer = 0 To drInv.Length - 1
                                Dim invLines As New Entity.InvoicedLiness.InvoicedLines
                                invLines.SetAmount = Helper.MakeDoubleValid(drInv(j).Item("Amount"))
                                invLines.SetInvoicedID = inv.InvoicedID
                                invLines.SetInvoiceToBeRaisedID = drInv(j).Item("InvoiceToBeRaisedID")
                                invLines = DB.InvoicedLines.Insert(invLines)
                            Next j

                            InvoicesToPrint.Add(inv.InvoicedID)

                            Dim r As DataRow
                            r = dtDone.NewRow
                            r("AddressTypeID") = i("AddressTypeID")
                            r("AddressID") = i("AddressID")
                            dtDone.Rows.Add(r)
                        End If
                    Else
                        If Not InvoicesToPrint.Contains(i("invoicedID")) Then
                            InvoicesToPrint.Add(Helper.MakeIntegerValid(i("invoicedID")))
                        End If
                    End If
                End If
            Next

            Print()
            PopulateDatagrid()
        Catch ex As Exception
            MessageBox.Show("An Error has occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgInvoices_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgInvoices.DoubleClick
        If Not loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance) Then
            Dim msg As String = "You do not have the necessary security permissions."
            Throw New Security.SecurityException(msg)
        End If
        If Not SelectedInvoiceDataRow Is Nothing Then
            If SelectedInvoiceDataRow.Item("InvoiceType") = "Supplier" Or SelectedInvoiceDataRow.Item("InvoiceType") = "Consolidation" Then
                ShowMessage("Payments cannot be managed for a supplier invoice", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Not Helper.MakeIntegerValid(SelectedInvoiceDataRow("InvoicedID")) = 0 Then
                With SelectedInvoiceDataRow
                    ShowForm(GetType(FrmInvoicedPayment), True, New Object() { .Item("InvoicedID"), .Item("Customer"), .Item("InvoiceAddress"),
                             .Item("InvoiceNumber"), .Item("RaisedDate"), .Item("Fullname"), .Item("EngineerVisitID"), .Item("VATRate"), Me})
                End With
            Else
                ShowMessage("An Invoice must be generated before payments can be applied for or received", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
        If Not SelectedInvoiceDataRow Is Nothing Then
            For Each r As DataRow In InvoicesDataview.Table.Rows
                If CBool(r("tick")) Then
                    If r("InvoiceType") = "Sales Credit" Then ' It was possible to use the change button and it would somehow change the original invoice of the credit so i stopped this.
                        ShowMessage("You can not change credits", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                End If
            Next
        End If
        cmsChange.Show(btnChange, New Point(0, 0))
    End Sub

    Private Sub tsmiPaymentTerms_Click(sender As Object, e As EventArgs) Handles tsmiPaymentTerms.Click
        If Not loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance) Then
            Dim msg As String = "You do not have the necessary security permissions."
            Throw New Security.SecurityException(msg)
        End If
        If Not SelectedInvoiceDataRow Is Nothing Then
            'POP UP FORM
            Dim fCIT As FRMChangePaymentTerms = ShowForm(GetType(FRMChangePaymentTerms), True, New Object() {SelectedInvoiceDataRow("InvoicedID"), SelectedInvoiceDataRow("Amount")})
            If fCIT.DialogResult = DialogResult.OK Then
                SelectedInvoiceDataRow("PaymentTerm") = Combo.GetSelectedItemDescription(fCIT.cboPaymentTerm)
                If Combo.GetSelectedItemValue(fCIT.cboPaymentTerm) = 69491 Then
                    SelectedInvoiceDataRow("PaymentBy") = Combo.GetSelectedItemDescription(fCIT.cboPaidBy)
                Else
                    SelectedInvoiceDataRow("PaymentBy") = ""
                End If
            End If
        End If
    End Sub

    Private Sub tsmiInvoicedTotal_Click(sender As Object, e As EventArgs) Handles tsmiInvoicedTotal.Click
        If Not loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance) Then
            Dim msg As String = "You do not have the necessary security permissions."
            Throw New Security.SecurityException(msg)
        End If
        If Not SelectedInvoiceDataRow Is Nothing Then
            'POP UP FORM
            If CBool(SelectedInvoiceDataRow("ExportedToSage")) = False Then
                Dim fCIT As FRMChangeInvoicedTotal = ShowForm(GetType(FRMChangeInvoicedTotal), True, New Object() {
                                                              SelectedInvoiceDataRow("InvoicedLineID"), SelectedInvoiceDataRow("Amount"), SelectedInvoiceDataRow("AccountNumber"),
                                                              SelectedInvoiceDataRow("Department"), SelectedInvoiceDataRow("NominalCode"), SelectedInvoiceDataRow("RaisedDate"),
                                                              SelectedInvoiceDataRow("InvoiceTypeID")})
                If fCIT.DialogResult = DialogResult.OK Then
                    SelectedInvoiceDataRow("Amount") = fCIT.txtInvoicedTotal.Text
                    SelectedInvoiceDataRow("AccountNumber") = fCIT.txtAccount.Text
                    SelectedInvoiceDataRow("Department") = fCIT.txtDept.Text
                    SelectedInvoiceDataRow("NominalCode") = fCIT.txtNominal.Text
                    SelectedInvoiceDataRow("RaisedDate") = fCIT.dtpTaxDate.Value
                End If
            Else
                ShowMessage("This invoice has already been exported", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub tsmiVatRate_Click(sender As Object, e As EventArgs) Handles tsmiVatRate.Click
        If Not loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance) Then
            Dim msg As String = "You do not have the necessary security permissions."
            Throw New Security.SecurityException(msg)
        End If
        If SelectedInvoiceDataRow Is Nothing Then
            Exit Sub
        End If

        If SelectedInvoiceDataRow.Item("InvoiceType") = "Supplier" Or SelectedInvoiceDataRow.Item("InvoiceType") = "Consolidation" Then
            ShowMessage("VAT Rate cannot be changed for a supplier invoice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Using f As New FRMChangeVAT(SelectedInvoiceDataRow("VATRateID"), SelectedInvoiceDataRow("InvoicedID"), SelectedInvoiceDataRow("InvoiceNumber"))
            f.ShowDialog()
        End Using
        PopulateDatagrid()
    End Sub

    Private Sub btnSalesCredit_Click(sender As Object, e As EventArgs) Handles btnSalesCredit.Click
        cmsSalesCredit.Show(btnSalesCredit, New Point(0, 0))
    End Sub

    Private Sub tsmiAccountNumber_Click(sender As Object, e As EventArgs) Handles tsmiAccountNumber.Click
        If Not loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance) Then
            Dim msg As String = "You do not have the necessary security permissions."
            Throw New Security.SecurityException(msg)
        End If
        If SelectedInvoiceDataRow Is Nothing Then Exit Sub

        Dim f As New FRMGenDropBox
        f.cbo2.Items.Clear()
        f.cbo1.Visible = False
        f.cbo2.Visible = False
        f.lblTop.Visible = False
        f.lblMiddle.Visible = False

        f.lblref.Text = "Account Number"
        f.txtref.Visible = True
        f.ShowDialog()
        f.btnOK.Text = "Save"

        If f.DialogResult = DialogResult.Cancel Then
            Exit Sub
        End If

        Dim EngVisitCharge As Entity.EngineerVisitCharges.EngineerVisitCharge =
                    DB.EngineerVisitCharge.EngineerVisitCharge_Get(SelectedInvoiceDataRow("EngineerVisitID"))

        EngVisitCharge.SetForSageAccountCode = f.txtref.Text.Trim

        DB.EngineerVisitCharge.EngineerVisitCharge_Update(EngVisitCharge)

        SelectedInvoiceDataRow("AccountNumber") = f.txtref.Text.Trim

    End Sub

    Private Sub tsmiIssue_Click(sender As Object, e As EventArgs) Handles tsmiIssue.Click
        If Not loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance) Then
            Dim msg As String = "You do not have the necessary security permissions."
            Throw New Security.SecurityException(msg)
        End If

        If Not InvoicesDataview Is Nothing Then
            Dim r As DataRow() = InvoicesDataview.Table.Select("tick = 1")

            Dim customerID As Integer = 0

            For Each i As DataRow In r

                If r(0)("InvoiceType") = "Sales Credit" Then
                    ShowMessage("Credits cannot be raised on credit records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                If Helper.MakeDoubleValid(i("CreditAmount")) >= Helper.MakeDoubleValid(i("Amount")) Then
                    ShowMessage("Credit Amount cannot be greater than Invoice Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                If customerID = 0 Or (customerID = i("CustomerID")) Then
                    customerID = i("customerID")
                Else
                    ShowMessage("Grouped credits must be against one customer only", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            Next
            If r.Length > 0 Then
                Using f As New FRMSalesCredit(r, False, True)
                    f.ShowDialog()
                End Using
                PopulateDatagrid()
            End If

        End If
    End Sub

    Private Sub tsmiRemove_Click(sender As Object, e As EventArgs) Handles tsmiRemove.Click
        If Not loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance) Then
            Dim msg As String = "You do not have the necessary security permissions."
            Throw New Security.SecurityException(msg)
        End If
        Dim ref As Integer = 0

        If Not SelectedInvoiceDataRow Is Nothing Then
            For Each r As DataRow In InvoicesDataview.Table.Rows
                If CBool(r("tick")) Then
                    If r("InvoiceType") <> "Sales Credit" Then
                        ShowMessage("You Can only delete credits", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                    If ref = 0 Or ref = Helper.MakeIntegerValid(r("LinkID")) Then
                        ref = Helper.MakeIntegerValid(r("LinkID"))
                    Else
                        ShowMessage("You Can not delete more than one group of credits at once", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                    If ref <> 0 Then
                        DB.ClearParameter() ' cause we are doing this in the wrong place
                        Dim dt As DataTable = DB.ExecuteWithReturn("Select CreditReference , DateExportedToSage, InvoicedLineID from tblSalesCredit where SalesCreditID = " & ref)

                        For Each dr As DataRow In dt.Rows
                            If IsDBNull(dr("DateExportedToSage")) = False Then
                                ShowMessage("One or more Credits have already been exported, cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            End If
                        Next

                        For Each dr2 As DataRow In dt.Rows
                            DB.ExecuteScalar("Delete tblInvoicedLinesCredit where invoicedLineID = " & dr2("InvoicedLineID"))
                        Next

                        DB.ExecuteScalar("Delete tblSalesCredit Where SalesCreditID = " & ref)
                        ref = 0
                    End If
                End If
            Next

            PopulateDatagrid()
        End If
    End Sub

    Private Sub tsmiBatchPrint_Click(sender As Object, e As EventArgs) Handles tsmiBatchPrint.Click
        If InvoicesDataview IsNot Nothing Then
            Dim dr() As DataRow = (From sf In InvoicesDataview.Table.AsEnumerable() Where sf.Field(Of Boolean)("Tick") = True And sf.Field(Of String)("InvoiceType") = "Sales Credit" Select sf).ToArray()

            If dr.Count < 1 Then
                ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim dtCredit As New DataTable
            dtCredit = dr.CopyToDataTable
            Dim oPrint As New Printing(dtCredit, "Sales Credit", Enums.SystemDocumentType.SalesCredit, True)
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        PopulateDatagrid()
    End Sub

    Private Sub btnGenNCCVal_Click(sender As Object, e As EventArgs) Handles btnGenVal.Click
        cmsValType.Show(btnGenVal, New Point(0, 0))
    End Sub

    Private Sub tsmiNCCVal_Click(sender As Object, e As EventArgs) Handles tsmiNCCVal.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim invoicedIds As List(Of Integer) = (From x In InvoicesDataview.Table.AsEnumerable() Where x.Field(Of Boolean)("Tick") = True Select x.Field(Of Integer)("InvoicedID")).Distinct().ToList()
            If invoicedIds.Count = 0 Then
                ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim exportData As New DataTable
            exportData.Columns.Add("ValNo")
            exportData.Columns.Add("UPRN")
            exportData.Columns.Add("JOB")
            exportData.Columns.Add("ActualCompDate", GetType(Date))
            exportData.Columns.Add("Invoice")
            exportData.Columns.Add("Address")
            exportData.Columns.Add("Code")
            exportData.Columns.Add("SORDescription")
            exportData.Columns.Add("Plant")
            exportData.Columns.Add("Materials", GetType(Double))
            exportData.Columns.Add("SubContractor", GetType(Double))
            exportData.Columns.Add("Labour", GetType(Double))
            exportData.Columns.Add("SORCost", GetType(Double))
            exportData.Columns.Add("MarginOnMaterials", GetType(Double))
            exportData.Columns.Add("MarginOnSubCon", GetType(Double))
            exportData.Columns.Add("Total", GetType(Double))
            exportData.Columns.Add("VAT", GetType(Double))
            exportData.Columns.Add("GrandTotal", GetType(Double))
            exportData.Columns.Add("Recharge")
            exportData.Columns.Add("HPSOfficer")

            For Each invoicedId As Integer In invoicedIds
                Dim visits As DataView = DB.Invoiced.NCCValuation(invoicedId)
                For Each dr As DataRow In visits.Table.Rows
                    Dim newRw As DataRow
                    newRw = exportData.NewRow

                    newRw("ValNo") = dr("ValNum")
                    newRw("UPRN") = dr("UPRN")
                    newRw("JOB") = dr("JOB")
                    newRw("ActualCompDate") = dr("ActualCompletion")
                    newRw("Invoice") = dr("InvoiceNumber")
                    newRw("Address") = dr("Address1")
                    newRw("Code") = dr("CODE")
                    newRw("SORDescription") = dr("Description")
                    newRw("Plant") = dr("Plant")
                    newRw("Materials") = dr("Material")
                    newRw("SubContractor") = dr("SubContractor")
                    newRw("Labour") = dr("labour")
                    newRw("SORCost") = dr("SORCost")
                    newRw("MarginOnMaterials") = dr("MatMark")
                    newRw("MarginOnSubCon") = dr("SubConMark")
                    newRw("Total") = dr("Total")
                    newRw("VAT") = dr("VAT")
                    newRw("GrandTotal") = dr("GrandTotal")
                    newRw("Recharge") = dr("Recharge")
                    newRw("HPSOfficer") = dr("HpsOfficer")

                    exportData.Rows.Add(newRw)
                Next
            Next

            ExportHelper.Export(exportData, "NCC Valuation", Enums.ExportType.XLS)
        Catch ex As Exception
            ShowMessage("Error generating document!" & vbCrLf & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub tsmiSorVal_Click(sender As Object, e As EventArgs) Handles tsmiSorVal.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If InvoicesDataview IsNot Nothing Then
                Dim drInvoices() As DataRow = (From sf In InvoicesDataview.Table.AsEnumerable() Where sf.Field(Of Boolean)("Tick") = True Select sf).ToArray()
                If drInvoices.Count < 1 Then
                    ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim dtValData As New DataTable
                dtValData.Columns.Add("UPRN", GetType(String))
                dtValData.Columns.Add("Client Ref", GetType(String))
                dtValData.Columns.Add("Gasway Job Number", GetType(String))
                dtValData.Columns.Add("Completion Date", GetType(Date))
                dtValData.Columns.Add("Invoice Number", GetType(String))
                dtValData.Columns.Add("Address", GetType(String))
                dtValData.Columns.Add("Invoice Description", GetType(String))
                dtValData.Columns.Add("SOR Code", GetType(String))
                dtValData.Columns.Add("SOR Description", GetType(String))
                dtValData.Columns.Add("SOR Price", GetType(String))
                dtValData.Columns.Add("SOR Qty", GetType(Integer))
                dtValData.Columns.Add("SOR Total", GetType(String))

                Try
                    For Each drInvoice As DataRow In drInvoices
                        If drInvoice("InvoiceType") <> "Visit" Then Continue For
                        If drInvoice("AccountNumber").ToString.Contains("IBC") Then Continue For

                        Dim engineerVisitId As Integer = Helper.MakeIntegerValid(drInvoice("EngineerVisitID"))
                        Dim dvEngVisit As DataView = DB.EngineerVisits.EngineerVisits_Get_ForVal(engineerVisitId)
                        If dvEngVisit.Count < 1 Then Continue For

                        Dim dvSorBreakdown As DataView = DB.EngineerVisitCharge.EngineerVisitCharge_Get_SorBreakdownForVal(engineerVisitId)
                        For Each drSor As DataRowView In dvSorBreakdown
                            Dim newRw As DataRow
                            newRw = dtValData.NewRow
                            newRw("UPRN") = Helper.MakeStringValid(dvEngVisit(0)("UPRN"))
                            newRw("Address") = Helper.MakeStringValid(dvEngVisit(0)("Site"))
                            newRw("Gasway Job Number") = Helper.MakeStringValid(dvEngVisit(0)("JobNumber"))
                            newRw("Completion Date") = Helper.MakeDateTimeValid(dvEngVisit(0)("CompletedDateTime"))
                            newRw("Client Ref") = Helper.MakeStringValid(dvEngVisit(0)("ClientRef"))
                            newRw("Invoice Number") = Helper.MakeStringValid(drInvoice("InvoiceNumber"))
                            newRw("Invoice Description") = Helper.MakeStringValid(dvEngVisit(0)("InvoiceNotes"))
                            newRw("SOR Code") = drSor("Code")
                            newRw("SOR Description") = drSor("Description")
                            newRw("SOR Price") = Helper.MakeDoubleValid(drSor("Cost")).ToString("c")
                            newRw("SOR Qty") = Helper.MakeIntegerValid(drSor("Quantity"))
                            newRw("SOR Total") = Helper.MakeDoubleValid(drSor("Charge")).ToString("c")
                            dtValData.Rows.Add(newRw)
                        Next
                    Next

                    ExportHelper.Export(dtValData, "Valuation", Enums.ExportType.XLS)
                Catch ex As Exception
                    ShowMessage("Error generating document!" & vbCrLf & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Default
                Finally
                    Me.Cursor = Cursors.Default
                End Try
            End If
        Catch ex As Exception
            ShowMessage("Error generating document!" & vbCrLf & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub tsmiGenericVal_Click(sender As Object, e As EventArgs) Handles tsmiGenericVal.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If InvoicesDataview IsNot Nothing Then
                Dim dr() As DataRow = (From sf In InvoicesDataview.Table.AsEnumerable()
                                       Where sf.Field(Of Boolean)("Tick") = True Select sf).ToArray()
                If dr.Count < 1 Then
                    ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim exportData As New DataTable
                exportData.Columns.Add("UPRN", GetType(String))
                exportData.Columns.Add("Client Ref", GetType(String))
                exportData.Columns.Add("Gasway Job Number", GetType(String))
                exportData.Columns.Add("Completion Date", GetType(Date))
                exportData.Columns.Add("Invoice Number", GetType(String))
                exportData.Columns.Add("Address", GetType(String))
                exportData.Columns.Add("Invoice Description", GetType(String))
                exportData.Columns.Add("SOR Description", GetType(String))
                exportData.Columns.Add("SOR Cost", GetType(Decimal))
                exportData.Columns.Add("Labour Cost", GetType(Decimal))
                exportData.Columns.Add("Parts Cost", GetType(Decimal))
                exportData.Columns.Add("Additional Cost", GetType(Decimal))
                exportData.Columns.Add("Total ex VAT", GetType(Double))
                exportData.Columns.Add("VAT", GetType(Double))
                exportData.Columns.Add("Total", GetType(Double))

                Try
                    For Each r As DataRow In dr
                        'if anything other than visit then we cannot add to val
                        If r("InvoiceType") <> "Visit" Then Continue For
                        If r("AccountNumber").ToString.Contains("IBC") Then Continue For

                        Dim engVisitId As Integer = Helper.MakeIntegerValid(r("EngineerVisitID"))

                        'get visit info
                        Dim dvEngVisit As DataView = DB.EngineerVisits.EngineerVisits_Get_ForVal(engVisitId)
                        If dvEngVisit.Count < 1 Then Continue For

                        'get visitcharge info
                        Dim dvChargeBreakdown As DataView =
                            DB.EngineerVisitCharge.EngineerVisitCharge_Get_ChargedBreakDown(engVisitId)

                        'get totals for different areas
                        Dim PARTSTotal As Decimal = dvChargeBreakdown.Table.AsEnumerable().Where(Function(row) row.Field(Of String)("Type") = "PARTS").
                            Sum(Function(row) row.Field(Of Decimal)("Charge"))
                        Dim SORTotal As Decimal = dvChargeBreakdown.Table.AsEnumerable().Where(Function(row) row.Field(Of String)("Type") = "SOR").
                            Sum(Function(row) row.Field(Of Decimal)("Charge"))
                        Dim LABOURTotal As Decimal = dvChargeBreakdown.Table.AsEnumerable().Where(Function(row) row.Field(Of String)("Type") = "LABOUR").
                            Sum(Function(row) row.Field(Of Decimal)("Charge"))
                        Dim ADDITIONALTotal As Decimal = dvChargeBreakdown.Table.AsEnumerable().Where(Function(row) row.Field(Of String)("Type") = "ADDITIONAL").
                            Sum(Function(row) row.Field(Of Decimal)("Charge"))

                        'get sor descriptions
                        Dim sorDescription As String =
                             String.Join(" / ", dvChargeBreakdown.Table.AsEnumerable().Where(Function(row) row.Field(Of String)("Type") = "SOR").
                                         Select(Function(row) row.Field(Of String)("Description")).ToArray())

                        'calculate amounts
                        Dim amount As Double = Helper.MakeDoubleValid(r("Amount"))
                        Dim vatRate As Double = Helper.MakeDoubleValid(r("VATRate")) / 100
                        Dim vatAmount As Double = amount * vatRate
                        Dim total As Double = amount + Math.Round(vatAmount, 2, MidpointRounding.ToEven)

                        'insert the info
                        Dim newRw As DataRow
                        newRw = exportData.NewRow
                        newRw("UPRN") = Helper.MakeStringValid(dvEngVisit(0)("UPRN"))
                        newRw("Address") = Helper.MakeStringValid(dvEngVisit(0)("Site"))
                        newRw("Gasway Job Number") = Helper.MakeStringValid(dvEngVisit(0)("JobNumber"))
                        newRw("Completion Date") = Helper.MakeDateTimeValid(dvEngVisit(0)("CompletedDateTime"))
                        newRw("Client Ref") = Helper.MakeStringValid(dvEngVisit(0)("ClientRef"))
                        newRw("Invoice Number") = Helper.MakeStringValid(r("InvoiceNumber"))
                        newRw("Invoice Description") = Helper.MakeStringValid(dvEngVisit(0)("InvoiceNotes"))
                        newRw("SOR Description") = sorDescription
                        newRw("SOR Cost") = SORTotal
                        newRw("Labour Cost") = LABOURTotal
                        newRw("Parts Cost") = PARTSTotal
                        newRw("Additional Cost") = ADDITIONALTotal
                        newRw("Total ex VAT") = amount
                        newRw("VAT") = Math.Round(vatAmount, 2, MidpointRounding.ToEven)
                        newRw("Total") = Math.Round(total, 2, MidpointRounding.ToEven)
                        exportData.Rows.Add(newRw)
                    Next
                    ExportHelper.Export(exportData, "Valuation", Enums.ExportType.XLS)
                Catch ex As Exception
                    ShowMessage("Error generating document!" & vbCrLf & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Default
                Finally
                    Me.Cursor = Cursors.Default
                End Try
            End If
        Catch ex As Exception
            ShowMessage("Error generating document!" & vbCrLf & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub txtJobNumber_TextChanged(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtJobNumber.KeyDown, txtPostcode.KeyDown, txtInvoiceNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            PopulateDatagrid()
        End If
    End Sub

    Private Sub txtSageMonth_TextChanged(sender As Object, e As EventArgs) Handles txtSageMonth.DoubleClick
        If Not loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance) Then
            Dim msg As String = "You do not have the necessary security permissions."
            Throw New Security.SecurityException(msg)
        End If
        Dim fCIT As FRMChangeSageDate = ShowForm(GetType(FRMChangeSageDate), True, Nothing)
        If fCIT.DialogResult = DialogResult.OK Then
            txtSageMonth.Text = CDate(DB.ExecuteScalar("Select Name from tblpicklists where enumtypeid = 69")).ToString("MMMM yyyy")
        End If
    End Sub

    Private Sub tsmiOrderNo_Click(sender As Object, e As EventArgs) Handles tsmiOrderNo.Click
        'get the difference
        If MessageBox.Show("Are you sure you want to update the order numbers?", "Confirm", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
            Exit Sub
        End If
        Try
            Dim diff As DataTable = InvoicesDataview.Table.GetChanges()
            Dim visitInvoices As DataRow() = diff.Select("InvoiceTypeID = " & CInt(Enums.InvoiceType.Visit))
            For Each visitInvoice As DataRow In visitInvoices
                Dim jobOfWorkId As Integer = If(visitInvoice.Table.Columns.Contains("JobOfWorkID"), Helper.MakeIntegerValid(visitInvoice("JobOfWorkID")), 0)
                Dim ponumber As String = Helper.MakeStringValid(visitInvoice("OrderNo"))

                If jobOfWorkId > 0 Then
                    DB.JobOfWorks.Update_PONumberByJobOfWorkID(jobOfWorkId, ponumber)
                End If
            Next
            ShowMessage("Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            ShowMessage("Unable to save: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Functions"

    Private Sub view()
        If Not SelectedInvoiceDataRow Is Nothing Then
            Select Case CType(SelectedInvoiceDataRow.Item("InvoiceTypeID"), Enums.InvoiceType)
                Case Enums.InvoiceType.Contract_Option1
                    ShowForm(GetType(FRMContractOriginal), True, New Object() {Helper.MakeIntegerValid(SelectedInvoiceDataRow.Item("ContractID")), Helper.MakeIntegerValid(SelectedInvoiceDataRow.Item("CustomerID"))})
                Case Enums.InvoiceType.Order
                    Select Case CInt(SelectedInvoiceDataRow.Item("OrderTypeID"))
                        Case Enums.OrderType.Customer
                            ShowForm(GetType(FRMOrder), False, New Object() {SelectedInvoiceDataRow.Item("OrderID"), Helper.MakeIntegerValid(SelectedInvoiceDataRow.Item("OrderSiteID")), 0, Me})
                        Case Enums.OrderType.StockProfile
                            ShowForm(GetType(FRMOrder), False, New Object() {SelectedInvoiceDataRow.Item("OrderID"), SelectedInvoiceDataRow.Item("VanID"), 0, Me})
                        Case Enums.OrderType.Warehouse
                            ShowForm(GetType(FRMOrder), False, New Object() {SelectedInvoiceDataRow.Item("OrderID"), SelectedInvoiceDataRow.Item("WarehouseID"), 0, Me})
                        Case Enums.OrderType.Job
                            ShowForm(GetType(FRMOrder), False, New Object() {SelectedInvoiceDataRow.Item("OrderID"), SelectedInvoiceDataRow.Item("EngineerVisitID"), 0, Me})
                        Case Else
                            'OrderID holds the consolidated order id
                            ShowForm(GetType(FRMConsolidation), True, New Object() {SelectedInvoiceDataRow.Item("OrderID")})
                    End Select
                Case Enums.InvoiceType.Visit
                    ShowForm(GetType(FRMEngineerVisit), True, New Object() {Helper.MakeIntegerValid(SelectedInvoiceDataRow.Item("EngineerVisitID"))})
            End Select
        Else
            ShowMessage("Please select an invoice.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub PopulateDatagrid()
        Me.Cursor = Cursors.WaitCursor
        Dim customerId As Integer = If(theCustomer IsNot Nothing, theCustomer.CustomerID, 0)
        Dim siteId As Integer = If(theSite IsNot Nothing, theSite.SiteID, 0)
        Dim postcode As String = If(Me.txtPostcode.Text.Trim.Length > 0, Me.txtPostcode.Text, Nothing)
        Dim invoiceTypeId As Integer = Combo.GetSelectedItemValue(Me.cboType)
        Dim jobNumber As String = If(Me.txtJobNumber.Text.Trim.Length > 0, Me.txtJobNumber.Text, Nothing)
        Dim invoiceNumber As String = If(Me.txtInvoiceNumber.Text.Trim.Length > 0, Me.txtInvoiceNumber.Text, Nothing)
        Dim userId As Integer = Combo.GetSelectedItemValue(Me.cboUser)
        Dim regionId As Integer = Combo.GetSelectedItemValue(Me.cboRegion)
        Dim department As String = Combo.GetSelectedItemValue(Me.cboDept).Trim()
        Dim exportedToSage As Integer = -1
        If cboExported.SelectedIndex = 1 Then
            exportedToSage = 1
        ElseIf cboExported.SelectedIndex = 2 Then
            exportedToSage = 0
        End If

        InvoicesDataview = DB.Invoiced.Invoiced_GetAll_Manager(
            dtpRaisedFrom.Value, dtpRaisedTo.Value, customerId, siteId,
            postcode, invoiceTypeId, jobNumber, invoiceNumber, userId,
            regionId, department, exportedToSage)

        If chkExportedOn.Checked Then
            Dim query As String = "ExportedOn = #" & dtpExportedOn.Value.ToString("yyyy-MM-dd") & "#"
            InvoicesDataview.RowFilter = query
        End If
        grpInvoices.Text = "Double Click To View / Add Payment Information - Search Results (" & InvoicesDataview.Count & ")"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ResetFilters()
        theCustomer = Nothing

        Dim fromDate As DateTime
        Select Case Today.DayOfWeek
            Case DayOfWeek.Monday
                fromDate = Now
            Case DayOfWeek.Tuesday
                fromDate = Now.AddDays(-1)
            Case DayOfWeek.Wednesday
                fromDate = Now.AddDays(-2)
            Case DayOfWeek.Thursday
                fromDate = Now.AddDays(-3)
            Case DayOfWeek.Friday
                fromDate = Now.AddDays(-4)
            Case DayOfWeek.Saturday
                fromDate = Now.AddDays(-5)
            Case DayOfWeek.Sunday
                fromDate = Now.AddDays(-6)
        End Select

        Combo.SetUpCombo(Me.cboStatus, DynamicDataTables.InvoiceStatus, "ValueMember", "DisplayMember", Enums.ComboValues.None)
        Combo.SetSelectedComboItem_By_Value(Me.cboStatus, -3)
        Me.txtInvoiceNumber.Text = ""
        Combo.SetUpCombo(Me.cboUser, DB.User.GetAll.Table, "UserID", "Fullname", Enums.ComboValues.No_Filter)
        Combo.SetSelectedComboItem_By_Value(Me.cboUser, 0)
        Me.dtpRaisedFrom.Value = fromDate.AddDays(-21)
        Me.dtpRaisedTo.Value = fromDate.AddDays(7)

        Combo.SetUpCombo(Me.cboType, DB.Picklists.GetAll(Enums.PickListTypes.InvoiceTypes).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter)
        Combo.SetSelectedComboItem_By_Value(Me.cboType, 0)
        Combo.SetUpCombo(Me.cboRegion, DB.Picklists.GetAll(Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter)

        Select Case True
            Case IsGasway
                Combo.SetUpCombo(Me.cboDept, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative)
            Case Else
                Combo.SetUpCombo(Me.cboDept, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative)
        End Select

        Me.txtJobNumber.Text = ""
        Me.txtPostcode.Text = ""

        Dim d1 As String = DB.ExecuteScalar("Select Name from tblpicklists where enumtypeid = 69")
        If Not (IsNothing(d1)) Then
            Me.txtSageMonth.Text = CDate(d1).ToString("MMMM yyyy")
        End If
    End Sub

    Public Sub Export()

        If Not Helper.MakeIntegerValid(InvoicesDataview?.Count) > 0 Then
            ShowMessage("No filter added", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim exportData As New DataTable

        exportData.Columns.Add("PaidStatus")
        exportData.Columns.Add("Customer")
        exportData.Columns.Add("Site")
        exportData.Columns.Add("InvoiceType")
        exportData.Columns.Add("JobNumber")
        exportData.Columns.Add("InvoiceAddressType")
        exportData.Columns.Add("InvoiceAddress")
        exportData.Columns.Add("Amount", GetType(Double))
        exportData.Columns.Add("InvoiceNumber")
        exportData.Columns.Add("RaisedDate")
        exportData.Columns.Add("Fullname")
        exportData.Columns.Add("Department")
        exportData.Columns.Add("Exported")

        For Each dr As DataRowView In CType(dgInvoices.DataSource, DataView)
            Dim newRw As DataRow = exportData.NewRow
            newRw("PaidStatus") = SelectedInvoiceDataRow("PaidStatus")
            newRw("Customer") = SelectedInvoiceDataRow("Customer")
            newRw("Site") = SelectedInvoiceDataRow("Site")
            newRw("InvoiceType") = SelectedInvoiceDataRow("InvoiceType")
            newRw("JobNumber") = SelectedInvoiceDataRow("JobNumber")
            newRw("InvoiceAddressType") = SelectedInvoiceDataRow("InvoiceAddressType")
            newRw("InvoiceAddress") = SelectedInvoiceDataRow("InvoiceAddress")
            newRw("Amount") = SelectedInvoiceDataRow("Amount")
            newRw("InvoiceNumber") = SelectedInvoiceDataRow("InvoiceNumber")
            newRw("RaisedDate") = Format(SelectedInvoiceDataRow("RaisedDate"), "dd/MM/yyyy")
            newRw("Fullname") = SelectedInvoiceDataRow("Fullname")
            newRw("Department") = SelectedInvoiceDataRow("Department")
            If Helper.MakeDateTimeValid(SelectedInvoiceDataRow("DateExportedToSage")) = Nothing Then
                newRw("Exported") = ""
            Else
                newRw("Exported") = Format(SelectedInvoiceDataRow("DateExportedToSage"), "dd/MM/yyyy")
            End If
            exportData.Rows.Add(newRw)
        Next
        ExportHelper.Export(exportData, "Invoiced List", Enums.ExportType.XLS)
    End Sub

    Public Sub Print()
        If InvoicesToPrint.Count < 1 Then Exit Sub
        Dim details As New ArrayList
        details.Add(InvoicesToPrint)

        Dim oPrint As New Printing(details, "Invoice", Enums.SystemDocumentType.Invoice, True)
        InvoicesToPrint.Clear()
    End Sub

    Public Sub FindPartPayJobs(ByVal Multi As Boolean)
        Try
            'FOR EVERY TICKED RECORD
            For Each dr As DataRow In InvoicesDataview.Table.Rows
                If Helper.MakeBooleanValid(dr("tick")) = True Then
                    'VISIT RECORDS
                    If CType(dr("InvoiceTypeID"), Enums.InvoiceType) = Enums.InvoiceType.Visit Then
                        'SEE IF JOB IS PART PAY
                        If DB.Job.Job_Get(dr("JobID")).ToBePartPaid = True Then
                            'UNTICK - We'll add to print list from here

                            dr("tick") = 0
                            'IS IT INVOICED?
                            If Helper.MakeIntegerValid(dr("invoicedID")) = 0 Then 'Invoiced =NO

                                'IS THERE AN Invoice for any other visits on this job?
                                Dim dt As DataTable = DB.InvoiceToBeRaised.InvoicesToBeRaised_GetAllVisitsInvoice_ByJobID(dr("JobID")).Table
                                If dt.Rows.Count > 0 Then 'Exisiting Invoice =YES

                                    'Add to Exisiting Invoice
                                    InsertInvoiceLines(Helper.MakeDoubleValid(dr.Item("Amount")),
                                    dt.Rows(0).Item("InvoicedID"), dr.Item("InvoiceToBeRaisedID"))

                                    'Add Invoice to print list
                                    If Not InvoicesToPrint.Contains(dt.Rows(0).Item("InvoicedID")) Then
                                        InvoicesToPrint.Add(Helper.MakeIntegerValid(dt.Rows(0).Item("InvoicedID")))
                                    End If
                                Else 'Exisiting Invoice =NO
                                    'CREATE NEW INVOICE
                                    Dim inv As New Entity.Invoiceds.Invoiced
                                    Dim invNum As New JobNumber
                                    invNum = DB.Job.GetNextJobNumber(5)
                                    inv.SetInvoiceNumber = invNum.Prefix & invNum.JobNumber
                                    inv.SetRaisedByUserID = loggedInUser.UserID
                                    inv.RaisedDate = Now
                                    inv = DB.Invoiced.Insert(inv)
                                    'ADD ALL THE VISITS READY FOR INVOICE
                                    Dim dtVisits As DataTable = DB.InvoiceToBeRaised.InvoicesToBeRaised_GetAllVisitsNotInvoice_ByJobID(dr("JobID")).Table
                                    For Each v As DataRow In dtVisits.Rows
                                        InsertInvoiceLines(Helper.MakeDoubleValid(v.Item("Amount")),
                                        inv.InvoicedID, v.Item("InvoiceToBeRaisedID"))
                                    Next v

                                    'IF its multi line invoice add on anyother things
                                    If Multi Then
                                        MultiInvoicePPJob(dr, inv, dtVisits)
                                    End If

                                    'Add Invoice to print list
                                    If Not InvoicesToPrint.Contains(inv.InvoicedID) Then
                                        InvoicesToPrint.Add(Helper.MakeIntegerValid(inv.InvoicedID))
                                    End If
                                End If
                            Else 'Invoiced = YES
                                'ARE THERE ANY OTHER VISITS THAT SHOUlD BE ONE THIS INVOICE THAT AREN'T?
                                'ADD THEM
                                For Each v As DataRow In DB.InvoiceToBeRaised.InvoicesToBeRaised_GetAllVisitsNotInvoice_ByJobID(dr("JobID"))
                                    If dr("InvoiceToBeRaisedID") <> v("InvoiceToBeRaisedID") Then
                                        InsertInvoiceLines(Helper.MakeDoubleValid(v.Item("Amount")),
                                        dr("invoicedID"), v.Item("InvoiceToBeRaisedID"))
                                    End If
                                Next

                                'Add Invoice to print list
                                If Not InvoicesToPrint.Contains(dr("InvoicedID")) Then
                                    InvoicesToPrint.Add(Helper.MakeIntegerValid(dr("InvoicedID")))
                                End If
                            End If

                        End If
                    End If
                End If

            Next
        Catch ex As Exception
            MessageBox.Show("An Error has occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub MultiInvoicePPJob(ByVal dr As DataRow, ByVal inv As Entity.Invoiceds.Invoiced, ByVal dtVisits As DataTable)
        Try
            'GET ALL ITEMS THAT YOU WANNA PUT ON THE INVOICE
            Dim drInv() As DataRow = InvoicesDataview.Table.Select("AddressTypeID=" & dr("AddressTypeID") & " AND AddressID=" & dr("AddressID"))
            For i As Integer = 0 To drInv.Length - 1

                'IS IT INVOICED ALREADY?
                If Helper.MakeIntegerValid(drInv(i).Item("invoicedID")) = 0 Then 'NO

                    'IS IT A VISIT OR AN ORDER?
                    If CType(drInv(i).Item("InvoiceTypeID"), Enums.InvoiceType) = Enums.InvoiceType.Order Then
                        'ORDER
                        'UNTICK
                        drInv(i).Item("tick") = 0
                        InsertInvoiceLines(Helper.MakeDoubleValid(drInv(i).Item("Amount")),
                           inv.InvoicedID, drInv(i).Item("InvoiceToBeRaisedID"))
                    Else 'VISIT

                        'IS THE VISIT ALREADY INSERTED ABOVE?
                        If dtVisits.Select("InvoiceToBeRaisedID=" & drInv(i).Item("InvoiceToBeRaisedID")).Length > 0 Then
                            'YES UNTICK
                            drInv(i).Item("tick") = 0
                        Else
                            'NO - IS IT PP JOB ?
                            If DB.Job.Job_Get(drInv(i).Item("JobID")).ToBePartPaid = True Then 'YES
                                'IS THERE ANY EXISTING INVOICES FOR THE JOB'S VISIT
                                Dim jobAlreadyInvoiced As Boolean = False

                                Dim alreadyInv As DataTable = DB.InvoiceToBeRaised.InvoicesToBeRaised_GetAllVisitsInvoice_ByJobID(drInv(i).Item("JobID")).Table
                                If alreadyInv.Rows.Count > 0 Then
                                    'AND ITS A DIFFERENT INVOICE TO THIS ONE
                                    For Each aInv As DataRow In alreadyInv.Rows
                                        If Helper.MakeIntegerValid(drInv(i).Item("InvoicedID")) = Helper.MakeIntegerValid(aInv("InvoicedID")) Then
                                            jobAlreadyInvoiced = True ' Just leave the this alone it will picked up later
                                        End If
                                    Next aInv
                                    If jobAlreadyInvoiced Then
                                        ' Just leave the this alone it will picked up later
                                    Else
                                        'UNTICK AND INSERT
                                        drInv(i).Item("tick") = 0
                                        InsertInvoiceLines(Helper.MakeDoubleValid(drInv(i).Item("Amount")),
                                                    inv.InvoicedID, drInv(i).Item("InvoiceToBeRaisedID"))
                                    End If
                                Else 'NO INVOICE
                                    'UNTICK AND INSERT
                                    drInv(i).Item("tick") = 0
                                    InsertInvoiceLines(Helper.MakeDoubleValid(drInv(i).Item("Amount")),
                                                inv.InvoicedID, drInv(i).Item("InvoiceToBeRaisedID"))
                                End If
                            Else 'NO
                                'UNTICK AND INSERT
                                drInv(i).Item("tick") = 0
                                InsertInvoiceLines(Helper.MakeDoubleValid(drInv(i).Item("Amount")),
                                                     inv.InvoicedID, drInv(i).Item("InvoiceToBeRaisedID"))
                            End If
                        End If
                    End If
                Else ' ALREADY INVOICED SO JUST UNTICK
                    drInv(i).Item("tick") = 0
                End If
            Next i
        Catch ex As Exception
            MessageBox.Show("An Error has occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub InsertInvoiceLines(ByVal amount As Double, ByVal invoicedID As Integer, ByVal InvoiceToBeRaisedID As Integer)
        Dim invLines As New Entity.InvoicedLiness.InvoicedLines
        invLines.SetAmount = amount
        invLines.SetInvoicedID = invoicedID
        invLines.SetInvoiceToBeRaisedID = InvoiceToBeRaisedID
        invLines = DB.InvoicedLines.Insert(invLines)
    End Sub

    Private Function Check_Supplier_Invoices_And_Continue() As Boolean
        Dim invoicesRemoved As Boolean = False

        For Each row As DataRow In InvoicesDataview.Table.Rows
            If row.Item("InvoiceType") = "Supplier" Or row.Item("InvoiceType") = "Consolidation" Then
                If row.Item("Tick") Then
                    row.Item("Tick") = False
                    invoicesRemoved = True
                End If
            End If
        Next

        If invoicesRemoved Then
            If ShowMessage("Supplier invoices have been removed - would you like to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return False
            End If
        End If

        Return True
    End Function

#End Region

#Region "Export Invoice to Sage"

    Private Async Sub btnMarkAsNotExported_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarkAsNotExported.Click

        If MessageBox.Show("Are you sure you want to mark the selected invoices as not exported?", "Confirm", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
            Exit Sub
        End If

        Try
            Me.Cursor = Cursors.WaitCursor

            If Not InvoicesDataview Is Nothing Then
                Dim nw As DataRow = Nothing
                For Each r As DataRowView In InvoicesDataview
                    If CBool(r("tick")) Then
                        If r("InvoiceType") = "Supplier" Then
                            Await DB.Invoiced.MarkOrderAsNotExportedAsync(CInt(r("SupplierInvoiceID")))
                        ElseIf r("InvoiceType") = "Part Credit" Then
                            Await DB.Invoiced.MarkPartCreditedAsNotExportedAsync(r("OrderID"), r("LinkID"))
                        ElseIf r("InvoiceType") = "Consolidation" Then
                            Await DB.Invoiced.MarkConsolidatedOrderAsNotExportedAsync(CInt(r("OrderID")))
                        ElseIf r("InvoiceType") = "Sales Credit" Then
                            Await DB.Invoiced.MarkSalesCreditAsNotExportedAsync(CInt(r("LinkID")))
                        Else
                            Await DB.Invoiced.MarkInvoiceAsNotExportedAsync(CInt(r("InvoicedID")))
                        End If
                    End If
                Next
            End If

            PopulateDatagrid()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show("An Error has occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub cboExportedToSage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboExported.SelectedIndexChanged
        Try
            PopulateDatagrid()
        Catch ex As Exception
            MessageBox.Show("An Error has occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnExportToAccounts_Click(sender As Object, e As EventArgs) Handles btnExportToAccounts.Click
        cmsExportForAccounts.Show(btnExportToAccounts, New Point(0, 0))
    End Sub

    Private Async Sub tsmiSunExport_Click(sender As Object, e As EventArgs) Handles tsmiSunExport.Click
        If Not loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance) Then
            Dim msg As String = "You do not have the necessary security permissions."
            Throw New Security.SecurityException(msg)
        End If

        Try
            Me.Cursor = Cursors.WaitCursor
            If Not InvoicesDataview Is Nothing Then
                Dim dr() As DataRow = (From sf In InvoicesDataview.Table.AsEnumerable()
                                       Where sf.Field(Of Boolean)("Tick") = True Select sf).ToArray()
                If dr.Count < 1 Then
                    ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim accountingPeriodDate As DateTime = New DateTime(CDate(txtSageMonth.Text).Year, CDate(txtSageMonth.Text).Month, 1)
                Dim dtSunMaps As DataTable = DB.SunFinance.GetAllMaps()
                Dim payload As New Entity.Accounts.Payload
                For Each r As DataRow In dr
                    Dim custType As String = String.Empty
                    Select Case r("InvoiceType").ToString
                        Case "Supplier", "Part Credit", "Consolidation"
                            custType = "Supplier"
                        Case Else
                            custType = "Customer"
                    End Select
                    Dim purchases As Boolean = If(custType = "Supplier", True, False)

                    If Helper.MakeBooleanValid(r("ExportedToSage")) = False Then
                        If CDbl(r("Amount")) > 0.0 Then
                            If (CDate(Format(r("Raiseddate"), "dd/MM/yyyy")) < accountingPeriodDate And Not purchases) Then
                                ShowMessage("A invoice has been stopped in the export as it is for a different month to the current processing month.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Else
                                Dim nominalCode As String = dtSunMaps.AsEnumerable().[Select](
                                    Function(x) New With {
                                            Key .Type = x.Field(Of String)("Type"),
                                            Key .OldVal = x.Field(Of String)("OldVal"),
                                            Key .NewVal = x.Field(Of String)("NewVal"),
                                            Key .Deleted = x.Field(Of Boolean)("Deleted")
                                        }).Where(Function(s) s.Type = "Nominal" AndAlso s.OldVal = r("NominalCode") AndAlso s.Deleted = False
                                    ).[Select](Function(h) h.NewVal).FirstOrDefault()
                                If String.IsNullOrEmpty(nominalCode) Then nominalCode = r("NominalCode")

                                Dim account As String = dtSunMaps.AsEnumerable().[Select](
                                        Function(x) New With {
                                            Key .Type = x.Field(Of String)("Type"),
                                            Key .OldVal = x.Field(Of String)("OldVal"),
                                            Key .NewVal = x.Field(Of String)("NewVal"),
                                            Key .Deleted = x.Field(Of Boolean)("Deleted")
                                        }).Where(Function(s) s.Type = custType AndAlso s.OldVal = r("AccountNumber") AndAlso s.Deleted = False
                                    ).[Select](Function(h) h.NewVal).FirstOrDefault()
                                If String.IsNullOrEmpty(account) Then account = r("AccountNumber")

                                Dim regionCode As String = dtSunMaps.AsEnumerable().[Select](
                                    Function(x) New With {
                                            Key .Type = x.Field(Of String)("Type"),
                                            Key .OldVal = x.Field(Of String)("OldVal"),
                                            Key .NewVal = x.Field(Of String)("NewVal"),
                                            Key .Deleted = x.Field(Of Boolean)("Deleted")
                                        }).Where(Function(s) s.Type = "Region" AndAlso s.OldVal = r("Region") AndAlso s.Deleted = False
                                    ).[Select](Function(h) h.NewVal).FirstOrDefault()

                                Dim netLine As New Entity.Accounts.Line
                                Dim vatLine As Entity.Accounts.Line = Nothing
                                Dim grossLine As Entity.Accounts.Line = Nothing

                                netLine.AccountCode = nominalCode
                                netLine.AccountingPeriod = Entity.Accounts.AccountsHelper.GetAccountPeriod(accountingPeriodDate)

                                If Not String.IsNullOrEmpty(regionCode) Then netLine.AnalysisCode1 = regionCode

                                netLine.AnalysisCode2 = Entity.Accounts.AccountsHelper.FormatSunDepartment(r("Department"))
                                netLine.TransactionDate = Format(CDate(r("RaisedDate")), "ddMMyyyy")
                                netLine.TransactionReference = r("InvoiceNumber")
                                netLine.EntryDate = Now.ToString("ddMMyyyy")

                                If Helper.MakeIntegerValid(r(("JobID"))) > 0 Then
                                    Dim jobType As String = Helper.MakeStringValid(r("JobType"))
                                    Dim jobTypeMap As String = dtSunMaps.AsEnumerable().[Select](
                                        Function(x) New With {
                                            Key .Type = x.Field(Of String)("Type"),
                                            Key .OldVal = x.Field(Of String)("OldVal"),
                                            Key .NewVal = x.Field(Of String)("NewVal"),
                                            Key .Deleted = x.Field(Of Boolean)("Deleted")
                                        }).Where(Function(s) s.Type = "JobType" AndAlso s.OldVal = jobType AndAlso s.Deleted = False
                                    ).[Select](Function(h) h.NewVal).FirstOrDefault()

                                    If String.IsNullOrEmpty(jobTypeMap) Then jobTypeMap = "GENERI"
                                    netLine.AnalysisCode4 = jobTypeMap
                                Else
                                    netLine.AnalysisCode4 = "GENERI"
                                End If

                                If netLine.AnalysisCode2 = "004" Then
                                    netLine.AnalysisCode6 = "COM"
                                Else
                                    If Helper.MakeIntegerValid(r("CustomerTypeID")) = CInt(Enums.CustomerType.SocialHousing) Then
                                        netLine.AnalysisCode6 = "GSH"
                                    Else
                                        netLine.AnalysisCode6 = "GAS"
                                    End If
                                End If

                                netLine.AnalysisCode7 = account
                                Dim customer As String = Helper.MakeStringValid(r("Customer")).Replace(" ", "")
                                netLine.AnalysisCode8 = customer.Substring(0, Math.Min(customer.Length, 15))
                                netLine.AnalysisCode9 = r("JobNumber")

                                Dim vatCode As String = Nothing
                                Select Case r("Tax_Code").ToString()
                                    Case "T0"
                                        vatCode = "ZR"
                                    Case "T1"
                                        vatCode = "SR"
                                    Case "T2"
                                        vatCode = "ER"
                                    Case "T5"
                                        vatCode = "LR"
                                    Case "T9"
                                        vatCode = "OS"
                                End Select
                                Select Case r("InvoiceType").ToString()
                                    Case "Supplier", "Part Credit", "Consolidation"
                                        vatCode = "I" & vatCode
                                    Case Else
                                        vatCode = "O" & vatCode
                                End Select

                                Dim purchaseVatCode As String = "B5850"
                                If IsRFT Then
                                    netLine.AnalysisCode3 = "NTS"
                                    netLine.AnalysisCode4 = "ADH001"
                                    netLine.AnalysisCode6 = "XXX"
                                    purchaseVatCode = "M9999"
                                End If

                                If r("InvoiceType") = "Supplier" Then
                                    netLine.AnalysisCode5 = vatCode
                                    If IsRFT Then
                                        netLine.Description = r("InvoiceAddress") & " " & r("JobNumber")
                                    Else
                                        netLine.Description = r("JobNumber")
                                    End If

                                    If r.Table.Columns.Contains("SubTaxRate") AndAlso Not IsDBNull(r("SubTaxRate")) Then
                                        Dim cisVatLine As Entity.Accounts.Line = Nothing
                                        Dim cisLine As Entity.Accounts.Line = Nothing
                                        netLine.JournalType = "PICIS"

                                        vatLine = netLine.Clone
                                        grossLine = netLine.Clone

                                        vatLine.AccountCode = purchaseVatCode
                                        grossLine.AccountCode = account

                                        cisVatLine = netLine.Clone
                                        cisLine = netLine.Clone

                                        cisVatLine.AccountCode = "B5710"
                                        cisLine.AccountCode = account

                                        If nominalCode = "23100" Then
                                            Dim cisVatAmount As Double = Helper.MakeDoubleValid(r("Amount")) * Helper.MakeDoubleValid(r("SubTaxRate"))
                                            cisVatLine.TransactionAmount = -cisVatAmount
                                            cisLine.TransactionAmount = cisVatAmount
                                        Else
                                            cisVatLine.TransactionAmount = -0
                                            cisLine.TransactionAmount = 0
                                        End If

                                        cisVatLine.DebitCredit = "C"
                                        cisLine.DebitCredit = "D"

                                        netLine.DebitCredit = "D"
                                        vatLine.DebitCredit = "D"
                                        grossLine.DebitCredit = "C"

                                        If IsRFT Then
                                            netLine.TransactionAmount = r("Amount") + r("VATAmount")
                                        Else
                                            netLine.TransactionAmount = r("Amount")
                                        End If
                                        vatLine.TransactionAmount = r("VATAmount")
                                        grossLine.TransactionAmount = -r("Amount") + -r("VATAmount")

                                        payload.Ledger.Add(netLine)
                                        payload.Ledger.Add(vatLine)
                                        payload.Ledger.Add(grossLine)
                                        If cisVatLine IsNot Nothing Then payload.Ledger.Add(cisVatLine)
                                        If cisVatLine IsNot Nothing Then payload.Ledger.Add(cisLine)
                                    Else
                                        netLine.JournalType = "PIGAB"

                                        vatLine = netLine.Clone
                                        grossLine = netLine.Clone

                                        vatLine.AccountCode = purchaseVatCode
                                        grossLine.AccountCode = account

                                        netLine.DebitCredit = "D"
                                        vatLine.DebitCredit = "D"
                                        grossLine.DebitCredit = "C"

                                        If IsRFT Then
                                            netLine.TransactionAmount = r("Amount") + r("VATAmount")
                                        Else
                                            netLine.TransactionAmount = r("Amount")
                                        End If
                                        vatLine.TransactionAmount = r("VATAmount")
                                        grossLine.TransactionAmount = -r("Amount") + -r("VATAmount")

                                        payload.Ledger.Add(netLine)
                                        payload.Ledger.Add(vatLine)
                                        payload.Ledger.Add(grossLine)
                                    End If

                                    Await DB.Invoiced.MarkOrderAsExportedAsync(CInt(r("SupplierInvoiceID")))
                                ElseIf r("InvoiceType") = "Part Credit" Then
                                    netLine.AnalysisCode5 = vatCode
                                    If IsRFT Then
                                        netLine.Description = r("InvoiceAddress") & " " & r("JobNumber")
                                    Else
                                        netLine.Description = r("JobNumber")
                                    End If
                                    If r.Table.Columns.Contains("SubTaxRate") AndAlso Not IsDBNull(r("SubTaxRate")) Then
                                        Dim cisVatLine As Entity.Accounts.Line = Nothing
                                        Dim cisLine As Entity.Accounts.Line = Nothing
                                        netLine.JournalType = "PCCIS"

                                        vatLine = netLine.Clone
                                        grossLine = netLine.Clone

                                        vatLine.AccountCode = purchaseVatCode
                                        grossLine.AccountCode = account

                                        cisVatLine = netLine.Clone
                                        cisLine = netLine.Clone
                                        cisVatLine.AccountCode = "B5710"
                                        cisLine.AccountCode = account

                                        If nominalCode = "23100" Then
                                            Dim cisVatAmount As Double = Helper.MakeDoubleValid(r("Amount")) * Helper.MakeDoubleValid(r("SubTaxRate"))
                                            cisVatLine.TransactionAmount = cisVatAmount
                                            cisLine.TransactionAmount = -cisVatAmount
                                        Else
                                            cisVatLine.TransactionAmount = 0
                                            cisLine.TransactionAmount = -0
                                        End If

                                        cisLine.DebitCredit = "D"
                                        cisVatLine.DebitCredit = "C"

                                        netLine.DebitCredit = "C"
                                        vatLine.DebitCredit = "C"
                                        grossLine.DebitCredit = "D"

                                        If IsRFT Then
                                            netLine.TransactionAmount = -r("Amount") + -r("VATAmount")
                                        Else
                                            netLine.TransactionAmount = -r("Amount")
                                        End If
                                        vatLine.TransactionAmount = -r("VATAmount")
                                        grossLine.TransactionAmount = r("Amount") + r("VATAmount")

                                        payload.Ledger.Add(netLine)
                                        payload.Ledger.Add(vatLine)
                                        payload.Ledger.Add(grossLine)
                                        If cisVatLine IsNot Nothing Then payload.Ledger.Add(cisVatLine)
                                        If cisVatLine IsNot Nothing Then payload.Ledger.Add(cisLine)
                                    Else
                                        netLine.JournalType = "PCGAB"

                                        vatLine = netLine.Clone
                                        grossLine = netLine.Clone

                                        vatLine.AccountCode = purchaseVatCode
                                        grossLine.AccountCode = account

                                        netLine.DebitCredit = "C"
                                        vatLine.DebitCredit = "C"
                                        grossLine.DebitCredit = "D"

                                        If IsRFT Then
                                            netLine.TransactionAmount = -r("Amount") + -r("VATAmount")
                                        Else
                                            netLine.TransactionAmount = -r("Amount")
                                        End If
                                        vatLine.TransactionAmount = -r("VATAmount")
                                        grossLine.TransactionAmount = r("Amount") + r("VATAmount")

                                        payload.Ledger.Add(netLine)
                                        payload.Ledger.Add(vatLine)
                                        payload.Ledger.Add(grossLine)
                                    End If

                                    Await DB.Invoiced.MarkPartCreditedAsExportedAsync(r("OrderID"), r("LinkID"))
                                ElseIf r("InvoiceType") = "Consolidation" Then
                                    netLine.AnalysisCode5 = vatCode
                                    If IsRFT Then
                                        netLine.Description = r("InvoiceAddress") & " " & r("JobNumber")
                                    Else
                                        netLine.Description = r("JobNumber")
                                    End If
                                    netLine.JournalType = "PIGAB"

                                    vatLine = netLine.Clone
                                    grossLine = netLine.Clone

                                    vatLine.AccountCode = purchaseVatCode
                                    grossLine.AccountCode = account

                                    netLine.DebitCredit = "D"
                                    vatLine.DebitCredit = "D"
                                    grossLine.DebitCredit = "C"

                                    If IsRFT Then
                                        netLine.TransactionAmount = r("Amount") + r("VATAmount")
                                    Else
                                        netLine.TransactionAmount = r("Amount")
                                    End If
                                    vatLine.TransactionAmount = r("VATAmount")
                                    grossLine.TransactionAmount = -r("Amount") + -r("VATAmount")

                                    payload.Ledger.Add(netLine)
                                    payload.Ledger.Add(vatLine)
                                    payload.Ledger.Add(grossLine)

                                    'OrderID holds the consolidated order id
                                    Await DB.Invoiced.MarkConsolidatedOrderAsExportedAsync(CInt(r("OrderID")))
                                ElseIf r("InvoiceType") = "Sales Credit" Then
                                    netLine.AnalysisCode5 = vatCode

                                    netLine.AnalysisCode9 = r("JobNumber")
                                    netLine.Description = "Credit Against Invoice : " & r("InvoiceNumber")
                                    netLine.TransactionReference = r("JobNumber")
                                    netLine.JournalType = "SCGAB"

                                    vatLine = netLine.Clone
                                    grossLine = netLine.Clone

                                    vatLine.AccountCode = "B5800"
                                    grossLine.AccountCode = account

                                    netLine.DebitCredit = "D"
                                    vatLine.DebitCredit = "D"
                                    grossLine.DebitCredit = "C"

                                    Dim VATRate As Decimal = r.Item("VATRATE")
                                    Dim VATRateDecimal As Decimal = VATRate / 100
                                    If Helper.MakeBooleanValid(r("IsOutOfScope")) Then VATRateDecimal = 0

                                    netLine.TransactionAmount = r("Amount")
                                    vatLine.TransactionAmount = CDec(r("Amount")) * VATRateDecimal
                                    grossLine.TransactionAmount = -r("Amount") + -(CDec(r("Amount")) * VATRateDecimal)

                                    payload.Ledger.Add(netLine)
                                    payload.Ledger.Add(vatLine)
                                    payload.Ledger.Add(grossLine)

                                    'LinkID holds the SalescreditID
                                    Await DB.Invoiced.MarkSalesCreditAsExportedAsync(CInt(r("LinkID")))
                                Else
                                    netLine.AnalysisCode5 = vatCode

                                    Dim description As String = ""
                                    description += Helper.MakeStringValid(r("Address1")).Trim.Replace(",", "")
                                    description += " "
                                    description += Helper.MakeStringValid(r("Address2")).Trim.Replace(",", "")
                                    description += "- " & Helper.MakeStringValid(r("PolicyNumber")).Trim.Replace(",", "")
                                    If description.Trim.Length = 0 Then
                                        description = "FSM INVOICE"
                                    End If
                                    netLine.Description = description

                                    netLine.JournalType = "SIGAB"

                                    vatLine = netLine.Clone
                                    grossLine = netLine.Clone

                                    vatLine.AccountCode = "B5800"
                                    grossLine.AccountCode = account

                                    netLine.DebitCredit = "C"
                                    vatLine.DebitCredit = "C"
                                    grossLine.DebitCredit = "D"

                                    Dim VATRate As Decimal = r.Item("VATRATE")
                                    Dim VATRateDecimal As Decimal = VATRate / 100
                                    If Helper.MakeBooleanValid(r("IsOutOfScope")) Then VATRateDecimal = 0

                                    netLine.TransactionAmount = -r("Amount")
                                    vatLine.TransactionAmount = -(CDec(r("Amount")) * VATRateDecimal)
                                    grossLine.TransactionAmount = r("Amount") + (CDec(r("Amount")) * VATRateDecimal)

                                    payload.Ledger.Add(netLine)
                                    payload.Ledger.Add(vatLine)
                                    payload.Ledger.Add(grossLine)

                                    Await DB.Invoiced.MarkInvoiceAsExportedAsync(CInt(r("InvoicedID")))
                                End If
                            End If
                        Else
                            Await DB.Invoiced.MarkInvoiceAsExportedAsync(CInt(r("InvoicedID")))
                        End If
                    End If
                Next

                Dim SSC As New Entity.Accounts.SSC
                SSC.Payload = payload
                If SSC.SaveToXml() Then
                    MessageBox.Show("Export Completed!", "Completion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                PopulateDatagrid()
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            MessageBox.Show("An Error has occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Async Sub tsmiSageExport_Click(sender As Object, e As EventArgs) Handles tsmiSageExport.Click
        If Not loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance) Then
            Dim msg As String = "You do not have the necessary security permissions."
            Throw New Security.SecurityException(msg)
        End If

        Try
            Me.Cursor = Cursors.WaitCursor
            Dim t As DataTable = New DataTable
            t.Columns.Add("Type") ' always "SI" for fsm invoices
            t.Columns.Add("AccountNumber")
            t.Columns.Add("NominalCode") ' depends on [JobDefinition]
            t.Columns.Add("DepartmentCode")
            t.Columns.Add("RaisedDate")
            t.Columns.Add("InvoiceNumber")
            t.Columns.Add("Description") ' always Address1<space>Address2 unless both blank then always "FSM Invoice"
            t.Columns.Add("Amount") '(amount before vat)
            t.Columns.Add("VATCode") ' always "T1" for fsm invoices
            t.Columns.Add("VATAmount")
            t.Columns.Add("ExchangeRate")
            t.Columns.Add("ExtraRef")

            Dim accountingPeriodDate As DateTime = New DateTime(CDate(txtSageMonth.Text).Year, CDate(txtSageMonth.Text).Month, 1)

            If Not InvoicesDataview Is Nothing Then
                Dim nw As DataRow
                For Each r As DataRow In InvoicesDataview.Table.Rows
                    If CBool(r("ExportedToSage")) = False Then ' don't export if already marked as done or nill value

                        If CDbl(r("Amount")) > 0.0 Then

                            If CBool(r("tick")) Then
                                Dim custType As String = String.Empty
                                Select Case r("InvoiceType").ToString
                                    Case "Supplier", "Part Credit", "Consolidation"
                                        custType = "Supplier"
                                    Case Else
                                        custType = "Customer"
                                End Select
                                Dim purchases As Boolean = If(custType = "Supplier", True, False)

                                If (CDate(Format(r("Raiseddate"), "dd/MM/yyyy")) < accountingPeriodDate And Not purchases) Then

                                    ShowMessage("A invoice has been stopped in the export as it is for a diffent month to the current processing month.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Else
                                    nw = t.NewRow()
                                    nw("AccountNumber") = r("AccountNumber")
                                    nw("NominalCode") = r("NominalCode")
                                    nw("DepartmentCode") = r("Department")
                                    nw("RaisedDate") = Format(CDate(r("RaisedDate")), "dd/MM/yyyy")

                                    nw("InvoiceNumber") = r("InvoiceNumber")
                                    nw("Amount") = r("Amount")
                                    nw("ExchangeRate") = 1

                                    If r("InvoiceType") = "Supplier" Then

                                        nw("VatAmount") = Format(CDec(r("VATAmount")), "f")
                                        nw("Type") = "PI"
                                        nw("Description") = r("JobNumber")
                                        nw("VATCode") = r("Tax_Code")
                                        nw("ExtraRef") = r("ExtraRef")

                                        Await DB.Invoiced.MarkOrderAsExportedAsync(CInt(r("SupplierInvoiceID")))
                                    ElseIf r("InvoiceType") = "Part Credit" Then
                                        nw("VatAmount") = Format(CDec(r("VATAmount")), "f")
                                        nw("Type") = "PC"
                                        nw("Description") = r("JobNumber")
                                        nw("VATCode") = r("Tax_Code")
                                        nw("ExtraRef") = r("ExtraRef")
                                        nw("InvoiceNumber") = r("SupplierCreditRef")

                                        Await DB.Invoiced.MarkPartCreditedAsExportedAsync(r("OrderID"), r("LinkID"))
                                    ElseIf r("InvoiceType") = "Consolidation" Then
                                        nw("VatAmount") = Format(CDec(r("VATAmount")), "f")
                                        nw("Type") = "PI"
                                        nw("Description") = r("JobNumber")
                                        nw("VATCode") = r("Tax_Code")
                                        nw("ExtraRef") = r("ExtraRef")

                                        'OrderID holds the consolidated order id
                                        Await DB.Invoiced.MarkConsolidatedOrderAsExportedAsync(CInt(r("OrderID")))

                                    ElseIf r("InvoiceType") = "Sales Credit" Then

                                        Dim VATRate As Decimal = r.Item("VATRATE")
                                        Dim VATRateDecimal As Decimal = VATRate / 100
                                        nw("VatAmount") = Format(CDec(r("Amount")) * VATRateDecimal, "f")

                                        '  nw("VatAmount") = Format(CDec(r("VATAmount")), "f")
                                        nw("Type") = "SC"
                                        nw("Description") = "Credit Against Invoice : " & r("JobNumber")
                                        nw("VATCode") = r("Tax_Code")
                                        nw("ExtraRef") = r("ExtraRef")
                                        nw("InvoiceNumber") = r("SupplierCreditRef")
                                        'LinkID holds the SalescreditID
                                        Await DB.Invoiced.MarkSalesCreditAsExportedAsync(CInt(r("LinkID")))
                                    Else
                                        Dim VATRate As Decimal = r.Item("VATRATE")
                                        Dim VATRateDecimal As Decimal = VATRate / 100
                                        nw("VatAmount") = Format(CDec(r("Amount")) * VATRateDecimal, "f")

                                        Dim description As String = ""
                                        description += Helper.MakeStringValid(r("Address1")).Trim.Replace(",", "")
                                        description += " "
                                        description += Helper.MakeStringValid(r("Address2")).Trim.Replace(",", "")
                                        description += "- " & Helper.MakeStringValid(r("PolicyNumber")).Trim.Replace(",", "")

                                        If description.Trim.Length = 0 Then
                                            description = "FSM INVOICE"
                                        End If

                                        nw("Type") = "SI"
                                        nw("Description") = description
                                        nw("VATCode") = r("Tax_Code") 'T1
                                        nw("ExtraRef") = r("JobNumber")

                                        Await DB.Invoiced.MarkInvoiceAsExportedAsync(CInt(r("InvoicedID")))
                                    End If

                                    t.Rows.Add(nw)
                                End If

                            End If
                        Else
                            Await DB.Invoiced.MarkInvoiceAsExportedAsync(CInt(r("InvoicedID")))
                        End If

                    End If
                Next

                If t.Rows.Count > 0 Then
                    Dim csv As CSVExporter = New CSVExporter
                    csv.CreateCSV(New DataView(t))
                    MessageBox.Show("Export complete", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    MessageBox.Show("Please select invoices to export.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If

            PopulateDatagrid()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show("An Error has occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub chkExportedOn_Click(sender As Object, e As EventArgs) Handles chkExportedOn.Click
        chkExportedOn.Checked = Not chkExportedOn.Checked
        dtpExportedOn.Enabled = chkExportedOn.Checked
    End Sub

#End Region

End Class