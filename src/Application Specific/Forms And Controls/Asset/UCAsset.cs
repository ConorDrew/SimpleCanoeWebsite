using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCAsset : UCBase, IUserControl
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public UCAsset() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCAsset_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            // Add any initialization after the InitializeComponent() call
            var argc = cboGasType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.GasTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc1 = cboFlueType;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.FlueTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
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

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
        private TabControl _TabControl1;

        internal TabControl TabControl1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabControl1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabControl1 != null)
                {
                }

                _TabControl1 = value;
                if (_TabControl1 != null)
                {
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

        private GroupBox _grpAsset;

        internal GroupBox grpAsset
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpAsset;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpAsset != null)
                {
                }

                _grpAsset = value;
                if (_grpAsset != null)
                {
                }
            }
        }

        private CheckBox _chkDateUnknown;

        internal CheckBox chkDateUnknown
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkDateUnknown;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkDateUnknown != null)
                {
                    _chkDateUnknown.CheckedChanged -= chkDateUnknown_CheckedChanged;
                }

                _chkDateUnknown = value;
                if (_chkDateUnknown != null)
                {
                    _chkDateUnknown.CheckedChanged += chkDateUnknown_CheckedChanged;
                }
            }
        }

        private Label _lblProductID;

        internal Label lblProductID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblProductID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblProductID != null)
                {
                }

                _lblProductID = value;
                if (_lblProductID != null)
                {
                }
            }
        }

        private TextBox _txtSerialNum;

        internal TextBox txtSerialNum
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSerialNum;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSerialNum != null)
                {
                }

                _txtSerialNum = value;
                if (_txtSerialNum != null)
                {
                }
            }
        }

        private Label _lblSerialNum;

        internal Label lblSerialNum
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSerialNum;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSerialNum != null)
                {
                }

                _lblSerialNum = value;
                if (_lblSerialNum != null)
                {
                }
            }
        }

        private Label _lblDateFitted;

        internal Label lblDateFitted
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDateFitted;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDateFitted != null)
                {
                }

                _lblDateFitted = value;
                if (_lblDateFitted != null)
                {
                }
            }
        }

        private Label _lblLocationID;

        internal Label lblLocationID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblLocationID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblLocationID != null)
                {
                }

                _lblLocationID = value;
                if (_lblLocationID != null)
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

        private Panel _pnlDocuments;

        internal Panel pnlDocuments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlDocuments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlDocuments != null)
                {
                }

                _pnlDocuments = value;
                if (_pnlDocuments != null)
                {
                }
            }
        }

        private TextBox _txtLocation;

        internal TextBox txtLocation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtLocation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtLocation != null)
                {
                }

                _txtLocation = value;
                if (_txtLocation != null)
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

        private CheckBox _chkCertificateLastIssuedUnknown;

        internal CheckBox chkCertificateLastIssuedUnknown
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkCertificateLastIssuedUnknown;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkCertificateLastIssuedUnknown != null)
                {
                    _chkCertificateLastIssuedUnknown.CheckedChanged -= chkCertificateLastIssuedUnknown_CheckedChanged;
                }

                _chkCertificateLastIssuedUnknown = value;
                if (_chkCertificateLastIssuedUnknown != null)
                {
                    _chkCertificateLastIssuedUnknown.CheckedChanged += chkCertificateLastIssuedUnknown_CheckedChanged;
                }
            }
        }

        private DateTimePicker _dtpCertificateLastIssued;

        internal DateTimePicker dtpCertificateLastIssued
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpCertificateLastIssued;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpCertificateLastIssued != null)
                {
                }

                _dtpCertificateLastIssued = value;
                if (_dtpCertificateLastIssued != null)
                {
                }
            }
        }

        private TextBox _txtBoughtFrom;

        internal TextBox txtBoughtFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtBoughtFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtBoughtFrom != null)
                {
                }

                _txtBoughtFrom = value;
                if (_txtBoughtFrom != null)
                {
                }
            }
        }

        private TextBox _txtSupplierBy;

        internal TextBox txtSupplierBy
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSupplierBy;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSupplierBy != null)
                {
                }

                _txtSupplierBy = value;
                if (_txtSupplierBy != null)
                {
                }
            }
        }

        private DateTimePicker _dtpDateFitted;

        internal DateTimePicker dtpDateFitted
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpDateFitted;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpDateFitted != null)
                {
                }

                _dtpDateFitted = value;
                if (_dtpDateFitted != null)
                {
                }
            }
        }

        private CheckBox _chkLastServicedDateUnknown;

        internal CheckBox chkLastServicedDateUnknown
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkLastServicedDateUnknown;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkLastServicedDateUnknown != null)
                {
                    _chkLastServicedDateUnknown.CheckedChanged -= chkLastServiceDateUnknown_CheckedChanged;
                }

                _chkLastServicedDateUnknown = value;
                if (_chkLastServicedDateUnknown != null)
                {
                    _chkLastServicedDateUnknown.CheckedChanged += chkLastServiceDateUnknown_CheckedChanged;
                }
            }
        }

        private DateTimePicker _dtpLastServicedDate;

        internal DateTimePicker dtpLastServicedDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpLastServicedDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpLastServicedDate != null)
                {
                }

                _dtpLastServicedDate = value;
                if (_dtpLastServicedDate != null)
                {
                }
            }
        }

        private TabPage _tabJobs;

        internal TabPage tabJobs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabJobs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabJobs != null)
                {
                }

                _tabJobs = value;
                if (_tabJobs != null)
                {
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

        private Button _btnAddJob;

        internal Button btnAddJob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddJob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddJob != null)
                {
                    _btnAddJob.Click -= btnAddJob_Click;
                }

                _btnAddJob = value;
                if (_btnAddJob != null)
                {
                    _btnAddJob.Click += btnAddJob_Click;
                }
            }
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

        private DateTimePicker _dtpWarrantyEndDate;

        internal DateTimePicker dtpWarrantyEndDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpWarrantyEndDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpWarrantyEndDate != null)
                {
                }

                _dtpWarrantyEndDate = value;
                if (_dtpWarrantyEndDate != null)
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

        private CheckBox _chkWarrantyStartDateUnknown;

        internal CheckBox chkWarrantyStartDateUnknown
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkWarrantyStartDateUnknown;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkWarrantyStartDateUnknown != null)
                {
                    _chkWarrantyStartDateUnknown.CheckedChanged -= chkWarrantyStartDateUnknown_CheckedChanged;
                }

                _chkWarrantyStartDateUnknown = value;
                if (_chkWarrantyStartDateUnknown != null)
                {
                    _chkWarrantyStartDateUnknown.CheckedChanged += chkWarrantyStartDateUnknown_CheckedChanged;
                }
            }
        }

        private DateTimePicker _dtpWarrantyStartDate;

        internal DateTimePicker dtpWarrantyStartDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpWarrantyStartDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpWarrantyStartDate != null)
                {
                    _dtpWarrantyStartDate.ValueChanged -= dtpWarrantyStartDate_ValueChanged;
                }

                _dtpWarrantyStartDate = value;
                if (_dtpWarrantyStartDate != null)
                {
                    _dtpWarrantyStartDate.ValueChanged += dtpWarrantyStartDate_ValueChanged;
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

        private TextBox _txtGCNumber;

        internal TextBox txtGCNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtGCNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtGCNumber != null)
                {
                }

                _txtGCNumber = value;
                if (_txtGCNumber != null)
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

        private TextBox _txtYearOfManufacture;

        internal TextBox txtYearOfManufacture
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtYearOfManufacture;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtYearOfManufacture != null)
                {
                }

                _txtYearOfManufacture = value;
                if (_txtYearOfManufacture != null)
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

        private TextBox _txtApproximateValue;

        internal TextBox txtApproximateValue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtApproximateValue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtApproximateValue != null)
                {
                }

                _txtApproximateValue = value;
                if (_txtApproximateValue != null)
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

        private ComboBox _cboGasType;

        internal ComboBox cboGasType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboGasType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboGasType != null)
                {
                }

                _cboGasType = value;
                if (_cboGasType != null)
                {
                }
            }
        }

        private ComboBox _cboFlueType;

        internal ComboBox cboFlueType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFlueType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboFlueType != null)
                {
                }

                _cboFlueType = value;
                if (_cboFlueType != null)
                {
                }
            }
        }

        private Button _btnFindProduct;

        internal Button btnFindProduct
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindProduct;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindProduct != null)
                {
                    _btnFindProduct.Click -= btnFindProduct_Click;
                }

                _btnFindProduct = value;
                if (_btnFindProduct != null)
                {
                    _btnFindProduct.Click += btnFindProduct_Click;
                }
            }
        }

        private TextBox _txtProduct;

        internal TextBox txtProduct
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtProduct;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtProduct != null)
                {
                }

                _txtProduct = value;
                if (_txtProduct != null)
                {
                }
            }
        }

        private CheckBox _chkTenantsAppliance;

        internal CheckBox chkTenantsAppliance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkTenantsAppliance;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkTenantsAppliance != null)
                {
                }

                _chkTenantsAppliance = value;
                if (_chkTenantsAppliance != null)
                {
                }
            }
        }

        private CheckBox _chkActive;

        internal CheckBox chkActive
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkActive;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkActive != null)
                {
                }

                _chkActive = value;
                if (_chkActive != null)
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _TabControl1 = new TabControl();
            _tabDetails = new TabPage();
            _grpAsset = new GroupBox();
            _chkTenantsAppliance = new CheckBox();
            _chkActive = new CheckBox();
            _btnFindProduct = new Button();
            _btnFindProduct.Click += new EventHandler(btnFindProduct_Click);
            _txtProduct = new TextBox();
            _cboFlueType = new ComboBox();
            _Label11 = new Label();
            _cboGasType = new ComboBox();
            _Label10 = new Label();
            _txtApproximateValue = new TextBox();
            _Label9 = new Label();
            _txtYearOfManufacture = new TextBox();
            _Label8 = new Label();
            _txtGCNumber = new TextBox();
            _Label7 = new Label();
            _dtpWarrantyEndDate = new DateTimePicker();
            _Label5 = new Label();
            _chkWarrantyStartDateUnknown = new CheckBox();
            _chkWarrantyStartDateUnknown.CheckedChanged += new EventHandler(chkWarrantyStartDateUnknown_CheckedChanged);
            _dtpWarrantyStartDate = new DateTimePicker();
            _dtpWarrantyStartDate.ValueChanged += new EventHandler(dtpWarrantyStartDate_ValueChanged);
            _Label6 = new Label();
            _chkLastServicedDateUnknown = new CheckBox();
            _chkLastServicedDateUnknown.CheckedChanged += new EventHandler(chkLastServiceDateUnknown_CheckedChanged);
            _dtpLastServicedDate = new DateTimePicker();
            _Label4 = new Label();
            _chkCertificateLastIssuedUnknown = new CheckBox();
            _chkCertificateLastIssuedUnknown.CheckedChanged += new EventHandler(chkCertificateLastIssuedUnknown_CheckedChanged);
            _dtpCertificateLastIssued = new DateTimePicker();
            _Label3 = new Label();
            _txtBoughtFrom = new TextBox();
            _Label2 = new Label();
            _txtSupplierBy = new TextBox();
            _Label1 = new Label();
            _txtLocation = new TextBox();
            _chkDateUnknown = new CheckBox();
            _chkDateUnknown.CheckedChanged += new EventHandler(chkDateUnknown_CheckedChanged);
            _lblProductID = new Label();
            _txtSerialNum = new TextBox();
            _lblSerialNum = new Label();
            _dtpDateFitted = new DateTimePicker();
            _lblDateFitted = new Label();
            _lblLocationID = new Label();
            _txtNotes = new TextBox();
            _lblNotes = new Label();
            _tabDocuments = new TabPage();
            _pnlDocuments = new Panel();
            _tabJobs = new TabPage();
            _grpJobs = new GroupBox();
            _btnAddJob = new Button();
            _btnAddJob.Click += new EventHandler(btnAddJob_Click);
            _dgJobs = new DataGrid();
            _dgJobs.DoubleClick += new EventHandler(dgJobs_DoubleClick);
            _TabControl1.SuspendLayout();
            _tabDetails.SuspendLayout();
            _grpAsset.SuspendLayout();
            _tabDocuments.SuspendLayout();
            _tabJobs.SuspendLayout();
            _grpJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgJobs).BeginInit();
            SuspendLayout();
            //
            // TabControl1
            //
            _TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _TabControl1.Controls.Add(_tabDetails);
            _TabControl1.Controls.Add(_tabDocuments);
            _TabControl1.Controls.Add(_tabJobs);
            _TabControl1.Location = new Point(1, 4);
            _TabControl1.Name = "TabControl1";
            _TabControl1.SelectedIndex = 0;
            _TabControl1.Size = new Size(788, 582);
            _TabControl1.TabIndex = 0;
            //
            // tabDetails
            //
            _tabDetails.Controls.Add(_grpAsset);
            _tabDetails.Location = new Point(4, 22);
            _tabDetails.Name = "tabDetails";
            _tabDetails.Size = new Size(780, 556);
            _tabDetails.TabIndex = 0;
            _tabDetails.Text = "Main Details";
            //
            // grpAsset
            //
            _grpAsset.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpAsset.Controls.Add(_chkTenantsAppliance);
            _grpAsset.Controls.Add(_chkActive);
            _grpAsset.Controls.Add(_btnFindProduct);
            _grpAsset.Controls.Add(_txtProduct);
            _grpAsset.Controls.Add(_cboFlueType);
            _grpAsset.Controls.Add(_Label11);
            _grpAsset.Controls.Add(_cboGasType);
            _grpAsset.Controls.Add(_Label10);
            _grpAsset.Controls.Add(_txtApproximateValue);
            _grpAsset.Controls.Add(_Label9);
            _grpAsset.Controls.Add(_txtYearOfManufacture);
            _grpAsset.Controls.Add(_Label8);
            _grpAsset.Controls.Add(_txtGCNumber);
            _grpAsset.Controls.Add(_Label7);
            _grpAsset.Controls.Add(_dtpWarrantyEndDate);
            _grpAsset.Controls.Add(_Label5);
            _grpAsset.Controls.Add(_chkWarrantyStartDateUnknown);
            _grpAsset.Controls.Add(_dtpWarrantyStartDate);
            _grpAsset.Controls.Add(_Label6);
            _grpAsset.Controls.Add(_chkLastServicedDateUnknown);
            _grpAsset.Controls.Add(_dtpLastServicedDate);
            _grpAsset.Controls.Add(_Label4);
            _grpAsset.Controls.Add(_chkCertificateLastIssuedUnknown);
            _grpAsset.Controls.Add(_dtpCertificateLastIssued);
            _grpAsset.Controls.Add(_Label3);
            _grpAsset.Controls.Add(_txtBoughtFrom);
            _grpAsset.Controls.Add(_Label2);
            _grpAsset.Controls.Add(_txtSupplierBy);
            _grpAsset.Controls.Add(_Label1);
            _grpAsset.Controls.Add(_txtLocation);
            _grpAsset.Controls.Add(_chkDateUnknown);
            _grpAsset.Controls.Add(_lblProductID);
            _grpAsset.Controls.Add(_txtSerialNum);
            _grpAsset.Controls.Add(_lblSerialNum);
            _grpAsset.Controls.Add(_dtpDateFitted);
            _grpAsset.Controls.Add(_lblDateFitted);
            _grpAsset.Controls.Add(_lblLocationID);
            _grpAsset.Controls.Add(_txtNotes);
            _grpAsset.Controls.Add(_lblNotes);
            _grpAsset.Location = new Point(11, 6);
            _grpAsset.Name = "grpAsset";
            _grpAsset.Size = new Size(762, 542);
            _grpAsset.TabIndex = 0;
            _grpAsset.TabStop = false;
            _grpAsset.Text = "Details";
            //
            // chkTenantsAppliance
            //
            _chkTenantsAppliance.Location = new Point(217, 426);
            _chkTenantsAppliance.Name = "chkTenantsAppliance";
            _chkTenantsAppliance.Size = new Size(140, 24);
            _chkTenantsAppliance.TabIndex = 39;
            _chkTenantsAppliance.Text = "Tenants Appliance";
            //
            // chkActive
            //
            _chkActive.Checked = true;
            _chkActive.CheckState = CheckState.Checked;
            _chkActive.Location = new Point(152, 426);
            _chkActive.Name = "chkActive";
            _chkActive.Size = new Size(88, 24);
            _chkActive.TabIndex = 38;
            _chkActive.Text = "Active";
            //
            // btnFindProduct
            //
            _btnFindProduct.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindProduct.Location = new Point(727, 18);
            _btnFindProduct.Name = "btnFindProduct";
            _btnFindProduct.Size = new Size(29, 23);
            _btnFindProduct.TabIndex = 37;
            _btnFindProduct.Text = "...";
            _btnFindProduct.UseVisualStyleBackColor = true;
            //
            // txtProduct
            //
            _txtProduct.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtProduct.Location = new Point(152, 20);
            _txtProduct.Name = "txtProduct";
            _txtProduct.ReadOnly = true;
            _txtProduct.Size = new Size(569, 21);
            _txtProduct.TabIndex = 36;
            //
            // cboFlueType
            //
            _cboFlueType.Cursor = Cursors.Hand;
            _cboFlueType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboFlueType.Location = new Point(152, 128);
            _cboFlueType.Name = "cboFlueType";
            _cboFlueType.Size = new Size(174, 21);
            _cboFlueType.TabIndex = 9;
            _cboFlueType.Tag = "";
            //
            // Label11
            //
            _Label11.Location = new Point(9, 129);
            _Label11.Name = "Label11";
            _Label11.Size = new Size(128, 20);
            _Label11.TabIndex = 8;
            _Label11.Text = "Flue Type";
            //
            // cboGasType
            //
            _cboGasType.Cursor = Cursors.Hand;
            _cboGasType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboGasType.Location = new Point(152, 155);
            _cboGasType.Name = "cboGasType";
            _cboGasType.Size = new Size(174, 21);
            _cboGasType.TabIndex = 11;
            _cboGasType.Tag = "";
            //
            // Label10
            //
            _Label10.Location = new Point(9, 158);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(128, 20);
            _Label10.TabIndex = 10;
            _Label10.Text = "Fuel Type";
            //
            // txtApproximateValue
            //
            _txtApproximateValue.Location = new Point(152, 399);
            _txtApproximateValue.MaxLength = 100;
            _txtApproximateValue.Name = "txtApproximateValue";
            _txtApproximateValue.Size = new Size(174, 21);
            _txtApproximateValue.TabIndex = 33;
            //
            // Label9
            //
            _Label9.Location = new Point(9, 402);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(128, 20);
            _Label9.TabIndex = 32;
            _Label9.Text = "Approximate Value";
            //
            // txtYearOfManufacture
            //
            _txtYearOfManufacture.Location = new Point(152, 372);
            _txtYearOfManufacture.MaxLength = 100;
            _txtYearOfManufacture.Name = "txtYearOfManufacture";
            _txtYearOfManufacture.Size = new Size(174, 21);
            _txtYearOfManufacture.TabIndex = 31;
            //
            // Label8
            //
            _Label8.Location = new Point(9, 375);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(133, 20);
            _Label8.TabIndex = 30;
            _Label8.Text = "Year Of Manufacture";
            //
            // txtGCNumber
            //
            _txtGCNumber.Location = new Point(152, 74);
            _txtGCNumber.MaxLength = 100;
            _txtGCNumber.Name = "txtGCNumber";
            _txtGCNumber.ReadOnly = true;
            _txtGCNumber.Size = new Size(174, 21);
            _txtGCNumber.TabIndex = 5;
            //
            // Label7
            //
            _Label7.Location = new Point(9, 77);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(117, 20);
            _Label7.TabIndex = 4;
            _Label7.Text = "GC Number";
            //
            // dtpWarrantyEndDate
            //
            _dtpWarrantyEndDate.Location = new Point(152, 291);
            _dtpWarrantyEndDate.Name = "dtpWarrantyEndDate";
            _dtpWarrantyEndDate.Size = new Size(174, 21);
            _dtpWarrantyEndDate.TabIndex = 25;
            _dtpWarrantyEndDate.Tag = "Asset.WarrantyEndDate";
            //
            // Label5
            //
            _Label5.Location = new Point(9, 295);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(125, 20);
            _Label5.TabIndex = 24;
            _Label5.Text = "Warranty End Date";
            //
            // chkWarrantyStartDateUnknown
            //
            _chkWarrantyStartDateUnknown.Location = new Point(343, 268);
            _chkWarrantyStartDateUnknown.Name = "chkWarrantyStartDateUnknown";
            _chkWarrantyStartDateUnknown.Size = new Size(88, 24);
            _chkWarrantyStartDateUnknown.TabIndex = 23;
            _chkWarrantyStartDateUnknown.Text = "Unknown";
            //
            // dtpWarrantyStartDate
            //
            _dtpWarrantyStartDate.Location = new Point(152, 264);
            _dtpWarrantyStartDate.Name = "dtpWarrantyStartDate";
            _dtpWarrantyStartDate.Size = new Size(174, 21);
            _dtpWarrantyStartDate.TabIndex = 22;
            _dtpWarrantyStartDate.Tag = "Asset.WarrantyStartDate";
            //
            // Label6
            //
            _Label6.Location = new Point(9, 268);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(141, 20);
            _Label6.TabIndex = 21;
            _Label6.Text = "Warranty Start Date";
            //
            // chkLastServicedDateUnknown
            //
            _chkLastServicedDateUnknown.Location = new Point(343, 209);
            _chkLastServicedDateUnknown.Name = "chkLastServicedDateUnknown";
            _chkLastServicedDateUnknown.Size = new Size(88, 24);
            _chkLastServicedDateUnknown.TabIndex = 17;
            _chkLastServicedDateUnknown.Text = "Unknown";
            //
            // dtpLastServicedDate
            //
            _dtpLastServicedDate.Location = new Point(152, 210);
            _dtpLastServicedDate.Name = "dtpLastServicedDate";
            _dtpLastServicedDate.Size = new Size(174, 21);
            _dtpLastServicedDate.TabIndex = 16;
            _dtpLastServicedDate.Tag = "Asset.LastServicedDate";
            //
            // Label4
            //
            _Label4.Location = new Point(9, 214);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(125, 20);
            _Label4.TabIndex = 15;
            _Label4.Text = "Last Serviced Date";
            //
            // chkCertificateLastIssuedUnknown
            //
            _chkCertificateLastIssuedUnknown.Location = new Point(343, 182);
            _chkCertificateLastIssuedUnknown.Name = "chkCertificateLastIssuedUnknown";
            _chkCertificateLastIssuedUnknown.Size = new Size(88, 24);
            _chkCertificateLastIssuedUnknown.TabIndex = 14;
            _chkCertificateLastIssuedUnknown.Text = "Unknown";
            //
            // dtpCertificateLastIssued
            //
            _dtpCertificateLastIssued.Location = new Point(152, 183);
            _dtpCertificateLastIssued.Name = "dtpCertificateLastIssued";
            _dtpCertificateLastIssued.Size = new Size(174, 21);
            _dtpCertificateLastIssued.TabIndex = 13;
            _dtpCertificateLastIssued.Tag = "Asset.CertificateLastIssued";
            //
            // Label3
            //
            _Label3.Location = new Point(9, 187);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(141, 20);
            _Label3.TabIndex = 12;
            _Label3.Text = "Certificate Last Issued";
            //
            // txtBoughtFrom
            //
            _txtBoughtFrom.Location = new Point(152, 318);
            _txtBoughtFrom.MaxLength = 100;
            _txtBoughtFrom.Name = "txtBoughtFrom";
            _txtBoughtFrom.Size = new Size(174, 21);
            _txtBoughtFrom.TabIndex = 27;
            //
            // Label2
            //
            _Label2.Location = new Point(9, 321);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(117, 20);
            _Label2.TabIndex = 26;
            _Label2.Text = "Gasway Ref";
            //
            // txtSupplierBy
            //
            _txtSupplierBy.Location = new Point(152, 345);
            _txtSupplierBy.MaxLength = 100;
            _txtSupplierBy.Name = "txtSupplierBy";
            _txtSupplierBy.Size = new Size(174, 21);
            _txtSupplierBy.TabIndex = 29;
            //
            // Label1
            //
            _Label1.Location = new Point(9, 348);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(117, 20);
            _Label1.TabIndex = 28;
            _Label1.Text = "Supplied By";
            //
            // txtLocation
            //
            _txtLocation.Location = new Point(152, 47);
            _txtLocation.Name = "txtLocation";
            _txtLocation.Size = new Size(174, 21);
            _txtLocation.TabIndex = 3;
            //
            // chkDateUnknown
            //
            _chkDateUnknown.Location = new Point(343, 235);
            _chkDateUnknown.Name = "chkDateUnknown";
            _chkDateUnknown.Size = new Size(88, 24);
            _chkDateUnknown.TabIndex = 20;
            _chkDateUnknown.Text = "Unknown";
            //
            // lblProductID
            //
            _lblProductID.Location = new Point(9, 23);
            _lblProductID.Name = "lblProductID";
            _lblProductID.Size = new Size(109, 20);
            _lblProductID.TabIndex = 0;
            _lblProductID.Text = "Product";
            //
            // txtSerialNum
            //
            _txtSerialNum.Location = new Point(152, 101);
            _txtSerialNum.MaxLength = 50;
            _txtSerialNum.Name = "txtSerialNum";
            _txtSerialNum.Size = new Size(174, 21);
            _txtSerialNum.TabIndex = 7;
            _txtSerialNum.Tag = "Asset.SerialNum";
            //
            // lblSerialNum
            //
            _lblSerialNum.Location = new Point(9, 101);
            _lblSerialNum.Name = "lblSerialNum";
            _lblSerialNum.Size = new Size(133, 20);
            _lblSerialNum.TabIndex = 6;
            _lblSerialNum.Text = "Serial";
            //
            // dtpDateFitted
            //
            _dtpDateFitted.Location = new Point(152, 237);
            _dtpDateFitted.Name = "dtpDateFitted";
            _dtpDateFitted.Size = new Size(174, 21);
            _dtpDateFitted.TabIndex = 19;
            _dtpDateFitted.Tag = "Asset.DateFitted";
            //
            // lblDateFitted
            //
            _lblDateFitted.Location = new Point(9, 239);
            _lblDateFitted.Name = "lblDateFitted";
            _lblDateFitted.Size = new Size(125, 20);
            _lblDateFitted.TabIndex = 18;
            _lblDateFitted.Text = "Date Fitted";
            //
            // lblLocationID
            //
            _lblLocationID.Location = new Point(9, 50);
            _lblLocationID.Name = "lblLocationID";
            _lblLocationID.Size = new Size(117, 20);
            _lblLocationID.TabIndex = 2;
            _lblLocationID.Text = "Location";
            //
            // txtNotes
            //
            _txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtNotes.Location = new Point(152, 456);
            _txtNotes.Multiline = true;
            _txtNotes.Name = "txtNotes";
            _txtNotes.ScrollBars = ScrollBars.Vertical;
            _txtNotes.Size = new Size(600, 77);
            _txtNotes.TabIndex = 35;
            _txtNotes.Tag = "Asset.Notes";
            //
            // lblNotes
            //
            _lblNotes.Location = new Point(9, 456);
            _lblNotes.Name = "lblNotes";
            _lblNotes.Size = new Size(101, 20);
            _lblNotes.TabIndex = 34;
            _lblNotes.Text = "Notes";
            //
            // tabDocuments
            //
            _tabDocuments.Controls.Add(_pnlDocuments);
            _tabDocuments.Location = new Point(4, 22);
            _tabDocuments.Name = "tabDocuments";
            _tabDocuments.Size = new Size(780, 556);
            _tabDocuments.TabIndex = 1;
            _tabDocuments.Text = "Documents";
            //
            // pnlDocuments
            //
            _pnlDocuments.Dock = DockStyle.Fill;
            _pnlDocuments.Location = new Point(0, 0);
            _pnlDocuments.Name = "pnlDocuments";
            _pnlDocuments.Size = new Size(780, 556);
            _pnlDocuments.TabIndex = 0;
            //
            // tabJobs
            //
            _tabJobs.Controls.Add(_grpJobs);
            _tabJobs.Location = new Point(4, 22);
            _tabJobs.Name = "tabJobs";
            _tabJobs.Size = new Size(780, 556);
            _tabJobs.TabIndex = 2;
            _tabJobs.Text = "Jobs";
            //
            // grpJobs
            //
            _grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpJobs.Controls.Add(_btnAddJob);
            _grpJobs.Controls.Add(_dgJobs);
            _grpJobs.Location = new Point(7, 9);
            _grpJobs.Name = "grpJobs";
            _grpJobs.Size = new Size(768, 542);
            _grpJobs.TabIndex = 1;
            _grpJobs.TabStop = false;
            _grpJobs.Text = "Jobs";
            //
            // btnAddJob
            //
            _btnAddJob.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAddJob.Location = new Point(8, 514);
            _btnAddJob.Name = "btnAddJob";
            _btnAddJob.Size = new Size(75, 23);
            _btnAddJob.TabIndex = 2;
            _btnAddJob.Text = "Add Job";
            //
            // dgJobs
            //
            _dgJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgJobs.DataMember = "";
            _dgJobs.HeaderForeColor = SystemColors.ControlText;
            _dgJobs.Location = new Point(8, 20);
            _dgJobs.Name = "dgJobs";
            _dgJobs.Size = new Size(752, 488);
            _dgJobs.TabIndex = 1;
            //
            // UCAsset
            //
            Controls.Add(_TabControl1);
            Name = "UCAsset";
            Size = new Size(795, 594);
            _TabControl1.ResumeLayout(false);
            _tabDetails.ResumeLayout(false);
            _grpAsset.ResumeLayout(false);
            _grpAsset.PerformLayout();
            _tabDocuments.ResumeLayout(false);
            _tabJobs.ResumeLayout(false);
            _grpJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgJobs).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            SetupJobsDataGrid();
        }

        public object LoadedItem
        {
            get
            {
                return CurrentAsset;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private UCDocumentsList DocumentsControl;

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.Assets.Asset _currentAsset;

        public Entity.Assets.Asset CurrentAsset
        {
            get
            {
                return _currentAsset;
            }

            set
            {
                _currentAsset = value;
                if (CurrentAsset is null)
                {
                    CurrentAsset = new Entity.Assets.Asset();
                    CurrentAsset.Exists = false;
                }

                if (CurrentAsset.Exists)
                {
                    Populate();
                    pnlDocuments.Controls.Clear();
                    DocumentsControl = new UCDocumentsList(Entity.Sys.Enums.TableNames.tblAsset, CurrentAsset.AssetID);
                    pnlDocuments.Controls.Add(DocumentsControl);
                    grpJobs.Enabled = true;
                    // Me.btnAddJob.Enabled = True
                    PopulateJobs();
                }
                else
                {
                    grpJobs.Enabled = false;
                }
            }
        }

        private int _LoadProductID;

        // This is used to allow pre-selection of the product on load of the form
        public int LoadProductID
        {
            get
            {
                return _LoadProductID;
            }

            set
            {
                _LoadProductID = value;
                if (value > 0)
                {
                    selectedProductID = _LoadProductID;
                    btnFindProduct.Enabled = false;
                }
            }
        }

        private int _LoadSiteID;

        // This is used to allow pre-selection of a Site that isnt set by CurrentSiteID
        public int LoadSiteID
        {
            get
            {
                return _LoadSiteID;
            }

            set
            {
                _LoadSiteID = value;
            }
        }

        private DataView _jobsTable;

        public DataView JobsDataView
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
                dgJobs.DataSource = JobsDataView;
            }
        }

        private DataRow SelectedJobDataRow
        {
            get
            {
                if (!(dgJobs.CurrentRowIndex == -1))
                {
                    return JobsDataView[dgJobs.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private int _selectedProductID = 0;

        private int selectedProductID
        {
            get
            {
                return _selectedProductID;
            }

            set
            {
                _selectedProductID = value;
                if (_selectedProductID > 0)
                {
                    var oProduct = App.DB.Product.Product_Get(_selectedProductID);
                    if (oProduct is object)
                    {
                        txtGCNumber.Text = oProduct.Number;
                        var oType = App.DB.Picklists.Get_One_As_Object(oProduct.TypeID);
                        if (oType is object)
                        {
                            txtProduct.Text = oType.Name + "-";
                        }

                        var oMake = App.DB.Picklists.Get_One_As_Object(oProduct.MakeID);
                        if (oMake is object)
                        {
                            txtProduct.Text += oMake.Name + "-";
                        }

                        var oModel = App.DB.Picklists.Get_One_As_Object(oProduct.ModelID);
                        if (oModel is object)
                        {
                            txtProduct.Text += oModel.Name;
                        }
                    }
                    else
                    {
                        selectedProductID = 0;
                    }
                }
                else
                {
                    txtGCNumber.Text = "";
                    txtProduct.Text = "";
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void SetupJobsDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgJobs);
            var tStyle = dgJobs.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job Number";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 100;
            JobNumber.NullText = "";
            tStyle.GridColumnStyles.Add(JobNumber);
            var PONumber = new DataGridLabelColumn();
            PONumber.Format = "";
            PONumber.FormatInfo = null;
            PONumber.HeaderText = "PO Number";
            PONumber.MappingName = "PONumber";
            PONumber.ReadOnly = true;
            PONumber.Width = 100;
            PONumber.NullText = "";
            tStyle.GridColumnStyles.Add(PONumber);
            var DateCreated = new DataGridLabelColumn();
            DateCreated.Format = "dd/MMM/yyyy";
            DateCreated.FormatInfo = null;
            DateCreated.HeaderText = "Date Created";
            DateCreated.MappingName = "DateCreated";
            DateCreated.ReadOnly = true;
            DateCreated.Width = 100;
            DateCreated.NullText = "";
            tStyle.GridColumnStyles.Add(DateCreated);
            var Definition = new DataGridLabelColumn();
            Definition.Format = "";
            Definition.FormatInfo = null;
            Definition.HeaderText = "Definition";
            Definition.MappingName = "JobDefinition";
            Definition.ReadOnly = true;
            Definition.Width = 100;
            Definition.NullText = "";
            tStyle.GridColumnStyles.Add(Definition);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 100;
            Type.NullText = Entity.Sys.Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
            tStyle.GridColumnStyles.Add(Type);
            var JobStatus = new DataGridLabelColumn();
            JobStatus.Format = "";
            JobStatus.FormatInfo = null;
            JobStatus.HeaderText = "Status";
            JobStatus.MappingName = "JobStatus";
            JobStatus.ReadOnly = true;
            JobStatus.Width = 100;
            JobStatus.NullText = "";
            tStyle.GridColumnStyles.Add(JobStatus);
            var CreatedBy = new DataGridLabelColumn();
            CreatedBy.Format = "";
            CreatedBy.FormatInfo = null;
            CreatedBy.HeaderText = "Created By";
            CreatedBy.MappingName = "CreatedBy";
            CreatedBy.ReadOnly = true;
            CreatedBy.Width = 100;
            CreatedBy.NullText = "";
            tStyle.GridColumnStyles.Add(CreatedBy);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblJob.ToString();
            dgJobs.TableStyles.Add(tStyle);
        }

        private void UCAsset_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void chkDateUnknown_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDateUnknown.Checked == false)
            {
                dtpDateFitted.Enabled = true;
            }
            else
            {
                dtpDateFitted.Enabled = false;
            }
        }

        private void chkCertificateLastIssuedUnknown_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCertificateLastIssuedUnknown.Checked == false)
            {
                dtpCertificateLastIssued.Enabled = true;
            }
            else
            {
                dtpCertificateLastIssued.Enabled = false;
            }
        }

        private void chkLastServiceDateUnknown_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLastServicedDateUnknown.Checked == false)
            {
                dtpLastServicedDate.Enabled = true;
            }
            else
            {
                dtpLastServicedDate.Enabled = false;
            }
        }

        private void chkWarrantyStartDateUnknown_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWarrantyStartDateUnknown.Checked == false)
            {
                dtpWarrantyStartDate.Enabled = true;
                dtpWarrantyEndDate.Enabled = true;
            }
            else
            {
                dtpWarrantyStartDate.Enabled = false;
                dtpWarrantyEndDate.Enabled = false;
            }
        }

        private void dgJobs_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedJobDataRow is null)
            {
                return;
            }

            App.ShowForm(typeof(FRMLogCallout), true, new object[] { SelectedJobDataRow["JobID"], CurrentAsset.PropertyID, this });
        }

        private void btnAddJob_Click(object sender, EventArgs e)
        {
            var currentSite = App.DB.Sites.Get(CurrentAsset.PropertyID);
            int customerStatus = App.DB.Customer.Customer_Get(currentSite.CustomerID).Status;
            if (currentSite.OnStop & !App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions." + Constants.vbCrLf;
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                throw new System.Security.SecurityException(msg);
            }
            else if (customerStatus == Conversions.ToInteger(Entity.Sys.Enums.CustomerStatus.OnHold) & !App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Finance))
            {
                string msg = "You do not have the necessary security permissions." + Constants.vbCrLf;
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                throw new System.Security.SecurityException(msg);
            }
            else if (currentSite.OnStop)
            {
                if (App.ShowMessage("This property is on stop. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            else if (customerStatus == Conversions.ToInteger(Entity.Sys.Enums.CustomerStatus.OnHold))
            {
                if (App.ShowMessage("The customer is on hold. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
            }

            if (App.loggedInUser.UserRegions.Count > 0)
            {
                if (App.loggedInUser.UserRegions.Table.Select("RegionID = " + currentSite.RegionID).Length < 1)
                {
                    string msg = "You do not have the necessary security permissions." + Constants.vbCrLf;
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                    throw new System.Security.SecurityException(msg);
                }
            }
            else
            {
                string msg = "You do not have the necessary security permissions." + Constants.vbCrLf;
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                throw new System.Security.SecurityException(msg);
            }

            if (string.IsNullOrEmpty(currentSite.TelephoneNum) & string.IsNullOrEmpty(currentSite.FaxNum) | string.IsNullOrEmpty(currentSite.EmailAddress))
            {
                if (App.ShowMessage("The phone number/email address is missing from site. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            App.ShowForm(typeof(FRMLogCallout), true, new object[] { 0, CurrentAsset.PropertyID, this, CurrentAsset.AssetID });
        }

        private void dtpWarrantyStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpWarrantyEndDate.Value = dtpWarrantyStartDate.Value.AddYears(1).AddDays(-1);
        }

        private void btnFindProduct_Click(object sender, EventArgs e)
        {
            selectedProductID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblProduct));
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void PopulateJobs()
        {
            JobsDataView = App.DB.Job.Job_GetAll_For_Asset(CurrentAsset.AssetID);
        }

        public void DisableControls()
        {
            if (!App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Compliance))
            {
                txtLocation.Enabled = false;
                txtSerialNum.Enabled = false;
                dtpDateFitted.Enabled = false;
                chkDateUnknown.Enabled = false;
                dtpCertificateLastIssued.Enabled = false;
                chkCertificateLastIssuedUnknown.Enabled = false;
                dtpLastServicedDate.Enabled = false;
                chkLastServicedDateUnknown.Enabled = false;
                dtpWarrantyStartDate.Enabled = false;
                chkWarrantyStartDateUnknown.Enabled = false;
                dtpWarrantyEndDate.Enabled = false;
                chkWarrantyStartDateUnknown.Enabled = false;
            }
        }

        public void Populate(int ID = 0)
        {
            if (App.ControlLoading == false)
            {
                App.ControlLoading = true;
                if (!(ID == 0))
                {
                    CurrentAsset = App.DB.Asset.Asset_Get(ID);
                }

                selectedProductID = CurrentAsset.ProductID;
                btnFindProduct.Enabled = false;
                txtSerialNum.Text = CurrentAsset.SerialNum;
                if (CurrentAsset.DateFitted == DateTime.MinValue)
                {
                    chkDateUnknown.Checked = true;
                }
                else
                {
                    dtpDateFitted.Value = CurrentAsset.DateFitted;
                }

                if (CurrentAsset.CertificateLastIssued == DateTime.MinValue)
                {
                    chkCertificateLastIssuedUnknown.Checked = true;
                }
                else
                {
                    dtpCertificateLastIssued.Value = CurrentAsset.CertificateLastIssued;
                }

                if (CurrentAsset.LastServicedDate == DateTime.MinValue)
                {
                    chkLastServicedDateUnknown.Checked = true;
                }
                else
                {
                    dtpLastServicedDate.Value = CurrentAsset.LastServicedDate;
                }

                if (CurrentAsset.WarrantyStartDate == DateTime.MinValue)
                {
                    chkWarrantyStartDateUnknown.Checked = true;
                }
                else
                {
                    dtpWarrantyStartDate.Value = CurrentAsset.WarrantyStartDate;
                }

                if (CurrentAsset.WarrantyEndDate == DateTime.MinValue)
                {
                    chkWarrantyStartDateUnknown.Checked = true;
                }
                else
                {
                    dtpWarrantyEndDate.Value = CurrentAsset.WarrantyEndDate;
                }

                txtBoughtFrom.Text = CurrentAsset.BoughtFrom;
                txtSupplierBy.Text = CurrentAsset.SuppliedBy;
                txtLocation.Text = CurrentAsset.Location;
                txtNotes.Text = CurrentAsset.Notes;
                txtGCNumber.Text = CurrentAsset.GCNumber;
                txtYearOfManufacture.Text = CurrentAsset.YearOfManufacture;
                txtApproximateValue.Text = CurrentAsset.ApproximateValue.ToString();
                chkActive.Checked = CurrentAsset.Active;
                chkTenantsAppliance.Checked = CurrentAsset.TenantsAppliance;
                var argcombo = cboGasType;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentAsset.GasTypeID.ToString());
                var argcombo1 = cboFlueType;
                Combo.SetSelectedComboItem_By_Value(ref argcombo1, CurrentAsset.FlueTypeID.ToString());
                txtBoughtFrom.Enabled = false;
                txtSupplierBy.Enabled = false;
                txtYearOfManufacture.Enabled = false;
                txtApproximateValue.Enabled = false;
                cboFlueType.Enabled = false;
                cboGasType.Enabled = false;
                DisableControls();
                App.AddChangeHandlers(this);
                App.ControlChanged = false;
                App.ControlLoading = false;
            }
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentAsset.IgnoreExceptionsOnSetMethods = true;
                CurrentAsset.SetProductID = selectedProductID;
                CurrentAsset.SetSerialNum = txtSerialNum.Text.Trim();
                if (chkDateUnknown.Checked == true)
                {
                    CurrentAsset.DateFitted = DateTime.MinValue;
                }
                else
                {
                    CurrentAsset.DateFitted = dtpDateFitted.Value;
                }

                if (chkCertificateLastIssuedUnknown.Checked == true)
                {
                    CurrentAsset.CertificateLastIssued = DateTime.MinValue;
                }
                else
                {
                    CurrentAsset.CertificateLastIssued = dtpCertificateLastIssued.Value;
                }

                if (chkLastServicedDateUnknown.Checked == true)
                {
                    CurrentAsset.LastServicedDate = DateTime.MinValue;
                }
                else
                {
                    CurrentAsset.LastServicedDate = dtpLastServicedDate.Value;
                }

                if (chkWarrantyStartDateUnknown.Checked == true)
                {
                    CurrentAsset.WarrantyStartDate = DateTime.MinValue;
                    CurrentAsset.WarrantyEndDate = DateTime.MinValue;
                }
                else
                {
                    CurrentAsset.WarrantyStartDate = dtpWarrantyStartDate.Value;
                    CurrentAsset.WarrantyEndDate = dtpWarrantyEndDate.Value;
                }

                CurrentAsset.SetBoughtFrom = txtBoughtFrom.Text.Trim();
                CurrentAsset.SetSuppliedBy = txtSupplierBy.Text.Trim();
                CurrentAsset.SetLocation = txtLocation.Text.Trim();
                CurrentAsset.SetNotes = txtNotes.Text.Trim();
                CurrentAsset.SetGCNumber = txtGCNumber.Text.Trim();
                CurrentAsset.SetYearOfManufacture = txtYearOfManufacture.Text.Trim();
                if (txtApproximateValue.Text.Trim().Length == 0)
                {
                    CurrentAsset.SetApproximateValue = 0;
                }
                else
                {
                    CurrentAsset.SetApproximateValue = txtApproximateValue.Text.Trim();
                }

                CurrentAsset.SetGasTypeID = Combo.get_GetSelectedItemValue(cboGasType);
                CurrentAsset.SetFlueTypeID = Combo.get_GetSelectedItemValue(cboFlueType);
                CurrentAsset.SetActive = chkActive.Checked;
                CurrentAsset.SetTenantsAppliance = chkTenantsAppliance.Checked;
                var cV = new Entity.Assets.AssetValidator();
                cV.Validate(CurrentAsset);
                if (CurrentAsset.Exists)
                {
                    App.DB.Asset.Update(CurrentAsset);
                }
                else
                {
                    if (LoadSiteID > 0)
                    {
                        CurrentAsset.SetPropertyID = LoadSiteID;
                    }
                    else
                    {
                        CurrentAsset.SetPropertyID = App.CurrentPropertyID;
                    }

                    CurrentAsset = App.DB.Asset.Insert(CurrentAsset);
                }

                if (!(LoadSiteID > 0))
                {
                    if (App.CurrentPropertyID == 0)
                    {
                        RecordsChanged?.Invoke(App.DB.Asset.Asset_GetAll(App.loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Asset, true, false, "");
                    }
                    else
                    {
                        RecordsChanged?.Invoke(App.DB.Asset.Asset_GetForSite(App.CurrentPropertyID), Entity.Sys.Enums.PageViewing.Asset, true, false, "");
                    }

                    StateChanged?.Invoke(CurrentAsset.AssetID);
                    App.MainForm.RefreshEntity(CurrentAsset.AssetID);
                }

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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}