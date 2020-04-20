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
    public class UCContractOption3Site : UCBase, IUserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCContractOption3Site() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCContractOption3Site_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            var argc = cboInvoiceFrequencyID;
            Combo.SetUpCombo(ref argc, DynamicDataTables.InvoiceFrequency, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc1 = cboVisitFrequencyID;
            Combo.SetUpCombo(ref argc1, DynamicDataTables.VisitFrequencyNoWeekly, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
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

        private ComboBox _cboInvoiceFrequencyID;

        internal ComboBox cboInvoiceFrequencyID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboInvoiceFrequencyID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboInvoiceFrequencyID != null)
                {
                }

                _cboInvoiceFrequencyID = value;
                if (_cboInvoiceFrequencyID != null)
                {
                }
            }
        }

        private Label _lblInvoiceFrequencyID;

        internal Label lblInvoiceFrequencyID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInvoiceFrequencyID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInvoiceFrequencyID != null)
                {
                }

                _lblInvoiceFrequencyID = value;
                if (_lblInvoiceFrequencyID != null)
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

        private GroupBox _gpbPPM;

        internal GroupBox gpbPPM
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbPPM;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbPPM != null)
                {
                }

                _gpbPPM = value;
                if (_gpbPPM != null)
                {
                }
            }
        }

        private DataGrid _dgPPMVisits;

        internal DataGrid dgPPMVisits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgPPMVisits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgPPMVisits != null)
                {
                }

                _dgPPMVisits = value;
                if (_dgPPMVisits != null)
                {
                }
            }
        }

        private GroupBox _gpbInvoiceAddress;

        internal GroupBox gpbInvoiceAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbInvoiceAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbInvoiceAddress != null)
                {
                }

                _gpbInvoiceAddress = value;
                if (_gpbInvoiceAddress != null)
                {
                }
            }
        }

        private DataGrid _dgInvoiceAddress;

        internal DataGrid dgInvoiceAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgInvoiceAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgInvoiceAddress != null)
                {
                    _dgInvoiceAddress.Click -= dgInvoiceAddress_Click;
                }

                _dgInvoiceAddress = value;
                if (_dgInvoiceAddress != null)
                {
                    _dgInvoiceAddress.Click += dgInvoiceAddress_Click;
                }
            }
        }

        private DateTimePicker _dtpFirstInvoiceDate;

        internal DateTimePicker dtpFirstInvoiceDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpFirstInvoiceDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpFirstInvoiceDate != null)
                {
                }

                _dtpFirstInvoiceDate = value;
                if (_dtpFirstInvoiceDate != null)
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpContractOption3Site = new GroupBox();
            _gpbPPM = new GroupBox();
            _dgPPMVisits = new DataGrid();
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
            _cboInvoiceFrequencyID = new ComboBox();
            _lblInvoiceFrequencyID = new Label();
            _txtSitePrice = new TextBox();
            _lblSitePrice = new Label();
            _gpbInvoiceAddress = new GroupBox();
            _dgInvoiceAddress = new DataGrid();
            _dgInvoiceAddress.Click += new EventHandler(dgInvoiceAddress_Click);
            _dtpFirstInvoiceDate = new DateTimePicker();
            _Label1 = new Label();
            _grpContractOption3Site.SuspendLayout();
            _gpbPPM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgPPMVisits).BeginInit();
            _gpbAssets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgAssets).BeginInit();
            _gpbInvoiceAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgInvoiceAddress).BeginInit();
            SuspendLayout();
            // 
            // grpContractOption3Site
            // 
            _grpContractOption3Site.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpContractOption3Site.Controls.Add(_gpbInvoiceAddress);
            _grpContractOption3Site.Controls.Add(_dtpFirstInvoiceDate);
            _grpContractOption3Site.Controls.Add(_Label1);
            _grpContractOption3Site.Controls.Add(_gpbPPM);
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
            _grpContractOption3Site.Controls.Add(_cboInvoiceFrequencyID);
            _grpContractOption3Site.Controls.Add(_lblInvoiceFrequencyID);
            _grpContractOption3Site.Controls.Add(_txtSitePrice);
            _grpContractOption3Site.Controls.Add(_lblSitePrice);
            _grpContractOption3Site.Location = new Point(8, 8);
            _grpContractOption3Site.Name = "grpContractOption3Site";
            _grpContractOption3Site.Size = new Size(979, 594);
            _grpContractOption3Site.TabIndex = 1;
            _grpContractOption3Site.TabStop = false;
            _grpContractOption3Site.Text = "Main Details";
            // 
            // gpbPPM
            // 
            _gpbPPM.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _gpbPPM.Controls.Add(_dgPPMVisits);
            _gpbPPM.Location = new Point(9, 449);
            _gpbPPM.Name = "gpbPPM";
            _gpbPPM.Size = new Size(963, 139);
            _gpbPPM.TabIndex = 12;
            _gpbPPM.TabStop = false;
            _gpbPPM.Text = "Scheduled Visit";
            // 
            // dgPPMVisits
            // 
            _dgPPMVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgPPMVisits.DataMember = "";
            _dgPPMVisits.HeaderForeColor = SystemColors.ControlText;
            _dgPPMVisits.Location = new Point(10, 19);
            _dgPPMVisits.Name = "dgPPMVisits";
            _dgPPMVisits.Size = new Size(947, 112);
            _dgPPMVisits.TabIndex = 0;
            // 
            // btnRefreshGrid
            // 
            _btnRefreshGrid.UseVisualStyleBackColor = true;
            _btnRefreshGrid.Location = new Point(424, 120);
            _btnRefreshGrid.Name = "btnRefreshGrid";
            _btnRefreshGrid.Size = new Size(200, 23);
            _btnRefreshGrid.TabIndex = 7;
            _btnRefreshGrid.Text = "Load Assets Scheduled";
            // 
            // lblWarning
            // 
            _lblWarning.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblWarning.ForeColor = Color.Red;
            _lblWarning.Location = new Point(328, 144);
            _lblWarning.Name = "lblWarning";
            _lblWarning.Size = new Size(296, 16);
            _lblWarning.TabIndex = 20;
            _lblWarning.Text = "! First Date must be between Start &&End Date";
            _lblWarning.Visible = false;
            // 
            // gpbAssets
            // 
            _gpbAssets.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _gpbAssets.Controls.Add(_dgAssets);
            _gpbAssets.Location = new Point(9, 168);
            _gpbAssets.Name = "gpbAssets";
            _gpbAssets.Size = new Size(963, 272);
            _gpbAssets.TabIndex = 11;
            _gpbAssets.TabStop = false;
            _gpbAssets.Text = "Assets - Enter duration in hours for each month";
            // 
            // dgAssets
            // 
            _dgAssets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgAssets.DataMember = "";
            _dgAssets.HeaderForeColor = SystemColors.ControlText;
            _dgAssets.Location = new Point(10, 25);
            _dgAssets.Name = "dgAssets";
            _dgAssets.Size = new Size(947, 239);
            _dgAssets.TabIndex = 0;
            // 
            // txtSite
            // 
            _txtSite.Location = new Point(120, 24);
            _txtSite.Multiline = true;
            _txtSite.Name = "txtSite";
            _txtSite.ReadOnly = true;
            _txtSite.ScrollBars = ScrollBars.Vertical;
            _txtSite.Size = new Size(200, 68);
            _txtSite.TabIndex = 0;
            _txtSite.Text = "";
            // 
            // lblSiteID
            // 
            _lblSiteID.Location = new Point(9, 25);
            _lblSiteID.Name = "lblSiteID";
            _lblSiteID.Size = new Size(139, 20);
            _lblSiteID.TabIndex = 13;
            _lblSiteID.Text = "Property";
            // 
            // txtContractSiteReference
            // 
            _txtContractSiteReference.Location = new Point(120, 96);
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
            _lblContractSiteReference.Location = new Point(10, 96);
            _lblContractSiteReference.Name = "lblContractSiteReference";
            _lblContractSiteReference.Size = new Size(139, 20);
            _lblContractSiteReference.TabIndex = 14;
            _lblContractSiteReference.Text = "Contract Property Ref";
            // 
            // dtpStartDate
            // 
            _dtpStartDate.Location = new Point(424, 24);
            _dtpStartDate.Name = "dtpStartDate";
            _dtpStartDate.TabIndex = 3;
            _dtpStartDate.Tag = "ContractOption3Site.StartDate";
            // 
            // lblStartDate
            // 
            _lblStartDate.Location = new Point(328, 25);
            _lblStartDate.Name = "lblStartDate";
            _lblStartDate.Size = new Size(96, 20);
            _lblStartDate.TabIndex = 16;
            _lblStartDate.Text = "Start Date";
            // 
            // dtpEndDate
            // 
            _dtpEndDate.Location = new Point(424, 48);
            _dtpEndDate.Name = "dtpEndDate";
            _dtpEndDate.TabIndex = 4;
            _dtpEndDate.Tag = "ContractOption3Site.EndDate";
            // 
            // lblEndDate
            // 
            _lblEndDate.Location = new Point(328, 49);
            _lblEndDate.Name = "lblEndDate";
            _lblEndDate.Size = new Size(96, 20);
            _lblEndDate.TabIndex = 17;
            _lblEndDate.Text = "End Date";
            // 
            // dtpFirstVisitDate
            // 
            _dtpFirstVisitDate.Location = new Point(424, 72);
            _dtpFirstVisitDate.Name = "dtpFirstVisitDate";
            _dtpFirstVisitDate.TabIndex = 5;
            _dtpFirstVisitDate.Tag = "ContractOption3Site.FirstVisitDate";
            // 
            // lblFirstVisitDate
            // 
            _lblFirstVisitDate.Location = new Point(328, 72);
            _lblFirstVisitDate.Name = "lblFirstVisitDate";
            _lblFirstVisitDate.Size = new Size(96, 20);
            _lblFirstVisitDate.TabIndex = 18;
            _lblFirstVisitDate.Text = "First Visit Date";
            // 
            // cboVisitFrequencyID
            // 
            _cboVisitFrequencyID.Cursor = Cursors.Hand;
            _cboVisitFrequencyID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboVisitFrequencyID.Location = new Point(424, 96);
            _cboVisitFrequencyID.Name = "cboVisitFrequencyID";
            _cboVisitFrequencyID.Size = new Size(200, 21);
            _cboVisitFrequencyID.TabIndex = 6;
            _cboVisitFrequencyID.Tag = "ContractOption3Site.VisitFrequencyID";
            // 
            // lblVisitFrequencyID
            // 
            _lblVisitFrequencyID.Location = new Point(328, 96);
            _lblVisitFrequencyID.Name = "lblVisitFrequencyID";
            _lblVisitFrequencyID.Size = new Size(96, 20);
            _lblVisitFrequencyID.TabIndex = 19;
            _lblVisitFrequencyID.Text = "Visit Frequency";
            // 
            // cboInvoiceFrequencyID
            // 
            _cboInvoiceFrequencyID.Cursor = Cursors.Hand;
            _cboInvoiceFrequencyID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboInvoiceFrequencyID.Location = new Point(768, 24);
            _cboInvoiceFrequencyID.Name = "cboInvoiceFrequencyID";
            _cboInvoiceFrequencyID.Size = new Size(200, 21);
            _cboInvoiceFrequencyID.TabIndex = 8;
            _cboInvoiceFrequencyID.Tag = "ContractOption3Site.InvoiceFrequencyID";
            // 
            // lblInvoiceFrequencyID
            // 
            _lblInvoiceFrequencyID.Location = new Point(632, 24);
            _lblInvoiceFrequencyID.Name = "lblInvoiceFrequencyID";
            _lblInvoiceFrequencyID.Size = new Size(112, 20);
            _lblInvoiceFrequencyID.TabIndex = 21;
            _lblInvoiceFrequencyID.Text = "Invoice Frequency ";
            // 
            // txtSitePrice
            // 
            _txtSitePrice.Location = new Point(120, 121);
            _txtSitePrice.MaxLength = 9;
            _txtSitePrice.Name = "txtSitePrice";
            _txtSitePrice.Size = new Size(200, 21);
            _txtSitePrice.TabIndex = 2;
            _txtSitePrice.Tag = "ContractOption3Site.SitePrice";
            _txtSitePrice.Text = "";
            // 
            // lblSitePrice
            // 
            _lblSitePrice.Location = new Point(10, 121);
            _lblSitePrice.Name = "lblSitePrice";
            _lblSitePrice.Size = new Size(112, 20);
            _lblSitePrice.TabIndex = 15;
            _lblSitePrice.Text = "Property Price";
            // 
            // gpbInvoiceAddress
            // 
            _gpbInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _gpbInvoiceAddress.Controls.Add(_dgInvoiceAddress);
            _gpbInvoiceAddress.Location = new Point(636, 72);
            _gpbInvoiceAddress.Name = "gpbInvoiceAddress";
            _gpbInvoiceAddress.Size = new Size(336, 96);
            _gpbInvoiceAddress.TabIndex = 10;
            _gpbInvoiceAddress.TabStop = false;
            _gpbInvoiceAddress.Text = "Invoice Address";
            // 
            // dgInvoiceAddress
            // 
            _dgInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgInvoiceAddress.DataMember = "";
            _dgInvoiceAddress.HeaderForeColor = SystemColors.ControlText;
            _dgInvoiceAddress.Location = new Point(8, 16);
            _dgInvoiceAddress.Name = "dgInvoiceAddress";
            _dgInvoiceAddress.Size = new Size(320, 72);
            _dgInvoiceAddress.TabIndex = 0;
            // 
            // dtpFirstInvoiceDate
            // 
            _dtpFirstInvoiceDate.Location = new Point(768, 48);
            _dtpFirstInvoiceDate.Name = "dtpFirstInvoiceDate";
            _dtpFirstInvoiceDate.TabIndex = 9;
            _dtpFirstInvoiceDate.Tag = "";
            // 
            // Label1
            // 
            _Label1.Location = new Point(632, 48);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(132, 20);
            _Label1.TabIndex = 22;
            _Label1.Text = "First Invoice Date";
            // 
            // UCContractOption3Site
            // 
            Controls.Add(_grpContractOption3Site);
            Name = "UCContractOption3Site";
            Size = new Size(994, 616);
            _grpContractOption3Site.ResumeLayout(false);
            _gpbPPM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgPPMVisits).EndInit();
            _gpbAssets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgAssets).EndInit();
            _gpbInvoiceAddress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgInvoiceAddress).EndInit();
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
                return CurrentContractOption3Site;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string ExtraText);

        public event StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private bool _InvoiceInserted = false;

        private bool InvoiceInserted
        {
            get
            {
                return _InvoiceInserted;
            }

            set
            {
                _InvoiceInserted = value;
            }
        }

        private Entity.ContractOption3Sites.ContractOption3Site _currentContractOption3Site;

        public Entity.ContractOption3Sites.ContractOption3Site CurrentContractOption3Site
        {
            get
            {
                return _currentContractOption3Site;
            }

            set
            {
                _currentContractOption3Site = value;
                if (CurrentContractOption3Site is null)
                {
                    CurrentContractOption3Site = new Entity.ContractOption3Sites.ContractOption3Site();
                    CurrentContractOption3Site.Exists = false;
                }

                if (CurrentContractOption3Site.Exists)
                {
                    Populate();
                    var site = new Entity.Sites.Site();
                    site = App.DB.Sites.Get(CurrentContractOption3Site.PropertyID);
                    txtSite.Text = Strings.Replace(Strings.Replace(Strings.Replace(site.Address1 + ", " + site.Address2 + ", " + site.Address3 + ", " + site.Address4 + ", " + site.Address5 + ", " + site.Postcode + ".", ", , ", ", "), ", , ", ", "), ", , ", ", ");

                    PPMSchedule = App.DB.ContractOption3SitePPMVisit.ContractOption3SitePPMVisit_GetAll_ContractSiteID(CurrentContractOption3Site.ContractSiteID);


                    // LETS CHECK IF WE HAD AN INVOICED ADDRESS ID ALREADY BEFORE THIS UPDATE
                    if (CurrentContractOption3Site.InvoiceAddressID > 0)
                    {
                        InvoiceInserted = true;
                    }

                    if (InvoiceInserted)
                    {
                        dtpFirstInvoiceDate.Enabled = false;
                        cboInvoiceFrequencyID.Enabled = false;
                        gpbInvoiceAddress.Enabled = false;
                    }
                    // Load Invoice Addresses
                    InvoiceAddresses = App.DB.InvoiceAddress.InvoiceAddress_Get_SiteID(CurrentContractOption3Site.PropertyID);
                    if (CurrentContractOption3Site.InvoiceAddressID > 0)
                    {
                        int c = 0;
                        foreach (DataRow dr in InvoiceAddresses.Table.Rows)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["AddressID"], CurrentContractOption3Site.InvoiceAddressID, false) & Operators.ConditionalCompareObjectEqual(dr["AddressTypeID"], CurrentContractOption3Site.InvoiceAddressTypeID, false)))
                            {
                                dgInvoiceAddress.CurrentRowIndex = c;
                                break;
                            }

                            c += 1;
                        }
                    }
                    else
                    {
                        dgInvoiceAddress.CurrentRowIndex = 0;
                    }

                    dgInvoiceAddress.Select(dgInvoiceAddress.CurrentRowIndex);
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

        private DataView _PPMSchedule = new DataView();

        private DataView PPMSchedule
        {
            get
            {
                return _PPMSchedule;
            }

            set
            {
                _PPMSchedule = value;
                _PPMSchedule.AllowNew = false;
                _PPMSchedule.AllowEdit = true;
                _PPMSchedule.AllowDelete = false;
                _PPMSchedule.Table.TableName = Entity.Sys.Enums.TableNames.tblContractOption3SitePPMVisit.ToString();
                dgPPMVisits.DataSource = PPMSchedule;
            }
        }

        private DataView _InvoiceAddresses;

        private DataView InvoiceAddresses
        {
            get
            {
                return _InvoiceAddresses;
            }

            set
            {
                _InvoiceAddresses = value;
                _InvoiceAddresses.AllowDelete = false;
                _InvoiceAddresses.AllowEdit = false;
                _InvoiceAddresses.AllowNew = false;
                _InvoiceAddresses.Table.TableName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString();
                dgInvoiceAddress.DataSource = InvoiceAddresses;
            }
        }

        private DataRow SelectedInvoiceAddressesDataRow
        {
            get
            {
                if (!(dgInvoiceAddress.CurrentRowIndex == -1))
                {
                    return InvoiceAddresses[dgInvoiceAddress.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
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

        public void SetupPPMDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgPPMVisits);
            var tStyle = dgPPMVisits.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var EstimatedVisitDate = new DataGridLabelColumn();
            EstimatedVisitDate.Format = "dd/MM/yyyy";
            EstimatedVisitDate.FormatInfo = null;
            EstimatedVisitDate.HeaderText = "Approx. VisitDate";
            EstimatedVisitDate.MappingName = "VisitDate";
            EstimatedVisitDate.ReadOnly = true;
            EstimatedVisitDate.Width = 220;
            EstimatedVisitDate.NullText = "";
            tStyle.GridColumnStyles.Add(EstimatedVisitDate);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job Number";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 220;
            JobNumber.NullText = "";
            tStyle.GridColumnStyles.Add(JobNumber);
            var StartDateTime = new DataGridLabelColumn();
            StartDateTime.Format = "dd/MM/yyyy";
            StartDateTime.FormatInfo = null;
            StartDateTime.HeaderText = "Visit Date";
            StartDateTime.MappingName = "StartDateTime";
            StartDateTime.ReadOnly = true;
            StartDateTime.Width = 220;
            StartDateTime.NullText = "Not Set";
            tStyle.GridColumnStyles.Add(StartDateTime);
            var Engineer = new DataGridLabelColumn();
            Engineer.Format = "";
            Engineer.FormatInfo = null;
            Engineer.HeaderText = "Engineer";
            Engineer.MappingName = "Name";
            Engineer.ReadOnly = true;
            Engineer.Width = 220;
            Engineer.NullText = "N/A";
            tStyle.GridColumnStyles.Add(Engineer);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblContractOption3SitePPMVisit.ToString();
            dgPPMVisits.TableStyles.Add(tStyle);
        }

        public void SetupInvoiceAddressDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgInvoiceAddress);
            var tStyle = dgInvoiceAddress.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            dgInvoiceAddress.ReadOnly = false;
            var AddressType = new DataGridLabelColumn();
            AddressType.Format = "";
            AddressType.FormatInfo = null;
            AddressType.HeaderText = "Address Type";
            AddressType.MappingName = "AddressType";
            AddressType.ReadOnly = true;
            AddressType.Width = 95;
            AddressType.NullText = "";
            tStyle.GridColumnStyles.Add(AddressType);
            var Address1 = new DataGridLabelColumn();
            Address1.Format = "";
            Address1.FormatInfo = null;
            Address1.HeaderText = "Address 1";
            Address1.MappingName = "Address1";
            Address1.ReadOnly = true;
            Address1.Width = 75;
            Address1.NullText = "";
            tStyle.GridColumnStyles.Add(Address1);
            var Address2 = new DataGridLabelColumn();
            Address2.Format = "";
            Address2.FormatInfo = null;
            Address2.HeaderText = "Address 2";
            Address2.MappingName = "Address2";
            Address2.ReadOnly = true;
            Address2.Width = 75;
            Address2.NullText = "";
            tStyle.GridColumnStyles.Add(Address2);
            var Address3 = new DataGridLabelColumn();
            Address3.Format = "";
            Address3.FormatInfo = null;
            Address3.HeaderText = "Address 3";
            Address3.MappingName = "Address3";
            Address3.ReadOnly = true;
            Address3.Width = 75;
            Address3.NullText = "";
            tStyle.GridColumnStyles.Add(Address3);
            var Address4 = new DataGridLabelColumn();
            Address4.Format = "";
            Address4.FormatInfo = null;
            Address4.HeaderText = "Address 4";
            Address4.MappingName = "Address4";
            Address4.ReadOnly = true;
            Address4.Width = 75;
            Address4.NullText = "";
            tStyle.GridColumnStyles.Add(Address4);
            var Address5 = new DataGridLabelColumn();
            Address5.Format = "";
            Address5.FormatInfo = null;
            Address5.HeaderText = "Address 5";
            Address5.MappingName = "Address5";
            Address5.ReadOnly = true;
            Address5.Width = 75;
            Address5.NullText = "";
            tStyle.GridColumnStyles.Add(Address5);
            var Postcode = new DataGridLabelColumn();
            Postcode.Format = "";
            Postcode.FormatInfo = null;
            Postcode.HeaderText = "Postcode";
            Postcode.MappingName = "Postcode";
            Postcode.ReadOnly = true;
            Postcode.Width = 75;
            Postcode.NullText = "";
            tStyle.GridColumnStyles.Add(Postcode);
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString();
            dgInvoiceAddress.TableStyles.Add(tStyle);
        }

        private void UCContractOption3Site_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
            SetupAssetsDataGrid();
            SetupPPMDataGrid();
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

        private void dgInvoiceAddress_Click(object sender, EventArgs e)
        {
            dgInvoiceAddress.Select(dgInvoiceAddress.CurrentRowIndex);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void ClearAssetsGrid()
        {
            if (CurrentContractOption3Site is object)
            {
                Assets = App.DB.Asset.Asset_GetForSite(CurrentContractOption3Site.PropertyID);
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
            if (CurrentContractOption3Site is object)
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
                CurrentContractOption3Site = App.DB.ContractOption3Site.ContractOption3Site_Get(ID);
            }

            AssetDurations = App.DB.ContractOption3SiteAsset.ContractOption3SiteAssetDuration_GetAll_ForContractSiteID(CurrentContractOption3Site.ContractSiteID);
            txtContractSiteReference.Text = CurrentContractOption3Site.ContractSiteReference;
            try
            {
                dtpStartDate.Value = CurrentContractOption3Site.StartDate;
                dtpEndDate.Value = CurrentContractOption3Site.EndDate;
                dtpFirstVisitDate.Value = CurrentContractOption3Site.FirstVisitDate;
                dtpFirstInvoiceDate.Value = CurrentContractOption3Site.FirstInvoiceDate;
            }
            catch (Exception ex)
            {
                // AMY DID THIS 
                dtpStartDate.Value = DateAndTime.Now;
                dtpEndDate.Value = DateAndTime.Now.AddYears(1).AddDays(-1);
                dtpFirstVisitDate.Value = DateAndTime.Now;
                dtpFirstInvoiceDate.Value = DateAndTime.Now;
            }

            var argcombo = cboVisitFrequencyID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentContractOption3Site.VisitFrequencyID.ToString());
            var argcombo1 = cboInvoiceFrequencyID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, CurrentContractOption3Site.InvoiceFrequencyID.ToString());
            txtSitePrice.Text = Strings.Format(CurrentContractOption3Site.SitePrice, "C");
            Assets = App.DB.Asset.Asset_GetForSite(CurrentContractOption3Site.PropertyID);
            AssetDurations = App.DB.ContractOption3SiteAsset.ContractOption3SiteAssetDuration_GetAll_ForContractSiteID(CurrentContractOption3Site.ContractSiteID);
            RefreshAssetsGrid();
            if (AssetDurations.Table.Rows.Count > 0)
            {
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;
                dtpFirstVisitDate.Enabled = false;
                cboVisitFrequencyID.Enabled = false;
                btnRefreshGrid.Enabled = false;
                dgAssets.Enabled = false;
            }
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentContractOption3Site.IgnoreExceptionsOnSetMethods = true;
                CurrentContractOption3Site.SetContractSiteReference = txtContractSiteReference.Text.Trim();
                CurrentContractOption3Site.StartDate = dtpStartDate.Value;
                CurrentContractOption3Site.EndDate = dtpEndDate.Value;
                CurrentContractOption3Site.FirstVisitDate = dtpFirstVisitDate.Value;
                CurrentContractOption3Site.SetVisitFrequencyID = Combo.get_GetSelectedItemValue(cboVisitFrequencyID);
                CurrentContractOption3Site.SetInvoiceFrequencyID = Combo.get_GetSelectedItemValue(cboInvoiceFrequencyID);
                CurrentContractOption3Site.SetSitePrice = txtSitePrice.Text.Trim().Replace("£", "");
                CurrentContractOption3Site.FirstInvoiceDate = dtpFirstInvoiceDate.Value;
                if (SelectedInvoiceAddressesDataRow is object)
                {
                    CurrentContractOption3Site.SetInvoiceAddressID = SelectedInvoiceAddressesDataRow["AddressID"];
                    CurrentContractOption3Site.SetInvoiceAddressTypeID = SelectedInvoiceAddressesDataRow["AddressTypeID"];
                }

                var cV = new Entity.ContractOption3Sites.ContractOption3SiteValidator();
                cV.Validate(CurrentContractOption3Site, Assets);
                if (CurrentContractOption3Site.Exists)
                {
                    App.DB.ContractOption3Site.Update(CurrentContractOption3Site);
                    if (PPMSchedule.Table.Rows.Count == 0)
                    {
                        if (App.ShowMessage("Visit will now be scheduled - are you sure you want to save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            App.DB.ContractOption3SiteAsset.ContractOption3SiteAssetDuration_Delete(CurrentContractOption3Site.ContractSiteID);
                            foreach (object vDate in Visits) // For each Visit 
                            {
                                var oJob = new Entity.Jobs.Job();
                                oJob = CreateJob(Conversions.ToDate(vDate));

                                // CREATE PPM VISIT RECORD
                                var PPM = new Entity.ContractOption3SitePPMVisits.ContractOption3SitePPMVisit();
                                PPM.SetContractSiteID = CurrentContractOption3Site.ContractSiteID;
                                PPM.VisitDate = Conversions.ToDate(vDate);
                                PPM.SetJobID = oJob.JobID;
                                App.DB.ContractOption3SitePPMVisit.Insert(PPM);
                            }
                        }
                    }
                }
                else
                {
                    CurrentContractOption3Site = App.DB.ContractOption3Site.Insert(CurrentContractOption3Site);
                }

                if (!InvoiceInserted)
                {
                    InsertInvoiceToBeRaiseLines();
                }

                StateChanged?.Invoke(CurrentContractOption3Site.ContractSiteID);
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

        private Entity.Jobs.Job CreateJob(DateTime vDate)
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
            oJob.SetContractID = CurrentContractOption3Site.ContractID;
            oJob.SetCreatedByUserID = App.loggedInUser.UserID;
            oJob.SetJobDefinitionEnumID = Entity.Sys.Helper.MakeIntegerValid(Entity.Sys.Enums.JobDefinition.Contract);
            var JobNumber = new JobNumber();
            JobNumber = App.DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.Contract);
            oJob.SetJobNumber = JobNumber.Prefix + JobNumber.JobNumber;
            oJob.SetPONumber = "";
            oJob.SetQuoteID = 0;
            oJob.SetJobTypeID = App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Service'")[0]["ManagerID"];
            oJob.SetPropertyID = CurrentContractOption3Site.PropertyID;
            oJob.SetStatusEnumID = Entity.Sys.Helper.MakeIntegerValid(Entity.Sys.Enums.JobStatus.Open);
            oJob.DateCreated = DateAndTime.Now;
            oJob.SetFOC = true;
            var curContract = new Entity.ContractOption3s.ContractOption3();
            curContract = App.DB.ContractOption3.ContractOption3_Get(CurrentContractOption3Site.ContractID);

            // IF CONTRACT IS NOT ACTIVE, FLAG JOB AS DELETED
            if ((Entity.Sys.Enums.ContractStatus)Conversions.ToInteger(curContract.ContractStatusID) == Entity.Sys.Enums.ContractStatus.Inactive)
            {
                oJob.SetDeleted = true;
            }

            // FOR EACH ASSET FOR THE VISIT DATE
            foreach (DataRow rAsset in Assets.Table.Rows)
            {
                // IF DURATION > 0 THEN SAVE DURATION 
                if (Conversions.ToBoolean(rAsset[Strings.Format(vDate, "MMM yy")] > 0))
                {
                    var assetDuration = new Entity.ContractOption3SiteAsset.ContractOption3SiteAsset();
                    assetDuration.SetContractSiteID = CurrentContractOption3Site.ContractSiteID;
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
            ojobOfWork.SetPONumber = "";
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

            // Dim matches As New ArrayList 'Arraylist of arraylists
            // FIND A SUITABLE ENGINEER FIRST
            // matches = GetEngineersAndVisits(numOfDaysNeeded, workingDaySlots, vDate)

            for (int i = 0, loopTo = numOfDaysNeeded - 1; i <= loopTo; i++)
            {
                var oEngVisit = new Entity.EngineerVisits.EngineerVisit();
                oEngVisit.IgnoreExceptionsOnSetMethods = true;
                // Try
                // oEngVisit.SetEngineerID = Entity.Sys.Helper.MakeIntegerValid(CType(matches.Item(i), ArrayList).Item(1))
                // Catch ex As Exception
                oEngVisit.SetEngineerID = 0;
                // End Try

                oEngVisit.SetNotesToEngineer = "PPM Contract Visit";

                // If oEngVisit.EngineerID > 0 Then

                // oEngVisit.StartDateTime = CType(matches.Item(i), ArrayList).Item(0)
                // If numOfMintuesNeeded > workingDayMinutes Then
                // oEngVisit.EndDateTime = CType(matches.Item(i), ArrayList).Item(0).AddHours(Math.Ceiling(workingDayMinutes / 60))
                // numOfMintuesNeeded -= workingDayMinutes
                // Else
                // oEngVisit.EndDateTime = CType(matches.Item(i), ArrayList).Item(0).AddHours(Math.Ceiling(numOfMintuesNeeded / 60))
                // End If
                // oEngVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Scheduled)
                // Else
                oEngVisit.StartDateTime = DateTime.MinValue;
                oEngVisit.EndDateTime = DateTime.MinValue;
                oEngVisit.SetStatusEnumID = Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule);
                // End If

                ojobOfWork.EngineerVisits.Add(oEngVisit);
            }


            // ADD JOB OF WORK TO JOB
            oJob.JobOfWorks.Add(ojobOfWork);
            // INSERT JOB 
            oJob = App.DB.Job.Insert(oJob);
            return oJob;
        }

        private ArrayList GetEngineersAndVisits(int numOfDaysNeeded, int numOfSlotsInADay, DateTime estVisitDate)
        {
            var site = new Entity.Sites.Site();
            var matches = new ArrayList();
            string postcode = "";
            DataView postcodeEngineers = null;
            int cntPostcodeEng = 0;
            int randomNum = 0;


            // SEE IF THE SITE HAS A DEFAULT ENGINEER
            site = App.DB.Sites.Get(CurrentContractOption3Site.PropertyID);
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

            return default;
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

        private void InsertInvoiceToBeRaiseLines()
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}