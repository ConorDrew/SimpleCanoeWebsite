Public Class UCQuoteContractOption3Convert : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(Me.cboContractStatus, DynamicDataTables.ContractStatus, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)

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

    Friend WithEvents grpQuoteContractOption3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtContractPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents gpbSite As System.Windows.Forms.GroupBox
    Friend WithEvents dgSites As System.Windows.Forms.DataGrid
    Friend WithEvents txtContractReference As System.Windows.Forms.TextBox
    Friend WithEvents lblContractReference As System.Windows.Forms.Label
    Friend WithEvents grpAssets As System.Windows.Forms.GroupBox
    Friend WithEvents dgAssets As System.Windows.Forms.DataGrid
    Friend WithEvents cboContractStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblContractStatus As System.Windows.Forms.Label
    Friend WithEvents btnContractNumber As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpQuoteContractOption3 = New System.Windows.Forms.GroupBox
        Me.btnContractNumber = New System.Windows.Forms.Button
        Me.cboContractStatus = New System.Windows.Forms.ComboBox
        Me.lblContractStatus = New System.Windows.Forms.Label
        Me.grpAssets = New System.Windows.Forms.GroupBox
        Me.dgAssets = New System.Windows.Forms.DataGrid
        Me.txtContractPrice = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblMsg = New System.Windows.Forms.Label
        Me.gpbSite = New System.Windows.Forms.GroupBox
        Me.dgSites = New System.Windows.Forms.DataGrid
        Me.txtContractReference = New System.Windows.Forms.TextBox
        Me.lblContractReference = New System.Windows.Forms.Label
        Me.grpQuoteContractOption3.SuspendLayout()
        Me.grpAssets.SuspendLayout()
        CType(Me.dgAssets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbSite.SuspendLayout()
        CType(Me.dgSites, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpQuoteContractOption3
        '
        Me.grpQuoteContractOption3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpQuoteContractOption3.Controls.Add(Me.btnContractNumber)
        Me.grpQuoteContractOption3.Controls.Add(Me.cboContractStatus)
        Me.grpQuoteContractOption3.Controls.Add(Me.lblContractStatus)
        Me.grpQuoteContractOption3.Controls.Add(Me.grpAssets)
        Me.grpQuoteContractOption3.Controls.Add(Me.txtContractPrice)
        Me.grpQuoteContractOption3.Controls.Add(Me.Label1)
        Me.grpQuoteContractOption3.Controls.Add(Me.lblMsg)
        Me.grpQuoteContractOption3.Controls.Add(Me.gpbSite)
        Me.grpQuoteContractOption3.Controls.Add(Me.txtContractReference)
        Me.grpQuoteContractOption3.Controls.Add(Me.lblContractReference)
        Me.grpQuoteContractOption3.Location = New System.Drawing.Point(8, 8)
        Me.grpQuoteContractOption3.Name = "grpQuoteContractOption3"
        Me.grpQuoteContractOption3.Size = New System.Drawing.Size(906, 594)
        Me.grpQuoteContractOption3.TabIndex = 1
        Me.grpQuoteContractOption3.TabStop = False
        Me.grpQuoteContractOption3.Text = "Main Details"
        '
        'btnContractNumber
        '
        Me.btnContractNumber.UseVisualStyleBackColor = True
        Me.btnContractNumber.Location = New System.Drawing.Point(14, 55)
        Me.btnContractNumber.Name = "btnContractNumber"
        Me.btnContractNumber.Size = New System.Drawing.Size(291, 23)
        Me.btnContractNumber.TabIndex = 2
        Me.btnContractNumber.Text = "Next Suggested Contract Number"
        '
        'cboContractStatus
        '
        Me.cboContractStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboContractStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContractStatus.Location = New System.Drawing.Point(728, 25)
        Me.cboContractStatus.Name = "cboContractStatus"
        Me.cboContractStatus.Size = New System.Drawing.Size(158, 21)
        Me.cboContractStatus.TabIndex = 4
        Me.cboContractStatus.Tag = "ContractOption3.ContractStatus"
        '
        'lblContractStatus
        '
        Me.lblContractStatus.Location = New System.Drawing.Point(621, 25)
        Me.lblContractStatus.Name = "lblContractStatus"
        Me.lblContractStatus.Size = New System.Drawing.Size(99, 20)
        Me.lblContractStatus.TabIndex = 59
        Me.lblContractStatus.Text = "Contract Status"
        '
        'grpAssets
        '
        Me.grpAssets.Controls.Add(Me.dgAssets)

        Me.grpAssets.Location = New System.Drawing.Point(10, 331)
        Me.grpAssets.Name = "grpAssets"
        Me.grpAssets.Size = New System.Drawing.Size(884, 243)
        Me.grpAssets.TabIndex = 57
        Me.grpAssets.TabStop = False
        Me.grpAssets.Text = "Assets"
        '
        'dgAssets
        '
        Me.dgAssets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAssets.DataMember = ""
        Me.dgAssets.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgAssets.Location = New System.Drawing.Point(10, 21)
        Me.dgAssets.Name = "dgAssets"
        Me.dgAssets.Size = New System.Drawing.Size(865, 217)
        Me.dgAssets.TabIndex = 1
        '
        'txtContractPrice
        '
        Me.txtContractPrice.Location = New System.Drawing.Point(424, 25)
        Me.txtContractPrice.MaxLength = 100
        Me.txtContractPrice.Name = "txtContractPrice"
        Me.txtContractPrice.Size = New System.Drawing.Size(175, 21)
        Me.txtContractPrice.TabIndex = 3
        Me.txtContractPrice.Tag = "ContractOption3.ContractPrice"
        Me.txtContractPrice.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(326, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 20)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Contract Price"
        '
        'lblMsg
        '
        Me.lblMsg.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMsg.Location = New System.Drawing.Point(326, 55)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(274, 23)
        Me.lblMsg.TabIndex = 54
        Me.lblMsg.Text = "Please save before adding properties"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpbSite
        '
        Me.gpbSite.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbSite.Controls.Add(Me.dgSites)
        Me.gpbSite.Location = New System.Drawing.Point(10, 84)
        Me.gpbSite.Name = "gpbSite"
        Me.gpbSite.Size = New System.Drawing.Size(884, 239)
        Me.gpbSite.TabIndex = 53
        Me.gpbSite.TabStop = False
        Me.gpbSite.Text = "Properties - Click a site to view the related assets."
        '
        'dgSites
        '
        Me.dgSites.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSites.DataMember = ""
        Me.dgSites.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSites.Location = New System.Drawing.Point(10, 19)
        Me.dgSites.Name = "dgSites"
        Me.dgSites.Size = New System.Drawing.Size(865, 210)
        Me.dgSites.TabIndex = 0
        '
        'txtContractReference
        '
        Me.txtContractReference.Location = New System.Drawing.Point(131, 25)
        Me.txtContractReference.MaxLength = 100
        Me.txtContractReference.Name = "txtContractReference"
        Me.txtContractReference.Size = New System.Drawing.Size(175, 21)
        Me.txtContractReference.TabIndex = 1
        Me.txtContractReference.Tag = "ContractOption3.ContractReference"
        Me.txtContractReference.Text = ""
        '
        'lblContractReference
        '
        Me.lblContractReference.Location = New System.Drawing.Point(14, 25)
        Me.lblContractReference.Name = "lblContractReference"
        Me.lblContractReference.Size = New System.Drawing.Size(118, 20)
        Me.lblContractReference.TabIndex = 52
        Me.lblContractReference.Text = "Contract Reference"
        '
        'UCQuoteContractOption3Convert
        '
        Me.Controls.Add(Me.grpQuoteContractOption3)
        Me.Name = "UCQuoteContractOption3Convert"
        Me.Size = New System.Drawing.Size(921, 616)
        Me.grpQuoteContractOption3.ResumeLayout(False)
        Me.grpAssets.ResumeLayout(False)
        CType(Me.dgAssets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbSite.ResumeLayout(False)
        CType(Me.dgSites, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentQuoteContractOption3
        End Get
    End Property

#End Region

#Region "Properties"

    Private _loading As Boolean = False

    Private Property Loading() As Boolean
        Get
            Return _loading
        End Get
        Set(ByVal Value As Boolean)
            _loading = Value
        End Set
    End Property

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _currentQuoteContractOption3 As Entity.QuoteContractOption3s.QuoteContractOption3

    Public Property CurrentQuoteContractOption3() As Entity.QuoteContractOption3s.QuoteContractOption3
        Get
            Return _currentQuoteContractOption3
        End Get
        Set(ByVal Value As Entity.QuoteContractOption3s.QuoteContractOption3)
            _currentQuoteContractOption3 = Value

            If _currentQuoteContractOption3 Is Nothing Then
                _currentQuoteContractOption3 = New Entity.QuoteContractOption3s.QuoteContractOption3
                _currentQuoteContractOption3.Exists = False
            End If

            If CurrentQuoteContractOption3.Exists Then
                Loading = True
                Populate()
                gpbSite.Enabled = True
                lblMsg.Visible = False
                Loading = False
            Else
                gpbSite.Enabled = False
                lblMsg.Visible = True
                txtContractPrice.Text = Format(CDbl(0.0), "C")
            End If

            Sites = DB.QuoteContractOption3Site.QuoteContractOption3Site_GetSelected_ForQuoteContract(CurrentQuoteContractOption3.QuoteContractID)

            For Each dr As DataRow In Sites.Table.Rows
                SetAssetsDurations = DB.QuoteContractOption3SiteAssetDurations.QuoteContractOption3SiteAssetDuration_GetAll_ForQuoteContractSiteID(dr("QuoteContractSiteID"))
                SetAssets = CreateAssetDataView(dr("SiteID"), dr("QuoteContractSiteID"))
                Visits.Add(New ArrayList)
            Next dr
        End Set
    End Property

    Private _Sites As DataView

    Private Property Sites() As DataView
        Get
            Return _Sites
        End Get
        Set(ByVal Value As DataView)
            _Sites = Value
            _Sites.Table.TableName = Entity.Sys.Enums.TableNames.tblQuoteContractOption3Site.ToString
            _Sites.AllowNew = False
            _Sites.AllowEdit = True
            _Sites.AllowDelete = False
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

    Private _Assets As New ArrayList

    Private ReadOnly Property Assets() As ArrayList
        Get
            Return _Assets
        End Get
    End Property

    Private WriteOnly Property SetAssets() As Object
        Set(ByVal Value As Object)
            Value.Table.TableName = Entity.Sys.Enums.TableNames.tblAsset.ToString
            Value.AllowNew = False
            Value.AllowEdit = True
            Value.AllowDelete = False
            _Assets.Add(Value)
        End Set
    End Property

    Private _AssetsDurations As New ArrayList

    Public ReadOnly Property AssetsDurations() As ArrayList
        Get
            Return _AssetsDurations
        End Get
    End Property

    Private WriteOnly Property SetAssetsDurations() As Object
        Set(ByVal Value As Object)
            Value.Table.TableName = Entity.Sys.Enums.TableNames.tblAsset.ToString
            Value.AllowNew = False
            Value.AllowEdit = True
            Value.AllowDelete = False
            _AssetsDurations.Add(Value)
        End Set
    End Property

    Private _Visits As New ArrayList

    Private Property Visits() As ArrayList
        Get
            Return _Visits
        End Get
        Set(ByVal Value As ArrayList)
            _Visits = Value
        End Set
    End Property

#End Region

#Region "SetUp"

    Public Sub SetupSitesDataGrid()
        Entity.Sys.Helper.SetUpDataGrid(dgSites)
        Dim tStyle As DataGridTableStyle = Me.dgSites.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Me.dgSites.ReadOnly = False
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False

        'Dim Tick As New DataGridBoolColumn
        'Tick.HeaderText = ""
        'Tick.MappingName = "Tick"
        'Tick.ReadOnly = True
        'Tick.Width = 50
        'Tick.NullText = ""
        'tStyle.GridColumnStyles.Add(Tick)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Property"
        Site.MappingName = "Site"
        Site.ReadOnly = True
        Site.Width = 250
        Site.NullText = ""
        tStyle.GridColumnStyles.Add(Site)

        Dim ContractSiteReference As New DataGridLabelColumn
        ContractSiteReference.Format = ""
        ContractSiteReference.FormatInfo = Nothing
        ContractSiteReference.HeaderText = "Property Reference"
        ContractSiteReference.MappingName = "QuoteContractSiteReference"
        ContractSiteReference.ReadOnly = True
        ContractSiteReference.Width = 100
        ContractSiteReference.NullText = ""
        tStyle.GridColumnStyles.Add(ContractSiteReference)

        Dim StartDate As New DataGridEditableTextBoxColumn
        StartDate.Format = "dd/MM/yyyy"
        StartDate.FormatInfo = Nothing
        StartDate.HeaderText = "Start Date"
        StartDate.MappingName = "StartDate"
        StartDate.ReadOnly = False
        StartDate.Width = 75
        StartDate.NullText = ""
        tStyle.GridColumnStyles.Add(StartDate)

        Dim EndDate As New DataGridEditableTextBoxColumn
        EndDate.Format = "dd/MM/yyyy"
        EndDate.FormatInfo = Nothing
        EndDate.HeaderText = "End Date"
        EndDate.MappingName = "EndDate"
        EndDate.ReadOnly = False
        EndDate.Width = 75
        EndDate.NullText = ""
        tStyle.GridColumnStyles.Add(EndDate)

        Dim FirstVisitDate As New DataGridEditableTextBoxColumn
        FirstVisitDate.Format = "dd/MM/yyyy"
        FirstVisitDate.FormatInfo = Nothing
        FirstVisitDate.HeaderText = "First Visit Date"
        FirstVisitDate.MappingName = "FirstVisitDate"
        FirstVisitDate.ReadOnly = False
        FirstVisitDate.Width = 120
        FirstVisitDate.NullText = ""
        tStyle.GridColumnStyles.Add(FirstVisitDate)

        Dim VisitFrequency As New DataGridComboBoxColumn
        VisitFrequency.HeaderText = "Visit Frequency"
        VisitFrequency.MappingName = "VisitFrequencyID"
        VisitFrequency.ReadOnly = False
        VisitFrequency.Width = 100
        VisitFrequency.ComboBox.DataSource = DB.QuoteContractOption3.VisitFrequency_Get
        VisitFrequency.ComboBox.DisplayMember = "DisplayMember"
        VisitFrequency.ComboBox.ValueMember = "VisitFrequencyID"
        tStyle.GridColumnStyles.Add(VisitFrequency)

        Dim InvoiceFrequency As New DataGridComboBoxColumn
        InvoiceFrequency.HeaderText = "Invoice Frequency"
        InvoiceFrequency.MappingName = "InvoiceFrequencyID"
        InvoiceFrequency.ReadOnly = False
        InvoiceFrequency.Width = 120
        InvoiceFrequency.ComboBox.DataSource = DB.QuoteContractOption3.InvoiceFrequency_Get
        InvoiceFrequency.ComboBox.DisplayMember = "DisplayMember"
        InvoiceFrequency.ComboBox.ValueMember = "InvoiceFrequencyID"
        tStyle.GridColumnStyles.Add(InvoiceFrequency)

        tStyle.ReadOnly = False
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblQuoteContractOption3Site.ToString
        Me.dgSites.TableStyles.Add(tStyle)

    End Sub

    Public Sub SetupAssetsDataGrid(ByVal startdate As DateTime, ByVal enddate As DateTime)
        Entity.Sys.Helper.SetUpDataGrid(dgAssets)
        Dim tStyle As DataGridTableStyle = Me.dgAssets.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Me.dgAssets.ReadOnly = False
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False

        Dim Product As New DataGridLabelColumn
        Product.Format = ""
        Product.FormatInfo = Nothing
        Product.HeaderText = "Product"
        Product.MappingName = "Product"
        Product.ReadOnly = True
        Product.Width = 150
        Product.NullText = ""
        tStyle.GridColumnStyles.Add(Product)

        Dim Location As New DataGridLabelColumn
        Location.Format = ""
        Location.FormatInfo = Nothing
        Location.HeaderText = "Location"
        Location.MappingName = "Location"
        Location.ReadOnly = True
        Location.Width = 90
        Location.NullText = ""
        tStyle.GridColumnStyles.Add(Location)

        Dim SerialNum As New DataGridLabelColumn
        SerialNum.Format = ""
        SerialNum.FormatInfo = Nothing
        SerialNum.HeaderText = "Serial Number"
        SerialNum.MappingName = "SerialNum"
        SerialNum.ReadOnly = True
        SerialNum.Width = 90
        SerialNum.NullText = ""
        tStyle.GridColumnStyles.Add(SerialNum)

        Dim numOfMonths As Integer = 0
        numOfMonths = Math.Ceiling(DateDiff(DateInterval.Month, startdate, enddate))

        For i As Integer = 0 To numOfMonths
            Dim dglc As New Contract3AssetsColourColumnConvert
            dglc.theUserControl = Me
            dglc.HeaderText = Format(startdate.AddMonths(i), "MMM yy")
            dglc.MappingName = Format(startdate.AddMonths(i), "MMM yy")
            dglc.ReadOnly = False
            dglc.Width = 50
            dglc.NullText = "-"
            tStyle.GridColumnStyles.Add(dglc)
        Next

        tStyle.ReadOnly = False
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblAsset.ToString
        Me.dgAssets.TableStyles.Add(tStyle)

    End Sub

#End Region

#Region "Events"

    Private Sub UCQuoteContractOption3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
        SetupSitesDataGrid()
    End Sub

    Private Sub txtQuoteContractPrice_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContractPrice.LostFocus
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

    Private Sub dgSites_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSites.CurrentCellChanged, dgSites.Click
        If Not SelectedSiteDataRow Is Nothing Then
            grpAssets.Text = "Assets for " & SelectedSiteDataRow("Site")

            If IsDBNull(SelectedSiteDataRow("StartDate")) = False And
                        IsDBNull(SelectedSiteDataRow("EndDate")) = False Then
                Assets.Item(dgSites.CurrentRowIndex) = CreateAssetDataView(SelectedSiteDataRow("SiteID"), SelectedSiteDataRow("QuoteContractSiteID"))
                dgAssets.DataSource = Assets.Item(dgSites.CurrentRowIndex)
            Else
                dgAssets.DataSource = Nothing
            End If

        End If
    End Sub

    Private Sub btnContractNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContractNumber.Click
        ShowForm(GetType(FRMAvailableContractNos), True, New Object() {Me.txtContractReference, Me})
    End Sub

#End Region

#Region "Functions"

    Public Sub UpdateDurations(ByVal Duration As Double, ByVal mappingName As DateTime)
        Dim found As Boolean = False
        Dim dv As DataView = CType(AssetsDurations(dgSites.CurrentRowIndex), DataView)

        For Each dr As DataRow In dv.Table.Rows

            If dr("CompareMonth") = Format(mappingName, "yyyyMM") And
                dr("AssetID") = CType(dgAssets.DataSource, DataView).Table.Rows(dgAssets.CurrentRowIndex).Item("AssetID") Then
                dr("visitDuration") = Duration
                found = True
                Exit For
            End If
        Next dr

        If found = False Then
            Dim newDr As DataRow
            newDr = dv.Table.NewRow
            newDr("CompareMonth") = Format(mappingName, "yyyyMM")
            newDr("AssetID") = CType(dgAssets.DataSource, DataView).Table.Rows(dgAssets.CurrentRowIndex).Item("AssetID")
            newDr("visitDuration") = Duration
            newDr("ScheduledMonth") = mappingName

            dv.Table.Rows.Add(newDr)
        End If
        AssetsDurations(dgSites.CurrentRowIndex) = dv

    End Sub

    Private Function CreateAssetDataView(ByVal siteID As Integer,
                                        ByVal quoteContractSiteID As Integer) As DataView

        Dim estVisitDate As DateTime = Nothing
        Dim numOfVisits As Integer = 0
        Dim visitFreqInMonths As Integer = 0
        Dim numOfMonths As Integer = 0
        Dim assetsDV As New DataView

        assetsDV = DB.Asset.Asset_GetForSite(siteID)

        numOfMonths = Math.Ceiling(DateDiff(DateInterval.Month, SelectedSiteDataRow("StartDate"), SelectedSiteDataRow("EndDate")))

        Dim newVisits As New ArrayList

        For i As Integer = 0 To numOfMonths
            assetsDV.Table.Columns.Add(Format(SelectedSiteDataRow("StartDate").AddMonths(i), "MMM yy"))
        Next

        If SelectedSiteDataRow("VisitFrequencyID") > 0 Then
            If SelectedSiteDataRow("FirstVisitDate").Date >= SelectedSiteDataRow("StartDate").Date And
                    SelectedSiteDataRow("FirstVisitDate").Date <= SelectedSiteDataRow("EndDate").Date Then

                numOfVisits = 0
                visitFreqInMonths = 0
                Select Case CType(SelectedSiteDataRow("VisitFrequencyID"), Entity.Sys.Enums.VisitFrequency)
                    Case Entity.Sys.Enums.VisitFrequency.Annually
                        visitFreqInMonths = 12
                    Case Entity.Sys.Enums.VisitFrequency.Bi_Annually
                        visitFreqInMonths = 6
                    Case Entity.Sys.Enums.VisitFrequency.Monthly
                        visitFreqInMonths = 1
                    Case Entity.Sys.Enums.VisitFrequency.Quarterly
                        visitFreqInMonths = 3
                End Select

                numOfVisits = Math.Ceiling(DateDiff(DateInterval.Month, SelectedSiteDataRow("StartDate"), SelectedSiteDataRow("EndDate")) / visitFreqInMonths)
                If numOfVisits = 0 Then
                    numOfVisits = 1
                End If
                estVisitDate = SelectedSiteDataRow("FirstVisitDate").Date & " 09:00:00"

                For i As Integer = 1 To numOfVisits

                    If estVisitDate >= CDate(Format(SelectedSiteDataRow("StartDate").Date, "dd/MM/yyyy") & " 09:00") _
                            And estVisitDate <= CDate(Format(SelectedSiteDataRow("EndDate").Date, "dd/MM/yyyy") & " 09:00") Then

                        'I WANT TO STORE THE DATE IT SHOULD HAVE BEEN SO THE DATES AT THE START OF THE MONTH DON@T CREEP UP FOR EAXMPLE - ALP
                        Dim shouldHaveBeenDate As DateTime = estVisitDate
                        'MAKE SURE WE DON'T BOOK A SATURADY OR SUNDAY
                        If estVisitDate.DayOfWeek = DayOfWeek.Saturday Then
                            estVisitDate = estVisitDate.AddDays(2)
                        ElseIf estVisitDate.DayOfWeek = DayOfWeek.Sunday Then
                            estVisitDate = estVisitDate.AddDays(1)
                        End If

                        For Each drAsset As DataRow In assetsDV.Table.Rows
                            Dim rVal As DataRow()
                            rVal = CType(AssetsDurations.Item(dgSites.CurrentRowIndex), DataView).Table.Select("CompareMonth=" & Format(estVisitDate, "yyyyMM") &
                                                                " AND AssetID=" & drAsset("AssetID"))
                            If rVal.Length > 0 Then
                                drAsset(Format(estVisitDate, "MMM yy")) = rVal(0).Item("VisitDuration")
                            Else
                                drAsset(Format(estVisitDate, "MMM yy")) = "0"
                            End If

                        Next drAsset

                        newVisits.Add(estVisitDate)
                        estVisitDate = shouldHaveBeenDate.AddMonths(visitFreqInMonths)
                    End If
                Next i
            Else

            End If
        End If
        If Visits.Count > 0 Then
            Visits.Item(dgSites.CurrentRowIndex) = newVisits
        End If

        SetupAssetsDataGrid(SelectedSiteDataRow("StartDate"), SelectedSiteDataRow("EndDate"))

        Me.Cursor = Cursors.Default
        assetsDV.AllowDelete = False
        assetsDV.AllowEdit = True
        assetsDV.AllowNew = False
        Return assetsDV
    End Function

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        If Not ID = 0 Then
            CurrentQuoteContractOption3 = DB.QuoteContractOption3.QuoteContractOption3_Get(ID)
        End If

        Me.txtContractReference.Text = CurrentQuoteContractOption3.QuoteContractReference
        Me.txtContractPrice.Text = Format(CurrentQuoteContractOption3.QuoteContractPrice, "C")
        Combo.SetSelectedComboItem_By_Value(Me.cboContractStatus, Entity.Sys.Enums.ContractStatus.Active)

    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor

            'CREATE A NEW CONTRACT
            Dim newContract As New Entity.ContractOption3s.ContractOption3
            newContract.SetContractPrice = Me.txtContractPrice.Text.Trim.Replace("£", "")
            newContract.SetContractReference = Me.txtContractReference.Text
            newContract.SetContractStatusID = Combo.GetSelectedItemValue(cboContractStatus)
            newContract.SetCustomerID = CurrentQuoteContractOption3.CustomerID
            newContract.SetQuoteContractID = CurrentQuoteContractOption3.QuoteContractID

            'VALIDATE THE CONTRACT
            Dim conVal As New Entity.ContractOption3s.ContractOption3Validator
            conVal.Validate(newContract)

            'VALIDATE THE SITES
            Dim sitVal As New Entity.ContractOption3Sites.ContractOption3SiteValidator
            Dim cnt As Integer = 0
            For Each drSite As DataRow In Sites.Table.Rows
                Dim valSite As New Entity.ContractOption3Sites.ContractOption3Site
                valSite.SetContractSiteReference = drSite("QuoteContractSiteReference")
                valSite.SetInvoiceFrequencyID = drSite("InvoiceFrequencyID")
                valSite.SetPropertyID = drSite("SiteID")
                valSite.SetSitePrice = drSite("SitePrice")
                valSite.SetVisitFrequencyID = drSite("VisitFrequencyID")
                valSite.StartDate = drSite("StartDate")
                valSite.EndDate = drSite("EndDate")
                valSite.FirstVisitDate = drSite("FirstVisitDate")
                valSite.FirstInvoiceDate = drSite("FirstVisitDate")
                valSite.SetInvoiceAddressID = drSite("SiteID")
                valSite.SetInvoiceAddressTypeID = CInt(Entity.Sys.Enums.InvoiceAddressType.Site)

                sitVal.Validate(valSite, Assets(cnt))
                cnt += 1
            Next drSite

            'INSERT CONTRACT
            newContract = DB.ContractOption3.Insert(newContract)

            'SET SITE with CONTRACT IDs
            cnt = 0
            For Each drSite As DataRow In Sites.Table.Rows
                Dim newSite As New Entity.ContractOption3Sites.ContractOption3Site
                newSite.SetContractSiteReference = drSite("QuoteContractSiteReference")
                newSite.SetInvoiceFrequencyID = drSite("InvoiceFrequencyID")
                newSite.SetPropertyID = drSite("SiteID")
                newSite.SetSitePrice = drSite("SitePrice")
                newSite.SetVisitFrequencyID = drSite("VisitFrequencyID")
                newSite.StartDate = drSite("StartDate")
                newSite.EndDate = drSite("EndDate")
                newSite.FirstVisitDate = drSite("FirstVisitDate")
                newSite.SetContractID = newContract.ContractID
                newSite.FirstInvoiceDate = drSite("FirstVisitDate")
                newSite.SetInvoiceAddressID = drSite("SiteID")
                newSite.SetInvoiceAddressTypeID = CInt(Entity.Sys.Enums.InvoiceAddressType.Site)
                'INSERT SITES - Setting assets
                newSite = DB.ContractOption3Site.Insert(newSite)
                InsertInvoiceToBeRaiseLines(newSite)

                DB.ContractOption3SiteAsset.ContractOption3SiteAssetDuration_Delete(newSite.ContractSiteID)

                For Each vDate As Object In Visits.Item(cnt) ' For each Visit

                    Dim oJob As New Entity.Jobs.Job
                    oJob = CreateJob(vDate, newSite, cnt, newContract)

                    'CREATE PPM VISIT RECORD
                    Dim PPM As New Entity.ContractOption3SitePPMVisits.ContractOption3SitePPMVisit
                    PPM.SetContractSiteID = newSite.ContractSiteID
                    PPM.VisitDate = vDate
                    PPM.SetJobID = oJob.JobID
                    DB.ContractOption3SitePPMVisit.Insert(PPM)

                Next vDate

                cnt += 1
            Next drSite

            RaiseEvent StateChanged(CurrentQuoteContractOption3.QuoteContractID)

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

    Private Sub InsertInvoiceToBeRaiseLines(ByVal CurrentContractOption3Site As Entity.ContractOption3Sites.ContractOption3Site)
        Dim numberOfInvoicesToRaise As Integer = 0

        Select Case CType(CurrentContractOption3Site.InvoiceFrequencyID, Entity.Sys.Enums.InvoiceFrequency)
            Case Entity.Sys.Enums.InvoiceFrequency.Annually
                numberOfInvoicesToRaise = DateDiff(DateInterval.Year, CurrentContractOption3Site.StartDate, CurrentContractOption3Site.EndDate)
            Case Entity.Sys.Enums.InvoiceFrequency.Bi_Annually
                numberOfInvoicesToRaise = (DateDiff(DateInterval.Year, CurrentContractOption3Site.StartDate, CurrentContractOption3Site.EndDate)) * 2
            Case Entity.Sys.Enums.InvoiceFrequency.Monthly
                numberOfInvoicesToRaise = DateDiff(DateInterval.Month, CurrentContractOption3Site.StartDate, CurrentContractOption3Site.EndDate)
            Case Entity.Sys.Enums.InvoiceFrequency.Per_Visit
                'Invoice the visit
            Case Entity.Sys.Enums.InvoiceFrequency.Quarterly
                numberOfInvoicesToRaise = DateDiff(DateInterval.Month, CurrentContractOption3Site.StartDate, CurrentContractOption3Site.EndDate) / 3
            Case Entity.Sys.Enums.InvoiceFrequency.Weekly
                numberOfInvoicesToRaise = DateDiff(DateInterval.Day, CurrentContractOption3Site.StartDate, CurrentContractOption3Site.EndDate) / 7
        End Select
        Dim raiseDate As DateTime = CurrentContractOption3Site.FirstInvoiceDate
        For i As Integer = 1 To numberOfInvoicesToRaise
            Dim invToBeRaised As New Entity.InvoiceToBeRaiseds.InvoiceToBeRaised
            invToBeRaised.SetAddressLinkID = CurrentContractOption3Site.InvoiceAddressID
            invToBeRaised.SetAddressTypeID = CurrentContractOption3Site.InvoiceAddressTypeID
            invToBeRaised.SetInvoiceTypeID = CInt(Entity.Sys.Enums.InvoiceType.Contract_Option3)
            invToBeRaised.SetLinkID = CurrentContractOption3Site.ContractSiteID
            invToBeRaised.RaiseDate = raiseDate
            DB.InvoiceToBeRaised.Insert(invToBeRaised)

            Select Case CType(CurrentContractOption3Site.InvoiceFrequencyID, Entity.Sys.Enums.InvoiceFrequency)
                Case Entity.Sys.Enums.InvoiceFrequency.Annually
                    raiseDate = raiseDate.AddYears(1)
                Case Entity.Sys.Enums.InvoiceFrequency.Bi_Annually
                    raiseDate = raiseDate.AddMonths(6)
                Case Entity.Sys.Enums.InvoiceFrequency.Monthly
                    raiseDate = raiseDate.AddMonths(1)
                Case Entity.Sys.Enums.InvoiceFrequency.Quarterly
                    raiseDate = raiseDate.AddMonths(3)
                Case Entity.Sys.Enums.InvoiceFrequency.Weekly
                    raiseDate = raiseDate.AddDays(7)
            End Select
        Next

    End Sub

    Private Function CreateJob(ByVal vDate As DateTime,
                                ByVal newSite As Entity.ContractOption3Sites.ContractOption3Site,
                                         ByVal currentSiteRow As Integer,
                                        ByVal curContract As Entity.ContractOption3s.ContractOption3) As Entity.Jobs.Job

        Dim durationTotal As Double = 0
        Dim slotDuration As Double = 0
        Dim numOfSlotsNeeded As Integer = 0
        Dim dayStartDate As DateTime = Nothing
        Dim dayEndDate As DateTime = Nothing
        Dim workingDayMinutes As Double = 0
        Dim workingDaySlots As Integer = 0
        Dim numOfDaysNeeded As Integer = 0
        Dim numOfMintuesNeeded As Integer = 0

        'CREATE new Job
        Dim oJob As New Entity.Jobs.Job
        oJob.SetContractID = newSite.ContractID
        oJob.SetCreatedByUserID = loggedInUser.UserID
        oJob.SetJobDefinitionEnumID = Entity.Sys.Helper.MakeIntegerValid(Entity.Sys.Enums.JobDefinition.Contract)
        Dim JobNumber As New JobNumber
        JobNumber = DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.Contract)
        oJob.SetJobNumber = JobNumber.Prefix & JobNumber.JobNumber
        oJob.SetPONumber = ""
        oJob.SetQuoteID = 0
        oJob.SetPropertyID = newSite.PropertyID
        oJob.SetStatusEnumID = Entity.Sys.Helper.MakeIntegerValid(Entity.Sys.Enums.JobStatus.Open)
        oJob.DateCreated = Now

        ' IF CONTRACT IS NOT ACTIVE, FLAG JOB AS DELETED
        If CType(curContract.ContractStatusID, Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Inactive Then
            oJob.SetDeleted = True
        End If

        'FOR EACH ASSET FOR THE VISIT DATE
        For Each rAsset As DataRow In CType(Assets(currentSiteRow), DataView).Table.Rows
            'IF DURATION > 0 THEN SAVE DURATION
            If rAsset(Format(vDate, "MMM yy")) > 0 Then
                Dim assetDuration As New Entity.ContractOption3SiteAsset.ContractOption3SiteAsset
                assetDuration.SetContractSiteID = newSite.ContractSiteID
                assetDuration.SetAssetID = rAsset("AssetID")
                assetDuration.ScheduledMonth = vDate
                assetDuration.SetVisitDuration = rAsset(Format(vDate, "MMM yy"))
                DB.ContractOption3SiteAsset.Insert(assetDuration)

                'ADD TO JOB ASSETS
                Dim jobAsset As New Entity.JobAssets.JobAsset
                jobAsset.SetAssetID = rAsset("AssetID")
                oJob.Assets.Add(jobAsset)

                'SUM UP DURATION
                durationTotal += Entity.Sys.Helper.MakeDoubleValid(rAsset(Format(vDate, "MMM yy")))
            End If
        Next

        '  CREATE JOB OF WORK
        Dim ojobOfWork As New Entity.JobOfWorks.JobOfWork
        ojobOfWork.IgnoreExceptionsOnSetMethods = True

        ' IF CONTRACT IS NOT ACTIVE, FLAG JOB AS DELETED
        If CType(curContract.ContractStatusID, Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Inactive Then
            ojobOfWork.SetDeleted = True
        End If

        'CREATE JOB ITEM - just on for default
        Dim ojobItem As New Entity.JobItems.JobItem
        ojobItem.IgnoreExceptionsOnSetMethods = True
        ojobItem.SetSummary = Entity.Sys.Helper.MakeStringValid("PPM Contract Visit")
        ojobOfWork.JobItems.Add(ojobItem)

        'SYSTEM NUMBER OF MINUTES IN A SLOTS
        Dim settings As New Entity.Management.Settings
        settings = DB.Manager.Get
        slotDuration = settings.TimeSlot

        'NUM OF SLOTS NEEDED FOR VISIT
        If durationTotal > 0 Then
            numOfMintuesNeeded = durationTotal * 60
            numOfSlotsNeeded = numOfMintuesNeeded / slotDuration
        Else
            numOfSlotsNeeded = 1
        End If

        'NEED SEE IF TOTAL DURATION IS GREATER THAN WORKING DAY
        dayStartDate = Entity.Sys.Helper.MakeDateTimeValid("01/01/1900 " & settings.WorkingHoursStart)
        dayEndDate = Entity.Sys.Helper.MakeDateTimeValid("01/01/1900 " & settings.WorkingHoursEnd)
        'NUMBER OF SLOTS IN A DAY
        workingDayMinutes = DateDiff(DateInterval.Minute, dayStartDate, dayEndDate)
        workingDaySlots = workingDayMinutes / slotDuration

        numOfDaysNeeded = Math.Ceiling(numOfSlotsNeeded / workingDaySlots)

        Dim matches As New ArrayList 'Arraylist of arraylists
        'FIND A SUITABLE ENGINEER FIRST
        matches = GetEngineersAndVisits(numOfDaysNeeded, workingDaySlots, vDate, newSite)

        For i As Integer = 0 To numOfDaysNeeded - 1
            Dim oEngVisit As New Entity.EngineerVisits.EngineerVisit
            oEngVisit.IgnoreExceptionsOnSetMethods = True
            Try
                oEngVisit.SetEngineerID = Entity.Sys.Helper.MakeIntegerValid(CType(matches.Item(i), ArrayList).Item(1))
            Catch ex As Exception
                oEngVisit.SetEngineerID = 0
            End Try
            oEngVisit.SetNotesToEngineer = "PPM Contract Visit"

            If oEngVisit.EngineerID > 0 Then

                oEngVisit.StartDateTime = CType(matches.Item(i), ArrayList).Item(0)
                If numOfMintuesNeeded > workingDayMinutes Then
                    oEngVisit.EndDateTime = CType(matches.Item(i), ArrayList).Item(0).AddHours(Math.Ceiling(workingDayMinutes / 60))
                    numOfMintuesNeeded -= workingDayMinutes
                Else
                    oEngVisit.EndDateTime = CType(matches.Item(i), ArrayList).Item(0).AddHours(Math.Ceiling(numOfMintuesNeeded / 60))
                End If
                oEngVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Scheduled)
            Else
                oEngVisit.StartDateTime = DateTime.MinValue
                oEngVisit.EndDateTime = DateTime.MinValue
                oEngVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule)
            End If

            ojobOfWork.EngineerVisits.Add(oEngVisit)
        Next i

        'ADD JOB OF WORK TO JOB
        oJob.JobOfWorks.Add(ojobOfWork)
        'INSERT JOB
        oJob = DB.Job.Insert(oJob)

        Return oJob
    End Function

    Private Function GetEngineersAndVisits(ByVal numOfDaysNeeded As Integer,
                                            ByVal numOfSlotsInADay As Integer,
                                               ByVal estVisitDate As DateTime,
                                                ByVal newSite As Entity.ContractOption3Sites.ContractOption3Site) As ArrayList
        Dim site As New Entity.Sites.Site
        Dim matches As New ArrayList
        Dim postcode As String = ""
        Dim postcodeEngineers As DataView = Nothing
        Dim cntPostcodeEng As Integer = 0
        Dim randomNum As Integer = 0

        'SEE IF THE SITE HAS A DEFAULT ENGINEER
        site = DB.Sites.Get(newSite.PropertyID)

        If site.EngineerID > 0 Then
            'IF THE SITE DOES, ARE THEY AVAILABLE ON THE DAY OR FOLLOWING 4 DAYS ( NOT WEEKENDS)
            matches = CheckAvailability(estVisitDate, site.EngineerID, numOfDaysNeeded, numOfSlotsInADay)
        End If
        'IF A ENG & SLOT IS FOUND, RETURN
        If matches.Count > 0 Then
            Return matches
        End If

        'NO MATCH FOUND FOR SITE ENGINEER
        'IS THERE A MATCH FOR POSTCODE ENGINEERS
        postcode = site.Postcode.Replace("-", "")
        postcode = postcode.Replace(" ", "")
        postcode = postcode.Substring(0, postcode.Length - 3)

        'GET ALL THE ENGINEERS THAT COVER THAT POSTCODE
        postcodeEngineers = DB.EngineerPostalRegion.EngineerPostalRegion_Get_For_Postcode(postcode)
        cntPostcodeEng = postcodeEngineers.Table.Rows.Count

        If cntPostcodeEng > 0 Then
            For i As Integer = 0 To cntPostcodeEng - 1
                Randomize()
                randomNum = CInt(Int((postcodeEngineers.Table.Rows.Count * Rnd()) + 1)) - 1

                matches = CheckAvailability(estVisitDate, postcodeEngineers.Table.Rows(randomNum).Item("EngineerID"), numOfDaysNeeded, numOfSlotsInADay)

                'IF A ENG & SLOT IS FOUND, RETURN
                If matches.Count > 0 Then
                    Return matches
                Else
                    postcodeEngineers.Table.Rows.Remove(postcodeEngineers.Table.Rows(randomNum))
                End If

            Next i
        End If
        Return matches
    End Function

    Private Function CheckAvailability(ByVal estimatedVisitDate As DateTime,
                                        ByVal engineerID As Integer,
                                        ByVal numOfDaysNeeded As Integer,
                                        ByVal numOfSlotsInADay As Integer) As ArrayList

        Dim engTimeSlots As DataTable
        Dim numOfSlotsAvailable As New ArrayList
        Dim actualVisitDate As DateTime = estimatedVisitDate
        Dim matches As New ArrayList
        Dim startSlotTime As String = ""
        Dim matchcount As Integer = 0

        For day As Integer = 0 To 4 ' SEARCHES OVER NEXT 5 WORKING DAYS
            matches.Clear()
            matchcount = 0
            'ADD ON DAYS - UNLESS FIRST TIME IN
            If day <> 0 Then
                actualVisitDate = estimatedVisitDate.AddDays(1)
            End If

            For i As Integer = 1 To numOfDaysNeeded ' SEARCHES 1st VISIT AND ALL SUSEQUNCE DAYS
                numOfSlotsAvailable.Clear()

                'ADD ON DAYS - UNLESS FIRST TIME IN
                If i <> 1 Then
                    actualVisitDate = actualVisitDate.AddDays(1)
                End If

                'MAKE IT NOT SAT
                If actualVisitDate.DayOfWeek = DayOfWeek.Saturday Then
                    actualVisitDate = actualVisitDate.AddDays(2)
                End If
                'MAKE IT NOT SUN
                If actualVisitDate.DayOfWeek = DayOfWeek.Saturday Then
                    actualVisitDate = actualVisitDate.AddDays(1)
                End If

                'GET SLOTS USED
                engTimeSlots = DB.Scheduler.Scheduler_DayTimeSlots(actualVisitDate, engineerID)
                'SLOTS ARE DISPLAY AS COLUMNS IN THIS TABLE THAT WHY WE LOOP THROUGH COLUMNS INSTEAD OF ROWS
                If engTimeSlots.Rows.Count > 0 Then
                    For colCnt As Integer = 0 To engTimeSlots.Columns.Count - 1
                        'LOOP THOROUGH EACH COLUMNS TRYING TO FIND AVAILABLE CONSECTUTIVE COLUMNS
                        'EQUAL TO THE NUMBER OF REQUIRED SLOTS
                        If engTimeSlots.Rows(0).Item(colCnt) = 0 Then
                            numOfSlotsAvailable.Add(engTimeSlots.Columns(colCnt).ColumnName)
                            If numOfSlotsAvailable.Count = numOfSlotsInADay Then
                                Exit For
                            End If
                        Else
                            'NOTHING AVAIALABLE
                            numOfSlotsAvailable.Clear()
                        End If
                    Next
                Else
                    'IF NO ROW THEN NOTHING USED FOR THAT DAY SO VISIT CAN GO AT THE BEGINNING
                    numOfSlotsAvailable.Add(DB.Manager.Get.WorkingHoursStart())
                End If

                If numOfSlotsAvailable.Count > 0 Then
                    Dim match As New ArrayList

                    If numOfSlotsAvailable.Count = numOfSlotsInADay _
                        Or (numOfSlotsAvailable(0) = DB.Manager.Get.WorkingHoursStart() And
                                                        numOfSlotsAvailable.Count = 1) Then

                        'IF THERE ARE ENOUGH AVAILABLE CONSECTUTIVE SLOTS ADD THE START TIME ONTO THE DATE

                        If numOfSlotsAvailable(0) = DB.Manager.Get.WorkingHoursStart() Then
                            startSlotTime = numOfSlotsAvailable(0)
                        Else
                            startSlotTime = Replace(numOfSlotsAvailable(0), "T", "").Insert(2, ":")
                        End If
                        actualVisitDate = CDate(Format(actualVisitDate, "dd/MM/yyyy") & " " & startSlotTime)

                        match.Add(actualVisitDate)
                        match.Add(engineerID)
                        matches.Add(match)
                        matchcount += 1
                    Else
                        match.Add(Nothing)
                        match.Add(0)
                        matches.Add(match)
                    End If

                End If
                If matchcount <> i Then
                    Exit For
                End If
            Next i
            If matchcount = numOfDaysNeeded Then
                Return (matches)
            End If
        Next day

        Return (matches)

    End Function

#End Region

End Class