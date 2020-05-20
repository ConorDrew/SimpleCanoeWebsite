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
            this.components = new System.ComponentModel.Container();
            this._grpJobs = new System.Windows.Forms.GroupBox();
            this._dgJobs = new System.Windows.Forms.DataGrid();
            this._btnResetFilters = new System.Windows.Forms.Button();
            this._grpFilters = new System.Windows.Forms.GroupBox();
            this._chkSortPostcode = new System.Windows.Forms.CheckBox();
            this._cboJobType = new System.Windows.Forms.ComboBox();
            this._lblJobType = new System.Windows.Forms.Label();
            this._txtJobsPerDay = new System.Windows.Forms.TextBox();
            this._cboLetterNumber = new System.Windows.Forms.ComboBox();
            this._lblJobsPerDay = new System.Windows.Forms.Label();
            this._Label14 = new System.Windows.Forms.Label();
            this._btnFilter = new System.Windows.Forms.Button();
            this._Label1 = new System.Windows.Forms.Label();
            this._dtpLetterCreateDate = new System.Windows.Forms.DateTimePicker();
            this._btnSelectAll = new System.Windows.Forms.Button();
            this._btnUnselect = new System.Windows.Forms.Button();
            this._btnGenerateLetters = new System.Windows.Forms.Button();
            this._chkScheduleJobs = new System.Windows.Forms.CheckBox();
            this._btnFindSite = new System.Windows.Forms.Button();
            this._cmsAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._tsmiDeleteSite = new System.Windows.Forms.ToolStripMenuItem();
            this._tsmiCreateJob = new System.Windows.Forms.ToolStripMenuItem();
            this._grpJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgJobs)).BeginInit();
            this._grpFilters.SuspendLayout();
            this._cmsAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpJobs
            // 
            this._grpJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpJobs.Controls.Add(this._dgJobs);
            this._grpJobs.Location = new System.Drawing.Point(12, 128);
            this._grpJobs.Name = "_grpJobs";
            this._grpJobs.Size = new System.Drawing.Size(962, 297);
            this._grpJobs.TabIndex = 3;
            this._grpJobs.TabStop = false;
            this._grpJobs.Text = "Jobs";
            // 
            // _dgJobs
            // 
            this._dgJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgJobs.DataMember = "";
            this._dgJobs.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgJobs.Location = new System.Drawing.Point(8, 20);
            this._dgJobs.Name = "_dgJobs";
            this._dgJobs.Size = new System.Drawing.Size(946, 269);
            this._dgJobs.TabIndex = 14;
            this._dgJobs.Click += new System.EventHandler(this.dgJobs_Click);
            // 
            // _btnResetFilters
            // 
            this._btnResetFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnResetFilters.Location = new System.Drawing.Point(20, 431);
            this._btnResetFilters.Name = "_btnResetFilters";
            this._btnResetFilters.Size = new System.Drawing.Size(111, 23);
            this._btnResetFilters.TabIndex = 4;
            this._btnResetFilters.Text = "Reset Filters";
            this._btnResetFilters.UseVisualStyleBackColor = true;
            this._btnResetFilters.Click += new System.EventHandler(this.btnResetFilters_Click);
            // 
            // _grpFilters
            // 
            this._grpFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpFilters.Controls.Add(this._chkSortPostcode);
            this._grpFilters.Controls.Add(this._cboJobType);
            this._grpFilters.Controls.Add(this._lblJobType);
            this._grpFilters.Controls.Add(this._txtJobsPerDay);
            this._grpFilters.Controls.Add(this._cboLetterNumber);
            this._grpFilters.Controls.Add(this._lblJobsPerDay);
            this._grpFilters.Controls.Add(this._Label14);
            this._grpFilters.Controls.Add(this._btnFilter);
            this._grpFilters.Controls.Add(this._Label1);
            this._grpFilters.Controls.Add(this._dtpLetterCreateDate);
            this._grpFilters.Location = new System.Drawing.Point(12, 12);
            this._grpFilters.Name = "_grpFilters";
            this._grpFilters.Size = new System.Drawing.Size(962, 81);
            this._grpFilters.TabIndex = 5;
            this._grpFilters.TabStop = false;
            this._grpFilters.Text = "Filters";
            // 
            // _chkSortPostcode
            // 
            this._chkSortPostcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chkSortPostcode.AutoSize = true;
            this._chkSortPostcode.Checked = true;
            this._chkSortPostcode.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkSortPostcode.Location = new System.Drawing.Point(440, 49);
            this._chkSortPostcode.Name = "_chkSortPostcode";
            this._chkSortPostcode.Size = new System.Drawing.Size(123, 17);
            this._chkSortPostcode.TabIndex = 46;
            this._chkSortPostcode.Text = "Sort by postcode";
            this._chkSortPostcode.UseVisualStyleBackColor = true;
            // 
            // _cboJobType
            // 
            this._cboJobType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboJobType.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cboJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboJobType.Location = new System.Drawing.Point(258, 47);
            this._cboJobType.Name = "_cboJobType";
            this._cboJobType.Size = new System.Drawing.Size(167, 21);
            this._cboJobType.TabIndex = 43;
            this._cboJobType.Tag = "Site.RegionID";
            // 
            // _lblJobType
            // 
            this._lblJobType.AutoSize = true;
            this._lblJobType.Location = new System.Drawing.Point(178, 50);
            this._lblJobType.Name = "_lblJobType";
            this._lblJobType.Size = new System.Drawing.Size(62, 13);
            this._lblJobType.TabIndex = 42;
            this._lblJobType.Text = "Job Type:";
            // 
            // _txtJobsPerDay
            // 
            this._txtJobsPerDay.Location = new System.Drawing.Point(94, 47);
            this._txtJobsPerDay.Name = "_txtJobsPerDay";
            this._txtJobsPerDay.Size = new System.Drawing.Size(53, 21);
            this._txtJobsPerDay.TabIndex = 5;
            this._txtJobsPerDay.Text = "32";
            // 
            // _cboLetterNumber
            // 
            this._cboLetterNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboLetterNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboLetterNumber.Location = new System.Drawing.Point(424, 14);
            this._cboLetterNumber.Name = "_cboLetterNumber";
            this._cboLetterNumber.Size = new System.Drawing.Size(324, 21);
            this._cboLetterNumber.TabIndex = 41;
            // 
            // _lblJobsPerDay
            // 
            this._lblJobsPerDay.AutoSize = true;
            this._lblJobsPerDay.Location = new System.Drawing.Point(6, 50);
            this._lblJobsPerDay.Name = "_lblJobsPerDay";
            this._lblJobsPerDay.Size = new System.Drawing.Size(82, 13);
            this._lblJobsPerDay.TabIndex = 4;
            this._lblJobsPerDay.Text = "Jobs Per Day";
            // 
            // _Label14
            // 
            this._Label14.Location = new System.Drawing.Point(360, 18);
            this._Label14.Name = "_Label14";
            this._Label14.Size = new System.Drawing.Size(96, 16);
            this._Label14.TabIndex = 40;
            this._Label14.Text = "Letter No.";
            // 
            // _btnFilter
            // 
            this._btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFilter.Location = new System.Drawing.Point(879, 39);
            this._btnFilter.Name = "_btnFilter";
            this._btnFilter.Size = new System.Drawing.Size(75, 23);
            this._btnFilter.TabIndex = 30;
            this._btnFilter.Text = "Filter";
            this._btnFilter.UseVisualStyleBackColor = true;
            this._btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(6, 17);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(130, 16);
            this._Label1.TabIndex = 29;
            this._Label1.Text = "Letter Create Date";
            // 
            // _dtpLetterCreateDate
            // 
            this._dtpLetterCreateDate.Location = new System.Drawing.Point(142, 12);
            this._dtpLetterCreateDate.Name = "_dtpLetterCreateDate";
            this._dtpLetterCreateDate.Size = new System.Drawing.Size(200, 21);
            this._dtpLetterCreateDate.TabIndex = 28;
            // 
            // _btnSelectAll
            // 
            this._btnSelectAll.Location = new System.Drawing.Point(12, 99);
            this._btnSelectAll.Name = "_btnSelectAll";
            this._btnSelectAll.Size = new System.Drawing.Size(119, 23);
            this._btnSelectAll.TabIndex = 6;
            this._btnSelectAll.Text = "Select All";
            this._btnSelectAll.UseVisualStyleBackColor = true;
            this._btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // _btnUnselect
            // 
            this._btnUnselect.Location = new System.Drawing.Point(154, 99);
            this._btnUnselect.Name = "_btnUnselect";
            this._btnUnselect.Size = new System.Drawing.Size(96, 23);
            this._btnUnselect.TabIndex = 7;
            this._btnUnselect.Text = "Unselect All";
            this._btnUnselect.UseVisualStyleBackColor = true;
            this._btnUnselect.Click += new System.EventHandler(this.btnUnselect_Click);
            // 
            // _btnGenerateLetters
            // 
            this._btnGenerateLetters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnGenerateLetters.Location = new System.Drawing.Point(808, 431);
            this._btnGenerateLetters.Name = "_btnGenerateLetters";
            this._btnGenerateLetters.Size = new System.Drawing.Size(158, 23);
            this._btnGenerateLetters.TabIndex = 8;
            this._btnGenerateLetters.Text = "Generate Jobs";
            this._btnGenerateLetters.UseVisualStyleBackColor = true;
            this._btnGenerateLetters.Click += new System.EventHandler(this.btnGenerateLetters_Click);
            // 
            // _chkScheduleJobs
            // 
            this._chkScheduleJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chkScheduleJobs.AutoSize = true;
            this._chkScheduleJobs.Checked = true;
            this._chkScheduleJobs.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkScheduleJobs.Location = new System.Drawing.Point(867, 105);
            this._chkScheduleJobs.Name = "_chkScheduleJobs";
            this._chkScheduleJobs.Size = new System.Drawing.Size(107, 17);
            this._chkScheduleJobs.TabIndex = 45;
            this._chkScheduleJobs.Text = "Schedule Jobs";
            this._chkScheduleJobs.UseVisualStyleBackColor = true;
            // 
            // _btnFindSite
            // 
            this._btnFindSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnFindSite.Location = new System.Drawing.Point(137, 431);
            this._btnFindSite.Name = "_btnFindSite";
            this._btnFindSite.Size = new System.Drawing.Size(111, 23);
            this._btnFindSite.TabIndex = 46;
            this._btnFindSite.Text = "Find Site";
            this._btnFindSite.UseVisualStyleBackColor = true;
            this._btnFindSite.Click += new System.EventHandler(this.btnFindSite_Click);
            // 
            // _cmsAction
            // 
            this._cmsAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsmiDeleteSite,
            this._tsmiCreateJob});
            this._cmsAction.Name = "cmsAction";
            this._cmsAction.Size = new System.Drawing.Size(130, 48);
            // 
            // _tsmiDeleteSite
            // 
            this._tsmiDeleteSite.Name = "_tsmiDeleteSite";
            this._tsmiDeleteSite.Size = new System.Drawing.Size(129, 22);
            this._tsmiDeleteSite.Text = "Delete Site";
            this._tsmiDeleteSite.Click += new System.EventHandler(this.tsmiDeleteSite_Click);
            // 
            // _tsmiCreateJob
            // 
            this._tsmiCreateJob.Name = "_tsmiCreateJob";
            this._tsmiCreateJob.Size = new System.Drawing.Size(129, 22);
            this._tsmiCreateJob.Text = "Create Job";
            this._tsmiCreateJob.Click += new System.EventHandler(this.tsmiCreateJob_Click);
            // 
            // FRMJobImportManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 466);
            this.Controls.Add(this._btnFindSite);
            this.Controls.Add(this._chkScheduleJobs);
            this.Controls.Add(this._btnGenerateLetters);
            this.Controls.Add(this._btnUnselect);
            this.Controls.Add(this._btnSelectAll);
            this.Controls.Add(this._grpFilters);
            this.Controls.Add(this._btnResetFilters);
            this.Controls.Add(this._grpJobs);
            this.Name = "FRMJobImportManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Letter Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRMJobManager_Load);
            this._grpJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgJobs)).EndInit();
            this._grpFilters.ResumeLayout(false);
            this._grpFilters.PerformLayout();
            this._cmsAction.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void IForm.LoadMe(object sender, EventArgs e)
        {
            
        }

        void IForm.ResetMe(int newID)
        {
            
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