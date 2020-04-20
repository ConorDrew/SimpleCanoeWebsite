Public Class UCGenerateQuote : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(Me.cboUsers, DB.User.GetAll().Table, "UserID", "FullName", Entity.Sys.Enums.ComboValues.Please_Select)
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
    Friend WithEvents tcQuote As System.Windows.Forms.TabControl

    Friend WithEvents tabDetails As System.Windows.Forms.TabPage
    Friend WithEvents tabItems As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgProducts As System.Windows.Forms.DataGrid
    Friend WithEvents btnRemoveProducts As System.Windows.Forms.Button
    Friend WithEvents btnFindProduct As System.Windows.Forms.Button
    Friend WithEvents btnFindPart As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgParts As System.Windows.Forms.DataGrid
    Friend WithEvents btnRemoveParts As System.Windows.Forms.Button
    Friend WithEvents txtAvailability As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPriceExcludeDetails As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtPriceDetails As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtpValidUntil As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtpEnquiryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCustRef As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboUsers As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkDeadlineNA As System.Windows.Forms.CheckBox
    Friend WithEvents dtpDeliveryDeadline As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnFindContact As System.Windows.Forms.Button
    Friend WithEvents txtContact As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnFindInvoiceAddress As System.Windows.Forms.Button
    Friend WithEvents txtInvoiceAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSpecialInstructions As System.Windows.Forms.TextBox
    Friend WithEvents btnFindSite As System.Windows.Forms.Button
    Friend WithEvents txtSite As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnFindCustomer As System.Windows.Forms.Button
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tabRequests As System.Windows.Forms.TabPage
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgPriceRequests As System.Windows.Forms.DataGrid
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dgConfirmedPriceRequests As System.Windows.Forms.DataGrid
    Friend WithEvents lblWarehouse As System.Windows.Forms.Label
    Friend WithEvents txtWarehouse As System.Windows.Forms.TextBox
    Friend WithEvents btnFindWarehouse As System.Windows.Forms.Button
    Friend WithEvents lblSpecial As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tcQuote = New System.Windows.Forms.TabControl
        Me.tabDetails = New System.Windows.Forms.TabPage
        Me.btnFindWarehouse = New System.Windows.Forms.Button
        Me.txtWarehouse = New System.Windows.Forms.TextBox
        Me.lblWarehouse = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtAvailability = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtPriceExcludeDetails = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtPriceDetails = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.dtpValidUntil = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.dtpEnquiryDate = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtCustRef = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboUsers = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.chkDeadlineNA = New System.Windows.Forms.CheckBox
        Me.dtpDeliveryDeadline = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnFindContact = New System.Windows.Forms.Button
        Me.txtContact = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnFindInvoiceAddress = New System.Windows.Forms.Button
        Me.txtInvoiceAddress = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblSpecial = New System.Windows.Forms.Label
        Me.txtSpecialInstructions = New System.Windows.Forms.TextBox
        Me.btnFindSite = New System.Windows.Forms.Button
        Me.txtSite = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnFindCustomer = New System.Windows.Forms.Button
        Me.txtCustomer = New System.Windows.Forms.TextBox
        Me.tabRequests = New System.Windows.Forms.TabPage
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.dgConfirmedPriceRequests = New System.Windows.Forms.DataGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgPriceRequests = New System.Windows.Forms.DataGrid
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.lblSearch = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.tabItems = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dgParts = New System.Windows.Forms.DataGrid
        Me.btnRemoveParts = New System.Windows.Forms.Button
        Me.btnFindPart = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgProducts = New System.Windows.Forms.DataGrid
        Me.btnRemoveProducts = New System.Windows.Forms.Button
        Me.btnFindProduct = New System.Windows.Forms.Button
        Me.tcQuote.SuspendLayout()
        Me.tabDetails.SuspendLayout()
        Me.tabRequests.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgConfirmedPriceRequests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgPriceRequests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabItems.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgParts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcQuote
        '
        Me.tcQuote.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcQuote.Controls.Add(Me.tabDetails)
        Me.tcQuote.Controls.Add(Me.tabRequests)
        Me.tcQuote.Controls.Add(Me.tabItems)
        Me.tcQuote.Location = New System.Drawing.Point(8, 8)
        Me.tcQuote.Name = "tcQuote"
        Me.tcQuote.SelectedIndex = 0
        Me.tcQuote.Size = New System.Drawing.Size(552, 496)
        Me.tcQuote.TabIndex = 0
        '
        'tabDetails
        '
        Me.tabDetails.Controls.Add(Me.btnFindWarehouse)
        Me.tabDetails.Controls.Add(Me.txtWarehouse)
        Me.tabDetails.Controls.Add(Me.lblWarehouse)
        Me.tabDetails.Controls.Add(Me.Label3)
        Me.tabDetails.Controls.Add(Me.cboStatus)
        Me.tabDetails.Controls.Add(Me.Label16)
        Me.tabDetails.Controls.Add(Me.txtAvailability)
        Me.tabDetails.Controls.Add(Me.Label15)
        Me.tabDetails.Controls.Add(Me.txtPriceExcludeDetails)
        Me.tabDetails.Controls.Add(Me.Label14)
        Me.tabDetails.Controls.Add(Me.txtPriceDetails)
        Me.tabDetails.Controls.Add(Me.Label13)
        Me.tabDetails.Controls.Add(Me.dtpValidUntil)
        Me.tabDetails.Controls.Add(Me.Label12)
        Me.tabDetails.Controls.Add(Me.dtpEnquiryDate)
        Me.tabDetails.Controls.Add(Me.Label11)
        Me.tabDetails.Controls.Add(Me.txtCustRef)
        Me.tabDetails.Controls.Add(Me.Label10)
        Me.tabDetails.Controls.Add(Me.cboUsers)
        Me.tabDetails.Controls.Add(Me.Label9)
        Me.tabDetails.Controls.Add(Me.chkDeadlineNA)
        Me.tabDetails.Controls.Add(Me.dtpDeliveryDeadline)
        Me.tabDetails.Controls.Add(Me.Label8)
        Me.tabDetails.Controls.Add(Me.btnFindContact)
        Me.tabDetails.Controls.Add(Me.txtContact)
        Me.tabDetails.Controls.Add(Me.Label7)
        Me.tabDetails.Controls.Add(Me.btnFindInvoiceAddress)
        Me.tabDetails.Controls.Add(Me.txtInvoiceAddress)
        Me.tabDetails.Controls.Add(Me.Label6)
        Me.tabDetails.Controls.Add(Me.lblSpecial)
        Me.tabDetails.Controls.Add(Me.txtSpecialInstructions)
        Me.tabDetails.Controls.Add(Me.btnFindSite)
        Me.tabDetails.Controls.Add(Me.txtSite)
        Me.tabDetails.Controls.Add(Me.Label1)
        Me.tabDetails.Controls.Add(Me.btnFindCustomer)
        Me.tabDetails.Controls.Add(Me.txtCustomer)
        Me.tabDetails.Location = New System.Drawing.Point(4, 22)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Size = New System.Drawing.Size(544, 470)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "Quote Details"
        '
        'btnFindWarehouse
        '
        Me.btnFindWarehouse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindWarehouse.BackColor = System.Drawing.Color.White
        Me.btnFindWarehouse.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindWarehouse.Location = New System.Drawing.Point(504, 56)
        Me.btnFindWarehouse.Name = "btnFindWarehouse"
        Me.btnFindWarehouse.Size = New System.Drawing.Size(32, 23)
        Me.btnFindWarehouse.TabIndex = 117
        Me.btnFindWarehouse.Text = "..."
        '
        'txtWarehouse
        '
        Me.txtWarehouse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWarehouse.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWarehouse.Location = New System.Drawing.Point(144, 56)
        Me.txtWarehouse.Name = "txtWarehouse"
        Me.txtWarehouse.ReadOnly = True
        Me.txtWarehouse.Size = New System.Drawing.Size(352, 21)
        Me.txtWarehouse.TabIndex = 116
        Me.txtWarehouse.Text = ""
        '
        'lblWarehouse
        '
        Me.lblWarehouse.Location = New System.Drawing.Point(8, 56)
        Me.lblWarehouse.Name = "lblWarehouse"
        Me.lblWarehouse.TabIndex = 115
        Me.lblWarehouse.Text = "Warehouse"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 23)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "Customer"
        '
        'cboStatus
        '
        Me.cboStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStatus.Location = New System.Drawing.Point(144, 248)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(392, 21)
        Me.cboStatus.TabIndex = 16
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(8, 248)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 23)
        Me.Label16.TabIndex = 113
        Me.Label16.Text = "Status:"
        '
        'txtAvailability
        '
        Me.txtAvailability.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAvailability.Location = New System.Drawing.Point(144, 356)
        Me.txtAvailability.Multiline = True
        Me.txtAvailability.Name = "txtAvailability"
        Me.txtAvailability.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAvailability.Size = New System.Drawing.Size(392, 40)
        Me.txtAvailability.TabIndex = 19
        Me.txtAvailability.Text = ""
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 356)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(120, 24)
        Me.Label15.TabIndex = 111
        Me.Label15.Text = "Availability:"
        '
        'txtPriceExcludeDetails
        '
        Me.txtPriceExcludeDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPriceExcludeDetails.Location = New System.Drawing.Point(144, 314)
        Me.txtPriceExcludeDetails.Multiline = True
        Me.txtPriceExcludeDetails.Name = "txtPriceExcludeDetails"
        Me.txtPriceExcludeDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPriceExcludeDetails.Size = New System.Drawing.Size(392, 40)
        Me.txtPriceExcludeDetails.TabIndex = 18
        Me.txtPriceExcludeDetails.Text = ""
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(8, 314)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 40)
        Me.Label14.TabIndex = 109
        Me.Label14.Text = "Prices Quoted Exclude:"
        '
        'txtPriceDetails
        '
        Me.txtPriceDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPriceDetails.Location = New System.Drawing.Point(144, 272)
        Me.txtPriceDetails.Multiline = True
        Me.txtPriceDetails.Name = "txtPriceDetails"
        Me.txtPriceDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPriceDetails.Size = New System.Drawing.Size(392, 40)
        Me.txtPriceDetails.TabIndex = 17
        Me.txtPriceDetails.Text = ""
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 272)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(120, 23)
        Me.Label13.TabIndex = 107
        Me.Label13.Text = "Prices Quoted Are:"
        '
        'dtpValidUntil
        '
        Me.dtpValidUntil.Location = New System.Drawing.Point(144, 200)
        Me.dtpValidUntil.Name = "dtpValidUntil"
        Me.dtpValidUntil.Size = New System.Drawing.Size(216, 21)
        Me.dtpValidUntil.TabIndex = 13
        Me.dtpValidUntil.Tag = "Order.DatePlaced"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(8, 200)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(114, 23)
        Me.Label12.TabIndex = 105
        Me.Label12.Text = "Valid Until"
        '
        'dtpEnquiryDate
        '
        Me.dtpEnquiryDate.Location = New System.Drawing.Point(144, 176)
        Me.dtpEnquiryDate.Name = "dtpEnquiryDate"
        Me.dtpEnquiryDate.Size = New System.Drawing.Size(216, 21)
        Me.dtpEnquiryDate.TabIndex = 12
        Me.dtpEnquiryDate.Tag = "Order.DatePlaced"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 176)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(114, 23)
        Me.Label11.TabIndex = 103
        Me.Label11.Text = "Enquiry Date"
        '
        'txtCustRef
        '
        Me.txtCustRef.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustRef.Location = New System.Drawing.Point(144, 152)
        Me.txtCustRef.Name = "txtCustRef"
        Me.txtCustRef.Size = New System.Drawing.Size(392, 21)
        Me.txtCustRef.TabIndex = 11
        Me.txtCustRef.Text = ""
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 152)
        Me.Label10.Name = "Label10"
        Me.Label10.TabIndex = 101
        Me.Label10.Text = "Customer Ref"
        '
        'cboUsers
        '
        Me.cboUsers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboUsers.Location = New System.Drawing.Point(144, 128)
        Me.cboUsers.Name = "cboUsers"
        Me.cboUsers.Size = New System.Drawing.Size(392, 21)
        Me.cboUsers.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 24)
        Me.Label9.TabIndex = 99
        Me.Label9.Text = "Product Co-ordinator"
        '
        'chkDeadlineNA
        '
        Me.chkDeadlineNA.Location = New System.Drawing.Point(144, 224)
        Me.chkDeadlineNA.Name = "chkDeadlineNA"
        Me.chkDeadlineNA.Size = New System.Drawing.Size(48, 24)
        Me.chkDeadlineNA.TabIndex = 14
        Me.chkDeadlineNA.Text = "N/A"
        '
        'dtpDeliveryDeadline
        '
        Me.dtpDeliveryDeadline.Location = New System.Drawing.Point(192, 224)
        Me.dtpDeliveryDeadline.Name = "dtpDeliveryDeadline"
        Me.dtpDeliveryDeadline.Size = New System.Drawing.Size(168, 21)
        Me.dtpDeliveryDeadline.TabIndex = 15
        Me.dtpDeliveryDeadline.Tag = "Order.DatePlaced"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 224)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 23)
        Me.Label8.TabIndex = 96
        Me.Label8.Text = "Delivery Deadline"
        '
        'btnFindContact
        '
        Me.btnFindContact.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindContact.BackColor = System.Drawing.Color.White
        Me.btnFindContact.Enabled = False
        Me.btnFindContact.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindContact.Location = New System.Drawing.Point(504, 104)
        Me.btnFindContact.Name = "btnFindContact"
        Me.btnFindContact.Size = New System.Drawing.Size(32, 24)
        Me.btnFindContact.TabIndex = 9
        Me.btnFindContact.Text = "..."
        '
        'txtContact
        '
        Me.txtContact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContact.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContact.Location = New System.Drawing.Point(144, 104)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.ReadOnly = True
        Me.txtContact.Size = New System.Drawing.Size(352, 21)
        Me.txtContact.TabIndex = 8
        Me.txtContact.Text = ""
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 24)
        Me.Label7.TabIndex = 93
        Me.Label7.Text = "Contact"
        '
        'btnFindInvoiceAddress
        '
        Me.btnFindInvoiceAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindInvoiceAddress.BackColor = System.Drawing.Color.White
        Me.btnFindInvoiceAddress.Enabled = False
        Me.btnFindInvoiceAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindInvoiceAddress.Location = New System.Drawing.Point(504, 80)
        Me.btnFindInvoiceAddress.Name = "btnFindInvoiceAddress"
        Me.btnFindInvoiceAddress.Size = New System.Drawing.Size(32, 24)
        Me.btnFindInvoiceAddress.TabIndex = 7
        Me.btnFindInvoiceAddress.Text = "..."
        '
        'txtInvoiceAddress
        '
        Me.txtInvoiceAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInvoiceAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceAddress.Location = New System.Drawing.Point(144, 80)
        Me.txtInvoiceAddress.Name = "txtInvoiceAddress"
        Me.txtInvoiceAddress.ReadOnly = True
        Me.txtInvoiceAddress.Size = New System.Drawing.Size(352, 21)
        Me.txtInvoiceAddress.TabIndex = 6
        Me.txtInvoiceAddress.Text = ""
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 24)
        Me.Label6.TabIndex = 90
        Me.Label6.Text = "Invoice Address"
        '
        'lblSpecial
        '
        Me.lblSpecial.Location = New System.Drawing.Point(8, 398)
        Me.lblSpecial.Name = "lblSpecial"
        Me.lblSpecial.Size = New System.Drawing.Size(80, 40)
        Me.lblSpecial.TabIndex = 87
        Me.lblSpecial.Text = "Special Instructions"
        '
        'txtSpecialInstructions
        '
        Me.txtSpecialInstructions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSpecialInstructions.Location = New System.Drawing.Point(144, 398)
        Me.txtSpecialInstructions.Multiline = True
        Me.txtSpecialInstructions.Name = "txtSpecialInstructions"
        Me.txtSpecialInstructions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSpecialInstructions.Size = New System.Drawing.Size(392, 66)
        Me.txtSpecialInstructions.TabIndex = 20
        Me.txtSpecialInstructions.Text = ""
        '
        'btnFindSite
        '
        Me.btnFindSite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindSite.BackColor = System.Drawing.Color.White
        Me.btnFindSite.Enabled = False
        Me.btnFindSite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindSite.Location = New System.Drawing.Point(504, 32)
        Me.btnFindSite.Name = "btnFindSite"
        Me.btnFindSite.Size = New System.Drawing.Size(32, 23)
        Me.btnFindSite.TabIndex = 4
        Me.btnFindSite.Text = "..."
        '
        'txtSite
        '
        Me.txtSite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSite.Location = New System.Drawing.Point(144, 32)
        Me.txtSite.Name = "txtSite"
        Me.txtSite.ReadOnly = True
        Me.txtSite.Size = New System.Drawing.Size(352, 21)
        Me.txtSite.TabIndex = 3
        Me.txtSite.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 23)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "Property"
        '
        'btnFindCustomer
        '
        Me.btnFindCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindCustomer.BackColor = System.Drawing.Color.White
        Me.btnFindCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindCustomer.Location = New System.Drawing.Point(504, 8)
        Me.btnFindCustomer.Name = "btnFindCustomer"
        Me.btnFindCustomer.Size = New System.Drawing.Size(32, 23)
        Me.btnFindCustomer.TabIndex = 2
        Me.btnFindCustomer.Text = "..."
        '
        'txtCustomer
        '
        Me.txtCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(144, 8)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(352, 21)
        Me.txtCustomer.TabIndex = 1
        Me.txtCustomer.Text = ""
        '
        'tabRequests
        '
        Me.tabRequests.Controls.Add(Me.GroupBox4)
        Me.tabRequests.Controls.Add(Me.GroupBox1)
        Me.tabRequests.Controls.Add(Me.lblSearch)
        Me.tabRequests.Controls.Add(Me.btnSearch)
        Me.tabRequests.Location = New System.Drawing.Point(4, 22)
        Me.tabRequests.Name = "tabRequests"
        Me.tabRequests.Size = New System.Drawing.Size(544, 470)
        Me.tabRequests.TabIndex = 2
        Me.tabRequests.Text = "Price Requests"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.dgConfirmedPriceRequests)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 264)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(528, 192)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Confirmed Price Requests"
        '
        'dgConfirmedPriceRequests
        '
        Me.dgConfirmedPriceRequests.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgConfirmedPriceRequests.DataMember = ""
        Me.dgConfirmedPriceRequests.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgConfirmedPriceRequests.Location = New System.Drawing.Point(8, 27)
        Me.dgConfirmedPriceRequests.Name = "dgConfirmedPriceRequests"
        Me.dgConfirmedPriceRequests.Size = New System.Drawing.Size(512, 157)
        Me.dgConfirmedPriceRequests.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgPriceRequests)
        Me.GroupBox1.Controls.Add(Me.btnUpdate)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(528, 216)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Unconfirmed Price Requests"
        '
        'dgPriceRequests
        '
        Me.dgPriceRequests.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgPriceRequests.DataMember = ""
        Me.dgPriceRequests.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgPriceRequests.Location = New System.Drawing.Point(8, 31)
        Me.dgPriceRequests.Name = "dgPriceRequests"
        Me.dgPriceRequests.Size = New System.Drawing.Size(512, 145)
        Me.dgPriceRequests.TabIndex = 1
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.Location = New System.Drawing.Point(8, 184)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(152, 24)
        Me.btnUpdate.TabIndex = 7
        Me.btnUpdate.Text = "Confirm Price Request"
        '
        'lblSearch
        '
        Me.lblSearch.Location = New System.Drawing.Point(136, 8)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(336, 23)
        Me.lblSearch.TabIndex = 5
        Me.lblSearch.Text = "Please Save Quote To Allow Search For Price Request"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(8, 8)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(120, 23)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "Search For Items"
        '
        'tabItems
        '
        Me.tabItems.Controls.Add(Me.GroupBox3)
        Me.tabItems.Controls.Add(Me.GroupBox2)
        Me.tabItems.Location = New System.Drawing.Point(4, 22)
        Me.tabItems.Name = "tabItems"
        Me.tabItems.Size = New System.Drawing.Size(544, 470)
        Me.tabItems.TabIndex = 1
        Me.tabItems.Text = "Products / Parts"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.dgParts)
        Me.GroupBox3.Controls.Add(Me.btnRemoveParts)
        Me.GroupBox3.Controls.Add(Me.btnFindPart)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 216)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(528, 248)
        Me.GroupBox3.TabIndex = 57
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Parts - Quantity and Price can be edited by clicking the appropriate cell"
        '
        'dgParts
        '
        Me.dgParts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgParts.DataMember = ""
        Me.dgParts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgParts.Location = New System.Drawing.Point(8, 41)
        Me.dgParts.Name = "dgParts"
        Me.dgParts.Size = New System.Drawing.Size(512, 167)
        Me.dgParts.TabIndex = 4
        '
        'btnRemoveParts
        '
        Me.btnRemoveParts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveParts.Location = New System.Drawing.Point(456, 218)
        Me.btnRemoveParts.Name = "btnRemoveParts"
        Me.btnRemoveParts.Size = New System.Drawing.Size(64, 23)
        Me.btnRemoveParts.TabIndex = 6
        Me.btnRemoveParts.Text = "Remove"
        '
        'btnFindPart
        '
        Me.btnFindPart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFindPart.BackColor = System.Drawing.SystemColors.Control
        Me.btnFindPart.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindPart.Location = New System.Drawing.Point(8, 216)
        Me.btnFindPart.Name = "btnFindPart"
        Me.btnFindPart.Size = New System.Drawing.Size(128, 23)
        Me.btnFindPart.TabIndex = 5
        Me.btnFindPart.Text = "Search For Part"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dgProducts)
        Me.GroupBox2.Controls.Add(Me.btnRemoveProducts)
        Me.GroupBox2.Controls.Add(Me.btnFindProduct)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(528, 200)
        Me.GroupBox2.TabIndex = 52
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Products - Quantity and Price can be edited by clicking the appropriate cell"
        '
        'dgProducts
        '
        Me.dgProducts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgProducts.DataMember = ""
        Me.dgProducts.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgProducts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgProducts.Location = New System.Drawing.Point(8, 35)
        Me.dgProducts.Name = "dgProducts"
        Me.dgProducts.Size = New System.Drawing.Size(512, 126)
        Me.dgProducts.TabIndex = 1
        '
        'btnRemoveProducts
        '
        Me.btnRemoveProducts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveProducts.Location = New System.Drawing.Point(456, 169)
        Me.btnRemoveProducts.Name = "btnRemoveProducts"
        Me.btnRemoveProducts.Size = New System.Drawing.Size(64, 23)
        Me.btnRemoveProducts.TabIndex = 3
        Me.btnRemoveProducts.Text = "Remove"
        '
        'btnFindProduct
        '
        Me.btnFindProduct.BackColor = System.Drawing.SystemColors.Control
        Me.btnFindProduct.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindProduct.Location = New System.Drawing.Point(8, 168)
        Me.btnFindProduct.Name = "btnFindProduct"
        Me.btnFindProduct.Size = New System.Drawing.Size(128, 23)
        Me.btnFindProduct.TabIndex = 2
        Me.btnFindProduct.Text = "Search For Product"
        '
        'UCGenerateQuote
        '
        Me.Controls.Add(Me.tcQuote)
        Me.Name = "UCGenerateQuote"
        Me.Size = New System.Drawing.Size(568, 512)
        Me.tcQuote.ResumeLayout(False)
        Me.tabDetails.ResumeLayout(False)
        Me.tabRequests.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgConfirmedPriceRequests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgPriceRequests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabItems.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgParts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
        SetupPartsDataGrid()
        SetupProductsDataGrid()
        SetupPriceRequestDatagrid()
        SetupConfirmedPriceRequestDatagrid()
        Combo.SetUpCombo(cboStatus, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Quote_Status).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get

        End Get
    End Property

#End Region

#Region "Properties"

#Region "Dataviews"

    Public Property PartsDataView() As DataView
        Get
            Return m_dTable2
        End Get
        Set(ByVal Value As DataView)
            m_dTable2 = Value
            m_dTable2.Table.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
            m_dTable2.AllowNew = False
            m_dTable2.AllowEdit = False
            m_dTable2.AllowDelete = False
            Me.dgParts.DataSource = PartsDataView
        End Set
    End Property

    Private m_dTable2 As DataView = Nothing

    Private ReadOnly Property SelectedPartDataRow() As DataRow
        Get
            If Not Me.dgParts.CurrentRowIndex = -1 Then
                Return PartsDataView(Me.dgParts.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Property ProductsDataView() As DataView
        Get
            Return m_dTable
        End Get
        Set(ByVal Value As DataView)
            m_dTable = Value
            m_dTable.Table.TableName = Entity.Sys.Enums.TableNames.tblProduct.ToString
            m_dTable.AllowNew = False
            m_dTable.AllowEdit = False
            m_dTable.AllowDelete = False
            Me.dgProducts.DataSource = ProductsDataView
        End Set
    End Property

    Private m_dTable As DataView = Nothing

    Private ReadOnly Property SelectedProductDataRow() As DataRow
        Get
            If Not Me.dgProducts.CurrentRowIndex = -1 Then
                Return ProductsDataView(Me.dgProducts.CurrentRowIndex).Row
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
            _PriceRequestDataView.Table.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString
            _PriceRequestDataView.AllowNew = False
            _PriceRequestDataView.AllowEdit = False
            _PriceRequestDataView.AllowDelete = False
            Me.dgPriceRequests.DataSource = PriceRequestDataView
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

    Private _ConfirmedPriceRequestDataView As DataView = Nothing

    Public Property ConfirmedPriceRequestDataView() As DataView
        Get
            Return _ConfirmedPriceRequestDataView
        End Get
        Set(ByVal Value As DataView)
            _ConfirmedPriceRequestDataView = Value
            _ConfirmedPriceRequestDataView.Table.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString
            _ConfirmedPriceRequestDataView.AllowNew = False
            _ConfirmedPriceRequestDataView.AllowEdit = False
            _ConfirmedPriceRequestDataView.AllowDelete = False
            Me.dgConfirmedPriceRequests.DataSource = ConfirmedPriceRequestDataView
        End Set
    End Property

    Private ReadOnly Property SelectedConfirmedPriceRequestDataRow() As DataRow
        Get
            If Not Me.dgConfirmedPriceRequests.CurrentRowIndex = -1 Then
                Return ConfirmedPriceRequestDataView(Me.dgConfirmedPriceRequests.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

    Private Loading As Boolean

    Private oQuoteOrder As Entity.QuoteOrders.QuoteOrder

    Public Property CurrentQuoteOrder() As Entity.QuoteOrders.QuoteOrder
        Get
            Return oQuoteOrder
        End Get
        Set(ByVal Value As Entity.QuoteOrders.QuoteOrder)
            oQuoteOrder = Value

            If CurrentQuoteOrder Is Nothing Then
                CurrentQuoteOrder = New Entity.QuoteOrders.QuoteOrder
                CurrentQuoteOrder.Exists = False
                Me.cboStatus.Enabled = False
                Combo.SetSelectedComboItem_By_Value(cboStatus, 1)
            Else
                Me.cboStatus.Enabled = True
            End If

            If CurrentQuoteOrder.Exists Then
                Me.btnSearch.Enabled = True
                Me.btnUpdate.Enabled = True
                Me.lblSearch.Visible = False
                Populate()
            Else
                Me.btnSearch.Enabled = False
                Me.btnUpdate.Enabled = False
                Me.lblSearch.Visible = True
            End If
            Loading = False
        End Set
    End Property

    Private _oCustomer As Entity.Customers.Customer

    Public Property Customer() As Entity.Customers.Customer
        Get
            Return _oCustomer
        End Get
        Set(ByVal Value As Entity.Customers.Customer)
            _oCustomer = Value
            If Not _oCustomer Is Nothing Then
                Me.txtCustomer.Text = Customer.Name & " ( " & Customer.AccountNumber & ") "
                Me.btnFindSite.Enabled = True
                theSite = Nothing
                InvoiceAddress = Nothing
                Contact = Nothing
            Else
                Me.txtCustomer.Text = ""
                Me.btnFindSite.Enabled = False
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
                Me.btnFindInvoiceAddress.Enabled = True
                Me.btnFindContact.Enabled = True
                InvoiceAddress = Nothing
                Contact = Nothing
                theWarehouse = Nothing
            Else
                Me.txtSite.Text = ""
                Me.btnFindInvoiceAddress.Enabled = False
                Me.btnFindContact.Enabled = False
            End If
        End Set
    End Property

    Private _oWarehouse As Entity.Warehouses.Warehouse

    Public Property theWarehouse() As Entity.Warehouses.Warehouse
        Get
            Return _oWarehouse
        End Get
        Set(ByVal Value As Entity.Warehouses.Warehouse)
            _oWarehouse = Value
            If Not _oWarehouse Is Nothing Then
                Me.txtWarehouse.Text = theWarehouse.Address1 & ", " & theWarehouse.Address2 & ", " & theWarehouse.Postcode
                theSite = Nothing
                'btnFindContact.Enabled = False
                'btnFindInvoiceAddress.Enabled = False
            Else
                Me.txtWarehouse.Text = ""
            End If
        End Set
    End Property

    Private _invoiceAddress As Entity.InvoiceAddresss.InvoiceAddress

    Public Property InvoiceAddress() As Entity.InvoiceAddresss.InvoiceAddress
        Get
            Return _invoiceAddress
        End Get
        Set(ByVal Value As Entity.InvoiceAddresss.InvoiceAddress)
            _invoiceAddress = Value
            If Not InvoiceAddress Is Nothing Then
                Me.txtInvoiceAddress.Text = InvoiceAddress.Address1 & ", " & InvoiceAddress.Address2 & ", " & InvoiceAddress.Postcode
            Else
                Me.txtInvoiceAddress.Text = ""
            End If
        End Set
    End Property

    Private _contact As Entity.Contacts.Contact

    Public Property Contact() As Entity.Contacts.Contact
        Get
            Return _contact
        End Get
        Set(ByVal Value As Entity.Contacts.Contact)
            _contact = Value
            If Not Contact Is Nothing Then
                Me.txtContact.Text = Contact.FirstName & " " & Contact.Surname
            Else
                Me.txtContact.Text = ""
            End If
        End Set
    End Property

    Public Event FormClose()

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

#End Region

#Region "Setup"

    Public Sub SetupPriceRequestDatagrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgPriceRequests)
        Dim tStyle As DataGridTableStyle = Me.dgPriceRequests.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 70
        Type.NullText = ""
        tStyle.GridColumnStyles.Add(Type)

        Dim SupplierName As New DataGridLabelColumn
        SupplierName.Format = ""
        SupplierName.FormatInfo = Nothing
        SupplierName.HeaderText = "Supplier"
        SupplierName.MappingName = "SupplierName"
        SupplierName.ReadOnly = True
        SupplierName.Width = 140
        SupplierName.NullText = ""
        tStyle.GridColumnStyles.Add(SupplierName)

        'Dim Postcode As New DataGridLabelColumn
        'Postcode.Format = ""
        'Postcode.FormatInfo = Nothing
        'Postcode.HeaderText = "Postcode"
        'Postcode.MappingName = "Postcode"
        'Postcode.ReadOnly = True
        'Postcode.Width = 120
        'Postcode.NullText = ""
        'tStyle.GridColumnStyles.Add(Postcode)

        'Dim TelephoneNum As New DataGridLabelColumn
        'TelephoneNum.Format = ""
        'TelephoneNum.FormatInfo = Nothing
        'TelephoneNum.HeaderText = "Telephone"
        'TelephoneNum.MappingName = "TelephoneNum"
        'TelephoneNum.ReadOnly = True
        'TelephoneNum.Width = 120
        'TelephoneNum.NullText = ""
        'tStyle.GridColumnStyles.Add(TelephoneNum)

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
        tStyle.MappingName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString
        Me.dgPriceRequests.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupConfirmedPriceRequestDatagrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgConfirmedPriceRequests)

        dgConfirmedPriceRequests.ReadOnly = False

        Dim tStyle As DataGridTableStyle = Me.dgConfirmedPriceRequests.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim chk As New DataGridCheckBox
        chk.HeaderText = "Selected"
        chk.MappingName = "Included"
        chk.ReadOnly = True
        chk.Width = 50
        chk.NullText = "0"
        tStyle.GridColumnStyles.Add(chk)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 70
        Type.NullText = ""
        tStyle.GridColumnStyles.Add(Type)

        Dim SupplierName As New DataGridLabelColumn
        SupplierName.Format = ""
        SupplierName.FormatInfo = Nothing
        SupplierName.HeaderText = "Supplier"
        SupplierName.MappingName = "SupplierName"
        SupplierName.ReadOnly = True
        SupplierName.Width = 120
        SupplierName.NullText = ""
        tStyle.GridColumnStyles.Add(SupplierName)

        Dim partName As New DataGridLabelColumn
        partName.Format = ""
        partName.FormatInfo = Nothing
        partName.HeaderText = "Part"
        partName.MappingName = "Part"
        partName.ReadOnly = True
        partName.Width = 120
        partName.NullText = ""
        tStyle.GridColumnStyles.Add(partName)

        Dim ProductName As New DataGridLabelColumn
        ProductName.Format = ""
        ProductName.FormatInfo = Nothing
        ProductName.HeaderText = "Product"
        ProductName.MappingName = "Product"
        ProductName.ReadOnly = True
        ProductName.Width = 120
        ProductName.NullText = ""
        tStyle.GridColumnStyles.Add(ProductName)

        Dim PartCode As New DataGridLabelColumn
        PartCode.Format = ""
        PartCode.FormatInfo = Nothing
        PartCode.HeaderText = "Supplier Code"
        PartCode.MappingName = "Code"
        PartCode.ReadOnly = True
        PartCode.Width = 120
        PartCode.NullText = ""
        tStyle.GridColumnStyles.Add(PartCode)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Buy Price"
        Price.MappingName = "BuyPrice"
        Price.ReadOnly = True
        Price.Width = 90
        Price.NullText = ""
        tStyle.GridColumnStyles.Add(Price)

        Dim Amount As New DataGridLabelColumn
        Amount.Format = ""
        Amount.FormatInfo = Nothing
        Amount.HeaderText = "Quantity"
        Amount.MappingName = "QuantityInPack"
        Amount.ReadOnly = True
        Amount.Width = 90
        Amount.NullText = ""
        tStyle.GridColumnStyles.Add(Amount)

        Dim SellPrice As New DataGridOrderTextBoxColumn
        SellPrice.Format = "C"
        SellPrice.FormatInfo = Nothing
        SellPrice.HeaderText = "Sell Price"
        SellPrice.MappingName = "SellPrice"
        SellPrice.ReadOnly = False
        SellPrice.Width = 90
        SellPrice.NullText = ""
        tStyle.GridColumnStyles.Add(SellPrice)

        tStyle.ReadOnly = False
        tStyle.MappingName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString
        Me.dgConfirmedPriceRequests.TableStyles.Add(tStyle)
    End Sub

    Public Function SetupPartsDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgParts)
        dgParts.ReadOnly = False

        Dim tStyle As DataGridTableStyle = Me.dgParts.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim PartName As New DataGridLabelColumn
        PartName.Format = ""
        PartName.FormatInfo = Nothing
        PartName.HeaderText = "Name"
        PartName.MappingName = "Name"
        PartName.ReadOnly = True
        PartName.Width = 130
        PartName.NullText = ""
        tStyle.GridColumnStyles.Add(PartName)

        Dim PartNumber As New DataGridLabelColumn
        PartNumber.Format = ""
        PartNumber.FormatInfo = Nothing
        PartNumber.HeaderText = "Number"
        PartNumber.MappingName = "Number"
        PartNumber.ReadOnly = True
        PartNumber.Width = 130
        PartNumber.NullText = ""
        tStyle.GridColumnStyles.Add(PartNumber)

        Dim PartReference As New DataGridLabelColumn
        PartReference.Format = ""
        PartReference.FormatInfo = Nothing
        PartReference.HeaderText = "Part Reference"
        PartReference.MappingName = "Reference"
        PartReference.ReadOnly = True
        PartReference.Width = 200
        PartReference.NullText = ""
        tStyle.GridColumnStyles.Add(PartReference)

        Dim ListPrice As New DataGridOrderTextBoxColumn
        ListPrice.Format = "C"
        ListPrice.FormatInfo = Nothing
        ListPrice.HeaderText = "List Price"
        ListPrice.MappingName = "SellPrice"
        ListPrice.ReadOnly = False
        ListPrice.Width = 100
        ListPrice.NullText = ""
        tStyle.GridColumnStyles.Add(ListPrice)

        Dim PartQuantity As New DataGridOrderTextBoxColumn
        PartQuantity.Format = "F"
        PartQuantity.FormatInfo = Nothing
        PartQuantity.HeaderText = "Quantity"
        PartQuantity.MappingName = "Quantity"
        PartQuantity.ReadOnly = False
        PartQuantity.Width = 150
        PartQuantity.NullText = ""
        tStyle.GridColumnStyles.Add(PartQuantity)

        Dim Price As New DataGridOrderTextBoxColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Quote Price"
        Price.MappingName = "Price"
        Price.ReadOnly = False
        Price.Width = 150
        Price.NullText = ""
        tStyle.GridColumnStyles.Add(Price)

        tStyle.ReadOnly = False
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblPart.ToString
        Me.dgParts.TableStyles.Add(tStyle)
    End Function

    Public Function SetupProductsDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgProducts)
        dgProducts.ReadOnly = False

        Dim tStyle As DataGridTableStyle = Me.dgProducts.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim ProductName As New DataGridLabelColumn
        ProductName.Format = ""
        ProductName.FormatInfo = Nothing
        ProductName.HeaderText = "Name"
        ProductName.MappingName = "typemakemodel"
        ProductName.ReadOnly = True
        ProductName.Width = 130
        ProductName.NullText = ""
        tStyle.GridColumnStyles.Add(ProductName)

        Dim ProductNumber As New DataGridLabelColumn
        ProductNumber.Format = ""
        ProductNumber.FormatInfo = Nothing
        ProductNumber.HeaderText = "Number"
        ProductNumber.MappingName = "Number"
        ProductNumber.ReadOnly = True
        ProductNumber.Width = 130
        ProductNumber.NullText = ""
        tStyle.GridColumnStyles.Add(ProductNumber)

        Dim ProductReference As New DataGridLabelColumn
        ProductReference.Format = ""
        ProductReference.FormatInfo = Nothing
        ProductReference.HeaderText = "Product Reference"
        ProductReference.MappingName = "Reference"
        ProductReference.ReadOnly = True
        ProductReference.Width = 200
        ProductReference.NullText = ""
        tStyle.GridColumnStyles.Add(ProductReference)

        Dim ListPrice As New DataGridOrderTextBoxColumn
        ListPrice.Format = "C"
        ListPrice.FormatInfo = Nothing
        ListPrice.HeaderText = "List Price"
        ListPrice.MappingName = "SellPrice"
        ListPrice.ReadOnly = False
        ListPrice.Width = 100
        ListPrice.NullText = ""
        tStyle.GridColumnStyles.Add(ListPrice)

        Dim ProductQuantity As New DataGridOrderTextBoxColumn
        ProductQuantity.Format = "F"
        ProductQuantity.FormatInfo = Nothing
        ProductQuantity.HeaderText = "Quantity"
        ProductQuantity.MappingName = "Quantity"
        ProductQuantity.ReadOnly = False
        ProductQuantity.Width = 150
        ProductQuantity.NullText = ""
        tStyle.GridColumnStyles.Add(ProductQuantity)

        Dim Price As New DataGridOrderTextBoxColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Price"
        Price.MappingName = "Price"
        Price.ReadOnly = False
        Price.Width = 150
        Price.NullText = ""
        tStyle.GridColumnStyles.Add(Price)

        tStyle.ReadOnly = False
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblProduct.ToString
        Me.dgProducts.TableStyles.Add(tStyle)
    End Function

#End Region

#Region "Events"

    Private Sub cboStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboStatus.SelectedIndexChanged
        If Loading = False And Not CurrentQuoteOrder Is Nothing Then
            If CurrentQuoteOrder.Exists = True Then
                If CType(Combo.GetSelectedItemValue(Me.cboStatus), Entity.Sys.Enums.QuoteContractStatus) = Entity.Sys.Enums.QuoteContractStatus.Accepted Then

                    Dim msgRes As MsgBoxResult
                    msgRes = ShowMessage("You are converting this quote to an order" & vbCrLf & "Do you wish to save any changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                    If msgRes = DialogResult.Yes Then
                        If Save() = False Then
                            Exit Sub
                        End If
                    ElseIf msgRes = MsgBoxResult.No Then
                        DB.QuoteOrder.Update(oQuoteOrder)
                    ElseIf msgRes = MsgBoxResult.Cancel Then
                        Combo.SetSelectedComboItem_By_Value(Me.cboStatus, CurrentQuoteOrder.QuoteStatusID)
                        Exit Sub
                    End If

                    Dim convertForm As FRMConvertToAnOrder = Activator.CreateInstance(GetType(FRMConvertToAnOrder))
                    '    convertForm.Icon = New Icon(convertForm.GetType(), "Logo.ico")
                    convertForm.ShowInTaskbar = False
                    convertForm.StartPosition = FormStartPosition.CenterScreen
                    convertForm.SizeGripStyle = SizeGripStyle.Hide

                    Dim PartsAndProducts As New DataView(New DataTable)
                    PartsAndProducts.Table.Columns.Add("PartProductID")
                    PartsAndProducts.Table.Columns.Add("Type")
                    PartsAndProducts.Table.Columns.Add("Number")
                    PartsAndProducts.Table.Columns.Add("Name")
                    PartsAndProducts.Table.Columns.Add("Quantity")
                    PartsAndProducts.Table.Columns.Add("SellPrice")

                    For Each row As DataRow In PartsDataView.Table.Rows

                        Dim newRow As DataRow = PartsAndProducts.Table.NewRow

                        newRow.Item("PartProductID") = row.Item("PartID")
                        newRow.Item("Type") = "Part"
                        newRow.Item("Number") = row.Item("Number")
                        newRow.Item("Name") = row.Item("Name")
                        newRow.Item("Quantity") = row.Item("Quantity")
                        newRow.Item("SellPrice") = row.Item("Price")

                        PartsAndProducts.Table.Rows.Add(newRow)
                        PartsAndProducts.Table.AcceptChanges()
                    Next

                    For Each row2 As DataRow In ProductsDataView.Table.Rows

                        Dim newRow As DataRow = PartsAndProducts.Table.NewRow

                        newRow.Item("PartProductID") = row2.Item("ProductID")
                        newRow.Item("Type") = "Product"
                        newRow.Item("Number") = row2.Item("Number")
                        newRow.Item("Name") = row2.Item("typemakemodel")
                        newRow.Item("Quantity") = row2.Item("Quantity")
                        newRow.Item("SellPrice") = row2.Item("Price")

                        PartsAndProducts.Table.Rows.Add(newRow)
                        PartsAndProducts.Table.AcceptChanges()
                    Next

                    convertForm.PriceRequestItemsDataView = Me.ConfirmedPriceRequestDataView

                    CType(convertForm, IBaseForm).SetFormParameters = New Object() {CInt(Entity.Sys.Enums.OrderType.Customer), 0, PartsAndProducts, CurrentQuoteOrder, 0, ConfirmedPriceRequestDataView}
                    If convertForm.ShowDialog() = DialogResult.OK Then
                    Else
                        Combo.SetSelectedComboItem_By_Value(Me.cboStatus, Entity.Sys.Enums.QuoteContractStatus.Generated)
                        Me.Save()
                    End If
                    Me.Populate(CurrentQuoteOrder.QuoteOrderID)
                ElseIf CType(Combo.GetSelectedItemValue(Me.cboStatus), Entity.Sys.Enums.QuoteContractStatus) = Entity.Sys.Enums.QuoteContractStatus.Rejected Then
                    ShowForm(GetType(FRMQuoteRejection), True, New Object() {Me, ""})
                    Me.Populate(CurrentQuoteOrder.QuoteOrderID)
                End If
            End If
        End If
    End Sub

    Private Sub btnFindCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCustomer.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblCustomer)
        If Not ID = 0 Then
            Customer = DB.Customer.Customer_Get(ID)
        End If
    End Sub

    Private Sub btnFindProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindProduct.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblProduct)
        If ID > 0 Then
            addProduct(ID)
        End If
    End Sub

    Private Sub btnFindPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindPart.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblPart)
        If ID > 0 Then
            addPart(ID)
        End If
    End Sub

    Private Sub btnFindSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindSite.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblSite, Customer.CustomerID)
        If Not ID = 0 Then
            theSite = DB.Sites.Get(ID)
        End If
    End Sub

    Private Sub UCGenerateQuote_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Loading = True
        LoadForm(sender, e)
    End Sub

    Private Sub btnRemoveProducts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveProducts.Click
        If SelectedProductDataRow Is Nothing Then
            ShowMessage("Please select product to remove", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ProductsDataView.Table.Rows.Remove(SelectedProductDataRow)
        ProductsDataView.Table.AcceptChanges()
    End Sub

    Private Sub btnRemoveParts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveParts.Click
        If SelectedPartDataRow Is Nothing Then
            ShowMessage("Please select part to remove", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        PartsDataView.Table.Rows.Remove(SelectedPartDataRow)
        PartsDataView.Table.AcceptChanges()
    End Sub

    Private Sub btnFindInvoiceAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindInvoiceAddress.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblInvoiceAddress, theSite.SiteID)
        If Not ID = 0 Then
            InvoiceAddress = DB.InvoiceAddress.InvoiceAddress_Get(ID)
        End If
    End Sub

    Private Sub btnFindContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindContact.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblContact, theSite.SiteID)
        If Not ID = 0 Then
            Contact = DB.Contact.Contact_Get(ID)
        End If
    End Sub

    Private Sub chkDeadlineNA_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDeadlineNA.CheckedChanged
        If Me.chkDeadlineNA.Checked = True Then
            Me.dtpDeliveryDeadline.Enabled = False
        Else
            Me.dtpDeliveryDeadline.Enabled = True
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim dialogue As DLGAdvancedItemSearch
        dialogue = checkIfExists(GetType(DLGAdvancedItemSearch).Name, True)
        If dialogue Is Nothing Then
            dialogue = Activator.CreateInstance(GetType(DLGAdvancedItemSearch))
        End If

        '  dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
        dialogue.ShowInTaskbar = False
        dialogue.QuoteID = oQuoteOrder.QuoteOrderID
        dialogue.ShowDialog()

        If dialogue.DialogResult = DialogResult.OK Then
            'Return dialogue.ID
        End If
        dialogue.Dispose()
        RefreshDatagrids()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        UpdatePriceRequest()
    End Sub

    Private Sub dgPriceRequests_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPriceRequests.DoubleClick
        UpdatePriceRequest()
    End Sub

    Private Sub btnFindWarehouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindWarehouse.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse)
        If Not ID = 0 Then
            theWarehouse = DB.Warehouse.Warehouse_Get(ID)
        End If
    End Sub

#End Region

#Region "Functions"

    Private Sub UpdatePriceRequest()
        If SelectedPriceRequestDataRow Is Nothing Then
            ShowMessage("Please select an item to update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If SelectedPriceRequestDataRow.Item("Type") = "Part" Then
            Dim oPartSupplier As New Entity.PartSuppliers.PartSupplier
            oPartSupplier.SetPartID = SelectedPriceRequestDataRow("PartProductID")
            oPartSupplier.SetSupplierID = SelectedPriceRequestDataRow("SupplierID")
            oPartSupplier.SetQuantityInPack = SelectedPriceRequestDataRow("QuantityInPack")

            ShowForm(GetType(FRMAddToQuote), True, New Object() {CurrentQuoteOrder.QuoteOrderID, oPartSupplier, Nothing, SelectedPriceRequestDataRow.Item("ID")})
        ElseIf SelectedPriceRequestDataRow.Item("Type") = "Product" Then
            Dim oProductSupplier As New Entity.ProductSuppliers.ProductSupplier
            oProductSupplier.SetProductID = SelectedPriceRequestDataRow("PartProductID")
            oProductSupplier.SetSupplierID = SelectedPriceRequestDataRow("SupplierID")
            oProductSupplier.SetQuantityInPack = SelectedPriceRequestDataRow("QuantityInPack")

            ShowForm(GetType(FRMAddToQuote), True, New Object() {CurrentQuoteOrder.QuoteOrderID, Nothing, oProductSupplier, SelectedPriceRequestDataRow.Item("ID")})
        End If
        RefreshDatagrids()
    End Sub

    Private Sub RefreshDatagrids()
        Me.PriceRequestDataView = DB.QuoteOrder.Quote_PriceRequests_GetAll(CurrentQuoteOrder.QuoteOrderID)
        Me.ConfirmedPriceRequestDataView = DB.QuoteOrder.Quote_PriceRequests_GetConfirmed(CurrentQuoteOrder.QuoteOrderID)
    End Sub

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate

        If Not ID = 0 Then
            CurrentQuoteOrder = DB.QuoteOrder.QuoteOrder_Get(ID)
        End If

        Customer = DB.Customer.Customer_Get(CurrentQuoteOrder.CustomerID)
        theSite = DB.Sites.Get(CurrentQuoteOrder.PropertyID)
        Contact = DB.Contact.Contact_Get(CurrentQuoteOrder.ContactID)
        InvoiceAddress = DB.InvoiceAddress.InvoiceAddress_Get(CurrentQuoteOrder.InvoiceAddressID)
        theWarehouse = DB.Warehouse.Warehouse_Get(CurrentQuoteOrder.WarehouseID)
        Me.txtSpecialInstructions.Text = CurrentQuoteOrder.SpecialInstructions
        If CurrentQuoteOrder.DeliveryDeadline = Nothing Then
            Me.chkDeadlineNA.Checked = True
        Else
            Me.dtpDeliveryDeadline.Value = CurrentQuoteOrder.DeliveryDeadline
            Me.chkDeadlineNA.Checked = False
        End If
        Combo.SetSelectedComboItem_By_Value(cboUsers, CurrentQuoteOrder.AllocatedToUser)
        Combo.SetSelectedComboItem_By_Value(cboStatus, CurrentQuoteOrder.QuoteStatusID)

        If CurrentQuoteOrder.QuoteStatusID = CInt(Entity.Sys.Enums.QuoteContractStatus.Generated) Then
            SetFormState(True)
        Else
            SetFormState(False)
        End If
        Me.txtCustRef.Text = CurrentQuoteOrder.CustomerRef
        Me.txtPriceDetails.Text = CurrentQuoteOrder.PriceDetails
        Me.txtPriceExcludeDetails.Text = CurrentQuoteOrder.PriceExcludeDetails
        Me.txtAvailability.Text = CurrentQuoteOrder.Availability
        Me.dtpEnquiryDate.Value = CurrentQuoteOrder.EnquiryDate
        Me.dtpValidUntil.Value = CurrentQuoteOrder.ValidUntilDate
        PartsDataView = DB.QuoteOrderPart.QuoteOrderPart_GetForQuoteOrder(CurrentQuoteOrder.QuoteOrderID)
        ProductsDataView = DB.QuoteOrderProduct.QuoteOrderProduct_GetForQuoteOrder(CurrentQuoteOrder.QuoteOrderID)
        RefreshDatagrids()
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save

        Try

            Dim oQuoteOrder As New Entity.QuoteOrders.QuoteOrder

            If CurrentQuoteOrder.Exists = True Then
                oQuoteOrder.SetReasonForReject = CurrentQuoteOrder.ReasonForReject
            End If

            If Not Customer Is Nothing Then
                oQuoteOrder.SetCustomerID = Customer.CustomerID
            Else
                oQuoteOrder.SetCustomerID = 0
            End If
            If Not theSite Is Nothing Then
                oQuoteOrder.SetPropertyID = theSite.SiteID
            Else
                oQuoteOrder.SetPropertyID = 0
            End If
            If Not theWarehouse Is Nothing Then
                oQuoteOrder.SetWarehouseID = theWarehouse.WarehouseID
            Else
                oQuoteOrder.SetWarehouseID = 0
            End If

            oQuoteOrder.SetAllocatedToUser = Combo.GetSelectedItemValue(Me.cboUsers)
            oQuoteOrder.SetCreatedByUser = loggedInUser.UserID
            If Not Contact Is Nothing Then
                oQuoteOrder.SetContactID = Contact.ContactID
            Else
                oQuoteOrder.SetContactID = 0
            End If

            oQuoteOrder.SetCustomerRef = Me.txtCustRef.Text
            oQuoteOrder.SetAvailability = Me.txtAvailability.Text
            oQuoteOrder.SetPriceDetails = Me.txtPriceDetails.Text
            oQuoteOrder.SetPriceExcludeDetails = Me.txtPriceExcludeDetails.Text
            oQuoteOrder.EnquiryDate = Me.dtpEnquiryDate.Value
            oQuoteOrder.ValidUntilDate = Me.dtpValidUntil.Value
            If Not InvoiceAddress Is Nothing Then
                oQuoteOrder.SetInvoiceAddressID = InvoiceAddress.InvoiceAddressID
            Else
                oQuoteOrder.SetInvoiceAddressID = 0
            End If
            oQuoteOrder.SetSpecialInstructions = Me.txtSpecialInstructions.Text
            oQuoteOrder.SetQuoteStatusID = Combo.GetSelectedItemValue(Me.cboStatus)
            If Me.chkDeadlineNA.Checked = True Then
                oQuoteOrder.DeliveryDeadline = Nothing
            Else
                oQuoteOrder.DeliveryDeadline = Me.dtpDeliveryDeadline.Value
            End If

            If CurrentQuoteOrder.Exists Then
                oQuoteOrder.SetQuoteOrderID = CurrentQuoteOrder.QuoteOrderID
                Dim qOValidator As New Entity.QuoteOrders.QuoteOrderValidator
                qOValidator.Validate(oQuoteOrder)
                DB.QuoteOrder.Update(oQuoteOrder)
            Else
                Dim qOValidator As New Entity.QuoteOrders.QuoteOrderValidator
                qOValidator.Validate(oQuoteOrder)
                oQuoteOrder = DB.QuoteOrder.Insert(oQuoteOrder)
            End If

            DB.QuoteOrderPart.QuoteOrderPart_DeleteForQuoteOrder(oQuoteOrder.QuoteOrderID)

            If Not PartsDataView Is Nothing Then
                For Each row As DataRow In Me.PartsDataView.Table.Rows
                    Dim oQuoteOrderPart As New Entity.QuoteOrderParts.QuoteOrderPart
                    oQuoteOrderPart.SetQuoteOrderID = oQuoteOrder.QuoteOrderID
                    oQuoteOrderPart.SetPartID = row.Item("PartID")
                    oQuoteOrderPart.SetQuantity = Entity.Sys.Helper.MakeIntegerValid(row.Item("Quantity"))
                    oQuoteOrderPart.SetPrice = Entity.Sys.Helper.MakeDoubleValid(row.Item("Price"))
                    DB.QuoteOrderPart.Insert(oQuoteOrderPart)
                Next
            End If

            DB.QuoteOrderProduct.QuoteOrderProduct_DeleteForQuoteOrder(oQuoteOrder.QuoteOrderID)

            If Not ProductsDataView Is Nothing Then
                For Each row As DataRow In Me.ProductsDataView.Table.Rows
                    Dim oQuoteOrderProduct As New Entity.QuoteOrderProducts.QuoteOrderProduct
                    oQuoteOrderProduct.SetQuoteOrderID = oQuoteOrder.QuoteOrderID
                    oQuoteOrderProduct.SetProductID = row.Item("ProductID")
                    oQuoteOrderProduct.SetQuantity = Entity.Sys.Helper.MakeIntegerValid(row.Item("Quantity"))
                    oQuoteOrderProduct.SetPrice = Entity.Sys.Helper.MakeDoubleValid(row.Item("Price"))
                    DB.QuoteOrderProduct.Insert(oQuoteOrderProduct)
                Next
            End If

            DB.QuoteOrder.QuoteOrder_DeleteItemsIncluded(oQuoteOrder.QuoteOrderID)

            If Not ConfirmedPriceRequestDataView Is Nothing Then
                For Each row As DataRow In Me.ConfirmedPriceRequestDataView.Table.Rows
                    If row.Item("Included") = "1" Then
                        If IsDBNull(row.Item("SellPrice")) Or Not IsNumeric(row.Item("SellPrice")) Then
                            ShowMessage("Please enter a Sell Price for all Items checked", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Function
                        End If
                    End If
                Next

                For Each row As DataRow In Me.ConfirmedPriceRequestDataView.Table.Rows
                    If row.Item("Included") = "1" Then
                        If row.Item("Type") = "Part" Then
                            DB.QuoteOrder.QuoteOrderPartsToInclude_Insert(oQuoteOrder.QuoteOrderID, row.Item("PartSupplierID"), row.Item("SellPrice"))
                        ElseIf row.Item("Type") = "Product" Then
                            DB.QuoteOrder.QuoteOrderProductsToInclude_Insert(oQuoteOrder.QuoteOrderID, row.Item("ProductSupplierID"), row.Item("SellPrice"))
                        End If
                    End If
                Next
            End If

            oQuoteOrder.Exists = True
            CurrentQuoteOrder = oQuoteOrder

            RaiseEvent StateChanged(CurrentQuoteOrder.QuoteOrderID)

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

    Private Sub SetFormState(ByVal Enabled As Boolean)

        Me.btnFindCustomer.Enabled = Enabled
        If Enabled = False Then
            Me.btnFindInvoiceAddress.Enabled = Enabled
            Me.btnFindContact.Enabled = Enabled
        End If

        Me.btnFindPart.Enabled = Enabled
        Me.btnFindProduct.Enabled = Enabled
        Me.btnFindSite.Enabled = Enabled
        Me.btnRemoveParts.Enabled = Enabled
        Me.btnRemoveProducts.Enabled = Enabled
        Me.cboStatus.Enabled = Enabled
        Me.cboUsers.Enabled = Enabled
        Me.chkDeadlineNA.Enabled = Enabled
        Me.dgParts.Enabled = Enabled
        Me.dgProducts.Enabled = Enabled
        Me.dtpDeliveryDeadline.Enabled = Enabled
        Me.dtpEnquiryDate.Enabled = Enabled
        Me.dtpValidUntil.Enabled = Enabled
        Me.txtAvailability.Enabled = Enabled
        Me.txtCustRef.Enabled = Enabled
        Me.txtPriceDetails.Enabled = Enabled
        Me.txtPriceExcludeDetails.Enabled = Enabled
        Me.txtSpecialInstructions.Enabled = Enabled

    End Sub

    Private Sub addProduct(ByVal ProductID As Integer)

        Dim oProduct As Entity.Products.Product = DB.Product.Product_Get(ProductID)

        If ProductsDataView Is Nothing Then
            ProductsDataView = New DataView(New DataTable)
            ProductsDataView.Table.Columns.Add("ProductID")
            ProductsDataView.Table.Columns.Add("typemakemodel")
            ProductsDataView.Table.Columns.Add("Number")
            ProductsDataView.Table.Columns.Add("SellPrice")
            ProductsDataView.Table.Columns.Add("Quantity")
            ProductsDataView.Table.Columns.Add("Price")
        End If

        Dim dr As DataRow = ProductsDataView.Table.NewRow

        dr.Item("ProductID") = ProductID
        dr.Item("typemakemodel") = oProduct.Name
        dr.Item("Number") = oProduct.Number
        dr.Item("SellPrice") = oProduct.SellPrice

        ProductsDataView.Table.Rows.Add(dr)

    End Sub

    Private Sub addPart(ByVal PartID As Integer)

        Dim oPart As Entity.Parts.Part = DB.Part.Part_Get(PartID)

        If PartsDataView Is Nothing Then
            PartsDataView = New DataView(New DataTable)
            PartsDataView.Table.Columns.Add("PartID")
            PartsDataView.Table.Columns.Add("Name")
            PartsDataView.Table.Columns.Add("Number")
            PartsDataView.Table.Columns.Add("SellPrice")
            PartsDataView.Table.Columns.Add("Quantity")
            PartsDataView.Table.Columns.Add("Price")
        End If

        Dim dr As DataRow = PartsDataView.Table.NewRow

        dr.Item("PartID") = PartID
        dr.Item("Name") = oPart.Name
        dr.Item("Number") = oPart.Number
        dr.Item("SellPrice") = oPart.SellPrice

        PartsDataView.Table.Rows.Add(dr)
    End Sub

    Public Sub RejectReasonChanged(ByVal Reason As String, ByVal ReasonID As Integer)
        CurrentQuoteOrder.SetReasonForReject = Reason
        CurrentQuoteOrder.SetReasonForRejectID = ReasonID
        Save()
    End Sub

#End Region

End Class