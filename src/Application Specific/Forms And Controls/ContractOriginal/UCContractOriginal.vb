Public Class UCContractOriginal : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        SetupSitesDataGrid()
        Combo.SetUpCombo(Me.cboInvoiceFrequencyID, DynamicDataTables.InvoiceFrequency_NoWeekly, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboContractStatusID, DynamicDataTables.ContractStatus, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboContractType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.ContractTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboReasonID, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.CancellationReasons).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboDiscount, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.CoverPlanDiscounts).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboInvType, DB.Picklists.GetAll(65).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboPaidBy, DB.Picklists.GetAll(66).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
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

    Friend WithEvents grpContract As System.Windows.Forms.GroupBox
    Friend WithEvents dtpContractStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblContractStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpContractEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblContractEndDate As System.Windows.Forms.Label
    Friend WithEvents cboContractStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents lblContractStatusID As System.Windows.Forms.Label
    Friend WithEvents txtContractPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblContractPrice As System.Windows.Forms.Label
    Friend WithEvents cboInvoiceFrequencyID As System.Windows.Forms.ComboBox
    Friend WithEvents lblInvoiceFrequencyID As System.Windows.Forms.Label
    Friend WithEvents grpSites As System.Windows.Forms.GroupBox
    Friend WithEvents dgSites As System.Windows.Forms.DataGrid
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents lblFirstInvoiceDate As System.Windows.Forms.Label
    Friend WithEvents dtpFirstInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents gpbInvoiceAddress As System.Windows.Forms.GroupBox
    Friend WithEvents dgInvoiceAddress As System.Windows.Forms.DataGrid
    Friend WithEvents lblContractType As System.Windows.Forms.Label
    Friend WithEvents cboContractType As System.Windows.Forms.ComboBox
    Friend WithEvents tcBottomSection As System.Windows.Forms.TabControl
    Friend WithEvents tabProperties As System.Windows.Forms.TabPage
    Friend WithEvents tabChargeDetails As System.Windows.Forms.TabPage
    Friend WithEvents gpbChargeDetails As System.Windows.Forms.GroupBox
    Friend WithEvents rdoCheque As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCreditCard As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDirectDebit As System.Windows.Forms.RadioButton
    Friend WithEvents txtBankName As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtSortCode As System.Windows.Forms.TextBox
    Friend WithEvents lblBankName As System.Windows.Forms.Label
    Friend WithEvents lblAccount As System.Windows.Forms.Label
    Friend WithEvents chkGasSupplyPipework As System.Windows.Forms.CheckBox
    Friend WithEvents lblCancelledDate As System.Windows.Forms.Label
    Friend WithEvents dtpCancelledDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkPlumbingDrainage As System.Windows.Forms.CheckBox
    Friend WithEvents chkWindowLockPest As System.Windows.Forms.CheckBox
    Friend WithEvents txtPONumber As System.Windows.Forms.TextBox
    Friend WithEvents lblPONumber As System.Windows.Forms.Label
    Friend WithEvents txtContractReference As System.Windows.Forms.TextBox
    Friend WithEvents lblContractReference As System.Windows.Forms.Label
    Friend WithEvents cboDoNotRenew As System.Windows.Forms.CheckBox
    Friend WithEvents txtDDMSRef As System.Windows.Forms.TextBox
    Friend WithEvents lblDDMSRef As System.Windows.Forms.Label
    Friend WithEvents lblDiscount As System.Windows.Forms.Label
    Friend WithEvents cboDiscount As System.Windows.Forms.ComboBox
    Friend WithEvents cboReasonID As System.Windows.Forms.ComboBox
    Friend WithEvents lblReason As System.Windows.Forms.Label
    Friend WithEvents tabAdditionalNotes As TabPage
    Friend WithEvents gpbInvoiceInformation As GroupBox
    Friend WithEvents txtAdditionalInvoiceNotes As RichTextBox
    Friend WithEvents cboInvType As ComboBox
    Friend WithEvents lblInvType As Label
    Friend WithEvents cboPaidBy As ComboBox
    Friend WithEvents lblPaidBy As Label
    Friend WithEvents txtSearchFilter As TextBox
    Friend WithEvents lblSearchFilter As Label
    Friend WithEvents lblSortCode As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpContract = New System.Windows.Forms.GroupBox()
        Me.txtSearchFilter = New System.Windows.Forms.TextBox()
        Me.lblSearchFilter = New System.Windows.Forms.Label()
        Me.cboPaidBy = New System.Windows.Forms.ComboBox()
        Me.lblPaidBy = New System.Windows.Forms.Label()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.lblInvType = New System.Windows.Forms.Label()
        Me.cboInvType = New System.Windows.Forms.ComboBox()
        Me.cboReasonID = New System.Windows.Forms.ComboBox()
        Me.lblReason = New System.Windows.Forms.Label()
        Me.lblDiscount = New System.Windows.Forms.Label()
        Me.cboDiscount = New System.Windows.Forms.ComboBox()
        Me.txtDDMSRef = New System.Windows.Forms.TextBox()
        Me.lblDDMSRef = New System.Windows.Forms.Label()
        Me.cboDoNotRenew = New System.Windows.Forms.CheckBox()
        Me.txtContractReference = New System.Windows.Forms.TextBox()
        Me.lblContractReference = New System.Windows.Forms.Label()
        Me.txtPONumber = New System.Windows.Forms.TextBox()
        Me.lblPONumber = New System.Windows.Forms.Label()
        Me.chkPlumbingDrainage = New System.Windows.Forms.CheckBox()
        Me.chkWindowLockPest = New System.Windows.Forms.CheckBox()
        Me.lblCancelledDate = New System.Windows.Forms.Label()
        Me.dtpCancelledDate = New System.Windows.Forms.DateTimePicker()
        Me.chkGasSupplyPipework = New System.Windows.Forms.CheckBox()
        Me.tcBottomSection = New System.Windows.Forms.TabControl()
        Me.tabProperties = New System.Windows.Forms.TabPage()
        Me.grpSites = New System.Windows.Forms.GroupBox()
        Me.dgSites = New System.Windows.Forms.DataGrid()
        Me.tabChargeDetails = New System.Windows.Forms.TabPage()
        Me.gpbChargeDetails = New System.Windows.Forms.GroupBox()
        Me.lblSortCode = New System.Windows.Forms.Label()
        Me.lblAccount = New System.Windows.Forms.Label()
        Me.lblBankName = New System.Windows.Forms.Label()
        Me.txtSortCode = New System.Windows.Forms.TextBox()
        Me.txtAccountNumber = New System.Windows.Forms.TextBox()
        Me.txtBankName = New System.Windows.Forms.TextBox()
        Me.rdoDirectDebit = New System.Windows.Forms.RadioButton()
        Me.rdoCreditCard = New System.Windows.Forms.RadioButton()
        Me.rdoCheque = New System.Windows.Forms.RadioButton()
        Me.tabAdditionalNotes = New System.Windows.Forms.TabPage()
        Me.gpbInvoiceInformation = New System.Windows.Forms.GroupBox()
        Me.txtAdditionalInvoiceNotes = New System.Windows.Forms.RichTextBox()
        Me.cboContractType = New System.Windows.Forms.ComboBox()
        Me.lblContractType = New System.Windows.Forms.Label()
        Me.gpbInvoiceAddress = New System.Windows.Forms.GroupBox()
        Me.dgInvoiceAddress = New System.Windows.Forms.DataGrid()
        Me.dtpFirstInvoiceDate = New System.Windows.Forms.DateTimePicker()
        Me.lblFirstInvoiceDate = New System.Windows.Forms.Label()
        Me.dtpContractStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblContractStartDate = New System.Windows.Forms.Label()
        Me.dtpContractEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblContractEndDate = New System.Windows.Forms.Label()
        Me.cboContractStatusID = New System.Windows.Forms.ComboBox()
        Me.lblContractStatusID = New System.Windows.Forms.Label()
        Me.txtContractPrice = New System.Windows.Forms.TextBox()
        Me.lblContractPrice = New System.Windows.Forms.Label()
        Me.cboInvoiceFrequencyID = New System.Windows.Forms.ComboBox()
        Me.lblInvoiceFrequencyID = New System.Windows.Forms.Label()
        Me.grpContract.SuspendLayout()
        Me.tcBottomSection.SuspendLayout()
        Me.tabProperties.SuspendLayout()
        Me.grpSites.SuspendLayout()
        CType(Me.dgSites, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabChargeDetails.SuspendLayout()
        Me.gpbChargeDetails.SuspendLayout()
        Me.tabAdditionalNotes.SuspendLayout()
        Me.gpbInvoiceInformation.SuspendLayout()
        Me.gpbInvoiceAddress.SuspendLayout()
        CType(Me.dgInvoiceAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpContract
        '
        Me.grpContract.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpContract.Controls.Add(Me.txtSearchFilter)
        Me.grpContract.Controls.Add(Me.lblSearchFilter)
        Me.grpContract.Controls.Add(Me.cboPaidBy)
        Me.grpContract.Controls.Add(Me.lblPaidBy)
        Me.grpContract.Controls.Add(Me.lblMsg)
        Me.grpContract.Controls.Add(Me.lblInvType)
        Me.grpContract.Controls.Add(Me.cboInvType)
        Me.grpContract.Controls.Add(Me.cboReasonID)
        Me.grpContract.Controls.Add(Me.lblReason)
        Me.grpContract.Controls.Add(Me.lblDiscount)
        Me.grpContract.Controls.Add(Me.cboDiscount)
        Me.grpContract.Controls.Add(Me.txtDDMSRef)
        Me.grpContract.Controls.Add(Me.lblDDMSRef)
        Me.grpContract.Controls.Add(Me.cboDoNotRenew)
        Me.grpContract.Controls.Add(Me.txtContractReference)
        Me.grpContract.Controls.Add(Me.lblContractReference)
        Me.grpContract.Controls.Add(Me.txtPONumber)
        Me.grpContract.Controls.Add(Me.lblPONumber)
        Me.grpContract.Controls.Add(Me.chkPlumbingDrainage)
        Me.grpContract.Controls.Add(Me.chkWindowLockPest)
        Me.grpContract.Controls.Add(Me.lblCancelledDate)
        Me.grpContract.Controls.Add(Me.dtpCancelledDate)
        Me.grpContract.Controls.Add(Me.chkGasSupplyPipework)
        Me.grpContract.Controls.Add(Me.tcBottomSection)
        Me.grpContract.Controls.Add(Me.cboContractType)
        Me.grpContract.Controls.Add(Me.lblContractType)
        Me.grpContract.Controls.Add(Me.gpbInvoiceAddress)
        Me.grpContract.Controls.Add(Me.dtpFirstInvoiceDate)
        Me.grpContract.Controls.Add(Me.lblFirstInvoiceDate)
        Me.grpContract.Controls.Add(Me.dtpContractStartDate)
        Me.grpContract.Controls.Add(Me.lblContractStartDate)
        Me.grpContract.Controls.Add(Me.dtpContractEndDate)
        Me.grpContract.Controls.Add(Me.lblContractEndDate)
        Me.grpContract.Controls.Add(Me.cboContractStatusID)
        Me.grpContract.Controls.Add(Me.lblContractStatusID)
        Me.grpContract.Controls.Add(Me.txtContractPrice)
        Me.grpContract.Controls.Add(Me.lblContractPrice)
        Me.grpContract.Controls.Add(Me.cboInvoiceFrequencyID)
        Me.grpContract.Controls.Add(Me.lblInvoiceFrequencyID)
        Me.grpContract.Location = New System.Drawing.Point(8, 8)
        Me.grpContract.Name = "grpContract"
        Me.grpContract.Size = New System.Drawing.Size(769, 627)
        Me.grpContract.TabIndex = 0
        Me.grpContract.TabStop = False
        Me.grpContract.Text = "Main Details"
        '
        'txtSearchFilter
        '
        Me.txtSearchFilter.Location = New System.Drawing.Point(496, 133)
        Me.txtSearchFilter.MaxLength = 100
        Me.txtSearchFilter.Name = "txtSearchFilter"
        Me.txtSearchFilter.Size = New System.Drawing.Size(248, 21)
        Me.txtSearchFilter.TabIndex = 44
        Me.txtSearchFilter.Tag = ""
        '
        'lblSearchFilter
        '
        Me.lblSearchFilter.Location = New System.Drawing.Point(360, 137)
        Me.lblSearchFilter.Name = "lblSearchFilter"
        Me.lblSearchFilter.Size = New System.Drawing.Size(132, 20)
        Me.lblSearchFilter.TabIndex = 43
        Me.lblSearchFilter.Text = "Search Filter"
        '
        'cboPaidBy
        '
        Me.cboPaidBy.FormattingEnabled = True
        Me.cboPaidBy.Location = New System.Drawing.Point(496, 105)
        Me.cboPaidBy.Name = "cboPaidBy"
        Me.cboPaidBy.Size = New System.Drawing.Size(248, 21)
        Me.cboPaidBy.TabIndex = 41
        Me.cboPaidBy.Visible = False
        '
        'lblPaidBy
        '
        Me.lblPaidBy.Location = New System.Drawing.Point(360, 106)
        Me.lblPaidBy.Name = "lblPaidBy"
        Me.lblPaidBy.Size = New System.Drawing.Size(130, 17)
        Me.lblPaidBy.TabIndex = 42
        Me.lblPaidBy.Text = "Paid By"
        Me.lblPaidBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPaidBy.Visible = False
        '
        'lblMsg
        '
        Me.lblMsg.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMsg.Location = New System.Drawing.Point(366, 366)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(376, 23)
        Me.lblMsg.TabIndex = 25
        Me.lblMsg.Text = "Please save before adding properties"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInvType
        '
        Me.lblInvType.Location = New System.Drawing.Point(360, 79)
        Me.lblInvType.Name = "lblInvType"
        Me.lblInvType.Size = New System.Drawing.Size(130, 17)
        Me.lblInvType.TabIndex = 40
        Me.lblInvType.Text = "Invoice Type"
        Me.lblInvType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboInvType
        '
        Me.cboInvType.FormattingEnabled = True
        Me.cboInvType.Location = New System.Drawing.Point(496, 78)
        Me.cboInvType.Name = "cboInvType"
        Me.cboInvType.Size = New System.Drawing.Size(248, 21)
        Me.cboInvType.TabIndex = 39
        '
        'cboReasonID
        '
        Me.cboReasonID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboReasonID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReasonID.Location = New System.Drawing.Point(144, 242)
        Me.cboReasonID.Name = "cboReasonID"
        Me.cboReasonID.Size = New System.Drawing.Size(195, 21)
        Me.cboReasonID.TabIndex = 38
        Me.cboReasonID.Tag = "Contract.ContractStatusID"
        '
        'lblReason
        '
        Me.lblReason.Location = New System.Drawing.Point(17, 245)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(132, 20)
        Me.lblReason.TabIndex = 37
        Me.lblReason.Text = "Reason"
        '
        'lblDiscount
        '
        Me.lblDiscount.Location = New System.Drawing.Point(17, 321)
        Me.lblDiscount.Name = "lblDiscount"
        Me.lblDiscount.Size = New System.Drawing.Size(121, 20)
        Me.lblDiscount.TabIndex = 36
        Me.lblDiscount.Text = "Discount"
        '
        'cboDiscount
        '
        Me.cboDiscount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDiscount.Location = New System.Drawing.Point(144, 318)
        Me.cboDiscount.Name = "cboDiscount"
        Me.cboDiscount.Size = New System.Drawing.Size(195, 21)
        Me.cboDiscount.TabIndex = 35
        Me.cboDiscount.Tag = ""
        '
        'txtDDMSRef
        '
        Me.txtDDMSRef.Location = New System.Drawing.Point(494, 310)
        Me.txtDDMSRef.MaxLength = 100
        Me.txtDDMSRef.Name = "txtDDMSRef"
        Me.txtDDMSRef.Size = New System.Drawing.Size(248, 21)
        Me.txtDDMSRef.TabIndex = 34
        Me.txtDDMSRef.Tag = ""
        '
        'lblDDMSRef
        '
        Me.lblDDMSRef.Location = New System.Drawing.Point(367, 313)
        Me.lblDDMSRef.Name = "lblDDMSRef"
        Me.lblDDMSRef.Size = New System.Drawing.Size(132, 20)
        Me.lblDDMSRef.TabIndex = 33
        Me.lblDDMSRef.Text = "DDMS Ref"
        '
        'cboDoNotRenew
        '
        Me.cboDoNotRenew.AutoSize = True
        Me.cboDoNotRenew.Location = New System.Drawing.Point(20, 296)
        Me.cboDoNotRenew.Name = "cboDoNotRenew"
        Me.cboDoNotRenew.Size = New System.Drawing.Size(107, 17)
        Me.cboDoNotRenew.TabIndex = 32
        Me.cboDoNotRenew.Text = "Do Not Renew"
        Me.cboDoNotRenew.UseVisualStyleBackColor = True
        '
        'txtContractReference
        '
        Me.txtContractReference.Location = New System.Drawing.Point(144, 45)
        Me.txtContractReference.MaxLength = 100
        Me.txtContractReference.Name = "txtContractReference"
        Me.txtContractReference.Size = New System.Drawing.Size(195, 21)
        Me.txtContractReference.TabIndex = 31
        Me.txtContractReference.Tag = "Contract.ContractReference"
        '
        'lblContractReference
        '
        Me.lblContractReference.Location = New System.Drawing.Point(16, 47)
        Me.lblContractReference.Name = "lblContractReference"
        Me.lblContractReference.Size = New System.Drawing.Size(132, 20)
        Me.lblContractReference.TabIndex = 30
        Me.lblContractReference.Text = "Contract Reference"
        '
        'txtPONumber
        '
        Me.txtPONumber.Location = New System.Drawing.Point(494, 337)
        Me.txtPONumber.MaxLength = 100
        Me.txtPONumber.Name = "txtPONumber"
        Me.txtPONumber.Size = New System.Drawing.Size(248, 21)
        Me.txtPONumber.TabIndex = 29
        Me.txtPONumber.Tag = ""
        '
        'lblPONumber
        '
        Me.lblPONumber.Location = New System.Drawing.Point(367, 340)
        Me.lblPONumber.Name = "lblPONumber"
        Me.lblPONumber.Size = New System.Drawing.Size(132, 20)
        Me.lblPONumber.TabIndex = 28
        Me.lblPONumber.Text = "PO Number"
        '
        'chkPlumbingDrainage
        '
        Me.chkPlumbingDrainage.AutoSize = True
        Me.chkPlumbingDrainage.Location = New System.Drawing.Point(20, 201)
        Me.chkPlumbingDrainage.Name = "chkPlumbingDrainage"
        Me.chkPlumbingDrainage.Size = New System.Drawing.Size(252, 17)
        Me.chkPlumbingDrainage.TabIndex = 27
        Me.chkPlumbingDrainage.Text = "Plumbing, drainage and electrical cover"
        Me.chkPlumbingDrainage.UseVisualStyleBackColor = True
        '
        'chkWindowLockPest
        '
        Me.chkWindowLockPest.AutoSize = True
        Me.chkWindowLockPest.Location = New System.Drawing.Point(20, 221)
        Me.chkWindowLockPest.Name = "chkWindowLockPest"
        Me.chkWindowLockPest.Size = New System.Drawing.Size(190, 17)
        Me.chkWindowLockPest.TabIndex = 26
        Me.chkWindowLockPest.Text = "Window, lock and pest cover"
        Me.chkWindowLockPest.UseVisualStyleBackColor = True
        '
        'lblCancelledDate
        '
        Me.lblCancelledDate.Location = New System.Drawing.Point(17, 275)
        Me.lblCancelledDate.Name = "lblCancelledDate"
        Me.lblCancelledDate.Size = New System.Drawing.Size(121, 20)
        Me.lblCancelledDate.TabIndex = 15
        Me.lblCancelledDate.Text = "Cancelled Date"
        '
        'dtpCancelledDate
        '
        Me.dtpCancelledDate.Location = New System.Drawing.Point(144, 271)
        Me.dtpCancelledDate.Name = "dtpCancelledDate"
        Me.dtpCancelledDate.Size = New System.Drawing.Size(195, 21)
        Me.dtpCancelledDate.TabIndex = 16
        '
        'chkGasSupplyPipework
        '
        Me.chkGasSupplyPipework.AutoSize = True
        Me.chkGasSupplyPipework.Location = New System.Drawing.Point(20, 180)
        Me.chkGasSupplyPipework.Name = "chkGasSupplyPipework"
        Me.chkGasSupplyPipework.Size = New System.Drawing.Size(147, 17)
        Me.chkGasSupplyPipework.TabIndex = 14
        Me.chkGasSupplyPipework.Text = "Gas Supply Pipework"
        Me.chkGasSupplyPipework.UseVisualStyleBackColor = True
        '
        'tcBottomSection
        '
        Me.tcBottomSection.Controls.Add(Me.tabProperties)
        Me.tcBottomSection.Controls.Add(Me.tabChargeDetails)
        Me.tcBottomSection.Controls.Add(Me.tabAdditionalNotes)
        Me.tcBottomSection.Location = New System.Drawing.Point(19, 374)
        Me.tcBottomSection.Name = "tcBottomSection"
        Me.tcBottomSection.SelectedIndex = 0
        Me.tcBottomSection.Size = New System.Drawing.Size(736, 249)
        Me.tcBottomSection.TabIndex = 24
        '
        'tabProperties
        '
        Me.tabProperties.Controls.Add(Me.grpSites)
        Me.tabProperties.Location = New System.Drawing.Point(4, 22)
        Me.tabProperties.Name = "tabProperties"
        Me.tabProperties.Size = New System.Drawing.Size(728, 223)
        Me.tabProperties.TabIndex = 0
        Me.tabProperties.Text = "Properties"
        '
        'grpSites
        '
        Me.grpSites.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSites.Controls.Add(Me.dgSites)
        Me.grpSites.Location = New System.Drawing.Point(8, 3)
        Me.grpSites.Name = "grpSites"
        Me.grpSites.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.grpSites.Size = New System.Drawing.Size(720, 214)
        Me.grpSites.TabIndex = 0
        Me.grpSites.TabStop = False
        Me.grpSites.Text = "Properties - Double click to view/edit"
        '
        'dgSites
        '
        Me.dgSites.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSites.DataMember = ""
        Me.dgSites.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSites.Location = New System.Drawing.Point(11, 22)
        Me.dgSites.Name = "dgSites"
        Me.dgSites.Size = New System.Drawing.Size(700, 185)
        Me.dgSites.TabIndex = 0
        '
        'tabChargeDetails
        '
        Me.tabChargeDetails.Controls.Add(Me.gpbChargeDetails)
        Me.tabChargeDetails.Location = New System.Drawing.Point(4, 22)
        Me.tabChargeDetails.Name = "tabChargeDetails"
        Me.tabChargeDetails.Size = New System.Drawing.Size(728, 223)
        Me.tabChargeDetails.TabIndex = 1
        Me.tabChargeDetails.Text = "Charge Details"
        '
        'gpbChargeDetails
        '
        Me.gpbChargeDetails.Controls.Add(Me.lblSortCode)
        Me.gpbChargeDetails.Controls.Add(Me.lblAccount)
        Me.gpbChargeDetails.Controls.Add(Me.lblBankName)
        Me.gpbChargeDetails.Controls.Add(Me.txtSortCode)
        Me.gpbChargeDetails.Controls.Add(Me.txtAccountNumber)
        Me.gpbChargeDetails.Controls.Add(Me.txtBankName)
        Me.gpbChargeDetails.Controls.Add(Me.rdoDirectDebit)
        Me.gpbChargeDetails.Controls.Add(Me.rdoCreditCard)
        Me.gpbChargeDetails.Controls.Add(Me.rdoCheque)
        Me.gpbChargeDetails.Location = New System.Drawing.Point(8, 0)
        Me.gpbChargeDetails.Name = "gpbChargeDetails"
        Me.gpbChargeDetails.Size = New System.Drawing.Size(712, 320)
        Me.gpbChargeDetails.TabIndex = 0
        Me.gpbChargeDetails.TabStop = False
        Me.gpbChargeDetails.Text = "Charge Details"
        '
        'lblSortCode
        '
        Me.lblSortCode.Location = New System.Drawing.Point(128, 152)
        Me.lblSortCode.Name = "lblSortCode"
        Me.lblSortCode.Size = New System.Drawing.Size(100, 23)
        Me.lblSortCode.TabIndex = 8
        Me.lblSortCode.Text = "Sort Code"
        '
        'lblAccount
        '
        Me.lblAccount.Location = New System.Drawing.Point(128, 120)
        Me.lblAccount.Name = "lblAccount"
        Me.lblAccount.Size = New System.Drawing.Size(100, 23)
        Me.lblAccount.TabIndex = 7
        Me.lblAccount.Text = "Account Number"
        '
        'lblBankName
        '
        Me.lblBankName.Location = New System.Drawing.Point(128, 88)
        Me.lblBankName.Name = "lblBankName"
        Me.lblBankName.Size = New System.Drawing.Size(100, 23)
        Me.lblBankName.TabIndex = 6
        Me.lblBankName.Text = "Bank Name"
        '
        'txtSortCode
        '
        Me.txtSortCode.Location = New System.Drawing.Point(232, 152)
        Me.txtSortCode.Name = "txtSortCode"
        Me.txtSortCode.Size = New System.Drawing.Size(360, 21)
        Me.txtSortCode.TabIndex = 5
        '
        'txtAccountNumber
        '
        Me.txtAccountNumber.Location = New System.Drawing.Point(232, 120)
        Me.txtAccountNumber.Name = "txtAccountNumber"
        Me.txtAccountNumber.Size = New System.Drawing.Size(360, 21)
        Me.txtAccountNumber.TabIndex = 4
        '
        'txtBankName
        '
        Me.txtBankName.Location = New System.Drawing.Point(232, 88)
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.Size = New System.Drawing.Size(360, 21)
        Me.txtBankName.TabIndex = 3
        '
        'rdoDirectDebit
        '
        Me.rdoDirectDebit.Location = New System.Drawing.Point(16, 88)
        Me.rdoDirectDebit.Name = "rdoDirectDebit"
        Me.rdoDirectDebit.Size = New System.Drawing.Size(104, 24)
        Me.rdoDirectDebit.TabIndex = 2
        Me.rdoDirectDebit.Text = "Direct Debit"
        '
        'rdoCreditCard
        '
        Me.rdoCreditCard.Location = New System.Drawing.Point(16, 56)
        Me.rdoCreditCard.Name = "rdoCreditCard"
        Me.rdoCreditCard.Size = New System.Drawing.Size(104, 24)
        Me.rdoCreditCard.TabIndex = 1
        Me.rdoCreditCard.Text = "Credit Card"
        '
        'rdoCheque
        '
        Me.rdoCheque.Location = New System.Drawing.Point(16, 24)
        Me.rdoCheque.Name = "rdoCheque"
        Me.rdoCheque.Size = New System.Drawing.Size(104, 24)
        Me.rdoCheque.TabIndex = 0
        Me.rdoCheque.Text = "Cheque"
        '
        'tabAdditionalNotes
        '
        Me.tabAdditionalNotes.Controls.Add(Me.gpbInvoiceInformation)
        Me.tabAdditionalNotes.Location = New System.Drawing.Point(4, 22)
        Me.tabAdditionalNotes.Name = "tabAdditionalNotes"
        Me.tabAdditionalNotes.Size = New System.Drawing.Size(728, 223)
        Me.tabAdditionalNotes.TabIndex = 2
        Me.tabAdditionalNotes.Text = "Additional Notes"
        Me.tabAdditionalNotes.UseVisualStyleBackColor = True
        '
        'gpbInvoiceInformation
        '
        Me.gpbInvoiceInformation.BackColor = System.Drawing.SystemColors.Control
        Me.gpbInvoiceInformation.Controls.Add(Me.txtAdditionalInvoiceNotes)
        Me.gpbInvoiceInformation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpbInvoiceInformation.Location = New System.Drawing.Point(0, 0)
        Me.gpbInvoiceInformation.Name = "gpbInvoiceInformation"
        Me.gpbInvoiceInformation.Size = New System.Drawing.Size(728, 223)
        Me.gpbInvoiceInformation.TabIndex = 3
        Me.gpbInvoiceInformation.TabStop = False
        Me.gpbInvoiceInformation.Text = "Additional Notes"
        '
        'txtAdditionalInvoiceNotes
        '
        Me.txtAdditionalInvoiceNotes.Location = New System.Drawing.Point(6, 20)
        Me.txtAdditionalInvoiceNotes.Name = "txtAdditionalInvoiceNotes"
        Me.txtAdditionalInvoiceNotes.Size = New System.Drawing.Size(499, 130)
        Me.txtAdditionalInvoiceNotes.TabIndex = 13
        Me.txtAdditionalInvoiceNotes.Text = ""
        '
        'cboContractType
        '
        Me.cboContractType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboContractType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContractType.Location = New System.Drawing.Point(144, 20)
        Me.cboContractType.Name = "cboContractType"
        Me.cboContractType.Size = New System.Drawing.Size(195, 21)
        Me.cboContractType.TabIndex = 4
        Me.cboContractType.Tag = ""
        '
        'lblContractType
        '
        Me.lblContractType.Location = New System.Drawing.Point(16, 22)
        Me.lblContractType.Name = "lblContractType"
        Me.lblContractType.Size = New System.Drawing.Size(132, 20)
        Me.lblContractType.TabIndex = 3
        Me.lblContractType.Text = "Contract Type"
        '
        'gpbInvoiceAddress
        '
        Me.gpbInvoiceAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbInvoiceAddress.Controls.Add(Me.dgInvoiceAddress)
        Me.gpbInvoiceAddress.Location = New System.Drawing.Point(363, 160)
        Me.gpbInvoiceAddress.Name = "gpbInvoiceAddress"
        Me.gpbInvoiceAddress.Size = New System.Drawing.Size(392, 140)
        Me.gpbInvoiceAddress.TabIndex = 23
        Me.gpbInvoiceAddress.TabStop = False
        Me.gpbInvoiceAddress.Text = "Invoice Address"
        '
        'dgInvoiceAddress
        '
        Me.dgInvoiceAddress.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgInvoiceAddress.DataMember = ""
        Me.dgInvoiceAddress.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgInvoiceAddress.Location = New System.Drawing.Point(8, 20)
        Me.dgInvoiceAddress.Name = "dgInvoiceAddress"
        Me.dgInvoiceAddress.Size = New System.Drawing.Size(376, 112)
        Me.dgInvoiceAddress.TabIndex = 0
        '
        'dtpFirstInvoiceDate
        '
        Me.dtpFirstInvoiceDate.Location = New System.Drawing.Point(496, 51)
        Me.dtpFirstInvoiceDate.Name = "dtpFirstInvoiceDate"
        Me.dtpFirstInvoiceDate.Size = New System.Drawing.Size(248, 21)
        Me.dtpFirstInvoiceDate.TabIndex = 22
        Me.dtpFirstInvoiceDate.Tag = ""
        '
        'lblFirstInvoiceDate
        '
        Me.lblFirstInvoiceDate.Location = New System.Drawing.Point(360, 57)
        Me.lblFirstInvoiceDate.Name = "lblFirstInvoiceDate"
        Me.lblFirstInvoiceDate.Size = New System.Drawing.Size(132, 20)
        Me.lblFirstInvoiceDate.TabIndex = 21
        Me.lblFirstInvoiceDate.Text = "First Invoice Date"
        '
        'dtpContractStartDate
        '
        Me.dtpContractStartDate.Location = New System.Drawing.Point(144, 96)
        Me.dtpContractStartDate.Name = "dtpContractStartDate"
        Me.dtpContractStartDate.Size = New System.Drawing.Size(195, 21)
        Me.dtpContractStartDate.TabIndex = 8
        Me.dtpContractStartDate.Tag = "Contract.ContractStartDate"
        '
        'lblContractStartDate
        '
        Me.lblContractStartDate.Location = New System.Drawing.Point(17, 96)
        Me.lblContractStartDate.Name = "lblContractStartDate"
        Me.lblContractStartDate.Size = New System.Drawing.Size(132, 20)
        Me.lblContractStartDate.TabIndex = 7
        Me.lblContractStartDate.Text = "Contract Start Date"
        '
        'dtpContractEndDate
        '
        Me.dtpContractEndDate.Location = New System.Drawing.Point(144, 120)
        Me.dtpContractEndDate.Name = "dtpContractEndDate"
        Me.dtpContractEndDate.Size = New System.Drawing.Size(195, 21)
        Me.dtpContractEndDate.TabIndex = 10
        Me.dtpContractEndDate.Tag = "Contract.ContractEndDate"
        '
        'lblContractEndDate
        '
        Me.lblContractEndDate.Location = New System.Drawing.Point(17, 120)
        Me.lblContractEndDate.Name = "lblContractEndDate"
        Me.lblContractEndDate.Size = New System.Drawing.Size(132, 20)
        Me.lblContractEndDate.TabIndex = 9
        Me.lblContractEndDate.Text = "Contract End Date"
        '
        'cboContractStatusID
        '
        Me.cboContractStatusID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboContractStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContractStatusID.Location = New System.Drawing.Point(144, 72)
        Me.cboContractStatusID.Name = "cboContractStatusID"
        Me.cboContractStatusID.Size = New System.Drawing.Size(195, 21)
        Me.cboContractStatusID.TabIndex = 6
        Me.cboContractStatusID.Tag = "Contract.ContractStatusID"
        '
        'lblContractStatusID
        '
        Me.lblContractStatusID.Location = New System.Drawing.Point(17, 72)
        Me.lblContractStatusID.Name = "lblContractStatusID"
        Me.lblContractStatusID.Size = New System.Drawing.Size(132, 20)
        Me.lblContractStatusID.TabIndex = 5
        Me.lblContractStatusID.Text = "Contract Status"
        Me.lblContractStatusID.Visible = False
        '
        'txtContractPrice
        '
        Me.txtContractPrice.Location = New System.Drawing.Point(144, 144)
        Me.txtContractPrice.MaxLength = 9
        Me.txtContractPrice.Name = "txtContractPrice"
        Me.txtContractPrice.Size = New System.Drawing.Size(195, 21)
        Me.txtContractPrice.TabIndex = 12
        Me.txtContractPrice.Tag = "Contract.ContractPrice"
        '
        'lblContractPrice
        '
        Me.lblContractPrice.Location = New System.Drawing.Point(16, 144)
        Me.lblContractPrice.Name = "lblContractPrice"
        Me.lblContractPrice.Size = New System.Drawing.Size(132, 20)
        Me.lblContractPrice.TabIndex = 11
        Me.lblContractPrice.Text = "Total Contract Price"
        '
        'cboInvoiceFrequencyID
        '
        Me.cboInvoiceFrequencyID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboInvoiceFrequencyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInvoiceFrequencyID.Location = New System.Drawing.Point(496, 24)
        Me.cboInvoiceFrequencyID.Name = "cboInvoiceFrequencyID"
        Me.cboInvoiceFrequencyID.Size = New System.Drawing.Size(248, 21)
        Me.cboInvoiceFrequencyID.TabIndex = 20
        Me.cboInvoiceFrequencyID.Tag = "Contract.InvoiceFrequencyID"
        '
        'lblInvoiceFrequencyID
        '
        Me.lblInvoiceFrequencyID.Location = New System.Drawing.Point(360, 27)
        Me.lblInvoiceFrequencyID.Name = "lblInvoiceFrequencyID"
        Me.lblInvoiceFrequencyID.Size = New System.Drawing.Size(132, 20)
        Me.lblInvoiceFrequencyID.TabIndex = 19
        Me.lblInvoiceFrequencyID.Text = "Invoice Frequency"
        '
        'UCContractOriginal
        '
        Me.Controls.Add(Me.grpContract)
        Me.Name = "UCContractOriginal"
        Me.Size = New System.Drawing.Size(784, 638)
        Me.grpContract.ResumeLayout(False)
        Me.grpContract.PerformLayout()
        Me.tcBottomSection.ResumeLayout(False)
        Me.tabProperties.ResumeLayout(False)
        Me.grpSites.ResumeLayout(False)
        CType(Me.dgSites, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabChargeDetails.ResumeLayout(False)
        Me.gpbChargeDetails.ResumeLayout(False)
        Me.gpbChargeDetails.PerformLayout()
        Me.tabAdditionalNotes.ResumeLayout(False)
        Me.gpbInvoiceInformation.ResumeLayout(False)
        Me.gpbInvoiceAddress.ResumeLayout(False)
        CType(Me.dgInvoiceAddress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)

    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentContract
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _currentContract As Entity.ContractsOriginal.ContractOriginal

    Public Property CurrentContract() As Entity.ContractsOriginal.ContractOriginal
        Get
            Return _currentContract
        End Get
        Set(ByVal Value As Entity.ContractsOriginal.ContractOriginal)
            _currentContract = Value

            If _currentContract Is Nothing Then
                _currentContract = New Entity.ContractsOriginal.ContractOriginal
                _currentContract.Exists = False
                Combo.SetSelectedComboItem_By_Value(cboContractStatusID, 3)
            End If

            If _currentContract.Exists Then

                Populate()
                grpSites.Enabled = True
                lblMsg.Visible = False
                dtpContractEndDate.Enabled = False
                dtpContractStartDate.Enabled = False
                dtpFirstInvoiceDate.Enabled = False
                cboInvoiceFrequencyID.Enabled = False
                gpbInvoiceAddress.Enabled = False
            Else
                grpSites.Enabled = False

                lblMsg.Visible = True
                txtContractPrice.Text = Format(CDbl(0.0), "C")
            End If

        End Set
    End Property

    Private _InvoiceToBeRaised As Entity.InvoiceToBeRaiseds.InvoiceToBeRaised

    Public Property InvoiceToBeRaised As Entity.InvoiceToBeRaiseds.InvoiceToBeRaised
        Get
            Return _InvoiceToBeRaised
        End Get
        Set(value As Entity.InvoiceToBeRaiseds.InvoiceToBeRaised)
            _InvoiceToBeRaised = value

            If InvoiceToBeRaised Is Nothing Then
                InvoiceToBeRaised = New Entity.InvoiceToBeRaiseds.InvoiceToBeRaised
                InvoiceToBeRaised.Exists = False
                Combo.SetSelectedComboItem_By_Value(Me.cboInvType, 1)
            Else
                Combo.SetSelectedComboItem_By_Value(Me.cboInvType, InvoiceToBeRaised.PaymentTermID)
            End If
        End Set
    End Property

    Private _IDToLinkTo As Integer = 0

    Public Property IDToLinkTo() As Integer
        Get
            Return _IDToLinkTo
        End Get
        Set(ByVal Value As Integer)
            _IDToLinkTo = Value

            If Not CurrentContract.Exists Then
                Dim currentContracts As DataTable = DB.Customer.Customer_Contracts_GetAll(IDToLinkTo).Table
                If currentContracts.Rows.Count > 0 Then
                    Dim length As Integer = currentContracts.Select("ContractType = 'Contract_Opt_1'").Length
                    If length > 0 Then
                        Me.txtContractReference.Text = currentContracts.Select("ContractType = 'Contract_Opt_1'")(length - 1).Item("ContractReference")
                        Me.txtContractReference.Text = ""
                    End If
                End If
            End If

            Sites = DB.ContractOriginalSite.GetAll_ContractID(CurrentContract.ContractID, IDToLinkTo)

            'Load Invoice Addresses
            InvoiceAddresses = DB.InvoiceAddress.InvoiceAddress_Get_CustomerID(IDToLinkTo)

            If CurrentContract.InvoiceAddressID > 0 Then
                Dim c As Integer = 0
                For Each dr As DataRow In InvoiceAddresses.Table.Rows
                    If dr("AddressID") = CurrentContract.InvoiceAddressID And
                        dr("AddressTypeID") = CurrentContract.InvoiceAddressTypeID Then
                        dgInvoiceAddress.CurrentRowIndex = c
                        Exit For
                    End If
                    c += 1
                Next dr
            Else
                dgInvoiceAddress.CurrentRowIndex = 0
            End If

            dgInvoiceAddress.Select(dgInvoiceAddress.CurrentRowIndex)

        End Set
    End Property

    Private _Sites As DataView

    Public Property Sites() As DataView
        Get
            Return _Sites
        End Get
        Set(ByVal Value As DataView)
            _Sites = Value
            _Sites.Table.TableName = Entity.Sys.Enums.TableNames.tblContractSite.ToString
            _Sites.AllowNew = False
            _Sites.AllowEdit = False
            _Sites.AllowDelete = False

            SiteID = SiteID
            Me.dgSites.DataSource = Sites
        End Set
    End Property

    Private ReadOnly Property SelectedSiteDataRow() As DataRow
        Get
            If Not Me.dgSites.CurrentRowIndex = -1 Then
                Return Sites(Me.dgSites.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _InvoiceAddresses As DataView

    Private Property InvoiceAddresses() As DataView
        Get
            Return _InvoiceAddresses
        End Get
        Set(ByVal Value As DataView)
            _InvoiceAddresses = Value
            _InvoiceAddresses.AllowDelete = False
            _InvoiceAddresses.AllowEdit = False
            _InvoiceAddresses.AllowNew = False
            _InvoiceAddresses.Table.TableName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString
            dgInvoiceAddress.DataSource = InvoiceAddresses
        End Set
    End Property

    Private ReadOnly Property SelectedInvoiceAddressesDataRow() As DataRow
        Get
            If Not Me.dgInvoiceAddress.CurrentRowIndex = -1 Then
                Return InvoiceAddresses(Me.dgInvoiceAddress.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _SiteID As Integer = 0

    Public Property SiteID() As Integer
        Get
            Return _SiteID
        End Get
        Set(ByVal Value As Integer)
            _SiteID = Value
            'IF IT A DOMESTIC CUSTOMER WE ONLY WANT TO SHOW ONE SITE
            If SiteID > 0 And IDToLinkTo = Entity.Sys.Enums.Customer.Domestic Then
                _Sites.RowFilter = "SiteID=" & SiteID
                _InvoiceAddresses.RowFilter = "(AddressType ='Customer HQ') OR (AddressType ='Invoice') OR (AddressID=" & SiteID & ")"

            End If
        End Set
    End Property

    Private _NumberUsed As Boolean = False

    Public Property NumberUsed() As Boolean
        Get
            Return _NumberUsed
        End Get
        Set(ByVal Value As Boolean)
            _NumberUsed = Value
        End Set
    End Property

    Public Number As JobNumber = Nothing

#End Region

#Region "SetUp"

    Public Sub SetupSitesDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(dgSites)
        Dim tStyle As DataGridTableStyle = Me.dgSites.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Me.dgSites.ReadOnly = False
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 50
        Tick.NullText = ""
        tStyle.GridColumnStyles.Add(Tick)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Property"
        Site.MappingName = "Site"
        Site.ReadOnly = True
        Site.Width = 200
        Site.NullText = ""
        tStyle.GridColumnStyles.Add(Site)

        Dim FirstVisitDate As New DataGridLabelColumn
        FirstVisitDate.Format = "dd/MM/yyyy"
        FirstVisitDate.FormatInfo = Nothing
        FirstVisitDate.HeaderText = "First Visit Date"
        FirstVisitDate.MappingName = "FirstVisitDate"
        FirstVisitDate.ReadOnly = True
        FirstVisitDate.Width = 100
        FirstVisitDate.NullText = ""
        tStyle.GridColumnStyles.Add(FirstVisitDate)

        Dim PricePerVisit As New DataGridLabelColumn
        PricePerVisit.Format = "C"
        PricePerVisit.FormatInfo = Nothing
        PricePerVisit.HeaderText = "Price Per Visit"
        PricePerVisit.MappingName = "PricePerVisit"
        PricePerVisit.ReadOnly = True
        PricePerVisit.Width = 100
        PricePerVisit.NullText = ""
        tStyle.GridColumnStyles.Add(PricePerVisit)

        Dim VisitFrequency As New DataGridLabelColumn
        VisitFrequency.Format = "C"
        VisitFrequency.FormatInfo = Nothing
        VisitFrequency.HeaderText = "Visit Frequency"
        VisitFrequency.MappingName = "VisitFrequency"
        VisitFrequency.ReadOnly = True
        VisitFrequency.Width = 100
        VisitFrequency.NullText = ""
        tStyle.GridColumnStyles.Add(VisitFrequency)

        Dim TotalSitePrice As New DataGridLabelColumn
        TotalSitePrice.Format = "C"
        TotalSitePrice.FormatInfo = Nothing
        TotalSitePrice.HeaderText = "Total Property Price"
        TotalSitePrice.MappingName = "TotalSitePrice"
        TotalSitePrice.ReadOnly = True
        TotalSitePrice.Width = 100
        TotalSitePrice.NullText = ""
        tStyle.GridColumnStyles.Add(TotalSitePrice)

        Dim VisitDuration As New DataGridLabelColumn
        VisitDuration.Format = ""
        VisitDuration.Alignment = HorizontalAlignment.Center
        VisitDuration.FormatInfo = Nothing
        VisitDuration.HeaderText = "Visit Duration (Mins)"
        VisitDuration.MappingName = "VisitDuration"
        VisitDuration.ReadOnly = True
        VisitDuration.Width = 120
        VisitDuration.NullText = ""
        tStyle.GridColumnStyles.Add(VisitDuration)

        Dim SitePrice As New DataGridLabelColumn
        SitePrice.Format = "C"
        SitePrice.FormatInfo = Nothing
        SitePrice.HeaderText = "Property Price"
        SitePrice.MappingName = "SitePrice"
        SitePrice.ReadOnly = True
        SitePrice.Width = 100
        SitePrice.NullText = ""
        tStyle.GridColumnStyles.Add(SitePrice)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblContractSite.ToString
        Me.dgSites.TableStyles.Add(tStyle)

        Entity.Sys.Helper.RemoveEventHandlers(Me.dgSites)
    End Sub

    Public Sub SetupInvoiceAddressDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgInvoiceAddress)
        Dim tStyle As DataGridTableStyle = Me.dgInvoiceAddress.TableStyles(0)

        tStyle.GridColumnStyles.Clear()
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False
        dgInvoiceAddress.ReadOnly = False

        Dim AddressType As New DataGridLabelColumn
        AddressType.Format = ""
        AddressType.FormatInfo = Nothing
        AddressType.HeaderText = "Address Type"
        AddressType.MappingName = "AddressType"
        AddressType.ReadOnly = True
        AddressType.Width = 95
        AddressType.NullText = ""
        tStyle.GridColumnStyles.Add(AddressType)

        Dim Address1 As New DataGridLabelColumn
        Address1.Format = ""
        Address1.FormatInfo = Nothing
        Address1.HeaderText = "Address 1"
        Address1.MappingName = "Address1"
        Address1.ReadOnly = True
        Address1.Width = 75
        Address1.NullText = ""
        tStyle.GridColumnStyles.Add(Address1)

        Dim Address2 As New DataGridLabelColumn
        Address2.Format = ""
        Address2.FormatInfo = Nothing
        Address2.HeaderText = "Address 2"
        Address2.MappingName = "Address2"
        Address2.ReadOnly = True
        Address2.Width = 75
        Address2.NullText = ""
        tStyle.GridColumnStyles.Add(Address2)

        Dim Address3 As New DataGridLabelColumn
        Address3.Format = ""
        Address3.FormatInfo = Nothing
        Address3.HeaderText = "Address 3"
        Address3.MappingName = "Address3"
        Address3.ReadOnly = True
        Address3.Width = 75
        Address3.NullText = ""
        tStyle.GridColumnStyles.Add(Address3)

        Dim Address4 As New DataGridLabelColumn
        Address4.Format = ""
        Address4.FormatInfo = Nothing
        Address4.HeaderText = "Address 4"
        Address4.MappingName = "Address4"
        Address4.ReadOnly = True
        Address4.Width = 75
        Address4.NullText = ""
        tStyle.GridColumnStyles.Add(Address4)

        Dim Address5 As New DataGridLabelColumn
        Address5.Format = ""
        Address5.FormatInfo = Nothing
        Address5.HeaderText = "Address 5"
        Address5.MappingName = "Address5"
        Address5.ReadOnly = True
        Address5.Width = 75
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

        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString
        Me.dgInvoiceAddress.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub UCContract_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub dgSites_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgSites.MouseUp
        Try
            Dim HitTestInfo As DataGrid.HitTestInfo
            HitTestInfo = dgSites.HitTest(e.X, e.Y)
            If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
                dgSites.CurrentRowIndex = HitTestInfo.Row()
            End If

            If Not HitTestInfo.Column = 0 Then
                Exit Sub
            End If
            If SelectedSiteDataRow Is Nothing Then
                Exit Sub
            End If

            Dim selected As Boolean = Not Entity.Sys.Helper.MakeBooleanValid(Me.dgSites(Me.dgSites.CurrentRowIndex, 0))

            If selected = True Then
                Save()
                ShowForm(GetType(FRMContractOriginalSite), True, New Object() {0, SelectedSiteDataRow("SiteID"), CurrentContract, Me})
            Else
                If ShowMessage("You are about to remove this property from the contract." &
                                vbCrLf & "This will remove all contract property jobs and visits not yet downloaded by the engineer" &
                               vbCrLf & "Do you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    If DB.ContractOriginalSite.Delete(SelectedSiteDataRow("ContractSiteID")) > 0 Then
                        ShowMessage("Could not remove property from contract as there are active visits", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
            Sites = DB.ContractOriginalSite.GetAll_ContractID(CurrentContract.ContractID, IDToLinkTo)
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgSites_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgSites.DoubleClick
        Try
            If SelectedSiteDataRow Is Nothing Then
                Exit Sub
            End If
            Dim Ticked As Boolean = Entity.Sys.Helper.MakeBooleanValid(Me.dgSites(Me.dgSites.CurrentRowIndex, 0))

            If Ticked = True Then
                ShowForm(GetType(FRMContractOriginalSite), True, New Object() {SelectedSiteDataRow("ContractSiteID"), SelectedSiteDataRow("SiteID"), CurrentContract, Me})
            Else
                Save()
                ShowForm(GetType(FRMContractOriginalSite), True, New Object() {0, SelectedSiteDataRow("SiteID"), CurrentContract, Me})
            End If

            Sites = DB.ContractOriginalSite.GetAll_ContractID(CurrentContract.ContractID, IDToLinkTo)
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtContractPrice_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContractPrice.LostFocus
        Dim price As String = ""

        If txtContractPrice.Text.Trim.Length = 0 Then
            price = Format(0.0, "C")
        ElseIf Not IsNumeric(txtContractPrice.Text.Replace("£", "")) Then
            price = Format(0.0, "C")
        Else
            price = Format(CDbl(txtContractPrice.Text.Replace("£", "")), "C")
        End If
        txtContractPrice.Text = price
    End Sub

    Private Sub btnCalculatePrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CurrentContract.ContractID > 0 Then
            Me.txtContractPrice.Text = Format(DB.ContractOriginal.ContractCalculatedTotal(CurrentContract.ContractID), "C")
        End If
    End Sub

    Private Sub btnContractNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowForm(GetType(FRMAvailableContractNos), True, New Object() {Me.txtContractReference, Me})
    End Sub

    Private Sub dgInvoiceAddress_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgInvoiceAddress.Click
        dgInvoiceAddress.Select(dgInvoiceAddress.CurrentRowIndex)
    End Sub

    Private Sub cboContractStatusID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboContractStatusID.SelectedIndexChanged

        If Combo.GetSelectedItemValue(cboContractStatusID) = Entity.Sys.Enums.ContractStatus.Cancelled Then

            If Combo.GetSelectedItemValue(cboReasonID) = 0 Or dtpCancelledDate.Value.Date > Today.Date Then
                MsgBox("You can not mark this contract as 'Cancelled' as you have not entered a cancelled reason or the cancelled date is in the future")
                Combo.SetSelectedComboItem_By_Value(cboContractStatusID, CurrentContract.ContractStatusID)
            End If

        End If

    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        If CurrentContract.Exists Then
            '  CurrentContract = DB.ContractOriginal.Get(ID)
            Me.txtContractReference.Text = CurrentContract.ContractReference
        Else

        End If
        Combo.SetSelectedComboItem_By_Value(cboReasonID, CurrentContract.ReasonID)
        If CurrentContract.ContractStatusID = 0 Then
            Combo.SetSelectedComboItem_By_Value(Me.cboContractStatusID, 3)
        Else
            Combo.SetSelectedComboItem_By_Value(Me.cboContractStatusID, CurrentContract.ContractStatusID)
        End If
        Me.dtpContractStartDate.Value = CurrentContract.ContractStartDate
        Me.dtpContractEndDate.Value = CurrentContract.ContractEndDate
        Me.txtContractPrice.Text = Format(CurrentContract.ContractPrice, "C")
        Combo.SetSelectedComboItem_By_Value(Me.cboInvoiceFrequencyID, CurrentContract.InvoiceFrequencyID)

        Me.dtpFirstInvoiceDate.Value = CurrentContract.FirstInvoiceDate

        Combo.SetSelectedComboItem_By_Value(cboContractType, CurrentContract.ContractTypeID)

        txtPONumber.Text = CurrentContract.PoNumber
        rdoCheque.Checked = CurrentContract.Cheque
        rdoCreditCard.Checked = CurrentContract.CreditCard
        rdoDirectDebit.Checked = CurrentContract.DirectDebit
        txtBankName.Text = CurrentContract.BankName
        txtAccountNumber.Text = CurrentContract.AccountNumber
        txtSortCode.Text = CurrentContract.SortCode
        chkGasSupplyPipework.Checked = CurrentContract.GasSupplyPipework
        chkPlumbingDrainage.Checked = CurrentContract.PlumbingDrainage
        chkWindowLockPest.Checked = CurrentContract.WindowLockPest
        cboDoNotRenew.Checked = CurrentContract.DoNotRenew
        Me.txtAdditionalInvoiceNotes.Text = CurrentContract.Notes

        Combo.SetSelectedComboItem_By_Value(cboDiscount, CurrentContract.DiscountID)

        If CurrentContract.ReasonID > 0 And CurrentContract.CancelledDate <> Nothing Then
            dtpCancelledDate.Value = CurrentContract.CancelledDate
            dtpCancelledDate.Visible = True
            lblCancelledDate.Visible = True
        Else
            dtpCancelledDate.Visible = False
            lblCancelledDate.Visible = False
        End If

        cboReasonID.Visible = True
        lblReason.Visible = True

        If CurrentContract.ContractStatusID = Entity.Sys.Enums.ContractStatus.Cancelled Then
            cboDoNotRenew.Checked = True
        End If

        'Else

        'dtpCancelledDate.Visible = False
        'cboReasonID.Visible = False
        'lblCancelledDate.Visible = False
        'lblReason.Visible = False
        'cboDoNotRenew.Checked = CurrentContract.DoNotRenew
        'End If

        txtDDMSRef.Text = CurrentContract.DDMSRef

    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            CurrentContract.IgnoreExceptionsOnSetMethods = True

            'CHECK TO SEE IF ANY FLAG HAVE CHANGED
            ChangeStatus()

            CurrentContract.SetContractReference = Me.txtContractReference.Text.Trim
            CurrentContract.ContractStartDate = Me.dtpContractStartDate.Value
            CurrentContract.ContractEndDate = Me.dtpContractEndDate.Value
            CurrentContract.SetContractStatusID = Combo.GetSelectedItemValue(Me.cboContractStatusID)
            CurrentContract.SetContractPrice = Me.txtContractPrice.Text.Trim.Replace("£", "")
            CurrentContract.SetInvoiceFrequencyID = Combo.GetSelectedItemValue(Me.cboInvoiceFrequencyID)
            CurrentContract.FirstInvoiceDate = dtpFirstInvoiceDate.Value
            CurrentContract.SetContractTypeID = Combo.GetSelectedItemValue(cboContractType)
            CurrentContract.SetCheque = rdoCheque.Checked
            CurrentContract.SetCreditCard = rdoCreditCard.Checked
            CurrentContract.SetDirectDebit = rdoDirectDebit.Checked
            CurrentContract.SetBankName = txtBankName.Text
            CurrentContract.SetAccountNumber = txtAccountNumber.Text
            CurrentContract.SetSortCode = txtSortCode.Text
            CurrentContract.SetPoNumber = txtPONumber.Text
            CurrentContract.SetGasSupplyPipework = chkGasSupplyPipework.Checked
            CurrentContract.SetPlumbingDrainage = chkPlumbingDrainage.Checked
            CurrentContract.SetWindowLockPest = chkWindowLockPest.Checked
            CurrentContract.SetDoNotRenew = cboDoNotRenew.Checked
            CurrentContract.SetDDMSRef = txtDDMSRef.Text
            CurrentContract.SetNotes = Me.txtAdditionalInvoiceNotes.Text

            CurrentContract.SetDiscountID = Combo.GetSelectedItemValue(cboDiscount)

            If Not SelectedInvoiceAddressesDataRow Is Nothing Then
                CurrentContract.SetInvoiceAddressID = SelectedInvoiceAddressesDataRow("AddressID")
                CurrentContract.SetInvoiceAddressTypeID = SelectedInvoiceAddressesDataRow("AddressTypeID")
            End If

            If CurrentContract.Exists Then
                CurrentContract.SetReasonID = Combo.GetSelectedItemValue(cboReasonID)
                CurrentContract.CancelledDate = dtpCancelledDate.Value

                Dim cV As New Entity.ContractsOriginal.ContractOriginalValidator
                cV.Validate(CurrentContract)

                DB.ContractOriginal.Update(CurrentContract)
                NumberUsed = True
            Else
                CurrentContract.SetCustomerID = IDToLinkTo

                Dim cV As New Entity.ContractsOriginal.ContractOriginalValidator
                cV.Validate(CurrentContract)

                CurrentContract = DB.ContractOriginal.Insert(CurrentContract)
                NumberUsed = True
                InsertInvoiceToBeRaiseLines()

            End If
            If InvoiceToBeRaised.Exists Then
                InvoiceToBeRaised.SetPaymentTermID = Combo.GetSelectedItemValue(cboInvType)
                InvoiceToBeRaised.SetPaidByID = Combo.GetSelectedItemValue(cboPaidBy)
                DB.InvoiceToBeRaised.Update(InvoiceToBeRaised)
            End If

            RaiseEvent StateChanged(CurrentContract.ContractID)

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

    Public Sub ChangeStatus()
        If Not CurrentContract Is Nothing Then
            'IF UPDATING
            If CurrentContract.Exists = True Then

                'IF CHANGING TO INACTIVE
                If CurrentContract.ContractStatusID <> Combo.GetSelectedItemValue(cboContractStatusID) And
                  (CType(Combo.GetSelectedItemValue(cboContractStatusID), Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Inactive) Then

                    '  Or CType(Combo.GetSelectedItemValue(cboContractStatusID), Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Cancelled

                    'ARE YOU SURE - YES NO OR CANCEL
                    Dim msgResult As New MsgBoxResult
                    msgResult = ShowMessage("You are setting this contract to inactive" & vbCrLf &
                                "Do you want to remove any contract job/visits scheduled but not downloaded?",
                                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                    'SET STATUS BACK TO ACTIVE
                    If msgResult = DialogResult.Cancel Then

                        Combo.SetSelectedComboItem_By_Value(cboContractStatusID, CInt(Entity.Sys.Enums.ContractStatus.Active))

                    ElseIf msgResult = MsgBoxResult.Yes Then '"DEACTIVATE EACH SITES JOBS - WHERE NOT DOWNLOADED

                        For Each site As DataRow In Sites.Table.Rows
                            If site("ContractSiteID") > 0 Then
                                DB.ContractOriginalSite.ActiveInactive(site("ContractSiteID"), True)
                            End If
                        Next site
                    End If

                ElseIf CurrentContract.ContractStatusID <> Combo.GetSelectedItemValue(cboContractStatusID) And
                            CType(Combo.GetSelectedItemValue(cboContractStatusID), Entity.Sys.Enums.ContractStatus) =
                                                                Entity.Sys.Enums.ContractStatus.Active Then
                    'IF CHANGING BACK TO ACTIVE

                    'REACTIVE ANY SITE JOBS PREVIOUSLY DEACTIVATED
                    For Each site As DataRow In Sites.Table.Rows
                        If site("ContractSiteID") > 0 Then
                            DB.ContractOriginalSite.ActiveInactive(site("ContractSiteID"), False)
                        End If
                    Next site
                End If

            End If

        End If
    End Sub

    Private Sub InsertInvoiceToBeRaiseLines()
        'Dim numberOfMonths As Double = DateDiff(DateInterval.Month, _
        '                           CDate(Format(CurrentContract.ContractStartDate, "dd/MMM/yyyy") & " 00:00:00"), _
        '                           CDate(Format(CurrentContract.ContractEndDate, "dd/MMM/yyyy") & " 23:59:59"))

        'New Way
        Dim startDate As DateTime = Format(CurrentContract.ContractStartDate, "dd/MM/yyyy") & " 00:00:00"
        Dim endDate As DateTime = Format(CurrentContract.ContractEndDate.AddDays(1), "dd/MM/yyyy") & " 00:00:00"

        Dim M As Integer = Math.Abs((startDate.Year - endDate.Year))
        Dim Numberofmonths As Integer = ((M * 12) + Math.Abs((startDate.Month - endDate.Month)))
        Dim days As Integer = endDate.Subtract(startDate).Days

        Dim numberOfInvoicesToRaise As Integer = 0

        Select Case CType(CurrentContract.InvoiceFrequencyID, Entity.Sys.Enums.InvoiceFrequency_NoWeeK)
            Case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Annually
                numberOfInvoicesToRaise = Numberofmonths / 12

            Case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Bi_Annually
                numberOfInvoicesToRaise = Numberofmonths / 6

            Case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Monthly
                numberOfInvoicesToRaise = Numberofmonths / 1

            Case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Per_Visit
                'Invoice the visit
            Case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Quarterly
                numberOfInvoicesToRaise = Numberofmonths / 3

            Case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.GBS_4_Month_Visits
                numberOfInvoicesToRaise = Numberofmonths / 4
        End Select

        If numberOfInvoicesToRaise = 0 Then
            numberOfInvoicesToRaise = 1
        End If

        Dim raiseDate As DateTime = CurrentContract.FirstInvoiceDate
        For i As Integer = 1 To numberOfInvoicesToRaise
            Dim invToBeRaised As New Entity.InvoiceToBeRaiseds.InvoiceToBeRaised
            invToBeRaised.SetAddressLinkID = CurrentContract.InvoiceAddressID
            invToBeRaised.SetAddressTypeID = CurrentContract.InvoiceAddressTypeID
            invToBeRaised.SetInvoiceTypeID = CInt(Entity.Sys.Enums.InvoiceType.Contract_Option1)
            invToBeRaised.SetLinkID = CurrentContract.ContractID
            invToBeRaised.RaiseDate = raiseDate
            DB.InvoiceToBeRaised.Insert(invToBeRaised)

            Select Case CType(CurrentContract.InvoiceFrequencyID, Entity.Sys.Enums.InvoiceFrequency_NoWeeK)
                Case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Annually
                    raiseDate = raiseDate.AddYears(1)
                Case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Bi_Annually
                    raiseDate = raiseDate.AddMonths(6)
                Case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Monthly
                    raiseDate = raiseDate.AddMonths(1)
                Case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Quarterly
                    raiseDate = raiseDate.AddMonths(3)
                Case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.GBS_4_Month_Visits
                    raiseDate = raiseDate.AddMonths(4)
            End Select
        Next

    End Sub

#End Region

    Private Sub cboInvoiceFrequencyID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboInvoiceFrequencyID.SelectedIndexChanged

    End Sub

    Private Sub cboContractType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboContractType.SelectedIndexChanged
        If Combo.GetSelectedItemValue(cboContractType) > 0 AndAlso CurrentContract.Exists = False Then
            If Not Number Is Nothing Then
                DB.Job.DeleteReservedOrderNumber(Number.JobNumber, Number.Prefix)
            End If
            Number = DB.Job.GetNextJobNumber(Combo.GetSelectedItemValue(cboContractType))
            If Number.JobNumber.ToString.Length < 3 Then
                Me.txtContractReference.Text = Number.Prefix & "00" & Number.JobNumber
            ElseIf Number.JobNumber.ToString.Length < 4 Then
                Me.txtContractReference.Text = Number.Prefix & "0" & Number.JobNumber
            Else
                Me.txtContractReference.Text = Number.Prefix & Number.JobNumber
            End If
            Me.txtContractReference.Text = Number.Prefix & Number.JobNumber
        End If
    End Sub

    Public Sub CloseForm()
        If Not Number Is Nothing And NumberUsed = False Then
            DB.Job.DeleteReservedOrderNumber(Number.JobNumber, Number.Prefix)
        End If
        Me.Dispose()
    End Sub

    Private Sub cboReasonID_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboReasonID.SelectedIndexChanged
        If Combo.GetSelectedItemValue(cboReasonID) > 0 Then
            If CurrentContract.CancelledDate <> Nothing Then
                dtpCancelledDate.Value = CurrentContract.CancelledDate
                dtpCancelledDate.Visible = True
                lblCancelledDate.Visible = True
            End If
        Else
            dtpCancelledDate.Visible = False
            lblCancelledDate.Visible = False
        End If
    End Sub

    Private Sub dgSites_Navigate(sender As Object, ne As NavigateEventArgs) Handles dgSites.Navigate

    End Sub

    Private Sub cboInvType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboInvType.SelectedIndexChanged
        If Combo.GetSelectedItemValue(cboInvType) = Entity.Sys.Enums.QuoteJobOfWorkTypes.Reciept Then
            lblPaidBy.Visible = True
            cboPaidBy.Visible = True
        Else
            lblPaidBy.Visible = False
            cboPaidBy.Visible = False
        End If
    End Sub

    Private Sub filterChange(sender As Object, e As EventArgs) Handles txtSearchFilter.TextChanged
        Dim filter As String = "Address1 LIKE '%" & Entity.Sys.Helper.RemoveSpecialCharacters(Me.txtSearchFilter.Text) & "%' OR Postcode LIKE '%" & Entity.Sys.Helper.RemoveSpecialCharacters(Me.txtSearchFilter.Text) & "%'"

        InvoiceAddresses.RowFilter = filter
    End Sub

End Class