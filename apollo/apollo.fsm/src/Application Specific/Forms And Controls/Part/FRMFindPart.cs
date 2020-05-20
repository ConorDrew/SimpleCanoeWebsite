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

        private Panel _pnlGreen;

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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._lblFilter = new System.Windows.Forms.Label();
            this._txtFilter = new System.Windows.Forms.TextBox();
            this._grpResults = new System.Windows.Forms.GroupBox();
            this._dgvParts = new System.Windows.Forms.DataGridView();
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._lblPreferredSupplier = new System.Windows.Forms.Label();
            this._pnlGreen = new System.Windows.Forms.Panel();
            this._btnSearch = new System.Windows.Forms.Button();
            this._grpResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvParts)).BeginInit();
            this.SuspendLayout();
            // 
            // _lblFilter
            // 
            this._lblFilter.Location = new System.Drawing.Point(8, 11);
            this._lblFilter.Name = "_lblFilter";
            this._lblFilter.Size = new System.Drawing.Size(100, 24);
            this._lblFilter.TabIndex = 2;
            this._lblFilter.Text = "Filter By Name";
            // 
            // _txtFilter
            // 
            this._txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtFilter.Location = new System.Drawing.Point(104, 11);
            this._txtFilter.Name = "_txtFilter";
            this._txtFilter.Size = new System.Drawing.Size(562, 21);
            this._txtFilter.TabIndex = 1;
            this._txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // _grpResults
            // 
            this._grpResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpResults.Controls.Add(this._dgvParts);
            this._grpResults.Location = new System.Drawing.Point(8, 39);
            this._grpResults.Name = "_grpResults";
            this._grpResults.Size = new System.Drawing.Size(793, 406);
            this._grpResults.TabIndex = 4;
            this._grpResults.TabStop = false;
            this._grpResults.Text = "Select record and click OK";
            // 
            // _dgvParts
            // 
            this._dgvParts.AllowUserToAddRows = false;
            this._dgvParts.AllowUserToDeleteRows = false;
            this._dgvParts.AllowUserToOrderColumns = true;
            this._dgvParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgvParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvParts.Location = new System.Drawing.Point(8, 20);
            this._dgvParts.Name = "_dgvParts";
            this._dgvParts.ReadOnly = true;
            this._dgvParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvParts.Size = new System.Drawing.Size(777, 380);
            this._dgvParts.TabIndex = 0;
            // 
            // _btnOK
            // 
            this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOK.Location = new System.Drawing.Point(745, 451);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(56, 23);
            this._btnOK.TabIndex = 3;
            this._btnOK.Text = "OK";
            this._btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnCancel.Location = new System.Drawing.Point(8, 451);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(56, 23);
            this._btnCancel.TabIndex = 4;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // _lblPreferredSupplier
            // 
            this._lblPreferredSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblPreferredSupplier.Location = new System.Drawing.Point(95, 456);
            this._lblPreferredSupplier.Name = "_lblPreferredSupplier";
            this._lblPreferredSupplier.Size = new System.Drawing.Size(175, 24);
            this._lblPreferredSupplier.TabIndex = 7;
            this._lblPreferredSupplier.Text = "Preferred Supplier";
            // 
            // _pnlGreen
            // 
            this._pnlGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._pnlGreen.BackColor = System.Drawing.Color.LightGreen;
            this._pnlGreen.Location = new System.Drawing.Point(70, 454);
            this._pnlGreen.Name = "_pnlGreen";
            this._pnlGreen.Size = new System.Drawing.Size(19, 20);
            this._pnlGreen.TabIndex = 8;
            // 
            // _btnSearch
            // 
            this._btnSearch.Location = new System.Drawing.Point(673, 10);
            this._btnSearch.Name = "_btnSearch";
            this._btnSearch.Size = new System.Drawing.Size(128, 23);
            this._btnSearch.TabIndex = 9;
            this._btnSearch.Text = "Search";
            this._btnSearch.UseVisualStyleBackColor = true;
            this._btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FRMFindPart
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(809, 481);
            this.ControlBox = false;
            this.Controls.Add(this._btnSearch);
            this.Controls.Add(this._pnlGreen);
            this.Controls.Add(this._lblPreferredSupplier);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._grpResults);
            this.Controls.Add(this._txtFilter);
            this.Controls.Add(this._lblFilter);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(704, 392);
            this.Name = "FRMFindPart";
            this.Text = "Find {0}";
            this._grpResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvParts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

        private string _PartNumber;

        private bool _ForMassPartEntry = false;

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