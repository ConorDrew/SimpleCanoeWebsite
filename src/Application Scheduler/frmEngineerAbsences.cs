using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class frmAbsences : FRMBaseForm
    {
        public frmAbsences() : base()
        {
            base.Load += frmHolidays_Load;

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
        private GroupBox _GroupBox1;

        internal GroupBox GroupBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox1 != null)
                {
                }

                _GroupBox1 = value;
                if (_GroupBox1 != null)
                {
                }
            }
        }

        private GroupBox _Search;

        internal GroupBox Search
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Search;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Search != null)
                {
                }

                _Search = value;
                if (_Search != null)
                {
                }
            }
        }

        private ComboBox _cboEngineers;

        internal ComboBox cboEngineers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboEngineers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboEngineers != null)
                {
                }

                _cboEngineers = value;
                if (_cboEngineers != null)
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

        private Button _btnShowResults;

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

        private DataGrid _dgAbsences;

        internal DataGrid dgAbsences
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgAbsences;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgAbsences != null)
                {
                    _dgAbsences.DoubleClick -= dgAbsences_DoubleClick;
                }

                _dgAbsences = value;
                if (_dgAbsences != null)
                {
                    _dgAbsences.DoubleClick += dgAbsences_DoubleClick;
                }
            }
        }

        private Button _btnNew;

        internal Button btnNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnNew != null)
                {
                    _btnNew.Click -= btnNew_Click;
                }

                _btnNew = value;
                if (_btnNew != null)
                {
                    _btnNew.Click += btnNew_Click;
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

        private DateTimePicker _dtTo;

        internal DateTimePicker dtTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtTo != null)
                {
                }

                _dtTo = value;
                if (_dtTo != null)
                {
                }
            }
        }

        private DateTimePicker _dtFrom;

        internal DateTimePicker dtFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtFrom != null)
                {
                }

                _dtFrom = value;
                if (_dtFrom != null)
                {
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

        private ComboBox _cboUsers;

        internal ComboBox cboUsers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboUsers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboUsers != null)
                {
                }

                _cboUsers = value;
                if (_cboUsers != null)
                {
                }
            }
        }

        private ContextMenu _mnuAbsenceType;

        internal ContextMenu mnuAbsenceType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuAbsenceType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuAbsenceType != null)
                {
                }

                _mnuAbsenceType = value;
                if (_mnuAbsenceType != null)
                {
                }
            }
        }

        private MenuItem _mnuEngineerAbsence;

        private MenuItem _mnuUserAbsence;

        private MenuItem _MenuItem2;

        private MenuItem _mnuBlockOfAbsences;

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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._dgAbsences = new System.Windows.Forms.DataGrid();
            this._Search = new System.Windows.Forms.GroupBox();
            this._Label5 = new System.Windows.Forms.Label();
            this._cboUsers = new System.Windows.Forms.ComboBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._dtTo = new System.Windows.Forms.DateTimePicker();
            this._dtFrom = new System.Windows.Forms.DateTimePicker();
            this._Label4 = new System.Windows.Forms.Label();
            this._Label3 = new System.Windows.Forms.Label();
            this._cboType = new System.Windows.Forms.ComboBox();
            this._btnShowResults = new System.Windows.Forms.Button();
            this._Label1 = new System.Windows.Forms.Label();
            this._cboEngineers = new System.Windows.Forms.ComboBox();
            this._btnNew = new System.Windows.Forms.Button();
            this._mnuAbsenceType = new System.Windows.Forms.ContextMenu();
            this._mnuEngineerAbsence = new System.Windows.Forms.MenuItem();
            this._mnuUserAbsence = new System.Windows.Forms.MenuItem();
            this._MenuItem2 = new System.Windows.Forms.MenuItem();
            this._mnuBlockOfAbsences = new System.Windows.Forms.MenuItem();
            this._btnDelete = new System.Windows.Forms.Button();
            this._GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgAbsences)).BeginInit();
            this._Search.SuspendLayout();
            this.SuspendLayout();
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._dgAbsences);
            this._GroupBox1.Font = new System.Drawing.Font("Verdana", 8F);
            this._GroupBox1.Location = new System.Drawing.Point(8, 160);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(741, 248);
            this._GroupBox1.TabIndex = 0;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Double click to edit";
            // 
            // _dgAbsences
            // 
            this._dgAbsences.AllowNavigation = false;
            this._dgAbsences.AlternatingBackColor = System.Drawing.Color.GhostWhite;
            this._dgAbsences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgAbsences.BackgroundColor = System.Drawing.Color.White;
            this._dgAbsences.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._dgAbsences.CaptionBackColor = System.Drawing.Color.RoyalBlue;
            this._dgAbsences.CaptionForeColor = System.Drawing.Color.White;
            this._dgAbsences.CaptionVisible = false;
            this._dgAbsences.DataMember = "";
            this._dgAbsences.Font = new System.Drawing.Font("Verdana", 8F);
            this._dgAbsences.ForeColor = System.Drawing.Color.MidnightBlue;
            this._dgAbsences.GridLineColor = System.Drawing.Color.RoyalBlue;
            this._dgAbsences.HeaderBackColor = System.Drawing.Color.MidnightBlue;
            this._dgAbsences.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this._dgAbsences.HeaderForeColor = System.Drawing.Color.Lavender;
            this._dgAbsences.LinkColor = System.Drawing.Color.Teal;
            this._dgAbsences.Location = new System.Drawing.Point(10, 17);
            this._dgAbsences.Name = "_dgAbsences";
            this._dgAbsences.ParentRowsBackColor = System.Drawing.Color.Lavender;
            this._dgAbsences.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this._dgAbsences.ParentRowsVisible = false;
            this._dgAbsences.RowHeadersVisible = false;
            this._dgAbsences.SelectionBackColor = System.Drawing.Color.Teal;
            this._dgAbsences.SelectionForeColor = System.Drawing.Color.PaleGreen;
            this._dgAbsences.Size = new System.Drawing.Size(722, 222);
            this._dgAbsences.TabIndex = 7;
            this._dgAbsences.DoubleClick += new System.EventHandler(this.dgAbsences_DoubleClick);
            // 
            // _Search
            // 
            this._Search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._Search.Controls.Add(this._Label5);
            this._Search.Controls.Add(this._cboUsers);
            this._Search.Controls.Add(this._Label2);
            this._Search.Controls.Add(this._dtTo);
            this._Search.Controls.Add(this._dtFrom);
            this._Search.Controls.Add(this._Label4);
            this._Search.Controls.Add(this._Label3);
            this._Search.Controls.Add(this._cboType);
            this._Search.Controls.Add(this._btnShowResults);
            this._Search.Controls.Add(this._Label1);
            this._Search.Controls.Add(this._cboEngineers);
            this._Search.Font = new System.Drawing.Font("Verdana", 8F);
            this._Search.Location = new System.Drawing.Point(8, 12);
            this._Search.Name = "_Search";
            this._Search.Size = new System.Drawing.Size(741, 142);
            this._Search.TabIndex = 1;
            this._Search.TabStop = false;
            this._Search.Text = "Search";
            // 
            // _Label5
            // 
            this._Label5.Font = new System.Drawing.Font("Verdana", 8F);
            this._Label5.Location = new System.Drawing.Point(16, 52);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(96, 17);
            this._Label5.TabIndex = 24;
            this._Label5.Text = "User:";
            // 
            // _cboUsers
            // 
            this._cboUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboUsers.Font = new System.Drawing.Font("Verdana", 8F);
            this._cboUsers.Location = new System.Drawing.Point(112, 48);
            this._cboUsers.Name = "_cboUsers";
            this._cboUsers.Size = new System.Drawing.Size(624, 21);
            this._cboUsers.TabIndex = 2;
            // 
            // _Label2
            // 
            this._Label2.Font = new System.Drawing.Font("Verdana", 8F);
            this._Label2.Location = new System.Drawing.Point(16, 112);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(80, 18);
            this._Label2.TabIndex = 22;
            this._Label2.Text = "Absent From";
            // 
            // _dtTo
            // 
            this._dtTo.Font = new System.Drawing.Font("Verdana", 8F);
            this._dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtTo.Location = new System.Drawing.Point(304, 112);
            this._dtTo.Name = "_dtTo";
            this._dtTo.Size = new System.Drawing.Size(152, 20);
            this._dtTo.TabIndex = 5;
            // 
            // _dtFrom
            // 
            this._dtFrom.Font = new System.Drawing.Font("Verdana", 8F);
            this._dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtFrom.Location = new System.Drawing.Point(112, 112);
            this._dtFrom.Name = "_dtFrom";
            this._dtFrom.Size = new System.Drawing.Size(152, 20);
            this._dtFrom.TabIndex = 4;
            this._dtFrom.Value = new System.DateTime(2007, 9, 14, 0, 0, 0, 0);
            // 
            // _Label4
            // 
            this._Label4.Font = new System.Drawing.Font("Verdana", 8F);
            this._Label4.Location = new System.Drawing.Point(272, 112);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(32, 18);
            this._Label4.TabIndex = 19;
            this._Label4.Text = "To";
            // 
            // _Label3
            // 
            this._Label3.Font = new System.Drawing.Font("Verdana", 8F);
            this._Label3.Location = new System.Drawing.Point(16, 80);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(96, 17);
            this._Label3.TabIndex = 18;
            this._Label3.Text = "Absence Type:";
            // 
            // _cboType
            // 
            this._cboType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboType.Font = new System.Drawing.Font("Verdana", 8F);
            this._cboType.Location = new System.Drawing.Point(112, 80);
            this._cboType.Name = "_cboType";
            this._cboType.Size = new System.Drawing.Size(624, 21);
            this._cboType.TabIndex = 3;
            // 
            // _btnShowResults
            // 
            this._btnShowResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnShowResults.Font = new System.Drawing.Font("Verdana", 8F);
            this._btnShowResults.Location = new System.Drawing.Point(670, 110);
            this._btnShowResults.Name = "_btnShowResults";
            this._btnShowResults.Size = new System.Drawing.Size(64, 23);
            this._btnShowResults.TabIndex = 6;
            this._btnShowResults.Text = "Show";
            this._btnShowResults.UseVisualStyleBackColor = true;
            this._btnShowResults.Click += new System.EventHandler(this.btnShowResults_Click);
            // 
            // _Label1
            // 
            this._Label1.Font = new System.Drawing.Font("Verdana", 8F);
            this._Label1.Location = new System.Drawing.Point(16, 24);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(96, 17);
            this._Label1.TabIndex = 1;
            this._Label1.Text = "Engineer:";
            // 
            // _cboEngineers
            // 
            this._cboEngineers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboEngineers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboEngineers.Font = new System.Drawing.Font("Verdana", 8F);
            this._cboEngineers.Location = new System.Drawing.Point(112, 19);
            this._cboEngineers.Name = "_cboEngineers";
            this._cboEngineers.Size = new System.Drawing.Size(624, 21);
            this._cboEngineers.TabIndex = 1;
            // 
            // _btnNew
            // 
            this._btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnNew.ContextMenu = this._mnuAbsenceType;
            this._btnNew.Font = new System.Drawing.Font("Verdana", 8F);
            this._btnNew.Location = new System.Drawing.Point(8, 416);
            this._btnNew.Name = "_btnNew";
            this._btnNew.Size = new System.Drawing.Size(64, 23);
            this._btnNew.TabIndex = 8;
            this._btnNew.Text = "Add New";
            this._btnNew.UseVisualStyleBackColor = true;
            this._btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // _mnuAbsenceType
            // 
            this._mnuAbsenceType.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._mnuEngineerAbsence,
            this._mnuUserAbsence,
            this._MenuItem2,
            this._mnuBlockOfAbsences});
            // 
            // _mnuEngineerAbsence
            // 
            this._mnuEngineerAbsence.Index = 0;
            this._mnuEngineerAbsence.Text = "Engineer Absence";
            this._mnuEngineerAbsence.Click += new System.EventHandler(this.mnuEngineerAbsence_Click);
            // 
            // _mnuUserAbsence
            // 
            this._mnuUserAbsence.Index = 1;
            this._mnuUserAbsence.Text = "User Absence";
            this._mnuUserAbsence.Click += new System.EventHandler(this.mnuUserAbsence_Click);
            // 
            // _MenuItem2
            // 
            this._MenuItem2.Index = 2;
            this._MenuItem2.Text = "-";
            // 
            // _mnuBlockOfAbsences
            // 
            this._mnuBlockOfAbsences.Index = 3;
            this._mnuBlockOfAbsences.Text = "Block of Absences";
            this._mnuBlockOfAbsences.Click += new System.EventHandler(this.mnuBlockOfAbsences_Click);
            // 
            // _btnDelete
            // 
            this._btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDelete.Font = new System.Drawing.Font("Verdana", 8F);
            this._btnDelete.Location = new System.Drawing.Point(688, 416);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(64, 23);
            this._btnDelete.TabIndex = 9;
            this._btnDelete.Text = "Delete";
            this._btnDelete.UseVisualStyleBackColor = true;
            this._btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmAbsences
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(760, 446);
            this.Controls.Add(this._btnDelete);
            this.Controls.Add(this._btnNew);
            this.Controls.Add(this._Search);
            this.Controls.Add(this._GroupBox1);
            this.MinimumSize = new System.Drawing.Size(768, 480);
            this.Name = "frmAbsences";
            this.Text = "Absences";
            this._GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgAbsences)).EndInit();
            this._Search.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private DataView _dvAbsences = new DataView();

        public DataView AbsencesDataView
        {
            get
            {
                return _dvAbsences;
            }

            set
            {
                _dvAbsences = value;
                _dvAbsences.Table.TableName = "tblEngineerAbsence";
                dgAbsences.DataSource = _dvAbsences;
                _dvAbsences.AllowNew = false;
                _dvAbsences.AllowEdit = false;
                _dvAbsences.AllowDelete = false;
            }
        }

        public DataRow SelectedAbsenceRow
        {
            get
            {
                if (dgAbsences.CurrentRowIndex > -1)
                {
                    return AbsencesDataView[dgAbsences.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        public event RefreshEngineerAbsencesEventHandler RefreshEngineerAbsences;

        public delegate void RefreshEngineerAbsencesEventHandler();

        private void frmHolidays_Load(object sender, EventArgs e)
        {
            LoadForm(this);
            SetupAbsenceDataGridGrid();
            LoadEngineerComboBox();
            LoadUserComboBox();
            LoadAbsencestypeComboBox();
        }

        private void btnShowResults_Click(object sender, EventArgs e)
        {
            SearchAbsences();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            EditAbsence();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            mnuAbsenceType.Show(btnNew, new Point(0, 0));
        }

        private void dgAbsences_DoubleClick(object sender, EventArgs e)
        {
            EditAbsence();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteAbsence();
        }

        private void mnuEngineerAbsence_Click(object sender, EventArgs e)
        {
            var frm = new FrmEngineerAbsence(0);
            frm.ShowDialog();
        }

        private void mnuUserAbsence_Click(object sender, EventArgs e)
        {
            var frm = new FrmUserAbsence();
            frm.ShowDialog();
        }

        private void mnuBlockOfAbsences_Click(object sender, EventArgs e)
        {
            var frm = new FrmBlockAbsence();
            frm.UserAbsenceChanged += SearchAbsences;
            frm.ShowDialog();
        }

        private void SetupAbsenceDataGridGrid()
        {
            SuspendLayout();
            Entity.Sys.Helper.SetUpDataGrid(dgAbsences);
            var tbStyle = dgAbsences.TableStyles[0];
            tbStyle.GridColumnStyles.Clear();
            dgAbsences.ReadOnly = true;
            var Name = new DataGridLabelColumn();
            Name.MappingName = "Name";
            Name.HeaderText = "Name";
            Name.Width = 200;
            Name.NullText = "";
            Name.ReadOnly = true;
            tbStyle.GridColumnStyles.Add(Name);
            var PersonnelType = new DataGridLabelColumn();
            PersonnelType.MappingName = "PersonnelType";
            PersonnelType.HeaderText = "Personnel Type";
            PersonnelType.Width = 200;
            PersonnelType.NullText = "";
            PersonnelType.ReadOnly = true;
            tbStyle.GridColumnStyles.Add(PersonnelType);
            var UnavailableType = new DataGridLabelColumn();
            UnavailableType.MappingName = "Description";
            UnavailableType.HeaderText = "Type";
            UnavailableType.Width = 110;
            UnavailableType.NullText = "";
            UnavailableType.ReadOnly = true;
            tbStyle.GridColumnStyles.Add(UnavailableType);
            var DateFrom = new DataGridLabelColumn();
            DateFrom.MappingName = "DateFrom";
            DateFrom.HeaderText = "Date From";
            DateFrom.Format = "dd/MM/yyyy HH:mm";
            DateFrom.Width = 100;
            DateFrom.NullText = "";
            DateFrom.ReadOnly = true;
            tbStyle.GridColumnStyles.Add(DateFrom);
            var DateTo = new DataGridLabelColumn();
            DateTo.MappingName = "DateTo";
            DateTo.HeaderText = "Date To";
            DateTo.Format = "dd/MM/yyyy HH:mm";
            DateTo.NullText = "";
            DateTo.Width = 100;
            DateTo.ReadOnly = true;
            tbStyle.GridColumnStyles.Add(DateTo);
            tbStyle.MappingName = "tblEngineerAbsence";
            dgAbsences.TableStyles.Add(tbStyle);
            ResumeLayout();
        }

        private void LoadAbsencestypeComboBox()
        {
            var dt = new DataTable();
            dt = App.DB.EngineerAbsence.EngineerAbsenceTypes_GetAll();
            var drAll = dt.NewRow();
            drAll["Description"] = "All";
            drAll["EngineerAbsenceTypeID"] = 0;
            dt.Rows.InsertAt(drAll, 0);
            dt.AcceptChanges();
            cboType.DataSource = dt;
            cboType.DisplayMember = "Description";
            cboType.ValueMember = "EngineerAbsenceTypeID";
        }

        private void LoadEngineerComboBox()
        {
            var dt = new DataTable();
            dt = App.DB.Engineer.Engineer_GetAll().Table;
            var drAll = dt.NewRow();
            drAll["Name"] = "All";
            drAll["EngineerID"] = 0;
            dt.Rows.InsertAt(drAll, 0);
            dt.AcceptChanges();
            cboEngineers.DataSource = dt;
            cboEngineers.DisplayMember = "Name";
            cboEngineers.ValueMember = "EngineerID";
        }

        private void LoadUserComboBox()
        {
            var dt = new DataTable();
            dt = App.DB.User.GetAll().Table;
            var drAll = dt.NewRow();
            drAll["Fullname"] = "All";
            drAll["UserID"] = 0;
            dt.Rows.InsertAt(drAll, 0);
            dt.AcceptChanges();
            cboUsers.DataSource = dt;
            cboUsers.DisplayMember = "Fullname";
            cboUsers.ValueMember = "UserID";
        }

        public void EditAbsence()
        {
            if (dgAbsences.CurrentRowIndex > -1)
            {
                if (SelectedAbsenceRow is object)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedAbsenceRow["PersonnelType"], "Engineer", false)))
                    {
                        var frm = new FrmEngineerAbsence(Conversions.ToInteger(SelectedAbsenceRow["ID"]));
                        frm.ShowDialog();
                    }
                    else
                    {
                        var frm = new FrmUserAbsence(Conversions.ToInteger(SelectedAbsenceRow["ID"]));
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void SearchAbsences()
        {
            string sql;
            var where = new ArrayList();
            sql = "SELECT EngineerAbsenceID AS ID,'Engineer' as PersonnelType , tblEngineer.Name as [Name], DateTo, DateFrom, AbsenceTypeID, Description";
            sql += " FROM tblEngineerAbsence";
            sql += " INNER JOIN tblEngineer ON tblEngineer.EngineerID = tblEngineerAbsence.EngineerID";
            sql += " LEFT JOIN tblEngineerAbsenceTypes ON tblEngineerAbsenceTypes.EngineerAbsenceTypeID = tblEngineerAbsence.AbsenceTypeID";

            // AMY PUT THIS IN TO CORRECT THE FILTER
            string dateStr = "";
            dateStr = " (('{0}' Between tblEngineerAbsence.DateFrom AND tblEngineerAbsence.DateTo) OR " + " ('{1}' Between tblEngineerAbsence.DateFrom AND tblEngineerAbsence.DateTo) OR " + " (tblEngineerAbsence.DateFrom Between '{0}' AND '{1}' AND tblEngineerAbsence.DateTo Between '{0}' AND '{1}') ) ";

            where.Add(string.Format(dateStr, dtFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00", dtTo.Value.ToString("yyyy-MM-dd") + " 23:59:59"));

            // where.Add(String.Format(" tblEngineerAbsence.DateFrom >= '{0}'", dtFrom.Value.ToString("yyyy-MM-dd") & " 00:00:00"))
            // where.Add(String.Format(" tblEngineerAbsence.DateTo <='{0}'", dtTo.Value.ToString("yyyy-MM-dd") & " 23:59:59"))

            if (cboEngineers.SelectedIndex > 0)
            {
                where.Add(string.Format(" tblEngineerAbsence.EngineerID = '{0}'", cboEngineers.SelectedValue));
            }

            if (cboType.SelectedIndex > 0)
            {
                where.Add(string.Format("tblEngineerAbsenceTypes.EngineerAbsenceTypeID = {0}", cboType.SelectedValue));
            }

            where.Add(" tblEngineerAbsence.Deleted = 0");
            where.Add(" tblEngineer.Deleted = 0");
            where.Add(" tblEngineerAbsenceTypes.Deleted = 0");
            if (where.Count > 0)
            {
                sql += "  WHERE";
                for (int x = 0, loopTo = where.Count - 1; x <= loopTo; x++)
                {
                    if (x > 0)
                    {
                        sql += " AND";
                    }

                    sql += " " + Conversions.ToString(where[x]);
                }
            }

            where.Clear();
            sql += " UNION ";
            sql += "SELECT UserAbsenceID AS ID, 'User' as PersonnelType ,tblUser.Fullname AS [Name] , DateTo, DateFrom, AbsenceTypeID, Description";
            sql += " FROM tblUserAbsence";
            sql += " INNER JOIN tblUser ON tblUser.UserID = tblUserAbsence.UserID";
            sql += " LEFT JOIN tblUserAbsenceTypes ON tblUserAbsenceTypes.UserAbsenceTypeID = tblUserAbsence.AbsenceTypeID";

            // AMY PUT THIS IN TO CORRECT THE FILTER
            dateStr = "";
            dateStr = " (('{0}' Between tblUserAbsence.DateFrom AND tblUserAbsence.DateTo) OR " + " ('{1}' Between tblUserAbsence.DateFrom AND tblUserAbsence.DateTo) OR " + " (tblUserAbsence.DateFrom Between '{0}' AND '{1}' AND tblUserAbsence.DateTo Between '{0}' AND '{1}') ) ";

            where.Add(string.Format(dateStr, dtFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00", dtTo.Value.ToString("yyyy-MM-dd") + " 23:59:59"));

            // where.Add(String.Format(" tblUserAbsence.DateFrom >= '{0}'", dtFrom.Value.ToString("yyyy-MM-dd") & " 00:00:00"))
            // where.Add(String.Format(" tblUserAbsence.DateTo <='{0}'", dtTo.Value.ToString("yyyy-MM-dd") & " 23:59:59"))

            if (cboUsers.SelectedIndex > 0)
            {
                where.Add(string.Format(" tblUserAbsence.UserID = '{0}'", cboUsers.SelectedValue));
            }

            if (cboType.SelectedIndex > 0)
            {
                where.Add(string.Format("tblUserAbsenceTypes.UserAbsenceTypeID = {0}", cboType.SelectedValue));
            }

            where.Add(" tblUserAbsence.Deleted = 0");
            where.Add(" tblUser.Deleted = 0");
            where.Add(" tblUserAbsenceTypes.Deleted = 0");
            if (where.Count > 0)
            {
                sql += "  WHERE";
                for (int x = 0, loopTo1 = where.Count - 1; x <= loopTo1; x++)
                {
                    if (x > 0)
                    {
                        sql += " AND";
                    }

                    sql += " " + Conversions.ToString(where[x]);
                }
            }

            var dt = App.DB.EngineerAbsence.AbsenceSearch(sql);
            AbsencesDataView = new DataView(dt);
            if (dt.Rows.Count > 0)
            {
                dgAbsences.Select(0);
            }

            ActiveControl = cboEngineers;
            cboEngineers.Focus();
        }

        private void DeleteAbsence()
        {
            if (dgAbsences.CurrentRowIndex > -1)
            {
                if (SelectedAbsenceRow is object)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedAbsenceRow["PersonnelType"], "Engineer", false)))
                    {
                        string str = string.Format("Are you sure you want to delete engineer {0}'s absence from {1} to {2}?", SelectedAbsenceRow["Name"], Conversions.ToString(Strings.Format(SelectedAbsenceRow["DateFrom"], "dd/MM/yy")), Conversions.ToString(Strings.Format(SelectedAbsenceRow["DateTo"], "dd/MM/yy")));
                        if (MessageBox.Show(str, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            App.DB.EngineerAbsence.Delete(Conversions.ToInteger(SelectedAbsenceRow["ID"]));
                            SearchAbsences();
                        }
                    }
                    else
                    {
                        string str = string.Format("Are you sure you want to delete user {0}'s absence from {1} to {2}?", SelectedAbsenceRow["Name"], Conversions.ToString(Strings.Format(SelectedAbsenceRow["DateFrom"], "dd/MM/yy")), Conversions.ToString(Strings.Format(SelectedAbsenceRow["DateTo"], "dd/MM/yy")));
                        if (MessageBox.Show(str, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            App.DB.UserAbsence.Delete(Conversions.ToInteger(SelectedAbsenceRow["ID"]));
                            SearchAbsences();
                        }
                    }
                }
            }
            else
            {
                App.ShowMessage("Please select an absence to delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}