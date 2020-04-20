Public Class UCProduct : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Combo.SetUpCombo(Me.cboMakeID, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Makes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboModelID, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Models).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboTypeID, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Types).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabMainDetails As System.Windows.Forms.TabPage
    Friend WithEvents grpProduct As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblNumber As System.Windows.Forms.Label
    Friend WithEvents cboTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblTypeID As System.Windows.Forms.Label
    Friend WithEvents cboMakeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblMakeID As System.Windows.Forms.Label
    Friend WithEvents cboModelID As System.Windows.Forms.ComboBox
    Friend WithEvents lblModelID As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents tabSuppliers As System.Windows.Forms.TabPage
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents dgProductSuppliers As System.Windows.Forms.DataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSellPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtRecommendedQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMinimumQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtReference As System.Windows.Forms.TextBox
    Friend WithEvents tabAssociatedParts As System.Windows.Forms.TabPage
    Friend WithEvents grpSupplier As System.Windows.Forms.GroupBox
    Friend WithEvents grpAssociatedParts As System.Windows.Forms.GroupBox
    Friend WithEvents dgAssociatedParts As System.Windows.Forms.DataGrid



    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabMainDetails = New System.Windows.Forms.TabPage
        Me.grpProduct = New System.Windows.Forms.GroupBox
        Me.txtReference = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtRecommendedQuantity = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtMinimumQuantity = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtSellPrice = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNumber = New System.Windows.Forms.TextBox
        Me.lblNumber = New System.Windows.Forms.Label
        Me.cboTypeID = New System.Windows.Forms.ComboBox
        Me.lblTypeID = New System.Windows.Forms.Label
        Me.cboMakeID = New System.Windows.Forms.ComboBox
        Me.lblMakeID = New System.Windows.Forms.Label
        Me.cboModelID = New System.Windows.Forms.ComboBox
        Me.lblModelID = New System.Windows.Forms.Label
        Me.txtNotes = New System.Windows.Forms.TextBox
        Me.lblNotes = New System.Windows.Forms.Label
        Me.tabSuppliers = New System.Windows.Forms.TabPage
        Me.grpSupplier = New System.Windows.Forms.GroupBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.dgProductSuppliers = New System.Windows.Forms.DataGrid
        Me.tabAssociatedParts = New System.Windows.Forms.TabPage
        Me.grpAssociatedParts = New System.Windows.Forms.GroupBox
        Me.dgAssociatedParts = New System.Windows.Forms.DataGrid
        Me.TabControl1.SuspendLayout()
        Me.tabMainDetails.SuspendLayout()
        Me.grpProduct.SuspendLayout()
        Me.tabSuppliers.SuspendLayout()
        Me.grpSupplier.SuspendLayout()
        CType(Me.dgProductSuppliers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAssociatedParts.SuspendLayout()
        Me.grpAssociatedParts.SuspendLayout()
        CType(Me.dgAssociatedParts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabMainDetails)
        Me.TabControl1.Controls.Add(Me.tabSuppliers)
        Me.TabControl1.Controls.Add(Me.tabAssociatedParts)
        Me.TabControl1.Location = New System.Drawing.Point(2, 7)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(633, 617)
        Me.TabControl1.TabIndex = 0
        '
        'tabMainDetails
        '
        Me.tabMainDetails.Controls.Add(Me.grpProduct)
        Me.tabMainDetails.Location = New System.Drawing.Point(4, 22)
        Me.tabMainDetails.Name = "tabMainDetails"
        Me.tabMainDetails.Size = New System.Drawing.Size(625, 591)
        Me.tabMainDetails.TabIndex = 0
        Me.tabMainDetails.Text = "Main Details"
        '
        'grpProduct
        '
        Me.grpProduct.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpProduct.Controls.Add(Me.txtReference)
        Me.grpProduct.Controls.Add(Me.Label2)
        Me.grpProduct.Controls.Add(Me.txtRecommendedQuantity)
        Me.grpProduct.Controls.Add(Me.Label6)
        Me.grpProduct.Controls.Add(Me.txtMinimumQuantity)
        Me.grpProduct.Controls.Add(Me.Label5)
        Me.grpProduct.Controls.Add(Me.txtSellPrice)
        Me.grpProduct.Controls.Add(Me.Label1)
        Me.grpProduct.Controls.Add(Me.txtNumber)
        Me.grpProduct.Controls.Add(Me.lblNumber)
        Me.grpProduct.Controls.Add(Me.cboTypeID)
        Me.grpProduct.Controls.Add(Me.lblTypeID)
        Me.grpProduct.Controls.Add(Me.cboMakeID)
        Me.grpProduct.Controls.Add(Me.lblMakeID)
        Me.grpProduct.Controls.Add(Me.cboModelID)
        Me.grpProduct.Controls.Add(Me.lblModelID)
        Me.grpProduct.Controls.Add(Me.txtNotes)
        Me.grpProduct.Controls.Add(Me.lblNotes)
        Me.grpProduct.Location = New System.Drawing.Point(8, 8)
        Me.grpProduct.Name = "grpProduct"
        Me.grpProduct.Size = New System.Drawing.Size(606, 576)
        Me.grpProduct.TabIndex = 0
        Me.grpProduct.TabStop = False
        Me.grpProduct.Text = "Details"
        '
        'txtReference
        '
        Me.txtReference.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReference.Location = New System.Drawing.Point(160, 56)
        Me.txtReference.MaxLength = 100
        Me.txtReference.Name = "txtReference"
        Me.txtReference.Size = New System.Drawing.Size(433, 21)
        Me.txtReference.TabIndex = 1
        Me.txtReference.Tag = "Product.Reference"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 20)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Reference"
        '
        'txtRecommendedQuantity
        '
        Me.txtRecommendedQuantity.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRecommendedQuantity.Location = New System.Drawing.Point(160, 248)
        Me.txtRecommendedQuantity.Name = "txtRecommendedQuantity"
        Me.txtRecommendedQuantity.Size = New System.Drawing.Size(433, 21)
        Me.txtRecommendedQuantity.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 246)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(152, 24)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Maximum Quantity"
        '
        'txtMinimumQuantity
        '
        Me.txtMinimumQuantity.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMinimumQuantity.Location = New System.Drawing.Point(160, 216)
        Me.txtMinimumQuantity.Name = "txtMinimumQuantity"
        Me.txtMinimumQuantity.Size = New System.Drawing.Size(433, 21)
        Me.txtMinimumQuantity.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 218)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 16)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Minimum Quantity"
        '
        'txtSellPrice
        '
        Me.txtSellPrice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSellPrice.Location = New System.Drawing.Point(160, 184)
        Me.txtSellPrice.Name = "txtSellPrice"
        Me.txtSellPrice.Size = New System.Drawing.Size(433, 21)
        Me.txtSellPrice.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 183)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 23)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Sell Price"
        '
        'txtNumber
        '
        Me.txtNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNumber.Location = New System.Drawing.Point(160, 24)
        Me.txtNumber.MaxLength = 100
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(433, 21)
        Me.txtNumber.TabIndex = 0
        Me.txtNumber.Tag = "Product.Number"
        '
        'lblNumber
        '
        Me.lblNumber.Location = New System.Drawing.Point(8, 24)
        Me.lblNumber.Name = "lblNumber"
        Me.lblNumber.Size = New System.Drawing.Size(120, 20)
        Me.lblNumber.TabIndex = 31
        Me.lblNumber.Text = "GC Number"
        '
        'cboTypeID
        '
        Me.cboTypeID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTypeID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTypeID.Location = New System.Drawing.Point(160, 88)
        Me.cboTypeID.Name = "cboTypeID"
        Me.cboTypeID.Size = New System.Drawing.Size(433, 21)
        Me.cboTypeID.TabIndex = 2
        Me.cboTypeID.Tag = "Product.TypeID"
        '
        'lblTypeID
        '
        Me.lblTypeID.Location = New System.Drawing.Point(8, 88)
        Me.lblTypeID.Name = "lblTypeID"
        Me.lblTypeID.Size = New System.Drawing.Size(46, 20)
        Me.lblTypeID.TabIndex = 31
        Me.lblTypeID.Text = "Type "
        '
        'cboMakeID
        '
        Me.cboMakeID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboMakeID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboMakeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMakeID.Location = New System.Drawing.Point(160, 120)
        Me.cboMakeID.Name = "cboMakeID"
        Me.cboMakeID.Size = New System.Drawing.Size(433, 21)
        Me.cboMakeID.TabIndex = 3
        Me.cboMakeID.Tag = "Product.MakeID"
        '
        'lblMakeID
        '
        Me.lblMakeID.Location = New System.Drawing.Point(8, 120)
        Me.lblMakeID.Name = "lblMakeID"
        Me.lblMakeID.Size = New System.Drawing.Size(47, 20)
        Me.lblMakeID.TabIndex = 31
        Me.lblMakeID.Text = "Make "
        '
        'cboModelID
        '
        Me.cboModelID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboModelID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboModelID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModelID.Location = New System.Drawing.Point(160, 152)
        Me.cboModelID.Name = "cboModelID"
        Me.cboModelID.Size = New System.Drawing.Size(433, 21)
        Me.cboModelID.TabIndex = 4
        Me.cboModelID.Tag = "Product.ModelID"
        '
        'lblModelID
        '
        Me.lblModelID.Location = New System.Drawing.Point(8, 152)
        Me.lblModelID.Name = "lblModelID"
        Me.lblModelID.Size = New System.Drawing.Size(48, 20)
        Me.lblModelID.TabIndex = 31
        Me.lblModelID.Text = "Model "
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(160, 280)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(433, 283)
        Me.txtNotes.TabIndex = 8
        Me.txtNotes.Tag = "Product.Notes"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(8, 280)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(48, 20)
        Me.lblNotes.TabIndex = 31
        Me.lblNotes.Text = "Notes"
        '
        'tabSuppliers
        '
        Me.tabSuppliers.Controls.Add(Me.grpSupplier)
        Me.tabSuppliers.Location = New System.Drawing.Point(4, 22)
        Me.tabSuppliers.Name = "tabSuppliers"
        Me.tabSuppliers.Size = New System.Drawing.Size(625, 591)
        Me.tabSuppliers.TabIndex = 1
        Me.tabSuppliers.Text = "Suppliers"
        '
        'grpSupplier
        '
        Me.grpSupplier.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSupplier.Controls.Add(Me.btnDelete)
        Me.grpSupplier.Controls.Add(Me.btnAdd)
        Me.grpSupplier.Controls.Add(Me.dgProductSuppliers)
        Me.grpSupplier.Location = New System.Drawing.Point(7, 8)
        Me.grpSupplier.Name = "grpSupplier"
        Me.grpSupplier.Size = New System.Drawing.Size(612, 577)
        Me.grpSupplier.TabIndex = 0
        Me.grpSupplier.TabStop = False
        Me.grpSupplier.Text = "Suppliers of this product"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(537, 544)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(64, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Remove"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(8, 543)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(64, 23)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add"
        '
        'dgProductSuppliers
        '
        Me.dgProductSuppliers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgProductSuppliers.DataMember = ""
        Me.dgProductSuppliers.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgProductSuppliers.Location = New System.Drawing.Point(9, 28)
        Me.dgProductSuppliers.Name = "dgProductSuppliers"
        Me.dgProductSuppliers.Size = New System.Drawing.Size(593, 469)
        Me.dgProductSuppliers.TabIndex = 1
        '
        'tabAssociatedParts
        '
        Me.tabAssociatedParts.Controls.Add(Me.grpAssociatedParts)
        Me.tabAssociatedParts.Location = New System.Drawing.Point(4, 22)
        Me.tabAssociatedParts.Name = "tabAssociatedParts"
        Me.tabAssociatedParts.Size = New System.Drawing.Size(625, 591)
        Me.tabAssociatedParts.TabIndex = 2
        Me.tabAssociatedParts.Text = "Associated Parts"
        '
        'grpAssociatedParts
        '
        Me.grpAssociatedParts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAssociatedParts.Controls.Add(Me.dgAssociatedParts)
        Me.grpAssociatedParts.Location = New System.Drawing.Point(7, 8)
        Me.grpAssociatedParts.Name = "grpAssociatedParts"
        Me.grpAssociatedParts.Size = New System.Drawing.Size(612, 577)
        Me.grpAssociatedParts.TabIndex = 1
        Me.grpAssociatedParts.TabStop = False
        Me.grpAssociatedParts.Text = "Associated parts of this product"
        '
        'dgAssociatedParts
        '
        Me.dgAssociatedParts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAssociatedParts.DataMember = ""
        Me.dgAssociatedParts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgAssociatedParts.Location = New System.Drawing.Point(9, 28)
        Me.dgAssociatedParts.Name = "dgAssociatedParts"
        Me.dgAssociatedParts.Size = New System.Drawing.Size(593, 542)
        Me.dgAssociatedParts.TabIndex = 1
        '
        'UCProduct
        '
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "UCProduct"
        Me.Size = New System.Drawing.Size(640, 628)
        Me.TabControl1.ResumeLayout(False)
        Me.tabMainDetails.ResumeLayout(False)
        Me.grpProduct.ResumeLayout(False)
        Me.grpProduct.PerformLayout()
        Me.tabSuppliers.ResumeLayout(False)
        Me.grpSupplier.ResumeLayout(False)
        CType(Me.dgProductSuppliers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAssociatedParts.ResumeLayout(False)
        Me.grpAssociatedParts.ResumeLayout(False)
        CType(Me.dgAssociatedParts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
        SetupSuppliersDatagrid()
        SetupAssociateDatagrid()

    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentProduct
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged
    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _currentProduct As Entity.Products.Product
    Public Property CurrentProduct() As Entity.Products.Product
        Get
            Return _currentProduct
        End Get
        Set(ByVal Value As Entity.Products.Product)
            _currentProduct = Value

            If CurrentProduct Is Nothing Then
                CurrentProduct = New Entity.Products.Product
                CurrentProduct.Exists = False
                Me.btnAdd.Enabled = False
                Me.btnDelete.Enabled = False
            End If

            If CurrentProduct.Exists Then
                Populate()
                Me.btnAdd.Enabled = True
                Me.btnDelete.Enabled = True
            End If

            PopulateSuppliers()

        End Set
    End Property

    Private _FromOrder As Boolean
    Public Property FromOrder() As Boolean
        Get
            Return _FromOrder
        End Get
        Set(ByVal Value As Boolean)
            _FromOrder = Value
        End Set
    End Property

    Private _ProductSuppliersDataview As DataView = Nothing
    Public Property ProductSuppliersDataView() As DataView
        Get
            Return _ProductSuppliersDataview
        End Get
        Set(ByVal Value As DataView)
            _ProductSuppliersDataview = Value
            _ProductSuppliersDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblProductSupplier.ToString
            _ProductSuppliersDataview.AllowNew = False
            _ProductSuppliersDataview.AllowEdit = False
            _ProductSuppliersDataview.AllowDelete = False
            Me.dgProductSuppliers.DataSource = ProductSuppliersDataView
        End Set
    End Property

    Private ReadOnly Property SelectedProductSupplierDataRow() As DataRow
        Get
            If Not Me.dgProductSuppliers.CurrentRowIndex = -1 Then
                Return ProductSuppliersDataView(Me.dgProductSuppliers.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _ProductAssociatedPartsDataview As DataView = Nothing
    Public Property ProductAssociatedPartsDataview() As DataView
        Get
            Return _ProductAssociatedPartsDataview
        End Get
        Set(ByVal Value As DataView)
            _ProductAssociatedPartsDataview = Value
            If Not _ProductAssociatedPartsDataview Is Nothing Then
                _ProductAssociatedPartsDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblProductAssociatedPart.ToString
                _ProductAssociatedPartsDataview.AllowNew = False
                _ProductAssociatedPartsDataview.AllowEdit = True
                _ProductAssociatedPartsDataview.AllowDelete = False
            End If

            Me.dgAssociatedParts.DataSource = ProductAssociatedPartsDataview
        End Set
    End Property

    Private ReadOnly Property SelectedProductAssociatedPartDataRow() As DataRow
        Get
            If Not Me.dgAssociatedParts.CurrentRowIndex = -1 Then
                Return ProductAssociatedPartsDataview(Me.dgAssociatedParts.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Public Sub SetupSuppliersDatagrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgProductSuppliers)
        Dim tStyle As DataGridTableStyle = Me.dgProductSuppliers.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim SupplierName As New DataGridLabelColumn
        SupplierName.Format = ""
        SupplierName.FormatInfo = Nothing
        SupplierName.HeaderText = "Supplier"
        SupplierName.MappingName = "SupplierName"
        SupplierName.ReadOnly = True
        SupplierName.Width = 130
        SupplierName.NullText = ""
        tStyle.GridColumnStyles.Add(SupplierName)

        Dim ProductCode As New DataGridLabelColumn
        ProductCode.Format = ""
        ProductCode.FormatInfo = Nothing
        ProductCode.HeaderText = "Supplier Product Code"
        ProductCode.MappingName = "ProductCode"
        ProductCode.ReadOnly = True
        ProductCode.Width = 130
        ProductCode.NullText = ""
        tStyle.GridColumnStyles.Add(ProductCode)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Supplier Price"
        Price.MappingName = "Price"
        Price.ReadOnly = True
        Price.Width = 85
        Price.NullText = ""
        tStyle.GridColumnStyles.Add(Price)

        Dim QuantityInPack As New DataGridLabelColumn
        QuantityInPack.Format = ""
        QuantityInPack.FormatInfo = Nothing
        QuantityInPack.HeaderText = "Quantity In Pack"
        QuantityInPack.MappingName = "QuantityInPack"
        QuantityInPack.ReadOnly = True
        QuantityInPack.Width = 110
        QuantityInPack.NullText = ""
        tStyle.GridColumnStyles.Add(QuantityInPack)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblProductSupplier.ToString
        Me.dgProductSuppliers.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupAssociateDatagrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgAssociatedParts)
        Dim tStyle As DataGridTableStyle = Me.dgAssociatedParts.TableStyles(0)

        Me.dgAssociatedParts.ReadOnly = False
        tStyle.AllowSorting = False
        tStyle.ReadOnly = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tStyle.GridColumnStyles.Add(Tick)

        Dim PartName As New DataGridLabelColumn
        PartName.Format = ""
        PartName.FormatInfo = Nothing
        PartName.HeaderText = "Part Name"
        PartName.MappingName = "Name"
        PartName.ReadOnly = True
        PartName.Width = 130
        PartName.NullText = ""
        tStyle.GridColumnStyles.Add(PartName)

        Dim PartNumber As New DataGridLabelColumn
        PartNumber.Format = ""
        PartNumber.FormatInfo = Nothing
        PartNumber.HeaderText = "Part Number"
        PartNumber.MappingName = "Number"
        PartNumber.ReadOnly = True
        PartNumber.Width = 130
        PartNumber.NullText = ""
        tStyle.GridColumnStyles.Add(PartNumber)

        Dim PartReference As New DataGridLabelColumn
        PartReference.Format = ""
        PartReference.FormatInfo = Nothing
        PartReference.HeaderText = "Part Reference"
        PartReference.MappingName = "Reference"
        PartReference.ReadOnly = True
        PartReference.Width = 130
        PartReference.NullText = ""
        tStyle.GridColumnStyles.Add(PartReference)

        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblProductAssociatedPart.ToString
        Me.dgAssociatedParts.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub UCProduct_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub dgProductSuppliers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgProductSuppliers.DoubleClick
        If SelectedProductSupplierDataRow Is Nothing Then
            Exit Sub
        End If

        ShowForm(GetType(FRMProductSupplier), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedProductSupplierDataRow.Item("ProductSupplierID")), CurrentProduct.ProductID, Me})
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ShowForm(GetType(FRMProductSupplier), True, New Object() {0, CurrentProduct.ProductID, Me})
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If SelectedProductSupplierDataRow Is Nothing Then
            ShowMessage("Please select a supplier to remove", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If ShowMessage("Are you sure you want to delete the selected record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        DB.ProductSupplier.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedProductSupplierDataRow.Item("ProductSupplierID")))
        ProductSuppliersDataView = DB.ProductSupplier.Get_ByProductID(CurrentProduct.ProductID)
    End Sub

    Private Sub dgAssociatedParts_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgAssociatedParts.DoubleClick
        If SelectedProductAssociatedPartDataRow Is Nothing Then
            Exit Sub
        End If

        ShowForm(GetType(FRMPart), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedProductAssociatedPartDataRow.Item("PartID")), True})
        ProductAssociatedPartsDataview = DB.ProductAssociatedPart.GetAll_For_ProductID(CurrentProduct.ProductID)
    End Sub

    Private Sub dgAssociatedParts_Clicks(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgAssociatedParts.Click
        Try
            If SelectedProductAssociatedPartDataRow Is Nothing Then
                Exit Sub
            End If

            Dim selected As Boolean = Not CBool(Me.dgAssociatedParts(Me.dgAssociatedParts.CurrentRowIndex, 0))
            Me.dgAssociatedParts(Me.dgAssociatedParts.CurrentRowIndex, 0) = selected
            AnythingChanges(sender, e)
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Functions"

    Public Sub PopulateSuppliers()
        ProductSuppliersDataView = DB.ProductSupplier.Get_ByProductID(CurrentProduct.ProductID)
    End Sub

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        ControlLoading = True
        If Not ID = 0 Then
            CurrentProduct = DB.Product.Product_Get(ID)
        End If

        Me.txtNumber.Text = CurrentProduct.Number
        Me.txtReference.Text = CurrentProduct.Reference
        Me.txtSellPrice.Text = CurrentProduct.SellPrice
        Combo.SetSelectedComboItem_By_Value(Me.cboTypeID, CurrentProduct.TypeID)
        Combo.SetSelectedComboItem_By_Value(Me.cboMakeID, CurrentProduct.MakeID)
        Combo.SetSelectedComboItem_By_Value(Me.cboModelID, CurrentProduct.ModelID)
        Me.txtNotes.Text = CurrentProduct.Notes
        Me.txtMinimumQuantity.Text = CurrentProduct.MinimumQuantity
        Me.txtRecommendedQuantity.Text = CurrentProduct.RecommendedQuantity
        ProductAssociatedPartsDataview = CurrentProduct.AssociatedPart

        AddChangeHandlers(Me)
        ControlChanged = False
        ControlLoading = False

    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            CurrentProduct.IgnoreExceptionsOnSetMethods = True

            CurrentProduct.SetNumber = Me.txtNumber.Text.Trim
            CurrentProduct.SetReference = Me.txtReference.Text.Trim
            CurrentProduct.SetTypeID = Combo.GetSelectedItemValue(Me.cboTypeID)
            CurrentProduct.SetMakeID = Combo.GetSelectedItemValue(Me.cboMakeID)
            CurrentProduct.SetModelID = Combo.GetSelectedItemValue(Me.cboModelID)
            CurrentProduct.SetNotes = Me.txtNotes.Text.Trim
            CurrentProduct.SetSellPrice = Me.txtSellPrice.Text.Trim
            CurrentProduct.SetMinimumQuantity = Entity.Sys.Helper.MakeIntegerValid(Me.txtMinimumQuantity.Text.Trim)
            CurrentProduct.SetRecommendedQuantity = Entity.Sys.Helper.MakeIntegerValid(Me.txtRecommendedQuantity.Text.Trim)
            CurrentProduct.AssociatedPart = ProductAssociatedPartsDataview
            Dim cV As New Entity.Products.ProductValidator
            cV.Validate(CurrentProduct)

            If CurrentProduct.Exists Then
                DB.Product.Update(CurrentProduct)
            Else
                CurrentProduct = DB.Product.Insert(CurrentProduct)
            End If

            If FromOrder = False Then
                RaiseEvent RecordsChanged(DB.Product.Product_GetAll(), Entity.Sys.Enums.PageViewing.Product, True, False, "")
                MainForm.RefreshEntity(CurrentProduct.ProductID)
            End If

            RaiseEvent StateChanged(CurrentProduct.ProductID)

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

