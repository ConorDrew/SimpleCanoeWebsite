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
    public class FRMBulkJobCreation : FRMBaseForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMBulkJobCreation() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            this.Load += FRMBulkJobCreation_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            var argc = cboJobType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
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

        private RichTextBox _txtNotes;

        internal RichTextBox txtNotes
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

        private Label _lblVisitNotes;

        internal Label lblVisitNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblVisitNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblVisitNotes != null)
                {
                }

                _lblVisitNotes = value;
                if (_lblVisitNotes != null)
                {
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
            _lblVisitDate = new Label();
            _dtpVisitDate = new DateTimePicker();
            _txtEngineer = new TextBox();
            _btnFindEngineer = new Button();
            _btnFindEngineer.Click += new EventHandler(btnFindEngineer_Click);
            _lblEngineer = new Label();
            _txtCustomer = new TextBox();
            _btnFindCustomer = new Button();
            _btnFindCustomer.Click += new EventHandler(btnFindCustomer_Click);
            _lblCustomer = new Label();
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
            _lblVisitNotes = new Label();
            _txtNotes = new RichTextBox();
            _grpExcelFile.SuspendLayout();
            _grpFailedImports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgFailedImports).BeginInit();
            SuspendLayout();
            //
            // grpExcelFile
            //
            _grpExcelFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpExcelFile.Controls.Add(_txtNotes);
            _grpExcelFile.Controls.Add(_lblVisitNotes);
            _grpExcelFile.Controls.Add(_lblVisitDate);
            _grpExcelFile.Controls.Add(_dtpVisitDate);
            _grpExcelFile.Controls.Add(_txtEngineer);
            _grpExcelFile.Controls.Add(_btnFindEngineer);
            _grpExcelFile.Controls.Add(_lblEngineer);
            _grpExcelFile.Controls.Add(_txtCustomer);
            _grpExcelFile.Controls.Add(_btnFindCustomer);
            _grpExcelFile.Controls.Add(_lblCustomer);
            _grpExcelFile.Controls.Add(_cboJobType);
            _grpExcelFile.Controls.Add(_lblJobType);
            _grpExcelFile.Controls.Add(_lblFile);
            _grpExcelFile.Controls.Add(_btnImport);
            _grpExcelFile.Controls.Add(_btnFindExcelFile);
            _grpExcelFile.Controls.Add(_txtExcelFile);
            _grpExcelFile.FlatStyle = FlatStyle.System;
            _grpExcelFile.Location = new Point(8, 40);
            _grpExcelFile.Name = "grpExcelFile";
            _grpExcelFile.Size = new Size(896, 159);
            _grpExcelFile.TabIndex = 3;
            _grpExcelFile.TabStop = false;
            _grpExcelFile.Text = "Select data file to import";
            //
            // lblVisitDate
            //
            _lblVisitDate.AutoSize = true;
            _lblVisitDate.Location = new Point(9, 60);
            _lblVisitDate.Name = "lblVisitDate";
            _lblVisitDate.Size = new Size(67, 13);
            _lblVisitDate.TabIndex = 45;
            _lblVisitDate.Text = "Visit Date:";
            //
            // dtpVisitDate
            //
            _dtpVisitDate.Location = new Point(89, 54);
            _dtpVisitDate.Name = "dtpVisitDate";
            _dtpVisitDate.Size = new Size(151, 21);
            _dtpVisitDate.TabIndex = 44;
            //
            // txtEngineer
            //
            _txtEngineer.Location = new Point(324, 54);
            _txtEngineer.Name = "txtEngineer";
            _txtEngineer.ReadOnly = true;
            _txtEngineer.Size = new Size(168, 21);
            _txtEngineer.TabIndex = 43;
            //
            // btnFindEngineer
            //
            _btnFindEngineer.Location = new Point(498, 54);
            _btnFindEngineer.Name = "btnFindEngineer";
            _btnFindEngineer.Size = new Size(32, 23);
            _btnFindEngineer.TabIndex = 42;
            _btnFindEngineer.Text = "...";
            _btnFindEngineer.UseVisualStyleBackColor = true;
            //
            // lblEngineer
            //
            _lblEngineer.AutoSize = true;
            _lblEngineer.Location = new Point(256, 59);
            _lblEngineer.Name = "lblEngineer";
            _lblEngineer.Size = new Size(62, 13);
            _lblEngineer.TabIndex = 41;
            _lblEngineer.Text = "Engineer:";
            //
            // txtCustomer
            //
            _txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtCustomer.Location = new Point(616, 56);
            _txtCustomer.Name = "txtCustomer";
            _txtCustomer.ReadOnly = true;
            _txtCustomer.Size = new Size(236, 21);
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
            _lblCustomer.Location = new Point(536, 59);
            _lblCustomer.Name = "lblCustomer";
            _lblCustomer.Size = new Size(74, 13);
            _lblCustomer.TabIndex = 38;
            _lblCustomer.Text = "Customers:";
            //
            // cboJobType
            //
            _cboJobType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboJobType.Cursor = Cursors.Hand;
            _cboJobType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboJobType.Location = new Point(653, 20);
            _cboJobType.Name = "cboJobType";
            _cboJobType.Size = new Size(158, 21);
            _cboJobType.TabIndex = 35;
            _cboJobType.Tag = "Site.RegionID";
            //
            // lblJobType
            //
            _lblJobType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblJobType.AutoSize = true;
            _lblJobType.Location = new Point(585, 23);
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
            _btnFindExcelFile.Location = new Point(539, 18);
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
            _txtExcelFile.Size = new Size(487, 21);
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
            _grpFailedImports.Location = new Point(8, 205);
            _grpFailedImports.Name = "grpFailedImports";
            _grpFailedImports.Size = new Size(896, 377);
            _grpFailedImports.TabIndex = 15;
            _grpFailedImports.TabStop = false;
            _grpFailedImports.Text = "Failed Jobs";
            //
            // dgFailedImports
            //
            _dgFailedImports.DataMember = "";
            _dgFailedImports.Dock = DockStyle.Fill;
            _dgFailedImports.HeaderForeColor = SystemColors.ControlText;
            _dgFailedImports.Location = new Point(3, 17);
            _dgFailedImports.Name = "dgFailedImports";
            _dgFailedImports.Size = new Size(890, 357);
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
            // lblVisitNotes
            //
            _lblVisitNotes.AutoSize = true;
            _lblVisitNotes.Location = new Point(9, 97);
            _lblVisitNotes.Name = "lblVisitNotes";
            _lblVisitNotes.Size = new Size(72, 13);
            _lblVisitNotes.TabIndex = 46;
            _lblVisitNotes.Text = "Visit Notes:";
            //
            // txtNotes
            //
            _txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtNotes.Location = new Point(89, 94);
            _txtNotes.Name = "txtNotes";
            _txtNotes.Size = new Size(801, 50);
            _txtNotes.TabIndex = 47;
            _txtNotes.Text = "";
            //
            // FRMBulkJobCreation
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
            Name = "FRMBulkJobCreation";
            Text = "Bulk Create Jobs";
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

        private void FRMBulkJobCreation_Load(object sender, EventArgs e)
        {
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

        private bool IsFormValid()
        {
            if (Customers is null)
            {
                App.ShowMessage("Please select a customer!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Helper.MakeIntegerValid(Engineer?.EngineerID) == 0)
            {
                App.ShowMessage("Please select a Engineer!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Conversions.ToBoolean(Helper.MakeIntegerValid(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboJobType)) == 0)))
            {
                App.ShowMessage("Please select a job type!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void Import()
        {
            if (!IsFormValid())
                return;
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
                ImportJobs(data);
            }
            catch (Exception ex)
            {
                App.ShowMessage("File data could not be imported : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                KillInstances(oExcel);
                string filePath = App.TheSystem.Configuration.DocumentsLocation + @"BulkJobCreation\";
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

        private void ImportJobs(DataSet data)
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
                    CreateJob(site);
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

        public void CreateJob(Site oSite)
        {
            var JobNumber = new JobNumber();
            JobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Callout);
            var job = new Entity.Jobs.Job()
            {
                SetPropertyID = oSite.SiteID,
                SetJobDefinitionEnumID = Conversions.ToInteger(Enums.JobDefinition.Callout),
                SetJobTypeID = Helper.MakeIntegerValid(Combo.get_GetSelectedItemValue(cboJobType)),
                SetStatusEnumID = Conversions.ToInteger(Enums.JobStatus.Open),
                SetCreatedByUserID = App.loggedInUser.UserID,
                SetFOC = true,
                SetJobCreationType = Conversions.ToInteger(Enums.JobCreationType.JobManager),
                SetJobNumber = JobNumber.Prefix + JobNumber.JobNumber,
                SetPONumber = "",
                SetQuoteID = 0,
                SetContractID = 0
            };
            var jobOfWork = new Entity.JobOfWorks.JobOfWork()
            {
                SetPONumber = "",
                SetPriority = 0
            };
            var engineerVisit = new Entity.EngineerVisits.EngineerVisit()
            {
                IgnoreExceptionsOnSetMethods = true,
                SetEngineerID = Engineer.EngineerID,
                SetNotesToEngineer = txtNotes.Text.Trim(),
                StartDateTime = dtpVisitDate.Value,
                EndDateTime = dtpVisitDate.Value.AddHours(1),
                SetStatusEnumID = Conversions.ToInteger(Enums.VisitStatus.Scheduled),
                SetAMPM = "AM",
                SetVisitNumber = 1
            };
            jobOfWork.EngineerVisits.Add(engineerVisit);
            job.JobOfWorks.Add(jobOfWork);
            job = App.DB.Job.Insert(job);
        }

        private void Export()
        {
            ExportHelper.Export(FailedImports, "Jobs", Enums.ExportType.XLS);
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