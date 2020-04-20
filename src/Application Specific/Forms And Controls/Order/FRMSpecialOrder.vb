Imports System.Collections.Generic
Imports System.Linq
Imports System.Reflection

Public Class FRMSpecialOrder : Inherits FRMBaseForm

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal supplierCode As Integer, ByVal price As Double,
                   ByVal quantity As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        _supplierCode = supplierCode
        _price = price
        _quantity = quantity

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

    Friend WithEvents gpbSpecialOrder As GroupBox
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents lblQuantity As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnAddPart As Button
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents lblPrice As Label
    Friend WithEvents txtSupplier As TextBox
    Friend WithEvents lblSupplier As Label
    Friend WithEvents txtSPN As TextBox
    Friend WithEvents lblPartCode As Label
    Friend WithEvents txtPartName As TextBox
    Friend WithEvents lblPartName As Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.gpbSpecialOrder = New System.Windows.Forms.GroupBox()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAddPart = New System.Windows.Forms.Button()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.txtSupplier = New System.Windows.Forms.TextBox()
        Me.lblSupplier = New System.Windows.Forms.Label()
        Me.txtSPN = New System.Windows.Forms.TextBox()
        Me.lblPartCode = New System.Windows.Forms.Label()
        Me.txtPartName = New System.Windows.Forms.TextBox()
        Me.lblPartName = New System.Windows.Forms.Label()
        Me.gpbSpecialOrder.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpbSpecialOrder
        '
        Me.gpbSpecialOrder.Controls.Add(Me.txtQuantity)
        Me.gpbSpecialOrder.Controls.Add(Me.lblQuantity)
        Me.gpbSpecialOrder.Controls.Add(Me.btnCancel)
        Me.gpbSpecialOrder.Controls.Add(Me.btnAddPart)
        Me.gpbSpecialOrder.Controls.Add(Me.txtPrice)
        Me.gpbSpecialOrder.Controls.Add(Me.lblPrice)
        Me.gpbSpecialOrder.Controls.Add(Me.txtSupplier)
        Me.gpbSpecialOrder.Controls.Add(Me.lblSupplier)
        Me.gpbSpecialOrder.Controls.Add(Me.txtSPN)
        Me.gpbSpecialOrder.Controls.Add(Me.lblPartCode)
        Me.gpbSpecialOrder.Controls.Add(Me.txtPartName)
        Me.gpbSpecialOrder.Controls.Add(Me.lblPartName)
        Me.gpbSpecialOrder.Location = New System.Drawing.Point(12, 38)
        Me.gpbSpecialOrder.Name = "gpbSpecialOrder"
        Me.gpbSpecialOrder.Size = New System.Drawing.Size(449, 183)
        Me.gpbSpecialOrder.TabIndex = 17
        Me.gpbSpecialOrder.TabStop = False
        Me.gpbSpecialOrder.Text = "Special Order"
        '
        'txtQuantity
        '
        Me.txtQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtQuantity.Location = New System.Drawing.Point(95, 103)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(112, 21)
        Me.txtQuantity.TabIndex = 45
        '
        'lblQuantity
        '
        Me.lblQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblQuantity.Location = New System.Drawing.Point(11, 106)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(78, 18)
        Me.lblQuantity.TabIndex = 52
        Me.lblQuantity.Text = "Quantity"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(14, 148)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 24)
        Me.btnCancel.TabIndex = 47
        Me.btnCancel.Text = "Cancel"
        '
        'btnAddPart
        '
        Me.btnAddPart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddPart.Location = New System.Drawing.Point(367, 148)
        Me.btnAddPart.Name = "btnAddPart"
        Me.btnAddPart.Size = New System.Drawing.Size(71, 24)
        Me.btnAddPart.TabIndex = 46
        Me.btnAddPart.Text = "Add"
        '
        'txtPrice
        '
        Me.txtPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPrice.Location = New System.Drawing.Point(326, 62)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(112, 21)
        Me.txtPrice.TabIndex = 44
        '
        'lblPrice
        '
        Me.lblPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPrice.Location = New System.Drawing.Point(242, 65)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(78, 18)
        Me.lblPrice.TabIndex = 51
        Me.lblPrice.Text = "Price"
        '
        'txtSupplier
        '
        Me.txtSupplier.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSupplier.Enabled = False
        Me.txtSupplier.Location = New System.Drawing.Point(95, 62)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.Size = New System.Drawing.Size(112, 21)
        Me.txtSupplier.TabIndex = 43
        '
        'lblSupplier
        '
        Me.lblSupplier.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSupplier.Location = New System.Drawing.Point(11, 65)
        Me.lblSupplier.Name = "lblSupplier"
        Me.lblSupplier.Size = New System.Drawing.Size(78, 18)
        Me.lblSupplier.TabIndex = 50
        Me.lblSupplier.Text = "Supplier"
        '
        'txtSPN
        '
        Me.txtSPN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSPN.Location = New System.Drawing.Point(326, 18)
        Me.txtSPN.Name = "txtSPN"
        Me.txtSPN.Size = New System.Drawing.Size(112, 21)
        Me.txtSPN.TabIndex = 42
        '
        'lblPartCode
        '
        Me.lblPartCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPartCode.Location = New System.Drawing.Point(242, 21)
        Me.lblPartCode.Name = "lblPartCode"
        Me.lblPartCode.Size = New System.Drawing.Size(78, 18)
        Me.lblPartCode.TabIndex = 49
        Me.lblPartCode.Text = "Part Code"
        '
        'txtPartName
        '
        Me.txtPartName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPartName.Location = New System.Drawing.Point(95, 18)
        Me.txtPartName.Name = "txtPartName"
        Me.txtPartName.Size = New System.Drawing.Size(112, 21)
        Me.txtPartName.TabIndex = 41
        '
        'lblPartName
        '
        Me.lblPartName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPartName.Location = New System.Drawing.Point(11, 21)
        Me.lblPartName.Name = "lblPartName"
        Me.lblPartName.Size = New System.Drawing.Size(78, 18)
        Me.lblPartName.TabIndex = 48
        Me.lblPartName.Text = "Part Name"
        '
        'FRMSpecialOrder
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(471, 228)
        Me.ControlBox = False
        Me.Controls.Add(Me.gpbSpecialOrder)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRMSpecialOrder"
        Me.Text = "Orders - Special Order"
        Me.Controls.SetChildIndex(Me.gpbSpecialOrder, 0)
        Me.gpbSpecialOrder.ResumeLayout(False)
        Me.gpbSpecialOrder.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private _supplierCode As Integer = 0.0

    Public ReadOnly Property SupplierCode() As Integer
        Get
            Return _supplierCode
        End Get
    End Property

    Private _price As Double = 0.0

    Public ReadOnly Property Price() As Double
        Get
            Return _price
        End Get
    End Property

    Private _partName As String = ""

    Public ReadOnly Property PartName() As String
        Get
            Return _partName
        End Get
    End Property

    Private _spn As String = ""

    Public ReadOnly Property SPN() As String
        Get
            Return _spn
        End Get
    End Property

    Private _quantity As Integer = 0

    Public ReadOnly Property Quantity() As Integer
        Get
            Return _quantity
        End Get
    End Property

#End Region

#Region "Interface Methods"

    Public ReadOnly Property LoadedControl() As IUserControl
        Get
            Return Nothing
        End Get
    End Property

#End Region

#Region "Events"

    Private Sub btnAddPart_Click(sender As Object, e As EventArgs) Handles btnAddPart.Click
        _spn = Me.txtSPN.Text
        _partName = Me.txtPartName.Text
        Try
            _price = Convert.ToDouble(Me.txtPrice.Text)
            _quantity = Convert.ToInt32(Me.txtQuantity.Text)
        Catch ex As Exception
            ShowMessage("Quantity/Price is incorrect format", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        Me.DialogResult = DialogResult.OK
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub FRMSpecialOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If SupplierCode = 0 Then
            Me.txtPrice.Text = 0
            Me.txtSupplier.Text = ""
            Me.txtQuantity.Text = 1
        Else
            Me.txtPrice.Text = Price
            Dim supplierID As Integer = DB.PartSupplier.PartSupplier_Get(SupplierCode).SupplierID
            Dim supplier As String = DB.Supplier.Supplier_Get(supplierID).Name
            Me.txtSupplier.Text = supplier
            Me.txtQuantity.Text = Quantity
        End If

    End Sub

#End Region

End Class