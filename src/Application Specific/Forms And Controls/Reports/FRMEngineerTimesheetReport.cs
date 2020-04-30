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

        internal Label Label9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label9 != null)
                {
                }

                _Label9 = value;
                if (_Label9 != null)
                {
                }
            }
        }

        private Label _Label8;

        internal Label Label8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label8 != null)
                {
                }

                _Label8 = value;
                if (_Label8 != null)
                {
                }
            }
        }

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

        internal Button btnExport
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnExport;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnExport != null)
                {
                    _btnExport.Click -= btnExport_Click;
                }

                _btnExport = value;
                if (_btnExport != null)
                {
                    _btnExport.Click += btnExport_Click;
                }
            }
        }

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

        internal Button btnRunReport
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRunReport;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRunReport != null)
                {
                    _btnRunReport.Click -= btnRunReport_Click;
                }

                _btnRunReport = value;
                if (_btnRunReport != null)
                {
                    _btnRunReport.Click += btnRunReport_Click;
                }
            }
        }

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

        internal Button btnClearAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClearAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClearAll != null)
                {
                    _btnClearAll.Click -= btnClearAll_Click;
                }

                _btnClearAll = value;
                if (_btnClearAll != null)
                {
                    _btnClearAll.Click += btnClearAll_Click;
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

        private Button _btnSummary;

        internal Button btnSummary
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSummary;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSummary != null)
                {
                    _btnSummary.Click -= btnSummary_Click;
                }

                _btnSummary = value;
                if (_btnSummary != null)
                {
                    _btnSummary.Click += btnSummary_Click;
                }
            }
        }

        private Label _lblDept;

        internal Label lblDept
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDept;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDept != null)
                {
                }

                _lblDept = value;
                if (_lblDept != null)
                {
                }
            }
        }

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
            _grpJobs = new GroupBox();
            _dgTimesheets = new DataGrid();
            _btnExport = new Button();
            _btnExport.Click += new EventHandler(btnExport_Click);
            _grpFilter = new GroupBox();
            _cboDept = new ComboBox();
            _cboDept.SelectedIndexChanged += new EventHandler(cboDept_Changed);
            _lblDept = new Label();
            _btnClearAll = new Button();
            _btnClearAll.Click += new EventHandler(btnClearAll_Click);
            _btnSelectAll = new Button();
            _btnSelectAll.Click += new EventHandler(btnSelectAll_Click);
            _dgEngineers = new DataGrid();
            _dgEngineers.Click += new EventHandler(dgEngineers_Clicks);
            _dgEngineers.DoubleClick += new EventHandler(dgEngineers_Clicks);
            _dgEngineers.Click += new EventHandler(dgEngineers_Clicks);
            _dgEngineers.DoubleClick += new EventHandler(dgEngineers_Clicks);
            _btnRunReport = new Button();
            _btnRunReport.Click += new EventHandler(btnRunReport_Click);
            _Label4 = new Label();
            _dtpTo = new DateTimePicker();
            _dtpFrom = new DateTimePicker();
            _txtJobNumber = new TextBox();
            _Label9 = new Label();
            _Label8 = new Label();
            _Label6 = new Label();
            _btnReset = new Button();
            _btnReset.Click += new EventHandler(btnReset_Click);
            _btnSummary = new Button();
            _btnSummary.Click += new EventHandler(btnSummary_Click);
            _grpJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgTimesheets).BeginInit();
            _grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgEngineers).BeginInit();
            SuspendLayout();
            //
            // grpJobs
            //
            _grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpJobs.Controls.Add(_dgTimesheets);
            _grpJobs.Location = new Point(8, 239);
            _grpJobs.Name = "grpJobs";
            _grpJobs.Size = new Size(844, 409);
            _grpJobs.TabIndex = 2;
            _grpJobs.TabStop = false;
            _grpJobs.Text = "Double Click To View / Edit";
            //
            // dgTimesheets
            //
            _dgTimesheets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgTimesheets.DataMember = "";
            _dgTimesheets.HeaderForeColor = SystemColors.ControlText;
            _dgTimesheets.Location = new Point(8, 19);
            _dgTimesheets.Name = "dgTimesheets";
            _dgTimesheets.Size = new Size(828, 382);
            _dgTimesheets.TabIndex = 14;
            //
            // btnExport
            //
            _btnExport.AccessibleDescription = "Export Job List To Excel";
            _btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnExport.Location = new Point(8, 656);
            _btnExport.Name = "btnExport";
            _btnExport.Size = new Size(56, 23);
            _btnExport.TabIndex = 15;
            _btnExport.Text = "Export";
            //
            // grpFilter
            //
            _grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpFilter.Controls.Add(_cboDept);
            _grpFilter.Controls.Add(_lblDept);
            _grpFilter.Controls.Add(_btnClearAll);
            _grpFilter.Controls.Add(_btnSelectAll);
            _grpFilter.Controls.Add(_dgEngineers);
            _grpFilter.Controls.Add(_btnRunReport);
            _grpFilter.Controls.Add(_Label4);
            _grpFilter.Controls.Add(_dtpTo);
            _grpFilter.Controls.Add(_dtpFrom);
            _grpFilter.Controls.Add(_txtJobNumber);
            _grpFilter.Controls.Add(_Label9);
            _grpFilter.Controls.Add(_Label8);
            _grpFilter.Controls.Add(_Label6);
            _grpFilter.Location = new Point(8, 32);
            _grpFilter.Name = "grpFilter";
            _grpFilter.Size = new Size(844, 201);
            _grpFilter.TabIndex = 1;
            _grpFilter.TabStop = false;
            _grpFilter.Text = "Filter";
            //
            // cboDept
            //
            _cboDept.Location = new Point(367, 35);
            _cboDept.Name = "cboDept";
            _cboDept.Size = new Size(126, 21);
            _cboDept.TabIndex = 30;
            //
            // lblDept
            //
            _lblDept.BackColor = Color.White;
            _lblDept.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblDept.Location = new Point(364, 16);
            _lblDept.Name = "lblDept";
            _lblDept.Size = new Size(103, 16);
            _lblDept.TabIndex = 29;
            _lblDept.Text = "Department";
            //
            // btnClearAll
            //
            _btnClearAll.Font = new Font("Verdana", 8.0F);
            _btnClearAll.Location = new Point(148, 11);
            _btnClearAll.Name = "btnClearAll";
            _btnClearAll.Size = new Size(64, 23);
            _btnClearAll.TabIndex = 28;
            _btnClearAll.Text = "Clear All";
            _btnClearAll.UseVisualStyleBackColor = true;
            //
            // btnSelectAll
            //
            _btnSelectAll.Font = new Font("Verdana", 8.0F);
            _btnSelectAll.Location = new Point(78, 11);
            _btnSelectAll.Name = "btnSelectAll";
            _btnSelectAll.Size = new Size(64, 23);
            _btnSelectAll.TabIndex = 27;
            _btnSelectAll.Text = "Select All";
            _btnSelectAll.UseVisualStyleBackColor = true;
            //
            // dgEngineers
            //
            _dgEngineers.AllowNavigation = false;
            _dgEngineers.AlternatingBackColor = Color.GhostWhite;
            _dgEngineers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _dgEngineers.BackgroundColor = Color.White;
            _dgEngineers.BorderStyle = BorderStyle.FixedSingle;
            _dgEngineers.CaptionBackColor = Color.RoyalBlue;
            _dgEngineers.CaptionForeColor = Color.White;
            _dgEngineers.CaptionText = "Engineers";
            _dgEngineers.CaptionVisible = false;
            _dgEngineers.DataMember = "";
            _dgEngineers.Font = new Font("Verdana", 8.0F);
            _dgEngineers.ForeColor = Color.MidnightBlue;
            _dgEngineers.GridLineColor = Color.RoyalBlue;
            _dgEngineers.HeaderBackColor = Color.MidnightBlue;
            _dgEngineers.HeaderFont = new Font("Tahoma", 8.0F, FontStyle.Bold);
            _dgEngineers.HeaderForeColor = Color.Lavender;
            _dgEngineers.LinkColor = Color.Teal;
            _dgEngineers.Location = new Point(11, 35);
            _dgEngineers.Name = "dgEngineers";
            _dgEngineers.ParentRowsBackColor = Color.Lavender;
            _dgEngineers.ParentRowsForeColor = Color.MidnightBlue;
            _dgEngineers.ParentRowsVisible = false;
            _dgEngineers.RowHeadersVisible = false;
            _dgEngineers.SelectionBackColor = Color.Teal;
            _dgEngineers.SelectionForeColor = Color.PaleGreen;
            _dgEngineers.Size = new Size(350, 141);
            _dgEngineers.TabIndex = 26;
            //
            // btnRunReport
            //
            _btnRunReport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnRunReport.Location = new Point(747, 172);
            _btnRunReport.Name = "btnRunReport";
            _btnRunReport.Size = new Size(91, 23);
            _btnRunReport.TabIndex = 25;
            _btnRunReport.Text = "Run Report";
            //
            // Label4
            //
            _Label4.BackColor = Color.White;
            _Label4.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label4.Location = new Point(8, 16);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(64, 16);
            _Label4.TabIndex = 24;
            _Label4.Text = "Engineers";
            //
            // dtpTo
            //
            _dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _dtpTo.Location = new Point(686, 47);
            _dtpTo.Name = "dtpTo";
            _dtpTo.Size = new Size(144, 21);
            _dtpTo.TabIndex = 13;
            //
            // dtpFrom
            //
            _dtpFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _dtpFrom.Location = new Point(686, 20);
            _dtpFrom.Name = "dtpFrom";
            _dtpFrom.Size = new Size(144, 21);
            _dtpFrom.TabIndex = 12;
            //
            // txtJobNumber
            //
            _txtJobNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtJobNumber.Location = new Point(686, 74);
            _txtJobNumber.Name = "txtJobNumber";
            _txtJobNumber.Size = new Size(144, 21);
            _txtJobNumber.TabIndex = 9;
            //
            // Label9
            //
            _Label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label9.Location = new Point(654, 52);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(24, 16);
            _Label9.TabIndex = 10;
            _Label9.Text = "To";
            _Label9.TextAlign = ContentAlignment.TopRight;
            //
            // Label8
            //
            _Label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label8.Location = new Point(592, 25);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(88, 16);
            _Label8.TabIndex = 9;
            _Label8.Text = "Date From";
            _Label8.TextAlign = ContentAlignment.TopRight;
            //
            // Label6
            //
            _Label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label6.Location = new Point(592, 79);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(88, 16);
            _Label6.TabIndex = 6;
            _Label6.Text = "Job Number";
            _Label6.TextAlign = ContentAlignment.TopRight;
            //
            // btnReset
            //
            _btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnReset.Location = new Point(72, 656);
            _btnReset.Name = "btnReset";
            _btnReset.Size = new Size(56, 23);
            _btnReset.TabIndex = 16;
            _btnReset.Text = "Reset";
            //
            // btnSummary
            //
            _btnSummary.AccessibleDescription = "Export Job List To Excel";
            _btnSummary.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSummary.Location = new Point(755, 656);
            _btnSummary.Name = "btnSummary";
            _btnSummary.Size = new Size(89, 23);
            _btnSummary.TabIndex = 17;
            _btnSummary.Text = "Summary";
            //
            // FRMEngineerTimesheetReport
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(860, 686);
            Controls.Add(_btnSummary);
            Controls.Add(_grpFilter);
            Controls.Add(_btnExport);
            Controls.Add(_grpJobs);
            Controls.Add(_btnReset);
            MinimumSize = new Size(808, 528);
            Name = "FRMEngineerTimesheetReport";
            Text = "Engineer Timesheet Report";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_btnReset, 0);
            Controls.SetChildIndex(_grpJobs, 0);
            Controls.SetChildIndex(_btnExport, 0);
            Controls.SetChildIndex(_grpFilter, 0);
            Controls.SetChildIndex(_btnSummary, 0);
            _grpJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgTimesheets).EndInit();
            _grpFilter.ResumeLayout(false);
            _grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgEngineers).EndInit();
            ResumeLayout(false);
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
                    drRw[0]["Time"] = (long)drRw[0]["Time"] + DateAndTime.DateDiff(DateInterval.Minute, Helper.MakeDateTimeValid(SelectedJobDataRow["StartDateTime"]), Helper.MakeDateTimeValid(SelectedJobDataRow["EndDateTime"]));
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
                    if (Conversions.ToBoolean((DateTime)drStartEnd[0]["StartDay"] > (DateTime)SelectedJobDataRow["StartDateTime"]))
                    {
                        drStartEnd[0]["StartDay"] = SelectedJobDataRow["StartDateTime"];
                    }

                    if (Conversions.ToBoolean((DateTime)drStartEnd[0]["EndDay"] < (DateTime)SelectedJobDataRow["EndDateTime"]))
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
                                        allTotal += (int)al["Time"];
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
                                total += (int)rSel[l]["Time"];
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
                                allTotal += (int)al["Time"];
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
                        total += (int)rSel[l]["Time"];
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
                            total += (int)rSel[l]["Time"];
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
                    totalUnallocated += (int)drDayUnallocated[b]["Time"];
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
                        total += (int)rSel[l]["Time"];
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
            Entity.Sys.ExportHelper.Export(exportData, "Timesheet " + Strings.Format(dtpFrom.Value, "dd-MM-yy") + " - " + Strings.Format(dtpTo.Value, "dd-MM-yy"), Entity.Sys.Enums.ExportType.CSV);
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
                    drRw[0]["Time"] = (long)drRw[0]["Time"] + DateAndTime.DateDiff(DateInterval.Minute, Helper.MakeDateTimeValid(SelectedJobDataRow["StartDateTime"]), Helper.MakeDateTimeValid(SelectedJobDataRow["EndDateTime"]));
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
                    if (Conversions.ToBoolean((DateTime)drStartEnd[0]["StartDay"] > (DateTime)SelectedJobDataRow["StartDateTime"]))
                    {
                        drStartEnd[0]["StartDay"] = SelectedJobDataRow["StartDateTime"];
                    }

                    if (Conversions.ToBoolean((DateTime)drStartEnd[0]["EndDay"] < (DateTime)SelectedJobDataRow["EndDateTime"]))
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
                                MinsTally += (int)rSel[0]["Time"];
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
                                        allTotal += (int)al["Time"];
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
                                total += (int)rSel[l]["Time"];
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
                        MinsTally += (int)rSel[0]["Time"];
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
                                allTotal += (int)al["Time"];
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
                        total += (int)rSel[l]["Time"];
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
                            total += (int)rSel[l]["Time"];
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
                    totalUnallocated += (int)drDayUnallocated[b]["Time"];
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
                        total += (int)rSel[l]["Time"];
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