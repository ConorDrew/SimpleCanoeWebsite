Imports System.Collections.Generic

Public Class DLGFindRecord : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal trans As SqlClient.SqlTransaction)

        MyBase.New()

        Me.Trans = trans

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
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents grpResults As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents grpStock As System.Windows.Forms.GroupBox
    Friend WithEvents dgStock As System.Windows.Forms.DataGrid
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cbOffice As CheckBox
    Friend WithEvents dgResults As System.Windows.Forms.DataGrid

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.grpResults = New System.Windows.Forms.GroupBox()
        Me.dgResults = New System.Windows.Forms.DataGrid()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.grpStock = New System.Windows.Forms.GroupBox()
        Me.dgStock = New System.Windows.Forms.DataGrid()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbOffice = New System.Windows.Forms.CheckBox()
        Me.grpResults.SuspendLayout()
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpStock.SuspendLayout()
        CType(Me.dgStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Filter By Name"
        '
        'txtFilter
        '
        Me.txtFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.Location = New System.Drawing.Point(104, 40)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(548, 21)
        Me.txtFilter.TabIndex = 1
        '
        'grpResults
        '
        Me.grpResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpResults.Controls.Add(Me.dgResults)
        Me.grpResults.Location = New System.Drawing.Point(8, 68)
        Me.grpResults.Name = "grpResults"
        Me.grpResults.Size = New System.Drawing.Size(793, 377)
        Me.grpResults.TabIndex = 4
        Me.grpResults.TabStop = False
        Me.grpResults.Text = "Select record and click OK"
        '
        'dgResults
        '
        Me.dgResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgResults.DataMember = ""
        Me.dgResults.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgResults.Location = New System.Drawing.Point(8, 27)
        Me.dgResults.Name = "dgResults"
        Me.dgResults.Size = New System.Drawing.Size(779, 342)
        Me.dgResults.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(745, 451)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(56, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(8, 451)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(56, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        '
        'grpStock
        '
        Me.grpStock.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpStock.Controls.Add(Me.dgStock)
        Me.grpStock.Location = New System.Drawing.Point(8, 280)
        Me.grpStock.Name = "grpStock"
        Me.grpStock.Size = New System.Drawing.Size(793, 165)
        Me.grpStock.TabIndex = 5
        Me.grpStock.TabStop = False
        Me.grpStock.Text = "Stock Locations for : 'No Part Selected'"
        Me.grpStock.Visible = False
        '
        'dgStock
        '
        Me.dgStock.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgStock.DataMember = ""
        Me.dgStock.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgStock.Location = New System.Drawing.Point(8, 20)
        Me.dgStock.Name = "dgStock"
        Me.dgStock.Size = New System.Drawing.Size(779, 137)
        Me.dgStock.TabIndex = 3
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(672, 39)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(129, 23)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "Add"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(95, 456)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(175, 24)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Preferred Supplier"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.LightGreen
        Me.Panel1.Location = New System.Drawing.Point(70, 454)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(19, 20)
        Me.Panel1.TabIndex = 8
        '
        'cbOffice
        '
        Me.cbOffice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbOffice.AutoSize = True
        Me.cbOffice.Location = New System.Drawing.Point(665, 42)
        Me.cbOffice.Name = "cbOffice"
        Me.cbOffice.Size = New System.Drawing.Size(130, 17)
        Me.cbOffice.TabIndex = 9
        Me.cbOffice.Text = "Only Show Offices"
        Me.cbOffice.UseVisualStyleBackColor = True
        Me.cbOffice.Visible = False
        '
        'DLGFindRecord
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(809, 481)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbOffice)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.grpStock)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.grpResults)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(704, 392)
        Me.Name = "DLGFindRecord"
        Me.Text = "Find {0}"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtFilter, 0)
        Me.Controls.SetChildIndex(Me.grpResults, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.grpStock, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.cbOffice, 0)
        Me.grpResults.ResumeLayout(False)
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpStock.ResumeLayout(False)
        CType(Me.dgStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        Me.ActiveControl = Me.txtFilter
        Me.txtFilter.Focus()

        SetupDG()
        SetupStockDatagrid()
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

    Private _Trans As SqlClient.SqlTransaction

    Public Property Trans() As SqlClient.SqlTransaction
        Get
            Return _Trans
        End Get
        Set(ByVal value As SqlClient.SqlTransaction)
            _Trans = value
        End Set
    End Property

    Private _TableToSearch As Entity.Sys.Enums.TableNames = Entity.Sys.Enums.TableNames.NO_TABLE

    Public Property TableToSearch() As Entity.Sys.Enums.TableNames
        Get
            Return _TableToSearch
        End Get
        Set(ByVal Value As Entity.Sys.Enums.TableNames)

            Me.MinimumSize = New Size(New Point(704, 392))

            _TableToSearch = Value
            Me.btnAdd.Visible = False

            Select Case TableToSearch
                Case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_tblPicklists_BIN
                    Me.Text = "Find Bin Reference"
                    Records = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PartBinReferences)
                Case Entity.Sys.Enums.TableNames.tblLocations
                    Me.Text = "Find Location"
                    Records = DB.Location.Locations_GetAll_WithNames
                Case Entity.Sys.Enums.TableNames.tblCustomer
                    Me.Text = "Find Customer"
                    Records = DB.Customer.Customer_GetAll_Light(loggedInUser.UserID)
                Case Entity.Sys.Enums.TableNames.tblUser
                    Me.Text = "Find User"
                    Records = DB.User.GetAll()
                Case Entity.Sys.Enums.TableNames.tblSite
                    If ForeignKeyFilters.Count > 0 Then
                        Me.Text = "Find Property For Customer"
                        Dim dtRecords As DataTable = New DataTable()
                        For Each custId As Integer In ForeignKeyFilters
                            Dim dvSites As DataView = DB.Sites.GetForCustomer_Light(custId, loggedInUser.UserID)
                            If dvSites.Count > 0 Then dtRecords.Merge(dvSites.Table)
                        Next
                        Records = New DataView(dtRecords)
                    ElseIf ForeignKeyFilter > 0 Then
                        Me.Text = "Find Property For Customer"
                        Records = DB.Sites.GetForCustomer_Light(ForeignKeyFilter, loggedInUser.UserID)
                    Else
                        Me.Text = "Find Property"
                        Records = DB.Sites.GetAll_Light_New(loggedInUser.UserID)
                    End If
                    Me.cbOffice.Visible = True
                Case Entity.Sys.Enums.TableNames.tblInvoiceAddress
                    If ForeignKeyFilter > 0 Then
                        Me.Text = "Find Invoice Address For Property"
                        Records = DB.InvoiceAddress.InvoiceAddress_GetForSite(ForeignKeyFilter)
                    Else
                        Me.Text = "Find Invoice Address"
                        Records = DB.InvoiceAddress.InvoiceAddress_GetAll()
                    End If
                Case Entity.Sys.Enums.TableNames.tblContact
                    If ForeignKeyFilter > 0 Then
                        Me.Text = "Find Contact For Property"
                        Records = DB.Contact.Contact_GetForSite(ForeignKeyFilter)
                    Else
                        Me.Text = "Find Contact"
                        Records = DB.Contact.Contact_GetAll()
                    End If
                Case Entity.Sys.Enums.TableNames.tblJob
                    Me.Text = "Find Job"
                    Records = DB.Job.Job_Get_All("Where tblJob.Deleted = 0")
                Case Entity.Sys.Enums.TableNames.tblWarehouse
                    Me.Text = "Find Warehouse"
                    If Not Trans Is Nothing Then
                        Records = DB.Warehouse.Warehouse_GetAll(Trans)
                    Else
                        Records = DB.Warehouse.Warehouse_GetAll()
                    End If
                Case Entity.Sys.Enums.TableNames.tblVan
                    Me.Text = "Find Stock Profile"
                    Records = DB.Van.Van_GetAll(False)
                Case Entity.Sys.Enums.TableNames.tblProduct
                    Me.Text = "Find Product"
                    If Not Trans Is Nothing Then
                        Records = DB.Product.Product_GetAll(Trans)
                    Else
                        Records = DB.Product.Product_GetAll()
                    End If
                    Me.btnAdd.Visible = True
                Case Entity.Sys.Enums.TableNames.tblPart
                    Me.Text = "Find Part"
                    If ForeignKeyFilter = 0 Then

                        If Not Trans Is Nothing Then
                            Records = DB.Part.Part_GetAll(Trans)
                        Else
                            Records = DB.Part.Part_GetAll(ForMassPartEntry)
                        End If

                        Me.Height = 392
                        Me.grpResults.Height = 79
                        Me.Height = 600
                        Me.grpStock.Visible = True
                        Me.btnAdd.Visible = True
                    Else

                        If Not Trans Is Nothing Then
                            Records = DB.Order.OrderPart_GetForOrder(ForeignKeyFilter, Trans)
                        Else
                            Records = DB.Order.OrderPart_GetForOrder(ForeignKeyFilter)
                        End If

                    End If

                    Me.txtFilter.Text = PartNumber

                Case Entity.Sys.Enums.TableNames.tblPartSupplier
                    Me.Text = "Find Part"
                    Records = DB.PartSupplier.PartSupplierGet_All()
                Case Entity.Sys.Enums.TableNames.tblProductSupplier
                    Me.Text = "Find Product"
                    Records = DB.ProductSupplier.ProductSupplierGet_All()
                Case Entity.Sys.Enums.TableNames.tblSupplier
                    Me.Text = "Find Supplier"
                    Records = DB.Supplier.Supplier_GetAll()
                    If Entity.Sys.Helper.MakeIntegerValid(ForeignKeyFilter) = 1 Then
                        Records.RowFilter = "MasterSupplierID = 0"
                    End If
                Case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_VansForPart
                    Me.Text = "Find Van"
                    If ForeignKeyFilter > 0 Then
                        If Not Trans Is Nothing Then
                            Records = DB.Van.Van_GetWithPart(ForeignKeyFilter, Trans)
                        Else
                            Records = DB.Van.Van_GetWithPart(ForeignKeyFilter)
                        End If
                    Else
                        If Not Trans Is Nothing Then
                            Records = DB.Van.Van_GetAll(False, Trans)
                        Else
                            Records = DB.Van.Van_GetAll(False)
                        End If
                    End If
                Case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_VansForProduct
                    Me.Text = "Find Van"
                    If ForeignKeyFilter > 0 Then
                        If Not Trans Is Nothing Then
                            Records = DB.Van.Van_GetWithProduct(ForeignKeyFilter, Trans)
                        Else
                            Records = DB.Van.Van_GetWithProduct(ForeignKeyFilter)
                        End If
                    Else
                        If Not Trans Is Nothing Then
                            Records = DB.Van.Van_GetAll(False, Trans)
                        Else
                            Records = DB.Van.Van_GetAll(False)
                        End If
                    End If
                Case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForProduct
                    Me.Text = "Find Supplier"
                    If ForeignKeyFilter > 0 Then
                        If Not Trans Is Nothing Then
                            Records = DB.Supplier.Supplier_GetWithProduct(ForeignKeyFilter, Trans)
                        Else
                            Records = DB.Supplier.Supplier_GetWithProduct(ForeignKeyFilter)
                        End If
                    Else
                        If Not Trans Is Nothing Then
                            Records = DB.Supplier.Supplier_GetAll(Trans)
                        Else
                            Records = DB.Supplier.Supplier_GetAll()
                        End If
                    End If
                Case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForPart
                    Me.Text = "Find Supplier"
                    If ForeignKeyFilter > 0 Then
                        If Not Trans Is Nothing Then
                            Records = DB.Supplier.Supplier_GetWithPart(ForeignKeyFilter, Trans)
                        Else
                            Records = DB.Supplier.Supplier_GetWithPart(ForeignKeyFilter)
                        End If
                    Else
                        If Not Trans Is Nothing Then
                            Records = DB.Supplier.Supplier_GetAll(Trans)
                        Else
                            Records = DB.Supplier.Supplier_GetAll()
                        End If
                    End If
                Case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehouseForProduct
                    Me.Text = "Find Warehouse"
                    If ForeignKeyFilter > 0 Then
                        If Not Trans Is Nothing Then
                            Records = DB.Warehouse.Warehouse_GetWithProduct(ForeignKeyFilter, Trans)
                        Else
                            Records = DB.Warehouse.Warehouse_GetWithProduct(ForeignKeyFilter)
                        End If
                    Else
                        If Not Trans Is Nothing Then
                            Records = DB.Warehouse.Warehouse_GetAll(Trans)
                        Else
                            Records = DB.Warehouse.Warehouse_GetAll()
                        End If
                    End If
                Case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehouseForPart
                    Me.Text = "Find Warehouse"
                    If ForeignKeyFilter > 0 Then
                        If Not Trans Is Nothing Then
                            Records = DB.Warehouse.Warehouse_GetWithPart(ForeignKeyFilter, Trans)
                        Else
                            Records = DB.Warehouse.Warehouse_GetWithPart(ForeignKeyFilter)
                        End If
                    Else
                        If Not Trans Is Nothing Then
                            Records = DB.Warehouse.Warehouse_GetAll(Trans)
                        Else
                            Records = DB.Warehouse.Warehouse_GetAll()
                        End If
                    End If
                Case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehousesAndVans
                    Me.Text = "Select A Location for the Unallocated Received Job Parts/Products to be placed"
                    If Trans Is Nothing Then
                        Records = DB.Location.Locations_GetAll_WithNames
                    Else
                        Records = DB.Location.Locations_GetAll_WithNames(Trans)
                    End If
                Case Entity.Sys.Enums.TableNames.tblEngineer
                    Me.Text = "Find an Engineer"
                    Records = DB.Engineer.Engineer_GetAll
                Case Entity.Sys.Enums.TableNames.tblOrder
                    Me.Text = "Find an Order"
                    Records = DB.Order.Order_GetAll("")
                    Records.RowFilter = " SupplierID > 0 AND OrderTypeID <> 1 AND OrderTypeID <> 4 AND DisplayStatusID >= " & CInt(Entity.Sys.Enums.OrderStatus.Complete)
                Case Entity.Sys.Enums.TableNames.tblFleetVan
                    Me.Text = "Find Van"
                    Records = DB.FleetVan.GetAll()
                Case Entity.Sys.Enums.TableNames.tblFleetVanFault
                    Me.Text = "Find Fault"
                    Records = DB.FleetVanFault.GetAll_Unresolved_WithNoJob()
                Case Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate
                    Me.Text = "Find SOR"
                    Records = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll()
                Case Entity.Sys.Enums.TableNames.tblEngineerSkills
                    Me.Text = "Find Engineer Skill"
                    Records = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Engineer_Levels)
                Case Entity.Sys.Enums.TableNames.tblEngineerRole
                    Me.Text = "Find an Engineer"
                    Records = DB.EngineerRole.GetEngineersNotAssignedToRole
            End Select

            If TableToSearch = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehousesAndVans Then
                btnCancel.Enabled = False
            Else
                btnCancel.Enabled = True
            End If

            Me.MinimumSize = Me.Size
        End Set
    End Property

    Private _foreignKeyFilter As Integer

    Public Property ForeignKeyFilter() As Integer
        Get
            Return _foreignKeyFilter
        End Get
        Set(ByVal Value As Integer)
            _foreignKeyFilter = Value
        End Set
    End Property

    Private _foreignKeyFilters As New List(Of Integer)

    Public Property ForeignKeyFilters() As List(Of Integer)
        Get
            Return _foreignKeyFilters
        End Get
        Set(ByVal value As List(Of Integer))
            _foreignKeyFilters = value
        End Set
    End Property

    Private _PartNumber As String

    Public Property PartNumber() As String
        Get
            Return _PartNumber
        End Get
        Set(ByVal Value As String)
            _PartNumber = Value
        End Set
    End Property

    Private _ForMassPartEntry As Boolean = False

    Public Property ForMassPartEntry() As Boolean
        Get
            Return _ForMassPartEntry
        End Get
        Set(ByVal Value As Boolean)
            _ForMassPartEntry = Value
        End Set
    End Property

    Private _dvRecords As DataView

    Private Property Records() As DataView
        Get
            Return _dvRecords
        End Get
        Set(ByVal value As DataView)
            _dvRecords = value
            _dvRecords.Table.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString
            _dvRecords.AllowNew = False
            If ForMassPartEntry Then
                _dvRecords.AllowEdit = True
            Else
                _dvRecords.AllowEdit = False
            End If
            _dvRecords.AllowDelete = False
            Me.dgResults.DataSource = Records

            If TableToSearch = Entity.Sys.Enums.TableNames.tblPart Then
                If Not Records Is Nothing Then
                    If Not Records.Table Is Nothing Then
                        If Records.Table.Rows.Count > 0 Then
                            If Not Trans Is Nothing Then
                                StockDataview = DB.Part.Stock_Get_Locations(Records.Table.Rows(0).Item("PartID"), Trans)
                            Else
                                StockDataview = DB.Part.Stock_Get_Locations(Records.Table.Rows(0).Item("PartID"))
                            End If

                            Me.grpStock.Text = "Stock Locations for : '" & Records.Table.Rows(0).Item("Name") & "'"
                        End If
                    End If
                End If
            End If
        End Set
    End Property

    Private ReadOnly Property SelectedDataRow() As DataRow
        Get
            If Not Me.dgResults.CurrentRowIndex = -1 Then
                Return Records(Me.dgResults.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _StockDataview As DataView = Nothing

    Public Property StockDataview() As DataView
        Get
            Return _StockDataview
        End Get
        Set(ByVal Value As DataView)
            _StockDataview = Value

            If Not _StockDataview Is Nothing Then
                If Not _StockDataview.Table Is Nothing Then
                    _StockDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString
                    _StockDataview.AllowNew = False
                    _StockDataview.AllowEdit = True
                    _StockDataview.AllowDelete = False
                End If
            End If

            Me.dgStock.DataSource = StockDataview
        End Set
    End Property

    Private _ID As Integer = 0

    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal Value As Integer)
            _ID = Value
        End Set
    End Property

    Private _2ndID As Integer = 0

    Public Property SecondID() As Integer
        Get
            Return _2ndID
        End Get
        Set(ByVal Value As Integer)
            _2ndID = Value
        End Set
    End Property

    Private _PartsToAdd As ArrayList = Nothing

    Public Property PartsToAdd() As ArrayList
        Get
            Return _PartsToAdd
        End Get
        Set(ByVal Value As ArrayList)
            _PartsToAdd = Value
        End Set
    End Property

#End Region

#Region "Setup"

    Private Sub SetupDG()
        Dim tStyle As DataGridTableStyle = Me.dgResults.TableStyles(0)

        tStyle.ReadOnly = True

        Select Case TableToSearch
            Case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_tblPicklists_BIN
                Dim Name As New DataGridLabelColumn
                Name.Format = ""
                Name.FormatInfo = Nothing
                Name.HeaderText = "Name"
                Name.MappingName = "Name"
                Name.ReadOnly = True
                Name.Width = 300
                Name.NullText = ""
                tStyle.GridColumnStyles.Add(Name)

            Case Entity.Sys.Enums.TableNames.tblLocations
                Dim LocationType As New DataGridLabelColumn
                LocationType.Format = ""
                LocationType.FormatInfo = Nothing
                LocationType.HeaderText = "Type"
                LocationType.MappingName = "LocationType"
                LocationType.ReadOnly = True
                LocationType.Width = 100
                LocationType.NullText = ""
                tStyle.GridColumnStyles.Add(LocationType)

                Dim Name As New DataGridLabelColumn
                Name.Format = ""
                Name.FormatInfo = Nothing
                Name.HeaderText = "Name"
                Name.MappingName = "Name"
                Name.ReadOnly = True
                Name.Width = 300
                Name.NullText = ""
                tStyle.GridColumnStyles.Add(Name)

            Case Entity.Sys.Enums.TableNames.tblCustomer
                Dim Name As New DataGridLabelColumn
                Name.Format = ""
                Name.FormatInfo = Nothing
                Name.HeaderText = "Name"
                Name.MappingName = "Name"
                Name.ReadOnly = True
                Name.Width = 170
                Name.NullText = ""
                tStyle.GridColumnStyles.Add(Name)

                Dim AccountNumber As New DataGridLabelColumn
                AccountNumber.Format = ""
                AccountNumber.FormatInfo = Nothing
                AccountNumber.HeaderText = "Account Number"
                AccountNumber.MappingName = "AccountNumber"
                AccountNumber.ReadOnly = True
                AccountNumber.Width = 100
                AccountNumber.NullText = ""
                tStyle.GridColumnStyles.Add(AccountNumber)

                Dim Region As New DataGridLabelColumn
                Region.Format = ""
                Region.FormatInfo = Nothing
                Region.HeaderText = "Region"
                Region.MappingName = "Region"
                Region.ReadOnly = True
                Region.Width = 100
                Region.NullText = ""
                tStyle.GridColumnStyles.Add(Region)

                Dim Type As New DataGridLabelColumn
                Type.Format = ""
                Type.FormatInfo = Nothing
                Type.HeaderText = "Type"
                Type.MappingName = "Type"
                Type.ReadOnly = True
                Type.Width = 140
                Type.NullText = ""
                tStyle.GridColumnStyles.Add(Type)

                Dim HO As New DataGridLabelColumn
                HO.Format = ""
                HO.FormatInfo = Nothing
                HO.HeaderText = "Head Office"
                HO.MappingName = "ho"
                HO.ReadOnly = True
                HO.Width = 250
                HO.NullText = ""
                tStyle.GridColumnStyles.Add(HO)
            Case Entity.Sys.Enums.TableNames.tblUser
                Dim Name As New DataGridLabelColumn
                Name.Format = ""
                Name.FormatInfo = Nothing
                Name.HeaderText = "Full Name"
                Name.MappingName = "FullName"
                Name.ReadOnly = True
                Name.Width = 170
                Name.NullText = ""
                tStyle.GridColumnStyles.Add(Name)

                Dim Address As New DataGridLabelColumn
                Address.Format = ""
                Address.FormatInfo = Nothing
                Address.HeaderText = "Email Address"
                Address.MappingName = "EmailAddress"
                Address.Width = 200
                Address.ReadOnly = True
                Address.NullText = ""
                tStyle.GridColumnStyles.Add(Address)

            Case Entity.Sys.Enums.TableNames.tblSite

                Dim customeerName As New DataGridLabelColumn
                customeerName.Format = ""
                customeerName.FormatInfo = Nothing
                customeerName.HeaderText = "Customer"
                customeerName.MappingName = "CustomerName"
                customeerName.ReadOnly = True
                customeerName.Width = 100
                customeerName.NullText = ""
                tStyle.GridColumnStyles.Add(customeerName)

                Dim Name As New DataGridLabelColumn
                Name.Format = ""
                Name.FormatInfo = Nothing
                Name.HeaderText = "Name"
                Name.MappingName = "Name"
                Name.ReadOnly = True
                Name.Width = 100
                Name.NullText = ""
                tStyle.GridColumnStyles.Add(Name)

                Dim Address1 As New DataGridLabelColumn
                Address1.Format = ""
                Address1.FormatInfo = Nothing
                Address1.HeaderText = "Address 1"
                Address1.MappingName = "Address1"
                Address1.ReadOnly = True
                Address1.Width = 100
                Address1.NullText = ""
                tStyle.GridColumnStyles.Add(Address1)

                Dim Town As New DataGridLabelColumn
                Town.Format = ""
                Town.FormatInfo = Nothing
                Town.HeaderText = "Address 2"
                Town.MappingName = "Address2"
                Town.ReadOnly = True
                Town.Width = 100
                Town.NullText = ""
                tStyle.GridColumnStyles.Add(Town)

                Dim County As New DataGridLabelColumn
                County.Format = ""
                County.FormatInfo = Nothing
                County.HeaderText = "Address 3"
                County.MappingName = "Address3"
                County.ReadOnly = True
                County.Width = 100
                County.NullText = ""
                tStyle.GridColumnStyles.Add(County)

                Dim Address4 As New DataGridLabelColumn
                Address4.Format = ""
                Address4.FormatInfo = Nothing
                Address4.HeaderText = "Address 4"
                Address4.MappingName = "Address4"
                Address4.ReadOnly = True
                Address4.Width = 100
                Address4.NullText = ""
                tStyle.GridColumnStyles.Add(Address4)

                Dim Address5 As New DataGridLabelColumn
                Address5.Format = ""
                Address5.FormatInfo = Nothing
                Address5.HeaderText = "Address 5"
                Address5.MappingName = "Address5"
                Address5.ReadOnly = True
                Address5.Width = 100
                Address5.NullText = ""
                tStyle.GridColumnStyles.Add(Address5)

                Dim Postcode As New DataGridLabelColumn
                Postcode.Format = ""
                Postcode.FormatInfo = Nothing
                Postcode.HeaderText = "Postcode"
                Postcode.MappingName = "Postcode"
                Postcode.ReadOnly = True
                Postcode.Width = 100
                Postcode.NullText = ""
                tStyle.GridColumnStyles.Add(Postcode)

                Dim TelephoneNum As New DataGridLabelColumn
                TelephoneNum.Format = ""
                TelephoneNum.FormatInfo = Nothing
                TelephoneNum.HeaderText = "Tel"
                TelephoneNum.MappingName = "TelephoneNum"
                TelephoneNum.ReadOnly = True
                TelephoneNum.Width = 100
                TelephoneNum.NullText = ""
                tStyle.GridColumnStyles.Add(TelephoneNum)

            Case Entity.Sys.Enums.TableNames.tblWarehouse

                Dim Name As New DataGridLabelColumn
                Name.Format = ""
                Name.FormatInfo = Nothing
                Name.HeaderText = "Name"
                Name.MappingName = "Name"
                Name.ReadOnly = True
                Name.Width = 100
                Name.NullText = ""
                tStyle.GridColumnStyles.Add(Name)

                Dim Address1 As New DataGridLabelColumn
                Address1.Format = ""
                Address1.FormatInfo = Nothing
                Address1.HeaderText = "Address 1"
                Address1.MappingName = "Address1"
                Address1.ReadOnly = True
                Address1.Width = 100
                Address1.NullText = ""
                tStyle.GridColumnStyles.Add(Address1)

                Dim Address2 As New DataGridLabelColumn
                Address2.Format = ""
                Address2.FormatInfo = Nothing
                Address2.HeaderText = "Address 2"
                Address2.MappingName = "Address2"
                Address2.ReadOnly = True
                Address2.Width = 100
                Address2.NullText = ""
                tStyle.GridColumnStyles.Add(Address2)

                Dim Address3 As New DataGridLabelColumn
                Address3.Format = ""
                Address3.FormatInfo = Nothing
                Address3.HeaderText = "Address 3"
                Address3.MappingName = "Address3"
                Address3.ReadOnly = True
                Address3.Width = 100
                Address3.NullText = ""
                tStyle.GridColumnStyles.Add(Address3)

                Dim Address4 As New DataGridLabelColumn
                Address4.Format = ""
                Address4.FormatInfo = Nothing
                Address4.HeaderText = "Address 4"
                Address4.MappingName = "Address4"
                Address4.ReadOnly = True
                Address4.Width = 100
                Address4.NullText = ""
                tStyle.GridColumnStyles.Add(Address4)

                Dim Address5 As New DataGridLabelColumn
                Address5.Format = ""
                Address5.FormatInfo = Nothing
                Address5.HeaderText = "Address 5"
                Address5.MappingName = "Address5"
                Address5.ReadOnly = True
                Address5.Width = 100
                Address5.NullText = ""
                tStyle.GridColumnStyles.Add(Address5)

                Dim Postcode As New DataGridLabelColumn
                Postcode.Format = ""
                Postcode.FormatInfo = Nothing
                Postcode.HeaderText = "Postcode"
                Postcode.MappingName = "Postcode"
                Postcode.ReadOnly = True
                Postcode.Width = 100
                Postcode.NullText = ""
                tStyle.GridColumnStyles.Add(Postcode)

                Dim TelephoneNum As New DataGridLabelColumn
                TelephoneNum.Format = ""
                TelephoneNum.FormatInfo = Nothing
                TelephoneNum.HeaderText = "Tel"
                TelephoneNum.MappingName = "TelephoneNum"
                TelephoneNum.ReadOnly = True
                TelephoneNum.Width = 100
                TelephoneNum.NullText = ""
                tStyle.GridColumnStyles.Add(TelephoneNum)

            Case Entity.Sys.Enums.TableNames.tblVan

                Dim Name As New DataGridLabelColumn
                Name.Format = ""
                Name.FormatInfo = Nothing
                Name.HeaderText = "Engineer Name"
                Name.MappingName = "EngineerName"
                Name.ReadOnly = True
                Name.Width = 100
                Name.NullText = ""
                tStyle.GridColumnStyles.Add(Name)

                Dim Registration As New DataGridLabelColumn
                Registration.Format = ""
                Registration.FormatInfo = Nothing
                Registration.HeaderText = "Stock Profile Name"
                Registration.MappingName = "Registration"
                Registration.ReadOnly = True
                Registration.Width = 150
                Registration.NullText = ""
                tStyle.GridColumnStyles.Add(Registration)

            Case Entity.Sys.Enums.TableNames.tblPart
                If ForMassPartEntry Then
                    tStyle.ReadOnly = False
                    dgResults.ReadOnly = False

                    Dim QuantityToAdd As New DataGridEditableTextBoxColumn
                    QuantityToAdd.BackColourBrush = Brushes.LightYellow
                    QuantityToAdd.Format = ""
                    QuantityToAdd.FormatInfo = Nothing
                    QuantityToAdd.HeaderText = "Add"
                    QuantityToAdd.MappingName = "QuantityToAdd"
                    QuantityToAdd.ReadOnly = False
                    QuantityToAdd.Width = 130
                    QuantityToAdd.NullText = ""
                    tStyle.GridColumnStyles.Add(QuantityToAdd)
                End If

                Dim PartName As New DataGridLabelColumn
                PartName.Format = ""
                PartName.FormatInfo = Nothing
                PartName.HeaderText = "Name"
                PartName.MappingName = "Name"
                PartName.ReadOnly = True
                PartName.Width = 130
                PartName.NullText = ""
                tStyle.GridColumnStyles.Add(PartName)

                Dim PartNumber As New DataGridLabelColumn
                PartNumber.Format = ""
                PartNumber.FormatInfo = Nothing
                PartNumber.HeaderText = "Number (MPN)"
                PartNumber.MappingName = "Number"
                PartNumber.ReadOnly = True
                PartNumber.Width = 130
                PartNumber.NullText = ""
                tStyle.GridColumnStyles.Add(PartNumber)

                Dim PartReference As New DataGridLabelColumn
                PartReference.Format = ""
                PartReference.FormatInfo = Nothing
                PartReference.HeaderText = "Reference"
                PartReference.MappingName = "Reference"
                PartReference.ReadOnly = True
                PartReference.Width = 200
                PartReference.NullText = ""
                tStyle.GridColumnStyles.Add(PartReference)

                Dim Quantity As New DataGridLabelColumn
                Quantity.Format = ""
                Quantity.FormatInfo = Nothing
                Quantity.HeaderText = "Qty"
                Quantity.MappingName = "WarehouseQuantity"
                Quantity.ReadOnly = True
                Quantity.Width = 50
                Quantity.NullText = ""
                tStyle.GridColumnStyles.Add(Quantity)

                Dim UnitType As New DataGridLabelColumn
                UnitType.Format = ""
                UnitType.FormatInfo = Nothing
                UnitType.HeaderText = "Unit Type"
                UnitType.MappingName = "UnitType"
                UnitType.ReadOnly = True
                UnitType.Width = 130
                UnitType.NullText = ""
                tStyle.GridColumnStyles.Add(UnitType)

                Dim SellPrice As New DataGridLabelColumn
                SellPrice.Format = "C"
                SellPrice.FormatInfo = Nothing
                SellPrice.HeaderText = "Sell Price"
                SellPrice.MappingName = "SellPrice"
                SellPrice.ReadOnly = True
                SellPrice.Width = 120
                SellPrice.NullText = ""
                tStyle.GridColumnStyles.Add(SellPrice)

            Case Entity.Sys.Enums.TableNames.tblProduct

                Dim ProductName As New DataGridLabelColumn
                ProductName.Format = ""
                ProductName.FormatInfo = Nothing
                ProductName.HeaderText = "Description"
                ProductName.MappingName = "typemakemodel"
                ProductName.ReadOnly = True
                ProductName.Width = 200
                ProductName.NullText = ""
                tStyle.GridColumnStyles.Add(ProductName)

                Dim ProductNumber As New DataGridLabelColumn
                ProductNumber.Format = ""
                ProductNumber.FormatInfo = Nothing
                ProductNumber.HeaderText = "GC Number"
                ProductNumber.MappingName = "Number"
                ProductNumber.ReadOnly = True
                ProductNumber.Width = 120
                ProductNumber.NullText = ""
                tStyle.GridColumnStyles.Add(ProductNumber)

                Dim ProductReference As New DataGridLabelColumn
                ProductReference.Format = ""
                ProductReference.FormatInfo = Nothing
                ProductReference.HeaderText = "Product Reference"
                ProductReference.MappingName = "Reference"
                ProductReference.ReadOnly = True
                ProductReference.Width = 200
                ProductReference.NullText = ""
                tStyle.GridColumnStyles.Add(ProductReference)

            Case Entity.Sys.Enums.TableNames.tblInvoiceAddress

                Dim Address1 As New DataGridLabelColumn
                Address1.Format = ""
                Address1.FormatInfo = Nothing
                Address1.HeaderText = "Address 1"
                Address1.MappingName = "Address1"
                Address1.ReadOnly = True
                Address1.Width = 100
                Address1.NullText = ""
                tStyle.GridColumnStyles.Add(Address1)

                Dim Address2 As New DataGridLabelColumn
                Address2.Format = ""
                Address2.FormatInfo = Nothing
                Address2.HeaderText = "Address 2"
                Address2.MappingName = "Address2"
                Address2.ReadOnly = True
                Address2.Width = 100
                Address2.NullText = ""
                tStyle.GridColumnStyles.Add(Address2)

                Dim Address3 As New DataGridLabelColumn
                Address3.Format = ""
                Address3.FormatInfo = Nothing
                Address3.HeaderText = "Address 3"
                Address3.MappingName = "Address3"
                Address3.ReadOnly = True
                Address3.Width = 100
                Address3.NullText = ""
                tStyle.GridColumnStyles.Add(Address3)

                Dim Address4 As New DataGridLabelColumn
                Address4.Format = ""
                Address4.FormatInfo = Nothing
                Address4.HeaderText = "Address 4"
                Address4.MappingName = "Address4"
                Address4.ReadOnly = True
                Address4.Width = 100
                Address4.NullText = ""
                tStyle.GridColumnStyles.Add(Address4)

                Dim Address5 As New DataGridLabelColumn
                Address5.Format = ""
                Address5.FormatInfo = Nothing
                Address5.HeaderText = "Address5"
                Address5.MappingName = "Address5"
                Address5.ReadOnly = True
                Address5.Width = 100
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

            Case Entity.Sys.Enums.TableNames.tblContact
                Dim FirstName As New DataGridLabelColumn
                FirstName.Format = ""
                FirstName.FormatInfo = Nothing
                FirstName.HeaderText = "First Name"
                FirstName.MappingName = "FirstName"
                FirstName.ReadOnly = True
                FirstName.Width = 160
                FirstName.NullText = ""
                tStyle.GridColumnStyles.Add(FirstName)

                Dim Surname As New DataGridLabelColumn
                Surname.Format = ""
                Surname.FormatInfo = Nothing
                Surname.HeaderText = "Surname"
                Surname.MappingName = "Surname"
                Surname.ReadOnly = True
                Surname.Width = 160
                Surname.NullText = ""
                tStyle.GridColumnStyles.Add(Surname)

                Dim Email As New DataGridLabelColumn
                Email.Format = ""
                Email.FormatInfo = Nothing
                Email.HeaderText = "Email"
                Email.MappingName = "EmailAddress"
                Email.ReadOnly = True
                Email.Width = 120
                Email.NullText = ""
                tStyle.GridColumnStyles.Add(Email)

                Dim TelephoneNum As New DataGridLabelColumn
                TelephoneNum.Format = ""
                TelephoneNum.FormatInfo = Nothing
                TelephoneNum.HeaderText = "Telephone Number"
                TelephoneNum.MappingName = "TelephoneNum"
                TelephoneNum.ReadOnly = True
                TelephoneNum.Width = 100
                TelephoneNum.NullText = ""
                tStyle.GridColumnStyles.Add(TelephoneNum)

            Case Entity.Sys.Enums.TableNames.tblPartSupplier

                Dim Supplier As New DataGridLabelColumn
                Supplier.Format = ""
                Supplier.FormatInfo = Nothing
                Supplier.HeaderText = "Supplier"
                Supplier.MappingName = "Supplier"
                Supplier.ReadOnly = True
                Supplier.Width = 130
                Supplier.NullText = ""
                tStyle.GridColumnStyles.Add(Supplier)

                Dim PartName As New DataGridLabelColumn
                PartName.Format = ""
                PartName.FormatInfo = Nothing
                PartName.HeaderText = "Name"
                PartName.MappingName = "Name"
                PartName.ReadOnly = True
                PartName.Width = 130
                PartName.NullText = ""
                tStyle.GridColumnStyles.Add(PartName)

                Dim PartNumber As New DataGridLabelColumn
                PartNumber.Format = ""
                PartNumber.FormatInfo = Nothing
                PartNumber.HeaderText = "Part Number (MPN)"
                PartNumber.MappingName = "Number"
                PartNumber.ReadOnly = True
                PartNumber.Width = 130
                PartNumber.NullText = ""
                tStyle.GridColumnStyles.Add(PartNumber)

                Dim QuantityInPack As New DataGridLabelColumn
                QuantityInPack.Format = ""
                QuantityInPack.FormatInfo = Nothing
                QuantityInPack.HeaderText = "Quantity In Pack"
                QuantityInPack.MappingName = "QuantityInPack"
                QuantityInPack.ReadOnly = True
                QuantityInPack.Width = 130
                QuantityInPack.NullText = ""
                tStyle.GridColumnStyles.Add(QuantityInPack)

                Dim PartCode As New DataGridLabelColumn
                PartCode.Format = ""
                PartCode.FormatInfo = Nothing
                PartCode.HeaderText = "Supplier Part Number (SPN)"
                PartCode.MappingName = "PartCode"
                PartCode.ReadOnly = True
                PartCode.Width = 130
                PartCode.NullText = ""
                tStyle.GridColumnStyles.Add(PartCode)

                Dim Price As New DataGridLabelColumn
                Price.Format = ""
                Price.FormatInfo = Nothing
                Price.HeaderText = "Price"
                Price.MappingName = "Price"
                Price.ReadOnly = True
                Price.Width = 130
                Price.NullText = ""
                tStyle.GridColumnStyles.Add(Price)

            Case Entity.Sys.Enums.TableNames.tblProductSupplier

                Dim Supplier As New DataGridLabelColumn
                Supplier.Format = ""
                Supplier.FormatInfo = Nothing
                Supplier.HeaderText = "Supplier"
                Supplier.MappingName = "Supplier"
                Supplier.ReadOnly = True
                Supplier.Width = 130
                Supplier.NullText = ""
                tStyle.GridColumnStyles.Add(Supplier)

                Dim ProductName As New DataGridLabelColumn
                ProductName.Format = ""
                ProductName.FormatInfo = Nothing
                ProductName.HeaderText = "Name"
                ProductName.MappingName = "Name"
                ProductName.ReadOnly = True
                ProductName.Width = 130
                ProductName.NullText = ""
                tStyle.GridColumnStyles.Add(ProductName)

                Dim ProductNumber As New DataGridLabelColumn
                ProductNumber.Format = ""
                ProductNumber.FormatInfo = Nothing
                ProductNumber.HeaderText = "Product Number"
                ProductNumber.MappingName = "Number"
                ProductNumber.ReadOnly = True
                ProductNumber.Width = 130
                ProductNumber.NullText = ""
                tStyle.GridColumnStyles.Add(ProductNumber)

                Dim QuantityInPack As New DataGridLabelColumn
                QuantityInPack.Format = ""
                QuantityInPack.FormatInfo = Nothing
                QuantityInPack.HeaderText = "Quantity In Pack"
                QuantityInPack.MappingName = "QuantityInPack"
                QuantityInPack.ReadOnly = True
                QuantityInPack.Width = 130
                QuantityInPack.NullText = ""
                tStyle.GridColumnStyles.Add(QuantityInPack)

                Dim ProductCode As New DataGridLabelColumn
                ProductCode.Format = ""
                ProductCode.FormatInfo = Nothing
                ProductCode.HeaderText = "Supplier Product Number"
                ProductCode.MappingName = "ProductCode"
                ProductCode.ReadOnly = True
                ProductCode.Width = 130
                ProductCode.NullText = ""
                tStyle.GridColumnStyles.Add(ProductCode)

                Dim Price As New DataGridLabelColumn
                Price.Format = ""
                Price.FormatInfo = Nothing
                Price.HeaderText = "Price"
                Price.MappingName = "Price"
                Price.ReadOnly = True
                Price.Width = 130
                Price.NullText = ""
                tStyle.GridColumnStyles.Add(Price)

            Case Entity.Sys.Enums.TableNames.tblSupplier, Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForPart, Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForProduct
                If TableToSearch = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForPart Then
                    If ForeignKeyFilter > 0 Then
                        Dim Preferred As New ColourColumn
                        Preferred.Format = ""
                        Preferred.FormatInfo = Nothing
                        Preferred.HeaderText = "Preferred"
                        Preferred.MappingName = "Preferred"
                        Preferred.ReadOnly = True
                        Preferred.Width = 25
                        Preferred.NullText = ""
                        tStyle.GridColumnStyles.Add(Preferred)
                    End If
                End If

                Dim Name As New DataGridLabelColumn
                Name.Format = ""
                Name.FormatInfo = Nothing
                Name.HeaderText = "Name"
                Name.MappingName = "Name"
                Name.ReadOnly = True
                Name.Width = 130
                Name.NullText = ""
                tStyle.GridColumnStyles.Add(Name)

                Dim Address1 As New DataGridLabelColumn
                Address1.Format = ""
                Address1.FormatInfo = Nothing
                Address1.HeaderText = "Address1"
                Address1.MappingName = "Address1"
                Address1.ReadOnly = True
                Address1.Width = 130
                Address1.NullText = ""
                tStyle.GridColumnStyles.Add(Address1)

                Dim Price As New DataGridLabelColumn
                Price.Format = ""
                Price.FormatInfo = Nothing
                Price.HeaderText = "Price"
                Price.MappingName = "Price"
                Price.ReadOnly = True
                Price.Width = 130
                Price.NullText = ""
                tStyle.GridColumnStyles.Add(Price)

                Dim Address2 As New DataGridLabelColumn
                Address2.Format = ""
                Address2.FormatInfo = Nothing
                Address2.HeaderText = "Address2"
                Address2.MappingName = "Address2"
                Address2.ReadOnly = True
                Address2.Width = 130
                Address2.NullText = ""
                tStyle.GridColumnStyles.Add(Address2)

                Dim Address3 As New DataGridLabelColumn
                Address3.Format = ""
                Address3.FormatInfo = Nothing
                Address3.HeaderText = "Address3"
                Address3.MappingName = "Address3"
                Address3.ReadOnly = True
                Address3.Width = 130
                Address3.NullText = ""
                tStyle.GridColumnStyles.Add(Address3)

                Dim Address4 As New DataGridLabelColumn
                Address4.Format = ""
                Address4.FormatInfo = Nothing
                Address4.HeaderText = "Address4"
                Address4.MappingName = "Address4"
                Address4.ReadOnly = True
                Address4.Width = 130
                Address4.NullText = ""
                tStyle.GridColumnStyles.Add(Address4)

                Dim Address5 As New DataGridLabelColumn
                Address5.Format = ""
                Address5.FormatInfo = Nothing
                Address5.HeaderText = "Address5"
                Address5.MappingName = "Address5"
                Address5.ReadOnly = True
                Address5.Width = 130
                Address5.NullText = ""
                tStyle.GridColumnStyles.Add(Address5)

                Dim Postcode As New DataGridLabelColumn
                Postcode.Format = ""
                Postcode.FormatInfo = Nothing
                Postcode.HeaderText = "Postcode"
                Postcode.MappingName = "Postcode"
                Postcode.ReadOnly = True
                Postcode.Width = 130
                Postcode.NullText = ""
                tStyle.GridColumnStyles.Add(Postcode)

                Dim TelephoneNum As New DataGridLabelColumn
                TelephoneNum.Format = ""
                TelephoneNum.FormatInfo = Nothing
                TelephoneNum.HeaderText = "Telephone"
                TelephoneNum.MappingName = "TelephoneNum"
                TelephoneNum.ReadOnly = True
                TelephoneNum.Width = 130
                TelephoneNum.NullText = ""
                tStyle.GridColumnStyles.Add(TelephoneNum)

            Case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_VansForPart, Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_VansForProduct

                Dim EngName As New DataGridLabelColumn
                EngName.Format = ""
                EngName.FormatInfo = Nothing
                EngName.HeaderText = "Engineer Name"
                EngName.MappingName = "EngineerName"
                EngName.ReadOnly = True
                EngName.Width = 100
                EngName.NullText = ""
                tStyle.GridColumnStyles.Add(EngName)

                Dim Registration As New DataGridLabelColumn
                Registration.Format = ""
                Registration.FormatInfo = Nothing
                Registration.HeaderText = "Registration"
                Registration.MappingName = "Registration"
                Registration.ReadOnly = True
                Registration.Width = 100
                Registration.NullText = ""
                tStyle.GridColumnStyles.Add(Registration)

                Dim Name As New DataGridLabelColumn
                Name.Format = ""
                Name.FormatInfo = Nothing
                Name.HeaderText = "Item Name"
                Name.MappingName = "Name"
                Name.ReadOnly = True
                Name.Width = 100
                Name.NullText = ""
                tStyle.GridColumnStyles.Add(Name)

                Dim Number As New DataGridLabelColumn
                Number.Format = ""
                Number.FormatInfo = Nothing
                Number.HeaderText = "Item Number"
                Number.MappingName = "Number"
                Number.ReadOnly = True
                Number.Width = 100
                Number.NullText = ""
                tStyle.GridColumnStyles.Add(Name)

                Dim Amount As New DataGridLabelColumn
                Amount.Format = ""
                Amount.FormatInfo = Nothing
                Amount.HeaderText = "Amount"
                Amount.MappingName = "Amount"
                Amount.ReadOnly = True
                Amount.Width = 100
                Amount.NullText = ""
                tStyle.GridColumnStyles.Add(Amount)

            Case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehouseForPart, Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehouseForProduct

                Dim Name As New DataGridLabelColumn
                Name.Format = ""
                Name.FormatInfo = Nothing
                Name.HeaderText = "Name"
                Name.MappingName = "warehouseName"
                Name.ReadOnly = True
                Name.Width = 100
                Name.NullText = ""
                tStyle.GridColumnStyles.Add(Name)

                Dim Address1 As New DataGridLabelColumn
                Address1.Format = ""
                Address1.FormatInfo = Nothing
                Address1.HeaderText = "Address 1"
                Address1.MappingName = "Address1"
                Address1.ReadOnly = True
                Address1.Width = 100
                Address1.NullText = ""
                tStyle.GridColumnStyles.Add(Address1)

                Dim Postcode As New DataGridLabelColumn
                Postcode.Format = ""
                Postcode.FormatInfo = Nothing
                Postcode.HeaderText = "Postcode"
                Postcode.MappingName = "Postcode"
                Postcode.ReadOnly = True
                Postcode.Width = 100
                Postcode.NullText = ""
                tStyle.GridColumnStyles.Add(Postcode)

                Dim TelephoneNum As New DataGridLabelColumn
                TelephoneNum.Format = ""
                TelephoneNum.FormatInfo = Nothing
                TelephoneNum.HeaderText = "Tel"
                TelephoneNum.MappingName = "TelephoneNum"
                TelephoneNum.ReadOnly = True
                TelephoneNum.Width = 100
                TelephoneNum.NullText = ""
                tStyle.GridColumnStyles.Add(TelephoneNum)

                Dim Amount As New DataGridLabelColumn
                Amount.Format = ""
                Amount.FormatInfo = Nothing
                Amount.HeaderText = "Amount"
                Amount.MappingName = "Amount"
                Amount.ReadOnly = True
                Amount.Width = 100
                Amount.NullText = ""
                tStyle.GridColumnStyles.Add(Amount)

            Case Entity.Sys.Enums.TableNames.tblJob

                Dim JobNumber As New DataGridLabelColumn
                JobNumber.Format = ""
                JobNumber.FormatInfo = Nothing
                JobNumber.HeaderText = "Job Number"
                JobNumber.MappingName = "JobNumber"
                JobNumber.ReadOnly = True
                JobNumber.Width = 100
                JobNumber.NullText = ""
                tStyle.GridColumnStyles.Add(JobNumber)

                'Dim PONumber As New DataGridLabelColumn
                'PONumber.Format = ""
                'PONumber.FormatInfo = Nothing
                'PONumber.HeaderText = "PO Number"
                'PONumber.MappingName = "PONumber"
                'PONumber.ReadOnly = True
                'PONumber.Width = 100
                'PONumber.NullText = ""
                'tStyle.GridColumnStyles.Add(PONumber)

                Dim DateCreated As New DataGridLabelColumn
                DateCreated.Format = "dd/MMM/yyyy"
                DateCreated.FormatInfo = Nothing
                DateCreated.HeaderText = "Date Created"
                DateCreated.MappingName = "DateCreated"
                DateCreated.ReadOnly = True
                DateCreated.Width = 100
                DateCreated.NullText = ""
                tStyle.GridColumnStyles.Add(DateCreated)

                Dim Definition As New DataGridLabelColumn
                Definition.Format = ""
                Definition.FormatInfo = Nothing
                Definition.HeaderText = "Definition"
                Definition.MappingName = "JobDefinition"
                Definition.ReadOnly = True
                Definition.Width = 100
                Definition.NullText = ""
                tStyle.GridColumnStyles.Add(Definition)

                Dim Type As New DataGridLabelColumn
                Type.Format = ""
                Type.FormatInfo = Nothing
                Type.HeaderText = "Type"
                Type.MappingName = "Type"
                Type.ReadOnly = True
                Type.Width = 100
                Type.NullText = Entity.Sys.Enums.ComboValues.Not_Applicable.ToString.Replace("_", " ")
                tStyle.GridColumnStyles.Add(Type)

                Dim JobStatus As New DataGridLabelColumn
                JobStatus.Format = ""
                JobStatus.FormatInfo = Nothing
                JobStatus.HeaderText = "Status"
                JobStatus.MappingName = "JobStatus"
                JobStatus.ReadOnly = True
                JobStatus.Width = 100
                JobStatus.NullText = ""
                tStyle.GridColumnStyles.Add(JobStatus)

                Dim CreatedBy As New DataGridLabelColumn
                CreatedBy.Format = ""
                CreatedBy.FormatInfo = Nothing
                CreatedBy.HeaderText = "Created By"
                CreatedBy.MappingName = "CreatedBy"
                CreatedBy.ReadOnly = True
                CreatedBy.Width = 100
                CreatedBy.NullText = ""
                tStyle.GridColumnStyles.Add(CreatedBy)

            Case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehousesAndVans
                Dim LocationType As New DataGridLabelColumn
                LocationType.Format = ""
                LocationType.FormatInfo = Nothing
                LocationType.HeaderText = "Location Type"
                LocationType.MappingName = "LocationType"
                LocationType.ReadOnly = True
                LocationType.Width = 100
                LocationType.NullText = ""
                tStyle.GridColumnStyles.Add(LocationType)

                Dim Location As New DataGridLabelColumn
                Location.Format = ""
                Location.FormatInfo = Nothing
                Location.HeaderText = "Location"
                Location.MappingName = "Name"
                Location.ReadOnly = True
                Location.Width = 100
                Location.NullText = ""
                tStyle.GridColumnStyles.Add(Location)

            Case Entity.Sys.Enums.TableNames.tblEngineer
                Dim Name As New DataGridLabelColumn
                Name.Format = ""
                Name.FormatInfo = Nothing
                Name.HeaderText = "Name"
                Name.MappingName = "Name"
                Name.ReadOnly = True
                Name.Width = 200
                Name.NullText = ""
                tStyle.GridColumnStyles.Add(Name)

                Dim TelephoneNum As New DataGridLabelColumn
                TelephoneNum.Format = ""
                TelephoneNum.FormatInfo = Nothing
                TelephoneNum.HeaderText = "Telephone Number"
                TelephoneNum.MappingName = "TelephoneNum"
                TelephoneNum.ReadOnly = True
                TelephoneNum.Width = 200
                TelephoneNum.NullText = ""
                tStyle.GridColumnStyles.Add(TelephoneNum)

                Dim Region As New DataGridLabelColumn
                Region.Format = ""
                Region.FormatInfo = Nothing
                Region.HeaderText = "Region"
                Region.MappingName = "Region"
                Region.ReadOnly = True
                Region.Width = 200
                Region.NullText = ""
                tStyle.GridColumnStyles.Add(Region)
            Case Entity.Sys.Enums.TableNames.tblOrder
                Dim DateCreated As New DataGridLabelColumn
                DateCreated.Format = "dd/MMM/yyyy"
                DateCreated.FormatInfo = Nothing
                DateCreated.HeaderText = "Date Placed"
                DateCreated.MappingName = "DatePlaced"
                DateCreated.ReadOnly = True
                DateCreated.Width = 90
                DateCreated.NullText = ""
                tStyle.GridColumnStyles.Add(DateCreated)

                Dim DeliveryDeadline As New DataGridLabelColumn
                DeliveryDeadline.Format = "dd/MMM/yyyy"
                DeliveryDeadline.FormatInfo = Nothing
                DeliveryDeadline.HeaderText = "Delivery Deadline"
                DeliveryDeadline.MappingName = "DeliveryDeadline"
                DeliveryDeadline.ReadOnly = True
                DeliveryDeadline.Width = 90
                DeliveryDeadline.NullText = ""
                tStyle.GridColumnStyles.Add(DeliveryDeadline)

                Dim OrderReference As New DataGridLabelColumn
                OrderReference.Format = ""
                OrderReference.FormatInfo = Nothing
                OrderReference.HeaderText = "Order Reference"
                OrderReference.MappingName = "OrderReference"
                OrderReference.ReadOnly = True
                OrderReference.Width = 110
                OrderReference.NullText = ""
                tStyle.GridColumnStyles.Add(OrderReference)

                Dim ConsolidationRef As New DataGridLabelColumn
                ConsolidationRef.Format = ""
                ConsolidationRef.FormatInfo = Nothing
                ConsolidationRef.HeaderText = "Consol Ref"
                ConsolidationRef.MappingName = "ConsolidationRef"
                ConsolidationRef.ReadOnly = True
                ConsolidationRef.Width = 110
                ConsolidationRef.NullText = ""
                tStyle.GridColumnStyles.Add(ConsolidationRef)

                Dim Type As New DataGridLabelColumn
                Type.Format = ""
                Type.FormatInfo = Nothing
                Type.HeaderText = "Type"
                Type.MappingName = "Type"
                Type.ReadOnly = True
                Type.Width = 75
                Type.NullText = Entity.Sys.Enums.ComboValues.Not_Applicable.ToString.Replace("_", " ")
                tStyle.GridColumnStyles.Add(Type)

                Dim Customer As New DataGridLabelColumn
                Customer.Format = ""
                Customer.FormatInfo = Nothing
                Customer.HeaderText = "Customer"
                Customer.MappingName = "Customer"
                Customer.ReadOnly = True
                Customer.Width = 140
                Customer.NullText = "N/A"
                tStyle.GridColumnStyles.Add(Customer)

                Dim Site As New DataGridLabelColumn
                Site.Format = ""
                Site.FormatInfo = Nothing
                Site.HeaderText = "Property"
                Site.MappingName = "Site"
                Site.ReadOnly = True
                Site.Width = 140
                Site.NullText = "N/A"
                tStyle.GridColumnStyles.Add(Site)

                Dim Supplier As New DataGridLabelColumn
                Supplier.Format = ""
                Supplier.FormatInfo = Nothing
                Supplier.HeaderText = "Supplier"
                Supplier.MappingName = "Supplier"
                Supplier.ReadOnly = True
                Supplier.Width = 100
                Supplier.NullText = "N/A"
                tStyle.GridColumnStyles.Add(Supplier)

                Dim JobNumber As New DataGridLabelColumn
                JobNumber.Format = ""
                JobNumber.FormatInfo = Nothing
                JobNumber.HeaderText = "Job Number"
                JobNumber.MappingName = "JobNumber"
                JobNumber.ReadOnly = True
                JobNumber.Width = 100
                JobNumber.NullText = "N/A"
                tStyle.GridColumnStyles.Add(JobNumber)

                Dim OrderStatus As New DataGridLabelColumn
                OrderStatus.Format = ""
                OrderStatus.FormatInfo = Nothing
                OrderStatus.HeaderText = "Status"
                OrderStatus.MappingName = "DisplayStatus"
                OrderStatus.ReadOnly = True
                OrderStatus.Width = 120
                OrderStatus.NullText = ""
                tStyle.GridColumnStyles.Add(OrderStatus)

                Dim SupplierExported As New DataGridLabelColumn
                SupplierExported.Format = ""
                SupplierExported.FormatInfo = Nothing
                SupplierExported.HeaderText = "Sup Inv Sent to Sage"
                SupplierExported.MappingName = "SupplierExported"
                SupplierExported.ReadOnly = True
                SupplierExported.Width = 50
                SupplierExported.NullText = ""
                tStyle.GridColumnStyles.Add(SupplierExported)

                Dim BuyPrice As New DataGridLabelColumn
                BuyPrice.Format = "C"
                BuyPrice.FormatInfo = Nothing
                BuyPrice.HeaderText = "Buy Price"
                BuyPrice.MappingName = "BuyPrice"
                BuyPrice.ReadOnly = True
                BuyPrice.Width = 75
                BuyPrice.NullText = "0"
                tStyle.GridColumnStyles.Add(BuyPrice)

                Dim SellPrice As New DataGridLabelColumn
                SellPrice.Format = "C"
                SellPrice.FormatInfo = Nothing
                SellPrice.HeaderText = "Sell Price"
                SellPrice.MappingName = "SellPrice"
                SellPrice.ReadOnly = True
                SellPrice.Width = 75
                SellPrice.NullText = "£0.00"
                tStyle.GridColumnStyles.Add(SellPrice)

                Dim CreatedBy As New DataGridLabelColumn
                CreatedBy.Format = ""
                CreatedBy.FormatInfo = Nothing
                CreatedBy.HeaderText = "Created By"
                CreatedBy.MappingName = "CreatedBy"
                CreatedBy.ReadOnly = True
                CreatedBy.Width = 100
                CreatedBy.NullText = ""
                tStyle.GridColumnStyles.Add(CreatedBy)

            Case Entity.Sys.Enums.TableNames.tblFleetVan
                Dim registration As New DataGridLabelColumn
                registration.Format = ""
                registration.FormatInfo = Nothing
                registration.HeaderText = "Registration"
                registration.MappingName = "Registration"
                registration.ReadOnly = True
                registration.Width = 150
                registration.NullText = ""
                tStyle.GridColumnStyles.Add(registration)

                Dim make As New DataGridLabelColumn
                make.Format = ""
                make.FormatInfo = Nothing
                make.HeaderText = "Engineer"
                make.MappingName = "Name"
                make.ReadOnly = True
                make.Width = 350
                make.NullText = ""
                tStyle.GridColumnStyles.Add(make)

            Case Entity.Sys.Enums.TableNames.tblFleetVanFault
                Dim registration As New DataGridLabelColumn
                registration.Format = ""
                registration.FormatInfo = Nothing
                registration.HeaderText = "Registration"
                registration.MappingName = "Registration"
                registration.ReadOnly = True
                registration.Width = 150
                registration.NullText = ""
                tStyle.GridColumnStyles.Add(registration)

                Dim fault As New DataGridLabelColumn
                fault.Format = ""
                fault.FormatInfo = Nothing
                fault.HeaderText = "Fault"
                fault.MappingName = "Name"
                fault.ReadOnly = True
                fault.Width = 150
                fault.NullText = ""
                tStyle.GridColumnStyles.Add(fault)

                Dim faultDate As New DataGridLabelColumn
                faultDate.Format = ""
                faultDate.FormatInfo = Nothing
                faultDate.HeaderText = "Fault Date"
                faultDate.MappingName = "FaultDate"
                faultDate.ReadOnly = True
                faultDate.Width = 250
                faultDate.NullText = ""
                tStyle.GridColumnStyles.Add(faultDate)
            Case Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate

                Dim Category As New DataGridLabelColumn
                Category.Format = ""
                Category.FormatInfo = Nothing
                Category.HeaderText = "Category"
                Category.MappingName = "Category"
                Category.ReadOnly = True
                Category.Width = 100
                Category.NullText = ""
                tStyle.GridColumnStyles.Add(Category)

                Dim Code As New DataGridLabelColumn
                Code.Format = ""
                Code.FormatInfo = Nothing
                Code.HeaderText = "Code"
                Code.MappingName = "Code"
                Code.ReadOnly = True
                Code.Width = 100
                Code.NullText = ""
                tStyle.GridColumnStyles.Add(Code)

                Dim Description As New DataGridLabelColumn
                Description.Format = ""
                Description.FormatInfo = Nothing
                Description.HeaderText = "Description"
                Description.MappingName = "Description"
                Description.ReadOnly = True
                Description.Width = 250
                Description.NullText = ""
                tStyle.GridColumnStyles.Add(Description)

                Dim TimeInMins As New DataGridLabelColumn
                TimeInMins.Format = ""
                TimeInMins.FormatInfo = Nothing
                TimeInMins.HeaderText = "Time (Mins)"
                TimeInMins.MappingName = "TimeInMins"
                TimeInMins.ReadOnly = True
                TimeInMins.Width = 80
                TimeInMins.NullText = ""
                tStyle.GridColumnStyles.Add(TimeInMins)

                Dim Price As New DataGridLabelColumn
                Price.Format = "C"
                Price.FormatInfo = Nothing
                Price.HeaderText = "Unit Price"
                Price.MappingName = "Price"
                Price.ReadOnly = True
                Price.Width = 80
                Price.NullText = ""
                tStyle.GridColumnStyles.Add(Price)

            Case Entity.Sys.Enums.TableNames.tblEngineerSkills
                Dim Name As New DataGridLabelColumn
                Name.Format = ""
                Name.FormatInfo = Nothing
                Name.HeaderText = "Name"
                Name.MappingName = "Name"
                Name.ReadOnly = True
                Name.Width = 300
                Name.NullText = ""
                tStyle.GridColumnStyles.Add(Name)

                Dim Description As New DataGridLabelColumn
                Description.Format = ""
                Description.FormatInfo = Nothing
                Description.HeaderText = "Description"
                Description.MappingName = "Description"
                Description.ReadOnly = True
                Description.Width = 250
                Description.NullText = ""
                tStyle.GridColumnStyles.Add(Description)
            Case Entity.Sys.Enums.TableNames.tblEngineerRole
                Dim name As New DataGridLabelColumn
                name.Format = ""
                name.FormatInfo = Nothing
                name.HeaderText = "Name"
                name.MappingName = "Name"
                name.ReadOnly = True
                name.Width = 300
                name.NullText = ""
                tStyle.GridColumnStyles.Add(name)

                Dim department As New DataGridLabelColumn
                department.Format = ""
                department.FormatInfo = Nothing
                department.HeaderText = "Department"
                department.MappingName = "Department"
                department.ReadOnly = True
                department.Width = 250
                department.NullText = ""
                tStyle.GridColumnStyles.Add(department)
        End Select

        tStyle.MappingName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString
        Me.dgResults.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupStockDatagrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgStock)
        Dim tStyle As DataGridTableStyle = Me.dgStock.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 100
        Type.NullText = ""
        tStyle.GridColumnStyles.Add(Type)

        Dim Location As New DataGridLabelColumn
        Location.Format = ""
        Location.FormatInfo = Nothing
        Location.HeaderText = "Location"
        Location.MappingName = "Location"
        Location.ReadOnly = True
        Location.Width = 200
        Location.NullText = ""
        tStyle.GridColumnStyles.Add(Location)

        Dim Shelf As New DataGridLabelColumn
        Shelf.Format = ""
        Shelf.FormatInfo = Nothing
        Shelf.HeaderText = "Shelf"
        Shelf.MappingName = "Shelf"
        Shelf.ReadOnly = True
        Shelf.Width = 100
        Shelf.NullText = ""
        tStyle.GridColumnStyles.Add(Shelf)

        Dim Bin As New DataGridLabelColumn
        Bin.Format = ""
        Bin.FormatInfo = Nothing
        Bin.HeaderText = "Bin"
        Bin.MappingName = "Bin"
        Bin.ReadOnly = True
        Bin.Width = 100
        Bin.NullText = ""
        tStyle.GridColumnStyles.Add(Bin)

        Dim Qty As New DataGridLabelColumn
        Qty.Format = ""
        Qty.FormatInfo = Nothing
        Qty.HeaderText = "Qty"
        Qty.MappingName = "Quantity"
        Qty.ReadOnly = True
        Qty.Width = 100
        Qty.NullText = ""
        tStyle.GridColumnStyles.Add(Qty)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblStock.ToString
        Me.dgStock.TableStyles.Add(tStyle)

    End Sub

#End Region

#Region "Events"

    Private Sub DLGFindRecord_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged
        RunFilter()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub dgResults_Select(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgResults.Click, dgResults.CurrentCellChanged
        If Not TableToSearch = Entity.Sys.Enums.TableNames.tblPart Then
            Exit Sub
        End If
        If SelectedDataRow Is Nothing Then
            StockDataview = Nothing
            Me.grpStock.Text = "Stock Locations for : 'No Part Selected'"
        Else
            If Not Trans Is Nothing Then
                StockDataview = DB.Part.Stock_Get_Locations(SelectedDataRow.Item("PartID"), Trans)
            Else : StockDataview = DB.Part.Stock_Get_Locations(SelectedDataRow.Item("PartID"))
            End If

            Me.grpStock.Text = "Stock Locations for : '" & SelectedDataRow.Item("Name") & "'"
        End If
    End Sub

    Private Sub dgResults_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgResults.DoubleClick
        If TableToSearch = Entity.Sys.Enums.TableNames.tblPart Then
            If SelectedDataRow Is Nothing Then
                Exit Sub
            End If
            ShowForm(GetType(FRMPart), True, New Object() {SelectedDataRow.Item("PartID"), True})
            Records = DB.Part.Part_GetAll()
            RunFilter()
        Else
            SelectItem()
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        SelectItem()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Select Case TableToSearch
            Case Entity.Sys.Enums.TableNames.tblPart
                ShowForm(GetType(FRMPart), True, New Object() {0, True})
                TableToSearch = Entity.Sys.Enums.TableNames.tblPart
            Case Entity.Sys.Enums.TableNames.tblProduct
                ShowForm(GetType(FRMProduct), True, New Object() {0, True})
                TableToSearch = Entity.Sys.Enums.TableNames.tblProduct
        End Select
    End Sub

#End Region

#Region "Functions"

    Private Sub SelectItem()
        If SelectedDataRow Is Nothing Then
            ShowMessage("No record selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Select Case TableToSearch
            Case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_tblPicklists_BIN
                ID = SelectedDataRow.Item("ManagerID")
            Case Entity.Sys.Enums.TableNames.tblLocations
                ID = SelectedDataRow.Item("LocationID")
            Case Entity.Sys.Enums.TableNames.tblCustomer
                ID = SelectedDataRow.Item("CustomerID")
            Case Entity.Sys.Enums.TableNames.tblUser
                ID = SelectedDataRow.Item("UserID")
            Case Entity.Sys.Enums.TableNames.tblSite
                ID = SelectedDataRow.Item("SiteID")
            Case Entity.Sys.Enums.TableNames.tblWarehouse
                ID = SelectedDataRow.Item("WarehouseID")
            Case Entity.Sys.Enums.TableNames.tblVan
                ID = SelectedDataRow.Item("VanID")
            Case Entity.Sys.Enums.TableNames.tblProduct
                ID = SelectedDataRow.Item("ProductID")
            Case Entity.Sys.Enums.TableNames.tblPart
                If ForMassPartEntry Then
                    PartsToAdd = New ArrayList
                    For Each row As DataRow In Records.Table.Rows
                        If row.Item("QuantityToAdd") > 0 Then
                            Dim newPart As New ArrayList
                            newPart.Add(row.Item("PartID"))
                            newPart.Add(row.Item("QuantityToAdd"))
                            PartsToAdd.Add(newPart)
                        End If
                    Next
                Else
                    ID = SelectedDataRow.Item("PartID")
                End If
            Case Entity.Sys.Enums.TableNames.tblInvoiceAddress
                ID = SelectedDataRow.Item("InvoiceAddressID")
            Case Entity.Sys.Enums.TableNames.tblContact
                ID = SelectedDataRow.Item("ContactID")
            Case Entity.Sys.Enums.TableNames.tblPartSupplier
                ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow.Item("PartSupplierID"))
                SecondID = SelectedDataRow.Item("PartID")
            Case Entity.Sys.Enums.TableNames.tblProductSupplier
                ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow.Item("ProductSupplierID"))
                SecondID = SelectedDataRow.Item("ProductID")
            Case Entity.Sys.Enums.TableNames.tblSupplier
                ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow.Item("SupplierID"))
            Case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_VansForPart
                ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow.Item("LocationID"))
            Case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_VansForProduct
                ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow.Item("LocationID"))
            Case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForProduct
                ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow.Item("SupplierID"))
            Case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_SuppliersForPart
                ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow.Item("SupplierID"))
            Case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehouseForPart
                ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow.Item("LocationID"))
            Case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehouseForProduct
                ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow.Item("LocationID"))
            Case Entity.Sys.Enums.TableNames.tblJob
                ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow.Item("JobID"))
            Case Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_WarehousesAndVans
                ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow.Item("LocationID"))
            Case Entity.Sys.Enums.TableNames.tblEngineer, Entity.Sys.Enums.TableNames.tblEngineerRole
                ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow.Item("EngineerID"))
            Case Entity.Sys.Enums.TableNames.tblOrder
                ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow.Item("OrderID"))
            Case Entity.Sys.Enums.TableNames.tblFleetVan
                ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow.Item("VanID"))
            Case Entity.Sys.Enums.TableNames.tblFleetVanFault
                ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow.Item("VanFaultID"))
            Case Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate
                ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow.Item("SystemScheduleOfRateID"))
            Case Entity.Sys.Enums.TableNames.tblEngineerSkills
                ID = SelectedDataRow.Item("ManagerID")
        End Select

        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub RunFilter()
        Dim whereClause As String = "Deleted = 0"

        If Not Me.txtFilter.Text.Trim.Length = 0 Then
            Select Case TableToSearch
                Case Entity.Sys.Enums.TableNames.tblJob
                    whereClause += " AND JobNumber LIKE '%" & Me.txtFilter.Text.Trim & "%'"
                Case Entity.Sys.Enums.TableNames.tblUser
                    whereClause += " AND FullName LIKE '%" & Me.txtFilter.Text.Trim & "%'"
                Case Entity.Sys.Enums.TableNames.tblContact
                    whereClause += " AND (Firstname LIKE '%" & Me.txtFilter.Text.Trim & "%') OR (Surname LIKE '%" & Me.txtFilter.Text.Trim & "%')"
                Case Entity.Sys.Enums.TableNames.tblSite
                    whereClause += " AND (Name LIKE '%" & Me.txtFilter.Text.Trim & "%' OR Address1 LIKE '%" &
                        Me.txtFilter.Text.Trim & "%' OR Address2 LIKE '%" & Me.txtFilter.Text.Trim & "%' OR PostCode LIKE '%" &
                        Me.txtFilter.Text.Trim & "%' OR PolicyNumber LIKE '%" & Me.txtFilter.Text.Trim & "%')"
                Case Entity.Sys.Enums.TableNames.tblProduct
                    whereClause += " AND typemakemodel LIKE '%" & Me.txtFilter.Text.Trim & "%' OR Reference LIKE '%" & Me.txtFilter.Text.Trim & "%'OR Number LIKE '%" & Me.txtFilter.Text.Trim & "%'"
                Case Entity.Sys.Enums.TableNames.tblPart
                    whereClause += " AND Name LIKE '%" & Me.txtFilter.Text.Trim & "%' OR Reference LIKE '%" & Me.txtFilter.Text.Trim & "%'OR Number LIKE '%" & Me.txtFilter.Text.Trim & "%'"
                Case Entity.Sys.Enums.TableNames.tblPartSupplier
                    whereClause += " AND PartCode LIKE '%" & Me.txtFilter.Text.Trim & "%'"
                Case Entity.Sys.Enums.TableNames.tblOrder
                    whereClause += " AND OrderReference LIKE '%" & Me.txtFilter.Text.Trim & "%'"
                Case Entity.Sys.Enums.TableNames.tblVan, Entity.Sys.Enums.TableNames.tblFleetVan
                    whereClause += " AND Registration LIKE '%" & Me.txtFilter.Text.Trim & "%'"
                Case Entity.Sys.Enums.TableNames.tblFleetVanFault
                    whereClause = "Registration LIKE '%" & Me.txtFilter.Text.Trim & "%'"
                Case Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate
                    whereClause += "AND (Description LIKE '%" & Me.txtFilter.Text.Trim & "%' OR Code LIKE '%" & Me.txtFilter.Text.Trim & "%')"
                Case Entity.Sys.Enums.TableNames.tblEngineerSkills
                    whereClause += "AND (Description LIKE '%" & Me.txtFilter.Text.Trim & "%' OR Name LIKE '%" & Me.txtFilter.Text.Trim & "%') AND EnumTypeID = 7"
                Case Else
                    whereClause += " AND Name LIKE '%" & Me.txtFilter.Text.Trim & "%'"
            End Select
        End If
        If cbOffice.Checked Then
            whereClause = whereClause + " AND Accommodation = 'Office'"
        End If

        If Entity.Sys.Helper.MakeIntegerValid(ForeignKeyFilter) = 1 AndAlso TableToSearch = Entity.Sys.Enums.TableNames.tblSupplier Then
            Records.RowFilter = "MasterSupplierID = 0 AND " & whereClause
        Else
            Records.RowFilter = whereClause
        End If

        StockDataview = Nothing
        Me.grpStock.Text = "Stock Locations for : 'No Part Selected'"
    End Sub

#End Region

#Region "Classes"

    Public Class ColourColumn : Inherits DataGridLabelColumn

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
            MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
            'set the color required dependant on the column value
            Dim brush As Brush

            brush = Brushes.White

            If Entity.Sys.Helper.MakeBooleanValid([source].List.Item(rowNum).row.item("Preferred")) Then
                brush = Brushes.LightGreen
            End If

            Me.TextBox.Text = ""
            'color the row cell
            Dim rect As Rectangle = bounds
            g.FillRectangle(brush, rect)
            g.DrawString("", Me.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom))

        End Sub

    End Class

#End Region

    Private Sub btnFilter_Click(sender As Object, e As EventArgs)
        RunFilter()
    End Sub

    Private Sub cbOffice_CheckedChanged(sender As Object, e As EventArgs) Handles cbOffice.CheckedChanged
        RunFilter()
    End Sub

End Class