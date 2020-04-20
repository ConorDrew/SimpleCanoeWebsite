using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FRMJobManager : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMJobManager() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMJobManager_Load;

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

        private GroupBox _grpJobs;

        internal GroupBox grpJobs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpJobs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpJobs != null)
                {
                }

                _grpJobs = value;
                if (_grpJobs != null)
                {
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

        private GroupBox _grpCustomerSearch;

        internal GroupBox grpCustomerSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpCustomerSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpCustomerSearch != null)
                {
                }

                _grpCustomerSearch = value;
                if (_grpCustomerSearch != null)
                {
                }
            }
        }

        private Label _lblCustomer;

        internal Label lblCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCustomer != null)
                {
                }

                _lblCustomer = value;
                if (_lblCustomer != null)
                {
                }
            }
        }

        private Label _lblPostcode;

        internal Label lblPostcode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPostcode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPostcode != null)
                {
                }

                _lblPostcode = value;
                if (_lblPostcode != null)
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
                    _btnReset.Click -= BtnReset_Click;
                }

                _btnReset = value;
                if (_btnReset != null)
                {
                    _btnReset.Click += BtnReset_Click;
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

        private GroupBox _grpMiscSearch;

        internal GroupBox grpMiscSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpMiscSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpMiscSearch != null)
                {
                }

                _grpMiscSearch = value;
                if (_grpMiscSearch != null)
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

        private Label _lblVisitStatus;

        internal Label lblVisitStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblVisitStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblVisitStatus != null)
                {
                }

                _lblVisitStatus = value;
                if (_lblVisitStatus != null)
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

        private Label _lblType;

        internal Label lblType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblType != null)
                {
                }

                _lblType = value;
                if (_lblType != null)
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

        private Label _lblJobNumber;

        internal Label lblJobNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblJobNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblJobNumber != null)
                {
                }

                _lblJobNumber = value;
                if (_lblJobNumber != null)
                {
                }
            }
        }

        private GroupBox _grpDateCriteria;

        internal GroupBox grpDateCriteria
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpDateCriteria;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpDateCriteria != null)
                {
                }

                _grpDateCriteria = value;
                if (_grpDateCriteria != null)
                {
                }
            }
        }

        private RadioButton _rdoNoDate;

        internal RadioButton rdoNoDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rdoNoDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rdoNoDate != null)
                {
                    _rdoNoDate.CheckedChanged -= rdoNoDate_CheckedChanged;
                }

                _rdoNoDate = value;
                if (_rdoNoDate != null)
                {
                    _rdoNoDate.CheckedChanged += rdoNoDate_CheckedChanged;
                }
            }
        }

        private RadioButton _rdoDateCreated;

        internal RadioButton rdoDateCreated
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rdoDateCreated;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rdoDateCreated != null)
                {
                    _rdoDateCreated.CheckedChanged -= rdoDateCreated_CheckChanged;
                }

                _rdoDateCreated = value;
                if (_rdoDateCreated != null)
                {
                    _rdoDateCreated.CheckedChanged += rdoDateCreated_CheckChanged;
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

        private Label _lblDateFrom;

        internal Label lblDateFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDateFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDateFrom != null)
                {
                }

                _lblDateFrom = value;
                if (_lblDateFrom != null)
                {
                }
            }
        }

        private Label _lblDateTo;

        internal Label lblDateTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDateTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDateTo != null)
                {
                }

                _lblDateTo = value;
                if (_lblDateTo != null)
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

        private TextBox _txtPONumber;

        internal TextBox txtPONumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPONumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPONumber != null)
                {
                }

                _txtPONumber = value;
                if (_txtPONumber != null)
                {
                }
            }
        }

        private Label _lbPoNumber;

        internal Label lbPoNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbPoNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbPoNumber != null)
                {
                }

                _lbPoNumber = value;
                if (_lbPoNumber != null)
                {
                }
            }
        }

        private CheckBox _chkNotShut;

        internal CheckBox chkNotShut
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkNotShut;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkNotShut != null)
                {
                }

                _chkNotShut = value;
                if (_chkNotShut != null)
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

        private Label _lblProperty;

        internal Label lblProperty
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblProperty;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblProperty != null)
                {
                }

                _lblProperty = value;
                if (_lblProperty != null)
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

        private DataGrid _dgJobs;

        internal DataGrid dgJobs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgJobs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgJobs != null)
                {
                    _dgJobs.DoubleClick -= dgJobs_DoubleClick;
                }

                _dgJobs = value;
                if (_dgJobs != null)
                {
                    _dgJobs.DoubleClick += dgJobs_DoubleClick;
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

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpJobs = new GroupBox();
            _dgJobs = new DataGrid();
            _dgJobs.DoubleClick += new EventHandler(dgJobs_DoubleClick);
            _pnlFilters = new Panel();
            _btnExport = new Button();
            _btnExport.Click += new EventHandler(btnExport_Click);
            _grpCustomerSearch = new GroupBox();
            _btnFindSite = new Button();
            _btnFindSite.Click += new EventHandler(btnFindSite_Click);
            _txtSite = new TextBox();
            _lblProperty = new Label();
            _lblCustomer = new Label();
            _lblPostcode = new Label();
            _txtPostcode = new TextBox();
            _txtCustomer = new TextBox();
            _btnFindCustomer = new Button();
            _btnFindCustomer.Click += new EventHandler(btnFindCustomer_Click);
            _btnReset = new Button();
            _btnReset.Click += new EventHandler(BtnReset_Click);
            _btnSearch = new Button();
            _btnSearch.Click += new EventHandler(btnSearch_Click);
            _grpMiscSearch = new GroupBox();
            _lblRegion = new Label();
            _cboRegion = new ComboBox();
            _chkNotShut = new CheckBox();
            _txtPONumber = new TextBox();
            _lbPoNumber = new Label();
            _cboStatus = new ComboBox();
            _lblVisitStatus = new Label();
            _cboType = new ComboBox();
            _lblType = new Label();
            _txtJobNumber = new TextBox();
            _lblJobNumber = new Label();
            _grpDateCriteria = new GroupBox();
            _rdoNoDate = new RadioButton();
            _rdoNoDate.CheckedChanged += new EventHandler(rdoNoDate_CheckedChanged);
            _rdoDateCreated = new RadioButton();
            _rdoDateCreated.CheckedChanged += new EventHandler(rdoDateCreated_CheckChanged);
            _dtpFrom = new DateTimePicker();
            _lblDateFrom = new Label();
            _lblDateTo = new Label();
            _dtpTo = new DateTimePicker();
            _grpJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgJobs).BeginInit();
            _pnlFilters.SuspendLayout();
            _grpCustomerSearch.SuspendLayout();
            _grpMiscSearch.SuspendLayout();
            _grpDateCriteria.SuspendLayout();
            SuspendLayout();
            // 
            // grpJobs
            // 
            _grpJobs.Controls.Add(_dgJobs);
            _grpJobs.Dock = DockStyle.Fill;
            _grpJobs.Location = new Point(0, 247);
            _grpJobs.Name = "grpJobs";
            _grpJobs.Size = new Size(1338, 354);
            _grpJobs.TabIndex = 44;
            _grpJobs.TabStop = false;
            _grpJobs.Text = "Results (awaiting search) - Double Click To View / Edit";
            // 
            // dgJobs
            // 
            _dgJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgJobs.DataMember = "";
            _dgJobs.HeaderForeColor = SystemColors.ControlText;
            _dgJobs.Location = new Point(6, 23);
            _dgJobs.Name = "dgJobs";
            _dgJobs.Size = new Size(1326, 298);
            _dgJobs.TabIndex = 15;
            // 
            // pnlFilters
            // 
            _pnlFilters.Controls.Add(_btnExport);
            _pnlFilters.Controls.Add(_grpCustomerSearch);
            _pnlFilters.Controls.Add(_btnReset);
            _pnlFilters.Controls.Add(_btnSearch);
            _pnlFilters.Controls.Add(_grpMiscSearch);
            _pnlFilters.Controls.Add(_grpDateCriteria);
            _pnlFilters.Dock = DockStyle.Top;
            _pnlFilters.Location = new Point(0, 0);
            _pnlFilters.Name = "pnlFilters";
            _pnlFilters.Size = new Size(1338, 247);
            _pnlFilters.TabIndex = 43;
            // 
            // btnExport
            // 
            _btnExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnExport.Location = new Point(964, 218);
            _btnExport.Name = "btnExport";
            _btnExport.Size = new Size(118, 23);
            _btnExport.TabIndex = 40;
            _btnExport.Text = "Export";
            _btnExport.UseVisualStyleBackColor = true;
            // 
            // grpCustomerSearch
            // 
            _grpCustomerSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpCustomerSearch.Controls.Add(_btnFindSite);
            _grpCustomerSearch.Controls.Add(_txtSite);
            _grpCustomerSearch.Controls.Add(_lblProperty);
            _grpCustomerSearch.Controls.Add(_lblCustomer);
            _grpCustomerSearch.Controls.Add(_lblPostcode);
            _grpCustomerSearch.Controls.Add(_txtPostcode);
            _grpCustomerSearch.Controls.Add(_txtCustomer);
            _grpCustomerSearch.Controls.Add(_btnFindCustomer);
            _grpCustomerSearch.Location = new Point(4, 3);
            _grpCustomerSearch.Name = "grpCustomerSearch";
            _grpCustomerSearch.Size = new Size(943, 105);
            _grpCustomerSearch.TabIndex = 37;
            _grpCustomerSearch.TabStop = false;
            _grpCustomerSearch.Text = "Customer";
            // 
            // btnFindSite
            // 
            _btnFindSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindSite.BackColor = Color.White;
            _btnFindSite.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindSite.Location = new Point(912, 43);
            _btnFindSite.Name = "btnFindSite";
            _btnFindSite.Size = new Size(25, 23);
            _btnFindSite.TabIndex = 35;
            _btnFindSite.Text = "...";
            _btnFindSite.UseVisualStyleBackColor = false;
            // 
            // txtSite
            // 
            _txtSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSite.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtSite.Location = new Point(107, 45);
            _txtSite.Name = "txtSite";
            _txtSite.ReadOnly = true;
            _txtSite.Size = new Size(800, 21);
            _txtSite.TabIndex = 34;
            // 
            // lblProperty
            // 
            _lblProperty.Location = new Point(11, 44);
            _lblProperty.Name = "lblProperty";
            _lblProperty.Size = new Size(65, 22);
            _lblProperty.TabIndex = 33;
            _lblProperty.Text = "Property";
            // 
            // lblCustomer
            // 
            _lblCustomer.Location = new Point(11, 17);
            _lblCustomer.Name = "lblCustomer";
            _lblCustomer.Size = new Size(64, 16);
            _lblCustomer.TabIndex = 27;
            _lblCustomer.Text = "Customer";
            // 
            // lblPostcode
            // 
            _lblPostcode.Location = new Point(11, 75);
            _lblPostcode.Name = "lblPostcode";
            _lblPostcode.Size = new Size(64, 16);
            _lblPostcode.TabIndex = 20;
            _lblPostcode.Text = "Postcode";
            // 
            // txtPostcode
            // 
            _txtPostcode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPostcode.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtPostcode.Location = new Point(107, 72);
            _txtPostcode.Name = "txtPostcode";
            _txtPostcode.Size = new Size(830, 21);
            _txtPostcode.TabIndex = 5;
            // 
            // txtCustomer
            // 
            _txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtCustomer.Location = new Point(107, 18);
            _txtCustomer.Name = "txtCustomer";
            _txtCustomer.ReadOnly = true;
            _txtCustomer.Size = new Size(800, 21);
            _txtCustomer.TabIndex = 1;
            // 
            // btnFindCustomer
            // 
            _btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindCustomer.BackColor = Color.White;
            _btnFindCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindCustomer.Location = new Point(912, 17);
            _btnFindCustomer.Name = "btnFindCustomer";
            _btnFindCustomer.Size = new Size(25, 23);
            _btnFindCustomer.TabIndex = 2;
            _btnFindCustomer.Text = "...";
            _btnFindCustomer.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            _btnReset.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnReset.Location = new Point(1088, 218);
            _btnReset.Name = "btnReset";
            _btnReset.Size = new Size(118, 23);
            _btnReset.TabIndex = 16;
            _btnReset.Text = "Reset All Filters";
            _btnReset.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            _btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnSearch.Location = new Point(1212, 218);
            _btnSearch.Name = "btnSearch";
            _btnSearch.Size = new Size(114, 23);
            _btnSearch.TabIndex = 39;
            _btnSearch.Text = "Search";
            _btnSearch.UseVisualStyleBackColor = true;
            // 
            // grpMiscSearch
            // 
            _grpMiscSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _grpMiscSearch.Controls.Add(_lblRegion);
            _grpMiscSearch.Controls.Add(_cboRegion);
            _grpMiscSearch.Controls.Add(_chkNotShut);
            _grpMiscSearch.Controls.Add(_txtPONumber);
            _grpMiscSearch.Controls.Add(_lbPoNumber);
            _grpMiscSearch.Controls.Add(_cboStatus);
            _grpMiscSearch.Controls.Add(_lblVisitStatus);
            _grpMiscSearch.Controls.Add(_cboType);
            _grpMiscSearch.Controls.Add(_lblType);
            _grpMiscSearch.Controls.Add(_txtJobNumber);
            _grpMiscSearch.Controls.Add(_lblJobNumber);
            _grpMiscSearch.Location = new Point(957, 3);
            _grpMiscSearch.Name = "grpMiscSearch";
            _grpMiscSearch.Size = new Size(367, 209);
            _grpMiscSearch.TabIndex = 38;
            _grpMiscSearch.TabStop = false;
            _grpMiscSearch.Text = "Misc";
            // 
            // lblRegion
            // 
            _lblRegion.Location = new Point(8, 77);
            _lblRegion.Name = "lblRegion";
            _lblRegion.Size = new Size(88, 16);
            _lblRegion.TabIndex = 28;
            _lblRegion.Text = "Region";
            // 
            // cboRegion
            // 
            _cboRegion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboRegion.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboRegion.Location = new Point(102, 74);
            _cboRegion.Name = "cboRegion";
            _cboRegion.Size = new Size(259, 21);
            _cboRegion.TabIndex = 27;
            // 
            // chkNotShut
            // 
            _chkNotShut.CheckAlign = ContentAlignment.MiddleRight;
            _chkNotShut.Location = new Point(102, 155);
            _chkNotShut.Name = "chkNotShut";
            _chkNotShut.Size = new Size(245, 32);
            _chkNotShut.TabIndex = 26;
            _chkNotShut.Text = "Only Show Jobs which are not completely shutdown";
            _chkNotShut.UseVisualStyleBackColor = true;
            // 
            // txtPONumber
            // 
            _txtPONumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPONumber.Location = new Point(102, 128);
            _txtPONumber.Name = "txtPONumber";
            _txtPONumber.Size = new Size(259, 21);
            _txtPONumber.TabIndex = 12;
            // 
            // lbPoNumber
            // 
            _lbPoNumber.Location = new Point(8, 128);
            _lbPoNumber.Name = "lbPoNumber";
            _lbPoNumber.Size = new Size(88, 16);
            _lbPoNumber.TabIndex = 11;
            _lbPoNumber.Text = "PO Number";
            // 
            // cboStatus
            // 
            _cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboStatus.Location = new Point(102, 47);
            _cboStatus.Name = "cboStatus";
            _cboStatus.Size = new Size(259, 21);
            _cboStatus.TabIndex = 8;
            // 
            // lblVisitStatus
            // 
            _lblVisitStatus.Location = new Point(8, 50);
            _lblVisitStatus.Name = "lblVisitStatus";
            _lblVisitStatus.Size = new Size(88, 16);
            _lblVisitStatus.TabIndex = 5;
            _lblVisitStatus.Text = "Visit Status";
            // 
            // cboType
            // 
            _cboType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboType.Location = new Point(102, 20);
            _cboType.Name = "cboType";
            _cboType.Size = new Size(259, 21);
            _cboType.TabIndex = 7;
            // 
            // lblType
            // 
            _lblType.Location = new Point(8, 20);
            _lblType.Name = "lblType";
            _lblType.Size = new Size(48, 16);
            _lblType.TabIndex = 4;
            _lblType.Text = "Type";
            // 
            // txtJobNumber
            // 
            _txtJobNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtJobNumber.Location = new Point(102, 101);
            _txtJobNumber.Name = "txtJobNumber";
            _txtJobNumber.Size = new Size(259, 21);
            _txtJobNumber.TabIndex = 9;
            // 
            // lblJobNumber
            // 
            _lblJobNumber.Location = new Point(8, 101);
            _lblJobNumber.Name = "lblJobNumber";
            _lblJobNumber.Size = new Size(79, 16);
            _lblJobNumber.TabIndex = 6;
            _lblJobNumber.Text = "Job Number";
            // 
            // grpDateCriteria
            // 
            _grpDateCriteria.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpDateCriteria.Controls.Add(_rdoNoDate);
            _grpDateCriteria.Controls.Add(_rdoDateCreated);
            _grpDateCriteria.Controls.Add(_dtpFrom);
            _grpDateCriteria.Controls.Add(_lblDateFrom);
            _grpDateCriteria.Controls.Add(_lblDateTo);
            _grpDateCriteria.Controls.Add(_dtpTo);
            _grpDateCriteria.Location = new Point(4, 114);
            _grpDateCriteria.Name = "grpDateCriteria";
            _grpDateCriteria.Size = new Size(943, 98);
            _grpDateCriteria.TabIndex = 36;
            _grpDateCriteria.TabStop = false;
            _grpDateCriteria.Text = "Date Criteria";
            // 
            // rdoNoDate
            // 
            _rdoNoDate.AutoSize = true;
            _rdoNoDate.Checked = true;
            _rdoNoDate.Location = new Point(8, 28);
            _rdoNoDate.Name = "rdoNoDate";
            _rdoNoDate.Size = new Size(54, 17);
            _rdoNoDate.TabIndex = 11;
            _rdoNoDate.TabStop = true;
            _rdoNoDate.Text = "None";
            _rdoNoDate.UseVisualStyleBackColor = true;
            // 
            // rdoDateCreated
            // 
            _rdoDateCreated.AutoSize = true;
            _rdoDateCreated.Location = new Point(8, 48);
            _rdoDateCreated.Name = "rdoDateCreated";
            _rdoDateCreated.Size = new Size(102, 17);
            _rdoDateCreated.TabIndex = 12;
            _rdoDateCreated.Text = "Date Created";
            _rdoDateCreated.UseVisualStyleBackColor = true;
            // 
            // dtpFrom
            // 
            _dtpFrom.Location = new Point(230, 30);
            _dtpFrom.Name = "dtpFrom";
            _dtpFrom.Size = new Size(169, 21);
            _dtpFrom.TabIndex = 14;
            // 
            // lblDateFrom
            // 
            _lblDateFrom.Location = new Point(176, 32);
            _lblDateFrom.Name = "lblDateFrom";
            _lblDateFrom.Size = new Size(48, 16);
            _lblDateFrom.TabIndex = 9;
            _lblDateFrom.Text = "From";
            // 
            // lblDateTo
            // 
            _lblDateTo.Location = new Point(176, 57);
            _lblDateTo.Name = "lblDateTo";
            _lblDateTo.Size = new Size(48, 16);
            _lblDateTo.TabIndex = 10;
            _lblDateTo.Text = "To";
            // 
            // dtpTo
            // 
            _dtpTo.Location = new Point(230, 57);
            _dtpTo.Name = "dtpTo";
            _dtpTo.Size = new Size(169, 21);
            _dtpTo.TabIndex = 15;
            // 
            // FRMJobManager
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(1338, 601);
            Controls.Add(_grpJobs);
            Controls.Add(_pnlFilters);
            MinimumSize = new Size(808, 528);
            Name = "FRMJobManager";
            Text = "Job Manager";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_pnlFilters, 0);
            Controls.SetChildIndex(_grpJobs, 0);
            _grpJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgJobs).EndInit();
            _pnlFilters.ResumeLayout(false);
            _grpCustomerSearch.ResumeLayout(false);
            _grpCustomerSearch.PerformLayout();
            _grpMiscSearch.ResumeLayout(false);
            _grpMiscSearch.PerformLayout();
            _grpDateCriteria.ResumeLayout(false);
            _grpDateCriteria.PerformLayout();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupJobsDataGrid();
            var argc = cboStatus;
            Combo.SetUpCombo(ref argc, DynamicDataTables.VisitStatus_For_Viewing, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter);
            var argc1 = cboType;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter);
            var argc2 = cboRegion;
            Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter);
            rdoDateCreated.Checked = true;
            dtpFrom.Value = DateAndTime.Now.AddMonths(-1);
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
        private int count = 0;
        private DataView _dvJobs;

        private DataView JobsDataview
        {
            get
            {
                return _dvJobs;
            }

            set
            {
                _dvJobs = value;
                if (JobsDataview is object)
                {
                    _dvJobs.AllowNew = false;
                    _dvJobs.AllowEdit = false;
                    _dvJobs.AllowDelete = false;
                    _dvJobs.Table.TableName = Entity.Sys.Enums.TableNames.tblJob.ToString();
                }

                dgJobs.DataSource = JobsDataview;
                if (JobsDataview is object)
                {
                    if (JobsDataview.Table.Rows.Count > 0)
                    {
                        dgJobs.Select(0);
                    }
                }
            }
        }

        private DataRow SelectedJobsDataRow
        {
            get
            {
                if (JobsDataview is null)
                {
                    return null;
                }

                if (!(dgJobs.CurrentRowIndex == -1))
                {
                    return JobsDataview[dgJobs.CurrentRowIndex].Row;
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void SetupJobsDataGrid()
        {
            var tbStyle = dgJobs.TableStyles[0];
            var DateCreated = new DataGridLabelColumn();
            DateCreated.Format = "dd/MMM/yyyy";
            DateCreated.FormatInfo = null;
            DateCreated.HeaderText = "Date Created";
            DateCreated.MappingName = "DateCreated";
            DateCreated.ReadOnly = true;
            DateCreated.Width = 100;
            DateCreated.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(DateCreated);
            var Customer = new DataGridLabelColumn();
            Customer.Format = "";
            Customer.FormatInfo = null;
            Customer.HeaderText = "Customer";
            Customer.MappingName = "Customer";
            Customer.ReadOnly = true;
            Customer.Width = 170;
            Customer.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(Customer);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Name";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 170;
            Name.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(Name);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Property";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 170;
            Site.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(Site);
            var SitePostcode = new DataGridLabelColumn();
            SitePostcode.Format = "";
            SitePostcode.FormatInfo = null;
            SitePostcode.HeaderText = "Postcode";
            SitePostcode.MappingName = "SitePostcode";
            SitePostcode.ReadOnly = true;
            SitePostcode.Width = 170;
            SitePostcode.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(SitePostcode);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job Number";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 90;
            JobNumber.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(JobNumber);
            var Tel = new DataGridLabelColumn();
            Tel.Format = "";
            Tel.FormatInfo = null;
            Tel.HeaderText = "Tel";
            Tel.MappingName = "Telephone";
            Tel.ReadOnly = true;
            Tel.Width = 110;
            Tel.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(Tel);
            var Mobile = new DataGridLabelColumn();
            Mobile.Format = "";
            Mobile.FormatInfo = null;
            Mobile.HeaderText = "Mobile";
            Mobile.MappingName = "Mobile";
            Mobile.ReadOnly = true;
            Mobile.Width = 110;
            Mobile.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(Mobile);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 110;
            Type.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(Type);
            var ContractType = new DataGridLabelColumn();
            ContractType.Format = "";
            ContractType.FormatInfo = null;
            ContractType.HeaderText = "Contract Type";
            ContractType.MappingName = "ContractType";
            ContractType.ReadOnly = true;
            ContractType.Width = 170;
            ContractType.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(ContractType);
            var VisitStatuses = new DataGridLabelColumn();
            VisitStatuses.Format = "";
            VisitStatuses.FormatInfo = null;
            VisitStatuses.HeaderText = "Visit Statuses";
            VisitStatuses.MappingName = "VisitStatuses";
            VisitStatuses.ReadOnly = true;
            VisitStatuses.Width = 170;
            VisitStatuses.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(VisitStatuses);
            var NotesToEngineer = new DataGridLabelColumn();
            NotesToEngineer.Format = "";
            NotesToEngineer.FormatInfo = null;
            NotesToEngineer.HeaderText = "Initial Description";
            NotesToEngineer.MappingName = "NotesToEngineer";
            NotesToEngineer.ReadOnly = true;
            NotesToEngineer.Width = 170;
            NotesToEngineer.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(NotesToEngineer);
            var LastOutcomeDetails = new DataGridLabelColumn();
            LastOutcomeDetails.Format = "";
            LastOutcomeDetails.FormatInfo = null;
            LastOutcomeDetails.HeaderText = "Last Outcome Details";
            LastOutcomeDetails.MappingName = "OutcomeDetails";
            LastOutcomeDetails.ReadOnly = true;
            LastOutcomeDetails.Width = 170;
            LastOutcomeDetails.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(LastOutcomeDetails);
            var CreatedBy = new DataGridLabelColumn();
            CreatedBy.Format = "";
            CreatedBy.FormatInfo = null;
            CreatedBy.HeaderText = "Created By";
            CreatedBy.MappingName = "CreatedBy";
            CreatedBy.ReadOnly = true;
            CreatedBy.Width = 170;
            CreatedBy.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(CreatedBy);
            var isJobOpen = new DataGridLabelColumn();
            isJobOpen.Format = "";
            isJobOpen.FormatInfo = null;
            isJobOpen.HeaderText = "Job Status";
            isJobOpen.MappingName = "JobStatus";
            isJobOpen.ReadOnly = true;
            isJobOpen.Width = 120;
            isJobOpen.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(isJobOpen);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblJob.ToString();
            dgJobs.TableStyles.Add(tbStyle);
        }

        private void FRMJobManager_Load(object sender, EventArgs e)
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
            int ID;
            if (theCustomer is null)
            {
                ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblSite));
            }
            else
            {
                ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblSite, theCustomer.CustomerID));
            }

            if (!(ID == 0))
            {
                theSite = App.DB.Sites.Get(ID);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void rdoDateCreated_CheckChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = rdoDateCreated.Checked;
            dtpTo.Enabled = rdoDateCreated.Checked;
        }

        private void rdoNoDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = !rdoNoDate.Checked;
            dtpTo.Enabled = !rdoNoDate.Checked;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdoNoDate.Checked == true)
            {
                if (App.ShowMessage("No date range is selected, please make sure other fields are selected as this may pull all the files from the database and crash your system, would you like to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PopulateDatagrid(true);
                }
                else
                {
                    return;
                }
            }
            else
            {
                PopulateDatagrid(true);
            }
        }

        private void dgJobs_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedJobsDataRow is null)
            {
                App.ShowMessage("Please select a visit to view", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            App.ShowForm(typeof(FRMLogCallout), true, new object[] { SelectedJobsDataRow["JobID"], SelectedJobsDataRow["SiteID"], this });
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void PopulateDatagrid(bool withRun)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (get_GetParameter(0) is null)
                {
                    DateTime dateFrom = default;
                    DateTime dateTo = default;
                    int customerId = theCustomer is object ? theCustomer.CustomerID : 0;
                    int siteId = theSite is object ? theSite.SiteID : 0;
                    string postcode = txtPostcode.Text.Trim().Length > 0 ? txtPostcode.Text : null;
                    int jobTypeId = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType));
                    int statusEnumId = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboStatus));
                    int regionId = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboRegion));
                    string jobNumber = !(txtJobNumber.Text.Trim().Length == 0) ? Entity.Sys.Helper.CleanText(txtJobNumber.Text.Trim()) : null;
                    string poNumber = !(txtPONumber.Text.Trim().Length == 0) ? Entity.Sys.Helper.CleanText(txtPONumber.Text.Trim()) : null;
                    bool isJobOpen = chkNotShut.Checked;
                    if (rdoDateCreated.Checked)
                    {
                        dateFrom = dtpFrom.Value;
                        dateTo = dtpTo.Value;
                    }

                    JobsDataview = App.DB.Job.Job_Manager_Search(dateFrom, dateTo, jobNumber, postcode, jobTypeId, customerId, siteId, statusEnumId, regionId, poNumber, isJobOpen);
                    count = JobsDataview.Count;
                    grpJobs.Text = "Double Click To View / Edit (" + Conversions.ToString(count) + ")";
                }
                else
                {
                    JobsDataview = null;
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ResetFilters()
        {
            theCustomer = null;
            theSite = null;
            var argcombo = cboType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            var argcombo1 = cboStatus;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, 0.ToString());
            txtJobNumber.Text = "";
            txtPONumber.Text = "";
            txtPostcode.Text = "";
            rdoDateCreated.Checked = true;
            dtpFrom.Value = DateAndTime.Today;
            dtpTo.Value = DateAndTime.Today;
            dtpFrom.Enabled = true;
            dtpTo.Enabled = true;
            dtpFrom.Value = DateAndTime.Now.AddMonths(-1);
            chkNotShut.Checked = false;
        }

        public void Export()
        {
            if (JobsDataview is object)
            {
                Entity.Sys.ExportHelper.Export(JobsDataview.Table, "Job Manager", Entity.Sys.Enums.ExportType.XLS);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}