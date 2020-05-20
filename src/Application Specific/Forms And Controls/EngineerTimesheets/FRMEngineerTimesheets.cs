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
            this._grpJobs = new System.Windows.Forms.GroupBox();
            this._dgTimesheets = new System.Windows.Forms.DataGrid();
            this._grpFilter = new System.Windows.Forms.GroupBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._txtaddress = new System.Windows.Forms.TextBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._txtJobNumber = new System.Windows.Forms.TextBox();
            this._btnFind = new System.Windows.Forms.Button();
            this._btnFindRecord = new System.Windows.Forms.Button();
            this._txtSearch = new System.Windows.Forms.TextBox();
            this._dtpTo = new System.Windows.Forms.DateTimePicker();
            this._dtpFrom = new System.Windows.Forms.DateTimePicker();
            this._Label9 = new System.Windows.Forms.Label();
            this._Label8 = new System.Windows.Forms.Label();
            this._chkDateCreated = new System.Windows.Forms.CheckBox();
            this._lblSearch = new System.Windows.Forms.Label();
            this._Label10 = new System.Windows.Forms.Label();
            this._cboType = new System.Windows.Forms.ComboBox();
            this._btnReset = new System.Windows.Forms.Button();
            this._btnAdd = new System.Windows.Forms.Button();
            this._btnDelete = new System.Windows.Forms.Button();
            this._grpJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgTimesheets)).BeginInit();
            this._grpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpJobs
            // 
            this._grpJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpJobs.Controls.Add(this._dgTimesheets);
            this._grpJobs.Location = new System.Drawing.Point(8, 189);
            this._grpJobs.Name = "_grpJobs";
            this._grpJobs.Size = new System.Drawing.Size(828, 331);
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
            this._dgTimesheets.Location = new System.Drawing.Point(8, 30);
            this._dgTimesheets.Name = "_dgTimesheets";
            this._dgTimesheets.Size = new System.Drawing.Size(812, 293);
            this._dgTimesheets.TabIndex = 11;
            this._dgTimesheets.DoubleClick += new System.EventHandler(this.dgTimesheets_DoubleClick);
            // 
            // _grpFilter
            // 
            this._grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpFilter.Controls.Add(this._Label2);
            this._grpFilter.Controls.Add(this._txtaddress);
            this._grpFilter.Controls.Add(this._Label1);
            this._grpFilter.Controls.Add(this._txtJobNumber);
            this._grpFilter.Controls.Add(this._btnFind);
            this._grpFilter.Controls.Add(this._btnFindRecord);
            this._grpFilter.Controls.Add(this._txtSearch);
            this._grpFilter.Controls.Add(this._dtpTo);
            this._grpFilter.Controls.Add(this._dtpFrom);
            this._grpFilter.Controls.Add(this._Label9);
            this._grpFilter.Controls.Add(this._Label8);
            this._grpFilter.Controls.Add(this._chkDateCreated);
            this._grpFilter.Controls.Add(this._lblSearch);
            this._grpFilter.Controls.Add(this._Label10);
            this._grpFilter.Controls.Add(this._cboType);
            this._grpFilter.Location = new System.Drawing.Point(8, 12);
            this._grpFilter.Name = "_grpFilter";
            this._grpFilter.Size = new System.Drawing.Size(828, 171);
            this._grpFilter.TabIndex = 1;
            this._grpFilter.TabStop = false;
            this._grpFilter.Text = "Filter";
            // 
            // _Label2
            // 
            this._Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label2.Location = new System.Drawing.Point(518, 84);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(112, 20);
            this._Label2.TabIndex = 22;
            this._Label2.Text = "Address";
            // 
            // _txtaddress
            // 
            this._txtaddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtaddress.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtaddress.Location = new System.Drawing.Point(636, 83);
            this._txtaddress.Name = "_txtaddress";
            this._txtaddress.Size = new System.Drawing.Size(184, 21);
            this._txtaddress.TabIndex = 21;
            // 
            // _Label1
            // 
            this._Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label1.Location = new System.Drawing.Point(518, 111);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(112, 20);
            this._Label1.TabIndex = 20;
            this._Label1.Text = "Job Number";
            // 
            // _txtJobNumber
            // 
            this._txtJobNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtJobNumber.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtJobNumber.Location = new System.Drawing.Point(636, 110);
            this._txtJobNumber.Name = "_txtJobNumber";
            this._txtJobNumber.Size = new System.Drawing.Size(184, 21);
            this._txtJobNumber.TabIndex = 19;
            // 
            // _btnFind
            // 
            this._btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFind.BackColor = System.Drawing.Color.White;
            this._btnFind.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFind.Location = new System.Drawing.Point(728, 140);
            this._btnFind.Name = "_btnFind";
            this._btnFind.Size = new System.Drawing.Size(92, 23);
            this._btnFind.TabIndex = 18;
            this._btnFind.Text = "Find";
            this._btnFind.UseVisualStyleBackColor = false;
            this._btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // _btnFindRecord
            // 
            this._btnFindRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindRecord.BackColor = System.Drawing.Color.White;
            this._btnFindRecord.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindRecord.Location = new System.Drawing.Point(788, 51);
            this._btnFindRecord.Name = "_btnFindRecord";
            this._btnFindRecord.Size = new System.Drawing.Size(32, 23);
            this._btnFindRecord.TabIndex = 17;
            this._btnFindRecord.Text = "...";
            this._btnFindRecord.UseVisualStyleBackColor = false;
            this._btnFindRecord.Click += new System.EventHandler(this.btnFindRecord_Click);
            // 
            // _txtSearch
            // 
            this._txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSearch.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtSearch.Location = new System.Drawing.Point(136, 53);
            this._txtSearch.Name = "_txtSearch";
            this._txtSearch.ReadOnly = true;
            this._txtSearch.Size = new System.Drawing.Size(644, 21);
            this._txtSearch.TabIndex = 16;
            // 
            // _dtpTo
            // 
            this._dtpTo.Location = new System.Drawing.Point(184, 118);
            this._dtpTo.Name = "_dtpTo";
            this._dtpTo.Size = new System.Drawing.Size(224, 21);
            this._dtpTo.TabIndex = 10;
            // 
            // _dtpFrom
            // 
            this._dtpFrom.Location = new System.Drawing.Point(184, 86);
            this._dtpFrom.Name = "_dtpFrom";
            this._dtpFrom.Size = new System.Drawing.Size(224, 21);
            this._dtpFrom.TabIndex = 9;
            // 
            // _Label9
            // 
            this._Label9.Location = new System.Drawing.Point(136, 115);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(48, 16);
            this._Label9.TabIndex = 10;
            this._Label9.Text = "To";
            // 
            // _Label8
            // 
            this._Label8.Location = new System.Drawing.Point(136, 83);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(48, 16);
            this._Label8.TabIndex = 9;
            this._Label8.Text = "From";
            // 
            // _chkDateCreated
            // 
            this._chkDateCreated.Cursor = System.Windows.Forms.Cursors.Hand;
            this._chkDateCreated.Location = new System.Drawing.Point(17, 86);
            this._chkDateCreated.Name = "_chkDateCreated";
            this._chkDateCreated.Size = new System.Drawing.Size(104, 24);
            this._chkDateCreated.TabIndex = 8;
            this._chkDateCreated.Text = "Date Between";
            this._chkDateCreated.UseVisualStyleBackColor = true;
            this._chkDateCreated.CheckedChanged += new System.EventHandler(this.chkDateCreated_CheckedChanged);
            // 
            // _lblSearch
            // 
            this._lblSearch.Location = new System.Drawing.Point(16, 53);
            this._lblSearch.Name = "_lblSearch";
            this._lblSearch.Size = new System.Drawing.Size(112, 20);
            this._lblSearch.TabIndex = 2;
            this._lblSearch.Text = "Engineer";
            // 
            // _Label10
            // 
            this._Label10.Location = new System.Drawing.Point(16, 25);
            this._Label10.Name = "_Label10";
            this._Label10.Size = new System.Drawing.Size(48, 20);
            this._Label10.TabIndex = 4;
            this._Label10.Text = "Type";
            // 
            // _cboType
            // 
            this._cboType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboType.Location = new System.Drawing.Point(136, 22);
            this._cboType.Name = "_cboType";
            this._cboType.Size = new System.Drawing.Size(684, 21);
            this._cboType.TabIndex = 1;
            // 
            // _btnReset
            // 
            this._btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnReset.Location = new System.Drawing.Point(8, 526);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(56, 23);
            this._btnReset.TabIndex = 13;
            this._btnReset.Text = "Reset";
            this._btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // _btnAdd
            // 
            this._btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAdd.Location = new System.Drawing.Point(772, 526);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(56, 23);
            this._btnAdd.TabIndex = 14;
            this._btnAdd.Text = "Add";
            this._btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // _btnDelete
            // 
            this._btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnDelete.Location = new System.Drawing.Point(70, 526);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(56, 23);
            this._btnDelete.TabIndex = 15;
            this._btnDelete.Text = "Delete";
            this._btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FRMEngineerTimesheets
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(844, 558);
            this.Controls.Add(this._btnDelete);
            this.Controls.Add(this._btnAdd);
            this.Controls.Add(this._grpFilter);
            this.Controls.Add(this._grpJobs);
            this.Controls.Add(this._btnReset);
            this.MinimumSize = new System.Drawing.Size(852, 592);
            this.Name = "FRMEngineerTimesheets";
            this.Text = "Engineer General Timesheets Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgTimesheets)).EndInit();
            this._grpFilter.ResumeLayout(false);
            this._grpFilter.PerformLayout();
            this.ResumeLayout(false);

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