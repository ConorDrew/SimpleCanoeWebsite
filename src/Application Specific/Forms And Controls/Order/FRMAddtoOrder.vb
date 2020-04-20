Public Class FRMAddtoOrder : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents Label3 As System.Windows.Forms.Label

    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtQtyInPack As System.Windows.Forms.TextBox
    Friend WithEvents btnAddToOrder As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblNumber As System.Windows.Forms.Label
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents lblQty As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSellPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtBuyPrice As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSupplier As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblName = New System.Windows.Forms.Label
        Me.lblNumber = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblSupplier = New System.Windows.Forms.Label
        Me.lblQty = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtNumber = New System.Windows.Forms.TextBox
        Me.txtQtyInPack = New System.Windows.Forms.TextBox
        Me.txtSupplierCode = New System.Windows.Forms.TextBox
        Me.txtSellPrice = New System.Windows.Forms.TextBox
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.btnAddToOrder = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.txtBuyPrice = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtSupplier = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(8, 24)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(120, 23)
        Me.lblName.TabIndex = 2
        Me.lblName.Text = "Name:"
        '
        'lblNumber
        '
        Me.lblNumber.Location = New System.Drawing.Point(8, 56)
        Me.lblNumber.Name = "lblNumber"
        Me.lblNumber.Size = New System.Drawing.Size(120, 23)
        Me.lblNumber.TabIndex = 3
        Me.lblNumber.Text = "Number:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 23)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Supplier Code:"
        '
        'lblSupplier
        '
        Me.lblSupplier.Location = New System.Drawing.Point(8, 88)
        Me.lblSupplier.Name = "lblSupplier"
        Me.lblSupplier.Size = New System.Drawing.Size(80, 24)
        Me.lblSupplier.TabIndex = 5
        Me.lblSupplier.Text = "Supplier:"
        '
        'lblQty
        '
        Me.lblQty.Location = New System.Drawing.Point(8, 120)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(120, 23)
        Me.lblQty.TabIndex = 6
        Me.lblQty.Text = "Quantity In Pack:"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 23)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Sell Price:"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 120)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 24)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Amount to add:"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(128, 24)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(296, 21)
        Me.txtName.TabIndex = 1
        Me.txtName.Text = ""
        '
        'txtNumber
        '
        Me.txtNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNumber.Enabled = False
        Me.txtNumber.Location = New System.Drawing.Point(128, 58)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.ReadOnly = True
        Me.txtNumber.Size = New System.Drawing.Size(296, 21)
        Me.txtNumber.TabIndex = 2
        Me.txtNumber.Text = ""
        '
        'txtQtyInPack
        '
        Me.txtQtyInPack.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQtyInPack.Enabled = False
        Me.txtQtyInPack.Location = New System.Drawing.Point(128, 122)
        Me.txtQtyInPack.Name = "txtQtyInPack"
        Me.txtQtyInPack.ReadOnly = True
        Me.txtQtyInPack.Size = New System.Drawing.Size(296, 21)
        Me.txtQtyInPack.TabIndex = 4
        Me.txtQtyInPack.Text = ""
        '
        'txtSupplierCode
        '
        Me.txtSupplierCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSupplierCode.Location = New System.Drawing.Point(128, 24)
        Me.txtSupplierCode.Name = "txtSupplierCode"
        Me.txtSupplierCode.Size = New System.Drawing.Size(296, 21)
        Me.txtSupplierCode.TabIndex = 5
        Me.txtSupplierCode.Text = ""
        '
        'txtSellPrice
        '
        Me.txtSellPrice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSellPrice.Location = New System.Drawing.Point(128, 90)
        Me.txtSellPrice.Name = "txtSellPrice"
        Me.txtSellPrice.Size = New System.Drawing.Size(296, 21)
        Me.txtSellPrice.TabIndex = 7
        Me.txtSellPrice.Text = ""
        '
        'txtAmount
        '
        Me.txtAmount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAmount.Location = New System.Drawing.Point(128, 122)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(168, 21)
        Me.txtAmount.TabIndex = 8
        Me.txtAmount.Text = ""
        '
        'btnAddToOrder
        '
        Me.btnAddToOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddToOrder.Location = New System.Drawing.Point(304, 122)
        Me.btnAddToOrder.Name = "btnAddToOrder"
        Me.btnAddToOrder.Size = New System.Drawing.Size(56, 23)
        Me.btnAddToOrder.TabIndex = 9
        Me.btnAddToOrder.Text = "Add"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(368, 122)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(56, 23)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        '
        'txtBuyPrice
        '
        Me.txtBuyPrice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBuyPrice.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuyPrice.Location = New System.Drawing.Point(128, 58)
        Me.txtBuyPrice.Name = "txtBuyPrice"
        Me.txtBuyPrice.Size = New System.Drawing.Size(296, 21)
        Me.txtBuyPrice.TabIndex = 6
        Me.txtBuyPrice.Text = ""
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 23)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Buy Price:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblName)
        Me.GroupBox1.Controls.Add(Me.lblNumber)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.txtNumber)
        Me.GroupBox1.Controls.Add(Me.lblSupplier)
        Me.GroupBox1.Controls.Add(Me.txtSupplier)
        Me.GroupBox1.Controls.Add(Me.lblQty)
        Me.GroupBox1.Controls.Add(Me.txtQtyInPack)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(432, 152)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Request Details"
        '
        'txtSupplier
        '
        Me.txtSupplier.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSupplier.Enabled = False
        Me.txtSupplier.Location = New System.Drawing.Point(128, 90)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.ReadOnly = True
        Me.txtSupplier.Size = New System.Drawing.Size(296, 21)
        Me.txtSupplier.TabIndex = 3
        Me.txtSupplier.Text = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtSupplierCode)
        Me.GroupBox2.Controls.Add(Me.txtBuyPrice)
        Me.GroupBox2.Controls.Add(Me.txtSellPrice)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtAmount)
        Me.GroupBox2.Controls.Add(Me.btnAddToOrder)
        Me.GroupBox2.Controls.Add(Me.btnCancel)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 200)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(432, 152)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Order Details"
        '
        'FRMAddtoOrder
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(448, 358)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(456, 392)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(456, 392)
        Me.Name = "FRMAddtoOrder"
        Me.Text = "Add Item to Order"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        oOrder = GetParameter(0)
        PartSupplier = GetParameter(1)
        ProductSupplier = GetParameter(2)
        PriceRequestID = GetParameter(3)

        LoadForm(sender, e, Me)

        If Not PartSupplier Is Nothing Then
            Dim oPart As Entity.Parts.Part = DB.Part.Part_Get(PartSupplier.PartID)

            Me.lblName.Text = "Part Name"
            Me.lblNumber.Text = "Part Number"
            Me.txtName.Text = oPart.Name
            Me.txtNumber.Text = oPart.Number
            Me.txtQtyInPack.Text = PartSupplier.QuantityInPack
            Me.txtSupplier.Text = DB.Supplier.Supplier_Get(PartSupplier.SupplierID).Name
        End If
        If Not ProductSupplier Is Nothing Then
            Dim oProduct As Entity.Products.Product = DB.Product.Product_Get(ProductSupplier.ProductID)

            Me.lblName.Text = "Product Name"
            Me.lblNumber.Text = "Product Number"
            Me.txtName.Text = oProduct.Name
            Me.txtNumber.Text = oProduct.Number
            Me.txtQtyInPack.Text = ProductSupplier.QuantityInPack
            Me.txtSupplier.Text = DB.Supplier.Supplier_Get(ProductSupplier.SupplierID).Name
        End If
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Private Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
        'DO NOTHING
    End Sub

#End Region

#Region "Properties"

    Private _oOrder As Entity.Orders.Order

    Private Property oOrder() As Entity.Orders.Order
        Get
            Return _oOrder
        End Get
        Set(ByVal value As Entity.Orders.Order)
            _oOrder = value
        End Set
    End Property

    'Private _OrderID As Integer
    'Public Property OrderID() As Integer
    '    Get
    '        Return _OrderID
    '    End Get
    '    Set(ByVal Value As Integer)
    '        _OrderID = Value
    '    End Set
    'End Property

    Private _partSupplier As Entity.PartSuppliers.PartSupplier

    Public Property PartSupplier() As Entity.PartSuppliers.PartSupplier
        Get
            Return _partSupplier
        End Get
        Set(ByVal Value As Entity.PartSuppliers.PartSupplier)
            _partSupplier = Value
        End Set
    End Property

    Private _productSupplier As Entity.ProductSuppliers.ProductSupplier

    Public Property ProductSupplier() As Entity.ProductSuppliers.ProductSupplier
        Get
            Return _productSupplier
        End Get
        Set(ByVal Value As Entity.ProductSuppliers.ProductSupplier)
            _productSupplier = Value
        End Set
    End Property

    Private _PriceRequestID As Integer

    Public Property PriceRequestID() As Integer
        Get
            Return _PriceRequestID
        End Get
        Set(ByVal Value As Integer)
            _PriceRequestID = Value
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub FRMAddtoOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub btnAddToOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToOrder.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If Not PartSupplier Is Nothing Then
                PartSupplier.IgnoreExceptionsOnSetMethods = True
                PartSupplier.SetPrice = Me.txtBuyPrice.Text.Trim
                PartSupplier.SetPartCode = Me.txtSupplierCode.Text.Trim

                Dim val As New Entity.PartSuppliers.PartSupplierValidator
                val.Validate(PartSupplier)

                Dim OrderPart As New Entity.OrderParts.OrderPart
                OrderPart.IgnoreExceptionsOnSetMethods = True
                OrderPart.SetSellPrice = Me.txtSellPrice.Text.Trim
                OrderPart.SetQuantity = Me.txtAmount.Text.Trim
                OrderPart.SetOrderID = oOrder.OrderID

                Dim val2 As New Entity.OrderParts.OrderPartValidator
                val2.Validate(OrderPart)

                PartSupplier = DB.PartSupplier.Insert(PartSupplier)

                OrderPart.SetBuyPrice = PartSupplier.Price
                OrderPart.SetPartSupplierID = PartSupplier.PartSupplierID

                DB.OrderPart.Insert(OrderPart, Not (oOrder.DoNotConsolidated))

                DB.PartPriceRequest.Complete(PriceRequestID)
            End If

            If Not ProductSupplier Is Nothing Then
                ProductSupplier.IgnoreExceptionsOnSetMethods = True
                ProductSupplier.SetPrice = Me.txtBuyPrice.Text.Trim
                ProductSupplier.SetProductCode = Me.txtSupplierCode.Text.Trim

                Dim val As New Entity.ProductSuppliers.ProductSupplierValidator
                val.Validate(ProductSupplier)

                Dim OrderProduct As New Entity.OrderProducts.OrderProduct
                OrderProduct.IgnoreExceptionsOnSetMethods = True
                OrderProduct.SetSellPrice = Me.txtSellPrice.Text.Trim
                OrderProduct.SetQuantity = Me.txtAmount.Text.Trim
                OrderProduct.SetOrderID = oOrder.OrderID

                Dim val2 As New Entity.OrderProducts.OrderProductValidator
                val2.Validate(OrderProduct)

                ProductSupplier = DB.ProductSupplier.Insert(ProductSupplier)

                OrderProduct.SetBuyPrice = ProductSupplier.Price
                OrderProduct.SetProductSupplierID = ProductSupplier.ProductSupplierID

                DB.OrderProduct.Insert(OrderProduct, True)

                DB.ProductPriceRequest.Complete(PriceRequestID)
            End If

            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

#End Region

End Class