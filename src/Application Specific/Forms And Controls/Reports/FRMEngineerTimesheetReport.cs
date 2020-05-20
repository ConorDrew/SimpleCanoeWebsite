using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMEngineerTimesheetReport : FRMBaseForm, IForm
    {
        public FRMEngineerTimesheetReport() : base()
        {
            base.Load += FRMEngineerTimesheetReport_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            switch (true)
            {
                case object _ when App.IsGasway:
                    {
                        var argc = cboDept;
                        Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Department).Table, "Name", "Name", Entity.Sys.Enums.ComboValues.Please_Select_Negative);
                        break;
                    }

                default:
                    {
                        var argc1 = cboDept;
                        Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Department).Table, "Name", "Description", Entity.Sys.Enums.ComboValues.Please_Select_Negative);
                        break;
                    }
            }

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

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
        private GroupBox _grpFilter;

        internal GroupBox grpFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpFilter != null)
                {
                }

                _grpFilter = value;
                if (_grpFilter != null)
                {
                }
            }
        }

        private GroupBox _grpJobs;

        private DateTimePicker _dtpTo;

        internal DateTimePicker dtpTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpTo != null)
                {
                }

                _dtpTo = value;
                if (_dtpTo != null)
                {
                }
            }
        }

        private DateTimePicker _dtpFrom;

        internal DateTimePicker dtpFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpFrom != null)
                {
                }

                _dtpFrom = value;
                if (_dtpFrom != null)
                {
                }
            }
        }

        private TextBox _txtJobNumber;

        internal TextBox txtJobNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtJobNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtJobNumber != null)
                {
                }

                _txtJobNumber = value;
                if (_txtJobNumber != null)
                {
                }
            }
        }

        private Label _Label9;

        private Label _Label8;

        private Label _Label6;

        internal Label Label6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label6 != null)
                {
                }

                _Label6 = value;
                if (_Label6 != null)
                {
                }
            }
        }

        private Button _btnExport;

        private Button _btnReset;

        internal Button btnReset
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnReset;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnReset != null)
                {
                    _btnReset.Click -= btnReset_Click;
                }

                _btnReset = value;
                if (_btnReset != null)
                {
                    _btnReset.Click += btnReset_Click;
                }
            }
        }

        private Label _Label4;

        internal Label Label4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label4 != null)
                {
                }

                _Label4 = value;
                if (_Label4 != null)
                {
                }
            }
        }

        private Button _btnRunReport;

        private DataGrid _dgEngineers;

        internal DataGrid dgEngineers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgEngineers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgEngineers != null)
                {
                    _dgEngineers.Click -= dgEngineers_Clicks;
                    _dgEngineers.DoubleClick -= dgEngineers_Clicks;
                }

                _dgEngineers = value;
                if (_dgEngineers != null)
                {
                    _dgEngineers.Click += dgEngineers_Clicks;
                    _dgEngineers.DoubleClick += dgEngineers_Clicks;
                }
            }
        }

        private Button _btnClearAll;

        private Button _btnSelectAll;

        private Button _btnSummary;

        private Label _lblDept;

        private ComboBox _cboDept;

        internal ComboBox cboDept
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDept;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDept != null)
                {
                    _cboDept.SelectedIndexChanged -= cboDept_Changed;
                }

                _cboDept = value;
                if (_cboDept != null)
                {
                    _cboDept.SelectedIndexChanged += cboDept_Changed;
                }
            }
        }

        private DataGrid _dgTimesheets;

        internal DataGrid dgTimesheets
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgTimesheets;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgTimesheets != null)
                {
                }

                _dgTimesheets = value;
                if (_dgTimesheets != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._grpJobs = new System.Windows.Forms.GroupBox();
            this._dgTimesheets = new System.Windows.Forms.DataGrid();
            this._btnExport = new System.Windows.Forms.Button();
            this._grpFilter = new System.Windows.Forms.GroupBox();
            this._cboDept = new System.Windows.Forms.ComboBox();
            this._lblDept = new System.Windows.Forms.Label();
            this._btnClearAll = new System.Windows.Forms.Button();
            this._btnSelectAll = new System.Windows.Forms.Button();
            this._dgEngineers = new System.Windows.Forms.DataGrid();
            this._btnRunReport = new System.Windows.Forms.Button();
            this._Label4 = new System.Windows.Forms.Label();
            this._dtpTo = new System.Windows.Forms.DateTimePicker();
            this._dtpFrom = new System.Windows.Forms.DateTimePicker();
            this._txtJobNumber = new System.Windows.Forms.TextBox();
            this._Label9 = new System.Windows.Forms.Label();
            this._Label8 = new System.Windows.Forms.Label();
            this._Label6 = new System.Windows.Forms.Label();
            this._btnReset = new System.Windows.Forms.Button();
            this._btnSummary = new System.Windows.Forms.Button();
            this._grpJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgTimesheets)).BeginInit();
            this._grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgEngineers)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpJobs
            // 
            this._grpJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpJobs.Controls.Add(this._dgTimesheets);
            this._grpJobs.Location = new System.Drawing.Point(8, 219);
            this._grpJobs.Name = "_grpJobs";
            this._grpJobs.Size = new System.Drawing.Size(844, 429);
            this._grpJobs.TabIndex = 2;
            this._grpJobs.TabStop = false;
            this._grpJobs.Text = "Double Click To View / Edit";
            // 
            // _dgTimesheets
            // 
            this._dgTimesheets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgTimesheets.DataMember = "";
            this._dgTimesheets.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgTimesheets.Location = new System.Drawing.Point(8, 19);
            this._dgTimesheets.Name = "_dgTimesheets";
            this._dgTimesheets.Size = new System.Drawing.Size(828, 402);
            this._dgTimesheets.TabIndex = 14;
            // 
            // _btnExport
            // 
            this._btnExport.AccessibleDescription = "Export Job List To Excel";
            this._btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnExport.Location = new System.Drawing.Point(8, 656);
            this._btnExport.Name = "_btnExport";
            this._btnExport.Size = new System.Drawing.Size(56, 23);
            this._btnExport.TabIndex = 15;
            this._btnExport.Text = "Export";
            this._btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // _grpFilter
            // 
            this._grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpFilter.Controls.Add(this._cboDept);
            this._grpFilter.Controls.Add(this._lblDept);
            this._grpFilter.Controls.Add(this._btnClearAll);
            this._grpFilter.Controls.Add(this._btnSelectAll);
            this._grpFilter.Controls.Add(this._dgEngineers);
            this._grpFilter.Controls.Add(this._btnRunReport);
            this._grpFilter.Controls.Add(this._Label4);
            this._grpFilter.Controls.Add(this._dtpTo);
            this._grpFilter.Controls.Add(this._dtpFrom);
            this._grpFilter.Controls.Add(this._txtJobNumber);
            this._grpFilter.Controls.Add(this._Label9);
            this._grpFilter.Controls.Add(this._Label8);
            this._grpFilter.Controls.Add(this._Label6);
            this._grpFilter.Location = new System.Drawing.Point(8, 12);
            this._grpFilter.Name = "_grpFilter";
            this._grpFilter.Size = new System.Drawing.Size(844, 201);
            this._grpFilter.TabIndex = 1;
            this._grpFilter.TabStop = false;
            this._grpFilter.Text = "Filter";
            // 
            // _cboDept
            // 
            this._cboDept.Location = new System.Drawing.Point(367, 35);
            this._cboDept.Name = "_cboDept";
            this._cboDept.Size = new System.Drawing.Size(126, 21);
            this._cboDept.TabIndex = 30;
            this._cboDept.SelectedIndexChanged += new System.EventHandler(this.cboDept_Changed);
            // 
            // _lblDept
            // 
            this._lblDept.BackColor = System.Drawing.Color.White;
            this._lblDept.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblDept.Location = new System.Drawing.Point(364, 16);
            this._lblDept.Name = "_lblDept";
            this._lblDept.Size = new System.Drawing.Size(103, 16);
            this._lblDept.TabIndex = 29;
            this._lblDept.Text = "Department";
            // 
            // _btnClearAll
            // 
            this._btnClearAll.Font = new System.Drawing.Font("Verdana", 8F);
            this._btnClearAll.Location = new System.Drawing.Point(148, 11);
            this._btnClearAll.Name = "_btnClearAll";
            this._btnClearAll.Size = new System.Drawing.Size(64, 23);
            this._btnClearAll.TabIndex = 28;
            this._btnClearAll.Text = "Clear All";
            this._btnClearAll.UseVisualStyleBackColor = true;
            this._btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // _btnSelectAll
            // 
            this._btnSelectAll.Font = new System.Drawing.Font("Verdana", 8F);
            this._btnSelectAll.Location = new System.Drawing.Point(78, 11);
            this._btnSelectAll.Name = "_btnSelectAll";
            this._btnSelectAll.Size = new System.Drawing.Size(64, 23);
            this._btnSelectAll.TabIndex = 27;
            this._btnSelectAll.Text = "Select All";
            this._btnSelectAll.UseVisualStyleBackColor = true;
            this._btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // _dgEngineers
            // 
            this._dgEngineers.AllowNavigation = false;
            this._dgEngineers.AlternatingBackColor = System.Drawing.Color.GhostWhite;
            this._dgEngineers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._dgEngineers.BackgroundColor = System.Drawing.Color.White;
            this._dgEngineers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._dgEngineers.CaptionBackColor = System.Drawing.Color.RoyalBlue;
            this._dgEngineers.CaptionForeColor = System.Drawing.Color.White;
            this._dgEngineers.CaptionText = "Engineers";
            this._dgEngineers.CaptionVisible = false;
            this._dgEngineers.DataMember = "";
            this._dgEngineers.Font = new System.Drawing.Font("Verdana", 8F);
            this._dgEngineers.ForeColor = System.Drawing.Color.MidnightBlue;
            this._dgEngineers.GridLineColor = System.Drawing.Color.RoyalBlue;
            this._dgEngineers.HeaderBackColor = System.Drawing.Color.MidnightBlue;
            this._dgEngineers.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this._dgEngineers.HeaderForeColor = System.Drawing.Color.Lavender;
            this._dgEngineers.LinkColor = System.Drawing.Color.Teal;
            this._dgEngineers.Location = new System.Drawing.Point(11, 35);
            this._dgEngineers.Name = "_dgEngineers";
            this._dgEngineers.ParentRowsBackColor = System.Drawing.Color.Lavender;
            this._dgEngineers.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this._dgEngineers.ParentRowsVisible = false;
            this._dgEngineers.RowHeadersVisible = false;
            this._dgEngineers.SelectionBackColor = System.Drawing.Color.Teal;
            this._dgEngineers.SelectionForeColor = System.Drawing.Color.PaleGreen;
            this._dgEngineers.Size = new System.Drawing.Size(350, 141);
            this._dgEngineers.TabIndex = 26;
            this._dgEngineers.Click += new System.EventHandler(this.dgEngineers_Clicks);
            this._dgEngineers.DoubleClick += new System.EventHandler(this.dgEngineers_Clicks);
            // 
            // _btnRunReport
            // 
            this._btnRunReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnRunReport.Location = new System.Drawing.Point(747, 172);
            this._btnRunReport.Name = "_btnRunReport";
            this._btnRunReport.Size = new System.Drawing.Size(91, 23);
            this._btnRunReport.TabIndex = 25;
            this._btnRunReport.Text = "Run Report";
            this._btnRunReport.Click += new System.EventHandler(this.btnRunReport_Click);
            // 
            // _Label4
            // 
            this._Label4.BackColor = System.Drawing.Color.White;
            this._Label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label4.Location = new System.Drawing.Point(8, 16);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(64, 16);
            this._Label4.TabIndex = 24;
            this._Label4.Text = "Engineers";
            // 
            // _dtpTo
            // 
            this._dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpTo.Location = new System.Drawing.Point(686, 47);
            this._dtpTo.Name = "_dtpTo";
            this._dtpTo.Size = new System.Drawing.Size(144, 21);
            this._dtpTo.TabIndex = 13;
            // 
            // _dtpFrom
            // 
            this._dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpFrom.Location = new System.Drawing.Point(686, 20);
            this._dtpFrom.Name = "_dtpFrom";
            this._dtpFrom.Size = new System.Drawing.Size(144, 21);
            this._dtpFrom.TabIndex = 12;
            // 
            // _txtJobNumber
            // 
            this._txtJobNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtJobNumber.Location = new System.Drawing.Point(686, 74);
            this._txtJobNumber.Name = "_txtJobNumber";
            this._txtJobNumber.Size = new System.Drawing.Size(144, 21);
            this._txtJobNumber.TabIndex = 9;
            // 
            // _Label9
            // 
            this._Label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label9.Location = new System.Drawing.Point(654, 52);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(24, 16);
            this._Label9.TabIndex = 10;
            this._Label9.Text = "To";
            this._Label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _Label8
            // 
            this._Label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label8.Location = new System.Drawing.Point(592, 25);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(88, 16);
            this._Label8.TabIndex = 9;
            this._Label8.Text = "Date From";
            this._Label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _Label6
            // 
            this._Label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label6.Location = new System.Drawing.Point(592, 79);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(88, 16);
            this._Label6.TabIndex = 6;
            this._Label6.Text = "Job Number";
            this._Label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _btnReset
            // 
            this._btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnReset.Location = new System.Drawing.Point(72, 656);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(56, 23);
            this._btnReset.TabIndex = 16;
            this._btnReset.Text = "Reset";
            this._btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // _btnSummary
            // 
            this._btnSummary.AccessibleDescription = "Export Job List To Excel";
            this._btnSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSummary.Location = new System.Drawing.Point(755, 656);
            this._btnSummary.Name = "_btnSummary";
            this._btnSummary.Size = new System.Drawing.Size(89, 23);
            this._btnSummary.TabIndex = 17;
            this._btnSummary.Text = "Summary";
            this._btnSummary.Click += new System.EventHandler(this.btnSummary_Click);
            // 
            // FRMEngineerTimesheetReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(860, 686);
            this.Controls.Add(this._btnSummary);
            this.Controls.Add(this._grpFilter);
            this.Controls.Add(this._btnExport);
            this.Controls.Add(this._grpJobs);
            this.Controls.Add(this._btnReset);
            this.MinimumSize = new System.Drawing.Size(808, 528);
            this.Name = "FRMEngineerTimesheetReport";
            this.Text = "Engineer Timesheet Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgTimesheets)).EndInit();
            this._grpFilter.ResumeLayout(false);
            this._grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgEngineers)).EndInit();
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupComboBoxes();
            SetupTimesheetsDataGrid();
            setUpDataGrid();
            PopulateDatagrid();
            EngineersDataView = App.DB.Engineer.Engineer_GetAll();
            var c = new DataColumn("Include", typeof(bool));
            c.DefaultValue = true;
            EngineersDataView.Table.Columns.Add(c);
            EngineersDataView.Table.AcceptChanges();
            foreach (DataRow r in EngineersDataView.Table.Rows)
                r["Include"] = true;
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

        private DataView _dvTimesheets;

        private DataView TimesheetsDataview
        {
            get
            {
                return _dvTimesheets;
            }

            set
            {
                _dvTimesheets = value;
                _dvTimesheets.AllowNew = false;
                _dvTimesheets.AllowEdit = false;
                _dvTimesheets.AllowDelete = false;
                _dvTimesheets.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitTimesheet.ToString();
                dgTimesheets.DataSource = TimesheetsDataview;
            }
        }

        private DataRow SelectedJobDataRow
        {
            get
            {
                if (!(dgTimesheets.CurrentRowIndex == -1))
                {
                    return TimesheetsDataview[dgTimesheets.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _dvEngineer;

        public DataView EngineersDataView
        {
            get
            {
                return _dvEngineer;
            }

            set
            {
                _dvEngineer = value;
                if (EngineersDataView is object)
                {
                    if (EngineersDataView.Table is object)
                    {
                        _dvEngineer.Table.TableName = "tblEngineers";
                        _dvEngineer.AllowNew = false;
                    }
                }

                dgEngineers.DataSource = EngineersDataView;
            }
        }

        private void SetupComboBoxes()
        {
            var Departments = new DataTable();
            Departments.Columns.Add("Value");
            Departments.Columns.Add("Description");
            DataRow DeptRow;
            DeptRow = Departments.NewRow();
            DeptRow["Value"] = 0;
            DeptRow["Description"] = "ALL";
            Departments.Rows.Add(DeptRow);
            DeptRow = Departments.NewRow();
            DeptRow["Value"] = 1;
            DeptRow["Description"] = "1";
            Departments.Rows.Add(DeptRow);
            DeptRow = Departments.NewRow();
            DeptRow["Value"] = 2;
            DeptRow["Description"] = "2";
            Departments.Rows.Add(DeptRow);
            DeptRow = Departments.NewRow();
            DeptRow["Value"] = 4;
            DeptRow["Description"] = "4";
            Departments.Rows.Add(DeptRow);
            DeptRow = Departments.NewRow();
            DeptRow["Value"] = 5;
            DeptRow["Description"] = "5";
            Departments.Rows.Add(DeptRow);
        }

        private void setUpDataGrid()
        {
            SuspendLayout();
            Entity.Sys.Helper.SetUpDataGrid(dgEngineers);
            var tsEngineers = dgEngineers.TableStyles[0];

            // Set up columns
            tsEngineers.ReadOnly = false;
            dgEngineers.ReadOnly = false;
            var include = new DataGridBoolColumn();
            include.HeaderText = "Include";
            include.MappingName = "Include";
            include.ReadOnly = false;
            include.Width = 50;
            // turn off tristate
            include.AllowNull = false;
            tsEngineers.GridColumnStyles.Add(include);
            var engineerID = new DataGridLabelColumn();
            engineerID.Format = "";
            engineerID.FormatInfo = null;
            engineerID.HeaderText = "Engineer ID";
            engineerID.MappingName = "EngineerID";
            engineerID.ReadOnly = true;
            engineerID.Width = 75;
            tsEngineers.GridColumnStyles.Add(engineerID);
            var engineerName = new DataGridLabelColumn();
            engineerName.Format = "";
            engineerName.FormatInfo = null;
            engineerName.HeaderText = "Engineer Name";
            engineerName.MappingName = "Name";
            engineerName.ReadOnly = true;
            engineerName.Width = 200;
            tsEngineers.GridColumnStyles.Add(engineerName);
            tsEngineers.MappingName = "tblEngineers";
            dgEngineers.TableStyles.Add(tsEngineers);
            ResumeLayout(true);
        }

        private void SetupTimesheetsDataGrid()
        {
            var tbStyle = dgTimesheets.TableStyles[0];
            var Source = new DataGridLabelColumn();
            Source.Format = "";
            Source.FormatInfo = null;
            Source.HeaderText = "Source";
            Source.MappingName = "Source";
            Source.ReadOnly = true;
            Source.Width = 100;
            Source.NullText = "";
            tbStyle.GridColumnStyles.Add(Source);
            var Engineer = new DataGridLabelColumn();
            Engineer.Format = "";
            Engineer.FormatInfo = null;
            Engineer.HeaderText = "Engineer";
            Engineer.MappingName = "Engineer";
            Engineer.ReadOnly = true;
            Engineer.Width = 150;
            Engineer.NullText = "";
            tbStyle.GridColumnStyles.Add(Engineer);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job Number";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 75;
            JobNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(JobNumber);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Property";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 100;
            Site.NullText = "";
            tbStyle.GridColumnStyles.Add(Site);
            var VisitDetails = new DataGridLabelColumn();
            VisitDetails.Format = "";
            VisitDetails.FormatInfo = null;
            VisitDetails.HeaderText = "Visit Details";
            VisitDetails.MappingName = "VisitDetails";
            VisitDetails.ReadOnly = true;
            VisitDetails.Width = 100;
            VisitDetails.NullText = "";
            tbStyle.GridColumnStyles.Add(VisitDetails);
            var DateFrom = new DataGridLabelColumn();
            DateFrom.Format = "dd/MM/yyyy";
            DateFrom.FormatInfo = null;
            DateFrom.HeaderText = "Date";
            DateFrom.MappingName = "StartDateTime";
            DateFrom.ReadOnly = true;
            DateFrom.Width = 75;
            DateFrom.NullText = "";
            tbStyle.GridColumnStyles.Add(DateFrom);
            var TimeFrom = new DataGridLabelColumn();
            TimeFrom.Format = "HH:mm";
            TimeFrom.FormatInfo = null;
            TimeFrom.HeaderText = "Start Time";
            TimeFrom.MappingName = "StartTime";
            TimeFrom.ReadOnly = true;
            TimeFrom.Width = 75;
            TimeFrom.NullText = "";
            tbStyle.GridColumnStyles.Add(TimeFrom);
            var TimeTo = new DataGridLabelColumn();
            TimeTo.Format = "HH:mm";
            TimeTo.FormatInfo = null;
            TimeTo.HeaderText = "End Time";
            TimeTo.MappingName = "EndDateTime";
            TimeTo.ReadOnly = true;
            TimeTo.Width = 100;
            TimeTo.NullText = "";
            tbStyle.GridColumnStyles.Add(TimeTo);
            var TimesheetType = new DataGridLabelColumn();
            TimesheetType.Format = "";
            TimesheetType.FormatInfo = null;
            TimesheetType.HeaderText = "Timesheet Type";
            TimesheetType.MappingName = "TimesheetType";
            TimesheetType.ReadOnly = true;
            TimesheetType.Width = 100;
            TimesheetType.NullText = "";
            tbStyle.GridColumnStyles.Add(TimesheetType);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVisitTimesheet.ToString();
            dgTimesheets.TableStyles.Add(tbStyle);
        }

        private void cboDept_Changed(object sender, EventArgs e)
        {
            string department = Entity.Sys.Helper.MakeStringValid(Combo.get_GetSelectedItemValue(cboDept));
            if (Entity.Sys.Helper.IsValidInteger(department) && Entity.Sys.Helper.MakeIntegerValid(department) <= -1)
            {
                // do nituhg
                return;
            }

            EngineersDataView = App.DB.Engineer.Engineer_GetAllbyDept(department);
            var c = new DataColumn("Include", typeof(bool));
            c.DefaultValue = true;
            EngineersDataView.Table.Columns.Add(c);
            EngineersDataView.Table.AcceptChanges();
            foreach (DataRow r in EngineersDataView.Table.Rows)
                r["Include"] = true;
        }

        private void FRMEngineerTimesheetReport_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            ExportSummary();
        }

        private void dgEngineers_Clicks(object sender, EventArgs e)
        {
            try
            {
                // this code mainly facilitates single clicks to change the state of a checkbox
                int includeColumn = 0;
                var pt = dgEngineers.PointToClient(MousePosition);
                var hti = dgEngineers.HitTest(pt);
                var bmb = BindingContext[dgEngineers.DataSource,
dgEngineers.DataMember];
                if (hti.Row < bmb.Count && hti.Type == DataGrid.HitTestType.Cell && hti.Column == includeColumn)
                {
                    bool selected = !Conversions.ToBoolean(dgEngineers[hti.Row, includeColumn]);
                    dgEngineers[hti.Row, includeColumn] = selected;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (EngineersDataView is object)
            {
                if (EngineersDataView.Table is object)
                {
                    foreach (DataRow r in EngineersDataView.Table.Rows)
                        r["Include"] = true;
                }
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (EngineersDataView is object)
            {
                if (EngineersDataView.Table is object)
                {
                    foreach (DataRow r in EngineersDataView.Table.Rows)
                        r["Include"] = false;
                }
            }
        }

        public void PopulateDatagrid()
        {
            try
            {
                ResetFilters();
                if (get_GetParameter(0) is null)
                {
                }
                else
                {
                    TimesheetsDataview = (DataView)get_GetParameter(0);
                    grpFilter.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFilters()
        {
            if (EngineersDataView is object)
            {
                if (EngineersDataView.Table is object)
                {
                    foreach (DataRow r in EngineersDataView.Table.Rows)
                        r["Include"] = true;
                }
            }

            txtJobNumber.Text = "";
            dtpFrom.Value = DateAndTime.Today.AddDays(-7);
            dtpTo.Value = DateAndTime.Today;
            grpFilter.Enabled = true;
            ShowData();
        }

        private void ShowData()
        {
            Cursor = Cursors.WaitCursor;
            string whereClause = " WHERE TS.StartDateTime >= '" + Strings.Format(dtpFrom.Value, "dd/MMM/yyyy 00:00:00") + "' AND TS.EndDateTime <= '" + Strings.Format(dtpTo.Value, "dd/MMM/yyyy 23:59:59") + "'";
            string engList = "0,";
            if (EngineersDataView is object)
            {
                if (EngineersDataView.Table is object)
                {
                    foreach (DataRow r in EngineersDataView.Table.Rows)
                    {
                        if (Conversions.ToBoolean(r["Include"]))
                        {
                            engList += r["EngineerID"] + ",";
                        }
                    }
                }
            }

            engList = engList.Substring(0, engList.Length - 1);
            whereClause += " AND tblEngineer.EngineerID IN (" + engList + ")";
            if (!(txtJobNumber.Text.Trim().Length == 0))
            {
                whereClause += " AND tblJob.JobNumber LIKE '" + txtJobNumber.Text.Trim() + "%'";
            }

            TimesheetsDataview = App.DB.EngineerVisitsTimeSheet.GetAll(whereClause);
            base.Cursor = Cursors.Default;
        }

        public void Export()
        {
            if (TimesheetsDataview.Count <= 0)
            {
                App.ShowMessage("No engineers are being displayed, please change / run filter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataRow[] rSel;
            int cnt = 0;
            var exportData = new DataTable();
            // exportData.Columns.Add("Engineer")
            exportData.Columns.Add("JobNumber");
            exportData.Columns.Add("Site");
            exportData.Columns.Add("Visit Details");
            exportData.Columns.Add("Notes From Engineer");
            // exportData.Columns.Add("Date")
            exportData.Columns.Add("Start Time");
            exportData.Columns.Add("End Time");
            exportData.Columns.Add("Timesheet Type");
            exportData.Columns.Add("Time");
            var theDays = new DataTable();
            theDays.Columns.Add("Day", typeof(DateTime));
            var dates = TimesheetsDataview.Table.Select("", "StartDateTime");
            foreach (DataRow d in dates)
            {
                if (theDays.Select("Day='" + Strings.Format(d["StartDateTime"], "dd/MMM/yyyy") + "'").Length == 0)
                {
                    DataRow dd;
                    dd = theDays.NewRow();
                    dd["Day"] = Strings.Format(d["StartDateTime"], "dd/MMM/yyyy");
                    theDays.Rows.Add(dd);
                }
            }

            if (theDays.Rows.Count > 5)
            {
                for (int datecol = 6, loopTo = theDays.Rows.Count; datecol <= loopTo; datecol++)
                    exportData.Columns.Add(datecol.ToString());
            }

            int i = 2;
            string lastDay = "";
            string lastEngineer = "";
            DataRow extraRw;
            var dtTimesheetTypes = new DataTable();
            dtTimesheetTypes.Columns.Add("Name");
            DataRow rtst;
            rtst = dtTimesheetTypes.NewRow();
            rtst["Name"] = "TRAVELLING";
            dtTimesheetTypes.Rows.Add(rtst);
            rtst = dtTimesheetTypes.NewRow();
            rtst["Name"] = "WORKING";
            dtTimesheetTypes.Rows.Add(rtst);
            rtst = dtTimesheetTypes.NewRow();
            rtst["Name"] = "LUNCH";
            dtTimesheetTypes.Rows.Add(rtst);
            rtst = dtTimesheetTypes.NewRow();
            rtst["Name"] = "NON-CHARGEABLE";
            dtTimesheetTypes.Rows.Add(rtst);
            var dtTimes = new DataTable();
            dtTimes.Columns.Add("Engineer");
            dtTimes.Columns.Add("Day");
            dtTimes.Columns.Add("Type");
            dtTimes.Columns.Add("Time"); // Minutes
            var dtStartEnd = new DataTable();
            dtStartEnd.Columns.Add("Engineer");
            dtStartEnd.Columns.Add("Day");
            dtStartEnd.Columns.Add("StartDay");
            dtStartEnd.Columns.Add("EndDay");
            var dtUnallocated = new DataTable();
            dtUnallocated.Columns.Add("Day");
            dtUnallocated.Columns.Add("Time");
            DataRow drUnallocated;
            for (int itm = 0, loopTo1 = ((DataView)dgTimesheets.DataSource).Count - 1; itm <= loopTo1; itm++)
            {
                dgTimesheets.CurrentRowIndex = itm;
                DataRow newRw;
                newRw = exportData.NewRow();

                // SUMMING UP
                var drRw = dtTimes.Select(Conversions.ToString(Conversions.ToString("Engineer='" + SelectedJobDataRow["Engineer"] + "' AND Day='" + Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy") + "' AND Type='") + SelectedJobDataRow["TimeSheetType"] + "'"));
                if (drRw.Length > 0)
                {
                    drRw[0]["Time"] = Convert.ToDecimal(drRw[0]["Time"]) + DateAndTime.DateDiff(DateInterval.Minute, Helper.MakeDateTimeValid(SelectedJobDataRow["StartDateTime"]), Helper.MakeDateTimeValid(SelectedJobDataRow["EndDateTime"]));
                }
                else
                {
                    DataRow nwRw;
                    nwRw = dtTimes.NewRow();
                    nwRw["Engineer"] = SelectedJobDataRow["Engineer"];
                    nwRw["Day"] = Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy");
                    nwRw["Type"] = SelectedJobDataRow["TimeSheetType"];
                    nwRw["Time"] = DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format(SelectedJobDataRow["EndDateTime"], "dd/MM/yyyy HH:mm")));
                    dtTimes.Rows.Add(nwRw);
                }

                DataRow nwExtra;
                nwExtra = dtTimes.NewRow();
                nwExtra["Engineer"] = SelectedJobDataRow["Engineer"];
                nwExtra["Day"] = Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy");
                nwExtra["Type"] = "Total Hours > 17:00";
                int dateDifference = 0;
                if (Conversions.ToBoolean(Conversions.ToDate(Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy") + " 17:00:00") < (DateTime)SelectedJobDataRow["StartDateTime"]))
                {
                    dateDifference = Conversions.ToInteger(DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(SelectedJobDataRow["StartDateTime"]), Conversions.ToDate(SelectedJobDataRow["EndDateTime"])));
                }
                else
                {
                    dateDifference = Conversions.ToInteger(DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy") + " 17:00:00"), Conversions.ToDate(SelectedJobDataRow["EndDateTime"])));
                }

                if (dateDifference > 0)
                {
                    nwExtra["Time"] = dateDifference;
                }
                else
                {
                    nwExtra["Time"] = 0;
                }

                dtTimes.Rows.Add(nwExtra);
                var drStartEnd = dtStartEnd.Select(Conversions.ToString("Engineer='" + SelectedJobDataRow["Engineer"] + "' AND Day='" + Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy") + "'"));
                if (drStartEnd.Length == 0)
                {
                    DataRow nwSE;
                    nwSE = dtStartEnd.NewRow();
                    nwSE["Engineer"] = SelectedJobDataRow["Engineer"];
                    nwSE["Day"] = Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy");
                    nwSE["StartDay"] = SelectedJobDataRow["StartDateTime"];
                    nwSE["EndDay"] = SelectedJobDataRow["EndDateTime"];
                    dtStartEnd.Rows.Add(nwSE);
                }
                else
                {
                    if (Convert.ToDateTime(drStartEnd[0]["StartDay"]) > Convert.ToDateTime(SelectedJobDataRow["StartDateTime"]))
                    {
                        drStartEnd[0]["StartDay"] = SelectedJobDataRow["StartDateTime"];
                    }

                    if (Convert.ToDateTime(drStartEnd[0]["EndDay"]) < Convert.ToDateTime(SelectedJobDataRow["EndDateTime"]))
                    {
                        drStartEnd[0]["EndDay"] = SelectedJobDataRow["EndDateTime"];
                    }
                }

                // ------------------------------------

                if (i == 2)
                {
                    // START BY PUTTING ENGINEER
                    extraRw = exportData.NewRow();
                    extraRw["JobNumber"] = SelectedJobDataRow["Engineer"];
                    exportData.Rows.Add(extraRw);
                    i += 1;

                    // SPACE
                    extraRw = exportData.NewRow();
                    exportData.Rows.Add(extraRw);
                    i += 1;

                    // DATE
                    extraRw = exportData.NewRow();
                    extraRw["JobNumber"] = Strings.Format(SelectedJobDataRow["StartDateTime"], "dddd");
                    extraRw["Site"] = Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy");
                    exportData.Rows.Add(extraRw);
                    i += 1;
                    lastDay = Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy");
                    lastEngineer = Conversions.ToString(SelectedJobDataRow["Engineer"]);
                }

                if ((lastDay ?? "") != (Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy") ?? ""))
                {
                    extraRw = exportData.NewRow();
                    exportData.Rows.Add(extraRw);
                    i += 1;
                    lastDay = Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy");
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(lastEngineer, SelectedJobDataRow["Engineer"], false)))
                    {
                        // DATE
                        extraRw = exportData.NewRow();
                        extraRw["JobNumber"] = Strings.Format(SelectedJobDataRow["StartDateTime"], "dddd");
                        extraRw["Site"] = Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy");
                        exportData.Rows.Add(extraRw);
                        i += 1;
                    }
                }

                if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(lastEngineer, SelectedJobDataRow["Engineer"], false)))
                {
                    extraRw = exportData.NewRow();
                    exportData.Rows.Add(extraRw);
                    i += 1;
                    extraRw = exportData.NewRow();
                    extraRw["JobNumber"] = "SUMMARY";
                    cnt = 3;
                    foreach (DataRow theDay in theDays.Rows)
                    {
                        extraRw[cnt] = Strings.Format(theDay["Day"], "dd/MM");
                        cnt += 1;
                    }

                    exportData.Rows.Add(extraRw);
                    i += 1;
                    foreach (DataRow dr in dtTimesheetTypes.Rows)
                    {
                        extraRw = exportData.NewRow();
                        extraRw["JobNumber"] = dr["Name"].ToString().ToUpper();
                        cnt = 3;
                        foreach (DataRow theDay in theDays.Rows)
                        {
                            rSel = dtTimes.Select("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "' AND Engineer='" + lastEngineer + "' AND Type='" + dr["Name"].ToString() + "'");
                            if (rSel.Length > 0)
                            {
                                extraRw[cnt] = formatTime(Conversions.ToInteger(rSel[0]["Time"]));
                            }
                            else
                            {
                                extraRw[cnt] = formatTime(0);
                            }

                            cnt += 1;
                        }

                        exportData.Rows.Add(extraRw);
                        i += 1;
                    }

                    extraRw = exportData.NewRow();
                    extraRw["JobNumber"] = "Unaccounted".ToUpper();
                    cnt = 3;
                    foreach (DataRow theDay in theDays.Rows)
                    {
                        var drUnAl = dtStartEnd.Select("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "' AND Engineer='" + lastEngineer + "'");
                        if (drUnAl.Length > 0)
                        {
                            var drAl = dtTimes.Select("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "' AND Engineer='" + lastEngineer + "'");
                            if (drAl.Length > 0)
                            {
                                int allTotal = 0;
                                foreach (DataRow al in drAl)
                                {
                                    if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(al["Type"], "Total Hours > 17:00", false)))
                                    {
                                        allTotal += Convert.ToInt32(al["Time"]);
                                    }
                                }

                                extraRw[cnt] = formatTime((int)(DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format(Conversions.ToDate(drUnAl[0]["StartDay"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format(Conversions.ToDate(drUnAl[0]["EndDay"]), "dd/MM/yyyy HH:mm"))) - allTotal));
                                drUnallocated = dtUnallocated.NewRow();
                                drUnallocated["Day"] = Strings.Format(theDay["Day"], "dd/MM/yyyy");
                                drUnallocated["Time"] = DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format(Conversions.ToDate(drUnAl[0]["StartDay"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format(Conversions.ToDate(drUnAl[0]["EndDay"]), "dd/MM/yyyy HH:mm"))) - allTotal;
                                dtUnallocated.Rows.Add(drUnallocated);
                            }
                            else
                            {
                                extraRw[cnt] = formatTime(Conversions.ToInteger(DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format(Conversions.ToDate(drUnAl[0]["StartDay"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format(Conversions.ToDate(drUnAl[0]["EndDay"]), "dd/MM/yyyy HH:mm")))));
                            }
                        }
                        else
                        {
                            extraRw[cnt] = formatTime(0);
                        }

                        cnt += 1;
                    }

                    exportData.Rows.Add(extraRw);
                    i += 1;
                    extraRw = exportData.NewRow();
                    extraRw["JobNumber"] = "Total Hours > 17:00".ToUpper();
                    cnt = 3;
                    foreach (DataRow theDay in theDays.Rows)
                    {
                        rSel = dtTimes.Select("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "' AND Engineer='" + lastEngineer + "' AND Type='Total Hours > 17:00'");
                        if (rSel.Length > 0)
                        {
                            int total = 0;
                            for (int l = 0, loopTo2 = rSel.Length - 1; l <= loopTo2; l++)
                                total += Convert.ToInt32(rSel[l]["Time"]);

                            extraRw[cnt] += formatTime(total);
                        }
                        else
                        {
                            extraRw[cnt] = formatTime(0);
                        }

                        cnt += 1;
                    }

                    exportData.Rows.Add(extraRw);
                    i += 1;
                    extraRw = exportData.NewRow();
                    exportData.Rows.Add(extraRw);
                    i += 1;
                    extraRw = exportData.NewRow();
                    exportData.Rows.Add(extraRw);
                    i += 1;
                    lastEngineer = Conversions.ToString(SelectedJobDataRow["Engineer"]);

                    // PUTTING ENGINEER
                    extraRw = exportData.NewRow();
                    extraRw["JobNumber"] = SelectedJobDataRow["Engineer"];
                    exportData.Rows.Add(extraRw);
                    i += 1;
                    // SPACE
                    extraRw = exportData.NewRow();
                    exportData.Rows.Add(extraRw);
                    i += 1;

                    // DATE
                    extraRw = exportData.NewRow();
                    extraRw["JobNumber"] = Strings.Format(SelectedJobDataRow["StartDateTime"], "dddd");
                    extraRw["Site"] = Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy");
                    exportData.Rows.Add(extraRw);
                    i += 1;
                }

                newRw["JobNumber"] = SelectedJobDataRow["JobNumber"];
                newRw["Site"] = SelectedJobDataRow["Site"];
                newRw["Visit Details"] = SelectedJobDataRow["VisitDetails"];
                newRw["Notes From Engineer"] = SelectedJobDataRow["NotesFromEngineer"];
                newRw["Start Time"] = Strings.Format(SelectedJobDataRow["StartDateTime"], "HH:mm");
                newRw["End Time"] = Strings.Format(SelectedJobDataRow["EndDateTime"], "HH:mm");
                newRw["Timesheet Type"] = SelectedJobDataRow["TimeSheetType"];
                newRw["Time"] = SelectedJobDataRow["Duration"];
                exportData.Rows.Add(newRw);
                dgTimesheets.UnSelect(itm);
                i += 1;
            }

            extraRw = exportData.NewRow();
            exportData.Rows.Add(extraRw);
            i += 1;
            extraRw = exportData.NewRow();
            extraRw["JobNumber"] = "SUMMARY";
            cnt = 3;
            foreach (DataRow theDay in theDays.Rows)
            {
                extraRw[cnt] = Strings.Format(theDay["Day"], "dd/MM");
                cnt += 1;
            }

            exportData.Rows.Add(extraRw);
            i += 1;
            foreach (DataRow dr in dtTimesheetTypes.Rows)
            {
                extraRw = exportData.NewRow();
                extraRw["JobNumber"] = dr["Name"].ToString().ToUpper();
                cnt = 3;
                foreach (DataRow theDay in theDays.Rows)
                {
                    rSel = dtTimes.Select(Conversions.ToString("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "' AND Engineer='" + SelectedJobDataRow["Engineer"] + "' AND Type='" + dr["Name"].ToString() + "'"));
                    if (rSel.Length > 0)
                    {
                        extraRw[cnt] = formatTime(Conversions.ToInteger(rSel[0]["Time"]));
                    }
                    else
                    {
                        extraRw[cnt] = formatTime(0);
                    }

                    cnt += 1;
                }

                exportData.Rows.Add(extraRw);
                i += 1;
            }

            extraRw = exportData.NewRow();
            extraRw["JobNumber"] = "Unaccounted".ToUpper();
            cnt = 3;
            foreach (DataRow theDay in theDays.Rows)
            {
                var drUnAl = dtStartEnd.Select(Conversions.ToString("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "' AND Engineer='" + SelectedJobDataRow["Engineer"] + "'"));
                if (drUnAl.Length > 0)
                {
                    var drAl = dtTimes.Select(Conversions.ToString("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "' AND Engineer='" + SelectedJobDataRow["Engineer"] + "'"));
                    if (drAl.Length > 0)
                    {
                        int allTotal = 0;
                        foreach (DataRow al in drAl)
                        {
                            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(al["Type"], "Total Hours > 17:00", false)))
                            {
                                allTotal += Convert.ToInt32(al["Time"]);
                            }
                        }

                        extraRw[cnt] = formatTime((int)(DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format(Conversions.ToDate(drUnAl[0]["StartDay"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format(Conversions.ToDate(drUnAl[0]["EndDay"]), "dd/MM/yyyy HH:mm"))) - allTotal));
                        drUnallocated = dtUnallocated.NewRow();
                        drUnallocated["Day"] = Strings.Format(theDay["Day"], "dd/MM/yyyy");
                        drUnallocated["Time"] = DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format(Conversions.ToDate(drUnAl[0]["StartDay"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format(Conversions.ToDate(drUnAl[0]["EndDay"]), "dd/MM/yyyy HH:mm"))) - allTotal;
                        dtUnallocated.Rows.Add(drUnallocated);
                    }
                    else
                    {
                        extraRw[cnt] = DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format(Conversions.ToDate(drUnAl[0]["StartDay"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format(Conversions.ToDate(drUnAl[0]["EndDay"]), "dd/MM/yyyy HH:mm")));
                    }
                }
                else
                {
                    extraRw[cnt] = formatTime(0);
                }

                cnt += 1;
            }

            exportData.Rows.Add(extraRw);
            i += 1;
            extraRw = exportData.NewRow();
            extraRw["JobNumber"] = "Total Hours > 17:00".ToUpper();
            cnt = 3;
            foreach (DataRow theDay in theDays.Rows)
            {
                rSel = dtTimes.Select(Conversions.ToString("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "' AND Engineer='" + SelectedJobDataRow["Engineer"] + "' AND Type='Total Hours > 17:00'"));
                if (rSel.Length > 0)
                {
                    int total = 0;
                    for (int l = 0, loopTo3 = rSel.Length - 1; l <= loopTo3; l++)
                        total += Convert.ToInt32(rSel[l]["Time"]);
                    extraRw[cnt] += formatTime(total);
                }
                else
                {
                    extraRw[cnt] = formatTime(0);
                }

                cnt += 1;
            }

            exportData.Rows.Add(extraRw);
            i += 1;
            extraRw = exportData.NewRow();
            exportData.Rows.Add(extraRw);
            i += 1;
            extraRw = exportData.NewRow();
            exportData.Rows.Add(extraRw);
            i += 1;
            extraRw = exportData.NewRow();
            exportData.Rows.Add(extraRw);
            i += 1;
            extraRw = exportData.NewRow();
            extraRw["JobNumber"] = "MASTER SUMMARY";
            cnt = 3;
            foreach (DataRow theDay in theDays.Rows)
            {
                extraRw[cnt] = Strings.Format(theDay["Day"], "dd/MM");
                cnt += 1;
            }

            exportData.Rows.Add(extraRw);
            i += 1;
            foreach (DataRow dr in dtTimesheetTypes.Rows)
            {
                extraRw = exportData.NewRow();
                extraRw["JobNumber"] = dr["Name"].ToString().ToUpper();
                cnt = 3;
                foreach (DataRow theDay in theDays.Rows)
                {
                    rSel = dtTimes.Select("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "' AND Type='" + dr["Name"].ToString() + "'");
                    if (rSel.Length > 0)
                    {
                        int total = 0;
                        for (int l = 0, loopTo4 = rSel.Length - 1; l <= loopTo4; l++)
                            total += Convert.ToInt32(rSel[l]["Time"]);
                        extraRw[cnt] = formatTime(total);
                    }
                    else
                    {
                        extraRw[cnt] = formatTime(0);
                    }

                    cnt += 1;
                }

                exportData.Rows.Add(extraRw);
                i += 1;
            }

            extraRw = exportData.NewRow();
            extraRw["JobNumber"] = "Unaccounted".ToUpper();
            cnt = 3;
            foreach (DataRow theDay in theDays.Rows)
            {
                int totalUnallocated = 0;
                var drDayUnallocated = dtUnallocated.Select("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "'");
                for (int b = 0, loopTo5 = drDayUnallocated.Length - 1; b <= loopTo5; b++)
                    totalUnallocated += Convert.ToInt32(drDayUnallocated[b]["Time"]);
                extraRw[cnt] = formatTime(totalUnallocated);
                cnt += 1;
            }

            exportData.Rows.Add(extraRw);
            i += 1;
            extraRw = exportData.NewRow();
            extraRw["JobNumber"] = "Total Hours > 17:00".ToUpper();
            cnt = 3;
            foreach (DataRow theDay in theDays.Rows)
            {
                rSel = dtTimes.Select("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "' AND Type='Total Hours > 17:00'");
                if (rSel.Length > 0)
                {
                    int total = 0;
                    for (int l = 0, loopTo6 = rSel.Length - 1; l <= loopTo6; l++)
                        total += Convert.ToInt32(rSel[l]["Time"]);
                    extraRw[cnt] = formatTime(total);
                }
                else
                {
                    extraRw[cnt] = formatTime(0);
                }

                cnt += 1;
            }

            exportData.Rows.Add(extraRw);
            i += 1;
            extraRw = exportData.NewRow();
            exportData.Rows.Add(extraRw);
            i += 1;
            extraRw = exportData.NewRow();
            exportData.Rows.Add(extraRw);
            i += 1;
            Entity.Sys.ExportHelper.Export(exportData, "Timesheet " + Strings.Format(dtpFrom.Value, "dd-MM-yy") + " - " + Strings.Format(dtpTo.Value, "dd-MM-yy"), Entity.Sys.Enums.ExportType.XLS);
        }

        public void ExportSummary(string Department = null)
        {
            if (TimesheetsDataview.Count <= 0)
            {
                App.ShowMessage("No engineers are being displayed, please change / run filter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataRow[] rSel;
            int cnt = 0;
            var exportData = new DataTable();
            exportData.Columns.Add("Engineer");
            exportData.Columns.Add("Travelling");
            exportData.Columns.Add("Working");
            exportData.Columns.Add("Lunch");
            exportData.Columns.Add("Non Chargeable");
            exportData.Columns.Add("Unallocated");
            exportData.Columns.Add("Total Hours > 17:00");
            var theDays = new DataTable();
            theDays.Columns.Add("Day", typeof(DateTime));
            var dates = TimesheetsDataview.Table.Select("", "StartDateTime");
            foreach (DataRow d in dates)
            {
                if (theDays.Select("Day='" + Strings.Format(d["StartDateTime"], "dd/MMM/yyyy") + "'").Length == 0)
                {
                    DataRow dd;
                    dd = theDays.NewRow();
                    dd["Day"] = Strings.Format(d["StartDateTime"], "dd/MMM/yyyy");
                    theDays.Rows.Add(dd);
                }
            }

            if (theDays.Rows.Count > 5)
            {
                for (int datecol = 6, loopTo = theDays.Rows.Count; datecol <= loopTo; datecol++)
                    exportData.Columns.Add(datecol.ToString());
            }

            int i = 2;
            string lastDay = "";
            string lastEngineer = "";
            var extraRw = default(DataRow);
            var dtTimesheetTypes = new DataTable();
            dtTimesheetTypes.Columns.Add("Name");
            DataRow rtst;
            rtst = dtTimesheetTypes.NewRow();
            rtst["Name"] = "TRAVELLING";
            dtTimesheetTypes.Rows.Add(rtst);
            rtst = dtTimesheetTypes.NewRow();
            rtst["Name"] = "WORKING";
            dtTimesheetTypes.Rows.Add(rtst);
            rtst = dtTimesheetTypes.NewRow();
            rtst["Name"] = "LUNCH";
            dtTimesheetTypes.Rows.Add(rtst);
            rtst = dtTimesheetTypes.NewRow();
            rtst["Name"] = "NON-CHARGEABLE";
            dtTimesheetTypes.Rows.Add(rtst);
            var dtTimes = new DataTable();
            dtTimes.Columns.Add("Engineer");
            dtTimes.Columns.Add("Day");
            dtTimes.Columns.Add("Type");
            dtTimes.Columns.Add("Time"); // Minutes
            var dtStartEnd = new DataTable();
            dtStartEnd.Columns.Add("Engineer");
            dtStartEnd.Columns.Add("Day");
            dtStartEnd.Columns.Add("StartDay");
            dtStartEnd.Columns.Add("EndDay");
            var dtUnallocated = new DataTable();
            dtUnallocated.Columns.Add("Day");
            dtUnallocated.Columns.Add("Time");
            DataRow drUnallocated;
            int MinsTally = 0;
            for (int itm = 0, loopTo1 = ((DataView)dgTimesheets.DataSource).Count - 1; itm <= loopTo1; itm++)
            {
                dgTimesheets.CurrentRowIndex = itm;
                DataRow newRw;
                newRw = exportData.NewRow();

                // SUMMING UP
                var drRw = dtTimes.Select(Conversions.ToString(Conversions.ToString("Engineer='" + SelectedJobDataRow["Engineer"] + "' AND Day='" + Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy") + "' AND Type='") + SelectedJobDataRow["TimeSheetType"] + "'"));
                if (drRw.Length > 0)
                {
                    drRw[0]["Time"] = Convert.ToDecimal(drRw[0]["Time"]) + DateAndTime.DateDiff(DateInterval.Minute, Helper.MakeDateTimeValid(SelectedJobDataRow["StartDateTime"]), Helper.MakeDateTimeValid(SelectedJobDataRow["EndDateTime"]));
                }
                else
                {
                    DataRow nwRw;
                    nwRw = dtTimes.NewRow();
                    nwRw["Engineer"] = SelectedJobDataRow["Engineer"];
                    nwRw["Day"] = Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy");
                    nwRw["Type"] = SelectedJobDataRow["TimeSheetType"];
                    nwRw["Time"] = DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format(SelectedJobDataRow["EndDateTime"], "dd/MM/yyyy HH:mm")));
                    dtTimes.Rows.Add(nwRw);
                }

                DataRow nwExtra;
                nwExtra = dtTimes.NewRow();
                nwExtra["Engineer"] = SelectedJobDataRow["Engineer"];
                nwExtra["Day"] = Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy");
                nwExtra["Type"] = "Total Hours > 17:00";
                int dateDifference = 0;
                if (Conversions.ToBoolean(Conversions.ToDate(Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy") + " 17:00:00") < (DateTime)SelectedJobDataRow["StartDateTime"]))
                {
                    dateDifference = Conversions.ToInteger(DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(SelectedJobDataRow["StartDateTime"]), Conversions.ToDate(SelectedJobDataRow["EndDateTime"])));
                }
                else
                {
                    dateDifference = Conversions.ToInteger(DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy") + " 17:00:00"), Conversions.ToDate(SelectedJobDataRow["EndDateTime"])));
                }

                if (dateDifference > 0)
                {
                    nwExtra["Time"] = dateDifference;
                }
                else
                {
                    nwExtra["Time"] = 0;
                }

                dtTimes.Rows.Add(nwExtra);
                var drStartEnd = dtStartEnd.Select(Conversions.ToString("Engineer='" + SelectedJobDataRow["Engineer"] + "' AND Day='" + Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy") + "'"));
                if (drStartEnd.Length == 0)
                {
                    DataRow nwSE;
                    nwSE = dtStartEnd.NewRow();
                    nwSE["Engineer"] = SelectedJobDataRow["Engineer"];
                    nwSE["Day"] = Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy");
                    nwSE["StartDay"] = SelectedJobDataRow["StartDateTime"];
                    nwSE["EndDay"] = SelectedJobDataRow["EndDateTime"];
                    dtStartEnd.Rows.Add(nwSE);
                }
                else
                {
                    if (Convert.ToDateTime(drStartEnd[0]["StartDay"]) > Convert.ToDateTime(SelectedJobDataRow["StartDateTime"]))
                    {
                        drStartEnd[0]["StartDay"] = SelectedJobDataRow["StartDateTime"];
                    }

                    if (Convert.ToDateTime(drStartEnd[0]["EndDay"]) < Convert.ToDateTime(SelectedJobDataRow["EndDateTime"]))
                    {
                        drStartEnd[0]["EndDay"] = SelectedJobDataRow["EndDateTime"];
                    }
                }

                // ------------------------------------

                if (i == 2)
                {
                    // START BY PUTTING ENGINEER
                    extraRw = exportData.NewRow();
                    extraRw["Engineer"] = SelectedJobDataRow["Engineer"];
                    lastDay = Strings.Format(SelectedJobDataRow["StartDateTime"], "dd/MM/yyyy");
                    lastEngineer = Conversions.ToString(SelectedJobDataRow["Engineer"]);
                }

                if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(lastEngineer, SelectedJobDataRow["Engineer"], false)))
                {
                    foreach (DataRow dr in dtTimesheetTypes.Rows)
                    {
                        MinsTally = 0;
                        foreach (DataRow theDay in theDays.Rows)
                        {
                            rSel = dtTimes.Select("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "' AND Engineer='" + lastEngineer + "' AND Type='" + dr["Name"].ToString() + "'");
                            if (rSel.Length > 0)
                            {
                                MinsTally += Convert.ToInt32(rSel[0]["Time"]);
                            }
                        }

                        extraRw[cnt] = MinsTally;
                        cnt += 1;
                    }

                    MinsTally = 0;
                    foreach (DataRow theDay in theDays.Rows)
                    {
                        var drUnAl = dtStartEnd.Select("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "' AND Engineer='" + lastEngineer + "'");
                        if (drUnAl.Length > 0)
                        {
                            var drAl = dtTimes.Select("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "' AND Engineer='" + lastEngineer + "'");
                            if (drAl.Length > 0)
                            {
                                int allTotal = 0;
                                foreach (DataRow al in drAl)
                                {
                                    if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(al["Type"], "Total Hours > 17:00", false)))
                                    {
                                        allTotal += Convert.ToInt32(al["Time"]);
                                    }
                                }

                                MinsTally += (int)DateAndTime.DateDiff(DateInterval.Minute, Helper.MakeDateTimeValid(drUnAl[0]["StartDay"]), Helper.MakeDateTimeValid(drUnAl[0]["EndDay"])) - allTotal;
                                drUnallocated = dtUnallocated.NewRow();
                                drUnallocated["Day"] = Strings.Format(theDay["Day"], "dd/MM/yyyy");
                                drUnallocated["Time"] = DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format(Conversions.ToDate(drUnAl[0]["StartDay"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format(Conversions.ToDate(drUnAl[0]["EndDay"]), "dd/MM/yyyy HH:mm"))) - allTotal;
                                dtUnallocated.Rows.Add(drUnallocated);
                            }
                            else
                            {
                                MinsTally += (int)DateAndTime.DateDiff(DateInterval.Minute, Helper.MakeDateTimeValid(drUnAl[0]["StartDay"]), Helper.MakeDateTimeValid(drUnAl[0]["EndDay"]));
                            }
                        }
                    }

                    extraRw[cnt] = MinsTally;
                    cnt += 1;
                    MinsTally = 0;
                    foreach (DataRow theDay in theDays.Rows)
                    {
                        rSel = dtTimes.Select("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "' AND Engineer='" + lastEngineer + "' AND Type='Total Hours > 17:00'");
                        if (rSel.Length > 0)
                        {
                            int total = 0;
                            for (int l = 0, loopTo2 = rSel.Length - 1; l <= loopTo2; l++)
                                total += Convert.ToInt32(rSel[l]["Time"]);
                            MinsTally += total;
                        }
                    }

                    extraRw[cnt] = MinsTally;
                    exportData.Rows.Add(extraRw);
                    i += 1;
                    cnt += 1;
                    lastEngineer = Conversions.ToString(SelectedJobDataRow["Engineer"]);

                    // PUTTING ENGINEER
                    extraRw = exportData.NewRow();
                    extraRw["Engineer"] = SelectedJobDataRow["Engineer"];
                }

                dgTimesheets.UnSelect(itm);
                i += 1;
            }

            cnt = 1;
            foreach (DataRow dr in dtTimesheetTypes.Rows)
            {
                MinsTally = 0;
                foreach (DataRow theDay in theDays.Rows)
                {
                    rSel = dtTimes.Select(Conversions.ToString("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "' AND Engineer='" + SelectedJobDataRow["Engineer"] + "' AND Type='" + dr["Name"].ToString() + "'"));
                    if (rSel.Length > 0)
                    {
                        MinsTally += Convert.ToInt32(rSel[0]["Time"]);
                    }
                }

                extraRw[cnt] = MinsTally;
                cnt += 1;
            }

            MinsTally = 0;
            foreach (DataRow theDay in theDays.Rows)
            {
                var drUnAl = dtStartEnd.Select(Conversions.ToString("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "' AND Engineer='" + SelectedJobDataRow["Engineer"] + "'"));
                if (drUnAl.Length > 0)
                {
                    var drAl = dtTimes.Select(Conversions.ToString("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "' AND Engineer='" + SelectedJobDataRow["Engineer"] + "'"));
                    if (drAl.Length > 0)
                    {
                        int allTotal = 0;
                        foreach (DataRow al in drAl)
                        {
                            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(al["Type"], "Total Hours > 17:00", false)))
                            {
                                allTotal += Convert.ToInt32(al["Time"]);
                            }
                        }

                        MinsTally += (int)DateAndTime.DateDiff(DateInterval.Minute, Helper.MakeDateTimeValid(drUnAl[0]["StartDay"]), Helper.MakeDateTimeValid(drUnAl[0]["EndDay"])) - allTotal;
                        drUnallocated = dtUnallocated.NewRow();
                        drUnallocated["Day"] = Strings.Format(theDay["Day"], "dd/MM/yyyy");
                        drUnallocated["Time"] = DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(Strings.Format(Conversions.ToDate(drUnAl[0]["StartDay"]), "dd/MM/yyyy HH:mm")), Conversions.ToDate(Strings.Format(Conversions.ToDate(drUnAl[0]["EndDay"]), "dd/MM/yyyy HH:mm"))) - allTotal;
                        dtUnallocated.Rows.Add(drUnallocated);
                    }
                    else
                    {
                        MinsTally += (int)DateAndTime.DateDiff(DateInterval.Minute, Helper.MakeDateTimeValid(drUnAl[0]["StartDay"]), Helper.MakeDateTimeValid(drUnAl[0]["EndDay"]));
                    }
                }
            }

            extraRw[cnt] = MinsTally;
            cnt += 1;
            MinsTally = 0;
            foreach (DataRow theDay in theDays.Rows)
            {
                rSel = dtTimes.Select(Conversions.ToString("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "' AND Engineer='" + SelectedJobDataRow["Engineer"] + "' AND Type='Total Hours > 17:00'"));
                if (rSel.Length > 0)
                {
                    int total = 0;
                    for (int l = 0, loopTo3 = rSel.Length - 1; l <= loopTo3; l++)
                        total += Convert.ToInt32(rSel[l]["Time"]);
                    MinsTally += total;
                }
            }

            extraRw[cnt] = MinsTally;
            exportData.Rows.Add(extraRw);
            i += 1;
            cnt += 1;
            extraRw = exportData.NewRow();
            extraRw["Engineer"] = "MASTER SUMMARY";
            cnt = 1;
            foreach (DataRow dr in dtTimesheetTypes.Rows)
            {
                MinsTally = 0;
                foreach (DataRow theDay in theDays.Rows)
                {
                    rSel = dtTimes.Select("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "' AND Type='" + dr["Name"].ToString() + "'");
                    if (rSel.Length > 0)
                    {
                        int total = 0;
                        for (int l = 0, loopTo4 = rSel.Length - 1; l <= loopTo4; l++)
                            total += Convert.ToInt32(rSel[l]["Time"]);
                        MinsTally += total;
                    }
                }

                extraRw[cnt] = MinsTally;
                cnt += 1;
            }

            MinsTally = 0;
            foreach (DataRow theDay in theDays.Rows)
            {
                int totalUnallocated = 0;
                var drDayUnallocated = dtUnallocated.Select("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "'");
                for (int b = 0, loopTo5 = drDayUnallocated.Length - 1; b <= loopTo5; b++)
                    totalUnallocated += Convert.ToInt32(drDayUnallocated[b]["Time"]);
                MinsTally += totalUnallocated;
            }

            extraRw[cnt] = MinsTally;
            cnt += 1;
            MinsTally = 0;
            foreach (DataRow theDay in theDays.Rows)
            {
                rSel = dtTimes.Select("Day='" + Strings.Format(theDay["Day"], "dd/MM/yyyy") + "' AND Type='Total Hours > 17:00'");
                if (rSel.Length > 0)
                {
                    int total = 0;
                    for (int l = 0, loopTo6 = rSel.Length - 1; l <= loopTo6; l++)
                        total += Convert.ToInt32(rSel[l]["Time"]);
                    MinsTally += total;
                }
            }

            extraRw[cnt] = MinsTally;
            exportData.Rows.Add(extraRw);
            i += 1;
            cnt += 1;
            extraRw = exportData.NewRow();
            exportData.Rows.Add(extraRw);
            i += 1;
            extraRw = exportData.NewRow();
            exportData.Rows.Add(extraRw);
            i += 1;
            Entity.Sys.ExportHelper.Export(exportData, Strings.Format(dtpFrom.Value, "dd-MM-yy") + " - " + Strings.Format(dtpTo.Value, "dd-MM-yy"), Entity.Sys.Enums.ExportType.CSV);
        }

        private string formatTime(int Minutes)
        {
            if (Minutes < 0)
            {
                return "00:00";
            }

            if (Minutes % 60 < 10)
            {
                return Math.Floor(Minutes / (decimal)60) + ":0" + Minutes % 60;
            }
            else
            {
                return Math.Floor(Minutes / (decimal)60) + ":" + Minutes % 60;
            }
        }
    }
}