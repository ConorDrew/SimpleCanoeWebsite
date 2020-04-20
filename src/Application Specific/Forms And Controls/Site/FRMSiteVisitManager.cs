using System;
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
    public class FRMSiteVisitManager : FRMBaseForm, IForm
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMSiteVisitManager() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMVisitManager_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

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

        private ComboBox _cboStatus;

        internal ComboBox cboStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboStatus != null)
                {
                }

                _cboStatus = value;
                if (_cboStatus != null)
                {
                }
            }
        }

        private ComboBox _cboDefinition;

        internal ComboBox cboDefinition
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDefinition;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDefinition != null)
                {
                }

                _cboDefinition = value;
                if (_cboDefinition != null)
                {
                }
            }
        }

        private Label _Label11;

        internal Label Label11
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label11;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label11 != null)
                {
                }

                _Label11 = value;
                if (_Label11 != null)
                {
                }
            }
        }

        private ComboBox _cboType;

        internal ComboBox cboType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboType != null)
                {
                }

                _cboType = value;
                if (_cboType != null)
                {
                }
            }
        }

        private Label _Label10;

        internal Label Label10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label10 != null)
                {
                }

                _Label10 = value;
                if (_Label10 != null)
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

        private Label _Label3;

        internal Label Label3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label3 != null)
                {
                }

                _Label3 = value;
                if (_Label3 != null)
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

        private CheckBox _chkVisitDate;

        internal CheckBox chkVisitDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkVisitDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkVisitDate != null)
                {
                    _chkVisitDate.CheckedChanged -= chkVisitDate_CheckedChanged;
                }

                _chkVisitDate = value;
                if (_chkVisitDate != null)
                {
                    _chkVisitDate.CheckedChanged += chkVisitDate_CheckedChanged;
                }
            }
        }

        private GroupBox _grpEngineerVisits;

        internal GroupBox grpEngineerVisits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpEngineerVisits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpEngineerVisits != null)
                {
                }

                _grpEngineerVisits = value;
                if (_grpEngineerVisits != null)
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

        private Button _btnfindEngineer;

        internal Button btnfindEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnfindEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnfindEngineer != null)
                {
                    _btnfindEngineer.Click -= btnfindEngineer_Click;
                }

                _btnfindEngineer = value;
                if (_btnfindEngineer != null)
                {
                    _btnfindEngineer.Click += btnfindEngineer_Click;
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

        private Label _Label12;

        internal Label Label12
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label12;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label12 != null)
                {
                }

                _Label12 = value;
                if (_Label12 != null)
                {
                }
            }
        }

        private ComboBox _cboOutcome;

        internal ComboBox cboOutcome
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboOutcome;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboOutcome != null)
                {
                }

                _cboOutcome = value;
                if (_cboOutcome != null)
                {
                }
            }
        }

        private Button _btnSearch;

        internal Button btnSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSearch != null)
                {
                    _btnSearch.Click -= btnSearch_Click;
                }

                _btnSearch = value;
                if (_btnSearch != null)
                {
                    _btnSearch.Click += btnSearch_Click;
                }
            }
        }

        private Label _Label5;

        internal Label Label5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label5 != null)
                {
                }

                _Label5 = value;
                if (_Label5 != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpEngineerVisits = new GroupBox();
            _dgVisits = new DataGrid();
            _dgVisits.DoubleClick += new EventHandler(dgVisits_DoubleClick);
            _btnExport = new Button();
            _btnExport.Click += new EventHandler(btnExport_Click);
            _grpFilter = new GroupBox();
            _btnSearch = new Button();
            _btnSearch.Click += new EventHandler(btnSearch_Click);
            _Label12 = new Label();
            _cboOutcome = new ComboBox();
            _btnfindEngineer = new Button();
            _btnfindEngineer.Click += new EventHandler(btnfindEngineer_Click);
            _txtEngineer = new TextBox();
            _Label5 = new Label();
            _dtpTo = new DateTimePicker();
            _dtpFrom = new DateTimePicker();
            _txtJobNumber = new TextBox();
            _Label9 = new Label();
            _Label8 = new Label();
            _chkVisitDate = new CheckBox();
            _chkVisitDate.CheckedChanged += new EventHandler(chkVisitDate_CheckedChanged);
            _Label6 = new Label();
            _cboType = new ComboBox();
            _Label11 = new Label();
            _cboDefinition = new ComboBox();
            _cboStatus = new ComboBox();
            _Label3 = new Label();
            _Label10 = new Label();
            _btnReset = new Button();
            _btnReset.Click += new EventHandler(btnReset_Click);
            _grpEngineerVisits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgVisits).BeginInit();
            _grpFilter.SuspendLayout();
            SuspendLayout();
            // 
            // grpEngineerVisits
            // 
            _grpEngineerVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpEngineerVisits.Controls.Add(_dgVisits);
            _grpEngineerVisits.Location = new Point(8, 173);
            _grpEngineerVisits.Name = "grpEngineerVisits";
            _grpEngineerVisits.Size = new Size(976, 407);
            _grpEngineerVisits.TabIndex = 2;
            _grpEngineerVisits.TabStop = false;
            _grpEngineerVisits.Text = "Double Click To View / Edit";
            // 
            // dgVisits
            // 
            _dgVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgVisits.DataMember = "";
            _dgVisits.HeaderForeColor = SystemColors.ControlText;
            _dgVisits.Location = new Point(8, 20);
            _dgVisits.Name = "dgVisits";
            _dgVisits.Size = new Size(960, 379);
            _dgVisits.TabIndex = 14;
            // 
            // btnExport
            // 
            _btnExport.AccessibleDescription = "Export Job List To Excel";
            _btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnExport.Location = new Point(8, 586);
            _btnExport.Name = "btnExport";
            _btnExport.Size = new Size(56, 23);
            _btnExport.TabIndex = 15;
            _btnExport.Text = "Export";
            // 
            // grpFilter
            // 
            _grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpFilter.Controls.Add(_btnSearch);
            _grpFilter.Controls.Add(_Label12);
            _grpFilter.Controls.Add(_cboOutcome);
            _grpFilter.Controls.Add(_btnfindEngineer);
            _grpFilter.Controls.Add(_txtEngineer);
            _grpFilter.Controls.Add(_Label5);
            _grpFilter.Controls.Add(_dtpTo);
            _grpFilter.Controls.Add(_dtpFrom);
            _grpFilter.Controls.Add(_txtJobNumber);
            _grpFilter.Controls.Add(_Label9);
            _grpFilter.Controls.Add(_Label8);
            _grpFilter.Controls.Add(_chkVisitDate);
            _grpFilter.Controls.Add(_Label6);
            _grpFilter.Controls.Add(_cboType);
            _grpFilter.Controls.Add(_Label11);
            _grpFilter.Controls.Add(_cboDefinition);
            _grpFilter.Controls.Add(_cboStatus);
            _grpFilter.Controls.Add(_Label3);
            _grpFilter.Controls.Add(_Label10);
            _grpFilter.Location = new Point(8, 32);
            _grpFilter.Name = "grpFilter";
            _grpFilter.Size = new Size(976, 135);
            _grpFilter.TabIndex = 1;
            _grpFilter.TabStop = false;
            _grpFilter.Text = "Filter";
            // 
            // btnSearch
            // 
            _btnSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSearch.Location = new Point(898, 106);
            _btnSearch.Name = "btnSearch";
            _btnSearch.Size = new Size(70, 23);
            _btnSearch.TabIndex = 33;
            _btnSearch.Text = "Run Filter";
            // 
            // Label12
            // 
            _Label12.Location = new Point(304, 77);
            _Label12.Name = "Label12";
            _Label12.Size = new Size(62, 22);
            _Label12.TabIndex = 31;
            _Label12.Text = "Outcome";
            // 
            // cboOutcome
            // 
            _cboOutcome.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboOutcome.Location = new Point(377, 74);
            _cboOutcome.Name = "cboOutcome";
            _cboOutcome.Size = new Size(184, 21);
            _cboOutcome.TabIndex = 32;
            // 
            // btnfindEngineer
            // 
            _btnfindEngineer.BackColor = Color.White;
            _btnfindEngineer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnfindEngineer.Location = new Point(258, 20);
            _btnfindEngineer.Name = "btnfindEngineer";
            _btnfindEngineer.Size = new Size(32, 23);
            _btnfindEngineer.TabIndex = 29;
            _btnfindEngineer.Text = "...";
            _btnfindEngineer.UseVisualStyleBackColor = false;
            // 
            // txtEngineer
            // 
            _txtEngineer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtEngineer.Location = new Point(68, 20);
            _txtEngineer.Name = "txtEngineer";
            _txtEngineer.ReadOnly = true;
            _txtEngineer.Size = new Size(184, 21);
            _txtEngineer.TabIndex = 28;
            // 
            // Label5
            // 
            _Label5.Location = new Point(7, 19);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(70, 16);
            _Label5.TabIndex = 30;
            _Label5.Text = "Engineer";
            // 
            // dtpTo
            // 
            _dtpTo.Location = new Point(621, 78);
            _dtpTo.Name = "dtpTo";
            _dtpTo.Size = new Size(155, 21);
            _dtpTo.TabIndex = 13;
            // 
            // dtpFrom
            // 
            _dtpFrom.Location = new Point(621, 47);
            _dtpFrom.Name = "dtpFrom";
            _dtpFrom.Size = new Size(155, 21);
            _dtpFrom.TabIndex = 12;
            // 
            // txtJobNumber
            // 
            _txtJobNumber.Location = new Point(377, 20);
            _txtJobNumber.Name = "txtJobNumber";
            _txtJobNumber.Size = new Size(184, 21);
            _txtJobNumber.TabIndex = 9;
            // 
            // Label9
            // 
            _Label9.Location = new Point(565, 79);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(48, 16);
            _Label9.TabIndex = 10;
            _Label9.Text = "To";
            // 
            // Label8
            // 
            _Label8.Location = new Point(565, 47);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(48, 16);
            _Label8.TabIndex = 9;
            _Label8.Text = "From";
            // 
            // chkVisitDate
            // 
            _chkVisitDate.Cursor = Cursors.Hand;
            _chkVisitDate.UseVisualStyleBackColor = true;
            _chkVisitDate.Location = new Point(567, 18);
            _chkVisitDate.Name = "chkVisitDate";
            _chkVisitDate.Size = new Size(80, 24);
            _chkVisitDate.TabIndex = 11;
            _chkVisitDate.Text = "Visit Date";
            // 
            // Label6
            // 
            _Label6.Location = new Point(304, 21);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(88, 16);
            _Label6.TabIndex = 6;
            _Label6.Text = "Job Number";
            // 
            // cboType
            // 
            _cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboType.Location = new Point(377, 47);
            _cboType.Name = "cboType";
            _cboType.Size = new Size(184, 21);
            _cboType.TabIndex = 7;
            // 
            // Label11
            // 
            _Label11.Location = new Point(8, 77);
            _Label11.Name = "Label11";
            _Label11.Size = new Size(48, 22);
            _Label11.TabIndex = 5;
            _Label11.Text = "Status";
            // 
            // cboDefinition
            // 
            _cboDefinition.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboDefinition.Location = new Point(68, 47);
            _cboDefinition.Name = "cboDefinition";
            _cboDefinition.Size = new Size(184, 21);
            _cboDefinition.TabIndex = 6;
            // 
            // cboStatus
            // 
            _cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboStatus.Location = new Point(68, 74);
            _cboStatus.Name = "cboStatus";
            _cboStatus.Size = new Size(184, 21);
            _cboStatus.TabIndex = 8;
            // 
            // Label3
            // 
            _Label3.Location = new Point(8, 50);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(72, 16);
            _Label3.TabIndex = 3;
            _Label3.Text = "Definition";
            // 
            // Label10
            // 
            _Label10.Location = new Point(304, 47);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(55, 22);
            _Label10.TabIndex = 4;
            _Label10.Text = "Type";
            // 
            // btnReset
            // 
            _btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnReset.Location = new Point(72, 586);
            _btnReset.Name = "btnReset";
            _btnReset.Size = new Size(56, 23);
            _btnReset.TabIndex = 16;
            _btnReset.Text = "Reset";
            // 
            // FRMSiteVisitManager
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(992, 616);
            Controls.Add(_grpFilter);
            Controls.Add(_btnExport);
            Controls.Add(_grpEngineerVisits);
            Controls.Add(_btnReset);
            MinimumSize = new Size(1000, 528);
            Name = "FRMSiteVisitManager";
            Text = "Site Visit Manager";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_btnReset, 0);
            Controls.SetChildIndex(_grpEngineerVisits, 0);
            Controls.SetChildIndex(_btnExport, 0);
            Controls.SetChildIndex(_grpFilter, 0);
            _grpEngineerVisits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgVisits).EndInit();
            _grpFilter.ResumeLayout(false);
            _grpFilter.PerformLayout();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupVisitDataGrid();
            var argc = cboDefinition;
            Combo.SetUpCombo(ref argc, DynamicDataTables.JobDefinitions, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
            var argc1 = cboOutcome;
            Combo.SetUpCombo(ref argc1, DynamicDataTables.OutcomeStatuses, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
            var argc2 = cboType;
            Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
            var argc3 = cboStatus;
            Combo.SetUpCombo(ref argc3, DynamicDataTables.VisitStatus_For_Viewing, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
            if (App.loggedInUser.Admin == false)
            {
                btnExport.Enabled = false;
            }

            SiteID = Conversions.ToInteger(get_GetParameter(0));
            PopulateDatagrid(true);
        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        private void ResetMe(int newID)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataView _dvVisits;

        private DataView VisitsDataview
        {
            get
            {
                return _dvVisits;
            }

            set
            {
                _dvVisits = value;
                if (VisitsDataview is object)
                {
                    _dvVisits.AllowNew = false;
                    _dvVisits.AllowEdit = false;
                    _dvVisits.AllowDelete = false;
                    _dvVisits.Table.TableName = Enums.TableNames.tblEngineerVisit.ToString();
                }

                dgVisits.DataSource = VisitsDataview;
                if (VisitsDataview is object)
                {
                    if (VisitsDataview.Table.Rows.Count > 0)
                    {
                        dgVisits.Select(0);
                    }
                }
            }
        }

        private DataRow SelectedVisitDataRow
        {
            get
            {
                if (VisitsDataview is null)
                {
                    return null;
                }

                if (!(dgVisits.CurrentRowIndex == -1))
                {
                    return VisitsDataview[dgVisits.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private Entity.Engineers.Engineer _theEngineer;

        public Entity.Engineers.Engineer theEngineer
        {
            get
            {
                return _theEngineer;
            }

            set
            {
                _theEngineer = value;
                if (_theEngineer is object)
                {
                    txtEngineer.Text = theEngineer.Name;
                }
                else
                {
                    txtEngineer.Text = "";
                }
            }
        }

        private int _siteID = 0;

        private int SiteID
        {
            get
            {
                return _siteID;
            }

            set
            {
                _siteID = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void SetupVisitDataGrid()
        {
            var tbStyle = dgVisits.TableStyles[0];
            var StartDateTime = new DataGridLabelColumn();
            StartDateTime.Format = "dd/MM/yy";
            StartDateTime.FormatInfo = null;
            StartDateTime.HeaderText = "Visit Date";
            StartDateTime.MappingName = "VisitDate";
            StartDateTime.ReadOnly = true;
            StartDateTime.Width = 60;
            StartDateTime.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(StartDateTime);
            var Engineer = new DataGridLabelColumn();
            Engineer.Format = "";
            Engineer.FormatInfo = null;
            Engineer.HeaderText = "Engineer";
            Engineer.MappingName = "Engineer";
            Engineer.ReadOnly = true;
            Engineer.Width = 75;
            Engineer.NullText = "";
            tbStyle.GridColumnStyles.Add(Engineer);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 75;
            Type.NullText = Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
            tbStyle.GridColumnStyles.Add(Type);
            var NotesToEngineer = new DataGridLabelColumn();
            NotesToEngineer.Format = "";
            NotesToEngineer.FormatInfo = null;
            NotesToEngineer.HeaderText = "Notes To Engineer";
            NotesToEngineer.MappingName = "NotesToEngineer";
            NotesToEngineer.ReadOnly = true;
            NotesToEngineer.Width = 325;
            NotesToEngineer.NullText = "";
            tbStyle.GridColumnStyles.Add(NotesToEngineer);
            var NotesFromEngineer = new DataGridLabelColumn();
            NotesFromEngineer.Format = "";
            NotesFromEngineer.FormatInfo = null;
            NotesFromEngineer.HeaderText = "Notes From Engineer";
            NotesFromEngineer.MappingName = "NotesFromEngineer";
            NotesFromEngineer.ReadOnly = true;
            NotesFromEngineer.Width = 325;
            NotesFromEngineer.NullText = "";
            tbStyle.GridColumnStyles.Add(NotesFromEngineer);
            var VisitCharge = new DataGridLabelColumn();
            VisitCharge.Format = "C";
            VisitCharge.FormatInfo = null;
            VisitCharge.HeaderText = "Charge";
            VisitCharge.MappingName = "VisitCharge";
            VisitCharge.ReadOnly = true;
            VisitCharge.Width = 45;
            VisitCharge.NullText = "";
            tbStyle.GridColumnStyles.Add(VisitCharge);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job No";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 75;
            JobNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(JobNumber);
            var VisitStatus = new DataGridLabelColumn();
            VisitStatus.Format = "";
            VisitStatus.FormatInfo = null;
            VisitStatus.HeaderText = "Status";
            VisitStatus.MappingName = "VisitStatus";
            VisitStatus.ReadOnly = true;
            VisitStatus.Width = 60;
            VisitStatus.NullText = "";
            tbStyle.GridColumnStyles.Add(VisitStatus);
            var VisitOutcome = new DataGridLabelColumn();
            VisitOutcome.Format = "";
            VisitOutcome.FormatInfo = null;
            VisitOutcome.HeaderText = "Outcome";
            VisitOutcome.MappingName = "VisitOutcome";
            VisitOutcome.ReadOnly = true;
            VisitOutcome.Width = 60;
            VisitOutcome.NullText = "";
            tbStyle.GridColumnStyles.Add(VisitOutcome);
            var PartsToFit = new BitToStringDescriptionColumn();
            PartsToFit.Format = "";
            PartsToFit.FormatInfo = null;
            PartsToFit.HeaderText = "Parts To Fit";
            PartsToFit.MappingName = "PartsToFit";
            PartsToFit.ReadOnly = true;
            PartsToFit.Width = 60;
            PartsToFit.NullText = "";
            tbStyle.GridColumnStyles.Add(PartsToFit);
            switch (true)
            {
                case object _ when App.IsRFT:
                    {
                        var trade = new DataGridLabelColumn();
                        trade.Format = "";
                        trade.FormatInfo = null;
                        trade.HeaderText = "Trade";
                        trade.MappingName = "Qualification";
                        trade.ReadOnly = true;
                        trade.Width = 85;
                        trade.NullText = "";
                        tbStyle.GridColumnStyles.Add(trade);
                        break;
                    }
            }

            var VisitValue = new DataGridLabelColumn();
            VisitValue.Format = "C";
            VisitValue.FormatInfo = null;
            VisitValue.HeaderText = "Visit Value";
            VisitValue.MappingName = "VisitValue";
            VisitValue.ReadOnly = true;
            VisitValue.Width = 60;
            VisitValue.NullText = "";
            tbStyle.GridColumnStyles.Add(VisitValue);
            var EngineerCost = new DataGridLabelColumn();
            EngineerCost.Format = "C";
            EngineerCost.FormatInfo = null;
            EngineerCost.HeaderText = "Engineer Cost";
            EngineerCost.MappingName = "EngineerCost";
            EngineerCost.ReadOnly = true;
            EngineerCost.Width = 60;
            EngineerCost.NullText = "";
            tbStyle.GridColumnStyles.Add(EngineerCost);
            var PartProductCost = new DataGridLabelColumn();
            PartProductCost.Format = "C";
            PartProductCost.FormatInfo = null;
            PartProductCost.HeaderText = @"Part\Product Cost";
            PartProductCost.MappingName = "PartProductCost";
            PartProductCost.ReadOnly = true;
            PartProductCost.Width = 60;
            PartProductCost.NullText = "";
            tbStyle.GridColumnStyles.Add(PartProductCost);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Enums.TableNames.tblEngineerVisit.ToString();
            dgVisits.TableStyles.Add(tbStyle);
        }

        private void FRMVisitManager_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void btnfindEngineer_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblEngineer));
            if (!(ID == 0))
            {
                theEngineer = App.DB.Engineer.Engineer_Get(ID);
            }
        }

        private void chkVisitDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVisitDate.Checked)
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            else
            {
                dtpFrom.Value = DateAndTime.Today;
                dtpTo.Value = DateAndTime.Today;
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
        }

        private void dgVisits_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedVisitDataRow is null)
            {
                App.ShowMessage("Please select a visit to view", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool @continue = false;
            var switchExpr = Conversions.ToInteger(SelectedVisitDataRow["StatusEnumID"]);
            switch (switchExpr)
            {
                case Conversions.ToInteger(Enums.VisitStatus.NOT_SET):
                    {
                        App.ShowMessage("This visit has not entered a visit life span yet.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case Conversions.ToInteger(Enums.VisitStatus.Parts_Need_Ordering):
                    {
                        App.ShowMessage("Parts Need Ordering for this visit, once ordered and recieved you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case Conversions.ToInteger(Enums.VisitStatus.Waiting_For_Parts):
                    {
                        App.ShowMessage("This visit is waiting for parts, once recieved you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case Conversions.ToInteger(Enums.VisitStatus.Ready_For_Schedule):
                    {
                        if (App.ShowMessage("This visit is ready for schedule, would you like to manually complete the visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            @continue = true;
                        }

                        break;
                    }

                case Conversions.ToInteger(Enums.VisitStatus.Scheduled):
                    {
                        if (App.ShowMessage("This visit is scheduled, would you like to manually complete the visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            @continue = true;
                        }

                        break;
                    }

                case Conversions.ToInteger(Enums.VisitStatus.Downloaded):
                    {
                        App.ShowMessage("This visit is currently with an engineer, once returned you may view the details.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case Conversions.ToInteger(Enums.VisitStatus.Uploaded):
                    {
                        @continue = true;
                        break;
                    }

                case (int)Enums.VisitStatus.Not_To_Be_Invoiced:
                    {
                        @continue = true;
                        break;
                    }

                case (int)Enums.VisitStatus.Ready_To_Be_Invoiced:
                    {
                        @continue = true;
                        break;
                    }

                case (int)Enums.VisitStatus.Invoiced:
                    {
                        @continue = true;
                        break;
                    }
            }

            if (@continue)
            {
                App.ShowForm(typeof(FRMEngineerVisit), true, new object[] { SelectedVisitDataRow["EngineerVisitID"] });
                PopulateDatagrid(true);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateDatagrid(true);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void PopulateDatagrid(bool withRun)
        {
            try
            {
                if (withRun)
                {
                    string whereClause = "AND (tblSite.SiteID = " + SiteID;
                    if (theEngineer is object)
                    {
                        whereClause += " AND tblEngineer.EngineerID = " + theEngineer.EngineerID + "";
                    }

                    if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboDefinition)) == 0))
                    {
                        whereClause += " AND tblJob.JobDefinitionEnumID = " + Combo.get_GetSelectedItemValue(cboDefinition) + "";
                    }

                    if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboType)) == 0))
                    {
                        whereClause += " AND tblJob.JobTypeID = " + Combo.get_GetSelectedItemValue(cboType) + "";
                    }

                    if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboStatus)) == 0))
                    {
                        whereClause += " AND @THEStatusEnumIDString = " + Combo.get_GetSelectedItemValue(cboStatus) + "";
                    }

                    if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboOutcome)) == 0))
                    {
                        whereClause += " AND tblEngineerVisit.OutcomeEnumID = " + Combo.get_GetSelectedItemValue(cboOutcome) + "";
                    }

                    if (!(txtJobNumber.Text.Trim().Length == 0))
                    {
                        whereClause += " AND tblJob.JobNumber LIKE '" + txtJobNumber.Text.Trim() + "%'";
                    }

                    if (chkVisitDate.Checked)
                    {
                        whereClause += " AND tblEngineerVisit.StartDateTime >= '" + Strings.Format(dtpFrom.Value, "dd-MMM-yyyy 00:00:00") + "' AND tblEngineerVisit.StartDateTime <= '" + Strings.Format(dtpTo.Value, "dd-MMM-yyyy 23:59:59") + "'";
                    }

                    whereClause += ")";
                    VisitsDataview = App.DB.EngineerVisits.EngineerVisits_Get_All_ForSite(whereClause);
                }
                else
                {
                    VisitsDataview = null;
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFilters()
        {
            theEngineer = null;
            var argcombo = cboDefinition;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            var argcombo1 = cboType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, 0.ToString());
            var argcombo2 = cboStatus;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, 0.ToString());
            var argcombo3 = cboOutcome;
            Combo.SetSelectedComboItem_By_Value(ref argcombo3, 0.ToString());
            txtJobNumber.Text = "";
            chkVisitDate.Checked = false;
            dtpFrom.Value = DateAndTime.Today;
            dtpTo.Value = DateAndTime.Today;
            dtpFrom.Enabled = false;
            dtpTo.Enabled = false;
            grpFilter.Enabled = true;
        }

        public void Export()
        {
            if (VisitsDataview is object)
            {
                ExportHelper.Export(VisitsDataview.Table, "SiteReport", Enums.ExportType.XLS);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}