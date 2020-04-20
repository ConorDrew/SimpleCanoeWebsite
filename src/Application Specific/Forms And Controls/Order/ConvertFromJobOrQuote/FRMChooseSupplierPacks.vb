Public Class FRMChooseSupplierPacks : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPacks As System.Windows.Forms.ComboBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboPacks = New System.Windows.Forms.ComboBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(248, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Item available in the following amounts:"
        '
        'cboPacks
        '
        Me.cboPacks.Location = New System.Drawing.Point(256, 40)
        Me.cboPacks.Name = "cboPacks"
        Me.cboPacks.Size = New System.Drawing.Size(240, 21)
        Me.cboPacks.TabIndex = 3
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(416, 72)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(8, 72)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        '
        'FRMChooseSupplierPacks
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(504, 102)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cboPacks)
        Me.Controls.Add(Me.Label1)
        Me.MaximumSize = New System.Drawing.Size(512, 136)
        Me.MinimumSize = New System.Drawing.Size(512, 136)
        Me.Name = "FRMChooseSupplierPacks"
        Me.Text = "Choose Packs"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cboPacks, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        SupplierID = GetParameter(0)
        ProductID = GetParameter(1)
        PartID = GetParameter(2)
        Trans = GetParameter(3)
        LoadForm(sender, e, Me)
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe

    End Sub

#End Region

#Region "Properties"

    Private _trans As SqlClient.SqlTransaction
    Public Property Trans() As SqlClient.SqlTransaction
        Get
            Return _trans
        End Get
        Set(ByVal value As SqlClient.SqlTransaction)
            _trans = value
        End Set
    End Property

    Private _supplierID As Integer

    Public Property SupplierID()
        Get
            Return _supplierID
        End Get
        Set(ByVal Value)
            _supplierID = Value
        End Set
    End Property

    Private _productID As Integer

    Public Property ProductID() As Integer
        Get
            Return _productID
        End Get
        Set(ByVal Value As Integer)
            _productID = Value
        End Set
    End Property

    Private _partID As Integer

    Public Property PartID() As Integer
        Get
            Return _partID
        End Get
        Set(ByVal Value As Integer)
            _partID = Value
        End Set
    End Property

    Private _productSupplierID As Integer
    Public Property ProductSupplierID() As Integer
        Get
            Return _productSupplierID
        End Get
        Set(ByVal Value As Integer)
            _productSupplierID = Value
        End Set
    End Property

    Private _partSupplierID As Integer
    Public Property PartSupplierID() As Integer
        Get
            Return _partSupplierID
        End Get
        Set(ByVal Value As Integer)
            _partSupplierID = Value
        End Set
    End Property

    Private _Amount As Integer
    Public Property Amount() As Integer
        Get
            Return _Amount
        End Get
        Set(ByVal Value As Integer)
            _Amount = Value
        End Set
    End Property

#End Region

#Region "Events"
    Private Sub FRMChooseSupplierPacks_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
        LoadPacks()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If ProductID > 0 Then
            ProductSupplierID = Combo.GetSelectedItemValue(cboPacks)
        Else
            PartSupplierID = Combo.GetSelectedItemValue(cboPacks)
        End If
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
#End Region

#Region "Functions"

    Public Function LoadPacks()
        If ProductID > 0 Then

            Dim dtProductPacks As DataTable

            If Not Trans Is Nothing Then
                dtProductPacks = DB.ProductSupplier.ProductSupplierPacks_Get(ProductID, SupplierID, Trans).Table
            Else
                dtProductPacks = DB.ProductSupplier.ProductSupplierPacks_Get(ProductID, SupplierID).Table
            End If

            Combo.SetUpCombo(cboPacks, dtProductPacks, "ProductSupplierID", "Packs", Entity.Sys.Enums.ComboValues.Please_Select)
            Combo.SetSelectedComboItem_By_Value(cboPacks, dtProductPacks.Rows(0).Item("ProductSupplierID"))

        ElseIf PartID > 0 Then

            Dim dtPartPacks As DataTable

            If Not Trans Is Nothing Then
                dtPartPacks = DB.PartSupplier.PartSupplierPacks_Get(PartID, SupplierID, Trans).Table
            Else
                dtPartPacks = DB.PartSupplier.PartSupplierPacks_Get(PartID, SupplierID).Table
            End If

            Combo.SetUpCombo(cboPacks, dtPartPacks, "PartSupplierID", "Packs", Entity.Sys.Enums.ComboValues.Please_Select)
            Combo.SetSelectedComboItem_By_Value(cboPacks, dtPartPacks.Rows(0).Item("PartSupplierID"))
        End If
    End Function
#End Region

End Class
