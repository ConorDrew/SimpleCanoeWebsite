using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMFindPart : FRMBaseForm, IForm
    {
        public FRMFindPart() : base()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
        }

        public FRMFindPart(System.Data.SqlClient.SqlTransaction trans) : base()
        {
            Trans = trans;

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

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
        private Label _lblFilter;

        internal Label lblFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFilter != null)
                {
                }

                _lblFilter = value;
                if (_lblFilter != null)
                {
                }
            }
        }

        private TextBox _txtFilter;

        internal TextBox txtFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFilter != null)
                {
                    _txtFilter.TextChanged -= txtFilter_TextChanged;
                }

                _txtFilter = value;
                if (_txtFilter != null)
                {
                    _txtFilter.TextChanged += txtFilter_TextChanged;
                }
            }
        }

        private GroupBox _grpResults;

        internal GroupBox grpResults
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpResults;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpResults != null)
                {
                }

                _grpResults = value;
                if (_grpResults != null)
                {
                }
            }
        }

        private Button _btnOK;

        internal Button btnOK
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOK;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOK != null)
                {
                    _btnOK.Click -= btnOK_Click;
                }

                _btnOK = value;
                if (_btnOK != null)
                {
                    _btnOK.Click += btnOK_Click;
                }
            }
        }

        private Button _btnCancel;

        internal Button btnCancel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCancel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCancel != null)
                {
                    _btnCancel.Click -= btnCancel_Click;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnCancel_Click;
                }
            }
        }

        private Label _lblPreferredSupplier;

        internal Label lblPreferredSupplier
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPreferredSupplier;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPreferredSupplier != null)
                {
                }

                _lblPreferredSupplier = value;
                if (_lblPreferredSupplier != null)
                {
                }
            }
        }

        private Panel _pnlGreen;

        internal Panel pnlGreen
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlGreen;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlGreen != null)
                {
                }

                _pnlGreen = value;
                if (_pnlGreen != null)
                {
                }
            }
        }

        private DataGridView _dgvParts;

        internal DataGridView dgvParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgvParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgvParts != null)
                {
                }

                _dgvParts = value;
                if (_dgvParts != null)
                {
                }
            }
        }

        private Button _btnSearch;

        internal Button btnSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSearch != null)
                {
                    _btnSearch.Click -= btnSearch_Click;
                }

                _btnSearch = value;
                if (_btnSearch != null)
                {
                    _btnSearch.Click += btnSearch_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _lblFilter = new Label();
            _txtFilter = new TextBox();
            _txtFilter.TextChanged += new EventHandler(txtFilter_TextChanged);
            _grpResults = new GroupBox();
            _dgvParts = new DataGridView();
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _lblPreferredSupplier = new Label();
            _pnlGreen = new Panel();
            _btnSearch = new Button();
            _btnSearch.Click += new EventHandler(btnSearch_Click);
            _grpResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvParts).BeginInit();
            SuspendLayout();
            //
            // lblFilter
            //
            _lblFilter.Location = new Point(8, 40);
            _lblFilter.Name = "lblFilter";
            _lblFilter.Size = new Size(100, 24);
            _lblFilter.TabIndex = 2;
            _lblFilter.Text = "Filter By Name";
            //
            // txtFilter
            //
            _txtFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtFilter.Location = new Point(104, 40);
            _txtFilter.Name = "txtFilter";
            _txtFilter.Size = new Size(562, 21);
            _txtFilter.TabIndex = 1;
            //
            // grpResults
            //
            _grpResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpResults.Controls.Add(_dgvParts);
            _grpResults.Location = new Point(8, 68);
            _grpResults.Name = "grpResults";
            _grpResults.Size = new Size(793, 377);
            _grpResults.TabIndex = 4;
            _grpResults.TabStop = false;
            _grpResults.Text = "Select record and click OK";
            //
            // dgvParts
            //
            _dgvParts.AllowUserToAddRows = false;
            _dgvParts.AllowUserToDeleteRows = false;
            _dgvParts.AllowUserToOrderColumns = true;
            _dgvParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgvParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgvParts.Location = new Point(8, 20);
            _dgvParts.Name = "dgvParts";
            _dgvParts.ReadOnly = true;
            _dgvParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvParts.Size = new Size(777, 351);
            _dgvParts.TabIndex = 0;
            //
            // btnOK
            //
            _btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnOK.Location = new Point(745, 451);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(56, 23);
            _btnOK.TabIndex = 3;
            _btnOK.Text = "OK";
            //
            // btnCancel
            //
            _btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnCancel.Location = new Point(8, 451);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(56, 23);
            _btnCancel.TabIndex = 4;
            _btnCancel.Text = "Cancel";
            //
            // lblPreferredSupplier
            //
            _lblPreferredSupplier.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblPreferredSupplier.Location = new Point(95, 456);
            _lblPreferredSupplier.Name = "lblPreferredSupplier";
            _lblPreferredSupplier.Size = new Size(175, 24);
            _lblPreferredSupplier.TabIndex = 7;
            _lblPreferredSupplier.Text = "Preferred Supplier";
            //
            // pnlGreen
            //
            _pnlGreen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _pnlGreen.BackColor = Color.LightGreen;
            _pnlGreen.Location = new Point(70, 454);
            _pnlGreen.Name = "pnlGreen";
            _pnlGreen.Size = new Size(19, 20);
            _pnlGreen.TabIndex = 8;
            //
            // btnSearch
            //
            _btnSearch.Location = new Point(673, 39);
            _btnSearch.Name = "btnSearch";
            _btnSearch.Size = new Size(128, 23);
            _btnSearch.TabIndex = 9;
            _btnSearch.Text = "Search";
            _btnSearch.UseVisualStyleBackColor = true;
            //
            // FRMFindPart
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(809, 481);
            ControlBox = false;
            Controls.Add(_btnSearch);
            Controls.Add(_pnlGreen);
            Controls.Add(_lblPreferredSupplier);
            Controls.Add(_btnCancel);
            Controls.Add(_btnOK);
            Controls.Add(_grpResults);
            Controls.Add(_txtFilter);
            Controls.Add(_lblFilter);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(704, 392);
            Name = "FRMFindPart";
            Text = "Find {0}";
            Controls.SetChildIndex(_lblFilter, 0);
            Controls.SetChildIndex(_txtFilter, 0);
            Controls.SetChildIndex(_grpResults, 0);
            Controls.SetChildIndex(_btnOK, 0);
            Controls.SetChildIndex(_btnCancel, 0);
            Controls.SetChildIndex(_lblPreferredSupplier, 0);
            Controls.SetChildIndex(_pnlGreen, 0);
            Controls.SetChildIndex(_btnSearch, 0);
            _grpResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgvParts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            ActiveControl = txtFilter;
            txtFilter.Focus();
        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        public void ResetMe(int newID)
        {
        }

        private System.Data.SqlClient.SqlTransaction _Trans;

        public System.Data.SqlClient.SqlTransaction Trans
        {
            get
            {
                return _Trans;
            }

            set
            {
                _Trans = value;
            }
        }

        public DataRow[] Datarows = null;
        private Entity.Sys.Enums.TableNames _TableToSearch = Entity.Sys.Enums.TableNames.NO_TABLE;

        public Entity.Sys.Enums.TableNames TableToSearch
        {
            get
            {
                return _TableToSearch;
            }

            set
            {
                MinimumSize = new Size(new Point(704, 392));
                _TableToSearch = value;
                if (TableToSearch == Entity.Sys.Enums.TableNames.tblPart)
                {
                    Entity.Sys.Helper.SetUpDataGridView(dgvParts);
                    dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvParts.AutoGenerateColumns = false;
                    dgvParts.Columns.Clear();
                    dgvParts.EditMode = DataGridViewEditMode.EditOnEnter;
                    var Qty = new DataGridViewTextBoxColumn();
                    Qty.HeaderText = "Qty";
                    Qty.DataPropertyName = "Qty";
                    Qty.FillWeight = 30;
                    Qty.ReadOnly = false;
                    Qty.SortMode = DataGridViewColumnSortMode.Programmatic;
                    dgvParts.Columns.Add(Qty);
                    var PartName = new DataGridViewTextBoxColumn();
                    PartName.FillWeight = 60;
                    PartName.HeaderText = "Part Name";
                    PartName.DataPropertyName = "Name";
                    PartName.ReadOnly = true;
                    PartName.Visible = true;
                    PartName.SortMode = DataGridViewColumnSortMode.Programmatic;
                    dgvParts.Columns.Add(PartName);
                    var PartNumber = new DataGridViewTextBoxColumn();
                    PartNumber.HeaderText = "Part Number";
                    PartNumber.DataPropertyName = "Number";
                    PartNumber.FillWeight = 50;
                    PartNumber.ReadOnly = true;
                    PartNumber.SortMode = DataGridViewColumnSortMode.Programmatic;
                    dgvParts.Columns.Add(PartNumber);
                    var Reference = new DataGridViewTextBoxColumn();
                    Reference.HeaderText = "Reference";
                    Reference.DataPropertyName = "Reference";
                    Reference.FillWeight = 50;
                    Reference.ReadOnly = true;
                    Reference.SortMode = DataGridViewColumnSortMode.Programmatic;
                    dgvParts.Columns.Add(Reference);
                    Records = App.DB.Part.Part_Search(txtFilter.Text, "");
                }
                else if (TableToSearch == Entity.Sys.Enums.TableNames.NOT_IN_Database_tblPartSupplierQty)
                {
                    Entity.Sys.Helper.SetUpDataGridView(dgvParts);
                    dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvParts.AutoGenerateColumns = false;
                    dgvParts.Columns.Clear();
                    dgvParts.EditMode = DataGridViewEditMode.EditOnEnter;
                    var Qty = new DataGridViewTextBoxColumn();
                    Qty.HeaderText = "Qty";
                    Qty.DataPropertyName = "Qty";
                    Qty.FillWeight = 30;
                    Qty.ReadOnly = false;
                    Qty.SortMode = DataGridViewColumnSortMode.Automatic;
                    dgvParts.Columns.Add(Qty);
                    var PartName = new DataGridViewTextBoxColumn();
                    PartName.FillWeight = 60;
                    PartName.HeaderText = "Part Name";
                    PartName.DataPropertyName = "PartName";
                    PartName.ReadOnly = true;
                    PartName.Visible = true;
                    PartName.SortMode = DataGridViewColumnSortMode.Automatic;
                    dgvParts.Columns.Add(PartName);
                    var PartNumber = new DataGridViewTextBoxColumn();
                    PartNumber.HeaderText = "Part Number";
                    PartNumber.DataPropertyName = "PartNumber";
                    PartNumber.FillWeight = 50;
                    PartNumber.ReadOnly = true;
                    PartNumber.SortMode = DataGridViewColumnSortMode.Automatic;
                    dgvParts.Columns.Add(PartNumber);
                    var Reference = new DataGridViewTextBoxColumn();
                    Reference.HeaderText = "Reference";
                    Reference.DataPropertyName = "Reference";
                    Reference.FillWeight = 50;
                    Reference.ReadOnly = true;
                    Reference.SortMode = DataGridViewColumnSortMode.Automatic;
                    dgvParts.Columns.Add(Reference);
                    var SPN = new DataGridViewTextBoxColumn();
                    SPN.HeaderText = "SPN";
                    SPN.DataPropertyName = "PartCode";
                    SPN.FillWeight = 50;
                    SPN.ReadOnly = true;
                    SPN.SortMode = DataGridViewColumnSortMode.Automatic;
                    dgvParts.Columns.Add(SPN);
                    var Supplier = new DataGridViewTextBoxColumn();
                    Supplier.HeaderText = "Supplier Name";
                    Supplier.DataPropertyName = "SupplierName";
                    Supplier.FillWeight = 60;
                    Supplier.ReadOnly = true;
                    Supplier.SortMode = DataGridViewColumnSortMode.Automatic;
                    Supplier.Visible = true;
                    dgvParts.Columns.Add(Supplier);
                    var Price = new DataGridViewTextBoxColumn();
                    Price.HeaderText = "Price";
                    Price.DataPropertyName = "Price";
                    Price.FillWeight = 60;
                    Price.ReadOnly = true;
                    Price.SortMode = DataGridViewColumnSortMode.Automatic;
                    Price.Visible = true;
                    dgvParts.Columns.Add(Price);
                    Records = (DataView)App.DB.PartSupplier.PartSupplier_Search(txtFilter.Text);
                }
                else
                {
                    Entity.Sys.Helper.SetUpDataGridView(dgvParts);
                    dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvParts.AutoGenerateColumns = false;
                    dgvParts.Columns.Clear();
                    dgvParts.EditMode = DataGridViewEditMode.EditOnEnter;
                    var Tick = new DataGridViewCheckBoxColumn();
                    Tick.FillWeight = 30;
                    Tick.HeaderText = "Include";
                    Tick.DataPropertyName = "Tick";
                    Tick.ReadOnly = false;
                    Tick.Visible = true;
                    Tick.SortMode = DataGridViewColumnSortMode.Programmatic;
                    dgvParts.Columns.Add(Tick);
                    var PartName = new DataGridViewTextBoxColumn();
                    PartName.FillWeight = 60;
                    PartName.HeaderText = "Part Name";
                    PartName.DataPropertyName = "PartName";
                    PartName.ReadOnly = true;
                    PartName.Visible = true;
                    PartName.SortMode = DataGridViewColumnSortMode.Programmatic;
                    dgvParts.Columns.Add(PartName);
                    var PartNumber = new DataGridViewTextBoxColumn();
                    PartNumber.HeaderText = "Part Number";
                    PartNumber.DataPropertyName = "PartNumber";
                    PartNumber.FillWeight = 50;
                    PartNumber.ReadOnly = true;
                    PartNumber.SortMode = DataGridViewColumnSortMode.Programmatic;
                    dgvParts.Columns.Add(PartNumber);
                    var SPN = new DataGridViewTextBoxColumn();
                    SPN.HeaderText = "SPN";
                    SPN.DataPropertyName = "PartCode";
                    SPN.FillWeight = 50;
                    SPN.ReadOnly = true;
                    SPN.SortMode = DataGridViewColumnSortMode.Programmatic;
                    dgvParts.Columns.Add(SPN);
                    var Supplier = new DataGridViewTextBoxColumn();
                    Supplier.HeaderText = "Supplier Name";
                    Supplier.DataPropertyName = "SupplierName";
                    Supplier.FillWeight = 60;
                    Supplier.ReadOnly = true;
                    Supplier.SortMode = DataGridViewColumnSortMode.Programmatic;
                    Supplier.Visible = true;
                    dgvParts.Columns.Add(Supplier);
                    dgvParts.Sort(Supplier, System.ComponentModel.ListSortDirection.Descending);
                    Records = (DataView)App.DB.PartSupplier.PartSupplier_Search(txtFilter.Text);
                }
            }
        }

        private int _foreignKeyFilter;

        public int ForeignKeyFilter
        {
            get
            {
                return _foreignKeyFilter;
            }

            set
            {
                _foreignKeyFilter = value;
            }
        }

        private string _PartNumber;

        public string PartNumber
        {
            get
            {
                return _PartNumber;
            }

            set
            {
                _PartNumber = value;
            }
        }

        private bool _ForMassPartEntry = false;

        public bool ForMassPartEntry
        {
            get
            {
                return _ForMassPartEntry;
            }

            set
            {
                _ForMassPartEntry = value;
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
                dgvParts.DataSource = Records;
            }
        }

        private int _ID = 0;

        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        private int _2ndID = 0;

        public int SecondID
        {
            get
            {
                return _2ndID;
            }

            set
            {
                _2ndID = value;
            }
        }

        private ArrayList _PartsToAdd = null;

        public ArrayList PartsToAdd
        {
            get
            {
                return _PartsToAdd;
            }

            set
            {
                _PartsToAdd = value;
            }
        }

        private int _PartID = 0;

        public int PartID
        {
            get
            {
                return _PartID;
            }

            set
            {
                _PartID = value;
            }
        }

        private int _PartSupplierID = 0;

        public int PartSupplierID
        {
            get
            {
                return _PartSupplierID;
            }

            set
            {
                _PartSupplierID = value;
            }
        }

        private DataGridViewSelectedRowCollection old;

        private void DLGFindRecord_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectItem();
        }

        private void SelectItem()
        {
            if (dgvParts.SelectedRows is null)
            {
                App.ShowMessage("No records selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (TableToSearch == Entity.Sys.Enums.TableNames.tblPart | TableToSearch == Entity.Sys.Enums.TableNames.NOT_IN_Database_tblPartSupplierQty)
            {
                Datarows = ((DataView)dgvParts.DataSource).Table.Select("Qty > 0");
            }
            else
            {
                Datarows = ((DataView)dgvParts.DataSource).Table.Select("Tick = 1");
            }

            DialogResult = DialogResult.OK;
        }

        private void RunFilter()
        {
            string whereClause = "0 = 0";
            if (!(txtFilter.Text.Trim().Length == 0))
            {
                var switchExpr = TableToSearch;
                switch (switchExpr)
                {
                    case Entity.Sys.Enums.TableNames.tblJob:
                        {
                            whereClause += " AND JobNumber LIKE '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblContact:
                        {
                            whereClause += " AND (Firstname LIKE '%" + txtFilter.Text.Trim() + "%') OR (Surname LIKE '%" + txtFilter.Text.Trim() + "%')";
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblSite:
                        {
                            whereClause += " AND (Name LIKE '%" + txtFilter.Text.Trim() + "%' OR Address1 LIKE '%" + txtFilter.Text.Trim() + "%')";
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblProduct:
                        {
                            whereClause += " AND typemakemodel LIKE '%" + txtFilter.Text.Trim() + "%' OR Reference LIKE '%" + txtFilter.Text.Trim() + "%'OR Number LIKE '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblPart:
                        {
                            whereClause += " AND Name LIKE '%" + txtFilter.Text.Trim() + "%' OR Reference LIKE '%" + txtFilter.Text.Trim() + "%'OR Number LIKE '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblPartSupplier:
                        {
                            whereClause += " AND PartName LIKE '%" + txtFilter.Text.Trim() + "%' OR PartCode LIKE '%" + txtFilter.Text.Trim() + "%' OR PartNumber LIKE '%" + txtFilter.Text.Trim() + "%' OR Reference LIKE '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }

                    case Entity.Sys.Enums.TableNames.tblOrder:
                        {
                            whereClause += " AND OrderReference LIKE '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }

                    default:
                        {
                            whereClause += " AND PartName LIKE '%" + txtFilter.Text.Trim() + "%' OR PartCode LIKE '%" + txtFilter.Text.Trim() + "%' OR PartNumber LIKE '%" + txtFilter.Text.Trim() + "%' OR Reference LIKE '%" + txtFilter.Text.Trim() + "%'";
                            break;
                        }
                }
            }

            Records.RowFilter = whereClause;
        }

        public class ColourColumn : DataGridLabelColumn
        {
            protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
            {
                base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                // set the color required dependant on the column value
                Brush brush;
                brush = Brushes.White;
                DataRowView dr = (DataRowView)source.List[rowNum];
                if (Entity.Sys.Helper.MakeBooleanValid(dr["Preferred"]))
                {
                    brush = Brushes.LightGreen;
                }

                TextBox.Text = "";
                // color the row cell
                var rect = bounds;
                g.FillRectangle(brush, rect);
                g.DrawString("", DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom));
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (TableToSearch == Entity.Sys.Enums.TableNames.tblPart)
            {
                Records = App.DB.Part.Part_Search(txtFilter.Text, "");
            }
            else
            {
                Records = (DataView)App.DB.PartSupplier.PartSupplier_Search(txtFilter.Text);
            }
        }
    }
}