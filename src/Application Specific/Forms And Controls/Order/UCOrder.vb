Imports System.Collections.Generic
Imports System.Linq
Imports FSM.Business.Orders
Imports FSM.Entity.CostCentres
Imports FSM.Entity.Jobs
Imports FSM.Entity.Sites
Imports FSM.Entity.Sys

Public Class UCOrder : Inherits UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Combo.SetUpCombo(Me.cboOrderTypeID, DynamicDataTables.OrderType, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboPartLocation, DynamicDataTables.LocationType, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboProductLocation, DynamicDataTables.LocationType, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboOrderStatus, DB.Order.OrderStatus_Get_All().Table, "OrderStatusID", "Name")
        Combo.SetUpCombo(Me.cboInvoiceTaxCodeNew, DB.Picklists.GetAll(Enums.PickListTypes.VATCodes).Table, "ManagerID", "Name", Enums.ComboValues.Dashes)
        Combo.SetUpCombo(Me.cboCreditTax, DB.Picklists.GetAll(Enums.PickListTypes.VATCodes).Table, "ManagerID", "Name", Enums.ComboValues.Dashes)
        Select Case True
            Case IsGasway
                Combo.SetUpCombo(Me.cboDept, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative)
            Case Else
                Combo.SetUpCombo(Me.cboDept, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative)
        End Select
        chkDoNotConsolidate.Checked = True
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
    Friend WithEvents grpOrder As GroupBox

    Friend WithEvents dtpDatePlaced As DateTimePicker
    Friend WithEvents lblDatePlaced As Label
    Friend WithEvents cboOrderTypeID As ComboBox
    Friend WithEvents lblOrderTypeID As Label
    Friend WithEvents txtOrderReference As TextBox
    Friend WithEvents lblOrderReference As Label
    Friend WithEvents tabDetails As TabPage
    Friend WithEvents tabProducts As TabPage
    Friend WithEvents tabParts As TabPage
    Friend WithEvents pnlDetails As Panel
    Friend WithEvents txtProductSearch As TextBox
    Friend WithEvents btnProductSearch As Button
    Friend WithEvents dgProduct As DataGrid
    Friend WithEvents txtPartSearch As TextBox
    Friend WithEvents btnAddProduct As Button
    Friend WithEvents btnAddPart As Button
    Friend WithEvents grpPartSearch As GroupBox
    Friend WithEvents grpAvailableParts As GroupBox
    Friend WithEvents txtPartQuantity As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents grpProductSearch As GroupBox
    Friend WithEvents grpProductsAvailable As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtProductQuantity As TextBox
    Friend WithEvents cboPartLocation As ComboBox
    Friend WithEvents cboProductLocation As ComboBox
    Friend WithEvents btnPartSearch As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPartBuyPrice As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtProductSellPrice As TextBox
    Friend WithEvents txtProductBuyPrice As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents cboOrderStatus As ComboBox
    Friend WithEvents tabPartPriceReq As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnUpdatePartPriceRequest As Button
    Friend WithEvents btnAddNewPart As Button
    Friend WithEvents btnAddNewProduct As Button
    Friend WithEvents tcOrderDetails As TabControl
    Friend WithEvents tabItemsIncluded As TabPage
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dgItemsIncluded As DataGrid
    Friend WithEvents lblItemQty As Label
    Friend WithEvents btnItemQtyUpdate As Button
    Friend WithEvents cboPrintType As ComboBox
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnEmail As Button
    Friend WithEvents btnCharges As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents chkDeadlineNA As CheckBox
    Friend WithEvents dtpDeliveryDeadline As DateTimePicker
    Friend WithEvents tabDocuments As TabPage
    Friend WithEvents pnlDocuments As Panel
    Friend WithEvents lblOrderStatus As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnCreatePartRequest As Button
    Friend WithEvents btnCreateProductPriceRequest As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents dgPriceRequests As DataGrid
    Friend WithEvents dtpSupplierInvoiceDateNew As DateTimePicker
    Friend WithEvents Label17 As Label
    Friend WithEvents txtNominalCodeNew As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtExtraReferenceNew As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents cboInvoiceTaxCodeNew As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents btnReceiveAll As Button
    Friend WithEvents btnEngineerReceived As Button
    Friend WithEvents chkDoNotConsolidate As CheckBox
    Friend WithEvents tabInvoices As TabPage
    Friend WithEvents grpReceivedInvoices As GroupBox
    Friend WithEvents dgvReceivedInvoices As DataGridView
    Friend WithEvents FSMDataSetBindingSource As BindingSource
    Friend WithEvents FSMDataSet As FSMDataSet
    Friend WithEvents btnAddSupplierInvoice As Button
    Friend WithEvents txtTotalAmount As TextBox
    Friend WithEvents lblTotalValue As Label
    Friend WithEvents txtVATAmount As TextBox
    Friend WithEvents lblVatValue As Label
    Friend WithEvents txtGoodsAmount As TextBox
    Friend WithEvents lblGoodsValue As Label
    Friend WithEvents lblInvoiceDate As Label
    Friend WithEvents txtSupplierInvoiceRefNew As TextBox
    Friend WithEvents lblSupplierRef As Label
    Friend WithEvents lblSupplierGoods As Label
    Friend WithEvents lblGoodsTotal As Label
    Friend WithEvents lblOrderTotal As Label
    Friend WithEvents lblOrderTotalLabel As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboReadySageNew As CheckBox
    Friend WithEvents btnUpdateSupplierInvoice As Button
    Friend WithEvents btnDeleteSupplierInvoice As Button
    Friend WithEvents chkRevertStatus As CheckBox
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnCreditDelete As Button
    Friend WithEvents txtCreditTotal As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCreditVAT As TextBox
    Friend WithEvents txtCreditNominal As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtCreditGoods As TextBox
    Friend WithEvents cboCreditTax As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txtCreditRef As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents btnCreditAdd As Button
    Friend WithEvents dgCredits As DataGridView
    Friend WithEvents dtpCreditDate As DateTimePicker
    Friend WithEvents lblCredits As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents lblOrderBalance As Label
    Friend WithEvents lblOrderBalanceLabel As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents txtCreditExRef As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents cboDept As ComboBox
    Friend WithEvents nudItemQty As NumericUpDown
    Friend WithEvents btnUpdateOrderRef As Button
    Friend WithEvents btnApproveOrder As Button
    Friend WithEvents dgParts As DataGrid
    Friend WithEvents btnRelatedJob As Button

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New ComponentModel.Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Me.grpOrder = New GroupBox()
        Me.btnApproveOrder = New Button()
        Me.btnUpdateOrderRef = New Button()
        Me.cboDept = New ComboBox()
        Me.lblOrderBalance = New Label()
        Me.lblOrderBalanceLabel = New Label()
        Me.chkRevertStatus = New CheckBox()
        Me.lblOrderTotalLabel = New Label()
        Me.lblOrderTotal = New Label()
        Me.chkDoNotConsolidate = New CheckBox()
        Me.chkDeadlineNA = New CheckBox()
        Me.dtpDeliveryDeadline = New DateTimePicker()
        Me.Label6 = New Label()
        Me.cboOrderStatus = New ComboBox()
        Me.Label19 = New Label()
        Me.dtpDatePlaced = New DateTimePicker()
        Me.lblDatePlaced = New Label()
        Me.txtOrderReference = New TextBox()
        Me.lblOrderReference = New Label()
        Me.tcOrderDetails = New TabControl()
        Me.tabDetails = New TabPage()
        Me.btnRelatedJob = New Button()
        Me.pnlDetails = New Panel()
        Me.lblOrderTypeID = New Label()
        Me.cboOrderTypeID = New ComboBox()
        Me.btnCharges = New Button()
        Me.tabParts = New TabPage()
        Me.grpPartSearch = New GroupBox()
        Me.btnAddNewPart = New Button()
        Me.cboPartLocation = New ComboBox()
        Me.btnPartSearch = New Button()
        Me.txtPartSearch = New TextBox()
        Me.grpAvailableParts = New GroupBox()
        Me.btnCreatePartRequest = New Button()
        Me.Label7 = New Label()
        Me.txtPartBuyPrice = New TextBox()
        Me.Label3 = New Label()
        Me.txtPartQuantity = New TextBox()
        Me.btnAddPart = New Button()
        Me.tabProducts = New TabPage()
        Me.grpProductsAvailable = New GroupBox()
        Me.btnCreateProductPriceRequest = New Button()
        Me.txtProductSellPrice = New TextBox()
        Me.Label5 = New Label()
        Me.txtProductBuyPrice = New TextBox()
        Me.Label4 = New Label()
        Me.Label1 = New Label()
        Me.txtProductQuantity = New TextBox()
        Me.dgProduct = New DataGrid()
        Me.btnAddProduct = New Button()
        Me.grpProductSearch = New GroupBox()
        Me.btnAddNewProduct = New Button()
        Me.cboProductLocation = New ComboBox()
        Me.btnProductSearch = New Button()
        Me.txtProductSearch = New TextBox()
        Me.tabItemsIncluded = New TabPage()
        Me.GroupBox3 = New GroupBox()
        Me.nudItemQty = New NumericUpDown()
        Me.btnEngineerReceived = New Button()
        Me.btnReceiveAll = New Button()
        Me.lblItemQty = New Label()
        Me.btnItemQtyUpdate = New Button()
        Me.dgItemsIncluded = New DataGrid()
        Me.tabPartPriceReq = New TabPage()
        Me.GroupBox2 = New GroupBox()
        Me.btnUpdatePartPriceRequest = New Button()
        Me.dgPriceRequests = New DataGrid()
        Me.tabDocuments = New TabPage()
        Me.pnlDocuments = New Panel()
        Me.btnEmail = New Button()
        Me.cboPrintType = New ComboBox()
        Me.btnPrint = New Button()
        Me.Label8 = New Label()
        Me.tabInvoices = New TabPage()
        Me.grpReceivedInvoices = New GroupBox()
        Me.btnDeleteSupplierInvoice = New Button()
        Me.btnUpdateSupplierInvoice = New Button()
        Me.txtTotalAmount = New TextBox()
        Me.lblTotalValue = New Label()
        Me.txtVATAmount = New TextBox()
        Me.txtNominalCodeNew = New TextBox()
        Me.Label16 = New Label()
        Me.lblVatValue = New Label()
        Me.txtGoodsAmount = New TextBox()
        Me.cboInvoiceTaxCodeNew = New ComboBox()
        Me.txtExtraReferenceNew = New TextBox()
        Me.Label13 = New Label()
        Me.lblGoodsValue = New Label()
        Me.Label15 = New Label()
        Me.lblInvoiceDate = New Label()
        Me.txtSupplierInvoiceRefNew = New TextBox()
        Me.lblSupplierRef = New Label()
        Me.btnAddSupplierInvoice = New Button()
        Me.dgvReceivedInvoices = New DataGridView()
        Me.dtpSupplierInvoiceDateNew = New DateTimePicker()
        Me.cboReadySageNew = New CheckBox()
        Me.TabPage1 = New TabPage()
        Me.GroupBox4 = New GroupBox()
        Me.Button1 = New Button()
        Me.CheckBox1 = New CheckBox()
        Me.txtCreditExRef = New TextBox()
        Me.Label21 = New Label()
        Me.btnCreditDelete = New Button()
        Me.txtCreditTotal = New TextBox()
        Me.Label9 = New Label()
        Me.txtCreditVAT = New TextBox()
        Me.txtCreditNominal = New TextBox()
        Me.Label10 = New Label()
        Me.Label14 = New Label()
        Me.txtCreditGoods = New TextBox()
        Me.cboCreditTax = New ComboBox()
        Me.Label18 = New Label()
        Me.Label20 = New Label()
        Me.txtCreditRef = New TextBox()
        Me.Label23 = New Label()
        Me.btnCreditAdd = New Button()
        Me.dgCredits = New DataGridView()
        Me.dtpCreditDate = New DateTimePicker()
        Me.lblOrderStatus = New Label()
        Me.GroupBox1 = New GroupBox()
        Me.lblCredits = New Label()
        Me.Label25 = New Label()
        Me.lblSupplierGoods = New Label()
        Me.lblGoodsTotal = New Label()
        Me.Label17 = New Label()
        Me.FSMDataSetBindingSource = New BindingSource(Me.components)
        Me.FSMDataSet = New FSMDataSet()
        Me.dgParts = New DataGrid()
        Me.grpOrder.SuspendLayout()
        Me.tcOrderDetails.SuspendLayout()
        Me.tabDetails.SuspendLayout()
        Me.tabParts.SuspendLayout()
        Me.grpPartSearch.SuspendLayout()
        Me.grpAvailableParts.SuspendLayout()
        Me.tabProducts.SuspendLayout()
        Me.grpProductsAvailable.SuspendLayout()
        CType(Me.dgProduct, ComponentModel.ISupportInitialize).BeginInit()
        Me.grpProductSearch.SuspendLayout()
        Me.tabItemsIncluded.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.nudItemQty, ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgItemsIncluded, ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPartPriceReq.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgPriceRequests, ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDocuments.SuspendLayout()
        Me.tabInvoices.SuspendLayout()
        Me.grpReceivedInvoices.SuspendLayout()
        CType(Me.dgvReceivedInvoices, ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgCredits, ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.FSMDataSetBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FSMDataSet, ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgParts, ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpOrder
        '
        Me.grpOrder.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.grpOrder.Controls.Add(Me.btnApproveOrder)
        Me.grpOrder.Controls.Add(Me.btnUpdateOrderRef)
        Me.grpOrder.Controls.Add(Me.cboDept)
        Me.grpOrder.Controls.Add(Me.lblOrderBalance)
        Me.grpOrder.Controls.Add(Me.lblOrderBalanceLabel)
        Me.grpOrder.Controls.Add(Me.chkRevertStatus)
        Me.grpOrder.Controls.Add(Me.lblOrderTotalLabel)
        Me.grpOrder.Controls.Add(Me.lblOrderTotal)
        Me.grpOrder.Controls.Add(Me.chkDoNotConsolidate)
        Me.grpOrder.Controls.Add(Me.chkDeadlineNA)
        Me.grpOrder.Controls.Add(Me.dtpDeliveryDeadline)
        Me.grpOrder.Controls.Add(Me.Label6)
        Me.grpOrder.Controls.Add(Me.cboOrderStatus)
        Me.grpOrder.Controls.Add(Me.Label19)
        Me.grpOrder.Controls.Add(Me.dtpDatePlaced)
        Me.grpOrder.Controls.Add(Me.lblDatePlaced)
        Me.grpOrder.Controls.Add(Me.txtOrderReference)
        Me.grpOrder.Controls.Add(Me.lblOrderReference)
        Me.grpOrder.Controls.Add(Me.tcOrderDetails)
        Me.grpOrder.Controls.Add(Me.lblOrderStatus)
        Me.grpOrder.Controls.Add(Me.GroupBox1)
        Me.grpOrder.Controls.Add(Me.Label17)
        Me.grpOrder.Location = New Point(8, 1)
        Me.grpOrder.Name = "grpOrder"
        Me.grpOrder.Size = New Size(1822, 561)
        Me.grpOrder.TabIndex = 1
        Me.grpOrder.TabStop = False
        Me.grpOrder.Text = "Main Details"
        '
        'btnApproveOrder
        '
        Me.btnApproveOrder.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnApproveOrder.Location = New Point(1421, 17)
        Me.btnApproveOrder.Name = "btnApproveOrder"
        Me.btnApproveOrder.Size = New Size(120, 23)
        Me.btnApproveOrder.TabIndex = 126
        Me.btnApproveOrder.Text = "Approve Order"
        Me.btnApproveOrder.Visible = False
        '
        'btnUpdateOrderRef
        '
        Me.btnUpdateOrderRef.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnUpdateOrderRef.Location = New Point(1230, 17)
        Me.btnUpdateOrderRef.Name = "btnUpdateOrderRef"
        Me.btnUpdateOrderRef.Size = New Size(120, 23)
        Me.btnUpdateOrderRef.TabIndex = 125
        Me.btnUpdateOrderRef.Text = "Change Order Ref"
        Me.btnUpdateOrderRef.Visible = False
        '
        'cboDept
        '
        Me.cboDept.FormattingEnabled = True
        Me.cboDept.Location = New Point(80, 94)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New Size(170, 21)
        Me.cboDept.TabIndex = 124
        '
        'lblOrderBalance
        '
        Me.lblOrderBalance.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.lblOrderBalance.Font = New Font("Verdana", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderBalance.Location = New Point(1685, 107)
        Me.lblOrderBalance.Name = "lblOrderBalance"
        Me.lblOrderBalance.Size = New Size(122, 15)
        Me.lblOrderBalance.TabIndex = 84
        Me.lblOrderBalance.Text = "£0.00"
        Me.lblOrderBalance.TextAlign = ContentAlignment.MiddleRight
        '
        'lblOrderBalanceLabel
        '
        Me.lblOrderBalanceLabel.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.lblOrderBalanceLabel.AutoSize = True
        Me.lblOrderBalanceLabel.Font = New Font("Verdana", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderBalanceLabel.Location = New Point(1563, 108)
        Me.lblOrderBalanceLabel.Name = "lblOrderBalanceLabel"
        Me.lblOrderBalanceLabel.Size = New Size(96, 13)
        Me.lblOrderBalanceLabel.TabIndex = 85
        Me.lblOrderBalanceLabel.Text = "Unallocated : "
        Me.lblOrderBalanceLabel.TextAlign = ContentAlignment.TopRight
        '
        'chkRevertStatus
        '
        Me.chkRevertStatus.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.chkRevertStatus.AutoSize = True
        Me.chkRevertStatus.Location = New Point(1230, 97)
        Me.chkRevertStatus.Name = "chkRevertStatus"
        Me.chkRevertStatus.Size = New Size(209, 17)
        Me.chkRevertStatus.TabIndex = 78
        Me.chkRevertStatus.Text = "Revert to Awaiting Confirmation"
        Me.chkRevertStatus.UseVisualStyleBackColor = True
        Me.chkRevertStatus.Visible = False
        '
        'lblOrderTotalLabel
        '
        Me.lblOrderTotalLabel.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.lblOrderTotalLabel.AutoSize = True
        Me.lblOrderTotalLabel.Font = New Font("Verdana", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderTotalLabel.Location = New Point(1559, 13)
        Me.lblOrderTotalLabel.Name = "lblOrderTotalLabel"
        Me.lblOrderTotalLabel.Size = New Size(157, 13)
        Me.lblOrderTotalLabel.TabIndex = 77
        Me.lblOrderTotalLabel.Text = "Purchase Order Total : "
        Me.lblOrderTotalLabel.TextAlign = ContentAlignment.TopRight
        '
        'lblOrderTotal
        '
        Me.lblOrderTotal.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.lblOrderTotal.Font = New Font("Verdana", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderTotal.Location = New Point(1731, 12)
        Me.lblOrderTotal.Name = "lblOrderTotal"
        Me.lblOrderTotal.Size = New Size(75, 15)
        Me.lblOrderTotal.TabIndex = 76
        Me.lblOrderTotal.Text = "£0.00"
        Me.lblOrderTotal.TextAlign = ContentAlignment.MiddleRight
        '
        'chkDoNotConsolidate
        '
        Me.chkDoNotConsolidate.AutoSize = True
        Me.chkDoNotConsolidate.Location = New Point(256, 97)
        Me.chkDoNotConsolidate.Name = "chkDoNotConsolidate"
        Me.chkDoNotConsolidate.Size = New Size(136, 17)
        Me.chkDoNotConsolidate.TabIndex = 69
        Me.chkDoNotConsolidate.Text = "Do Not Consolidate"
        Me.chkDoNotConsolidate.UseVisualStyleBackColor = True
        Me.chkDoNotConsolidate.Visible = False
        '
        'chkDeadlineNA
        '
        Me.chkDeadlineNA.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.chkDeadlineNA.Location = New Point(1347, 66)
        Me.chkDeadlineNA.Name = "chkDeadlineNA"
        Me.chkDeadlineNA.Size = New Size(48, 24)
        Me.chkDeadlineNA.TabIndex = 4
        Me.chkDeadlineNA.Text = "N/A"
        '
        'dtpDeliveryDeadline
        '
        Me.dtpDeliveryDeadline.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.dtpDeliveryDeadline.Location = New Point(1398, 66)
        Me.dtpDeliveryDeadline.Name = "dtpDeliveryDeadline"
        Me.dtpDeliveryDeadline.Size = New Size(144, 21)
        Me.dtpDeliveryDeadline.TabIndex = 5
        Me.dtpDeliveryDeadline.Tag = "Order.DatePlaced"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.Label6.Location = New Point(1225, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New Size(114, 23)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Delivery Deadline"
        '
        'cboOrderStatus
        '
        Me.cboOrderStatus.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.cboOrderStatus.Location = New Point(80, 43)
        Me.cboOrderStatus.Name = "cboOrderStatus"
        Me.cboOrderStatus.Size = New Size(1142, 21)
        Me.cboOrderStatus.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.Location = New Point(6, 43)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New Size(48, 23)
        Me.Label19.TabIndex = 33
        Me.Label19.Text = "Status"
        '
        'dtpDatePlaced
        '
        Me.dtpDatePlaced.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.dtpDatePlaced.Location = New Point(80, 67)
        Me.dtpDatePlaced.Name = "dtpDatePlaced"
        Me.dtpDatePlaced.Size = New Size(1142, 21)
        Me.dtpDatePlaced.TabIndex = 3
        Me.dtpDatePlaced.Tag = "Order.DatePlaced"
        '
        'lblDatePlaced
        '
        Me.lblDatePlaced.Location = New Point(6, 67)
        Me.lblDatePlaced.Name = "lblDatePlaced"
        Me.lblDatePlaced.Size = New Size(79, 20)
        Me.lblDatePlaced.TabIndex = 31
        Me.lblDatePlaced.Text = "Date Placed"
        '
        'txtOrderReference
        '
        Me.txtOrderReference.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.txtOrderReference.Location = New Point(80, 19)
        Me.txtOrderReference.MaxLength = 100
        Me.txtOrderReference.Name = "txtOrderReference"
        Me.txtOrderReference.ReadOnly = True
        Me.txtOrderReference.Size = New Size(1142, 21)
        Me.txtOrderReference.TabIndex = 1
        Me.txtOrderReference.Tag = "Order.OrderReference"
        Me.txtOrderReference.Visible = False
        '
        'lblOrderReference
        '
        Me.lblOrderReference.Location = New Point(6, 19)
        Me.lblOrderReference.Name = "lblOrderReference"
        Me.lblOrderReference.Size = New Size(66, 20)
        Me.lblOrderReference.TabIndex = 31
        Me.lblOrderReference.Text = "Order Ref"
        '
        'tcOrderDetails
        '
        Me.tcOrderDetails.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.tcOrderDetails.Controls.Add(Me.tabDetails)
        Me.tcOrderDetails.Controls.Add(Me.tabParts)
        Me.tcOrderDetails.Controls.Add(Me.tabProducts)
        Me.tcOrderDetails.Controls.Add(Me.tabItemsIncluded)
        Me.tcOrderDetails.Controls.Add(Me.tabPartPriceReq)
        Me.tcOrderDetails.Controls.Add(Me.tabDocuments)
        Me.tcOrderDetails.Controls.Add(Me.tabInvoices)
        Me.tcOrderDetails.Controls.Add(Me.TabPage1)
        Me.tcOrderDetails.Location = New Point(11, 156)
        Me.tcOrderDetails.Name = "tcOrderDetails"
        Me.tcOrderDetails.SelectedIndex = 0
        Me.tcOrderDetails.Size = New Size(1804, 399)
        Me.tcOrderDetails.TabIndex = 6
        '
        'tabDetails
        '
        Me.tabDetails.Controls.Add(Me.btnRelatedJob)
        Me.tabDetails.Controls.Add(Me.pnlDetails)
        Me.tabDetails.Controls.Add(Me.lblOrderTypeID)
        Me.tabDetails.Controls.Add(Me.cboOrderTypeID)
        Me.tabDetails.Controls.Add(Me.btnCharges)
        Me.tabDetails.Location = New Point(4, 22)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Size = New Size(1796, 373)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "Order Details"
        '
        'btnRelatedJob
        '
        Me.btnRelatedJob.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnRelatedJob.Enabled = False
        Me.btnRelatedJob.Location = New Point(1491, 7)
        Me.btnRelatedJob.Name = "btnRelatedJob"
        Me.btnRelatedJob.Size = New Size(120, 23)
        Me.btnRelatedJob.TabIndex = 32
        Me.btnRelatedJob.Text = "View Related Job"
        '
        'pnlDetails
        '
        Me.pnlDetails.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.pnlDetails.Location = New Point(0, 40)
        Me.pnlDetails.Name = "pnlDetails"
        Me.pnlDetails.Size = New Size(1793, 324)
        Me.pnlDetails.TabIndex = 9
        '
        'lblOrderTypeID
        '
        Me.lblOrderTypeID.Location = New Point(8, 8)
        Me.lblOrderTypeID.Name = "lblOrderTypeID"
        Me.lblOrderTypeID.Size = New Size(64, 20)
        Me.lblOrderTypeID.TabIndex = 31
        Me.lblOrderTypeID.Text = "Order For"
        '
        'cboOrderTypeID
        '
        Me.cboOrderTypeID.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.cboOrderTypeID.Cursor = Cursors.Hand
        Me.cboOrderTypeID.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboOrderTypeID.Location = New Point(96, 8)
        Me.cboOrderTypeID.Name = "cboOrderTypeID"
        Me.cboOrderTypeID.Size = New Size(1387, 21)
        Me.cboOrderTypeID.TabIndex = 7
        Me.cboOrderTypeID.Tag = "Order.OrderTypeID"
        '
        'btnCharges
        '
        Me.btnCharges.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnCharges.Location = New Point(1617, 7)
        Me.btnCharges.Name = "btnCharges"
        Me.btnCharges.Size = New Size(168, 23)
        Me.btnCharges.TabIndex = 8
        Me.btnCharges.Text = "Manage Additional Charges"
        '
        'tabParts
        '
        Me.tabParts.Controls.Add(Me.grpPartSearch)
        Me.tabParts.Controls.Add(Me.grpAvailableParts)
        Me.tabParts.Location = New Point(4, 22)
        Me.tabParts.Name = "tabParts"
        Me.tabParts.Size = New Size(1796, 373)
        Me.tabParts.TabIndex = 2
        Me.tabParts.Text = "Parts Available"
        '
        'grpPartSearch
        '
        Me.grpPartSearch.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.grpPartSearch.Controls.Add(Me.btnAddNewPart)
        Me.grpPartSearch.Controls.Add(Me.cboPartLocation)
        Me.grpPartSearch.Controls.Add(Me.btnPartSearch)
        Me.grpPartSearch.Controls.Add(Me.txtPartSearch)
        Me.grpPartSearch.Location = New Point(8, 8)
        Me.grpPartSearch.Name = "grpPartSearch"
        Me.grpPartSearch.Size = New Size(1785, 56)
        Me.grpPartSearch.TabIndex = 13
        Me.grpPartSearch.TabStop = False
        Me.grpPartSearch.Text = "Part Search From"
        '
        'btnAddNewPart
        '
        Me.btnAddNewPart.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnAddNewPart.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNewPart.Location = New Point(1708, 24)
        Me.btnAddNewPart.Name = "btnAddNewPart"
        Me.btnAddNewPart.Size = New Size(64, 22)
        Me.btnAddNewPart.TabIndex = 4
        Me.btnAddNewPart.Text = "New Part"
        '
        'cboPartLocation
        '
        Me.cboPartLocation.Location = New Point(8, 24)
        Me.cboPartLocation.Name = "cboPartLocation"
        Me.cboPartLocation.Size = New Size(152, 21)
        Me.cboPartLocation.TabIndex = 1
        '
        'btnPartSearch
        '
        Me.btnPartSearch.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnPartSearch.Enabled = False
        Me.btnPartSearch.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.btnPartSearch.Location = New Point(1635, 23)
        Me.btnPartSearch.Name = "btnPartSearch"
        Me.btnPartSearch.Size = New Size(64, 22)
        Me.btnPartSearch.TabIndex = 3
        Me.btnPartSearch.Text = "Find"
        '
        'txtPartSearch
        '
        Me.txtPartSearch.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.txtPartSearch.Location = New Point(168, 24)
        Me.txtPartSearch.Name = "txtPartSearch"
        Me.txtPartSearch.Size = New Size(1460, 21)
        Me.txtPartSearch.TabIndex = 2
        '
        'grpAvailableParts
        '
        Me.grpAvailableParts.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.grpAvailableParts.Controls.Add(Me.btnCreatePartRequest)
        Me.grpAvailableParts.Controls.Add(Me.Label7)
        Me.grpAvailableParts.Controls.Add(Me.txtPartBuyPrice)
        Me.grpAvailableParts.Controls.Add(Me.Label3)
        Me.grpAvailableParts.Controls.Add(Me.txtPartQuantity)
        Me.grpAvailableParts.Controls.Add(Me.dgParts)
        Me.grpAvailableParts.Controls.Add(Me.btnAddPart)
        Me.grpAvailableParts.Location = New Point(8, 72)
        Me.grpAvailableParts.Name = "grpAvailableParts"
        Me.grpAvailableParts.Size = New Size(1785, 297)
        Me.grpAvailableParts.TabIndex = 14
        Me.grpAvailableParts.TabStop = False
        Me.grpAvailableParts.Text = "Available Parts && Packs"
        '
        'btnCreatePartRequest
        '
        Me.btnCreatePartRequest.Anchor = CType(((AnchorStyles.Bottom Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.btnCreatePartRequest.Location = New Point(935, 263)
        Me.btnCreatePartRequest.Name = "btnCreatePartRequest"
        Me.btnCreatePartRequest.Size = New Size(837, 24)
        Me.btnCreatePartRequest.TabIndex = 10
        Me.btnCreatePartRequest.Text = "Part Price Request"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.Label7.Location = New Point(8, 269)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New Size(40, 13)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Qty"
        '
        'txtPartBuyPrice
        '
        Me.txtPartBuyPrice.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.txtPartBuyPrice.Location = New Point(248, 265)
        Me.txtPartBuyPrice.Name = "txtPartBuyPrice"
        Me.txtPartBuyPrice.Size = New Size(112, 21)
        Me.txtPartBuyPrice.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.Label3.Location = New Point(176, 269)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(64, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Buy Price"
        '
        'txtPartQuantity
        '
        Me.txtPartQuantity.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.txtPartQuantity.Location = New Point(56, 265)
        Me.txtPartQuantity.Name = "txtPartQuantity"
        Me.txtPartQuantity.Size = New Size(112, 21)
        Me.txtPartQuantity.TabIndex = 6
        '
        'btnAddPart
        '
        Me.btnAddPart.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.btnAddPart.Location = New Point(378, 263)
        Me.btnAddPart.Name = "btnAddPart"
        Me.btnAddPart.Size = New Size(56, 24)
        Me.btnAddPart.TabIndex = 9
        Me.btnAddPart.Text = "Add"
        '
        'tabProducts
        '
        Me.tabProducts.Controls.Add(Me.grpProductsAvailable)
        Me.tabProducts.Controls.Add(Me.grpProductSearch)
        Me.tabProducts.Location = New Point(4, 22)
        Me.tabProducts.Name = "tabProducts"
        Me.tabProducts.Size = New Size(1796, 373)
        Me.tabProducts.TabIndex = 1
        Me.tabProducts.Text = "Products Available"
        '
        'grpProductsAvailable
        '
        Me.grpProductsAvailable.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.grpProductsAvailable.Controls.Add(Me.btnCreateProductPriceRequest)
        Me.grpProductsAvailable.Controls.Add(Me.txtProductSellPrice)
        Me.grpProductsAvailable.Controls.Add(Me.Label5)
        Me.grpProductsAvailable.Controls.Add(Me.txtProductBuyPrice)
        Me.grpProductsAvailable.Controls.Add(Me.Label4)
        Me.grpProductsAvailable.Controls.Add(Me.Label1)
        Me.grpProductsAvailable.Controls.Add(Me.txtProductQuantity)
        Me.grpProductsAvailable.Controls.Add(Me.dgProduct)
        Me.grpProductsAvailable.Controls.Add(Me.btnAddProduct)
        Me.grpProductsAvailable.Location = New Point(8, 72)
        Me.grpProductsAvailable.Name = "grpProductsAvailable"
        Me.grpProductsAvailable.Size = New Size(1785, 298)
        Me.grpProductsAvailable.TabIndex = 10
        Me.grpProductsAvailable.TabStop = False
        Me.grpProductsAvailable.Text = "Available Products "
        '
        'btnCreateProductPriceRequest
        '
        Me.btnCreateProductPriceRequest.Anchor = CType(((AnchorStyles.Bottom Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.btnCreateProductPriceRequest.Location = New Point(616, 263)
        Me.btnCreateProductPriceRequest.Name = "btnCreateProductPriceRequest"
        Me.btnCreateProductPriceRequest.Size = New Size(1161, 24)
        Me.btnCreateProductPriceRequest.TabIndex = 10
        Me.btnCreateProductPriceRequest.Text = "Product Price Request"
        '
        'txtProductSellPrice
        '
        Me.txtProductSellPrice.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.txtProductSellPrice.Location = New Point(432, 265)
        Me.txtProductSellPrice.Name = "txtProductSellPrice"
        Me.txtProductSellPrice.Size = New Size(112, 21)
        Me.txtProductSellPrice.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.Label5.Location = New Point(368, 269)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New Size(64, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Sell Price"
        '
        'txtProductBuyPrice
        '
        Me.txtProductBuyPrice.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.txtProductBuyPrice.Location = New Point(232, 265)
        Me.txtProductBuyPrice.Name = "txtProductBuyPrice"
        Me.txtProductBuyPrice.Size = New Size(112, 21)
        Me.txtProductBuyPrice.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.Label4.Location = New Point(168, 269)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New Size(64, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Buy Price"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.Label1.Location = New Point(8, 269)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(40, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Qty"
        '
        'txtProductQuantity
        '
        Me.txtProductQuantity.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.txtProductQuantity.Location = New Point(48, 265)
        Me.txtProductQuantity.Name = "txtProductQuantity"
        Me.txtProductQuantity.Size = New Size(112, 21)
        Me.txtProductQuantity.TabIndex = 6
        '
        'dgProduct
        '
        Me.dgProduct.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.dgProduct.DataMember = ""
        Me.dgProduct.HeaderForeColor = SystemColors.ControlText
        Me.dgProduct.Location = New Point(8, 20)
        Me.dgProduct.Name = "dgProduct"
        Me.dgProduct.Size = New Size(1769, 235)
        Me.dgProduct.TabIndex = 5
        '
        'btnAddProduct
        '
        Me.btnAddProduct.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.btnAddProduct.Location = New Point(552, 263)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New Size(56, 24)
        Me.btnAddProduct.TabIndex = 9
        Me.btnAddProduct.Text = "Add "
        '
        'grpProductSearch
        '
        Me.grpProductSearch.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.grpProductSearch.Controls.Add(Me.btnAddNewProduct)
        Me.grpProductSearch.Controls.Add(Me.cboProductLocation)
        Me.grpProductSearch.Controls.Add(Me.btnProductSearch)
        Me.grpProductSearch.Controls.Add(Me.txtProductSearch)
        Me.grpProductSearch.Location = New Point(8, 8)
        Me.grpProductSearch.Name = "grpProductSearch"
        Me.grpProductSearch.Size = New Size(1785, 56)
        Me.grpProductSearch.TabIndex = 9
        Me.grpProductSearch.TabStop = False
        Me.grpProductSearch.Text = "Product Search From"
        '
        'btnAddNewProduct
        '
        Me.btnAddNewProduct.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnAddNewProduct.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNewProduct.Location = New Point(1680, 24)
        Me.btnAddNewProduct.Name = "btnAddNewProduct"
        Me.btnAddNewProduct.Size = New Size(88, 22)
        Me.btnAddNewProduct.TabIndex = 4
        Me.btnAddNewProduct.Text = "New Product"
        '
        'cboProductLocation
        '
        Me.cboProductLocation.Location = New Point(8, 24)
        Me.cboProductLocation.Name = "cboProductLocation"
        Me.cboProductLocation.Size = New Size(152, 21)
        Me.cboProductLocation.TabIndex = 1
        '
        'btnProductSearch
        '
        Me.btnProductSearch.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnProductSearch.Enabled = False
        Me.btnProductSearch.Location = New Point(1618, 24)
        Me.btnProductSearch.Name = "btnProductSearch"
        Me.btnProductSearch.Size = New Size(56, 22)
        Me.btnProductSearch.TabIndex = 3
        Me.btnProductSearch.Text = "Find"
        '
        'txtProductSearch
        '
        Me.txtProductSearch.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.txtProductSearch.Location = New Point(168, 24)
        Me.txtProductSearch.Name = "txtProductSearch"
        Me.txtProductSearch.Size = New Size(1444, 21)
        Me.txtProductSearch.TabIndex = 2
        '
        'tabItemsIncluded
        '
        Me.tabItemsIncluded.Controls.Add(Me.GroupBox3)
        Me.tabItemsIncluded.Location = New Point(4, 22)
        Me.tabItemsIncluded.Name = "tabItemsIncluded"
        Me.tabItemsIncluded.Size = New Size(1796, 373)
        Me.tabItemsIncluded.TabIndex = 8
        Me.tabItemsIncluded.Text = "Items Included"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.nudItemQty)
        Me.GroupBox3.Controls.Add(Me.btnEngineerReceived)
        Me.GroupBox3.Controls.Add(Me.btnReceiveAll)
        Me.GroupBox3.Controls.Add(Me.lblItemQty)
        Me.GroupBox3.Controls.Add(Me.btnItemQtyUpdate)
        Me.GroupBox3.Controls.Add(Me.dgItemsIncluded)
        Me.GroupBox3.Location = New Point(8, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New Size(1785, 361)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Double click to mark as received"
        '
        'nudItemQty
        '
        Me.nudItemQty.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.nudItemQty.Location = New Point(70, 327)
        Me.nudItemQty.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nudItemQty.Name = "nudItemQty"
        Me.nudItemQty.Size = New Size(64, 21)
        Me.nudItemQty.TabIndex = 30
        Me.nudItemQty.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnEngineerReceived
        '
        Me.btnEngineerReceived.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        Me.btnEngineerReceived.Location = New Point(1536, 328)
        Me.btnEngineerReceived.Name = "btnEngineerReceived"
        Me.btnEngineerReceived.Size = New Size(134, 23)
        Me.btnEngineerReceived.TabIndex = 12
        Me.btnEngineerReceived.Text = "Engineer Received"
        Me.btnEngineerReceived.UseVisualStyleBackColor = True
        '
        'btnReceiveAll
        '
        Me.btnReceiveAll.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        Me.btnReceiveAll.Location = New Point(1676, 328)
        Me.btnReceiveAll.Name = "btnReceiveAll"
        Me.btnReceiveAll.Size = New Size(101, 23)
        Me.btnReceiveAll.TabIndex = 11
        Me.btnReceiveAll.Text = "Receive All"
        Me.btnReceiveAll.UseVisualStyleBackColor = True
        '
        'lblItemQty
        '
        Me.lblItemQty.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.lblItemQty.Location = New Point(8, 329)
        Me.lblItemQty.Name = "lblItemQty"
        Me.lblItemQty.Size = New Size(56, 21)
        Me.lblItemQty.TabIndex = 10
        Me.lblItemQty.Text = "Quantity"
        '
        'btnItemQtyUpdate
        '
        Me.btnItemQtyUpdate.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.btnItemQtyUpdate.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.btnItemQtyUpdate.Location = New Point(149, 325)
        Me.btnItemQtyUpdate.Name = "btnItemQtyUpdate"
        Me.btnItemQtyUpdate.Size = New Size(64, 23)
        Me.btnItemQtyUpdate.TabIndex = 3
        Me.btnItemQtyUpdate.Text = "Update"
        '
        'dgItemsIncluded
        '
        Me.dgItemsIncluded.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.dgItemsIncluded.DataMember = ""
        Me.dgItemsIncluded.HeaderForeColor = SystemColors.ControlText
        Me.dgItemsIncluded.Location = New Point(8, 20)
        Me.dgItemsIncluded.Name = "dgItemsIncluded"
        Me.dgItemsIncluded.Size = New Size(1769, 302)
        Me.dgItemsIncluded.TabIndex = 1
        '
        'tabPartPriceReq
        '
        Me.tabPartPriceReq.Controls.Add(Me.GroupBox2)
        Me.tabPartPriceReq.Location = New Point(4, 22)
        Me.tabPartPriceReq.Name = "tabPartPriceReq"
        Me.tabPartPriceReq.Size = New Size(1796, 373)
        Me.tabPartPriceReq.TabIndex = 7
        Me.tabPartPriceReq.Text = "Price Requests"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnUpdatePartPriceRequest)
        Me.GroupBox2.Controls.Add(Me.dgPriceRequests)
        Me.GroupBox2.Location = New Point(8, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New Size(1785, 361)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Price requests for parts and products"
        '
        'btnUpdatePartPriceRequest
        '
        Me.btnUpdatePartPriceRequest.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.btnUpdatePartPriceRequest.Location = New Point(8, 329)
        Me.btnUpdatePartPriceRequest.Name = "btnUpdatePartPriceRequest"
        Me.btnUpdatePartPriceRequest.Size = New Size(75, 24)
        Me.btnUpdatePartPriceRequest.TabIndex = 2
        Me.btnUpdatePartPriceRequest.Text = "Update"
        '
        'dgPriceRequests
        '
        Me.dgPriceRequests.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.dgPriceRequests.DataMember = ""
        Me.dgPriceRequests.HeaderForeColor = SystemColors.ControlText
        Me.dgPriceRequests.Location = New Point(8, 32)
        Me.dgPriceRequests.Name = "dgPriceRequests"
        Me.dgPriceRequests.Size = New Size(1769, 287)
        Me.dgPriceRequests.TabIndex = 1
        '
        'tabDocuments
        '
        Me.tabDocuments.Controls.Add(Me.pnlDocuments)
        Me.tabDocuments.Controls.Add(Me.btnEmail)
        Me.tabDocuments.Controls.Add(Me.cboPrintType)
        Me.tabDocuments.Controls.Add(Me.btnPrint)
        Me.tabDocuments.Controls.Add(Me.Label8)
        Me.tabDocuments.Location = New Point(4, 22)
        Me.tabDocuments.Name = "tabDocuments"
        Me.tabDocuments.Size = New Size(1796, 373)
        Me.tabDocuments.TabIndex = 9
        Me.tabDocuments.Text = "Documents"
        '
        'pnlDocuments
        '
        Me.pnlDocuments.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.pnlDocuments.Location = New Point(8, 40)
        Me.pnlDocuments.Name = "pnlDocuments"
        Me.pnlDocuments.Size = New Size(1785, 324)
        Me.pnlDocuments.TabIndex = 4
        '
        'btnEmail
        '
        Me.btnEmail.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnEmail.Location = New Point(1329, 8)
        Me.btnEmail.Name = "btnEmail"
        Me.btnEmail.Size = New Size(104, 23)
        Me.btnEmail.TabIndex = 3
        Me.btnEmail.Text = "Send Via Email"
        Me.btnEmail.Visible = False
        '
        'cboPrintType
        '
        Me.cboPrintType.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.cboPrintType.Location = New Point(8, 8)
        Me.cboPrintType.Name = "cboPrintType"
        Me.cboPrintType.Size = New Size(1225, 21)
        Me.cboPrintType.TabIndex = 1
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnPrint.Location = New Point(1241, 8)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New Size(56, 23)
        Me.btnPrint.TabIndex = 2
        Me.btnPrint.Text = "Print"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.Label8.Location = New Point(1305, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New Size(18, 16)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "or"
        Me.Label8.Visible = False
        '
        'tabInvoices
        '
        Me.tabInvoices.Controls.Add(Me.grpReceivedInvoices)
        Me.tabInvoices.Location = New Point(4, 22)
        Me.tabInvoices.Name = "tabInvoices"
        Me.tabInvoices.Size = New Size(1796, 373)
        Me.tabInvoices.TabIndex = 10
        Me.tabInvoices.Text = "Supplier Invoices"
        '
        'grpReceivedInvoices
        '
        Me.grpReceivedInvoices.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.grpReceivedInvoices.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Me.grpReceivedInvoices.Controls.Add(Me.btnDeleteSupplierInvoice)
        Me.grpReceivedInvoices.Controls.Add(Me.btnUpdateSupplierInvoice)
        Me.grpReceivedInvoices.Controls.Add(Me.txtTotalAmount)
        Me.grpReceivedInvoices.Controls.Add(Me.lblTotalValue)
        Me.grpReceivedInvoices.Controls.Add(Me.txtVATAmount)
        Me.grpReceivedInvoices.Controls.Add(Me.txtNominalCodeNew)
        Me.grpReceivedInvoices.Controls.Add(Me.Label16)
        Me.grpReceivedInvoices.Controls.Add(Me.lblVatValue)
        Me.grpReceivedInvoices.Controls.Add(Me.txtGoodsAmount)
        Me.grpReceivedInvoices.Controls.Add(Me.cboInvoiceTaxCodeNew)
        Me.grpReceivedInvoices.Controls.Add(Me.txtExtraReferenceNew)
        Me.grpReceivedInvoices.Controls.Add(Me.Label13)
        Me.grpReceivedInvoices.Controls.Add(Me.lblGoodsValue)
        Me.grpReceivedInvoices.Controls.Add(Me.Label15)
        Me.grpReceivedInvoices.Controls.Add(Me.lblInvoiceDate)
        Me.grpReceivedInvoices.Controls.Add(Me.txtSupplierInvoiceRefNew)
        Me.grpReceivedInvoices.Controls.Add(Me.lblSupplierRef)
        Me.grpReceivedInvoices.Controls.Add(Me.btnAddSupplierInvoice)
        Me.grpReceivedInvoices.Controls.Add(Me.dgvReceivedInvoices)
        Me.grpReceivedInvoices.Controls.Add(Me.dtpSupplierInvoiceDateNew)
        Me.grpReceivedInvoices.Controls.Add(Me.cboReadySageNew)
        Me.grpReceivedInvoices.Location = New Point(4, 4)
        Me.grpReceivedInvoices.Name = "grpReceivedInvoices"
        Me.grpReceivedInvoices.Size = New Size(1789, 366)
        Me.grpReceivedInvoices.TabIndex = 0
        Me.grpReceivedInvoices.TabStop = False
        Me.grpReceivedInvoices.Text = "Received Invoices"
        '
        'btnDeleteSupplierInvoice
        '
        Me.btnDeleteSupplierInvoice.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        Me.btnDeleteSupplierInvoice.Location = New Point(1603, 339)
        Me.btnDeleteSupplierInvoice.Name = "btnDeleteSupplierInvoice"
        Me.btnDeleteSupplierInvoice.Size = New Size(56, 24)
        Me.btnDeleteSupplierInvoice.TabIndex = 121
        Me.btnDeleteSupplierInvoice.Text = "Delete"
        Me.btnDeleteSupplierInvoice.Visible = False
        '
        'btnUpdateSupplierInvoice
        '
        Me.btnUpdateSupplierInvoice.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        Me.btnUpdateSupplierInvoice.Location = New Point(1665, 339)
        Me.btnUpdateSupplierInvoice.Name = "btnUpdateSupplierInvoice"
        Me.btnUpdateSupplierInvoice.Size = New Size(56, 24)
        Me.btnUpdateSupplierInvoice.TabIndex = 122
        Me.btnUpdateSupplierInvoice.Text = "Update"
        Me.btnUpdateSupplierInvoice.Visible = False
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.txtTotalAmount.Location = New Point(547, 340)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.Size = New Size(100, 21)
        Me.txtTotalAmount.TabIndex = 109
        '
        'lblTotalValue
        '
        Me.lblTotalValue.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.lblTotalValue.AutoSize = True
        Me.lblTotalValue.Location = New Point(485, 343)
        Me.lblTotalValue.Name = "lblTotalValue"
        Me.lblTotalValue.Size = New Size(55, 13)
        Me.lblTotalValue.TabIndex = 28
        Me.lblTotalValue.Text = "Total (£)"
        '
        'txtVATAmount
        '
        Me.txtVATAmount.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.txtVATAmount.Location = New Point(379, 340)
        Me.txtVATAmount.Name = "txtVATAmount"
        Me.txtVATAmount.Size = New Size(100, 21)
        Me.txtVATAmount.TabIndex = 108
        '
        'txtNominalCodeNew
        '
        Me.txtNominalCodeNew.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.txtNominalCodeNew.Location = New Point(633, 311)
        Me.txtNominalCodeNew.MaxLength = 100
        Me.txtNominalCodeNew.Name = "txtNominalCodeNew"
        Me.txtNominalCodeNew.Size = New Size(70, 21)
        Me.txtNominalCodeNew.TabIndex = 105
        Me.txtNominalCodeNew.Tag = "Order.SupplierInvoiceReference"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.Label16.Location = New Point(568, 314)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New Size(70, 20)
        Me.Label16.TabIndex = 65
        Me.Label16.Text = "Nominal"
        '
        'lblVatValue
        '
        Me.lblVatValue.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.lblVatValue.AutoSize = True
        Me.lblVatValue.Location = New Point(322, 343)
        Me.lblVatValue.Name = "lblVatValue"
        Me.lblVatValue.Size = New Size(50, 13)
        Me.lblVatValue.TabIndex = 26
        Me.lblVatValue.Text = "VAT (£)"
        '
        'txtGoodsAmount
        '
        Me.txtGoodsAmount.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.txtGoodsAmount.Location = New Point(76, 340)
        Me.txtGoodsAmount.Name = "txtGoodsAmount"
        Me.txtGoodsAmount.Size = New Size(100, 21)
        Me.txtGoodsAmount.TabIndex = 106
        '
        'cboInvoiceTaxCodeNew
        '
        Me.cboInvoiceTaxCodeNew.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.cboInvoiceTaxCodeNew.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboInvoiceTaxCodeNew.Location = New Point(258, 340)
        Me.cboInvoiceTaxCodeNew.Name = "cboInvoiceTaxCodeNew"
        Me.cboInvoiceTaxCodeNew.Size = New Size(58, 21)
        Me.cboInvoiceTaxCodeNew.TabIndex = 107
        '
        'txtExtraReferenceNew
        '
        Me.txtExtraReferenceNew.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.txtExtraReferenceNew.Location = New Point(493, 311)
        Me.txtExtraReferenceNew.MaxLength = 100
        Me.txtExtraReferenceNew.Name = "txtExtraReferenceNew"
        Me.txtExtraReferenceNew.Size = New Size(70, 21)
        Me.txtExtraReferenceNew.TabIndex = 104
        Me.txtExtraReferenceNew.Tag = "Order.SupplierInvoiceReference"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.Label13.Location = New Point(182, 343)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New Size(70, 20)
        Me.Label13.TabIndex = 59
        Me.Label13.Text = "Tax Code"
        '
        'lblGoodsValue
        '
        Me.lblGoodsValue.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.lblGoodsValue.AutoSize = True
        Me.lblGoodsValue.Location = New Point(6, 343)
        Me.lblGoodsValue.Name = "lblGoodsValue"
        Me.lblGoodsValue.Size = New Size(64, 13)
        Me.lblGoodsValue.TabIndex = 24
        Me.lblGoodsValue.Text = "Goods (£)"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.Label15.Location = New Point(435, 314)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New Size(56, 20)
        Me.Label15.TabIndex = 63
        Me.Label15.Text = "Ex Ref."
        '
        'lblInvoiceDate
        '
        Me.lblInvoiceDate.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.lblInvoiceDate.AutoSize = True
        Me.lblInvoiceDate.Location = New Point(6, 314)
        Me.lblInvoiceDate.Name = "lblInvoiceDate"
        Me.lblInvoiceDate.Size = New Size(80, 13)
        Me.lblInvoiceDate.TabIndex = 1
        Me.lblInvoiceDate.Text = "Invoice Date"
        '
        'txtSupplierInvoiceRefNew
        '
        Me.txtSupplierInvoiceRefNew.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.txtSupplierInvoiceRefNew.Location = New Point(329, 311)
        Me.txtSupplierInvoiceRefNew.Name = "txtSupplierInvoiceRefNew"
        Me.txtSupplierInvoiceRefNew.Size = New Size(100, 21)
        Me.txtSupplierInvoiceRefNew.TabIndex = 103
        '
        'lblSupplierRef
        '
        Me.lblSupplierRef.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.lblSupplierRef.AutoSize = True
        Me.lblSupplierRef.Location = New Point(242, 314)
        Me.lblSupplierRef.Name = "lblSupplierRef"
        Me.lblSupplierRef.Size = New Size(75, 13)
        Me.lblSupplierRef.TabIndex = 1
        Me.lblSupplierRef.Text = "Invoice Ref."
        '
        'btnAddSupplierInvoice
        '
        Me.btnAddSupplierInvoice.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        Me.btnAddSupplierInvoice.Location = New Point(1727, 339)
        Me.btnAddSupplierInvoice.Name = "btnAddSupplierInvoice"
        Me.btnAddSupplierInvoice.Size = New Size(56, 24)
        Me.btnAddSupplierInvoice.TabIndex = 123
        Me.btnAddSupplierInvoice.Text = "Add "
        '
        'dgvReceivedInvoices
        '
        Me.dgvReceivedInvoices.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = Color.White
        DataGridViewCellStyle1.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = Color.Navy
        DataGridViewCellStyle1.SelectionBackColor = Color.Gainsboro
        DataGridViewCellStyle1.SelectionForeColor = Color.Navy
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.[True]
        Me.dgvReceivedInvoices.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReceivedInvoices.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.dgvReceivedInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvReceivedInvoices.BackgroundColor = Color.White
        Me.dgvReceivedInvoices.BorderStyle = BorderStyle.None
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.SteelBlue
        DataGridViewCellStyle2.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = Color.SteelBlue
        DataGridViewCellStyle2.SelectionForeColor = Color.White
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.[True]
        Me.dgvReceivedInvoices.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvReceivedInvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReceivedInvoices.EnableHeadersVisualStyles = False
        Me.dgvReceivedInvoices.GridColor = Color.LightSteelBlue
        Me.dgvReceivedInvoices.Location = New Point(3, 17)
        Me.dgvReceivedInvoices.MultiSelect = False
        Me.dgvReceivedInvoices.Name = "dgvReceivedInvoices"
        Me.dgvReceivedInvoices.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = Color.Gainsboro
        DataGridViewCellStyle3.SelectionForeColor = Color.Navy
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.[True]
        Me.dgvReceivedInvoices.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvReceivedInvoices.RowTemplate.Height = 29
        Me.dgvReceivedInvoices.RowTemplate.ReadOnly = True
        Me.dgvReceivedInvoices.RowTemplate.Resizable = DataGridViewTriState.[True]
        Me.dgvReceivedInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvReceivedInvoices.Size = New Size(1780, 288)
        Me.dgvReceivedInvoices.TabIndex = 0
        '
        'dtpSupplierInvoiceDateNew
        '
        Me.dtpSupplierInvoiceDateNew.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.dtpSupplierInvoiceDateNew.Location = New Point(92, 311)
        Me.dtpSupplierInvoiceDateNew.Name = "dtpSupplierInvoiceDateNew"
        Me.dtpSupplierInvoiceDateNew.Size = New Size(144, 21)
        Me.dtpSupplierInvoiceDateNew.TabIndex = 101
        Me.dtpSupplierInvoiceDateNew.Tag = "Order.SupplierInvoiceDate"
        '
        'cboReadySageNew
        '
        Me.cboReadySageNew.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.cboReadySageNew.Location = New Point(653, 338)
        Me.cboReadySageNew.Name = "cboReadySageNew"
        Me.cboReadySageNew.RightToLeft = RightToLeft.Yes
        Me.cboReadySageNew.Size = New Size(247, 24)
        Me.cboReadySageNew.TabIndex = 110
        Me.cboReadySageNew.Text = "Ready to send to Accounts Package"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Location = New Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New Size(1796, 373)
        Me.TabPage1.TabIndex = 11
        Me.TabPage1.Text = "Credits"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.GroupBox4.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.CheckBox1)
        Me.GroupBox4.Controls.Add(Me.txtCreditExRef)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.btnCreditDelete)
        Me.GroupBox4.Controls.Add(Me.txtCreditTotal)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.txtCreditVAT)
        Me.GroupBox4.Controls.Add(Me.txtCreditNominal)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.txtCreditGoods)
        Me.GroupBox4.Controls.Add(Me.cboCreditTax)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.txtCreditRef)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.btnCreditAdd)
        Me.GroupBox4.Controls.Add(Me.dgCredits)
        Me.GroupBox4.Controls.Add(Me.dtpCreditDate)
        Me.GroupBox4.Location = New Point(3, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New Size(1789, 366)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Part Credits"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        Me.Button1.Location = New Point(1495, 339)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New Size(142, 24)
        Me.Button1.TabIndex = 127
        Me.Button1.Text = "Convert to Van stock"
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.CheckBox1.Location = New Point(-20, 312)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.RightToLeft = RightToLeft.Yes
        Me.CheckBox1.Size = New Size(141, 24)
        Me.CheckBox1.TabIndex = 126
        Me.CheckBox1.Text = "Credit Recieved"
        '
        'txtCreditExRef
        '
        Me.txtCreditExRef.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.txtCreditExRef.Location = New Point(1118, 339)
        Me.txtCreditExRef.MaxLength = 100
        Me.txtCreditExRef.Name = "txtCreditExRef"
        Me.txtCreditExRef.Size = New Size(70, 21)
        Me.txtCreditExRef.TabIndex = 125
        Me.txtCreditExRef.Tag = "Order.SupplierInvoiceReference"
        '
        'Label21
        '
        Me.Label21.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.Label21.Location = New Point(1073, 342)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New Size(56, 20)
        Me.Label21.TabIndex = 124
        Me.Label21.Text = "Ex Ref."
        '
        'btnCreditDelete
        '
        Me.btnCreditDelete.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        Me.btnCreditDelete.Location = New Point(1656, 339)
        Me.btnCreditDelete.Name = "btnCreditDelete"
        Me.btnCreditDelete.Size = New Size(56, 24)
        Me.btnCreditDelete.TabIndex = 121
        Me.btnCreditDelete.Text = "Delete"
        Me.btnCreditDelete.Visible = False
        '
        'txtCreditTotal
        '
        Me.txtCreditTotal.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.txtCreditTotal.Location = New Point(539, 342)
        Me.txtCreditTotal.Name = "txtCreditTotal"
        Me.txtCreditTotal.Size = New Size(68, 21)
        Me.txtCreditTotal.TabIndex = 109
        '
        'Label9
        '
        Me.Label9.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New Point(467, 345)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New Size(55, 13)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Total (£)"
        '
        'txtCreditVAT
        '
        Me.txtCreditVAT.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.txtCreditVAT.Location = New Point(372, 341)
        Me.txtCreditVAT.Name = "txtCreditVAT"
        Me.txtCreditVAT.Size = New Size(68, 21)
        Me.txtCreditVAT.TabIndex = 108
        '
        'txtCreditNominal
        '
        Me.txtCreditNominal.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.txtCreditNominal.Location = New Point(1000, 339)
        Me.txtCreditNominal.MaxLength = 100
        Me.txtCreditNominal.Name = "txtCreditNominal"
        Me.txtCreditNominal.Size = New Size(70, 21)
        Me.txtCreditNominal.TabIndex = 105
        Me.txtCreditNominal.Tag = "Order.SupplierInvoiceReference"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.Label10.Location = New Point(947, 342)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New Size(70, 20)
        Me.Label10.TabIndex = 65
        Me.Label10.Text = "Nominal"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New Point(309, 344)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New Size(50, 13)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "VAT (£)"
        '
        'txtCreditGoods
        '
        Me.txtCreditGoods.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.txtCreditGoods.Location = New Point(95, 340)
        Me.txtCreditGoods.Name = "txtCreditGoods"
        Me.txtCreditGoods.Size = New Size(54, 21)
        Me.txtCreditGoods.TabIndex = 106
        '
        'cboCreditTax
        '
        Me.cboCreditTax.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.cboCreditTax.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboCreditTax.Location = New Point(238, 340)
        Me.cboCreditTax.Name = "cboCreditTax"
        Me.cboCreditTax.Size = New Size(46, 21)
        Me.cboCreditTax.TabIndex = 107
        '
        'Label18
        '
        Me.Label18.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.Label18.Location = New Point(168, 342)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New Size(70, 20)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "Tax Code"
        '
        'Label20
        '
        Me.Label20.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Location = New Point(6, 343)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New Size(86, 13)
        Me.Label20.TabIndex = 24
        Me.Label20.Text = "Credit Net (£)"
        '
        'txtCreditRef
        '
        Me.txtCreditRef.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.txtCreditRef.Location = New Point(871, 339)
        Me.txtCreditRef.Name = "txtCreditRef"
        Me.txtCreditRef.Size = New Size(70, 21)
        Me.txtCreditRef.TabIndex = 103
        '
        'Label23
        '
        Me.Label23.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Location = New Point(801, 344)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New Size(68, 13)
        Me.Label23.TabIndex = 1
        Me.Label23.Text = "Credit Ref."
        '
        'btnCreditAdd
        '
        Me.btnCreditAdd.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        Me.btnCreditAdd.Location = New Point(1727, 339)
        Me.btnCreditAdd.Name = "btnCreditAdd"
        Me.btnCreditAdd.Size = New Size(56, 24)
        Me.btnCreditAdd.TabIndex = 123
        Me.btnCreditAdd.Text = "Add "
        '
        'dgCredits
        '
        Me.dgCredits.AllowUserToAddRows = False
        DataGridViewCellStyle4.BackColor = Color.White
        DataGridViewCellStyle4.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = Color.Navy
        DataGridViewCellStyle4.SelectionBackColor = Color.Gainsboro
        DataGridViewCellStyle4.SelectionForeColor = Color.Navy
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.[True]
        Me.dgCredits.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgCredits.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.dgCredits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.dgCredits.BackgroundColor = Color.White
        Me.dgCredits.BorderStyle = BorderStyle.None
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = Color.SteelBlue
        DataGridViewCellStyle5.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = Color.White
        DataGridViewCellStyle5.SelectionBackColor = Color.SteelBlue
        DataGridViewCellStyle5.SelectionForeColor = Color.White
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.[True]
        Me.dgCredits.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgCredits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCredits.EnableHeadersVisualStyles = False
        Me.dgCredits.GridColor = Color.LightSteelBlue
        Me.dgCredits.Location = New Point(3, 23)
        Me.dgCredits.MultiSelect = False
        Me.dgCredits.Name = "dgCredits"
        Me.dgCredits.RowHeadersVisible = False
        DataGridViewCellStyle6.BackColor = Color.White
        DataGridViewCellStyle6.Font = New Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = Color.Navy
        DataGridViewCellStyle6.SelectionBackColor = Color.Gainsboro
        DataGridViewCellStyle6.SelectionForeColor = Color.Navy
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.[True]
        Me.dgCredits.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgCredits.RowTemplate.Height = 29
        Me.dgCredits.RowTemplate.ReadOnly = True
        Me.dgCredits.RowTemplate.Resizable = DataGridViewTriState.[True]
        Me.dgCredits.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgCredits.Size = New Size(1780, 288)
        Me.dgCredits.TabIndex = 0
        '
        'dtpCreditDate
        '
        Me.dtpCreditDate.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.dtpCreditDate.Location = New Point(128, 313)
        Me.dtpCreditDate.Name = "dtpCreditDate"
        Me.dtpCreditDate.Size = New Size(142, 21)
        Me.dtpCreditDate.TabIndex = 101
        Me.dtpCreditDate.Tag = "Order.SupplierInvoiceDate"
        '
        'lblOrderStatus
        '
        Me.lblOrderStatus.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.lblOrderStatus.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblOrderStatus.Font = New Font("Verdana", 10.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderStatus.Location = New Point(16, 129)
        Me.lblOrderStatus.Name = "lblOrderStatus"
        Me.lblOrderStatus.Size = New Size(1645, 24)
        Me.lblOrderStatus.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblCredits)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.lblSupplierGoods)
        Me.GroupBox1.Controls.Add(Me.lblGoodsTotal)
        Me.GroupBox1.Location = New Point(1547, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New Size(275, 63)
        Me.GroupBox1.TabIndex = 76
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Supplier Invoice Totals"
        '
        'lblCredits
        '
        Me.lblCredits.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.lblCredits.Font = New Font("Verdana", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.lblCredits.Location = New Point(138, 37)
        Me.lblCredits.Name = "lblCredits"
        Me.lblCredits.Size = New Size(122, 15)
        Me.lblCredits.TabIndex = 80
        Me.lblCredits.Text = "£0.00"
        Me.lblCredits.TextAlign = ContentAlignment.MiddleRight
        '
        'Label25
        '
        Me.Label25.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Font = New Font("Verdana", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New Point(14, 40)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New Size(123, 13)
        Me.Label25.TabIndex = 81
        Me.Label25.Text = "Supplier Credits : "
        Me.Label25.TextAlign = ContentAlignment.TopRight
        '
        'lblSupplierGoods
        '
        Me.lblSupplierGoods.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.lblSupplierGoods.AutoSize = True
        Me.lblSupplierGoods.Font = New Font("Verdana", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.lblSupplierGoods.Location = New Point(14, 19)
        Me.lblSupplierGoods.Name = "lblSupplierGoods"
        Me.lblSupplierGoods.Size = New Size(133, 13)
        Me.lblSupplierGoods.TabIndex = 73
        Me.lblSupplierGoods.Text = "Supplier Invoices : "
        Me.lblSupplierGoods.TextAlign = ContentAlignment.TopRight
        '
        'lblGoodsTotal
        '
        Me.lblGoodsTotal.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.lblGoodsTotal.Font = New Font("Verdana", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.lblGoodsTotal.Location = New Point(138, 17)
        Me.lblGoodsTotal.Name = "lblGoodsTotal"
        Me.lblGoodsTotal.Size = New Size(122, 15)
        Me.lblGoodsTotal.TabIndex = 70
        Me.lblGoodsTotal.Text = "£0.00"
        Me.lblGoodsTotal.TextAlign = ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.Location = New Point(6, 97)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New Size(79, 20)
        Me.Label17.TabIndex = 68
        Me.Label17.Text = "Cost Centre"
        '
        'FSMDataSetBindingSource
        '
        Me.FSMDataSetBindingSource.DataSource = Me.FSMDataSet
        Me.FSMDataSetBindingSource.Position = 0
        '
        'FSMDataSet
        '
        Me.FSMDataSet.DataSetName = "FSMDataSet"
        Me.FSMDataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema
        '
        'dgParts
        '
        Me.dgParts.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.dgParts.DataMember = ""
        Me.dgParts.HeaderForeColor = SystemColors.ControlText
        Me.dgParts.Location = New Point(8, 20)
        Me.dgParts.Name = "dgParts"
        Me.dgParts.Size = New Size(1769, 237)
        Me.dgParts.TabIndex = 5
        '
        'UCOrder
        '
        Me.Controls.Add(Me.grpOrder)
        Me.Name = "UCOrder"
        Me.Size = New Size(1835, 571)
        Me.grpOrder.ResumeLayout(False)
        Me.grpOrder.PerformLayout()
        Me.tcOrderDetails.ResumeLayout(False)
        Me.tabDetails.ResumeLayout(False)
        Me.tabParts.ResumeLayout(False)
        Me.grpPartSearch.ResumeLayout(False)
        Me.grpPartSearch.PerformLayout()
        Me.grpAvailableParts.ResumeLayout(False)
        Me.grpAvailableParts.PerformLayout()
        Me.tabProducts.ResumeLayout(False)
        Me.grpProductsAvailable.ResumeLayout(False)
        Me.grpProductsAvailable.PerformLayout()
        CType(Me.dgProduct, ComponentModel.ISupportInitialize).EndInit()
        Me.grpProductSearch.ResumeLayout(False)
        Me.grpProductSearch.PerformLayout()
        Me.tabItemsIncluded.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.nudItemQty, ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgItemsIncluded, ComponentModel.ISupportInitialize).EndInit()
        Me.tabPartPriceReq.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgPriceRequests, ComponentModel.ISupportInitialize).EndInit()
        Me.tabDocuments.ResumeLayout(False)
        Me.tabInvoices.ResumeLayout(False)
        Me.grpReceivedInvoices.ResumeLayout(False)
        Me.grpReceivedInvoices.PerformLayout()
        CType(Me.dgvReceivedInvoices, ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgCredits, ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.FSMDataSetBindingSource, ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FSMDataSet, ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgParts, ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Objects"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)

        SetupProductsDatagrid()
        SetupPartsDatagrid()
        SetupPriceRequestDatagrid()
        SetupSupplierInvoices()
        SetupCredits()

        If Not CurrentOrder Is Nothing Then
            If CurrentOrder.OrderStatusID = Enums.OrderStatus.AwaitingConfirmation Or CurrentOrder.OrderStatusID = 0 Then
                txtOrderReference.Visible = False
            Else
                txtOrderReference.Visible = True

            End If
        Else
            txtOrderReference.Visible = False
        End If

        tcOrderDetails.TabPages.Remove(tabProducts)
        tcOrderDetails.TabPages.Remove(tabPartPriceReq)

    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentOrder
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Public Event FormClose()

    Private IsLoading As Boolean = True
    Private DocumentsControl As UCDocumentsList
    Public ucCustomerOrder As New UCOrderForCustomer
    Public ucJobOrder As New UCOrderForJob
    Public ucWarehouseOrder As New UCOrderForWarehouse
    Public ucVanOrder As New UCOrderForVan

    Private _currentOrder As Entity.Orders.Order

    Public Property CurrentOrder() As Entity.Orders.Order
        Get
            Return _currentOrder
        End Get
        Set(ByVal Value As Entity.Orders.Order)
            _currentOrder = Value

            If _currentOrder Is Nothing Then
                _currentOrder = New Entity.Orders.Order
                _currentOrder.Exists = False
            End If

            If Not CurrentOrder.Exists Then
                Me.btnEngineerReceived.Visible = False
                OrderNumber = DB.Job.GetNextJobNumber(Enums.JobDefinition.ORDER)

                Me.cboOrderStatus.Enabled = False
                'Me.txtOrderReference.Enabled = True
                'Me.dtpDatePlaced.Enabled = True
                Me.cboOrderTypeID.Enabled = True
                'Me.dtpDeliveryDeadline.Enabled = True
                'Me.chkDeadlineNA.Enabled = True
                Me.cboPrintType.Enabled = False
                Me.btnPrint.Enabled = False
                Me.btnEmail.Enabled = False
                Me.btnCharges.Enabled = False

                Combo.SetSelectedComboItem_By_Value(cboOrderStatus, Enums.OrderStatus.AwaitingConfirmation)

                Me.lblOrderStatus.Text = "SAVE BASE ORDER DETAILS BEFORE MANAGING ITEMS"
                Me.lblOrderStatus.Visible = True

                EnableTabs(False)

                Combo.SetUpCombo(Me.cboPrintType, Nothing, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select)

                'Me.lblGoodsValue.Text = Format(0, "C")
                '     Me.lblVATTotal.Text = Format(0, "C")
            Else
                Me.cboOrderStatus.Enabled = True
                'Me.txtOrderReference.Enabled = False
                'Me.dtpDatePlaced.Enabled = False
                Me.cboOrderTypeID.Enabled = False
                'Me.dtpDeliveryDeadline.Enabled = False
                'Me.chkDeadlineNA.Enabled = False
                Me.cboPrintType.Enabled = True
                Me.btnPrint.Enabled = True
                Me.btnEmail.Enabled = True
                Me.btnCharges.Enabled = True

                Me.pnlDocuments.Controls.Clear()
                DocumentsControl = New UCDocumentsList(Enums.TableNames.tblOrder, CurrentOrder.OrderID)
                Me.pnlDocuments.Controls.Add(DocumentsControl)

                Combo.SetUpCombo(Me.cboPrintType, DynamicDataTables.SystemDocumentTypes(CurrentOrder.OrderTypeID), "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select)

                Populate()

                EnableTabs(True)
            End If

            SetupItemsIncludedDatagrid()

            IsLoading = False
        End Set
    End Property

    Private Function isOrderComplete() As Boolean
        Dim orderComplete As Boolean = True

        For Each row As DataRow In Me.ItemsIncludedDataView.Table.Rows
            If row.Item("QuantityOnOrder") > row.Item("QuantityReceived") Then
                orderComplete = False
            End If
        Next

        Return orderComplete
    End Function

    Private Function isOrderCancelled() As Boolean

        RefreshDataGrids()

        If ItemsIncludedDataView.Count > 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Private _passedID As Integer

    Public Property PassedID() As Integer
        Get
            Return _passedID
        End Get
        Set(ByVal Value As Integer)
            _passedID = Value
        End Set
    End Property

    Private _reason As String = ""

    Public Property Reason() As String
        Get
            Return _reason
        End Get
        Set(ByVal Value As String)
            _reason = Value
        End Set
    End Property

    Private _ItemsIncludedDataView As DataView = Nothing

    Public Property ItemsIncludedDataView() As DataView
        Get
            Return _ItemsIncludedDataView
        End Get
        Set(ByVal Value As DataView)
            _ItemsIncludedDataView = Value
            _ItemsIncludedDataView.Table.TableName = Enums.TableNames.tblOrder.ToString
            _ItemsIncludedDataView.AllowNew = False
            _ItemsIncludedDataView.AllowEdit = False
            _ItemsIncludedDataView.AllowDelete = False
            Me.dgItemsIncluded.DataSource = ItemsIncludedDataView

            PopulateOrderTotal()

            If ItemsIncludedDataView.Table.Rows.Count = 0 Then
                SupplierUsedID = 0
                LocationUsedID = 0
            End If
        End Set
    End Property

    Private ReadOnly Property SelectedItemIncludedDataRow() As DataRow
        Get
            If Not Me.dgItemsIncluded.CurrentRowIndex = -1 Then
                Return ItemsIncludedDataView(Me.dgItemsIncluded.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _ProductsDataView As DataView = Nothing

    Public Property ProductsDataView() As DataView
        Get
            Return _ProductsDataView
        End Get
        Set(ByVal Value As DataView)
            _ProductsDataView = Value
            _ProductsDataView.Table.TableName = Enums.TableNames.tblProduct.ToString
            _ProductsDataView.AllowNew = False
            _ProductsDataView.AllowEdit = False
            _ProductsDataView.AllowDelete = False
            Me.dgProduct.DataSource = ProductsDataView
        End Set
    End Property

    Private ReadOnly Property SelectedProductDataRow() As DataRow
        Get
            If Not Me.dgProduct.CurrentRowIndex = -1 Then
                Return ProductsDataView(Me.dgProduct.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _PriceRequestDataView As DataView = Nothing

    Public Property PriceRequestDataView() As DataView
        Get
            Return _PriceRequestDataView
        End Get
        Set(ByVal Value As DataView)
            _PriceRequestDataView = Value
            _PriceRequestDataView.Table.TableName = Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString
            _PriceRequestDataView.AllowNew = False
            _PriceRequestDataView.AllowEdit = False
            _PriceRequestDataView.AllowDelete = False
            Me.dgPriceRequests.DataSource = PriceRequestDataView

            Me.btnUpdatePartPriceRequest.Enabled = False
        End Set
    End Property

    Private ReadOnly Property SelectedPriceRequestDataRow() As DataRow
        Get
            If Not Me.dgPriceRequests.CurrentRowIndex = -1 Then
                Return PriceRequestDataView(Me.dgPriceRequests.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _PartsDataView As DataView = Nothing

    Public Property PartsDataView() As DataView
        Get
            Return _PartsDataView
        End Get
        Set(ByVal Value As DataView)
            _PartsDataView = Value
            _PartsDataView.Table.TableName = Enums.TableNames.tblPart.ToString
            _PartsDataView.AllowNew = False
            _PartsDataView.AllowEdit = False
            _PartsDataView.AllowDelete = False
            Me.dgParts.DataSource = PartsDataView
        End Set
    End Property

    Private ReadOnly Property SelectedPartDataRow() As DataRow
        Get
            If Not Me.dgParts.CurrentRowIndex = -1 Then
                Return PartsDataView(Me.dgParts.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    'This is to make sure we can only have one supplier per order
    Private _supplierUsedID As Integer

    Public Property SupplierUsedID() As Integer
        Get
            Return _supplierUsedID
        End Get
        Set(ByVal Value As Integer)
            _supplierUsedID = Value
        End Set
    End Property

    Private _locationUsedID As Integer

    Public Property LocationUsedID() As Integer
        Get
            Return _locationUsedID
        End Get
        Set(ByVal Value As Integer)
            _locationUsedID = Value
        End Set
    End Property

    Private _OrderNumberUsed As Boolean = False

    Public Property OrderNumberUsed() As Boolean
        Get
            Return _OrderNumberUsed
        End Get
        Set(ByVal Value As Boolean)
            _OrderNumberUsed = Value
        End Set
    End Property

    Private _OrderNumber As New JobNumber

    Public Property OrderNumber() As JobNumber
        Get
            Return _OrderNumber
        End Get
        Set(ByVal Value As JobNumber)
            _OrderNumber = Value

            If CurrentOrder.Exists = False Then

                OrderNumberUsed = False

                _OrderNumber.OrderNumber = OrderNumber.JobNumber

                While OrderNumber.OrderNumber.Length < 5
                    _OrderNumber.OrderNumber = "0" & OrderNumber.OrderNumber
                End While

                Dim typePrefix As String = ""

                Select Case CType(Combo.GetSelectedItemValue(cboOrderTypeID), Enums.OrderType)
                    Case Enums.OrderType.Customer
                        typePrefix = "W"
                    Case Enums.OrderType.StockProfile
                        typePrefix = "V"
                    Case Enums.OrderType.Warehouse
                        typePrefix = "W"
                    Case Enums.OrderType.Job
                        typePrefix = "V"
                End Select

                Dim userPrefix As String = ""
                Dim username() As String = loggedInUser.Fullname.Split(" ")
                For Each s As String In username
                    userPrefix += s.Substring(0, 1)
                Next

                _OrderNumber.OrderNumber = userPrefix & typePrefix & OrderNumber.OrderNumber
                Me.txtOrderReference.Text = OrderNumber.OrderNumber
            End If

        End Set
    End Property

    Private _customerID As Integer

    Public Property CustomerID As Integer
        Get
            Return _customerID
        End Get
        Set(value As Integer)
            _customerID = value
        End Set
    End Property

#End Region

#Region "Classes"

    Public Class ColourColumn : Inherits DataGridLabelColumn

        Protected Overloads Overrides Sub Paint(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal source As CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As Brush, ByVal foreBrush As Brush, ByVal alignToRight As Boolean)
            MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
            'set the color required dependant on the column value
            Dim brush As Brush

            brush = Brushes.White

            If Helper.MakeBooleanValid([source].List.Item(rowNum).row.item("Preferred")) Then
                brush = Brushes.LightGreen
            End If

            Me.TextBox.Text = ""
            'color the row cell
            Dim rect As Rectangle = bounds
            g.FillRectangle(brush, rect)
            g.DrawString("", Me.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom))

        End Sub

    End Class

#End Region

#Region "Setup"

    Private Sub SetupCredits()
        dgCredits.AutoGenerateColumns = False

        Dim CreditInvoiceDate As New DataGridViewTextBoxColumn
        CreditInvoiceDate.FillWeight = 75
        CreditInvoiceDate.HeaderText = "Credit Created"
        CreditInvoiceDate.DataPropertyName = "DateCreated"
        CreditInvoiceDate.SortMode = DataGridViewColumnSortMode.Automatic
        dgCredits.Columns.Add(CreditInvoiceDate)

        Dim CreditInvoiceID As New DataGridViewTextBoxColumn
        CreditInvoiceID.FillWeight = 75
        CreditInvoiceID.HeaderText = "Part Number"
        CreditInvoiceID.Name = "PartNumber"
        CreditInvoiceID.DataPropertyName = "PartNumber"
        CreditInvoiceID.SortMode = DataGridViewColumnSortMode.NotSortable
        dgCredits.Columns.Add(CreditInvoiceID)

        Dim CreditInvoiceAmount As New DataGridViewTextBoxColumn
        CreditInvoiceAmount.FillWeight = 150
        CreditInvoiceAmount.HeaderText = "Part Name"
        CreditInvoiceAmount.Name = "PartName"
        CreditInvoiceAmount.DataPropertyName = "PartName"
        CreditInvoiceAmount.SortMode = DataGridViewColumnSortMode.NotSortable
        '  CreditInvoiceAmount.DefaultCellStyle.Format = "c"
        dgCredits.Columns.Add(CreditInvoiceAmount)

        Dim CreditGoodsAmount As New DataGridViewTextBoxColumn
        CreditGoodsAmount.FillWeight = 30
        CreditGoodsAmount.HeaderText = "Qty"
        CreditGoodsAmount.Name = "Qty"
        CreditGoodsAmount.DataPropertyName = "Qty"
        CreditGoodsAmount.SortMode = DataGridViewColumnSortMode.NotSortable
        '  CreditGoodsAmount.DefaultCellStyle.Format = "c"
        dgCredits.Columns.Add(CreditGoodsAmount)

        Dim CreditVATAmount As New DataGridViewTextBoxColumn
        CreditVATAmount.FillWeight = 50
        CreditVATAmount.HeaderText = "Parts Buy Price"
        CreditVATAmount.DataPropertyName = "Total"
        CreditVATAmount.SortMode = DataGridViewColumnSortMode.NotSortable
        CreditVATAmount.DefaultCellStyle.Format = "c"
        dgCredits.Columns.Add(CreditVATAmount)

        Dim CreditInvoiceReference As New DataGridViewTextBoxColumn
        CreditInvoiceReference.FillWeight = 75
        CreditInvoiceReference.HeaderText = "Return Ref."
        CreditInvoiceReference.DataPropertyName = "ReturnRef"
        CreditInvoiceReference.SortMode = DataGridViewColumnSortMode.NotSortable
        dgCredits.Columns.Add(CreditInvoiceReference)

        Dim CreditInvoiceReference2 As New DataGridViewTextBoxColumn
        CreditInvoiceReference2.FillWeight = 75
        CreditInvoiceReference2.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"
        CreditInvoiceReference2.HeaderText = "Date Part Returned"
        CreditInvoiceReference2.Name = "DatePartReturned"
        CreditInvoiceReference2.DataPropertyName = "DatePartReturned"
        CreditInvoiceReference2.SortMode = DataGridViewColumnSortMode.NotSortable
        dgCredits.Columns.Add(CreditInvoiceReference2)

        Dim CreditInvoiceReference3 As New DataGridViewTextBoxColumn
        CreditInvoiceReference3.FillWeight = 150

        CreditInvoiceReference3.HeaderText = "Engineer Returning"
        CreditInvoiceReference3.DataPropertyName = "Engineer"
        CreditInvoiceReference3.SortMode = DataGridViewColumnSortMode.NotSortable
        dgCredits.Columns.Add(CreditInvoiceReference3)

        Dim CreditInvoiceReference4 As New DataGridViewTextBoxColumn
        CreditInvoiceReference4.FillWeight = 75

        CreditInvoiceReference4.HeaderText = "Supplier Credit Ref"
        CreditInvoiceReference4.DataPropertyName = "SupplierCreditRef"
        CreditInvoiceReference4.SortMode = DataGridViewColumnSortMode.NotSortable
        dgCredits.Columns.Add(CreditInvoiceReference4)

        Dim CreditInvoiceReference5 As New DataGridViewTextBoxColumn
        CreditInvoiceReference5.FillWeight = 75
        CreditInvoiceReference5.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"
        CreditInvoiceReference5.HeaderText = "Date Credit Recieved"
        CreditInvoiceReference5.DataPropertyName = "DateReceived"
        CreditInvoiceReference5.Name = "DateReceived"
        CreditInvoiceReference5.SortMode = DataGridViewColumnSortMode.NotSortable
        dgCredits.Columns.Add(CreditInvoiceReference5)

        Dim CreditAmount As New DataGridViewTextBoxColumn
        CreditAmount.FillWeight = 30
        CreditAmount.HeaderText = "Credit Total"
        '  CreditGoodsAmount.Name = "Qty"
        CreditAmount.DataPropertyName = "AmountReceived"
        CreditAmount.SortMode = DataGridViewColumnSortMode.NotSortable
        CreditAmount.DefaultCellStyle.Format = "c"
        dgCredits.Columns.Add(CreditAmount)

        Dim CreditPartsID As New DataGridViewTextBoxColumn
        CreditPartsID.FillWeight = 1
        CreditPartsID.HeaderText = ""
        CreditPartsID.Visible = True
        CreditPartsID.DataPropertyName = "PartCreditsID"
        CreditPartsID.Name = "PartCreditsID"
        CreditPartsID.SortMode = DataGridViewColumnSortMode.NotSortable
        '  CreditGoodsAmount.DefaultCellStyle.Format = "c"
        dgCredits.Columns.Add(CreditPartsID)

        Dim CreditPartsIDs As New DataGridViewTextBoxColumn
        CreditPartsIDs.FillWeight = 1
        CreditPartsIDs.HeaderText = ""
        CreditPartsIDs.Visible = True
        CreditPartsIDs.DataPropertyName = "PartID"
        CreditPartsIDs.Name = "PartID"
        CreditPartsIDs.SortMode = DataGridViewColumnSortMode.NotSortable
        '  CreditGoodsAmount.DefaultCellStyle.Format = "c"
        dgCredits.Columns.Add(CreditPartsIDs)

        Dim CreditPartsIDss As New DataGridViewTextBoxColumn
        CreditPartsIDss.FillWeight = 1
        CreditPartsIDss.HeaderText = ""
        CreditPartsIDss.Visible = True
        CreditPartsIDss.DataPropertyName = "OrderPartID"
        CreditPartsIDss.Name = "OrderPartID"
        CreditPartsIDss.SortMode = DataGridViewColumnSortMode.NotSortable
        '  CreditGoodsAmount.DefaultCellStyle.Format = "c"
        dgCredits.Columns.Add(CreditPartsIDss)

        Dim PartsToBeCreditedID As New DataGridViewTextBoxColumn
        PartsToBeCreditedID.FillWeight = 1
        PartsToBeCreditedID.HeaderText = ""
        PartsToBeCreditedID.Visible = True
        PartsToBeCreditedID.DataPropertyName = "PartsToBeCreditedID"
        PartsToBeCreditedID.Name = "PartsToBeCreditedID"
        PartsToBeCreditedID.SortMode = DataGridViewColumnSortMode.NotSortable
        '  CreditGoodsAmount.DefaultCellStyle.Format = "c"
        dgCredits.Columns.Add(PartsToBeCreditedID)

        Dim CreditPartsIDsss As New DataGridViewTextBoxColumn
        CreditPartsIDsss.FillWeight = 1
        CreditPartsIDsss.HeaderText = ""
        CreditPartsIDsss.Visible = True
        CreditPartsIDsss.DataPropertyName = "DateExportedToSage"
        CreditPartsIDsss.Name = "DateExportedToSage"
        CreditPartsIDsss.SortMode = DataGridViewColumnSortMode.NotSortable
        '  CreditGoodsAmount.DefaultCellStyle.Format = "c"
        dgCredits.Columns.Add(CreditPartsIDsss)

    End Sub

    Private Sub SetupSupplierInvoices()
        dgvReceivedInvoices.AutoGenerateColumns = False

        Dim SupplierInvoiceDate As New DataGridViewTextBoxColumn
        SupplierInvoiceDate.FillWeight = 200
        SupplierInvoiceDate.HeaderText = "Invoice Date"
        SupplierInvoiceDate.DataPropertyName = "SupplierInvoiceDate"
        SupplierInvoiceDate.SortMode = DataGridViewColumnSortMode.Automatic
        dgvReceivedInvoices.Columns.Add(SupplierInvoiceDate)

        Dim SupplierInvoiceReference As New DataGridViewTextBoxColumn
        SupplierInvoiceReference.FillWeight = 200
        SupplierInvoiceReference.HeaderText = "Supplier Invoice Ref."
        SupplierInvoiceReference.DataPropertyName = "SupplierInvoiceReference"
        SupplierInvoiceReference.SortMode = DataGridViewColumnSortMode.NotSortable
        dgvReceivedInvoices.Columns.Add(SupplierInvoiceReference)

        Dim SupplierGoodsAmount As New DataGridViewTextBoxColumn
        SupplierGoodsAmount.FillWeight = 200
        SupplierGoodsAmount.HeaderText = "Goods"
        SupplierGoodsAmount.Name = "SupplierInvoiceAmount"
        SupplierGoodsAmount.DataPropertyName = "SupplierInvoiceAmount"
        SupplierGoodsAmount.SortMode = DataGridViewColumnSortMode.NotSortable
        SupplierGoodsAmount.DefaultCellStyle.Format = "c"
        dgvReceivedInvoices.Columns.Add(SupplierGoodsAmount)

        Dim SupplierVATAmount As New DataGridViewTextBoxColumn
        SupplierVATAmount.FillWeight = 200
        SupplierVATAmount.HeaderText = "VAT"
        SupplierVATAmount.DataPropertyName = "SupplierVATAmount"
        SupplierVATAmount.SortMode = DataGridViewColumnSortMode.NotSortable
        SupplierVATAmount.DefaultCellStyle.Format = "c"
        dgvReceivedInvoices.Columns.Add(SupplierVATAmount)

        Dim SupplierInvoiceAmount As New DataGridViewTextBoxColumn
        SupplierInvoiceAmount.FillWeight = 200
        SupplierInvoiceAmount.HeaderText = "Total"
        SupplierInvoiceAmount.DataPropertyName = "SupplierGoodsAmount"
        SupplierInvoiceAmount.SortMode = DataGridViewColumnSortMode.NotSortable
        SupplierInvoiceAmount.DefaultCellStyle.Format = "c"
        dgvReceivedInvoices.Columns.Add(SupplierInvoiceAmount)

        Dim SupplierInvoiceID As New DataGridViewTextBoxColumn
        SupplierInvoiceID.FillWeight = 50
        SupplierInvoiceID.HeaderText = "Trans ID"
        SupplierInvoiceID.Name = "SupplierInvoiceID"
        SupplierInvoiceID.DataPropertyName = "SupplierInvoiceID"
        SupplierInvoiceID.SortMode = DataGridViewColumnSortMode.NotSortable
        dgvReceivedInvoices.Columns.Add(SupplierInvoiceID)
    End Sub

    Public Sub SetupItemsIncludedDatagrid()

        Helper.SetUpDataGrid(Me.dgItemsIncluded)
        Dim tStyle As DataGridTableStyle = Me.dgItemsIncluded.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim SupplierName As New DataGridLabelColumn
        SupplierName.Format = ""
        SupplierName.FormatInfo = Nothing
        SupplierName.HeaderText = "Supplier"
        SupplierName.MappingName = "SupplierName"
        SupplierName.ReadOnly = True
        SupplierName.Width = 100
        SupplierName.NullText = "N/A"
        tStyle.GridColumnStyles.Add(SupplierName)

        Dim WarehouseName As New DataGridLabelColumn
        WarehouseName.Format = ""
        WarehouseName.FormatInfo = Nothing
        WarehouseName.HeaderText = "Warehouse Name"
        WarehouseName.MappingName = "WarehouseName"
        WarehouseName.ReadOnly = True
        WarehouseName.Width = 100
        WarehouseName.NullText = "N/A"
        tStyle.GridColumnStyles.Add(WarehouseName)

        Dim VanReg As New DataGridLabelColumn
        VanReg.Format = ""
        VanReg.FormatInfo = Nothing
        VanReg.HeaderText = "Stock Profile Name"
        VanReg.MappingName = "Registration"
        VanReg.ReadOnly = True
        VanReg.Width = 100
        VanReg.NullText = "N/A"
        tStyle.GridColumnStyles.Add(VanReg)

        Dim ProductName As New DataGridLabelColumn
        ProductName.Format = ""
        ProductName.FormatInfo = Nothing
        ProductName.HeaderText = "Item Name"
        ProductName.MappingName = "Name"
        ProductName.ReadOnly = True
        ProductName.Width = 150
        ProductName.NullText = ""
        tStyle.GridColumnStyles.Add(ProductName)

        Dim ProductCode As New DataGridLabelColumn
        ProductCode.Format = ""
        ProductCode.FormatInfo = Nothing
        ProductCode.HeaderText = "Company Code (GPN)"
        ProductCode.MappingName = "Number"
        ProductCode.ReadOnly = True
        ProductCode.Width = 100
        ProductCode.NullText = ""
        tStyle.GridColumnStyles.Add(ProductCode)

        Dim SuppProductCode As New DataGridLabelColumn
        SuppProductCode.Format = ""
        SuppProductCode.FormatInfo = Nothing
        SuppProductCode.HeaderText = "Supplier Part Code (SPN)"
        SuppProductCode.MappingName = "SupplierPartCode"
        SuppProductCode.ReadOnly = True
        SuppProductCode.Width = 100
        SuppProductCode.NullText = ""
        tStyle.GridColumnStyles.Add(SuppProductCode)

        Dim BuyPrice As New DataGridLabelColumn
        BuyPrice.Format = "C"
        BuyPrice.FormatInfo = Nothing
        BuyPrice.HeaderText = "Cost"
        BuyPrice.MappingName = "BuyPrice"
        BuyPrice.ReadOnly = True
        BuyPrice.Width = 85
        BuyPrice.NullText = ""
        tStyle.GridColumnStyles.Add(BuyPrice)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Sell Price"
        Price.MappingName = "SellPrice"
        Price.ReadOnly = True
        Price.Width = 85
        Price.NullText = ""
        tStyle.GridColumnStyles.Add(Price)

        Dim QuantityInPack As New DataGridLabelColumn
        QuantityInPack.Format = ""
        QuantityInPack.FormatInfo = Nothing
        QuantityInPack.HeaderText = "Qty In Pack"
        QuantityInPack.MappingName = "QuantityInPack"
        QuantityInPack.ReadOnly = True
        QuantityInPack.Width = 100
        QuantityInPack.NullText = ""
        tStyle.GridColumnStyles.Add(QuantityInPack)

        Dim QuantityOnOrder As New DataGridLabelColumn
        QuantityOnOrder.Format = ""
        QuantityOnOrder.FormatInfo = Nothing
        QuantityOnOrder.HeaderText = "Qty To Order"
        QuantityOnOrder.MappingName = "QuantityOnOrder"
        QuantityOnOrder.ReadOnly = True
        QuantityOnOrder.Width = 100
        QuantityOnOrder.NullText = ""
        tStyle.GridColumnStyles.Add(QuantityOnOrder)

        Dim QuantityReceived As New DataGridLabelColumn
        QuantityReceived.Format = ""
        QuantityReceived.FormatInfo = Nothing
        QuantityReceived.HeaderText = "Qty Received"
        QuantityReceived.MappingName = "QuantityReceived"
        QuantityReceived.ReadOnly = True
        QuantityReceived.Width = 100
        QuantityReceived.NullText = ""
        tStyle.GridColumnStyles.Add(QuantityReceived)

        If Not CurrentOrder Is Nothing Then
            If CurrentOrder.Exists Then

                Dim WithVan As New DataGridLabelColumn
                WithVan.Format = "dd/MM/yyyy HH:mm:ss"
                WithVan.FormatInfo = Nothing
                WithVan.HeaderText = "Date Engineer Picked up"
                WithVan.MappingName = "WithEngineer_Van"
                WithVan.ReadOnly = True
                WithVan.Width = 110
                WithVan.NullText = ""
                tStyle.GridColumnStyles.Add(WithVan)

                Dim WithEngineer As New DataGridLabelColumn
                WithEngineer.Format = "dd/MM/yyyy HH:mm:ss"
                WithEngineer.FormatInfo = Nothing
                WithEngineer.HeaderText = "Date Engineer Distributed"
                WithEngineer.MappingName = "WithEngineer_Job"
                WithEngineer.ReadOnly = True
                WithEngineer.Width = 110
                WithEngineer.NullText = ""
                tStyle.GridColumnStyles.Add(WithEngineer)

            End If
        End If

        tStyle.ReadOnly = True
        tStyle.MappingName = Enums.TableNames.tblOrder.ToString
        Me.dgItemsIncluded.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupPartsDatagrid()

        Helper.SetUpDataGrid(Me.dgParts)
        Dim tStyle As DataGridTableStyle = Me.dgParts.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Preferred As New ColourColumn
        Preferred.Format = ""
        Preferred.FormatInfo = Nothing
        Preferred.HeaderText = "Preferred"
        Preferred.MappingName = "Preferred"
        Preferred.ReadOnly = True
        Preferred.Width = 25
        Preferred.NullText = ""
        tStyle.GridColumnStyles.Add(Preferred)

        Dim SupplierName As New DataGridLabelColumn
        SupplierName.Format = ""
        SupplierName.FormatInfo = Nothing
        SupplierName.HeaderText = "Supplier"
        SupplierName.MappingName = "SupplierName"
        SupplierName.ReadOnly = True
        SupplierName.Width = 100
        SupplierName.NullText = "No Supplier Assigned"
        tStyle.GridColumnStyles.Add(SupplierName)

        Dim EngineerName As New DataGridLabelColumn
        EngineerName.Format = ""
        EngineerName.FormatInfo = Nothing
        EngineerName.HeaderText = "Engineer Name"
        EngineerName.MappingName = "EngineerName"
        EngineerName.ReadOnly = True
        EngineerName.Width = 100
        EngineerName.NullText = ""
        tStyle.GridColumnStyles.Add(EngineerName)

        Dim VanRegistration As New DataGridLabelColumn
        VanRegistration.Format = ""
        VanRegistration.FormatInfo = Nothing
        VanRegistration.HeaderText = "Stock Profile Name"
        VanRegistration.MappingName = "Registration"
        VanRegistration.ReadOnly = True
        VanRegistration.Width = 130
        VanRegistration.NullText = ""
        tStyle.GridColumnStyles.Add(VanRegistration)

        Dim warehouseName As New DataGridLabelColumn
        warehouseName.Format = ""
        warehouseName.FormatInfo = Nothing
        warehouseName.HeaderText = "Warehouse Name"
        warehouseName.MappingName = "warehouseName"
        warehouseName.ReadOnly = True
        warehouseName.Width = 120
        warehouseName.NullText = ""
        tStyle.GridColumnStyles.Add(warehouseName)

        Dim address1 As New DataGridLabelColumn
        address1.Format = ""
        address1.FormatInfo = Nothing
        address1.HeaderText = "Address 1"
        address1.MappingName = "address1"
        address1.ReadOnly = True
        address1.Width = 120
        address1.NullText = ""
        tStyle.GridColumnStyles.Add(address1)

        Dim postcode As New DataGridLabelColumn
        postcode.Format = ""
        postcode.FormatInfo = Nothing
        postcode.HeaderText = "Postcode"
        postcode.MappingName = "postcode"
        postcode.ReadOnly = True
        postcode.Width = 120
        postcode.NullText = ""
        tStyle.GridColumnStyles.Add(postcode)

        Dim PartName As New DataGridLabelColumn
        PartName.Format = ""
        PartName.FormatInfo = Nothing
        PartName.HeaderText = "Part Name"
        PartName.MappingName = "PartName"
        PartName.ReadOnly = True
        PartName.Width = 250
        PartName.NullText = ""
        tStyle.GridColumnStyles.Add(PartName)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Cost"
        Price.MappingName = "Price"
        Price.ReadOnly = True
        Price.Width = 85
        Price.NullText = "£0.00"
        tStyle.GridColumnStyles.Add(Price)

        Dim PartNumber As New DataGridLabelColumn
        PartNumber.Format = ""
        PartNumber.FormatInfo = Nothing
        PartNumber.HeaderText = "Company Code"
        PartNumber.MappingName = "PartNumber"
        PartNumber.ReadOnly = True
        PartNumber.Width = 100
        PartNumber.NullText = ""
        tStyle.GridColumnStyles.Add(PartNumber)

        Dim PartCode As New DataGridLabelColumn
        PartCode.Format = ""
        PartCode.FormatInfo = Nothing
        PartCode.HeaderText = "Supplier Code"
        PartCode.MappingName = "PartCode"
        PartCode.ReadOnly = True
        PartCode.Width = 130
        PartCode.NullText = ""
        tStyle.GridColumnStyles.Add(PartCode)

        Dim QuantityInPack As New DataGridLabelColumn
        QuantityInPack.Format = ""
        QuantityInPack.FormatInfo = Nothing
        QuantityInPack.HeaderText = "Qty In Pack"
        QuantityInPack.MappingName = "QuantityInPack"
        QuantityInPack.ReadOnly = True
        QuantityInPack.Width = 120
        QuantityInPack.NullText = ""
        tStyle.GridColumnStyles.Add(QuantityInPack)

        Dim PartReference As New DataGridLabelColumn
        PartReference.Format = ""
        PartReference.FormatInfo = Nothing
        PartReference.HeaderText = "Part Ref"
        PartReference.MappingName = "Reference"
        PartReference.ReadOnly = True
        PartReference.Width = 100
        PartReference.NullText = ""
        tStyle.GridColumnStyles.Add(PartReference)

        Dim SellPrice As New DataGridLabelColumn
        SellPrice.Format = "C"
        SellPrice.FormatInfo = Nothing
        SellPrice.HeaderText = "Sell Price"
        SellPrice.MappingName = "SellPrice"
        SellPrice.ReadOnly = True
        SellPrice.Width = 85
        SellPrice.NullText = ""
        tStyle.GridColumnStyles.Add(SellPrice)

        Dim Amount As New DataGridLabelColumn
        Amount.Format = ""
        Amount.FormatInfo = Nothing
        Amount.HeaderText = "Amount"
        Amount.MappingName = "Amount"
        Amount.ReadOnly = True
        Amount.Width = 85
        Amount.NullText = ""
        tStyle.GridColumnStyles.Add(Amount)

        tStyle.ReadOnly = True
        tStyle.MappingName = Enums.TableNames.tblPart.ToString
        Me.dgParts.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupProductsDatagrid()

        Helper.SetUpDataGrid(Me.dgProduct)
        Dim tStyle As DataGridTableStyle = Me.dgProduct.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim warehouseName As New DataGridLabelColumn
        warehouseName.Format = ""
        warehouseName.FormatInfo = Nothing
        warehouseName.HeaderText = "Warehouse Name"
        warehouseName.MappingName = "warehouseName"
        warehouseName.ReadOnly = True
        warehouseName.Width = 120
        warehouseName.NullText = ""
        tStyle.GridColumnStyles.Add(warehouseName)

        Dim address1 As New DataGridLabelColumn
        address1.Format = ""
        address1.FormatInfo = Nothing
        address1.HeaderText = "Address 1"
        address1.MappingName = "address1"
        address1.ReadOnly = True
        address1.Width = 120
        address1.NullText = ""
        tStyle.GridColumnStyles.Add(address1)

        Dim postcode As New DataGridLabelColumn
        postcode.Format = ""
        postcode.FormatInfo = Nothing
        postcode.HeaderText = "Postcode"
        postcode.MappingName = "postcode"
        postcode.ReadOnly = True
        postcode.Width = 120
        postcode.NullText = ""
        tStyle.GridColumnStyles.Add(postcode)

        Dim SupplierName As New DataGridLabelColumn
        SupplierName.Format = ""
        SupplierName.FormatInfo = Nothing
        SupplierName.HeaderText = "Supplier"
        SupplierName.MappingName = "SupplierName"
        SupplierName.ReadOnly = True
        SupplierName.Width = 100
        SupplierName.NullText = "No Supplier Assigned"
        tStyle.GridColumnStyles.Add(SupplierName)

        Dim EngineerName As New DataGridLabelColumn
        EngineerName.Format = ""
        EngineerName.FormatInfo = Nothing
        EngineerName.HeaderText = "Engineer Name"
        EngineerName.MappingName = "EngineerName"
        EngineerName.ReadOnly = True
        EngineerName.Width = 100
        EngineerName.NullText = ""
        tStyle.GridColumnStyles.Add(EngineerName)

        Dim VanRegistration As New DataGridLabelColumn
        VanRegistration.Format = ""
        VanRegistration.FormatInfo = Nothing
        VanRegistration.HeaderText = "Stock Profile Name"
        VanRegistration.MappingName = "Registration"
        VanRegistration.ReadOnly = True
        VanRegistration.Width = 130
        VanRegistration.NullText = ""
        tStyle.GridColumnStyles.Add(VanRegistration)

        Dim ProductName As New DataGridLabelColumn
        ProductName.Format = ""
        ProductName.FormatInfo = Nothing
        ProductName.HeaderText = "Description"
        ProductName.MappingName = "typemakemodel"
        ProductName.ReadOnly = True
        ProductName.Width = 100
        ProductName.NullText = ""
        tStyle.GridColumnStyles.Add(ProductName)

        Dim ProductCode As New DataGridLabelColumn
        ProductCode.Format = ""
        ProductCode.FormatInfo = Nothing
        ProductCode.HeaderText = "Supplier Product Code"
        ProductCode.MappingName = "ProductCode"
        ProductCode.ReadOnly = True
        ProductCode.Width = 130
        ProductCode.NullText = ""
        tStyle.GridColumnStyles.Add(ProductCode)

        Dim ProductNumber As New DataGridLabelColumn
        ProductNumber.Format = ""
        ProductNumber.FormatInfo = Nothing
        ProductNumber.HeaderText = "Product Code"
        ProductNumber.MappingName = "ProductNumber"
        ProductNumber.ReadOnly = True
        ProductNumber.Width = 100
        ProductNumber.NullText = ""
        tStyle.GridColumnStyles.Add(ProductNumber)

        Dim ProductReference As New DataGridLabelColumn
        ProductReference.Format = ""
        ProductReference.FormatInfo = Nothing
        ProductReference.HeaderText = "Product Reference"
        ProductReference.MappingName = "Reference"
        ProductReference.ReadOnly = True
        ProductReference.Width = 120
        ProductReference.NullText = ""
        tStyle.GridColumnStyles.Add(ProductReference)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Cost"
        Price.MappingName = "Price"
        Price.ReadOnly = True
        Price.Width = 85
        Price.NullText = ""
        tStyle.GridColumnStyles.Add(Price)

        Dim SellPrice As New DataGridLabelColumn
        SellPrice.Format = "C"
        SellPrice.FormatInfo = Nothing
        SellPrice.HeaderText = "Sell Price"
        SellPrice.MappingName = "SellPrice"
        SellPrice.ReadOnly = True
        SellPrice.Width = 85
        SellPrice.NullText = ""
        tStyle.GridColumnStyles.Add(SellPrice)

        Dim QuantityInPack As New DataGridLabelColumn
        QuantityInPack.Format = ""
        QuantityInPack.FormatInfo = Nothing
        QuantityInPack.HeaderText = "Quantity In Pack"
        QuantityInPack.MappingName = "QuantityInPack"
        QuantityInPack.ReadOnly = True
        QuantityInPack.Width = 120
        QuantityInPack.NullText = ""
        tStyle.GridColumnStyles.Add(QuantityInPack)

        Dim Amount As New DataGridLabelColumn
        Amount.Format = ""
        Amount.FormatInfo = Nothing
        Amount.HeaderText = "Amount"
        Amount.MappingName = "Amount"
        Amount.ReadOnly = True
        Amount.Width = 85
        Amount.NullText = ""
        tStyle.GridColumnStyles.Add(Amount)

        tStyle.ReadOnly = True
        tStyle.MappingName = Enums.TableNames.tblProduct.ToString
        Me.dgProduct.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupPriceRequestDatagrid()
        Helper.SetUpDataGrid(Me.dgPriceRequests)
        Dim tStyle As DataGridTableStyle = Me.dgPriceRequests.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 75
        Type.NullText = ""
        tStyle.GridColumnStyles.Add(Type)

        Dim SupplierName As New DataGridLabelColumn
        SupplierName.Format = ""
        SupplierName.FormatInfo = Nothing
        SupplierName.HeaderText = "Supplier"
        SupplierName.MappingName = "SupplierName"
        SupplierName.ReadOnly = True
        SupplierName.Width = 150
        SupplierName.NullText = ""
        tStyle.GridColumnStyles.Add(SupplierName)

        Dim Postcode As New DataGridLabelColumn
        Postcode.Format = ""
        Postcode.FormatInfo = Nothing
        Postcode.HeaderText = "Postcode"
        Postcode.MappingName = "Postcode"
        Postcode.ReadOnly = True
        Postcode.Width = 150
        Postcode.NullText = ""
        tStyle.GridColumnStyles.Add(Postcode)

        Dim TelephoneNum As New DataGridLabelColumn
        TelephoneNum.Format = ""
        TelephoneNum.FormatInfo = Nothing
        TelephoneNum.HeaderText = "Telephone"
        TelephoneNum.MappingName = "TelephoneNum"
        TelephoneNum.ReadOnly = True
        TelephoneNum.Width = 150
        TelephoneNum.NullText = ""
        tStyle.GridColumnStyles.Add(TelephoneNum)

        Dim partName As New DataGridLabelColumn
        partName.Format = ""
        partName.FormatInfo = Nothing
        partName.HeaderText = "Part"
        partName.MappingName = "Part"
        partName.ReadOnly = True
        partName.Width = 150
        partName.NullText = ""
        tStyle.GridColumnStyles.Add(partName)

        Dim ProductName As New DataGridLabelColumn
        ProductName.Format = ""
        ProductName.FormatInfo = Nothing
        ProductName.HeaderText = "Product"
        ProductName.MappingName = "Product"
        ProductName.ReadOnly = True
        ProductName.Width = 150
        ProductName.NullText = ""
        tStyle.GridColumnStyles.Add(ProductName)

        Dim Amount As New DataGridLabelColumn
        Amount.Format = ""
        Amount.FormatInfo = Nothing
        Amount.HeaderText = "Quantity"
        Amount.MappingName = "QuantityInPack"
        Amount.ReadOnly = True
        Amount.Width = 110
        Amount.NullText = ""
        tStyle.GridColumnStyles.Add(Amount)

        tStyle.ReadOnly = True
        tStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString
        Me.dgPriceRequests.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub txtGoodsAmount_TextChanged(sender As System.Object, e As EventArgs) Handles txtGoodsAmount.LostFocus
        If Not txtGoodsAmount.Text = Nothing Then
            Try
                Calculate_Tax()
                txtGoodsAmount.Text = FormatCurrency(txtGoodsAmount.Text)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txtVATAmount_LostFocus(sender As Object, e As EventArgs) Handles txtVATAmount.LostFocus
        If Not txtGoodsAmount.Text = Nothing And Not txtVATAmount.Text = Nothing Then
            txtVATAmount.Text = FormatCurrency(txtVATAmount.Text)
            Me.txtTotalAmount.Text = FormatCurrency(CDbl(Replace(txtGoodsAmount.Text, "£", "")) + CDbl(Replace(txtVATAmount.Text, "£", "")))
        End If
    End Sub

    Private Sub txtCreditAmount_TextChanged(sender As System.Object, e As EventArgs) Handles txtCreditGoods.LostFocus
        If Not txtCreditGoods.Text = Nothing Then
            Try
                Calculate_Tax2()
                txtCreditGoods.Text = FormatCurrency(txtCreditGoods.Text)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txtCreditVAT__LostFocus(sender As Object, e As EventArgs) Handles txtCreditVAT.LostFocus
        If Not txtCreditGoods.Text = Nothing And Not txtCreditVAT.Text = Nothing Then
            txtCreditVAT.Text = FormatCurrency(txtCreditVAT.Text)
            Me.txtCreditTotal.Text = FormatCurrency(CDbl(Replace(txtCreditGoods.Text, "£", "")) + CDbl(Replace(txtCreditVAT.Text, "£", "")))
        End If
    End Sub

    Private Sub btnReceiveAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReceiveAll.Click

        If CurrentOrder.OrderConsolidationID > 0 Then
            If CStr(SelectedItemIncludedDataRow.Item("Type")) = "OrderPart" Or CStr(SelectedItemIncludedDataRow.Item("Type")) = "OrderProduct" Then
                ShowMessage("This order has been added to a consolidation so should be managed from there.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If
        If Not CurrentOrder.OrderStatusID = CInt(Enums.OrderStatus.Confirmed) Then
            ShowMessage("Order must be confirmed to mark items into stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        For Each itemRow As DataRow In ItemsIncludedDataView.Table.Rows

            If Not CInt(itemRow.Item("QuantityOnOrder")) = CInt(itemRow.Item("QuantityReceived")) Then

                Dim quantityInput As Integer = (CInt(itemRow.Item("QuantityOnOrder")) - CInt(itemRow.Item("QuantityReceived")))

                Select Case CStr(itemRow.Item("Type"))
                    Case "OrderProduct"

                        Dim OrderProduct As New Entity.OrderProducts.OrderProduct
                        Dim oProduct As New Entity.Products.Product

                        OrderProduct = DB.OrderProduct.OrderProduct_Get(CInt(itemRow("ID")))
                        Dim oProductSupplier As Entity.ProductSuppliers.ProductSupplier = DB.ProductSupplier.ProductSupplier_Get(OrderProduct.ProductSupplierID)
                        oProduct = DB.Product.Product_Get(oProductSupplier.ProductID)

                        OrderProduct.SetQuantityReceived = OrderProduct.QuantityReceived + quantityInput
                        DB.OrderProduct.Update(OrderProduct)

                        Select Case CurrentOrder.OrderTypeID
                            Case CInt(Enums.OrderType.Customer)
                                'DO NOTHING
                            Case CInt(Enums.OrderType.Job)
                                'DO NOTHING
                            Case CInt(Enums.OrderType.StockProfile)
                                'DO NOTHING - THIS WILL BE DONE ON THE PDA
                            Case CInt(Enums.OrderType.Warehouse)
                                Dim oOrderLocation As Entity.OrderLocations.OrderLocation = DB.OrderLocation.OrderLocation_GetForOrder(OrderProduct.OrderID)

                                Dim oProductTransaction As New Entity.ProductTransactions.ProductTransaction
                                oProductTransaction.SetLocationID = oOrderLocation.LocationID
                                oProductTransaction.SetProductID = oProductSupplier.ProductID
                                oProductTransaction.SetOrderProductID = OrderProduct.OrderProductID
                                oProductTransaction.SetAmount = quantityInput * oProductSupplier.QuantityInPack
                                oProductTransaction.SetTransactionTypeID = CInt(Enums.Transaction.StockIn)
                                DB.ProductTransaction.Insert(oProductTransaction)
                        End Select
                    Case "OrderPart"

                        Dim OrderPart As New Entity.OrderParts.OrderPart
                        OrderPart = DB.OrderPart.OrderPart_Get(CInt(itemRow("ID")))

                        OrderPart.SetQuantityReceived = OrderPart.QuantityReceived + quantityInput
                        DB.OrderPart.Update(OrderPart)

                        Select Case CurrentOrder.OrderTypeID
                            Case CInt(Enums.OrderType.Customer)
                                'DO NOTHING
                            Case CInt(Enums.OrderType.Job)
                                'DO NOTHING
                            Case CInt(Enums.OrderType.StockProfile)
                                'DO NOTHING - THIS WILL BE DONE ON THE PDA
                            Case CInt(Enums.OrderType.Warehouse)
                                Dim oOrderLocation As Entity.OrderLocations.OrderLocation = DB.OrderLocation.OrderLocation_GetForOrder(OrderPart.OrderID)
                                Dim oPartSupplier As Entity.PartSuppliers.PartSupplier = DB.PartSupplier.PartSupplier_Get(OrderPart.PartSupplierID)

                                Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                                oPartTransaction.SetLocationID = oOrderLocation.LocationID
                                oPartTransaction.SetPartID = oPartSupplier.PartID
                                oPartTransaction.SetOrderPartID = OrderPart.OrderPartID
                                oPartTransaction.SetAmount = quantityInput * oPartSupplier.QuantityInPack
                                oPartTransaction.SetTransactionTypeID = CInt(Enums.Transaction.StockIn)
                                DB.PartTransaction.Insert(oPartTransaction)
                        End Select
                    Case "OrderLocationProduct"
                        Dim OrderLocationProduct As Entity.OrderLocationProduct.OrderLocationProduct = DB.OrderLocationProduct.OrderLocationProduct_Get(CInt(itemRow("ID")))
                        Dim oProductTransaction As Entity.ProductTransactions.ProductTransaction = DB.ProductTransaction.ProductTransaction_GetByOrderLocationProduct(OrderLocationProduct.OrderLocationProductID)

                        oProductTransaction.SetAmount = oProductTransaction.Amount + quantityInput
                        DB.ProductTransaction.Update(oProductTransaction)

                        oProductTransaction.SetLocationID = OrderLocationProduct.LocationID
                        oProductTransaction.SetProductID = OrderLocationProduct.ProductID
                        oProductTransaction.SetOrderLocationProductID = OrderLocationProduct.OrderLocationProductID
                        oProductTransaction.SetTransactionTypeID = CInt(Enums.Transaction.StockOut)
                        oProductTransaction.SetAmount = -quantityInput
                        DB.ProductTransaction.Insert(oProductTransaction)

                        OrderLocationProduct.SetQuantityReceived = OrderLocationProduct.QuantityReceived + quantityInput
                        DB.OrderLocationProduct.Update(OrderLocationProduct)

                        Select Case CurrentOrder.OrderTypeID
                            Case CInt(Enums.OrderType.Customer)
                                'DO NOTHING
                            Case CInt(Enums.OrderType.Job)
                                'DO NOTHING
                            Case CInt(Enums.OrderType.StockProfile)
                                'DO NOTHING - THIS WILL BE DONE ON THE PDA
                            Case CInt(Enums.OrderType.Warehouse)
                                Dim oOrderLocation As Entity.OrderLocations.OrderLocation
                                oOrderLocation = DB.OrderLocation.OrderLocation_GetForOrder(OrderLocationProduct.OrderID)
                                oProductTransaction.SetLocationID = oOrderLocation.LocationID
                                oProductTransaction.SetTransactionTypeID = CInt(Enums.Transaction.StockIn)
                                oProductTransaction.SetOrderLocationProductID = OrderLocationProduct.OrderLocationProductID
                                oProductTransaction.SetAmount = quantityInput
                                oProductTransaction.SetProductID = OrderLocationProduct.ProductID
                                DB.ProductTransaction.Insert(oProductTransaction)
                        End Select

                    Case "OrderLocationPart"
                        Dim OrderLocationPart As Entity.OrderLocationPart.OrderLocationPart = DB.OrderLocationPart.OrderLocationPart_Get(CInt(itemRow("ID")))
                        Dim oPartTransaction As Entity.PartTransactions.PartTransaction = DB.PartTransaction.PartTransaction_GetByOrderLocationPart(OrderLocationPart.OrderLocationPartID)

                        oPartTransaction.SetAmount = oPartTransaction.Amount + quantityInput
                        DB.PartTransaction.Update(oPartTransaction)

                        oPartTransaction.SetLocationID = OrderLocationPart.LocationID
                        oPartTransaction.SetPartID = OrderLocationPart.PartID
                        oPartTransaction.SetOrderLocationPartID = OrderLocationPart.OrderLocationPartID
                        oPartTransaction.SetTransactionTypeID = CInt(Enums.Transaction.StockOut)
                        oPartTransaction.SetAmount = -quantityInput
                        DB.PartTransaction.Insert(oPartTransaction)

                        OrderLocationPart.SetQuantityReceived = OrderLocationPart.QuantityReceived + quantityInput
                        DB.OrderLocationPart.Update(OrderLocationPart)

                        Select Case CurrentOrder.OrderTypeID
                            Case CInt(Enums.OrderType.Customer)
                                'DO NOTHING
                            Case CInt(Enums.OrderType.Job)
                                'DO NOTHING
                            Case CInt(Enums.OrderType.StockProfile)
                                'DO NOTHING - THIS WILL BE DONE ON THE PDA
                            Case CInt(Enums.OrderType.Warehouse)
                                Dim oOrderLocation As Entity.OrderLocations.OrderLocation
                                oOrderLocation = DB.OrderLocation.OrderLocation_GetForOrder(OrderLocationPart.OrderID)
                                oPartTransaction.SetLocationID = oOrderLocation.LocationID
                                oPartTransaction.SetTransactionTypeID = CInt(Enums.Transaction.StockIn)
                                oPartTransaction.SetOrderLocationPartID = OrderLocationPart.OrderLocationPartID
                                oPartTransaction.SetAmount = quantityInput
                                oPartTransaction.SetPartID = OrderLocationPart.PartID
                                DB.PartTransaction.Insert(oPartTransaction)
                        End Select
                End Select

            End If
        Next

        Populate(CurrentOrder.OrderID)

        If isOrderComplete() = True Then
            CurrentOrder.SetOrderStatusID = CInt(Enums.OrderStatus.Complete)

            DB.Order.Update(CurrentOrder)
            IsLoading = True
            Populate(CurrentOrder.OrderID)
            IsLoading = False

            If CurrentOrder.OrderTypeID = CInt(Enums.OrderType.Job) Then
                Dim oEngineerVisit As Entity.EngineerVisits.EngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(ucJobOrder.SelectedEngineerVisitDataRow.Item("EngineerVisitID"))
                If oEngineerVisit.StatusEnumID = CInt(Enums.VisitStatus.Waiting_For_Parts) Then

                    'LETS SEE FIRST IF ALL THE ORDERS RELATING TO THIS VISIT ARE COMPLETE? - ALP 22/01/08
                    Dim dv As DataView = DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(oEngineerVisit.EngineerVisitID)
                    Dim allComplete As Boolean = True
                    For Each dr As DataRow In dv.Table.Rows
                        If Not Helper.MakeIntegerValid(dr("OrderStatusID")) = 0 Then
                            If Not (dr("OrderStatusID") = CInt(Enums.OrderStatus.Complete)) Then
                                allComplete = False
                            End If
                        End If
                    Next
                    If allComplete Then
                        ShowForm(GetType(FRMPickDespatchDetails), True, New Object() {oEngineerVisit})
                    End If

                End If
            End If

            'IF ORDER IS COMPLETE AND ITS A CUSTOMER ORDER THEN ADD ROW TO RAISE INVOICE TABLE
            If CType(CurrentOrder.OrderTypeID, Entity.Sys.Enums.OrderType) = Entity.Sys.Enums.OrderType.Customer Then
                ShowForm(GetType(FrmRaiseInvoiceDetails), True, New Object() {CurrentOrder.OrderID, CurrentOrder.InvoiceAddressID})
            End If

        End If

    End Sub

    Private Sub btnRelatedJob_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnRelatedJob.Click
        Dim oJob As Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(PassedID)
        ShowForm(GetType(FRMLogCallout), True, New Object() {oJob.JobID, oJob.PropertyID, Me, Nothing, PassedID})
    End Sub

    Private Sub UCOrder_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If Me.tcOrderDetails.SelectedIndex = 1 Then 'parts
            If e.KeyCode = Keys.Enter Then
                PartSearch()
            End If
        ElseIf Me.tcOrderDetails.SelectedIndex = 2 Then 'products
            If e.KeyCode = Keys.Enter Then
                ProductSearch()
            End If
        Else

        End If

    End Sub

    Private Sub UCOrder_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
        Dim ssm3 As Enums.SecuritySystemModules
        ssm3 = Enums.SecuritySystemModules.POUnlock
        If loggedInUser.HasAccessToModule(ssm3) = True Then
            chkRevertStatus.Visible = True
        End If
    End Sub

    Private Sub cboOrderTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboOrderTypeID.SelectedIndexChanged
        If Me.pnlDetails.Controls.Count > 0 Then
            Me.pnlDetails.Controls.Clear()
        End If

        Select Case Combo.GetSelectedItemValue(Me.cboOrderTypeID)
            Case Enums.OrderType.Customer
                Me.pnlDetails.Controls.Add(ucCustomerOrder)
            Case Enums.OrderType.Job
                Me.pnlDetails.Controls.Add(ucJobOrder)
            Case Enums.OrderType.Warehouse
                Me.pnlDetails.Controls.Add(ucWarehouseOrder)
            Case Enums.OrderType.StockProfile
                If _currentOrder.Exists Then
                    Me.pnlDetails.Controls.Add(ucVanOrder)
                Else
                    'ShowMessage("Van Orders Have been suspended.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'Combo.SetSelectedComboItem_By_Value(Me.cboOrderTypeID, 0)
                    'Exit Sub
                    Me.pnlDetails.Controls.Add(ucVanOrder)
                End If

            Case Else
                If CurrentOrder Is Nothing Then
                    Me.lblOrderStatus.Text = "SAVE BASE ORDER DETAILS BEFORE MANAGING ITEMS"
                Else
                    If CurrentOrder.Exists Then
                        Me.lblOrderStatus.Text = "PICK WHAT THE ORDER IS FOR"
                    Else
                        Me.lblOrderStatus.Text = "SAVE BASE ORDER DETAILS BEFORE MANAGING ITEMS"
                    End If
                End If
                Me.lblOrderStatus.Visible = True
                Exit Sub
        End Select

        OrderNumber = OrderNumber

        Select Case CurrentOrder.OrderStatusID
            Case Enums.OrderStatus.Confirmed, Enums.OrderStatus.AwaitingApproval
                DisableFields()
                btnCharges.Enabled = True
                Me.lblOrderStatus.Text = "ORDER WAITING FOR ITEMS RECEIVED"
                Me.lblOrderStatus.Visible = True
            Case Enums.OrderStatus.Cancelled
                DisableFields()
                btnCharges.Enabled = False
                Me.lblOrderStatus.Text = "ORDER HAS BEEN CANCELLED (click to view)"
                Me.lblOrderStatus.Visible = True
            Case Enums.OrderStatus.Complete
                DisableFields()
                btnCharges.Enabled = False
                Me.lblOrderStatus.Text = "ORDER COMPLETE"
                Me.lblOrderStatus.Visible = True

                If CurrentOrder.ExportedToSage Then
                    Me.lblOrderStatus.Text += " - (Invoiced and Sent to Sage)"
                Else
                    If CurrentOrder.Invoiced Then
                        Me.lblOrderStatus.Text += " - (Invoiced)"
                    End If
                End If
            Case Enums.OrderStatus.AwaitingConfirmation
                Me.lblOrderStatus.Text = "ORDER AWAITING CONFIRMATION FROM CUSTOMER"
                Me.lblOrderStatus.Visible = True
            Case Else
                Me.lblOrderStatus.Text = ""
                Me.lblOrderStatus.Visible = False
        End Select

        If CurrentOrder.SentToSage Then
            Me.lblOrderStatus.Text += " *Supplier Invoice(s) sent to Sage*"
        Else
            Me.lblOrderStatus.Text += " *Supplier Invoice NOT sent to Sage*"
        End If
    End Sub

    Private Sub tcOrderDetails_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles tcOrderDetails.SelectedIndexChanged
        If IsLoading = False Then
            If Not tcOrderDetails.SelectedTab.Name = "tabDetails" Then
                If Combo.GetSelectedItemValue(Me.cboOrderTypeID) = 0 Then
                    ShowMessage("You must select an Order Type to continue.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    tcOrderDetails.SelectedTab = Me.tabDetails
                End If
            End If
        End If
    End Sub

    Private Sub chkDeadlineNA_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkDeadlineNA.CheckedChanged
        If Me.chkDeadlineNA.Checked Then
            Me.dtpDeliveryDeadline.Enabled = False
        Else
            Me.dtpDeliveryDeadline.Enabled = True
        End If
    End Sub

    Private Sub cboOrderStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboOrderStatus.SelectedIndexChanged
        Dim RemoveConsolidation As Boolean = False

        If IsLoading = False Then
            If Not Combo.GetSelectedItemValue(cboOrderStatus) = Enums.OrderStatus.Confirmed Then
                If CurrentOrder.OrderConsolidationID > 0 Then
                    ShowMessage("This order has been added to a consolidation so should be managed from there.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    IsLoading = True
                    Combo.SetSelectedComboItem_By_Value(cboOrderStatus, CurrentOrder.OrderStatusID)
                    IsLoading = False
                    Exit Sub
                End If
            End If

            Select Case Combo.GetSelectedItemValue(cboOrderStatus)
                Case Enums.OrderStatus.Confirmed
                    Dim department As String = Helper.MakeStringValid(Combo.GetSelectedItemValue(cboDept))

                    If Helper.IsValidInteger(department) AndAlso Helper.MakeIntegerValid(department) <= 0 Then
                        ShowMessage("Department Reference Missing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        IsLoading = True
                        Combo.SetSelectedComboItem_By_Value(cboOrderStatus, CurrentOrder.OrderStatusID)
                        IsLoading = False
                    Else
                        If ShowMessage("Are you sure you want to confirm order? No changes can be made to the order once it has been confirmed.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                            IsLoading = True
                            Combo.SetSelectedComboItem_By_Value(cboOrderStatus, CurrentOrder.OrderStatusID)
                            IsLoading = False
                            Exit Sub
                        Else
                            If ItemsIncludedDataView.Table.Rows.Count = 0 Then
                                ShowMessage("There are no items included on this order, Order cannot be marked as confirmed until items added", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                IsLoading = True
                                Combo.SetSelectedComboItem_By_Value(cboOrderStatus, CurrentOrder.OrderStatusID)
                                IsLoading = False
                                Exit Sub
                            Else
                                If CurrentOrder.OrderConsolidationID > 0 Then
                                    If ShowMessage("This order will be removed from the consolidation, are you sure you wish to confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                        IsLoading = True
                                        Combo.SetSelectedComboItem_By_Value(cboOrderStatus, CurrentOrder.OrderStatusID)
                                        IsLoading = False
                                        Exit Sub
                                    Else
                                        IsLoading = True
                                        CurrentOrder.SetOrderStatusID = CInt(Enums.OrderStatus.Confirmed)
                                        RemoveConsolidation = True
                                    End If
                                Else

                                    If CurrentOrder.OrderStatusID <> CInt(Enums.OrderStatus.Confirmed) Then
                                        Dim orderControl As OrderControl = New OrderControl(CurrentOrder)
                                        If orderControl.IsWithinJobSpendLimit() Then
                                            CurrentOrder.SetOrderStatusID = CInt(Enums.OrderStatus.Confirmed)
                                        Else
                                            If loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.POAuthorisation) Then
                                                ShowMessage("Job cost capacity was exceeded when creating this purchase order!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                CurrentOrder.SetOrderStatusID = CInt(Enums.OrderStatus.Confirmed)
                                            Else
                                                ShowMessage("Job cost capacity was exceeded when creating this purchase order!" & vbCrLf & vbCrLf &
                                                            "Please note that this order is currently awaiting approval!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                CurrentOrder.SetOrderStatusID = CInt(Enums.OrderStatus.AwaitingApproval)
                                            End If
                                        End If
                                    End If

                                    If CurrentOrder.OrderStatusID = CInt(Enums.OrderStatus.Confirmed) AndAlso CurrentOrder.OrderTypeID = Enums.OrderType.Job Then
                                        Dim engineerVisitId As Integer = CType(Me.pnlDetails.Controls(0), UCOrderForJob).SelectedEngineerVisitDataRow.Item("EngineerVisitID")
                                        Dim oEngVisit As Entity.EngineerVisits.EngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(engineerVisitId)
                                        oEngVisit.SetPartsToFit = True
                                        DB.EngineerVisits.Update(oEngVisit, 0, True)
                                    End If

                                    'check if the order has an f on the end
                                    Dim orderRef As String = CurrentOrder.OrderReference
                                    If orderRef.ToLower.EndsWith("f") Then
                                        'remove the f
                                        CurrentOrder.SetOrderReference = CurrentOrder.OrderReference.Trim().Remove(orderRef.Length - 1)
                                    End If

                                    If CurrentOrder.OrderTypeID = Enums.OrderType.Job Then
                                        Dim siteId As Integer = CType(Me.pnlDetails.Controls(0), UCOrderForJob).SelectedEngineerVisitDataRow("SiteID")
                                        Dim currentCustomer As Entity.Customers.Customer = DB.Customer.Customer_Get_ForSiteID(siteId)
                                        If (currentCustomer.IsPFH) Then
                                            If DB.Supplier.Supplier_GetSecondaryPrice(SupplierUsedID) Then
                                                CurrentOrder.SetOrderReference = CurrentOrder.OrderReference & "F"
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                Case Enums.OrderStatus.Cancelled

                    If Not CurrentOrder.OrderStatusID = Enums.OrderStatus.Cancelled Then
                        If ShowMessage("Are you sure you want to cancel this order?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            ShowForm(GetType(FRMOrderRejection), True, New Object() {Me, ""})

                            If dgvReceivedInvoices.RowCount > 0 Then
                                ShowMessage("You can not cancel this order as Invoices have been received", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                IsLoading = True
                                Combo.SetSelectedComboItem_By_Value(cboOrderStatus, CurrentOrder.OrderStatusID)
                                IsLoading = False
                                Exit Sub
                            End If

                            If Reason.Trim.Length = 0 Then
                                IsLoading = True
                                Combo.SetSelectedComboItem_By_Value(cboOrderStatus, CurrentOrder.OrderStatusID)
                                IsLoading = False
                                Exit Sub
                            Else

                                'remove parts allocated
                                If CurrentOrder.OrderTypeID = Enums.OrderType.Job Then

                                    Dim dt As DataTable = DB.Order.OrderPart_GetForOrder(CurrentOrder.OrderID).Table

                                    For Each d As DataRow In dt.Rows
                                        DB.ExecuteScalar("Delete tblengineerVisitPartAllocated where orderpartid = " & d("OrderPartID"))
                                    Next

                                End If

                                DB.PartTransaction.DeleteForOrder(CurrentOrder.OrderID)
                                DB.ProductTransaction.DeleteForOrder(CurrentOrder.OrderID)
                                CurrentOrder.SetReasonForReject = Reason
                                CurrentOrder.SetOrderStatusID = CInt(Enums.OrderStatus.Cancelled)
                            End If
                        Else
                            IsLoading = True
                            Combo.SetSelectedComboItem_By_Value(cboOrderStatus, CurrentOrder.OrderStatusID)
                            IsLoading = False
                            Exit Sub
                        End If
                    End If
                Case Enums.OrderStatus.Complete
                    Dim department As String = Helper.MakeStringValid(Combo.GetSelectedItemValue(cboDept))

                    If Helper.IsValidInteger(department) AndAlso Helper.MakeIntegerValid(department) <= 0 Then
                        ShowMessage("Department Reference Missing", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        IsLoading = True
                        Combo.SetSelectedComboItem_By_Value(cboOrderStatus, CurrentOrder.OrderStatusID)
                        IsLoading = False
                    Else
                        If CurrentOrder.OrderStatusID = Enums.OrderStatus.AwaitingConfirmation Then
                            ShowMessage("You cannot complete an order manually.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            IsLoading = True
                            Combo.SetSelectedComboItem_By_Value(cboOrderStatus, CurrentOrder.OrderStatusID)
                            IsLoading = False
                            Exit Sub
                        End If
                    End If
            End Select

            CurrentOrder.SetDepartmentRef = Combo.GetSelectedItemValue(cboDept)
            DB.Order.Update(CurrentOrder)

            If RemoveConsolidation Then
                DB.OrderConsolidations.Order_Set_Consolidated(CurrentOrder.OrderConsolidationID, CurrentOrder.OrderID, True)
            End If

            IsLoading = True

            CurrentOrder = DB.Order.Order_Get(CurrentOrder.OrderID)

        End If

        If Not CurrentOrder Is Nothing Then
            If CurrentOrder.OrderStatusID = Enums.OrderStatus.AwaitingConfirmation Or
               CurrentOrder.OrderStatusID = Enums.OrderStatus.AwaitingApproval Or
               CurrentOrder.OrderStatusID = 0 Then

                txtOrderReference.Visible = False
                btnUpdateOrderRef.Visible = False
            Else
                txtOrderReference.Visible = True
                btnUpdateOrderRef.Visible = True
            End If
        Else
            txtOrderReference.Visible = False
            btnUpdateOrderRef.Visible = False
        End If
    End Sub

    Public Sub ReasonChanged(ByVal Reason As String)
        Me.Reason = Reason
    End Sub

    Private Sub lblOrderStatus_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblOrderStatus.Click
        If CurrentOrder.OrderStatusID = Enums.OrderStatus.Cancelled Then
            ShowForm(GetType(FRMOrderRejection), True, New Object() {Me, CurrentOrder.ReasonForReject})
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnPrint.Click
        Print()
    End Sub

    Private Sub btnEmail_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnEmail.Click
        Email()
    End Sub

    Private Sub btnCharges_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnCharges.Click
        If CurrentOrder.OrderID = 0 Then
            ShowMessage("You must save the order before adding additional charges", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        ShowForm(GetType(FRMOrderCharges), True, New Object() {CurrentOrder.OrderID})

        PopulateOrderTotal()
    End Sub

    Private Sub btnCreatePartRequest_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnCreatePartRequest.Click
        Dim supplierID As Integer = FindRecord(Enums.TableNames.tblSupplier)

        Try
            If Not supplierID = 0 Then
                Me.Cursor = Cursors.WaitCursor

                Dim oPartPriceRequest As New Entity.PartSupplierPriceRequests.PartSupplierPriceRequest
                oPartPriceRequest.IgnoreExceptionsOnSetMethods = True
                oPartPriceRequest.SetPartID = SelectedPartDataRow.Item("PartID")
                oPartPriceRequest.SetQuantityInPack = Me.txtPartQuantity.Text.Trim
                oPartPriceRequest.SetOrderID = CurrentOrder.OrderID
                oPartPriceRequest.SetSupplierID = supplierID
                oPartPriceRequest.SetComplete = 0

                Dim val As New Entity.PartSupplierPriceRequests.PartSupplierPriceRequestValidator
                val.Validate(oPartPriceRequest)

                DB.PartPriceRequest.InsertForOrder(oPartPriceRequest)

                RefreshDataGrids()

                PartSearch()
                ProductSearch()
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

    Private Sub btnCreateProductPriceRequest_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnCreateProductPriceRequest.Click
        Dim supplierID As Integer = FindRecord(Enums.TableNames.tblSupplier)

        Try
            If Not supplierID = 0 Then
                Me.Cursor = Cursors.WaitCursor

                Dim oProductPriceRequest As New Entity.ProductSupplierPriceRequests.ProductSupplierPriceRequest
                oProductPriceRequest.IgnoreExceptionsOnSetMethods = True
                oProductPriceRequest.SetProductID = SelectedProductDataRow.Item("ProductID")
                oProductPriceRequest.SetQuantityInPack = Me.txtProductQuantity.Text.Trim
                oProductPriceRequest.SetOrderID = CurrentOrder.OrderID
                oProductPriceRequest.SetSupplierID = supplierID
                oProductPriceRequest.SetComplete = 0

                Dim val As New Entity.ProductSupplierPriceRequests.ProductSupplierPriceRequestValidator
                val.Validate(oProductPriceRequest)

                DB.ProductPriceRequest.InsertForOrder(oProductPriceRequest)

                PartSearch()
                ProductSearch()
                RefreshDataGrids()
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

    Private Sub dgPriceRequests_Click(ByVal sender As Object, ByVal e As EventArgs) Handles dgPriceRequests.Click, dgPriceRequests.CurrentCellChanged
        If SelectedPriceRequestDataRow Is Nothing Then
            ShowMessage("Please select item to update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.btnUpdatePartPriceRequest.Enabled = False
            Exit Sub
        End If

        Me.btnUpdatePartPriceRequest.Enabled = True
    End Sub

    Private Sub btnUpdatePartPriceRequest_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnUpdatePartPriceRequest.Click
        If SelectedPriceRequestDataRow Is Nothing Then
            ShowMessage("Please select an item to update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.btnUpdatePartPriceRequest.Enabled = False
            Exit Sub
        End If

        If SelectedPriceRequestDataRow.Item("Type") = "Part" Then
            Dim oPartSupplier As New Entity.PartSuppliers.PartSupplier
            oPartSupplier.SetPartID = SelectedPriceRequestDataRow("PartProductID")
            oPartSupplier.SetSupplierID = SelectedPriceRequestDataRow("SupplierID")
            oPartSupplier.SetQuantityInPack = SelectedPriceRequestDataRow("QuantityInPack")

            ShowForm(GetType(FRMAddtoOrder), True, New Object() {CurrentOrder, oPartSupplier, Nothing, SelectedPriceRequestDataRow.Item("ID")})
        ElseIf SelectedPriceRequestDataRow.Item("Type") = "Product" Then
            Dim oProductSupplier As New Entity.ProductSuppliers.ProductSupplier
            oProductSupplier.SetProductID = SelectedPriceRequestDataRow("PartProductID")
            oProductSupplier.SetSupplierID = SelectedPriceRequestDataRow("SupplierID")
            oProductSupplier.SetQuantityInPack = SelectedPriceRequestDataRow("QuantityInPack")

            ShowForm(GetType(FRMAddtoOrder), True, New Object() {CurrentOrder, Nothing, oProductSupplier, SelectedPriceRequestDataRow.Item("ID")})
        End If

        RefreshDataGrids()
        PartSearch()
        ProductSearch()
    End Sub

    Private Sub cboTaxCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboInvoiceTaxCodeNew.SelectedIndexChanged
        Calculate_Tax()
    End Sub

    Private Sub cboCreditTaxCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboCreditTax.SelectedIndexChanged
        Calculate_Tax2()
    End Sub

    Private Sub dgvReceivedInvoices_CellClick(sender As Object, e As EventArgs) Handles dgvReceivedInvoices.CellClick
        btnUpdateSupplierInvoice.Visible = True
        btnDeleteSupplierInvoice.Visible = True

        Dim SupplierInvoiceID As Integer = dgvReceivedInvoices.Item("SupplierInvoiceID", dgvReceivedInvoices.CurrentRow.Index).Value

        Dim dt As DataTable = DB.SupplierInvoices.Order_GetSupplierInvoice(SupplierInvoiceID).ToTable

        Dim SupplierInvoiceDate As Date = Nothing
        If Not IsDBNull(dt.Rows(0).Item("SupplierInvoiceDate")) Then SupplierInvoiceDate = dt.Rows(0).Item("SupplierInvoiceDate")
        If SupplierInvoiceDate = Nothing Then
            'chkInvoiceSupInvDateNANew.Checked = True
            dtpSupplierInvoiceDateNew.Value = Now
        Else
            'chkInvoiceSupInvDateNANew.Checked = False
            dtpSupplierInvoiceDateNew.Value = SupplierInvoiceDate
        End If

        Dim SupplierInvoiceRef As String = Nothing
        If Not IsDBNull(dt.Rows(0).Item("SupplierInvoiceReference")) Then SupplierInvoiceRef = dt.Rows(0).Item("SupplierInvoiceReference")
        txtSupplierInvoiceRefNew.Text = SupplierInvoiceRef

        Dim ExtraRef As String = Nothing
        If Not IsDBNull(dt.Rows(0).Item("ExtraRef")) Then ExtraRef = dt.Rows(0).Item("ExtraRef")
        txtExtraReferenceNew.Text = ExtraRef

        Dim NominalCode As String = Nothing
        If Not IsDBNull(dt.Rows(0).Item("NominalCode")) Then NominalCode = dt.Rows(0).Item("NominalCode")
        txtNominalCodeNew.Text = NominalCode

        Dim SupplierInvoiceGoods As Double = Nothing
        If Not IsDBNull(dt.Rows(0).Item("SupplierGoodsAmount")) Then SupplierInvoiceGoods = dt.Rows(0).Item("SupplierGoodsAmount")
        txtTotalAmount.Text = Format(SupplierInvoiceGoods, "C")

        Dim SupplierInvoiceVAT As Double = Nothing
        If Not IsDBNull(dt.Rows(0).Item("SupplierVATAmount")) Then SupplierInvoiceVAT = dt.Rows(0).Item("SupplierVATAmount")
        txtVATAmount.Text = Format(SupplierInvoiceVAT, "C")

        Dim SupplierInvoiceTotal As Double = Nothing
        If Not IsDBNull(dt.Rows(0).Item("SupplierInvoiceAmount")) Then SupplierInvoiceTotal = dt.Rows(0).Item("SupplierInvoiceAmount")
        txtGoodsAmount.Text = Format(SupplierInvoiceTotal, "C")

        cboInvoiceTaxCodeNew.SelectedValue = Nothing
        If Not IsDBNull(dt.Rows(0).Item("TaxCodeID")) Then
            Combo.SetSelectedComboItem_By_Value(Me.cboInvoiceTaxCodeNew, dt.Rows(0).Item("TaxCodeID"))
        End If
        cboInvoiceTaxCodeNew.SelectedValue = dt.Rows(0).Item("TaxCodeID")

        If Not IsGasway Then
            If (dt.Rows(0).Item("RequiresAuthorisation") = True And dt.Rows(0).Item("Authorised") = True) Or dt.Rows(0).Item("RequiresAuthorisation") = False Then
                cboReadySageNew.Enabled = True
            Else
                cboReadySageNew.Enabled = False
            End If
        End If

        btnAddSupplierInvoice.Text = "New"

        If CBool(dt.Rows(0).Item("SentToSage")) = True Then
            dtpSupplierInvoiceDateNew.Enabled = False
            txtSupplierInvoiceRefNew.ReadOnly = True
            txtExtraReferenceNew.ReadOnly = True
            txtNominalCodeNew.ReadOnly = True
            txtGoodsAmount.ReadOnly = True
            txtVATAmount.ReadOnly = True
            txtTotalAmount.ReadOnly = True
            cboInvoiceTaxCodeNew.Enabled = False
            btnUpdateSupplierInvoice.Enabled = False
            btnDeleteSupplierInvoice.Enabled = False
        Else
            dtpSupplierInvoiceDateNew.Enabled = True
            txtSupplierInvoiceRefNew.ReadOnly = False
            txtExtraReferenceNew.ReadOnly = False
            txtNominalCodeNew.ReadOnly = False
            txtGoodsAmount.ReadOnly = False
            txtVATAmount.ReadOnly = False
            txtTotalAmount.ReadOnly = False
            cboInvoiceTaxCodeNew.Enabled = True
            btnUpdateSupplierInvoice.Enabled = True
            btnDeleteSupplierInvoice.Enabled = True
        End If
    End Sub

    Private Sub dgCredits_CellClick(sender As Object, e As EventArgs) Handles dgCredits.CellClick
        btnCreditAdd.Visible = True
        btnCreditDelete.Visible = True

        If dgCredits.Item("DateReceived", dgCredits.CurrentRow.Index).Value.ToString.Length = 0 Then
        Else

            Dim CreditID As Integer = dgCredits.Item("PartCreditsID", dgCredits.CurrentRow.Index).Value

            Dim dt As DataTable = DB.PartsToBeCredited.PartsToBeCredited_Get_Parts_For_CreditID(CreditID).Table

            Dim SupplierInvoiceDate As Date = Nothing
            If Not IsDBNull(dt.Rows(0).Item("DateReceived")) Then SupplierInvoiceDate = dt.Rows(0).Item("DateReceived")
            If SupplierInvoiceDate = Nothing Then
                'chkInvoiceSupInvDateNANew.Checked = True
                dtpCreditDate.Value = Now
            Else
                'chkInvoiceSupInvDateNANew.Checked = False
                dtpCreditDate.Value = SupplierInvoiceDate
            End If

            Dim SupplierInvoiceRef As String = Nothing
            If Not IsDBNull(dt.Rows(0).Item("SupplierCreditRef")) Then SupplierInvoiceRef = dt.Rows(0).Item("SupplierCreditRef")
            txtCreditRef.Text = SupplierInvoiceRef

            Dim ExtraRef As String = Nothing
            If Not IsDBNull(dt.Rows(0).Item("ExtraRef")) Then ExtraRef = dt.Rows(0).Item("ExtraRef")
            txtCreditExRef.Text = ExtraRef

            Dim NominalCode As String = Nothing
            If Not IsDBNull(dt.Rows(0).Item("NominalCode")) Then NominalCode = dt.Rows(0).Item("NominalCode")
            txtCreditNominal.Text = NominalCode

            cboCreditTax.SelectedValue = Nothing
            If Not IsDBNull(dt.Rows(0).Item("TaxCodeID")) Then
                Combo.SetSelectedComboItem_By_Value(Me.cboCreditTax, dt.Rows(0).Item("TaxCodeID"))
            End If
            cboCreditTax.SelectedValue = dt.Rows(0).Item("TaxCodeID")

            Dim SupplierInvoiceGoods As Double = Nothing
            If Not IsDBNull(dt.Rows(0).Item("AmountReceived")) Then SupplierInvoiceGoods = dt.Rows(0).Item("AmountReceived")
            txtCreditGoods.Text = Format(SupplierInvoiceGoods, "C")
            '/ (1 + (DB.Picklists.Get_One_As_Object(Combo.GetSelectedItemValue(Me.cboCreditTax)).PercentageRate / 100))

            Calculate_Tax2()

            If IsDBNull((dt.Rows(0).Item("DateExportedToSage"))) = False Then
                dtpCreditDate.Enabled = False
                'chkInvoiceSupInvDateNANew.Enabled = False
                txtCreditRef.ReadOnly = True
                txtCreditExRef.ReadOnly = True
                txtCreditNominal.ReadOnly = True
                txtCreditGoods.ReadOnly = True
                txtCreditVAT.ReadOnly = True
                txtCreditTotal.ReadOnly = True
                cboCreditTax.Enabled = False

                btnCreditAdd.Enabled = False
                btnCreditDelete.Enabled = False
            Else
                dtpCreditDate.Enabled = True
                'chkInvoiceSupInvDateNANew.Enabled = False
                txtCreditRef.ReadOnly = False
                txtCreditExRef.ReadOnly = False
                txtCreditNominal.ReadOnly = False
                txtCreditGoods.ReadOnly = False
                txtCreditVAT.ReadOnly = False
                txtCreditTotal.ReadOnly = False
                cboCreditTax.Enabled = True

                btnCreditAdd.Enabled = True
                btnCreditDelete.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnAddSupplierInvoice_Click(sender As System.Object, e As EventArgs) Handles btnAddSupplierInvoice.Click
        If CurrentOrder.OrderTypeID = 0 Then
            ShowMessage("You must save your order details before continuing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If btnAddSupplierInvoice.Text = "New" Then
            btnAddSupplierInvoice.Text = "Add"

            dtpSupplierInvoiceDateNew.Value = Now
            txtSupplierInvoiceRefNew.Text = Nothing
            txtExtraReferenceNew.Text = Nothing
            txtNominalCodeNew.Text = Nothing
            txtGoodsAmount.Text = Nothing
            txtVATAmount.Text = Nothing
            txtTotalAmount.Text = Nothing
            Combo.SetSelectedComboItem_By_Value(Me.cboInvoiceTaxCodeNew, Nothing)
            cboReadySageNew.Checked = False

            dtpSupplierInvoiceDateNew.Enabled = True
            txtSupplierInvoiceRefNew.ReadOnly = False
            txtExtraReferenceNew.ReadOnly = False
            txtNominalCodeNew.ReadOnly = False
            txtGoodsAmount.ReadOnly = False
            txtVATAmount.ReadOnly = False
            txtTotalAmount.ReadOnly = False
            cboInvoiceTaxCodeNew.Enabled = True
            cboReadySageNew.Enabled = True
        Else
            If ValidateSupplierInvoice() Then
                Dim oSupplierInvoice As New Entity.Orders.SupplierInvoice
                oSupplierInvoice.SetOrderID = CurrentOrder.OrderID
                oSupplierInvoice.SetInvoiceReference = txtSupplierInvoiceRefNew.Text
                oSupplierInvoice.SetInvoiceDate = dtpSupplierInvoiceDateNew.Value
                oSupplierInvoice.SetGoodsAmount = Replace(txtTotalAmount.Text, "£", "")
                oSupplierInvoice.SetVATAmount = Replace(txtVATAmount.Text, "£", "")
                oSupplierInvoice.SetTotalAmount = Replace(txtGoodsAmount.Text, "£", "")
                oSupplierInvoice.SetTaxCodeID = Combo.GetSelectedItemValue(cboInvoiceTaxCodeNew)
                oSupplierInvoice.SetNominalCode = txtNominalCodeNew.Text
                oSupplierInvoice.SetExtraRef = txtExtraReferenceNew.Text
                oSupplierInvoice.SetReadyToSendToSage = cboReadySageNew.Checked
                oSupplierInvoice.SetSentToSage = 0
                oSupplierInvoice.SetOldSystemInvoice = 0
                oSupplierInvoice.SetDateExported = Nothing
                oSupplierInvoice.SetKeyedBy = loggedInUser.UserID

                Try
                    DB.SupplierInvoices.Insert(oSupplierInvoice)
                Catch ex As Exception
                    ShowMessage("An error has occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                RefreshDataGrids()
                PopulateOrderTotal()

                txtSupplierInvoiceRefNew.Text = Nothing
                txtExtraReferenceNew.Text = Nothing
                txtNominalCodeNew.Text = Nothing
                txtGoodsAmount.Text = Nothing
                txtVATAmount.Text = Nothing
                txtTotalAmount.Text = Nothing
                Combo.SetSelectedComboItem_By_Value(Me.cboInvoiceTaxCodeNew, Nothing)
            End If
        End If
    End Sub

    Private Sub btnCreditAdd_Click(sender As System.Object, e As EventArgs) Handles btnCreditAdd.Click
        If btnCreditAdd.Text = "New" Then
            btnCreditAdd.Text = "Add"

            dtpCreditDate.Value = Now
            txtCreditRef.Text = Nothing
            txtCreditExRef.Text = Nothing
            txtCreditNominal.Text = Nothing
            txtCreditGoods.Text = Nothing
            txtCreditVAT.Text = Nothing
            txtCreditTotal.Text = Nothing
            Combo.SetSelectedComboItem_By_Value(Me.cboCreditTax, Nothing)

            dtpCreditDate.Enabled = True
            txtCreditRef.ReadOnly = False
            txtCreditExRef.ReadOnly = False
            txtCreditNominal.ReadOnly = False
            txtCreditGoods.ReadOnly = False
            txtCreditVAT.ReadOnly = False
            txtCreditTotal.ReadOnly = False
            cboCreditTax.Enabled = True
        Else
            If ValidateCreditInvoice() Then
                Dim dv As New DataView
                Using f As New FRMPartsForCreditList(CurrentOrder.OrderID, False, True)
                    f.ShowDialog()
                    dv = f.RatesDataview
                End Using
                Dim dtc As New DataTable
                Dim oCredit As New Entity.PartsToBeCrediteds.PartsToBeCredited
                If dv.Table.Select("tick = 1 AND QtyToCredit > 0").Length > 0 Then

                    For Each r As DataRow In dv.Table.Select("tick = 1 AND QtyToCredit > 0")
                        oCredit = New Entity.PartsToBeCrediteds.PartsToBeCredited

                        oCredit.SetOrderID = CurrentOrder.OrderID
                        oCredit.SetOrderReference = CurrentOrder.OrderReference
                        oCredit.SetPartID = r("PartProductID")
                        oCredit.SetQty = r("QtyToCredit")
                        oCredit.SetCreditReceived = CDbl(txtCreditGoods.Text.Replace("£", ""))
                        oCredit.SetStatusID = 3
                        oCredit.SetSupplierID = SupplierUsedID

                        oCredit.SetPartOrderID = r("ID")  ' orderpartid

                        dtc = DB.PartsToBeCredited.PartsToBeCredited_Get_OrderPartID(r("ID")).Table

                        If dtc.Rows.Count > 0 AndAlso Not IsDBNull(dtc.Rows(0)("CreditReceived")) Then 'Update  there are rows but we havent allocated the credit yet
                            oCredit.SetPartsToBeCreditedID = dtc.Rows(0)("PartsToBeCreditedID")
                            DB.PartsToBeCredited.Update(oCredit)
                        Else ' Insert they may be rows but we already adddeda  credit for that add a new line

                            oCredit = DB.PartsToBeCredited.Insert(oCredit)

                        End If

                        'insert the credit?

                    Next

                    If dtc.Rows.Count = 0 OrElse Not IsDBNull(dtc.Rows(0)("CreditReceived")) Then  ' if there are no credits against this order for this part or there is but already has a credit allocated - add a new line

                        Dim partcreditsID As Integer = DB.PartsToBeCredited.PartCredits_Insert(CDbl(txtCreditGoods.Text.Replace("£", "")), "", dtpCreditDate.Value, Date.MinValue, Combo.GetSelectedItemValue(cboCreditTax), txtCreditNominal.Text, CurrentOrder.DepartmentRef, txtCreditExRef.Text, txtCreditRef.Text)

                        DB.ExecuteScalar("INSERT INTO tblPartCreditParts (PartCreditID,PartsToBeCreditedID) VALUES (" & partcreditsID & "," & oCredit.PartsToBeCreditedID & ")")
                    Else

                        DB.PartsToBeCredited.PartCredits_Update(dtc.Rows(0)("PartCreditsID"), CDbl(txtCreditGoods.Text), "", dtpCreditDate.Value, Date.MinValue, Combo.GetSelectedItemValue(cboCreditTax), txtCreditNominal.Text, CurrentOrder.DepartmentRef, txtCreditExRef.Text, txtCreditRef.Text)

                    End If

                    RefreshDataGrids()
                    PopulateOrderTotal()

                End If
            End If

        End If

    End Sub

    Private Sub btnUpdateSupplierInvoice_Click(sender As System.Object, e As EventArgs) Handles btnUpdateSupplierInvoice.Click
        If ValidateSupplierInvoice(True) Then
            Dim oSupplierInvoice As New Entity.Orders.SupplierInvoice
            oSupplierInvoice.SetOrderID = CurrentOrder.OrderID
            oSupplierInvoice.SetInvoiceReference = txtSupplierInvoiceRefNew.Text
            oSupplierInvoice.SetInvoiceDate = dtpSupplierInvoiceDateNew.Value
            oSupplierInvoice.SetGoodsAmount = Replace(txtTotalAmount.Text, "£", "")
            oSupplierInvoice.SetVATAmount = Replace(txtVATAmount.Text, "£", "")
            oSupplierInvoice.SetTotalAmount = Replace(txtGoodsAmount.Text, "£", "")
            oSupplierInvoice.SetTaxCodeID = Combo.GetSelectedItemValue(cboInvoiceTaxCodeNew)
            oSupplierInvoice.SetNominalCode = txtNominalCodeNew.Text
            oSupplierInvoice.SetExtraRef = txtExtraReferenceNew.Text
            oSupplierInvoice.SetReadyToSendToSage = cboReadySageNew.Checked
            oSupplierInvoice.SetSentToSage = 0
            oSupplierInvoice.SetOldSystemInvoice = 0
            oSupplierInvoice.SetDateExported = Nothing
            oSupplierInvoice.SetKeyedBy = loggedInUser.UserID

            Dim SupplierInvoiceID As Integer = dgvReceivedInvoices.Item("SupplierInvoiceID", dgvReceivedInvoices.CurrentRow.Index).Value
            oSupplierInvoice.SetInvoiceID = SupplierInvoiceID

            Try
                DB.SupplierInvoices.Update(oSupplierInvoice)
            Catch ex As Exception
                ShowMessage("An error has occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            dtpSupplierInvoiceDateNew.Value = Now
            txtSupplierInvoiceRefNew.Text = Nothing
            txtExtraReferenceNew.Text = Nothing
            txtNominalCodeNew.Text = Nothing
            txtGoodsAmount.Text = Nothing
            txtVATAmount.Text = Nothing
            txtTotalAmount.Text = Nothing
            Combo.SetSelectedComboItem_By_Value(Me.cboInvoiceTaxCodeNew, Nothing)
            cboReadySageNew.Checked = False

            RefreshDataGrids()
            PopulateOrderTotal()
        End If
    End Sub

    Private Sub btnDeleteSupplierInvoice_Click(sender As System.Object, e As EventArgs) Handles btnDeleteSupplierInvoice.Click
        Dim SupplierInvoiceID As Integer = dgvReceivedInvoices.Item("SupplierInvoiceID", dgvReceivedInvoices.CurrentRow.Index).Value
        DB.SupplierInvoices.Delete(SupplierInvoiceID)

        dtpSupplierInvoiceDateNew.Value = Now
        txtSupplierInvoiceRefNew.Text = Nothing
        txtExtraReferenceNew.Text = Nothing
        txtNominalCodeNew.Text = Nothing
        txtGoodsAmount.Text = Nothing
        txtVATAmount.Text = Nothing
        txtTotalAmount.Text = Nothing
        Combo.SetSelectedComboItem_By_Value(Me.cboInvoiceTaxCodeNew, Nothing)
        cboReadySageNew.Checked = False

        RefreshDataGrids()
        PopulateOrderTotal()

        btnAddSupplierInvoice.Text = "Add"
    End Sub

    Private Sub btnDeleteCredit_Click(sender As System.Object, e As EventArgs) Handles btnCreditDelete.Click

        Dim CreditID As Integer = 0
        If IsDBNull(dgCredits.Item("PartCreditsID", dgCredits.CurrentRow.Index).Value) Then
        Else
            CreditID = dgCredits.Item("PartCreditsID", dgCredits.CurrentRow.Index).Value
        End If

        Dim OrderPartID As Integer = 0

        If IsDBNull(dgCredits.Item("OrderPartID", dgCredits.CurrentRow.Index).Value) Then
        Else
            OrderPartID = dgCredits.Item("OrderPartID", dgCredits.CurrentRow.Index).Value
        End If

        Dim partCreditId As Integer = 0
        If IsDBNull(dgCredits.Item("PartsToBeCreditedID", dgCredits.CurrentRow.Index).Value) Then
        Else
            partCreditId = dgCredits.Item("PartsToBeCreditedID", dgCredits.CurrentRow.Index).Value
        End If

        If partCreditId > 0 Then
            DB.ExecuteScalar("Delete From tblPartstobeCredited where PartsToBeCreditedID = " & partCreditId)
        ElseIf CreditID > 0 Then
            DB.PartsToBeCredited.Delete(CreditID)
        ElseIf OrderPartID > 0 Then
            DB.ExecuteScalar("Delete From tblPartstobeCredited where OrderPartID = " & OrderPartID)
            DB.ExecuteScalar("Delete From tblPArtDistributed Where OrderPartID = " & OrderPartID)
            DB.ExecuteScalar("UPDATE tblEngineerVisitPartAllocated SET CreditRequested = 0,CreditQty = 0 WHERE ORDERPARTID = " & OrderPartID)
        End If

        dtpCreditDate.Value = Now
        txtCreditRef.Text = Nothing
        txtCreditExRef.Text = Nothing
        txtCreditNominal.Text = Nothing
        txtCreditGoods.Text = Nothing
        txtCreditVAT.Text = Nothing
        txtCreditTotal.Text = Nothing
        Combo.SetSelectedComboItem_By_Value(Me.cboCreditTax, Nothing)

        RefreshDataGrids()
        PopulateOrderTotal()

    End Sub

#Region "Parts"

    Private Sub cboPartLocation_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboPartLocation.SelectedIndexChanged
        If Not PartsDataView Is Nothing Then
            PartsDataView.Table.Rows.Clear()
        End If

        UpdatePartSearchOptions()
    End Sub

    Private Sub btnAddNewPart_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddNewPart.Click
        ShowForm(GetType(FRMPart), True, New Object() {0, True})

        PartSearch()
    End Sub

    Private Sub btnPartSearch_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnPartSearch.Click
        PartSearch()
    End Sub

    Private Sub dgParts_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles dgParts.DoubleClick
        If Not SelectedPartDataRow Is Nothing Then
            If loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.CreateParts) Then
                Dim isPartPack As Boolean = Helper.MakeBooleanValid(SelectedPartDataRow("IsPartPack"))
                If isPartPack Then
                    ShowForm(GetType(FRMPartPack), True, New Object() {Helper.MakeIntegerValid(SelectedPartDataRow.Item("PartID")), True, True})
                Else
                    ShowForm(GetType(FRMPart), True, New Object() {Helper.MakeIntegerValid(SelectedPartDataRow.Item("PartID")), True})
                End If
            End If
        End If
    End Sub

    Private Sub dgParts_Click(ByVal sender As Object, ByVal e As EventArgs) Handles dgParts.Click, dgParts.CurrentCellChanged
        UpdatePartSearchOptions()

        If SelectedPartDataRow Is Nothing Then
            Exit Sub
        End If

        Select Case Combo.GetSelectedItemValue(cboPartLocation)
            Case Enums.LocationType.Van
                Me.txtPartQuantity.Text = 1
                Me.txtPartQuantity.ReadOnly = False
                Me.txtPartBuyPrice.Text = "N/A"
                Me.txtPartBuyPrice.ReadOnly = True
                Me.btnAddPart.Enabled = True
                Me.btnCreatePartRequest.Enabled = False
            Case Enums.LocationType.Warehouse
                Me.txtPartQuantity.Text = 1
                Me.txtPartQuantity.ReadOnly = False
                Me.txtPartBuyPrice.Text = "N/A"
                Me.txtPartBuyPrice.ReadOnly = True
                Me.btnAddPart.Enabled = True
                Me.btnCreatePartRequest.Enabled = False
            Case Enums.LocationType.Supplier
                Dim isPartPack As Boolean = Helper.MakeBooleanValid(SelectedPartDataRow("IsPartPack"))
                Me.txtPartBuyPrice.Enabled = Not isPartPack

                Me.txtPartQuantity.Text = "1"
                Me.txtPartQuantity.ReadOnly = False

                If IsDBNull(SelectedPartDataRow.Item("SupplierID")) Then
                    Me.txtPartBuyPrice.Text = "N/A"
                    Me.txtPartBuyPrice.ReadOnly = True
                    Me.btnAddPart.Enabled = False
                Else
                    Me.txtPartBuyPrice.Text = Format(SelectedPartDataRow.Item("Price"), "F")
                    Me.txtPartBuyPrice.ReadOnly = False
                    Me.btnAddPart.Enabled = True
                End If

                Me.btnCreatePartRequest.Enabled = True
        End Select
    End Sub

    Private Sub AddPartToOrder()
        Dim oOrderPart As New Entity.OrderParts.OrderPart
        oOrderPart.IgnoreExceptionsOnSetMethods = True
        oOrderPart.SetOrderID = CurrentOrder.OrderID
        oOrderPart.SetPartSupplierID = SelectedPartDataRow.Item("PartSupplierID")

        Dim partid As Integer = SelectedPartDataRow.Item("PartID")
        Dim isSpecialPart As Boolean = Helper.MakeBooleanValid(SelectedPartDataRow("IsSpecialPart"))
        If isSpecialPart Then
            Dim f As New FRMSpecialOrder(SelectedPartDataRow.Item("PartSupplierID"), txtPartBuyPrice.Text.Trim, txtPartQuantity.Text.Trim)
            f.ShowDialog()
            If f.DialogResult = DialogResult.OK Then
                oOrderPart.SetQuantity = f.Quantity
                oOrderPart.SetBuyPrice = f.Price
                oOrderPart.SetSpecialDescription = f.PartName
                oOrderPart.SetSpecialPartNumber = f.SPN
            Else
                Exit Sub
            End If
        Else

            oOrderPart.SetQuantity = txtPartQuantity.Text.Trim
            oOrderPart.SetBuyPrice = txtPartBuyPrice.Text.Trim
        End If

        oOrderPart.SetQuantityReceived = 0
        oOrderPart.SetChildSupplierID = 0

        Dim warehouseID As Integer = 0

        For Each row As DataRow In DB.Part.Stock_Get_Locations(partid).Table.Rows
            If row.Item("Type") = "WAREHOUSE" Then
                If row.Item("Quantity") >= oOrderPart.Quantity Then
                    warehouseID = row.Item("WarehouseID")
                    Exit For
                End If
            End If
        Next

        If Not warehouseID = 0 Then
            If ShowMessage("There is stock available in a warehouse, would you like to still order from supplier?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Combo.SetSelectedComboItem_By_Value(cboPartLocation, CInt(Enums.LocationType.Warehouse))

                PartSearch()

                Dim index As Integer = 0
                For Each row As DataRow In PartsDataView.Table.Rows
                    If row.Item("WarehouseID") = warehouseID And row.Item("PartID") = partid Then
                        Exit For
                    Else
                        index += 1
                    End If
                Next

                Me.dgParts.CurrentRowIndex = index
                Me.dgParts.Select(index)

                dgParts_Click(Nothing, Nothing)

                Me.txtPartQuantity.Text = oOrderPart.Quantity

                Exit Sub
            End If
        End If

        Dim val As New Entity.OrderParts.OrderPartValidator
        val.Validate(oOrderPart)

        oOrderPart = DB.OrderPart.Insert(oOrderPart, Not (CurrentOrder.DoNotConsolidated))
        If CurrentOrder.OrderTypeID = Enums.OrderType.Job Then

            DB.EngineerVisitPartProductAllocated.InsertOne(CType(Me.pnlDetails.Controls(0), UCOrderForJob).SelectedEngineerVisitDataRow.Item("EngineerVisitID"),
           "Part", oOrderPart.Quantity, oOrderPart.OrderPartID,
                    SelectedPartDataRow.Item("PartID"), Combo.GetSelectedItemValue(cboPartLocation))
        End If

        SupplierUsedID = SelectedPartDataRow.Item("SupplierID")
        LocationUsedID = 0
    End Sub

    Private Sub AddPackToOrder()

        Dim qty As Integer = Helper.MakeIntegerValid(Me.txtPartQuantity.Text)
        If qty = 0 Then Exit Sub

        Dim supplierId As Integer = Helper.MakeIntegerValid(SelectedPartDataRow.Item("SupplierID"))
        Dim packId As Integer = Helper.MakeIntegerValid(SelectedPartDataRow.Item("PartID"))
        Dim dvPartPack As DataView = DB.Part.PartPack_Get(packId)
        For Each drPart As DataRowView In dvPartPack
            Dim partId As Integer = Helper.MakeIntegerValid(drPart("PartID"))
            Dim dvPartSupplier As DataView = DB.PartSupplier.Get_ByPartIDAndSupplierID(partId, supplierId)
            If dvPartSupplier.Count = 0 Then Continue For

            Dim oOrderPart As New Entity.OrderParts.OrderPart
            oOrderPart.IgnoreExceptionsOnSetMethods = True
            oOrderPart.SetOrderID = CurrentOrder.OrderID
            oOrderPart.SetPartSupplierID = Helper.MakeIntegerValid(dvPartSupplier(0)("PartSupplierID"))

            oOrderPart.SetQuantity = qty * Helper.MakeIntegerValid(drPart("Qty"))
            oOrderPart.SetBuyPrice = Helper.MakeDoubleValid(dvPartSupplier(0)("Price"))

            oOrderPart.SetQuantityReceived = 0
            oOrderPart.SetChildSupplierID = 0

            Dim val As New Entity.OrderParts.OrderPartValidator
            val.Validate(oOrderPart)

            oOrderPart = DB.OrderPart.Insert(oOrderPart, Not (CurrentOrder.DoNotConsolidated))
            If CurrentOrder.OrderTypeID = Enums.OrderType.Job Then
                DB.EngineerVisitPartProductAllocated.InsertOne(CType(Me.pnlDetails.Controls(0), UCOrderForJob).SelectedEngineerVisitDataRow.Item("EngineerVisitID"), "Part", oOrderPart.Quantity, oOrderPart.OrderPartID, partId, Combo.GetSelectedItemValue(cboPartLocation))
            End If

        Next

        SupplierUsedID = supplierId
        LocationUsedID = 0
    End Sub

    Private Sub btnAddPart_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddPart.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim ssm As Enums.SecuritySystemModules
            ssm = Enums.SecuritySystemModules.CreatePO
            Dim ssm2 As Enums.SecuritySystemModules
            ssm2 = Enums.SecuritySystemModules.EditPO
            If loggedInUser.HasAccessToModule(ssm) = True Or loggedInUser.HasAccessToModule(ssm2) = True Then

                Select Case Combo.GetSelectedItemValue(cboPartLocation)
                    Case Enums.LocationType.Supplier
                        Dim isPartPack As Boolean = Helper.MakeBooleanValid(SelectedPartDataRow("IsPartPack"))
                        If isPartPack Then
                            AddPackToOrder()
                        Else
                            AddPartToOrder()
                        End If
                    Case Enums.LocationType.Van
                        Dim oOrderLocationPart As New Entity.OrderLocationPart.OrderLocationPart
                        oOrderLocationPart.IgnoreExceptionsOnSetMethods = True
                        oOrderLocationPart.SetOrderID = CurrentOrder.OrderID
                        oOrderLocationPart.SetPartID = SelectedPartDataRow.Item("PartID")
                        oOrderLocationPart.SetLocationID = SelectedPartDataRow.Item("LocationID")
                        oOrderLocationPart.SetQuantity = txtPartQuantity.Text.Trim
                        oOrderLocationPart.SetQuantityReceived = 0

                        Dim val As New Entity.OrderLocationPart.OrderLocationPartValidator
                        val.Validate(oOrderLocationPart)

                        oOrderLocationPart = DB.OrderLocationPart.Insert(oOrderLocationPart, True)

                        If CurrentOrder.OrderTypeID = Enums.OrderType.Job Then

                            DB.EngineerVisitPartProductAllocated.InsertOne(CType(Me.pnlDetails.Controls(0), UCOrderForJob).SelectedEngineerVisitDataRow.Item("EngineerVisitID"),
                           "Part", oOrderLocationPart.Quantity, oOrderLocationPart.OrderLocationPartID,
                                    SelectedPartDataRow.Item("PartID"), Combo.GetSelectedItemValue(cboPartLocation))
                        End If

                        Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                        oPartTransaction.IgnoreExceptionsOnSetMethods = True
                        oPartTransaction.SetOrderLocationPartID = oOrderLocationPart.OrderLocationPartID
                        oPartTransaction.SetTransactionTypeID = CInt(Enums.Transaction.StockReserve)
                        oPartTransaction.SetPartID = oOrderLocationPart.PartID
                        oPartTransaction.SetAmount = -oOrderLocationPart.Quantity
                        oPartTransaction.SetLocationID = oOrderLocationPart.LocationID

                        oPartTransaction = DB.PartTransaction.Insert(oPartTransaction)

                        LocationUsedID = oOrderLocationPart.LocationID
                        SupplierUsedID = 0

                    Case Enums.LocationType.Warehouse
                        Dim oOrderLocationPart As New Entity.OrderLocationPart.OrderLocationPart
                        oOrderLocationPart.IgnoreExceptionsOnSetMethods = True
                        oOrderLocationPart.SetOrderID = CurrentOrder.OrderID
                        oOrderLocationPart.SetPartID = SelectedPartDataRow.Item("PartID")
                        oOrderLocationPart.SetLocationID = SelectedPartDataRow.Item("LocationID")
                        oOrderLocationPart.SetQuantity = txtPartQuantity.Text.Trim
                        oOrderLocationPart.SetQuantityReceived = 0

                        Dim val As New Entity.OrderLocationPart.OrderLocationPartValidator
                        val.Validate(oOrderLocationPart)

                        oOrderLocationPart = DB.OrderLocationPart.Insert(oOrderLocationPart, True)

                        If CurrentOrder.OrderTypeID = Enums.OrderType.Job Then

                            DB.EngineerVisitPartProductAllocated.InsertOne(CType(Me.pnlDetails.Controls(0), UCOrderForJob).SelectedEngineerVisitDataRow.Item("EngineerVisitID"),
                           "Part", oOrderLocationPart.Quantity, oOrderLocationPart.OrderLocationPartID,
                                    SelectedPartDataRow.Item("PartID"), Combo.GetSelectedItemValue(cboPartLocation))
                        End If
                        Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                        oPartTransaction.IgnoreExceptionsOnSetMethods = True
                        oPartTransaction.SetOrderLocationPartID = oOrderLocationPart.OrderLocationPartID
                        oPartTransaction.SetTransactionTypeID = CInt(Enums.Transaction.StockReserve)
                        oPartTransaction.SetPartID = oOrderLocationPart.PartID
                        oPartTransaction.SetAmount = -oOrderLocationPart.Quantity
                        oPartTransaction.SetLocationID = oOrderLocationPart.LocationID

                        oPartTransaction = DB.PartTransaction.Insert(oPartTransaction)

                        LocationUsedID = oOrderLocationPart.LocationID
                        SupplierUsedID = 0
                End Select

                IsLoading = True
                CurrentOrder = DB.Order.Order_Get(CurrentOrder.OrderID)
                RefreshDataGrids()
                PartSearch()
            Else
                Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                Throw New Security.SecurityException(msg)
            End If
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("Part could not be added." & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

#End Region

#Region "Products"

    Private Sub cboProductLocation_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboProductLocation.SelectedIndexChanged
        If Not ProductsDataView Is Nothing Then
            ProductsDataView.Table.Rows.Clear()
        End If

        UpdateProductSearchOptions()
    End Sub

    Private Sub btnAddNewProduct_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddNewProduct.Click
        ShowForm(GetType(FRMProduct), True, New Object() {0, True})

        ProductSearch()
    End Sub

    Private Sub btnProductSearch_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnProductSearch.Click
        ProductSearch()
    End Sub

    Private Sub dgProduct_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles dgProduct.DoubleClick
        If Not SelectedProductDataRow Is Nothing Then
            ShowForm(GetType(FRMProduct), True, New Object() {Helper.MakeIntegerValid(SelectedProductDataRow.Item("ProductID")), True})
            ProductSearch()
        End If
    End Sub

    Private Sub dgProduct_Click(ByVal sender As Object, ByVal e As EventArgs) Handles dgProduct.Click, dgProduct.CurrentCellChanged, dgItemsIncluded.DoubleClick
        UpdateProductSearchOptions()

        If SelectedProductDataRow Is Nothing Then
            Exit Sub
        End If

        Select Case Combo.GetSelectedItemValue(Me.cboProductLocation)
            Case Enums.LocationType.Van
                Me.txtProductQuantity.Text = 1
                Me.txtProductQuantity.ReadOnly = False
                Me.txtProductBuyPrice.Text = "N/A"
                Me.txtProductBuyPrice.ReadOnly = True
                If CurrentOrder.OrderTypeID = Enums.OrderType.StockProfile Or CurrentOrder.OrderTypeID = Enums.OrderType.Warehouse Then
                    Me.txtProductSellPrice.Text = "N/A"
                    Me.txtProductSellPrice.ReadOnly = True
                Else
                    Me.txtProductSellPrice.Text = Format(SelectedProductDataRow.Item("SellPrice"), "F")
                    Me.txtProductSellPrice.ReadOnly = False
                End If
                Me.btnAddProduct.Enabled = True
                Me.btnCreateProductPriceRequest.Enabled = False
            Case Enums.LocationType.Warehouse
                Me.txtProductQuantity.Text = 1
                Me.txtProductQuantity.ReadOnly = False
                Me.txtProductBuyPrice.Text = "N/A"
                Me.txtProductBuyPrice.ReadOnly = True
                If CurrentOrder.OrderTypeID = Enums.OrderType.StockProfile Or CurrentOrder.OrderTypeID = Enums.OrderType.Warehouse Then
                    Me.txtProductSellPrice.Text = "N/A"
                    Me.txtProductSellPrice.ReadOnly = True
                Else
                    Me.txtProductSellPrice.Text = Format(SelectedProductDataRow.Item("SellPrice"), "F")
                    Me.txtProductSellPrice.ReadOnly = False
                End If
                Me.btnAddProduct.Enabled = True
                Me.btnCreateProductPriceRequest.Enabled = False
            Case Enums.LocationType.Supplier
                Me.txtProductQuantity.Text = "1"
                Me.txtProductQuantity.ReadOnly = False

                If IsDBNull(SelectedProductDataRow.Item("SupplierID")) Then
                    Me.txtProductBuyPrice.Text = "N/A"
                    Me.txtProductBuyPrice.ReadOnly = True
                    Me.txtProductSellPrice.Text = "N/A"
                    Me.txtProductSellPrice.ReadOnly = True
                    Me.btnAddProduct.Enabled = False
                Else
                    Me.txtProductBuyPrice.Text = Format(SelectedProductDataRow.Item("Price"), "F")
                    Me.txtProductBuyPrice.ReadOnly = False
                    If CurrentOrder.OrderTypeID = Enums.OrderType.StockProfile Or CurrentOrder.OrderTypeID = Enums.OrderType.Warehouse Then
                        Me.txtProductSellPrice.Text = "N/A"
                        Me.txtProductSellPrice.ReadOnly = True
                    Else
                        Me.txtProductSellPrice.Text = ""
                        Me.txtProductSellPrice.ReadOnly = False
                    End If
                    Me.btnAddProduct.Enabled = True
                End If

                Me.btnCreateProductPriceRequest.Enabled = True
        End Select
    End Sub

    Private Sub btnAddProduct_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddProduct.Click
        Try

            Cursor.Current = Cursors.WaitCursor

            Dim ssm As Enums.SecuritySystemModules
            ssm = Enums.SecuritySystemModules.EditPO
            Dim ssm2 As Enums.SecuritySystemModules
            ssm2 = Enums.SecuritySystemModules.CreatePO
            If loggedInUser.HasAccessToModule(ssm) = True Or loggedInUser.HasAccessToModule(ssm2) = True Then

                Select Case Combo.GetSelectedItemValue(cboProductLocation)
                    Case Enums.LocationType.Supplier
                        Dim oOrderProduct As New Entity.OrderProducts.OrderProduct
                        oOrderProduct.IgnoreExceptionsOnSetMethods = True
                        oOrderProduct.SetOrderID = CurrentOrder.OrderID
                        oOrderProduct.SetProductSupplierID = SelectedProductDataRow.Item("ProductSupplierID")
                        oOrderProduct.SetQuantity = txtProductQuantity.Text.Trim
                        oOrderProduct.SetBuyPrice = txtProductBuyPrice.Text.Trim
                        If Me.txtProductSellPrice.ReadOnly Then
                            oOrderProduct.SetSellPrice = 0.0
                        Else
                            oOrderProduct.SetSellPrice = txtProductSellPrice.Text.Trim
                        End If
                        oOrderProduct.SetQuantityReceived = 0

                        Dim warehouseID As Integer = 0
                        Dim productID As Integer = SelectedProductDataRow.Item("ProductID")

                        For Each row As DataRow In DB.Product.Stock_Get_Locations(productID).Table.Rows
                            If row.Item("Type") = "WAREHOUSE" Then
                                If row.Item("Quantity") >= oOrderProduct.Quantity Then
                                    warehouseID = row.Item("WarehouseID")
                                    Exit For
                                End If
                            End If
                        Next

                        If Not warehouseID = 0 Then
                            If ShowMessage("There is stock available in a warehouse, would you like to still order from supplier?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                Combo.SetSelectedComboItem_By_Value(cboProductLocation, CInt(Enums.LocationType.Warehouse))

                                ProductSearch()

                                Dim index As Integer = 0
                                For Each row As DataRow In ProductsDataView.Table.Rows
                                    If row.Item("WarehouseID") = warehouseID And row.Item("ProductID") = productID Then
                                        Exit For
                                    Else
                                        index += 1
                                    End If
                                Next

                                Me.dgProduct.CurrentRowIndex = index
                                Me.dgProduct.Select(index)

                                dgProduct_Click(Nothing, Nothing)

                                Me.txtProductQuantity.Text = oOrderProduct.Quantity

                                Exit Sub
                            End If
                        End If

                        Dim val As New Entity.OrderProducts.OrderProductValidator
                        val.Validate(oOrderProduct)

                        oOrderProduct = DB.OrderProduct.Insert(oOrderProduct, True)
                        If CurrentOrder.OrderTypeID = Enums.OrderType.Job Then

                            DB.EngineerVisitPartProductAllocated.InsertOne(CType(Me.pnlDetails.Controls(0), UCOrderForJob).SelectedEngineerVisitDataRow.Item("EngineerVisitID"),
                           "Product", oOrderProduct.Quantity, oOrderProduct.OrderProductID,
                                    SelectedProductDataRow.Item("ProductID"), Combo.GetSelectedItemValue(cboProductLocation))
                        End If

                        SupplierUsedID = SelectedProductDataRow.Item("SupplierID")
                        LocationUsedID = 0

                    Case Enums.LocationType.Van
                        Dim oOrderLocationProduct As New Entity.OrderLocationProduct.OrderLocationProduct
                        oOrderLocationProduct.IgnoreExceptionsOnSetMethods = True
                        oOrderLocationProduct.SetOrderID = CurrentOrder.OrderID
                        oOrderLocationProduct.SetProductID = SelectedProductDataRow.Item("ProductID")
                        oOrderLocationProduct.SetLocationID = SelectedProductDataRow.Item("LocationID")
                        oOrderLocationProduct.SetQuantity = txtProductQuantity.Text.Trim
                        If Me.txtProductSellPrice.ReadOnly Then
                            oOrderLocationProduct.SetSellPrice = 0.0
                        Else
                            oOrderLocationProduct.SetSellPrice = txtProductSellPrice.Text.Trim
                        End If
                        oOrderLocationProduct.SetQuantityReceived = 0

                        Dim val As New Entity.OrderLocationProduct.OrderLocationProductValidator
                        val.Validate(oOrderLocationProduct)

                        oOrderLocationProduct = DB.OrderLocationProduct.Insert(oOrderLocationProduct, True)

                        If CurrentOrder.OrderTypeID = Enums.OrderType.Job Then

                            DB.EngineerVisitPartProductAllocated.InsertOne(CType(Me.pnlDetails.Controls(0), UCOrderForJob).SelectedEngineerVisitDataRow.Item("EngineerVisitID"),
                           "Product", oOrderLocationProduct.Quantity, oOrderLocationProduct.OrderLocationProductID,
                                    SelectedProductDataRow.Item("ProductID"), Combo.GetSelectedItemValue(cboProductLocation))
                        End If

                        Dim oProductTransaction As New Entity.ProductTransactions.ProductTransaction
                        oProductTransaction.IgnoreExceptionsOnSetMethods = True
                        oProductTransaction.SetOrderLocationProductID = oOrderLocationProduct.OrderLocationProductID
                        oProductTransaction.SetTransactionTypeID = CInt(Enums.Transaction.StockReserve)
                        oProductTransaction.SetProductID = oOrderLocationProduct.ProductID
                        oProductTransaction.SetAmount = -oOrderLocationProduct.Quantity
                        oProductTransaction.SetLocationID = oOrderLocationProduct.LocationID

                        oProductTransaction = DB.ProductTransaction.Insert(oProductTransaction)

                        SupplierUsedID = 0
                        LocationUsedID = oOrderLocationProduct.LocationID

                    Case Enums.LocationType.Warehouse
                        Dim oOrderLocationProduct As New Entity.OrderLocationProduct.OrderLocationProduct
                        oOrderLocationProduct.IgnoreExceptionsOnSetMethods = True
                        oOrderLocationProduct.SetOrderID = CurrentOrder.OrderID
                        oOrderLocationProduct.SetProductID = SelectedProductDataRow.Item("ProductID")
                        oOrderLocationProduct.SetLocationID = SelectedProductDataRow.Item("LocationID")
                        oOrderLocationProduct.SetQuantity = txtProductQuantity.Text.Trim
                        If Me.txtProductSellPrice.ReadOnly Then
                            oOrderLocationProduct.SetSellPrice = 0.0
                        Else
                            oOrderLocationProduct.SetSellPrice = txtProductSellPrice.Text.Trim
                        End If
                        oOrderLocationProduct.SetQuantityReceived = 0

                        Dim val As New Entity.OrderLocationProduct.OrderLocationProductValidator
                        val.Validate(oOrderLocationProduct)

                        oOrderLocationProduct = DB.OrderLocationProduct.Insert(oOrderLocationProduct, True)

                        If CurrentOrder.OrderTypeID = Enums.OrderType.Job Then

                            DB.EngineerVisitPartProductAllocated.InsertOne(CType(Me.pnlDetails.Controls(0), UCOrderForJob).SelectedEngineerVisitDataRow.Item("EngineerVisitID"),
                           "Product", oOrderLocationProduct.Quantity, oOrderLocationProduct.OrderLocationProductID,
                                    SelectedProductDataRow.Item("ProductID"), Combo.GetSelectedItemValue(cboProductLocation))
                        End If

                        Dim oProductTransaction As New Entity.ProductTransactions.ProductTransaction
                        oProductTransaction.IgnoreExceptionsOnSetMethods = True
                        oProductTransaction.SetOrderLocationProductID = oOrderLocationProduct.OrderLocationProductID
                        oProductTransaction.SetTransactionTypeID = CInt(Enums.Transaction.StockReserve)
                        oProductTransaction.SetProductID = oOrderLocationProduct.ProductID
                        oProductTransaction.SetAmount = -oOrderLocationProduct.Quantity
                        oProductTransaction.SetLocationID = oOrderLocationProduct.LocationID

                        oProductTransaction = DB.ProductTransaction.Insert(oProductTransaction)

                        SupplierUsedID = 0
                        LocationUsedID = oOrderLocationProduct.LocationID
                End Select

                RefreshDataGrids()
                ProductSearch()
            Else
                Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                Throw New Security.SecurityException(msg)
            End If
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("Product could not be added." & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub txtPartSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPartSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor.Current = Cursors.WaitCursor
            PartSearch()
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub txtProductSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor.Current = Cursors.WaitCursor
            ProductSearch()
            Cursor.Current = Cursors.Default
        End If
    End Sub

#End Region

#Region "Items Included"

    Private Sub btnItemRemove_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnItemQtyUpdate.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim ssm As Enums.SecuritySystemModules
            ssm = Enums.SecuritySystemModules.EditPO
            Dim ssm2 As Enums.SecuritySystemModules
            ssm2 = Enums.SecuritySystemModules.CreatePO
            If loggedInUser.HasAccessToModule(ssm) = True Or loggedInUser.HasAccessToModule(ssm2) = True Then

                If SelectedItemIncludedDataRow Is Nothing Then
                    ShowMessage("Please select an item to remove", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If Me.nudItemQty.Value = 0 Then
                    If ShowMessage("Completely remove item?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Exit Sub
                    End If
                End If

                If SelectedItemIncludedDataRow.Item("QuantityReceived") > 0 Then
                    '   ShowMessage("Items have been recieved. Quantity cannot be ammended!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '  Exit Sub
                End If

                Select Case CStr(SelectedItemIncludedDataRow.Item("Type"))
                    Case "OrderProduct"
                        Dim oOrderProduct As New Entity.OrderProducts.OrderProduct
                        oOrderProduct = DB.OrderProduct.OrderProduct_Get(SelectedItemIncludedDataRow.Item("ID"))

                        If Me.nudItemQty.Value = 0 Then
                            DB.OrderProduct.Delete(oOrderProduct.OrderProductID)
                        Else
                            oOrderProduct.SetQuantity = Me.nudItemQty.Value
                            DB.OrderProduct.Update(oOrderProduct)
                        End If
                        ''IF ITS A JOB ORDER REMOVE THE PARTS FROM THE JOB ALLOCATION
                        'If CurrentOrder.OrderTypeID = CInt(Entity.Sys.Enums.OrderType.Job) Then
                        '    DB.EngineerVisitPartProductAllocated.EngineerVisitProductAllocated_Delete(CInt(Entity.Sys.Enums.LocationType.Supplier), oOrderProduct.OrderProductID)
                        'End If
                        '*************************************************************
                    Case "OrderPart"
                        Dim oOrderPart As New Entity.OrderParts.OrderPart
                        oOrderPart = DB.OrderPart.OrderPart_Get(SelectedItemIncludedDataRow.Item("ID"))

                        If Me.nudItemQty.Value = 0 Then
                            DB.OrderPart.Delete(oOrderPart.OrderPartID)
                        Else
                            oOrderPart.SetQuantity = Me.nudItemQty.Value
                            DB.OrderPart.Update(oOrderPart)
                        End If
                        'IF ITS A JOB ORDER REMOVE THE PARTS FROM THE JOB ALLOCATION
                        If CurrentOrder.OrderTypeID = CInt(Enums.OrderType.Job) Then
                            'DB.EngineerVisitPartProductAllocated.EngineerVisitPartAllocated_Delete(CInt(Entity.Sys.Enums.LocationType.Supplier), oOrderPart.OrderPartID)
                            DB.EngineerVisitPartProductAllocated.EngineerVisitPartAllocated_RemoveFromOrder(CInt(Enums.LocationType.Supplier), oOrderPart.OrderPartID)
                        End If
                        '*************************************************************
                    Case "OrderLocationProduct"
                        Dim oOrderLocationProduct As New Entity.OrderLocationProduct.OrderLocationProduct
                        oOrderLocationProduct = DB.OrderLocationProduct.OrderLocationProduct_Get(SelectedItemIncludedDataRow.Item("ID"))

                        Dim oProductTransaction As New Entity.ProductTransactions.ProductTransaction
                        oProductTransaction = DB.ProductTransaction.ProductTransaction_GetByOrderLocationProduct(oOrderLocationProduct.OrderLocationProductID)
                        If Me.nudItemQty.Value = 0 Then
                            DB.OrderLocationProduct.Delete(oOrderLocationProduct.OrderLocationProductID)
                            DB.ProductTransaction.Delete(oProductTransaction.ProductTransactionID)
                        Else
                            oOrderLocationProduct.SetQuantity = Me.nudItemQty.Value
                            DB.OrderLocationProduct.Update(oOrderLocationProduct)

                            oProductTransaction.SetAmount = Me.nudItemQty.Value
                            DB.ProductTransaction.Update(oProductTransaction)
                        End If
                        'IF ITS A JOB ORDER REMOVE THE PARTS FROM THE JOB ALLOCATION
                        If CurrentOrder.OrderTypeID = CInt(Enums.OrderType.Job) Then
                            DB.EngineerVisitPartProductAllocated.EngineerVisitProductAllocated_Delete(CInt(Enums.LocationType.Warehouse), oOrderLocationProduct.OrderLocationProductID)
                        End If
                        '*************************************************************
                    Case "OrderLocationPart"
                        Dim oOrderLocationPart As New Entity.OrderLocationPart.OrderLocationPart
                        oOrderLocationPart = DB.OrderLocationPart.OrderLocationPart_Get(SelectedItemIncludedDataRow.Item("ID"))

                        Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                        oPartTransaction = DB.PartTransaction.PartTransaction_GetByOrderLocationPart(oOrderLocationPart.OrderLocationPartID)

                        If Me.nudItemQty.Value = 0 Then
                            DB.OrderLocationPart.Delete(oOrderLocationPart.OrderLocationPartID)
                            DB.PartTransaction.Delete(oPartTransaction.PartTransactionID)
                        Else
                            oOrderLocationPart.SetQuantity = Me.nudItemQty.Value
                            DB.OrderLocationPart.Update(oOrderLocationPart)

                            oPartTransaction.SetAmount = Me.nudItemQty.Value
                            DB.PartTransaction.Update(oPartTransaction)
                        End If

                        'IF ITS A JOB ORDER REMOVE THE PARTS FROM THE JOB ALLOCATION
                        If CurrentOrder.OrderTypeID = CInt(Enums.OrderType.Job) Then
                            DB.EngineerVisitPartProductAllocated.EngineerVisitPartAllocated_RemoveFromOrder(CInt(Enums.LocationType.Warehouse), oOrderLocationPart.OrderLocationPartID)
                            'DB.EngineerVisitPartProductAllocated.EngineerVisitPartAllocated_Delete(CInt(Entity.Sys.Enums.LocationType.Warehouse), oOrderLocationPart.OrderLocationPartID)
                        End If
                        '*************************************************************
                End Select

                If isOrderCancelled() And CurrentOrder.OrderStatusID > CInt(Enums.OrderStatus.AwaitingConfirmation) Then
                    CurrentOrder.SetOrderStatusID = CInt(Enums.OrderStatus.Cancelled)
                    DB.Order.Update(CurrentOrder)

                    'IS THIS ON A CONSOLIDATED
                    If CurrentOrder.OrderConsolidationID > 0 Then
                        Dim allCancelled As Boolean = True
                        'CHECK AND CANCEL Consolidated order if nessary
                        For Each drOrd As DataRow In DB.OrderConsolidations.Order_GetForConsolidationByID(CurrentOrder.OrderConsolidationID, 0, 0).Table.Rows
                            If drOrd("OrderStatusID") <> CInt(Enums.OrderStatus.Cancelled) Then
                                allCancelled = False
                                Exit For
                            End If
                        Next

                        If allCancelled Then
                            Dim oConOrder As Entity.OrderConsolidations.OrderConsolidation = DB.OrderConsolidations.OrderConsolidation_Get(CurrentOrder.OrderConsolidationID)
                            oConOrder.SetConsolidatedOrderStatusID = CInt(Enums.OrderStatus.Cancelled)
                            DB.OrderConsolidations.Update(oConOrder)
                        End If
                    End If

                    IsLoading = True
                    Populate(CurrentOrder.OrderID)
                    IsLoading = False
                    Exit Sub
                End If

                If isOrderComplete() = True Then
                    If CurrentOrder.OrderStatusID > CInt(Enums.OrderStatus.AwaitingConfirmation) Then
                        CurrentOrder.SetOrderStatusID = CInt(Enums.OrderStatus.Complete)
                        DB.Order.Update(CurrentOrder)

                        'IS THIS ON A CONSOLIDATED
                        If CurrentOrder.OrderConsolidationID > 0 Then
                            Dim allComplete As Boolean = True
                            'CHECK AND COMPLETE Consolidated order if nessary
                            For Each drOrd As DataRow In DB.OrderConsolidations.Order_GetForConsolidationByID(CurrentOrder.OrderConsolidationID, 0, 0).Table.Rows
                                If drOrd("OrderStatusID") < CInt(Enums.OrderStatus.Complete) Then
                                    allComplete = False
                                    Exit For
                                End If
                            Next

                            If allComplete Then
                                Dim oConOrder As Entity.OrderConsolidations.OrderConsolidation = DB.OrderConsolidations.OrderConsolidation_Get(CurrentOrder.OrderConsolidationID)
                                oConOrder.SetConsolidatedOrderStatusID = CInt(Enums.OrderStatus.Complete)
                                DB.OrderConsolidations.Update(oConOrder)
                            End If
                        End If
                        IsLoading = True
                        Populate(CurrentOrder.OrderID)
                        IsLoading = False
                    End If

                    If CurrentOrder.OrderTypeID = CInt(Enums.OrderType.Job) Then
                        Dim oEngineerVisit As Entity.EngineerVisits.EngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(ucJobOrder.SelectedEngineerVisitDataRow.Item("EngineerVisitID"))
                        If oEngineerVisit.StatusEnumID = CInt(Enums.VisitStatus.Waiting_For_Parts) Then

                            'LETS SEE FIRST IF ALL THE ORDERS RELATING TO THIS VISIT ARE COMPLETE? - ALP 22/01/08
                            Dim dv As DataView = DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(oEngineerVisit.EngineerVisitID)
                            Dim allComplete As Boolean = True
                            For Each dr As DataRow In dv.Table.Rows
                                If Not Helper.MakeIntegerValid(dr("OrderStatusID")) = 0 Then
                                    If Not (dr("OrderStatusID") = CInt(Enums.OrderStatus.Complete)) Then
                                        allComplete = False
                                    End If
                                End If
                            Next
                            If allComplete Then
                                If ShowMessage("The visit this order relates to is waiting for parts. Would you like to set the status of the visit to Ready To Schedule?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                    oEngineerVisit.SetStatusEnumID = CInt(Enums.VisitStatus.Ready_For_Schedule)
                                    oEngineerVisit.SetPartsToFit = True
                                    DB.EngineerVisits.Update(oEngineerVisit, 0, True)
                                End If
                            End If

                        End If
                    End If

                    'IF ORDER IS COMPLETE AND ITS A CUSTOMER ORDER THEN ADD ROW TO RAISE INVOICE TABLE
                    If CType(CurrentOrder.OrderTypeID, Entity.Sys.Enums.OrderType) = Entity.Sys.Enums.OrderType.Customer Then
                        ShowForm(GetType(FrmRaiseInvoiceDetails), True, New Object() {CurrentOrder.OrderID, CurrentOrder.InvoiceAddressID})
                    End If
                End If

                PartSearch()
                ProductSearch()
                RefreshDataGrids()
            Else
                Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                Throw New Security.SecurityException(msg)
            End If
        Catch ex As Exception
            ShowMessage("Item cannot be removed." & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.nudItemQty.Value = 0
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgItemsIncluded_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        If Me.SelectedItemIncludedDataRow Is Nothing Then
            Exit Sub
        End If
        If CurrentOrder.OrderConsolidationID > 0 Then
            If CStr(SelectedItemIncludedDataRow.Item("Type")) = "OrderPart" Or CStr(SelectedItemIncludedDataRow.Item("Type")) = "OrderProduct" Then
                ShowMessage("This order has been added to a consolidation so should be managed from there.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If
        If Not CurrentOrder.OrderStatusID = CInt(Enums.OrderStatus.Confirmed) Then
            ShowMessage("Order must be confirmed to mark items into stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If CInt(SelectedItemIncludedDataRow.Item("QuantityOnOrder")) = CInt(SelectedItemIncludedDataRow.Item("QuantityReceived")) Then
            ShowMessage("This stock has been fully received", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        ShowForm(GetType(FRMReceiveStock), True, New Object() {CurrentOrder.OrderID, CStr(SelectedItemIncludedDataRow.Item("Type")), CInt(SelectedItemIncludedDataRow("ID"))})

        Populate(CurrentOrder.OrderID)

        If isOrderComplete() = True Then
            If CurrentOrder.OrderStatusID > CInt(Enums.OrderStatus.AwaitingConfirmation) Then
                CurrentOrder.SetOrderStatusID = CInt(Enums.OrderStatus.Complete)
                DB.Order.Update(CurrentOrder)
                IsLoading = True
                Populate(CurrentOrder.OrderID)
                IsLoading = False
            End If

            If CurrentOrder.OrderTypeID = CInt(Enums.OrderType.Job) Then
                Dim oEngineerVisit As Entity.EngineerVisits.EngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(ucJobOrder.SelectedEngineerVisitDataRow.Item("EngineerVisitID"))
                If oEngineerVisit.StatusEnumID = CInt(Enums.VisitStatus.Waiting_For_Parts) Then

                    'LETS SEE FIRST IF ALL THE ORDERS RELATING TO THIS VISIT ARE COMPLETE? - ALP 22/01/08
                    Dim dv As DataView = DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(oEngineerVisit.EngineerVisitID)
                    Dim allComplete As Boolean = True
                    For Each dr As DataRow In dv.Table.Rows
                        If Not Helper.MakeIntegerValid(dr("OrderStatusID")) = 0 Then
                            If Not (dr("OrderStatusID") = CInt(Enums.OrderStatus.Complete)) Then
                                allComplete = False
                            End If
                        End If
                    Next
                    If allComplete Then
                        ShowForm(GetType(FRMPickDespatchDetails), True, New Object() {oEngineerVisit})
                    End If

                End If
            End If

            'IF ORDER IS COMPLETE AND ITS A CUSTOMER ORDER THEN ADD ROW TO RAISE INVOICE TABLE
            If CType(CurrentOrder.OrderTypeID, Entity.Sys.Enums.OrderType) = Entity.Sys.Enums.OrderType.Customer Then
                ShowForm(GetType(FrmRaiseInvoiceDetails), True, New Object() {CurrentOrder.OrderID, CurrentOrder.InvoiceAddressID})
            End If
        End If

    End Sub

    Private Sub dgItemsIncluded_Click(sender As Object, e As EventArgs) Handles dgItemsIncluded.Click
        If Me.SelectedItemIncludedDataRow Is Nothing Then
            Exit Sub
        End If
        Me.nudItemQty.Value = CInt(SelectedItemIncludedDataRow("QuantityOnOrder"))
    End Sub

#End Region

#End Region

#Region "Functions"

    Public Function ValidateSupplierInvoice(Optional ByVal Update As Boolean = False) As Boolean
        Dim Errors As String = "Please correct the following error(s):" & vbNewLine
        Dim NoError As Boolean = True
        If txtSupplierInvoiceRefNew.Text = Nothing Then
            Errors += "- 'Invoice Ref' cannot be empty." & vbNewLine
            NoError = False
        End If
        If txtNominalCodeNew.Text = Nothing Then
            Errors += "- 'Nominal Code' cannot be empty." & vbNewLine
            NoError = False
        End If
        If txtGoodsAmount.Text = Nothing Or Format(txtGoodsAmount.Text, "C") = "£0.00" Then
            Errors += "- 'Goods' cannot be empty and must not equals 0." & vbNewLine
            NoError = False
        End If
        If txtVATAmount.Text = Nothing Then
            Errors += "- 'VAT' cannot be empty." & vbNewLine
            NoError = False
        End If
        If txtTotalAmount.Text = Nothing Or Format(txtTotalAmount.Text, "C") = "£0.00" Then
            Errors += "- 'Total' cannot be empty and must not equals 0." & vbNewLine
            NoError = False
        End If

        If NoError = False Then
            ShowMessage(Errors, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If NoError Then
            Dim itemAmount As Double = 0.0
            Dim invoiceTotal As Double = 0.0
            For Each row As DataRow In ItemsIncludedDataView.Table.Rows
                itemAmount += (row.Item("BuyPrice") * row.Item("QuantityOnOrder"))
            Next
            'PLUS ADDITIONAL
            For Each row As DataRow In DB.OrderCharge.OrderCharge_GetForOrder(CurrentOrder.OrderID).Table.Rows
                itemAmount += row.Item("Amount")
            Next

            'GET EXISTING SUPPLIER INVOICES
            For Each row As DataRow In DB.SupplierInvoices.Order_GetSupplierInvoices(CurrentOrder.OrderID).Table.Rows
                invoiceTotal += row.Item("SupplierInvoiceAmount")
            Next

            Dim CurrentTotal As Double = 0

            If Update Then
                Dim UpdateingAmount As Double = Replace(dgvReceivedInvoices.Item("SupplierInvoiceAmount", dgvReceivedInvoices.CurrentRow.Index).Value, "£", "")
                CurrentTotal = invoiceTotal - UpdateingAmount + CDbl(Replace(txtGoodsAmount.Text, "£", "")) - 0.05
            Else
                CurrentTotal = invoiceTotal + CDbl(Replace(txtGoodsAmount.Text, "£", "")) - 0.05
            End If

            If CurrentTotal > Format(itemAmount, "F") Then
                ShowMessage("The entered supplier invoice amount is greater than the total of the order. You will now be prompted to enter the override password to continue", MessageBoxButtons.OK, MessageBoxIcon.Information)

                If Not EnterOverridePassword() Then
                    Return False
                End If
            End If
        End If

        Return NoError
    End Function

    Public Function ValidateCreditInvoice(Optional ByVal Update As Boolean = False) As Boolean
        Dim Errors As String = "Please correct the following error(s):" & vbNewLine
        Dim NoError As Boolean = True
        If txtCreditRef.Text = Nothing Then
            Errors += "- 'Invoice Ref' cannot be empty." & vbNewLine
            NoError = False
        End If
        If txtCreditNominal.Text = Nothing Then
            Errors += "- 'Nominal Code' cannot be empty." & vbNewLine
            NoError = False
        End If
        If txtCreditGoods.Text = Nothing Or Format(txtCreditGoods.Text, "C") = "£0.00" Then
            Errors += "- 'Goods' cannot be empty and must not equals 0." & vbNewLine
            NoError = False
        End If
        If txtCreditVAT.Text = Nothing Then
            Errors += "- 'VAT' cannot be empty." & vbNewLine
            NoError = False
        End If

        If NoError = False Then
            ShowMessage(Errors, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If NoError Then
            Dim itemAmount As Double = 0.0
            Dim invoiceTotal As Double = 0.0

            Dim CurrentTotal As Double = 0

        End If

        Return NoError
    End Function

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        Me.btnEngineerReceived.Visible = False

        If Not ID = 0 Then
            CurrentOrder = DB.Order.Order_Get(ID)
        End If

        Me.dtpDatePlaced.Value = CurrentOrder.DatePlaced
        Me.txtOrderReference.Text = CurrentOrder.OrderReference

        If CurrentOrder.DeliveryDeadline = Nothing Then
            Me.chkDeadlineNA.Checked = True
        Else
            Me.dtpDeliveryDeadline.Value = CurrentOrder.DeliveryDeadline
            Me.chkDeadlineNA.Checked = False
        End If

        Combo.SetSelectedComboItem_By_Value(cboDept, CurrentOrder.DepartmentRef)

        Combo.SetSelectedComboItem_By_Value(Me.cboOrderTypeID, CurrentOrder.OrderTypeID)
        Combo.SetSelectedComboItem_By_Value(Me.cboOrderStatus, CurrentOrder.OrderStatusID)

        chkDoNotConsolidate.Checked = CurrentOrder.DoNotConsolidated

        Select Case CurrentOrder.OrderStatusID
            Case Enums.OrderStatus.Confirmed, Enums.OrderStatus.AwaitingApproval
                DisableFields()
                btnCharges.Enabled = True
                Me.lblOrderStatus.Text = "ORDER WAITING FOR ITEMS RECEIVED"
                Me.lblOrderStatus.Visible = True
                Me.btnPrint.Enabled = Not CurrentOrder.OrderStatusID = Enums.OrderStatus.AwaitingApproval
                Me.btnApproveOrder.Visible = CurrentOrder.OrderStatusID = Enums.OrderStatus.AwaitingApproval AndAlso loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.POAuthorisation)
            Case Enums.OrderStatus.Cancelled
                DisableFields()
                btnCharges.Enabled = False
                Me.lblOrderStatus.Text = "ORDER HAS BEEN CANCELLED (click to view)"
                Me.lblOrderStatus.Visible = True
            Case Enums.OrderStatus.Complete
                DisableFields()
                btnCharges.Enabled = False
                Me.lblOrderStatus.Text = "ORDER COMPLETE"
                Me.lblOrderStatus.Visible = True

                If CurrentOrder.ExportedToSage Then
                    Me.lblOrderStatus.Text += " - (Invoiced and Sent to Sage)"
                Else
                    If CurrentOrder.Invoiced Then
                        Me.lblOrderStatus.Text += " - (Invoiced)"
                    End If
                End If
            Case Enums.OrderStatus.AwaitingConfirmation
                Me.lblOrderStatus.Text = "ORDER AWAITING CONFIRMATION FROM CUSTOMER"
                Me.lblOrderStatus.Visible = True
        End Select

        RefreshDataGrids()

        Me.btnUpdateOrderRef.Visible = loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance)

        Select Case CurrentOrder.OrderTypeID
            Case Enums.OrderType.Customer
                ucCustomerOrder.Customer = DB.Customer.Customer_GetForOrder(CurrentOrder.OrderID)
                Dim oSiteOrder As New Entity.SiteOrders.SiteOrder
                oSiteOrder = DB.SiteOrder.SiteOrder_GetForOrder(CurrentOrder.OrderID)
                If oSiteOrder Is Nothing Then
                    ucCustomerOrder.Warehouse = DB.Warehouse.Warehouse_GetByLocationID(DB.OrderLocation.OrderLocation_GetForOrder(CurrentOrder.OrderID).LocationID)
                Else
                    ucCustomerOrder.theProperty = DB.Sites.Get(oSiteOrder.SiteID)
                End If
                CustomerID = ucCustomerOrder.Customer.CustomerID
                ucCustomerOrder.Contact = DB.Contact.Contact_Get(CurrentOrder.ContactID)
                ucCustomerOrder.InvoiceAddress = DB.InvoiceAddress.InvoiceAddress_Get(CurrentOrder.InvoiceAddressID)
                Combo.SetSelectedComboItem_By_Value(ucCustomerOrder.cboUsers, CurrentOrder.AllocatedToUser)
                ucCustomerOrder.txtSpecialInstructions.Text = CurrentOrder.SpecialInstructions
                Me.btnRelatedJob.Enabled = False

            Case Enums.OrderType.StockProfile
                ucVanOrder.Van = DB.Van.Van_Get(PassedID)
                Dim deliveryAddressID As Integer = DB.OrderLocation.OrderLocation_GetForOrder(CurrentOrder.OrderID).DeliveryAddressID
                If Not deliveryAddressID = 0 Then
                    ucVanOrder.DeliveryAddress = DB.Warehouse.Warehouse_Get(deliveryAddressID)
                End If
                Me.btnRelatedJob.Enabled = False
                Me.btnEngineerReceived.Visible = True
            Case Enums.OrderType.Warehouse
                ucWarehouseOrder.Warehouse = DB.Warehouse.Warehouse_Get(PassedID)
                Me.btnRelatedJob.Enabled = False
            Case Enums.OrderType.Job
                ucJobOrder.EngineerVisitsDataView = DB.EngineerVisits.EngineerVisits_Get(PassedID)
                If ucJobOrder.EngineerVisitsDataView IsNot Nothing And ucJobOrder.EngineerVisitsDataView.Count > 0 Then
                    If ucJobOrder.EngineerVisitsDataView.Table.Columns.Contains("CustomerID") AndAlso
                        Not IsDBNull(ucJobOrder.EngineerVisitsDataView(0)("CustomerID")) Then
                        CustomerID = Helper.MakeIntegerValid(ucJobOrder.EngineerVisitsDataView(0)("CustomerID"))
                    End If
                End If
                ucJobOrder.Warehouse = DB.Warehouse.Warehouse_Get(DB.EngineerVisitOrder.EngineerVisitOrder_GetForOrder(CurrentOrder.OrderID).WarehouseID)
                Me.btnRelatedJob.Enabled = True
            Case Else
                Me.lblOrderStatus.Text = "PICK WHAT THE ORDER IS FOR"
                Me.lblOrderStatus.Visible = True
        End Select

        If CurrentOrder.OrderConsolidationID = 0 Then
            Me.lblOrderStatus.Text += " *Supplier Invoice NOT sent to Sage*"
        Else
            If DB.OrderConsolidations.OrderConsolidation_Get(CurrentOrder.OrderConsolidationID).HasSupplierPO Then
                'Supplier Invoices
                Me.txtSupplierInvoiceRefNew.ReadOnly = True
                Me.txtExtraReferenceNew.ReadOnly = True
                Me.txtNominalCodeNew.ReadOnly = True
                Me.txtExtraReferenceNew.ReadOnly = True
                Me.dtpSupplierInvoiceDateNew.Enabled = False
                Me.cboInvoiceTaxCodeNew.Enabled = False
                Me.txtNominalCodeNew.ReadOnly = True
                Me.txtGoodsAmount.ReadOnly = True
                Me.txtVATAmount.ReadOnly = True
                Me.txtTotalAmount.ReadOnly = True
                Me.btnAddSupplierInvoice.Enabled = False

                cboDept.Enabled = True

                Me.lblOrderStatus.Text += " *Supplier Invoice managed within consolidation*"
            Else
                Me.lblOrderStatus.Text += " *Supplier Invoice NOT sent to Sage*"
            End If
        End If

        If isOrderComplete() = True AndAlso dgvReceivedInvoices.RowCount > 0 Then
            Me.chkRevertStatus.Enabled = False
        End If
        'End If
    End Sub

    Private Sub PopulateOrderTotal()
        Dim total As Double = 0.0
        For Each row As DataRow In ItemsIncludedDataView.Table.Rows
            total += (row.Item("BuyPrice") * row.Item("QuantityOnOrder"))
        Next
        For Each row As DataRow In DB.OrderCharge.OrderCharge_GetForOrder(CurrentOrder.OrderID).Table.Rows
            total += row.Item("Amount")
        Next
        Me.lblOrderTotal.Text = Format(total, "C")

        Dim GoodsTotal As Double = 0.0
        Dim VATTotal As Double = 0.0
        Dim GrandTotal As Double = 0.0
        For Each row As DataRow In DB.SupplierInvoices.Order_GetSupplierInvoices(CurrentOrder.OrderID).Table.Rows
            GoodsTotal += row.Item("SupplierInvoiceAmount")
            VATTotal += row.Item("SupplierVATAmount")
            GrandTotal += row.Item("SupplierGoodsAmount")
        Next
        Me.lblGoodsTotal.Text = Format(GoodsTotal, "C")

        lblCredits.Text = "0"
        For Each row As DataRow In DB.ExecuteWithReturn("select (AmountReceived) as CreditReceived from tblPartCredits pc inner join (sELECT MAX(tblPartCreditParts.PartsToBeCreditedID) AS MAXIMUN ,PartCreditID  FROM tblPartCreditParts group by PartCreditID) pcp on pcp.PartCreditID = pc.PartCreditsID inner join tblPartsToBeCredited tbc ON tbc.PartsToBeCreditedID = pcp.maximun WHERE OrderID = " & CurrentOrder.OrderID).Rows
            lblCredits.Text = lblCredits.Text + row("CreditReceived")

        Next

        Dim OrderBalance As Double = total - GoodsTotal + lblCredits.Text

        lblCredits.Text = Format(CDbl(lblCredits.Text), "C")
        Me.lblOrderBalance.Text = Format(OrderBalance, "C")

        Select Case Format(OrderBalance, "C")
            Case "£0.00"
                lblOrderBalance.ForeColor = Color.Green
            Case Is < 0
                lblOrderBalance.ForeColor = Color.Red
            Case Is > 0
                lblOrderBalance.ForeColor = Color.DarkOrange
            Case Else

        End Select
    End Sub

    Private Sub RefreshDataGrids()
        Me.ItemsIncludedDataView = DB.Order.Order_ItemsGetAll(CurrentOrder.OrderID)
        For Each row As DataRow In ItemsIncludedDataView.Table.Rows
            If Not IsDBNull(row.Item("SupplierID")) Then
                SupplierUsedID = row.Item("SupplierID")
                Exit For
            End If
        Next

        If SupplierUsedID > 0 Then txtNominalCodeNew.Text = DB.Supplier.Supplier_Get(SupplierUsedID).DefaultNominal

        Me.PriceRequestDataView = DB.Order.Order_PriceRequests_GetAll(CurrentOrder.OrderID)

        Me.dgvReceivedInvoices.DataSource = DB.SupplierInvoices.Order_GetSupplierInvoices(CurrentOrder.OrderID)

        Me.dgCredits.DataSource = DB.PartsToBeCredited.PartsToBeCredited_Get_OrderID(CurrentOrder.OrderID)

    End Sub

    Public Sub DisableFields()
        'Me.txtOrderReference.Enabled = False
        Me.txtPartBuyPrice.Enabled = False
        Me.txtPartQuantity.Enabled = False
        Me.txtPartSearch.Enabled = False
        Me.txtProductBuyPrice.Enabled = False
        Me.txtProductQuantity.Enabled = False
        Me.txtProductSearch.Enabled = False
        Me.txtProductSellPrice.Enabled = False
        'Me.txtItemQuantity.Enabled = False
        'Me.btnItemRemove.Enabled = False
        Me.ucVanOrder.Enabled = False
        Me.ucWarehouseOrder.Enabled = False
        Me.ucCustomerOrder.btnFindCustomer.Enabled = False
        Me.ucCustomerOrder.btnFindSite.Enabled = False
        Me.ucCustomerOrder.btnFindWarehouse.Enabled = False
        Me.btnAddPart.Enabled = False
        Me.btnAddProduct.Enabled = False
        Me.btnPartSearch.Enabled = False
        Me.btnProductSearch.Enabled = False
        'Me.btnCharges.Enabled = False
        Me.cboOrderStatus.Enabled = False
        Me.cboOrderTypeID.Enabled = False
        Me.cboPartLocation.Enabled = False
        Me.cboProductLocation.Enabled = False
        Me.dgParts.Enabled = False
        Me.dgProduct.Enabled = False

        Select Case CurrentOrder.OrderStatusID
            Case Enums.OrderStatus.Confirmed, Enums.OrderStatus.AwaitingApproval
                Me.txtOrderReference.ReadOnly = True
                Me.dtpDatePlaced.Enabled = True
                Me.chkDeadlineNA.Enabled = True
            Case Enums.OrderStatus.Cancelled
                Me.txtOrderReference.ReadOnly = True
                Me.dtpDatePlaced.Enabled = False
                Me.chkDeadlineNA.Enabled = False
            Case Enums.OrderStatus.Complete
                Me.txtOrderReference.ReadOnly = True
                Me.dtpDatePlaced.Enabled = False
                Me.chkDeadlineNA.Enabled = False
                Me.dtpDeliveryDeadline.Enabled = False
            Case Enums.OrderStatus.AwaitingConfirmation
                Me.txtOrderReference.ReadOnly = True
                Me.dtpDatePlaced.Enabled = True
                Me.chkDeadlineNA.Enabled = True
        End Select

    End Sub

    Private Sub EnableTabs(ByVal Enabled As Boolean)

        Select Case CurrentOrder.OrderStatusID
            Case CInt(Enums.OrderStatus.Complete)
                If CurrentOrder.OrderTypeID = CInt(Enums.OrderType.StockProfile) Then
                    Dim someNotWithEngineer As Boolean = False

                    For Each itemRow As DataRow In ItemsIncludedDataView.Table.Rows
                        If Helper.MakeDateTimeValid(itemRow.Item("WithEngineer_Van")) = Nothing And Helper.MakeDateTimeValid(itemRow.Item("WithEngineer_Job")) = Nothing Then
                            someNotWithEngineer = True
                            Exit For
                        End If
                    Next

                    If someNotWithEngineer Then
                        ' Me.dgItemsIncluded.Enabled = False
                        Me.nudItemQty.Enabled = False
                        Me.btnItemQtyUpdate.Enabled = False
                        Me.btnReceiveAll.Enabled = False
                        Me.btnEngineerReceived.Visible = True
                    Else
                        '  Me.tabItemsIncluded.Enabled = False
                        dgItemsIncluded.ReadOnly = True
                        btnItemQtyUpdate.Enabled = False
                        btnEngineerReceived.Enabled = False
                        btnReceiveAll.Enabled = False
                    End If
                Else
                    '  Me.tabItemsIncluded.Enabled = False
                    dgItemsIncluded.ReadOnly = True
                    btnItemQtyUpdate.Enabled = False
                    btnEngineerReceived.Enabled = False
                    btnReceiveAll.Enabled = False
                End If
            Case Else
                Me.tabItemsIncluded.Enabled = True
        End Select

        Me.tabPartPriceReq.Enabled = Enabled
        Me.tabParts.Enabled = Enabled
        Me.tabProducts.Enabled = Enabled
        Me.tabDocuments.Enabled = Enabled
        Me.ucCustomerOrder.btnFindCustomer.Enabled = Not Enabled
        Me.ucCustomerOrder.btnFindSite.Enabled = Not Enabled
        Me.ucCustomerOrder.btnFindWarehouse.Enabled = Not Enabled
        Me.ucJobOrder.Enabled = Not Enabled
        Me.ucWarehouseOrder.Enabled = Not Enabled
        Me.ucVanOrder.Enabled = Not Enabled
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim ssm As Enums.SecuritySystemModules
            ssm = Enums.SecuritySystemModules.EditPO
            Dim ssm2 As Enums.SecuritySystemModules
            ssm2 = Enums.SecuritySystemModules.CreatePO
            If loggedInUser.HasAccessToModule(ssm) = True Or loggedInUser.HasAccessToModule(ssm2) = True Then

                Dim oOrder As New Entity.Orders.Order
                oOrder.IgnoreExceptionsOnSetMethods = True
                oOrder.SetSentToSage = CurrentOrder.SentToSage

                Dim oSite As New Site
                Dim oJob As Job = Nothing
                oSite.Exists = False

                'validate a customer/van/warehouse has been selected
                Select Case Combo.GetSelectedItemValue(cboOrderTypeID)
                    Case Enums.OrderType.Customer
                        If CType(Me.pnlDetails.Controls(0), UCOrderForCustomer).Customer Is Nothing Then
                            ShowMessage("Please select a Customer this Order is to be placed for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return False
                        End If
                        If CType(Me.pnlDetails.Controls(0), UCOrderForCustomer).theProperty Is Nothing And CType(Me.pnlDetails.Controls(0), UCOrderForCustomer).Warehouse Is Nothing Then
                            ShowMessage("Please select a Property/Warehouse this Order is to be placed for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return False
                        End If
                        oSite = CType(Me.pnlDetails.Controls(0), UCOrderForCustomer).theProperty
                    Case Enums.OrderType.Warehouse
                        If CType(Me.pnlDetails.Controls(0), UCOrderForWarehouse).Warehouse Is Nothing Then
                            ShowMessage("Please select a Warehouse this Order is to be placed for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return False
                        End If
                    Case Enums.OrderType.StockProfile
                        If CType(Me.pnlDetails.Controls(0), UCOrderForVan).Van Is Nothing Then
                            ShowMessage("Please select a Van this Order is to be placed for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return False
                        End If
                    Case Enums.OrderType.Job
                        If CType(Me.pnlDetails.Controls(0), UCOrderForJob).SelectedEngineerVisitDataRow Is Nothing Then
                            ShowMessage("Please select a Visit this Order is to be placed for.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return False
                        End If
                        oSite = DB.Sites.Get(CType(Me.pnlDetails.Controls(0), UCOrderForJob).SelectedEngineerVisitDataRow("SiteID"))
                        If Not CurrentOrder.Exists Then
                            oJob = DB.Job.Job_Get_For_An_EngineerVisit_ID(Helper.MakeIntegerValid(
                                CType(Me.pnlDetails.Controls(0), UCOrderForJob).SelectedEngineerVisitDataRow.Item("EngineerVisitID")))
                            Dim dvOrders As DataView = DB.Order.Orders_GetForJob(oJob.JobID)

                            dvOrders.RowFilter = "OrderStatus <> 'Cancelled'"

                            If dvOrders.Count > 0 Then

                                Dim exOrders As New List(Of String)
                                For Each dvRow As DataRowView In dvOrders
                                    exOrders.Add("Order Ref: " & dvRow("OrderReference") & ", Supplier: " & dvRow("Supplier"))
                                Next

                                If ShowMessageWithDetails("Existing Purchase Orders", "The following orders have already been placed against this job." &
                                    vbCrLf & vbCrLf & "Do you wish to continue?", exOrders) <> DialogResult.OK Then
                                    Return False
                                End If
                            End If

                            Dim department As String = Helper.MakeStringValid(Combo.GetSelectedItemValue(Me.cboDept))
                            If Helper.IsValidInteger(department) AndAlso Not Helper.MakeIntegerValid(department) <= -1 Then
                                Dim cc As Integer = GetCostCentre(oJob, oSite)
                                Combo.SetSelectedComboItem_By_Value(cboDept, cc.ToString())
                            ElseIf Not IsNumeric(department) Then
                                Dim cc As Integer = GetCostCentre(oJob, oSite)
                                Combo.SetSelectedComboItem_By_Value(cboDept, cc.ToString())
                            End If
                        End If
                    Case Else
                        ShowMessage("Please select an order type.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return False
                End Select

                'if we have a site check if user has region permission
                If oSite?.Exists Then
                    If loggedInUser.UserRegions.Count > 0 Then
                        If loggedInUser.UserRegions.Table.Select("RegionID = " & oSite.RegionID).Length < 1 Then
                            Dim msg As String = "You do not have the necessary security permissions to create a purchase order on this site." & vbCrLf
                            msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                            Throw New Security.SecurityException(msg)
                        End If
                    ElseIf oSite.RegionID <> loggedInUser.UserID Then
                        Dim msg As String = "You do not have the necessary security permissions to create a purchase order on this site." & vbCrLf
                        msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                        Throw New Security.SecurityException(msg)
                    End If
                End If

                oOrder.SetOrderID = CurrentOrder.OrderID
                oOrder.DatePlaced = Me.dtpDatePlaced.Value
                oOrder.SetOrderTypeID = Combo.GetSelectedItemValue(Me.cboOrderTypeID)

                If oOrder.UserID = 0 Then oOrder.SetUserID = loggedInUser.UserID
                oOrder.SetOrderStatusID = CInt(Combo.GetSelectedItemValue(cboOrderStatus))
                If Me.chkDeadlineNA.Checked Then
                    oOrder.DeliveryDeadline = Nothing
                Else
                    oOrder.DeliveryDeadline = Me.dtpDeliveryDeadline.Value
                End If

                oOrder.SupplierInvoiceDate = Nothing
                oOrder.SetDepartmentRef = Combo.GetSelectedItemValue(cboDept)
                oOrder.SetDoNotConsolidated = chkDoNotConsolidate.Checked
                Select Case Combo.GetSelectedItemValue(cboOrderTypeID)
                    Case Enums.OrderType.Customer
                        If CType(Me.pnlDetails.Controls(0), UCOrderForCustomer).Contact Is Nothing Then
                            oOrder.SetContactID = 0
                        Else
                            oOrder.SetContactID = CType(Me.pnlDetails.Controls(0), UCOrderForCustomer).Contact.ContactID

                        End If

                        If CType(Me.pnlDetails.Controls(0), UCOrderForCustomer).InvoiceAddress Is Nothing Then
                            oOrder.SetInvoiceAddressID = 0
                        Else
                            oOrder.SetInvoiceAddressID = CType(Me.pnlDetails.Controls(0), UCOrderForCustomer).InvoiceAddress.InvoiceAddressID
                        End If
                        oOrder.SetAllocatedToUser = Combo.GetSelectedItemValue(CType(Me.pnlDetails.Controls(0), UCOrderForCustomer).cboUsers)
                        oOrder.SetSpecialInstructions = CType(Me.pnlDetails.Controls(0), UCOrderForCustomer).txtSpecialInstructions.Text.Trim
                End Select

                oOrder.SetOrderReference = Me.txtOrderReference.Text.Trim

                Dim cV As New Entity.Orders.OrderValidator
                cV.Validate(oOrder)

                If Not CurrentOrder.Exists Then

                    oOrder = DB.Order.Insert(oOrder)

                    If oOrder.OrderReference = OrderNumber.OrderNumber Then
                        OrderNumberUsed = True
                    End If

                    Dim oSiteOrder As New Entity.SiteOrders.SiteOrder
                    Dim oCustomerOrder As New Entity.CustomerOrders.CustomerOrder
                    Dim oOrderLocation As New Entity.OrderLocations.OrderLocation
                    Dim oEngineerVisitOrder As New Entity.EngineerVisitOrders.EngineerVisitOrder

                    'Insert an order location, this is who/where the order is for
                    Select Case oOrder.OrderTypeID
                        Case Enums.OrderType.Customer
                            oCustomerOrder.SetCustomerID = CType(Me.pnlDetails.Controls(0), UCOrderForCustomer).Customer.CustomerID
                            oCustomerOrder.SetOrderID = oOrder.OrderID
                            DB.CustomerOrder.DeleteForOrder(oOrder.OrderID)
                            oCustomerOrder = DB.CustomerOrder.Insert(oCustomerOrder)

                            If Not CType(Me.pnlDetails.Controls(0), UCOrderForCustomer).theProperty Is Nothing Then
                                oSiteOrder.SetOrderID = oOrder.OrderID
                                oSiteOrder.SetSiteID = CType(Me.pnlDetails.Controls(0), UCOrderForCustomer).theProperty.SiteID
                                DB.SiteOrder.DeleteByOrder(oOrder.OrderID)
                                oSiteOrder = DB.SiteOrder.Insert(oSiteOrder)
                                PassedID = oSiteOrder.SiteID
                            Else
                                oOrderLocation.SetOrderID = oOrder.OrderID
                                oOrderLocation.SetLocationID = DB.Warehouse.Warehouse_GetDV(CType(Me.pnlDetails.Controls(0), UCOrderForCustomer).Warehouse.WarehouseID).Table.Rows(0).Item("LocationID")
                                DB.OrderLocation.DeleteForOrder(oOrder.OrderID)
                                oOrderLocation = DB.OrderLocation.Insert(oOrderLocation)
                                PassedID = CType(Me.pnlDetails.Controls(0), UCOrderForCustomer).Warehouse.WarehouseID
                            End If

                        Case Enums.OrderType.Warehouse
                            oOrderLocation.SetOrderID = oOrder.OrderID
                            oOrderLocation.SetLocationID = DB.Warehouse.Warehouse_GetDV(CType(Me.pnlDetails.Controls(0), UCOrderForWarehouse).Warehouse.WarehouseID).Table.Rows(0).Item("LocationID")
                            DB.OrderLocation.DeleteForOrder(oOrder.OrderID)
                            oOrderLocation = DB.OrderLocation.Insert(oOrderLocation)
                            PassedID = CType(Me.pnlDetails.Controls(0), UCOrderForWarehouse).Warehouse.WarehouseID

                        Case Enums.OrderType.StockProfile
                            oOrderLocation.SetOrderID = oOrder.OrderID
                            oOrderLocation.SetLocationID = CInt(DB.Van.Van_GetDV(CType(Me.pnlDetails.Controls(0), UCOrderForVan).Van.VanID).Table.Rows(0).Item("LocationID"))
                            oOrderLocation.SetDeliveryAddressID = CType(Me.pnlDetails.Controls(0), UCOrderForVan).DeliveryAddressID
                            DB.OrderLocation.DeleteForOrder(oOrder.OrderID)
                            oOrderLocation = DB.OrderLocation.Insert(oOrderLocation)
                            PassedID = CType(Me.pnlDetails.Controls(0), UCOrderForVan).Van.VanID

                        Case Enums.OrderType.Job
                            oEngineerVisitOrder.SetOrderID = oOrder.OrderID

                            If Not CType(Me.pnlDetails.Controls(0), UCOrderForJob).Warehouse Is Nothing Then
                                oEngineerVisitOrder.SetWarehouseID = CType(Me.pnlDetails.Controls(0), UCOrderForJob).Warehouse.WarehouseID
                            End If

                            oEngineerVisitOrder.SetEngineerVisitID = CType(Me.pnlDetails.Controls(0), UCOrderForJob).SelectedEngineerVisitDataRow.Item("EngineerVisitID")
                            DB.EngineerVisitOrder.EngineerVisitOrder_DeleteForOrder(oOrder.OrderID)
                            oEngineerVisitOrder = DB.EngineerVisitOrder.Insert(oEngineerVisitOrder)
                            Dim oEngineerVisit As Entity.EngineerVisits.EngineerVisit
                            oEngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(oEngineerVisitOrder.EngineerVisitID)
                            If oEngineerVisit.StatusEnumID < CInt(Enums.VisitStatus.Scheduled) Then
                                oEngineerVisit.SetStatusEnumID = CInt(Enums.VisitStatus.Waiting_For_Parts)
                                DB.EngineerVisits.Update(oEngineerVisit, 0, True)
                            End If

                            PassedID = CType(Me.pnlDetails.Controls(0), UCOrderForJob).SelectedEngineerVisitDataRow.Item("EngineerVisitID")
                    End Select

                    CurrentOrder = oOrder
                Else
                    Dim ssm3 As Enums.SecuritySystemModules
                    ssm3 = Enums.SecuritySystemModules.POUnlock
                    If loggedInUser.HasAccessToModule(ssm3) = True Then
                        If chkRevertStatus.Checked = True Then
                            oOrder.SetOrderStatusID = 1
                            'LoadForm(Me, System.EventArgs)
                            DB.Order.Update(oOrder)
                            FRMOrder.ResetMe(oOrder.OrderID)
                            cboPartLocation.Enabled = True
                            txtPartSearch.Enabled = True
                            btnPartSearch.Enabled = True
                            Me.txtPartQuantity.Enabled = True
                            Me.txtPartBuyPrice.Enabled = True
                            cboProductLocation.Enabled = True
                            txtProductSearch.Enabled = True
                            Me.txtProductQuantity.Enabled = True
                            Me.txtProductBuyPrice.Enabled = True
                            Me.txtProductSellPrice.Enabled = True
                            btnProductSearch.Enabled = True
                            btnItemQtyUpdate.Enabled = True
                            nudItemQty.Enabled = True
                            Me.dgParts.Enabled = True
                            Me.dgProduct.Enabled = True
                            btnReceiveAll.Enabled = True
                            chkRevertStatus.Checked = False
                        Else
                            DB.Order.Update(oOrder)

                        End If

                    End If
                    'DB.Order.Update(oOrder)
                End If

                RaiseEvent StateChanged(CurrentOrder.OrderID)

                Return True
            Else
                Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                Throw New Security.SecurityException(msg)
                Return False
            End If
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

    Private Sub PartSearch()
        Select Case Combo.GetSelectedItemValue(cboPartLocation)
            Case 0
                'do nothing
            Case Enums.LocationType.Supplier
                If LocationUsedID = 0 Then
                    Dim isFlagship As Boolean = False
                    Dim currentCustomer As Entity.Customers.Customer = DB.Customer.Customer_Get(CustomerID)
                    isFlagship = (currentCustomer IsNot Nothing AndAlso currentCustomer.IsPFH)

                    PartsDataView = DB.PartSupplier.PartSupplier_Search(Me.txtPartSearch.Text, SupplierUsedID, isFlagship)
                Else
                    ShowMessage("A warehouse/van has been ordered from so no supplier orders can be added", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Case Enums.LocationType.Van
                If SupplierUsedID = 0 Then
                    PartsDataView = DB.PartTransaction.SearchByVan(Me.txtPartSearch.Text, LocationUsedID)
                Else
                    ShowMessage("A supplier has been ordered from so no stock profile can be added", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Case Enums.LocationType.Warehouse
                If SupplierUsedID = 0 Then
                    PartsDataView = DB.PartTransaction.SearchByWarehouse(Me.txtPartSearch.Text, LocationUsedID)
                Else
                    ShowMessage("A supplier has been ordered from so no warehouse orders can be added", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
        End Select

        UpdatePartSearchOptions()
    End Sub

    Private Sub UpdatePartSearchOptions()
        Select Case Combo.GetSelectedItemValue(cboPartLocation)
            Case 0
                Me.grpPartSearch.Text = "Part Search From"
                Me.btnPartSearch.Enabled = False
            Case Enums.LocationType.Supplier
                Me.btnPartSearch.Enabled = True
                Me.grpPartSearch.Text = "Search takes place on Part Name, Number (MPN) and Supplier Code (SPN)"
            Case Enums.LocationType.Van
                Me.btnPartSearch.Enabled = True
                Me.grpPartSearch.Text = "Search takes place on Part Name, Number (MPN), Engineer Name and Stock Profile"
            Case Enums.LocationType.Warehouse
                Me.btnPartSearch.Enabled = True
                Me.grpPartSearch.Text = "Search takes place on Part Name, Number (MPN) and Warehouse Name"
        End Select

        'Me.txtPartSearch.Text = ""
        Me.txtPartQuantity.Text = ""
        Me.txtPartQuantity.ReadOnly = True
        Me.txtPartBuyPrice.Text = ""
        Me.txtPartBuyPrice.ReadOnly = True
        Me.btnAddPart.Enabled = False
        Me.btnCreatePartRequest.Enabled = False
    End Sub

    Private Sub ProductSearch()
        Select Case Combo.GetSelectedItemValue(cboProductLocation)
            Case 0
                'do nothing
            Case Enums.LocationType.Supplier
                If LocationUsedID = 0 Then
                    ProductsDataView = DB.ProductSupplier.ProductSupplier_Search(Me.txtProductSearch.Text, SupplierUsedID)
                Else
                    ShowMessage("A warehouse/van has been ordered from so no supplier orders can be added", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Case Enums.LocationType.Van
                If SupplierUsedID = 0 Then
                    ProductsDataView = DB.ProductTransaction.SearchByVan(Me.txtProductSearch.Text, LocationUsedID)
                Else
                    ShowMessage("A supplier has been ordered from so no stock profile orders can be added", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Case Enums.LocationType.Warehouse
                If SupplierUsedID = 0 Then
                    ProductsDataView = DB.ProductTransaction.SearchByWarehouse(Me.txtProductSearch.Text, LocationUsedID)
                Else
                    ShowMessage("A supplier has been ordered from so no warehouse orders can be added", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
        End Select

        UpdateProductSearchOptions()
    End Sub

    Private Sub UpdateProductSearchOptions()
        Select Case Combo.GetSelectedItemValue(cboProductLocation)
            Case 0
                Me.grpProductSearch.Text = "Product Search From"
                Me.btnProductSearch.Enabled = False
            Case Enums.LocationType.Supplier
                Me.btnProductSearch.Enabled = True
                Me.grpProductSearch.Text = "Search takes place on Product Number, Model, Make, Type  and Supplier Code"
            Case Enums.LocationType.Van
                Me.btnProductSearch.Enabled = True
                Me.grpProductSearch.Text = "Search takes place on Product Number, Model, Make, Type, Engineer Name and stock profile"
            Case Enums.LocationType.Warehouse
                Me.btnProductSearch.Enabled = True
                Me.grpProductSearch.Text = "Search takes place on Product Number, Model, Make, Type and Warehouse Name"
        End Select

        'Me.txtProductSearch.Text = ""
        Me.txtProductQuantity.Text = ""
        Me.txtProductQuantity.ReadOnly = True
        Me.txtProductBuyPrice.Text = ""
        Me.txtProductBuyPrice.ReadOnly = True
        Me.txtProductSellPrice.Text = ""
        Me.txtProductSellPrice.ReadOnly = True
        Me.btnAddProduct.Enabled = False
        Me.btnCreateProductPriceRequest.Enabled = False
    End Sub

    Private Sub Calculate_Tax()
        If IsLoading Then
            Exit Sub
        End If

        Try
            Me.txtVATAmount.Text = Format(Replace(txtGoodsAmount.Text, "£", "") * (DB.Picklists.Get_One_As_Object(Combo.GetSelectedItemValue(Me.cboInvoiceTaxCodeNew)).PercentageRate / 100), "C")
            Me.txtTotalAmount.Text = FormatCurrency(CDbl(Replace(txtGoodsAmount.Text, "£", "")) + CDbl(Replace(txtVATAmount.Text, "£", "")))
        Catch ex As Exception
            Me.txtVATAmount.Text = Nothing
            Me.txtTotalAmount.Text = Nothing
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Not dgCredits.CurrentRow Is Nothing Then

            If dgCredits.Item("DatePartReturned", dgCredits.CurrentRow.Index).Value.ToString.Length > 0 Then
                ShowMessage("This part has been returned so no, you cant move it to a van.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else

                Dim PartsAndProductsDistribution As New DataTable

                PartsAndProductsDistribution.Columns.Add("LocationID")
                PartsAndProductsDistribution.Columns.Add("AllocatedID")
                PartsAndProductsDistribution.Columns.Add("Other")
                PartsAndProductsDistribution.Columns.Add("Quantity")
                PartsAndProductsDistribution.Columns.Add("PartProductID")
                PartsAndProductsDistribution.Columns.Add("OrderPartProductID")
                PartsAndProductsDistribution.Columns.Add("StockTransactionType")

                Dim frmDistribution As New FRMConvertToVan(False, dgCredits.Item("Qty", dgCredits.CurrentRow.Index).Value, dgCredits.Item("PartName", dgCredits.CurrentRow.Index).Value, "Part", dgCredits.Item("PartID", dgCredits.CurrentRow.Index).Value, Nothing)
                If frmDistribution.ShowDialog = DialogResult.OK Then

                    For Each row As DataRow In frmDistribution.Locations.Table.Rows
                        If row.Item("Quantity") > 0 Then
                            Dim r As DataRow = PartsAndProductsDistribution.NewRow

                            Dim allocated As Integer = DB.ExecuteScalar("Select EngineerVisitPartAllocatedID From tblEngineervisitPartAllocated Where OrderPartID = " & dgCredits.Item("OrderPartID", dgCredits.CurrentRow.Index).Value)
                            ' r("DistributedID") = 0
                            r("LocationID") = row.Item("LocationID")
                            r("AllocatedID") = allocated
                            r("Other") = False
                            r("Quantity") = row.Item("Quantity")
                            r("PartProductID") = dgCredits.Item("PartID", dgCredits.CurrentRow.Index).Value
                            r("OrderPartProductID") = dgCredits.Item("OrderPartID", dgCredits.CurrentRow.Index).Value
                            r("StockTransactionType") = CInt(Enums.Transaction.StockIn)
                            PartsAndProductsDistribution.Rows.Add(r)
                        End If
                    Next

                    DB.Order.AllocatedDistributions(PartsAndProductsDistribution)
                    DB.ExecuteScalar("DELETE from tblPartsToBeCredited WHERE OrderPartID = " & dgCredits.Item("OrderPartID", dgCredits.CurrentRow.Index).Value)

                    ShowMessage("Moved!", MessageBoxButtons.OK, MessageBoxIcon.Question)

                    RefreshDataGrids()

                End If

            End If

        End If

    End Sub

    Private Sub Calculate_Tax2()
        If IsLoading Then
            Exit Sub
        End If

        Try
            Me.txtCreditVAT.Text = Format(Replace(txtCreditGoods.Text, "£", "") * (DB.Picklists.Get_One_As_Object(Combo.GetSelectedItemValue(Me.cboCreditTax)).PercentageRate / 100), "C")
            Me.txtCreditTotal.Text = FormatCurrency(CDbl(Replace(txtCreditGoods.Text, "£", "")) + CDbl(Replace(txtCreditVAT.Text, "£", "")))
        Catch ex As Exception
            Me.txtCreditVAT.Text = Nothing
            Me.txtCreditTotal.Text = Nothing
        End Try

    End Sub

    Private Sub btnEngineerReceived_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEngineerReceived.Click
        If CurrentOrder Is Nothing Then
            ShowMessage("Order must be created first", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Not CurrentOrder.Exists Then
            ShowMessage("Order must be created first", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Not CurrentOrder.OrderTypeID = CInt(Enums.OrderType.StockProfile) Then
            ShowMessage("Order must be for a van", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Not CurrentOrder.OrderStatusID = CInt(Enums.OrderStatus.Complete) Then
            ShowMessage("Order must be completed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If ShowMessage("Are you sure you wish to mark all items as received by engineer?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        For Each itemRow As DataRow In ItemsIncludedDataView.Table.Rows
            Dim continueSave As Boolean = True

            If CurrentOrder.OrderTypeID = CInt(Enums.OrderType.StockProfile) Then
                If Not Helper.MakeDateTimeValid(itemRow.Item("WithEngineer_Van")) = Nothing Then
                    continueSave = False
                End If
            ElseIf CurrentOrder.OrderTypeID = CInt(Enums.OrderType.Job) Then
                If Not Helper.MakeDateTimeValid(itemRow.Item("WithEngineer_Job")) = Nothing Then
                    continueSave = False
                End If
            End If

            If continueSave Then
                Dim QuantityReceived As Integer = CInt(itemRow.Item("QuantityReceived"))

                Select Case CStr(itemRow.Item("Type"))
                    Case "OrderProduct"
                        'DO NOTHING

                    Case "OrderPart"
                        Dim OrderPart As Entity.OrderParts.OrderPart = DB.OrderPart.OrderPart_Get(CInt(itemRow("ID")))
                        Dim oOrderLocation As Entity.OrderLocations.OrderLocation = DB.OrderLocation.OrderLocation_GetForOrder(OrderPart.OrderID)
                        Dim oPartSupplier As Entity.PartSuppliers.PartSupplier = DB.PartSupplier.PartSupplier_Get(OrderPart.PartSupplierID)

                        Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                        oPartTransaction.SetLocationID = oOrderLocation.LocationID
                        oPartTransaction.SetPartID = oPartSupplier.PartID
                        oPartTransaction.SetOrderPartID = OrderPart.OrderPartID
                        oPartTransaction.SetAmount = QuantityReceived * oPartSupplier.QuantityInPack
                        oPartTransaction.SetTransactionTypeID = CInt(Enums.Transaction.StockIn)
                        DB.PartTransaction.Insert(oPartTransaction)

                        DB.OrderPart.EngineerReceived(OrderPart.OrderPartID)
                    Case "OrderLocationProduct"
                        'DO NOTHING

                    Case "OrderLocationPart"
                        Dim OrderLocationPart As Entity.OrderLocationPart.OrderLocationPart = DB.OrderLocationPart.OrderLocationPart_Get(CInt(itemRow("ID")))
                        Dim oPartTransaction As Entity.PartTransactions.PartTransaction = DB.PartTransaction.PartTransaction_GetByOrderLocationPart(OrderLocationPart.OrderLocationPartID)

                        Dim oOrderLocation As Entity.OrderLocations.OrderLocation
                        oOrderLocation = DB.OrderLocation.OrderLocation_GetForOrder(OrderLocationPart.OrderID)
                        oPartTransaction.SetLocationID = oOrderLocation.LocationID
                        oPartTransaction.SetTransactionTypeID = CInt(Enums.Transaction.StockIn)
                        oPartTransaction.SetOrderLocationPartID = OrderLocationPart.OrderLocationPartID
                        oPartTransaction.SetAmount = QuantityReceived
                        oPartTransaction.SetPartID = OrderLocationPart.PartID
                        DB.PartTransaction.Insert(oPartTransaction)

                        DB.OrderLocationPart.EngineerReceived(OrderLocationPart.OrderLocationPartID)
                End Select
            End If
        Next

        Populate(CurrentOrder.OrderID)
    End Sub

    Public Function GetCostCentre(ByVal job As Job, ByVal site As Site) As Integer
        Dim cc As CostCentre = DB.CostCentre.Get(job?.JobTypeID, site?.CustomerID, Entity.CostCentres.Enums.GetBy.JobTypeIdAndCutomerId)?.FirstOrDefault()
        Return If(cc IsNot Nothing, cc.CostCentre, -1)
    End Function

#End Region

#Region "Email"

    Private Sub Email()
        If CurrentOrder.Exists = True Then
            Select Case Combo.GetSelectedItemValue(Me.cboPrintType)
                Case Enums.SystemDocumentType.SupplierPurchaseOrder
                    Dim email As New Emails
                    email.To = ""
                    email.From = TheSystem.Configuration.SalesEmailFrom
                    email.Subject = "Purchase Order"
                    email.Body = "Purchase Order Attached"
                    PrintSupplierPurchaseOrders(CurrentOrder.OrderTypeID, email)
            End Select
        Else
            ShowMessage("You must save the order before you can send.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

#End Region

#Region "Printing"

    Public Sub Print()
        If CurrentOrder.Exists = True Then
            Select Case Combo.GetSelectedItemValue(Me.cboPrintType)
                Case Enums.SystemDocumentType.SupplierPurchaseOrder
                    PrintSupplierPurchaseOrders(CurrentOrder.OrderTypeID, Nothing)
            End Select
            Me.pnlDocuments.Controls.Clear()
            DocumentsControl = New UCDocumentsList(Enums.TableNames.tblOrder, CurrentOrder.OrderID)
            Me.pnlDocuments.Controls.Add(DocumentsControl)
        Else
            ShowMessage("You must save the order before you can print.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Function PrintSupplierPurchaseOrders(ByVal OrderTypeID As Integer, ByVal oEmail As Emails) As Boolean

        Dim details As New ArrayList

        Dim orderDV As DataView = DB.Order.OrderSupplierItemsForPrint_Get(CurrentOrder.OrderID)
        If orderDV.Table.Rows.Count > 0 Then
            orderDV.Sort = "SupplierID"
            Dim printDT As DataTable = orderDV.Table.Clone
            Dim printDS As New DataSet
            Dim prevSupplierID As Integer = orderDV.Table.Rows(0).Item("SupplierID")
            For Each row As DataRow In orderDV.Table.Rows
                If row.Item("SupplierID") = prevSupplierID Then
                    printDT.Rows.Add(row.ItemArray)
                Else
                    printDT.TableName = "tblOrder" & CStr(prevSupplierID)
                    printDS.Tables.Add(printDT.Copy)
                    printDT.Rows.Clear()
                    printDT.Rows.Add(row.ItemArray)
                End If
                prevSupplierID = CInt(row.Item("SupplierID"))
            Next
            If printDT.Rows.Count > 0 Then
                printDT.TableName = "tblOrder" & CStr(prevSupplierID)
                printDS.Tables.Add(printDT.Copy)
                details.Add(printDS)
            End If

            Dim answer As DialogResult = ShowMessage("Do you want to print to PDF?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Select Case OrderTypeID
                Case Enums.OrderType.Customer
                    'details.Add(CType(Me.pnlDetails.Controls(0), UCOrderForCustomer).theSite)
                    If CType(Me.pnlDetails.Controls(0), UCOrderForCustomer).theProperty Is Nothing Then
                        details.Add("Warehouse")
                        details.Add(CType(Me.pnlDetails.Controls(0), UCOrderForCustomer).Warehouse)
                    Else
                        details.Add("Site")
                        details.Add(CType(Me.pnlDetails.Controls(0), UCOrderForCustomer).theProperty)
                    End If
                    details.Add(Nothing)
                    details.Add(DB.User.Get(CurrentOrder.UserID))
                    details.Add(CurrentOrder.OrderReference)
                    details.Add(CurrentOrder.DeliveryDeadline)
                    details.Add(DB.OrderCharge.OrderCharge_GetForOrder(CurrentOrder.OrderID))
                    details.Add(answer)
                    If Not oEmail Is Nothing Then
                        Dim oPrint As New Printing(details, "SupplierPurchaseOrder", Enums.SystemDocumentType.SupplierPurchaseOrder, True, CurrentOrder.OrderID, True)
                        For Each oSupplier As Entity.Suppliers.Supplier In oPrint.MultiEmail()
                            oEmail.Attachments.Add(oSupplier.FilePath)
                            oEmail.To = oSupplier.EmailAddress
                            oEmail.SendMe = True
                            oEmail.Send()
                        Next
                    Else
                        Dim oPrint As New Printing(details, "SupplierPurchaseOrder", Enums.SystemDocumentType.SupplierPurchaseOrder, True, CurrentOrder.OrderID)
                    End If

                Case Enums.OrderType.Warehouse
                    details.Add("Warehouse")
                    details.Add(CType(Me.pnlDetails.Controls(0), UCOrderForWarehouse).Warehouse)
                    details.Add(Nothing)
                    details.Add(DB.User.Get(CurrentOrder.UserID))
                    details.Add(CurrentOrder.OrderReference)
                    details.Add(CurrentOrder.DeliveryDeadline)
                    details.Add(DB.OrderCharge.OrderCharge_GetForOrder(CurrentOrder.OrderID))
                    details.Add(answer)
                    If Not oEmail Is Nothing Then
                        Dim oPrint As New Printing(details, "SupplierPurchaseOrder", Enums.SystemDocumentType.SupplierPurchaseOrder, True, CurrentOrder.OrderID, True)
                        For Each oSupplier As Entity.Suppliers.Supplier In oPrint.MultiEmail()
                            oEmail.Attachments.Add(oSupplier.FilePath)
                            oEmail.To = oSupplier.EmailAddress
                            oEmail.SendMe = True
                            oEmail.Send()
                        Next
                    Else
                        Dim oPrint As New Printing(details, "SupplierPurchaseOrder", Enums.SystemDocumentType.SupplierPurchaseOrder, True, CurrentOrder.OrderID)
                    End If
                Case Enums.OrderType.Job
                    Dim warehouseID As Integer = DB.EngineerVisitOrder.EngineerVisitOrder_GetForOrder(CurrentOrder.OrderID).WarehouseID
                    If warehouseID > 0 Then
                        details.Add("Warehouse")
                        details.Add(DB.Warehouse.Warehouse_Get(warehouseID))
                    Else
                        details.Add("Site")
                        details.Add(DB.Sites.Get(DB.Job.Job_Get_For_An_EngineerVisit_ID(DB.EngineerVisitOrder.EngineerVisitOrder_GetForOrder(CurrentOrder.OrderID).EngineerVisitID).PropertyID))
                    End If

                    details.Add(Nothing)
                    details.Add(DB.User.Get(CurrentOrder.UserID))
                    details.Add(CurrentOrder.OrderReference)
                    details.Add(CurrentOrder.DeliveryDeadline)
                    details.Add(DB.OrderCharge.OrderCharge_GetForOrder(CurrentOrder.OrderID))
                    details.Add(answer)
                    If Not oEmail Is Nothing Then
                        Dim oPrint As New Printing(details, "SupplierPurchaseOrder", Enums.SystemDocumentType.SupplierPurchaseOrder, True, CurrentOrder.OrderID, True)
                        For Each oSupplier As Entity.Suppliers.Supplier In oPrint.MultiEmail()
                            oEmail.Attachments.Add(oSupplier.FilePath)
                            oEmail.To = oSupplier.EmailAddress
                            oEmail.SendMe = True
                            oEmail.Send()
                        Next
                    Else
                        Dim oPrint As New Printing(details, "SupplierPurchaseOrder", Enums.SystemDocumentType.SupplierPurchaseOrder, True, CurrentOrder.OrderID)
                    End If

                Case Enums.OrderType.StockProfile
                    details.Add("Stock Profile")

                    Dim deliveryAddressID As Integer = DB.OrderLocation.OrderLocation_GetForOrder(CurrentOrder.OrderID).DeliveryAddressID
                    If Not deliveryAddressID = 0 Then
                        details.Add(DB.Warehouse.Warehouse_Get(deliveryAddressID))
                    Else
                        details.Add(Nothing)
                    End If
                    details.Add(Nothing)
                    details.Add(DB.User.Get(CurrentOrder.UserID))
                    details.Add(CurrentOrder.OrderReference)
                    details.Add(CurrentOrder.DeliveryDeadline)
                    details.Add(DB.OrderCharge.OrderCharge_GetForOrder(CurrentOrder.OrderID))
                    details.Add(answer)
                    If Not oEmail Is Nothing Then
                        Dim oPrint As New Printing(details, "SupplierPurchaseOrder", Enums.SystemDocumentType.SupplierPurchaseOrder, True, CurrentOrder.OrderID, True)
                        For Each oSupplier As Entity.Suppliers.Supplier In oPrint.MultiEmail()
                            oEmail.Attachments.Add(oSupplier.FilePath)
                            oEmail.To = oSupplier.EmailAddress
                            oEmail.SendMe = True
                            oEmail.Send()
                        Next
                    Else
                        Dim oPrint As New Printing(details, "SupplierPurchaseOrder", Enums.SystemDocumentType.SupplierPurchaseOrder, True, CurrentOrder.OrderID)
                    End If
            End Select
        Else
            ShowMessage("No Items have been ordered from suppliers", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Function

    Private Sub btnUpdateOrderRef_Click(sender As Object, e As EventArgs) Handles btnUpdateOrderRef.Click
        If Me.txtOrderReference.ReadOnly = True Then
            If CurrentOrder Is Nothing Then Exit Sub
            If Not CurrentOrder.Exists Then Exit Sub
            Me.txtOrderReference.ReadOnly = False
            Me.txtOrderReference.Enabled = True
        Else
            'update
            If ShowMessage("Do you wish to update the order ref?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                DB.Order.[Update_OrderRef](CurrentOrder.OrderID, Me.txtOrderReference.Text)
                Dim email As New Emails
                email.To = EmailAddress.Accounts
                email.From = EmailAddress.FSM
                email.Subject = "Purchase Order Changed"
                email.Body = "Purchase Order Changed from " & CurrentOrder.OrderReference &
                    " to " & Me.txtOrderReference.Text & " by " & loggedInUser.Fullname
                email.SendMe = True
                email.Send()

                Me.txtOrderReference.ReadOnly = True
                Me.txtOrderReference.Enabled = False
            End If

        End If
    End Sub

    Private Sub btnApproveOrder_Click(sender As Object, e As EventArgs) Handles btnApproveOrder.Click
        If CurrentOrder.OrderStatusID <> Enums.OrderStatus.AwaitingApproval Then Exit Sub

        If ShowMessage("Are you sure you want to approve this order?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ShowForm(GetType(FRMOrderRejection), True, New Object() {Me, "", True})

            If Reason.Trim.Length = 0 Then
                IsLoading = True
                Combo.SetSelectedComboItem_By_Value(cboOrderStatus, CurrentOrder.OrderStatusID)
                IsLoading = False
                Exit Sub
            Else
                CurrentOrder.SetReason = Reason
                CurrentOrder.SetOrderStatusID = CInt(Enums.OrderStatus.Confirmed)
                DB.Order.Update(CurrentOrder)
                Populate()
            End If
        End If
    End Sub

#End Region

End Class