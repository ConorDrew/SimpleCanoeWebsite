using FSM.Entity.CostCentres;
using FSM.Entity.CostCentres.Enums;
using FSM.Entity.CostCentres.LinkTypes.Enums;
using FSM.Entity.Customers;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMCustomerSORJobType : FRMBaseForm, IForm
    {
        public FRMCustomerSORJobType() : base()
        {
            base.Load += FRMJobLocks_Load;

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
        private GroupBox _grpLocks;

        private DataGrid _dgSOR;

        internal DataGrid dgSOR
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgSOR;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgSOR != null)
                {
                }

                _dgSOR = value;
                if (_dgSOR != null)
                {
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

        private ComboBox _cboJobType;

        internal ComboBox cboJobType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboJobType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboJobType != null)
                {
                }

                _cboJobType = value;
                if (_cboJobType != null)
                {
                }
            }
        }

        private Label _lblCustomerSorJobType;

        private Button _btnAdd;

        internal Button btnAdd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAdd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAdd != null)
                {
                    _btnAdd.Click -= btnAdd_Click;
                }

                _btnAdd = value;
                if (_btnAdd != null)
                {
                    _btnAdd.Click += btnAdd_Click;
                }
            }
        }

        private ComboBox _CboSOR;

        internal ComboBox CboSOR
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CboSOR;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CboSOR != null)
                {
                }

                _CboSOR = value;
                if (_CboSOR != null)
                {
                }
            }
        }

        private Label _lblSor;

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
                }

                _btnSave = value;
                if (_btnSave != null)
                {
                }
            }
        }

        private Label _lbSorCustomer;

        private TextBox _txtCustomer;

        internal TextBox txtCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCustomer != null)
                {
                }

                _txtCustomer = value;
                if (_txtCustomer != null)
                {
                }
            }
        }

        private Button _btnFindCustomer;

        private GroupBox _grpCostCentreMatrix;

        private ComboBox _cboRegion;

        internal ComboBox cboRegion
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboRegion;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboRegion != null)
                {
                }

                _cboRegion = value;
                if (_cboRegion != null)
                {
                }
            }
        }

        private Label _lblRegion;

        internal Label lblRegion
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRegion;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRegion != null)
                {
                }

                _lblRegion = value;
                if (_lblRegion != null)
                {
                }
            }
        }

        private ComboBox _cboCCJobType;

        internal ComboBox cboCCJobType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboCCJobType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboCCJobType != null)
                {
                }

                _cboCCJobType = value;
                if (_cboCCJobType != null)
                {
                }
            }
        }

        private Button _btnDeleteCCM;

        private Label _lblJobType;

        private DataGrid _dgCostCentreMatrix;

        internal DataGrid dgCostCentreMatrix
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgCostCentreMatrix;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgCostCentreMatrix != null)
                {
                    _dgCostCentreMatrix.Click -= dgCostCentreMatrix_Click;
                }

                _dgCostCentreMatrix = value;
                if (_dgCostCentreMatrix != null)
                {
                    _dgCostCentreMatrix.Click += dgCostCentreMatrix_Click;
                }
            }
        }

        private Button _btnAddCCM;

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

        private Label _lblCostCentre;

        private ComboBox _cboLinkType;

        internal ComboBox cboLinkType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboLinkType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboLinkType != null)
                {
                    _cboLinkType.SelectedIndexChanged -= cboLinkType_SelectedIndexChanged;
                }

                _cboLinkType = value;
                if (_cboLinkType != null)
                {
                    _cboLinkType.SelectedIndexChanged += cboLinkType_SelectedIndexChanged;
                }
            }
        }

        private Label _lblLinkType;

        private Label _lblCcCustomer;

        internal Label lblCcCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCcCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCcCustomer != null)
                {
                }

                _lblCcCustomer = value;
                if (_lblCcCustomer != null)
                {
                }
            }
        }

        private Button _btnCcFindCustomer;

        internal Button btnCcFindCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCcFindCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCcFindCustomer != null)
                {
                    _btnCcFindCustomer.Click -= btnCcFindCustomer_Click;
                }

                _btnCcFindCustomer = value;
                if (_btnCcFindCustomer != null)
                {
                    _btnCcFindCustomer.Click += btnCcFindCustomer_Click;
                }
            }
        }

        private TextBox _txtCcCustomer;

        internal TextBox txtCcCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCcCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCcCustomer != null)
                {
                }

                _txtCcCustomer = value;
                if (_txtCcCustomer != null)
                {
                }
            }
        }

        private TextBox _txtJobSpendLimit;

        internal TextBox txtJobSpendLimit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtJobSpendLimit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtJobSpendLimit != null)
                {
                }

                _txtJobSpendLimit = value;
                if (_txtJobSpendLimit != null)
                {
                }
            }
        }

        private Label _lblJobSpendLimit;

        private Button _btnReset;

        internal Button btnReset
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnReset;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnReset != null)
                {
                    _btnReset.Click -= btnReset_Click;
                }

                _btnReset = value;
                if (_btnReset != null)
                {
                    _btnReset.Click += btnReset_Click;
                }
            }
        }

        private Button _btnDelete;

        internal Button btnDelete
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDelete;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDelete != null)
                {
                    _btnDelete.Click -= btnDelete_Click;
                }

                _btnDelete = value;
                if (_btnDelete != null)
                {
                    _btnDelete.Click += btnDelete_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._grpLocks = new System.Windows.Forms.GroupBox();
            this._btnSave = new System.Windows.Forms.Button();
            this._lbSorCustomer = new System.Windows.Forms.Label();
            this._txtCustomer = new System.Windows.Forms.TextBox();
            this._btnFindCustomer = new System.Windows.Forms.Button();
            this._btnDelete = new System.Windows.Forms.Button();
            this._btnAdd = new System.Windows.Forms.Button();
            this._CboSOR = new System.Windows.Forms.ComboBox();
            this._lblSor = new System.Windows.Forms.Label();
            this._cboJobType = new System.Windows.Forms.ComboBox();
            this._lblCustomerSorJobType = new System.Windows.Forms.Label();
            this._dgSOR = new System.Windows.Forms.DataGrid();
            this._btnClose = new System.Windows.Forms.Button();
            this._grpCostCentreMatrix = new System.Windows.Forms.GroupBox();
            this._btnReset = new System.Windows.Forms.Button();
            this._txtJobSpendLimit = new System.Windows.Forms.TextBox();
            this._lblJobSpendLimit = new System.Windows.Forms.Label();
            this._cboLinkType = new System.Windows.Forms.ComboBox();
            this._lblLinkType = new System.Windows.Forms.Label();
            this._lblCcCustomer = new System.Windows.Forms.Label();
            this._btnCcFindCustomer = new System.Windows.Forms.Button();
            this._txtCcCustomer = new System.Windows.Forms.TextBox();
            this._cboCostCentre = new System.Windows.Forms.ComboBox();
            this._lblCostCentre = new System.Windows.Forms.Label();
            this._btnAddCCM = new System.Windows.Forms.Button();
            this._cboRegion = new System.Windows.Forms.ComboBox();
            this._lblRegion = new System.Windows.Forms.Label();
            this._cboCCJobType = new System.Windows.Forms.ComboBox();
            this._btnDeleteCCM = new System.Windows.Forms.Button();
            this._lblJobType = new System.Windows.Forms.Label();
            this._dgCostCentreMatrix = new System.Windows.Forms.DataGrid();
            this._grpLocks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgSOR)).BeginInit();
            this._grpCostCentreMatrix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgCostCentreMatrix)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpLocks
            // 
            this._grpLocks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._grpLocks.Controls.Add(this._btnSave);
            this._grpLocks.Controls.Add(this._lbSorCustomer);
            this._grpLocks.Controls.Add(this._txtCustomer);
            this._grpLocks.Controls.Add(this._btnFindCustomer);
            this._grpLocks.Controls.Add(this._btnDelete);
            this._grpLocks.Controls.Add(this._btnAdd);
            this._grpLocks.Controls.Add(this._CboSOR);
            this._grpLocks.Controls.Add(this._lblSor);
            this._grpLocks.Controls.Add(this._cboJobType);
            this._grpLocks.Controls.Add(this._lblCustomerSorJobType);
            this._grpLocks.Controls.Add(this._dgSOR);
            this._grpLocks.Location = new System.Drawing.Point(8, 12);
            this._grpLocks.Name = "_grpLocks";
            this._grpLocks.Size = new System.Drawing.Size(683, 771);
            this._grpLocks.TabIndex = 1;
            this._grpLocks.TabStop = false;
            // 
            // _btnSave
            // 
            this._btnSave.AccessibleDescription = "Save item";
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnSave.ImageIndex = 1;
            this._btnSave.Location = new System.Drawing.Point(621, 742);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(56, 22);
            this._btnSave.TabIndex = 4;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            // 
            // _lbSorCustomer
            // 
            this._lbSorCustomer.Location = new System.Drawing.Point(6, 23);
            this._lbSorCustomer.Name = "_lbSorCustomer";
            this._lbSorCustomer.Size = new System.Drawing.Size(64, 16);
            this._lbSorCustomer.TabIndex = 36;
            this._lbSorCustomer.Text = "Customer";
            // 
            // _txtCustomer
            // 
            this._txtCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtCustomer.Location = new System.Drawing.Point(76, 20);
            this._txtCustomer.Name = "_txtCustomer";
            this._txtCustomer.ReadOnly = true;
            this._txtCustomer.Size = new System.Drawing.Size(131, 21);
            this._txtCustomer.TabIndex = 34;
            // 
            // _btnFindCustomer
            // 
            this._btnFindCustomer.BackColor = System.Drawing.Color.White;
            this._btnFindCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindCustomer.Location = new System.Drawing.Point(213, 18);
            this._btnFindCustomer.Name = "_btnFindCustomer";
            this._btnFindCustomer.Size = new System.Drawing.Size(25, 23);
            this._btnFindCustomer.TabIndex = 35;
            this._btnFindCustomer.Text = "...";
            this._btnFindCustomer.UseVisualStyleBackColor = false;
            this._btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
            // 
            // _btnDelete
            // 
            this._btnDelete.AccessibleDescription = "Save item";
            this._btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnDelete.ImageIndex = 1;
            this._btnDelete.Location = new System.Drawing.Point(9, 742);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(56, 22);
            this._btnDelete.TabIndex = 2;
            this._btnDelete.Text = "Delete";
            this._btnDelete.UseVisualStyleBackColor = true;
            this._btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // _btnAdd
            // 
            this._btnAdd.AccessibleDescription = "Save item";
            this._btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnAdd.ImageIndex = 1;
            this._btnAdd.Location = new System.Drawing.Point(8, 47);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(667, 23);
            this._btnAdd.TabIndex = 33;
            this._btnAdd.Text = "Add";
            this._btnAdd.UseVisualStyleBackColor = true;
            this._btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // _CboSOR
            // 
            this._CboSOR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._CboSOR.FormattingEnabled = true;
            this._CboSOR.Location = new System.Drawing.Point(451, 21);
            this._CboSOR.Name = "_CboSOR";
            this._CboSOR.Size = new System.Drawing.Size(222, 21);
            this._CboSOR.TabIndex = 32;
            // 
            // _lblSor
            // 
            this._lblSor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblSor.AutoSize = true;
            this._lblSor.Location = new System.Drawing.Point(413, 23);
            this._lblSor.Name = "_lblSor";
            this._lblSor.Size = new System.Drawing.Size(32, 13);
            this._lblSor.TabIndex = 31;
            this._lblSor.Text = "SOR";
            // 
            // _cboJobType
            // 
            this._cboJobType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboJobType.FormattingEnabled = true;
            this._cboJobType.Location = new System.Drawing.Point(307, 20);
            this._cboJobType.Name = "_cboJobType";
            this._cboJobType.Size = new System.Drawing.Size(100, 21);
            this._cboJobType.TabIndex = 3;
            // 
            // _lblCustomerSorJobType
            // 
            this._lblCustomerSorJobType.AutoSize = true;
            this._lblCustomerSorJobType.Location = new System.Drawing.Point(244, 24);
            this._lblCustomerSorJobType.Name = "_lblCustomerSorJobType";
            this._lblCustomerSorJobType.Size = new System.Drawing.Size(57, 13);
            this._lblCustomerSorJobType.TabIndex = 2;
            this._lblCustomerSorJobType.Text = "Job Type";
            // 
            // _dgSOR
            // 
            this._dgSOR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgSOR.DataMember = "";
            this._dgSOR.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgSOR.Location = new System.Drawing.Point(8, 76);
            this._dgSOR.Name = "_dgSOR";
            this._dgSOR.Size = new System.Drawing.Size(667, 651);
            this._dgSOR.TabIndex = 1;
            // 
            // _btnClose
            // 
            this._btnClose.AccessibleDescription = "Save item";
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnClose.ImageIndex = 1;
            this._btnClose.Location = new System.Drawing.Point(16, 802);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(56, 24);
            this._btnClose.TabIndex = 3;
            this._btnClose.Text = "Close";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // _grpCostCentreMatrix
            // 
            this._grpCostCentreMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpCostCentreMatrix.Controls.Add(this._btnReset);
            this._grpCostCentreMatrix.Controls.Add(this._txtJobSpendLimit);
            this._grpCostCentreMatrix.Controls.Add(this._lblJobSpendLimit);
            this._grpCostCentreMatrix.Controls.Add(this._cboLinkType);
            this._grpCostCentreMatrix.Controls.Add(this._lblLinkType);
            this._grpCostCentreMatrix.Controls.Add(this._lblCcCustomer);
            this._grpCostCentreMatrix.Controls.Add(this._btnCcFindCustomer);
            this._grpCostCentreMatrix.Controls.Add(this._txtCcCustomer);
            this._grpCostCentreMatrix.Controls.Add(this._cboCostCentre);
            this._grpCostCentreMatrix.Controls.Add(this._lblCostCentre);
            this._grpCostCentreMatrix.Controls.Add(this._btnAddCCM);
            this._grpCostCentreMatrix.Controls.Add(this._cboRegion);
            this._grpCostCentreMatrix.Controls.Add(this._lblRegion);
            this._grpCostCentreMatrix.Controls.Add(this._cboCCJobType);
            this._grpCostCentreMatrix.Controls.Add(this._btnDeleteCCM);
            this._grpCostCentreMatrix.Controls.Add(this._lblJobType);
            this._grpCostCentreMatrix.Controls.Add(this._dgCostCentreMatrix);
            this._grpCostCentreMatrix.Location = new System.Drawing.Point(697, 12);
            this._grpCostCentreMatrix.Name = "_grpCostCentreMatrix";
            this._grpCostCentreMatrix.Size = new System.Drawing.Size(896, 771);
            this._grpCostCentreMatrix.TabIndex = 35;
            this._grpCostCentreMatrix.TabStop = false;
            this._grpCostCentreMatrix.Text = "Cost Centre Matrix";
            // 
            // _btnReset
            // 
            this._btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnReset.Location = new System.Drawing.Point(810, 50);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(78, 20);
            this._btnReset.TabIndex = 77;
            this._btnReset.Tag = "";
            this._btnReset.Text = "Reset";
            this._btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // _txtJobSpendLimit
            // 
            this._txtJobSpendLimit.Location = new System.Drawing.Point(336, 49);
            this._txtJobSpendLimit.Name = "_txtJobSpendLimit";
            this._txtJobSpendLimit.Size = new System.Drawing.Size(117, 21);
            this._txtJobSpendLimit.TabIndex = 76;
            // 
            // _lblJobSpendLimit
            // 
            this._lblJobSpendLimit.AutoSize = true;
            this._lblJobSpendLimit.Location = new System.Drawing.Point(222, 52);
            this._lblJobSpendLimit.Name = "_lblJobSpendLimit";
            this._lblJobSpendLimit.Size = new System.Drawing.Size(108, 13);
            this._lblJobSpendLimit.TabIndex = 75;
            this._lblJobSpendLimit.Text = "Job Spend Limit £";
            // 
            // _cboLinkType
            // 
            this._cboLinkType.FormattingEnabled = true;
            this._cboLinkType.Location = new System.Drawing.Point(90, 49);
            this._cboLinkType.Name = "_cboLinkType";
            this._cboLinkType.Size = new System.Drawing.Size(119, 21);
            this._cboLinkType.TabIndex = 74;
            this._cboLinkType.SelectedIndexChanged += new System.EventHandler(this.cboLinkType_SelectedIndexChanged);
            // 
            // _lblLinkType
            // 
            this._lblLinkType.AutoSize = true;
            this._lblLinkType.Location = new System.Drawing.Point(8, 52);
            this._lblLinkType.Name = "_lblLinkType";
            this._lblLinkType.Size = new System.Drawing.Size(61, 13);
            this._lblLinkType.TabIndex = 73;
            this._lblLinkType.Text = "Link Type";
            // 
            // _lblCcCustomer
            // 
            this._lblCcCustomer.AutoSize = true;
            this._lblCcCustomer.Location = new System.Drawing.Point(471, 25);
            this._lblCcCustomer.Name = "_lblCcCustomer";
            this._lblCcCustomer.Size = new System.Drawing.Size(63, 13);
            this._lblCcCustomer.TabIndex = 72;
            this._lblCcCustomer.Text = "Customer";
            this._lblCcCustomer.Visible = false;
            // 
            // _btnCcFindCustomer
            // 
            this._btnCcFindCustomer.BackColor = System.Drawing.Color.White;
            this._btnCcFindCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnCcFindCustomer.Location = new System.Drawing.Point(712, 18);
            this._btnCcFindCustomer.Name = "_btnCcFindCustomer";
            this._btnCcFindCustomer.Size = new System.Drawing.Size(32, 23);
            this._btnCcFindCustomer.TabIndex = 71;
            this._btnCcFindCustomer.Text = "...";
            this._btnCcFindCustomer.UseVisualStyleBackColor = false;
            this._btnCcFindCustomer.Visible = false;
            this._btnCcFindCustomer.Click += new System.EventHandler(this.btnCcFindCustomer_Click);
            // 
            // _txtCcCustomer
            // 
            this._txtCcCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtCcCustomer.Location = new System.Drawing.Point(540, 19);
            this._txtCcCustomer.Name = "_txtCcCustomer";
            this._txtCcCustomer.ReadOnly = true;
            this._txtCcCustomer.Size = new System.Drawing.Size(166, 21);
            this._txtCcCustomer.TabIndex = 70;
            this._txtCcCustomer.Visible = false;
            // 
            // _cboCostCentre
            // 
            this._cboCostCentre.FormattingEnabled = true;
            this._cboCostCentre.Location = new System.Drawing.Point(90, 19);
            this._cboCostCentre.Name = "_cboCostCentre";
            this._cboCostCentre.Size = new System.Drawing.Size(73, 21);
            this._cboCostCentre.TabIndex = 69;
            // 
            // _lblCostCentre
            // 
            this._lblCostCentre.AutoSize = true;
            this._lblCostCentre.Location = new System.Drawing.Point(8, 23);
            this._lblCostCentre.Name = "_lblCostCentre";
            this._lblCostCentre.Size = new System.Drawing.Size(76, 13);
            this._lblCostCentre.TabIndex = 68;
            this._lblCostCentre.Text = "Cost Centre";
            // 
            // _btnAddCCM
            // 
            this._btnAddCCM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAddCCM.Location = new System.Drawing.Point(810, 20);
            this._btnAddCCM.Name = "_btnAddCCM";
            this._btnAddCCM.Size = new System.Drawing.Size(78, 20);
            this._btnAddCCM.TabIndex = 67;
            this._btnAddCCM.Tag = "";
            this._btnAddCCM.Text = "Save";
            this._btnAddCCM.Click += new System.EventHandler(this.btnAddCCM_Click);
            // 
            // _cboRegion
            // 
            this._cboRegion.FormattingEnabled = true;
            this._cboRegion.Location = new System.Drawing.Point(523, 19);
            this._cboRegion.Name = "_cboRegion";
            this._cboRegion.Size = new System.Drawing.Size(159, 21);
            this._cboRegion.TabIndex = 32;
            // 
            // _lblRegion
            // 
            this._lblRegion.AutoSize = true;
            this._lblRegion.Location = new System.Drawing.Point(471, 23);
            this._lblRegion.Name = "_lblRegion";
            this._lblRegion.Size = new System.Drawing.Size(46, 13);
            this._lblRegion.TabIndex = 31;
            this._lblRegion.Text = "Region";
            // 
            // _cboCCJobType
            // 
            this._cboCCJobType.FormattingEnabled = true;
            this._cboCCJobType.Location = new System.Drawing.Point(300, 19);
            this._cboCCJobType.Name = "_cboCCJobType";
            this._cboCCJobType.Size = new System.Drawing.Size(153, 21);
            this._cboCCJobType.TabIndex = 3;
            // 
            // _btnDeleteCCM
            // 
            this._btnDeleteCCM.AccessibleDescription = "Save item";
            this._btnDeleteCCM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDeleteCCM.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnDeleteCCM.ImageIndex = 1;
            this._btnDeleteCCM.Location = new System.Drawing.Point(810, 742);
            this._btnDeleteCCM.Name = "_btnDeleteCCM";
            this._btnDeleteCCM.Size = new System.Drawing.Size(78, 22);
            this._btnDeleteCCM.TabIndex = 2;
            this._btnDeleteCCM.Text = "Delete";
            this._btnDeleteCCM.UseVisualStyleBackColor = true;
            this._btnDeleteCCM.Click += new System.EventHandler(this.btnDeleteCCM_Click);
            // 
            // _lblJobType
            // 
            this._lblJobType.AutoSize = true;
            this._lblJobType.Location = new System.Drawing.Point(222, 23);
            this._lblJobType.Name = "_lblJobType";
            this._lblJobType.Size = new System.Drawing.Size(57, 13);
            this._lblJobType.TabIndex = 2;
            this._lblJobType.Text = "Job Type";
            // 
            // _dgCostCentreMatrix
            // 
            this._dgCostCentreMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgCostCentreMatrix.DataMember = "";
            this._dgCostCentreMatrix.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgCostCentreMatrix.Location = new System.Drawing.Point(11, 76);
            this._dgCostCentreMatrix.Name = "_dgCostCentreMatrix";
            this._dgCostCentreMatrix.Size = new System.Drawing.Size(880, 651);
            this._dgCostCentreMatrix.TabIndex = 1;
            this._dgCostCentreMatrix.Click += new System.EventHandler(this.dgCostCentreMatrix_Click);
            // 
            // FRMCustomerSORJobType
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1604, 852);
            this.Controls.Add(this._grpCostCentreMatrix);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._grpLocks);
            this.MinimumSize = new System.Drawing.Size(793, 520);
            this.Name = "FRMCustomerSORJobType";
            this.Text = "Setup";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpLocks.ResumeLayout(false);
            this._grpLocks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgSOR)).EndInit();
            this._grpCostCentreMatrix.ResumeLayout(false);
            this._grpCostCentreMatrix.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgCostCentreMatrix)).EndInit();
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupDataGrid();
            SetupCCMDataGrid();
            var argc = cboJobType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc1 = cboCCJobType;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc2 = cboRegion;
            Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc3 = cboLinkType;
            Combo.SetUpCombo(ref argc3, App.DB.CostCentreLinkType.GetAll().Table, "Id", "Name", Enums.ComboValues.Please_Select);
            switch (true)
            {
                case object _ when App.IsGasway:
                    {
                        var argc4 = cboCostCentre;
                        Combo.SetUpCombo(ref argc4, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }

                default:
                    {
                        var argc5 = cboCostCentre;
                        Combo.SetUpCombo(ref argc5, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }
            }

            cboLinkType.Items.RemoveAt(0);
            var argcombo = cboLinkType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 1.ToString());
            var argc6 = CboSOR;
            Combo.SetUpCombo(ref argc6, App.DB.CustomerScheduleOfRate.GetAll_For_CustomerID(App.CurrentCustomerID).Table, "CustomerScheduleOfRateID", "Description", Enums.ComboValues.Please_Select);
            SORSkills = App.DB.CustomerScheduleOfRate.Customer_Jobtype_Sor_GetAll();
            UpdateCostCentreMatrixDg();
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

        private Customer _theCustomer = new Customer();

        public Customer theCustomer
        {
            get
            {
                return _theCustomer;
            }

            set
            {
                _theCustomer = value;
                if (!(_theCustomer.CustomerID == 0))
                {
                    txtCustomer.Text = theCustomer.Name + " (A/C No : " + _theCustomer.AccountNumber + ")";
                    var argc = CboSOR;
                    Combo.SetUpCombo(ref argc, App.DB.CustomerScheduleOfRate.GetAll_For_CustomerID(_theCustomer.CustomerID).Table, "CustomerScheduleOfRateID", "Description", Enums.ComboValues.Please_Select);
                }
                else
                {
                    txtCustomer.Text = "";
                }
            }
        }

        private Customer _customer;

        public Customer Customer
        {
            get
            {
                return _customer;
            }

            set
            {
                _customer = value;
                if (Helper.MakeIntegerValid(_customer?.CustomerID) > 0)
                {
                    txtCcCustomer.Text = _customer.Name;
                }
                else
                {
                    txtCcCustomer.Text = "";
                }
            }
        }

        private DataView _SORSkills;

        private DataView SORSkills
        {
            get
            {
                return _SORSkills;
            }

            set
            {
                _SORSkills = value;
                _SORSkills.AllowNew = false;
                _SORSkills.AllowEdit = false;
                _SORSkills.AllowDelete = false;
                _SORSkills.Table.TableName = "Skills";
                dgSOR.DataSource = _SORSkills;
            }
        }

        private DataRow SelectedDataRow
        {
            get
            {
                if (!(dgSOR.CurrentRowIndex == -1))
                {
                    return SORSkills[dgSOR.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _costCentreMatrix;

        private DataView CostCentreMatrix
        {
            get
            {
                return _costCentreMatrix;
            }

            set
            {
                _costCentreMatrix = value;
                _costCentreMatrix.AllowNew = false;
                _costCentreMatrix.AllowEdit = false;
                _costCentreMatrix.AllowDelete = false;
                _costCentreMatrix.Table.TableName = "CostCentreMatrix";
                dgCostCentreMatrix.DataSource = CostCentreMatrix;
            }
        }

        private DataRow SelectedDataRowCCM
        {
            get
            {
                if (!(dgCostCentreMatrix.CurrentRowIndex == -1))
                {
                    return CostCentreMatrix[dgCostCentreMatrix.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private void SetupDataGrid()
        {
            Helper.SetUpDataGrid(dgSOR);
            var tbStyle = dgSOR.TableStyles[0];
            var CustomerJobTypeSORID = new DataGridLabelColumn();
            CustomerJobTypeSORID.Format = "";
            CustomerJobTypeSORID.FormatInfo = null;
            CustomerJobTypeSORID.HeaderText = "CustomerJobTypeSORID";
            CustomerJobTypeSORID.MappingName = "CustomerJobTypeSORID";
            CustomerJobTypeSORID.ReadOnly = true;
            CustomerJobTypeSORID.Width = 5;
            CustomerJobTypeSORID.NullText = "";
            tbStyle.GridColumnStyles.Add(CustomerJobTypeSORID);
            var CustomerScheduleOfRateID = new DataGridLabelColumn();
            CustomerScheduleOfRateID.Format = "";
            CustomerScheduleOfRateID.FormatInfo = null;
            CustomerScheduleOfRateID.HeaderText = "CustomerScheduleOfRateID";
            CustomerScheduleOfRateID.MappingName = "CustomerScheduleOfRateID";
            CustomerScheduleOfRateID.ReadOnly = true;
            CustomerScheduleOfRateID.Width = 5;
            CustomerScheduleOfRateID.NullText = "";
            tbStyle.GridColumnStyles.Add(CustomerScheduleOfRateID);
            var CustomerID = new DataGridLabelColumn();
            CustomerID.Format = "";
            CustomerID.FormatInfo = null;
            CustomerID.HeaderText = "CustomerID";
            CustomerID.MappingName = "CustomerID";
            CustomerID.ReadOnly = true;
            CustomerID.Width = 5;
            CustomerID.NullText = "";
            tbStyle.GridColumnStyles.Add(CustomerID);
            var JobTypeID = new DataGridLabelColumn();
            JobTypeID.Format = "";
            JobTypeID.FormatInfo = null;
            JobTypeID.HeaderText = "JobTypeID";
            JobTypeID.MappingName = "JobTypeID";
            JobTypeID.ReadOnly = true;
            JobTypeID.Width = 5;
            JobTypeID.NullText = "";
            tbStyle.GridColumnStyles.Add(JobTypeID);
            var Customer = new DataGridLabelColumn();
            Customer.Format = "";
            Customer.FormatInfo = null;
            Customer.HeaderText = "Customer Name";
            Customer.MappingName = "Customer";
            Customer.ReadOnly = true;
            Customer.Width = 100;
            Customer.NullText = "";
            tbStyle.GridColumnStyles.Add(Customer);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job Type";
            JobNumber.MappingName = "JobType";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 150;
            JobNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(JobNumber);
            var SORCode = new DataGridLabelColumn();
            SORCode.Format = "";
            SORCode.FormatInfo = null;
            SORCode.HeaderText = "SOR Code";
            SORCode.MappingName = "code";
            SORCode.ReadOnly = true;
            SORCode.Width = 100;
            SORCode.NullText = "";
            tbStyle.GridColumnStyles.Add(SORCode);
            var FullName = new DataGridLabelColumn();
            FullName.Format = "";
            FullName.FormatInfo = null;
            FullName.HeaderText = "SOR Description";
            FullName.MappingName = "Description";
            FullName.ReadOnly = true;
            FullName.Width = 150;
            FullName.NullText = "";
            tbStyle.GridColumnStyles.Add(FullName);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = "Skills";
            dgSOR.TableStyles.Add(tbStyle);
        }

        private void SetupCCMDataGrid()
        {
            Helper.SetUpDataGrid(dgCostCentreMatrix);
            var tbStyle = dgCostCentreMatrix.TableStyles[0];
            var costCentre = new DataGridLabelColumn();
            costCentre.Format = "";
            costCentre.FormatInfo = null;
            costCentre.HeaderText = "Cost Centre";
            costCentre.MappingName = "CostCentre";
            costCentre.ReadOnly = true;
            costCentre.Width = 100;
            costCentre.NullText = "";
            tbStyle.GridColumnStyles.Add(costCentre);
            var jobType = new DataGridLabelColumn();
            jobType.Format = "";
            jobType.FormatInfo = null;
            jobType.HeaderText = "Job Type";
            jobType.MappingName = "JobType";
            jobType.ReadOnly = true;
            jobType.Width = 250;
            jobType.NullText = "";
            tbStyle.GridColumnStyles.Add(jobType);
            var link = new DataGridLabelColumn();
            link.Format = "";
            link.FormatInfo = null;
            link.HeaderText = "Link";
            link.MappingName = "Link";
            link.ReadOnly = true;
            link.Width = 200;
            link.NullText = "";
            tbStyle.GridColumnStyles.Add(link);
            var linkType = new DataGridLabelColumn();
            linkType.Format = "";
            linkType.FormatInfo = null;
            linkType.HeaderText = "Link Type";
            linkType.MappingName = "LinkType";
            linkType.ReadOnly = true;
            linkType.Width = 150;
            linkType.NullText = "";
            tbStyle.GridColumnStyles.Add(linkType);
            var jobSpendLimit = new DataGridLabelColumn();
            jobSpendLimit.Format = "c";
            jobSpendLimit.FormatInfo = null;
            jobSpendLimit.HeaderText = "Job Spend Limit";
            jobSpendLimit.MappingName = "JobSpendLimit";
            jobSpendLimit.ReadOnly = true;
            jobSpendLimit.Width = 150;
            jobSpendLimit.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(jobSpendLimit);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = "CostCentreMatrix";
            dgCostCentreMatrix.TableStyles.Add(tbStyle);
        }

        private void FRMJobLocks_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedDataRow is null)
            {
                App.ShowMessage("Please select a line to remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (App.EnterOverridePassword() == true)
            {
                if (App.ShowMessage("Are you sure you wish to delete this row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    App.DB.CustomerScheduleOfRate.Customer_Jobtype_Sor_Delete(Conversions.ToInteger(SelectedDataRow["CustomerJobTypeSORID"]));
                    SORSkills = App.DB.CustomerScheduleOfRate.Customer_Jobtype_Sor_GetAll();
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Error unlocking job : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (theCustomer.CustomerID > 0 & Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboJobType)) > 0 & Conversions.ToDouble(Combo.get_GetSelectedItemValue(CboSOR)) > 0)
            {
                App.DB.CustomerScheduleOfRate.Customer_Jobtype_Sor_Insert(theCustomer.CustomerID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboJobType)), Conversions.ToInteger(Combo.get_GetSelectedItemValue(CboSOR)));
                SORSkills = App.DB.CustomerScheduleOfRate.Customer_Jobtype_Sor_GetAll();
            }
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblCustomer));
            if (!(ID == 0))
            {
                theCustomer = App.DB.Customer.Customer_Get(ID);
            }
        }

        private void btnCcFindCustomer_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblCustomer));
            if (!(ID == 0))
            {
                Customer = App.DB.Customer.Customer_Get(ID);
            }
        }

        private void btnAddCCM_Click(object sender, EventArgs e)
        {
            var _ssmList = new List<Enums.SecuritySystemModules>();
            _ssmList.Add(Enums.SecuritySystemModules.IT);
            _ssmList.Add(Enums.SecuritySystemModules.Finance);
            if (!App.loggedInUser.HasAccessToMulitpleModules(_ssmList))
            {
                App.ShowSecurityError();
            }

            string costCentre = Helper.MakeStringValid(Combo.get_GetSelectedItemValue(cboCostCentre).Trim());
            int jobTypeId = Helper.MakeIntegerValid(Combo.get_GetSelectedItemValue(cboCCJobType));
            decimal costCap = Conversions.ToDecimal(txtJobSpendLimit.Text.Length > 0 ? Helper.MakeDoubleValid(txtJobSpendLimit.Text) : default);
            if (jobTypeId == 0 | (costCentre ?? "") == "-1")
                return;
            var ccs = App.DB.CostCentre.Get(jobTypeId, default, GetBy.JobTypeId);
            int linkId = 0;
            int linkTypeId = Helper.MakeIntegerValid(Combo.get_GetSelectedItemValue(cboLinkType));
            switch (linkTypeId)
            {
                case (int)LinkType.RegionId:
                    {
                        linkId = Helper.MakeIntegerValid(Combo.get_GetSelectedItemValue(cboRegion));
                        if (linkId == 0)
                        {
                            App.ShowMessage("Please select a region!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        break;
                    }

                case (int)LinkType.CustomerId:
                    {
                        linkId = Helper.MakeIntegerValid(Customer?.CustomerID);
                        if (linkId == 0)
                        {
                            App.ShowMessage("Please select a customer!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        break;
                    }
            }

            if (ccs is object)
                ccs = ccs.Where(x => x.JobTypeId == jobTypeId & x.LinkId == linkId & x.LinkTypeId == linkTypeId).ToList();
            if (ccs is object && ccs.Count > 0)
            {
                ccs.FirstOrDefault().CostCentreId = Conversions.ToInteger(costCentre);
                ccs.FirstOrDefault().JobTypeId = jobTypeId;
                ccs.FirstOrDefault().LinkId = linkId;
                ccs.FirstOrDefault().LinkTypeId = linkTypeId;
                ccs.FirstOrDefault().JobSpendLimit = costCap;
                App.DB.CostCentre.Update(ccs.FirstOrDefault());
                UpdateCostCentreMatrixDg();
            }
            else
            {
                var cc = new CostCentre() { CostCentreId = Conversions.ToInteger(costCentre), JobTypeId = jobTypeId, LinkId = linkId, LinkTypeId = linkTypeId, JobSpendLimit = costCap };
                cc = App.DB.CostCentre.Insert(cc);
                if (cc.Id > 0)
                    UpdateCostCentreMatrixDg();
            }
        }

        public void UpdateCostCentreMatrixDg()
        {
            CostCentreMatrix = App.DB.CostCentre.GetAll();
            ResetControls();
        }

        public void ResetControls()
        {
            var argcombo = cboCCJobType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            var argcombo1 = cboRegion;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, 0.ToString());
            var argcombo2 = cboCostCentre;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, "-1");
            Customer = null;
            txtJobSpendLimit.Text = "";
        }

        private void btnDeleteCCM_Click(object sender, EventArgs e)
        {
            var _ssmList = new List<Enums.SecuritySystemModules>();
            _ssmList.Add(Enums.SecuritySystemModules.IT);
            _ssmList.Add(Enums.SecuritySystemModules.Finance);
            if (!App.loggedInUser.HasAccessToMulitpleModules(_ssmList))
            {
                App.ShowSecurityError();
            }

            if (SelectedDataRowCCM is null)
            {
                App.ShowMessage("Please select a line to remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (App.ShowMessage("Are you sure you wish to delete this row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                App.DB.CostCentre.Delete(Conversions.ToInteger(SelectedDataRowCCM["Id"]));
                UpdateCostCentreMatrixDg();
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error deleting: " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void cboLinkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int linkTypeId = Helper.MakeIntegerValid(Combo.get_GetSelectedItemValue(cboLinkType));
            switch (linkTypeId)
            {
                case (int)(LinkType.RegionId):
                    {
                        lblRegion.Visible = true;
                        cboRegion.Visible = true;
                        lblCcCustomer.Visible = false;
                        txtCcCustomer.Visible = false;
                        btnCcFindCustomer.Visible = false;
                        break;
                    }

                case (int)(LinkType.CustomerId):
                    {
                        lblCcCustomer.Visible = true;
                        txtCcCustomer.Visible = true;
                        btnCcFindCustomer.Visible = true;
                        lblRegion.Visible = false;
                        cboRegion.Visible = false;
                        break;
                    }
            }
        }

        private void dgCostCentreMatrix_Click(object sender, EventArgs e)
        {
            if (SelectedDataRowCCM is null)
                return;
            var costCentre = App.DB.CostCentre.Get(Conversions.ToInteger(SelectedDataRowCCM["Id"]), default, GetBy.Id).FirstOrDefault();
            var argcombo = cboCostCentre;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, costCentre.CostCentreId.ToString());
            var argcombo1 = cboCCJobType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, costCentre.JobTypeId.ToString());
            var argcombo2 = cboLinkType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, costCentre.LinkTypeId.ToString());
            if (costCentre.LinkTypeId == (int)LinkType.RegionId)
            {
                var argcombo3 = cboRegion;
                Combo.SetSelectedComboItem_By_Value(ref argcombo3, costCentre.LinkId.ToString());
            }
            else
            {
                Customer = App.DB.Customer.Customer_Get(costCentre.LinkId);
            }

            txtJobSpendLimit.Text = Helper.MakeStringValid(costCentre.JobSpendLimit);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetControls();
        }
    }
}