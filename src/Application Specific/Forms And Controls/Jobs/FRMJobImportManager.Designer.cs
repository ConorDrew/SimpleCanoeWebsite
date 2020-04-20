using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    [DesignerGenerated()]
    public partial class FRMJobImportManager : FRMBaseForm, IForm
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            _grpJobs = new GroupBox();
            _dgJobs = new DataGrid();
            _dgJobs.Click += new EventHandler(dgJobs_Click);
            _btnResetFilters = new Button();
            _btnResetFilters.Click += new EventHandler(btnResetFilters_Click);
            _grpFilters = new GroupBox();
            _chkSortPostcode = new CheckBox();
            _cboJobType = new ComboBox();
            _lblJobType = new Label();
            _txtJobsPerDay = new TextBox();
            _cboLetterNumber = new ComboBox();
            _lblJobsPerDay = new Label();
            _Label14 = new Label();
            _btnFilter = new Button();
            _btnFilter.Click += new EventHandler(btnFilter_Click);
            _Label1 = new Label();
            _dtpLetterCreateDate = new DateTimePicker();
            _btnSelectAll = new Button();
            _btnSelectAll.Click += new EventHandler(btnSelectAll_Click);
            _btnUnselect = new Button();
            _btnUnselect.Click += new EventHandler(btnUnselect_Click);
            _btnGenerateLetters = new Button();
            _btnGenerateLetters.Click += new EventHandler(btnGenerateLetters_Click);
            _chkScheduleJobs = new CheckBox();
            _btnFindSite = new Button();
            _btnFindSite.Click += new EventHandler(btnFindSite_Click);
            _cmsAction = new ContextMenuStrip(components);
            _tsmiDeleteSite = new ToolStripMenuItem();
            _tsmiDeleteSite.Click += new EventHandler(tsmiDeleteSite_Click);
            _tsmiCreateJob = new ToolStripMenuItem();
            _tsmiCreateJob.Click += new EventHandler(tsmiCreateJob_Click);
            _grpJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgJobs).BeginInit();
            _grpFilters.SuspendLayout();
            _cmsAction.SuspendLayout();
            SuspendLayout();
            // 
            // grpJobs
            // 
            _grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpJobs.Controls.Add(_dgJobs);
            _grpJobs.Location = new Point(12, 154);
            _grpJobs.Name = "grpJobs";
            _grpJobs.Size = new Size(962, 271);
            _grpJobs.TabIndex = 3;
            _grpJobs.TabStop = false;
            _grpJobs.Text = "Jobs";
            // 
            // dgJobs
            // 
            _dgJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgJobs.DataMember = "";
            _dgJobs.HeaderForeColor = SystemColors.ControlText;
            _dgJobs.Location = new Point(8, 20);
            _dgJobs.Name = "dgJobs";
            _dgJobs.Size = new Size(946, 243);
            _dgJobs.TabIndex = 14;
            // 
            // btnResetFilters
            // 
            _btnResetFilters.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnResetFilters.Location = new Point(20, 431);
            _btnResetFilters.Name = "btnResetFilters";
            _btnResetFilters.Size = new Size(111, 23);
            _btnResetFilters.TabIndex = 4;
            _btnResetFilters.Text = "Reset Filters";
            _btnResetFilters.UseVisualStyleBackColor = true;
            // 
            // grpFilters
            // 
            _grpFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpFilters.Controls.Add(_chkSortPostcode);
            _grpFilters.Controls.Add(_cboJobType);
            _grpFilters.Controls.Add(_lblJobType);
            _grpFilters.Controls.Add(_txtJobsPerDay);
            _grpFilters.Controls.Add(_cboLetterNumber);
            _grpFilters.Controls.Add(_lblJobsPerDay);
            _grpFilters.Controls.Add(_Label14);
            _grpFilters.Controls.Add(_btnFilter);
            _grpFilters.Controls.Add(_Label1);
            _grpFilters.Controls.Add(_dtpLetterCreateDate);
            _grpFilters.Location = new Point(12, 38);
            _grpFilters.Name = "grpFilters";
            _grpFilters.Size = new Size(962, 81);
            _grpFilters.TabIndex = 5;
            _grpFilters.TabStop = false;
            _grpFilters.Text = "Filters";
            // 
            // chkSortPostcode
            // 
            _chkSortPostcode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _chkSortPostcode.AutoSize = true;
            _chkSortPostcode.Checked = true;
            _chkSortPostcode.CheckState = CheckState.Checked;
            _chkSortPostcode.Location = new Point(440, 49);
            _chkSortPostcode.Name = "chkSortPostcode";
            _chkSortPostcode.Size = new Size(123, 17);
            _chkSortPostcode.TabIndex = 46;
            _chkSortPostcode.Text = "Sort by postcode";
            _chkSortPostcode.UseVisualStyleBackColor = true;
            // 
            // cboJobType
            // 
            _cboJobType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboJobType.Cursor = Cursors.Hand;
            _cboJobType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboJobType.Location = new Point(258, 47);
            _cboJobType.Name = "cboJobType";
            _cboJobType.Size = new Size(167, 21);
            _cboJobType.TabIndex = 43;
            _cboJobType.Tag = "Site.RegionID";
            // 
            // lblJobType
            // 
            _lblJobType.AutoSize = true;
            _lblJobType.Location = new Point(178, 50);
            _lblJobType.Name = "lblJobType";
            _lblJobType.Size = new Size(62, 13);
            _lblJobType.TabIndex = 42;
            _lblJobType.Text = "Job Type:";
            // 
            // txtJobsPerDay
            // 
            _txtJobsPerDay.Location = new Point(94, 47);
            _txtJobsPerDay.Name = "txtJobsPerDay";
            _txtJobsPerDay.Size = new Size(53, 21);
            _txtJobsPerDay.TabIndex = 5;
            _txtJobsPerDay.Text = "32";
            // 
            // cboLetterNumber
            // 
            _cboLetterNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboLetterNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboLetterNumber.Location = new Point(424, 14);
            _cboLetterNumber.Name = "cboLetterNumber";
            _cboLetterNumber.Size = new Size(324, 21);
            _cboLetterNumber.TabIndex = 41;
            // 
            // lblJobsPerDay
            // 
            _lblJobsPerDay.AutoSize = true;
            _lblJobsPerDay.Location = new Point(6, 50);
            _lblJobsPerDay.Name = "lblJobsPerDay";
            _lblJobsPerDay.Size = new Size(82, 13);
            _lblJobsPerDay.TabIndex = 4;
            _lblJobsPerDay.Text = "Jobs Per Day";
            // 
            // Label14
            // 
            _Label14.Location = new Point(360, 18);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(96, 16);
            _Label14.TabIndex = 40;
            _Label14.Text = "Letter No.";
            // 
            // btnFilter
            // 
            _btnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFilter.Location = new Point(879, 39);
            _btnFilter.Name = "btnFilter";
            _btnFilter.Size = new Size(75, 23);
            _btnFilter.TabIndex = 30;
            _btnFilter.Text = "Filter";
            _btnFilter.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            _Label1.Location = new Point(6, 17);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(130, 16);
            _Label1.TabIndex = 29;
            _Label1.Text = "Letter Create Date";
            // 
            // dtpLetterCreateDate
            // 
            _dtpLetterCreateDate.Location = new Point(142, 12);
            _dtpLetterCreateDate.Name = "dtpLetterCreateDate";
            _dtpLetterCreateDate.Size = new Size(200, 21);
            _dtpLetterCreateDate.TabIndex = 28;
            // 
            // btnSelectAll
            // 
            _btnSelectAll.Location = new Point(12, 125);
            _btnSelectAll.Name = "btnSelectAll";
            _btnSelectAll.Size = new Size(119, 23);
            _btnSelectAll.TabIndex = 6;
            _btnSelectAll.Text = "Select All";
            _btnSelectAll.UseVisualStyleBackColor = true;
            // 
            // btnUnselect
            // 
            _btnUnselect.Location = new Point(154, 125);
            _btnUnselect.Name = "btnUnselect";
            _btnUnselect.Size = new Size(96, 23);
            _btnUnselect.TabIndex = 7;
            _btnUnselect.Text = "Unselect All";
            _btnUnselect.UseVisualStyleBackColor = true;
            // 
            // btnGenerateLetters
            // 
            _btnGenerateLetters.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnGenerateLetters.Location = new Point(808, 431);
            _btnGenerateLetters.Name = "btnGenerateLetters";
            _btnGenerateLetters.Size = new Size(158, 23);
            _btnGenerateLetters.TabIndex = 8;
            _btnGenerateLetters.Text = "Generate Jobs";
            _btnGenerateLetters.UseVisualStyleBackColor = true;
            // 
            // chkScheduleJobs
            // 
            _chkScheduleJobs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _chkScheduleJobs.AutoSize = true;
            _chkScheduleJobs.Checked = true;
            _chkScheduleJobs.CheckState = CheckState.Checked;
            _chkScheduleJobs.Location = new Point(867, 131);
            _chkScheduleJobs.Name = "chkScheduleJobs";
            _chkScheduleJobs.Size = new Size(107, 17);
            _chkScheduleJobs.TabIndex = 45;
            _chkScheduleJobs.Text = "Schedule Jobs";
            _chkScheduleJobs.UseVisualStyleBackColor = true;
            // 
            // btnFindSite
            // 
            _btnFindSite.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnFindSite.Location = new Point(137, 431);
            _btnFindSite.Name = "btnFindSite";
            _btnFindSite.Size = new Size(111, 23);
            _btnFindSite.TabIndex = 46;
            _btnFindSite.Text = "Find Site";
            _btnFindSite.UseVisualStyleBackColor = true;
            // 
            // cmsAction
            // 
            _cmsAction.Items.AddRange(new ToolStripItem[] { _tsmiDeleteSite, _tsmiCreateJob });
            _cmsAction.Name = "cmsAction";
            _cmsAction.Size = new Size(130, 48);
            // 
            // tsmiDeleteSite
            // 
            _tsmiDeleteSite.Name = "tsmiDeleteSite";
            _tsmiDeleteSite.Size = new Size(129, 22);
            _tsmiDeleteSite.Text = "Delete Site";
            // 
            // tsmiCreateJob
            // 
            _tsmiCreateJob.Name = "tsmiCreateJob";
            _tsmiCreateJob.Size = new Size(129, 22);
            _tsmiCreateJob.Text = "Create Job";
            // 
            // FRMJobImportManager
            // 
            AutoScaleDimensions = new SizeF(7.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(986, 466);
            Controls.Add(_btnFindSite);
            Controls.Add(_chkScheduleJobs);
            Controls.Add(_btnGenerateLetters);
            Controls.Add(_btnUnselect);
            Controls.Add(_btnSelectAll);
            Controls.Add(_grpFilters);
            Controls.Add(_btnResetFilters);
            Controls.Add(_grpJobs);
            Name = "FRMJobImportManager";
            StartPosition = FormStartPosition.Manual;
            Text = "Letter Manager";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpJobs, 0);
            Controls.SetChildIndex(_btnResetFilters, 0);
            Controls.SetChildIndex(_grpFilters, 0);
            Controls.SetChildIndex(_btnSelectAll, 0);
            Controls.SetChildIndex(_btnUnselect, 0);
            Controls.SetChildIndex(_btnGenerateLetters, 0);
            Controls.SetChildIndex(_chkScheduleJobs, 0);
            Controls.SetChildIndex(_btnFindSite, 0);
            _grpJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgJobs).EndInit();
            _grpFilters.ResumeLayout(false);
            _grpFilters.PerformLayout();
            _cmsAction.ResumeLayout(false);
            Load += new EventHandler(FRMJobManager_Load);
            ResumeLayout(false);
            PerformLayout();
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
                    _dgJobs.Click -= dgJobs_Click;
                }

                _dgJobs = value;
                if (_dgJobs != null)
                {
                    _dgJobs.Click += dgJobs_Click;
                }
            }
        }

        private Button _btnResetFilters;

        internal Button btnResetFilters
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnResetFilters;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnResetFilters != null)
                {
                    _btnResetFilters.Click -= btnResetFilters_Click;
                }

                _btnResetFilters = value;
                if (_btnResetFilters != null)
                {
                    _btnResetFilters.Click += btnResetFilters_Click;
                }
            }
        }

        private GroupBox _grpFilters;

        internal GroupBox grpFilters
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpFilters;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpFilters != null)
                {
                }

                _grpFilters = value;
                if (_grpFilters != null)
                {
                }
            }
        }

        private Button _btnFilter;

        internal Button btnFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFilter != null)
                {
                    _btnFilter.Click -= btnFilter_Click;
                }

                _btnFilter = value;
                if (_btnFilter != null)
                {
                    _btnFilter.Click += btnFilter_Click;
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

        private DateTimePicker _dtpLetterCreateDate;

        internal DateTimePicker dtpLetterCreateDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpLetterCreateDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpLetterCreateDate != null)
                {
                }

                _dtpLetterCreateDate = value;
                if (_dtpLetterCreateDate != null)
                {
                }
            }
        }

        private Button _btnSelectAll;

        internal Button btnSelectAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSelectAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSelectAll != null)
                {
                    _btnSelectAll.Click -= btnSelectAll_Click;
                }

                _btnSelectAll = value;
                if (_btnSelectAll != null)
                {
                    _btnSelectAll.Click += btnSelectAll_Click;
                }
            }
        }

        private Button _btnUnselect;

        internal Button btnUnselect
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnUnselect;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnUnselect != null)
                {
                    _btnUnselect.Click -= btnUnselect_Click;
                }

                _btnUnselect = value;
                if (_btnUnselect != null)
                {
                    _btnUnselect.Click += btnUnselect_Click;
                }
            }
        }

        private Button _btnGenerateLetters;

        internal Button btnGenerateLetters
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnGenerateLetters;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnGenerateLetters != null)
                {
                    _btnGenerateLetters.Click -= btnGenerateLetters_Click;
                }

                _btnGenerateLetters = value;
                if (_btnGenerateLetters != null)
                {
                    _btnGenerateLetters.Click += btnGenerateLetters_Click;
                }
            }
        }

        private ComboBox _cboLetterNumber;

        internal ComboBox cboLetterNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboLetterNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboLetterNumber != null)
                {
                }

                _cboLetterNumber = value;
                if (_cboLetterNumber != null)
                {
                }
            }
        }

        private Label _Label14;

        internal Label Label14
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label14;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label14 != null)
                {
                }

                _Label14 = value;
                if (_Label14 != null)
                {
                }
            }
        }

        private TextBox _txtJobsPerDay;

        internal TextBox txtJobsPerDay
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtJobsPerDay;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtJobsPerDay != null)
                {
                }

                _txtJobsPerDay = value;
                if (_txtJobsPerDay != null)
                {
                }
            }
        }

        private Label _lblJobsPerDay;

        internal Label lblJobsPerDay
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblJobsPerDay;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblJobsPerDay != null)
                {
                }

                _lblJobsPerDay = value;
                if (_lblJobsPerDay != null)
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

        private CheckBox _chkScheduleJobs;

        internal CheckBox chkScheduleJobs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkScheduleJobs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkScheduleJobs != null)
                {
                }

                _chkScheduleJobs = value;
                if (_chkScheduleJobs != null)
                {
                }
            }
        }

        private CheckBox _chkSortPostcode;

        internal CheckBox chkSortPostcode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkSortPostcode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkSortPostcode != null)
                {
                }

                _chkSortPostcode = value;
                if (_chkSortPostcode != null)
                {
                }
            }
        }

        private Button _btnFindSite;

        internal Button btnFindSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindSite != null)
                {
                    _btnFindSite.Click -= btnFindSite_Click;
                }

                _btnFindSite = value;
                if (_btnFindSite != null)
                {
                    _btnFindSite.Click += btnFindSite_Click;
                }
            }
        }

        private ContextMenuStrip _cmsAction;

        internal ContextMenuStrip cmsAction
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmsAction;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmsAction != null)
                {
                }

                _cmsAction = value;
                if (_cmsAction != null)
                {
                }
            }
        }

        private ToolStripMenuItem _tsmiDeleteSite;

        internal ToolStripMenuItem tsmiDeleteSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmiDeleteSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmiDeleteSite != null)
                {
                    _tsmiDeleteSite.Click -= tsmiDeleteSite_Click;
                }

                _tsmiDeleteSite = value;
                if (_tsmiDeleteSite != null)
                {
                    _tsmiDeleteSite.Click += tsmiDeleteSite_Click;
                }
            }
        }

        private ToolStripMenuItem _tsmiCreateJob;

        internal ToolStripMenuItem tsmiCreateJob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tsmiCreateJob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tsmiCreateJob != null)
                {
                    _tsmiCreateJob.Click -= tsmiCreateJob_Click;
                }

                _tsmiCreateJob = value;
                if (_tsmiCreateJob != null)
                {
                    _tsmiCreateJob.Click += tsmiCreateJob_Click;
                }
            }
        }
    }
}