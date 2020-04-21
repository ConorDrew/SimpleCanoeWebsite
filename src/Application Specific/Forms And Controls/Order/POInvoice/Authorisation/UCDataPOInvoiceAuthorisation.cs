using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCDataPOInvoiceAuthorisation : UCBase
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public UCDataPOInvoiceAuthorisation() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
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
        private IContainer components;

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

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
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
            ((ISupportInitialize)_dgvData).BeginInit();
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
            ((ISupportInitialize)_dgvData).EndInit();
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

        private string _Department;

        public string Department
        {
            get
            {
                string DepartmentRet = default;
                return DepartmentRet;
            }

            set
            {
                _Department = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataGridViewCellStyle m_SelectedStyle = new DataGridViewCellStyle();
        private int m_SelectedRow = -1;

        public void SetupDG()
        {
            dgvData.AutoGenerateColumns = false;
            var InvoiceNo = new DataGridViewTextBoxColumn();
            InvoiceNo.HeaderText = "Invoice No";
            InvoiceNo.DataPropertyName = "InvoiceNo";
            InvoiceNo.Name = "InvoiceNo";
            InvoiceNo.FillWeight = 15;
            InvoiceNo.ReadOnly = true;
            InvoiceNo.Visible = true;
            InvoiceNo.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(InvoiceNo);
            var Exclude = new DataGridViewCheckBoxColumn();
            Exclude.FillWeight = 5;
            Exclude.HeaderText = "Exclude";
            Exclude.DataPropertyName = "Exclude";
            Exclude.Name = "Exclude";
            Exclude.ReadOnly = false;
            Exclude.Visible = false;
            Exclude.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(Exclude);
            var ID = new DataGridViewTextBoxColumn();
            ID.HeaderText = "ID";
            ID.DataPropertyName = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            ID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(ID);

            // Dim InvoiceNo As New DataGridViewTextBoxColumn
            // InvoiceNo.HeaderText = "Invoice No"
            // InvoiceNo.DataPropertyName = "InvoiceNo"
            // InvoiceNo.FillWeight = 15
            // InvoiceNo.ReadOnly = True
            // InvoiceNo.Visible = True
            // InvoiceNo.SortMode = DataGridViewColumnSortMode.Programmatic
            // dgvData.Columns.Add(InvoiceNo)

            var InvoiceDate = new DataGridViewTextBoxColumn();
            InvoiceDate.HeaderText = "Invoice Date";
            InvoiceDate.DataPropertyName = "InvoiceDate";
            InvoiceDate.Name = "InvoiceDate";
            // InvoiceDate.FillWeight = 15
            InvoiceDate.ReadOnly = true;
            InvoiceDate.Visible = true;
            InvoiceDate.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(InvoiceDate);
            var PurchaseOrderNo = new DataGridViewTextBoxColumn();
            PurchaseOrderNo.HeaderText = "Purchase Order No";
            PurchaseOrderNo.DataPropertyName = "PurchaseOrderNo";
            PurchaseOrderNo.Name = "PurchaseOrderNo";
            // PurchaseOrderNo.FillWeight = 20
            PurchaseOrderNo.ReadOnly = false;
            PurchaseOrderNo.Visible = true;
            PurchaseOrderNo.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(PurchaseOrderNo);
            var SupplierID = new DataGridViewTextBoxColumn();
            SupplierID.HeaderText = "Supplier ID";
            SupplierID.DataPropertyName = "SupplierID";
            SupplierID.Name = "SupplierID";
            SupplierID.ReadOnly = true;
            SupplierID.Visible = false;
            SupplierID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(SupplierID);
            var SupplierName = new DataGridViewTextBoxColumn();
            SupplierName.HeaderText = "Supplier";
            SupplierName.DataPropertyName = "SupplierName";
            SupplierName.Name = "SupplierName";
            SupplierName.ReadOnly = true;
            SupplierName.Visible = true;
            SupplierName.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(SupplierName);
            var NoOfParts = new DataGridViewTextBoxColumn();
            NoOfParts.HeaderText = "No Of Parts";
            NoOfParts.DataPropertyName = "NoOfParts";
            NoOfParts.Name = "NoOfParts";
            NoOfParts.ReadOnly = false;
            NoOfParts.Visible = false;
            NoOfParts.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(NoOfParts);
            var Quantities = new DataGridViewTextBoxColumn();
            Quantities.HeaderText = "No of Parts (total qty)";
            Quantities.DataPropertyName = "Quantities";
            Quantities.Name = "Quantities";
            Quantities.FillWeight = 10;
            Quantities.ReadOnly = false;
            Quantities.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(Quantities);
            var TotalUnitPrice = new DataGridViewTextBoxColumn();
            TotalUnitPrice.HeaderText = "Total Unit Price";
            TotalUnitPrice.DataPropertyName = "TotalUnitPrice";
            TotalUnitPrice.Name = "TotalUnitPrice";
            // TotalUnitPrice.FillWeight = 10
            TotalUnitPrice.ReadOnly = true;
            TotalUnitPrice.Visible = false;
            TotalUnitPrice.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(TotalUnitPrice);
            var PONetValue = new DataGridViewTextBoxColumn();
            PONetValue.HeaderText = "PO Net Value";
            PONetValue.DataPropertyName = "PONetValue";
            PONetValue.Name = "PONetValue";
            // TotalUnitPrice.FillWeight = 10
            PONetValue.ReadOnly = true;
            PONetValue.Visible = true;
            PONetValue.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(PONetValue);
            var PONetDifference = new DataGridViewTextBoxColumn();
            PONetDifference.HeaderText = "Net Difference (£)";
            PONetDifference.DataPropertyName = "PONetDifference";
            PONetDifference.Name = "PONetDifference";
            // TotalUnitPrice.FillWeight = 10
            PONetDifference.ReadOnly = true;
            PONetDifference.Visible = true;
            PONetDifference.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(PONetDifference);
            var TotalNetAmount = new DataGridViewTextBoxColumn();
            TotalNetAmount.HeaderText = "Invoice Net Amount";
            TotalNetAmount.DataPropertyName = "TotalNetAmount";
            TotalNetAmount.Name = "TotalNetAmount";
            // TotalNetAmount.FillWeight = 10
            TotalNetAmount.ReadOnly = true;
            TotalNetAmount.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(TotalNetAmount);
            var TotalVATAmount = new DataGridViewTextBoxColumn();
            TotalVATAmount.HeaderText = "Invoice VAT Amount";
            TotalVATAmount.DataPropertyName = "TotalVATAmount";
            TotalVATAmount.Name = "TotalVATAmount";
            // TotalVATAmount.FillWeight = 10
            TotalVATAmount.ReadOnly = true;
            TotalVATAmount.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(TotalVATAmount);
            var TotalGrossAmount = new DataGridViewTextBoxColumn();
            TotalGrossAmount.HeaderText = "Invoice Gross Amount";
            TotalGrossAmount.DataPropertyName = "TotalGrossAmount";
            TotalGrossAmount.Name = "TotalGrossAmount";
            // TotalGrossAmount.FillWeight = 10
            TotalGrossAmount.ReadOnly = true;
            TotalGrossAmount.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(TotalGrossAmount);
            var creditAmount = new DataGridViewTextBoxColumn();
            creditAmount.HeaderText = "Total Credit on Order";
            creditAmount.DataPropertyName = "CreditAmount";
            creditAmount.Name = "CreditAmount";
            // TotalGrossAmount.FillWeight = 10
            creditAmount.ReadOnly = true;
            creditAmount.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(creditAmount);
            var ValidateResult = new DataGridViewTextBoxColumn();
            ValidateResult.HeaderText = "Validate Result";
            ValidateResult.DataPropertyName = "ValidateResult";
            ValidateResult.Name = "ValidateResult";
            ValidateResult.ReadOnly = true;
            ValidateResult.Visible = false;
            ValidateResult.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(ValidateResult);
            var POOrderID = new DataGridViewTextBoxColumn();
            POOrderID.HeaderText = "POOrderID";
            POOrderID.DataPropertyName = "OrderID";
            POOrderID.Name = "OrderID";
            POOrderID.ReadOnly = true;
            POOrderID.Visible = false;
            POOrderID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(POOrderID);
            var ViewParts = new DataGridViewTextBoxColumn();
            ViewParts.HeaderText = "View Parts";
            ViewParts.DataPropertyName = "ViewParts";
            ViewParts.Name = "ViewParts";
            ViewParts.ReadOnly = true;
            ViewParts.Visible = true;
            ViewParts.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(ViewParts);
            var OrderTypeID = new DataGridViewTextBoxColumn();
            OrderTypeID.HeaderText = "OrderTypeID";
            OrderTypeID.DataPropertyName = "OrderTypeID";
            OrderTypeID.Name = "OrderTypeID";
            OrderTypeID.ReadOnly = true;
            OrderTypeID.Visible = false;
            OrderTypeID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(OrderTypeID);
            var OrderForID = new DataGridViewTextBoxColumn();
            OrderForID.HeaderText = "OrderForID";
            OrderForID.DataPropertyName = "OrderForID";
            OrderForID.Name = "OrderForID";
            OrderForID.ReadOnly = true;
            OrderForID.Visible = false;
            OrderForID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(OrderForID);
            var ViewOrder = new DataGridViewTextBoxColumn();
            ViewOrder.HeaderText = "View Order";
            ViewOrder.DataPropertyName = "ViewOrder";
            ViewOrder.Name = "ViewOrder";
            ViewOrder.ReadOnly = true;
            ViewOrder.Visible = true;
            ViewOrder.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(ViewOrder);
            var Authorise = new DataGridViewTextBoxColumn();
            Authorise.HeaderText = "Authorise";
            Authorise.DataPropertyName = "Authorise";
            Authorise.Name = "Authorise";
            Authorise.ReadOnly = true;
            Authorise.Visible = true;
            Authorise.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(Authorise);
            var PODepartment = new DataGridViewTextBoxColumn();
            PODepartment.HeaderText = "Department";
            PODepartment.DataPropertyName = "PODepartment";
            PODepartment.Name = "PODepartment";
            PODepartment.FillWeight = 15;
            PODepartment.ReadOnly = true;
            PODepartment.Visible = true;
            PODepartment.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(PODepartment);
            dgvData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        private void UCDataPOInvoiceAuthorisation_Load(object sender, EventArgs e)
        {
            SetupDG();
            m_SelectedStyle.BackColor = Color.LightBlue;
        }

        private void dgvData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var newColumn = dgvData.Columns[e.ColumnIndex];
                var oldColumn = dgvData.SortedColumn;
                ListSortDirection direction;

                // If oldColumn is null, then the DataGridView is not currently sorted.
                if (oldColumn is object)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn && dgvData.SortOrder == SortOrder.Ascending)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    else
                    {
                        // Sort a new column and remove the old SortGlyph.
                        direction = ListSortDirection.Ascending;
                        oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                    }
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                }

                // Sort the selected column.

                if (newColumn.ValueType is object)
                {
                    dgvData.Sort(newColumn, direction);
                    if (direction == ListSortDirection.Ascending)
                    {
                        newColumn.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                    }
                    else
                    {
                        newColumn.HeaderCell.SortGlyphDirection = SortOrder.Descending;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void dgvData_Click(object sender, EventArgs ev)
        {
            MouseEventArgs e = (MouseEventArgs)ev;
            try
            {
                int columnIndex = 0;
                if (dgvData is object && dgvData.CurrentCell is object)
                {
                    columnIndex = dgvData.CurrentCell.ColumnIndex;
                }

                if (columnIndex > 0)
                {
                    string columnName = dgvData.Columns[columnIndex].Name;
                    if (e.Button == MouseButtons.Left)
                    {
                        var switchExpr = columnName.ToLower();
                        switch (switchExpr)
                        {
                            case "viewparts":
                                {
                                    FRMPOInvoiceIncludedItems dialogue;
                                    dialogue = (FRMPOInvoiceIncludedItems)App.checkIfExists(typeof(FRMPOInvoiceIncludedItems).Name, true);
                                    if (dialogue is null)
                                    {
                                        dialogue = (FRMPOInvoiceIncludedItems)Activator.CreateInstance(typeof(FRMPOInvoiceIncludedItems));
                                    }

                                    dialogue.ShowInTaskbar = false;
                                    int poNoIndex = dgvData.Columns.IndexOf(dgvData.Columns["PurchaseOrderNo"]);
                                    dialogue.POToShow = Conversions.ToString(dgvData[poNoIndex, dgvData.CurrentCell.RowIndex].Value);
                                    int invoiceIndex = dgvData.Columns.IndexOf(dgvData.Columns["InvoiceNo"]);
                                    dialogue.InvoiceNo = Conversions.ToString(dgvData[invoiceIndex, dgvData.CurrentCell.RowIndex].Value);
                                    dialogue.ShowDialog();
                                    if (dialogue.DialogResult == DialogResult.OK)
                                    {
                                        if (string.IsNullOrEmpty(_Department))
                                        {
                                            Data = App.DB.POInvoice.POInvoiceImport_RefreshData(Conversions.ToInteger(_ValidateType), "%");
                                        }
                                        else
                                        {
                                            Data = App.DB.POInvoice.POInvoiceImport_RefreshData(Conversions.ToInteger(_ValidateType), _Department);
                                        }
                                    }
                                    else if (string.IsNullOrEmpty(_Department))
                                    {
                                        Data = App.DB.POInvoice.POInvoiceImport_RefreshData(Conversions.ToInteger(_ValidateType), "%");
                                    }
                                    else
                                    {
                                        Data = App.DB.POInvoice.POInvoiceImport_RefreshData(Conversions.ToInteger(_ValidateType), _Department);
                                    }

                                    dialogue.Close();
                                    break;
                                }

                            case "vieworder":
                                {
                                    int orderIdIndex = dgvData.Columns.IndexOf(dgvData.Columns["OrderID"]);
                                    int orderForIdIndex = dgvData.Columns.IndexOf(dgvData.Columns["OrderForID"]);
                                    if (!(dgvData[orderIdIndex, dgvData.CurrentCell.RowIndex].Value == DBNull.Value))
                                    {
                                        App.ShowForm(typeof(FRMOrder), true, new object[] { dgvData[orderIdIndex, dgvData.CurrentCell.RowIndex].Value, dgvData[orderForIdIndex, dgvData.CurrentCell.RowIndex].Value, 0, this, true });
                                    }

                                    break;
                                }

                            case "authorise":
                                {
                                    int idIndex = dgvData.Columns.IndexOf(dgvData.Columns["ID"]);
                                    int id = Conversions.ToInteger(dgvData[idIndex, dgvData.CurrentCell.RowIndex].Value);
                                    FRMPOInvoiceAuthReasons dialogue;
                                    dialogue = (FRMPOInvoiceAuthReasons)App.checkIfExists(typeof(FRMPOInvoiceAuthReasons).Name, true);
                                    if (dialogue is null)
                                    {
                                        dialogue = (FRMPOInvoiceAuthReasons)Activator.CreateInstance(typeof(FRMPOInvoiceAuthReasons));
                                    }

                                    dialogue.ShowInTaskbar = false;
                                    dialogue.AuthReason = null;
                                    dialogue.AuthReasonDetail = null;
                                    dialogue.ShowDialog();
                                    if (dialogue.DialogResult == DialogResult.OK)
                                    {
                                        string NewAuthReason = string.Empty;
                                        if (dialogue._AuthReason is object)
                                        {
                                            NewAuthReason = dialogue._AuthReason;
                                        }

                                        string NewAuthReasonDetail = string.Empty;
                                        if (dialogue._AuthReasonDetail is object)
                                        {
                                            NewAuthReasonDetail = dialogue._AuthReasonDetail;
                                        }

                                        int sortedColumn = dgvData.SortedColumn is null ? 0 : dgvData.SortedColumn.Index;
                                        var sortedDirection = dgvData.SortOrder;
                                        App.DB.POInvoice.POInvoiceImport_UpdateAuthorised(id, true, App.loggedInUser.UserID, DateAndTime.Now, NewAuthReason, NewAuthReasonDetail);
                                        if (string.IsNullOrEmpty(_Department))
                                        {
                                            Data = App.DB.POInvoice.POInvoiceImport_RefreshData(Conversions.ToInteger(_ValidateType), "%");
                                        }
                                        else
                                        {
                                            Data = App.DB.POInvoice.POInvoiceImport_RefreshData(Conversions.ToInteger(_ValidateType), _Department);
                                        }

                                        try
                                        {
                                            switch (sortedDirection)
                                            {
                                                case SortOrder.Ascending:
                                                    {
                                                        dgvData.Sort(dgvData.Columns[sortedColumn], ListSortDirection.Ascending);
                                                        break;
                                                    }

                                                case SortOrder.Descending:
                                                    {
                                                        dgvData.Sort(dgvData.Columns[sortedColumn], ListSortDirection.Descending);
                                                        break;
                                                    }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }
                                    else
                                    {
                                    }

                                    dialogue.Close();
                                    break;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}