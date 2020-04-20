Public Class FRMAddToQuote : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox

    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
    Friend WithEvents txtBuyPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblNumber As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents txtSupplier As System.Windows.Forms.TextBox
    Friend WithEvents lblQty As System.Windows.Forms.Label
    Friend WithEvents txtQtyInPack As System.Windows.Forms.TextBox
    Friend WithEvents btnConfirm As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSupplierCode = New System.Windows.Forms.TextBox
        Me.txtBuyPrice = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnConfirm = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblName = New System.Windows.Forms.Label
        Me.lblNumber = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtNumber = New System.Windows.Forms.TextBox
        Me.lblSupplier = New System.Windows.Forms.Label
        Me.txtSupplier = New System.Windows.Forms.TextBox
        Me.lblQty = New System.Windows.Forms.Label
        Me.txtQtyInPack = New System.Windows.Forms.TextBox
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtSupplierCode)
        Me.GroupBox2.Controls.Add(Me.txtBuyPrice)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.btnConfirm)
        Me.GroupBox2.Controls.Add(Me.btnCancel)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 195)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(512, 125)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Quote Details"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 23)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Supplier Code:"
        '
        'txtSupplierCode
        '
        Me.txtSupplierCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSupplierCode.Location = New System.Drawing.Point(128, 24)
        Me.txtSupplierCode.Name = "txtSupplierCode"
        Me.txtSupplierCode.Size = New System.Drawing.Size(376, 21)
        Me.txtSupplierCode.TabIndex = 5
        Me.txtSupplierCode.Text = ""
        '
        'txtBuyPrice
        '
        Me.txtBuyPrice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBuyPrice.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuyPrice.Location = New System.Drawing.Point(128, 63)
        Me.txtBuyPrice.Name = "txtBuyPrice"
        Me.txtBuyPrice.Size = New System.Drawing.Size(376, 21)
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
        'btnConfirm
        '
        Me.btnConfirm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConfirm.Location = New System.Drawing.Point(352, 96)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(88, 23)
        Me.btnConfirm.TabIndex = 9
        Me.btnConfirm.Text = "Confirm"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(448, 96)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(56, 23)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
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
        Me.GroupBox1.Location = New System.Drawing.Point(8, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(512, 152)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Request Details"
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
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(128, 24)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(376, 21)
        Me.txtName.TabIndex = 1
        Me.txtName.Text = ""
        '
        'txtNumber
        '
        Me.txtNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNumber.Enabled = False
        Me.txtNumber.Location = New System.Drawing.Point(128, 63)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.ReadOnly = True
        Me.txtNumber.Size = New System.Drawing.Size(376, 21)
        Me.txtNumber.TabIndex = 2
        Me.txtNumber.Text = ""
        '
        'lblSupplier
        '
        Me.lblSupplier.Location = New System.Drawing.Point(8, 88)
        Me.lblSupplier.Name = "lblSupplier"
        Me.lblSupplier.Size = New System.Drawing.Size(80, 24)
        Me.lblSupplier.TabIndex = 5
        Me.lblSupplier.Text = "Supplier:"
        '
        'txtSupplier
        '
        Me.txtSupplier.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSupplier.Enabled = False
        Me.txtSupplier.Location = New System.Drawing.Point(128, 95)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.ReadOnly = True
        Me.txtSupplier.Size = New System.Drawing.Size(376, 21)
        Me.txtSupplier.TabIndex = 3
        Me.txtSupplier.Text = ""
        '
        'lblQty
        '
        Me.lblQty.Location = New System.Drawing.Point(8, 120)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(120, 23)
        Me.lblQty.TabIndex = 6
        Me.lblQty.Text = "Quantity In Pack:"
        '
        'txtQtyInPack
        '
        Me.txtQtyInPack.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQtyInPack.Enabled = False
        Me.txtQtyInPack.Location = New System.Drawing.Point(128, 127)
        Me.txtQtyInPack.Name = "txtQtyInPack"
        Me.txtQtyInPack.ReadOnly = True
        Me.txtQtyInPack.Size = New System.Drawing.Size(376, 21)
        Me.txtQtyInPack.TabIndex = 4
        Me.txtQtyInPack.Text = ""
        '
        'FRMAddToQuote
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(528, 326)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximumSize = New System.Drawing.Size(536, 360)
        Me.MinimumSize = New System.Drawing.Size(536, 360)
        Me.Name = "FRMAddToQuote"
        Me.Text = "Confrim Price Request"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        QuoteID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(0))
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

    Private _QuoteID As Integer

    Public Property QuoteID() As Integer
        Get
            Return _QuoteID
        End Get
        Set(ByVal Value As Integer)
            _QuoteID = Value
        End Set
    End Property

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

    Private Sub FRMAddToQuote_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If Not PartSupplier Is Nothing Then
                PartSupplier.IgnoreExceptionsOnSetMethods = True
                PartSupplier.SetPrice = Me.txtBuyPrice.Text.Trim
                PartSupplier.SetPartCode = Me.txtSupplierCode.Text.Trim

                Dim val As New Entity.PartSuppliers.PartSupplierValidator
                val.Validate(PartSupplier)

                PartSupplier = DB.PartSupplier.Insert(PartSupplier)

                DB.PartPriceRequest.Complete(PriceRequestID)

            End If

            If Not ProductSupplier Is Nothing Then
                ProductSupplier.IgnoreExceptionsOnSetMethods = True
                ProductSupplier.SetPrice = Me.txtBuyPrice.Text.Trim
                ProductSupplier.SetProductCode = Me.txtSupplierCode.Text.Trim

                Dim val As New Entity.ProductSuppliers.ProductSupplierValidator
                val.Validate(ProductSupplier)

                ProductSupplier = DB.ProductSupplier.Insert(ProductSupplier)

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