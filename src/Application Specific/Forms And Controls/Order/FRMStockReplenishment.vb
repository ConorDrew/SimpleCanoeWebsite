Public Class FRMStockReplenishment : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

    Friend WithEvents dgStockReplenishment As System.Windows.Forms.DataGrid
    Friend WithEvents btnToMinimum As System.Windows.Forms.Button
    Friend WithEvents btnToRecommended As System.Windows.Forms.Button
    Friend WithEvents chkRecommended As System.Windows.Forms.CheckBox
    Friend WithEvents chkMinimum As System.Windows.Forms.CheckBox
    Friend WithEvents lblNumberOfItems As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtItem As System.Windows.Forms.TextBox
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnRunFilter As System.Windows.Forms.Button
    Friend WithEvents chkIncludeVans As System.Windows.Forms.CheckBox
    Friend WithEvents btnClose As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgStockReplenishment = New System.Windows.Forms.DataGrid
        Me.btnToMinimum = New System.Windows.Forms.Button
        Me.btnToRecommended = New System.Windows.Forms.Button
        Me.chkRecommended = New System.Windows.Forms.CheckBox
        Me.chkMinimum = New System.Windows.Forms.CheckBox
        Me.lblNumberOfItems = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnRunFilter = New System.Windows.Forms.Button
        Me.chkIncludeVans = New System.Windows.Forms.CheckBox
        Me.txtItem = New System.Windows.Forms.TextBox
        Me.txtLocation = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnClose = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgStockReplenishment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgStockReplenishment)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 204)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(992, 488)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tick those combinations you wish to update"
        '
        'dgStockReplenishment
        '
        Me.dgStockReplenishment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgStockReplenishment.DataMember = ""
        Me.dgStockReplenishment.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgStockReplenishment.Location = New System.Drawing.Point(8, 25)
        Me.dgStockReplenishment.Name = "dgStockReplenishment"
        Me.dgStockReplenishment.Size = New System.Drawing.Size(976, 455)
        Me.dgStockReplenishment.TabIndex = 7
        '
        'btnToMinimum
        '
        Me.btnToMinimum.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnToMinimum.Location = New System.Drawing.Point(432, 700)
        Me.btnToMinimum.Name = "btnToMinimum"
        Me.btnToMinimum.Size = New System.Drawing.Size(280, 23)
        Me.btnToMinimum.TabIndex = 3
        Me.btnToMinimum.Text = "Bring amounts up to minimum quantities"
        '
        'btnToRecommended
        '
        Me.btnToRecommended.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnToRecommended.Location = New System.Drawing.Point(720, 700)
        Me.btnToRecommended.Name = "btnToRecommended"
        Me.btnToRecommended.Size = New System.Drawing.Size(280, 23)
        Me.btnToRecommended.TabIndex = 4
        Me.btnToRecommended.Text = "Bring amounts up to maximum quantities"
        '
        'chkRecommended
        '
        Me.chkRecommended.Location = New System.Drawing.Point(10, 76)
        Me.chkRecommended.Name = "chkRecommended"
        Me.chkRecommended.Size = New System.Drawing.Size(271, 24)
        Me.chkRecommended.TabIndex = 2
        Me.chkRecommended.Text = "Items where amount is below maximum"
        '
        'chkMinimum
        '
        Me.chkMinimum.Checked = True
        Me.chkMinimum.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMinimum.Location = New System.Drawing.Point(10, 103)
        Me.chkMinimum.Name = "chkMinimum"
        Me.chkMinimum.Size = New System.Drawing.Size(256, 24)
        Me.chkMinimum.TabIndex = 3
        Me.chkMinimum.Text = "Items where amount is below minimum"
        '
        'lblNumberOfItems
        '
        Me.lblNumberOfItems.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblNumberOfItems.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblNumberOfItems.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumberOfItems.Location = New System.Drawing.Point(85, 700)
        Me.lblNumberOfItems.Name = "lblNumberOfItems"
        Me.lblNumberOfItems.Size = New System.Drawing.Size(341, 24)
        Me.lblNumberOfItems.TabIndex = 7
        Me.lblNumberOfItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(32, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(425, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Amount ABOVE or EQUAL to both minimum and the maximum quantities"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Yellow
        Me.Panel1.Location = New System.Drawing.Point(8, 54)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(16, 16)
        Me.Panel1.TabIndex = 10
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Salmon
        Me.Panel2.Location = New System.Drawing.Point(8, 82)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(16, 16)
        Me.Panel2.TabIndex = 11
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightGreen
        Me.Panel3.Location = New System.Drawing.Point(8, 24)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(16, 16)
        Me.Panel3.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(425, 16)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Amount ABOVE or EQUAL to minimum but BELOW maximum quantities"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(32, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(376, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Amount BELOW both minimum and the maximum quantities"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightBlue
        Me.Panel4.Location = New System.Drawing.Point(8, 109)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(16, 16)
        Me.Panel4.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(32, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(376, 16)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "A quantity is on order to replenish stock"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnRunFilter)
        Me.GroupBox2.Controls.Add(Me.chkIncludeVans)
        Me.GroupBox2.Controls.Add(Me.txtItem)
        Me.GroupBox2.Controls.Add(Me.txtLocation)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.chkRecommended)
        Me.GroupBox2.Controls.Add(Me.chkMinimum)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 40)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(479, 158)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filters"
        '
        'btnRunFilter
        '
        Me.btnRunFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRunFilter.Location = New System.Drawing.Point(388, 128)
        Me.btnRunFilter.Name = "btnRunFilter"
        Me.btnRunFilter.Size = New System.Drawing.Size(85, 23)
        Me.btnRunFilter.TabIndex = 12
        Me.btnRunFilter.Text = "Filter"
        Me.btnRunFilter.UseVisualStyleBackColor = True
        '
        'chkIncludeVans
        '
        Me.chkIncludeVans.Location = New System.Drawing.Point(10, 128)
        Me.chkIncludeVans.Name = "chkIncludeVans"
        Me.chkIncludeVans.Size = New System.Drawing.Size(256, 24)
        Me.chkIncludeVans.TabIndex = 11
        Me.chkIncludeVans.Text = "Include Vans"
        '
        'txtItem
        '
        Me.txtItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtItem.Location = New System.Drawing.Point(80, 49)
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(393, 21)
        Me.txtItem.TabIndex = 1
        '
        'txtLocation
        '
        Me.txtLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLocation.Location = New System.Drawing.Point(80, 21)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(393, 21)
        Me.txtLocation.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 23)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Item"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 23)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Location"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Panel1)
        Me.GroupBox3.Controls.Add(Me.Panel3)
        Me.GroupBox3.Controls.Add(Me.Panel4)
        Me.GroupBox3.Controls.Add(Me.Panel2)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(493, 40)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(507, 158)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "KEY"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(8, 700)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(64, 23)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        '
        'FRMStockReplenishment
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblNumberOfItems)
        Me.Controls.Add(Me.btnToRecommended)
        Me.Controls.Add(Me.btnToMinimum)
        Me.Controls.Add(Me.GroupBox1)
        Me.MinimumSize = New System.Drawing.Size(832, 544)
        Me.Name = "FRMStockReplenishment"
        Me.Text = "Stock Replenishment"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnToMinimum, 0)
        Me.Controls.SetChildIndex(Me.btnToRecommended, 0)
        Me.Controls.SetChildIndex(Me.lblNumberOfItems, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgStockReplenishment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        If GetParameter(0) Then
            Me.WindowState = FormWindowState.Maximized
        End If

        SetupStockDatagrid()

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

    Private lastSelectedType As String = ""
    Private lastSelectedID As Integer = 0
    Private warehouses As New ArrayList
    Private vans As New ArrayList

    Private _StockDataView As DataView = Nothing

    Public Property StockDataView() As DataView
        Get
            Return _StockDataView
        End Get
        Set(ByVal Value As DataView)
            _StockDataView = Value
            _StockDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString
            _StockDataView.AllowNew = False
            _StockDataView.AllowEdit = False
            _StockDataView.AllowDelete = False
            Me.dgStockReplenishment.DataSource = StockDataView
        End Set
    End Property

    Private ReadOnly Property SelectedStockDataRow() As DataRow
        Get
            If Not Me.dgStockReplenishment.CurrentRowIndex = -1 Then
                Return StockDataView(Me.dgStockReplenishment.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Public Sub SetupStockDatagrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgStockReplenishment)
        Dim tStyle As DataGridTableStyle = Me.dgStockReplenishment.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Me.dgStockReplenishment.ReadOnly = False
        tStyle.AllowSorting = True
        tStyle.ReadOnly = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tStyle.GridColumnStyles.Add(Tick)

        Dim Location As New DataGridLabelColumn
        Location.Format = ""
        Location.FormatInfo = Nothing
        Location.HeaderText = "Location"
        Location.MappingName = "Location"
        Location.ReadOnly = True
        Location.Width = 150
        Location.NullText = ""
        tStyle.GridColumnStyles.Add(Location)

        Dim Item As New DataGridLabelColumn
        Item.Format = ""
        Item.FormatInfo = Nothing
        Item.HeaderText = "Item"
        Item.MappingName = "Item"
        Item.ReadOnly = True
        Item.Width = 150
        Item.NullText = ""
        tStyle.GridColumnStyles.Add(Item)

        Dim MinimumQuantity As New DataGridLabelColumn
        MinimumQuantity.Format = ""
        MinimumQuantity.FormatInfo = Nothing
        MinimumQuantity.HeaderText = "Minimum Quantity"
        MinimumQuantity.MappingName = "MinimumQuantity"
        MinimumQuantity.ReadOnly = True
        MinimumQuantity.Width = 150
        MinimumQuantity.NullText = ""
        tStyle.GridColumnStyles.Add(MinimumQuantity)

        Dim RecommendedQuantity As New DataGridLabelColumn
        RecommendedQuantity.Format = ""
        RecommendedQuantity.FormatInfo = Nothing
        RecommendedQuantity.HeaderText = "Maximum Quantity"
        RecommendedQuantity.MappingName = "RecommendedQuantity"
        RecommendedQuantity.ReadOnly = True
        RecommendedQuantity.Width = 150
        RecommendedQuantity.NullText = ""
        tStyle.GridColumnStyles.Add(RecommendedQuantity)

        Dim Amount As New StockReplenishmentColourColumn
        Amount.Format = ""
        Amount.FormatInfo = Nothing
        Amount.HeaderText = "Amount"
        Amount.MappingName = "Amount"
        Amount.ReadOnly = True
        Amount.Width = 75
        Amount.NullText = ""
        tStyle.GridColumnStyles.Add(Amount)

        Dim PacksOnOrder As New DataGridLabelColumn
        PacksOnOrder.Format = ""
        PacksOnOrder.FormatInfo = Nothing
        PacksOnOrder.HeaderText = "Packs On Order"
        PacksOnOrder.MappingName = "PacksOnOrder"
        PacksOnOrder.ReadOnly = True
        PacksOnOrder.Width = 120
        PacksOnOrder.NullText = ""
        tStyle.GridColumnStyles.Add(PacksOnOrder)

        Dim UnitsOnOrder As New DataGridLabelColumn
        UnitsOnOrder.Format = ""
        UnitsOnOrder.FormatInfo = Nothing
        UnitsOnOrder.HeaderText = "Units On Order"
        UnitsOnOrder.MappingName = "UnitsOnOrder"
        UnitsOnOrder.ReadOnly = True
        UnitsOnOrder.Width = 120
        UnitsOnOrder.NullText = ""
        tStyle.GridColumnStyles.Add(UnitsOnOrder)

        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblStock.ToString
        Me.dgStockReplenishment.TableStyles.Add(tStyle)

        Entity.Sys.Helper.RemoveEventHandlers(Me.dgStockReplenishment)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMStockReplenishment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub dgStockReplenishment_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgStockReplenishment.MouseUp
        Try
            If SelectedStockDataRow Is Nothing Then
                Exit Sub
            End If
            Dim HitTestInfo As DataGrid.HitTestInfo
            HitTestInfo = dgStockReplenishment.HitTest(e.X, e.Y)
            If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
                If HitTestInfo.Column = 0 Then
                    Dim selected As Boolean = Not CBool(Me.dgStockReplenishment(Me.dgStockReplenishment.CurrentRowIndex, 0))
                    Me.dgStockReplenishment(Me.dgStockReplenishment.CurrentRowIndex, 0) = selected
                End If
            End If
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub btnToMinimum_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnToMinimum.Click
        Try
            lastSelectedType = ""
            lastSelectedID = 0

            If ShowMessage("This will create orders. Some stock can be replenished from warehouses, others may require a supplier selection. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            warehouses.Clear()
            vans.Clear()

            For Each row As DataRow In StockDataView.Table.Rows
                If row.Item("Tick") Then
                    If row.Item("WarehouseID") = 0 Then
                        AddPlaceToGetFrom(row, "MinimumQuantity", CheckAndAddVan(row.Item("VanID"), row.Item("Location")), True)
                    Else
                        AddPlaceToGetFrom(row, "MinimumQuantity", CheckAndAddWarehouse(row.Item("WarehouseID"), row.Item("Location")), False)
                    End If
                End If
            Next

            CreateOrders()
        Catch ex As Exception
            ShowMessage("Error generating orders : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    Private Sub btnToRecommended_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnToRecommended.Click
        Try
            lastSelectedType = ""
            lastSelectedID = 0

            If ShowMessage("This will create orders. Some stock can be replenished from warehouses, others may require a supplier selection. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            warehouses.Clear()
            vans.Clear()

            For Each row As DataRow In StockDataView.Table.Rows
                If row.Item("Tick") Then
                    If row.Item("WarehouseID") = 0 Then
                        AddPlaceToGetFrom(row, "RecommendedQuantity", CheckAndAddVan(row.Item("VanID"), row.Item("Location")), True)
                    Else
                        AddPlaceToGetFrom(row, "RecommendedQuantity", CheckAndAddWarehouse(row.Item("WarehouseID"), row.Item("Location")), False)
                    End If
                End If
            Next

            CreateOrders()
        Catch ex As Exception
            ShowMessage("Error generating orders : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

#End Region

#Region "Functions"

    Private Sub btnRunFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunFilter.Click
        Filter()
    End Sub

    Private Sub Filter()
        StockDataView = DB.Location.StockTake_Replenishment_Filtered(txtLocation.Text, txtItem.Text, chkIncludeVans.Checked, chkMinimum.Checked, chkRecommended.Checked)

        Me.lblNumberOfItems.Text = StockDataView.Count & " Items"
    End Sub

    Private Function CheckAndAddWarehouse(ByVal WarehouseID As Integer, ByVal Warehouse As String) As Integer
        Dim found As Boolean = False
        Dim index As Integer = 0
        For Each item As ArrayList In warehouses
            If item.Item(0) = WarehouseID Then
                found = True
                Exit For
            End If
            index += 1
        Next

        If Not found Then
            Dim newWarehouse As New ArrayList
            newWarehouse.Add(WarehouseID)

            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("PartID"))
            dt.Columns.Add(New DataColumn("PartSupplierID"))
            dt.Columns.Add(New DataColumn("LocationID"))
            dt.Columns.Add(New DataColumn("Quantity"))
            dt.Columns.Add(New DataColumn("BuyPrice"))
            dt.Columns.Add(New DataColumn("SupplierID"))
            dt.Columns.Add(New DataColumn("Deleted"))
            newWarehouse.Add(dt)

            newWarehouse.Add(Warehouse)

            warehouses.Add(newWarehouse)
        End If

        Return index
    End Function

    Private Function CheckAndAddVan(ByVal VanID As Integer, ByVal Van As String) As Integer
        Dim found As Boolean = False
        Dim index As Integer = 0
        For Each item As ArrayList In vans
            If item.Item(0) = VanID Then
                found = True
                Exit For
            End If
            index += 1
        Next

        If Not found Then
            Dim newVan As New ArrayList
            newVan.Add(VanID)

            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("PartID"))
            dt.Columns.Add(New DataColumn("PartSupplierID"))
            dt.Columns.Add(New DataColumn("LocationID"))
            dt.Columns.Add(New DataColumn("Quantity"))
            dt.Columns.Add(New DataColumn("BuyPrice"))
            dt.Columns.Add(New DataColumn("SupplierID"))
            dt.Columns.Add(New DataColumn("Deleted"))
            newVan.Add(dt)

            newVan.Add(Van)

            vans.Add(newVan)
        End If

        Return index
    End Function

    Private Sub AddPlaceToGetFrom(ByVal row As DataRow, ByVal MinimumOrRecommended As String, ByVal Index As Integer, ByVal ForVan As Boolean)
        Dim quantityFromLocation As Integer = 0
        If MinimumOrRecommended = "MinimumQuantity" Then
            quantityFromLocation = ((row.Item("MinimumQuantity") - row.Item("Amount")) - row.Item("PacksOnOrder"))
        ElseIf MinimumOrRecommended = "RecommendedQuantity" Then
            quantityFromLocation = ((row.Item("RecommendedQuantity") - row.Item("Amount")) - row.Item("PacksOnOrder"))
        End If

        If quantityFromLocation <= 0 Then
            Exit Sub
        End If

        Dim LocationID As Integer = 0
        Dim PartSupplierID As Integer = 0
        Dim QuantityInPack As Integer = 0
        Dim SupplierID As Integer = 0
        Dim Price As Double = 0.0

        Dim oFRMSelectLocation As FRMSelectLocation = ShowForm(GetType(FRMSelectLocation), True, New Object() {row.Item("PartID"), row.Item("Item"), row.Item("Location"), quantityFromLocation, warehouses, vans, lastSelectedType, lastSelectedID, ""})
        If oFRMSelectLocation Is Nothing Then
            Exit Sub
        Else
            If oFRMSelectLocation.DialogResult = DialogResult.OK Then
                LocationID = oFRMSelectLocation.LocationID
                PartSupplierID = oFRMSelectLocation.PartSupplierID
                QuantityInPack = oFRMSelectLocation.InPack
                SupplierID = oFRMSelectLocation.SupplierID
                Price = oFRMSelectLocation.Price
            End If
            oFRMSelectLocation.Dispose()
        End If

        If LocationID = 0 And PartSupplierID = 0 Then
            ShowMessage("No location selected for the item : " & row.Item("Item") & " at " & row.Item("Location"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If LocationID = 0 Then
            Dim quantityNeeded As Integer = 0
            If MinimumOrRecommended = "MinimumQuantity" Then
                quantityNeeded = Math.Ceiling(((row.Item("MinimumQuantity") - row.Item("Amount")) - row.Item("PacksOnOrder")) / QuantityInPack)
            ElseIf MinimumOrRecommended = "RecommendedQuantity" Then
                quantityNeeded = Math.Ceiling(((row.Item("RecommendedQuantity") - row.Item("Amount")) - row.Item("PacksOnOrder")) / QuantityInPack)
            End If

            If quantityNeeded <= 0 Then
                ShowMessage("No order needed for the item : " & row.Item("Item") & " at " & row.Item("Location"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Dim newRow As DataRow

                If ForVan Then
                    newRow = CType(CType(vans.Item(Index), ArrayList).Item(1), DataTable).NewRow()
                Else
                    newRow = CType(CType(warehouses.Item(Index), ArrayList).Item(1), DataTable).NewRow()
                End If

                newRow("PartID") = row.Item("PartID")
                newRow("PartSupplierID") = PartSupplierID
                newRow("LocationID") = 0
                newRow("Quantity") = quantityNeeded
                newRow("BuyPrice") = Price
                newRow("SupplierID") = SupplierID

                If ForVan Then
                    CType(CType(vans.Item(Index), ArrayList).Item(1), DataTable).Rows.Add(newRow)
                Else
                    CType(CType(warehouses.Item(Index), ArrayList).Item(1), DataTable).Rows.Add(newRow)
                End If

                lastSelectedType = "Supplier"
                lastSelectedID = PartSupplierID
            End If
        Else
            Dim newRow As DataRow

            If ForVan Then
                newRow = CType(CType(vans.Item(Index), ArrayList).Item(1), DataTable).NewRow()
            Else
                newRow = CType(CType(warehouses.Item(Index), ArrayList).Item(1), DataTable).NewRow()
            End If

            newRow("PartID") = row.Item("PartID")
            newRow("PartSupplierID") = 0
            newRow("LocationID") = LocationID
            newRow("Quantity") = quantityFromLocation
            newRow("BuyPrice") = 0.0
            newRow("SupplierID") = 0

            If ForVan Then
                CType(CType(vans.Item(Index), ArrayList).Item(1), DataTable).Rows.Add(newRow)
            Else
                CType(CType(warehouses.Item(Index), ArrayList).Item(1), DataTable).Rows.Add(newRow)
            End If

            lastSelectedType = "Warehouse"
            lastSelectedID = LocationID
        End If
    End Sub

    'THIS WAS THE ORIGINAL METHOD UNTIL TONY B SPOKE TO ROB AND MADE THE ALTERATIONS AS PER ABOVE METHOD
    'Private Sub AddPlaceToGetFrom(ByVal row As DataRow, ByVal MinimumOrRecommended As String, ByVal Index As Integer, ByVal ForVan As Boolean)
    '    Dim quantityFromLocation As Integer = 0
    '    If MinimumOrRecommended = "MinimumQuantity" Then
    '        quantityFromLocation = ((row.Item("MinimumQuantity") - row.Item("Amount")) - row.Item("OnOrder"))
    '    ElseIf MinimumOrRecommended = "RecommendedQuantity" Then
    '        quantityFromLocation = ((row.Item("RecommendedQuantity") - row.Item("Amount")) - row.Item("OnOrder"))
    '    End If

    '    If quantityFromLocation = 0 Then
    '        Exit Sub
    '    End If

    '    Dim locationID As Integer = 0

    '    For Each orderRow As DataRow In DB.Part.Stock_Get_Locations(row.Item("PartID"), row.Item("WarehouseID")).Table.Rows
    '        If orderRow.Item("Type") = "WAREHOUSE" Then
    '            If orderRow.Item("Quantity") >= quantityFromLocation Then
    '                If ShowMessage("There is enough stock for the item '" & row.Item("Item") & "' in the '" & orderRow.Item("Location") & "' warehouse" & vbCrLf & "Replenish using this stock?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) =DialogResult.Yes Then
    '                    locationID = orderRow.Item("LocationID")
    '                    Exit For
    '                End If
    '            Else
    '                If ShowMessage("There is not enough stock for the item '" & row.Item("Item") & "' in the '" & orderRow.Item("Location") & "' warehouse" & vbCrLf & "Replenish using this location and await stock arrival?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) =DialogResult.Yes Then
    '                    locationID = orderRow.Item("LocationID")
    '                    Exit For
    '                End If
    '            End If
    '        End If
    '    Next

    '    If locationID = 0 Then
    '        Dim PartSupplierID As Integer = 0
    '        Dim PartSuppliers As DataTable = DB.PartSupplier.Get_ByPartID(row.Item("PartID")).Table
    '        If PartSuppliers.Rows.Count = 0 Then
    '            PartSupplierID = 0
    '            ShowMessage("There are no suppliers for the item : " & row.Item("Item") & " at " & row.Item("Location"), MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        ElseIf PartSuppliers.Rows.Count = 1 Then
    '            PartSupplierID = PartSuppliers.Rows(0).Item("PartSupplierID")
    '        Else
    '            PartSupplierID = PickPartProductSupplier(Entity.Sys.Enums.TableNames.tblPartSupplier, row.Item("PartID"))
    '            If PartSupplierID = 0 Then
    '                ShowMessage("No supplier selected for the item : " & row.Item("Item") & " at " & row.Item("Location"), MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            End If
    '        End If

    '        If Not PartSupplierID = 0 Then
    '            Dim oPartSupplier As Entity.PartSuppliers.PartSupplier = DB.PartSupplier.PartSupplier_Get(PartSupplierID)

    '            Dim quantityNeeded As Integer = 0
    '            If MinimumOrRecommended = "MinimumQuantity" Then
    '                quantityNeeded = Math.Ceiling((row.Item("MinimumQuantity") - row.Item("Amount")) / oPartSupplier.QuantityInPack)
    '            ElseIf MinimumOrRecommended = "RecommendedQuantity" Then
    '                quantityNeeded = Math.Ceiling((row.Item("RecommendedQuantity") - row.Item("Amount")) / oPartSupplier.QuantityInPack)
    '            End If

    '            If quantityNeeded <= 0 Then
    '                ShowMessage("No order needed for the item : " & row.Item("Item") & " at " & row.Item("Location"), MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Else
    '                Dim newRow As DataRow

    '                If ForVan Then
    '                    newRow = CType(CType(vans.Item(Index), ArrayList).Item(1), DataTable).NewRow()
    '                Else
    '                    newRow = CType(CType(warehouses.Item(Index), ArrayList).Item(1), DataTable).NewRow()
    '                End If

    '                newRow("PartID") = row.Item("PartID")
    '                newRow("PartSupplierID") = oPartSupplier.PartSupplierID
    '                newRow("LocationID") = 0
    '                newRow("Quantity") = quantityNeeded
    '                newRow("BuyPrice") = oPartSupplier.Price
    '                newRow("SupplierID") = oPartSupplier.SupplierID

    '                If ForVan Then
    '                    CType(CType(vans.Item(Index), ArrayList).Item(1), DataTable).Rows.Add(newRow)
    '                Else
    '                    CType(CType(warehouses.Item(Index), ArrayList).Item(1), DataTable).Rows.Add(newRow)
    '                End If
    '            End If
    '        End If
    '    Else
    '        Dim newRow As DataRow

    '        If ForVan Then
    '            newRow = CType(CType(vans.Item(Index), ArrayList).Item(1), DataTable).NewRow()
    '        Else
    '            newRow = CType(CType(warehouses.Item(Index), ArrayList).Item(1), DataTable).NewRow()
    '        End If

    '        newRow("PartID") = row.Item("PartID")
    '        newRow("PartSupplierID") = 0
    '        newRow("LocationID") = locationID
    '        newRow("Quantity") = quantityFromLocation
    '        newRow("BuyPrice") = 0.0
    '        newRow("SupplierID") = 0

    '        If ForVan Then
    '            CType(CType(vans.Item(Index), ArrayList).Item(1), DataTable).Rows.Add(newRow)
    '        Else
    '            CType(CType(warehouses.Item(Index), ArrayList).Item(1), DataTable).Rows.Add(newRow)
    '        End If
    '    End If
    'End Sub

    Private Function GetOrderReference(ByVal oOrderType As Entity.Sys.Enums.OrderType) As String

        Dim OrderNumber As New JobNumber
        OrderNumber = DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.ORDER)
        OrderNumber.OrderNumber = OrderNumber.JobNumber

        While OrderNumber.OrderNumber.Length < 5
            OrderNumber.OrderNumber = "0" & OrderNumber.OrderNumber
        End While

        Dim typePrefix As String = ""

        Select Case oOrderType
            Case Entity.Sys.Enums.OrderType.Customer
                typePrefix = "W"
            Case Entity.Sys.Enums.OrderType.StockProfile
                typePrefix = "V"
            Case Entity.Sys.Enums.OrderType.Warehouse
                typePrefix = "W"
        End Select

        Dim userPrefix As String = ""
        Dim username() As String = loggedInUser.Fullname.Split(" ")
        For Each s As String In username
            userPrefix += s.Substring(0, 1)
        Next

        Return userPrefix & typePrefix & OrderNumber.OrderNumber
    End Function

    Private Sub CreateOrders()

        Dim orderCreated As Integer = 0

        If warehouses.Count = 0 And vans.Count = 0 Then
            ShowMessage("No orders were needed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            For i As Integer = warehouses.Count - 1 To 0 Step -1
                If CType(CType(warehouses.Item(i), ArrayList).Item(1), DataTable).Rows.Count = 0 Then
                    warehouses.RemoveAt(i)
                Else
                    'COUNT SUPPLIER
                    Dim suppliers As New ArrayList
                    For Each drItm As DataRow In CType(CType(warehouses.Item(i), ArrayList).Item(1), DataTable).Rows
                        If Not CInt(drItm("SupplierID")) = 0 Then
                            If suppliers.Contains(CInt(drItm.Item("SupplierID"))) = False Then
                                suppliers.Add(CInt(drItm("SupplierID")))
                            End If
                        End If
                    Next

                    'FOR EACH SUPPLIER
                    For j As Integer = 0 To suppliers.Count - 1
                        Dim oOrder As New Entity.Orders.Order
                        oOrder.IgnoreExceptionsOnSetMethods = True
                        oOrder.DatePlaced = Now()
                        oOrder.SetOrderTypeID = CInt(Entity.Sys.Enums.OrderType.Warehouse)
                        oOrder.SetOrderReference = GetOrderReference(Entity.Sys.Enums.OrderType.Warehouse) ' "REP : " & CType(warehouses.Item(i), ArrayList).Item(2) & ":" & suppliers(j)
                        oOrder.SetUserID = loggedInUser.UserID
                        oOrder.SetOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation)
                        oOrder.DeliveryDeadline = Nothing
                        oOrder.SetDoNotConsolidated = True

                        oOrder = DB.Order.Insert(oOrder)
                        orderCreated += 1
                        Dim oOrderLocation As New Entity.OrderLocations.OrderLocation
                        oOrderLocation.SetOrderID = oOrder.OrderID
                        oOrderLocation.SetLocationID = DB.Warehouse.Warehouse_GetDV(CType(warehouses.Item(i), ArrayList).Item(0)).Table.Rows(0).Item("LocationID")
                        oOrderLocation = DB.OrderLocation.Insert(oOrderLocation)

                        Dim drSelect() As DataRow = CType(CType(warehouses.Item(i), ArrayList).Item(1), DataTable).Select("SupplierID='" & CInt(suppliers(j)) & "'")
                        For k As Integer = 0 To drSelect.Length - 1
                            Dim row As DataRow = drSelect(k)
                            If row.Item("LocationID") = 0 Then
                                Dim oOrderPart As New Entity.OrderParts.OrderPart
                                oOrderPart.IgnoreExceptionsOnSetMethods = True
                                oOrderPart.SetOrderID = oOrder.OrderID
                                oOrderPart.SetPartSupplierID = row.Item("PartSupplierID")
                                oOrderPart.SetQuantity = row.Item("Quantity")
                                oOrderPart.SetBuyPrice = row.Item("BuyPrice")
                                oOrderPart.SetSellPrice = 0.0
                                oOrderPart.SetQuantityReceived = 0
                                DB.OrderPart.Insert(oOrderPart, Not (oOrder.DoNotConsolidated))
                            End If
                        Next k
                    Next j

                    'COUNT LOCATIONS
                    Dim locations As New ArrayList
                    For Each drItm As DataRow In CType(CType(warehouses.Item(i), ArrayList).Item(1), DataTable).Rows
                        If Not CInt(drItm("LocationID")) = 0 Then
                            If locations.Contains(CInt(drItm.Item("LocationID"))) = False Then
                                locations.Add(CInt(drItm("LocationID")))
                            End If
                        End If
                    Next

                    'FOR EACH LOCATION
                    For j As Integer = 0 To locations.Count - 1
                        Dim oOrder As New Entity.Orders.Order
                        oOrder.IgnoreExceptionsOnSetMethods = True
                        oOrder.DatePlaced = Now()
                        oOrder.SetOrderTypeID = CInt(Entity.Sys.Enums.OrderType.Warehouse)
                        oOrder.SetOrderReference = GetOrderReference(Entity.Sys.Enums.OrderType.Warehouse) '  "REP : " & CType(warehouses.Item(i), ArrayList).Item(2) & ":" & locations(j)
                        oOrder.SetUserID = loggedInUser.UserID
                        oOrder.SetOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation)
                        oOrder.DeliveryDeadline = Nothing

                        oOrder = DB.Order.Insert(oOrder)
                        orderCreated += 1
                        Dim oOrderLocation As New Entity.OrderLocations.OrderLocation
                        oOrderLocation.SetOrderID = oOrder.OrderID
                        oOrderLocation.SetLocationID = DB.Warehouse.Warehouse_GetDV(CType(warehouses.Item(i), ArrayList).Item(0)).Table.Rows(0).Item("LocationID")
                        oOrderLocation = DB.OrderLocation.Insert(oOrderLocation)

                        Dim drSelect() As DataRow = CType(CType(warehouses.Item(i), ArrayList).Item(1), DataTable).Select("LocationID='" & CInt(locations(j)) & "'")
                        For k As Integer = 0 To drSelect.Length - 1
                            Dim row As DataRow = drSelect(k)
                            If Not row.Item("LocationID") = 0 Then
                                Dim oOrderLocationPart As New Entity.OrderLocationPart.OrderLocationPart
                                oOrderLocationPart.IgnoreExceptionsOnSetMethods = True
                                oOrderLocationPart.SetOrderID = oOrder.OrderID
                                oOrderLocationPart.SetPartID = row.Item("PartID")
                                oOrderLocationPart.SetLocationID = row.Item("LocationID")
                                oOrderLocationPart.SetQuantity = row.Item("Quantity")
                                oOrderLocationPart.SetSellPrice = 0.0
                                oOrderLocationPart.SetQuantityReceived = 0

                                oOrderLocationPart = DB.OrderLocationPart.Insert(oOrderLocationPart, True)

                                Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                                oPartTransaction.IgnoreExceptionsOnSetMethods = True
                                oPartTransaction.SetOrderLocationPartID = oOrderLocationPart.OrderLocationPartID
                                oPartTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockReserve)
                                oPartTransaction.SetPartID = oOrderLocationPart.PartID
                                oPartTransaction.SetAmount = -oOrderLocationPart.Quantity
                                oPartTransaction.SetLocationID = oOrderLocationPart.LocationID

                                oPartTransaction = DB.PartTransaction.Insert(oPartTransaction)
                            End If
                        Next k
                    Next j
                End If
            Next

            For i As Integer = vans.Count - 1 To 0 Step -1
                If CType(CType(vans.Item(i), ArrayList).Item(1), DataTable).Rows.Count = 0 Then
                    vans.RemoveAt(i)
                Else
                    'COUNT SUPPLIER
                    Dim suppliers As New ArrayList
                    For Each drItm As DataRow In CType(CType(vans.Item(i), ArrayList).Item(1), DataTable).Rows
                        If Not CInt(drItm("SupplierID")) = 0 Then
                            If suppliers.Contains(CInt(drItm.Item("SupplierID"))) = False Then
                                suppliers.Add(CInt(drItm("SupplierID")))
                            End If
                        End If
                    Next

                    'FOR EACH SUPPLIER
                    For j As Integer = 0 To suppliers.Count - 1
                        Dim oOrder As New Entity.Orders.Order
                        oOrder.IgnoreExceptionsOnSetMethods = True
                        oOrder.DatePlaced = Now()
                        oOrder.SetOrderTypeID = CInt(Entity.Sys.Enums.OrderType.StockProfile)
                        oOrder.SetOrderReference = GetOrderReference(Entity.Sys.Enums.OrderType.StockProfile) '  "REP : " & CType(vans.Item(i), ArrayList).Item(2) & ":" & suppliers(j)
                        oOrder.SetUserID = loggedInUser.UserID
                        oOrder.SetOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation)
                        oOrder.DeliveryDeadline = Nothing

                        oOrder = DB.Order.Insert(oOrder)
                        orderCreated += 1

                        Dim oOrderLocation As New Entity.OrderLocations.OrderLocation
                        oOrderLocation.SetOrderID = oOrder.OrderID
                        oOrderLocation.SetLocationID = DB.Van.Van_GetDV(CType(vans.Item(i), ArrayList).Item(0)).Table.Rows(0).Item("LocationID")
                        oOrderLocation = DB.OrderLocation.Insert(oOrderLocation)

                        Dim drSelect() As DataRow = CType(CType(vans.Item(i), ArrayList).Item(1), DataTable).Select("SupplierID='" & CInt(suppliers(j)) & "'")
                        For k As Integer = 0 To drSelect.Length - 1
                            Dim row As DataRow = drSelect(k)
                            If row.Item("LocationID") = 0 Then
                                Dim oOrderPart As New Entity.OrderParts.OrderPart
                                oOrderPart.IgnoreExceptionsOnSetMethods = True
                                oOrderPart.SetOrderID = oOrder.OrderID
                                oOrderPart.SetPartSupplierID = row.Item("PartSupplierID")
                                oOrderPart.SetQuantity = row.Item("Quantity")
                                oOrderPart.SetBuyPrice = row.Item("BuyPrice")
                                oOrderPart.SetSellPrice = 0.0
                                oOrderPart.SetQuantityReceived = 0

                                DB.OrderPart.Insert(oOrderPart, Not (oOrder.DoNotConsolidated))
                            End If
                        Next k
                    Next j

                    'COUNT LOCATIONS
                    Dim locations As New ArrayList
                    For Each drItm As DataRow In CType(CType(vans.Item(i), ArrayList).Item(1), DataTable).Rows
                        If Not CInt(drItm("LocationID")) = 0 Then
                            If locations.Contains(CInt(drItm.Item("LocationID"))) = False Then
                                locations.Add(CInt(drItm("LocationID")))
                            End If
                        End If
                    Next

                    'FOR EACH LOCATION
                    For j As Integer = 0 To locations.Count - 1
                        Dim oOrder As New Entity.Orders.Order
                        oOrder.IgnoreExceptionsOnSetMethods = True
                        oOrder.DatePlaced = Now()
                        oOrder.SetOrderTypeID = CInt(Entity.Sys.Enums.OrderType.StockProfile)
                        oOrder.SetOrderReference = GetOrderReference(Entity.Sys.Enums.OrderType.StockProfile) '  "REP : " & CType(vans.Item(i), ArrayList).Item(2) & ":" & locations(j)
                        oOrder.SetUserID = loggedInUser.UserID
                        oOrder.SetOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation)
                        oOrder.DeliveryDeadline = Nothing

                        oOrder = DB.Order.Insert(oOrder)
                        orderCreated += 1

                        Dim oOrderLocation As New Entity.OrderLocations.OrderLocation
                        oOrderLocation.SetOrderID = oOrder.OrderID
                        oOrderLocation.SetLocationID = DB.Van.Van_GetDV(CType(vans.Item(i), ArrayList).Item(0)).Table.Rows(0).Item("LocationID")
                        oOrderLocation = DB.OrderLocation.Insert(oOrderLocation)

                        Dim drSelect() As DataRow = CType(CType(vans.Item(i), ArrayList).Item(1), DataTable).Select("LocationID='" & CInt(locations(j)) & "'")
                        For k As Integer = 0 To drSelect.Length - 1
                            Dim row As DataRow = drSelect(k)
                            If Not row.Item("LocationID") = 0 Then
                                Dim oOrderLocationPart As New Entity.OrderLocationPart.OrderLocationPart
                                oOrderLocationPart.IgnoreExceptionsOnSetMethods = True
                                oOrderLocationPart.SetOrderID = oOrder.OrderID
                                oOrderLocationPart.SetPartID = row.Item("PartID")
                                oOrderLocationPart.SetLocationID = row.Item("LocationID")
                                oOrderLocationPart.SetQuantity = row.Item("Quantity")
                                oOrderLocationPart.SetSellPrice = 0.0
                                oOrderLocationPart.SetQuantityReceived = 0

                                oOrderLocationPart = DB.OrderLocationPart.Insert(oOrderLocationPart, True)

                                Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                                oPartTransaction.IgnoreExceptionsOnSetMethods = True
                                oPartTransaction.SetOrderLocationPartID = oOrderLocationPart.OrderLocationPartID
                                oPartTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockReserve)
                                oPartTransaction.SetPartID = oOrderLocationPart.PartID
                                oPartTransaction.SetAmount = -oOrderLocationPart.Quantity
                                oPartTransaction.SetLocationID = oOrderLocationPart.LocationID

                                oPartTransaction = DB.PartTransaction.Insert(oPartTransaction)
                            End If
                        Next k
                    Next j
                End If
            Next

            ShowMessage(orderCreated & " orders created", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If orderCreated > 0 Then
                Filter()
            End If
        End If
    End Sub

#End Region

End Class