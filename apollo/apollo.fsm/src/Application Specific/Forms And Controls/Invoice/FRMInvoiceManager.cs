using FSM.Entity.Customers;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMInvoiceManager : FRMBaseForm, IForm
    {
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

        private Label _lblCustomers;

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

        private Label _Label8;

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

        private Button _btnDeselectAll;

        private Button _btnPrintOneItemOneInvoice;

        private Button _btnPrintManyItemsOnOneInvoice;

        private Button _btnAddInvoiceAddress;

        private Button _btnSearch;

        private Button _btnBackToVisitManager;

        private Label _Label13;

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

        private ToolStripMenuItem _ts2;

        private ToolStripMenuItem _RaiseProFormaToolStripMenuItem;

        private Button _btnChangeLine;

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

        private Button _btnView;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._grpInvoices = new System.Windows.Forms.GroupBox();
            this._btnChangeLine = new System.Windows.Forms.Button();
            this._btnBackToVisitManager = new System.Windows.Forms.Button();
            this._dgInvoices = new System.Windows.Forms.DataGrid();
            this._btnSelectAll = new System.Windows.Forms.Button();
            this._btnDeselectAll = new System.Windows.Forms.Button();
            this._grpFilter = new System.Windows.Forms.GroupBox();
            this._txtAccNo = new System.Windows.Forms.TextBox();
            this._lblAccNo = new System.Windows.Forms.Label();
            this._lblDept = new System.Windows.Forms.Label();
            this._cboDept = new System.Windows.Forms.ComboBox();
            this._Label13 = new System.Windows.Forms.Label();
            this._cboRegion = new System.Windows.Forms.ComboBox();
            this._btnSearch = new System.Windows.Forms.Button();
            this._btnFindCustomer = new System.Windows.Forms.Button();
            this._txtCustomer = new System.Windows.Forms.TextBox();
            this._lblCustomers = new System.Windows.Forms.Label();
            this._txtPostcode = new System.Windows.Forms.TextBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._btnFindSite = new System.Windows.Forms.Button();
            this._txtSite = new System.Windows.Forms.TextBox();
            this._dtpTo = new System.Windows.Forms.DateTimePicker();
            this._dtpFrom = new System.Windows.Forms.DateTimePicker();
            this._txtJobNumber = new System.Windows.Forms.TextBox();
            this._Label9 = new System.Windows.Forms.Label();
            this._Label8 = new System.Windows.Forms.Label();
            this._Label6 = new System.Windows.Forms.Label();
            this._Label2 = new System.Windows.Forms.Label();
            this._Label10 = new System.Windows.Forms.Label();
            this._cboType = new System.Windows.Forms.ComboBox();
            this._btnExport = new System.Windows.Forms.Button();
            this._btnReset = new System.Windows.Forms.Button();
            this._btnPrintOneItemOneInvoice = new System.Windows.Forms.Button();
            this._btnPrintManyItemsOnOneInvoice = new System.Windows.Forms.Button();
            this._btnAddInvoiceAddress = new System.Windows.Forms.Button();
            this._btnView = new System.Windows.Forms.Button();
            this._Button1 = new System.Windows.Forms.Button();
            this._ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._ts1 = new System.Windows.Forms.ToolStripMenuItem();
            this._ts2 = new System.Windows.Forms.ToolStripMenuItem();
            this._RaiseProFormaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._grpInvoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgInvoices)).BeginInit();
            this._grpFilter.SuspendLayout();
            this._ContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpInvoices
            // 
            this._grpInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpInvoices.Controls.Add(this._btnChangeLine);
            this._grpInvoices.Controls.Add(this._btnBackToVisitManager);
            this._grpInvoices.Controls.Add(this._dgInvoices);
            this._grpInvoices.Controls.Add(this._btnSelectAll);
            this._grpInvoices.Controls.Add(this._btnDeselectAll);
            this._grpInvoices.Location = new System.Drawing.Point(8, 173);
            this._grpInvoices.Name = "_grpInvoices";
            this._grpInvoices.Size = new System.Drawing.Size(1182, 337);
            this._grpInvoices.TabIndex = 3;
            this._grpInvoices.TabStop = false;
            this._grpInvoices.Text = "Items Ready To Be Invoiced";
            // 
            // _btnChangeLine
            // 
            this._btnChangeLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnChangeLine.Location = new System.Drawing.Point(848, 20);
            this._btnChangeLine.Name = "_btnChangeLine";
            this._btnChangeLine.Size = new System.Drawing.Size(160, 23);
            this._btnChangeLine.TabIndex = 22;
            this._btnChangeLine.Text = "Change Line";
            this._btnChangeLine.Click += new System.EventHandler(this.btnChangeLine_Click);
            // 
            // _btnBackToVisitManager
            // 
            this._btnBackToVisitManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnBackToVisitManager.Location = new System.Drawing.Point(1014, 20);
            this._btnBackToVisitManager.Name = "_btnBackToVisitManager";
            this._btnBackToVisitManager.Size = new System.Drawing.Size(160, 23);
            this._btnBackToVisitManager.TabIndex = 21;
            this._btnBackToVisitManager.Text = "Back To Visit Manager";
            this._btnBackToVisitManager.Click += new System.EventHandler(this.btnBackToVisitManager_Click);
            // 
            // _dgInvoices
            // 
            this._dgInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgInvoices.DataMember = "";
            this._dgInvoices.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgInvoices.Location = new System.Drawing.Point(8, 49);
            this._dgInvoices.Name = "_dgInvoices";
            this._dgInvoices.Size = new System.Drawing.Size(1166, 280);
            this._dgInvoices.TabIndex = 14;
            this._dgInvoices.DoubleClick += new System.EventHandler(this.dgInvoices_DoubleClick);
            this._dgInvoices.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgInvoices_MouseUp);
            // 
            // _btnSelectAll
            // 
            this._btnSelectAll.AccessibleDescription = "Export Job List To Excel";
            this._btnSelectAll.Location = new System.Drawing.Point(7, 20);
            this._btnSelectAll.Name = "_btnSelectAll";
            this._btnSelectAll.Size = new System.Drawing.Size(88, 23);
            this._btnSelectAll.TabIndex = 19;
            this._btnSelectAll.Text = "Select All";
            this._btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // _btnDeselectAll
            // 
            this._btnDeselectAll.Location = new System.Drawing.Point(103, 20);
            this._btnDeselectAll.Name = "_btnDeselectAll";
            this._btnDeselectAll.Size = new System.Drawing.Size(88, 23);
            this._btnDeselectAll.TabIndex = 20;
            this._btnDeselectAll.Text = "Deselect All";
            this._btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // _grpFilter
            // 
            this._grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpFilter.Controls.Add(this._txtAccNo);
            this._grpFilter.Controls.Add(this._lblAccNo);
            this._grpFilter.Controls.Add(this._lblDept);
            this._grpFilter.Controls.Add(this._cboDept);
            this._grpFilter.Controls.Add(this._Label13);
            this._grpFilter.Controls.Add(this._cboRegion);
            this._grpFilter.Controls.Add(this._btnSearch);
            this._grpFilter.Controls.Add(this._btnFindCustomer);
            this._grpFilter.Controls.Add(this._txtCustomer);
            this._grpFilter.Controls.Add(this._lblCustomers);
            this._grpFilter.Controls.Add(this._txtPostcode);
            this._grpFilter.Controls.Add(this._Label1);
            this._grpFilter.Controls.Add(this._btnFindSite);
            this._grpFilter.Controls.Add(this._txtSite);
            this._grpFilter.Controls.Add(this._dtpTo);
            this._grpFilter.Controls.Add(this._dtpFrom);
            this._grpFilter.Controls.Add(this._txtJobNumber);
            this._grpFilter.Controls.Add(this._Label9);
            this._grpFilter.Controls.Add(this._Label8);
            this._grpFilter.Controls.Add(this._Label6);
            this._grpFilter.Controls.Add(this._Label2);
            this._grpFilter.Controls.Add(this._Label10);
            this._grpFilter.Controls.Add(this._cboType);
            this._grpFilter.Location = new System.Drawing.Point(8, 12);
            this._grpFilter.Name = "_grpFilter";
            this._grpFilter.Size = new System.Drawing.Size(1182, 155);
            this._grpFilter.TabIndex = 4;
            this._grpFilter.TabStop = false;
            this._grpFilter.Text = "Filter";
            // 
            // _txtAccNo
            // 
            this._txtAccNo.Location = new System.Drawing.Point(742, 123);
            this._txtAccNo.Name = "_txtAccNo";
            this._txtAccNo.Size = new System.Drawing.Size(160, 21);
            this._txtAccNo.TabIndex = 41;
            // 
            // _lblAccNo
            // 
            this._lblAccNo.Location = new System.Drawing.Point(606, 126);
            this._lblAccNo.Name = "_lblAccNo";
            this._lblAccNo.Size = new System.Drawing.Size(84, 16);
            this._lblAccNo.TabIndex = 40;
            this._lblAccNo.Text = "Acc No";
            // 
            // _lblDept
            // 
            this._lblDept.Location = new System.Drawing.Point(328, 123);
            this._lblDept.Name = "_lblDept";
            this._lblDept.Size = new System.Drawing.Size(84, 16);
            this._lblDept.TabIndex = 38;
            this._lblDept.Text = "Cost Centre";
            // 
            // _cboDept
            // 
            this._cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboDept.Location = new System.Drawing.Point(418, 123);
            this._cboDept.Name = "_cboDept";
            this._cboDept.Size = new System.Drawing.Size(160, 21);
            this._cboDept.TabIndex = 39;
            // 
            // _Label13
            // 
            this._Label13.Location = new System.Drawing.Point(8, 123);
            this._Label13.Name = "_Label13";
            this._Label13.Size = new System.Drawing.Size(72, 16);
            this._Label13.TabIndex = 37;
            this._Label13.Text = "Region";
            // 
            // _cboRegion
            // 
            this._cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboRegion.Location = new System.Drawing.Point(160, 120);
            this._cboRegion.Name = "_cboRegion";
            this._cboRegion.Size = new System.Drawing.Size(160, 21);
            this._cboRegion.TabIndex = 36;
            // 
            // _btnSearch
            // 
            this._btnSearch.AccessibleDescription = "Export Job List To Excel";
            this._btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSearch.Location = new System.Drawing.Point(1014, 123);
            this._btnSearch.Name = "_btnSearch";
            this._btnSearch.Size = new System.Drawing.Size(120, 23);
            this._btnSearch.TabIndex = 28;
            this._btnSearch.Text = "Run Filter";
            this._btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // _btnFindCustomer
            // 
            this._btnFindCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindCustomer.BackColor = System.Drawing.Color.White;
            this._btnFindCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindCustomer.Location = new System.Drawing.Point(1142, 48);
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
            this._txtCustomer.Location = new System.Drawing.Point(160, 48);
            this._txtCustomer.Name = "_txtCustomer";
            this._txtCustomer.ReadOnly = true;
            this._txtCustomer.Size = new System.Drawing.Size(974, 21);
            this._txtCustomer.TabIndex = 1;
            // 
            // _lblCustomers
            // 
            this._lblCustomers.Location = new System.Drawing.Point(8, 48);
            this._lblCustomers.Name = "_lblCustomers";
            this._lblCustomers.Size = new System.Drawing.Size(72, 21);
            this._lblCustomers.TabIndex = 27;
            this._lblCustomers.Text = "Customers";
            // 
            // _txtPostcode
            // 
            this._txtPostcode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtPostcode.Location = new System.Drawing.Point(160, 96);
            this._txtPostcode.Name = "_txtPostcode";
            this._txtPostcode.Size = new System.Drawing.Size(160, 21);
            this._txtPostcode.TabIndex = 5;
            this._txtPostcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJobNumber_TextChanged);
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(8, 96);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(64, 16);
            this._Label1.TabIndex = 20;
            this._Label1.Text = "Postcode";
            // 
            // _btnFindSite
            // 
            this._btnFindSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindSite.BackColor = System.Drawing.Color.White;
            this._btnFindSite.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindSite.Location = new System.Drawing.Point(1142, 72);
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
            this._txtSite.Location = new System.Drawing.Point(160, 72);
            this._txtSite.Name = "_txtSite";
            this._txtSite.ReadOnly = true;
            this._txtSite.Size = new System.Drawing.Size(974, 21);
            this._txtSite.TabIndex = 3;
            // 
            // _dtpTo
            // 
            this._dtpTo.Location = new System.Drawing.Point(376, 24);
            this._dtpTo.Name = "_dtpTo";
            this._dtpTo.Size = new System.Drawing.Size(160, 21);
            this._dtpTo.TabIndex = 13;
            // 
            // _dtpFrom
            // 
            this._dtpFrom.Location = new System.Drawing.Point(160, 24);
            this._dtpFrom.Name = "_dtpFrom";
            this._dtpFrom.Size = new System.Drawing.Size(160, 21);
            this._dtpFrom.TabIndex = 12;
            // 
            // _txtJobNumber
            // 
            this._txtJobNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtJobNumber.Location = new System.Drawing.Point(742, 96);
            this._txtJobNumber.Name = "_txtJobNumber";
            this._txtJobNumber.Size = new System.Drawing.Size(392, 21);
            this._txtJobNumber.TabIndex = 9;
            this._txtJobNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJobNumber_TextChanged);
            // 
            // _Label9
            // 
            this._Label9.Location = new System.Drawing.Point(336, 24);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(48, 16);
            this._Label9.TabIndex = 10;
            this._Label9.Text = "and";
            // 
            // _Label8
            // 
            this._Label8.Location = new System.Drawing.Point(8, 24);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(144, 16);
            this._Label8.TabIndex = 9;
            this._Label8.Text = "To Raise Date Between : ";
            // 
            // _Label6
            // 
            this._Label6.Location = new System.Drawing.Point(606, 99);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(136, 16);
            this._Label6.TabIndex = 6;
            this._Label6.Text = "Job/Order/Contract No";
            // 
            // _Label2
            // 
            this._Label2.Location = new System.Drawing.Point(8, 72);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(64, 16);
            this._Label2.TabIndex = 2;
            this._Label2.Text = "Property";
            // 
            // _Label10
            // 
            this._Label10.Location = new System.Drawing.Point(328, 96);
            this._Label10.Name = "_Label10";
            this._Label10.Size = new System.Drawing.Size(48, 16);
            this._Label10.TabIndex = 4;
            this._Label10.Text = "Type";
            // 
            // _cboType
            // 
            this._cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboType.Location = new System.Drawing.Point(418, 96);
            this._cboType.Name = "_cboType";
            this._cboType.Size = new System.Drawing.Size(160, 21);
            this._cboType.TabIndex = 7;
            // 
            // _btnExport
            // 
            this._btnExport.AccessibleDescription = "Export Job List To Excel";
            this._btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnExport.Location = new System.Drawing.Point(8, 518);
            this._btnExport.Name = "_btnExport";
            this._btnExport.Size = new System.Drawing.Size(56, 23);
            this._btnExport.TabIndex = 17;
            this._btnExport.Text = "Export";
            this._btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // _btnReset
            // 
            this._btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnReset.Location = new System.Drawing.Point(72, 518);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(56, 23);
            this._btnReset.TabIndex = 18;
            this._btnReset.Text = "Reset";
            this._btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // _btnPrintOneItemOneInvoice
            // 
            this._btnPrintOneItemOneInvoice.AccessibleDescription = "Export Job List To Excel";
            this._btnPrintOneItemOneInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnPrintOneItemOneInvoice.Location = new System.Drawing.Point(136, 518);
            this._btnPrintOneItemOneInvoice.Name = "_btnPrintOneItemOneInvoice";
            this._btnPrintOneItemOneInvoice.Size = new System.Drawing.Size(216, 23);
            this._btnPrintOneItemOneInvoice.TabIndex = 21;
            this._btnPrintOneItemOneInvoice.Text = "Print One Item One Invoice";
            this._btnPrintOneItemOneInvoice.Click += new System.EventHandler(this.btnPrintOneItemOneInvoice_Click);
            // 
            // _btnPrintManyItemsOnOneInvoice
            // 
            this._btnPrintManyItemsOnOneInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnPrintManyItemsOnOneInvoice.Location = new System.Drawing.Point(360, 518);
            this._btnPrintManyItemsOnOneInvoice.Name = "_btnPrintManyItemsOnOneInvoice";
            this._btnPrintManyItemsOnOneInvoice.Size = new System.Drawing.Size(216, 23);
            this._btnPrintManyItemsOnOneInvoice.TabIndex = 22;
            this._btnPrintManyItemsOnOneInvoice.Text = "Print Many Items on One Invoice";
            this._btnPrintManyItemsOnOneInvoice.Click += new System.EventHandler(this.btnPrintManyItemsOnOneInvoice_Click);
            // 
            // _btnAddInvoiceAddress
            // 
            this._btnAddInvoiceAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnAddInvoiceAddress.Location = new System.Drawing.Point(584, 518);
            this._btnAddInvoiceAddress.Name = "_btnAddInvoiceAddress";
            this._btnAddInvoiceAddress.Size = new System.Drawing.Size(160, 23);
            this._btnAddInvoiceAddress.TabIndex = 23;
            this._btnAddInvoiceAddress.Text = "Add Invoice Address";
            this._btnAddInvoiceAddress.Click += new System.EventHandler(this.btnAddInvoiceAddress_Click);
            // 
            // _btnView
            // 
            this._btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnView.Location = new System.Drawing.Point(1060, 518);
            this._btnView.Name = "_btnView";
            this._btnView.Size = new System.Drawing.Size(130, 23);
            this._btnView.TabIndex = 24;
            this._btnView.Text = "View";
            this._btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // _Button1
            // 
            this._Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Button1.ContextMenuStrip = this._ContextMenuStrip1;
            this._Button1.Location = new System.Drawing.Point(750, 518);
            this._Button1.Name = "_Button1";
            this._Button1.Size = new System.Drawing.Size(169, 23);
            this._Button1.TabIndex = 26;
            this._Button1.Text = "Raise Alternative Doc";
            this._Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // _ContextMenuStrip1
            // 
            this._ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ts1,
            this._ts2,
            this._RaiseProFormaToolStripMenuItem});
            this._ContextMenuStrip1.Name = "ContextMenuStrip1";
            this._ContextMenuStrip1.Size = new System.Drawing.Size(173, 70);
            // 
            // _ts1
            // 
            this._ts1.Name = "_ts1";
            this._ts1.Size = new System.Drawing.Size(172, 22);
            this._ts1.Text = "Missed DD Invoice";
            this._ts1.Click += new System.EventHandler(this.ts1_Click);
            // 
            // _ts2
            // 
            this._ts2.Name = "_ts2";
            this._ts2.Size = new System.Drawing.Size(172, 22);
            this._ts2.Text = "Missed DD Receipt";
            this._ts2.Click += new System.EventHandler(this.ts2_Click);
            // 
            // _RaiseProFormaToolStripMenuItem
            // 
            this._RaiseProFormaToolStripMenuItem.Name = "_RaiseProFormaToolStripMenuItem";
            this._RaiseProFormaToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this._RaiseProFormaToolStripMenuItem.Text = "Raise Pro-Forma";
            this._RaiseProFormaToolStripMenuItem.Click += new System.EventHandler(this.RaiseProFormaToolStripMenuItem_Click);
            // 
            // FRMInvoiceManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1198, 548);
            this.Controls.Add(this._Button1);
            this.Controls.Add(this._btnView);
            this.Controls.Add(this._btnAddInvoiceAddress);
            this.Controls.Add(this._btnPrintOneItemOneInvoice);
            this.Controls.Add(this._btnPrintManyItemsOnOneInvoice);
            this.Controls.Add(this._btnExport);
            this.Controls.Add(this._btnReset);
            this.Controls.Add(this._grpFilter);
            this.Controls.Add(this._grpInvoices);
            this.Name = "FRMInvoiceManager";
            this.Text = "Ready To Be Invoice Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpInvoices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgInvoices)).EndInit();
            this._grpFilter.ResumeLayout(false);
            this._grpFilter.PerformLayout();
            this._ContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
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
                DataView dv = (DataView)get_GetParameter(0);
                if (dv != null)
                {
                    if (Conversions.ToBoolean(dv.Table.Rows.Count > 0))
                    {
                        dtpFrom.Value = Conversions.ToDate(dv.Table.Select("RaiseDate = MIN(RaiseDate)")[0]["RaiseDate"]);
                        dtpTo.Value = Conversions.ToDate(dv.Table.Select("RaiseDate = MAX(RaiseDate)")[0]["RaiseDate"]);
                    }

                    InvoicesDataview = dv;
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
                                    inv.SetInvoiceNumber = invNum.Prefix + invNum.Number;
                                    inv.SetRaisedByUserID = App.loggedInUser.UserID;
                                    inv.RaisedDate = Conversions.ToDate(i["RaiseDate"]);
                                    if (Conversions.ToBoolean((int)i["TAXRateID"] > 0))
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
                                        inv.SetInvoiceNumber = invNum.Prefix + invNum.Number;
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
                                    inv.SetInvoiceNumber = invNum.Prefix + invNum.Number;
                                    inv.SetRaisedByUserID = App.loggedInUser.UserID;
                                    inv.RaisedDate = Conversions.ToDate(i["RaiseDate"]);
                                    if (Conversions.ToBoolean((int)i["TAXRateID"] > 0))
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
                                    inv.SetInvoiceNumber = invNum.Prefix + invNum.Number;
                                    inv.SetRaisedByUserID = App.loggedInUser.UserID;
                                    inv.RaisedDate = Conversions.ToDate(i["RaiseDate"]);
                                    if (Conversions.ToBoolean((int)i["TAXRateID"] > 0))
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