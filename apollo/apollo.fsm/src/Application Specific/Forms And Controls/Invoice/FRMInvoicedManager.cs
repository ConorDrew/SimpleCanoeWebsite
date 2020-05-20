using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMInvoicedManager : FRMBaseForm, IForm
    {
        public FRMInvoicedManager() : base()
        {
            base.Load += FRMInvoicedManager_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            // PopulateDatagrid()

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
        private Button _btnPrintOneItemOneInvoice;

        private Button _btnExport;

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

        private GroupBox _grpFilter;

        private Button _btnFindCustomer;

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

        private Label _lblCustomer;

        private TextBox _txtPostcode;

        internal TextBox txtPostcode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPostcode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPostcode != null)
                {
                    _txtPostcode.KeyDown -= txtJobNumber_TextChanged;
                }

                _txtPostcode = value;
                if (_txtPostcode != null)
                {
                    _txtPostcode.KeyDown += txtJobNumber_TextChanged;
                }
            }
        }

        private Label _lblPostcode;

        private Button _btnFindSite;

        private TextBox _txtSite;

        internal TextBox txtSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSite != null)
                {
                }

                _txtSite = value;
                if (_txtSite != null)
                {
                }
            }
        }

        private TextBox _txtJobNumber;

        internal TextBox txtJobNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtJobNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtJobNumber != null)
                {
                    _txtJobNumber.KeyDown -= txtJobNumber_TextChanged;
                }

                _txtJobNumber = value;
                if (_txtJobNumber != null)
                {
                    _txtJobNumber.KeyDown += txtJobNumber_TextChanged;
                }
            }
        }

        private Label _lblRefNo;

        private Label _lblProperty;

        private Label _lblType;

        private ComboBox _cboType;

        internal ComboBox cboType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboType != null)
                {
                }

                _cboType = value;
                if (_cboType != null)
                {
                }
            }
        }

        private Label _lblDate;

        private DateTimePicker _dtpRaisedTo;

        internal DateTimePicker dtpRaisedTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpRaisedTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpRaisedTo != null)
                {
                }

                _dtpRaisedTo = value;
                if (_dtpRaisedTo != null)
                {
                }
            }
        }

        private DateTimePicker _dtpRaisedFrom;

        internal DateTimePicker dtpRaisedFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpRaisedFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpRaisedFrom != null)
                {
                }

                _dtpRaisedFrom = value;
                if (_dtpRaisedFrom != null)
                {
                }
            }
        }

        private Label _lblDateBetween;

        private Label _lblInvoiceNumber;

        private Label _lblStatus;

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
                }

                _cboStatus = value;
                if (_cboStatus != null)
                {
                }
            }
        }

        private GroupBox _grpInvoices;

        internal GroupBox grpInvoices
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpInvoices;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpInvoices != null)
                {
                }

                _grpInvoices = value;
                if (_grpInvoices != null)
                {
                }
            }
        }

        private Label _lblInvoicePartPayed;

        private Label _lblInvoicePayed;

        private Label _lblGreenColour;

        private Label _lblGoldColour;

        private Label _lblInvoicedNotPayed;

        private Label _lblRedColour;

        private DataGrid _dgInvoices;

        internal DataGrid dgInvoices
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgInvoices;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgInvoices != null)
                {
                    _dgInvoices.MouseUp -= dgInvoices_MouseUp;
                    _dgInvoices.DoubleClick -= dgInvoices_DoubleClick;
                }

                _dgInvoices = value;
                if (_dgInvoices != null)
                {
                    _dgInvoices.MouseUp += dgInvoices_MouseUp;
                    _dgInvoices.DoubleClick += dgInvoices_DoubleClick;
                }
            }
        }

        private Button _btnSelectAll;

        private Button _btnDeselectAll;

        private Label _lblUser;

        private ComboBox _cboUser;

        internal ComboBox cboUser
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboUser;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboUser != null)
                {
                }

                _cboUser = value;
                if (_cboUser != null)
                {
                }
            }
        }

        private TextBox _txtInvoiceNumber;

        internal TextBox txtInvoiceNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtInvoiceNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtInvoiceNumber != null)
                {
                    _txtInvoiceNumber.KeyDown -= txtJobNumber_TextChanged;
                }

                _txtInvoiceNumber = value;
                if (_txtInvoiceNumber != null)
                {
                    _txtInvoiceNumber.KeyDown += txtJobNumber_TextChanged;
                }
            }
        }

        private Button _btnChange;

        internal Button btnChange
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnChange;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnChange != null)
                {
                    _btnChange.Click -= btnChange_Click;
                }

                _btnChange = value;
                if (_btnChange != null)
                {
                    _btnChange.Click += btnChange_Click;
                }
            }
        }

        private Button _btnMarkAsNotExported;

        private ComboBox _cboExported;

        internal ComboBox cboExported
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboExported;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboExported != null)
                {
                    _cboExported.SelectedIndexChanged -= cboExportedToSage_SelectedIndexChanged;
                }

                _cboExported = value;
                if (_cboExported != null)
                {
                    _cboExported.SelectedIndexChanged += cboExportedToSage_SelectedIndexChanged;
                }
            }
        }

        private Label _lblExported;

        private Button _btnSearch;

        private Label _lblRegion;

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

        private Button _btnGenVal;

        internal Button btnGenVal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnGenVal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnGenVal != null)
                {
                    _btnGenVal.Click -= btnGenNCCVal_Click;
                }

                _btnGenVal = value;
                if (_btnGenVal != null)
                {
                    _btnGenVal.Click += btnGenNCCVal_Click;
                }
            }
        }

        private Label _lblSageMonth;

        private TextBox _txtSageMonth;

        internal TextBox txtSageMonth
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSageMonth;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSageMonth != null)
                {
                    _txtSageMonth.DoubleClick -= txtSageMonth_TextChanged;
                }

                _txtSageMonth = value;
                if (_txtSageMonth != null)
                {
                    _txtSageMonth.DoubleClick += txtSageMonth_TextChanged;
                }
            }
        }

        private Button _btnSalesCredit;

        internal Button btnSalesCredit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSalesCredit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSalesCredit != null)
                {
                    _btnSalesCredit.Click -= btnSalesCredit_Click;
                }

                _btnSalesCredit = value;
                if (_btnSalesCredit != null)
                {
                    _btnSalesCredit.Click += btnSalesCredit_Click;
                }
            }
        }

        private ContextMenuStrip _cmsValType;

        internal ContextMenuStrip cmsValType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmsValType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmsValType != null)
                {
                }

                _cmsValType = value;
                if (_cmsValType != null)
                {
                }
            }
        }

        private ToolStripMenuItem _tsmiNCCVal;

        private ToolStripMenuItem _tsmiGenericVal;

        private ContextMenuStrip _cmsChange;

        internal ContextMenuStrip cmsChange
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmsChange;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmsChange != null)
                {
                }

                _cmsChange = value;
                if (_cmsChange != null)
                {
                }
            }
        }

        private ToolStripMenuItem _tsmiPaymentTerms;

        private ToolStripMenuItem _tsmiInvoicedTotal;

        private ToolStripMenuItem _tsmiVatRate;

        private ContextMenuStrip _cmsSalesCredit;

        internal ContextMenuStrip cmsSalesCredit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmsSalesCredit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmsSalesCredit != null)
                {
                }

                _cmsSalesCredit = value;
                if (_cmsSalesCredit != null)
                {
                }
            }
        }

        private ToolStripMenuItem _tsmiIssue;

        private ToolStripMenuItem _tsmiRemove;

        private ToolStripMenuItem _tsmiBatchPrint;

        private ContextMenuStrip _cmsExportForAccounts;

        internal ContextMenuStrip cmsExportForAccounts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmsExportForAccounts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmsExportForAccounts != null)
                {
                }

                _cmsExportForAccounts = value;
                if (_cmsExportForAccounts != null)
                {
                }
            }
        }

        private ToolStripMenuItem _tsmiSunExport;

        private ToolStripMenuItem _tsmiSageExport;

        private Button _btnExportToAccounts;

        internal Button btnExportToAccounts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnExportToAccounts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnExportToAccounts != null)
                {
                    _btnExportToAccounts.Click -= btnExportToAccounts_Click;
                }

                _btnExportToAccounts = value;
                if (_btnExportToAccounts != null)
                {
                    _btnExportToAccounts.Click += btnExportToAccounts_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmiAccountNumber;

        private Label _lblDept;

        private ComboBox _cboDept;

        internal ComboBox cboDept
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDept;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDept != null)
                {
                }

                _cboDept = value;
                if (_cboDept != null)
                {
                }
            }
        }

        private ToolStripMenuItem _tsmiOrderNo;

        private DateTimePicker _dtpExportedOn;

        internal DateTimePicker dtpExportedOn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpExportedOn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpExportedOn != null)
                {
                }

                _dtpExportedOn = value;
                if (_dtpExportedOn != null)
                {
                }
            }
        }

        private Label _lblExportedOn;

        private CheckBox _chkExportedOn;

        internal CheckBox chkExportedOn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkExportedOn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkExportedOn != null)
                {
                    _chkExportedOn.Click -= chkExportedOn_Click;
                }

                _chkExportedOn = value;
                if (_chkExportedOn != null)
                {
                    _chkExportedOn.Click += chkExportedOn_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmiSorVal;

        private Button _btnView;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._btnPrintOneItemOneInvoice = new System.Windows.Forms.Button();
            this._btnExport = new System.Windows.Forms.Button();
            this._btnReset = new System.Windows.Forms.Button();
            this._grpFilter = new System.Windows.Forms.GroupBox();
            this._dtpExportedOn = new System.Windows.Forms.DateTimePicker();
            this._lblExportedOn = new System.Windows.Forms.Label();
            this._lblDept = new System.Windows.Forms.Label();
            this._cboDept = new System.Windows.Forms.ComboBox();
            this._lblSageMonth = new System.Windows.Forms.Label();
            this._txtSageMonth = new System.Windows.Forms.TextBox();
            this._lblRegion = new System.Windows.Forms.Label();
            this._cboRegion = new System.Windows.Forms.ComboBox();
            this._btnSearch = new System.Windows.Forms.Button();
            this._cboExported = new System.Windows.Forms.ComboBox();
            this._lblExported = new System.Windows.Forms.Label();
            this._btnFindCustomer = new System.Windows.Forms.Button();
            this._txtCustomer = new System.Windows.Forms.TextBox();
            this._lblCustomer = new System.Windows.Forms.Label();
            this._txtPostcode = new System.Windows.Forms.TextBox();
            this._lblPostcode = new System.Windows.Forms.Label();
            this._btnFindSite = new System.Windows.Forms.Button();
            this._txtSite = new System.Windows.Forms.TextBox();
            this._txtJobNumber = new System.Windows.Forms.TextBox();
            this._lblRefNo = new System.Windows.Forms.Label();
            this._lblProperty = new System.Windows.Forms.Label();
            this._lblType = new System.Windows.Forms.Label();
            this._cboType = new System.Windows.Forms.ComboBox();
            this._lblDateBetween = new System.Windows.Forms.Label();
            this._dtpRaisedFrom = new System.Windows.Forms.DateTimePicker();
            this._dtpRaisedTo = new System.Windows.Forms.DateTimePicker();
            this._lblDate = new System.Windows.Forms.Label();
            this._cboStatus = new System.Windows.Forms.ComboBox();
            this._lblStatus = new System.Windows.Forms.Label();
            this._lblInvoiceNumber = new System.Windows.Forms.Label();
            this._lblUser = new System.Windows.Forms.Label();
            this._cboUser = new System.Windows.Forms.ComboBox();
            this._txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this._chkExportedOn = new System.Windows.Forms.CheckBox();
            this._grpInvoices = new System.Windows.Forms.GroupBox();
            this._btnSalesCredit = new System.Windows.Forms.Button();
            this._btnChange = new System.Windows.Forms.Button();
            this._dgInvoices = new System.Windows.Forms.DataGrid();
            this._btnSelectAll = new System.Windows.Forms.Button();
            this._btnDeselectAll = new System.Windows.Forms.Button();
            this._lblInvoicePartPayed = new System.Windows.Forms.Label();
            this._lblInvoicePayed = new System.Windows.Forms.Label();
            this._lblGreenColour = new System.Windows.Forms.Label();
            this._lblGoldColour = new System.Windows.Forms.Label();
            this._lblInvoicedNotPayed = new System.Windows.Forms.Label();
            this._lblRedColour = new System.Windows.Forms.Label();
            this._btnView = new System.Windows.Forms.Button();
            this._btnMarkAsNotExported = new System.Windows.Forms.Button();
            this._btnGenVal = new System.Windows.Forms.Button();
            this._cmsValType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._tsmiNCCVal = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmiGenericVal = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmiSorVal = new System.Windows.Forms.ToolStripMenuItem();
            this._cmsChange = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._tsmiPaymentTerms = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmiInvoicedTotal = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmiVatRate = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmiAccountNumber = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmiOrderNo = new System.Windows.Forms.ToolStripMenuItem();
            this._cmsSalesCredit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._tsmiIssue = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmiRemove = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmiBatchPrint = new System.Windows.Forms.ToolStripMenuItem();
            this._cmsExportForAccounts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._tsmiSunExport = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmiSageExport = new System.Windows.Forms.ToolStripMenuItem();
            this._btnExportToAccounts = new System.Windows.Forms.Button();
            this._grpFilter.SuspendLayout();
            this._grpInvoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgInvoices)).BeginInit();
            this._cmsValType.SuspendLayout();
            this._cmsChange.SuspendLayout();
            this._cmsSalesCredit.SuspendLayout();
            this._cmsExportForAccounts.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnPrintOneItemOneInvoice
            // 
            this._btnPrintOneItemOneInvoice.AccessibleDescription = "Export Job List To Excel";
            this._btnPrintOneItemOneInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnPrintOneItemOneInvoice.Location = new System.Drawing.Point(125, 594);
            this._btnPrintOneItemOneInvoice.Name = "_btnPrintOneItemOneInvoice";
            this._btnPrintOneItemOneInvoice.Size = new System.Drawing.Size(141, 23);
            this._btnPrintOneItemOneInvoice.TabIndex = 27;
            this._btnPrintOneItemOneInvoice.Text = "Regenerate Invoice";
            this._btnPrintOneItemOneInvoice.Click += new System.EventHandler(this.btnPrintOneItemOneInvoice_Click);
            // 
            // _btnExport
            // 
            this._btnExport.AccessibleDescription = "Export Job List To Excel";
            this._btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnExport.Location = new System.Drawing.Point(8, 594);
            this._btnExport.Name = "_btnExport";
            this._btnExport.Size = new System.Drawing.Size(56, 23);
            this._btnExport.TabIndex = 25;
            this._btnExport.Text = "Export";
            this._btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // _btnReset
            // 
            this._btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnReset.Location = new System.Drawing.Point(67, 594);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(55, 23);
            this._btnReset.TabIndex = 26;
            this._btnReset.Text = "Reset";
            this._btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // _grpFilter
            // 
            this._grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpFilter.Controls.Add(this._dtpExportedOn);
            this._grpFilter.Controls.Add(this._lblExportedOn);
            this._grpFilter.Controls.Add(this._lblDept);
            this._grpFilter.Controls.Add(this._cboDept);
            this._grpFilter.Controls.Add(this._lblSageMonth);
            this._grpFilter.Controls.Add(this._txtSageMonth);
            this._grpFilter.Controls.Add(this._lblRegion);
            this._grpFilter.Controls.Add(this._cboRegion);
            this._grpFilter.Controls.Add(this._btnSearch);
            this._grpFilter.Controls.Add(this._cboExported);
            this._grpFilter.Controls.Add(this._lblExported);
            this._grpFilter.Controls.Add(this._btnFindCustomer);
            this._grpFilter.Controls.Add(this._txtCustomer);
            this._grpFilter.Controls.Add(this._lblCustomer);
            this._grpFilter.Controls.Add(this._txtPostcode);
            this._grpFilter.Controls.Add(this._lblPostcode);
            this._grpFilter.Controls.Add(this._btnFindSite);
            this._grpFilter.Controls.Add(this._txtSite);
            this._grpFilter.Controls.Add(this._txtJobNumber);
            this._grpFilter.Controls.Add(this._lblRefNo);
            this._grpFilter.Controls.Add(this._lblProperty);
            this._grpFilter.Controls.Add(this._lblType);
            this._grpFilter.Controls.Add(this._cboType);
            this._grpFilter.Controls.Add(this._lblDateBetween);
            this._grpFilter.Controls.Add(this._dtpRaisedFrom);
            this._grpFilter.Controls.Add(this._dtpRaisedTo);
            this._grpFilter.Controls.Add(this._lblDate);
            this._grpFilter.Controls.Add(this._cboStatus);
            this._grpFilter.Controls.Add(this._lblStatus);
            this._grpFilter.Controls.Add(this._lblInvoiceNumber);
            this._grpFilter.Controls.Add(this._lblUser);
            this._grpFilter.Controls.Add(this._cboUser);
            this._grpFilter.Controls.Add(this._txtInvoiceNumber);
            this._grpFilter.Controls.Add(this._chkExportedOn);
            this._grpFilter.Location = new System.Drawing.Point(8, 12);
            this._grpFilter.Name = "_grpFilter";
            this._grpFilter.Size = new System.Drawing.Size(1123, 236);
            this._grpFilter.TabIndex = 24;
            this._grpFilter.TabStop = false;
            this._grpFilter.Text = "Filter";
            // 
            // _dtpExportedOn
            // 
            this._dtpExportedOn.Location = new System.Drawing.Point(541, 163);
            this._dtpExportedOn.Name = "_dtpExportedOn";
            this._dtpExportedOn.Size = new System.Drawing.Size(186, 21);
            this._dtpExportedOn.TabIndex = 44;
            // 
            // _lblExportedOn
            // 
            this._lblExportedOn.Location = new System.Drawing.Point(416, 164);
            this._lblExportedOn.Name = "_lblExportedOn";
            this._lblExportedOn.Size = new System.Drawing.Size(85, 16);
            this._lblExportedOn.TabIndex = 45;
            this._lblExportedOn.Text = "Exported On";
            // 
            // _lblDept
            // 
            this._lblDept.AutoSize = true;
            this._lblDept.Location = new System.Drawing.Point(747, 166);
            this._lblDept.Name = "_lblDept";
            this._lblDept.Size = new System.Drawing.Size(76, 13);
            this._lblDept.TabIndex = 42;
            this._lblDept.Text = "Cost Centre";
            // 
            // _cboDept
            // 
            this._cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboDept.Location = new System.Drawing.Point(845, 164);
            this._cboDept.Name = "_cboDept";
            this._cboDept.Size = new System.Drawing.Size(224, 21);
            this._cboDept.TabIndex = 43;
            // 
            // _lblSageMonth
            // 
            this._lblSageMonth.Location = new System.Drawing.Point(416, 197);
            this._lblSageMonth.Name = "_lblSageMonth";
            this._lblSageMonth.Size = new System.Drawing.Size(98, 19);
            this._lblSageMonth.TabIndex = 40;
            this._lblSageMonth.Text = "Account Month";
            // 
            // _txtSageMonth
            // 
            this._txtSageMonth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSageMonth.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtSageMonth.Location = new System.Drawing.Point(520, 195);
            this._txtSageMonth.Name = "_txtSageMonth";
            this._txtSageMonth.ReadOnly = true;
            this._txtSageMonth.Size = new System.Drawing.Size(207, 21);
            this._txtSageMonth.TabIndex = 41;
            this._txtSageMonth.DoubleClick += new System.EventHandler(this.txtSageMonth_TextChanged);
            // 
            // _lblRegion
            // 
            this._lblRegion.Location = new System.Drawing.Point(8, 198);
            this._lblRegion.Name = "_lblRegion";
            this._lblRegion.Size = new System.Drawing.Size(72, 16);
            this._lblRegion.TabIndex = 39;
            this._lblRegion.Text = "Region";
            // 
            // _cboRegion
            // 
            this._cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboRegion.Location = new System.Drawing.Point(160, 195);
            this._cboRegion.Name = "_cboRegion";
            this._cboRegion.Size = new System.Drawing.Size(248, 21);
            this._cboRegion.TabIndex = 38;
            // 
            // _btnSearch
            // 
            this._btnSearch.AccessibleDescription = "Export Job List To Excel";
            this._btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSearch.Location = new System.Drawing.Point(981, 198);
            this._btnSearch.Name = "_btnSearch";
            this._btnSearch.Size = new System.Drawing.Size(88, 23);
            this._btnSearch.TabIndex = 30;
            this._btnSearch.Text = "Run Filter";
            this._btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // _cboExported
            // 
            this._cboExported.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboExported.Items.AddRange(new object[] {
            "Show All",
            "Exported",
            "Not Exported"});
            this._cboExported.Location = new System.Drawing.Point(160, 161);
            this._cboExported.Name = "_cboExported";
            this._cboExported.Size = new System.Drawing.Size(248, 21);
            this._cboExported.TabIndex = 29;
            this._cboExported.SelectedIndexChanged += new System.EventHandler(this.cboExportedToSage_SelectedIndexChanged);
            // 
            // _lblExported
            // 
            this._lblExported.Location = new System.Drawing.Point(8, 164);
            this._lblExported.Name = "_lblExported";
            this._lblExported.Size = new System.Drawing.Size(122, 18);
            this._lblExported.TabIndex = 28;
            this._lblExported.Text = "Exported";
            // 
            // _btnFindCustomer
            // 
            this._btnFindCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindCustomer.BackColor = System.Drawing.Color.White;
            this._btnFindCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindCustomer.Location = new System.Drawing.Point(1077, 40);
            this._btnFindCustomer.Name = "_btnFindCustomer";
            this._btnFindCustomer.Size = new System.Drawing.Size(32, 23);
            this._btnFindCustomer.TabIndex = 2;
            this._btnFindCustomer.Text = "...";
            this._btnFindCustomer.UseVisualStyleBackColor = false;
            this._btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
            // 
            // _txtCustomer
            // 
            this._txtCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtCustomer.Location = new System.Drawing.Point(160, 40);
            this._txtCustomer.Name = "_txtCustomer";
            this._txtCustomer.ReadOnly = true;
            this._txtCustomer.Size = new System.Drawing.Size(909, 21);
            this._txtCustomer.TabIndex = 1;
            // 
            // _lblCustomer
            // 
            this._lblCustomer.Location = new System.Drawing.Point(8, 40);
            this._lblCustomer.Name = "_lblCustomer";
            this._lblCustomer.Size = new System.Drawing.Size(64, 16);
            this._lblCustomer.TabIndex = 27;
            this._lblCustomer.Text = "Customer";
            // 
            // _txtPostcode
            // 
            this._txtPostcode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtPostcode.Location = new System.Drawing.Point(160, 88);
            this._txtPostcode.Name = "_txtPostcode";
            this._txtPostcode.Size = new System.Drawing.Size(248, 21);
            this._txtPostcode.TabIndex = 5;
            this._txtPostcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJobNumber_TextChanged);
            // 
            // _lblPostcode
            // 
            this._lblPostcode.Location = new System.Drawing.Point(8, 88);
            this._lblPostcode.Name = "_lblPostcode";
            this._lblPostcode.Size = new System.Drawing.Size(64, 16);
            this._lblPostcode.TabIndex = 20;
            this._lblPostcode.Text = "Postcode";
            // 
            // _btnFindSite
            // 
            this._btnFindSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindSite.BackColor = System.Drawing.Color.White;
            this._btnFindSite.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindSite.Location = new System.Drawing.Point(1077, 64);
            this._btnFindSite.Name = "_btnFindSite";
            this._btnFindSite.Size = new System.Drawing.Size(32, 23);
            this._btnFindSite.TabIndex = 4;
            this._btnFindSite.Text = "...";
            this._btnFindSite.UseVisualStyleBackColor = false;
            this._btnFindSite.Click += new System.EventHandler(this.btnFindSite_Click);
            // 
            // _txtSite
            // 
            this._txtSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSite.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtSite.Location = new System.Drawing.Point(160, 64);
            this._txtSite.Name = "_txtSite";
            this._txtSite.ReadOnly = true;
            this._txtSite.Size = new System.Drawing.Size(909, 21);
            this._txtSite.TabIndex = 3;
            // 
            // _txtJobNumber
            // 
            this._txtJobNumber.Location = new System.Drawing.Point(160, 136);
            this._txtJobNumber.Name = "_txtJobNumber";
            this._txtJobNumber.Size = new System.Drawing.Size(248, 21);
            this._txtJobNumber.TabIndex = 9;
            this._txtJobNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJobNumber_TextChanged);
            // 
            // _lblRefNo
            // 
            this._lblRefNo.Location = new System.Drawing.Point(8, 136);
            this._lblRefNo.Name = "_lblRefNo";
            this._lblRefNo.Size = new System.Drawing.Size(136, 16);
            this._lblRefNo.TabIndex = 6;
            this._lblRefNo.Text = "Job/Order/Contract No";
            // 
            // _lblProperty
            // 
            this._lblProperty.Location = new System.Drawing.Point(8, 64);
            this._lblProperty.Name = "_lblProperty";
            this._lblProperty.Size = new System.Drawing.Size(64, 16);
            this._lblProperty.TabIndex = 2;
            this._lblProperty.Text = "Property";
            // 
            // _lblType
            // 
            this._lblType.Location = new System.Drawing.Point(8, 112);
            this._lblType.Name = "_lblType";
            this._lblType.Size = new System.Drawing.Size(48, 16);
            this._lblType.TabIndex = 4;
            this._lblType.Text = "Type";
            // 
            // _cboType
            // 
            this._cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboType.Location = new System.Drawing.Point(160, 112);
            this._cboType.Name = "_cboType";
            this._cboType.Size = new System.Drawing.Size(248, 21);
            this._cboType.TabIndex = 7;
            // 
            // _lblDateBetween
            // 
            this._lblDateBetween.Location = new System.Drawing.Point(416, 16);
            this._lblDateBetween.Name = "_lblDateBetween";
            this._lblDateBetween.Size = new System.Drawing.Size(48, 16);
            this._lblDateBetween.TabIndex = 14;
            this._lblDateBetween.Text = "and";
            // 
            // _dtpRaisedFrom
            // 
            this._dtpRaisedFrom.Location = new System.Drawing.Point(160, 16);
            this._dtpRaisedFrom.Name = "_dtpRaisedFrom";
            this._dtpRaisedFrom.Size = new System.Drawing.Size(248, 21);
            this._dtpRaisedFrom.TabIndex = 15;
            // 
            // _dtpRaisedTo
            // 
            this._dtpRaisedTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpRaisedTo.Location = new System.Drawing.Point(520, 16);
            this._dtpRaisedTo.Name = "_dtpRaisedTo";
            this._dtpRaisedTo.Size = new System.Drawing.Size(549, 21);
            this._dtpRaisedTo.TabIndex = 16;
            // 
            // _lblDate
            // 
            this._lblDate.Location = new System.Drawing.Point(8, 16);
            this._lblDate.Name = "_lblDate";
            this._lblDate.Size = new System.Drawing.Size(136, 16);
            this._lblDate.TabIndex = 17;
            this._lblDate.Text = "Raised Date Between : ";
            // 
            // _cboStatus
            // 
            this._cboStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboStatus.Location = new System.Drawing.Point(520, 88);
            this._cboStatus.Name = "_cboStatus";
            this._cboStatus.Size = new System.Drawing.Size(549, 21);
            this._cboStatus.TabIndex = 8;
            // 
            // _lblStatus
            // 
            this._lblStatus.Location = new System.Drawing.Point(416, 90);
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(48, 16);
            this._lblStatus.TabIndex = 5;
            this._lblStatus.Text = "Status";
            // 
            // _lblInvoiceNumber
            // 
            this._lblInvoiceNumber.Location = new System.Drawing.Point(416, 114);
            this._lblInvoiceNumber.Name = "_lblInvoiceNumber";
            this._lblInvoiceNumber.Size = new System.Drawing.Size(104, 16);
            this._lblInvoiceNumber.TabIndex = 10;
            this._lblInvoiceNumber.Text = "Invoice Number";
            // 
            // _lblUser
            // 
            this._lblUser.BackColor = System.Drawing.Color.White;
            this._lblUser.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblUser.Location = new System.Drawing.Point(416, 138);
            this._lblUser.Name = "_lblUser";
            this._lblUser.Size = new System.Drawing.Size(40, 16);
            this._lblUser.TabIndex = 12;
            this._lblUser.Text = "User";
            // 
            // _cboUser
            // 
            this._cboUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboUser.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cboUser.ItemHeight = 13;
            this._cboUser.Location = new System.Drawing.Point(520, 136);
            this._cboUser.Name = "_cboUser";
            this._cboUser.Size = new System.Drawing.Size(549, 21);
            this._cboUser.TabIndex = 13;
            // 
            // _txtInvoiceNumber
            // 
            this._txtInvoiceNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtInvoiceNumber.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtInvoiceNumber.Location = new System.Drawing.Point(520, 112);
            this._txtInvoiceNumber.Name = "_txtInvoiceNumber";
            this._txtInvoiceNumber.Size = new System.Drawing.Size(549, 21);
            this._txtInvoiceNumber.TabIndex = 11;
            this._txtInvoiceNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJobNumber_TextChanged);
            // 
            // _chkExportedOn
            // 
            this._chkExportedOn.AutoCheck = false;
            this._chkExportedOn.AutoSize = true;
            this._chkExportedOn.Location = new System.Drawing.Point(520, 166);
            this._chkExportedOn.Name = "_chkExportedOn";
            this._chkExportedOn.Size = new System.Drawing.Size(30, 17);
            this._chkExportedOn.TabIndex = 46;
            this._chkExportedOn.Text = " ";
            this._chkExportedOn.UseVisualStyleBackColor = true;
            this._chkExportedOn.Click += new System.EventHandler(this.chkExportedOn_Click);
            // 
            // _grpInvoices
            // 
            this._grpInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpInvoices.Controls.Add(this._btnSalesCredit);
            this._grpInvoices.Controls.Add(this._btnChange);
            this._grpInvoices.Controls.Add(this._dgInvoices);
            this._grpInvoices.Controls.Add(this._btnSelectAll);
            this._grpInvoices.Controls.Add(this._btnDeselectAll);
            this._grpInvoices.Controls.Add(this._lblInvoicePartPayed);
            this._grpInvoices.Controls.Add(this._lblInvoicePayed);
            this._grpInvoices.Controls.Add(this._lblGreenColour);
            this._grpInvoices.Controls.Add(this._lblGoldColour);
            this._grpInvoices.Controls.Add(this._lblInvoicedNotPayed);
            this._grpInvoices.Controls.Add(this._lblRedColour);
            this._grpInvoices.Location = new System.Drawing.Point(8, 254);
            this._grpInvoices.Name = "_grpInvoices";
            this._grpInvoices.Size = new System.Drawing.Size(1123, 334);
            this._grpInvoices.TabIndex = 23;
            this._grpInvoices.TabStop = false;
            this._grpInvoices.Text = "Double Click To View / Add Payment Information";
            // 
            // _btnSalesCredit
            // 
            this._btnSalesCredit.AccessibleDescription = "";
            this._btnSalesCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSalesCredit.Location = new System.Drawing.Point(827, 24);
            this._btnSalesCredit.Name = "_btnSalesCredit";
            this._btnSalesCredit.Size = new System.Drawing.Size(148, 23);
            this._btnSalesCredit.TabIndex = 35;
            this._btnSalesCredit.Text = "Sales Credit";
            this._btnSalesCredit.Click += new System.EventHandler(this.btnSalesCredit_Click);
            // 
            // _btnChange
            // 
            this._btnChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnChange.Location = new System.Drawing.Point(981, 24);
            this._btnChange.Name = "_btnChange";
            this._btnChange.Size = new System.Drawing.Size(136, 23);
            this._btnChange.TabIndex = 27;
            this._btnChange.Text = "Change";
            this._btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // _dgInvoices
            // 
            this._dgInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgInvoices.DataMember = "";
            this._dgInvoices.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgInvoices.Location = new System.Drawing.Point(8, 72);
            this._dgInvoices.Name = "_dgInvoices";
            this._dgInvoices.Size = new System.Drawing.Size(1109, 252);
            this._dgInvoices.TabIndex = 14;
            this._dgInvoices.DoubleClick += new System.EventHandler(this.dgInvoices_DoubleClick);
            this._dgInvoices.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgInvoices_MouseUp);
            // 
            // _btnSelectAll
            // 
            this._btnSelectAll.AccessibleDescription = "Export Job List To Excel";
            this._btnSelectAll.Location = new System.Drawing.Point(8, 24);
            this._btnSelectAll.Name = "_btnSelectAll";
            this._btnSelectAll.Size = new System.Drawing.Size(88, 23);
            this._btnSelectAll.TabIndex = 19;
            this._btnSelectAll.Text = "Select All";
            this._btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // _btnDeselectAll
            // 
            this._btnDeselectAll.Location = new System.Drawing.Point(104, 24);
            this._btnDeselectAll.Name = "_btnDeselectAll";
            this._btnDeselectAll.Size = new System.Drawing.Size(88, 23);
            this._btnDeselectAll.TabIndex = 20;
            this._btnDeselectAll.Text = "Deselect All";
            this._btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // _lblInvoicePartPayed
            // 
            this._lblInvoicePartPayed.Location = new System.Drawing.Point(259, 52);
            this._lblInvoicePartPayed.Name = "_lblInvoicePartPayed";
            this._lblInvoicePartPayed.Size = new System.Drawing.Size(224, 23);
            this._lblInvoicePartPayed.TabIndex = 26;
            this._lblInvoicePartPayed.Text = "Invoiced - Some Payments Received";
            // 
            // _lblInvoicePayed
            // 
            this._lblInvoicePayed.Location = new System.Drawing.Point(515, 52);
            this._lblInvoicePayed.Name = "_lblInvoicePayed";
            this._lblInvoicePayed.Size = new System.Drawing.Size(120, 23);
            this._lblInvoicePayed.TabIndex = 25;
            this._lblInvoicePayed.Text = "Invoiced and Paid";
            // 
            // _lblGreenColour
            // 
            this._lblGreenColour.BackColor = System.Drawing.Color.LightGreen;
            this._lblGreenColour.Location = new System.Drawing.Point(491, 52);
            this._lblGreenColour.Name = "_lblGreenColour";
            this._lblGreenColour.Size = new System.Drawing.Size(23, 23);
            this._lblGreenColour.TabIndex = 24;
            // 
            // _lblGoldColour
            // 
            this._lblGoldColour.BackColor = System.Drawing.Color.Gold;
            this._lblGoldColour.Location = new System.Drawing.Point(235, 51);
            this._lblGoldColour.Name = "_lblGoldColour";
            this._lblGoldColour.Size = new System.Drawing.Size(23, 23);
            this._lblGoldColour.TabIndex = 23;
            // 
            // _lblInvoicedNotPayed
            // 
            this._lblInvoicedNotPayed.Location = new System.Drawing.Point(35, 52);
            this._lblInvoicedNotPayed.Name = "_lblInvoicedNotPayed";
            this._lblInvoicedNotPayed.Size = new System.Drawing.Size(200, 23);
            this._lblInvoicedNotPayed.TabIndex = 22;
            this._lblInvoicedNotPayed.Text = "Invoiced - No Payments Received";
            // 
            // _lblRedColour
            // 
            this._lblRedColour.BackColor = System.Drawing.Color.Red;
            this._lblRedColour.Location = new System.Drawing.Point(11, 51);
            this._lblRedColour.Name = "_lblRedColour";
            this._lblRedColour.Size = new System.Drawing.Size(23, 23);
            this._lblRedColour.TabIndex = 21;
            // 
            // _btnView
            // 
            this._btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnView.Location = new System.Drawing.Point(561, 594);
            this._btnView.Name = "_btnView";
            this._btnView.Size = new System.Drawing.Size(59, 23);
            this._btnView.TabIndex = 29;
            this._btnView.Text = "View";
            this._btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // _btnMarkAsNotExported
            // 
            this._btnMarkAsNotExported.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnMarkAsNotExported.CausesValidation = false;
            this._btnMarkAsNotExported.Location = new System.Drawing.Point(813, 594);
            this._btnMarkAsNotExported.Name = "_btnMarkAsNotExported";
            this._btnMarkAsNotExported.Size = new System.Drawing.Size(146, 23);
            this._btnMarkAsNotExported.TabIndex = 31;
            this._btnMarkAsNotExported.Text = "Unmark Exports";
            this._btnMarkAsNotExported.UseVisualStyleBackColor = true;
            this._btnMarkAsNotExported.Click += new System.EventHandler(this.btnMarkAsNotExported_Click);
            // 
            // _btnGenVal
            // 
            this._btnGenVal.AccessibleDescription = "";
            this._btnGenVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnGenVal.Location = new System.Drawing.Point(270, 594);
            this._btnGenVal.Name = "_btnGenVal";
            this._btnGenVal.Size = new System.Drawing.Size(125, 23);
            this._btnGenVal.TabIndex = 32;
            this._btnGenVal.Text = "Generate Val";
            this._btnGenVal.Click += new System.EventHandler(this.btnGenNCCVal_Click);
            // 
            // _cmsValType
            // 
            this._cmsValType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsmiNCCVal,
            this._tsmiGenericVal,
            this._tsmiSorVal});
            this._cmsValType.Name = "cmsValType";
            this._cmsValType.Size = new System.Drawing.Size(115, 70);
            // 
            // _tsmiNCCVal
            // 
            this._tsmiNCCVal.Name = "_tsmiNCCVal";
            this._tsmiNCCVal.Size = new System.Drawing.Size(114, 22);
            this._tsmiNCCVal.Text = "NCC";
            this._tsmiNCCVal.Click += new System.EventHandler(this.tsmiNCCVal_Click);
            // 
            // _tsmiGenericVal
            // 
            this._tsmiGenericVal.Name = "_tsmiGenericVal";
            this._tsmiGenericVal.Size = new System.Drawing.Size(114, 22);
            this._tsmiGenericVal.Text = "Generic";
            this._tsmiGenericVal.Click += new System.EventHandler(this.tsmiGenericVal_Click);
            // 
            // _tsmiSorVal
            // 
            this._tsmiSorVal.Name = "_tsmiSorVal";
            this._tsmiSorVal.Size = new System.Drawing.Size(114, 22);
            this._tsmiSorVal.Text = "SOR";
            this._tsmiSorVal.Click += new System.EventHandler(this.tsmiSorVal_Click);
            // 
            // _cmsChange
            // 
            this._cmsChange.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsmiPaymentTerms,
            this._tsmiInvoicedTotal,
            this._tsmiVatRate,
            this._tsmiAccountNumber,
            this._tsmiOrderNo});
            this._cmsChange.Name = "cmsChange";
            this._cmsChange.Size = new System.Drawing.Size(167, 114);
            // 
            // _tsmiPaymentTerms
            // 
            this._tsmiPaymentTerms.Name = "_tsmiPaymentTerms";
            this._tsmiPaymentTerms.Size = new System.Drawing.Size(166, 22);
            this._tsmiPaymentTerms.Text = "Payment Terms";
            this._tsmiPaymentTerms.Click += new System.EventHandler(this.tsmiPaymentTerms_Click);
            // 
            // _tsmiInvoicedTotal
            // 
            this._tsmiInvoicedTotal.Name = "_tsmiInvoicedTotal";
            this._tsmiInvoicedTotal.Size = new System.Drawing.Size(166, 22);
            this._tsmiInvoicedTotal.Text = "Invoiced Total";
            this._tsmiInvoicedTotal.Click += new System.EventHandler(this.tsmiInvoicedTotal_Click);
            // 
            // _tsmiVatRate
            // 
            this._tsmiVatRate.Name = "_tsmiVatRate";
            this._tsmiVatRate.Size = new System.Drawing.Size(166, 22);
            this._tsmiVatRate.Text = "Vat Rate";
            this._tsmiVatRate.Click += new System.EventHandler(this.tsmiVatRate_Click);
            // 
            // _tsmiAccountNumber
            // 
            this._tsmiAccountNumber.Name = "_tsmiAccountNumber";
            this._tsmiAccountNumber.Size = new System.Drawing.Size(166, 22);
            this._tsmiAccountNumber.Text = "Account Number";
            this._tsmiAccountNumber.Click += new System.EventHandler(this.tsmiAccountNumber_Click);
            // 
            // _tsmiOrderNo
            // 
            this._tsmiOrderNo.Name = "_tsmiOrderNo";
            this._tsmiOrderNo.Size = new System.Drawing.Size(166, 22);
            this._tsmiOrderNo.Text = "Order No";
            this._tsmiOrderNo.Click += new System.EventHandler(this.tsmiOrderNo_Click);
            // 
            // _cmsSalesCredit
            // 
            this._cmsSalesCredit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsmiIssue,
            this._tsmiRemove,
            this._tsmiBatchPrint});
            this._cmsSalesCredit.Name = "ContextMenuStrip2";
            this._cmsSalesCredit.Size = new System.Drawing.Size(197, 70);
            // 
            // _tsmiIssue
            // 
            this._tsmiIssue.Name = "_tsmiIssue";
            this._tsmiIssue.Size = new System.Drawing.Size(196, 22);
            this._tsmiIssue.Text = "Issue Sales Credit";
            this._tsmiIssue.Click += new System.EventHandler(this.tsmiIssue_Click);
            // 
            // _tsmiRemove
            // 
            this._tsmiRemove.Name = "_tsmiRemove";
            this._tsmiRemove.Size = new System.Drawing.Size(196, 22);
            this._tsmiRemove.Text = "Remove Sales Credit";
            this._tsmiRemove.Click += new System.EventHandler(this.tsmiRemove_Click);
            // 
            // _tsmiBatchPrint
            // 
            this._tsmiBatchPrint.Name = "_tsmiBatchPrint";
            this._tsmiBatchPrint.Size = new System.Drawing.Size(196, 22);
            this._tsmiBatchPrint.Text = "Batch Print Sales Credit";
            this._tsmiBatchPrint.Click += new System.EventHandler(this.tsmiBatchPrint_Click);
            // 
            // _cmsExportForAccounts
            // 
            this._cmsExportForAccounts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsmiSunExport,
            this._tsmiSageExport});
            this._cmsExportForAccounts.Name = "cmsExportForAccounts";
            this._cmsExportForAccounts.Size = new System.Drawing.Size(152, 48);
            // 
            // _tsmiSunExport
            // 
            this._tsmiSunExport.Name = "_tsmiSunExport";
            this._tsmiSunExport.Size = new System.Drawing.Size(151, 22);
            this._tsmiSunExport.Text = "Export To Sun";
            this._tsmiSunExport.Click += new System.EventHandler(this.tsmiSunExport_Click);
            // 
            // _tsmiSageExport
            // 
            this._tsmiSageExport.Name = "_tsmiSageExport";
            this._tsmiSageExport.Size = new System.Drawing.Size(151, 22);
            this._tsmiSageExport.Text = "Export To Sage";
            this._tsmiSageExport.Click += new System.EventHandler(this.tsmiSageExport_Click);
            // 
            // _btnExportToAccounts
            // 
            this._btnExportToAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnExportToAccounts.Location = new System.Drawing.Point(965, 594);
            this._btnExportToAccounts.Name = "_btnExportToAccounts";
            this._btnExportToAccounts.Size = new System.Drawing.Size(166, 23);
            this._btnExportToAccounts.TabIndex = 35;
            this._btnExportToAccounts.Text = "Export To Accounts";
            this._btnExportToAccounts.Click += new System.EventHandler(this.btnExportToAccounts_Click);
            // 
            // FRMInvoicedManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1137, 626);
            this.Controls.Add(this._btnExportToAccounts);
            this.Controls.Add(this._btnGenVal);
            this.Controls.Add(this._btnMarkAsNotExported);
            this.Controls.Add(this._btnView);
            this.Controls.Add(this._btnPrintOneItemOneInvoice);
            this.Controls.Add(this._btnExport);
            this.Controls.Add(this._grpFilter);
            this.Controls.Add(this._btnReset);
            this.Controls.Add(this._grpInvoices);
            this.Name = "FRMInvoicedManager";
            this.Text = "Invoiced Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpFilter.ResumeLayout(false);
            this._grpFilter.PerformLayout();
            this._grpInvoices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgInvoices)).EndInit();
            this._cmsValType.ResumeLayout(false);
            this._cmsChange.ResumeLayout(false);
            this._cmsSalesCredit.ResumeLayout(false);
            this._cmsExportForAccounts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupInvoiceDataGrid();
            ResetFilters();
            try
            {
                if (get_GetParameter(0) is object)
                {
                    InvoicesDataview = (DataView)get_GetParameter(0);
                    ((IBaseForm)this).SetFormParameters = null;
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private DataView _dvInvoices;

        private DataView InvoicesDataview
        {
            get
            {
                return _dvInvoices;
            }

            set
            {
                _dvInvoices = value;
                _dvInvoices.AllowNew = false;
                _dvInvoices.AllowEdit = true;
                _dvInvoices.AllowDelete = false;
                _dvInvoices.Table.TableName = Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString();
                dgInvoices.DataSource = InvoicesDataview;
            }
        }

        private DataRow SelectedInvoiceDataRow
        {
            get
            {
                if (!(dgInvoices.CurrentRowIndex == -1))
                {
                    return InvoicesDataview[dgInvoices.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private Entity.Customers.Customer _theCustomer;

        public Entity.Customers.Customer theCustomer
        {
            get
            {
                return _theCustomer;
            }

            set
            {
                _theCustomer = value;
                theSite = null;
                if (_theCustomer is object)
                {
                    txtCustomer.Text = theCustomer.Name + " (A/C No : " + theCustomer.AccountNumber + ")";
                }
                else
                {
                    txtCustomer.Text = "";
                }
            }
        }

        private Entity.Sites.Site _oSite;

        public Entity.Sites.Site theSite
        {
            get
            {
                return _oSite;
            }

            set
            {
                _oSite = value;
                if (_oSite is object)
                {
                    txtSite.Text = theSite.Address1 + ", " + theSite.Address2 + ", " + theSite.Postcode;
                }
                else
                {
                    txtSite.Text = "";
                }
            }
        }

        private ArrayList _invoicesToPrint = new ArrayList();

        private ArrayList InvoicesToPrint
        {
            get
            {
                return _invoicesToPrint;
            }

            set
            {
                _invoicesToPrint = value;
            }
        }

        private bool _IsLoading = true;

        private bool IsLoading
        {
            get
            {
                return _IsLoading;
            }

            set
            {
                _IsLoading = value;
            }
        }

        private void SetupInvoiceDataGrid()
        {
            Helper.SetUpDataGrid(dgInvoices);
            var tbStyle = dgInvoices.TableStyles[0];
            tbStyle.GridColumnStyles.Clear();
            // tbStyle.AllowSorting = False

            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tbStyle.GridColumnStyles.Add(Tick);
            var PaidStatus = new PaidStatusColourColumn();
            PaidStatus.Format = "";
            PaidStatus.FormatInfo = null;
            PaidStatus.HeaderText = "Paid";
            PaidStatus.MappingName = "PaidStatus";
            PaidStatus.ReadOnly = true;
            PaidStatus.Width = 30;
            PaidStatus.NullText = "";
            tbStyle.GridColumnStyles.Add(PaidStatus);
            var Customer = new DataGridLabelColumn();
            Customer.Format = "";
            Customer.FormatInfo = null;
            Customer.HeaderText = "Customer";
            Customer.MappingName = "Customer";
            Customer.ReadOnly = true;
            Customer.Width = 75;
            Customer.NullText = "";
            tbStyle.GridColumnStyles.Add(Customer);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Property";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 75;
            Site.NullText = "";
            tbStyle.GridColumnStyles.Add(Site);
            var InvoiceType = new DataGridLabelColumn();
            InvoiceType.Format = "";
            InvoiceType.FormatInfo = null;
            InvoiceType.HeaderText = "Inv. Type";
            InvoiceType.MappingName = "InvoiceType";
            InvoiceType.ReadOnly = true;
            InvoiceType.Width = 75;
            InvoiceType.NullText = "";
            tbStyle.GridColumnStyles.Add(InvoiceType);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job/Ord/Con No.";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 85;
            JobNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(JobNumber);
            var InvoiceAddressType = new DataGridLabelColumn();
            InvoiceAddressType.Format = "";
            InvoiceAddressType.FormatInfo = null;
            InvoiceAddressType.HeaderText = "Inv. Addr. Type";
            InvoiceAddressType.MappingName = "InvoiceAddressType";
            InvoiceAddressType.ReadOnly = true;
            InvoiceAddressType.Width = 75;
            InvoiceAddressType.NullText = "";
            tbStyle.GridColumnStyles.Add(InvoiceAddressType);
            var InvoiceAddress = new DataGridLabelColumn();
            InvoiceAddress.Format = "";
            InvoiceAddress.FormatInfo = null;
            InvoiceAddress.HeaderText = "Invoice Add.";
            InvoiceAddress.MappingName = "InvoiceAddress";
            InvoiceAddress.ReadOnly = true;
            InvoiceAddress.Width = 75;
            InvoiceAddress.NullText = "";
            tbStyle.GridColumnStyles.Add(InvoiceAddress);
            var Amount = new DataGridLabelColumn();
            Amount.Format = "C";
            Amount.FormatInfo = null;
            Amount.HeaderText = "Amount";
            Amount.MappingName = "Amount";
            Amount.ReadOnly = true;
            Amount.Width = 75;
            Amount.NullText = "";
            tbStyle.GridColumnStyles.Add(Amount);
            var VATRate = new DataGridLabelColumn();
            VATRate.Format = "";
            VATRate.FormatInfo = null;
            VATRate.HeaderText = "VAT Rate";
            VATRate.MappingName = "VATRate";
            VATRate.ReadOnly = true;
            VATRate.Width = 75;
            VATRate.NullText = "";
            tbStyle.GridColumnStyles.Add(VATRate);
            var InvoiceNumber = new DataGridLabelColumn();
            InvoiceNumber.Format = "C";
            InvoiceNumber.FormatInfo = null;
            InvoiceNumber.HeaderText = "Invoice No";
            InvoiceNumber.MappingName = "InvoiceNumber";
            InvoiceNumber.ReadOnly = true;
            InvoiceNumber.Width = 75;
            InvoiceNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(InvoiceNumber);
            var RaisedOn = new DataGridLabelColumn();
            RaisedOn.Format = "dd/MM/yyyy";
            RaisedOn.FormatInfo = null;
            RaisedOn.HeaderText = "Raised On";
            RaisedOn.MappingName = "RaisedDate";
            RaisedOn.ReadOnly = true;
            RaisedOn.Width = 75;
            RaisedOn.NullText = "";
            tbStyle.GridColumnStyles.Add(RaisedOn);
            var RaisedBy = new DataGridLabelColumn();
            RaisedBy.Format = "";
            RaisedBy.FormatInfo = null;
            RaisedBy.HeaderText = "Raised By";
            RaisedBy.MappingName = "Fullname";
            RaisedBy.ReadOnly = true;
            RaisedBy.Width = 75;
            RaisedBy.NullText = "";
            tbStyle.GridColumnStyles.Add(RaisedBy);
            var DateExportedToSage = new DataGridLabelColumn();
            DateExportedToSage.Format = "dd/MM/yyyy";
            DateExportedToSage.FormatInfo = null;
            DateExportedToSage.HeaderText = "Exported";
            DateExportedToSage.MappingName = "DateExportedToSage";
            DateExportedToSage.ReadOnly = true;
            DateExportedToSage.Width = 105;
            DateExportedToSage.NullText = "";
            tbStyle.GridColumnStyles.Add(DateExportedToSage);
            var SupplierInvoiceID = new DataGridLabelColumn();
            SupplierInvoiceID.Format = "";
            SupplierInvoiceID.FormatInfo = null;
            SupplierInvoiceID.HeaderText = "Supplier Invoice ID";
            SupplierInvoiceID.MappingName = "SupplierInvoiceID";
            SupplierInvoiceID.ReadOnly = true;
            SupplierInvoiceID.Width = 105;
            SupplierInvoiceID.NullText = "";
            tbStyle.GridColumnStyles.Add(SupplierInvoiceID);
            var CreditAmount = new DataGridLabelColumn();
            CreditAmount.Format = "C";
            CreditAmount.FormatInfo = null;
            CreditAmount.HeaderText = "Credited Amount";
            CreditAmount.MappingName = "CreditAmount";
            CreditAmount.ReadOnly = true;
            CreditAmount.Width = 80;
            CreditAmount.NullText = "";
            tbStyle.GridColumnStyles.Add(CreditAmount);
            var PaymentTerm = new DataGridLabelColumn();
            PaymentTerm.Format = "";
            PaymentTerm.FormatInfo = null;
            PaymentTerm.HeaderText = "Payment Term";
            PaymentTerm.MappingName = "PaymentTerm";
            PaymentTerm.ReadOnly = true;
            PaymentTerm.Width = 120;
            PaymentTerm.NullText = "";
            tbStyle.GridColumnStyles.Add(PaymentTerm);
            var PaymentBy = new DataGridLabelColumn();
            PaymentBy.Format = "";
            PaymentBy.FormatInfo = null;
            PaymentBy.HeaderText = "Payment by";
            PaymentBy.MappingName = "PaymentBy";
            PaymentBy.ReadOnly = true;
            PaymentBy.Width = 100;
            PaymentBy.NullText = "";
            tbStyle.GridColumnStyles.Add(PaymentBy);
            var AccountNumber = new DataGridLabelColumn();
            AccountNumber.Format = "";
            AccountNumber.FormatInfo = null;
            AccountNumber.HeaderText = "Acc Number";
            AccountNumber.MappingName = "AccountNumber";
            AccountNumber.ReadOnly = true;
            AccountNumber.Width = 100;
            AccountNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(AccountNumber);
            var orderNo = new DataGridEditableTextBoxColumn();
            orderNo.Format = "";
            orderNo.FormatInfo = null;
            orderNo.HeaderText = "Order No";
            orderNo.MappingName = "OrderNo";
            orderNo.ReadOnly = false;
            orderNo.Width = 100;
            orderNo.NullText = "";
            tbStyle.GridColumnStyles.Add(orderNo);
            tbStyle.ReadOnly = false;
            dgInvoices.ReadOnly = false;
            tbStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString();
            dgInvoices.TableStyles.Add(tbStyle);
        }

        private void FRMInvoicedManager_Load(object sender, EventArgs e)
        {
            IsLoading = true;
            LoadMe(sender, e);
            IsLoading = false;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            view();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblCustomer));
            if (!(ID == 0))
            {
                theCustomer = App.DB.Customer.Customer_Get(ID);
            }
        }

        private void btnFindSite_Click(object sender, EventArgs e)
        {
            int ID;
            if (theCustomer is null)
            {
                ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite));
            }
            else
            {
                ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite, theCustomer.CustomerID));
            }

            if (!(ID == 0))
            {
                theSite = App.DB.Sites.Get(ID);
            }
        }

        private void dgInvoices_MouseUp(object sender, MouseEventArgs e)
        {
            DataGrid.HitTestInfo HitTestInfo;
            HitTestInfo = dgInvoices.HitTest(e.X, e.Y);
            if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
            {
                if (HitTestInfo.Column == 0)
                {
                    bool selected = !Helper.MakeBooleanValid(SelectedInvoiceDataRow["tick"]);
                    SelectedInvoiceDataRow["Tick"] = selected;
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int itm = 0, loopTo = ((DataView)dgInvoices.DataSource).Count - 1; itm <= loopTo; itm++)
            {
                dgInvoices.CurrentRowIndex = itm;
                SelectedInvoiceDataRow["tick"] = 1;
            }
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            for (int itm = 0, loopTo = ((DataView)dgInvoices.DataSource).Count - 1; itm <= loopTo; itm++)
            {
                dgInvoices.CurrentRowIndex = itm;
                SelectedInvoiceDataRow["tick"] = 0;
            }
        }

        private void btnPrintOneItemOneInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Check_Supplier_Invoices_And_Continue())
                {
                    return;
                }

                FindPartPayJobs(false);
                var drTicked = (from sf in InvoicesDataview.Table.AsEnumerable()
                                where sf.Field<bool>("Tick") == true
                                select sf).ToArray();
                foreach (DataRow i in drTicked)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(i["InvoiceType"], "Sales Credit", false)))  // its a credit
                    {
                        int amountOfCreditsForInvoice = (from sf in InvoicesDataview.Table.AsEnumerable()
                                                         where (sf.Field<string>("InvoiceType") ?? "") == "Sales Credit" & Operators.ConditionalCompareObjectEqual(sf.Field<string>("InvoiceNumber"), i["InvoiceNumber"], false)
                                                         select sf).Count();
                        DataTable credit = null;
                        DialogResult result = default;
                        if (amountOfCreditsForInvoice > 1)
                        {
                            string message = Conversions.ToString("Invoice No: " + i["InvoiceNumber"] + " has more than one credit." + Constants.vbCrLf + Constants.vbCrLf + "Do you want merge them together?");
                            result = App.ShowMessage(message, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }

                        if (result != default && result == DialogResult.Yes)
                        {
                            credit = App.DB.SalesCredit.InvoicedLines_GetAll_ByInvoicedNumber(Conversions.ToString(i["InvoiceNumber"])).Table;
                        }
                        else
                        {
                            credit = App.DB.SalesCredit.InvoicedLines_GetAll_ByCreditReference(Conversions.ToString(i["JobNumber"])).Table;
                        }

                        credit.Columns.Add("SalesCreditID");
                        credit.Rows[0]["SalesCreditID"] = i["LinkID"];
                        credit.Columns.Add("CreditReference");
                        credit.Rows[0]["CreditReference"] = i["JobNumber"];
                        var oPrint = new Printing(credit, "Sales Credit", Enums.SystemDocumentType.SalesCredit);
                    }
                    else if (Helper.MakeIntegerValid(i["invoicedID"]) == 0)  // normal
                    {
                        var inv = new Entity.Invoiceds.Invoiced();
                        // AMY IS CHEATING AND USING JOB NUMBER - 5 isn't a job definition!
                        var invNum = new JobNumber();
                        invNum = App.DB.Job.GetNextJobNumber((Enums.JobDefinition)5);
                        inv.SetInvoiceNumber = invNum.Prefix + invNum.Number;
                        inv.SetRaisedByUserID = App.loggedInUser.UserID;
                        inv.RaisedDate = DateAndTime.Now;
                        inv = App.DB.Invoiced.Insert(inv);
                        var invLines = new Entity.InvoicedLiness.InvoicedLines();
                        invLines.SetAmount = Helper.MakeDoubleValid(i["Amount"]);
                        invLines.SetInvoicedID = inv.InvoicedID;
                        invLines.SetInvoiceToBeRaisedID = i["InvoiceToBeRaisedID"];
                        invLines = App.DB.InvoicedLines.Insert(invLines);
                        var PrintArray = new ArrayList();
                        PrintArray.Add(i["InvoicedID"]);
                        PrintArray.Add(i["RegionID"]);
                        InvoicesToPrint.Add(PrintArray);
                    }
                    else
                    {
                        bool exists = false;
                        foreach (ArrayList al in InvoicesToPrint)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(al[0], i["InvoicedID"], false))) // check if the invoice id is already in....
                            {
                                exists = true;
                            }
                        }

                        if (exists == false) // if not add it.
                        {
                            var PrintArray = new ArrayList();
                            PrintArray.Add(i["InvoicedID"]);
                            PrintArray.Add(i["RegionID"]);
                            InvoicesToPrint.Add(PrintArray);
                        }
                    }
                }

                Print();
                PopulateDatagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPrintManyItemsOnOneInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Check_Supplier_Invoices_And_Continue())
                {
                    return;
                }

                FindPartPayJobs(true);
                var dtDone = new DataTable();
                dtDone.Columns.Add("AddressTypeID");
                dtDone.Columns.Add("AddressID");
                foreach (DataRow i in InvoicesDataview.Table.Rows)
                {
                    if (Helper.MakeBooleanValid(i["tick"]) == true)
                    {
                        if (Helper.MakeIntegerValid(i["invoicedID"]) == 0)
                        {
                            if (dtDone.Select(Conversions.ToString(Conversions.ToString("AddressTypeID=" + i["AddressTypeID"] + " AND AddressID=") + i["AddressID"])).Length == 0)
                            {
                                var drInv = InvoicesDataview.Table.Select(Conversions.ToString(Conversions.ToString("AddressTypeID=" + i["AddressTypeID"] + " AND AddressID=") + i["AddressID"] + " AND Tick = 1"));
                                var inv = new Entity.Invoiceds.Invoiced();
                                var invNum = new JobNumber();
                                invNum = App.DB.Job.GetNextJobNumber((Enums.JobDefinition)5);
                                inv.SetInvoiceNumber = invNum.Prefix + invNum.Number;
                                inv.SetRaisedByUserID = App.loggedInUser.UserID;
                                inv.RaisedDate = DateAndTime.Now;
                                inv = App.DB.Invoiced.Insert(inv);
                                for (int j = 0, loopTo = drInv.Length - 1; j <= loopTo; j++)
                                {
                                    var invLines = new Entity.InvoicedLiness.InvoicedLines();
                                    invLines.SetAmount = Helper.MakeDoubleValid(drInv[j]["Amount"]);
                                    invLines.SetInvoicedID = inv.InvoicedID;
                                    invLines.SetInvoiceToBeRaisedID = drInv[j]["InvoiceToBeRaisedID"];
                                    invLines = App.DB.InvoicedLines.Insert(invLines);
                                }

                                InvoicesToPrint.Add(inv.InvoicedID);
                                DataRow r;
                                r = dtDone.NewRow();
                                r["AddressTypeID"] = i["AddressTypeID"];
                                r["AddressID"] = i["AddressID"];
                                dtDone.Rows.Add(r);
                            }
                        }
                        else if (!InvoicesToPrint.Contains(i["invoicedID"]))
                        {
                            InvoicesToPrint.Add(Helper.MakeIntegerValid(i["invoicedID"]));
                        }
                    }
                }

                Print();
                PopulateDatagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgInvoices_DoubleClick(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
            }

            if (SelectedInvoiceDataRow is object)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedInvoiceDataRow["InvoiceType"], "Supplier", false) | Operators.ConditionalCompareObjectEqual(SelectedInvoiceDataRow["InvoiceType"], "Consolidation", false)))
                {
                    App.ShowMessage("Payments cannot be managed for a supplier invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!(Helper.MakeIntegerValid(SelectedInvoiceDataRow["InvoicedID"]) == 0))
                {
                    {
                        var withBlock = SelectedInvoiceDataRow;
                        App.ShowForm(typeof(FrmInvoicedPayment), true, new object[] { withBlock["InvoicedID"], withBlock["Customer"], withBlock["InvoiceAddress"], withBlock["InvoiceNumber"], withBlock["RaisedDate"], withBlock["Fullname"], withBlock["EngineerVisitID"], withBlock["VATRate"], this });
                    }
                }
                else
                {
                    App.ShowMessage("An Invoice must be generated before payments can be applied for or received", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (SelectedInvoiceDataRow is object)
            {
                foreach (DataRow r in InvoicesDataview.Table.Rows)
                {
                    if (Conversions.ToBoolean(r["tick"]))
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Sales Credit", false))) // It was possible to use the change button and it would somehow change the original invoice of the credit so i stopped this.
                        {
                            App.ShowMessage("You can not change credits", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }
            }

            cmsChange.Show(btnChange, new Point(0, 0));
        }

        private void tsmiPaymentTerms_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
            }

            if (SelectedInvoiceDataRow is object)
            {
                // POP UP FORM
                FRMChangePaymentTerms fCIT = (FRMChangePaymentTerms)App.ShowForm(typeof(FRMChangePaymentTerms), true, new object[] { SelectedInvoiceDataRow["InvoicedID"], SelectedInvoiceDataRow["Amount"] });
                if (fCIT.DialogResult == DialogResult.OK)
                {
                    SelectedInvoiceDataRow["PaymentTerm"] = Combo.get_GetSelectedItemDescription(fCIT.cboPaymentTerm);
                    if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(fCIT.cboPaymentTerm)) == 69491)
                    {
                        SelectedInvoiceDataRow["PaymentBy"] = Combo.get_GetSelectedItemDescription(fCIT.cboPaidBy);
                    }
                    else
                    {
                        SelectedInvoiceDataRow["PaymentBy"] = "";
                    }
                }
            }
        }

        private void tsmiInvoicedTotal_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
            }

            if (SelectedInvoiceDataRow is object)
            {
                // POP UP FORM
                if (Conversions.ToBoolean(SelectedInvoiceDataRow["ExportedToSage"]) == false)
                {
                    FRMChangeInvoicedTotal fCIT = (FRMChangeInvoicedTotal)App.ShowForm(typeof(FRMChangeInvoicedTotal), true, new object[] { SelectedInvoiceDataRow["InvoicedLineID"], SelectedInvoiceDataRow["Amount"], SelectedInvoiceDataRow["AccountNumber"], SelectedInvoiceDataRow["Department"], SelectedInvoiceDataRow["NominalCode"], SelectedInvoiceDataRow["RaisedDate"], SelectedInvoiceDataRow["InvoiceTypeID"] });
                    if (fCIT.DialogResult == DialogResult.OK)
                    {
                        SelectedInvoiceDataRow["Amount"] = fCIT.txtInvoicedTotal.Text;
                        SelectedInvoiceDataRow["AccountNumber"] = fCIT.txtAccount.Text;
                        SelectedInvoiceDataRow["Department"] = fCIT.txtDept.Text;
                        SelectedInvoiceDataRow["NominalCode"] = fCIT.txtNominal.Text;
                        SelectedInvoiceDataRow["RaisedDate"] = fCIT.dtpTaxDate.Value;
                    }
                }
                else
                {
                    App.ShowMessage("This invoice has already been exported", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsmiVatRate_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
            }

            if (SelectedInvoiceDataRow is null)
            {
                return;
            }

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedInvoiceDataRow["InvoiceType"], "Supplier", false) | Operators.ConditionalCompareObjectEqual(SelectedInvoiceDataRow["InvoiceType"], "Consolidation", false)))
            {
                App.ShowMessage("VAT Rate cannot be changed for a supplier invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var f = new FRMChangeVAT(Conversions.ToInteger(SelectedInvoiceDataRow["VATRateID"]), Conversions.ToInteger(SelectedInvoiceDataRow["InvoicedID"]), Conversions.ToString(SelectedInvoiceDataRow["InvoiceNumber"])))
            {
                f.ShowDialog();
            }

            PopulateDatagrid();
        }

        private void btnSalesCredit_Click(object sender, EventArgs e)
        {
            cmsSalesCredit.Show(btnSalesCredit, new Point(0, 0));
        }

        private void tsmiAccountNumber_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
            }

            if (SelectedInvoiceDataRow is null)
                return;
            var f = new FRMGenDropBox();
            f.cbo2.Items.Clear();
            f.cbo1.Visible = false;
            f.cbo2.Visible = false;
            f.lblTop.Visible = false;
            f.lblMiddle.Visible = false;
            f.lblref.Text = "Account Number";
            f.txtref.Visible = true;
            f.ShowDialog();
            f.btnOK.Text = "Save";
            if (f.DialogResult == DialogResult.Cancel)
            {
                return;
            }

            var EngVisitCharge = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get(Conversions.ToInteger(SelectedInvoiceDataRow["EngineerVisitID"]));
            EngVisitCharge.SetForSageAccountCode = f.txtref.Text.Trim();
            App.DB.EngineerVisitCharge.EngineerVisitCharge_Update(EngVisitCharge);
            SelectedInvoiceDataRow["AccountNumber"] = f.txtref.Text.Trim();
        }

        private void tsmiIssue_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
            }

            if (InvoicesDataview is object)
            {
                var r = InvoicesDataview.Table.Select("tick = 1");
                int customerID = 0;
                foreach (DataRow i in r)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r[0]["InvoiceType"], "Sales Credit", false)))
                    {
                        App.ShowMessage("Credits cannot be raised on credit records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (Helper.MakeDoubleValid(i["CreditAmount"]) >= Helper.MakeDoubleValid(i["Amount"]))
                    {
                        App.ShowMessage("Credit Amount cannot be greater than Invoice Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (Conversions.ToBoolean(customerID == 0 | Operators.ConditionalCompareObjectEqual(customerID, i["CustomerID"], false)))
                    {
                        customerID = Conversions.ToInteger(i["customerID"]);
                    }
                    else
                    {
                        App.ShowMessage("Grouped credits must be against one customer only", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (r.Length > 0)
                {
                    using (var f = new FRMSalesCredit(r, false, true))
                    {
                        f.ShowDialog();
                    }

                    PopulateDatagrid();
                }
            }
        }

        private void tsmiRemove_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
            }

            int @ref = 0;
            if (SelectedInvoiceDataRow is object)
            {
                foreach (DataRow r in InvoicesDataview.Table.Rows)
                {
                    if (Conversions.ToBoolean(r["tick"]))
                    {
                        if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Sales Credit", false)))
                        {
                            App.ShowMessage("You Can only delete credits", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        if (@ref == 0 | @ref == Helper.MakeIntegerValid(r["LinkID"]))
                        {
                            @ref = Helper.MakeIntegerValid(r["LinkID"]);
                        }
                        else
                        {
                            App.ShowMessage("You Can not delete more than one group of credits at once", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        if (@ref != 0)
                        {
                            App.DB.ClearParameter(); // cause we are doing this in the wrong place
                            var dt = App.DB.ExecuteWithReturn("Select CreditReference , DateExportedToSage, InvoicedLineID from tblSalesCredit where SalesCreditID = " + @ref);
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (Information.IsDBNull(dr["DateExportedToSage"]) == false)
                                {
                                    App.ShowMessage("One or more Credits have already been exported, cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                            }

                            foreach (DataRow dr2 in dt.Rows)
                                App.DB.ExecuteScalar(Conversions.ToString("Delete tblInvoicedLinesCredit where invoicedLineID = " + dr2["InvoicedLineID"]));
                            App.DB.ExecuteScalar("Delete tblSalesCredit Where SalesCreditID = " + @ref);
                            @ref = 0;
                        }
                    }
                }

                PopulateDatagrid();
            }
        }

        private void tsmiBatchPrint_Click(object sender, EventArgs e)
        {
            if (InvoicesDataview is object)
            {
                var dr = (from sf in InvoicesDataview.Table.AsEnumerable()
                          where sf.Field<bool>("Tick") == true & (sf.Field<string>("InvoiceType") ?? "") == "Sales Credit"
                          select sf).ToArray();
                if (dr.Count() < 1)
                {
                    App.ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var dtCredit = new DataTable();
                dtCredit = dr.CopyToDataTable();
                var oPrint = new Printing(dtCredit, "Sales Credit", Enums.SystemDocumentType.SalesCredit, true);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateDatagrid();
        }

        private void btnGenNCCVal_Click(object sender, EventArgs e)
        {
            cmsValType.Show(btnGenVal, new Point(0, 0));
        }

        private void tsmiNCCVal_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var invoicedIds = (from x in InvoicesDataview.Table.AsEnumerable()
                                   where x.Field<bool>("Tick") == true
                                   select x.Field<int>("InvoicedID")).Distinct().ToList();
                if (invoicedIds.Count == 0)
                {
                    App.ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var exportData = new DataTable();
                exportData.Columns.Add("ValNo");
                exportData.Columns.Add("UPRN");
                exportData.Columns.Add("JOB");
                exportData.Columns.Add("ActualCompDate", typeof(DateTime));
                exportData.Columns.Add("Invoice");
                exportData.Columns.Add("Address");
                exportData.Columns.Add("Code");
                exportData.Columns.Add("SORDescription");
                exportData.Columns.Add("Plant");
                exportData.Columns.Add("Materials", typeof(double));
                exportData.Columns.Add("SubContractor", typeof(double));
                exportData.Columns.Add("Labour", typeof(double));
                exportData.Columns.Add("SORCost", typeof(double));
                exportData.Columns.Add("MarginOnMaterials", typeof(double));
                exportData.Columns.Add("MarginOnSubCon", typeof(double));
                exportData.Columns.Add("Total", typeof(double));
                exportData.Columns.Add("VAT", typeof(double));
                exportData.Columns.Add("GrandTotal", typeof(double));
                exportData.Columns.Add("Recharge");
                exportData.Columns.Add("HPSOfficer");
                foreach (int invoicedId in invoicedIds)
                {
                    var visits = App.DB.Invoiced.NCCValuation(invoicedId);
                    foreach (DataRow dr in visits.Table.Rows)
                    {
                        DataRow newRw;
                        newRw = exportData.NewRow();
                        newRw["ValNo"] = dr["ValNum"];
                        newRw["UPRN"] = dr["UPRN"];
                        newRw["JOB"] = dr["JOB"];
                        newRw["ActualCompDate"] = dr["ActualCompletion"];
                        newRw["Invoice"] = dr["InvoiceNumber"];
                        newRw["Address"] = dr["Address1"];
                        newRw["Code"] = dr["CODE"];
                        newRw["SORDescription"] = dr["Description"];
                        newRw["Plant"] = dr["Plant"];
                        newRw["Materials"] = dr["Material"];
                        newRw["SubContractor"] = dr["SubContractor"];
                        newRw["Labour"] = dr["labour"];
                        newRw["SORCost"] = dr["SORCost"];
                        newRw["MarginOnMaterials"] = dr["MatMark"];
                        newRw["MarginOnSubCon"] = dr["SubConMark"];
                        newRw["Total"] = dr["Total"];
                        newRw["VAT"] = dr["VAT"];
                        newRw["GrandTotal"] = dr["GrandTotal"];
                        newRw["Recharge"] = dr["Recharge"];
                        newRw["HPSOfficer"] = dr["HpsOfficer"];
                        exportData.Rows.Add(newRw);
                    }
                }

                ExportHelper.Export(exportData, "NCC Valuation", Enums.ExportType.XLS);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error generating document!" + Constants.vbCrLf + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void tsmiSorVal_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (InvoicesDataview is object)
                {
                    var drInvoices = (from sf in InvoicesDataview.Table.AsEnumerable()
                                      where sf.Field<bool>("Tick") == true
                                      select sf).ToArray();
                    if (drInvoices.Count() < 1)
                    {
                        App.ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var dtValData = new DataTable();
                    dtValData.Columns.Add("UPRN", typeof(string));
                    dtValData.Columns.Add("Client Ref", typeof(string));
                    dtValData.Columns.Add("Gasway Job Number", typeof(string));
                    dtValData.Columns.Add("Completion Date", typeof(DateTime));
                    dtValData.Columns.Add("Invoice Number", typeof(string));
                    dtValData.Columns.Add("Address", typeof(string));
                    dtValData.Columns.Add("Invoice Description", typeof(string));
                    dtValData.Columns.Add("SOR Code", typeof(string));
                    dtValData.Columns.Add("SOR Description", typeof(string));
                    dtValData.Columns.Add("SOR Price", typeof(string));
                    dtValData.Columns.Add("SOR Qty", typeof(int));
                    dtValData.Columns.Add("SOR Total", typeof(string));
                    try
                    {
                        foreach (DataRow drInvoice in drInvoices)
                        {
                            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(drInvoice["InvoiceType"], "Visit", false)))
                                continue;
                            if (drInvoice["AccountNumber"].ToString().Contains("IBC"))
                                continue;
                            int engineerVisitId = Helper.MakeIntegerValid(drInvoice["EngineerVisitID"]);
                            var dvEngVisit = App.DB.EngineerVisits.EngineerVisits_Get_ForVal(engineerVisitId);
                            if (dvEngVisit.Count < 1)
                                continue;
                            var dvSorBreakdown = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get_SorBreakdownForVal(engineerVisitId);
                            foreach (DataRowView drSor in dvSorBreakdown)
                            {
                                DataRow newRw;
                                newRw = dtValData.NewRow();
                                newRw["UPRN"] = Helper.MakeStringValid(dvEngVisit[0]["UPRN"]);
                                newRw["Address"] = Helper.MakeStringValid(dvEngVisit[0]["Site"]);
                                newRw["Gasway Job Number"] = Helper.MakeStringValid(dvEngVisit[0]["JobNumber"]);
                                newRw["Completion Date"] = Helper.MakeDateTimeValid(dvEngVisit[0]["CompletedDateTime"]);
                                newRw["Client Ref"] = Helper.MakeStringValid(dvEngVisit[0]["ClientRef"]);
                                newRw["Invoice Number"] = Helper.MakeStringValid(drInvoice["InvoiceNumber"]);
                                newRw["Invoice Description"] = Helper.MakeStringValid(dvEngVisit[0]["InvoiceNotes"]);
                                newRw["SOR Code"] = drSor["Code"];
                                newRw["SOR Description"] = drSor["Description"];
                                newRw["SOR Price"] = Helper.MakeDoubleValid(drSor["Cost"]).ToString("c");
                                newRw["SOR Qty"] = Helper.MakeIntegerValid(drSor["Quantity"]);
                                newRw["SOR Total"] = Helper.MakeDoubleValid(drSor["Charge"]).ToString("c");
                                dtValData.Rows.Add(newRw);
                            }
                        }

                        ExportHelper.Export(dtValData, "Valuation", Enums.ExportType.XLS);
                    }
                    catch (Exception ex)
                    {
                        App.ShowMessage("Error generating document!" + Constants.vbCrLf + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Cursor = Cursors.Default;
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error generating document!" + Constants.vbCrLf + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void tsmiGenericVal_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (InvoicesDataview is object)
                {
                    var dr = (from sf in InvoicesDataview.Table.AsEnumerable()
                              where sf.Field<bool>("Tick") == true
                              select sf).ToArray();
                    if (dr.Count() < 1)
                    {
                        App.ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var exportData = new DataTable();
                    exportData.Columns.Add("UPRN", typeof(string));
                    exportData.Columns.Add("Client Ref", typeof(string));
                    exportData.Columns.Add("Gasway Job Number", typeof(string));
                    exportData.Columns.Add("Completion Date", typeof(DateTime));
                    exportData.Columns.Add("Invoice Number", typeof(string));
                    exportData.Columns.Add("Address", typeof(string));
                    exportData.Columns.Add("Invoice Description", typeof(string));
                    exportData.Columns.Add("SOR Description", typeof(string));
                    exportData.Columns.Add("SOR Cost", typeof(decimal));
                    exportData.Columns.Add("Labour Cost", typeof(decimal));
                    exportData.Columns.Add("Parts Cost", typeof(decimal));
                    exportData.Columns.Add("Additional Cost", typeof(decimal));
                    exportData.Columns.Add("Total ex VAT", typeof(double));
                    exportData.Columns.Add("VAT", typeof(double));
                    exportData.Columns.Add("Total", typeof(double));
                    try
                    {
                        foreach (DataRow r in dr)
                        {
                            // if anything other than visit then we cannot add to val
                            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Visit", false)))
                                continue;
                            if (r["AccountNumber"].ToString().Contains("IBC"))
                                continue;
                            int engVisitId = Helper.MakeIntegerValid(r["EngineerVisitID"]);

                            // get visit info
                            var dvEngVisit = App.DB.EngineerVisits.EngineerVisits_Get_ForVal(engVisitId);
                            if (dvEngVisit.Count < 1)
                                continue;

                            // get visitcharge info
                            var dvChargeBreakdown = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get_ChargedBreakDown(engVisitId);

                            // get totals for different areas
                            decimal PARTSTotal = dvChargeBreakdown.Table.AsEnumerable().Where(row => (row.Field<string>("Type") ?? "") == "PARTS").Sum(row => row.Field<decimal>("Charge"));
                            decimal SORTotal = dvChargeBreakdown.Table.AsEnumerable().Where(row => (row.Field<string>("Type") ?? "") == "SOR").Sum(row => row.Field<decimal>("Charge"));
                            decimal LABOURTotal = dvChargeBreakdown.Table.AsEnumerable().Where(row => (row.Field<string>("Type") ?? "") == "LABOUR").Sum(row => row.Field<decimal>("Charge"));
                            decimal ADDITIONALTotal = dvChargeBreakdown.Table.AsEnumerable().Where(row => (row.Field<string>("Type") ?? "") == "ADDITIONAL").Sum(row => row.Field<decimal>("Charge"));

                            // get sor descriptions
                            string sorDescription = string.Join(" / ", dvChargeBreakdown.Table.AsEnumerable().Where(row => (row.Field<string>("Type") ?? "") == "SOR").Select(row => row.Field<string>("Description")).ToArray());

                            // calculate amounts
                            double amount = Helper.MakeDoubleValid(r["Amount"]);
                            double vatRate = Helper.MakeDoubleValid(r["VATRate"]) / 100;
                            double vatAmount = amount * vatRate;
                            double total = amount + Math.Round(vatAmount, 2, MidpointRounding.ToEven);

                            // insert the info
                            DataRow newRw;
                            newRw = exportData.NewRow();
                            newRw["UPRN"] = Helper.MakeStringValid(dvEngVisit[0]["UPRN"]);
                            newRw["Address"] = Helper.MakeStringValid(dvEngVisit[0]["Site"]);
                            newRw["Gasway Job Number"] = Helper.MakeStringValid(dvEngVisit[0]["JobNumber"]);
                            newRw["Completion Date"] = Helper.MakeDateTimeValid(dvEngVisit[0]["CompletedDateTime"]);
                            newRw["Client Ref"] = Helper.MakeStringValid(dvEngVisit[0]["ClientRef"]);
                            newRw["Invoice Number"] = Helper.MakeStringValid(r["InvoiceNumber"]);
                            newRw["Invoice Description"] = Helper.MakeStringValid(dvEngVisit[0]["InvoiceNotes"]);
                            newRw["SOR Description"] = sorDescription;
                            newRw["SOR Cost"] = SORTotal;
                            newRw["Labour Cost"] = LABOURTotal;
                            newRw["Parts Cost"] = PARTSTotal;
                            newRw["Additional Cost"] = ADDITIONALTotal;
                            newRw["Total ex VAT"] = amount;
                            newRw["VAT"] = Math.Round(vatAmount, 2, MidpointRounding.ToEven);
                            newRw["Total"] = Math.Round(total, 2, MidpointRounding.ToEven);
                            exportData.Rows.Add(newRw);
                        }

                        ExportHelper.Export(exportData, "Valuation", Enums.ExportType.XLS);
                    }
                    catch (Exception ex)
                    {
                        App.ShowMessage("Error generating document!" + Constants.vbCrLf + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Cursor = Cursors.Default;
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error generating document!" + Constants.vbCrLf + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void txtJobNumber_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PopulateDatagrid();
            }
        }

        private void txtSageMonth_TextChanged(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
            }

            FRMChangeSageDate fCIT = (FRMChangeSageDate)App.ShowForm(typeof(FRMChangeSageDate), true, null);
            if (fCIT.DialogResult == DialogResult.OK)
            {
                txtSageMonth.Text = Conversions.ToDate(App.DB.ExecuteScalar("Select Name from tblpicklists where enumtypeid = 69")).ToString("MMMM yyyy");
            }
        }

        private void tsmiOrderNo_Click(object sender, EventArgs e)
        {
            // get the difference
            if (MessageBox.Show("Are you sure you want to update the order numbers?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                return;
            }

            try
            {
                var diff = InvoicesDataview.Table.GetChanges();
                var visitInvoices = diff.Select("InvoiceTypeID = " + Conversions.ToInteger(Enums.InvoiceType.Visit));
                foreach (DataRow visitInvoice in visitInvoices)
                {
                    int jobOfWorkId = visitInvoice.Table.Columns.Contains("JobOfWorkID") ? Helper.MakeIntegerValid(visitInvoice["JobOfWorkID"]) : 0;
                    string ponumber = Helper.MakeStringValid(visitInvoice["OrderNo"]);
                    if (jobOfWorkId > 0)
                    {
                        App.DB.JobOfWorks.Update_PONumberByJobOfWorkID(jobOfWorkId, ponumber);
                    }
                }

                App.ShowMessage("Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Unable to save: " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void view()
        {
            if (SelectedInvoiceDataRow is object)
            {
                var switchExpr = (Enums.InvoiceType)Conversions.ToInteger(SelectedInvoiceDataRow["InvoiceTypeID"]);
                switch (switchExpr)
                {
                    case Enums.InvoiceType.Contract_Option1:
                        {
                            App.ShowForm(typeof(FRMContractOriginal), true, new object[] { Helper.MakeIntegerValid(SelectedInvoiceDataRow["ContractID"]), Helper.MakeIntegerValid(SelectedInvoiceDataRow["CustomerID"]) });
                            break;
                        }

                    case Enums.InvoiceType.Order:
                        {
                            var switchExpr1 = Conversions.ToInteger(SelectedInvoiceDataRow["OrderTypeID"]);
                            switch (switchExpr1)
                            {
                                case (int)Enums.OrderType.Customer:
                                    {
                                        App.ShowForm(typeof(FRMOrder), false, new object[] { SelectedInvoiceDataRow["OrderID"], Helper.MakeIntegerValid(SelectedInvoiceDataRow["OrderSiteID"]), 0, this });
                                        break;
                                    }

                                case (int)Enums.OrderType.StockProfile:
                                    {
                                        App.ShowForm(typeof(FRMOrder), false, new object[] { SelectedInvoiceDataRow["OrderID"], SelectedInvoiceDataRow["VanID"], 0, this });
                                        break;
                                    }

                                case (int)Enums.OrderType.Warehouse:
                                    {
                                        App.ShowForm(typeof(FRMOrder), false, new object[] { SelectedInvoiceDataRow["OrderID"], SelectedInvoiceDataRow["WarehouseID"], 0, this });
                                        break;
                                    }

                                case (int)Enums.OrderType.Job:
                                    {
                                        App.ShowForm(typeof(FRMOrder), false, new object[] { SelectedInvoiceDataRow["OrderID"], SelectedInvoiceDataRow["EngineerVisitID"], 0, this });
                                        break;
                                    }

                                default:
                                    {
                                        // OrderID holds the consolidated order id
                                        App.ShowForm(typeof(FRMConsolidation), true, new object[] { SelectedInvoiceDataRow["OrderID"] });
                                        break;
                                    }
                            }

                            break;
                        }

                    case Enums.InvoiceType.Visit:
                        {
                            App.ShowForm(typeof(FRMEngineerVisit), true, new object[] { Helper.MakeIntegerValid(SelectedInvoiceDataRow["EngineerVisitID"]) });
                            break;
                        }
                }
            }
            else
            {
                App.ShowMessage("Please select an invoice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PopulateDatagrid()
        {
            Cursor = Cursors.WaitCursor;
            int customerId = theCustomer is object ? theCustomer.CustomerID : 0;
            int siteId = theSite is object ? theSite.SiteID : 0;
            string postcode = txtPostcode.Text.Trim().Length > 0 ? txtPostcode.Text : null;
            int invoiceTypeId = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType));
            string jobNumber = txtJobNumber.Text.Trim().Length > 0 ? txtJobNumber.Text : null;
            string invoiceNumber = txtInvoiceNumber.Text.Trim().Length > 0 ? txtInvoiceNumber.Text : null;
            int userId = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboUser));
            int regionId = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboRegion));
            string department = Combo.get_GetSelectedItemValue(cboDept).Trim();
            int exportedToSage = -1;
            if (cboExported.SelectedIndex == 1)
            {
                exportedToSage = 1;
            }
            else if (cboExported.SelectedIndex == 2)
            {
                exportedToSage = 0;
            }

            InvoicesDataview = App.DB.Invoiced.Invoiced_GetAll_Manager(dtpRaisedFrom.Value, dtpRaisedTo.Value, customerId, siteId, postcode, invoiceTypeId, jobNumber, invoiceNumber, userId, regionId, department, exportedToSage);
            if (chkExportedOn.Checked)
            {
                string query = "ExportedOn = #" + dtpExportedOn.Value.ToString("yyyy-MM-dd") + "#";
                InvoicesDataview.RowFilter = query;
            }

            grpInvoices.Text = "Double Click To View / Add Payment Information - Search Results (" + InvoicesDataview.Count + ")";
            Cursor = Cursors.Default;
        }

        private void ResetFilters()
        {
            theCustomer = null;
            var fromDate = default(DateTime);
            var switchExpr = DateAndTime.Today.DayOfWeek;
            switch (switchExpr)
            {
                case DayOfWeek.Monday:
                    {
                        fromDate = DateAndTime.Now;
                        break;
                    }

                case DayOfWeek.Tuesday:
                    {
                        fromDate = DateAndTime.Now.AddDays(-1);
                        break;
                    }

                case DayOfWeek.Wednesday:
                    {
                        fromDate = DateAndTime.Now.AddDays(-2);
                        break;
                    }

                case DayOfWeek.Thursday:
                    {
                        fromDate = DateAndTime.Now.AddDays(-3);
                        break;
                    }

                case DayOfWeek.Friday:
                    {
                        fromDate = DateAndTime.Now.AddDays(-4);
                        break;
                    }

                case DayOfWeek.Saturday:
                    {
                        fromDate = DateAndTime.Now.AddDays(-5);
                        break;
                    }

                case DayOfWeek.Sunday:
                    {
                        fromDate = DateAndTime.Now.AddDays(-6);
                        break;
                    }
            }

            var argc = cboStatus;
            Combo.SetUpCombo(ref argc, DynamicDataTables.InvoiceStatus, "ValueMember", "DisplayMember", Enums.ComboValues.None);
            var argcombo = cboStatus;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, (-3).ToString());
            txtInvoiceNumber.Text = "";
            var argc1 = cboUser;
            Combo.SetUpCombo(ref argc1, App.DB.User.GetAll().Table, "UserID", "Fullname", Enums.ComboValues.No_Filter);
            var argcombo1 = cboUser;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, 0.ToString());
            dtpRaisedFrom.Value = fromDate.AddDays(-21);
            dtpRaisedTo.Value = fromDate.AddDays(7);
            var argc2 = cboType;
            Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Enums.PickListTypes.InvoiceTypes).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
            var argcombo2 = cboType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, 0.ToString());
            var argc3 = cboRegion;
            Combo.SetUpCombo(ref argc3, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
            switch (true)
            {
                case object _ when App.IsGasway:
                    {
                        var argc4 = cboDept;
                        Combo.SetUpCombo(ref argc4, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }

                default:
                    {
                        var argc5 = cboDept;
                        Combo.SetUpCombo(ref argc5, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }
            }

            txtJobNumber.Text = "";
            txtPostcode.Text = "";
            string d1 = Conversions.ToString(App.DB.ExecuteScalar("Select Name from tblpicklists where enumtypeid = 69"));
            if (!Information.IsNothing(d1))
            {
                txtSageMonth.Text = Conversions.ToDate(d1).ToString("MMMM yyyy");
            }
        }

        public void Export()
        {
            if (!(Helper.MakeIntegerValid(InvoicesDataview?.Count) > 0))
            {
                App.ShowMessage("No filter added", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var exportData = new DataTable();
            exportData.Columns.Add("PaidStatus");
            exportData.Columns.Add("Customer");
            exportData.Columns.Add("Site");
            exportData.Columns.Add("InvoiceType");
            exportData.Columns.Add("JobNumber");
            exportData.Columns.Add("InvoiceAddressType");
            exportData.Columns.Add("InvoiceAddress");
            exportData.Columns.Add("Amount", typeof(double));
            exportData.Columns.Add("InvoiceNumber");
            exportData.Columns.Add("RaisedDate");
            exportData.Columns.Add("Fullname");
            exportData.Columns.Add("Department");
            exportData.Columns.Add("Exported");
            foreach (DataRowView dr in (DataView)dgInvoices.DataSource)
            {
                var newRw = exportData.NewRow();
                newRw["PaidStatus"] = dr["PaidStatus"];
                newRw["Customer"] = dr["Customer"];
                newRw["Site"] = dr["Site"];
                newRw["InvoiceType"] = dr["InvoiceType"];
                newRw["JobNumber"] = dr["JobNumber"];
                newRw["InvoiceAddressType"] = dr["InvoiceAddressType"];
                newRw["InvoiceAddress"] = dr["InvoiceAddress"];
                newRw["Amount"] = dr["Amount"];
                newRw["InvoiceNumber"] = dr["InvoiceNumber"];
                newRw["RaisedDate"] = Strings.Format(dr["RaisedDate"], "dd/MM/yyyy");
                newRw["Fullname"] = dr["Fullname"];
                newRw["Department"] = dr["Department"];
                if (Helper.MakeDateTimeValid(dr["DateExportedToSage"]) == default)
                {
                    newRw["Exported"] = "";
                }
                else
                {
                    newRw["Exported"] = Strings.Format(dr["DateExportedToSage"], "dd/MM/yyyy");
                }

                exportData.Rows.Add(newRw);
            }

            ExportHelper.Export(exportData, "Invoiced List", Enums.ExportType.XLS);
        }

        public void Print()
        {
            if (InvoicesToPrint.Count < 1)
                return;
            var details = new ArrayList();
            details.Add(InvoicesToPrint);
            var oPrint = new Printing(details, "Invoice", Enums.SystemDocumentType.Invoice, true);
            InvoicesToPrint.Clear();
        }

        public void FindPartPayJobs(bool Multi)
        {
            try
            {
                // FOR EVERY TICKED RECORD
                foreach (DataRow dr in InvoicesDataview.Table.Rows)
                {
                    if (Helper.MakeBooleanValid(dr["tick"]) == true)
                    {
                        // VISIT RECORDS
                        if ((Enums.InvoiceType)Conversions.ToInteger(dr["InvoiceTypeID"]) == Enums.InvoiceType.Visit)
                        {
                            // SEE IF JOB IS PART PAY
                            if (App.DB.Job.Job_Get(Conversions.ToInteger(dr["JobID"])).ToBePartPaid == true)
                            {
                                // UNTICK - We'll add to print list from here

                                dr["tick"] = 0;
                                // IS IT INVOICED?
                                if (Helper.MakeIntegerValid(dr["invoicedID"]) == 0) // Invoiced =NO
                                {
                                    // IS THERE AN Invoice for any other visits on this job?
                                    var dt = App.DB.InvoiceToBeRaised.InvoicesToBeRaised_GetAllVisitsInvoice_ByJobID(Conversions.ToInteger(dr["JobID"])).Table;
                                    if (dt.Rows.Count > 0) // Exisiting Invoice =YES
                                    {
                                        // Add to Exisiting Invoice
                                        InsertInvoiceLines(Helper.MakeDoubleValid(dr["Amount"]), Conversions.ToInteger(dt.Rows[0]["InvoicedID"]), Conversions.ToInteger(dr["InvoiceToBeRaisedID"]));

                                        // Add Invoice to print list
                                        if (!InvoicesToPrint.Contains(dt.Rows[0]["InvoicedID"]))
                                        {
                                            InvoicesToPrint.Add(Helper.MakeIntegerValid(dt.Rows[0]["InvoicedID"]));
                                        }
                                    }
                                    else // Exisiting Invoice =NO
                                    {
                                        // CREATE NEW INVOICE
                                        var inv = new Entity.Invoiceds.Invoiced();
                                        var invNum = new JobNumber();
                                        invNum = App.DB.Job.GetNextJobNumber((Enums.JobDefinition)5);
                                        inv.SetInvoiceNumber = invNum.Prefix + invNum.Number;
                                        inv.SetRaisedByUserID = App.loggedInUser.UserID;
                                        inv.RaisedDate = DateAndTime.Now;
                                        inv = App.DB.Invoiced.Insert(inv);
                                        // ADD ALL THE VISITS READY FOR INVOICE
                                        var dtVisits = App.DB.InvoiceToBeRaised.InvoicesToBeRaised_GetAllVisitsNotInvoice_ByJobID(Conversions.ToInteger(dr["JobID"])).Table;
                                        foreach (DataRow v in dtVisits.Rows)
                                            InsertInvoiceLines(Helper.MakeDoubleValid(v["Amount"]), inv.InvoicedID, Conversions.ToInteger(v["InvoiceToBeRaisedID"]));

                                        // IF its multi line invoice add on anyother things
                                        if (Multi)
                                        {
                                            MultiInvoicePPJob(dr, inv, dtVisits);
                                        }

                                        // Add Invoice to print list
                                        if (!InvoicesToPrint.Contains(inv.InvoicedID))
                                        {
                                            InvoicesToPrint.Add(Helper.MakeIntegerValid(inv.InvoicedID));
                                        }
                                    }
                                }
                                else // Invoiced = YES
                                {
                                    // ARE THERE ANY OTHER VISITS THAT SHOUlD BE ONE THIS INVOICE THAT AREN'T?
                                    // ADD THEM
                                    foreach (DataRow v in App.DB.InvoiceToBeRaised.InvoicesToBeRaised_GetAllVisitsNotInvoice_ByJobID(Conversions.ToInteger(dr["JobID"])))
                                    {
                                        if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(dr["InvoiceToBeRaisedID"], v["InvoiceToBeRaisedID"], false)))
                                        {
                                            InsertInvoiceLines(Helper.MakeDoubleValid(v["Amount"]), Conversions.ToInteger(dr["invoicedID"]), Conversions.ToInteger(v["InvoiceToBeRaisedID"]));
                                        }
                                    }

                                    // Add Invoice to print list
                                    if (!InvoicesToPrint.Contains(dr["InvoicedID"]))
                                    {
                                        InvoicesToPrint.Add(Helper.MakeIntegerValid(dr["InvoicedID"]));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MultiInvoicePPJob(DataRow dr, Entity.Invoiceds.Invoiced inv, DataTable dtVisits)
        {
            try
            {
                // GET ALL ITEMS THAT YOU WANNA PUT ON THE INVOICE
                var drInv = InvoicesDataview.Table.Select(Conversions.ToString(Conversions.ToString("AddressTypeID=" + dr["AddressTypeID"] + " AND AddressID=") + dr["AddressID"]));
                for (int i = 0, loopTo = drInv.Length - 1; i <= loopTo; i++)
                {
                    // IS IT INVOICED ALREADY?
                    if (Helper.MakeIntegerValid(drInv[i]["invoicedID"]) == 0) // NO
                    {
                        // IS IT A VISIT OR AN ORDER?
                        if ((Enums.InvoiceType)Conversions.ToInteger(drInv[i]["InvoiceTypeID"]) == Enums.InvoiceType.Order)
                        {
                            // ORDER
                            // UNTICK
                            drInv[i]["tick"] = 0;
                            InsertInvoiceLines(Helper.MakeDoubleValid(drInv[i]["Amount"]), inv.InvoicedID, Conversions.ToInteger(drInv[i]["InvoiceToBeRaisedID"]));
                        }

                        // IS THE VISIT ALREADY INSERTED ABOVE?
                        else if (dtVisits.Select(Conversions.ToString("InvoiceToBeRaisedID=" + drInv[i]["InvoiceToBeRaisedID"])).Length > 0) // VISIT
                        {
                            // YES UNTICK
                            drInv[i]["tick"] = 0;
                        }
                        // NO - IS IT PP JOB ?
                        else if (App.DB.Job.Job_Get(Conversions.ToInteger(drInv[i]["JobID"])).ToBePartPaid == true) // YES
                        {
                            // IS THERE ANY EXISTING INVOICES FOR THE JOB'S VISIT
                            bool jobAlreadyInvoiced = false;
                            var alreadyInv = App.DB.InvoiceToBeRaised.InvoicesToBeRaised_GetAllVisitsInvoice_ByJobID(Conversions.ToInteger(drInv[i]["JobID"])).Table;
                            if (alreadyInv.Rows.Count > 0)
                            {
                                // AND ITS A DIFFERENT INVOICE TO THIS ONE
                                foreach (DataRow aInv in alreadyInv.Rows)
                                {
                                    if (Helper.MakeIntegerValid(drInv[i]["InvoicedID"]) == Helper.MakeIntegerValid(aInv["InvoicedID"]))
                                    {
                                        jobAlreadyInvoiced = true; // Just leave the this alone it will picked up later
                                    }
                                }

                                if (jobAlreadyInvoiced)
                                {
                                }
                                // Just leave the this alone it will picked up later
                                else
                                {
                                    // UNTICK AND INSERT
                                    drInv[i]["tick"] = 0;
                                    InsertInvoiceLines(Helper.MakeDoubleValid(drInv[i]["Amount"]), inv.InvoicedID, Conversions.ToInteger(drInv[i]["InvoiceToBeRaisedID"]));
                                }
                            }
                            else // NO INVOICE
                            {
                                // UNTICK AND INSERT
                                drInv[i]["tick"] = 0;
                                InsertInvoiceLines(Helper.MakeDoubleValid(drInv[i]["Amount"]), inv.InvoicedID, Conversions.ToInteger(drInv[i]["InvoiceToBeRaisedID"]));
                            }
                        }
                        else // NO
                        {
                            // UNTICK AND INSERT
                            drInv[i]["tick"] = 0;
                            InsertInvoiceLines(Helper.MakeDoubleValid(drInv[i]["Amount"]), inv.InvoicedID, Conversions.ToInteger(drInv[i]["InvoiceToBeRaisedID"]));
                        }
                    }
                    else // ALREADY INVOICED SO JUST UNTICK
                    {
                        drInv[i]["tick"] = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void InsertInvoiceLines(double amount, int invoicedID, int InvoiceToBeRaisedID)
        {
            var invLines = new Entity.InvoicedLiness.InvoicedLines();
            invLines.SetAmount = amount;
            invLines.SetInvoicedID = invoicedID;
            invLines.SetInvoiceToBeRaisedID = InvoiceToBeRaisedID;
            invLines = App.DB.InvoicedLines.Insert(invLines);
        }

        private bool Check_Supplier_Invoices_And_Continue()
        {
            bool invoicesRemoved = false;
            foreach (DataRow row in InvoicesDataview.Table.Rows)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["InvoiceType"], "Supplier", false) | Operators.ConditionalCompareObjectEqual(row["InvoiceType"], "Consolidation", false)))
                {
                    if (Conversions.ToBoolean(row["Tick"]))
                    {
                        row["Tick"] = false;
                        invoicesRemoved = true;
                    }
                }
            }

            if (invoicesRemoved)
            {
                if (App.ShowMessage("Supplier invoices have been removed - would you like to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }
            }

            return true;
        }

        private async void btnMarkAsNotExported_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to mark the selected invoices as not exported?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                if (InvoicesDataview is object)
                {
                    DataRow nw = null;
                    foreach (DataRowView r in InvoicesDataview)
                    {
                        if (Conversions.ToBoolean(r["tick"]))
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Supplier", false)))
                            {
                                await App.DB.Invoiced.MarkOrderAsNotExportedAsync(Conversions.ToInteger(r["SupplierInvoiceID"]));
                            }
                            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Part Credit", false)))
                            {
                                await App.DB.Invoiced.MarkPartCreditedAsNotExportedAsync(Conversions.ToInteger(r["OrderID"]), Conversions.ToInteger(r["LinkID"]));
                            }
                            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Consolidation", false)))
                            {
                                await App.DB.Invoiced.MarkConsolidatedOrderAsNotExportedAsync(Conversions.ToInteger(r["OrderID"]));
                            }
                            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Sales Credit", false)))
                            {
                                await App.DB.Invoiced.MarkSalesCreditAsNotExportedAsync(Conversions.ToInteger(r["LinkID"]));
                            }
                            else
                            {
                                await App.DB.Invoiced.MarkInvoiceAsNotExportedAsync(Conversions.ToInteger(r["InvoicedID"]));
                            }
                        }
                    }
                }

                PopulateDatagrid();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
            }
        }

        private void cboExportedToSage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PopulateDatagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportToAccounts_Click(object sender, EventArgs e)
        {
            cmsExportForAccounts.Show(btnExportToAccounts, new Point(0, 0));
        }

        private async void tsmiSunExport_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                if (InvoicesDataview is object)
                {
                    var dr = (from sf in InvoicesDataview.Table.AsEnumerable()
                              where sf.Field<bool>("Tick") == true
                              select sf).ToArray();
                    if (dr.Count() < 1)
                    {
                        App.ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var accountingPeriodDate = new DateTime(Conversions.ToDate(txtSageMonth.Text).Year, Conversions.ToDate(txtSageMonth.Text).Month, 1);
                    var dtSunMaps = App.DB.SunFinance.GetAllMaps();
                    var payload = new Entity.Accounts.Payload();
                    foreach (DataRow r in dr)
                    {
                        string custType = string.Empty;
                        var switchExpr = r["InvoiceType"].ToString();
                        switch (switchExpr)
                        {
                            case "Supplier":
                            case "Part Credit":
                            case "Consolidation":
                                {
                                    custType = "Supplier";
                                    break;
                                }

                            default:
                                {
                                    custType = "Customer";
                                    break;
                                }
                        }

                        bool purchases = (custType ?? "") == "Supplier" ? true : false;
                        if (Helper.MakeBooleanValid(r["ExportedToSage"]) == false)
                        {
                            if (Conversions.ToDouble(r["Amount"]) > 0.0)
                            {
                                if (Conversions.ToDate(Strings.Format(r["Raiseddate"], "dd/MM/yyyy")) < accountingPeriodDate & !purchases)
                                {
                                    App.ShowMessage("A invoice has been stopped in the export as it is for a different month to the current processing month.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    string nominalCode = dtSunMaps.AsEnumerable().Select(x => new
                                    {
                                        Type = x.Field<string>("Type"),
                                        OldVal = x.Field<string>("OldVal"),
                                        NewVal = x.Field<string>("NewVal"),
                                        Deleted = x.Field<bool>("Deleted")
                                    }).Where(s => (s.Type ?? "") == "Nominal" && Operators.ConditionalCompareObjectEqual(s.OldVal, r["NominalCode"], false) && s.Deleted == false).Select(h => h.NewVal).FirstOrDefault();
                                    if (string.IsNullOrEmpty(nominalCode))
                                        nominalCode = Conversions.ToString(r["NominalCode"]);
                                    string account = dtSunMaps.AsEnumerable().Select(x => new
                                    {
                                        Type = x.Field<string>("Type"),
                                        OldVal = x.Field<string>("OldVal"),
                                        NewVal = x.Field<string>("NewVal"),
                                        Deleted = x.Field<bool>("Deleted")
                                    }).Where(s => (s.Type ?? "") == (custType ?? "") && Operators.ConditionalCompareObjectEqual(s.OldVal, r["AccountNumber"], false) && s.Deleted == false).Select(h => h.NewVal).FirstOrDefault();
                                    if (string.IsNullOrEmpty(account))
                                        account = Conversions.ToString(r["AccountNumber"]);
                                    string regionCode = dtSunMaps.AsEnumerable().Select(x => new
                                    {
                                        Type = x.Field<string>("Type"),
                                        OldVal = x.Field<string>("OldVal"),
                                        NewVal = x.Field<string>("NewVal"),
                                        Deleted = x.Field<bool>("Deleted")
                                    }).Where(s => (s.Type ?? "") == "Region" && Operators.ConditionalCompareObjectEqual(s.OldVal, r["Region"], false) && s.Deleted == false).Select(h => h.NewVal).FirstOrDefault();
                                    var netLine = new Entity.Accounts.Line();
                                    Entity.Accounts.Line vatLine = null;
                                    Entity.Accounts.Line grossLine = null;
                                    netLine.AccountCode = nominalCode;
                                    netLine.AccountingPeriod = Entity.Accounts.AccountsHelper.GetAccountPeriod(accountingPeriodDate);
                                    if (!string.IsNullOrEmpty(regionCode))
                                        netLine.AnalysisCode1 = regionCode;
                                    netLine.AnalysisCode2 = Entity.Accounts.AccountsHelper.FormatSunDepartment(Conversions.ToString(r["Department"]));
                                    netLine.TransactionDate = Strings.Format(Conversions.ToDate(r["RaisedDate"]), "ddMMyyyy");
                                    netLine.TransactionReference = Conversions.ToString(r["InvoiceNumber"]);
                                    netLine.EntryDate = DateAndTime.Now.ToString("ddMMyyyy");
                                    if (Helper.MakeIntegerValid(r["JobID"]) > 0)
                                    {
                                        string jobType = Helper.MakeStringValid(r["JobType"]);
                                        string jobTypeMap = dtSunMaps.AsEnumerable().Select(x => new
                                        {
                                            Type = x.Field<string>("Type"),
                                            OldVal = x.Field<string>("OldVal"),
                                            NewVal = x.Field<string>("NewVal"),
                                            Deleted = x.Field<bool>("Deleted")
                                        }).Where(s => (s.Type ?? "") == "JobType" && (s.OldVal ?? "") == (jobType ?? "") && s.Deleted == false).Select(h => h.NewVal).FirstOrDefault();
                                        if (string.IsNullOrEmpty(jobTypeMap))
                                            jobTypeMap = "GENERI";
                                        netLine.AnalysisCode4 = jobTypeMap;
                                    }
                                    else
                                    {
                                        netLine.AnalysisCode4 = "GENERI";
                                    }

                                    if ((netLine.AnalysisCode2 ?? "") == "004")
                                    {
                                        netLine.AnalysisCode6 = "COM";
                                    }
                                    else if (Helper.MakeIntegerValid(r["CustomerTypeID"]) == Conversions.ToInteger(Enums.CustomerType.SocialHousing))
                                    {
                                        netLine.AnalysisCode6 = "GSH";
                                    }
                                    else
                                    {
                                        netLine.AnalysisCode6 = "GAS";
                                    }

                                    netLine.AnalysisCode7 = account;
                                    string customer = Helper.MakeStringValid(r["Customer"]).Replace(" ", "");
                                    netLine.AnalysisCode8 = customer.Substring(0, Math.Min(customer.Length, 15));
                                    netLine.AnalysisCode9 = Conversions.ToString(r["JobNumber"]);
                                    string vatCode = null;
                                    var switchExpr1 = r["Tax_Code"].ToString();
                                    switch (switchExpr1)
                                    {
                                        case "T0":
                                            {
                                                vatCode = "ZR";
                                                break;
                                            }

                                        case "T1":
                                            {
                                                vatCode = "SR";
                                                break;
                                            }

                                        case "T2":
                                            {
                                                vatCode = "ER";
                                                break;
                                            }

                                        case "T5":
                                            {
                                                vatCode = "LR";
                                                break;
                                            }

                                        case "T9":
                                            {
                                                vatCode = "OS";
                                                break;
                                            }
                                    }

                                    var switchExpr2 = r["InvoiceType"].ToString();
                                    switch (switchExpr2)
                                    {
                                        case "Supplier":
                                        case "Part Credit":
                                        case "Consolidation":
                                            {
                                                vatCode = "I" + vatCode;
                                                break;
                                            }

                                        default:
                                            {
                                                vatCode = "O" + vatCode;
                                                break;
                                            }
                                    }

                                    string purchaseVatCode = "B5850";
                                    if (App.IsRFT)
                                    {
                                        netLine.AnalysisCode3 = "NTS";
                                        netLine.AnalysisCode4 = "ADH001";
                                        netLine.AnalysisCode6 = "XXX";
                                        purchaseVatCode = "M9999";
                                    }

                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Supplier", false)))
                                    {
                                        netLine.AnalysisCode5 = vatCode;
                                        if (App.IsRFT)
                                        {
                                            netLine.Description = Conversions.ToString(Conversions.ToString(r["InvoiceAddress"] + " ") + r["JobNumber"]);
                                        }
                                        else
                                        {
                                            netLine.Description = Conversions.ToString(r["JobNumber"]);
                                        }

                                        if (r.Table.Columns.Contains("SubTaxRate") && !Information.IsDBNull(r["SubTaxRate"]))
                                        {
                                            Entity.Accounts.Line cisVatLine = null;
                                            Entity.Accounts.Line cisLine = null;
                                            netLine.JournalType = "PICIS";
                                            vatLine = (Entity.Accounts.Line)netLine.Clone();
                                            grossLine = (Entity.Accounts.Line)netLine.Clone();
                                            vatLine.AccountCode = purchaseVatCode;
                                            grossLine.AccountCode = account;
                                            cisVatLine = (Entity.Accounts.Line)netLine.Clone();
                                            cisLine = (Entity.Accounts.Line)netLine.Clone();
                                            cisVatLine.AccountCode = "B5710";
                                            cisLine.AccountCode = account;
                                            if ((nominalCode ?? "") == "23100")
                                            {
                                                double cisVatAmount = Helper.MakeDoubleValid(r["Amount"]) * Helper.MakeDoubleValid(r["SubTaxRate"]);
                                                cisVatLine.TransactionAmount = -cisVatAmount;
                                                cisLine.TransactionAmount = cisVatAmount;
                                            }
                                            else
                                            {
                                                cisVatLine.TransactionAmount = -0;
                                                cisLine.TransactionAmount = 0;
                                            }

                                            cisVatLine.DebitCredit = "C";
                                            cisLine.DebitCredit = "D";
                                            netLine.DebitCredit = "D";
                                            vatLine.DebitCredit = "D";
                                            grossLine.DebitCredit = "C";
                                            if (App.IsRFT)
                                            {
                                                netLine.TransactionAmount = Conversions.ToDouble((decimal)r["Amount"] + (decimal)r["VATAmount"]);
                                            }
                                            else
                                            {
                                                netLine.TransactionAmount = Conversions.ToDouble(r["Amount"]);
                                            }

                                            vatLine.TransactionAmount = Conversions.ToDouble(r["VATAmount"]);
                                            grossLine.TransactionAmount = Conversions.ToDouble(-(decimal)r["Amount"] + -(decimal)r["VATAmount"]);
                                            payload.Ledger.Add(netLine);
                                            payload.Ledger.Add(vatLine);
                                            payload.Ledger.Add(grossLine);
                                            if (cisVatLine is object)
                                                payload.Ledger.Add(cisVatLine);
                                            if (cisVatLine is object)
                                                payload.Ledger.Add(cisLine);
                                        }
                                        else
                                        {
                                            netLine.JournalType = "PIGAB";
                                            vatLine = (Entity.Accounts.Line)netLine.Clone();
                                            grossLine = (Entity.Accounts.Line)netLine.Clone();
                                            vatLine.AccountCode = purchaseVatCode;
                                            grossLine.AccountCode = account;
                                            netLine.DebitCredit = "D";
                                            vatLine.DebitCredit = "D";
                                            grossLine.DebitCredit = "C";
                                            if (App.IsRFT)
                                            {
                                                netLine.TransactionAmount = Conversions.ToDouble((decimal)r["Amount"] + (decimal)r["VATAmount"]);
                                            }
                                            else
                                            {
                                                netLine.TransactionAmount = Conversions.ToDouble(r["Amount"]);
                                            }

                                            vatLine.TransactionAmount = Conversions.ToDouble(r["VATAmount"]);
                                            grossLine.TransactionAmount = Conversions.ToDouble(-(decimal)r["Amount"] + -(decimal)r["VATAmount"]);
                                            payload.Ledger.Add(netLine);
                                            payload.Ledger.Add(vatLine);
                                            payload.Ledger.Add(grossLine);
                                        }

                                        await App.DB.Invoiced.MarkOrderAsExportedAsync(Conversions.ToInteger(r["SupplierInvoiceID"]));
                                    }
                                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Part Credit", false)))
                                    {
                                        netLine.AnalysisCode5 = vatCode;
                                        if (App.IsRFT)
                                        {
                                            netLine.Description = Conversions.ToString(Conversions.ToString(r["InvoiceAddress"] + " ") + r["JobNumber"]);
                                        }
                                        else
                                        {
                                            netLine.Description = Conversions.ToString(r["JobNumber"]);
                                        }

                                        if (r.Table.Columns.Contains("SubTaxRate") && !Information.IsDBNull(r["SubTaxRate"]))
                                        {
                                            Entity.Accounts.Line cisVatLine = null;
                                            Entity.Accounts.Line cisLine = null;
                                            netLine.JournalType = "PCCIS";
                                            vatLine = (Entity.Accounts.Line)netLine.Clone();
                                            grossLine = (Entity.Accounts.Line)netLine.Clone();
                                            vatLine.AccountCode = purchaseVatCode;
                                            grossLine.AccountCode = account;
                                            cisVatLine = (Entity.Accounts.Line)netLine.Clone();
                                            cisLine = (Entity.Accounts.Line)netLine.Clone();
                                            cisVatLine.AccountCode = "B5710";
                                            cisLine.AccountCode = account;
                                            if ((nominalCode ?? "") == "23100")
                                            {
                                                double cisVatAmount = Helper.MakeDoubleValid(r["Amount"]) * Helper.MakeDoubleValid(r["SubTaxRate"]);
                                                cisVatLine.TransactionAmount = cisVatAmount;
                                                cisLine.TransactionAmount = -cisVatAmount;
                                            }
                                            else
                                            {
                                                cisVatLine.TransactionAmount = 0;
                                                cisLine.TransactionAmount = -0;
                                            }

                                            cisLine.DebitCredit = "D";
                                            cisVatLine.DebitCredit = "C";
                                            netLine.DebitCredit = "C";
                                            vatLine.DebitCredit = "C";
                                            grossLine.DebitCredit = "D";
                                            if (App.IsRFT)
                                            {
                                                netLine.TransactionAmount = Conversions.ToDouble(-(decimal)r["Amount"] + -(decimal)r["VATAmount"]);
                                            }
                                            else
                                            {
                                                netLine.TransactionAmount = Conversions.ToDouble(-(decimal)r["Amount"]);
                                            }

                                            vatLine.TransactionAmount = Conversions.ToDouble(-(decimal)r["VATAmount"]);
                                            grossLine.TransactionAmount = Conversions.ToDouble((decimal)r["Amount"] + (decimal)r["VATAmount"]);
                                            payload.Ledger.Add(netLine);
                                            payload.Ledger.Add(vatLine);
                                            payload.Ledger.Add(grossLine);
                                            if (cisVatLine is object)
                                                payload.Ledger.Add(cisVatLine);
                                            if (cisVatLine is object)
                                                payload.Ledger.Add(cisLine);
                                        }
                                        else
                                        {
                                            netLine.JournalType = "PCGAB";
                                            vatLine = (Entity.Accounts.Line)netLine.Clone();
                                            grossLine = (Entity.Accounts.Line)netLine.Clone();
                                            vatLine.AccountCode = purchaseVatCode;
                                            grossLine.AccountCode = account;
                                            netLine.DebitCredit = "C";
                                            vatLine.DebitCredit = "C";
                                            grossLine.DebitCredit = "D";
                                            if (App.IsRFT)
                                            {
                                                netLine.TransactionAmount = Conversions.ToDouble(-(decimal)r["Amount"] + -(decimal)r["VATAmount"]);
                                            }
                                            else
                                            {
                                                netLine.TransactionAmount = Conversions.ToDouble(-(decimal)r["Amount"]);
                                            }

                                            vatLine.TransactionAmount = Conversions.ToDouble(-(decimal)r["VATAmount"]);
                                            grossLine.TransactionAmount = Conversions.ToDouble((decimal)r["Amount"] + (decimal)r["VATAmount"]);
                                            payload.Ledger.Add(netLine);
                                            payload.Ledger.Add(vatLine);
                                            payload.Ledger.Add(grossLine);
                                        }

                                        await App.DB.Invoiced.MarkPartCreditedAsExportedAsync(Conversions.ToInteger(r["OrderID"]), Conversions.ToInteger(r["LinkID"]));
                                    }
                                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Consolidation", false)))
                                    {
                                        netLine.AnalysisCode5 = vatCode;
                                        if (App.IsRFT)
                                        {
                                            netLine.Description = Conversions.ToString(Conversions.ToString(r["InvoiceAddress"] + " ") + r["JobNumber"]);
                                        }
                                        else
                                        {
                                            netLine.Description = Conversions.ToString(r["JobNumber"]);
                                        }

                                        netLine.JournalType = "PIGAB";
                                        vatLine = (Entity.Accounts.Line)netLine.Clone();
                                        grossLine = (Entity.Accounts.Line)netLine.Clone();
                                        vatLine.AccountCode = purchaseVatCode;
                                        grossLine.AccountCode = account;
                                        netLine.DebitCredit = "D";
                                        vatLine.DebitCredit = "D";
                                        grossLine.DebitCredit = "C";
                                        if (App.IsRFT)
                                        {
                                            netLine.TransactionAmount = Conversions.ToDouble((decimal)r["Amount"] + (decimal)r["VATAmount"]);
                                        }
                                        else
                                        {
                                            netLine.TransactionAmount = Conversions.ToDouble(r["Amount"]);
                                        }

                                        vatLine.TransactionAmount = Conversions.ToDouble(r["VATAmount"]);
                                        grossLine.TransactionAmount = Conversions.ToDouble(-(decimal)r["Amount"] + -(decimal)r["VATAmount"]);
                                        payload.Ledger.Add(netLine);
                                        payload.Ledger.Add(vatLine);
                                        payload.Ledger.Add(grossLine);

                                        // OrderID holds the consolidated order id
                                        await App.DB.Invoiced.MarkConsolidatedOrderAsExportedAsync(Conversions.ToInteger(r["OrderID"]));
                                    }
                                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Sales Credit", false)))
                                    {
                                        netLine.AnalysisCode5 = vatCode;
                                        netLine.AnalysisCode9 = Conversions.ToString(r["JobNumber"]);
                                        netLine.Description = Conversions.ToString("Credit Against Invoice : " + r["InvoiceNumber"]);
                                        netLine.TransactionReference = Conversions.ToString(r["JobNumber"]);
                                        netLine.JournalType = "SCGAB";
                                        vatLine = (Entity.Accounts.Line)netLine.Clone();
                                        grossLine = (Entity.Accounts.Line)netLine.Clone();
                                        vatLine.AccountCode = "B5800";
                                        grossLine.AccountCode = account;
                                        netLine.DebitCredit = "D";
                                        vatLine.DebitCredit = "D";
                                        grossLine.DebitCredit = "C";
                                        decimal VATRate = Conversions.ToDecimal(r["VATRATE"]);
                                        decimal VATRateDecimal = VATRate / 100;
                                        if (Helper.MakeBooleanValid(r["IsOutOfScope"]))
                                            VATRateDecimal = 0;
                                        netLine.TransactionAmount = Conversions.ToDouble(r["Amount"]);
                                        vatLine.TransactionAmount = Conversions.ToDouble(r["Amount"]) * (double)VATRateDecimal;
                                        grossLine.TransactionAmount = Conversions.ToDouble(-(decimal)r["Amount"] + -(Conversions.ToDecimal(r["Amount"]) * VATRateDecimal));
                                        payload.Ledger.Add(netLine);
                                        payload.Ledger.Add(vatLine);
                                        payload.Ledger.Add(grossLine);

                                        // LinkID holds the SalescreditID
                                        await App.DB.Invoiced.MarkSalesCreditAsExportedAsync(Conversions.ToInteger(r["LinkID"]));
                                    }
                                    else
                                    {
                                        netLine.AnalysisCode5 = vatCode;
                                        string description = "";
                                        description += Helper.MakeStringValid(r["Address1"]).Trim().Replace(",", "");
                                        description += " ";
                                        description += Helper.MakeStringValid(r["Address2"]).Trim().Replace(",", "");
                                        description += "- " + Helper.MakeStringValid(r["PolicyNumber"]).Trim().Replace(",", "");
                                        if (description.Trim().Length == 0)
                                        {
                                            description = "FSM INVOICE";
                                        }

                                        netLine.Description = description;
                                        netLine.JournalType = "SIGAB";
                                        vatLine = (Entity.Accounts.Line)netLine.Clone();
                                        grossLine = (Entity.Accounts.Line)netLine.Clone();
                                        vatLine.AccountCode = "B5800";
                                        grossLine.AccountCode = account;
                                        netLine.DebitCredit = "C";
                                        vatLine.DebitCredit = "C";
                                        grossLine.DebitCredit = "D";
                                        decimal VATRate = Conversions.ToDecimal(r["VATRATE"]);
                                        decimal VATRateDecimal = VATRate / 100;
                                        if (Helper.MakeBooleanValid(r["IsOutOfScope"]))
                                            VATRateDecimal = 0;
                                        netLine.TransactionAmount = Conversions.ToDouble(-(decimal)r["Amount"]);
                                        vatLine.TransactionAmount = Conversions.ToDouble(-(Conversions.ToDecimal(r["Amount"]) * VATRateDecimal));
                                        grossLine.TransactionAmount = Conversions.ToDouble((decimal)r["Amount"] + Conversions.ToDecimal(r["Amount"]) * VATRateDecimal);
                                        payload.Ledger.Add(netLine);
                                        payload.Ledger.Add(vatLine);
                                        payload.Ledger.Add(grossLine);
                                        await App.DB.Invoiced.MarkInvoiceAsExportedAsync(Conversions.ToInteger(r["InvoicedID"]));
                                    }
                                }
                            }
                            else
                            {
                                await App.DB.Invoiced.MarkInvoiceAsExportedAsync(Conversions.ToInteger(r["InvoicedID"]));
                            }
                        }
                    }

                    var SSC = new Entity.Accounts.SSC();
                    SSC.Payload = payload;
                    if (SSC.SaveToXml())
                    {
                        MessageBox.Show("Export Completed!", "Completion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    PopulateDatagrid();
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
            }
        }

        private async void tsmiSageExport_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                var t = new DataTable();
                t.Columns.Add("Type"); // always "SI" for fsm invoices
                t.Columns.Add("AccountNumber");
                t.Columns.Add("NominalCode"); // depends on [JobDefinition]
                t.Columns.Add("DepartmentCode");
                t.Columns.Add("RaisedDate");
                t.Columns.Add("InvoiceNumber");
                t.Columns.Add("Description"); // always Address1<space>Address2 unless both blank then always "FSM Invoice"
                t.Columns.Add("Amount"); // (amount before vat)
                t.Columns.Add("VATCode"); // always "T1" for fsm invoices
                t.Columns.Add("VATAmount");
                t.Columns.Add("ExchangeRate");
                t.Columns.Add("ExtraRef");
                var accountingPeriodDate = new DateTime(Conversions.ToDate(txtSageMonth.Text).Year, Conversions.ToDate(txtSageMonth.Text).Month, 1);
                if (InvoicesDataview is object)
                {
                    DataRow nw;
                    foreach (DataRow r in InvoicesDataview.Table.Rows)
                    {
                        if (Conversions.ToBoolean(r["ExportedToSage"]) == false) // don't export if already marked as done or nill value
                        {
                            if (Conversions.ToDouble(r["Amount"]) > 0.0)
                            {
                                if (Conversions.ToBoolean(r["tick"]))
                                {
                                    string custType = string.Empty;
                                    var switchExpr = r["InvoiceType"].ToString();
                                    switch (switchExpr)
                                    {
                                        case "Supplier":
                                        case "Part Credit":
                                        case "Consolidation":
                                            {
                                                custType = "Supplier";
                                                break;
                                            }

                                        default:
                                            {
                                                custType = "Customer";
                                                break;
                                            }
                                    }

                                    bool purchases = (custType ?? "") == "Supplier" ? true : false;
                                    if (Conversions.ToDate(Strings.Format(r["Raiseddate"], "dd/MM/yyyy")) < accountingPeriodDate & !purchases)
                                    {
                                        App.ShowMessage("A invoice has been stopped in the export as it is for a diffent month to the current processing month.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        nw = t.NewRow();
                                        nw["AccountNumber"] = r["AccountNumber"];
                                        nw["NominalCode"] = r["NominalCode"];
                                        nw["DepartmentCode"] = r["Department"];
                                        nw["RaisedDate"] = Strings.Format(Conversions.ToDate(r["RaisedDate"]), "dd/MM/yyyy");
                                        nw["InvoiceNumber"] = r["InvoiceNumber"];
                                        nw["Amount"] = r["Amount"];
                                        nw["ExchangeRate"] = 1;
                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Supplier", false)))
                                        {
                                            nw["VatAmount"] = Strings.Format(Conversions.ToDecimal(r["VATAmount"]), "f");
                                            nw["Type"] = "PI";
                                            nw["Description"] = r["JobNumber"];
                                            nw["VATCode"] = r["Tax_Code"];
                                            nw["ExtraRef"] = r["ExtraRef"];
                                            await App.DB.Invoiced.MarkOrderAsExportedAsync(Conversions.ToInteger(r["SupplierInvoiceID"]));
                                        }
                                        else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Part Credit", false)))
                                        {
                                            nw["VatAmount"] = Strings.Format(Conversions.ToDecimal(r["VATAmount"]), "f");
                                            nw["Type"] = "PC";
                                            nw["Description"] = r["JobNumber"];
                                            nw["VATCode"] = r["Tax_Code"];
                                            nw["ExtraRef"] = r["ExtraRef"];
                                            nw["InvoiceNumber"] = r["SupplierCreditRef"];
                                            await App.DB.Invoiced.MarkPartCreditedAsExportedAsync(Conversions.ToInteger(r["OrderID"]), Conversions.ToInteger(r["LinkID"]));
                                        }
                                        else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Consolidation", false)))
                                        {
                                            nw["VatAmount"] = Strings.Format(Conversions.ToDecimal(r["VATAmount"]), "f");
                                            nw["Type"] = "PI";
                                            nw["Description"] = r["JobNumber"];
                                            nw["VATCode"] = r["Tax_Code"];
                                            nw["ExtraRef"] = r["ExtraRef"];

                                            // OrderID holds the consolidated order id
                                            await App.DB.Invoiced.MarkConsolidatedOrderAsExportedAsync(Conversions.ToInteger(r["OrderID"]));
                                        }
                                        else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["InvoiceType"], "Sales Credit", false)))
                                        {
                                            decimal VATRate = Conversions.ToDecimal(r["VATRATE"]);
                                            decimal VATRateDecimal = VATRate / 100;
                                            nw["VatAmount"] = Strings.Format(Conversions.ToDecimal(r["Amount"]) * VATRateDecimal, "f");

                                            // nw("VatAmount") = Format(CDec(r("VATAmount")), "f")
                                            nw["Type"] = "SC";
                                            nw["Description"] = "Credit Against Invoice : " + r["JobNumber"];
                                            nw["VATCode"] = r["Tax_Code"];
                                            nw["ExtraRef"] = r["ExtraRef"];
                                            nw["InvoiceNumber"] = r["SupplierCreditRef"];
                                            // LinkID holds the SalescreditID
                                            await App.DB.Invoiced.MarkSalesCreditAsExportedAsync(Conversions.ToInteger(r["LinkID"]));
                                        }
                                        else
                                        {
                                            decimal VATRate = Conversions.ToDecimal(r["VATRATE"]);
                                            decimal VATRateDecimal = VATRate / 100;
                                            nw["VatAmount"] = Strings.Format(Conversions.ToDecimal(r["Amount"]) * VATRateDecimal, "f");
                                            string description = "";
                                            description += Helper.MakeStringValid(r["Address1"]).Trim().Replace(",", "");
                                            description += " ";
                                            description += Helper.MakeStringValid(r["Address2"]).Trim().Replace(",", "");
                                            description += "- " + Helper.MakeStringValid(r["PolicyNumber"]).Trim().Replace(",", "");
                                            if (description.Trim().Length == 0)
                                            {
                                                description = "FSM INVOICE";
                                            }

                                            nw["Type"] = "SI";
                                            nw["Description"] = description;
                                            nw["VATCode"] = r["Tax_Code"]; // T1
                                            nw["ExtraRef"] = r["JobNumber"];
                                            await App.DB.Invoiced.MarkInvoiceAsExportedAsync(Conversions.ToInteger(r["InvoicedID"]));
                                        }

                                        t.Rows.Add(nw);
                                    }
                                }
                            }
                            else
                            {
                                await App.DB.Invoiced.MarkInvoiceAsExportedAsync(Conversions.ToInteger(r["InvoicedID"]));
                            }
                        }
                    }

                    if (t.Rows.Count > 0)
                    {
                        var csv = new CSVExporter();
                        csv.CreateCSV(new DataView(t));
                        MessageBox.Show("Export complete", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show("Please select invoices to export.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }

                PopulateDatagrid();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
            }
        }

        private void chkExportedOn_Click(object sender, EventArgs e)
        {
            chkExportedOn.Checked = !chkExportedOn.Checked;
            dtpExportedOn.Enabled = chkExportedOn.Checked;
        }
    }
}