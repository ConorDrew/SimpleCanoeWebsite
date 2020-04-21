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
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMStockMove() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        internal GroupBox grpCurrent
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpCurrent;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpCurrent != null)
                {
                }

                _grpCurrent = value;
                if (_grpCurrent != null)
                {
                }
            }
        }

        private GroupBox _grpNew;

        internal GroupBox grpNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpNew != null)
                {
                }

                _grpNew = value;
                if (_grpNew != null)
                {
                }
            }
        }

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

        internal GroupBox grpItems
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpItems;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpItems != null)
                {
                }

                _grpItems = value;
                if (_grpItems != null)
                {
                }
            }
        }

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

        internal Button btnMove
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnMove;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnMove != null)
                {
                    _btnMove.Click -= btnMove_Click;
                }

                _btnMove = value;
                if (_btnMove != null)
                {
                    _btnMove.Click += btnMove_Click;
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

        internal Button btnSelectAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSelectAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSelectAll != null)
                {
                    _btnSelectAll.Click -= btnSelectAll_Click;
                }

                _btnSelectAll = value;
                if (_btnSelectAll != null)
                {
                    _btnSelectAll.Click += btnSelectAll_Click;
                }
            }
        }

        private Button _btnDeselectAll;

        internal Button btnDeselectAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDeselectAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeselectAll != null)
                {
                    _btnDeselectAll.Click -= btnDeselectAll_Click;
                }

                _btnDeselectAll = value;
                if (_btnDeselectAll != null)
                {
                    _btnDeselectAll.Click += btnDeselectAll_Click;
                }
            }
        }

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
            _radWarehouseCurrent = new RadioButton();
            _radWarehouseCurrent.CheckedChanged += new EventHandler(radWarehouseCurrent_CheckedChanged);
            _radVanCurrent = new RadioButton();
            _radVanCurrent.CheckedChanged += new EventHandler(radVanCurrent_CheckedChanged);
            _Label5 = new Label();
            _cboLocationCurrent = new ComboBox();
            _cboLocationCurrent.SelectedIndexChanged += new EventHandler(cboLocationCurrent_SelectedIndexChanged);
            _grpCurrent = new GroupBox();
            _grpNew = new GroupBox();
            _radWarehouseNew = new RadioButton();
            _radWarehouseNew.CheckedChanged += new EventHandler(radWarehouseNew_CheckedChanged);
            _Label1 = new Label();
            _radVanNew = new RadioButton();
            _radVanNew.CheckedChanged += new EventHandler(radVanNew_CheckedChanged);
            _cboLocationNew = new ComboBox();
            _grpItems = new GroupBox();
            _Label4 = new Label();
            _btnSelectAll = new Button();
            _btnSelectAll.Click += new EventHandler(btnSelectAll_Click);
            _btnDeselectAll = new Button();
            _btnDeselectAll.Click += new EventHandler(btnDeselectAll_Click);
            _txtFilter = new TextBox();
            _txtFilter.TextChanged += new EventHandler(txtFilter_TextChanged);
            _Label3 = new Label();
            _txtQuantity = new TextBox();
            _txtQuantity.GotFocus += new EventHandler(txtQuantity_GotFocus);
            _txtQuantity.Validating += new System.ComponentModel.CancelEventHandler(txtQuantity_Validating);
            _Label2 = new Label();
            _dgItems = new DataGrid();
            _dgItems.DoubleClick += new EventHandler(dgItems_DoubleClick);
            _dgItems.Click += new EventHandler(dgItems_Click);
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _btnMove = new Button();
            _btnMove.Click += new EventHandler(btnMove_Click);
            _grpCurrent.SuspendLayout();
            _grpNew.SuspendLayout();
            _grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgItems).BeginInit();
            SuspendLayout();
            //
            // radWarehouseCurrent
            //
            _radWarehouseCurrent.Checked = true;
            _radWarehouseCurrent.Location = new Point(8, 20);
            _radWarehouseCurrent.Name = "radWarehouseCurrent";
            _radWarehouseCurrent.Size = new Size(96, 26);
            _radWarehouseCurrent.TabIndex = 1;
            _radWarehouseCurrent.TabStop = true;
            _radWarehouseCurrent.Text = "Warehouse";
            //
            // radVanCurrent
            //
            _radVanCurrent.Location = new Point(110, 20);
            _radVanCurrent.Name = "radVanCurrent";
            _radVanCurrent.Size = new Size(99, 26);
            _radVanCurrent.TabIndex = 2;
            _radVanCurrent.Text = "Stock Profile";
            //
            // Label5
            //
            _Label5.Location = new Point(214, 25);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(24, 23);
            _Label5.TabIndex = 7;
            _Label5.Text = ">";
            //
            // cboLocationCurrent
            //
            _cboLocationCurrent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboLocationCurrent.Location = new Point(247, 25);
            _cboLocationCurrent.Name = "cboLocationCurrent";
            _cboLocationCurrent.Size = new Size(337, 21);
            _cboLocationCurrent.TabIndex = 3;
            //
            // grpCurrent
            //
            _grpCurrent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpCurrent.Controls.Add(_radWarehouseCurrent);
            _grpCurrent.Controls.Add(_Label5);
            _grpCurrent.Controls.Add(_radVanCurrent);
            _grpCurrent.Controls.Add(_cboLocationCurrent);
            _grpCurrent.Location = new Point(4, 38);
            _grpCurrent.Name = "grpCurrent";
            _grpCurrent.Size = new Size(592, 58);
            _grpCurrent.TabIndex = 1;
            _grpCurrent.TabStop = false;
            _grpCurrent.Text = "Select current stock location";
            //
            // grpNew
            //
            _grpNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _grpNew.Controls.Add(_radWarehouseNew);
            _grpNew.Controls.Add(_Label1);
            _grpNew.Controls.Add(_radVanNew);
            _grpNew.Controls.Add(_cboLocationNew);
            _grpNew.Location = new Point(4, 337);
            _grpNew.Name = "grpNew";
            _grpNew.Size = new Size(592, 58);
            _grpNew.TabIndex = 3;
            _grpNew.TabStop = false;
            _grpNew.Text = "Select new stock location";
            //
            // radWarehouseNew
            //
            _radWarehouseNew.Checked = true;
            _radWarehouseNew.Location = new Point(8, 20);
            _radWarehouseNew.Name = "radWarehouseNew";
            _radWarehouseNew.Size = new Size(96, 26);
            _radWarehouseNew.TabIndex = 1;
            _radWarehouseNew.TabStop = true;
            _radWarehouseNew.Text = "Warehouse";
            //
            // Label1
            //
            _Label1.Location = new Point(214, 23);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(24, 23);
            _Label1.TabIndex = 7;
            _Label1.Text = ">";
            //
            // radVanNew
            //
            _radVanNew.Location = new Point(110, 20);
            _radVanNew.Name = "radVanNew";
            _radVanNew.Size = new Size(98, 26);
            _radVanNew.TabIndex = 2;
            _radVanNew.Text = "Stock Profile";
            //
            // cboLocationNew
            //
            _cboLocationNew.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboLocationNew.Location = new Point(247, 25);
            _cboLocationNew.Name = "cboLocationNew";
            _cboLocationNew.Size = new Size(337, 21);
            _cboLocationNew.TabIndex = 3;
            //
            // grpItems
            //
            _grpItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpItems.Controls.Add(_Label4);
            _grpItems.Controls.Add(_btnSelectAll);
            _grpItems.Controls.Add(_btnDeselectAll);
            _grpItems.Controls.Add(_txtFilter);
            _grpItems.Controls.Add(_Label3);
            _grpItems.Controls.Add(_txtQuantity);
            _grpItems.Controls.Add(_Label2);
            _grpItems.Controls.Add(_dgItems);
            _grpItems.Location = new Point(4, 102);
            _grpItems.Name = "grpItems";
            _grpItems.Size = new Size(592, 229);
            _grpItems.TabIndex = 2;
            _grpItems.TabStop = false;
            _grpItems.Text = "Select item to move";
            //
            // Label4
            //
            _Label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label4.Location = new Point(295, 201);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(255, 14);
            _Label4.TabIndex = 23;
            _Label4.Text = "The current quantity will be moved across";
            _Label4.Visible = false;
            //
            // btnSelectAll
            //
            _btnSelectAll.AccessibleDescription = "Export Job List To Excel";
            _btnSelectAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnSelectAll.Location = new Point(400, 18);
            _btnSelectAll.Name = "btnSelectAll";
            _btnSelectAll.Size = new Size(88, 23);
            _btnSelectAll.TabIndex = 21;
            _btnSelectAll.Text = "Select All";
            //
            // btnDeselectAll
            //
            _btnDeselectAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnDeselectAll.Location = new Point(496, 18);
            _btnDeselectAll.Name = "btnDeselectAll";
            _btnDeselectAll.Size = new Size(88, 23);
            _btnDeselectAll.TabIndex = 22;
            _btnDeselectAll.Text = "Deselect All";
            //
            // txtFilter
            //
            _txtFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtFilter.Location = new Point(48, 20);
            _txtFilter.Name = "txtFilter";
            _txtFilter.Size = new Size(335, 21);
            _txtFilter.TabIndex = 1;
            //
            // Label3
            //
            _Label3.Location = new Point(4, 23);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(51, 18);
            _Label3.TabIndex = 3;
            _Label3.Text = "Filter";
            //
            // txtQuantity
            //
            _txtQuantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtQuantity.Location = new Point(189, 198);
            _txtQuantity.Name = "txtQuantity";
            _txtQuantity.Size = new Size(100, 21);
            _txtQuantity.TabIndex = 3;
            _txtQuantity.Text = "1";
            //
            // Label2
            //
            _Label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label2.Location = new Point(6, 201);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(177, 16);
            _Label2.TabIndex = 1;
            _Label2.Text = "Enter quantity being moved";
            //
            // dgItems
            //
            _dgItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgItems.DataMember = "";
            _dgItems.HeaderForeColor = SystemColors.ControlText;
            _dgItems.Location = new Point(6, 47);
            _dgItems.Name = "dgItems";
            _dgItems.Size = new Size(580, 145);
            _dgItems.TabIndex = 2;
            //
            // btnClose
            //
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.Location = new Point(4, 401);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(59, 23);
            _btnClose.TabIndex = 5;
            _btnClose.Text = "Close";
            _btnClose.UseVisualStyleBackColor = true;
            //
            // btnMove
            //
            _btnMove.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnMove.Location = new Point(537, 401);
            _btnMove.Name = "btnMove";
            _btnMove.Size = new Size(59, 23);
            _btnMove.TabIndex = 4;
            _btnMove.Text = "Move";
            _btnMove.UseVisualStyleBackColor = true;
            //
            // FRMStockMove
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(601, 435);
            Controls.Add(_btnMove);
            Controls.Add(_btnClose);
            Controls.Add(_grpItems);
            Controls.Add(_grpNew);
            Controls.Add(_grpCurrent);
            MinimumSize = new Size(609, 469);
            Name = "FRMStockMove";
            Text = "Internal Parts Transfer";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpCurrent, 0);
            Controls.SetChildIndex(_grpNew, 0);
            Controls.SetChildIndex(_grpItems, 0);
            Controls.SetChildIndex(_btnClose, 0);
            Controls.SetChildIndex(_btnMove, 0);
            _grpCurrent.ResumeLayout(false);
            _grpNew.ResumeLayout(false);
            _grpItems.ResumeLayout(false);
            _grpItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgItems).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

            if (Conversions.ToBoolean(!mulitple & CurrentQty > (int)SelectedStockDataRow["Amount"]))
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void ShowStock(int WarehouseID, int VanID)
        {
            var dt = new DataTable();
            dt.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString();
            dt.Columns.Add(new DataColumn("Select", typeof(bool)));
            dt.Columns.Add(new DataColumn("Type"));
            dt.Columns.Add(new DataColumn("ID"));
            dt.Columns.Add(new DataColumn("LocationID"));
            dt.Columns.Add(new DataColumn("Description"));
            dt.Columns.Add(new DataColumn("Number"));
            dt.Columns.Add(new DataColumn("Reference"));
            dt.Columns.Add(new DataColumn("Amount"));
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}