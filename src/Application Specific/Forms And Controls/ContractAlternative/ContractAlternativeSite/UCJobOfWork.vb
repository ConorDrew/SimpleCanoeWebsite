Public Class UCJobOfWork : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        SetupJobItemsDataGrid()
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
    Friend WithEvents btnRemoveFromJobOfWork As System.Windows.Forms.Button

    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgVisits As System.Windows.Forms.DataGrid
    Friend WithEvents dtpFirstVisitDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFirstVisitDate As System.Windows.Forms.Label
    Friend WithEvents dgJobItemsAdded As System.Windows.Forms.DataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMileageCostPerVisit As System.Windows.Forms.TextBox
    Friend WithEvents txtAverageMileage As System.Windows.Forms.TextBox
    Friend WithEvents txtCostPerMile As System.Windows.Forms.TextBox
    Friend WithEvents chkIncludeMileage As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRatesTotal As System.Windows.Forms.TextBox
    Friend WithEvents chkRates As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotalSitePrice As System.Windows.Forms.TextBox
    Friend WithEvents grpScheduleOfRates As System.Windows.Forms.GroupBox
    Friend WithEvents btnSiteScheduleOfRates As System.Windows.Forms.Button
    Friend WithEvents txtQuantityPerVisit As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnAddRates As System.Windows.Forms.Button
    Friend WithEvents btnRemoveRates As System.Windows.Forms.Button
    Friend WithEvents cboScheduleOfRatesCategoryID As System.Windows.Forms.ComboBox
    Friend WithEvents lblScheduleOfRatesCategoryID As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtDescriptionRate As System.Windows.Forms.TextBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents dgScheduleOfRates As System.Windows.Forms.DataGrid
    Friend WithEvents txtPricePerVisit As System.Windows.Forms.TextBox
    Friend WithEvents lblPricePerVisit As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtItemTotal As System.Windows.Forms.TextBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnRemoveFromJobOfWork = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgVisits = New System.Windows.Forms.DataGrid
        Me.dgJobItemsAdded = New System.Windows.Forms.DataGrid
        Me.dtpFirstVisitDate = New System.Windows.Forms.DateTimePicker
        Me.lblFirstVisitDate = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtMileageCostPerVisit = New System.Windows.Forms.TextBox
        Me.txtAverageMileage = New System.Windows.Forms.TextBox
        Me.txtCostPerMile = New System.Windows.Forms.TextBox
        Me.chkIncludeMileage = New System.Windows.Forms.CheckBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtRatesTotal = New System.Windows.Forms.TextBox
        Me.chkRates = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTotalSitePrice = New System.Windows.Forms.TextBox
        Me.grpScheduleOfRates = New System.Windows.Forms.GroupBox
        Me.btnSiteScheduleOfRates = New System.Windows.Forms.Button
        Me.txtQuantityPerVisit = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnAddRates = New System.Windows.Forms.Button
        Me.btnRemoveRates = New System.Windows.Forms.Button
        Me.cboScheduleOfRatesCategoryID = New System.Windows.Forms.ComboBox
        Me.lblScheduleOfRatesCategoryID = New System.Windows.Forms.Label
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.lblCode = New System.Windows.Forms.Label
        Me.txtDescriptionRate = New System.Windows.Forms.TextBox
        Me.lblDescription = New System.Windows.Forms.Label
        Me.txtPrice = New System.Windows.Forms.TextBox
        Me.lblPrice = New System.Windows.Forms.Label
        Me.dgScheduleOfRates = New System.Windows.Forms.DataGrid
        Me.txtPricePerVisit = New System.Windows.Forms.TextBox
        Me.lblPricePerVisit = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtItemTotal = New System.Windows.Forms.TextBox
        CType(Me.dgVisits, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgJobItemsAdded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpScheduleOfRates.SuspendLayout()
        CType(Me.dgScheduleOfRates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRemoveFromJobOfWork
        '
        Me.btnRemoveFromJobOfWork.UseVisualStyleBackColor = True
        Me.btnRemoveFromJobOfWork.Location = New System.Drawing.Point(352, 8)
        Me.btnRemoveFromJobOfWork.Name = "btnRemoveFromJobOfWork"
        Me.btnRemoveFromJobOfWork.Size = New System.Drawing.Size(96, 23)
        Me.btnRemoveFromJobOfWork.TabIndex = 0
        Me.btnRemoveFromJobOfWork.Text = "Remove"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Job Items Added"
        '
        'dgVisits
        '
        Me.dgVisits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgVisits.DataMember = ""
        Me.dgVisits.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgVisits.Location = New System.Drawing.Point(424, 224)
        Me.dgVisits.Name = "dgVisits"
        Me.dgVisits.Size = New System.Drawing.Size(456, 88)
        Me.dgVisits.TabIndex = 46
        '
        'dgJobItemsAdded
        '
        Me.dgJobItemsAdded.DataMember = ""
        Me.dgJobItemsAdded.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgJobItemsAdded.Location = New System.Drawing.Point(8, 32)
        Me.dgJobItemsAdded.Name = "dgJobItemsAdded"
        Me.dgJobItemsAdded.Size = New System.Drawing.Size(440, 160)
        Me.dgJobItemsAdded.TabIndex = 1
        '
        'dtpFirstVisitDate
        '
        Me.dtpFirstVisitDate.CalendarFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFirstVisitDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFirstVisitDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFirstVisitDate.Location = New System.Drawing.Point(104, 200)
        Me.dtpFirstVisitDate.Name = "dtpFirstVisitDate"
        Me.dtpFirstVisitDate.Size = New System.Drawing.Size(96, 21)
        Me.dtpFirstVisitDate.TabIndex = 3
        Me.dtpFirstVisitDate.Tag = "ContractSite.FirstVisitDate"
        Me.dtpFirstVisitDate.Value = New Date(2007, 6, 18, 15, 21, 39, 569)
        '
        'lblFirstVisitDate
        '
        Me.lblFirstVisitDate.BackColor = System.Drawing.Color.White
        Me.lblFirstVisitDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstVisitDate.Location = New System.Drawing.Point(8, 202)
        Me.lblFirstVisitDate.Name = "lblFirstVisitDate"
        Me.lblFirstVisitDate.Size = New System.Drawing.Size(96, 16)
        Me.lblFirstVisitDate.TabIndex = 48
        Me.lblFirstVisitDate.Text = "First Visit Date"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(424, 208)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "PPM Scheduled"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 223)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 21)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "Mileage Per Visit"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(208, 223)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 21)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "Price Per Mile"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(208, 247)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 21)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Mileage Total Per Visit"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMileageCostPerVisit
        '
        Me.txtMileageCostPerVisit.Enabled = False
        Me.txtMileageCostPerVisit.Location = New System.Drawing.Point(344, 247)
        Me.txtMileageCostPerVisit.Name = "txtMileageCostPerVisit"
        Me.txtMileageCostPerVisit.Size = New System.Drawing.Size(72, 21)
        Me.txtMileageCostPerVisit.TabIndex = 8
        Me.txtMileageCostPerVisit.Text = ""
        '
        'txtAverageMileage
        '
        Me.txtAverageMileage.Location = New System.Drawing.Point(128, 223)
        Me.txtAverageMileage.Name = "txtAverageMileage"
        Me.txtAverageMileage.Size = New System.Drawing.Size(72, 21)
        Me.txtAverageMileage.TabIndex = 5
        Me.txtAverageMileage.Text = "0"
        '
        'txtCostPerMile
        '
        Me.txtCostPerMile.Location = New System.Drawing.Point(344, 223)
        Me.txtCostPerMile.Name = "txtCostPerMile"
        Me.txtCostPerMile.Size = New System.Drawing.Size(72, 21)
        Me.txtCostPerMile.TabIndex = 6
        Me.txtCostPerMile.Text = "£0.00"
        '
        'chkIncludeMileage
        '
        Me.chkIncludeMileage.Location = New System.Drawing.Point(8, 247)
        Me.chkIncludeMileage.Name = "chkIncludeMileage"
        Me.chkIncludeMileage.Size = New System.Drawing.Size(193, 21)
        Me.chkIncludeMileage.TabIndex = 7
        Me.chkIncludeMileage.Text = "Include Mileage in Visit Total"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(208, 270)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 23)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "Rate Total Per Visit"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRatesTotal
        '
        Me.txtRatesTotal.Enabled = False
        Me.txtRatesTotal.Location = New System.Drawing.Point(344, 271)
        Me.txtRatesTotal.MaxLength = 50
        Me.txtRatesTotal.Name = "txtRatesTotal"
        Me.txtRatesTotal.Size = New System.Drawing.Size(72, 21)
        Me.txtRatesTotal.TabIndex = 10
        Me.txtRatesTotal.Tag = "SystemScheduleOfRate.Code"
        Me.txtRatesTotal.Text = ""
        '
        'chkRates
        '
        Me.chkRates.Location = New System.Drawing.Point(8, 270)
        Me.chkRates.Name = "chkRates"
        Me.chkRates.Size = New System.Drawing.Size(176, 23)
        Me.chkRates.TabIndex = 9
        Me.chkRates.Text = "Include Rates in Visit Total"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(208, 294)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 23)
        Me.Label6.TabIndex = 80
        Me.Label6.Text = "Total Work Price"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalSitePrice
        '
        Me.txtTotalSitePrice.Location = New System.Drawing.Point(344, 295)
        Me.txtTotalSitePrice.Name = "txtTotalSitePrice"
        Me.txtTotalSitePrice.Size = New System.Drawing.Size(72, 21)
        Me.txtTotalSitePrice.TabIndex = 12
        Me.txtTotalSitePrice.Text = ""
        '
        'grpScheduleOfRates
        '
        Me.grpScheduleOfRates.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpScheduleOfRates.Controls.Add(Me.btnSiteScheduleOfRates)
        Me.grpScheduleOfRates.Controls.Add(Me.txtQuantityPerVisit)
        Me.grpScheduleOfRates.Controls.Add(Me.Label7)
        Me.grpScheduleOfRates.Controls.Add(Me.btnAddRates)
        Me.grpScheduleOfRates.Controls.Add(Me.btnRemoveRates)
        Me.grpScheduleOfRates.Controls.Add(Me.cboScheduleOfRatesCategoryID)
        Me.grpScheduleOfRates.Controls.Add(Me.lblScheduleOfRatesCategoryID)
        Me.grpScheduleOfRates.Controls.Add(Me.txtCode)
        Me.grpScheduleOfRates.Controls.Add(Me.lblCode)
        Me.grpScheduleOfRates.Controls.Add(Me.txtDescriptionRate)
        Me.grpScheduleOfRates.Controls.Add(Me.lblDescription)
        Me.grpScheduleOfRates.Controls.Add(Me.txtPrice)
        Me.grpScheduleOfRates.Controls.Add(Me.lblPrice)
        Me.grpScheduleOfRates.Controls.Add(Me.dgScheduleOfRates)

        Me.grpScheduleOfRates.Location = New System.Drawing.Point(456, 0)
        Me.grpScheduleOfRates.Name = "grpScheduleOfRates"
        Me.grpScheduleOfRates.Size = New System.Drawing.Size(432, 208)
        Me.grpScheduleOfRates.TabIndex = 2
        Me.grpScheduleOfRates.TabStop = False
        Me.grpScheduleOfRates.Text = "Property Contract Schedule Of Rates"
        '
        'btnSiteScheduleOfRates
        '
        Me.btnSiteScheduleOfRates.Location = New System.Drawing.Point(96, 178)
        Me.btnSiteScheduleOfRates.Name = "btnSiteScheduleOfRates"
        Me.btnSiteScheduleOfRates.Size = New System.Drawing.Size(240, 23)
        Me.btnSiteScheduleOfRates.TabIndex = 7
        Me.btnSiteScheduleOfRates.Text = "Add Property Schedule Of Rates"
        '
        'txtQuantityPerVisit
        '
        Me.txtQuantityPerVisit.Location = New System.Drawing.Point(344, 40)
        Me.txtQuantityPerVisit.MaxLength = 9
        Me.txtQuantityPerVisit.Name = "txtQuantityPerVisit"
        Me.txtQuantityPerVisit.Size = New System.Drawing.Size(80, 21)
        Me.txtQuantityPerVisit.TabIndex = 4
        Me.txtQuantityPerVisit.Tag = "SystemScheduleOfRate.Price"
        Me.txtQuantityPerVisit.Text = ""
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(264, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 20)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "Qty Per Visit"
        '
        'btnAddRates
        '
        Me.btnAddRates.Location = New System.Drawing.Point(8, 178)
        Me.btnAddRates.Name = "btnAddRates"
        Me.btnAddRates.Size = New System.Drawing.Size(72, 23)
        Me.btnAddRates.TabIndex = 6
        Me.btnAddRates.Text = "Add"
        '
        'btnRemoveRates
        '
        Me.btnRemoveRates.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveRates.Location = New System.Drawing.Point(352, 180)
        Me.btnRemoveRates.Name = "btnRemoveRates"
        Me.btnRemoveRates.Size = New System.Drawing.Size(72, 23)
        Me.btnRemoveRates.TabIndex = 8
        Me.btnRemoveRates.Text = "Remove"
        '
        'cboScheduleOfRatesCategoryID
        '
        Me.cboScheduleOfRatesCategoryID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboScheduleOfRatesCategoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboScheduleOfRatesCategoryID.Location = New System.Drawing.Point(88, 16)
        Me.cboScheduleOfRatesCategoryID.Name = "cboScheduleOfRatesCategoryID"
        Me.cboScheduleOfRatesCategoryID.Size = New System.Drawing.Size(171, 21)
        Me.cboScheduleOfRatesCategoryID.TabIndex = 0
        Me.cboScheduleOfRatesCategoryID.Tag = "SystemScheduleOfRate.ScheduleOfRatesCategoryID"
        '
        'lblScheduleOfRatesCategoryID
        '
        Me.lblScheduleOfRatesCategoryID.Location = New System.Drawing.Point(8, 16)
        Me.lblScheduleOfRatesCategoryID.Name = "lblScheduleOfRatesCategoryID"
        Me.lblScheduleOfRatesCategoryID.Size = New System.Drawing.Size(80, 20)
        Me.lblScheduleOfRatesCategoryID.TabIndex = 43
        Me.lblScheduleOfRatesCategoryID.Text = "Category"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(88, 40)
        Me.txtCode.MaxLength = 50
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(171, 21)
        Me.txtCode.TabIndex = 1
        Me.txtCode.Tag = "SystemScheduleOfRate.Code"
        Me.txtCode.Text = ""
        '
        'lblCode
        '
        Me.lblCode.Location = New System.Drawing.Point(8, 40)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(80, 20)
        Me.lblCode.TabIndex = 42
        Me.lblCode.Text = "Code"
        '
        'txtDescriptionRate
        '
        Me.txtDescriptionRate.Location = New System.Drawing.Point(88, 64)
        Me.txtDescriptionRate.MaxLength = 0
        Me.txtDescriptionRate.Multiline = True
        Me.txtDescriptionRate.Name = "txtDescriptionRate"
        Me.txtDescriptionRate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescriptionRate.Size = New System.Drawing.Size(336, 24)
        Me.txtDescriptionRate.TabIndex = 2
        Me.txtDescriptionRate.Tag = "SystemScheduleOfRate.Description"
        Me.txtDescriptionRate.Text = ""
        '
        'lblDescription
        '
        Me.lblDescription.Location = New System.Drawing.Point(8, 64)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(80, 20)
        Me.lblDescription.TabIndex = 41
        Me.lblDescription.Text = "Description"
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(344, 16)
        Me.txtPrice.MaxLength = 9
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(80, 21)
        Me.txtPrice.TabIndex = 3
        Me.txtPrice.Tag = "SystemScheduleOfRate.Price"
        Me.txtPrice.Text = ""
        '
        'lblPrice
        '
        Me.lblPrice.Location = New System.Drawing.Point(264, 16)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(80, 20)
        Me.lblPrice.TabIndex = 40
        Me.lblPrice.Text = "Price"
        '
        'dgScheduleOfRates
        '
        Me.dgScheduleOfRates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgScheduleOfRates.DataMember = ""
        Me.dgScheduleOfRates.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgScheduleOfRates.Location = New System.Drawing.Point(8, 91)
        Me.dgScheduleOfRates.Name = "dgScheduleOfRates"
        Me.dgScheduleOfRates.Size = New System.Drawing.Size(416, 85)
        Me.dgScheduleOfRates.TabIndex = 5
        '
        'txtPricePerVisit
        '
        Me.txtPricePerVisit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPricePerVisit.Location = New System.Drawing.Point(128, 295)
        Me.txtPricePerVisit.MaxLength = 9
        Me.txtPricePerVisit.Name = "txtPricePerVisit"
        Me.txtPricePerVisit.Size = New System.Drawing.Size(72, 21)
        Me.txtPricePerVisit.TabIndex = 11
        Me.txtPricePerVisit.Tag = "ContractSite.PricePerVisit"
        Me.txtPricePerVisit.Text = ""
        '
        'lblPricePerVisit
        '
        Me.lblPricePerVisit.BackColor = System.Drawing.Color.White
        Me.lblPricePerVisit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPricePerVisit.Location = New System.Drawing.Point(8, 295)
        Me.lblPricePerVisit.Name = "lblPricePerVisit"
        Me.lblPricePerVisit.Size = New System.Drawing.Size(120, 20)
        Me.lblPricePerVisit.TabIndex = 83
        Me.lblPricePerVisit.Text = "Total Price Per Visit"
        Me.lblPricePerVisit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(208, 202)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 16)
        Me.Label9.TabIndex = 85
        Me.Label9.Text = "Item Total"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtItemTotal
        '
        Me.txtItemTotal.Enabled = False
        Me.txtItemTotal.Location = New System.Drawing.Point(344, 200)
        Me.txtItemTotal.MaxLength = 50
        Me.txtItemTotal.Name = "txtItemTotal"
        Me.txtItemTotal.Size = New System.Drawing.Size(72, 21)
        Me.txtItemTotal.TabIndex = 4
        Me.txtItemTotal.Tag = "SystemScheduleOfRate.Code"
        Me.txtItemTotal.Text = ""
        '
        'UCJobOfWork
        '
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtItemTotal)
        Me.Controls.Add(Me.txtPricePerVisit)
        Me.Controls.Add(Me.lblPricePerVisit)
        Me.Controls.Add(Me.grpScheduleOfRates)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTotalSitePrice)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMileageCostPerVisit)
        Me.Controls.Add(Me.txtAverageMileage)
        Me.Controls.Add(Me.txtCostPerMile)
        Me.Controls.Add(Me.chkIncludeMileage)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtRatesTotal)
        Me.Controls.Add(Me.chkRates)
        Me.Controls.Add(Me.btnRemoveFromJobOfWork)
        Me.Controls.Add(Me.dgVisits)
        Me.Controls.Add(Me.dgJobItemsAdded)
        Me.Controls.Add(Me.dtpFirstVisitDate)
        Me.Controls.Add(Me.lblFirstVisitDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Name = "UCJobOfWork"
        Me.Size = New System.Drawing.Size(896, 320)
        CType(Me.dgVisits, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgJobItemsAdded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpScheduleOfRates.ResumeLayout(False)
        CType(Me.dgScheduleOfRates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
        SetupJobItemsDataGrid()
        SetupVisitDataGrid()
        SetupScheduleOfRatesDataGrid()
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get

        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Public Event RemovedItem()

    Private _onControl As UCContractAlternativeSite = Nothing

    Public Property OnControl() As UCContractAlternativeSite
        Get
            Return _onControl
        End Get
        Set(ByVal Value As UCContractAlternativeSite)
            _onControl = Value
        End Set
    End Property

    Private _CurrentJobOfWork As Entity.ContractAlternativeSiteJobOfWorks.ContractAlternativeSiteJobOfWork

    Public Property CurrentJobOfWork() As Entity.ContractAlternativeSiteJobOfWorks.ContractAlternativeSiteJobOfWork
        Get
            Return _CurrentJobOfWork
        End Get
        Set(ByVal Value As Entity.ContractAlternativeSiteJobOfWorks.ContractAlternativeSiteJobOfWork)
            _CurrentJobOfWork = Value

            Me.txtCostPerMile.Text = Format(DB.CustomerCharge.CustomerCharge_GetForCustomer(OnControl.CurrentContractSite.PropertyID).MileageRate, "C")
            Me.txtPricePerVisit.Text = "£0.00"
            ScheduleOfRatesDataview = BuildUpScheduleOfRatesDataview()

            If CurrentJobOfWork Is Nothing Then
                CurrentJobOfWork = New Entity.ContractAlternativeSiteJobOfWorks.ContractAlternativeSiteJobOfWork
                dtpFirstVisitDate.Value = OnControl.CurrentContract.ContractStartDate.AddDays(1)
                CurrentJobOfWork.FirstVisitDate = OnControl.CurrentContract.ContractStartDate.AddDays(1)
            End If

            dtpFirstVisitDate.Value = CurrentJobOfWork.FirstVisitDate

            JobItemsAddedDataView = DB.ContractAlternativeSiteJobItems.GetAll_For_JobOfWorkID(CurrentJobOfWork.ContractSiteJobOfWorkID)
            Visits = DB.ContractAlternativePPMVisit.GetAll_For_ContractSiteJobOfWorkID(CurrentJobOfWork.ContractSiteJobOfWorkID)
            If Visits.Table.Rows.Count > 0 Then
                Me.dtpFirstVisitDate.Enabled = False
                Me.btnRemoveFromJobOfWork.Enabled = False
            Else
                Me.dtpFirstVisitDate.Enabled = True
                Me.btnRemoveFromJobOfWork.Enabled = True
            End If

            Combo.SetUpCombo(cboScheduleOfRatesCategoryID, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.ScheduleRatesCategories).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
            Populate()
        End Set
    End Property

    Private _JobItemsAddedDataView As DataView

    Public Property JobItemsAddedDataView() As DataView
        Get
            Return _JobItemsAddedDataView
        End Get
        Set(ByVal Value As DataView)
            _JobItemsAddedDataView = Value
            _JobItemsAddedDataView.AllowNew = False
            _JobItemsAddedDataView.AllowEdit = False
            _JobItemsAddedDataView.AllowDelete = False
            _JobItemsAddedDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblContractAlternativeSiteJobItems.ToString
            dgJobItemsAdded.DataSource = JobItemsAddedDataView
        End Set
    End Property

    Private ReadOnly Property SelectedJobItemsDataRow() As DataRow
        Get
            If Not Me.dgJobItemsAdded.CurrentRowIndex = -1 Then
                Return JobItemsAddedDataView(Me.dgJobItemsAdded.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _Visits As DataView

    Public Property Visits() As DataView
        Get
            Return _Visits
        End Get
        Set(ByVal Value As DataView)
            _Visits = Value
            _Visits.Table.TableName = Entity.Sys.Enums.TableNames.tblContractPPMVisit.ToString
            _Visits.AllowNew = False
            _Visits.AllowEdit = True
            _Visits.AllowDelete = False
            Me.dgVisits.DataSource = Visits
        End Set
    End Property

    Private _ScheduleOfRatesDataview As DataView

    Public Property ScheduleOfRatesDataview() As DataView
        Get
            Return _ScheduleOfRatesDataview
        End Get
        Set(ByVal Value As DataView)
            _ScheduleOfRatesDataview = Value

            _ScheduleOfRatesDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString
            _ScheduleOfRatesDataview.AllowNew = False
            _ScheduleOfRatesDataview.AllowEdit = True
            _ScheduleOfRatesDataview.AllowDelete = False
            Me.dgScheduleOfRates.DataSource = ScheduleOfRatesDataview
        End Set
    End Property

    Private ReadOnly Property SelectedRatesDataRow() As DataRow
        Get
            If Not Me.dgScheduleOfRates.CurrentRowIndex = -1 Then
                Return ScheduleOfRatesDataview(Me.dgScheduleOfRates.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _isLoading As Boolean = False

    Private Property IsLoading() As Boolean
        Get
            Return _isLoading
        End Get
        Set(ByVal Value As Boolean)
            _isLoading = Value
        End Set
    End Property

#End Region

#Region "Setup"

    Public Sub SetupJobItemsDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(dgJobItemsAdded)
        Dim tStyle As DataGridTableStyle = Me.dgJobItemsAdded.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Description As New DataGridLabelColumn
        Description.Format = ""
        Description.FormatInfo = Nothing
        Description.HeaderText = "Description"
        Description.MappingName = "Description"
        Description.ReadOnly = True
        Description.Width = 100
        Description.NullText = ""
        tStyle.GridColumnStyles.Add(Description)

        Dim PricePerVisit As New DataGridLabelColumn
        PricePerVisit.Format = "C"
        PricePerVisit.FormatInfo = Nothing
        PricePerVisit.HeaderText = "Item Price Per Visit"
        PricePerVisit.MappingName = "ItemPricePerVisit"
        PricePerVisit.ReadOnly = True
        PricePerVisit.Width = 85
        PricePerVisit.NullText = ""
        tStyle.GridColumnStyles.Add(PricePerVisit)

        Dim VisitFrequency As New DataGridLabelColumn
        VisitFrequency.Format = ""
        VisitFrequency.FormatInfo = Nothing
        VisitFrequency.HeaderText = "Visit Frequency"
        VisitFrequency.MappingName = "VisitFrequency"
        VisitFrequency.ReadOnly = True
        VisitFrequency.Width = 100
        VisitFrequency.NullText = ""
        tStyle.GridColumnStyles.Add(VisitFrequency)

        Dim VisitDuration As New DataGridLabelColumn
        VisitDuration.Format = ""
        VisitDuration.FormatInfo = Nothing
        VisitDuration.HeaderText = "Visit Duration"
        VisitDuration.MappingName = "VisitDuration"
        VisitDuration.ReadOnly = True
        VisitDuration.Width = 90
        VisitDuration.NullText = ""
        VisitDuration.Alignment = HorizontalAlignment.Center
        tStyle.GridColumnStyles.Add(VisitDuration)

        Dim Assets As New DataGridLabelColumn
        Assets.Format = "C"
        Assets.FormatInfo = Nothing
        Assets.HeaderText = "Appliances"
        Assets.MappingName = "Assets"
        Assets.ReadOnly = True
        Assets.Width = 130
        Assets.NullText = ""
        tStyle.GridColumnStyles.Add(Assets)

        tStyle.ReadOnly = False
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblContractAlternativeSiteJobItems.ToString
        Me.dgJobItemsAdded.TableStyles.Add(tStyle)

    End Sub

    Public Sub SetupVisitDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(dgVisits)
        Dim tStyle As DataGridTableStyle = Me.dgVisits.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim EstimatedVisitDate As New DataGridLabelColumn
        EstimatedVisitDate.Format = "dd/MM/yyyy"
        EstimatedVisitDate.FormatInfo = Nothing
        EstimatedVisitDate.HeaderText = "Estimated Visit Date"
        EstimatedVisitDate.MappingName = "EstimatedVisitDate"
        EstimatedVisitDate.ReadOnly = True
        EstimatedVisitDate.Width = 150
        EstimatedVisitDate.NullText = ""
        tStyle.GridColumnStyles.Add(EstimatedVisitDate)

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "JobNumber"
        JobNumber.MappingName = "JobNumber"
        JobNumber.ReadOnly = True
        JobNumber.Width = 100
        JobNumber.NullText = ""
        tStyle.GridColumnStyles.Add(JobNumber)

        Dim StartDateTime As New DataGridLabelColumn
        StartDateTime.Format = "dd/MM/yyyy"
        StartDateTime.FormatInfo = Nothing
        StartDateTime.HeaderText = "Visit Date"
        StartDateTime.MappingName = "StartDateTime"
        StartDateTime.ReadOnly = True
        StartDateTime.Width = 100
        StartDateTime.NullText = "Not Set"
        tStyle.GridColumnStyles.Add(StartDateTime)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Engineer"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 100
        Name.NullText = "N/A"
        tStyle.GridColumnStyles.Add(Name)

        tStyle.ReadOnly = False
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblContractPPMVisit.ToString
        Me.dgVisits.TableStyles.Add(tStyle)

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
        Category.Width = 95
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
        Description.Width = 105
        Description.NullText = ""
        tStyle.GridColumnStyles.Add(Description)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Unit Price"
        Price.MappingName = "Price"
        Price.ReadOnly = False
        Price.Width = 60
        Price.NullText = ""
        tStyle.GridColumnStyles.Add(Price)

        Dim QtyPerVisit As New DataGridLabelColumn
        QtyPerVisit.Format = ""
        QtyPerVisit.FormatInfo = Nothing
        QtyPerVisit.HeaderText = "Unit Qty Per Visit"
        QtyPerVisit.MappingName = "QtyPerVisit"
        QtyPerVisit.ReadOnly = False
        QtyPerVisit.Width = 100
        QtyPerVisit.NullText = ""
        tStyle.GridColumnStyles.Add(QtyPerVisit)

        tStyle.ReadOnly = False
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString
        Me.dgScheduleOfRates.TableStyles.Add(tStyle)

    End Sub

#End Region

#Region "Events"

    Private Sub UCJobOfWork_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub btnRemoveFromJobOfWork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveFromJobOfWork.Click
        If SelectedJobItemsDataRow Is Nothing Then
            Exit Sub
        End If

        DB.ContractAlternativeSiteJobItems.Update(SelectedJobItemsDataRow("ContractSiteJobItemID"), 0)
        CalculateItemTotal()
        RaiseEvent RemovedItem()
    End Sub

    Private Sub dtpFirstVisitDate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFirstVisitDate.LostFocus
        If dtpFirstVisitDate.Value < OnControl.CurrentContract.ContractStartDate Or
            dtpFirstVisitDate.Value > OnControl.CurrentContract.ContractEndDate Then
            ShowMessage("First Visit must be inside the contract boundaries", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dtpFirstVisitDate.Value = OnControl.CurrentContract.ContractStartDate.AddDays(1)
        Else
            CurrentJobOfWork.FirstVisitDate = dtpFirstVisitDate.Value
        End If
    End Sub

    Private Sub dgJobItemsAdded_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgJobItemsAdded.MouseUp
        Dim HitTestInfo As DataGrid.HitTestInfo
        HitTestInfo = dgJobItemsAdded.HitTest(e.X, e.Y)

        If Not SelectedJobItemsDataRow Is Nothing Then
            If HitTestInfo.Column = 4 Then
                ShowForm(GetType(FRMJobItemAssets), True, New Object() {SelectedJobItemsDataRow("ContractSiteJobItemID")})
            End If
        End If

    End Sub

    Private Sub txtPricePerVisit_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPricePerVisit.LostFocus
        Dim price As String = ""

        If txtPricePerVisit.Text.Trim.Length = 0 Then
            price = Format(0.0, "C")
        ElseIf Not IsNumeric(txtPricePerVisit.Text.Replace("£", "")) Then
            price = Format(0.0, "C")
        Else
            price = Format(CDbl(txtPricePerVisit.Text.Replace("£", "")), "C")
        End If
        txtPricePerVisit.Text = price
        CalculateSiteTotal()
    End Sub

    Private Sub txtAverageMileage_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAverageMileage.LostFocus
        Dim mileage As String = ""

        If txtAverageMileage.Text.Trim.Length = 0 Then
            mileage = Format(0.0, "C")
        ElseIf Not IsNumeric(txtAverageMileage.Text) Then
            mileage = Format(0.0, "C")
        Else
            mileage = Format(CDbl(txtAverageMileage.Text), "F")
        End If
        txtAverageMileage.Text = mileage
        CalculateMileageTotal()
        CalculateSiteTotal()
        CurrentJobOfWork.SetAverageMileage = txtAverageMileage.Text.Replace("£", "")
    End Sub

    Private Sub txtCostPerMile_Focus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCostPerMile.LostFocus
        Dim price As String = ""

        If txtCostPerMile.Text.Trim.Length = 0 Then
            price = Format(0.0, "C")
        ElseIf Not IsNumeric(txtCostPerMile.Text.Replace("£", "")) Then
            price = Format(0.0, "C")
        Else
            price = Format(CDbl(txtCostPerMile.Text.Replace("£", "")), "C")
        End If
        txtCostPerMile.Text = price
        CalculateMileageTotal()
        CalculateSiteTotal()

        CurrentJobOfWork.SetPricePerMile = Me.txtCostPerMile.Text.Replace("£", "")
    End Sub

    Private Sub chkIncludeMileage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIncludeMileage.CheckedChanged
        If chkIncludeMileage.Checked Then
            IncludeMileage()
        Else
            TakeawayMileage()
        End If
        CalculateSiteTotal()
        CurrentJobOfWork.SetIncludeMileagePrice = chkIncludeMileage.Checked
    End Sub

    Private Sub chkRates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRates.CheckedChanged
        If chkRates.Checked Then
            IncludeRates()
        Else
            TakeawayRates()
        End If
        CalculateSiteTotal()
        CurrentJobOfWork.SetIncludeRates = chkRates.Checked
    End Sub

    Private Sub btnAddRates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRates.Click
        Dim valid As Boolean = True
        Dim errorMsg As String = ""
        If Not Combo.GetSelectedItemValue(cboScheduleOfRatesCategoryID) > 0 Then
            errorMsg = "* Category is missing" & vbCrLf
            valid = False
        End If

        If txtDescriptionRate.Text.Trim.Length = 0 Then
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

        If txtQuantityPerVisit.Text.Trim.Length = 0 Then
            errorMsg += "* Quantity is missing" & vbCrLf
            valid = False
        ElseIf IsNumeric(txtQuantityPerVisit.Text) = False Then
            errorMsg += "* Qty must be numeric" & vbCrLf
            valid = False
        End If

        If valid Then
            Dim newRow As DataRow
            newRow = ScheduleOfRatesDataview.Table.NewRow
            newRow("ScheduleOfRatesCategoryID") = Combo.GetSelectedItemValue(cboScheduleOfRatesCategoryID)
            newRow("Category") = Combo.GetSelectedItemDescription(cboScheduleOfRatesCategoryID)
            newRow("Code") = txtCode.Text
            newRow("Description") = txtDescriptionRate.Text
            newRow("Price") = txtPrice.Text
            newRow("QtyPerVisit") = txtQuantityPerVisit.Text

            ScheduleOfRatesDataview.Table.Rows.Add(newRow)

            Combo.SetSelectedComboItem_By_Value(cboScheduleOfRatesCategoryID, "0")
            Me.txtCode.Text = ""
            Me.txtDescriptionRate.Text = ""
            Me.txtPrice.Text = ""
            Me.txtQuantityPerVisit.Text = ""
            CalculateRates()
            CalculateSiteTotal()
        Else
            MessageBox.Show("Please correct the following:" & vbCrLf & errorMsg, "Errors", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnRemoveRates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveRates.Click
        If Not SelectedRatesDataRow Is Nothing Then
            With SelectedRatesDataRow

                If MessageBox.Show("DELETE :" & .Item("Description"), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                    ScheduleOfRatesDataview.Table.Rows.Remove(SelectedRatesDataRow)
                    CalculateRates()
                    CalculateSiteTotal()
                End If

            End With
        End If
    End Sub

    Private Sub btnSiteScheduleOfRates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiteScheduleOfRates.Click
        Using f As New FRMSiteScheduleOfRateList(OnControl.CurrentContractSite.PropertyID, ScheduleOfRatesDataview)
            f.ShowDialog()
        End Using
        dgScheduleOfRates.DataSource = ScheduleOfRatesDataview
        CalculateRates()
        CalculateSiteTotal()
    End Sub

    Private Sub txtTotalSitePrice_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalSitePrice.LostFocus
        Dim price As String = ""

        If txtTotalSitePrice.Text.Trim.Length = 0 Then
            price = Format(0.0, "C")
        ElseIf Not IsNumeric(txtTotalSitePrice.Text.Replace("£", "")) Then
            price = Format(0.0, "C")
        Else
            price = Format(CDbl(txtTotalSitePrice.Text.Replace("£", "")), "C")
        End If
        txtTotalSitePrice.Text = price
        CurrentJobOfWork.SetTotalSitePrice = price.Replace("£", "")
    End Sub

#End Region

#Region "Functions"

    Private Function BuildUpScheduleOfRatesDataview() As DataView
        Dim newTable As New DataTable
        newTable.Columns.Add("ScheduleOfRatesCategoryID")
        newTable.Columns.Add("Category")
        newTable.Columns.Add("Code")
        newTable.Columns.Add("Description")
        newTable.Columns.Add("Price")
        newTable.Columns.Add("QtyPerVisit")
        newTable.TableName = Entity.Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString
        Return New DataView(newTable)
    End Function

    Private Sub IncludeMileage()
        Me.txtPricePerVisit.Text = Format(Entity.Sys.Helper.MakeDoubleValid(Me.txtPricePerVisit.Text.Replace("£", "")) _
                                        + Entity.Sys.Helper.MakeDoubleValid(Me.txtMileageCostPerVisit.Text.Replace("£", "")), "C")
    End Sub

    Private Sub TakeawayMileage()
        Me.txtPricePerVisit.Text = Format(Entity.Sys.Helper.MakeDoubleValid(Me.txtPricePerVisit.Text.Replace("£", "")) _
                                    - Entity.Sys.Helper.MakeDoubleValid(Me.txtMileageCostPerVisit.Text.Replace("£", "")), "C")
    End Sub

    Private Sub IncludeRates()
        Me.txtPricePerVisit.Text = Format(Entity.Sys.Helper.MakeDoubleValid(Me.txtPricePerVisit.Text.Replace("£", "")) _
                                        + Entity.Sys.Helper.MakeDoubleValid(Me.txtRatesTotal.Text.Replace("£", "")), "C")
    End Sub

    Private Sub TakeawayRates()
        Me.txtPricePerVisit.Text = Format(Entity.Sys.Helper.MakeDoubleValid(Me.txtPricePerVisit.Text.Replace("£", "")) _
                                    - Entity.Sys.Helper.MakeDoubleValid(Me.txtRatesTotal.Text.Replace("£", "")), "C")
    End Sub

    Private Sub CalculateRates()
        Dim oldTotal As Decimal = 0.0
        Dim runningTotal As Decimal = 0.0

        If Me.txtRatesTotal.Text.Trim.Length = 0 Then
            Me.txtRatesTotal.Text = "£0.00"
        Else
            oldTotal = Me.txtRatesTotal.Text.Replace("£", "0")
        End If

        For Each rate As DataRow In ScheduleOfRatesDataview.Table.Rows
            runningTotal += rate.Item("Price") * rate.Item("QtyPerVisit")
        Next

        Me.txtRatesTotal.Text = Format(runningTotal, "C")

        If Me.chkRates.Checked Then

            Me.txtPricePerVisit.Text = Entity.Sys.Helper.MakeDoubleValid(Me.txtPricePerVisit.Text.Replace("£", "")) - oldTotal
            Me.txtPricePerVisit.Text = Format(Entity.Sys.Helper.MakeDoubleValid(Me.txtPricePerVisit.Text.Replace("£", "")) _
                               + runningTotal, "C")

        End If
    End Sub

    Private Sub CalculateMileageTotal()
        Dim oldTotal As Decimal = 0.0
        If Me.txtMileageCostPerVisit.Text.Trim.Length = 0 Then
            Me.txtMileageCostPerVisit.Text = "£0.00"
        Else
            oldTotal = Me.txtMileageCostPerVisit.Text.Replace("£", "0")
        End If

        Me.txtMileageCostPerVisit.Text = Format(Entity.Sys.Helper.MakeDoubleValid(Me.txtAverageMileage.Text) _
                                    * Entity.Sys.Helper.MakeDoubleValid(Me.txtCostPerMile.Text.Replace("£", "")), "C")

        If Me.chkIncludeMileage.Checked Then

            Me.txtPricePerVisit.Text = Entity.Sys.Helper.MakeDoubleValid(Me.txtPricePerVisit.Text.Replace("£", "")) - oldTotal
            Me.txtPricePerVisit.Text = Format(Entity.Sys.Helper.MakeDoubleValid(Me.txtPricePerVisit.Text.Replace("£", "")) _
                               + Me.txtMileageCostPerVisit.Text.Replace("£", ""), "C")

        End If
    End Sub

    Public Sub CalculateItemTotal()
        Dim oldTotal As Decimal = 0.0
        Dim runningTotal As Decimal = 0.0

        If Me.txtItemTotal.Text.Trim.Length = 0 Then
            Me.txtItemTotal.Text = "£0.00"
        Else
            oldTotal = Me.txtItemTotal.Text.Replace("£", "0")
        End If

        For Each ji As DataRow In JobItemsAddedDataView.Table.Rows
            runningTotal += ji.Item("ItemPricePerVisit")
        Next

        Me.txtItemTotal.Text = Format(runningTotal, "C")

        Me.txtPricePerVisit.Text = Entity.Sys.Helper.MakeDoubleValid(Me.txtPricePerVisit.Text.Replace("£", "")) - oldTotal
        Me.txtPricePerVisit.Text = Format(Entity.Sys.Helper.MakeDoubleValid(Me.txtPricePerVisit.Text.Replace("£", "")) _
                           + runningTotal, "C")

        CalculateSiteTotal()

    End Sub

    Private Sub CalculateSiteTotal()
        Dim numberOfVisit As Integer = 0
        Dim price As String = ""

        If txtPricePerVisit.Text.Trim.Length = 0 Then
            price = Format(0.0, "C")
        ElseIf Not IsNumeric(txtPricePerVisit.Text.Replace("£", "")) Then
            price = Format(0.0, "C")
        Else
            price = Format(CDbl(txtPricePerVisit.Text.Replace("£", "")), "C")
        End If
        txtPricePerVisit.Text = price

        If Not SelectedJobItemsDataRow Is Nothing Then
            Select Case CType(SelectedJobItemsDataRow("VisitFrequencyID"), Entity.Sys.Enums.VisitFrequency)
                Case Entity.Sys.Enums.VisitFrequency.Annually
                    numberOfVisit = 1
                Case Entity.Sys.Enums.VisitFrequency.Bi_Annually
                    numberOfVisit = 2
                Case Entity.Sys.Enums.VisitFrequency.Monthly
                    numberOfVisit = 12
                Case Entity.Sys.Enums.VisitFrequency.Quarterly
                    numberOfVisit = 4
                Case Entity.Sys.Enums.VisitFrequency.Weekly
                    numberOfVisit = 52
            End Select
        End If

        If numberOfVisit = 0 Then
            Me.txtTotalSitePrice.Text = "£0.00"
        Else
            Me.txtTotalSitePrice.Text = Format(Me.txtPricePerVisit.Text.Replace("£", "") * numberOfVisit, "C")
        End If

        If IsLoading = False Then
            CurrentJobOfWork.SetPricePerVisit = price.Replace("£", "")
            CurrentJobOfWork.SetTotalSitePrice = Me.txtTotalSitePrice.Text.Replace("£", "")
        End If

    End Sub

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        IsLoading = True

        Me.dtpFirstVisitDate.Value = CurrentJobOfWork.FirstVisitDate

        Me.txtAverageMileage.Text = CurrentJobOfWork.AverageMileage
        Me.txtCostPerMile.Text = Format(CurrentJobOfWork.PricePerMile, "C")

        Me.chkIncludeMileage.Checked = CurrentJobOfWork.IncludeMileagePrice
        Me.chkRates.Checked = CurrentJobOfWork.IncludeRates
        ScheduleOfRatesDataview = DB.ContractAlternativeSiteJobOfWork.GetJobOfWorkScheduleOfRates(CurrentJobOfWork.ContractSiteJobOfWorkID)

        CalculateRates()
        CalculateMileageTotal()
        CalculateItemTotal()
        CalculateSiteTotal()
        Me.txtPricePerVisit.Text = Format(CurrentJobOfWork.PricePerVisit, "C")
        Me.txtTotalSitePrice.Text = Format(CurrentJobOfWork.TotalSitePrice, "C")

        IsLoading = False

        CurrentJobOfWork.SetPricePerVisit = Me.txtPricePerVisit.Text.Replace("£", "")
        CurrentJobOfWork.SetTotalSitePrice = Me.txtTotalSitePrice.Text.Replace("£", "")
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try

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

#End Region

End Class