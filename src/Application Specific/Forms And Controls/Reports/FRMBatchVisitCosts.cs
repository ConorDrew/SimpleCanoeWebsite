using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FSM
{
    public class FRMBatchVisitCosts : FRMBaseForm, IForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMBatchVisitCosts() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMVisitManager_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
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
                    _dgVisits.MouseUp -= dgVisits_MouseUp;
                }

                _dgVisits = value;
                if (_dgVisits != null)
                {
                    _dgVisits.MouseUp += dgVisits_MouseUp;
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

        private Button _btnShowdata;

        internal Button btnShowdata
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnShowdata;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnShowdata != null)
                {
                    _btnShowdata.Click -= btnShowdata_Click;
                }

                _btnShowdata = value;
                if (_btnShowdata != null)
                {
                    _btnShowdata.Click += btnShowdata_Click;
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpEngineerVisits = new GroupBox();
            _dgVisits = new DataGrid();
            _dgVisits.MouseUp += new MouseEventHandler(dgVisits_MouseUp);
            _btnExport = new Button();
            _btnExport.Click += new EventHandler(btnExport_Click);
            _Label8 = new Label();
            _Label9 = new Label();
            _dtpFrom = new DateTimePicker();
            _dtpTo = new DateTimePicker();
            _btnShowdata = new Button();
            _btnShowdata.Click += new EventHandler(btnShowdata_Click);
            _btnSelectAll = new Button();
            _btnSelectAll.Click += new EventHandler(btnSelectAll_Click);
            _btnUnselect = new Button();
            _btnUnselect.Click += new EventHandler(btnUnselect_Click);
            _grpFilter = new GroupBox();
            _Label1 = new Label();
            _grpEngineerVisits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgVisits).BeginInit();
            _grpFilter.SuspendLayout();
            SuspendLayout();
            //
            // grpEngineerVisits
            //
            _grpEngineerVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpEngineerVisits.Controls.Add(_dgVisits);
            _grpEngineerVisits.Location = new Point(8, 121);
            _grpEngineerVisits.Name = "grpEngineerVisits";
            _grpEngineerVisits.Size = new Size(784, 340);
            _grpEngineerVisits.TabIndex = 2;
            _grpEngineerVisits.TabStop = false;
            _grpEngineerVisits.Text = "Double Click To View / Edit";
            //
            // dgVisits
            //
            _dgVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgVisits.DataMember = "";
            _dgVisits.HeaderForeColor = SystemColors.ControlText;
            _dgVisits.Location = new Point(8, 18);
            _dgVisits.Name = "dgVisits";
            _dgVisits.Size = new Size(768, 314);
            _dgVisits.TabIndex = 14;
            //
            // btnExport
            //
            _btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnExport.Location = new Point(16, 467);
            _btnExport.Name = "btnExport";
            _btnExport.Size = new Size(96, 23);
            _btnExport.TabIndex = 37;
            _btnExport.Text = "Export";
            //
            // Label8
            //
            _Label8.Location = new Point(76, 24);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(48, 16);
            _Label8.TabIndex = 9;
            _Label8.Text = "From";
            //
            // Label9
            //
            _Label9.Location = new Point(279, 24);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(48, 16);
            _Label9.TabIndex = 10;
            _Label9.Text = "To";
            //
            // dtpFrom
            //
            _dtpFrom.Location = new Point(116, 21);
            _dtpFrom.Name = "dtpFrom";
            _dtpFrom.Size = new Size(144, 21);
            _dtpFrom.TabIndex = 12;
            //
            // dtpTo
            //
            _dtpTo.Location = new Point(319, 21);
            _dtpTo.Name = "dtpTo";
            _dtpTo.Size = new Size(144, 21);
            _dtpTo.TabIndex = 13;
            //
            // btnShowdata
            //
            _btnShowdata.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnShowdata.Location = new Point(679, 51);
            _btnShowdata.Name = "btnShowdata";
            _btnShowdata.Size = new Size(96, 23);
            _btnShowdata.TabIndex = 35;
            _btnShowdata.Text = "Show Data";
            //
            // btnSelectAll
            //
            _btnSelectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnSelectAll.Location = new Point(11, 51);
            _btnSelectAll.Name = "btnSelectAll";
            _btnSelectAll.Size = new Size(96, 23);
            _btnSelectAll.TabIndex = 36;
            _btnSelectAll.Text = "Select All";
            //
            // btnUnselect
            //
            _btnUnselect.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnUnselect.Location = new Point(113, 51);
            _btnUnselect.Name = "btnUnselect";
            _btnUnselect.Size = new Size(96, 23);
            _btnUnselect.TabIndex = 37;
            _btnUnselect.Text = "Unselect All";
            //
            // grpFilter
            //
            _grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpFilter.Controls.Add(_Label1);
            _grpFilter.Controls.Add(_btnUnselect);
            _grpFilter.Controls.Add(_btnSelectAll);
            _grpFilter.Controls.Add(_btnShowdata);
            _grpFilter.Controls.Add(_dtpTo);
            _grpFilter.Controls.Add(_dtpFrom);
            _grpFilter.Controls.Add(_Label9);
            _grpFilter.Controls.Add(_Label8);
            _grpFilter.Location = new Point(8, 32);
            _grpFilter.Name = "grpFilter";
            _grpFilter.Size = new Size(784, 83);
            _grpFilter.TabIndex = 1;
            _grpFilter.TabStop = false;
            _grpFilter.Text = "Filter";
            //
            // Label1
            //
            _Label1.AutoSize = true;
            _Label1.Location = new Point(8, 24);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(62, 13);
            _Label1.TabIndex = 38;
            _Label1.Text = "Visit Date";
            //
            // FRMBatchVisitCosts
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(800, 494);
            Controls.Add(_btnExport);
            Controls.Add(_grpEngineerVisits);
            Controls.Add(_grpFilter);
            MinimumSize = new Size(808, 528);
            Name = "FRMBatchVisitCosts";
            Text = "Batch Visit Costs Data Report";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpFilter, 0);
            Controls.SetChildIndex(_grpEngineerVisits, 0);
            Controls.SetChildIndex(_btnExport, 0);
            _grpEngineerVisits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgVisits).EndInit();
            _grpFilter.ResumeLayout(false);
            _grpFilter.PerformLayout();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupVisitDataGrid();
            PopulateDatagrid();
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
                _dvVisits.AllowNew = false;
                _dvVisits.AllowEdit = true;
                _dvVisits.AllowDelete = false;
                _dvVisits.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString();
                dgVisits.DataSource = VisitsDataview;
            }
        }

        private DataRow SelectedVisitDataRow
        {
            get
            {
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void SetupVisitDataGrid()
        {
            var tbStyle = dgVisits.TableStyles[0];
            var tick = new DataGridBoolColumn();
            tick.HeaderText = "";
            tick.MappingName = "tick";
            tick.ReadOnly = false;
            tick.Width = 25;
            tbStyle.GridColumnStyles.Add(tick);
            var StartDateTime = new DataGridLabelColumn();
            StartDateTime.Format = "";
            StartDateTime.FormatInfo = null;
            StartDateTime.HeaderText = "StartDateTime";
            StartDateTime.MappingName = "StartDateTime";
            StartDateTime.ReadOnly = true;
            StartDateTime.Width = 150;
            StartDateTime.NullText = "";
            tbStyle.GridColumnStyles.Add(StartDateTime);
            var VisitStatus = new DataGridLabelColumn();
            VisitStatus.Format = "";
            VisitStatus.FormatInfo = null;
            VisitStatus.HeaderText = "VisitStatus";
            VisitStatus.MappingName = "VisitStatus";
            VisitStatus.ReadOnly = true;
            VisitStatus.Width = 150;
            VisitStatus.NullText = "";
            tbStyle.GridColumnStyles.Add(VisitStatus);
            var NotesToEngineer = new DataGridLabelColumn();
            NotesToEngineer.Format = "";
            NotesToEngineer.FormatInfo = null;
            NotesToEngineer.HeaderText = "NotesToEngineer";
            NotesToEngineer.MappingName = "NotesToEngineer";
            NotesToEngineer.ReadOnly = true;
            NotesToEngineer.Width = 150;
            NotesToEngineer.NullText = "";
            tbStyle.GridColumnStyles.Add(NotesToEngineer);
            var NotesFromEngineer = new DataGridLabelColumn();
            NotesFromEngineer.Format = "";
            NotesFromEngineer.FormatInfo = null;
            NotesFromEngineer.HeaderText = "NotesFromEngineer";
            NotesFromEngineer.MappingName = "NotesFromEngineer";
            NotesFromEngineer.ReadOnly = true;
            NotesFromEngineer.Width = 150;
            NotesFromEngineer.NullText = "";
            tbStyle.GridColumnStyles.Add(NotesFromEngineer);
            var OutcomeDetails = new DataGridLabelColumn();
            OutcomeDetails.Format = "";
            OutcomeDetails.FormatInfo = null;
            OutcomeDetails.HeaderText = "OutcomeDetails";
            OutcomeDetails.MappingName = "OutcomeDetails";
            OutcomeDetails.ReadOnly = true;
            OutcomeDetails.Width = 150;
            OutcomeDetails.NullText = "";
            tbStyle.GridColumnStyles.Add(OutcomeDetails);
            var VisitOutcome = new DataGridLabelColumn();
            VisitOutcome.Format = "";
            VisitOutcome.FormatInfo = null;
            VisitOutcome.HeaderText = "VisitOutcome";
            VisitOutcome.MappingName = "VisitOutcome";
            VisitOutcome.ReadOnly = true;
            VisitOutcome.Width = 150;
            VisitOutcome.NullText = "";
            tbStyle.GridColumnStyles.Add(VisitOutcome);
            var Customer = new DataGridLabelColumn();
            Customer.Format = "";
            Customer.FormatInfo = null;
            Customer.HeaderText = "Customer";
            Customer.MappingName = "Customer";
            Customer.ReadOnly = true;
            Customer.Width = 150;
            Customer.NullText = "";
            tbStyle.GridColumnStyles.Add(Customer);
            var ForSageAccountCode = new DataGridLabelColumn();
            ForSageAccountCode.Format = "";
            ForSageAccountCode.FormatInfo = null;
            ForSageAccountCode.HeaderText = "ForSageAccountCode";
            ForSageAccountCode.MappingName = "ForSageAccountCode";
            ForSageAccountCode.ReadOnly = true;
            ForSageAccountCode.Width = 150;
            ForSageAccountCode.NullText = "";
            tbStyle.GridColumnStyles.Add(ForSageAccountCode);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Site";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 100;
            Site.NullText = "";
            tbStyle.GridColumnStyles.Add(Site);
            var Postcode = new DataGridLabelColumn();
            Postcode.Format = "";
            Postcode.FormatInfo = null;
            Postcode.HeaderText = "Postcode";
            Postcode.MappingName = "SitePostcode";
            Postcode.ReadOnly = true;
            Postcode.Width = 75;
            Postcode.NullText = "";
            tbStyle.GridColumnStyles.Add(Postcode);
            var JobID = new DataGridLabelColumn();
            JobID.Format = "";
            JobID.FormatInfo = null;
            JobID.HeaderText = "JobID";
            JobID.MappingName = "JobID";
            JobID.ReadOnly = true;
            JobID.Width = 75;
            JobID.NullText = "";
            tbStyle.GridColumnStyles.Add(JobID);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job Number";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 75;
            JobNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(JobNumber);
            var JobDefinition = new DataGridLabelColumn();
            JobDefinition.Format = "";
            JobDefinition.FormatInfo = null;
            JobDefinition.HeaderText = "JobDefinition";
            JobDefinition.MappingName = "JobDefinition";
            JobDefinition.ReadOnly = true;
            JobDefinition.Width = 75;
            JobDefinition.NullText = "";
            tbStyle.GridColumnStyles.Add(JobDefinition);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 75;
            Type.NullText = "";
            tbStyle.GridColumnStyles.Add(Type);
            var Engineer = new DataGridLabelColumn();
            Engineer.Format = "";
            Engineer.FormatInfo = null;
            Engineer.HeaderText = "Engineer";
            Engineer.MappingName = "Engineer";
            Engineer.ReadOnly = true;
            Engineer.Width = 75;
            Engineer.NullText = "";
            tbStyle.GridColumnStyles.Add(Engineer);
            var VisitCharge = new DataGridLabelColumn();
            VisitCharge.Format = "";
            VisitCharge.FormatInfo = null;
            VisitCharge.HeaderText = "VisitCharge";
            VisitCharge.MappingName = "VisitCharge";
            VisitCharge.ReadOnly = true;
            VisitCharge.Width = 75;
            VisitCharge.NullText = "";
            tbStyle.GridColumnStyles.Add(VisitCharge);
            var EngineerCost = new DataGridLabelColumn();
            EngineerCost.Format = "";
            EngineerCost.FormatInfo = null;
            EngineerCost.HeaderText = "EngineerCost";
            EngineerCost.MappingName = "EngineerCost";
            EngineerCost.ReadOnly = true;
            EngineerCost.Width = 75;
            EngineerCost.NullText = "";
            tbStyle.GridColumnStyles.Add(EngineerCost);
            var PartProductCost = new DataGridLabelColumn();
            PartProductCost.Format = "";
            PartProductCost.FormatInfo = null;
            PartProductCost.HeaderText = "PartProductCost";
            PartProductCost.MappingName = "PartProductCost";
            PartProductCost.ReadOnly = true;
            PartProductCost.Width = 75;
            PartProductCost.NullText = "";
            tbStyle.GridColumnStyles.Add(PartProductCost);
            var PartsToFit = new DataGridLabelColumn();
            PartsToFit.Format = "";
            PartsToFit.FormatInfo = null;
            PartsToFit.HeaderText = "PartsToFit";
            PartsToFit.MappingName = "PartsToFit";
            PartsToFit.ReadOnly = true;
            PartsToFit.Width = 75;
            PartsToFit.NullText = "";
            tbStyle.GridColumnStyles.Add(PartsToFit);
            var SupInvoice = new DataGridLabelColumn();
            SupInvoice.Format = "";
            SupInvoice.FormatInfo = null;
            SupInvoice.HeaderText = "SupInvoice";
            SupInvoice.MappingName = "SupInvoice";
            SupInvoice.ReadOnly = true;
            SupInvoice.Width = 75;
            SupInvoice.NullText = "";
            tbStyle.GridColumnStyles.Add(SupInvoice);
            var Credit = new DataGridLabelColumn();
            // DefectCount.Format = "C"
            Credit.FormatInfo = null;
            Credit.HeaderText = "Credit";
            Credit.MappingName = "Credit";
            Credit.ReadOnly = true;
            Credit.Width = 100;
            Credit.NullText = "";
            tbStyle.GridColumnStyles.Add(Credit);
            var ContractType = new DataGridLabelColumn();
            // DefectCount.Format = "C"
            ContractType.FormatInfo = null;
            ContractType.HeaderText = "ContractType";
            ContractType.MappingName = "ContractType";
            ContractType.ReadOnly = true;
            ContractType.Width = 100;
            ContractType.NullText = "";
            tbStyle.GridColumnStyles.Add(ContractType);
            var Jobitems = new DataGridLabelColumn();
            // DefectCount.Format = "C"
            Jobitems.FormatInfo = null;
            Jobitems.HeaderText = "Jobitems";
            Jobitems.MappingName = "Jobitems";
            Jobitems.ReadOnly = true;
            Jobitems.Width = 100;
            Jobitems.NullText = "";
            tbStyle.GridColumnStyles.Add(Jobitems);

            // dt.Columns.Add("ExceptionAppMake")
            var Department = new DataGridLabelColumn();
            // DefectCount.Format = "C"
            Department.FormatInfo = null;
            Department.HeaderText = "Department";
            Department.MappingName = "Department";
            Department.ReadOnly = true;
            Department.Width = 100;
            Department.NullText = "";
            tbStyle.GridColumnStyles.Add(Department);

            // dt.Columns.Add("ExceptionAppModel")
            var NominalCode = new DataGridLabelColumn();
            // DefectCount.Format = "C"
            NominalCode.FormatInfo = null;
            NominalCode.HeaderText = "NominalCode";
            NominalCode.MappingName = "NominalCode";
            NominalCode.ReadOnly = true;
            NominalCode.Width = 100;
            NominalCode.NullText = "";
            tbStyle.GridColumnStyles.Add(NominalCode);

            // dt.Columns.Add("ExceptionAppLLAppliance")
            var JobValue = new DataGridLabelColumn();
            // DefectCount.Format = "C"
            JobValue.FormatInfo = null;
            JobValue.HeaderText = "JobValue";
            JobValue.MappingName = "JobValue";
            JobValue.ReadOnly = true;
            JobValue.Width = 100;
            JobValue.NullText = "";
            tbStyle.GridColumnStyles.Add(JobValue);
            tbStyle.ReadOnly = false;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString();
            dgVisits.TableStyles.Add(tbStyle);
        }

        public DataRow SelectedJobRow
        {
            get
            {
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

        private void FRMVisitManager_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void btnShowdata_Click(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void dgVisits_MouseUp(object sender, MouseEventArgs e)
        {
            // Dim HitTestInfo As DataGrid.HitTestInfo
            // HitTestInfo = dgVisits.HitTest(e.X, e.Y)
            // If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
            // If HitTestInfo.Column = 0 Then
            // Dim selected As Boolean = Not Entity.Sys.Helper.MakeBooleanValid(SelectedVisitDataRow.Item("tick"))
            // SelectedVisitDataRow.Item("Tick") = selected
            // End If
            // End If
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in VisitsDataview.Table.Rows)
                dr["tick"] = true;
        }

        private void btnUnselect_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in VisitsDataview.Table.Rows)
                dr["tick"] = false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Dim dtExport As New DataTable
            // dtExport.Columns.Add("Customer")
            // dtExport.Columns.Add("Site")
            // dtExport.Columns.Add("JobNumber")
            // dtExport.Columns.Add("Definition")
            // dtExport.Columns.Add("Type")
            // dtExport.Columns.Add("Status")
            // dtExport.Columns.Add("Outcome")
            // dtExport.Columns.Add("ScheduledDate")
            // dtExport.Columns.Add("Engineer")
            // dtExport.Columns.Add("TypeMakeModel")
            // dtExport.Columns.Add("ExceptionType")
            // dtExport.Columns.Add("ExceptionAppLocation")
            // dtExport.Columns.Add("ExceptionAppType")
            // dtExport.Columns.Add("ExceptionAppMake")
            // dtExport.Columns.Add("ExceptionAppModel")
            // dtExport.Columns.Add("ExceptionAppLLAppliance")
            // dtExport.Columns.Add("ExceptionAppServicedOrInspected")
            // dtExport.Columns.Add("ExceptionAppSafe")
            // dtExport.Columns.Add("ExceptionAppFlueSatisfactory")
            // dtExport.Columns.Add("ExceptionAppFlueVisual")
            // dtExport.Columns.Add("ExceptionAppFlueFlowTest")
            // dtExport.Columns.Add("ExceptionAppFlueSpillageTest")
            // dtExport.Columns.Add("ExceptionAppVentilationSatisfactory")
            // dtExport.Columns.Add("ExceptionAppSafetyOperation")
            // dtExport.Columns.Add("ExceptionAppInletStaticPressure")
            // dtExport.Columns.Add("ExceptionAppInletWorkingPressure")
            // dtExport.Columns.Add("ExceptionAppHeatInput")
            // dtExport.Columns.Add("ExceptionAppMaxBurnerPressure")
            // dtExport.Columns.Add("ExceptionAppCO2")
            // dtExport.Columns.Add("ExceptionAppCo2CoRatio")

            // Dim nr As DataRow

            // For Each dr As DataRow In VisitsDataview.Table.Rows
            // If dr("Tick") = True Then

            // Dim nr As DataRow
            // nr = dtExport.NewRow
            // nr("Customer") = dr("Customer")
            // nr("Site") = dr("Site")
            // nr("JobNumber") = dr("JobNumber")
            // nr("Definition") = dr("Definition")
            // nr("Type") = dr("Type")
            // nr("Status") = dr("Status")
            // nr("Outcome") = dr("Outcome")
            // nr("ScheduledDate") = dr("ScheduledDate")
            // nr("Engineer") = dr("Engineer")
            // nr("TypeMakeModel") = dr("TypeMakeModel")
            // nr("ExceptionType") = dr("ExceptionType")
            // nr("ExceptionAppLocation") = dr("ExceptionAppLocation")
            // nr("ExceptionAppType") = dr("ExceptionAppType")
            // nr("ExceptionAppMake") = dr("ExceptionAppMake")
            // nr("ExceptionAppModel") = dr("ExceptionAppModel")
            // nr("ExceptionAppLLAppliance") = dr("ExceptionAppLLAppliance")
            // nr("ExceptionAppServicedOrInspected") = dr("ExceptionAppServicedOrInspected")
            // nr("ExceptionAppSafe") = dr("ExceptionAppSafe")
            // nr("ExceptionAppFlueSatisfactory") = dr("ExceptionAppFlueSatisfactory")
            // nr("ExceptionAppFlueVisual") = dr("ExceptionAppFlueVisual")
            // nr("ExceptionAppFlueFlowTest") = dr("ExceptionAppFlueFlowTest")
            // nr("ExceptionAppFlueSpillageTest") = dr("ExceptionAppFlueSpillageTest")
            // nr("ExceptionAppVentilationSatisfactory") = dr("ExceptionAppVentilationSatisfactory")
            // nr("ExceptionAppSafetyOperation") = dr("ExceptionAppSafetyOperation")
            // nr("ExceptionAppInletStaticPressure") = dr("ExceptionAppInletStaticPressure")
            // nr("ExceptionAppInletWorkingPressure") = dr("ExceptionAppInletWorkingPressure")
            // nr("ExceptionAppHeatInput") = dr("ExceptionAppHeatInput")
            // nr("ExceptionAppMaxBurnerPressure") = dr("ExceptionAppMaxBurnerPressure")
            // nr("ExceptionAppCO2") = dr("ExceptionAppCO2")
            // nr("ExceptionAppCo2CoRatio") = dr("ExceptionAppCo2CoRatio")
            // dtExport.Rows.Add(nr)
            // End If
            // Next
            // If Not dtExport.Rows.Count = 0 Then
            // Dim exporter As New Entity.Sys.Exporting(dtExport, "Gas Summary Spec")
            // exporter = Nothing
            // End If
            Export();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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
                    VisitsDataview = (DataView)get_GetParameter(0);
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
            dtpFrom.Value = DateAndTime.Today.AddDays(-1);
            dtpTo.Value = DateAndTime.Today.AddMonths(-1);
            dtpFrom.Enabled = true;
            dtpTo.Enabled = true;
            grpFilter.Enabled = true;
        }

        private void RunFilter()
        {
            string whereClause;

            // If Me.chkVisitDate.Checked Then
            whereClause = "WHERE tblEngineerVisit.Deleted = 0 AND tblJobOfWork.Deleted = 0 AND tblJob.Deleted = 0 AND (tblInvoiceToBeRaised.InvoiceTypeID = 260 OR tblInvoiceToBeRaised.InvoiceTypeID is null) AND (DATEADD(dd, 0, DATEDIFF(dd, 0, tblEngineerVisit.StartDateTime))>= CONVERT(DATETIME, '" + Strings.Format(dtpFrom.Value, "yyyy-MM-dd 00:00:00") + "', 102)) AND (DATEADD(dd, 0, DATEDIFF(dd, 0, tblEngineerVisit.StartDateTime))<= CONVERT(DATETIME, '" + Strings.Format(dtpTo.Value, "yyyy-MM-dd 23:59:59") + "', 102)) AND (tblEngineerVisit.Deleted = 0)";
            // End If

            VisitsDataview = App.DB.Reports.Reports_BatchVisitCosts(whereClause);
            grpEngineerVisits.Text = "Visits: " + VisitsDataview.Table.Rows.Count;
        }

        public void Export()
        {
            var exportData = new DataTable();
            // exportData.Columns.Add("Customer")
            // exportData.Columns.Add("Site")
            // exportData.Columns.Add("SitePostcode")
            // exportData.Columns.Add("JobNumber")
            // exportData.Columns.Add("PONumber")
            // exportData.Columns.Add("JobDefinition")
            // exportData.Columns.Add("Type")
            // exportData.Columns.Add("VisitStatus")
            // exportData.Columns.Add("StartDateTime")
            // exportData.Columns.Add("Engineer")
            // exportData.Columns.Add("VisitValue", GetType(Double))
            // exportData.Columns.Add("VisitCharge")
            // exportData.Columns.Add("EngineerCost", GetType(Double))
            // exportData.Columns.Add("PartProductCost", GetType(Double))

            exportData.Columns.Add("StartDateTime", typeof(DateTime));
            exportData.Columns.Add("VisitStatus");
            exportData.Columns.Add("NotesToEngineer");
            exportData.Columns.Add("NotesFromEngineer");
            exportData.Columns.Add("OutcomeDetails");
            exportData.Columns.Add("VisitOutcome");
            exportData.Columns.Add("Customer");
            exportData.Columns.Add("ForSageAccountCode");
            exportData.Columns.Add("Site");
            exportData.Columns.Add("Postcode");
            exportData.Columns.Add("JobID");
            exportData.Columns.Add("JobNumber");
            exportData.Columns.Add("JobDefinition");
            exportData.Columns.Add("Type");
            exportData.Columns.Add("Engineer");
            exportData.Columns.Add("VisitCharge", typeof(double));
            exportData.Columns.Add("EngineerCost");
            exportData.Columns.Add("PartProductCost");
            exportData.Columns.Add("PartsToFit");
            exportData.Columns.Add("SupInvoice");
            exportData.Columns.Add("Credit");
            exportData.Columns.Add("ContractType");
            exportData.Columns.Add("Jobitems");
            exportData.Columns.Add("Department");
            exportData.Columns.Add("NominalCode");
            exportData.Columns.Add("JobValue", typeof(double));
            exportData.Columns.Add("WorkingHours");
            exportData.Columns.Add("TravelingHours");
            for (int itm = 0, loopTo = ((DataView)dgVisits.DataSource).Count - 1; itm <= loopTo; itm++)
            {
                dgVisits.CurrentRowIndex = itm;
                DataRow newRw;
                newRw = exportData.NewRow();

                // newRw("Customer") = SelectedVisitDataRow("Customer")
                // newRw("Site") = SelectedVisitDataRow("Site")
                // newRw("SitePostcode") = SelectedVisitDataRow("SitePostcode")
                // newRw("JobNumber") = SelectedVisitDataRow("JobNumber")
                // newRw("PONumber") = SelectedVisitDataRow("PONumber")
                // newRw("JobDefinition") = SelectedVisitDataRow("JobDefinition")
                // newRw("Type") = SelectedVisitDataRow("Type")
                // newRw("VisitStatus") = SelectedVisitDataRow("VisitStatus")
                // newRw("StartDateTime") = SelectedVisitDataRow("StartDateTime")
                // newRw("Engineer") = SelectedVisitDataRow("Engineer")
                // newRw("VisitValue") = SelectedVisitDataRow("VisitValue")
                // newRw("VisitCharge") = SelectedVisitDataRow("VisitCharge")
                // newRw("EngineerCost") = SelectedVisitDataRow("EngineerCost")
                // newRw("PartProductCost") = SelectedVisitDataRow("PartProductCost")

                newRw["StartDateTime"] = SelectedVisitDataRow["StartDateTime"];
                newRw["VisitStatus"] = SelectedVisitDataRow["VisitStatus"];
                newRw["NotesToEngineer"] = SelectedVisitDataRow["NotesToEngineer"];
                newRw["NotesFromEngineer"] = SelectedVisitDataRow["NotesFromEngineer"];
                newRw["OutcomeDetails"] = SelectedVisitDataRow["OutcomeDetails"];
                newRw["VisitOutcome"] = SelectedVisitDataRow["VisitOutcome"];
                newRw["Customer"] = SelectedVisitDataRow["Customer"];
                newRw["ForSageAccountCode"] = SelectedVisitDataRow["ForSageAccountCode"];
                newRw["Site"] = SelectedVisitDataRow["Site"];
                newRw["Postcode"] = SelectedVisitDataRow["Postcode"];
                newRw["JobID"] = SelectedVisitDataRow["JobID"];
                newRw["JobNumber"] = SelectedVisitDataRow["JobNumber"];
                newRw["JobDefinition"] = SelectedVisitDataRow["JobDefinition"];
                newRw["Type"] = SelectedVisitDataRow["Type"];
                newRw["Engineer"] = SelectedVisitDataRow["Engineer"];
                newRw["VisitCharge"] = SelectedVisitDataRow["VisitCharge"];
                newRw["EngineerCost"] = SelectedVisitDataRow["EngineerCost"];
                newRw["PartProductCost"] = SelectedVisitDataRow["PartProductCost"];
                newRw["PartsToFit"] = SelectedVisitDataRow["PartsToFit"];
                newRw["SupInvoice"] = SelectedVisitDataRow["SupInvoice"];
                newRw["Credit"] = SelectedVisitDataRow["Credit"];
                newRw["ContractType"] = SelectedVisitDataRow["ContractType"];
                newRw["Jobitems"] = SelectedVisitDataRow["Jobitems"];
                newRw["Department"] = SelectedVisitDataRow["Department"];
                newRw["NominalCode"] = SelectedVisitDataRow["NominalCode"];
                newRw["JobValue"] = SelectedVisitDataRow["JobValue"];
                newRw["WorkingHours"] = SelectedVisitDataRow["WorkingHours"];
                newRw["TravelingHours"] = SelectedVisitDataRow["TravelingHours"];
                exportData.Rows.Add(newRw);
                dgVisits.UnSelect(itm);
            }

            Entity.Sys.ExportHelper.Export(exportData, "Batch Visit Costs Report", Entity.Sys.Enums.ExportType.CSV);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}