using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FSM.Business.Orders;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class TabletOrder : FRMBaseForm, IForm
    {
        public TabletOrder(int EngineerIDin) : base()
        {
            base.Load += TabletOrder_Load;
            base.Load += FrmPartSearch_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            EngineerID = EngineerIDin;
        }

        public TabletOrder(System.Data.SqlClient.SqlTransaction trans) : base()
        {
            base.Load += TabletOrder_Load;
            base.Load += FrmPartSearch_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public TabletOrder() : base()
        {
            base.Load += TabletOrder_Load;
            base.Load += FrmPartSearch_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            switch (true)
            {
                case object _ when App.IsGasway:
                    {
                        var argc = cboCostCentre;
                        Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }

                default:
                    {
                        var argc1 = cboCostCentre;
                        Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }
            }
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

        private Button _btnFindPart;

        internal Button btnFindPart
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindPart;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindPart != null)
                {
                    _btnFindPart.Click -= btnFindPart_Click;
                }

                _btnFindPart = value;
                if (_btnFindPart != null)
                {
                    _btnFindPart.Click += btnFindPart_Click;
                }
            }
        }

        private TextBox _txtPartSearch;

        internal TextBox txtPartSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartSearch != null)
                {
                    _txtPartSearch.KeyDown -= txtPartSearch_KeyDown;
                }

                _txtPartSearch = value;
                if (_txtPartSearch != null)
                {
                    _txtPartSearch.KeyDown += txtPartSearch_KeyDown;
                }
            }
        }

        private Label _lblQty;

        internal Label lblQty
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQty;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQty != null)
                {
                }

                _lblQty = value;
                if (_lblQty != null)
                {
                }
            }
        }

        private Button _btnCreate;

        internal Button btnCreate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCreate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCreate != null)
                {

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _btnCreate.Click -= btnCreate_Click;
                }

                _btnCreate = value;
                if (_btnCreate != null)
                {
                    _btnCreate.Click += btnCreate_Click;
                }
            }
        }

        private Label _lblSearch;

        internal Label lblSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSearch != null)
                {
                }

                _lblSearch = value;
                if (_lblSearch != null)
                {
                }
            }
        }

        private Label _lblSupplier;

        internal Label lblSupplier
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSupplier;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSupplier != null)
                {
                }

                _lblSupplier = value;
                if (_lblSupplier != null)
                {
                }
            }
        }

        private NumericUpDown _nudQty;

        internal NumericUpDown nudQty
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _nudQty;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_nudQty != null)
                {
                }

                _nudQty = value;
                if (_nudQty != null)
                {
                }
            }
        }

        private DataGridView _dgParts;

        internal DataGridView dgParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgParts != null)
                {
                }

                _dgParts = value;
                if (_dgParts != null)
                {
                }
            }
        }

        private Label _lblTopLabel;

        internal Label lblTopLabel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTopLabel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTopLabel != null)
                {
                }

                _lblTopLabel = value;
                if (_lblTopLabel != null)
                {
                }
            }
        }

        private Button _btnAddPart;

        internal Button btnAddPart
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddPart;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddPart != null)
                {
                    _btnAddPart.Click -= btnAddPart_Click;
                }

                _btnAddPart = value;
                if (_btnAddPart != null)
                {
                    _btnAddPart.Click += btnAddPart_Click;
                }
            }
        }

        private RadioButton _rbNo;

        internal RadioButton rbNo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rbNo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rbNo != null)
                {
                }

                _rbNo = value;
                if (_rbNo != null)
                {
                }
            }
        }

        private RadioButton _rbYes;

        internal RadioButton rbYes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rbYes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rbYes != null)
                {
                }

                _rbYes = value;
                if (_rbYes != null)
                {
                }
            }
        }

        private Button _btnBack;

        internal Button btnBack
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnBack;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnBack != null)
                {
                    _btnBack.Click -= btnBack_Click;
                }

                _btnBack = value;
                if (_btnBack != null)
                {
                    _btnBack.Click += btnBack_Click;
                }
            }
        }

        private Panel _pnlFilters;

        internal Panel pnlFilters
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlFilters;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlFilters != null)
                {
                }

                _pnlFilters = value;
                if (_pnlFilters != null)
                {
                }
            }
        }

        private DataGridView _dgvSearch;

        internal DataGridView dgvSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgvSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgvSearch != null)
                {
                    _dgvSearch.CellClick -= DataGridView1_CellContentClick;
                    _dgvSearch.CellDoubleClick -= btnAddPart_Click;
                }

                _dgvSearch = value;
                if (_dgvSearch != null)
                {
                    _dgvSearch.CellClick += DataGridView1_CellContentClick;
                    _dgvSearch.CellDoubleClick += btnAddPart_Click;
                }
            }
        }

        private TextBox _txtSupplier;

        internal TextBox txtSupplier
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSupplier;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSupplier != null)
                {
                }

                _txtSupplier = value;
                if (_txtSupplier != null)
                {
                }
            }
        }

        private Label _lblCostCentre;

        internal Label lblCostCentre
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCostCentre;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCostCentre != null)
                {
                }

                _lblCostCentre = value;
                if (_lblCostCentre != null)
                {
                }
            }
        }

        private ComboBox _cboCostCentre;

        internal ComboBox cboCostCentre
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboCostCentre;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboCostCentre != null)
                {
                }

                _cboCostCentre = value;
                if (_cboCostCentre != null)
                {
                }
            }
        }

        private TextBox _txtNewOrderNumber;

        internal TextBox txtNewOrderNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNewOrderNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNewOrderNumber != null)
                {
                }

                _txtNewOrderNumber = value;
                if (_txtNewOrderNumber != null)
                {
                }
            }
        }

        private Label _lblDate;

        internal Label lblDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDate != null)
                {
                }

                _lblDate = value;
                if (_lblDate != null)
                {
                }
            }
        }

        private DateTimePicker _dtpDatePlaced;

        internal DateTimePicker dtpDatePlaced
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpDatePlaced;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpDatePlaced != null)
                {
                }

                _dtpDatePlaced = value;
                if (_dtpDatePlaced != null)
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
            _btnFindPart = new Button();
            _btnFindPart.Click += new EventHandler(btnFindPart_Click);
            _txtPartSearch = new TextBox();
            _txtPartSearch.KeyDown += new KeyEventHandler(txtPartSearch_KeyDown);
            _lblQty = new Label();
            _btnCreate = new Button();
            _btnCreate.Click += new EventHandler(btnCreate_Click);
            _lblSearch = new Label();
            _lblSupplier = new Label();
            _nudQty = new NumericUpDown();
            _dgParts = new DataGridView();
            _lblTopLabel = new Label();
            _btnAddPart = new Button();
            _btnAddPart.Click += new EventHandler(btnAddPart_Click);
            _rbNo = new RadioButton();
            _rbYes = new RadioButton();
            _btnBack = new Button();
            _btnBack.Click += new EventHandler(btnBack_Click);
            _pnlFilters = new Panel();
            _dtpDatePlaced = new DateTimePicker();
            _lblDate = new Label();
            _cboCostCentre = new ComboBox();
            _lblCostCentre = new Label();
            _txtSupplier = new TextBox();
            _dgvSearch = new DataGridView();
            _dgvSearch.CellClick += new DataGridViewCellEventHandler(DataGridView1_CellContentClick);
            _dgvSearch.CellDoubleClick += new DataGridViewCellEventHandler(btnAddPart_Click);
            _txtNewOrderNumber = new TextBox();
            ((System.ComponentModel.ISupportInitialize)_nudQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_dgParts).BeginInit();
            _pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvSearch).BeginInit();
            SuspendLayout();
            // 
            // btnFindPart
            // 
            _btnFindPart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnFindPart.Location = new Point(856, 105);
            _btnFindPart.Name = "btnFindPart";
            _btnFindPart.Size = new Size(145, 34);
            _btnFindPart.TabIndex = 13;
            _btnFindPart.Text = "Find";
            _btnFindPart.UseVisualStyleBackColor = true;
            // 
            // txtPartSearch
            // 
            _txtPartSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPartSearch.Font = new Font("Microsoft Sans Serif", 14.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtPartSearch.Location = new Point(321, 62);
            _txtPartSearch.Name = "txtPartSearch";
            _txtPartSearch.Size = new Size(680, 29);
            _txtPartSearch.TabIndex = 2;
            // 
            // lblQty
            // 
            _lblQty.Font = new Font("Verdana", 9.0F);
            _lblQty.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(192)));
            _lblQty.Location = new Point(4, 67);
            _lblQty.Name = "lblQty";
            _lblQty.Size = new Size(120, 21);
            _lblQty.TabIndex = 19;
            _lblQty.Text = "Qty";
            // 
            // btnCreate
            // 
            _btnCreate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnCreate.Font = new Font("Verdana", 9.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnCreate.Location = new Point(857, 552);
            _btnCreate.Name = "btnCreate";
            _btnCreate.Size = new Size(146, 40);
            _btnCreate.TabIndex = 130;
            _btnCreate.Text = "Create Order";
            _btnCreate.UseVisualStyleBackColor = true;
            // 
            // lblSearch
            // 
            _lblSearch.Font = new Font("Verdana", 9.0F);
            _lblSearch.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(192)));
            _lblSearch.Location = new Point(249, 67);
            _lblSearch.Name = "lblSearch";
            _lblSearch.Size = new Size(67, 21);
            _lblSearch.TabIndex = 20;
            _lblSearch.Text = "Search";
            // 
            // lblSupplier
            // 
            _lblSupplier.Font = new Font("Verdana", 9.0F);
            _lblSupplier.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(192)));
            _lblSupplier.Location = new Point(4, 22);
            _lblSupplier.Name = "lblSupplier";
            _lblSupplier.Size = new Size(120, 21);
            _lblSupplier.TabIndex = 18;
            _lblSupplier.Text = "Supplier";
            // 
            // nudQty
            // 
            _nudQty.BackColor = Color.White;
            _nudQty.Font = new Font("Verdana", 16.0F);
            _nudQty.Location = new Point(130, 61);
            _nudQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            _nudQty.Name = "nudQty";
            _nudQty.Size = new Size(112, 33);
            _nudQty.TabIndex = 9;
            _nudQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dgParts
            // 
            _dgParts.AllowUserToAddRows = false;
            _dgParts.AllowUserToDeleteRows = false;
            _dgParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgParts.Location = new Point(13, 413);
            _dgParts.Name = "dgParts";
            _dgParts.Size = new Size(990, 133);
            _dgParts.TabIndex = 133;
            // 
            // lblTopLabel
            // 
            _lblTopLabel.AutoSize = true;
            _lblTopLabel.Font = new Font("Microsoft Sans Serif", 14.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblTopLabel.Location = new Point(17, 50);
            _lblTopLabel.Name = "lblTopLabel";
            _lblTopLabel.Size = new Size(539, 24);
            _lblTopLabel.TabIndex = 132;
            _lblTopLabel.Text = "Are these parts to be fitted on this visit?  (NO creates a new visit)";
            // 
            // btnAddPart
            // 
            _btnAddPart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnAddPart.Enabled = false;
            _btnAddPart.Location = new Point(857, 372);
            _btnAddPart.Name = "btnAddPart";
            _btnAddPart.Size = new Size(146, 34);
            _btnAddPart.TabIndex = 124;
            _btnAddPart.Text = "Add";
            _btnAddPart.UseVisualStyleBackColor = true;
            // 
            // rbNo
            // 
            _rbNo.AutoSize = true;
            _rbNo.Font = new Font("Microsoft Sans Serif", 14.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _rbNo.Location = new Point(949, 49);
            _rbNo.Name = "rbNo";
            _rbNo.Size = new Size(53, 28);
            _rbNo.TabIndex = 127;
            _rbNo.TabStop = true;
            _rbNo.Text = "No";
            _rbNo.UseVisualStyleBackColor = true;
            // 
            // rbYes
            // 
            _rbYes.AutoSize = true;
            _rbYes.Font = new Font("Microsoft Sans Serif", 14.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _rbYes.Location = new Point(836, 50);
            _rbYes.Name = "rbYes";
            _rbYes.Size = new Size(60, 28);
            _rbYes.TabIndex = 126;
            _rbYes.TabStop = true;
            _rbYes.Text = "Yes";
            _rbYes.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            _btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnBack.Font = new Font("Verdana", 9.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnBack.Location = new Point(12, 552);
            _btnBack.Name = "btnBack";
            _btnBack.Size = new Size(146, 40);
            _btnBack.TabIndex = 125;
            _btnBack.Text = "Close";
            _btnBack.UseVisualStyleBackColor = true;
            // 
            // pnlFilters
            // 
            _pnlFilters.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _pnlFilters.BackColor = SystemColors.Info;
            _pnlFilters.Controls.Add(_dtpDatePlaced);
            _pnlFilters.Controls.Add(_lblDate);
            _pnlFilters.Controls.Add(_cboCostCentre);
            _pnlFilters.Controls.Add(_lblCostCentre);
            _pnlFilters.Controls.Add(_txtSupplier);
            _pnlFilters.Controls.Add(_lblSearch);
            _pnlFilters.Controls.Add(_lblSupplier);
            _pnlFilters.Controls.Add(_btnFindPart);
            _pnlFilters.Controls.Add(_txtPartSearch);
            _pnlFilters.Controls.Add(_nudQty);
            _pnlFilters.Controls.Add(_lblQty);
            _pnlFilters.Location = new Point(1, 91);
            _pnlFilters.Name = "pnlFilters";
            _pnlFilters.Size = new Size(1013, 145);
            _pnlFilters.TabIndex = 123;
            // 
            // dtpDatePlaced
            // 
            _dtpDatePlaced.Location = new Point(130, 105);
            _dtpDatePlaced.Name = "dtpDatePlaced";
            _dtpDatePlaced.Size = new Size(702, 21);
            _dtpDatePlaced.TabIndex = 25;
            // 
            // lblDate
            // 
            _lblDate.Font = new Font("Verdana", 9.0F);
            _lblDate.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(192)));
            _lblDate.Location = new Point(4, 110);
            _lblDate.Name = "lblDate";
            _lblDate.Size = new Size(120, 21);
            _lblDate.TabIndex = 24;
            _lblDate.Text = "Date Placed";
            // 
            // cboCostCentre
            // 
            _cboCostCentre.FormattingEnabled = true;
            _cboCostCentre.Location = new Point(764, 29);
            _cboCostCentre.Name = "cboCostCentre";
            _cboCostCentre.Size = new Size(237, 21);
            _cboCostCentre.TabIndex = 23;
            // 
            // lblCostCentre
            // 
            _lblCostCentre.Font = new Font("Verdana", 9.0F);
            _lblCostCentre.ForeColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(0)), Conversions.ToInteger(Conversions.ToByte(192)));
            _lblCostCentre.Location = new Point(761, 12);
            _lblCostCentre.Name = "lblCostCentre";
            _lblCostCentre.Size = new Size(89, 21);
            _lblCostCentre.TabIndex = 22;
            _lblCostCentre.Text = "Cost Centre:";
            // 
            // txtSupplier
            // 
            _txtSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSupplier.Font = new Font("Microsoft Sans Serif", 14.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtSupplier.Location = new Point(130, 21);
            _txtSupplier.Name = "txtSupplier";
            _txtSupplier.ReadOnly = true;
            _txtSupplier.Size = new Size(625, 29);
            _txtSupplier.TabIndex = 21;
            // 
            // dgvSearch
            // 
            _dgvSearch.AllowUserToAddRows = false;
            _dgvSearch.AllowUserToDeleteRows = false;
            _dgvSearch.AllowUserToResizeRows = false;
            _dgvSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgvSearch.EditMode = DataGridViewEditMode.EditProgrammatically;
            _dgvSearch.Location = new Point(12, 242);
            _dgvSearch.MultiSelect = false;
            _dgvSearch.Name = "dgvSearch";
            _dgvSearch.ReadOnly = true;
            _dgvSearch.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            _dgvSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvSearch.ShowCellErrors = false;
            _dgvSearch.ShowCellToolTips = false;
            _dgvSearch.ShowEditingIcon = false;
            _dgvSearch.ShowRowErrors = false;
            _dgvSearch.Size = new Size(839, 165);
            _dgvSearch.TabIndex = 134;
            // 
            // txtNewOrderNumber
            // 
            _txtNewOrderNumber.BackColor = Color.White;
            _txtNewOrderNumber.BorderStyle = BorderStyle.None;
            _txtNewOrderNumber.Font = new Font("Verdana", 12.0F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtNewOrderNumber.ForeColor = Color.Red;
            _txtNewOrderNumber.Location = new Point(243, 563);
            _txtNewOrderNumber.Name = "txtNewOrderNumber";
            _txtNewOrderNumber.ReadOnly = true;
            _txtNewOrderNumber.Size = new Size(543, 20);
            _txtNewOrderNumber.TabIndex = 135;
            _txtNewOrderNumber.Text = "Your order number will be displayed here once created.";
            _txtNewOrderNumber.TextAlign = HorizontalAlignment.Center;
            // 
            // TabletOrder
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(1014, 608);
            ControlBox = false;
            Controls.Add(_txtNewOrderNumber);
            Controls.Add(_dgvSearch);
            Controls.Add(_btnCreate);
            Controls.Add(_dgParts);
            Controls.Add(_lblTopLabel);
            Controls.Add(_btnAddPart);
            Controls.Add(_rbNo);
            Controls.Add(_rbYes);
            Controls.Add(_btnBack);
            Controls.Add(_pnlFilters);
            MaximizeBox = false;
            MaximumSize = new Size(1030, 647);
            MinimizeBox = false;
            MinimumSize = new Size(1030, 647);
            Name = "TabletOrder";
            Text = "Part Search";
            Controls.SetChildIndex(_pnlFilters, 0);
            Controls.SetChildIndex(_btnBack, 0);
            Controls.SetChildIndex(_rbYes, 0);
            Controls.SetChildIndex(_rbNo, 0);
            Controls.SetChildIndex(_btnAddPart, 0);
            Controls.SetChildIndex(_lblTopLabel, 0);
            Controls.SetChildIndex(_dgParts, 0);
            Controls.SetChildIndex(_btnCreate, 0);
            Controls.SetChildIndex(_dgvSearch, 0);
            Controls.SetChildIndex(_txtNewOrderNumber, 0);
            ((System.ComponentModel.ISupportInitialize)_nudQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)_dgParts).EndInit();
            _pnlFilters.ResumeLayout(false);
            _pnlFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvSearch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        private void ResetMe(int newID)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void SetupDataTable()
        {
            PartsList.Columns.Add("PartSupplierID");
            PartsList.Columns.Add("SPN");
            PartsList.Columns.Add("Description");
            PartsList.Columns.Add("Qty");
            PartsList.Columns.Add("Supplier");
            PartsList.Columns.Add("PartID");
            PartsList.Columns.Add("Price");
            PartsList.Columns.Add("IsSpecialPart");
        }

        private void SetupPartsDataGrid()
        {
            try
            {
                // dgParts.TableStyles.Add(New DataGridTableStyle)
                // Globals.FormatDatagrid(dgParts)

                // Dim tStyle As DataGridTableStyle = dgParts.TableStyles(0)

                var PartSupplierID = new DataGridViewTextBoxColumn();
                PartSupplierID.HeaderText = "PartSupplierID";
                PartSupplierID.DataPropertyName = "PartSupplierID";
                PartSupplierID.Visible = false;
                // PartSupplierID. = ""
                PartSupplierID.Width = 10;
                dgParts.Columns.Add(PartSupplierID);

                // tStyle.GridColumnStyles.Add(PartSupplierID)

                var PartID = new DataGridViewTextBoxColumn();
                PartID.HeaderText = "PartID";
                PartID.DataPropertyName = "PartID";
                PartID.Visible = false;
                // PartSupplierID. = ""
                PartID.Width = 10;
                dgParts.Columns.Add(PartID);
                var SPN = new DataGridViewTextBoxColumn();
                SPN.HeaderText = "SPN";
                SPN.DataPropertyName = "SPN";
                // PartSupplierID. = ""
                SPN.Width = 200;
                dgParts.Columns.Add(SPN);
                SPN.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                var Description = new DataGridViewTextBoxColumn();
                Description.HeaderText = "Description";
                Description.DataPropertyName = "Description";
                dgParts.Columns.Add(Description);
                Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                Description.Width = 300;
                var Qty = new DataGridViewTextBoxColumn();
                Qty.HeaderText = "Qty";
                Qty.DataPropertyName = "Qty";
                Qty.Width = 70;
                dgParts.Columns.Add(Qty);
                Qty.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                Qty.Width = 70;
                var Price = new DataGridViewTextBoxColumn();
                Price.HeaderText = "Buy Price";
                Price.DataPropertyName = "Price";
                Price.Width = 70;
                dgParts.Columns.Add(Price);
                Qty.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                Qty.Width = 70;
            }
            catch (Exception ex)
            {
                App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void SetupSearchDataGrid()
        {
            try
            {
                // SearchDataView = New DataView
                dgvSearch.AutoGenerateColumns = false;
                // _searchDataView.AllowNew = False
                // _searchDataView.AllowEdit = False
                // _searchDataView.AllowDelete = False

                var PartSupplierID = new DataGridViewTextBoxColumn();
                PartSupplierID.HeaderText = "PartSupplierID";
                PartSupplierID.DataPropertyName = "PartSupplierID";
                PartSupplierID.Width = 10;
                dgvSearch.Columns.Add(PartSupplierID);
                PartSupplierID.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                PartSupplierID.Visible = false;
                var IsSpecialPart = new DataGridViewTextBoxColumn();
                IsSpecialPart.HeaderText = "IsSpecialPart";
                IsSpecialPart.DataPropertyName = "IsSpecialPart";
                IsSpecialPart.Width = 10;
                dgvSearch.Columns.Add(IsSpecialPart);
                IsSpecialPart.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                IsSpecialPart.Visible = false;
                var SupplierID = new DataGridViewTextBoxColumn();
                SupplierID.HeaderText = "SupplierID";
                SupplierID.DataPropertyName = "SupplierID";
                SupplierID.Name = "SupplierID";
                SupplierID.Visible = true;
                // PartSupplierID. = ""
                SupplierID.Width = 5;
                dgvSearch.Columns.Add(SupplierID);
                var Supplier = new DataGridViewTextBoxColumn();
                Supplier.HeaderText = "Supplier";
                Supplier.DataPropertyName = "Supplier";
                Supplier.Visible = true;
                // PartSupplierID. = ""
                Supplier.Width = 120;
                dgvSearch.Columns.Add(Supplier);
                var SPN = new DataGridViewTextBoxColumn();
                SPN.HeaderText = "SPN";
                SPN.DataPropertyName = "PartCode";
                SPN.Width = 80;
                dgvSearch.Columns.Add(SPN);
                SPN.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                var Number = new DataGridViewTextBoxColumn();
                Number.HeaderText = "Number";
                Number.DataPropertyName = "Number";
                Number.Width = 80;
                dgvSearch.Columns.Add(Number);
                var Description = new DataGridViewTextBoxColumn();
                Description.HeaderText = "Description";
                Description.DataPropertyName = "Name";
                Description.Width = 400;
                dgvSearch.Columns.Add(Description);
                var Price = new DataGridViewTextBoxColumn();
                Price.HeaderText = "Buy Price";
                Price.DataPropertyName = "price";
                Price.Width = 80;
                dgvSearch.Columns.Add(Price);
            }
            catch (Exception ex)
            {
                App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private DataView _partsDataView;

        private DataView PartsDataView
        {
            get
            {
                return _partsDataView;
            }

            set
            {
                if (value is object)
                {
                    _partsDataView = value;
                    _partsDataView.Table.TableName = "tblPart";
                }

                dgParts.DataSource = _partsDataView;
            }
        }

        public DataRow SelectedPartsRow
        {
            get
            {
                if (PartsDataView is object)
                {
                    if (PartsDataView.Table.Rows.Count > 0)
                    {
                        return PartsDataView[dgParts.CurrentRow.Index].Row;
                    }
                    else
                    {
                        return null;
                    }

                    return null;
                }

                return null;
            }
        }

        private DataView _searchDataView;

        private DataView SearchDataView
        {
            get
            {
                return _searchDataView;
            }

            set
            {
                if (value is object)
                {
                    _searchDataView = value;
                    _searchDataView.Table.TableName = "tblSearch";
                }

                dgvSearch.DataSource = _searchDataView;
            }
        }

        public DataRow SelectedSearchRow
        {
            get
            {
                if (SearchDataView is object)
                {
                    if (SearchDataView.Table.Rows.Count > 0)
                    {
                        return SearchDataView[dgvSearch.CurrentRow.Index].Row;
                    }
                    else
                    {
                        return null;
                    }

                    return null;
                }

                return null;
            }
        }

        private int SupplierID = 0;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private JobNumber _OrderNumber = new JobNumber();

        public JobNumber OrderNumber
        {
            get
            {
                return _OrderNumber;
            }

            set
            {
                _OrderNumber = value;
                _OrderNumber.OrderNumber = OrderNumber.Number.ToString();
                while (OrderNumber.OrderNumber.Length < 5)
                    _OrderNumber.OrderNumber = "0" + OrderNumber.OrderNumber;
                string typePrefix = "";
                typePrefix = "V";
                string userPrefix = "";
                var username = App.loggedInUser.Fullname.Split(' ');
                foreach (string s in username)
                    userPrefix += s.Substring(0, 1);
                _OrderNumber.OrderNumber = userPrefix + typePrefix + OrderNumber.OrderNumber;
            }
        }

        private int _engineerVisitID;

        public int EngineerVisitID
        {
            get
            {
                return _engineerVisitID;
            }

            set
            {
                _engineerVisitID = value;
            }
        }

        private int _engineerID;

        public int EngineerID
        {
            get
            {
                return _engineerID;
            }

            set
            {
                _engineerID = value;
            }
        }

        private DataTable PartsList = new DataTable();

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (rbNo.Checked == false & rbYes.Checked == false)
            {
                App.ShowMessage("You must select the visit option to be able to create an order.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (PartsList.Rows.Count == 0)
            {
                App.ShowMessage("You must select a part to create an order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string department = Helper.MakeStringValid(Combo.get_GetSelectedItemValue(cboCostCentre));
            if (Helper.IsValidInteger(department) && Helper.MakeIntegerValid(department) <= 0)
            {
                App.ShowMessage("You need to enter a department to create an order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var oJobAudit = new Entity.JobAudits.JobAudit();
            var cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            var oJob = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisitID);
            string Job_JobID = oJob.JobID.ToString();
            int Job_VisitType = oJob.JobTypeID;
            int Job_SiteID = oJob.PropertyID;
            if (rbNo.Checked == true)
            {
                if (Job_VisitType == 519) // = service then create a new breakdown job
                {
                    var oJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Callout);
                    string Job_JobNumber = oJobNumber.Number.ToString();
                    string Job_JobPrefix = oJobNumber.Prefix;
                    Job_JobNumber = Job_JobPrefix + Job_JobNumber;
                    var oNewJob = new Entity.Jobs.Job();
                    oNewJob.SetPropertyID = Job_SiteID;
                    oNewJob.SetJobDefinitionEnumID = Enums.JobDefinition.Callout;
                    oNewJob.SetJobTypeID = 4703;
                    oNewJob.SetCreatedByUserID = App.loggedInUser.UserID;
                    oNewJob.SetJobNumber = Job_JobNumber;
                    oNewJob.SetPONumber = null;
                    oNewJob.SetQuoteID = 0;
                    oNewJob.SetContractID = 0;
                    oNewJob.SetToBePartPaid = false;
                    oNewJob.SetRetention = 0;
                    oNewJob.SetCollectPayment = false;
                    oNewJob.SetPOC = false;
                    oNewJob.SetOTI = false;
                    oNewJob.SetFOC = false;
                    oNewJob.SetDeleted = false;
                    oNewJob = App.DB.Job.Insert(oNewJob);
                    Job_JobID = oNewJob.JobID.ToString();
                    string NewJobActionChange = "New Job Inserted (By User " + App.loggedInUser.Fullname.ToString() + ") - JobNumber: " + Job_JobNumber + " (Unique Job ID: " + Job_JobID + ")";
                    oJobAudit = new Entity.JobAudits.JobAudit();
                    oJobAudit.SetJobID = Job_JobID;
                    oJobAudit.SetActionChange = NewJobActionChange;
                    App.DB.JobAudit.Insert(oJobAudit);
                }

                System.Data.SqlClient.SqlTransaction trans;
                System.Data.SqlClient.SqlConnection con;
                con = new System.Data.SqlClient.SqlConnection(App.DB.ServerConnectionString);
                con.Open();
                trans = con.BeginTransaction(IsolationLevel.ReadUncommitted);
                var oJOW = new Entity.JobOfWorks.JobOfWork();
                int JoW_JoWID;
                oJOW.SetJobID = Job_JobID;
                oJOW.SetDeleted = false;
                oJOW.SetPONumber = "";
                oJOW.SetStatus = 1;
                oJOW.SetPriority = null;
                oJOW = App.DB.JobOfWorks.Insert(oJOW, trans);
                JoW_JoWID = oJOW.JobOfWorkID;
                trans.Commit();
                con.Close();
                var oEngVisit = new Entity.EngineerVisits.EngineerVisit();
                oEngVisit.SetJobOfWorkID = JoW_JoWID;
                oEngVisit.SetEngineerID = 0;
                oEngVisit.SetStatusEnumID = 4;
                oEngVisit.SetNotesFromEngineer = "Created for Tablet from Head Office";
                oEngVisit.SetPartsToFit = 1;
                oEngVisit.SetExpectedEngineerID = 0;
                oEngVisit.SetRecharge = 0;
                oEngVisit.SetDeleted = false;
                oEngVisit.SetAMPM = null;
                oEngVisit = App.DB.EngineerVisits.Insert(oEngVisit, Conversions.ToInteger(Job_JobID));
                EngineerVisitID = oEngVisit.EngineerVisitID;
                string ActionChange = "New Visit Inserted (By User " + App.loggedInUser.Fullname + ") - Status: NOT SET (Unique Visit ID: " + EngineerVisitID + ")";
                oJobAudit = new Entity.JobAudits.JobAudit();
                oJobAudit.SetJobID = Job_JobID;
                oJobAudit.SetActionChange = ActionChange;
                App.DB.JobAudit.Insert(oJobAudit);
            }
            else
            {
                var oEngVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(EngineerVisitID);
                if (oEngVisit is object)
                {
                    oEngVisit.SetPartsToFit = true;
                    App.DB.EngineerVisits.Update(oEngVisit, Conversions.ToInteger(Job_JobID), true);
                }
            }

            var oOrder = new Entity.Orders.Order();
            oOrder.IgnoreExceptionsOnSetMethods = true;
            oOrder.SetSentToSage = false;

            // validate a customer/van/warehouse has been selected

            oOrder.SetOrderID = 0; // new
            oOrder.DatePlaced = DateAndTime.Now;
            oOrder.SetOrderTypeID = 4;  // Job
            oOrder.SetUserID = App.loggedInUser.UserID;
            oOrder.SetOrderStatusID = Conversions.ToInteger(2); // Confirmed
            oOrder.DeliveryDeadline = default; // TODO
            oOrder.SupplierInvoiceDate = default;
            OrderNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.ORDER);
            oOrder.SetDepartmentRef = department;
            oOrder.SetDoNotConsolidated = true;
            oOrder.DatePlaced = dtpDatePlaced.Value;
            // check if customer is pfh
            oOrder.SetOrderReference = OrderNumber.OrderNumber;
            var customer = App.DB.Customer.Customer_Get_ForSiteID(oJob.PropertyID);
            if (customer.IsPFH == true)
            {
                if (App.DB.Supplier.Supplier_GetSecondaryPrice(SupplierID))
                {
                    oOrder.SetOrderReference = OrderNumber.OrderNumber + "F";
                }
            }

            oOrder = App.DB.Order.Insert(oOrder);
            var oEngineerVisitOrder = new Entity.EngineerVisitOrders.EngineerVisitOrder();
            oEngineerVisitOrder.SetOrderID = oOrder.OrderID;
            oEngineerVisitOrder.SetEngineerVisitID = EngineerVisitID;
            App.DB.EngineerVisitOrder.EngineerVisitOrder_DeleteForOrder(oOrder.OrderID);
            oEngineerVisitOrder = App.DB.EngineerVisitOrder.Insert(oEngineerVisitOrder);

            // Add parts

            foreach (DataRow dr in PartsList.Rows)
            {
                var oOrderPart = new Entity.OrderParts.OrderPart();
                oOrderPart.IgnoreExceptionsOnSetMethods = true;
                oOrderPart.SetOrderID = oOrder.OrderID;
                oOrderPart.SetPartSupplierID = dr["PartSupplierID"];
                int partID = Conversions.ToInteger(dr["PartID"]);
                bool IsSpecialPart = Conversions.ToBoolean(dr["IsSpecialPart"]);
                if (IsSpecialPart)
                {
                    var f = new FRMSpecialOrder(Conversions.ToInteger(dr["PartSupplierID"]), Conversions.ToDouble(dr["Price"]), Conversions.ToInteger(dr["Qty"]));
                    f.ShowDialog();
                    if (f.DialogResult == DialogResult.OK)
                    {
                        oOrderPart.SetQuantity = f.Quantity;
                        oOrderPart.SetBuyPrice = f.Price;
                        oOrderPart.SetSpecialDescription = f.PartName;
                        oOrderPart.SetSpecialPartNumber = f.SPN;
                        oOrderPart.SetQuantityReceived = f.Quantity;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    oOrderPart.SetQuantity = dr["Qty"];
                    oOrderPart.SetBuyPrice = dr["Price"];
                    oOrderPart.SetQuantityReceived = dr["Qty"];
                }

                oOrderPart.SetChildSupplierID = 0;
                int warehouseID = 0;
                var val = new Entity.OrderParts.OrderPartValidator();
                val.Validate(oOrderPart);
                oOrderPart = App.DB.OrderPart.Insert(oOrderPart, false);
                App.DB.EngineerVisitPartProductAllocated.InsertOne(EngineerVisitID, "Part", oOrderPart.Quantity, oOrderPart.OrderPartID, Conversions.ToInteger(dr["PartID"]), 1); // 1 = Supplier
            }

            var orderControl = new OrderControl(oOrder);
            if (orderControl.IsWithinJobSpendLimit())
            {
                oOrder.SetOrderStatusID = Conversions.ToInteger(Enums.OrderStatus.Complete); // take it straight to complete
            }
            else if (App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.POAuthorisation))
            {
                App.ShowMessage("Job cost capacity was exceeded when creating this purchase order!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                oOrder.SetOrderStatusID = Conversions.ToInteger(Enums.OrderStatus.Complete); // take it straight to complete
            }
            else
            {
                App.ShowMessage("Job cost capacity was exceeded when creating this purchase order!" + Constants.vbCrLf + Constants.vbCrLf + "Please note that this order is currently awaiting approval!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                oOrder.SetOrderStatusID = Conversions.ToInteger(Enums.OrderStatus.AwaitingApproval);
            }

            App.DB.Order.Update(oOrder);
            txtNewOrderNumber.Text = "Created Purchase Order Number : " + oOrder.OrderReference;
            txtNewOrderNumber.Visible = oOrder.OrderStatusID == (int)Enums.OrderStatus.AwaitingApproval ? false : true;
            btnCreate.Enabled = false;
        }

        private void TabletOrder_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnFindPart_Click(object sender, EventArgs e)
        {
            int MasterSupplierID;
            string cmd = "SELECT COALESCE(MasterSupplierID,0) FROM tblSupplier WHERE SupplierID = " + SupplierID;
            MasterSupplierID = Conversions.ToInteger(App.DB.ExecuteScalar(cmd));
            DataTable PartFound;
            if (MasterSupplierID == 0)
            {
                SearchDataView = (DataView)App.DB.PartSupplier.PartSupplier_FindTabletOrder(txtPartSearch.Text, SupplierID);
            }
            else
            {
                SearchDataView = (DataView)App.DB.PartSupplier.PartSupplier_FindTabletOrder(txtPartSearch.Text, SupplierID);
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSearch.SelectedRows[0].Index > -1)
            {
                btnAddPart.Enabled = true;
            }
            else
            {
                btnAddPart.Enabled = false;
            }
        }

        private void FrmPartSearch_Load(object sender, EventArgs e)
        {
            try
            {
                SetupDataTable();
                SetupPartsDataGrid();
                SetupSearchDataGrid();
                Text = "Create Order (Current Visit: " + EngineerVisitID + " for Engineer: " + EngineerID + ")";
            }
            catch (Exception ex)
            {
                App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            catch (Exception ex)
            {
                App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            int MasterSupplierID;
            string cmd = "SELECT COALESCE(MasterSupplierID,0) FROM tblSupplier WHERE SupplierID = " + SupplierID;
            MasterSupplierID = Conversions.ToInteger(App.DB.ExecuteScalar(cmd));
            if (dgvSearch.SelectedCells[0].RowIndex > -1)
            {
                PartsList.Rows.Add(SelectedSearchRow["PartSupplierID"], SelectedSearchRow["PartCode"], SelectedSearchRow["Name"], nudQty.Value, SelectedSearchRow["Supplier"], SelectedSearchRow["PartID"], SelectedSearchRow["Price"], SelectedSearchRow["IsSpecialPart"]);
                txtPartSearch.Text = null;
                btnAddPart.Enabled = false;
                dgParts.DataSource = PartsList;
                nudQty.Value = 1;
                if (MasterSupplierID > 0)
                {
                    SupplierID = MasterSupplierID;
                }
                else
                {
                    SupplierID = Conversions.ToInteger(SelectedSearchRow["SupplierID"]);
                }
                // SupplierID = SelectedSearchRow("SupplierID")
                txtSupplier.Text = Conversions.ToString(SelectedSearchRow["Supplier"]);
                SearchDataView.Table.Clear();
            }
            else
            {
                Interaction.MsgBox("Please select an item", MsgBoxStyle.OkOnly, "Opps");
            }
        }

        private void txtPartSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFindPart_Click(sender, e);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}