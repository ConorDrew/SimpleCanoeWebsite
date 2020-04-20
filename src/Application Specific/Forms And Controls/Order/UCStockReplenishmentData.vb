Public Class UCStockReplenishmentData : Inherits UCBase

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
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvData
        '
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Location = New System.Drawing.Point(0, 0)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.Size = New System.Drawing.Size(512, 344)
        Me.dgvData.TabIndex = 3
        '
        'UCData
        '
        Me.Controls.Add(Me.dgvData)
        Me.Name = "UCData"
        Me.Size = New System.Drawing.Size(512, 344)
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Public ReadOnly Property LoadedItem() As Object
        Get
            Return Data
        End Get
    End Property

#End Region

#Region "Properties"

    Private _Data As DataView
    Public Property Data() As DataView
        Get
            Return _Data
        End Get
        Set(ByVal value As DataView)
            _Data = value
            _Data.AllowNew = False
            _Data.AllowEdit = True
            _Data.AllowDelete = False
            dgvData.AutoGenerateColumns = False
            Me.dgvData.DataSource = Data
        End Set
    End Property

#End Region

#Region "Setup"

    Private m_SelectedStyle As New DataGridViewCellStyle
    Private m_SelectedRow As Integer = -1

    Public Sub SetupDG()
        dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvData.Font = New Font("Arial", 7)

        Dim Exclude As New DataGridViewCheckBoxColumn
        Exclude.FillWeight = 5
        Exclude.HeaderText = "Exclude"
        Exclude.DataPropertyName = "Exclude"
        Exclude.ReadOnly = False
        Exclude.SortMode = DataGridViewColumnSortMode.Programmatic
        Exclude.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvData.Columns.Add(Exclude)

        Dim ID As New DataGridViewTextBoxColumn
        ID.HeaderText = "ID"
        ID.DataPropertyName = "ID"
        ID.ReadOnly = False
        ID.Visible = False
        ID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(ID)

        Dim LocationID As New DataGridViewTextBoxColumn
        LocationID.HeaderText = "Location"
        LocationID.DataPropertyName = "Location"
        LocationID.ReadOnly = True
        LocationID.Visible = True
        LocationID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(LocationID)

        Dim WarehouseID As New DataGridViewTextBoxColumn
        WarehouseID.HeaderText = "WarehouseID"
        WarehouseID.DataPropertyName = "WarehouseID"
        WarehouseID.ReadOnly = True
        WarehouseID.Visible = False
        WarehouseID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(WarehouseID)

        Dim VanID As New DataGridViewTextBoxColumn
        VanID.HeaderText = "VanID"
        VanID.DataPropertyName = "VanID"
        VanID.ReadOnly = True
        VanID.Visible = False
        VanID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(VanID)

        Dim PartName As New DataGridViewTextBoxColumn
        PartName.HeaderText = "Part Name"
        PartName.DataPropertyName = "Item"
        PartName.ReadOnly = True
        PartName.Visible = True
        PartName.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(PartName)

        Dim PartID As New DataGridViewTextBoxColumn
        PartID.HeaderText = "Part ID"
        PartID.DataPropertyName = "PartID"
        PartID.ReadOnly = True
        PartID.Visible = False
        PartID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(PartID)

        Dim PartSupplierID As New DataGridViewTextBoxColumn
        PartSupplierID.HeaderText = "PartSupplierID"
        PartSupplierID.DataPropertyName = "PartSupplierID"
        PartSupplierID.ReadOnly = True
        PartSupplierID.Visible = False
        PartSupplierID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(PartSupplierID)

        Dim PartSupplierName As New DataGridViewTextBoxColumn
        PartSupplierName.HeaderText = "Supplier"
        PartSupplierName.DataPropertyName = "PartSupplierName"
        PartSupplierName.ReadOnly = True
        PartSupplierName.Visible = True
        PartSupplierName.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(PartSupplierName)

        Dim MinimumQuantity As New DataGridViewTextBoxColumn
        MinimumQuantity.FillWeight = 5
        MinimumQuantity.HeaderText = "Minimum Quantity"
        MinimumQuantity.DataPropertyName = "MinimumQuantity"
        MinimumQuantity.ReadOnly = True
        MinimumQuantity.Visible = True
        MinimumQuantity.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(MinimumQuantity)

        Dim RecommendedQuantity As New DataGridViewTextBoxColumn
        RecommendedQuantity.FillWeight = 5
        RecommendedQuantity.HeaderText = "Recommended Quantity"
        RecommendedQuantity.DataPropertyName = "RecommendedQuantity"
        RecommendedQuantity.ReadOnly = True
        RecommendedQuantity.Visible = True
        RecommendedQuantity.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(RecommendedQuantity)

        Dim CurrentAmount As New DataGridViewTextBoxColumn
        CurrentAmount.FillWeight = 5
        CurrentAmount.HeaderText = "Current Amount"
        CurrentAmount.DataPropertyName = "Amount"
        CurrentAmount.ReadOnly = True
        CurrentAmount.Visible = True
        CurrentAmount.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(CurrentAmount)

        Dim PacksOnOrder As New DataGridViewTextBoxColumn
        PacksOnOrder.FillWeight = 5
        PacksOnOrder.HeaderText = "Packs On Order"
        PacksOnOrder.DataPropertyName = "PacksOnOrder"
        PacksOnOrder.ReadOnly = True
        PacksOnOrder.Visible = True
        PacksOnOrder.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(PacksOnOrder)

        Dim UnitsOnOrder As New DataGridViewTextBoxColumn
        UnitsOnOrder.FillWeight = 5
        UnitsOnOrder.HeaderText = "Units On Order"
        UnitsOnOrder.DataPropertyName = "UnitsOnOrder"
        UnitsOnOrder.ReadOnly = True
        UnitsOnOrder.Visible = True
        UnitsOnOrder.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(UnitsOnOrder)

        Dim AmountToOrder As New DataGridViewTextBoxColumn
        AmountToOrder.FillWeight = 5
        AmountToOrder.HeaderText = "Amount To Order"
        AmountToOrder.DataPropertyName = "AmountToOrder"
        AmountToOrder.ReadOnly = False
        AmountToOrder.Visible = True
        AmountToOrder.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(AmountToOrder)

        Dim FilterType As New DataGridViewTextBoxColumn
        FilterType.HeaderText = "Filter Type"
        FilterType.DataPropertyName = "FilterType"
        FilterType.ReadOnly = True
        FilterType.Visible = False
        FilterType.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(FilterType)
    End Sub

#End Region

#Region "Events"

    Private Sub UCData_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetupDG()
        m_SelectedStyle.BackColor = Color.LightBlue
    End Sub

    Private Sub dgvData_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellValueChanged
        If e.ColumnIndex = 14 Then
            Dim ItemID As Integer = dgvData.Item(1, e.RowIndex).Value
            ''Dim ItemID As Integer = dgvData.Rows(e.RowIndex).Cells(1).Value
            Dim AmountToOrder As Integer = CInt(dgvData.Rows(e.RowIndex).Cells(14).Value)

            DB.Location.StockTake_Replenishment_UpdateAmountToOrder(ItemID, AmountToOrder)
        End If
    End Sub

    Private Sub dgvData_Click(sender As Object, e As System.EventArgs) Handles dgvData.DoubleClick
        Dim PartID As Integer = dgvData.Item(6, dgvData.CurrentCell.RowIndex).Value
        If Not PartID = Nothing Then ShowForm(GetType(FRMPart), True, New Object() {PartID, False})
    End Sub

    Private Sub dgvData_RowLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellEndEdit
        If e.ColumnIndex = 0 Then
            Dim ItemID As Integer = dgvData.Item(1, e.RowIndex).Value
            'Dim ItemID As Integer = dgvData.Rows(e.RowIndex).Cells(1).Value
            Dim Exclude As Boolean = CBool(dgvData.Rows(e.RowIndex).Cells(0).Value)

            DB.Location.StockTake_Replenishment_UpdateExclude(ItemID, Exclude)
        End If
    End Sub

    Private Sub dgvData_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvData.SelectionChanged
        If Not m_SelectedRow = -1 Then
            m_SelectedRow = dgvData.CurrentRow.Index
            dgvData.CurrentRow.DefaultCellStyle = m_SelectedStyle
        End If
    End Sub

    Private Sub dgvData_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgvData.ColumnHeaderMouseClick
        Dim newColumn As DataGridViewColumn = dgvData.Columns(e.ColumnIndex)
        Dim oldColumn As DataGridViewColumn = dgvData.SortedColumn
        Dim direction As System.ComponentModel.ListSortDirection

        ' If oldColumn is null, then the DataGridView is not currently sorted. 
        If oldColumn IsNot Nothing Then
            ' Sort the same column again, reversing the SortOrder. 
            If oldColumn Is newColumn AndAlso dgvData.SortOrder = SortOrder.Ascending Then
                direction = System.ComponentModel.ListSortDirection.Descending
            Else
                ' Sort a new column and remove the old SortGlyph.
                direction = System.ComponentModel.ListSortDirection.Ascending
                oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None
            End If
        Else
            direction = System.ComponentModel.ListSortDirection.Ascending
        End If

        ' Sort the selected column.
        dgvData.Sort(newColumn, direction)
        If direction = System.ComponentModel.ListSortDirection.Ascending Then
            newColumn.HeaderCell.SortGlyphDirection = SortOrder.Ascending
        Else
            newColumn.HeaderCell.SortGlyphDirection = SortOrder.Descending
        End If
    End Sub

    Private Sub dgvData_RowLeave1(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.RowLeave
        If m_SelectedRow >= 0 Then
            dgvData.Rows(m_SelectedRow).DefaultCellStyle = Nothing
        End If
    End Sub

#End Region


End Class
