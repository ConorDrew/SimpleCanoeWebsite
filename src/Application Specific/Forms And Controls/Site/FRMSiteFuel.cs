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
    public class FRMSiteFuel : FRMBaseForm, IForm
    {
        public FRMSiteFuel()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMContactInfo_Load;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMSiteFuel(Entity.Sites.Site oSite) : base()
        {
            base.Load += FRMContactInfo_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            CurrentSite = oSite;
            var argc = cboFuel;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.GasTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc1 = cboChargeType;
            Combo.SetUpCombo(ref argc1, App.DB.Sites.SiteFuelCharge_GetAll().Table, "SiteFuelChargeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select_Negative);
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

        private TabControl _SiteFuelTabControl;

        internal TabControl SiteFuelTabControl
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SiteFuelTabControl;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SiteFuelTabControl != null)
                {
                }

                _SiteFuelTabControl = value;
                if (_SiteFuelTabControl != null)
                {
                }
            }
        }

        private TabPage _tabSiteFuel;

        internal TabPage tabSiteFuel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabSiteFuel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabSiteFuel != null)
                {
                }

                _tabSiteFuel = value;
                if (_tabSiteFuel != null)
                {
                }
            }
        }

        private TabPage _tabAudit;

        internal TabPage tabAudit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabAudit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabAudit != null)
                {
                }

                _tabAudit = value;
                if (_tabAudit != null)
                {
                }
            }
        }

        private GroupBox _grpSiteFuels;

        internal GroupBox grpSiteFuels
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSiteFuels;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSiteFuels != null)
                {
                }

                _grpSiteFuels = value;
                if (_grpSiteFuels != null)
                {
                }
            }
        }

        private DataGrid _dgSiteFuel;

        internal DataGrid dgSiteFuel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgSiteFuel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgSiteFuel != null)
                {
                    _dgSiteFuel.Click -= dgSiteFuel_Click;
                    _dgSiteFuel.MouseUp -= dgSiteFuel_MouseUp;
                    _dgSiteFuel.Leave -= dgSiteFuel_Leave;
                }

                _dgSiteFuel = value;
                if (_dgSiteFuel != null)
                {
                    _dgSiteFuel.Click += dgSiteFuel_Click;
                    _dgSiteFuel.MouseUp += dgSiteFuel_MouseUp;
                    _dgSiteFuel.Leave += dgSiteFuel_Leave;
                }
            }
        }

        private Button _btnSaveFuel;

        internal Button btnSaveFuel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSaveFuel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSaveFuel != null)
                {
                    _btnSaveFuel.Click -= btnSave_Click;
                }

                _btnSaveFuel = value;
                if (_btnSaveFuel != null)
                {
                    _btnSaveFuel.Click += btnSave_Click;
                }
            }
        }

        private Button _btnDeleteSiteFuel;

        internal Button btnDeleteSiteFuel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDeleteSiteFuel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeleteSiteFuel != null)
                {
                    _btnDeleteSiteFuel.Click -= btnDeleteSiteFuel_Click;
                }

                _btnDeleteSiteFuel = value;
                if (_btnDeleteSiteFuel != null)
                {
                    _btnDeleteSiteFuel.Click += btnDeleteSiteFuel_Click;
                }
            }
        }

        private GroupBox _grpSiteFuelUpdate;

        internal GroupBox grpSiteFuelUpdate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSiteFuelUpdate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSiteFuelUpdate != null)
                {
                }

                _grpSiteFuelUpdate = value;
                if (_grpSiteFuelUpdate != null)
                {
                }
            }
        }

        private Label _lblFuel;

        internal Label lblFuel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFuel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFuel != null)
                {
                }

                _lblFuel = value;
                if (_lblFuel != null)
                {
                }
            }
        }

        private ComboBox _cboFuel;

        internal ComboBox cboFuel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFuel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboFuel != null)
                {
                }

                _cboFuel = value;
                if (_cboFuel != null)
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

        private GroupBox _grpSite;

        internal GroupBox grpSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSite != null)
                {
                }

                _grpSite = value;
                if (_grpSite != null)
                {
                }
            }
        }

        private TextBox _txtCustomerName;

        internal TextBox txtCustomerName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCustomerName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCustomerName != null)
                {
                }

                _txtCustomerName = value;
                if (_txtCustomerName != null)
                {
                }
            }
        }

        private Label _lblSite;

        internal Label lblSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSite != null)
                {
                }

                _lblSite = value;
                if (_lblSite != null)
                {
                }
            }
        }

        private TextBox _txtSiteName;

        internal TextBox txtSiteName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSiteName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSiteName != null)
                {
                }

                _txtSiteName = value;
                if (_txtSiteName != null)
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

        private TextBox _txtTelephoneNum;

        internal TextBox txtTelephoneNum
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTelephoneNum;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTelephoneNum != null)
                {
                }

                _txtTelephoneNum = value;
                if (_txtTelephoneNum != null)
                {
                }
            }
        }

        private Label _lblTelephoneNum;

        internal Label lblTelephoneNum
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTelephoneNum;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTelephoneNum != null)
                {
                }

                _lblTelephoneNum = value;
                if (_lblTelephoneNum != null)
                {
                }
            }
        }

        private TextBox _txtEmailAddress;

        internal TextBox txtEmailAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEmailAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEmailAddress != null)
                {
                }

                _txtEmailAddress = value;
                if (_txtEmailAddress != null)
                {
                }
            }
        }

        private Label _lblEmailAddress;

        internal Label lblEmailAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEmailAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEmailAddress != null)
                {
                }

                _lblEmailAddress = value;
                if (_lblEmailAddress != null)
                {
                }
            }
        }

        private TextBox _txtFaxNum;

        internal TextBox txtFaxNum
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFaxNum;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFaxNum != null)
                {
                }

                _txtFaxNum = value;
                if (_txtFaxNum != null)
                {
                }
            }
        }

        private Label _lblFaxNum;

        internal Label lblFaxNum
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFaxNum;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFaxNum != null)
                {
                }

                _lblFaxNum = value;
                if (_lblFaxNum != null)
                {
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

        private Label _lblSiteName;

        internal Label lblSiteName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSiteName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSiteName != null)
                {
                }

                _lblSiteName = value;
                if (_lblSiteName != null)
                {
                }
            }
        }

        private ToolTip _ttSiteFuel;

        internal ToolTip ttSiteFuel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ttSiteFuel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ttSiteFuel != null)
                {
                }

                _ttSiteFuel = value;
                if (_ttSiteFuel != null)
                {
                }
            }
        }

        private GroupBox _grpSiteFuelAudit;

        internal GroupBox grpSiteFuelAudit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSiteFuelAudit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSiteFuelAudit != null)
                {
                }

                _grpSiteFuelAudit = value;
                if (_grpSiteFuelAudit != null)
                {
                }
            }
        }

        private DataGrid _dgSiteFuelAudit;

        internal DataGrid dgSiteFuelAudit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgSiteFuelAudit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgSiteFuelAudit != null)
                {
                }

                _dgSiteFuelAudit = value;
                if (_dgSiteFuelAudit != null)
                {
                }
            }
        }

        private TextBox _txtAddedOn;

        internal TextBox txtAddedOn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddedOn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddedOn != null)
                {
                }

                _txtAddedOn = value;
                if (_txtAddedOn != null)
                {
                }
            }
        }

        private Label _lblAddedOn;

        internal Label lblAddedOn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddedOn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddedOn != null)
                {
                }

                _lblAddedOn = value;
                if (_lblAddedOn != null)
                {
                }
            }
        }

        private TextBox _txtAddedByText;

        internal TextBox txtAddedByText
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddedByText;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddedByText != null)
                {
                }

                _txtAddedByText = value;
                if (_txtAddedByText != null)
                {
                }
            }
        }

        private Label _lblAddedBy;

        internal Label lblAddedBy
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddedBy;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddedBy != null)
                {
                }

                _lblAddedBy = value;
                if (_lblAddedBy != null)
                {
                }
            }
        }

        private Label _lblChargeType;

        internal Label lblChargeType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblChargeType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblChargeType != null)
                {
                }

                _lblChargeType = value;
                if (_lblChargeType != null)
                {
                }
            }
        }

        private ComboBox _cboChargeType;

        internal ComboBox cboChargeType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboChargeType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboChargeType != null)
                {
                }

                _cboChargeType = value;
                if (_cboChargeType != null)
                {
                }
            }
        }

        private DateTimePicker _dtpActualServiceDate;

        internal DateTimePicker dtpActualServiceDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpActualServiceDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpActualServiceDate != null)
                {
                }

                _dtpActualServiceDate = value;
                if (_dtpActualServiceDate != null)
                {
                }
            }
        }

        private Label _lblActualServiceDate;

        internal Label lblActualServiceDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblActualServiceDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblActualServiceDate != null)
                {
                }

                _lblActualServiceDate = value;
                if (_lblActualServiceDate != null)
                {
                }
            }
        }

        private Button _btnUpdateSiteService;

        internal Button btnUpdateSiteService
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnUpdateSiteService;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnUpdateSiteService != null)
                {
                    _btnUpdateSiteService.Click -= btnUpdateSiteService_Click;
                }

                _btnUpdateSiteService = value;
                if (_btnUpdateSiteService != null)
                {
                    _btnUpdateSiteService.Click += btnUpdateSiteService_Click;
                }
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            _SiteFuelTabControl = new TabControl();
            _tabSiteFuel = new TabPage();
            _grpSiteFuels = new GroupBox();
            _grpSite = new GroupBox();
            _btnUpdateSiteService = new Button();
            _btnUpdateSiteService.Click += new EventHandler(btnUpdateSiteService_Click);
            _txtSite = new TextBox();
            _lblSiteName = new Label();
            _txtCustomerName = new TextBox();
            _lblSite = new Label();
            _txtSiteName = new TextBox();
            _lblCustomer = new Label();
            _txtTelephoneNum = new TextBox();
            _lblTelephoneNum = new Label();
            _txtEmailAddress = new TextBox();
            _lblEmailAddress = new Label();
            _txtFaxNum = new TextBox();
            _lblFaxNum = new Label();
            _grpSiteFuelUpdate = new GroupBox();
            _dtpActualServiceDate = new DateTimePicker();
            _lblActualServiceDate = new Label();
            _lblChargeType = new Label();
            _cboChargeType = new ComboBox();
            _txtAddedOn = new TextBox();
            _lblAddedOn = new Label();
            _txtAddedByText = new TextBox();
            _lblAddedBy = new Label();
            _dtpLastServiceDate = new DateTimePicker();
            _lblLastService = new Label();
            _lblFuel = new Label();
            _cboFuel = new ComboBox();
            _btnSaveFuel = new Button();
            _btnSaveFuel.Click += new EventHandler(btnSave_Click);
            _btnDeleteSiteFuel = new Button();
            _btnDeleteSiteFuel.Click += new EventHandler(btnDeleteSiteFuel_Click);
            _dgSiteFuel = new DataGrid();
            _dgSiteFuel.Click += new EventHandler(dgSiteFuel_Click);
            _dgSiteFuel.MouseUp += new MouseEventHandler(dgSiteFuel_MouseUp);
            _dgSiteFuel.Leave += new EventHandler(dgSiteFuel_Leave);
            _tabAudit = new TabPage();
            _grpSiteFuelAudit = new GroupBox();
            _dgSiteFuelAudit = new DataGrid();
            _ttSiteFuel = new ToolTip(components);
            _SiteFuelTabControl.SuspendLayout();
            _tabSiteFuel.SuspendLayout();
            _grpSiteFuels.SuspendLayout();
            _grpSite.SuspendLayout();
            _grpSiteFuelUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSiteFuel).BeginInit();
            _tabAudit.SuspendLayout();
            _grpSiteFuelAudit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSiteFuelAudit).BeginInit();
            SuspendLayout();
            // 
            // SiteFuelTabControl
            // 
            _SiteFuelTabControl.Controls.Add(_tabSiteFuel);
            _SiteFuelTabControl.Controls.Add(_tabAudit);
            _SiteFuelTabControl.Dock = DockStyle.Fill;
            _SiteFuelTabControl.Location = new Point(0, 0);
            _SiteFuelTabControl.Name = "SiteFuelTabControl";
            _SiteFuelTabControl.SelectedIndex = 0;
            _SiteFuelTabControl.Size = new Size(800, 557);
            _SiteFuelTabControl.TabIndex = 2;
            // 
            // tabSiteFuel
            // 
            _tabSiteFuel.Controls.Add(_grpSiteFuels);
            _tabSiteFuel.Location = new Point(4, 22);
            _tabSiteFuel.Name = "tabSiteFuel";
            _tabSiteFuel.Padding = new Padding(3);
            _tabSiteFuel.Size = new Size(792, 531);
            _tabSiteFuel.TabIndex = 0;
            _tabSiteFuel.Text = "Site Fuels";
            _tabSiteFuel.UseVisualStyleBackColor = true;
            // 
            // grpSiteFuels
            // 
            _grpSiteFuels.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpSiteFuels.Controls.Add(_grpSite);
            _grpSiteFuels.Controls.Add(_grpSiteFuelUpdate);
            _grpSiteFuels.Controls.Add(_dgSiteFuel);
            _grpSiteFuels.Location = new Point(5, 3);
            _grpSiteFuels.Margin = new Padding(0);
            _grpSiteFuels.Name = "grpSiteFuels";
            _grpSiteFuels.Padding = new Padding(0);
            _grpSiteFuels.Size = new Size(782, 523);
            _grpSiteFuels.TabIndex = 14;
            _grpSiteFuels.TabStop = false;
            _grpSiteFuels.Text = "Site Fuel";
            // 
            // grpSite
            // 
            _grpSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _grpSite.Controls.Add(_btnUpdateSiteService);
            _grpSite.Controls.Add(_txtSite);
            _grpSite.Controls.Add(_lblSiteName);
            _grpSite.Controls.Add(_txtCustomerName);
            _grpSite.Controls.Add(_lblSite);
            _grpSite.Controls.Add(_txtSiteName);
            _grpSite.Controls.Add(_lblCustomer);
            _grpSite.Controls.Add(_txtTelephoneNum);
            _grpSite.Controls.Add(_lblTelephoneNum);
            _grpSite.Controls.Add(_txtEmailAddress);
            _grpSite.Controls.Add(_lblEmailAddress);
            _grpSite.Controls.Add(_txtFaxNum);
            _grpSite.Controls.Add(_lblFaxNum);
            _grpSite.Location = new Point(489, 17);
            _grpSite.Name = "grpSite";
            _grpSite.Size = new Size(287, 229);
            _grpSite.TabIndex = 115;
            _grpSite.TabStop = false;
            _grpSite.Text = "Site ";
            // 
            // btnUpdateSiteService
            // 
            _btnUpdateSiteService.Location = new Point(139, 196);
            _btnUpdateSiteService.Name = "btnUpdateSiteService";
            _btnUpdateSiteService.Size = new Size(139, 23);
            _btnUpdateSiteService.TabIndex = 126;
            _btnUpdateSiteService.Text = "Update Site Service";
            // 
            // txtSite
            // 
            _txtSite.Location = new Point(117, 48);
            _txtSite.Name = "txtSite";
            _txtSite.ReadOnly = true;
            _txtSite.Size = new Size(161, 21);
            _txtSite.TabIndex = 121;
            // 
            // lblSiteName
            // 
            _lblSiteName.Location = new Point(8, 51);
            _lblSiteName.Name = "lblSiteName";
            _lblSiteName.Size = new Size(80, 23);
            _lblSiteName.TabIndex = 125;
            _lblSiteName.Text = "Name:";
            // 
            // txtCustomerName
            // 
            _txtCustomerName.Location = new Point(117, 20);
            _txtCustomerName.Name = "txtCustomerName";
            _txtCustomerName.ReadOnly = true;
            _txtCustomerName.Size = new Size(161, 21);
            _txtCustomerName.TabIndex = 120;
            // 
            // lblSite
            // 
            _lblSite.Location = new Point(8, 79);
            _lblSite.Name = "lblSite";
            _lblSite.Size = new Size(80, 23);
            _lblSite.TabIndex = 124;
            _lblSite.Text = "Property:";
            // 
            // txtSiteName
            // 
            _txtSiteName.Location = new Point(117, 76);
            _txtSiteName.Name = "txtSiteName";
            _txtSiteName.ReadOnly = true;
            _txtSiteName.Size = new Size(161, 21);
            _txtSiteName.TabIndex = 122;
            // 
            // lblCustomer
            // 
            _lblCustomer.Location = new Point(6, 23);
            _lblCustomer.Name = "lblCustomer";
            _lblCustomer.Size = new Size(80, 23);
            _lblCustomer.TabIndex = 123;
            _lblCustomer.Text = "Customer:";
            // 
            // txtTelephoneNum
            // 
            _txtTelephoneNum.Location = new Point(117, 104);
            _txtTelephoneNum.MaxLength = 50;
            _txtTelephoneNum.Name = "txtTelephoneNum";
            _txtTelephoneNum.ReadOnly = true;
            _txtTelephoneNum.Size = new Size(161, 21);
            _txtTelephoneNum.TabIndex = 114;
            _txtTelephoneNum.Tag = "Site.TelephoneNum";
            // 
            // lblTelephoneNum
            // 
            _lblTelephoneNum.Location = new Point(8, 107);
            _lblTelephoneNum.Name = "lblTelephoneNum";
            _lblTelephoneNum.Size = new Size(48, 20);
            _lblTelephoneNum.TabIndex = 119;
            _lblTelephoneNum.Text = "Tel";
            // 
            // txtEmailAddress
            // 
            _txtEmailAddress.Location = new Point(117, 160);
            _txtEmailAddress.MaxLength = 100;
            _txtEmailAddress.Name = "txtEmailAddress";
            _txtEmailAddress.ReadOnly = true;
            _txtEmailAddress.Size = new Size(161, 21);
            _txtEmailAddress.TabIndex = 116;
            _txtEmailAddress.Tag = "Site.EmailAddress";
            // 
            // lblEmailAddress
            // 
            _lblEmailAddress.Location = new Point(8, 163);
            _lblEmailAddress.Name = "lblEmailAddress";
            _lblEmailAddress.Size = new Size(98, 20);
            _lblEmailAddress.TabIndex = 118;
            _lblEmailAddress.Text = "Email Address";
            // 
            // txtFaxNum
            // 
            _txtFaxNum.Location = new Point(117, 132);
            _txtFaxNum.MaxLength = 50;
            _txtFaxNum.Name = "txtFaxNum";
            _txtFaxNum.ReadOnly = true;
            _txtFaxNum.Size = new Size(161, 21);
            _txtFaxNum.TabIndex = 115;
            _txtFaxNum.Tag = "Site.FaxNum";
            // 
            // lblFaxNum
            // 
            _lblFaxNum.Location = new Point(8, 135);
            _lblFaxNum.Name = "lblFaxNum";
            _lblFaxNum.Size = new Size(50, 20);
            _lblFaxNum.TabIndex = 117;
            _lblFaxNum.Text = "Mobile";
            // 
            // grpSiteFuelUpdate
            // 
            _grpSiteFuelUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _grpSiteFuelUpdate.Controls.Add(_dtpActualServiceDate);
            _grpSiteFuelUpdate.Controls.Add(_lblActualServiceDate);
            _grpSiteFuelUpdate.Controls.Add(_lblChargeType);
            _grpSiteFuelUpdate.Controls.Add(_cboChargeType);
            _grpSiteFuelUpdate.Controls.Add(_txtAddedOn);
            _grpSiteFuelUpdate.Controls.Add(_lblAddedOn);
            _grpSiteFuelUpdate.Controls.Add(_txtAddedByText);
            _grpSiteFuelUpdate.Controls.Add(_lblAddedBy);
            _grpSiteFuelUpdate.Controls.Add(_dtpLastServiceDate);
            _grpSiteFuelUpdate.Controls.Add(_lblLastService);
            _grpSiteFuelUpdate.Controls.Add(_lblFuel);
            _grpSiteFuelUpdate.Controls.Add(_cboFuel);
            _grpSiteFuelUpdate.Controls.Add(_btnSaveFuel);
            _grpSiteFuelUpdate.Controls.Add(_btnDeleteSiteFuel);
            _grpSiteFuelUpdate.Location = new Point(489, 252);
            _grpSiteFuelUpdate.Name = "grpSiteFuelUpdate";
            _grpSiteFuelUpdate.Size = new Size(287, 266);
            _grpSiteFuelUpdate.TabIndex = 12;
            _grpSiteFuelUpdate.TabStop = false;
            _grpSiteFuelUpdate.Text = "Fuel";
            // 
            // dtpActualServiceDate
            // 
            _dtpActualServiceDate.Location = new Point(142, 119);
            _dtpActualServiceDate.Name = "dtpActualServiceDate";
            _dtpActualServiceDate.Size = new Size(139, 21);
            _dtpActualServiceDate.TabIndex = 133;
            // 
            // lblActualServiceDate
            // 
            _lblActualServiceDate.Location = new Point(6, 125);
            _lblActualServiceDate.Name = "lblActualServiceDate";
            _lblActualServiceDate.Size = new Size(124, 20);
            _lblActualServiceDate.TabIndex = 132;
            _lblActualServiceDate.Text = "Service Date";
            // 
            // lblChargeType
            // 
            _lblChargeType.AutoSize = true;
            _lblChargeType.Location = new Point(6, 56);
            _lblChargeType.Name = "lblChargeType";
            _lblChargeType.Size = new Size(49, 13);
            _lblChargeType.TabIndex = 131;
            _lblChargeType.Text = "Charge";
            // 
            // cboChargeType
            // 
            _cboChargeType.FormattingEnabled = true;
            _cboChargeType.Location = new Point(72, 53);
            _cboChargeType.Name = "cboChargeType";
            _cboChargeType.Size = new Size(209, 21);
            _cboChargeType.TabIndex = 130;
            // 
            // txtAddedOn
            // 
            _txtAddedOn.Location = new Point(120, 185);
            _txtAddedOn.Name = "txtAddedOn";
            _txtAddedOn.ReadOnly = true;
            _txtAddedOn.Size = new Size(161, 21);
            _txtAddedOn.TabIndex = 128;
            // 
            // lblAddedOn
            // 
            _lblAddedOn.Location = new Point(8, 188);
            _lblAddedOn.Name = "lblAddedOn";
            _lblAddedOn.Size = new Size(80, 23);
            _lblAddedOn.TabIndex = 129;
            _lblAddedOn.Text = "Added On:";
            // 
            // txtAddedByText
            // 
            _txtAddedByText.Location = new Point(120, 152);
            _txtAddedByText.Name = "txtAddedByText";
            _txtAddedByText.ReadOnly = true;
            _txtAddedByText.Size = new Size(161, 21);
            _txtAddedByText.TabIndex = 126;
            // 
            // lblAddedBy
            // 
            _lblAddedBy.Location = new Point(6, 155);
            _lblAddedBy.Name = "lblAddedBy";
            _lblAddedBy.Size = new Size(80, 23);
            _lblAddedBy.TabIndex = 127;
            _lblAddedBy.Text = "Added By:";
            // 
            // dtpLastServiceDate
            // 
            _dtpLastServiceDate.Location = new Point(142, 86);
            _dtpLastServiceDate.Name = "dtpLastServiceDate";
            _dtpLastServiceDate.Size = new Size(139, 21);
            _dtpLastServiceDate.TabIndex = 57;
            // 
            // lblLastService
            // 
            _lblLastService.Location = new Point(6, 92);
            _lblLastService.Name = "lblLastService";
            _lblLastService.Size = new Size(114, 20);
            _lblLastService.TabIndex = 56;
            _lblLastService.Text = "Service Due Date";
            // 
            // lblFuel
            // 
            _lblFuel.AutoSize = true;
            _lblFuel.Location = new Point(8, 23);
            _lblFuel.Name = "lblFuel";
            _lblFuel.Size = new Size(30, 13);
            _lblFuel.TabIndex = 55;
            _lblFuel.Text = "Fuel";
            // 
            // cboFuel
            // 
            _cboFuel.FormattingEnabled = true;
            _cboFuel.Location = new Point(72, 20);
            _cboFuel.Name = "cboFuel";
            _cboFuel.Size = new Size(209, 21);
            _cboFuel.TabIndex = 54;
            // 
            // btnSaveFuel
            // 
            _btnSaveFuel.Location = new Point(191, 233);
            _btnSaveFuel.Name = "btnSaveFuel";
            _btnSaveFuel.Size = new Size(90, 23);
            _btnSaveFuel.TabIndex = 9;
            _btnSaveFuel.Text = "Save";
            // 
            // btnDeleteSiteFuel
            // 
            _btnDeleteSiteFuel.Location = new Point(9, 233);
            _btnDeleteSiteFuel.Name = "btnDeleteSiteFuel";
            _btnDeleteSiteFuel.Size = new Size(90, 23);
            _btnDeleteSiteFuel.TabIndex = 10;
            _btnDeleteSiteFuel.Text = "Delete";
            // 
            // dgSiteFuel
            // 
            _dgSiteFuel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgSiteFuel.DataMember = "";
            _dgSiteFuel.HeaderForeColor = SystemColors.ControlText;
            _dgSiteFuel.Location = new Point(5, 19);
            _dgSiteFuel.Name = "dgSiteFuel";
            _dgSiteFuel.Size = new Size(478, 499);
            _dgSiteFuel.TabIndex = 11;
            // 
            // tabAudit
            // 
            _tabAudit.Controls.Add(_grpSiteFuelAudit);
            _tabAudit.Location = new Point(4, 22);
            _tabAudit.Name = "tabAudit";
            _tabAudit.Padding = new Padding(3);
            _tabAudit.Size = new Size(792, 531);
            _tabAudit.TabIndex = 1;
            _tabAudit.Text = "Audit";
            _tabAudit.UseVisualStyleBackColor = true;
            // 
            // grpSiteFuelAudit
            // 
            _grpSiteFuelAudit.Controls.Add(_dgSiteFuelAudit);
            _grpSiteFuelAudit.Dock = DockStyle.Fill;
            _grpSiteFuelAudit.Location = new Point(3, 3);
            _grpSiteFuelAudit.Name = "grpSiteFuelAudit";
            _grpSiteFuelAudit.Size = new Size(786, 525);
            _grpSiteFuelAudit.TabIndex = 5;
            _grpSiteFuelAudit.TabStop = false;
            _grpSiteFuelAudit.Text = "Site Fuel Audit";
            // 
            // dgSiteFuelAudit
            // 
            _dgSiteFuelAudit.DataMember = "";
            _dgSiteFuelAudit.Dock = DockStyle.Fill;
            _dgSiteFuelAudit.HeaderForeColor = SystemColors.ControlText;
            _dgSiteFuelAudit.Location = new Point(3, 17);
            _dgSiteFuelAudit.Name = "dgSiteFuelAudit";
            _dgSiteFuelAudit.Size = new Size(780, 505);
            _dgSiteFuelAudit.TabIndex = 15;
            // 
            // FRMSiteFuel
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(800, 557);
            Controls.Add(_SiteFuelTabControl);
            MinimumSize = new Size(1, 1);
            Name = "FRMSiteFuel";
            Text = "Site Fuel";
            Controls.SetChildIndex(_SiteFuelTabControl, 0);
            _SiteFuelTabControl.ResumeLayout(false);
            _tabSiteFuel.ResumeLayout(false);
            _grpSiteFuels.ResumeLayout(false);
            _grpSite.ResumeLayout(false);
            _grpSite.PerformLayout();
            _grpSiteFuelUpdate.ResumeLayout(false);
            _grpSiteFuelUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSiteFuel).EndInit();
            _tabAudit.ResumeLayout(false);
            _grpSiteFuelAudit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgSiteFuelAudit).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupSiteFuelDataGrid();
            SetupSiteFuelAuditDataGrid();
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
        public void SetupSiteFuelDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgSiteFuel);
            var tStyle = dgSiteFuel.TableStyles[0];
            var fuelType = new DataGridSiteFuelColumn();
            fuelType.Format = "";
            fuelType.FormatInfo = null;
            fuelType.HeaderText = "Fuel Type";
            fuelType.MappingName = "FuelType";
            fuelType.ReadOnly = true;
            fuelType.Width = 100;
            fuelType.NullText = "";
            tStyle.GridColumnStyles.Add(fuelType);
            var serviceDue = new DataGridSiteFuelColumn();
            serviceDue.Format = "dd/MM/yyyy";
            serviceDue.FormatInfo = null;
            serviceDue.HeaderText = "Service Due";
            serviceDue.MappingName = "ServiceDue";
            serviceDue.ReadOnly = true;
            serviceDue.Width = 105;
            serviceDue.NullText = "N/A";
            tStyle.GridColumnStyles.Add(serviceDue);
            var lastServiceDate = new DataGridSiteFuelColumn();
            lastServiceDate.Format = "dd/MM/yyyy";
            lastServiceDate.FormatInfo = null;
            lastServiceDate.HeaderText = "Service Date";
            lastServiceDate.MappingName = "ActualServiceDate";
            lastServiceDate.ReadOnly = true;
            lastServiceDate.Width = 105;
            lastServiceDate.NullText = "N/A";
            tStyle.GridColumnStyles.Add(lastServiceDate);
            var FuelChargeType = new DataGridSiteFuelColumn();
            FuelChargeType.Format = "dd/MM/yyyy";
            FuelChargeType.FormatInfo = null;
            FuelChargeType.HeaderText = "Charge Type";
            FuelChargeType.MappingName = "FuelChargeType";
            FuelChargeType.ReadOnly = true;
            FuelChargeType.Width = 170;
            FuelChargeType.NullText = "";
            tStyle.GridColumnStyles.Add(FuelChargeType);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSiteFuel.ToString();
            dgSiteFuel.TableStyles.Add(tStyle);
        }

        public void SetupSiteFuelAuditDataGrid()
        {
            var tStyle = dgSiteFuelAudit.TableStyles[0];
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
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblSiteFuel.ToString();
            dgSiteFuelAudit.TableStyles.Add(tStyle);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private Entity.Sites.Site _osite;

        public Entity.Sites.Site CurrentSite
        {
            get
            {
                return _osite;
            }

            set
            {
                _osite = value;
                txtSite.Text = CurrentSite.Name;
                txtSiteName.Text = CurrentSite.Address1 + "," + CurrentSite.Postcode;
                var CurrentCustomer = new Entity.Customers.Customer();
                CurrentCustomer = App.DB.Customer.Customer_Get_Light(CurrentSite.CustomerID);
                txtCustomerName.Text = CurrentCustomer.Name;
                txtTelephoneNum.Text = CurrentSite.TelephoneNum;
                txtFaxNum.Text = CurrentSite.FaxNum;
                txtEmailAddress.Text = CurrentSite.EmailAddress;
                PopulateSiteFuelDataGrid();
                PopulateSiteAuditFuelDataGrid();
            }
        }

        private DataView _dvSiteFuels = null;

        public DataView SiteFuelsDataView
        {
            get
            {
                return _dvSiteFuels;
            }

            set
            {
                _dvSiteFuels = value;
                _dvSiteFuels.AllowNew = false;
                _dvSiteFuels.AllowEdit = false;
                _dvSiteFuels.AllowDelete = false;
                _dvSiteFuels.Table.TableName = Entity.Sys.Enums.TableNames.tblSiteFuel.ToString();
                dgSiteFuel.DataSource = SiteFuelsDataView;
            }
        }

        private DataRow SelectedSiteFuelDataRow
        {
            get
            {
                if (!(dgSiteFuel.CurrentRowIndex == -1))
                {
                    return SiteFuelsDataView[dgSiteFuel.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _dvSiteFuelAudit;

        private DataView SiteFuelAuditDataView
        {
            get
            {
                return _dvSiteFuelAudit;
            }

            set
            {
                _dvSiteFuelAudit = value;
                _dvSiteFuelAudit.AllowNew = false;
                _dvSiteFuelAudit.AllowEdit = false;
                _dvSiteFuelAudit.AllowDelete = false;
                _dvSiteFuelAudit.Table.TableName = Entity.Sys.Enums.TableNames.tblSiteFuel.ToString();
                dgSiteFuelAudit.DataSource = SiteFuelAuditDataView;
            }
        }

        private void FRMContactInfo_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int fuelId = Entity.Sys.Helper.MakeIntegerValid(Combo.get_GetSelectedItemValue(cboFuel));
            if (fuelId == 0 | fuelId == (int)Entity.Sys.Enums.FuelTypes.NA)
            {
                return;
            }

            int chargeTypeId = Entity.Sys.Helper.MakeIntegerValid(Combo.get_GetSelectedItemValue(cboChargeType));
            var siteFuels = SiteFuelsDataView.Table.Select("FuelID = " + fuelId);
            string message = "";
            bool noServiceDate = false;
            string change = Combo.get_GetSelectedItemDescription(cboFuel) + " added";
            int siteFuelID = 0;
            if (siteFuels.Length > 0)
            {
                if (!App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Servicing))
                {
                    string msg = "You do not have the necessary security permissions.";
                    throw new System.Security.SecurityException(msg);
                    return;
                }

                message += "Update Fuel?";
                change = string.Empty;
                foreach (DataRow fuel in siteFuels)
                {
                    siteFuelID = Conversions.ToInteger(fuel["SiteFuelID"]);
                    if (Entity.Sys.Helper.MakeDateTimeValid(fuel["LastServiceDate"]).Date.AddYears(1) != dtpLastServiceDate.Value.Date.AddYears(1))
                    {
                        message += Constants.vbCrLf + Constants.vbCrLf + "You have changed the last service date, do you wish to continue?";
                        change = "Updated " + Combo.get_GetSelectedItemDescription(cboFuel) + ", changed service due date from " + Conversions.ToDate(fuel["LastServiceDate"]).Date.AddYears(1) + " to " + dtpLastServiceDate.Value.Date.AddYears(1);
                    }

                    if (Entity.Sys.Helper.MakeDateTimeValid(fuel["ActualServiceDate"]).Date != dtpActualServiceDate.Value.Date)
                    {
                        message += Constants.vbCrLf + Constants.vbCrLf + "You have changed the service date, do you wish to continue?";
                        change = "Updated " + Combo.get_GetSelectedItemDescription(cboFuel) + ", changed service date from " + Conversions.ToDate(fuel["ActualServiceDate"]).Date + " to " + dtpLastServiceDate.Value.Date;
                    }

                    if (Entity.Sys.Helper.MakeIntegerValid(Combo.get_GetSelectedItemValue(cboChargeType)) != Conversions.ToInteger(fuel["SiteFuelChargeID"]))
                    {
                        change = Conversions.ToString("Updated " + Combo.get_GetSelectedItemDescription(cboFuel) + ", changed contract charge type from " + fuel["FuelChargeType"] + " to " + Combo.get_GetSelectedItemDescription(cboChargeType));
                    }
                    else
                    {
                        chargeTypeId = Conversions.ToInteger(fuel["SiteFuelChargeID"]);
                    }
                }

                if (App.ShowMessage(message, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            var currentFuel = App.DB.Sites.SiteFuel_Get(siteFuelID);
            if (currentFuel is null)
            {
                currentFuel = new Entity.Sites.SiteFuel();
                if (App.ShowMessage("Use dates selected?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    noServiceDate = true;
                }
            }

            {
                var withBlock = currentFuel;
                withBlock.SetSiteFuelID = siteFuelID;
                withBlock.SetSiteID = CurrentSite.SiteID;
                withBlock.SetFuelID = fuelId;
                if (noServiceDate)
                {
                    withBlock.LastServiceDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                    withBlock.ActualServiceDate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                }
                else
                {
                    withBlock.LastServiceDate = dtpLastServiceDate.Value.AddYears(-1);
                    withBlock.ActualServiceDate = dtpActualServiceDate.Value;
                }

                withBlock.SetSiteFuelChargeID = chargeTypeId;
            }

            try
            {
                if (!App.DB.Sites.SiteFuel_Update(currentFuel))
                    throw new Exception("Failed to save!");
                // check if site has a service date against it 
                if (CurrentSite.LastServiceDate.Date < currentFuel.LastServiceDate)
                {
                    App.DB.Sites.Site_UpdateLastServiceDate(CurrentSite.SiteID, currentFuel.LastServiceDate, currentFuel.ActualServiceDate, true);
                }
                else if (App.ShowMessage("Service due date on site is later than fuel." + Constants.vbCrLf + Constants.vbCrLf + "Do you want to update?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    App.DB.Sites.Site_UpdateLastServiceDate(CurrentSite.SiteID, currentFuel.LastServiceDate, currentFuel.ActualServiceDate, true);
                }

                if (!string.IsNullOrEmpty(change))
                    App.DB.Sites.SiteFuelAudit_Insert(CurrentSite.SiteID, change);
                PopulateSiteFuelDataGrid();
                PopulateSiteAuditFuelDataGrid();
            }
            catch (Exception ex)
            {
                App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgSiteFuel_Click(object sender, EventArgs e)
        {
            if (SelectedSiteFuelDataRow is null)
            {
                return;
            }

            var argcombo = cboFuel;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(SelectedSiteFuelDataRow["FuelID"]));
            var argcombo1 = cboChargeType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, Conversions.ToString(SelectedSiteFuelDataRow["SiteFuelChargeID"]));
            dtpLastServiceDate.Value = Entity.Sys.Helper.MakeDateTimeValid(SelectedSiteFuelDataRow["LastServiceDate"]).AddYears(1);
            if (!Information.IsDBNull(SelectedSiteFuelDataRow["ActualServiceDate"]))
            {
                dtpActualServiceDate.Value = Entity.Sys.Helper.MakeDateTimeValid(SelectedSiteFuelDataRow["ActualServiceDate"]);
            }
            else
            {
                dtpActualServiceDate.Value = Entity.Sys.Helper.MakeDateTimeValid(SelectedSiteFuelDataRow["LastServiceDate"]);
            }

            txtAddedByText.Text = Conversions.ToString(SelectedSiteFuelDataRow["Fullname"]);
            txtAddedOn.Text = Conversions.ToString(Conversions.ToDate(SelectedSiteFuelDataRow["DateAdded"]).Date);
        }

        private void btnDeleteSiteFuel_Click(object sender, EventArgs e)
        {
            if (SelectedSiteFuelDataRow is null)
            {
                return;
            }

            if (!App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Servicing))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
                return;
            }

            if (App.ShowMessage(Conversions.ToString("Remove " + SelectedSiteFuelDataRow["FuelType"] + "?" + Constants.vbCrLf + Constants.vbCrLf + "Are you sure?"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int siteFuelId = Entity.Sys.Helper.MakeIntegerValid(SelectedSiteFuelDataRow["SiteFuelID"]);
            try
            {
                if (!App.DB.Sites.SiteFuel_Delete(siteFuelId))
                    throw new Exception("Failed to delete!");
                string change = Conversions.ToString(SelectedSiteFuelDataRow["FuelType"] + " removed");
                if (!string.IsNullOrEmpty(change))
                    App.DB.Sites.SiteFuelAudit_Insert(CurrentSite.SiteID, change);
                PopulateSiteFuelDataGrid();
                PopulateSiteAuditFuelDataGrid();
            }
            catch (Exception ex)
            {
                App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgSiteFuel_MouseUp(object sender, MouseEventArgs e)
        {
            ttSiteFuel.Hide(dgSiteFuel);
            if (SelectedSiteFuelDataRow is null)
            {
                return;
            }

            string message = "";
            // check for row before we call it
            if (SelectedSiteFuelDataRow.Table.Columns.Contains("lastservicedate"))
            {
                var lsd = Entity.Sys.Helper.MakeDateTimeValid(SelectedSiteFuelDataRow["lastservicedate"]);
                if (lsd != default && lsd > System.Data.SqlTypes.SqlDateTime.MinValue.Value.AddYears(1))
                {
                    if (lsd <= DateAndTime.Now.AddDays(-365))
                    {
                        message = "Overdue";
                    }
                    else if (lsd <= DateAndTime.Now.AddDays(-352) & lsd > DateAndTime.Now.AddDays(-365))
                    {
                        message = "Third letter stage";
                    }
                    else if (lsd <= DateAndTime.Now.AddDays(-330) & lsd > DateAndTime.Now.AddDays(-352))
                    {
                        message = "Second letter stage";
                    }
                    else if (lsd <= DateAndTime.Now.AddDays(-309) & lsd > DateAndTime.Now.AddDays(-330))
                    {
                        message = "First letter stage";
                    }
                    else if (lsd <= DateAndTime.Now.AddDays(-281) & lsd > DateAndTime.Now.AddDays(-309))
                    {
                        message = "Service due soon";
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    message = "No service recorded";
                }
            }

            var hittest = dgSiteFuel.HitTest(e.X, e.Y);
            if (hittest.Type == DataGrid.HitTestType.Cell)
            {
                if (hittest.Row >= 0)
                {
                    ttSiteFuel.Show(message, dgSiteFuel, e.X, e.Y);
                }
            }
        }

        private void dgSiteFuel_Leave(object sender, EventArgs e)
        {
            ttSiteFuel.Hide(dgSiteFuel);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void PopulateSiteFuelDataGrid()
        {
            try
            {
                SiteFuelsDataView = App.DB.Sites.SiteFuel_GetAll_ForSite(CurrentSite.SiteID);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateSiteAuditFuelDataGrid()
        {
            try
            {
                SiteFuelAuditDataView = App.DB.Sites.SiteFuelAudit_Get(CurrentSite.SiteID);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateSiteService_Click(object sender, EventArgs e)
        {
            if (!App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Servicing))
            {
                string msg = "You do not have the necessary security permissions.";
                throw new System.Security.SecurityException(msg);
                return;
            }

            FRMLastServiceDate fLSD = (FRMLastServiceDate)App.ShowForm(typeof(FRMLastServiceDate), true, new object[] { CurrentSite.SiteID });
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}