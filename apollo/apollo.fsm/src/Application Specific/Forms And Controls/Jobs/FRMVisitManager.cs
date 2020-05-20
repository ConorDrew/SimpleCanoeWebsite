using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMVisitManager : FRMBaseForm, IForm
    {
        public FRMVisitManager() : base()
        {
            base.Load += FRMVisitManager_Load;

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
                    _txtPONumber.KeyDown -= txtJobNumber_TextChanged;
                }

                _txtPONumber = value;
                if (_txtPONumber != null)
                {
                    _txtPONumber.KeyDown += txtJobNumber_TextChanged;
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

        private Label _Label7;

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
                    _dgVisits.DoubleClick -= dgVisits_DoubleClick;
                }

                _dgVisits = value;
                if (_dgVisits != null)
                {
                    _dgVisits.DoubleClick += dgVisits_DoubleClick;
                }
            }
        }

        private Button _btnRequiringParts;

        private Button _btnCreateOrder;

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
                    _txtPostcode.TextChanged -= txtPostcode_TextChanged;
                    _txtPostcode.KeyDown -= txtJobNumber_TextChanged;
                }

                _txtPostcode = value;
                if (_txtPostcode != null)
                {
                    _txtPostcode.TextChanged += txtPostcode_TextChanged;
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

        private Button _btnfindEngineer;

        private TextBox _txtEngineer;

        internal TextBox txtEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEngineer != null)
                {
                }

                _txtEngineer = value;
                if (_txtEngineer != null)
                {
                }
            }
        }

        private Label _Label12;

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
                    _cboOutcome.TextChanged -= cboOutcome_TextChanged;
                    _cboOutcome.SelectedIndexChanged -= cboOutcome_SelectedIndexChanged_1;
                }

                _cboOutcome = value;
                if (_cboOutcome != null)
                {
                    _cboOutcome.TextChanged += cboOutcome_TextChanged;
                    _cboOutcome.SelectedIndexChanged += cboOutcome_SelectedIndexChanged_1;
                }
            }
        }

        private Button _btnSearch;

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

        private Label _Label14;

        private ComboBox _CboServExp;

        internal ComboBox CboServExp
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CboServExp;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CboServExp != null)
                {
                }

                _CboServExp = value;
                if (_CboServExp != null)
                {
                }
            }
        }

        private Label _Label15;

        private ComboBox _cboDepartment;

        internal ComboBox cboDepartment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDepartment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDepartment != null)
                {
                }

                _cboDepartment = value;
                if (_cboDepartment != null)
                {
                }
            }
        }

        private CheckBox _chkftfcode;

        internal CheckBox chkftfcode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkftfcode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkftfcode != null)
                {
                }

                _chkftfcode = value;
                if (_chkftfcode != null)
                {
                }
            }
        }

        private Label _Label16;

        private ComboBox _cboLetterNumber;

        internal ComboBox cboLetterNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboLetterNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboLetterNumber != null)
                {
                }

                _cboLetterNumber = value;
                if (_cboLetterNumber != null)
                {
                }
            }
        }

        private Label _Label17;

        private ComboBox _cboPriority;

        internal ComboBox cboPriority
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPriority;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPriority != null)
                {
                }

                _cboPriority = value;
                if (_cboPriority != null)
                {
                }
            }
        }

        private DateTimePicker _dtpToServiceDate;

        internal DateTimePicker dtpToServiceDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpToServiceDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpToServiceDate != null)
                {
                }

                _dtpToServiceDate = value;
                if (_dtpToServiceDate != null)
                {
                }
            }
        }

        private DateTimePicker _dtpFromServiceDate;

        internal DateTimePicker dtpFromServiceDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpFromServiceDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpFromServiceDate != null)
                {
                }

                _dtpFromServiceDate = value;
                if (_dtpFromServiceDate != null)
                {
                }
            }
        }

        private Label _Label18;

        private Label _Label19;

        private CheckBox _chkServiceDate;

        internal CheckBox chkServiceDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkServiceDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkServiceDate != null)
                {
                }

                _chkServiceDate = value;
                if (_chkServiceDate != null)
                {
                }
            }
        }

        private DateTimePicker _dtpVisitEndTo;

        internal DateTimePicker dtpVisitEndTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpVisitEndTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpVisitEndTo != null)
                {
                }

                _dtpVisitEndTo = value;
                if (_dtpVisitEndTo != null)
                {
                }
            }
        }

        private DateTimePicker _dtpVisitEndFrom;

        internal DateTimePicker dtpVisitEndFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpVisitEndFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpVisitEndFrom != null)
                {
                }

                _dtpVisitEndFrom = value;
                if (_dtpVisitEndFrom != null)
                {
                }
            }
        }

        private Label _lblVisitEndTo;

        private Label _lblVisitEndFrom;

        private CheckBox _chkVisitEnd;

        internal CheckBox chkVisitEnd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkVisitEnd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkVisitEnd != null)
                {
                    _chkVisitEnd.CheckedChanged -= chkVisitEnd_CheckedChanged;
                }

                _chkVisitEnd = value;
                if (_chkVisitEnd != null)
                {
                    _chkVisitEnd.CheckedChanged += chkVisitEnd_CheckedChanged;
                }
            }
        }

        private CheckBox _chkRecharge;

        internal CheckBox chkRecharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkRecharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkRecharge != null)
                {
                }

                _chkRecharge = value;
                if (_chkRecharge != null)
                {
                }
            }
        }

        private Label _lblVisitCharge;

        private ComboBox _cboVisitCharge;

        internal ComboBox cboVisitCharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboVisitCharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboVisitCharge != null)
                {
                }

                _cboVisitCharge = value;
                if (_cboVisitCharge != null)
                {
                }
            }
        }

        private Label _lblNonChargeable;

        private Label _lblGreenColour;

        private Label _lblVisitChargeable;

        private Label _lblYellowColour;

        private Label _lblQualification;

        internal Label lblQualification
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQualification;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQualification != null)
                {
                }

                _lblQualification = value;
                if (_lblQualification != null)
                {
                }
            }
        }

        private ComboBox _cboQualification;

        internal ComboBox cboQualification
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQualification;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQualification != null)
                {
                }

                _cboQualification = value;
                if (_cboQualification != null)
                {
                }
            }
        }

        private Label _Label5;

        internal Label Label5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label5 != null)
                {
                }

                _Label5 = value;
                if (_Label5 != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._grpEngineerVisits = new System.Windows.Forms.GroupBox();
            this._dgVisits = new System.Windows.Forms.DataGrid();
            this._btnExport = new System.Windows.Forms.Button();
            this._grpFilter = new System.Windows.Forms.GroupBox();
            this._lblQualification = new System.Windows.Forms.Label();
            this._cboQualification = new System.Windows.Forms.ComboBox();
            this._lblNonChargeable = new System.Windows.Forms.Label();
            this._lblGreenColour = new System.Windows.Forms.Label();
            this._lblVisitChargeable = new System.Windows.Forms.Label();
            this._lblYellowColour = new System.Windows.Forms.Label();
            this._lblVisitCharge = new System.Windows.Forms.Label();
            this._cboVisitCharge = new System.Windows.Forms.ComboBox();
            this._chkRecharge = new System.Windows.Forms.CheckBox();
            this._dtpVisitEndTo = new System.Windows.Forms.DateTimePicker();
            this._dtpVisitEndFrom = new System.Windows.Forms.DateTimePicker();
            this._lblVisitEndTo = new System.Windows.Forms.Label();
            this._lblVisitEndFrom = new System.Windows.Forms.Label();
            this._chkVisitEnd = new System.Windows.Forms.CheckBox();
            this._dtpToServiceDate = new System.Windows.Forms.DateTimePicker();
            this._dtpFromServiceDate = new System.Windows.Forms.DateTimePicker();
            this._Label18 = new System.Windows.Forms.Label();
            this._Label19 = new System.Windows.Forms.Label();
            this._chkServiceDate = new System.Windows.Forms.CheckBox();
            this._Label17 = new System.Windows.Forms.Label();
            this._cboPriority = new System.Windows.Forms.ComboBox();
            this._Label16 = new System.Windows.Forms.Label();
            this._cboLetterNumber = new System.Windows.Forms.ComboBox();
            this._chkftfcode = new System.Windows.Forms.CheckBox();
            this._Label15 = new System.Windows.Forms.Label();
            this._cboDepartment = new System.Windows.Forms.ComboBox();
            this._Label14 = new System.Windows.Forms.Label();
            this._CboServExp = new System.Windows.Forms.ComboBox();
            this._Label13 = new System.Windows.Forms.Label();
            this._cboRegion = new System.Windows.Forms.ComboBox();
            this._btnSearch = new System.Windows.Forms.Button();
            this._Label12 = new System.Windows.Forms.Label();
            this._cboOutcome = new System.Windows.Forms.ComboBox();
            this._btnfindEngineer = new System.Windows.Forms.Button();
            this._txtEngineer = new System.Windows.Forms.TextBox();
            this._Label5 = new System.Windows.Forms.Label();
            this._btnFindCustomer = new System.Windows.Forms.Button();
            this._txtCustomer = new System.Windows.Forms.TextBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._txtPostcode = new System.Windows.Forms.TextBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._btnFindSite = new System.Windows.Forms.Button();
            this._txtSite = new System.Windows.Forms.TextBox();
            this._dtpTo = new System.Windows.Forms.DateTimePicker();
            this._dtpFrom = new System.Windows.Forms.DateTimePicker();
            this._txtPONumber = new System.Windows.Forms.TextBox();
            this._txtJobNumber = new System.Windows.Forms.TextBox();
            this._Label9 = new System.Windows.Forms.Label();
            this._Label8 = new System.Windows.Forms.Label();
            this._chkVisitDate = new System.Windows.Forms.CheckBox();
            this._Label7 = new System.Windows.Forms.Label();
            this._Label6 = new System.Windows.Forms.Label();
            this._Label2 = new System.Windows.Forms.Label();
            this._Label10 = new System.Windows.Forms.Label();
            this._cboType = new System.Windows.Forms.ComboBox();
            this._Label11 = new System.Windows.Forms.Label();
            this._cboStatus = new System.Windows.Forms.ComboBox();
            this._Label3 = new System.Windows.Forms.Label();
            this._cboDefinition = new System.Windows.Forms.ComboBox();
            this._btnReset = new System.Windows.Forms.Button();
            this._btnRequiringParts = new System.Windows.Forms.Button();
            this._btnCreateOrder = new System.Windows.Forms.Button();
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
            this._grpEngineerVisits.Location = new System.Drawing.Point(8, 283);
            this._grpEngineerVisits.Name = "_grpEngineerVisits";
            this._grpEngineerVisits.Size = new System.Drawing.Size(1438, 242);
            this._grpEngineerVisits.TabIndex = 2;
            this._grpEngineerVisits.TabStop = false;
            // 
            // _dgVisits
            // 
            this._dgVisits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgVisits.DataMember = "";
            this._dgVisits.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgVisits.Location = new System.Drawing.Point(8, 20);
            this._dgVisits.Name = "_dgVisits";
            this._dgVisits.Size = new System.Drawing.Size(1422, 214);
            this._dgVisits.TabIndex = 14;
            this._dgVisits.DoubleClick += new System.EventHandler(this.dgVisits_DoubleClick);
            // 
            // _btnExport
            // 
            this._btnExport.AccessibleDescription = "Export Job List To Excel";
            this._btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnExport.Location = new System.Drawing.Point(8, 531);
            this._btnExport.Name = "_btnExport";
            this._btnExport.Size = new System.Drawing.Size(56, 23);
            this._btnExport.TabIndex = 15;
            this._btnExport.Text = "Export";
            this._btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // _grpFilter
            // 
            this._grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpFilter.Controls.Add(this._lblQualification);
            this._grpFilter.Controls.Add(this._cboQualification);
            this._grpFilter.Controls.Add(this._lblNonChargeable);
            this._grpFilter.Controls.Add(this._lblGreenColour);
            this._grpFilter.Controls.Add(this._lblVisitChargeable);
            this._grpFilter.Controls.Add(this._lblYellowColour);
            this._grpFilter.Controls.Add(this._lblVisitCharge);
            this._grpFilter.Controls.Add(this._cboVisitCharge);
            this._grpFilter.Controls.Add(this._chkRecharge);
            this._grpFilter.Controls.Add(this._dtpVisitEndTo);
            this._grpFilter.Controls.Add(this._dtpVisitEndFrom);
            this._grpFilter.Controls.Add(this._lblVisitEndTo);
            this._grpFilter.Controls.Add(this._lblVisitEndFrom);
            this._grpFilter.Controls.Add(this._chkVisitEnd);
            this._grpFilter.Controls.Add(this._dtpToServiceDate);
            this._grpFilter.Controls.Add(this._dtpFromServiceDate);
            this._grpFilter.Controls.Add(this._Label18);
            this._grpFilter.Controls.Add(this._Label19);
            this._grpFilter.Controls.Add(this._chkServiceDate);
            this._grpFilter.Controls.Add(this._Label17);
            this._grpFilter.Controls.Add(this._cboPriority);
            this._grpFilter.Controls.Add(this._Label16);
            this._grpFilter.Controls.Add(this._cboLetterNumber);
            this._grpFilter.Controls.Add(this._chkftfcode);
            this._grpFilter.Controls.Add(this._Label15);
            this._grpFilter.Controls.Add(this._cboDepartment);
            this._grpFilter.Controls.Add(this._Label14);
            this._grpFilter.Controls.Add(this._CboServExp);
            this._grpFilter.Controls.Add(this._Label13);
            this._grpFilter.Controls.Add(this._cboRegion);
            this._grpFilter.Controls.Add(this._btnSearch);
            this._grpFilter.Controls.Add(this._Label12);
            this._grpFilter.Controls.Add(this._cboOutcome);
            this._grpFilter.Controls.Add(this._btnfindEngineer);
            this._grpFilter.Controls.Add(this._txtEngineer);
            this._grpFilter.Controls.Add(this._Label5);
            this._grpFilter.Controls.Add(this._btnFindCustomer);
            this._grpFilter.Controls.Add(this._txtCustomer);
            this._grpFilter.Controls.Add(this._Label4);
            this._grpFilter.Controls.Add(this._txtPostcode);
            this._grpFilter.Controls.Add(this._Label1);
            this._grpFilter.Controls.Add(this._btnFindSite);
            this._grpFilter.Controls.Add(this._txtSite);
            this._grpFilter.Controls.Add(this._dtpTo);
            this._grpFilter.Controls.Add(this._dtpFrom);
            this._grpFilter.Controls.Add(this._txtPONumber);
            this._grpFilter.Controls.Add(this._txtJobNumber);
            this._grpFilter.Controls.Add(this._Label9);
            this._grpFilter.Controls.Add(this._Label8);
            this._grpFilter.Controls.Add(this._chkVisitDate);
            this._grpFilter.Controls.Add(this._Label7);
            this._grpFilter.Controls.Add(this._Label6);
            this._grpFilter.Controls.Add(this._Label2);
            this._grpFilter.Controls.Add(this._Label10);
            this._grpFilter.Controls.Add(this._cboType);
            this._grpFilter.Controls.Add(this._Label11);
            this._grpFilter.Controls.Add(this._cboStatus);
            this._grpFilter.Location = new System.Drawing.Point(8, 12);
            this._grpFilter.Name = "_grpFilter";
            this._grpFilter.Size = new System.Drawing.Size(1438, 271);
            this._grpFilter.TabIndex = 1;
            this._grpFilter.TabStop = false;
            this._grpFilter.Text = "Filter";
            // 
            // _lblQualification
            // 
            this._lblQualification.BackColor = System.Drawing.Color.Transparent;
            this._lblQualification.Location = new System.Drawing.Point(662, 150);
            this._lblQualification.Name = "_lblQualification";
            this._lblQualification.Size = new System.Drawing.Size(90, 16);
            this._lblQualification.TabIndex = 63;
            this._lblQualification.Text = "Qualification";
            // 
            // _cboQualification
            // 
            this._cboQualification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboQualification.Location = new System.Drawing.Point(776, 147);
            this._cboQualification.Name = "_cboQualification";
            this._cboQualification.Size = new System.Drawing.Size(266, 21);
            this._cboQualification.TabIndex = 62;
            // 
            // _lblNonChargeable
            // 
            this._lblNonChargeable.Location = new System.Drawing.Point(876, 244);
            this._lblNonChargeable.Name = "_lblNonChargeable";
            this._lblNonChargeable.Size = new System.Drawing.Size(139, 16);
            this._lblNonChargeable.TabIndex = 61;
            this._lblNonChargeable.Text = "Non-Chargeable Visit";
            // 
            // _lblGreenColour
            // 
            this._lblGreenColour.BackColor = System.Drawing.Color.LightGreen;
            this._lblGreenColour.Location = new System.Drawing.Point(850, 240);
            this._lblGreenColour.Name = "_lblGreenColour";
            this._lblGreenColour.Size = new System.Drawing.Size(20, 20);
            this._lblGreenColour.TabIndex = 60;
            // 
            // _lblVisitChargeable
            // 
            this._lblVisitChargeable.Location = new System.Drawing.Point(738, 244);
            this._lblVisitChargeable.Name = "_lblVisitChargeable";
            this._lblVisitChargeable.Size = new System.Drawing.Size(109, 17);
            this._lblVisitChargeable.TabIndex = 59;
            this._lblVisitChargeable.Text = "Chargeable Visit";
            // 
            // _lblYellowColour
            // 
            this._lblYellowColour.BackColor = System.Drawing.Color.Yellow;
            this._lblYellowColour.Location = new System.Drawing.Point(712, 240);
            this._lblYellowColour.Name = "_lblYellowColour";
            this._lblYellowColour.Size = new System.Drawing.Size(20, 20);
            this._lblYellowColour.TabIndex = 58;
            // 
            // _lblVisitCharge
            // 
            this._lblVisitCharge.Location = new System.Drawing.Point(662, 117);
            this._lblVisitCharge.Name = "_lblVisitCharge";
            this._lblVisitCharge.Size = new System.Drawing.Size(108, 20);
            this._lblVisitCharge.TabIndex = 57;
            this._lblVisitCharge.Text = "Visit Chargeable?";
            // 
            // _cboVisitCharge
            // 
            this._cboVisitCharge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboVisitCharge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboVisitCharge.Location = new System.Drawing.Point(776, 113);
            this._cboVisitCharge.MinimumSize = new System.Drawing.Size(70, 0);
            this._cboVisitCharge.Name = "_cboVisitCharge";
            this._cboVisitCharge.Size = new System.Drawing.Size(297, 21);
            this._cboVisitCharge.TabIndex = 56;
            // 
            // _chkRecharge
            // 
            this._chkRecharge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chkRecharge.Cursor = System.Windows.Forms.Cursors.Hand;
            this._chkRecharge.Location = new System.Drawing.Point(1106, 209);
            this._chkRecharge.Name = "_chkRecharge";
            this._chkRecharge.Size = new System.Drawing.Size(95, 24);
            this._chkRecharge.TabIndex = 55;
            this._chkRecharge.Text = "Recharge";
            this._chkRecharge.UseVisualStyleBackColor = true;
            // 
            // _dtpVisitEndTo
            // 
            this._dtpVisitEndTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpVisitEndTo.Enabled = false;
            this._dtpVisitEndTo.Location = new System.Drawing.Point(1274, 118);
            this._dtpVisitEndTo.Name = "_dtpVisitEndTo";
            this._dtpVisitEndTo.Size = new System.Drawing.Size(156, 21);
            this._dtpVisitEndTo.TabIndex = 54;
            // 
            // _dtpVisitEndFrom
            // 
            this._dtpVisitEndFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpVisitEndFrom.Enabled = false;
            this._dtpVisitEndFrom.Location = new System.Drawing.Point(1274, 91);
            this._dtpVisitEndFrom.Name = "_dtpVisitEndFrom";
            this._dtpVisitEndFrom.Size = new System.Drawing.Size(156, 21);
            this._dtpVisitEndFrom.TabIndex = 53;
            // 
            // _lblVisitEndTo
            // 
            this._lblVisitEndTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblVisitEndTo.Location = new System.Drawing.Point(1220, 121);
            this._lblVisitEndTo.Name = "_lblVisitEndTo";
            this._lblVisitEndTo.Size = new System.Drawing.Size(48, 16);
            this._lblVisitEndTo.TabIndex = 51;
            this._lblVisitEndTo.Text = "To";
            // 
            // _lblVisitEndFrom
            // 
            this._lblVisitEndFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblVisitEndFrom.Location = new System.Drawing.Point(1220, 93);
            this._lblVisitEndFrom.Name = "_lblVisitEndFrom";
            this._lblVisitEndFrom.Size = new System.Drawing.Size(48, 16);
            this._lblVisitEndFrom.TabIndex = 50;
            this._lblVisitEndFrom.Text = "From";
            // 
            // _chkVisitEnd
            // 
            this._chkVisitEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chkVisitEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this._chkVisitEnd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._chkVisitEnd.Location = new System.Drawing.Point(1106, 84);
            this._chkVisitEnd.Name = "_chkVisitEnd";
            this._chkVisitEnd.Size = new System.Drawing.Size(115, 24);
            this._chkVisitEnd.TabIndex = 52;
            this._chkVisitEnd.Text = "Visit End Date";
            this._chkVisitEnd.CheckedChanged += new System.EventHandler(this.chkVisitEnd_CheckedChanged);
            // 
            // _dtpToServiceDate
            // 
            this._dtpToServiceDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpToServiceDate.Location = new System.Drawing.Point(1274, 184);
            this._dtpToServiceDate.Name = "_dtpToServiceDate";
            this._dtpToServiceDate.Size = new System.Drawing.Size(158, 21);
            this._dtpToServiceDate.TabIndex = 49;
            // 
            // _dtpFromServiceDate
            // 
            this._dtpFromServiceDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpFromServiceDate.Location = new System.Drawing.Point(1274, 153);
            this._dtpFromServiceDate.Name = "_dtpFromServiceDate";
            this._dtpFromServiceDate.Size = new System.Drawing.Size(158, 21);
            this._dtpFromServiceDate.TabIndex = 48;
            // 
            // _Label18
            // 
            this._Label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label18.Location = new System.Drawing.Point(1220, 187);
            this._Label18.Name = "_Label18";
            this._Label18.Size = new System.Drawing.Size(48, 16);
            this._Label18.TabIndex = 46;
            this._Label18.Text = "To";
            // 
            // _Label19
            // 
            this._Label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label19.Location = new System.Drawing.Point(1220, 155);
            this._Label19.Name = "_Label19";
            this._Label19.Size = new System.Drawing.Size(48, 16);
            this._Label19.TabIndex = 45;
            this._Label19.Text = "From";
            // 
            // _chkServiceDate
            // 
            this._chkServiceDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chkServiceDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this._chkServiceDate.Location = new System.Drawing.Point(1106, 150);
            this._chkServiceDate.Name = "_chkServiceDate";
            this._chkServiceDate.Size = new System.Drawing.Size(95, 24);
            this._chkServiceDate.TabIndex = 47;
            this._chkServiceDate.Text = "Service Date";
            this._chkServiceDate.UseVisualStyleBackColor = true;
            // 
            // _Label17
            // 
            this._Label17.BackColor = System.Drawing.Color.Transparent;
            this._Label17.Location = new System.Drawing.Point(6, 248);
            this._Label17.Name = "_Label17";
            this._Label17.Size = new System.Drawing.Size(94, 15);
            this._Label17.TabIndex = 44;
            this._Label17.Text = "Priority";
            // 
            // _cboPriority
            // 
            this._cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboPriority.Location = new System.Drawing.Point(104, 243);
            this._cboPriority.Name = "_cboPriority";
            this._cboPriority.Size = new System.Drawing.Size(184, 21);
            this._cboPriority.TabIndex = 43;
            // 
            // _Label16
            // 
            this._Label16.BackColor = System.Drawing.Color.Transparent;
            this._Label16.Location = new System.Drawing.Point(295, 244);
            this._Label16.Name = "_Label16";
            this._Label16.Size = new System.Drawing.Size(90, 16);
            this._Label16.TabIndex = 42;
            this._Label16.Text = "Letter Number";
            // 
            // _cboLetterNumber
            // 
            this._cboLetterNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboLetterNumber.Location = new System.Drawing.Point(390, 240);
            this._cboLetterNumber.Name = "_cboLetterNumber";
            this._cboLetterNumber.Size = new System.Drawing.Size(266, 21);
            this._cboLetterNumber.TabIndex = 41;
            // 
            // _chkftfcode
            // 
            this._chkftfcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chkftfcode.Cursor = System.Windows.Forms.Cursors.Hand;
            this._chkftfcode.Location = new System.Drawing.Point(1335, 213);
            this._chkftfcode.Name = "_chkftfcode";
            this._chkftfcode.Size = new System.Drawing.Size(95, 17);
            this._chkftfcode.TabIndex = 40;
            this._chkftfcode.Text = "No FTF code";
            this._chkftfcode.UseVisualStyleBackColor = true;
            this._chkftfcode.Visible = false;
            // 
            // _Label15
            // 
            this._Label15.Location = new System.Drawing.Point(296, 120);
            this._Label15.Name = "_Label15";
            this._Label15.Size = new System.Drawing.Size(81, 20);
            this._Label15.TabIndex = 39;
            this._Label15.Text = "Cost Centre";
            // 
            // _cboDepartment
            // 
            this._cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboDepartment.Location = new System.Drawing.Point(390, 116);
            this._cboDepartment.Name = "_cboDepartment";
            this._cboDepartment.Size = new System.Drawing.Size(266, 21);
            this._cboDepartment.TabIndex = 38;
            // 
            // _Label14
            // 
            this._Label14.BackColor = System.Drawing.Color.Transparent;
            this._Label14.Location = new System.Drawing.Point(6, 220);
            this._Label14.Name = "_Label14";
            this._Label14.Size = new System.Drawing.Size(96, 13);
            this._Label14.TabIndex = 37;
            this._Label14.Text = "Serv Expires in";
            // 
            // _CboServExp
            // 
            this._CboServExp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._CboServExp.Location = new System.Drawing.Point(104, 214);
            this._CboServExp.Name = "_CboServExp";
            this._CboServExp.Size = new System.Drawing.Size(184, 21);
            this._CboServExp.TabIndex = 36;
            // 
            // _Label13
            // 
            this._Label13.Location = new System.Drawing.Point(6, 153);
            this._Label13.Name = "_Label13";
            this._Label13.Size = new System.Drawing.Size(72, 16);
            this._Label13.TabIndex = 35;
            this._Label13.Text = "Region";
            // 
            // _cboRegion
            // 
            this._cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboRegion.Location = new System.Drawing.Point(104, 149);
            this._cboRegion.Name = "_cboRegion";
            this._cboRegion.Size = new System.Drawing.Size(184, 21);
            this._cboRegion.TabIndex = 34;
            // 
            // _btnSearch
            // 
            this._btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSearch.Location = new System.Drawing.Point(1360, 242);
            this._btnSearch.Name = "_btnSearch";
            this._btnSearch.Size = new System.Drawing.Size(70, 23);
            this._btnSearch.TabIndex = 33;
            this._btnSearch.Text = "Run Filter";
            this._btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // _Label12
            // 
            this._Label12.Location = new System.Drawing.Point(296, 181);
            this._Label12.Name = "_Label12";
            this._Label12.Size = new System.Drawing.Size(62, 22);
            this._Label12.TabIndex = 31;
            this._Label12.Text = "Outcome";
            // 
            // _cboOutcome
            // 
            this._cboOutcome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboOutcome.Location = new System.Drawing.Point(390, 178);
            this._cboOutcome.Name = "_cboOutcome";
            this._cboOutcome.Size = new System.Drawing.Size(266, 21);
            this._cboOutcome.TabIndex = 32;
            this._cboOutcome.SelectedIndexChanged += new System.EventHandler(this.cboOutcome_SelectedIndexChanged_1);
            this._cboOutcome.TextChanged += new System.EventHandler(this.cboOutcome_TextChanged);
            // 
            // _btnfindEngineer
            // 
            this._btnfindEngineer.BackColor = System.Drawing.Color.White;
            this._btnfindEngineer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnfindEngineer.Location = new System.Drawing.Point(624, 85);
            this._btnfindEngineer.Name = "_btnfindEngineer";
            this._btnfindEngineer.Size = new System.Drawing.Size(32, 23);
            this._btnfindEngineer.TabIndex = 29;
            this._btnfindEngineer.Text = "...";
            this._btnfindEngineer.UseVisualStyleBackColor = false;
            this._btnfindEngineer.Click += new System.EventHandler(this.btnfindEngineer_Click);
            // 
            // _txtEngineer
            // 
            this._txtEngineer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEngineer.Location = new System.Drawing.Point(390, 86);
            this._txtEngineer.Name = "_txtEngineer";
            this._txtEngineer.ReadOnly = true;
            this._txtEngineer.Size = new System.Drawing.Size(228, 21);
            this._txtEngineer.TabIndex = 28;
            // 
            // _Label5
            // 
            this._Label5.Location = new System.Drawing.Point(296, 88);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(70, 16);
            this._Label5.TabIndex = 30;
            this._Label5.Text = "Engineer";
            // 
            // _btnFindCustomer
            // 
            this._btnFindCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindCustomer.BackColor = System.Drawing.Color.White;
            this._btnFindCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindCustomer.Location = new System.Drawing.Point(1043, 26);
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
            this._txtCustomer.Location = new System.Drawing.Point(104, 25);
            this._txtCustomer.Name = "_txtCustomer";
            this._txtCustomer.ReadOnly = true;
            this._txtCustomer.Size = new System.Drawing.Size(933, 21);
            this._txtCustomer.TabIndex = 1;
            // 
            // _Label4
            // 
            this._Label4.Location = new System.Drawing.Point(8, 24);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(64, 16);
            this._Label4.TabIndex = 27;
            this._Label4.Text = "Customer";
            // 
            // _txtPostcode
            // 
            this._txtPostcode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtPostcode.Location = new System.Drawing.Point(104, 85);
            this._txtPostcode.Name = "_txtPostcode";
            this._txtPostcode.Size = new System.Drawing.Size(184, 21);
            this._txtPostcode.TabIndex = 5;
            this._txtPostcode.TextChanged += new System.EventHandler(this.txtPostcode_TextChanged);
            this._txtPostcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJobNumber_TextChanged);
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(8, 88);
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
            this._btnFindSite.Location = new System.Drawing.Point(1043, 53);
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
            this._txtSite.Location = new System.Drawing.Point(104, 55);
            this._txtSite.Name = "_txtSite";
            this._txtSite.ReadOnly = true;
            this._txtSite.Size = new System.Drawing.Size(933, 21);
            this._txtSite.TabIndex = 3;
            // 
            // _dtpTo
            // 
            this._dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpTo.Location = new System.Drawing.Point(1274, 56);
            this._dtpTo.Name = "_dtpTo";
            this._dtpTo.Size = new System.Drawing.Size(156, 21);
            this._dtpTo.TabIndex = 13;
            // 
            // _dtpFrom
            // 
            this._dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpFrom.Location = new System.Drawing.Point(1274, 29);
            this._dtpFrom.Name = "_dtpFrom";
            this._dtpFrom.Size = new System.Drawing.Size(156, 21);
            this._dtpFrom.TabIndex = 12;
            // 
            // _txtPONumber
            // 
            this._txtPONumber.Location = new System.Drawing.Point(104, 182);
            this._txtPONumber.Name = "_txtPONumber";
            this._txtPONumber.Size = new System.Drawing.Size(184, 21);
            this._txtPONumber.TabIndex = 10;
            this._txtPONumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJobNumber_TextChanged);
            // 
            // _txtJobNumber
            // 
            this._txtJobNumber.Location = new System.Drawing.Point(390, 210);
            this._txtJobNumber.Name = "_txtJobNumber";
            this._txtJobNumber.Size = new System.Drawing.Size(266, 21);
            this._txtJobNumber.TabIndex = 9;
            this._txtJobNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJobNumber_TextChanged);
            // 
            // _Label9
            // 
            this._Label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label9.Location = new System.Drawing.Point(1220, 59);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(48, 16);
            this._Label9.TabIndex = 10;
            this._Label9.Text = "To";
            // 
            // _Label8
            // 
            this._Label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label8.Location = new System.Drawing.Point(1220, 31);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(48, 16);
            this._Label8.TabIndex = 9;
            this._Label8.Text = "From";
            // 
            // _chkVisitDate
            // 
            this._chkVisitDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chkVisitDate.Checked = true;
            this._chkVisitDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkVisitDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this._chkVisitDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._chkVisitDate.Location = new System.Drawing.Point(1106, 26);
            this._chkVisitDate.Name = "_chkVisitDate";
            this._chkVisitDate.Size = new System.Drawing.Size(80, 24);
            this._chkVisitDate.TabIndex = 11;
            this._chkVisitDate.Text = "Visit Date";
            this._chkVisitDate.CheckedChanged += new System.EventHandler(this.chkVisitDate_CheckedChanged);
            // 
            // _Label7
            // 
            this._Label7.Location = new System.Drawing.Point(8, 187);
            this._Label7.Name = "_Label7";
            this._Label7.Size = new System.Drawing.Size(88, 16);
            this._Label7.TabIndex = 7;
            this._Label7.Text = "PO Number";
            // 
            // _Label6
            // 
            this._Label6.Location = new System.Drawing.Point(297, 216);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(80, 16);
            this._Label6.TabIndex = 6;
            this._Label6.Text = "Job Number";
            // 
            // _Label2
            // 
            this._Label2.Location = new System.Drawing.Point(8, 56);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(64, 16);
            this._Label2.TabIndex = 2;
            this._Label2.Text = "Property";
            // 
            // _Label10
            // 
            this._Label10.Location = new System.Drawing.Point(296, 150);
            this._Label10.Name = "_Label10";
            this._Label10.Size = new System.Drawing.Size(70, 22);
            this._Label10.TabIndex = 4;
            this._Label10.Text = "Job Type";
            // 
            // _cboType
            // 
            this._cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboType.Location = new System.Drawing.Point(390, 147);
            this._cboType.Name = "_cboType";
            this._cboType.Size = new System.Drawing.Size(266, 21);
            this._cboType.TabIndex = 7;
            // 
            // _Label11
            // 
            this._Label11.Location = new System.Drawing.Point(6, 123);
            this._Label11.Name = "_Label11";
            this._Label11.Size = new System.Drawing.Size(48, 22);
            this._Label11.TabIndex = 5;
            this._Label11.Text = "Status";
            // 
            // _cboStatus
            // 
            this._cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboStatus.Location = new System.Drawing.Point(104, 117);
            this._cboStatus.Name = "_cboStatus";
            this._cboStatus.Size = new System.Drawing.Size(184, 21);
            this._cboStatus.TabIndex = 8;
            // 
            // _Label3
            // 
            this._Label3.Location = new System.Drawing.Point(8, 116);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(72, 16);
            this._Label3.TabIndex = 3;
            this._Label3.Text = "Definition";
            // 
            // _cboDefinition
            // 
            this._cboDefinition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboDefinition.Location = new System.Drawing.Point(104, 116);
            this._cboDefinition.Name = "_cboDefinition";
            this._cboDefinition.Size = new System.Drawing.Size(184, 21);
            this._cboDefinition.TabIndex = 6;
            // 
            // _btnReset
            // 
            this._btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnReset.Location = new System.Drawing.Point(72, 531);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(56, 23);
            this._btnReset.TabIndex = 16;
            this._btnReset.Text = "Reset";
            this._btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // _btnRequiringParts
            // 
            this._btnRequiringParts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnRequiringParts.Location = new System.Drawing.Point(136, 531);
            this._btnRequiringParts.Name = "_btnRequiringParts";
            this._btnRequiringParts.Size = new System.Drawing.Size(144, 23);
            this._btnRequiringParts.TabIndex = 17;
            this._btnRequiringParts.Text = "Visits Requiring Parts";
            this._btnRequiringParts.Click += new System.EventHandler(this.btnRequiringParts_Click);
            // 
            // _btnCreateOrder
            // 
            this._btnCreateOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnCreateOrder.Location = new System.Drawing.Point(288, 531);
            this._btnCreateOrder.Name = "_btnCreateOrder";
            this._btnCreateOrder.Size = new System.Drawing.Size(112, 23);
            this._btnCreateOrder.TabIndex = 18;
            this._btnCreateOrder.Text = "Create Order";
            this._btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // FRMVisitManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1454, 561);
            this.Controls.Add(this._btnCreateOrder);
            this.Controls.Add(this._btnRequiringParts);
            this.Controls.Add(this._grpFilter);
            this.Controls.Add(this._btnExport);
            this.Controls.Add(this._grpEngineerVisits);
            this.Controls.Add(this._btnReset);
            this.MinimumSize = new System.Drawing.Size(808, 528);
            this.Name = "FRMVisitManager";
            this.Text = "Visit Manager";
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
            SetupVisitDataGrid();
            // Combo.SetUpCombo(Me.cboDefinition, DynamicDataTables.JobDefinitions, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
            var argc = cboOutcome;
            Combo.SetUpCombo(ref argc, DynamicDataTables.OutcomeStatuses, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
            var argc1 = cboType;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
            // get the region assigned to the user
            if (App.loggedInUser.UserRegions.Count > 0)
            {
                var argc2 = cboRegion;
                Combo.SetUpCombo(ref argc2, App.loggedInUser.UserRegions.Table, "RegionID", "Name", Enums.ComboValues.No_Filter);
            }
            else
            {
                var argc3 = cboRegion;
                Combo.SetUpCombo(ref argc3, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
            }

            var argc4 = cboStatus;
            Combo.SetUpCombo(ref argc4, DynamicDataTables.VisitStatus_For_Viewing, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
            var argc5 = CboServExp;
            Combo.SetUpCombo(ref argc5, DynamicDataTables.ServExpiry, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
            var argc6 = cboLetterNumber;
            Combo.SetUpCombo(ref argc6, DynamicDataTables.LetterType, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
            var argc7 = cboPriority;
            Combo.SetUpCombo(ref argc7, App.DB.Picklists.GetAll(Enums.PickListTypes.JOWPriority).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
            var argc8 = cboVisitCharge;
            Combo.SetUpCombo(ref argc8, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNoNA).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc9 = cboQualification;
            Combo.SetUpCombo(ref argc9, App.DB.Picklists.GetAll(Enums.PickListTypes.Engineer_Levels).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            switch (true)
            {
                case object _ when App.IsGasway:
                    {
                        var argc10 = cboDepartment;
                        Combo.SetUpCombo(ref argc10, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }

                default:
                    {
                        var argc11 = cboDepartment;
                        Combo.SetUpCombo(ref argc11, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }
            }

            switch (true)
            {
                case object _ when App.IsRFT:
                    {
                        lblQualification.Text = "Trade";
                        break;
                    }

                default:
                    {
                        lblQualification.Text = "Qualification";
                        lblQualification.Visible = false;
                        cboQualification.Visible = false;
                        break;
                    }
            }

            if (App.loggedInUser.Admin == false)
            {
                btnExport.Enabled = false;
            }

            if (get_GetParameter(1) is object & get_GetParameter(2) is object)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(get_GetParameter(2), "From Invoice Manager", false)))
                {
                    dtVisitFilters = (DataTable)get_GetParameter(1);
                    LoadLastFilters();
                }
                else
                {
                    PopulateDatagrid(false);
                }
            }
            else
            {
                // PopulateDatagrid(False)
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

        private int count = 0;
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
                if (VisitsDataview is object)
                {
                    _dvVisits.AllowNew = false;
                    _dvVisits.AllowEdit = false;
                    _dvVisits.AllowDelete = false;
                    _dvVisits.Table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
                }

                dgVisits.DataSource = VisitsDataview;
                if (VisitsDataview is object)
                {
                    if (VisitsDataview.Table.Rows.Count > 0)
                    {
                        dgVisits.Select(0);
                    }
                }
            }
        }

        private DataRow SelectedVisitDataRow
        {
            get
            {
                if (VisitsDataview is null)
                {
                    return null;
                }

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

        private Entity.Engineers.Engineer _theEngineer;

        public Entity.Engineers.Engineer theEngineer
        {
            get
            {
                return _theEngineer;
            }

            set
            {
                _theEngineer = value;
                if (_theEngineer is object)
                {
                    txtEngineer.Text = theEngineer.Name;
                }
                else
                {
                    txtEngineer.Text = "";
                }
            }
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

        private void SetupVisitDataGrid()
        {
            var tbStyle = dgVisits.TableStyles[0];
            var visitCharge = new DataGridVisitManagerColumn();
            visitCharge.Format = "";
            visitCharge.FormatInfo = null;
            visitCharge.HeaderText = "";
            visitCharge.MappingName = "VisitChargeable";
            visitCharge.ReadOnly = true;
            visitCharge.Width = 30;
            visitCharge.NullText = "";
            visitCharge.TextBox.Text = "";
            tbStyle.GridColumnStyles.Add(visitCharge);
            var Customer = new DataGridLabelColumn();
            Customer.Format = "";
            Customer.FormatInfo = null;
            Customer.HeaderText = "Customer";
            Customer.MappingName = "Customer";
            Customer.ReadOnly = true;
            Customer.Width = 120;
            Customer.NullText = "";
            tbStyle.GridColumnStyles.Add(Customer);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Property";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 200;
            Site.NullText = "";
            tbStyle.GridColumnStyles.Add(Site);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job Number";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 65;
            JobNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(JobNumber);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 75;
            Type.NullText = Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
            tbStyle.GridColumnStyles.Add(Type);
            var PartsToFit = new BitToStringDescriptionColumn();
            PartsToFit.Format = "";
            PartsToFit.FormatInfo = null;
            PartsToFit.HeaderText = "Parts To Fit";
            PartsToFit.MappingName = "PartsToFit";
            PartsToFit.ReadOnly = true;
            PartsToFit.Width = 25;
            PartsToFit.NullText = "";
            tbStyle.GridColumnStyles.Add(PartsToFit);
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
            var StartDateTime = new DataGridLabelColumn();
            StartDateTime.Format = "dd/MMM/yyyy";
            StartDateTime.FormatInfo = null;
            StartDateTime.HeaderText = "Visit Date";
            StartDateTime.MappingName = "VisitDate";
            StartDateTime.ReadOnly = true;
            StartDateTime.Width = 170;
            StartDateTime.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(StartDateTime);
            switch (true)
            {
                case object _ when App.IsRFT:
                    {
                        var trade = new DataGridLabelColumn();
                        trade.Format = "";
                        trade.FormatInfo = null;
                        trade.HeaderText = "Trade";
                        trade.MappingName = "Qualification";
                        trade.ReadOnly = true;
                        trade.Width = 85;
                        trade.NullText = "";
                        tbStyle.GridColumnStyles.Add(trade);
                        break;
                    }
            }

            var NotesTo = new DataGridLabelColumn();
            NotesTo.Format = "";
            NotesTo.FormatInfo = null;
            NotesTo.HeaderText = "Notes to Engineer";
            NotesTo.MappingName = "NotesToEngineer";
            NotesTo.ReadOnly = true;
            NotesTo.Width = 250;
            NotesTo.NullText = "N/A";
            tbStyle.GridColumnStyles.Add(NotesTo);
            var Engineer = new DataGridLabelColumn();
            Engineer.Format = "";
            Engineer.FormatInfo = null;
            Engineer.HeaderText = "Engineer";
            Engineer.MappingName = "Engineer";
            Engineer.ReadOnly = true;
            Engineer.Width = 90;
            Engineer.NullText = "";
            tbStyle.GridColumnStyles.Add(Engineer);
            var InvoiceNotes = new DataGridLabelColumn();
            InvoiceNotes.Format = "";
            InvoiceNotes.FormatInfo = null;
            InvoiceNotes.HeaderText = "Invoice Notes";
            InvoiceNotes.MappingName = "InvoiceNotes";
            InvoiceNotes.ReadOnly = true;
            InvoiceNotes.Width = 200;
            InvoiceNotes.NullText = "";
            tbStyle.GridColumnStyles.Add(InvoiceNotes);
            var ServiceExpiryDate = new DataGridLabelColumn();
            ServiceExpiryDate.Format = "dd/MMM/yyyy";
            ServiceExpiryDate.FormatInfo = null;
            ServiceExpiryDate.HeaderText = "Service Expiry Date";
            ServiceExpiryDate.MappingName = "ServiceExpiryDate";
            ServiceExpiryDate.ReadOnly = true;
            ServiceExpiryDate.Width = 80;
            ServiceExpiryDate.NullText = "";
            tbStyle.GridColumnStyles.Add(ServiceExpiryDate);
            var SiteFuel = new DataGridLabelColumn();
            SiteFuel.Format = "";
            SiteFuel.FormatInfo = null;
            SiteFuel.HeaderText = "Site Fuel";
            SiteFuel.MappingName = "SiteFuel";
            SiteFuel.ReadOnly = true;
            SiteFuel.Width = 75;
            SiteFuel.NullText = "";
            tbStyle.GridColumnStyles.Add(SiteFuel);
            var PONumber = new DataGridLabelColumn();
            PONumber.Format = "";
            PONumber.FormatInfo = null;
            PONumber.HeaderText = "PO Number";
            PONumber.MappingName = "PONumber";
            PONumber.ReadOnly = true;
            PONumber.Width = 55;
            PONumber.NullText = "";
            tbStyle.GridColumnStyles.Add(PONumber);
            var estimatedService = new DataGridLabelColumn();
            estimatedService.Format = "dd/MMM/yyyy";
            estimatedService.FormatInfo = null;
            estimatedService.HeaderText = "Estimated Service Date";
            estimatedService.MappingName = "EstimatedVisitDate";
            estimatedService.ReadOnly = true;
            estimatedService.Width = 80;
            estimatedService.NullText = "";
            tbStyle.GridColumnStyles.Add(estimatedService);
            var Priority = new DataGridLabelColumn();
            Priority.Format = "";
            Priority.FormatInfo = null;
            Priority.HeaderText = "Priority";
            Priority.MappingName = "Priority";
            Priority.ReadOnly = true;
            Priority.Width = 65;
            Priority.NullText = "";
            tbStyle.GridColumnStyles.Add(Priority);
            var LetterNumber = new DataGridLabelColumn();
            LetterNumber.Format = "";
            LetterNumber.FormatInfo = null;
            LetterNumber.HeaderText = "Let Num";
            LetterNumber.MappingName = "VisitNumber";
            LetterNumber.ReadOnly = true;
            LetterNumber.Width = 55;
            LetterNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(LetterNumber);
            var jobCreatedTime = new DataGridLabelColumn();
            jobCreatedTime.Format = "dd/MMM/yyyy";
            jobCreatedTime.FormatInfo = null;
            jobCreatedTime.HeaderText = "Job Created";
            jobCreatedTime.MappingName = "JobCreatedDateTime";
            jobCreatedTime.ReadOnly = true;
            jobCreatedTime.Width = 120;
            jobCreatedTime.NullText = "";
            tbStyle.GridColumnStyles.Add(jobCreatedTime);
            var visitCreatedTime = new DataGridLabelColumn();
            visitCreatedTime.Format = "dd/MMM/yyyy";
            visitCreatedTime.FormatInfo = null;
            visitCreatedTime.HeaderText = "Visit Created";
            visitCreatedTime.MappingName = "VisitCreatedDateTime";
            visitCreatedTime.ReadOnly = true;
            visitCreatedTime.Width = 120;
            visitCreatedTime.NullText = "";
            tbStyle.GridColumnStyles.Add(visitCreatedTime);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Enums.TableNames.tblEngineerVisit.ToString();
            dgVisits.TableStyles.Add(tbStyle);
        }

        private void FRMVisitManager_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblCustomer));
            if (!(ID == 0))
            {
                theCustomer = App.DB.Customer.Customer_Get(ID);
                // RunFilter()
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
                // RunFilter()
            }
        }

        private void btnfindEngineer_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblEngineer));
            if (!(ID == 0))
            {
                theEngineer = App.DB.Engineer.Engineer_Get(ID);
                // RunFilter()
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
            // RunFilter()
        }

        private void chkVisitEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVisitEnd.Checked)
            {
                dtpVisitEndFrom.Enabled = true;
                dtpVisitEndTo.Enabled = true;
            }
            else
            {
                dtpVisitEndFrom.Value = DateAndTime.Today;
                dtpVisitEndTo.Value = DateAndTime.Today;
                dtpVisitEndFrom.Enabled = false;
                dtpVisitEndTo.Enabled = false;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void btnRequiringParts_Click(object sender, EventArgs e)
        {
            ResetFilters();
            var argcombo = cboStatus;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToInteger(Enums.VisitStatus.Waiting_For_Parts).ToString());
            // RunFilter()
            PopulateDatagrid(true);
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (SelectedVisitDataRow is null)
            {
                App.ShowMessage("Please select a visit to create an order for", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(SelectedVisitDataRow["StatusEnumID"], Conversions.ToInteger(Enums.VisitStatus.Ready_For_Schedule), false) & !Operators.ConditionalCompareObjectEqual(SelectedVisitDataRow["StatusEnumID"], Conversions.ToInteger(Enums.VisitStatus.Waiting_For_Parts), false)))
            {
                App.ShowMessage("Only Visits that are waiting for parts or are ready for schedule are allowed to create orders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FRMOrder fOrders = (FRMOrder)App.ShowForm(typeof(FRMOrder), false, new object[] { 0, SelectedVisitDataRow["EngineerVisitID"], Conversions.ToInteger(Enums.OrderType.Job) });
        }

        private void dgVisits_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedVisitDataRow is null)
            {
                App.ShowMessage("Please select a visit to view", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool @continue = false;
            var switchExpr = Conversions.ToInteger(SelectedVisitDataRow["StatusEnumID"]);
            switch (switchExpr)
            {
                case (int)(Enums.VisitStatus.NOT_SET):
                    {
                        if (App.ShowMessage("This visit has not entered a visit life span yet.  View related job details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            App.ShowForm(typeof(FRMLogCallout), true, new object[] { SelectedVisitDataRow["JobID"], SelectedVisitDataRow["SiteID"], this, null, SelectedVisitDataRow["EngineerVisitID"] });
                        }

                        break;
                    }

                case (int)(Enums.VisitStatus.Parts_Need_Ordering):
                    {
                        if (App.ShowMessage("Parts Need Ordering for this visit, once ordered and recieved you may proceed.  View related job details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            App.ShowForm(typeof(FRMLogCallout), true, new object[] { SelectedVisitDataRow["JobID"], SelectedVisitDataRow["SiteID"], this, null, SelectedVisitDataRow["EngineerVisitID"] });
                        }

                        break;
                    }

                case (int)(Enums.VisitStatus.Waiting_For_Parts):
                    {
                        if (App.ShowMessage("This visit is waiting for parts, once recieved you may proceed.  View related job details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            App.ShowForm(typeof(FRMLogCallout), true, new object[] { SelectedVisitDataRow["JobID"], SelectedVisitDataRow["SiteID"], this, null, SelectedVisitDataRow["EngineerVisitID"] });
                        }

                        break;
                    }

                case (int)(Enums.VisitStatus.Ready_For_Schedule):
                    {
                        if (App.ShowMessage("This visit is ready for schedule, would you like to manually complete the visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            @continue = true;
                        }

                        break;
                    }

                case (int)(Enums.VisitStatus.Scheduled):
                    {
                        if (App.ShowMessage("This visit is scheduled, would you like to manually complete the visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            @continue = true;
                        }

                        break;
                    }

                case (int)(Enums.VisitStatus.Downloaded):
                    {
                        if (App.ShowMessage("This visit is currently with an engineer, once returned you may view the details.  View related job details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            App.ShowForm(typeof(FRMLogCallout), true, new object[] { SelectedVisitDataRow["JobID"], SelectedVisitDataRow["SiteID"], this, null, SelectedVisitDataRow["EngineerVisitID"] });
                        }

                        break;
                    }

                case (int)(Enums.VisitStatus.Uploaded):
                    {
                        @continue = true;
                        break;
                    }

                case (int)Enums.VisitStatus.Not_To_Be_Invoiced:
                    {
                        @continue = true;
                        break;
                    }

                case (int)Enums.VisitStatus.Ready_To_Be_Invoiced:
                    {
                        @continue = true;
                        break;
                    }

                case (int)Enums.VisitStatus.Invoiced:
                    {
                        @continue = true;
                        break;
                    }
            }

            if (@continue)
            {
                App.ShowForm(typeof(FRMEngineerVisit), true, new object[] { SelectedVisitDataRow["EngineerVisitID"], dtVisitFilters });
                updaterow();
                // PopulateDatagrid(True)
                // LoadLastFilters()
            }
        }

        public void updaterow()
        {
            var visit = App.DB.EngineerVisits.EngineerVisit_GetUpdate(Conversions.ToInteger(SelectedVisitDataRow["EngineerVisitID"]));
            VisitsDataview.AllowDelete = true;
            SelectedVisitDataRow["VisitStatus"] = visit.Table.Rows[0]["VisitStatus"];
            SelectedVisitDataRow["StatusEnumID"] = visit.Table.Rows[0]["StatusEnumID"];
            SelectedVisitDataRow["InvoiceNotes"] = visit.Table.Rows[0]["NotesFromEngineer"];

            // If Not Combo.GetSelectedItemValue(Me.cboStatus) = 0 AndAlso Combo.GetSelectedItemValue(Me.cboStatus) <> SelectedVisitDataRow("StatusEnumID") Then
            // VisitsDataview.Delete(Me.dgVisits.CurrentRowIndex)
            // End If
        }

        private void txtPostcode_TextChanged(object sender, EventArgs e)
        {
            // RunFilter()
        }

        private void cboOutcome_SelectedIndexChanged(object sender, EventArgs e)
        {
            // RunFilter()
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateDatagrid(true);
        }

        public void PopulateDatagrid(bool withRun)
        {
            try
            {
                if (get_GetParameter(0) is null)
                {
                    if (withRun)
                    {
                        string whereClause = "(1 = 1 ";
                        string addwhereClause = "(1 = 1 ";
                        if (theCustomer is object)
                        {
                            whereClause += " AND tblCustomer.CustomerID = " + theCustomer.CustomerID + "";
                        }

                        if (theSite is object)
                        {
                            whereClause += " AND tblSite.SiteID = " + theSite.SiteID + "";
                        }

                        if (theEngineer is object)
                        {
                            whereClause += " AND tblEngineer.EngineerID = " + theEngineer.EngineerID + "";
                        }
                        // If Not Combo.GetSelectedItemValue(Me.cboDefinition) = 0 Then
                        // whereClause += " AND tblJob.JobDefinitionEnumID = " & Combo.GetSelectedItemValue(Me.cboDefinition) & ""
                        // End If
                        if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboType)) == 0))
                        {
                            whereClause += " AND tblJob.JobTypeID = " + Combo.get_GetSelectedItemValue(cboType) + "";
                        }

                        if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboStatus)) == 0))
                        {
                            whereClause += " AND @THEStatusEnumIDString = " + Combo.get_GetSelectedItemValue(cboStatus) + "";
                        }

                        if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboOutcome)) == 0))
                        {
                            whereClause += " AND tblEngineerVisit.OutcomeEnumID = " + Combo.get_GetSelectedItemValue(cboOutcome) + "";
                        }

                        if (App.loggedInUser.UserRegions.Count > 0)
                        {
                            if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboRegion)) == 0))
                            {
                                whereClause += " AND tblsite.RegionID = " + Combo.get_GetSelectedItemValue(cboRegion) + "";
                            }
                            else
                            {
                                string regionString = string.Join(",", App.loggedInUser.UserRegions.Table.AsEnumerable().Select(x => x.Field<int>("RegionID").ToString()).ToArray());
                                whereClause += " AND tblsite.RegionID in (" + regionString + ")";
                            }
                        }
                        else if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboRegion)) == 0))
                        {
                            whereClause += " AND tblsite.RegionID = " + Combo.get_GetSelectedItemValue(cboRegion) + "";
                        }

                        if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(CboServExp)) == 0))
                        {
                            whereClause += " AND DATEADD(year,1,tblsite.lastservicedate) < '" + Strings.Format(DateAndTime.Today.AddDays(Conversions.ToDouble(Combo.get_GetSelectedItemValue(CboServExp))), "yyyy-MM-dd") + "'";
                        }

                        string department = Helper.MakeStringValid(Combo.get_GetSelectedItemValue(cboDepartment));
                        if (Helper.IsValidInteger(department) && !(Helper.MakeIntegerValid(department) <= 0))
                        {
                            whereClause += " AND tblEngineer.Department = '" + department + "'";
                        }
                        else if (!Information.IsNumeric(department))
                        {
                            whereClause += " AND tblEngineer.Department = '" + department + "'";
                        }

                        if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboLetterNumber)) == 0))
                        {
                            whereClause += " AND tblEngineerVisit.VisitNumber = " + Combo.get_GetSelectedItemValue(cboLetterNumber);
                        }

                        if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPriority)) == 0))
                        {
                            whereClause += " AND pris.managerid = " + Combo.get_GetSelectedItemValue(cboPriority);
                        }

                        if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboVisitCharge)) == 0))
                        {
                            addwhereClause += " AND VisitChargeable = " + Combo.get_GetSelectedItemValue(cboVisitCharge);
                        }

                        if (!(txtJobNumber.Text.Trim().Length == 0))
                        {
                            whereClause += " AND tblJob.JobNumber LIKE '" + txtJobNumber.Text.Trim() + "%'";
                        }

                        if (!(txtPONumber.Text.Trim().Length == 0))
                        {
                            whereClause += " AND tblJobOfWork.PONumber LIKE '" + txtPONumber.Text.Trim() + "%'";
                        }

                        if (chkVisitDate.Checked)
                        {
                            whereClause += " AND tblEngineerVisit.StartDateTime >= '" + Strings.Format(dtpFrom.Value, "dd-MMM-yyyy 00:00:00") + "' AND tblEngineerVisit.StartDateTime <= '" + Strings.Format(dtpTo.Value, "dd-MMM-yyyy 23:59:59") + "'";
                        }

                        if (chkVisitEnd.Checked)
                        {
                            whereClause += " AND tblEngineerVisit.EndDateTime >= '" + Strings.Format(dtpVisitEndFrom.Value, "dd-MMM-yyyy 00:00:00") + "' AND tblEngineerVisit.EndDateTime <= '" + Strings.Format(dtpVisitEndTo.Value, "dd-MMM-yyyy 23:59:59") + "'";
                        }

                        if (chkServiceDate.Checked)
                        {
                            whereClause += " AND tblContractOriginalPPMVisit.EstimatedVisitDate >= '" + Strings.Format(dtpFromServiceDate.Value, "dd-MMM-yyyy 00:00:00") + "' AND tblContractOriginalPPMVisit.EstimatedVisitDate <= '" + Strings.Format(dtpToServiceDate.Value, "dd-MMM-yyyy 23:59:59") + "'";
                        }

                        if (chkftfcode.Checked)
                        {
                            whereClause += " AND tblEngineerVisitQC.FTFCode IS NULL ";
                        }

                        if (chkRecharge.Checked)
                        {
                            whereClause += " AND tblEngineerVisit.Recharge = 1 ";
                        }

                        if (!(txtPostcode.Text.Trim().Length == 0))
                        {
                            whereClause += " AND tblSite.Postcode LIKE '" + txtPostcode.Text.Trim() + "%'";
                        }

                        if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboQualification)) == 0))
                        {
                            whereClause += " AND tblJobOfWork.QualificationID = " + Combo.get_GetSelectedItemValue(cboQualification);
                        }

                        whereClause += ")";
                        addwhereClause += ")";
                        VisitsDataview = App.DB.EngineerVisits.EngineerVisits_Manager_Get_ByWhere(whereClause, addwhereClause);
                        count = VisitsDataview.Count;
                        grpEngineerVisits.Text = "Double Click To View / Edit (" + Conversions.ToString(count) + ")";
                    }
                    else
                    {
                        VisitsDataview = null;
                    }
                }
                // VisitsDataview = DB.EngineerVisits.EngineerVisits_Get_All()
                // RunFilter()
                else
                {
                    VisitsDataview = (DataView)get_GetParameter(0);
                    grpFilter.Enabled = false;
                }

                LogSearchCriteria();
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFilters()
        {
            theCustomer = null;
            theEngineer = null;
            var argcombo = cboDefinition;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            var argcombo1 = cboType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, 0.ToString());
            var argcombo2 = cboStatus;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, 0.ToString());
            var argcombo3 = cboOutcome;
            Combo.SetSelectedComboItem_By_Value(ref argcombo3, 0.ToString());
            txtJobNumber.Text = "";
            txtPONumber.Text = "";
            txtPostcode.Text = "";
            chkVisitDate.Checked = false;
            dtpFrom.Value = DateAndTime.Today;
            dtpTo.Value = DateAndTime.Today;
            dtpFrom.Enabled = false;
            dtpTo.Enabled = false;
            grpFilter.Enabled = true;
        }

        public void Export()
        {
            if (VisitsDataview is object && VisitsDataview.Table.Rows.Count > 0)
            {
                var exportData = new DataTable();
                exportData.Columns.Add("Customer");
                exportData.Columns.Add("Site");
                exportData.Columns.Add("JobNumber");
                exportData.Columns.Add("PONumber");
                exportData.Columns.Add("VisitOutcome");
                exportData.Columns.Add("Type");
                exportData.Columns.Add("VisitStatus");
                exportData.Columns.Add("Engineer");
                exportData.Columns.Add("PolicyNumber");
                exportData.Columns.Add("Priority");
                exportData.Columns.Add("Department");
                exportData.Columns.Add("VisitNumber");
                exportData.Columns.Add("SiteContact");
                exportData.Columns.Add("FirstLine");
                exportData.Columns.Add("Area");
                exportData.Columns.Add("PostCode");
                exportData.Columns.Add("TelephoneNum");
                exportData.Columns.Add("MobileNum");
                exportData.Columns.Add("EmailAddress");
                exportData.Columns.Add("ServiceExpiryDate", typeof(DateTime));
                exportData.Columns.Add("SiteFuel");
                exportData.Columns.Add("StartDateTime", typeof(DateTime));
                exportData.Columns.Add("NotesToEngineer");
                exportData.Columns.Add("NotesFromEngineer");
                exportData.Columns.Add("InvoiceNotes");
                exportData.Columns.Add("JobCreatedDateTime", typeof(DateTime));
                exportData.Columns.Add("VisitCreatedDateTime", typeof(DateTime));
                foreach (DataRow dr in VisitsDataview.Table.Rows)
                {
                    DataRow newRw;
                    newRw = exportData.NewRow();
                    newRw["Customer"] = dr["Customer"];
                    newRw["Site"] = dr["Site"];
                    newRw["JobNumber"] = dr["JobNumber"];
                    newRw["PONumber"] = dr["PONumber"];
                    newRw["VisitOutcome"] = dr["VisitOutcome"];
                    newRw["Type"] = dr["Type"];
                    newRw["VisitStatus"] = dr["VisitStatus"];
                    newRw["Engineer"] = dr["Engineer"];
                    newRw["PolicyNumber"] = dr["PolicyNumber"];
                    newRw["Priority"] = dr["Priority"];
                    newRw["Department"] = dr["Department"];
                    newRw["VisitNumber"] = dr["VisitNumber"];
                    newRw["SiteContact"] = dr["SiteContact"];
                    newRw["FirstLine"] = dr["FirstLine"];
                    newRw["Area"] = dr["Area"];
                    newRw["PostCode"] = dr["PostCode"];
                    newRw["TelephoneNum"] = dr["TelephoneNum"];
                    newRw["MobileNum"] = dr["MobileNum"];
                    newRw["EmailAddress"] = dr["EmailAddress"];
                    newRw["ServiceExpiryDate"] = dr["ServiceExpiryDate"];
                    newRw["SiteFuel"] = dr["SiteFuel"];
                    newRw["StartDateTime"] = dr["StartDateTime"];
                    newRw["NotesToEngineer"] = dr["NotesToEngineer"];
                    newRw["NotesFromEngineer"] = dr["OutcomeDetails"];
                    newRw["InvoiceNotes"] = dr["InvoiceNotes"];
                    newRw["JobCreatedDateTime"] = dr["JobCreatedDateTime"];
                    newRw["VisitCreatedDateTime"] = dr["VisitCreatedDateTime"];
                    exportData.Rows.Add(newRw);
                }

                ExportHelper.Export(exportData, "VisitManager", Enums.ExportType.XLS);
            }
            else
            {
                App.ShowMessage("No data to export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void cboOutcome_TextChanged(object sender, EventArgs e)
        {
            if ((cboOutcome.Text.ToString() ?? "") == "Further Works")
            {
                chkftfcode.Visible = true;
            }
            else
            {
                chkftfcode.CheckState = CheckState.Unchecked;
                chkftfcode.Visible = true;
            }
        }

        private void cboOutcome_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if ((cboOutcome.Text.ToString() ?? "") == "Further Works")
            {
                chkftfcode.Visible = true;
            }
            else
            {
                chkftfcode.CheckState = CheckState.Unchecked;
                chkftfcode.Visible = false;
            }
        }

        private void LogSearchCriteria()
        {
            dtVisitFilters.Rows.Clear();
            var dt = dtVisitFilters;
            DataRow dr;
            dr = dt.NewRow();
            dr["Field"] = "theCustomer";
            if (theCustomer is null)
            {
                dr["Value"] = 0;
            }
            else
            {
                dr["Value"] = theCustomer.CustomerID;
            }

            dr["Type"] = "Object";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Field"] = "theSite";
            if (theSite is null)
            {
                dr["Value"] = 0;
            }
            else
            {
                dr["Value"] = theSite.SiteID;
            }

            dr["Type"] = "Object";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Field"] = "theEngineer";
            if (theEngineer is null)
            {
                dr["Value"] = 0;
            }
            else
            {
                dr["Value"] = theEngineer.EngineerID;
            }

            dr["Type"] = "Object";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Field"] = "cboType";
            dr["Value"] = Combo.get_GetSelectedItemValue(cboType);
            dr["Type"] = "Combo";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Field"] = "cboStatus";
            dr["Value"] = Combo.get_GetSelectedItemValue(cboStatus);
            dr["Type"] = "Combo";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Field"] = "cboOutcome";
            dr["Value"] = Combo.get_GetSelectedItemValue(cboOutcome);
            dr["Type"] = "Combo";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Field"] = "txtJobNumber";
            dr["Value"] = txtJobNumber.Text;
            dr["Type"] = "Text";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Field"] = "txtPONumber";
            dr["Value"] = txtPONumber.Text;
            dr["Type"] = "Text";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Field"] = "txtPostcode";
            dr["Value"] = txtPostcode.Text;
            dr["Type"] = "Text";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Field"] = "chkVisitDate";
            dr["Value"] = chkVisitDate.Checked;
            dr["Type"] = "CHECK";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Field"] = "dtpFrom";
            dr["Value"] = dtpFrom.Value;
            dr["Type"] = "DTP";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Field"] = "dtpTo";
            dr["Value"] = dtpTo.Value;
            dr["Type"] = "DTP";
            dt.Rows.Add(dr);
        }

        private void LoadLastFilters()
        {
            if (Controls.Count > 0)
            {
                if (dtVisitFilters.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtVisitFilters.Rows)
                    {
                        var switchExpr = dr["Type"].ToString();
                        switch (switchExpr)
                        {
                            case "Object":
                                {
                                    var switchExpr1 = dr["Field"].ToString();
                                    switch (switchExpr1)
                                    {
                                        case "theCustomer":
                                            {
                                                var cust = App.DB.Customer.Customer_Get(Conversions.ToInteger(dr["Value"]));
                                                if (cust is object)
                                                {
                                                    theCustomer = cust;
                                                }

                                                break;
                                            }

                                        case "theSite":
                                            {
                                                var s = App.DB.Sites.Get(dr["Value"]);
                                                if (s is object)
                                                {
                                                    theSite = s;
                                                }

                                                break;
                                            }

                                        case "theEngineer":
                                            {
                                                var eng = App.DB.Engineer.Engineer_Get(Conversions.ToInteger(dr["Value"]));
                                                if (eng is object)
                                                {
                                                    theEngineer = eng;
                                                }

                                                break;
                                            }
                                    }

                                    break;
                                }

                            case "Combo":
                                {
                                    ComboBox argcombo = (ComboBox)Controls.Find(Conversions.ToString(dr["Field"]), true)[0];
                                    Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(dr["Value"]));
                                    break;
                                }

                            case "Text":
                                {
                                    ((TextBox)Controls.Find(Conversions.ToString(dr["Field"]), true)[0]).Text = Conversions.ToString(dr["Value"]);
                                    break;
                                }

                            case "Radio":
                                {
                                    ((RadioButton)Controls.Find(Conversions.ToString(dr["Field"]), true)[0]).Checked = Conversions.ToBoolean(dr["Value"]);
                                    break;
                                }

                            case "DTP":
                                {
                                    ((DateTimePicker)Controls.Find(Conversions.ToString(dr["Field"]), true)[0]).Value = Conversions.ToDate(dr["Value"]);
                                    break;
                                }

                            case "CHECK":
                                {
                                    ((CheckBox)Controls.Find(Conversions.ToString(dr["Field"]), true)[0]).Checked = Conversions.ToBoolean(dr["Value"]);
                                    break;
                                }
                        }
                    }

                    PopulateDatagrid(true);
                }
            }
        }

        private void txtJobNumber_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PopulateDatagrid(true);
            }
        }
    }
}