Public Class UCQuoteContractAlternativeConvert : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(Me.cboInvoiceFrequencyID, DynamicDataTables.InvoiceFrequency, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboContractStatusID, DynamicDataTables.ContractStatus, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)

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
    Friend WithEvents txtContractReference As System.Windows.Forms.TextBox
    Friend WithEvents lblContractReference As System.Windows.Forms.Label
    Friend WithEvents cboContractStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents lblContractStatusID As System.Windows.Forms.Label
    Friend WithEvents cboInvoiceFrequencyID As System.Windows.Forms.ComboBox
    Friend WithEvents lblInvoiceFrequencyID As System.Windows.Forms.Label
    Friend WithEvents grpSites As System.Windows.Forms.GroupBox
    Friend WithEvents dgSites As System.Windows.Forms.DataGrid
    Friend WithEvents txtQuoteContractPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents grpVisits As System.Windows.Forms.GroupBox
    Friend WithEvents TCJobsOfWork As System.Windows.Forms.TabControl
    Friend WithEvents btnContractNumber As System.Windows.Forms.Button
    Friend WithEvents dtpContractStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblContractStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpContractEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblContractEndDate As System.Windows.Forms.Label
    Friend WithEvents gpbInvoiceAddress As System.Windows.Forms.GroupBox
    Friend WithEvents dgInvoiceAddress As System.Windows.Forms.DataGrid
    Friend WithEvents dtpFirstInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpContract = New System.Windows.Forms.GroupBox
        Me.grpVisits = New System.Windows.Forms.GroupBox
        Me.TCJobsOfWork = New System.Windows.Forms.TabControl
        Me.txtQuoteContractPrice = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.grpSites = New System.Windows.Forms.GroupBox
        Me.dgSites = New System.Windows.Forms.DataGrid
        Me.txtContractReference = New System.Windows.Forms.TextBox
        Me.lblContractReference = New System.Windows.Forms.Label
        Me.cboContractStatusID = New System.Windows.Forms.ComboBox
        Me.lblContractStatusID = New System.Windows.Forms.Label
        Me.cboInvoiceFrequencyID = New System.Windows.Forms.ComboBox
        Me.lblInvoiceFrequencyID = New System.Windows.Forms.Label
        Me.lblContractEndDate = New System.Windows.Forms.Label
        Me.btnContractNumber = New System.Windows.Forms.Button
        Me.dtpContractStartDate = New System.Windows.Forms.DateTimePicker
        Me.lblContractStartDate = New System.Windows.Forms.Label
        Me.dtpContractEndDate = New System.Windows.Forms.DateTimePicker
        Me.gpbInvoiceAddress = New System.Windows.Forms.GroupBox
        Me.dgInvoiceAddress = New System.Windows.Forms.DataGrid
        Me.dtpFirstInvoiceDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.grpContract.SuspendLayout()
        Me.grpVisits.SuspendLayout()
        Me.grpSites.SuspendLayout()
        CType(Me.dgSites, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbInvoiceAddress.SuspendLayout()
        CType(Me.dgInvoiceAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpContract
        '
        Me.grpContract.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpContract.Controls.Add(Me.gpbInvoiceAddress)
        Me.grpContract.Controls.Add(Me.dtpFirstInvoiceDate)
        Me.grpContract.Controls.Add(Me.Label1)
        Me.grpContract.Controls.Add(Me.grpVisits)
        Me.grpContract.Controls.Add(Me.txtQuoteContractPrice)
        Me.grpContract.Controls.Add(Me.grpSites)
        Me.grpContract.Controls.Add(Me.txtContractReference)
        Me.grpContract.Controls.Add(Me.lblContractReference)
        Me.grpContract.Controls.Add(Me.cboContractStatusID)
        Me.grpContract.Controls.Add(Me.lblContractStatusID)
        Me.grpContract.Controls.Add(Me.cboInvoiceFrequencyID)
        Me.grpContract.Controls.Add(Me.lblInvoiceFrequencyID)
        Me.grpContract.Controls.Add(Me.lblContractEndDate)
        Me.grpContract.Controls.Add(Me.btnContractNumber)
        Me.grpContract.Controls.Add(Me.dtpContractStartDate)
        Me.grpContract.Controls.Add(Me.lblContractStartDate)
        Me.grpContract.Controls.Add(Me.dtpContractEndDate)
        Me.grpContract.Controls.Add(Me.Label6)
        Me.grpContract.Location = New System.Drawing.Point(8, 0)
        Me.grpContract.Name = "grpContract"
        Me.grpContract.Size = New System.Drawing.Size(968, 664)
        Me.grpContract.TabIndex = 0
        Me.grpContract.TabStop = False
        Me.grpContract.Text = "Main Details"
        '
        'grpVisits
        '
        Me.grpVisits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpVisits.Controls.Add(Me.TCJobsOfWork)

        Me.grpVisits.Location = New System.Drawing.Point(11, 216)
        Me.grpVisits.Name = "grpVisits"
        Me.grpVisits.Size = New System.Drawing.Size(949, 432)
        Me.grpVisits.TabIndex = 8
        Me.grpVisits.TabStop = False
        Me.grpVisits.Text = "Jobs Of Work"
        '
        'TCJobsOfWork
        '
        Me.TCJobsOfWork.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TCJobsOfWork.Location = New System.Drawing.Point(8, 24)
        Me.TCJobsOfWork.Name = "TCJobsOfWork"
        Me.TCJobsOfWork.SelectedIndex = 0
        Me.TCJobsOfWork.Size = New System.Drawing.Size(933, 400)
        Me.TCJobsOfWork.TabIndex = 44
        '
        'txtQuoteContractPrice
        '
        Me.txtQuoteContractPrice.Location = New System.Drawing.Point(136, 64)
        Me.txtQuoteContractPrice.MaxLength = 9
        Me.txtQuoteContractPrice.Name = "txtQuoteContractPrice"
        Me.txtQuoteContractPrice.Size = New System.Drawing.Size(170, 21)
        Me.txtQuoteContractPrice.TabIndex = 7
        Me.txtQuoteContractPrice.Tag = "Contract.ContractPrice"
        Me.txtQuoteContractPrice.Text = ""
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 20)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "Total Contract Price"
        '
        'grpSites
        '
        Me.grpSites.Controls.Add(Me.dgSites)
        Me.grpSites.Location = New System.Drawing.Point(11, 112)
        Me.grpSites.Name = "grpSites"
        Me.grpSites.Size = New System.Drawing.Size(949, 104)
        Me.grpSites.TabIndex = 7
        Me.grpSites.TabStop = False
        Me.grpSites.Text = "Properties"
        '
        'dgSites
        '
        Me.dgSites.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSites.DataMember = ""
        Me.dgSites.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSites.Location = New System.Drawing.Point(11, 16)
        Me.dgSites.Name = "dgSites"
        Me.dgSites.Size = New System.Drawing.Size(929, 80)
        Me.dgSites.TabIndex = 0
        '
        'txtContractReference
        '
        Me.txtContractReference.Location = New System.Drawing.Point(136, 16)
        Me.txtContractReference.MaxLength = 100
        Me.txtContractReference.Name = "txtContractReference"
        Me.txtContractReference.Size = New System.Drawing.Size(170, 21)
        Me.txtContractReference.TabIndex = 1
        Me.txtContractReference.Tag = "Contract.ContractReference"
        Me.txtContractReference.Text = ""
        '
        'lblContractReference
        '
        Me.lblContractReference.Location = New System.Drawing.Point(17, 16)
        Me.lblContractReference.Name = "lblContractReference"
        Me.lblContractReference.Size = New System.Drawing.Size(139, 20)
        Me.lblContractReference.TabIndex = 31
        Me.lblContractReference.Text = "Contract Reference"
        '
        'cboContractStatusID
        '
        Me.cboContractStatusID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboContractStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContractStatusID.Location = New System.Drawing.Point(136, 40)
        Me.cboContractStatusID.Name = "cboContractStatusID"
        Me.cboContractStatusID.Size = New System.Drawing.Size(170, 21)
        Me.cboContractStatusID.TabIndex = 3
        Me.cboContractStatusID.Tag = "Contract.ContractStatusID"
        '
        'lblContractStatusID
        '
        Me.lblContractStatusID.Location = New System.Drawing.Point(16, 40)
        Me.lblContractStatusID.Name = "lblContractStatusID"
        Me.lblContractStatusID.Size = New System.Drawing.Size(139, 20)
        Me.lblContractStatusID.TabIndex = 31
        Me.lblContractStatusID.Text = "Contract Status"
        '
        'cboInvoiceFrequencyID
        '
        Me.cboInvoiceFrequencyID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboInvoiceFrequencyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInvoiceFrequencyID.Location = New System.Drawing.Point(136, 88)
        Me.cboInvoiceFrequencyID.Name = "cboInvoiceFrequencyID"
        Me.cboInvoiceFrequencyID.Size = New System.Drawing.Size(170, 21)
        Me.cboInvoiceFrequencyID.TabIndex = 6
        Me.cboInvoiceFrequencyID.Tag = "Contract.InvoiceFrequencyID"
        '
        'lblInvoiceFrequencyID
        '
        Me.lblInvoiceFrequencyID.Location = New System.Drawing.Point(16, 88)
        Me.lblInvoiceFrequencyID.Name = "lblInvoiceFrequencyID"
        Me.lblInvoiceFrequencyID.Size = New System.Drawing.Size(139, 20)
        Me.lblInvoiceFrequencyID.TabIndex = 4
        Me.lblInvoiceFrequencyID.Text = "Invoice Frequency"
        '
        'lblContractEndDate
        '
        Me.lblContractEndDate.Location = New System.Drawing.Point(312, 64)
        Me.lblContractEndDate.Name = "lblContractEndDate"
        Me.lblContractEndDate.Size = New System.Drawing.Size(56, 20)
        Me.lblContractEndDate.TabIndex = 49
        Me.lblContractEndDate.Text = "End Date"
        '
        'btnContractNumber
        '
        Me.btnContractNumber.UseVisualStyleBackColor = True
        Me.btnContractNumber.Location = New System.Drawing.Point(312, 15)
        Me.btnContractNumber.Name = "btnContractNumber"
        Me.btnContractNumber.Size = New System.Drawing.Size(208, 23)
        Me.btnContractNumber.TabIndex = 2
        Me.btnContractNumber.Text = "Next Suggested Contract Number"
        '
        'dtpContractStartDate
        '
        Me.dtpContractStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpContractStartDate.Location = New System.Drawing.Point(400, 40)
        Me.dtpContractStartDate.Name = "dtpContractStartDate"
        Me.dtpContractStartDate.Size = New System.Drawing.Size(120, 21)
        Me.dtpContractStartDate.TabIndex = 4
        Me.dtpContractStartDate.Tag = "Contract.ContractStartDate"
        '
        'lblContractStartDate
        '
        Me.lblContractStartDate.Location = New System.Drawing.Point(312, 40)
        Me.lblContractStartDate.Name = "lblContractStartDate"
        Me.lblContractStartDate.Size = New System.Drawing.Size(64, 20)
        Me.lblContractStartDate.TabIndex = 46
        Me.lblContractStartDate.Text = "Start Date"
        '
        'dtpContractEndDate
        '
        Me.dtpContractEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpContractEndDate.Location = New System.Drawing.Point(400, 64)
        Me.dtpContractEndDate.Name = "dtpContractEndDate"
        Me.dtpContractEndDate.Size = New System.Drawing.Size(120, 21)
        Me.dtpContractEndDate.TabIndex = 5
        Me.dtpContractEndDate.Tag = "Contract.ContractEndDate"
        '
        'gpbInvoiceAddress
        '
        Me.gpbInvoiceAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbInvoiceAddress.Controls.Add(Me.dgInvoiceAddress)
        Me.gpbInvoiceAddress.Location = New System.Drawing.Point(528, 8)
        Me.gpbInvoiceAddress.Name = "gpbInvoiceAddress"
        Me.gpbInvoiceAddress.Size = New System.Drawing.Size(432, 104)
        Me.gpbInvoiceAddress.TabIndex = 64
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
        Me.dgInvoiceAddress.Size = New System.Drawing.Size(416, 76)
        Me.dgInvoiceAddress.TabIndex = 0
        '
        'dtpFirstInvoiceDate
        '
        Me.dtpFirstInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFirstInvoiceDate.Location = New System.Drawing.Point(400, 88)
        Me.dtpFirstInvoiceDate.Name = "dtpFirstInvoiceDate"
        Me.dtpFirstInvoiceDate.Size = New System.Drawing.Size(120, 21)
        Me.dtpFirstInvoiceDate.TabIndex = 63
        Me.dtpFirstInvoiceDate.Tag = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(312, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 20)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "First Inv. Date"
        '
        'UCQuoteContractAlternativeConvert
        '
        Me.Controls.Add(Me.grpContract)
        Me.Name = "UCQuoteContractAlternativeConvert"
        Me.Size = New System.Drawing.Size(983, 675)
        Me.grpContract.ResumeLayout(False)
        Me.grpVisits.ResumeLayout(False)
        Me.grpSites.ResumeLayout(False)
        CType(Me.dgSites, System.ComponentModel.ISupportInitialize).EndInit()
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
            Return CurrentQuoteContract
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _currentQuoteContract As Entity.QuoteContractAlternatives.QuoteContractAlternative

    Public Property CurrentQuoteContract() As Entity.QuoteContractAlternatives.QuoteContractAlternative
        Get
            Return _currentQuoteContract
        End Get
        Set(ByVal Value As Entity.QuoteContractAlternatives.QuoteContractAlternative)
            _currentQuoteContract = Value

            If _currentQuoteContract Is Nothing Then
                _currentQuoteContract = New Entity.QuoteContractAlternatives.QuoteContractAlternative
                _currentQuoteContract.Exists = False
            End If

            Populate()
            Sites = DB.QuoteContractAlternativeSite.GetAll_QuoteContractID(_currentQuoteContract.QuoteContractID, _currentQuoteContract.CustomerID)
            'Load Invoice Addresses
            InvoiceAddresses = DB.InvoiceAddress.InvoiceAddress_Get_CustomerID(_currentQuoteContract.CustomerID)

            For Each site As DataRow In Sites.Table.Rows
                SiteArray.Add(DB.QuoteContractAlternativeSite.Get(site("QuoteContractSiteID")))
            Next site
        End Set
    End Property

    Private _Sites As DataView

    Private Property Sites() As DataView
        Get
            Return _Sites
        End Get
        Set(ByVal Value As DataView)
            _Sites = Value
            _Sites.Table.TableName = Entity.Sys.Enums.TableNames.tblQuoteContractSite.ToString
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

    Private _SiteArray As New ArrayList

    Public Property SiteArray() As ArrayList
        Get
            Return _SiteArray
        End Get
        Set(ByVal Value As ArrayList)
            _SiteArray = Value
        End Set
    End Property

    Public IsLoading As Boolean = False

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
        Tick.Width = 40
        Tick.NullText = ""
        tStyle.GridColumnStyles.Add(Tick)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Property"
        Site.MappingName = "Site"
        Site.ReadOnly = True
        Site.Width = 400
        Site.NullText = ""
        tStyle.GridColumnStyles.Add(Site)

        tStyle.ReadOnly = False
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblQuoteContractSite.ToString
        Me.dgSites.TableStyles.Add(tStyle)

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

    Private Sub txtContractPrice_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuoteContractPrice.LostFocus
        Dim price As String = ""

        If txtQuoteContractPrice.Text.Trim.Length = 0 Then
            price = Format(0.0, "C")
        ElseIf Not IsNumeric(txtQuoteContractPrice.Text.Replace("£", "")) Then
            price = Format(0.0, "C")
        Else
            price = Format(CDbl(txtQuoteContractPrice.Text.Replace("£", "")), "C")
        End If
        txtQuoteContractPrice.Text = price
    End Sub

    Private Sub dgSites_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSites.Click, dgSites.CurrentCellChanged
        If Not SelectedSiteDataRow Is Nothing Then
            grpVisits.Text = "Jobs Of Work for " & SelectedSiteDataRow("Site")

            Dim CurrentQuoteContractSite As New Entity.QuoteContractAlternativeSites.QuoteContractAlternativeSite
            'CurrentQuoteContractSite = DB.QuoteContractAlternativeSite.Get(SelectedSiteDataRow("QuoteContractSiteID"))
            CurrentQuoteContractSite = SiteArray(dgSites.CurrentRowIndex)
            IsLoading = True
            If Not CurrentQuoteContractSite Is Nothing Then
                If CurrentQuoteContractSite.JobOfWorks.Count > 0 Then
                    Me.TCJobsOfWork.TabPages.Clear()

                    For Each jobOfWork As Entity.QuoteContractAlternativeSiteJobOfWorks.QuoteContractAlternativeSiteJobOfWork In CurrentQuoteContractSite.JobOfWorks
                        If DB.QuoteContractAlternativeSiteJobItems.GetAll_For_JobOfWorkID(jobOfWork.QuoteContractSiteJobOfWorkID()).Table.Rows.Count > 0 Then
                            Dim tp As TabPage = AddJobOfWork(jobOfWork, CurrentQuoteContractSite)
                        End If
                    Next
                    Me.TCJobsOfWork.SelectedTab = Me.TCJobsOfWork.TabPages(0)
                Else
                    Me.TCJobsOfWork.TabPages.Clear()
                End If
            Else
                Me.TCJobsOfWork.TabPages.Clear()
            End If
            IsLoading = False
        End If
    End Sub

    Private Sub dgSites_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgSites.MouseUp
        Dim HitTestInfo As DataGrid.HitTestInfo
        HitTestInfo = dgSites.HitTest(e.X, e.Y)
        If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
            dgSites.CurrentRowIndex = HitTestInfo.Row()
        End If

        If HitTestInfo.Column = 0 Then
            Dim selected As Boolean = Not Entity.Sys.Helper.MakeBooleanValid(Me.dgSites(Me.dgSites.CurrentRowIndex, 0))
            Sites.Table.Rows(dgSites.CurrentRowIndex).Item("Tick") = selected

            TCJobsOfWork.Enabled = selected

        End If
    End Sub

    Private Sub btnContractNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContractNumber.Click
        ShowForm(GetType(FRMAvailableContractNos), True, New Object() {Me.txtContractReference, Me})
    End Sub

    Private Sub dgInvoiceAddress_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgInvoiceAddress.Click
        dgInvoiceAddress.Select(dgInvoiceAddress.CurrentRowIndex)
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

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        If Not ID = 0 Then
            CurrentQuoteContract = DB.QuoteContractAlternative.Get(ID)
        End If

        Me.txtContractReference.Text = CurrentQuoteContract.QuoteContractReference
        Me.dtpContractStartDate.Value = CurrentQuoteContract.ContractStart
        Me.dtpContractEndDate.Value = CurrentQuoteContract.ContractEnd
        Combo.SetSelectedComboItem_By_Value(Me.cboContractStatusID, Entity.Sys.Enums.ContractStatus.Active)
        Me.txtQuoteContractPrice.Text = Format(CurrentQuoteContract.QuoteContractPrice, "C")
        Me.dtpFirstInvoiceDate.Value = CurrentQuoteContract.ContractStart
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim NewContract As New Entity.ContractsAlternative.ContractAlternative

            NewContract.IgnoreExceptionsOnSetMethods = True

            NewContract.SetContractReference = Me.txtContractReference.Text.Trim
            NewContract.ContractStartDate = Me.dtpContractStartDate.Value
            NewContract.ContractEndDate = Me.dtpContractEndDate.Value
            NewContract.SetContractStatusID = Combo.GetSelectedItemValue(Me.cboContractStatusID)
            NewContract.SetContractPrice = Me.txtQuoteContractPrice.Text.Trim.Replace("£", "")

            NewContract.SetInvoiceFrequencyID = Combo.GetSelectedItemValue(Me.cboInvoiceFrequencyID)
            NewContract.SetQuoteContractID = CurrentQuoteContract.QuoteContractID
            NewContract.SetCustomerID = CurrentQuoteContract.CustomerID

            NewContract.FirstInvoiceDate = dtpFirstInvoiceDate.Value

            If Not SelectedInvoiceAddressesDataRow Is Nothing Then
                NewContract.SetInvoiceAddressID = SelectedInvoiceAddressesDataRow("AddressID")
                NewContract.SetInvoiceAddressTypeID = SelectedInvoiceAddressesDataRow("AddressTypeID")
            End If

            Dim cV As New Entity.ContractsAlternative.ContractAlternativeValidator
            cV.Validate(NewContract)

            'VALIDATE SITES BEFORE WE CONTINUE
            For Each site As DataRow In Sites.Table.Rows
                If site.Item("Tick") = True Then

                    Dim sV As New Entity.ContractAlternativeSites.ContractAlternativeSiteValidator
                    Dim validateSite As New Entity.ContractAlternativeSites.ContractAlternativeSite
                    validateSite.SetContractID = NewContract.ContractID
                    validateSite.SetPropertyID = site.Item("SiteID")
                    sV.Validate(validateSite, NewContract)

                End If
            Next

            'INSERT NEW CONTRACT
            NewContract = DB.ContractAlternative.Insert(NewContract)
            InsertInvoiceToBeRaiseLines(NewContract)

            'INSERT CONTRACT SITES
            Dim siteCount As Integer = 0
            For Each site As DataRow In Sites.Table.Rows
                If site.Item("Tick") = True Then
                    Dim newSite As New Entity.ContractAlternativeSites.ContractAlternativeSite
                    newSite.SetContractID = NewContract.ContractID
                    newSite.SetPropertyID = site.Item("SiteID")

                    newSite = DB.ContractAlternativeSite.Insert(newSite)

                    Dim JobOfWorkCount As Integer = 0

                    'INSERT CONTRACT JOBOFWORK
                    For Each JOW As Entity.QuoteContractAlternativeSiteJobOfWorks.QuoteContractAlternativeSiteJobOfWork In
                       CType(SiteArray(siteCount), Entity.QuoteContractAlternativeSites.QuoteContractAlternativeSite).JobOfWorks

                        If DB.QuoteContractAlternativeSiteJobItems.GetAll_For_JobOfWorkID(JOW.QuoteContractSiteJobOfWorkID()).Table.Rows.Count > 0 Then

                            Dim newConJobOfWork As New Entity.ContractAlternativeSiteJobOfWorks.ContractAlternativeSiteJobOfWork
                            newConJobOfWork.FirstVisitDate = JOW.FirstVisitDate
                            newConJobOfWork.SetAverageMileage = JOW.AverageMileage
                            newConJobOfWork.SetIncludeMileagePrice = JOW.IncludeMileagePrice
                            newConJobOfWork.SetIncludeRates = JOW.IncludeRates
                            newConJobOfWork.SetPricePerMile = JOW.PricePerMile
                            newConJobOfWork.SetPricePerVisit = JOW.PricePerVisit
                            newConJobOfWork.SetTotalSitePrice = JOW.TotalSitePrice
                            newConJobOfWork.SetContractSiteID = newSite.ContractSiteID
                            newConJobOfWork = DB.ContractAlternativeSiteJobOfWork.Insert(newConJobOfWork)

                            DB.ContractAlternativeSiteJobOfWork.SaveRates(JOW.ScheduledOfRates_UsedForConvertOnly, newConJobOfWork.ContractSiteJobOfWorkID)

                            Dim dvJobItems As DataView
                            dvJobItems = DB.QuoteContractAlternativeSiteJobItems.GetAll_For_JobOfWorkID _
                                    (CType(CType(SiteArray(siteCount),
                                        Entity.QuoteContractAlternativeSites.QuoteContractAlternativeSite).JobOfWorks(JobOfWorkCount),
                                        Entity.QuoteContractAlternativeSiteJobOfWorks.QuoteContractAlternativeSiteJobOfWork).QuoteContractSiteJobOfWorkID)

                            'INSERT CONTRACT JOB ITEMS
                            For Each jobI As DataRow In dvJobItems.Table.Rows

                                Dim newConJobI As New Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItems
                                newConJobI.SetContractSiteID = CType(SiteArray(siteCount), Entity.QuoteContractAlternativeSites.QuoteContractAlternativeSite).QuoteContractSiteID
                                newConJobI.SetDescription = jobI("Description")
                                newConJobI.SetJobOfWorkID = newConJobOfWork.ContractSiteJobOfWorkID
                                newConJobI.SetItemPricePerVisit = jobI("itemPricePerVisit")
                                newConJobI.SetVisitDuration = jobI("VisitDuration")
                                newConJobI.SetVisitFrequencyID = jobI("VisitFrequencyID")

                                newConJobI = DB.ContractAlternativeSiteJobItems.Insert(newConJobI)

                                'INSERT CONTRACT ASSETS
                                Dim dvAssets As DataView = DB.QuoteContractAlternativeSiteAsset.GetAll_JobItemID(jobI("QuoteContractSiteJobItemID"))
                                For Each drAsset As DataRow In dvAssets.Table.Rows
                                    Dim newConAsset As New Entity.ContractAlternativeSiteAssets.ContractAlternativeSiteAsset
                                    newConAsset.SetAssetID = drAsset("AssetID")
                                    newConAsset.SetContractSiteJobItemID = newConJobI.ContractSiteJobItemID
                                    DB.ContractAlternativeSiteAsset.Insert(newConAsset)
                                Next drAsset
                            Next jobI

                            'Plan jobs
                            'START SCHEDULING JOBS************************
                            ScheduleJob(NewContract, newSite, newConJobOfWork, DB.ContractAlternativeSiteJobItems.GetAll_For_JobOfWorkID(newConJobOfWork.ContractSiteJobOfWorkID))
                            '*********************************************
                            JobOfWorkCount = +1
                        End If
                    Next JOW
                End If
                siteCount += 1
            Next site

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

    Private Sub ScheduleJob(ByVal newContract As Entity.ContractsAlternative.ContractAlternative,
                            ByVal newSite As Entity.ContractAlternativeSites.ContractAlternativeSite,
                            ByVal newJobOfWork As Entity.ContractAlternativeSiteJobOfWorks.ContractAlternativeSiteJobOfWork,
                            ByVal newJobItems As DataView)
        Try

            'Duration OF Contract In Days
            Dim ContractDuration As Integer
            ContractDuration = newContract.ContractEndDate.Subtract(newContract.ContractStartDate).Days

            'How Visit Should happen in days
            Dim NumOfVisits As Integer = 0
            Dim VisitFreqInDays As Integer = 0

            Select Case CType(newJobItems.Table.Rows(0).Item("VisitFrequencyID"), Entity.Sys.Enums.VisitFrequency)
                Case Entity.Sys.Enums.VisitFrequency.Annually
                    VisitFreqInDays = 365
                Case Entity.Sys.Enums.VisitFrequency.Bi_Annually
                    VisitFreqInDays = 182
                Case Entity.Sys.Enums.VisitFrequency.Monthly
                    VisitFreqInDays = 30
                Case Entity.Sys.Enums.VisitFrequency.Quarterly
                    VisitFreqInDays = 91
                Case Entity.Sys.Enums.VisitFrequency.Weekly
                    VisitFreqInDays = 7
            End Select

            NumOfVisits = Math.Floor(ContractDuration / VisitFreqInDays)
            If NumOfVisits = 0 Then
                NumOfVisits = 1
            End If
            Dim EstVisitDate As DateTime = newJobOfWork.FirstVisitDate.Date & " 09:00:00"

            For i As Integer = 1 To NumOfVisits
                If EstVisitDate >= newContract.ContractStartDate And EstVisitDate <= newContract.ContractEndDate Then

                    'MAKE SURE WE DON'T BOOK A SATURADY OR SUNDAY
                    If EstVisitDate.DayOfWeek = DayOfWeek.Saturday Then
                        EstVisitDate = EstVisitDate.AddDays(2)
                    ElseIf EstVisitDate.DayOfWeek = DayOfWeek.Sunday Then
                        EstVisitDate = EstVisitDate.AddDays(1)
                    End If

                    'CREATE JOB
                    Dim job As New Entity.Jobs.Job
                    job.SetPropertyID = newSite.PropertyID
                    job.SetJobDefinitionEnumID = CInt(Entity.Sys.Enums.JobDefinition.Contract)
                    job.SetJobTypeID = 0
                    job.SetStatusEnumID = CInt(Entity.Sys.Enums.JobStatus.Open)
                    job.SetCreatedByUserID = loggedInUser.UserID
                    Dim JobNumber As New JobNumber
                    JobNumber = DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.Contract)
                    job.SetJobNumber = JobNumber.Prefix & JobNumber.JobNumber
                    job.SetPONumber = ""
                    job.SetQuoteID = 0
                    job.SetContractID = newContract.ContractID

                    If CType(newContract.ContractStatusID, Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Inactive Then
                        job.SetDeleted = True
                    End If

                    '  INSERT JOB ITEM
                    Dim JobOfWork As New Entity.JobOfWorks.JobOfWork
                    JobOfWork.IgnoreExceptionsOnSetMethods = True
                    If CType(newContract.ContractStatusID, Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Inactive Then
                        JobOfWork.SetDeleted = True
                    End If

                    'Work out how long all the jobitems will take - running tally
                    Dim JobDuration As Integer = 0

                    For Each rw As DataRow In newJobItems.Table.Rows

                        Dim JobItem As New Entity.JobItems.JobItem
                        JobItem.IgnoreExceptionsOnSetMethods = True
                        JobItem.SetSummary = Entity.Sys.Helper.MakeStringValid("PPM Contract Visit: ") &
                                        rw("Description")

                        JobDuration += rw("VisitDuration")

                        'INSERT ANY ASSETS
                        Dim AssetsDV As DataView = DB.ContractAlternativeSiteAsset.GetAll_JobItemID(rw.Item("ContractSiteJobItemID"))

                        For Each dr As DataRow In AssetsDV.Table.Rows
                            Dim JobAsset As New Entity.JobAssets.JobAsset
                            JobAsset.SetAssetID = dr("AssetID")
                            job.Assets.Add(JobAsset)
                        Next dr

                        JobOfWork.JobItems.Add(JobItem)
                    Next rw

                    'NOW SEE IF WE CAN FIND A MATCHING ENGINEER
                    Dim match As New ArrayList
                    Dim engineerID As Integer = 0
                    Dim actualVisitDate As DateTime = Nothing
                    match = MatchingEngineer(job, EstVisitDate, JobDuration)
                    If Not match Is Nothing Then
                        If match.Count > 0 Then
                            actualVisitDate = match(0)
                            engineerID = match(1)
                        End If
                    End If
                    ''NOW SEE IF WE CAN FIND A MATCHING ENGINEER
                    'Dim EngineerID As Integer = 0
                    'Dim site As New Entity.Sites.Site
                    'site = DB.Site.Site_Get(job.SiteID)
                    'If site.EngineerID > 0 Then
                    '    EngineerID = site.EngineerID
                    'Else
                    '    Dim Postcode As String
                    '    Postcode = site.Postcode.Replace("-", "")
                    '    Postcode = Postcode.Replace(" ", "")
                    '    Postcode = Postcode.Substring(0, Postcode.Length - 3)

                    '    Dim MatchingEngineers As DataView
                    '    MatchingEngineers = DB.EngineerPostalRegion.EngineerPostalRegion_Get_For_Postcode(Postcode)
                    '    If MatchingEngineers.Table.Rows.Count > 0 Then
                    '        Dim randomNum As Integer = 0
                    '        Randomize()
                    '        randomNum = CInt(Int((MatchingEngineers.Table.Rows.Count * Rnd()) + 1)) - 1

                    '        EngineerID = MatchingEngineers.Table.Rows(randomNum).Item("EngineerID")
                    '    End If
                    'End If

                    'IF WE FIND A MATCHING ENGINEER INSERT ENGINEER VISIT
                    Dim EngineerVisit As New Entity.EngineerVisits.EngineerVisit
                    EngineerVisit.IgnoreExceptionsOnSetMethods = True
                    EngineerVisit.SetEngineerID = engineerID
                    EngineerVisit.SetNotesToEngineer = "PPM Contract Visit"

                    If engineerID > 0 Then
                        EngineerVisit.StartDateTime = actualVisitDate
                        EngineerVisit.EndDateTime = actualVisitDate.AddMinutes(JobDuration)
                        EngineerVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Scheduled)
                    Else
                        EngineerVisit.StartDateTime = DateTime.MinValue
                        EngineerVisit.EndDateTime = DateTime.MinValue
                        EngineerVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule)
                    End If

                    If CType(newContract.ContractStatusID, Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Inactive Then
                        EngineerVisit.SetDeleted = True
                    End If

                    JobOfWork.EngineerVisits.Add(EngineerVisit)

                    job.JobOfWorks.Add(JobOfWork)
                    job = DB.Job.Insert(job)

                    'CREATE PPM VISIT RECORD
                    Dim PPM As New Entity.ContractAlternativePPMVisits.ContractAlternativePPMVisit
                    PPM.SetContractSiteJobOfWorkID = newJobOfWork.ContractSiteJobOfWorkID
                    PPM.EstimatedVisitDate = EstVisitDate
                    PPM.SetJobID = job.JobID
                    DB.ContractAlternativePPMVisit.Insert(PPM)
                    EstVisitDate = EstVisitDate.AddDays(VisitFreqInDays)
                End If
            Next i
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Function MatchingEngineer(ByVal job As Entity.Jobs.Job, ByVal estVisitDate As DateTime,
                                   ByVal visitDuration As Integer) As ArrayList
        Dim site As New Entity.Sites.Site
        Dim engineerID As Integer = 0
        Dim slotDuration As Integer = 0 'MINTUES
        'Dim visitDuration As Integer = 0
        Dim numOfSlotsNeeded As Integer = 0
        Dim match As New ArrayList
        Dim postcode As String = ""
        Dim postcodeEngineers As DataView = Nothing
        Dim cntPostcodeEng As Integer = 0
        Dim randomNum As Integer = 0

        'SYSTEM NUMBER OF MINUTES IN A SLOTS
        slotDuration = DB.Manager.Get.TimeSlot

        'VISIT DURATION FOR THIS SITE IN HOURS - its passed!
        ' visitDuration = Combo.GetSelectedItemValue(cboVisitDuration)

        'NUM OF SLOTS NEEDED FOR VISIT
        If visitDuration > 0 Then
            numOfSlotsNeeded = visitDuration / slotDuration
        End If
        '***************************************************************

        'SEE IF THE SITE HAS A DEFAULT ENGINEER
        site = DB.Sites.Get(job.PropertyID)

        If site.EngineerID > 0 Then
            'IF THE SITE DOES, ARE THEY AVAILABLE ON THE DAY OR FOLLOWING 4 DAYS ( NOT WEEKENDS)
            match = CheckAvailability(estVisitDate, site.EngineerID, numOfSlotsNeeded)
        End If
        'IF A ENG & SLOT IS FOUND, RETURN
        If match.Count > 0 Then
            Return match
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

                match = CheckAvailability(estVisitDate _
                                            , postcodeEngineers.Table.Rows(randomNum).Item("EngineerID") _
                                            , numOfSlotsNeeded)
                'IF A ENG & SLOT IS FOUND, RETURN
                If match.Count > 0 Then
                    Return match
                Else
                    postcodeEngineers.Table.Rows.Remove(postcodeEngineers.Table.Rows(randomNum))
                End If

            Next i
        End If
        Return match
    End Function

    Private Function CheckAvailability(ByVal estimatedVisitDate As DateTime,
                                         ByVal engineerID As Integer,
                                         ByVal numOfSlotsNeeded As Integer) As ArrayList

        Dim engTimeSlots As DataTable
        Dim numOfSlotsAvailable As New ArrayList
        Dim actualVisitDate As DateTime = estimatedVisitDate
        Dim match As New ArrayList
        Dim startSlotTime As String = ""

        For day As Integer = 0 To 4
            numOfSlotsAvailable.Clear()

            'ADD ON DAYS - UNLESS FIRST TIME IN
            If day <> 0 Then
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
                        If numOfSlotsAvailable.Count = numOfSlotsNeeded Then
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

                If numOfSlotsAvailable.Count = numOfSlotsNeeded Or
                    numOfSlotsAvailable(0) = DB.Manager.Get.WorkingHoursStart() Then

                    'IF THERE ARE ENOUGH AVAILABLE CONSECTUTIVE SLOTS ADD THE START TIME ONTO THE DATE

                    If numOfSlotsAvailable(0) = DB.Manager.Get.WorkingHoursStart() Then
                        startSlotTime = numOfSlotsAvailable(0)
                    Else
                        startSlotTime = Replace(numOfSlotsAvailable(0), "T", "").Insert(2, ":")
                    End If
                    actualVisitDate = CDate(Format(actualVisitDate, "dd/MM/yyyy") & " " & startSlotTime)

                    match.Add(actualVisitDate)
                    match.Add(engineerID)
                    Return (match)
                End If

            End If
        Next day
        Return (match)

    End Function

    Private Function AddJobOfWork(ByVal jobOfWork As Entity.QuoteContractAlternativeSiteJobOfWorks.QuoteContractAlternativeSiteJobOfWork,
    ByVal CurrentQuoteContractSite As Entity.QuoteContractAlternativeSites.QuoteContractAlternativeSite) As TabPage
        Dim tp As New TabPage
        tp.BackColor = Color.White

        Dim ctrl As New UCConvertJobOfWork
        ctrl.OnControl = Me
        If jobOfWork Is Nothing Then
            jobOfWork = New Entity.QuoteContractAlternativeSiteJobOfWorks.QuoteContractAlternativeSiteJobOfWork
            jobOfWork.SetQuoteContractSiteID = CurrentQuoteContractSite.QuoteContractSiteID
            jobOfWork.FirstVisitDate = CurrentQuoteContract.ContractStart.AddDays(1)
            jobOfWork = DB.QuoteContractAlternativeSiteJobOfWork.Insert(jobOfWork)
        End If
        ctrl.CurrentJobOfWork = jobOfWork

        ctrl.Dock = DockStyle.Fill
        tp.Controls.Add(ctrl)
        Me.TCJobsOfWork.TabPages.Add(tp)
        CheckTabs()

        Me.TCJobsOfWork.SelectedTab = tp

        Return tp
    End Function

    Private Sub CheckTabs()
        Dim i As Integer = 1
        For Each tab As TabPage In Me.TCJobsOfWork.TabPages
            tab.Text = "Job Of Work #" & i
            i += 1
        Next
    End Sub

    Private Sub InsertInvoiceToBeRaiseLines(ByVal CurrentContract As Entity.ContractsAlternative.ContractAlternative)
        Dim numberOfInvoicesToRaise As Integer = 0

        Select Case CType(CurrentContract.InvoiceFrequencyID, Entity.Sys.Enums.InvoiceFrequency)
            Case Entity.Sys.Enums.InvoiceFrequency.Annually
                numberOfInvoicesToRaise = DateDiff(DateInterval.Year, CurrentContract.ContractStartDate, CurrentContract.ContractEndDate)
            Case Entity.Sys.Enums.InvoiceFrequency.Bi_Annually
                numberOfInvoicesToRaise = (DateDiff(DateInterval.Year, CurrentContract.ContractStartDate, CurrentContract.ContractEndDate)) * 2
            Case Entity.Sys.Enums.InvoiceFrequency.Monthly
                numberOfInvoicesToRaise = DateDiff(DateInterval.Month, CurrentContract.ContractStartDate, CurrentContract.ContractEndDate)
            Case Entity.Sys.Enums.InvoiceFrequency.Per_Visit
                'Invoice the visit
            Case Entity.Sys.Enums.InvoiceFrequency.Quarterly
                numberOfInvoicesToRaise = DateDiff(DateInterval.Month, CurrentContract.ContractStartDate, CurrentContract.ContractEndDate) / 3
            Case Entity.Sys.Enums.InvoiceFrequency.Weekly
                numberOfInvoicesToRaise = DateDiff(DateInterval.Day, CurrentContract.ContractStartDate, CurrentContract.ContractEndDate) / 7
        End Select
        Dim raiseDate As DateTime = CurrentContract.FirstInvoiceDate
        For i As Integer = 1 To numberOfInvoicesToRaise
            Dim invToBeRaised As New Entity.InvoiceToBeRaiseds.InvoiceToBeRaised
            invToBeRaised.SetAddressLinkID = CurrentContract.InvoiceAddressID
            invToBeRaised.SetAddressTypeID = CurrentContract.InvoiceAddressTypeID
            invToBeRaised.SetInvoiceTypeID = CInt(Entity.Sys.Enums.InvoiceType.Contract_Option2)
            invToBeRaised.SetLinkID = CurrentContract.ContractID
            invToBeRaised.RaiseDate = raiseDate
            DB.InvoiceToBeRaised.Insert(invToBeRaised)

            Select Case CType(CurrentContract.InvoiceFrequencyID, Entity.Sys.Enums.InvoiceFrequency)
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

#End Region

End Class