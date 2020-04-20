using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCContractOriginalSite : UCBase, IUserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCContractOriginalSite() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCContractSite_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            SetupAssetsDataGrid();
            var argc = cboVisitFrequencyID;
            Combo.SetUpCombo(ref argc, DynamicDataTables.VisitFrequencyNoWeekly, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);

            // Combo.SetUpCombo(Me.cboVisitDuration, DynamicDataTables.VisitDuration(), "VisitDuration", "DisplayMember")
            // cboVisitDuration.SelectedIndex = 0
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

        private GroupBox _grpContractSite;

        internal GroupBox grpContractSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpContractSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpContractSite != null)
                {
                }

                _grpContractSite = value;
                if (_grpContractSite != null)
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
                }

                _dtpFirstVisitDate = value;
                if (_dtpFirstVisitDate != null)
                {
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
                }

                _cboVisitFrequencyID = value;
                if (_cboVisitFrequencyID != null)
                {
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
                    _dgAssets.MouseUp -= dgAssets_MouseUp;
                }

                _dgAssets = value;
                if (_dgAssets != null)
                {
                    _dgAssets.MouseUp += dgAssets_MouseUp;
                }
            }
        }

        private GroupBox _grpVisits;

        internal GroupBox grpVisits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpVisits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpVisits != null)
                {
                }

                _grpVisits = value;
                if (_grpVisits != null)
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

        private GroupBox _grpScheduleOfRates;

        internal GroupBox grpScheduleOfRates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpScheduleOfRates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpScheduleOfRates != null)
                {
                }

                _grpScheduleOfRates = value;
                if (_grpScheduleOfRates != null)
                {
                }
            }
        }

        private Button _btnSiteScheduleOfRates;

        internal Button btnSiteScheduleOfRates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSiteScheduleOfRates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSiteScheduleOfRates != null)
                {
                    _btnSiteScheduleOfRates.Click -= btnSiteScheduleOfRates_Click;
                }

                _btnSiteScheduleOfRates = value;
                if (_btnSiteScheduleOfRates != null)
                {
                    _btnSiteScheduleOfRates.Click += btnSiteScheduleOfRates_Click;
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

        private DataGrid _dgSystemRates;

        internal DataGrid dgSystemRates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgSystemRates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgSystemRates != null)
                {
                    _dgSystemRates.MouseUp -= dgSystemRates_MouseUp;
                }

                _dgSystemRates = value;
                if (_dgSystemRates != null)
                {
                    _dgSystemRates.MouseUp += dgSystemRates_MouseUp;
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

        private CheckBox _chkLLCertificateReqd;

        internal CheckBox chkLLCertificateReqd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkLLCertificateReqd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkLLCertificateReqd != null)
                {
                }

                _chkLLCertificateReqd = value;
                if (_chkLLCertificateReqd != null)
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

        private TextBox _txtVisitDuration;

        internal TextBox txtVisitDuration
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtVisitDuration;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtVisitDuration != null)
                {
                }

                _txtVisitDuration = value;
                if (_txtVisitDuration != null)
                {
                }
            }
        }

        private CheckBox _chkCommercial;

        internal CheckBox chkCommercial
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkCommercial;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkCommercial != null)
                {
                }

                _chkCommercial = value;
                if (_chkCommercial != null)
                {
                }
            }
        }

        private GroupBox _GroupBox1;

        internal GroupBox GroupBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox1 != null)
                {
                }

                _GroupBox1 = value;
                if (_GroupBox1 != null)
                {
                }
            }
        }

        private Button _btnAddVisit;

        internal Button btnAddVisit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddVisit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddVisit != null)
                {

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    _btnAddVisit.Click -= btnAddVisit_Click;
                }

                _btnAddVisit = value;
                if (_btnAddVisit != null)
                {
                    _btnAddVisit.Click += btnAddVisit_Click;
                }
            }
        }

        private Button _btRemoveVisit;

        internal Button btRemoveVisit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btRemoveVisit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btRemoveVisit != null)
                {
                    _btRemoveVisit.Click -= btRemoveVisit_Click;
                }

                _btRemoveVisit = value;
                if (_btRemoveVisit != null)
                {
                    _btRemoveVisit.Click += btRemoveVisit_Click;
                }
            }
        }

        private DataGrid _dgVisitsSetup;

        internal DataGrid dgVisitsSetup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgVisitsSetup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgVisitsSetup != null)
                {
                    _dgVisitsSetup.DoubleClick -= dgVisits2_DoubleClick;
                }

                _dgVisitsSetup = value;
                if (_dgVisitsSetup != null)
                {
                    _dgVisitsSetup.DoubleClick += dgVisits2_DoubleClick;
                }
            }
        }

        private DataGrid _dgScheduleOfRates;

        internal DataGrid dgScheduleOfRates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgScheduleOfRates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgScheduleOfRates != null)
                {
                }

                _dgScheduleOfRates = value;
                if (_dgScheduleOfRates != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpContractSite = new GroupBox();
            _GroupBox1 = new GroupBox();
            _btnAddVisit = new Button();
            _btnAddVisit.Click += new EventHandler(btnAddVisit_Click);
            _btRemoveVisit = new Button();
            _btRemoveVisit.Click += new EventHandler(btRemoveVisit_Click);
            _dgVisitsSetup = new DataGrid();
            _dgVisitsSetup.DoubleClick += new EventHandler(dgVisits2_DoubleClick);
            _chkCommercial = new CheckBox();
            _txtVisitDuration = new TextBox();
            _txtAdditionalNotes = new TextBox();
            _Label2 = new Label();
            _chkLLCertificateReqd = new CheckBox();
            _grpScheduleOfRates = new GroupBox();
            _dgSystemRates = new DataGrid();
            _dgSystemRates.MouseUp += new MouseEventHandler(dgSystemRates_MouseUp);
            _btnSiteScheduleOfRates = new Button();
            _btnSiteScheduleOfRates.Click += new EventHandler(btnSiteScheduleOfRates_Click);
            _btnRemove = new Button();
            _btnRemove.Click += new EventHandler(btnRemove_Click);
            _dgScheduleOfRates = new DataGrid();
            _Label1 = new Label();
            _grpAssets = new GroupBox();
            _dgAssets = new DataGrid();
            _dgAssets.MouseUp += new MouseEventHandler(dgAssets_MouseUp);
            _txtSite = new TextBox();
            _dtpFirstVisitDate = new DateTimePicker();
            _lblFirstVisitDate = new Label();
            _cboVisitFrequencyID = new ComboBox();
            _lblVisitFrequencyID = new Label();
            _lblSite = new Label();
            _grpVisits = new GroupBox();
            _dgVisits = new DataGrid();
            _dgVisits.DoubleClick += new EventHandler(dgVisits_DoubleClick);
            _grpContractSite.SuspendLayout();
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgVisitsSetup).BeginInit();
            _grpScheduleOfRates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSystemRates).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_dgScheduleOfRates).BeginInit();
            _grpAssets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgAssets).BeginInit();
            _grpVisits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgVisits).BeginInit();
            SuspendLayout();
            // 
            // grpContractSite
            // 
            _grpContractSite.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpContractSite.Controls.Add(_GroupBox1);
            _grpContractSite.Controls.Add(_chkCommercial);
            _grpContractSite.Controls.Add(_txtVisitDuration);
            _grpContractSite.Controls.Add(_txtAdditionalNotes);
            _grpContractSite.Controls.Add(_Label2);
            _grpContractSite.Controls.Add(_chkLLCertificateReqd);
            _grpContractSite.Controls.Add(_grpScheduleOfRates);
            _grpContractSite.Controls.Add(_Label1);
            _grpContractSite.Controls.Add(_grpAssets);
            _grpContractSite.Controls.Add(_txtSite);
            _grpContractSite.Controls.Add(_dtpFirstVisitDate);
            _grpContractSite.Controls.Add(_lblFirstVisitDate);
            _grpContractSite.Controls.Add(_cboVisitFrequencyID);
            _grpContractSite.Controls.Add(_lblVisitFrequencyID);
            _grpContractSite.Controls.Add(_lblSite);
            _grpContractSite.Controls.Add(_grpVisits);
            _grpContractSite.Location = new Point(5, 6);
            _grpContractSite.Name = "grpContractSite";
            _grpContractSite.Size = new Size(931, 600);
            _grpContractSite.TabIndex = 0;
            _grpContractSite.TabStop = false;
            _grpContractSite.Text = "Main Details";
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _GroupBox1.Controls.Add(_btnAddVisit);
            _GroupBox1.Controls.Add(_btRemoveVisit);
            _GroupBox1.Controls.Add(_dgVisitsSetup);
            _GroupBox1.Location = new Point(13, 264);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(912, 164);
            _GroupBox1.TabIndex = 15;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Commercial Contract Visits Setup";
            // 
            // btnAddVisit
            // 
            _btnAddVisit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAddVisit.Location = new Point(10, 129);
            _btnAddVisit.Name = "btnAddVisit";
            _btnAddVisit.Size = new Size(89, 23);
            _btnAddVisit.TabIndex = 4;
            _btnAddVisit.Text = "Add";
            // 
            // btRemoveVisit
            // 
            _btRemoveVisit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btRemoveVisit.Location = new Point(802, 129);
            _btRemoveVisit.Name = "btRemoveVisit";
            _btRemoveVisit.Size = new Size(101, 23);
            _btRemoveVisit.TabIndex = 5;
            _btRemoveVisit.Text = "Remove";
            // 
            // dgVisitsSetup
            // 
            _dgVisitsSetup.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgVisitsSetup.DataMember = "";
            _dgVisitsSetup.HeaderForeColor = SystemColors.ControlText;
            _dgVisitsSetup.Location = new Point(10, 21);
            _dgVisitsSetup.Name = "dgVisitsSetup";
            _dgVisitsSetup.Size = new Size(892, 102);
            _dgVisitsSetup.TabIndex = 0;
            // 
            // chkCommercial
            // 
            _chkCommercial.AutoSize = true;
            _chkCommercial.Location = new Point(161, 86);
            _chkCommercial.Name = "chkCommercial";
            _chkCommercial.RightToLeft = RightToLeft.Yes;
            _chkCommercial.Size = new Size(95, 17);
            _chkCommercial.TabIndex = 7;
            _chkCommercial.Text = "Commercial";
            _chkCommercial.UseVisualStyleBackColor = true;
            // 
            // txtVisitDuration
            // 
            _txtVisitDuration.Location = new Point(407, 88);
            _txtVisitDuration.Name = "txtVisitDuration";
            _txtVisitDuration.Size = new Size(136, 21);
            _txtVisitDuration.TabIndex = 9;
            // 
            // txtAdditionalNotes
            // 
            _txtAdditionalNotes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAdditionalNotes.Location = new Point(656, 56);
            _txtAdditionalNotes.Multiline = true;
            _txtAdditionalNotes.Name = "txtAdditionalNotes";
            _txtAdditionalNotes.ScrollBars = ScrollBars.Vertical;
            _txtAdditionalNotes.Size = new Size(265, 53);
            _txtAdditionalNotes.TabIndex = 11;
            // 
            // Label2
            // 
            _Label2.Location = new Point(549, 72);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(112, 20);
            _Label2.TabIndex = 10;
            _Label2.Text = "Additional Notes";
            // 
            // chkLLCertificateReqd
            // 
            _chkLLCertificateReqd.AutoSize = true;
            _chkLLCertificateReqd.CheckAlign = ContentAlignment.MiddleRight;
            _chkLLCertificateReqd.Location = new Point(16, 86);
            _chkLLCertificateReqd.Name = "chkLLCertificateReqd";
            _chkLLCertificateReqd.Size = new Size(139, 17);
            _chkLLCertificateReqd.TabIndex = 6;
            _chkLLCertificateReqd.Text = "L/L Certificate Reqd";
            _chkLLCertificateReqd.UseVisualStyleBackColor = true;
            // 
            // grpScheduleOfRates
            // 
            _grpScheduleOfRates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpScheduleOfRates.Controls.Add(_dgSystemRates);
            _grpScheduleOfRates.Controls.Add(_btnSiteScheduleOfRates);
            _grpScheduleOfRates.Controls.Add(_btnRemove);
            _grpScheduleOfRates.Controls.Add(_dgScheduleOfRates);
            _grpScheduleOfRates.Location = new Point(13, 109);
            _grpScheduleOfRates.Name = "grpScheduleOfRates";
            _grpScheduleOfRates.Size = new Size(912, 155);
            _grpScheduleOfRates.TabIndex = 12;
            _grpScheduleOfRates.TabStop = false;
            _grpScheduleOfRates.Text = "Contract Schedule Of Rates";
            // 
            // dgSystemRates
            // 
            _dgSystemRates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgSystemRates.DataMember = "";
            _dgSystemRates.HeaderForeColor = SystemColors.ControlText;
            _dgSystemRates.Location = new Point(11, 19);
            _dgSystemRates.Name = "dgSystemRates";
            _dgSystemRates.Size = new Size(432, 106);
            _dgSystemRates.TabIndex = 0;
            // 
            // btnSiteScheduleOfRates
            // 
            _btnSiteScheduleOfRates.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnSiteScheduleOfRates.Location = new Point(449, 126);
            _btnSiteScheduleOfRates.Name = "btnSiteScheduleOfRates";
            _btnSiteScheduleOfRates.Size = new Size(89, 23);
            _btnSiteScheduleOfRates.TabIndex = 2;
            _btnSiteScheduleOfRates.Text = "Add";
            // 
            // btnRemove
            // 
            _btnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnRemove.Location = new Point(802, 126);
            _btnRemove.Name = "btnRemove";
            _btnRemove.Size = new Size(101, 23);
            _btnRemove.TabIndex = 3;
            _btnRemove.Text = "Remove";
            // 
            // dgScheduleOfRates
            // 
            _dgScheduleOfRates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            _dgScheduleOfRates.DataMember = "";
            _dgScheduleOfRates.HeaderForeColor = SystemColors.ControlText;
            _dgScheduleOfRates.Location = new Point(449, 19);
            _dgScheduleOfRates.Name = "dgScheduleOfRates";
            _dgScheduleOfRates.Size = new Size(454, 106);
            _dgScheduleOfRates.TabIndex = 1;
            // 
            // Label1
            // 
            _Label1.Location = new Point(307, 88);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(89, 20);
            _Label1.TabIndex = 8;
            _Label1.Text = "Visit Duration";
            // 
            // grpAssets
            // 
            _grpAssets.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _grpAssets.Controls.Add(_dgAssets);
            _grpAssets.Location = new Point(14, 434);
            _grpAssets.Name = "grpAssets";
            _grpAssets.Size = new Size(442, 156);
            _grpAssets.TabIndex = 13;
            _grpAssets.TabStop = false;
            _grpAssets.Text = "Appliances";
            // 
            // dgAssets
            // 
            _dgAssets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgAssets.DataMember = "";
            _dgAssets.HeaderForeColor = SystemColors.ControlText;
            _dgAssets.Location = new Point(10, 21);
            _dgAssets.Name = "dgAssets";
            _dgAssets.Size = new Size(423, 130);
            _dgAssets.TabIndex = 0;
            // 
            // txtSite
            // 
            _txtSite.Location = new Point(78, 19);
            _txtSite.Multiline = true;
            _txtSite.Name = "txtSite";
            _txtSite.ReadOnly = true;
            _txtSite.ScrollBars = ScrollBars.Vertical;
            _txtSite.Size = new Size(843, 31);
            _txtSite.TabIndex = 1;
            // 
            // dtpFirstVisitDate
            // 
            _dtpFirstVisitDate.Location = new Point(139, 57);
            _dtpFirstVisitDate.Name = "dtpFirstVisitDate";
            _dtpFirstVisitDate.Size = new Size(162, 21);
            _dtpFirstVisitDate.TabIndex = 3;
            _dtpFirstVisitDate.Tag = "ContractSite.FirstVisitDate";
            // 
            // lblFirstVisitDate
            // 
            _lblFirstVisitDate.Location = new Point(18, 58);
            _lblFirstVisitDate.Name = "lblFirstVisitDate";
            _lblFirstVisitDate.Size = new Size(89, 20);
            _lblFirstVisitDate.TabIndex = 2;
            _lblFirstVisitDate.Text = "First Visit Date";
            // 
            // cboVisitFrequencyID
            // 
            _cboVisitFrequencyID.Cursor = Cursors.Hand;
            _cboVisitFrequencyID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboVisitFrequencyID.Location = new Point(407, 58);
            _cboVisitFrequencyID.Name = "cboVisitFrequencyID";
            _cboVisitFrequencyID.Size = new Size(136, 21);
            _cboVisitFrequencyID.TabIndex = 5;
            _cboVisitFrequencyID.Tag = "ContractSite.VisitFrequencyID";
            // 
            // lblVisitFrequencyID
            // 
            _lblVisitFrequencyID.Location = new Point(307, 57);
            _lblVisitFrequencyID.Name = "lblVisitFrequencyID";
            _lblVisitFrequencyID.Size = new Size(94, 20);
            _lblVisitFrequencyID.TabIndex = 4;
            _lblVisitFrequencyID.Text = "Visit Frequency";
            // 
            // lblSite
            // 
            _lblSite.Location = new Point(13, 19);
            _lblSite.Name = "lblSite";
            _lblSite.Size = new Size(64, 20);
            _lblSite.TabIndex = 0;
            _lblSite.Text = "Property";
            // 
            // grpVisits
            // 
            _grpVisits.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _grpVisits.Controls.Add(_dgVisits);
            _grpVisits.Location = new Point(462, 434);
            _grpVisits.Name = "grpVisits";
            _grpVisits.Size = new Size(465, 157);
            _grpVisits.TabIndex = 14;
            _grpVisits.TabStop = false;
            _grpVisits.Text = "Visits Created";
            // 
            // dgVisits
            // 
            _dgVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgVisits.DataMember = "";
            _dgVisits.HeaderForeColor = SystemColors.ControlText;
            _dgVisits.Location = new Point(10, 21);
            _dgVisits.Name = "dgVisits";
            _dgVisits.Size = new Size(446, 131);
            _dgVisits.TabIndex = 0;
            // 
            // UCContractOriginalSite
            // 
            Controls.Add(_grpContractSite);
            Name = "UCContractOriginalSite";
            Size = new Size(941, 616);
            _grpContractSite.ResumeLayout(false);
            _grpContractSite.PerformLayout();
            _GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgVisitsSetup).EndInit();
            _grpScheduleOfRates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgSystemRates).EndInit();
            ((System.ComponentModel.ISupportInitialize)_dgScheduleOfRates).EndInit();
            _grpAssets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgAssets).EndInit();
            _grpVisits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgVisits).EndInit();
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
                return CurrentContractSite;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraTest);

        public event StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.ContractOriginalSites.ContractOriginalSite _OldContractSite;

        public Entity.ContractOriginalSites.ContractOriginalSite OldContractSite
        {
            get
            {
                return _OldContractSite;
            }

            set
            {
                _OldContractSite = value;
            }
        }

        private Entity.ContractOriginalSites.ContractOriginalSite _currentContractSite;

        public Entity.ContractOriginalSites.ContractOriginalSite CurrentContractSite
        {
            get
            {
                return _currentContractSite;
            }

            set
            {
                _currentContractSite = value;
                SetupSystemRatesDataGrid();
                SystemRates = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll_WithoutDefaults();
                if (_currentContractSite is null)
                {
                    _currentContractSite = new Entity.ContractOriginalSites.ContractOriginalSite();
                    _currentContractSite.Exists = false;
                }

                if (_currentContractSite.Exists)
                {
                    Populate();
                    dtpFirstVisitDate.Enabled = false;
                    cboVisitFrequencyID.Enabled = false;
                    txtVisitDuration.Enabled = false;
                    // Me.cboVisitDuration.Enabled = False
                    Visits = App.DB.ContractOriginalPPMVisit.GetAll_For_ContractSiteID(_currentContractSite.ContractSiteID);
                }
                else if (OldContractSite is null)
                {
                    _currentContractSite.ContractSiteScheduleOfRates = BuildUpScheduleOfRatesDataview();
                    dtpFirstVisitDate.Value = CurrentContract.ContractStartDate;
                }
                else
                {
                    _currentContractSite.ContractSiteScheduleOfRates = OldContractSite.ContractSiteScheduleOfRates;
                    int visitDuration = 0;
                    foreach (DataRow drSOR in CurrentContractSite.ContractSiteScheduleOfRates.Table.Rows)
                        visitDuration += drSOR["Qty"] * drSOR["TimeInMins"];
                    _currentContractSite.SetVisitDuration = visitDuration;
                    _currentContractSite.SetAdditionalNotes = OldContractSite.AdditionalNotes;
                    _currentContractSite.SetIncludeAssetPrice = OldContractSite.IncludeAssetPrice;
                    _currentContractSite.SetIncludeMileagePrice = OldContractSite.IncludeMileagePrice;
                    _currentContractSite.SetIncludeRates = OldContractSite.IncludeRates;
                    _currentContractSite.SetLLCertReqd = OldContractSite.LLCertReqd;
                    _currentContractSite.SetPricePerMile = OldContractSite.PricePerMile;
                    _currentContractSite.SetPricePerVisit = OldContractSite.PricePerVisit;
                    _currentContractSite.SetAverageMileage = OldContractSite.AverageMileage;
                    _currentContractSite.SetTotalSitePrice = OldContractSite.TotalSitePrice;
                    _currentContractSite.SetVisitFrequencyID = OldContractSite.VisitFrequencyID;
                    _currentContractSite.FirstVisitDate = OldContractSite.FirstVisitDate;
                    Populate();
                }

                Site = App.DB.Sites.Get(SiteID);
                txtSite.Text = Strings.Replace(Strings.Replace(Strings.Replace(Site.Address1 + ", " + Site.Address2 + ", " + Site.Address3 + ", " + Site.Address4 + ", " + Site.Address5 + ", " + Site.Postcode + ".", ", , ", ", "), ", , ", ", "), ", , ", ", ");
            }
        }

        private int _SiteID = 0;

        public int SiteID
        {
            get
            {
                return _SiteID;
            }

            set
            {
                _SiteID = value;
            }
        }

        private Entity.Sites.Site _site;

        public Entity.Sites.Site Site
        {
            get
            {
                return _site;
            }

            set
            {
                _site = value;
            }
        }

        private Entity.ContractsOriginal.ContractOriginal _CurrentContract;

        public Entity.ContractsOriginal.ContractOriginal CurrentContract
        {
            get
            {
                return _CurrentContract;
            }

            set
            {
                _CurrentContract = value;
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
                _Assets.Table.TableName = Enums.TableNames.tblContractSiteAsset.ToString();
                _Assets.AllowNew = false;
                _Assets.AllowEdit = true;
                _Assets.AllowDelete = false;
                dgAssets.DataSource = Assets;
            }
        }

        private DataView _SystemRates;

        private DataView SystemRates
        {
            get
            {
                return _SystemRates;
            }

            set
            {
                _SystemRates = value;
                _SystemRates.Table.TableName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
                _SystemRates.AllowNew = false;
                _SystemRates.AllowEdit = true;
                _SystemRates.AllowDelete = false;
                dgSystemRates.DataSource = SystemRates;
            }
        }

        private DataRow SelectedSystemRatesDataRow
        {
            get
            {
                if (!(dgSystemRates.CurrentRowIndex == -1))
                {
                    return SystemRates[dgSystemRates.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _Visits;

        private DataView Visits
        {
            get
            {
                return _Visits;
            }

            set
            {
                _Visits = value;
                _Visits.Table.TableName = Enums.TableNames.tblContractPPMVisit.ToString();
                _Visits.AllowNew = false;
                _Visits.AllowEdit = true;
                _Visits.AllowDelete = false;
                dgVisits.DataSource = Visits;
            }
        }

        private DataView _Visits2;

        private DataView Visits2
        {
            get
            {
                return _Visits2;
            }

            set
            {
                _Visits2 = value;
                _Visits2.Table.TableName = Enums.TableNames.tblContractPPMVisit.ToString();
                _Visits2.AllowNew = false;
                _Visits2.AllowEdit = true;
                _Visits2.AllowDelete = false;
                dgVisitsSetup.DataSource = Visits2;
            }
        }

        private DataRow SelectedVisitDataRow
        {
            get
            {
                if (!(dgVisits.CurrentRowIndex == -1))
                {
                    return Visits[dgVisits.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataRow SelectedVisitDataRow2
        {
            get
            {
                if (!(dgVisitsSetup.CurrentRowIndex == -1))
                {
                    return Visits2[dgVisitsSetup.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataRow SelectedAssetDataRow
        {
            get
            {
                if (!(dgAssets.CurrentRowIndex == -1))
                {
                    return Assets[dgAssets.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataRow SelectedRatesDataRow
        {
            get
            {
                if (!(dgScheduleOfRates.CurrentRowIndex == -1))
                {
                    return CurrentContractSite.ContractSiteScheduleOfRates[dgScheduleOfRates.CurrentRowIndex].Row;
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
            Helper.SetUpDataGrid(dgAssets);
            var tStyle = dgAssets.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            dgAssets.ReadOnly = false;
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 50;
            Tick.NullText = "";
            tStyle.GridColumnStyles.Add(Tick);
            var Product = new DataGridLabelColumn();
            Product.Format = "";
            Product.FormatInfo = null;
            Product.HeaderText = "Product";
            Product.MappingName = "Product";
            Product.ReadOnly = true;
            Product.Width = 94;
            Product.NullText = "";
            tStyle.GridColumnStyles.Add(Product);
            var Location = new DataGridLabelColumn();
            Location.Format = "";
            Location.FormatInfo = null;
            Location.HeaderText = "Location";
            Location.MappingName = "Location";
            Location.ReadOnly = true;
            Location.Width = 94;
            Location.NullText = "";
            tStyle.GridColumnStyles.Add(Location);
            var SerialNum = new DataGridLabelColumn();
            SerialNum.Format = "";
            SerialNum.FormatInfo = null;
            SerialNum.HeaderText = "Serial Number";
            SerialNum.MappingName = "SerialNum";
            SerialNum.ReadOnly = true;
            SerialNum.Width = 94;
            SerialNum.NullText = "";
            tStyle.GridColumnStyles.Add(SerialNum);
            var PricePerVisit = new DataGridEditableTextBoxColumn();
            PricePerVisit.Format = "C";
            PricePerVisit.FormatInfo = null;
            PricePerVisit.HeaderText = "Price Per Visit (Click cell to change)";
            PricePerVisit.MappingName = "PricePerVisit";
            PricePerVisit.ReadOnly = false;
            PricePerVisit.Width = 150;
            PricePerVisit.NullText = "";
            tStyle.GridColumnStyles.Add(PricePerVisit);
            tStyle.ReadOnly = false;
            tStyle.MappingName = Enums.TableNames.tblContractSiteAsset.ToString();
            dgAssets.TableStyles.Add(tStyle);

            // Entity.Sys.Helper.RemoveEventHandlers(Me.dgAssets)
        }

        public void SetupVisitDataGrid()
        {
            Helper.SetUpDataGrid(dgVisits);
            var tStyle = dgVisits.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var EstimatedVisitDate = new DataGridLabelColumn();
            EstimatedVisitDate.Format = "dd/MM/yyyy";
            EstimatedVisitDate.FormatInfo = null;
            EstimatedVisitDate.HeaderText = "Estimated Visit Date";
            EstimatedVisitDate.MappingName = "EstimatedVisitDate";
            EstimatedVisitDate.ReadOnly = true;
            EstimatedVisitDate.Width = 130;
            EstimatedVisitDate.NullText = "";
            tStyle.GridColumnStyles.Add(EstimatedVisitDate);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job No.";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 80;
            JobNumber.NullText = "";
            tStyle.GridColumnStyles.Add(JobNumber);
            var StartDateTime = new DataGridLabelColumn();
            StartDateTime.Format = "dd/MM/yyyy";
            StartDateTime.FormatInfo = null;
            StartDateTime.HeaderText = "Visit Date";
            StartDateTime.MappingName = "StartDateTime";
            StartDateTime.ReadOnly = true;
            StartDateTime.Width = 80;
            StartDateTime.NullText = "Not Set";
            tStyle.GridColumnStyles.Add(StartDateTime);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Engineer";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 100;
            Name.NullText = "N/A";
            tStyle.GridColumnStyles.Add(Name);
            tStyle.ReadOnly = false;
            tStyle.MappingName = Enums.TableNames.tblContractPPMVisit.ToString();
            dgVisits.TableStyles.Add(tStyle);
        }

        public void SetupVisit2DataGrid()
        {
            Helper.SetUpDataGrid(dgVisitsSetup);
            var tStyle = dgVisitsSetup.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var VisitType = new DataGridLabelColumn();
            VisitType.Format = "dd/MM/yyyy";
            VisitType.FormatInfo = null;
            VisitType.HeaderText = "Visit Type";
            VisitType.MappingName = "VisitType";
            VisitType.ReadOnly = true;
            VisitType.Width = 130;
            VisitType.NullText = "";
            tStyle.GridColumnStyles.Add(VisitType);
            var Frequency = new DataGridLabelColumn();
            Frequency.Format = "";
            Frequency.FormatInfo = null;
            Frequency.HeaderText = "Frequency";
            Frequency.MappingName = "Frequency";
            Frequency.ReadOnly = true;
            Frequency.Width = 150;
            Frequency.NullText = "";
            tStyle.GridColumnStyles.Add(Frequency);
            var VisitDate = new DataGridLabelColumn();
            VisitDate.Format = "dd/MM/yyyy";
            VisitDate.FormatInfo = null;
            VisitDate.HeaderText = "Est Visit Date";
            VisitDate.MappingName = "VisitDate";
            VisitDate.ReadOnly = true;
            VisitDate.Width = 200;
            VisitDate.NullText = "Not Set";
            tStyle.GridColumnStyles.Add(VisitDate);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "SubCon / Pref Engineers";
            Name.MappingName = "EngName";
            Name.ReadOnly = true;
            Name.Width = 250;
            Name.NullText = "N/A";
            tStyle.GridColumnStyles.Add(Name);
            var PricePerVisit = new DataGridEditableTextBoxColumn();
            PricePerVisit.Format = "C";
            PricePerVisit.FormatInfo = null;
            PricePerVisit.HeaderText = "Cost";
            PricePerVisit.MappingName = "COST";
            PricePerVisit.ReadOnly = false;
            PricePerVisit.Width = 150;
            PricePerVisit.NullText = "";
            tStyle.GridColumnStyles.Add(PricePerVisit);
            tStyle.ReadOnly = false;
            tStyle.MappingName = Enums.TableNames.tblContractPPMVisit.ToString();
            dgVisitsSetup.TableStyles.Add(tStyle);
        }

        public void SetupSystemRatesDataGrid()
        {
            Helper.SetUpDataGrid(dgSystemRates);
            var tStyle = dgSystemRates.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            dgSystemRates.ReadOnly = false;
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tStyle.GridColumnStyles.Add(Tick);
            var QtyPerVisit = new DataGridEditableTextBoxColumn();
            QtyPerVisit.Format = "D"; // Decimal
            QtyPerVisit.FormatInfo = null;
            QtyPerVisit.HeaderText = "Quantity To Add";
            QtyPerVisit.MappingName = "Qty";
            QtyPerVisit.ReadOnly = false;
            QtyPerVisit.Width = 100;
            QtyPerVisit.NullText = "";
            tStyle.GridColumnStyles.Add(QtyPerVisit);
            var Category = new DataGridLabelColumn();
            Category.Format = "";
            Category.FormatInfo = null;
            Category.HeaderText = "Category";
            Category.MappingName = "Category";
            Category.ReadOnly = true;
            Category.Width = 100;
            Category.NullText = "";
            tStyle.GridColumnStyles.Add(Category);
            var Code = new DataGridLabelColumn();
            Code.Format = "";
            Code.FormatInfo = null;
            Code.HeaderText = "Code";
            Code.MappingName = "Code";
            Code.ReadOnly = true;
            Code.Width = 100;
            Code.NullText = "";
            tStyle.GridColumnStyles.Add(Code);
            var Description = new DataGridLabelColumn();
            Description.Format = "";
            Description.FormatInfo = null;
            Description.HeaderText = "Description";
            Description.MappingName = "Description";
            Description.ReadOnly = true;
            Description.Width = 150;
            Description.NullText = "";
            tStyle.GridColumnStyles.Add(Description);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Unit Price";
            Price.MappingName = "Price";
            Price.ReadOnly = false;
            Price.Width = 80;
            Price.NullText = "";
            tStyle.GridColumnStyles.Add(Price);
            tStyle.MappingName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
            dgSystemRates.TableStyles.Add(tStyle);
        }

        public void SetupScheduleOfRatesDataGrid()
        {
            Helper.SetUpDataGrid(dgScheduleOfRates);
            var tStyle = dgScheduleOfRates.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Category = new DataGridLabelColumn();
            Category.Format = "";
            Category.FormatInfo = null;
            Category.HeaderText = "Category";
            Category.MappingName = "Category";
            Category.ReadOnly = true;
            Category.Width = 100;
            Category.NullText = "";
            tStyle.GridColumnStyles.Add(Category);
            var Code = new DataGridLabelColumn();
            Code.Format = "";
            Code.FormatInfo = null;
            Code.HeaderText = "Code";
            Code.MappingName = "Code";
            Code.ReadOnly = true;
            Code.Width = 100;
            Code.NullText = "";
            tStyle.GridColumnStyles.Add(Code);
            var Description = new DataGridLabelColumn();
            Description.Format = "";
            Description.FormatInfo = null;
            Description.HeaderText = "Description";
            Description.MappingName = "Description";
            Description.ReadOnly = true;
            Description.Width = 150;
            Description.NullText = "";
            tStyle.GridColumnStyles.Add(Description);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Unit Price";
            Price.MappingName = "Price";
            Price.ReadOnly = false;
            Price.Width = 80;
            Price.NullText = "";
            tStyle.GridColumnStyles.Add(Price);
            var QtyPerVisit = new DataGridLabelColumn();
            QtyPerVisit.Format = "";
            QtyPerVisit.FormatInfo = null;
            QtyPerVisit.HeaderText = "Unit Qty Per Visit";
            QtyPerVisit.MappingName = "Qty";
            QtyPerVisit.ReadOnly = false;
            QtyPerVisit.Width = 100;
            QtyPerVisit.NullText = "";
            tStyle.GridColumnStyles.Add(QtyPerVisit);
            tStyle.ReadOnly = false;
            tStyle.MappingName = Enums.TableNames.tblContractOriginalSiteRates.ToString();
            dgScheduleOfRates.TableStyles.Add(tStyle);
        }

        private void UCContractSite_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
            if (Visits2 is null)
            {
                Visits2 = App.DB.ContractVisits.GetAll_For_ContractSiteID(0); // generate a grid
            }
        }

        private void dgAssets_MouseUp(object sender, MouseEventArgs e)
        {
            DataGrid.HitTestInfo HitTestInfo;
            HitTestInfo = dgAssets.HitTest(e.X, e.Y);
            if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
            {
                dgAssets.CurrentRowIndex = HitTestInfo.Row;
            }

            if (HitTestInfo.Column == 0)
            {
                bool selected = !Helper.MakeBooleanValid(dgAssets[dgAssets.CurrentRowIndex, 0]);
                Assets.Table.Rows[dgAssets.CurrentRowIndex]["Tick"] = selected;
            }
        }

        private void dgSystemRates_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (SelectedSystemRatesDataRow is null)
                {
                    return;
                }

                DataGrid.HitTestInfo HitTestInfo;
                HitTestInfo = dgSystemRates.HitTest(e.X, e.Y);
                if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
                {
                    dgSystemRates.CurrentRowIndex = HitTestInfo.Row;
                }

                if (HitTestInfo.Column == 0)
                {
                    bool selected = !Conversions.ToBoolean(dgSystemRates[dgSystemRates.CurrentRowIndex, 0]);
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedSystemRatesDataRow["Qty"], 0, false)))
                    {
                        SelectedSystemRatesDataRow["Qty"] = 1;
                    }

                    dgSystemRates[dgSystemRates.CurrentRowIndex, 0] = selected;
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (SelectedRatesDataRow is object)
            {
                {
                    var withBlock = SelectedRatesDataRow;
                    if ((int)MessageBox.Show(Conversions.ToString("DELETE :" + withBlock["Description"]), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (int)MsgBoxResult.Yes)
                    {
                        // REMOVE SOR TIME
                        int visitDuration = Helper.MakeIntegerValid(txtVisitDuration.Text);
                        visitDuration -= SelectedRatesDataRow["Qty"] * SelectedRatesDataRow["TimeInMins"];
                        txtVisitDuration.Text = visitDuration.ToString();
                        if (Conversions.ToBoolean(SelectedRatesDataRow["ContractOriginalSiteRateID"] > 0))
                        {
                            App.DB.ContractOriginalSiteRates.Delete(Conversions.ToInteger(SelectedRatesDataRow["ContractOriginalSiteRateID"]));
                            CurrentContractSite.ContractSiteScheduleOfRates = App.DB.ContractOriginalSiteRates.ContractOriginalSiteRates_GetForContractSite(CurrentContractSite.ContractSiteID);
                            Save();
                        }
                        else
                        {
                            CurrentContractSite.ContractSiteScheduleOfRates.Table.Rows.Remove(SelectedRatesDataRow);
                        }

                        dgScheduleOfRates.DataSource = CurrentContractSite.ContractSiteScheduleOfRates;
                    }
                }
            }
        }

        private void btnSiteScheduleOfRates_Click(object sender, EventArgs e)
        {
            foreach (DataRow tickedRow in SystemRates.Table.Select("Tick = 1"))
            {
                if (CurrentContractSite.ContractSiteScheduleOfRates.Table.Select(Conversions.ToString("RateID = " + tickedRow["SystemScheduleOfRateID"])).Length > 0)
                {
                    var updateRow = CurrentContractSite.ContractSiteScheduleOfRates.Table.Select(Conversions.ToString("RateID = " + tickedRow["SystemScheduleOfRateID"]))[0];
                    updateRow["Qty"] += tickedRow["Qty"];
                    updateRow["Updated"] = true;
                    updateRow.AcceptChanges();
                    CurrentContractSite.ContractSiteScheduleOfRates.Table.AcceptChanges();
                }
                else
                {
                    var newRow = CurrentContractSite.ContractSiteScheduleOfRates.Table.NewRow();
                    newRow["ContractOriginalSiteRateID"] = 0;
                    newRow["RateID"] = tickedRow["SystemScheduleOfRateID"];
                    newRow["ScheduleOfRatesCategoryID"] = tickedRow["ScheduleOfRatesCategoryID"];
                    newRow["Category"] = tickedRow["Category"];
                    newRow["Code"] = tickedRow["Code"];
                    newRow["Description"] = tickedRow["Description"];
                    newRow["Price"] = tickedRow["Price"];
                    newRow["TimeInMins"] = tickedRow["TimeInMins"];
                    newRow["Qty"] = tickedRow["Qty"];
                    newRow["Updated"] = false;
                    CurrentContractSite.ContractSiteScheduleOfRates.Table.Rows.Add(newRow);
                    CurrentContractSite.ContractSiteScheduleOfRates.Table.AcceptChanges();
                }

                int visitDuration = Helper.MakeIntegerValid(txtVisitDuration.Text);
                visitDuration += tickedRow["Qty"] * tickedRow["TimeInMins"];
                txtVisitDuration.Text = visitDuration.ToString();
            }

            dgScheduleOfRates.DataSource = CurrentContractSite.ContractSiteScheduleOfRates;
            foreach (DataRow tickedRow in SystemRates.Table.Select("Tick = 1"))
            {
                tickedRow["Tick"] = 0;
                tickedRow["Qty"] = 0;
            }

            SystemRates.Table.AcceptChanges();
        }

        private void dgVisits_DoubleClick(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMLogCallout), true, new object[] { SelectedVisitDataRow["JobID"], CurrentContractSite.PropertyID, this });
        }

        private void dgVisits2_DoubleClick(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMLogCallout), true, new object[] { SelectedVisitDataRow["JobID"], CurrentContractSite.PropertyID, this });
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataView BuildUpScheduleOfRatesDataview()
        {
            var newTable = new DataTable();
            newTable.Columns.Add("ContractOriginalSiteRateID");
            newTable.Columns.Add("RateID");
            newTable.Columns.Add("ScheduleOfRatesCategoryID");
            newTable.Columns.Add("Category");
            newTable.Columns.Add("Code");
            newTable.Columns.Add("Description");
            newTable.Columns.Add("TimeInMins", typeof(int));
            newTable.Columns.Add("Price", typeof(double));
            newTable.Columns.Add("Qty", typeof(int));
            newTable.Columns.Add("Updated");
            newTable.TableName = Enums.TableNames.tblContractOriginalSiteRates.ToString();
            return new DataView(newTable);
        }

        private double CalculateSiteTotal(double SORPrice)
        {
            int numberOfVisit = 0;
            var switchExpr = (Enums.VisitFrequency)Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboVisitFrequencyID));
            switch (switchExpr)
            {
                case Enums.VisitFrequency.Annually:
                    {
                        numberOfVisit = 1;
                        break;
                    }

                case Enums.VisitFrequency.Bi_Annually:
                    {
                        numberOfVisit = 2;
                        break;
                    }

                case Enums.VisitFrequency.Monthly:
                    {
                        numberOfVisit = 12;
                        break;
                    }

                case Enums.VisitFrequency.Quarterly:
                    {
                        numberOfVisit = 4;
                        break;
                    }

                case Enums.VisitFrequency.Weekly:
                    {
                        numberOfVisit = 52;
                        break;
                    }
            }

            return numberOfVisit * SORPrice;
        }

        private void Populate(int ID = 0)
        {
            if (Visits2 is null)
            {
                Visits2 = App.DB.ContractVisits.GetAll_For_ContractSiteID(0); // generate a grid
            }

            if (!(ID == 0))
            {
                CurrentContractSite = App.DB.ContractOriginalSite.Get(ID);
                SiteID = CurrentContractSite.PropertyID;
                CurrentContract.SetContractID = CurrentContractSite.ContractID;
                dgVisitsSetup.DataSource = App.DB.ContractVisits.GetAll_For_ContractSiteID(CurrentContractSite.ContractSiteID);
                Visits2 = App.DB.ContractVisits.GetAll_For_ContractSiteID(CurrentContractSite.ContractSiteID);
            }

            dtpFirstVisitDate.Value = CurrentContractSite.FirstVisitDate;
            var argcombo = cboVisitFrequencyID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentContractSite.VisitFrequencyID.ToString());
            txtVisitDuration.Text = CurrentContractSite.VisitDuration.ToString();
            txtAdditionalNotes.Text = CurrentContractSite.AdditionalNotes;
            chkLLCertificateReqd.Checked = CurrentContractSite.LLCertReqd;
            chkCommercial.Checked = CurrentContractSite.Commercial;
            dgScheduleOfRates.DataSource = CurrentContractSite.ContractSiteScheduleOfRates;
        }

        public void PopAssets()
        {
            Assets = App.DB.ContractOriginalSiteAsset.GetAll_ContractSiteID(CurrentContractSite.ContractSiteID, SiteID);
            if (!CurrentContractSite.Exists)
            {
                foreach (DataRow dr in Assets.Table.Rows)
                    dr["Tick"] = true;
            }
        }

        public bool Save()
        {
            try
            {
                if (!CurrentContractSite.ContractSiteScheduleOfRates.Table.Columns.Contains("Total"))
                {
                    CurrentContractSite.ContractSiteScheduleOfRates.Table.Columns.Add(new DataColumn("Total", typeof(double), "Price * Qty"));
                    CurrentContractSite.ContractSiteScheduleOfRates.Table.AcceptChanges();
                }

                double SORPrice;
                if (Information.IsDBNull(CurrentContractSite.ContractSiteScheduleOfRates.Table.Compute("SUM(Total)", "")))
                {
                    SORPrice = 0;
                }
                else
                {
                    SORPrice = Conversions.ToDouble(CurrentContractSite.ContractSiteScheduleOfRates.Table.Compute("SUM(Total)", ""));
                }

                Cursor = Cursors.WaitCursor;
                CurrentContractSite.IgnoreExceptionsOnSetMethods = true;
                CurrentContractSite.SetPropertyID = SiteID;
                CurrentContractSite.SetContractID = CurrentContract.ContractID;
                CurrentContractSite.SetPricePerVisit = SORPrice;
                CurrentContractSite.FirstVisitDate = dtpFirstVisitDate.Value;
                CurrentContractSite.SetVisitFrequencyID = Combo.get_GetSelectedItemValue(cboVisitFrequencyID);
                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboVisitFrequencyID)) < 1)
                {
                    CurrentContractSite.SetVisitFrequencyID = 7; // monthly
                }

                // CurrentContractSite.SetVisitDuration = Combo.GetSelectedItemValue(cboVisitDuration)
                CurrentContractSite.SetVisitDuration = txtVisitDuration.Text;
                CurrentContractSite.SetAverageMileage = 0; // :removed at Robs request
                CurrentContractSite.SetIncludeAssetPrice = false;
                CurrentContractSite.SetIncludeMileagePrice = false;
                CurrentContractSite.SetTotalSitePrice = CalculateSiteTotal(SORPrice);
                CurrentContractSite.SetPricePerMile = 0; // :removed at Robs request
                CurrentContractSite.SetIncludeRates = true;
                CurrentContractSite.SetLLCertReqd = chkLLCertificateReqd.Checked;
                CurrentContractSite.SetAdditionalNotes = txtAdditionalNotes.Text;
                CurrentContractSite.SetCommercial = chkCommercial.Checked;
                if (Visits2.Table.Rows.Count < 1)
                {
                    var cV = new Entity.ContractOriginalSites.ContractOriginalSiteValidator();
                    cV.Validate(CurrentContractSite, CurrentContract);
                }

                if (CurrentContractSite.Exists) // UPDATE
                {
                    if (App.ShowMessage("Are you sure you want to save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return default;
                    }

                    App.DB.ContractOriginalSite.Update(CurrentContractSite);

                    // DELETE AND RE INSERT ASSET
                    App.DB.ContractOriginalSiteAsset.Delete(CurrentContractSite.ContractSiteID);
                    foreach (DataRow drAsset in Assets.Table.Rows)
                    {
                        if (Helper.MakeBooleanValid(drAsset["Tick"]) == true)
                        {

                            // NOW ADD TO CONTRACT SITE AS NORMAL
                            var ContractSiteAsset = new Entity.ContractOriginalSiteAssets.ContractOriginalSiteAsset();
                            ContractSiteAsset.SetAssetID = drAsset["AssetID"];
                            ContractSiteAsset.SetContractSiteID = CurrentContractSite.ContractSiteID;
                            ContractSiteAsset.SetPricePerVisit = drAsset["PricePerVisit"];
                            ContractSiteAsset = App.DB.ContractOriginalSiteAsset.Insert(ContractSiteAsset);
                        }
                    }

                    // NOW ADD THE AMEND THE ASSETS ON JOBS WHERE THE FIRST VISIT HAS NOT BEEN DOWNLOADED
                    foreach (DataRow drJob in Visits.Table.Rows)
                    {
                        var dtEngVisits = App.DB.EngineerVisits.EngineerVisits_Get_All_JobID(Conversions.ToInteger(drJob["JobID"])).Table;
                        if ((Enums.VisitStatus)Conversions.ToInteger(dtEngVisits.Rows[0]["StatusEnumID"]) < Enums.VisitStatus.Downloaded)
                        {
                            App.DB.JobAsset.Delete(Conversions.ToInteger(drJob["JobID"]));

                            // INSERT ANY ASSETS
                            foreach (DataRow dr in Assets.Table.Rows)
                            {
                                if (Helper.MakeBooleanValid(dr["Tick"]) == true)
                                {
                                    var JobAsset = new Entity.JobAssets.JobAsset();
                                    JobAsset.SetAssetID = dr["AssetID"];
                                    JobAsset.SetJobID = drJob["JobID"];
                                    JobAsset = App.DB.JobAsset.Insert(JobAsset);
                                }
                            }
                        }
                    }

                    Assets = App.DB.ContractOriginalSiteAsset.GetAll_ContractSiteID(CurrentContractSite.ContractSiteID, SiteID);
                    foreach (DataRow drRate in CurrentContractSite.ContractSiteScheduleOfRates.Table.Rows)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(drRate["Updated"], true, false)))
                        {
                            var contractSOR = new Entity.ContractOriginalSiteRatess.ContractOriginalSiteRates();
                            contractSOR.SetContractSiteID = CurrentContractSite.ContractSiteID;
                            contractSOR.SetContractOriginalSiteRateID = drRate["ContractOriginalSiteRateID"];
                            contractSOR.SetQty = drRate["Qty"];
                            contractSOR.SetRateID = drRate["RateID"];
                            App.DB.ContractOriginalSiteRates.Update(contractSOR);
                        }
                        else if (Helper.MakeIntegerValid(drRate["ContractOriginalSiteRateID"]) == 0)
                        {
                            var contractSOR = new Entity.ContractOriginalSiteRatess.ContractOriginalSiteRates();
                            contractSOR.SetContractSiteID = CurrentContractSite.ContractSiteID;
                            contractSOR.SetQty = drRate["Qty"];
                            contractSOR.SetRateID = drRate["RateID"];
                            App.DB.ContractOriginalSiteRates.Insert(contractSOR);
                        }
                    }

                    string st = "";
                    int ii = 0;
                    foreach (DataRow dr in Visits2.Table.Rows)
                    {
                        ii += 1;
                        App.DB.ContractVisits.Delete(Conversions.ToInteger(dr["ContractVisitID"]));
                        int r = Conversions.ToInteger(App.DB.ExecuteScalar(Conversions.ToString("SELECT COUNT(*) FROM tblContractVisits WHERE ContractVisitID = " + dr["ContractVisitID"])));
                        if (r > 0) // 
                        {
                            // it has been moved on too far
                            st += "row " + ii + "couldn't be ammended as its gone past scheduled " + Constants.vbNewLine;
                        }
                        else
                        {
                            // it has been removed so please remove ppm
                            App.DB.ContractOriginalSite.Delete_Visits(Conversions.ToInteger(dr["ContractSiteID"]));
                            // then re add the visit
                            ScheduleSingleRow(dr);
                        }
                    }

                    if (Visits is null || Visits.Table.Rows.Count == 0)
                    {
                        ScheduleJob();
                    }

                    if (st.ToString().Length > 0)
                    {
                        App.ShowMessage(st, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else // INSERT
                {
                    if (App.ShowMessage("Are you sure you want to save?" + Constants.vbCrLf + "Information cannot be altered after save and jobs will be scheduled", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return default;
                    }

                    CurrentContractSite = App.DB.ContractOriginalSite.Insert(CurrentContractSite);

                    // DELETE AND RE INSERT ASSET
                    App.DB.ContractOriginalSiteAsset.Delete(CurrentContractSite.ContractSiteID);
                    foreach (DataRow drAsset in Assets.Table.Rows)
                    {
                        if (Helper.MakeBooleanValid(drAsset["Tick"]) == true)
                        {
                            var ContractSiteAsset = new Entity.ContractOriginalSiteAssets.ContractOriginalSiteAsset();
                            ContractSiteAsset.SetAssetID = drAsset["AssetID"];
                            ContractSiteAsset.SetContractSiteID = CurrentContractSite.ContractSiteID;
                            ContractSiteAsset.SetPricePerVisit = drAsset["PricePerVisit"];
                            ContractSiteAsset = App.DB.ContractOriginalSiteAsset.Insert(ContractSiteAsset);
                        }
                    }

                    foreach (DataRow drRate in CurrentContractSite.ContractSiteScheduleOfRates.Table.Rows)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(drRate["Updated"], true, false)))
                        {
                            var contractSOR = new Entity.ContractOriginalSiteRatess.ContractOriginalSiteRates();
                            contractSOR.SetContractSiteID = CurrentContractSite.ContractSiteID;
                            contractSOR.SetContractOriginalSiteRateID = drRate["ContractOriginalSiteRateID"];
                            contractSOR.SetQty = drRate["Qty"];
                            contractSOR.SetRateID = drRate["RateID"];
                            App.DB.ContractOriginalSiteRates.Update(contractSOR);
                        }
                        else if (Helper.MakeIntegerValid(drRate["ContractOriginalSiteRateID"]) == 0)
                        {
                            var contractSOR = new Entity.ContractOriginalSiteRatess.ContractOriginalSiteRates();
                            contractSOR.SetContractSiteID = CurrentContractSite.ContractSiteID;
                            contractSOR.SetQty = drRate["Qty"];
                            contractSOR.SetRateID = drRate["RateID"];
                            App.DB.ContractOriginalSiteRates.Insert(contractSOR);
                        }
                    }

                    if (Visits is null || Visits.Table.Rows.Count == 0)
                    {
                        ScheduleJob();
                    }
                }

                StateChanged?.Invoke(CurrentContractSite.ContractSiteID);
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

        private void ScheduleJob()
        {
            try
            {
                int contractDuration;

                // New Way
                DateTime startDate = Conversions.ToDate(Strings.Format(CurrentContract.ContractStartDate, "dd/MM/yyyy") + " 00:00:00");
                DateTime endDate = Conversions.ToDate(Strings.Format(CurrentContract.ContractEndDate.AddDays(1), "dd/MM/yyyy") + " 00:00:00");
                contractDuration = endDate.Subtract(startDate).Days;
                int M = Math.Abs(startDate.Year - endDate.Year);
                int months = M * 12 + Math.Abs(startDate.Month - endDate.Month);
                int days = endDate.Subtract(startDate).Days;

                // How Visit Should happen in days ' NOOOOOOO
                int numOfVisits = 0;
                int visitFreqInMonths = 0;
                int visitFreqIndays = 0;
                var switchExpr = (Enums.VisitFrequency)Conversions.ToInteger(CurrentContractSite.VisitFrequencyID);
                switch (switchExpr)
                {
                    case Enums.VisitFrequency.Annually:
                        {
                            visitFreqInMonths = 12;
                            break;
                        }

                    case Enums.VisitFrequency.Bi_Annually:
                        {
                            visitFreqInMonths = 6;
                            break;
                        }

                    case Enums.VisitFrequency.Monthly:
                        {
                            visitFreqInMonths = 1;
                            break;
                        }

                    case Enums.VisitFrequency.Quarterly:
                        {
                            visitFreqInMonths = 3;
                            break;
                        }

                    case Enums.VisitFrequency.GBS_4_Month_Visits:
                        {
                            visitFreqInMonths = 4;
                            break;
                        }

                    case Enums.VisitFrequency.Fortnightly:
                        {
                            visitFreqIndays = 14;
                            break;
                        }
                }

                if (visitFreqIndays == 0)
                {
                    numOfVisits = Conversions.ToInteger(Math.Floor(months / (double)visitFreqInMonths));
                    if (numOfVisits == 0)
                    {
                        numOfVisits = 1;
                    }
                }
                else if (visitFreqIndays > 0)
                {
                    numOfVisits = Conversions.ToInteger(Math.Floor(days / (double)visitFreqIndays));
                    if (numOfVisits == 0)
                    {
                        numOfVisits = 1;
                    }
                }

                DateTime estVisitDate = Conversions.ToDate(dtpFirstVisitDate.Value.Date + " 09:00:00");
                string jobSummary = string.Empty;
                int rateCount = 0;
                foreach (DataRow rateRow in CurrentContractSite.ContractSiteScheduleOfRates.Table.Rows)
                {
                    if (rateCount > 0)
                    {
                        jobSummary += " And ";
                    }

                    if (Conversions.ToBoolean(rateRow["Qty"] > 1))
                    {
                        jobSummary += Conversions.ToString(rateRow["Qty"] + " x ") + rateRow["Description"];
                    }
                    else
                    {
                        jobSummary += rateRow["Description"];
                    }

                    rateCount += 1;
                }

                if (CurrentContractSite.LLCertReqd == true)
                {
                    if (jobSummary.Length > 0)
                    {
                        jobSummary += ". ";
                    }

                    jobSummary += "Landlord Certificate Required";
                }

                if (jobSummary.Length > 0)
                {
                    jobSummary += ". ";
                }

                jobSummary += CurrentContractSite.AdditionalNotes;
                if (Conversions.ToDate(Strings.Format(estVisitDate, "dd/MM/yyyy") + " 00:00:00") >= Conversions.ToDate(Strings.Format(CurrentContract.ContractStartDate, "dd/MM/yyyy") + " 00:00:00") & Conversions.ToDate(Strings.Format(estVisitDate, "dd/MM/yyyy") + " 00:00:00") <= Conversions.ToDate(Strings.Format(CurrentContract.ContractEndDate, "dd/MM/yyyy") + " 00:00:00"))


                {

                    // MAKE SURE WE DON'T BOOK A SATURADY OR SUNDAY
                    if (estVisitDate.DayOfWeek == DayOfWeek.Saturday)
                    {
                        estVisitDate = estVisitDate.AddDays(2);
                    }
                    else if (estVisitDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        estVisitDate = estVisitDate.AddDays(1);
                    }

                    // CREATE JOB
                    var job = new Entity.Jobs.Job();
                    job.SetPropertyID = CurrentContractSite.PropertyID;
                    job.SetJobDefinitionEnumID = Conversions.ToInteger(Enums.JobDefinition.Contract);
                    if (chkCommercial.Checked)
                    {
                        job.SetJobTypeID = App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Commercial'")[0]["ManagerID"];
                    }
                    else if (chkLLCertificateReqd.Checked)
                    {
                        job.SetJobTypeID = App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Service and Certificate'")[0]["ManagerID"];
                    }
                    else
                    {
                        job.SetJobTypeID = App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Service'")[0]["ManagerID"];
                    }

                    job.SetStatusEnumID = Conversions.ToInteger(Enums.JobStatus.Open);
                    job.SetCreatedByUserID = App.loggedInUser.UserID;
                    job.SetFOC = true;
                    var JobNumber = new JobNumber();
                    JobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Contract);
                    job.SetJobNumber = JobNumber.Prefix + JobNumber.JobNumber;
                    job.SetPONumber = "";
                    job.SetQuoteID = 0;
                    job.SetContractID = CurrentContract.ContractID;
                    if ((Enums.ContractStatus)Conversions.ToInteger(CurrentContract.ContractStatusID) == Enums.ContractStatus.Inactive)
                    {
                        job.SetDeleted = true;
                    }

                    // INSERT ANY ASSETS
                    foreach (DataRow dr in Assets.Table.Rows)
                    {
                        if (Helper.MakeBooleanValid(dr["Tick"]) == true)
                        {
                            var JobAsset = new Entity.JobAssets.JobAsset();
                            JobAsset.SetAssetID = dr["AssetID"];
                            job.Assets.Add(JobAsset);
                        }
                    }

                    // INSERT JOB ITEM
                    var jobOfWork = new Entity.JobOfWorks.JobOfWork();
                    jobOfWork.SetPONumber = "";
                    jobOfWork.IgnoreExceptionsOnSetMethods = true;
                    if ((Enums.ContractStatus)Conversions.ToInteger(CurrentContract.ContractStatusID) == Enums.ContractStatus.Inactive)
                    {
                        jobOfWork.SetDeleted = true;
                    }

                    foreach (DataRow sorRow in CurrentContractSite.ContractSiteScheduleOfRates.Table.Rows)
                    {
                        var customerSors = App.DB.CustomerScheduleOfRate.Exists(Conversions.ToInteger(sorRow["ScheduleOfRatesCategoryID"]), Conversions.ToString(sorRow["Description"]), Conversions.ToString(sorRow["Code"]), Site.CustomerID);
                        int customerSorId = 0;
                        if (customerSors.Rows.Count > 0)
                            customerSorId = Helper.MakeIntegerValid(customerSors.Rows[0][0]);
                        if (!(customerSorId > 0))
                        {
                            var customerSor = new Entity.CustomerScheduleOfRates.CustomerScheduleOfRate()
                            {
                                SetCode = sorRow["Code"],
                                SetDescription = sorRow["Description"],
                                SetPrice = sorRow["Price"],
                                SetScheduleOfRatesCategoryID = sorRow["ScheduleOfRatesCategoryID"],
                                SetTimeInMins = sorRow["TimeInMins"],
                                SetCustomerID = Site.CustomerID
                            };
                            customerSorId = App.DB.CustomerScheduleOfRate.Insert(customerSor).CustomerScheduleOfRateID;
                            App.DB.CustomerScheduleOfRate.Delete(customerSorId);
                        }

                        var jobItem = new Entity.JobItems.JobItem();
                        jobItem.IgnoreExceptionsOnSetMethods = true;
                        jobItem.SetSummary = sorRow["Description"];
                        jobItem.SetQty = 1;
                        jobItem.SetRateID = customerSorId;
                        jobItem.SetSystemLinkID = Conversions.ToInteger(Enums.TableNames.tblCustomerScheduleOfRate);
                        jobOfWork.JobItems.Add(jobItem);
                    }

                    if (jobOfWork.JobItems.Count == 0)
                    {
                        var jobItem = new Entity.JobItems.JobItem();
                        jobItem.IgnoreExceptionsOnSetMethods = true;
                        jobItem.SetSummary = jobSummary;
                        jobOfWork.JobItems.Add(jobItem);
                    }

                    // IF WE FIND A MATCHING ENGINEER INSERT ENGINEER VISIT
                    var engineerVisit = new Entity.EngineerVisits.EngineerVisit();
                    engineerVisit.IgnoreExceptionsOnSetMethods = true;
                    engineerVisit.SetEngineerID = 0; // engineerID
                    engineerVisit.SetNotesToEngineer = jobSummary;
                    engineerVisit.StartDateTime = DateTime.MinValue;
                    engineerVisit.EndDateTime = DateTime.MinValue;
                    engineerVisit.SetStatusEnumID = Conversions.ToInteger(Enums.VisitStatus.Ready_For_Schedule);
                    // End If

                    if ((Enums.ContractStatus)Conversions.ToInteger(CurrentContract.ContractStatusID) == Enums.ContractStatus.Inactive)
                    {
                        engineerVisit.SetDeleted = true;
                    }

                    jobOfWork.EngineerVisits.Add(engineerVisit);
                    job.JobOfWorks.Add(jobOfWork);
                    job = App.DB.Job.Insert(job);

                    // CREATE PPM VISIT RECORD
                    var PPM = new Entity.ContractOriginalPPMVisits.ContractOriginalPPMVisit();
                    PPM.SetContractSiteID = CurrentContractSite.ContractSiteID;
                    PPM.EstimatedVisitDate = estVisitDate;
                    PPM.SetJobID = job.JobID;
                    App.DB.ContractOriginalPPMVisit.Insert(PPM);
                    if (visitFreqIndays == 0)
                    {
                        estVisitDate = estVisitDate.AddMonths(visitFreqInMonths);
                    }
                    else if (visitFreqIndays > 0)
                    {
                        estVisitDate = estVisitDate.AddDays(visitFreqIndays);
                    }
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ScheduleSingleRow(DataRow dr)
        {
            try
            {

                // Duration OF Contract In Days
                int contractDuration;
                // contractDuration = CurrentContract.ContractEndDate.Subtract(CurrentContract.ContractStartDate).Days

                // New Way
                DateTime startDate = Conversions.ToDate(Strings.Format(CurrentContract.ContractStartDate, "dd/MM/yyyy") + " 00:00:00");
                DateTime endDate = Conversions.ToDate(Strings.Format(CurrentContract.ContractEndDate.AddDays(1), "dd/MM/yyyy") + " 00:00:00");
                contractDuration = endDate.Subtract(startDate).Days;
                int M = Math.Abs(startDate.Year - endDate.Year);
                int months = M * 12 + Math.Abs(startDate.Month - endDate.Month);
                int days = endDate.Subtract(startDate).Days;

                // How Visit Should happen in days ' NOOOOOOO
                int numOfVisits = 0;
                int visitFreqInMonths = 0;
                int visitFreqIndays = 0;
                DateTime estVisitDate = Conversions.ToDate(DateAndTime.Today.Date + " 09:00:00");
                Enums.VisitFrequency visitFrequency = (Enums.VisitFrequency)Conversions.ToInteger(dr["FrequencyID"]);
                switch (visitFrequency)
                {
                    case Enums.VisitFrequency.Annually:
                        {
                            visitFreqInMonths = 12;
                            estVisitDate = Conversions.ToDate(dr["VisitDate"].Date + " 9:00:00");
                            break;
                        }

                    case Enums.VisitFrequency.Bi_Annually:
                        {
                            visitFreqInMonths = 6;
                            estVisitDate = CurrentContract.ContractStartDate.AddMonths(6);
                            break;
                        }

                    case Enums.VisitFrequency.Monthly:
                        {
                            visitFreqInMonths = 1;
                            estVisitDate = CurrentContract.ContractStartDate.AddMonths(1);
                            break;
                        }

                    case Enums.VisitFrequency.Quarterly:
                        {
                            visitFreqInMonths = 3;
                            estVisitDate = CurrentContract.ContractStartDate.AddMonths(3);
                            break;
                        }

                    case Enums.VisitFrequency.GBS_4_Month_Visits:
                        {
                            visitFreqInMonths = 4;
                            estVisitDate = CurrentContract.ContractStartDate.AddMonths(4);
                            break;
                        }

                    case Enums.VisitFrequency.Fortnightly:
                        {
                            visitFreqIndays = 14;
                            estVisitDate = CurrentContract.ContractStartDate.AddDays(14);
                            break;
                        }
                }

                if (visitFreqIndays == 0)
                {
                    numOfVisits = Conversions.ToInteger(Math.Floor(months / (double)visitFreqInMonths));
                    if (numOfVisits == 0)
                    {
                        numOfVisits = 1;
                    }
                }
                else if (visitFreqIndays > 0)
                {
                    numOfVisits = Conversions.ToInteger(Math.Floor(days / (double)visitFreqIndays));
                    if (numOfVisits == 0)
                    {
                        numOfVisits = 1;
                    }
                }

                string jobSummary = string.Empty;
                int rateCount = 0;
                int time = Conversions.ToInteger(dr["HoursReq"]);

                // MAKE SURE WE DON'T BOOK A SATURADY OR SUNDAY
                if (estVisitDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    estVisitDate = estVisitDate.AddDays(2);
                }
                else if (estVisitDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    estVisitDate = estVisitDate.AddDays(1);
                }

                // CREATE JOB
                var job = new Entity.Jobs.Job();
                job.SetPropertyID = CurrentContractSite.PropertyID;
                job.SetJobDefinitionEnumID = Conversions.ToInteger(Enums.JobDefinition.Contract);

                // If chkCommercial.Checked Then

                job.SetJobTypeID = App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Commercial'")[0]["ManagerID"];
                job.SetStatusEnumID = Conversions.ToInteger(Enums.JobStatus.Open);
                job.SetCreatedByUserID = App.loggedInUser.UserID;
                job.SetFOC = true;
                var JobNumber = new JobNumber();
                JobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Contract);
                job.SetJobNumber = JobNumber.Prefix + JobNumber.JobNumber;
                job.SetPONumber = "";
                job.SetQuoteID = 0;
                job.SetContractID = CurrentContract.ContractID;

                // INSERT ANY ASSETS
                foreach (DataRow dr2 in Assets.Table.Rows)
                {
                    if (Helper.MakeBooleanValid(dr2["Tick"]) == true)
                    {
                        var JobAsset = new Entity.JobAssets.JobAsset();
                        JobAsset.SetAssetID = dr2["AssetID"];
                        job.Assets.Add(JobAsset);
                    }
                }

                while (time > 0)
                {

                    // INSERT JOB ITEM
                    var jobOfWork = new Entity.JobOfWorks.JobOfWork();
                    jobOfWork.SetPONumber = "";
                    jobOfWork.IgnoreExceptionsOnSetMethods = true;
                    if ((Enums.ContractStatus)Conversions.ToInteger(CurrentContract.ContractStatusID) == Enums.ContractStatus.Inactive)
                    {
                        jobOfWork.SetDeleted = true;
                    }

                    string description = "";
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["VisitType"], "SubContractor", false)))
                    {
                        description = dr["SubContractor"].ToString() + " ";
                    }
                    else
                    {
                        description = Conversions.ToString(dr["VisitType"] + " Service ");
                    }

                    switch (visitFrequency)
                    {
                        case Enums.VisitFrequency.Annually:
                            {
                                description += "Annual Visit. ";
                                break;
                            }

                        default:
                            {
                                description += dr["Frequency"] + " Visit. ";
                                break;
                            }
                    }

                    var customerSors = App.DB.CustomerScheduleOfRate.Exists(4701, "Contracted Visit", "C3", Site.CustomerID);
                    int customerSorId = 0;
                    if (customerSors.Rows.Count > 0)
                        customerSorId = Helper.MakeIntegerValid(customerSors.Rows[0][0]);
                    if (!(customerSorId > 0))
                    {
                        var customerSor = new Entity.CustomerScheduleOfRates.CustomerScheduleOfRate()
                        {
                            SetCode = "C3",
                            SetDescription = "Contracted Visit",
                            SetPrice = 0,
                            SetScheduleOfRatesCategoryID = 4701,
                            SetTimeInMins = 60,
                            SetCustomerID = Site.CustomerID
                        };
                        customerSorId = App.DB.CustomerScheduleOfRate.Insert(customerSor).CustomerScheduleOfRateID;
                    }

                    int jobitemtime = 0;
                    if (time < 8.1)
                    {
                        jobitemtime = time;
                        time = 0;
                    }
                    else
                    {
                        jobitemtime = 8;
                        time = time - 8;
                    }

                    var jobItem = new Entity.JobItems.JobItem();
                    jobItem.IgnoreExceptionsOnSetMethods = true;
                    jobItem.SetSummary = description;
                    jobItem.SetQty = jobitemtime;
                    jobItem.SetRateID = customerSorId;
                    jobItem.SetSystemLinkID = Conversions.ToInteger(Enums.TableNames.tblCustomerScheduleOfRate);
                    jobOfWork.JobItems.Add(jobItem);

                    // IF WE FIND A MATCHING ENGINEER INSERT ENGINEER VISIT
                    var engineerVisit = new Entity.EngineerVisits.EngineerVisit();
                    engineerVisit.IgnoreExceptionsOnSetMethods = true;
                    engineerVisit.SetEngineerID = 0; // engineerID
                    description += dr["AdditionalNotes"];
                    engineerVisit.SetNotesToEngineer = description;
                    engineerVisit.StartDateTime = DateTime.MinValue;
                    engineerVisit.EndDateTime = DateTime.MinValue;
                    engineerVisit.SetStatusEnumID = Conversions.ToInteger(Enums.VisitStatus.Ready_For_Schedule);
                    jobOfWork.EngineerVisits.Add(engineerVisit);
                    job.JobOfWorks.Add(jobOfWork);
                }

                job = App.DB.Job.Insert(job);

                // CREATE PPM VISIT RECORD
                var PPM = new Entity.ContractOriginalPPMVisits.ContractOriginalPPMVisit();
                PPM.SetContractSiteID = CurrentContractSite.ContractSiteID;
                PPM.EstimatedVisitDate = estVisitDate;
                PPM.SetJobID = job.JobID;
                App.DB.ContractOriginalPPMVisit.Insert(PPM);

                // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''UPDATE VISIT DATE IN tblContractVisits''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                var contractVisit = new Entity.ContractOriginalVisits.ContractOriginalVisit();
                contractVisit.SetAdditionalNotes = dr["AdditionalNotes"];
                contractVisit.SetContractSiteID = CurrentContractSite.ContractSiteID;
                contractVisit.SetCost = dr["Cost"];
                contractVisit.EstimatedVisitDate = estVisitDate;
                contractVisit.SetFrequency = dr["Frequency"];
                contractVisit.SetFrequencyID = dr["FrequencyID"];
                contractVisit.SetHoursReq = dr["HoursReq"];
                contractVisit.SetJobID = job.JobID;
                contractVisit.SetPreferredEngineer = dr["PreferredEngineer"];
                contractVisit.SetPreferredEngineerID = dr["PreferredEngineerID"];
                contractVisit.SetSubContractor = dr["SubContractor"];
                contractVisit.SetSubContractorID = dr["SubContractorID"];
                contractVisit.SetVisitType = dr["VisitType"];
                contractVisit.SetVisitTypeID = dr["VisitTypeID"];
                App.DB.ContractVisits.Insert(contractVisit);
                if (visitFreqIndays == 0)
                {
                    estVisitDate = estVisitDate.AddMonths(visitFreqInMonths);
                }
                else if (visitFreqIndays > 0)
                {
                    estVisitDate = estVisitDate.AddDays(visitFreqIndays);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ArrayList MatchingEngineer(Entity.Jobs.Job job, DateTime estVisitDate)
        {
            var site = new Entity.Sites.Site();
            int engineerID = 0;
            int slotDuration = 0; // MINTUES
            int visitDuration = 0;
            int numOfSlotsNeeded = 0;
            var match = new ArrayList();
            string postcode = "";
            DataView postcodeEngineers = null;
            int cntPostcodeEng = 0;
            int randomNum = 0;

            // SYSTEM NUMBER OF MINUTES IN A SLOTS
            slotDuration = App.DB.Manager.Get().TimeSlot;

            // VISIT DURATION FOR THIS SITE IN HOURS
            visitDuration = Conversions.ToInteger(txtVisitDuration.Text); // Combo.GetSelectedItemValue(cboVisitDuration)

            // NUM OF SLOTS NEEDED FOR VISIT
            if (visitDuration > 0)
            {
                numOfSlotsNeeded = (int)(visitDuration / (double)slotDuration);
            }
            // ***************************************************************

            // SEE IF THE SITE HAS A DEFAULT ENGINEER
            site = App.DB.Sites.Get(job.PropertyID);
            if (site.EngineerID > 0)
            {
                // IF THE SITE DOES, ARE THEY AVAILABLE ON THE DAY OR FOLLOWING 4 DAYS ( NOT WEEKENDS)
                match = CheckAvailability(estVisitDate, site.EngineerID, numOfSlotsNeeded);
            }
            // IF A ENG & SLOT IS FOUND, RETURN
            if (match.Count > 0)
            {
                return match;
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
                    match = CheckAvailability(estVisitDate, Conversions.ToInteger(postcodeEngineers.Table.Rows[randomNum]["EngineerID"]), numOfSlotsNeeded);

                    // IF A ENG & SLOT IS FOUND, RETURN
                    if (match.Count > 0)
                    {
                        return match;
                    }
                    else
                    {
                        postcodeEngineers.Table.Rows.Remove(postcodeEngineers.Table.Rows[randomNum]);
                    }
                }
            }

            return match;
        }

        private ArrayList CheckAvailability(DateTime estimatedVisitDate, int engineerID, int numOfSlotsNeeded)
        {
            DataTable engTimeSlots;
            var numOfSlotsAvailable = new ArrayList();
            var actualVisitDate = estimatedVisitDate;
            var match = new ArrayList();
            string startSlotTime = "";
            for (int day = 0; day <= 4; day++)
            {
                numOfSlotsAvailable.Clear();

                // ADD ON DAYS - UNLESS FIRST TIME IN
                if (day != 0)
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
                    for (int colCnt = 0, loopTo = engTimeSlots.Columns.Count - 1; colCnt <= loopTo; colCnt++)
                    {
                        // LOOP THOROUGH EACH COLUMNS TRYING TO FIND AVAILABLE CONSECTUTIVE COLUMNS
                        // EQUAL TO THE NUMBER OF REQUIRED SLOTS
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(engTimeSlots.Rows[0][colCnt], 0, false)))
                        {
                            numOfSlotsAvailable.Add(engTimeSlots.Columns[colCnt].ColumnName);
                            if (numOfSlotsAvailable.Count == numOfSlotsNeeded)
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
                    if (Conversions.ToBoolean(numOfSlotsAvailable.Count == numOfSlotsNeeded | Operators.ConditionalCompareObjectEqual(numOfSlotsAvailable[0], App.DB.Manager.Get().WorkingHoursStart, false)))
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
                        return match;
                    }
                }
            }

            return match;
        }

        private void btnAddVisit_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            if (Visits2 is null)
            {
                Visits2 = App.DB.ContractVisits.GetAll_For_ContractSiteID(0); // generate a grid
            }

            dt = Visits2.Table;
            var f = new DLGSetupVisit();
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                var dr = dt.NewRow();
                dr["SubContractor"] = Combo.get_GetSelectedItemDescription(f.cboSubContractor);
                dr["PreferredEngineer"] = Combo.get_GetSelectedItemDescription(f.cboPreferredEngineer);
                dr["VisitType"] = Combo.get_GetSelectedItemDescription(f.cboType);
                dr["Frequency"] = Combo.get_GetSelectedItemDescription(f.cboFrequency);
                dr["VisitTypeID"] = Combo.get_GetSelectedItemValue(f.cboType);
                dr["VisitDate"] = f.dtpTargetDate.Value;
                dr["FrequencyID"] = Combo.get_GetSelectedItemValue(f.cboFrequency);
                dr["Cost"] = f.txtFilter.Text.Replace("£", "");
                dr["SubContractorID"] = Combo.get_GetSelectedItemValue(f.cboSubContractor);
                dr["PreferredEngineerID"] = Combo.get_GetSelectedItemValue(f.cboPreferredEngineer);
                dr["HoursReq"] = f.TextBox1.Text;
                dr["AdditionalNotes"] = f.txtAdditional.Text;
                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(f.cboPreferredEngineer)) > 0)
                {
                    dr["EngName"] = Combo.get_GetSelectedItemDescription(f.cboPreferredEngineer);
                }

                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(f.cboSubContractor)) > 0)
                {
                    dr["EngName"] = Combo.get_GetSelectedItemDescription(f.cboSubContractor);
                }

                dt.Rows.Add(dr);
                dgVisitsSetup.DataSource = dt;
                Visits2.Table = dt;
            }
        }

        private void btRemoveVisit_Click(object sender, EventArgs e)
        {
            if (SelectedVisitDataRow2 is object)
            {
                {
                    var withBlock = SelectedVisitDataRow2;
                    if ((int)MessageBox.Show(Conversions.ToString("DELETE :" + withBlock["VisitType"]), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (int)MsgBoxResult.Yes)
                    {
                        // REMOVE

                        if (Information.IsDBNull(SelectedVisitDataRow2["ContractVisitID"]) || Conversions.ToBoolean(SelectedVisitDataRow2["ContractVisitID"] < 1))
                        {
                            // not in DB
                            Visits2.Table.Rows.Remove(SelectedVisitDataRow2);
                        }
                        else
                        {
                            // In DB
                            App.DB.ContractVisits.Delete(Conversions.ToInteger(SelectedVisitDataRow2["ContractVisitID"]));
                            Visits2 = App.DB.ContractVisits.GetAll_For_ContractSiteID(CurrentContractSite.ContractSiteID);
                        }

                        dgVisitsSetup.DataSource = Visits2;
                    }
                }
            }
        }
    }
}