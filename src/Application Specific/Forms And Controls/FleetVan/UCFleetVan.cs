using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCFleetVan : UCBase, IUserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCFleetVan() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCFleetVan_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            var argc = cboVanType;
            Combo.SetUpCombo(ref argc, App.DB.FleetVanType.GetAll().Table, "VanTypeID", "Model", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc1 = cboFaultType;
            Combo.SetUpCombo(ref argc1, App.DB.FleetVanFault.FaultTypes_GetAll().Table, "VanFaultTypeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc2 = cboProcurementMethod;
            Combo.SetUpCombo(ref argc2, DynamicDataTables.FleetVanContractProcurementMethod, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
            switch (true)
            {
                case object _ when App.IsGasway:
                    {
                        var argc3 = cboDepartment;
                        Combo.SetUpCombo(ref argc3, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Department).Table, "Name", "Name", Entity.Sys.Enums.ComboValues.Please_Select_Negative);
                        break;
                    }

                default:
                    {
                        var argc4 = cboDepartment;
                        Combo.SetUpCombo(ref argc4, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Department).Table, "Name", "Description", Entity.Sys.Enums.ComboValues.Please_Select_Negative);
                        break;
                    }
            }
        }

        // UserControl overrides dispose to clean up the component list.
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

        private TabPage _tabHistory;

        internal TabPage tabHistory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabHistory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabHistory != null)
                {
                }

                _tabHistory = value;
                if (_tabHistory != null)
                {
                }
            }
        }

        private GroupBox _grpVanAudit;

        internal GroupBox grpVanAudit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpVanAudit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpVanAudit != null)
                {
                }

                _grpVanAudit = value;
                if (_grpVanAudit != null)
                {
                }
            }
        }

        private DataGrid _dgVanAudits;

        internal DataGrid dgVanAudits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgVanAudits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgVanAudits != null)
                {
                    _dgVanAudits.Click -= dgVanAudits_Click;
                }

                _dgVanAudits = value;
                if (_dgVanAudits != null)
                {
                    _dgVanAudits.Click += dgVanAudits_Click;
                }
            }
        }

        private TabPage _tabDetails;

        internal TabPage tabDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabDetails != null)
                {
                }

                _tabDetails = value;
                if (_tabDetails != null)
                {
                }
            }
        }

        private GroupBox _grpMaintenance;

        internal GroupBox grpMaintenance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpMaintenance;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpMaintenance != null)
                {
                }

                _grpMaintenance = value;
                if (_grpMaintenance != null)
                {
                }
            }
        }

        private DateTimePicker _dtpNextServiceDate;

        internal DateTimePicker dtpNextServiceDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpNextServiceDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpNextServiceDate != null)
                {
                }

                _dtpNextServiceDate = value;
                if (_dtpNextServiceDate != null)
                {
                }
            }
        }

        private Label _lblNextServiceDate;

        internal Label lblNextServiceDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNextServiceDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblNextServiceDate != null)
                {
                }

                _lblNextServiceDate = value;
                if (_lblNextServiceDate != null)
                {
                }
            }
        }

        private DateTimePicker _dtpLastServiceDate;

        internal DateTimePicker dtpLastServiceDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpLastServiceDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpLastServiceDate != null)
                {
                }

                _dtpLastServiceDate = value;
                if (_dtpLastServiceDate != null)
                {
                }
            }
        }

        private DateTimePicker _dtpMOTExpiry;

        internal DateTimePicker dtpMOTExpiry
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpMOTExpiry;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpMOTExpiry != null)
                {
                }

                _dtpMOTExpiry = value;
                if (_dtpMOTExpiry != null)
                {
                }
            }
        }

        private Label _lblMOT;

        internal Label lblMOT
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMOT;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMOT != null)
                {
                }

                _lblMOT = value;
                if (_lblMOT != null)
                {
                }
            }
        }

        private TextBox _txtBreakdown;

        internal TextBox txtBreakdown
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtBreakdown;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtBreakdown != null)
                {
                }

                _txtBreakdown = value;
                if (_txtBreakdown != null)
                {
                }
            }
        }

        private Label _lblBreakdownCompany;

        internal Label lblBreakdownCompany
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblBreakdownCompany;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblBreakdownCompany != null)
                {
                }

                _lblBreakdownCompany = value;
                if (_lblBreakdownCompany != null)
                {
                }
            }
        }

        private Label _lblLastService;

        internal Label lblLastService
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblLastService;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblLastService != null)
                {
                }

                _lblLastService = value;
                if (_lblLastService != null)
                {
                }
            }
        }

        private GroupBox _grpEngineer;

        internal GroupBox grpEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpEngineer != null)
                {
                }

                _grpEngineer = value;
                if (_grpEngineer != null)
                {
                }
            }
        }

        private DateTimePicker _dtpStartDate;

        internal DateTimePicker dtpStartDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpStartDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpStartDate != null)
                {
                }

                _dtpStartDate = value;
                if (_dtpStartDate != null)
                {
                }
            }
        }

        private Label _lblStartDate;

        internal Label lblStartDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblStartDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblStartDate != null)
                {
                }

                _lblStartDate = value;
                if (_lblStartDate != null)
                {
                }
            }
        }

        private Label _lblDepartment;

        internal Label lblDepartment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDepartment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDepartment != null)
                {
                }

                _lblDepartment = value;
                if (_lblDepartment != null)
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

        private Label _lblEngineer;

        internal Label lblEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEngineer != null)
                {
                }

                _lblEngineer = value;
                if (_lblEngineer != null)
                {
                }
            }
        }

        private GroupBox _grpVan;

        internal GroupBox grpVan
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpVan;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpVan != null)
                {
                }

                _grpVan = value;
                if (_grpVan != null)
                {
                }
            }
        }

        private Label _lblReturned;

        internal Label lblReturned
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblReturned;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblReturned != null)
                {
                }

                _lblReturned = value;
                if (_lblReturned != null)
                {
                }
            }
        }

        private TextBox _txtAverageMileage;

        internal TextBox txtAverageMileage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAverageMileage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAverageMileage != null)
                {
                }

                _txtAverageMileage = value;
                if (_txtAverageMileage != null)
                {
                }
            }
        }

        private Label _lblAverageMileage;

        internal Label lblAverageMileage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAverageMileage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAverageMileage != null)
                {
                }

                _lblAverageMileage = value;
                if (_lblAverageMileage != null)
                {
                }
            }
        }

        private TextBox _txtMileage;

        internal TextBox txtMileage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMileage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMileage != null)
                {
                }

                _txtMileage = value;
                if (_txtMileage != null)
                {
                }
            }
        }

        private Label _lblMileage;

        internal Label lblMileage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMileage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMileage != null)
                {
                }

                _lblMileage = value;
                if (_lblMileage != null)
                {
                }
            }
        }

        private TextBox _txtModel;

        internal TextBox txtModel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtModel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtModel != null)
                {
                }

                _txtModel = value;
                if (_txtModel != null)
                {
                }
            }
        }

        private Label _lblMdoel;

        internal Label lblMdoel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMdoel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMdoel != null)
                {
                }

                _lblMdoel = value;
                if (_lblMdoel != null)
                {
                }
            }
        }

        private ComboBox _cboVanType;

        internal ComboBox cboVanType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboVanType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboVanType != null)
                {
                    _cboVanType.SelectedIndexChanged -= cboVanType_SelectedIndexChanged;
                }

                _cboVanType = value;
                if (_cboVanType != null)
                {
                    _cboVanType.SelectedIndexChanged += cboVanType_SelectedIndexChanged;
                }
            }
        }

        private TextBox _txtMake;

        internal TextBox txtMake
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMake;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMake != null)
                {
                }

                _txtMake = value;
                if (_txtMake != null)
                {
                }
            }
        }

        private TextBox _txtRegistration;

        internal TextBox txtRegistration
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtRegistration;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtRegistration != null)
                {
                }

                _txtRegistration = value;
                if (_txtRegistration != null)
                {
                }
            }
        }

        private Label _lblRegistration;

        internal Label lblRegistration
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRegistration;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRegistration != null)
                {
                }

                _lblRegistration = value;
                if (_lblRegistration != null)
                {
                }
            }
        }

        private TextBox _txtNotes;

        internal TextBox txtNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNotes != null)
                {
                }

                _txtNotes = value;
                if (_txtNotes != null)
                {
                }
            }
        }

        private Label _lblNotes;

        internal Label lblNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblNotes != null)
                {
                }

                _lblNotes = value;
                if (_lblNotes != null)
                {
                }
            }
        }

        private Label _lblInsuranceDue;

        internal Label lblInsuranceDue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInsuranceDue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInsuranceDue != null)
                {
                }

                _lblInsuranceDue = value;
                if (_lblInsuranceDue != null)
                {
                }
            }
        }

        private Label _lblMake;

        internal Label lblMake
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMake;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMake != null)
                {
                }

                _lblMake = value;
                if (_lblMake != null)
                {
                }
            }
        }

        private TabControl _tcVans;

        internal TabControl tcVans
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tcVans;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tcVans != null)
                {
                }

                _tcVans = value;
                if (_tcVans != null)
                {
                }
            }
        }

        private DateTimePicker _dtpTaxExpiry;

        internal DateTimePicker dtpTaxExpiry
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpTaxExpiry;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpTaxExpiry != null)
                {
                }

                _dtpTaxExpiry = value;
                if (_dtpTaxExpiry != null)
                {
                }
            }
        }

        private Label _lblRoadTax;

        internal Label lblRoadTax
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRoadTax;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRoadTax != null)
                {
                }

                _lblRoadTax = value;
                if (_lblRoadTax != null)
                {
                }
            }
        }

        private Button _btnNextService;

        internal Button btnNextService
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnNextService;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnNextService != null)
                {
                    _btnNextService.Click -= btnNextService_Click;
                }

                _btnNextService = value;
                if (_btnNextService != null)
                {
                    _btnNextService.Click += btnNextService_Click;
                }
            }
        }

        private TextBox _txtLastServiceMileage;

        internal TextBox txtLastServiceMileage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtLastServiceMileage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtLastServiceMileage != null)
                {
                }

                _txtLastServiceMileage = value;
                if (_txtLastServiceMileage != null)
                {
                }
            }
        }

        private Label _lblMileageLastService;

        internal Label lblMileageLastService
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMileageLastService;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMileageLastService != null)
                {
                }

                _lblMileageLastService = value;
                if (_lblMileageLastService != null)
                {
                }
            }
        }

        private CheckBox _chkReturned;

        internal CheckBox chkReturned
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkReturned;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkReturned != null)
                {
                    _chkReturned.CheckedChanged -= chkReturned_CheckedChanged;
                }

                _chkReturned = value;
                if (_chkReturned != null)
                {
                    _chkReturned.CheckedChanged += chkReturned_CheckedChanged;
                }
            }
        }

        private TabPage _tabFaults;

        internal TabPage tabFaults
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabFaults;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabFaults != null)
                {
                }

                _tabFaults = value;
                if (_tabFaults != null)
                {
                }
            }
        }

        private GroupBox _grpFaultDetails;

        internal GroupBox grpFaultDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpFaultDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpFaultDetails != null)
                {
                }

                _grpFaultDetails = value;
                if (_grpFaultDetails != null)
                {
                }
            }
        }

        private ComboBox _cboFaultType;

        internal ComboBox cboFaultType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFaultType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboFaultType != null)
                {
                }

                _cboFaultType = value;
                if (_cboFaultType != null)
                {
                }
            }
        }

        private TextBox _txtEngineerFaultNotes;

        internal TextBox txtEngineerFaultNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEngineerFaultNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEngineerFaultNotes != null)
                {
                }

                _txtEngineerFaultNotes = value;
                if (_txtEngineerFaultNotes != null)
                {
                }
            }
        }

        private Label _lblEngineerNotes;

        internal Label lblEngineerNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEngineerNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEngineerNotes != null)
                {
                }

                _lblEngineerNotes = value;
                if (_lblEngineerNotes != null)
                {
                }
            }
        }

        private Label _lblFaultType;

        internal Label lblFaultType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFaultType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFaultType != null)
                {
                }

                _lblFaultType = value;
                if (_lblFaultType != null)
                {
                }
            }
        }

        private GroupBox _grpVanFaultDg;

        internal GroupBox grpVanFaultDg
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpVanFaultDg;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpVanFaultDg != null)
                {
                }

                _grpVanFaultDg = value;
                if (_grpVanFaultDg != null)
                {
                }
            }
        }

        private DataGrid _dgVanFaults;

        internal DataGrid dgVanFaults
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgVanFaults;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgVanFaults != null)
                {
                    _dgVanFaults.Click -= dgVanFaults_Click;
                    _dgVanFaults.CurrentCellChanged -= dgVanFaults_Click;
                    _dgVanFaults.DoubleClick -= dgVanFaults_DoubleClick;
                }

                _dgVanFaults = value;
                if (_dgVanFaults != null)
                {
                    _dgVanFaults.Click += dgVanFaults_Click;
                    _dgVanFaults.CurrentCellChanged += dgVanFaults_Click;
                    _dgVanFaults.DoubleClick += dgVanFaults_DoubleClick;
                }
            }
        }

        private TextBox _txtFaultNotes;

        internal TextBox txtFaultNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFaultNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFaultNotes != null)
                {
                }

                _txtFaultNotes = value;
                if (_txtFaultNotes != null)
                {
                }
            }
        }

        private Label _lblFaultNotes;

        internal Label lblFaultNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFaultNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFaultNotes != null)
                {
                }

                _lblFaultNotes = value;
                if (_lblFaultNotes != null)
                {
                }
            }
        }

        private CheckBox _chkResolved;

        internal CheckBox chkResolved
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkResolved;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkResolved != null)
                {
                    _chkResolved.CheckedChanged -= chkResolved_CheckedChanged;
                }

                _chkResolved = value;
                if (_chkResolved != null)
                {
                    _chkResolved.CheckedChanged += chkResolved_CheckedChanged;
                }
            }
        }

        private DateTimePicker _dtpResolvedDate;

        internal DateTimePicker dtpResolvedDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpResolvedDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpResolvedDate != null)
                {
                }

                _dtpResolvedDate = value;
                if (_dtpResolvedDate != null)
                {
                }
            }
        }

        private Label _lblResolvedDate;

        internal Label lblResolvedDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblResolvedDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblResolvedDate != null)
                {
                }

                _lblResolvedDate = value;
                if (_lblResolvedDate != null)
                {
                }
            }
        }

        private DateTimePicker _dtpFaultDate;

        internal DateTimePicker dtpFaultDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpFaultDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpFaultDate != null)
                {
                }

                _dtpFaultDate = value;
                if (_dtpFaultDate != null)
                {
                }
            }
        }

        private Label _lblFaultDate;

        internal Label lblFaultDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFaultDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFaultDate != null)
                {
                }

                _lblFaultDate = value;
                if (_lblFaultDate != null)
                {
                }
            }
        }

        private Button _btnRemove;

        internal Button btnRemove
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemove;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemove != null)
                {
                    _btnRemove.Click -= btnRemove_Click;
                }

                _btnRemove = value;
                if (_btnRemove != null)
                {
                    _btnRemove.Click += btnRemove_Click;
                }
            }
        }

        private TabPage _tabContract;

        internal TabPage tabContract
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabContract;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabContract != null)
                {
                }

                _tabContract = value;
                if (_tabContract != null)
                {
                }
            }
        }

        private GroupBox _grpContractDetails;

        internal GroupBox grpContractDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpContractDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpContractDetails != null)
                {
                }

                _grpContractDetails = value;
                if (_grpContractDetails != null)
                {
                }
            }
        }

        private ComboBox _cboProcurementMethod;

        internal ComboBox cboProcurementMethod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboProcurementMethod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboProcurementMethod != null)
                {
                    _cboProcurementMethod.SelectedIndexChanged -= cboProcurementMethod_SelectedIndexChanged;
                }

                _cboProcurementMethod = value;
                if (_cboProcurementMethod != null)
                {
                    _cboProcurementMethod.SelectedIndexChanged += cboProcurementMethod_SelectedIndexChanged;
                }
            }
        }

        private TextBox _txtContractLength;

        internal TextBox txtContractLength
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContractLength;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContractLength != null)
                {
                }

                _txtContractLength = value;
                if (_txtContractLength != null)
                {
                }
            }
        }

        private TextBox _txtLessor;

        internal TextBox txtLessor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtLessor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtLessor != null)
                {
                }

                _txtLessor = value;
                if (_txtLessor != null)
                {
                }
            }
        }

        private Label _lblLessor;

        internal Label lblLessor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblLessor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblLessor != null)
                {
                }

                _lblLessor = value;
                if (_lblLessor != null)
                {
                }
            }
        }

        private Label _lblProcurementMethod;

        internal Label lblProcurementMethod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblProcurementMethod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblProcurementMethod != null)
                {
                }

                _lblProcurementMethod = value;
                if (_lblProcurementMethod != null)
                {
                }
            }
        }

        private Label _lblContractLength;

        internal Label lblContractLength
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractLength;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractLength != null)
                {
                }

                _lblContractLength = value;
                if (_lblContractLength != null)
                {
                }
            }
        }

        private TabPage _tabEngineerHistory;

        internal TabPage tabEngineerHistory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabEngineerHistory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabEngineerHistory != null)
                {
                }

                _tabEngineerHistory = value;
                if (_tabEngineerHistory != null)
                {
                }
            }
        }

        private GroupBox _grpEngineerHistory;

        internal GroupBox grpEngineerHistory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpEngineerHistory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpEngineerHistory != null)
                {
                }

                _grpEngineerHistory = value;
                if (_grpEngineerHistory != null)
                {
                }
            }
        }

        private DataGrid _dgEngineerHistory;

        internal DataGrid dgEngineerHistory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgEngineerHistory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgEngineerHistory != null)
                {
                }

                _dgEngineerHistory = value;
                if (_dgEngineerHistory != null)
                {
                }
            }
        }

        private Button _btnNewFault;

        internal Button btnNewFault
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnNewFault;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnNewFault != null)
                {
                    _btnNewFault.Click -= btnNewFault_Click;
                }

                _btnNewFault = value;
                if (_btnNewFault != null)
                {
                    _btnNewFault.Click += btnNewFault_Click;
                }
            }
        }

        private DateTimePicker _dtpContractEnd;

        internal DateTimePicker dtpContractEnd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpContractEnd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpContractEnd != null)
                {
                }

                _dtpContractEnd = value;
                if (_dtpContractEnd != null)
                {
                }
            }
        }

        private Label _lblContractEnd;

        internal Label lblContractEnd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractEnd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractEnd != null)
                {
                }

                _lblContractEnd = value;
                if (_lblContractEnd != null)
                {
                }
            }
        }

        private DateTimePicker _dtpContractStart;

        internal DateTimePicker dtpContractStart
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpContractStart;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpContractStart != null)
                {
                }

                _dtpContractStart = value;
                if (_dtpContractStart != null)
                {
                }
            }
        }

        private Label _lblContractStart;

        internal Label lblContractStart
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractStart;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractStart != null)
                {
                }

                _lblContractStart = value;
                if (_lblContractStart != null)
                {
                }
            }
        }

        private TextBox _txtAgreementRef;

        internal TextBox txtAgreementRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAgreementRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAgreementRef != null)
                {
                }

                _txtAgreementRef = value;
                if (_txtAgreementRef != null)
                {
                }
            }
        }

        private Label _lblAgreementRef;

        internal Label lblAgreementRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAgreementRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAgreementRef != null)
                {
                }

                _lblAgreementRef = value;
                if (_lblAgreementRef != null)
                {
                }
            }
        }

        private TextBox _txtContractMileage;

        internal TextBox txtContractMileage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContractMileage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContractMileage != null)
                {
                }

                _txtContractMileage = value;
                if (_txtContractMileage != null)
                {
                }
            }
        }

        private Label _lblContractMileage;

        internal Label lblContractMileage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractMileage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractMileage != null)
                {
                }

                _lblContractMileage = value;
                if (_lblContractMileage != null)
                {
                }
            }
        }

        private GroupBox _grpFinances;

        internal GroupBox grpFinances
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpFinances;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpFinances != null)
                {
                }

                _grpFinances = value;
                if (_grpFinances != null)
                {
                }
            }
        }

        private TextBox _txtMonthlyRental;

        internal TextBox txtMonthlyRental
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMonthlyRental;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMonthlyRental != null)
                {
                    _txtMonthlyRental.KeyUp -= txtMonthlyRental_KeyUp;
                }

                _txtMonthlyRental = value;
                if (_txtMonthlyRental != null)
                {
                    _txtMonthlyRental.KeyUp += txtMonthlyRental_KeyUp;
                }
            }
        }

        private Label _lblMonthlyRental;

        internal Label lblMonthlyRental
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMonthlyRental;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMonthlyRental != null)
                {
                }

                _lblMonthlyRental = value;
                if (_lblMonthlyRental != null)
                {
                }
            }
        }

        private Label _lblAnnualRental;

        internal Label lblAnnualRental
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAnnualRental;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAnnualRental != null)
                {
                }

                _lblAnnualRental = value;
                if (_lblAnnualRental != null)
                {
                }
            }
        }

        private TextBox _txtWeeklyRental;

        internal TextBox txtWeeklyRental
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtWeeklyRental;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtWeeklyRental != null)
                {
                    _txtWeeklyRental.KeyUp -= txtWeeklyRental_KeyUp;
                }

                _txtWeeklyRental = value;
                if (_txtWeeklyRental != null)
                {
                    _txtWeeklyRental.KeyUp += txtWeeklyRental_KeyUp;
                }
            }
        }

        private TextBox _txtExcessMileageRate;

        internal TextBox txtExcessMileageRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtExcessMileageRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtExcessMileageRate != null)
                {
                    _txtExcessMileageRate.KeyUp -= txtExcessMileageRate_KeyUp;
                }

                _txtExcessMileageRate = value;
                if (_txtExcessMileageRate != null)
                {
                    _txtExcessMileageRate.KeyUp += txtExcessMileageRate_KeyUp;
                }
            }
        }

        private Label _lblExcessMileageRate;

        internal Label lblExcessMileageRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblExcessMileageRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblExcessMileageRate != null)
                {
                }

                _lblExcessMileageRate = value;
                if (_lblExcessMileageRate != null)
                {
                }
            }
        }

        private Label _lblWeeklyRental;

        internal Label lblWeeklyRental
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblWeeklyRental;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblWeeklyRental != null)
                {
                }

                _lblWeeklyRental = value;
                if (_lblWeeklyRental != null)
                {
                }
            }
        }

        private TextBox _txtAnnualRental;

        internal TextBox txtAnnualRental
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAnnualRental;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAnnualRental != null)
                {
                    _txtAnnualRental.KeyUp -= txtAnnualRental_KeyUp;
                }

                _txtAnnualRental = value;
                if (_txtAnnualRental != null)
                {
                    _txtAnnualRental.KeyUp += txtAnnualRental_KeyUp;
                }
            }
        }

        private TextBox _txtContractNotes;

        internal TextBox txtContractNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContractNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContractNotes != null)
                {
                }

                _txtContractNotes = value;
                if (_txtContractNotes != null)
                {
                }
            }
        }

        private Label _lblContractNotes;

        internal Label lblContractNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractNotes != null)
                {
                }

                _lblContractNotes = value;
                if (_lblContractNotes != null)
                {
                }
            }
        }

        private TabPage _tabServiceHistory;

        internal TabPage tabServiceHistory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabServiceHistory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabServiceHistory != null)
                {
                }

                _tabServiceHistory = value;
                if (_tabServiceHistory != null)
                {
                }
            }
        }

        private GroupBox _gpServiceHistory;

        internal GroupBox gpServiceHistory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpServiceHistory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpServiceHistory != null)
                {
                }

                _gpServiceHistory = value;
                if (_gpServiceHistory != null)
                {
                }
            }
        }

        private DataGrid _dgServiceHistory;

        internal DataGrid dgServiceHistory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgServiceHistory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgServiceHistory != null)
                {
                    _dgServiceHistory.DoubleClick -= dgServiceHistory_DoubleClick;
                }

                _dgServiceHistory = value;
                if (_dgServiceHistory != null)
                {
                    _dgServiceHistory.DoubleClick += dgServiceHistory_DoubleClick;
                }
            }
        }

        private Button _btnRemoveEquipment;

        internal Button btnRemoveEquipment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveEquipment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveEquipment != null)
                {
                    _btnRemoveEquipment.Click -= btnRemoveEquipment_Click;
                }

                _btnRemoveEquipment = value;
                if (_btnRemoveEquipment != null)
                {
                    _btnRemoveEquipment.Click += btnRemoveEquipment_Click;
                }
            }
        }

        private Button _btnAddEquipment;

        internal Button btnAddEquipment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddEquipment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddEquipment != null)
                {
                    _btnAddEquipment.Click -= btnAddEquipment_Click;
                }

                _btnAddEquipment = value;
                if (_btnAddEquipment != null)
                {
                    _btnAddEquipment.Click += btnAddEquipment_Click;
                }
            }
        }

        private DataGrid _dgEquipment;

        internal DataGrid dgEquipment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgEquipment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgEquipment != null)
                {
                }

                _dgEquipment = value;
                if (_dgEquipment != null)
                {
                }
            }
        }

        private TextBox _txtForecastExcessCost;

        internal TextBox txtForecastExcessCost
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtForecastExcessCost;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtForecastExcessCost != null)
                {
                }

                _txtForecastExcessCost = value;
                if (_txtForecastExcessCost != null)
                {
                }
            }
        }

        private Label _lblForcastedExcessCost;

        internal Label lblForcastedExcessCost
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblForcastedExcessCost;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblForcastedExcessCost != null)
                {
                }

                _lblForcastedExcessCost = value;
                if (_lblForcastedExcessCost != null)
                {
                }
            }
        }

        private TextBox _txtExcessMileageCost;

        internal TextBox txtExcessMileageCost
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtExcessMileageCost;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtExcessMileageCost != null)
                {
                }

                _txtExcessMileageCost = value;
                if (_txtExcessMileageCost != null)
                {
                }
            }
        }

        private Label _lblExcessCost;

        internal Label lblExcessCost
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblExcessCost;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblExcessCost != null)
                {
                }

                _lblExcessCost = value;
                if (_lblExcessCost != null)
                {
                }
            }
        }

        private TabPage _tabDocuments;

        internal TabPage tabDocuments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabDocuments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabDocuments != null)
                {
                }

                _tabDocuments = value;
                if (_tabDocuments != null)
                {
                }
            }
        }

        private TextBox _txtJobRef;

        internal TextBox txtJobRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtJobRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtJobRef != null)
                {
                }

                _txtJobRef = value;
                if (_txtJobRef != null)
                {
                }
            }
        }

        private Label _lblJobRef;

        internal Label lblJobRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblJobRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblJobRef != null)
                {
                }

                _lblJobRef = value;
                if (_lblJobRef != null)
                {
                }
            }
        }

        private TextBox _txtStatus;

        internal TextBox txtStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtStatus != null)
                {
                }

                _txtStatus = value;
                if (_txtStatus != null)
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

        private TextBox _txtScheduled;

        internal TextBox txtScheduled
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtScheduled;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtScheduled != null)
                {
                }

                _txtScheduled = value;
                if (_txtScheduled != null)
                {
                }
            }
        }

        private Label _lblScheduled;

        internal Label lblScheduled
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblScheduled;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblScheduled != null)
                {
                }

                _lblScheduled = value;
                if (_lblScheduled != null)
                {
                }
            }
        }

        private GroupBox _grpHistoryDetails;

        internal GroupBox grpHistoryDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpHistoryDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpHistoryDetails != null)
                {
                }

                _grpHistoryDetails = value;
                if (_grpHistoryDetails != null)
                {
                }
            }
        }

        private TextBox _txtUsername;

        internal TextBox txtUsername
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtUsername;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtUsername != null)
                {
                }

                _txtUsername = value;
                if (_txtUsername != null)
                {
                }
            }
        }

        private Label _lblUser;

        internal Label lblUser
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblUser;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblUser != null)
                {
                }

                _lblUser = value;
                if (_lblUser != null)
                {
                }
            }
        }

        private DateTimePicker _dtpHistoryDate;

        internal DateTimePicker dtpHistoryDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpHistoryDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpHistoryDate != null)
                {
                }

                _dtpHistoryDate = value;
                if (_dtpHistoryDate != null)
                {
                }
            }
        }

        private Label _lblDate;

        internal Label lblDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDate != null)
                {
                }

                _lblDate = value;
                if (_lblDate != null)
                {
                }
            }
        }

        private TextBox _txtChange;

        internal TextBox txtChange
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtChange;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtChange != null)
                {
                }

                _txtChange = value;
                if (_txtChange != null)
                {
                }
            }
        }

        private Label _lblChange;

        internal Label lblChange
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblChange;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblChange != null)
                {
                }

                _lblChange = value;
                if (_lblChange != null)
                {
                }
            }
        }

        private TextBox _txtOutcome;

        internal TextBox txtOutcome
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtOutcome;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtOutcome != null)
                {
                }

                _txtOutcome = value;
                if (_txtOutcome != null)
                {
                }
            }
        }

        private Label _lblOutcome;

        internal Label lblOutcome
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblOutcome;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblOutcome != null)
                {
                }

                _lblOutcome = value;
                if (_lblOutcome != null)
                {
                }
            }
        }

        private Button _btnEndContract;

        internal Button btnEndContract
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnEndContract;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnEndContract != null)
                {
                    _btnEndContract.Click -= btnEndContract_Click;
                }

                _btnEndContract = value;
                if (_btnEndContract != null)
                {
                    _btnEndContract.Click += btnEndContract_Click;
                }
            }
        }

        private CheckBox _chkEndDate;

        internal CheckBox chkEndDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkEndDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkEndDate != null)
                {
                    _chkEndDate.CheckedChanged -= chkEndDate_CheckedChanged;
                }

                _chkEndDate = value;
                if (_chkEndDate != null)
                {
                    _chkEndDate.CheckedChanged += chkEndDate_CheckedChanged;
                }
            }
        }

        private DateTimePicker _dtpEndDate;

        internal DateTimePicker dtpEndDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpEndDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpEndDate != null)
                {
                }

                _dtpEndDate = value;
                if (_dtpEndDate != null)
                {
                }
            }
        }

        private TextBox _txtAdditionalNotes;

        internal TextBox txtAdditionalNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAdditionalNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAdditionalNotes != null)
                {
                }

                _txtAdditionalNotes = value;
                if (_txtAdditionalNotes != null)
                {
                }
            }
        }

        private Label _lblAddNotes;

        internal Label lblAddNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddNotes != null)
                {
                }

                _lblAddNotes = value;
                if (_lblAddNotes != null)
                {
                }
            }
        }

        private CheckBox _chkArchive;

        internal CheckBox chkArchive
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkArchive;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkArchive != null)
                {
                }

                _chkArchive = value;
                if (_chkArchive != null)
                {
                }
            }
        }

        private CheckBox _chkHideArchive;

        internal CheckBox chkHideArchive
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkHideArchive;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkHideArchive != null)
                {
                    _chkHideArchive.CheckedChanged -= chkHideArchive_CheckedChanged;
                }

                _chkHideArchive = value;
                if (_chkHideArchive != null)
                {
                    _chkHideArchive.CheckedChanged += chkHideArchive_CheckedChanged;
                }
            }
        }

        private TextBox _txtStartingMileage;

        internal TextBox txtStartingMileage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtStartingMileage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtStartingMileage != null)
                {
                }

                _txtStartingMileage = value;
                if (_txtStartingMileage != null)
                {
                }
            }
        }

        private Label _lblStartingMileage;

        internal Label lblStartingMileage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblStartingMileage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblStartingMileage != null)
                {
                }

                _lblStartingMileage = value;
                if (_lblStartingMileage != null)
                {
                }
            }
        }

        private TextBox _txtTyreSize;

        internal TextBox txtTyreSize
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTyreSize;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTyreSize != null)
                {
                }

                _txtTyreSize = value;
                if (_txtTyreSize != null)
                {
                }
            }
        }

        private Label _lblTyresSize;

        internal Label lblTyresSize
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTyresSize;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTyresSize != null)
                {
                }

                _lblTyresSize = value;
                if (_lblTyresSize != null)
                {
                }
            }
        }

        private DateTimePicker _dtpBreakdownExpiry;

        internal DateTimePicker dtpBreakdownExpiry
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpBreakdownExpiry;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpBreakdownExpiry != null)
                {
                }

                _dtpBreakdownExpiry = value;
                if (_dtpBreakdownExpiry != null)
                {
                }
            }
        }

        private Label _lblBreakdownExpiry;

        internal Label lblBreakdownExpiry
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblBreakdownExpiry;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblBreakdownExpiry != null)
                {
                }

                _lblBreakdownExpiry = value;
                if (_lblBreakdownExpiry != null)
                {
                }
            }
        }

        private DateTimePicker _dtpWarrantyExpiry;

        internal DateTimePicker dtpWarrantyExpiry
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpWarrantyExpiry;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpWarrantyExpiry != null)
                {
                }

                _dtpWarrantyExpiry = value;
                if (_dtpWarrantyExpiry != null)
                {
                }
            }
        }

        private Label _lblWarrantyExpiry;

        internal Label lblWarrantyExpiry
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblWarrantyExpiry;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblWarrantyExpiry != null)
                {
                }

                _lblWarrantyExpiry = value;
                if (_lblWarrantyExpiry != null)
                {
                }
            }
        }

        private Button _btnRemoveContractEndDate;

        internal Button btnRemoveContractEndDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveContractEndDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveContractEndDate != null)
                {
                    _btnRemoveContractEndDate.Click -= btnRemoveContractEndDate_Click;
                }

                _btnRemoveContractEndDate = value;
                if (_btnRemoveContractEndDate != null)
                {
                    _btnRemoveContractEndDate.Click += btnRemoveContractEndDate_Click;
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

        private Button _btnSaveFault;

        internal Button btnSaveFault
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSaveFault;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSaveFault != null)
                {
                    _btnSaveFault.Click -= (_, __) => btnSaveFault_Click();
                    _btnSaveFault.Click -= btnSaveFault_Click;
                }

                _btnSaveFault = value;
                if (_btnSaveFault != null)
                {
                    _btnSaveFault.Click += (_, __) => btnSaveFault_Click();
                    _btnSaveFault.Click += btnSaveFault_Click;
                }
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _tabHistory = new TabPage();
            _grpHistoryDetails = new GroupBox();
            _txtUsername = new TextBox();
            _lblUser = new Label();
            _dtpHistoryDate = new DateTimePicker();
            _lblDate = new Label();
            _txtChange = new TextBox();
            _lblChange = new Label();
            _grpVanAudit = new GroupBox();
            _dgVanAudits = new DataGrid();
            _dgVanAudits.Click += new EventHandler(dgVanAudits_Click);
            _tabDetails = new TabPage();
            _grpMaintenance = new GroupBox();
            _dtpBreakdownExpiry = new DateTimePicker();
            _lblBreakdownExpiry = new Label();
            _dtpWarrantyExpiry = new DateTimePicker();
            _lblWarrantyExpiry = new Label();
            _txtLastServiceMileage = new TextBox();
            _lblMileageLastService = new Label();
            _btnNextService = new Button();
            _btnNextService.Click += new EventHandler(btnNextService_Click);
            _dtpTaxExpiry = new DateTimePicker();
            _lblRoadTax = new Label();
            _dtpNextServiceDate = new DateTimePicker();
            _lblNextServiceDate = new Label();
            _dtpLastServiceDate = new DateTimePicker();
            _dtpMOTExpiry = new DateTimePicker();
            _lblMOT = new Label();
            _txtBreakdown = new TextBox();
            _lblBreakdownCompany = new Label();
            _lblLastService = new Label();
            _grpEngineer = new GroupBox();
            _cboDepartment = new ComboBox();
            _chkEndDate = new CheckBox();
            _chkEndDate.CheckedChanged += new EventHandler(chkEndDate_CheckedChanged);
            _dtpEndDate = new DateTimePicker();
            _btnRemove = new Button();
            _btnRemove.Click += new EventHandler(btnRemove_Click);
            _dtpStartDate = new DateTimePicker();
            _lblStartDate = new Label();
            _lblDepartment = new Label();
            _btnfindEngineer = new Button();
            _btnfindEngineer.Click += new EventHandler(btnfindEngineer_Click);
            _txtEngineer = new TextBox();
            _lblEngineer = new Label();
            _grpVan = new GroupBox();
            _txtTyreSize = new TextBox();
            _lblTyresSize = new Label();
            _btnRemoveEquipment = new Button();
            _btnRemoveEquipment.Click += new EventHandler(btnRemoveEquipment_Click);
            _btnAddEquipment = new Button();
            _btnAddEquipment.Click += new EventHandler(btnAddEquipment_Click);
            _dgEquipment = new DataGrid();
            _chkReturned = new CheckBox();
            _chkReturned.CheckedChanged += new EventHandler(chkReturned_CheckedChanged);
            _lblReturned = new Label();
            _txtAverageMileage = new TextBox();
            _lblAverageMileage = new Label();
            _txtMileage = new TextBox();
            _lblMileage = new Label();
            _txtModel = new TextBox();
            _lblMdoel = new Label();
            _cboVanType = new ComboBox();
            _cboVanType.SelectedIndexChanged += new EventHandler(cboVanType_SelectedIndexChanged);
            _txtMake = new TextBox();
            _txtRegistration = new TextBox();
            _lblRegistration = new Label();
            _txtNotes = new TextBox();
            _lblNotes = new Label();
            _lblInsuranceDue = new Label();
            _lblMake = new Label();
            _tcVans = new TabControl();
            _tabFaults = new TabPage();
            _chkHideArchive = new CheckBox();
            _chkHideArchive.CheckedChanged += new EventHandler(chkHideArchive_CheckedChanged);
            _grpFaultDetails = new GroupBox();
            _chkArchive = new CheckBox();
            _txtAdditionalNotes = new TextBox();
            _lblAddNotes = new Label();
            _txtOutcome = new TextBox();
            _lblOutcome = new Label();
            _txtStatus = new TextBox();
            _lblVisitStatus = new Label();
            _txtScheduled = new TextBox();
            _lblScheduled = new Label();
            _txtJobRef = new TextBox();
            _lblJobRef = new Label();
            _btnNewFault = new Button();
            _btnNewFault.Click += new EventHandler(btnNewFault_Click);
            _chkResolved = new CheckBox();
            _chkResolved.CheckedChanged += new EventHandler(chkResolved_CheckedChanged);
            _dtpResolvedDate = new DateTimePicker();
            _lblResolvedDate = new Label();
            _dtpFaultDate = new DateTimePicker();
            _lblFaultDate = new Label();
            _txtFaultNotes = new TextBox();
            _lblFaultNotes = new Label();
            _cboFaultType = new ComboBox();
            _txtEngineerFaultNotes = new TextBox();
            _lblEngineerNotes = new Label();
            _lblFaultType = new Label();
            _grpVanFaultDg = new GroupBox();
            _dgVanFaults = new DataGrid();
            _dgVanFaults.Click += new EventHandler(dgVanFaults_Click);
            _dgVanFaults.CurrentCellChanged += new EventHandler(dgVanFaults_Click);
            _dgVanFaults.Click += new EventHandler(dgVanFaults_Click);
            _dgVanFaults.CurrentCellChanged += new EventHandler(dgVanFaults_Click);
            _dgVanFaults.DoubleClick += new EventHandler(dgVanFaults_DoubleClick);
            _tabContract = new TabPage();
            _grpFinances = new GroupBox();
            _txtForecastExcessCost = new TextBox();
            _lblForcastedExcessCost = new Label();
            _txtExcessMileageCost = new TextBox();
            _lblExcessCost = new Label();
            _txtAnnualRental = new TextBox();
            _txtAnnualRental.KeyUp += new KeyEventHandler(txtAnnualRental_KeyUp);
            _txtMonthlyRental = new TextBox();
            _txtMonthlyRental.KeyUp += new KeyEventHandler(txtMonthlyRental_KeyUp);
            _lblMonthlyRental = new Label();
            _lblAnnualRental = new Label();
            _txtWeeklyRental = new TextBox();
            _txtWeeklyRental.KeyUp += new KeyEventHandler(txtWeeklyRental_KeyUp);
            _txtExcessMileageRate = new TextBox();
            _txtExcessMileageRate.KeyUp += new KeyEventHandler(txtExcessMileageRate_KeyUp);
            _lblExcessMileageRate = new Label();
            _lblWeeklyRental = new Label();
            _grpContractDetails = new GroupBox();
            _btnRemoveContractEndDate = new Button();
            _btnRemoveContractEndDate.Click += new EventHandler(btnRemoveContractEndDate_Click);
            _txtStartingMileage = new TextBox();
            _lblStartingMileage = new Label();
            _btnEndContract = new Button();
            _btnEndContract.Click += new EventHandler(btnEndContract_Click);
            _txtContractNotes = new TextBox();
            _lblContractNotes = new Label();
            _txtAgreementRef = new TextBox();
            _lblAgreementRef = new Label();
            _txtContractMileage = new TextBox();
            _lblContractMileage = new Label();
            _dtpContractEnd = new DateTimePicker();
            _lblContractEnd = new Label();
            _dtpContractStart = new DateTimePicker();
            _lblContractStart = new Label();
            _cboProcurementMethod = new ComboBox();
            _cboProcurementMethod.SelectedIndexChanged += new EventHandler(cboProcurementMethod_SelectedIndexChanged);
            _txtContractLength = new TextBox();
            _txtLessor = new TextBox();
            _lblLessor = new Label();
            _lblProcurementMethod = new Label();
            _lblContractLength = new Label();
            _tabEngineerHistory = new TabPage();
            _grpEngineerHistory = new GroupBox();
            _dgEngineerHistory = new DataGrid();
            _tabServiceHistory = new TabPage();
            _gpServiceHistory = new GroupBox();
            _dgServiceHistory = new DataGrid();
            _dgServiceHistory.DoubleClick += new EventHandler(dgServiceHistory_DoubleClick);
            _tabDocuments = new TabPage();
            _btnSaveFault = new Button();
            _btnSaveFault.Click += new EventHandler(btnSaveFault_Click);
            _btnSaveFault.Click += new EventHandler(btnSaveFault_Click);
            _tabHistory.SuspendLayout();
            _grpHistoryDetails.SuspendLayout();
            _grpVanAudit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgVanAudits).BeginInit();
            _tabDetails.SuspendLayout();
            _grpMaintenance.SuspendLayout();
            _grpEngineer.SuspendLayout();
            _grpVan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgEquipment).BeginInit();
            _tcVans.SuspendLayout();
            _tabFaults.SuspendLayout();
            _grpFaultDetails.SuspendLayout();
            _grpVanFaultDg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgVanFaults).BeginInit();
            _tabContract.SuspendLayout();
            _grpFinances.SuspendLayout();
            _grpContractDetails.SuspendLayout();
            _tabEngineerHistory.SuspendLayout();
            _grpEngineerHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgEngineerHistory).BeginInit();
            _tabServiceHistory.SuspendLayout();
            _gpServiceHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgServiceHistory).BeginInit();
            SuspendLayout();
            // 
            // tabHistory
            // 
            _tabHistory.Controls.Add(_grpHistoryDetails);
            _tabHistory.Controls.Add(_grpVanAudit);
            _tabHistory.Location = new Point(4, 22);
            _tabHistory.Name = "tabHistory";
            _tabHistory.Size = new Size(675, 702);
            _tabHistory.TabIndex = 1;
            _tabHistory.Text = "History";
            _tabHistory.UseVisualStyleBackColor = true;
            // 
            // grpHistoryDetails
            // 
            _grpHistoryDetails.Controls.Add(_txtUsername);
            _grpHistoryDetails.Controls.Add(_lblUser);
            _grpHistoryDetails.Controls.Add(_dtpHistoryDate);
            _grpHistoryDetails.Controls.Add(_lblDate);
            _grpHistoryDetails.Controls.Add(_txtChange);
            _grpHistoryDetails.Controls.Add(_lblChange);
            _grpHistoryDetails.Location = new Point(6, 7);
            _grpHistoryDetails.Name = "grpHistoryDetails";
            _grpHistoryDetails.Size = new Size(664, 241);
            _grpHistoryDetails.TabIndex = 17;
            _grpHistoryDetails.TabStop = false;
            _grpHistoryDetails.Text = "History Details";
            // 
            // txtUsername
            // 
            _txtUsername.Location = new Point(372, 24);
            _txtUsername.Name = "txtUsername";
            _txtUsername.ReadOnly = true;
            _txtUsername.Size = new Size(146, 21);
            _txtUsername.TabIndex = 68;
            // 
            // lblUser
            // 
            _lblUser.Location = new Point(312, 27);
            _lblUser.Name = "lblUser";
            _lblUser.Size = new Size(44, 20);
            _lblUser.TabIndex = 67;
            _lblUser.Text = "User";
            // 
            // dtpHistoryDate
            // 
            _dtpHistoryDate.Enabled = false;
            _dtpHistoryDate.Location = new Point(89, 21);
            _dtpHistoryDate.Name = "dtpHistoryDate";
            _dtpHistoryDate.Size = new Size(146, 21);
            _dtpHistoryDate.TabIndex = 2;
            _dtpHistoryDate.Tag = "";
            // 
            // lblDate
            // 
            _lblDate.Location = new Point(9, 27);
            _lblDate.Name = "lblDate";
            _lblDate.Size = new Size(85, 20);
            _lblDate.TabIndex = 65;
            _lblDate.Text = "Date";
            // 
            // txtChange
            // 
            _txtChange.Location = new Point(89, 64);
            _txtChange.Multiline = true;
            _txtChange.Name = "txtChange";
            _txtChange.ScrollBars = ScrollBars.Vertical;
            _txtChange.Size = new Size(569, 161);
            _txtChange.TabIndex = 6;
            _txtChange.Tag = "";
            // 
            // lblChange
            // 
            _lblChange.Location = new Point(10, 64);
            _lblChange.Name = "lblChange";
            _lblChange.Size = new Size(59, 20);
            _lblChange.TabIndex = 45;
            _lblChange.Text = "Change";
            // 
            // grpVanAudit
            // 
            _grpVanAudit.Controls.Add(_dgVanAudits);
            _grpVanAudit.Location = new Point(3, 254);
            _grpVanAudit.Name = "grpVanAudit";
            _grpVanAudit.Size = new Size(664, 553);
            _grpVanAudit.TabIndex = 4;
            _grpVanAudit.TabStop = false;
            _grpVanAudit.Text = "Van Audit";
            // 
            // dgVanAudits
            // 
            _dgVanAudits.DataMember = "";
            _dgVanAudits.Dock = DockStyle.Fill;
            _dgVanAudits.HeaderForeColor = SystemColors.ControlText;
            _dgVanAudits.Location = new Point(3, 17);
            _dgVanAudits.Name = "dgVanAudits";
            _dgVanAudits.Size = new Size(658, 533);
            _dgVanAudits.TabIndex = 15;
            // 
            // tabDetails
            // 
            _tabDetails.Controls.Add(_grpMaintenance);
            _tabDetails.Controls.Add(_grpEngineer);
            _tabDetails.Controls.Add(_grpVan);
            _tabDetails.Location = new Point(4, 22);
            _tabDetails.Name = "tabDetails";
            _tabDetails.Size = new Size(675, 702);
            _tabDetails.TabIndex = 0;
            _tabDetails.Text = "Main Details";
            // 
            // grpMaintenance
            // 
            _grpMaintenance.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _grpMaintenance.Controls.Add(_dtpBreakdownExpiry);
            _grpMaintenance.Controls.Add(_lblBreakdownExpiry);
            _grpMaintenance.Controls.Add(_dtpWarrantyExpiry);
            _grpMaintenance.Controls.Add(_lblWarrantyExpiry);
            _grpMaintenance.Controls.Add(_txtLastServiceMileage);
            _grpMaintenance.Controls.Add(_lblMileageLastService);
            _grpMaintenance.Controls.Add(_btnNextService);
            _grpMaintenance.Controls.Add(_dtpTaxExpiry);
            _grpMaintenance.Controls.Add(_lblRoadTax);
            _grpMaintenance.Controls.Add(_dtpNextServiceDate);
            _grpMaintenance.Controls.Add(_lblNextServiceDate);
            _grpMaintenance.Controls.Add(_dtpLastServiceDate);
            _grpMaintenance.Controls.Add(_dtpMOTExpiry);
            _grpMaintenance.Controls.Add(_lblMOT);
            _grpMaintenance.Controls.Add(_txtBreakdown);
            _grpMaintenance.Controls.Add(_lblBreakdownCompany);
            _grpMaintenance.Controls.Add(_lblLastService);
            _grpMaintenance.Location = new Point(8, 302);
            _grpMaintenance.Name = "grpMaintenance";
            _grpMaintenance.Size = new Size(664, 222);
            _grpMaintenance.TabIndex = 61;
            _grpMaintenance.TabStop = false;
            _grpMaintenance.Text = "Maintenance";
            // 
            // dtpBreakdownExpiry
            // 
            _dtpBreakdownExpiry.Location = new Point(457, 178);
            _dtpBreakdownExpiry.Name = "dtpBreakdownExpiry";
            _dtpBreakdownExpiry.Size = new Size(141, 21);
            _dtpBreakdownExpiry.TabIndex = 71;
            _dtpBreakdownExpiry.Tag = "";
            // 
            // lblBreakdownExpiry
            // 
            _lblBreakdownExpiry.Location = new Point(325, 184);
            _lblBreakdownExpiry.Name = "lblBreakdownExpiry";
            _lblBreakdownExpiry.Size = new Size(117, 20);
            _lblBreakdownExpiry.TabIndex = 72;
            _lblBreakdownExpiry.Text = "Breakdown Expiry";
            // 
            // dtpWarrantyExpiry
            // 
            _dtpWarrantyExpiry.Location = new Point(457, 138);
            _dtpWarrantyExpiry.Name = "dtpWarrantyExpiry";
            _dtpWarrantyExpiry.Size = new Size(141, 21);
            _dtpWarrantyExpiry.TabIndex = 69;
            _dtpWarrantyExpiry.Tag = "";
            // 
            // lblWarrantyExpiry
            // 
            _lblWarrantyExpiry.Location = new Point(325, 144);
            _lblWarrantyExpiry.Name = "lblWarrantyExpiry";
            _lblWarrantyExpiry.Size = new Size(105, 20);
            _lblWarrantyExpiry.TabIndex = 70;
            _lblWarrantyExpiry.Text = "Warranty Expiry";
            // 
            // txtLastServiceMileage
            // 
            _txtLastServiceMileage.Location = new Point(489, 18);
            _txtLastServiceMileage.Name = "txtLastServiceMileage";
            _txtLastServiceMileage.Size = new Size(109, 21);
            _txtLastServiceMileage.TabIndex = 10;
            _txtLastServiceMileage.Tag = " ";
            // 
            // lblMileageLastService
            // 
            _lblMileageLastService.Location = new Point(325, 21);
            _lblMileageLastService.Name = "lblMileageLastService";
            _lblMileageLastService.Size = new Size(142, 20);
            _lblMileageLastService.TabIndex = 68;
            _lblMileageLastService.Text = "Mileage at Last Service";
            // 
            // btnNextService
            // 
            _btnNextService.Location = new Point(328, 56);
            _btnNextService.Name = "btnNextService";
            _btnNextService.Size = new Size(270, 21);
            _btnNextService.TabIndex = 12;
            _btnNextService.Text = "Calculate Next Service";
            _btnNextService.UseVisualStyleBackColor = true;
            // 
            // dtpTaxExpiry
            // 
            _dtpTaxExpiry.Location = new Point(120, 138);
            _dtpTaxExpiry.Name = "dtpTaxExpiry";
            _dtpTaxExpiry.Size = new Size(138, 21);
            _dtpTaxExpiry.TabIndex = 15;
            _dtpTaxExpiry.Tag = "Van.InsuranceDue";
            // 
            // lblRoadTax
            // 
            _lblRoadTax.Location = new Point(9, 144);
            _lblRoadTax.Name = "lblRoadTax";
            _lblRoadTax.Size = new Size(84, 20);
            _lblRoadTax.TabIndex = 65;
            _lblRoadTax.Text = "Tax Expiry";
            // 
            // dtpNextServiceDate
            // 
            _dtpNextServiceDate.Location = new Point(120, 54);
            _dtpNextServiceDate.Name = "dtpNextServiceDate";
            _dtpNextServiceDate.Size = new Size(138, 21);
            _dtpNextServiceDate.TabIndex = 11;
            _dtpNextServiceDate.Tag = "Van.InsuranceDue";
            // 
            // lblNextServiceDate
            // 
            _lblNextServiceDate.Location = new Point(9, 60);
            _lblNextServiceDate.Name = "lblNextServiceDate";
            _lblNextServiceDate.Size = new Size(85, 20);
            _lblNextServiceDate.TabIndex = 62;
            _lblNextServiceDate.Text = "Next Service";
            // 
            // dtpLastServiceDate
            // 
            _dtpLastServiceDate.Location = new Point(120, 18);
            _dtpLastServiceDate.Name = "dtpLastServiceDate";
            _dtpLastServiceDate.Size = new Size(138, 21);
            _dtpLastServiceDate.TabIndex = 9;
            _dtpLastServiceDate.Tag = "Van.InsuranceDue";
            // 
            // dtpMOTExpiry
            // 
            _dtpMOTExpiry.Location = new Point(120, 99);
            _dtpMOTExpiry.Name = "dtpMOTExpiry";
            _dtpMOTExpiry.Size = new Size(138, 21);
            _dtpMOTExpiry.TabIndex = 13;
            _dtpMOTExpiry.Tag = "Van.InsuranceDue";
            // 
            // lblMOT
            // 
            _lblMOT.Location = new Point(9, 105);
            _lblMOT.Name = "lblMOT";
            _lblMOT.Size = new Size(84, 20);
            _lblMOT.TabIndex = 58;
            _lblMOT.Text = "MOT Expiry";
            // 
            // txtBreakdown
            // 
            _txtBreakdown.Location = new Point(457, 97);
            _txtBreakdown.Name = "txtBreakdown";
            _txtBreakdown.Size = new Size(141, 21);
            _txtBreakdown.TabIndex = 16;
            _txtBreakdown.Tag = " ";
            // 
            // lblBreakdownCompany
            // 
            _lblBreakdownCompany.Location = new Point(325, 100);
            _lblBreakdownCompany.Name = "lblBreakdownCompany";
            _lblBreakdownCompany.Size = new Size(105, 20);
            _lblBreakdownCompany.TabIndex = 53;
            _lblBreakdownCompany.Text = "Breakdown";
            // 
            // lblLastService
            // 
            _lblLastService.Location = new Point(8, 24);
            _lblLastService.Name = "lblLastService";
            _lblLastService.Size = new Size(85, 20);
            _lblLastService.TabIndex = 31;
            _lblLastService.Text = "Last Service";
            // 
            // grpEngineer
            // 
            _grpEngineer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _grpEngineer.Controls.Add(_cboDepartment);
            _grpEngineer.Controls.Add(_chkEndDate);
            _grpEngineer.Controls.Add(_dtpEndDate);
            _grpEngineer.Controls.Add(_btnRemove);
            _grpEngineer.Controls.Add(_dtpStartDate);
            _grpEngineer.Controls.Add(_lblStartDate);
            _grpEngineer.Controls.Add(_lblDepartment);
            _grpEngineer.Controls.Add(_btnfindEngineer);
            _grpEngineer.Controls.Add(_txtEngineer);
            _grpEngineer.Controls.Add(_lblEngineer);
            _grpEngineer.Location = new Point(8, 524);
            _grpEngineer.Name = "grpEngineer";
            _grpEngineer.Size = new Size(664, 152);
            _grpEngineer.TabIndex = 45;
            _grpEngineer.TabStop = false;
            _grpEngineer.Text = "Engineer";
            // 
            // cboDepartment
            // 
            _cboDepartment.Cursor = Cursors.Hand;
            _cboDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboDepartment.Location = new Point(120, 52);
            _cboDepartment.Name = "cboDepartment";
            _cboDepartment.Size = new Size(146, 21);
            _cboDepartment.TabIndex = 50;
            _cboDepartment.Tag = "";
            // 
            // chkEndDate
            // 
            _chkEndDate.AutoSize = true;
            _chkEndDate.BackColor = SystemColors.Control;
            _chkEndDate.Location = new Point(328, 89);
            _chkEndDate.Name = "chkEndDate";
            _chkEndDate.Size = new Size(78, 17);
            _chkEndDate.TabIndex = 65;
            _chkEndDate.Text = "End Date";
            _chkEndDate.UseVisualStyleBackColor = false;
            // 
            // dtpEndDate
            // 
            _dtpEndDate.Enabled = false;
            _dtpEndDate.Location = new Point(421, 85);
            _dtpEndDate.Name = "dtpEndDate";
            _dtpEndDate.Size = new Size(138, 21);
            _dtpEndDate.TabIndex = 63;
            // 
            // btnRemove
            // 
            _btnRemove.Location = new Point(489, 17);
            _btnRemove.Name = "btnRemove";
            _btnRemove.Size = new Size(75, 23);
            _btnRemove.TabIndex = 62;
            _btnRemove.Text = "Remove";
            _btnRemove.UseVisualStyleBackColor = true;
            // 
            // dtpStartDate
            // 
            _dtpStartDate.Location = new Point(120, 84);
            _dtpStartDate.Name = "dtpStartDate";
            _dtpStartDate.Size = new Size(138, 21);
            _dtpStartDate.TabIndex = 21;
            // 
            // lblStartDate
            // 
            _lblStartDate.Location = new Point(9, 90);
            _lblStartDate.Name = "lblStartDate";
            _lblStartDate.Size = new Size(84, 20);
            _lblStartDate.TabIndex = 58;
            _lblStartDate.Text = "Start Date";
            // 
            // lblDepartment
            // 
            _lblDepartment.Location = new Point(9, 55);
            _lblDepartment.Name = "lblDepartment";
            _lblDepartment.Size = new Size(104, 20);
            _lblDepartment.TabIndex = 55;
            _lblDepartment.Text = "Department";
            // 
            // btnfindEngineer
            // 
            _btnfindEngineer.BackColor = Color.White;
            _btnfindEngineer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnfindEngineer.Location = new Point(337, 19);
            _btnfindEngineer.Name = "btnfindEngineer";
            _btnfindEngineer.Size = new Size(32, 23);
            _btnfindEngineer.TabIndex = 18;
            _btnfindEngineer.Text = "...";
            _btnfindEngineer.UseVisualStyleBackColor = false;
            // 
            // txtEngineer
            // 
            _txtEngineer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtEngineer.Location = new Point(120, 19);
            _txtEngineer.Name = "txtEngineer";
            _txtEngineer.ReadOnly = true;
            _txtEngineer.Size = new Size(201, 21);
            _txtEngineer.TabIndex = 17;
            // 
            // lblEngineer
            // 
            _lblEngineer.Location = new Point(8, 24);
            _lblEngineer.Name = "lblEngineer";
            _lblEngineer.Size = new Size(85, 20);
            _lblEngineer.TabIndex = 31;
            _lblEngineer.Text = "Engineer";
            // 
            // grpVan
            // 
            _grpVan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _grpVan.Controls.Add(_txtTyreSize);
            _grpVan.Controls.Add(_lblTyresSize);
            _grpVan.Controls.Add(_btnRemoveEquipment);
            _grpVan.Controls.Add(_btnAddEquipment);
            _grpVan.Controls.Add(_dgEquipment);
            _grpVan.Controls.Add(_chkReturned);
            _grpVan.Controls.Add(_lblReturned);
            _grpVan.Controls.Add(_txtAverageMileage);
            _grpVan.Controls.Add(_lblAverageMileage);
            _grpVan.Controls.Add(_txtMileage);
            _grpVan.Controls.Add(_lblMileage);
            _grpVan.Controls.Add(_txtModel);
            _grpVan.Controls.Add(_lblMdoel);
            _grpVan.Controls.Add(_cboVanType);
            _grpVan.Controls.Add(_txtMake);
            _grpVan.Controls.Add(_txtRegistration);
            _grpVan.Controls.Add(_lblRegistration);
            _grpVan.Controls.Add(_txtNotes);
            _grpVan.Controls.Add(_lblNotes);
            _grpVan.Controls.Add(_lblInsuranceDue);
            _grpVan.Controls.Add(_lblMake);
            _grpVan.Location = new Point(8, 8);
            _grpVan.Name = "grpVan";
            _grpVan.Size = new Size(664, 288);
            _grpVan.TabIndex = 2;
            _grpVan.TabStop = false;
            _grpVan.Text = "Details";
            // 
            // txtTyreSize
            // 
            _txtTyreSize.Location = new Point(477, 160);
            _txtTyreSize.MaxLength = 10;
            _txtTyreSize.Name = "txtTyreSize";
            _txtTyreSize.Size = new Size(161, 21);
            _txtTyreSize.TabIndex = 48;
            // 
            // lblTyresSize
            // 
            _lblTyresSize.Location = new Point(363, 163);
            _lblTyresSize.Name = "lblTyresSize";
            _lblTyresSize.Size = new Size(81, 20);
            _lblTyresSize.TabIndex = 49;
            _lblTyresSize.Text = "Tyre Size";
            // 
            // btnRemoveEquipment
            // 
            _btnRemoveEquipment.Location = new Point(367, 121);
            _btnRemoveEquipment.Name = "btnRemoveEquipment";
            _btnRemoveEquipment.Size = new Size(75, 23);
            _btnRemoveEquipment.TabIndex = 46;
            _btnRemoveEquipment.Text = "Remove";
            _btnRemoveEquipment.UseVisualStyleBackColor = true;
            // 
            // btnAddEquipment
            // 
            _btnAddEquipment.Location = new Point(563, 121);
            _btnAddEquipment.Name = "btnAddEquipment";
            _btnAddEquipment.Size = new Size(75, 23);
            _btnAddEquipment.TabIndex = 47;
            _btnAddEquipment.Text = "Add";
            _btnAddEquipment.UseVisualStyleBackColor = true;
            // 
            // dgEquipment
            // 
            _dgEquipment.DataMember = "";
            _dgEquipment.HeaderForeColor = SystemColors.ControlText;
            _dgEquipment.Location = new Point(367, 10);
            _dgEquipment.Name = "dgEquipment";
            _dgEquipment.Size = new Size(271, 103);
            _dgEquipment.TabIndex = 44;
            // 
            // chkReturned
            // 
            _chkReturned.AutoSize = true;
            _chkReturned.BackColor = SystemColors.Control;
            _chkReturned.Location = new Point(478, 194);
            _chkReturned.Name = "chkReturned";
            _chkReturned.Size = new Size(34, 17);
            _chkReturned.TabIndex = 7;
            _chkReturned.Text = "  ";
            _chkReturned.UseVisualStyleBackColor = false;
            // 
            // lblReturned
            // 
            _lblReturned.Location = new Point(364, 195);
            _lblReturned.Name = "lblReturned";
            _lblReturned.Size = new Size(81, 20);
            _lblReturned.TabIndex = 43;
            _lblReturned.Text = "Returned";
            // 
            // txtAverageMileage
            // 
            _txtAverageMileage.Enabled = false;
            _txtAverageMileage.Location = new Point(120, 195);
            _txtAverageMileage.MaxLength = 10;
            _txtAverageMileage.Name = "txtAverageMileage";
            _txtAverageMileage.Size = new Size(146, 21);
            _txtAverageMileage.TabIndex = 6;
            // 
            // lblAverageMileage
            // 
            _lblAverageMileage.Location = new Point(6, 198);
            _lblAverageMileage.Name = "lblAverageMileage";
            _lblAverageMileage.Size = new Size(112, 20);
            _lblAverageMileage.TabIndex = 42;
            _lblAverageMileage.Text = "Average Mileage";
            // 
            // txtMileage
            // 
            _txtMileage.Location = new Point(120, 160);
            _txtMileage.MaxLength = 10;
            _txtMileage.Name = "txtMileage";
            _txtMileage.Size = new Size(146, 21);
            _txtMileage.TabIndex = 5;
            // 
            // lblMileage
            // 
            _lblMileage.Location = new Point(6, 163);
            _lblMileage.Name = "lblMileage";
            _lblMileage.Size = new Size(81, 20);
            _lblMileage.TabIndex = 40;
            _lblMileage.Text = "Mileage";
            // 
            // txtModel
            // 
            _txtModel.Enabled = false;
            _txtModel.Location = new Point(120, 125);
            _txtModel.MaxLength = 10;
            _txtModel.Name = "txtModel";
            _txtModel.Size = new Size(146, 21);
            _txtModel.TabIndex = 4;
            // 
            // lblMdoel
            // 
            _lblMdoel.Location = new Point(6, 128);
            _lblMdoel.Name = "lblMdoel";
            _lblMdoel.Size = new Size(81, 20);
            _lblMdoel.TabIndex = 38;
            _lblMdoel.Text = "Model";
            // 
            // cboVanType
            // 
            _cboVanType.Cursor = Cursors.Hand;
            _cboVanType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboVanType.Location = new Point(120, 55);
            _cboVanType.Name = "cboVanType";
            _cboVanType.Size = new Size(146, 21);
            _cboVanType.TabIndex = 2;
            _cboVanType.Tag = "";
            // 
            // txtMake
            // 
            _txtMake.Enabled = false;
            _txtMake.Location = new Point(120, 90);
            _txtMake.MaxLength = 10;
            _txtMake.Name = "txtMake";
            _txtMake.Size = new Size(146, 21);
            _txtMake.TabIndex = 3;
            // 
            // txtRegistration
            // 
            _txtRegistration.Location = new Point(120, 20);
            _txtRegistration.MaxLength = 20;
            _txtRegistration.Name = "txtRegistration";
            _txtRegistration.Size = new Size(146, 21);
            _txtRegistration.TabIndex = 1;
            // 
            // lblRegistration
            // 
            _lblRegistration.Location = new Point(6, 23);
            _lblRegistration.Name = "lblRegistration";
            _lblRegistration.Size = new Size(85, 20);
            _lblRegistration.TabIndex = 31;
            _lblRegistration.Text = "Registration";
            // 
            // txtNotes
            // 
            _txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtNotes.Location = new Point(120, 231);
            _txtNotes.Multiline = true;
            _txtNotes.Name = "txtNotes";
            _txtNotes.ScrollBars = ScrollBars.Vertical;
            _txtNotes.Size = new Size(518, 37);
            _txtNotes.TabIndex = 8;
            _txtNotes.Tag = "Van.Notes";
            // 
            // lblNotes
            // 
            _lblNotes.Location = new Point(6, 234);
            _lblNotes.Name = "lblNotes";
            _lblNotes.Size = new Size(53, 20);
            _lblNotes.TabIndex = 31;
            _lblNotes.Text = "Notes";
            // 
            // lblInsuranceDue
            // 
            _lblInsuranceDue.Location = new Point(6, 58);
            _lblInsuranceDue.Name = "lblInsuranceDue";
            _lblInsuranceDue.Size = new Size(96, 20);
            _lblInsuranceDue.TabIndex = 31;
            _lblInsuranceDue.Text = "Van Type";
            // 
            // lblMake
            // 
            _lblMake.Location = new Point(6, 93);
            _lblMake.Name = "lblMake";
            _lblMake.Size = new Size(81, 20);
            _lblMake.TabIndex = 31;
            _lblMake.Text = "Make";
            // 
            // tcVans
            // 
            _tcVans.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _tcVans.Controls.Add(_tabDetails);
            _tcVans.Controls.Add(_tabFaults);
            _tcVans.Controls.Add(_tabContract);
            _tcVans.Controls.Add(_tabEngineerHistory);
            _tcVans.Controls.Add(_tabServiceHistory);
            _tcVans.Controls.Add(_tabHistory);
            _tcVans.Controls.Add(_tabDocuments);
            _tcVans.Location = new Point(4, 7);
            _tcVans.Name = "tcVans";
            _tcVans.SelectedIndex = 0;
            _tcVans.Size = new Size(683, 728);
            _tcVans.TabIndex = 0;
            // 
            // tabFaults
            // 
            _tabFaults.BackColor = SystemColors.Control;
            _tabFaults.Controls.Add(_chkHideArchive);
            _tabFaults.Controls.Add(_grpFaultDetails);
            _tabFaults.Controls.Add(_grpVanFaultDg);
            _tabFaults.Location = new Point(4, 22);
            _tabFaults.Name = "tabFaults";
            _tabFaults.Size = new Size(675, 702);
            _tabFaults.TabIndex = 2;
            _tabFaults.Text = "Faults";
            // 
            // chkHideArchive
            // 
            _chkHideArchive.AutoSize = true;
            _chkHideArchive.Checked = true;
            _chkHideArchive.CheckState = CheckState.Checked;
            _chkHideArchive.Location = new Point(573, 390);
            _chkHideArchive.Name = "chkHideArchive";
            _chkHideArchive.Size = new Size(98, 17);
            _chkHideArchive.TabIndex = 78;
            _chkHideArchive.Text = "Hide Archive";
            _chkHideArchive.UseVisualStyleBackColor = true;
            // 
            // grpFaultDetails
            // 
            _grpFaultDetails.Controls.Add(_chkArchive);
            _grpFaultDetails.Controls.Add(_txtAdditionalNotes);
            _grpFaultDetails.Controls.Add(_lblAddNotes);
            _grpFaultDetails.Controls.Add(_txtOutcome);
            _grpFaultDetails.Controls.Add(_lblOutcome);
            _grpFaultDetails.Controls.Add(_txtStatus);
            _grpFaultDetails.Controls.Add(_lblVisitStatus);
            _grpFaultDetails.Controls.Add(_txtScheduled);
            _grpFaultDetails.Controls.Add(_lblScheduled);
            _grpFaultDetails.Controls.Add(_txtJobRef);
            _grpFaultDetails.Controls.Add(_lblJobRef);
            _grpFaultDetails.Controls.Add(_btnNewFault);
            _grpFaultDetails.Controls.Add(_btnSaveFault);
            _grpFaultDetails.Controls.Add(_chkResolved);
            _grpFaultDetails.Controls.Add(_dtpResolvedDate);
            _grpFaultDetails.Controls.Add(_lblResolvedDate);
            _grpFaultDetails.Controls.Add(_dtpFaultDate);
            _grpFaultDetails.Controls.Add(_lblFaultDate);
            _grpFaultDetails.Controls.Add(_txtFaultNotes);
            _grpFaultDetails.Controls.Add(_lblFaultNotes);
            _grpFaultDetails.Controls.Add(_cboFaultType);
            _grpFaultDetails.Controls.Add(_txtEngineerFaultNotes);
            _grpFaultDetails.Controls.Add(_lblEngineerNotes);
            _grpFaultDetails.Controls.Add(_lblFaultType);
            _grpFaultDetails.Location = new Point(7, 7);
            _grpFaultDetails.Name = "grpFaultDetails";
            _grpFaultDetails.Size = new Size(664, 375);
            _grpFaultDetails.TabIndex = 16;
            _grpFaultDetails.TabStop = false;
            _grpFaultDetails.Text = "Fault Details";
            // 
            // chkArchive
            // 
            _chkArchive.AutoSize = true;
            _chkArchive.Location = new Point(589, 137);
            _chkArchive.Name = "chkArchive";
            _chkArchive.Size = new Size(69, 17);
            _chkArchive.TabIndex = 77;
            _chkArchive.Text = "Archive";
            _chkArchive.UseVisualStyleBackColor = true;
            // 
            // txtAdditionalNotes
            // 
            _txtAdditionalNotes.Location = new Point(112, 267);
            _txtAdditionalNotes.Multiline = true;
            _txtAdditionalNotes.Name = "txtAdditionalNotes";
            _txtAdditionalNotes.ScrollBars = ScrollBars.Vertical;
            _txtAdditionalNotes.Size = new Size(546, 62);
            _txtAdditionalNotes.TabIndex = 75;
            _txtAdditionalNotes.Tag = "";
            // 
            // lblAddNotes
            // 
            _lblAddNotes.Location = new Point(9, 270);
            _lblAddNotes.Name = "lblAddNotes";
            _lblAddNotes.Size = new Size(103, 20);
            _lblAddNotes.TabIndex = 76;
            _lblAddNotes.Text = "Additional Notes";
            // 
            // txtOutcome
            // 
            _txtOutcome.Location = new Point(401, 168);
            _txtOutcome.Name = "txtOutcome";
            _txtOutcome.ReadOnly = true;
            _txtOutcome.Size = new Size(146, 21);
            _txtOutcome.TabIndex = 74;
            // 
            // lblOutcome
            // 
            _lblOutcome.Location = new Point(298, 171);
            _lblOutcome.Name = "lblOutcome";
            _lblOutcome.Size = new Size(95, 20);
            _lblOutcome.TabIndex = 73;
            _lblOutcome.Text = "Outcome";
            // 
            // txtStatus
            // 
            _txtStatus.Location = new Point(112, 168);
            _txtStatus.Name = "txtStatus";
            _txtStatus.ReadOnly = true;
            _txtStatus.Size = new Size(146, 21);
            _txtStatus.TabIndex = 72;
            // 
            // lblVisitStatus
            // 
            _lblVisitStatus.Location = new Point(9, 171);
            _lblVisitStatus.Name = "lblVisitStatus";
            _lblVisitStatus.Size = new Size(95, 20);
            _lblVisitStatus.TabIndex = 71;
            _lblVisitStatus.Text = "Visit Status";
            // 
            // txtScheduled
            // 
            _txtScheduled.Location = new Point(401, 135);
            _txtScheduled.Name = "txtScheduled";
            _txtScheduled.ReadOnly = true;
            _txtScheduled.Size = new Size(146, 21);
            _txtScheduled.TabIndex = 70;
            // 
            // lblScheduled
            // 
            _lblScheduled.Location = new Point(298, 138);
            _lblScheduled.Name = "lblScheduled";
            _lblScheduled.Size = new Size(95, 20);
            _lblScheduled.TabIndex = 69;
            _lblScheduled.Text = "Scheduled";
            // 
            // txtJobRef
            // 
            _txtJobRef.Location = new Point(112, 135);
            _txtJobRef.Name = "txtJobRef";
            _txtJobRef.ReadOnly = true;
            _txtJobRef.Size = new Size(146, 21);
            _txtJobRef.TabIndex = 68;
            // 
            // lblJobRef
            // 
            _lblJobRef.Location = new Point(9, 138);
            _lblJobRef.Name = "lblJobRef";
            _lblJobRef.Size = new Size(95, 20);
            _lblJobRef.TabIndex = 67;
            _lblJobRef.Text = "Job Reference";
            // 
            // btnNewFault
            // 
            _btnNewFault.Location = new Point(13, 338);
            _btnNewFault.Name = "btnNewFault";
            _btnNewFault.Size = new Size(75, 23);
            _btnNewFault.TabIndex = 7;
            _btnNewFault.Text = "New";
            _btnNewFault.UseVisualStyleBackColor = true;
            // 
            // chkResolved
            // 
            _chkResolved.AutoSize = true;
            _chkResolved.Location = new Point(300, 99);
            _chkResolved.Name = "chkResolved";
            _chkResolved.Size = new Size(78, 17);
            _chkResolved.TabIndex = 4;
            _chkResolved.Text = "Resolved";
            _chkResolved.UseVisualStyleBackColor = true;
            // 
            // dtpResolvedDate
            // 
            _dtpResolvedDate.Enabled = false;
            _dtpResolvedDate.Location = new Point(112, 96);
            _dtpResolvedDate.Name = "dtpResolvedDate";
            _dtpResolvedDate.Size = new Size(146, 21);
            _dtpResolvedDate.TabIndex = 3;
            _dtpResolvedDate.Tag = "";
            // 
            // lblResolvedDate
            // 
            _lblResolvedDate.Location = new Point(9, 102);
            _lblResolvedDate.Name = "lblResolvedDate";
            _lblResolvedDate.Size = new Size(95, 20);
            _lblResolvedDate.TabIndex = 66;
            _lblResolvedDate.Text = "Resolved Date";
            // 
            // dtpFaultDate
            // 
            _dtpFaultDate.Location = new Point(112, 60);
            _dtpFaultDate.Name = "dtpFaultDate";
            _dtpFaultDate.Size = new Size(146, 21);
            _dtpFaultDate.TabIndex = 2;
            _dtpFaultDate.Tag = "";
            // 
            // lblFaultDate
            // 
            _lblFaultDate.Location = new Point(8, 66);
            _lblFaultDate.Name = "lblFaultDate";
            _lblFaultDate.Size = new Size(85, 20);
            _lblFaultDate.TabIndex = 65;
            _lblFaultDate.Text = "Fault Date";
            // 
            // txtFaultNotes
            // 
            _txtFaultNotes.Location = new Point(112, 202);
            _txtFaultNotes.Multiline = true;
            _txtFaultNotes.Name = "txtFaultNotes";
            _txtFaultNotes.ReadOnly = true;
            _txtFaultNotes.ScrollBars = ScrollBars.Vertical;
            _txtFaultNotes.Size = new Size(546, 52);
            _txtFaultNotes.TabIndex = 6;
            _txtFaultNotes.Tag = "";
            // 
            // lblFaultNotes
            // 
            _lblFaultNotes.Location = new Point(10, 205);
            _lblFaultNotes.Name = "lblFaultNotes";
            _lblFaultNotes.Size = new Size(96, 20);
            _lblFaultNotes.TabIndex = 45;
            _lblFaultNotes.Text = "Notes";
            // 
            // cboFaultType
            // 
            _cboFaultType.Cursor = Cursors.Hand;
            _cboFaultType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboFaultType.Location = new Point(112, 27);
            _cboFaultType.Name = "cboFaultType";
            _cboFaultType.Size = new Size(146, 21);
            _cboFaultType.TabIndex = 1;
            _cboFaultType.Tag = "";
            // 
            // txtEngineerFaultNotes
            // 
            _txtEngineerFaultNotes.Location = new Point(401, 27);
            _txtEngineerFaultNotes.Multiline = true;
            _txtEngineerFaultNotes.Name = "txtEngineerFaultNotes";
            _txtEngineerFaultNotes.ScrollBars = ScrollBars.Vertical;
            _txtEngineerFaultNotes.Size = new Size(257, 95);
            _txtEngineerFaultNotes.TabIndex = 5;
            _txtEngineerFaultNotes.Tag = "";
            // 
            // lblEngineerNotes
            // 
            _lblEngineerNotes.Location = new Point(297, 30);
            _lblEngineerNotes.Name = "lblEngineerNotes";
            _lblEngineerNotes.Size = new Size(98, 20);
            _lblEngineerNotes.TabIndex = 31;
            _lblEngineerNotes.Text = "Engineer Notes";
            // 
            // lblFaultType
            // 
            _lblFaultType.Location = new Point(8, 30);
            _lblFaultType.Name = "lblFaultType";
            _lblFaultType.Size = new Size(96, 20);
            _lblFaultType.TabIndex = 31;
            _lblFaultType.Text = "Fault Type";
            // 
            // grpVanFaultDg
            // 
            _grpVanFaultDg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _grpVanFaultDg.Controls.Add(_dgVanFaults);
            _grpVanFaultDg.Location = new Point(11, 413);
            _grpVanFaultDg.Name = "grpVanFaultDg";
            _grpVanFaultDg.Size = new Size(664, 287);
            _grpVanFaultDg.TabIndex = 5;
            _grpVanFaultDg.TabStop = false;
            _grpVanFaultDg.Text = "Van Fault History (Double click to view)";
            // 
            // dgVanFaults
            // 
            _dgVanFaults.DataMember = "";
            _dgVanFaults.Dock = DockStyle.Fill;
            _dgVanFaults.HeaderForeColor = SystemColors.ControlText;
            _dgVanFaults.Location = new Point(3, 17);
            _dgVanFaults.Name = "dgVanFaults";
            _dgVanFaults.Size = new Size(658, 267);
            _dgVanFaults.TabIndex = 15;
            // 
            // tabContract
            // 
            _tabContract.BackColor = SystemColors.Control;
            _tabContract.Controls.Add(_grpFinances);
            _tabContract.Controls.Add(_grpContractDetails);
            _tabContract.Location = new Point(4, 22);
            _tabContract.Name = "tabContract";
            _tabContract.Size = new Size(675, 702);
            _tabContract.TabIndex = 3;
            _tabContract.Text = "Contract";
            // 
            // grpFinances
            // 
            _grpFinances.Controls.Add(_txtForecastExcessCost);
            _grpFinances.Controls.Add(_lblForcastedExcessCost);
            _grpFinances.Controls.Add(_txtExcessMileageCost);
            _grpFinances.Controls.Add(_lblExcessCost);
            _grpFinances.Controls.Add(_txtAnnualRental);
            _grpFinances.Controls.Add(_txtMonthlyRental);
            _grpFinances.Controls.Add(_lblMonthlyRental);
            _grpFinances.Controls.Add(_lblAnnualRental);
            _grpFinances.Controls.Add(_txtWeeklyRental);
            _grpFinances.Controls.Add(_txtExcessMileageRate);
            _grpFinances.Controls.Add(_lblExcessMileageRate);
            _grpFinances.Controls.Add(_lblWeeklyRental);
            _grpFinances.Location = new Point(8, 294);
            _grpFinances.Name = "grpFinances";
            _grpFinances.Size = new Size(664, 138);
            _grpFinances.TabIndex = 75;
            _grpFinances.TabStop = false;
            _grpFinances.Text = "Finances";
            // 
            // txtForecastExcessCost
            // 
            _txtForecastExcessCost.Enabled = false;
            _txtForecastExcessCost.Location = new Point(498, 99);
            _txtForecastExcessCost.MaxLength = 10;
            _txtForecastExcessCost.Name = "txtForecastExcessCost";
            _txtForecastExcessCost.Size = new Size(146, 21);
            _txtForecastExcessCost.TabIndex = 75;
            // 
            // lblForcastedExcessCost
            // 
            _lblForcastedExcessCost.Location = new Point(347, 102);
            _lblForcastedExcessCost.Name = "lblForcastedExcessCost";
            _lblForcastedExcessCost.Size = new Size(145, 20);
            _lblForcastedExcessCost.TabIndex = 76;
            _lblForcastedExcessCost.Text = "Forecast Excess Cost";
            // 
            // txtExcessMileageCost
            // 
            _txtExcessMileageCost.Enabled = false;
            _txtExcessMileageCost.Location = new Point(159, 99);
            _txtExcessMileageCost.MaxLength = 10;
            _txtExcessMileageCost.Name = "txtExcessMileageCost";
            _txtExcessMileageCost.Size = new Size(146, 21);
            _txtExcessMileageCost.TabIndex = 73;
            // 
            // lblExcessCost
            // 
            _lblExcessCost.Location = new Point(8, 102);
            _lblExcessCost.Name = "lblExcessCost";
            _lblExcessCost.Size = new Size(126, 20);
            _lblExcessCost.TabIndex = 74;
            _lblExcessCost.Text = "Excess Mileage Cost";
            // 
            // txtAnnualRental
            // 
            _txtAnnualRental.Location = new Point(498, 60);
            _txtAnnualRental.MaxLength = 10;
            _txtAnnualRental.Name = "txtAnnualRental";
            _txtAnnualRental.Size = new Size(146, 21);
            _txtAnnualRental.TabIndex = 12;
            // 
            // txtMonthlyRental
            // 
            _txtMonthlyRental.Location = new Point(159, 60);
            _txtMonthlyRental.MaxLength = 10;
            _txtMonthlyRental.Name = "txtMonthlyRental";
            _txtMonthlyRental.Size = new Size(146, 21);
            _txtMonthlyRental.TabIndex = 11;
            // 
            // lblMonthlyRental
            // 
            _lblMonthlyRental.Location = new Point(8, 63);
            _lblMonthlyRental.Name = "lblMonthlyRental";
            _lblMonthlyRental.Size = new Size(126, 20);
            _lblMonthlyRental.TabIndex = 72;
            _lblMonthlyRental.Text = "Monthly Rental";
            // 
            // lblAnnualRental
            // 
            _lblAnnualRental.Location = new Point(347, 63);
            _lblAnnualRental.Name = "lblAnnualRental";
            _lblAnnualRental.Size = new Size(126, 20);
            _lblAnnualRental.TabIndex = 69;
            _lblAnnualRental.Text = "Annual Rental";
            // 
            // txtWeeklyRental
            // 
            _txtWeeklyRental.Location = new Point(498, 20);
            _txtWeeklyRental.MaxLength = 10;
            _txtWeeklyRental.Name = "txtWeeklyRental";
            _txtWeeklyRental.Size = new Size(146, 21);
            _txtWeeklyRental.TabIndex = 10;
            // 
            // txtExcessMileageRate
            // 
            _txtExcessMileageRate.Location = new Point(159, 20);
            _txtExcessMileageRate.MaxLength = 20;
            _txtExcessMileageRate.Name = "txtExcessMileageRate";
            _txtExcessMileageRate.Size = new Size(146, 21);
            _txtExcessMileageRate.TabIndex = 9;
            // 
            // lblExcessMileageRate
            // 
            _lblExcessMileageRate.Location = new Point(8, 24);
            _lblExcessMileageRate.Name = "lblExcessMileageRate";
            _lblExcessMileageRate.Size = new Size(126, 20);
            _lblExcessMileageRate.TabIndex = 31;
            _lblExcessMileageRate.Text = "Excess Mileage Rate";
            // 
            // lblWeeklyRental
            // 
            _lblWeeklyRental.Location = new Point(347, 23);
            _lblWeeklyRental.Name = "lblWeeklyRental";
            _lblWeeklyRental.Size = new Size(100, 20);
            _lblWeeklyRental.TabIndex = 31;
            _lblWeeklyRental.Text = "Weekly Rental";
            // 
            // grpContractDetails
            // 
            _grpContractDetails.Controls.Add(_btnRemoveContractEndDate);
            _grpContractDetails.Controls.Add(_txtStartingMileage);
            _grpContractDetails.Controls.Add(_lblStartingMileage);
            _grpContractDetails.Controls.Add(_btnEndContract);
            _grpContractDetails.Controls.Add(_txtContractNotes);
            _grpContractDetails.Controls.Add(_lblContractNotes);
            _grpContractDetails.Controls.Add(_txtAgreementRef);
            _grpContractDetails.Controls.Add(_lblAgreementRef);
            _grpContractDetails.Controls.Add(_txtContractMileage);
            _grpContractDetails.Controls.Add(_lblContractMileage);
            _grpContractDetails.Controls.Add(_dtpContractEnd);
            _grpContractDetails.Controls.Add(_lblContractEnd);
            _grpContractDetails.Controls.Add(_dtpContractStart);
            _grpContractDetails.Controls.Add(_lblContractStart);
            _grpContractDetails.Controls.Add(_cboProcurementMethod);
            _grpContractDetails.Controls.Add(_txtContractLength);
            _grpContractDetails.Controls.Add(_txtLessor);
            _grpContractDetails.Controls.Add(_lblLessor);
            _grpContractDetails.Controls.Add(_lblProcurementMethod);
            _grpContractDetails.Controls.Add(_lblContractLength);
            _grpContractDetails.Location = new Point(8, 3);
            _grpContractDetails.Name = "grpContractDetails";
            _grpContractDetails.Size = new Size(664, 285);
            _grpContractDetails.TabIndex = 3;
            _grpContractDetails.TabStop = false;
            _grpContractDetails.Text = "Details";
            // 
            // btnRemoveContractEndDate
            // 
            _btnRemoveContractEndDate.Location = new Point(433, 100);
            _btnRemoveContractEndDate.Name = "btnRemoveContractEndDate";
            _btnRemoveContractEndDate.Size = new Size(24, 23);
            _btnRemoveContractEndDate.TabIndex = 80;
            _btnRemoveContractEndDate.Text = "X";
            _btnRemoveContractEndDate.UseVisualStyleBackColor = true;
            _btnRemoveContractEndDate.Visible = false;
            // 
            // txtStartingMileage
            // 
            _txtStartingMileage.Location = new Point(498, 142);
            _txtStartingMileage.MaxLength = 10;
            _txtStartingMileage.Name = "txtStartingMileage";
            _txtStartingMileage.Size = new Size(146, 21);
            _txtStartingMileage.TabIndex = 78;
            // 
            // lblStartingMileage
            // 
            _lblStartingMileage.Location = new Point(347, 145);
            _lblStartingMileage.Name = "lblStartingMileage";
            _lblStartingMileage.Size = new Size(126, 20);
            _lblStartingMileage.TabIndex = 79;
            _lblStartingMileage.Text = "Starting Mileage";
            // 
            // btnEndContract
            // 
            _btnEndContract.Location = new Point(498, 99);
            _btnEndContract.Name = "btnEndContract";
            _btnEndContract.Size = new Size(146, 23);
            _btnEndContract.TabIndex = 77;
            _btnEndContract.Text = "End Contract";
            _btnEndContract.UseVisualStyleBackColor = true;
            _btnEndContract.Visible = false;
            // 
            // txtContractNotes
            // 
            _txtContractNotes.Location = new Point(159, 185);
            _txtContractNotes.Multiline = true;
            _txtContractNotes.Name = "txtContractNotes";
            _txtContractNotes.ScrollBars = ScrollBars.Vertical;
            _txtContractNotes.Size = new Size(485, 75);
            _txtContractNotes.TabIndex = 8;
            _txtContractNotes.Tag = "Van.Notes";
            // 
            // lblContractNotes
            // 
            _lblContractNotes.Location = new Point(6, 188);
            _lblContractNotes.Name = "lblContractNotes";
            _lblContractNotes.Size = new Size(53, 20);
            _lblContractNotes.TabIndex = 76;
            _lblContractNotes.Text = "Notes";
            // 
            // txtAgreementRef
            // 
            _txtAgreementRef.Location = new Point(159, 142);
            _txtAgreementRef.MaxLength = 10;
            _txtAgreementRef.Name = "txtAgreementRef";
            _txtAgreementRef.Size = new Size(146, 21);
            _txtAgreementRef.TabIndex = 7;
            // 
            // lblAgreementRef
            // 
            _lblAgreementRef.Location = new Point(8, 145);
            _lblAgreementRef.Name = "lblAgreementRef";
            _lblAgreementRef.Size = new Size(100, 20);
            _lblAgreementRef.TabIndex = 74;
            _lblAgreementRef.Text = "Agreement Ref";
            // 
            // txtContractMileage
            // 
            _txtContractMileage.Location = new Point(498, 62);
            _txtContractMileage.MaxLength = 10;
            _txtContractMileage.Name = "txtContractMileage";
            _txtContractMileage.Size = new Size(146, 21);
            _txtContractMileage.TabIndex = 4;
            // 
            // lblContractMileage
            // 
            _lblContractMileage.Location = new Point(347, 65);
            _lblContractMileage.Name = "lblContractMileage";
            _lblContractMileage.Size = new Size(126, 20);
            _lblContractMileage.TabIndex = 72;
            _lblContractMileage.Text = "Contract Mileage";
            // 
            // dtpContractEnd
            // 
            _dtpContractEnd.Enabled = false;
            _dtpContractEnd.Location = new Point(498, 99);
            _dtpContractEnd.Name = "dtpContractEnd";
            _dtpContractEnd.Size = new Size(146, 21);
            _dtpContractEnd.TabIndex = 6;
            _dtpContractEnd.Tag = "";
            _dtpContractEnd.Visible = false;
            // 
            // lblContractEnd
            // 
            _lblContractEnd.Location = new Point(347, 105);
            _lblContractEnd.Name = "lblContractEnd";
            _lblContractEnd.Size = new Size(95, 20);
            _lblContractEnd.TabIndex = 70;
            _lblContractEnd.Text = "Contract End";
            _lblContractEnd.UseCompatibleTextRendering = true;
            // 
            // dtpContractStart
            // 
            _dtpContractStart.Location = new Point(159, 99);
            _dtpContractStart.Name = "dtpContractStart";
            _dtpContractStart.Size = new Size(146, 21);
            _dtpContractStart.TabIndex = 5;
            _dtpContractStart.Tag = "";
            // 
            // lblContractStart
            // 
            _lblContractStart.Location = new Point(8, 105);
            _lblContractStart.Name = "lblContractStart";
            _lblContractStart.Size = new Size(126, 20);
            _lblContractStart.TabIndex = 69;
            _lblContractStart.Text = "Contract Start";
            // 
            // cboProcurementMethod
            // 
            _cboProcurementMethod.Cursor = Cursors.Hand;
            _cboProcurementMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboProcurementMethod.Location = new Point(498, 20);
            _cboProcurementMethod.Name = "cboProcurementMethod";
            _cboProcurementMethod.Size = new Size(146, 21);
            _cboProcurementMethod.TabIndex = 2;
            _cboProcurementMethod.Tag = "";
            // 
            // txtContractLength
            // 
            _txtContractLength.Location = new Point(159, 59);
            _txtContractLength.MaxLength = 10;
            _txtContractLength.Name = "txtContractLength";
            _txtContractLength.Size = new Size(146, 21);
            _txtContractLength.TabIndex = 3;
            // 
            // txtLessor
            // 
            _txtLessor.Location = new Point(159, 20);
            _txtLessor.MaxLength = 20;
            _txtLessor.Name = "txtLessor";
            _txtLessor.Size = new Size(146, 21);
            _txtLessor.TabIndex = 1;
            // 
            // lblLessor
            // 
            _lblLessor.Location = new Point(8, 24);
            _lblLessor.Name = "lblLessor";
            _lblLessor.Size = new Size(85, 20);
            _lblLessor.TabIndex = 31;
            _lblLessor.Text = "Lessor";
            // 
            // lblProcurementMethod
            // 
            _lblProcurementMethod.Location = new Point(347, 23);
            _lblProcurementMethod.Name = "lblProcurementMethod";
            _lblProcurementMethod.Size = new Size(126, 20);
            _lblProcurementMethod.TabIndex = 31;
            _lblProcurementMethod.Text = "Procurement Method";
            // 
            // lblContractLength
            // 
            _lblContractLength.Location = new Point(8, 62);
            _lblContractLength.Name = "lblContractLength";
            _lblContractLength.Size = new Size(100, 20);
            _lblContractLength.TabIndex = 31;
            _lblContractLength.Text = "Contract Length";
            // 
            // tabEngineerHistory
            // 
            _tabEngineerHistory.Controls.Add(_grpEngineerHistory);
            _tabEngineerHistory.Location = new Point(4, 22);
            _tabEngineerHistory.Name = "tabEngineerHistory";
            _tabEngineerHistory.Size = new Size(675, 702);
            _tabEngineerHistory.TabIndex = 4;
            _tabEngineerHistory.Text = "Engineer History";
            _tabEngineerHistory.UseVisualStyleBackColor = true;
            // 
            // grpEngineerHistory
            // 
            _grpEngineerHistory.Controls.Add(_dgEngineerHistory);
            _grpEngineerHistory.Location = new Point(5, 6);
            _grpEngineerHistory.Name = "grpEngineerHistory";
            _grpEngineerHistory.Size = new Size(664, 801);
            _grpEngineerHistory.TabIndex = 5;
            _grpEngineerHistory.TabStop = false;
            _grpEngineerHistory.Text = "Engineer History";
            // 
            // dgEngineerHistory
            // 
            _dgEngineerHistory.DataMember = "";
            _dgEngineerHistory.Dock = DockStyle.Fill;
            _dgEngineerHistory.HeaderForeColor = SystemColors.ControlText;
            _dgEngineerHistory.Location = new Point(3, 17);
            _dgEngineerHistory.Name = "dgEngineerHistory";
            _dgEngineerHistory.Size = new Size(658, 781);
            _dgEngineerHistory.TabIndex = 15;
            // 
            // tabServiceHistory
            // 
            _tabServiceHistory.Controls.Add(_gpServiceHistory);
            _tabServiceHistory.Location = new Point(4, 22);
            _tabServiceHistory.Name = "tabServiceHistory";
            _tabServiceHistory.Size = new Size(675, 702);
            _tabServiceHistory.TabIndex = 5;
            _tabServiceHistory.Text = "Service History";
            _tabServiceHistory.UseVisualStyleBackColor = true;
            // 
            // gpServiceHistory
            // 
            _gpServiceHistory.Controls.Add(_dgServiceHistory);
            _gpServiceHistory.Location = new Point(5, 6);
            _gpServiceHistory.Name = "gpServiceHistory";
            _gpServiceHistory.Size = new Size(664, 801);
            _gpServiceHistory.TabIndex = 6;
            _gpServiceHistory.TabStop = false;
            _gpServiceHistory.Text = "Service History";
            // 
            // dgServiceHistory
            // 
            _dgServiceHistory.DataMember = "";
            _dgServiceHistory.Dock = DockStyle.Fill;
            _dgServiceHistory.HeaderForeColor = SystemColors.ControlText;
            _dgServiceHistory.Location = new Point(3, 17);
            _dgServiceHistory.Name = "dgServiceHistory";
            _dgServiceHistory.Size = new Size(658, 781);
            _dgServiceHistory.TabIndex = 15;
            // 
            // tabDocuments
            // 
            _tabDocuments.Location = new Point(4, 22);
            _tabDocuments.Name = "tabDocuments";
            _tabDocuments.Size = new Size(675, 702);
            _tabDocuments.TabIndex = 6;
            _tabDocuments.Text = "Documents";
            _tabDocuments.UseVisualStyleBackColor = true;
            // 
            // btnSaveFault
            // 
            _btnSaveFault.Location = new Point(583, 338);
            _btnSaveFault.Name = "btnSaveFault";
            _btnSaveFault.Size = new Size(75, 23);
            _btnSaveFault.TabIndex = 8;
            _btnSaveFault.Text = "Save";
            _btnSaveFault.UseVisualStyleBackColor = true;
            // 
            // UCFleetVan
            // 
            Controls.Add(_tcVans);
            Name = "UCFleetVan";
            Size = new Size(693, 748);
            _tabHistory.ResumeLayout(false);
            _grpHistoryDetails.ResumeLayout(false);
            _grpHistoryDetails.PerformLayout();
            _grpVanAudit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgVanAudits).EndInit();
            _tabDetails.ResumeLayout(false);
            _grpMaintenance.ResumeLayout(false);
            _grpMaintenance.PerformLayout();
            _grpEngineer.ResumeLayout(false);
            _grpEngineer.PerformLayout();
            _grpVan.ResumeLayout(false);
            _grpVan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgEquipment).EndInit();
            _tcVans.ResumeLayout(false);
            _tabFaults.ResumeLayout(false);
            _tabFaults.PerformLayout();
            _grpFaultDetails.ResumeLayout(false);
            _grpFaultDetails.PerformLayout();
            _grpVanFaultDg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgVanFaults).EndInit();
            _tabContract.ResumeLayout(false);
            _grpFinances.ResumeLayout(false);
            _grpFinances.PerformLayout();
            _grpContractDetails.ResumeLayout(false);
            _grpContractDetails.PerformLayout();
            _tabEngineerHistory.ResumeLayout(false);
            _grpEngineerHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgEngineerHistory).EndInit();
            _tabServiceHistory.ResumeLayout(false);
            _gpServiceHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgServiceHistory).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            SetupDGEquipment();
            SetupDGFault();
            SetupDGEngineerHistory();
            SetupDGServiceHistory();
            SetupDGAudit();
        }

        public object LoadedItem
        {
            get
            {
                return CurrentVan;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private UCDocumentsList DocumentsControl;
        private Entity.FleetVans.FleetVan _currentVan;

        public Entity.FleetVans.FleetVan CurrentVan
        {
            get
            {
                return _currentVan;
            }

            set
            {
                _currentVan = value;
                if (_currentVan is null)
                {
                    _currentVan = new Entity.FleetVans.FleetVan();
                }

                if (_currentVan.Exists)
                {
                    PopulateVanEquipmentDatagrid();
                    PopulateEngineerHistoryDatagrid();
                    PopulateVanFaultDatagrid();
                    PopulateServiceDatagrid();
                    PopulateVanAuditDatagrid();
                    DocumentsControl = new UCDocumentsList(Entity.Sys.Enums.TableNames.tblFleetVan, _currentVan.VanID);
                }
                else
                {
                    tcVans.TabPages.Remove(tabFaults);
                    tcVans.TabPages.Remove(tabEngineerHistory);
                    tcVans.TabPages.Remove(tabServiceHistory);
                    tcVans.TabPages.Remove(tabHistory);
                    DocumentsControl = new UCDocumentsList(Entity.Sys.Enums.TableNames.tblFleetVan, App.DB.FleetVan.Get_NextVanID());
                }

                tabDocuments.Controls.Add(DocumentsControl);
            }
        }

        private Entity.FleetVans.FleetVanEngineer _currentVanEngineer;

        public Entity.FleetVans.FleetVanEngineer CurrentVanEngineer
        {
            get
            {
                return _currentVanEngineer;
            }

            set
            {
                _currentVanEngineer = value;
                if (_currentVanEngineer is null)
                {
                    _currentVanEngineer = new Entity.FleetVans.FleetVanEngineer();
                    _currentVanEngineer.Exists = false;
                }
            }
        }

        private Entity.FleetVans.FleetVanMaintenance _currentVanMaintenance;

        public Entity.FleetVans.FleetVanMaintenance CurrentVanMaintenance
        {
            get
            {
                return _currentVanMaintenance;
            }

            set
            {
                _currentVanMaintenance = value;
                if (_currentVanMaintenance is null)
                {
                    _currentVanMaintenance = new Entity.FleetVans.FleetVanMaintenance();
                    _currentVanMaintenance.Exists = false;
                }
            }
        }

        private Entity.FleetVans.FleetVanFault _currentVanFault;

        public Entity.FleetVans.FleetVanFault CurrentVanFault
        {
            get
            {
                return _currentVanFault;
            }

            set
            {
                _currentVanFault = value;
                if (_currentVanFault is null)
                {
                    _currentVanFault = new Entity.FleetVans.FleetVanFault();
                    _currentVanFault.Exists = false;
                }
            }
        }

        private Entity.FleetVans.FleetVanContract _currentContract;

        public Entity.FleetVans.FleetVanContract CurrentContract
        {
            get
            {
                return _currentContract;
            }

            set
            {
                _currentContract = value;
                if (_currentContract is null)
                {
                    _currentContract = new Entity.FleetVans.FleetVanContract();
                    _currentContract.Exists = false;
                }
            }
        }

        private Entity.Engineers.Engineer _engineer;

        public Entity.Engineers.Engineer Engineer
        {
            get
            {
                return _engineer;
            }

            set
            {
                _engineer = value;
                if (_engineer is object)
                {
                    txtEngineer.Text = Engineer.Name;
                }
                else
                {
                    txtEngineer.Text = "<Not Set>";
                }
            }
        }

        private DataView _dvVanEquipment;

        private DataView VanEquipmentDataview
        {
            get
            {
                return _dvVanEquipment;
            }

            set
            {
                _dvVanEquipment = value;
                _dvVanEquipment.AllowNew = false;
                _dvVanEquipment.AllowEdit = false;
                _dvVanEquipment.AllowDelete = false;
                _dvVanEquipment.Table.TableName = Entity.Sys.Enums.TableNames.tblFleetVanEquipment.ToString();
                dgEquipment.DataSource = VanEquipmentDataview;
            }
        }

        private DataRow SelectedEquipmentDataRow
        {
            get
            {
                if (!(dgEquipment.CurrentRowIndex == -1))
                {
                    return VanEquipmentDataview[dgEquipment.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _dvVanFaults;

        private DataView VanFaultDataview
        {
            get
            {
                return _dvVanFaults;
            }

            set
            {
                _dvVanFaults = value;
                _dvVanFaults.AllowNew = false;
                _dvVanFaults.AllowEdit = false;
                _dvVanFaults.AllowDelete = false;
                _dvVanFaults.Table.TableName = Entity.Sys.Enums.TableNames.tblFleetVanFault.ToString();
                dgVanFaults.DataSource = VanFaultDataview;
            }
        }

        private DataRow SelectedFaultDataRow
        {
            get
            {
                if (!(dgVanFaults.CurrentRowIndex == -1))
                {
                    return VanFaultDataview[dgVanFaults.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _dvEngineerHistory;

        private DataView EngineerHistoryDataview
        {
            get
            {
                return _dvEngineerHistory;
            }

            set
            {
                _dvEngineerHistory = value;
                _dvEngineerHistory.AllowNew = false;
                _dvEngineerHistory.AllowEdit = false;
                _dvEngineerHistory.AllowDelete = false;
                _dvEngineerHistory.Table.TableName = Entity.Sys.Enums.TableNames.tblFleetVanEngineer.ToString();
                dgEngineerHistory.DataSource = EngineerHistoryDataview;
            }
        }

        private DataView _jobsTable = null;

        public DataView ServiceDataView
        {
            get
            {
                return _jobsTable;
            }

            set
            {
                _jobsTable = value;
                _jobsTable.Table.TableName = Entity.Sys.Enums.TableNames.tblJob.ToString();
                _jobsTable.AllowNew = false;
                _jobsTable.AllowEdit = false;
                _jobsTable.AllowDelete = false;
                dgServiceHistory.DataSource = ServiceDataView;
            }
        }

        private DataRow SelectedServiceDataRow
        {
            get
            {
                if (!(dgServiceHistory.CurrentRowIndex == -1))
                {
                    return ServiceDataView[dgServiceHistory.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _dvVanAudits;

        private DataView VanAuditsDataview
        {
            get
            {
                return _dvVanAudits;
            }

            set
            {
                _dvVanAudits = value;
                _dvVanAudits.AllowNew = false;
                _dvVanAudits.AllowEdit = false;
                _dvVanAudits.AllowDelete = false;
                _dvVanAudits.Table.TableName = Entity.Sys.Enums.TableNames.tblFleetVanAudit.ToString();
                dgVanAudits.DataSource = VanAuditsDataview;
            }
        }

        private DataRow SelectedVanHistoryDataRow
        {
            get
            {
                if (!(dgVanAudits.CurrentRowIndex == -1))
                {
                    return VanAuditsDataview[dgVanAudits.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private List<int> _equipmentList = new List<int>();

        private List<int> EquipmentList
        {
            get
            {
                return _equipmentList;
            }

            set
            {
                _equipmentList = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void SetupDGEquipment()
        {
            var tStyle = dgEquipment.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var equipmentName = new DataGridLabelColumn();
            equipmentName.Format = "";
            equipmentName.FormatInfo = null;
            equipmentName.HeaderText = "Equipment";
            equipmentName.MappingName = "Name";
            equipmentName.ReadOnly = true;
            equipmentName.Width = 130;
            equipmentName.NullText = "";
            tStyle.GridColumnStyles.Add(equipmentName);
            var addedOn = new DataGridLabelColumn();
            addedOn.Format = "";
            addedOn.FormatInfo = null;
            addedOn.HeaderText = "Added On";
            addedOn.MappingName = "AddedOn";
            addedOn.ReadOnly = true;
            addedOn.Width = 137;
            addedOn.NullText = "";
            tStyle.GridColumnStyles.Add(addedOn);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblFleetVanEquipment.ToString();
            dgEquipment.TableStyles.Add(tStyle);
        }

        public void SetupDGFault()
        {
            var tStyle = dgVanFaults.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var faultType = new DataGridLabelColumn();
            faultType.Format = "";
            faultType.FormatInfo = null;
            faultType.HeaderText = "Fault";
            faultType.MappingName = "Name";
            faultType.ReadOnly = true;
            faultType.Width = 120;
            faultType.NullText = "";
            tStyle.GridColumnStyles.Add(faultType);
            var faultDate = new DataGridLabelColumn();
            faultDate.Format = "dd/MM/yyyy";
            faultDate.FormatInfo = null;
            faultDate.HeaderText = "Fault Date";
            faultDate.MappingName = "FaultDate";
            faultDate.ReadOnly = true;
            faultDate.Width = 100;
            faultDate.NullText = "";
            tStyle.GridColumnStyles.Add(faultDate);
            var resolvedDate = new DataGridLabelColumn();
            resolvedDate.Format = "dd/MM/yyyy";
            resolvedDate.FormatInfo = null;
            resolvedDate.HeaderText = "Resolved Date";
            resolvedDate.MappingName = "ResolvedDate";
            resolvedDate.ReadOnly = true;
            resolvedDate.Width = 100;
            resolvedDate.NullText = "";
            tStyle.GridColumnStyles.Add(resolvedDate);
            var engineerNotes = new DataGridLabelColumn();
            engineerNotes.Format = "";
            engineerNotes.FormatInfo = null;
            engineerNotes.HeaderText = "Engineer Notes";
            engineerNotes.MappingName = "EngineerNotes";
            engineerNotes.ReadOnly = true;
            engineerNotes.Width = 180;
            engineerNotes.NullText = "";
            tStyle.GridColumnStyles.Add(engineerNotes);
            var lastChanged = new DataGridLabelColumn();
            lastChanged.Format = "dd/MM/yyyy";
            lastChanged.FormatInfo = null;
            lastChanged.HeaderText = "Last Changed";
            lastChanged.MappingName = "LastChanged";
            lastChanged.ReadOnly = true;
            lastChanged.Width = 100;
            lastChanged.NullText = "";
            tStyle.GridColumnStyles.Add(lastChanged);
            var changedBy = new DataGridLabelColumn();
            changedBy.Format = "";
            changedBy.FormatInfo = null;
            changedBy.HeaderText = "Changed By";
            changedBy.MappingName = "Fullname";
            changedBy.ReadOnly = true;
            changedBy.Width = 100;
            changedBy.NullText = "";
            tStyle.GridColumnStyles.Add(changedBy);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblFleetVanFault.ToString();
            dgVanFaults.TableStyles.Add(tStyle);
        }

        public void SetupDGEngineerHistory()
        {
            var tStyle = dgEngineerHistory.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var name = new DataGridLabelColumn();
            name.Format = "";
            name.FormatInfo = null;
            name.HeaderText = "Name";
            name.MappingName = "Name";
            name.ReadOnly = true;
            name.Width = 130;
            name.NullText = "";
            tStyle.GridColumnStyles.Add(name);
            var startDate = new DataGridLabelColumn();
            startDate.Format = "dd/MM/yyyy";
            startDate.FormatInfo = null;
            startDate.HeaderText = "From";
            startDate.MappingName = "StartDateTime";
            startDate.ReadOnly = true;
            startDate.Width = 150;
            startDate.NullText = "";
            tStyle.GridColumnStyles.Add(startDate);
            var endDate = new DataGridLabelColumn();
            endDate.Format = "dd/MM/yyyy";
            endDate.FormatInfo = null;
            endDate.HeaderText = "To";
            endDate.MappingName = "EndDateTime";
            endDate.ReadOnly = true;
            endDate.Width = 150;
            endDate.NullText = "";
            tStyle.GridColumnStyles.Add(endDate);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblFleetVanEngineer.ToString();
            dgEngineerHistory.TableStyles.Add(tStyle);
        }

        public void SetupDGServiceHistory()
        {
            var tStyle = dgServiceHistory.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var DateCreated = new DataGridLabelColumn();
            DateCreated.Format = "dd/MM/yyyy";
            DateCreated.FormatInfo = null;
            DateCreated.HeaderText = "Created";
            DateCreated.MappingName = "DateCreated";
            DateCreated.ReadOnly = true;
            DateCreated.Width = 80;
            DateCreated.NullText = "";
            tStyle.GridColumnStyles.Add(DateCreated);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job No";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 75;
            JobNumber.NullText = "";
            tStyle.GridColumnStyles.Add(JobNumber);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 145;
            Type.NullText = Entity.Sys.Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
            tStyle.GridColumnStyles.Add(Type);
            var VisitStatus = new DataGridLabelColumn();
            VisitStatus.Format = "";
            VisitStatus.FormatInfo = null;
            VisitStatus.HeaderText = "Visit Status";
            VisitStatus.MappingName = "VisitStatus";
            VisitStatus.ReadOnly = true;
            VisitStatus.Width = 125;
            VisitStatus.NullText = "";
            tStyle.GridColumnStyles.Add(VisitStatus);
            var VisitOutcome = new DataGridLabelColumn();
            VisitOutcome.Format = "";
            VisitOutcome.FormatInfo = null;
            VisitOutcome.HeaderText = "Outcome";
            VisitOutcome.MappingName = "VisitOutcome";
            VisitOutcome.ReadOnly = true;
            VisitOutcome.Width = 125;
            VisitOutcome.NullText = "";
            tStyle.GridColumnStyles.Add(VisitOutcome);
            var LastVisitDate = new DataGridLabelColumn();
            LastVisitDate.Format = "dd/MM/yyyy";
            LastVisitDate.FormatInfo = null;
            LastVisitDate.HeaderText = "Date";
            LastVisitDate.MappingName = "LastVisitDate";
            LastVisitDate.ReadOnly = true;
            LastVisitDate.Width = 100;
            LastVisitDate.NullText = "";
            tStyle.GridColumnStyles.Add(LastVisitDate);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblJob.ToString();
            dgServiceHistory.TableStyles.Add(tStyle);
        }

        public void SetupDGAudit()
        {
            var tStyle = dgVanAudits.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Action";
            Name.MappingName = "ActionChange";
            Name.ReadOnly = true;
            Name.Width = 350;
            Name.NullText = "";
            tStyle.GridColumnStyles.Add(Name);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Date";
            Site.MappingName = "ActionDateTime";
            Site.ReadOnly = true;
            Site.Width = 100;
            Site.NullText = "";
            tStyle.GridColumnStyles.Add(Site);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "User";
            Type.MappingName = "Fullname";
            Type.ReadOnly = true;
            Type.Width = 200;
            Type.NullText = "";
            tStyle.GridColumnStyles.Add(Type);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblFleetVanAudit.ToString();
            dgVanAudits.TableStyles.Add(tStyle);
        }

        private void UCFleetVan_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void btnEngineerHistory_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMEngineerHistory), true, new object[] { CurrentVan.VanID });
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void Populate(int ID = 0)
        {
            App.ControlLoading = true;
            if (!(ID == 0))
            {
                CurrentVan = App.DB.FleetVan.Get(ID);
                CurrentVanEngineer = App.DB.FleetVanEngineer.Get_ByVanID(CurrentVan.VanID);
                CurrentVanMaintenance = App.DB.FleetVanMaintenance.Get_ByVanID(CurrentVan.VanID);
                CurrentContract = App.DB.FleetVanContract.Get_ByVanID(CurrentVan.VanID);
                RunEstimateUpdates();
                txtRegistration.Text = CurrentVan.Registration;
                var argcombo = cboVanType;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentVan.VanTypeID.ToString());
                var currentVanType = App.DB.FleetVanType.Get(CurrentVan.VanTypeID);
                if (currentVanType is object)
                {
                    txtMake.Text = currentVanType.Make;
                    txtModel.Text = currentVanType.Model;
                }

                txtMileage.Text = CurrentVan.Mileage.ToString();
                txtAverageMileage.Text = CurrentVan.AverageMileage.ToString();
                chkReturned.Checked = CurrentVan.Returned;
                txtNotes.Text = CurrentVan.Notes;
                txtTyreSize.Text = CurrentVan.TyreSize;
                string department = CurrentVan.Department;
                if (CurrentVanEngineer.Exists)
                {
                    Engineer = App.DB.Engineer.Engineer_Get(CurrentVanEngineer.EngineerID);
                    txtEngineer.Text = Engineer.Name;
                    department = Engineer.Department.Trim();
                    dtpStartDate.Value = CurrentVanEngineer.StartDate;
                }
                else
                {
                    txtEngineer.Text = "<Not Set>";
                }

                var argcombo1 = cboDepartment;
                Combo.SetSelectedComboItem_By_Value(ref argcombo1, department);
                if (CurrentVanMaintenance.Exists)
                {
                    {
                        var withBlock = CurrentVanMaintenance;
                        dtpLastServiceDate.Value = withBlock.LastService;
                        dtpNextServiceDate.Value = withBlock.NextService;
                        txtLastServiceMileage.Text = withBlock.LastServiceMileage.ToString();
                        dtpMOTExpiry.Value = withBlock.MOTExpiry;
                        dtpTaxExpiry.Value = withBlock.RoadTaxExpiry;
                        txtBreakdown.Text = withBlock.Breakdown;
                        if (withBlock.WarrantyExpiry != default)
                            dtpWarrantyExpiry.Value = withBlock.WarrantyExpiry;
                        if (withBlock.BreakdownExpiry != default)
                            dtpBreakdownExpiry.Value = withBlock.BreakdownExpiry;
                    }
                }

                if (CurrentContract.Exists)
                {
                    {
                        var withBlock1 = CurrentContract;
                        txtLessor.Text = withBlock1.Lessor;
                        var argcombo2 = cboProcurementMethod;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo2, withBlock1.ProcurementMethod.ToString());
                        if (CurrentContract.ContractEnd != default)
                        {
                            dtpContractEnd.Enabled = true;
                            dtpContractEnd.Visible = true;
                            btnRemoveContractEndDate.Visible = true;
                            btnRemoveContractEndDate.Enabled = true;
                            btnEndContract.Visible = false;
                            btnEndContract.Enabled = false;
                        }
                        else if (withBlock1.ProcurementMethod != (int)Entity.Sys.Enums.FleetVanContractProcurementMethod.Hire)
                        {
                            dtpContractEnd.Enabled = true;
                            dtpContractEnd.Visible = true;
                            btnRemoveContractEndDate.Visible = true;
                            btnRemoveContractEndDate.Enabled = true;
                            btnEndContract.Visible = false;
                            btnEndContract.Enabled = false;
                        }
                        else
                        {
                            dtpContractEnd.Enabled = false;
                            dtpContractEnd.Visible = false;
                            btnRemoveContractEndDate.Visible = false;
                            btnRemoveContractEndDate.Enabled = false;
                            btnEndContract.Visible = true;
                            btnEndContract.Enabled = true;
                        }

                        txtContractLength.Text = withBlock1.ContractLength.ToString();
                        txtContractMileage.Text = withBlock1.ContractMileage.ToString();
                        txtStartingMileage.Text = withBlock1.StartingMileage.ToString();
                        dtpContractStart.Value = withBlock1.ContractStart;
                        if (withBlock1.ContractEnd != default)
                        {
                            dtpContractEnd.Value = withBlock1.ContractEnd;
                        }

                        txtAgreementRef.Text = withBlock1.AgreementRef;
                        txtContractNotes.Text = withBlock1.Notes;
                        txtExcessMileageRate.Text = withBlock1.ExcessMileageRate.ToString();
                        txtWeeklyRental.Text = withBlock1.WeeklyRental.ToString();
                        txtMonthlyRental.Text = withBlock1.MonthlyRental.ToString();
                        txtAnnualRental.Text = withBlock1.AnnualRental.ToString();
                        txtExcessMileageCost.Text = withBlock1.ExcessMileageCost.ToString();
                        txtForecastExcessCost.Text = withBlock1.ForecastExcessMileageCost.ToString();
                    }
                }

                PopulateVanEquipmentDatagrid();
                PopulateEngineerHistoryDatagrid();
                PopulateVanFaultDatagrid();
                PopulateServiceDatagrid();
                PopulateVanAuditDatagrid();
            }

            App.AddChangeHandlers(this);
            App.ControlChanged = false;
            App.ControlLoading = false;
        }

        private void PopulateVanEquipmentDatagrid()
        {
            try
            {
                VanEquipmentDataview = App.DB.FleetVanEquipment.Get_ByVanID(CurrentVan.VanID);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateVanFaultDatagrid()
        {
            try
            {
                VanFaultDataview = App.DB.FleetVanFault.GetAll_ByVanID(CurrentVan.VanID);
                VanFaultDataview.RowFilter = "Archive = 0";
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateServiceDatagrid()
        {
            try
            {
                ServiceDataView = App.DB.FleetVanService.GetServices_ByVanId(CurrentVan.VanID);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateEngineerHistoryDatagrid()
        {
            try
            {
                EngineerHistoryDataview = App.DB.FleetVanEngineer.GetAll_ByVanID(CurrentVan.VanID);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateVanAuditDatagrid()
        {
            try
            {
                VanAuditsDataview = App.DB.FleetVan.VanAudit_Get(CurrentVan.VanID);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Save()
        {
            var sender = new object();
            var e = new EventArgs();
            if (Conversions.ToBoolean(!btnSave_Click(sender, e)))
                return false;
            if (Conversions.ToBoolean(!btnContractSave_Click(sender, e)))
                return false;
            App.MainForm.RefreshEntity(CurrentVan.VanID);
            return default;
        }

        private object btnSave_Click(object sender, EventArgs e)
        {
            var detailsSaved = default(bool);
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentVan.IgnoreExceptionsOnSetMethods = true;
                string change = UpdateVanAudit();
                if (CurrentVan.Exists == false)
                {
                    btnNextService_Click(sender, e);
                }

                {
                    var withBlock = CurrentVan;
                    withBlock.SetRegistration = txtRegistration.Text;
                    withBlock.SetVanTypeID = Combo.get_GetSelectedItemValue(cboVanType);
                    withBlock.SetMileage = Entity.Sys.Helper.MakeIntegerValid(txtMileage.Text);
                    withBlock.SetAverageMileage = Entity.Sys.Helper.MakeIntegerValid(txtAverageMileage.Text);
                    withBlock.SetReturned = chkReturned.Checked;
                    withBlock.SetNotes = txtNotes.Text;
                    withBlock.SetDepartment = Entity.Sys.Helper.MakeStringValid(Combo.get_GetSelectedItemValue(cboDepartment).Trim());
                    withBlock.SetTyreSize = Math.Round(Entity.Sys.Helper.MakeDoubleValid(txtTyreSize.Text), 2).ToString();
                }

                var cV = new Entity.FleetVans.FleetVanValidator();
                cV.Validate(CurrentVan);
                detailsSaved = true;
                if (CurrentVan.Exists)
                {
                    App.DB.FleetVan.Update(CurrentVan);
                }
                else
                {
                    CurrentVan = App.DB.FleetVan.Insert(CurrentVan);
                }

                if (!string.IsNullOrEmpty(change))
                    App.DB.FleetVan.VanAudit_Insert(CurrentVan.VanID, change);
                if (CurrentVan.VanID > 0)
                {
                    if (CurrentVanMaintenance is null)
                    {
                        CurrentVanMaintenance = new Entity.FleetVans.FleetVanMaintenance();
                    }

                    string maintainanceChange = UpdateVanMaintenanceAudit();
                    {
                        var withBlock1 = CurrentVanMaintenance;
                        withBlock1.SetVanID = CurrentVan.VanID;
                        withBlock1.LastService = dtpLastServiceDate.Value;
                        withBlock1.NextService = dtpNextServiceDate.Value;
                        withBlock1.SetLastServiceMileage = Entity.Sys.Helper.MakeIntegerValid(txtLastServiceMileage.Text);
                        withBlock1.MOTExpiry = dtpMOTExpiry.Value;
                        withBlock1.RoadTaxExpiry = dtpTaxExpiry.Value;
                        withBlock1.SetBreakdown = txtBreakdown.Text;
                        withBlock1.BreakdownExpiry = dtpBreakdownExpiry.Value;
                        withBlock1.WarrantyExpiry = dtpWarrantyExpiry.Value;
                    }

                    if (CurrentVanEngineer is null)
                    {
                        CurrentVanEngineer = new Entity.FleetVans.FleetVanEngineer();
                    }

                    string engineerChange = UpdateVanEngineerAudit();
                    {
                        var withBlock2 = CurrentVanEngineer;
                        if (Engineer is null)
                        {
                            withBlock2.SetEngineerID = 0;
                        }
                        else
                        {
                            withBlock2.SetEngineerID = Engineer.EngineerID;
                        }

                        withBlock2.SetVanID = CurrentVan.VanID;
                        withBlock2.StartDate = dtpStartDate.Value.Date;
                        if (chkEndDate.Checked)
                        {
                            withBlock2.EndDate = dtpEndDate.Value.Date;
                        }
                    }

                    var cVE = new Entity.FleetVans.FleetVanEngineerValidator();
                    cVE.Validate(CurrentVanEngineer);
                    if (CurrentVanEngineer.EngineerID > 0)
                    {
                        if (CurrentVanEngineer.Exists)
                        {
                            App.DB.FleetVanEngineer.Update(CurrentVanEngineer);
                        }
                        else
                        {
                            CurrentVanEngineer = App.DB.FleetVanEngineer.Insert(CurrentVanEngineer);
                        }
                    }

                    if (!string.IsNullOrEmpty(engineerChange))
                    {
                        App.DB.FleetVan.VanAudit_Insert(CurrentVan.VanID, engineerChange);
                    }

                    var cVM = new Entity.FleetVans.FleetVanMaintenanceValidator();
                    cVM.Validate(CurrentVanMaintenance);
                    if (CurrentVanMaintenance.Exists)
                    {
                        App.DB.FleetVanMaintenance.Update(CurrentVanMaintenance);
                    }
                    else
                    {
                        CurrentVanMaintenance = App.DB.FleetVanMaintenance.Insert(CurrentVanMaintenance);
                    }

                    if (!string.IsNullOrEmpty(maintainanceChange))
                    {
                        App.DB.FleetVan.VanAudit_Insert(CurrentVan.VanID, maintainanceChange);
                    }
                }

                if (EquipmentList.Count > 0)
                {
                    foreach (int vanEquipmentID in EquipmentList)
                        App.DB.FleetVanEquipment.Update(vanEquipmentID, CurrentVan.VanID);
                }

                return true;
            }
            catch (ValidationException vex)
            {
                if (detailsSaved)
                {
                    string msg = "Main van details have been saved, please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                    msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                    App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    string msg = "Details have NOT been saved, please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                    msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                    App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                return false;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private string UpdateVanAudit()
        {
            // we need to see whats different

            bool update = false;
            string change = "";
            {
                var withBlock = CurrentVan;
                if (withBlock.Exists)
                {
                    if (withBlock.VanTypeID != Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboVanType)))
                    {
                        update = true;
                        var oldVanType = App.DB.FleetVanType.Get(withBlock.VanTypeID);
                        var newVanType = App.DB.FleetVanType.Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboVanType)));
                        change += "Type of van changed from: " + oldVanType.Make + " " + oldVanType.Model + " to: " + newVanType.Make + " " + newVanType.Model;
                    }

                    if (withBlock.Mileage != Conversions.ToDouble(txtMileage.Text))
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        change += "Mileage changed from: " + withBlock.Mileage + " to: " + txtMileage.Text;
                    }

                    if (withBlock.AverageMileage != Conversions.ToDouble(txtAverageMileage.Text))
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        change += "Average Mileage changed from: " + withBlock.AverageMileage + " to: " + txtAverageMileage.Text;
                    }

                    if ((withBlock.Department ?? "") != (Combo.get_GetSelectedItemValue(cboDepartment) ?? ""))
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        change += "Department changed from: " + withBlock.Department + " to: " + Combo.get_GetSelectedItemValue(cboDepartment);
                    }

                    if (withBlock.Returned != chkReturned.Checked)
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        if (withBlock.Returned)
                        {
                            change += "Van has been returned";
                        }
                    }

                    if ((withBlock.Notes ?? "") != (txtNotes.Text ?? ""))
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        change += "Notes were updated";
                    }
                }
            }

            return change;
        }

        private string UpdateVanMaintenanceAudit()
        {
            // we need to see whats different

            bool update = false;
            string change = null;
            {
                var withBlock = CurrentVanMaintenance;
                if (withBlock.Exists)
                {
                    if (withBlock.LastService != dtpLastServiceDate.Value)
                    {
                        update = true;
                        change += "Last service date changed from: " + withBlock.LastService + " to: " + dtpLastServiceDate.Value;
                    }

                    if (withBlock.NextService != dtpNextServiceDate.Value)
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        change += "Next service date changed from: " + withBlock.NextService + " to: " + dtpNextServiceDate.Value;
                    }

                    if (Conversions.ToBoolean(Entity.Sys.Helper.MakeIntegerValid(txtLastServiceMileage.Text)))
                    {
                        if (withBlock.LastServiceMileage != Conversions.ToDouble(txtLastServiceMileage.Text))
                        {
                            if (update)
                            {
                                change += ", ";
                            }

                            update = true;
                            change += "Last service mileage changed from: " + withBlock.LastServiceMileage + " to: " + txtLastServiceMileage.Text;
                        }
                    }
                    else
                    {
                        App.ShowMessage("Last Service requires a numberical value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    if (withBlock.MOTExpiry != dtpMOTExpiry.Value)
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        change += "MOT expiry date changed from: " + withBlock.MOTExpiry + " to: " + dtpMOTExpiry.Value;
                    }

                    if (withBlock.RoadTaxExpiry != dtpTaxExpiry.Value)
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        change += "Road tax expiry date changed from: " + withBlock.RoadTaxExpiry + " to: " + dtpTaxExpiry.Value;
                    }

                    if ((withBlock.Breakdown ?? "") != (txtBreakdown.Text ?? ""))
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        change += "Breakdown provider changed from: " + withBlock.Breakdown + " to: " + txtBreakdown.Text;
                    }
                }
            }

            return change;
        }

        private string UpdateVanEngineerAudit()
        {
            // we need to see whats different

            bool update = false;
            string change = "";
            {
                var withBlock = CurrentVanEngineer;
                if (withBlock.Exists)
                {
                    if (withBlock.EngineerID != Engineer.EngineerID)
                    {
                        update = true;
                        change += "Engineer changed";
                    }

                    if (withBlock.StartDate != dtpStartDate.Value)
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        change += "Start date changed from: " + withBlock.StartDate + " to: " + dtpStartDate.Value;
                    }
                }
            }

            return change;
        }

        private bool btnSaveFault_Click()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (CurrentVanFault is null)
                {
                    CurrentVanFault = new Entity.FleetVans.FleetVanFault();
                }

                CurrentVanFault.IgnoreExceptionsOnSetMethods = true;
                {
                    var withBlock = CurrentVanFault;
                    withBlock.SetFaultTypeID = Combo.get_GetSelectedItemValue(cboFaultType);
                    withBlock.SetVanID = CurrentVan.VanID;
                    withBlock.FaultDate = dtpFaultDate.Value;
                    withBlock.SetArchive = chkArchive.Checked;
                    withBlock.ResolvedDate = Conversions.ToDate(Interaction.IIf(chkResolved.Checked, dtpResolvedDate.Value, null));
                    withBlock.SetEngineerNotes = txtEngineerFaultNotes.Text;
                    if (string.IsNullOrEmpty(txtAdditionalNotes.Text))
                    {
                        withBlock.SetNotes = txtFaultNotes.Text;
                    }
                    else if (string.IsNullOrEmpty(txtFaultNotes.Text))
                    {
                        withBlock.SetNotes = txtAdditionalNotes.Text;
                    }
                    else
                    {
                        withBlock.SetNotes = txtFaultNotes.Text + Constants.vbNewLine + Constants.vbNewLine + txtAdditionalNotes.Text;
                    }
                }

                var cVE = new Entity.FleetVans.FleetVanFaultValidator();
                cVE.Validate(CurrentVanFault);
                if (CurrentVanFault.Exists)
                {
                    App.DB.FleetVanFault.Update(CurrentVanFault);
                }
                else
                {
                    CurrentVanFault = App.DB.FleetVanFault.Insert(CurrentVanFault);
                }

                PopulateVanFaultDatagrid();
                return true;
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private object btnContractSave_Click(object sender, EventArgs e)
        {
            string emsg = "Please ensure the main details are saved first!";
            if (CurrentVan is null)
            {
                App.ShowMessage(emsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!CurrentVan.Exists)
            {
                App.ShowMessage(emsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                if (CurrentContract is null)
                {
                    CurrentContract = new Entity.FleetVans.FleetVanContract();
                }

                string change = UpdateVanContractAudit();
                {
                    var withBlock = CurrentContract;
                    withBlock.IgnoreExceptionsOnSetMethods = true;
                    withBlock.SetVanID = CurrentVan.VanID;
                    withBlock.SetLessor = txtLessor.Text;
                    withBlock.SetProcurementMethod = Combo.get_GetSelectedItemValue(cboProcurementMethod);
                    withBlock.SetContractLength = txtContractLength.Text;
                    withBlock.ContractStart = dtpContractStart.Value;
                    withBlock.ContractEnd = dtpContractEnd.Enabled ? dtpContractEnd.Value : default;
                    withBlock.SetContractMileage = Entity.Sys.Helper.MakeIntegerValid(txtContractMileage.Text);
                    withBlock.SetStartingMileage = Entity.Sys.Helper.MakeIntegerValid(txtStartingMileage.Text);
                    withBlock.SetExcessMileageRate = Entity.Sys.Helper.MakeDoubleValid(txtExcessMileageRate.Text);
                    withBlock.SetWeeklyRental = Entity.Sys.Helper.MakeDoubleValid(txtWeeklyRental.Text);
                    withBlock.SetMonthlyRental = Entity.Sys.Helper.MakeDoubleValid(txtMonthlyRental.Text);
                    withBlock.SetAnnualRental = Entity.Sys.Helper.MakeDoubleValid(txtAnnualRental.Text);
                    withBlock.SetAgreementRef = txtAgreementRef.Text;
                    withBlock.SetNotes = txtContractNotes.Text;
                }

                var cVE = new Entity.FleetVans.FleetVanContractValidator();
                cVE.Validate(CurrentContract);
                if (CurrentContract.Exists)
                {
                    App.DB.FleetVanContract.Update(CurrentContract);
                }
                else
                {
                    CurrentContract = App.DB.FleetVanContract.Insert(CurrentContract);
                }

                if (!string.IsNullOrEmpty(change))
                    App.DB.FleetVan.VanAudit_Insert(CurrentVan.VanID, change);
                return true;
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private string UpdateVanContractAudit()
        {
            // we need to see whats different

            bool update = false;
            string change = "";
            {
                var withBlock = CurrentContract;
                if (withBlock.Exists)
                {
                    if ((withBlock.Lessor ?? "") != (txtLessor.Text ?? ""))
                    {
                        update = true;
                        change += "Lessor changed from: " + withBlock.Lessor + " to: " + txtLessor.Text;
                    }

                    if (Conversions.ToBoolean(Entity.Sys.Helper.MakeIntegerValid(txtContractLength.Text)))
                    {
                        if (withBlock.ContractLength != Conversions.ToDouble(txtContractLength.Text))
                        {
                            if (update)
                            {
                                change += ", ";
                            }

                            update = true;
                            change += "Contract length changed from: " + withBlock.ContractLength + " to: " + txtContractLength.Text;
                        }
                    }
                    else
                    {
                        App.ShowMessage("Contract Length requires a numberical value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

                if (withBlock.ContractStart != dtpContractStart.Value)
                {
                    if (update)
                    {
                        change += ", ";
                    }

                    update = true;
                    change += "Contract start changed from: " + withBlock.ContractStart + " to: " + dtpContractStart.Value;
                }

                if (withBlock.ContractEnd != dtpContractEnd.Value)
                {
                    if (update)
                    {
                        change += ", ";
                    }

                    update = true;
                    change += "Contract end changed from: " + withBlock.ContractEnd + " to: " + dtpContractEnd.Value;
                }

                if (Conversions.ToBoolean(Entity.Sys.Helper.MakeIntegerValid(txtContractMileage.Text)))
                {
                    if (withBlock.ContractMileage != Conversions.ToDouble(txtContractMileage.Text))
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        change += "Contract mileage changed from: " + withBlock.ContractMileage + " to: " + txtContractMileage.Text;
                    }
                }
                else
                {
                    App.ShowMessage("Contract mileage requires a numberical value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                if (Conversions.ToBoolean(Entity.Sys.Helper.MakeIntegerValid(txtStartingMileage.Text)))
                {
                    if (withBlock.StartingMileage != Conversions.ToDouble(txtStartingMileage.Text))
                    {
                        if (update)
                        {
                            change += ", ";
                        }

                        update = true;
                        change += "Contract start mileage changed from: " + withBlock.StartingMileage + " to: " + txtStartingMileage.Text;
                    }
                }
                else
                {
                    App.ShowMessage("Contract mileage requires a numberical value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                if (withBlock.ExcessMileageRate != Conversions.ToDouble(txtExcessMileageRate.Text))
                {
                    if (update)
                    {
                        change += ", ";
                    }

                    update = true;
                    change += "Excess mileage rate changed from: " + withBlock.ExcessMileageRate + " to: " + txtExcessMileageRate.Text;
                }

                if (withBlock.ExcessMileageCost != Conversions.ToDouble(txtExcessMileageCost.Text))
                {
                    if (update)
                    {
                        change += ", ";
                    }

                    update = true;
                    change += "Excess mileage cost changed from: " + withBlock.ExcessMileageCost + " to: " + txtExcessMileageCost.Text;
                }

                if (withBlock.ForecastExcessMileageCost != Conversions.ToDouble(txtForecastExcessCost.Text))
                {
                    if (update)
                    {
                        change += ", ";
                    }

                    update = true;
                    change += "Forecast excess mileage cost changed from: " + withBlock.ForecastExcessMileageCost + " to: " + txtForecastExcessCost.Text;
                }

                if (withBlock.WeeklyRental != Conversions.ToDouble(txtWeeklyRental.Text))
                {
                    if (update)
                    {
                        change += ", ";
                    }

                    update = true;
                    change += "Weekly rental rate changed from: " + withBlock.WeeklyRental + " to: " + txtWeeklyRental.Text;
                }

                if (withBlock.MonthlyRental != Conversions.ToDouble(txtMonthlyRental.Text))
                {
                    if (update)
                    {
                        change += ", ";
                    }

                    update = true;
                    change += "Monthly rental rate changed from: " + withBlock.MonthlyRental + " to: " + txtMonthlyRental.Text;
                }

                if (withBlock.AnnualRental != Conversions.ToDouble(txtAnnualRental.Text))
                {
                    if (update)
                    {
                        change += ", ";
                    }

                    update = true;
                    change += "Annual rental rate changed from: " + withBlock.AnnualRental + " to: " + txtAnnualRental.Text;
                }
            }

            return change;
        }

        private void RunEstimateUpdates()
        {

            // First we need to calculate the average mileage
            // Get the weeks between now and the last service date
            if (!CurrentVanMaintenance.Exists)
            {
                return;
            }

            try
            {
                int weeks = Conversions.ToInteger(DateAndTime.DateDiff(DateInterval.WeekOfYear, CurrentVanMaintenance.LastService, DateTime.Now));
                if (weeks < 1)
                {
                    weeks = 1;
                }

                if (CurrentVan.Mileage < 1)
                {
                    return;
                }

                int mileageDiff = CurrentVan.Mileage - CurrentVanMaintenance.LastServiceMileage;
                var avgMileages = new List<int>();

                // calculate average mileage based on last service
                int currentContractLength = 0;
                double lastServiceAverageMileage = 0;

                // multiple the average mileage by 4
                lastServiceAverageMileage = Math.Round(mileageDiff / (double)weeks * 4.3, MidpointRounding.AwayFromZero);
                CurrentVan.SetAverageMileage = lastServiceAverageMileage;
                if (CurrentContract.Exists)
                {
                    if (CurrentContract.ContractStart < DateTime.Now & CurrentContract.ProcurementMethod != (int)Entity.Sys.Enums.FleetVanContractProcurementMethod.Owned & CurrentContract.ContractLength > 0)
                    {
                        avgMileages.Add(Conversions.ToInteger(lastServiceAverageMileage));

                        // calculate the average mileage over the contract period
                        currentContractLength = Conversions.ToInteger(DateAndTime.DateDiff(DateInterval.WeekOfYear, CurrentContract.ContractStart, DateTime.Now));
                        int mileageFromContractStart = CurrentVan.Mileage - CurrentContract.StartingMileage;
                        if (currentContractLength > 0)
                        {
                            double currentAverageMileageOverContract = Math.Round(mileageFromContractStart / (double)currentContractLength * 4.3, MidpointRounding.AwayFromZero);
                            avgMileages.Add(Conversions.ToInteger(currentAverageMileageOverContract));
                            CurrentVan.SetAverageMileage = Conversions.ToInteger(avgMileages.Average());
                        }
                    }
                }

                var vanType = App.DB.FleetVanType.Get(CurrentVan.VanTypeID);

                // next service based on date
                var nsDate = CurrentVanMaintenance.LastService.AddMonths(vanType.DateServiceInterval);

                // lets see how many months it will take to get to next service mileage
                int avg = (int)(vanType.MileageServiceInterval / (double)CurrentVan.AverageMileage);
                // next service based on mileage
                var nsMileage = CurrentVanMaintenance.LastService.AddMonths(avg);
                if (nsDate < nsMileage)
                {
                    CurrentVanMaintenance.NextService = nsDate;
                }
                else
                {
                    CurrentVanMaintenance.NextService = nsMileage;
                }

                if (CurrentContract.ContractMileage == 0)
                {
                    CurrentContract.SetExcessMileageCost = 0;
                    CurrentContract.SetForecastExcessMileageCost = CurrentContract.ExcessMileageCost;
                    return;
                }

                // calculate the excess mileage cost
                if (CurrentVan.Mileage > CurrentContract.ContractMileage)
                {
                    int contractMileageDiff = CurrentVan.Mileage - CurrentContract.ContractMileage;
                    double excessMileageCost = CurrentContract.ExcessMileageRate * contractMileageDiff;
                    CurrentContract.SetExcessMileageCost = excessMileageCost;
                }
                else
                {
                    CurrentContract.SetExcessMileageCost = 0;
                }

                if (CurrentContract.ContractEnd == default)
                {
                    return;
                }

                // get contract length
                CurrentContract.SetContractLength = DateAndTime.DateDiff(DateInterval.Month, CurrentContract.ContractStart, CurrentContract.ContractEnd);
                int remainingLength = Conversions.ToInteger(Math.Round(CurrentContract.ContractLength - currentContractLength / 4.3));
                double estMileageOverRemainingLength = lastServiceAverageMileage * remainingLength;
                int estContractMileage = (int)(estMileageOverRemainingLength + CurrentVan.Mileage);
                if (estContractMileage > CurrentContract.ContractMileage)
                {
                    int contractMileageDiff = estContractMileage - CurrentContract.ContractMileage;
                    double excessMileageCost = CurrentContract.ExcessMileageRate * contractMileageDiff;
                    CurrentContract.SetForecastExcessMileageCost = Math.Round(excessMileageCost, 2, MidpointRounding.AwayFromZero);
                }
                else
                {
                    CurrentContract.SetForecastExcessMileageCost = CurrentContract.ExcessMileageCost;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnfindEngineer_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblEngineer));
            if (!(ID == 0))
            {
                // temporaily store engineer
                var tempEngineer = App.DB.Engineer.Engineer_Get(ID);
                if (tempEngineer is object)
                {
                    // check to see if vehicle of road
                    if (!(tempEngineer.EngineerID == Entity.Sys.Consts.VOR))
                    {
                        // Lets see if the engineer is assigned to any other van
                        var engineerDv = App.DB.FleetVanEngineer.GetAll_ByEngineerID(tempEngineer.EngineerID);
                        // if count more than 0 then engineer has been assigned to van and cannot have two
                        if (engineerDv.Table.Rows.Count > 0)
                        {
                            var reg = new List<string>();
                            var vanEngineerID = new List<int>();
                            foreach (DataRowView rowView in engineerDv)
                            {
                                var row = rowView.Row;
                                reg.Add(Conversions.ToString(row["Registration"]));
                                vanEngineerID.Add(Conversions.ToInteger(row["VanEngineerID"]));
                            }

                            if (reg.Count > 0)
                            {
                                string regString = string.Join(Environment.NewLine, reg.ToArray());
                                if (App.ShowMessage(tempEngineer.Name + " is currently assigned to the following van(s): " + regString + ", do you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    foreach (int vanId in vanEngineerID)
                                        App.DB.FleetVanEngineer.Delete(vanId);
                                    Engineer = tempEngineer;
                                }
                            }
                        }
                        else
                        {
                            Engineer = tempEngineer;
                        }
                    }
                    else
                    {
                        Engineer = tempEngineer;
                    }
                }
            }
        }

        private void btnNextService_Click(object sender, EventArgs e)
        {
            int lastServiceAverageMileage = 0;
            int mileage = 0;
            int lastServiceMileage = 0;
            var lastServiceDate = dtpLastServiceDate.Value;

            // Using the current mileage, last service mileage and last service date we can calculate the average mileage
            try
            {
                if (txtMileage.Text.Trim().Length < 1)
                {
                    throw new Exception();
                }

                mileage = Conversions.ToInteger(txtMileage.Text);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Please add mileage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (txtLastServiceMileage.Text.Trim().Length < 1)
                {
                    throw new Exception();
                }

                lastServiceMileage = Conversions.ToInteger(txtLastServiceMileage.Text);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Please add last service mileage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // First we need to calculate the average mileage
            // Get the weeks between now and the last service date
            int weeks = Conversions.ToInteger(DateAndTime.DateDiff(DateInterval.WeekOfYear, lastServiceDate, DateTime.Now));
            if (weeks < 1)
            {
                weeks = 1;
            }

            int mileageDiff = mileage - lastServiceMileage;
            var avgMileages = new List<int>();
            lastServiceAverageMileage = Conversions.ToInteger(Math.Round(mileageDiff / (double)weeks * 4.3, MidpointRounding.AwayFromZero));
            txtAverageMileage.Text = lastServiceAverageMileage.ToString();
            if (CurrentContract is object)
            {
                if (CurrentContract.Exists)
                {
                    if (CurrentContract.ContractStart < DateTime.Now & CurrentContract.ProcurementMethod != (int)Entity.Sys.Enums.FleetVanContractProcurementMethod.Owned & CurrentContract.ContractLength > 0)
                    {
                        avgMileages.Add(lastServiceAverageMileage);

                        // calculate the average mileage over the contract period
                        int currentContractLength = 0;
                        currentContractLength = Conversions.ToInteger(DateAndTime.DateDiff(DateInterval.WeekOfYear, CurrentContract.ContractStart, DateTime.Now));
                        int mileageFromContractStart = mileage - Entity.Sys.Helper.MakeIntegerValid(txtStartingMileage.Text);
                        if (currentContractLength > 0)
                        {
                            double currentAverageMileageOverContract = Math.Round(mileageFromContractStart / (double)currentContractLength * 4.3, MidpointRounding.AwayFromZero);
                            avgMileages.Add(Conversions.ToInteger(currentAverageMileageOverContract));
                            txtAverageMileage.Text = Conversions.ToInteger(avgMileages.Average()).ToString();
                        }
                    }
                }
            }

            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboVanType)) == 0)
            {
                App.ShowMessage("Please select van type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var vanType = App.DB.FleetVanType.Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboVanType)));

            // next service based on date
            var nsDate = lastServiceDate.AddMonths(vanType.DateServiceInterval);

            // lets see how many months it will take to get to next service mileage
            if (Conversions.ToInteger(txtAverageMileage.Text) > 0)
            {
                int avg = (int)(vanType.MileageServiceInterval / (double)Conversions.ToInteger(txtAverageMileage.Text));
                // next service based on mileage
                var nsMileage = lastServiceDate.AddMonths(avg);
                if (nsDate < nsMileage)
                {
                    dtpNextServiceDate.Value = nsDate;
                }
                else
                {
                    dtpNextServiceDate.Value = nsMileage;
                }
            }
        }

        private void cboVanType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentVanType = App.DB.FleetVanType.Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboVanType)));
            if (currentVanType is object)
            {
                txtMake.Text = currentVanType.Make;
                txtModel.Text = currentVanType.Model;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // remove engineer from van
            if (CurrentVanEngineer is object)
            {
                if (App.ShowMessage("Are you sure you want to remove " + txtEngineer.Text + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (CurrentVanEngineer.Exists)
                    {
                        DateTime endDate = Conversions.ToDate(Interaction.IIf(chkEndDate.Checked, dtpEndDate.Value.Date, null));
                        App.DB.FleetVanEngineer.Delete(CurrentVanEngineer.VanEngineerID, endDate);
                        CurrentVanEngineer = null;
                        Engineer = null;
                        PopulateEngineerHistoryDatagrid();
                        chkEndDate.Checked = false;
                        dtpStartDate.Value = DateTime.Now;
                        dtpEndDate.Value = DateTime.Now;
                        App.ShowMessage("Engineer has been removed from current van.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        CurrentVanEngineer = null;
                        Engineer = null;
                        PopulateEngineerHistoryDatagrid();
                    }
                }
            }
        }

        private void dgVanFaults_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentVan is null)
                {
                    return;
                }

                if (!CurrentVan.Exists)
                {
                    return;
                }

                if (SelectedFaultDataRow is null)
                {
                    return;
                }

                CurrentVanFault = App.DB.FleetVanFault.Get(Conversions.ToInteger(SelectedFaultDataRow["VanFaultID"]));
                {
                    var withBlock = CurrentVanFault;
                    var argcombo = cboFaultType;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, withBlock.FaultTypeID.ToString());
                    dtpFaultDate.Value = withBlock.FaultDate;
                    chkResolved.Checked = false;
                    chkArchive.Checked = withBlock.Archive;
                    if (withBlock.ResolvedDate != default)
                    {
                        dtpResolvedDate.Value = withBlock.ResolvedDate;
                        chkResolved.Checked = true;
                    }
                    else
                    {
                        dtpResolvedDate.Value = DateAndTime.Now;
                    }

                    dtpResolvedDate.Enabled = chkResolved.Checked;
                    txtEngineerFaultNotes.Text = withBlock.EngineerNotes;
                    txtFaultNotes.Text = withBlock.Notes;
                    txtAdditionalNotes.Text = string.Empty;
                    var job = App.DB.Job.Job_Get(withBlock.JobID);
                    var visit = App.DB.EngineerVisits.EngineerVisits_Get_LastForJob(withBlock.JobID);
                    if (job is object & visit is object)
                    {
                        txtJobRef.Text = job.JobNumber;
                        if (visit.StartDateTime != default)
                        {
                            txtScheduled.Text = visit.StartDateTime.ToShortDateString();
                        }

                        txtStatus.Text = visit.VisitStatus;
                        txtOutcome.Text = visit.VisitOutcome;
                    }
                    else
                    {
                        txtJobRef.Text = "";
                        txtScheduled.Text = "";
                        txtStatus.Text = "";
                        txtOutcome.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error, cannot find fault : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewFault_Click(object sender, EventArgs e)
        {
            var argcombo = cboFaultType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            CurrentVanFault = null;
            dtpFaultDate.Value = DateAndTime.Now;
            dtpResolvedDate.Value = DateAndTime.Now;
            chkResolved.Checked = false;
            chkArchive.Checked = false;
            txtEngineerFaultNotes.Text = string.Empty;
            txtFaultNotes.Text = string.Empty;
            txtJobRef.Text = "";
            txtScheduled.Text = "";
            txtStatus.Text = "";
            txtOutcome.Text = "";
        }

        private void dgServiceHistory_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedServiceDataRow is null)
            {
                return;
            }

            App.ShowForm(typeof(FRMLogCallout), true, new object[] { SelectedServiceDataRow["JobID"], SelectedServiceDataRow["SiteID"], this });
        }

        private void btnRemoveEquipment_Click(object sender, EventArgs e)
        {
            if (App.ShowMessage(Conversions.ToString("Are you sure you want to remove " + SelectedEquipmentDataRow["Name"] + "?"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                App.DB.FleetVanEquipment.Delete(Conversions.ToInteger(SelectedEquipmentDataRow["VanEquipmentID"]));
                PopulateVanEquipmentDatagrid();
            }
        }

        private void btnAddEquipment_Click(object sender, EventArgs e)
        {
            var f = new FRMAddVanEquipment();
            f.ShowDialog();
            if (App.DB.FleetVanEquipment.Check(CurrentVan.VanID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(f.cboEquipment))) == 0)
            {
                int vanEquipmentID = App.DB.FleetVanEquipment.Insert(CurrentVan.VanID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(f.cboEquipment)));
                if (CurrentVan.VanID == 0)
                {
                    EquipmentList.Add(vanEquipmentID);
                }

                PopulateVanEquipmentDatagrid();
            }
            else
            {
                App.ShowMessage("Equipment already assigned to van", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkResolved_CheckedChanged(object sender, EventArgs e)
        {
            dtpResolvedDate.Enabled = chkResolved.Checked;
            if (CurrentVanFault is object)
            {
                if (CurrentVanFault.ResolvedDate == default)
                    dtpResolvedDate.Value = DateAndTime.Now;
            }
            else
            {
                dtpResolvedDate.Value = DateAndTime.Now;
            }
        }

        private void dgVanFaults_DoubleClick(object sender, EventArgs e)
        {
            if (CurrentVanFault.Exists)
            {
                if (CurrentVanFault.JobID > 0)
                {
                    var job = App.DB.Job.Job_Get(CurrentVanFault.JobID);
                    if (job is object)
                    {
                        App.ShowForm(typeof(FRMLogCallout), true, new object[] { job.JobID, job.PropertyID, this });
                    }
                }
            }
        }

        private void txtExcessMileageRate_KeyUp(object sender, KeyEventArgs e)
        {
            if (CurrentContract is object)
            {
                if (CurrentContract.Exists)
                {
                    CurrentContract.SetExcessMileageRate = txtExcessMileageRate.Text;
                    RunEstimateUpdates();
                }
            }
        }

        private void txtWeeklyRental_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double weeklyRental = Conversions.ToDouble(txtWeeklyRental.Text);
                // set monthly and annual rental costs
                txtMonthlyRental.Text = Math.Round(weeklyRental * 4.3, MidpointRounding.AwayFromZero).ToString();
                txtAnnualRental.Text = Math.Round(weeklyRental * 52, MidpointRounding.AwayFromZero).ToString();
            }
            catch (Exception ex)
            {
                App.ShowMessage("Weekly rental in wrong format", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMonthlyRental_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double montlyRental = Conversions.ToDouble(txtMonthlyRental.Text);
                // set weekly and annual rental costs
                txtWeeklyRental.Text = Math.Round(montlyRental / 4.3, MidpointRounding.AwayFromZero).ToString();
                txtAnnualRental.Text = Math.Round(montlyRental * 12, MidpointRounding.AwayFromZero).ToString();
            }
            catch (Exception ex)
            {
                App.ShowMessage("Monthly rental in wrong format", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAnnualRental_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double annualRental = Conversions.ToDouble(txtAnnualRental.Text);
                // set monthly and annual rental costs
                txtWeeklyRental.Text = Math.Round(annualRental / 52, MidpointRounding.AwayFromZero).ToString();
                txtMonthlyRental.Text = Math.Round(annualRental / 12, MidpointRounding.AwayFromZero).ToString();
            }
            catch (Exception ex)
            {
                App.ShowMessage("Annual rental in wrong format", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgVanAudits_Click(object sender, EventArgs e)
        {
            if (SelectedVanHistoryDataRow is object)
            {
                dtpHistoryDate.Value = Conversions.ToDate(SelectedVanHistoryDataRow["ActionDateTime"]);
                txtUsername.Text = Conversions.ToString(SelectedVanHistoryDataRow["Fullname"]);
                txtChange.Text = Conversions.ToString(SelectedVanHistoryDataRow["ActionChange"]);
            }
        }

        private void btnEndContract_Click(object sender, EventArgs e)
        {
            if (App.ShowMessage("End Contract, Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (CurrentContract.Exists)
                {
                    CurrentContract.ContractEnd = DateTime.Now;
                    App.DB.FleetVanContract.Update(CurrentContract);
                    string change = "Contract ended";
                    if (!string.IsNullOrEmpty(change))
                        App.DB.FleetVan.VanAudit_Insert(CurrentVan.VanID, change);
                }
            }
        }

        private void cboProcurementMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboProcurementMethod)) != (double)Entity.Sys.Enums.FleetVanContractProcurementMethod.Hire)
            {
                dtpContractEnd.Enabled = true;
                dtpContractEnd.Visible = true;
                btnEndContract.Visible = false;
                btnEndContract.Enabled = false;
            }
            else
            {
                dtpContractEnd.Enabled = false;
                dtpContractEnd.Visible = false;
                btnEndContract.Visible = true;
                btnEndContract.Enabled = true;
            }

            if (CurrentContract is object)
            {
                if (CurrentContract.ContractEnd != default)
                {
                    dtpContractEnd.Enabled = true;
                    dtpContractEnd.Visible = true;
                    btnEndContract.Visible = false;
                    btnEndContract.Enabled = false;
                }
            }
        }

        private void chkReturned_CheckedChanged(object sender, EventArgs e)
        {
            if (App.ControlLoading)
            {
                return;
            }

            if (chkReturned.Checked)
            {
                if (App.ShowMessage("Return Vehicle? If yes, contract will end today and engineer shall be removed!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (CurrentVanEngineer is object)
                    {
                        if (CurrentVanEngineer.Exists)
                        {
                            App.DB.FleetVanEngineer.Delete(CurrentVanEngineer.VanEngineerID);
                            CurrentVanEngineer = null;
                            Engineer = null;
                        }
                    }

                    if (CurrentContract.Exists)
                    {
                        CurrentContract.ContractEnd = DateTime.Now;
                        App.DB.FleetVanContract.Update(CurrentContract);
                    }

                    App.DB.FleetVan.ReturnVan(CurrentVan.VanID);
                    string change = "Van returned";
                    if (!string.IsNullOrEmpty(change))
                        App.DB.FleetVan.VanAudit_Insert(CurrentVan.VanID, change);
                    Populate(CurrentVan.VanID);
                    Save();
                    App.ControlChanged = false;
                }
                else
                {
                    chkReturned.Checked = false;
                }
            }
        }

        private void chkEndDate_CheckedChanged(object sender, EventArgs e)
        {
            if (App.ControlLoading)
            {
                return;
            }

            if (chkEndDate.Checked)
            {
                dtpEndDate.Enabled = true;
            }
            else
            {
                dtpEndDate.Enabled = false;
            }
        }

        private void chkHideArchive_CheckedChanged(object sender, EventArgs e)
        {
            if (VanFaultDataview is null)
            {
                return;
            }

            VanFaultDataview.RowFilter = Conversions.ToString(Interaction.IIf(chkHideArchive.Checked, "Archive = 0", ""));
        }

        private void btnRemoveContractEndDate_Click(object sender, EventArgs e)
        {
            if (App.ShowMessage("Are you sure you want to remove the contract end date?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                btnRemoveContractEndDate.Visible = false;
                dtpContractEnd.Visible = false;
                dtpContractEnd.Enabled = false;
                btnEndContract.Visible = true;
                btnEndContract.Enabled = true;
            }
        }

        private void btnSaveFault_Click(object sender, EventArgs e)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}