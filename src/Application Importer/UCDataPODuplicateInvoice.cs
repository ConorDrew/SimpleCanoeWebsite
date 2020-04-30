using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCDataPODuplicateInvoice : UCBase
    {
        

        public UCDataPODuplicateInvoice() : base()
        {
            
            
            // Private Sub UCData_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            // End Sub
            this.Load += UCDataPOInvoiceAuthorisation_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
        }

        // Form overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components is null))
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        private DataGridView _dgvData;

        internal DataGridView dgvData
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgvData;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgvData != null)
                {
                    _dgvData.ColumnHeaderMouseClick -= dgvData_ColumnHeaderMouseClick;

                    
                    _dgvData.Click -= dgvData_Click;
                }

                _dgvData = value;
                if (_dgvData != null)
                {
                    _dgvData.ColumnHeaderMouseClick += dgvData_ColumnHeaderMouseClick;
                    _dgvData.Click += dgvData_Click;
                }
            }
        }

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _dgvData = new DataGridView();
            _dgvData.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(dgvData_ColumnHeaderMouseClick);
            _dgvData.Click += new EventHandler(dgvData_Click);
            ((System.ComponentModel.ISupportInitialize)_dgvData).BeginInit();
            SuspendLayout();
            //
            // dgvData
            //
            _dgvData.AllowUserToAddRows = false;
            _dgvData.AllowUserToDeleteRows = false;
            _dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgvData.Location = new Point(0, 0);
            _dgvData.Name = "dgvData";
            _dgvData.Size = new Size(512, 344);
            _dgvData.TabIndex = 3;
            //
            // UCDataPartsInvoiceImport
            //
            Controls.Add(_dgvData);
            Name = "UCDataPartsInvoiceImport";
            Size = new Size(512, 344);
            ((System.ComponentModel.ISupportInitialize)_dgvData).EndInit();
            ResumeLayout(false);
        }

        
        

        public object LoadedItem
        {
            get
            {
                return Data;
            }
        }

        
        
        private DataView _Data;

        public DataView Data
        {
            get
            {
                return _Data;
            }

            set
            {
                _Data = value;
                _Data.AllowNew = false;
                _Data.AllowEdit = true;
                dgvData.AutoGenerateColumns = false;
                dgvData.DataSource = Data;
            }
        }

        
        
        private DataGridViewCellStyle m_SelectedStyle = new DataGridViewCellStyle();
        private int m_SelectedRow = -1;

        public void SetupDG()
        {
            dgvData.AutoGenerateColumns = false;
            var InvoiceNo = new DataGridViewTextBoxColumn();
            InvoiceNo.HeaderText = "Invoice No";
            InvoiceNo.DataPropertyName = "InvoiceNo";
            InvoiceNo.FillWeight = 15;
            InvoiceNo.ReadOnly = true;
            InvoiceNo.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(InvoiceNo);
            var InvoiceDate = new DataGridViewTextBoxColumn();
            InvoiceDate.HeaderText = "Invoice Date";
            InvoiceDate.DataPropertyName = "InvoiceDate";
            InvoiceDate.ReadOnly = true;
            InvoiceDate.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(InvoiceDate);
            var PurchaseOrderNo = new DataGridViewTextBoxColumn();
            PurchaseOrderNo.HeaderText = "Purchase Order No";
            PurchaseOrderNo.DataPropertyName = "PurchaseOrderNo";
            PurchaseOrderNo.ReadOnly = true;
            PurchaseOrderNo.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(PurchaseOrderNo);
            var SupplierID = new DataGridViewTextBoxColumn();
            SupplierID.HeaderText = "Supplier ID";
            SupplierID.DataPropertyName = "SupplierID";
            SupplierID.Visible = false;
            SupplierID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(SupplierID);
            var SupplierPartCode = new DataGridViewTextBoxColumn();
            SupplierPartCode.HeaderText = "Supplier Part Code";
            SupplierPartCode.DataPropertyName = "SupplierPartCode";
            SupplierPartCode.ReadOnly = true;
            SupplierPartCode.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(SupplierPartCode);
            var Description = new DataGridViewTextBoxColumn();
            Description.HeaderText = "Part Description";
            Description.DataPropertyName = "Description";
            Description.Visible = true;
            Description.ReadOnly = true;
            Description.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(Description);
            var Quantities = new DataGridViewTextBoxColumn();
            Quantities.HeaderText = "Quantity Of Parts";
            Quantities.DataPropertyName = "Quantity";
            Quantities.FillWeight = 10;
            Quantities.ReadOnly = true;
            Quantities.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(Quantities);
            var UnitPrice = new DataGridViewTextBoxColumn();
            UnitPrice.HeaderText = "Unit Price";
            UnitPrice.DataPropertyName = "UnitPrice";
            UnitPrice.ReadOnly = true;
            UnitPrice.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(UnitPrice);
            var NetAmount = new DataGridViewTextBoxColumn();
            NetAmount.HeaderText = "Net Amount";
            NetAmount.DataPropertyName = "NetAmount";
            NetAmount.ReadOnly = true;
            NetAmount.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(NetAmount);
            var VATAmount = new DataGridViewTextBoxColumn();
            VATAmount.HeaderText = "VAT Amount";
            VATAmount.DataPropertyName = "VATAmount";
            VATAmount.ReadOnly = true;
            VATAmount.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(VATAmount);
            var GrossAmount = new DataGridViewTextBoxColumn();
            GrossAmount.HeaderText = "Gross Amount";
            GrossAmount.DataPropertyName = "GrossAmount";
            GrossAmount.ReadOnly = true;
            GrossAmount.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(GrossAmount);
            var TotalQtyOfParts = new DataGridViewTextBoxColumn();
            TotalQtyOfParts.HeaderText = "Total Qty Of Parts";
            TotalQtyOfParts.DataPropertyName = "TotalQtyOfParts";
            TotalQtyOfParts.ReadOnly = true;
            TotalQtyOfParts.Visible = false;
            TotalQtyOfParts.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(TotalQtyOfParts);
            var Allow = new DataGridViewCheckBoxColumn();
            Allow.FillWeight = 5;
            Allow.HeaderText = "Allow";
            Allow.DataPropertyName = "Allow";
            Allow.ReadOnly = false;
            Allow.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(Allow);
            var Update = new DataGridViewButtonColumn();
            Update.HeaderText = "Update";
            Update.DataPropertyName = "Update";
            Update.ReadOnly = true;
            Update.Visible = true;
            Update.DefaultCellStyle.NullValue = "Update";
            Update.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(Update);
            dgvData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        private void UCDataPOInvoiceAuthorisation_Load(object sender, EventArgs e)
        {
            SetupDG();
            m_SelectedStyle.BackColor = Color.LightBlue;
        }

        private void dgvData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var newColumn = dgvData.Columns[e.ColumnIndex];
            var oldColumn = dgvData.SortedColumn;
            System.ComponentModel.ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not currently sorted.
            if (oldColumn is object)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn && dgvData.SortOrder == SortOrder.Ascending)
                {
                    direction = System.ComponentModel.ListSortDirection.Descending;
                }
                else
                {
                    // Sort a new column and remove the old SortGlyph.
                    direction = System.ComponentModel.ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = System.ComponentModel.ListSortDirection.Ascending;
            }

            // Sort the selected column.
            dgvData.Sort(newColumn, direction);
            if (direction == System.ComponentModel.ListSortDirection.Ascending)
            {
                newColumn.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            }
            else
            {
                newColumn.HeaderCell.SortGlyphDirection = SortOrder.Descending;
            }
        }

        private void dgvData_Click(object sender, EventArgs ev)
        {
            MouseEventArgs e = (MouseEventArgs)ev;
            if (e.Button == MouseButtons.Left)
            {
                if (dgvData.CurrentCell is object)
                {
                    if (dgvData.CurrentCell.ColumnIndex == 13)
                    {
                        bool toBeAllowed = Conversions.ToBoolean(dgvData[12, dgvData.CurrentCell.RowIndex].Value);
                        if (toBeAllowed)
                        {
                            string invoiceNo = Conversions.ToString(dgvData[0, dgvData.CurrentCell.RowIndex].Value);
                            if (App.ShowMessage("Add " + invoiceNo + " to database?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                // insert the part into the table
                                App.DB.ImportValidation.POInvoiceImport_InsertPart(Conversions.ToString(dgvData[2, dgvData.CurrentCell.RowIndex].Value), Conversions.ToString(dgvData[4, dgvData.CurrentCell.RowIndex].Value), Conversions.ToString(dgvData[5, dgvData.CurrentCell.RowIndex].Value), Conversions.ToInteger(dgvData[6, dgvData.CurrentCell.RowIndex].Value), Conversions.ToDouble(dgvData[7, dgvData.CurrentCell.RowIndex].Value), Conversions.ToDouble(dgvData[8, dgvData.CurrentCell.RowIndex].Value), Conversions.ToDouble(dgvData[9, dgvData.CurrentCell.RowIndex].Value), Conversions.ToDouble(dgvData[10, dgvData.CurrentCell.RowIndex].Value), Conversions.ToString(dgvData[0, dgvData.CurrentCell.RowIndex].Value));
                                App.DB.ImportValidation.POInvoiceImport_UpdateOrderTotals(Conversions.ToString(dgvData[2, dgvData.CurrentCell.RowIndex].Value), Conversions.ToInteger(dgvData[6, dgvData.CurrentCell.RowIndex].Value), Conversions.ToDouble(dgvData[7, dgvData.CurrentCell.RowIndex].Value), Conversions.ToDouble(dgvData[8, dgvData.CurrentCell.RowIndex].Value), Conversions.ToDouble(dgvData[9, dgvData.CurrentCell.RowIndex].Value), Conversions.ToDouble(dgvData[10, dgvData.CurrentCell.RowIndex].Value), Conversions.ToInteger(dgvData[11, dgvData.CurrentCell.RowIndex].Value), Conversions.ToString(dgvData[0, dgvData.CurrentCell.RowIndex].Value));
                                Data.Delete(dgvData.CurrentCell.RowIndex);
                                dgvData.Refresh();
                            }
                        }
                    }
                }
            }
        }
    }
}