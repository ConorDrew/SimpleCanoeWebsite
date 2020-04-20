Public Class FRMQuoteManager : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents grpFilter As System.Windows.Forms.GroupBox

    Friend WithEvents grpJobs As System.Windows.Forms.GroupBox
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents dgQuotes As System.Windows.Forms.DataGrid
    Friend WithEvents txtReference As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkQuoteDate As System.Windows.Forms.CheckBox
    Friend WithEvents btnFindCustomer As System.Windows.Forms.Button
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents btnFindSite As System.Windows.Forms.Button
    Friend WithEvents txtSite As System.Windows.Forms.TextBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpJobs = New System.Windows.Forms.GroupBox()
        Me.dgQuotes = New System.Windows.Forms.DataGrid()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.grpFilter = New System.Windows.Forms.GroupBox()
        Me.btnFindSite = New System.Windows.Forms.Button()
        Me.txtSite = New System.Windows.Forms.TextBox()
        Me.btnFindCustomer = New System.Windows.Forms.Button()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.txtReference = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkQuoteDate = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.grpJobs.SuspendLayout()
        CType(Me.dgQuotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpJobs
        '
        Me.grpJobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpJobs.Controls.Add(Me.dgQuotes)
        Me.grpJobs.Location = New System.Drawing.Point(8, 232)
        Me.grpJobs.Name = "grpJobs"
        Me.grpJobs.Size = New System.Drawing.Size(784, 224)
        Me.grpJobs.TabIndex = 2
        Me.grpJobs.TabStop = False
        Me.grpJobs.Text = "Double Click To View / Edit"
        '
        'dgQuotes
        '
        Me.dgQuotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgQuotes.DataMember = ""
        Me.dgQuotes.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgQuotes.Location = New System.Drawing.Point(8, 27)
        Me.dgQuotes.Name = "dgQuotes"
        Me.dgQuotes.Size = New System.Drawing.Size(768, 189)
        Me.dgQuotes.TabIndex = 9
        '
        'btnExport
        '
        Me.btnExport.AccessibleDescription = "Export Job List To Excel"
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(8, 464)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(56, 23)
        Me.btnExport.TabIndex = 10
        Me.btnExport.Text = "Export"
        '
        'grpFilter
        '
        Me.grpFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilter.Controls.Add(Me.btnFindSite)
        Me.grpFilter.Controls.Add(Me.txtSite)
        Me.grpFilter.Controls.Add(Me.btnFindCustomer)
        Me.grpFilter.Controls.Add(Me.txtCustomer)
        Me.grpFilter.Controls.Add(Me.Label1)
        Me.grpFilter.Controls.Add(Me.dtpTo)
        Me.grpFilter.Controls.Add(Me.dtpFrom)
        Me.grpFilter.Controls.Add(Me.txtReference)
        Me.grpFilter.Controls.Add(Me.Label9)
        Me.grpFilter.Controls.Add(Me.Label8)
        Me.grpFilter.Controls.Add(Me.chkQuoteDate)
        Me.grpFilter.Controls.Add(Me.Label6)
        Me.grpFilter.Controls.Add(Me.Label2)
        Me.grpFilter.Controls.Add(Me.Label10)
        Me.grpFilter.Controls.Add(Me.cboType)
        Me.grpFilter.Controls.Add(Me.Label11)
        Me.grpFilter.Controls.Add(Me.cboStatus)
        Me.grpFilter.Location = New System.Drawing.Point(8, 40)
        Me.grpFilter.Name = "grpFilter"
        Me.grpFilter.Size = New System.Drawing.Size(784, 184)
        Me.grpFilter.TabIndex = 1
        Me.grpFilter.TabStop = False
        Me.grpFilter.Text = "Filter"
        '
        'btnFindSite
        '
        Me.btnFindSite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindSite.BackColor = System.Drawing.Color.White
        Me.btnFindSite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindSite.Location = New System.Drawing.Point(736, 88)
        Me.btnFindSite.Name = "btnFindSite"
        Me.btnFindSite.Size = New System.Drawing.Size(32, 23)
        Me.btnFindSite.TabIndex = 15
        Me.btnFindSite.Text = "..."
        Me.btnFindSite.UseVisualStyleBackColor = False
        '
        'txtSite
        '
        Me.txtSite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSite.Location = New System.Drawing.Point(104, 88)
        Me.txtSite.Name = "txtSite"
        Me.txtSite.ReadOnly = True
        Me.txtSite.Size = New System.Drawing.Size(624, 21)
        Me.txtSite.TabIndex = 14
        '
        'btnFindCustomer
        '
        Me.btnFindCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindCustomer.BackColor = System.Drawing.Color.White
        Me.btnFindCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindCustomer.Location = New System.Drawing.Point(736, 56)
        Me.btnFindCustomer.Name = "btnFindCustomer"
        Me.btnFindCustomer.Size = New System.Drawing.Size(32, 23)
        Me.btnFindCustomer.TabIndex = 13
        Me.btnFindCustomer.Text = "..."
        Me.btnFindCustomer.UseVisualStyleBackColor = False
        '
        'txtCustomer
        '
        Me.txtCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(104, 56)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(624, 21)
        Me.txtCustomer.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Customer"
        '
        'dtpTo
        '
        Me.dtpTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpTo.Location = New System.Drawing.Point(592, 152)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(184, 21)
        Me.dtpTo.TabIndex = 8
        '
        'dtpFrom
        '
        Me.dtpFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFrom.Location = New System.Drawing.Point(592, 121)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(184, 21)
        Me.dtpFrom.TabIndex = 7
        '
        'txtReference
        '
        Me.txtReference.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReference.Location = New System.Drawing.Point(104, 121)
        Me.txtReference.Name = "txtReference"
        Me.txtReference.Size = New System.Drawing.Size(312, 21)
        Me.txtReference.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Location = New System.Drawing.Point(536, 153)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "To"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.Location = New System.Drawing.Point(536, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "From"
        '
        'chkQuoteDate
        '
        Me.chkQuoteDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkQuoteDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkQuoteDate.UseVisualStyleBackColor = True
        Me.chkQuoteDate.Location = New System.Drawing.Point(424, 121)
        Me.chkQuoteDate.Name = "chkQuoteDate"
        Me.chkQuoteDate.Size = New System.Drawing.Size(104, 24)
        Me.chkQuoteDate.TabIndex = 6
        Me.chkQuoteDate.Text = "Quote Date"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Reference"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Property"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 16)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Type"
        '
        'cboType
        '
        Me.cboType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Location = New System.Drawing.Point(104, 25)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(312, 21)
        Me.cboType.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 152)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 16)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Status"
        '
        'cboStatus
        '
        Me.cboStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Location = New System.Drawing.Point(104, 153)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(312, 21)
        Me.cboStatus.TabIndex = 5
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(72, 464)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(56, 23)
        Me.btnReset.TabIndex = 11
        Me.btnReset.Text = "Reset"
        '
        'FRMQuoteManager
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(800, 494)
        Me.Controls.Add(Me.grpFilter)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.grpJobs)
        Me.Controls.Add(Me.btnReset)
        Me.MinimumSize = New System.Drawing.Size(808, 528)
        Me.Name = "FRMQuoteManager"
        Me.Text = "Quote Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.btnReset, 0)
        Me.Controls.SetChildIndex(Me.grpJobs, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.grpFilter, 0)
        Me.grpJobs.ResumeLayout(False)
        CType(Me.dgQuotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFilter.ResumeLayout(False)
        Me.grpFilter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        SetupQuotesDataGrid()
        PopulateDatagrid()
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

    Private _dvQuotes As DataView

    Private Property QuotesDataview() As DataView
        Get
            Return _dvQuotes
        End Get
        Set(ByVal value As DataView)
            _dvQuotes = value
            _dvQuotes.AllowNew = False
            _dvQuotes.AllowEdit = False
            _dvQuotes.AllowDelete = False
            _dvQuotes.Table.TableName = Entity.Sys.Enums.TableNames.tblQuotes.ToString
            Me.dgQuotes.DataSource = QuotesDataview
        End Set
    End Property

    Private ReadOnly Property SelectedQuoteDataRow() As DataRow
        Get
            If Not Me.dgQuotes.CurrentRowIndex = -1 Then
                Return QuotesDataview(Me.dgQuotes.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
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
            Else
                Me.txtCustomer.Text = ""
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
            Else
                Me.txtSite.Text = ""
            End If
        End Set
    End Property

#End Region

#Region "Setup"

    Private Sub SetupQuotesDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgQuotes.TableStyles(0)

        Dim QuoteType As New DataGridLabelColumn
        QuoteType.Format = ""
        QuoteType.FormatInfo = Nothing
        QuoteType.HeaderText = "Quote Type"
        QuoteType.MappingName = "QuoteType"
        QuoteType.ReadOnly = True
        QuoteType.Width = 80
        QuoteType.NullText = ""
        tbStyle.GridColumnStyles.Add(QuoteType)

        Dim Customer As New DataGridLabelColumn
        Customer.Format = ""
        Customer.FormatInfo = Nothing
        Customer.HeaderText = "Customer"
        Customer.MappingName = "Customer"
        Customer.ReadOnly = True
        Customer.Width = 150
        Customer.NullText = ""
        tbStyle.GridColumnStyles.Add(Customer)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Property"
        Site.MappingName = "Site"
        Site.ReadOnly = True
        Site.Width = 150
        Site.NullText = ""
        tbStyle.GridColumnStyles.Add(Site)

        Dim SitePostcode As New DataGridLabelColumn
        SitePostcode.Format = ""
        SitePostcode.FormatInfo = Nothing
        SitePostcode.HeaderText = "Postcode"
        SitePostcode.MappingName = "SitePostcode"
        SitePostcode.ReadOnly = True
        SitePostcode.Width = 100
        SitePostcode.NullText = ""
        tbStyle.GridColumnStyles.Add(SitePostcode)

        Dim QuoteReference As New DataGridLabelColumn
        QuoteReference.Format = ""
        QuoteReference.FormatInfo = Nothing
        QuoteReference.HeaderText = "Reference"
        QuoteReference.MappingName = "Reference"
        QuoteReference.ReadOnly = True
        QuoteReference.Width = 120
        QuoteReference.NullText = ""
        tbStyle.GridColumnStyles.Add(QuoteReference)

        Dim QuoteDate As New DataGridLabelColumn
        QuoteDate.Format = "dd/MM/yyyy"
        QuoteDate.FormatInfo = Nothing
        QuoteDate.HeaderText = "Quote Date"
        QuoteDate.MappingName = "QuoteDate"
        QuoteDate.ReadOnly = True
        QuoteDate.Width = 80
        QuoteDate.NullText = ""
        tbStyle.GridColumnStyles.Add(QuoteDate)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Price"
        Price.MappingName = "Price"
        Price.ReadOnly = True
        Price.Width = 85
        Price.NullText = ""
        tbStyle.GridColumnStyles.Add(Price)

        Dim QuoteStatus As New DataGridLabelColumn
        QuoteStatus.Format = ""
        QuoteStatus.FormatInfo = Nothing
        QuoteStatus.HeaderText = "Status"
        QuoteStatus.MappingName = "Status"
        QuoteStatus.ReadOnly = True
        QuoteStatus.Width = 100
        QuoteStatus.NullText = ""
        tbStyle.GridColumnStyles.Add(QuoteStatus)

        Dim RejectedReason As New DataGridLabelColumn
        RejectedReason.Format = ""
        RejectedReason.FormatInfo = Nothing
        RejectedReason.HeaderText = "Rejected Reason"
        RejectedReason.MappingName = "RejectedReason"
        RejectedReason.ReadOnly = True
        RejectedReason.Width = 150
        RejectedReason.NullText = ""
        tbStyle.GridColumnStyles.Add(RejectedReason)

        Dim Converted As New DataGridLabelColumn
        Converted.Format = ""
        Converted.FormatInfo = Nothing
        Converted.HeaderText = "Converted"
        Converted.MappingName = "Converted"
        Converted.ReadOnly = True
        Converted.Width = 50
        Converted.NullText = ""
        tbStyle.GridColumnStyles.Add(Converted)

        Dim ConvertedJN As New DataGridLabelColumn
        ConvertedJN.Format = ""
        ConvertedJN.FormatInfo = Nothing
        ConvertedJN.HeaderText = "Converted JobNumber"
        ConvertedJN.MappingName = "ConvertedJN"
        ConvertedJN.ReadOnly = True
        ConvertedJN.Width = 100
        ConvertedJN.NullText = ""
        tbStyle.GridColumnStyles.Add(ConvertedJN)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblQuotes.ToString
        Me.dgQuotes.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMQuoteManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ResetFilters()
    End Sub

    Private Sub chkQuoteDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkQuoteDate.CheckedChanged
        If Me.chkQuoteDate.Checked Then
            Me.dtpFrom.Enabled = True
            Me.dtpTo.Enabled = True
        Else
            Me.dtpFrom.Value = Today
            Me.dtpTo.Value = Today
            Me.dtpFrom.Enabled = False
            Me.dtpTo.Enabled = False
        End If
        RunFilter()
    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
        If CInt(Combo.GetSelectedItemValue(Me.cboType)) = CInt(Entity.Sys.Enums.QuoteType.Contract_Opt_1) Then
            Me.btnFindCustomer.Enabled = True
            Me.btnFindSite.Enabled = False
        ElseIf CInt(Combo.GetSelectedItemValue(Me.cboType)) = CInt(Entity.Sys.Enums.QuoteType.Job) Then
            Me.btnFindSite.Enabled = True
            Me.btnFindCustomer.Enabled = False
        End If
        RunFilter()
    End Sub

    Private Sub btnFindCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCustomer.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblCustomer)
        If Not ID = 0 Then
            Customer = DB.Customer.Customer_Get(ID)
            RunFilter()
        End If
    End Sub

    Private Sub btnFindSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindSite.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblSite)
        If Not ID = 0 Then
            theSite = DB.Sites.Get(ID)
            RunFilter()
        End If
    End Sub

    Private Sub cboCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RunFilter()
    End Sub

    Private Sub cboSite_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RunFilter()
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStatus.SelectedIndexChanged
        RunFilter()
    End Sub

    Private Sub txtReference_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReference.TextChanged
        RunFilter()
    End Sub

    Private Sub dtpFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged
        RunFilter()
    End Sub

    Private Sub dtpTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.ValueChanged
        RunFilter()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

    Private Sub dgQuotes_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgQuotes.DoubleClick
        If SelectedQuoteDataRow Is Nothing Then
            Exit Sub
        End If

        If SelectedQuoteDataRow("QuoteType") = Entity.Sys.Enums.QuoteType.Contract_Opt_3.ToString Then
            ShowForm(GetType(FRMQuoteContractOption3), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedQuoteDataRow.Item("QuoteID")), Entity.Sys.Helper.MakeIntegerValid(SelectedQuoteDataRow.Item("IDToLinkTo"))})
        ElseIf SelectedQuoteDataRow("QuoteType") = Entity.Sys.Enums.QuoteType.Job.ToString Then
            ShowForm(GetType(FRMQuoteJob), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedQuoteDataRow.Item("QuoteID")), SelectedQuoteDataRow("IDToLinkTo")})
        End If
    End Sub

#End Region

#Region "Functions"

    Public Sub PopulateDatagrid()
        Try
            ResetFilters()
            If GetParameter(0) Is Nothing Then
                ResetFilters()
            Else
                QuotesDataview = GetParameter(0)
                Me.grpFilter.Enabled = False
            End If
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetFilters()
        QuotesDataview = DB.Quotes.QuotesGet_All()
        theSite = Nothing
        Customer = Nothing
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("ValueMember"))
        dt.Columns.Add(New DataColumn("DisplayMember"))
        Dim newRow As DataRow
        newRow = dt.NewRow
        newRow("ValueMember") = CInt(Entity.Sys.Enums.QuoteType.Job)
        newRow("DisplayMember") = "Jobs"
        dt.Rows.Add(newRow)
        newRow = dt.NewRow
        newRow("ValueMember") = CInt(Entity.Sys.Enums.QuoteType.Contract_Opt_1)
        newRow("DisplayMember") = "Contracts"
        dt.Rows.Add(newRow)
        Combo.SetUpCombo(Me.cboType, dt, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None)
        Combo.SetSelectedComboItem_By_Value(Me.cboType, CInt(Entity.Sys.Enums.QuoteType.Job))
        Combo.SetUpCombo(cboStatus, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Quote_Status).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetSelectedComboItem_By_Value(Me.cboStatus, 0)

        Me.txtReference.Text = ""
        Me.chkQuoteDate.Checked = False
        Me.dtpFrom.Value = Today
        Me.dtpTo.Value = Today
        Me.dtpFrom.Enabled = False
        Me.dtpTo.Enabled = False
        Me.grpFilter.Enabled = True
    End Sub

    Private Sub RunFilter()
        Dim whereClause As String = ""

        If CInt(Combo.GetSelectedItemValue(Me.cboType)) = CInt(Entity.Sys.Enums.QuoteType.Contract_Opt_1) Then
            whereClause += " QuoteType <> 'Job'"

            If Not Customer Is Nothing Then
                whereClause += " AND CustomerID = " & Customer.CustomerID & ""
            End If

        ElseIf CInt(Combo.GetSelectedItemValue(Me.cboType)) = CInt(Entity.Sys.Enums.QuoteType.Job) Then
            whereClause += " QuoteType = 'Job'"

            If Not theSite Is Nothing Then
                whereClause += " AND SiteID = " & theSite.SiteID & ""
            End If

        End If
        If Not Me.txtReference.Text.Trim.Length = 0 Then
            whereClause += " AND Reference LIKE '" & Me.txtReference.Text.Trim & "%'"
        End If
        If Not Combo.GetSelectedItemValue(Me.cboStatus) = 0 Then
            whereClause += " AND StatusID = " & Combo.GetSelectedItemValue(Me.cboStatus) & ""
        End If
        If Me.chkQuoteDate.Checked Then
            whereClause += " AND QuoteDate >= '" & Format(Me.dtpFrom.Value, "dd/MM/yyyy 00:00:00") & "' AND QuoteDate <= '" & Format(Me.dtpTo.Value, "dd/MM/yyyy 23:59:59") & "'"
        End If

        QuotesDataview.RowFilter = whereClause
        grpJobs.Text = String.Format("Results ({0}) - Double Click To View / Edit", QuotesDataview.Count)
    End Sub

    Public Sub Export()
        Dim exportData As New DataTable
        exportData.Columns.Add("QuoteType")
        exportData.Columns.Add("Customer")
        exportData.Columns.Add("Site")
        exportData.Columns.Add("SitePostcode")
        exportData.Columns.Add("Reference")
        exportData.Columns.Add("QuoteDate")
        exportData.Columns.Add("Price", GetType(Double))
        exportData.Columns.Add("Status")
        exportData.Columns.Add("RejectedReason")

        For itm As Integer = 0 To CType(dgQuotes.DataSource, DataView).Count - 1
            dgQuotes.CurrentRowIndex = itm
            Dim newRw As DataRow
            newRw = exportData.NewRow

            newRw("QuoteType") = SelectedQuoteDataRow("QuoteType")
            newRw("Customer") = SelectedQuoteDataRow("Customer")
            newRw("Site") = SelectedQuoteDataRow("Site")
            newRw("SitePostcode") = SelectedQuoteDataRow("SitePostcode")
            newRw("Reference") = SelectedQuoteDataRow("Reference")
            newRw("QuoteDate") = SelectedQuoteDataRow("QuoteDate")
            newRw("Price") = SelectedQuoteDataRow("Price")
            newRw("Status") = SelectedQuoteDataRow("Status")
            newRw("RejectedReason") = SelectedQuoteDataRow("RejectedReason")

            exportData.Rows.Add(newRw)

            dgQuotes.UnSelect(itm)
        Next itm

        Dim exporter As New Entity.Sys.Exporting(exportData, "Quote List")
        exporter = Nothing
    End Sub

#End Region

End Class