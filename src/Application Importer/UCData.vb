Public Class UCData : Inherits UCBase

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

        Dim Exclude As New DataGridViewCheckBoxColumn
        Exclude.FillWeight = 25
        Exclude.HeaderText = "Exclude"
        Exclude.DataPropertyName = "Exclude"
        Exclude.ReadOnly = False
        Exclude.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(Exclude)

        Dim ForceInsert As New DataGridViewCheckBoxColumn
        ForceInsert.FillWeight = 25
        ForceInsert.HeaderText = "Force Insert"
        ForceInsert.DataPropertyName = "ForceInsert"
        ForceInsert.ReadOnly = False
        ForceInsert.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(ForceInsert)

        Dim ImportID As New DataGridViewTextBoxColumn
        ImportID.HeaderText = "Import ID"
        ImportID.DataPropertyName = "ImportID"
        ImportID.ReadOnly = True
        ImportID.Visible = False
        ImportID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(ImportID)

        Dim PartID As New DataGridViewTextBoxColumn
        PartID.HeaderText = "Part ID"
        PartID.DataPropertyName = "PartID"
        PartID.ReadOnly = True
        PartID.Visible = False
        PartID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(PartID)

        Dim ImportPrice As New DataGridViewTextBoxColumn
        ImportPrice.FillWeight = 35
        ImportPrice.HeaderText = "Import Price"
        ImportPrice.DataPropertyName = "Import Price"
        ImportPrice.ReadOnly = False
        ImportPrice.SortMode = DataGridViewColumnSortMode.Programmatic
        ImportPrice.DefaultCellStyle.Format = "N3"
        dgvData.Columns.Add(ImportPrice)

        Dim ExistingPrice As New DataGridViewTextBoxColumn
        ExistingPrice.FillWeight = 35
        ExistingPrice.HeaderText = "Existing Price"
        ExistingPrice.DataPropertyName = "Existing Price"
        ExistingPrice.DefaultCellStyle.Format = "N3"
        ExistingPrice.ReadOnly = True
        ExistingPrice.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(ExistingPrice)

        Dim PercentDifference As New DataGridViewTextBoxColumn
        PercentDifference.FillWeight = 35
        PercentDifference.HeaderText = "Percent Difference"
        PercentDifference.DataPropertyName = "PercentDifference"
        PercentDifference.DefaultCellStyle.Format = "0.00\%"
        PercentDifference.ReadOnly = True
        PercentDifference.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(PercentDifference)

        Dim ImportSecondaryPrice As New DataGridViewTextBoxColumn
        ImportSecondaryPrice.FillWeight = 35
        ImportSecondaryPrice.HeaderText = "Import Secondary Price"
        ImportSecondaryPrice.DataPropertyName = "Import Secondary Price"
        ImportSecondaryPrice.ReadOnly = False
        ImportSecondaryPrice.DefaultCellStyle.Format = "N3"
        ImportSecondaryPrice.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(ImportSecondaryPrice)

        Dim ExistingSecondaryPrice As New DataGridViewTextBoxColumn
        ExistingSecondaryPrice.FillWeight = 35
        ExistingSecondaryPrice.HeaderText = "Existing Secondary Price"
        ExistingSecondaryPrice.DataPropertyName = "Existing Secondary Price"
        ExistingSecondaryPrice.ReadOnly = True
        ExistingSecondaryPrice.DefaultCellStyle.Format = "N3"
        ExistingSecondaryPrice.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(ExistingSecondaryPrice)

        Dim PercentDifferenceSecondary As New DataGridViewTextBoxColumn
        PercentDifferenceSecondary.FillWeight = 35
        PercentDifferenceSecondary.HeaderText = "Secondary Percent Difference"
        PercentDifferenceSecondary.DataPropertyName = "SecondaryPercentDifference"
        PercentDifferenceSecondary.DefaultCellStyle.Format = "0.00\%"
        PercentDifferenceSecondary.ReadOnly = True
        PercentDifferenceSecondary.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(PercentDifferenceSecondary)

        Dim ImportDesc As New DataGridViewTextBoxColumn
        ImportDesc.FillWeight = 200
        ImportDesc.HeaderText = "Import Description"
        ImportDesc.DataPropertyName = "Import Desc"
        ImportDesc.ReadOnly = False
        ImportDesc.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(ImportDesc)

        Dim ExistingDesc As New DataGridViewTextBoxColumn
        ExistingDesc.FillWeight = 200
        ExistingDesc.HeaderText = "Existing Description"
        ExistingDesc.DataPropertyName = "Existing Desc"
        ExistingDesc.ReadOnly = True
        ExistingDesc.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(ExistingDesc)

        Dim ImportPartCode As New DataGridViewTextBoxColumn
        ImportPartCode.FillWeight = 75
        ImportPartCode.HeaderText = "Import MPN"
        ImportPartCode.DataPropertyName = "Import PC"
        ImportPartCode.ReadOnly = True
        ImportPartCode.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(ImportPartCode)

        Dim ExistingPartCode As New DataGridViewTextBoxColumn
        ExistingPartCode.FillWeight = 75
        ExistingPartCode.HeaderText = "Existing MPN"
        ExistingPartCode.DataPropertyName = "Existing PC"
        ExistingPartCode.ReadOnly = True
        ExistingPartCode.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(ExistingPartCode)

        Dim ImportSPC As New DataGridViewTextBoxColumn
        ImportSPC.FillWeight = 75
        ImportSPC.HeaderText = "Import SPN"
        ImportSPC.DataPropertyName = "Import SPC"
        ImportSPC.ReadOnly = False
        ImportSPC.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(ImportSPC)

        Dim ExistingSPC As New DataGridViewTextBoxColumn
        ExistingSPC.FillWeight = 75
        ExistingSPC.HeaderText = "Existing SPN"
        ExistingSPC.DataPropertyName = "Existing SPC"
        ExistingSPC.ReadOnly = False
        ExistingSPC.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(ExistingSPC)

        Dim Supplier As New DataGridViewTextBoxColumn
        Supplier.FillWeight = 100
        Supplier.HeaderText = "Supplier Name"
        Supplier.DataPropertyName = "Supplier Name"
        Supplier.ReadOnly = True
        Supplier.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(Supplier)

        Dim Category As New DataGridViewTextBoxColumn
        Category.FillWeight = 100
        Category.HeaderText = "Category"
        Category.DataPropertyName = "Category"
        Category.Name = "Category"
        Category.ReadOnly = True
        Category.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(Category)

        Dim SwapSPN As New DataGridViewCheckBoxColumn
        SwapSPN.FillWeight = 25
        SwapSPN.HeaderText = "Swap SPN"
        SwapSPN.DataPropertyName = "SwapSPN"
        SwapSPN.Name = "SwapSPN"
        SwapSPN.ReadOnly = False
        PartID.Visible = False
        dgvData.Columns.Add(SwapSPN)

    End Sub


#End Region

#Region "Events"

    Private Sub UCData_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_SelectedStyle.BackColor = Color.LightBlue
    End Sub

    Private Sub dgData_Click(sender As Object, e As System.EventArgs) Handles dgvData.DoubleClick
        Dim PartID As Integer = dgvData.Item(3, dgvData.CurrentCell.RowIndex).Value
        If Not PartID = Nothing Then ShowForm(GetType(FRMPart), True, New Object() {PartID, False})
    End Sub

    Private Sub dgData_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvData.CellMouseUp
        If (e.ColumnIndex = 0 Or e.ColumnIndex = dgvData.Columns("SwapSPN").Index Or e.ColumnIndex = 1) And e.RowIndex >= 0 Then
            dgvData.EndEdit()
        End If
    End Sub

    Private Sub dgvData_RowLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellEndEdit
        If e.RowIndex >= 0 Then
            Dim ImportID As Integer = dgvData.Item(2, e.RowIndex).Value
            Dim Exclude As Boolean = CBool(dgvData.Rows(e.RowIndex).Cells(0).Value)
            Dim ForceInsert As Boolean = CBool(dgvData.Rows(e.RowIndex).Cells(1).Value)
            Dim ImportPrice As Double = dgvData.Item(4, e.RowIndex).Value
            Dim SwapSPN As Boolean = CBool(dgvData.Rows(e.RowIndex).Cells(dgvData.Columns("SwapSPN").Index).Value)
            Dim Category As String = CStr(dgvData.Rows(e.RowIndex).Cells(dgvData.Columns("Category").Index).Value)
            Dim ImportDescription As String = ""
            DB.ImportValidation.Parts_PreImportChange(ImportID, Exclude, ForceInsert, ImportPrice, ImportDescription, SwapSPN, Category)
        End If
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvData.SelectionChanged
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