Imports System.Collections.Generic
Imports System.Linq
Imports FSM.Entity.CostCentres
Imports FSM.Entity.CostCentres.Enums
Imports FSM.Entity.Sys

Public Class UCQuoteJob : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(cboQuoteStatus, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Quote_Status).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboJobType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable)
        Combo.SetUpCombo(cboScheduleOfRatesCategoryID, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.ScheduleRatesCategories).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboVAT, DB.VATRatesSQL.VATRates_GetAll_InputOrOutput("O").Table, "VATRateID", "Friendly", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboAsbestos, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Quote_Asbestos).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboAccess, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Quote_AccessEquipment).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(cboElectricalPack, DynamicDataTables.Quote_ElectricianPack, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        Select Case True
            Case IsGasway
                Combo.SetUpCombo(Me.cboDept, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative)
            Case Else
                Combo.SetUpCombo(Me.cboDept, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative)
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents lblQuoteStatus As System.Windows.Forms.Label

    Friend WithEvents lblQuoteDate As System.Windows.Forms.Label
    Friend WithEvents cboQuoteStatus As System.Windows.Forms.ComboBox
    Friend WithEvents grpJobItems As System.Windows.Forms.GroupBox
    Friend WithEvents txtReference As System.Windows.Forms.TextBox
    Friend WithEvents cboJobType As System.Windows.Forms.ComboBox
    Friend WithEvents lblJobType As System.Windows.Forms.Label
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents txtBOC As System.Windows.Forms.TextBox
    Friend WithEvents lblPartsCost As System.Windows.Forms.Label
    Friend WithEvents grpParts As System.Windows.Forms.GroupBox
    Friend WithEvents btnRemovePartProduct As System.Windows.Forms.Button
    Friend WithEvents btnFindPart As System.Windows.Forms.Button
    Friend WithEvents dgPartsAndProducts As System.Windows.Forms.DataGrid
    Friend WithEvents dtpQuoteDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSiteName As System.Windows.Forms.TextBox
    Friend WithEvents lblProperty As System.Windows.Forms.Label
    Friend WithEvents lblQuoteRef As System.Windows.Forms.Label
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents dgScheduleOfRates As System.Windows.Forms.DataGrid
    Friend WithEvents cboScheduleOfRatesCategoryID As System.Windows.Forms.ComboBox
    Friend WithEvents lblScheduleOfRatesCategoryID As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnSiteScheduleOfRates As System.Windows.Forms.Button
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents txtPartsCost As System.Windows.Forms.TextBox
    Friend WithEvents lblPartsMarkup As System.Windows.Forms.Label
    Friend WithEvents txtPartsProductsMarkup As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalPartsCharge As System.Windows.Forms.Label
    Friend WithEvents txtPartsCostTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblSORCost As System.Windows.Forms.Label
    Friend WithEvents txtScheduleRatesCost As System.Windows.Forms.TextBox
    Friend WithEvents lblSORMarkup As System.Windows.Forms.Label
    Friend WithEvents txtScheduleRateMarkup As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalSORCharge As System.Windows.Forms.Label
    Friend WithEvents txtScheduleRatesCostTotal As System.Windows.Forms.TextBox
    Friend WithEvents grpRates As System.Windows.Forms.GroupBox
    Friend WithEvents txtTimeInMins As System.Windows.Forms.TextBox
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents lblAsbestosNotes As Label
    Friend WithEvents txtAsbestos As TextBox
    Friend WithEvents cboAsbestos As ComboBox
    Friend WithEvents lblAsbestosStatus As Label
    Friend WithEvents lblInstallerNotes As Label
    Friend WithEvents txtInstallerNotes As TextBox
    Friend WithEvents gpOtherLabour As GroupBox
    Friend WithEvents txtElectricianCharge As TextBox
    Friend WithEvents lblTotalElectricianCharge As Label
    Friend WithEvents txtElectricianMarkup As TextBox
    Friend WithEvents lblElectricianMarkup As Label
    Friend WithEvents txtElectricianCost As TextBox
    Friend WithEvents lblElectricianCost As Label
    Friend WithEvents lblTotalInstallerCharge As Label
    Friend WithEvents txtInstallerMarkup As TextBox
    Friend WithEvents lblInstallerMarkup As Label
    Friend WithEvents txtInstallerCost As TextBox
    Friend WithEvents lblInstallerCost As Label
    Friend WithEvents txtBuilderCharge As TextBox
    Friend WithEvents lblTotalBuilderCharge As Label
    Friend WithEvents txtBuilderMarkup As TextBox
    Friend WithEvents lblBuilderMarkup As Label
    Friend WithEvents txtBuilderCost As TextBox
    Friend WithEvents lblBuilderCost As Label
    Friend WithEvents txtInstallerCharge As TextBox
    Friend WithEvents txtAccess As TextBox
    Friend WithEvents lblAddCharges As Label
    Friend WithEvents cboAccess As ComboBox
    Friend WithEvents lblAccessEquipment As Label
    Friend WithEvents txtInstallerLabourDays As TextBox
    Friend WithEvents lblInstallerDays As Label
    Friend WithEvents txtElectricianHours As TextBox
    Friend WithEvents lblElectricianPack As Label
    Friend WithEvents txtElectricianNotes As TextBox
    Friend WithEvents lblElectricianNotes As Label
    Friend WithEvents lblElectricianPackHours As Label
    Friend WithEvents lblElectOr As Label
    Friend WithEvents cboElectricalPack As ComboBox
    Friend WithEvents txtElectricianArrivalHour As TextBox
    Friend WithEvents lblElectricianHour As Label
    Friend WithEvents txtElectricianArrivalDay As TextBox
    Friend WithEvents lblElectricianArrivalDay As Label
    Friend WithEvents txtBuilderArrivalHour As TextBox
    Friend WithEvents lblBuilderHour As Label
    Friend WithEvents txtBuilderArrivalDay As TextBox
    Friend WithEvents lblArrivalDay As Label
    Friend WithEvents txtBuilderHours As TextBox
    Friend WithEvents txtBuilderNotes As TextBox
    Friend WithEvents lblBuilderNotes As Label
    Friend WithEvents lblBuilderLabourHours As Label
    Friend WithEvents lblBuilderLabour As Label
    Friend WithEvents lblBOC As Label
    Friend WithEvents txtDeposit As TextBox
    Friend WithEvents lblDeposit As Label
    Friend WithEvents txtincVAT As TextBox
    Friend WithEvents lblIncVAT As Label
    Friend WithEvents cboVAT As ComboBox
    Friend WithEvents lblVAT As Label
    Friend WithEvents txtGrandTotal As TextBox
    Friend WithEvents txtTotalCosts As TextBox
    Friend WithEvents lblSale As Label
    Friend WithEvents txtProfitPound As TextBox
    Friend WithEvents lblProfitSlash As Label
    Friend WithEvents txtProfitPerc As TextBox
    Friend WithEvents lblProfit As Label
    Friend WithEvents lblTotalCosts As Label
    Friend WithEvents chkSORCharge As CheckBox
    Friend WithEvents txtSurveyor As TextBox
    Friend WithEvents lblSurveyor As Label
    Friend WithEvents lblLastChangedOn As Label
    Friend WithEvents txtChangedDate As TextBox
    Friend WithEvents lblChangedBy As Label
    Friend WithEvents txtChangedBy As TextBox
    Friend WithEvents lblNA As Label
    Friend WithEvents lblEstStartDAte As Label
    Friend WithEvents dtpestStartDate As DateTimePicker
    Friend WithEvents lblPurchaseDept As Label
    Friend WithEvents cboDept As ComboBox
    Friend WithEvents chkService As CheckBox
    Friend WithEvents chkHOver As CheckBox
    Friend WithEvents txtOriginalQuote As TextBox
    Friend WithEvents lblOriginalQuote As Label
    Friend WithEvents btnEmailSOR As Button
    Friend WithEvents grpTotals As System.Windows.Forms.GroupBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpRates = New System.Windows.Forms.GroupBox()
        Me.btnEmailSOR = New System.Windows.Forms.Button()
        Me.txtTimeInMins = New System.Windows.Forms.TextBox()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.btnSiteScheduleOfRates = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.cboScheduleOfRatesCategoryID = New System.Windows.Forms.ComboBox()
        Me.lblScheduleOfRatesCategoryID = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.dgScheduleOfRates = New System.Windows.Forms.DataGrid()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblQuoteStatus = New System.Windows.Forms.Label()
        Me.lblQuoteDate = New System.Windows.Forms.Label()
        Me.cboQuoteStatus = New System.Windows.Forms.ComboBox()
        Me.grpJobItems = New System.Windows.Forms.GroupBox()
        Me.lblNA = New System.Windows.Forms.Label()
        Me.lblEstStartDAte = New System.Windows.Forms.Label()
        Me.txtInstallerLabourDays = New System.Windows.Forms.TextBox()
        Me.dtpestStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblInstallerDays = New System.Windows.Forms.Label()
        Me.txtAccess = New System.Windows.Forms.TextBox()
        Me.lblAddCharges = New System.Windows.Forms.Label()
        Me.cboAccess = New System.Windows.Forms.ComboBox()
        Me.lblAccessEquipment = New System.Windows.Forms.Label()
        Me.lblAsbestosNotes = New System.Windows.Forms.Label()
        Me.txtAsbestos = New System.Windows.Forms.TextBox()
        Me.cboAsbestos = New System.Windows.Forms.ComboBox()
        Me.lblAsbestosStatus = New System.Windows.Forms.Label()
        Me.lblInstallerNotes = New System.Windows.Forms.Label()
        Me.txtInstallerNotes = New System.Windows.Forms.TextBox()
        Me.txtReference = New System.Windows.Forms.TextBox()
        Me.cboJobType = New System.Windows.Forms.ComboBox()
        Me.lblJobType = New System.Windows.Forms.Label()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.grpTotals = New System.Windows.Forms.GroupBox()
        Me.txtOriginalQuote = New System.Windows.Forms.TextBox()
        Me.lblOriginalQuote = New System.Windows.Forms.Label()
        Me.txtGrandTotal = New System.Windows.Forms.TextBox()
        Me.chkSORCharge = New System.Windows.Forms.CheckBox()
        Me.lblBOC = New System.Windows.Forms.Label()
        Me.txtDeposit = New System.Windows.Forms.TextBox()
        Me.lblDeposit = New System.Windows.Forms.Label()
        Me.txtincVAT = New System.Windows.Forms.TextBox()
        Me.lblIncVAT = New System.Windows.Forms.Label()
        Me.cboVAT = New System.Windows.Forms.ComboBox()
        Me.lblVAT = New System.Windows.Forms.Label()
        Me.txtTotalCosts = New System.Windows.Forms.TextBox()
        Me.lblSale = New System.Windows.Forms.Label()
        Me.txtProfitPound = New System.Windows.Forms.TextBox()
        Me.lblProfitSlash = New System.Windows.Forms.Label()
        Me.txtProfitPerc = New System.Windows.Forms.TextBox()
        Me.lblProfit = New System.Windows.Forms.Label()
        Me.lblTotalCosts = New System.Windows.Forms.Label()
        Me.txtPartsCostTotal = New System.Windows.Forms.TextBox()
        Me.txtBuilderCharge = New System.Windows.Forms.TextBox()
        Me.lblTotalBuilderCharge = New System.Windows.Forms.Label()
        Me.txtBuilderMarkup = New System.Windows.Forms.TextBox()
        Me.lblBuilderMarkup = New System.Windows.Forms.Label()
        Me.txtBuilderCost = New System.Windows.Forms.TextBox()
        Me.lblBuilderCost = New System.Windows.Forms.Label()
        Me.txtElectricianCharge = New System.Windows.Forms.TextBox()
        Me.lblTotalElectricianCharge = New System.Windows.Forms.Label()
        Me.txtElectricianMarkup = New System.Windows.Forms.TextBox()
        Me.lblElectricianMarkup = New System.Windows.Forms.Label()
        Me.txtElectricianCost = New System.Windows.Forms.TextBox()
        Me.lblElectricianCost = New System.Windows.Forms.Label()
        Me.txtInstallerCharge = New System.Windows.Forms.TextBox()
        Me.lblTotalInstallerCharge = New System.Windows.Forms.Label()
        Me.txtInstallerMarkup = New System.Windows.Forms.TextBox()
        Me.lblInstallerMarkup = New System.Windows.Forms.Label()
        Me.txtInstallerCost = New System.Windows.Forms.TextBox()
        Me.lblInstallerCost = New System.Windows.Forms.Label()
        Me.txtScheduleRatesCostTotal = New System.Windows.Forms.TextBox()
        Me.lblTotalSORCharge = New System.Windows.Forms.Label()
        Me.txtScheduleRateMarkup = New System.Windows.Forms.TextBox()
        Me.lblSORMarkup = New System.Windows.Forms.Label()
        Me.txtScheduleRatesCost = New System.Windows.Forms.TextBox()
        Me.lblSORCost = New System.Windows.Forms.Label()
        Me.lblTotalPartsCharge = New System.Windows.Forms.Label()
        Me.txtPartsProductsMarkup = New System.Windows.Forms.TextBox()
        Me.lblPartsMarkup = New System.Windows.Forms.Label()
        Me.txtBOC = New System.Windows.Forms.TextBox()
        Me.txtPartsCost = New System.Windows.Forms.TextBox()
        Me.lblPartsCost = New System.Windows.Forms.Label()
        Me.grpParts = New System.Windows.Forms.GroupBox()
        Me.btnRemovePartProduct = New System.Windows.Forms.Button()
        Me.btnFindPart = New System.Windows.Forms.Button()
        Me.dgPartsAndProducts = New System.Windows.Forms.DataGrid()
        Me.dtpQuoteDate = New System.Windows.Forms.DateTimePicker()
        Me.txtSiteName = New System.Windows.Forms.TextBox()
        Me.lblProperty = New System.Windows.Forms.Label()
        Me.lblQuoteRef = New System.Windows.Forms.Label()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.gpOtherLabour = New System.Windows.Forms.GroupBox()
        Me.txtBuilderArrivalHour = New System.Windows.Forms.TextBox()
        Me.lblBuilderHour = New System.Windows.Forms.Label()
        Me.txtBuilderArrivalDay = New System.Windows.Forms.TextBox()
        Me.lblArrivalDay = New System.Windows.Forms.Label()
        Me.txtBuilderHours = New System.Windows.Forms.TextBox()
        Me.txtBuilderNotes = New System.Windows.Forms.TextBox()
        Me.lblBuilderNotes = New System.Windows.Forms.Label()
        Me.lblBuilderLabourHours = New System.Windows.Forms.Label()
        Me.lblBuilderLabour = New System.Windows.Forms.Label()
        Me.txtElectricianArrivalHour = New System.Windows.Forms.TextBox()
        Me.lblElectricianHour = New System.Windows.Forms.Label()
        Me.txtElectricianArrivalDay = New System.Windows.Forms.TextBox()
        Me.lblElectricianArrivalDay = New System.Windows.Forms.Label()
        Me.txtElectricianHours = New System.Windows.Forms.TextBox()
        Me.txtElectricianNotes = New System.Windows.Forms.TextBox()
        Me.lblElectricianNotes = New System.Windows.Forms.Label()
        Me.lblElectricianPackHours = New System.Windows.Forms.Label()
        Me.lblElectOr = New System.Windows.Forms.Label()
        Me.cboElectricalPack = New System.Windows.Forms.ComboBox()
        Me.lblElectricianPack = New System.Windows.Forms.Label()
        Me.txtSurveyor = New System.Windows.Forms.TextBox()
        Me.lblSurveyor = New System.Windows.Forms.Label()
        Me.lblLastChangedOn = New System.Windows.Forms.Label()
        Me.txtChangedDate = New System.Windows.Forms.TextBox()
        Me.lblChangedBy = New System.Windows.Forms.Label()
        Me.txtChangedBy = New System.Windows.Forms.TextBox()
        Me.lblPurchaseDept = New System.Windows.Forms.Label()
        Me.cboDept = New System.Windows.Forms.ComboBox()
        Me.chkService = New System.Windows.Forms.CheckBox()
        Me.chkHOver = New System.Windows.Forms.CheckBox()
        Me.grpRates.SuspendLayout()
        CType(Me.dgScheduleOfRates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpJobItems.SuspendLayout()
        Me.grpTotals.SuspendLayout()
        Me.grpParts.SuspendLayout()
        CType(Me.dgPartsAndProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpOtherLabour.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpRates
        '
        Me.grpRates.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpRates.Controls.Add(Me.btnEmailSOR)
        Me.grpRates.Controls.Add(Me.txtTimeInMins)
        Me.grpRates.Controls.Add(Me.lblTime)
        Me.grpRates.Controls.Add(Me.btnSiteScheduleOfRates)
        Me.grpRates.Controls.Add(Me.btnRemove)
        Me.grpRates.Controls.Add(Me.cboScheduleOfRatesCategoryID)
        Me.grpRates.Controls.Add(Me.lblScheduleOfRatesCategoryID)
        Me.grpRates.Controls.Add(Me.txtCode)
        Me.grpRates.Controls.Add(Me.lblCode)
        Me.grpRates.Controls.Add(Me.txtDescription)
        Me.grpRates.Controls.Add(Me.lblDescription)
        Me.grpRates.Controls.Add(Me.dgScheduleOfRates)
        Me.grpRates.Controls.Add(Me.txtPrice)
        Me.grpRates.Controls.Add(Me.lblPrice)
        Me.grpRates.Controls.Add(Me.lblQuantity)
        Me.grpRates.Controls.Add(Me.txtQuantity)
        Me.grpRates.Controls.Add(Me.btnAdd)
        Me.grpRates.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.grpRates.Location = New System.Drawing.Point(8, 339)
        Me.grpRates.Name = "grpRates"
        Me.grpRates.Size = New System.Drawing.Size(539, 358)
        Me.grpRates.TabIndex = 6
        Me.grpRates.TabStop = False
        Me.grpRates.Text = "Schedule Of  Rates"
        '
        'btnEmailSOR
        '
        Me.btnEmailSOR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEmailSOR.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnEmailSOR.Location = New System.Drawing.Point(6, 164)
        Me.btnEmailSOR.Name = "btnEmailSOR"
        Me.btnEmailSOR.Size = New System.Drawing.Size(111, 23)
        Me.btnEmailSOR.TabIndex = 17
        Me.btnEmailSOR.Text = "Email SOR List"
        '
        'txtTimeInMins
        '
        Me.txtTimeInMins.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTimeInMins.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtTimeInMins.Location = New System.Drawing.Point(176, 270)
        Me.txtTimeInMins.MaxLength = 9
        Me.txtTimeInMins.Name = "txtTimeInMins"
        Me.txtTimeInMins.Size = New System.Drawing.Size(355, 21)
        Me.txtTimeInMins.TabIndex = 10
        Me.txtTimeInMins.Tag = "SystemScheduleOfRate.Price"
        '
        'lblTime
        '
        Me.lblTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTime.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblTime.Location = New System.Drawing.Point(8, 271)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(136, 20)
        Me.lblTime.TabIndex = 9
        Me.lblTime.Text = "Time (in Minutes)"
        '
        'btnSiteScheduleOfRates
        '
        Me.btnSiteScheduleOfRates.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSiteScheduleOfRates.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSiteScheduleOfRates.Location = New System.Drawing.Point(307, 326)
        Me.btnSiteScheduleOfRates.Name = "btnSiteScheduleOfRates"
        Me.btnSiteScheduleOfRates.Size = New System.Drawing.Size(224, 23)
        Me.btnSiteScheduleOfRates.TabIndex = 16
        Me.btnSiteScheduleOfRates.Text = "Add Site Schedule Of Rates"
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnRemove.Location = New System.Drawing.Point(451, 164)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(80, 23)
        Me.btnRemove.TabIndex = 2
        Me.btnRemove.Text = "Remove"
        '
        'cboScheduleOfRatesCategoryID
        '
        Me.cboScheduleOfRatesCategoryID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboScheduleOfRatesCategoryID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboScheduleOfRatesCategoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboScheduleOfRatesCategoryID.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.cboScheduleOfRatesCategoryID.Location = New System.Drawing.Point(176, 198)
        Me.cboScheduleOfRatesCategoryID.Name = "cboScheduleOfRatesCategoryID"
        Me.cboScheduleOfRatesCategoryID.Size = New System.Drawing.Size(355, 21)
        Me.cboScheduleOfRatesCategoryID.TabIndex = 4
        Me.cboScheduleOfRatesCategoryID.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID"
        '
        'lblScheduleOfRatesCategoryID
        '
        Me.lblScheduleOfRatesCategoryID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblScheduleOfRatesCategoryID.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblScheduleOfRatesCategoryID.Location = New System.Drawing.Point(8, 198)
        Me.lblScheduleOfRatesCategoryID.Name = "lblScheduleOfRatesCategoryID"
        Me.lblScheduleOfRatesCategoryID.Size = New System.Drawing.Size(179, 20)
        Me.lblScheduleOfRatesCategoryID.TabIndex = 3
        Me.lblScheduleOfRatesCategoryID.Text = "Schedule Of Rates Category"
        '
        'txtCode
        '
        Me.txtCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtCode.Location = New System.Drawing.Point(176, 222)
        Me.txtCode.MaxLength = 50
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(355, 21)
        Me.txtCode.TabIndex = 6
        Me.txtCode.Tag = "SystemScheduleOfRate.Code"
        '
        'lblCode
        '
        Me.lblCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblCode.Location = New System.Drawing.Point(8, 222)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(72, 20)
        Me.lblCode.TabIndex = 5
        Me.lblCode.Text = "Code"
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtDescription.Location = New System.Drawing.Point(176, 246)
        Me.txtDescription.MaxLength = 0
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(355, 20)
        Me.txtDescription.TabIndex = 8
        Me.txtDescription.Tag = "SystemScheduleOfRate.Description"
        '
        'lblDescription
        '
        Me.lblDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDescription.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblDescription.Location = New System.Drawing.Point(8, 246)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(112, 20)
        Me.lblDescription.TabIndex = 7
        Me.lblDescription.Text = "Description"
        '
        'dgScheduleOfRates
        '
        Me.dgScheduleOfRates.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgScheduleOfRates.DataMember = ""
        Me.dgScheduleOfRates.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dgScheduleOfRates.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgScheduleOfRates.Location = New System.Drawing.Point(8, 20)
        Me.dgScheduleOfRates.Name = "dgScheduleOfRates"
        Me.dgScheduleOfRates.Size = New System.Drawing.Size(523, 138)
        Me.dgScheduleOfRates.TabIndex = 0
        '
        'txtPrice
        '
        Me.txtPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPrice.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtPrice.Location = New System.Drawing.Point(48, 294)
        Me.txtPrice.MaxLength = 9
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(122, 21)
        Me.txtPrice.TabIndex = 12
        Me.txtPrice.Tag = "SystemScheduleOfRate.Price"
        '
        'lblPrice
        '
        Me.lblPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPrice.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblPrice.Location = New System.Drawing.Point(8, 294)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(40, 20)
        Me.lblPrice.TabIndex = 11
        Me.lblPrice.Text = "Price"
        '
        'lblQuantity
        '
        Me.lblQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblQuantity.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblQuantity.Location = New System.Drawing.Point(176, 294)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(56, 20)
        Me.lblQuantity.TabIndex = 13
        Me.lblQuantity.Text = "Quantity"
        '
        'txtQuantity
        '
        Me.txtQuantity.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQuantity.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtQuantity.Location = New System.Drawing.Point(256, 294)
        Me.txtQuantity.MaxLength = 9
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(275, 21)
        Me.txtQuantity.TabIndex = 14
        Me.txtQuantity.Tag = ""
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnAdd.Location = New System.Drawing.Point(8, 326)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(80, 23)
        Me.btnAdd.TabIndex = 15
        Me.btnAdd.Text = "Add"
        '
        'lblQuoteStatus
        '
        Me.lblQuoteStatus.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblQuoteStatus.Location = New System.Drawing.Point(474, 38)
        Me.lblQuoteStatus.Name = "lblQuoteStatus"
        Me.lblQuoteStatus.Size = New System.Drawing.Size(88, 23)
        Me.lblQuoteStatus.TabIndex = 61
        Me.lblQuoteStatus.Text = "Quote Status:"
        '
        'lblQuoteDate
        '
        Me.lblQuoteDate.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblQuoteDate.Location = New System.Drawing.Point(475, 3)
        Me.lblQuoteDate.Name = "lblQuoteDate"
        Me.lblQuoteDate.Size = New System.Drawing.Size(80, 23)
        Me.lblQuoteDate.TabIndex = 60
        Me.lblQuoteDate.Text = "Quote Date:"
        '
        'cboQuoteStatus
        '
        Me.cboQuoteStatus.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.cboQuoteStatus.ItemHeight = 13
        Me.cboQuoteStatus.Location = New System.Drawing.Point(560, 37)
        Me.cboQuoteStatus.Name = "cboQuoteStatus"
        Me.cboQuoteStatus.Size = New System.Drawing.Size(151, 21)
        Me.cboQuoteStatus.TabIndex = 4
        '
        'grpJobItems
        '
        Me.grpJobItems.Controls.Add(Me.lblNA)
        Me.grpJobItems.Controls.Add(Me.lblEstStartDAte)
        Me.grpJobItems.Controls.Add(Me.txtInstallerLabourDays)
        Me.grpJobItems.Controls.Add(Me.dtpestStartDate)
        Me.grpJobItems.Controls.Add(Me.lblInstallerDays)
        Me.grpJobItems.Controls.Add(Me.txtAccess)
        Me.grpJobItems.Controls.Add(Me.lblAddCharges)
        Me.grpJobItems.Controls.Add(Me.cboAccess)
        Me.grpJobItems.Controls.Add(Me.lblAccessEquipment)
        Me.grpJobItems.Controls.Add(Me.lblAsbestosNotes)
        Me.grpJobItems.Controls.Add(Me.txtAsbestos)
        Me.grpJobItems.Controls.Add(Me.cboAsbestos)
        Me.grpJobItems.Controls.Add(Me.lblAsbestosStatus)
        Me.grpJobItems.Controls.Add(Me.lblInstallerNotes)
        Me.grpJobItems.Controls.Add(Me.txtInstallerNotes)
        Me.grpJobItems.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.grpJobItems.Location = New System.Drawing.Point(8, 66)
        Me.grpJobItems.Name = "grpJobItems"
        Me.grpJobItems.Size = New System.Drawing.Size(539, 266)
        Me.grpJobItems.TabIndex = 5
        Me.grpJobItems.TabStop = False
        Me.grpJobItems.Text = "Job Details"
        '
        'lblNA
        '
        Me.lblNA.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblNA.Location = New System.Drawing.Point(120, 245)
        Me.lblNA.Name = "lblNA"
        Me.lblNA.Size = New System.Drawing.Size(73, 19)
        Me.lblNA.TabIndex = 72
        Me.lblNA.Text = "N/A"
        Me.lblNA.Visible = False
        '
        'lblEstStartDAte
        '
        Me.lblEstStartDAte.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblEstStartDAte.Location = New System.Drawing.Point(8, 246)
        Me.lblEstStartDAte.Name = "lblEstStartDAte"
        Me.lblEstStartDAte.Size = New System.Drawing.Size(109, 17)
        Me.lblEstStartDAte.TabIndex = 73
        Me.lblEstStartDAte.Text = "Est Start Date"
        '
        'txtInstallerLabourDays
        '
        Me.txtInstallerLabourDays.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtInstallerLabourDays.Location = New System.Drawing.Point(123, 147)
        Me.txtInstallerLabourDays.MaxLength = 50
        Me.txtInstallerLabourDays.Name = "txtInstallerLabourDays"
        Me.txtInstallerLabourDays.Size = New System.Drawing.Size(143, 21)
        Me.txtInstallerLabourDays.TabIndex = 20
        Me.txtInstallerLabourDays.Tag = "SystemScheduleOfRate.Code"
        '
        'dtpestStartDate
        '
        Me.dtpestStartDate.CalendarFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpestStartDate.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtpestStartDate.Location = New System.Drawing.Point(123, 242)
        Me.dtpestStartDate.Name = "dtpestStartDate"
        Me.dtpestStartDate.Size = New System.Drawing.Size(167, 21)
        Me.dtpestStartDate.TabIndex = 72
        Me.dtpestStartDate.Value = New Date(2007, 8, 13, 15, 56, 20, 616)
        '
        'lblInstallerDays
        '
        Me.lblInstallerDays.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblInstallerDays.Location = New System.Drawing.Point(8, 150)
        Me.lblInstallerDays.Name = "lblInstallerDays"
        Me.lblInstallerDays.Size = New System.Drawing.Size(98, 20)
        Me.lblInstallerDays.TabIndex = 19
        Me.lblInstallerDays.Text = "Installer Days"
        '
        'txtAccess
        '
        Me.txtAccess.AcceptsReturn = True
        Me.txtAccess.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtAccess.Location = New System.Drawing.Point(460, 216)
        Me.txtAccess.MaxLength = 50
        Me.txtAccess.Name = "txtAccess"
        Me.txtAccess.Size = New System.Drawing.Size(71, 21)
        Me.txtAccess.TabIndex = 18
        Me.txtAccess.Tag = "SystemScheduleOfRate.Code"
        '
        'lblAddCharges
        '
        Me.lblAddCharges.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblAddCharges.Location = New System.Drawing.Point(328, 219)
        Me.lblAddCharges.Name = "lblAddCharges"
        Me.lblAddCharges.Size = New System.Drawing.Size(134, 20)
        Me.lblAddCharges.TabIndex = 17
        Me.lblAddCharges.Text = "Access / Add Charges"
        '
        'cboAccess
        '
        Me.cboAccess.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboAccess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccess.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.cboAccess.Location = New System.Drawing.Point(123, 216)
        Me.cboAccess.Name = "cboAccess"
        Me.cboAccess.Size = New System.Drawing.Size(201, 21)
        Me.cboAccess.TabIndex = 14
        Me.cboAccess.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID"
        '
        'lblAccessEquipment
        '
        Me.lblAccessEquipment.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblAccessEquipment.Location = New System.Drawing.Point(6, 216)
        Me.lblAccessEquipment.Name = "lblAccessEquipment"
        Me.lblAccessEquipment.Size = New System.Drawing.Size(114, 20)
        Me.lblAccessEquipment.TabIndex = 13
        Me.lblAccessEquipment.Text = "Access Equipment"
        '
        'lblAsbestosNotes
        '
        Me.lblAsbestosNotes.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblAsbestosNotes.Location = New System.Drawing.Point(8, 174)
        Me.lblAsbestosNotes.Name = "lblAsbestosNotes"
        Me.lblAsbestosNotes.Size = New System.Drawing.Size(112, 20)
        Me.lblAsbestosNotes.TabIndex = 12
        Me.lblAsbestosNotes.Text = "Asbestos Notes"
        '
        'txtAsbestos
        '
        Me.txtAsbestos.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtAsbestos.Location = New System.Drawing.Point(123, 174)
        Me.txtAsbestos.MaxLength = 50
        Me.txtAsbestos.Multiline = True
        Me.txtAsbestos.Name = "txtAsbestos"
        Me.txtAsbestos.Size = New System.Drawing.Size(410, 36)
        Me.txtAsbestos.TabIndex = 11
        Me.txtAsbestos.Tag = "SystemScheduleOfRate.Code"
        '
        'cboAsbestos
        '
        Me.cboAsbestos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboAsbestos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAsbestos.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.cboAsbestos.Location = New System.Drawing.Point(397, 147)
        Me.cboAsbestos.Name = "cboAsbestos"
        Me.cboAsbestos.Size = New System.Drawing.Size(136, 21)
        Me.cboAsbestos.TabIndex = 10
        Me.cboAsbestos.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID"
        '
        'lblAsbestosStatus
        '
        Me.lblAsbestosStatus.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblAsbestosStatus.Location = New System.Drawing.Point(272, 150)
        Me.lblAsbestosStatus.Name = "lblAsbestosStatus"
        Me.lblAsbestosStatus.Size = New System.Drawing.Size(114, 20)
        Me.lblAsbestosStatus.TabIndex = 9
        Me.lblAsbestosStatus.Text = "Asbestos Status"
        '
        'lblInstallerNotes
        '
        Me.lblInstallerNotes.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblInstallerNotes.Location = New System.Drawing.Point(8, 23)
        Me.lblInstallerNotes.Name = "lblInstallerNotes"
        Me.lblInstallerNotes.Size = New System.Drawing.Size(98, 20)
        Me.lblInstallerNotes.TabIndex = 8
        Me.lblInstallerNotes.Text = "Installer Notes"
        '
        'txtInstallerNotes
        '
        Me.txtInstallerNotes.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtInstallerNotes.Location = New System.Drawing.Point(123, 23)
        Me.txtInstallerNotes.MaxLength = 50
        Me.txtInstallerNotes.Multiline = True
        Me.txtInstallerNotes.Name = "txtInstallerNotes"
        Me.txtInstallerNotes.Size = New System.Drawing.Size(410, 118)
        Me.txtInstallerNotes.TabIndex = 7
        Me.txtInstallerNotes.Tag = "SystemScheduleOfRate.Code"
        '
        'txtReference
        '
        Me.txtReference.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtReference.Location = New System.Drawing.Point(316, 37)
        Me.txtReference.MaxLength = 50
        Me.txtReference.Name = "txtReference"
        Me.txtReference.Size = New System.Drawing.Size(154, 21)
        Me.txtReference.TabIndex = 3
        '
        'cboJobType
        '
        Me.cboJobType.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.cboJobType.ItemHeight = 13
        Me.cboJobType.Location = New System.Drawing.Point(316, 1)
        Me.cboJobType.Name = "cboJobType"
        Me.cboJobType.Size = New System.Drawing.Size(154, 21)
        Me.cboJobType.TabIndex = 1
        '
        'lblJobType
        '
        Me.lblJobType.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblJobType.Location = New System.Drawing.Point(252, 3)
        Me.lblJobType.Name = "lblJobType"
        Me.lblJobType.Size = New System.Drawing.Size(72, 23)
        Me.lblJobType.TabIndex = 56
        Me.lblJobType.Text = "Job Type:"
        '
        'lblCustomer
        '
        Me.lblCustomer.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblCustomer.Location = New System.Drawing.Point(8, 4)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(80, 23)
        Me.lblCustomer.TabIndex = 54
        Me.lblCustomer.Text = "Customer:"
        '
        'grpTotals
        '
        Me.grpTotals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpTotals.Controls.Add(Me.txtOriginalQuote)
        Me.grpTotals.Controls.Add(Me.lblOriginalQuote)
        Me.grpTotals.Controls.Add(Me.txtGrandTotal)
        Me.grpTotals.Controls.Add(Me.chkSORCharge)
        Me.grpTotals.Controls.Add(Me.lblBOC)
        Me.grpTotals.Controls.Add(Me.txtDeposit)
        Me.grpTotals.Controls.Add(Me.lblDeposit)
        Me.grpTotals.Controls.Add(Me.txtincVAT)
        Me.grpTotals.Controls.Add(Me.lblIncVAT)
        Me.grpTotals.Controls.Add(Me.cboVAT)
        Me.grpTotals.Controls.Add(Me.lblVAT)
        Me.grpTotals.Controls.Add(Me.txtTotalCosts)
        Me.grpTotals.Controls.Add(Me.lblSale)
        Me.grpTotals.Controls.Add(Me.txtProfitPound)
        Me.grpTotals.Controls.Add(Me.lblProfitSlash)
        Me.grpTotals.Controls.Add(Me.txtProfitPerc)
        Me.grpTotals.Controls.Add(Me.lblProfit)
        Me.grpTotals.Controls.Add(Me.lblTotalCosts)
        Me.grpTotals.Controls.Add(Me.txtPartsCostTotal)
        Me.grpTotals.Controls.Add(Me.txtBuilderCharge)
        Me.grpTotals.Controls.Add(Me.lblTotalBuilderCharge)
        Me.grpTotals.Controls.Add(Me.txtBuilderMarkup)
        Me.grpTotals.Controls.Add(Me.lblBuilderMarkup)
        Me.grpTotals.Controls.Add(Me.txtBuilderCost)
        Me.grpTotals.Controls.Add(Me.lblBuilderCost)
        Me.grpTotals.Controls.Add(Me.txtElectricianCharge)
        Me.grpTotals.Controls.Add(Me.lblTotalElectricianCharge)
        Me.grpTotals.Controls.Add(Me.txtElectricianMarkup)
        Me.grpTotals.Controls.Add(Me.lblElectricianMarkup)
        Me.grpTotals.Controls.Add(Me.txtElectricianCost)
        Me.grpTotals.Controls.Add(Me.lblElectricianCost)
        Me.grpTotals.Controls.Add(Me.txtInstallerCharge)
        Me.grpTotals.Controls.Add(Me.lblTotalInstallerCharge)
        Me.grpTotals.Controls.Add(Me.txtInstallerMarkup)
        Me.grpTotals.Controls.Add(Me.lblInstallerMarkup)
        Me.grpTotals.Controls.Add(Me.txtInstallerCost)
        Me.grpTotals.Controls.Add(Me.lblInstallerCost)
        Me.grpTotals.Controls.Add(Me.txtScheduleRatesCostTotal)
        Me.grpTotals.Controls.Add(Me.lblTotalSORCharge)
        Me.grpTotals.Controls.Add(Me.txtScheduleRateMarkup)
        Me.grpTotals.Controls.Add(Me.lblSORMarkup)
        Me.grpTotals.Controls.Add(Me.txtScheduleRatesCost)
        Me.grpTotals.Controls.Add(Me.lblSORCost)
        Me.grpTotals.Controls.Add(Me.lblTotalPartsCharge)
        Me.grpTotals.Controls.Add(Me.txtPartsProductsMarkup)
        Me.grpTotals.Controls.Add(Me.lblPartsMarkup)
        Me.grpTotals.Controls.Add(Me.txtBOC)
        Me.grpTotals.Controls.Add(Me.txtPartsCost)
        Me.grpTotals.Controls.Add(Me.lblPartsCost)
        Me.grpTotals.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.grpTotals.Location = New System.Drawing.Point(579, 490)
        Me.grpTotals.Name = "grpTotals"
        Me.grpTotals.Size = New System.Drawing.Size(592, 207)
        Me.grpTotals.TabIndex = 64
        Me.grpTotals.TabStop = False
        Me.grpTotals.Text = "Summary Of Quote"
        '
        'txtOriginalQuote
        '
        Me.txtOriginalQuote.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOriginalQuote.Enabled = False
        Me.txtOriginalQuote.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtOriginalQuote.Location = New System.Drawing.Point(292, 10)
        Me.txtOriginalQuote.MaxLength = 50
        Me.txtOriginalQuote.Name = "txtOriginalQuote"
        Me.txtOriginalQuote.ReadOnly = True
        Me.txtOriginalQuote.Size = New System.Drawing.Size(99, 21)
        Me.txtOriginalQuote.TabIndex = 94
        '
        'lblOriginalQuote
        '
        Me.lblOriginalQuote.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOriginalQuote.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblOriginalQuote.Location = New System.Drawing.Point(136, 9)
        Me.lblOriginalQuote.Name = "lblOriginalQuote"
        Me.lblOriginalQuote.Size = New System.Drawing.Size(172, 23)
        Me.lblOriginalQuote.TabIndex = 95
        Me.lblOriginalQuote.Text = "Original Quote (ex VAT)"
        Me.lblOriginalQuote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGrandTotal.Enabled = False
        Me.txtGrandTotal.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtGrandTotal.Location = New System.Drawing.Point(41, 183)
        Me.txtGrandTotal.MaxLength = 50
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.Size = New System.Drawing.Size(70, 21)
        Me.txtGrandTotal.TabIndex = 87
        '
        'chkSORCharge
        '
        Me.chkSORCharge.AutoSize = True
        Me.chkSORCharge.Location = New System.Drawing.Point(9, 17)
        Me.chkSORCharge.Name = "chkSORCharge"
        Me.chkSORCharge.Size = New System.Drawing.Size(97, 17)
        Me.chkSORCharge.TabIndex = 93
        Me.chkSORCharge.Text = "SOR Charge"
        Me.chkSORCharge.UseVisualStyleBackColor = True
        '
        'lblBOC
        '
        Me.lblBOC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBOC.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblBOC.Location = New System.Drawing.Point(461, 183)
        Me.lblBOC.Name = "lblBOC"
        Me.lblBOC.Size = New System.Drawing.Size(51, 19)
        Me.lblBOC.TabIndex = 92
        Me.lblBOC.Text = "B.O.C"
        Me.lblBOC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDeposit
        '
        Me.txtDeposit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDeposit.Enabled = False
        Me.txtDeposit.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtDeposit.Location = New System.Drawing.Point(397, 183)
        Me.txtDeposit.MaxLength = 50
        Me.txtDeposit.Name = "txtDeposit"
        Me.txtDeposit.Size = New System.Drawing.Size(64, 21)
        Me.txtDeposit.TabIndex = 91
        '
        'lblDeposit
        '
        Me.lblDeposit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDeposit.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblDeposit.Location = New System.Drawing.Point(346, 184)
        Me.lblDeposit.Name = "lblDeposit"
        Me.lblDeposit.Size = New System.Drawing.Size(51, 19)
        Me.lblDeposit.TabIndex = 90
        Me.lblDeposit.Text = "Deposit"
        Me.lblDeposit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtincVAT
        '
        Me.txtincVAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtincVAT.Enabled = False
        Me.txtincVAT.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtincVAT.Location = New System.Drawing.Point(275, 183)
        Me.txtincVAT.MaxLength = 50
        Me.txtincVAT.Name = "txtincVAT"
        Me.txtincVAT.ReadOnly = True
        Me.txtincVAT.Size = New System.Drawing.Size(65, 21)
        Me.txtincVAT.TabIndex = 89
        '
        'lblIncVAT
        '
        Me.lblIncVAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblIncVAT.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblIncVAT.Location = New System.Drawing.Point(218, 184)
        Me.lblIncVAT.Name = "lblIncVAT"
        Me.lblIncVAT.Size = New System.Drawing.Size(68, 17)
        Me.lblIncVAT.TabIndex = 88
        Me.lblIncVAT.Text = "inc VAT:"
        Me.lblIncVAT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboVAT
        '
        Me.cboVAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboVAT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboVAT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVAT.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.cboVAT.Location = New System.Drawing.Point(138, 183)
        Me.cboVAT.Name = "cboVAT"
        Me.cboVAT.Size = New System.Drawing.Size(78, 21)
        Me.cboVAT.TabIndex = 22
        Me.cboVAT.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID"
        '
        'lblVAT
        '
        Me.lblVAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVAT.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblVAT.Location = New System.Drawing.Point(111, 185)
        Me.lblVAT.Name = "lblVAT"
        Me.lblVAT.Size = New System.Drawing.Size(37, 15)
        Me.lblVAT.TabIndex = 21
        Me.lblVAT.Text = "VAT"
        '
        'txtTotalCosts
        '
        Me.txtTotalCosts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalCosts.Enabled = False
        Me.txtTotalCosts.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtTotalCosts.Location = New System.Drawing.Point(138, 159)
        Me.txtTotalCosts.MaxLength = 50
        Me.txtTotalCosts.Name = "txtTotalCosts"
        Me.txtTotalCosts.ReadOnly = True
        Me.txtTotalCosts.Size = New System.Drawing.Size(78, 21)
        Me.txtTotalCosts.TabIndex = 81
        '
        'lblSale
        '
        Me.lblSale.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSale.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblSale.Location = New System.Drawing.Point(9, 183)
        Me.lblSale.Name = "lblSale"
        Me.lblSale.Size = New System.Drawing.Size(33, 19)
        Me.lblSale.TabIndex = 86
        Me.lblSale.Text = "Sale"
        Me.lblSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProfitPound
        '
        Me.txtProfitPound.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProfitPound.Enabled = False
        Me.txtProfitPound.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtProfitPound.Location = New System.Drawing.Point(365, 159)
        Me.txtProfitPound.MaxLength = 50
        Me.txtProfitPound.Name = "txtProfitPound"
        Me.txtProfitPound.ReadOnly = True
        Me.txtProfitPound.Size = New System.Drawing.Size(64, 21)
        Me.txtProfitPound.TabIndex = 85
        '
        'lblProfitSlash
        '
        Me.lblProfitSlash.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProfitSlash.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblProfitSlash.Location = New System.Drawing.Point(347, 157)
        Me.lblProfitSlash.Name = "lblProfitSlash"
        Me.lblProfitSlash.Size = New System.Drawing.Size(10, 23)
        Me.lblProfitSlash.TabIndex = 84
        Me.lblProfitSlash.Text = "/"
        Me.lblProfitSlash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProfitPerc
        '
        Me.txtProfitPerc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProfitPerc.Enabled = False
        Me.txtProfitPerc.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtProfitPerc.Location = New System.Drawing.Point(292, 158)
        Me.txtProfitPerc.MaxLength = 50
        Me.txtProfitPerc.Name = "txtProfitPerc"
        Me.txtProfitPerc.ReadOnly = True
        Me.txtProfitPerc.Size = New System.Drawing.Size(48, 21)
        Me.txtProfitPerc.TabIndex = 83
        '
        'lblProfit
        '
        Me.lblProfit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProfit.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblProfit.Location = New System.Drawing.Point(218, 156)
        Me.lblProfit.Name = "lblProfit"
        Me.lblProfit.Size = New System.Drawing.Size(45, 23)
        Me.lblProfit.TabIndex = 82
        Me.lblProfit.Text = "Profit"
        Me.lblProfit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalCosts
        '
        Me.lblTotalCosts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalCosts.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblTotalCosts.Location = New System.Drawing.Point(9, 156)
        Me.lblTotalCosts.Name = "lblTotalCosts"
        Me.lblTotalCosts.Size = New System.Drawing.Size(102, 23)
        Me.lblTotalCosts.TabIndex = 80
        Me.lblTotalCosts.Text = "Total Costs"
        Me.lblTotalCosts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartsCostTotal
        '
        Me.txtPartsCostTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartsCostTotal.Enabled = False
        Me.txtPartsCostTotal.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtPartsCostTotal.Location = New System.Drawing.Point(512, 39)
        Me.txtPartsCostTotal.Name = "txtPartsCostTotal"
        Me.txtPartsCostTotal.ReadOnly = True
        Me.txtPartsCostTotal.Size = New System.Drawing.Size(72, 21)
        Me.txtPartsCostTotal.TabIndex = 9
        '
        'txtBuilderCharge
        '
        Me.txtBuilderCharge.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBuilderCharge.Enabled = False
        Me.txtBuilderCharge.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtBuilderCharge.Location = New System.Drawing.Point(512, 135)
        Me.txtBuilderCharge.Name = "txtBuilderCharge"
        Me.txtBuilderCharge.ReadOnly = True
        Me.txtBuilderCharge.Size = New System.Drawing.Size(72, 21)
        Me.txtBuilderCharge.TabIndex = 76
        '
        'lblTotalBuilderCharge
        '
        Me.lblTotalBuilderCharge.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalBuilderCharge.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblTotalBuilderCharge.Location = New System.Drawing.Point(344, 133)
        Me.lblTotalBuilderCharge.Name = "lblTotalBuilderCharge"
        Me.lblTotalBuilderCharge.Size = New System.Drawing.Size(168, 23)
        Me.lblTotalBuilderCharge.TabIndex = 79
        Me.lblTotalBuilderCharge.Text = "Total Builder Charge"
        Me.lblTotalBuilderCharge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBuilderMarkup
        '
        Me.txtBuilderMarkup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBuilderMarkup.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtBuilderMarkup.Location = New System.Drawing.Point(292, 135)
        Me.txtBuilderMarkup.Name = "txtBuilderMarkup"
        Me.txtBuilderMarkup.Size = New System.Drawing.Size(48, 21)
        Me.txtBuilderMarkup.TabIndex = 75
        '
        'lblBuilderMarkup
        '
        Me.lblBuilderMarkup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBuilderMarkup.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblBuilderMarkup.Location = New System.Drawing.Point(219, 135)
        Me.lblBuilderMarkup.Name = "lblBuilderMarkup"
        Me.lblBuilderMarkup.Size = New System.Drawing.Size(80, 20)
        Me.lblBuilderMarkup.TabIndex = 78
        Me.lblBuilderMarkup.Text = "Markup (%)"
        Me.lblBuilderMarkup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBuilderCost
        '
        Me.txtBuilderCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBuilderCost.Enabled = False
        Me.txtBuilderCost.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtBuilderCost.Location = New System.Drawing.Point(138, 135)
        Me.txtBuilderCost.MaxLength = 50
        Me.txtBuilderCost.Name = "txtBuilderCost"
        Me.txtBuilderCost.Size = New System.Drawing.Size(78, 21)
        Me.txtBuilderCost.TabIndex = 74
        '
        'lblBuilderCost
        '
        Me.lblBuilderCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBuilderCost.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblBuilderCost.Location = New System.Drawing.Point(9, 133)
        Me.lblBuilderCost.Name = "lblBuilderCost"
        Me.lblBuilderCost.Size = New System.Drawing.Size(147, 23)
        Me.lblBuilderCost.TabIndex = 77
        Me.lblBuilderCost.Text = "Builder Cost"
        Me.lblBuilderCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtElectricianCharge
        '
        Me.txtElectricianCharge.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtElectricianCharge.Enabled = False
        Me.txtElectricianCharge.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtElectricianCharge.Location = New System.Drawing.Point(512, 112)
        Me.txtElectricianCharge.Name = "txtElectricianCharge"
        Me.txtElectricianCharge.ReadOnly = True
        Me.txtElectricianCharge.Size = New System.Drawing.Size(72, 21)
        Me.txtElectricianCharge.TabIndex = 67
        '
        'lblTotalElectricianCharge
        '
        Me.lblTotalElectricianCharge.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalElectricianCharge.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblTotalElectricianCharge.Location = New System.Drawing.Point(344, 109)
        Me.lblTotalElectricianCharge.Name = "lblTotalElectricianCharge"
        Me.lblTotalElectricianCharge.Size = New System.Drawing.Size(168, 23)
        Me.lblTotalElectricianCharge.TabIndex = 73
        Me.lblTotalElectricianCharge.Text = "Total Electrician Charge"
        Me.lblTotalElectricianCharge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtElectricianMarkup
        '
        Me.txtElectricianMarkup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtElectricianMarkup.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtElectricianMarkup.Location = New System.Drawing.Point(292, 112)
        Me.txtElectricianMarkup.Name = "txtElectricianMarkup"
        Me.txtElectricianMarkup.Size = New System.Drawing.Size(48, 21)
        Me.txtElectricianMarkup.TabIndex = 66
        '
        'lblElectricianMarkup
        '
        Me.lblElectricianMarkup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblElectricianMarkup.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblElectricianMarkup.Location = New System.Drawing.Point(219, 109)
        Me.lblElectricianMarkup.Name = "lblElectricianMarkup"
        Me.lblElectricianMarkup.Size = New System.Drawing.Size(80, 23)
        Me.lblElectricianMarkup.TabIndex = 72
        Me.lblElectricianMarkup.Text = "Markup (%)"
        Me.lblElectricianMarkup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtElectricianCost
        '
        Me.txtElectricianCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtElectricianCost.Enabled = False
        Me.txtElectricianCost.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtElectricianCost.Location = New System.Drawing.Point(138, 112)
        Me.txtElectricianCost.MaxLength = 50
        Me.txtElectricianCost.Name = "txtElectricianCost"
        Me.txtElectricianCost.Size = New System.Drawing.Size(78, 21)
        Me.txtElectricianCost.TabIndex = 65
        '
        'lblElectricianCost
        '
        Me.lblElectricianCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblElectricianCost.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblElectricianCost.Location = New System.Drawing.Point(9, 110)
        Me.lblElectricianCost.Name = "lblElectricianCost"
        Me.lblElectricianCost.Size = New System.Drawing.Size(147, 23)
        Me.lblElectricianCost.TabIndex = 71
        Me.lblElectricianCost.Text = "Electrician Cost"
        Me.lblElectricianCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInstallerCharge
        '
        Me.txtInstallerCharge.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInstallerCharge.Enabled = False
        Me.txtInstallerCharge.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtInstallerCharge.Location = New System.Drawing.Point(512, 88)
        Me.txtInstallerCharge.Name = "txtInstallerCharge"
        Me.txtInstallerCharge.ReadOnly = True
        Me.txtInstallerCharge.Size = New System.Drawing.Size(72, 21)
        Me.txtInstallerCharge.TabIndex = 64
        '
        'lblTotalInstallerCharge
        '
        Me.lblTotalInstallerCharge.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalInstallerCharge.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblTotalInstallerCharge.Location = New System.Drawing.Point(344, 86)
        Me.lblTotalInstallerCharge.Name = "lblTotalInstallerCharge"
        Me.lblTotalInstallerCharge.Size = New System.Drawing.Size(160, 23)
        Me.lblTotalInstallerCharge.TabIndex = 70
        Me.lblTotalInstallerCharge.Text = "Total Installer Charge"
        Me.lblTotalInstallerCharge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInstallerMarkup
        '
        Me.txtInstallerMarkup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInstallerMarkup.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtInstallerMarkup.Location = New System.Drawing.Point(292, 88)
        Me.txtInstallerMarkup.Name = "txtInstallerMarkup"
        Me.txtInstallerMarkup.Size = New System.Drawing.Size(48, 21)
        Me.txtInstallerMarkup.TabIndex = 63
        '
        'lblInstallerMarkup
        '
        Me.lblInstallerMarkup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInstallerMarkup.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblInstallerMarkup.Location = New System.Drawing.Point(219, 86)
        Me.lblInstallerMarkup.Name = "lblInstallerMarkup"
        Me.lblInstallerMarkup.Size = New System.Drawing.Size(80, 23)
        Me.lblInstallerMarkup.TabIndex = 69
        Me.lblInstallerMarkup.Text = "Markup (%)"
        Me.lblInstallerMarkup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInstallerCost
        '
        Me.txtInstallerCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInstallerCost.Enabled = False
        Me.txtInstallerCost.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtInstallerCost.Location = New System.Drawing.Point(138, 88)
        Me.txtInstallerCost.MaxLength = 50
        Me.txtInstallerCost.Name = "txtInstallerCost"
        Me.txtInstallerCost.Size = New System.Drawing.Size(78, 21)
        Me.txtInstallerCost.TabIndex = 62
        '
        'lblInstallerCost
        '
        Me.lblInstallerCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInstallerCost.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblInstallerCost.Location = New System.Drawing.Point(9, 86)
        Me.lblInstallerCost.Name = "lblInstallerCost"
        Me.lblInstallerCost.Size = New System.Drawing.Size(136, 23)
        Me.lblInstallerCost.TabIndex = 68
        Me.lblInstallerCost.Text = "Installer Cost"
        Me.lblInstallerCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtScheduleRatesCostTotal
        '
        Me.txtScheduleRatesCostTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtScheduleRatesCostTotal.Enabled = False
        Me.txtScheduleRatesCostTotal.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtScheduleRatesCostTotal.Location = New System.Drawing.Point(512, 63)
        Me.txtScheduleRatesCostTotal.Name = "txtScheduleRatesCostTotal"
        Me.txtScheduleRatesCostTotal.ReadOnly = True
        Me.txtScheduleRatesCostTotal.Size = New System.Drawing.Size(72, 21)
        Me.txtScheduleRatesCostTotal.TabIndex = 12
        '
        'lblTotalSORCharge
        '
        Me.lblTotalSORCharge.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalSORCharge.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblTotalSORCharge.Location = New System.Drawing.Point(344, 62)
        Me.lblTotalSORCharge.Name = "lblTotalSORCharge"
        Me.lblTotalSORCharge.Size = New System.Drawing.Size(168, 23)
        Me.lblTotalSORCharge.TabIndex = 61
        Me.lblTotalSORCharge.Text = "Total SOR Charge"
        Me.lblTotalSORCharge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtScheduleRateMarkup
        '
        Me.txtScheduleRateMarkup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtScheduleRateMarkup.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtScheduleRateMarkup.Location = New System.Drawing.Point(292, 63)
        Me.txtScheduleRateMarkup.Name = "txtScheduleRateMarkup"
        Me.txtScheduleRateMarkup.Size = New System.Drawing.Size(48, 21)
        Me.txtScheduleRateMarkup.TabIndex = 11
        '
        'lblSORMarkup
        '
        Me.lblSORMarkup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSORMarkup.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblSORMarkup.Location = New System.Drawing.Point(219, 60)
        Me.lblSORMarkup.Name = "lblSORMarkup"
        Me.lblSORMarkup.Size = New System.Drawing.Size(80, 23)
        Me.lblSORMarkup.TabIndex = 59
        Me.lblSORMarkup.Text = "Markup (%)"
        Me.lblSORMarkup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtScheduleRatesCost
        '
        Me.txtScheduleRatesCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtScheduleRatesCost.Enabled = False
        Me.txtScheduleRatesCost.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtScheduleRatesCost.Location = New System.Drawing.Point(138, 63)
        Me.txtScheduleRatesCost.MaxLength = 50
        Me.txtScheduleRatesCost.Name = "txtScheduleRatesCost"
        Me.txtScheduleRatesCost.Size = New System.Drawing.Size(78, 21)
        Me.txtScheduleRatesCost.TabIndex = 10
        '
        'lblSORCost
        '
        Me.lblSORCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSORCost.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblSORCost.Location = New System.Drawing.Point(9, 60)
        Me.lblSORCost.Name = "lblSORCost"
        Me.lblSORCost.Size = New System.Drawing.Size(147, 23)
        Me.lblSORCost.TabIndex = 57
        Me.lblSORCost.Text = "SOR Cost"
        Me.lblSORCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalPartsCharge
        '
        Me.lblTotalPartsCharge.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalPartsCharge.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblTotalPartsCharge.Location = New System.Drawing.Point(344, 39)
        Me.lblTotalPartsCharge.Name = "lblTotalPartsCharge"
        Me.lblTotalPartsCharge.Size = New System.Drawing.Size(181, 23)
        Me.lblTotalPartsCharge.TabIndex = 54
        Me.lblTotalPartsCharge.Text = "Total Parts Charge"
        Me.lblTotalPartsCharge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPartsProductsMarkup
        '
        Me.txtPartsProductsMarkup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartsProductsMarkup.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtPartsProductsMarkup.Location = New System.Drawing.Point(292, 39)
        Me.txtPartsProductsMarkup.Name = "txtPartsProductsMarkup"
        Me.txtPartsProductsMarkup.Size = New System.Drawing.Size(48, 21)
        Me.txtPartsProductsMarkup.TabIndex = 8
        '
        'lblPartsMarkup
        '
        Me.lblPartsMarkup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPartsMarkup.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblPartsMarkup.Location = New System.Drawing.Point(219, 37)
        Me.lblPartsMarkup.Name = "lblPartsMarkup"
        Me.lblPartsMarkup.Size = New System.Drawing.Size(80, 23)
        Me.lblPartsMarkup.TabIndex = 52
        Me.lblPartsMarkup.Text = "Markup (%)"
        Me.lblPartsMarkup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBOC
        '
        Me.txtBOC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBOC.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtBOC.Location = New System.Drawing.Point(512, 183)
        Me.txtBOC.MaxLength = 50
        Me.txtBOC.Name = "txtBOC"
        Me.txtBOC.ReadOnly = True
        Me.txtBOC.Size = New System.Drawing.Size(72, 21)
        Me.txtBOC.TabIndex = 16
        '
        'txtPartsCost
        '
        Me.txtPartsCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartsCost.Enabled = False
        Me.txtPartsCost.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtPartsCost.Location = New System.Drawing.Point(138, 39)
        Me.txtPartsCost.MaxLength = 50
        Me.txtPartsCost.Name = "txtPartsCost"
        Me.txtPartsCost.Size = New System.Drawing.Size(78, 21)
        Me.txtPartsCost.TabIndex = 7
        '
        'lblPartsCost
        '
        Me.lblPartsCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPartsCost.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblPartsCost.Location = New System.Drawing.Point(9, 37)
        Me.lblPartsCost.Name = "lblPartsCost"
        Me.lblPartsCost.Size = New System.Drawing.Size(136, 23)
        Me.lblPartsCost.TabIndex = 50
        Me.lblPartsCost.Text = "Parts Cost"
        Me.lblPartsCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpParts
        '
        Me.grpParts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpParts.Controls.Add(Me.btnRemovePartProduct)
        Me.grpParts.Controls.Add(Me.btnFindPart)
        Me.grpParts.Controls.Add(Me.dgPartsAndProducts)
        Me.grpParts.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.grpParts.Location = New System.Drawing.Point(579, 230)
        Me.grpParts.Name = "grpParts"
        Me.grpParts.Size = New System.Drawing.Size(592, 254)
        Me.grpParts.TabIndex = 8
        Me.grpParts.TabStop = False
        Me.grpParts.Text = "Parts && Products Required"
        '
        'btnRemovePartProduct
        '
        Me.btnRemovePartProduct.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemovePartProduct.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnRemovePartProduct.Location = New System.Drawing.Point(481, 226)
        Me.btnRemovePartProduct.Name = "btnRemovePartProduct"
        Me.btnRemovePartProduct.Size = New System.Drawing.Size(96, 22)
        Me.btnRemovePartProduct.TabIndex = 3
        Me.btnRemovePartProduct.Text = "Remove"
        '
        'btnFindPart
        '
        Me.btnFindPart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFindPart.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnFindPart.Location = New System.Drawing.Point(9, 226)
        Me.btnFindPart.Name = "btnFindPart"
        Me.btnFindPart.Size = New System.Drawing.Size(88, 22)
        Me.btnFindPart.TabIndex = 1
        Me.btnFindPart.Text = "Add Part"
        '
        'dgPartsAndProducts
        '
        Me.dgPartsAndProducts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgPartsAndProducts.DataMember = ""
        Me.dgPartsAndProducts.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dgPartsAndProducts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgPartsAndProducts.Location = New System.Drawing.Point(12, 25)
        Me.dgPartsAndProducts.Name = "dgPartsAndProducts"
        Me.dgPartsAndProducts.Size = New System.Drawing.Size(564, 195)
        Me.dgPartsAndProducts.TabIndex = 10
        '
        'dtpQuoteDate
        '
        Me.dtpQuoteDate.CalendarFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpQuoteDate.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.dtpQuoteDate.Location = New System.Drawing.Point(560, 2)
        Me.dtpQuoteDate.Name = "dtpQuoteDate"
        Me.dtpQuoteDate.Size = New System.Drawing.Size(151, 21)
        Me.dtpQuoteDate.TabIndex = 2
        Me.dtpQuoteDate.Value = New Date(2007, 8, 13, 15, 56, 20, 616)
        '
        'txtSiteName
        '
        Me.txtSiteName.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtSiteName.Location = New System.Drawing.Point(77, 38)
        Me.txtSiteName.Name = "txtSiteName"
        Me.txtSiteName.ReadOnly = True
        Me.txtSiteName.Size = New System.Drawing.Size(172, 21)
        Me.txtSiteName.TabIndex = 49
        Me.txtSiteName.TabStop = False
        '
        'lblProperty
        '
        Me.lblProperty.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblProperty.Location = New System.Drawing.Point(8, 37)
        Me.lblProperty.Name = "lblProperty"
        Me.lblProperty.Size = New System.Drawing.Size(80, 23)
        Me.lblProperty.TabIndex = 55
        Me.lblProperty.Text = "Property:"
        '
        'lblQuoteRef
        '
        Me.lblQuoteRef.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblQuoteRef.Location = New System.Drawing.Point(251, 37)
        Me.lblQuoteRef.Name = "lblQuoteRef"
        Me.lblQuoteRef.Size = New System.Drawing.Size(73, 23)
        Me.lblQuoteRef.TabIndex = 57
        Me.lblQuoteRef.Text = "Quote Ref:"
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtCustomerName.Location = New System.Drawing.Point(77, 3)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.ReadOnly = True
        Me.txtCustomerName.Size = New System.Drawing.Size(172, 21)
        Me.txtCustomerName.TabIndex = 48
        Me.txtCustomerName.TabStop = False
        '
        'gpOtherLabour
        '
        Me.gpOtherLabour.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpOtherLabour.Controls.Add(Me.txtBuilderArrivalHour)
        Me.gpOtherLabour.Controls.Add(Me.lblBuilderHour)
        Me.gpOtherLabour.Controls.Add(Me.txtBuilderArrivalDay)
        Me.gpOtherLabour.Controls.Add(Me.lblArrivalDay)
        Me.gpOtherLabour.Controls.Add(Me.txtBuilderHours)
        Me.gpOtherLabour.Controls.Add(Me.txtBuilderNotes)
        Me.gpOtherLabour.Controls.Add(Me.lblBuilderNotes)
        Me.gpOtherLabour.Controls.Add(Me.lblBuilderLabourHours)
        Me.gpOtherLabour.Controls.Add(Me.lblBuilderLabour)
        Me.gpOtherLabour.Controls.Add(Me.txtElectricianArrivalHour)
        Me.gpOtherLabour.Controls.Add(Me.lblElectricianHour)
        Me.gpOtherLabour.Controls.Add(Me.txtElectricianArrivalDay)
        Me.gpOtherLabour.Controls.Add(Me.lblElectricianArrivalDay)
        Me.gpOtherLabour.Controls.Add(Me.txtElectricianHours)
        Me.gpOtherLabour.Controls.Add(Me.txtElectricianNotes)
        Me.gpOtherLabour.Controls.Add(Me.lblElectricianNotes)
        Me.gpOtherLabour.Controls.Add(Me.lblElectricianPackHours)
        Me.gpOtherLabour.Controls.Add(Me.lblElectOr)
        Me.gpOtherLabour.Controls.Add(Me.cboElectricalPack)
        Me.gpOtherLabour.Controls.Add(Me.lblElectricianPack)
        Me.gpOtherLabour.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.gpOtherLabour.Location = New System.Drawing.Point(579, 72)
        Me.gpOtherLabour.Name = "gpOtherLabour"
        Me.gpOtherLabour.Size = New System.Drawing.Size(592, 152)
        Me.gpOtherLabour.TabIndex = 65
        Me.gpOtherLabour.TabStop = False
        Me.gpOtherLabour.Text = "Other Labour"
        '
        'txtBuilderArrivalHour
        '
        Me.txtBuilderArrivalHour.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBuilderArrivalHour.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtBuilderArrivalHour.Location = New System.Drawing.Point(543, 83)
        Me.txtBuilderArrivalHour.MaxLength = 50
        Me.txtBuilderArrivalHour.Name = "txtBuilderArrivalHour"
        Me.txtBuilderArrivalHour.Size = New System.Drawing.Size(33, 21)
        Me.txtBuilderArrivalHour.TabIndex = 40
        Me.txtBuilderArrivalHour.Tag = "SystemScheduleOfRate.Code"
        '
        'lblBuilderHour
        '
        Me.lblBuilderHour.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBuilderHour.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblBuilderHour.Location = New System.Drawing.Point(503, 86)
        Me.lblBuilderHour.Name = "lblBuilderHour"
        Me.lblBuilderHour.Size = New System.Drawing.Size(40, 20)
        Me.lblBuilderHour.TabIndex = 39
        Me.lblBuilderHour.Text = "Hour"
        '
        'txtBuilderArrivalDay
        '
        Me.txtBuilderArrivalDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBuilderArrivalDay.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtBuilderArrivalDay.Location = New System.Drawing.Point(467, 83)
        Me.txtBuilderArrivalDay.MaxLength = 50
        Me.txtBuilderArrivalDay.Name = "txtBuilderArrivalDay"
        Me.txtBuilderArrivalDay.Size = New System.Drawing.Size(33, 21)
        Me.txtBuilderArrivalDay.TabIndex = 38
        Me.txtBuilderArrivalDay.Tag = "SystemScheduleOfRate.Code"
        '
        'lblArrivalDay
        '
        Me.lblArrivalDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblArrivalDay.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblArrivalDay.Location = New System.Drawing.Point(394, 86)
        Me.lblArrivalDay.Name = "lblArrivalDay"
        Me.lblArrivalDay.Size = New System.Drawing.Size(77, 20)
        Me.lblArrivalDay.TabIndex = 37
        Me.lblArrivalDay.Text = "Arrival Day"
        '
        'txtBuilderHours
        '
        Me.txtBuilderHours.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBuilderHours.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtBuilderHours.Location = New System.Drawing.Point(123, 82)
        Me.txtBuilderHours.MaxLength = 50
        Me.txtBuilderHours.Name = "txtBuilderHours"
        Me.txtBuilderHours.Size = New System.Drawing.Size(58, 21)
        Me.txtBuilderHours.TabIndex = 33
        Me.txtBuilderHours.Tag = "SystemScheduleOfRate.Code"
        '
        'txtBuilderNotes
        '
        Me.txtBuilderNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBuilderNotes.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtBuilderNotes.Location = New System.Drawing.Point(123, 109)
        Me.txtBuilderNotes.MaxLength = 50
        Me.txtBuilderNotes.Multiline = True
        Me.txtBuilderNotes.Name = "txtBuilderNotes"
        Me.txtBuilderNotes.Size = New System.Drawing.Size(453, 30)
        Me.txtBuilderNotes.TabIndex = 30
        Me.txtBuilderNotes.Tag = "SystemScheduleOfRate.Code"
        '
        'lblBuilderNotes
        '
        Me.lblBuilderNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBuilderNotes.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblBuilderNotes.Location = New System.Drawing.Point(8, 110)
        Me.lblBuilderNotes.Name = "lblBuilderNotes"
        Me.lblBuilderNotes.Size = New System.Drawing.Size(109, 20)
        Me.lblBuilderNotes.TabIndex = 36
        Me.lblBuilderNotes.Text = "Builder Notes"
        '
        'lblBuilderLabourHours
        '
        Me.lblBuilderLabourHours.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBuilderLabourHours.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblBuilderLabourHours.Location = New System.Drawing.Point(184, 85)
        Me.lblBuilderLabourHours.Name = "lblBuilderLabourHours"
        Me.lblBuilderLabourHours.Size = New System.Drawing.Size(32, 20)
        Me.lblBuilderLabourHours.TabIndex = 35
        Me.lblBuilderLabourHours.Text = "Hrs"
        '
        'lblBuilderLabour
        '
        Me.lblBuilderLabour.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBuilderLabour.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblBuilderLabour.Location = New System.Drawing.Point(8, 85)
        Me.lblBuilderLabour.Name = "lblBuilderLabour"
        Me.lblBuilderLabour.Size = New System.Drawing.Size(109, 20)
        Me.lblBuilderLabour.TabIndex = 32
        Me.lblBuilderLabour.Text = "Builder Labour"
        '
        'txtElectricianArrivalHour
        '
        Me.txtElectricianArrivalHour.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtElectricianArrivalHour.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtElectricianArrivalHour.Location = New System.Drawing.Point(543, 15)
        Me.txtElectricianArrivalHour.MaxLength = 50
        Me.txtElectricianArrivalHour.Name = "txtElectricianArrivalHour"
        Me.txtElectricianArrivalHour.Size = New System.Drawing.Size(33, 21)
        Me.txtElectricianArrivalHour.TabIndex = 29
        Me.txtElectricianArrivalHour.Tag = "SystemScheduleOfRate.Code"
        '
        'lblElectricianHour
        '
        Me.lblElectricianHour.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblElectricianHour.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblElectricianHour.Location = New System.Drawing.Point(503, 18)
        Me.lblElectricianHour.Name = "lblElectricianHour"
        Me.lblElectricianHour.Size = New System.Drawing.Size(40, 20)
        Me.lblElectricianHour.TabIndex = 28
        Me.lblElectricianHour.Text = "Hour"
        '
        'txtElectricianArrivalDay
        '
        Me.txtElectricianArrivalDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtElectricianArrivalDay.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtElectricianArrivalDay.Location = New System.Drawing.Point(467, 15)
        Me.txtElectricianArrivalDay.MaxLength = 50
        Me.txtElectricianArrivalDay.Name = "txtElectricianArrivalDay"
        Me.txtElectricianArrivalDay.Size = New System.Drawing.Size(33, 21)
        Me.txtElectricianArrivalDay.TabIndex = 27
        Me.txtElectricianArrivalDay.Tag = "SystemScheduleOfRate.Code"
        '
        'lblElectricianArrivalDay
        '
        Me.lblElectricianArrivalDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblElectricianArrivalDay.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblElectricianArrivalDay.Location = New System.Drawing.Point(394, 18)
        Me.lblElectricianArrivalDay.Name = "lblElectricianArrivalDay"
        Me.lblElectricianArrivalDay.Size = New System.Drawing.Size(77, 20)
        Me.lblElectricianArrivalDay.TabIndex = 26
        Me.lblElectricianArrivalDay.Text = "Arrival Day"
        '
        'txtElectricianHours
        '
        Me.txtElectricianHours.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtElectricianHours.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtElectricianHours.Location = New System.Drawing.Point(265, 15)
        Me.txtElectricianHours.MaxLength = 50
        Me.txtElectricianHours.Name = "txtElectricianHours"
        Me.txtElectricianHours.Size = New System.Drawing.Size(58, 21)
        Me.txtElectricianHours.TabIndex = 22
        Me.txtElectricianHours.Tag = "SystemScheduleOfRate.Code"
        '
        'txtElectricianNotes
        '
        Me.txtElectricianNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtElectricianNotes.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtElectricianNotes.Location = New System.Drawing.Point(123, 41)
        Me.txtElectricianNotes.MaxLength = 50
        Me.txtElectricianNotes.Multiline = True
        Me.txtElectricianNotes.Name = "txtElectricianNotes"
        Me.txtElectricianNotes.Size = New System.Drawing.Size(453, 36)
        Me.txtElectricianNotes.TabIndex = 21
        Me.txtElectricianNotes.Tag = "SystemScheduleOfRate.Code"
        '
        'lblElectricianNotes
        '
        Me.lblElectricianNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblElectricianNotes.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblElectricianNotes.Location = New System.Drawing.Point(8, 42)
        Me.lblElectricianNotes.Name = "lblElectricianNotes"
        Me.lblElectricianNotes.Size = New System.Drawing.Size(109, 20)
        Me.lblElectricianNotes.TabIndex = 25
        Me.lblElectricianNotes.Text = "Electrician Notes"
        '
        'lblElectricianPackHours
        '
        Me.lblElectricianPackHours.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblElectricianPackHours.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblElectricianPackHours.Location = New System.Drawing.Point(326, 18)
        Me.lblElectricianPackHours.Name = "lblElectricianPackHours"
        Me.lblElectricianPackHours.Size = New System.Drawing.Size(32, 20)
        Me.lblElectricianPackHours.TabIndex = 24
        Me.lblElectricianPackHours.Text = "Hrs"
        '
        'lblElectOr
        '
        Me.lblElectOr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblElectOr.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblElectOr.Location = New System.Drawing.Point(241, 18)
        Me.lblElectOr.Name = "lblElectOr"
        Me.lblElectOr.Size = New System.Drawing.Size(31, 20)
        Me.lblElectOr.TabIndex = 23
        Me.lblElectOr.Text = "Or"
        '
        'cboElectricalPack
        '
        Me.cboElectricalPack.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboElectricalPack.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboElectricalPack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboElectricalPack.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.cboElectricalPack.Location = New System.Drawing.Point(123, 16)
        Me.cboElectricalPack.Name = "cboElectricalPack"
        Me.cboElectricalPack.Size = New System.Drawing.Size(116, 21)
        Me.cboElectricalPack.TabIndex = 21
        Me.cboElectricalPack.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID"
        '
        'lblElectricianPack
        '
        Me.lblElectricianPack.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblElectricianPack.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblElectricianPack.Location = New System.Drawing.Point(8, 17)
        Me.lblElectricianPack.Name = "lblElectricianPack"
        Me.lblElectricianPack.Size = New System.Drawing.Size(109, 20)
        Me.lblElectricianPack.TabIndex = 21
        Me.lblElectricianPack.Text = "Electrician Pack"
        '
        'txtSurveyor
        '
        Me.txtSurveyor.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtSurveyor.Location = New System.Drawing.Point(821, 2)
        Me.txtSurveyor.MaxLength = 50
        Me.txtSurveyor.Name = "txtSurveyor"
        Me.txtSurveyor.ReadOnly = True
        Me.txtSurveyor.Size = New System.Drawing.Size(204, 21)
        Me.txtSurveyor.TabIndex = 66
        '
        'lblSurveyor
        '
        Me.lblSurveyor.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblSurveyor.Location = New System.Drawing.Point(715, 6)
        Me.lblSurveyor.Name = "lblSurveyor"
        Me.lblSurveyor.Size = New System.Drawing.Size(76, 23)
        Me.lblSurveyor.TabIndex = 67
        Me.lblSurveyor.Text = "Surveyor"
        '
        'lblLastChangedOn
        '
        Me.lblLastChangedOn.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblLastChangedOn.Location = New System.Drawing.Point(714, 40)
        Me.lblLastChangedOn.Name = "lblLastChangedOn"
        Me.lblLastChangedOn.Size = New System.Drawing.Size(106, 23)
        Me.lblLastChangedOn.TabIndex = 68
        Me.lblLastChangedOn.Text = "Last Changed On"
        '
        'txtChangedDate
        '
        Me.txtChangedDate.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtChangedDate.Location = New System.Drawing.Point(821, 38)
        Me.txtChangedDate.MaxLength = 50
        Me.txtChangedDate.Name = "txtChangedDate"
        Me.txtChangedDate.ReadOnly = True
        Me.txtChangedDate.Size = New System.Drawing.Size(66, 21)
        Me.txtChangedDate.TabIndex = 69
        '
        'lblChangedBy
        '
        Me.lblChangedBy.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblChangedBy.Location = New System.Drawing.Point(890, 39)
        Me.lblChangedBy.Name = "lblChangedBy"
        Me.lblChangedBy.Size = New System.Drawing.Size(29, 23)
        Me.lblChangedBy.TabIndex = 70
        Me.lblChangedBy.Text = "by"
        '
        'txtChangedBy
        '
        Me.txtChangedBy.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtChangedBy.Location = New System.Drawing.Point(914, 38)
        Me.txtChangedBy.MaxLength = 50
        Me.txtChangedBy.Name = "txtChangedBy"
        Me.txtChangedBy.ReadOnly = True
        Me.txtChangedBy.Size = New System.Drawing.Size(111, 21)
        Me.txtChangedBy.TabIndex = 71
        '
        'lblPurchaseDept
        '
        Me.lblPurchaseDept.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblPurchaseDept.Location = New System.Drawing.Point(1031, 26)
        Me.lblPurchaseDept.Name = "lblPurchaseDept"
        Me.lblPurchaseDept.Size = New System.Drawing.Size(125, 16)
        Me.lblPurchaseDept.TabIndex = 72
        Me.lblPurchaseDept.Text = "Purchase Dept"
        Me.lblPurchaseDept.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cboDept
        '
        Me.cboDept.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDept.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDept.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.cboDept.Location = New System.Drawing.Point(1039, 39)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New System.Drawing.Size(116, 21)
        Me.cboDept.TabIndex = 41
        Me.cboDept.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID"
        '
        'chkService
        '
        Me.chkService.AutoSize = True
        Me.chkService.Checked = True
        Me.chkService.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkService.Location = New System.Drawing.Point(1039, 5)
        Me.chkService.Name = "chkService"
        Me.chkService.Size = New System.Drawing.Size(53, 17)
        Me.chkService.TabIndex = 73
        Me.chkService.Text = "Serv"
        Me.chkService.UseVisualStyleBackColor = True
        '
        'chkHOver
        '
        Me.chkHOver.AutoSize = True
        Me.chkHOver.Checked = True
        Me.chkHOver.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHOver.Location = New System.Drawing.Point(1098, 5)
        Me.chkHOver.Name = "chkHOver"
        Me.chkHOver.Size = New System.Drawing.Size(66, 17)
        Me.chkHOver.TabIndex = 74
        Me.chkHOver.Text = "H.Over"
        Me.chkHOver.UseVisualStyleBackColor = True
        '
        'UCQuoteJob
        '
        Me.Controls.Add(Me.chkHOver)
        Me.Controls.Add(Me.chkService)
        Me.Controls.Add(Me.cboDept)
        Me.Controls.Add(Me.txtCustomerName)
        Me.Controls.Add(Me.cboQuoteStatus)
        Me.Controls.Add(Me.lblPurchaseDept)
        Me.Controls.Add(Me.txtChangedBy)
        Me.Controls.Add(Me.lblChangedBy)
        Me.Controls.Add(Me.txtChangedDate)
        Me.Controls.Add(Me.lblLastChangedOn)
        Me.Controls.Add(Me.txtSurveyor)
        Me.Controls.Add(Me.lblSurveyor)
        Me.Controls.Add(Me.gpOtherLabour)
        Me.Controls.Add(Me.grpRates)
        Me.Controls.Add(Me.lblQuoteStatus)
        Me.Controls.Add(Me.lblQuoteDate)
        Me.Controls.Add(Me.grpJobItems)
        Me.Controls.Add(Me.txtReference)
        Me.Controls.Add(Me.cboJobType)
        Me.Controls.Add(Me.lblJobType)
        Me.Controls.Add(Me.lblCustomer)
        Me.Controls.Add(Me.grpTotals)
        Me.Controls.Add(Me.grpParts)
        Me.Controls.Add(Me.dtpQuoteDate)
        Me.Controls.Add(Me.txtSiteName)
        Me.Controls.Add(Me.lblProperty)
        Me.Controls.Add(Me.lblQuoteRef)
        Me.Name = "UCQuoteJob"
        Me.Size = New System.Drawing.Size(1179, 705)
        Me.grpRates.ResumeLayout(False)
        Me.grpRates.PerformLayout()
        CType(Me.dgScheduleOfRates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpJobItems.ResumeLayout(False)
        Me.grpJobItems.PerformLayout()
        Me.grpTotals.ResumeLayout(False)
        Me.grpTotals.PerformLayout()
        Me.grpParts.ResumeLayout(False)
        CType(Me.dgPartsAndProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpOtherLabour.ResumeLayout(False)
        Me.gpOtherLabour.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
        SetupPartsAndProductsDataGrid()
        SetupScheduleOfRatesDataGrid()
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentQuoteJob
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Public Event RefreshButton()

    Private _CurrentSite As Entity.Sites.Site

    Public Property CurrentSite() As Entity.Sites.Site
        Get
            Return _CurrentSite
        End Get
        Set(ByVal Value As Entity.Sites.Site)
            _CurrentSite = Value

            CurrentQuoteJob.SetSiteID = CurrentSite.SiteID
            If Not CurrentQuoteJob.Exists = True Then
                CustomerCharge = DB.CustomerCharge.CustomerCharge_GetForCustomer(CurrentSite.CustomerID)
                If Not IsNothing(CustomerCharge) Then
                    Me.txtPartsProductsMarkup.Text = CustomerCharge.PartsMarkup & "%"
                    Me.txtScheduleRateMarkup.Text = CustomerCharge.RatesMarkup & "%"
                End If
                QuoteNumber = DB.QuoteJob.GetNextQuoteNumber
                If Not IsNothing(QuoteNumber) Then
                    Me.txtReference.Text = QuoteNumber.Prefix & QuoteNumber.JobNumber
                End If
            End If

            Me.txtSiteName.Text = CurrentSite.Address1 & " " & CurrentSite.Address2 & ", " & CurrentSite.Postcode
            Me.txtCustomerName.Text = DB.Customer.Customer_Get(CurrentSite.CustomerID).Name

            If AssetsDataView Is Nothing Then
                AssetsDataView = DB.Asset.Asset_GetForSite(CurrentSite.SiteID)
            End If
        End Set
    End Property

    Private _CustomerCharge As Entity.CustomerCharges.CustomerCharge

    Public Property CustomerCharge() As Entity.CustomerCharges.CustomerCharge
        Get
            Return _CustomerCharge
        End Get
        Set(ByVal Value As Entity.CustomerCharges.CustomerCharge)
            _CustomerCharge = Value
        End Set
    End Property

    Private _CurrentQuoteJob As Entity.QuoteJobs.QuoteJob

    Public Property CurrentQuoteJob() As Entity.QuoteJobs.QuoteJob
        Get
            Return _CurrentQuoteJob
        End Get
        Set(ByVal Value As Entity.QuoteJobs.QuoteJob)
            _CurrentQuoteJob = Value

            If _CurrentQuoteJob Is Nothing Then
                _CurrentQuoteJob = New Entity.QuoteJobs.QuoteJob
                _CurrentQuoteJob.Exists = False
                _CurrentQuoteJob.ScheduleOfRates = BuildUpScheduleOfRatesDataview()

            End If

            Me.dtpQuoteDate.Value = Now
            Loading = True
            Populate()
            Loading = False

            PartsAndProducts = CurrentQuoteJob.QuoteJobPartsAndProducts
        End Set
    End Property

    Private _AssetsTable As DataView = Nothing

    Public Property AssetsDataView() As DataView
        Get
            Return _AssetsTable
        End Get
        Set(ByVal Value As DataView)
            _AssetsTable = Value
            _AssetsTable.Table.TableName = Entity.Sys.Enums.TableNames.tblQuoteJobAssets.ToString
            _AssetsTable.AllowNew = False
            _AssetsTable.AllowEdit = False
            _AssetsTable.AllowDelete = False
        End Set
    End Property

    Private _PartsAndProducts As DataView = Nothing

    Public Property PartsAndProducts() As DataView
        Get
            Return _PartsAndProducts
        End Get
        Set(ByVal Value As DataView)
            _PartsAndProducts = Value
            _PartsAndProducts.Table.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString
            _PartsAndProducts.AllowNew = False
            _PartsAndProducts.AllowEdit = False
            _PartsAndProducts.AllowDelete = False
            Me.dgPartsAndProducts.DataSource = PartsAndProducts
        End Set
    End Property

    Private ReadOnly Property SelectedAssetDataRow() As DataRow
        Get
            Return Nothing
        End Get
    End Property

    Private ReadOnly Property SelectedRatesDataRow() As DataRow
        Get
            If Not Me.dgScheduleOfRates.CurrentRowIndex = -1 Then
                Return CurrentQuoteJob.ScheduleOfRates(Me.dgScheduleOfRates.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _JobItemsTable As DataView = Nothing

    Public Property JobItemsDataView() As DataView
        Get
            Return _JobItemsTable
        End Get
        Set(ByVal Value As DataView)
            _JobItemsTable = Value
            _JobItemsTable.Table.TableName = Entity.Sys.Enums.TableNames.tblQuoteJobItem.ToString
            _JobItemsTable.AllowNew = False
            _JobItemsTable.AllowEdit = False
            _JobItemsTable.AllowDelete = False
        End Set
    End Property

    Private ReadOnly Property SelectedItemDataRow() As DataRow
        Get
            Return Nothing
        End Get
    End Property

    Private _JobItemState As Entity.Sys.Enums.FormState = Entity.Sys.Enums.FormState.Insert

    Private _loading As Boolean = False

    Private Property Loading() As Boolean
        Get
            Return _loading
        End Get
        Set(ByVal Value As Boolean)
            _loading = Value
        End Set
    End Property

    Private _PartProductID As Integer = 0

    Public Property PartProductID() As Integer
        Get
            Return _PartProductID
        End Get
        Set(ByVal Value As Integer)
            _PartProductID = Value
        End Set
    End Property

    Private _QuoteNumberUsed As Boolean = False

    Public Property QuoteNumberUsed() As Boolean
        Get
            Return _QuoteNumberUsed
        End Get
        Set(ByVal Value As Boolean)
            _QuoteNumberUsed = Value
        End Set
    End Property

    Private _QuoteNumber As New JobNumber

    Public Property QuoteNumber() As JobNumber
        Get
            Return _QuoteNumber
        End Get
        Set(ByVal Value As JobNumber)
            _QuoteNumber = Value
        End Set
    End Property

    Private _TotalCosts As Double

    Public Property TotalCosts() As Double
        Get
            Return _TotalCosts
        End Get
        Set(ByVal Value As Double)
            _TotalCosts = Value
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub UCQuoteJob_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub txtPartsTotal_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPartsCost.LostFocus, txtPartsProductsMarkup.LostFocus,
                                                                                                                txtScheduleRateMarkup.LostFocus, txtScheduleRatesCost.LostFocus, cboVAT.SelectedIndexChanged
        If Not CurrentQuoteJob Is Nothing Then
            WorkOutGrandTotal()
        End If

    End Sub

    Private Sub cboQuoteStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboQuoteStatus.SelectedIndexChanged
        'IS THE FORM LOADING
        If Loading Or CurrentQuoteJob Is Nothing Then
            Exit Sub
        End If

        'IF ADDING NEW CANNOT ACCEPT OR REJECT
        If Not CurrentQuoteJob.Exists And
            (CType(Combo.GetSelectedItemValue(cboQuoteStatus), Entity.Sys.Enums.Quote_JobStatus) = Entity.Sys.Enums.Quote_JobStatus.Accepted Or
            CType(Combo.GetSelectedItemValue(cboQuoteStatus), Entity.Sys.Enums.Quote_JobStatus) = Entity.Sys.Enums.Quote_JobStatus.Rejected) Then

            ShowMessage("You can not accept or reject a quote until you have saved.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Combo.SetSelectedComboItem_By_Value(cboQuoteStatus, Helper.MakeIntegerValid(Entity.Sys.Enums.QuoteContractStatus.Generated))

            Exit Sub
        End If

        'ACCEPTING
        If CType(Combo.GetSelectedItemValue(cboQuoteStatus), Entity.Sys.Enums.Quote_JobStatus) = Entity.Sys.Enums.Quote_JobStatus.Accepted Then

            QuoteJob_Create_InstallJob()

            'REJECTING
        ElseIf CType(Combo.GetSelectedItemValue(cboQuoteStatus), Entity.Sys.Enums.Quote_JobStatus) = Entity.Sys.Enums.Quote_JobStatus.Rejected Then

            ShowForm(GetType(FRMQuoteRejection), True, New Object() {Me, ""})
            Me.Populate(CurrentQuoteJob.QuoteJobID)
        End If

    End Sub

    Public Function QuoteJob_Create_InstallJob() As String

        Dim msgRes As MsgBoxResult
        msgRes = ShowMessage("You are converting this quote to a live job." & vbCrLf & "Do you wish to save any changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If msgRes = DialogResult.Yes Then
            If Save() = False Then
                Return ""
            End If
        ElseIf msgRes = MsgBoxResult.No Then
            CurrentQuoteJob = DB.QuoteJob.Update(CurrentQuoteJob)
            Return ""
        ElseIf msgRes = MsgBoxResult.Cancel Then
            Combo.SetSelectedComboItem_By_Value(cboQuoteStatus, CurrentQuoteJob.StatusEnumID)
            Return ""
        End If

        Loading = True

        Dim rads As String = ""
        Dim fail As Boolean = False
        Dim supList As New List(Of Integer)
        Dim supName As New List(Of String)
        Dim specialpartid As Integer = Entity.Sys.Consts.SpecialOrderPartNumber
        Dim convertedJobNumber As String = ""

        For Each dr As DataRow In PartsAndProducts.Table.Rows
            If dr("Extra").ToString.Contains("Rad:") Then
                rads += dr("Extra").ToString.Replace("Rad: ", "") & " : " & dr("Name") & ", "
            End If
            If dr("Supplier") = "No Supplier" Then
                fail = True
                '    specialpartid = dr("ID")
            End If
            If Not IsDBNull(dr("SupplierID")) Then
                supList.Add(Helper.MakeIntegerValid(dr("SupplierID")))
                If Not supName.Contains(dr("Supplier")) Then
                    supName.Add(CStr(dr("Supplier")))
                End If
            End If

        Next

        'Going to workout what existing orders we got and then ask user where they want to place the specials
        If fail Then
            Dim f As New FRMGenDropBox
            Dim sups As DataTable = DB.Supplier.Supplier_GetAll().Table
            f.cbo2.Items.Clear()

            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            For Each dr As DataRow In sups.Rows
                If supList.Contains(Helper.MakeIntegerValid(dr("SupplierID"))) Then
                    dt.Rows.Add(New String() {dr("SupplierID"), dr("Name"), "0"})
                End If
            Next

            Combo.SetUpCombo(f.cbo2, dt, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select) '

            f.cbo1.Visible = False
            f.cbo2.Visible = True
            f.lblTop.Text = "Please select the Supplier for specials"
            f.lblMiddle.Text = ""
            f.lblref.Text = ""
            f.txtref.Visible = False
            f.ShowDialog()

            If f.DialogResult = DialogResult.Cancel Then
                Return ""
            End If

            Dim supid As Integer = Combo.GetSelectedItemValue(f.cbo2)
            Dim supplierpartid As Integer = DB.PartSupplier.Get_ByPartIDAndSupplierID(specialpartid, supid).Table.Rows(0)("PartSupplierID") ' get the first - thats fine
            For Each dr As DataRow In PartsAndProducts.Table.Rows

                If dr("Supplier") = "No Supplier" Then
                    dr("PartSupplierID") = supplierpartid
                    dr("SpecialDescription") = dr("Name")
                    dr("SpecialCost") = 0.01

                End If
            Next
            convertedJobNumber = DB.Job.Job_Get_For_Quote_ID(CurrentQuoteJob.QuoteJobID)?.JobNumber
            If Not String.IsNullOrEmpty(convertedJobNumber) Then
                MsgBox("Quote has already been converted, Install JobNumber : " & convertedJobNumber)
                Return convertedJobNumber
            Else
                Save()
            End If

        End If

        Dim department As String = Entity.Sys.Helper.MakeStringValid(Combo.GetSelectedItemValue(Me.cboDept))
        If Helper.IsValidInteger(department) AndAlso Helper.MakeIntegerValid(department) <= 0 Then
            MsgBox("Please select the department for the purchase")
            Return ""
        End If

        If txtElectricianCost.Text.Length < 1 Then txtElectricianCost.Text = "£0"
        ''Eng NOTES
        Dim notes As String = ""
        notes += "WHO SURVEYED JOB - " & txtSurveyor.Text & vbCrLf
        notes += "JOB LENGTH IN DAYS - " & txtInstallerLabourDays.Text & vbCrLf
        notes += "SUPPLIERS - " & String.Join(",", supName.ToArray())
        notes += "RADIATOR POSITIONS - " & rads & vbCrLf
        notes += "ASBESTOS - " & Combo.GetSelectedItemDescription(cboAsbestos) & " : " & txtAsbestos.Text & vbCrLf
        notes += "ADDITIONAL JOB NOTES - " & txtInstallerNotes.Text & vbCrLf
        notes += "BUILDING WORK INVOLVED - " & txtBuilderNotes.Text & vbCrLf
        notes += "BUILDER ARRIVAL DAY / HOUR - " & txtBuilderArrivalDay.Text & "/" & txtBuilderArrivalHour.Text & vbCrLf
        notes += "ACCESS EQUIPTMENT REQUIRED - " & Combo.GetSelectedItemDescription(cboAccess) & vbCrLf
        notes += "ELECTRICIAN ARRIVAL DAY / HOUR - " & txtElectricianArrivalDay.Text & "/" & txtElectricianArrivalHour.Text & vbCrLf
        notes += "BALANCE ON COMPLETION - " & txtBOC.Text & vbCrLf

        ''Electrician NOTES
        Dim ElecNotes As String = ""
        ElecNotes += "ELECTRICIAN NOTES - " & txtElectricianNotes.Text & vbCrLf
        ElecNotes += "ELECTRICIAN PACK / LABOUR  - " & Combo.GetSelectedItemDescription(cboElectricalPack) & " / " & txtElectricianHours.Text & "HRS" & vbCrLf
        ElecNotes += "ASBESTOS - " & Combo.GetSelectedItemDescription(cboAsbestos) & " : " & txtAsbestos.Text & vbCrLf
        ElecNotes += "ELECTRICIAN ARRIVAL DAY / HOUR - " & txtElectricianArrivalDay.Text & "/" & txtElectricianArrivalHour.Text & vbCrLf
        ElecNotes += "ELECTRICIAN COSTS - " & txtElectricianCost.Text & vbCrLf

        ''BUILDER NOTES
        Dim BuilderNotes As String = ""
        BuilderNotes += "BUILDER NOTES - " & txtBuilderNotes.Text & vbCrLf
        BuilderNotes += "BUILDER LABOUR  - " & txtBuilderHours.Text & "HRS" & vbCrLf
        BuilderNotes += "ASBESTOS - " & Combo.GetSelectedItemDescription(cboAsbestos) & " : " & txtAsbestos.Text & vbCrLf
        BuilderNotes += "BUILDER ARRIVAL DAY / HOUR - " & txtBuilderArrivalDay.Text & "/" & txtBuilderArrivalHour.Text & vbCrLf
        BuilderNotes += "ACCESS EQUIPTMENT REQUIRED - " & Combo.GetSelectedItemDescription(cboAccess) & vbCrLf

        If txtBuilderArrivalDay.Text.Length = 0 Then
            txtBuilderArrivalDay.Text = "0"
        End If
        If txtElectricianArrivalDay.Text.Length = 0 Then
            txtElectricianArrivalDay.Text = "0"
        End If

        Dim ReqBuilder As Boolean = If((Helper.MakeDoubleValid(txtBuilderCost.Text) > 0) Or Helper.MakeIntegerValid(txtBuilderArrivalDay.Text) > 0, True, False)
        Dim ReqElectrian As Boolean = If(Helper.MakeDoubleValid(txtElectricianCost.Text) > 0 Or Helper.MakeIntegerValid(txtElectricianArrivalDay.Text) > 0, True, False)
        Dim ReqService As Boolean = 1
        Dim ReqHandOver As Boolean = 1

        'check to see if job has been created by another user
        convertedJobNumber = DB.Job.Job_Get_For_Quote_ID(CurrentQuoteJob.QuoteJobID)?.JobNumber
        If Not String.IsNullOrEmpty(convertedJobNumber) Then
            MsgBox("Quote has already been converted, Install JobNumber : " & convertedJobNumber)
            Return convertedJobNumber
        End If

        Dim jn As String = DB.QuoteJob.QuoteJob_Create_Install(CurrentQuoteJob.SiteID, txtSurveyor.Text, notes, BuilderNotes, ElecNotes, Combo.GetSelectedItemValue(cboDept), CurrentQuoteJob.QuoteJobID,
                                            ReqElectrian, ReqBuilder, chkService.Checked, chkHOver.Checked,
                                            Helper.MakeDoubleValid(txtElectricianCost.Text), Helper.MakeDoubleValid(txtBuilderCost.Text))

        Combo.SetSelectedComboItem_By_Value(cboQuoteStatus, Entity.Sys.Enums.Quote_JobStatus.Accepted)
        Loading = False
        Me.Save()

        Me.Populate(CurrentQuoteJob.QuoteJobID)
        MsgBox("Quote Successfully Converted, Install JobNumber : C" & jn)
        Return "C" & jn

    End Function

    Private Sub btnFindPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindPart.Click
        Dim dialogue1 As FRMFindPart
        dialogue1 = checkIfExists(GetType(FRMFindPart).Name, True)
        If dialogue1 Is Nothing Then
            dialogue1 = Activator.CreateInstance(GetType(FRMFindPart))
        End If
        '  dialogue1.Icon = New Icon(dialogue1.GetType(), "Logo.ico")
        dialogue1.ShowInTaskbar = False
        dialogue1.TableToSearch = Entity.Sys.Enums.TableNames.NOT_IN_Database_tblPartSupplierQty
        dialogue1.ShowDialog()

        Dim datarows() As DataRow = Nothing
        If dialogue1.DialogResult = DialogResult.OK Then
            datarows = dialogue1.Datarows
        Else
            Exit Sub
        End If
        For Each dr As DataRow In datarows
            Dim newRow As DataRow

            If Helper.MakeBooleanValid(dr("IsPartPack")) Then
                Dim supplierId As Integer = Helper.MakeIntegerValid(dr("SupplierID"))
                Dim packId As Integer = Helper.MakeIntegerValid(dr("PartID"))
                Dim dvPartPack As DataView = DB.Part.PartPack_Get(packId)
                Dim qty As Integer = dr("Qty")
                For Each drPart As DataRowView In dvPartPack
                    newRow = CurrentQuoteJob.QuoteJobPartsAndProducts.Table.NewRow()
                    Dim partId As Integer = Helper.MakeIntegerValid(drPart("PartID"))
                    Dim dvPartSupplier As DataView = DB.PartSupplier.Get_ByPartIDAndSupplierID(partId, supplierId)

                    newRow.Item("SellPrice") = 0.0
                    newRow.Item("Extra") = ""
                    newRow.Item("ID") = drPart("PartID")
                    newRow.Item("Number") = drPart("PartNumber")
                    newRow.Item("PartSupplierID") = dvPartSupplier(0)("PartSupplierID")
                    newRow.Item("Name") = drPart("PartName")
                    newRow.Item("Quantity") = drPart("Qty") * qty
                    newRow.Item("BuyPrice") = dvPartSupplier(0)("Price")
                    newRow.Item("Total") = newRow.Item("Quantity") * newRow.Item("BuyPrice")
                    newRow.Item("Type") = "Part"
                    newRow.Item("Supplier") = dvPartSupplier(0)("SupplierName")

                    CurrentQuoteJob.QuoteJobPartsAndProducts.Table.Rows.Add(newRow)

                Next
            Else
                newRow = CurrentQuoteJob.QuoteJobPartsAndProducts.Table.NewRow()
                newRow.Item("SellPrice") = 0.0
                newRow.Item("Extra") = ""
                newRow.Item("ID") = dr("PartID")
                newRow.Item("Number") = dr("PartNumber")
                newRow.Item("PartSupplierID") = dr("PartSupplierID")
                newRow.Item("Name") = dr("PartName")
                newRow.Item("Quantity") = dr("Qty")
                newRow.Item("BuyPrice") = dr("Price")
                newRow.Item("Total") = newRow.Item("Quantity") * newRow.Item("BuyPrice")
                newRow.Item("Type") = "Part"
                newRow.Item("Supplier") = dr("SupplierName")

                If dr("IsSpecialPart") = 1 Then
                    Dim f As New FRMSpecialOrder(0, 0, 0)
                    f.ShowDialog()
                    If f.DialogResult = DialogResult.OK Then
                        newRow.Item("Quantity") = f.Quantity
                        newRow.Item("BuyPrice") = f.Price
                        newRow.Item("SpecialCost") = f.Price
                        newRow.Item("Name") = f.PartName
                        newRow.Item("SpecialDescription") = f.PartName
                        newRow.Item("Number") = f.SPN
                        newRow.Item("Extra") = f.SPN
                        newRow.Item("Total") = newRow.Item("Quantity") * newRow.Item("BuyPrice")
                    Else

                    End If
                End If
                CurrentQuoteJob.QuoteJobPartsAndProducts.Table.Rows.Add(newRow)

            End If

        Next
        SetupPartsTotals()
    End Sub

    Private Sub btnSiteScheduleOfRates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiteScheduleOfRates.Click
        Using f As New FRMSiteScheduleOfRateList(CurrentQuoteJob.SiteID, CurrentQuoteJob.ScheduleOfRates, True)
            f.ShowDialog()
        End Using
        dgScheduleOfRates.DataSource = CurrentQuoteJob.ScheduleOfRates
        SetupSORTotals()
    End Sub

    Private Sub btnRemovePartProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemovePartProduct.Click
        If Me.dgPartsAndProducts.CurrentRowIndex > -1 Then
            CurrentQuoteJob.QuoteJobPartsAndProducts.Table.AcceptChanges()
            CurrentQuoteJob.QuoteJobPartsAndProducts.Table.Rows.RemoveAt(Me.dgPartsAndProducts.CurrentRowIndex)

            SetupPartsTotals()
        Else
            ShowMessage("Please select item to remove", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim valid As Boolean = True
        Dim errorMsg As String = ""
        If Not Combo.GetSelectedItemValue(cboScheduleOfRatesCategoryID) > 0 Then
            errorMsg = "* Category is missing" & vbCrLf
            valid = False
        End If

        If txtDescription.Text.Trim.Length = 0 Then
            errorMsg += "* Description is missing" & vbCrLf
            valid = False
        End If

        If txtPrice.Text.Trim.Length = 0 Then
            errorMsg += "* Price is missing" & vbCrLf
            valid = False
        ElseIf IsNumeric(txtPrice.Text) = False Then
            errorMsg += "* Price must be numeric" & vbCrLf
            valid = False
        End If

        If txtQuantity.Text.Trim.Length = 0 Then
            errorMsg += "* Quantity is missing" & vbCrLf
            valid = False
        ElseIf IsNumeric(txtQuantity.Text) = False Then
            errorMsg += "* Quantity must be numeric" & vbCrLf
            valid = False
        End If

        If valid Then

            Dim rate As New Entity.CustomerScheduleOfRates.CustomerScheduleOfRate
            rate.IgnoreExceptionsOnSetMethods = True
            rate.SetScheduleOfRatesCategoryID = Combo.GetSelectedItemValue(cboScheduleOfRatesCategoryID)
            rate.SetCode = txtCode.Text
            rate.SetDescription = txtDescription.Text
            rate.SetPrice = txtPrice.Text
            rate.SetTimeInMins = txtTimeInMins.Text

            rate = DB.CustomerScheduleOfRate.Insert(rate)
            'now delete the rate (we do this because the rate is local to this quote only,
            'it will still show on the quote.)
            DB.CustomerScheduleOfRate.Delete(rate.CustomerScheduleOfRateID)

            Dim newRow As DataRow
            newRow = CurrentQuoteJob.ScheduleOfRates.Table.NewRow

            newRow("RateID") = rate.CustomerScheduleOfRateID
            newRow("ScheduleOfRatesCategoryID") = rate.ScheduleOfRatesCategoryID
            newRow("Category") = Combo.GetSelectedItemDescription(cboScheduleOfRatesCategoryID)
            newRow("Code") = rate.Code
            newRow("Description") = rate.Description
            newRow("Price") = rate.Price
            newRow("TimeInMins") = rate.TimeInMins

            newRow("Quantity") = txtQuantity.Text
            newRow("Total") = Entity.Sys.Helper.MakeDoubleValid(newRow("Price")) * Entity.Sys.Helper.MakeDoubleValid(newRow("Quantity"))
            CurrentQuoteJob.ScheduleOfRates.Table.Rows.Add(newRow)

            Combo.SetSelectedComboItem_By_Value(cboScheduleOfRatesCategoryID, "0")
            Me.txtCode.Text = ""
            Me.txtDescription.Text = ""
            Me.txtPrice.Text = ""
            Me.txtQuantity.Text = ""
            Me.txtTimeInMins.Text = ""
            dgScheduleOfRates.DataSource = CurrentQuoteJob.ScheduleOfRates
            SetupSORTotals()
        Else
            MessageBox.Show("Please correct the following:" & vbCrLf & errorMsg, "Errors", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If Not SelectedRatesDataRow Is Nothing Then
            With SelectedRatesDataRow
                If MessageBox.Show("DELETE :" & .Item("Description"), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                    CurrentQuoteJob.ScheduleOfRates.Table.Rows.Remove(SelectedRatesDataRow)
                    SetupSORTotals()
                End If
            End With
        End If
    End Sub

    Private Sub btnAddToJobItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If SelectedRatesDataRow Is Nothing Then
            ShowMessage("Please select rate to add description to job item list", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        JobItemsDataView.Table.AcceptChanges()
        Dim newRow As DataRow = JobItemsDataView.Table.NewRow
        newRow.Item("Summary") = Entity.Sys.Helper.MakeStringValid(SelectedRatesDataRow.Item("Description"))
        newRow.Item("RateID") = Helper.MakeIntegerValid(SelectedRatesDataRow.Item("RateID"))
        newRow.Item("Qty") = Entity.Sys.Helper.MakeDoubleValid(SelectedRatesDataRow.Item("Quantity"))
        JobItemsDataView.Table.Rows.Add(newRow)
    End Sub

#End Region

#Region "Setup"

    Public Sub SetupPartsAndProductsDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgPartsAndProducts)
        Dim tStyle As DataGridTableStyle = Me.dgPartsAndProducts.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim number As New DataGridLabelColumn
        number.Format = ""
        number.FormatInfo = Nothing
        number.HeaderText = "Number"
        number.MappingName = "number"
        number.ReadOnly = True
        number.Width = 100
        number.NullText = ""
        tStyle.GridColumnStyles.Add(number)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Name"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 160
        Name.NullText = ""
        tStyle.GridColumnStyles.Add(Name)

        Dim quantity As New DataGridLabelColumn
        quantity.Format = ""
        quantity.FormatInfo = Nothing
        quantity.HeaderText = "Qty"
        quantity.MappingName = "quantity"
        quantity.ReadOnly = True
        quantity.Width = 50
        quantity.NullText = ""
        tStyle.GridColumnStyles.Add(quantity)

        Dim Sellprice As New DataGridLabelColumn
        Sellprice.Format = "C"
        Sellprice.FormatInfo = Nothing
        Sellprice.HeaderText = "Buy Price"
        Sellprice.MappingName = "BuyPrice"
        Sellprice.ReadOnly = True
        Sellprice.Width = 75
        Sellprice.NullText = ""
        tStyle.GridColumnStyles.Add(Sellprice)

        Dim Extra As New DataGridLabelColumn
        Extra.Format = ""
        Extra.FormatInfo = Nothing
        Extra.HeaderText = "Extra"
        Extra.MappingName = "Extra"
        Extra.ReadOnly = False
        Extra.Width = 75
        Extra.NullText = ""
        tStyle.GridColumnStyles.Add(Extra)

        Dim Supplier As New DataGridLabelColumn
        Supplier.Format = ""
        Supplier.FormatInfo = Nothing
        Supplier.HeaderText = "Supplier"
        Supplier.MappingName = "Supplier"
        Supplier.ReadOnly = False
        Supplier.Width = 75
        Supplier.NullText = ""
        tStyle.GridColumnStyles.Add(Supplier)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString
        Me.dgPartsAndProducts.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupScheduleOfRatesDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(dgScheduleOfRates)
        Dim tStyle As DataGridTableStyle = Me.dgScheduleOfRates.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Category As New DataGridLabelColumn
        Category.Format = ""
        Category.FormatInfo = Nothing
        Category.HeaderText = "Category"
        Category.MappingName = "Category"
        Category.ReadOnly = True
        Category.Width = 90
        Category.NullText = ""
        tStyle.GridColumnStyles.Add(Category)

        Dim Code As New DataGridLabelColumn
        Code.Format = ""
        Code.FormatInfo = Nothing
        Code.HeaderText = "Code"
        Code.MappingName = "Code"
        Code.ReadOnly = True
        Code.Width = 75
        Code.NullText = ""
        tStyle.GridColumnStyles.Add(Code)

        Dim Description As New DataGridLabelColumn
        Description.Format = ""
        Description.FormatInfo = Nothing
        Description.HeaderText = "Description"
        Description.MappingName = "Description"
        Description.ReadOnly = True
        Description.Width = 150
        Description.NullText = ""
        tStyle.GridColumnStyles.Add(Description)

        Dim TimeInMins As New DataGridLabelColumn
        TimeInMins.Format = "C"
        TimeInMins.FormatInfo = Nothing
        TimeInMins.HeaderText = "Time"
        TimeInMins.MappingName = "TimeInMins"
        TimeInMins.ReadOnly = False
        TimeInMins.Width = 50
        TimeInMins.NullText = ""
        tStyle.GridColumnStyles.Add(TimeInMins)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Unit Price"
        Price.MappingName = "Price"
        Price.ReadOnly = False
        Price.Width = 75
        Price.NullText = ""
        tStyle.GridColumnStyles.Add(Price)

        Dim Quantity As New DataGridLabelColumn
        Quantity.Format = ""
        Quantity.FormatInfo = Nothing
        Quantity.HeaderText = "Unit Qty"
        Quantity.MappingName = "Quantity"
        Quantity.ReadOnly = True
        Quantity.Width = 75
        Quantity.NullText = ""
        tStyle.GridColumnStyles.Add(Quantity)

        Dim Total As New DataGridLabelColumn
        Total.Format = "C"
        Total.FormatInfo = Nothing
        Total.HeaderText = "Total"
        Total.MappingName = "Total"
        Total.ReadOnly = False
        Total.Width = 75
        Total.NullText = ""
        tStyle.GridColumnStyles.Add(Total)

        tStyle.ReadOnly = False
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString
        Me.dgScheduleOfRates.TableStyles.Add(tStyle)

    End Sub

#End Region

#Region "Functions"

    Private Sub WorkOutGrandTotal()

        If Me.txtPartsCost.Text = "" Then
            Me.txtPartsCost.Text = "£0.00"
        ElseIf Not IsNumeric(txtPartsCost.Text.Trim.Replace("£", "")) Then
            Me.txtPartsCost.Text = "£0.00"
        Else
            Me.txtPartsCost.Text = Format(Entity.Sys.Helper.MakeDoubleValid(txtPartsCost.Text.Trim.Replace("£", "")), "C")
        End If

        If Me.txtPartsProductsMarkup.Text = "" Then
            Me.txtPartsProductsMarkup.Text = "0%"
        ElseIf Not IsNumeric(txtPartsProductsMarkup.Text.Trim.Replace("%", "")) Then
            Me.txtPartsProductsMarkup.Text = "0%"
        Else
            Me.txtPartsProductsMarkup.Text = txtPartsProductsMarkup.Text.Trim.Replace("%", "") & "%"
        End If

        If Me.txtScheduleRatesCost.Text = "" Then
            Me.txtScheduleRatesCost.Text = "£0.00"
        ElseIf Not IsNumeric(txtScheduleRatesCost.Text.Trim.Replace("£", "")) Then
            Me.txtScheduleRatesCost.Text = "£0.00"
        Else
            Me.txtScheduleRatesCost.Text = Format(Entity.Sys.Helper.MakeDoubleValid(txtScheduleRatesCost.Text.Trim.Replace("£", "")), "C")
        End If

        If Me.txtScheduleRateMarkup.Text = "" Then
            Me.txtScheduleRateMarkup.Text = "0%"
        ElseIf Not IsNumeric(txtScheduleRateMarkup.Text.Trim.Replace("%", "")) Then
            Me.txtScheduleRateMarkup.Text = "0%"
        Else
            Me.txtScheduleRateMarkup.Text = txtScheduleRateMarkup.Text.Trim.Replace("%", "") & "%"
        End If

        If Me.txtInstallerCost.Text = "" Then
            Me.txtInstallerCost.Text = "£0.00"
        ElseIf Not IsNumeric(txtInstallerCost.Text.Trim.Replace("£", "")) Then
            Me.txtInstallerCost.Text = "£0.00"
        Else
            Me.txtInstallerCost.Text = Format(Entity.Sys.Helper.MakeDoubleValid(txtInstallerCost.Text.Trim.Replace("£", "")), "C")
        End If

        If Me.txtInstallerMarkup.Text = "" Then
            Me.txtInstallerMarkup.Text = "0%"
        ElseIf Not IsNumeric(txtInstallerMarkup.Text.Trim.Replace("%", "")) Then
            Me.txtInstallerMarkup.Text = "0%"
        Else
            Me.txtInstallerMarkup.Text = txtInstallerMarkup.Text.Trim.Replace("%", "") & "%"
        End If

        If Me.txtBuilderCost.Text = "" Then
            Me.txtBuilderCost.Text = "£0.00"
        ElseIf Not IsNumeric(txtBuilderCost.Text.Trim.Replace("£", "")) Then
            Me.txtBuilderCost.Text = "£0.00"
        Else
            Me.txtBuilderCost.Text = Format(Entity.Sys.Helper.MakeDoubleValid(txtBuilderCost.Text.Trim.Replace("£", "")), "C")
        End If

        If Me.txtBuilderMarkup.Text = "" Then
            Me.txtBuilderMarkup.Text = "0%"
        ElseIf Not IsNumeric(txtBuilderMarkup.Text.Trim.Replace("%", "")) Then
            Me.txtBuilderMarkup.Text = "0%"
        Else
            Me.txtBuilderMarkup.Text = txtBuilderMarkup.Text.Trim.Replace("%", "") & "%"
        End If

        If Me.txtElectricianCost.Text = "" Then
            Me.txtElectricianCost.Text = "£0.00"
        ElseIf Not IsNumeric(txtElectricianCost.Text.Trim.Replace("£", "")) Then
            Me.txtElectricianCost.Text = "£0.00"
        Else
            Me.txtElectricianCost.Text = Format(Entity.Sys.Helper.MakeDoubleValid(txtElectricianCost.Text.Trim.Replace("£", "")), "C")
        End If

        If Me.txtElectricianMarkup.Text = "" Then
            Me.txtElectricianMarkup.Text = "0%"
        ElseIf Not IsNumeric(txtElectricianMarkup.Text.Trim.Replace("%", "")) Then
            Me.txtElectricianMarkup.Text = "0%"
        Else
            Me.txtElectricianMarkup.Text = txtElectricianMarkup.Text.Trim.Replace("%", "") & "%"
        End If

        Dim productPartTotal As Double = 0.0
        productPartTotal = Helper.MakeDoubleValid(Me.txtPartsCost.Text.Replace("£", "")) +
                            ((Helper.MakeDoubleValid(Me.txtPartsCost.Text.Replace("£", "") / 100)) _
                            * Helper.MakeDoubleValid(Me.txtPartsProductsMarkup.Text.Replace("%", "")))
        Me.txtPartsCostTotal.Text = Format(productPartTotal, "C")

        Dim scheduleRateTotal As Double = 0.0
        scheduleRateTotal = Helper.MakeDoubleValid(Me.txtScheduleRatesCost.Text.Replace("£", "")) +
                        ((Helper.MakeDoubleValid(Me.txtScheduleRatesCost.Text.Replace("£", "") / 100)) *
                        Helper.MakeDoubleValid(Me.txtScheduleRateMarkup.Text.Replace("%", "")))
        Me.txtScheduleRatesCostTotal.Text = Format(scheduleRateTotal, "C")

        Dim InstallerTotal As Double = 0.0
        InstallerTotal = Helper.MakeDoubleValid(Me.txtInstallerCost.Text.Replace("£", "")) +
                        ((Helper.MakeDoubleValid(Me.txtInstallerCost.Text.Replace("£", "") / 100)) *
                        Helper.MakeDoubleValid(Me.txtInstallerMarkup.Text.Replace("%", "")))

        Me.txtInstallerCharge.Text = Format(InstallerTotal, "C")

        Dim BuilderTotal As Double = 0.0
        BuilderTotal = Helper.MakeDoubleValid(Me.txtBuilderCost.Text.Replace("£", "")) +
                        ((Helper.MakeDoubleValid(Me.txtBuilderCost.Text.Replace("£", "") / 100)) *
                        Helper.MakeDoubleValid(Me.txtBuilderMarkup.Text.Replace("%", "")))

        Me.txtBuilderCharge.Text = Format(BuilderTotal, "C")

        Dim ElectricianTotal As Double = 0.0
        ElectricianTotal = Helper.MakeDoubleValid(Me.txtElectricianCost.Text.Replace("£", "")) +
                        ((Helper.MakeDoubleValid(Me.txtElectricianCost.Text.Replace("£", "") / 100)) *
                        Helper.MakeDoubleValid(Me.txtElectricianMarkup.Text.Replace("%", "")))
        Me.txtElectricianCharge.Text = Format(ElectricianTotal, "C")

        Dim AdditionalCharge As Double = Helper.MakeDoubleValid(Me.txtAccess.Text.Replace("£", ""))

        If chkSORCharge.Checked Then
            Me.txtInstallerCharge.Text = 0
            Me.txtElectricianCharge.Text = 0
            Me.txtBuilderCharge.Text = 0

            Me.txtPartsCostTotal.Text = 0
            AdditionalCharge = 0
        Else
            Me.txtScheduleRatesCostTotal.Text = 0
        End If

        Dim GrandTotal As Double = 0.0
        GrandTotal = Helper.MakeDoubleValid(Me.txtPartsCostTotal.Text.Replace("£", "")) +
                    Helper.MakeDoubleValid(Me.txtScheduleRatesCostTotal.Text.Replace("£", "")) +
                    Helper.MakeDoubleValid(Me.txtInstallerCharge.Text.Replace("£", "")) +
                    Helper.MakeDoubleValid(Me.txtElectricianCharge.Text.Replace("£", "")) +
                    Helper.MakeDoubleValid(Me.txtBuilderCharge.Text.Replace("£", "")) + AdditionalCharge
        Me.txtGrandTotal.Text = Format(GrandTotal, "C")

        If CurrentQuoteJob IsNot Nothing Then
            With CurrentQuoteJob
                .SetPartsAndProductsTotal = productPartTotal
                .SetScheduleOfRatesTotal = scheduleRateTotal
                .SetScheduleOfRatesTotal = ElectricianTotal
                .SetGrandTotal = GrandTotal
            End With
        End If

        TotalCosts = Helper.MakeDoubleValid(Me.txtBuilderCost.Text.Replace("£", "")) + Helper.MakeDoubleValid(Me.txtElectricianCost.Text.Replace("£", "")) + Helper.MakeDoubleValid(Me.txtInstallerCost.Text.Replace("£", "")) +
            Helper.MakeDoubleValid(Me.txtPartsCost.Text.Replace("£", "")) + Helper.MakeDoubleValid(Me.txtAccess.Text.Replace("£", ""))
        txtTotalCosts.Text = Format(TotalCosts, "C")
        If Combo.GetSelectedItemValue(cboVAT) > 0 Then
            Dim VATRate As Double = DB.VATRatesSQL.VATRates_Get(Combo.GetSelectedItemValue(cboVAT)).VATRate
            Me.txtProfitPound.Text = Format(Helper.MakeDoubleValid(Me.txtGrandTotal.Text.Replace("£", "")) - TotalCosts, "C")
            Me.txtProfitPerc.Text = Math.Round((Helper.MakeDoubleValid(txtProfitPound.Text) / Helper.MakeDoubleValid(Me.txtGrandTotal.Text.Replace("£", ""))) * 100, 2) & "%"
            Me.txtGrandTotal.Text = Format(Helper.MakeDoubleValid(Me.txtGrandTotal.Text.Replace("£", "")), "C")
            Me.txtincVAT.Text = Format(Helper.MakeDoubleValid(Me.txtGrandTotal.Text.Replace("£", "")) * (1 + (VATRate / 100)), "C")
            ' Me.txtDeposit.Text = Format(CurrentQuoteJob.DepositAmount, "C")
            Me.txtBOC.Text = Format((Helper.MakeDoubleValid(Me.txtGrandTotal.Text.Replace("£", "")) * (1 + (VATRate / 100))) - Helper.MakeDoubleValid(Me.txtDeposit.Text.Replace("£", "")), "C")
        End If

    End Sub

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("Summary"))
        dt.Columns.Add(New DataColumn("RateID"))
        dt.Columns.Add(New DataColumn("Qty"))
        JobItemsDataView = New DataView(dt)

        If CurrentQuoteJob.Exists Then
            If CType(CurrentQuoteJob.StatusEnumID, Entity.Sys.Enums.Quote_JobStatus) = -1 Then

                Entity.Sys.Helper.MakeReadOnly(Me.grpJobItems, True)
                Me.cboJobType.Enabled = False
                Me.txtReference.Enabled = False
                Me.dtpQuoteDate.Enabled = False
                cboQuoteStatus.Enabled = False
                Me.grpParts.Enabled = False
                Me.grpRates.Enabled = False
                Me.grpTotals.Enabled = False
            Else

                Entity.Sys.Helper.MakeReadOnly(Me.grpJobItems, False)
                Me.cboJobType.Enabled = True
                Me.txtReference.Enabled = True
                Me.dtpQuoteDate.Enabled = True
                cboQuoteStatus.Enabled = True
                Me.grpParts.Enabled = True
                Me.grpRates.Enabled = True
                Me.grpTotals.Enabled = True
            End If

            Combo.SetSelectedComboItem_By_Value(Me.cboJobType, CurrentQuoteJob.JobTypeID)
            Combo.SetSelectedComboItem_By_Value(cboQuoteStatus, CurrentQuoteJob.StatusEnumID)

            Me.txtReference.Text = CurrentQuoteJob.Reference
            Me.dtpQuoteDate.Value = CurrentQuoteJob.DateCreated

            Me.txtPartsCost.Text = Format(CurrentQuoteJob.PartsCost, "C")
            Me.txtPartsProductsMarkup.Text = CurrentQuoteJob.PartsAndProductsMarkup & "%"
            Me.txtPartsCostTotal.Text = Format(Entity.Sys.Helper.MakeDoubleValid(CurrentQuoteJob.PartsCost + ((CurrentQuoteJob.PartsCost / 100) * CurrentQuoteJob.PartsAndProductsMarkup)), "C")

            Me.dgScheduleOfRates.DataSource = CurrentQuoteJob.ScheduleOfRates

            Me.txtScheduleRatesCost.Text = Format(CurrentQuoteJob.ScheduleOfRatesTotal, "C")
            Me.txtScheduleRateMarkup.Text = CurrentQuoteJob.ScheduleOfRatesMarkup & "%"
            Me.txtScheduleRatesCostTotal.Text = Format(Entity.Sys.Helper.MakeDoubleValid(CurrentQuoteJob.ScheduleOfRatesTotal + ((CurrentQuoteJob.ScheduleOfRatesTotal / 100) * CurrentQuoteJob.ScheduleOfRatesMarkup)), "C")

            Me.txtElectricianCost.Text = Format(CurrentQuoteJob.ElectricianCost, "C")
            Me.txtElectricianMarkup.Text = CurrentQuoteJob.ElectricianMarkUp & "%"
            Me.txtElectricianCharge.Text = Format(Entity.Sys.Helper.MakeDoubleValid(Helper.MakeDoubleValid(Me.txtElectricianCost.Text) + ((Helper.MakeDoubleValid(Me.txtElectricianCost.Text) / 100) * CurrentQuoteJob.ElectricianMarkUp)), "C")

            Me.txtInstallerCost.Text = Format(CurrentQuoteJob.EngineerCost, "C")
            Me.txtInstallerMarkup.Text = CurrentQuoteJob.EngineerMarkUp & "%"
            Me.txtInstallerCharge.Text = Format(Entity.Sys.Helper.MakeDoubleValid(CurrentQuoteJob.EngineerCost + ((CurrentQuoteJob.EngineerCost / 100) * CurrentQuoteJob.EngineerMarkUp)), "C")

            Me.txtBuilderCost.Text = Format(CurrentQuoteJob.BuilderCost, "C")
            Me.txtBuilderMarkup.Text = CurrentQuoteJob.BuilderMarkUp & "%"
            Me.txtBuilderCharge.Text = Format(Entity.Sys.Helper.MakeDoubleValid(CurrentQuoteJob.BuilderCost + ((CurrentQuoteJob.BuilderCost / 100) * CurrentQuoteJob.BuilderMarkUp)), "C")

            chkSORCharge.Checked = CurrentQuoteJob.SORCharge
            Combo.SetSelectedComboItem_By_Value(cboVAT, CurrentQuoteJob.VatRateID)
            Combo.SetSelectedComboItem_By_Value(cboElectricalPack, CurrentQuoteJob.ElectricianPackTypeID)
            'new workdetails
            Me.txtAccess.Text = CurrentQuoteJob.AdditionalCosts
            Me.txtInstallerNotes.Text = CurrentQuoteJob.NotesToEngineer
            Me.txtInstallerLabourDays.Text = CurrentQuoteJob.EngineerLabourHrs
            Combo.SetSelectedComboItem_By_Value(cboAsbestos, CurrentQuoteJob.AsbestosID)
            Me.txtAsbestos.Text = CurrentQuoteJob.AsbestosComment
            Combo.SetSelectedComboItem_By_Value(cboAccess, CurrentQuoteJob.AccessEquipmentID)

            Me.txtElectricianHours.Text = CurrentQuoteJob.ElectricianLabourHrs
            Me.txtElectricianArrivalDay.Text = CurrentQuoteJob.ElectricianArrivalDayNo
            Me.txtElectricianArrivalHour.Text = CurrentQuoteJob.ElectricianArrivalHour
            Me.txtElectricianNotes.Text = CurrentQuoteJob.NotesToElectrician
            Me.txtBuilderHours.Text = CurrentQuoteJob.BuilderLabourHrs
            Me.txtBuilderArrivalDay.Text = CurrentQuoteJob.BuilderArrivalDayNo
            Me.txtBuilderArrivalHour.Text = CurrentQuoteJob.BuilderArrivalHour
            Me.txtBuilderNotes.Text = CurrentQuoteJob.NotesToBuilder

            Me.txtOriginalQuote.Text = Format(CurrentQuoteJob.OriginalQuotedAmount, "C")

            TotalCosts = CurrentQuoteJob.BuilderCost + CurrentQuoteJob.ElectricianCost + CurrentQuoteJob.EngineerCost + CurrentQuoteJob.PartsCost + CurrentQuoteJob.AdditionalCosts
            txtTotalCosts.Text = Format(TotalCosts, "C")
            Me.txtDeposit.Text = Format(CurrentQuoteJob.DepositAmount, "C")

            If Combo.GetSelectedItemValue(cboVAT) > 0 Then
                Dim VATRate As Double = DB.VATRatesSQL.VATRates_Get(Combo.GetSelectedItemValue(cboVAT)).VATRate
                Me.txtProfitPound.Text = Format(CurrentQuoteJob.QuotedAmount - TotalCosts, "C")
                Me.txtProfitPerc.Text = Math.Round((Helper.MakeDoubleValid(Me.txtProfitPound.Text.Replace("£", "")) / CurrentQuoteJob.QuotedAmount) * 100, 2) & "%"
                Me.txtGrandTotal.Text = Format(CurrentQuoteJob.QuotedAmount, "C")
                Me.txtincVAT.Text = Format(CurrentQuoteJob.QuotedAmount * (1 + (VATRate / 100)), "C")

                Me.txtBOC.Text = Format((CurrentQuoteJob.QuotedAmount * (1 + (VATRate / 100))) - CurrentQuoteJob.DepositAmount, "C")
            End If

            If CurrentQuoteJob.EstStartDate > Date.MinValue Then
                lblNA.Visible = False
                dtpestStartDate.Visible = True
                dtpestStartDate.Value = CurrentQuoteJob.EstStartDate
            Else
                lblNA.Visible = True
                dtpestStartDate.Visible = False

            End If

            Try 'LAZY
                Dim ev As Entity.EngineerVisits.EngineerVisit = DB.EngineerVisits.EngineerVisits_Get_New_As_Object(CurrentQuoteJob.SurveyVisitID)
                Dim Eng As Entity.Engineers.Engineer = DB.Engineer.Engineer_Get(ev.EngineerID)
                Me.txtSurveyor.Text = Eng.Name
            Catch ex As Exception
                Me.txtSurveyor.Text = "N/A"
            End Try

            Me.txtChangedDate.Text = CurrentQuoteJob.ChangedDateTime.ToString("dd/MM/yyyy")
            Dim User As Entity.Users.User = DB.User.Get(CurrentQuoteJob.ChangedByUserID)
            Me.txtChangedBy.Text = User.Fullname

            Combo.SetSelectedComboItem_By_Value(cboDept, CurrentQuoteJob.Department.Trim())
        Else

            Me.txtInstallerCost.Text = Format(0, "C")
            Me.txtElectricianCost.Text = Format(0, "C")
            Me.txtBuilderCost.Text = Format(0, "C")
            Me.txtGrandTotal.Text = Format(0, "C")
            Me.txtDeposit.Text = Format(0, "C")
            Me.txtPartsCost.Text = Format(0, "C")
            Me.txtBOC.Text = Format(0, "C")
            Me.txtScheduleRatesCost.Text = Format(0, "C")
            Me.txtProfitPound.Text = Format(0, "C")
            Me.txtOriginalQuote.Text = Format(CurrentQuoteJob.OriginalQuotedAmount, "C")

            CurrentQuoteJob.QuoteJobPartsAndProducts = DB.QuoteJob.Get_Parts_And_Products_For_QuoteJobID(CurrentQuoteJob.QuoteJobID)
        End If

        RaiseEvent RefreshButton()
    End Sub

    Public Sub LoadDepartment()
        Dim department As String = Entity.Sys.Helper.MakeStringValid(Combo.GetSelectedItemValue(Me.cboDept))

        If Entity.Sys.Helper.IsValidInteger(department) AndAlso Not Entity.Sys.Helper.MakeIntegerValid(department) <= 0 Then
            Dim cc As CostCentre = DB.CostCentre.Get(CurrentQuoteJob?.JobTypeID, CurrentSite?.CustomerID, GetBy.JobTypeIdAndCutomerId)?.FirstOrDefault()
            Combo.SetSelectedComboItem_By_Value(cboDept, cc?.CostCentre)
        ElseIf Not IsNumeric(department) Then
            Dim cc As CostCentre = DB.CostCentre.Get(CurrentQuoteJob?.JobTypeID, CurrentSite?.CustomerID, GetBy.JobTypeIdAndCutomerId)?.FirstOrDefault()
            Combo.SetSelectedComboItem_By_Value(cboDept, Helper.MakeStringValid(cc?.CostCentre))
        End If
    End Sub

    Private Sub SetupPartsTotals()
        Dim parts As Double = 0.0
        For Each row As DataRow In CurrentQuoteJob.QuoteJobPartsAndProducts.Table.Rows
            parts += row.Item("Quantity") * row.Item("BuyPrice")
        Next

        CurrentQuoteJob.SetPartsAndProductsTotal = parts

        Me.txtPartsCost.Text = Format(parts, "C")

        WorkOutGrandTotal()

    End Sub

    Private Sub SetupSORTotals()
        Dim rates As Double = 0.0
        For Each row As DataRow In CurrentQuoteJob.ScheduleOfRates.Table.Rows
            rates += row.Item("Total")
        Next

        CurrentQuoteJob.SetScheduleOfRatesTotal = rates

        Me.txtScheduleRatesCost.Text = Format(rates, "C")

        WorkOutGrandTotal()

    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor

            CurrentQuoteJob.IgnoreExceptionsOnSetMethods = True
            CurrentQuoteJob.SetJobDefinitionEnumID = Entity.Sys.Helper.MakeIntegerValid(Entity.Sys.Enums.JobDefinition.Quoted)
            CurrentQuoteJob.SetJobTypeID = Combo.GetSelectedItemValue(Me.cboJobType)
            CurrentQuoteJob.SetStatusEnumID = Entity.Sys.Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboQuoteStatus))
            CurrentQuoteJob.SetReference = Me.txtReference.Text.Trim
            CurrentQuoteJob.DateCreated = Me.dtpQuoteDate.Value
            CurrentQuoteJob.SetPartsAndProductsTotal = Me.txtPartsCost.Text.Trim.Replace("£", "")
            CurrentQuoteJob.SetPartsAndProductsMarkup = Me.txtPartsProductsMarkup.Text.Trim.Replace("%", "")
            CurrentQuoteJob.SetGrandTotal = Me.txtBOC.Text.Trim.Replace("£", "")
            CurrentQuoteJob.SetScheduleOfRatesMarkup = Me.txtScheduleRateMarkup.Text.Trim.Replace("%", "")
            CurrentQuoteJob.SetScheduleOfRatesTotal = Me.txtScheduleRatesCost.Text.Trim.Replace("£", "")
            CurrentQuoteJob.SetMileageRate = 0
            CurrentQuoteJob.SetEstimatedMileage = 0

            CurrentQuoteJob.SetNotesToEngineer = Me.txtInstallerNotes.Text
            CurrentQuoteJob.SetNotesToElectrician = Me.txtElectricianNotes.Text
            CurrentQuoteJob.SetNotesToBuilder = Me.txtBuilderNotes.Text
            CurrentQuoteJob.SetEngineerLabourHrs = Helper.MakeDoubleValid(Me.txtInstallerLabourDays.Text)
            CurrentQuoteJob.SetElectricianLabourHrs = Helper.MakeDoubleValid(Me.txtElectricianHours.Text)
            CurrentQuoteJob.SetBuilderLabourHrs = Helper.MakeDoubleValid(Me.txtBuilderHours.Text)
            CurrentQuoteJob.SetEngineerMarkUp = Helper.MakeDoubleValid(Me.txtInstallerMarkup.Text.Replace("%", ""))
            CurrentQuoteJob.SetElectricianMarkUp = Helper.MakeDoubleValid(Me.txtElectricianMarkup.Text.Replace("%", ""))
            CurrentQuoteJob.SetBuilderMarkUp = Helper.MakeDoubleValid(Me.txtBuilderMarkup.Text.Replace("%", ""))
            CurrentQuoteJob.SetElectricianArrivalDayNo = Helper.MakeIntegerValid(Me.txtElectricianArrivalDay.Text)
            CurrentQuoteJob.SetElectricianArrivalHour = Helper.MakeIntegerValid(Me.txtElectricianArrivalHour.Text)
            CurrentQuoteJob.SetBuilderArrivalDayNo = Helper.MakeIntegerValid(Me.txtBuilderArrivalDay.Text)
            CurrentQuoteJob.SetBuilderArrivalHour = Helper.MakeIntegerValid(Me.txtBuilderArrivalHour.Text)
            CurrentQuoteJob.SetPartsCost = Helper.MakeDoubleValid(Me.txtPartsCost.Text)
            CurrentQuoteJob.SetEngineerCost = Helper.MakeDoubleValid(Me.txtInstallerCost.Text)
            CurrentQuoteJob.SetBuilderCost = Helper.MakeDoubleValid(Me.txtBuilderCost.Text)
            CurrentQuoteJob.SetElectricianCost = Helper.MakeDoubleValid(Me.txtElectricianCost.Text)
            CurrentQuoteJob.SetQuotedAmount = Helper.MakeDoubleValid(Me.txtGrandTotal.Text)
            CurrentQuoteJob.SetDepositAmount = Helper.MakeDoubleValid(Me.txtDeposit.Text)
            CurrentQuoteJob.SetVatRateID = Combo.GetSelectedItemValue(cboVAT)
            CurrentQuoteJob.ChangedDateTime = Now
            CurrentQuoteJob.SetChangedByUserID = loggedInUser.UserID
            CurrentQuoteJob.SetOriginalQuotedAmount = CurrentQuoteJob.OriginalQuotedAmount
            CurrentQuoteJob.SetElectricianPackTypeID = Combo.GetSelectedItemValue(cboElectricalPack)
            CurrentQuoteJob.SetSORCharge = chkSORCharge.Checked
            CurrentQuoteJob.SetAccessEquipmentID = Combo.GetSelectedItemValue(cboAccess)
            CurrentQuoteJob.SetAsbestosID = Combo.GetSelectedItemValue(cboAsbestos)
            CurrentQuoteJob.SetAdditionalCosts = Helper.MakeDoubleValid(Me.txtAccess.Text)
            CurrentQuoteJob.SetAsbestosComment = Me.txtAsbestos.Text
            CurrentQuoteJob.EstStartDate = Helper.MakeDateTimeValid(Me.dtpQuoteDate.Value)
            CurrentQuoteJob.SetSurveyVisitID = CurrentQuoteJob.SurveyVisitID
            CurrentQuoteJob.SetDepartment = Combo.GetSelectedItemValue(cboDept)

            CurrentQuoteJob.QuoteAssets.Clear()
            For Each row As DataRow In AssetsDataView.Table.Rows
                If row.Item("Tick") Then
                    Dim qJobAsset As New Entity.QuoteJobAssets.QuoteJobAsset
                    qJobAsset.SetAssetID = Entity.Sys.Helper.MakeIntegerValid(row.Item("AssetID"))

                    CurrentQuoteJob.QuoteAssets.Add(qJobAsset)
                End If
            Next

            Dim qJobOfWork As Entity.QuoteJobOfWorks.QuoteJobOfWork

            If CurrentQuoteJob.QuoteJobOfWorks.Count > 0 Then
                qJobOfWork = CurrentQuoteJob.QuoteJobOfWorks.Item(0)
                qJobOfWork.QuoteJobItems.Clear()
            Else
                qJobOfWork = New Entity.QuoteJobOfWorks.QuoteJobOfWork
            End If

            qJobOfWork.IgnoreExceptionsOnSetMethods = True

            CurrentQuoteJob.QuoteJobOfWorks.Clear()

            For Each row As DataRow In CurrentQuoteJob.ScheduleOfRates.Table.Rows
                Dim qJobItem As New Entity.QuoteJobItems.QuoteJobItem
                qJobItem.IgnoreExceptionsOnSetMethods = True
                qJobItem.SetSummary = Entity.Sys.Helper.MakeStringValid(row.Item("Description"))
                qJobItem.SetRateID = Entity.Sys.Helper.MakeIntegerValid(row.Item("RateID"))
                If row.Table.Columns.Contains("SystemLinkID") Then
                    qJobItem.SetSystemLinkID = Entity.Sys.Helper.MakeIntegerValid(row.Item("SystemLinkID"))
                End If
                qJobItem.SetQty = Entity.Sys.Helper.MakeDoubleValid(row.Item("Quantity"))
                qJobOfWork.QuoteJobItems.Add(qJobItem)
            Next

            CurrentQuoteJob.QuoteJobOfWorks.Add(qJobOfWork)
            Dim jV As New Entity.QuoteJobs.QuoteJobValidator

            jV.Validate(CurrentQuoteJob, JobItemsDataView)

            If CurrentQuoteJob.Exists Then
                CurrentQuoteJob = DB.QuoteJob.Update(CurrentQuoteJob)
            Else
                CurrentQuoteJob = DB.QuoteJob.Insert(CurrentQuoteJob)
                QuoteNumberUsed = True
                ShowMessage("Quote added : " & CurrentQuoteJob.Reference, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            RaiseEvent StateChanged(CurrentQuoteJob.QuoteJobID)

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

    Public Sub RejectReasonChanged(ByVal Reason As String, ByVal ReasonID As Integer)
        CurrentQuoteJob.SetReasonForReject = Reason
        CurrentQuoteJob.SetReasonForRejectID = ReasonID
        Save()
    End Sub

    Private Function BuildUpScheduleOfRatesDataview() As DataView
        Dim newTable As New DataTable
        newTable.Columns.Add("ScheduleOfRatesCategoryID")
        newTable.Columns.Add("Category")
        newTable.Columns.Add("Code")
        newTable.Columns.Add("Description")
        newTable.Columns.Add("Price", System.Type.GetType("System.Double"))
        newTable.Columns.Add("Quantity", System.Type.GetType("System.Double"))
        newTable.Columns.Add("Total", System.Type.GetType("System.Double"))
        newTable.Columns.Add("RateID", System.Type.GetType("System.Int32"))
        newTable.Columns.Add("TimeInMins", System.Type.GetType("System.Int32"))
        newTable.TableName = Entity.Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString
        Return New DataView(newTable)

    End Function

    Private Sub cboElectricalPack_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboElectricalPack.SelectedIndexChanged
        'Electrician

        Select Case Combo.GetSelectedItemValue(cboElectricalPack)
            Case 0
                Me.txtElectricianCost.Text = Format(Helper.MakeDoubleValid(CurrentQuoteJob?.ElectricianLabourHrs) * 27.5, "C") ' Hard coded Rate TODO
            Case 1
                Me.txtElectricianCost.Text = Format(100, "C")
            Case 2
                Me.txtElectricianCost.Text = Format(155, "C")
            Case 3
                Me.txtElectricianCost.Text = Format(500, "C")

        End Select

        WorkOutGrandTotal()

    End Sub

    Private Sub chkSORCharge_CheckedChanged(sender As Object, e As EventArgs) Handles chkSORCharge.CheckedChanged
        WorkOutGrandTotal()

    End Sub

    Private Sub txtBuilderHours_TextChanged(sender As Object, e As EventArgs) Handles txtBuilderHours.TextChanged
        Try
            Dim bulderDayRate As Double = 200.0
            Dim days As Double = Helper.MakeDoubleValid(txtBuilderHours.Text) / 8
            Dim bulderDays As Double = Math.Ceiling(days / 0.5) * 0.5
            Me.txtBuilderCost.Text = Format(bulderDays * bulderDayRate, "C")
        Catch ex As Exception

        End Try

        WorkOutGrandTotal()
    End Sub

    Private Sub txtGrandTotal_TextChanged(sender As Object, e As EventArgs) Handles txtGrandTotal.TextChanged

    End Sub

    Private Function EmailBody(ByVal dt As DataTable) As String

        Dim Body As String = "<html xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:o=""urn:schemas-microsoft-com:office:office"" xmlns:w=""urn:schemas-microsoft-com:office:word"" xmlns:x=""urn:schemas-microsoft-com:office:excel"" xmlns:m=""http://schemas.microsoft.com/office/2004/12/omml"" xmlns=""http://www.w3.org/TR/REC-html40""><head><meta http-equiv=Content-Type content=""text/html; charset=iso-8859-1""><meta name=Generator content=""Microsoft Word 15 (filtered medium)""><style><!--
                        /* Font Definitions */
                        @font-face
                            {font-family:""Cambria Math"";
                            panose-1:2 4 5 3 5 4 6 3 2 4;}
                        @font-face
                            {font-family:Calibri;
                            panose-1:2 15 5 2 2 2 4 3 2 4;}
                        /* Style Definitions */
                        p.MsoNormal, li.MsoNormal, div.MsoNormal
                            {margin:0cm;
                            margin-bottom:.0001pt;
                            font-size:11.0pt;
                            font-family:""Calibri"",sans-serif;
                            mso-fareast-language:EN-US;}
                        a:link, span.MsoHyperlink
                            {mso-style-priority:99;
                            color:#0563C1;
                            text-decoration:underline;}
                        a:visited, span.MsoHyperlinkFollowed
                            {mso-style-priority:99;
                            color:#954F72;
                            text-decoration:underline;}
                        span.EmailStyle17
                            {mso-style-type:personal-compose;
                            font-family:""Calibri"",sans-serif;
                            color:windowtext;}
                        .MsoChpDefault
                            {mso-style-type:export-only;
                            font-family:""Calibri"",sans-serif;
                            mso-fareast-language:EN-US;}
                        @page WordSection1
                            {size:612.0pt 792.0pt;
                            margin:72.0pt 72.0pt 72.0pt 72.0pt;}
                        div.WordSection1
                            {page:WordSection1;}
                        --></style><!--[if gte mso 9]><xml>
                        <o:shapedefaults v:ext=""edit"" spidmax=""1026"" />
                        </xml><![endif]--><!--[if gte mso 9]><xml>
                        <o:shapelayout v:ext=""edit"">
                        <o:idmap v:ext=""edit"" data=""1"" />
                        </o:shapelayout></xml><![endif]--></head><body lang=EN-GB link=""#0563C1"" vlink=""#954F72"">
                        <div class=WordSection1><p class=MsoNormal>Dear Sir/Madam,<o:p></o:p></p>
                        <p class=MsoNormal><o:p>&nbsp;</o:p></p>
                        <table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 align=left width=799 style='width:599.15pt;border-collapse:collapse;margin-left:6.75pt;margin-right:6.75pt'>
                        <tr style='height:15.0pt'>
                        <td width=115 nowrap valign=bottom style='width:86.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'>
                        <p class=MsoNormal style='mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'>
                        <b><span style='color:black;mso-fareast-language:EN-GB'>SOR CODE<o:p></o:p></span></b></p>
                        </td>
                        <td width=487 nowrap valign=bottom style='width:365.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'>
                        <p class=MsoNormal style='mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'><b><span style='color:black;mso-fareast-language:EN-GB'>Description<o:p></o:p></span></b></p>
                        </td>
                        <td width=64 nowrap valign=bottom style='width:48.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'>
                        <p class=MsoNormal align=center style='text-align:center;mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'><b><span style='color:black;mso-fareast-language:EN-GB'>Qty<o:p></o:p></span></b></p>
                        </td>
                        <td width=70 nowrap valign=bottom style='width:52.15pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'>
                        <p class=MsoNormal align=center style='text-align:center;mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'><b><span style='color:black;mso-fareast-language:EN-GB'>UnitPrice<o:p></o:p></span></b></p>
                        </td>
                        <td width=64 nowrap valign=bottom style='width:70.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'><p class=MsoNormal align=center style='text-align:center;mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'><b><span style='color:black;mso-fareast-language:EN-GB'>Line Total<o:p></o:p></span></b></p>
                        </td>
                        </tr>"
        For Each dr As DataRow In dt.Rows

            Body += "
            <tr style='height:15.0pt'>
            <td width=115 nowrap valign=bottom style='width:86.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'>
            <p class=MsoNormal style='mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'>
            <span style='color:black;mso-fareast-language:EN-GB'>" & dr("Code") & "<o:p></o:p></span></p>
            </td>
            <td width=487 nowrap valign=bottom style='width:365.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'><p class=MsoNormal style='mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'>
            <span style='color:black;mso-fareast-language:EN-GB'>" & dr("Description") & "<o:p></o:p>
            </span></p>
            </td>
            <td width=64 nowrap valign=bottom style='width:48.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'><p class=MsoNormal align=center style='text-align:center;mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'>
            <span style='color:black;mso-fareast-language:EN-GB'>" & dr("quantity") & "<o:p></o:p>
            </span></p>
            </td>
            <td width=70 nowrap valign=bottom style='width:52.15pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'><p class=MsoNormal align=center style='text-align:center;mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'>
            <span style='color:black;mso-fareast-language:EN-GB'>£" & dr("Price") & "<o:p></o:p></span>
            </p></td>
            <td width=64 nowrap valign=bottom style='width:55.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:15.0pt'><p class=MsoNormal align=center style='text-align:center;mso-element:frame;mso-element-frame-hspace:9.0pt;mso-element-wrap:around;mso-element-anchor-vertical:paragraph;mso-element-anchor-horizontal:margin;mso-element-top:64.1pt;mso-height-rule:exactly'>
            <span style='color:black;mso-fareast-language:EN-GB'>£" & dr("Total") & "<o:p></o:p></span>
            </p>
            </td>
            </tr>"
        Next

        Body += "</table>
                <p class=MsoNormal><o:p>&nbsp;</o:p></p><p class=MsoNormal><o:p>&nbsp;</o:p></p><p class=MsoNormal><o:p>&nbsp;</o:p></p><p class=MsoNormal><o:p>&nbsp;</o:p></p>
                <p class=MsoNormal><o:p>&nbsp;</o:p></p><p class=MsoNormal><o:p>&nbsp;</o:p></p>
                <p class=MsoNormal><o:p></o:p></p></div>"

        Return Body

    End Function

    Private Sub btnEmailSOR_Click(sender As Object, e As EventArgs) Handles btnEmailSOR.Click

        If Helper.IsEmailValid(loggedInUser.EmailAddress) Then
            Dim Body As String = EmailBody(CurrentQuoteJob.ScheduleOfRates.Table)

            Dim oEmail As New Emails
            oEmail.Body = Body
            oEmail.From = Entity.Sys.EmailAddress.FSM
            oEmail.To = loggedInUser.EmailAddress
            oEmail.Subject = "SOR List"
            oEmail.SendMe = True
            oEmail.Send()
        Else
            ShowMessage("Your email address has not been added to your account, please contact IT", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

#End Region

End Class