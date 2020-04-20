using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public partial class FRMPOInvoiceIncludedItems : FRMBaseForm, IForm
    {
        public FRMPOInvoiceIncludedItems()
        {
            InitializeComponent();
        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
        }

        public void ResetMe(int newID)
        {
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private string _POToShow;

        public string POToShow
        {
            get
            {
                string POToShowRet = default;
                return POToShowRet;
            }

            set
            {

                // Me.MinimumSize = New Size(New Point(704, 392))

                _POToShow = value;
                // SetupDG()
                // Records = DB.ImportValidation.POInvoiceImport_ShowPOParts(_POToShow)

                // Me.MinimumSize = Me.Size
            }
        }

        private string _InvoiceNo;

        public string InvoiceNo
        {
            get
            {
                string InvoiceNoRet = default;
                return InvoiceNoRet;
            }

            set
            {

                // Me.MinimumSize = New Size(New Point(704, 392))

                _InvoiceNo = value;
                // SetupDG()
                // Records = DB.ImportValidation.POInvoiceImport_ShowPOParts(_POToShow)

                // Me.MinimumSize = Me.Size
            }
        }

        private DataView _dvRecords;

        private DataView Records
        {
            get
            {
                return _dvRecords;
            }

            set
            {
                _dvRecords = value;
                _dvRecords.Table.TableName = "POInvoiceImport_Parts";
                _dvRecords.AllowNew = false;
                _dvRecords.AllowEdit = true;
                _dvRecords.AllowDelete = false;
                dgvData.DataSource = Records;
            }
        }

        private DataView _dvPORecords;

        private DataView PORecords
        {
            get
            {
                return _dvPORecords;
            }

            set
            {
                _dvPORecords = value;
                _dvPORecords.Table.TableName = "PO_Parts";
                _dvPORecords.AllowNew = false;
                _dvPORecords.AllowEdit = true;
                _dvPORecords.AllowDelete = false;
                dgvPOData.DataSource = PORecords;
            }
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void SetupDG()
        {
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvData.AutoGenerateColumns = false;
            dgvData.EditMode = DataGridViewEditMode.EditOnEnter;

            // Dim Exclude As New DataGridViewCheckBoxColumn
            // Exclude.FillWeight = 5
            // Exclude.HeaderText = "Exclude"
            // Exclude.DataPropertyName = "Exclude"
            // Exclude.ReadOnly = False
            // Exclude.Visible = False
            // Exclude.SortMode = DataGridViewColumnSortMode.Programmatic
            // dgvData.Columns.Add(Exclude)

            // Dim ID As New DataGridViewTextBoxColumn
            // ID.HeaderText = "ID"
            // ID.DataPropertyName = "ID"
            // ID.ReadOnly = True
            // ID.Visible = False
            // ID.SortMode = DataGridViewColumnSortMode.Programmatic
            // dgvData.Columns.Add(ID)

            // Dim PurchaseOrderNo As New DataGridViewTextBoxColumn
            // PurchaseOrderNo.HeaderText = "PurchaseOrderNo"
            // PurchaseOrderNo.DataPropertyName = "PurchaseOrderNo"
            // PurchaseOrderNo.ReadOnly = True
            // PurchaseOrderNo.Visible = False
            // PurchaseOrderNo.SortMode = DataGridViewColumnSortMode.Programmatic
            // dgvData.Columns.Add(PurchaseOrderNo)

            var SupplierPartCode = new DataGridViewTextBoxColumn();
            SupplierPartCode.HeaderText = "Supplier PC";
            SupplierPartCode.FillWeight = 25;
            SupplierPartCode.DataPropertyName = "SupplierPartCode";
            SupplierPartCode.ReadOnly = true;
            SupplierPartCode.Visible = true;
            SupplierPartCode.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(SupplierPartCode);
            var Description = new DataGridViewTextBoxColumn();
            Description.FillWeight = 60;
            Description.HeaderText = "Description";
            Description.DataPropertyName = "Description";
            Description.ReadOnly = true;
            Description.Visible = true;
            Description.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(Description);
            var Quantity = new DataGridViewTextBoxColumn();
            Quantity.HeaderText = "Qty";
            Quantity.DataPropertyName = "Quantity";
            Quantity.FillWeight = 15;
            Quantity.ReadOnly = true;
            Quantity.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(Quantity);
            var UnitPrice = new DataGridViewTextBoxColumn();
            UnitPrice.HeaderText = "Unit Price";
            UnitPrice.DataPropertyName = "UnitPrice";
            UnitPrice.FillWeight = 15;
            UnitPrice.ReadOnly = true;
            UnitPrice.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(UnitPrice);
            var NetAmount = new DataGridViewTextBoxColumn();
            NetAmount.HeaderText = "Net Amount";
            NetAmount.DataPropertyName = "NetAmount";
            NetAmount.FillWeight = 15;
            NetAmount.ReadOnly = true;
            NetAmount.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(NetAmount);
            var VATAmount = new DataGridViewTextBoxColumn();
            VATAmount.HeaderText = "VAT Amount";
            VATAmount.DataPropertyName = "VATAmount";
            VATAmount.FillWeight = 15;
            VATAmount.ReadOnly = true;
            VATAmount.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(VATAmount);
            var GrossAmount = new DataGridViewTextBoxColumn();
            GrossAmount.HeaderText = "Gross Amount";
            GrossAmount.DataPropertyName = "GrossAmount";
            GrossAmount.FillWeight = 15;
            GrossAmount.ReadOnly = true;
            GrossAmount.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(GrossAmount);
            var Failed = new DataGridViewTextBoxColumn();
            Failed.HeaderText = "Failed";
            Failed.DataPropertyName = "FailedPart";
            Failed.FillWeight = 15;
            Failed.ReadOnly = true;
            Failed.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(Failed);

            // Dim ValidateResult As New DataGridViewTextBoxColumn
            // ValidateResult.HeaderText = "Validate Result"
            // ValidateResult.DataPropertyName = "ValidateResult"
            // ValidateResult.ReadOnly = True
            // ValidateResult.Visible = False
            // ValidateResult.SortMode = DataGridViewColumnSortMode.Programmatic
            // dgvData.Columns.Add(ValidateResult)

            // dgvData.Columns(5).ReadOnly = False


        }

        public void SetupDGPOParts()
        {
            dgvPOData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPOData.AutoGenerateColumns = false;
            dgvPOData.EditMode = DataGridViewEditMode.EditOnEnter;

            // Dim Exclude As New DataGridViewCheckBoxColumn
            // Exclude.FillWeight = 5
            // Exclude.HeaderText = "Exclude"
            // Exclude.DataPropertyName = "Exclude"
            // Exclude.ReadOnly = False
            // Exclude.Visible = False
            // Exclude.SortMode = DataGridViewColumnSortMode.Programmatic
            // dgvData.Columns.Add(Exclude)

            // Dim ID As New DataGridViewTextBoxColumn
            // ID.HeaderText = "ID"
            // ID.DataPropertyName = "ID"
            // ID.ReadOnly = True
            // ID.Visible = False
            // ID.SortMode = DataGridViewColumnSortMode.Programmatic
            // dgvPOData.Columns.Add(ID)

            // Dim PurchaseOrderNo As New DataGridViewTextBoxColumn
            // PurchaseOrderNo.HeaderText = "PurchaseOrderNo"
            // PurchaseOrderNo.DataPropertyName = "PurchaseOrderNo"
            // PurchaseOrderNo.ReadOnly = True
            // PurchaseOrderNo.Visible = False
            // PurchaseOrderNo.SortMode = DataGridViewColumnSortMode.Programmatic
            // dgvPOData.Columns.Add(PurchaseOrderNo)

            var SupplierPartCode = new DataGridViewTextBoxColumn();
            SupplierPartCode.HeaderText = "Supplier PC";
            SupplierPartCode.FillWeight = 25;
            SupplierPartCode.DataPropertyName = "SupplierPartCode";
            SupplierPartCode.ReadOnly = true;
            SupplierPartCode.Visible = true;
            SupplierPartCode.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvPOData.Columns.Add(SupplierPartCode);
            var Description = new DataGridViewTextBoxColumn();
            Description.FillWeight = 60;
            Description.HeaderText = "Description";
            Description.DataPropertyName = "Name";
            Description.ReadOnly = true;
            Description.Visible = true;
            Description.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvPOData.Columns.Add(Description);
            var Quantity = new DataGridViewTextBoxColumn();
            Quantity.HeaderText = "Qty";
            Quantity.DataPropertyName = "QuantityOnOrder";
            Quantity.FillWeight = 15;
            Quantity.ReadOnly = true;
            Quantity.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvPOData.Columns.Add(Quantity);
            var UnitPrice = new DataGridViewTextBoxColumn();
            UnitPrice.HeaderText = "Unit Price";
            UnitPrice.DataPropertyName = "BuyPrice";
            UnitPrice.FillWeight = 15;
            UnitPrice.ReadOnly = true;
            UnitPrice.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvPOData.Columns.Add(UnitPrice);

            // Dim NetAmount As New DataGridViewTextBoxColumn
            // NetAmount.HeaderText = "Net Amount"
            // NetAmount.DataPropertyName = "NetAmount"
            // NetAmount.FillWeight = 15
            // NetAmount.ReadOnly = True
            // NetAmount.SortMode = DataGridViewColumnSortMode.Programmatic
            // dgvPOData.Columns.Add(NetAmount)

            // Dim VATAmount As New DataGridViewTextBoxColumn
            // VATAmount.HeaderText = "VAT Amount"
            // VATAmount.DataPropertyName = "VATAmount"
            // VATAmount.FillWeight = 15
            // VATAmount.ReadOnly = True
            // VATAmount.SortMode = DataGridViewColumnSortMode.Programmatic
            // dgvPOData.Columns.Add(VATAmount)

            // Dim GrossAmount As New DataGridViewTextBoxColumn
            // GrossAmount.HeaderText = "Gross Amount"
            // GrossAmount.DataPropertyName = "GrossAmount"
            // GrossAmount.FillWeight = 15
            // GrossAmount.ReadOnly = True
            // GrossAmount.SortMode = DataGridViewColumnSortMode.Programmatic
            // dgvPOData.Columns.Add(GrossAmount)

            // Dim ValidateResult As New DataGridViewTextBoxColumn
            // ValidateResult.HeaderText = "Validate Result"
            // ValidateResult.DataPropertyName = "ValidateResult"
            // ValidateResult.ReadOnly = True
            // ValidateResult.Visible = False
            // ValidateResult.SortMode = DataGridViewColumnSortMode.Programmatic
            // dgvPOData.Columns.Add(ValidateResult)

            // dgvPOData.Columns(5).ReadOnly = False


        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var switchExpr = e.ColumnIndex;
            switch (switchExpr)
            {
                // Case 5
                // Cursor.Current = Cursors.WaitCursor
                // Dim PartID As Integer = dgvData.Item(1, e.RowIndex).Value
                // Dim PartQty As Integer = dgvData.Item(5, e.RowIndex).Value
                // DB.ImportValidation.POInvoiceImport_UpdatePartQty(PartID, PartQty)
                // DB.ImportValidation.POInvoiceImport_UpdateOrderTotalsAfterPartChange(_POToShow, _InvoiceNo)
                // Records = DB.ImportValidation.POInvoiceImport_ShowPOParts(_POToShow, _InvoiceNo)
                // Cursor.Current = Cursors.Default
                // Case 6
                // Cursor.Current = Cursors.WaitCursor
                // Dim PartID As Integer = dgvData.Item(1, e.RowIndex).Value
                // Dim PartUnitPrice As Integer = dgvData.Item(6, e.RowIndex).Value
                // DB.ImportValidation.POInvoiceImport_UpdatePartUnitPrice(PartID, PartUnitPrice)
                // DB.ImportValidation.POInvoiceImport_UpdateOrderTotalsAfterPartChange(_POToShow, _InvoiceNo)
                // Records = DB.ImportValidation.POInvoiceImport_ShowPOParts(_POToShow, _InvoiceNo)
                // Cursor.Current = Cursors.Default
            }
        }

        private void dgvData_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            // Dim ImportID As Integer = dgvData.Item(1, e.RowIndex).Value
            // Dim PurchaseOrderNo As String = dgvData.Item(4, e.RowIndex).Value
            // DB.ImportValidation.POInvoiceImport_UpdatePurchaseOrderNoAndValidate(ImportID, PurchaseOrderNo)
            Cursor.Current = Cursors.Default;
        }

        private void FRMPOInvoiceIncludedItems_Load(object sender, EventArgs e)
        {
            dgvData.AutoGenerateColumns = false;
            Records = App.DB.ImportValidation.POInvoiceImport_ShowPOParts(_POToShow, _InvoiceNo);
            SetupDG();
            dgvPOData.AutoGenerateColumns = false;
            string OrderID = App.DB.Order.Order_Get_OrderID_ByRef(_POToShow);
            PORecords = App.DB.Order.Order_ItemsGetAll(Conversions.ToInteger(OrderID));
            SetupDGPOParts();
        }
    }
}