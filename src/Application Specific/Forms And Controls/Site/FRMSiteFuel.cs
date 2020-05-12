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
            base.Load += FRMContactInfo_Load;
        }

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

        private TabPage _tabSiteFuel;

        private TabPage _tabAudit;

        private GroupBox _grpSiteFuels;

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

        private Button _btnDeleteSiteFuel;

        private GroupBox _grpSiteFuelUpdate;

        private Label _lblFuel;

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

        private GroupBox _grpSite;

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

        private Label _lblChargeType;

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

        private Button _btnUpdateSiteService;

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._SiteFuelTabControl = new System.Windows.Forms.TabControl();
            this._tabSiteFuel = new System.Windows.Forms.TabPage();
            this._grpSiteFuels = new System.Windows.Forms.GroupBox();
            this._grpSite = new System.Windows.Forms.GroupBox();
            this._btnUpdateSiteService = new System.Windows.Forms.Button();
            this._txtSite = new System.Windows.Forms.TextBox();
            this._lblSiteName = new System.Windows.Forms.Label();
            this._txtCustomerName = new System.Windows.Forms.TextBox();
            this._lblSite = new System.Windows.Forms.Label();
            this._txtSiteName = new System.Windows.Forms.TextBox();
            this._lblCustomer = new System.Windows.Forms.Label();
            this._txtTelephoneNum = new System.Windows.Forms.TextBox();
            this._lblTelephoneNum = new System.Windows.Forms.Label();
            this._txtEmailAddress = new System.Windows.Forms.TextBox();
            this._lblEmailAddress = new System.Windows.Forms.Label();
            this._txtFaxNum = new System.Windows.Forms.TextBox();
            this._lblFaxNum = new System.Windows.Forms.Label();
            this._grpSiteFuelUpdate = new System.Windows.Forms.GroupBox();
            this._dtpActualServiceDate = new System.Windows.Forms.DateTimePicker();
            this._lblActualServiceDate = new System.Windows.Forms.Label();
            this._lblChargeType = new System.Windows.Forms.Label();
            this._cboChargeType = new System.Windows.Forms.ComboBox();
            this._txtAddedOn = new System.Windows.Forms.TextBox();
            this._lblAddedOn = new System.Windows.Forms.Label();
            this._txtAddedByText = new System.Windows.Forms.TextBox();
            this._lblAddedBy = new System.Windows.Forms.Label();
            this._dtpLastServiceDate = new System.Windows.Forms.DateTimePicker();
            this._lblLastService = new System.Windows.Forms.Label();
            this._lblFuel = new System.Windows.Forms.Label();
            this._cboFuel = new System.Windows.Forms.ComboBox();
            this._btnSaveFuel = new System.Windows.Forms.Button();
            this._btnDeleteSiteFuel = new System.Windows.Forms.Button();
            this._dgSiteFuel = new System.Windows.Forms.DataGrid();
            this._tabAudit = new System.Windows.Forms.TabPage();
            this._grpSiteFuelAudit = new System.Windows.Forms.GroupBox();
            this._dgSiteFuelAudit = new System.Windows.Forms.DataGrid();
            this._ttSiteFuel = new System.Windows.Forms.ToolTip(this.components);
            this._SiteFuelTabControl.SuspendLayout();
            this._tabSiteFuel.SuspendLayout();
            this._grpSiteFuels.SuspendLayout();
            this._grpSite.SuspendLayout();
            this._grpSiteFuelUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgSiteFuel)).BeginInit();
            this._tabAudit.SuspendLayout();
            this._grpSiteFuelAudit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgSiteFuelAudit)).BeginInit();
            this.SuspendLayout();
            // 
            // _SiteFuelTabControl
            // 
            this._SiteFuelTabControl.Controls.Add(this._tabSiteFuel);
            this._SiteFuelTabControl.Controls.Add(this._tabAudit);
            this._SiteFuelTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._SiteFuelTabControl.Location = new System.Drawing.Point(0, 0);
            this._SiteFuelTabControl.Name = "_SiteFuelTabControl";
            this._SiteFuelTabControl.SelectedIndex = 0;
            this._SiteFuelTabControl.Size = new System.Drawing.Size(800, 557);
            this._SiteFuelTabControl.TabIndex = 2;
            // 
            // _tabSiteFuel
            // 
            this._tabSiteFuel.Controls.Add(this._grpSiteFuels);
            this._tabSiteFuel.Location = new System.Drawing.Point(4, 22);
            this._tabSiteFuel.Name = "_tabSiteFuel";
            this._tabSiteFuel.Padding = new System.Windows.Forms.Padding(3);
            this._tabSiteFuel.Size = new System.Drawing.Size(792, 531);
            this._tabSiteFuel.TabIndex = 0;
            this._tabSiteFuel.Text = "Site Fuels";
            this._tabSiteFuel.UseVisualStyleBackColor = true;
            // 
            // _grpSiteFuels
            // 
            this._grpSiteFuels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpSiteFuels.Controls.Add(this._grpSite);
            this._grpSiteFuels.Controls.Add(this._grpSiteFuelUpdate);
            this._grpSiteFuels.Controls.Add(this._dgSiteFuel);
            this._grpSiteFuels.Location = new System.Drawing.Point(5, 3);
            this._grpSiteFuels.Margin = new System.Windows.Forms.Padding(0);
            this._grpSiteFuels.Name = "_grpSiteFuels";
            this._grpSiteFuels.Padding = new System.Windows.Forms.Padding(0);
            this._grpSiteFuels.Size = new System.Drawing.Size(782, 523);
            this._grpSiteFuels.TabIndex = 14;
            this._grpSiteFuels.TabStop = false;
            this._grpSiteFuels.Text = "Site Fuel";
            // 
            // _grpSite
            // 
            this._grpSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._grpSite.Controls.Add(this._btnUpdateSiteService);
            this._grpSite.Controls.Add(this._txtSite);
            this._grpSite.Controls.Add(this._lblSiteName);
            this._grpSite.Controls.Add(this._txtCustomerName);
            this._grpSite.Controls.Add(this._lblSite);
            this._grpSite.Controls.Add(this._txtSiteName);
            this._grpSite.Controls.Add(this._lblCustomer);
            this._grpSite.Controls.Add(this._txtTelephoneNum);
            this._grpSite.Controls.Add(this._lblTelephoneNum);
            this._grpSite.Controls.Add(this._txtEmailAddress);
            this._grpSite.Controls.Add(this._lblEmailAddress);
            this._grpSite.Controls.Add(this._txtFaxNum);
            this._grpSite.Controls.Add(this._lblFaxNum);
            this._grpSite.Location = new System.Drawing.Point(489, 17);
            this._grpSite.Name = "_grpSite";
            this._grpSite.Size = new System.Drawing.Size(287, 229);
            this._grpSite.TabIndex = 115;
            this._grpSite.TabStop = false;
            this._grpSite.Text = "Site ";
            // 
            // _btnUpdateSiteService
            // 
            this._btnUpdateSiteService.Location = new System.Drawing.Point(139, 196);
            this._btnUpdateSiteService.Name = "_btnUpdateSiteService";
            this._btnUpdateSiteService.Size = new System.Drawing.Size(139, 23);
            this._btnUpdateSiteService.TabIndex = 126;
            this._btnUpdateSiteService.Text = "Update Site Service";
            this._btnUpdateSiteService.Click += new System.EventHandler(this.btnUpdateSiteService_Click);
            // 
            // _txtSite
            // 
            this._txtSite.Location = new System.Drawing.Point(117, 48);
            this._txtSite.Name = "_txtSite";
            this._txtSite.ReadOnly = true;
            this._txtSite.Size = new System.Drawing.Size(161, 21);
            this._txtSite.TabIndex = 121;
            // 
            // _lblSiteName
            // 
            this._lblSiteName.Location = new System.Drawing.Point(8, 51);
            this._lblSiteName.Name = "_lblSiteName";
            this._lblSiteName.Size = new System.Drawing.Size(80, 23);
            this._lblSiteName.TabIndex = 125;
            this._lblSiteName.Text = "Name:";
            // 
            // _txtCustomerName
            // 
            this._txtCustomerName.Location = new System.Drawing.Point(117, 20);
            this._txtCustomerName.Name = "_txtCustomerName";
            this._txtCustomerName.ReadOnly = true;
            this._txtCustomerName.Size = new System.Drawing.Size(161, 21);
            this._txtCustomerName.TabIndex = 120;
            // 
            // _lblSite
            // 
            this._lblSite.Location = new System.Drawing.Point(8, 79);
            this._lblSite.Name = "_lblSite";
            this._lblSite.Size = new System.Drawing.Size(80, 23);
            this._lblSite.TabIndex = 124;
            this._lblSite.Text = "Property:";
            // 
            // _txtSiteName
            // 
            this._txtSiteName.Location = new System.Drawing.Point(117, 76);
            this._txtSiteName.Name = "_txtSiteName";
            this._txtSiteName.ReadOnly = true;
            this._txtSiteName.Size = new System.Drawing.Size(161, 21);
            this._txtSiteName.TabIndex = 122;
            // 
            // _lblCustomer
            // 
            this._lblCustomer.Location = new System.Drawing.Point(6, 23);
            this._lblCustomer.Name = "_lblCustomer";
            this._lblCustomer.Size = new System.Drawing.Size(80, 23);
            this._lblCustomer.TabIndex = 123;
            this._lblCustomer.Text = "Customer:";
            // 
            // _txtTelephoneNum
            // 
            this._txtTelephoneNum.Location = new System.Drawing.Point(117, 104);
            this._txtTelephoneNum.MaxLength = 50;
            this._txtTelephoneNum.Name = "_txtTelephoneNum";
            this._txtTelephoneNum.ReadOnly = true;
            this._txtTelephoneNum.Size = new System.Drawing.Size(161, 21);
            this._txtTelephoneNum.TabIndex = 114;
            this._txtTelephoneNum.Tag = "Site.TelephoneNum";
            // 
            // _lblTelephoneNum
            // 
            this._lblTelephoneNum.Location = new System.Drawing.Point(8, 107);
            this._lblTelephoneNum.Name = "_lblTelephoneNum";
            this._lblTelephoneNum.Size = new System.Drawing.Size(48, 20);
            this._lblTelephoneNum.TabIndex = 119;
            this._lblTelephoneNum.Text = "Tel";
            // 
            // _txtEmailAddress
            // 
            this._txtEmailAddress.Location = new System.Drawing.Point(117, 160);
            this._txtEmailAddress.MaxLength = 100;
            this._txtEmailAddress.Name = "_txtEmailAddress";
            this._txtEmailAddress.ReadOnly = true;
            this._txtEmailAddress.Size = new System.Drawing.Size(161, 21);
            this._txtEmailAddress.TabIndex = 116;
            this._txtEmailAddress.Tag = "Site.EmailAddress";
            // 
            // _lblEmailAddress
            // 
            this._lblEmailAddress.Location = new System.Drawing.Point(8, 163);
            this._lblEmailAddress.Name = "_lblEmailAddress";
            this._lblEmailAddress.Size = new System.Drawing.Size(98, 20);
            this._lblEmailAddress.TabIndex = 118;
            this._lblEmailAddress.Text = "Email Address";
            // 
            // _txtFaxNum
            // 
            this._txtFaxNum.Location = new System.Drawing.Point(117, 132);
            this._txtFaxNum.MaxLength = 50;
            this._txtFaxNum.Name = "_txtFaxNum";
            this._txtFaxNum.ReadOnly = true;
            this._txtFaxNum.Size = new System.Drawing.Size(161, 21);
            this._txtFaxNum.TabIndex = 115;
            this._txtFaxNum.Tag = "Site.FaxNum";
            // 
            // _lblFaxNum
            // 
            this._lblFaxNum.Location = new System.Drawing.Point(8, 135);
            this._lblFaxNum.Name = "_lblFaxNum";
            this._lblFaxNum.Size = new System.Drawing.Size(50, 20);
            this._lblFaxNum.TabIndex = 117;
            this._lblFaxNum.Text = "Mobile";
            // 
            // _grpSiteFuelUpdate
            // 
            this._grpSiteFuelUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._grpSiteFuelUpdate.Controls.Add(this._dtpActualServiceDate);
            this._grpSiteFuelUpdate.Controls.Add(this._lblActualServiceDate);
            this._grpSiteFuelUpdate.Controls.Add(this._lblChargeType);
            this._grpSiteFuelUpdate.Controls.Add(this._cboChargeType);
            this._grpSiteFuelUpdate.Controls.Add(this._txtAddedOn);
            this._grpSiteFuelUpdate.Controls.Add(this._lblAddedOn);
            this._grpSiteFuelUpdate.Controls.Add(this._txtAddedByText);
            this._grpSiteFuelUpdate.Controls.Add(this._lblAddedBy);
            this._grpSiteFuelUpdate.Controls.Add(this._dtpLastServiceDate);
            this._grpSiteFuelUpdate.Controls.Add(this._lblLastService);
            this._grpSiteFuelUpdate.Controls.Add(this._lblFuel);
            this._grpSiteFuelUpdate.Controls.Add(this._cboFuel);
            this._grpSiteFuelUpdate.Controls.Add(this._btnSaveFuel);
            this._grpSiteFuelUpdate.Controls.Add(this._btnDeleteSiteFuel);
            this._grpSiteFuelUpdate.Location = new System.Drawing.Point(489, 252);
            this._grpSiteFuelUpdate.Name = "_grpSiteFuelUpdate";
            this._grpSiteFuelUpdate.Size = new System.Drawing.Size(287, 266);
            this._grpSiteFuelUpdate.TabIndex = 12;
            this._grpSiteFuelUpdate.TabStop = false;
            this._grpSiteFuelUpdate.Text = "Fuel";
            // 
            // _dtpActualServiceDate
            // 
            this._dtpActualServiceDate.Location = new System.Drawing.Point(142, 119);
            this._dtpActualServiceDate.Name = "_dtpActualServiceDate";
            this._dtpActualServiceDate.Size = new System.Drawing.Size(139, 21);
            this._dtpActualServiceDate.TabIndex = 133;
            // 
            // _lblActualServiceDate
            // 
            this._lblActualServiceDate.Location = new System.Drawing.Point(6, 125);
            this._lblActualServiceDate.Name = "_lblActualServiceDate";
            this._lblActualServiceDate.Size = new System.Drawing.Size(124, 20);
            this._lblActualServiceDate.TabIndex = 132;
            this._lblActualServiceDate.Text = "Service Date";
            // 
            // _lblChargeType
            // 
            this._lblChargeType.AutoSize = true;
            this._lblChargeType.Location = new System.Drawing.Point(6, 56);
            this._lblChargeType.Name = "_lblChargeType";
            this._lblChargeType.Size = new System.Drawing.Size(49, 13);
            this._lblChargeType.TabIndex = 131;
            this._lblChargeType.Text = "Charge";
            // 
            // _cboChargeType
            // 
            this._cboChargeType.FormattingEnabled = true;
            this._cboChargeType.Location = new System.Drawing.Point(72, 53);
            this._cboChargeType.Name = "_cboChargeType";
            this._cboChargeType.Size = new System.Drawing.Size(209, 21);
            this._cboChargeType.TabIndex = 130;
            // 
            // _txtAddedOn
            // 
            this._txtAddedOn.Location = new System.Drawing.Point(120, 185);
            this._txtAddedOn.Name = "_txtAddedOn";
            this._txtAddedOn.ReadOnly = true;
            this._txtAddedOn.Size = new System.Drawing.Size(161, 21);
            this._txtAddedOn.TabIndex = 128;
            // 
            // _lblAddedOn
            // 
            this._lblAddedOn.Location = new System.Drawing.Point(8, 188);
            this._lblAddedOn.Name = "_lblAddedOn";
            this._lblAddedOn.Size = new System.Drawing.Size(80, 23);
            this._lblAddedOn.TabIndex = 129;
            this._lblAddedOn.Text = "Added On:";
            // 
            // _txtAddedByText
            // 
            this._txtAddedByText.Location = new System.Drawing.Point(120, 152);
            this._txtAddedByText.Name = "_txtAddedByText";
            this._txtAddedByText.ReadOnly = true;
            this._txtAddedByText.Size = new System.Drawing.Size(161, 21);
            this._txtAddedByText.TabIndex = 126;
            // 
            // _lblAddedBy
            // 
            this._lblAddedBy.Location = new System.Drawing.Point(6, 155);
            this._lblAddedBy.Name = "_lblAddedBy";
            this._lblAddedBy.Size = new System.Drawing.Size(80, 23);
            this._lblAddedBy.TabIndex = 127;
            this._lblAddedBy.Text = "Added By:";
            // 
            // _dtpLastServiceDate
            // 
            this._dtpLastServiceDate.Location = new System.Drawing.Point(142, 86);
            this._dtpLastServiceDate.Name = "_dtpLastServiceDate";
            this._dtpLastServiceDate.Size = new System.Drawing.Size(139, 21);
            this._dtpLastServiceDate.TabIndex = 57;
            // 
            // _lblLastService
            // 
            this._lblLastService.Location = new System.Drawing.Point(6, 92);
            this._lblLastService.Name = "_lblLastService";
            this._lblLastService.Size = new System.Drawing.Size(114, 20);
            this._lblLastService.TabIndex = 56;
            this._lblLastService.Text = "Service Due Date";
            // 
            // _lblFuel
            // 
            this._lblFuel.AutoSize = true;
            this._lblFuel.Location = new System.Drawing.Point(8, 23);
            this._lblFuel.Name = "_lblFuel";
            this._lblFuel.Size = new System.Drawing.Size(30, 13);
            this._lblFuel.TabIndex = 55;
            this._lblFuel.Text = "Fuel";
            // 
            // _cboFuel
            // 
            this._cboFuel.FormattingEnabled = true;
            this._cboFuel.Location = new System.Drawing.Point(72, 20);
            this._cboFuel.Name = "_cboFuel";
            this._cboFuel.Size = new System.Drawing.Size(209, 21);
            this._cboFuel.TabIndex = 54;
            // 
            // _btnSaveFuel
            // 
            this._btnSaveFuel.Location = new System.Drawing.Point(191, 233);
            this._btnSaveFuel.Name = "_btnSaveFuel";
            this._btnSaveFuel.Size = new System.Drawing.Size(90, 23);
            this._btnSaveFuel.TabIndex = 9;
            this._btnSaveFuel.Text = "Save";
            this._btnSaveFuel.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _btnDeleteSiteFuel
            // 
            this._btnDeleteSiteFuel.Location = new System.Drawing.Point(9, 233);
            this._btnDeleteSiteFuel.Name = "_btnDeleteSiteFuel";
            this._btnDeleteSiteFuel.Size = new System.Drawing.Size(90, 23);
            this._btnDeleteSiteFuel.TabIndex = 10;
            this._btnDeleteSiteFuel.Text = "Delete";
            this._btnDeleteSiteFuel.Click += new System.EventHandler(this.btnDeleteSiteFuel_Click);
            // 
            // _dgSiteFuel
            // 
            this._dgSiteFuel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgSiteFuel.DataMember = "";
            this._dgSiteFuel.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgSiteFuel.Location = new System.Drawing.Point(5, 19);
            this._dgSiteFuel.Name = "_dgSiteFuel";
            this._dgSiteFuel.Size = new System.Drawing.Size(478, 499);
            this._dgSiteFuel.TabIndex = 11;
            this._dgSiteFuel.Click += new System.EventHandler(this.dgSiteFuel_Click);
            this._dgSiteFuel.Leave += new System.EventHandler(this.dgSiteFuel_Leave);
            this._dgSiteFuel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgSiteFuel_MouseUp);
            // 
            // _tabAudit
            // 
            this._tabAudit.Controls.Add(this._grpSiteFuelAudit);
            this._tabAudit.Location = new System.Drawing.Point(4, 22);
            this._tabAudit.Name = "_tabAudit";
            this._tabAudit.Padding = new System.Windows.Forms.Padding(3);
            this._tabAudit.Size = new System.Drawing.Size(792, 531);
            this._tabAudit.TabIndex = 1;
            this._tabAudit.Text = "Audit";
            this._tabAudit.UseVisualStyleBackColor = true;
            // 
            // _grpSiteFuelAudit
            // 
            this._grpSiteFuelAudit.Controls.Add(this._dgSiteFuelAudit);
            this._grpSiteFuelAudit.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grpSiteFuelAudit.Location = new System.Drawing.Point(3, 3);
            this._grpSiteFuelAudit.Name = "_grpSiteFuelAudit";
            this._grpSiteFuelAudit.Size = new System.Drawing.Size(786, 525);
            this._grpSiteFuelAudit.TabIndex = 5;
            this._grpSiteFuelAudit.TabStop = false;
            this._grpSiteFuelAudit.Text = "Site Fuel Audit";
            // 
            // _dgSiteFuelAudit
            // 
            this._dgSiteFuelAudit.DataMember = "";
            this._dgSiteFuelAudit.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgSiteFuelAudit.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgSiteFuelAudit.Location = new System.Drawing.Point(3, 17);
            this._dgSiteFuelAudit.Name = "_dgSiteFuelAudit";
            this._dgSiteFuelAudit.Size = new System.Drawing.Size(780, 505);
            this._dgSiteFuelAudit.TabIndex = 15;
            // 
            // FRMSiteFuel
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(800, 557);
            this.Controls.Add(this._SiteFuelTabControl);
            this.MinimumSize = new System.Drawing.Size(1, 1);
            this.Name = "FRMSiteFuel";
            this.ShowIcon = false;
            this.Text = "Site Fuel";
            this._SiteFuelTabControl.ResumeLayout(false);
            this._tabSiteFuel.ResumeLayout(false);
            this._grpSiteFuels.ResumeLayout(false);
            this._grpSite.ResumeLayout(false);
            this._grpSite.PerformLayout();
            this._grpSiteFuelUpdate.ResumeLayout(false);
            this._grpSiteFuelUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgSiteFuel)).EndInit();
            this._tabAudit.ResumeLayout(false);
            this._grpSiteFuelAudit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgSiteFuelAudit)).EndInit();
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
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

        public void ResetMe(int newID)
        {
        }

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
    }
}