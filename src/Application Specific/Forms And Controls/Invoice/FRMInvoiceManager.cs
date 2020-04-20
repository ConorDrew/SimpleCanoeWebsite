using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FSM.Entity.Customers;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FRMInvoiceManager : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMInvoiceManager() : base()
        {
            base.Load += FRMInvoiceManager_Load;

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

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _dgInvoices.DoubleClick -= dgInvoices_DoubleClick;
                    _dgInvoices.MouseUp -= dgInvoices_MouseUp;
                }

                _dgInvoices = value;
                if (_dgInvoices != null)
                {
                    _dgInvoices.DoubleClick += dgInvoices_DoubleClick;
                    _dgInvoices.MouseUp += dgInvoices_MouseUp;
                }
            }
        }

        private GroupBox _grpFilter;

        internal GroupBox grpFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpFilter != null)
                {
                }

                _grpFilter = value;
                if (_grpFilter != null)
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

        private Label _lblCustomers;

        internal Label lblCustomers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCustomers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCustomers != null)
                {
                }

                _lblCustomers = value;
                if (_lblCustomers != null)
                {
                }
            }
        }

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

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    _txtPostcode.KeyDown -= txtJobNumber_TextChanged;
                }

                _txtPostcode = value;
                if (_txtPostcode != null)
                {
                    _txtPostcode.KeyDown += txtJobNumber_TextChanged;
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

        private Button _btnFindSite;

        internal Button btnFindSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindSite != null)
                {
                    _btnFindSite.Click -= btnFindSite_Click;
                }

                _btnFindSite = value;
                if (_btnFindSite != null)
                {
                    _btnFindSite.Click += btnFindSite_Click;
                }
            }
        }

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

        private DateTimePicker _dtpTo;

        internal DateTimePicker dtpTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpTo != null)
                {
                }

                _dtpTo = value;
                if (_dtpTo != null)
                {
                }
            }
        }

        private DateTimePicker _dtpFrom;

        internal DateTimePicker dtpFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpFrom != null)
                {
                }

                _dtpFrom = value;
                if (_dtpFrom != null)
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

        private Label _Label8;

        internal Label Label8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label8 != null)
                {
                }

                _Label8 = value;
                if (_Label8 != null)
                {
                }
            }
        }

        private Label _Label6;

        internal Label Label6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label6 != null)
                {
                }

                _Label6 = value;
                if (_Label6 != null)
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

        private Button _btnPrintOneItemOneInvoice;

        internal Button btnPrintOneItemOneInvoice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrintOneItemOneInvoice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrintOneItemOneInvoice != null)
                {
                    _btnPrintOneItemOneInvoice.Click -= btnPrintOneItemOneInvoice_Click;
                }

                _btnPrintOneItemOneInvoice = value;
                if (_btnPrintOneItemOneInvoice != null)
                {
                    _btnPrintOneItemOneInvoice.Click += btnPrintOneItemOneInvoice_Click;
                }
            }
        }

        private Button _btnPrintManyItemsOnOneInvoice;

        internal Button btnPrintManyItemsOnOneInvoice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrintManyItemsOnOneInvoice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrintManyItemsOnOneInvoice != null)
                {
                    _btnPrintManyItemsOnOneInvoice.Click -= btnPrintManyItemsOnOneInvoice_Click;
                }

                _btnPrintManyItemsOnOneInvoice = value;
                if (_btnPrintManyItemsOnOneInvoice != null)
                {
                    _btnPrintManyItemsOnOneInvoice.Click += btnPrintManyItemsOnOneInvoice_Click;
                }
            }
        }

        private Button _btnAddInvoiceAddress;

        internal Button btnAddInvoiceAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddInvoiceAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddInvoiceAddress != null)
                {
                    _btnAddInvoiceAddress.Click -= btnAddInvoiceAddress_Click;
                }

                _btnAddInvoiceAddress = value;
                if (_btnAddInvoiceAddress != null)
                {
                    _btnAddInvoiceAddress.Click += btnAddInvoiceAddress_Click;
                }
            }
        }

        private Button _btnSearch;

        internal Button btnSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSearch != null)
                {
                    _btnSearch.Click -= btnSearch_Click;
                }

                _btnSearch = value;
                if (_btnSearch != null)
                {
                    _btnSearch.Click += btnSearch_Click;
                }
            }
        }

        private Button _btnBackToVisitManager;

        internal Button btnBackToVisitManager
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnBackToVisitManager;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnBackToVisitManager != null)
                {
                    _btnBackToVisitManager.Click -= btnBackToVisitManager_Click;
                }

                _btnBackToVisitManager = value;
                if (_btnBackToVisitManager != null)
                {
                    _btnBackToVisitManager.Click += btnBackToVisitManager_Click;
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

        private Button _Button1;

        internal Button Button1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button1 != null)
                {
                    _Button1.Click -= Button1_Click;
                }

                _Button1 = value;
                if (_Button1 != null)
                {
                    _Button1.Click += Button1_Click;
                }
            }
        }

        private ContextMenuStrip _ContextMenuStrip1;

        internal ContextMenuStrip ContextMenuStrip1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ContextMenuStrip1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ContextMenuStrip1 != null)
                {
                }

                _ContextMenuStrip1 = value;
                if (_ContextMenuStrip1 != null)
                {
                }
            }
        }

        private ToolStripMenuItem _ts1;

        internal ToolStripMenuItem ts1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ts1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ts1 != null)
                {
                    _ts1.Click -= ts1_Click;
                }

                _ts1 = value;
                if (_ts1 != null)
                {
                    _ts1.Click += ts1_Click;
                }
            }
        }

        private ToolStripMenuItem _ts2;

        internal ToolStripMenuItem ts2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ts2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ts2 != null)
                {
                    _ts2.Click -= ts2_Click;
                }

                _ts2 = value;
                if (_ts2 != null)
                {
                    _ts2.Click += ts2_Click;
                }
            }
        }

        private ToolStripMenuItem _RaiseProFormaToolStripMenuItem;

        internal ToolStripMenuItem RaiseProFormaToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _RaiseProFormaToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_RaiseProFormaToolStripMenuItem != null)
                {
                    _RaiseProFormaToolStripMenuItem.Click -= RaiseProFormaToolStripMenuItem_Click;
                }

                _RaiseProFormaToolStripMenuItem = value;
                if (_RaiseProFormaToolStripMenuItem != null)
                {
                    _RaiseProFormaToolStripMenuItem.Click += RaiseProFormaToolStripMenuItem_Click;
                }
            }
        }

        private Button _btnChangeLine;

        internal Button btnChangeLine
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnChangeLine;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnChangeLine != null)
                {
                    _btnChangeLine.Click -= btnChangeLine_Click;
                }

                _btnChangeLine = value;
                if (_btnChangeLine != null)
                {
                    _btnChangeLine.Click += btnChangeLine_Click;
                }
            }
        }

        private Label _lblDept;

        internal Label lblDept
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDept;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDept != null)
                {
                }

                _lblDept = value;
                if (_lblDept != null)
                {
                }
            }
        }

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

        private TextBox _txtAccNo;

        internal TextBox txtAccNo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAccNo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAccNo != null)
                {
                }

                _txtAccNo = value;
                if (_txtAccNo != null)
                {
                }
            }
        }

        private Label _lblAccNo;

        internal Label lblAccNo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAccNo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAccNo != null)
                {
                }

                _lblAccNo = value;
                if (_lblAccNo != null)
                {
                }
            }
        }

        private Button _btnView;

        internal Button btnView
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnView;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnView != null)
                {
                    _btnView.Click -= btnView_Click;
                }

                _btnView = value;
                if (_btnView != null)
                {
                    _btnView.Click += btnView_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            _grpInvoices = new GroupBox();
            _btnChangeLine = new Button();
            _btnChangeLine.Click += new EventHandler(btnChangeLine_Click);
            _btnBackToVisitManager = new Button();
            _btnBackToVisitManager.Click += new EventHandler(btnBackToVisitManager_Click);
            _dgInvoices = new DataGrid();
            _dgInvoices.DoubleClick += new EventHandler(dgInvoices_DoubleClick);
            _dgInvoices.MouseUp += new MouseEventHandler(dgInvoices_MouseUp);
            _btnSelectAll = new Button();
            _btnSelectAll.Click += new EventHandler(btnSelectAll_Click);
            _btnDeselectAll = new Button();
            _btnDeselectAll.Click += new EventHandler(btnDeselectAll_Click);
            _grpFilter = new GroupBox();
            _txtAccNo = new TextBox();
            _lblAccNo = new Label();
            _lblDept = new Label();
            _cboDept = new ComboBox();
            _Label13 = new Label();
            _cboRegion = new ComboBox();
            _btnSearch = new Button();
            _btnSearch.Click += new EventHandler(btnSearch_Click);
            _btnFindCustomer = new Button();
            _btnFindCustomer.Click += new EventHandler(btnFindCustomer_Click);
            _txtCustomer = new TextBox();
            _lblCustomers = new Label();
            _txtPostcode = new TextBox();
            _txtPostcode.KeyDown += new KeyEventHandler(txtJobNumber_TextChanged);
            _Label1 = new Label();
            _btnFindSite = new Button();
            _btnFindSite.Click += new EventHandler(btnFindSite_Click);
            _txtSite = new TextBox();
            _dtpTo = new DateTimePicker();
            _dtpFrom = new DateTimePicker();
            _txtJobNumber = new TextBox();
            _txtJobNumber.KeyDown += new KeyEventHandler(txtJobNumber_TextChanged);
            _Label9 = new Label();
            _Label8 = new Label();
            _Label6 = new Label();
            _Label2 = new Label();
            _Label10 = new Label();
            _cboType = new ComboBox();
            _btnExport = new Button();
            _btnExport.Click += new EventHandler(btnExport_Click);
            _btnReset = new Button();
            _btnReset.Click += new EventHandler(btnReset_Click);
            _btnPrintOneItemOneInvoice = new Button();
            _btnPrintOneItemOneInvoice.Click += new EventHandler(btnPrintOneItemOneInvoice_Click);
            _btnPrintManyItemsOnOneInvoice = new Button();
            _btnPrintManyItemsOnOneInvoice.Click += new EventHandler(btnPrintManyItemsOnOneInvoice_Click);
            _btnAddInvoiceAddress = new Button();
            _btnAddInvoiceAddress.Click += new EventHandler(btnAddInvoiceAddress_Click);
            _btnView = new Button();
            _btnView.Click += new EventHandler(btnView_Click);
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            _ContextMenuStrip1 = new ContextMenuStrip(components);
            _ts1 = new ToolStripMenuItem();
            _ts1.Click += new EventHandler(ts1_Click);
            _ts2 = new ToolStripMenuItem();
            _ts2.Click += new EventHandler(ts2_Click);
            _RaiseProFormaToolStripMenuItem = new ToolStripMenuItem();
            _RaiseProFormaToolStripMenuItem.Click += new EventHandler(RaiseProFormaToolStripMenuItem_Click);
            _grpInvoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgInvoices).BeginInit();
            _grpFilter.SuspendLayout();
            _ContextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // grpInvoices
            // 
            _grpInvoices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpInvoices.Controls.Add(_btnChangeLine);
            _grpInvoices.Controls.Add(_btnBackToVisitManager);
            _grpInvoices.Controls.Add(_dgInvoices);
            _grpInvoices.Controls.Add(_btnSelectAll);
            _grpInvoices.Controls.Add(_btnDeselectAll);
            _grpInvoices.Location = new Point(8, 186);
            _grpInvoices.Name = "grpInvoices";
            _grpInvoices.Size = new Size(1182, 324);
            _grpInvoices.TabIndex = 3;
            _grpInvoices.TabStop = false;
            _grpInvoices.Text = "Items Ready To Be Invoiced";
            // 
            // btnChangeLine
            // 
            _btnChangeLine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnChangeLine.Location = new Point(848, 20);
            _btnChangeLine.Name = "btnChangeLine";
            _btnChangeLine.Size = new Size(160, 23);
            _btnChangeLine.TabIndex = 22;
            _btnChangeLine.Text = "Change Line";
            // 
            // btnBackToVisitManager
            // 
            _btnBackToVisitManager.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnBackToVisitManager.Location = new Point(1014, 20);
            _btnBackToVisitManager.Name = "btnBackToVisitManager";
            _btnBackToVisitManager.Size = new Size(160, 23);
            _btnBackToVisitManager.TabIndex = 21;
            _btnBackToVisitManager.Text = "Back To Visit Manager";
            // 
            // dgInvoices
            // 
            _dgInvoices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgInvoices.DataMember = "";
            _dgInvoices.HeaderForeColor = SystemColors.ControlText;
            _dgInvoices.Location = new Point(8, 49);
            _dgInvoices.Name = "dgInvoices";
            _dgInvoices.Size = new Size(1166, 267);
            _dgInvoices.TabIndex = 14;
            // 
            // btnSelectAll
            // 
            _btnSelectAll.AccessibleDescription = "Export Job List To Excel";
            _btnSelectAll.Location = new Point(7, 20);
            _btnSelectAll.Name = "btnSelectAll";
            _btnSelectAll.Size = new Size(88, 23);
            _btnSelectAll.TabIndex = 19;
            _btnSelectAll.Text = "Select All";
            // 
            // btnDeselectAll
            // 
            _btnDeselectAll.Location = new Point(103, 20);
            _btnDeselectAll.Name = "btnDeselectAll";
            _btnDeselectAll.Size = new Size(88, 23);
            _btnDeselectAll.TabIndex = 20;
            _btnDeselectAll.Text = "Deselect All";
            // 
            // grpFilter
            // 
            _grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpFilter.Controls.Add(_txtAccNo);
            _grpFilter.Controls.Add(_lblAccNo);
            _grpFilter.Controls.Add(_lblDept);
            _grpFilter.Controls.Add(_cboDept);
            _grpFilter.Controls.Add(_Label13);
            _grpFilter.Controls.Add(_cboRegion);
            _grpFilter.Controls.Add(_btnSearch);
            _grpFilter.Controls.Add(_btnFindCustomer);
            _grpFilter.Controls.Add(_txtCustomer);
            _grpFilter.Controls.Add(_lblCustomers);
            _grpFilter.Controls.Add(_txtPostcode);
            _grpFilter.Controls.Add(_Label1);
            _grpFilter.Controls.Add(_btnFindSite);
            _grpFilter.Controls.Add(_txtSite);
            _grpFilter.Controls.Add(_dtpTo);
            _grpFilter.Controls.Add(_dtpFrom);
            _grpFilter.Controls.Add(_txtJobNumber);
            _grpFilter.Controls.Add(_Label9);
            _grpFilter.Controls.Add(_Label8);
            _grpFilter.Controls.Add(_Label6);
            _grpFilter.Controls.Add(_Label2);
            _grpFilter.Controls.Add(_Label10);
            _grpFilter.Controls.Add(_cboType);
            _grpFilter.Location = new Point(8, 32);
            _grpFilter.Name = "grpFilter";
            _grpFilter.Size = new Size(1182, 155);
            _grpFilter.TabIndex = 4;
            _grpFilter.TabStop = false;
            _grpFilter.Text = "Filter";
            // 
            // txtAccNo
            // 
            _txtAccNo.Location = new Point(742, 123);
            _txtAccNo.Name = "txtAccNo";
            _txtAccNo.Size = new Size(160, 21);
            _txtAccNo.TabIndex = 41;
            // 
            // lblAccNo
            // 
            _lblAccNo.Location = new Point(606, 126);
            _lblAccNo.Name = "lblAccNo";
            _lblAccNo.Size = new Size(84, 16);
            _lblAccNo.TabIndex = 40;
            _lblAccNo.Text = "Acc No";
            // 
            // lblDept
            // 
            _lblDept.Location = new Point(328, 123);
            _lblDept.Name = "lblDept";
            _lblDept.Size = new Size(84, 16);
            _lblDept.TabIndex = 38;
            _lblDept.Text = "Cost Centre";
            // 
            // cboDept
            // 
            _cboDept.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboDept.Location = new Point(418, 123);
            _cboDept.Name = "cboDept";
            _cboDept.Size = new Size(160, 21);
            _cboDept.TabIndex = 39;
            // 
            // Label13
            // 
            _Label13.Location = new Point(8, 123);
            _Label13.Name = "Label13";
            _Label13.Size = new Size(72, 16);
            _Label13.TabIndex = 37;
            _Label13.Text = "Region";
            // 
            // cboRegion
            // 
            _cboRegion.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboRegion.Location = new Point(160, 120);
            _cboRegion.Name = "cboRegion";
            _cboRegion.Size = new Size(160, 21);
            _cboRegion.TabIndex = 36;
            // 
            // btnSearch
            // 
            _btnSearch.AccessibleDescription = "Export Job List To Excel";
            _btnSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSearch.Location = new Point(1014, 123);
            _btnSearch.Name = "btnSearch";
            _btnSearch.Size = new Size(120, 23);
            _btnSearch.TabIndex = 28;
            _btnSearch.Text = "Run Filter";
            // 
            // btnFindCustomer
            // 
            _btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindCustomer.BackColor = Color.White;
            _btnFindCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindCustomer.Location = new Point(1142, 48);
            _btnFindCustomer.Name = "btnFindCustomer";
            _btnFindCustomer.Size = new Size(32, 23);
            _btnFindCustomer.TabIndex = 2;
            _btnFindCustomer.Text = "...";
            _btnFindCustomer.UseVisualStyleBackColor = false;
            // 
            // txtCustomer
            // 
            _txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtCustomer.Location = new Point(160, 48);
            _txtCustomer.Name = "txtCustomer";
            _txtCustomer.ReadOnly = true;
            _txtCustomer.Size = new Size(974, 21);
            _txtCustomer.TabIndex = 1;
            // 
            // lblCustomers
            // 
            _lblCustomers.Location = new Point(8, 48);
            _lblCustomers.Name = "lblCustomers";
            _lblCustomers.Size = new Size(72, 21);
            _lblCustomers.TabIndex = 27;
            _lblCustomers.Text = "Customers";
            // 
            // txtPostcode
            // 
            _txtPostcode.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtPostcode.Location = new Point(160, 96);
            _txtPostcode.Name = "txtPostcode";
            _txtPostcode.Size = new Size(160, 21);
            _txtPostcode.TabIndex = 5;
            // 
            // Label1
            // 
            _Label1.Location = new Point(8, 96);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(64, 16);
            _Label1.TabIndex = 20;
            _Label1.Text = "Postcode";
            // 
            // btnFindSite
            // 
            _btnFindSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindSite.BackColor = Color.White;
            _btnFindSite.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindSite.Location = new Point(1142, 72);
            _btnFindSite.Name = "btnFindSite";
            _btnFindSite.Size = new Size(32, 23);
            _btnFindSite.TabIndex = 4;
            _btnFindSite.Text = "...";
            _btnFindSite.UseVisualStyleBackColor = false;
            // 
            // txtSite
            // 
            _txtSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSite.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtSite.Location = new Point(160, 72);
            _txtSite.Name = "txtSite";
            _txtSite.ReadOnly = true;
            _txtSite.Size = new Size(974, 21);
            _txtSite.TabIndex = 3;
            // 
            // dtpTo
            // 
            _dtpTo.Location = new Point(376, 24);
            _dtpTo.Name = "dtpTo";
            _dtpTo.Size = new Size(160, 21);
            _dtpTo.TabIndex = 13;
            // 
            // dtpFrom
            // 
            _dtpFrom.Location = new Point(160, 24);
            _dtpFrom.Name = "dtpFrom";
            _dtpFrom.Size = new Size(160, 21);
            _dtpFrom.TabIndex = 12;
            // 
            // txtJobNumber
            // 
            _txtJobNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtJobNumber.Location = new Point(742, 96);
            _txtJobNumber.Name = "txtJobNumber";
            _txtJobNumber.Size = new Size(392, 21);
            _txtJobNumber.TabIndex = 9;
            // 
            // Label9
            // 
            _Label9.Location = new Point(336, 24);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(48, 16);
            _Label9.TabIndex = 10;
            _Label9.Text = "and";
            // 
            // Label8
            // 
            _Label8.Location = new Point(8, 24);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(144, 16);
            _Label8.TabIndex = 9;
            _Label8.Text = "To Raise Date Between : ";
            // 
            // Label6
            // 
            _Label6.Location = new Point(606, 99);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(136, 16);
            _Label6.TabIndex = 6;
            _Label6.Text = "Job/Order/Contract No";
            // 
            // Label2
            // 
            _Label2.Location = new Point(8, 72);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(64, 16);
            _Label2.TabIndex = 2;
            _Label2.Text = "Property";
            // 
            // Label10
            // 
            _Label10.Location = new Point(328, 96);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(48, 16);
            _Label10.TabIndex = 4;
            _Label10.Text = "Type";
            // 
            // cboType
            // 
            _cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboType.Location = new Point(418, 96);
            _cboType.Name = "cboType";
            _cboType.Size = new Size(160, 21);
            _cboType.TabIndex = 7;
            // 
            // btnExport
            // 
            _btnExport.AccessibleDescription = "Export Job List To Excel";
            _btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnExport.Location = new Point(8, 518);
            _btnExport.Name = "btnExport";
            _btnExport.Size = new Size(56, 23);
            _btnExport.TabIndex = 17;
            _btnExport.Text = "Export";
            // 
            // btnReset
            // 
            _btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnReset.Location = new Point(72, 518);
            _btnReset.Name = "btnReset";
            _btnReset.Size = new Size(56, 23);
            _btnReset.TabIndex = 18;
            _btnReset.Text = "Reset";
            // 
            // btnPrintOneItemOneInvoice
            // 
            _btnPrintOneItemOneInvoice.AccessibleDescription = "Export Job List To Excel";
            _btnPrintOneItemOneInvoice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnPrintOneItemOneInvoice.Location = new Point(136, 518);
            _btnPrintOneItemOneInvoice.Name = "btnPrintOneItemOneInvoice";
            _btnPrintOneItemOneInvoice.Size = new Size(216, 23);
            _btnPrintOneItemOneInvoice.TabIndex = 21;
            _btnPrintOneItemOneInvoice.Text = "Print One Item One Invoice";
            // 
            // btnPrintManyItemsOnOneInvoice
            // 
            _btnPrintManyItemsOnOneInvoice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnPrintManyItemsOnOneInvoice.Location = new Point(360, 518);
            _btnPrintManyItemsOnOneInvoice.Name = "btnPrintManyItemsOnOneInvoice";
            _btnPrintManyItemsOnOneInvoice.Size = new Size(216, 23);
            _btnPrintManyItemsOnOneInvoice.TabIndex = 22;
            _btnPrintManyItemsOnOneInvoice.Text = "Print Many Items on One Invoice";
            // 
            // btnAddInvoiceAddress
            // 
            _btnAddInvoiceAddress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAddInvoiceAddress.Location = new Point(584, 518);
            _btnAddInvoiceAddress.Name = "btnAddInvoiceAddress";
            _btnAddInvoiceAddress.Size = new Size(160, 23);
            _btnAddInvoiceAddress.TabIndex = 23;
            _btnAddInvoiceAddress.Text = "Add Invoice Address";
            // 
            // btnView
            // 
            _btnView.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnView.Location = new Point(1060, 518);
            _btnView.Name = "btnView";
            _btnView.Size = new Size(130, 23);
            _btnView.TabIndex = 24;
            _btnView.Text = "View";
            // 
            // Button1
            // 
            _Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Button1.ContextMenuStrip = _ContextMenuStrip1;
            _Button1.Location = new Point(750, 518);
            _Button1.Name = "Button1";
            _Button1.Size = new Size(169, 23);
            _Button1.TabIndex = 26;
            _Button1.Text = "Raise Alternative Doc";
            // 
            // ContextMenuStrip1
            // 
            _ContextMenuStrip1.Items.AddRange(new ToolStripItem[] { _ts1, _ts2, _RaiseProFormaToolStripMenuItem });
            _ContextMenuStrip1.Name = "ContextMenuStrip1";
            _ContextMenuStrip1.Size = new Size(173, 70);
            // 
            // ts1
            // 
            _ts1.Name = "ts1";
            _ts1.Size = new Size(172, 22);
            _ts1.Text = "Missed DD Invoice";
            // 
            // ts2
            // 
            _ts2.Name = "ts2";
            _ts2.Size = new Size(172, 22);
            _ts2.Text = "Missed DD Receipt";
            // 
            // RaiseProFormaToolStripMenuItem
            // 
            _RaiseProFormaToolStripMenuItem.Name = "RaiseProFormaToolStripMenuItem";
            _RaiseProFormaToolStripMenuItem.Size = new Size(172, 22);
            _RaiseProFormaToolStripMenuItem.Text = "Raise Pro-Forma";
            // 
            // FRMInvoiceManager
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(1198, 548);
            Controls.Add(_Button1);
            Controls.Add(_btnView);
            Controls.Add(_btnAddInvoiceAddress);
            Controls.Add(_btnPrintOneItemOneInvoice);
            Controls.Add(_btnPrintManyItemsOnOneInvoice);
            Controls.Add(_btnExport);
            Controls.Add(_btnReset);
            Controls.Add(_grpFilter);
            Controls.Add(_grpInvoices);
            Name = "FRMInvoiceManager";
            Text = "Ready To Be Invoice Manager";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpInvoices, 0);
            Controls.SetChildIndex(_grpFilter, 0);
            Controls.SetChildIndex(_btnReset, 0);
            Controls.SetChildIndex(_btnExport, 0);
            Controls.SetChildIndex(_btnPrintManyItemsOnOneInvoice, 0);
            Controls.SetChildIndex(_btnPrintOneItemOneInvoice, 0);
            Controls.SetChildIndex(_btnAddInvoiceAddress, 0);
            Controls.SetChildIndex(_btnView, 0);
            Controls.SetChildIndex(_Button1, 0);
            _grpInvoices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgInvoices).EndInit();
            _grpFilter.ResumeLayout(false);
            _grpFilter.PerformLayout();
            _ContextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupInvoiceDataGrid();
            ResetFilters();
            try
            {
                if (get_GetParameter(2) is object && get_GetParameter(2).GetType().Equals(typeof(DataTable)))
                {
                    dtVisitFilters = (DataTable)get_GetParameter(2);
                }

                if (get_GetParameter(0) is object)
                {
                    if (Conversions.ToBoolean(get_GetParameter(0).Table.rows.count > 0))
                    {
                        dtpFrom.Value = Conversions.ToDate(get_GetParameter(0).Table.Select("RaiseDate = MIN(RaiseDate)")(0).Item("RaiseDate"));
                        dtpTo.Value = Conversions.ToDate(get_GetParameter(0).Table.Select("RaiseDate = MAX(RaiseDate)")(0).Item("RaiseDate"));
                    }

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

        private void ResetMe(int newID)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataTable _dtVisit = new DataTable();

        public DataTable dtVisitFilters
        {
            get
            {
                if (_dtVisit.Columns.Count == 0)
                {
                    _dtVisit.Columns.Add("Field");
                    _dtVisit.Columns.Add("Value");
                    _dtVisit.Columns.Add("Type");
                }

                return _dtVisit;
            }

            set
            {
                _dtVisit = value;
            }
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
                _dvInvoices.AllowEdit = false;
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

        private List<Customer> _customers = new List<Customer>();

        public List<Customer> Customers
        {
            get
            {
                return _customers;
            }

            set
            {
                _customers = value;
                theSite = null;
                if (_customers.Count > 0)
                {
                    string custText = string.Empty;
                    bool addComma = false;
                    foreach (Customer cust in _customers)
                    {
                        if (addComma)
                            custText += ", ";
                        custText += cust.Name + " (A/C No : " + cust.AccountNumber + ")";
                        addComma = true;
                    }

                    txtCustomer.Text = custText;
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

        public string DDpaidBy = "";

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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
            var Customer = new DataGridLabelColumn();
            Customer.Format = "";
            Customer.FormatInfo = null;
            Customer.HeaderText = "Customer";
            Customer.MappingName = "Customer";
            Customer.ReadOnly = true;
            Customer.Width = 100;
            Customer.NullText = "";
            tbStyle.GridColumnStyles.Add(Customer);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Property";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 100;
            Site.NullText = "";
            tbStyle.GridColumnStyles.Add(Site);
            var InvoiceType = new DataGridLabelColumn();
            InvoiceType.Format = "";
            InvoiceType.FormatInfo = null;
            InvoiceType.HeaderText = "Inv. Type";
            InvoiceType.MappingName = "InvoiceType";
            InvoiceType.ReadOnly = true;
            InvoiceType.Width = 70;
            InvoiceType.NullText = "";
            tbStyle.GridColumnStyles.Add(InvoiceType);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job/Order/Contract No.";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 140;
            JobNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(JobNumber);
            var RaiseDate = new DataGridLabelColumn();
            RaiseDate.Format = "dd/MMM/yyyy";
            RaiseDate.FormatInfo = null;
            RaiseDate.HeaderText = "Raise Date";
            RaiseDate.MappingName = "RaiseDate";
            RaiseDate.ReadOnly = true;
            RaiseDate.Width = 85;
            RaiseDate.NullText = "";
            tbStyle.GridColumnStyles.Add(RaiseDate);
            var InvoiceAddressType = new DataGridLabelColumn();
            InvoiceAddressType.Format = "";
            InvoiceAddressType.FormatInfo = null;
            InvoiceAddressType.HeaderText = "Inv. Addr. Type";
            InvoiceAddressType.MappingName = "InvoiceAddressType";
            InvoiceAddressType.ReadOnly = true;
            InvoiceAddressType.Width = 100;
            InvoiceAddressType.NullText = "";
            tbStyle.GridColumnStyles.Add(InvoiceAddressType);
            var InvoiceAddress = new DataGridLabelColumn();
            InvoiceAddress.Format = "";
            InvoiceAddress.FormatInfo = null;
            InvoiceAddress.HeaderText = "Invoice Address";
            InvoiceAddress.MappingName = "InvoiceAddress";
            InvoiceAddress.ReadOnly = true;
            InvoiceAddress.Width = 100;
            InvoiceAddress.NullText = "";
            tbStyle.GridColumnStyles.Add(InvoiceAddress);
            var dept = new DataGridLabelColumn();
            dept.Format = "";
            dept.FormatInfo = null;
            dept.HeaderText = "Department";
            dept.MappingName = "Department";
            dept.ReadOnly = true;
            dept.Width = 100;
            dept.NullText = "";
            tbStyle.GridColumnStyles.Add(dept);
            var Amount = new DataGridLabelColumn();
            Amount.Format = "C";
            Amount.FormatInfo = null;
            Amount.HeaderText = "Amount";
            Amount.MappingName = "Amount";
            Amount.ReadOnly = true;
            Amount.Width = 75;
            Amount.NullText = "";
            tbStyle.GridColumnStyles.Add(Amount);
            var vatCode = new DataGridLabelColumn();
            vatCode.Format = "";
            vatCode.FormatInfo = null;
            vatCode.HeaderText = "VAT Code";
            vatCode.MappingName = "VatCode";
            vatCode.ReadOnly = true;
            vatCode.Width = 75;
            vatCode.NullText = "";
            tbStyle.GridColumnStyles.Add(vatCode);
            var VAT = new DataGridLabelColumn();
            VAT.Format = "";
            VAT.FormatInfo = null;
            VAT.HeaderText = "VAT %";
            VAT.MappingName = "VAT";
            VAT.ReadOnly = true;
            VAT.Width = 75;
            VAT.NullText = "";
            tbStyle.GridColumnStyles.Add(VAT);
            tbStyle.ReadOnly = true;

            // dgInvoices.ReadOnly = False
            tbStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString();
            dgInvoices.TableStyles.Add(tbStyle);
        }

        private void dgInvoices_DoubleClick(object sender, EventArgs e)
        {
            view();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            view();
        }

        private void FRMInvoiceManager_Load(object sender, EventArgs e)
        {
            IsLoading = true;
            LoadMe(sender, e);
            IsLoading = false;
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
            var frmFindCust = new FRMFindCustomers();
            frmFindCust.ShowDialog();
            Customers = new List<Customer>();
            var dvCustomers = frmFindCust.CustomerDataView;
            var drCustomers = (from row in dvCustomers.Table.AsEnumerable()
                               where row.Field<bool>("Include") == true
                               select row).ToArray();
            var cIds = (from dr in drCustomers
                        select (Helper.MakeIntegerValid(dr["CustomerID"]))).ToList();
            foreach (int cId in cIds)
                Customers.Add(App.DB.Customer.Customer_Get(cId));
            Customers = Customers;
        }

        private void btnFindSite_Click(object sender, EventArgs e)
        {
            int ID;
            if (Customers.Count > 0)
            {
                ID = App.FindRecordMultiId(Enums.TableNames.tblSite, Customers.Select(x => x.CustomerID).Distinct().ToList());
            }
            else
            {
                ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite));
            }

            if (!(ID == 0))
            {
                theSite = App.DB.Sites.Get(ID);
                // RunFilter()
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
            foreach (DataRow dr in InvoicesDataview.Table.Select(InvoicesDataview.RowFilter))
                dr["tick"] = 1;
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in InvoicesDataview.Table.Rows)
                dr["tick"] = 0;
        }

        private void btnPrintOneItemOneInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                bool zeroInvoices = false;
                if (ValidateInvoiceAddress())
                {
                    FindPartPayJobs(false);
                    foreach (DataRow i in InvoicesDataview.Table.Rows)
                    {
                        if (Conversions.ToBoolean(Helper.MakeBooleanValid(i["tick"]) == true & !Operators.ConditionalCompareObjectEqual(i["PaymentTermID"], 69817, false)))
                        {
                            if (Helper.MakeDoubleValid(i["Amount"]) > 0)
                            {

                                // CHECK THAT ANOTHER USERS HASN'T GENERATED SINCE WE LAST REFRESHED OUR SCREEN

                                if (App.DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID(Conversions.ToInteger(i["InvoiceToBeRaisedID"])).Count == 0)
                                {
                                    var inv = new Entity.Invoiceds.Invoiced();
                                    // AMY IS CHEATING AND USING JOB NUMBER - 5 isn't a job definition!
                                    var invNum = new JobNumber();
                                    invNum = App.DB.Job.GetNextJobNumber((Enums.JobDefinition)5);
                                    inv.SetInvoiceNumber = invNum.Prefix + invNum.JobNumber;
                                    inv.SetRaisedByUserID = App.loggedInUser.UserID;
                                    inv.RaisedDate = Conversions.ToDate(i["RaiseDate"]);
                                    if (Conversions.ToBoolean(i["TAXRateID"] > 0))
                                    {
                                        inv.SetVATRateID = i["TAXRateID"];
                                    }
                                    else
                                    {
                                        inv.SetVATRateID = App.DB.VATRatesSQL.VATRates_Get_ByDate(DateAndTime.Now);
                                    }

                                    inv.SetPaymentTermID = i["PaymentTermID"];
                                    inv.SetPaidByID = i["PaidByID"];
                                    inv = App.DB.Invoiced.Insert(inv);
                                    var invLines = new Entity.InvoicedLiness.InvoicedLines();
                                    invLines.SetAmount = i["Amount"];
                                    invLines.SetInvoicedID = inv.InvoicedID;
                                    invLines.SetInvoiceToBeRaisedID = i["InvoiceToBeRaisedID"];
                                    invLines = App.DB.InvoicedLines.Insert(invLines);
                                    var PrintArray = new ArrayList();
                                    PrintArray.Add(inv.InvoicedID);
                                    PrintArray.Add(i["RegionID"]);
                                    InvoicesToPrint.Add(PrintArray);
                                }
                            }
                            else
                            {
                                zeroInvoices = true;
                            }
                        }
                    }

                    if (zeroInvoices)
                    {
                        App.ShowMessage("1 or more invoice could not be generated because they have a zero amount.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    Print();
                    PopulateDatagrid();
                }
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
                bool zeroInvoices = false;
                if (ValidateInvoiceAddress())
                {
                    FindPartPayJobs(true);
                    var dtDone = new DataTable();
                    dtDone.Columns.Add("AddressTypeID");
                    dtDone.Columns.Add("AddressID");
                    int lastVat = -1;
                    foreach (DataRow i in InvoicesDataview.Table.Select("tick = 1"))
                    {
                        if (lastVat > -1 && Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(lastVat, i["TAXRateID"], false)))
                        {
                            Interaction.MsgBox("Different VAT rates cannot be batched", MsgBoxStyle.OkOnly, "Ooops");
                            return;
                        }

                        lastVat = Conversions.ToInteger(i["TAXRateID"]);
                    }

                    var raiseDate = DateAndTime.Now;
                    var f = new FRMChangeRaiseDate();
                    f.dtpTaxDate.Value = raiseDate.Date;
                    f.ShowDialog();
                    if (f.DialogResult == DialogResult.OK)
                    {
                        raiseDate = f.dtpTaxDate.Value;
                    }
                    else
                    {
                        return;
                    }

                    foreach (DataRow i in InvoicesDataview.Table.Rows)
                    {
                        if (Conversions.ToBoolean(Helper.MakeBooleanValid(i["tick"]) == true & !Operators.ConditionalCompareObjectEqual(i["PAYMENTTERMID"], 69817, false))) // i("PAIDBYID") <> 69792
                        {
                            if (Helper.MakeDoubleValid(i["Amount"]) > 0)
                            {
                                if (App.DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID(Conversions.ToInteger(i["InvoiceToBeRaisedID"])).Count == 0)
                                {
                                    if (dtDone.Select(Conversions.ToString(Conversions.ToString("AddressTypeID=" + i["AddressTypeID"] + " AND AddressID=") + i["AddressID"])).Length == 0)
                                    {
                                        var drInv = InvoicesDataview.Table.Select(Conversions.ToString(Conversions.ToString("AddressTypeID=" + i["AddressTypeID"] + " AND AddressID=") + i["AddressID"] + " AND Tick = 1"));
                                        var inv = new Entity.Invoiceds.Invoiced();
                                        var invNum = new JobNumber();
                                        invNum = App.DB.Job.GetNextJobNumber((Enums.JobDefinition)5);
                                        inv.SetInvoiceNumber = invNum.Prefix + invNum.JobNumber;
                                        inv.SetRaisedByUserID = App.loggedInUser.UserID;
                                        inv.RaisedDate = raiseDate;
                                        inv.SetVATRateID = lastVat;
                                        inv = App.DB.Invoiced.Insert(inv);
                                        for (int j = 0, loopTo = drInv.Length - 1; j <= loopTo; j++)
                                        {
                                            var invLines = new Entity.InvoicedLiness.InvoicedLines();
                                            invLines.SetAmount = Helper.MakeDoubleValid(drInv[j]["Amount"]);
                                            invLines.SetInvoicedID = inv.InvoicedID;
                                            invLines.SetInvoiceToBeRaisedID = drInv[j]["InvoiceToBeRaisedID"];
                                            invLines = App.DB.InvoicedLines.Insert(invLines);
                                        }

                                        var PrintArray = new ArrayList();
                                        PrintArray.Add(inv.InvoicedID);
                                        PrintArray.Add(i["RegionID"]);
                                        InvoicesToPrint.Add(PrintArray);
                                        DataRow r;
                                        r = dtDone.NewRow();
                                        r["AddressTypeID"] = i["AddressTypeID"];
                                        r["AddressID"] = i["AddressID"];
                                        dtDone.Rows.Add(r);
                                    }
                                }
                            }
                            else
                            {
                                zeroInvoices = true;
                            }
                        }
                    }

                    if (zeroInvoices)
                    {
                        App.ShowMessage("1 or more invoice could not be generated because they have a zero amount.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    Print();
                    PopulateDatagrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddInvoiceAddress_Click(object sender, EventArgs e)
        {
            if (SelectedInvoiceDataRow is object)
            {
                if (Helper.MakeIntegerValid(SelectedInvoiceDataRow["AddressLinkID"]) == 0)
                {
                    App.ShowForm(typeof(FRMAddInvoiceAddress), true, new object[] { SelectedInvoiceDataRow["LinkID"], SelectedInvoiceDataRow["InvoiceToBeRaisedID"], this });
                }
                else
                {
                    MessageBox.Show("This line has an Invoice Address", "Invoice Address", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateDatagrid();
        }

        private void btnBackToVisitManager_Click(object sender, EventArgs e)
        {
            Navigation.Navigate(Enums.MenuTypes.Jobs);
            App.ShowForm(typeof(FRMVisitManager), false, new object[] { null, dtVisitFilters, "From Invoice Manager" });
            // {"FromInvoice"}
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void view()
        {
            if (SelectedInvoiceDataRow is object)
            {
                var switchExpr = Helper.MakeIntegerValid(SelectedInvoiceDataRow["InvoiceTypeID"]);
                switch (switchExpr)
                {
                    case (int)Enums.InvoiceType.Contract_Option1:
                        {
                            App.ShowForm(typeof(FRMContractOriginal), true, new object[] { Helper.MakeIntegerValid(SelectedInvoiceDataRow["ContractID"]), Helper.MakeIntegerValid(SelectedInvoiceDataRow["CustomerID"]), Helper.MakeIntegerValid(SelectedInvoiceDataRow["InvoiceToBeRaisedID"]) });
                            break;
                        }

                    case (int)Enums.InvoiceType.Order:
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
                            }

                            break;
                        }

                    case (int)Enums.InvoiceType.Visit:
                        {
                            App.ShowForm(typeof(FRMEngineerVisit), true, new object[] { Helper.MakeIntegerValid(SelectedInvoiceDataRow["EngineerVisitID"]) });
                            break;
                        }
                }

                PopulateDatagrid();
            }
            else
            {
                App.ShowMessage("Please select an invoice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PopulateDatagrid()
        {
            Cursor.Current = Cursors.WaitCursor;
            InvoicesDataview = App.DB.InvoiceToBeRaised.Invoices_GetAll_Manager(dtpFrom.Value, dtpTo.Value);
            RunFilter();
            Cursor.Current = Cursors.Default;
        }

        private void ResetFilters()
        {
            Customers = new List<Customer>();
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

            dtpFrom.Value = fromDate;
            dtpTo.Value = fromDate.AddDays(7);
            var argc = cboType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Enums.PickListTypes.InvoiceTypes).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
            var argcombo = cboType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            var argc1 = cboRegion;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
            switch (true)
            {
                case object _ when App.IsGasway:
                    {
                        var argc2 = cboDept;
                        Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }

                default:
                    {
                        var argc3 = cboDept;
                        Combo.SetUpCombo(ref argc3, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }
            }

            txtJobNumber.Text = "";
            txtPostcode.Text = "";
        }

        private void RunFilter()
        {
            if (InvoicesDataview is null)
            {
                return;
            }

            string whereClause = "1 = 1 ";
            if (Customers.Count > 0)
            {
                whereClause += " AND CustomerID IN (" + string.Join(", ", Customers.Select(x => x.CustomerID).Distinct()) + ")";
            }

            if (theSite is object)
            {
                whereClause += " AND SiteID = " + theSite.SiteID + "";
            }

            if (!(txtPostcode.Text.Trim().Length == 0))
            {
                whereClause += " AND Postcode LIKE '" + txtPostcode.Text.Trim() + "%'";
            }

            if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboType)) == 0))
            {
                whereClause += " AND InvoiceTypeID = " + Combo.get_GetSelectedItemValue(cboType) + "";
            }

            if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboRegion)) == 0))
            {
                whereClause += " AND RegionID = " + Combo.get_GetSelectedItemValue(cboRegion) + "";
            }

            string department = Helper.MakeStringValid(Combo.get_GetSelectedItemValue(cboDept));
            if (Helper.IsValidInteger(department) && !(Helper.MakeIntegerValid(department) <= 0))
            {
                whereClause += " AND Department = '" + department + "'";
            }
            else if (!Information.IsNumeric(department))
            {
                whereClause += " AND Department = '" + department + "'";
            }

            if (!(txtJobNumber.Text.Trim().Length == 0))
            {
                whereClause += " AND JobNumber LIKE '" + txtJobNumber.Text.Trim() + "%'";
            }

            if (!(txtAccNo.Text.Trim().Length == 0))
            {
                whereClause += " AND AccountNumber LIKE '" + txtAccNo.Text.Trim() + "%'";
            }

            InvoicesDataview.RowFilter = whereClause;
        }

        public void Export()
        {
            Cursor.Current = Cursors.WaitCursor;
            var exportData = new DataTable();
            exportData.Columns.Add("Customer");
            exportData.Columns.Add("Site");
            exportData.Columns.Add("InvoiceType");
            exportData.Columns.Add("JobNumber");
            exportData.Columns.Add("RaiseDate");
            exportData.Columns.Add("InvoiceAddressType");
            exportData.Columns.Add("InvoiceAddress");
            exportData.Columns.Add("SorDescription");
            exportData.Columns.Add("DDMSRef");
            exportData.Columns.Add("CostCentre");
            exportData.Columns.Add("VatCode");
            exportData.Columns.Add("Amount", typeof(double));
            foreach (DataRowView dr in (DataView)dgInvoices.DataSource)
            {
                var newRw = exportData.NewRow();
                newRw["Customer"] = dr["Customer"];
                newRw["Site"] = dr["Site"];
                newRw["InvoiceType"] = dr["InvoiceType"];
                newRw["JobNumber"] = dr["JobNumber"];
                newRw["RaiseDate"] = Strings.Format(dr["RaiseDate"], "dd/MM/yyyy");
                newRw["InvoiceAddressType"] = dr["InvoiceAddressType"];
                newRw["InvoiceAddress"] = dr["InvoiceAddress"];
                newRw["CostCentre"] = dr["Department"];
                newRw["VatCode"] = dr["VatCode"];
                newRw["DDMSRef"] = dr["DDMSRef"];
                int engineerVisitId = Helper.MakeIntegerValid(dr["EngineerVisitID"]);
                if (engineerVisitId > 0)
                {
                    var dvChargeBreakdown = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get_ChargedBreakDown(engineerVisitId);
                    string sorDescription = string.Join(" / ", dvChargeBreakdown.Table.AsEnumerable().Where(row => (row.Field<string>("Type") ?? "") == "SOR").Select(row => row.Field<string>("Description")).ToArray());
                    newRw["SorDescription"] = sorDescription;
                }
                else
                {
                    newRw["SorDescription"] = string.Empty;
                }

                newRw["Amount"] = dr["Amount"];
                exportData.Rows.Add(newRw);
            }

            ExportHelper.Export(exportData, "Invoice List", Enums.ExportType.XLS);
            Cursor.Current = Cursors.Default;
        }

        public bool ValidateInvoiceAddress()
        {
            string s = "The following lines are missing invoice addresses: " + Constants.vbCrLf;
            bool valid = true;
            foreach (DataRow i in InvoicesDataview.Table.Rows)
            {
                if (Helper.MakeBooleanValid(i["tick"]) == true)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(i["AddressLinkID"], 0, false)))
                    {
                        s += "* " + i["JobNumber"] + Constants.vbCrLf;
                        valid = false;
                    }
                }
            }

            if (valid == false)
            {
                MessageBox.Show(s, "Invoice Addresses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return valid;
        }

        public void Print()
        {
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

                                        bool exists = false;
                                        foreach (ArrayList al in InvoicesToPrint)
                                        {
                                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(al[0], dt.Rows[0]["InvoicedID"], false))) // check if the invoice id is already in....
                                            {
                                                exists = true;
                                            }
                                        }

                                        if (exists == false) // if not add it.
                                        {
                                            var PrintArray = new ArrayList();
                                            PrintArray.Add(dt.Rows[0]["InvoicedID"]);
                                            PrintArray.Add(dr["RegionID"]);
                                            InvoicesToPrint.Add(PrintArray);
                                        }
                                    }
                                    else // Exisiting Invoice =NO
                                    {
                                        // CREATE NEW INVOICE
                                        var inv = new Entity.Invoiceds.Invoiced();
                                        var invNum = new JobNumber();
                                        invNum = App.DB.Job.GetNextJobNumber((Enums.JobDefinition)5);
                                        inv.SetInvoiceNumber = invNum.Prefix + invNum.JobNumber;
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
                                        bool exists = false;
                                        foreach (ArrayList al in InvoicesToPrint)
                                        {
                                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(al[0], inv.InvoicedID, false))) // check if the invoice id is already in....
                                            {
                                                exists = true;
                                            }
                                        }

                                        if (exists == false) // if not add it.
                                        {
                                            var PrintArray = new ArrayList();
                                            PrintArray.Add(inv.InvoicedID);
                                            PrintArray.Add(dr["RegionID"]);
                                            InvoicesToPrint.Add(PrintArray);
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
                                    bool exists = false;
                                    foreach (ArrayList al in InvoicesToPrint)
                                    {
                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(al[0], dr["InvoicedID"], false))) // check if the invoice id is already in....
                                        {
                                            exists = true;
                                        }
                                    }

                                    if (exists == false) // if not add it.
                                    {
                                        var PrintArray = new ArrayList();
                                        PrintArray.Add(dr["InvoicedID"]);
                                        PrintArray.Add(dr["RegionID"]);
                                        InvoicesToPrint.Add(PrintArray);
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
                    // If Entity.Sys.Helper.MakeIntegerValid(drInv(i).Item("invoicedID")) = 0 Then 'NO

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
                    // Else ' ALREADY INVOICED SO JUST UNTICK
                    // drInv(i).Item("tick") = 0
                    // End If
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

        private void txtJobNumber_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PopulateDatagrid();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ContextMenuStrip1.Show(Button1, new Point(0, 0));
        }

        private void ts1_Click(object sender, EventArgs e) // inv
        {
            try
            {
                bool zeroInvoices = false;
                if (ValidateInvoiceAddress())
                {
                    FindPartPayJobs(false);
                    foreach (DataRow i in InvoicesDataview.Table.Rows)
                    {
                        if (Conversions.ToBoolean(Helper.MakeBooleanValid(i["tick"]) == true & !Operators.ConditionalCompareObjectEqual(i["PAYMENTTERMID"], 69817, false)))
                        {
                            if (Helper.MakeDoubleValid(i["Amount"]) > 0)
                            {

                                // CHECK THAT ANOTHER USERS HASN'T GENERATED SINCE WE LAST REFRESHED OUR SCREEN

                                if (App.DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID(Conversions.ToInteger(i["InvoiceToBeRaisedID"])).Count == 0)
                                {
                                    var inv = new Entity.Invoiceds.Invoiced();
                                    // AMY IS CHEATING AND USING JOB NUMBER - 5 isn't a job definition!
                                    var invNum = new JobNumber();
                                    invNum = App.DB.Job.GetNextJobNumber((Enums.JobDefinition)5);
                                    inv.SetInvoiceNumber = invNum.Prefix + invNum.JobNumber;
                                    inv.SetRaisedByUserID = App.loggedInUser.UserID;
                                    inv.RaisedDate = Conversions.ToDate(i["RaiseDate"]);
                                    if (Conversions.ToBoolean(i["TAXRateID"] > 0))
                                    {
                                        inv.SetVATRateID = i["TAXRateID"];
                                    }
                                    else
                                    {
                                        inv.SetVATRateID = App.DB.VATRatesSQL.VATRates_Get_ByDate(DateAndTime.Now);
                                    }

                                    inv.SetPaymentTermID = i["PaymentTermID"];
                                    inv.SetPaidByID = i["PaidByID"];
                                    inv.SetAdhocInvoiceType = "DDINVOICE";
                                    inv = App.DB.Invoiced.Insert(inv);
                                    var invLines = new Entity.InvoicedLiness.InvoicedLines();
                                    invLines.SetAmount = i["Amount"];
                                    invLines.SetInvoicedID = inv.InvoicedID;
                                    invLines.SetInvoiceToBeRaisedID = i["InvoiceToBeRaisedID"];
                                    invLines = App.DB.InvoicedLines.Insert(invLines);
                                    var PrintArray = new ArrayList();
                                    PrintArray.Add(inv.InvoicedID);
                                    PrintArray.Add(i["RegionID"]);
                                    InvoicesToPrint.Add(PrintArray);
                                }
                            }
                            else
                            {
                                zeroInvoices = true;
                            }
                        }
                    }

                    if (zeroInvoices)
                    {
                        App.ShowMessage("1 or more invoice could not be generated because they have a zero amount.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    PrintAdhocInvoice("DDINVOICE");
                    PopulateDatagrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ts2_Click(object sender, EventArgs e) // receipt
        {
            try
            {
                bool zeroInvoices = false;
                if (ValidateInvoiceAddress())
                {
                    FindPartPayJobs(false);
                    var f = new FRMPaidBy();
                    f.ShowDialog();
                    if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(f.cboDDPaid)) == 0)
                        return;
                    DDpaidBy = Combo.get_GetSelectedItemDescription(f.cboDDPaid);
                    foreach (DataRow i in InvoicesDataview.Table.Rows)
                    {
                        if (Conversions.ToBoolean(Helper.MakeBooleanValid(i["tick"]) == true & !Operators.ConditionalCompareObjectEqual(i["PAYMENTTERMID"], 69817, false)))
                        {
                            if (Helper.MakeDoubleValid(i["Amount"]) > 0)
                            {

                                // CHECK THAT ANOTHER USERS HASN'T GENERATED SINCE WE LAST REFRESHED OUR SCREEN

                                if (App.DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID(Conversions.ToInteger(i["InvoiceToBeRaisedID"])).Count == 0)
                                {
                                    var inv = new Entity.Invoiceds.Invoiced();
                                    // AMY IS CHEATING AND USING JOB NUMBER - 5 isn't a job definition!
                                    var invNum = new JobNumber();
                                    invNum = App.DB.Job.GetNextJobNumber((Enums.JobDefinition)5);
                                    inv.SetInvoiceNumber = invNum.Prefix + invNum.JobNumber;
                                    inv.SetRaisedByUserID = App.loggedInUser.UserID;
                                    inv.RaisedDate = Conversions.ToDate(i["RaiseDate"]);
                                    if (Conversions.ToBoolean(i["TAXRateID"] > 0))
                                    {
                                        inv.SetVATRateID = i["TAXRateID"];
                                    }
                                    else
                                    {
                                        inv.SetVATRateID = App.DB.VATRatesSQL.VATRates_Get_ByDate(DateAndTime.Now);
                                    }

                                    inv.SetPaymentTermID = i["PaymentTermID"];
                                    inv.SetPaidByID = Combo.get_GetSelectedItemValue(f.cboDDPaid);
                                    inv.SetAdhocInvoiceType = "DDRECEIPT";
                                    inv = App.DB.Invoiced.Insert(inv);
                                    var invLines = new Entity.InvoicedLiness.InvoicedLines();
                                    invLines.SetAmount = i["Amount"];
                                    invLines.SetInvoicedID = inv.InvoicedID;
                                    invLines.SetInvoiceToBeRaisedID = i["InvoiceToBeRaisedID"];
                                    invLines = App.DB.InvoicedLines.Insert(invLines);
                                    var PrintArray = new ArrayList();
                                    PrintArray.Add(inv.InvoicedID);
                                    PrintArray.Add(i["RegionID"]);
                                    InvoicesToPrint.Add(PrintArray);
                                }
                            }
                            else
                            {
                                zeroInvoices = true;
                            }
                        }
                    }

                    if (zeroInvoices)
                    {
                        App.ShowMessage("1 or more invoice could not be generated because they have a zero amount.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    PrintAdhocInvoice("DDRECEIPT");
                    PopulateDatagrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void PrintAdhocInvoice(string type)
        {
            var details = new ArrayList();
            details.Add(InvoicesToPrint);
            details.Add(type);
            details.Add(DDpaidBy);
            var oPrint = new Printing(details, "Invoice", Enums.SystemDocumentType.Invoice, true);
            // System.Diagnostics.Process.Start(TheSystem.Configuration.DocumentsLocation)
            InvoicesToPrint.Clear();
        }

        private void RaiseProFormaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var details = new ArrayList();

            // 0 is type 327 contract , 260 visit [InvoiceTypeID]
            // 1 is job or contractoriginalSITE  jobid and cos

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(InvoicesDataview.Table.Select("TICK = 1")[0]["InvoiceTypeID"], 327, false)))
            {
                details.Add("CONTRACT");
                details.Add(App.DB.ContractOriginalSite.Get(Conversions.ToInteger(InvoicesDataview.Table.Select("TICK = 1")[0]["cos"])));
            }
            else
            {
                details.Add("JOB");
                details.Add(App.DB.Job.Job_Get(Conversions.ToInteger(InvoicesDataview.Table.Select("TICK = 1")[0]["JobID"])));
            }

            var f = new FRMInvoiceExtraDetail();
            f.ShowDialog();

            // 2 is invoice notes
            details.Add(f.txtNotes.Text);
            // 3 is Price
            details.Add(Conversions.ToDouble(f.txtCharge.Text));
            // 4 is VAT double

            details.Add(App.DB.VATRatesSQL.VATRates_Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(f.cbo))).VATRate);
            // 5 is readytobeinvoicedID
            details.Add(InvoicesDataview.Table.Select("TICK = 1")[0]["InvoiceToBeRaisedID"]);
            var oPrint = new Printing(details, "ProForma", Enums.SystemDocumentType.ProForma, true);
        }

        private void btnChangeLine_Click(object sender, EventArgs e)
        {
            if (InvoicesDataview is object)
            {
                if (App.EnterOverridePasswordINV())
                {
                    var dr = (from sf in InvoicesDataview.Table.AsEnumerable()
                              where sf.Field<bool>("Tick") == true
                              select sf).ToArray();
                    foreach (DataRow r in dr)
                    {
                        FRMChangeInvoiceLine fCIL = (FRMChangeInvoiceLine)App.ShowForm(typeof(FRMChangeInvoiceLine), true, new object[] { r["Amount"], r["TAXRateID"] });
                        if (fCIL.DialogResult == DialogResult.OK)
                        {
                            r["Amount"] = Conversions.ToDouble(fCIL.txtAmount.Text);
                            r["TAXRateID"] = Combo.get_GetSelectedItemValue(fCIL.cboInvoiceTaxCodeNew);
                            r["VAT"] = App.DB.VATRatesSQL.VATRates_Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(fCIL.cboInvoiceTaxCodeNew))).VATRate;
                        }
                    }
                }
            }
        }
    }
}