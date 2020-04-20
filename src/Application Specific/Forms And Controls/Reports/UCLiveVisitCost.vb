Public Class UCLiveVisitCost : Inherits UCBase

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
            _Data.AllowEdit = False
            _Data.AllowDelete = False
            dgvData.AutoGenerateColumns = True
            Me.dgvData.DataSource = Data
        End Set
    End Property

#End Region

#Region "Setup"

    Private m_SelectedStyle As New DataGridViewCellStyle
    Private m_SelectedRow As Integer = -1

    Public Sub SetupDG()
        dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        'Dim Exclude As New DataGridViewCheckBoxColumn
        'Exclude.FillWeight = 25
        'Exclude.HeaderText = "Exclude"
        'Exclude.DataPropertyName = "Exclude"
        'Exclude.ReadOnly = False
        'Exclude.SortMode = DataGridViewColumnSortMode.Programmatic
        'dgvData.Columns.Add(Exclude)
    End Sub

#End Region

#Region "Events"

    Private Sub UCData_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetupDG()
        m_SelectedStyle.BackColor = Color.LightBlue
    End Sub

    'Private Sub dgvData_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellValueChanged
    '    If e.ColumnIndex = 11 Then
    '        Dim ImportID As Integer = dgvData.Item(2, e.RowIndex).Value
    '        Dim ImportDescription As String = dgvData.Item(6, e.RowIndex).Value
    '        Dim ExistingSPC As String = dgvData.Item(11, e.RowIndex).Value

    '        DB.ImportValidation.Parts_UpdatePart(ImportID, ImportDescription, ExistingSPC)
    '    End If
    'End Sub

    'Private Sub dgData_Click(sender As Object, e As System.EventArgs) Handles dgvData.DoubleClick
    '    Dim PartID As Integer = dgvData.Item(3, dgvData.CurrentCell.RowIndex).Value
    '    If Not PartID = Nothing Then ShowForm(GetType(FRMPart), True, New Object() {PartID, False})
    'End Sub

    'Private Sub dgvData_RowLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellEndEdit
    '    Dim ImportID As Integer = dgvData.Item(2, e.RowIndex).Value
    '    Dim Exclude As Boolean = CBool(dgvData.Rows(e.RowIndex).Cells(0).Value)
    '    Dim ForceInsert As Boolean = CBool(dgvData.Rows(e.RowIndex).Cells(1).Value)
    '    Dim ImportPrice As Double = dgvData.Item(4, e.RowIndex).Value
    '    Dim ImportDescription As String = dgvData.Item(7, e.RowIndex).Value

    '    DB.ImportValidation.Parts_PreImportChange(ImportID, Exclude, ForceInsert, ImportPrice, ImportDescription)
    'End Sub

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
