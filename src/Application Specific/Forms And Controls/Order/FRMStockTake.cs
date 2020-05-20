using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMStockTake : FRMBaseForm, IForm
    {
        public FRMStockTake() : base()
        {
            base.Load += FRMStockTake_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            var argc = cboCategory;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Enums.PickListTypes.PartCategories).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
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
        private GroupBox _grpStockLevels;

        private GroupBox _grpFilterArea;

        private RadioButton _radVans;

        internal RadioButton radVans
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radVans;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radVans != null)
                {
                    _radVans.CheckedChanged -= radVans_CheckedChanged;
                }

                _radVans = value;
                if (_radVans != null)
                {
                    _radVans.CheckedChanged += radVans_CheckedChanged;
                }
            }
        }

        private RadioButton _radWarehouses;

        internal RadioButton radWarehouses
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radWarehouses;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radWarehouses != null)
                {
                    _radWarehouses.CheckedChanged -= radWarehouses_CheckedChanged;
                }

                _radWarehouses = value;
                if (_radWarehouses != null)
                {
                    _radWarehouses.CheckedChanged += radWarehouses_CheckedChanged;
                }
            }
        }

        private ComboBox _cboFilter;

        internal ComboBox cboFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboFilter != null)
                {
                }

                _cboFilter = value;
                if (_cboFilter != null)
                {
                }
            }
        }

        private Button _btnSave;

        internal Button btnSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSave != null)
                {
                    _btnSave.Click -= btnSave_Click;
                }

                _btnSave = value;
                if (_btnSave != null)
                {
                    _btnSave.Click += btnSave_Click;
                }
            }
        }

        private DataGrid _dgStock;

        internal DataGrid dgStock
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgStock;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgStock != null)
                {
                }

                _dgStock = value;
                if (_dgStock != null)
                {
                }
            }
        }

        private Panel _Panel2;

        private Label _lblShow;

        private Label _lblArrow;

        private Button _btnExport;

        private RadioButton _radBothLocations;

        private Label _lblBottomInfo;

        private ComboBox _cboCategory;

        internal ComboBox cboCategory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboCategory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboCategory != null)
                {
                }

                _cboCategory = value;
                if (_cboCategory != null)
                {
                }
            }
        }

        private Label _lblCategory;

        private Button _btnRun;

        private CheckBox _chkLocations;

        internal CheckBox chkLocations
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkLocations;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkLocations != null)
                {
                }

                _chkLocations = value;
                if (_chkLocations != null)
                {
                }
            }
        }

        private TextBox _txtLocationFilter;

        internal TextBox txtLocationFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtLocationFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtLocationFilter != null)
                {
                    _txtLocationFilter.TextChanged -= txtLocationFilter_TextChanged;
                }

                _txtLocationFilter = value;
                if (_txtLocationFilter != null)
                {
                    _txtLocationFilter.TextChanged += txtLocationFilter_TextChanged;
                }
            }
        }

        private Label _lblLocationFilter;

        private Label _lblStockValuation;

        private CheckBox _chkExpectedNotZero;

        internal CheckBox chkExpectedNotZero
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkExpectedNotZero;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkExpectedNotZero != null)
                {
                }

                _chkExpectedNotZero = value;
                if (_chkExpectedNotZero != null)
                {
                }
            }
        }

        private Label _lblPartMpn;

        private TextBox _txtMPN;

        internal TextBox txtMPN
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMPN;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMPN != null)
                {
                    _txtMPN.KeyDown -= txtMPN_TextChanged;
                }

                _txtMPN = value;
                if (_txtMPN != null)
                {
                    _txtMPN.KeyDown += txtMPN_TextChanged;
                }
            }
        }

        private TextBox _txtPrice;

        internal TextBox txtPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPrice != null)
                {
                }

                _txtPrice = value;
                if (_txtPrice != null)
                {
                }
            }
        }

        private Button _btnStockReplenishment;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._dgStock = new System.Windows.Forms.DataGrid();
            this._grpStockLevels = new System.Windows.Forms.GroupBox();
            this._txtPrice = new System.Windows.Forms.TextBox();
            this._lblStockValuation = new System.Windows.Forms.Label();
            this._txtLocationFilter = new System.Windows.Forms.TextBox();
            this._lblLocationFilter = new System.Windows.Forms.Label();
            this._grpFilterArea = new System.Windows.Forms.GroupBox();
            this._txtMPN = new System.Windows.Forms.TextBox();
            this._lblPartMpn = new System.Windows.Forms.Label();
            this._chkExpectedNotZero = new System.Windows.Forms.CheckBox();
            this._chkLocations = new System.Windows.Forms.CheckBox();
            this._btnRun = new System.Windows.Forms.Button();
            this._cboCategory = new System.Windows.Forms.ComboBox();
            this._lblCategory = new System.Windows.Forms.Label();
            this._Panel2 = new System.Windows.Forms.Panel();
            this._radBothLocations = new System.Windows.Forms.RadioButton();
            this._radWarehouses = new System.Windows.Forms.RadioButton();
            this._radVans = new System.Windows.Forms.RadioButton();
            this._lblArrow = new System.Windows.Forms.Label();
            this._cboFilter = new System.Windows.Forms.ComboBox();
            this._lblShow = new System.Windows.Forms.Label();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnExport = new System.Windows.Forms.Button();
            this._lblBottomInfo = new System.Windows.Forms.Label();
            this._btnStockReplenishment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._dgStock)).BeginInit();
            this._grpStockLevels.SuspendLayout();
            this._grpFilterArea.SuspendLayout();
            this._Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dgStock
            // 
            this._dgStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgStock.DataMember = "";
            this._dgStock.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgStock.Location = new System.Drawing.Point(10, 45);
            this._dgStock.Name = "_dgStock";
            this._dgStock.Size = new System.Drawing.Size(884, 332);
            this._dgStock.TabIndex = 8;
            // 
            // _grpStockLevels
            // 
            this._grpStockLevels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpStockLevels.Controls.Add(this._txtPrice);
            this._grpStockLevels.Controls.Add(this._lblStockValuation);
            this._grpStockLevels.Controls.Add(this._txtLocationFilter);
            this._grpStockLevels.Controls.Add(this._lblLocationFilter);
            this._grpStockLevels.Controls.Add(this._dgStock);
            this._grpStockLevels.Location = new System.Drawing.Point(8, 124);
            this._grpStockLevels.Name = "_grpStockLevels";
            this._grpStockLevels.Size = new System.Drawing.Size(903, 385);
            this._grpStockLevels.TabIndex = 1;
            this._grpStockLevels.TabStop = false;
            this._grpStockLevels.Text = "Current Stock Levels";
            // 
            // _txtPrice
            // 
            this._txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtPrice.Location = new System.Drawing.Point(764, 13);
            this._txtPrice.Name = "_txtPrice";
            this._txtPrice.ReadOnly = true;
            this._txtPrice.Size = new System.Drawing.Size(130, 21);
            this._txtPrice.TabIndex = 16;
            // 
            // _lblStockValuation
            // 
            this._lblStockValuation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblStockValuation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblStockValuation.Location = new System.Drawing.Point(652, 16);
            this._lblStockValuation.Name = "_lblStockValuation";
            this._lblStockValuation.Size = new System.Drawing.Size(118, 22);
            this._lblStockValuation.TabIndex = 14;
            this._lblStockValuation.Text = "Stock Valuation";
            // 
            // _txtLocationFilter
            // 
            this._txtLocationFilter.Location = new System.Drawing.Point(100, 17);
            this._txtLocationFilter.Name = "_txtLocationFilter";
            this._txtLocationFilter.Size = new System.Drawing.Size(214, 21);
            this._txtLocationFilter.TabIndex = 11;
            this._txtLocationFilter.TextChanged += new System.EventHandler(this.txtLocationFilter_TextChanged);
            // 
            // _lblLocationFilter
            // 
            this._lblLocationFilter.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblLocationFilter.Location = new System.Drawing.Point(7, 20);
            this._lblLocationFilter.Name = "_lblLocationFilter";
            this._lblLocationFilter.Size = new System.Drawing.Size(105, 22);
            this._lblLocationFilter.TabIndex = 9;
            this._lblLocationFilter.Text = "Location filter";
            // 
            // _grpFilterArea
            // 
            this._grpFilterArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpFilterArea.Controls.Add(this._txtMPN);
            this._grpFilterArea.Controls.Add(this._lblPartMpn);
            this._grpFilterArea.Controls.Add(this._chkExpectedNotZero);
            this._grpFilterArea.Controls.Add(this._chkLocations);
            this._grpFilterArea.Controls.Add(this._btnRun);
            this._grpFilterArea.Controls.Add(this._cboCategory);
            this._grpFilterArea.Controls.Add(this._lblCategory);
            this._grpFilterArea.Controls.Add(this._Panel2);
            this._grpFilterArea.Controls.Add(this._lblShow);
            this._grpFilterArea.Location = new System.Drawing.Point(8, 12);
            this._grpFilterArea.Name = "_grpFilterArea";
            this._grpFilterArea.Size = new System.Drawing.Size(903, 106);
            this._grpFilterArea.TabIndex = 2;
            this._grpFilterArea.TabStop = false;
            this._grpFilterArea.Text = "Filters";
            // 
            // _txtMPN
            // 
            this._txtMPN.Location = new System.Drawing.Point(72, 79);
            this._txtMPN.Name = "_txtMPN";
            this._txtMPN.Size = new System.Drawing.Size(244, 21);
            this._txtMPN.TabIndex = 14;
            this._txtMPN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMPN_TextChanged);
            // 
            // _lblPartMpn
            // 
            this._lblPartMpn.AutoSize = true;
            this._lblPartMpn.Location = new System.Drawing.Point(9, 82);
            this._lblPartMpn.Name = "_lblPartMpn";
            this._lblPartMpn.Size = new System.Drawing.Size(58, 13);
            this._lblPartMpn.TabIndex = 13;
            this._lblPartMpn.Text = "Part MPN";
            // 
            // _chkExpectedNotZero
            // 
            this._chkExpectedNotZero.AutoSize = true;
            this._chkExpectedNotZero.Location = new System.Drawing.Point(334, 77);
            this._chkExpectedNotZero.Name = "_chkExpectedNotZero";
            this._chkExpectedNotZero.Size = new System.Drawing.Size(259, 17);
            this._chkExpectedNotZero.TabIndex = 12;
            this._chkExpectedNotZero.Text = "Only show parts where expected is not 0";
            this._chkExpectedNotZero.UseVisualStyleBackColor = true;
            // 
            // _chkLocations
            // 
            this._chkLocations.AutoSize = true;
            this._chkLocations.Checked = true;
            this._chkLocations.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkLocations.Location = new System.Drawing.Point(334, 57);
            this._chkLocations.Name = "_chkLocations";
            this._chkLocations.Size = new System.Drawing.Size(225, 17);
            this._chkLocations.TabIndex = 11;
            this._chkLocations.Text = "Only show parts with a location set";
            this._chkLocations.UseVisualStyleBackColor = true;
            // 
            // _btnRun
            // 
            this._btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnRun.Location = new System.Drawing.Point(840, 78);
            this._btnRun.Name = "_btnRun";
            this._btnRun.Size = new System.Drawing.Size(56, 25);
            this._btnRun.TabIndex = 10;
            this._btnRun.Text = "Run";
            this._btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // _cboCategory
            // 
            this._cboCategory.Location = new System.Drawing.Point(72, 53);
            this._cboCategory.Name = "_cboCategory";
            this._cboCategory.Size = new System.Drawing.Size(244, 21);
            this._cboCategory.TabIndex = 9;
            // 
            // _lblCategory
            // 
            this._lblCategory.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblCategory.Location = new System.Drawing.Point(9, 51);
            this._lblCategory.Name = "_lblCategory";
            this._lblCategory.Size = new System.Drawing.Size(64, 22);
            this._lblCategory.TabIndex = 8;
            this._lblCategory.Text = "Category";
            // 
            // _Panel2
            // 
            this._Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._Panel2.Controls.Add(this._radBothLocations);
            this._Panel2.Controls.Add(this._radWarehouses);
            this._Panel2.Controls.Add(this._radVans);
            this._Panel2.Controls.Add(this._lblArrow);
            this._Panel2.Controls.Add(this._cboFilter);
            this._Panel2.Location = new System.Drawing.Point(62, 14);
            this._Panel2.Name = "_Panel2";
            this._Panel2.Size = new System.Drawing.Size(835, 32);
            this._Panel2.TabIndex = 6;
            // 
            // _radBothLocations
            // 
            this._radBothLocations.Checked = true;
            this._radBothLocations.Location = new System.Drawing.Point(216, 6);
            this._radBothLocations.Name = "_radBothLocations";
            this._radBothLocations.Size = new System.Drawing.Size(56, 26);
            this._radBothLocations.TabIndex = 6;
            this._radBothLocations.TabStop = true;
            this._radBothLocations.Text = "Both";
            this._radBothLocations.CheckedChanged += new System.EventHandler(this.radBothLocations_CheckedChanged);
            // 
            // _radWarehouses
            // 
            this._radWarehouses.Location = new System.Drawing.Point(8, 6);
            this._radWarehouses.Name = "_radWarehouses";
            this._radWarehouses.Size = new System.Drawing.Size(96, 26);
            this._radWarehouses.TabIndex = 4;
            this._radWarehouses.Text = "Warehouses";
            this._radWarehouses.CheckedChanged += new System.EventHandler(this.radWarehouses_CheckedChanged);
            // 
            // _radVans
            // 
            this._radVans.Location = new System.Drawing.Point(110, 6);
            this._radVans.Name = "_radVans";
            this._radVans.Size = new System.Drawing.Size(97, 26);
            this._radVans.TabIndex = 5;
            this._radVans.Text = "Stock Profile";
            this._radVans.CheckedChanged += new System.EventHandler(this.radVans_CheckedChanged);
            // 
            // _lblArrow
            // 
            this._lblArrow.Location = new System.Drawing.Point(267, 10);
            this._lblArrow.Name = "_lblArrow";
            this._lblArrow.Size = new System.Drawing.Size(24, 23);
            this._lblArrow.TabIndex = 7;
            this._lblArrow.Text = ">";
            // 
            // _cboFilter
            // 
            this._cboFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboFilter.Location = new System.Drawing.Point(293, 8);
            this._cboFilter.Name = "_cboFilter";
            this._cboFilter.Size = new System.Drawing.Size(534, 21);
            this._cboFilter.TabIndex = 7;
            // 
            // _lblShow
            // 
            this._lblShow.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblShow.Location = new System.Drawing.Point(8, 24);
            this._lblShow.Name = "_lblShow";
            this._lblShow.Size = new System.Drawing.Size(48, 22);
            this._lblShow.TabIndex = 7;
            this._lblShow.Text = "Show";
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSave.Location = new System.Drawing.Point(855, 520);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(56, 25);
            this._btnSave.TabIndex = 3;
            this._btnSave.Text = "Save";
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _btnExport
            // 
            this._btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnExport.Location = new System.Drawing.Point(8, 520);
            this._btnExport.Name = "_btnExport";
            this._btnExport.Size = new System.Drawing.Size(56, 25);
            this._btnExport.TabIndex = 9;
            this._btnExport.Text = "Export";
            this._btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // _lblBottomInfo
            // 
            this._lblBottomInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._lblBottomInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._lblBottomInfo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblBottomInfo.Location = new System.Drawing.Point(180, 520);
            this._lblBottomInfo.Name = "_lblBottomInfo";
            this._lblBottomInfo.Size = new System.Drawing.Size(675, 23);
            this._lblBottomInfo.TabIndex = 5;
            this._lblBottomInfo.Text = "Use last columns to enter ACTUAL STOCK AMOUNT AND REASON then click save";
            this._lblBottomInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _btnStockReplenishment
            // 
            this._btnStockReplenishment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnStockReplenishment.Location = new System.Drawing.Point(72, 520);
            this._btnStockReplenishment.Name = "_btnStockReplenishment";
            this._btnStockReplenishment.Size = new System.Drawing.Size(184, 25);
            this._btnStockReplenishment.TabIndex = 10;
            this._btnStockReplenishment.Text = "Manage Stock Replenishment";
            this._btnStockReplenishment.Click += new System.EventHandler(this.btnStockReplenishment_Click);
            // 
            // FRMStockTake
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(919, 550);
            this.Controls.Add(this._btnStockReplenishment);
            this.Controls.Add(this._lblBottomInfo);
            this.Controls.Add(this._btnExport);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._grpFilterArea);
            this.Controls.Add(this._grpStockLevels);
            this.MinimumSize = new System.Drawing.Size(860, 584);
            this.Name = "FRMStockTake";
            this.Text = "Stock Take";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this._dgStock)).EndInit();
            this._grpStockLevels.ResumeLayout(false);
            this._grpStockLevels.PerformLayout();
            this._grpFilterArea.ResumeLayout(false);
            this._grpFilterArea.PerformLayout();
            this._Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            if (App.IsRFT)
            {
                DvStockTakeReason = App.DB.Location.StockTakeReason_Get();
                var nr = DvStockTakeReason.Table.NewRow();
                nr["StockTakeReasonID"] = 0;
                nr["StockTakeReasonType"] = "-- Select reason --";
                DvStockTakeReason.Table.Rows.InsertAt(nr, 0);
            }

            StockDgSetup();
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
            // DO NOTHING
        }

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
                _StockDataView.AllowNew = false;
                _StockDataView.AllowEdit = true;
                _StockDataView.AllowDelete = false;
                _StockDataView.Table.TableName = Enums.TableNames.tblStock.ToString();
                dgStock.DataSource = StockDataView;
            }
        }

        private DataView _dvStockTakeReason;

        private DataView DvStockTakeReason
        {
            get
            {
                return _dvStockTakeReason;
            }

            set
            {
                _dvStockTakeReason = value;
            }
        }

        public void StockDgSetup()
        {
            var tbStyle = dgStock.TableStyles[0];
            var Category = new DataGridLabelColumn();
            Category.Format = "";
            Category.FormatInfo = null;
            Category.HeaderText = "Category";
            Category.MappingName = "Category";
            Category.ReadOnly = true;
            Category.Width = 200;
            Category.NullText = "";
            tbStyle.GridColumnStyles.Add(Category);
            var partName = new DataGridLabelColumn();
            partName.Format = "";
            partName.FormatInfo = null;
            partName.HeaderText = "Name";
            partName.MappingName = "Name";
            partName.ReadOnly = true;
            partName.Width = 200;
            partName.NullText = "";
            tbStyle.GridColumnStyles.Add(partName);
            var partNumber = new DataGridLabelColumn();
            partNumber.Format = "";
            partNumber.FormatInfo = null;
            partNumber.HeaderText = "Number";
            partNumber.MappingName = "Number";
            partNumber.ReadOnly = true;
            partNumber.Width = 100;
            partNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(partNumber);
            var PartReference = new DataGridLabelColumn();
            PartReference.Format = "";
            PartReference.FormatInfo = null;
            PartReference.HeaderText = "Reference";
            PartReference.MappingName = "Reference";
            PartReference.ReadOnly = true;
            PartReference.Width = 100;
            PartReference.NullText = "";
            tbStyle.GridColumnStyles.Add(PartReference);
            var Cost = new DataGridLabelColumn();
            Cost.Format = "c";
            Cost.FormatInfo = null;
            Cost.HeaderText = "Unit Cost";
            Cost.MappingName = "Cost";
            Cost.ReadOnly = true;
            Cost.Width = 80;
            Cost.NullText = "";
            tbStyle.GridColumnStyles.Add(Cost);
            var Location = new DataGridLabelColumn();
            Location.Format = "";
            Location.FormatInfo = null;
            Location.HeaderText = "Location";
            Location.MappingName = "Location";
            Location.ReadOnly = true;
            Location.Width = 100;
            Location.NullText = "";
            tbStyle.GridColumnStyles.Add(Location);
            var Amount = new DataGridLabelColumn();
            Amount.Format = "";
            Amount.FormatInfo = null;
            Amount.HeaderText = "Expected";
            Amount.MappingName = "Amount";
            Amount.ReadOnly = true;
            Amount.Width = 80;
            Amount.NullText = "";
            tbStyle.GridColumnStyles.Add(Amount);
            var actualAmount = new DataGridOrderTextBoxColumn();
            actualAmount.Format = "";
            actualAmount.FormatInfo = null;
            actualAmount.HeaderText = "Actual";
            actualAmount.MappingName = "ActualAmount";
            actualAmount.ReadOnly = false;
            actualAmount.Width = 80;
            actualAmount.NullText = "";
            tbStyle.GridColumnStyles.Add(actualAmount);
            if (App.IsRFT)
            {
                var reason = new DataGridComboBoxColumn();
                reason.HeaderText = "Reason";
                reason.MappingName = "Reason";
                reason.ReadOnly = false;
                reason.Width = 250;
                reason.ComboBox.DataSource = DvStockTakeReason;
                reason.ComboBox.DisplayMember = "StockTakeReasonType";
                reason.ComboBox.ValueMember = "StockTakeReasonID";
                tbStyle.GridColumnStyles.Add(reason);
            }

            tbStyle.ReadOnly = false;
            dgStock.ReadOnly = false;
            tbStyle.MappingName = Enums.TableNames.tblStock.ToString();
            dgStock.TableStyles.Add(tbStyle);
        }

        private void FRMStockTake_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void radWarehouses_CheckedChanged(object sender, EventArgs e)
        {
            var argc = cboFilter;
            Combo.SetUpCombo(ref argc, App.DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Enums.ComboValues.No_Filter);
            var argcombo = cboFilter;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            cboFilter.Enabled = true;
        }

        private void radVans_CheckedChanged(object sender, EventArgs e)
        {
            var argc = cboFilter;
            Combo.SetUpCombo(ref argc, App.DB.Van.Van_GetAll(false).Table, "VanID", "Registration", Enums.ComboValues.No_Filter);
            var argcombo = cboFilter;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            cboFilter.Enabled = true;
        }

        private void radBothLocations_CheckedChanged(object sender, EventArgs e)
        {
            var argc = cboFilter;
            Combo.SetUpCombo(ref argc, App.DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Enums.ComboValues.No_Filter);
            var argcombo = cboFilter;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            cboFilter.Enabled = false;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Populate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void btnStockReplenishment_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMStockReplenishment), true, new object[] { false });
            Populate();
        }

        private void txtLocationFilter_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void txtMPN_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Populate();
            }
        }

        private void Filter()
        {
            if (StockDataView is null)
            {
                return;
            }

            string whereClause = "1 = 1 ";
            if (!(txtLocationFilter.Text.Trim().Length == 0))
            {
                whereClause += " AND Location LIKE '%" + Helper.RemoveSpecialCharacters(txtLocationFilter.Text.Trim()) + "%' ";
            }

            whereClause = whereClause.Replace("*", "[*]");
            StockDataView.RowFilter = whereClause;
            CalcValuation();
        }

        private void Populate()
        {
            int WarehouseID = 0;
            int VanID = 0;
            bool ShowOnlyWarehouses = Conversions.ToBoolean(0);
            bool ShowOnlyVans = Conversions.ToBoolean(0);
            if (radWarehouses.Checked)
            {
                WarehouseID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboFilter));
                ShowOnlyWarehouses = Conversions.ToBoolean(1);
            }

            if (radVans.Checked)
            {
                VanID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboFilter));
                ShowOnlyVans = Conversions.ToBoolean(1);
            }

            Cursor.Current = Cursors.WaitCursor;
            if (Strings.Len(txtMPN.Text) == 0)
            {
                StockDataView = App.DB.Location.StockTake_GetAll(chkLocations.Checked, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboCategory)), WarehouseID, VanID, chkExpectedNotZero.Checked, ShowOnlyWarehouses, ShowOnlyVans);
            }
            else
            {
                StockDataView = App.DB.Location.StockTake_GetAll_WithName(chkLocations.Checked, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboCategory)), WarehouseID, VanID, chkExpectedNotZero.Checked, ShowOnlyWarehouses, ShowOnlyVans, txtMPN.Text);
            }

            CalcValuation();
            Cursor.Current = Cursors.Default;
        }

        private void Save()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string errString = "";
                bool valid = true;
                var drChangedAmounts = StockDataView.Table.AsEnumerable().Where(x => !Helper.IsStringEmpty(x["actualAmount"])).ToArray();
                foreach (DataRow row in drChangedAmounts)
                {
                    if (!(Conversions.ToString(row["actualAmount"]).Trim().Length == 0))
                    {
                        if (!Helper.IsValidInteger(row["actualAmount"]))
                        {
                            valid = false;
                            if (Conversions.ToInteger(row["PartID"]) > 0)
                            {
                                errString += Conversions.ToString("Amount for part '" + row["Number"] + "' in '") + row["Location"] + "' is invalid" + Constants.vbCrLf;
                            }
                            else
                            {
                                errString += Conversions.ToString("Amount for product '" + row["Number"] + "' in '") + row["Location"] + "' is invalid" + Constants.vbCrLf;
                            }
                        }

                        if (App.IsRFT && !(Helper.MakeIntegerValid(row["Reason"]) > 0) && Helper.MakeIntegerValid(row["actualAmount"]) != Helper.MakeIntegerValid(row["Amount"]))
                        {
                            valid = false;
                            if (Conversions.ToInteger(row["PartID"]) > 0)
                            {
                                errString += Conversions.ToString("Reason for part '" + row["Number"] + "' in '") + row["Location"] + "' is missing" + Constants.vbCrLf;
                            }
                            else
                            {
                                errString += Conversions.ToString("Reason for product '" + row["Number"] + "' in '") + row["Location"] + "' is missing" + Constants.vbCrLf;
                            }
                        }
                    }
                }

                if (!valid)
                {
                    string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                    msg = string.Format(msg, Constants.vbNewLine, errString);
                    App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (App.ShowMessage("Perform stock adjustments now?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                foreach (DataRow row in drChangedAmounts)
                {
                    if (Helper.IsValidInteger(row["actualAmount"]))
                    {
                        if (!(Conversions.ToInteger(row["PartID"]) == 0))
                        {
                            App.DB.PartTransaction.PartTransaction_Consolidate_All(Conversions.ToInteger(row["LocationID"]), Conversions.ToInteger(row["PartID"]));
                            var oPartTransaction = new Entity.PartTransactions.PartTransaction();
                            oPartTransaction.SetLocationID = row["LocationID"];
                            oPartTransaction.SetAmount = Convert.ToInt32(row["actualAmount"]) - (int)row["Amount"];
                            oPartTransaction.SetPartID = row["PartID"];
                            oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockAdjustment);
                            App.DB.PartTransaction.Insert(oPartTransaction);
                        }
                        else
                        {
                            App.DB.ProductTransaction.ProductTransaction_Consolidate_All(Conversions.ToInteger(row["LocationID"]), Conversions.ToInteger(row["ProductID"]));
                            var oProductTransaction = new Entity.ProductTransactions.ProductTransaction();
                            oProductTransaction.SetLocationID = row["LocationID"];
                            oProductTransaction.SetAmount = Convert.ToInt32(row["actualAmount"]) - (int)row["Amount"];
                            oProductTransaction.SetProductID = row["ProductID"];
                            oProductTransaction.SetTransactionTypeID = Conversions.ToInteger(Enums.Transaction.StockAdjustment);
                            App.DB.ProductTransaction.Insert(oProductTransaction);
                        }

                        if (App.IsRFT)
                        {
                            var oStockTakeAudit = new Entity.StockTakeAudit();
                            oStockTakeAudit.SetPartID = row["PartID"];
                            oStockTakeAudit.SetOriginalAmount = row["Amount"];
                            oStockTakeAudit.SetNewAmount = Convert.ToInt32(row["actualAmount"]);
                            oStockTakeAudit.SetReasonChange = Conversions.ToInteger(row["Reason"]);
                            oStockTakeAudit.SetLocationID = row["LocationID"];
                            App.DB.StockTakeAudit.Insert(oStockTakeAudit);
                        }
                    }
                }

                Populate();
            }
            catch (Exception ex)
            {
                App.ShowMessage("Could not perform stock adjustments : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void Export()
        {
            if (StockDataView is null)
            {
                return;
            }

            var exportData = new DataTable();
            exportData.Columns.Add("Category");
            exportData.Columns.Add("Location");
            exportData.Columns.Add("Name");
            exportData.Columns.Add("Number");
            exportData.Columns.Add("Reference");
            exportData.Columns.Add("Cost");
            exportData.Columns.Add("MinQty");
            exportData.Columns.Add("MaxQty");
            exportData.Columns.Add("Amount Expected");
            exportData.Columns.Add("Actual Amount");
            foreach (DataRow row in StockDataView.Table.Rows)
            {
                DataRow newRw;
                newRw = exportData.NewRow();
                newRw["Category"] = row["Category"];
                newRw["Location"] = row["Location"];
                newRw["Name"] = row["Name"];
                newRw["Number"] = row["Number"];
                newRw["Reference"] = row["Reference"];
                newRw["Cost"] = row["Cost"];
                newRw["Amount Expected"] = row["Amount"];
                newRw["Actual Amount"] = row["ActualAmount"];
                newRw["MinQty"] = row["MinQty"];
                newRw["MaxQty"] = row["RecQty"];
                exportData.Rows.Add(newRw);
            }

            ExportHelper.Export(exportData, "Stock Take", Enums.ExportType.XLS);
        }

        public void CalcValuation()
        {
            double valuation = 0.00;
            foreach (DataRowView row in StockDataView)
            {
                double stockAmount = Helper.MakeDoubleValid(row["Amount"]);
                if (stockAmount > 0)
                {
                    valuation += Helper.MakeDoubleValid(row["Cost"]) * stockAmount;
                }
            }

            txtPrice.Text = Math.Round(valuation, 2, MidpointRounding.AwayFromZero).ToString("C");
        }
    }
}