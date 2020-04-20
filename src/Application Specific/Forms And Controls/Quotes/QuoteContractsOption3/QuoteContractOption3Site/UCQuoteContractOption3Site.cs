﻿using System;
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
    public class UCQuoteContractOption3Site : UCBase, IUserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCQuoteContractOption3Site() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCContractOption3Site_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            var argc = cboVisitFrequencyID;
            Combo.SetUpCombo(ref argc, DynamicDataTables.VisitFrequencyNoWeekly, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
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

        private GroupBox _grpContractOption3Site;

        internal GroupBox grpContractOption3Site
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpContractOption3Site;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpContractOption3Site != null)
                {
                }

                _grpContractOption3Site = value;
                if (_grpContractOption3Site != null)
                {
                }
            }
        }

        private Label _lblSiteID;

        internal Label lblSiteID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSiteID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSiteID != null)
                {
                }

                _lblSiteID = value;
                if (_lblSiteID != null)
                {
                }
            }
        }

        private TextBox _txtContractSiteReference;

        internal TextBox txtContractSiteReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContractSiteReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContractSiteReference != null)
                {
                }

                _txtContractSiteReference = value;
                if (_txtContractSiteReference != null)
                {
                }
            }
        }

        private Label _lblContractSiteReference;

        internal Label lblContractSiteReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractSiteReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractSiteReference != null)
                {
                }

                _lblContractSiteReference = value;
                if (_lblContractSiteReference != null)
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
                    _dtpStartDate.ValueChanged -= dtpStartDate_ValueChanged;
                }

                _dtpStartDate = value;
                if (_dtpStartDate != null)
                {
                    _dtpStartDate.ValueChanged += dtpStartDate_ValueChanged;
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
                    _dtpEndDate.ValueChanged -= dtpEndDate_ValueChanged;
                }

                _dtpEndDate = value;
                if (_dtpEndDate != null)
                {
                    _dtpEndDate.ValueChanged += dtpEndDate_ValueChanged;
                }
            }
        }

        private Label _lblEndDate;

        internal Label lblEndDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEndDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEndDate != null)
                {
                }

                _lblEndDate = value;
                if (_lblEndDate != null)
                {
                }
            }
        }

        private DateTimePicker _dtpFirstVisitDate;

        internal DateTimePicker dtpFirstVisitDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpFirstVisitDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpFirstVisitDate != null)
                {
                    _dtpFirstVisitDate.ValueChanged -= dtpFirstVisitDate_ValueChanged;
                }

                _dtpFirstVisitDate = value;
                if (_dtpFirstVisitDate != null)
                {
                    _dtpFirstVisitDate.ValueChanged += dtpFirstVisitDate_ValueChanged;
                }
            }
        }

        private Label _lblFirstVisitDate;

        internal Label lblFirstVisitDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFirstVisitDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFirstVisitDate != null)
                {
                }

                _lblFirstVisitDate = value;
                if (_lblFirstVisitDate != null)
                {
                }
            }
        }

        private ComboBox _cboVisitFrequencyID;

        internal ComboBox cboVisitFrequencyID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboVisitFrequencyID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboVisitFrequencyID != null)
                {
                    _cboVisitFrequencyID.SelectedIndexChanged -= cboVisitFrequencyID_SelectedIndexChanged;
                }

                _cboVisitFrequencyID = value;
                if (_cboVisitFrequencyID != null)
                {
                    _cboVisitFrequencyID.SelectedIndexChanged += cboVisitFrequencyID_SelectedIndexChanged;
                }
            }
        }

        private Label _lblVisitFrequencyID;

        internal Label lblVisitFrequencyID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblVisitFrequencyID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblVisitFrequencyID != null)
                {
                }

                _lblVisitFrequencyID = value;
                if (_lblVisitFrequencyID != null)
                {
                }
            }
        }

        private TextBox _txtSitePrice;

        internal TextBox txtSitePrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSitePrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSitePrice != null)
                {
                }

                _txtSitePrice = value;
                if (_txtSitePrice != null)
                {
                }
            }
        }

        private Label _lblSitePrice;

        internal Label lblSitePrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSitePrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSitePrice != null)
                {
                }

                _lblSitePrice = value;
                if (_lblSitePrice != null)
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

        private GroupBox _gpbAssets;

        internal GroupBox gpbAssets
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbAssets;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbAssets != null)
                {
                }

                _gpbAssets = value;
                if (_gpbAssets != null)
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

        private Label _lblWarning;

        internal Label lblWarning
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblWarning;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblWarning != null)
                {
                }

                _lblWarning = value;
                if (_lblWarning != null)
                {
                }
            }
        }

        private Button _btnRefreshGrid;

        internal Button btnRefreshGrid
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRefreshGrid;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRefreshGrid != null)
                {
                    _btnRefreshGrid.Click -= btnRefreshGrid_Click;
                }

                _btnRefreshGrid = value;
                if (_btnRefreshGrid != null)
                {
                    _btnRefreshGrid.Click += btnRefreshGrid_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpContractOption3Site = new GroupBox();
            _btnRefreshGrid = new Button();
            _btnRefreshGrid.Click += new EventHandler(btnRefreshGrid_Click);
            _lblWarning = new Label();
            _gpbAssets = new GroupBox();
            _dgAssets = new DataGrid();
            _txtSite = new TextBox();
            _lblSiteID = new Label();
            _txtContractSiteReference = new TextBox();
            _lblContractSiteReference = new Label();
            _dtpStartDate = new DateTimePicker();
            _dtpStartDate.ValueChanged += new EventHandler(dtpStartDate_ValueChanged);
            _lblStartDate = new Label();
            _dtpEndDate = new DateTimePicker();
            _dtpEndDate.ValueChanged += new EventHandler(dtpEndDate_ValueChanged);
            _lblEndDate = new Label();
            _dtpFirstVisitDate = new DateTimePicker();
            _dtpFirstVisitDate.ValueChanged += new EventHandler(dtpFirstVisitDate_ValueChanged);
            _lblFirstVisitDate = new Label();
            _cboVisitFrequencyID = new ComboBox();
            _cboVisitFrequencyID.SelectedIndexChanged += new EventHandler(cboVisitFrequencyID_SelectedIndexChanged);
            _lblVisitFrequencyID = new Label();
            _txtSitePrice = new TextBox();
            _lblSitePrice = new Label();
            _grpContractOption3Site.SuspendLayout();
            _gpbAssets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgAssets).BeginInit();
            SuspendLayout();
            // 
            // grpContractOption3Site
            // 
            _grpContractOption3Site.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpContractOption3Site.Controls.Add(_btnRefreshGrid);
            _grpContractOption3Site.Controls.Add(_lblWarning);
            _grpContractOption3Site.Controls.Add(_gpbAssets);
            _grpContractOption3Site.Controls.Add(_txtSite);
            _grpContractOption3Site.Controls.Add(_lblSiteID);
            _grpContractOption3Site.Controls.Add(_txtContractSiteReference);
            _grpContractOption3Site.Controls.Add(_lblContractSiteReference);
            _grpContractOption3Site.Controls.Add(_dtpStartDate);
            _grpContractOption3Site.Controls.Add(_lblStartDate);
            _grpContractOption3Site.Controls.Add(_dtpEndDate);
            _grpContractOption3Site.Controls.Add(_lblEndDate);
            _grpContractOption3Site.Controls.Add(_dtpFirstVisitDate);
            _grpContractOption3Site.Controls.Add(_lblFirstVisitDate);
            _grpContractOption3Site.Controls.Add(_cboVisitFrequencyID);
            _grpContractOption3Site.Controls.Add(_lblVisitFrequencyID);
            _grpContractOption3Site.Controls.Add(_txtSitePrice);
            _grpContractOption3Site.Controls.Add(_lblSitePrice);
            _grpContractOption3Site.Location = new Point(8, 8);
            _grpContractOption3Site.Name = "grpContractOption3Site";
            _grpContractOption3Site.Size = new Size(979, 594);
            _grpContractOption3Site.TabIndex = 1;
            _grpContractOption3Site.TabStop = false;
            _grpContractOption3Site.Text = "Main Details";
            // 
            // btnRefreshGrid
            // 
            _btnRefreshGrid.UseVisualStyleBackColor = true;
            _btnRefreshGrid.Location = new Point(500, 122);
            _btnRefreshGrid.Name = "btnRefreshGrid";
            _btnRefreshGrid.Size = new Size(200, 23);
            _btnRefreshGrid.TabIndex = 8;
            _btnRefreshGrid.Text = "Load Assets Scheduled";
            // 
            // lblWarning
            // 
            _lblWarning.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblWarning.ForeColor = Color.Red;
            _lblWarning.Location = new Point(704, 71);
            _lblWarning.Name = "lblWarning";
            _lblWarning.Size = new Size(268, 23);
            _lblWarning.TabIndex = 34;
            _lblWarning.Text = "! Date must be between Start &&End Date";
            _lblWarning.Visible = false;
            // 
            // gpbAssets
            // 
            _gpbAssets.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _gpbAssets.Controls.Add(_dgAssets);
            _gpbAssets.Location = new Point(9, 153);
            _gpbAssets.Name = "gpbAssets";
            _gpbAssets.Size = new Size(963, 434);
            _gpbAssets.TabIndex = 9;
            _gpbAssets.TabStop = false;
            _gpbAssets.Text = "Assets - Enter duration in hours for each month";
            // 
            // dgAssets
            // 
            _dgAssets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgAssets.DataMember = "";
            _dgAssets.HeaderForeColor = SystemColors.ControlText;
            _dgAssets.Location = new Point(10, 26);
            _dgAssets.Name = "dgAssets";
            _dgAssets.Size = new Size(942, 400);
            _dgAssets.TabIndex = 0;
            // 
            // txtSite
            // 
            _txtSite.Location = new Point(151, 25);
            _txtSite.Multiline = true;
            _txtSite.Name = "txtSite";
            _txtSite.ReadOnly = true;
            _txtSite.ScrollBars = ScrollBars.Vertical;
            _txtSite.Size = new Size(200, 77);
            _txtSite.TabIndex = 0;
            _txtSite.Text = "";
            // 
            // lblSiteID
            // 
            _lblSiteID.Location = new Point(9, 25);
            _lblSiteID.Name = "lblSiteID";
            _lblSiteID.Size = new Size(139, 20);
            _lblSiteID.TabIndex = 31;
            _lblSiteID.Text = "Property";
            // 
            // txtContractSiteReference
            // 
            _txtContractSiteReference.Location = new Point(151, 104);
            _txtContractSiteReference.MaxLength = 100;
            _txtContractSiteReference.Name = "txtContractSiteReference";
            _txtContractSiteReference.ReadOnly = true;
            _txtContractSiteReference.Size = new Size(200, 21);
            _txtContractSiteReference.TabIndex = 1;
            _txtContractSiteReference.Tag = "ContractOption3Site.ContractSiteReference";
            _txtContractSiteReference.Text = "";
            // 
            // lblContractSiteReference
            // 
            _lblContractSiteReference.Location = new Point(10, 104);
            _lblContractSiteReference.Name = "lblContractSiteReference";
            _lblContractSiteReference.Size = new Size(139, 20);
            _lblContractSiteReference.TabIndex = 31;
            _lblContractSiteReference.Text = "Quote Property Reference";
            // 
            // dtpStartDate
            // 
            _dtpStartDate.Location = new Point(500, 25);
            _dtpStartDate.Name = "dtpStartDate";
            _dtpStartDate.TabIndex = 4;
            _dtpStartDate.Tag = "ContractOption3Site.StartDate";
            // 
            // lblStartDate
            // 
            _lblStartDate.Location = new Point(366, 25);
            _lblStartDate.Name = "lblStartDate";
            _lblStartDate.Size = new Size(123, 20);
            _lblStartDate.TabIndex = 31;
            _lblStartDate.Text = "Start Date";
            // 
            // dtpEndDate
            // 
            _dtpEndDate.Location = new Point(500, 49);
            _dtpEndDate.Name = "dtpEndDate";
            _dtpEndDate.TabIndex = 5;
            _dtpEndDate.Tag = "ContractOption3Site.EndDate";
            // 
            // lblEndDate
            // 
            _lblEndDate.Location = new Point(366, 49);
            _lblEndDate.Name = "lblEndDate";
            _lblEndDate.Size = new Size(123, 20);
            _lblEndDate.TabIndex = 31;
            _lblEndDate.Text = "End Date";
            // 
            // dtpFirstVisitDate
            // 
            _dtpFirstVisitDate.Location = new Point(500, 72);
            _dtpFirstVisitDate.Name = "dtpFirstVisitDate";
            _dtpFirstVisitDate.TabIndex = 6;
            _dtpFirstVisitDate.Tag = "ContractOption3Site.FirstVisitDate";
            // 
            // lblFirstVisitDate
            // 
            _lblFirstVisitDate.Location = new Point(367, 72);
            _lblFirstVisitDate.Name = "lblFirstVisitDate";
            _lblFirstVisitDate.Size = new Size(123, 20);
            _lblFirstVisitDate.TabIndex = 31;
            _lblFirstVisitDate.Text = "First Visit Date";
            // 
            // cboVisitFrequencyID
            // 
            _cboVisitFrequencyID.Cursor = Cursors.Hand;
            _cboVisitFrequencyID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboVisitFrequencyID.Location = new Point(500, 96);
            _cboVisitFrequencyID.Name = "cboVisitFrequencyID";
            _cboVisitFrequencyID.Size = new Size(200, 21);
            _cboVisitFrequencyID.TabIndex = 7;
            _cboVisitFrequencyID.Tag = "ContractOption3Site.VisitFrequencyID";
            // 
            // lblVisitFrequencyID
            // 
            _lblVisitFrequencyID.Location = new Point(367, 96);
            _lblVisitFrequencyID.Name = "lblVisitFrequencyID";
            _lblVisitFrequencyID.Size = new Size(96, 20);
            _lblVisitFrequencyID.TabIndex = 31;
            _lblVisitFrequencyID.Text = "Visit Frequency";
            // 
            // txtSitePrice
            // 
            _txtSitePrice.Location = new Point(151, 128);
            _txtSitePrice.MaxLength = 9;
            _txtSitePrice.Name = "txtSitePrice";
            _txtSitePrice.Size = new Size(200, 21);
            _txtSitePrice.TabIndex = 3;
            _txtSitePrice.Tag = "ContractOption3Site.SitePrice";
            _txtSitePrice.Text = "";
            // 
            // lblSitePrice
            // 
            _lblSitePrice.Location = new Point(10, 128);
            _lblSitePrice.Name = "lblSitePrice";
            _lblSitePrice.Size = new Size(112, 20);
            _lblSitePrice.TabIndex = 31;
            _lblSitePrice.Text = "Property Price";
            // 
            // UCQuoteContractOption3Site
            // 
            Controls.Add(_grpContractOption3Site);
            Name = "UCQuoteContractOption3Site";
            Size = new Size(994, 616);
            _grpContractOption3Site.ResumeLayout(false);
            _gpbAssets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgAssets).EndInit();
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
                return CurrentQuoteContractOption3Site;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string ExtraText);

        public event StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.QuoteContractOption3Sites.QuoteContractOption3Site _currentQuoteContractOption3Site;

        public Entity.QuoteContractOption3Sites.QuoteContractOption3Site CurrentQuoteContractOption3Site
        {
            get
            {
                return _currentQuoteContractOption3Site;
            }

            set
            {
                _currentQuoteContractOption3Site = value;
                if (_currentQuoteContractOption3Site is null)
                {
                    _currentQuoteContractOption3Site = new Entity.QuoteContractOption3Sites.QuoteContractOption3Site();
                    _currentQuoteContractOption3Site.Exists = false;
                }

                if (_currentQuoteContractOption3Site.Exists)
                {
                    Populate();
                    var site = new Entity.Sites.Site();
                    site = App.DB.Sites.Get(_currentQuoteContractOption3Site.SiteID);
                    txtSite.Text = Strings.Replace(Strings.Replace(Strings.Replace(site.Address1 + ", " + site.Address2 + ", " + site.Address3 + ", " + site.Address4 + ", " + site.Address5 + ", " + site.Postcode + ".", ", , ", ", "), ", , ", ", "), ", , ", ", ");
                }
            }
        }

        private DataView _Assets;

        private DataView Assets
        {
            get
            {
                return _Assets;
            }

            set
            {
                _Assets = value;
                _Assets.AllowNew = false;
                _Assets.AllowEdit = true;
                _Assets.AllowDelete = false;
                _Assets.Table.TableName = Entity.Sys.Enums.TableNames.tblAsset.ToString();
                dgAssets.DataSource = _Assets;
            }
        }

        private int _NumOfMonths = 0;

        private int NumOfMonths
        {
            get
            {
                return _NumOfMonths;
            }

            set
            {
                _NumOfMonths = value;
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

        private DataView _AssetDurations = new DataView();

        private DataView AssetDurations
        {
            get
            {
                return _AssetDurations;
            }

            set
            {
                _AssetDurations = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void SetupAssetsDataGrid()
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
            numOfMonths = Conversions.ToInteger(Math.Ceiling((decimal)DateAndTime.DateDiff(DateInterval.Month, dtpStartDate.Value, dtpEndDate.Value)));
            for (int i = 0, loopTo = numOfMonths; i <= loopTo; i++)
            {
                var dglc = new Contract3AssetsColourColumn();
                dglc.HeaderText = Strings.Format(dtpStartDate.Value.AddMonths(i), "MMM yy");
                dglc.MappingName = Strings.Format(dtpStartDate.Value.AddMonths(i), "MMM yy");
                dglc.ReadOnly = false;
                dglc.Width = 50;
                dglc.NullText = "-";
                tStyle.GridColumnStyles.Add(dglc);
            }

            tStyle.ReadOnly = false;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblAsset.ToString();
            dgAssets.TableStyles.Add(tStyle);
        }

        private void UCContractOption3Site_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
            SetupAssetsDataGrid();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            ClearAssetsGrid();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            ClearAssetsGrid();
        }

        private void dtpFirstVisitDate_ValueChanged(object sender, EventArgs e)
        {
            ClearAssetsGrid();
        }

        private void cboVisitFrequencyID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAssetsGrid();
        }

        private void btnRefreshGrid_Click(object sender, EventArgs e)
        {
            RefreshAssetsGrid();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void ClearAssetsGrid()
        {
            if (CurrentQuoteContractOption3Site is object)
            {
                Assets = App.DB.Asset.Asset_GetForSite(CurrentQuoteContractOption3Site.SiteID);
            }

            if (dtpFirstVisitDate.Value >= dtpStartDate.Value & dtpFirstVisitDate.Value <= dtpEndDate.Value)
            {
                lblWarning.Visible = false;
            }
            else
            {
                lblWarning.Visible = true;
            }
        }

        private void RefreshAssetsGrid()
        {
            Cursor = Cursors.WaitCursor;
            DateTime estVisitDate = default;
            int numOfVisits = 0;
            int visitFreqInMonths = 0;
            if (CurrentQuoteContractOption3Site is object)
            {
                if (Assets is object)
                {
                    NumOfMonths = Conversions.ToInteger(Math.Ceiling((decimal)DateAndTime.DateDiff(DateInterval.Month, dtpStartDate.Value, dtpEndDate.Value)));
                    ClearAssetsGrid();
                    Visits = new ArrayList();
                    for (int i = 0, loopTo = NumOfMonths; i <= loopTo; i++)
                        Assets.Table.Columns.Add(Strings.Format(dtpStartDate.Value.AddMonths(i), "MMM yy"));
                    if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboVisitFrequencyID)) > 0)
                    {
                        if (dtpFirstVisitDate.Value.Date >= dtpStartDate.Value.Date & dtpFirstVisitDate.Value.Date <= dtpEndDate.Value.Date)
                        {
                            lblWarning.Visible = false;

                            // How Visit Should happen in days
                            numOfVisits = 0;
                            // visitFreqInDays = 0
                            visitFreqInMonths = 0;
                            var switchExpr = (Entity.Sys.Enums.VisitFrequency)Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboVisitFrequencyID));
                            switch (switchExpr)
                            {
                                case Entity.Sys.Enums.VisitFrequency.Annually:
                                    {
                                        // visitFreqInDays = 365
                                        visitFreqInMonths = 12;
                                        break;
                                    }

                                case Entity.Sys.Enums.VisitFrequency.Bi_Annually:
                                    {
                                        // visitFreqInDays = 182
                                        visitFreqInMonths = 6;
                                        break;
                                    }

                                case Entity.Sys.Enums.VisitFrequency.Monthly:
                                    {
                                        // visitFreqInDays = 30
                                        visitFreqInMonths = 1;
                                        break;
                                    }

                                case Entity.Sys.Enums.VisitFrequency.Quarterly:
                                    {
                                        // visitFreqInDays = 91
                                        visitFreqInMonths = 3;
                                        break;
                                    }
                            }

                            // numOfVisits = Math.Floor(Math.Ceiling(DateDiff(DateInterval.Day, dtpStartDate.Value, dtpEndDate.Value)) / visitFreqInDays)
                            numOfVisits = Conversions.ToInteger(Math.Ceiling(DateAndTime.DateDiff(DateInterval.Month, dtpStartDate.Value, dtpEndDate.Value) / (double)visitFreqInMonths));
                            if (numOfVisits == 0)
                            {
                                numOfVisits = 1;
                            }

                            estVisitDate = Conversions.ToDate(dtpFirstVisitDate.Value.Date + " 09:00:00");
                            for (int i = 1, loopTo1 = numOfVisits; i <= loopTo1; i++)
                            {
                                if (estVisitDate >= Conversions.ToDate(Strings.Format(dtpStartDate.Value.Date, "dd/MM/yyyy") + " 09:00") & estVisitDate <= Conversions.ToDate(Strings.Format(dtpEndDate.Value.Date, "dd/MM/yyyy") + " 09:00"))
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

                                    foreach (DataRow drAsset in Assets.Table.Rows)
                                    {
                                        DataRow[] rVal;
                                        rVal = AssetDurations.Table.Select(Conversions.ToString("CompareMonth=" + Strings.Format(estVisitDate, "yyyyMM") + " AND AssetID=" + drAsset["AssetID"]));
                                        if (rVal.Length > 0)
                                        {
                                            drAsset[Strings.Format(estVisitDate, "MMM yy")] = rVal[0]["VisitDuration"];
                                        }
                                        else
                                        {
                                            drAsset[Strings.Format(estVisitDate, "MMM yy")] = "0";
                                        }
                                    }

                                    Visits.Add(estVisitDate);

                                    // estVisitDate = estVisitDate.AddDays(visitFreqInDays)
                                    estVisitDate = shouldHaveBeenDate.AddMonths(visitFreqInMonths);
                                }
                            }
                        }
                        else
                        {
                            lblWarning.Visible = true;
                        }
                    }
                }

                SetupAssetsDataGrid();
            }

            Cursor = Cursors.Default;
        }

        private void Populate(int ID = 0)
        {
            if (!(ID == 0))
            {
                CurrentQuoteContractOption3Site = App.DB.QuoteContractOption3Site.QuoteContractOption3Site_Get(ID);
            }

            AssetDurations = App.DB.QuoteContractOption3SiteAssetDurations.QuoteContractOption3SiteAssetDuration_GetAll_ForQuoteContractSiteID(CurrentQuoteContractOption3Site.QuoteContractSiteID);
            txtContractSiteReference.Text = CurrentQuoteContractOption3Site.QuoteContractSiteReference;
            try
            {
                dtpStartDate.Value = CurrentQuoteContractOption3Site.StartDate;
                dtpEndDate.Value = CurrentQuoteContractOption3Site.EndDate;
                dtpFirstVisitDate.Value = CurrentQuoteContractOption3Site.FirstVisitDate;
            }
            catch (Exception ex)
            {
                // AMY DID THIS
                dtpStartDate.Value = DateAndTime.Now;
                dtpEndDate.Value = DateAndTime.Now.AddYears(1).AddDays(-1);
                dtpFirstVisitDate.Value = DateAndTime.Now;
            }

            var argcombo = cboVisitFrequencyID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentQuoteContractOption3Site.VisitFrequencyID.ToString());
            txtSitePrice.Text = Strings.Format(CurrentQuoteContractOption3Site.SitePrice, "C");
            Assets = App.DB.Asset.Asset_GetForSite(CurrentQuoteContractOption3Site.SiteID);
            AssetDurations = App.DB.QuoteContractOption3SiteAssetDurations.QuoteContractOption3SiteAssetDuration_GetAll_ForQuoteContractSiteID(CurrentQuoteContractOption3Site.QuoteContractSiteID);
            RefreshAssetsGrid();
            // If AssetDurations.Table.Rows.Count > 0 Then
            // Me.dtpStartDate.Enabled = False
            // Me.dtpEndDate.Enabled = False
            // Me.dtpFirstVisitDate.Enabled = False
            // Me.cboVisitFrequencyID.Enabled = False
            // Me.btnRefreshGrid.Enabled = False
            // Me.dgAssets.Enabled = False
            // End If
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentQuoteContractOption3Site.IgnoreExceptionsOnSetMethods = true;
                CurrentQuoteContractOption3Site.SetQuoteContractSiteReference = txtContractSiteReference.Text.Trim();
                CurrentQuoteContractOption3Site.StartDate = dtpStartDate.Value;
                CurrentQuoteContractOption3Site.EndDate = dtpEndDate.Value;
                CurrentQuoteContractOption3Site.FirstVisitDate = dtpFirstVisitDate.Value;
                CurrentQuoteContractOption3Site.SetVisitFrequencyID = Combo.get_GetSelectedItemValue(cboVisitFrequencyID);
                CurrentQuoteContractOption3Site.SetSitePrice = txtSitePrice.Text.Trim().Replace("£", "");
                var cV = new Entity.QuoteContractOption3Sites.QuoteContractOption3SiteValidator();
                cV.Validate(CurrentQuoteContractOption3Site, Assets);
                if (CurrentQuoteContractOption3Site.Exists)
                {
                    App.DB.QuoteContractOption3Site.Update(CurrentQuoteContractOption3Site);
                    App.DB.QuoteContractOption3SiteAssetDurations.QuoteContractOption3SiteAssetDuration_Delete(CurrentQuoteContractOption3Site.QuoteContractSiteID);
                    foreach (object vDate in Visits) // For each Visit
                    {

                        // FOR EACH ASSET FOR THE VISIT DATE
                        foreach (DataRow rAsset in Assets.Table.Rows)
                        {
                            // IF DURATION > 0 THEN SAVE DURATION
                            if (Conversions.ToBoolean(rAsset[Strings.Format(vDate, "MMM yy")] > 0))
                            {
                                var assetDuration = new Entity.QuoteContractOption3SiteAssetDurations.QuoteContractOption3SiteAssetDuration();
                                assetDuration.SetQuoteContractSiteID = CurrentQuoteContractOption3Site.QuoteContractSiteID;
                                assetDuration.SetAssetID = rAsset["AssetID"];
                                assetDuration.ScheduledMonth = Conversions.ToDate(vDate);
                                assetDuration.SetVisitDuration = rAsset[Strings.Format(vDate, "MMM yy")];
                                App.DB.QuoteContractOption3SiteAssetDurations.Insert(assetDuration);
                            }
                        }
                    }
                }
                else
                {
                    CurrentQuoteContractOption3Site = App.DB.QuoteContractOption3Site.Insert(CurrentQuoteContractOption3Site);
                }

                StateChanged?.Invoke(CurrentQuoteContractOption3Site.QuoteContractSiteID);
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