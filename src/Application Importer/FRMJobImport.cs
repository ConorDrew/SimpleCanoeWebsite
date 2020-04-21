using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FSM.Entity.Customers;
using FSM.Entity.Engineers;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FRMJobImport : FRMBaseForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMJobImport() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            this.Load += FRMJobImport_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            var argc = cboJobType;
            Combo.SetUpCombo(ref argc, App.DB.JobImports.JobImportType_GetAll().Table, "JobImportTypeID", "Name", Enums.ComboValues.Please_Select);
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
        private GroupBox _grpExcelFile;

        internal GroupBox grpExcelFile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpExcelFile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpExcelFile != null)
                {
                }

                _grpExcelFile = value;
                if (_grpExcelFile != null)
                {
                }
            }
        }

        private TextBox _txtExcelFile;

        internal TextBox txtExcelFile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtExcelFile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtExcelFile != null)
                {
                }

                _txtExcelFile = value;
                if (_txtExcelFile != null)
                {
                }
            }
        }

        private Button _btnFindExcelFile;

        internal Button btnFindExcelFile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindExcelFile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindExcelFile != null)
                {
                    _btnFindExcelFile.Click -= btnFindExcelFile_Click;
                }

                _btnFindExcelFile = value;
                if (_btnFindExcelFile != null)
                {
                    _btnFindExcelFile.Click += btnFindExcelFile_Click;
                }
            }
        }

        private Button _btnImport;

        internal Button btnImport
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnImport;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnImport != null)
                {
                    _btnImport.Click -= btnImport_Click;
                }

                _btnImport = value;
                if (_btnImport != null)
                {
                    _btnImport.Click += btnImport_Click;
                }
            }
        }

        private Button _btnClose;

        internal Button btnClose
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClose;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClose != null)
                {
                    _btnClose.Click -= btnClose_Click;
                }

                _btnClose = value;
                if (_btnClose != null)
                {
                    _btnClose.Click += btnClose_Click;
                }
            }
        }

        private ProgressBar _pbStatus;

        internal ProgressBar pbStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pbStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pbStatus != null)
                {
                }

                _pbStatus = value;
                if (_pbStatus != null)
                {
                }
            }
        }

        private Label _lblFile;

        internal Label lblFile
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFile;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFile != null)
                {
                }

                _lblFile = value;
                if (_lblFile != null)
                {
                }
            }
        }

        private Label _lblMessages;

        internal Label lblMessages
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMessages;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMessages != null)
                {
                }

                _lblMessages = value;
                if (_lblMessages != null)
                {
                }
            }
        }

        private ComboBox _cboJobType;

        internal ComboBox cboJobType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboJobType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboJobType != null)
                {
                }

                _cboJobType = value;
                if (_cboJobType != null)
                {
                }
            }
        }

        private GroupBox _grpFailedImports;

        internal GroupBox grpFailedImports
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpFailedImports;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpFailedImports != null)
                {
                }

                _grpFailedImports = value;
                if (_grpFailedImports != null)
                {
                }
            }
        }

        private DataGrid _dgFailedImports;

        internal DataGrid dgFailedImports
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgFailedImports;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgFailedImports != null)
                {
                }

                _dgFailedImports = value;
                if (_dgFailedImports != null)
                {
                }
            }
        }

        private Button _btnExportFailed;

        internal Button btnExportFailed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnExportFailed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnExportFailed != null)
                {
                    _btnExportFailed.Click -= btnExportFailed_Click;
                }

                _btnExportFailed = value;
                if (_btnExportFailed != null)
                {
                    _btnExportFailed.Click += btnExportFailed_Click;
                }
            }
        }

        private RadioButton _radBtnJobStatus;

        internal RadioButton radBtnJobStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radBtnJobStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radBtnJobStatus != null)
                {
                    _radBtnJobStatus.CheckedChanged -= radBtnJob_CheckedChanged;
                }

                _radBtnJobStatus = value;
                if (_radBtnJobStatus != null)
                {
                    _radBtnJobStatus.CheckedChanged += radBtnJob_CheckedChanged;
                }
            }
        }

        private RadioButton _radBtnJob;

        internal RadioButton radBtnJob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radBtnJob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radBtnJob != null)
                {
                    _radBtnJob.CheckedChanged -= radBtnJob_CheckedChanged;
                }

                _radBtnJob = value;
                if (_radBtnJob != null)
                {
                    _radBtnJob.CheckedChanged += radBtnJob_CheckedChanged;
                }
            }
        }

        private Label _lblJobType;

        internal Label lblJobType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblJobType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblJobType != null)
                {
                }

                _lblJobType = value;
                if (_lblJobType != null)
                {
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

        private Label _lblVisitDate;

        internal Label lblVisitDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblVisitDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblVisitDate != null)
                {
                }

                _lblVisitDate = value;
                if (_lblVisitDate != null)
                {
                }
            }
        }

        private DateTimePicker _dtpVisitDate;

        internal DateTimePicker dtpVisitDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpVisitDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpVisitDate != null)
                {
                }

                _dtpVisitDate = value;
                if (_dtpVisitDate != null)
                {
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

        private Button _btnFindEngineer;

        internal Button btnFindEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindEngineer != null)
                {
                    _btnFindEngineer.Click -= btnFindEngineer_Click;
                }

                _btnFindEngineer = value;
                if (_btnFindEngineer != null)
                {
                    _btnFindEngineer.Click += btnFindEngineer_Click;
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

        private CheckBox _chkCreateJob;

        internal CheckBox chkCreateJob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkCreateJob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkCreateJob != null)
                {
                    _chkCreateJob.Click -= chkCreateJob_Click;
                }

                _chkCreateJob = value;
                if (_chkCreateJob != null)
                {
                    _chkCreateJob.Click += chkCreateJob_Click;
                }
            }
        }

        private Label _lblProgress;

        internal Label lblProgress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblProgress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblProgress != null)
                {
                }

                _lblProgress = value;
                if (_lblProgress != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpExcelFile = new GroupBox();
            _txtCustomer = new TextBox();
            _btnFindCustomer = new Button();
            _btnFindCustomer.Click += new EventHandler(btnFindCustomer_Click);
            _lblCustomer = new Label();
            _radBtnJobStatus = new RadioButton();
            _radBtnJobStatus.CheckedChanged += new EventHandler(radBtnJob_CheckedChanged);
            _radBtnJob = new RadioButton();
            _radBtnJob.CheckedChanged += new EventHandler(radBtnJob_CheckedChanged);
            _cboJobType = new ComboBox();
            _lblJobType = new Label();
            _lblFile = new Label();
            _btnImport = new Button();
            _btnImport.Click += new EventHandler(btnImport_Click);
            _btnFindExcelFile = new Button();
            _btnFindExcelFile.Click += new EventHandler(btnFindExcelFile_Click);
            _txtExcelFile = new TextBox();
            _btnClose = new Button();
            _btnClose.Click += new EventHandler(btnClose_Click);
            _pbStatus = new ProgressBar();
            _lblProgress = new Label();
            _lblMessages = new Label();
            _grpFailedImports = new GroupBox();
            _dgFailedImports = new DataGrid();
            _btnExportFailed = new Button();
            _btnExportFailed.Click += new EventHandler(btnExportFailed_Click);
            _txtEngineer = new TextBox();
            _btnFindEngineer = new Button();
            _btnFindEngineer.Click += new EventHandler(btnFindEngineer_Click);
            _lblEngineer = new Label();
            _dtpVisitDate = new DateTimePicker();
            _lblVisitDate = new Label();
            _chkCreateJob = new CheckBox();
            _chkCreateJob.Click += new EventHandler(chkCreateJob_Click);
            _grpExcelFile.SuspendLayout();
            _grpFailedImports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgFailedImports).BeginInit();
            SuspendLayout();
            //
            // grpExcelFile
            //
            _grpExcelFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpExcelFile.Controls.Add(_chkCreateJob);
            _grpExcelFile.Controls.Add(_lblVisitDate);
            _grpExcelFile.Controls.Add(_dtpVisitDate);
            _grpExcelFile.Controls.Add(_txtEngineer);
            _grpExcelFile.Controls.Add(_btnFindEngineer);
            _grpExcelFile.Controls.Add(_lblEngineer);
            _grpExcelFile.Controls.Add(_txtCustomer);
            _grpExcelFile.Controls.Add(_btnFindCustomer);
            _grpExcelFile.Controls.Add(_lblCustomer);
            _grpExcelFile.Controls.Add(_radBtnJobStatus);
            _grpExcelFile.Controls.Add(_radBtnJob);
            _grpExcelFile.Controls.Add(_cboJobType);
            _grpExcelFile.Controls.Add(_lblJobType);
            _grpExcelFile.Controls.Add(_lblFile);
            _grpExcelFile.Controls.Add(_btnImport);
            _grpExcelFile.Controls.Add(_btnFindExcelFile);
            _grpExcelFile.Controls.Add(_txtExcelFile);
            _grpExcelFile.FlatStyle = FlatStyle.System;
            _grpExcelFile.Location = new Point(8, 40);
            _grpExcelFile.Name = "grpExcelFile";
            _grpExcelFile.Size = new Size(896, 134);
            _grpExcelFile.TabIndex = 3;
            _grpExcelFile.TabStop = false;
            _grpExcelFile.Text = "Select data file to import";
            //
            // txtCustomer
            //
            _txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtCustomer.Location = new Point(429, 56);
            _txtCustomer.Name = "txtCustomer";
            _txtCustomer.ReadOnly = true;
            _txtCustomer.Size = new Size(423, 21);
            _txtCustomer.TabIndex = 40;
            //
            // btnFindCustomer
            //
            _btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindCustomer.Location = new Point(858, 54);
            _btnFindCustomer.Name = "btnFindCustomer";
            _btnFindCustomer.Size = new Size(32, 23);
            _btnFindCustomer.TabIndex = 39;
            _btnFindCustomer.Text = "...";
            _btnFindCustomer.UseVisualStyleBackColor = true;
            //
            // lblCustomer
            //
            _lblCustomer.AutoSize = true;
            _lblCustomer.Location = new Point(349, 59);
            _lblCustomer.Name = "lblCustomer";
            _lblCustomer.Size = new Size(74, 13);
            _lblCustomer.TabIndex = 38;
            _lblCustomer.Text = "Customers:";
            //
            // radBtnJobStatus
            //
            _radBtnJobStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _radBtnJobStatus.AutoSize = true;
            _radBtnJobStatus.Checked = true;
            _radBtnJobStatus.Location = new Point(670, 24);
            _radBtnJobStatus.Name = "radBtnJobStatus";
            _radBtnJobStatus.Size = new Size(84, 17);
            _radBtnJobStatus.TabIndex = 37;
            _radBtnJobStatus.TabStop = true;
            _radBtnJobStatus.Text = "Job Status";
            _radBtnJobStatus.UseVisualStyleBackColor = true;
            //
            // radBtnJob
            //
            _radBtnJob.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _radBtnJob.AutoSize = true;
            _radBtnJob.Location = new Point(760, 24);
            _radBtnJob.Name = "radBtnJob";
            _radBtnJob.Size = new Size(44, 17);
            _radBtnJob.TabIndex = 36;
            _radBtnJob.Text = "Job";
            _radBtnJob.UseVisualStyleBackColor = true;
            //
            // cboJobType
            //
            _cboJobType.Cursor = Cursors.Hand;
            _cboJobType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboJobType.Location = new Point(86, 56);
            _cboJobType.Name = "cboJobType";
            _cboJobType.Size = new Size(242, 21);
            _cboJobType.TabIndex = 35;
            _cboJobType.Tag = "Site.RegionID";
            //
            // lblJobType
            //
            _lblJobType.AutoSize = true;
            _lblJobType.Location = new Point(6, 59);
            _lblJobType.Name = "lblJobType";
            _lblJobType.Size = new Size(62, 13);
            _lblJobType.TabIndex = 19;
            _lblJobType.Text = "Job Type:";
            //
            // lblFile
            //
            _lblFile.AutoSize = true;
            _lblFile.Location = new Point(6, 23);
            _lblFile.Name = "lblFile";
            _lblFile.Size = new Size(31, 13);
            _lblFile.TabIndex = 13;
            _lblFile.Text = "File:";
            //
            // btnImport
            //
            _btnImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnImport.Enabled = false;
            _btnImport.FlatStyle = FlatStyle.System;
            _btnImport.Location = new Point(826, 18);
            _btnImport.Name = "btnImport";
            _btnImport.Size = new Size(64, 23);
            _btnImport.TabIndex = 7;
            _btnImport.Text = "Import";
            //
            // btnFindExcelFile
            //
            _btnFindExcelFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindExcelFile.FlatStyle = FlatStyle.System;
            _btnFindExcelFile.Location = new Point(616, 20);
            _btnFindExcelFile.Name = "btnFindExcelFile";
            _btnFindExcelFile.Size = new Size(32, 23);
            _btnFindExcelFile.TabIndex = 5;
            _btnFindExcelFile.Text = "...";
            //
            // txtExcelFile
            //
            _txtExcelFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtExcelFile.Location = new Point(43, 20);
            _txtExcelFile.Name = "txtExcelFile";
            _txtExcelFile.ReadOnly = true;
            _txtExcelFile.Size = new Size(567, 21);
            _txtExcelFile.TabIndex = 4;
            //
            // btnClose
            //
            _btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnClose.FlatStyle = FlatStyle.System;
            _btnClose.Location = new Point(848, 624);
            _btnClose.Name = "btnClose";
            _btnClose.Size = new Size(56, 23);
            _btnClose.TabIndex = 9;
            _btnClose.Text = "Close";
            //
            // pbStatus
            //
            _pbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _pbStatus.Location = new Point(8, 624);
            _pbStatus.Name = "pbStatus";
            _pbStatus.Size = new Size(784, 23);
            _pbStatus.Step = 1;
            _pbStatus.TabIndex = 10;
            //
            // lblProgress
            //
            _lblProgress.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _lblProgress.Location = new Point(800, 627);
            _lblProgress.Name = "lblProgress";
            _lblProgress.Size = new Size(40, 16);
            _lblProgress.TabIndex = 11;
            _lblProgress.Text = "0%";
            _lblProgress.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblMessages
            //
            _lblMessages.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _lblMessages.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblMessages.ForeColor = Color.Red;
            _lblMessages.Location = new Point(5, 595);
            _lblMessages.Name = "lblMessages";
            _lblMessages.Size = new Size(787, 19);
            _lblMessages.TabIndex = 12;
            _lblMessages.TextAlign = ContentAlignment.MiddleLeft;
            _lblMessages.Visible = false;
            //
            // grpFailedImports
            //
            _grpFailedImports.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpFailedImports.Controls.Add(_dgFailedImports);
            _grpFailedImports.FlatStyle = FlatStyle.System;
            _grpFailedImports.Location = new Point(8, 180);
            _grpFailedImports.Name = "grpFailedImports";
            _grpFailedImports.Size = new Size(896, 402);
            _grpFailedImports.TabIndex = 15;
            _grpFailedImports.TabStop = false;
            _grpFailedImports.Text = "Failed Imports";
            //
            // dgFailedImports
            //
            _dgFailedImports.DataMember = "";
            _dgFailedImports.Dock = DockStyle.Fill;
            _dgFailedImports.HeaderForeColor = SystemColors.ControlText;
            _dgFailedImports.Location = new Point(3, 17);
            _dgFailedImports.Name = "dgFailedImports";
            _dgFailedImports.Size = new Size(890, 382);
            _dgFailedImports.TabIndex = 45;
            //
            // btnExportFailed
            //
            _btnExportFailed.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnExportFailed.FlatStyle = FlatStyle.System;
            _btnExportFailed.Location = new Point(800, 593);
            _btnExportFailed.Name = "btnExportFailed";
            _btnExportFailed.Size = new Size(104, 23);
            _btnExportFailed.TabIndex = 16;
            _btnExportFailed.Text = "Export Failures";
            _btnExportFailed.Visible = false;
            //
            // txtEngineer
            //
            _txtEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtEngineer.Location = new Point(616, 93);
            _txtEngineer.Name = "txtEngineer";
            _txtEngineer.ReadOnly = true;
            _txtEngineer.Size = new Size(236, 21);
            _txtEngineer.TabIndex = 43;
            //
            // btnFindEngineer
            //
            _btnFindEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindEngineer.Enabled = false;
            _btnFindEngineer.Location = new Point(858, 91);
            _btnFindEngineer.Name = "btnFindEngineer";
            _btnFindEngineer.Size = new Size(32, 23);
            _btnFindEngineer.TabIndex = 42;
            _btnFindEngineer.Text = "...";
            _btnFindEngineer.UseVisualStyleBackColor = true;
            //
            // lblEngineer
            //
            _lblEngineer.AutoSize = true;
            _lblEngineer.Location = new Point(548, 96);
            _lblEngineer.Name = "lblEngineer";
            _lblEngineer.Size = new Size(62, 13);
            _lblEngineer.TabIndex = 41;
            _lblEngineer.Text = "Engineer:";
            //
            // dtpVisitDate
            //
            _dtpVisitDate.Enabled = false;
            _dtpVisitDate.Location = new Point(370, 93);
            _dtpVisitDate.Name = "dtpVisitDate";
            _dtpVisitDate.Size = new Size(151, 21);
            _dtpVisitDate.TabIndex = 44;
            //
            // lblVisitDate
            //
            _lblVisitDate.AutoSize = true;
            _lblVisitDate.Location = new Point(290, 96);
            _lblVisitDate.Name = "lblVisitDate";
            _lblVisitDate.Size = new Size(67, 13);
            _lblVisitDate.TabIndex = 45;
            _lblVisitDate.Text = "Visit Date:";
            //
            // chkCreateJob
            //
            _chkCreateJob.AutoCheck = false;
            _chkCreateJob.AutoSize = true;
            _chkCreateJob.Location = new Point(9, 95);
            _chkCreateJob.Name = "chkCreateJob";
            _chkCreateJob.Size = new Size(94, 17);
            _chkCreateJob.TabIndex = 46;
            _chkCreateJob.Text = "Create Jobs";
            _chkCreateJob.UseVisualStyleBackColor = true;
            //
            // FRMJobImport
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(912, 654);
            Controls.Add(_btnExportFailed);
            Controls.Add(_grpFailedImports);
            Controls.Add(_lblMessages);
            Controls.Add(_lblProgress);
            Controls.Add(_pbStatus);
            Controls.Add(_btnClose);
            Controls.Add(_grpExcelFile);
            MinimumSize = new Size(920, 688);
            Name = "FRMJobImport";
            Text = "Job Importer";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpExcelFile, 0);
            Controls.SetChildIndex(_btnClose, 0);
            Controls.SetChildIndex(_pbStatus, 0);
            Controls.SetChildIndex(_lblProgress, 0);
            Controls.SetChildIndex(_lblMessages, 0);
            Controls.SetChildIndex(_grpFailedImports, 0);
            Controls.SetChildIndex(_btnExportFailed, 0);
            _grpExcelFile.ResumeLayout(false);
            _grpExcelFile.PerformLayout();
            _grpFailedImports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgFailedImports).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private FileInfo _file;

        public FileInfo File
        {
            get
            {
                return _file;
            }

            set
            {
                _file = value;
            }
        }

        private DataTable _failedImports = new DataTable();

        private DataTable FailedImports
        {
            get
            {
                return _failedImports;
            }

            set
            {
                _failedImports = value;
            }
        }

        private List<Customer> _customers = new List<Customer>();

        public List<Customer> Customers
        {
            get
            {
                return _customers;
            }

            set
            {
                _customers = value;
                if (_customers.Count > 0)
                {
                    string custText = string.Empty;
                    bool addComma = false;
                    foreach (Customer cust in _customers)
                    {
                        if (addComma)
                            custText += ", ";
                        custText += cust.Name;
                        addComma = true;
                    }

                    txtCustomer.Text = custText;
                }
                else
                {
                    txtCustomer.Text = "";
                }
            }
        }

        private Engineer _engineer;

        public Engineer Engineer
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

        private void FRMJobImport_Load(object sender, EventArgs e)
        {
            radBtnJob.Visible = App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Compliance);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void btnFindExcelFile_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Import();
        }

        private void btnExportFailed_Click(object sender, EventArgs e)
        {
            Export();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void LoadData()
        {
            var dlg = default(OpenFileDialog);
            Microsoft.Office.Interop.Excel.Application oExcel;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btnFindExcelFile.Enabled = false;
                txtExcelFile.Text = "";
                btnImport.Enabled = false;
                dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var tempfile = new FileInfo(dlg.FileName);

                    // Is it an excel file?
                    if ((tempfile.Extension ?? "") == ".xls" | (tempfile.Extension ?? "") == ".xlsx")
                    {
                        File = tempfile;
                        // Is an Excel file
                        txtExcelFile.Text = File.FullName;
                        btnImport.Enabled = true;
                    }
                    else
                    {
                        App.ShowMessage("File must be .xls, or .xlsx.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                txtExcelFile.Text = "";
                btnImport.Enabled = false;
                App.ShowMessage("File data could not be loaded : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dlg.Dispose();
                btnFindExcelFile.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void Import()
        {
            int jobImportTypeID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboJobType));
            if (radBtnJob.Checked)
            {
                if (jobImportTypeID == 0)
                {
                    App.ShowMessage("Please select a job type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Customers.Count == 0)
                {
                    App.ShowMessage("Please select a customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            var oExcel = default(Microsoft.Office.Interop.Excel.Application);
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btnClose.Enabled = false;
                btnFindExcelFile.Enabled = false;
                btnImport.Enabled = false;
                pbStatus.Value = 0;
                cboJobType.Enabled = false;
                oExcel = new Microsoft.Office.Interop.Excel.Application();
                oExcel.DisplayAlerts = false;
                Microsoft.Office.Interop.Excel.Worksheet oWorksheet;
                oExcel.Workbooks.Add(File.FullName);
                oWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)oExcel.Worksheets[1];
                string strCom = " SELECT * FROM [" + oWorksheet.Name + "$]";
                string strCon = "";
                if ((File.Extension.Trim().ToLower() ?? "") == (".xls".ToLower() ?? ""))
                {
                    strCon = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + File.FullName + " ; Extended Properties=Excel 8.0; ";
                }
                else if ((File.Extension.Trim().ToLower() ?? "") == (".xlsx".ToLower() ?? ""))
                {
                    strCon = " Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source = " + File.FullName + " ; Extended Properties=Excel 12.0; ";
                }

                var conn = new System.Data.OleDb.OleDbConnection(strCon);
                var adapter = new System.Data.OleDb.OleDbDataAdapter();
                var data = new DataSet();
                adapter.SelectCommand = new System.Data.OleDb.OleDbCommand(strCom, conn);
                data.Clear();
                adapter.Fill(data);
                if (radBtnJob.Checked)
                    ImportJobs(data, jobImportTypeID);
                else
                    ImportJobsStatus(data);
            }
            catch (Exception ex)
            {
                App.ShowMessage("File data could not be imported : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                KillInstances(oExcel);
                string filePath = App.TheSystem.Configuration.DocumentsLocation;
                filePath += Interaction.IIf(radBtnJob.Checked, @"JobImports\", @"JobImports\JobStatusImports\");
                Directory.CreateDirectory(filePath);
                string fileType = Path.GetExtension(File.Name);
                System.IO.File.Move(File.FullName, filePath + File.Name.Replace(fileType, "_" + DateAndTime.Now.ToString("dd_MMM_yyyy_HH_mm_ss") + fileType));
                File = null;
                txtExcelFile.Text = "";
                if (FailedImports.Rows.Count > 0)
                {
                    btnExportFailed.Visible = true;
                }

                pbStatus.Value = pbStatus.Maximum;
                btnClose.Enabled = true;
                btnFindExcelFile.Enabled = true;
                cboJobType.Enabled = true;
                btnImport.Enabled = true;
                pbStatus.Value = 0;
                Cursor.Current = Cursors.Default;
            }
        }

        private void ImportJobsStatus(DataSet data)
        {
            data.Tables[0].Columns.Add("Failure Reason");
            FailedImports = data.Tables[0].Clone();
            pbStatus.Maximum = data.Tables[0].Rows.Count;
            for (int i = 0, loopTo = data.Tables[0].Rows.Count - 1; i <= loopTo; i++)
            {
                var row = data.Tables[0].Rows[i];
                string jobNumber = string.Empty;
                string status = string.Empty;
                string startDate = string.Empty;
                Entity.EngineerVisits.EngineerVisit visit = null;
                if (data.Tables[0].Columns.Contains("EngineerVisitID"))
                {
                    if (row["EngineerVisitID"] != DBNull.Value)
                    {
                        try
                        {
                            visit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(row["EngineerVisitID"]));
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }

                if (visit is null)
                {
                    if (row["JobNumber"] == DBNull.Value)
                    {
                        row["Failure Reason"] = "No job number";
                        FailedImports.ImportRow(row);
                        goto nextrow;
                    }
                    else
                    {
                        jobNumber = Conversions.ToString(row["JobNumber"]);
                    }

                    if (row["StartDateTime"] == DBNull.Value)
                    {
                        row["Failure Reason"] = "No visit start date";
                        FailedImports.ImportRow(row);
                        goto nextrow;
                    }
                    else
                    {
                        startDate = Conversions.ToString(row["StartDateTime"]);
                    }

                    var dvEngineerVisits = App.DB.EngineerVisits.EngineerVisits_Get_All_JobNumber_Light(jobNumber);
                    if (!(dvEngineerVisits.Count > 0))
                    {
                        row["Failure Reason"] = "Cannot find any visits associated to job number";
                        FailedImports.ImportRow(row);
                        goto nextrow;
                    }

                    foreach (DataRow visitRow in dvEngineerVisits.Table.Rows)
                    {
                        if (Conversions.ToDate(visitRow["StartDateTime"]).Date == Conversions.ToDate(startDate).Date)
                        {
                            visit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(visitRow["EngineerVisitID"]));
                        }
                    }
                }

                if (row["Status"] == DBNull.Value)
                {
                    row["Failure Reason"] = "No status found";
                    FailedImports.ImportRow(row);
                    goto nextrow;
                }
                else
                {
                    status = Conversions.ToString(row["Status"]);
                }

                if (visit is object)
                {
                    // check if visitdate matches orginal date
                    if (row["StartDateTime"] == DBNull.Value)
                    {
                        row["Failure Reason"] = "No visit start date";
                        FailedImports.ImportRow(row);
                        goto nextrow;
                    }
                    else
                    {
                        startDate = Conversions.ToString(row["StartDateTime"]);
                    }

                    if (Conversions.ToDate(startDate).Date != visit.StartDateTime.Date)
                    {
                        row["Failure Reason"] = "Start date does not match";
                        FailedImports.ImportRow(row);
                        goto nextrow;
                    }

                    if (visit.StatusEnumID != (int)Enums.VisitStatus.Scheduled)
                    {
                        row["Failure Reason"] = "Visit Status has already been updated";
                        FailedImports.ImportRow(row);
                        goto nextrow;
                    }

                    int outcomeID;
                    var switchExpr = Helper.MakeIntegerValid(status);
                    switch (switchExpr)
                    {
                        case (int)Enums.JobImportStatus.DidNotAttend: // engineer hasn't attended
                            {
                                outcomeID = Conversions.ToInteger(Enums.EngineerVisitOutcomes.Could_Not_Start);
                                row["Failure Reason"] = "Please manually rescheduled";
                                FailedImports.ImportRow(row);
                                goto nextrow;
                                break;
                            }

                        case (int)Enums.JobImportStatus.Carded: // carded
                            {
                                outcomeID = Conversions.ToInteger(Enums.EngineerVisitOutcomes.Carded);
                                break;
                            }

                        case (int)Enums.JobImportStatus.Complete: // complete
                            {
                                outcomeID = Conversions.ToInteger(Enums.EngineerVisitOutcomes.Complete);
                                break;
                            }

                        default:
                            {
                                row["Failure Reason"] = "Invalid status";
                                FailedImports.ImportRow(row);
                                goto nextrow;
                                break;
                            }
                    }

                    if (!App.DB.EngineerVisits.EngineerVisits_UpdateStatus(visit.EngineerVisitID, Conversions.ToInteger(Enums.VisitStatus.Uploaded), outcomeID))
                    {
                        row["Failure Reason"] = "Failed to update status";
                        FailedImports.ImportRow(row);
                        goto nextrow;
                    }
                }
                else
                {
                    row["Failure Reason"] = "Cannot find any visits";
                    FailedImports.ImportRow(row);
                }

            nextrow:
                ;
                MoveProgressOn();
            }

            MoveProgressOn(true);
            App.ShowMessage("Data has been imported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblMessages.Visible = false;
            if (FailedImports.Rows.Count > 0)
            {
                dgFailedImports.DataSource = FailedImports;
            }
        }

        private void ImportJobs(DataSet data, int jobImportTypeID)
        {
            data.Tables[0].Columns.Add("Failure Reason");
            FailedImports = data.Tables[0].Clone();
            pbStatus.Maximum = data.Tables[0].Rows.Count;
            for (int i = 0, loopTo = data.Tables[0].Rows.Count - 1; i <= loopTo; i++)
            {
                var row = data.Tables[0].Rows[i];
                string uprn = string.Empty;
                if (row["UPRN"] == DBNull.Value)
                {
                    row["Failure Reason"] = "No uprn";
                    FailedImports.ImportRow(row);
                    goto nextrow;
                }
                else
                {
                    uprn = Conversions.ToString(row["UPRN"]);
                }

                Site site = null;
                foreach (Customer customer in Customers)
                {
                    if (site is null)
                    {
                        site = App.DB.Sites.Get(uprn, SiteSQL.GetBy.Uprn, customer.CustomerID);
                    }
                }

                if (site is null)
                {
                    row["Failure Reason"] = "Cannot find site";
                    FailedImports.ImportRow(row);
                    MoveProgressOn();
                }
                else
                {
                    if (App.DB.JobImports.JobImport_Exist(site.SiteID, jobImportTypeID))
                    {
                        row["Failure Reason"] = "Site and job exists in system";
                        FailedImports.ImportRow(row);
                        MoveProgressOn();
                    }

                    var jobImport = new Entity.JobImport.JobImport();
                    {
                        var withBlock = jobImport;
                        withBlock.SetSiteID = site.SiteID;
                        withBlock.SetUPRN = site.PolicyNumber;
                        withBlock.SetJobImportTypeID = jobImportTypeID;
                        withBlock.DateAdded = DateAndTime.Now;
                    }

                    jobImport = App.DB.JobImports.JobImport_Insert(jobImport);
                    if (!jobImport.Exists)
                    {
                        row["Failure Reason"] = "Database failure";
                        FailedImports.ImportRow(row);
                    }

                    if (chkCreateJob.Checked && Helper.MakeIntegerValid(Engineer?.EngineerID) > 0)
                    {
                        var job = CreateJob(site, jobImportTypeID);
                        if (Helper.MakeIntegerValid(job?.JobID) > 0)
                        {
                            App.DB.ExecuteWithOutReturn("UPDATE tblJobImport SET JobID = " + job.JobID + ", JobNumber = '" + job.JobNumber + "', Status = " + 0 + ", BookedVisit = '" + Strings.Format(dtpVisitDate.Value, "yyyy-MM-dd") + "', Letter1 = '" + Strings.Format(DateAndTime.Now, "yyyy-MM-dd") + "' WHERE JobImportID = " + jobImport.JobImportID + "");
                        }
                    }
                }

            nextrow:
                ;
                MoveProgressOn();
            }

            MoveProgressOn(true);
            App.ShowMessage("Data has been imported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblMessages.Visible = false;
            if (FailedImports.Rows.Count > 0)
            {
                dgFailedImports.DataSource = FailedImports;
                btnExportFailed.Visible = true;
            }
        }

        public Entity.Jobs.Job CreateJob(Site oSite, int jobImportTypeId)
        {
            var theVisitDate = default(DateTime);
            var jobImportType = App.DB.JobImports.JobImportType_Get(jobImportTypeId);
            if (jobImportType is null)
                return null;
            var SORdt = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_Get_ByEngineerQual(jobImportType.EngineerQualID).Table;
            int visittime = 0;
            var JobNumber = new JobNumber();
            JobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Callout);
            var job = new Entity.Jobs.Job()
            {
                SetPropertyID = oSite.SiteID,
                SetJobDefinitionEnumID = Conversions.ToInteger(Enums.JobDefinition.Callout),
                SetJobTypeID = jobImportType.JobTypeID,
                SetStatusEnumID = Conversions.ToInteger(Enums.JobStatus.Open),
                SetCreatedByUserID = App.loggedInUser.UserID,
                SetFOC = true,
                SetJobCreationType = Conversions.ToInteger(Enums.JobCreationType.JobManager),
                SetJobNumber = JobNumber.Prefix + JobNumber.JobNumber,
                SetPONumber = "",
                SetQuoteID = 0,
                SetContractID = 0
            };
            var jobOfWork = new Entity.JobOfWorks.JobOfWork();

            // Get service priority
            int servicePriority = 0;
            DataRow[] rows = App.DB.Picklists.GetAll(Enums.PickListTypes.JOWPriority).Table.Select("Name = 'Dayworks'");
            if (rows.Length == 0)
            {
                var oPickList = new Entity.PickLists.PickList();
                oPickList.SetName = "Dayworks";
                oPickList.SetEnumTypeID = Conversions.ToInteger(Enums.PickListTypes.JOWPriority);
                servicePriority = App.DB.Picklists.Insert(oPickList);
            }
            else
            {
                servicePriority = Conversions.ToInteger(rows[0]["ManagerID"]);
            }

            // INSERT JOB ITEM
            jobOfWork.SetPONumber = "";
            jobOfWork.SetPriority = servicePriority;
            if (!(jobOfWork.Priority == 0))
            {
                jobOfWork.PriorityDateSet = DateAndTime.Now;
            }

            jobOfWork.IgnoreExceptionsOnSetMethods = true;
            foreach (DataRow sorRow in SORdt.Rows)
            {
                var customerSors = App.DB.CustomerScheduleOfRate.Exists(Conversions.ToInteger(sorRow["ScheduleOfRatesCategoryID"]), Conversions.ToString(sorRow["Description"]), Conversions.ToString(sorRow["Code"]), oSite.CustomerID);
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
                        SetCustomerID = oSite.CustomerID
                    };
                    customerSorId = App.DB.CustomerScheduleOfRate.Insert(customerSor).CustomerScheduleOfRateID;
                    App.DB.CustomerScheduleOfRate.Delete(customerSorId);
                }

                visittime = Conversions.ToInteger(sorRow["TimeInMins"]);
                var jobItem = new Entity.JobItems.JobItem();
                jobItem.IgnoreExceptionsOnSetMethods = true;
                jobItem.SetSummary = sorRow["Description"];
                jobItem.SetQty = 1;
                jobItem.SetRateID = customerSorId;
                jobItem.SetSystemLinkID = Conversions.ToInteger(Enums.TableNames.tblCustomerScheduleOfRate);
                jobOfWork.JobItems.Add(jobItem);
            }

            var engineerVisit = new Entity.EngineerVisits.EngineerVisit();
            engineerVisit.IgnoreExceptionsOnSetMethods = true;
            engineerVisit.SetEngineerID = 0;
            engineerVisit.SetEngineerID = Engineer.EngineerID;
            engineerVisit.SetNotesToEngineer = jobImportType.Name;
            engineerVisit.StartDateTime = dtpVisitDate.Value;
            engineerVisit.EndDateTime = dtpVisitDate.Value.AddHours(1);
            engineerVisit.SetStatusEnumID = Conversions.ToInteger(Enums.VisitStatus.Scheduled);
            engineerVisit.DueDate = theVisitDate;
            engineerVisit.SetAMPM = "AM";
            engineerVisit.SetVisitNumber = 1;
            jobOfWork.EngineerVisits.Add(engineerVisit);
            job.JobOfWorks.Add(jobOfWork);
            job = App.DB.Job.Insert(job);
            return job;
        }

        private void Export()
        {
            ExportHelper.Export(FailedImports, "Job Imports", Enums.ExportType.XLS);
            FailedImports.Clear();
            btnExportFailed.Visible = false;
        }

        public void MoveProgressOn(bool toMaximum = false)
        {
            try
            {
                if (toMaximum)
                {
                    pbStatus.Value = pbStatus.Maximum;
                    lblProgress.Text = "100%";
                }
                else
                {
                    pbStatus.Value += 1;
                    lblProgress.Text = Math.Floor(pbStatus.Value / (double)pbStatus.Maximum * 100) + "%";
                }

                Application.DoEvents();
            }
            catch (Exception ex)
            {
            }
        }

        private void KillInstances(Microsoft.Office.Interop.Excel.Application app)
        {
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            app = null;
            GC.Collect();
            var mp = Process.GetProcessesByName("EXCEL");
            foreach (var p in mp)
            {
                try
                {
                    if (p.Responding)
                    {
                        if (string.IsNullOrEmpty(p.MainWindowTitle))
                        {
                            p.Kill();
                        }
                    }
                    else
                    {
                        p.Kill();
                    }
                }
                catch
                {
                }
            };
        }

        private void radBtnJob_CheckedChanged(object sender, EventArgs e)
        {
            lblJobType.Visible = radBtnJob.Checked;
            cboJobType.Visible = radBtnJob.Checked;
            txtCustomer.Visible = radBtnJob.Checked;
            btnFindCustomer.Visible = radBtnJob.Checked;
            lblCustomer.Visible = radBtnJob.Checked;
            lblEngineer.Visible = radBtnJob.Checked;
            lblVisitDate.Visible = radBtnJob.Checked;
            dtpVisitDate.Visible = radBtnJob.Checked;
            txtEngineer.Visible = radBtnJob.Checked;
            btnFindEngineer.Visible = radBtnJob.Checked;
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            var frmFindCust = new FRMFindCustomers();
            frmFindCust.ShowDialog();
            Customers = new List<Customer>();
            var dvCustomers = frmFindCust.CustomerDataView;
            var drCustomers = (from row in dvCustomers.Table.AsEnumerable()
                               where row.Field<bool>("Include") == true
                               select row).ToArray();
            var cIds = (from dr in drCustomers
                        select (Helper.MakeIntegerValid(dr["CustomerID"]))).ToList();
            foreach (int cId in cIds)
                Customers.Add(App.DB.Customer.Customer_Get(cId));
            Customers = Customers;
        }

        private void chkCreateJob_Click(object sender, EventArgs e)
        {
            chkCreateJob.Checked = !chkCreateJob.Checked;
            dtpVisitDate.Enabled = chkCreateJob.Checked;
            btnFindEngineer.Enabled = chkCreateJob.Checked;
        }

        private void btnFindEngineer_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblEngineer));
            if (!(ID == 0))
            {
                Engineer = App.DB.Engineer.Engineer_Get(ID);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}