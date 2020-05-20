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
        public FRMSiteVisitManager() : base()
        {
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
            this._grpEngineerVisits = new System.Windows.Forms.GroupBox();
            this._dgVisits = new System.Windows.Forms.DataGrid();
            this._btnExport = new System.Windows.Forms.Button();
            this._grpFilter = new System.Windows.Forms.GroupBox();
            this._btnSearch = new System.Windows.Forms.Button();
            this._Label12 = new System.Windows.Forms.Label();
            this._cboOutcome = new System.Windows.Forms.ComboBox();
            this._btnfindEngineer = new System.Windows.Forms.Button();
            this._txtEngineer = new System.Windows.Forms.TextBox();
            this._Label5 = new System.Windows.Forms.Label();
            this._dtpTo = new System.Windows.Forms.DateTimePicker();
            this._dtpFrom = new System.Windows.Forms.DateTimePicker();
            this._txtJobNumber = new System.Windows.Forms.TextBox();
            this._Label9 = new System.Windows.Forms.Label();
            this._Label8 = new System.Windows.Forms.Label();
            this._chkVisitDate = new System.Windows.Forms.CheckBox();
            this._Label6 = new System.Windows.Forms.Label();
            this._cboType = new System.Windows.Forms.ComboBox();
            this._Label11 = new System.Windows.Forms.Label();
            this._cboDefinition = new System.Windows.Forms.ComboBox();
            this._cboStatus = new System.Windows.Forms.ComboBox();
            this._Label3 = new System.Windows.Forms.Label();
            this._Label10 = new System.Windows.Forms.Label();
            this._btnReset = new System.Windows.Forms.Button();
            this._grpEngineerVisits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgVisits)).BeginInit();
            this._grpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpEngineerVisits
            // 
            this._grpEngineerVisits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpEngineerVisits.Controls.Add(this._dgVisits);
            this._grpEngineerVisits.Location = new System.Drawing.Point(8, 153);
            this._grpEngineerVisits.Name = "_grpEngineerVisits";
            this._grpEngineerVisits.Size = new System.Drawing.Size(976, 427);
            this._grpEngineerVisits.TabIndex = 2;
            this._grpEngineerVisits.TabStop = false;
            this._grpEngineerVisits.Text = "Double Click To View / Edit";
            // 
            // _dgVisits
            // 
            this._dgVisits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgVisits.DataMember = "";
            this._dgVisits.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgVisits.Location = new System.Drawing.Point(8, 20);
            this._dgVisits.Name = "_dgVisits";
            this._dgVisits.Size = new System.Drawing.Size(960, 399);
            this._dgVisits.TabIndex = 14;
            this._dgVisits.DoubleClick += new System.EventHandler(this.dgVisits_DoubleClick);
            // 
            // _btnExport
            // 
            this._btnExport.AccessibleDescription = "Export Job List To Excel";
            this._btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnExport.Location = new System.Drawing.Point(8, 586);
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
            this._grpFilter.Controls.Add(this._btnSearch);
            this._grpFilter.Controls.Add(this._Label12);
            this._grpFilter.Controls.Add(this._cboOutcome);
            this._grpFilter.Controls.Add(this._btnfindEngineer);
            this._grpFilter.Controls.Add(this._txtEngineer);
            this._grpFilter.Controls.Add(this._Label5);
            this._grpFilter.Controls.Add(this._dtpTo);
            this._grpFilter.Controls.Add(this._dtpFrom);
            this._grpFilter.Controls.Add(this._txtJobNumber);
            this._grpFilter.Controls.Add(this._Label9);
            this._grpFilter.Controls.Add(this._Label8);
            this._grpFilter.Controls.Add(this._chkVisitDate);
            this._grpFilter.Controls.Add(this._Label6);
            this._grpFilter.Controls.Add(this._cboType);
            this._grpFilter.Controls.Add(this._Label11);
            this._grpFilter.Controls.Add(this._cboDefinition);
            this._grpFilter.Controls.Add(this._cboStatus);
            this._grpFilter.Controls.Add(this._Label3);
            this._grpFilter.Controls.Add(this._Label10);
            this._grpFilter.Location = new System.Drawing.Point(8, 12);
            this._grpFilter.Name = "_grpFilter";
            this._grpFilter.Size = new System.Drawing.Size(976, 135);
            this._grpFilter.TabIndex = 1;
            this._grpFilter.TabStop = false;
            this._grpFilter.Text = "Filter";
            // 
            // _btnSearch
            // 
            this._btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSearch.Location = new System.Drawing.Point(898, 106);
            this._btnSearch.Name = "_btnSearch";
            this._btnSearch.Size = new System.Drawing.Size(70, 23);
            this._btnSearch.TabIndex = 33;
            this._btnSearch.Text = "Run Filter";
            this._btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // _Label12
            // 
            this._Label12.Location = new System.Drawing.Point(304, 77);
            this._Label12.Name = "_Label12";
            this._Label12.Size = new System.Drawing.Size(62, 22);
            this._Label12.TabIndex = 31;
            this._Label12.Text = "Outcome";
            // 
            // _cboOutcome
            // 
            this._cboOutcome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboOutcome.Location = new System.Drawing.Point(377, 74);
            this._cboOutcome.Name = "_cboOutcome";
            this._cboOutcome.Size = new System.Drawing.Size(184, 21);
            this._cboOutcome.TabIndex = 32;
            // 
            // _btnfindEngineer
            // 
            this._btnfindEngineer.BackColor = System.Drawing.Color.White;
            this._btnfindEngineer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnfindEngineer.Location = new System.Drawing.Point(258, 20);
            this._btnfindEngineer.Name = "_btnfindEngineer";
            this._btnfindEngineer.Size = new System.Drawing.Size(32, 23);
            this._btnfindEngineer.TabIndex = 29;
            this._btnfindEngineer.Text = "...";
            this._btnfindEngineer.UseVisualStyleBackColor = false;
            this._btnfindEngineer.Click += new System.EventHandler(this.btnfindEngineer_Click);
            // 
            // _txtEngineer
            // 
            this._txtEngineer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEngineer.Location = new System.Drawing.Point(68, 20);
            this._txtEngineer.Name = "_txtEngineer";
            this._txtEngineer.ReadOnly = true;
            this._txtEngineer.Size = new System.Drawing.Size(184, 21);
            this._txtEngineer.TabIndex = 28;
            // 
            // _Label5
            // 
            this._Label5.Location = new System.Drawing.Point(7, 19);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(70, 16);
            this._Label5.TabIndex = 30;
            this._Label5.Text = "Engineer";
            // 
            // _dtpTo
            // 
            this._dtpTo.Location = new System.Drawing.Point(621, 78);
            this._dtpTo.Name = "_dtpTo";
            this._dtpTo.Size = new System.Drawing.Size(155, 21);
            this._dtpTo.TabIndex = 13;
            // 
            // _dtpFrom
            // 
            this._dtpFrom.Location = new System.Drawing.Point(621, 47);
            this._dtpFrom.Name = "_dtpFrom";
            this._dtpFrom.Size = new System.Drawing.Size(155, 21);
            this._dtpFrom.TabIndex = 12;
            // 
            // _txtJobNumber
            // 
            this._txtJobNumber.Location = new System.Drawing.Point(377, 20);
            this._txtJobNumber.Name = "_txtJobNumber";
            this._txtJobNumber.Size = new System.Drawing.Size(184, 21);
            this._txtJobNumber.TabIndex = 9;
            // 
            // _Label9
            // 
            this._Label9.Location = new System.Drawing.Point(565, 79);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(48, 16);
            this._Label9.TabIndex = 10;
            this._Label9.Text = "To";
            // 
            // _Label8
            // 
            this._Label8.Location = new System.Drawing.Point(565, 47);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(48, 16);
            this._Label8.TabIndex = 9;
            this._Label8.Text = "From";
            // 
            // _chkVisitDate
            // 
            this._chkVisitDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this._chkVisitDate.Location = new System.Drawing.Point(567, 18);
            this._chkVisitDate.Name = "_chkVisitDate";
            this._chkVisitDate.Size = new System.Drawing.Size(80, 24);
            this._chkVisitDate.TabIndex = 11;
            this._chkVisitDate.Text = "Visit Date";
            this._chkVisitDate.UseVisualStyleBackColor = true;
            this._chkVisitDate.CheckedChanged += new System.EventHandler(this.chkVisitDate_CheckedChanged);
            // 
            // _Label6
            // 
            this._Label6.Location = new System.Drawing.Point(304, 21);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(88, 16);
            this._Label6.TabIndex = 6;
            this._Label6.Text = "Job Number";
            // 
            // _cboType
            // 
            this._cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboType.Location = new System.Drawing.Point(377, 47);
            this._cboType.Name = "_cboType";
            this._cboType.Size = new System.Drawing.Size(184, 21);
            this._cboType.TabIndex = 7;
            // 
            // _Label11
            // 
            this._Label11.Location = new System.Drawing.Point(8, 77);
            this._Label11.Name = "_Label11";
            this._Label11.Size = new System.Drawing.Size(48, 22);
            this._Label11.TabIndex = 5;
            this._Label11.Text = "Status";
            // 
            // _cboDefinition
            // 
            this._cboDefinition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboDefinition.Location = new System.Drawing.Point(68, 47);
            this._cboDefinition.Name = "_cboDefinition";
            this._cboDefinition.Size = new System.Drawing.Size(184, 21);
            this._cboDefinition.TabIndex = 6;
            // 
            // _cboStatus
            // 
            this._cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboStatus.Location = new System.Drawing.Point(68, 74);
            this._cboStatus.Name = "_cboStatus";
            this._cboStatus.Size = new System.Drawing.Size(184, 21);
            this._cboStatus.TabIndex = 8;
            // 
            // _Label3
            // 
            this._Label3.Location = new System.Drawing.Point(8, 50);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(72, 16);
            this._Label3.TabIndex = 3;
            this._Label3.Text = "Definition";
            // 
            // _Label10
            // 
            this._Label10.Location = new System.Drawing.Point(304, 47);
            this._Label10.Name = "_Label10";
            this._Label10.Size = new System.Drawing.Size(55, 22);
            this._Label10.TabIndex = 4;
            this._Label10.Text = "Type";
            // 
            // _btnReset
            // 
            this._btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnReset.Location = new System.Drawing.Point(72, 586);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(56, 23);
            this._btnReset.TabIndex = 16;
            this._btnReset.Text = "Reset";
            this._btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // FRMSiteVisitManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(992, 616);
            this.Controls.Add(this._grpFilter);
            this.Controls.Add(this._btnExport);
            this.Controls.Add(this._grpEngineerVisits);
            this.Controls.Add(this._btnReset);
            this.MinimumSize = new System.Drawing.Size(1000, 528);
            this.Name = "FRMSiteVisitManager";
            this.Text = "Site Visit Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpEngineerVisits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgVisits)).EndInit();
            this._grpFilter.ResumeLayout(false);
            this._grpFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
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

        public void ResetMe(int newID)
        {
        }

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
                case (int)(Enums.VisitStatus.NOT_SET):
                    {
                        App.ShowMessage("This visit has not entered a visit life span yet.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case (int)(Enums.VisitStatus.Parts_Need_Ordering):
                    {
                        App.ShowMessage("Parts Need Ordering for this visit, once ordered and recieved you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case (int)(Enums.VisitStatus.Waiting_For_Parts):
                    {
                        App.ShowMessage("This visit is waiting for parts, once recieved you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case (int)(Enums.VisitStatus.Ready_For_Schedule):
                    {
                        if (App.ShowMessage("This visit is ready for schedule, would you like to manually complete the visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            @continue = true;
                        }

                        break;
                    }

                case (int)(Enums.VisitStatus.Scheduled):
                    {
                        if (App.ShowMessage("This visit is scheduled, would you like to manually complete the visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            @continue = true;
                        }

                        break;
                    }

                case (int)(Enums.VisitStatus.Downloaded):
                    {
                        App.ShowMessage("This visit is currently with an engineer, once returned you may view the details.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case (int)(Enums.VisitStatus.Uploaded):
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
    }
}