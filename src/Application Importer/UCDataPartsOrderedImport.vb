Public Class UCDataPartsOrderedImport : Inherits UCBase

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
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Location = New System.Drawing.Point(0, 0)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.Size = New System.Drawing.Size(512, 344)
        Me.dgvData.TabIndex = 3
        '
        'UCDataPartsInvoiceImport
        '
        Me.Controls.Add(Me.dgvData)
        Me.Name = "UCDataPartsInvoiceImport"
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

    Private _ValidateType As System.String
    Public Property ValidateType() As System.String
        Get
            Return ValidateType
        End Get
        Set(ByVal Value As System.String)
            _ValidateType = Value
        End Set
    End Property

#End Region

#Region "Setup"

    Private m_SelectedStyle As New DataGridViewCellStyle
    Private m_SelectedRow As Integer = -1

    Public Sub SetupDG()

        Dim Exclude As New DataGridViewCheckBoxColumn
        Exclude.FillWeight = 5
        Exclude.HeaderText = "Exclude"
        Exclude.DataPropertyName = "Exclude"
        Exclude.ReadOnly = False
        Exclude.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(Exclude)

        'Dim RequiresAuth As New DataGridViewCheckBoxColumn
        'RequiresAuth.FillWeight = 5
        'RequiresAuth.HeaderText = "Requires Auth"
        'RequiresAuth.DataPropertyName = "RequiresAuthorisation"
        'RequiresAuth.ReadOnly = False
        'RequiresAuth.SortMode = DataGridViewColumnSortMode.Programmatic
        'dgvData.Columns.Add(RequiresAuth)

        Dim ID As New DataGridViewTextBoxColumn
        ID.HeaderText = "ID"
        ID.DataPropertyName = "ID"
        ID.ReadOnly = True
        ID.Visible = False
        ID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(ID)

        Dim SupplierOrderNumber As New DataGridViewTextBoxColumn
        SupplierOrderNumber.HeaderText = "Supplier Order Number"
        SupplierOrderNumber.DataPropertyName = "SupplierOrderNumber"
        SupplierOrderNumber.FillWeight = 15
        SupplierOrderNumber.ReadOnly = True
        SupplierOrderNumber.Visible = True
        SupplierOrderNumber.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(SupplierOrderNumber)

        Dim OrderDate As New DataGridViewTextBoxColumn
        OrderDate.HeaderText = "Order Date"
        OrderDate.DataPropertyName = "OrderDate"
        'InvoiceDate.FillWeight = 15
        OrderDate.ReadOnly = True
        OrderDate.Visible = True
        OrderDate.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(OrderDate)

        Dim PurchaseOrderNumber As New DataGridViewTextBoxColumn
        PurchaseOrderNumber.HeaderText = "Purchase Order Number"
        PurchaseOrderNumber.DataPropertyName = "PurchaseOrderNumber"
        'PurchaseOrderNo.FillWeight = 20
        PurchaseOrderNumber.ReadOnly = False
        PurchaseOrderNumber.Visible = True
        PurchaseOrderNumber.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(PurchaseOrderNumber)

        Dim SupplierPartCode As New DataGridViewTextBoxColumn
        SupplierPartCode.HeaderText = "Supplier PartCode"
        SupplierPartCode.DataPropertyName = "SupplierPartCode"
        SupplierPartCode.ReadOnly = False
        SupplierPartCode.Visible = True
        SupplierPartCode.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(SupplierPartCode)

        Dim Description As New DataGridViewTextBoxColumn
        Description.HeaderText = "Description"
        Description.DataPropertyName = "Description"
        Description.ReadOnly = True
        Description.Visible = True
        Description.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(Description)

        Dim Quantity As New DataGridViewTextBoxColumn
        Quantity.HeaderText = "Quantity"
        Quantity.DataPropertyName = "Quantity"
        Quantity.ReadOnly = True
        Quantity.Visible = True
        Quantity.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(Quantity)

        Dim SupplierID As New DataGridViewTextBoxColumn
        SupplierID.HeaderText = "SupplierID"
        SupplierID.DataPropertyName = "SupplierID"
        SupplierID.FillWeight = 10
        SupplierID.ReadOnly = True
        SupplierID.Visible = False
        SupplierID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(SupplierID)

        Dim SupplierName As New DataGridViewTextBoxColumn
        SupplierName.HeaderText = "Supplier"
        SupplierName.DataPropertyName = "SupplierName"
        SupplierName.FillWeight = 10
        SupplierName.ReadOnly = True
        SupplierName.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(SupplierName)

        Dim Delete As New DataGridViewCheckBoxColumn
        Delete.FillWeight = 5
        Delete.HeaderText = "Delete"
        Delete.DataPropertyName = "Delete"
        Delete.ReadOnly = False
        Delete.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(Delete)

        dgvData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

    End Sub

#End Region

#Region "Events"

    Private Sub UCData_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetupDG()
        m_SelectedStyle.BackColor = Color.LightBlue
    End Sub

    Private Sub dgvData_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvData.CellMouseDoubleClick
        Dim i As Integer = e.Clicks
    End Sub

    Private Sub dgvData_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellValueChanged
        Select Case e.ColumnIndex
            Case 4
                Cursor.Current = Cursors.WaitCursor
                Dim ImportID As Integer = dgvData.Item(1, e.RowIndex).Value
                Dim PurchaseOrderNo As String = dgvData.Item(4, e.RowIndex).Value
                DB.ImportValidation.PartsOrderedImport_UpdatePurchaseOrderNumber(ImportID, PurchaseOrderNo)
                Cursor.Current = Cursors.Default
            Case 5
                Cursor.Current = Cursors.WaitCursor
                Dim ImportID As Integer = dgvData.Item(1, e.RowIndex).Value
                Dim SupplierPartCode As String = dgvData.Item(5, e.RowIndex).Value
                DB.ImportValidation.PartsOrderedImport_UpdateSupplierPartCode(ImportID, SupplierPartCode)
                Cursor.Current = Cursors.Default
        End Select
    End Sub

    Private Sub dgvData_RowLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellEndEdit
        Dim ID As Integer = dgvData.Item(1, e.RowIndex).Value
        Dim Exclude As Boolean = CBool(dgvData.Rows(e.RowIndex).Cells(0).Value)
        DB.ImportValidation.PartsOrderedImport_UpdateExclude(ID, Exclude)
        'Dim RequiresAuth As Boolean = CBool(dgvData.Rows(e.RowIndex).Cells(1).Value)
        'DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(ID, RequiresAuth)

        If loggedInUser.Fullname = "Jane Lockett" Then
            Dim ToBeDeleted As Boolean = CBool(dgvData.Rows(e.RowIndex).Cells(10).Value)
            DB.ImportValidation.PartsOrderedImport_UpdateDelete(ID, ToBeDeleted)
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

#End Region

    'Private Sub dgvData_Click(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvData.Click

    '    If e.Button =MouseButtons.Left Then
    '        If dgvData.CurrentCell.ColumnIndex = 18 Then
    '            Dim dialogue As FRMPOInvoiceIncludedItems
    '            dialogue = checkIfExists(GetType(FRMPOInvoiceIncludedItems).Name, True)
    '            If dialogue Is Nothing Then
    '                dialogue = Activator.CreateInstance(GetType(FRMPOInvoiceIncludedItems))
    '            End If
    '            dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
    '            dialogue.ShowInTaskbar = False
    '            dialogue.POToShow = dgvData.Item(5, dgvData.CurrentCell.RowIndex).Value
    '            dialogue.InvoiceNo = dgvData.Item(3, dgvData.CurrentCell.RowIndex).Value
    '            dialogue.ShowDialog()

    '            If dialogue.DialogResult = DialogResult.OK Then
    '                FRMPartsInvoiceImport.ShowData(_ValidateType)
    '            Else
    '            End If
    '            dialogue.Close()
    '        ElseIf dgvData.CurrentCell.ColumnIndex = 21 Then

    '            If Not dgvData.Item(17, dgvData.CurrentCell.RowIndex).Value Is DBNull.Value Then
    '                ShowForm(GetType(FRMOrder), True, New Object() {dgvData.Item(17, dgvData.CurrentCell.RowIndex).Value, dgvData.Item(20, dgvData.CurrentCell.RowIndex).Value, 0, Me, True})
    '            End If


    '        End If

    '    End If
    'End Sub
End Class
