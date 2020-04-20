Public Class UCQuotesList : Inherits FSM.UCBase

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal EntityToLinkToIn As Entity.Sys.Enums.TableNames, ByVal CustomerIDIn As Integer,
                                                                                ByVal SiteIDIn As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        EntityToLinkTo = EntityToLinkToIn
        CustomerID = CustomerIDIn
        SiteID = SiteIDIn

        If CustomerID = 0 Then
            Me.btnAdd.Enabled = False
            Me.btnDelete.Enabled = False
        Else
            Populate()

            Me.btnAdd.Enabled = True
            Me.btnDelete.Enabled = True
        End If
        Me.Dock = DockStyle.Fill
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
    Friend WithEvents btnDelete As System.Windows.Forms.Button

    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents grpQuotes As System.Windows.Forms.GroupBox
    Friend WithEvents dgQuotes As System.Windows.Forms.DataGrid
    Friend WithEvents ctxtMnuQuotes As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuJobQuote As System.Windows.Forms.MenuItem

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpQuotes = New System.Windows.Forms.GroupBox()
        Me.dgQuotes = New System.Windows.Forms.DataGrid()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.ctxtMnuQuotes = New System.Windows.Forms.ContextMenu()
        Me.mnuJobQuote = New System.Windows.Forms.MenuItem()
        Me.grpQuotes.SuspendLayout()
        CType(Me.dgQuotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpQuotes
        '
        Me.grpQuotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpQuotes.Controls.Add(Me.dgQuotes)
        Me.grpQuotes.Location = New System.Drawing.Point(8, 8)
        Me.grpQuotes.Name = "grpQuotes"
        Me.grpQuotes.Size = New System.Drawing.Size(488, 512)
        Me.grpQuotes.TabIndex = 0
        Me.grpQuotes.TabStop = False
        Me.grpQuotes.Text = "Double Click To View / Edit"
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
        Me.dgQuotes.Size = New System.Drawing.Size(472, 477)
        Me.dgQuotes.TabIndex = 1
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleDescription = "Delete Contract"
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(440, 528)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(56, 25)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        '
        'btnAdd
        '
        Me.btnAdd.AccessibleDescription = "Add New Contract"
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(8, 528)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(56, 25)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add"
        '
        'ctxtMnuQuotes
        '
        Me.ctxtMnuQuotes.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuJobQuote})
        '
        'mnuJobQuote
        '
        Me.mnuJobQuote.Index = 0
        Me.mnuJobQuote.Text = "Job Quote"
        '
        'UCQuotesList
        '
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.grpQuotes)
        Me.Name = "UCQuotesList"
        Me.Size = New System.Drawing.Size(504, 560)
        Me.grpQuotes.ResumeLayout(False)
        CType(Me.dgQuotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Properties"

    Public Event RefreshContracts()

    Public Event RefreshJobs()

    Private _EntityToLinkTo As Entity.Sys.Enums.TableNames

    Public Property EntityToLinkTo() As Entity.Sys.Enums.TableNames
        Get
            Return _EntityToLinkTo
        End Get
        Set(ByVal Value As Entity.Sys.Enums.TableNames)
            _EntityToLinkTo = Value
        End Set
    End Property

    Private _CustomerID As Integer = 0

    Public Property CustomerID() As Integer
        Get
            Return _CustomerID
        End Get
        Set(ByVal Value As Integer)
            _CustomerID = Value
        End Set
    End Property

    Private _SiteID As Integer = 0

    Public Property SiteID() As Integer
        Get
            Return _SiteID
        End Get
        Set(ByVal Value As Integer)
            _SiteID = Value
        End Set
    End Property

    Private _dvQuotes As DataView

    Public Property Quotes() As DataView
        Get
            Return _dvQuotes
        End Get
        Set(ByVal value As DataView)
            _dvQuotes = value
            _dvQuotes.Table.TableName = Entity.Sys.Enums.TableNames.tblQuotes.ToString
            _dvQuotes.AllowNew = False
            _dvQuotes.AllowEdit = False
            _dvQuotes.AllowDelete = False
            Me.dgQuotes.DataSource = Quotes
        End Set
    End Property

    Private ReadOnly Property SelectedQuoteDataRow() As DataRow
        Get
            If Not Me.dgQuotes.CurrentRowIndex = -1 Then
                Return Quotes(Me.dgQuotes.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _SelectedSiteID As Integer = 0

    Public Property SelectedSiteID() As Integer
        Get
            Return _SelectedSiteID
        End Get
        Set(ByVal Value As Integer)
            _SelectedSiteID = Value
        End Set
    End Property

#End Region

#Region "SetUp"

    Private Sub SetupContractsDataGrid()
        Dim tStyle As DataGridTableStyle = Me.dgQuotes.TableStyles(0)
        tStyle.GridColumnStyles.Clear()

        Dim QuoteType As New DataGridLabelColumn
        QuoteType.Format = ""
        QuoteType.FormatInfo = Nothing
        QuoteType.HeaderText = "Quote Type"
        QuoteType.MappingName = "QuoteType"
        QuoteType.ReadOnly = True
        QuoteType.Width = 100
        QuoteType.NullText = ""
        tStyle.GridColumnStyles.Add(QuoteType)

        Dim QuoteReference As New DataGridLabelColumn
        QuoteReference.Format = ""
        QuoteReference.FormatInfo = Nothing
        QuoteReference.HeaderText = "Reference"
        QuoteReference.MappingName = "Reference"
        QuoteReference.ReadOnly = True
        QuoteReference.Width = 100
        QuoteReference.NullText = ""
        tStyle.GridColumnStyles.Add(QuoteReference)

        Dim QuoteDate As New DataGridLabelColumn
        QuoteDate.Format = "dd/MM/yyyy"
        QuoteDate.FormatInfo = Nothing
        QuoteDate.HeaderText = "Quote Date"
        QuoteDate.MappingName = "QuoteDate"
        QuoteDate.ReadOnly = True
        QuoteDate.Width = 80
        QuoteDate.NullText = ""
        tStyle.GridColumnStyles.Add(QuoteDate)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Price"
        Price.MappingName = "Price"
        Price.ReadOnly = True
        Price.Width = 85
        Price.NullText = ""
        tStyle.GridColumnStyles.Add(Price)

        Dim QuoteStatus As New DataGridLabelColumn
        QuoteStatus.Format = ""
        QuoteStatus.FormatInfo = Nothing
        QuoteStatus.HeaderText = "Status"
        QuoteStatus.MappingName = "Status"
        QuoteStatus.ReadOnly = True
        QuoteStatus.Width = 100
        QuoteStatus.NullText = ""
        tStyle.GridColumnStyles.Add(QuoteStatus)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblQuotes.ToString
        Me.dgQuotes.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub UCQuotesList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadBaseControl(Me)
        SetupContractsDataGrid()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ctxtMnuQuotes.Show(btnAdd, New Point(0, -30))
    End Sub

    Private Sub mnuJobQuote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuJobQuote.Click
        If Not SiteID = 0 Then
            ShowForm(GetType(FRMQuoteJob), True, New Object() {0, SiteID})
        Else
            ' pick site from site list for customer
            ShowForm(GetType(FRMQuoteJobSelectASite), True, New Object() {CustomerID, Me})

            If SelectedSiteID <> 0 Then
                ShowForm(GetType(FRMQuoteJob), True, New Object() {0, SelectedSiteID})
            End If

        End If
        Populate()
    End Sub

    Private Sub dgQuotes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgQuotes.DoubleClick
        If SelectedQuoteDataRow Is Nothing Then
            Exit Sub
        End If

        If SelectedQuoteDataRow("QuoteType") = Entity.Sys.Enums.QuoteType.Contract_Opt_3.ToString Then
            ShowForm(GetType(FRMQuoteContractOption3), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedQuoteDataRow.Item("QuoteID")), Entity.Sys.Helper.MakeIntegerValid(CustomerID)})
        ElseIf SelectedQuoteDataRow("QuoteType") = Entity.Sys.Enums.QuoteType.Job.ToString Then
            ShowForm(GetType(FRMQuoteJob), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedQuoteDataRow.Item("QuoteID")), SelectedQuoteDataRow("IDToLinkTo")})
        End If

        Populate()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If SelectedQuoteDataRow Is Nothing Then
            ShowMessage("Please select quote to delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If ShowMessage("Are you sure you want to delete this quote?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        If SelectedQuoteDataRow("QuoteType") = Entity.Sys.Enums.QuoteType.Contract_Opt_1.ToString Then
            'DELETE  PPM Visits, Quote Contract Site Assets, Quote Contract Sites
            Dim sites As New DataView
            sites = DB.QuoteContractOriginalSite.GetAll_QuoteContractID(SelectedQuoteDataRow.Item("QuoteID"), CustomerID)

            For Each r As DataRow In sites.Table.Rows
                DB.QuoteContractOriginalSite.Delete(r("QuoteContractSiteID"))
            Next r

            DB.QuoteContractOriginal.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedQuoteDataRow.Item("QuoteID")))
        ElseIf SelectedQuoteDataRow("QuoteType") = Entity.Sys.Enums.QuoteType.Contract_Opt_2.ToString Then
            'DELETE  PPM Visits, Quote Contract Site Assets, Quote Contract Sites
            Dim sites As New DataView
            sites = DB.QuoteContractAlternativeSite.GetAll_QuoteContractID(SelectedQuoteDataRow.Item("QuoteID"), CustomerID)

            For Each r As DataRow In sites.Table.Rows
                DB.QuoteContractAlternativeSite.Delete(r("QuoteContractSiteID"))
            Next r

            DB.QuoteContractAlternative.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedQuoteDataRow.Item("QuoteID")))

        ElseIf SelectedQuoteDataRow("QuoteType") = Entity.Sys.Enums.QuoteType.Job.ToString Then
            DB.QuoteJob.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedQuoteDataRow.Item("QuoteID")))

        ElseIf SelectedQuoteDataRow("QuoteType") = Entity.Sys.Enums.QuoteType.Contract_Opt_3.ToString Then
            ' DELETE   Quote Contract Site Assets, Quote Contract Sites
            Dim sites As New DataView
            sites = DB.QuoteContractOption3Site.QuoteContractOption3Site_GetAll_ForQuoteContract(SelectedQuoteDataRow.Item("QuoteID"), CustomerID)

            For Each r As DataRow In sites.Table.Rows
                DB.QuoteContractOption3Site.Delete(r("QuoteContractSiteID"))
            Next r

            DB.QuoteContractOption3.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedQuoteDataRow.Item("QuoteID")))

        End If

        Populate()
    End Sub

#End Region

#Region "Function"

    Private Sub Populate()
        If EntityToLinkTo = Entity.Sys.Enums.TableNames.tblCustomer Then
            Quotes = DB.Quotes.QuotesGet_All_For_CustomerID(CustomerID)
        ElseIf EntityToLinkTo = Entity.Sys.Enums.TableNames.tblSite Then
            Quotes = DB.Quotes.QuotesGet_All_For_SiteID(SiteID)
        Else
            Quotes = DB.Quotes.QuotesGet_All
        End If
        RaiseEvent RefreshContracts()
        RaiseEvent RefreshJobs()

    End Sub

#End Region

End Class