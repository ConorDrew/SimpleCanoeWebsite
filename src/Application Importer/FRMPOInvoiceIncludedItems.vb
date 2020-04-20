Public Class FRMPOInvoiceIncludedItems : Inherits FSM.FRMBaseForm : Implements IForm


    Public ReadOnly Property LoadedControl As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Public Sub LoadMe(sender As Object, e As EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

    End Sub

    Public Sub ResetMe(newID As Integer) Implements IForm.ResetMe

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

#Region "Properties"
    Private _POToShow As System.String
    Public Property POToShow() As System.String
        Get
            Return POToShow
        End Get
        Set(ByVal Value As System.String)

            'Me.MinimumSize = New Size(New Point(704, 392))

            _POToShow = Value
            'SetupDG()
            'Records = DB.ImportValidation.POInvoiceImport_ShowPOParts(_POToShow)

            'Me.MinimumSize = Me.Size
        End Set
    End Property

    Private _InvoiceNo As System.String
    Public Property InvoiceNo() As System.String
        Get
            Return InvoiceNo
        End Get
        Set(ByVal Value As System.String)

            'Me.MinimumSize = New Size(New Point(704, 392))

            _InvoiceNo = Value
            'SetupDG()
            'Records = DB.ImportValidation.POInvoiceImport_ShowPOParts(_POToShow)

            'Me.MinimumSize = Me.Size
        End Set
    End Property

    Private _dvRecords As DataView
    Private Property Records() As DataView
        Get
            Return _dvRecords
        End Get
        Set(ByVal value As DataView)
            _dvRecords = value
            _dvRecords.Table.TableName = "POInvoiceImport_Parts"
            _dvRecords.AllowNew = False
            _dvRecords.AllowEdit = True
            _dvRecords.AllowDelete = False
            Me.dgvData.DataSource = Records
        End Set
    End Property

    Private _dvPORecords As DataView
    Private Property PORecords() As DataView
        Get
            Return _dvPORecords
        End Get
        Set(ByVal value As DataView)
            _dvPORecords = value
            _dvPORecords.Table.TableName = "PO_Parts"
            _dvPORecords.AllowNew = False
            _dvPORecords.AllowEdit = True
            _dvPORecords.AllowDelete = False
            Me.dgvPOData.DataSource = PORecords
        End Set
    End Property
#End Region

#Region "Setup"
    Public Sub SetupDG()

        dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvData.AutoGenerateColumns = False
        dgvData.EditMode = DataGridViewEditMode.EditOnEnter

        'Dim Exclude As New DataGridViewCheckBoxColumn
        'Exclude.FillWeight = 5
        'Exclude.HeaderText = "Exclude"
        'Exclude.DataPropertyName = "Exclude"
        'Exclude.ReadOnly = False
        'Exclude.Visible = False
        'Exclude.SortMode = DataGridViewColumnSortMode.Programmatic
        'dgvData.Columns.Add(Exclude)

        'Dim ID As New DataGridViewTextBoxColumn
        'ID.HeaderText = "ID"
        'ID.DataPropertyName = "ID"
        'ID.ReadOnly = True
        'ID.Visible = False
        'ID.SortMode = DataGridViewColumnSortMode.Programmatic
        'dgvData.Columns.Add(ID)

        'Dim PurchaseOrderNo As New DataGridViewTextBoxColumn
        'PurchaseOrderNo.HeaderText = "PurchaseOrderNo"
        'PurchaseOrderNo.DataPropertyName = "PurchaseOrderNo"
        'PurchaseOrderNo.ReadOnly = True
        'PurchaseOrderNo.Visible = False
        'PurchaseOrderNo.SortMode = DataGridViewColumnSortMode.Programmatic
        'dgvData.Columns.Add(PurchaseOrderNo)

        Dim SupplierPartCode As New DataGridViewTextBoxColumn
        SupplierPartCode.HeaderText = "Supplier PC"
        SupplierPartCode.FillWeight = 25
        SupplierPartCode.DataPropertyName = "SupplierPartCode"
        SupplierPartCode.ReadOnly = True
        SupplierPartCode.Visible = True
        SupplierPartCode.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(SupplierPartCode)

        Dim Description As New DataGridViewTextBoxColumn
        Description.FillWeight = 60
        Description.HeaderText = "Description"
        Description.DataPropertyName = "Description"
        Description.ReadOnly = True
        Description.Visible = True
        Description.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(Description)

        Dim Quantity As New DataGridViewTextBoxColumn
        Quantity.HeaderText = "Qty"
        Quantity.DataPropertyName = "Quantity"
        Quantity.FillWeight = 15
        Quantity.ReadOnly = True
        Quantity.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(Quantity)

        Dim UnitPrice As New DataGridViewTextBoxColumn
        UnitPrice.HeaderText = "Unit Price"
        UnitPrice.DataPropertyName = "UnitPrice"
        UnitPrice.FillWeight = 15
        UnitPrice.ReadOnly = True
        UnitPrice.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(UnitPrice)

        Dim NetAmount As New DataGridViewTextBoxColumn
        NetAmount.HeaderText = "Net Amount"
        NetAmount.DataPropertyName = "NetAmount"
        NetAmount.FillWeight = 15
        NetAmount.ReadOnly = True
        NetAmount.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(NetAmount)

        Dim VATAmount As New DataGridViewTextBoxColumn
        VATAmount.HeaderText = "VAT Amount"
        VATAmount.DataPropertyName = "VATAmount"
        VATAmount.FillWeight = 15
        VATAmount.ReadOnly = True
        VATAmount.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(VATAmount)

        Dim GrossAmount As New DataGridViewTextBoxColumn
        GrossAmount.HeaderText = "Gross Amount"
        GrossAmount.DataPropertyName = "GrossAmount"
        GrossAmount.FillWeight = 15
        GrossAmount.ReadOnly = True
        GrossAmount.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(GrossAmount)

        Dim Failed As New DataGridViewTextBoxColumn
        Failed.HeaderText = "Failed"
        Failed.DataPropertyName = "FailedPart"
        Failed.FillWeight = 15
        Failed.ReadOnly = True
        Failed.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(Failed)

        'Dim ValidateResult As New DataGridViewTextBoxColumn
        'ValidateResult.HeaderText = "Validate Result"
        'ValidateResult.DataPropertyName = "ValidateResult"
        'ValidateResult.ReadOnly = True
        'ValidateResult.Visible = False
        'ValidateResult.SortMode = DataGridViewColumnSortMode.Programmatic
        'dgvData.Columns.Add(ValidateResult)

        'dgvData.Columns(5).ReadOnly = False


    End Sub

    Public Sub SetupDGPOParts()

        dgvPOData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPOData.AutoGenerateColumns = False
        dgvPOData.EditMode = DataGridViewEditMode.EditOnEnter

        'Dim Exclude As New DataGridViewCheckBoxColumn
        'Exclude.FillWeight = 5
        'Exclude.HeaderText = "Exclude"
        'Exclude.DataPropertyName = "Exclude"
        'Exclude.ReadOnly = False
        'Exclude.Visible = False
        'Exclude.SortMode = DataGridViewColumnSortMode.Programmatic
        'dgvData.Columns.Add(Exclude)

        'Dim ID As New DataGridViewTextBoxColumn
        'ID.HeaderText = "ID"
        'ID.DataPropertyName = "ID"
        'ID.ReadOnly = True
        'ID.Visible = False
        'ID.SortMode = DataGridViewColumnSortMode.Programmatic
        'dgvPOData.Columns.Add(ID)

        'Dim PurchaseOrderNo As New DataGridViewTextBoxColumn
        'PurchaseOrderNo.HeaderText = "PurchaseOrderNo"
        'PurchaseOrderNo.DataPropertyName = "PurchaseOrderNo"
        'PurchaseOrderNo.ReadOnly = True
        'PurchaseOrderNo.Visible = False
        'PurchaseOrderNo.SortMode = DataGridViewColumnSortMode.Programmatic
        'dgvPOData.Columns.Add(PurchaseOrderNo)

        Dim SupplierPartCode As New DataGridViewTextBoxColumn
        SupplierPartCode.HeaderText = "Supplier PC"
        SupplierPartCode.FillWeight = 25
        SupplierPartCode.DataPropertyName = "SupplierPartCode"
        SupplierPartCode.ReadOnly = True
        SupplierPartCode.Visible = True
        SupplierPartCode.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvPOData.Columns.Add(SupplierPartCode)

        Dim Description As New DataGridViewTextBoxColumn
        Description.FillWeight = 60
        Description.HeaderText = "Description"
        Description.DataPropertyName = "Name"
        Description.ReadOnly = True
        Description.Visible = True
        Description.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvPOData.Columns.Add(Description)

        Dim Quantity As New DataGridViewTextBoxColumn
        Quantity.HeaderText = "Qty"
        Quantity.DataPropertyName = "QuantityOnOrder"
        Quantity.FillWeight = 15
        Quantity.ReadOnly = True
        Quantity.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvPOData.Columns.Add(Quantity)

        Dim UnitPrice As New DataGridViewTextBoxColumn
        UnitPrice.HeaderText = "Unit Price"
        UnitPrice.DataPropertyName = "BuyPrice"
        UnitPrice.FillWeight = 15
        UnitPrice.ReadOnly = True
        UnitPrice.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvPOData.Columns.Add(UnitPrice)

        'Dim NetAmount As New DataGridViewTextBoxColumn
        'NetAmount.HeaderText = "Net Amount"
        'NetAmount.DataPropertyName = "NetAmount"
        'NetAmount.FillWeight = 15
        'NetAmount.ReadOnly = True
        'NetAmount.SortMode = DataGridViewColumnSortMode.Programmatic
        'dgvPOData.Columns.Add(NetAmount)

        'Dim VATAmount As New DataGridViewTextBoxColumn
        'VATAmount.HeaderText = "VAT Amount"
        'VATAmount.DataPropertyName = "VATAmount"
        'VATAmount.FillWeight = 15
        'VATAmount.ReadOnly = True
        'VATAmount.SortMode = DataGridViewColumnSortMode.Programmatic
        'dgvPOData.Columns.Add(VATAmount)

        'Dim GrossAmount As New DataGridViewTextBoxColumn
        'GrossAmount.HeaderText = "Gross Amount"
        'GrossAmount.DataPropertyName = "GrossAmount"
        'GrossAmount.FillWeight = 15
        'GrossAmount.ReadOnly = True
        'GrossAmount.SortMode = DataGridViewColumnSortMode.Programmatic
        'dgvPOData.Columns.Add(GrossAmount)

        'Dim ValidateResult As New DataGridViewTextBoxColumn
        'ValidateResult.HeaderText = "Validate Result"
        'ValidateResult.DataPropertyName = "ValidateResult"
        'ValidateResult.ReadOnly = True
        'ValidateResult.Visible = False
        'ValidateResult.SortMode = DataGridViewColumnSortMode.Programmatic
        'dgvPOData.Columns.Add(ValidateResult)

        'dgvPOData.Columns(5).ReadOnly = False


    End Sub
    
#End Region

    Private Sub dgvData_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellValueChanged
        Select Case e.ColumnIndex
            'Case 5
            '    Cursor.Current = Cursors.WaitCursor
            '    Dim PartID As Integer = dgvData.Item(1, e.RowIndex).Value
            '    Dim PartQty As Integer = dgvData.Item(5, e.RowIndex).Value
            '    DB.ImportValidation.POInvoiceImport_UpdatePartQty(PartID, PartQty)
            '    DB.ImportValidation.POInvoiceImport_UpdateOrderTotalsAfterPartChange(_POToShow, _InvoiceNo)
            '    Records = DB.ImportValidation.POInvoiceImport_ShowPOParts(_POToShow, _InvoiceNo)
            '    Cursor.Current = Cursors.Default
            'Case 6
            '    Cursor.Current = Cursors.WaitCursor
            '    Dim PartID As Integer = dgvData.Item(1, e.RowIndex).Value
            '    Dim PartUnitPrice As Integer = dgvData.Item(6, e.RowIndex).Value
            '    DB.ImportValidation.POInvoiceImport_UpdatePartUnitPrice(PartID, PartUnitPrice)
            '    DB.ImportValidation.POInvoiceImport_UpdateOrderTotalsAfterPartChange(_POToShow, _InvoiceNo)
            '    Records = DB.ImportValidation.POInvoiceImport_ShowPOParts(_POToShow, _InvoiceNo)
            '    Cursor.Current = Cursors.Default
        End Select
    End Sub

    Private Sub dgvData_Click(sender As Object, e As EventArgs) Handles dgvData.Click
        Cursor.Current = Cursors.WaitCursor
        'Dim ImportID As Integer = dgvData.Item(1, e.RowIndex).Value
        'Dim PurchaseOrderNo As String = dgvData.Item(4, e.RowIndex).Value
        'DB.ImportValidation.POInvoiceImport_UpdatePurchaseOrderNoAndValidate(ImportID, PurchaseOrderNo)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub FRMPOInvoiceIncludedItems_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvData.AutoGenerateColumns = False
        Records = DB.ImportValidation.POInvoiceImport_ShowPOParts(_POToShow, _InvoiceNo)
        SetupDG()
        dgvPOData.AutoGenerateColumns = False
        Dim OrderID As String = DB.Order.Order_Get_OrderID_ByRef(_POToShow)
        PORecords = DB.Order.Order_ItemsGetAll(OrderID)
        SetupDGPOParts()
    End Sub
End Class