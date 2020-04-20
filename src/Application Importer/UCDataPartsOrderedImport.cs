using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCDataPartsOrderedImport : UCBase
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCDataPartsOrderedImport() : base()
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
                }

                _dgvData = value;
                if (_dgvData != null)
                {
                    _dgvData.CellMouseDoubleClick += dgvData_CellMouseDoubleClick;
                    _dgvData.CellValueChanged += dgvData_CellValueChanged;
                    _dgvData.CellEndEdit += dgvData_RowLeave;
                    _dgvData.ColumnHeaderMouseClick += dgvData_ColumnHeaderMouseClick;
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
            var Exclude = new DataGridViewCheckBoxColumn();
            Exclude.FillWeight = 5;
            Exclude.HeaderText = "Exclude";
            Exclude.DataPropertyName = "Exclude";
            Exclude.ReadOnly = false;
            Exclude.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(Exclude);

            // Dim RequiresAuth As New DataGridViewCheckBoxColumn
            // RequiresAuth.FillWeight = 5
            // RequiresAuth.HeaderText = "Requires Auth"
            // RequiresAuth.DataPropertyName = "RequiresAuthorisation"
            // RequiresAuth.ReadOnly = False
            // RequiresAuth.SortMode = DataGridViewColumnSortMode.Programmatic
            // dgvData.Columns.Add(RequiresAuth)

            var ID = new DataGridViewTextBoxColumn();
            ID.HeaderText = "ID";
            ID.DataPropertyName = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            ID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(ID);
            var SupplierOrderNumber = new DataGridViewTextBoxColumn();
            SupplierOrderNumber.HeaderText = "Supplier Order Number";
            SupplierOrderNumber.DataPropertyName = "SupplierOrderNumber";
            SupplierOrderNumber.FillWeight = 15;
            SupplierOrderNumber.ReadOnly = true;
            SupplierOrderNumber.Visible = true;
            SupplierOrderNumber.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(SupplierOrderNumber);
            var OrderDate = new DataGridViewTextBoxColumn();
            OrderDate.HeaderText = "Order Date";
            OrderDate.DataPropertyName = "OrderDate";
            // InvoiceDate.FillWeight = 15
            OrderDate.ReadOnly = true;
            OrderDate.Visible = true;
            OrderDate.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(OrderDate);
            var PurchaseOrderNumber = new DataGridViewTextBoxColumn();
            PurchaseOrderNumber.HeaderText = "Purchase Order Number";
            PurchaseOrderNumber.DataPropertyName = "PurchaseOrderNumber";
            // PurchaseOrderNo.FillWeight = 20
            PurchaseOrderNumber.ReadOnly = false;
            PurchaseOrderNumber.Visible = true;
            PurchaseOrderNumber.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(PurchaseOrderNumber);
            var SupplierPartCode = new DataGridViewTextBoxColumn();
            SupplierPartCode.HeaderText = "Supplier PartCode";
            SupplierPartCode.DataPropertyName = "SupplierPartCode";
            SupplierPartCode.ReadOnly = false;
            SupplierPartCode.Visible = true;
            SupplierPartCode.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(SupplierPartCode);
            var Description = new DataGridViewTextBoxColumn();
            Description.HeaderText = "Description";
            Description.DataPropertyName = "Description";
            Description.ReadOnly = true;
            Description.Visible = true;
            Description.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(Description);
            var Quantity = new DataGridViewTextBoxColumn();
            Quantity.HeaderText = "Quantity";
            Quantity.DataPropertyName = "Quantity";
            Quantity.ReadOnly = true;
            Quantity.Visible = true;
            Quantity.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(Quantity);
            var SupplierID = new DataGridViewTextBoxColumn();
            SupplierID.HeaderText = "SupplierID";
            SupplierID.DataPropertyName = "SupplierID";
            SupplierID.FillWeight = 10;
            SupplierID.ReadOnly = true;
            SupplierID.Visible = false;
            SupplierID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(SupplierID);
            var SupplierName = new DataGridViewTextBoxColumn();
            SupplierName.HeaderText = "Supplier";
            SupplierName.DataPropertyName = "SupplierName";
            SupplierName.FillWeight = 10;
            SupplierName.ReadOnly = true;
            SupplierName.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(SupplierName);
            var Delete = new DataGridViewCheckBoxColumn();
            Delete.FillWeight = 5;
            Delete.HeaderText = "Delete";
            Delete.DataPropertyName = "Delete";
            Delete.ReadOnly = false;
            Delete.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(Delete);
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
                case 4:
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        int ImportID = Conversions.ToInteger(dgvData[1, e.RowIndex].Value);
                        string PurchaseOrderNo = Conversions.ToString(dgvData[4, e.RowIndex].Value);
                        App.DB.ImportValidation.PartsOrderedImport_UpdatePurchaseOrderNumber(ImportID, PurchaseOrderNo);
                        Cursor.Current = Cursors.Default;
                        break;
                    }

                case 5:
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        int ImportID = Conversions.ToInteger(dgvData[1, e.RowIndex].Value);
                        string SupplierPartCode = Conversions.ToString(dgvData[5, e.RowIndex].Value);
                        App.DB.ImportValidation.PartsOrderedImport_UpdateSupplierPartCode(ImportID, SupplierPartCode);
                        Cursor.Current = Cursors.Default;
                        break;
                    }
            }
        }

        private void dgvData_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            int ID = Conversions.ToInteger(dgvData[1, e.RowIndex].Value);
            bool Exclude = Conversions.ToBoolean(dgvData.Rows[e.RowIndex].Cells[0].Value);
            App.DB.ImportValidation.PartsOrderedImport_UpdateExclude(ID, Exclude);
            // Dim RequiresAuth As Boolean = CBool(dgvData.Rows(e.RowIndex).Cells(1).Value)
            // DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(ID, RequiresAuth)

            if ((App.loggedInUser.Fullname ?? "") == "Jane Lockett")
            {
                bool ToBeDeleted = Conversions.ToBoolean(dgvData.Rows[e.RowIndex].Cells[10].Value);
                App.DB.ImportValidation.PartsOrderedImport_UpdateDelete(ID, ToBeDeleted);
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        // Private Sub dgvData_Click(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvData.Click

        // If e.Button =MouseButtons.Left Then
        // If dgvData.CurrentCell.ColumnIndex = 18 Then
        // Dim dialogue As FRMPOInvoiceIncludedItems
        // dialogue = checkIfExists(GetType(FRMPOInvoiceIncludedItems).Name, True)
        // If dialogue Is Nothing Then
        // dialogue = Activator.CreateInstance(GetType(FRMPOInvoiceIncludedItems))
        // End If
        // dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
        // dialogue.ShowInTaskbar = False
        // dialogue.POToShow = dgvData.Item(5, dgvData.CurrentCell.RowIndex).Value
        // dialogue.InvoiceNo = dgvData.Item(3, dgvData.CurrentCell.RowIndex).Value
        // dialogue.ShowDialog()

        // If dialogue.DialogResult = DialogResult.OK Then
        // FRMPartsInvoiceImport.ShowData(_ValidateType)
        // Else
        // End If
        // dialogue.Close()
        // ElseIf dgvData.CurrentCell.ColumnIndex = 21 Then

        // If Not dgvData.Item(17, dgvData.CurrentCell.RowIndex).Value Is DBNull.Value Then
        // ShowForm(GetType(FRMOrder), True, New Object() {dgvData.Item(17, dgvData.CurrentCell.RowIndex).Value, dgvData.Item(20, dgvData.CurrentCell.RowIndex).Value, 0, Me, True})
        // End If


        // End If

        // End If
        // End Sub
    }
}