Public Class FRMContractRenewal : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents txtPercentMarkup As System.Windows.Forms.TextBox

    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgFirstVisitDates As System.Windows.Forms.DataGrid
    Friend WithEvents btnCreateContract As System.Windows.Forms.Button
    Friend WithEvents txtNewPrice As System.Windows.Forms.TextBox
    Friend WithEvents gpbContract As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gpbSites As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gpbInvoiceAddress As System.Windows.Forms.GroupBox
    Friend WithEvents dgInvoiceAddress As System.Windows.Forms.DataGrid
    Friend WithEvents cboInvoiceFrequencyID As System.Windows.Forms.ComboBox
    Friend WithEvents lblInvoiceFrequencyID As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.gpbContract = New System.Windows.Forms.GroupBox()
        Me.gpbInvoiceAddress = New System.Windows.Forms.GroupBox()
        Me.dgInvoiceAddress = New System.Windows.Forms.DataGrid()
        Me.cboInvoiceFrequencyID = New System.Windows.Forms.ComboBox()
        Me.lblInvoiceFrequencyID = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNewPrice = New System.Windows.Forms.TextBox()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.txtPercentMarkup = New System.Windows.Forms.TextBox()
        Me.btnCreateContract = New System.Windows.Forms.Button()
        Me.dgFirstVisitDates = New System.Windows.Forms.DataGrid()
        Me.gpbSites = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.gpbContract.SuspendLayout()
        Me.gpbInvoiceAddress.SuspendLayout()
        CType(Me.dgInvoiceAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgFirstVisitDates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbSites.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpbContract
        '
        Me.gpbContract.Controls.Add(Me.gpbInvoiceAddress)
        Me.gpbContract.Controls.Add(Me.cboInvoiceFrequencyID)
        Me.gpbContract.Controls.Add(Me.lblInvoiceFrequencyID)
        Me.gpbContract.Controls.Add(Me.Label6)
        Me.gpbContract.Controls.Add(Me.Label5)
        Me.gpbContract.Controls.Add(Me.dtpInvoiceDate)
        Me.gpbContract.Controls.Add(Me.Label4)
        Me.gpbContract.Controls.Add(Me.Label3)
        Me.gpbContract.Controls.Add(Me.Label2)
        Me.gpbContract.Controls.Add(Me.Label1)
        Me.gpbContract.Controls.Add(Me.txtNewPrice)
        Me.gpbContract.Controls.Add(Me.dtpStartDate)
        Me.gpbContract.Controls.Add(Me.dtpEndDate)
        Me.gpbContract.Controls.Add(Me.txtPercentMarkup)
        Me.gpbContract.Location = New System.Drawing.Point(6, 38)
        Me.gpbContract.Name = "gpbContract"
        Me.gpbContract.Size = New System.Drawing.Size(908, 185)
        Me.gpbContract.TabIndex = 2
        Me.gpbContract.TabStop = False
        Me.gpbContract.Text = "Contract"
        '
        'gpbInvoiceAddress
        '
        Me.gpbInvoiceAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbInvoiceAddress.Controls.Add(Me.dgInvoiceAddress)
        Me.gpbInvoiceAddress.Location = New System.Drawing.Point(350, 15)
        Me.gpbInvoiceAddress.Name = "gpbInvoiceAddress"
        Me.gpbInvoiceAddress.Size = New System.Drawing.Size(539, 162)
        Me.gpbInvoiceAddress.TabIndex = 16
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
        Me.dgInvoiceAddress.Size = New System.Drawing.Size(523, 134)
        Me.dgInvoiceAddress.TabIndex = 0
        '
        'cboInvoiceFrequencyID
        '
        Me.cboInvoiceFrequencyID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboInvoiceFrequencyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInvoiceFrequencyID.Location = New System.Drawing.Point(123, 154)
        Me.cboInvoiceFrequencyID.Name = "cboInvoiceFrequencyID"
        Me.cboInvoiceFrequencyID.Size = New System.Drawing.Size(195, 21)
        Me.cboInvoiceFrequencyID.TabIndex = 15
        Me.cboInvoiceFrequencyID.Tag = "Contract.InvoiceFrequencyID"
        '
        'lblInvoiceFrequencyID
        '
        Me.lblInvoiceFrequencyID.Location = New System.Drawing.Point(8, 157)
        Me.lblInvoiceFrequencyID.Name = "lblInvoiceFrequencyID"
        Me.lblInvoiceFrequencyID.Size = New System.Drawing.Size(132, 20)
        Me.lblInvoiceFrequencyID.TabIndex = 14
        Me.lblInvoiceFrequencyID.Text = "Invoice Frequency"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 23)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "New Price"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 23)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Invoice Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpInvoiceDate
        '
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(123, 126)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(195, 21)
        Me.dtpInvoiceDate.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 23)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "End Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Start Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(324, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 23)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "%"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Markup Amount"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNewPrice
        '
        Me.txtNewPrice.Location = New System.Drawing.Point(123, 45)
        Me.txtNewPrice.Name = "txtNewPrice"
        Me.txtNewPrice.Size = New System.Drawing.Size(195, 21)
        Me.txtNewPrice.TabIndex = 5
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(123, 72)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(195, 21)
        Me.dtpStartDate.TabIndex = 2
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(123, 99)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(195, 21)
        Me.dtpEndDate.TabIndex = 1
        '
        'txtPercentMarkup
        '
        Me.txtPercentMarkup.Location = New System.Drawing.Point(123, 17)
        Me.txtPercentMarkup.Name = "txtPercentMarkup"
        Me.txtPercentMarkup.Size = New System.Drawing.Size(195, 21)
        Me.txtPercentMarkup.TabIndex = 0
        '
        'btnCreateContract
        '
        Me.btnCreateContract.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreateContract.Location = New System.Drawing.Point(790, 251)
        Me.btnCreateContract.Name = "btnCreateContract"
        Me.btnCreateContract.Size = New System.Drawing.Size(112, 23)
        Me.btnCreateContract.TabIndex = 4
        Me.btnCreateContract.Text = "Create Contract"
        '
        'dgFirstVisitDates
        '
        Me.dgFirstVisitDates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgFirstVisitDates.DataMember = ""
        Me.dgFirstVisitDates.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgFirstVisitDates.Location = New System.Drawing.Point(8, 24)
        Me.dgFirstVisitDates.Name = "dgFirstVisitDates"
        Me.dgFirstVisitDates.Size = New System.Drawing.Size(894, 221)
        Me.dgFirstVisitDates.TabIndex = 3
        '
        'gpbSites
        '
        Me.gpbSites.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbSites.Controls.Add(Me.btnCancel)
        Me.gpbSites.Controls.Add(Me.dgFirstVisitDates)
        Me.gpbSites.Controls.Add(Me.btnCreateContract)
        Me.gpbSites.Location = New System.Drawing.Point(6, 229)
        Me.gpbSites.Name = "gpbSites"
        Me.gpbSites.Size = New System.Drawing.Size(908, 281)
        Me.gpbSites.TabIndex = 3
        Me.gpbSites.TabStop = False
        Me.gpbSites.Text = "Properties - Enter Dates"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(8, 251)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        '
        'FRMContractRenewal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(928, 509)
        Me.ControlBox = False
        Me.Controls.Add(Me.gpbSites)
        Me.Controls.Add(Me.gpbContract)
        Me.MinimumSize = New System.Drawing.Size(928, 529)
        Me.Name = "FRMContractRenewal"
        Me.Text = "Contract Renewal"
        Me.Controls.SetChildIndex(Me.gpbContract, 0)
        Me.Controls.SetChildIndex(Me.gpbSites, 0)
        Me.gpbContract.ResumeLayout(False)
        Me.gpbContract.PerformLayout()
        Me.gpbInvoiceAddress.ResumeLayout(False)
        CType(Me.dgInvoiceAddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgFirstVisitDates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbSites.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        Select Case GetParameter(0)
            Case Entity.Sys.Enums.QuoteType.Contract_Opt_1.ToString
                ContractType = Entity.Sys.Enums.QuoteType.Contract_Opt_1
            Case Entity.Sys.Enums.QuoteType.Contract_Opt_2.ToString
                ContractType = Entity.Sys.Enums.QuoteType.Contract_Opt_2
            Case Entity.Sys.Enums.QuoteType.Contract_Opt_3.ToString
                ContractType = Entity.Sys.Enums.QuoteType.Contract_Opt_3
        End Select

        ContractID = GetParameter(1)
        Combo.SetUpCombo(Me.cboInvoiceFrequencyID, DynamicDataTables.InvoiceFrequency_NoWeekly, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        FormSetUp()
        Populate()
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Private Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
    End Sub

#End Region

#Region "Properties"

    Private _ContractID As Integer

    Private Property ContractID() As Integer
        Get
            Return _ContractID
        End Get
        Set(ByVal Value As Integer)
            _ContractID = Value
        End Set
    End Property

    Private _ContractType As Entity.Sys.Enums.QuoteType

    Private Property ContractType() As Entity.Sys.Enums.QuoteType
        Get
            Return _ContractType
        End Get
        Set(ByVal Value As Entity.Sys.Enums.QuoteType)
            _ContractType = Value
        End Set
    End Property

    Private _OldContractOne As Entity.ContractsOriginal.ContractOriginal

    Private Property OldContractOne() As Entity.ContractsOriginal.ContractOriginal
        Get
            Return _OldContractOne
        End Get
        Set(ByVal Value As Entity.ContractsOriginal.ContractOriginal)
            _OldContractOne = Value
        End Set
    End Property

    Private _OldContractTwo As Entity.ContractsAlternative.ContractAlternative

    Private Property OldContractTwo() As Entity.ContractsAlternative.ContractAlternative
        Get
            Return _OldContractTwo
        End Get
        Set(ByVal Value As Entity.ContractsAlternative.ContractAlternative)
            _OldContractTwo = Value
        End Set
    End Property

    Private _OldContractThree As Entity.ContractOption3s.ContractOption3

    Private Property OldContractThree() As Entity.ContractOption3s.ContractOption3
        Get
            Return _OldContractThree
        End Get
        Set(ByVal Value As Entity.ContractOption3s.ContractOption3)
            _OldContractThree = Value
        End Set
    End Property

    Private _OldSites As DataView

    Private Property OldSites() As DataView
        Get
            Return _OldSites
        End Get
        Set(ByVal Value As DataView)
            _OldSites = Value
            _OldSites.AllowDelete = False
            _OldSites.AllowEdit = True
            _OldSites.AllowNew = False
            _OldSites.Table.TableName = Entity.Sys.Enums.TableNames.NO_TABLE.ToString
            dgFirstVisitDates.DataSource = OldSites
        End Set
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

#End Region

#Region "Setup"

    Private Sub FormSetUp()
        SetupInvoiceAddressDataGrid()
        Select Case ContractType
            Case Entity.Sys.Enums.QuoteType.Contract_Opt_1
                SetupdgContractOne()
            Case Entity.Sys.Enums.QuoteType.Contract_Opt_2
                SetupdgContractTwo()
            Case Entity.Sys.Enums.QuoteType.Contract_Opt_3
                SetupContractThree()
        End Select
    End Sub

    Private Sub SetupdgContractOne()
        Dim tbStyle As DataGridTableStyle = Me.dgFirstVisitDates.TableStyles(0)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Property"
        Site.MappingName = "Site"
        Site.ReadOnly = True
        Site.Width = 300
        Site.NullText = ""
        tbStyle.GridColumnStyles.Add(Site)

        Dim FirstVisitDate As New DataGridEditableTextBoxColumn
        FirstVisitDate.Format = "dd/MM/yyyy"
        FirstVisitDate.FormatInfo = Nothing
        FirstVisitDate.HeaderText = "First Visit Date"
        FirstVisitDate.MappingName = "FirstVisitDate"
        FirstVisitDate.ReadOnly = False
        FirstVisitDate.Width = 120
        FirstVisitDate.NullText = ""
        tbStyle.GridColumnStyles.Add(FirstVisitDate)

        tbStyle.ReadOnly = False
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.NO_TABLE.ToString
        dgFirstVisitDates.ReadOnly = False
        Me.dgFirstVisitDates.TableStyles.Add(tbStyle)
    End Sub

    Private Sub SetupdgContractTwo()
        Dim tbStyle As DataGridTableStyle = Me.dgFirstVisitDates.TableStyles(0)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Property"
        Site.MappingName = "Site"
        Site.ReadOnly = True
        Site.Width = 250
        Site.NullText = ""
        tbStyle.GridColumnStyles.Add(Site)

        Dim VisitFrequency As New DataGridLabelColumn
        VisitFrequency.Format = ""
        VisitFrequency.FormatInfo = Nothing
        VisitFrequency.HeaderText = "Visit Frequency"
        VisitFrequency.MappingName = "VisitFrequency"
        VisitFrequency.ReadOnly = True
        VisitFrequency.Width = 100
        VisitFrequency.NullText = ""
        tbStyle.GridColumnStyles.Add(VisitFrequency)

        Dim FirstVisitDate As New DataGridEditableTextBoxColumn
        FirstVisitDate.Format = "dd/MM/yyyy"
        FirstVisitDate.FormatInfo = Nothing
        FirstVisitDate.HeaderText = "First Visit Date"
        FirstVisitDate.MappingName = "FirstVisitDate"
        FirstVisitDate.ReadOnly = False
        FirstVisitDate.Width = 100
        FirstVisitDate.NullText = ""
        tbStyle.GridColumnStyles.Add(FirstVisitDate)

        tbStyle.ReadOnly = False
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.NO_TABLE.ToString
        dgFirstVisitDates.ReadOnly = False
        Me.dgFirstVisitDates.TableStyles.Add(tbStyle)
    End Sub

    Private Sub SetupContractThree()
        Dim tbStyle As DataGridTableStyle = Me.dgFirstVisitDates.TableStyles(0)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Property"
        Site.MappingName = "Site"
        Site.ReadOnly = True
        Site.Width = 250
        Site.NullText = ""
        tbStyle.GridColumnStyles.Add(Site)

        Dim StartDate As New DataGridEditableTextBoxColumn
        StartDate.Format = "dd/MM/yyyy"
        StartDate.FormatInfo = Nothing
        StartDate.HeaderText = "Start Date"
        StartDate.MappingName = "StartDate"
        StartDate.ReadOnly = False
        StartDate.Width = 100
        StartDate.NullText = ""
        tbStyle.GridColumnStyles.Add(StartDate)

        Dim EndDate As New DataGridEditableTextBoxColumn
        EndDate.Format = "dd/MM/yyyy"
        EndDate.FormatInfo = Nothing
        EndDate.HeaderText = "End Date"
        EndDate.MappingName = "EndDate"
        EndDate.ReadOnly = False
        EndDate.Width = 100
        EndDate.NullText = ""
        tbStyle.GridColumnStyles.Add(EndDate)

        Dim FirstVisitDate As New DataGridEditableTextBoxColumn
        FirstVisitDate.Format = "dd/MM/yyyy"
        FirstVisitDate.FormatInfo = Nothing
        FirstVisitDate.HeaderText = "First Visit Date"
        FirstVisitDate.MappingName = "FirstVisitDate"
        FirstVisitDate.ReadOnly = False
        FirstVisitDate.Width = 100
        FirstVisitDate.NullText = ""
        tbStyle.GridColumnStyles.Add(FirstVisitDate)

        tbStyle.ReadOnly = False
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.NO_TABLE.ToString
        dgFirstVisitDates.ReadOnly = False
        Me.dgFirstVisitDates.TableStyles.Add(tbStyle)
    End Sub

    Public Sub SetupInvoiceAddressDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgInvoiceAddress)
        Dim tStyle As DataGridTableStyle = Me.dgInvoiceAddress.TableStyles(0)

        tStyle.GridColumnStyles.Clear()
        'tStyle.AllowSorting = False
        'tStyle.ReadOnly = False
        'dgInvoiceAddress.ReadOnly = False

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

    Private Sub FRMContractManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub txtPercentMarkup_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPercentMarkup.TextChanged
        Dim percent As Double = 0
        If Not Me.txtPercentMarkup.Text.Length = 0 Then
            If IsNumeric(txtPercentMarkup.Text) Then
                percent = txtPercentMarkup.Text
            End If
        End If
        Select Case ContractType
            Case Entity.Sys.Enums.QuoteType.Contract_Opt_1
                Me.txtNewPrice.Text = Format((OldContractOne.ContractPrice * (percent / 100)) + OldContractOne.ContractPrice, "C")
            Case Entity.Sys.Enums.QuoteType.Contract_Opt_2
                Me.txtNewPrice.Text = Format((OldContractTwo.ContractPrice * (percent / 100)) + OldContractTwo.ContractPrice, "C")
            Case Entity.Sys.Enums.QuoteType.Contract_Opt_3
                Me.txtNewPrice.Text = Format((OldContractThree.ContractPrice * (percent / 100)) + OldContractThree.ContractPrice, "C")
        End Select

        If percent = 0 Then
            txtPercentMarkup.Text = percent
        End If

    End Sub

    Private Sub dtpStartDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpStartDate.ValueChanged
        If dtpEndDate.Value < dtpStartDate.Value Then
            dtpEndDate.Value = dtpStartDate.Value.AddYears(1).AddDays(-1)
        End If

        If Not OldSites Is Nothing Then
            For Each dr As DataRow In OldSites.Table.Rows
                dr("FirstVisitDate") = Me.dtpStartDate.Value.AddDays(1)
            Next
        End If

    End Sub

    Private Sub btnCreateContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateContract.Click
        Cursor = Cursors.WaitCursor
        Dim saved As Boolean = False
        Select Case ContractType
            Case Entity.Sys.Enums.QuoteType.Contract_Opt_1
                saved = SaveOne()
        End Select

        If saved Then

            Select Case ContractType
                Case Entity.Sys.Enums.QuoteType.Contract_Opt_1
                    Dim newContractID As Integer = DB.ContractManager.ContractRenewals_GetNewID_ByOldID(ContractID, CInt(Entity.Sys.Enums.QuoteType.Contract_Opt_1))
                    Dim dtContracts As DataTable = DB.ContractOriginal.ProcessContract(newContractID)
                    If dtContracts Is Nothing Then Exit Sub
                    Dim details As New ArrayList() From {dtContracts}
                    Dim oPrint As New Entity.Sys.Printing(details, "", Entity.Sys.Enums.SystemDocumentType.ContractOption1)
            End Select
            Cursor = Cursors.Default
            CType(GetParameter(2), FRMContractManager).PopulateDatagrid()
            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

#End Region

#Region " Functions"

    Private Sub Populate()
        Try
            Select Case ContractType
                Case Entity.Sys.Enums.QuoteType.Contract_Opt_1
                    PopulateOne()
                Case Entity.Sys.Enums.QuoteType.Contract_Opt_2
                    PopulateTwo()
                Case Entity.Sys.Enums.QuoteType.Contract_Opt_3
                    PopulateThree()
            End Select
        Catch ex As Exception
            ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PopulateOne()
        OldContractOne = DB.ContractOriginal.Get(ContractID)
        Me.txtPercentMarkup.Text = 0
        Me.dtpStartDate.Value = Now
        Me.dtpEndDate.Value = Now.AddYears(1).AddDays(-1)
        Me.dtpInvoiceDate.Value = Now
        Combo.SetSelectedComboItem_By_Value(Me.cboInvoiceFrequencyID, OldContractOne.InvoiceFrequencyID)
        Dim newSiteOneTable As New DataTable
        newSiteOneTable.Columns.Add("SiteID")
        newSiteOneTable.Columns.Add("ContractSiteID")
        newSiteOneTable.Columns.Add("Site")
        newSiteOneTable.Columns.Add("FirstVisitDate", GetType(DateTime))

        Dim newSite As DataRow
        For Each drSite As DataRow In DB.ContractOriginalSite.GetAll_ContractID(ContractID, OldContractOne.CustomerID).Table.Rows
            If Entity.Sys.Helper.MakeBooleanValid(drSite("Tick")) = True Then
                newSite = newSiteOneTable.NewRow
                newSite("SiteID") = drSite("SiteID")
                newSite("ContractSiteID") = drSite("ContractSiteID")
                newSite("Site") = drSite("Site")
                newSite("FirstVisitDate") = Me.dtpStartDate.Value.AddDays(1)
                newSiteOneTable.Rows.Add(newSite)
            End If
        Next drSite

        OldSites = New DataView(newSiteOneTable)

        'Load Invoice Addresses
        InvoiceAddresses = DB.InvoiceAddress.InvoiceAddress_Get_CustomerID(OldContractOne.CustomerID)

        If OldContractOne.InvoiceAddressID > 0 Then
            Dim c As Integer = 0
            For Each dr As DataRow In InvoiceAddresses.Table.Rows
                If dr("AddressID") = OldContractOne.InvoiceAddressID And
                    dr("AddressTypeID") = OldContractOne.InvoiceAddressTypeID Then
                    dgInvoiceAddress.CurrentRowIndex = c
                    Exit For
                End If
                c += 1
            Next dr
        Else
            dgInvoiceAddress.CurrentRowIndex = 0
        End If
        If dgInvoiceAddress.CurrentRowIndex < 0 Then

            dgInvoiceAddress.Select(dgInvoiceAddress.CurrentRowIndex)

        End If
    End Sub

    Private Sub PopulateTwo()
        OldContractTwo = DB.ContractAlternative.Get(ContractID)
        Me.txtPercentMarkup.Text = 0
        Me.dtpStartDate.Value = Now
        Me.dtpEndDate.Value = Now.AddYears(1).AddDays(-1)
        Me.dtpInvoiceDate.Value = Now
        Combo.SetSelectedComboItem_By_Value(Me.cboInvoiceFrequencyID, OldContractTwo.InvoiceFrequencyID)
        Dim newSiteJOWTable As New DataTable
        newSiteJOWTable.Columns.Add("ContractSiteID")
        newSiteJOWTable.Columns.Add("Site")
        newSiteJOWTable.Columns.Add("SiteID")
        newSiteJOWTable.Columns.Add("VisitFrequency")
        newSiteJOWTable.Columns.Add("FirstVisitDate", GetType(DateTime))
        newSiteJOWTable.Columns.Add("ContractSiteJobOfWorkID")

        Dim newSiteJOW As DataRow
        For Each drSiteJOW As DataRow In DB.ContractManager.ContractRenewal_AlternativeSitesJobOfWorks(ContractID).Table.Rows

            newSiteJOW = newSiteJOWTable.NewRow
            newSiteJOW("ContractSiteID") = drSiteJOW("ContractSiteID")
            newSiteJOW("Site") = drSiteJOW("Site")
            newSiteJOW("SiteID") = drSiteJOW("SiteID")
            newSiteJOW("VisitFrequency") = drSiteJOW("VisitFrequency")
            newSiteJOW("FirstVisitDate") = Me.dtpStartDate.Value.AddDays(1)
            newSiteJOW("ContractSiteJobOfWorkID") = drSiteJOW("ContractSiteJobOfWorkID")
            newSiteJOWTable.Rows.Add(newSiteJOW)

        Next drSiteJOW

        OldSites = New DataView(newSiteJOWTable)
        'Load Invoice Addresses
        InvoiceAddresses = DB.InvoiceAddress.InvoiceAddress_Get_CustomerID(OldContractTwo.CustomerID)

        If OldContractTwo.InvoiceAddressID > 0 Then
            Dim c As Integer = 0
            For Each dr As DataRow In InvoiceAddresses.Table.Rows
                If dr("AddressID") = OldContractTwo.InvoiceAddressID And
                    dr("AddressTypeID") = OldContractTwo.InvoiceAddressTypeID Then
                    dgInvoiceAddress.CurrentRowIndex = c
                    Exit For
                End If
                c += 1
            Next dr
        Else
            dgInvoiceAddress.CurrentRowIndex = 0
        End If
        If dgInvoiceAddress.CurrentRowIndex < 0 Then

            dgInvoiceAddress.Select(dgInvoiceAddress.CurrentRowIndex)

        End If
    End Sub

    Private Sub PopulateThree()
        OldContractThree = DB.ContractOption3.ContractOption3_Get(ContractID)
        Me.txtPercentMarkup.Text = 0
        Me.dtpStartDate.Enabled = False
        Me.dtpEndDate.Enabled = False
        Me.dtpInvoiceDate.Value = Now
        Dim newSiteTable As New DataTable
        newSiteTable.Columns.Add("ContractSiteID")
        newSiteTable.Columns.Add("Site")
        newSiteTable.Columns.Add("OrderID")
        newSiteTable.Columns.Add("StartDate", GetType(DateTime))
        newSiteTable.Columns.Add("EndDate", GetType(DateTime))
        newSiteTable.Columns.Add("FirstVisitDate", GetType(DateTime))

        Dim newSite As DataRow
        For Each drSite As DataRow In DB.ContractOption3Site.ContractOption3Site_GetAll_ForContract(ContractID, OldContractThree.CustomerID).Table.Rows
            If Entity.Sys.Helper.MakeBooleanValid(drSite("tick")) Then
                newSite = newSiteTable.NewRow
                newSite("ContractSiteID") = drSite("ContractSiteID")
                newSite("Site") = drSite("Site")
                newSite("OrderID") = drSite("OrderID")
                newSite("StartDate") = Now
                newSite("EndDate") = Now.AddYears(1).AddDays(-1)
                newSite("FirstVisitDate") = Now.AddDays(1)
                newSiteTable.Rows.Add(newSite)
            End If

        Next drSite

        OldSites = New DataView(newSiteTable)

    End Sub

    Private Function SaveOne() As Boolean
        Try
            Dim newCon1 As New Entity.ContractsOriginal.ContractOriginal

            If Not SelectedInvoiceAddressesDataRow Is Nothing Then
                newCon1.SetInvoiceAddressID = SelectedInvoiceAddressesDataRow("AddressID")
                newCon1.SetInvoiceAddressTypeID = SelectedInvoiceAddressesDataRow("AddressTypeID")
            End If

            Dim err As String = ""
            If dtpEndDate.Value <= dtpStartDate.Value Then
                err += "* End Date must be after Start Date" & vbCrLf
            End If
            If Combo.GetSelectedItemValue(cboInvoiceFrequencyID) = 0 Then
                err += "* Select Invoice Frequency"
            End If
            If newCon1.InvoiceAddressID = 0 Then
                err += "* Select Invoice Address"
            End If
            For Each dr As DataRow In OldSites.Table.Rows
                If Not (dr("FirstVisitDate") > dtpStartDate.Value And dr("FirstVisitDate") < dtpEndDate.Value) Then
                    err += "* First Visit Dates must be between contract start and end dates." & vbCrLf
                End If
            Next

            If err.Length > 0 Then
                ShowMessage("Please correct the following errors" & vbCrLf & err, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            Else
                'InsertContract

                newCon1.SetContractPrice = Me.txtNewPrice.Text.Replace("£", "")
                newCon1.SetContractReference = OldContractOne.ContractReference
                newCon1.SetContractStatusID = CInt(Entity.Sys.Enums.ContractStatus.Active)
                newCon1.SetCustomerID = OldContractOne.CustomerID

                newCon1.SetInvoiceFrequencyID = Combo.GetSelectedItemValue(cboInvoiceFrequencyID)
                newCon1.ContractStartDate = dtpStartDate.Value
                newCon1.ContractEndDate = dtpEndDate.Value
                newCon1.FirstInvoiceDate = dtpInvoiceDate.Value
                newCon1.SetContractTypeID = OldContractOne.ContractTypeID
                newCon1.SetGasSupplyPipework = OldContractOne.GasSupplyPipework

                newCon1 = DB.ContractOriginal.Insert(newCon1)
                With newCon1
                    InsertInvoiceToBeRaiseLines(.InvoiceFrequencyID, .ContractStartDate, .ContractEndDate, .FirstInvoiceDate, .InvoiceAddressID, .InvoiceAddressTypeID, .ContractID, CInt(Entity.Sys.Enums.InvoiceType.Contract_Option1))
                End With

                For Each drSite As DataRow In OldSites.Table.Rows
                    ShowForm(GetType(FRMContractOriginalSite), True, New Object() {0, drSite("SiteID"), newCon1, Me, drSite("ContractSiteID")})
                Next

                DB.ContractManager.ContractRenewalsInsert(OldContractOne.ContractID, newCon1.ContractID, CInt(Entity.Sys.Enums.QuoteType.Contract_Opt_1))
                Return True
            End If
        Catch ex As Exception
            ShowMessage("Error: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

#Region "Contract One Scheduling "

    Private Sub ScheduleJobContractOne(ByVal Contract As Entity.ContractsOriginal.ContractOriginal,
                               ByVal CurrentContractSite As Entity.ContractOriginalSites.ContractOriginalSite)
        Try

            'Duration OF Contract In Days
            Dim contractDuration As Integer
            contractDuration = Contract.ContractEndDate.Subtract(Contract.ContractStartDate).Days

            'How Visit Should happen in days
            Dim numOfVisits As Integer = 0
            Dim visitFreqInDays As Integer = 0

            Select Case CType(CurrentContractSite.VisitFrequencyID, Entity.Sys.Enums.VisitFrequency)
                Case Entity.Sys.Enums.VisitFrequency.Annually
                    visitFreqInDays = 365
                Case Entity.Sys.Enums.VisitFrequency.Bi_Annually
                    visitFreqInDays = 182
                Case Entity.Sys.Enums.VisitFrequency.Monthly
                    visitFreqInDays = 30
                Case Entity.Sys.Enums.VisitFrequency.Quarterly
                    visitFreqInDays = 91
                Case Entity.Sys.Enums.VisitFrequency.Weekly
                    visitFreqInDays = 7
            End Select

            numOfVisits = Math.Floor(contractDuration / visitFreqInDays)
            If numOfVisits = 0 Then
                numOfVisits = 1
            End If

            Dim estVisitDate As DateTime = CurrentContractSite.FirstVisitDate.Date & " 09:00:00"

            For i As Integer = 1 To numOfVisits
                If CDate(Format(estVisitDate, "dd/MM/yyyy") & " 00:00:00") _
                        >= CDate(Format(Contract.ContractStartDate, "dd/MM/yyyy") & " 00:00:00") _
                            And CDate(Format(estVisitDate, "dd/MM/yyyy") & " 00:00:00") _
                        <= CDate(Format(Contract.ContractEndDate, "dd/MM/yyyy") & " 00:00:00") Then

                    'MAKE SURE WE DON'T BOOK A SATURADY OR SUNDAY
                    If estVisitDate.DayOfWeek = DayOfWeek.Saturday Then
                        estVisitDate = estVisitDate.AddDays(2)
                    ElseIf estVisitDate.DayOfWeek = DayOfWeek.Sunday Then
                        estVisitDate = estVisitDate.AddDays(1)
                    End If

                    'CREATE JOB
                    Dim job As New Entity.Jobs.Job
                    job.SetPropertyID = CurrentContractSite.PropertyID
                    job.SetJobDefinitionEnumID = CInt(Entity.Sys.Enums.JobDefinition.Contract)
                    job.SetJobTypeID = 0
                    job.SetStatusEnumID = CInt(Entity.Sys.Enums.JobStatus.Open)
                    job.SetCreatedByUserID = loggedInUser.UserID
                    Dim JobNumber As New JobNumber
                    JobNumber = DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.Contract)
                    job.SetJobNumber = JobNumber.Prefix & JobNumber.JobNumber
                    job.SetPONumber = ""
                    job.SetQuoteID = 0
                    job.SetContractID = Contract.ContractID

                    If CType(Contract.ContractStatusID, Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Inactive Then
                        job.SetDeleted = True
                    End If

                    'INSERT ANY ASSETS
                    For Each dr As DataRow In DB.ContractOriginalSiteAsset.GetAll_ContractSiteID(CurrentContractSite.ContractSiteID, CurrentContractSite.PropertyID).Table.Rows
                        If Entity.Sys.Helper.MakeBooleanValid(dr("Tick")) = True Then
                            Dim JobAsset As New Entity.JobAssets.JobAsset
                            JobAsset.SetAssetID = dr("AssetID")
                            job.Assets.Add(JobAsset)
                        End If
                    Next

                    '  INSERT JOB ITEM
                    Dim jobOfWork As New Entity.JobOfWorks.JobOfWork
                    jobOfWork.IgnoreExceptionsOnSetMethods = True
                    jobOfWork.SetPONumber = ""
                    jobOfWork.SetDeleted = True

                    Dim jobItem As New Entity.JobItems.JobItem
                    jobItem.IgnoreExceptionsOnSetMethods = True
                    jobItem.SetSummary = Entity.Sys.Helper.MakeStringValid("PPM Contract Visit")

                    jobOfWork.JobItems.Add(jobItem)

                    'NOW SEE IF WE CAN FIND A MATCHING ENGINEER
                    Dim match As New ArrayList
                    Dim engineerID As Integer = 0
                    Dim actualVisitDate As DateTime = Nothing
                    match = MatchingEngineerContractOne(job, estVisitDate, CurrentContractSite.VisitDuration)
                    If Not match Is Nothing Then
                        If match.Count > 0 Then
                            actualVisitDate = match(0)
                            engineerID = match(1)
                        End If
                    End If

                    'IF WE FIND A MATCHING ENGINEER INSERT ENGINEER VISIT
                    Dim engineerVisit As New Entity.EngineerVisits.EngineerVisit
                    engineerVisit.IgnoreExceptionsOnSetMethods = True
                    engineerVisit.SetEngineerID = engineerID
                    engineerVisit.SetNotesToEngineer = "PPM Contract Visit"

                    If engineerID > 0 Then
                        engineerVisit.StartDateTime = actualVisitDate
                        engineerVisit.EndDateTime = actualVisitDate.AddHours(CurrentContractSite.VisitDuration)
                        engineerVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Scheduled)
                    Else
                        engineerVisit.StartDateTime = DateTime.MinValue
                        engineerVisit.EndDateTime = DateTime.MinValue
                        engineerVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule)
                    End If

                    If CType(Contract.ContractStatusID, Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Inactive Then
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
                    estVisitDate = estVisitDate.AddDays(visitFreqInDays)
                End If
            Next i
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Function MatchingEngineerContractOne(ByVal job As Entity.Jobs.Job, ByVal estVisitDate As DateTime, ByVal visitDuration As Double) As ArrayList
        Dim site As New Entity.Sites.Site
        Dim engineerID As Integer = 0
        Dim slotDuration As Integer = 0 'MINTUES
        '  Dim visitDuration As Integer = 0
        Dim numOfSlotsNeeded As Integer = 0
        Dim match As New ArrayList
        Dim postcode As String = ""
        Dim postcodeEngineers As DataView = Nothing
        Dim cntPostcodeEng As Integer = 0
        Dim randomNum As Integer = 0

        'SYSTEM NUMBER OF MINUTES IN A SLOTS
        slotDuration = DB.Manager.Get.TimeSlot

        ''VISIT DURATION FOR THIS SITE IN HOURS
        'visitDuration = Combo.GetSelectedItemValue(visitDuration)

        'NUM OF SLOTS NEEDED FOR VISIT
        If visitDuration > 0 Then
            numOfSlotsNeeded = visitDuration / slotDuration
        End If
        '***************************************************************

        'SEE IF THE SITE HAS A DEFAULT ENGINEER
        site = DB.Sites.Get(job.PropertyID)

        If site.EngineerID > 0 Then
            'IF THE SITE DOES, ARE THEY AVAILABLE ON THE DAY OR FOLLOWING 4 DAYS ( NOT WEEKENDS)
            match = CheckAvailabilityContractOne(estVisitDate, site.EngineerID, numOfSlotsNeeded)
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

                match = CheckAvailabilityContractOne(estVisitDate _
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

    End Function

    Private Function CheckAvailabilityContractOne(ByVal estimatedVisitDate As DateTime,
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

#End Region

#Region "Contract Two Scheduling"

    Private Sub ScheduleJobContractTwo(ByVal JobItemDV As DataView,
                                        ByVal FirstVisitDate As DateTime,
                                        ByVal ContractSiteJobOfWorkID As Integer,
                                        ByVal CurrentContract As Entity.ContractsAlternative.ContractAlternative,
                                        ByVal CurrentContractSite As Entity.ContractAlternativeSites.ContractAlternativeSite)
        Try

            'Duration OF Contract In Days
            Dim ContractDuration As Integer
            ContractDuration = CurrentContract.ContractEndDate.Subtract(CurrentContract.ContractStartDate).Days

            'How Visit Should happen in days
            Dim NumOfVisits As Integer = 0
            Dim VisitFreqInDays As Integer = 0

            Select Case CType(JobItemDV.Table.Rows(0).Item("VisitFrequencyID"), Entity.Sys.Enums.VisitFrequency)
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
            Dim EstVisitDate As DateTime = FirstVisitDate.Date & " 09:00:00"

            For i As Integer = 1 To NumOfVisits
                If EstVisitDate >= CurrentContract.ContractStartDate And EstVisitDate <= CurrentContract.ContractEndDate Then

                    'MAKE SURE WE DON'T BOOK A SATURADY OR SUNDAY
                    If EstVisitDate.DayOfWeek = DayOfWeek.Saturday Then
                        EstVisitDate = EstVisitDate.AddDays(2)
                    ElseIf EstVisitDate.DayOfWeek = DayOfWeek.Sunday Then
                        EstVisitDate = EstVisitDate.AddDays(1)
                    End If

                    'CREATE JOB
                    Dim job As New Entity.Jobs.Job
                    job.SetPropertyID = CurrentContractSite.PropertyID
                    job.SetJobDefinitionEnumID = CInt(Entity.Sys.Enums.JobDefinition.Contract)
                    job.SetJobTypeID = 0
                    job.SetStatusEnumID = CInt(Entity.Sys.Enums.JobStatus.Open)
                    job.SetCreatedByUserID = loggedInUser.UserID
                    Dim JobNumber As New JobNumber
                    JobNumber = DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.Contract)
                    job.SetJobNumber = JobNumber.Prefix & JobNumber.JobNumber
                    job.SetPONumber = ""
                    job.SetQuoteID = 0
                    job.SetContractID = CurrentContract.ContractID

                    If CType(CurrentContract.ContractStatusID, Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Inactive Then
                        job.SetDeleted = True
                    End If

                    '  INSERT JOB ITEM
                    Dim JobOfWork As New Entity.JobOfWorks.JobOfWork
                    JobOfWork.IgnoreExceptionsOnSetMethods = True
                    JobOfWork.SetPONumber = ""
                    If CType(CurrentContract.ContractStatusID, Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Inactive Then
                        JobOfWork.SetDeleted = True
                    End If

                    'Work out how long all the jobitems will take - running tally
                    Dim JobDuration As Integer = 0

                    For Each rw As DataRow In JobItemDV.Table.Rows

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
                    match = MatchingEngineerContractTwo(job, EstVisitDate, JobDuration)
                    If Not match Is Nothing Then
                        If match.Count > 0 Then
                            actualVisitDate = match(0)
                            engineerID = match(1)
                        End If
                    End If

                    'IF WE FIND A MATCHING ENGINEER INSERT ENGINEER VISIT
                    Dim EngineerVisit As New Entity.EngineerVisits.EngineerVisit
                    EngineerVisit.IgnoreExceptionsOnSetMethods = True
                    EngineerVisit.SetEngineerID = engineerID
                    EngineerVisit.SetNotesToEngineer = "PPM Contract Visit"

                    If engineerID > 0 Then
                        EngineerVisit.StartDateTime = actualVisitDate
                        EngineerVisit.EndDateTime = actualVisitDate.AddHours(JobDuration)
                        EngineerVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Scheduled)
                    Else
                        EngineerVisit.StartDateTime = DateTime.MinValue
                        EngineerVisit.EndDateTime = DateTime.MinValue
                        EngineerVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule)
                    End If

                    If CType(CurrentContract.ContractStatusID, Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Inactive Then
                        EngineerVisit.SetDeleted = True
                    End If

                    JobOfWork.EngineerVisits.Add(EngineerVisit)

                    job.JobOfWorks.Add(JobOfWork)
                    job = DB.Job.Insert(job)

                    'CREATE PPM VISIT RECORD
                    Dim PPM As New Entity.ContractAlternativePPMVisits.ContractAlternativePPMVisit
                    PPM.SetContractSiteJobOfWorkID = ContractSiteJobOfWorkID
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

    Private Function MatchingEngineerContractTwo(ByVal job As Entity.Jobs.Job, ByVal estVisitDate As DateTime,
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
            match = CheckAvailabilityContractTwo(estVisitDate, site.EngineerID, numOfSlotsNeeded)
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

                match = CheckAvailabilityContractTwo(estVisitDate _
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

    End Function

    Private Function CheckAvailabilityContractTwo(ByVal estimatedVisitDate As DateTime,
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

#End Region

    Private Sub InsertInvoiceToBeRaiseLines(ByVal InvoiceFrequencyID As Integer, ByVal StartDate As DateTime,
                                            ByVal EndDate As DateTime, ByVal FirstInvoiceDate As DateTime,
                                            ByVal InvoiceAddressID As Integer, ByVal InvoiceAddressTypeID As Integer,
                                            ByVal LinkID As Integer, ByVal InvoiceType As Integer)

        StartDate = Format(StartDate, "dd/MM/yyyy") & " 00:00:00"
        EndDate = Format(EndDate.AddDays(1), "dd/MM/yyyy") & " 00:00:00"

        Dim M As Integer = Math.Abs((StartDate.Year - EndDate.Year))
        Dim Numberofmonths As Integer = ((M * 12) + Math.Abs((StartDate.Month - EndDate.Month)))
        Dim days As Integer = EndDate.Subtract(StartDate).Days

        Dim numberOfInvoicesToRaise As Integer = 0

        Select Case CType(InvoiceFrequencyID, Entity.Sys.Enums.InvoiceFrequency_NoWeeK)
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

        Dim raiseDate As DateTime = FirstInvoiceDate
        For i As Integer = 1 To numberOfInvoicesToRaise
            Dim invToBeRaised As New Entity.InvoiceToBeRaiseds.InvoiceToBeRaised
            invToBeRaised.SetAddressLinkID = InvoiceAddressID
            invToBeRaised.SetAddressTypeID = InvoiceAddressTypeID
            invToBeRaised.SetInvoiceTypeID = CInt(Entity.Sys.Enums.InvoiceType.Contract_Option1)
            invToBeRaised.SetLinkID = LinkID
            invToBeRaised.RaiseDate = raiseDate
            DB.InvoiceToBeRaised.Insert(invToBeRaised)

            Select Case CType(InvoiceFrequencyID, Entity.Sys.Enums.InvoiceFrequency_NoWeeK)
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

End Class