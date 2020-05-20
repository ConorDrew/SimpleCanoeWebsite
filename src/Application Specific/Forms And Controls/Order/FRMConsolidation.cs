using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMConsolidation : FRMBaseForm, IForm
    {
        public FRMConsolidation() : base()
        {
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

        private GroupBox _grpItems;

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

        private Label _Label13;

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

        private Label _Label9;

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
            this._btnSave = new System.Windows.Forms.Button();
            this._btnClose = new System.Windows.Forms.Button();
            this._Label1 = new System.Windows.Forms.Label();
            this._Label2 = new System.Windows.Forms.Label();
            this._Label3 = new System.Windows.Forms.Label();
            this._Label4 = new System.Windows.Forms.Label();
            this._grpMain = new System.Windows.Forms.GroupBox();
            this._lblStatus = new System.Windows.Forms.Label();
            this._chkPOSupplied = new System.Windows.Forms.CheckBox();
            this._Label17 = new System.Windows.Forms.Label();
            this._cbxReadyToSendToSage = new System.Windows.Forms.CheckBox();
            this._txtDepartment = new System.Windows.Forms.TextBox();
            this._cboStatus = new System.Windows.Forms.ComboBox();
            this._txtNominalCode = new System.Windows.Forms.TextBox();
            this._btnSupplier = new System.Windows.Forms.Button();
            this._Label16 = new System.Windows.Forms.Label();
            this._txtComments = new System.Windows.Forms.TextBox();
            this._txtSupplier = new System.Windows.Forms.TextBox();
            this._txtVAT = new System.Windows.Forms.TextBox();
            this._txtExtraReference = new System.Windows.Forms.TextBox();
            this._Label14 = new System.Windows.Forms.Label();
            this._txtReference = new System.Windows.Forms.TextBox();
            this._cboTaxCode = new System.Windows.Forms.ComboBox();
            this._Label15 = new System.Windows.Forms.Label();
            this._Label13 = new System.Windows.Forms.Label();
            this._txtSupplierInvoiceAmount = new System.Windows.Forms.TextBox();
            this._Label10 = new System.Windows.Forms.Label();
            this._Label9 = new System.Windows.Forms.Label();
            this._chkSupInvDateNA = new System.Windows.Forms.CheckBox();
            this._txtSupplierInvoiceReference = new System.Windows.Forms.TextBox();
            this._dtpSupplierInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this._Label11 = new System.Windows.Forms.Label();
            this._grpOrders = new System.Windows.Forms.GroupBox();
            this._dgOrders = new System.Windows.Forms.DataGrid();
            this._grpItems = new System.Windows.Forms.GroupBox();
            this._lblOrderTotal = new System.Windows.Forms.Label();
            this._dgItems = new System.Windows.Forms.DataGrid();
            this._btnPrint = new System.Windows.Forms.Button();
            this._btnReceiveAll = new System.Windows.Forms.Button();
            this._btnPrintDistribution = new System.Windows.Forms.Button();
            this._grpMain.SuspendLayout();
            this._grpOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgOrders)).BeginInit();
            this._grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgItems)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSave.Location = new System.Drawing.Point(833, 681);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(60, 25);
            this._btnSave.TabIndex = 4;
            this._btnSave.Text = "Save";
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClose.Location = new System.Drawing.Point(12, 681);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(56, 25);
            this._btnClose.TabIndex = 7;
            this._btnClose.Text = "Close";
            this._btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // _Label1
            // 
            this._Label1.AutoSize = true;
            this._Label1.Location = new System.Drawing.Point(6, 26);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(65, 13);
            this._Label1.TabIndex = 4;
            this._Label1.Text = "Reference";
            // 
            // _Label2
            // 
            this._Label2.AutoSize = true;
            this._Label2.Location = new System.Drawing.Point(6, 83);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(69, 13);
            this._Label2.TabIndex = 5;
            this._Label2.Text = "Comments";
            // 
            // _Label3
            // 
            this._Label3.AutoSize = true;
            this._Label3.Location = new System.Drawing.Point(6, 52);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(54, 13);
            this._Label3.TabIndex = 6;
            this._Label3.Text = "Supplier";
            // 
            // _Label4
            // 
            this._Label4.AutoSize = true;
            this._Label4.Location = new System.Drawing.Point(185, 26);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(43, 13);
            this._Label4.TabIndex = 7;
            this._Label4.Text = "Status";
            // 
            // _grpMain
            // 
            this._grpMain.Controls.Add(this._lblStatus);
            this._grpMain.Controls.Add(this._chkPOSupplied);
            this._grpMain.Controls.Add(this._Label17);
            this._grpMain.Controls.Add(this._cbxReadyToSendToSage);
            this._grpMain.Controls.Add(this._txtDepartment);
            this._grpMain.Controls.Add(this._cboStatus);
            this._grpMain.Controls.Add(this._txtNominalCode);
            this._grpMain.Controls.Add(this._btnSupplier);
            this._grpMain.Controls.Add(this._Label16);
            this._grpMain.Controls.Add(this._txtComments);
            this._grpMain.Controls.Add(this._txtSupplier);
            this._grpMain.Controls.Add(this._txtVAT);
            this._grpMain.Controls.Add(this._txtExtraReference);
            this._grpMain.Controls.Add(this._Label14);
            this._grpMain.Controls.Add(this._txtReference);
            this._grpMain.Controls.Add(this._cboTaxCode);
            this._grpMain.Controls.Add(this._Label15);
            this._grpMain.Controls.Add(this._Label13);
            this._grpMain.Controls.Add(this._Label1);
            this._grpMain.Controls.Add(this._Label4);
            this._grpMain.Controls.Add(this._Label2);
            this._grpMain.Controls.Add(this._txtSupplierInvoiceAmount);
            this._grpMain.Controls.Add(this._Label3);
            this._grpMain.Controls.Add(this._Label10);
            this._grpMain.Controls.Add(this._Label9);
            this._grpMain.Controls.Add(this._chkSupInvDateNA);
            this._grpMain.Controls.Add(this._txtSupplierInvoiceReference);
            this._grpMain.Controls.Add(this._dtpSupplierInvoiceDate);
            this._grpMain.Controls.Add(this._Label11);
            this._grpMain.Location = new System.Drawing.Point(12, 12);
            this._grpMain.Name = "_grpMain";
            this._grpMain.Size = new System.Drawing.Size(400, 363);
            this._grpMain.TabIndex = 1;
            this._grpMain.TabStop = false;
            this._grpMain.Text = "Main Details";
            // 
            // _lblStatus
            // 
            this._lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._lblStatus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblStatus.Location = new System.Drawing.Point(10, 307);
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(233, 50);
            this._lblStatus.TabIndex = 89;
            this._lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _chkPOSupplied
            // 
            this._chkPOSupplied.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._chkPOSupplied.Location = new System.Drawing.Point(9, 161);
            this._chkPOSupplied.Name = "_chkPOSupplied";
            this._chkPOSupplied.Size = new System.Drawing.Size(251, 24);
            this._chkPOSupplied.TabIndex = 88;
            this._chkPOSupplied.Text = "Supplier purchase invoice provided";
            // 
            // _Label17
            // 
            this._Label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._Label17.Location = new System.Drawing.Point(243, 308);
            this._Label17.Name = "_Label17";
            this._Label17.Size = new System.Drawing.Size(38, 20);
            this._Label17.TabIndex = 87;
            this._Label17.Text = "Dept";
            // 
            // _cbxReadyToSendToSage
            // 
            this._cbxReadyToSendToSage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cbxReadyToSendToSage.Location = new System.Drawing.Point(232, 334);
            this._cbxReadyToSendToSage.Name = "_cbxReadyToSendToSage";
            this._cbxReadyToSendToSage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._cbxReadyToSendToSage.Size = new System.Drawing.Size(163, 24);
            this._cbxReadyToSendToSage.TabIndex = 78;
            this._cbxReadyToSendToSage.Text = "Ready to send to sage";
            // 
            // _txtDepartment
            // 
            this._txtDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._txtDepartment.Location = new System.Drawing.Point(302, 307);
            this._txtDepartment.MaxLength = 100;
            this._txtDepartment.Name = "_txtDepartment";
            this._txtDepartment.Size = new System.Drawing.Size(93, 21);
            this._txtDepartment.TabIndex = 77;
            this._txtDepartment.Tag = "Order.SupplierInvoiceReference";
            // 
            // _cboStatus
            // 
            this._cboStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboStatus.FormattingEnabled = true;
            this._cboStatus.Location = new System.Drawing.Point(234, 23);
            this._cboStatus.Name = "_cboStatus";
            this._cboStatus.Size = new System.Drawing.Size(160, 21);
            this._cboStatus.TabIndex = 2;
            this._cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // 
            // _txtNominalCode
            // 
            this._txtNominalCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtNominalCode.Location = new System.Drawing.Point(302, 278);
            this._txtNominalCode.MaxLength = 100;
            this._txtNominalCode.Name = "_txtNominalCode";
            this._txtNominalCode.Size = new System.Drawing.Size(93, 21);
            this._txtNominalCode.TabIndex = 76;
            this._txtNominalCode.Tag = "Order.SupplierInvoiceReference";
            // 
            // _btnSupplier
            // 
            this._btnSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSupplier.Location = new System.Drawing.Point(359, 52);
            this._btnSupplier.Name = "_btnSupplier";
            this._btnSupplier.Size = new System.Drawing.Size(35, 23);
            this._btnSupplier.TabIndex = 4;
            this._btnSupplier.Text = "...";
            this._btnSupplier.UseVisualStyleBackColor = true;
            this._btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // _Label16
            // 
            this._Label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label16.Location = new System.Drawing.Point(243, 278);
            this._Label16.Name = "_Label16";
            this._Label16.Size = new System.Drawing.Size(70, 20);
            this._Label16.TabIndex = 86;
            this._Label16.Text = "Nominal";
            // 
            // _txtComments
            // 
            this._txtComments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtComments.Location = new System.Drawing.Point(89, 83);
            this._txtComments.Multiline = true;
            this._txtComments.Name = "_txtComments";
            this._txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtComments.Size = new System.Drawing.Size(305, 72);
            this._txtComments.TabIndex = 5;
            // 
            // _txtSupplier
            // 
            this._txtSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSupplier.Location = new System.Drawing.Point(89, 52);
            this._txtSupplier.Name = "_txtSupplier";
            this._txtSupplier.ReadOnly = true;
            this._txtSupplier.Size = new System.Drawing.Size(264, 21);
            this._txtSupplier.TabIndex = 3;
            // 
            // _txtVAT
            // 
            this._txtVAT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtVAT.Location = new System.Drawing.Point(138, 277);
            this._txtVAT.MaxLength = 100;
            this._txtVAT.Name = "_txtVAT";
            this._txtVAT.Size = new System.Drawing.Size(105, 21);
            this._txtVAT.TabIndex = 75;
            this._txtVAT.Tag = "Order.SupplierInvoiceAmount";
            this._txtVAT.GotFocus += new System.EventHandler(this.txtVAT_GotFocus);
            this._txtVAT.Validating += new System.ComponentModel.CancelEventHandler(this.txtVAT_Validating);
            // 
            // _txtExtraReference
            // 
            this._txtExtraReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtExtraReference.Location = new System.Drawing.Point(302, 189);
            this._txtExtraReference.MaxLength = 100;
            this._txtExtraReference.Name = "_txtExtraReference";
            this._txtExtraReference.Size = new System.Drawing.Size(93, 21);
            this._txtExtraReference.TabIndex = 70;
            this._txtExtraReference.Tag = "Order.SupplierInvoiceReference";
            // 
            // _Label14
            // 
            this._Label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label14.Location = new System.Drawing.Point(7, 278);
            this._Label14.Name = "_Label14";
            this._Label14.Size = new System.Drawing.Size(125, 20);
            this._Label14.TabIndex = 84;
            this._Label14.Text = "Invoice VAT Amount";
            // 
            // _txtReference
            // 
            this._txtReference.Location = new System.Drawing.Point(89, 23);
            this._txtReference.Name = "_txtReference";
            this._txtReference.Size = new System.Drawing.Size(90, 21);
            this._txtReference.TabIndex = 1;
            // 
            // _cboTaxCode
            // 
            this._cboTaxCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._cboTaxCode.Location = new System.Drawing.Point(302, 249);
            this._cboTaxCode.Name = "_cboTaxCode";
            this._cboTaxCode.Size = new System.Drawing.Size(93, 21);
            this._cboTaxCode.TabIndex = 74;
            this._cboTaxCode.SelectedIndexChanged += new System.EventHandler(this.cboTaxCode_SelectedIndexChanged);
            // 
            // _Label15
            // 
            this._Label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label15.Location = new System.Drawing.Point(249, 192);
            this._Label15.Name = "_Label15";
            this._Label15.Size = new System.Drawing.Size(56, 20);
            this._Label15.TabIndex = 85;
            this._Label15.Text = "Ex Ref.";
            // 
            // _Label13
            // 
            this._Label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label13.Location = new System.Drawing.Point(243, 251);
            this._Label13.Name = "_Label13";
            this._Label13.Size = new System.Drawing.Size(70, 20);
            this._Label13.TabIndex = 83;
            this._Label13.Text = "Tax Code";
            // 
            // _txtSupplierInvoiceAmount
            // 
            this._txtSupplierInvoiceAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtSupplierInvoiceAmount.Location = new System.Drawing.Point(138, 249);
            this._txtSupplierInvoiceAmount.MaxLength = 100;
            this._txtSupplierInvoiceAmount.Name = "_txtSupplierInvoiceAmount";
            this._txtSupplierInvoiceAmount.Size = new System.Drawing.Size(105, 21);
            this._txtSupplierInvoiceAmount.TabIndex = 73;
            this._txtSupplierInvoiceAmount.Tag = "Order.SupplierInvoiceAmount";
            this._txtSupplierInvoiceAmount.GotFocus += new System.EventHandler(this.txtSupplierInvoiceAmount_GotFocus);
            this._txtSupplierInvoiceAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txtSupplierInvoiceAmount_Validating);
            // 
            // _Label10
            // 
            this._Label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label10.Location = new System.Drawing.Point(7, 248);
            this._Label10.Name = "_Label10";
            this._Label10.Size = new System.Drawing.Size(106, 20);
            this._Label10.TabIndex = 80;
            this._Label10.Text = "Invoice Amount";
            // 
            // _Label9
            // 
            this._Label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label9.Location = new System.Drawing.Point(7, 191);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(94, 20);
            this._Label9.TabIndex = 79;
            this._Label9.Text = "Invoice Ref.";
            // 
            // _chkSupInvDateNA
            // 
            this._chkSupInvDateNA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._chkSupInvDateNA.Location = new System.Drawing.Point(138, 219);
            this._chkSupInvDateNA.Name = "_chkSupInvDateNA";
            this._chkSupInvDateNA.Size = new System.Drawing.Size(48, 24);
            this._chkSupInvDateNA.TabIndex = 71;
            this._chkSupInvDateNA.Text = "N/A";
            this._chkSupInvDateNA.CheckedChanged += new System.EventHandler(this.chkSupInvDateNA_CheckedChanged);
            // 
            // _txtSupplierInvoiceReference
            // 
            this._txtSupplierInvoiceReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtSupplierInvoiceReference.Location = new System.Drawing.Point(138, 188);
            this._txtSupplierInvoiceReference.MaxLength = 100;
            this._txtSupplierInvoiceReference.Name = "_txtSupplierInvoiceReference";
            this._txtSupplierInvoiceReference.Size = new System.Drawing.Size(105, 21);
            this._txtSupplierInvoiceReference.TabIndex = 69;
            this._txtSupplierInvoiceReference.Tag = "Order.SupplierInvoiceReference";
            // 
            // _dtpSupplierInvoiceDate
            // 
            this._dtpSupplierInvoiceDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._dtpSupplierInvoiceDate.Location = new System.Drawing.Point(189, 222);
            this._dtpSupplierInvoiceDate.Name = "_dtpSupplierInvoiceDate";
            this._dtpSupplierInvoiceDate.Size = new System.Drawing.Size(206, 21);
            this._dtpSupplierInvoiceDate.TabIndex = 72;
            this._dtpSupplierInvoiceDate.Tag = "Order.SupplierInvoiceDate";
            // 
            // _Label11
            // 
            this._Label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label11.Location = new System.Drawing.Point(7, 221);
            this._Label11.Name = "_Label11";
            this._Label11.Size = new System.Drawing.Size(94, 20);
            this._Label11.TabIndex = 81;
            this._Label11.Text = "Invoice Date";
            // 
            // _grpOrders
            // 
            this._grpOrders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpOrders.Controls.Add(this._dgOrders);
            this._grpOrders.Location = new System.Drawing.Point(418, 12);
            this._grpOrders.Name = "_grpOrders";
            this._grpOrders.Size = new System.Drawing.Size(475, 363);
            this._grpOrders.TabIndex = 2;
            this._grpOrders.TabStop = false;
            this._grpOrders.Text = "Related Orders (Double click to view)";
            // 
            // _dgOrders
            // 
            this._dgOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgOrders.DataMember = "";
            this._dgOrders.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgOrders.Location = new System.Drawing.Point(6, 23);
            this._dgOrders.Name = "_dgOrders";
            this._dgOrders.Size = new System.Drawing.Size(463, 334);
            this._dgOrders.TabIndex = 1;
            this._dgOrders.DoubleClick += new System.EventHandler(this.dgOrders_DoubleClick);
            // 
            // _grpItems
            // 
            this._grpItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpItems.Controls.Add(this._lblOrderTotal);
            this._grpItems.Controls.Add(this._dgItems);
            this._grpItems.Location = new System.Drawing.Point(12, 381);
            this._grpItems.Name = "_grpItems";
            this._grpItems.Size = new System.Drawing.Size(881, 294);
            this._grpItems.TabIndex = 3;
            this._grpItems.TabStop = false;
            this._grpItems.Text = "Related Items";
            // 
            // _lblOrderTotal
            // 
            this._lblOrderTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblOrderTotal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblOrderTotal.Location = new System.Drawing.Point(580, 17);
            this._lblOrderTotal.Name = "_lblOrderTotal";
            this._lblOrderTotal.Size = new System.Drawing.Size(295, 15);
            this._lblOrderTotal.TabIndex = 82;
            this._lblOrderTotal.Text = "Order Total : £0.00";
            this._lblOrderTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _dgItems
            // 
            this._dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgItems.DataMember = "";
            this._dgItems.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgItems.Location = new System.Drawing.Point(9, 35);
            this._dgItems.Name = "_dgItems";
            this._dgItems.Size = new System.Drawing.Size(866, 253);
            this._dgItems.TabIndex = 1;
            this._dgItems.DoubleClick += new System.EventHandler(this.dgItems_DoubleClick);
            this._dgItems.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgItems_MouseUp);
            // 
            // _btnPrint
            // 
            this._btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnPrint.Location = new System.Drawing.Point(434, 681);
            this._btnPrint.Name = "_btnPrint";
            this._btnPrint.Size = new System.Drawing.Size(249, 25);
            this._btnPrint.TabIndex = 6;
            this._btnPrint.Text = "Print combined supplier purchase order";
            this._btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // _btnReceiveAll
            // 
            this._btnReceiveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnReceiveAll.Location = new System.Drawing.Point(689, 681);
            this._btnReceiveAll.Name = "_btnReceiveAll";
            this._btnReceiveAll.Size = new System.Drawing.Size(138, 25);
            this._btnReceiveAll.TabIndex = 5;
            this._btnReceiveAll.Text = "Save && Receive All";
            this._btnReceiveAll.Click += new System.EventHandler(this.btnReceiveAll_Click);
            // 
            // _btnPrintDistribution
            // 
            this._btnPrintDistribution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnPrintDistribution.Location = new System.Drawing.Point(258, 681);
            this._btnPrintDistribution.Name = "_btnPrintDistribution";
            this._btnPrintDistribution.Size = new System.Drawing.Size(170, 25);
            this._btnPrintDistribution.TabIndex = 8;
            this._btnPrintDistribution.Text = "Print order distribution list";
            this._btnPrintDistribution.Click += new System.EventHandler(this.btnPrintDistribution_Click);
            // 
            // FRMConsolidation
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(905, 718);
            this.ControlBox = false;
            this.Controls.Add(this._btnPrintDistribution);
            this.Controls.Add(this._btnReceiveAll);
            this.Controls.Add(this._btnPrint);
            this.Controls.Add(this._grpItems);
            this.Controls.Add(this._grpOrders);
            this.Controls.Add(this._grpMain);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._btnSave);
            this.MinimumSize = new System.Drawing.Size(913, 752);
            this.Name = "FRMConsolidation";
            this.Text = "Consolidation : ID {0}";
            this._grpMain.ResumeLayout(false);
            this._grpMain.PerformLayout();
            this._grpOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgOrders)).EndInit();
            this._grpItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgItems)).EndInit();
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
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

            if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboStatus)) > (int)Entity.Sys.Enums.OrderStatus.AwaitingConfirmation)
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
                row["EnterReceived"] = (int)row["QuantityOnOrder"] - (int)row["QuantityReceived"];
                if (Conversions.ToBoolean((int)row["EnterReceived"] < 0))
                {
                    row["EnterReceived"] = 0;
                }
            }

            Save();
        }

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
                            if (Conversions.ToBoolean(Entity.Sys.Helper.MakeIntegerValid(itm["EnterReceived"]) + (int)itm["QuantityReceived"] > (int)itm["QuantityOnOrder"]))
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
                    decimal itemAmount = 0;
                    foreach (DataRow row in ItemsDataView.Table.Rows)
                        itemAmount += (decimal)row["BuyPrice"] * (int)row["QuantityOnOrder"];
                    // PLUS ADDITIONAL
                    foreach (DataRow row in App.DB.OrderCharge.OrderCharge_GetForConsolidatedOrder(OrderConsolidation.OrderConsolidationID).Table.Rows)
                        itemAmount += (decimal)row["Amount"];
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
                            case (int)(Entity.Sys.Enums.OrderType.Customer):
                                {
                                    break;
                                }
                            // DO NOTHING
                            case (int)(Entity.Sys.Enums.OrderType.Job):
                                {
                                    break;
                                }
                            // DO NOTHING
                            case (int)(Entity.Sys.Enums.OrderType.StockProfile):
                                {
                                    break;
                                }
                            // DO NOTHING - DONE ON PDA
                            case (int)(Entity.Sys.Enums.OrderType.Warehouse):
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
                            case (int)(Entity.Sys.Enums.OrderType.Customer):
                                {
                                    break;
                                }
                            // DO NOTHING
                            case (int)(Entity.Sys.Enums.OrderType.Job):
                                {
                                    break;
                                }
                            // DO NOTHING
                            case (int)(Entity.Sys.Enums.OrderType.StockProfile):
                                {
                                    break;
                                }
                            // DO NOTHING - DONE ON PDA
                            case (int)(Entity.Sys.Enums.OrderType.Warehouse):
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
    }
}