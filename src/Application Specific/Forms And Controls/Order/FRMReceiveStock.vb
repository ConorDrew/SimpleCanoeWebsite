Public Class FRMReceiveStock : Inherits FSM.FRMBaseForm : Implements IForm

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

    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtQuantityPreviouslyReceived As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalquantity As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantityInput As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents lblItemName As System.Windows.Forms.Label
    Friend WithEvents lblItemNumber As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblItemName = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtNumber = New System.Windows.Forms.TextBox
        Me.lblItemNumber = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtQuantityPreviouslyReceived = New System.Windows.Forms.TextBox
        Me.txtTotalquantity = New System.Windows.Forms.TextBox
        Me.txtQuantityInput = New System.Windows.Forms.TextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtLocation = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblItemName
        '
        Me.lblItemName.Location = New System.Drawing.Point(16, 24)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(96, 23)
        Me.lblItemName.TabIndex = 2
        Me.lblItemName.Text = "Item Name:"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(136, 26)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(288, 21)
        Me.txtName.TabIndex = 1
        '
        'txtNumber
        '
        Me.txtNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNumber.Location = New System.Drawing.Point(136, 56)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.ReadOnly = True
        Me.txtNumber.Size = New System.Drawing.Size(288, 21)
        Me.txtNumber.TabIndex = 2
        '
        'lblItemNumber
        '
        Me.lblItemNumber.Location = New System.Drawing.Point(16, 56)
        Me.lblItemNumber.Name = "lblItemNumber"
        Me.lblItemNumber.Size = New System.Drawing.Size(96, 23)
        Me.lblItemNumber.TabIndex = 4
        Me.lblItemNumber.Text = "Item Number:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Total Ordered:"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 23)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Total Received :"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(15, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 23)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Quantity Received:"
        '
        'txtQuantityPreviouslyReceived
        '
        Me.txtQuantityPreviouslyReceived.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQuantityPreviouslyReceived.Location = New System.Drawing.Point(136, 154)
        Me.txtQuantityPreviouslyReceived.Name = "txtQuantityPreviouslyReceived"
        Me.txtQuantityPreviouslyReceived.ReadOnly = True
        Me.txtQuantityPreviouslyReceived.Size = New System.Drawing.Size(288, 21)
        Me.txtQuantityPreviouslyReceived.TabIndex = 5
        '
        'txtTotalquantity
        '
        Me.txtTotalquantity.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalquantity.Location = New System.Drawing.Point(136, 122)
        Me.txtTotalquantity.Name = "txtTotalquantity"
        Me.txtTotalquantity.ReadOnly = True
        Me.txtTotalquantity.Size = New System.Drawing.Size(288, 21)
        Me.txtTotalquantity.TabIndex = 4
        '
        'txtQuantityInput
        '
        Me.txtQuantityInput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQuantityInput.Location = New System.Drawing.Point(136, 24)
        Me.txtQuantityInput.Name = "txtQuantityInput"
        Me.txtQuantityInput.Size = New System.Drawing.Size(224, 21)
        Me.txtQuantityInput.TabIndex = 6
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(368, 24)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(56, 23)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "OK"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 23)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Order For:"
        '
        'txtLocation
        '
        Me.txtLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLocation.Location = New System.Drawing.Point(136, 90)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.ReadOnly = True
        Me.txtLocation.Size = New System.Drawing.Size(288, 21)
        Me.txtLocation.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblItemNumber)
        Me.GroupBox1.Controls.Add(Me.lblItemName)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtNumber)
        Me.GroupBox1.Controls.Add(Me.txtLocation)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtTotalquantity)
        Me.GroupBox1.Controls.Add(Me.txtQuantityPreviouslyReceived)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(432, 184)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Stock Details"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.txtQuantityInput)
        Me.GroupBox2.Controls.Add(Me.btnOK)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 232)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(432, 56)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Stock Received"
        '
        'FRMReceiveStock
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(448, 302)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(456, 336)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(456, 336)
        Me.Name = "FRMReceiveStock"
        Me.Text = "Stock Received Manager"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        Order = DB.Order.Order_Get(Entity.Sys.Helper.MakeIntegerValid(GetParameter(0)))
        OrderType = Entity.Sys.Helper.MakeStringValid(GetParameter(1))
        ID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(2))

        LoadForm(sender, e, Me)
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

    Private _oOrder As Entity.Orders.Order = Nothing

    Public Property Order() As Entity.Orders.Order
        Get
            Return _oOrder
        End Get
        Set(ByVal Value As Entity.Orders.Order)
            _oOrder = Value
        End Set
    End Property

    Private _OrderType As String = ""

    Public Property OrderType() As String
        Get
            Return _OrderType
        End Get
        Set(ByVal Value As String)
            _OrderType = Value

            Select Case OrderType
                Case "OrderProduct"
                    Me.lblItemName.Text = "Product Name: "
                    Me.lblItemNumber.Text = "Product Number: "
                Case "OrderPart"
                    Me.lblItemName.Text = "Part Name: "
                    Me.lblItemNumber.Text = "Part Number: "
                Case "OrderLocationProduct"
                    Me.lblItemName.Text = "Product Name: "
                    Me.lblItemNumber.Text = "Product Number: "
                Case "OrderLocationPart"
                    Me.lblItemName.Text = "Part Name: "
                    Me.lblItemNumber.Text = "Part Number: "
            End Select
        End Set
    End Property

    Private _ID As Integer = 0

    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal Value As Integer)
            _ID = Value

            Dim oProduct As Entity.Products.Product
            Dim oPart As Entity.Parts.Part

            Select Case OrderType
                Case "OrderProduct"
                    OrderProduct = DB.OrderProduct.OrderProduct_Get(ID)
                    Dim oProductSupplier As Entity.ProductSuppliers.ProductSupplier = DB.ProductSupplier.ProductSupplier_Get(OrderProduct.ProductSupplierID)
                    oProduct = DB.Product.Product_Get(oProductSupplier.ProductID)

                    Me.txtTotalquantity.Text = OrderProduct.Quantity
                    Me.txtQuantityPreviouslyReceived.Text = OrderProduct.QuantityReceived
                    Me.txtName.Text = oProduct.Name
                    Me.txtNumber.Text = oProduct.Number
                Case "OrderPart"
                    OrderPart = DB.OrderPart.OrderPart_Get(ID)
                    Dim oPartSupplier As Entity.PartSuppliers.PartSupplier = DB.PartSupplier.PartSupplier_Get(OrderPart.PartSupplierID)
                    oPart = DB.Part.Part_Get(oPartSupplier.PartID)

                    Me.txtTotalquantity.Text = OrderPart.Quantity
                    Me.txtQuantityPreviouslyReceived.Text = OrderPart.QuantityReceived
                    Me.txtName.Text = oPart.Name
                    Me.txtNumber.Text = oPart.Number
                Case "OrderLocationProduct"
                    OrderLocationProduct = DB.OrderLocationProduct.OrderLocationProduct_Get(ID)
                    oProduct = DB.Product.Product_Get(OrderLocationProduct.ProductID)

                    Me.txtTotalquantity.Text = OrderLocationProduct.Quantity
                    Me.txtQuantityPreviouslyReceived.Text = OrderLocationProduct.QuantityReceived
                    Me.txtName.Text = oProduct.Name
                    Me.txtNumber.Text = oProduct.Number
                Case "OrderLocationPart"
                    OrderLocationPart = DB.OrderLocationPart.OrderLocationPart_Get(ID)
                    oPart = DB.Part.Part_Get(OrderLocationPart.PartID)

                    Me.txtTotalquantity.Text = OrderLocationPart.Quantity
                    Me.txtQuantityPreviouslyReceived.Text = OrderLocationPart.QuantityReceived
                    Me.txtName.Text = oPart.Name
                    Me.txtNumber.Text = oPart.Number
            End Select

            Select Case Order.OrderTypeID
                Case CInt(Entity.Sys.Enums.OrderType.Customer)
                    Dim oSiteOrder As Entity.SiteOrders.SiteOrder = DB.SiteOrder.SiteOrder_GetForOrder(Order.OrderID)
                    If Not oSiteOrder Is Nothing Then
                        Dim oSite As Entity.Sites.Site = DB.Sites.Get(oSiteOrder.SiteID)
                        Dim oCustomer As Entity.Customers.Customer = DB.Customer.Customer_Get(oSite.CustomerID)
                        Me.txtLocation.Text = "Property:" & oSite.Address1 & ", " & oSite.Postcode & " (" & oCustomer.AccountNumber & ")"
                    Else
                        Dim oCustomer As Entity.Customers.Customer = DB.Customer.Customer_GetForOrder(Order.OrderID)
                        Me.txtLocation.Text = "Customer:" & oCustomer.Name & " - " & oCustomer.AccountNumber
                    End If

                Case CInt(Entity.Sys.Enums.OrderType.Job)
                    Me.txtLocation.Text = "Engineer Visit"
                Case Else
                    Dim oOrderLocation As Entity.OrderLocations.OrderLocation = DB.OrderLocation.OrderLocation_GetForOrder(Order.OrderID)
                    Dim oLocation As Entity.Locationss.Locations = DB.Location.Locations_Get(oOrderLocation.LocationID)
                    If oLocation.VanID > 0 Then
                        Me.txtLocation.Text = "Van: " & DB.Van.Van_Get(oLocation.VanID).Registration
                    ElseIf oLocation.WarehouseID > 0 Then
                        Me.txtLocation.Text = "Warehouse: " & DB.Warehouse.Warehouse_Get(oLocation.WarehouseID).Name
                    End If
            End Select
        End Set
    End Property

    Private _orderPart As Entity.OrderParts.OrderPart

    Public Property OrderPart() As Entity.OrderParts.OrderPart
        Get
            Return _orderPart
        End Get
        Set(ByVal Value As Entity.OrderParts.OrderPart)
            _orderPart = Value
        End Set
    End Property

    Private _orderProduct As Entity.OrderProducts.OrderProduct

    Public Property OrderProduct() As Entity.OrderProducts.OrderProduct
        Get
            Return _orderProduct
        End Get
        Set(ByVal Value As Entity.OrderProducts.OrderProduct)
            _orderProduct = Value
        End Set
    End Property

    Private _orderLocationProduct As Entity.OrderLocationProduct.OrderLocationProduct

    Public Property OrderLocationProduct() As Entity.OrderLocationProduct.OrderLocationProduct
        Get
            Return _orderLocationProduct
        End Get
        Set(ByVal Value As Entity.OrderLocationProduct.OrderLocationProduct)
            _orderLocationProduct = Value
        End Set
    End Property

    Private _orderLocationPart As Entity.OrderLocationPart.OrderLocationPart

    Public Property OrderLocationPart() As Entity.OrderLocationPart.OrderLocationPart
        Get
            Return _orderLocationPart
        End Get
        Set(ByVal Value As Entity.OrderLocationPart.OrderLocationPart)
            _orderLocationPart = Value
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub FRMReceiveStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not Entity.Sys.Helper.IsValidInteger(Me.txtQuantityInput.Text.Trim) Then
            ShowMessage("Please enter the quantity that has been received", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            If (CInt(Me.txtQuantityInput.Text.Trim) + CInt(Me.txtQuantityPreviouslyReceived.Text.Trim)) > CInt(Me.txtTotalquantity.Text.Trim) Then
                ShowMessage("Quantity received can not be greater than the quantity ordered", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        UpdateOrderItems(CInt(Me.txtQuantityInput.Text.Trim))
    End Sub

#End Region

#Region "Functions"

    Public Sub UpdateOrderItems(ByVal QuantityInput As Integer)
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case OrderType
                Case "OrderProduct"
                    OrderProduct.SetQuantityReceived = OrderProduct.QuantityReceived + QuantityInput
                    DB.OrderProduct.Update(OrderProduct)

                    Select Case Order.OrderTypeID
                        Case CInt(Entity.Sys.Enums.OrderType.Customer)
                            'DO NOTHING
                        Case CInt(Entity.Sys.Enums.OrderType.Job)
                            'DO NOTHING
                        Case CInt(Entity.Sys.Enums.OrderType.StockProfile)
                            'DO NOTHING - THIS WILL BE DONE ON THE PDA
                        Case CInt(Entity.Sys.Enums.OrderType.Warehouse)
                            Dim oOrderLocation As Entity.OrderLocations.OrderLocation = DB.OrderLocation.OrderLocation_GetForOrder(OrderProduct.OrderID)
                            Dim oProductSupplier As Entity.ProductSuppliers.ProductSupplier = DB.ProductSupplier.ProductSupplier_Get(OrderProduct.ProductSupplierID)

                            Dim oProductTransaction As New Entity.ProductTransactions.ProductTransaction
                            oProductTransaction.SetLocationID = oOrderLocation.LocationID
                            oProductTransaction.SetProductID = oProductSupplier.ProductID
                            oProductTransaction.SetOrderProductID = OrderProduct.OrderProductID
                            oProductTransaction.SetAmount = QuantityInput * oProductSupplier.QuantityInPack
                            oProductTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockIn)
                            DB.ProductTransaction.Insert(oProductTransaction)
                    End Select
                Case "OrderPart"
                    OrderPart.SetQuantityReceived = OrderPart.QuantityReceived + QuantityInput
                    DB.OrderPart.Update(OrderPart)

                    Select Case Order.OrderTypeID
                        Case CInt(Entity.Sys.Enums.OrderType.Customer)
                            'DO NOTHING
                        Case CInt(Entity.Sys.Enums.OrderType.Job)
                            'DO NOTHING
                        Case CInt(Entity.Sys.Enums.OrderType.StockProfile)
                            'DO NOTHING - THIS WILL BE DONE ON THE PDA
                        Case CInt(Entity.Sys.Enums.OrderType.Warehouse)
                            Dim oOrderLocation As Entity.OrderLocations.OrderLocation = DB.OrderLocation.OrderLocation_GetForOrder(OrderPart.OrderID)
                            Dim oPartSupplier As Entity.PartSuppliers.PartSupplier = DB.PartSupplier.PartSupplier_Get(OrderPart.PartSupplierID)

                            Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                            oPartTransaction.SetLocationID = oOrderLocation.LocationID
                            oPartTransaction.SetPartID = oPartSupplier.PartID
                            oPartTransaction.SetOrderPartID = OrderPart.OrderPartID
                            oPartTransaction.SetAmount = QuantityInput * oPartSupplier.QuantityInPack
                            oPartTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockIn)
                            DB.PartTransaction.Insert(oPartTransaction)
                    End Select
                Case "OrderLocationProduct"
                    Dim oProductTransaction As Entity.ProductTransactions.ProductTransaction = DB.ProductTransaction.ProductTransaction_GetByOrderLocationProduct(OrderLocationProduct.OrderLocationProductID)

                    oProductTransaction.SetAmount = oProductTransaction.Amount + QuantityInput
                    DB.ProductTransaction.Update(oProductTransaction)

                    oProductTransaction.SetLocationID = OrderLocationProduct.LocationID
                    oProductTransaction.SetProductID = OrderLocationProduct.ProductID
                    oProductTransaction.SetOrderLocationProductID = OrderLocationProduct.OrderLocationProductID
                    oProductTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockOut)
                    oProductTransaction.SetAmount = -QuantityInput
                    DB.ProductTransaction.Insert(oProductTransaction)

                    OrderLocationProduct.SetQuantityReceived = OrderLocationProduct.QuantityReceived + QuantityInput
                    DB.OrderLocationProduct.Update(OrderLocationProduct)

                    Select Case Order.OrderTypeID
                        Case CInt(Entity.Sys.Enums.OrderType.Customer)
                            'DO NOTHING
                        Case CInt(Entity.Sys.Enums.OrderType.Job)
                            'DO NOTHING
                        Case CInt(Entity.Sys.Enums.OrderType.StockProfile)
                            'DO NOTHING - THIS WILL BE DONE ON THE PDA
                        Case CInt(Entity.Sys.Enums.OrderType.Warehouse)
                            Dim oOrderLocation As Entity.OrderLocations.OrderLocation
                            oOrderLocation = DB.OrderLocation.OrderLocation_GetForOrder(OrderLocationProduct.OrderID)
                            oProductTransaction.SetLocationID = oOrderLocation.LocationID
                            oProductTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockIn)
                            oProductTransaction.SetOrderLocationProductID = OrderLocationProduct.OrderLocationProductID
                            oProductTransaction.SetAmount = QuantityInput
                            oProductTransaction.SetProductID = OrderLocationProduct.ProductID
                            DB.ProductTransaction.Insert(oProductTransaction)
                    End Select
                Case "OrderLocationPart"
                    Dim oPartTransaction As Entity.PartTransactions.PartTransaction = DB.PartTransaction.PartTransaction_GetByOrderLocationPart(OrderLocationPart.OrderLocationPartID)

                    oPartTransaction.SetAmount = oPartTransaction.Amount + QuantityInput
                    DB.PartTransaction.Update(oPartTransaction)

                    oPartTransaction.SetLocationID = OrderLocationPart.LocationID
                    oPartTransaction.SetPartID = OrderLocationPart.PartID
                    oPartTransaction.SetOrderLocationPartID = OrderLocationPart.OrderLocationPartID
                    oPartTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockOut)
                    oPartTransaction.SetAmount = -QuantityInput
                    DB.PartTransaction.Insert(oPartTransaction)

                    OrderLocationPart.SetQuantityReceived = OrderLocationPart.QuantityReceived + QuantityInput
                    DB.OrderLocationPart.Update(OrderLocationPart)

                    Select Case Order.OrderTypeID
                        Case CInt(Entity.Sys.Enums.OrderType.Customer)
                            'DO NOTHING
                        Case CInt(Entity.Sys.Enums.OrderType.Job)
                            'DO NOTHING
                        Case CInt(Entity.Sys.Enums.OrderType.StockProfile)
                            'DO NOTHING - THIS WILL BE DONE ON THE PDA
                        Case CInt(Entity.Sys.Enums.OrderType.Warehouse)
                            Dim oOrderLocation As Entity.OrderLocations.OrderLocation
                            oOrderLocation = DB.OrderLocation.OrderLocation_GetForOrder(OrderLocationPart.OrderID)
                            oPartTransaction.SetLocationID = oOrderLocation.LocationID
                            oPartTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockIn)
                            oPartTransaction.SetOrderLocationPartID = OrderLocationPart.OrderLocationPartID
                            oPartTransaction.SetAmount = QuantityInput
                            oPartTransaction.SetPartID = OrderLocationPart.PartID
                            DB.PartTransaction.Insert(oPartTransaction)
                    End Select
            End Select

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