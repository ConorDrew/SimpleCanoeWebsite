using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCLiveVisitCost : UCBase
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCLiveVisitCost() : base()
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

                    // Private Sub dgvData_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellValueChanged
                    // If e.ColumnIndex = 11 Then
                    // Dim ImportID As Integer = dgvData.Item(2, e.RowIndex).Value
                    // Dim ImportDescription As String = dgvData.Item(6, e.RowIndex).Value
                    // Dim ExistingSPC As String = dgvData.Item(11, e.RowIndex).Value

                    // DB.ImportValidation.Parts_UpdatePart(ImportID, ImportDescription, ExistingSPC)
                    // End If
                    // End Sub

                    // Private Sub dgData_Click(sender As Object, e As System.EventArgs) Handles dgvData.DoubleClick
                    // Dim PartID As Integer = dgvData.Item(3, dgvData.CurrentCell.RowIndex).Value
                    // If Not PartID = Nothing Then ShowForm(GetType(FRMPart), True, New Object() {PartID, False})
                    // End Sub

                    // Private Sub dgvData_RowLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellEndEdit
                    // Dim ImportID As Integer = dgvData.Item(2, e.RowIndex).Value
                    // Dim Exclude As Boolean = CBool(dgvData.Rows(e.RowIndex).Cells(0).Value)
                    // Dim ForceInsert As Boolean = CBool(dgvData.Rows(e.RowIndex).Cells(1).Value)
                    // Dim ImportPrice As Double = dgvData.Item(4, e.RowIndex).Value
                    // Dim ImportDescription As String = dgvData.Item(7, e.RowIndex).Value

                    // DB.ImportValidation.Parts_PreImportChange(ImportID, Exclude, ForceInsert, ImportPrice, ImportDescription)
                    // End Sub

                    _dgvData.SelectionChanged -= DataGridView1_SelectionChanged;
                    _dgvData.ColumnHeaderMouseClick -= dgvData_ColumnHeaderMouseClick;
                    _dgvData.RowLeave -= dgvData_RowLeave1;
                }

                _dgvData = value;
                if (_dgvData != null)
                {
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
                _Data.AllowEdit = false;
                _Data.AllowDelete = false;
                dgvData.AutoGenerateColumns = true;
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

            // Dim Exclude As New DataGridViewCheckBoxColumn
            // Exclude.FillWeight = 25
            // Exclude.HeaderText = "Exclude"
            // Exclude.DataPropertyName = "Exclude"
            // Exclude.ReadOnly = False
            // Exclude.SortMode = DataGridViewColumnSortMode.Programmatic
            // dgvData.Columns.Add(Exclude)
        }

        private void UCData_Load(object sender, EventArgs e)
        {
            SetupDG();
            m_SelectedStyle.BackColor = Color.LightBlue;
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