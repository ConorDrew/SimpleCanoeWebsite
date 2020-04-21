using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCData : UCBase
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public UCData() : base()
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
                    _dgvData.DoubleClick -= dgData_Click;
                    _dgvData.CellMouseUp -= dgData_CellMouseUp;
                    _dgvData.CellEndEdit -= dgvData_RowLeave;
                    _dgvData.SelectionChanged -= DataGridView1_SelectionChanged;
                    _dgvData.ColumnHeaderMouseClick -= dgvData_ColumnHeaderMouseClick;
                    _dgvData.RowLeave -= dgvData_RowLeave1;
                }

                _dgvData = value;
                if (_dgvData != null)
                {
                    _dgvData.DoubleClick += dgData_Click;
                    _dgvData.CellMouseUp += dgData_CellMouseUp;
                    _dgvData.CellEndEdit += dgvData_RowLeave;
                    _dgvData.SelectionChanged += DataGridView1_SelectionChanged;
                    _dgvData.ColumnHeaderMouseClick += dgvData_ColumnHeaderMouseClick;
                    _dgvData.RowLeave += dgvData_RowLeave1;
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
            _dgvData.DoubleClick += new EventHandler(dgData_Click);
            _dgvData.CellMouseUp += new DataGridViewCellMouseEventHandler(dgData_CellMouseUp);
            _dgvData.CellEndEdit += new DataGridViewCellEventHandler(dgvData_RowLeave);
            _dgvData.SelectionChanged += new EventHandler(DataGridView1_SelectionChanged);
            _dgvData.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(dgvData_ColumnHeaderMouseClick);
            _dgvData.RowLeave += new DataGridViewCellEventHandler(dgvData_RowLeave1);
            ((System.ComponentModel.ISupportInitialize)_dgvData).BeginInit();
            SuspendLayout();
            //
            // dgvData
            //
            _dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgvData.Location = new Point(0, 0);
            _dgvData.Name = "dgvData";
            _dgvData.Size = new Size(512, 344);
            _dgvData.TabIndex = 3;
            //
            // UCData
            //
            Controls.Add(_dgvData);
            Name = "UCData";
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataGridViewCellStyle m_SelectedStyle = new DataGridViewCellStyle();
        private int m_SelectedRow = -1;

        public void SetupDG()
        {
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var Exclude = new DataGridViewCheckBoxColumn();
            Exclude.FillWeight = 25;
            Exclude.HeaderText = "Exclude";
            Exclude.DataPropertyName = "Exclude";
            Exclude.ReadOnly = false;
            Exclude.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(Exclude);
            var ForceInsert = new DataGridViewCheckBoxColumn();
            ForceInsert.FillWeight = 25;
            ForceInsert.HeaderText = "Force Insert";
            ForceInsert.DataPropertyName = "ForceInsert";
            ForceInsert.ReadOnly = false;
            ForceInsert.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(ForceInsert);
            var ImportID = new DataGridViewTextBoxColumn();
            ImportID.HeaderText = "Import ID";
            ImportID.DataPropertyName = "ImportID";
            ImportID.ReadOnly = true;
            ImportID.Visible = false;
            ImportID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(ImportID);
            var PartID = new DataGridViewTextBoxColumn();
            PartID.HeaderText = "Part ID";
            PartID.DataPropertyName = "PartID";
            PartID.ReadOnly = true;
            PartID.Visible = false;
            PartID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(PartID);
            var ImportPrice = new DataGridViewTextBoxColumn();
            ImportPrice.FillWeight = 35;
            ImportPrice.HeaderText = "Import Price";
            ImportPrice.DataPropertyName = "Import Price";
            ImportPrice.ReadOnly = false;
            ImportPrice.SortMode = DataGridViewColumnSortMode.Programmatic;
            ImportPrice.DefaultCellStyle.Format = "N3";
            dgvData.Columns.Add(ImportPrice);
            var ExistingPrice = new DataGridViewTextBoxColumn();
            ExistingPrice.FillWeight = 35;
            ExistingPrice.HeaderText = "Existing Price";
            ExistingPrice.DataPropertyName = "Existing Price";
            ExistingPrice.DefaultCellStyle.Format = "N3";
            ExistingPrice.ReadOnly = true;
            ExistingPrice.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(ExistingPrice);
            var PercentDifference = new DataGridViewTextBoxColumn();
            PercentDifference.FillWeight = 35;
            PercentDifference.HeaderText = "Percent Difference";
            PercentDifference.DataPropertyName = "PercentDifference";
            PercentDifference.DefaultCellStyle.Format = @"0.00\%";
            PercentDifference.ReadOnly = true;
            PercentDifference.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(PercentDifference);
            var ImportSecondaryPrice = new DataGridViewTextBoxColumn();
            ImportSecondaryPrice.FillWeight = 35;
            ImportSecondaryPrice.HeaderText = "Import Secondary Price";
            ImportSecondaryPrice.DataPropertyName = "Import Secondary Price";
            ImportSecondaryPrice.ReadOnly = false;
            ImportSecondaryPrice.DefaultCellStyle.Format = "N3";
            ImportSecondaryPrice.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(ImportSecondaryPrice);
            var ExistingSecondaryPrice = new DataGridViewTextBoxColumn();
            ExistingSecondaryPrice.FillWeight = 35;
            ExistingSecondaryPrice.HeaderText = "Existing Secondary Price";
            ExistingSecondaryPrice.DataPropertyName = "Existing Secondary Price";
            ExistingSecondaryPrice.ReadOnly = true;
            ExistingSecondaryPrice.DefaultCellStyle.Format = "N3";
            ExistingSecondaryPrice.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(ExistingSecondaryPrice);
            var PercentDifferenceSecondary = new DataGridViewTextBoxColumn();
            PercentDifferenceSecondary.FillWeight = 35;
            PercentDifferenceSecondary.HeaderText = "Secondary Percent Difference";
            PercentDifferenceSecondary.DataPropertyName = "SecondaryPercentDifference";
            PercentDifferenceSecondary.DefaultCellStyle.Format = @"0.00\%";
            PercentDifferenceSecondary.ReadOnly = true;
            PercentDifferenceSecondary.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(PercentDifferenceSecondary);
            var ImportDesc = new DataGridViewTextBoxColumn();
            ImportDesc.FillWeight = 200;
            ImportDesc.HeaderText = "Import Description";
            ImportDesc.DataPropertyName = "Import Desc";
            ImportDesc.ReadOnly = false;
            ImportDesc.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(ImportDesc);
            var ExistingDesc = new DataGridViewTextBoxColumn();
            ExistingDesc.FillWeight = 200;
            ExistingDesc.HeaderText = "Existing Description";
            ExistingDesc.DataPropertyName = "Existing Desc";
            ExistingDesc.ReadOnly = true;
            ExistingDesc.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(ExistingDesc);
            var ImportPartCode = new DataGridViewTextBoxColumn();
            ImportPartCode.FillWeight = 75;
            ImportPartCode.HeaderText = "Import MPN";
            ImportPartCode.DataPropertyName = "Import PC";
            ImportPartCode.ReadOnly = true;
            ImportPartCode.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(ImportPartCode);
            var ExistingPartCode = new DataGridViewTextBoxColumn();
            ExistingPartCode.FillWeight = 75;
            ExistingPartCode.HeaderText = "Existing MPN";
            ExistingPartCode.DataPropertyName = "Existing PC";
            ExistingPartCode.ReadOnly = true;
            ExistingPartCode.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(ExistingPartCode);
            var ImportSPC = new DataGridViewTextBoxColumn();
            ImportSPC.FillWeight = 75;
            ImportSPC.HeaderText = "Import SPN";
            ImportSPC.DataPropertyName = "Import SPC";
            ImportSPC.ReadOnly = false;
            ImportSPC.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(ImportSPC);
            var ExistingSPC = new DataGridViewTextBoxColumn();
            ExistingSPC.FillWeight = 75;
            ExistingSPC.HeaderText = "Existing SPN";
            ExistingSPC.DataPropertyName = "Existing SPC";
            ExistingSPC.ReadOnly = false;
            ExistingSPC.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(ExistingSPC);
            var Supplier = new DataGridViewTextBoxColumn();
            Supplier.FillWeight = 100;
            Supplier.HeaderText = "Supplier Name";
            Supplier.DataPropertyName = "Supplier Name";
            Supplier.ReadOnly = true;
            Supplier.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(Supplier);
            var Category = new DataGridViewTextBoxColumn();
            Category.FillWeight = 100;
            Category.HeaderText = "Category";
            Category.DataPropertyName = "Category";
            Category.Name = "Category";
            Category.ReadOnly = true;
            Category.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(Category);
            var SwapSPN = new DataGridViewCheckBoxColumn();
            SwapSPN.FillWeight = 25;
            SwapSPN.HeaderText = "Swap SPN";
            SwapSPN.DataPropertyName = "SwapSPN";
            SwapSPN.Name = "SwapSPN";
            SwapSPN.ReadOnly = false;
            PartID.Visible = false;
            dgvData.Columns.Add(SwapSPN);
        }

        private void UCData_Load(object sender, EventArgs e)
        {
            m_SelectedStyle.BackColor = Color.LightBlue;
        }

        private void dgData_Click(object sender, EventArgs e)
        {
            int PartID = Conversions.ToInteger(dgvData[3, dgvData.CurrentCell.RowIndex].Value);
            if (PartID != default)
                App.ShowForm(typeof(FRMPart), true, new object[] { PartID, false });
        }

        private void dgData_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.ColumnIndex == 0 | e.ColumnIndex == dgvData.Columns["SwapSPN"].Index | e.ColumnIndex == 1) & e.RowIndex >= 0)
            {
                dgvData.EndEdit();
            }
        }

        private void dgvData_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int ImportID = Conversions.ToInteger(dgvData[2, e.RowIndex].Value);
                bool Exclude = Conversions.ToBoolean(dgvData.Rows[e.RowIndex].Cells[0].Value);
                bool ForceInsert = Conversions.ToBoolean(dgvData.Rows[e.RowIndex].Cells[1].Value);
                double ImportPrice = Conversions.ToDouble(dgvData[4, e.RowIndex].Value);
                bool SwapSPN = Conversions.ToBoolean(dgvData.Rows[e.RowIndex].Cells[dgvData.Columns["SwapSPN"].Index].Value);
                string Category = Conversions.ToString(dgvData.Rows[e.RowIndex].Cells[dgvData.Columns["Category"].Index].Value);
                string ImportDescription = "";
                App.DB.ImportValidation.Parts_PreImportChange(ImportID, Exclude, ForceInsert, ImportPrice, ImportDescription, SwapSPN, Category);
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (!(m_SelectedRow == -1))
            {
                m_SelectedRow = dgvData.CurrentRow.Index;
                dgvData.CurrentRow.DefaultCellStyle = m_SelectedStyle;
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

        private void dgvData_RowLeave1(object sender, DataGridViewCellEventArgs e)
        {
            if (m_SelectedRow >= 0)
            {
                dgvData.Rows[m_SelectedRow].DefaultCellStyle = null;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}