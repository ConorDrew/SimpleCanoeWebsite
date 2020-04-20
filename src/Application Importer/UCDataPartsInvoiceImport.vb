Public Class UCDataPartsInvoiceImport : Inherits UCBase

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

        Dim Exclude As New DataGridViewCheckBoxColumn '0
        Exclude.FillWeight = 5
        Exclude.HeaderText = "Exclude"
        Exclude.DataPropertyName = "Exclude"
        Exclude.ReadOnly = False
        Exclude.Visible = False
        Exclude.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(Exclude)

        Dim RequiresAuth As New DataGridViewCheckBoxColumn '1
        RequiresAuth.FillWeight = 5
        RequiresAuth.HeaderText = "Requires Auth"
        RequiresAuth.DataPropertyName = "RequiresAuthorisation"
        RequiresAuth.ReadOnly = False
        RequiresAuth.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(RequiresAuth)

        Dim ID As New DataGridViewTextBoxColumn '2
        ID.HeaderText = "ID"
        ID.DataPropertyName = "ID"
        ID.ReadOnly = True
        ID.Visible = False
        ID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(ID)

        Dim InvoiceNo As New DataGridViewTextBoxColumn '3
        InvoiceNo.HeaderText = "Invoice No"
        InvoiceNo.DataPropertyName = "InvoiceNo"
        InvoiceNo.FillWeight = 15
        InvoiceNo.ReadOnly = True
        InvoiceNo.Visible = True
        InvoiceNo.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(InvoiceNo)

        Dim InvoiceDate As New DataGridViewTextBoxColumn '4
        InvoiceDate.HeaderText = "Invoice Date"
        InvoiceDate.DataPropertyName = "InvoiceDate"
        InvoiceDate.ReadOnly = True
        InvoiceDate.Visible = True
        InvoiceDate.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(InvoiceDate)

        Dim PurchaseOrderNo As New DataGridViewTextBoxColumn '5
        PurchaseOrderNo.HeaderText = "Purchase Order No"
        PurchaseOrderNo.DataPropertyName = "PurchaseOrderNo"
        PurchaseOrderNo.ReadOnly = False
        PurchaseOrderNo.Visible = True
        PurchaseOrderNo.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(PurchaseOrderNo)

        Dim invoSup As New DataGridViewTextBoxColumn '6
        invoSup.HeaderText = "Inv Supp"
        invoSup.DataPropertyName = "SupplierName"
        invoSup.ReadOnly = True
        invoSup.Visible = True
        invoSup.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(invoSup)

        Dim poSupp As New DataGridViewTextBoxColumn '7
        poSupp.HeaderText = "PO Supp"
        poSupp.DataPropertyName = "POSupp"
        poSupp.ReadOnly = True
        poSupp.Visible = True
        poSupp.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(poSupp)

        Dim PONetValue As New DataGridViewTextBoxColumn '8
        PONetValue.HeaderText = "PO Net Value"
        PONetValue.DataPropertyName = "PONetValue"
        PONetValue.ReadOnly = True
        PONetValue.Visible = True
        PONetValue.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(PONetValue)

        Dim PONetDifference As New DataGridViewTextBoxColumn '9
        PONetDifference.HeaderText = "Net Difference (£)"
        PONetDifference.DataPropertyName = "PONetDifference"
        PONetDifference.ReadOnly = True
        PONetDifference.Visible = True
        PONetDifference.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(PONetDifference)

        Dim TotalNetAmount As New DataGridViewTextBoxColumn '10
        TotalNetAmount.HeaderText = "Invoice Net Amount"
        TotalNetAmount.DataPropertyName = "TotalNetAmount"
        TotalNetAmount.ReadOnly = True
        TotalNetAmount.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(TotalNetAmount)

        Dim TotalVATAmount As New DataGridViewTextBoxColumn '11
        TotalVATAmount.HeaderText = "Invoice VAT Amount"
        TotalVATAmount.DataPropertyName = "TotalVATAmount"
        TotalVATAmount.ReadOnly = True
        TotalVATAmount.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(TotalVATAmount)

        Dim TotalGrossAmount As New DataGridViewTextBoxColumn '12
        TotalGrossAmount.HeaderText = "Invoice Gross Amount"
        TotalGrossAmount.DataPropertyName = "TotalGrossAmount"
        TotalGrossAmount.ReadOnly = True
        TotalGrossAmount.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(TotalGrossAmount)

        Dim ViewParts As New DataGridViewTextBoxColumn '13
        ViewParts.HeaderText = "View Parts"
        ViewParts.DataPropertyName = "ViewParts"
        ViewParts.ReadOnly = True
        ViewParts.Visible = True
        ViewParts.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(ViewParts)

        Dim ViewOrder As New DataGridViewTextBoxColumn '14
        ViewOrder.HeaderText = "View Order"
        ViewOrder.DataPropertyName = "ViewOrder"
        ViewOrder.ReadOnly = True
        ViewOrder.Visible = True
        ViewOrder.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(ViewOrder)

        Dim updateSupplier As New DataGridViewCheckBoxColumn '15
        updateSupplier.FillWeight = 5
        updateSupplier.HeaderText = "Update Supplier"
        updateSupplier.DataPropertyName = "EditOrder"
        updateSupplier.ReadOnly = False
        updateSupplier.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(updateSupplier)

        Dim Delete As New DataGridViewCheckBoxColumn '16
        Delete.FillWeight = 5
        Delete.HeaderText = "Delete"
        Delete.DataPropertyName = "Delete"
        Delete.ReadOnly = False
        Delete.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(Delete)

        Dim POOrderID As New DataGridViewTextBoxColumn '17
        POOrderID.HeaderText = "POOrderID"
        POOrderID.DataPropertyName = "OrderID"
        POOrderID.ReadOnly = True
        POOrderID.Visible = False
        POOrderID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(POOrderID)

        Dim OrderForID As New DataGridViewTextBoxColumn '18
        OrderForID.HeaderText = "OrderForID"
        OrderForID.DataPropertyName = "OrderForID"
        OrderForID.ReadOnly = True
        OrderForID.Visible = False
        OrderForID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(OrderForID)

        Dim ValidateResult As New DataGridViewTextBoxColumn '19
        ValidateResult.HeaderText = "Validate Result"
        ValidateResult.DataPropertyName = "ValidateResult"
        ValidateResult.ReadOnly = True
        ValidateResult.Visible = False
        ValidateResult.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(ValidateResult)

        Dim SupplierID As New DataGridViewTextBoxColumn '20
        SupplierID.HeaderText = "Supplier ID"
        SupplierID.DataPropertyName = "SupplierID"
        SupplierID.ReadOnly = True
        SupplierID.Visible = False
        SupplierID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(SupplierID)

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
            Case 5
                Cursor.Current = Cursors.WaitCursor
                Dim ImportID As Integer = dgvData.Item(2, e.RowIndex).Value
                Dim PurchaseOrderNo As String = dgvData.Item(5, e.RowIndex).Value
                DB.ImportValidation.POInvoiceImport_UpdatePurchaseOrderNoAndValidate(ImportID, PurchaseOrderNo)
                Cursor.Current = Cursors.Default
        End Select
    End Sub

    Private Sub dgvData_RowLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellEndEdit
        Dim ID As Integer = dgvData.Item(2, e.RowIndex).Value

        Dim RequiresAuth As Boolean = CBool(dgvData.Rows(e.RowIndex).Cells(1).Value)
        Dim PONetDiff As Double = 0.0
        If dgvData.Rows(e.RowIndex).Cells(8).Value.ToString = "" Then
        Else
            PONetDiff = CDbl(dgvData.Rows(e.RowIndex).Cells(8).Value)
        End If

        If RequiresAuth = True And Not PONetDiff = 0.0 Then
            DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(ID, RequiresAuth)
        ElseIf RequiresAuth = False Then
            DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(ID, RequiresAuth)
        Else
        End If

        Dim updateSupplier As Boolean = CBool(dgvData.Rows(e.RowIndex).Cells(15).Value)
        Dim validationResult As Integer = CInt(dgvData.Rows(e.RowIndex).Cells(19).Value)
        If updateSupplier And validationResult = CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.SuppliersDoNotMatch) Then
            Dim orderId As Integer = dgvData.Item(17, dgvData.CurrentCell.RowIndex).Value
            Dim supplierId As Integer = dgvData.Item(20, dgvData.CurrentCell.RowIndex).Value
            DB.ImportValidation.Order_UpdateSupplier(orderId, supplierId)
        End If

        If loggedInUser.Fullname = "Jane Lockett" Then
            Dim ToBeDeleted As Boolean = CBool(dgvData.Rows(e.RowIndex).Cells(16).Value)
            DB.ImportValidation.POInvoiceImport_UpdateDelete(ID, ToBeDeleted)
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

    Private Sub dgvData_Click(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvData.Click
        If e.Button = MouseButtons.Left Then
            If dgvData.CurrentCell IsNot Nothing Then
                Select Case dgvData.CurrentCell.ColumnIndex
                    Case 0
                        Dim ID As Integer = dgvData.Item(2, dgvData.CurrentCell.RowIndex).Value
                        Dim chkExcluded As DataGridViewCheckBoxCell = dgvData.CurrentCell
                        Dim exclude As Boolean = If(chkExcluded.EditingCellFormattedValue, False, True)
                        DB.ImportValidation.POInvoiceImport_UpdateExclude(ID, exclude)
                    Case 13
                        Dim dialogue As FRMPOInvoiceIncludedItems
                        dialogue = checkIfExists(GetType(FRMPOInvoiceIncludedItems).Name, True)
                        If dialogue Is Nothing Then
                            dialogue = Activator.CreateInstance(GetType(FRMPOInvoiceIncludedItems))
                        End If
                        dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
                        dialogue.ShowInTaskbar = False
                        dialogue.POToShow = dgvData.Item(5, dgvData.CurrentCell.RowIndex).Value
                        dialogue.InvoiceNo = dgvData.Item(3, dgvData.CurrentCell.RowIndex).Value
                        dialogue.ShowDialog()

                        If dialogue.DialogResult = DialogResult.OK Then
                            FRMPartsInvoiceImport.ShowData(_ValidateType)
                        Else
                        End If
                        dialogue.Close()
                    Case 14
                        If Not dgvData.Item(17, dgvData.CurrentCell.RowIndex).Value Is DBNull.Value Then
                            ShowForm(GetType(FRMOrder), True, New Object() {dgvData.Item(17, dgvData.CurrentCell.RowIndex).Value, dgvData.Item(18, dgvData.CurrentCell.RowIndex).Value, 0, Me, True})
                        End If
                End Select
            End If
        End If
    End Sub

End Class