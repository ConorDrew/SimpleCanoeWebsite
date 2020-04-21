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
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMVisitManager() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        private Label _Label7;

        internal Label Label7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label7 != null)
                {
                }

                _Label7 = value;
                if (_Label7 != null)
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

        internal Button btnRequiringParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRequiringParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRequiringParts != null)
                {
                    _btnRequiringParts.Click -= btnRequiringParts_Click;
                }

                _btnRequiringParts = value;
                if (_btnRequiringParts != null)
                {
                    _btnRequiringParts.Click += btnRequiringParts_Click;
                }
            }
        }

        private Button _btnCreateOrder;

        internal Button btnCreateOrder
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCreateOrder;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCreateOrder != null)
                {
                    _btnCreateOrder.Click -= btnCreateOrder_Click;
                }

                _btnCreateOrder = value;
                if (_btnCreateOrder != null)
                {
                    _btnCreateOrder.Click += btnCreateOrder_Click;
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

        internal Button btnfindEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnfindEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnfindEngineer != null)
                {
                    _btnfindEngineer.Click -= btnfindEngineer_Click;
                }

                _btnfindEngineer = value;
                if (_btnfindEngineer != null)
                {
                    _btnfindEngineer.Click += btnfindEngineer_Click;
                }
            }
        }

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

        internal Label Label12
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label12;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label12 != null)
                {
                }

                _Label12 = value;
                if (_Label12 != null)
                {
                }
            }
        }

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
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
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

        internal Label Label18
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label18;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label18 != null)
                {
                }

                _Label18 = value;
                if (_Label18 != null)
                {
                }
            }
        }

        private Label _Label19;

        internal Label Label19
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label19;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label19 != null)
                {
                }

                _Label19 = value;
                if (_Label19 != null)
                {
                }
            }
        }

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

        internal Label lblVisitEndTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblVisitEndTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblVisitEndTo != null)
                {
                }

                _lblVisitEndTo = value;
                if (_lblVisitEndTo != null)
                {
                }
            }
        }

        private Label _lblVisitEndFrom;

        internal Label lblVisitEndFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblVisitEndFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblVisitEndFrom != null)
                {
                }

                _lblVisitEndFrom = value;
                if (_lblVisitEndFrom != null)
                {
                }
            }
        }

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

        internal Label lblVisitCharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblVisitCharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblVisitCharge != null)
                {
                }

                _lblVisitCharge = value;
                if (_lblVisitCharge != null)
                {
                }
            }
        }

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

        internal Label lblNonChargeable
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNonChargeable;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblNonChargeable != null)
                {
                }

                _lblNonChargeable = value;
                if (_lblNonChargeable != null)
                {
                }
            }
        }

        private Label _lblGreenColour;

        internal Label lblGreenColour
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblGreenColour;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblGreenColour != null)
                {
                }

                _lblGreenColour = value;
                if (_lblGreenColour != null)
                {
                }
            }
        }

        private Label _lblVisitChargeable;

        internal Label lblVisitChargeable
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblVisitChargeable;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblVisitChargeable != null)
                {
                }

                _lblVisitChargeable = value;
                if (_lblVisitChargeable != null)
                {
                }
            }
        }

        private Label _lblYellowColour;

        internal Label lblYellowColour
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblYellowColour;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblYellowColour != null)
                {
                }

                _lblYellowColour = value;
                if (_lblYellowColour != null)
                {
                }
            }
        }

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
            _grpEngineerVisits = new GroupBox();
            _dgVisits = new DataGrid();
            _dgVisits.DoubleClick += new EventHandler(dgVisits_DoubleClick);
            _btnExport = new Button();
            _btnExport.Click += new EventHandler(btnExport_Click);
            _grpFilter = new GroupBox();
            _lblQualification = new Label();
            _cboQualification = new ComboBox();
            _lblNonChargeable = new Label();
            _lblGreenColour = new Label();
            _lblVisitChargeable = new Label();
            _lblYellowColour = new Label();
            _lblVisitCharge = new Label();
            _cboVisitCharge = new ComboBox();
            _chkRecharge = new CheckBox();
            _dtpVisitEndTo = new DateTimePicker();
            _dtpVisitEndFrom = new DateTimePicker();
            _lblVisitEndTo = new Label();
            _lblVisitEndFrom = new Label();
            _chkVisitEnd = new CheckBox();
            _chkVisitEnd.CheckedChanged += new EventHandler(chkVisitEnd_CheckedChanged);
            _dtpToServiceDate = new DateTimePicker();
            _dtpFromServiceDate = new DateTimePicker();
            _Label18 = new Label();
            _Label19 = new Label();
            _chkServiceDate = new CheckBox();
            _Label17 = new Label();
            _cboPriority = new ComboBox();
            _Label16 = new Label();
            _cboLetterNumber = new ComboBox();
            _chkftfcode = new CheckBox();
            _Label15 = new Label();
            _cboDepartment = new ComboBox();
            _Label14 = new Label();
            _CboServExp = new ComboBox();
            _Label13 = new Label();
            _cboRegion = new ComboBox();
            _btnSearch = new Button();
            _btnSearch.Click += new EventHandler(btnSearch_Click);
            _Label12 = new Label();
            _cboOutcome = new ComboBox();
            _cboOutcome.TextChanged += new EventHandler(cboOutcome_TextChanged);
            _cboOutcome.SelectedIndexChanged += new EventHandler(cboOutcome_SelectedIndexChanged_1);
            _btnfindEngineer = new Button();
            _btnfindEngineer.Click += new EventHandler(btnfindEngineer_Click);
            _txtEngineer = new TextBox();
            _Label5 = new Label();
            _btnFindCustomer = new Button();
            _btnFindCustomer.Click += new EventHandler(btnFindCustomer_Click);
            _txtCustomer = new TextBox();
            _Label4 = new Label();
            _txtPostcode = new TextBox();
            _txtPostcode.TextChanged += new EventHandler(txtPostcode_TextChanged);
            _txtPostcode.KeyDown += new KeyEventHandler(txtJobNumber_TextChanged);
            _Label1 = new Label();
            _btnFindSite = new Button();
            _btnFindSite.Click += new EventHandler(btnFindSite_Click);
            _txtSite = new TextBox();
            _dtpTo = new DateTimePicker();
            _dtpFrom = new DateTimePicker();
            _txtPONumber = new TextBox();
            _txtPONumber.KeyDown += new KeyEventHandler(txtJobNumber_TextChanged);
            _txtJobNumber = new TextBox();
            _txtJobNumber.KeyDown += new KeyEventHandler(txtJobNumber_TextChanged);
            _Label9 = new Label();
            _Label8 = new Label();
            _chkVisitDate = new CheckBox();
            _chkVisitDate.CheckedChanged += new EventHandler(chkVisitDate_CheckedChanged);
            _Label7 = new Label();
            _Label6 = new Label();
            _Label2 = new Label();
            _Label10 = new Label();
            _cboType = new ComboBox();
            _Label11 = new Label();
            _cboStatus = new ComboBox();
            _Label3 = new Label();
            _cboDefinition = new ComboBox();
            _btnReset = new Button();
            _btnReset.Click += new EventHandler(btnReset_Click);
            _btnRequiringParts = new Button();
            _btnRequiringParts.Click += new EventHandler(btnRequiringParts_Click);
            _btnCreateOrder = new Button();
            _btnCreateOrder.Click += new EventHandler(btnCreateOrder_Click);
            _grpEngineerVisits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgVisits).BeginInit();
            _grpFilter.SuspendLayout();
            SuspendLayout();
            //
            // grpEngineerVisits
            //
            _grpEngineerVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpEngineerVisits.Controls.Add(_dgVisits);
            _grpEngineerVisits.Location = new Point(8, 303);
            _grpEngineerVisits.Name = "grpEngineerVisits";
            _grpEngineerVisits.Size = new Size(1438, 222);
            _grpEngineerVisits.TabIndex = 2;
            _grpEngineerVisits.TabStop = false;
            //
            // dgVisits
            //
            _dgVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgVisits.DataMember = "";
            _dgVisits.HeaderForeColor = SystemColors.ControlText;
            _dgVisits.Location = new Point(8, 20);
            _dgVisits.Name = "dgVisits";
            _dgVisits.Size = new Size(1422, 194);
            _dgVisits.TabIndex = 14;
            //
            // btnExport
            //
            _btnExport.AccessibleDescription = "Export Job List To Excel";
            _btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnExport.Location = new Point(8, 531);
            _btnExport.Name = "btnExport";
            _btnExport.Size = new Size(56, 23);
            _btnExport.TabIndex = 15;
            _btnExport.Text = "Export";
            //
            // grpFilter
            //
            _grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpFilter.Controls.Add(_lblQualification);
            _grpFilter.Controls.Add(_cboQualification);
            _grpFilter.Controls.Add(_lblNonChargeable);
            _grpFilter.Controls.Add(_lblGreenColour);
            _grpFilter.Controls.Add(_lblVisitChargeable);
            _grpFilter.Controls.Add(_lblYellowColour);
            _grpFilter.Controls.Add(_lblVisitCharge);
            _grpFilter.Controls.Add(_cboVisitCharge);
            _grpFilter.Controls.Add(_chkRecharge);
            _grpFilter.Controls.Add(_dtpVisitEndTo);
            _grpFilter.Controls.Add(_dtpVisitEndFrom);
            _grpFilter.Controls.Add(_lblVisitEndTo);
            _grpFilter.Controls.Add(_lblVisitEndFrom);
            _grpFilter.Controls.Add(_chkVisitEnd);
            _grpFilter.Controls.Add(_dtpToServiceDate);
            _grpFilter.Controls.Add(_dtpFromServiceDate);
            _grpFilter.Controls.Add(_Label18);
            _grpFilter.Controls.Add(_Label19);
            _grpFilter.Controls.Add(_chkServiceDate);
            _grpFilter.Controls.Add(_Label17);
            _grpFilter.Controls.Add(_cboPriority);
            _grpFilter.Controls.Add(_Label16);
            _grpFilter.Controls.Add(_cboLetterNumber);
            _grpFilter.Controls.Add(_chkftfcode);
            _grpFilter.Controls.Add(_Label15);
            _grpFilter.Controls.Add(_cboDepartment);
            _grpFilter.Controls.Add(_Label14);
            _grpFilter.Controls.Add(_CboServExp);
            _grpFilter.Controls.Add(_Label13);
            _grpFilter.Controls.Add(_cboRegion);
            _grpFilter.Controls.Add(_btnSearch);
            _grpFilter.Controls.Add(_Label12);
            _grpFilter.Controls.Add(_cboOutcome);
            _grpFilter.Controls.Add(_btnfindEngineer);
            _grpFilter.Controls.Add(_txtEngineer);
            _grpFilter.Controls.Add(_Label5);
            _grpFilter.Controls.Add(_btnFindCustomer);
            _grpFilter.Controls.Add(_txtCustomer);
            _grpFilter.Controls.Add(_Label4);
            _grpFilter.Controls.Add(_txtPostcode);
            _grpFilter.Controls.Add(_Label1);
            _grpFilter.Controls.Add(_btnFindSite);
            _grpFilter.Controls.Add(_txtSite);
            _grpFilter.Controls.Add(_dtpTo);
            _grpFilter.Controls.Add(_dtpFrom);
            _grpFilter.Controls.Add(_txtPONumber);
            _grpFilter.Controls.Add(_txtJobNumber);
            _grpFilter.Controls.Add(_Label9);
            _grpFilter.Controls.Add(_Label8);
            _grpFilter.Controls.Add(_chkVisitDate);
            _grpFilter.Controls.Add(_Label7);
            _grpFilter.Controls.Add(_Label6);
            _grpFilter.Controls.Add(_Label2);
            _grpFilter.Controls.Add(_Label10);
            _grpFilter.Controls.Add(_cboType);
            _grpFilter.Controls.Add(_Label11);
            _grpFilter.Controls.Add(_cboStatus);
            _grpFilter.Location = new Point(8, 32);
            _grpFilter.Name = "grpFilter";
            _grpFilter.Size = new Size(1438, 271);
            _grpFilter.TabIndex = 1;
            _grpFilter.TabStop = false;
            _grpFilter.Text = "Filter";
            //
            // lblQualification
            //
            _lblQualification.BackColor = Color.Transparent;
            _lblQualification.Location = new Point(662, 150);
            _lblQualification.Name = "lblQualification";
            _lblQualification.Size = new Size(90, 16);
            _lblQualification.TabIndex = 63;
            _lblQualification.Text = "Qualification";
            //
            // cboQualification
            //
            _cboQualification.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboQualification.Location = new Point(776, 147);
            _cboQualification.Name = "cboQualification";
            _cboQualification.Size = new Size(266, 21);
            _cboQualification.TabIndex = 62;
            //
            // lblNonChargeable
            //
            _lblNonChargeable.Location = new Point(876, 244);
            _lblNonChargeable.Name = "lblNonChargeable";
            _lblNonChargeable.Size = new Size(139, 16);
            _lblNonChargeable.TabIndex = 61;
            _lblNonChargeable.Text = "Non-Chargeable Visit";
            //
            // lblGreenColour
            //
            _lblGreenColour.BackColor = Color.LightGreen;
            _lblGreenColour.Location = new Point(850, 240);
            _lblGreenColour.Name = "lblGreenColour";
            _lblGreenColour.Size = new Size(20, 20);
            _lblGreenColour.TabIndex = 60;
            //
            // lblVisitChargeable
            //
            _lblVisitChargeable.Location = new Point(738, 244);
            _lblVisitChargeable.Name = "lblVisitChargeable";
            _lblVisitChargeable.Size = new Size(109, 17);
            _lblVisitChargeable.TabIndex = 59;
            _lblVisitChargeable.Text = "Chargeable Visit";
            //
            // lblYellowColour
            //
            _lblYellowColour.BackColor = Color.Yellow;
            _lblYellowColour.Location = new Point(712, 240);
            _lblYellowColour.Name = "lblYellowColour";
            _lblYellowColour.Size = new Size(20, 20);
            _lblYellowColour.TabIndex = 58;
            //
            // lblVisitCharge
            //
            _lblVisitCharge.Location = new Point(662, 117);
            _lblVisitCharge.Name = "lblVisitCharge";
            _lblVisitCharge.Size = new Size(108, 20);
            _lblVisitCharge.TabIndex = 57;
            _lblVisitCharge.Text = "Visit Chargeable?";
            //
            // cboVisitCharge
            //
            _cboVisitCharge.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboVisitCharge.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboVisitCharge.Location = new Point(776, 113);
            _cboVisitCharge.MinimumSize = new Size(70, 0);
            _cboVisitCharge.Name = "cboVisitCharge";
            _cboVisitCharge.Size = new Size(297, 21);
            _cboVisitCharge.TabIndex = 56;
            //
            // chkRecharge
            //
            _chkRecharge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _chkRecharge.Cursor = Cursors.Hand;
            _chkRecharge.Location = new Point(1106, 209);
            _chkRecharge.Name = "chkRecharge";
            _chkRecharge.Size = new Size(95, 24);
            _chkRecharge.TabIndex = 55;
            _chkRecharge.Text = "Recharge";
            _chkRecharge.UseVisualStyleBackColor = true;
            //
            // dtpVisitEndTo
            //
            _dtpVisitEndTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _dtpVisitEndTo.Enabled = false;
            _dtpVisitEndTo.Location = new Point(1274, 118);
            _dtpVisitEndTo.Name = "dtpVisitEndTo";
            _dtpVisitEndTo.Size = new Size(156, 21);
            _dtpVisitEndTo.TabIndex = 54;
            //
            // dtpVisitEndFrom
            //
            _dtpVisitEndFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _dtpVisitEndFrom.Enabled = false;
            _dtpVisitEndFrom.Location = new Point(1274, 91);
            _dtpVisitEndFrom.Name = "dtpVisitEndFrom";
            _dtpVisitEndFrom.Size = new Size(156, 21);
            _dtpVisitEndFrom.TabIndex = 53;
            //
            // lblVisitEndTo
            //
            _lblVisitEndTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblVisitEndTo.Location = new Point(1220, 121);
            _lblVisitEndTo.Name = "lblVisitEndTo";
            _lblVisitEndTo.Size = new Size(48, 16);
            _lblVisitEndTo.TabIndex = 51;
            _lblVisitEndTo.Text = "To";
            //
            // lblVisitEndFrom
            //
            _lblVisitEndFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblVisitEndFrom.Location = new Point(1220, 93);
            _lblVisitEndFrom.Name = "lblVisitEndFrom";
            _lblVisitEndFrom.Size = new Size(48, 16);
            _lblVisitEndFrom.TabIndex = 50;
            _lblVisitEndFrom.Text = "From";
            //
            // chkVisitEnd
            //
            _chkVisitEnd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _chkVisitEnd.Cursor = Cursors.Hand;
            _chkVisitEnd.FlatStyle = FlatStyle.System;
            _chkVisitEnd.Location = new Point(1106, 84);
            _chkVisitEnd.Name = "chkVisitEnd";
            _chkVisitEnd.Size = new Size(115, 24);
            _chkVisitEnd.TabIndex = 52;
            _chkVisitEnd.Text = "Visit End Date";
            //
            // dtpToServiceDate
            //
            _dtpToServiceDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _dtpToServiceDate.Location = new Point(1274, 184);
            _dtpToServiceDate.Name = "dtpToServiceDate";
            _dtpToServiceDate.Size = new Size(158, 21);
            _dtpToServiceDate.TabIndex = 49;
            //
            // dtpFromServiceDate
            //
            _dtpFromServiceDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _dtpFromServiceDate.Location = new Point(1274, 153);
            _dtpFromServiceDate.Name = "dtpFromServiceDate";
            _dtpFromServiceDate.Size = new Size(158, 21);
            _dtpFromServiceDate.TabIndex = 48;
            //
            // Label18
            //
            _Label18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label18.Location = new Point(1220, 187);
            _Label18.Name = "Label18";
            _Label18.Size = new Size(48, 16);
            _Label18.TabIndex = 46;
            _Label18.Text = "To";
            //
            // Label19
            //
            _Label19.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label19.Location = new Point(1220, 155);
            _Label19.Name = "Label19";
            _Label19.Size = new Size(48, 16);
            _Label19.TabIndex = 45;
            _Label19.Text = "From";
            //
            // chkServiceDate
            //
            _chkServiceDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _chkServiceDate.Cursor = Cursors.Hand;
            _chkServiceDate.Location = new Point(1106, 150);
            _chkServiceDate.Name = "chkServiceDate";
            _chkServiceDate.Size = new Size(95, 24);
            _chkServiceDate.TabIndex = 47;
            _chkServiceDate.Text = "Service Date";
            _chkServiceDate.UseVisualStyleBackColor = true;
            //
            // Label17
            //
            _Label17.BackColor = Color.Transparent;
            _Label17.Location = new Point(6, 248);
            _Label17.Name = "Label17";
            _Label17.Size = new Size(94, 15);
            _Label17.TabIndex = 44;
            _Label17.Text = "Priority";
            //
            // cboPriority
            //
            _cboPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboPriority.Location = new Point(104, 243);
            _cboPriority.Name = "cboPriority";
            _cboPriority.Size = new Size(184, 21);
            _cboPriority.TabIndex = 43;
            //
            // Label16
            //
            _Label16.BackColor = Color.Transparent;
            _Label16.Location = new Point(295, 244);
            _Label16.Name = "Label16";
            _Label16.Size = new Size(90, 16);
            _Label16.TabIndex = 42;
            _Label16.Text = "Letter Number";
            //
            // cboLetterNumber
            //
            _cboLetterNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboLetterNumber.Location = new Point(390, 240);
            _cboLetterNumber.Name = "cboLetterNumber";
            _cboLetterNumber.Size = new Size(266, 21);
            _cboLetterNumber.TabIndex = 41;
            //
            // chkftfcode
            //
            _chkftfcode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _chkftfcode.Cursor = Cursors.Hand;
            _chkftfcode.Location = new Point(1335, 213);
            _chkftfcode.Name = "chkftfcode";
            _chkftfcode.Size = new Size(95, 17);
            _chkftfcode.TabIndex = 40;
            _chkftfcode.Text = "No FTF code";
            _chkftfcode.UseVisualStyleBackColor = true;
            _chkftfcode.Visible = false;
            //
            // Label15
            //
            _Label15.Location = new Point(296, 120);
            _Label15.Name = "Label15";
            _Label15.Size = new Size(81, 20);
            _Label15.TabIndex = 39;
            _Label15.Text = "Cost Centre";
            //
            // cboDepartment
            //
            _cboDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboDepartment.Location = new Point(390, 116);
            _cboDepartment.Name = "cboDepartment";
            _cboDepartment.Size = new Size(266, 21);
            _cboDepartment.TabIndex = 38;
            //
            // Label14
            //
            _Label14.BackColor = Color.Transparent;
            _Label14.Location = new Point(6, 220);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(96, 13);
            _Label14.TabIndex = 37;
            _Label14.Text = "Serv Expires in";
            //
            // CboServExp
            //
            _CboServExp.DropDownStyle = ComboBoxStyle.DropDownList;
            _CboServExp.Location = new Point(104, 214);
            _CboServExp.Name = "CboServExp";
            _CboServExp.Size = new Size(184, 21);
            _CboServExp.TabIndex = 36;
            //
            // Label13
            //
            _Label13.Location = new Point(6, 153);
            _Label13.Name = "Label13";
            _Label13.Size = new Size(72, 16);
            _Label13.TabIndex = 35;
            _Label13.Text = "Region";
            //
            // cboRegion
            //
            _cboRegion.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboRegion.Location = new Point(104, 149);
            _cboRegion.Name = "cboRegion";
            _cboRegion.Size = new Size(184, 21);
            _cboRegion.TabIndex = 34;
            //
            // btnSearch
            //
            _btnSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSearch.Location = new Point(1360, 242);
            _btnSearch.Name = "btnSearch";
            _btnSearch.Size = new Size(70, 23);
            _btnSearch.TabIndex = 33;
            _btnSearch.Text = "Run Filter";
            //
            // Label12
            //
            _Label12.Location = new Point(296, 181);
            _Label12.Name = "Label12";
            _Label12.Size = new Size(62, 22);
            _Label12.TabIndex = 31;
            _Label12.Text = "Outcome";
            //
            // cboOutcome
            //
            _cboOutcome.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboOutcome.Location = new Point(390, 178);
            _cboOutcome.Name = "cboOutcome";
            _cboOutcome.Size = new Size(266, 21);
            _cboOutcome.TabIndex = 32;
            //
            // btnfindEngineer
            //
            _btnfindEngineer.BackColor = Color.White;
            _btnfindEngineer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnfindEngineer.Location = new Point(624, 85);
            _btnfindEngineer.Name = "btnfindEngineer";
            _btnfindEngineer.Size = new Size(32, 23);
            _btnfindEngineer.TabIndex = 29;
            _btnfindEngineer.Text = "...";
            _btnfindEngineer.UseVisualStyleBackColor = false;
            //
            // txtEngineer
            //
            _txtEngineer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtEngineer.Location = new Point(390, 86);
            _txtEngineer.Name = "txtEngineer";
            _txtEngineer.ReadOnly = true;
            _txtEngineer.Size = new Size(228, 21);
            _txtEngineer.TabIndex = 28;
            //
            // Label5
            //
            _Label5.Location = new Point(296, 88);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(70, 16);
            _Label5.TabIndex = 30;
            _Label5.Text = "Engineer";
            //
            // btnFindCustomer
            //
            _btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindCustomer.BackColor = Color.White;
            _btnFindCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindCustomer.Location = new Point(1043, 26);
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
            _txtCustomer.Location = new Point(104, 25);
            _txtCustomer.Name = "txtCustomer";
            _txtCustomer.ReadOnly = true;
            _txtCustomer.Size = new Size(933, 21);
            _txtCustomer.TabIndex = 1;
            //
            // Label4
            //
            _Label4.Location = new Point(8, 24);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(64, 16);
            _Label4.TabIndex = 27;
            _Label4.Text = "Customer";
            //
            // txtPostcode
            //
            _txtPostcode.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtPostcode.Location = new Point(104, 85);
            _txtPostcode.Name = "txtPostcode";
            _txtPostcode.Size = new Size(184, 21);
            _txtPostcode.TabIndex = 5;
            //
            // Label1
            //
            _Label1.Location = new Point(8, 88);
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
            _btnFindSite.Location = new Point(1043, 53);
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
            _txtSite.Location = new Point(104, 55);
            _txtSite.Name = "txtSite";
            _txtSite.ReadOnly = true;
            _txtSite.Size = new Size(933, 21);
            _txtSite.TabIndex = 3;
            //
            // dtpTo
            //
            _dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _dtpTo.Location = new Point(1274, 56);
            _dtpTo.Name = "dtpTo";
            _dtpTo.Size = new Size(156, 21);
            _dtpTo.TabIndex = 13;
            //
            // dtpFrom
            //
            _dtpFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _dtpFrom.Location = new Point(1274, 29);
            _dtpFrom.Name = "dtpFrom";
            _dtpFrom.Size = new Size(156, 21);
            _dtpFrom.TabIndex = 12;
            //
            // txtPONumber
            //
            _txtPONumber.Location = new Point(104, 182);
            _txtPONumber.Name = "txtPONumber";
            _txtPONumber.Size = new Size(184, 21);
            _txtPONumber.TabIndex = 10;
            //
            // txtJobNumber
            //
            _txtJobNumber.Location = new Point(390, 210);
            _txtJobNumber.Name = "txtJobNumber";
            _txtJobNumber.Size = new Size(266, 21);
            _txtJobNumber.TabIndex = 9;
            //
            // Label9
            //
            _Label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label9.Location = new Point(1220, 59);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(48, 16);
            _Label9.TabIndex = 10;
            _Label9.Text = "To";
            //
            // Label8
            //
            _Label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label8.Location = new Point(1220, 31);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(48, 16);
            _Label8.TabIndex = 9;
            _Label8.Text = "From";
            //
            // chkVisitDate
            //
            _chkVisitDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _chkVisitDate.Checked = true;
            _chkVisitDate.CheckState = CheckState.Checked;
            _chkVisitDate.Cursor = Cursors.Hand;
            _chkVisitDate.FlatStyle = FlatStyle.System;
            _chkVisitDate.Location = new Point(1106, 26);
            _chkVisitDate.Name = "chkVisitDate";
            _chkVisitDate.Size = new Size(80, 24);
            _chkVisitDate.TabIndex = 11;
            _chkVisitDate.Text = "Visit Date";
            //
            // Label7
            //
            _Label7.Location = new Point(8, 187);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(88, 16);
            _Label7.TabIndex = 7;
            _Label7.Text = "PO Number";
            //
            // Label6
            //
            _Label6.Location = new Point(297, 216);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(80, 16);
            _Label6.TabIndex = 6;
            _Label6.Text = "Job Number";
            //
            // Label2
            //
            _Label2.Location = new Point(8, 56);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(64, 16);
            _Label2.TabIndex = 2;
            _Label2.Text = "Property";
            //
            // Label10
            //
            _Label10.Location = new Point(296, 150);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(70, 22);
            _Label10.TabIndex = 4;
            _Label10.Text = "Job Type";
            //
            // cboType
            //
            _cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboType.Location = new Point(390, 147);
            _cboType.Name = "cboType";
            _cboType.Size = new Size(266, 21);
            _cboType.TabIndex = 7;
            //
            // Label11
            //
            _Label11.Location = new Point(6, 123);
            _Label11.Name = "Label11";
            _Label11.Size = new Size(48, 22);
            _Label11.TabIndex = 5;
            _Label11.Text = "Status";
            //
            // cboStatus
            //
            _cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboStatus.Location = new Point(104, 117);
            _cboStatus.Name = "cboStatus";
            _cboStatus.Size = new Size(184, 21);
            _cboStatus.TabIndex = 8;
            //
            // Label3
            //
            _Label3.Location = new Point(8, 116);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(72, 16);
            _Label3.TabIndex = 3;
            _Label3.Text = "Definition";
            //
            // cboDefinition
            //
            _cboDefinition.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboDefinition.Location = new Point(104, 116);
            _cboDefinition.Name = "cboDefinition";
            _cboDefinition.Size = new Size(184, 21);
            _cboDefinition.TabIndex = 6;
            //
            // btnReset
            //
            _btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnReset.Location = new Point(72, 531);
            _btnReset.Name = "btnReset";
            _btnReset.Size = new Size(56, 23);
            _btnReset.TabIndex = 16;
            _btnReset.Text = "Reset";
            //
            // btnRequiringParts
            //
            _btnRequiringParts.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnRequiringParts.Location = new Point(136, 531);
            _btnRequiringParts.Name = "btnRequiringParts";
            _btnRequiringParts.Size = new Size(144, 23);
            _btnRequiringParts.TabIndex = 17;
            _btnRequiringParts.Text = "Visits Requiring Parts";
            //
            // btnCreateOrder
            //
            _btnCreateOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnCreateOrder.Location = new Point(288, 531);
            _btnCreateOrder.Name = "btnCreateOrder";
            _btnCreateOrder.Size = new Size(112, 23);
            _btnCreateOrder.TabIndex = 18;
            _btnCreateOrder.Text = "Create Order";
            //
            // FRMVisitManager
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(1454, 561);
            Controls.Add(_btnCreateOrder);
            Controls.Add(_btnRequiringParts);
            Controls.Add(_grpFilter);
            Controls.Add(_btnExport);
            Controls.Add(_grpEngineerVisits);
            Controls.Add(_btnReset);
            MinimumSize = new Size(808, 528);
            Name = "FRMVisitManager";
            Text = "Visit Manager";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_btnReset, 0);
            Controls.SetChildIndex(_grpEngineerVisits, 0);
            Controls.SetChildIndex(_btnExport, 0);
            Controls.SetChildIndex(_grpFilter, 0);
            Controls.SetChildIndex(_btnRequiringParts, 0);
            Controls.SetChildIndex(_btnCreateOrder, 0);
            _grpEngineerVisits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgVisits).EndInit();
            _grpFilter.ResumeLayout(false);
            _grpFilter.PerformLayout();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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