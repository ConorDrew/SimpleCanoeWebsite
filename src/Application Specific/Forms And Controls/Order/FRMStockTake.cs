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

        internal GroupBox grpStockLevels
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpStockLevels;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpStockLevels != null)
                {
                }

                _grpStockLevels = value;
                if (_grpStockLevels != null)
                {
                }
            }
        }

        private GroupBox _grpFilterArea;

        internal GroupBox grpFilterArea
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpFilterArea;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpFilterArea != null)
                {
                }

                _grpFilterArea = value;
                if (_grpFilterArea != null)
                {
                }
            }
        }

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

        internal Panel Panel2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel2 != null)
                {
                }

                _Panel2 = value;
                if (_Panel2 != null)
                {
                }
            }
        }

        private Label _lblShow;

        internal Label lblShow
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblShow;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblShow != null)
                {
                }

                _lblShow = value;
                if (_lblShow != null)
                {
                }
            }
        }

        private Label _lblArrow;

        internal Label lblArrow
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblArrow;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblArrow != null)
                {
                }

                _lblArrow = value;
                if (_lblArrow != null)
                {
                }
            }
        }

        private Button _btnExport;

        internal Button btnExport
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnExport;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnExport != null)
                {
                    _btnExport.Click -= btnExport_Click;
                }

                _btnExport = value;
                if (_btnExport != null)
                {
                    _btnExport.Click += btnExport_Click;
                }
            }
        }

        private RadioButton _radBothLocations;

        internal RadioButton radBothLocations
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radBothLocations;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radBothLocations != null)
                {
                    _radBothLocations.CheckedChanged -= radBothLocations_CheckedChanged;
                }

                _radBothLocations = value;
                if (_radBothLocations != null)
                {
                    _radBothLocations.CheckedChanged += radBothLocations_CheckedChanged;
                }
            }
        }

        private Label _lblBottomInfo;

        internal Label lblBottomInfo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblBottomInfo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblBottomInfo != null)
                {
                }

                _lblBottomInfo = value;
                if (_lblBottomInfo != null)
                {
                }
            }
        }

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

        internal Label lblCategory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCategory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCategory != null)
                {
                }

                _lblCategory = value;
                if (_lblCategory != null)
                {
                }
            }
        }

        private Button _btnRun;

        internal Button btnRun
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRun;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRun != null)
                {
                    _btnRun.Click -= btnRun_Click;
                }

                _btnRun = value;
                if (_btnRun != null)
                {
                    _btnRun.Click += btnRun_Click;
                }
            }
        }

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

        internal Label lblLocationFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblLocationFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblLocationFilter != null)
                {
                }

                _lblLocationFilter = value;
                if (_lblLocationFilter != null)
                {
                }
            }
        }

        private Label _lblStockValuation;

        internal Label lblStockValuation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblStockValuation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblStockValuation != null)
                {
                }

                _lblStockValuation = value;
                if (_lblStockValuation != null)
                {
                }
            }
        }

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

        internal Label lblPartMpn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPartMpn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPartMpn != null)
                {
                }

                _lblPartMpn = value;
                if (_lblPartMpn != null)
                {
                }
            }
        }

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

        internal Button btnStockReplenishment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnStockReplenishment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnStockReplenishment != null)
                {
                    _btnStockReplenishment.Click -= btnStockReplenishment_Click;
                }

                _btnStockReplenishment = value;
                if (_btnStockReplenishment != null)
                {
                    _btnStockReplenishment.Click += btnStockReplenishment_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _dgStock = new DataGrid();
            _grpStockLevels = new GroupBox();
            _txtPrice = new TextBox();
            _lblStockValuation = new Label();
            _txtLocationFilter = new TextBox();
            _txtLocationFilter.TextChanged += new EventHandler(txtLocationFilter_TextChanged);
            _lblLocationFilter = new Label();
            _grpFilterArea = new GroupBox();
            _txtMPN = new TextBox();
            _txtMPN.KeyDown += new KeyEventHandler(txtMPN_TextChanged);
            _lblPartMpn = new Label();
            _chkExpectedNotZero = new CheckBox();
            _chkLocations = new CheckBox();
            _btnRun = new Button();
            _btnRun.Click += new EventHandler(btnRun_Click);
            _cboCategory = new ComboBox();
            _lblCategory = new Label();
            _Panel2 = new Panel();
            _radBothLocations = new RadioButton();
            _radBothLocations.CheckedChanged += new EventHandler(radBothLocations_CheckedChanged);
            _radWarehouses = new RadioButton();
            _radWarehouses.CheckedChanged += new EventHandler(radWarehouses_CheckedChanged);
            _radVans = new RadioButton();
            _radVans.CheckedChanged += new EventHandler(radVans_CheckedChanged);
            _lblArrow = new Label();
            _cboFilter = new ComboBox();
            _lblShow = new Label();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _btnExport = new Button();
            _btnExport.Click += new EventHandler(btnExport_Click);
            _lblBottomInfo = new Label();
            _btnStockReplenishment = new Button();
            _btnStockReplenishment.Click += new EventHandler(btnStockReplenishment_Click);
            ((System.ComponentModel.ISupportInitialize)_dgStock).BeginInit();
            _grpStockLevels.SuspendLayout();
            _grpFilterArea.SuspendLayout();
            _Panel2.SuspendLayout();
            SuspendLayout();
            //
            // dgStock
            //
            _dgStock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgStock.DataMember = "";
            _dgStock.HeaderForeColor = SystemColors.ControlText;
            _dgStock.Location = new Point(10, 45);
            _dgStock.Name = "dgStock";
            _dgStock.Size = new Size(884, 296);
            _dgStock.TabIndex = 8;
            //
            // grpStockLevels
            //
            _grpStockLevels.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpStockLevels.Controls.Add(_txtPrice);
            _grpStockLevels.Controls.Add(_lblStockValuation);
            _grpStockLevels.Controls.Add(_txtLocationFilter);
            _grpStockLevels.Controls.Add(_lblLocationFilter);
            _grpStockLevels.Controls.Add(_dgStock);
            _grpStockLevels.Location = new Point(8, 160);
            _grpStockLevels.Name = "grpStockLevels";
            _grpStockLevels.Size = new Size(903, 349);
            _grpStockLevels.TabIndex = 1;
            _grpStockLevels.TabStop = false;
            _grpStockLevels.Text = "Current Stock Levels";
            //
            // txtPrice
            //
            _txtPrice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtPrice.Location = new Point(764, 13);
            _txtPrice.Name = "txtPrice";
            _txtPrice.ReadOnly = true;
            _txtPrice.Size = new Size(130, 21);
            _txtPrice.TabIndex = 16;
            //
            // lblStockValuation
            //
            _lblStockValuation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblStockValuation.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblStockValuation.Location = new Point(652, 16);
            _lblStockValuation.Name = "lblStockValuation";
            _lblStockValuation.Size = new Size(118, 22);
            _lblStockValuation.TabIndex = 14;
            _lblStockValuation.Text = "Stock Valuation";
            //
            // txtLocationFilter
            //
            _txtLocationFilter.Location = new Point(100, 17);
            _txtLocationFilter.Name = "txtLocationFilter";
            _txtLocationFilter.Size = new Size(214, 21);
            _txtLocationFilter.TabIndex = 11;
            //
            // lblLocationFilter
            //
            _lblLocationFilter.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblLocationFilter.Location = new Point(7, 20);
            _lblLocationFilter.Name = "lblLocationFilter";
            _lblLocationFilter.Size = new Size(105, 22);
            _lblLocationFilter.TabIndex = 9;
            _lblLocationFilter.Text = "Location filter";
            //
            // grpFilterArea
            //
            _grpFilterArea.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpFilterArea.Controls.Add(_txtMPN);
            _grpFilterArea.Controls.Add(_lblPartMpn);
            _grpFilterArea.Controls.Add(_chkExpectedNotZero);
            _grpFilterArea.Controls.Add(_chkLocations);
            _grpFilterArea.Controls.Add(_btnRun);
            _grpFilterArea.Controls.Add(_cboCategory);
            _grpFilterArea.Controls.Add(_lblCategory);
            _grpFilterArea.Controls.Add(_Panel2);
            _grpFilterArea.Controls.Add(_lblShow);
            _grpFilterArea.Location = new Point(8, 48);
            _grpFilterArea.Name = "grpFilterArea";
            _grpFilterArea.Size = new Size(903, 106);
            _grpFilterArea.TabIndex = 2;
            _grpFilterArea.TabStop = false;
            _grpFilterArea.Text = "Filters";
            //
            // txtMPN
            //
            _txtMPN.Location = new Point(72, 79);
            _txtMPN.Name = "txtMPN";
            _txtMPN.Size = new Size(244, 21);
            _txtMPN.TabIndex = 14;
            //
            // lblPartMpn
            //
            _lblPartMpn.AutoSize = true;
            _lblPartMpn.Location = new Point(9, 82);
            _lblPartMpn.Name = "lblPartMpn";
            _lblPartMpn.Size = new Size(58, 13);
            _lblPartMpn.TabIndex = 13;
            _lblPartMpn.Text = "Part MPN";
            //
            // chkExpectedNotZero
            //
            _chkExpectedNotZero.AutoSize = true;
            _chkExpectedNotZero.Location = new Point(334, 77);
            _chkExpectedNotZero.Name = "chkExpectedNotZero";
            _chkExpectedNotZero.Size = new Size(259, 17);
            _chkExpectedNotZero.TabIndex = 12;
            _chkExpectedNotZero.Text = "Only show parts where expected is not 0";
            _chkExpectedNotZero.UseVisualStyleBackColor = true;
            //
            // chkLocations
            //
            _chkLocations.AutoSize = true;
            _chkLocations.Checked = true;
            _chkLocations.CheckState = CheckState.Checked;
            _chkLocations.Location = new Point(334, 57);
            _chkLocations.Name = "chkLocations";
            _chkLocations.Size = new Size(225, 17);
            _chkLocations.TabIndex = 11;
            _chkLocations.Text = "Only show parts with a location set";
            _chkLocations.UseVisualStyleBackColor = true;
            //
            // btnRun
            //
            _btnRun.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnRun.Location = new Point(840, 78);
            _btnRun.Name = "btnRun";
            _btnRun.Size = new Size(56, 25);
            _btnRun.TabIndex = 10;
            _btnRun.Text = "Run";
            //
            // cboCategory
            //
            _cboCategory.Location = new Point(72, 53);
            _cboCategory.Name = "cboCategory";
            _cboCategory.Size = new Size(244, 21);
            _cboCategory.TabIndex = 9;
            //
            // lblCategory
            //
            _lblCategory.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblCategory.Location = new Point(9, 51);
            _lblCategory.Name = "lblCategory";
            _lblCategory.Size = new Size(64, 22);
            _lblCategory.TabIndex = 8;
            _lblCategory.Text = "Category";
            //
            // Panel2
            //
            _Panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _Panel2.Controls.Add(_radBothLocations);
            _Panel2.Controls.Add(_radWarehouses);
            _Panel2.Controls.Add(_radVans);
            _Panel2.Controls.Add(_lblArrow);
            _Panel2.Controls.Add(_cboFilter);
            _Panel2.Location = new Point(62, 14);
            _Panel2.Name = "Panel2";
            _Panel2.Size = new Size(835, 32);
            _Panel2.TabIndex = 6;
            //
            // radBothLocations
            //
            _radBothLocations.Checked = true;
            _radBothLocations.Location = new Point(216, 6);
            _radBothLocations.Name = "radBothLocations";
            _radBothLocations.Size = new Size(56, 26);
            _radBothLocations.TabIndex = 6;
            _radBothLocations.TabStop = true;
            _radBothLocations.Text = "Both";
            //
            // radWarehouses
            //
            _radWarehouses.Location = new Point(8, 6);
            _radWarehouses.Name = "radWarehouses";
            _radWarehouses.Size = new Size(96, 26);
            _radWarehouses.TabIndex = 4;
            _radWarehouses.Text = "Warehouses";
            //
            // radVans
            //
            _radVans.Location = new Point(110, 6);
            _radVans.Name = "radVans";
            _radVans.Size = new Size(97, 26);
            _radVans.TabIndex = 5;
            _radVans.Text = "Stock Profile";
            //
            // lblArrow
            //
            _lblArrow.Location = new Point(267, 10);
            _lblArrow.Name = "lblArrow";
            _lblArrow.Size = new Size(24, 23);
            _lblArrow.TabIndex = 7;
            _lblArrow.Text = ">";
            //
            // cboFilter
            //
            _cboFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboFilter.Location = new Point(293, 8);
            _cboFilter.Name = "cboFilter";
            _cboFilter.Size = new Size(534, 21);
            _cboFilter.TabIndex = 7;
            //
            // lblShow
            //
            _lblShow.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblShow.Location = new Point(8, 24);
            _lblShow.Name = "lblShow";
            _lblShow.Size = new Size(48, 22);
            _lblShow.TabIndex = 7;
            _lblShow.Text = "Show";
            //
            // btnSave
            //
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSave.Location = new Point(855, 520);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(56, 25);
            _btnSave.TabIndex = 3;
            _btnSave.Text = "Save";
            //
            // btnExport
            //
            _btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnExport.Location = new Point(8, 520);
            _btnExport.Name = "btnExport";
            _btnExport.Size = new Size(56, 25);
            _btnExport.TabIndex = 9;
            _btnExport.Text = "Export";
            //
            // lblBottomInfo
            //
            _lblBottomInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _lblBottomInfo.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(192)));
            _lblBottomInfo.Font = new Font("Verdana", 10.0F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblBottomInfo.Location = new Point(180, 520);
            _lblBottomInfo.Name = "lblBottomInfo";
            _lblBottomInfo.Size = new Size(675, 23);
            _lblBottomInfo.TabIndex = 5;
            _lblBottomInfo.Text = "Use last columns to enter ACTUAL STOCK AMOUNT AND REASON then click save";
            _lblBottomInfo.TextAlign = ContentAlignment.MiddleCenter;
            //
            // btnStockReplenishment
            //
            _btnStockReplenishment.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnStockReplenishment.Location = new Point(72, 520);
            _btnStockReplenishment.Name = "btnStockReplenishment";
            _btnStockReplenishment.Size = new Size(184, 25);
            _btnStockReplenishment.TabIndex = 10;
            _btnStockReplenishment.Text = "Manage Stock Replenishment";
            //
            // FRMStockTake
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(919, 550);
            Controls.Add(_btnStockReplenishment);
            Controls.Add(_lblBottomInfo);
            Controls.Add(_btnExport);
            Controls.Add(_btnSave);
            Controls.Add(_grpFilterArea);
            Controls.Add(_grpStockLevels);
            MinimumSize = new Size(860, 584);
            Name = "FRMStockTake";
            Text = "Stock Take";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpStockLevels, 0);
            Controls.SetChildIndex(_grpFilterArea, 0);
            Controls.SetChildIndex(_btnSave, 0);
            Controls.SetChildIndex(_btnExport, 0);
            Controls.SetChildIndex(_lblBottomInfo, 0);
            Controls.SetChildIndex(_btnStockReplenishment, 0);
            ((System.ComponentModel.ISupportInitialize)_dgStock).EndInit();
            _grpStockLevels.ResumeLayout(false);
            _grpStockLevels.PerformLayout();
            _grpFilterArea.ResumeLayout(false);
            _grpFilterArea.PerformLayout();
            _Panel2.ResumeLayout(false);
            ResumeLayout(false);
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