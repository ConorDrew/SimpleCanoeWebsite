using FSM.Business.Orders;
using FSM.Entity.Sys;
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

        private Label _lblSupplier;

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

        private Panel _pnlFilters;

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
            this._btnFindPart = new System.Windows.Forms.Button();
            this._txtPartSearch = new System.Windows.Forms.TextBox();
            this._lblQty = new System.Windows.Forms.Label();
            this._btnCreate = new System.Windows.Forms.Button();
            this._lblSearch = new System.Windows.Forms.Label();
            this._lblSupplier = new System.Windows.Forms.Label();
            this._nudQty = new System.Windows.Forms.NumericUpDown();
            this._dgParts = new System.Windows.Forms.DataGridView();
            this._lblTopLabel = new System.Windows.Forms.Label();
            this._btnAddPart = new System.Windows.Forms.Button();
            this._rbNo = new System.Windows.Forms.RadioButton();
            this._rbYes = new System.Windows.Forms.RadioButton();
            this._btnBack = new System.Windows.Forms.Button();
            this._pnlFilters = new System.Windows.Forms.Panel();
            this._dtpDatePlaced = new System.Windows.Forms.DateTimePicker();
            this._lblDate = new System.Windows.Forms.Label();
            this._cboCostCentre = new System.Windows.Forms.ComboBox();
            this._lblCostCentre = new System.Windows.Forms.Label();
            this._txtSupplier = new System.Windows.Forms.TextBox();
            this._dgvSearch = new System.Windows.Forms.DataGridView();
            this._txtNewOrderNumber = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._nudQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgParts)).BeginInit();
            this._pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnFindPart
            // 
            this._btnFindPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindPart.Location = new System.Drawing.Point(856, 105);
            this._btnFindPart.Name = "_btnFindPart";
            this._btnFindPart.Size = new System.Drawing.Size(145, 34);
            this._btnFindPart.TabIndex = 13;
            this._btnFindPart.Text = "Find";
            this._btnFindPart.UseVisualStyleBackColor = true;
            this._btnFindPart.Click += new System.EventHandler(this.btnFindPart_Click);
            // 
            // _txtPartSearch
            // 
            this._txtPartSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtPartSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtPartSearch.Location = new System.Drawing.Point(321, 62);
            this._txtPartSearch.Name = "_txtPartSearch";
            this._txtPartSearch.Size = new System.Drawing.Size(680, 29);
            this._txtPartSearch.TabIndex = 2;
            this._txtPartSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartSearch_KeyDown);
            // 
            // _lblQty
            // 
            this._lblQty.Font = new System.Drawing.Font("Verdana", 9F);
            this._lblQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this._lblQty.Location = new System.Drawing.Point(4, 67);
            this._lblQty.Name = "_lblQty";
            this._lblQty.Size = new System.Drawing.Size(120, 21);
            this._lblQty.TabIndex = 19;
            this._lblQty.Text = "Qty";
            // 
            // _btnCreate
            // 
            this._btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCreate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnCreate.Location = new System.Drawing.Point(856, 558);
            this._btnCreate.Name = "_btnCreate";
            this._btnCreate.Size = new System.Drawing.Size(146, 40);
            this._btnCreate.TabIndex = 130;
            this._btnCreate.Text = "Create Order";
            this._btnCreate.UseVisualStyleBackColor = true;
            this._btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // _lblSearch
            // 
            this._lblSearch.Font = new System.Drawing.Font("Verdana", 9F);
            this._lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this._lblSearch.Location = new System.Drawing.Point(249, 67);
            this._lblSearch.Name = "_lblSearch";
            this._lblSearch.Size = new System.Drawing.Size(67, 21);
            this._lblSearch.TabIndex = 20;
            this._lblSearch.Text = "Search";
            // 
            // _lblSupplier
            // 
            this._lblSupplier.Font = new System.Drawing.Font("Verdana", 9F);
            this._lblSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this._lblSupplier.Location = new System.Drawing.Point(4, 22);
            this._lblSupplier.Name = "_lblSupplier";
            this._lblSupplier.Size = new System.Drawing.Size(120, 21);
            this._lblSupplier.TabIndex = 18;
            this._lblSupplier.Text = "Supplier";
            // 
            // _nudQty
            // 
            this._nudQty.BackColor = System.Drawing.Color.White;
            this._nudQty.Font = new System.Drawing.Font("Verdana", 16F);
            this._nudQty.Location = new System.Drawing.Point(130, 61);
            this._nudQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._nudQty.Name = "_nudQty";
            this._nudQty.Size = new System.Drawing.Size(112, 33);
            this._nudQty.TabIndex = 9;
            this._nudQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _dgParts
            // 
            this._dgParts.AllowUserToAddRows = false;
            this._dgParts.AllowUserToDeleteRows = false;
            this._dgParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgParts.Location = new System.Drawing.Point(12, 373);
            this._dgParts.Name = "_dgParts";
            this._dgParts.Size = new System.Drawing.Size(990, 179);
            this._dgParts.TabIndex = 133;
            // 
            // _lblTopLabel
            // 
            this._lblTopLabel.AutoSize = true;
            this._lblTopLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblTopLabel.Location = new System.Drawing.Point(16, 10);
            this._lblTopLabel.Name = "_lblTopLabel";
            this._lblTopLabel.Size = new System.Drawing.Size(539, 24);
            this._lblTopLabel.TabIndex = 132;
            this._lblTopLabel.Text = "Are these parts to be fitted on this visit?  (NO creates a new visit)";
            // 
            // _btnAddPart
            // 
            this._btnAddPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAddPart.Enabled = false;
            this._btnAddPart.Location = new System.Drawing.Point(856, 332);
            this._btnAddPart.Name = "_btnAddPart";
            this._btnAddPart.Size = new System.Drawing.Size(146, 34);
            this._btnAddPart.TabIndex = 124;
            this._btnAddPart.Text = "Add";
            this._btnAddPart.UseVisualStyleBackColor = true;
            this._btnAddPart.Click += new System.EventHandler(this.btnAddPart_Click);
            // 
            // _rbNo
            // 
            this._rbNo.AutoSize = true;
            this._rbNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._rbNo.Location = new System.Drawing.Point(948, 9);
            this._rbNo.Name = "_rbNo";
            this._rbNo.Size = new System.Drawing.Size(53, 28);
            this._rbNo.TabIndex = 127;
            this._rbNo.TabStop = true;
            this._rbNo.Text = "No";
            this._rbNo.UseVisualStyleBackColor = true;
            // 
            // _rbYes
            // 
            this._rbYes.AutoSize = true;
            this._rbYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._rbYes.Location = new System.Drawing.Point(835, 10);
            this._rbYes.Name = "_rbYes";
            this._rbYes.Size = new System.Drawing.Size(60, 28);
            this._rbYes.TabIndex = 126;
            this._rbYes.TabStop = true;
            this._rbYes.Text = "Yes";
            this._rbYes.UseVisualStyleBackColor = true;
            // 
            // _btnBack
            // 
            this._btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnBack.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnBack.Location = new System.Drawing.Point(11, 558);
            this._btnBack.Name = "_btnBack";
            this._btnBack.Size = new System.Drawing.Size(146, 40);
            this._btnBack.TabIndex = 125;
            this._btnBack.Text = "Close";
            this._btnBack.UseVisualStyleBackColor = true;
            this._btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // _pnlFilters
            // 
            this._pnlFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlFilters.BackColor = System.Drawing.SystemColors.Info;
            this._pnlFilters.Controls.Add(this._dtpDatePlaced);
            this._pnlFilters.Controls.Add(this._lblDate);
            this._pnlFilters.Controls.Add(this._cboCostCentre);
            this._pnlFilters.Controls.Add(this._lblCostCentre);
            this._pnlFilters.Controls.Add(this._txtSupplier);
            this._pnlFilters.Controls.Add(this._lblSearch);
            this._pnlFilters.Controls.Add(this._lblSupplier);
            this._pnlFilters.Controls.Add(this._btnFindPart);
            this._pnlFilters.Controls.Add(this._txtPartSearch);
            this._pnlFilters.Controls.Add(this._nudQty);
            this._pnlFilters.Controls.Add(this._lblQty);
            this._pnlFilters.Location = new System.Drawing.Point(0, 51);
            this._pnlFilters.Name = "_pnlFilters";
            this._pnlFilters.Size = new System.Drawing.Size(1013, 145);
            this._pnlFilters.TabIndex = 123;
            // 
            // _dtpDatePlaced
            // 
            this._dtpDatePlaced.Location = new System.Drawing.Point(130, 105);
            this._dtpDatePlaced.Name = "_dtpDatePlaced";
            this._dtpDatePlaced.Size = new System.Drawing.Size(702, 21);
            this._dtpDatePlaced.TabIndex = 25;
            // 
            // _lblDate
            // 
            this._lblDate.Font = new System.Drawing.Font("Verdana", 9F);
            this._lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this._lblDate.Location = new System.Drawing.Point(4, 110);
            this._lblDate.Name = "_lblDate";
            this._lblDate.Size = new System.Drawing.Size(120, 21);
            this._lblDate.TabIndex = 24;
            this._lblDate.Text = "Date Placed";
            // 
            // _cboCostCentre
            // 
            this._cboCostCentre.FormattingEnabled = true;
            this._cboCostCentre.Location = new System.Drawing.Point(764, 29);
            this._cboCostCentre.Name = "_cboCostCentre";
            this._cboCostCentre.Size = new System.Drawing.Size(237, 21);
            this._cboCostCentre.TabIndex = 23;
            // 
            // _lblCostCentre
            // 
            this._lblCostCentre.Font = new System.Drawing.Font("Verdana", 9F);
            this._lblCostCentre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this._lblCostCentre.Location = new System.Drawing.Point(761, 12);
            this._lblCostCentre.Name = "_lblCostCentre";
            this._lblCostCentre.Size = new System.Drawing.Size(89, 21);
            this._lblCostCentre.TabIndex = 22;
            this._lblCostCentre.Text = "Cost Centre:";
            // 
            // _txtSupplier
            // 
            this._txtSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtSupplier.Location = new System.Drawing.Point(130, 21);
            this._txtSupplier.Name = "_txtSupplier";
            this._txtSupplier.ReadOnly = true;
            this._txtSupplier.Size = new System.Drawing.Size(625, 29);
            this._txtSupplier.TabIndex = 21;
            // 
            // _dgvSearch
            // 
            this._dgvSearch.AllowUserToAddRows = false;
            this._dgvSearch.AllowUserToDeleteRows = false;
            this._dgvSearch.AllowUserToResizeRows = false;
            this._dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvSearch.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this._dgvSearch.Location = new System.Drawing.Point(11, 202);
            this._dgvSearch.MultiSelect = false;
            this._dgvSearch.Name = "_dgvSearch";
            this._dgvSearch.ReadOnly = true;
            this._dgvSearch.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this._dgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvSearch.ShowCellErrors = false;
            this._dgvSearch.ShowCellToolTips = false;
            this._dgvSearch.ShowEditingIcon = false;
            this._dgvSearch.ShowRowErrors = false;
            this._dgvSearch.Size = new System.Drawing.Size(839, 165);
            this._dgvSearch.TabIndex = 134;
            this._dgvSearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            this._dgvSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.btnAddPart_Click);
            // 
            // _txtNewOrderNumber
            // 
            this._txtNewOrderNumber.BackColor = System.Drawing.Color.White;
            this._txtNewOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtNewOrderNumber.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtNewOrderNumber.ForeColor = System.Drawing.Color.Red;
            this._txtNewOrderNumber.Location = new System.Drawing.Point(242, 569);
            this._txtNewOrderNumber.Name = "_txtNewOrderNumber";
            this._txtNewOrderNumber.ReadOnly = true;
            this._txtNewOrderNumber.Size = new System.Drawing.Size(543, 20);
            this._txtNewOrderNumber.TabIndex = 135;
            this._txtNewOrderNumber.Text = "Your order number will be displayed here once created.";
            this._txtNewOrderNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TabletOrder
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1014, 608);
            this.ControlBox = false;
            this.Controls.Add(this._txtNewOrderNumber);
            this.Controls.Add(this._dgvSearch);
            this.Controls.Add(this._btnCreate);
            this.Controls.Add(this._dgParts);
            this.Controls.Add(this._lblTopLabel);
            this.Controls.Add(this._btnAddPart);
            this.Controls.Add(this._rbNo);
            this.Controls.Add(this._rbYes);
            this.Controls.Add(this._btnBack);
            this.Controls.Add(this._pnlFilters);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1030, 647);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1030, 647);
            this.Name = "TabletOrder";
            this.Text = "Part Search";
            ((System.ComponentModel.ISupportInitialize)(this._nudQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgParts)).EndInit();
            this._pnlFilters.ResumeLayout(false);
            this._pnlFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void LoadMe(object sender, EventArgs e)
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

        public void ResetMe(int newID)
        {
        }

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
    }
}