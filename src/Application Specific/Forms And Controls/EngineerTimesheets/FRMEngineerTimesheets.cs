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
    public class FRMEngineerTimesheets : FRMBaseForm, IForm
    {
        public FRMEngineerTimesheets() : base()
        {
            base.Load += FRMOrderManager_Load;

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

        private CheckBox _chkDateCreated;

        internal CheckBox chkDateCreated
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkDateCreated;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkDateCreated != null)
                {
                    _chkDateCreated.CheckedChanged -= chkDateCreated_CheckedChanged;
                }

                _chkDateCreated = value;
                if (_chkDateCreated != null)
                {
                    _chkDateCreated.CheckedChanged += chkDateCreated_CheckedChanged;
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
                    _dgTimesheets.DoubleClick -= dgTimesheets_DoubleClick;
                }

                _dgTimesheets = value;
                if (_dgTimesheets != null)
                {
                    _dgTimesheets.DoubleClick += dgTimesheets_DoubleClick;
                }
            }
        }

        private Label _lblSearch;

        private Button _btnFindRecord;

        internal Button btnFindRecord
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindRecord;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindRecord != null)
                {
                    _btnFindRecord.Click -= btnFindRecord_Click;
                }

                _btnFindRecord = value;
                if (_btnFindRecord != null)
                {
                    _btnFindRecord.Click += btnFindRecord_Click;
                }
            }
        }

        private Button _btnFind;

        internal Button btnFind
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFind;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFind != null)
                {
                    _btnFind.Click -= btnFind_Click;
                }

                _btnFind = value;
                if (_btnFind != null)
                {
                    _btnFind.Click += btnFind_Click;
                }
            }
        }

        private Button _btnAdd;

        internal Button btnAdd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAdd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAdd != null)
                {
                    _btnAdd.Click -= btnAdd_Click;
                }

                _btnAdd = value;
                if (_btnAdd != null)
                {
                    _btnAdd.Click += btnAdd_Click;
                }
            }
        }

        private Button _btnDelete;

        internal Button btnDelete
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDelete;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDelete != null)
                {
                    _btnDelete.Click -= btnDelete_Click;
                }

                _btnDelete = value;
                if (_btnDelete != null)
                {
                    _btnDelete.Click += btnDelete_Click;
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

        private Label _Label2;

        internal Label Label2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label2 != null)
                {
                }

                _Label2 = value;
                if (_Label2 != null)
                {
                }
            }
        }

        private TextBox _txtaddress;

        internal TextBox txtaddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtaddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtaddress != null)
                {
                }

                _txtaddress = value;
                if (_txtaddress != null)
                {
                }
            }
        }

        private TextBox _txtSearch;

        internal TextBox txtSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSearch != null)
                {
                }

                _txtSearch = value;
                if (_txtSearch != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpJobs = new GroupBox();
            _dgTimesheets = new DataGrid();
            _dgTimesheets.DoubleClick += new EventHandler(dgTimesheets_DoubleClick);
            _grpFilter = new GroupBox();
            _Label1 = new Label();
            _txtJobNumber = new TextBox();
            _btnFind = new Button();
            _btnFind.Click += new EventHandler(btnFind_Click);
            _btnFindRecord = new Button();
            _btnFindRecord.Click += new EventHandler(btnFindRecord_Click);
            _txtSearch = new TextBox();
            _dtpTo = new DateTimePicker();
            _dtpFrom = new DateTimePicker();
            _Label9 = new Label();
            _Label8 = new Label();
            _chkDateCreated = new CheckBox();
            _chkDateCreated.CheckedChanged += new EventHandler(chkDateCreated_CheckedChanged);
            _lblSearch = new Label();
            _Label10 = new Label();
            _cboType = new ComboBox();
            _btnReset = new Button();
            _btnReset.Click += new EventHandler(btnReset_Click);
            _btnAdd = new Button();
            _btnAdd.Click += new EventHandler(btnAdd_Click);
            _btnDelete = new Button();
            _btnDelete.Click += new EventHandler(btnDelete_Click);
            _Label2 = new Label();
            _txtaddress = new TextBox();
            _grpJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgTimesheets).BeginInit();
            _grpFilter.SuspendLayout();
            SuspendLayout();
            //
            // grpJobs
            //
            _grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpJobs.Controls.Add(_dgTimesheets);
            _grpJobs.Location = new Point(8, 217);
            _grpJobs.Name = "grpJobs";
            _grpJobs.Size = new Size(828, 303);
            _grpJobs.TabIndex = 2;
            _grpJobs.TabStop = false;
            _grpJobs.Text = "Double Click To View / Edit";
            //
            // dgTimesheets
            //
            _dgTimesheets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgTimesheets.DataMember = "";
            _dgTimesheets.HeaderForeColor = SystemColors.ControlText;
            _dgTimesheets.Location = new Point(8, 30);
            _dgTimesheets.Name = "dgTimesheets";
            _dgTimesheets.Size = new Size(812, 265);
            _dgTimesheets.TabIndex = 11;
            //
            // grpFilter
            //
            _grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpFilter.Controls.Add(_Label2);
            _grpFilter.Controls.Add(_txtaddress);
            _grpFilter.Controls.Add(_Label1);
            _grpFilter.Controls.Add(_txtJobNumber);
            _grpFilter.Controls.Add(_btnFind);
            _grpFilter.Controls.Add(_btnFindRecord);
            _grpFilter.Controls.Add(_txtSearch);
            _grpFilter.Controls.Add(_dtpTo);
            _grpFilter.Controls.Add(_dtpFrom);
            _grpFilter.Controls.Add(_Label9);
            _grpFilter.Controls.Add(_Label8);
            _grpFilter.Controls.Add(_chkDateCreated);
            _grpFilter.Controls.Add(_lblSearch);
            _grpFilter.Controls.Add(_Label10);
            _grpFilter.Controls.Add(_cboType);
            _grpFilter.Location = new Point(8, 40);
            _grpFilter.Name = "grpFilter";
            _grpFilter.Size = new Size(828, 171);
            _grpFilter.TabIndex = 1;
            _grpFilter.TabStop = false;
            _grpFilter.Text = "Filter";
            //
            // Label1
            //
            _Label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label1.Location = new Point(518, 111);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(112, 20);
            _Label1.TabIndex = 20;
            _Label1.Text = "Job Number";
            //
            // txtJobNumber
            //
            _txtJobNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtJobNumber.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtJobNumber.Location = new Point(636, 110);
            _txtJobNumber.Name = "txtJobNumber";
            _txtJobNumber.Size = new Size(184, 21);
            _txtJobNumber.TabIndex = 19;
            //
            // btnFind
            //
            _btnFind.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFind.BackColor = Color.White;
            _btnFind.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFind.Location = new Point(728, 140);
            _btnFind.Name = "btnFind";
            _btnFind.Size = new Size(92, 23);
            _btnFind.TabIndex = 18;
            _btnFind.Text = "Find";
            _btnFind.UseVisualStyleBackColor = false;
            //
            // btnFindRecord
            //
            _btnFindRecord.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindRecord.BackColor = Color.White;
            _btnFindRecord.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindRecord.Location = new Point(788, 51);
            _btnFindRecord.Name = "btnFindRecord";
            _btnFindRecord.Size = new Size(32, 23);
            _btnFindRecord.TabIndex = 17;
            _btnFindRecord.Text = "...";
            _btnFindRecord.UseVisualStyleBackColor = false;
            //
            // txtSearch
            //
            _txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSearch.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtSearch.Location = new Point(136, 53);
            _txtSearch.Name = "txtSearch";
            _txtSearch.ReadOnly = true;
            _txtSearch.Size = new Size(644, 21);
            _txtSearch.TabIndex = 16;
            //
            // dtpTo
            //
            _dtpTo.Location = new Point(184, 118);
            _dtpTo.Name = "dtpTo";
            _dtpTo.Size = new Size(224, 21);
            _dtpTo.TabIndex = 10;
            //
            // dtpFrom
            //
            _dtpFrom.Location = new Point(184, 86);
            _dtpFrom.Name = "dtpFrom";
            _dtpFrom.Size = new Size(224, 21);
            _dtpFrom.TabIndex = 9;
            //
            // Label9
            //
            _Label9.Location = new Point(136, 115);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(48, 16);
            _Label9.TabIndex = 10;
            _Label9.Text = "To";
            //
            // Label8
            //
            _Label8.Location = new Point(136, 83);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(48, 16);
            _Label8.TabIndex = 9;
            _Label8.Text = "From";
            //
            // chkDateCreated
            //
            _chkDateCreated.Cursor = Cursors.Hand;
            _chkDateCreated.UseVisualStyleBackColor = true;
            _chkDateCreated.Location = new Point(17, 86);
            _chkDateCreated.Name = "chkDateCreated";
            _chkDateCreated.Size = new Size(104, 24);
            _chkDateCreated.TabIndex = 8;
            _chkDateCreated.Text = "Date Between";
            //
            // lblSearch
            //
            _lblSearch.Location = new Point(16, 53);
            _lblSearch.Name = "lblSearch";
            _lblSearch.Size = new Size(112, 20);
            _lblSearch.TabIndex = 2;
            _lblSearch.Text = "Engineer";
            //
            // Label10
            //
            _Label10.Location = new Point(16, 25);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(48, 20);
            _Label10.TabIndex = 4;
            _Label10.Text = "Type";
            //
            // cboType
            //
            _cboType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboType.Location = new Point(136, 22);
            _cboType.Name = "cboType";
            _cboType.Size = new Size(684, 21);
            _cboType.TabIndex = 1;
            //
            // btnReset
            //
            _btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnReset.Location = new Point(8, 526);
            _btnReset.Name = "btnReset";
            _btnReset.Size = new Size(56, 23);
            _btnReset.TabIndex = 13;
            _btnReset.Text = "Reset";
            //
            // btnAdd
            //
            _btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnAdd.Location = new Point(772, 526);
            _btnAdd.Name = "btnAdd";
            _btnAdd.Size = new Size(56, 23);
            _btnAdd.TabIndex = 14;
            _btnAdd.Text = "Add";
            //
            // btnDelete
            //
            _btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnDelete.Location = new Point(70, 526);
            _btnDelete.Name = "btnDelete";
            _btnDelete.Size = new Size(56, 23);
            _btnDelete.TabIndex = 15;
            _btnDelete.Text = "Delete";
            //
            // Label2
            //
            _Label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label2.Location = new Point(518, 84);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(112, 20);
            _Label2.TabIndex = 22;
            _Label2.Text = "Address";
            //
            // txtaddress
            //
            _txtaddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _txtaddress.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtaddress.Location = new Point(636, 83);
            _txtaddress.Name = "txtaddress";
            _txtaddress.Size = new Size(184, 21);
            _txtaddress.TabIndex = 21;
            //
            // FRMEngineerTimesheets
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(844, 558);
            Controls.Add(_btnDelete);
            Controls.Add(_btnAdd);
            Controls.Add(_grpFilter);
            Controls.Add(_grpJobs);
            Controls.Add(_btnReset);
            MinimumSize = new Size(852, 592);
            Name = "FRMEngineerTimesheets";
            Text = "Engineer General Timesheets Manager";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_btnReset, 0);
            Controls.SetChildIndex(_grpJobs, 0);
            Controls.SetChildIndex(_grpFilter, 0);
            Controls.SetChildIndex(_btnAdd, 0);
            Controls.SetChildIndex(_btnDelete, 0);
            _grpJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgTimesheets).EndInit();
            _grpFilter.ResumeLayout(false);
            _grpFilter.PerformLayout();
            ResumeLayout(false);
        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupTimesheetsDataGrid();
            var argc = cboType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.TimeSheetTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter);
            ResetFilters();
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
                _dvTimesheets.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerTimesheet.ToString();
                dgTimesheets.DataSource = TimesheetsDataview;
            }
        }

        private DataRow SelectedTimesheetDataRow
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

        private Entity.Engineers.Engineer _oEngineer;

        public Entity.Engineers.Engineer oEngineer
        {
            get
            {
                return _oEngineer;
            }

            set
            {
                _oEngineer = value;
                if (_oEngineer is object)
                {
                    txtSearch.Text = oEngineer.Name;
                }
                else
                {
                    txtSearch.Text = "";
                }
            }
        }

        private void SetupTimesheetsDataGrid()
        {
            var tbStyle = dgTimesheets.TableStyles[0];
            var Engineer = new DataGridLabelColumn();
            Engineer.Format = "";
            Engineer.FormatInfo = null;
            Engineer.HeaderText = "Engineer";
            Engineer.MappingName = "Name";
            Engineer.ReadOnly = true;
            Engineer.Width = 250;
            Engineer.NullText = "";
            tbStyle.GridColumnStyles.Add(Engineer);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 150;
            Type.NullText = "";
            tbStyle.GridColumnStyles.Add(Type);
            var Comments = new DataGridLabelColumn();
            Comments.Format = "";
            Comments.FormatInfo = null;
            Comments.HeaderText = "Comments";
            Comments.MappingName = "Comments";
            Comments.ReadOnly = true;
            Comments.Width = 300;
            Comments.NullText = "";
            tbStyle.GridColumnStyles.Add(Comments);
            var StartDateTime = new DataGridLabelColumn();
            StartDateTime.Format = "dd/MM/yyyy HH:mm";
            StartDateTime.FormatInfo = null;
            StartDateTime.HeaderText = "Start Date/Time";
            StartDateTime.MappingName = "StartDateTime";
            StartDateTime.ReadOnly = true;
            StartDateTime.Width = 150;
            StartDateTime.NullText = "";
            tbStyle.GridColumnStyles.Add(StartDateTime);
            var EndDateTime = new DataGridLabelColumn();
            EndDateTime.Format = "dd/MM/yyyy HH:mm";
            EndDateTime.FormatInfo = null;
            EndDateTime.HeaderText = "End Date/Time";
            EndDateTime.MappingName = "EndDateTime";
            EndDateTime.ReadOnly = true;
            EndDateTime.Width = 150;
            EndDateTime.NullText = "";
            tbStyle.GridColumnStyles.Add(EndDateTime);
            var Address = new DataGridLabelColumn();
            Address.Format = "";
            Address.FormatInfo = null;
            Address.HeaderText = "Address";
            Address.MappingName = "Address";
            Address.ReadOnly = true;
            Address.Width = 300;
            Address.NullText = "";
            tbStyle.GridColumnStyles.Add(Address);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job Number";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 300;
            JobNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(JobNumber);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerTimesheet.ToString();
            dgTimesheets.TableStyles.Add(tbStyle);
        }

        private void FRMOrderManager_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void chkDateCreated_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDateCreated.Checked)
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

        private void dgTimesheets_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedTimesheetDataRow is null)
            {
                return;
            }

            App.ShowForm(typeof(FRMEngineerTimesheet), true, new object[] { SelectedTimesheetDataRow["EngineerTimeSheetID"], SelectedTimesheetDataRow["Source"] });
            RunFilter();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMEngineerTimesheet), true, new object[] { 0 });
            RunFilter();
        }

        private void btnFindRecord_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblEngineer));
            if (!(ID == 0))
            {
                oEngineer = App.DB.Engineer.Engineer_Get(ID);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedTimesheetDataRow is null)
            {
                return;
            }

            if (App.ShowMessage("Are you sure you want to delete this timesheet?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                App.DB.EngineerTimesheets.Delete(Conversions.ToInteger(SelectedTimesheetDataRow["EngineerTimeSheetID"]));
            }

            RunFilter();
        }

        private void ResetFilters()
        {
            var argcombo = cboType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            chkDateCreated.Checked = false;
            dtpFrom.Value = DateAndTime.Today;
            dtpFrom.Enabled = false;
            dtpTo.Value = DateAndTime.Today;
            dtpTo.Enabled = false;
            grpFilter.Enabled = true;
            txtSearch.Text = "";
        }

        private void RunFilter()
        {
            string whereClause = " WHERE 1=1 ";
            string whereClause2 = "";
            if (oEngineer is object)
            {
                whereClause += " AND tblEngineer.EngineerID = " + oEngineer.EngineerID + "";
            }

            if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboType)) == 0))
            {
                whereClause += " AND TimeSheetTypeID = " + Combo.get_GetSelectedItemValue(cboType) + "";
            }

            if (!(txtJobNumber.Text.Length == 0))
            {
                whereClause2 += " AND jobNumber = '" + txtJobNumber.Text + "'";
            }

            if (!(txtaddress.Text.Length == 0))
            {
                whereClause2 += " AND Address1 LIKE '%" + txtaddress.Text + "%'";
            }

            if (chkDateCreated.Checked)
            {
                whereClause += " AND TS.StartDateTime >= '" + Strings.Format(dtpFrom.Value, "dd/MMM/yyyy 00:00:00") + "' AND TS.EndDateTime <= '" + Strings.Format(dtpTo.Value, "dd/MMM/yyyy 23:59:59") + "'";
            }

            TimesheetsDataview = App.DB.EngineerTimesheets.GetAll(whereClause, whereClause2);
        }
    }
}