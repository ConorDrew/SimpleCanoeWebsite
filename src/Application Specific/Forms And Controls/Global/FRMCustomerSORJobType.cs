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

        internal GroupBox grpLocks
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpLocks;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpLocks != null)
                {
                }

                _grpLocks = value;
                if (_grpLocks != null)
                {
                }
            }
        }

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

        internal Label lblCustomerSorJobType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCustomerSorJobType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCustomerSorJobType != null)
                {
                }

                _lblCustomerSorJobType = value;
                if (_lblCustomerSorJobType != null)
                {
                }
            }
        }

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

        internal Label lblSor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSor != null)
                {
                }

                _lblSor = value;
                if (_lblSor != null)
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
                }

                _btnSave = value;
                if (_btnSave != null)
                {
                }
            }
        }

        private Label _lbSorCustomer;

        internal Label lbSorCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbSorCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbSorCustomer != null)
                {
                }

                _lbSorCustomer = value;
                if (_lbSorCustomer != null)
                {
                }
            }
        }

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

        internal Button btnFindCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindCustomer != null)
                {
                    _btnFindCustomer.Click -= btnFindCustomer_Click;
                }

                _btnFindCustomer = value;
                if (_btnFindCustomer != null)
                {
                    _btnFindCustomer.Click += btnFindCustomer_Click;
                }
            }
        }

        private GroupBox _grpCostCentreMatrix;

        internal GroupBox grpCostCentreMatrix
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpCostCentreMatrix;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpCostCentreMatrix != null)
                {
                }

                _grpCostCentreMatrix = value;
                if (_grpCostCentreMatrix != null)
                {
                }
            }
        }

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

        internal Button btnDeleteCCM
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDeleteCCM;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeleteCCM != null)
                {
                    _btnDeleteCCM.Click -= btnDeleteCCM_Click;
                }

                _btnDeleteCCM = value;
                if (_btnDeleteCCM != null)
                {
                    _btnDeleteCCM.Click += btnDeleteCCM_Click;
                }
            }
        }

        private Label _lblJobType;

        internal Label lblJobType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblJobType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblJobType != null)
                {
                }

                _lblJobType = value;
                if (_lblJobType != null)
                {
                }
            }
        }

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

        internal Button btnAddCCM
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddCCM;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddCCM != null)
                {
                    _btnAddCCM.Click -= btnAddCCM_Click;
                }

                _btnAddCCM = value;
                if (_btnAddCCM != null)
                {
                    _btnAddCCM.Click += btnAddCCM_Click;
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

        internal Label lblLinkType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblLinkType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblLinkType != null)
                {
                }

                _lblLinkType = value;
                if (_lblLinkType != null)
                {
                }
            }
        }

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

        internal Label lblJobSpendLimit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblJobSpendLimit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblJobSpendLimit != null)
                {
                }

                _lblJobSpendLimit = value;
                if (_lblJobSpendLimit != null)
                {
                }
            }
        }

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
            _grpLocks = new GroupBox();
            _btnSave = new Button();
            _lbSorCustomer = new Label();
            _txtCustomer = new TextBox();
            _btnFindCustomer = new Button();
            _btnFindCustomer.Click += new EventHandler(btnFindCustomer_Click);
            _btnDelete = new Button();
            _btnDelete.Click += new EventHandler(btnDelete_Click);
            _btnAdd = new Button();
            _btnAdd.Click += new EventHandler(btnAdd_Click);
            _CboSOR = new ComboBox();
            _lblSor = new Label();
            _cboJobType = new ComboBox();
            _lblCustomerSorJobType = new Label();
            _dgSOR = new DataGrid();
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _grpCostCentreMatrix = new GroupBox();
            _btnReset = new Button();
            _btnReset.Click += new EventHandler(btnReset_Click);
            _txtJobSpendLimit = new TextBox();
            _lblJobSpendLimit = new Label();
            _cboLinkType = new ComboBox();
            _cboLinkType.SelectedIndexChanged += new EventHandler(cboLinkType_SelectedIndexChanged);
            _lblLinkType = new Label();
            _lblCcCustomer = new Label();
            _btnCcFindCustomer = new Button();
            _btnCcFindCustomer.Click += new EventHandler(btnCcFindCustomer_Click);
            _txtCcCustomer = new TextBox();
            _cboCostCentre = new ComboBox();
            _lblCostCentre = new Label();
            _btnAddCCM = new Button();
            _btnAddCCM.Click += new EventHandler(btnAddCCM_Click);
            _cboRegion = new ComboBox();
            _lblRegion = new Label();
            _cboCCJobType = new ComboBox();
            _btnDeleteCCM = new Button();
            _btnDeleteCCM.Click += new EventHandler(btnDeleteCCM_Click);
            _lblJobType = new Label();
            _dgCostCentreMatrix = new DataGrid();
            _dgCostCentreMatrix.Click += new EventHandler(dgCostCentreMatrix_Click);
            _grpLocks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSOR).BeginInit();
            _grpCostCentreMatrix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgCostCentreMatrix).BeginInit();
            SuspendLayout();
            //
            // grpLocks
            //
            _grpLocks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _grpLocks.Controls.Add(_btnSave);
            _grpLocks.Controls.Add(_lbSorCustomer);
            _grpLocks.Controls.Add(_txtCustomer);
            _grpLocks.Controls.Add(_btnFindCustomer);
            _grpLocks.Controls.Add(_btnDelete);
            _grpLocks.Controls.Add(_btnAdd);
            _grpLocks.Controls.Add(_CboSOR);
            _grpLocks.Controls.Add(_lblSor);
            _grpLocks.Controls.Add(_cboJobType);
            _grpLocks.Controls.Add(_lblCustomerSorJobType);
            _grpLocks.Controls.Add(_dgSOR);
            _grpLocks.Location = new Point(8, 40);
            _grpLocks.Name = "grpLocks";
            _grpLocks.Size = new Size(683, 743);
            _grpLocks.TabIndex = 1;
            _grpLocks.TabStop = false;
            //
            // btnSave
            //
            _btnSave.AccessibleDescription = "Save item";
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSave.Cursor = Cursors.Hand;
            _btnSave.ImageIndex = 1;
            _btnSave.Location = new Point(621, 714);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(56, 22);
            _btnSave.TabIndex = 4;
            _btnSave.Text = "Save";
            _btnSave.UseVisualStyleBackColor = true;
            //
            // lbSorCustomer
            //
            _lbSorCustomer.Location = new Point(6, 23);
            _lbSorCustomer.Name = "lbSorCustomer";
            _lbSorCustomer.Size = new Size(64, 16);
            _lbSorCustomer.TabIndex = 36;
            _lbSorCustomer.Text = "Customer";
            //
            // txtCustomer
            //
            _txtCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtCustomer.Location = new Point(76, 20);
            _txtCustomer.Name = "txtCustomer";
            _txtCustomer.ReadOnly = true;
            _txtCustomer.Size = new Size(131, 21);
            _txtCustomer.TabIndex = 34;
            //
            // btnFindCustomer
            //
            _btnFindCustomer.BackColor = Color.White;
            _btnFindCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindCustomer.Location = new Point(213, 18);
            _btnFindCustomer.Name = "btnFindCustomer";
            _btnFindCustomer.Size = new Size(25, 23);
            _btnFindCustomer.TabIndex = 35;
            _btnFindCustomer.Text = "...";
            _btnFindCustomer.UseVisualStyleBackColor = false;
            //
            // btnDelete
            //
            _btnDelete.AccessibleDescription = "Save item";
            _btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnDelete.Cursor = Cursors.Hand;
            _btnDelete.ImageIndex = 1;
            _btnDelete.Location = new Point(9, 714);
            _btnDelete.Name = "btnDelete";
            _btnDelete.Size = new Size(56, 22);
            _btnDelete.TabIndex = 2;
            _btnDelete.Text = "Delete";
            _btnDelete.UseVisualStyleBackColor = true;
            //
            // btnAdd
            //
            _btnAdd.AccessibleDescription = "Save item";
            _btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _btnAdd.Cursor = Cursors.Hand;
            _btnAdd.ImageIndex = 1;
            _btnAdd.Location = new Point(8, 47);
            _btnAdd.Name = "btnAdd";
            _btnAdd.Size = new Size(667, 23);
            _btnAdd.TabIndex = 33;
            _btnAdd.Text = "Add";
            _btnAdd.UseVisualStyleBackColor = true;
            //
            // CboSOR
            //
            _CboSOR.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _CboSOR.FormattingEnabled = true;
            _CboSOR.Location = new Point(451, 21);
            _CboSOR.Name = "CboSOR";
            _CboSOR.Size = new Size(222, 21);
            _CboSOR.TabIndex = 32;
            //
            // lblSor
            //
            _lblSor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblSor.AutoSize = true;
            _lblSor.Location = new Point(413, 23);
            _lblSor.Name = "lblSor";
            _lblSor.Size = new Size(32, 13);
            _lblSor.TabIndex = 31;
            _lblSor.Text = "SOR";
            //
            // cboJobType
            //
            _cboJobType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboJobType.FormattingEnabled = true;
            _cboJobType.Location = new Point(307, 20);
            _cboJobType.Name = "cboJobType";
            _cboJobType.Size = new Size(100, 21);
            _cboJobType.TabIndex = 3;
            //
            // lblCustomerSorJobType
            //
            _lblCustomerSorJobType.AutoSize = true;
            _lblCustomerSorJobType.Location = new Point(244, 24);
            _lblCustomerSorJobType.Name = "lblCustomerSorJobType";
            _lblCustomerSorJobType.Size = new Size(57, 13);
            _lblCustomerSorJobType.TabIndex = 2;
            _lblCustomerSorJobType.Text = "Job Type";
            //
            // dgSOR
            //
            _dgSOR.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgSOR.DataMember = "";
            _dgSOR.HeaderForeColor = SystemColors.ControlText;
            _dgSOR.Location = new Point(8, 76);
            _dgSOR.Name = "dgSOR";
            _dgSOR.Size = new Size(667, 623);
            _dgSOR.TabIndex = 1;
            //
            // btnClose
            //
            _btnClose.AccessibleDescription = "Save item";
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.Cursor = Cursors.Hand;
            _btnClose.ImageIndex = 1;
            _btnClose.Location = new Point(16, 802);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(56, 24);
            _btnClose.TabIndex = 3;
            _btnClose.Text = "Close";
            _btnClose.UseVisualStyleBackColor = true;
            //
            // grpCostCentreMatrix
            //
            _grpCostCentreMatrix.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpCostCentreMatrix.Controls.Add(_btnReset);
            _grpCostCentreMatrix.Controls.Add(_txtJobSpendLimit);
            _grpCostCentreMatrix.Controls.Add(_lblJobSpendLimit);
            _grpCostCentreMatrix.Controls.Add(_cboLinkType);
            _grpCostCentreMatrix.Controls.Add(_lblLinkType);
            _grpCostCentreMatrix.Controls.Add(_lblCcCustomer);
            _grpCostCentreMatrix.Controls.Add(_btnCcFindCustomer);
            _grpCostCentreMatrix.Controls.Add(_txtCcCustomer);
            _grpCostCentreMatrix.Controls.Add(_cboCostCentre);
            _grpCostCentreMatrix.Controls.Add(_lblCostCentre);
            _grpCostCentreMatrix.Controls.Add(_btnAddCCM);
            _grpCostCentreMatrix.Controls.Add(_cboRegion);
            _grpCostCentreMatrix.Controls.Add(_lblRegion);
            _grpCostCentreMatrix.Controls.Add(_cboCCJobType);
            _grpCostCentreMatrix.Controls.Add(_btnDeleteCCM);
            _grpCostCentreMatrix.Controls.Add(_lblJobType);
            _grpCostCentreMatrix.Controls.Add(_dgCostCentreMatrix);
            _grpCostCentreMatrix.Location = new Point(697, 40);
            _grpCostCentreMatrix.Name = "grpCostCentreMatrix";
            _grpCostCentreMatrix.Size = new Size(896, 743);
            _grpCostCentreMatrix.TabIndex = 35;
            _grpCostCentreMatrix.TabStop = false;
            _grpCostCentreMatrix.Text = "Cost Centre Matrix";
            //
            // btnReset
            //
            _btnReset.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnReset.Location = new Point(810, 50);
            _btnReset.Name = "btnReset";
            _btnReset.Size = new Size(78, 20);
            _btnReset.TabIndex = 77;
            _btnReset.Tag = "";
            _btnReset.Text = "Reset";
            //
            // txtJobSpendLimit
            //
            _txtJobSpendLimit.Location = new Point(336, 49);
            _txtJobSpendLimit.Name = "txtJobSpendLimit";
            _txtJobSpendLimit.Size = new Size(117, 21);
            _txtJobSpendLimit.TabIndex = 76;
            //
            // lblJobSpendLimit
            //
            _lblJobSpendLimit.AutoSize = true;
            _lblJobSpendLimit.Location = new Point(222, 52);
            _lblJobSpendLimit.Name = "lblJobSpendLimit";
            _lblJobSpendLimit.Size = new Size(108, 13);
            _lblJobSpendLimit.TabIndex = 75;
            _lblJobSpendLimit.Text = "Job Spend Limit £";
            //
            // cboLinkType
            //
            _cboLinkType.FormattingEnabled = true;
            _cboLinkType.Location = new Point(90, 49);
            _cboLinkType.Name = "cboLinkType";
            _cboLinkType.Size = new Size(119, 21);
            _cboLinkType.TabIndex = 74;
            //
            // lblLinkType
            //
            _lblLinkType.AutoSize = true;
            _lblLinkType.Location = new Point(8, 52);
            _lblLinkType.Name = "lblLinkType";
            _lblLinkType.Size = new Size(61, 13);
            _lblLinkType.TabIndex = 73;
            _lblLinkType.Text = "Link Type";
            //
            // lblCcCustomer
            //
            _lblCcCustomer.AutoSize = true;
            _lblCcCustomer.Location = new Point(471, 25);
            _lblCcCustomer.Name = "lblCcCustomer";
            _lblCcCustomer.Size = new Size(63, 13);
            _lblCcCustomer.TabIndex = 72;
            _lblCcCustomer.Text = "Customer";
            _lblCcCustomer.Visible = false;
            //
            // btnCcFindCustomer
            //
            _btnCcFindCustomer.BackColor = Color.White;
            _btnCcFindCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnCcFindCustomer.Location = new Point(712, 18);
            _btnCcFindCustomer.Name = "btnCcFindCustomer";
            _btnCcFindCustomer.Size = new Size(32, 23);
            _btnCcFindCustomer.TabIndex = 71;
            _btnCcFindCustomer.Text = "...";
            _btnCcFindCustomer.UseVisualStyleBackColor = false;
            _btnCcFindCustomer.Visible = false;
            //
            // txtCcCustomer
            //
            _txtCcCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtCcCustomer.Location = new Point(540, 19);
            _txtCcCustomer.Name = "txtCcCustomer";
            _txtCcCustomer.ReadOnly = true;
            _txtCcCustomer.Size = new Size(166, 21);
            _txtCcCustomer.TabIndex = 70;
            _txtCcCustomer.Visible = false;
            //
            // cboCostCentre
            //
            _cboCostCentre.FormattingEnabled = true;
            _cboCostCentre.Location = new Point(90, 19);
            _cboCostCentre.Name = "cboCostCentre";
            _cboCostCentre.Size = new Size(73, 21);
            _cboCostCentre.TabIndex = 69;
            //
            // lblCostCentre
            //
            _lblCostCentre.AutoSize = true;
            _lblCostCentre.Location = new Point(8, 23);
            _lblCostCentre.Name = "lblCostCentre";
            _lblCostCentre.Size = new Size(76, 13);
            _lblCostCentre.TabIndex = 68;
            _lblCostCentre.Text = "Cost Centre";
            //
            // btnAddCCM
            //
            _btnAddCCM.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAddCCM.Location = new Point(810, 20);
            _btnAddCCM.Name = "btnAddCCM";
            _btnAddCCM.Size = new Size(78, 20);
            _btnAddCCM.TabIndex = 67;
            _btnAddCCM.Tag = "";
            _btnAddCCM.Text = "Save";
            //
            // cboRegion
            //
            _cboRegion.FormattingEnabled = true;
            _cboRegion.Location = new Point(523, 19);
            _cboRegion.Name = "cboRegion";
            _cboRegion.Size = new Size(159, 21);
            _cboRegion.TabIndex = 32;
            //
            // lblRegion
            //
            _lblRegion.AutoSize = true;
            _lblRegion.Location = new Point(471, 23);
            _lblRegion.Name = "lblRegion";
            _lblRegion.Size = new Size(46, 13);
            _lblRegion.TabIndex = 31;
            _lblRegion.Text = "Region";
            //
            // cboCCJobType
            //
            _cboCCJobType.FormattingEnabled = true;
            _cboCCJobType.Location = new Point(300, 19);
            _cboCCJobType.Name = "cboCCJobType";
            _cboCCJobType.Size = new Size(153, 21);
            _cboCCJobType.TabIndex = 3;
            //
            // btnDeleteCCM
            //
            _btnDeleteCCM.AccessibleDescription = "Save item";
            _btnDeleteCCM.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnDeleteCCM.Cursor = Cursors.Hand;
            _btnDeleteCCM.ImageIndex = 1;
            _btnDeleteCCM.Location = new Point(810, 714);
            _btnDeleteCCM.Name = "btnDeleteCCM";
            _btnDeleteCCM.Size = new Size(78, 22);
            _btnDeleteCCM.TabIndex = 2;
            _btnDeleteCCM.Text = "Delete";
            _btnDeleteCCM.UseVisualStyleBackColor = true;
            //
            // lblJobType
            //
            _lblJobType.AutoSize = true;
            _lblJobType.Location = new Point(222, 23);
            _lblJobType.Name = "lblJobType";
            _lblJobType.Size = new Size(57, 13);
            _lblJobType.TabIndex = 2;
            _lblJobType.Text = "Job Type";
            //
            // dgCostCentreMatrix
            //
            _dgCostCentreMatrix.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgCostCentreMatrix.DataMember = "";
            _dgCostCentreMatrix.HeaderForeColor = SystemColors.ControlText;
            _dgCostCentreMatrix.Location = new Point(11, 76);
            _dgCostCentreMatrix.Name = "dgCostCentreMatrix";
            _dgCostCentreMatrix.Size = new Size(880, 623);
            _dgCostCentreMatrix.TabIndex = 1;
            //
            // FRMCustomerSORJobType
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(1604, 852);
            Controls.Add(_grpCostCentreMatrix);
            Controls.Add(_btnClose);
            Controls.Add(_grpLocks);
            MinimumSize = new Size(793, 520);
            Name = "FRMCustomerSORJobType";
            Text = "Setup";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpLocks, 0);
            Controls.SetChildIndex(_btnClose, 0);
            Controls.SetChildIndex(_grpCostCentreMatrix, 0);
            _grpLocks.ResumeLayout(false);
            _grpLocks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSOR).EndInit();
            _grpCostCentreMatrix.ResumeLayout(false);
            _grpCostCentreMatrix.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgCostCentreMatrix).EndInit();
            ResumeLayout(false);
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