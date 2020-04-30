using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCStockReplenishmentData : UCBase
    {
        

        public UCStockReplenishmentData() : base()
        {
            
            
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
                    _dgvData.CellValueChanged -= dgvData_CellValueChanged;
                    _dgvData.DoubleClick -= dgvData_Click;
                    _dgvData.CellEndEdit -= dgvData_RowLeave;
                    _dgvData.SelectionChanged -= dgvData_SelectionChanged;
                    _dgvData.ColumnHeaderMouseClick -= dgvData_ColumnHeaderMouseClick;
                    _dgvData.RowLeave -= dgvData_RowLeave1;
                }

                _dgvData = value;
                if (_dgvData != null)
                {
                    _dgvData.CellValueChanged += dgvData_CellValueChanged;
                    _dgvData.DoubleClick += dgvData_Click;
                    _dgvData.CellEndEdit += dgvData_RowLeave;
                    _dgvData.SelectionChanged += dgvData_SelectionChanged;
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
            _dgvData.CellValueChanged += new DataGridViewCellEventHandler(dgvData_CellValueChanged);
            _dgvData.DoubleClick += new EventHandler(dgvData_Click);
            _dgvData.CellEndEdit += new DataGridViewCellEventHandler(dgvData_RowLeave);
            _dgvData.SelectionChanged += new EventHandler(dgvData_SelectionChanged);
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
                _Data.AllowDelete = false;
                dgvData.AutoGenerateColumns = false;
                dgvData.DataSource = Data;
            }
        }

        
        
        private DataGridViewCellStyle m_SelectedStyle = new DataGridViewCellStyle();
        private int m_SelectedRow = -1;

        public void SetupDG()
        {
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvData.Font = new Font("Arial", 7);
            var Exclude = new DataGridViewCheckBoxColumn();
            Exclude.FillWeight = 5;
            Exclude.HeaderText = "Exclude";
            Exclude.DataPropertyName = "Exclude";
            Exclude.ReadOnly = false;
            Exclude.SortMode = DataGridViewColumnSortMode.Programmatic;
            Exclude.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvData.Columns.Add(Exclude);
            var ID = new DataGridViewTextBoxColumn();
            ID.HeaderText = "ID";
            ID.DataPropertyName = "ID";
            ID.ReadOnly = false;
            ID.Visible = false;
            ID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(ID);
            var LocationID = new DataGridViewTextBoxColumn();
            LocationID.HeaderText = "Location";
            LocationID.DataPropertyName = "Location";
            LocationID.ReadOnly = true;
            LocationID.Visible = true;
            LocationID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(LocationID);
            var WarehouseID = new DataGridViewTextBoxColumn();
            WarehouseID.HeaderText = "WarehouseID";
            WarehouseID.DataPropertyName = "WarehouseID";
            WarehouseID.ReadOnly = true;
            WarehouseID.Visible = false;
            WarehouseID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(WarehouseID);
            var VanID = new DataGridViewTextBoxColumn();
            VanID.HeaderText = "VanID";
            VanID.DataPropertyName = "VanID";
            VanID.ReadOnly = true;
            VanID.Visible = false;
            VanID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(VanID);
            var PartName = new DataGridViewTextBoxColumn();
            PartName.HeaderText = "Part Name";
            PartName.DataPropertyName = "Item";
            PartName.ReadOnly = true;
            PartName.Visible = true;
            PartName.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(PartName);
            var PartID = new DataGridViewTextBoxColumn();
            PartID.HeaderText = "Part ID";
            PartID.DataPropertyName = "PartID";
            PartID.ReadOnly = true;
            PartID.Visible = false;
            PartID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(PartID);
            var PartSupplierID = new DataGridViewTextBoxColumn();
            PartSupplierID.HeaderText = "PartSupplierID";
            PartSupplierID.DataPropertyName = "PartSupplierID";
            PartSupplierID.ReadOnly = true;
            PartSupplierID.Visible = false;
            PartSupplierID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(PartSupplierID);
            var PartSupplierName = new DataGridViewTextBoxColumn();
            PartSupplierName.HeaderText = "Supplier";
            PartSupplierName.DataPropertyName = "PartSupplierName";
            PartSupplierName.ReadOnly = true;
            PartSupplierName.Visible = true;
            PartSupplierName.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(PartSupplierName);
            var MinimumQuantity = new DataGridViewTextBoxColumn();
            MinimumQuantity.FillWeight = 5;
            MinimumQuantity.HeaderText = "Minimum Quantity";
            MinimumQuantity.DataPropertyName = "MinimumQuantity";
            MinimumQuantity.ReadOnly = true;
            MinimumQuantity.Visible = true;
            MinimumQuantity.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(MinimumQuantity);
            var RecommendedQuantity = new DataGridViewTextBoxColumn();
            RecommendedQuantity.FillWeight = 5;
            RecommendedQuantity.HeaderText = "Recommended Quantity";
            RecommendedQuantity.DataPropertyName = "RecommendedQuantity";
            RecommendedQuantity.ReadOnly = true;
            RecommendedQuantity.Visible = true;
            RecommendedQuantity.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(RecommendedQuantity);
            var CurrentAmount = new DataGridViewTextBoxColumn();
            CurrentAmount.FillWeight = 5;
            CurrentAmount.HeaderText = "Current Amount";
            CurrentAmount.DataPropertyName = "Amount";
            CurrentAmount.ReadOnly = true;
            CurrentAmount.Visible = true;
            CurrentAmount.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(CurrentAmount);
            var PacksOnOrder = new DataGridViewTextBoxColumn();
            PacksOnOrder.FillWeight = 5;
            PacksOnOrder.HeaderText = "Packs On Order";
            PacksOnOrder.DataPropertyName = "PacksOnOrder";
            PacksOnOrder.ReadOnly = true;
            PacksOnOrder.Visible = true;
            PacksOnOrder.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(PacksOnOrder);
            var UnitsOnOrder = new DataGridViewTextBoxColumn();
            UnitsOnOrder.FillWeight = 5;
            UnitsOnOrder.HeaderText = "Units On Order";
            UnitsOnOrder.DataPropertyName = "UnitsOnOrder";
            UnitsOnOrder.ReadOnly = true;
            UnitsOnOrder.Visible = true;
            UnitsOnOrder.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(UnitsOnOrder);
            var AmountToOrder = new DataGridViewTextBoxColumn();
            AmountToOrder.FillWeight = 5;
            AmountToOrder.HeaderText = "Amount To Order";
            AmountToOrder.DataPropertyName = "AmountToOrder";
            AmountToOrder.ReadOnly = false;
            AmountToOrder.Visible = true;
            AmountToOrder.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(AmountToOrder);
            var FilterType = new DataGridViewTextBoxColumn();
            FilterType.HeaderText = "Filter Type";
            FilterType.DataPropertyName = "FilterType";
            FilterType.ReadOnly = true;
            FilterType.Visible = false;
            FilterType.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvData.Columns.Add(FilterType);
        }

        private void UCData_Load(object sender, EventArgs e)
        {
            SetupDG();
            m_SelectedStyle.BackColor = Color.LightBlue;
        }

        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 14)
            {
                int ItemID = Conversions.ToInteger(dgvData[1, e.RowIndex].Value);
                // 'Dim ItemID As Integer = dgvData.Rows(e.RowIndex).Cells(1).Value
                int AmountToOrder = Conversions.ToInteger(dgvData.Rows[e.RowIndex].Cells[14].Value);
                App.DB.Location.StockTake_Replenishment_UpdateAmountToOrder(ItemID, AmountToOrder);
            }
        }

        private void dgvData_Click(object sender, EventArgs e)
        {
            int PartID = Conversions.ToInteger(dgvData[6, dgvData.CurrentCell.RowIndex].Value);
            if (PartID != default)
                App.ShowForm(typeof(FRMPart), true, new object[] { PartID, false });
        }

        private void dgvData_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int ItemID = Conversions.ToInteger(dgvData[1, e.RowIndex].Value);
                // Dim ItemID As Integer = dgvData.Rows(e.RowIndex).Cells(1).Value
                bool Exclude = Conversions.ToBoolean(dgvData.Rows[e.RowIndex].Cells[0].Value);
                App.DB.Location.StockTake_Replenishment_UpdateExclude(ItemID, Exclude);
            }
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
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

        
    }
}