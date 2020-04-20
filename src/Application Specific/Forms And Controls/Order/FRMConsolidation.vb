Public Class FRMConsolidation : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        Combo.SetUpCombo(Me.cboStatus, DB.Order.OrderStatus_Get_All().Table, "OrderStatusID", "Name", Entity.Sys.Enums.ComboValues.None)
        Combo.SetUpCombo(Me.cboTaxCode, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.VATCodes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Dashes)
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
    Friend WithEvents btnSave As System.Windows.Forms.Button

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grpMain As System.Windows.Forms.GroupBox
    Friend WithEvents txtReference As System.Windows.Forms.TextBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnSupplier As System.Windows.Forms.Button
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplier As System.Windows.Forms.TextBox
    Friend WithEvents grpOrders As System.Windows.Forms.GroupBox
    Friend WithEvents grpItems As System.Windows.Forms.GroupBox
    Friend WithEvents dgOrders As System.Windows.Forms.DataGrid
    Friend WithEvents dgItems As System.Windows.Forms.DataGrid
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnReceiveAll As System.Windows.Forms.Button
    Friend WithEvents chkPOSupplied As System.Windows.Forms.CheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cbxReadyToSendToSage As System.Windows.Forms.CheckBox
    Friend WithEvents txtDepartment As System.Windows.Forms.TextBox
    Friend WithEvents txtNominalCode As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtVAT As System.Windows.Forms.TextBox
    Friend WithEvents txtExtraReference As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboTaxCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSupplierInvoiceAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkSupInvDateNA As System.Windows.Forms.CheckBox
    Friend WithEvents txtSupplierInvoiceReference As System.Windows.Forms.TextBox
    Friend WithEvents dtpSupplierInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblOrderTotal As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents btnPrintDistribution As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.grpMain = New System.Windows.Forms.GroupBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.chkPOSupplied = New System.Windows.Forms.CheckBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cbxReadyToSendToSage = New System.Windows.Forms.CheckBox
        Me.txtDepartment = New System.Windows.Forms.TextBox
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.txtNominalCode = New System.Windows.Forms.TextBox
        Me.btnSupplier = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtComments = New System.Windows.Forms.TextBox
        Me.txtSupplier = New System.Windows.Forms.TextBox
        Me.txtVAT = New System.Windows.Forms.TextBox
        Me.txtExtraReference = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtReference = New System.Windows.Forms.TextBox
        Me.cboTaxCode = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtSupplierInvoiceAmount = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.chkSupInvDateNA = New System.Windows.Forms.CheckBox
        Me.txtSupplierInvoiceReference = New System.Windows.Forms.TextBox
        Me.dtpSupplierInvoiceDate = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.grpOrders = New System.Windows.Forms.GroupBox
        Me.dgOrders = New System.Windows.Forms.DataGrid
        Me.grpItems = New System.Windows.Forms.GroupBox
        Me.lblOrderTotal = New System.Windows.Forms.Label
        Me.dgItems = New System.Windows.Forms.DataGrid
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnReceiveAll = New System.Windows.Forms.Button
        Me.btnPrintDistribution = New System.Windows.Forms.Button
        Me.grpMain.SuspendLayout()
        Me.grpOrders.SuspendLayout()
        CType(Me.dgOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpItems.SuspendLayout()
        CType(Me.dgItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(833, 681)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(60, 25)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(12, 681)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 25)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Reference"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Comments"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Supplier"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(185, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Status"
        '
        'grpMain
        '
        Me.grpMain.Controls.Add(Me.lblStatus)
        Me.grpMain.Controls.Add(Me.chkPOSupplied)
        Me.grpMain.Controls.Add(Me.Label17)
        Me.grpMain.Controls.Add(Me.cbxReadyToSendToSage)
        Me.grpMain.Controls.Add(Me.txtDepartment)
        Me.grpMain.Controls.Add(Me.cboStatus)
        Me.grpMain.Controls.Add(Me.txtNominalCode)
        Me.grpMain.Controls.Add(Me.btnSupplier)
        Me.grpMain.Controls.Add(Me.Label16)
        Me.grpMain.Controls.Add(Me.txtComments)
        Me.grpMain.Controls.Add(Me.txtSupplier)
        Me.grpMain.Controls.Add(Me.txtVAT)
        Me.grpMain.Controls.Add(Me.txtExtraReference)
        Me.grpMain.Controls.Add(Me.Label14)
        Me.grpMain.Controls.Add(Me.txtReference)
        Me.grpMain.Controls.Add(Me.cboTaxCode)
        Me.grpMain.Controls.Add(Me.Label15)
        Me.grpMain.Controls.Add(Me.Label13)
        Me.grpMain.Controls.Add(Me.Label1)
        Me.grpMain.Controls.Add(Me.Label4)
        Me.grpMain.Controls.Add(Me.Label2)
        Me.grpMain.Controls.Add(Me.txtSupplierInvoiceAmount)
        Me.grpMain.Controls.Add(Me.Label3)
        Me.grpMain.Controls.Add(Me.Label10)
        Me.grpMain.Controls.Add(Me.Label9)
        Me.grpMain.Controls.Add(Me.chkSupInvDateNA)
        Me.grpMain.Controls.Add(Me.txtSupplierInvoiceReference)
        Me.grpMain.Controls.Add(Me.dtpSupplierInvoiceDate)
        Me.grpMain.Controls.Add(Me.Label11)
        Me.grpMain.Location = New System.Drawing.Point(12, 38)
        Me.grpMain.Name = "grpMain"
        Me.grpMain.Size = New System.Drawing.Size(400, 337)
        Me.grpMain.TabIndex = 1
        Me.grpMain.TabStop = False
        Me.grpMain.Text = "Main Details"
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblStatus.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(10, 281)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(233, 50)
        Me.lblStatus.TabIndex = 89
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkPOSupplied
        '
        Me.chkPOSupplied.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPOSupplied.Location = New System.Drawing.Point(9, 135)
        Me.chkPOSupplied.Name = "chkPOSupplied"
        Me.chkPOSupplied.Size = New System.Drawing.Size(251, 24)
        Me.chkPOSupplied.TabIndex = 88
        Me.chkPOSupplied.Text = "Supplier purchase invoice provided"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.Location = New System.Drawing.Point(243, 282)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 20)
        Me.Label17.TabIndex = 87
        Me.Label17.Text = "Dept"
        '
        'cbxReadyToSendToSage
        '
        Me.cbxReadyToSendToSage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxReadyToSendToSage.Location = New System.Drawing.Point(232, 308)
        Me.cbxReadyToSendToSage.Name = "cbxReadyToSendToSage"
        Me.cbxReadyToSendToSage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbxReadyToSendToSage.Size = New System.Drawing.Size(163, 24)
        Me.cbxReadyToSendToSage.TabIndex = 78
        Me.cbxReadyToSendToSage.Text = "Ready to send to sage"
        '
        'txtDepartment
        '
        Me.txtDepartment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDepartment.Location = New System.Drawing.Point(302, 281)
        Me.txtDepartment.MaxLength = 100
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.Size = New System.Drawing.Size(93, 21)
        Me.txtDepartment.TabIndex = 77
        Me.txtDepartment.Tag = "Order.SupplierInvoiceReference"
        '
        'cboStatus
        '
        Me.cboStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(234, 23)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(160, 21)
        Me.cboStatus.TabIndex = 2
        '
        'txtNominalCode
        '
        Me.txtNominalCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtNominalCode.Location = New System.Drawing.Point(302, 252)
        Me.txtNominalCode.MaxLength = 100
        Me.txtNominalCode.Name = "txtNominalCode"
        Me.txtNominalCode.Size = New System.Drawing.Size(93, 21)
        Me.txtNominalCode.TabIndex = 76
        Me.txtNominalCode.Tag = "Order.SupplierInvoiceReference"
        '
        'btnSupplier
        '
        Me.btnSupplier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSupplier.Location = New System.Drawing.Point(359, 52)
        Me.btnSupplier.Name = "btnSupplier"
        Me.btnSupplier.Size = New System.Drawing.Size(35, 23)
        Me.btnSupplier.TabIndex = 4
        Me.btnSupplier.Text = "..."
        Me.btnSupplier.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.Location = New System.Drawing.Point(243, 252)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 20)
        Me.Label16.TabIndex = 86
        Me.Label16.Text = "Nominal"
        '
        'txtComments
        '
        Me.txtComments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComments.Location = New System.Drawing.Point(89, 83)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtComments.Size = New System.Drawing.Size(305, 46)
        Me.txtComments.TabIndex = 5
        '
        'txtSupplier
        '
        Me.txtSupplier.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSupplier.Location = New System.Drawing.Point(89, 52)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.ReadOnly = True
        Me.txtSupplier.Size = New System.Drawing.Size(264, 21)
        Me.txtSupplier.TabIndex = 3
        '
        'txtVAT
        '
        Me.txtVAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtVAT.Location = New System.Drawing.Point(138, 251)
        Me.txtVAT.MaxLength = 100
        Me.txtVAT.Name = "txtVAT"
        Me.txtVAT.Size = New System.Drawing.Size(105, 21)
        Me.txtVAT.TabIndex = 75
        Me.txtVAT.Tag = "Order.SupplierInvoiceAmount"
        '
        'txtExtraReference
        '
        Me.txtExtraReference.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtExtraReference.Location = New System.Drawing.Point(302, 163)
        Me.txtExtraReference.MaxLength = 100
        Me.txtExtraReference.Name = "txtExtraReference"
        Me.txtExtraReference.Size = New System.Drawing.Size(93, 21)
        Me.txtExtraReference.TabIndex = 70
        Me.txtExtraReference.Tag = "Order.SupplierInvoiceReference"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.Location = New System.Drawing.Point(7, 252)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(125, 20)
        Me.Label14.TabIndex = 84
        Me.Label14.Text = "Invoice VAT Amount"
        '
        'txtReference
        '
        Me.txtReference.Location = New System.Drawing.Point(89, 23)
        Me.txtReference.Name = "txtReference"
        Me.txtReference.Size = New System.Drawing.Size(90, 21)
        Me.txtReference.TabIndex = 1
        '
        'cboTaxCode
        '
        Me.cboTaxCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboTaxCode.Location = New System.Drawing.Point(302, 223)
        Me.cboTaxCode.Name = "cboTaxCode"
        Me.cboTaxCode.Size = New System.Drawing.Size(93, 21)
        Me.cboTaxCode.TabIndex = 74
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.Location = New System.Drawing.Point(249, 166)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 20)
        Me.Label15.TabIndex = 85
        Me.Label15.Text = "Ex Ref."
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.Location = New System.Drawing.Point(243, 225)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 20)
        Me.Label13.TabIndex = 83
        Me.Label13.Text = "Tax Code"
        '
        'txtSupplierInvoiceAmount
        '
        Me.txtSupplierInvoiceAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSupplierInvoiceAmount.Location = New System.Drawing.Point(138, 223)
        Me.txtSupplierInvoiceAmount.MaxLength = 100
        Me.txtSupplierInvoiceAmount.Name = "txtSupplierInvoiceAmount"
        Me.txtSupplierInvoiceAmount.Size = New System.Drawing.Size(105, 21)
        Me.txtSupplierInvoiceAmount.TabIndex = 73
        Me.txtSupplierInvoiceAmount.Tag = "Order.SupplierInvoiceAmount"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.Location = New System.Drawing.Point(7, 222)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 20)
        Me.Label10.TabIndex = 80
        Me.Label10.Text = "Invoice Amount"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.Location = New System.Drawing.Point(7, 165)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 20)
        Me.Label9.TabIndex = 79
        Me.Label9.Text = "Invoice Ref."
        '
        'chkSupInvDateNA
        '
        Me.chkSupInvDateNA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkSupInvDateNA.Location = New System.Drawing.Point(138, 193)
        Me.chkSupInvDateNA.Name = "chkSupInvDateNA"
        Me.chkSupInvDateNA.Size = New System.Drawing.Size(48, 24)
        Me.chkSupInvDateNA.TabIndex = 71
        Me.chkSupInvDateNA.Text = "N/A"
        '
        'txtSupplierInvoiceReference
        '
        Me.txtSupplierInvoiceReference.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSupplierInvoiceReference.Location = New System.Drawing.Point(138, 162)
        Me.txtSupplierInvoiceReference.MaxLength = 100
        Me.txtSupplierInvoiceReference.Name = "txtSupplierInvoiceReference"
        Me.txtSupplierInvoiceReference.Size = New System.Drawing.Size(105, 21)
        Me.txtSupplierInvoiceReference.TabIndex = 69
        Me.txtSupplierInvoiceReference.Tag = "Order.SupplierInvoiceReference"
        '
        'dtpSupplierInvoiceDate
        '
        Me.dtpSupplierInvoiceDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpSupplierInvoiceDate.Location = New System.Drawing.Point(189, 196)
        Me.dtpSupplierInvoiceDate.Name = "dtpSupplierInvoiceDate"
        Me.dtpSupplierInvoiceDate.Size = New System.Drawing.Size(206, 21)
        Me.dtpSupplierInvoiceDate.TabIndex = 72
        Me.dtpSupplierInvoiceDate.Tag = "Order.SupplierInvoiceDate"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.Location = New System.Drawing.Point(7, 195)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 20)
        Me.Label11.TabIndex = 81
        Me.Label11.Text = "Invoice Date"
        '
        'grpOrders
        '
        Me.grpOrders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpOrders.Controls.Add(Me.dgOrders)
        Me.grpOrders.Location = New System.Drawing.Point(418, 38)
        Me.grpOrders.Name = "grpOrders"
        Me.grpOrders.Size = New System.Drawing.Size(475, 337)
        Me.grpOrders.TabIndex = 2
        Me.grpOrders.TabStop = False
        Me.grpOrders.Text = "Related Orders (Double click to view)"
        '
        'dgOrders
        '
        Me.dgOrders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgOrders.DataMember = ""
        Me.dgOrders.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgOrders.Location = New System.Drawing.Point(6, 23)
        Me.dgOrders.Name = "dgOrders"
        Me.dgOrders.Size = New System.Drawing.Size(463, 308)
        Me.dgOrders.TabIndex = 1
        '
        'grpItems
        '
        Me.grpItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpItems.Controls.Add(Me.lblOrderTotal)
        Me.grpItems.Controls.Add(Me.dgItems)
        Me.grpItems.Location = New System.Drawing.Point(12, 381)
        Me.grpItems.Name = "grpItems"
        Me.grpItems.Size = New System.Drawing.Size(881, 294)
        Me.grpItems.TabIndex = 3
        Me.grpItems.TabStop = False
        Me.grpItems.Text = "Related Items"
        '
        'lblOrderTotal
        '
        Me.lblOrderTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOrderTotal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderTotal.Location = New System.Drawing.Point(580, 17)
        Me.lblOrderTotal.Name = "lblOrderTotal"
        Me.lblOrderTotal.Size = New System.Drawing.Size(295, 15)
        Me.lblOrderTotal.TabIndex = 82
        Me.lblOrderTotal.Text = "Order Total : £0.00"
        Me.lblOrderTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgItems
        '
        Me.dgItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgItems.DataMember = ""
        Me.dgItems.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgItems.Location = New System.Drawing.Point(9, 35)
        Me.dgItems.Name = "dgItems"
        Me.dgItems.Size = New System.Drawing.Size(866, 253)
        Me.dgItems.TabIndex = 1
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(434, 681)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(249, 25)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "Print combined supplier purchase order"
        '
        'btnReceiveAll
        '
        Me.btnReceiveAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReceiveAll.Location = New System.Drawing.Point(689, 681)
        Me.btnReceiveAll.Name = "btnReceiveAll"
        Me.btnReceiveAll.Size = New System.Drawing.Size(138, 25)
        Me.btnReceiveAll.TabIndex = 5
        Me.btnReceiveAll.Text = "Save && Receive All"
        '
        'btnPrintDistribution
        '
        Me.btnPrintDistribution.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintDistribution.Location = New System.Drawing.Point(258, 681)
        Me.btnPrintDistribution.Name = "btnPrintDistribution"
        Me.btnPrintDistribution.Size = New System.Drawing.Size(170, 25)
        Me.btnPrintDistribution.TabIndex = 8
        Me.btnPrintDistribution.Text = "Print order distribution list"
        '
        'FRMConsolidation
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(905, 718)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnPrintDistribution)
        Me.Controls.Add(Me.btnReceiveAll)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.grpItems)
        Me.Controls.Add(Me.grpOrders)
        Me.Controls.Add(Me.grpMain)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.MinimumSize = New System.Drawing.Size(913, 752)
        Me.Name = "FRMConsolidation"
        Me.Text = "Consolidation : ID {0}"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.grpMain, 0)
        Me.Controls.SetChildIndex(Me.grpOrders, 0)
        Me.Controls.SetChildIndex(Me.grpItems, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.Controls.SetChildIndex(Me.btnReceiveAll, 0)
        Me.Controls.SetChildIndex(Me.btnPrintDistribution, 0)
        Me.grpMain.ResumeLayout(False)
        Me.grpMain.PerformLayout()
        Me.grpOrders.ResumeLayout(False)
        CType(Me.dgOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpItems.ResumeLayout(False)
        CType(Me.dgItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        OrderConsolidation = DB.OrderConsolidations.OrderConsolidation_Get(GetParameter(0))
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
        'DO NOTHING
    End Sub

#End Region

#Region "Setup"

    Private Sub SetupDG()
        Dim tbStyle As DataGridTableStyle = Me.dgOrders.TableStyles(0)

        tbStyle.GridColumnStyles.Clear()

        tbStyle.ReadOnly = False
        Me.dgOrders.ReadOnly = False
        tbStyle.AllowSorting = False

        If OrderConsolidation.ConsolidatedOrderStatusID <= Entity.Sys.Enums.OrderStatus.AwaitingConfirmation Then
            'Dim Tick As New DataGridBoolColumn
            'Tick.HeaderText = ""
            'Tick.MappingName = "Tick"
            'Tick.ReadOnly = False
            'Tick.Width = 25
            'Tick.NullText = ""
            'tbStyle.GridColumnStyles.Add(Tick)
        End If

        Dim OrderReference As New DataGridLabelColumn
        OrderReference.Format = ""
        OrderReference.FormatInfo = Nothing
        OrderReference.HeaderText = "Order Reference"
        OrderReference.MappingName = "OrderReference"
        OrderReference.ReadOnly = True
        OrderReference.Width = 100
        OrderReference.NullText = ""
        tbStyle.GridColumnStyles.Add(OrderReference)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 75
        Type.NullText = ""
        tbStyle.GridColumnStyles.Add(Type)

        Dim OrderFor As New DataGridLabelColumn
        OrderFor.Format = ""
        OrderFor.FormatInfo = Nothing
        OrderFor.HeaderText = "Order Is For"
        OrderFor.MappingName = "Destination"
        OrderFor.ReadOnly = True
        OrderFor.Width = 80
        OrderFor.NullText = ""
        tbStyle.GridColumnStyles.Add(OrderFor)

        Dim Status As New DataGridLabelColumn
        Status.Format = ""
        Status.FormatInfo = Nothing
        Status.HeaderText = "Status"
        Status.MappingName = "OrderStatus"
        Status.ReadOnly = True
        Status.Width = 100
        Status.NullText = ""
        tbStyle.GridColumnStyles.Add(Status)

        Dim DatePlaced As New DataGridLabelColumn
        DatePlaced.Format = ""
        DatePlaced.FormatInfo = Nothing
        DatePlaced.HeaderText = "Date Placed"
        DatePlaced.MappingName = "DatePlaced"
        DatePlaced.ReadOnly = True
        DatePlaced.Width = 100
        DatePlaced.NullText = ""
        tbStyle.GridColumnStyles.Add(DatePlaced)

        Dim CreatedBy As New DataGridLabelColumn
        CreatedBy.Format = ""
        CreatedBy.FormatInfo = Nothing
        CreatedBy.HeaderText = "Created By"
        CreatedBy.MappingName = "CreatedBy"
        CreatedBy.ReadOnly = True
        CreatedBy.Width = 100
        CreatedBy.NullText = ""
        tbStyle.GridColumnStyles.Add(CreatedBy)

        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblOrder.ToString
        Me.dgOrders.TableStyles.Add(tbStyle)
    End Sub

    Private Sub SetupItemsDG()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgItems)
        Dim tbStyle As DataGridTableStyle = Me.dgItems.TableStyles(0)

        tbStyle.GridColumnStyles.Clear()

        tbStyle.ReadOnly = False
        Me.dgItems.ReadOnly = False
        tbStyle.AllowSorting = False

        Dim Number As New DataGridLabelColumn
        Number.Format = ""
        Number.FormatInfo = Nothing
        Number.HeaderText = "Number"
        Number.MappingName = "Number"
        Number.ReadOnly = True
        Number.Width = 100
        Number.NullText = ""
        tbStyle.GridColumnStyles.Add(Number)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Name"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 200
        Name.NullText = ""
        tbStyle.GridColumnStyles.Add(Name)

        Dim BuyPrice As New DataGridLabelColumn
        BuyPrice.Format = "C"
        BuyPrice.FormatInfo = Nothing
        BuyPrice.HeaderText = "Buy Price"
        BuyPrice.MappingName = "BuyPrice"
        BuyPrice.ReadOnly = True
        BuyPrice.Width = 80
        BuyPrice.NullText = ""
        tbStyle.GridColumnStyles.Add(BuyPrice)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 75
        Type.NullText = ""
        tbStyle.GridColumnStyles.Add(Type)

        Dim Destination As New DataGridLabelColumn
        Destination.Format = ""
        Destination.FormatInfo = Nothing
        Destination.HeaderText = "Destination"
        Destination.MappingName = "Destination"
        Destination.ReadOnly = True
        Destination.Width = 100
        Destination.NullText = ""
        tbStyle.GridColumnStyles.Add(Destination)

        Dim OrderReference As New DataGridLabelColumn
        OrderReference.Format = ""
        OrderReference.FormatInfo = Nothing
        OrderReference.HeaderText = "Order"
        OrderReference.MappingName = "OrderReference"
        OrderReference.ReadOnly = True
        OrderReference.Width = 75
        OrderReference.NullText = ""
        tbStyle.GridColumnStyles.Add(OrderReference)

        Dim ItemsOnOrder As New DataGridLabelColumn
        ItemsOnOrder.Format = ""
        ItemsOnOrder.FormatInfo = Nothing
        ItemsOnOrder.HeaderText = "No. Ordered"
        ItemsOnOrder.MappingName = "QuantityOnOrder"
        ItemsOnOrder.ReadOnly = True
        ItemsOnOrder.Width = 75
        ItemsOnOrder.NullText = ""
        tbStyle.GridColumnStyles.Add(ItemsOnOrder)

        If OrderConsolidation.ConsolidatedOrderStatusID = Entity.Sys.Enums.OrderStatus.Confirmed Then
            Dim ItemsReceived As New DataGridLabelColumn
            ItemsReceived.Format = ""
            ItemsReceived.FormatInfo = Nothing
            ItemsReceived.HeaderText = "No. Received"
            ItemsReceived.MappingName = "QuantityReceived"
            ItemsReceived.ReadOnly = True
            ItemsReceived.Width = 75
            ItemsReceived.NullText = ""
            tbStyle.GridColumnStyles.Add(ItemsReceived)

            Dim EnterReceived As New DataGridTextBoxColumn
            EnterReceived.Format = ""
            EnterReceived.FormatInfo = Nothing
            EnterReceived.HeaderText = "Enter Received "
            EnterReceived.MappingName = "EnterReceived"
            EnterReceived.ReadOnly = False
            EnterReceived.Width = 75
            EnterReceived.NullText = ""
            EnterReceived.TextBox.BackColor = Color.LightYellow
            tbStyle.GridColumnStyles.Add(EnterReceived)
        End If

        If OrderConsolidation.ConsolidatedOrderStatusID = Entity.Sys.Enums.OrderStatus.Complete Then
            Dim ItemsReceived As New DataGridLabelColumn
            ItemsReceived.Format = ""
            ItemsReceived.FormatInfo = Nothing
            ItemsReceived.HeaderText = "No. Received"
            ItemsReceived.MappingName = "QuantityReceived"
            ItemsReceived.ReadOnly = True
            ItemsReceived.Width = 75
            ItemsReceived.NullText = ""
            tbStyle.GridColumnStyles.Add(ItemsReceived)
        End If

        tbStyle.MappingName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString
        Me.dgItems.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Properties"

    Private IsLoading As Boolean = True

    Private _OrderConsolidation As Entity.OrderConsolidations.OrderConsolidation

    Public Property OrderConsolidation() As Entity.OrderConsolidations.OrderConsolidation
        Get
            Return _OrderConsolidation
        End Get
        Set(ByVal Value As Entity.OrderConsolidations.OrderConsolidation)
            _OrderConsolidation = Value
            If OrderConsolidation Is Nothing Then
                _OrderConsolidation = New Entity.OrderConsolidations.OrderConsolidation
                _OrderConsolidation.Exists = False
            End If

            If Not OrderConsolidation.Exists Then
                Me.Text = "Consolidation : Adding New..."

                OrderNumber = DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.CONSOLIDATION)

                Combo.SetSelectedComboItem_By_Value(Me.cboStatus, Entity.Sys.Enums.OrderStatus.AwaitingConfirmation)
                Me.cboStatus.Enabled = False

                Me.btnPrint.Enabled = False
                Me.btnPrintDistribution.Enabled = False
                Me.btnReceiveAll.Enabled = False
                Me.chkPOSupplied.Enabled = False

                Me.txtSupplierInvoiceReference.ReadOnly = True
                Me.chkSupInvDateNA.Enabled = False
                Me.dtpSupplierInvoiceDate.Enabled = False
                Me.txtSupplierInvoiceAmount.ReadOnly = True
                Me.txtVAT.ReadOnly = True
                Me.cboTaxCode.Enabled = False
                Me.txtExtraReference.ReadOnly = True
                Me.txtNominalCode.ReadOnly = True
                Me.txtDepartment.ReadOnly = True
                Me.cbxReadyToSendToSage.Enabled = False
            Else
                Me.btnPrint.Enabled = True
                Me.btnPrintDistribution.Enabled = True

                Me.Text = "Consolidation : ID " & OrderConsolidation.OrderConsolidationID

                Populate()

                OrderNumberUsed = True
            End If

            SetupDG()
            SetupItemsDG()

            IsLoading = False
        End Set
    End Property

    Private _OrderNumber As New JobNumber

    Public Property OrderNumber() As JobNumber
        Get
            Return _OrderNumber
        End Get
        Set(ByVal Value As JobNumber)
            _OrderNumber = Value

            OrderNumberUsed = False

            OrderNumber.OrderNumber = OrderNumber.JobNumber

            While OrderNumber.OrderNumber.Length < 6
                OrderNumber.OrderNumber = "0" & OrderNumber.OrderNumber
            End While

            Me.txtReference.Text = OrderNumber.Prefix & OrderNumber.OrderNumber
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

    Private _Supplier As Entity.Suppliers.Supplier

    Public Property Supplier() As Entity.Suppliers.Supplier
        Get
            Return _Supplier
        End Get
        Set(ByVal Value As Entity.Suppliers.Supplier)
            _Supplier = Value
            If Supplier Is Nothing Then
                Me.txtSupplier.Text = ""
            Else
                Me.txtSupplier.Text = Supplier.Name & " (" & Supplier.AccountNumber & ")"

                ItemsDataView = DB.OrderConsolidations.Order_GetItemForConsolidationID(OrderConsolidation.OrderConsolidationID, False)

                If OrderConsolidation.Exists Then
                    If OrderConsolidation.ConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation) Then
                        OrderDataView = DB.OrderConsolidations.Order_GetForConsolidationByID(OrderConsolidation.OrderConsolidationID, _Supplier.SupplierID, 0)
                    Else
                        OrderDataView = DB.OrderConsolidations.Order_GetForConsolidationByID_Confirmed(OrderConsolidation.OrderConsolidationID, False)
                    End If
                Else
                    OrderDataView = DB.OrderConsolidations.Order_GetForConsolidation(_Supplier.SupplierID, 0)
                End If
            End If
        End Set
    End Property

    Private _OrderDataView As DataView = Nothing

    Public Property OrderDataView() As DataView
        Get
            Return _OrderDataView
        End Get
        Set(ByVal Value As DataView)
            _OrderDataView = Value
            _OrderDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
            _OrderDataView.AllowNew = False
            _OrderDataView.AllowEdit = True
            _OrderDataView.AllowDelete = False
            Me.dgOrders.DataSource = OrderDataView
        End Set
    End Property

    Private ReadOnly Property SelectedOrderDataRow() As DataRow
        Get
            If Not Me.dgOrders.CurrentRowIndex = -1 Then
                Return OrderDataView(Me.dgOrders.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _itemsDataView As DataView = Nothing

    Public Property ItemsDataView() As DataView
        Get
            Return _itemsDataView
        End Get
        Set(ByVal Value As DataView)
            _itemsDataView = Value
            _itemsDataView.Table.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString
            _itemsDataView.AllowNew = False
            _itemsDataView.AllowEdit = True
            _itemsDataView.AllowDelete = False
            Me.dgItems.DataSource = ItemsDataView

            Dim total As Double = 0.0
            For Each row As DataRow In ItemsDataView.Table.Rows
                total += FormatCurrency(Entity.Sys.Helper.MakeDoubleValid(FormatCurrency(row.Item("BuyPrice"), 2)) * Entity.Sys.Helper.MakeDoubleValid(FormatCurrency(row.Item("QuantityOnOrder"), 2)), 2)
            Next
            'PLUS ADDITIONAL
            For Each row As DataRow In DB.OrderCharge.OrderCharge_GetForConsolidatedOrder(OrderConsolidation.OrderConsolidationID).Table.Rows
                total += FormatCurrency(row.Item("Amount"), 2)
            Next

            Me.lblOrderTotal.Text = "Order Total : " & FormatCurrency(total, 2)
        End Set
    End Property

    Private ReadOnly Property SelectedItemDataRow() As DataRow
        Get
            If Not Me.dgItems.CurrentRowIndex = -1 Then
                Return ItemsDataView(Me.dgItems.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Events"

    Private Sub FRMConsolidation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Not OrderNumberUsed Then
            DB.Job.DeleteReservedOrderNumber(OrderNumber.JobNumber, OrderNumber.Prefix)
        End If
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub btnSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplier.Click
        Supplier = DB.Supplier.Supplier_Get(FindRecord(Entity.Sys.Enums.TableNames.tblSupplier))
    End Sub

    Private Sub chkSupInvDateNA_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSupInvDateNA.CheckedChanged
        If Me.chkSupInvDateNA.Checked Then
            Me.dtpSupplierInvoiceDate.Enabled = False
            Me.dtpSupplierInvoiceDate.Value = Now.Date
        Else
            Me.dtpSupplierInvoiceDate.Enabled = True
        End If
    End Sub

    Private Sub txtSupplierInvoiceAmount_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSupplierInvoiceAmount.GotFocus
        Me.txtSupplierInvoiceAmount.Text = ""
    End Sub

    Private Sub txtSupplierInvoiceAmount_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSupplierInvoiceAmount.Validating
        If Not Me.txtSupplierInvoiceAmount.Text.Trim.Length = 0 Then
            If IsNumeric(Me.txtSupplierInvoiceAmount.Text.Trim) Then
                OrderConsolidation.SetSupplierInvoiceAmount = Entity.Sys.Helper.MakeDoubleValid(Me.txtSupplierInvoiceAmount.Text.Trim)
            End If
        End If

        Me.txtSupplierInvoiceAmount.Text = Format(OrderConsolidation.SupplierInvoiceAmount, "C")

        Calculate_Tax()
    End Sub

    Private Sub txtVAT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVAT.GotFocus
        Me.txtVAT.Text = ""
    End Sub

    Private Sub txtVAT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtVAT.Validating
        If Not Me.txtVAT.Text.Trim.Length = 0 Then
            If IsNumeric(Me.txtVAT.Text.Trim) Then
                OrderConsolidation.SetVATAmount = Entity.Sys.Helper.MakeDoubleValid(Me.txtVAT.Text.Trim)
            End If
        End If

        Me.txtVAT.Text = Format(OrderConsolidation.VATAmount, "C")
    End Sub

    Private Sub cboTaxCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTaxCode.SelectedIndexChanged
        Calculate_Tax()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Save()
    End Sub

    Private Sub dgOrders_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgOrders.DoubleClick
        Select Case CInt(SelectedOrderDataRow.Item("OrderTypeID"))
            Case Entity.Sys.Enums.OrderType.Customer
                ShowForm(GetType(FRMOrder), True, New Object() {SelectedOrderDataRow.Item("OrderID"), Entity.Sys.Helper.MakeIntegerValid(SelectedOrderDataRow.Item("SiteID")), 0, Me, True})
            Case Entity.Sys.Enums.OrderType.StockProfile
                ShowForm(GetType(FRMOrder), True, New Object() {SelectedOrderDataRow.Item("OrderID"), SelectedOrderDataRow.Item("VanID"), 0, Me, True})
            Case Entity.Sys.Enums.OrderType.Warehouse
                ShowForm(GetType(FRMOrder), True, New Object() {SelectedOrderDataRow.Item("OrderID"), SelectedOrderDataRow.Item("WarehouseID"), 0, Me, True})
            Case Entity.Sys.Enums.OrderType.Job
                ShowForm(GetType(FRMOrder), True, New Object() {SelectedOrderDataRow.Item("OrderID"), SelectedOrderDataRow.Item("EngineerVisitID"), 0, Me, True})
        End Select
        If OrderConsolidation.Exists Then
            If OrderConsolidation.ConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation) Then
                OrderDataView = DB.OrderConsolidations.Order_GetForConsolidationByID(OrderConsolidation.OrderConsolidationID, _Supplier.SupplierID, 0)
            Else
                OrderDataView = DB.OrderConsolidations.Order_GetForConsolidationByID_Confirmed(OrderConsolidation.OrderConsolidationID, False)
            End If
        Else
            OrderDataView = DB.OrderConsolidations.Order_GetForConsolidation(_Supplier.SupplierID, 0)
        End If
    End Sub

    Dim DoubleClicked As Boolean = False

    Private Sub dgItems_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgItems.MouseUp
        If Not DoubleClicked Then
            Exit Sub
        End If

        Try
            If SelectedItemDataRow Is Nothing Then
                Exit Sub
            End If

            Dim HitTestInfo As DataGrid.HitTestInfo = Me.dgItems.HitTest(e.X, e.Y)
            If HitTestInfo.Row = -1 Then
                Exit Sub
            End If
            If ItemsDataView.Table.Rows(HitTestInfo.Row) Is Nothing Then
                Exit Sub
            End If
            If ItemsDataView.Table.Columns(HitTestInfo.Column).ColumnName.Trim.ToLower = "BuyPrice".ToLower Then
                ShowForm(GetType(FRMPart), True, New Object() {SelectedItemDataRow.Item("PartProductID"), True})
                Exit Sub
            Else
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub dgItems_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgItems.DoubleClick
        Try
            If SelectedItemDataRow Is Nothing Then
                DoubleClicked = False
                Exit Sub
            End If

            If Not SelectedItemDataRow.Item("Type") = "OrderPart" Then
                DoubleClicked = False
                Exit Sub
            End If

            DoubleClicked = True
        Catch ex As Exception
            DoubleClicked = False
        End Try
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboStatus.SelectedIndexChanged
        If IsLoading Then
            Exit Sub
        End If

        If Combo.GetSelectedItemValue(Me.cboStatus) > Entity.Sys.Enums.OrderStatus.AwaitingConfirmation Then
            Dim dept As Boolean = True
            Dim orderNum As String = ""
            For Each o As DataRow In OrderDataView.Table.Rows
                If Entity.Sys.Helper.MakeStringValid(o.Item("DepartmentRef")).Length = 0 Then
                    dept = False
                    orderNum += o("OrderReference")
                    Exit For
                End If
            Next

            If dept = False Then
                ShowMessage("Order " & orderNum & " is missing a department code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Combo.SetSelectedComboItem_By_Value(cboStatus, OrderConsolidation.ConsolidatedOrderStatusID)
                Exit Sub

            End If
        End If

        Select Case Combo.GetSelectedItemValue(Me.cboStatus)
            Case Entity.Sys.Enums.OrderStatus.AwaitingConfirmation
                If OrderConsolidation.ConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation) Then
                    Exit Sub
                End If

                If OrderConsolidation.ConsolidatedOrderStatusID > CInt(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation) Then
                    ShowMessage("You cannot go back once the consolidation has progressed.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Combo.SetSelectedComboItem_By_Value(cboStatus, OrderConsolidation.ConsolidatedOrderStatusID)
                    Exit Sub
                End If
            Case Entity.Sys.Enums.OrderStatus.Confirmed
                If OrderConsolidation.ConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Confirmed) Then
                    Exit Sub
                End If

                If OrderConsolidation.ConsolidatedOrderStatusID > CInt(Entity.Sys.Enums.OrderStatus.Confirmed) Then
                    ShowMessage("You cannot go back once the consolidation has progressed.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Combo.SetSelectedComboItem_By_Value(cboStatus, OrderConsolidation.ConsolidatedOrderStatusID)
                    Exit Sub
                End If

                If ShowMessage("Are you sure you want to confirm this consolidation and all related orders? No changes can be made to orders once it has been confirmed.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Combo.SetSelectedComboItem_By_Value(cboStatus, OrderConsolidation.ConsolidatedOrderStatusID)
                    Exit Sub
                Else
                    OrderConsolidation.SetConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Confirmed)
                End If
            Case Entity.Sys.Enums.OrderStatus.Cancelled
                If OrderConsolidation.ConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Cancelled) Then
                    Exit Sub
                End If

                If OrderConsolidation.ConsolidatedOrderStatusID > CInt(Entity.Sys.Enums.OrderStatus.Cancelled) Then
                    ShowMessage("You cannot go back once the consolidation has progressed.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Combo.SetSelectedComboItem_By_Value(cboStatus, OrderConsolidation.ConsolidatedOrderStatusID)
                    Exit Sub
                End If

                If ShowMessage("Are you sure you want to cancel this consolidation and all related orders?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    OrderConsolidation.SetConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Cancelled)
                Else
                    Combo.SetSelectedComboItem_By_Value(cboStatus, OrderConsolidation.ConsolidatedOrderStatusID)
                    Exit Sub
                End If
            Case Entity.Sys.Enums.OrderStatus.Complete
                If OrderConsolidation.ConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Complete) Then
                    Exit Sub
                End If

                If OrderConsolidation.ConsolidatedOrderStatusID < CInt(Entity.Sys.Enums.OrderStatus.Complete) Then
                    ShowMessage("You cannot complete a consolidation manually.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Combo.SetSelectedComboItem_By_Value(cboStatus, OrderConsolidation.ConsolidatedOrderStatusID)
                    Exit Sub
                End If
        End Select

        DB.OrderConsolidations.Update(OrderConsolidation)

        OrderConsolidation = DB.OrderConsolidations.OrderConsolidation_Get(OrderConsolidation.OrderConsolidationID)
    End Sub

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        PrintSupplierPurchaseOrders(False)
    End Sub

    Private Sub btnPrintDistribution_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintDistribution.Click
        PrintSupplierPurchaseOrders(True)
    End Sub

    Private Sub btnReceiveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiveAll.Click
        If OrderConsolidation.ConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation) Then
            ShowMessage("Consolidation must be confirmed to receive stock", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If OrderConsolidation.ConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Cancelled) Then
            ShowMessage("Consolidation has been cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If OrderConsolidation.ConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Complete) Then
            ShowMessage("Consolidation is fully received", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If OrderConsolidation.ConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Invoiced) Then
            ShowMessage("Consolidation is fully received", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If OrderConsolidation.ConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Sent_To_Sage) Then
            ShowMessage("Consolidation is fully received", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        For Each row As DataRow In ItemsDataView.Table.Rows
            row.Item("EnterReceived") = (row.Item("QuantityOnOrder") - row.Item("QuantityReceived"))

            If row.Item("EnterReceived") < 0 Then
                row.Item("EnterReceived") = 0
            End If
        Next

        Save()
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate()
        Me.txtReference.Text = OrderConsolidation.ConsolidationRef
        Combo.SetSelectedComboItem_By_Value(Me.cboStatus, OrderConsolidation.ConsolidatedOrderStatusID)
        Supplier = DB.Supplier.Supplier_Get(OrderConsolidation.SupplierID)
        Me.txtComments.Text = OrderConsolidation.Comments
        Me.chkPOSupplied.Checked = OrderConsolidation.HasSupplierPO
        Me.txtSupplierInvoiceReference.Text = OrderConsolidation.SupplierInvoiceReference
        If OrderConsolidation.SupplierInvoiceDate = Nothing Then
            Me.chkSupInvDateNA.Checked = True
            Me.dtpSupplierInvoiceDate.Value = Now.Date
            Me.dtpSupplierInvoiceDate.Enabled = False
        Else
            Me.chkSupInvDateNA.Checked = False
            Me.dtpSupplierInvoiceDate.Value = OrderConsolidation.SupplierInvoiceDate.Date
            Me.dtpSupplierInvoiceDate.Enabled = True
        End If
        Me.txtSupplierInvoiceAmount.Text = Format(OrderConsolidation.SupplierInvoiceAmount, "C")
        Combo.SetSelectedComboItem_By_Value(Me.cboTaxCode, OrderConsolidation.TaxCodeID)
        Me.txtVAT.Text = Format(OrderConsolidation.VATAmount, "C")
        Me.txtExtraReference.Text = OrderConsolidation.ExtraRef
        Me.txtNominalCode.Text = OrderConsolidation.NominalCode
        Me.txtDepartment.Text = OrderConsolidation.DepartmentRef
        Me.cbxReadyToSendToSage.Checked = OrderConsolidation.ReadyToSendToSage

        Me.txtReference.ReadOnly = True
        Me.btnSupplier.Enabled = False

        If OrderConsolidation.ConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Cancelled) Or OrderConsolidation.ConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Complete) Then
            Me.cboStatus.Enabled = False
            Me.btnReceiveAll.Enabled = False
            If OrderConsolidation.ConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Cancelled) Then
                Me.btnSave.Enabled = False
            Else
                Me.btnSave.Enabled = True
            End If
        Else
            Me.cboStatus.Enabled = True
            Me.btnSave.Enabled = True
            Me.btnReceiveAll.Enabled = True
        End If

        If OrderConsolidation.SentToSage Then
            Me.chkPOSupplied.Enabled = False
            Me.txtSupplierInvoiceReference.ReadOnly = True
            Me.chkSupInvDateNA.Enabled = False
            Me.dtpSupplierInvoiceDate.Enabled = False
            Me.txtSupplierInvoiceAmount.ReadOnly = True
            Me.txtVAT.ReadOnly = True
            Me.cboTaxCode.Enabled = False
            Me.txtExtraReference.ReadOnly = True
            Me.txtNominalCode.ReadOnly = True
            Me.txtDepartment.ReadOnly = True
            Me.cbxReadyToSendToSage.Enabled = False
            Me.btnSave.Enabled = False
            Me.lblStatus.Text = "*Supplier PI was Sent to Sage on " & Format(OrderConsolidation.DateExported, "dd/MMM/yyyy") & "*"
        Else
            If OrderConsolidation.ReadyToSendToSage Then
                Me.chkPOSupplied.Enabled = False
                Me.txtSupplierInvoiceReference.ReadOnly = True
                Me.chkSupInvDateNA.Enabled = False
                Me.dtpSupplierInvoiceDate.Enabled = False
                Me.txtSupplierInvoiceAmount.ReadOnly = True
                Me.txtVAT.ReadOnly = True
                Me.cboTaxCode.Enabled = False
                Me.txtExtraReference.ReadOnly = True
                Me.txtNominalCode.ReadOnly = True
                Me.txtDepartment.ReadOnly = True
                Me.cbxReadyToSendToSage.Enabled = True
                Me.lblStatus.Text = "*Supplier PI is ready to be sent to Sage*"
            Else
                If OrderConsolidation.HasSupplierPO Then
                    Me.chkPOSupplied.Enabled = True
                    Me.txtSupplierInvoiceReference.ReadOnly = False
                    Me.chkSupInvDateNA.Enabled = True
                    Me.txtSupplierInvoiceAmount.ReadOnly = False
                    Me.txtVAT.ReadOnly = False
                    Me.cboTaxCode.Enabled = True
                    Me.txtExtraReference.ReadOnly = False
                    Me.txtNominalCode.ReadOnly = False
                    Me.txtDepartment.ReadOnly = False
                    Me.cbxReadyToSendToSage.Enabled = True
                    Me.lblStatus.Text = "*Supplier PI is assigned but not ready to be sent to Sage*"
                Else
                    Me.chkPOSupplied.Enabled = True
                    Me.txtSupplierInvoiceReference.ReadOnly = True
                    Me.chkSupInvDateNA.Enabled = False
                    Me.dtpSupplierInvoiceDate.Enabled = False
                    Me.txtSupplierInvoiceAmount.ReadOnly = True
                    Me.txtVAT.ReadOnly = True
                    Me.cboTaxCode.Enabled = False
                    Me.txtExtraReference.ReadOnly = True
                    Me.txtNominalCode.ReadOnly = True
                    Me.txtDepartment.ReadOnly = True
                    Me.cbxReadyToSendToSage.Enabled = False
                    Me.lblStatus.Text = "*Supplier PI has NOT been assigned so should be actioned within each related order*"
                End If
            End If
        End If
    End Sub

    Private Sub Calculate_Tax()
        If IsLoading Then
            Exit Sub
        End If
        If OrderConsolidation Is Nothing Then
            Me.txtVAT.Text = Format(0.0, "C")
        Else
            If Combo.GetSelectedItemValue(Me.cboTaxCode) = 0 Then
                Me.txtVAT.Text = Format(OrderConsolidation.VATAmount, "C")
            Else
                Try
                    OrderConsolidation.SetVATAmount = OrderConsolidation.SupplierInvoiceAmount * (DB.Picklists.Get_One_As_Object(Combo.GetSelectedItemValue(Me.cboTaxCode)).PercentageRate / 100)
                    Me.txtVAT.Text = Format(OrderConsolidation.VATAmount, "C")
                Catch ex As Exception
                    Me.txtVAT.Text = Format(OrderConsolidation.VATAmount, "C")
                End Try
            End If
        End If
    End Sub

    Private Sub Save()
        Try
            Dim amountReceived As Boolean = True

            If OrderConsolidation.ConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Confirmed) Then
                If Not ItemsDataView Is Nothing Then
                    For Each itm As DataRow In ItemsDataView.Table.Rows
                        If (Entity.Sys.Helper.MakeIntegerValid(itm("EnterReceived")) + itm("QuantityReceived")) >
                        itm("QuantityOnOrder") Then
                            amountReceived = False
                        End If
                    Next itm
                End If
            End If

            If amountReceived = False Then
                If ShowMessage("Some of the amounts entered for received are greater than the quantity ordered. Are you sure you wish to receive this quantity of stock?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Exit Sub
                End If
            End If

            Me.Cursor = Cursors.WaitCursor
            OrderConsolidation.IgnoreExceptionsOnSetMethods = True
            OrderConsolidation.SetConsolidationRef = Me.txtReference.Text.Trim
            OrderConsolidation.SetComments = Me.txtComments.Text.Trim
            If Supplier Is Nothing Then
                OrderConsolidation.SetSupplierID = 0
            Else
                OrderConsolidation.SetSupplierID = Supplier.SupplierID
            End If
            OrderConsolidation.SetConsolidatedOrderStatusID = Combo.GetSelectedItemValue(cboStatus)
            OrderConsolidation.HasSupplierPO = Me.chkPOSupplied.Checked
            OrderConsolidation.SetSupplierInvoiceReference = Me.txtSupplierInvoiceReference.Text.Trim
            If Me.chkSupInvDateNA.Checked Then
                OrderConsolidation.SupplierInvoiceDate = Nothing
            Else
                OrderConsolidation.SupplierInvoiceDate = Me.dtpSupplierInvoiceDate.Value.Date
            End If
            OrderConsolidation.SetTaxCodeID = Combo.GetSelectedItemValue(Me.cboTaxCode)
            OrderConsolidation.SetExtraRef = Me.txtExtraReference.Text.Trim
            OrderConsolidation.SetNominalCode = Me.txtNominalCode.Text.Trim
            OrderConsolidation.SetDepartmentRef = Me.txtDepartment.Text.Trim
            OrderConsolidation.SetReadyToSendToSage = Me.cbxReadyToSendToSage.Checked

            Dim oCValidator As New Entity.OrderConsolidations.OrderConsolidationValidator
            oCValidator.Validate(OrderConsolidation, False)

            If OrderConsolidation.ReadyToSendToSage Then
                Dim itemAmount As Double = 0.0
                For Each row As DataRow In ItemsDataView.Table.Rows
                    itemAmount += (row.Item("BuyPrice") * row.Item("QuantityOnOrder"))
                Next
                'PLUS ADDITIONAL
                For Each row As DataRow In DB.OrderCharge.OrderCharge_GetForConsolidatedOrder(OrderConsolidation.OrderConsolidationID).Table.Rows
                    itemAmount += row.Item("Amount")
                Next
                If Not Format(OrderConsolidation.SupplierInvoiceAmount, "F") = Format(itemAmount, "F") Then
                    ShowMessage("The entered supplier invoice amount does not match the total of the consolidation. You will now be prompted to enter the override password to continue", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    If Not EnterOverridePassword() Then
                        Exit Sub
                    End If
                End If
            End If

            If Not OrderConsolidation.Exists = True Then
                OrderConsolidation.SetOrderConsolidationID = DB.OrderConsolidations.Insert(OrderConsolidation)
                OrderNumberUsed = True
            End If

            DB.OrderConsolidations.OrderConsolidation_Clear_Orders(OrderConsolidation.OrderConsolidationID)

            For Each row As DataRow In OrderDataView.Table.Select("Tick = True")
                DB.OrderConsolidations.Order_Set_Consolidated(OrderConsolidation.OrderConsolidationID, row.Item("OrderID"), False)
            Next

            If OrderConsolidation.ConsolidatedOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Confirmed) Then
                ReceivedQuantityUpdated()
            End If

            DB.OrderConsolidations.Update(OrderConsolidation)

            IsLoading = True

            OrderConsolidation = DB.OrderConsolidations.OrderConsolidation_Get(OrderConsolidation.OrderConsolidationID)
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

    Private Sub ReceivedQuantityUpdated()
        For Each itm As DataRow In ItemsDataView.Table.Rows
            If Entity.Sys.Helper.MakeIntegerValid(itm("EnterReceived")) > 0 Then
                SaveReceived(itm("Type"), itm("EnterReceived"), itm("OrderProductPartID"), itm("OrderTypeID"))
            End If
        Next itm

        Dim ds As DataSet = DB.OrderConsolidations.Orders_Complete_ByConsolidationOrderID(OrderConsolidation.OrderConsolidationID)

        For Each row As DataRow In ds.Tables(0).Rows
            Dim dv As DataView = DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(row.Item("EngineerVisitID"))
            Dim allComplete As Boolean = True
            For Each dr As DataRow In dv.Table.Rows
                If Not Entity.Sys.Helper.MakeIntegerValid(dr("OrderStatusID")) = 0 Then
                    If Not (dr("OrderStatusID") = CInt(Entity.Sys.Enums.OrderStatus.Complete)) Then
                        allComplete = False
                    End If
                End If
            Next
            If allComplete Then
                Dim oEngineerVisit As Entity.EngineerVisits.EngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(row.Item("EngineerVisitID"))

                ShowForm(GetType(FRMPickDespatchDetails), True, New Object() {oEngineerVisit})
            End If
        Next

        For Each row As DataRow In ds.Tables(1).Rows
            If row.Item("InvoiceToBeRaisedID") = 0 Then
                If ShowMessage("The customer order '" & row.Item("OrderDetails") & "' which this consolidation relates to requires an invoice address. Would you like to assign now?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    ShowForm(GetType(FrmRaiseInvoiceDetails), True, New Object() {row.Item("OrderID"), row.Item("InvoiceAddressID")})
                End If
            End If
        Next

        OrderConsolidation.SetConsolidatedOrderStatusID = ds.Tables(2).Rows(0).Item("ConsolidatedOrderStatusID")
    End Sub

    Private Sub SaveReceived(ByVal Type As String, ByVal QuantityInput As Integer, ByVal OrderProductPartID As Integer, ByVal OrderTypeID As Integer)
        Select Case Type
            Case "OrderPart"
                Dim OrderPart As Entity.OrderParts.OrderPart = DB.OrderPart.OrderPart_Get(OrderProductPartID)
                OrderPart.SetQuantityReceived = OrderPart.QuantityReceived + QuantityInput
                DB.OrderPart.Update(OrderPart)

                Select Case OrderTypeID
                    Case CInt(Entity.Sys.Enums.OrderType.Customer)
                        'DO NOTHING
                    Case CInt(Entity.Sys.Enums.OrderType.Job)
                        'DO NOTHING
                    Case CInt(Entity.Sys.Enums.OrderType.StockProfile)
                        'DO NOTHING - DONE ON PDA
                    Case CInt(Entity.Sys.Enums.OrderType.Warehouse)
                        Dim oOrderLocation As Entity.OrderLocations.OrderLocation = DB.OrderLocation.OrderLocation_GetForOrder(OrderPart.OrderID)
                        Dim oPartSupplier As Entity.PartSuppliers.PartSupplier = DB.PartSupplier.PartSupplier_Get(OrderPart.PartSupplierID)

                        Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                        oPartTransaction.SetLocationID = oOrderLocation.LocationID
                        oPartTransaction.SetPartID = oPartSupplier.PartID
                        oPartTransaction.SetOrderPartID = OrderPart.OrderPartID
                        oPartTransaction.SetAmount = QuantityInput * oPartSupplier.QuantityInPack
                        oPartTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockIn)
                        DB.PartTransaction.Insert(oPartTransaction)
                End Select
            Case "OrderProduct"
                Dim OrderProduct As Entity.OrderProducts.OrderProduct = DB.OrderProduct.OrderProduct_Get(OrderProductPartID)
                OrderProduct.SetQuantityReceived = OrderProduct.QuantityReceived + QuantityInput
                DB.OrderProduct.Update(OrderProduct)

                Select Case OrderTypeID
                    Case CInt(Entity.Sys.Enums.OrderType.Customer)
                        'DO NOTHING
                    Case CInt(Entity.Sys.Enums.OrderType.Job)
                        'DO NOTHING
                    Case CInt(Entity.Sys.Enums.OrderType.StockProfile)
                        'DO NOTHING - DONE ON PDA
                    Case CInt(Entity.Sys.Enums.OrderType.Warehouse)
                        Dim oOrderLocation As Entity.OrderLocations.OrderLocation = DB.OrderLocation.OrderLocation_GetForOrder(OrderProduct.OrderID)
                        Dim oProductSupplier As Entity.ProductSuppliers.ProductSupplier = DB.ProductSupplier.ProductSupplier_Get(OrderProduct.ProductSupplierID)

                        Dim oProductTransaction As New Entity.ProductTransactions.ProductTransaction
                        oProductTransaction.SetLocationID = oOrderLocation.LocationID
                        oProductTransaction.SetProductID = oProductSupplier.ProductID
                        oProductTransaction.SetOrderProductID = OrderProduct.OrderProductID
                        oProductTransaction.SetAmount = QuantityInput * oProductSupplier.QuantityInPack
                        oProductTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockIn)
                        DB.ProductTransaction.Insert(oProductTransaction)
                End Select
        End Select
    End Sub

    Public Sub PrintSupplierPurchaseOrders(ByVal ShowDestination As Boolean)
        Dim dtAdditionalCharges As New DataTable
        dtAdditionalCharges.Columns.Add("OrderChargeID")
        dtAdditionalCharges.Columns.Add("OrderID")
        dtAdditionalCharges.Columns.Add("OrderChargeTypeID")
        dtAdditionalCharges.Columns.Add("Amount")
        dtAdditionalCharges.Columns.Add("Reference")
        dtAdditionalCharges.Columns.Add("ChargeType")
        dtAdditionalCharges.Columns.Add("Deleted")

        Dim details As New ArrayList
        details.Add(OrderConsolidation.ConsolidationRef)
        details.Add(DB.Supplier.Supplier_Get(OrderConsolidation.SupplierID))
        details.Add(ItemsDataView.Table)

        Dim deadLine As DateTime = DateTime.MaxValue
        For Each row As DataRow In OrderDataView.Table.Rows
            If Entity.Sys.Helper.MakeDateTimeValid(row.Item("DeliveryDeadline")).Date < deadLine.Date Then
                deadLine = Entity.Sys.Helper.MakeDateTimeValid(row.Item("DeliveryDeadline")).Date
            End If

            'GET ADDITIONAL CHARGES
            Dim dvOrderAdditionalCharges As DataView = DB.OrderCharge.OrderCharge_GetForOrder(row("OrderID"))
            For Each drAdditional As DataRow In dvOrderAdditionalCharges.Table.Rows
                Dim newRw As DataRow
                newRw = dtAdditionalCharges.NewRow
                newRw("OrderChargeID") = drAdditional("OrderChargeID")
                newRw("OrderID") = drAdditional("OrderID")
                newRw("OrderChargeTypeID") = drAdditional("OrderChargeTypeID")
                newRw("Amount") = drAdditional("Amount")
                newRw("Reference") = drAdditional("Reference")
                newRw("ChargeType") = drAdditional("ChargeType")
                newRw("Deleted") = drAdditional("Deleted")
                dtAdditionalCharges.Rows.Add(newRw)
            Next
        Next

        details.Add(deadLine)

        details.Add(New DataView(dtAdditionalCharges))

        If ShowDestination Then
            Dim oPrint As New Entity.Sys.Printing(details, "SupplierPurchaseOrder", Entity.Sys.Enums.SystemDocumentType.SupplierPurchaseOrder_WithDestination)
        Else
            Dim oPrint As New Entity.Sys.Printing(details, "SupplierPurchaseOrder", Entity.Sys.Enums.SystemDocumentType.SupplierPurchaseOrder)
        End If
    End Sub

#End Region

End Class