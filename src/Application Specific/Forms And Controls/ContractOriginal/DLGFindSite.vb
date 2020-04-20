Public Class DLGFindSite : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboPayer As System.Windows.Forms.ComboBox
    Friend WithEvents grpDD As System.Windows.Forms.Panel
    Friend WithEvents txtAccName As System.Windows.Forms.TextBox
    Friend WithEvents lbl3 As System.Windows.Forms.Label
    Friend WithEvents txtBankName As System.Windows.Forms.TextBox
    Friend WithEvents txtAccNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblBankName As System.Windows.Forms.Label
    Friend WithEvents lblAccNumber As System.Windows.Forms.Label
    Friend WithEvents txtSortCode As System.Windows.Forms.TextBox
    Friend WithEvents lblSortCode As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpEffDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgResults As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.grpResults = New System.Windows.Forms.GroupBox()
        Me.grpDD = New System.Windows.Forms.Panel()
        Me.txtAccName = New System.Windows.Forms.TextBox()
        Me.lbl3 = New System.Windows.Forms.Label()
        Me.txtBankName = New System.Windows.Forms.TextBox()
        Me.txtAccNumber = New System.Windows.Forms.TextBox()
        Me.lblBankName = New System.Windows.Forms.Label()
        Me.lblAccNumber = New System.Windows.Forms.Label()
        Me.txtSortCode = New System.Windows.Forms.TextBox()
        Me.lblSortCode = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboPayer = New System.Windows.Forms.ComboBox()
        Me.dgResults = New System.Windows.Forms.DataGrid()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpEffDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grpResults.SuspendLayout()
        Me.grpDD.SuspendLayout()
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.txtFilter.Location = New System.Drawing.Point(109, 40)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(547, 21)
        Me.txtFilter.TabIndex = 1
        '
        'grpResults
        '
        Me.grpResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpResults.Controls.Add(Me.Label4)
        Me.grpResults.Controls.Add(Me.dtpEffDate)
        Me.grpResults.Controls.Add(Me.grpDD)
        Me.grpResults.Controls.Add(Me.Label3)
        Me.grpResults.Controls.Add(Me.cboPayer)
        Me.grpResults.Controls.Add(Me.dgResults)
        Me.grpResults.Location = New System.Drawing.Point(8, 68)
        Me.grpResults.Name = "grpResults"
        Me.grpResults.Size = New System.Drawing.Size(793, 377)
        Me.grpResults.TabIndex = 4
        Me.grpResults.TabStop = False
        Me.grpResults.Text = "Select record and click OK"
        '
        'grpDD
        '
        Me.grpDD.Controls.Add(Me.txtAccName)
        Me.grpDD.Controls.Add(Me.lbl3)
        Me.grpDD.Controls.Add(Me.txtBankName)
        Me.grpDD.Controls.Add(Me.txtAccNumber)
        Me.grpDD.Controls.Add(Me.lblBankName)
        Me.grpDD.Controls.Add(Me.lblAccNumber)
        Me.grpDD.Controls.Add(Me.txtSortCode)
        Me.grpDD.Controls.Add(Me.lblSortCode)
        Me.grpDD.Location = New System.Drawing.Point(3, 279)
        Me.grpDD.Name = "grpDD"
        Me.grpDD.Size = New System.Drawing.Size(782, 63)
        Me.grpDD.TabIndex = 5
        Me.grpDD.Visible = False
        '
        'txtAccName
        '
        Me.txtAccName.Location = New System.Drawing.Point(111, 19)
        Me.txtAccName.Name = "txtAccName"
        Me.txtAccName.Size = New System.Drawing.Size(137, 21)
        Me.txtAccName.TabIndex = 120
        '
        'lbl3
        '
        Me.lbl3.Location = New System.Drawing.Point(20, 23)
        Me.lbl3.Name = "lbl3"
        Me.lbl3.Size = New System.Drawing.Size(89, 20)
        Me.lbl3.TabIndex = 128
        Me.lbl3.Text = "Account Name"
        '
        'txtBankName
        '
        Me.txtBankName.Location = New System.Drawing.Point(654, 19)
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.Size = New System.Drawing.Size(104, 21)
        Me.txtBankName.TabIndex = 123
        '
        'txtAccNumber
        '
        Me.txtAccNumber.Location = New System.Drawing.Point(497, 19)
        Me.txtAccNumber.Name = "txtAccNumber"
        Me.txtAccNumber.Size = New System.Drawing.Size(84, 21)
        Me.txtAccNumber.TabIndex = 122
        '
        'lblBankName
        '
        Me.lblBankName.Location = New System.Drawing.Point(582, 22)
        Me.lblBankName.Name = "lblBankName"
        Me.lblBankName.Size = New System.Drawing.Size(78, 20)
        Me.lblBankName.TabIndex = 127
        Me.lblBankName.Text = "Bank Name"
        '
        'lblAccNumber
        '
        Me.lblAccNumber.Location = New System.Drawing.Point(396, 22)
        Me.lblAccNumber.Name = "lblAccNumber"
        Me.lblAccNumber.Size = New System.Drawing.Size(108, 20)
        Me.lblAccNumber.TabIndex = 126
        Me.lblAccNumber.Text = "Account Number"
        '
        'txtSortCode
        '
        Me.txtSortCode.Location = New System.Drawing.Point(315, 19)
        Me.txtSortCode.Name = "txtSortCode"
        Me.txtSortCode.Size = New System.Drawing.Size(77, 21)
        Me.txtSortCode.TabIndex = 121
        '
        'lblSortCode
        '
        Me.lblSortCode.Location = New System.Drawing.Point(251, 23)
        Me.lblSortCode.Name = "lblSortCode"
        Me.lblSortCode.Size = New System.Drawing.Size(73, 20)
        Me.lblSortCode.TabIndex = 125
        Me.lblSortCode.Text = "Sort Code"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 24)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Payer"
        '
        'cboPayer
        '
        Me.cboPayer.FormattingEnabled = True
        Me.cboPayer.Location = New System.Drawing.Point(8, 231)
        Me.cboPayer.Name = "cboPayer"
        Me.cboPayer.Size = New System.Drawing.Size(271, 21)
        Me.cboPayer.TabIndex = 3
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
        Me.dgResults.Size = New System.Drawing.Size(777, 150)
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
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(664, 35)
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
        'dtpEffDate
        '
        Me.dtpEffDate.Location = New System.Drawing.Point(585, 228)
        Me.dtpEffDate.Name = "dtpEffDate"
        Me.dtpEffDate.Size = New System.Drawing.Size(200, 21)
        Me.dtpEffDate.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(582, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 24)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Effective From"
        '
        'DLGFindSite
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(809, 481)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.grpResults)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(704, 392)
        Me.Name = "DLGFindSite"
        Me.Text = "Find {0}"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtFilter, 0)
        Me.Controls.SetChildIndex(Me.grpResults, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.grpResults.ResumeLayout(False)
        Me.grpDD.ResumeLayout(False)
        Me.grpDD.PerformLayout()
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).EndInit()
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
                Case Entity.Sys.Enums.TableNames.tblSite
                    If ForeignKeyFilter > 0 Then
                        Me.Text = "Find Property For Customer"
                        Records = DB.Sites.GetForCustomer_Light(ForeignKeyFilter, loggedInUser.UserID)
                    Else
                        Me.Text = "Find Property"
                        Records = DB.Sites.GetAll_Light_New(loggedInUser.UserID)
                    End If
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
                    Records = DB.Job.Job_Get_All("Where tblJob.Deleted =0 ")
                Case Entity.Sys.Enums.TableNames.tblWarehouse
                    Me.Text = "Find Warehouse"
                    If Not Trans Is Nothing Then
                        Records = DB.Warehouse.Warehouse_GetAll(Trans)
                    Else
                        Records = DB.Warehouse.Warehouse_GetAll()
                    End If
                Case Entity.Sys.Enums.TableNames.tblVan
                    Me.Text = "Find Van"
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

    Private _2ndID As String = 0
    Public Property SecondID() As String
        Get
            Return _2ndID
        End Get
        Set(ByVal Value As String)
            _2ndID = Value
        End Set
    End Property


    Private _AddressID As String = 0
    Public Property AddressID() As String
        Get
            Return _AddressID
        End Get
        Set(ByVal Value As String)
            _AddressID = Value
        End Set
    End Property


    Private _InvoiceFrequencyID As String = 0
    Public Property InvoiceFrequencyID() As String
        Get
            Return _InvoiceFrequencyID
        End Get
        Set(ByVal Value As String)
            _InvoiceFrequencyID = Value
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

    Private _EffDate As Date = Date.MinValue
    Public Property EffDate() As Date
        Get
            Return _EffDate
        End Get
        Set(ByVal Value As Date)
            _EffDate = Value
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
                Name.Width = 160
                Name.NullText = ""
                tStyle.GridColumnStyles.Add(Name)

                Dim AccountNumber As New DataGridLabelColumn
                AccountNumber.Format = ""
                AccountNumber.FormatInfo = Nothing
                AccountNumber.HeaderText = "Account Number"
                AccountNumber.MappingName = "AccountNumber"
                AccountNumber.ReadOnly = True
                AccountNumber.Width = 160
                AccountNumber.NullText = ""
                tStyle.GridColumnStyles.Add(AccountNumber)

                Dim Region As New DataGridLabelColumn
                Region.Format = ""
                Region.FormatInfo = Nothing
                Region.HeaderText = "Region"
                Region.MappingName = "Region"
                Region.ReadOnly = True
                Region.Width = 160
                Region.NullText = ""
                tStyle.GridColumnStyles.Add(Region)

                Dim Type As New DataGridLabelColumn
                Type.Format = ""
                Type.FormatInfo = Nothing
                Type.HeaderText = "Type"
                Type.MappingName = "Type"
                Type.ReadOnly = True
                Type.Width = 160
                Type.NullText = ""
                tStyle.GridColumnStyles.Add(Type)

            Case Entity.Sys.Enums.TableNames.tblSite

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
                Registration.HeaderText = "Registration"
                Registration.MappingName = "Registration"
                Registration.ReadOnly = True
                Registration.Width = 100
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
                Name.Width = 160
                Name.NullText = ""
                tStyle.GridColumnStyles.Add(Name)

                Dim TelephoneNum As New DataGridLabelColumn
                TelephoneNum.Format = ""
                TelephoneNum.FormatInfo = Nothing
                TelephoneNum.HeaderText = "Telephone Number"
                TelephoneNum.MappingName = "TelephoneNum"
                TelephoneNum.ReadOnly = True
                TelephoneNum.Width = 100
                TelephoneNum.NullText = ""
                tStyle.GridColumnStyles.Add(TelephoneNum)

                Dim Region As New DataGridLabelColumn
                Region.Format = ""
                Region.FormatInfo = Nothing
                Region.HeaderText = "Region"
                Region.MappingName = "Region"
                Region.ReadOnly = True
                Region.Width = 100
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

        End Select

        tStyle.MappingName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString
        Me.dgResults.TableStyles.Add(tStyle)
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
        'If Not TableToSearch = Entity.Sys.Enums.TableNames.tblPart Then
        '    Exit Sub
        'End If
        If SelectedDataRow Is Nothing Then
            StockDataview = Nothing

        Else
            SelectItem()
            Dim dt As DataTable = DB.InvoiceAddress.InvoiceAddress_Get_SiteID(ID).Table

            cboPayer.Items.Clear()

            For Each dr As DataRow In dt.Rows
                cboPayer.Items.Add(New Combo(dr("Address1") & "," & dr("Address2") & "," & dr("Postcode"), dr("AddressID") & "`" & dr("AddressTypeID")))
            Next
            cboPayer.Items.Add(New Combo("-- Please Select --", 0))

            cboPayer.DisplayMember = "Description"
            cboPayer.ValueMember = "Value"

            Combo.SetSelectedComboItem_By_Value(cboPayer, "0")

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
        If Combo.GetSelectedItemValue(cboPayer) = "0" Then
            Exit Sub
        Else
            'If grpDD.Visible = True And Not (txtBankName.Text.Length > 0 And txtAccName.Text.Length > 2 And txtSortCode.Text.Length > 5 And txtAccNumber.Text.Length > 7) Then
            '    ShowMessage("You must enter Bank name ,Account name, sortcode and account code correctly for Direct Debit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If
            EffDate = dtpEffDate.Value
            Me.DialogResult = DialogResult.OK
        End If
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
            Case Entity.Sys.Enums.TableNames.tblEngineer
                ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow.Item("EngineerID"))
            Case Entity.Sys.Enums.TableNames.tblOrder
                ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow.Item("OrderID"))
        End Select

        '  Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub RunFilter()
        Dim whereClause As String = "Deleted = 0"
        If Not Me.txtFilter.Text.Trim.Length = 0 Then
            Select Case TableToSearch
                Case Entity.Sys.Enums.TableNames.tblJob
                    whereClause += " AND JobNumber LIKE '%" & Me.txtFilter.Text.Trim & "%'"
                Case Entity.Sys.Enums.TableNames.tblContact
                    whereClause += " AND (Firstname LIKE '%" & Me.txtFilter.Text.Trim & "%') OR (Surname LIKE '%" & Me.txtFilter.Text.Trim & "%')"
                Case Entity.Sys.Enums.TableNames.tblSite
                    whereClause += " AND (Name LIKE '%" & Me.txtFilter.Text.Trim & "%' OR Address1 LIKE '%" & Me.txtFilter.Text.Trim & "%')"
                Case Entity.Sys.Enums.TableNames.tblProduct
                    whereClause += " AND typemakemodel LIKE '%" & Me.txtFilter.Text.Trim & "%' OR Reference LIKE '%" & Me.txtFilter.Text.Trim & "%'OR Number LIKE '%" & Me.txtFilter.Text.Trim & "%'"
                Case Entity.Sys.Enums.TableNames.tblPart
                    whereClause += " AND Name LIKE '%" & Me.txtFilter.Text.Trim & "%' OR Reference LIKE '%" & Me.txtFilter.Text.Trim & "%'OR Number LIKE '%" & Me.txtFilter.Text.Trim & "%'"
                Case Entity.Sys.Enums.TableNames.tblPartSupplier
                    whereClause += " AND PartCode LIKE '%" & Me.txtFilter.Text.Trim & "%'"
                Case Entity.Sys.Enums.TableNames.tblOrder
                    whereClause += " AND OrderReference LIKE '%" & Me.txtFilter.Text.Trim & "%'"
                Case Entity.Sys.Enums.TableNames.tblVan
                    whereClause += " AND Registration LIKE '%" & Me.txtFilter.Text.Trim & "%'"
                Case Else
                    whereClause += " AND Name LIKE '%" & Me.txtFilter.Text.Trim & "%'"
            End Select
        End If

        Records.RowFilter = whereClause

        StockDataview = Nothing

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

    Private Sub cboPayer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPayer.SelectedIndexChanged

        If Combo.GetSelectedItemValue(cboPayer) <> "0" Then

            SecondID = Combo.GetSelectedItemValue(cboPayer)

            'If SecondID.Split("`")(0) <> AddressID Then

            '    grpDD.Visible = True


            'End If

        End If

    End Sub
End Class
