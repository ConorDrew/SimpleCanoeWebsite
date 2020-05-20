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
        public FRMJobImport() : base()
        {
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
            this._grpExcelFile = new System.Windows.Forms.GroupBox();
            this._chkCreateJob = new System.Windows.Forms.CheckBox();
            this._lblVisitDate = new System.Windows.Forms.Label();
            this._dtpVisitDate = new System.Windows.Forms.DateTimePicker();
            this._txtEngineer = new System.Windows.Forms.TextBox();
            this._btnFindEngineer = new System.Windows.Forms.Button();
            this._lblEngineer = new System.Windows.Forms.Label();
            this._txtCustomer = new System.Windows.Forms.TextBox();
            this._btnFindCustomer = new System.Windows.Forms.Button();
            this._lblCustomer = new System.Windows.Forms.Label();
            this._radBtnJobStatus = new System.Windows.Forms.RadioButton();
            this._radBtnJob = new System.Windows.Forms.RadioButton();
            this._cboJobType = new System.Windows.Forms.ComboBox();
            this._lblJobType = new System.Windows.Forms.Label();
            this._lblFile = new System.Windows.Forms.Label();
            this._btnImport = new System.Windows.Forms.Button();
            this._btnFindExcelFile = new System.Windows.Forms.Button();
            this._txtExcelFile = new System.Windows.Forms.TextBox();
            this._btnClose = new System.Windows.Forms.Button();
            this._pbStatus = new System.Windows.Forms.ProgressBar();
            this._lblProgress = new System.Windows.Forms.Label();
            this._lblMessages = new System.Windows.Forms.Label();
            this._grpFailedImports = new System.Windows.Forms.GroupBox();
            this._dgFailedImports = new System.Windows.Forms.DataGrid();
            this._btnExportFailed = new System.Windows.Forms.Button();
            this._grpExcelFile.SuspendLayout();
            this._grpFailedImports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgFailedImports)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpExcelFile
            // 
            this._grpExcelFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpExcelFile.Controls.Add(this._chkCreateJob);
            this._grpExcelFile.Controls.Add(this._lblVisitDate);
            this._grpExcelFile.Controls.Add(this._dtpVisitDate);
            this._grpExcelFile.Controls.Add(this._txtEngineer);
            this._grpExcelFile.Controls.Add(this._btnFindEngineer);
            this._grpExcelFile.Controls.Add(this._lblEngineer);
            this._grpExcelFile.Controls.Add(this._txtCustomer);
            this._grpExcelFile.Controls.Add(this._btnFindCustomer);
            this._grpExcelFile.Controls.Add(this._lblCustomer);
            this._grpExcelFile.Controls.Add(this._radBtnJobStatus);
            this._grpExcelFile.Controls.Add(this._radBtnJob);
            this._grpExcelFile.Controls.Add(this._cboJobType);
            this._grpExcelFile.Controls.Add(this._lblJobType);
            this._grpExcelFile.Controls.Add(this._lblFile);
            this._grpExcelFile.Controls.Add(this._btnImport);
            this._grpExcelFile.Controls.Add(this._btnFindExcelFile);
            this._grpExcelFile.Controls.Add(this._txtExcelFile);
            this._grpExcelFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._grpExcelFile.Location = new System.Drawing.Point(8, 12);
            this._grpExcelFile.Name = "_grpExcelFile";
            this._grpExcelFile.Size = new System.Drawing.Size(896, 162);
            this._grpExcelFile.TabIndex = 3;
            this._grpExcelFile.TabStop = false;
            this._grpExcelFile.Text = "Select data file to import";
            // 
            // _chkCreateJob
            // 
            this._chkCreateJob.AutoCheck = false;
            this._chkCreateJob.AutoSize = true;
            this._chkCreateJob.Location = new System.Drawing.Point(9, 95);
            this._chkCreateJob.Name = "_chkCreateJob";
            this._chkCreateJob.Size = new System.Drawing.Size(94, 17);
            this._chkCreateJob.TabIndex = 46;
            this._chkCreateJob.Text = "Create Jobs";
            this._chkCreateJob.UseVisualStyleBackColor = true;
            this._chkCreateJob.Click += new System.EventHandler(this.chkCreateJob_Click);
            // 
            // _lblVisitDate
            // 
            this._lblVisitDate.AutoSize = true;
            this._lblVisitDate.Location = new System.Drawing.Point(290, 96);
            this._lblVisitDate.Name = "_lblVisitDate";
            this._lblVisitDate.Size = new System.Drawing.Size(67, 13);
            this._lblVisitDate.TabIndex = 45;
            this._lblVisitDate.Text = "Visit Date:";
            // 
            // _dtpVisitDate
            // 
            this._dtpVisitDate.Enabled = false;
            this._dtpVisitDate.Location = new System.Drawing.Point(370, 93);
            this._dtpVisitDate.Name = "_dtpVisitDate";
            this._dtpVisitDate.Size = new System.Drawing.Size(151, 21);
            this._dtpVisitDate.TabIndex = 44;
            // 
            // _txtEngineer
            // 
            this._txtEngineer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtEngineer.Location = new System.Drawing.Point(616, 93);
            this._txtEngineer.Name = "_txtEngineer";
            this._txtEngineer.ReadOnly = true;
            this._txtEngineer.Size = new System.Drawing.Size(236, 21);
            this._txtEngineer.TabIndex = 43;
            // 
            // _btnFindEngineer
            // 
            this._btnFindEngineer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindEngineer.Enabled = false;
            this._btnFindEngineer.Location = new System.Drawing.Point(858, 91);
            this._btnFindEngineer.Name = "_btnFindEngineer";
            this._btnFindEngineer.Size = new System.Drawing.Size(32, 23);
            this._btnFindEngineer.TabIndex = 42;
            this._btnFindEngineer.Text = "...";
            this._btnFindEngineer.UseVisualStyleBackColor = true;
            this._btnFindEngineer.Click += new System.EventHandler(this.btnFindEngineer_Click);
            // 
            // _lblEngineer
            // 
            this._lblEngineer.AutoSize = true;
            this._lblEngineer.Location = new System.Drawing.Point(548, 96);
            this._lblEngineer.Name = "_lblEngineer";
            this._lblEngineer.Size = new System.Drawing.Size(62, 13);
            this._lblEngineer.TabIndex = 41;
            this._lblEngineer.Text = "Engineer:";
            // 
            // _txtCustomer
            // 
            this._txtCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtCustomer.Location = new System.Drawing.Point(429, 56);
            this._txtCustomer.Name = "_txtCustomer";
            this._txtCustomer.ReadOnly = true;
            this._txtCustomer.Size = new System.Drawing.Size(423, 21);
            this._txtCustomer.TabIndex = 40;
            // 
            // _btnFindCustomer
            // 
            this._btnFindCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindCustomer.Location = new System.Drawing.Point(858, 54);
            this._btnFindCustomer.Name = "_btnFindCustomer";
            this._btnFindCustomer.Size = new System.Drawing.Size(32, 23);
            this._btnFindCustomer.TabIndex = 39;
            this._btnFindCustomer.Text = "...";
            this._btnFindCustomer.UseVisualStyleBackColor = true;
            this._btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
            // 
            // _lblCustomer
            // 
            this._lblCustomer.AutoSize = true;
            this._lblCustomer.Location = new System.Drawing.Point(349, 59);
            this._lblCustomer.Name = "_lblCustomer";
            this._lblCustomer.Size = new System.Drawing.Size(74, 13);
            this._lblCustomer.TabIndex = 38;
            this._lblCustomer.Text = "Customers:";
            // 
            // _radBtnJobStatus
            // 
            this._radBtnJobStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._radBtnJobStatus.AutoSize = true;
            this._radBtnJobStatus.Checked = true;
            this._radBtnJobStatus.Location = new System.Drawing.Point(670, 24);
            this._radBtnJobStatus.Name = "_radBtnJobStatus";
            this._radBtnJobStatus.Size = new System.Drawing.Size(84, 17);
            this._radBtnJobStatus.TabIndex = 37;
            this._radBtnJobStatus.TabStop = true;
            this._radBtnJobStatus.Text = "Job Status";
            this._radBtnJobStatus.UseVisualStyleBackColor = true;
            this._radBtnJobStatus.CheckedChanged += new System.EventHandler(this.radBtnJob_CheckedChanged);
            // 
            // _radBtnJob
            // 
            this._radBtnJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._radBtnJob.AutoSize = true;
            this._radBtnJob.Location = new System.Drawing.Point(760, 24);
            this._radBtnJob.Name = "_radBtnJob";
            this._radBtnJob.Size = new System.Drawing.Size(44, 17);
            this._radBtnJob.TabIndex = 36;
            this._radBtnJob.Text = "Job";
            this._radBtnJob.UseVisualStyleBackColor = true;
            this._radBtnJob.CheckedChanged += new System.EventHandler(this.radBtnJob_CheckedChanged);
            // 
            // _cboJobType
            // 
            this._cboJobType.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cboJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboJobType.Location = new System.Drawing.Point(86, 56);
            this._cboJobType.Name = "_cboJobType";
            this._cboJobType.Size = new System.Drawing.Size(242, 21);
            this._cboJobType.TabIndex = 35;
            this._cboJobType.Tag = "Site.RegionID";
            // 
            // _lblJobType
            // 
            this._lblJobType.AutoSize = true;
            this._lblJobType.Location = new System.Drawing.Point(6, 59);
            this._lblJobType.Name = "_lblJobType";
            this._lblJobType.Size = new System.Drawing.Size(62, 13);
            this._lblJobType.TabIndex = 19;
            this._lblJobType.Text = "Job Type:";
            // 
            // _lblFile
            // 
            this._lblFile.AutoSize = true;
            this._lblFile.Location = new System.Drawing.Point(6, 23);
            this._lblFile.Name = "_lblFile";
            this._lblFile.Size = new System.Drawing.Size(31, 13);
            this._lblFile.TabIndex = 13;
            this._lblFile.Text = "File:";
            // 
            // _btnImport
            // 
            this._btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnImport.Enabled = false;
            this._btnImport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnImport.Location = new System.Drawing.Point(826, 18);
            this._btnImport.Name = "_btnImport";
            this._btnImport.Size = new System.Drawing.Size(64, 23);
            this._btnImport.TabIndex = 7;
            this._btnImport.Text = "Import";
            this._btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // _btnFindExcelFile
            // 
            this._btnFindExcelFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindExcelFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnFindExcelFile.Location = new System.Drawing.Point(616, 20);
            this._btnFindExcelFile.Name = "_btnFindExcelFile";
            this._btnFindExcelFile.Size = new System.Drawing.Size(32, 23);
            this._btnFindExcelFile.TabIndex = 5;
            this._btnFindExcelFile.Text = "...";
            this._btnFindExcelFile.Click += new System.EventHandler(this.btnFindExcelFile_Click);
            // 
            // _txtExcelFile
            // 
            this._txtExcelFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtExcelFile.Location = new System.Drawing.Point(43, 20);
            this._txtExcelFile.Name = "_txtExcelFile";
            this._txtExcelFile.ReadOnly = true;
            this._txtExcelFile.Size = new System.Drawing.Size(567, 21);
            this._txtExcelFile.TabIndex = 4;
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnClose.Location = new System.Drawing.Point(848, 624);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(56, 23);
            this._btnClose.TabIndex = 9;
            this._btnClose.Text = "Close";
            this._btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // _pbStatus
            // 
            this._pbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pbStatus.Location = new System.Drawing.Point(8, 624);
            this._pbStatus.Name = "_pbStatus";
            this._pbStatus.Size = new System.Drawing.Size(784, 23);
            this._pbStatus.Step = 1;
            this._pbStatus.TabIndex = 10;
            // 
            // _lblProgress
            // 
            this._lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._lblProgress.Location = new System.Drawing.Point(800, 627);
            this._lblProgress.Name = "_lblProgress";
            this._lblProgress.Size = new System.Drawing.Size(40, 16);
            this._lblProgress.TabIndex = 11;
            this._lblProgress.Text = "0%";
            this._lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _lblMessages
            // 
            this._lblMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lblMessages.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblMessages.ForeColor = System.Drawing.Color.Red;
            this._lblMessages.Location = new System.Drawing.Point(5, 595);
            this._lblMessages.Name = "_lblMessages";
            this._lblMessages.Size = new System.Drawing.Size(787, 19);
            this._lblMessages.TabIndex = 12;
            this._lblMessages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblMessages.Visible = false;
            // 
            // _grpFailedImports
            // 
            this._grpFailedImports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpFailedImports.Controls.Add(this._dgFailedImports);
            this._grpFailedImports.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._grpFailedImports.Location = new System.Drawing.Point(8, 180);
            this._grpFailedImports.Name = "_grpFailedImports";
            this._grpFailedImports.Size = new System.Drawing.Size(896, 402);
            this._grpFailedImports.TabIndex = 15;
            this._grpFailedImports.TabStop = false;
            this._grpFailedImports.Text = "Failed Imports";
            // 
            // _dgFailedImports
            // 
            this._dgFailedImports.DataMember = "";
            this._dgFailedImports.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgFailedImports.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgFailedImports.Location = new System.Drawing.Point(3, 17);
            this._dgFailedImports.Name = "_dgFailedImports";
            this._dgFailedImports.Size = new System.Drawing.Size(890, 382);
            this._dgFailedImports.TabIndex = 45;
            // 
            // _btnExportFailed
            // 
            this._btnExportFailed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnExportFailed.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnExportFailed.Location = new System.Drawing.Point(800, 593);
            this._btnExportFailed.Name = "_btnExportFailed";
            this._btnExportFailed.Size = new System.Drawing.Size(104, 23);
            this._btnExportFailed.TabIndex = 16;
            this._btnExportFailed.Text = "Export Failures";
            this._btnExportFailed.Visible = false;
            this._btnExportFailed.Click += new System.EventHandler(this.btnExportFailed_Click);
            // 
            // FRMJobImport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(912, 654);
            this.Controls.Add(this._btnExportFailed);
            this.Controls.Add(this._grpFailedImports);
            this.Controls.Add(this._lblMessages);
            this.Controls.Add(this._lblProgress);
            this.Controls.Add(this._pbStatus);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._grpExcelFile);
            this.MinimumSize = new System.Drawing.Size(920, 688);
            this.Name = "FRMJobImport";
            this.Text = "Job Importer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpExcelFile.ResumeLayout(false);
            this._grpExcelFile.PerformLayout();
            this._grpFailedImports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgFailedImports)).EndInit();
            this.ResumeLayout(false);

        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

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
                SetJobNumber = JobNumber.Prefix + JobNumber.Number,
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
    }
}