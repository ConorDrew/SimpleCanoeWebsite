Imports System.Collections.Generic

Public Class UCDataPODuplicateInvoice : Inherits UCBase

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
            dgvData.AutoGenerateColumns = False
            Me.dgvData.DataSource = Data
        End Set
    End Property

#End Region

#Region "Setup"

    Private m_SelectedStyle As New DataGridViewCellStyle
    Private m_SelectedRow As Integer = -1

    Public Sub SetupDG()

        dgvData.AutoGenerateColumns = False

        Dim InvoiceNo As New DataGridViewTextBoxColumn
        InvoiceNo.HeaderText = "Invoice No"
        InvoiceNo.DataPropertyName = "InvoiceNo"
        InvoiceNo.FillWeight = 15
        InvoiceNo.ReadOnly = True
        InvoiceNo.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(InvoiceNo)

        Dim InvoiceDate As New DataGridViewTextBoxColumn
        InvoiceDate.HeaderText = "Invoice Date"
        InvoiceDate.DataPropertyName = "InvoiceDate"
        InvoiceDate.ReadOnly = True
        InvoiceDate.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(InvoiceDate)

        Dim PurchaseOrderNo As New DataGridViewTextBoxColumn
        PurchaseOrderNo.HeaderText = "Purchase Order No"
        PurchaseOrderNo.DataPropertyName = "PurchaseOrderNo"
        PurchaseOrderNo.ReadOnly = True
        PurchaseOrderNo.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(PurchaseOrderNo)

        Dim SupplierID As New DataGridViewTextBoxColumn
        SupplierID.HeaderText = "Supplier ID"
        SupplierID.DataPropertyName = "SupplierID"
        SupplierID.Visible = False
        SupplierID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(SupplierID)

        Dim SupplierPartCode As New DataGridViewTextBoxColumn
        SupplierPartCode.HeaderText = "Supplier Part Code"
        SupplierPartCode.DataPropertyName = "SupplierPartCode"
        SupplierPartCode.ReadOnly = True
        SupplierPartCode.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(SupplierPartCode)

        Dim Description As New DataGridViewTextBoxColumn
        Description.HeaderText = "Part Description"
        Description.DataPropertyName = "Description"
        Description.Visible = True
        Description.ReadOnly = True
        Description.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(Description)

        Dim Quantities As New DataGridViewTextBoxColumn
        Quantities.HeaderText = "Quantity Of Parts"
        Quantities.DataPropertyName = "Quantity"
        Quantities.FillWeight = 10
        Quantities.ReadOnly = True
        Quantities.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(Quantities)

        Dim UnitPrice As New DataGridViewTextBoxColumn
        UnitPrice.HeaderText = "Unit Price"
        UnitPrice.DataPropertyName = "UnitPrice"
        UnitPrice.ReadOnly = True
        UnitPrice.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(UnitPrice)

        Dim NetAmount As New DataGridViewTextBoxColumn
        NetAmount.HeaderText = "Net Amount"
        NetAmount.DataPropertyName = "NetAmount"
        NetAmount.ReadOnly = True
        NetAmount.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(NetAmount)

        Dim VATAmount As New DataGridViewTextBoxColumn
        VATAmount.HeaderText = "VAT Amount"
        VATAmount.DataPropertyName = "VATAmount"
        VATAmount.ReadOnly = True
        VATAmount.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(VATAmount)

        Dim GrossAmount As New DataGridViewTextBoxColumn
        GrossAmount.HeaderText = "Gross Amount"
        GrossAmount.DataPropertyName = "GrossAmount"
        GrossAmount.ReadOnly = True
        GrossAmount.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(GrossAmount)

        Dim TotalQtyOfParts As New DataGridViewTextBoxColumn
        TotalQtyOfParts.HeaderText = "Total Qty Of Parts"
        TotalQtyOfParts.DataPropertyName = "TotalQtyOfParts"
        TotalQtyOfParts.ReadOnly = True
        TotalQtyOfParts.Visible = False
        TotalQtyOfParts.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(TotalQtyOfParts)

        Dim Allow As New DataGridViewCheckBoxColumn
        Allow.FillWeight = 5
        Allow.HeaderText = "Allow"
        Allow.DataPropertyName = "Allow"
        Allow.ReadOnly = False
        Allow.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(Allow)

        Dim Update As New DataGridViewButtonColumn
        Update.HeaderText = "Update"
        Update.DataPropertyName = "Update"
        Update.ReadOnly = True
        Update.Visible = True
        Update.DefaultCellStyle.NullValue = "Update"
        Update.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(Update)

        dgvData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
    End Sub

#End Region

#Region "Events"

    'Private Sub UCData_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'End Sub
    Private Sub UCDataPOInvoiceAuthorisation_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetupDG()
        m_SelectedStyle.BackColor = Color.LightBlue
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

    Private Sub dgvData_Click(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvData.Click
        If e.Button = MouseButtons.Left Then
            If dgvData.CurrentCell IsNot Nothing Then
                If dgvData.CurrentCell.ColumnIndex = 13 Then
                    Dim toBeAllowed As Boolean = CBool(dgvData.Item(12, dgvData.CurrentCell.RowIndex).Value)
                    If toBeAllowed Then
                        Dim invoiceNo As String = dgvData.Item(0, dgvData.CurrentCell.RowIndex).Value
                        If ShowMessage("Add " & invoiceNo & " to database?",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Warning) = DialogResult.Yes Then
                            'insert the part into the table
                            DB.ImportValidation.POInvoiceImport_InsertPart(
                                dgvData.Item(2, dgvData.CurrentCell.RowIndex).Value,
                                dgvData.Item(4, dgvData.CurrentCell.RowIndex).Value,
                                dgvData.Item(5, dgvData.CurrentCell.RowIndex).Value,
                                dgvData.Item(6, dgvData.CurrentCell.RowIndex).Value,
                                dgvData.Item(7, dgvData.CurrentCell.RowIndex).Value,
                                dgvData.Item(8, dgvData.CurrentCell.RowIndex).Value,
                                dgvData.Item(9, dgvData.CurrentCell.RowIndex).Value,
                                dgvData.Item(10, dgvData.CurrentCell.RowIndex).Value,
                                dgvData.Item(0, dgvData.CurrentCell.RowIndex).Value)

                            DB.ImportValidation.POInvoiceImport_UpdateOrderTotals(
                                dgvData.Item(2, dgvData.CurrentCell.RowIndex).Value,
                                dgvData.Item(6, dgvData.CurrentCell.RowIndex).Value,
                                dgvData.Item(7, dgvData.CurrentCell.RowIndex).Value,
                                dgvData.Item(8, dgvData.CurrentCell.RowIndex).Value,
                                dgvData.Item(9, dgvData.CurrentCell.RowIndex).Value,
                                dgvData.Item(10, dgvData.CurrentCell.RowIndex).Value,
                                dgvData.Item(11, dgvData.CurrentCell.RowIndex).Value,
                                dgvData.Item(0, dgvData.CurrentCell.RowIndex).Value)

                            Data.Delete(dgvData.CurrentCell.RowIndex)
                            dgvData.Refresh()
                        End If
                    End If
                End If
            End If
        End If
    End Sub
End Class
