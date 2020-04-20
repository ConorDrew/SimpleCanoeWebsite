Imports System.Security.Cryptography
Imports FSM.Entity
Imports FSM.Entity.Sys

Public Class UCContractWiz : Inherits FSM.UCBase : Implements IUserControl

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(Me.cboPaymentType, DynamicDataTables.ContractPaymentTypes, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboPeriod, DynamicDataTables.ContractPeriod, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboContractType, DB.Picklists.GetAll(Enums.PickListTypes.ContractTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboReasonID, DB.Picklists.GetAll(Enums.PickListTypes.CancellationReasons).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboInitialPaymentType, DynamicDataTables.ContractInitialPaymentTypes, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboPromotion, DB.Picklists.GetAll(Enums.PickListTypes.CoverPlanDiscounts).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        SetUpSoldByCombo()
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

    Friend WithEvents btnAmend As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents lblReference As System.Windows.Forms.Label
    Friend WithEvents lblMonthly As System.Windows.Forms.Label
    Friend WithEvents grpPromo As System.Windows.Forms.Panel
    Friend WithEvents btnPromoOK As System.Windows.Forms.Button
    Friend WithEvents cboPromotion As System.Windows.Forms.ComboBox
    Friend WithEvents lblPromotionalOffer As System.Windows.Forms.Label
    Friend WithEvents grpContractType As System.Windows.Forms.Panel
    Friend WithEvents lblcancel As System.Windows.Forms.Label
    Friend WithEvents lblCancelReason As System.Windows.Forms.Label
    Friend WithEvents btnTypeOk As System.Windows.Forms.Button
    Friend WithEvents lblConType As System.Windows.Forms.Label
    Friend WithEvents cboReasonID As System.Windows.Forms.ComboBox
    Friend WithEvents dtpCancelledDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboContractType As System.Windows.Forms.ComboBox
    Friend WithEvents grpAppliancesCovered As System.Windows.Forms.Panel
    Friend WithEvents btnMinusSecond As System.Windows.Forms.Button
    Friend WithEvents btnMinusMain As System.Windows.Forms.Button
    Friend WithEvents btnAddSecond As System.Windows.Forms.Button
    Friend WithEvents btnAddMain As System.Windows.Forms.Button
    Friend WithEvents LblSecondApps2 As System.Windows.Forms.Label
    Friend WithEvents txtSecondryCount As System.Windows.Forms.TextBox
    Friend WithEvents cboSecondryApps As System.Windows.Forms.ComboBox
    Friend WithEvents lblSecondOR As System.Windows.Forms.Label
    Friend WithEvents btnAppsOK As System.Windows.Forms.Button
    Friend WithEvents lblAdditionalApps As System.Windows.Forms.Label
    Friend WithEvents lblMainApps2 As System.Windows.Forms.Label
    Friend WithEvents txtMainAppCount As System.Windows.Forms.TextBox
    Friend WithEvents cboMainApps As System.Windows.Forms.ComboBox
    Friend WithEvents lblMainOR As System.Windows.Forms.Label
    Friend WithEvents lblMainApps As System.Windows.Forms.Label
    Friend WithEvents lblAppsCovered As System.Windows.Forms.Label
    Friend WithEvents grpContractPeriod As System.Windows.Forms.Panel
    Friend WithEvents btnPeriodOK As System.Windows.Forms.Button
    Friend WithEvents lblPeriod As System.Windows.Forms.Label
    Friend WithEvents cboPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents lblConPeriod As System.Windows.Forms.Label
    Friend WithEvents dtpContractStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblContractStartDate As System.Windows.Forms.Label
    Friend WithEvents grpAdditionalOptions As System.Windows.Forms.Panel
    Friend WithEvents btnAdditionalOK As System.Windows.Forms.Button
    Friend WithEvents lblAdditionalOptions As System.Windows.Forms.Label
    Friend WithEvents chkPlumbingDrainage As System.Windows.Forms.CheckBox
    Friend WithEvents chkWindowLockPest As System.Windows.Forms.CheckBox
    Friend WithEvents chkGasSupplyPipework As System.Windows.Forms.CheckBox
    Friend WithEvents grpPayers As System.Windows.Forms.Panel
    Friend WithEvents btnPaymentOK As System.Windows.Forms.Button
    Friend WithEvents lblPaymentMethod As System.Windows.Forms.Label
    Friend WithEvents cboPaymentType As System.Windows.Forms.ComboBox
    Friend WithEvents cboPAyer As System.Windows.Forms.ComboBox
    Friend WithEvents lblPayer As System.Windows.Forms.Label
    Friend WithEvents lblPayersDetail As System.Windows.Forms.Label
    Friend WithEvents grpAdditionalDetails As System.Windows.Forms.Panel
    Friend WithEvents txtNotesToEngineer As System.Windows.Forms.TextBox
    Friend WithEvents lblServiceNotes As System.Windows.Forms.Label
    Friend WithEvents txtPONumber As System.Windows.Forms.TextBox
    Friend WithEvents lblPO As System.Windows.Forms.Label
    Friend WithEvents lblAddDetails As System.Windows.Forms.Label
    Friend WithEvents DgMain As System.Windows.Forms.DataGridView
    Friend WithEvents dgSecondAssets As System.Windows.Forms.DataGridView
    Friend WithEvents lblMonthlyEst As System.Windows.Forms.Label
    Friend WithEvents lblContractRef As System.Windows.Forms.Label
    Friend WithEvents lblTotalEst As System.Windows.Forms.Label
    Friend WithEvents lblFollowedBy As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkLandlord As System.Windows.Forms.CheckBox
    Friend WithEvents chkCommercial As System.Windows.Forms.CheckBox
    Friend WithEvents cboContract As System.Windows.Forms.ComboBox
    Friend WithEvents cboInitialPaymentType As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblPaidBy As System.Windows.Forms.Label
    Friend WithEvents grpDD As System.Windows.Forms.Panel
    Friend WithEvents txtBankName As System.Windows.Forms.TextBox
    Friend WithEvents txtAccNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblBankName As System.Windows.Forms.Label
    Friend WithEvents lblAccNumber As System.Windows.Forms.Label
    Friend WithEvents txtSortCode As System.Windows.Forms.TextBox
    Friend WithEvents lblSortCode As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnRenew As System.Windows.Forms.Button
    Friend WithEvents txtAccName As System.Windows.Forms.TextBox
    Friend WithEvents lbl3 As System.Windows.Forms.Label
    Friend WithEvents lblRenewed As System.Windows.Forms.Label
    Friend WithEvents cboSoldBy As System.Windows.Forms.ComboBox
    Friend WithEvents lblsold As System.Windows.Forms.Label
    Friend WithEvents btnTransfer As System.Windows.Forms.Button
    Friend WithEvents lblchanging As System.Windows.Forms.Label
    Friend WithEvents lblIsLandlord As Label

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.

    Friend WithEvents grpContract As System.Windows.Forms.GroupBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpContract = New System.Windows.Forms.GroupBox()
        Me.btnTransfer = New System.Windows.Forms.Button()
        Me.lblsold = New System.Windows.Forms.Label()
        Me.btnRenew = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblFollowedBy = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMonthlyEst = New System.Windows.Forms.Label()
        Me.lblContractRef = New System.Windows.Forms.Label()
        Me.lblTotalEst = New System.Windows.Forms.Label()
        Me.grpPromo = New System.Windows.Forms.Panel()
        Me.btnPromoOK = New System.Windows.Forms.Button()
        Me.cboPromotion = New System.Windows.Forms.ComboBox()
        Me.lblPromotionalOffer = New System.Windows.Forms.Label()
        Me.grpContractType = New System.Windows.Forms.Panel()
        Me.cboContract = New System.Windows.Forms.ComboBox()
        Me.lblcancel = New System.Windows.Forms.Label()
        Me.lblCancelReason = New System.Windows.Forms.Label()
        Me.btnTypeOk = New System.Windows.Forms.Button()
        Me.lblConType = New System.Windows.Forms.Label()
        Me.cboReasonID = New System.Windows.Forms.ComboBox()
        Me.dtpCancelledDate = New System.Windows.Forms.DateTimePicker()
        Me.cboContractType = New System.Windows.Forms.ComboBox()
        Me.lblIsLandlord = New System.Windows.Forms.Label()
        Me.grpAppliancesCovered = New System.Windows.Forms.Panel()
        Me.dgSecondAssets = New System.Windows.Forms.DataGridView()
        Me.DgMain = New System.Windows.Forms.DataGridView()
        Me.btnMinusSecond = New System.Windows.Forms.Button()
        Me.btnMinusMain = New System.Windows.Forms.Button()
        Me.btnAddSecond = New System.Windows.Forms.Button()
        Me.btnAddMain = New System.Windows.Forms.Button()
        Me.LblSecondApps2 = New System.Windows.Forms.Label()
        Me.txtSecondryCount = New System.Windows.Forms.TextBox()
        Me.cboSecondryApps = New System.Windows.Forms.ComboBox()
        Me.lblSecondOR = New System.Windows.Forms.Label()
        Me.btnAppsOK = New System.Windows.Forms.Button()
        Me.lblAdditionalApps = New System.Windows.Forms.Label()
        Me.lblMainApps2 = New System.Windows.Forms.Label()
        Me.txtMainAppCount = New System.Windows.Forms.TextBox()
        Me.cboMainApps = New System.Windows.Forms.ComboBox()
        Me.lblMainOR = New System.Windows.Forms.Label()
        Me.lblMainApps = New System.Windows.Forms.Label()
        Me.lblAppsCovered = New System.Windows.Forms.Label()
        Me.lblReference = New System.Windows.Forms.Label()
        Me.lblMonthly = New System.Windows.Forms.Label()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.btnAmend = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboSoldBy = New System.Windows.Forms.ComboBox()
        Me.lblRenewed = New System.Windows.Forms.Label()
        Me.grpContractPeriod = New System.Windows.Forms.Panel()
        Me.btnPeriodOK = New System.Windows.Forms.Button()
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.cboPeriod = New System.Windows.Forms.ComboBox()
        Me.lblConPeriod = New System.Windows.Forms.Label()
        Me.dtpContractStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblContractStartDate = New System.Windows.Forms.Label()
        Me.grpAdditionalOptions = New System.Windows.Forms.Panel()
        Me.btnAdditionalOK = New System.Windows.Forms.Button()
        Me.lblAdditionalOptions = New System.Windows.Forms.Label()
        Me.chkPlumbingDrainage = New System.Windows.Forms.CheckBox()
        Me.chkWindowLockPest = New System.Windows.Forms.CheckBox()
        Me.chkGasSupplyPipework = New System.Windows.Forms.CheckBox()
        Me.grpPayers = New System.Windows.Forms.Panel()
        Me.grpDD = New System.Windows.Forms.Panel()
        Me.lblchanging = New System.Windows.Forms.Label()
        Me.txtAccName = New System.Windows.Forms.TextBox()
        Me.lbl3 = New System.Windows.Forms.Label()
        Me.txtBankName = New System.Windows.Forms.TextBox()
        Me.txtAccNumber = New System.Windows.Forms.TextBox()
        Me.lblBankName = New System.Windows.Forms.Label()
        Me.lblAccNumber = New System.Windows.Forms.Label()
        Me.txtSortCode = New System.Windows.Forms.TextBox()
        Me.lblSortCode = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblPaidBy = New System.Windows.Forms.Label()
        Me.cboInitialPaymentType = New System.Windows.Forms.ComboBox()
        Me.btnPaymentOK = New System.Windows.Forms.Button()
        Me.lblPaymentMethod = New System.Windows.Forms.Label()
        Me.cboPaymentType = New System.Windows.Forms.ComboBox()
        Me.cboPAyer = New System.Windows.Forms.ComboBox()
        Me.lblPayer = New System.Windows.Forms.Label()
        Me.lblPayersDetail = New System.Windows.Forms.Label()
        Me.grpAdditionalDetails = New System.Windows.Forms.Panel()
        Me.chkCommercial = New System.Windows.Forms.CheckBox()
        Me.chkLandlord = New System.Windows.Forms.CheckBox()
        Me.txtNotesToEngineer = New System.Windows.Forms.TextBox()
        Me.lblServiceNotes = New System.Windows.Forms.Label()
        Me.txtPONumber = New System.Windows.Forms.TextBox()
        Me.lblPO = New System.Windows.Forms.Label()
        Me.lblAddDetails = New System.Windows.Forms.Label()
        Me.grpContract.SuspendLayout()
        Me.grpPromo.SuspendLayout()
        Me.grpContractType.SuspendLayout()
        Me.grpAppliancesCovered.SuspendLayout()
        CType(Me.dgSecondAssets, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpContractPeriod.SuspendLayout()
        Me.grpAdditionalOptions.SuspendLayout()
        Me.grpPayers.SuspendLayout()
        Me.grpDD.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grpAdditionalDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpContract
        '
        Me.grpContract.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpContract.Controls.Add(Me.btnTransfer)
        Me.grpContract.Controls.Add(Me.lblsold)
        Me.grpContract.Controls.Add(Me.btnRenew)
        Me.grpContract.Controls.Add(Me.Label2)
        Me.grpContract.Controls.Add(Me.lblFollowedBy)
        Me.grpContract.Controls.Add(Me.Label1)
        Me.grpContract.Controls.Add(Me.lblMonthlyEst)
        Me.grpContract.Controls.Add(Me.lblContractRef)
        Me.grpContract.Controls.Add(Me.lblTotalEst)
        Me.grpContract.Controls.Add(Me.grpPromo)
        Me.grpContract.Controls.Add(Me.grpContractType)
        Me.grpContract.Controls.Add(Me.grpAppliancesCovered)
        Me.grpContract.Controls.Add(Me.lblReference)
        Me.grpContract.Controls.Add(Me.lblMonthly)
        Me.grpContract.Controls.Add(Me.BtnCancel)
        Me.grpContract.Controls.Add(Me.btnAmend)
        Me.grpContract.Controls.Add(Me.btnNew)
        Me.grpContract.Controls.Add(Me.Label7)
        Me.grpContract.Controls.Add(Me.cboSoldBy)
        Me.grpContract.Controls.Add(Me.lblRenewed)
        Me.grpContract.Location = New System.Drawing.Point(8, 8)
        Me.grpContract.Name = "grpContract"
        Me.grpContract.Size = New System.Drawing.Size(1080, 690)
        Me.grpContract.TabIndex = 0
        Me.grpContract.TabStop = False
        Me.grpContract.Text = "Contract Wizard"
        '
        'btnTransfer
        '
        Me.btnTransfer.Location = New System.Drawing.Point(593, 28)
        Me.btnTransfer.Name = "btnTransfer"
        Me.btnTransfer.Size = New System.Drawing.Size(146, 23)
        Me.btnTransfer.TabIndex = 155
        Me.btnTransfer.Text = "TRANSFER CONTRACT"
        Me.btnTransfer.UseVisualStyleBackColor = True
        Me.btnTransfer.Visible = False
        '
        'lblsold
        '
        Me.lblsold.Location = New System.Drawing.Point(667, 33)
        Me.lblsold.Name = "lblsold"
        Me.lblsold.Size = New System.Drawing.Size(79, 20)
        Me.lblsold.TabIndex = 154
        Me.lblsold.Text = "Sold By"
        Me.lblsold.Visible = False
        '
        'btnRenew
        '
        Me.btnRenew.Location = New System.Drawing.Point(748, 28)
        Me.btnRenew.Name = "btnRenew"
        Me.btnRenew.Size = New System.Drawing.Size(146, 23)
        Me.btnRenew.TabIndex = 151
        Me.btnRenew.Text = "RENEW CONTRACT"
        Me.btnRenew.UseVisualStyleBackColor = True
        Me.btnRenew.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(346, 625)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(191, 25)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "Annual Amount: "
        '
        'lblFollowedBy
        '
        Me.lblFollowedBy.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFollowedBy.Location = New System.Drawing.Point(242, 658)
        Me.lblFollowedBy.Name = "lblFollowedBy"
        Me.lblFollowedBy.Size = New System.Drawing.Size(97, 25)
        Me.lblFollowedBy.TabIndex = 150
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 658)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(230, 25)
        Me.Label1.TabIndex = 149
        Me.Label1.Text = "Followed By:"
        '
        'lblMonthlyEst
        '
        Me.lblMonthlyEst.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthlyEst.Location = New System.Drawing.Point(238, 625)
        Me.lblMonthlyEst.Name = "lblMonthlyEst"
        Me.lblMonthlyEst.Size = New System.Drawing.Size(108, 25)
        Me.lblMonthlyEst.TabIndex = 148
        '
        'lblContractRef
        '
        Me.lblContractRef.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContractRef.Location = New System.Drawing.Point(898, 625)
        Me.lblContractRef.Name = "lblContractRef"
        Me.lblContractRef.Size = New System.Drawing.Size(137, 25)
        Me.lblContractRef.TabIndex = 148
        '
        'lblTotalEst
        '
        Me.lblTotalEst.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalEst.Location = New System.Drawing.Point(538, 625)
        Me.lblTotalEst.Name = "lblTotalEst"
        Me.lblTotalEst.Size = New System.Drawing.Size(118, 25)
        Me.lblTotalEst.TabIndex = 147
        '
        'grpPromo
        '
        Me.grpPromo.Controls.Add(Me.btnPromoOK)
        Me.grpPromo.Controls.Add(Me.cboPromotion)
        Me.grpPromo.Controls.Add(Me.lblPromotionalOffer)
        Me.grpPromo.Location = New System.Drawing.Point(0, 377)
        Me.grpPromo.Name = "grpPromo"
        Me.grpPromo.Size = New System.Drawing.Size(1040, 36)
        Me.grpPromo.TabIndex = 95
        '
        'btnPromoOK
        '
        Me.btnPromoOK.Location = New System.Drawing.Point(998, 7)
        Me.btnPromoOK.Name = "btnPromoOK"
        Me.btnPromoOK.Size = New System.Drawing.Size(36, 23)
        Me.btnPromoOK.TabIndex = 79
        Me.btnPromoOK.Text = "OK"
        Me.btnPromoOK.UseVisualStyleBackColor = True
        '
        'cboPromotion
        '
        Me.cboPromotion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPromotion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPromotion.Location = New System.Drawing.Point(409, 8)
        Me.cboPromotion.Name = "cboPromotion"
        Me.cboPromotion.Size = New System.Drawing.Size(581, 21)
        Me.cboPromotion.TabIndex = 78
        Me.cboPromotion.Tag = "Contract.ContractStatusID"
        '
        'lblPromotionalOffer
        '
        Me.lblPromotionalOffer.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPromotionalOffer.Location = New System.Drawing.Point(9, 4)
        Me.lblPromotionalOffer.Name = "lblPromotionalOffer"
        Me.lblPromotionalOffer.Size = New System.Drawing.Size(345, 25)
        Me.lblPromotionalOffer.TabIndex = 77
        Me.lblPromotionalOffer.Text = "Promotional Offer / Discounts"
        '
        'grpContractType
        '
        Me.grpContractType.Controls.Add(Me.cboContract)
        Me.grpContractType.Controls.Add(Me.lblcancel)
        Me.grpContractType.Controls.Add(Me.lblCancelReason)
        Me.grpContractType.Controls.Add(Me.btnTypeOk)
        Me.grpContractType.Controls.Add(Me.lblConType)
        Me.grpContractType.Controls.Add(Me.cboReasonID)
        Me.grpContractType.Controls.Add(Me.dtpCancelledDate)
        Me.grpContractType.Controls.Add(Me.cboContractType)
        Me.grpContractType.Controls.Add(Me.lblIsLandlord)
        Me.grpContractType.Location = New System.Drawing.Point(1, 57)
        Me.grpContractType.Name = "grpContractType"
        Me.grpContractType.Size = New System.Drawing.Size(1039, 51)
        Me.grpContractType.TabIndex = 94
        '
        'cboContract
        '
        Me.cboContract.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContract.Location = New System.Drawing.Point(257, 14)
        Me.cboContract.Name = "cboContract"
        Me.cboContract.Size = New System.Drawing.Size(379, 21)
        Me.cboContract.TabIndex = 69
        Me.cboContract.Tag = ""
        '
        'lblcancel
        '
        Me.lblcancel.Location = New System.Drawing.Point(254, 17)
        Me.lblcancel.Name = "lblcancel"
        Me.lblcancel.Size = New System.Drawing.Size(79, 20)
        Me.lblcancel.TabIndex = 74
        Me.lblcancel.Text = "Cancel Date"
        '
        'lblCancelReason
        '
        Me.lblCancelReason.Location = New System.Drawing.Point(665, 20)
        Me.lblCancelReason.Name = "lblCancelReason"
        Me.lblCancelReason.Size = New System.Drawing.Size(50, 20)
        Me.lblCancelReason.TabIndex = 73
        Me.lblCancelReason.Text = "Reason"
        '
        'btnTypeOk
        '
        Me.btnTypeOk.Location = New System.Drawing.Point(996, 15)
        Me.btnTypeOk.Name = "btnTypeOk"
        Me.btnTypeOk.Size = New System.Drawing.Size(36, 23)
        Me.btnTypeOk.TabIndex = 72
        Me.btnTypeOk.Text = "OK"
        Me.btnTypeOk.UseVisualStyleBackColor = True
        '
        'lblConType
        '
        Me.lblConType.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConType.Location = New System.Drawing.Point(6, 12)
        Me.lblConType.Name = "lblConType"
        Me.lblConType.Size = New System.Drawing.Size(207, 25)
        Me.lblConType.TabIndex = 71
        Me.lblConType.Text = "Contract Type"
        '
        'cboReasonID
        '
        Me.cboReasonID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboReasonID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReasonID.Location = New System.Drawing.Point(775, 15)
        Me.cboReasonID.Name = "cboReasonID"
        Me.cboReasonID.Size = New System.Drawing.Size(215, 21)
        Me.cboReasonID.TabIndex = 70
        Me.cboReasonID.Tag = "Contract.ContractStatusID"
        '
        'dtpCancelledDate
        '
        Me.dtpCancelledDate.Location = New System.Drawing.Point(408, 14)
        Me.dtpCancelledDate.Name = "dtpCancelledDate"
        Me.dtpCancelledDate.Size = New System.Drawing.Size(229, 21)
        Me.dtpCancelledDate.TabIndex = 69
        '
        'cboContractType
        '
        Me.cboContractType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboContractType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContractType.Location = New System.Drawing.Point(644, 15)
        Me.cboContractType.Name = "cboContractType"
        Me.cboContractType.Size = New System.Drawing.Size(346, 21)
        Me.cboContractType.TabIndex = 68
        Me.cboContractType.Tag = ""
        '
        'lblIsLandlord
        '
        Me.lblIsLandlord.Location = New System.Drawing.Point(254, 8)
        Me.lblIsLandlord.Name = "lblIsLandlord"
        Me.lblIsLandlord.Size = New System.Drawing.Size(384, 36)
        Me.lblIsLandlord.TabIndex = 75
        Me.lblIsLandlord.Text = "Reason"
        Me.lblIsLandlord.Visible = False
        '
        'grpAppliancesCovered
        '
        Me.grpAppliancesCovered.Controls.Add(Me.dgSecondAssets)
        Me.grpAppliancesCovered.Controls.Add(Me.DgMain)
        Me.grpAppliancesCovered.Controls.Add(Me.btnMinusSecond)
        Me.grpAppliancesCovered.Controls.Add(Me.btnMinusMain)
        Me.grpAppliancesCovered.Controls.Add(Me.btnAddSecond)
        Me.grpAppliancesCovered.Controls.Add(Me.btnAddMain)
        Me.grpAppliancesCovered.Controls.Add(Me.LblSecondApps2)
        Me.grpAppliancesCovered.Controls.Add(Me.txtSecondryCount)
        Me.grpAppliancesCovered.Controls.Add(Me.cboSecondryApps)
        Me.grpAppliancesCovered.Controls.Add(Me.lblSecondOR)
        Me.grpAppliancesCovered.Controls.Add(Me.btnAppsOK)
        Me.grpAppliancesCovered.Controls.Add(Me.lblAdditionalApps)
        Me.grpAppliancesCovered.Controls.Add(Me.lblMainApps2)
        Me.grpAppliancesCovered.Controls.Add(Me.txtMainAppCount)
        Me.grpAppliancesCovered.Controls.Add(Me.cboMainApps)
        Me.grpAppliancesCovered.Controls.Add(Me.lblMainOR)
        Me.grpAppliancesCovered.Controls.Add(Me.lblMainApps)
        Me.grpAppliancesCovered.Controls.Add(Me.lblAppsCovered)
        Me.grpAppliancesCovered.Location = New System.Drawing.Point(0, 154)
        Me.grpAppliancesCovered.Name = "grpAppliancesCovered"
        Me.grpAppliancesCovered.Size = New System.Drawing.Size(1040, 183)
        Me.grpAppliancesCovered.TabIndex = 93
        '
        'dgSecondAssets
        '
        Me.dgSecondAssets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSecondAssets.Location = New System.Drawing.Point(645, 99)
        Me.dgSecondAssets.MultiSelect = False
        Me.dgSecondAssets.Name = "dgSecondAssets"
        Me.dgSecondAssets.ReadOnly = True
        Me.dgSecondAssets.RowHeadersVisible = False
        Me.dgSecondAssets.ShowCellErrors = False
        Me.dgSecondAssets.ShowEditingIcon = False
        Me.dgSecondAssets.ShowRowErrors = False
        Me.dgSecondAssets.Size = New System.Drawing.Size(293, 70)
        Me.dgSecondAssets.TabIndex = 146
        '
        'DgMain
        '
        Me.DgMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgMain.Location = New System.Drawing.Point(645, 13)
        Me.DgMain.MultiSelect = False
        Me.DgMain.Name = "DgMain"
        Me.DgMain.ReadOnly = True
        Me.DgMain.RowHeadersVisible = False
        Me.DgMain.ShowCellErrors = False
        Me.DgMain.ShowEditingIcon = False
        Me.DgMain.ShowRowErrors = False
        Me.DgMain.Size = New System.Drawing.Size(293, 70)
        Me.DgMain.TabIndex = 145
        '
        'btnMinusSecond
        '
        Me.btnMinusSecond.Location = New System.Drawing.Point(599, 146)
        Me.btnMinusSecond.Name = "btnMinusSecond"
        Me.btnMinusSecond.Size = New System.Drawing.Size(39, 23)
        Me.btnMinusSecond.TabIndex = 144
        Me.btnMinusSecond.Text = "-"
        Me.btnMinusSecond.UseVisualStyleBackColor = True
        '
        'btnMinusMain
        '
        Me.btnMinusMain.Location = New System.Drawing.Point(599, 60)
        Me.btnMinusMain.Name = "btnMinusMain"
        Me.btnMinusMain.Size = New System.Drawing.Size(39, 23)
        Me.btnMinusMain.TabIndex = 143
        Me.btnMinusMain.Text = "-"
        Me.btnMinusMain.UseVisualStyleBackColor = True
        '
        'btnAddSecond
        '
        Me.btnAddSecond.Location = New System.Drawing.Point(599, 122)
        Me.btnAddSecond.Name = "btnAddSecond"
        Me.btnAddSecond.Size = New System.Drawing.Size(39, 23)
        Me.btnAddSecond.TabIndex = 142
        Me.btnAddSecond.Text = "+"
        Me.btnAddSecond.UseVisualStyleBackColor = True
        '
        'btnAddMain
        '
        Me.btnAddMain.Location = New System.Drawing.Point(599, 36)
        Me.btnAddMain.Name = "btnAddMain"
        Me.btnAddMain.Size = New System.Drawing.Size(39, 23)
        Me.btnAddMain.TabIndex = 141
        Me.btnAddMain.Text = "+"
        Me.btnAddMain.UseVisualStyleBackColor = True
        '
        'LblSecondApps2
        '
        Me.LblSecondApps2.Location = New System.Drawing.Point(940, 123)
        Me.LblSecondApps2.Name = "LblSecondApps2"
        Me.LblSecondApps2.Size = New System.Drawing.Size(87, 20)
        Me.LblSecondApps2.TabIndex = 140
        Me.LblSecondApps2.Text = "APPLIANCES"
        '
        'txtSecondryCount
        '
        Me.txtSecondryCount.Location = New System.Drawing.Point(973, 96)
        Me.txtSecondryCount.MaxLength = 100
        Me.txtSecondryCount.Name = "txtSecondryCount"
        Me.txtSecondryCount.Size = New System.Drawing.Size(36, 21)
        Me.txtSecondryCount.TabIndex = 139
        Me.txtSecondryCount.Tag = ""
        '
        'cboSecondryApps
        '
        Me.cboSecondryApps.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboSecondryApps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSecondryApps.Location = New System.Drawing.Point(409, 99)
        Me.cboSecondryApps.Name = "cboSecondryApps"
        Me.cboSecondryApps.Size = New System.Drawing.Size(229, 21)
        Me.cboSecondryApps.TabIndex = 138
        Me.cboSecondryApps.Tag = ""
        '
        'lblSecondOR
        '
        Me.lblSecondOR.Location = New System.Drawing.Point(942, 99)
        Me.lblSecondOR.Name = "lblSecondOR"
        Me.lblSecondOR.Size = New System.Drawing.Size(25, 20)
        Me.lblSecondOR.TabIndex = 137
        Me.lblSecondOR.Text = "OR"
        '
        'btnAppsOK
        '
        Me.btnAppsOK.Location = New System.Drawing.Point(995, 146)
        Me.btnAppsOK.Name = "btnAppsOK"
        Me.btnAppsOK.Size = New System.Drawing.Size(39, 23)
        Me.btnAppsOK.TabIndex = 136
        Me.btnAppsOK.Text = "OK"
        Me.btnAppsOK.UseVisualStyleBackColor = True
        '
        'lblAdditionalApps
        '
        Me.lblAdditionalApps.Location = New System.Drawing.Point(254, 104)
        Me.lblAdditionalApps.Name = "lblAdditionalApps"
        Me.lblAdditionalApps.Size = New System.Drawing.Size(144, 20)
        Me.lblAdditionalApps.TabIndex = 134
        Me.lblAdditionalApps.Text = "Additional Appliance(s)"
        '
        'lblMainApps2
        '
        Me.lblMainApps2.Location = New System.Drawing.Point(940, 54)
        Me.lblMainApps2.Name = "lblMainApps2"
        Me.lblMainApps2.Size = New System.Drawing.Size(87, 20)
        Me.lblMainApps2.TabIndex = 133
        Me.lblMainApps2.Text = "APPLIANCES"
        '
        'txtMainAppCount
        '
        Me.txtMainAppCount.Location = New System.Drawing.Point(973, 27)
        Me.txtMainAppCount.MaxLength = 100
        Me.txtMainAppCount.Name = "txtMainAppCount"
        Me.txtMainAppCount.Size = New System.Drawing.Size(36, 21)
        Me.txtMainAppCount.TabIndex = 132
        Me.txtMainAppCount.Tag = ""
        '
        'cboMainApps
        '
        Me.cboMainApps.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMainApps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMainApps.Location = New System.Drawing.Point(409, 13)
        Me.cboMainApps.Name = "cboMainApps"
        Me.cboMainApps.Size = New System.Drawing.Size(229, 21)
        Me.cboMainApps.TabIndex = 131
        Me.cboMainApps.Tag = ""
        '
        'lblMainOR
        '
        Me.lblMainOR.Location = New System.Drawing.Point(942, 30)
        Me.lblMainOR.Name = "lblMainOR"
        Me.lblMainOR.Size = New System.Drawing.Size(25, 20)
        Me.lblMainOR.TabIndex = 130
        Me.lblMainOR.Text = "OR"
        '
        'lblMainApps
        '
        Me.lblMainApps.Location = New System.Drawing.Point(254, 18)
        Me.lblMainApps.Name = "lblMainApps"
        Me.lblMainApps.Size = New System.Drawing.Size(125, 20)
        Me.lblMainApps.TabIndex = 128
        Me.lblMainApps.Text = "Main Appliance(s)"
        '
        'lblAppsCovered
        '
        Me.lblAppsCovered.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAppsCovered.Location = New System.Drawing.Point(5, 13)
        Me.lblAppsCovered.Name = "lblAppsCovered"
        Me.lblAppsCovered.Size = New System.Drawing.Size(230, 25)
        Me.lblAppsCovered.TabIndex = 127
        Me.lblAppsCovered.Text = "Appliances Covered"
        '
        'lblReference
        '
        Me.lblReference.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReference.Location = New System.Drawing.Point(666, 625)
        Me.lblReference.Name = "lblReference"
        Me.lblReference.Size = New System.Drawing.Size(228, 25)
        Me.lblReference.TabIndex = 79
        Me.lblReference.Text = "Contract Reference: "
        '
        'lblMonthly
        '
        Me.lblMonthly.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthly.Location = New System.Drawing.Point(5, 625)
        Me.lblMonthly.Name = "lblMonthly"
        Me.lblMonthly.Size = New System.Drawing.Size(230, 25)
        Me.lblMonthly.TabIndex = 77
        Me.lblMonthly.Text = "First Month Amount"
        '
        'BtnCancel
        '
        Me.BtnCancel.Enabled = False
        Me.BtnCancel.Location = New System.Drawing.Point(902, 28)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(138, 23)
        Me.BtnCancel.TabIndex = 38
        Me.BtnCancel.Text = "CANCEL CURRENT"
        Me.BtnCancel.UseVisualStyleBackColor = True
        Me.BtnCancel.Visible = False
        '
        'btnAmend
        '
        Me.btnAmend.Location = New System.Drawing.Point(427, 28)
        Me.btnAmend.Name = "btnAmend"
        Me.btnAmend.Size = New System.Drawing.Size(146, 23)
        Me.btnAmend.TabIndex = 33
        Me.btnAmend.Text = "AMEND CURRENT"
        Me.btnAmend.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(271, 28)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(150, 23)
        Me.btnNew.TabIndex = 32
        Me.btnNew.Text = "ADD NEW"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(2, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(263, 25)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Add, Amend or Cancel?"
        '
        'cboSoldBy
        '
        Me.cboSoldBy.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboSoldBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSoldBy.Location = New System.Drawing.Point(776, 30)
        Me.cboSoldBy.Name = "cboSoldBy"
        Me.cboSoldBy.Size = New System.Drawing.Size(257, 21)
        Me.cboSoldBy.TabIndex = 153
        Me.cboSoldBy.Tag = ""
        Me.cboSoldBy.Visible = False
        '
        'lblRenewed
        '
        Me.lblRenewed.AutoSize = True
        Me.lblRenewed.ForeColor = System.Drawing.Color.DarkRed
        Me.lblRenewed.Location = New System.Drawing.Point(700, 33)
        Me.lblRenewed.Name = "lblRenewed"
        Me.lblRenewed.Size = New System.Drawing.Size(196, 13)
        Me.lblRenewed.TabIndex = 152
        Me.lblRenewed.Text = "This Contract Has been Renewed"
        Me.lblRenewed.Visible = False
        '
        'grpContractPeriod
        '
        Me.grpContractPeriod.Controls.Add(Me.btnPeriodOK)
        Me.grpContractPeriod.Controls.Add(Me.lblPeriod)
        Me.grpContractPeriod.Controls.Add(Me.cboPeriod)
        Me.grpContractPeriod.Controls.Add(Me.lblConPeriod)
        Me.grpContractPeriod.Controls.Add(Me.dtpContractStartDate)
        Me.grpContractPeriod.Controls.Add(Me.lblContractStartDate)
        Me.grpContractPeriod.Location = New System.Drawing.Point(8, 112)
        Me.grpContractPeriod.Name = "grpContractPeriod"
        Me.grpContractPeriod.Size = New System.Drawing.Size(1040, 48)
        Me.grpContractPeriod.TabIndex = 94
        '
        'btnPeriodOK
        '
        Me.btnPeriodOK.Location = New System.Drawing.Point(997, 11)
        Me.btnPeriodOK.Name = "btnPeriodOK"
        Me.btnPeriodOK.Size = New System.Drawing.Size(36, 23)
        Me.btnPeriodOK.TabIndex = 53
        Me.btnPeriodOK.Text = "OK"
        Me.btnPeriodOK.UseVisualStyleBackColor = True
        '
        'lblPeriod
        '
        Me.lblPeriod.Location = New System.Drawing.Point(667, 16)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(50, 20)
        Me.lblPeriod.TabIndex = 52
        Me.lblPeriod.Text = "Period"
        '
        'cboPeriod
        '
        Me.cboPeriod.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPeriod.Location = New System.Drawing.Point(776, 12)
        Me.cboPeriod.Name = "cboPeriod"
        Me.cboPeriod.Size = New System.Drawing.Size(214, 21)
        Me.cboPeriod.TabIndex = 51
        Me.cboPeriod.Tag = "Contract.ContractStatusID"
        '
        'lblConPeriod
        '
        Me.lblConPeriod.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConPeriod.Location = New System.Drawing.Point(5, 13)
        Me.lblConPeriod.Name = "lblConPeriod"
        Me.lblConPeriod.Size = New System.Drawing.Size(207, 25)
        Me.lblConPeriod.TabIndex = 50
        Me.lblConPeriod.Text = "Contract Period"
        '
        'dtpContractStartDate
        '
        Me.dtpContractStartDate.Location = New System.Drawing.Point(406, 10)
        Me.dtpContractStartDate.Name = "dtpContractStartDate"
        Me.dtpContractStartDate.Size = New System.Drawing.Size(230, 21)
        Me.dtpContractStartDate.TabIndex = 49
        Me.dtpContractStartDate.Tag = "Contract.ContractStartDate"
        '
        'lblContractStartDate
        '
        Me.lblContractStartDate.Location = New System.Drawing.Point(252, 13)
        Me.lblContractStartDate.Name = "lblContractStartDate"
        Me.lblContractStartDate.Size = New System.Drawing.Size(148, 20)
        Me.lblContractStartDate.TabIndex = 48
        Me.lblContractStartDate.Text = "Starting From"
        '
        'grpAdditionalOptions
        '
        Me.grpAdditionalOptions.Controls.Add(Me.btnAdditionalOK)
        Me.grpAdditionalOptions.Controls.Add(Me.lblAdditionalOptions)
        Me.grpAdditionalOptions.Controls.Add(Me.chkPlumbingDrainage)
        Me.grpAdditionalOptions.Controls.Add(Me.chkWindowLockPest)
        Me.grpAdditionalOptions.Controls.Add(Me.chkGasSupplyPipework)
        Me.grpAdditionalOptions.Location = New System.Drawing.Point(8, 348)
        Me.grpAdditionalOptions.Name = "grpAdditionalOptions"
        Me.grpAdditionalOptions.Size = New System.Drawing.Size(1040, 31)
        Me.grpAdditionalOptions.TabIndex = 95
        '
        'btnAdditionalOK
        '
        Me.btnAdditionalOK.Location = New System.Drawing.Point(996, 4)
        Me.btnAdditionalOK.Name = "btnAdditionalOK"
        Me.btnAdditionalOK.Size = New System.Drawing.Size(39, 23)
        Me.btnAdditionalOK.TabIndex = 68
        Me.btnAdditionalOK.Text = "OK"
        Me.btnAdditionalOK.UseVisualStyleBackColor = True
        '
        'lblAdditionalOptions
        '
        Me.lblAdditionalOptions.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdditionalOptions.Location = New System.Drawing.Point(8, 2)
        Me.lblAdditionalOptions.Name = "lblAdditionalOptions"
        Me.lblAdditionalOptions.Size = New System.Drawing.Size(230, 25)
        Me.lblAdditionalOptions.TabIndex = 67
        Me.lblAdditionalOptions.Text = "Additional Options"
        '
        'chkPlumbingDrainage
        '
        Me.chkPlumbingDrainage.AutoSize = True
        Me.chkPlumbingDrainage.Location = New System.Drawing.Point(487, 9)
        Me.chkPlumbingDrainage.Name = "chkPlumbingDrainage"
        Me.chkPlumbingDrainage.Size = New System.Drawing.Size(252, 17)
        Me.chkPlumbingDrainage.TabIndex = 66
        Me.chkPlumbingDrainage.Text = "Plumbing, drainage and electrical cover"
        Me.chkPlumbingDrainage.UseVisualStyleBackColor = True
        '
        'chkWindowLockPest
        '
        Me.chkWindowLockPest.AutoSize = True
        Me.chkWindowLockPest.Location = New System.Drawing.Point(257, 9)
        Me.chkWindowLockPest.Name = "chkWindowLockPest"
        Me.chkWindowLockPest.Size = New System.Drawing.Size(190, 17)
        Me.chkWindowLockPest.TabIndex = 65
        Me.chkWindowLockPest.Text = "Window, lock and pest cover"
        Me.chkWindowLockPest.UseVisualStyleBackColor = True
        '
        'chkGasSupplyPipework
        '
        Me.chkGasSupplyPipework.AutoSize = True
        Me.chkGasSupplyPipework.Location = New System.Drawing.Point(775, 9)
        Me.chkGasSupplyPipework.Name = "chkGasSupplyPipework"
        Me.chkGasSupplyPipework.Size = New System.Drawing.Size(147, 17)
        Me.chkGasSupplyPipework.TabIndex = 64
        Me.chkGasSupplyPipework.Text = "Gas Supply Pipework"
        Me.chkGasSupplyPipework.UseVisualStyleBackColor = True
        '
        'grpPayers
        '
        Me.grpPayers.Controls.Add(Me.grpDD)
        Me.grpPayers.Controls.Add(Me.Panel2)
        Me.grpPayers.Controls.Add(Me.Panel1)
        Me.grpPayers.Controls.Add(Me.cboInitialPaymentType)
        Me.grpPayers.Controls.Add(Me.btnPaymentOK)
        Me.grpPayers.Controls.Add(Me.lblPaymentMethod)
        Me.grpPayers.Controls.Add(Me.cboPaymentType)
        Me.grpPayers.Controls.Add(Me.cboPAyer)
        Me.grpPayers.Controls.Add(Me.lblPayer)
        Me.grpPayers.Controls.Add(Me.lblPayersDetail)
        Me.grpPayers.Location = New System.Drawing.Point(8, 430)
        Me.grpPayers.Name = "grpPayers"
        Me.grpPayers.Size = New System.Drawing.Size(1040, 69)
        Me.grpPayers.TabIndex = 96
        '
        'grpDD
        '
        Me.grpDD.Controls.Add(Me.lblchanging)
        Me.grpDD.Controls.Add(Me.txtAccName)
        Me.grpDD.Controls.Add(Me.lbl3)
        Me.grpDD.Controls.Add(Me.txtBankName)
        Me.grpDD.Controls.Add(Me.txtAccNumber)
        Me.grpDD.Controls.Add(Me.lblBankName)
        Me.grpDD.Controls.Add(Me.lblAccNumber)
        Me.grpDD.Controls.Add(Me.txtSortCode)
        Me.grpDD.Controls.Add(Me.lblSortCode)
        Me.grpDD.Location = New System.Drawing.Point(3, 31)
        Me.grpDD.Name = "grpDD"
        Me.grpDD.Size = New System.Drawing.Size(991, 38)
        Me.grpDD.TabIndex = 117
        Me.grpDD.Visible = False
        '
        'lblchanging
        '
        Me.lblchanging.ForeColor = System.Drawing.Color.Red
        Me.lblchanging.Location = New System.Drawing.Point(7, 5)
        Me.lblchanging.Name = "lblchanging"
        Me.lblchanging.Size = New System.Drawing.Size(236, 28)
        Me.lblchanging.TabIndex = 129
        Me.lblchanging.Text = "Changing D/D details will create a new D/D (even if original details are blank)"
        Me.lblchanging.Visible = False
        '
        'txtAccName
        '
        Me.txtAccName.Location = New System.Drawing.Point(340, 8)
        Me.txtAccName.Name = "txtAccName"
        Me.txtAccName.Size = New System.Drawing.Size(137, 21)
        Me.txtAccName.TabIndex = 1
        '
        'lbl3
        '
        Me.lbl3.Location = New System.Drawing.Point(249, 12)
        Me.lbl3.Name = "lbl3"
        Me.lbl3.Size = New System.Drawing.Size(89, 20)
        Me.lbl3.TabIndex = 110
        Me.lbl3.Text = "Account Name"
        '
        'txtBankName
        '
        Me.txtBankName.Location = New System.Drawing.Point(883, 8)
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.Size = New System.Drawing.Size(104, 21)
        Me.txtBankName.TabIndex = 4
        '
        'txtAccNumber
        '
        Me.txtAccNumber.Location = New System.Drawing.Point(726, 8)
        Me.txtAccNumber.Name = "txtAccNumber"
        Me.txtAccNumber.Size = New System.Drawing.Size(84, 21)
        Me.txtAccNumber.TabIndex = 3
        '
        'lblBankName
        '
        Me.lblBankName.Location = New System.Drawing.Point(811, 11)
        Me.lblBankName.Name = "lblBankName"
        Me.lblBankName.Size = New System.Drawing.Size(78, 20)
        Me.lblBankName.TabIndex = 107
        Me.lblBankName.Text = "Bank Name"
        '
        'lblAccNumber
        '
        Me.lblAccNumber.Location = New System.Drawing.Point(625, 11)
        Me.lblAccNumber.Name = "lblAccNumber"
        Me.lblAccNumber.Size = New System.Drawing.Size(108, 20)
        Me.lblAccNumber.TabIndex = 106
        Me.lblAccNumber.Text = "Account Number"
        '
        'txtSortCode
        '
        Me.txtSortCode.Location = New System.Drawing.Point(544, 8)
        Me.txtSortCode.Name = "txtSortCode"
        Me.txtSortCode.Size = New System.Drawing.Size(77, 21)
        Me.txtSortCode.TabIndex = 2
        '
        'lblSortCode
        '
        Me.lblSortCode.Location = New System.Drawing.Point(480, 12)
        Me.lblSortCode.Name = "lblSortCode"
        Me.lblSortCode.Size = New System.Drawing.Size(73, 20)
        Me.lblSortCode.TabIndex = 104
        Me.lblSortCode.Text = "Sort Code"
        '
        'Panel2
        '
        Me.Panel2.Location = New System.Drawing.Point(634, 33)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(357, 33)
        Me.Panel2.TabIndex = 117
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblPaidBy)
        Me.Panel1.Location = New System.Drawing.Point(645, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(110, 22)
        Me.Panel1.TabIndex = 116
        '
        'lblPaidBy
        '
        Me.lblPaidBy.Location = New System.Drawing.Point(6, 1)
        Me.lblPaidBy.Name = "lblPaidBy"
        Me.lblPaidBy.Size = New System.Drawing.Size(106, 20)
        Me.lblPaidBy.TabIndex = 115
        Me.lblPaidBy.Text = "Paid By:"
        '
        'cboInitialPaymentType
        '
        Me.cboInitialPaymentType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboInitialPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInitialPaymentType.Location = New System.Drawing.Point(773, 38)
        Me.cboInitialPaymentType.Name = "cboInitialPaymentType"
        Me.cboInitialPaymentType.Size = New System.Drawing.Size(216, 21)
        Me.cboInitialPaymentType.TabIndex = 113
        Me.cboInitialPaymentType.Tag = "Contract.ContractStatusID"
        '
        'btnPaymentOK
        '
        Me.btnPaymentOK.Location = New System.Drawing.Point(998, 37)
        Me.btnPaymentOK.Name = "btnPaymentOK"
        Me.btnPaymentOK.Size = New System.Drawing.Size(36, 23)
        Me.btnPaymentOK.TabIndex = 98
        Me.btnPaymentOK.Text = "OK"
        Me.btnPaymentOK.UseVisualStyleBackColor = True
        '
        'lblPaymentMethod
        '
        Me.lblPaymentMethod.Location = New System.Drawing.Point(722, 10)
        Me.lblPaymentMethod.Name = "lblPaymentMethod"
        Me.lblPaymentMethod.Size = New System.Drawing.Size(106, 20)
        Me.lblPaymentMethod.TabIndex = 93
        Me.lblPaymentMethod.Text = "Payment Method"
        '
        'cboPaymentType
        '
        Me.cboPaymentType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaymentType.Location = New System.Drawing.Point(834, 6)
        Me.cboPaymentType.Name = "cboPaymentType"
        Me.cboPaymentType.Size = New System.Drawing.Size(154, 21)
        Me.cboPaymentType.TabIndex = 92
        Me.cboPaymentType.Tag = "Contract.ContractStatusID"
        '
        'cboPAyer
        '
        Me.cboPAyer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPAyer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPAyer.Location = New System.Drawing.Point(407, 5)
        Me.cboPAyer.Name = "cboPAyer"
        Me.cboPAyer.Size = New System.Drawing.Size(309, 21)
        Me.cboPAyer.TabIndex = 91
        Me.cboPAyer.Tag = ""
        '
        'lblPayer
        '
        Me.lblPayer.Location = New System.Drawing.Point(252, 10)
        Me.lblPayer.Name = "lblPayer"
        Me.lblPayer.Size = New System.Drawing.Size(59, 20)
        Me.lblPayer.TabIndex = 90
        Me.lblPayer.Text = "Payer"
        '
        'lblPayersDetail
        '
        Me.lblPayersDetail.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPayersDetail.Location = New System.Drawing.Point(9, 5)
        Me.lblPayersDetail.Name = "lblPayersDetail"
        Me.lblPayersDetail.Size = New System.Drawing.Size(230, 25)
        Me.lblPayersDetail.TabIndex = 89
        Me.lblPayersDetail.Text = "Payers Detail"
        '
        'grpAdditionalDetails
        '
        Me.grpAdditionalDetails.Controls.Add(Me.chkCommercial)
        Me.grpAdditionalDetails.Controls.Add(Me.chkLandlord)
        Me.grpAdditionalDetails.Controls.Add(Me.txtNotesToEngineer)
        Me.grpAdditionalDetails.Controls.Add(Me.lblServiceNotes)
        Me.grpAdditionalDetails.Controls.Add(Me.txtPONumber)
        Me.grpAdditionalDetails.Controls.Add(Me.lblPO)
        Me.grpAdditionalDetails.Controls.Add(Me.lblAddDetails)
        Me.grpAdditionalDetails.Location = New System.Drawing.Point(8, 509)
        Me.grpAdditionalDetails.Name = "grpAdditionalDetails"
        Me.grpAdditionalDetails.Size = New System.Drawing.Size(1040, 87)
        Me.grpAdditionalDetails.TabIndex = 96
        '
        'chkCommercial
        '
        Me.chkCommercial.AutoSize = True
        Me.chkCommercial.Location = New System.Drawing.Point(487, 55)
        Me.chkCommercial.Name = "chkCommercial"
        Me.chkCommercial.Size = New System.Drawing.Size(123, 17)
        Me.chkCommercial.TabIndex = 8
        Me.chkCommercial.Text = "Commercial Plan"
        Me.chkCommercial.UseVisualStyleBackColor = True
        '
        'chkLandlord
        '
        Me.chkLandlord.AutoSize = True
        Me.chkLandlord.Location = New System.Drawing.Point(256, 55)
        Me.chkLandlord.Name = "chkLandlord"
        Me.chkLandlord.Size = New System.Drawing.Size(159, 17)
        Me.chkLandlord.TabIndex = 7
        Me.chkLandlord.Text = "Landlord Cert Required"
        Me.chkLandlord.UseVisualStyleBackColor = True
        '
        'txtNotesToEngineer
        '
        Me.txtNotesToEngineer.Location = New System.Drawing.Point(773, 8)
        Me.txtNotesToEngineer.Multiline = True
        Me.txtNotesToEngineer.Name = "txtNotesToEngineer"
        Me.txtNotesToEngineer.Size = New System.Drawing.Size(216, 71)
        Me.txtNotesToEngineer.TabIndex = 6
        '
        'lblServiceNotes
        '
        Me.lblServiceNotes.Location = New System.Drawing.Point(650, 8)
        Me.lblServiceNotes.Name = "lblServiceNotes"
        Me.lblServiceNotes.Size = New System.Drawing.Size(114, 20)
        Me.lblServiceNotes.TabIndex = 89
        Me.lblServiceNotes.Text = "Service Visit Notes"
        '
        'txtPONumber
        '
        Me.txtPONumber.Location = New System.Drawing.Point(408, 8)
        Me.txtPONumber.Name = "txtPONumber"
        Me.txtPONumber.Size = New System.Drawing.Size(229, 21)
        Me.txtPONumber.TabIndex = 5
        '
        'lblPO
        '
        Me.lblPO.Location = New System.Drawing.Point(254, 11)
        Me.lblPO.Name = "lblPO"
        Me.lblPO.Size = New System.Drawing.Size(159, 20)
        Me.lblPO.TabIndex = 86
        Me.lblPO.Text = "PO Number"
        '
        'lblAddDetails
        '
        Me.lblAddDetails.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddDetails.Location = New System.Drawing.Point(6, 8)
        Me.lblAddDetails.Name = "lblAddDetails"
        Me.lblAddDetails.Size = New System.Drawing.Size(230, 25)
        Me.lblAddDetails.TabIndex = 85
        Me.lblAddDetails.Text = "Additional Details"
        '
        'UCContractWiz
        '
        Me.Controls.Add(Me.grpAdditionalDetails)
        Me.Controls.Add(Me.grpPayers)
        Me.Controls.Add(Me.grpAdditionalOptions)
        Me.Controls.Add(Me.grpContractPeriod)
        Me.Controls.Add(Me.grpContract)
        Me.Name = "UCContractWiz"
        Me.Size = New System.Drawing.Size(1095, 701)
        Me.grpContract.ResumeLayout(False)
        Me.grpContract.PerformLayout()
        Me.grpPromo.ResumeLayout(False)
        Me.grpContractType.ResumeLayout(False)
        Me.grpAppliancesCovered.ResumeLayout(False)
        Me.grpAppliancesCovered.PerformLayout()
        CType(Me.dgSecondAssets, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpContractPeriod.ResumeLayout(False)
        Me.grpAdditionalOptions.ResumeLayout(False)
        Me.grpAdditionalOptions.PerformLayout()
        Me.grpPayers.ResumeLayout(False)
        Me.grpDD.ResumeLayout(False)
        Me.grpDD.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.grpAdditionalDetails.ResumeLayout(False)
        Me.grpAdditionalDetails.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentContract
        End Get
    End Property

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

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
            End If

            If _currentContract.Exists Then
                dtpContractStartDate.Enabled = False
            Else
                lblTotalEst.Text = Format(CDbl(0.0), "C")
            End If

            If CurrentContractSite Is Nothing Then
                CurrentContractSite = New Entity.ContractOriginalSites.ContractOriginalSite
                CurrentContractSite.Exists = False
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
            Sites = DB.ContractOriginalSite.GetAll_ContractID(CurrentContract.ContractID, IDToLinkTo)
        End Set
    End Property

    Private _Sites As DataView

    Public Property Sites() As DataView
        Get
            Return _Sites
        End Get
        Set(ByVal Value As DataView)
            _Sites = Value
            _Sites.Table.TableName = Enums.TableNames.tblContractSite.ToString
            _Sites.AllowNew = False
            _Sites.AllowEdit = False
            _Sites.AllowDelete = False

            SiteID = SiteID
        End Set
    End Property

    Private _MainDataView As DataView = Nothing

    Public Property MainDataView() As DataView
        Get
            Return _MainDataView
        End Get
        Set(ByVal Value As DataView)
            _MainDataView = Value
            _MainDataView.Table.TableName = "MainApps"
            _MainDataView.AllowNew = False
            _MainDataView.AllowEdit = True
            _MainDataView.AllowDelete = False
            Me.DgMain.DataSource = MainDataView
        End Set
    End Property

    Private ReadOnly Property SelectedMainDataRow() As DataGridViewRow
        Get
            If (Not Me.DgMain.CurrentRow Is Nothing) AndAlso Not Me.DgMain.CurrentRow.Index = -1 Then
                Return Me.DgMain.CurrentRow
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _SecondAppliances As DataView

    Private Property SecondAppliances() As DataView
        Get
            Return _SecondAppliances
        End Get
        Set(ByVal Value As DataView)
            _SecondAppliances = Value
            _SecondAppliances.AllowDelete = False
            _SecondAppliances.AllowEdit = False
            _SecondAppliances.AllowNew = False
            _SecondAppliances.Table.TableName = Enums.TableNames.tblInvoiceAddress.ToString

            dgSecondAssets.DataSource = SecondAppliances
        End Set
    End Property

    Private ReadOnly Property SelectedSecondAppDataRow() As DataGridViewRow
        Get
            If (Not Me.dgSecondAssets.CurrentRow Is Nothing) AndAlso Not Me.dgSecondAssets.CurrentRow.Index = -1 Then
                Return Me.dgSecondAssets.CurrentRow
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
            If DB.ContractOriginal.GetAll_ForSite_Active(SiteID).Table.Rows.Count = 0 Then
                btnAmend.Enabled = False
            Else
                btnAmend.Enabled = True
            End If

            If SiteID > 0 And IDToLinkTo = Enums.Customer.Domestic Then
                _Sites.RowFilter = "SiteID=" & SiteID
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

    Private _Price As Double = 0.0

    Public Property Price() As Double
        Get
            Return _Price
        End Get
        Set(ByVal Value As Double)
            _Price = Value
        End Set
    End Property

    Private _jobNumber As JobNumber = Nothing

    Public Property Number() As JobNumber
        Get
            Return _jobNumber
        End Get
        Set(ByVal Value As JobNumber)
            _jobNumber = Value
        End Set
    End Property

    Private _currentContractSite As Entity.ContractOriginalSites.ContractOriginalSite

    Public Property CurrentContractSite() As Entity.ContractOriginalSites.ContractOriginalSite
        Get
            Return _currentContractSite
        End Get
        Set(ByVal Value As Entity.ContractOriginalSites.ContractOriginalSite)
            _currentContractSite = Value
            If _currentContractSite Is Nothing Then
                _currentContractSite = New Entity.ContractOriginalSites.ContractOriginalSite
                _currentContractSite.Exists = False
            End If

        End Set

    End Property

    Dim p As String = "Gasway100"
    Dim newdate As Date
    Dim c As Control()
    Dim b As Button
    Dim discount As Double = 0.0
    Dim needDD As Boolean = True
    Dim EffDate As Date = Date.MinValue
    Dim OldEndDate As Date
    Dim NewSiteID As Integer = 0
    Dim NewPayer As String = ""
    Dim ddsort As String = ""
    Dim ddAcc As String = ""
    Dim Offset As Boolean = True
    Dim ManualApp As String = ""
    Dim SecondApp As String = ""
    Dim Jn As JobNumber
    Dim PreviousRef As String = ""
    Dim previousFirst As Double = 0
    Dim previousSecond As Double = 0
    Dim previousTotal As Double = 0
    Dim OverridePrice As Boolean = False

    Public Sub SetupMainDataGrid()
        DgMain.Columns(0).Visible = False
        DgMain.ColumnHeadersVisible = False
        DgMain.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DgMain.AllowUserToAddRows = False
    End Sub

    Public Sub SetupSecondryDataGrid()
        dgSecondAssets.Columns(0).Visible = False
        dgSecondAssets.ColumnHeadersVisible = False
        dgSecondAssets.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgSecondAssets.AllowUserToAddRows = False
    End Sub

    Private Sub UCContract_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)

        grpAppliancesCovered.Visible = False
        grpContractType.Visible = False
        grpContractPeriod.Visible = False
        grpAdditionalDetails.Visible = False
        grpAdditionalOptions.Visible = False
        grpPayers.Visible = False
        grpPromo.Visible = False
    End Sub

    Private Sub cboContractType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboContractType.SelectedIndexChanged
        If Combo.GetSelectedItemValue(cboContractType) > 0 Then
            If CurrentContractSite.Exists Then

                Me.lblContractRef.Text = CurrentContract.ContractReference
                If (b.Text = "Amend Contract" Or b.Text = "Renew Contract") And CurrentContract.ContractTypeID <> Combo.GetSelectedItemValue(cboContractType) Then
                    OverridePrice = False
                    If Not Number Is Nothing Then
                        DB.Job.DeleteReservedOrderNumber(Number.JobNumber, Number.Prefix)
                    End If
                    Number = DB.Job.GetNextJobNumber(Combo.GetSelectedItemValue(cboContractType))
                    If Number.JobNumber.ToString.Length < 3 Then
                        Me.lblContractRef.Text = Number.Prefix & "00" & Number.JobNumber
                    ElseIf Number.JobNumber.ToString.Length < 4 Then
                        Me.lblContractRef.Text = Number.Prefix & "0" & Number.JobNumber
                    Else
                        Me.lblContractRef.Text = Number.Prefix & Number.JobNumber
                    End If
                End If
            Else

                If Not Number Is Nothing Then
                    DB.Job.DeleteReservedOrderNumber(Number.JobNumber, Number.Prefix)
                End If
                Number = DB.Job.GetNextJobNumber(Combo.GetSelectedItemValue(cboContractType))
                If Number.JobNumber.ToString.Length < 3 Then
                    Me.lblContractRef.Text = Number.Prefix & "00" & Number.JobNumber
                ElseIf Number.JobNumber.ToString.Length < 4 Then
                    Me.lblContractRef.Text = Number.Prefix & "0" & Number.JobNumber
                Else
                    Me.lblContractRef.Text = Number.Prefix & Number.JobNumber
                End If

            End If

            If Not CurrentContract.Exists Then
                If Combo.GetSelectedItemDescription(cboContractType) = "Totally Assured" Then
                    Combo.SetUpCombo(Me.cboPeriod, DynamicDataTables.ContractPeriod,
                                     "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select)
                Else
                    cboPeriod.Items.Clear()
                    cboPeriod.Items.Add(New Combo("-- Please Select --", "0"))
                    cboPeriod.Items.Add(New Combo("1 Year", "1"))
                    cboPeriod.DisplayMember = "Description"
                    cboPeriod.ValueMember = "Value"
                    Combo.SetSelectedComboItem_By_Value(cboPeriod, "0")
                    If b.Text = "Amend Contract" Or b.Text = "Renew Contract" Then
                        Combo.SetSelectedComboItem_By_Value(cboPeriod, "1")
                    End If

                End If
            End If

            If Combo.GetSelectedItemValue(cboPeriod) > 1 And (chkGasSupplyPipework.Checked Or chkPlumbingDrainage.Checked Or chkWindowLockPest.Checked) Then
                ShowMessage("Additional Options can not be added to a plan which runs for more than one year.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                chkWindowLockPest.Checked = False
                chkPlumbingDrainage.Checked = False
                chkGasSupplyPipework.Checked = False
                Exit Sub
            Else
                DoTotals()
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        btnTypeOk.Visible = True
        Dim dt As DataTable = DB.ContractOriginal.GetAll_ForSite_Active(SiteID).Table
        If dt.Rows.Count > 0 Then
            If ShowMessage("Contracts already exist for this site are you sure you wish to add a new contract?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
        End If

        c = ParentForm.Controls.Find("btnSave", True)
        b = c(0)
        b.Text = "Create Contract"
        b.Visible = False

        cboSoldBy.SelectedValue = loggedInUser.UserID
        lblsold.Visible = True
        cboSoldBy.Visible = True
        btnTransfer.Visible = False
        lblIsLandlord.Visible = True
        lblIsLandlord.Text = "Is this a Landlords property? - Please attached L/L before continuing"

        cboContract.Visible = False

        grpAppliancesCovered.Visible = False

        grpContractPeriod.Visible = False
        grpAdditionalDetails.Visible = False
        grpAdditionalOptions.Visible = False
        grpPayers.Visible = False
        grpPromo.Visible = False

        Combo.SetUpCombo(Me.cboMainApps, DB.Asset.Asset_GetForSite(SiteID).Table, "AssetID", "Product", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSecondryApps, DB.Asset.Asset_GetForSite(SiteID).Table, "AssetID", "Product", Enums.ComboValues.Please_Select)

        PayerDrop()

        MainDataView = DB.ContractOriginal.GetAssetsForContract(0, True)
        SecondAppliances = DB.ContractOriginal.GetAssetsForContract(0, False)

        SetupMainDataGrid()
        SetupSecondryDataGrid()

        grpContractType.Visible = True
        lblcancel.Visible = False
        lblCancelReason.Visible = False
        dtpCancelledDate.Visible = False
        cboReasonID.Visible = False
        needDD = True
        lblchanging.Visible = False
    End Sub

    Private Sub btnAmend_Click(sender As Object, e As EventArgs) Handles btnAmend.Click
        lblsold.Visible = False
        cboSoldBy.Visible = False

        c = ParentForm.Controls.Find("btnSave", True)
        b = c(0)
        b.Text = "Amend Contract"
        b.Enabled = False

        grpContractType.Visible = True
        cboContract.Visible = True
        lblcancel.Visible = False
        lblCancelReason.Visible = False
        dtpCancelledDate.Visible = False
        cboReasonID.Visible = False
        Me.cboPaymentType.Enabled = False
        lblIsLandlord.Visible = False

        ContractDrop()

        Combo.SetUpCombo(Me.cboMainApps, DB.Asset.Asset_GetForSite(SiteID).Table, "AssetID", "Product", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboSecondryApps, DB.Asset.Asset_GetForSite(SiteID).Table, "AssetID", "Product", Enums.ComboValues.Please_Select)

        lblchanging.Visible = True

        needDD = False
        b.Enabled = False
    End Sub

    Private Sub btnTransfer_Click(sender As Object, e As EventArgs) Handles btnTransfer.Click
        Dim f As New DLGFindSite()

        f.TableToSearch = Enums.TableNames.tblSite
        f.AddressID = CurrentContract.InvoiceAddressID
        f.InvoiceFrequencyID = CurrentContract.InvoiceFrequencyID
        f.ShowDialog()

        NewSiteID = f.ID
        NewPayer = f.SecondID ' amigination
        EffDate = f.EffDate

        If CurrentContract.InvoiceFrequencyID = Enums.InvoiceFrequency.Bi_Annually And
            (NewPayer.Split("`")(0) <> CurrentContract.InvoiceAddressID Or
            NewPayer.Split("`")(1) <> CurrentContract.InvoiceAddressTypeID) Then
            ' D/D details are changing
            txtAccName.Text = ""
            txtAccNumber.Text = ""
            txtBankName.Text = ""
            txtSortCode.Text = ""
            grpAdditionalDetails.Visible = False
            b.Text = "Transfer Contract"
            b.Enabled = False
        Else
            grpAdditionalDetails.Visible = False
            b.Text = "Transfer Contract"
            b.Enabled = False
        End If

        ''''' redo payer dropdown
        Dim dt As DataTable = DB.InvoiceAddress.InvoiceAddress_Get_SiteID(NewSiteID).Table
        cboPAyer.Items.Clear()

        For Each dr As DataRow In dt.Rows
            cboPAyer.Items.Add(New Combo(dr("Address1") & "," & dr("Address2") & "," & dr("Postcode"), dr("AddressID") & "`" & dr("AddressTypeID")))
        Next
        cboPAyer.Items.Add(New Combo("-- Please Select --", 0))

        cboPAyer.DisplayMember = "Description"
        cboPAyer.ValueMember = "Value"

        Combo.SetSelectedComboItem_By_Value(cboPAyer, NewPayer)
        lblchanging.Visible = True
    End Sub

    Private Sub btnAddMain_Click(sender As Object, e As EventArgs) Handles btnAddMain.Click
        If Combo.GetSelectedItemValue(cboMainApps) > 0 Then
            MainDataView.AllowNew = True
            Dim newrow As DataRowView = MainDataView.AddNew
            newrow("AssetID") = Combo.GetSelectedItemValue(cboMainApps)
            newrow("Product") = Combo.GetSelectedItemDescription(cboMainApps)
            newrow.EndEdit()

            DgMain.DataSource = MainDataView
        End If
        txtMainAppCount.Text = DgMain.Rows.Count
        DoTotals()
    End Sub

    Private Sub btnAddSecond_Click(sender As Object, e As EventArgs) Handles btnAddSecond.Click
        If Combo.GetSelectedItemValue(cboSecondryApps) > 0 Then
            SecondAppliances.AllowNew = True
            Dim newrow As DataRowView = SecondAppliances.AddNew
            newrow("AssetID") = Combo.GetSelectedItemValue(cboSecondryApps)
            newrow("Product") = Combo.GetSelectedItemDescription(cboSecondryApps)
            newrow.EndEdit()

            dgSecondAssets.DataSource = SecondAppliances
        End If
        txtSecondryCount.Text = dgSecondAssets.Rows.Count
        DoTotals()
    End Sub

    Private Sub btnTypeOk_Click_1(sender As Object, e As EventArgs) Handles btnTypeOk.Click
        If Combo.GetSelectedItemValue(cboContractType) > 0 Then
            grpContractPeriod.Visible = True
            DoTotals()
        Else
            ShowMessage("You Must Select a contract", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnPeriodOK_Click_1(sender As Object, e As EventArgs) Handles btnPeriodOK.Click
        If Combo.GetSelectedItemValue(cboPeriod) > 0 Then
            grpAppliancesCovered.Visible = True
            DoTotals()
        Else
            ShowMessage("You Must Select a Period", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnAppsOK_Click(sender As Object, e As EventArgs) Handles btnAppsOK.Click
        If DgMain.RowCount = 0 And CBT(txtMainAppCount.Text) > 0 Then
            Dim f As New FRMManualApp
            f.lblMsg.Text = "As you haven't identified the main applaince, please provide one below."
            f.ShowDialog()
            ManualApp = Combo.GetSelectedItemDescription(f.cboInitialPaymentType)
        End If
        If dgSecondAssets.RowCount = 0 And CBT(txtSecondryCount.Text) > 0 Then
            Dim f As New FRMManualApp
            f.lblMsg.Text = "As you haven't identified the second applaince, please provide one below."
            f.ShowDialog()
            SecondApp = Combo.GetSelectedItemDescription(f.cboInitialPaymentType)
        End If
        If CBT(txtMainAppCount.Text) + CBT(txtSecondryCount.Text) > 0 Then
            grpAdditionalOptions.Visible = True
            DoTotals()
        Else
            ShowMessage("You Must add at least one appliance", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnPromoOK_Click(sender As Object, e As EventArgs) Handles btnPromoOK.Click
        grpPayers.Visible = True
        DoTotals()
        ShowMessage("Please be aware that all levels of cover exclude damage caused by scale, shale and sludge, plus the removal of such debris. " &
                    vbNewLine & "The repair or replacement of flues or their components is also excluded, as is pipework located inside the fabric of the building." &
                    vbNewLine & "All cover plans are twelve month contracts, and cancellation during the cover period may not entitle you to a refund." &
                    vbNewLine & "During our first visit under cover, if we find that the appliance is in a seriously degraded state, then we may cancel your plan and return any policy payments made to that point",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub btnPaymentOK_Click(sender As Object, e As EventArgs) Handles btnPaymentOK.Click
        Dim paymentType As Integer = Combo.GetSelectedItemValue(cboPaymentType)
        If paymentType = Enums.ContractPaymentType.Direct_Debit And
            txtAccNumber.Text = ddAcc And b.Text <> "Create Contract" Then ' ddAcc  is used in amending to record original data if there is none it will still spot the change
            grpAdditionalDetails.Visible = True
            DoTotals()
            If lblTotalEst.Text = 0 And discount <> 100 Then
                Dim f As New FRMNewPrice
                f.ShowDialog()
                If IsNumeric(f.txtPrice.Text) AndAlso CDbl(f.txtPrice.Text) > 0 Then
                    lblTotalEst.Text = Format(CDbl(f.txtPrice.Text), "C")
                    lblMonthlyEst.Text = Format(CDbl(lblTotalEst.Text) / 12, "C")
                    lblFollowedBy.Text = Format(CDbl(lblTotalEst.Text) / 12, "C")
                    OverridePrice = True
                End If
            End If
            b.Visible = True
            b.Enabled = True
        Else
            discount = DB.Picklists.Get_One_As_Object(Combo.GetSelectedItemValue(cboPromotion))?.PercentageRate
            Dim contractType As Integer = Combo.GetSelectedItemValue(cboContractType)
            If contractType = Enums.ContractTypes.EmployeeFree Or contractType = Enums.ContractTypes.FamilyFree Then
                discount = 100
            End If
            If lblTotalEst.Text = 0 And discount <> 100 Then
                Dim f As New FRMNewPrice
                f.ShowDialog()
                If IsNumeric(f.txtPrice.Text) AndAlso CDbl(f.txtPrice.Text) > 0 Then
                    lblTotalEst.Text = Format(CDbl(f.txtPrice.Text), "C")
                    lblMonthlyEst.Text = Format(CDbl(lblTotalEst.Text) / 12, "C")
                    lblFollowedBy.Text = Format(CDbl(lblTotalEst.Text) / 12, "C")
                    OverridePrice = True
                End If
            End If

            If lblTotalEst.Text > 0 Then
                If Combo.GetSelectedItemValue(cboPAyer) <> "0" And paymentType > 0 Then

                    If ((paymentType = Enums.ContractPaymentType.Direct_Debit And
                        (txtBankName.Text.Length > 0 And txtAccName.Text.Length > 2 And txtAccNumber.Text.Length < 9 And txtAccNumber.Text.Length > 2 And txtSortCode.Text.Length > 5 And txtSortCode.Text.Length < 7)) Or
                        paymentType <> Enums.ContractPaymentType.Direct_Debit) Then

                        If b.Text = "Create Contract" Or b.Text = "Renew Contract" Then
                            Dim f As New FRMGenDropBox
                            Select Case Combo.GetSelectedItemValue(cboPaymentType)
                                Case Enums.ContractPaymentType.Annual
                                    f.lblTop.Text = "You Must Take Full Payment Now In order to set up this Contract."

                                Case Else
                                    ShowMessage(
                                        "All Direct Debits are protected by a guarantee. Would you like me to read the guarantee to you, or you can read it in the confirmation letter? " & vbNewLine & vbNewLine &
                                        "This guarantee is offered by all banks and building societies that take part in the Direct Debit scheme.If the amounts to be paid or the payment dates change, " &
                                        "Gasway Services Ltd will notify you 10 working days in advance of your account being debited Or as otherwise agreed. " &
                                        "If an error Is made by Gasway Services Ltd Or your bank Or building society, you are guaranteed a full And immediate refund from your branch of the amount paid. " &
                                        "You can cancel a Direct Debit at any time by writing to your bank Or building society.  Please also send a copy of your letter to us.",
                                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                                    f.lblTop.Text = "You Must Take the first Payment Now, In order to set up this Contract."
                            End Select
                            f.ShowDialog()
                            Combo.SetSelectedComboItem_By_Value(cboInitialPaymentType, Combo.GetSelectedItemValue(f.cbo1))
                            If Combo.GetSelectedItemValue(cboInitialPaymentType) = "0" Then
                                Exit Sub
                            Else
                                ShowAdditionalDetails()
                            End If

                        End If
                        ShowAdditionalDetails()
                    Else
                        ShowMessage("You must enter Bank name, Account name, sortcode (6 Digits) And account code (8 digits) correctly for Direct Debit",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                Else
                    ShowMessage("You must select a payer And payment method", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            ElseIf discount = 100 Then
                ShowAdditionalDetails()
            Else
                ShowMessage("You cannot create a contract of Zero Value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub ShowAdditionalDetails()
        grpAdditionalDetails.Visible = True
        If Combo.GetSelectedItemValue(cboContractType) <> Enums.ContractTypes.PreventativeMaintenance Then
            DoTotals()
        End If
        b.Visible = True
        b.Enabled = True
        dtpContractStartDate.Enabled = False
    End Sub

    Private Sub cboPaymentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPaymentType.SelectedIndexChanged
        Dim selectedPaymentType As Integer = Combo.GetSelectedItemValue(cboPaymentType)

        If b?.Text = "Create Contract" Then
            b.Visible = False
            grpAdditionalDetails.Visible = False
        End If

        If selectedPaymentType = Enums.ContractPaymentType.Annual Or selectedPaymentType = 0 Then
            'annual
            grpDD.Visible = False
        Else
            'DirectDebit
            grpDD.Visible = True
        End If
    End Sub

    Private Sub btnAdditionalOK_Click(sender As Object, e As EventArgs) Handles btnAdditionalOK.Click
        If Combo.GetSelectedItemValue(cboPeriod) > 1 And (chkGasSupplyPipework.Checked Or chkPlumbingDrainage.Checked Or chkWindowLockPest.Checked) Then
            ShowMessage("Additional Options can Not be added to a plan which runs for more than one year.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            grpPromo.Visible = True
            DoTotals()
        End If
    End Sub

    Private Sub btnMinusMain_Click(sender As Object, e As EventArgs) Handles btnMinusMain.Click
        If Not DgMain.CurrentRow Is Nothing Then
            MainDataView.AllowDelete = True
            MainDataView.Table.Rows.RemoveAt(SelectedMainDataRow.Index)

            txtMainAppCount.Text = DgMain.Rows.Count
            DoTotals()
        End If
    End Sub

    Private Sub btnMinusSecond_Click(sender As Object, e As EventArgs) Handles btnMinusSecond.Click
        If Not dgSecondAssets.CurrentRow Is Nothing Then
            SecondAppliances.AllowDelete = True
            SecondAppliances.Table.Rows.RemoveAt(SelectedSecondAppDataRow.Index)
            txtSecondryCount.Text = dgSecondAssets.Rows.Count
            DoTotals()
        End If
    End Sub

    Private Sub cboPeriod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPeriod.SelectedIndexChanged
        If Combo.GetSelectedItemValue(cboPeriod) > 0 Then
            If Not b Is Nothing Then
                b.Enabled = True
            End If
            DoTotals()
        Else
            If Not b Is Nothing Then
                b.Enabled = False
            End If
        End If
    End Sub

    Private Sub cboPromotion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPromotion.SelectedIndexChanged
        If Combo.GetSelectedItemValue(cboPromotion) > 0 Then
            discount = DB.Picklists.Get_One_As_Object(Combo.GetSelectedItemValue(cboPromotion)).PercentageRate
        Else
            Combo.SetSelectedComboItem_By_Value(cboPromotion, "0")
            discount = 0
        End If

        DoTotals()
    End Sub

    Private Sub cboContract_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboContract.SelectedIndexChanged
        If Combo.GetSelectedItemValue(cboContract) <> "0" Then
            CurrentContract = DB.ContractOriginal.Get(Combo.GetSelectedItemValue(cboContract).Split("`")(0))
            CurrentContractSite = DB.ContractOriginalSite.Get(Combo.GetSelectedItemValue(cboContract).Split("`")(1))

            If b.Text = "Amend Contract" Then
                lblContractStartDate.Text = "Change Effective from"
                Combo.SetSelectedComboItem_By_Value(cboPeriod, "1")
                cboPeriod.Enabled = False
                btnPeriodOK.Enabled = True
            Else
                lblContractStartDate.Text = "Starting From"
                lblPeriod.Visible = True
                cboPeriod.Visible = True
            End If

            grpContractPeriod.Visible = True
            grpContractPeriod.Enabled = True

            PayerDrop()

            lblcancel.Visible = False
            lblCancelReason.Visible = False
            dtpCancelledDate.Visible = False
            cboReasonID.Visible = False

            MainDataView = DB.ContractOriginal.GetAssetsForContract(0, True)
            SecondAppliances = DB.ContractOriginal.GetAssetsForContract(0, False)

            SetupMainDataGrid()
            SetupSecondryDataGrid()

            Populate()
            btnTypeOk.Visible = True
            cboContractType.Enabled = True
            BtnCancel.Visible = True

            Dim renewed As Integer = DB.ExecuteScalar("Select Count(*) FROM tblContractRenewals WHERE OldContractID = " & CurrentContract.ContractID)
            If renewed > 0 Then
                btnTransfer.Visible = True
                btnRenew.Visible = False
                lblRenewed.Visible = True
            Else
                btnTransfer.Visible = True
                btnRenew.Visible = True
                lblRenewed.Visible = False
            End If
        ElseIf b.Text = "Amend Contract" Then
            btnTypeOk.Visible = False
            cboContractType.Enabled = False
        End If
    End Sub

    Private Sub btnRenew_Click(sender As Object, e As EventArgs) Handles btnRenew.Click
        c = ParentForm.Controls.Find("btnSave", True)
        b = c(0)
        b.Text = "Renew Contract"
        b.Enabled = False
        btnRenew.BackColor = Color.Blue

        grpAppliancesCovered.Enabled = True
        grpContractPeriod.Enabled = True
        grpAppliancesCovered.Visible = True
        grpAdditionalOptions.Visible = True
        grpPromo.Enabled = True
        grpPayers.Visible = True
        cboPaymentType.Enabled = True

        DoTotals()

        dtpContractStartDate.Value = CurrentContract.ContractEndDate.AddDays(1)
        grpAdditionalDetails.Visible = False
        btnPaymentOK.ForeColor = Color.OrangeRed
        If CurrentContract.ContractType = "68032" Then   ''''swap to PLAT STAR

            CurrentContract.SetContractType = Enums.ContractTypes.PlatinumStar
            Combo.SetSelectedComboItem_By_Value(cboContractType, Enums.ContractTypes.PlatinumStar)

            If Not Number Is Nothing Then
                DB.Job.DeleteReservedOrderNumber(Number.JobNumber, Number.Prefix)
            End If
            Number = DB.Job.GetNextJobNumber(Enums.ContractTypes.PlatinumStar)
            If Number.JobNumber.ToString.Length < 3 Then
                Me.lblContractRef.Text = Number.Prefix & "00" & Number.JobNumber
            ElseIf Number.JobNumber.ToString.Length < 4 Then
                Me.lblContractRef.Text = Number.Prefix & "0" & Number.JobNumber
            Else
                Me.lblContractRef.Text = Number.Prefix & Number.JobNumber
            End If

            CurrentContract.SetContractReference = Me.lblContractRef.Text

            DoTotals()
        End If
    End Sub

    Private Sub cboSoldBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSoldBy.SelectedIndexChanged
        If cboSoldBy.Visible = False Then
            Exit Sub
        End If

        If loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Invoicing) Then
        Else
            ShowMessage("You can not authorise discounts on this plan", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            cboSoldBy.SelectedValue = loggedInUser.UserID
            Exit Sub
        End If
    End Sub

    Private Sub chkWindowLockPest_CheckedChanged(sender As Object, e As EventArgs) Handles chkWindowLockPest.CheckedChanged, chkPlumbingDrainage.CheckedChanged, chkGasSupplyPipework.CheckedChanged
        If Combo.GetSelectedItemValue(cboPeriod) > 1 And (chkGasSupplyPipework.Checked Or chkPlumbingDrainage.Checked Or chkWindowLockPest.Checked) Then
            ShowMessage("Additional Options can not be added to a plan which runs for more than one year.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            chkWindowLockPest.Checked = False
            chkPlumbingDrainage.Checked = False
            chkGasSupplyPipework.Checked = False
            Exit Sub
        Else
            DoTotals()
        End If
    End Sub

    Private Sub txtMainAppCount_TextChanged(sender As Object, e As EventArgs) Handles txtMainAppCount.TextChanged, txtSecondryCount.TextAlignChanged
        If CBT(txtMainAppCount.Text) + CBT(txtSecondryCount.Text) > 0 Then
            DoTotals()
            If Not b Is Nothing Then
                b.Enabled = True
            End If
        Else
            DoTotals()
            If Not b Is Nothing Then
                b.Enabled = False
            End If
        End If
    End Sub

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        MainDataView = DB.ContractOriginal.GetAssetsForContract(CurrentContractSite.ContractSiteID, True)
        SecondAppliances = DB.ContractOriginal.GetAssetsForContract(CurrentContractSite.ContractSiteID, False)

        txtMainAppCount.Text = MainDataView.Table.Rows.Count
        txtSecondryCount.Text = SecondAppliances.Table.Rows.Count
        Combo.SetSelectedComboItem_By_Value(cboContractType, CurrentContract.ContractTypeID)
        Me.dtpContractStartDate.Value = CurrentContract.ContractStartDate
        Dim dd1 As Integer = DateHelper.GetYearsBetween(CurrentContract.ContractStartDate, CurrentContract.ContractEndDate.AddDays(10))
        If dd1 = 0 Then dd1 = 1
        Combo.SetSelectedComboItem_By_Value(cboPeriod, dd1)

        If CurrentContract.ContractPriceAfterVAT > 0 Then
            Me.lblTotalEst.Text = Format(CurrentContract.ContractPriceAfterVAT, "C")
        Else
            Me.lblTotalEst.Text = Format(CurrentContract.ContractPrice * 1.2, "C")
        End If
        previousTotal = Me.lblTotalEst.Text
        Dim theRounded As Double = Math.Round(Me.lblTotalEst.Text / 12, 2)

        previousFirst = Format(((theRounded + (Me.lblTotalEst.Text - (theRounded * 12)))), "C")
        previousSecond = Format(theRounded, "C")

        txtPONumber.Text = CurrentContract.PoNumber

        'TODO sortcode and account numbers
        Combo.SetSelectedComboItem_By_Value(cboPromotion, CurrentContract.DiscountID)

        txtBankName.Text = CurrentContract.BankName
        txtAccNumber.Text = CurrentContract.AccountNumber
        txtSortCode.Text = CurrentContract.SortCode

        chkGasSupplyPipework.Checked = CurrentContract.GasSupplyPipework
        chkPlumbingDrainage.Checked = CurrentContract.PlumbingDrainage
        chkWindowLockPest.Checked = CurrentContract.WindowLockPest
        chkLandlord.Checked = CurrentContractSite.LLCertReqd
        chkCommercial.Checked = CurrentContractSite.Commercial
        txtNotesToEngineer.Text = CurrentContractSite.AdditionalNotes

        Combo.SetSelectedComboItem_By_Value(cboPAyer, CurrentContract.InvoiceAddressID & "`" & CurrentContract.InvoiceAddressTypeID)

        If CurrentContract.InvoiceFrequencyID = Enums.InvoiceFrequency.Monthly Then Combo.SetSelectedComboItem_By_Value(cboPaymentType, CInt(Enums.ContractPaymentType.Direct_Debit)) ' dd
        If CurrentContract.InvoiceFrequencyID = Enums.InvoiceFrequency.Annually Then Combo.SetSelectedComboItem_By_Value(cboPaymentType, CInt(Enums.ContractPaymentType.Annual)) ' Ann
        If CurrentContract.InvoiceFrequencyID = Enums.InvoiceFrequency.AnnuallyDD Then Combo.SetSelectedComboItem_By_Value(cboPaymentType, CInt(Enums.ContractPaymentType.AnnualDirectDebit)) ' AnnDD

        Dim dd As DataTable = DB.ExecuteWithReturn("Select  SC, AC, InitialPaymentType,FirstAmount,SecondPayment,AccName FROM tblContractP where ContractSiteID = " & CurrentContractSite.ContractSiteID)

        If txtMainAppCount.Text = "0" Then txtMainAppCount.Text = CurrentContractSite.MainAppliances
        If txtSecondryCount.Text = "0" Then txtSecondryCount.Text = CurrentContractSite.SecondryAppliances

        'decrypt
        Dim wrapper As New Simple3Des(p)

        ' DecryptData throws if the wrong password is used.
        If dd.Rows.Count > 0 Then
            Try
                ddsort = wrapper.DecryptData(dd.Rows(0)("sc"))
                ddAcc = wrapper.DecryptData(dd.Rows(0)("Ac"))
            Catch ex As System.Security.Cryptography.CryptographicException
                MsgBox("The Account data could not be decrypted")
            End Try

            Combo.SetSelectedComboItem_By_Description(cboInitialPaymentType, dd.Rows(0)("InitialPaymentType").ToString)
            txtSortCode.Text = ddsort
            txtAccNumber.Text = ddAcc
            txtAccName.Text = dd.Rows(0)("AccName")
            lblFollowedBy.Text = Format(dd.Rows(0)("SecondPayment"), "C")
        End If

        If CurrentContract.ContractStatusID = Enums.ContractStatus.Cancelled Then
            dtpCancelledDate.Value = CurrentContract.CancelledDate
            dtpCancelledDate.Visible = True
            cboReasonID.Visible = True
            Combo.SetSelectedComboItem_By_Value(cboReasonID, CurrentContract.ReasonID)
        Else
            dtpCancelledDate.Visible = False
            cboReasonID.Visible = False
        End If

        PreviousRef = CurrentContract.ContractReference
        lblContractRef.Text = CurrentContract.ContractReference
    End Sub

    Public Function workingdays(ByVal Startdate As Date, ByVal EndDate As Date) As Integer
        Dim count As Integer = 0
        Dim totalDays As Integer = (EndDate - Startdate).Days
        Dim dvBankHolidays As DataView = DB.TimeSlotRates.BankHolidays_GetAll

        For i As Integer = 0 To totalDays
            Dim weekday As DayOfWeek = Startdate.AddDays(i).DayOfWeek
            If dvBankHolidays.Table.Select("BankHolidayDate='" & CDate(Strings.Format(Startdate.AddDays(i), "dd/MM/yyyy")) & "'").Length > 0 Then

            ElseIf weekday <> DayOfWeek.Saturday AndAlso weekday <> DayOfWeek.Sunday Then
                count += 1
            End If
        Next
        Return count
    End Function

    Public Function ProcessingDateSub() As Date
        Dim dateout As Date
        Dim contractStart As Date = CurrentContract.ContractStartDate

        If workingdays(Today.AddDays(1), New Date(Year(contractStart), Month(contractStart), contractStart.Day)) < 11 Then
            dateout = New Date(Today.Year, Today.Month, 1).AddMonths(2)
        Else
            dateout = New Date(contractStart.Year, contractStart.Month, 1).AddMonths(1)
        End If

        Dim dvBankHolidays As DataView = DB.TimeSlotRates.BankHolidays_GetAll
        Dim c As Integer = 0
        Dim i As Integer = 0
        While i < 11
            Dim weekday As DayOfWeek = dateout.AddDays(-c).DayOfWeek
            If dvBankHolidays.Table.Select("BankHolidayDate='" & CDate(Strings.Format(dateout.AddDays(-c), "dd/MM/yyyy")) & "'").Length > 0 Then

            ElseIf weekday <> DayOfWeek.Saturday AndAlso weekday <> DayOfWeek.Sunday Then
                i = i + 1
            End If
            c = c - 1
        End While
        Return dateout.AddDays(c)
    End Function

    Public Sub SetContract()
        Try
            Dim paymentType As Integer = Combo.GetSelectedItemValue(cboPaymentType)

            CurrentContract.SetContractReference = lblContractRef.Text
            If Combo.GetSelectedItemValue(cboReasonID) > 0 Then
                CurrentContract.SetContractStatusID = CInt(Enums.ContractStatus.Cancelled)
            Else
                CurrentContract.SetContractStatusID = CInt(Enums.ContractStatus.Active)
            End If

            Dim VAT As Entity.VATRatess.VATRates = DB.VATRatesSQL.VATRates_Get(DB.VATRatesSQL.VATRates_Get_ByDate(CurrentContract.ContractStartDate))
            CurrentContract.SetContractPrice = (Price / (1 + (VAT.VATRate / 100)))
            CurrentContract.SetContractPriceAfterVAT = (Price)

            CurrentContract.FirstInvoiceDate = CurrentContract.ContractStartDate

            Select Case paymentType
                Case Enums.ContractPaymentType.Annual
                    CurrentContract.SetDirectDebit = False
                    CurrentContract.SetAnnual = True
                    CurrentContract.SetInvoiceFrequencyID = CInt(Enums.InvoiceFrequency.Annually)

                Case Enums.ContractPaymentType.AnnualDirectDebit
                    CurrentContract.SetDirectDebit = True
                    CurrentContract.SetAnnual = True
                    CurrentContract.SetInvoiceFrequencyID = CInt(Enums.InvoiceFrequency.AnnuallyDD)

                Case Else
                    CurrentContract.SetDirectDebit = True
                    CurrentContract.SetAnnual = False
                    CurrentContract.SetInvoiceFrequencyID = CInt(Enums.InvoiceFrequency.Monthly)
            End Select

            CurrentContract.SetContractTypeID = Combo.GetSelectedItemValue(cboContractType)
            CurrentContract.SetDiscountID = Combo.GetSelectedItemValue(cboPromotion)
            CurrentContract.SetBankName = txtBankName.Text
            CurrentContract.SetPoNumber = txtPONumber.Text
            CurrentContract.SetGasSupplyPipework = chkGasSupplyPipework.Checked
            CurrentContract.SetPlumbingDrainage = chkPlumbingDrainage.Checked
            CurrentContract.SetWindowLockPest = chkWindowLockPest.Checked
            If Combo.GetSelectedItemValue(cboPAyer) <> "0" Then
                CurrentContract.SetInvoiceAddressID = Combo.GetSelectedItemValue(cboPAyer).Split("`")(0)
                CurrentContract.SetInvoiceAddressTypeID = Combo.GetSelectedItemValue(cboPAyer).Split("`")(1)
            End If
            CurrentContract.SetCustomerID = IDToLinkTo

            Dim cV As New Entity.ContractsOriginal.ContractOriginalValidator
            cV.Validate(CurrentContract)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SetContractSite()
        Try
            CurrentContractSite.IgnoreExceptionsOnSetMethods = True

            CurrentContractSite.SetPropertyID = SiteID
            CurrentContractSite.SetContractID = CurrentContract.ContractID
            CurrentContractSite.SetPricePerVisit = 25

            NextVisit()   ''''''  get the next visit

            CurrentContractSite.FirstVisitDate = newdate

            CurrentContractSite.SetVisitFrequencyID = 7 'Annually
            CurrentContractSite.SetVisitDuration = (CBT(txtMainAppCount.Text) * 50) + (CBT(txtSecondryCount.Text) * 30)
            CurrentContractSite.SetAverageMileage = 0 ':removed at Robs request
            CurrentContractSite.SetIncludeAssetPrice = False
            CurrentContractSite.SetIncludeMileagePrice = False
            CurrentContractSite.SetTotalSitePrice = 100
            CurrentContractSite.SetPricePerMile = 0 ':removed at Robs request
            CurrentContractSite.SetIncludeRates = True
            CurrentContractSite.SetLLCertReqd = Me.chkLandlord.Checked
            CurrentContractSite.SetAdditionalNotes = Me.txtNotesToEngineer.Text
            CurrentContractSite.SetCommercial = Me.chkCommercial.Checked
            CurrentContractSite.SetMainAppliances = CBT(Me.txtMainAppCount.Text)
            CurrentContractSite.SetSecondryAppliances = CBT(Me.txtSecondryCount.Text)
            Dim cVo As New Entity.ContractOriginalSites.ContractOriginalSiteValidator
            cVo.Validate(CurrentContractSite, CurrentContract)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SetContractSiteAsset()
        Try
            'DELETE AND RE INSERT ASSET
            DB.ContractOriginalSiteAsset.Delete(CurrentContractSite.ContractSiteID)

            For Each drAsset As DataRow In MainDataView.Table.Rows
                Dim ContractSiteAsset As New Entity.ContractOriginalSiteAssets.ContractOriginalSiteAsset
                ContractSiteAsset.SetAssetID = drAsset("AssetID")
                ContractSiteAsset.SetContractSiteID = CurrentContractSite.ContractSiteID
                ContractSiteAsset.SetPricePerVisit = 25
                ContractSiteAsset.SetType = drAsset("Product").ToString.Split("-")(0).Trim(" ")
                ContractSiteAsset.SetPrimaryAsset = True
                ContractSiteAsset.SetProduct = drAsset("Product")
                ContractSiteAsset = DB.ContractOriginalSiteAsset.Insert(ContractSiteAsset)
            Next drAsset

            For Each drAsset2 As DataRow In SecondAppliances.Table.Rows
                Dim ContractSiteAsset As New Entity.ContractOriginalSiteAssets.ContractOriginalSiteAsset
                ContractSiteAsset.SetAssetID = drAsset2("AssetID")
                ContractSiteAsset.SetContractSiteID = CurrentContractSite.ContractSiteID
                ContractSiteAsset.SetPricePerVisit = 25
                ContractSiteAsset.SetPrimaryAsset = False
                ContractSiteAsset.SetType = drAsset2("Product").ToString.Split("-")(0).Trim(" ")
                ContractSiteAsset.SetProduct = drAsset2("Product")
                ContractSiteAsset = DB.ContractOriginalSiteAsset.Insert(ContractSiteAsset)
            Next drAsset2

            If CBT(txtMainAppCount.Text) > 0 Then
                Dim contractSOR As New Entity.ContractOriginalSiteRatess.ContractOriginalSiteRates
                contractSOR.SetContractSiteID = CurrentContractSite.ContractSiteID
                contractSOR.SetQty = CBT(txtMainAppCount.Text)
                contractSOR.SetRateID = 244
                DB.ContractOriginalSiteRates.Insert(contractSOR)
            End If

            If CBT(txtSecondryCount.Text) > 0 Then
                Dim contractSOR As New Entity.ContractOriginalSiteRatess.ContractOriginalSiteRates
                contractSOR.SetContractSiteID = CurrentContractSite.ContractSiteID
                contractSOR.SetQty = CBT(txtSecondryCount.Text)
                contractSOR.SetRateID = 245
                DB.ContractOriginalSiteRates.Insert(contractSOR)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        If CBT(txtMainAppCount.Text) > 0 Or CBT(txtSecondryCount.Text) > 0 Then
            Try
                Me.Cursor = Cursors.WaitCursor
                CurrentContract.IgnoreExceptionsOnSetMethods = True

                If Combo.GetSelectedItemValue(cboPeriod) = 0 Then
                    ShowMessage("Period missing! Please correct!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
                Dim installments As Integer = 12 * Combo.GetSelectedItemValue(cboPeriod)
                Price = lblTotalEst.Text

                Dim fMonthlyEst As Double = 0 'first monthly payment
                Dim sMonthlyEst As Double = 0 'second monthly payment
                Dim paymentType As Integer = Combo.GetSelectedItemValue(cboPaymentType)

                Dim wrapper As New Simple3Des(p)
                Dim cipherSort As String = wrapper.EncryptData(txtSortCode.Text.Replace("-", ""))

                Dim wrapper2 As New Simple3Des(p)
                Dim cipherAccount As String = wrapper.EncryptData(txtAccNumber.Text)

                If b.Text = "Create Contract" Then  ' new contract

#Region "Create Contract"

                    If ShowMessage("Are you sure you want to save?" & vbCrLf & "Information cannot be altered after save and jobs will be created", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Exit Function
                    End If

                    CurrentContract.ContractStartDate = Me.dtpContractStartDate.Value
                    CurrentContract.ContractEndDate = Me.dtpContractStartDate.Value.AddYears(Combo.GetSelectedItemValue(cboPeriod)).AddDays(-1)
                    SetContract()

                    CurrentContract = DB.ContractOriginal.Insert(CurrentContract)
                    NumberUsed = True

                    InsertInvoiceToBeRaiseLines()

                    SetContractSite()
                    CurrentContractSite = DB.ContractOriginalSite.Insert(CurrentContractSite)   ' insert site contract

                    Select Case paymentType
                        Case Enums.ContractPaymentType.Annual,
                             Enums.ContractPaymentType.AnnualDirectDebit
                            fMonthlyEst = Helper.MakeDoubleValid(lblTotalEst.Text)
                            installments = 0

                        Case Else
                            fMonthlyEst = Helper.MakeDoubleValid(lblMonthlyEst.Text)
                            sMonthlyEst = Helper.MakeDoubleValid(lblFollowedBy.Text)
                            installments -= 1
                    End Select

                    DB.ExecuteScalar("INSERT INTO tblContractP (ContractSiteID,Sc,Ac,TransactionType,FirstAmount,DDProcessingDate,Processed,SecondPayment,Installments,InitialPaymentType,AccName,UserID,Type,ManualApp) VALUES (" &
                                     CurrentContractSite.ContractSiteID & ",'" & cipherSort & "','" & cipherAccount & "',17," & fMonthlyEst & ",'" &
                                     Format(ProcessingDateSub(), "yyyy-MM-dd") & "',0," & sMonthlyEst & " ," & installments & ",'" & Combo.GetSelectedItemDescription(cboInitialPaymentType) & "','" & txtAccName.Text.Replace("'", "") & "'," &
                                     CInt(cboSoldBy.SelectedValue) & ",'NEW','" & ManualApp & "')")

                    SetContractSiteAsset()

                    'START SCHEDULING JOBS************************
                    ScheduleJob()
                    '**************************
                    NumberUsed = True

                    RaiseEvent StateChanged(CurrentContract.ContractID)
                    b.Enabled = False
                    ShowMessage("Contract " & lblContractRef.Text & " has been created.", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Return True

#End Region

                ElseIf b.Text = "Amend Contract" Then ' amending old

#Region "Amend Contract"

                    If ShowMessage("Are you sure you want to save?" & vbCrLf & "Information cannot be altered after save and jobs will be created", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Exit Function
                    End If

                    Dim hasContractChanged As Boolean = False
                    Dim contractTypeId As Integer = Combo.GetSelectedItemValue(cboContractType)

                    'check if user has changed the contract type if so ...
                    If CurrentContract.ContractTypeID <> contractTypeId Then
                        'distingush if contract is being upgraded or downgraded
                        Select Case contractTypeId
                            Case Enums.ContractTypes.SilverStar
                                hasContractChanged = ChangeContract(False, contractTypeId)
                            Case Enums.ContractTypes.GoldStar
                                hasContractChanged = ChangeContract(CurrentContract.ContractTypeID > CInt(Enums.ContractTypes.GoldStar), contractTypeId)
                            Case Enums.ContractTypes.PlatinumStar
                                hasContractChanged = ChangeContract(CurrentContract.ContractTypeID > CInt(Enums.ContractTypes.PlatinumStar), contractTypeId)
                            Case Enums.ContractTypes.PlatinumImmediate
                                hasContractChanged = ChangeContract(True, contractTypeId)
                            Case Enums.ContractTypes.TotallyAssured
                                hasContractChanged = ChangeContract(CurrentContract.ContractTypeID <> CInt(Enums.ContractTypes.PlatinumImmediate), contractTypeId)
                        End Select
                    End If

                    Dim ContractsDT As DataTable = DB.ContractOriginal.Get_NotProcessed(CurrentContract.ContractID).Table
                    If ContractsDT.Rows.Count > 0 AndAlso ContractsDT.Rows(0)("InvoiceToBeRaisedID") > 0 Then installments -= 1

                    Dim type As String = "AMEND"
                    If txtAccNumber.Text <> ddAcc Or (hasContractChanged And contractTypeId = Enums.ContractTypes.TotallyAssured) Then
                        type = "AMENDD"
                        CurrentContract.FirstInvoiceDate = Today
                    Else
                        CurrentContract.FirstInvoiceDate = New Date(Today.Year, Today.Month, 1).AddMonths(1)
                        Offset = False
                    End If

                    Dim invoicecount As Integer = 0
                    If CurrentContract.InvoiceFrequencyID = Enums.InvoiceFrequency.Monthly Or
                       CurrentContract.InvoiceFrequencyID = Enums.InvoiceFrequency.AnnuallyDD Then
                        ' delete the old invoices
                        DB.ExecuteScalar("DELETE FROM tblInvoiceToBeRaised WHERE InvoiceToBeRaisedID IN ( " &
                                             "Select tblInvoiceToBeRaised.InvoiceToBeRaisedID FROM tblInvoiceToBeRaised " &
                                             " LEFT JOIN tblInvoicedLines ON tblInvoicedLines.InvoiceToBeRaisedID = tblInvoiceToBeRaised.InvoiceToBeRaisedID WHERE tblInvoicedLines.InvoicedLineID is null AND LinkID = " &
                                             CurrentContract.ContractID & " AND InvoiceTypeID = 327 and tblInvoiceToBeRaised.RaiseDate > GETDATE())")
                        'insert some new ones.
                        EffDate = Today
                        If Not (hasContractChanged AndAlso contractTypeId = Enums.ContractTypes.TotallyAssured) Then
                            invoicecount = InsertInvoiceToBeRaiseLines(True, hasContractChanged)
                        End If
                    End If

                    Dim VAT As Entity.VATRatess.VATRates = DB.VATRatesSQL.VATRates_Get(DB.VATRatesSQL.VATRates_Get_ByDate(CurrentContract.ContractStartDate))
                    If hasContractChanged Then
                        CurrentContract.SetDDMSRef = PreviousRef
                    End If

                    SetContract()
                    SetContractSiteAsset()
                    SetContractSite()

                    If CurrentContract.Exists Then
                        If hasContractChanged Then
                            Dim cV As New Entity.ContractsOriginal.ContractOriginalValidator
                            cV.Validate(CurrentContract)

                            DB.ContractOriginal.Insert(CurrentContract)
                            CurrentContractSite.SetContractID = CurrentContract.ContractID
                            DB.ContractOriginalSite.Insert(CurrentContractSite)
                            SetContractSiteAsset()

                            invoicecount = InsertInvoiceToBeRaiseLines(True, hasContractChanged)
                            DB.ContractOriginal.Insert_UpgradedFrom(CurrentContract.ContractID, PreviousRef)
                        Else
                            CurrentContract.SetReasonID = Combo.GetSelectedItemValue(cboReasonID)
                            CurrentContract.CancelledDate = dtpCancelledDate.Value

                            Dim cV As New Entity.ContractsOriginal.ContractOriginalValidator
                            cV.Validate(CurrentContract)

                            DB.ContractOriginal.Update(CurrentContract)
                            DB.ContractOriginalSite.Update(CurrentContractSite)
                        End If
                        NumberUsed = True
                    Else
                        CurrentContract.SetCustomerID = IDToLinkTo
                        Dim cV As New Entity.ContractsOriginal.ContractOriginalValidator
                        cV.Validate(CurrentContract)

                        CurrentContract = DB.ContractOriginal.Insert(CurrentContract)
                        NumberUsed = True
                    End If

                    Select Case paymentType
                        Case Enums.ContractPaymentType.Annual,
                         Enums.ContractPaymentType.AnnualDirectDebit
                            fMonthlyEst = Helper.MakeDoubleValid(lblTotalEst.Text)
                            installments = 0
                        Case Else
                            fMonthlyEst = Helper.MakeDoubleValid(lblMonthlyEst.Text)
                            sMonthlyEst = Helper.MakeDoubleValid(lblFollowedBy.Text)
                            If hasContractChanged And CurrentContract.ContractTypeID = Enums.ContractTypes.TotallyAssured Then
                                installments = 1
                            End If
                    End Select

                    Dim c As Integer = DB.ExecuteScalar("Select Count(*) from tblcontractp where Processed = 0 AND Installments > 0 AND contractsiteID = " & CurrentContractSite.ContractSiteID)
                    If c > 0 Then
                        DB.ExecuteScalar("Delete from tblcontractp where Processed = 0 AND Installments > 0 AND contractsiteID = " & CurrentContractSite.ContractSiteID)
                        If type = "AMEND" Then
                            type = "NEW"
                        End If
                        DB.ExecuteScalar("INSERT INTO tblContractP (ContractSiteID,Sc,Ac,TransactionType,FirstAmount,DDProcessingDate,Processed,SecondPayment,Installments,InitialPaymentType,AccName,UserID,Type,ManualApp,SecondApp) VALUES (" &
                                     CurrentContractSite.ContractSiteID & ",'" & cipherSort & "','" & cipherAccount & "',17," & fMonthlyEst & ",'" & Format(ProcessingDateSub(), "yyyy-MM-dd") & "',0," & sMonthlyEst & " ," &
                                     installments & ",'" & Combo.GetSelectedItemDescription(cboInitialPaymentType) & "','" & txtAccName.Text & "'," & loggedInUser.UserID & ",'" & type & "','" & ManualApp & "','" & SecondApp & "')")
                    ElseIf type = "AMENDD" Then
                        DB.ExecuteScalar("INSERT INTO tblContractP (ContractSiteID,Sc,Ac,TransactionType,FirstAmount,DDProcessingDate,Processed,SecondPayment,Installments,InitialPaymentType,AccName,UserID,Type,ManualApp,SecondApp) VALUES (" &
                                     CurrentContractSite.ContractSiteID & ",'" & cipherSort & "','" & cipherAccount & "',17," & sMonthlyEst & ",'" & Format(ProcessingDateSub(), "yyyy-MM-dd") & "',0," & sMonthlyEst & " ," &
                                     invoicecount & ",'" & Combo.GetSelectedItemDescription(cboInitialPaymentType) & "','" & txtAccName.Text & "'," & loggedInUser.UserID & ",'" & type & "','" & ManualApp & "','" & SecondApp & "')")

                        Dim FeedbackEmail As New Emails
                        FeedbackEmail.From = EmailAddress.FSM
                        FeedbackEmail.To = EmailAddress.Coverplan
                        FeedbackEmail.Subject = "A DDMS Record Requires Manually Changing"
                        Dim ddmsref As String = ""
                        If CurrentContract.DDMSRef.Length > 0 Then ddmsref = CurrentContract.DDMSRef Else ddmsref = CurrentContract.ContractReference
                        FeedbackEmail.Body = "Please amend record " & ddmsref & ", a new direct debit instruction will be added to DDMS tonight But the existing dd instructions should be removed or cancelled."
                        FeedbackEmail.SendMe = True
                        FeedbackEmail.Send()

                    ElseIf type = "AMEND" Then
                        Dim contractPDataTable As DataTable = DB.ExecuteWithReturn("SELECT DirectDebitID, ManualApp, SecondApp, FirstAmount, SecondPayment, Installments FROM tblContractP WHERE ContractSiteID = " & CurrentContractSite.ContractSiteID)
                        For Each row As DataRow In contractPDataTable.Rows
                            If Not String.IsNullOrEmpty(ManualApp) AndAlso Helper.MakeStringValid(row("ManualApp")) <> ManualApp Then
                                DB.ExecuteScalar("UPDATE tblContractP SET ManualApp = '" & ManualApp & "' WHERE DirectDebitID = " & row("DirectDebitID"))
                            End If
                            If Not String.IsNullOrEmpty(SecondApp) AndAlso Helper.MakeStringValid(row("SecondApp")) <> SecondApp Then
                                DB.ExecuteScalar("UPDATE tblContractP SET SecondApp = '" & SecondApp & "' WHERE DirectDebitID = " & row("DirectDebitID"))
                            End If
                            If (Helper.MakeDoubleValid(row("FirstAmount")) <> fMonthlyEst) Or (Helper.MakeDoubleValid(row("FirstAmount")) <> sMonthlyEst) Then
                                DB.ExecuteScalar("UPDATE tblContractP SET FirstAmount = " & fMonthlyEst & " WHERE DirectDebitID = " & row("DirectDebitID"))
                            End If
                            If (Helper.MakeDoubleValid(row("SecondPayment")) <> sMonthlyEst) Then
                                DB.ExecuteScalar("UPDATE tblContractP SET SecondPayment = " & sMonthlyEst & " WHERE DirectDebitID = " & row("DirectDebitID"))
                            End If
                            If (Helper.MakeIntegerValid(row("Installments")) <> invoicecount) Then
                                DB.ExecuteScalar("UPDATE tblContractP SET Installments = " & invoicecount & " WHERE DirectDebitID = " & row("DirectDebitID"))
                            End If
                        Next

                    End If
                    NumberUsed = True

                    RaiseEvent StateChanged(CurrentContract.ContractID)
                    b.Enabled = False
                    ShowMessage("Contract " & lblContractRef.Text & " has been Amended.", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    If hasContractChanged AndAlso CurrentContract.ContractTypeID = Enums.ContractTypes.TotallyAssured Then
                        ScheduleJob()
                    End If

                    Return True

#End Region

                ElseIf b.Text = "Transfer Contract" Then

#Region "Transfer Contract"

                    If ShowMessage("Are you sure you want to save?" & vbCrLf & "Information cannot be altered after save and jobs will be created", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Exit Function
                    End If

                    SetContract()
                    CurrentContractSite.SetPropertyID = NewSiteID

                    If NewPayer.Length > 1 Then
                        OldEndDate = CurrentContract.ContractEndDate
                        CurrentContract.ContractEndDate = EffDate.AddDays(-1)

                        CurrentContract.SetReasonID = CInt(Enums.ContractInactiveReason.Transferred)
                        DB.ContractOriginal.Update(CurrentContract) ' update old contract

                        CurrentContract.SetInvoiceAddressID = NewPayer.Split("`")(0)  ' build new contract
                        CurrentContract.SetInvoiceAddressTypeID = NewPayer.Split("`")(1)
                    Else
                        Exit Function
                    End If

                    CurrentContract.SetReasonID = 0
                    CurrentContract.ContractEndDate = OldEndDate

                    If EffDate > OldEndDate Then Exit Function
                    If EffDate < CurrentContract.ContractStartDate Then
                    Else
                        CurrentContract.ContractStartDate = EffDate
                    End If

                    CurrentContract.SetPreviousInvoiceFrequencyID = CurrentContract.InvoiceFrequencyID

                    If Combo.GetSelectedItemValue(cboReasonID) > 0 Then
                        CurrentContract.SetContractStatusID = CInt(Enums.ContractStatus.Cancelled)
                    Else
                        CurrentContract.SetContractStatusID = CInt(Enums.ContractStatus.Active)
                    End If

                    Dim VAT As Entity.VATRatess.VATRates = DB.VATRatesSQL.VATRates_Get(DB.VATRatesSQL.VATRates_Get_ByDate(CurrentContract.ContractStartDate))
                    CurrentContract.SetContractPrice = (Price / (1 + (VAT.VATRate / 100)))
                    CurrentContract.SetContractPriceAfterVAT = (Price)

                    Dim cV As New Entity.ContractsOriginal.ContractOriginalValidator
                    newdate = DB.ContractOriginal.Transfer(CurrentContract.ContractID, CurrentContractSite.ContractSiteID, EffDate) ' before its replaced with new contract

                    Dim oldcontractid As Integer = CurrentContract.ContractID  ' part 1
                    CurrentContract = DB.ContractOriginal.Insert(CurrentContract)
                    NumberUsed = True

                    ' Add the New reference to the old contract ' part 2
                    DB.ExecuteScalar("UPDATE tblContractOriginal SET MigratedToContractID = " & CurrentContract.ContractID & " WHERE ContractID = " & oldcontractid)

                    '' Important dont miss this :)
                    CurrentContractSite.SetContractID = CurrentContract.ContractID

                    If newdate = Date.MinValue Then
                    Else
                        CurrentContractSite.FirstVisitDate = newdate
                    End If

                    'delete incomplete invoices
                    Dim type As String = "TRANS"
                    If txtAccNumber.Text <> ddAcc Then
                        type = "TRANSD"
                        CurrentContract.FirstInvoiceDate = EffDate
                    Else
                        CurrentContract.FirstInvoiceDate = New Date(CurrentContract.ContractStartDate.Year, CurrentContract.ContractStartDate.Month, 1).AddMonths(1)
                        Offset = False ' dont jump the next month
                    End If

                    If CurrentContract.InvoiceFrequencyID = Enums.InvoiceFrequency.Monthly Or CurrentContract.InvoiceFrequencyID = Enums.InvoiceFrequency.AnnuallyDD Then
                        InsertInvoiceToBeRaiseLines(True)
                    End If

                    CurrentContractSite.IgnoreExceptionsOnSetMethods = True
                    CurrentContractSite.SetLLCertReqd = Me.chkLandlord.Checked
                    CurrentContractSite.SetAdditionalNotes = Me.txtNotesToEngineer.Text
                    CurrentContractSite.SetCommercial = Me.chkCommercial.Checked

                    Dim cVo As New Entity.ContractOriginalSites.ContractOriginalSiteValidator
                    DB.ExecuteScalar("DELETE tblcontractp where Processed = 0 AND Installments > 0 AND contractsiteID = " & CurrentContractSite.ContractSiteID & "")

                    Select Case paymentType
                        Case Enums.ContractPaymentType.Annual,
                         Enums.ContractPaymentType.AnnualDirectDebit
                            fMonthlyEst = Helper.MakeDoubleValid(lblTotalEst.Text)
                        Case Else
                            fMonthlyEst = Helper.MakeDoubleValid(lblMonthlyEst.Text)
                            sMonthlyEst = Helper.MakeDoubleValid(lblFollowedBy.Text)
                    End Select

                    CurrentContractSite = DB.ContractOriginalSite.Insert(CurrentContractSite)   ' insert site contract
                    If type = "TRANSD" Then
                        DB.ExecuteScalar("INSERT INTO tblContractP (ContractSiteID,Sc,Ac,TransactionType,FirstAmount,DDProcessingDate,Processed,SecondPayment,Installments,InitialPaymentType,AccName,UserID,Type) VALUES (" &
                                     CurrentContractSite.ContractSiteID & ",'" & cipherSort & "','" & cipherAccount & "',17," & fMonthlyEst & ",'" & Format(ProcessingDateSub(), "yyyy-MM-dd") & "',0," &
                                     sMonthlyEst & " ," & installments & ",'" & Combo.GetSelectedItemDescription(cboInitialPaymentType) & "','" & txtAccName.Text & "'," & loggedInUser.UserID & ",'" & type & "')")
                    End If

                    If newdate = Date.MinValue Then
                    Else
                        ScheduleJob()
                    End If
                    '**************************
                    NumberUsed = True

                    ' DB.ContractManager.ContractRenewalsInsert(oldContract,
                    ' CurrentContract.ContractID, CInt(Enums.QuoteType.Contract_Opt_1))
                    RaiseEvent StateChanged(CurrentContract.ContractID)

                    b.Enabled = False
                    ShowMessage("Contract " & lblContractRef.Text & " has been Transfered.", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Return True

#End Region

                ElseIf b.Text = "Renew Contract" Then

#Region "Renew Contract"

                    'INSERT
                    If ShowMessage("Are you sure you want to save?" & vbCrLf & "Information cannot be altered after save and jobs will be created", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Exit Function
                    End If

                    SetContract()
                    Dim oldContract As String = CurrentContract.ContractID

                    CurrentContract.SetContractReference = lblContractRef.Text
                    CurrentContract.ContractStartDate = CurrentContract.ContractEndDate.AddDays(1)
                    CurrentContract.ContractEndDate = CurrentContract.ContractStartDate.AddYears(Combo.GetSelectedItemValue(cboPeriod)).AddDays(-1)
                    CurrentContract.SetDiscountID = Combo.GetSelectedItemValue(cboPromotion)
                    CurrentContract.SetPreviousInvoiceFrequencyID = CurrentContract.InvoiceFrequencyID

                    If Combo.GetSelectedItemValue(cboReasonID) > 0 Then
                        CurrentContract.SetContractStatusID = CInt(Enums.ContractStatus.Cancelled)
                    Else
                        CurrentContract.SetContractStatusID = CInt(Enums.ContractStatus.Active)
                    End If

                    Dim VAT As Entity.VATRatess.VATRates = DB.VATRatesSQL.VATRates_Get(DB.VATRatesSQL.VATRates_Get_ByDate(CurrentContract.ContractStartDate))
                    CurrentContract.SetContractPrice = (Price / (1 + (VAT.VATRate / 100)))
                    CurrentContract.SetContractPriceAfterVAT = (Price)

                    Dim type As String = "RENEWAL"
                    If txtAccNumber.Text <> ddAcc Then
                        type = "RENEWALD"
                        CurrentContract.FirstInvoiceDate = CurrentContract.ContractStartDate

                    ElseIf paymentType = Enums.ContractPaymentType.Annual Then 'ANNUAL
                        CurrentContract.FirstInvoiceDate = CurrentContract.ContractStartDate
                    Else ' Standard Renewal Monthly no change
                        Offset = False
                        CurrentContract.FirstInvoiceDate = New Date(CurrentContract.ContractStartDate.Year, CurrentContract.ContractStartDate.Month, 1) '.AddMonths(1)
                        Offset = False ' dont jump the next month
                    End If

                    CurrentContract.SetCustomerID = IDToLinkTo
                    CurrentContract = DB.ContractOriginal.Insert(CurrentContract)
                    NumberUsed = True

                    InsertInvoiceToBeRaiseLines()

                    SetContractSite()
                    CurrentContractSite.FirstVisitDate = newdate
                    CurrentContractSite = DB.ContractOriginalSite.Insert(CurrentContractSite)   ' insert site contract

                    Dim ip As String = ""

                    If paymentType = Enums.ContractPaymentType.Annual Then
                        ip = Combo.GetSelectedItemDescription(cboInitialPaymentType)
                    Else
                        ip = "RENEWAL"
                    End If

                    Select Case paymentType
                        Case Enums.ContractPaymentType.Annual, Enums.ContractPaymentType.AnnualDirectDebit
                            fMonthlyEst = Helper.MakeDoubleValid(lblTotalEst.Text)
                            installments = 0

                        Case Else
                            fMonthlyEst = Helper.MakeDoubleValid(lblMonthlyEst.Text)
                            sMonthlyEst = Helper.MakeDoubleValid(lblFollowedBy.Text)
                    End Select

                    DB.ExecuteScalar("INSERT INTO tblContractP(ContractSiteID, Sc, Ac, TransactionType, FirstAmount, DDProcessingDate, Processed, SecondPayment, Installments, InitialPaymentType, AccName, UserID, Type) VALUES (" &
                                     CurrentContractSite.ContractSiteID & ",'" & cipherSort & "','" & cipherAccount & "', 17," & fMonthlyEst & ",'" & Format(ProcessingDateSub(), "yyyy-MM-dd") & "',0," & sMonthlyEst & " ," &
                                     installments & ",'" & ip & "','" & txtAccName.Text & "'," & loggedInUser.UserID & ",'" & type & "')")

                    SetContractSiteAsset()

                    'START SCHEDULING JOBS************************
                    ScheduleJob()
                    '**************************
                    NumberUsed = True

                    DB.ContractManager.ContractRenewalsInsert(oldContract, CurrentContract.ContractID, CInt(Enums.QuoteType.Contract_Opt_1))

                    RaiseEvent StateChanged(CurrentContract.ContractID)

                    b.Enabled = False
                    ShowMessage("Contract " & lblContractRef.Text & " has been Renewed.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True

#End Region

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
        End If

    End Function

    Public Function ChangeContract(ByVal upgrade As Boolean, ByVal contractypeId As Integer) As Boolean
        Dim currentContractName As String = DB.Picklists.Get_One_As_Object(CurrentContract.ContractTypeID).Name
        Dim newContractName As String = DB.Picklists.Get_One_As_Object(contractypeId).Name
        Dim text As String = ""

        'Determnine which text to use
        If upgrade Then
            text = "Upgrade"
        Else
            text = "Downgrade"
        End If

        'Check with user
        If ShowMessage(text & " contract, Contract - " & CurrentContract.ContractReference &
                                        " will be " & text.ToLower & "d from " & currentContractName & " to " &
                                        newContractName, MessageBoxButtons.OKCancel,
                                        MessageBoxIcon.Information) = DialogResult.Cancel Then
            Return False
        End If

        'Get effective date and give user second chance to change their mind
        Dim f As New FRMContractUpgradeDowngrade()
        f.ShowDialog()
        If f.DialogResult = DialogResult.OK Then
            EffDate = f.EffDate
        Else
            Return False
        End If

        'check if contract has started

        If EffDate.Date > CurrentContract.ContractStartDate.Date Then
            OldEndDate = CurrentContract.ContractEndDate
            CurrentContract.ContractEndDate = EffDate.AddDays(-1)

            'Set the reason for the contract change
            If upgrade Then
                CurrentContract.SetReasonID = CInt(Enums.ContractInactiveReason.Upgraded)
            Else
                CurrentContract.SetReasonID = CInt(Enums.ContractInactiveReason.Downgraded)
            End If
            CurrentContract.SetDoNotRenew = True

            'Validate and update old contract
            Dim cV As New Entity.ContractsOriginal.ContractOriginalValidator
            cV.Validate(CurrentContract)
            DB.ContractOriginal.Update(CurrentContract)

            CurrentContract.SetDoNotRenew = False
            'Set contract start and end date for new contract
            'End date should be from previous contract and start from date of effect

            CurrentContract.ContractStartDate = EffDate
            If contractypeId = Enums.ContractTypes.TotallyAssured Then
                CurrentContract.ContractEndDate = EffDate.AddYears(1).AddDays(-1)
                CurrentContract.FirstInvoiceDate = Today
            Else
                CurrentContract.ContractEndDate = OldEndDate
            End If

            Return True
        Else
            Throw New Exception("Effective date less than contract start date")
        End If

        Return False
    End Function

    Private Sub NextVisit()

        Dim RandomClass As New Random()
        Dim d As Object = DB.ExecuteScalar("select MAX(Startdatetime) from tblEngineerVisit ev inner join tblJobOfWork jow on jow.JobOfWorkID = ev.JobOfWorkID inner join tblJob j on j.JobID = jow.JobID where j.JobTypeID in (4702,519) and OutcomeEnumID in (1) and SiteID = " & SiteID)
        Dim enddate As Date

        If DateDiff(DateInterval.Day, CurrentContract.ContractStartDate, CurrentContract.ContractEndDate) > 366 Then
            enddate = CurrentContract.ContractStartDate.AddYears(1)
        Else
            enddate = CurrentContract.ContractEndDate
        End If

        If IsDBNull(d) Then
            d = New Date(Today.AddYears(-1).Year, 6, 15)
            If d.AddYears(1) < CurrentContract.ContractStartDate Then

                If CurrentContract.ContractStartDate.DayOfYear < 91 Then ' does contract end in the excluded months
                    newdate = New Date(CurrentContract.ContractStartDate.Year, 1, 1).AddDays(91 + RandomClass.Next(0, 30))
                ElseIf enddate.DayOfYear > 275 Then
                    newdate = New Date(enddate.Year, 1, 1).AddDays(275 - RandomClass.Next(0, 30))
                Else
                    newdate = CurrentContract.ContractStartDate.AddDays(5 + RandomClass.Next(0, 20))
                End If

            ElseIf d.AddYears(1) > enddate Then

                If enddate.DayOfYear > 275 Then
                    newdate = New Date(enddate.Year, 1, 1).AddDays(275 - RandomClass.Next(0, 30))
                Else
                    newdate = New Date(enddate.Year, 1, 1).AddDays(-RandomClass.Next(0, 10))
                End If

            ElseIf d.AddYears(1).DayOfYear < 91 Then ' in march or less
                newdate = New Date(d.AddYears(1).Year, 1, 1).AddDays(91 + RandomClass.Next(0, 30))
                If newdate > enddate Then
                    newdate = d.AddYears(1).AddDays(-180)
                End If
            ElseIf d.AddYears(1).DayOfYear > 275 Then ' in october or more
                newdate = New Date(d.AddYears(1).Year, 1, 1).AddDays(275 - RandomClass.Next(0, 30))
                If newdate < CurrentContract.ContractStartDate Then
                    newdate = d.AddYears(1).AddDays(180)
                End If
            Else
                newdate = CDate(d).AddYears(1)
            End If
        End If

        If chkLandlord.Checked = True Then
            newdate = CDate(d).AddYears(1)
            If newdate > enddate Then
                newdate = enddate.AddDays(-3)
            ElseIf newdate < CurrentContract.ContractStartDate Then
                newdate = CurrentContract.ContractStartDate.AddDays(3)
            End If
        Else
            If d.AddYears(1) < CurrentContract.ContractStartDate Then

                If CurrentContract.ContractStartDate.DayOfYear < 91 Then ' does contract end in the excluded months
                    newdate = New Date(CurrentContract.ContractStartDate.Year, 1, 1).AddDays(91 + RandomClass.Next(0, 30))
                ElseIf enddate.DayOfYear > 275 Then
                    newdate = New Date(enddate.Year, 1, 1).AddDays(275 - RandomClass.Next(0, 30))
                Else
                    newdate = CurrentContract.ContractStartDate.AddDays(5 + RandomClass.Next(0, 20))
                End If

            ElseIf d.AddYears(1) > enddate Then

                If enddate.DayOfYear > 275 Then
                    newdate = New Date(enddate.Year, 1, 1).AddDays(275 - RandomClass.Next(0, 30))
                Else
                    newdate = New Date(enddate.Year, 1, 1).AddDays(-RandomClass.Next(0, 10))
                End If

            ElseIf d.AddYears(1).DayOfYear < 91 Then ' in march or less
                newdate = New Date(d.AddYears(1).Year, 1, 1).AddDays(91 + RandomClass.Next(0, 30))
                If newdate > enddate Then
                    newdate = d.AddYears(1).AddDays(-180)
                End If
            ElseIf d.AddYears(1).DayOfYear > 275 Then ' in october or more
                newdate = New Date(d.AddYears(1).Year, 1, 1).AddDays(275 - RandomClass.Next(0, 30))
                If newdate < CurrentContract.ContractStartDate Then
                    newdate = d.AddYears(1).AddDays(180)
                End If
            Else
                newdate = CDate(d).AddYears(1).AddDays(-1)
            End If
        End If
        If newdate < CurrentContract.ContractStartDate.Date Or newdate >= CurrentContract.ContractEndDate.Date Then
            newdate = CurrentContract.ContractEndDate.AddMonths(-6)
        End If

    End Sub

    Private Sub ScheduleJob()
        Try
            'Duration OF Contract In Days
            Dim contractDuration As Integer
            'contractDuration = CurrentContract.ContractEndDate.Subtract(CurrentContract.ContractStartDate).Days

            ''New Way
            Dim startDate As DateTime = DateHelper.GetDateZeroTime(CurrentContract.ContractStartDate)
            Dim endDate As DateTime = DateHelper.GetDateZeroTime(CurrentContract.ContractEndDate.AddDays(1))

            contractDuration = endDate.Subtract(startDate).Days
            Dim M As Integer = Math.Abs((startDate.Year - endDate.Year))
            Dim months As Integer = ((M * 12) + Math.Abs((startDate.Month - endDate.Month)))
            ' months = months * Combo.GetSelectedItemValue(cboPeriod)
            Dim days As Integer = endDate.Subtract(startDate).Days

            'How Visit Should happen in days ' NOOOOOOO
            Dim numOfVisits As Integer = 0
            Dim visitFreqInMonths As Integer = 0
            Dim visitFreqIndays As Integer = 0

            Select Case CType(CurrentContractSite.VisitFrequencyID, Enums.VisitFrequency)
                Case Enums.VisitFrequency.Annually
                    visitFreqInMonths = 12
                Case Enums.VisitFrequency.Bi_Annually
                    visitFreqInMonths = 6
                Case Enums.VisitFrequency.Monthly
                    visitFreqInMonths = 1
                Case Enums.VisitFrequency.Quarterly
                    visitFreqInMonths = 3
                Case Enums.VisitFrequency.GBS_4_Month_Visits
                    visitFreqInMonths = 4
                Case Enums.VisitFrequency.Fortnightly
                    visitFreqIndays = 14
            End Select

            If visitFreqIndays = 0 Then
                numOfVisits = Math.Floor(months / visitFreqInMonths)
                If numOfVisits = 0 Then
                    numOfVisits = 1
                End If
            ElseIf visitFreqIndays > 0 Then
                numOfVisits = Math.Floor(days / visitFreqIndays)
                If numOfVisits = 0 Then
                    numOfVisits = 1
                End If
            End If

            If newdate = Nothing Then
                NextVisit()
            End If

            Dim estVisitDate As DateTime = newdate.Date & " 09:00:00"  ' TODO
            Dim jobSummary As String = String.Empty
            Dim rateCount As Integer = 0

            If CBT(txtMainAppCount.Text) > 0 Then
                If rateCount > 0 Then
                    jobSummary += " And "
                End If
                If CBT(txtMainAppCount.Text) > 1 Then
                    jobSummary += CBT(txtMainAppCount.Text) & " x " & "Service Primary Coverplan Appliances"
                Else
                    jobSummary += "Service Primary Coverplan Appliance"
                End If
                rateCount += 1
            End If

            If CBT(txtSecondryCount.Text) > 0 Then
                If rateCount > 0 Then
                    jobSummary += " And "
                End If
                If CBT(txtSecondryCount.Text) > 1 Then
                    jobSummary += CBT(txtSecondryCount.Text) & " x " & "Service Additional Coverplan Appliances"
                Else
                    jobSummary += "Service Additional Coverplan Appliance"
                End If
                rateCount += 1
            End If

            If CurrentContractSite.LLCertReqd = True Then
                If jobSummary.Length > 0 Then
                    jobSummary += ". "
                End If
                jobSummary += "Landlord Certificate Required"
            End If

            If jobSummary.Length > 0 Then
                jobSummary += ". "
            End If

            jobSummary += CurrentContractSite.AdditionalNotes

            For i As Integer = 1 To numOfVisits
                If DateHelper.GetDateZeroTime(estVisitDate) >= DateHelper.GetDateZeroTime(CurrentContract.ContractStartDate) And
                     DateHelper.GetDateZeroTime(estVisitDate) <= DateHelper.GetDateZeroTime(CurrentContract.ContractEndDate) Then

                    'MAKE SURE WE DON'T BOOK A SATURADY OR SUNDAY
                    If estVisitDate.DayOfWeek = DayOfWeek.Saturday Then
                        estVisitDate = estVisitDate.AddDays(2)
                    ElseIf estVisitDate.DayOfWeek = DayOfWeek.Sunday Then
                        estVisitDate = estVisitDate.AddDays(1)
                    End If

                    'CREATE JOB
                    Dim job As New Entity.Jobs.Job
                    job.SetPropertyID = CurrentContractSite.PropertyID
                    job.SetJobDefinitionEnumID = CInt(Enums.JobDefinition.Contract)
                    If chkCommercial.Checked Then
                        job.SetJobTypeID = DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Commercial'")(0).Item("ManagerID")
                    ElseIf chkLandlord.Checked Then
                        job.SetJobTypeID = DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Service and Certificate'")(0).Item("ManagerID")
                    Else
                        job.SetJobTypeID = DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Service'")(0).Item("ManagerID")
                    End If

                    job.SetStatusEnumID = CInt(Enums.JobStatus.Open)
                    job.SetCreatedByUserID = loggedInUser.UserID
                    job.SetFOC = True
                    Dim JobNumber As New JobNumber
                    JobNumber = DB.Job.GetNextJobNumber(Enums.JobDefinition.Contract)
                    job.SetJobNumber = JobNumber.Prefix & JobNumber.JobNumber
                    job.SetPONumber = ""
                    job.SetQuoteID = 0
                    job.SetContractID = CurrentContract.ContractID

                    If CType(CurrentContract.ContractStatusID, Enums.ContractStatus) = Enums.ContractStatus.Inactive Then
                        job.SetDeleted = True
                    End If

                    'INSERT ANY ASSETS
                    For Each dr As DataRow In MainDataView.Table.Rows
                        Dim JobAsset As New Entity.JobAssets.JobAsset
                        JobAsset.SetAssetID = dr("AssetID")
                        job.Assets.Add(JobAsset)
                    Next

                    For Each dr As DataRow In SecondAppliances.Table.Rows
                        Dim JobAsset As New Entity.JobAssets.JobAsset
                        JobAsset.SetAssetID = dr("AssetID")
                        job.Assets.Add(JobAsset)
                    Next

                    ' INSERT JOB ITEM
                    Dim jobOfWork As New Entity.JobOfWorks.JobOfWork
                    jobOfWork.SetPONumber = ""
                    jobOfWork.IgnoreExceptionsOnSetMethods = True
                    If CType(CurrentContract.ContractStatusID, Enums.ContractStatus) = Enums.ContractStatus.Inactive Then
                        jobOfWork.SetDeleted = True
                    End If

                    Dim site As Entity.Sites.Site = DB.Sites.Get(CurrentContractSite.PropertyID)

                    If CBT(txtMainAppCount.Text) > 0 Then

                        Dim customerSors As DataTable = DB.CustomerScheduleOfRate.Exists(4700, "Service Primary Coverplan Appliance", "CS1", site.CustomerID)
                        Dim customerSorId As Integer = 0
                        If customerSors.Rows.Count > 0 Then customerSorId = Helper.MakeIntegerValid(customerSors.Rows(0)(0))

                        If Not customerSorId > 0 Then
                            Dim customerSor As New CustomerScheduleOfRates.CustomerScheduleOfRate With {
                                .SetCode = "CS1",
                                .SetDescription = "Service Primary Coverplan Appliance",
                                .SetPrice = 0.0,
                                .SetScheduleOfRatesCategoryID = 4700,
                                .SetTimeInMins = 50,
                                .SetCustomerID = site.CustomerID
                            }
                            customerSorId = DB.CustomerScheduleOfRate.Insert(customerSor).CustomerScheduleOfRateID
                            DB.CustomerScheduleOfRate.Delete(customerSorId)
                        End If

                        Dim jobItem As New JobItems.JobItem
                        jobItem.IgnoreExceptionsOnSetMethods = True
                        jobItem.SetSummary = "Service Primary Coverplan Appliance"
                        jobItem.SetQty = txtMainAppCount.Text
                        jobItem.SetRateID = customerSorId
                        jobItem.SetSystemLinkID = CInt(Enums.TableNames.tblCustomerScheduleOfRate)
                        jobOfWork.JobItems.Add(jobItem)

                    End If

                    If CBT(txtSecondryCount.Text) > 0 Then

                        Dim customerSors As DataTable = DB.CustomerScheduleOfRate.Exists(4700, "Service Additional Coverplan Appliance", "CS2", site.CustomerID)
                        Dim customerSorId As Integer = 0
                        If customerSors.Rows.Count > 0 Then customerSorId = Helper.MakeIntegerValid(customerSors.Rows(0)(0))

                        If Not customerSorId > 0 Then
                            Dim customerSor As New CustomerScheduleOfRates.CustomerScheduleOfRate With {
                                .SetCode = "CS2",
                                .SetDescription = "Service Additional Coverplan Appliance",
                                .SetPrice = 0.0,
                                .SetScheduleOfRatesCategoryID = 4700,
                                .SetTimeInMins = 30,
                                .SetCustomerID = site.CustomerID
                            }
                            customerSorId = DB.CustomerScheduleOfRate.Insert(customerSor).CustomerScheduleOfRateID
                            DB.CustomerScheduleOfRate.Delete(customerSorId)
                        End If

                        Dim jobItem As New JobItems.JobItem
                        jobItem.IgnoreExceptionsOnSetMethods = True
                        jobItem.SetSummary = "Service Additional Coverplan Appliance"
                        jobItem.SetQty = txtSecondryCount.Text
                        jobItem.SetRateID = customerSorId
                        jobItem.SetSystemLinkID = CInt(Enums.TableNames.tblCustomerScheduleOfRate)
                        jobOfWork.JobItems.Add(jobItem)
                    End If

                    If jobOfWork.JobItems.Count = 0 Then
                        Dim jobItem As New Entity.JobItems.JobItem
                        jobItem.IgnoreExceptionsOnSetMethods = True
                        jobItem.SetSummary = jobSummary

                        jobOfWork.JobItems.Add(jobItem)
                    End If

                    'NOW SEE IF WE CAN FIND A MATCHING ENGINEER
                    'IF WE FIND A MATCHING ENGINEER INSERT ENGINEER VISIT
                    Dim engineerVisit As New Entity.EngineerVisits.EngineerVisit
                    engineerVisit.IgnoreExceptionsOnSetMethods = True
                    engineerVisit.SetEngineerID = 0 'engineerID

                    engineerVisit.SetNotesToEngineer = jobSummary
                    If chkLandlord.Checked = True Then
                        engineerVisit.SetNotesToEngineer = "DUE " & Format(estVisitDate, "dd/MM/yyyy") & " " & engineerVisit.NotesToEngineer

                    End If

                    engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer & " Covered by " & Combo.GetSelectedItemDescription(cboContractType)
                    engineerVisit.StartDateTime = DateTime.MinValue
                    engineerVisit.EndDateTime = DateTime.MinValue
                    engineerVisit.SetStatusEnumID = CInt(Enums.VisitStatus.Ready_For_Schedule)

                    If CType(CurrentContract.ContractStatusID, Enums.ContractStatus) = Enums.ContractStatus.Inactive Then
                        engineerVisit.SetDeleted = True
                    End If

                    jobOfWork.EngineerVisits.Add(engineerVisit)
                    job.JobOfWorks.Add(jobOfWork)
                    job = DB.Job.Insert(job)

                    'CREATE PPM VISIT RECORD
                    Dim PPM As New Entity.ContractOriginalPPMVisits.ContractOriginalPPMVisit
                    PPM.SetContractSiteID = CurrentContractSite.ContractSiteID
                    PPM.EstimatedVisitDate = estVisitDate
                    PPM.SetJobID = job.JobID
                    DB.ContractOriginalPPMVisit.Insert(PPM)
                    If visitFreqIndays = 0 Then
                        estVisitDate = estVisitDate.AddMonths(visitFreqInMonths)
                    ElseIf visitFreqIndays > 0 Then
                        estVisitDate = estVisitDate.AddDays(visitFreqIndays)
                    End If
                End If
            Next i
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function InsertInvoiceToBeRaiseLines(Optional ByVal part As Boolean = False, Optional ByVal contractChanged As Boolean = False) As Integer
        Dim startDate As DateTime
        Dim endDate As DateTime

        If part = False Then
            startDate = Format(CurrentContract.ContractStartDate, "dd/MM/yyyy") & " 00:00:00"
            endDate = Format(CurrentContract.ContractEndDate.AddDays(1), "dd/MM/yyyy") & " 00:00:00"
        Else
            startDate = Format(New Date(EffDate.Year, EffDate.Month, 1).AddMonths(1), "dd/MM/yyy") & " 00:00:00"
            endDate = Format(CurrentContract.ContractEndDate.AddDays(1), "dd/MM/yyyy") & " 00:00:00"
        End If

        Dim days As Integer = endDate.Subtract(startDate).Days
        Dim numberOfMonths As Integer = DateDiff(DateInterval.Month, startDate, endDate)
        Dim numberOfInvoicesToRaise As Integer = 0

        Select Case CType(CurrentContract.InvoiceFrequencyID, Enums.InvoiceFrequency_NoWeeK)
            Case Enums.InvoiceFrequency_NoWeeK.Annually,
                 Enums.InvoiceFrequency_NoWeeK.AnnuallyDD
                numberOfInvoicesToRaise = 1

            Case Enums.InvoiceFrequency_NoWeeK.Bi_Annually
                numberOfInvoicesToRaise = numberOfMonths / 6

            Case Enums.InvoiceFrequency_NoWeeK.Monthly
                numberOfInvoicesToRaise = numberOfMonths / 1

            Case Enums.InvoiceFrequency_NoWeeK.Per_Visit
                'Invoice the visit
            Case Enums.InvoiceFrequency_NoWeeK.Quarterly
                numberOfInvoicesToRaise = numberOfMonths / 3

            Case Enums.InvoiceFrequency_NoWeeK.GBS_4_Month_Visits
                numberOfInvoicesToRaise = numberOfMonths / 4
        End Select

        If numberOfInvoicesToRaise < 1 Then
            numberOfInvoicesToRaise = 1
        End If

        If (contractChanged AndAlso CurrentContract.ContractTypeID = Enums.ContractTypes.TotallyAssured) Or
            CurrentContract.ContractTypeID = Enums.ContractTypes.EmployeeFree Or
            CurrentContract.ContractTypeID = Enums.ContractTypes.FamilyFree Then
            Return 0
        End If

        Dim raiseDate As DateTime = CurrentContract.FirstInvoiceDate ' same as contract
        For i As Integer = 1 To numberOfInvoicesToRaise
            Dim invToBeRaised As New Entity.InvoiceToBeRaiseds.InvoiceToBeRaised
            invToBeRaised.SetAddressLinkID = CurrentContract.InvoiceAddressID
            invToBeRaised.SetAddressTypeID = CurrentContract.InvoiceAddressTypeID
            invToBeRaised.SetInvoiceTypeID = CInt(Enums.InvoiceType.Contract_Option1)
            invToBeRaised.SetLinkID = CurrentContract.ContractID
            invToBeRaised.RaiseDate = raiseDate
            DB.InvoiceToBeRaised.Insert(invToBeRaised)
            If Combo.GetSelectedItemValue(cboPaymentType) = Enums.ContractPaymentType.Direct_Debit And
                i = 1 And Offset Then 'D/D paid upfront so next D/D will skip a month
                raiseDate = New Date(raiseDate.Year, raiseDate.Month, 1).AddMonths(1)
            End If

            Select Case CType(CurrentContract.InvoiceFrequencyID, Enums.InvoiceFrequency_NoWeeK)
                Case Enums.InvoiceFrequency_NoWeeK.Annually,
                     Enums.InvoiceFrequency_NoWeeK.AnnuallyDD
                    raiseDate = raiseDate.AddYears(1)
                Case Enums.InvoiceFrequency_NoWeeK.Bi_Annually
                    raiseDate = raiseDate.AddMonths(6)
                Case Enums.InvoiceFrequency_NoWeeK.Monthly
                    raiseDate = raiseDate.AddMonths(1)
                Case Enums.InvoiceFrequency_NoWeeK.Quarterly
                    raiseDate = raiseDate.AddMonths(3)
                Case Enums.InvoiceFrequency_NoWeeK.GBS_4_Month_Visits
                    raiseDate = raiseDate.AddMonths(4)
            End Select
        Next
        Return numberOfInvoicesToRaise

    End Function

    Private Sub DoTotals()
        Dim total As Double = 0.0
        Dim inititalMultiplyer As Double = 1
        Dim AnnualMutliplier As Double = 1

        If Combo.GetSelectedItemValue(cboPaymentType) = Enums.ContractPaymentType.Direct_Debit And
            Combo.GetSelectedItemValue(cboInitialPaymentType) = CInt(Enums.ContractInitialPaymentType.CreditCard) Then ' direct debit initially paid by credit card 2.5% on first payment
            inititalMultiplyer = 1
        ElseIf Combo.GetSelectedItemValue(cboPaymentType) = Enums.ContractPaymentType.Annual And
            Combo.GetSelectedItemValue(cboInitialPaymentType) = CInt(Enums.ContractInitialPaymentType.CreditCard) Then 'annual payment with credit card 2.5% on total
            AnnualMutliplier = 1
        End If

        Select Case Combo.GetSelectedItemDescription(cboContractType)

            Case "Platinum Star"
                total = CDbl(DB.Picklists.Get_Single_Description("Platinum Star", 52))
                total = total * CInt(CBT(txtMainAppCount.Text))
                total = total + (CInt(CBT(txtSecondryCount.Text)) * CDbl(DB.Picklists.Get_Single_Description("Additional Appliance PLAT", 52)))

                If chkWindowLockPest.Checked And chkPlumbingDrainage.Checked And chkGasSupplyPipework.Checked Then
                    total = total + CDbl(DB.Picklists.Get_Single_Description("AHE", 52))
                Else
                    total = total - (CInt(chkGasSupplyPipework.Checked) * CDbl(DB.Picklists.Get_Single_Description("Gas Supply Pipework", 52)))
                    total = total - (CInt(chkPlumbingDrainage.Checked) * CDbl(DB.Picklists.Get_Single_Description("PDE", 52)))
                    total = total - (CInt(chkWindowLockPest.Checked) * CDbl(DB.Picklists.Get_Single_Description("WLP", 52)))
                End If

                total = total - ((total / 100) * discount)
                total = total * AnnualMutliplier
                lblTotalEst.Text = Format(total, "C")

                Dim theRounded As Double = Math.Round(total / 12, 2)

                lblMonthlyEst.Text = Format(((theRounded + (total - (theRounded * 12))) * inititalMultiplyer), "C")
                lblFollowedBy.Text = Format(theRounded, "C")

            Case "Platinum Star System"
                total = CDbl(DB.Picklists.Get_Single_Description("Platinum Star System", 52))
                total = total * CInt(CBT(txtMainAppCount.Text))
                total = total + (CInt(CBT(txtSecondryCount.Text)) * CDbl(DB.Picklists.Get_Single_Description("Additional Appliance PLAT", 52)))

                If chkWindowLockPest.Checked And chkPlumbingDrainage.Checked And chkGasSupplyPipework.Checked Then
                    total = total + CDbl(DB.Picklists.Get_Single_Description("AHE", 52))
                Else
                    total = total - (CInt(chkGasSupplyPipework.Checked) * CDbl(DB.Picklists.Get_Single_Description("Gas Supply Pipework", 52)))
                    total = total - (CInt(chkPlumbingDrainage.Checked) * CDbl(DB.Picklists.Get_Single_Description("PDE", 52)))
                    total = total - (CInt(chkWindowLockPest.Checked) * CDbl(DB.Picklists.Get_Single_Description("WLP", 52)))
                End If

                total = total - ((total / 100) * discount)
                total = total * AnnualMutliplier
                lblTotalEst.Text = Format(total, "C")

                Dim theRounded As Double = Math.Round(total / 12, 2)

                lblMonthlyEst.Text = Format(((theRounded + (total - (theRounded * 12))) * inititalMultiplyer), "C")
                lblFollowedBy.Text = Format(theRounded, "C")

            Case "Silver Star"
                total = CDbl(DB.Picklists.Get_Single_Description("Silver Star", 52))
                total = total * CInt(CBT(txtMainAppCount.Text))
                total = total + (CInt(CBT(txtSecondryCount.Text)) * CDbl(DB.Picklists.Get_Single_Description("Additional Appliance", 52)))

                If chkWindowLockPest.Checked And chkPlumbingDrainage.Checked And chkGasSupplyPipework.Checked Then
                    total = total + CDbl(DB.Picklists.Get_Single_Description("AHE", 52))
                Else
                    total = total - (CInt(chkGasSupplyPipework.Checked) * CDbl(DB.Picklists.Get_Single_Description("Gas Supply Pipework", 52)))
                    total = total - (CInt(chkPlumbingDrainage.Checked) * CDbl(DB.Picklists.Get_Single_Description("PDE", 52)))
                    total = total - (CInt(chkWindowLockPest.Checked) * CDbl(DB.Picklists.Get_Single_Description("WLP", 52)))
                End If
                total = total - ((total / 100) * discount)
                total = total * AnnualMutliplier
                lblTotalEst.Text = Format(total, "C")

                Dim theRounded As Double = Math.Round(total / 12, 2)

                lblMonthlyEst.Text = Format(((theRounded + (total - (theRounded * 12))) * inititalMultiplyer), "C")
                lblFollowedBy.Text = Format(theRounded, "C")

            Case "Platinum Immediate"
                total = CDbl(DB.Picklists.Get_Single_Description("Platinum Immediate", 52))
                total = total * CInt(CBT(txtMainAppCount.Text))
                total = total + (CInt(CBT(txtSecondryCount.Text)) * CDbl(DB.Picklists.Get_Single_Description("Additional Appliance PLAT", 52)))

                If chkWindowLockPest.Checked And chkPlumbingDrainage.Checked And chkGasSupplyPipework.Checked Then
                    total = total + CDbl(DB.Picklists.Get_Single_Description("AHE", 52))
                Else
                    total = total - (CInt(chkGasSupplyPipework.Checked) * CDbl(DB.Picklists.Get_Single_Description("Gas Supply Pipework", 52)))
                    total = total - (CInt(chkPlumbingDrainage.Checked) * CDbl(DB.Picklists.Get_Single_Description("PDE", 52)))
                    total = total - (CInt(chkWindowLockPest.Checked) * CDbl(DB.Picklists.Get_Single_Description("WLP", 52)))
                End If
                total = total - ((total / 100) * discount)
                total = total * AnnualMutliplier
                lblTotalEst.Text = Format(total, "C")

                Dim theRounded As Double = Math.Round(total / 12, 2)
                lblMonthlyEst.Text = Format(((theRounded + (total - (theRounded * 12))) * inititalMultiplyer), "C")
                lblFollowedBy.Text = Format(theRounded, "C")

            Case "Platinum Star Agency"
                total = CDbl(DB.Picklists.Get_Single_Description("Platinum Star Agency", 52))
                total = total / (1 + (discount / 100))
                total = total * AnnualMutliplier
                lblTotalEst.Text = Format(total, "C")

                Dim theRounded As Double = Math.Round(total / 12, 2)
                lblMonthlyEst.Text = Format(((theRounded + (total - (theRounded * 12))) * inititalMultiplyer), "C")
                lblFollowedBy.Text = Format(theRounded, "C")

            Case "Gold Star"
                total = CDbl(DB.Picklists.Get_Single_Description("Gold Star", 52))
                total = total * CInt(CBT(txtMainAppCount.Text))
                total = total + (CInt(CBT(txtSecondryCount.Text)) * CDbl(DB.Picklists.Get_Single_Description("Additional Appliance", 52)))

                If chkWindowLockPest.Checked And chkPlumbingDrainage.Checked And chkGasSupplyPipework.Checked Then
                    total = total + CDbl(DB.Picklists.Get_Single_Description("AHE", 52))
                Else
                    total = total - (CInt(chkGasSupplyPipework.Checked) * CDbl(DB.Picklists.Get_Single_Description("Gas Supply Pipework", 52)))
                    total = total - (CInt(chkPlumbingDrainage.Checked) * CDbl(DB.Picklists.Get_Single_Description("PDE", 52)))
                    total = total - (CInt(chkWindowLockPest.Checked) * CDbl(DB.Picklists.Get_Single_Description("WLP", 52)))
                End If
                total = total - ((total / 100) * discount)
                total = total * AnnualMutliplier
                lblTotalEst.Text = Format(total, "C")

                Dim theRounded As Double = Math.Round(total / 12, 2)
                lblMonthlyEst.Text = Format(((theRounded + (total - (theRounded * 12))) * inititalMultiplyer), "C")
                lblFollowedBy.Text = Format(theRounded, "C")

            Case "Gold Star Agency"
                total = CDbl(DB.Picklists.Get_Single_Description("Gold Star Agency", 52))
                total = total - ((total / 100) * discount)
                total = total * AnnualMutliplier
                lblTotalEst.Text = Format(total, "C")

                Dim theRounded As Double = Math.Round(total / 12, 2)
                lblMonthlyEst.Text = Format(((theRounded + (total - (theRounded * 12))) * inititalMultiplyer), "C")
                lblFollowedBy.Text = Format(theRounded, "C")

            Case "Totally Assured"
                total = CDbl(DB.Picklists.Get_Single_Description("TA", 52)) * Combo.GetSelectedItemValue(cboPeriod)
                total = total + (CInt(CBT(txtSecondryCount.Text)) * CDbl(DB.Picklists.Get_Single_Description("Additional Appliance PLAT", 52)))

                If chkWindowLockPest.Checked And chkPlumbingDrainage.Checked And chkGasSupplyPipework.Checked Then
                    total = total + CDbl(DB.Picklists.Get_Single_Description("AHE", 52))
                Else
                    total = total - (CInt(chkGasSupplyPipework.Checked) * CDbl(DB.Picklists.Get_Single_Description("Gas Supply Pipework", 52)))
                    total = total - (CInt(chkPlumbingDrainage.Checked) * CDbl(DB.Picklists.Get_Single_Description("PDE", 52)))
                    total = total - (CInt(chkWindowLockPest.Checked) * CDbl(DB.Picklists.Get_Single_Description("WLP", 52)))
                End If

                total = total - ((total / 100) * discount)
                total = total * AnnualMutliplier
                lblTotalEst.Text = Format(total, "C")

                Dim theRounded As Double = Math.Round((total / (Combo.GetSelectedItemValue(cboPeriod) * 12)), 2)
                Dim offset As Double = (total - (theRounded * (Combo.GetSelectedItemValue(cboPeriod) * 12)))
                lblMonthlyEst.Text = Format(((theRounded + offset) * inititalMultiplyer), "C")
                lblFollowedBy.Text = Format(theRounded, "C")

            Case "Preventative Maintenance Contract", "Employee Free", "Family Free Give Away"
                total = 0
                discount = 0
                lblMonthlyEst.Text = Format(0, "C")
                lblFollowedBy.Text = Format(0, "C")
                lblTotalEst.Text = Format(total, "C")
            Case Else
                If b?.Text = "Renew Contract" And Not OverridePrice Then
                    Dim f As New FRMNewPrice
                    f.ShowDialog()
                    If IsNumeric(f.txtPrice.Text) AndAlso CDbl(f.txtPrice.Text) > 0 Then
                        lblTotalEst.Text = Format(CDbl(f.txtPrice.Text), "C")
                        lblMonthlyEst.Text = Format(CDbl(lblTotalEst.Text) / 12, "C")
                        lblFollowedBy.Text = Format(CDbl(lblTotalEst.Text) / 12, "C")
                        OverridePrice = True

                        total = CDbl(f.txtPrice.Text)
                        discount = 0
                    End If
                End If
        End Select

        If Not b Is Nothing AndAlso b.Text = "Amend Contract" AndAlso lblMonthlyEst.Text <> "" Then

            Dim CurrentRemainMonth As Double = 0
            Dim FutureRemainMonth As Double = 0
            If workingdays(CurrentContract.ContractStartDate, New Date(Today.Year, Today.Month, Today.Day).AddMonths(1)) < 11 Then  ' have we already taken the first payment?
            Else
                CurrentRemainMonth = CDbl(previousSecond)
                FutureRemainMonth = CDbl(lblFollowedBy.Text)

                Dim totalamount As Double = ((lblTotalEst.Text / 12) * DateDiff(DateInterval.Month, Today, CurrentContract.ContractEndDate))
                Dim futurechange As Decimal = Math.Round(totalamount - CurrentRemainMonth, 2)
                If totalamount <> (CurrentRemainMonth * DateDiff(DateInterval.Month, Today, CurrentContract.ContractEndDate)) Then

                    Dim theRounded As Double = Math.Round(((totalamount / DateDiff(DateInterval.Month, Today, CurrentContract.ContractEndDate))), 2)
                    Dim offset As Double = (totalamount - (theRounded * DateDiff(DateInterval.Month, Today, CurrentContract.ContractEndDate)))
                    lblMonthlyEst.Text = Format(((theRounded + offset) * inititalMultiplyer), "C")
                    lblFollowedBy.Text = Format(theRounded, "C")

                End If
            End If
        End If
    End Sub

    Function CBT(ByVal s As String) As String
        If IsNumeric(s) Then s = s Else s = "0"
        Return s
    End Function

    Public Sub ContractDrop()
        Dim dt As DataTable = DB.ContractOriginal.GetAll_ForSite_Active(SiteID).Table

        cboContract.Items.Clear()

        For Each dr As DataRow In dt.Rows
            cboContract.Items.Add(New Combo(dr("ContractReference") & " : " & dr("ContractStartDate") & " to " & dr("ContractEndDate"), dr("ContractID") & "`" & dr("ContractSiteID")))
        Next
        cboContract.Items.Add(New Combo("-- Please Select --", 0))

        cboContract.DisplayMember = "Description"
        cboContract.ValueMember = "Value"

        Combo.SetSelectedComboItem_By_Value(cboContract, "0")
    End Sub

    Public Sub CloseForm()
        If Not Number Is Nothing And NumberUsed = False Then
            DB.Job.DeleteReservedOrderNumber(Number.JobNumber, Number.Prefix)
        End If
        Me.Dispose()
    End Sub

    Public Sub PayerDrop()
        Dim dt As DataTable = DB.InvoiceAddress.InvoiceAddress_Get_SiteID(SiteID).Table

        cboPAyer.Items.Clear()

        For Each dr As DataRow In dt.Rows
            cboPAyer.Items.Add(New Combo(dr("Address1") & "," & dr("Address2") & "," & dr("Postcode"), dr("AddressID") & "`" & dr("AddressTypeID")))
        Next
        cboPAyer.Items.Add(New Combo("-- Please Select --", 0))

        cboPAyer.DisplayMember = "Description"
        cboPAyer.ValueMember = "Value"

        Combo.SetSelectedComboItem_By_Value(cboPAyer, "0")
    End Sub

    Public Sub ProcessContracts()
        If Not CurrentContract Is Nothing AndAlso CurrentContract.ContractID > 0 Then

            Dim dtContracts As DataTable = DB.ContractOriginal.ProcessContract(CurrentContract.ContractID)
            If dtContracts Is Nothing Then Exit Sub
            Try
                Dim details As New ArrayList
                Dim oPrint As New Printing(details, "ContractBatch", Enums.SystemDocumentType.ContractBatch, True, 0, True, dt:=dtContracts)
                Dim ar As ArrayList = oPrint.MultiEmail
                Process.Start(ar(0))
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ProcessExpiry()
        Dim failed As Boolean = False
        Dim ContractsDT As DataTable

        If CurrentContract.ContractID > 0 Then
            Try
                ContractsDT = DB.ContractOriginal.Contract_Get_Renewal(CurrentContract.ContractID).Table
                ContractsDT.Columns.Add("RenewalPrice")

                If ContractsDT.Select("InvoiceFrequencyID = 6").Length > 0 Then

                    'calculate and if sucsessfull add it as new to database the next main function will raise the renewal details
                    If ContractsDT.Rows(0).Item("ContractTypeID") = Enums.ContractTypes.PreventativeMaintenance Then
                        Dim f As New FRMNewPrice
                        f.ShowDialog()
                        If IsNumeric(f.txtPrice.Text) AndAlso CDbl(f.txtPrice.Text) > 0 Then
                            ContractsDT.Rows(0)("RenewalPrice") = CDbl(f.txtPrice.Text)
                            OverridePrice = True
                        Else
                            ShowMessage("Please enter amount without commas or pound sign", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    Else
                        Dim newprice As Double = CalculateNewRateAndRenew(ContractsDT.Rows(0))
                        ContractsDT.Rows(0)("RenewalPrice") = newprice
                    End If

                    Dim details As New ArrayList
                    Dim oPrint As New Printing(details, "ContractExpiry", Enums.SystemDocumentType.ContractExpiry, True, 0, True, dt:=ContractsDT)
                    Dim ar As ArrayList = oPrint.MultiEmail
                    Process.Start(ar(0))
                End If
            Catch ex As Exception
                failed = True
            End Try
        End If
    End Sub

    Public Function CalculateNewRateAndRenew(ByVal dr As DataRow) As Double
        Dim divider As Decimal = (DateDiff(DateInterval.Year, CDate(dr("ContractStartDate")), CDate(dr("ContractEndDate")).AddDays(+10)))
        If divider = 0 Then divider = 1

        Dim OldPrice As Double = (dr("ContractPrice") / divider) * 1.2 ' inc vat

        Dim MainApps As Integer = 0
        Dim SecondryApps As Integer = 0

        Dim dt As DataTable = DB.ContractOriginalSiteAsset.GetAll_ContractSiteID(dr("ContractSiteID"), dr("siteid")).Table

        dt.Columns.Add("PrimaryAsset")

        If IsDBNull(dr("MainAppliances")) AndAlso IsDBNull(dr("SecondryAppliances")) Then
            'code to determin how many appliances

            Dim Backboiler As String = ""
            Dim count As Integer = 0
            For Each r As DataRow In dt.Select("Tick = 1")
                If r("product").ToString.Split("-")(0).Trim = "Back Boiler" Or r("product").ToString.Split("-")(0).Trim = "Warm Air unit" Then
                    Backboiler = r("product").ToString.Split("-")(1).Trim
                End If
                If r("product").ToString.Split("-")(0).Trim = "Back Boiler" Or r("product").ToString.Split("-")(0).Trim = "Oil Boiler" Or
                    r("product").ToString.Split("-")(0).Trim = "Air Source Heat Pump" Or r("product").ToString.Split("-")(0).Trim = "Cond Boiler" Or
                    r("product").ToString.Split("-")(0).Trim = "Cond Boiler Store" Or r("product").ToString.Split("-")(0).Trim = "Cond Combi" Or
                    r("product").ToString.Split("-")(0).Trim = "Std Eff Boiler" Or r("product").ToString.Split("-")(0).Trim = "Std Eff Boiler Store" Or
                    r("product").ToString.Split("-")(0).Trim = "Std Eff Combi" Or r("product").ToString.Split("-")(0).Trim = "Warn Air Unit" Then
                    MainApps += 1
                    dt.Rows(count)("PrimaryAsset") = True
                Else
                    SecondryApps += 1
                    dt.Rows(count)("PrimaryAsset") = False
                End If
                count += 1
            Next
            For Each r As DataRow In dt.Select("Tick = 1")
                If Backboiler = r("product").ToString.Split("-")(1).Trim AndAlso (r("product").ToString.Split("-")(0).Trim = "Gas Fire" Or r("product").ToString.Split("-")(0).Trim = "Circulator") Then
                    SecondryApps += -1
                    Exit For
                End If
            Next
        Else
            MainApps = dr("MainAppliances")
            SecondryApps = dr("SecondryAppliances")

            Dim m2 As Integer = 0
            Dim s2 As Integer = 0
            Dim Backboiler As String = ""
            Dim count As Integer = 0
            For Each r As DataRow In dt.Select("Tick = 1")
                If r("product").ToString.Split("-")(0).Trim = "Back Boiler" Or r("product").ToString.Split("-")(0).Trim = "Warm Air unit" Then
                    Backboiler = r("product").ToString.Split("-")(1).Trim
                End If
                If r("product").ToString.Split("-")(0).Trim = "Back Boiler" Or r("product").ToString.Split("-")(0).Trim = "Oil Boiler" Or
                    r("product").ToString.Split("-")(0).Trim = "Air Source Heat Pump" Or r("product").ToString.Split("-")(0).Trim = "Cond Boiler" Or
                    r("product").ToString.Split("-")(0).Trim = "Cond Boiler Store" Or r("product").ToString.Split("-")(0).Trim = "Cond Combi" Or
                    r("product").ToString.Split("-")(0).Trim = "Std Eff Boiler" Or r("product").ToString.Split("-")(0).Trim = "Std Eff Boiler Store" Or
                    r("product").ToString.Split("-")(0).Trim = "Std Eff Combi" Or r("product").ToString.Split("-")(0).Trim = "Warn Air Unit" Then
                    m2 += 1
                    dt.Rows(count)("PrimaryAsset") = True
                Else
                    s2 += 1
                    dt.Rows(count)("PrimaryAsset") = False
                End If
                count += 1
            Next
            For Each r As DataRow In dt.Select("Tick = 1")
                If Backboiler = r("product").ToString.Split("-")(1).Trim AndAlso (r("product").ToString.Split("-")(0).Trim = "Gas Fire" Or r("product").ToString.Split("-")(0).Trim = "Circulator") Then
                    s2 += -1
                    Exit For
                End If
            Next

            If MainApps + SecondryApps < 1 Then
                MainApps = m2
                SecondryApps = s2
            End If
        End If

        Dim DiscountID As Integer = 0

        If Not IsDBNull(dr("DiscountID")) Then
            DiscountID = dr("DiscountID")
        End If

        Dim diff As Integer = DateDiff(DateInterval.Year, dr("ContractStartDate"), CDate(dr("ContractEndDate")).AddDays(10))
        If diff = 0 Then diff = 1
        Dim conttype As Integer = dr("ContractTypeID")
        If conttype = 68032 Then conttype = Enums.ContractTypes.PlatinumStar '(convert a PI to a PS it will fail price check sooo...)

        Dim newtotal() As Double = Gettotal(conttype, MainApps, SecondryApps, dr("WindowLockPest"), dr("PlumbingDrainage"), dr("GasSupplyPipework"), DiscountID, diff)

        If (newtotal(0) / OldPrice > 1.1 And (Not dr("ContractTypeID") = 68032)) Or (newtotal(0) / OldPrice < 0.9 And (Not dr("ContractTypeID") = 68032)) Then  'Added failure (create) if PI
            ' the price has swung too much something is wrong
            newtotal(0) = 0
        End If
        Return newtotal(0)
    End Function

    Function Gettotal(ByVal ContractTypeID As Integer, ByVal Main As Integer, ByVal Add As Integer,
                      ByVal WindowsLocks As Boolean, ByVal PlumbingDrainage As Boolean,
                      ByVal GasSupply As Boolean, ByVal DiscountID As Integer, ByVal Years As Integer) As Double()

        Dim newprice As Double() = {0.01, 0.01, 0.01}
        Dim Discount As Double = 0
        If Not IsDBNull(DiscountID) AndAlso DiscountID > 0 Then
            Discount = DB.Picklists.Get_One_As_Object(DiscountID).PercentageRate()
        End If

        If Main = 0 And Add > 1 Then   'sort out primary applaince
            Main = 1
            Add = Add - 1
        End If

        If Main = 0 And Add = 0 Then
            Main = 1
        End If

        Select Case (ContractTypeID)
            Case Enums.ContractTypes.PlatinumStar
                newprice(0) = CDbl(DB.Picklists.Get_Single_Description("Platinum Star", 52))
                newprice(0) = newprice(0) * Main
                newprice(0) = newprice(0) + (Add * CDbl(DB.Picklists.Get_Single_Description("Additional Appliance PLAT", 52)))

                If WindowsLocks And PlumbingDrainage And GasSupply Then
                    newprice(0) = newprice(0) + CDbl(DB.Picklists.Get_Single_Description("AHE", 52))
                Else
                    newprice(0) = newprice(0) - (GasSupply * CDbl(DB.Picklists.Get_Single_Description("Gas Supply Pipework", 52)))
                    newprice(0) = newprice(0) - (PlumbingDrainage * CDbl(DB.Picklists.Get_Single_Description("PDE", 52)))
                    newprice(0) = newprice(0) - (WindowsLocks * CDbl(DB.Picklists.Get_Single_Description("WLP", 52)))
                End If
                newprice(0) = newprice(0) - ((newprice(0) / 100) * Discount)

                Dim theRounded As Double = Math.Round(newprice(0) / 12, 2)

                newprice(1) = Format(theRounded + (newprice(0) - (theRounded * 12)), "C") ' First Month
                newprice(2) = Format(theRounded, "C")  ' followed by

            Case Enums.ContractTypes.PlatinumImmediate
                newprice(0) = CDbl(DB.Picklists.Get_Single_Description("Platinum Immediate", 52))
                newprice(0) = newprice(0) * Main
                newprice(0) = newprice(0) + (Add * CDbl(DB.Picklists.Get_Single_Description("Additional Appliance PLAT", 52)))

                If WindowsLocks And PlumbingDrainage And GasSupply Then
                    newprice(0) = newprice(0) + CDbl(DB.Picklists.Get_Single_Description("AHE", 52))
                Else
                    newprice(0) = newprice(0) - (GasSupply * CDbl(DB.Picklists.Get_Single_Description("Gas Supply Pipework", 52)))
                    newprice(0) = newprice(0) - (PlumbingDrainage * CDbl(DB.Picklists.Get_Single_Description("PDE", 52)))
                    newprice(0) = newprice(0) - (WindowsLocks * CDbl(DB.Picklists.Get_Single_Description("WLP", 52)))
                End If
                newprice(0) = newprice(0) - ((newprice(0) / 100) * Discount)

                Dim theRounded As Double = Math.Round(newprice(0) / 12, 2)
                newprice(1) = Format(theRounded + (newprice(0) - (theRounded * 12)), "C")
                newprice(2) = Format(theRounded, "C")

            Case 67353 'TODO old possible drop
                newprice(0) = CDbl(DB.Picklists.Get_Single_Description("Platinum Star Agency", 52))
                newprice(0) = newprice(0) - ((newprice(0) / 100) * Discount)

                Dim theRounded As Double = Math.Round(newprice(0) / 12, 2)
                newprice(1) = Format(theRounded + (newprice(0) - (theRounded * 12)), "C")
                newprice(2) = Format(theRounded, "C")

            Case Enums.ContractTypes.GoldStar
                newprice(0) = CDbl(DB.Picklists.Get_Single_Description("Gold Star", 52))
                newprice(0) = newprice(0) * Main
                newprice(0) = newprice(0) + (Add * CDbl(DB.Picklists.Get_Single_Description("Additional Appliance", 52)))

                If WindowsLocks And PlumbingDrainage And GasSupply Then
                    newprice(0) = newprice(0) + CDbl(DB.Picklists.Get_Single_Description("AHE", 52))
                Else
                    newprice(0) = newprice(0) - (GasSupply * CDbl(DB.Picklists.Get_Single_Description("Gas Supply Pipework", 52)))
                    newprice(0) = newprice(0) - (PlumbingDrainage * CDbl(DB.Picklists.Get_Single_Description("PDE", 52)))
                    newprice(0) = newprice(0) - (WindowsLocks * CDbl(DB.Picklists.Get_Single_Description("WLP", 52)))
                End If
                newprice(0) = newprice(0) - ((newprice(0) / 100) * Discount)

                Dim theRounded As Double = Math.Round(newprice(0) / 12, 2)
                newprice(1) = Format(theRounded + (newprice(0) - (theRounded * 12)), "C")
                newprice(2) = Format(theRounded, "C")

            Case 67247 'TODO old possible drop
                newprice(0) = CDbl(DB.Picklists.Get_Single_Description("Gold Star Agency", 52))
                ' newprice(0) = newprice(0) / (1 + (Discount / 100))
                Dim theRounded As Double = Math.Round(newprice(0) / 12, 2)
                newprice(1) = Format(theRounded + (newprice(0) - (theRounded * 12)), "C")
                newprice(2) = Format(theRounded, "C")

            Case 68294 'TODO old possible drop
                newprice(0) = CDbl(DB.Picklists.Get_Single_Description("TA", 52)) * Years
                newprice(0) = newprice(0) - ((newprice(0) / 100) * Discount)
                newprice(0) = newprice(0) + (Add * CDbl(DB.Picklists.Get_Single_Description("Additional Appliance PLAT", 52)))

                If WindowsLocks And PlumbingDrainage And GasSupply Then
                    newprice(0) = newprice(0) + CDbl(DB.Picklists.Get_Single_Description("AHE", 52))
                Else
                    newprice(0) = newprice(0) - (GasSupply * CDbl(DB.Picklists.Get_Single_Description("Gas Supply Pipework", 52)))
                    newprice(0) = newprice(0) - (PlumbingDrainage * CDbl(DB.Picklists.Get_Single_Description("PDE", 52)))
                    newprice(0) = newprice(0) - (WindowsLocks * CDbl(DB.Picklists.Get_Single_Description("WLP", 52)))
                End If

                Dim theRounded As Double = Math.Round(newprice(0) / (CDbl(DB.Picklists.Get_Single_Description("TA", 52)) / 12), 2)
                newprice(1) = Format(theRounded + (newprice(0) - (theRounded * (CDbl(DB.Picklists.Get_Single_Description("TA", 52)) / 12))), "C")
                newprice(2) = Format(theRounded, "C")

            Case Enums.ContractTypes.SilverStar
                newprice(0) = CDbl(DB.Picklists.Get_Single_Description("Silver Star", 52))
                newprice(0) = newprice(0) * Main
                newprice(0) = newprice(0) + (Add * CDbl(DB.Picklists.Get_Single_Description("Additional Appliance", 52)))

                If WindowsLocks And PlumbingDrainage And GasSupply Then
                    newprice(0) = newprice(0) + CDbl(DB.Picklists.Get_Single_Description("AHE", 52))
                Else
                    newprice(0) = newprice(0) - (GasSupply * CDbl(DB.Picklists.Get_Single_Description("Gas Supply Pipework", 52)))
                    newprice(0) = newprice(0) - (PlumbingDrainage * CDbl(DB.Picklists.Get_Single_Description("PDE", 52)))
                    newprice(0) = newprice(0) - (WindowsLocks * CDbl(DB.Picklists.Get_Single_Description("WLP", 52)))
                End If
                newprice(0) = newprice(0) - ((newprice(0) / 100) * Discount)

                Dim theRounded As Double = Math.Round(newprice(0) / 12, 2)
                newprice(1) = Format(theRounded + (newprice(0) - (theRounded * 12)), "C")
                newprice(2) = Format(theRounded, "C")
        End Select
        Return newprice
    End Function

    Public Sub SetUpSoldByCombo()
        cboSoldBy.Items.Clear()
        cboSoldBy.Items.Add("-- Not Applicable --")
        cboSoldBy.DataSource = DB.Engineer.User_And_Engineer_GetAll()
        cboSoldBy.DisplayMember = "Name"
        cboSoldBy.ValueMember = "UID"
        cboSoldBy.SelectedIndex = 0
    End Sub

End Class

Public NotInheritable Class Simple3Des

    Private TripleDes As New TripleDESCryptoServiceProvider

    Sub New(ByVal key As String)
        ' Initialize the crypto provider.
        TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
        TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
    End Sub

    Private Function TruncateHash(
    ByVal key As String,
    ByVal length As Integer) As Byte()

        Dim sha1 As New SHA1CryptoServiceProvider

        ' Hash the key.
        Dim keyBytes() As Byte =
            System.Text.Encoding.Unicode.GetBytes(key)
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)

        ' Truncate or pad the hash.
        ReDim Preserve hash(length - 1)
        Return hash
    End Function

    Public Function EncryptData(
    ByVal plaintext As String) As String

        ' Convert the plaintext string to a byte array.
        Dim plaintextBytes() As Byte =
            System.Text.Encoding.Unicode.GetBytes(plaintext)

        ' Create the stream.
        Dim ms As New System.IO.MemoryStream
        ' Create the encoder to write to the stream.
        Dim encStream As New CryptoStream(ms,
            TripleDes.CreateEncryptor(),
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
        encStream.FlushFinalBlock()

        ' Convert the encrypted stream to a printable string.
        Return Convert.ToBase64String(ms.ToArray)
    End Function

    Public Function DecryptData(
    ByVal encryptedtext As String) As String

        ' Convert the encrypted text string to a byte array.
        Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

        ' Create the stream.
        Dim ms As New System.IO.MemoryStream
        ' Create the decoder to write to the stream.
        Dim decStream As New CryptoStream(ms,
            TripleDes.CreateDecryptor(),
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()

        ' Convert the plaintext stream to a string.
        Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
    End Function

End Class