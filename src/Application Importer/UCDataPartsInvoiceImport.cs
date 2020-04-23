using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCDataPartsInvoiceImport : UCBase
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public UCDataPartsInvoiceImport() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCData_Load;

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
                    _dgvData.CellMouseDoubleClick -= dgvData_CellMouseDoubleClick;
                    _dgvData.CellValueChanged -= dgvData_CellValueChanged;
                    _dgvData.CellEndEdit -= dgvData_RowLeave;
                    _dgvData.ColumnHeaderMouseClick -= dgvData_ColumnHeaderMouseClick;

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    _dgvData.Click -= dgvData_Click;
                }

                _dgvData = value;
                if (_dgvData != null)
                {
                    _dgvData.CellMouseDoubleClick += dgvData_CellMouseDoubleClick;
                    _dgvData.CellValueChanged += dgvData_CellValueChanged;
                    _dgvData.CellEndEdit += dgvData_RowLeave;
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
            _dgvData.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvData_CellMouseDoubleClick);
            _dgvData.CellValueChanged += new DataGridViewCellEventHandler(dgvData_CellValueChanged);
            _dgvData.CellEndEdit += new DataGridViewCellEventHandler(dgvData_RowLeave);
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public object LoadedItem
        {
            get
            {
                return Data;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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
                _Data.AllowDelete = false;
                dgvData.AutoGenerateColumns = false;
                dgvData.DataSource = Data;
            }
        }

        private string _ValidateType;

        public string ValidateType
        {
            get
            {
                string ValidateTypeRet = default;
                return ValidateTypeRet;
            }

            set
            {
                _ValidateType = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataGridViewCellStyle m_SelectedStyle = new DataGridViewCellStyle();
        private int m_SelectedRow = -1;

        public void SetupDG()
        {
            var Exclude = new DataGridViewCheckBoxColumn(); // 0
            Exclude.FillWeight = 5;
            Exclude.HeaderText = "Exclude";
            Exclude.DataPropertyName = "Exclude";
            Exclude.ReadOnly = false;
            Exclude.Visible = false;
            Exclude.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(Exclude);
            var RequiresAuth = new DataGridViewCheckBoxColumn(); // 1
            RequiresAuth.FillWeight = 5;
            RequiresAuth.HeaderText = "Requires Auth";
            RequiresAuth.DataPropertyName = "RequiresAuthorisation";
            RequiresAuth.ReadOnly = false;
            RequiresAuth.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(RequiresAuth);
            var ID = new DataGridViewTextBoxColumn(); // 2
            ID.HeaderText = "ID";
            ID.DataPropertyName = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            ID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(ID);
            var InvoiceNo = new DataGridViewTextBoxColumn(); // 3
            InvoiceNo.HeaderText = "Invoice No";
            InvoiceNo.DataPropertyName = "InvoiceNo";
            InvoiceNo.FillWeight = 15;
            InvoiceNo.ReadOnly = true;
            InvoiceNo.Visible = true;
            InvoiceNo.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(InvoiceNo);
            var InvoiceDate = new DataGridViewTextBoxColumn(); // 4
            InvoiceDate.HeaderText = "Invoice Date";
            InvoiceDate.DataPropertyName = "InvoiceDate";
            InvoiceDate.ReadOnly = true;
            InvoiceDate.Visible = true;
            InvoiceDate.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(InvoiceDate);
            var PurchaseOrderNo = new DataGridViewTextBoxColumn(); // 5
            PurchaseOrderNo.HeaderText = "Purchase Order No";
            PurchaseOrderNo.DataPropertyName = "PurchaseOrderNo";
            PurchaseOrderNo.ReadOnly = false;
            PurchaseOrderNo.Visible = true;
            PurchaseOrderNo.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(PurchaseOrderNo);
            var invoSup = new DataGridViewTextBoxColumn(); // 6
            invoSup.HeaderText = "Inv Supp";
            invoSup.DataPropertyName = "SupplierName";
            invoSup.ReadOnly = true;
            invoSup.Visible = true;
            invoSup.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(invoSup);
            var poSupp = new DataGridViewTextBoxColumn(); // 7
            poSupp.HeaderText = "PO Supp";
            poSupp.DataPropertyName = "POSupp";
            poSupp.ReadOnly = true;
            poSupp.Visible = true;
            poSupp.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(poSupp);
            var PONetValue = new DataGridViewTextBoxColumn(); // 8
            PONetValue.HeaderText = "PO Net Value";
            PONetValue.DataPropertyName = "PONetValue";
            PONetValue.ReadOnly = true;
            PONetValue.Visible = true;
            PONetValue.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(PONetValue);
            var PONetDifference = new DataGridViewTextBoxColumn(); // 9
            PONetDifference.HeaderText = "Net Difference (£)";
            PONetDifference.DataPropertyName = "PONetDifference";
            PONetDifference.ReadOnly = true;
            PONetDifference.Visible = true;
            PONetDifference.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(PONetDifference);
            var TotalNetAmount = new DataGridViewTextBoxColumn(); // 10
            TotalNetAmount.HeaderText = "Invoice Net Amount";
            TotalNetAmount.DataPropertyName = "TotalNetAmount";
            TotalNetAmount.ReadOnly = true;
            TotalNetAmount.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(TotalNetAmount);
            var TotalVATAmount = new DataGridViewTextBoxColumn(); // 11
            TotalVATAmount.HeaderText = "Invoice VAT Amount";
            TotalVATAmount.DataPropertyName = "TotalVATAmount";
            TotalVATAmount.ReadOnly = true;
            TotalVATAmount.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(TotalVATAmount);
            var TotalGrossAmount = new DataGridViewTextBoxColumn(); // 12
            TotalGrossAmount.HeaderText = "Invoice Gross Amount";
            TotalGrossAmount.DataPropertyName = "TotalGrossAmount";
            TotalGrossAmount.ReadOnly = true;
            TotalGrossAmount.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(TotalGrossAmount);
            var ViewParts = new DataGridViewTextBoxColumn(); // 13
            ViewParts.HeaderText = "View Parts";
            ViewParts.DataPropertyName = "ViewParts";
            ViewParts.ReadOnly = true;
            ViewParts.Visible = true;
            ViewParts.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(ViewParts);
            var ViewOrder = new DataGridViewTextBoxColumn(); // 14
            ViewOrder.HeaderText = "View Order";
            ViewOrder.DataPropertyName = "ViewOrder";
            ViewOrder.ReadOnly = true;
            ViewOrder.Visible = true;
            ViewOrder.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(ViewOrder);
            var updateSupplier = new DataGridViewCheckBoxColumn(); // 15
            updateSupplier.FillWeight = 5;
            updateSupplier.HeaderText = "Update Supplier";
            updateSupplier.DataPropertyName = "EditOrder";
            updateSupplier.ReadOnly = false;
            updateSupplier.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(updateSupplier);
            var Delete = new DataGridViewCheckBoxColumn(); // 16
            Delete.FillWeight = 5;
            Delete.HeaderText = "Delete";
            Delete.DataPropertyName = "Delete";
            Delete.ReadOnly = false;
            Delete.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(Delete);
            var POOrderID = new DataGridViewTextBoxColumn(); // 17
            POOrderID.HeaderText = "POOrderID";
            POOrderID.DataPropertyName = "OrderID";
            POOrderID.ReadOnly = true;
            POOrderID.Visible = false;
            POOrderID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(POOrderID);
            var OrderForID = new DataGridViewTextBoxColumn(); // 18
            OrderForID.HeaderText = "OrderForID";
            OrderForID.DataPropertyName = "OrderForID";
            OrderForID.ReadOnly = true;
            OrderForID.Visible = false;
            OrderForID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(OrderForID);
            var ValidateResult = new DataGridViewTextBoxColumn(); // 19
            ValidateResult.HeaderText = "Validate Result";
            ValidateResult.DataPropertyName = "ValidateResult";
            ValidateResult.ReadOnly = true;
            ValidateResult.Visible = false;
            ValidateResult.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(ValidateResult);
            var SupplierID = new DataGridViewTextBoxColumn(); // 20
            SupplierID.HeaderText = "Supplier ID";
            SupplierID.DataPropertyName = "SupplierID";
            SupplierID.ReadOnly = true;
            SupplierID.Visible = false;
            SupplierID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(SupplierID);
            dgvData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        private void UCData_Load(object sender, EventArgs e)
        {
            SetupDG();
            m_SelectedStyle.BackColor = Color.LightBlue;
        }

        private void dgvData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = e.Clicks;
        }

        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var switchExpr = e.ColumnIndex;
            switch (switchExpr)
            {
                case 5:
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        int ImportID = Conversions.ToInteger(dgvData[2, e.RowIndex].Value);
                        string PurchaseOrderNo = Conversions.ToString(dgvData[5, e.RowIndex].Value);
                        App.DB.ImportValidation.POInvoiceImport_UpdatePurchaseOrderNoAndValidate(ImportID, PurchaseOrderNo);
                        Cursor.Current = Cursors.Default;
                        break;
                    }
            }
        }

        private void dgvData_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            int ID = Conversions.ToInteger(dgvData[2, e.RowIndex].Value);
            bool RequiresAuth = Conversions.ToBoolean(dgvData.Rows[e.RowIndex].Cells[1].Value);
            double PONetDiff = 0.0;
            if (string.IsNullOrEmpty(dgvData.Rows[e.RowIndex].Cells[8].Value.ToString()))
            {
            }
            else
            {
                PONetDiff = Conversions.ToDouble(dgvData.Rows[e.RowIndex].Cells[8].Value);
            }

            if (RequiresAuth == true & !(PONetDiff == 0.0))
            {
                App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(ID, RequiresAuth);
            }
            else if (RequiresAuth == false)
            {
                App.DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(ID, RequiresAuth);
            }
            else
            {
            }

            bool updateSupplier = Conversions.ToBoolean(dgvData.Rows[e.RowIndex].Cells[15].Value);
            int validationResult = Conversions.ToInteger(dgvData.Rows[e.RowIndex].Cells[19].Value);
            if (updateSupplier & validationResult == Conversions.ToInteger(Entity.Sys.Enums.PartsInvoiceImportValidationResults.SuppliersDoNotMatch))
            {
                int orderId = Conversions.ToInteger(dgvData[17, dgvData.CurrentCell.RowIndex].Value);
                int supplierId = Conversions.ToInteger(dgvData[20, dgvData.CurrentCell.RowIndex].Value);
                App.DB.ImportValidation.Order_UpdateSupplier(orderId, supplierId);
            }

            if ((App.loggedInUser.Fullname ?? "") == "Jane Lockett")
            {
                bool ToBeDeleted = Conversions.ToBoolean(dgvData.Rows[e.RowIndex].Cells[16].Value);
                App.DB.ImportValidation.POInvoiceImport_UpdateDelete(ID, ToBeDeleted);
            }
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
                    var switchExpr = dgvData.CurrentCell.ColumnIndex;
                    switch (switchExpr)
                    {
                        case 0:
                            {
                                int ID = Conversions.ToInteger(dgvData[2, dgvData.CurrentCell.RowIndex].Value);
                                DataGridViewCheckBoxCell chkExcluded = (DataGridViewCheckBoxCell)dgvData.CurrentCell;
                                bool exclude = Conversions.ToBoolean(chkExcluded.EditingCellFormattedValue) ? false : true;
                                App.DB.ImportValidation.POInvoiceImport_UpdateExclude(ID, exclude);
                                break;
                            }

                        case 13:
                            {
                                FRMPOInvoiceIncludedItems dialogue;
                                dialogue = (FRMPOInvoiceIncludedItems)App.checkIfExists(typeof(FRMPOInvoiceIncludedItems).Name, true);
                                if (dialogue is null)
                                {
                                    dialogue = (FRMPOInvoiceIncludedItems)Activator.CreateInstance(typeof(FRMPOInvoiceIncludedItems));
                                }

                                //dialogue.Icon = new Icon(dialogue.GetType(), "Logo.ico");
                                dialogue.ShowInTaskbar = false;
                                dialogue.POToShow = Conversions.ToString(dgvData[5, dgvData.CurrentCell.RowIndex].Value);
                                dialogue.InvoiceNo = Conversions.ToString(dgvData[3, dgvData.CurrentCell.RowIndex].Value);
                                dialogue.ShowDialog();
                                if (dialogue.DialogResult == DialogResult.OK)
                                {
                                    My.MyProject.Forms.FRMPartsInvoiceImport.ShowData(Conversions.ToInteger(_ValidateType));
                                }
                                else
                                {
                                }

                                dialogue.Close();
                                break;
                            }

                        case 14:
                            {
                                if (!(dgvData[17, dgvData.CurrentCell.RowIndex].Value == DBNull.Value))
                                {
                                    App.ShowForm(typeof(FRMOrder), true, new object[] { dgvData[17, dgvData.CurrentCell.RowIndex].Value, dgvData[18, dgvData.CurrentCell.RowIndex].Value, 0, this, true });
                                }

                                break;
                            }
                    }
                }
            }
        }
    }
}