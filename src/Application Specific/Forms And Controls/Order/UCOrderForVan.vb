Public Class UCOrderForVan : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

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
    Friend WithEvents grpVanDetails As System.Windows.Forms.GroupBox
    Friend WithEvents btnFindVan As System.Windows.Forms.Button
    Friend WithEvents txtVan As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDeliveryAddress As System.Windows.Forms.Button
    Friend WithEvents txtDeliveryAddress As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpVanDetails = New System.Windows.Forms.GroupBox()
        Me.btnDeliveryAddress = New System.Windows.Forms.Button()
        Me.txtDeliveryAddress = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnFindVan = New System.Windows.Forms.Button()
        Me.txtVan = New System.Windows.Forms.TextBox()
        Me.grpVanDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpVanDetails
        '
        Me.grpVanDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpVanDetails.Controls.Add(Me.btnDeliveryAddress)
        Me.grpVanDetails.Controls.Add(Me.txtDeliveryAddress)
        Me.grpVanDetails.Controls.Add(Me.Label1)
        Me.grpVanDetails.Controls.Add(Me.btnFindVan)
        Me.grpVanDetails.Controls.Add(Me.txtVan)
        Me.grpVanDetails.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpVanDetails.Location = New System.Drawing.Point(8, 8)
        Me.grpVanDetails.Name = "grpVanDetails"
        Me.grpVanDetails.Size = New System.Drawing.Size(576, 272)
        Me.grpVanDetails.TabIndex = 2
        Me.grpVanDetails.TabStop = False
        Me.grpVanDetails.Text = "Stock Profile Details"
        '
        'btnDeliveryAddress
        '
        Me.btnDeliveryAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeliveryAddress.BackColor = System.Drawing.Color.White
        Me.btnDeliveryAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeliveryAddress.Location = New System.Drawing.Point(536, 105)
        Me.btnDeliveryAddress.Name = "btnDeliveryAddress"
        Me.btnDeliveryAddress.Size = New System.Drawing.Size(32, 23)
        Me.btnDeliveryAddress.TabIndex = 5
        Me.btnDeliveryAddress.Text = "..."
        Me.btnDeliveryAddress.UseVisualStyleBackColor = False
        '
        'txtDeliveryAddress
        '
        Me.txtDeliveryAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDeliveryAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliveryAddress.Location = New System.Drawing.Point(8, 105)
        Me.txtDeliveryAddress.Name = "txtDeliveryAddress"
        Me.txtDeliveryAddress.ReadOnly = True
        Me.txtDeliveryAddress.Size = New System.Drawing.Size(520, 21)
        Me.txtDeliveryAddress.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Delivery Address for Supplier"
        '
        'btnFindVan
        '
        Me.btnFindVan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindVan.BackColor = System.Drawing.Color.White
        Me.btnFindVan.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindVan.Location = New System.Drawing.Point(536, 28)
        Me.btnFindVan.Name = "btnFindVan"
        Me.btnFindVan.Size = New System.Drawing.Size(32, 23)
        Me.btnFindVan.TabIndex = 2
        Me.btnFindVan.Text = "..."
        Me.btnFindVan.UseVisualStyleBackColor = False
        '
        'txtVan
        '
        Me.txtVan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVan.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVan.Location = New System.Drawing.Point(8, 28)
        Me.txtVan.Name = "txtVan"
        Me.txtVan.ReadOnly = True
        Me.txtVan.Size = New System.Drawing.Size(520, 21)
        Me.txtVan.TabIndex = 1
        '
        'UCOrderForVan
        '
        Me.Controls.Add(Me.grpVanDetails)
        Me.Name = "UCOrderForVan"
        Me.Size = New System.Drawing.Size(592, 288)
        Me.grpVanDetails.ResumeLayout(False)
        Me.grpVanDetails.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return Nothing
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged
    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _oVan As Entity.Vans.Van
    Public Property Van() As Entity.Vans.Van
        Get
            Return _oVan
        End Get
        Set(ByVal Value As Entity.Vans.Van)
            _oVan = Value
            Me.txtVan.Text = _oVan.Registration
        End Set
    End Property

    Private _oDeliveryAddress As Entity.Warehouses.Warehouse
    Public Property DeliveryAddress() As Entity.Warehouses.Warehouse
        Get
            Return _oDeliveryAddress
        End Get
        Set(ByVal Value As Entity.Warehouses.Warehouse)
            _oDeliveryAddress = Value
            Me.txtDeliveryAddress.Text = _oDeliveryAddress.Name
            DeliveryAddressID = _oDeliveryAddress.WarehouseID
        End Set
    End Property

    Private _deliveryAddressID As Integer = 0
    Public Property DeliveryAddressID() As Integer
        Get
            Return _deliveryAddressID
        End Get
        Set(ByVal Value As Integer)
            _deliveryAddressID = Value
        End Set
    End Property
#End Region

#Region "Events"

    Private Sub UCOrderForVan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub btnFindVan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVan.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblVan)
        If Not ID = 0 Then
            Van = DB.Van.Van_Get(ID)
        End If
    End Sub

    Private Sub btnDeliveryAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeliveryAddress.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse)
        If Not ID = 0 Then
            DeliveryAddress = DB.Warehouse.Warehouse_Get(ID)
        End If
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        'DO NOTHING
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        'DO NOTHING
    End Function

#End Region

End Class
