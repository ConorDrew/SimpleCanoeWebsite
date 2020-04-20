Public Class UCOrderForWarehouse : Inherits FSM.UCBase : Implements IUserControl

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
    Friend WithEvents grpWarehouseDetails As System.Windows.Forms.GroupBox
    Friend WithEvents btnFindWarehouse As System.Windows.Forms.Button
    Friend WithEvents txtWarehouse As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpWarehouseDetails = New System.Windows.Forms.GroupBox
        Me.btnFindWarehouse = New System.Windows.Forms.Button
        Me.txtWarehouse = New System.Windows.Forms.TextBox
        Me.grpWarehouseDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpWarehouseDetails
        '
        Me.grpWarehouseDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpWarehouseDetails.Controls.Add(Me.btnFindWarehouse)
        Me.grpWarehouseDetails.Controls.Add(Me.txtWarehouse)
        Me.grpWarehouseDetails.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpWarehouseDetails.Location = New System.Drawing.Point(8, 8)
        Me.grpWarehouseDetails.Name = "grpWarehouseDetails"
        Me.grpWarehouseDetails.Size = New System.Drawing.Size(552, 64)
        Me.grpWarehouseDetails.TabIndex = 1
        Me.grpWarehouseDetails.TabStop = False
        Me.grpWarehouseDetails.Text = "Warehouse Details"
        '
        'btnFindWarehouse
        '
        Me.btnFindWarehouse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindWarehouse.BackColor = System.Drawing.Color.White
        Me.btnFindWarehouse.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindWarehouse.Location = New System.Drawing.Point(512, 31)
        Me.btnFindWarehouse.Name = "btnFindWarehouse"
        Me.btnFindWarehouse.Size = New System.Drawing.Size(32, 23)
        Me.btnFindWarehouse.TabIndex = 2
        Me.btnFindWarehouse.Text = "..."
        '
        'txtWarehouse
        '
        Me.txtWarehouse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWarehouse.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWarehouse.Location = New System.Drawing.Point(8, 31)
        Me.txtWarehouse.Name = "txtWarehouse"
        Me.txtWarehouse.ReadOnly = True
        Me.txtWarehouse.Size = New System.Drawing.Size(496, 21)
        Me.txtWarehouse.TabIndex = 1
        Me.txtWarehouse.Text = ""
        '
        'UCOrderForWarehouse
        '
        Me.Controls.Add(Me.grpWarehouseDetails)
        Me.Name = "UCOrderForWarehouse"
        Me.Size = New System.Drawing.Size(568, 88)
        Me.grpWarehouseDetails.ResumeLayout(False)
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

    Private _oWarehouse As Entity.Warehouses.Warehouse
    Public Property Warehouse() As Entity.Warehouses.Warehouse
        Get
            Return _oWarehouse
        End Get
        Set(ByVal Value As Entity.Warehouses.Warehouse)
            _oWarehouse = Value
            Me.txtWarehouse.Text = Warehouse.Name & " ( " & Warehouse.Address1 & ", " & Warehouse.Postcode & ") "
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub btnFindWarehouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindWarehouse.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse)
        If Not ID = 0 Then
            Warehouse = DB.Warehouse.Warehouse_Get(ID)
        End If
    End Sub

    Private Sub UCOrderForWarehouse_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
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
