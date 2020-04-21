using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FRMConsolidation : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMConsolidation() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMConsolidation_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            var argc = cboStatus;
            Combo.SetUpCombo(ref argc, App.DB.Order.OrderStatus_Get_All().Table, "OrderStatusID", "Name", Entity.Sys.Enums.ComboValues.None);
            var argc1 = cboTaxCode;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.VATCodes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Dashes);
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

        private GroupBox _grpMain;

        internal GroupBox grpMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpMain != null)
                {
                }

                _grpMain = value;
                if (_grpMain != null)
                {
                }
            }
        }

        private TextBox _txtReference;

        internal TextBox txtReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtReference != null)
                {
                }

                _txtReference = value;
                if (_txtReference != null)
                {
                }
            }
        }

        private ComboBox _cboStatus;

        internal ComboBox cboStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboStatus != null)
                {
                    _cboStatus.SelectedIndexChanged -= cboStatus_SelectedIndexChanged;
                }

                _cboStatus = value;
                if (_cboStatus != null)
                {
                    _cboStatus.SelectedIndexChanged += cboStatus_SelectedIndexChanged;
                }
            }
        }

        private Button _btnSupplier;

        internal Button btnSupplier
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSupplier;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSupplier != null)
                {
                    _btnSupplier.Click -= btnSupplier_Click;
                }

                _btnSupplier = value;
                if (_btnSupplier != null)
                {
                    _btnSupplier.Click += btnSupplier_Click;
                }
            }
        }

        private TextBox _txtComments;

        internal TextBox txtComments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtComments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtComments != null)
                {
                }

                _txtComments = value;
                if (_txtComments != null)
                {
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

        private GroupBox _grpOrders;

        internal GroupBox grpOrders
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpOrders;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpOrders != null)
                {
                }

                _grpOrders = value;
                if (_grpOrders != null)
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

        private DataGrid _dgOrders;

        internal DataGrid dgOrders
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgOrders;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgOrders != null)
                {
                    _dgOrders.DoubleClick -= dgOrders_DoubleClick;
                }

                _dgOrders = value;
                if (_dgOrders != null)
                {
                    _dgOrders.DoubleClick += dgOrders_DoubleClick;
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
                    _dgItems.MouseUp -= dgItems_MouseUp;
                    _dgItems.DoubleClick -= dgItems_DoubleClick;
                }

                _dgItems = value;
                if (_dgItems != null)
                {
                    _dgItems.MouseUp += dgItems_MouseUp;
                    _dgItems.DoubleClick += dgItems_DoubleClick;
                }
            }
        }

        private Button _btnPrint;

        internal Button btnPrint
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrint;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrint != null)
                {
                    _btnPrint.Click -= btnPrint_Click;
                }

                _btnPrint = value;
                if (_btnPrint != null)
                {
                    _btnPrint.Click += btnPrint_Click;
                }
            }
        }

        private Button _btnReceiveAll;

        internal Button btnReceiveAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnReceiveAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnReceiveAll != null)
                {
                    _btnReceiveAll.Click -= btnReceiveAll_Click;
                }

                _btnReceiveAll = value;
                if (_btnReceiveAll != null)
                {
                    _btnReceiveAll.Click += btnReceiveAll_Click;
                }
            }
        }

        private CheckBox _chkPOSupplied;

        internal CheckBox chkPOSupplied
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkPOSupplied;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkPOSupplied != null)
                {
                }

                _chkPOSupplied = value;
                if (_chkPOSupplied != null)
                {
                }
            }
        }

        private Label _Label17;

        internal Label Label17
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label17;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label17 != null)
                {
                }

                _Label17 = value;
                if (_Label17 != null)
                {
                }
            }
        }

        private CheckBox _cbxReadyToSendToSage;

        internal CheckBox cbxReadyToSendToSage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbxReadyToSendToSage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbxReadyToSendToSage != null)
                {
                }

                _cbxReadyToSendToSage = value;
                if (_cbxReadyToSendToSage != null)
                {
                }
            }
        }

        private TextBox _txtDepartment;

        internal TextBox txtDepartment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDepartment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDepartment != null)
                {
                }

                _txtDepartment = value;
                if (_txtDepartment != null)
                {
                }
            }
        }

        private TextBox _txtNominalCode;

        internal TextBox txtNominalCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNominalCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNominalCode != null)
                {
                }

                _txtNominalCode = value;
                if (_txtNominalCode != null)
                {
                }
            }
        }

        private Label _Label16;

        internal Label Label16
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label16;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label16 != null)
                {
                }

                _Label16 = value;
                if (_Label16 != null)
                {
                }
            }
        }

        private TextBox _txtVAT;

        internal TextBox txtVAT
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtVAT;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtVAT != null)
                {
                    _txtVAT.GotFocus -= txtVAT_GotFocus;
                    _txtVAT.Validating -= txtVAT_Validating;
                }

                _txtVAT = value;
                if (_txtVAT != null)
                {
                    _txtVAT.GotFocus += txtVAT_GotFocus;
                    _txtVAT.Validating += txtVAT_Validating;
                }
            }
        }

        private TextBox _txtExtraReference;

        internal TextBox txtExtraReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtExtraReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtExtraReference != null)
                {
                }

                _txtExtraReference = value;
                if (_txtExtraReference != null)
                {
                }
            }
        }

        private Label _Label14;

        internal Label Label14
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label14;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label14 != null)
                {
                }

                _Label14 = value;
                if (_Label14 != null)
                {
                }
            }
        }

        private ComboBox _cboTaxCode;

        internal ComboBox cboTaxCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTaxCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboTaxCode != null)
                {
                    _cboTaxCode.SelectedIndexChanged -= cboTaxCode_SelectedIndexChanged;
                }

                _cboTaxCode = value;
                if (_cboTaxCode != null)
                {
                    _cboTaxCode.SelectedIndexChanged += cboTaxCode_SelectedIndexChanged;
                }
            }
        }

        private Label _Label15;

        internal Label Label15
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label15;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label15 != null)
                {
                }

                _Label15 = value;
                if (_Label15 != null)
                {
                }
            }
        }

        private Label _Label13;

        internal Label Label13
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label13;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label13 != null)
                {
                }

                _Label13 = value;
                if (_Label13 != null)
                {
                }
            }
        }

        private TextBox _txtSupplierInvoiceAmount;

        internal TextBox txtSupplierInvoiceAmount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSupplierInvoiceAmount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSupplierInvoiceAmount != null)
                {
                    _txtSupplierInvoiceAmount.GotFocus -= txtSupplierInvoiceAmount_GotFocus;
                    _txtSupplierInvoiceAmount.Validating -= txtSupplierInvoiceAmount_Validating;
                }

                _txtSupplierInvoiceAmount = value;
                if (_txtSupplierInvoiceAmount != null)
                {
                    _txtSupplierInvoiceAmount.GotFocus += txtSupplierInvoiceAmount_GotFocus;
                    _txtSupplierInvoiceAmount.Validating += txtSupplierInvoiceAmount_Validating;
                }
            }
        }

        private Label _Label10;

        internal Label Label10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label10 != null)
                {
                }

                _Label10 = value;
                if (_Label10 != null)
                {
                }
            }
        }

        private Label _Label9;

        internal Label Label9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label9 != null)
                {
                }

                _Label9 = value;
                if (_Label9 != null)
                {
                }
            }
        }

        private CheckBox _chkSupInvDateNA;

        internal CheckBox chkSupInvDateNA
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkSupInvDateNA;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkSupInvDateNA != null)
                {
                    _chkSupInvDateNA.CheckedChanged -= chkSupInvDateNA_CheckedChanged;
                }

                _chkSupInvDateNA = value;
                if (_chkSupInvDateNA != null)
                {
                    _chkSupInvDateNA.CheckedChanged += chkSupInvDateNA_CheckedChanged;
                }
            }
        }

        private TextBox _txtSupplierInvoiceReference;

        internal TextBox txtSupplierInvoiceReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSupplierInvoiceReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSupplierInvoiceReference != null)
                {
                }

                _txtSupplierInvoiceReference = value;
                if (_txtSupplierInvoiceReference != null)
                {
                }
            }
        }

        private DateTimePicker _dtpSupplierInvoiceDate;

        internal DateTimePicker dtpSupplierInvoiceDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpSupplierInvoiceDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpSupplierInvoiceDate != null)
                {
                }

                _dtpSupplierInvoiceDate = value;
                if (_dtpSupplierInvoiceDate != null)
                {
                }
            }
        }

        private Label _Label11;

        internal Label Label11
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label11;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label11 != null)
                {
                }

                _Label11 = value;
                if (_Label11 != null)
                {
                }
            }
        }

        private Label _lblOrderTotal;

        internal Label lblOrderTotal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblOrderTotal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblOrderTotal != null)
                {
                }

                _lblOrderTotal = value;
                if (_lblOrderTotal != null)
                {
                }
            }
        }

        private Label _lblStatus;

        internal Label lblStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblStatus != null)
                {
                }

                _lblStatus = value;
                if (_lblStatus != null)
                {
                }
            }
        }

        private Button _btnPrintDistribution;

        internal Button btnPrintDistribution
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrintDistribution;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrintDistribution != null)
                {
                    _btnPrintDistribution.Click -= btnPrintDistribution_Click;
                }

                _btnPrintDistribution = value;
                if (_btnPrintDistribution != null)
                {
                    _btnPrintDistribution.Click += btnPrintDistribution_Click;
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _Label1 = new Label();
            _Label2 = new Label();
            _Label3 = new Label();
            _Label4 = new Label();
            _grpMain = new GroupBox();
            _lblStatus = new Label();
            _chkPOSupplied = new CheckBox();
            _Label17 = new Label();
            _cbxReadyToSendToSage = new CheckBox();
            _txtDepartment = new TextBox();
            _cboStatus = new ComboBox();
            _cboStatus.SelectedIndexChanged += new EventHandler(cboStatus_SelectedIndexChanged);
            _txtNominalCode = new TextBox();
            _btnSupplier = new Button();
            _btnSupplier.Click += new EventHandler(btnSupplier_Click);
            _Label16 = new Label();
            _txtComments = new TextBox();
            _txtSupplier = new TextBox();
            _txtVAT = new TextBox();
            _txtVAT.GotFocus += new EventHandler(txtVAT_GotFocus);
            _txtVAT.Validating += new System.ComponentModel.CancelEventHandler(txtVAT_Validating);
            _txtExtraReference = new TextBox();
            _Label14 = new Label();
            _txtReference = new TextBox();
            _cboTaxCode = new ComboBox();
            _cboTaxCode.SelectedIndexChanged += new EventHandler(cboTaxCode_SelectedIndexChanged);
            _Label15 = new Label();
            _Label13 = new Label();
            _txtSupplierInvoiceAmount = new TextBox();
            _txtSupplierInvoiceAmount.GotFocus += new EventHandler(txtSupplierInvoiceAmount_GotFocus);
            _txtSupplierInvoiceAmount.Validating += new System.ComponentModel.CancelEventHandler(txtSupplierInvoiceAmount_Validating);
            _Label10 = new Label();
            _Label9 = new Label();
            _chkSupInvDateNA = new CheckBox();
            _chkSupInvDateNA.CheckedChanged += new EventHandler(chkSupInvDateNA_CheckedChanged);
            _txtSupplierInvoiceReference = new TextBox();
            _dtpSupplierInvoiceDate = new DateTimePicker();
            _Label11 = new Label();
            _grpOrders = new GroupBox();
            _dgOrders = new DataGrid();
            _dgOrders.DoubleClick += new EventHandler(dgOrders_DoubleClick);
            _grpItems = new GroupBox();
            _lblOrderTotal = new Label();
            _dgItems = new DataGrid();
            _dgItems.MouseUp += new MouseEventHandler(dgItems_MouseUp);
            _dgItems.DoubleClick += new EventHandler(dgItems_DoubleClick);
            _btnPrint = new Button();
            _btnPrint.Click += new EventHandler(btnPrint_Click);
            _btnReceiveAll = new Button();
            _btnReceiveAll.Click += new EventHandler(btnReceiveAll_Click);
            _btnPrintDistribution = new Button();
            _btnPrintDistribution.Click += new EventHandler(btnPrintDistribution_Click);
            _grpMain.SuspendLayout();
            _grpOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgOrders).BeginInit();
            _grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgItems).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSave.Location = new Point(833, 681);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(60, 25);
            _btnSave.TabIndex = 4;
            _btnSave.Text = "Save";
            // 
            // btnClose
            // 
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClose.Location = new Point(12, 681);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(56, 25);
            _btnClose.TabIndex = 7;
            _btnClose.Text = "Close";
            // 
            // Label1
            // 
            _Label1.AutoSize = true;
            _Label1.Location = new Point(6, 26);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(65, 13);
            _Label1.TabIndex = 4;
            _Label1.Text = "Reference";
            // 
            // Label2
            // 
            _Label2.AutoSize = true;
            _Label2.Location = new Point(6, 83);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(69, 13);
            _Label2.TabIndex = 5;
            _Label2.Text = "Comments";
            // 
            // Label3
            // 
            _Label3.AutoSize = true;
            _Label3.Location = new Point(6, 52);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(54, 13);
            _Label3.TabIndex = 6;
            _Label3.Text = "Supplier";
            // 
            // Label4
            // 
            _Label4.AutoSize = true;
            _Label4.Location = new Point(185, 26);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(43, 13);
            _Label4.TabIndex = 7;
            _Label4.Text = "Status";
            // 
            // grpMain
            // 
            _grpMain.Controls.Add(_lblStatus);
            _grpMain.Controls.Add(_chkPOSupplied);
            _grpMain.Controls.Add(_Label17);
            _grpMain.Controls.Add(_cbxReadyToSendToSage);
            _grpMain.Controls.Add(_txtDepartment);
            _grpMain.Controls.Add(_cboStatus);
            _grpMain.Controls.Add(_txtNominalCode);
            _grpMain.Controls.Add(_btnSupplier);
            _grpMain.Controls.Add(_Label16);
            _grpMain.Controls.Add(_txtComments);
            _grpMain.Controls.Add(_txtSupplier);
            _grpMain.Controls.Add(_txtVAT);
            _grpMain.Controls.Add(_txtExtraReference);
            _grpMain.Controls.Add(_Label14);
            _grpMain.Controls.Add(_txtReference);
            _grpMain.Controls.Add(_cboTaxCode);
            _grpMain.Controls.Add(_Label15);
            _grpMain.Controls.Add(_Label13);
            _grpMain.Controls.Add(_Label1);
            _grpMain.Controls.Add(_Label4);
            _grpMain.Controls.Add(_Label2);
            _grpMain.Controls.Add(_txtSupplierInvoiceAmount);
            _grpMain.Controls.Add(_Label3);
            _grpMain.Controls.Add(_Label10);
            _grpMain.Controls.Add(_Label9);
            _grpMain.Controls.Add(_chkSupInvDateNA);
            _grpMain.Controls.Add(_txtSupplierInvoiceReference);
            _grpMain.Controls.Add(_dtpSupplierInvoiceDate);
            _grpMain.Controls.Add(_Label11);
            _grpMain.Location = new Point(12, 38);
            _grpMain.Name = "grpMain";
            _grpMain.Size = new Size(400, 337);
            _grpMain.TabIndex = 1;
            _grpMain.TabStop = false;
            _grpMain.Text = "Main Details";
            // 
            // lblStatus
            // 
            _lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _lblStatus.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(255)), Conversions.ToInteger(Conversions.ToByte(192)));
            _lblStatus.Font = new Font("Verdana", 9.0F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblStatus.Location = new Point(10, 281);
            _lblStatus.Name = "lblStatus";
            _lblStatus.Size = new Size(233, 50);
            _lblStatus.TabIndex = 89;
            _lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // chkPOSupplied
            // 
            _chkPOSupplied.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _chkPOSupplied.Location = new Point(9, 135);
            _chkPOSupplied.Name = "chkPOSupplied";
            _chkPOSupplied.Size = new Size(251, 24);
            _chkPOSupplied.TabIndex = 88;
            _chkPOSupplied.Text = "Supplier purchase invoice provided";
            // 
            // Label17
            // 
            _Label17.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _Label17.Location = new Point(243, 282);
            _Label17.Name = "Label17";
            _Label17.Size = new Size(38, 20);
            _Label17.TabIndex = 87;
            _Label17.Text = "Dept";
            // 
            // cbxReadyToSendToSage
            // 
            _cbxReadyToSendToSage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _cbxReadyToSendToSage.Location = new Point(232, 308);
            _cbxReadyToSendToSage.Name = "cbxReadyToSendToSage";
            _cbxReadyToSendToSage.RightToLeft = RightToLeft.Yes;
            _cbxReadyToSendToSage.Size = new Size(163, 24);
            _cbxReadyToSendToSage.TabIndex = 78;
            _cbxReadyToSendToSage.Text = "Ready to send to sage";
            // 
            // txtDepartment
            // 
            _txtDepartment.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _txtDepartment.Location = new Point(302, 281);
            _txtDepartment.MaxLength = 100;
            _txtDepartment.Name = "txtDepartment";
            _txtDepartment.Size = new Size(93, 21);
            _txtDepartment.TabIndex = 77;
            _txtDepartment.Tag = "Order.SupplierInvoiceReference";
            // 
            // cboStatus
            // 
            _cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboStatus.FormattingEnabled = true;
            _cboStatus.Location = new Point(234, 23);
            _cboStatus.Name = "cboStatus";
            _cboStatus.Size = new Size(160, 21);
            _cboStatus.TabIndex = 2;
            // 
            // txtNominalCode
            // 
            _txtNominalCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtNominalCode.Location = new Point(302, 252);
            _txtNominalCode.MaxLength = 100;
            _txtNominalCode.Name = "txtNominalCode";
            _txtNominalCode.Size = new Size(93, 21);
            _txtNominalCode.TabIndex = 76;
            _txtNominalCode.Tag = "Order.SupplierInvoiceReference";
            // 
            // btnSupplier
            // 
            _btnSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnSupplier.Location = new Point(359, 52);
            _btnSupplier.Name = "btnSupplier";
            _btnSupplier.Size = new Size(35, 23);
            _btnSupplier.TabIndex = 4;
            _btnSupplier.Text = "...";
            _btnSupplier.UseVisualStyleBackColor = true;
            // 
            // Label16
            // 
            _Label16.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label16.Location = new Point(243, 252);
            _Label16.Name = "Label16";
            _Label16.Size = new Size(70, 20);
            _Label16.TabIndex = 86;
            _Label16.Text = "Nominal";
            // 
            // txtComments
            // 
            _txtComments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtComments.Location = new Point(89, 83);
            _txtComments.Multiline = true;
            _txtComments.Name = "txtComments";
            _txtComments.ScrollBars = ScrollBars.Both;
            _txtComments.Size = new Size(305, 46);
            _txtComments.TabIndex = 5;
            // 
            // txtSupplier
            // 
            _txtSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSupplier.Location = new Point(89, 52);
            _txtSupplier.Name = "txtSupplier";
            _txtSupplier.ReadOnly = true;
            _txtSupplier.Size = new Size(264, 21);
            _txtSupplier.TabIndex = 3;
            // 
            // txtVAT
            // 
            _txtVAT.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtVAT.Location = new Point(138, 251);
            _txtVAT.MaxLength = 100;
            _txtVAT.Name = "txtVAT";
            _txtVAT.Size = new Size(105, 21);
            _txtVAT.TabIndex = 75;
            _txtVAT.Tag = "Order.SupplierInvoiceAmount";
            // 
            // txtExtraReference
            // 
            _txtExtraReference.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtExtraReference.Location = new Point(302, 163);
            _txtExtraReference.MaxLength = 100;
            _txtExtraReference.Name = "txtExtraReference";
            _txtExtraReference.Size = new Size(93, 21);
            _txtExtraReference.TabIndex = 70;
            _txtExtraReference.Tag = "Order.SupplierInvoiceReference";
            // 
            // Label14
            // 
            _Label14.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label14.Location = new Point(7, 252);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(125, 20);
            _Label14.TabIndex = 84;
            _Label14.Text = "Invoice VAT Amount";
            // 
            // txtReference
            // 
            _txtReference.Location = new Point(89, 23);
            _txtReference.Name = "txtReference";
            _txtReference.Size = new Size(90, 21);
            _txtReference.TabIndex = 1;
            // 
            // cboTaxCode
            // 
            _cboTaxCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _cboTaxCode.Location = new Point(302, 223);
            _cboTaxCode.Name = "cboTaxCode";
            _cboTaxCode.Size = new Size(93, 21);
            _cboTaxCode.TabIndex = 74;
            // 
            // Label15
            // 
            _Label15.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label15.Location = new Point(249, 166);
            _Label15.Name = "Label15";
            _Label15.Size = new Size(56, 20);
            _Label15.TabIndex = 85;
            _Label15.Text = "Ex Ref.";
            // 
            // Label13
            // 
            _Label13.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label13.Location = new Point(243, 225);
            _Label13.Name = "Label13";
            _Label13.Size = new Size(70, 20);
            _Label13.TabIndex = 83;
            _Label13.Text = "Tax Code";
            // 
            // txtSupplierInvoiceAmount
            // 
            _txtSupplierInvoiceAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtSupplierInvoiceAmount.Location = new Point(138, 223);
            _txtSupplierInvoiceAmount.MaxLength = 100;
            _txtSupplierInvoiceAmount.Name = "txtSupplierInvoiceAmount";
            _txtSupplierInvoiceAmount.Size = new Size(105, 21);
            _txtSupplierInvoiceAmount.TabIndex = 73;
            _txtSupplierInvoiceAmount.Tag = "Order.SupplierInvoiceAmount";
            // 
            // Label10
            // 
            _Label10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label10.Location = new Point(7, 222);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(106, 20);
            _Label10.TabIndex = 80;
            _Label10.Text = "Invoice Amount";
            // 
            // Label9
            // 
            _Label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label9.Location = new Point(7, 165);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(94, 20);
            _Label9.TabIndex = 79;
            _Label9.Text = "Invoice Ref.";
            // 
            // chkSupInvDateNA
            // 
            _chkSupInvDateNA.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _chkSupInvDateNA.Location = new Point(138, 193);
            _chkSupInvDateNA.Name = "chkSupInvDateNA";
            _chkSupInvDateNA.Size = new Size(48, 24);
            _chkSupInvDateNA.TabIndex = 71;
            _chkSupInvDateNA.Text = "N/A";
            // 
            // txtSupplierInvoiceReference
            // 
            _txtSupplierInvoiceReference.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtSupplierInvoiceReference.Location = new Point(138, 162);
            _txtSupplierInvoiceReference.MaxLength = 100;
            _txtSupplierInvoiceReference.Name = "txtSupplierInvoiceReference";
            _txtSupplierInvoiceReference.Size = new Size(105, 21);
            _txtSupplierInvoiceReference.TabIndex = 69;
            _txtSupplierInvoiceReference.Tag = "Order.SupplierInvoiceReference";
            // 
            // dtpSupplierInvoiceDate
            // 
            _dtpSupplierInvoiceDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _dtpSupplierInvoiceDate.Location = new Point(189, 196);
            _dtpSupplierInvoiceDate.Name = "dtpSupplierInvoiceDate";
            _dtpSupplierInvoiceDate.Size = new Size(206, 21);
            _dtpSupplierInvoiceDate.TabIndex = 72;
            _dtpSupplierInvoiceDate.Tag = "Order.SupplierInvoiceDate";
            // 
            // Label11
            // 
            _Label11.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label11.Location = new Point(7, 195);
            _Label11.Name = "Label11";
            _Label11.Size = new Size(94, 20);
            _Label11.TabIndex = 81;
            _Label11.Text = "Invoice Date";
            // 
            // grpOrders
            // 
            _grpOrders.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpOrders.Controls.Add(_dgOrders);
            _grpOrders.Location = new Point(418, 38);
            _grpOrders.Name = "grpOrders";
            _grpOrders.Size = new Size(475, 337);
            _grpOrders.TabIndex = 2;
            _grpOrders.TabStop = false;
            _grpOrders.Text = "Related Orders (Double click to view)";
            // 
            // dgOrders
            // 
            _dgOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgOrders.DataMember = "";
            _dgOrders.HeaderForeColor = SystemColors.ControlText;
            _dgOrders.Location = new Point(6, 23);
            _dgOrders.Name = "dgOrders";
            _dgOrders.Size = new Size(463, 308);
            _dgOrders.TabIndex = 1;
            // 
            // grpItems
            // 
            _grpItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpItems.Controls.Add(_lblOrderTotal);
            _grpItems.Controls.Add(_dgItems);
            _grpItems.Location = new Point(12, 381);
            _grpItems.Name = "grpItems";
            _grpItems.Size = new Size(881, 294);
            _grpItems.TabIndex = 3;
            _grpItems.TabStop = false;
            _grpItems.Text = "Related Items";
            // 
            // lblOrderTotal
            // 
            _lblOrderTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblOrderTotal.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblOrderTotal.Location = new Point(580, 17);
            _lblOrderTotal.Name = "lblOrderTotal";
            _lblOrderTotal.Size = new Size(295, 15);
            _lblOrderTotal.TabIndex = 82;
            _lblOrderTotal.Text = "Order Total : £0.00";
            _lblOrderTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgItems
            // 
            _dgItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgItems.DataMember = "";
            _dgItems.HeaderForeColor = SystemColors.ControlText;
            _dgItems.Location = new Point(9, 35);
            _dgItems.Name = "dgItems";
            _dgItems.Size = new Size(866, 253);
            _dgItems.TabIndex = 1;
            // 
            // btnPrint
            // 
            _btnPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnPrint.Location = new Point(434, 681);
            _btnPrint.Name = "btnPrint";
            _btnPrint.Size = new Size(249, 25);
            _btnPrint.TabIndex = 6;
            _btnPrint.Text = "Print combined supplier purchase order";
            // 
            // btnReceiveAll
            // 
            _btnReceiveAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnReceiveAll.Location = new Point(689, 681);
            _btnReceiveAll.Name = "btnReceiveAll";
            _btnReceiveAll.Size = new Size(138, 25);
            _btnReceiveAll.TabIndex = 5;
            _btnReceiveAll.Text = "Save && Receive All";
            // 
            // btnPrintDistribution
            // 
            _btnPrintDistribution.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnPrintDistribution.Location = new Point(258, 681);
            _btnPrintDistribution.Name = "btnPrintDistribution";
            _btnPrintDistribution.Size = new Size(170, 25);
            _btnPrintDistribution.TabIndex = 8;
            _btnPrintDistribution.Text = "Print order distribution list";
            // 
            // FRMConsolidation
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(905, 718);
            ControlBox = false;
            Controls.Add(_btnPrintDistribution);
            Controls.Add(_btnReceiveAll);
            Controls.Add(_btnPrint);
            Controls.Add(_grpItems);
            Controls.Add(_grpOrders);
            Controls.Add(_grpMain);
            Controls.Add(_btnClose);
            Controls.Add(_btnSave);
            MinimumSize = new Size(913, 752);
            Name = "FRMConsolidation";
            Text = "Consolidation : ID {0}";
            Controls.SetChildIndex(_btnSave, 0);
            Controls.SetChildIndex(_btnClose, 0);
            Controls.SetChildIndex(_grpMain, 0);
            Controls.SetChildIndex(_grpOrders, 0);
            Controls.SetChildIndex(_grpItems, 0);
            Controls.SetChildIndex(_btnPrint, 0);
            Controls.SetChildIndex(_btnReceiveAll, 0);
            Controls.SetChildIndex(_btnPrintDistribution, 0);
            _grpMain.ResumeLayout(false);
            _grpMain.PerformLayout();
            _grpOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgOrders).EndInit();
            _grpItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgItems).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            OrderConsolidation = App.DB.OrderConsolidations.OrderConsolidation_Get(Conversions.ToInteger(get_GetParameter(0)));
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void SetupDG()
        {
            var tbStyle = dgOrders.TableStyles[0];
            tbStyle.GridColumnStyles.Clear();
            tbStyle.ReadOnly = false;
            dgOrders.ReadOnly = false;
            tbStyle.AllowSorting = false;
            if (OrderConsolidation.ConsolidatedOrderStatusID <= (int)Entity.Sys.Enums.OrderStatus.AwaitingConfirmation)
            {
                // Dim Tick As New DataGridBoolColumn
                // Tick.HeaderText = ""
                // Tick.MappingName = "Tick"
                // Tick.ReadOnly = False
                // Tick.Width = 25
                // Tick.NullText = ""
                // tbStyle.GridColumnStyles.Add(Tick)
            }

            var OrderReference = new DataGridLabelColumn();
            OrderReference.Format = "";
            OrderReference.FormatInfo = null;
            OrderReference.HeaderText = "Order Reference";
            OrderReference.MappingName = "OrderReference";
            OrderReference.ReadOnly = true;
            OrderReference.Width = 100;
            OrderReference.NullText = "";
            tbStyle.GridColumnStyles.Add(OrderReference);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 75;
            Type.NullText = "";
            tbStyle.GridColumnStyles.Add(Type);
            var OrderFor = new DataGridLabelColumn();
            OrderFor.Format = "";
            OrderFor.FormatInfo = null;
            OrderFor.HeaderText = "Order Is For";
            OrderFor.MappingName = "Destination";
            OrderFor.ReadOnly = true;
            OrderFor.Width = 80;
            OrderFor.NullText = "";
            tbStyle.GridColumnStyles.Add(OrderFor);
            var Status = new DataGridLabelColumn();
            Status.Format = "";
            Status.FormatInfo = null;
            Status.HeaderText = "Status";
            Status.MappingName = "OrderStatus";
            Status.ReadOnly = true;
            Status.Width = 100;
            Status.NullText = "";
            tbStyle.GridColumnStyles.Add(Status);
            var DatePlaced = new DataGridLabelColumn();
            DatePlaced.Format = "";
            DatePlaced.FormatInfo = null;
            DatePlaced.HeaderText = "Date Placed";
            DatePlaced.MappingName = "DatePlaced";
            DatePlaced.ReadOnly = true;
            DatePlaced.Width = 100;
            DatePlaced.NullText = "";
            tbStyle.GridColumnStyles.Add(DatePlaced);
            var CreatedBy = new DataGridLabelColumn();
            CreatedBy.Format = "";
            CreatedBy.FormatInfo = null;
            CreatedBy.HeaderText = "Created By";
            CreatedBy.MappingName = "CreatedBy";
            CreatedBy.ReadOnly = true;
            CreatedBy.Width = 100;
            CreatedBy.NullText = "";
            tbStyle.GridColumnStyles.Add(CreatedBy);
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblOrder.ToString();
            dgOrders.TableStyles.Add(tbStyle);
        }

        private void SetupItemsDG()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgItems);
            var tbStyle = dgItems.TableStyles[0];
            tbStyle.GridColumnStyles.Clear();
            tbStyle.ReadOnly = false;
            dgItems.ReadOnly = false;
            tbStyle.AllowSorting = false;
            var Number = new DataGridLabelColumn();
            Number.Format = "";
            Number.FormatInfo = null;
            Number.HeaderText = "Number";
            Number.MappingName = "Number";
            Number.ReadOnly = true;
            Number.Width = 100;
            Number.NullText = "";
            tbStyle.GridColumnStyles.Add(Number);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Name";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 200;
            Name.NullText = "";
            tbStyle.GridColumnStyles.Add(Name);
            var BuyPrice = new DataGridLabelColumn();
            BuyPrice.Format = "C";
            BuyPrice.FormatInfo = null;
            BuyPrice.HeaderText = "Buy Price";
            BuyPrice.MappingName = "BuyPrice";
            BuyPrice.ReadOnly = true;
            BuyPrice.Width = 80;
            BuyPrice.NullText = "";
            tbStyle.GridColumnStyles.Add(BuyPrice);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 75;
            Type.NullText = "";
            tbStyle.GridColumnStyles.Add(Type);
            var Destination = new DataGridLabelColumn();
            Destination.Format = "";
            Destination.FormatInfo = null;
            Destination.HeaderText = "Destination";
            Destination.MappingName = "Destination";
            Destination.ReadOnly = true;
            Destination.Width = 100;
            Destination.NullText = "";
            tbStyle.GridColumnStyles.Add(Destination);
            var OrderReference = new DataGridLabelColumn();
            OrderReference.Format = "";
            OrderReference.FormatInfo = null;
            OrderReference.HeaderText = "Order";
            OrderReference.MappingName = "OrderReference";
            OrderReference.ReadOnly = true;
            OrderReference.Width = 75;
            OrderReference.NullText = "";
            tbStyle.GridColumnStyles.Add(OrderReference);
            var ItemsOnOrder = new DataGridLabelColumn();
            ItemsOnOrder.Format = "";
            ItemsOnOrder.FormatInfo = null;
            ItemsOnOrder.HeaderText = "No. Ordered";
            ItemsOnOrder.MappingName = "QuantityOnOrder";
            ItemsOnOrder.ReadOnly = true;
            ItemsOnOrder.Width = 75;
            ItemsOnOrder.NullText = "";
            tbStyle.GridColumnStyles.Add(ItemsOnOrder);
            if (OrderConsolidation.ConsolidatedOrderStatusID == (int)Entity.Sys.Enums.OrderStatus.Confirmed)
            {
                var ItemsReceived = new DataGridLabelColumn();
                ItemsReceived.Format = "";
                ItemsReceived.FormatInfo = null;
                ItemsReceived.HeaderText = "No. Received";
                ItemsReceived.MappingName = "QuantityReceived";
                ItemsReceived.ReadOnly = true;
                ItemsReceived.Width = 75;
                ItemsReceived.NullText = "";
                tbStyle.GridColumnStyles.Add(ItemsReceived);
                var EnterReceived = new DataGridTextBoxColumn();
                EnterReceived.Format = "";
                EnterReceived.FormatInfo = null;
                EnterReceived.HeaderText = "Enter Received ";
                EnterReceived.MappingName = "EnterReceived";
                EnterReceived.ReadOnly = false;
                EnterReceived.Width = 75;
                EnterReceived.NullText = "";
                EnterReceived.TextBox.BackColor = Color.LightYellow;
                tbStyle.GridColumnStyles.Add(EnterReceived);
            }

            if (OrderConsolidation.ConsolidatedOrderStatusID == (int)Entity.Sys.Enums.OrderStatus.Complete)
            {
                var ItemsReceived = new DataGridLabelColumn();
                ItemsReceived.Format = "";
                ItemsReceived.FormatInfo = null;
                ItemsReceived.HeaderText = "No. Received";
                ItemsReceived.MappingName = "QuantityReceived";
                ItemsReceived.ReadOnly = true;
                ItemsReceived.Width = 75;
                ItemsReceived.NullText = "";
                tbStyle.GridColumnStyles.Add(ItemsReceived);
            }

            tbStyle.MappingName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
            dgItems.TableStyles.Add(tbStyle);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private bool IsLoading = true;
        private Entity.OrderConsolidations.OrderConsolidation _OrderConsolidation;

        public Entity.OrderConsolidations.OrderConsolidation OrderConsolidation
        {
            get
            {
                return _OrderConsolidation;
            }

            set
            {
                _OrderConsolidation = value;
                if (OrderConsolidation is null)
                {
                    _OrderConsolidation = new Entity.OrderConsolidations.OrderConsolidation();
                    _OrderConsolidation.Exists = false;
                }

                if (!OrderConsolidation.Exists)
                {
                    Text = "Consolidation : Adding New...";
                    OrderNumber = App.DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.CONSOLIDATION);
                    var argcombo = cboStatus;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation));
                    cboStatus.Enabled = false;
                    btnPrint.Enabled = false;
                    btnPrintDistribution.Enabled = false;
                    btnReceiveAll.Enabled = false;
                    chkPOSupplied.Enabled = false;
                    txtSupplierInvoiceReference.ReadOnly = true;
                    chkSupInvDateNA.Enabled = false;
                    dtpSupplierInvoiceDate.Enabled = false;
                    txtSupplierInvoiceAmount.ReadOnly = true;
                    txtVAT.ReadOnly = true;
                    cboTaxCode.Enabled = false;
                    txtExtraReference.ReadOnly = true;
                    txtNominalCode.ReadOnly = true;
                    txtDepartment.ReadOnly = true;
                    cbxReadyToSendToSage.Enabled = false;
                }
                else
                {
                    btnPrint.Enabled = true;
                    btnPrintDistribution.Enabled = true;
                    Text = "Consolidation : ID " + OrderConsolidation.OrderConsolidationID;
                    Populate();
                    OrderNumberUsed = true;
                }

                SetupDG();
                SetupItemsDG();
                IsLoading = false;
            }
        }

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
                OrderNumberUsed = false;
                OrderNumber.OrderNumber = OrderNumber.Number.ToString();
                while (OrderNumber.OrderNumber.Length < 6)
                    OrderNumber.OrderNumber = "0" + OrderNumber.OrderNumber;
                txtReference.Text = OrderNumber.Prefix + OrderNumber.OrderNumber;
            }
        }

        private bool _OrderNumberUsed = false;

        public bool OrderNumberUsed
        {
            get
            {
                return _OrderNumberUsed;
            }

            set
            {
                _OrderNumberUsed = value;
            }
        }

        private Entity.Suppliers.Supplier _Supplier;

        public Entity.Suppliers.Supplier Supplier
        {
            get
            {
                return _Supplier;
            }

            set
            {
                _Supplier = value;
                if (Supplier is null)
                {
                    txtSupplier.Text = "";
                }
                else
                {
                    txtSupplier.Text = Supplier.Name + " (" + Supplier.AccountNumber + ")";
                    ItemsDataView = App.DB.OrderConsolidations.Order_GetItemForConsolidationID(OrderConsolidation.OrderConsolidationID, false);
                    if (OrderConsolidation.Exists)
                    {
                        if (OrderConsolidation.ConsolidatedOrderStatusID == Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation))
                        {
                            OrderDataView = App.DB.OrderConsolidations.Order_GetForConsolidationByID(OrderConsolidation.OrderConsolidationID, _Supplier.SupplierID, 0);
                        }
                        else
                        {
                            OrderDataView = App.DB.OrderConsolidations.Order_GetForConsolidationByID_Confirmed(OrderConsolidation.OrderConsolidationID, false);
                        }
                    }
                    else
                    {
                        OrderDataView = App.DB.OrderConsolidations.Order_GetForConsolidation(_Supplier.SupplierID, 0);
                    }
                }
            }
        }

        private DataView _OrderDataView = null;

        public DataView OrderDataView
        {
            get
            {
                return _OrderDataView;
            }

            set
            {
                _OrderDataView = value;
                _OrderDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString();
                _OrderDataView.AllowNew = false;
                _OrderDataView.AllowEdit = true;
                _OrderDataView.AllowDelete = false;
                dgOrders.DataSource = OrderDataView;
            }
        }

        private DataRow SelectedOrderDataRow
        {
            get
            {
                if (!(dgOrders.CurrentRowIndex == -1))
                {
                    return OrderDataView[dgOrders.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _itemsDataView = null;

        public DataView ItemsDataView
        {
            get
            {
                return _itemsDataView;
            }

            set
            {
                _itemsDataView = value;
                _itemsDataView.Table.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
                _itemsDataView.AllowNew = false;
                _itemsDataView.AllowEdit = true;
                _itemsDataView.AllowDelete = false;
                dgItems.DataSource = ItemsDataView;
                double total = 0.0;
                foreach (DataRow row in ItemsDataView.Table.Rows)
                    total += Conversions.ToDouble(Strings.FormatCurrency(Entity.Sys.Helper.MakeDoubleValid(Strings.FormatCurrency(row["BuyPrice"], 2)) * Entity.Sys.Helper.MakeDoubleValid(Strings.FormatCurrency(row["QuantityOnOrder"], 2)), 2));
                // PLUS ADDITIONAL
                foreach (DataRow row in App.DB.OrderCharge.OrderCharge_GetForConsolidatedOrder(OrderConsolidation.OrderConsolidationID).Table.Rows)
                    total += Conversions.ToDouble(Strings.FormatCurrency(row["Amount"], 2));
                lblOrderTotal.Text = "Order Total : " + Strings.FormatCurrency(total, 2);
            }
        }

        private DataRow SelectedItemDataRow
        {
            get
            {
                if (!(dgItems.CurrentRowIndex == -1))
                {
                    return ItemsDataView[dgItems.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private void FRMConsolidation_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!OrderNumberUsed)
            {
                App.DB.Job.DeleteReservedOrderNumber(OrderNumber.Number, OrderNumber.Prefix);
            }

            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            Supplier = App.DB.Supplier.Supplier_Get(Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblSupplier)));
        }

        private void chkSupInvDateNA_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSupInvDateNA.Checked)
            {
                dtpSupplierInvoiceDate.Enabled = false;
                dtpSupplierInvoiceDate.Value = DateAndTime.Now.Date;
            }
            else
            {
                dtpSupplierInvoiceDate.Enabled = true;
            }
        }

        private void txtSupplierInvoiceAmount_GotFocus(object sender, EventArgs e)
        {
            txtSupplierInvoiceAmount.Text = "";
        }

        private void txtSupplierInvoiceAmount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!(txtSupplierInvoiceAmount.Text.Trim().Length == 0))
            {
                if (Information.IsNumeric(txtSupplierInvoiceAmount.Text.Trim()))
                {
                    OrderConsolidation.SetSupplierInvoiceAmount = Entity.Sys.Helper.MakeDoubleValid(txtSupplierInvoiceAmount.Text.Trim());
                }
            }

            txtSupplierInvoiceAmount.Text = Strings.Format(OrderConsolidation.SupplierInvoiceAmount, "C");
            Calculate_Tax();
        }

        private void txtVAT_GotFocus(object sender, EventArgs e)
        {
            txtVAT.Text = "";
        }

        private void txtVAT_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!(txtVAT.Text.Trim().Length == 0))
            {
                if (Information.IsNumeric(txtVAT.Text.Trim()))
                {
                    OrderConsolidation.SetVATAmount = Entity.Sys.Helper.MakeDoubleValid(txtVAT.Text.Trim());
                }
            }

            txtVAT.Text = Strings.Format(OrderConsolidation.VATAmount, "C");
        }

        private void cboTaxCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate_Tax();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void dgOrders_DoubleClick(object sender, EventArgs e)
        {
            var switchExpr = Conversions.ToInteger(SelectedOrderDataRow["OrderTypeID"]);
            switch (switchExpr)
            {
                case (int)Entity.Sys.Enums.OrderType.Customer:
                    {
                        App.ShowForm(typeof(FRMOrder), true, new object[] { SelectedOrderDataRow["OrderID"], Entity.Sys.Helper.MakeIntegerValid(SelectedOrderDataRow["SiteID"]), 0, this, true });
                        break;
                    }

                case (int)Entity.Sys.Enums.OrderType.StockProfile:
                    {
                        App.ShowForm(typeof(FRMOrder), true, new object[] { SelectedOrderDataRow["OrderID"], SelectedOrderDataRow["VanID"], 0, this, true });
                        break;
                    }

                case (int)Entity.Sys.Enums.OrderType.Warehouse:
                    {
                        App.ShowForm(typeof(FRMOrder), true, new object[] { SelectedOrderDataRow["OrderID"], SelectedOrderDataRow["WarehouseID"], 0, this, true });
                        break;
                    }

                case (int)Entity.Sys.Enums.OrderType.Job:
                    {
                        App.ShowForm(typeof(FRMOrder), true, new object[] { SelectedOrderDataRow["OrderID"], SelectedOrderDataRow["EngineerVisitID"], 0, this, true });
                        break;
                    }
            }

            if (OrderConsolidation.Exists)
            {
                if (OrderConsolidation.ConsolidatedOrderStatusID == Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation))
                {
                    OrderDataView = App.DB.OrderConsolidations.Order_GetForConsolidationByID(OrderConsolidation.OrderConsolidationID, _Supplier.SupplierID, 0);
                }
                else
                {
                    OrderDataView = App.DB.OrderConsolidations.Order_GetForConsolidationByID_Confirmed(OrderConsolidation.OrderConsolidationID, false);
                }
            }
            else
            {
                OrderDataView = App.DB.OrderConsolidations.Order_GetForConsolidation(_Supplier.SupplierID, 0);
            }
        }

        private bool DoubleClicked = false;

        private void dgItems_MouseUp(object sender, MouseEventArgs e)
        {
            if (!DoubleClicked)
            {
                return;
            }

            try
            {
                if (SelectedItemDataRow is null)
                {
                    return;
                }

                var HitTestInfo = dgItems.HitTest(e.X, e.Y);
                if (HitTestInfo.Row == -1)
                {
                    return;
                }

                if (ItemsDataView.Table.Rows[HitTestInfo.Row] is null)
                {
                    return;
                }

                if ((ItemsDataView.Table.Columns[HitTestInfo.Column].ColumnName.Trim().ToLower() ?? "") == ("BuyPrice".ToLower() ?? ""))
                {
                    App.ShowForm(typeof(FRMPart), true, new object[] { SelectedItemDataRow["PartProductID"], true });
                    return;
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void dgItems_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (SelectedItemDataRow is null)
                {
                    DoubleClicked = false;
                    return;
                }

                if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(SelectedItemDataRow["Type"], "OrderPart", false)))
                {
                    DoubleClicked = false;
                    return;
                }

                DoubleClicked = true;
            }
            catch (Exception ex)
            {
                DoubleClicked = false;
            }
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsLoading)
            {
                return;
            }

            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboStatus)) > (double)Entity.Sys.Enums.OrderStatus.AwaitingConfirmation)
            {
                bool dept = true;
                string orderNum = "";
                foreach (DataRow o in OrderDataView.Table.Rows)
                {
                    if (Entity.Sys.Helper.MakeStringValid(o["DepartmentRef"]).Length == 0)
                    {
                        dept = false;
                        orderNum += o["OrderReference"];
                        break;
                    }
                }

                if (dept == false)
                {
                    App.ShowMessage("Order " + orderNum + " is missing a department code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var argcombo = cboStatus;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, OrderConsolidation.ConsolidatedOrderStatusID.ToString());
                    return;
                }
            }

            var switchExpr = Combo.get_GetSelectedItemValue(cboStatus);
            switch (switchExpr)
            {
                case var @case when @case == Conversions.ToString(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation):
                    {
                        if (OrderConsolidation.ConsolidatedOrderStatusID == Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation))
                        {
                            return;
                        }

                        if (OrderConsolidation.ConsolidatedOrderStatusID > Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation))
                        {
                            App.ShowMessage("You cannot go back once the consolidation has progressed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            var argcombo1 = cboStatus;
                            Combo.SetSelectedComboItem_By_Value(ref argcombo1, OrderConsolidation.ConsolidatedOrderStatusID.ToString());
                            return;
                        }

                        break;
                    }

                case var case1 when case1 == Conversions.ToString(Entity.Sys.Enums.OrderStatus.Confirmed):
                    {
                        if (OrderConsolidation.ConsolidatedOrderStatusID == Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Confirmed))
                        {
                            return;
                        }

                        if (OrderConsolidation.ConsolidatedOrderStatusID > Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Confirmed))
                        {
                            App.ShowMessage("You cannot go back once the consolidation has progressed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            var argcombo2 = cboStatus;
                            Combo.SetSelectedComboItem_By_Value(ref argcombo2, OrderConsolidation.ConsolidatedOrderStatusID.ToString());
                            return;
                        }

                        if (App.ShowMessage("Are you sure you want to confirm this consolidation and all related orders? No changes can be made to orders once it has been confirmed.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            var argcombo3 = cboStatus;
                            Combo.SetSelectedComboItem_By_Value(ref argcombo3, OrderConsolidation.ConsolidatedOrderStatusID.ToString());
                            return;
                        }
                        else
                        {
                            OrderConsolidation.SetConsolidatedOrderStatusID = Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Confirmed);
                        }

                        break;
                    }

                case var case2 when case2 == Conversions.ToString(Entity.Sys.Enums.OrderStatus.Cancelled):
                    {
                        if (OrderConsolidation.ConsolidatedOrderStatusID == Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Cancelled))
                        {
                            return;
                        }

                        if (OrderConsolidation.ConsolidatedOrderStatusID > Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Cancelled))
                        {
                            App.ShowMessage("You cannot go back once the consolidation has progressed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            var argcombo4 = cboStatus;
                            Combo.SetSelectedComboItem_By_Value(ref argcombo4, OrderConsolidation.ConsolidatedOrderStatusID.ToString());
                            return;
                        }

                        if (App.ShowMessage("Are you sure you want to cancel this consolidation and all related orders?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            OrderConsolidation.SetConsolidatedOrderStatusID = Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Cancelled);
                        }
                        else
                        {
                            var argcombo5 = cboStatus;
                            Combo.SetSelectedComboItem_By_Value(ref argcombo5, OrderConsolidation.ConsolidatedOrderStatusID.ToString());
                            return;
                        }

                        break;
                    }

                case var case3 when case3 == Conversions.ToString(Entity.Sys.Enums.OrderStatus.Complete):
                    {
                        if (OrderConsolidation.ConsolidatedOrderStatusID == Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Complete))
                        {
                            return;
                        }

                        if (OrderConsolidation.ConsolidatedOrderStatusID < Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Complete))
                        {
                            App.ShowMessage("You cannot complete a consolidation manually.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            var argcombo6 = cboStatus;
                            Combo.SetSelectedComboItem_By_Value(ref argcombo6, OrderConsolidation.ConsolidatedOrderStatusID.ToString());
                            return;
                        }

                        break;
                    }
            }

            App.DB.OrderConsolidations.Update(OrderConsolidation);
            OrderConsolidation = App.DB.OrderConsolidations.OrderConsolidation_Get(OrderConsolidation.OrderConsolidationID);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintSupplierPurchaseOrders(false);
        }

        private void btnPrintDistribution_Click(object sender, EventArgs e)
        {
            PrintSupplierPurchaseOrders(true);
        }

        private void btnReceiveAll_Click(object sender, EventArgs e)
        {
            if (OrderConsolidation.ConsolidatedOrderStatusID == Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation))
            {
                App.ShowMessage("Consolidation must be confirmed to receive stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (OrderConsolidation.ConsolidatedOrderStatusID == Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Cancelled))
            {
                App.ShowMessage("Consolidation has been cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (OrderConsolidation.ConsolidatedOrderStatusID == Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Complete))
            {
                App.ShowMessage("Consolidation is fully received", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (OrderConsolidation.ConsolidatedOrderStatusID == Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Invoiced))
            {
                App.ShowMessage("Consolidation is fully received", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (OrderConsolidation.ConsolidatedOrderStatusID == Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Sent_To_Sage))
            {
                App.ShowMessage("Consolidation is fully received", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (DataRow row in ItemsDataView.Table.Rows)
            {
                row["EnterReceived"] = row["QuantityOnOrder"] - row["QuantityReceived"];
                if (Conversions.ToBoolean(row["EnterReceived"] < 0))
                {
                    row["EnterReceived"] = 0;
                }
            }

            Save();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void Populate()
        {
            txtReference.Text = OrderConsolidation.ConsolidationRef;
            var argcombo = cboStatus;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, OrderConsolidation.ConsolidatedOrderStatusID.ToString());
            Supplier = App.DB.Supplier.Supplier_Get(OrderConsolidation.SupplierID);
            txtComments.Text = OrderConsolidation.Comments;
            chkPOSupplied.Checked = OrderConsolidation.HasSupplierPO;
            txtSupplierInvoiceReference.Text = OrderConsolidation.SupplierInvoiceReference;
            if (OrderConsolidation.SupplierInvoiceDate == default)
            {
                chkSupInvDateNA.Checked = true;
                dtpSupplierInvoiceDate.Value = DateAndTime.Now.Date;
                dtpSupplierInvoiceDate.Enabled = false;
            }
            else
            {
                chkSupInvDateNA.Checked = false;
                dtpSupplierInvoiceDate.Value = OrderConsolidation.SupplierInvoiceDate.Date;
                dtpSupplierInvoiceDate.Enabled = true;
            }

            txtSupplierInvoiceAmount.Text = Strings.Format(OrderConsolidation.SupplierInvoiceAmount, "C");
            var argcombo1 = cboTaxCode;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, OrderConsolidation.TaxCodeID.ToString());
            txtVAT.Text = Strings.Format(OrderConsolidation.VATAmount, "C");
            txtExtraReference.Text = OrderConsolidation.ExtraRef;
            txtNominalCode.Text = OrderConsolidation.NominalCode;
            txtDepartment.Text = OrderConsolidation.DepartmentRef;
            cbxReadyToSendToSage.Checked = OrderConsolidation.ReadyToSendToSage;
            txtReference.ReadOnly = true;
            btnSupplier.Enabled = false;
            if (OrderConsolidation.ConsolidatedOrderStatusID == Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Cancelled) | OrderConsolidation.ConsolidatedOrderStatusID == Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Complete))
            {
                cboStatus.Enabled = false;
                btnReceiveAll.Enabled = false;
                if (OrderConsolidation.ConsolidatedOrderStatusID == Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Cancelled))
                {
                    btnSave.Enabled = false;
                }
                else
                {
                    btnSave.Enabled = true;
                }
            }
            else
            {
                cboStatus.Enabled = true;
                btnSave.Enabled = true;
                btnReceiveAll.Enabled = true;
            }

            if (OrderConsolidation.SentToSage)
            {
                chkPOSupplied.Enabled = false;
                txtSupplierInvoiceReference.ReadOnly = true;
                chkSupInvDateNA.Enabled = false;
                dtpSupplierInvoiceDate.Enabled = false;
                txtSupplierInvoiceAmount.ReadOnly = true;
                txtVAT.ReadOnly = true;
                cboTaxCode.Enabled = false;
                txtExtraReference.ReadOnly = true;
                txtNominalCode.ReadOnly = true;
                txtDepartment.ReadOnly = true;
                cbxReadyToSendToSage.Enabled = false;
                btnSave.Enabled = false;
                lblStatus.Text = "*Supplier PI was Sent to Sage on " + Strings.Format(OrderConsolidation.DateExported, "dd/MMM/yyyy") + "*";
            }
            else if (OrderConsolidation.ReadyToSendToSage)
            {
                chkPOSupplied.Enabled = false;
                txtSupplierInvoiceReference.ReadOnly = true;
                chkSupInvDateNA.Enabled = false;
                dtpSupplierInvoiceDate.Enabled = false;
                txtSupplierInvoiceAmount.ReadOnly = true;
                txtVAT.ReadOnly = true;
                cboTaxCode.Enabled = false;
                txtExtraReference.ReadOnly = true;
                txtNominalCode.ReadOnly = true;
                txtDepartment.ReadOnly = true;
                cbxReadyToSendToSage.Enabled = true;
                lblStatus.Text = "*Supplier PI is ready to be sent to Sage*";
            }
            else if (OrderConsolidation.HasSupplierPO)
            {
                chkPOSupplied.Enabled = true;
                txtSupplierInvoiceReference.ReadOnly = false;
                chkSupInvDateNA.Enabled = true;
                txtSupplierInvoiceAmount.ReadOnly = false;
                txtVAT.ReadOnly = false;
                cboTaxCode.Enabled = true;
                txtExtraReference.ReadOnly = false;
                txtNominalCode.ReadOnly = false;
                txtDepartment.ReadOnly = false;
                cbxReadyToSendToSage.Enabled = true;
                lblStatus.Text = "*Supplier PI is assigned but not ready to be sent to Sage*";
            }
            else
            {
                chkPOSupplied.Enabled = true;
                txtSupplierInvoiceReference.ReadOnly = true;
                chkSupInvDateNA.Enabled = false;
                dtpSupplierInvoiceDate.Enabled = false;
                txtSupplierInvoiceAmount.ReadOnly = true;
                txtVAT.ReadOnly = true;
                cboTaxCode.Enabled = false;
                txtExtraReference.ReadOnly = true;
                txtNominalCode.ReadOnly = true;
                txtDepartment.ReadOnly = true;
                cbxReadyToSendToSage.Enabled = false;
                lblStatus.Text = "*Supplier PI has NOT been assigned so should be actioned within each related order*";
            }
        }

        private void Calculate_Tax()
        {
            if (IsLoading)
            {
                return;
            }

            if (OrderConsolidation is null)
            {
                txtVAT.Text = Strings.Format(0.0, "C");
            }
            else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboTaxCode)) == 0)
            {
                txtVAT.Text = Strings.Format(OrderConsolidation.VATAmount, "C");
            }
            else
            {
                try
                {
                    OrderConsolidation.SetVATAmount = OrderConsolidation.SupplierInvoiceAmount * (App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboTaxCode))).PercentageRate / 100);
                    txtVAT.Text = Strings.Format(OrderConsolidation.VATAmount, "C");
                }
                catch (Exception ex)
                {
                    txtVAT.Text = Strings.Format(OrderConsolidation.VATAmount, "C");
                }
            }
        }

        private void Save()
        {
            try
            {
                bool amountReceived = true;
                if (OrderConsolidation.ConsolidatedOrderStatusID == Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Confirmed))
                {
                    if (ItemsDataView is object)
                    {
                        foreach (DataRow itm in ItemsDataView.Table.Rows)
                        {
                            if (Conversions.ToBoolean(Entity.Sys.Helper.MakeIntegerValid(itm["EnterReceived"]) + itm["QuantityReceived"] > itm["QuantityOnOrder"]))
                            {
                                amountReceived = false;
                            }
                        }
                    }
                }

                if (amountReceived == false)
                {
                    if (App.ShowMessage("Some of the amounts entered for received are greater than the quantity ordered. Are you sure you wish to receive this quantity of stock?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }

                Cursor = Cursors.WaitCursor;
                OrderConsolidation.IgnoreExceptionsOnSetMethods = true;
                OrderConsolidation.SetConsolidationRef = txtReference.Text.Trim();
                OrderConsolidation.SetComments = txtComments.Text.Trim();
                if (Supplier is null)
                {
                    OrderConsolidation.SetSupplierID = 0;
                }
                else
                {
                    OrderConsolidation.SetSupplierID = Supplier.SupplierID;
                }

                OrderConsolidation.SetConsolidatedOrderStatusID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboStatus));
                OrderConsolidation.HasSupplierPO = chkPOSupplied.Checked;
                OrderConsolidation.SetSupplierInvoiceReference = txtSupplierInvoiceReference.Text.Trim();
                if (chkSupInvDateNA.Checked)
                {
                    OrderConsolidation.SupplierInvoiceDate = default;
                }
                else
                {
                    OrderConsolidation.SupplierInvoiceDate = dtpSupplierInvoiceDate.Value.Date;
                }

                OrderConsolidation.SetTaxCodeID = Combo.get_GetSelectedItemValue(cboTaxCode);
                OrderConsolidation.SetExtraRef = txtExtraReference.Text.Trim();
                OrderConsolidation.SetNominalCode = txtNominalCode.Text.Trim();
                OrderConsolidation.SetDepartmentRef = txtDepartment.Text.Trim();
                OrderConsolidation.SetReadyToSendToSage = cbxReadyToSendToSage.Checked;
                var oCValidator = new Entity.OrderConsolidations.OrderConsolidationValidator();
                oCValidator.Validate(OrderConsolidation, false);
                if (OrderConsolidation.ReadyToSendToSage)
                {
                    double itemAmount = 0.0;
                    foreach (DataRow row in ItemsDataView.Table.Rows)
                        itemAmount += row["BuyPrice"] * row["QuantityOnOrder"];
                    // PLUS ADDITIONAL
                    foreach (DataRow row in App.DB.OrderCharge.OrderCharge_GetForConsolidatedOrder(OrderConsolidation.OrderConsolidationID).Table.Rows)
                        itemAmount += row["Amount"];
                    if (!((Strings.Format(OrderConsolidation.SupplierInvoiceAmount, "F") ?? "") == (Strings.Format(itemAmount, "F") ?? "")))
                    {
                        App.ShowMessage("The entered supplier invoice amount does not match the total of the consolidation. You will now be prompted to enter the override password to continue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (!App.EnterOverridePassword())
                        {
                            return;
                        }
                    }
                }

                if (!(OrderConsolidation.Exists == true))
                {
                    OrderConsolidation.SetOrderConsolidationID = App.DB.OrderConsolidations.Insert(OrderConsolidation);
                    OrderNumberUsed = true;
                }

                App.DB.OrderConsolidations.OrderConsolidation_Clear_Orders(OrderConsolidation.OrderConsolidationID);
                foreach (DataRow row in OrderDataView.Table.Select("Tick = True"))
                    App.DB.OrderConsolidations.Order_Set_Consolidated(OrderConsolidation.OrderConsolidationID, Conversions.ToInteger(row["OrderID"]), false);
                if (OrderConsolidation.ConsolidatedOrderStatusID == Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Confirmed))
                {
                    ReceivedQuantityUpdated();
                }

                App.DB.OrderConsolidations.Update(OrderConsolidation);
                IsLoading = true;
                OrderConsolidation = App.DB.OrderConsolidations.OrderConsolidation_Get(OrderConsolidation.OrderConsolidationID);
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ReceivedQuantityUpdated()
        {
            foreach (DataRow itm in ItemsDataView.Table.Rows)
            {
                if (Entity.Sys.Helper.MakeIntegerValid(itm["EnterReceived"]) > 0)
                {
                    SaveReceived(Conversions.ToString(itm["Type"]), Conversions.ToInteger(itm["EnterReceived"]), Conversions.ToInteger(itm["OrderProductPartID"]), Conversions.ToInteger(itm["OrderTypeID"]));
                }
            }

            var ds = App.DB.OrderConsolidations.Orders_Complete_ByConsolidationOrderID(OrderConsolidation.OrderConsolidationID);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var dv = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(Conversions.ToInteger(row["EngineerVisitID"]));
                bool allComplete = true;
                foreach (DataRow dr in dv.Table.Rows)
                {
                    if (!(Entity.Sys.Helper.MakeIntegerValid(dr["OrderStatusID"]) == 0))
                    {
                        if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(dr["OrderStatusID"], Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Complete), false)))
                        {
                            allComplete = false;
                        }
                    }
                }

                if (allComplete)
                {
                    var oEngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(row["EngineerVisitID"]));
                    App.ShowForm(typeof(FRMPickDespatchDetails), true, new object[] { oEngineerVisit });
                }
            }

            foreach (DataRow row in ds.Tables[1].Rows)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["InvoiceToBeRaisedID"], 0, false)))
                {
                    if (App.ShowMessage(Conversions.ToString("The customer order '" + row["OrderDetails"] + "' which this consolidation relates to requires an invoice address. Would you like to assign now?"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        App.ShowForm(typeof(FrmRaiseInvoiceDetails), true, new object[] { row["OrderID"], row["InvoiceAddressID"] });
                    }
                }
            }

            OrderConsolidation.SetConsolidatedOrderStatusID = Conversions.ToInteger(ds.Tables[2].Rows[0]["ConsolidatedOrderStatusID"]);
        }

        private void SaveReceived(string Type, int QuantityInput, int OrderProductPartID, int OrderTypeID)
        {
            switch (Type)
            {
                case "OrderPart":
                    {
                        var OrderPart = App.DB.OrderPart.OrderPart_Get(OrderProductPartID);
                        OrderPart.SetQuantityReceived = OrderPart.QuantityReceived + QuantityInput;
                        App.DB.OrderPart.Update(OrderPart);
                        switch (OrderTypeID)
                        {
                            case Conversions.ToInteger(Entity.Sys.Enums.OrderType.Customer):
                                {
                                    break;
                                }
                            // DO NOTHING
                            case Conversions.ToInteger(Entity.Sys.Enums.OrderType.Job):
                                {
                                    break;
                                }
                            // DO NOTHING
                            case Conversions.ToInteger(Entity.Sys.Enums.OrderType.StockProfile):
                                {
                                    break;
                                }
                            // DO NOTHING - DONE ON PDA
                            case Conversions.ToInteger(Entity.Sys.Enums.OrderType.Warehouse):
                                {
                                    var oOrderLocation = App.DB.OrderLocation.OrderLocation_GetForOrder(OrderPart.OrderID);
                                    var oPartSupplier = App.DB.PartSupplier.PartSupplier_Get(OrderPart.PartSupplierID);
                                    var oPartTransaction = new Entity.PartTransactions.PartTransaction();
                                    oPartTransaction.SetLocationID = oOrderLocation.LocationID;
                                    oPartTransaction.SetPartID = oPartSupplier.PartID;
                                    oPartTransaction.SetOrderPartID = OrderPart.OrderPartID;
                                    oPartTransaction.SetAmount = QuantityInput * oPartSupplier.QuantityInPack;
                                    oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockIn);
                                    App.DB.PartTransaction.Insert(oPartTransaction);
                                    break;
                                }
                        }

                        break;
                    }

                case "OrderProduct":
                    {
                        var OrderProduct = App.DB.OrderProduct.OrderProduct_Get(OrderProductPartID);
                        OrderProduct.SetQuantityReceived = OrderProduct.QuantityReceived + QuantityInput;
                        App.DB.OrderProduct.Update(OrderProduct);
                        switch (OrderTypeID)
                        {
                            case Conversions.ToInteger(Entity.Sys.Enums.OrderType.Customer):
                                {
                                    break;
                                }
                            // DO NOTHING
                            case Conversions.ToInteger(Entity.Sys.Enums.OrderType.Job):
                                {
                                    break;
                                }
                            // DO NOTHING
                            case Conversions.ToInteger(Entity.Sys.Enums.OrderType.StockProfile):
                                {
                                    break;
                                }
                            // DO NOTHING - DONE ON PDA
                            case Conversions.ToInteger(Entity.Sys.Enums.OrderType.Warehouse):
                                {
                                    var oOrderLocation = App.DB.OrderLocation.OrderLocation_GetForOrder(OrderProduct.OrderID);
                                    var oProductSupplier = App.DB.ProductSupplier.ProductSupplier_Get(OrderProduct.ProductSupplierID);
                                    var oProductTransaction = new Entity.ProductTransactions.ProductTransaction();
                                    oProductTransaction.SetLocationID = oOrderLocation.LocationID;
                                    oProductTransaction.SetProductID = oProductSupplier.ProductID;
                                    oProductTransaction.SetOrderProductID = OrderProduct.OrderProductID;
                                    oProductTransaction.SetAmount = QuantityInput * oProductSupplier.QuantityInPack;
                                    oProductTransaction.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockIn);
                                    App.DB.ProductTransaction.Insert(oProductTransaction);
                                    break;
                                }
                        }

                        break;
                    }
            }
        }

        public void PrintSupplierPurchaseOrders(bool ShowDestination)
        {
            var dtAdditionalCharges = new DataTable();
            dtAdditionalCharges.Columns.Add("OrderChargeID");
            dtAdditionalCharges.Columns.Add("OrderID");
            dtAdditionalCharges.Columns.Add("OrderChargeTypeID");
            dtAdditionalCharges.Columns.Add("Amount");
            dtAdditionalCharges.Columns.Add("Reference");
            dtAdditionalCharges.Columns.Add("ChargeType");
            dtAdditionalCharges.Columns.Add("Deleted");
            var details = new ArrayList();
            details.Add(OrderConsolidation.ConsolidationRef);
            details.Add(App.DB.Supplier.Supplier_Get(OrderConsolidation.SupplierID));
            details.Add(ItemsDataView.Table);
            var deadLine = DateTime.MaxValue;
            foreach (DataRow row in OrderDataView.Table.Rows)
            {
                if (Entity.Sys.Helper.MakeDateTimeValid(row["DeliveryDeadline"]).Date < deadLine.Date)
                {
                    deadLine = Entity.Sys.Helper.MakeDateTimeValid(row["DeliveryDeadline"]).Date;
                }

                // GET ADDITIONAL CHARGES
                var dvOrderAdditionalCharges = App.DB.OrderCharge.OrderCharge_GetForOrder(Conversions.ToInteger(row["OrderID"]));
                foreach (DataRow drAdditional in dvOrderAdditionalCharges.Table.Rows)
                {
                    DataRow newRw;
                    newRw = dtAdditionalCharges.NewRow();
                    newRw["OrderChargeID"] = drAdditional["OrderChargeID"];
                    newRw["OrderID"] = drAdditional["OrderID"];
                    newRw["OrderChargeTypeID"] = drAdditional["OrderChargeTypeID"];
                    newRw["Amount"] = drAdditional["Amount"];
                    newRw["Reference"] = drAdditional["Reference"];
                    newRw["ChargeType"] = drAdditional["ChargeType"];
                    newRw["Deleted"] = drAdditional["Deleted"];
                    dtAdditionalCharges.Rows.Add(newRw);
                }
            }

            details.Add(deadLine);
            details.Add(new DataView(dtAdditionalCharges));
            if (ShowDestination)
            {
                var oPrint = new Entity.Sys.Printing(details, "SupplierPurchaseOrder", Entity.Sys.Enums.SystemDocumentType.SupplierPurchaseOrder_WithDestination);
            }
            else
            {
                var oPrint = new Entity.Sys.Printing(details, "SupplierPurchaseOrder", Entity.Sys.Enums.SystemDocumentType.SupplierPurchaseOrder);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}