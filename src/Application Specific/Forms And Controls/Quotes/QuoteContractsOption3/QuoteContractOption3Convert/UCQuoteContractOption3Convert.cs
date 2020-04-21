using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCQuoteContractOption3Convert : UCBase, IUserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCQuoteContractOption3Convert() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCQuoteContractOption3_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            var argc = cboContractStatus;
            Combo.SetUpCombo(ref argc, DynamicDataTables.ContractStatus, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
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

        private GroupBox _grpQuoteContractOption3;

        internal GroupBox grpQuoteContractOption3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpQuoteContractOption3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpQuoteContractOption3 != null)
                {
                }

                _grpQuoteContractOption3 = value;
                if (_grpQuoteContractOption3 != null)
                {
                }
            }
        }

        private TextBox _txtContractPrice;

        internal TextBox txtContractPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContractPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContractPrice != null)
                {
                    _txtContractPrice.LostFocus -= txtQuoteContractPrice_LostFocus;
                }

                _txtContractPrice = value;
                if (_txtContractPrice != null)
                {
                    _txtContractPrice.LostFocus += txtQuoteContractPrice_LostFocus;
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

        private Label _lblMsg;

        internal Label lblMsg
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMsg;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMsg != null)
                {
                }

                _lblMsg = value;
                if (_lblMsg != null)
                {
                }
            }
        }

        private GroupBox _gpbSite;

        internal GroupBox gpbSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbSite != null)
                {
                }

                _gpbSite = value;
                if (_gpbSite != null)
                {
                }
            }
        }

        private DataGrid _dgSites;

        internal DataGrid dgSites
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgSites;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgSites != null)
                {
                    _dgSites.CurrentCellChanged -= dgSites_Click;
                    _dgSites.Click -= dgSites_Click;
                }

                _dgSites = value;
                if (_dgSites != null)
                {
                    _dgSites.CurrentCellChanged += dgSites_Click;
                    _dgSites.Click += dgSites_Click;
                }
            }
        }

        private TextBox _txtContractReference;

        internal TextBox txtContractReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContractReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContractReference != null)
                {
                }

                _txtContractReference = value;
                if (_txtContractReference != null)
                {
                }
            }
        }

        private Label _lblContractReference;

        internal Label lblContractReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractReference != null)
                {
                }

                _lblContractReference = value;
                if (_lblContractReference != null)
                {
                }
            }
        }

        private GroupBox _grpAssets;

        internal GroupBox grpAssets
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpAssets;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpAssets != null)
                {
                }

                _grpAssets = value;
                if (_grpAssets != null)
                {
                }
            }
        }

        private DataGrid _dgAssets;

        internal DataGrid dgAssets
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgAssets;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgAssets != null)
                {
                }

                _dgAssets = value;
                if (_dgAssets != null)
                {
                }
            }
        }

        private ComboBox _cboContractStatus;

        internal ComboBox cboContractStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboContractStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboContractStatus != null)
                {
                }

                _cboContractStatus = value;
                if (_cboContractStatus != null)
                {
                }
            }
        }

        private Label _lblContractStatus;

        internal Label lblContractStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractStatus != null)
                {
                }

                _lblContractStatus = value;
                if (_lblContractStatus != null)
                {
                }
            }
        }

        private Button _btnContractNumber;

        internal Button btnContractNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnContractNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnContractNumber != null)
                {
                    _btnContractNumber.Click -= btnContractNumber_Click;
                }

                _btnContractNumber = value;
                if (_btnContractNumber != null)
                {
                    _btnContractNumber.Click += btnContractNumber_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpQuoteContractOption3 = new GroupBox();
            _btnContractNumber = new Button();
            _btnContractNumber.Click += new EventHandler(btnContractNumber_Click);
            _cboContractStatus = new ComboBox();
            _lblContractStatus = new Label();
            _grpAssets = new GroupBox();
            _dgAssets = new DataGrid();
            _txtContractPrice = new TextBox();
            _txtContractPrice.LostFocus += new EventHandler(txtQuoteContractPrice_LostFocus);
            _Label1 = new Label();
            _lblMsg = new Label();
            _gpbSite = new GroupBox();
            _dgSites = new DataGrid();
            _dgSites.CurrentCellChanged += new EventHandler(dgSites_Click);
            _dgSites.Click += new EventHandler(dgSites_Click);
            _dgSites.CurrentCellChanged += new EventHandler(dgSites_Click);
            _dgSites.Click += new EventHandler(dgSites_Click);
            _txtContractReference = new TextBox();
            _lblContractReference = new Label();
            _grpQuoteContractOption3.SuspendLayout();
            _grpAssets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgAssets).BeginInit();
            _gpbSite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSites).BeginInit();
            SuspendLayout();
            // 
            // grpQuoteContractOption3
            // 
            _grpQuoteContractOption3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpQuoteContractOption3.Controls.Add(_btnContractNumber);
            _grpQuoteContractOption3.Controls.Add(_cboContractStatus);
            _grpQuoteContractOption3.Controls.Add(_lblContractStatus);
            _grpQuoteContractOption3.Controls.Add(_grpAssets);
            _grpQuoteContractOption3.Controls.Add(_txtContractPrice);
            _grpQuoteContractOption3.Controls.Add(_Label1);
            _grpQuoteContractOption3.Controls.Add(_lblMsg);
            _grpQuoteContractOption3.Controls.Add(_gpbSite);
            _grpQuoteContractOption3.Controls.Add(_txtContractReference);
            _grpQuoteContractOption3.Controls.Add(_lblContractReference);
            _grpQuoteContractOption3.Location = new Point(8, 8);
            _grpQuoteContractOption3.Name = "grpQuoteContractOption3";
            _grpQuoteContractOption3.Size = new Size(906, 594);
            _grpQuoteContractOption3.TabIndex = 1;
            _grpQuoteContractOption3.TabStop = false;
            _grpQuoteContractOption3.Text = "Main Details";
            // 
            // btnContractNumber
            // 
            _btnContractNumber.UseVisualStyleBackColor = true;
            _btnContractNumber.Location = new Point(14, 55);
            _btnContractNumber.Name = "btnContractNumber";
            _btnContractNumber.Size = new Size(291, 23);
            _btnContractNumber.TabIndex = 2;
            _btnContractNumber.Text = "Next Suggested Contract Number";
            // 
            // cboContractStatus
            // 
            _cboContractStatus.Cursor = Cursors.Hand;
            _cboContractStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboContractStatus.Location = new Point(728, 25);
            _cboContractStatus.Name = "cboContractStatus";
            _cboContractStatus.Size = new Size(158, 21);
            _cboContractStatus.TabIndex = 4;
            _cboContractStatus.Tag = "ContractOption3.ContractStatus";
            // 
            // lblContractStatus
            // 
            _lblContractStatus.Location = new Point(621, 25);
            _lblContractStatus.Name = "lblContractStatus";
            _lblContractStatus.Size = new Size(99, 20);
            _lblContractStatus.TabIndex = 59;
            _lblContractStatus.Text = "Contract Status";
            // 
            // grpAssets
            // 
            _grpAssets.Controls.Add(_dgAssets);
            _grpAssets.Location = new Point(10, 331);
            _grpAssets.Name = "grpAssets";
            _grpAssets.Size = new Size(884, 243);
            _grpAssets.TabIndex = 57;
            _grpAssets.TabStop = false;
            _grpAssets.Text = "Assets";
            // 
            // dgAssets
            // 
            _dgAssets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgAssets.DataMember = "";
            _dgAssets.HeaderForeColor = SystemColors.ControlText;
            _dgAssets.Location = new Point(10, 21);
            _dgAssets.Name = "dgAssets";
            _dgAssets.Size = new Size(865, 217);
            _dgAssets.TabIndex = 1;
            // 
            // txtContractPrice
            // 
            _txtContractPrice.Location = new Point(424, 25);
            _txtContractPrice.MaxLength = 100;
            _txtContractPrice.Name = "txtContractPrice";
            _txtContractPrice.Size = new Size(175, 21);
            _txtContractPrice.TabIndex = 3;
            _txtContractPrice.Tag = "ContractOption3.ContractPrice";
            _txtContractPrice.Text = "";
            // 
            // Label1
            // 
            _Label1.Location = new Point(326, 25);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(99, 20);
            _Label1.TabIndex = 56;
            _Label1.Text = "Contract Price";
            // 
            // lblMsg
            // 
            _lblMsg.BackColor = Color.LightGoldenrodYellow;
            _lblMsg.BorderStyle = BorderStyle.FixedSingle;
            _lblMsg.Location = new Point(326, 55);
            _lblMsg.Name = "lblMsg";
            _lblMsg.Size = new Size(274, 23);
            _lblMsg.TabIndex = 54;
            _lblMsg.Text = "Please save before adding properties";
            _lblMsg.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gpbSite
            // 
            _gpbSite.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _gpbSite.Controls.Add(_dgSites);
            _gpbSite.Location = new Point(10, 84);
            _gpbSite.Name = "gpbSite";
            _gpbSite.Size = new Size(884, 239);
            _gpbSite.TabIndex = 53;
            _gpbSite.TabStop = false;
            _gpbSite.Text = "Properties - Click a site to view the related assets.";
            // 
            // dgSites
            // 
            _dgSites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgSites.DataMember = "";
            _dgSites.HeaderForeColor = SystemColors.ControlText;
            _dgSites.Location = new Point(10, 19);
            _dgSites.Name = "dgSites";
            _dgSites.Size = new Size(865, 210);
            _dgSites.TabIndex = 0;
            // 
            // txtContractReference
            // 
            _txtContractReference.Location = new Point(131, 25);
            _txtContractReference.MaxLength = 100;
            _txtContractReference.Name = "txtContractReference";
            _txtContractReference.Size = new Size(175, 21);
            _txtContractReference.TabIndex = 1;
            _txtContractReference.Tag = "ContractOption3.ContractReference";
            _txtContractReference.Text = "";
            // 
            // lblContractReference
            // 
            _lblContractReference.Location = new Point(14, 25);
            _lblContractReference.Name = "lblContractReference";
            _lblContractReference.Size = new Size(118, 20);
            _lblContractReference.TabIndex = 52;
            _lblContractReference.Text = "Contract Reference";
            // 
            // UCQuoteContractOption3Convert
            // 
            Controls.Add(_grpQuoteContractOption3);
            Name = "UCQuoteContractOption3Convert";
            Size = new Size(921, 616);
            _grpQuoteContractOption3.ResumeLayout(false);
            _grpAssets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgAssets).EndInit();
            _gpbSite.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgSites).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
        }

        public object LoadedItem
        {
            get
            {
                return CurrentQuoteContractOption3;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private bool _loading = false;

        private bool Loading
        {
            get
            {
                return _loading;
            }

            set
            {
                _loading = value;
            }
        }

        public event RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.QuoteContractOption3s.QuoteContractOption3 _currentQuoteContractOption3;

        public Entity.QuoteContractOption3s.QuoteContractOption3 CurrentQuoteContractOption3
        {
            get
            {
                return _currentQuoteContractOption3;
            }

            set
            {
                _currentQuoteContractOption3 = value;
                if (_currentQuoteContractOption3 is null)
                {
                    _currentQuoteContractOption3 = new Entity.QuoteContractOption3s.QuoteContractOption3();
                    _currentQuoteContractOption3.Exists = false;
                }

                if (CurrentQuoteContractOption3.Exists)
                {
                    Loading = true;
                    Populate();
                    gpbSite.Enabled = true;
                    lblMsg.Visible = false;
                    Loading = false;
                }
                else
                {
                    gpbSite.Enabled = false;
                    lblMsg.Visible = true;
                    txtContractPrice.Text = Strings.Format(Conversions.ToDouble(0.0), "C");
                }

                Sites = App.DB.QuoteContractOption3Site.QuoteContractOption3Site_GetSelected_ForQuoteContract(CurrentQuoteContractOption3.QuoteContractID);
                foreach (DataRow dr in Sites.Table.Rows)
                {
                    SetAssetsDurations = App.DB.QuoteContractOption3SiteAssetDurations.QuoteContractOption3SiteAssetDuration_GetAll_ForQuoteContractSiteID(Conversions.ToInteger(dr["QuoteContractSiteID"]));
                    SetAssets = CreateAssetDataView(Conversions.ToInteger(dr["SiteID"]), Conversions.ToInteger(dr["QuoteContractSiteID"]));
                    Visits.Add(new ArrayList());
                }
            }
        }

        private DataView _Sites;

        private DataView Sites
        {
            get
            {
                return _Sites;
            }

            set
            {
                _Sites = value;
                _Sites.Table.TableName = Entity.Sys.Enums.TableNames.tblQuoteContractOption3Site.ToString();
                _Sites.AllowNew = false;
                _Sites.AllowEdit = true;
                _Sites.AllowDelete = false;
                dgSites.DataSource = Sites;
            }
        }

        private DataRow SelectedSiteDataRow
        {
            get
            {
                if (!(dgSites.CurrentRowIndex == -1))
                {
                    return Sites[dgSites.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private ArrayList _Assets = new ArrayList();

        private ArrayList Assets
        {
            get
            {
                return _Assets;
            }
        }

        private object SetAssets
        {
            set
            {
                value.Table.TableName = Entity.Sys.Enums.TableNames.tblAsset.ToString();
                value.AllowNew = false;
                value.AllowEdit = true;
                value.AllowDelete = false;
                _Assets.Add(value);
            }
        }

        private ArrayList _AssetsDurations = new ArrayList();

        public ArrayList AssetsDurations
        {
            get
            {
                return _AssetsDurations;
            }
        }

        private object SetAssetsDurations
        {
            set
            {
                value.Table.TableName = Entity.Sys.Enums.TableNames.tblAsset.ToString();
                value.AllowNew = false;
                value.AllowEdit = true;
                value.AllowDelete = false;
                _AssetsDurations.Add(value);
            }
        }

        private ArrayList _Visits = new ArrayList();

        private ArrayList Visits
        {
            get
            {
                return _Visits;
            }

            set
            {
                _Visits = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void SetupSitesDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgSites);
            var tStyle = dgSites.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            dgSites.ReadOnly = false;
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;

            // Dim Tick As New DataGridBoolColumn
            // Tick.HeaderText = ""
            // Tick.MappingName = "Tick"
            // Tick.ReadOnly = True
            // Tick.Width = 50
            // Tick.NullText = ""
            // tStyle.GridColumnStyles.Add(Tick)

            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Property";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 250;
            Site.NullText = "";
            tStyle.GridColumnStyles.Add(Site);
            var ContractSiteReference = new DataGridLabelColumn();
            ContractSiteReference.Format = "";
            ContractSiteReference.FormatInfo = null;
            ContractSiteReference.HeaderText = "Property Reference";
            ContractSiteReference.MappingName = "QuoteContractSiteReference";
            ContractSiteReference.ReadOnly = true;
            ContractSiteReference.Width = 100;
            ContractSiteReference.NullText = "";
            tStyle.GridColumnStyles.Add(ContractSiteReference);
            var StartDate = new DataGridEditableTextBoxColumn();
            StartDate.Format = "dd/MM/yyyy";
            StartDate.FormatInfo = null;
            StartDate.HeaderText = "Start Date";
            StartDate.MappingName = "StartDate";
            StartDate.ReadOnly = false;
            StartDate.Width = 75;
            StartDate.NullText = "";
            tStyle.GridColumnStyles.Add(StartDate);
            var EndDate = new DataGridEditableTextBoxColumn();
            EndDate.Format = "dd/MM/yyyy";
            EndDate.FormatInfo = null;
            EndDate.HeaderText = "End Date";
            EndDate.MappingName = "EndDate";
            EndDate.ReadOnly = false;
            EndDate.Width = 75;
            EndDate.NullText = "";
            tStyle.GridColumnStyles.Add(EndDate);
            var FirstVisitDate = new DataGridEditableTextBoxColumn();
            FirstVisitDate.Format = "dd/MM/yyyy";
            FirstVisitDate.FormatInfo = null;
            FirstVisitDate.HeaderText = "First Visit Date";
            FirstVisitDate.MappingName = "FirstVisitDate";
            FirstVisitDate.ReadOnly = false;
            FirstVisitDate.Width = 120;
            FirstVisitDate.NullText = "";
            tStyle.GridColumnStyles.Add(FirstVisitDate);
            var VisitFrequency = new DataGridComboBoxColumn();
            VisitFrequency.HeaderText = "Visit Frequency";
            VisitFrequency.MappingName = "VisitFrequencyID";
            VisitFrequency.ReadOnly = false;
            VisitFrequency.Width = 100;
            VisitFrequency.ComboBox.DataSource = App.DB.QuoteContractOption3.VisitFrequency_Get();
            VisitFrequency.ComboBox.DisplayMember = "DisplayMember";
            VisitFrequency.ComboBox.ValueMember = "VisitFrequencyID";
            tStyle.GridColumnStyles.Add(VisitFrequency);
            var InvoiceFrequency = new DataGridComboBoxColumn();
            InvoiceFrequency.HeaderText = "Invoice Frequency";
            InvoiceFrequency.MappingName = "InvoiceFrequencyID";
            InvoiceFrequency.ReadOnly = false;
            InvoiceFrequency.Width = 120;
            InvoiceFrequency.ComboBox.DataSource = App.DB.QuoteContractOption3.InvoiceFrequency_Get();
            InvoiceFrequency.ComboBox.DisplayMember = "DisplayMember";
            InvoiceFrequency.ComboBox.ValueMember = "InvoiceFrequencyID";
            tStyle.GridColumnStyles.Add(InvoiceFrequency);
            tStyle.ReadOnly = false;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblQuoteContractOption3Site.ToString();
            dgSites.TableStyles.Add(tStyle);
        }

        public void SetupAssetsDataGrid(DateTime startdate, DateTime enddate)
        {
            Entity.Sys.Helper.SetUpDataGrid(dgAssets);
            var tStyle = dgAssets.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            dgAssets.ReadOnly = false;
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            var Product = new DataGridLabelColumn();
            Product.Format = "";
            Product.FormatInfo = null;
            Product.HeaderText = "Product";
            Product.MappingName = "Product";
            Product.ReadOnly = true;
            Product.Width = 150;
            Product.NullText = "";
            tStyle.GridColumnStyles.Add(Product);
            var Location = new DataGridLabelColumn();
            Location.Format = "";
            Location.FormatInfo = null;
            Location.HeaderText = "Location";
            Location.MappingName = "Location";
            Location.ReadOnly = true;
            Location.Width = 90;
            Location.NullText = "";
            tStyle.GridColumnStyles.Add(Location);
            var SerialNum = new DataGridLabelColumn();
            SerialNum.Format = "";
            SerialNum.FormatInfo = null;
            SerialNum.HeaderText = "Serial Number";
            SerialNum.MappingName = "SerialNum";
            SerialNum.ReadOnly = true;
            SerialNum.Width = 90;
            SerialNum.NullText = "";
            tStyle.GridColumnStyles.Add(SerialNum);
            int numOfMonths = 0;
            numOfMonths = Conversions.ToInteger(Math.Ceiling((decimal)DateAndTime.DateDiff(DateInterval.Month, startdate, enddate)));
            for (int i = 0, loopTo = numOfMonths; i <= loopTo; i++)
            {
                var dglc = new Contract3AssetsColourColumnConvert();
                dglc.theUserControl = this;
                dglc.HeaderText = Strings.Format(startdate.AddMonths(i), "MMM yy");
                dglc.MappingName = Strings.Format(startdate.AddMonths(i), "MMM yy");
                dglc.ReadOnly = false;
                dglc.Width = 50;
                dglc.NullText = "-";
                tStyle.GridColumnStyles.Add(dglc);
            }

            tStyle.ReadOnly = false;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblAsset.ToString();
            dgAssets.TableStyles.Add(tStyle);
        }

        private void UCQuoteContractOption3_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
            SetupSitesDataGrid();
        }

        private void txtQuoteContractPrice_LostFocus(object sender, EventArgs e)
        {
            string price = "";
            if (txtContractPrice.Text.Trim().Length == 0)
            {
                price = Strings.Format(0.0, "C");
            }
            else if (!Information.IsNumeric(txtContractPrice.Text.Replace("£", "")))
            {
                price = Strings.Format(0.0, "C");
            }
            else
            {
                price = Strings.Format(Conversions.ToDouble(txtContractPrice.Text.Replace("£", "")), "C");
            }

            txtContractPrice.Text = price;
        }

        private void dgSites_Click(object sender, EventArgs e)
        {
            if (SelectedSiteDataRow is object)
            {
                grpAssets.Text = Conversions.ToString("Assets for " + SelectedSiteDataRow["Site"]);
                if (Information.IsDBNull(SelectedSiteDataRow["StartDate"]) == false & Information.IsDBNull(SelectedSiteDataRow["EndDate"]) == false)
                {
                    Assets[dgSites.CurrentRowIndex] = CreateAssetDataView(Conversions.ToInteger(SelectedSiteDataRow["SiteID"]), Conversions.ToInteger(SelectedSiteDataRow["QuoteContractSiteID"]));
                    dgAssets.DataSource = Assets[dgSites.CurrentRowIndex];
                }
                else
                {
                    dgAssets.DataSource = null;
                }
            }
        }

        private void btnContractNumber_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMAvailableContractNos), true, new object[] { txtContractReference, this });
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void UpdateDurations(double Duration, DateTime mappingName)
        {
            bool found = false;
            DataView dv = (DataView)AssetsDurations[dgSites.CurrentRowIndex];
            foreach (DataRow dr in dv.Table.Rows)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["CompareMonth"], Strings.Format(mappingName, "yyyyMM"), false) & Operators.ConditionalCompareObjectEqual(dr["AssetID"], ((DataView)dgAssets.DataSource).Table.Rows[dgAssets.CurrentRowIndex]["AssetID"], false)))
                {
                    dr["visitDuration"] = Duration;
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                DataRow newDr;
                newDr = dv.Table.NewRow();
                newDr["CompareMonth"] = Strings.Format(mappingName, "yyyyMM");
                newDr["AssetID"] = ((DataView)dgAssets.DataSource).Table.Rows[dgAssets.CurrentRowIndex]["AssetID"];
                newDr["visitDuration"] = Duration;
                newDr["ScheduledMonth"] = mappingName;
                dv.Table.Rows.Add(newDr);
            }

            AssetsDurations[dgSites.CurrentRowIndex] = dv;
        }

        private DataView CreateAssetDataView(int siteID, int quoteContractSiteID)
        {
            DateTime estVisitDate = default;
            int numOfVisits = 0;
            int visitFreqInMonths = 0;
            int numOfMonths = 0;
            var assetsDV = new DataView();
            assetsDV = App.DB.Asset.Asset_GetForSite(siteID);
            numOfMonths = Conversions.ToInteger(Math.Ceiling((decimal)DateAndTime.DateDiff(DateInterval.Month, Conversions.ToDate(SelectedSiteDataRow["StartDate"]), Conversions.ToDate(SelectedSiteDataRow["EndDate"]))));
            var newVisits = new ArrayList();
            for (int i = 0, loopTo = numOfMonths; i <= loopTo; i++)
                assetsDV.Table.Columns.Add(Strings.Format(SelectedSiteDataRow["StartDate"].AddMonths(i), "MMM yy"));
            if (Conversions.ToBoolean(SelectedSiteDataRow["VisitFrequencyID"] > 0))
            {
                if (Conversions.ToBoolean(SelectedSiteDataRow["FirstVisitDate"].Date >= SelectedSiteDataRow["StartDate"].Date & SelectedSiteDataRow["FirstVisitDate"].Date <= SelectedSiteDataRow["EndDate"].Date))
                {
                    numOfVisits = 0;
                    visitFreqInMonths = 0;
                    var switchExpr = (Entity.Sys.Enums.VisitFrequency)Conversions.ToInteger(SelectedSiteDataRow["VisitFrequencyID"]);
                    switch (switchExpr)
                    {
                        case Entity.Sys.Enums.VisitFrequency.Annually:
                            {
                                visitFreqInMonths = 12;
                                break;
                            }

                        case Entity.Sys.Enums.VisitFrequency.Bi_Annually:
                            {
                                visitFreqInMonths = 6;
                                break;
                            }

                        case Entity.Sys.Enums.VisitFrequency.Monthly:
                            {
                                visitFreqInMonths = 1;
                                break;
                            }

                        case Entity.Sys.Enums.VisitFrequency.Quarterly:
                            {
                                visitFreqInMonths = 3;
                                break;
                            }
                    }

                    numOfVisits = Conversions.ToInteger(Math.Ceiling(DateAndTime.DateDiff(DateInterval.Month, Conversions.ToDate(SelectedSiteDataRow["StartDate"]), Conversions.ToDate(SelectedSiteDataRow["EndDate"])) / (double)visitFreqInMonths));
                    if (numOfVisits == 0)
                    {
                        numOfVisits = 1;
                    }

                    estVisitDate = Conversions.ToDate(SelectedSiteDataRow["FirstVisitDate"].Date + " 09:00:00");
                    for (int i = 1, loopTo1 = numOfVisits; i <= loopTo1; i++)
                    {
                        if (estVisitDate >= Conversions.ToDate(Strings.Format(SelectedSiteDataRow["StartDate"].Date, "dd/MM/yyyy") + " 09:00") & estVisitDate <= Conversions.ToDate(Strings.Format(SelectedSiteDataRow["EndDate"].Date, "dd/MM/yyyy") + " 09:00"))
                        {

                            // I WANT TO STORE THE DATE IT SHOULD HAVE BEEN SO THE DATES AT THE START OF THE MONTH DON@T CREEP UP FOR EAXMPLE - ALP
                            var shouldHaveBeenDate = estVisitDate;
                            // MAKE SURE WE DON'T BOOK A SATURADY OR SUNDAY
                            if (estVisitDate.DayOfWeek == DayOfWeek.Saturday)
                            {
                                estVisitDate = estVisitDate.AddDays(2);
                            }
                            else if (estVisitDate.DayOfWeek == DayOfWeek.Sunday)
                            {
                                estVisitDate = estVisitDate.AddDays(1);
                            }

                            foreach (DataRow drAsset in assetsDV.Table.Rows)
                            {
                                DataRow[] rVal;
                                rVal = ((DataView)AssetsDurations[dgSites.CurrentRowIndex]).Table.Select(Conversions.ToString("CompareMonth=" + Strings.Format(estVisitDate, "yyyyMM") + " AND AssetID=" + drAsset["AssetID"]));
                                if (rVal.Length > 0)
                                {
                                    drAsset[Strings.Format(estVisitDate, "MMM yy")] = rVal[0]["VisitDuration"];
                                }
                                else
                                {
                                    drAsset[Strings.Format(estVisitDate, "MMM yy")] = "0";
                                }
                            }

                            newVisits.Add(estVisitDate);
                            estVisitDate = shouldHaveBeenDate.AddMonths(visitFreqInMonths);
                        }
                    }
                }
                else
                {
                }
            }

            if (Visits.Count > 0)
            {
                Visits[dgSites.CurrentRowIndex] = newVisits;
            }

            SetupAssetsDataGrid(Conversions.ToDate(SelectedSiteDataRow["StartDate"]), Conversions.ToDate(SelectedSiteDataRow["EndDate"]));
            Cursor = Cursors.Default;
            assetsDV.AllowDelete = false;
            assetsDV.AllowEdit = true;
            assetsDV.AllowNew = false;
            return assetsDV;
        }

        private void Populate(int ID = 0)
        {
            if (!(ID == 0))
            {
                CurrentQuoteContractOption3 = App.DB.QuoteContractOption3.QuoteContractOption3_Get(ID);
            }

            txtContractReference.Text = CurrentQuoteContractOption3.QuoteContractReference;
            txtContractPrice.Text = Strings.Format(CurrentQuoteContractOption3.QuoteContractPrice, "C");
            var argcombo = cboContractStatus;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(Entity.Sys.Enums.ContractStatus.Active));
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // CREATE A NEW CONTRACT
                var newContract = new Entity.ContractOption3s.ContractOption3();
                newContract.SetContractPrice = txtContractPrice.Text.Trim().Replace("£", "");
                newContract.SetContractReference = txtContractReference.Text;
                newContract.SetContractStatusID = Combo.get_GetSelectedItemValue(cboContractStatus);
                newContract.SetCustomerID = CurrentQuoteContractOption3.CustomerID;
                newContract.SetQuoteContractID = CurrentQuoteContractOption3.QuoteContractID;

                // VALIDATE THE CONTRACT
                var conVal = new Entity.ContractOption3s.ContractOption3Validator();
                conVal.Validate(newContract);

                // VALIDATE THE SITES
                var sitVal = new Entity.ContractOption3Sites.ContractOption3SiteValidator();
                int cnt = 0;
                foreach (DataRow drSite in Sites.Table.Rows)
                {
                    var valSite = new Entity.ContractOption3Sites.ContractOption3Site();
                    valSite.SetContractSiteReference = drSite["QuoteContractSiteReference"];
                    valSite.SetInvoiceFrequencyID = drSite["InvoiceFrequencyID"];
                    valSite.SetPropertyID = drSite["SiteID"];
                    valSite.SetSitePrice = drSite["SitePrice"];
                    valSite.SetVisitFrequencyID = drSite["VisitFrequencyID"];
                    valSite.StartDate = Conversions.ToDate(drSite["StartDate"]);
                    valSite.EndDate = Conversions.ToDate(drSite["EndDate"]);
                    valSite.FirstVisitDate = Conversions.ToDate(drSite["FirstVisitDate"]);
                    valSite.FirstInvoiceDate = Conversions.ToDate(drSite["FirstVisitDate"]);
                    valSite.SetInvoiceAddressID = drSite["SiteID"];
                    valSite.SetInvoiceAddressTypeID = Conversions.ToInteger(Entity.Sys.Enums.InvoiceAddressType.Site);
                    sitVal.Validate(valSite, (DataView)Assets[cnt]);
                    cnt += 1;
                }

                // INSERT CONTRACT
                newContract = App.DB.ContractOption3.Insert(newContract);

                // SET SITE with CONTRACT IDs
                cnt = 0;
                foreach (DataRow drSite in Sites.Table.Rows)
                {
                    var newSite = new Entity.ContractOption3Sites.ContractOption3Site();
                    newSite.SetContractSiteReference = drSite["QuoteContractSiteReference"];
                    newSite.SetInvoiceFrequencyID = drSite["InvoiceFrequencyID"];
                    newSite.SetPropertyID = drSite["SiteID"];
                    newSite.SetSitePrice = drSite["SitePrice"];
                    newSite.SetVisitFrequencyID = drSite["VisitFrequencyID"];
                    newSite.StartDate = Conversions.ToDate(drSite["StartDate"]);
                    newSite.EndDate = Conversions.ToDate(drSite["EndDate"]);
                    newSite.FirstVisitDate = Conversions.ToDate(drSite["FirstVisitDate"]);
                    newSite.SetContractID = newContract.ContractID;
                    newSite.FirstInvoiceDate = Conversions.ToDate(drSite["FirstVisitDate"]);
                    newSite.SetInvoiceAddressID = drSite["SiteID"];
                    newSite.SetInvoiceAddressTypeID = Conversions.ToInteger(Entity.Sys.Enums.InvoiceAddressType.Site);
                    // INSERT SITES - Setting assets
                    newSite = App.DB.ContractOption3Site.Insert(newSite);
                    InsertInvoiceToBeRaiseLines(newSite);
                    App.DB.ContractOption3SiteAsset.ContractOption3SiteAssetDuration_Delete(newSite.ContractSiteID);
                    foreach (object vDate in (IEnumerable)Visits[cnt]) // For each Visit
                    {
                        var oJob = new Entity.Jobs.Job();
                        oJob = CreateJob(Conversions.ToDate(vDate), newSite, cnt, newContract);

                        // CREATE PPM VISIT RECORD
                        var PPM = new Entity.ContractOption3SitePPMVisits.ContractOption3SitePPMVisit();
                        PPM.SetContractSiteID = newSite.ContractSiteID;
                        PPM.VisitDate = Conversions.ToDate(vDate);
                        PPM.SetJobID = oJob.JobID;
                        App.DB.ContractOption3SitePPMVisit.Insert(PPM);
                    }

                    cnt += 1;
                }

                StateChanged?.Invoke(CurrentQuoteContractOption3.QuoteContractID);
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

        private void InsertInvoiceToBeRaiseLines(Entity.ContractOption3Sites.ContractOption3Site CurrentContractOption3Site)
        {
            int numberOfInvoicesToRaise = 0;
            var switchExpr = (Entity.Sys.Enums.InvoiceFrequency)Conversions.ToInteger(CurrentContractOption3Site.InvoiceFrequencyID);
            switch (switchExpr)
            {
                case Entity.Sys.Enums.InvoiceFrequency.Annually:
                    {
                        numberOfInvoicesToRaise = Conversions.ToInteger(DateAndTime.DateDiff(DateInterval.Year, CurrentContractOption3Site.StartDate, CurrentContractOption3Site.EndDate));
                        break;
                    }

                case Entity.Sys.Enums.InvoiceFrequency.Bi_Annually:
                    {
                        numberOfInvoicesToRaise = (int)(DateAndTime.DateDiff(DateInterval.Year, CurrentContractOption3Site.StartDate, CurrentContractOption3Site.EndDate) * 2);
                        break;
                    }

                case Entity.Sys.Enums.InvoiceFrequency.Monthly:
                    {
                        numberOfInvoicesToRaise = Conversions.ToInteger(DateAndTime.DateDiff(DateInterval.Month, CurrentContractOption3Site.StartDate, CurrentContractOption3Site.EndDate));
                        break;
                    }

                case Entity.Sys.Enums.InvoiceFrequency.Per_Visit:
                    {
                        break;
                    }
                // Invoice the visit
                case Entity.Sys.Enums.InvoiceFrequency.Quarterly:
                    {
                        numberOfInvoicesToRaise = (int)(DateAndTime.DateDiff(DateInterval.Month, CurrentContractOption3Site.StartDate, CurrentContractOption3Site.EndDate) / (double)3);
                        break;
                    }

                case Entity.Sys.Enums.InvoiceFrequency.Weekly:
                    {
                        numberOfInvoicesToRaise = (int)(DateAndTime.DateDiff(DateInterval.Day, CurrentContractOption3Site.StartDate, CurrentContractOption3Site.EndDate) / (double)7);
                        break;
                    }
            }

            var raiseDate = CurrentContractOption3Site.FirstInvoiceDate;
            for (int i = 1, loopTo = numberOfInvoicesToRaise; i <= loopTo; i++)
            {
                var invToBeRaised = new Entity.InvoiceToBeRaiseds.InvoiceToBeRaised();
                invToBeRaised.SetAddressLinkID = CurrentContractOption3Site.InvoiceAddressID;
                invToBeRaised.SetAddressTypeID = CurrentContractOption3Site.InvoiceAddressTypeID;
                invToBeRaised.SetInvoiceTypeID = Conversions.ToInteger(Entity.Sys.Enums.InvoiceType.Contract_Option3);
                invToBeRaised.SetLinkID = CurrentContractOption3Site.ContractSiteID;
                invToBeRaised.RaiseDate = raiseDate;
                App.DB.InvoiceToBeRaised.Insert(invToBeRaised);
                var switchExpr1 = (Entity.Sys.Enums.InvoiceFrequency)Conversions.ToInteger(CurrentContractOption3Site.InvoiceFrequencyID);
                switch (switchExpr1)
                {
                    case Entity.Sys.Enums.InvoiceFrequency.Annually:
                        {
                            raiseDate = raiseDate.AddYears(1);
                            break;
                        }

                    case Entity.Sys.Enums.InvoiceFrequency.Bi_Annually:
                        {
                            raiseDate = raiseDate.AddMonths(6);
                            break;
                        }

                    case Entity.Sys.Enums.InvoiceFrequency.Monthly:
                        {
                            raiseDate = raiseDate.AddMonths(1);
                            break;
                        }

                    case Entity.Sys.Enums.InvoiceFrequency.Quarterly:
                        {
                            raiseDate = raiseDate.AddMonths(3);
                            break;
                        }

                    case Entity.Sys.Enums.InvoiceFrequency.Weekly:
                        {
                            raiseDate = raiseDate.AddDays(7);
                            break;
                        }
                }
            }
        }

        private Entity.Jobs.Job CreateJob(DateTime vDate, Entity.ContractOption3Sites.ContractOption3Site newSite, int currentSiteRow, Entity.ContractOption3s.ContractOption3 curContract)
        {
            double durationTotal = 0;
            double slotDuration = 0;
            int numOfSlotsNeeded = 0;
            DateTime dayStartDate = default;
            DateTime dayEndDate = default;
            double workingDayMinutes = 0;
            int workingDaySlots = 0;
            int numOfDaysNeeded = 0;
            int numOfMintuesNeeded = 0;

            // CREATE new Job
            var oJob = new Entity.Jobs.Job();
            oJob.SetContractID = newSite.ContractID;
            oJob.SetCreatedByUserID = App.loggedInUser.UserID;
            oJob.SetJobDefinitionEnumID = Entity.Sys.Helper.MakeIntegerValid(Entity.Sys.Enums.JobDefinition.Contract);
            var JobNumber = new JobNumber();
            JobNumber = App.DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.Contract);
            oJob.SetJobNumber = JobNumber.Prefix + JobNumber.Number;
            oJob.SetPONumber = "";
            oJob.SetQuoteID = 0;
            oJob.SetPropertyID = newSite.PropertyID;
            oJob.SetStatusEnumID = Entity.Sys.Helper.MakeIntegerValid(Entity.Sys.Enums.JobStatus.Open);
            oJob.DateCreated = DateAndTime.Now;

            // IF CONTRACT IS NOT ACTIVE, FLAG JOB AS DELETED
            if ((Entity.Sys.Enums.ContractStatus)Conversions.ToInteger(curContract.ContractStatusID) == Entity.Sys.Enums.ContractStatus.Inactive)
            {
                oJob.SetDeleted = true;
            }

            // FOR EACH ASSET FOR THE VISIT DATE
            foreach (DataRow rAsset in ((DataView)Assets[currentSiteRow]).Table.Rows)
            {
                // IF DURATION > 0 THEN SAVE DURATION
                if (Conversions.ToBoolean(rAsset[Strings.Format(vDate, "MMM yy")] > 0))
                {
                    var assetDuration = new Entity.ContractOption3SiteAsset.ContractOption3SiteAsset();
                    assetDuration.SetContractSiteID = newSite.ContractSiteID;
                    assetDuration.SetAssetID = rAsset["AssetID"];
                    assetDuration.ScheduledMonth = vDate;
                    assetDuration.SetVisitDuration = rAsset[Strings.Format(vDate, "MMM yy")];
                    App.DB.ContractOption3SiteAsset.Insert(assetDuration);

                    // ADD TO JOB ASSETS
                    var jobAsset = new Entity.JobAssets.JobAsset();
                    jobAsset.SetAssetID = rAsset["AssetID"];
                    oJob.Assets.Add(jobAsset);

                    // SUM UP DURATION
                    durationTotal += Entity.Sys.Helper.MakeDoubleValid(rAsset[Strings.Format(vDate, "MMM yy")]);
                }
            }

            // CREATE JOB OF WORK
            var ojobOfWork = new Entity.JobOfWorks.JobOfWork();
            ojobOfWork.IgnoreExceptionsOnSetMethods = true;

            // IF CONTRACT IS NOT ACTIVE, FLAG JOB AS DELETED
            if ((Entity.Sys.Enums.ContractStatus)Conversions.ToInteger(curContract.ContractStatusID) == Entity.Sys.Enums.ContractStatus.Inactive)
            {
                ojobOfWork.SetDeleted = true;
            }

            // CREATE JOB ITEM - just on for default
            var ojobItem = new Entity.JobItems.JobItem();
            ojobItem.IgnoreExceptionsOnSetMethods = true;
            ojobItem.SetSummary = Entity.Sys.Helper.MakeStringValid("PPM Contract Visit");
            ojobOfWork.JobItems.Add(ojobItem);

            // SYSTEM NUMBER OF MINUTES IN A SLOTS
            var settings = new Entity.Management.Settings();
            settings = App.DB.Manager.Get();
            slotDuration = settings.TimeSlot;

            // NUM OF SLOTS NEEDED FOR VISIT
            if (durationTotal > 0)
            {
                numOfMintuesNeeded = (int)(durationTotal * 60);
                numOfSlotsNeeded = (int)(numOfMintuesNeeded / slotDuration);
            }
            else
            {
                numOfSlotsNeeded = 1;
            }

            // NEED SEE IF TOTAL DURATION IS GREATER THAN WORKING DAY
            dayStartDate = Entity.Sys.Helper.MakeDateTimeValid("01/01/1900 " + settings.WorkingHoursStart);
            dayEndDate = Entity.Sys.Helper.MakeDateTimeValid("01/01/1900 " + settings.WorkingHoursEnd);
            // NUMBER OF SLOTS IN A DAY
            workingDayMinutes = DateAndTime.DateDiff(DateInterval.Minute, dayStartDate, dayEndDate);
            workingDaySlots = (int)(workingDayMinutes / slotDuration);
            numOfDaysNeeded = Conversions.ToInteger(Math.Ceiling(numOfSlotsNeeded / (double)workingDaySlots));
            var matches = new ArrayList(); // Arraylist of arraylists
                                           // FIND A SUITABLE ENGINEER FIRST
            matches = GetEngineersAndVisits(numOfDaysNeeded, workingDaySlots, vDate, newSite);
            for (int i = 0, loopTo = numOfDaysNeeded - 1; i <= loopTo; i++)
            {
                var oEngVisit = new Entity.EngineerVisits.EngineerVisit();
                oEngVisit.IgnoreExceptionsOnSetMethods = true;
                try
                {
                    oEngVisit.SetEngineerID = Entity.Sys.Helper.MakeIntegerValid(((ArrayList)matches[i])[1]);
                }
                catch (Exception ex)
                {
                    oEngVisit.SetEngineerID = 0;
                }

                oEngVisit.SetNotesToEngineer = "PPM Contract Visit";
                if (oEngVisit.EngineerID > 0)
                {
                    oEngVisit.StartDateTime = Conversions.ToDate(((ArrayList)matches[i])[0]);
                    if (numOfMintuesNeeded > workingDayMinutes)
                    {
                        oEngVisit.EndDateTime = Conversions.ToDate(((ArrayList)matches[i])[0].AddHours(Math.Ceiling(workingDayMinutes / (double)60)));
                        numOfMintuesNeeded -= workingDayMinutes;
                    }
                    else
                    {
                        oEngVisit.EndDateTime = Conversions.ToDate(((ArrayList)matches[i])[0].AddHours(Math.Ceiling((double)numOfMintuesNeeded / (double)60)));
                    }

                    oEngVisit.SetStatusEnumID = Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Scheduled);
                }
                else
                {
                    oEngVisit.StartDateTime = DateTime.MinValue;
                    oEngVisit.EndDateTime = DateTime.MinValue;
                    oEngVisit.SetStatusEnumID = Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule);
                }

                ojobOfWork.EngineerVisits.Add(oEngVisit);
            }

            // ADD JOB OF WORK TO JOB
            oJob.JobOfWorks.Add(ojobOfWork);
            // INSERT JOB
            oJob = App.DB.Job.Insert(oJob);
            return oJob;
        }

        private ArrayList GetEngineersAndVisits(int numOfDaysNeeded, int numOfSlotsInADay, DateTime estVisitDate, Entity.ContractOption3Sites.ContractOption3Site newSite)
        {
            var site = new Entity.Sites.Site();
            var matches = new ArrayList();
            string postcode = "";
            DataView postcodeEngineers = null;
            int cntPostcodeEng = 0;
            int randomNum = 0;

            // SEE IF THE SITE HAS A DEFAULT ENGINEER
            site = App.DB.Sites.Get(newSite.PropertyID);
            if (site.EngineerID > 0)
            {
                // IF THE SITE DOES, ARE THEY AVAILABLE ON THE DAY OR FOLLOWING 4 DAYS ( NOT WEEKENDS)
                matches = CheckAvailability(estVisitDate, site.EngineerID, numOfDaysNeeded, numOfSlotsInADay);
            }
            // IF A ENG & SLOT IS FOUND, RETURN
            if (matches.Count > 0)
            {
                return matches;
            }

            // NO MATCH FOUND FOR SITE ENGINEER
            // IS THERE A MATCH FOR POSTCODE ENGINEERS
            postcode = site.Postcode.Replace("-", "");
            postcode = postcode.Replace(" ", "");
            postcode = postcode.Substring(0, postcode.Length - 3);

            // GET ALL THE ENGINEERS THAT COVER THAT POSTCODE
            postcodeEngineers = App.DB.EngineerPostalRegion.EngineerPostalRegion_Get_For_Postcode(postcode);
            cntPostcodeEng = postcodeEngineers.Table.Rows.Count;
            if (cntPostcodeEng > 0)
            {
                for (int i = 0, loopTo = cntPostcodeEng - 1; i <= loopTo; i++)
                {
                    VBMath.Randomize();
                    randomNum = Conversions.ToInteger(Conversion.Int(postcodeEngineers.Table.Rows.Count * VBMath.Rnd() + 1)) - 1;
                    matches = CheckAvailability(estVisitDate, Conversions.ToInteger(postcodeEngineers.Table.Rows[randomNum]["EngineerID"]), numOfDaysNeeded, numOfSlotsInADay);

                    // IF A ENG & SLOT IS FOUND, RETURN
                    if (matches.Count > 0)
                    {
                        return matches;
                    }
                    else
                    {
                        postcodeEngineers.Table.Rows.Remove(postcodeEngineers.Table.Rows[randomNum]);
                    }
                }
            }

            return matches;
        }

        private ArrayList CheckAvailability(DateTime estimatedVisitDate, int engineerID, int numOfDaysNeeded, int numOfSlotsInADay)
        {
            DataTable engTimeSlots;
            var numOfSlotsAvailable = new ArrayList();
            var actualVisitDate = estimatedVisitDate;
            var matches = new ArrayList();
            string startSlotTime = "";
            int matchcount = 0;
            for (int day = 0; day <= 4; day++) // SEARCHES OVER NEXT 5 WORKING DAYS
            {
                matches.Clear();
                matchcount = 0;
                // ADD ON DAYS - UNLESS FIRST TIME IN
                if (day != 0)
                {
                    actualVisitDate = estimatedVisitDate.AddDays(1);
                }

                for (int i = 1, loopTo = numOfDaysNeeded; i <= loopTo; i++) // SEARCHES 1st VISIT AND ALL SUSEQUNCE DAYS
                {
                    numOfSlotsAvailable.Clear();

                    // ADD ON DAYS - UNLESS FIRST TIME IN
                    if (i != 1)
                    {
                        actualVisitDate = actualVisitDate.AddDays(1);
                    }

                    // MAKE IT NOT SAT
                    if (actualVisitDate.DayOfWeek == DayOfWeek.Saturday)
                    {
                        actualVisitDate = actualVisitDate.AddDays(2);
                    }
                    // MAKE IT NOT SUN
                    if (actualVisitDate.DayOfWeek == DayOfWeek.Saturday)
                    {
                        actualVisitDate = actualVisitDate.AddDays(1);
                    }

                    // GET SLOTS USED
                    engTimeSlots = App.DB.Scheduler.Scheduler_DayTimeSlots(actualVisitDate, engineerID.ToString());
                    // SLOTS ARE DISPLAY AS COLUMNS IN THIS TABLE THAT WHY WE LOOP THROUGH COLUMNS INSTEAD OF ROWS
                    if (engTimeSlots.Rows.Count > 0)
                    {
                        for (int colCnt = 0, loopTo1 = engTimeSlots.Columns.Count - 1; colCnt <= loopTo1; colCnt++)
                        {
                            // LOOP THOROUGH EACH COLUMNS TRYING TO FIND AVAILABLE CONSECTUTIVE COLUMNS
                            // EQUAL TO THE NUMBER OF REQUIRED SLOTS
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(engTimeSlots.Rows[0][colCnt], 0, false)))
                            {
                                numOfSlotsAvailable.Add(engTimeSlots.Columns[colCnt].ColumnName);
                                if (numOfSlotsAvailable.Count == numOfSlotsInADay)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                // NOTHING AVAIALABLE
                                numOfSlotsAvailable.Clear();
                            }
                        }
                    }
                    else
                    {
                        // IF NO ROW THEN NOTHING USED FOR THAT DAY SO VISIT CAN GO AT THE BEGINNING
                        numOfSlotsAvailable.Add(App.DB.Manager.Get().WorkingHoursStart);
                    }

                    if (numOfSlotsAvailable.Count > 0)
                    {
                        var match = new ArrayList();
                        if (Conversions.ToBoolean(numOfSlotsAvailable.Count == numOfSlotsInADay | Operators.ConditionalCompareObjectEqual(numOfSlotsAvailable[0], App.DB.Manager.Get().WorkingHoursStart, false) & numOfSlotsAvailable.Count == 1))
                        {

                            // IF THERE ARE ENOUGH AVAILABLE CONSECTUTIVE SLOTS ADD THE START TIME ONTO THE DATE

                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(numOfSlotsAvailable[0], App.DB.Manager.Get().WorkingHoursStart, false)))
                            {
                                startSlotTime = Conversions.ToString(numOfSlotsAvailable[0]);
                            }
                            else
                            {
                                startSlotTime = Strings.Replace(Conversions.ToString(numOfSlotsAvailable[0]), "T", "").Insert(2, ":");
                            }

                            actualVisitDate = Conversions.ToDate(Strings.Format(actualVisitDate, "dd/MM/yyyy") + " " + startSlotTime);
                            match.Add(actualVisitDate);
                            match.Add(engineerID);
                            matches.Add(match);
                            matchcount += 1;
                        }
                        else
                        {
                            match.Add(null);
                            match.Add(0);
                            matches.Add(match);
                        }
                    }

                    if (matchcount != i)
                    {
                        break;
                    }
                }

                if (matchcount == numOfDaysNeeded)
                {
                    return matches;
                }
            }

            return matches;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}