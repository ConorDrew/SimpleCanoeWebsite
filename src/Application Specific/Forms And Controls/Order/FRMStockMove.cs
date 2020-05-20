using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMStockMove : FRMBaseForm, IForm
    {
        public FRMStockMove() : base()
        {
            base.Load += FRMStockMove_Load;

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

        private RadioButton _radWarehouseCurrent;

        internal RadioButton radWarehouseCurrent
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radWarehouseCurrent;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radWarehouseCurrent != null)
                {
                    _radWarehouseCurrent.CheckedChanged -= radWarehouseCurrent_CheckedChanged;
                }

                _radWarehouseCurrent = value;
                if (_radWarehouseCurrent != null)
                {
                    _radWarehouseCurrent.CheckedChanged += radWarehouseCurrent_CheckedChanged;
                }
            }
        }

        private RadioButton _radVanCurrent;

        internal RadioButton radVanCurrent
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radVanCurrent;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radVanCurrent != null)
                {
                    _radVanCurrent.CheckedChanged -= radVanCurrent_CheckedChanged;
                }

                _radVanCurrent = value;
                if (_radVanCurrent != null)
                {
                    _radVanCurrent.CheckedChanged += radVanCurrent_CheckedChanged;
                }
            }
        }

        private Label _Label5;

        internal Label Label5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label5 != null)
                {
                }

                _Label5 = value;
                if (_Label5 != null)
                {
                }
            }
        }

        private ComboBox _cboLocationCurrent;

        internal ComboBox cboLocationCurrent
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboLocationCurrent;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboLocationCurrent != null)
                {
                    _cboLocationCurrent.SelectedIndexChanged -= cboLocationCurrent_SelectedIndexChanged;
                }

                _cboLocationCurrent = value;
                if (_cboLocationCurrent != null)
                {
                    _cboLocationCurrent.SelectedIndexChanged += cboLocationCurrent_SelectedIndexChanged;
                }
            }
        }

        private GroupBox _grpCurrent;

        private GroupBox _grpNew;

        private RadioButton _radWarehouseNew;

        internal RadioButton radWarehouseNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radWarehouseNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radWarehouseNew != null)
                {
                    _radWarehouseNew.CheckedChanged -= radWarehouseNew_CheckedChanged;
                }

                _radWarehouseNew = value;
                if (_radWarehouseNew != null)
                {
                    _radWarehouseNew.CheckedChanged += radWarehouseNew_CheckedChanged;
                }
            }
        }

        private Label _Label1;

        internal Label Label1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label1 != null)
                {
                }

                _Label1 = value;
                if (_Label1 != null)
                {
                }
            }
        }

        private RadioButton _radVanNew;

        internal RadioButton radVanNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radVanNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radVanNew != null)
                {
                    _radVanNew.CheckedChanged -= radVanNew_CheckedChanged;
                }

                _radVanNew = value;
                if (_radVanNew != null)
                {
                    _radVanNew.CheckedChanged += radVanNew_CheckedChanged;
                }
            }
        }

        private ComboBox _cboLocationNew;

        internal ComboBox cboLocationNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboLocationNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboLocationNew != null)
                {
                }

                _cboLocationNew = value;
                if (_cboLocationNew != null)
                {
                }
            }
        }

        private GroupBox _grpItems;

        private TextBox _txtQuantity;

        internal TextBox txtQuantity
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQuantity;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQuantity != null)
                {
                    _txtQuantity.GotFocus -= txtQuantity_GotFocus;
                    _txtQuantity.Validating -= txtQuantity_Validating;
                }

                _txtQuantity = value;
                if (_txtQuantity != null)
                {
                    _txtQuantity.GotFocus += txtQuantity_GotFocus;
                    _txtQuantity.Validating += txtQuantity_Validating;
                }
            }
        }

        private Label _Label2;

        internal Label Label2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label2 != null)
                {
                }

                _Label2 = value;
                if (_Label2 != null)
                {
                }
            }
        }

        private DataGrid _dgItems;

        internal DataGrid dgItems
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgItems;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgItems != null)
                {
                    _dgItems.DoubleClick -= dgItems_DoubleClick;
                    _dgItems.Click -= dgItems_Click;
                }

                _dgItems = value;
                if (_dgItems != null)
                {
                    _dgItems.DoubleClick += dgItems_DoubleClick;
                    _dgItems.Click += dgItems_Click;
                }
            }
        }

        private Button _btnClose;

        internal Button btnClose
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClose;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClose != null)
                {
                    _btnClose.Click -= btnClose_Click;
                }

                _btnClose = value;
                if (_btnClose != null)
                {
                    _btnClose.Click += btnClose_Click;
                }
            }
        }

        private Button _btnMove;

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

        private Label _Label3;

        internal Label Label3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label3 != null)
                {
                }

                _Label3 = value;
                if (_Label3 != null)
                {
                }
            }
        }

        private Button _btnSelectAll;

        private Button _btnDeselectAll;

        private Label _Label4;

        internal Label Label4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label4 != null)
                {
                }

                _Label4 = value;
                if (_Label4 != null)
                {
                }
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._radWarehouseCurrent = new System.Windows.Forms.RadioButton();
            this._radVanCurrent = new System.Windows.Forms.RadioButton();
            this._Label5 = new System.Windows.Forms.Label();
            this._cboLocationCurrent = new System.Windows.Forms.ComboBox();
            this._grpCurrent = new System.Windows.Forms.GroupBox();
            this._grpNew = new System.Windows.Forms.GroupBox();
            this._radWarehouseNew = new System.Windows.Forms.RadioButton();
            this._Label1 = new System.Windows.Forms.Label();
            this._radVanNew = new System.Windows.Forms.RadioButton();
            this._cboLocationNew = new System.Windows.Forms.ComboBox();
            this._grpItems = new System.Windows.Forms.GroupBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._btnSelectAll = new System.Windows.Forms.Button();
            this._btnDeselectAll = new System.Windows.Forms.Button();
            this._txtFilter = new System.Windows.Forms.TextBox();
            this._Label3 = new System.Windows.Forms.Label();
            this._txtQuantity = new System.Windows.Forms.TextBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._dgItems = new System.Windows.Forms.DataGrid();
            this._btnClose = new System.Windows.Forms.Button();
            this._btnMove = new System.Windows.Forms.Button();
            this._grpCurrent.SuspendLayout();
            this._grpNew.SuspendLayout();
            this._grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgItems)).BeginInit();
            this.SuspendLayout();
            // 
            // _radWarehouseCurrent
            // 
            this._radWarehouseCurrent.Checked = true;
            this._radWarehouseCurrent.Location = new System.Drawing.Point(8, 20);
            this._radWarehouseCurrent.Name = "_radWarehouseCurrent";
            this._radWarehouseCurrent.Size = new System.Drawing.Size(96, 26);
            this._radWarehouseCurrent.TabIndex = 1;
            this._radWarehouseCurrent.TabStop = true;
            this._radWarehouseCurrent.Text = "Warehouse";
            this._radWarehouseCurrent.CheckedChanged += new System.EventHandler(this.radWarehouseCurrent_CheckedChanged);
            // 
            // _radVanCurrent
            // 
            this._radVanCurrent.Location = new System.Drawing.Point(110, 20);
            this._radVanCurrent.Name = "_radVanCurrent";
            this._radVanCurrent.Size = new System.Drawing.Size(99, 26);
            this._radVanCurrent.TabIndex = 2;
            this._radVanCurrent.Text = "Stock Profile";
            this._radVanCurrent.CheckedChanged += new System.EventHandler(this.radVanCurrent_CheckedChanged);
            // 
            // _Label5
            // 
            this._Label5.Location = new System.Drawing.Point(214, 25);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(24, 23);
            this._Label5.TabIndex = 7;
            this._Label5.Text = ">";
            // 
            // _cboLocationCurrent
            // 
            this._cboLocationCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboLocationCurrent.Location = new System.Drawing.Point(247, 25);
            this._cboLocationCurrent.Name = "_cboLocationCurrent";
            this._cboLocationCurrent.Size = new System.Drawing.Size(337, 21);
            this._cboLocationCurrent.TabIndex = 3;
            this._cboLocationCurrent.SelectedIndexChanged += new System.EventHandler(this.cboLocationCurrent_SelectedIndexChanged);
            // 
            // _grpCurrent
            // 
            this._grpCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpCurrent.Controls.Add(this._radWarehouseCurrent);
            this._grpCurrent.Controls.Add(this._Label5);
            this._grpCurrent.Controls.Add(this._radVanCurrent);
            this._grpCurrent.Controls.Add(this._cboLocationCurrent);
            this._grpCurrent.Location = new System.Drawing.Point(4, 12);
            this._grpCurrent.Name = "_grpCurrent";
            this._grpCurrent.Size = new System.Drawing.Size(592, 58);
            this._grpCurrent.TabIndex = 1;
            this._grpCurrent.TabStop = false;
            this._grpCurrent.Text = "Select current stock location";
            // 
            // _grpNew
            // 
            this._grpNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpNew.Controls.Add(this._radWarehouseNew);
            this._grpNew.Controls.Add(this._Label1);
            this._grpNew.Controls.Add(this._radVanNew);
            this._grpNew.Controls.Add(this._cboLocationNew);
            this._grpNew.Location = new System.Drawing.Point(4, 337);
            this._grpNew.Name = "_grpNew";
            this._grpNew.Size = new System.Drawing.Size(592, 58);
            this._grpNew.TabIndex = 3;
            this._grpNew.TabStop = false;
            this._grpNew.Text = "Select new stock location";
            // 
            // _radWarehouseNew
            // 
            this._radWarehouseNew.Checked = true;
            this._radWarehouseNew.Location = new System.Drawing.Point(8, 20);
            this._radWarehouseNew.Name = "_radWarehouseNew";
            this._radWarehouseNew.Size = new System.Drawing.Size(96, 26);
            this._radWarehouseNew.TabIndex = 1;
            this._radWarehouseNew.TabStop = true;
            this._radWarehouseNew.Text = "Warehouse";
            this._radWarehouseNew.CheckedChanged += new System.EventHandler(this.radWarehouseNew_CheckedChanged);
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(214, 23);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(24, 23);
            this._Label1.TabIndex = 7;
            this._Label1.Text = ">";
            // 
            // _radVanNew
            // 
            this._radVanNew.Location = new System.Drawing.Point(110, 20);
            this._radVanNew.Name = "_radVanNew";
            this._radVanNew.Size = new System.Drawing.Size(98, 26);
            this._radVanNew.TabIndex = 2;
            this._radVanNew.Text = "Stock Profile";
            this._radVanNew.CheckedChanged += new System.EventHandler(this.radVanNew_CheckedChanged);
            // 
            // _cboLocationNew
            // 
            this._cboLocationNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboLocationNew.Location = new System.Drawing.Point(247, 25);
            this._cboLocationNew.Name = "_cboLocationNew";
            this._cboLocationNew.Size = new System.Drawing.Size(337, 21);
            this._cboLocationNew.TabIndex = 3;
            // 
            // _grpItems
            // 
            this._grpItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpItems.Controls.Add(this._Label4);
            this._grpItems.Controls.Add(this._btnSelectAll);
            this._grpItems.Controls.Add(this._btnDeselectAll);
            this._grpItems.Controls.Add(this._txtFilter);
            this._grpItems.Controls.Add(this._Label3);
            this._grpItems.Controls.Add(this._txtQuantity);
            this._grpItems.Controls.Add(this._Label2);
            this._grpItems.Controls.Add(this._dgItems);
            this._grpItems.Location = new System.Drawing.Point(4, 76);
            this._grpItems.Name = "_grpItems";
            this._grpItems.Size = new System.Drawing.Size(592, 255);
            this._grpItems.TabIndex = 2;
            this._grpItems.TabStop = false;
            this._grpItems.Text = "Select item to move";
            // 
            // _Label4
            // 
            this._Label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label4.Location = new System.Drawing.Point(295, 227);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(255, 14);
            this._Label4.TabIndex = 23;
            this._Label4.Text = "The current quantity will be moved across";
            this._Label4.Visible = false;
            // 
            // _btnSelectAll
            // 
            this._btnSelectAll.AccessibleDescription = "Export Job List To Excel";
            this._btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSelectAll.Location = new System.Drawing.Point(400, 18);
            this._btnSelectAll.Name = "_btnSelectAll";
            this._btnSelectAll.Size = new System.Drawing.Size(88, 23);
            this._btnSelectAll.TabIndex = 21;
            this._btnSelectAll.Text = "Select All";
            this._btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // _btnDeselectAll
            // 
            this._btnDeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDeselectAll.Location = new System.Drawing.Point(496, 18);
            this._btnDeselectAll.Name = "_btnDeselectAll";
            this._btnDeselectAll.Size = new System.Drawing.Size(88, 23);
            this._btnDeselectAll.TabIndex = 22;
            this._btnDeselectAll.Text = "Deselect All";
            this._btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // _txtFilter
            // 
            this._txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtFilter.Location = new System.Drawing.Point(48, 20);
            this._txtFilter.Name = "_txtFilter";
            this._txtFilter.Size = new System.Drawing.Size(335, 21);
            this._txtFilter.TabIndex = 1;
            this._txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // _Label3
            // 
            this._Label3.Location = new System.Drawing.Point(4, 23);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(51, 18);
            this._Label3.TabIndex = 3;
            this._Label3.Text = "Filter";
            // 
            // _txtQuantity
            // 
            this._txtQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtQuantity.Location = new System.Drawing.Point(189, 224);
            this._txtQuantity.Name = "_txtQuantity";
            this._txtQuantity.Size = new System.Drawing.Size(100, 21);
            this._txtQuantity.TabIndex = 3;
            this._txtQuantity.Text = "1";
            this._txtQuantity.GotFocus += new System.EventHandler(this.txtQuantity_GotFocus);
            this._txtQuantity.Validating += new System.ComponentModel.CancelEventHandler(this.txtQuantity_Validating);
            // 
            // _Label2
            // 
            this._Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label2.Location = new System.Drawing.Point(6, 227);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(177, 16);
            this._Label2.TabIndex = 1;
            this._Label2.Text = "Enter quantity being moved";
            // 
            // _dgItems
            // 
            this._dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgItems.DataMember = "";
            this._dgItems.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgItems.Location = new System.Drawing.Point(6, 47);
            this._dgItems.Name = "_dgItems";
            this._dgItems.Size = new System.Drawing.Size(580, 171);
            this._dgItems.TabIndex = 2;
            this._dgItems.Click += new System.EventHandler(this.dgItems_Click);
            this._dgItems.DoubleClick += new System.EventHandler(this.dgItems_DoubleClick);
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClose.Location = new System.Drawing.Point(4, 401);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(59, 23);
            this._btnClose.TabIndex = 5;
            this._btnClose.Text = "Close";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // _btnMove
            // 
            this._btnMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnMove.Location = new System.Drawing.Point(537, 401);
            this._btnMove.Name = "_btnMove";
            this._btnMove.Size = new System.Drawing.Size(59, 23);
            this._btnMove.TabIndex = 4;
            this._btnMove.Text = "Move";
            this._btnMove.UseVisualStyleBackColor = true;
            this._btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // FRMStockMove
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(601, 435);
            this.Controls.Add(this._btnMove);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._grpItems);
            this.Controls.Add(this._grpNew);
            this.Controls.Add(this._grpCurrent);
            this.MinimumSize = new System.Drawing.Size(609, 469);
            this.Name = "FRMStockMove";
            this.Text = "Internal Parts Transfer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpCurrent.ResumeLayout(false);
            this._grpNew.ResumeLayout(false);
            this._grpItems.ResumeLayout(false);
            this._grpItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgItems)).EndInit();
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            var argc = cboLocationCurrent;
            Combo.SetUpCombo(ref argc, App.DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Entity.Sys.Enums.ComboValues.None);
            if (cboLocationCurrent.Items.Count > 0)
                cboLocationCurrent.SelectedIndex = 0;
            ShowStock(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboLocationCurrent)), 0);
            var argc1 = cboLocationNew;
            Combo.SetUpCombo(ref argc1, App.DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Entity.Sys.Enums.ComboValues.None);
            if (cboLocationNew.Items.Count > 0)
                cboLocationNew.SelectedIndex = 0;
            SetupDatagrid();
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

        private int CurrentQty = 1;
        private DataView _StockDataView = null;

        public DataView StockDataView
        {
            get
            {
                return _StockDataView;
            }

            set
            {
                _StockDataView = value;
                _StockDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString();
                _StockDataView.AllowNew = false;
                _StockDataView.AllowEdit = false;
                _StockDataView.AllowDelete = false;
                dgItems.DataSource = StockDataView;
            }
        }

        private DataRow SelectedStockDataRow
        {
            get
            {
                if (!(dgItems.CurrentRowIndex == -1))
                {
                    return StockDataView[dgItems.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        public void SetupDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgItems);
            var tStyle = dgItems.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            tStyle.ReadOnly = false;
            tStyle.AllowSorting = false;
            dgItems.ReadOnly = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Select";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tStyle.GridColumnStyles.Add(Tick);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 75;
            Type.NullText = "";
            tStyle.GridColumnStyles.Add(Type);
            var Description = new DataGridLabelColumn();
            Description.Format = "";
            Description.FormatInfo = null;
            Description.HeaderText = "Description";
            Description.MappingName = "Description";
            Description.ReadOnly = true;
            Description.Width = 180;
            Description.NullText = "";
            tStyle.GridColumnStyles.Add(Description);
            var Number = new DataGridLabelColumn();
            Number.Format = "";
            Number.FormatInfo = null;
            Number.HeaderText = "Number";
            Number.MappingName = "Number";
            Number.ReadOnly = true;
            Number.Width = 140;
            Number.NullText = "";
            tStyle.GridColumnStyles.Add(Number);
            var Reference = new DataGridLabelColumn();
            Reference.Format = "";
            Reference.FormatInfo = null;
            Reference.HeaderText = "Reference";
            Reference.MappingName = "Reference";
            Reference.ReadOnly = true;
            Reference.Width = 200;
            Reference.NullText = "";
            tStyle.GridColumnStyles.Add(Reference);
            var Amount = new DataGridLabelColumn();
            Amount.Format = "";
            Amount.FormatInfo = null;
            Amount.HeaderText = "Amount";
            Amount.MappingName = "Amount";
            Amount.ReadOnly = true;
            Amount.Width = 120;
            Amount.NullText = "";
            tStyle.GridColumnStyles.Add(Amount);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblStock.ToString();
            dgItems.TableStyles.Add(tStyle);
        }

        private void FRMStockMove_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void dgItems_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedStockDataRow is null)
            {
                return;
            }

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedStockDataRow["Type"], "PART", false)))
            {
                App.ShowForm(typeof(FRMPart), true, new object[] { SelectedStockDataRow["ID"], true });
                ShowStock(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboLocationCurrent)), 0);
            }
        }

        private void radWarehouseCurrent_CheckedChanged(object sender, EventArgs e)
        {
            if (radWarehouseCurrent.Checked)
            {
                var argc = cboLocationCurrent;
                Combo.SetUpCombo(ref argc, App.DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Entity.Sys.Enums.ComboValues.None);
                if (cboLocationCurrent.Items.Count > 0)
                {
                    cboLocationCurrent.SelectedIndex = 0;
                    ShowStock(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboLocationCurrent)), 0);
                }
            }
        }

        private void radVanCurrent_CheckedChanged(object sender, EventArgs e)
        {
            if (radVanCurrent.Checked)
            {
                var argc = cboLocationCurrent;
                Combo.SetUpCombo(ref argc, App.DB.Van.Van_GetAll(false).Table, "VanID", "Registration", Entity.Sys.Enums.ComboValues.None);
                if (cboLocationCurrent.Items.Count > 0)
                {
                    cboLocationCurrent.SelectedIndex = 0;
                    ShowStock(0, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboLocationCurrent)));
                }
            }
        }

        private void radWarehouseNew_CheckedChanged(object sender, EventArgs e)
        {
            if (radWarehouseNew.Checked)
            {
                var argc = cboLocationNew;
                Combo.SetUpCombo(ref argc, App.DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Entity.Sys.Enums.ComboValues.None);
                if (cboLocationNew.Items.Count > 0)
                {
                    cboLocationNew.SelectedIndex = 0;
                }
            }
        }

        private void radVanNew_CheckedChanged(object sender, EventArgs e)
        {
            if (radVanNew.Checked)
            {
                var argc = cboLocationNew;
                Combo.SetUpCombo(ref argc, App.DB.Van.Van_GetAll(false).Table, "VanID", "Registration", Entity.Sys.Enums.ComboValues.None);
                if (cboLocationNew.Items.Count > 0)
                {
                    cboLocationNew.SelectedIndex = 0;
                }
            }
        }

        private void cboLocationCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radWarehouseCurrent.Checked)
            {
                ShowStock(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboLocationCurrent)), 0);
            }
            else
            {
                ShowStock(0, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboLocationCurrent)));
            }
        }

        private void txtQuantity_GotFocus(object sender, EventArgs e)
        {
            CurrentQty = Conversions.ToInteger(txtQuantity.Text.Trim());
            txtQuantity.Text = "";
        }

        private void txtQuantity_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (Entity.Sys.Helper.IsValidInteger(txtQuantity.Text.Trim()))
                {
                    CurrentQty = Conversions.ToInteger(txtQuantity.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                // DO NOTHING
            }

            txtQuantity.Text = CurrentQty.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            if (SelectedStockDataRow is null)
            {
                App.ShowMessage("Please select an item to move", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (radWarehouseCurrent.Checked & radWarehouseNew.Checked)
            {
                if ((Combo.get_GetSelectedItemValue(cboLocationCurrent) ?? "") == (Combo.get_GetSelectedItemValue(cboLocationNew) ?? ""))
                {
                    App.ShowMessage("You are attempting to move stock to the same place", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (radVanCurrent.Checked & radVanNew.Checked)
            {
                if ((Combo.get_GetSelectedItemValue(cboLocationCurrent) ?? "") == (Combo.get_GetSelectedItemValue(cboLocationNew) ?? ""))
                {
                    App.ShowMessage("You are attempting to move stock to the same place", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // lets check to see if we are moving multiple or individual part
            bool mulitple = false;
            int selectedCount = 0;
            foreach (DataRow dr in StockDataView.Table.Rows)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Select"], true, false)))
                {
                    selectedCount += 1;
                    if (selectedCount > 1)
                    {
                        mulitple = true;
                        break;
                    }
                }
            }
            if (!mulitple & CurrentQty > (int)SelectedStockDataRow["Amount"])
            {
                if (App.ShowMessage("You are attempting to move more than there is available" + Constants.vbCrLf + "This will result in negative stock" + Constants.vbCrLf + "Are you sure you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            int LocationID = 0;
            foreach (DataRow row in App.DB.Location.Locations_GetAll().Table.Rows)
            {
                if (radWarehouseNew.Checked)
                {
                    if (Entity.Sys.Helper.MakeIntegerValid(row["WarehouseID"]) == Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboLocationNew)))
                    {
                        LocationID = Conversions.ToInteger(row["LocationID"]);
                        break;
                    }
                }
                else if (Entity.Sys.Helper.MakeIntegerValid(row["VanID"]) == Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboLocationNew)))
                {
                    LocationID = Conversions.ToInteger(row["LocationID"]);
                    break;
                }
            }

            if (LocationID == 0)
            {
                App.ShowMessage("Location being moved to could not be determined", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (mulitple)
            {
                if (App.ShowMessage("You are about to mulitple parts/products from '" + Combo.get_GetSelectedItemDescription(cboLocationCurrent) + "' to '" + Combo.get_GetSelectedItemDescription(cboLocationNew) + "'. Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                foreach (DataRow dr in StockDataView.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Select"], true, false) & (int)dr["Amount"] > 0))
                    {
                        MovePart(dr, Conversions.ToInteger(dr["Amount"]), LocationID);
                    }
                }
            }
            else
            {
                if (App.ShowMessage(Conversions.ToString("You are about to move " + CurrentQty + " '" + SelectedStockDataRow["Description"] + "' from '" + Combo.get_GetSelectedItemDescription(cboLocationCurrent) + "' to '" + Combo.get_GetSelectedItemDescription(cboLocationNew) + "'. Are you sure?"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                MovePart(SelectedStockDataRow, CurrentQty, LocationID);
            }

            if (radWarehouseCurrent.Checked)
            {
                ShowStock(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboLocationCurrent)), 0);
            }
            else
            {
                ShowStock(0, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboLocationCurrent)));
            }

            string whereClause = "";
            if (!(txtFilter.Text.Trim().Length == 0))
            {
                whereClause += "(Description LIKE '%" + txtFilter.Text.Trim() + "%' ";
                whereClause += "OR Number LIKE '%" + txtFilter.Text.Trim() + "%' ";
                whereClause += "OR Reference LIKE '%" + txtFilter.Text.Trim() + "%')";
            }

            StockDataView.RowFilter = whereClause;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (StockDataView is null)
            {
                return;
            }

            if (StockDataView.Table is null)
            {
                return;
            }

            string whereClause = "";
            if (!(txtFilter.Text.Trim().Length == 0))
            {
                whereClause += "(Description LIKE '%" + txtFilter.Text.Trim() + "%' ";
                whereClause += "OR Number LIKE '%" + txtFilter.Text.Trim() + "%' ";
                whereClause += "OR Reference LIKE '%" + txtFilter.Text.Trim() + "%')";
            }

            StockDataView.RowFilter = whereClause;
        }

        private void ShowStock(int WarehouseID, int VanID)
        {
            var dt = new DataTable();
            dt.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString();
            dt.Columns.Add(new DataColumn("Select", typeof(bool)));
            dt.Columns.Add(new DataColumn("Type"));
            dt.Columns.Add(new DataColumn("ID", typeof(int)));
            dt.Columns.Add(new DataColumn("LocationID", typeof(int)));
            dt.Columns.Add(new DataColumn("Description"));
            dt.Columns.Add(new DataColumn("Number"));
            dt.Columns.Add(new DataColumn("Reference"));
            dt.Columns.Add(new DataColumn("Amount", typeof(int)));
            DataRow r;
            if (!(WarehouseID == 0))
            {
                foreach (DataRow row in App.DB.PartTransaction.GetByWarehouse(WarehouseID, true).Table.Rows)
                {
                    r = dt.NewRow();
                    r["Select"] = false;
                    r["Type"] = "PART";
                    r["ID"] = row["PartID"];
                    r["LocationID"] = row["LocationID"];
                    r["Description"] = row["PartName"];
                    r["Number"] = row["PartNumber"];
                    r["Reference"] = row["Reference"];
                    r["Amount"] = row["Amount"];
                    dt.Rows.Add(r);
                }

                foreach (DataRow row in App.DB.ProductTransaction.GetByWarehouse(WarehouseID).Table.Rows)
                {
                    r = dt.NewRow();
                    r["Select"] = false;
                    r["Type"] = "PRODUCT";
                    r["ID"] = row["ProductID"];
                    r["LocationID"] = row["LocationID"];
                    r["Description"] = row["typemakemodel"];
                    r["Number"] = row["ProductNumber"];
                    r["Reference"] = "";
                    r["Amount"] = row["Amount"];
                    dt.Rows.Add(r);
                }
            }
            else
            {
                foreach (DataRow row in App.DB.PartTransaction.GetByVan2(VanID, ForIPT: true).Rows)
                {
                    r = dt.NewRow();
                    r["Select"] = false;
                    r["Type"] = "PART";
                    r["ID"] = row["PartID"];
                    r["LocationID"] = row["LocationID"];
                    r["Description"] = row["PartName"];
                    r["Number"] = row["PartNumber"];
                    r["Reference"] = row["Reference"];
                    r["Amount"] = row["Amount"];
                    dt.Rows.Add(r);
                }

                foreach (DataRow row in App.DB.ProductTransaction.GetByVan(VanID).Table.Rows)
                {
                    r = dt.NewRow();
                    r["Select"] = false;
                    r["Type"] = "PRODUCT";
                    r["ID"] = row["ProductID"];
                    r["LocationID"] = row["LocationID"];
                    r["Description"] = row["typemakemodel"];
                    r["Number"] = row["ProductNumber"];
                    r["Reference"] = "";
                    r["Amount"] = row["Amount"];
                    dt.Rows.Add(r);
                }
            }

            StockDataView = new DataView(dt);
            CurrentQty = 1;
            txtQuantity.Text = CurrentQty.ToString();
            Label2.Visible = true;
            txtQuantity.Visible = true;
            Label4.Visible = false;
        }

        private void dgItems_Click(object sender, EventArgs e)
        {
            Label2.Visible = true;
            txtQuantity.Visible = true;
            Label4.Visible = false;
            if (SelectedStockDataRow is null)
            {
                return;
            }

            bool selected = !Conversions.ToBoolean(dgItems[dgItems.CurrentRowIndex, 0]);
            dgItems[dgItems.CurrentRowIndex, 0] = selected;
            int selectedCount = 0;
            foreach (DataRow dr in StockDataView.Table.Rows)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Select"], true, false)))
                {
                    selectedCount += 1;
                    if (selectedCount > 1)
                    {
                        Label2.Visible = false;
                        txtQuantity.Visible = false;
                        Label4.Visible = true;
                        break;
                    }
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in StockDataView.Table.Select(StockDataView.RowFilter))
                dr["Select"] = true;
            Label2.Visible = false;
            txtQuantity.Visible = false;
            Label4.Visible = true;
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in StockDataView.Table.Rows)
                dr["Select"] = false;
            Label2.Visible = true;
            txtQuantity.Visible = true;
            Label4.Visible = false;
        }

        public void MovePart(DataRow dr, int qty, int locationID)
        {
            int PartID = 0;
            int ProductID = 0;
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Type"], "PART", false)))
            {
                var oPartTransactionOut = new Entity.PartTransactions.PartTransaction();
                oPartTransactionOut.IgnoreExceptionsOnSetMethods = true;
                oPartTransactionOut.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockOut);
                oPartTransactionOut.SetPartID = dr["ID"];
                oPartTransactionOut.SetAmount = -qty;
                oPartTransactionOut.SetLocationID = dr["LocationID"];
                oPartTransactionOut = App.DB.PartTransaction.Insert(oPartTransactionOut);
                var oPartTransactionIn = new Entity.PartTransactions.PartTransaction();
                oPartTransactionIn.IgnoreExceptionsOnSetMethods = true;
                oPartTransactionIn.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockIn);
                oPartTransactionIn.SetPartID = dr["ID"];
                oPartTransactionIn.SetAmount = qty;
                oPartTransactionIn.SetLocationID = locationID;
                oPartTransactionIn = App.DB.PartTransaction.Insert(oPartTransactionIn);
                PartID = Conversions.ToInteger(dr["ID"]);
            }
            else
            {
                var oProductTransactionOut = new Entity.ProductTransactions.ProductTransaction();
                oProductTransactionOut.IgnoreExceptionsOnSetMethods = true;
                oProductTransactionOut.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockOut);
                oProductTransactionOut.SetProductID = dr["ID"];
                oProductTransactionOut.SetAmount = -qty;
                oProductTransactionOut.SetLocationID = dr["LocationID"];
                oProductTransactionOut = App.DB.ProductTransaction.Insert(oProductTransactionOut);
                var oProductTransactionIn = new Entity.ProductTransactions.ProductTransaction();
                oProductTransactionIn.IgnoreExceptionsOnSetMethods = true;
                oProductTransactionIn.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockIn);
                oProductTransactionIn.SetProductID = dr["ID"];
                oProductTransactionIn.SetAmount = qty;
                oProductTransactionIn.SetLocationID = dr;
                oProductTransactionIn = App.DB.ProductTransaction.Insert(oProductTransactionIn);
                ProductID = Conversions.ToInteger(dr["ID"]);
            }

            App.DB.Location.IPT_Audit_Insert(PartID, ProductID, Conversions.ToInteger(dr["LocationID"]), locationID, qty);
        }
    }
}