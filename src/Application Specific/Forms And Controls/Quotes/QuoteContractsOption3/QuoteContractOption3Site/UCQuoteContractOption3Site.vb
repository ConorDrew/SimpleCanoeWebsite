Public Class UCQuoteContractOption3Site : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(Me.cboVisitFrequencyID, DynamicDataTables.VisitFrequencyNoWeekly, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)

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

    Friend WithEvents grpContractOption3Site As System.Windows.Forms.GroupBox
    Friend WithEvents lblSiteID As System.Windows.Forms.Label
    Friend WithEvents txtContractSiteReference As System.Windows.Forms.TextBox
    Friend WithEvents lblContractSiteReference As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpFirstVisitDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFirstVisitDate As System.Windows.Forms.Label
    Friend WithEvents cboVisitFrequencyID As System.Windows.Forms.ComboBox
    Friend WithEvents lblVisitFrequencyID As System.Windows.Forms.Label
    Friend WithEvents txtSitePrice As System.Windows.Forms.TextBox
    Friend WithEvents lblSitePrice As System.Windows.Forms.Label
    Friend WithEvents txtSite As System.Windows.Forms.TextBox
    Friend WithEvents gpbAssets As System.Windows.Forms.GroupBox
    Friend WithEvents dgAssets As System.Windows.Forms.DataGrid
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    Friend WithEvents btnRefreshGrid As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpContractOption3Site = New System.Windows.Forms.GroupBox
        Me.btnRefreshGrid = New System.Windows.Forms.Button
        Me.lblWarning = New System.Windows.Forms.Label
        Me.gpbAssets = New System.Windows.Forms.GroupBox
        Me.dgAssets = New System.Windows.Forms.DataGrid
        Me.txtSite = New System.Windows.Forms.TextBox
        Me.lblSiteID = New System.Windows.Forms.Label
        Me.txtContractSiteReference = New System.Windows.Forms.TextBox
        Me.lblContractSiteReference = New System.Windows.Forms.Label
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker
        Me.lblStartDate = New System.Windows.Forms.Label
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.lblEndDate = New System.Windows.Forms.Label
        Me.dtpFirstVisitDate = New System.Windows.Forms.DateTimePicker
        Me.lblFirstVisitDate = New System.Windows.Forms.Label
        Me.cboVisitFrequencyID = New System.Windows.Forms.ComboBox
        Me.lblVisitFrequencyID = New System.Windows.Forms.Label
        Me.txtSitePrice = New System.Windows.Forms.TextBox
        Me.lblSitePrice = New System.Windows.Forms.Label
        Me.grpContractOption3Site.SuspendLayout()
        Me.gpbAssets.SuspendLayout()
        CType(Me.dgAssets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpContractOption3Site
        '
        Me.grpContractOption3Site.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpContractOption3Site.Controls.Add(Me.btnRefreshGrid)
        Me.grpContractOption3Site.Controls.Add(Me.lblWarning)
        Me.grpContractOption3Site.Controls.Add(Me.gpbAssets)
        Me.grpContractOption3Site.Controls.Add(Me.txtSite)
        Me.grpContractOption3Site.Controls.Add(Me.lblSiteID)
        Me.grpContractOption3Site.Controls.Add(Me.txtContractSiteReference)
        Me.grpContractOption3Site.Controls.Add(Me.lblContractSiteReference)
        Me.grpContractOption3Site.Controls.Add(Me.dtpStartDate)
        Me.grpContractOption3Site.Controls.Add(Me.lblStartDate)
        Me.grpContractOption3Site.Controls.Add(Me.dtpEndDate)
        Me.grpContractOption3Site.Controls.Add(Me.lblEndDate)
        Me.grpContractOption3Site.Controls.Add(Me.dtpFirstVisitDate)
        Me.grpContractOption3Site.Controls.Add(Me.lblFirstVisitDate)
        Me.grpContractOption3Site.Controls.Add(Me.cboVisitFrequencyID)
        Me.grpContractOption3Site.Controls.Add(Me.lblVisitFrequencyID)
        Me.grpContractOption3Site.Controls.Add(Me.txtSitePrice)
        Me.grpContractOption3Site.Controls.Add(Me.lblSitePrice)
        Me.grpContractOption3Site.Location = New System.Drawing.Point(8, 8)
        Me.grpContractOption3Site.Name = "grpContractOption3Site"
        Me.grpContractOption3Site.Size = New System.Drawing.Size(979, 594)
        Me.grpContractOption3Site.TabIndex = 1
        Me.grpContractOption3Site.TabStop = False
        Me.grpContractOption3Site.Text = "Main Details"
        '
        'btnRefreshGrid
        '
        Me.btnRefreshGrid.UseVisualStyleBackColor = True
        Me.btnRefreshGrid.Location = New System.Drawing.Point(500, 122)
        Me.btnRefreshGrid.Name = "btnRefreshGrid"
        Me.btnRefreshGrid.Size = New System.Drawing.Size(200, 23)
        Me.btnRefreshGrid.TabIndex = 8
        Me.btnRefreshGrid.Text = "Load Assets Scheduled"
        '
        'lblWarning
        '
        Me.lblWarning.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarning.ForeColor = System.Drawing.Color.Red
        Me.lblWarning.Location = New System.Drawing.Point(704, 71)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(268, 23)
        Me.lblWarning.TabIndex = 34
        Me.lblWarning.Text = "! Date must be between Start &&End Date"
        Me.lblWarning.Visible = False
        '
        'gpbAssets
        '
        Me.gpbAssets.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbAssets.Controls.Add(Me.dgAssets)
        Me.gpbAssets.Location = New System.Drawing.Point(9, 153)
        Me.gpbAssets.Name = "gpbAssets"
        Me.gpbAssets.Size = New System.Drawing.Size(963, 434)
        Me.gpbAssets.TabIndex = 9
        Me.gpbAssets.TabStop = False
        Me.gpbAssets.Text = "Assets - Enter duration in hours for each month"
        '
        'dgAssets
        '
        Me.dgAssets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAssets.DataMember = ""
        Me.dgAssets.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgAssets.Location = New System.Drawing.Point(10, 26)
        Me.dgAssets.Name = "dgAssets"
        Me.dgAssets.Size = New System.Drawing.Size(942, 400)
        Me.dgAssets.TabIndex = 0
        '
        'txtSite
        '
        Me.txtSite.Location = New System.Drawing.Point(151, 25)
        Me.txtSite.Multiline = True
        Me.txtSite.Name = "txtSite"
        Me.txtSite.ReadOnly = True
        Me.txtSite.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSite.Size = New System.Drawing.Size(200, 77)
        Me.txtSite.TabIndex = 0
        Me.txtSite.Text = ""
        '
        'lblSiteID
        '
        Me.lblSiteID.Location = New System.Drawing.Point(9, 25)
        Me.lblSiteID.Name = "lblSiteID"
        Me.lblSiteID.Size = New System.Drawing.Size(139, 20)
        Me.lblSiteID.TabIndex = 31
        Me.lblSiteID.Text = "Property"
        '
        'txtContractSiteReference
        '
        Me.txtContractSiteReference.Location = New System.Drawing.Point(151, 104)
        Me.txtContractSiteReference.MaxLength = 100
        Me.txtContractSiteReference.Name = "txtContractSiteReference"
        Me.txtContractSiteReference.ReadOnly = True
        Me.txtContractSiteReference.Size = New System.Drawing.Size(200, 21)
        Me.txtContractSiteReference.TabIndex = 1
        Me.txtContractSiteReference.Tag = "ContractOption3Site.ContractSiteReference"
        Me.txtContractSiteReference.Text = ""
        '
        'lblContractSiteReference
        '
        Me.lblContractSiteReference.Location = New System.Drawing.Point(10, 104)
        Me.lblContractSiteReference.Name = "lblContractSiteReference"
        Me.lblContractSiteReference.Size = New System.Drawing.Size(139, 20)
        Me.lblContractSiteReference.TabIndex = 31
        Me.lblContractSiteReference.Text = "Quote Property Reference"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(500, 25)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.TabIndex = 4
        Me.dtpStartDate.Tag = "ContractOption3Site.StartDate"
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(366, 25)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(123, 20)
        Me.lblStartDate.TabIndex = 31
        Me.lblStartDate.Text = "Start Date"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(500, 49)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.TabIndex = 5
        Me.dtpEndDate.Tag = "ContractOption3Site.EndDate"
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(366, 49)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(123, 20)
        Me.lblEndDate.TabIndex = 31
        Me.lblEndDate.Text = "End Date"
        '
        'dtpFirstVisitDate
        '
        Me.dtpFirstVisitDate.Location = New System.Drawing.Point(500, 72)
        Me.dtpFirstVisitDate.Name = "dtpFirstVisitDate"
        Me.dtpFirstVisitDate.TabIndex = 6
        Me.dtpFirstVisitDate.Tag = "ContractOption3Site.FirstVisitDate"
        '
        'lblFirstVisitDate
        '
        Me.lblFirstVisitDate.Location = New System.Drawing.Point(367, 72)
        Me.lblFirstVisitDate.Name = "lblFirstVisitDate"
        Me.lblFirstVisitDate.Size = New System.Drawing.Size(123, 20)
        Me.lblFirstVisitDate.TabIndex = 31
        Me.lblFirstVisitDate.Text = "First Visit Date"
        '
        'cboVisitFrequencyID
        '
        Me.cboVisitFrequencyID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboVisitFrequencyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisitFrequencyID.Location = New System.Drawing.Point(500, 96)
        Me.cboVisitFrequencyID.Name = "cboVisitFrequencyID"
        Me.cboVisitFrequencyID.Size = New System.Drawing.Size(200, 21)
        Me.cboVisitFrequencyID.TabIndex = 7
        Me.cboVisitFrequencyID.Tag = "ContractOption3Site.VisitFrequencyID"
        '
        'lblVisitFrequencyID
        '
        Me.lblVisitFrequencyID.Location = New System.Drawing.Point(367, 96)
        Me.lblVisitFrequencyID.Name = "lblVisitFrequencyID"
        Me.lblVisitFrequencyID.Size = New System.Drawing.Size(96, 20)
        Me.lblVisitFrequencyID.TabIndex = 31
        Me.lblVisitFrequencyID.Text = "Visit Frequency"
        '
        'txtSitePrice
        '
        Me.txtSitePrice.Location = New System.Drawing.Point(151, 128)
        Me.txtSitePrice.MaxLength = 9
        Me.txtSitePrice.Name = "txtSitePrice"
        Me.txtSitePrice.Size = New System.Drawing.Size(200, 21)
        Me.txtSitePrice.TabIndex = 3
        Me.txtSitePrice.Tag = "ContractOption3Site.SitePrice"
        Me.txtSitePrice.Text = ""
        '
        'lblSitePrice
        '
        Me.lblSitePrice.Location = New System.Drawing.Point(10, 128)
        Me.lblSitePrice.Name = "lblSitePrice"
        Me.lblSitePrice.Size = New System.Drawing.Size(112, 20)
        Me.lblSitePrice.TabIndex = 31
        Me.lblSitePrice.Text = "Property Price"
        '
        'UCQuoteContractOption3Site
        '
        Me.Controls.Add(Me.grpContractOption3Site)
        Me.Name = "UCQuoteContractOption3Site"
        Me.Size = New System.Drawing.Size(994, 616)
        Me.grpContractOption3Site.ResumeLayout(False)
        Me.gpbAssets.ResumeLayout(False)
        CType(Me.dgAssets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentQuoteContractOption3Site
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal ExtraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _currentQuoteContractOption3Site As Entity.QuoteContractOption3Sites.QuoteContractOption3Site

    Public Property CurrentQuoteContractOption3Site() As Entity.QuoteContractOption3Sites.QuoteContractOption3Site
        Get
            Return _currentQuoteContractOption3Site
        End Get
        Set(ByVal Value As Entity.QuoteContractOption3Sites.QuoteContractOption3Site)
            _currentQuoteContractOption3Site = Value

            If _currentQuoteContractOption3Site Is Nothing Then
                _currentQuoteContractOption3Site = New Entity.QuoteContractOption3Sites.QuoteContractOption3Site
                _currentQuoteContractOption3Site.Exists = False
            End If

            If _currentQuoteContractOption3Site.Exists Then
                Populate()
                Dim site As New Entity.Sites.Site
                site = DB.Sites.Get(_currentQuoteContractOption3Site.SiteID)
                txtSite.Text = Replace(Replace(Replace(
                                        site.Address1 & ", " & site.Address2 & ", " & site.Address3 & ", " & site.Address4 & ", " & site.Address5 & ", " & site.Postcode & "." _
                                        , ", , ", ", "), ", , ", ", "), ", , ", ", ")
            End If
        End Set
    End Property

    Private _Assets As DataView

    Private Property Assets() As DataView
        Get
            Return _Assets
        End Get
        Set(ByVal Value As DataView)
            _Assets = Value
            _Assets.AllowNew = False
            _Assets.AllowEdit = True
            _Assets.AllowDelete = False
            _Assets.Table.TableName = Entity.Sys.Enums.TableNames.tblAsset.ToString

            dgAssets.DataSource = _Assets
        End Set
    End Property

    Private _NumOfMonths As Integer = 0

    Private Property NumOfMonths() As Integer
        Get
            Return _NumOfMonths
        End Get
        Set(ByVal Value As Integer)
            _NumOfMonths = Value
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

    Private _AssetDurations As New DataView

    Private Property AssetDurations() As DataView
        Get
            Return _AssetDurations
        End Get
        Set(ByVal Value As DataView)
            _AssetDurations = Value
        End Set
    End Property

#End Region

#Region "SetUp"

    Public Sub SetupAssetsDataGrid()
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
        numOfMonths = Math.Ceiling(DateDiff(DateInterval.Month, dtpStartDate.Value, dtpEndDate.Value))

        For i As Integer = 0 To numOfMonths
            Dim dglc As New Contract3AssetsColourColumn
            dglc.HeaderText = Format(dtpStartDate.Value.AddMonths(i), "MMM yy")
            dglc.MappingName = Format(dtpStartDate.Value.AddMonths(i), "MMM yy")
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

    Private Sub UCContractOption3Site_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
        SetupAssetsDataGrid()
    End Sub

    Private Sub dtpStartDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpStartDate.ValueChanged
        ClearAssetsGrid()
    End Sub

    Private Sub dtpEndDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpEndDate.ValueChanged
        ClearAssetsGrid()
    End Sub

    Private Sub dtpFirstVisitDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFirstVisitDate.ValueChanged
        ClearAssetsGrid()
    End Sub

    Private Sub cboVisitFrequencyID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVisitFrequencyID.SelectedIndexChanged
        ClearAssetsGrid()
    End Sub

    Private Sub btnRefreshGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshGrid.Click
        RefreshAssetsGrid()
    End Sub

#End Region

#Region "Functions"

    Private Sub ClearAssetsGrid()
        If Not CurrentQuoteContractOption3Site Is Nothing Then
            Assets = DB.Asset.Asset_GetForSite(CurrentQuoteContractOption3Site.SiteID)

        End If

        If dtpFirstVisitDate.Value >= dtpStartDate.Value And
                   dtpFirstVisitDate.Value <= dtpEndDate.Value Then
            lblWarning.Visible = False
        Else
            lblWarning.Visible = True
        End If

    End Sub

    Private Sub RefreshAssetsGrid()
        Me.Cursor = Cursors.WaitCursor
        Dim estVisitDate As DateTime = Nothing
        Dim numOfVisits As Integer = 0
        Dim visitFreqInMonths As Integer = 0

        If Not CurrentQuoteContractOption3Site Is Nothing Then
            If Not Assets Is Nothing Then
                NumOfMonths = Math.Ceiling(DateDiff(DateInterval.Month, dtpStartDate.Value, dtpEndDate.Value))

                ClearAssetsGrid()
                Visits = New ArrayList

                For i As Integer = 0 To NumOfMonths
                    Assets.Table.Columns.Add(Format(dtpStartDate.Value.AddMonths(i), "MMM yy"))
                Next

                If Combo.GetSelectedItemValue(cboVisitFrequencyID) > 0 Then
                    If dtpFirstVisitDate.Value.Date >= dtpStartDate.Value.Date And
                        dtpFirstVisitDate.Value.Date <= dtpEndDate.Value.Date Then
                        lblWarning.Visible = False

                        'How Visit Should happen in days
                        numOfVisits = 0
                        '   visitFreqInDays = 0
                        visitFreqInMonths = 0
                        Select Case CType(Combo.GetSelectedItemValue(cboVisitFrequencyID), Entity.Sys.Enums.VisitFrequency)
                            Case Entity.Sys.Enums.VisitFrequency.Annually
                                'visitFreqInDays = 365
                                visitFreqInMonths = 12
                            Case Entity.Sys.Enums.VisitFrequency.Bi_Annually
                                'visitFreqInDays = 182
                                visitFreqInMonths = 6
                            Case Entity.Sys.Enums.VisitFrequency.Monthly
                                ' visitFreqInDays = 30
                                visitFreqInMonths = 1
                            Case Entity.Sys.Enums.VisitFrequency.Quarterly
                                'visitFreqInDays = 91
                                visitFreqInMonths = 3

                        End Select

                        '  numOfVisits = Math.Floor(Math.Ceiling(DateDiff(DateInterval.Day, dtpStartDate.Value, dtpEndDate.Value)) / visitFreqInDays)
                        numOfVisits = Math.Ceiling(DateDiff(DateInterval.Month, dtpStartDate.Value, dtpEndDate.Value) / visitFreqInMonths)
                        If numOfVisits = 0 Then
                            numOfVisits = 1
                        End If

                        estVisitDate = dtpFirstVisitDate.Value.Date & " 09:00:00"

                        For i As Integer = 1 To numOfVisits

                            If estVisitDate >= CDate(Format(dtpStartDate.Value.Date, "dd/MM/yyyy") & " 09:00") _
                                    And estVisitDate <= CDate(Format(dtpEndDate.Value.Date, "dd/MM/yyyy") & " 09:00") Then

                                'I WANT TO STORE THE DATE IT SHOULD HAVE BEEN SO THE DATES AT THE START OF THE MONTH DON@T CREEP UP FOR EAXMPLE - ALP
                                Dim shouldHaveBeenDate As DateTime = estVisitDate
                                'MAKE SURE WE DON'T BOOK A SATURADY OR SUNDAY
                                If estVisitDate.DayOfWeek = DayOfWeek.Saturday Then
                                    estVisitDate = estVisitDate.AddDays(2)
                                ElseIf estVisitDate.DayOfWeek = DayOfWeek.Sunday Then
                                    estVisitDate = estVisitDate.AddDays(1)
                                End If

                                For Each drAsset As DataRow In Assets.Table.Rows
                                    Dim rVal As DataRow()
                                    rVal = AssetDurations.Table.Select("CompareMonth=" & Format(estVisitDate, "yyyyMM") &
                                                                        " AND AssetID=" & drAsset("AssetID"))
                                    If rVal.Length > 0 Then
                                        drAsset(Format(estVisitDate, "MMM yy")) = rVal(0).Item("VisitDuration")
                                    Else
                                        drAsset(Format(estVisitDate, "MMM yy")) = "0"
                                    End If

                                Next drAsset
                                Visits.Add(estVisitDate)

                                ' estVisitDate = estVisitDate.AddDays(visitFreqInDays)
                                estVisitDate = shouldHaveBeenDate.AddMonths(visitFreqInMonths)
                            End If
                        Next i
                    Else
                        lblWarning.Visible = True

                    End If
                End If
            End If

            SetupAssetsDataGrid()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        If Not ID = 0 Then
            CurrentQuoteContractOption3Site = DB.QuoteContractOption3Site.QuoteContractOption3Site_Get(ID)
        End If

        AssetDurations = DB.QuoteContractOption3SiteAssetDurations.QuoteContractOption3SiteAssetDuration_GetAll_ForQuoteContractSiteID(CurrentQuoteContractOption3Site.QuoteContractSiteID)

        Me.txtContractSiteReference.Text = CurrentQuoteContractOption3Site.QuoteContractSiteReference

        Try
            Me.dtpStartDate.Value = CurrentQuoteContractOption3Site.StartDate
            Me.dtpEndDate.Value = CurrentQuoteContractOption3Site.EndDate
            Me.dtpFirstVisitDate.Value = CurrentQuoteContractOption3Site.FirstVisitDate
        Catch ex As Exception
            'AMY DID THIS
            dtpStartDate.Value = Now
            dtpEndDate.Value = Now.AddYears(1).AddDays(-1)
            dtpFirstVisitDate.Value = Now
        End Try

        Combo.SetSelectedComboItem_By_Value(Me.cboVisitFrequencyID, CurrentQuoteContractOption3Site.VisitFrequencyID)
        Me.txtSitePrice.Text = Format(CurrentQuoteContractOption3Site.SitePrice, "C")
        Assets = DB.Asset.Asset_GetForSite(CurrentQuoteContractOption3Site.SiteID)

        AssetDurations = DB.QuoteContractOption3SiteAssetDurations.QuoteContractOption3SiteAssetDuration_GetAll_ForQuoteContractSiteID(CurrentQuoteContractOption3Site.QuoteContractSiteID)
        RefreshAssetsGrid()
        'If AssetDurations.Table.Rows.Count > 0 Then
        '    Me.dtpStartDate.Enabled = False
        '    Me.dtpEndDate.Enabled = False
        '    Me.dtpFirstVisitDate.Enabled = False
        '    Me.cboVisitFrequencyID.Enabled = False
        '    Me.btnRefreshGrid.Enabled = False
        '    Me.dgAssets.Enabled = False
        'End If
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            CurrentQuoteContractOption3Site.IgnoreExceptionsOnSetMethods = True

            CurrentQuoteContractOption3Site.SetQuoteContractSiteReference = Me.txtContractSiteReference.Text.Trim
            CurrentQuoteContractOption3Site.StartDate = Me.dtpStartDate.Value
            CurrentQuoteContractOption3Site.EndDate = Me.dtpEndDate.Value
            CurrentQuoteContractOption3Site.FirstVisitDate = Me.dtpFirstVisitDate.Value
            CurrentQuoteContractOption3Site.SetVisitFrequencyID = Combo.GetSelectedItemValue(Me.cboVisitFrequencyID)
            CurrentQuoteContractOption3Site.SetSitePrice = Me.txtSitePrice.Text.Trim.Replace("£", "")

            Dim cV As New Entity.QuoteContractOption3Sites.QuoteContractOption3SiteValidator
            cV.Validate(CurrentQuoteContractOption3Site, Assets)

            If CurrentQuoteContractOption3Site.Exists Then
                DB.QuoteContractOption3Site.Update(CurrentQuoteContractOption3Site)

                DB.QuoteContractOption3SiteAssetDurations.QuoteContractOption3SiteAssetDuration_Delete(CurrentQuoteContractOption3Site.QuoteContractSiteID)

                For Each vDate As Object In Visits ' For each Visit

                    'FOR EACH ASSET FOR THE VISIT DATE
                    For Each rAsset As DataRow In Assets.Table.Rows
                        'IF DURATION > 0 THEN SAVE DURATION
                        If rAsset(Format(vDate, "MMM yy")) > 0 Then
                            Dim assetDuration As New Entity.QuoteContractOption3SiteAssetDurations.QuoteContractOption3SiteAssetDuration
                            assetDuration.SetQuoteContractSiteID = CurrentQuoteContractOption3Site.QuoteContractSiteID
                            assetDuration.SetAssetID = rAsset("AssetID")
                            assetDuration.ScheduledMonth = vDate
                            assetDuration.SetVisitDuration = rAsset(Format(vDate, "MMM yy"))
                            DB.QuoteContractOption3SiteAssetDurations.Insert(assetDuration)
                        End If
                    Next

                Next vDate
            Else
                CurrentQuoteContractOption3Site = DB.QuoteContractOption3Site.Insert(CurrentQuoteContractOption3Site)
            End If

            RaiseEvent StateChanged(CurrentQuoteContractOption3Site.QuoteContractSiteID)

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