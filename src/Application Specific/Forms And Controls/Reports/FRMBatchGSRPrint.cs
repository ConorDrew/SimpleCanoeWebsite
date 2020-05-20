using FSM.Entity.Sys;
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
    public class FRMBatchGSRPrint : FRMBaseForm, IForm
    {
        public FRMBatchGSRPrint() : base()
        {
            base.Load += FRMVisitManager_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
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
                }

                _txtJobNumber = value;
                if (_txtJobNumber != null)
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
                }

                _cboStatus = value;
                if (_cboStatus != null)
                {
                }
            }
        }

        private ComboBox _cboDefinition;

        internal ComboBox cboDefinition
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDefinition;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDefinition != null)
                {
                }

                _cboDefinition = value;
                if (_cboDefinition != null)
                {
                }
            }
        }

        private Label _Label11;

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

        private Label _Label10;

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

        private CheckBox _chkVisitDate;

        internal CheckBox chkVisitDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkVisitDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkVisitDate != null)
                {
                    _chkVisitDate.CheckedChanged -= chkVisitDate_CheckedChanged;
                }

                _chkVisitDate = value;
                if (_chkVisitDate != null)
                {
                    _chkVisitDate.CheckedChanged += chkVisitDate_CheckedChanged;
                }
            }
        }

        private GroupBox _grpEngineerVisits;

        internal GroupBox grpEngineerVisits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpEngineerVisits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpEngineerVisits != null)
                {
                }

                _grpEngineerVisits = value;
                if (_grpEngineerVisits != null)
                {
                }
            }
        }

        private DataGrid _dgVisits;

        internal DataGrid dgVisits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgVisits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgVisits != null)
                {
                    _dgVisits.MouseUp -= dgVisits_MouseUp;
                    _dgVisits.DoubleClick -= dgVisits_DoubleClick;
                }

                _dgVisits = value;
                if (_dgVisits != null)
                {
                    _dgVisits.MouseUp += dgVisits_MouseUp;
                    _dgVisits.DoubleClick += dgVisits_DoubleClick;
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
                }

                _txtPostcode = value;
                if (_txtPostcode != null)
                {
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

        private Label _Label13;

        private ComboBox _cboOutcome;

        internal ComboBox cboOutcome
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboOutcome;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboOutcome != null)
                {
                }

                _cboOutcome = value;
                if (_cboOutcome != null)
                {
                }
            }
        }

        private Button _btnUnselect;

        private Button _btnSelectAll;

        private Button _btnPrint;

        private Button _btnExport;

        private CheckBox _chkPrintHdr;

        internal CheckBox chkPrintHdr
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkPrintHdr;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkPrintHdr != null)
                {
                }

                _chkPrintHdr = value;
                if (_chkPrintHdr != null)
                {
                }
            }
        }

        private CheckBox _chkExceptionsOnly;

        internal CheckBox chkExceptionsOnly
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkExceptionsOnly;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkExceptionsOnly != null)
                {
                }

                _chkExceptionsOnly = value;
                if (_chkExceptionsOnly != null)
                {
                }
            }
        }

        private Button _btnShowdata;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._grpEngineerVisits = new System.Windows.Forms.GroupBox();
            this._dgVisits = new System.Windows.Forms.DataGrid();
            this._grpFilter = new System.Windows.Forms.GroupBox();
            this._chkExceptionsOnly = new System.Windows.Forms.CheckBox();
            this._chkPrintHdr = new System.Windows.Forms.CheckBox();
            this._btnUnselect = new System.Windows.Forms.Button();
            this._btnSelectAll = new System.Windows.Forms.Button();
            this._btnShowdata = new System.Windows.Forms.Button();
            this._cboOutcome = new System.Windows.Forms.ComboBox();
            this._btnFindCustomer = new System.Windows.Forms.Button();
            this._txtCustomer = new System.Windows.Forms.TextBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._txtPostcode = new System.Windows.Forms.TextBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._btnFindSite = new System.Windows.Forms.Button();
            this._txtSite = new System.Windows.Forms.TextBox();
            this._dtpTo = new System.Windows.Forms.DateTimePicker();
            this._dtpFrom = new System.Windows.Forms.DateTimePicker();
            this._txtJobNumber = new System.Windows.Forms.TextBox();
            this._Label9 = new System.Windows.Forms.Label();
            this._Label8 = new System.Windows.Forms.Label();
            this._chkVisitDate = new System.Windows.Forms.CheckBox();
            this._Label6 = new System.Windows.Forms.Label();
            this._Label3 = new System.Windows.Forms.Label();
            this._Label2 = new System.Windows.Forms.Label();
            this._Label10 = new System.Windows.Forms.Label();
            this._cboType = new System.Windows.Forms.ComboBox();
            this._Label11 = new System.Windows.Forms.Label();
            this._cboDefinition = new System.Windows.Forms.ComboBox();
            this._cboStatus = new System.Windows.Forms.ComboBox();
            this._Label13 = new System.Windows.Forms.Label();
            this._btnPrint = new System.Windows.Forms.Button();
            this._btnExport = new System.Windows.Forms.Button();
            this._grpEngineerVisits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgVisits)).BeginInit();
            this._grpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpEngineerVisits
            // 
            this._grpEngineerVisits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpEngineerVisits.Controls.Add(this._dgVisits);
            this._grpEngineerVisits.Location = new System.Drawing.Point(8, 242);
            this._grpEngineerVisits.Name = "_grpEngineerVisits";
            this._grpEngineerVisits.Size = new System.Drawing.Size(784, 219);
            this._grpEngineerVisits.TabIndex = 2;
            this._grpEngineerVisits.TabStop = false;
            this._grpEngineerVisits.Text = "Double Click To View / Edit";
            // 
            // _dgVisits
            // 
            this._dgVisits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgVisits.DataMember = "";
            this._dgVisits.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgVisits.Location = new System.Drawing.Point(8, 18);
            this._dgVisits.Name = "_dgVisits";
            this._dgVisits.Size = new System.Drawing.Size(768, 193);
            this._dgVisits.TabIndex = 14;
            this._dgVisits.DoubleClick += new System.EventHandler(this.dgVisits_DoubleClick);
            this._dgVisits.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgVisits_MouseUp);
            // 
            // _grpFilter
            // 
            this._grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpFilter.Controls.Add(this._chkExceptionsOnly);
            this._grpFilter.Controls.Add(this._chkPrintHdr);
            this._grpFilter.Controls.Add(this._btnUnselect);
            this._grpFilter.Controls.Add(this._btnSelectAll);
            this._grpFilter.Controls.Add(this._btnShowdata);
            this._grpFilter.Controls.Add(this._cboOutcome);
            this._grpFilter.Controls.Add(this._btnFindCustomer);
            this._grpFilter.Controls.Add(this._txtCustomer);
            this._grpFilter.Controls.Add(this._Label4);
            this._grpFilter.Controls.Add(this._txtPostcode);
            this._grpFilter.Controls.Add(this._Label1);
            this._grpFilter.Controls.Add(this._btnFindSite);
            this._grpFilter.Controls.Add(this._txtSite);
            this._grpFilter.Controls.Add(this._dtpTo);
            this._grpFilter.Controls.Add(this._dtpFrom);
            this._grpFilter.Controls.Add(this._txtJobNumber);
            this._grpFilter.Controls.Add(this._Label9);
            this._grpFilter.Controls.Add(this._Label8);
            this._grpFilter.Controls.Add(this._chkVisitDate);
            this._grpFilter.Controls.Add(this._Label6);
            this._grpFilter.Controls.Add(this._Label3);
            this._grpFilter.Controls.Add(this._Label2);
            this._grpFilter.Controls.Add(this._Label10);
            this._grpFilter.Controls.Add(this._cboType);
            this._grpFilter.Controls.Add(this._Label11);
            this._grpFilter.Controls.Add(this._cboDefinition);
            this._grpFilter.Controls.Add(this._cboStatus);
            this._grpFilter.Controls.Add(this._Label13);
            this._grpFilter.Location = new System.Drawing.Point(8, 12);
            this._grpFilter.Name = "_grpFilter";
            this._grpFilter.Size = new System.Drawing.Size(784, 224);
            this._grpFilter.TabIndex = 1;
            this._grpFilter.TabStop = false;
            this._grpFilter.Text = "Filter";
            // 
            // _chkExceptionsOnly
            // 
            this._chkExceptionsOnly.AutoSize = true;
            this._chkExceptionsOnly.Location = new System.Drawing.Point(361, 197);
            this._chkExceptionsOnly.Name = "_chkExceptionsOnly";
            this._chkExceptionsOnly.Size = new System.Drawing.Size(147, 17);
            this._chkExceptionsOnly.TabIndex = 39;
            this._chkExceptionsOnly.Text = "Only Print Exceptions";
            this._chkExceptionsOnly.UseVisualStyleBackColor = true;
            // 
            // _chkPrintHdr
            // 
            this._chkPrintHdr.AutoSize = true;
            this._chkPrintHdr.Location = new System.Drawing.Point(216, 197);
            this._chkPrintHdr.Name = "_chkPrintHdr";
            this._chkPrintHdr.Size = new System.Drawing.Size(129, 17);
            this._chkPrintHdr.TabIndex = 38;
            this._chkPrintHdr.Text = "Print Header Page";
            this._chkPrintHdr.UseVisualStyleBackColor = true;
            // 
            // _btnUnselect
            // 
            this._btnUnselect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnUnselect.Location = new System.Drawing.Point(113, 192);
            this._btnUnselect.Name = "_btnUnselect";
            this._btnUnselect.Size = new System.Drawing.Size(96, 23);
            this._btnUnselect.TabIndex = 37;
            this._btnUnselect.Text = "Unselect All";
            this._btnUnselect.Click += new System.EventHandler(this.btnUnselect_Click);
            // 
            // _btnSelectAll
            // 
            this._btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSelectAll.Location = new System.Drawing.Point(11, 192);
            this._btnSelectAll.Name = "_btnSelectAll";
            this._btnSelectAll.Size = new System.Drawing.Size(96, 23);
            this._btnSelectAll.TabIndex = 36;
            this._btnSelectAll.Text = "Select All";
            this._btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // _btnShowdata
            // 
            this._btnShowdata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnShowdata.Location = new System.Drawing.Point(679, 192);
            this._btnShowdata.Name = "_btnShowdata";
            this._btnShowdata.Size = new System.Drawing.Size(96, 23);
            this._btnShowdata.TabIndex = 35;
            this._btnShowdata.Text = "Show Data";
            this._btnShowdata.Click += new System.EventHandler(this.btnShowdata_Click);
            // 
            // _cboOutcome
            // 
            this._cboOutcome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cboOutcome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboOutcome.Location = new System.Drawing.Point(600, 115);
            this._cboOutcome.Name = "_cboOutcome";
            this._cboOutcome.Size = new System.Drawing.Size(176, 21);
            this._cboOutcome.TabIndex = 34;
            // 
            // _btnFindCustomer
            // 
            this._btnFindCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindCustomer.BackColor = System.Drawing.Color.White;
            this._btnFindCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindCustomer.Location = new System.Drawing.Point(736, 19);
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
            this._txtCustomer.Location = new System.Drawing.Point(104, 19);
            this._txtCustomer.Name = "_txtCustomer";
            this._txtCustomer.ReadOnly = true;
            this._txtCustomer.Size = new System.Drawing.Size(624, 21);
            this._txtCustomer.TabIndex = 1;
            // 
            // _Label4
            // 
            this._Label4.Location = new System.Drawing.Point(8, 16);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(64, 16);
            this._Label4.TabIndex = 27;
            this._Label4.Text = "Customer";
            // 
            // _txtPostcode
            // 
            this._txtPostcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtPostcode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtPostcode.Location = new System.Drawing.Point(104, 67);
            this._txtPostcode.Name = "_txtPostcode";
            this._txtPostcode.Size = new System.Drawing.Size(184, 21);
            this._txtPostcode.TabIndex = 5;
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(8, 64);
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
            this._btnFindSite.Location = new System.Drawing.Point(736, 43);
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
            this._txtSite.Location = new System.Drawing.Point(104, 43);
            this._txtSite.Name = "_txtSite";
            this._txtSite.ReadOnly = true;
            this._txtSite.Size = new System.Drawing.Size(624, 21);
            this._txtSite.TabIndex = 3;
            // 
            // _dtpTo
            // 
            this._dtpTo.Location = new System.Drawing.Point(144, 163);
            this._dtpTo.Name = "_dtpTo";
            this._dtpTo.Size = new System.Drawing.Size(144, 21);
            this._dtpTo.TabIndex = 13;
            // 
            // _dtpFrom
            // 
            this._dtpFrom.Location = new System.Drawing.Point(144, 139);
            this._dtpFrom.Name = "_dtpFrom";
            this._dtpFrom.Size = new System.Drawing.Size(144, 21);
            this._dtpFrom.TabIndex = 12;
            // 
            // _txtJobNumber
            // 
            this._txtJobNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtJobNumber.Location = new System.Drawing.Point(104, 115);
            this._txtJobNumber.Name = "_txtJobNumber";
            this._txtJobNumber.Size = new System.Drawing.Size(184, 21);
            this._txtJobNumber.TabIndex = 9;
            // 
            // _Label9
            // 
            this._Label9.Location = new System.Drawing.Point(104, 160);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(48, 16);
            this._Label9.TabIndex = 10;
            this._Label9.Text = "To";
            // 
            // _Label8
            // 
            this._Label8.Location = new System.Drawing.Point(104, 136);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(48, 16);
            this._Label8.TabIndex = 9;
            this._Label8.Text = "From";
            // 
            // _chkVisitDate
            // 
            this._chkVisitDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this._chkVisitDate.Location = new System.Drawing.Point(8, 136);
            this._chkVisitDate.Name = "_chkVisitDate";
            this._chkVisitDate.Size = new System.Drawing.Size(80, 24);
            this._chkVisitDate.TabIndex = 11;
            this._chkVisitDate.Text = "Visit Date";
            this._chkVisitDate.UseVisualStyleBackColor = true;
            this._chkVisitDate.CheckedChanged += new System.EventHandler(this.chkVisitDate_CheckedChanged);
            // 
            // _Label6
            // 
            this._Label6.Location = new System.Drawing.Point(8, 112);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(88, 16);
            this._Label6.TabIndex = 6;
            this._Label6.Text = "Job Number";
            // 
            // _Label3
            // 
            this._Label3.Location = new System.Drawing.Point(8, 88);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(72, 16);
            this._Label3.TabIndex = 3;
            this._Label3.Text = "Definition";
            // 
            // _Label2
            // 
            this._Label2.Location = new System.Drawing.Point(8, 40);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(64, 16);
            this._Label2.TabIndex = 2;
            this._Label2.Text = "Site";
            // 
            // _Label10
            // 
            this._Label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label10.Location = new System.Drawing.Point(296, 92);
            this._Label10.Name = "_Label10";
            this._Label10.Size = new System.Drawing.Size(48, 16);
            this._Label10.TabIndex = 4;
            this._Label10.Text = "Type";
            // 
            // _cboType
            // 
            this._cboType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboType.Location = new System.Drawing.Point(344, 91);
            this._cboType.Name = "_cboType";
            this._cboType.Size = new System.Drawing.Size(184, 21);
            this._cboType.TabIndex = 7;
            // 
            // _Label11
            // 
            this._Label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label11.Location = new System.Drawing.Point(536, 95);
            this._Label11.Name = "_Label11";
            this._Label11.Size = new System.Drawing.Size(48, 16);
            this._Label11.TabIndex = 5;
            this._Label11.Text = "Status";
            // 
            // _cboDefinition
            // 
            this._cboDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboDefinition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboDefinition.Location = new System.Drawing.Point(104, 92);
            this._cboDefinition.Name = "_cboDefinition";
            this._cboDefinition.Size = new System.Drawing.Size(184, 21);
            this._cboDefinition.TabIndex = 6;
            // 
            // _cboStatus
            // 
            this._cboStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboStatus.Location = new System.Drawing.Point(600, 91);
            this._cboStatus.Name = "_cboStatus";
            this._cboStatus.Size = new System.Drawing.Size(176, 21);
            this._cboStatus.TabIndex = 8;
            // 
            // _Label13
            // 
            this._Label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label13.Location = new System.Drawing.Point(536, 118);
            this._Label13.Name = "_Label13";
            this._Label13.Size = new System.Drawing.Size(64, 16);
            this._Label13.TabIndex = 33;
            this._Label13.Text = "Outcome";
            // 
            // _btnPrint
            // 
            this._btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnPrint.Location = new System.Drawing.Point(692, 467);
            this._btnPrint.Name = "_btnPrint";
            this._btnPrint.Size = new System.Drawing.Size(96, 23);
            this._btnPrint.TabIndex = 36;
            this._btnPrint.Text = "Print GSRs";
            this._btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // _btnExport
            // 
            this._btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnExport.Location = new System.Drawing.Point(16, 467);
            this._btnExport.Name = "_btnExport";
            this._btnExport.Size = new System.Drawing.Size(96, 23);
            this._btnExport.TabIndex = 37;
            this._btnExport.Text = "Export";
            this._btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FRMBatchGSRPrint
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(800, 494);
            this.Controls.Add(this._btnExport);
            this.Controls.Add(this._btnPrint);
            this.Controls.Add(this._grpEngineerVisits);
            this.Controls.Add(this._grpFilter);
            this.MinimumSize = new System.Drawing.Size(808, 528);
            this.Name = "FRMBatchGSRPrint";
            this.Text = "Batch GSR Print";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpEngineerVisits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgVisits)).EndInit();
            this._grpFilter.ResumeLayout(false);
            this._grpFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            var argc = cboDefinition;
            Combo.SetUpCombo(ref argc, DynamicDataTables.JobDefinitions, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter);
            var argc1 = cboType;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter);
            var argc2 = cboStatus;
            Combo.SetUpCombo(ref argc2, DynamicDataTables.VisitStatus_For_Viewing, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter);
            var argc3 = cboOutcome;
            Combo.SetUpCombo(ref argc3, DynamicDataTables.OutcomeStatuses, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter);
            SetupVisitDataGrid();
            PopulateDatagrid();
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

        private DataView _dvVisits;

        private DataView VisitsDataview
        {
            get
            {
                return _dvVisits;
            }

            set
            {
                _dvVisits = value;
                _dvVisits.AllowNew = false;
                _dvVisits.AllowEdit = false;
                _dvVisits.AllowDelete = false;
                _dvVisits.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString();
                dgVisits.DataSource = VisitsDataview;
            }
        }

        private DataRow SelectedVisitDataRow
        {
            get
            {
                if (!(dgVisits.CurrentRowIndex == -1))
                {
                    return VisitsDataview[dgVisits.CurrentRowIndex].Row;
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
                    btnFindSite.Enabled = true;
                }
                else
                {
                    txtCustomer.Text = "";
                    btnFindSite.Enabled = false;
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

        private void SetupVisitDataGrid()
        {
            var tbStyle = dgVisits.TableStyles[0];
            var tick = new DataGridBoolColumn();
            tick.HeaderText = "";
            tick.MappingName = "tick";
            tick.ReadOnly = true;
            tick.Width = 25;
            tick.NullText = "";
            tbStyle.GridColumnStyles.Add(tick);
            var Emailtick = new DataGridBoolColumn();
            Emailtick.HeaderText = "Sending Email";
            Emailtick.MappingName = "EmailSend";
            Emailtick.ReadOnly = true;
            Emailtick.Width = 75;
            Emailtick.NullText = "";
            tbStyle.GridColumnStyles.Add(Emailtick);
            var Customer = new DataGridLabelColumn();
            Customer.Format = "";
            Customer.FormatInfo = null;
            Customer.HeaderText = "Customer";
            Customer.MappingName = "Customer";
            Customer.ReadOnly = true;
            Customer.Width = 150;
            Customer.NullText = "";
            tbStyle.GridColumnStyles.Add(Customer);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Site";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 100;
            Site.NullText = "";
            tbStyle.GridColumnStyles.Add(Site);
            var Postcode = new DataGridLabelColumn();
            Postcode.Format = "";
            Postcode.FormatInfo = null;
            Postcode.HeaderText = "Postcode";
            Postcode.MappingName = "SitePostcode";
            Postcode.ReadOnly = true;
            Postcode.Width = 75;
            Postcode.NullText = "";
            tbStyle.GridColumnStyles.Add(Postcode);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job Number";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 75;
            JobNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(JobNumber);
            var PONumber = new DataGridLabelColumn();
            PONumber.Format = "";
            PONumber.FormatInfo = null;
            PONumber.HeaderText = "PO Number";
            PONumber.MappingName = "PONumber";
            PONumber.ReadOnly = true;
            PONumber.Width = 75;
            PONumber.NullText = "";
            tbStyle.GridColumnStyles.Add(PONumber);
            var JobDefinition = new DataGridLabelColumn();
            JobDefinition.Format = "";
            JobDefinition.FormatInfo = null;
            JobDefinition.HeaderText = "Definition";
            JobDefinition.MappingName = "JobDefinition";
            JobDefinition.ReadOnly = true;
            JobDefinition.Width = 75;
            JobDefinition.NullText = "";
            tbStyle.GridColumnStyles.Add(JobDefinition);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 75;
            Type.NullText = Entity.Sys.Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
            tbStyle.GridColumnStyles.Add(Type);
            var VisitStatus = new DataGridLabelColumn();
            VisitStatus.Format = "";
            VisitStatus.FormatInfo = null;
            VisitStatus.HeaderText = "Status";
            VisitStatus.MappingName = "VisitStatus";
            VisitStatus.ReadOnly = true;
            VisitStatus.Width = 75;
            VisitStatus.NullText = "";
            tbStyle.GridColumnStyles.Add(VisitStatus);
            var VisitOutcome = new DataGridLabelColumn();
            VisitOutcome.Format = "";
            VisitOutcome.FormatInfo = null;
            VisitOutcome.HeaderText = "Outcome";
            VisitOutcome.MappingName = "VisitOutcome";
            VisitOutcome.ReadOnly = true;
            VisitOutcome.Width = 75;
            VisitOutcome.NullText = "";
            tbStyle.GridColumnStyles.Add(VisitOutcome);
            var EstimatedVisitDate = new DataGridLabelColumn();
            EstimatedVisitDate.Format = "dd/MMM/yyyy";
            EstimatedVisitDate.FormatInfo = null;
            EstimatedVisitDate.HeaderText = "Estimated Visit Date";
            EstimatedVisitDate.MappingName = "EstimatedVisitDate";
            EstimatedVisitDate.ReadOnly = true;
            EstimatedVisitDate.Width = 100;
            EstimatedVisitDate.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(EstimatedVisitDate);
            var StartDateTime = new DataGridLabelColumn();
            StartDateTime.Format = "dd/MMM/yyyy";
            StartDateTime.FormatInfo = null;
            StartDateTime.HeaderText = "Scheduled Date";
            StartDateTime.MappingName = "StartDateTime";
            StartDateTime.ReadOnly = true;
            StartDateTime.Width = 100;
            StartDateTime.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(StartDateTime);
            var Engineer = new DataGridLabelColumn();
            Engineer.Format = "";
            Engineer.FormatInfo = null;
            Engineer.HeaderText = "Engineer";
            Engineer.MappingName = "Engineer";
            Engineer.ReadOnly = true;
            Engineer.Width = 75;
            Engineer.NullText = "";
            tbStyle.GridColumnStyles.Add(Engineer);
            var VisitValue = new DataGridLabelColumn();
            VisitValue.Format = "C";
            VisitValue.FormatInfo = null;
            VisitValue.HeaderText = "Visit Value";
            VisitValue.MappingName = "VisitValue";
            VisitValue.ReadOnly = true;
            VisitValue.Width = 75;
            VisitValue.NullText = "";
            tbStyle.GridColumnStyles.Add(VisitValue);
            var VisitCharge = new DataGridLabelColumn();
            VisitCharge.Format = "C";
            VisitCharge.FormatInfo = null;
            VisitCharge.HeaderText = "Visit Charge";
            VisitCharge.MappingName = "VisitCharge";
            VisitCharge.ReadOnly = true;
            VisitCharge.Width = 200;
            VisitCharge.NullText = "";
            tbStyle.GridColumnStyles.Add(VisitCharge);
            var EngineerCost = new DataGridLabelColumn();
            EngineerCost.Format = "C";
            EngineerCost.FormatInfo = null;
            EngineerCost.HeaderText = "Engineer Cost";
            EngineerCost.MappingName = "EngineerCost";
            EngineerCost.ReadOnly = true;
            EngineerCost.Width = 100;
            EngineerCost.NullText = "";
            tbStyle.GridColumnStyles.Add(EngineerCost);
            var PartProductCost = new DataGridLabelColumn();
            PartProductCost.Format = "C";
            PartProductCost.FormatInfo = null;
            PartProductCost.HeaderText = @"Part\Product Cost";
            PartProductCost.MappingName = "PartProductCost";
            PartProductCost.ReadOnly = true;
            PartProductCost.Width = 100;
            PartProductCost.NullText = "";
            tbStyle.GridColumnStyles.Add(PartProductCost);
            var DefectCount = new DataGridLabelColumn();
            // DefectCount.Format = "C"
            DefectCount.FormatInfo = null;
            DefectCount.HeaderText = "DefectCount";
            DefectCount.MappingName = "DefectCount";
            DefectCount.ReadOnly = true;
            DefectCount.Width = 100;
            DefectCount.NullText = "";
            tbStyle.GridColumnStyles.Add(DefectCount);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString();
            dgVisits.TableStyles.Add(tbStyle);
        }

        private void FRMVisitManager_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblCustomer));
            if (!(ID == 0))
            {
                theCustomer = App.DB.Customer.Customer_Get(ID);
            }
        }

        private void btnFindSite_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblSite, theCustomer.CustomerID));
            if (!(ID == 0))
            {
                theSite = App.DB.Sites.Get(ID);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void chkVisitDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVisitDate.Checked)
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            else
            {
                dtpFrom.Value = DateAndTime.Today;
                dtpTo.Value = DateAndTime.Today;
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
        }

        private void btnShowdata_Click(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void dgVisits_MouseUp(object sender, MouseEventArgs e)
        {
            DataGrid.HitTestInfo HitTestInfo;
            HitTestInfo = dgVisits.HitTest(e.X, e.Y);
            if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
            {
                if (HitTestInfo.Column == 0)
                {
                    bool selected = !Entity.Sys.Helper.MakeBooleanValid(SelectedVisitDataRow["tick"]);
                    SelectedVisitDataRow["Tick"] = selected;
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (VisitsDataview is object && VisitsDataview.Count > 0)
            {
                foreach (DataRow dr in VisitsDataview.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["EmailSend"], 0, false)))
                    {
                        dr["tick"] = true;
                    }
                }
            }
        }

        private void btnUnselect_Click(object sender, EventArgs e)
        {
            if (VisitsDataview is object && VisitsDataview.Count > 0)
            {
                foreach (DataRow dr in VisitsDataview.Table.Rows)
                    dr["tick"] = false;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var details = new ArrayList();
            details.Add(VisitsDataview.Table.Select("Tick= true"));
            details.Add(chkPrintHdr.Checked);
            var oPrint = new Entity.Sys.Printing(details, "GSR Batch", Entity.Sys.Enums.SystemDocumentType.GSRBatch, true);
            RunFilter();
            Cursor = Cursors.Default;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var dtExport = new DataTable();
            dtExport.Columns.Add("Resident Name");
            dtExport.Columns.Add("Address 1");
            dtExport.Columns.Add("Postcode");
            dtExport.Columns.Add("Sub Area");
            dtExport.Columns.Add("Contact No.");
            dtExport.Columns.Add("PRI Data");
            dtExport.Columns.Add("Works");
            dtExport.Columns.Add("Date Completed");
            dtExport.Columns.Add("Operative");
            DataRow nr;
            foreach (DataRow dr in VisitsDataview.Table.Rows)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Tick"], true, false)))
                {
                    nr = dtExport.NewRow();
                    string name = Entity.Sys.Helper.MakeStringValid(dr["SiteName"]);
                    if (name.Contains("T2"))
                    {
                        name = name.Substring(0, Strings.InStr(name, "T2") - 1);
                    }

                    name = name.Replace("T1 ", "");
                    name = name.Trim();
                    nr["Resident Name"] = name;
                    nr["Address 1"] = Entity.Sys.Helper.MakeStringValid(dr["Address1"]);
                    nr["Postcode"] = Entity.Sys.Helper.MakeStringValid(dr["Postcode"]);
                    nr["Sub Area"] = Entity.Sys.Helper.MakeStringValid(dr["Address2"]);
                    string phoneNum = "";
                    string orginalPhoneNum = Entity.Sys.Helper.MakeStringValid(dr["TelephoneNum"]);
                    for (int i = 0, loopTo = orginalPhoneNum.Length - 1; i <= loopTo; i++)
                    {
                        if (Information.IsNumeric(orginalPhoneNum[i]) | Conversions.ToString(orginalPhoneNum[i]) == " ")
                        {
                            phoneNum += Conversions.ToString(orginalPhoneNum[i]);
                        }
                    }

                    nr["Contact No."] = "'" + phoneNum;
                    nr["PRI Data"] = Entity.Sys.Helper.MakeStringValid(dr["SiteNotes"]);
                    nr["Works"] = dr["Type"];
                    nr["Date Completed"] = Strings.Format(Entity.Sys.Helper.MakeDateTimeValid(dr["StartDateTime"]), "dd/MMM/yyyy");
                    nr["Operative"] = dr["Engineer"];
                    dtExport.Rows.Add(nr);
                }
            }

            ExportHelper.Export(dtExport, "Gas Summary Spec", Enums.ExportType.XLS);
        }

        public void PopulateDatagrid()
        {
            try
            {
                ResetFilters();
                if (get_GetParameter(0) is null)
                {
                }
                else
                {
                    VisitsDataview = (DataView)get_GetParameter(0);
                    grpFilter.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFilters()
        {
            theCustomer = null;
            var argcombo = cboDefinition;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            var argcombo1 = cboType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, 4702.ToString());
            var argcombo2 = cboStatus;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, 0.ToString());
            var argcombo3 = cboOutcome;
            Combo.SetSelectedComboItem_By_Value(ref argcombo3, 1.ToString());
            txtJobNumber.Text = "";
            txtPostcode.Text = "";
            chkVisitDate.Checked = true;
            if (DateAndTime.Today.DayOfWeek == DayOfWeek.Monday)
            {
                dtpFrom.Value = DateAndTime.Today.AddDays(-1);
                dtpTo.Value = DateAndTime.Today.AddDays(-3);
            }
            else
            {
                dtpFrom.Value = DateAndTime.Today.AddDays(-1);
                dtpTo.Value = DateAndTime.Today.AddDays(-1);
            }

            dtpFrom.Enabled = true;
            dtpTo.Enabled = true;
            grpFilter.Enabled = true;
        }

        private void RunFilter()
        {
            string whereClause = "AND tblEngineerVisit.Deleted = 0 ";
            if (theCustomer is object)
            {
                whereClause += " AND tblCustomer.CustomerID = " + theCustomer.CustomerID + "";
            }

            if (theSite is object)
            {
                whereClause += " AND tblSite.SiteID = " + theSite.SiteID + "";
            }

            if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboDefinition)) == 0))
            {
                whereClause += " AND JobDefinitionEnumID = " + Combo.get_GetSelectedItemValue(cboDefinition) + "";
            }

            if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboType)) == 0))
            {
                whereClause += " AND JobTypeID = " + Combo.get_GetSelectedItemValue(cboType) + "";
            }

            if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboStatus)) == 0))
            {
                whereClause += " AND (CASE ISNULL(tblEngineerVisitCharge.InvoiceReadyID, 0) " + "  WHEN 0 THEN tblEngineerVisit.StatusEnumID " + "  WHEN 1 THEN tblEngineerVisit.StatusEnumID " + "  WHEN 2 THEN  " + " CASE  " + " WHEN ISNULL(tblInvoicedLines.InvoicedLineID, 0)>1 THEN 8 " + " ELSE 7 " + "   End " + " WHEN 3 THEN 6 " + "  End) = " + Combo.get_GetSelectedItemValue(cboStatus);
            }

            if (!(txtJobNumber.Text.Trim().Length == 0))
            {
                whereClause += " AND JobNumber LIKE '" + txtJobNumber.Text.Trim() + "%'";
            }

            if (chkVisitDate.Checked)
            {
                whereClause += " AND StartDateTime >= '" + Strings.Format(dtpFrom.Value, "dd/MMM/yyyy 00:00:00") + "' AND StartDateTime <= '" + Strings.Format(dtpTo.Value, "dd/MMM/yyyy 23:59:59") + "'";
            }

            if (!(txtPostcode.Text.Trim().Length == 0))
            {
                whereClause += " AND tblSite.Postcode LIKE '" + txtPostcode.Text.Trim() + "%'";
            }

            if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboOutcome)) == 0))
            {
                whereClause += " AND OutcomeEnumID = " + Combo.get_GetSelectedItemValue(cboOutcome) + "";
            }

            if (chkExceptionsOnly.Checked)
            {
                whereClause += " AND DefectCount > 0";
            }

            VisitsDataview = App.DB.EngineerVisits.EngineerVisits_Get_All(whereClause);
            grpEngineerVisits.Text = "Double Click To View / Edit - Visits: " + VisitsDataview.Table.Rows.Count;
        }

        public void Export()
        {
            var exportData = new DataTable();
            exportData.Columns.Add("Customer");
            exportData.Columns.Add("Site");
            exportData.Columns.Add("SitePostcode");
            exportData.Columns.Add("JobNumber");
            exportData.Columns.Add("PONumber");
            exportData.Columns.Add("JobDefinition");
            exportData.Columns.Add("Type");
            exportData.Columns.Add("VisitStatus");
            exportData.Columns.Add("StartDateTime");
            exportData.Columns.Add("Engineer");
            exportData.Columns.Add("VisitValue", typeof(decimal));
            exportData.Columns.Add("VisitCharge");
            exportData.Columns.Add("EngineerCost", typeof(decimal));
            exportData.Columns.Add("PartProductCost", typeof(decimal));
            for (int itm = 0, loopTo = ((DataView)dgVisits.DataSource).Count - 1; itm <= loopTo; itm++)
            {
                dgVisits.CurrentRowIndex = itm;
                DataRow newRw;
                newRw = exportData.NewRow();
                newRw["Customer"] = SelectedVisitDataRow["Customer"];
                newRw["Site"] = SelectedVisitDataRow["Site"];
                newRw["SitePostcode"] = SelectedVisitDataRow["SitePostcode"];
                newRw["JobNumber"] = SelectedVisitDataRow["JobNumber"];
                newRw["PONumber"] = SelectedVisitDataRow["PONumber"];
                newRw["JobDefinition"] = SelectedVisitDataRow["JobDefinition"];
                newRw["Type"] = SelectedVisitDataRow["Type"];
                newRw["VisitStatus"] = SelectedVisitDataRow["VisitStatus"];
                newRw["StartDateTime"] = SelectedVisitDataRow["StartDateTime"];
                newRw["Engineer"] = SelectedVisitDataRow["Engineer"];
                newRw["VisitValue"] = SelectedVisitDataRow["VisitValue"];
                newRw["VisitCharge"] = SelectedVisitDataRow["VisitCharge"];
                newRw["EngineerCost"] = SelectedVisitDataRow["EngineerCost"];
                newRw["PartProductCost"] = SelectedVisitDataRow["PartProductCost"];
                exportData.Rows.Add(newRw);
                dgVisits.UnSelect(itm);
            }
        }

        private void dgVisits_DoubleClick(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMEngineerVisit), true, new object[] { SelectedVisitDataRow["EngineerVisitID"] });
        }
    }
}