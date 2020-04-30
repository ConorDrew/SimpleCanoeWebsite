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

        internal Button btnShowResults
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnShowResults;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnShowResults != null)
                {
                    _btnShowResults.Click -= btnShowResults_Click;
                }

                _btnShowResults = value;
                if (_btnShowResults != null)
                {
                    _btnShowResults.Click += btnShowResults_Click;
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

        internal MenuItem mnuEngineerAbsence
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuEngineerAbsence;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuEngineerAbsence != null)
                {
                    _mnuEngineerAbsence.Click -= mnuEngineerAbsence_Click;
                }

                _mnuEngineerAbsence = value;
                if (_mnuEngineerAbsence != null)
                {
                    _mnuEngineerAbsence.Click += mnuEngineerAbsence_Click;
                }
            }
        }

        private MenuItem _mnuUserAbsence;

        internal MenuItem mnuUserAbsence
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuUserAbsence;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuUserAbsence != null)
                {
                    _mnuUserAbsence.Click -= mnuUserAbsence_Click;
                }

                _mnuUserAbsence = value;
                if (_mnuUserAbsence != null)
                {
                    _mnuUserAbsence.Click += mnuUserAbsence_Click;
                }
            }
        }

        private MenuItem _MenuItem2;

        internal MenuItem MenuItem2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MenuItem2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_MenuItem2 != null)
                {
                }

                _MenuItem2 = value;
                if (_MenuItem2 != null)
                {
                }
            }
        }

        private MenuItem _mnuBlockOfAbsences;

        internal MenuItem mnuBlockOfAbsences
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuBlockOfAbsences;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuBlockOfAbsences != null)
                {
                    _mnuBlockOfAbsences.Click -= mnuBlockOfAbsences_Click;
                }

                _mnuBlockOfAbsences = value;
                if (_mnuBlockOfAbsences != null)
                {
                    _mnuBlockOfAbsences.Click += mnuBlockOfAbsences_Click;
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _GroupBox1 = new GroupBox();
            _dgAbsences = new DataGrid();
            _dgAbsences.DoubleClick += new EventHandler(dgAbsences_DoubleClick);
            _Search = new GroupBox();
            _Label5 = new Label();
            _cboUsers = new ComboBox();
            _Label2 = new Label();
            _dtTo = new DateTimePicker();
            _dtFrom = new DateTimePicker();
            _Label4 = new Label();
            _Label3 = new Label();
            _cboType = new ComboBox();
            _btnShowResults = new Button();
            _btnShowResults.Click += new EventHandler(btnShowResults_Click);
            _Label1 = new Label();
            _cboEngineers = new ComboBox();
            _btnNew = new Button();
            _btnNew.Click += new EventHandler(btnNew_Click);
            _mnuAbsenceType = new ContextMenu();
            _mnuEngineerAbsence = new MenuItem();
            _mnuEngineerAbsence.Click += new EventHandler(mnuEngineerAbsence_Click);
            _mnuUserAbsence = new MenuItem();
            _mnuUserAbsence.Click += new EventHandler(mnuUserAbsence_Click);
            _btnDelete = new Button();
            _btnDelete.Click += new EventHandler(btnDelete_Click);
            _mnuBlockOfAbsences = new MenuItem();
            _mnuBlockOfAbsences.Click += new EventHandler(mnuBlockOfAbsences_Click);
            _MenuItem2 = new MenuItem();
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgAbsences).BeginInit();
            _Search.SuspendLayout();
            SuspendLayout();
            // 
            // GroupBox1
            // 
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_dgAbsences);
            _GroupBox1.Font = new Font("Verdana", 8.0F);
            _GroupBox1.Location = new Point(8, 192);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(741, 216);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Double click to edit";
            // 
            // dgAbsences
            // 
            _dgAbsences.AllowNavigation = false;
            _dgAbsences.AlternatingBackColor = Color.GhostWhite;
            _dgAbsences.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgAbsences.BackgroundColor = Color.White;
            _dgAbsences.BorderStyle = BorderStyle.FixedSingle;
            _dgAbsences.CaptionBackColor = Color.RoyalBlue;
            _dgAbsences.CaptionForeColor = Color.White;
            _dgAbsences.CaptionVisible = false;
            _dgAbsences.DataMember = "";
            _dgAbsences.Font = new Font("Verdana", 8.0F);
            _dgAbsences.ForeColor = Color.MidnightBlue;
            _dgAbsences.GridLineColor = Color.RoyalBlue;
            _dgAbsences.HeaderBackColor = Color.MidnightBlue;
            _dgAbsences.HeaderFont = new Font("Tahoma", 8.0F, FontStyle.Bold);
            _dgAbsences.HeaderForeColor = Color.Lavender;
            _dgAbsences.LinkColor = Color.Teal;
            _dgAbsences.Location = new Point(10, 17);
            _dgAbsences.Name = "dgAbsences";
            _dgAbsences.ParentRowsBackColor = Color.Lavender;
            _dgAbsences.ParentRowsForeColor = Color.MidnightBlue;
            _dgAbsences.ParentRowsVisible = false;
            _dgAbsences.RowHeadersVisible = false;
            _dgAbsences.SelectionBackColor = Color.Teal;
            _dgAbsences.SelectionForeColor = Color.PaleGreen;
            _dgAbsences.Size = new Size(722, 190);
            _dgAbsences.TabIndex = 7;
            // 
            // Search
            // 
            _Search.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _Search.Controls.Add(_Label5);
            _Search.Controls.Add(_cboUsers);
            _Search.Controls.Add(_Label2);
            _Search.Controls.Add(_dtTo);
            _Search.Controls.Add(_dtFrom);
            _Search.Controls.Add(_Label4);
            _Search.Controls.Add(_Label3);
            _Search.Controls.Add(_cboType);
            _Search.Controls.Add(_btnShowResults);
            _Search.Controls.Add(_Label1);
            _Search.Controls.Add(_cboEngineers);
            _Search.Font = new Font("Verdana", 8.0F);
            _Search.Location = new Point(8, 40);
            _Search.Name = "Search";
            _Search.Size = new Size(741, 144);
            _Search.TabIndex = 1;
            _Search.TabStop = false;
            _Search.Text = "Search";
            // 
            // Label5
            // 

            _Label5.Font = new Font("Verdana", 8.0F);
            _Label5.Location = new Point(16, 52);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(96, 17);
            _Label5.TabIndex = 24;
            _Label5.Text = "User:";
            // 
            // cboUsers
            // 
            _cboUsers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboUsers.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboUsers.Font = new Font("Verdana", 8.0F);
            _cboUsers.Location = new Point(112, 48);
            _cboUsers.Name = "cboUsers";
            _cboUsers.Size = new Size(624, 21);
            _cboUsers.TabIndex = 2;
            // 
            // Label2
            // 

            _Label2.Font = new Font("Verdana", 8.0F);
            _Label2.Location = new Point(16, 112);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(80, 18);
            _Label2.TabIndex = 22;
            _Label2.Text = "Absent From";
            // 
            // dtTo
            // 
            _dtTo.Font = new Font("Verdana", 8.0F);
            _dtTo.Format = DateTimePickerFormat.Short;
            _dtTo.Location = new Point(304, 112);
            _dtTo.Name = "dtTo";
            _dtTo.Size = new Size(152, 20);
            _dtTo.TabIndex = 5;
            // 
            // dtFrom
            // 
            _dtFrom.Font = new Font("Verdana", 8.0F);
            _dtFrom.Format = DateTimePickerFormat.Short;
            _dtFrom.Location = new Point(112, 112);
            _dtFrom.Name = "dtFrom";
            _dtFrom.Size = new Size(152, 20);
            _dtFrom.TabIndex = 4;
            _dtFrom.Value = new DateTime(2007, 9, 14, 0, 0, 0, 0);
            // 
            // Label4
            // 
            _Label4.Font = new Font("Verdana", 8.0F);
            _Label4.Location = new Point(272, 112);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(32, 18);
            _Label4.TabIndex = 19;
            _Label4.Text = "To";
            // 
            // Label3
            // 

            _Label3.Font = new Font("Verdana", 8.0F);
            _Label3.Location = new Point(16, 80);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(96, 17);
            _Label3.TabIndex = 18;
            _Label3.Text = "Absence Type:";
            // 
            // cboType
            // 
            _cboType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboType.Font = new Font("Verdana", 8.0F);
            _cboType.Location = new Point(112, 80);
            _cboType.Name = "cboType";
            _cboType.Size = new Size(624, 21);
            _cboType.TabIndex = 3;
            // 
            // btnShowResults
            // 
            _btnShowResults.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnShowResults.UseVisualStyleBackColor = true;
            _btnShowResults.Font = new Font("Verdana", 8.0F);
            _btnShowResults.Location = new Point(670, 112);
            _btnShowResults.Name = "btnShowResults";
            _btnShowResults.Size = new Size(64, 23);
            _btnShowResults.TabIndex = 6;
            _btnShowResults.Text = "Show";
            // 
            // Label1
            // 

            _Label1.Font = new Font("Verdana", 8.0F);
            _Label1.Location = new Point(16, 24);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(96, 17);
            _Label1.TabIndex = 1;
            _Label1.Text = "Engineer:";
            // 
            // cboEngineers
            // 
            _cboEngineers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboEngineers.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboEngineers.Font = new Font("Verdana", 8.0F);
            _cboEngineers.Location = new Point(112, 19);
            _cboEngineers.Name = "cboEngineers";
            _cboEngineers.Size = new Size(624, 21);
            _cboEngineers.TabIndex = 1;
            // 
            // btnNew
            // 
            _btnNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnNew.ContextMenu = _mnuAbsenceType;
            _btnNew.UseVisualStyleBackColor = true;
            _btnNew.Font = new Font("Verdana", 8.0F);
            _btnNew.Location = new Point(8, 416);
            _btnNew.Name = "btnNew";
            _btnNew.Size = new Size(64, 23);
            _btnNew.TabIndex = 8;
            _btnNew.Text = "Add New";
            // 
            // mnuAbsenceType
            // 
            _mnuAbsenceType.MenuItems.AddRange(new MenuItem[] { _mnuEngineerAbsence, _mnuUserAbsence, _MenuItem2, _mnuBlockOfAbsences });
            // 
            // mnuEngineerAbsence
            // 
            _mnuEngineerAbsence.Index = 0;
            _mnuEngineerAbsence.Text = "Engineer Absence";
            // 
            // mnuUserAbsence
            // 
            _mnuUserAbsence.Index = 1;
            _mnuUserAbsence.Text = "User Absence";
            // 
            // btnDelete
            // 
            _btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnDelete.UseVisualStyleBackColor = true;
            _btnDelete.Font = new Font("Verdana", 8.0F);
            _btnDelete.Location = new Point(688, 416);
            _btnDelete.Name = "btnDelete";
            _btnDelete.Size = new Size(64, 23);
            _btnDelete.TabIndex = 9;
            _btnDelete.Text = "Delete";
            // 
            // mnuBlockOfAbsences
            // 
            _mnuBlockOfAbsences.Index = 3;
            _mnuBlockOfAbsences.Text = "Block of Absences";
            // 
            // MenuItem2
            // 
            _MenuItem2.Index = 2;
            _MenuItem2.Text = "-";
            // 
            // frmAbsences
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(760, 446);
            Controls.Add(_btnDelete);
            Controls.Add(_btnNew);
            Controls.Add(_Search);
            Controls.Add(_GroupBox1);
            MinimumSize = new Size(768, 480);
            Name = "frmAbsences";
            Text = "Absences";
            Controls.SetChildIndex(_GroupBox1, 0);
            Controls.SetChildIndex(_Search, 0);
            Controls.SetChildIndex(_btnNew, 0);
            Controls.SetChildIndex(_btnDelete, 0);
            _GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgAbsences).EndInit();
            _Search.ResumeLayout(false);
            ResumeLayout(false);
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

        public void NewAbsence()
        {
            var frm = new FrmEngineerAbsence(0);
            frm.ShowDialog();
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