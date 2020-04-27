using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class frmVisit : FRMBaseForm, ISchedulerForm
    {
        public frmVisit()
        {
            base.SizeChanged += frmVisit_SizeChanged;
            base.Load += frmVisit_Load;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public frmVisit(int EngineerIDIn, DateTime Date, int SORTotal, int EngineerVisitID, bool isCopyIn) : base()
        {
            base.SizeChanged += frmVisit_SizeChanged;
            base.Load += frmVisit_Load;
            engineerID = EngineerIDIn.ToString();

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Initialise our dynamic controls
            lblStarts = new List<Label>();
            dtpMulitpleVisitsStart = new List<DateTimePicker>();
            lblEnds = new List<Label>();
            dtpMulitpleVisitsEnd = new List<DateTimePicker>();
            btnAddVisits = new List<Button>();
            btnRemoveVisits = new List<Button>();

            // Add any initialization after the InitializeComponent() call

            theSelectedDay = Date;
            DtTimeSlot = App.DB.Scheduler.Scheduler_DayTimeSlots(Date, engineerID);
            picPlanner.Image = scheduler_DayTimeSlots_bitmap();
            SORMinutes = SORTotal;
            AMPM = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(EngineerVisitID).AMPM;
            var argc = cboAppointment;
            Combo.SetUpCombo(ref argc, App.DB.Appointments.GetAll().Table, "AppointmentID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);

            // initialise mulitple visits tab
            InitComplexVisits();
            isCopy = isCopyIn;
            _detailPopup = new frmDetailsPopup(this);
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

        private TabControl _tabCtrlVisits;

        internal TabControl tabCtrlVisits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabCtrlVisits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabCtrlVisits != null)
                {
                }

                _tabCtrlVisits = value;
                if (_tabCtrlVisits != null)
                {
                }
            }
        }

        private TabPage _tabStandardVisit;

        internal TabPage tabStandardVisit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabStandardVisit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabStandardVisit != null)
                {
                }

                _tabStandardVisit = value;
                if (_tabStandardVisit != null)
                {
                }
            }
        }

        private TabPage _tabComplexVisit;

        internal TabPage tabComplexVisit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabComplexVisit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabComplexVisit != null)
                {
                }

                _tabComplexVisit = value;
                if (_tabComplexVisit != null)
                {
                }
            }
        }

        private GroupBox _GroupBox2;

        internal GroupBox GroupBox2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox2 != null)
                {
                }

                _GroupBox2 = value;
                if (_GroupBox2 != null)
                {
                }
            }
        }

        private ComboBox _cboAppointment;

        internal ComboBox cboAppointment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboAppointment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboAppointment != null)
                {
                }

                _cboAppointment = value;
                if (_cboAppointment != null)
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

        private Label _lblAMPM;

        internal Label lblAMPM
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAMPM;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAMPM != null)
                {
                }

                _lblAMPM = value;
                if (_lblAMPM != null)
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

        private TextBox _txtEndTimeMinutes;

        internal TextBox txtEndTimeMinutes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEndTimeMinutes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEndTimeMinutes != null)
                {
                    _txtEndTimeMinutes.TextChanged -= txtEndTimeHours_TextChanged;
                }

                _txtEndTimeMinutes = value;
                if (_txtEndTimeMinutes != null)
                {
                    _txtEndTimeMinutes.TextChanged += txtEndTimeHours_TextChanged;
                }
            }
        }

        private TextBox _txtEndTimeHours;

        internal TextBox txtEndTimeHours
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEndTimeHours;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEndTimeHours != null)
                {
                    _txtEndTimeHours.TextChanged -= txtEndTimeHours_TextChanged;
                }

                _txtEndTimeHours = value;
                if (_txtEndTimeHours != null)
                {
                    _txtEndTimeHours.TextChanged -= txtEndTimeHours_TextChanged;
                }
            }
        }

        private TextBox _txtStartTimeMinutes;

        internal TextBox txtStartTimeMinutes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtStartTimeMinutes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtStartTimeMinutes != null)
                {
                    _txtStartTimeMinutes.TextChanged -= txtEndTimeHours_TextChanged;
                }

                _txtStartTimeMinutes = value;
                if (_txtStartTimeMinutes != null)
                {
                    _txtStartTimeMinutes.TextChanged += txtEndTimeHours_TextChanged;
                }
            }
        }

        private TextBox _txtStartTimeHours;

        internal TextBox txtStartTimeHours
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtStartTimeHours;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtStartTimeHours != null)
                {
                    _txtStartTimeHours.TextChanged -= txtEndTimeHours_TextChanged;
                }

                _txtStartTimeHours = value;
                if (_txtStartTimeHours != null)
                {
                    _txtStartTimeHours.TextChanged += txtEndTimeHours_TextChanged;
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

        private Button _btnSave;

        internal Button btnSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSave != null)
                {
                    _btnSave.Click -= btnSave_Click;
                }

                _btnSave = value;
                if (_btnSave != null)
                {
                    _btnSave.Click += btnSave_Click;
                }
            }
        }

        private Button _btnCancel;

        internal Button btnCancel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCancel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCancel != null)
                {
                    _btnCancel.Click -= btnCancel_Click;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnCancel_Click;
                }
            }
        }

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

        private Panel _Panel2;

        internal Panel Panel2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel2 != null)
                {
                }

                _Panel2 = value;
                if (_Panel2 != null)
                {
                }
            }
        }

        private Panel _Panel1;

        internal Panel Panel1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel1 != null)
                {
                }

                _Panel1 = value;
                if (_Panel1 != null)
                {
                }
            }
        }

        private PictureBox _picPlanner;

        internal PictureBox picPlanner
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _picPlanner;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_picPlanner != null)
                {
                    _picPlanner.MouseUp -= picPlanner_MouseUp;
                }

                _picPlanner = value;
                if (_picPlanner != null)
                {
                    _picPlanner.MouseUp += picPlanner_MouseUp;
                }
            }
        }

        private Label _Label7;

        internal Label Label7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label7 != null)
                {
                }

                _Label7 = value;
                if (_Label7 != null)
                {
                }
            }
        }

        private Panel _Panel3;

        internal Panel Panel3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel3 != null)
                {
                }

                _Panel3 = value;
                if (_Panel3 != null)
                {
                }
            }
        }

        private Panel _Panel4;

        internal Panel Panel4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel4 != null)
                {
                }

                _Panel4 = value;
                if (_Panel4 != null)
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

        private GroupBox _GroupBox3;

        internal GroupBox GroupBox3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox3 != null)
                {
                }

                _GroupBox3 = value;
                if (_GroupBox3 != null)
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

        private Panel _Panel5;

        internal Panel Panel5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel5 != null)
                {
                }

                _Panel5 = value;
                if (_Panel5 != null)
                {
                }
            }
        }

        private Label _Label16;

        internal Label Label16
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label16;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label16 != null)
                {
                }

                _Label16 = value;
                if (_Label16 != null)
                {
                }
            }
        }

        private Panel _Panel7;

        internal Panel Panel7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel7 != null)
                {
                }

                _Panel7 = value;
                if (_Panel7 != null)
                {
                }
            }
        }

        private Panel _Panel8;

        internal Panel Panel8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel8 != null)
                {
                }

                _Panel8 = value;
                if (_Panel8 != null)
                {
                }
            }
        }

        private Label _Label17;

        internal Label Label17
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label17;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label17 != null)
                {
                }

                _Label17 = value;
                if (_Label17 != null)
                {
                }
            }
        }

        private Pabo.Calendar.MonthCalendar _calComplexVisit;

        internal Pabo.Calendar.MonthCalendar calComplexVisit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _calComplexVisit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_calComplexVisit != null)
                {
                    _calComplexVisit.MonthChanged -= DtpComplexVisit_MonthChanged;
                }

                _calComplexVisit = value;
                if (_calComplexVisit != null)
                {
                    _calComplexVisit.MonthChanged += DtpComplexVisit_MonthChanged;
                }
            }
        }

        private GroupBox _GroupBox4;

        internal GroupBox GroupBox4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox4 != null)
                {
                }

                _GroupBox4 = value;
                if (_GroupBox4 != null)
                {
                }
            }
        }

        private Button _btnSaveComplex;

        internal Button btnSaveComplex
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSaveComplex;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSaveComplex != null)
                {
                    _btnSaveComplex.Click -= BtnSaveComplex_Click;
                }

                _btnSaveComplex = value;
                if (_btnSaveComplex != null)
                {
                    _btnSaveComplex.Click += BtnSaveComplex_Click;
                }
            }
        }

        private Button _btnCancel2;

        internal Button btnCancel2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCancel2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCancel2 != null)
                {
                    _btnCancel2.Click -= btnCancel_Click;
                }

                _btnCancel2 = value;
                if (_btnCancel2 != null)
                {
                    _btnCancel2.Click += btnCancel_Click;
                }
            }
        }

        private Button _btnAdditionalVisit;

        internal Button btnAdditionalVisit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAdditionalVisit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAdditionalVisit != null)
                {
                    _btnAdditionalVisit.Click -= btnAdditionalVisit_Click;
                }

                _btnAdditionalVisit = value;
                if (_btnAdditionalVisit != null)
                {
                    _btnAdditionalVisit.Click += btnAdditionalVisit_Click;
                }
            }
        }

        private List<Label> lblStarts;
        private List<DateTimePicker> dtpMulitpleVisitsStart;
        private List<Label> lblEnds;
        private List<DateTimePicker> dtpMulitpleVisitsEnd;
        private List<Button> btnAddVisits;
        private List<Button> btnRemoveVisits;
        private TableLayoutPanel _pnlLayout;

        internal TableLayoutPanel pnlLayout
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlLayout;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlLayout != null)
                {
                }

                _pnlLayout = value;
                if (_pnlLayout != null)
                {
                }
            }
        }

        private Panel _Panel9;

        internal Panel Panel9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel9 != null)
                {
                }

                _Panel9 = value;
                if (_Panel9 != null)
                {
                }
            }
        }

        private Label _Label13;

        internal Label Label13
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label13;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label13 != null)
                {
                }

                _Label13 = value;
                if (_Label13 != null)
                {
                }
            }
        }

        private ToolTip _ttComplexVisits;

        internal ToolTip ttComplexVisits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ttComplexVisits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ttComplexVisits != null)
                {
                }

                _ttComplexVisits = value;
                if (_ttComplexVisits != null)
                {
                }
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            _tabCtrlVisits = new TabControl();
            _tabStandardVisit = new TabPage();
            _GroupBox2 = new GroupBox();
            _cboAppointment = new ComboBox();
            _Label12 = new Label();
            _lblAMPM = new Label();
            _Label11 = new Label();
            _Label10 = new Label();
            _txtEndTimeMinutes = new TextBox();
            _txtEndTimeMinutes.TextChanged += new EventHandler(txtEndTimeHours_TextChanged);
            _txtEndTimeHours = new TextBox();
            _txtEndTimeHours.TextChanged += new EventHandler(txtEndTimeHours_TextChanged);
            _txtStartTimeMinutes = new TextBox();
            _txtStartTimeMinutes.TextChanged += new EventHandler(txtEndTimeHours_TextChanged);
            _txtStartTimeHours = new TextBox();
            _txtStartTimeHours.TextChanged += new EventHandler(txtEndTimeHours_TextChanged);
            _Label4 = new Label();
            _Label3 = new Label();
            _Label2 = new Label();
            _Label1 = new Label();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _GroupBox1 = new GroupBox();
            _Label9 = new Label();
            _Label6 = new Label();
            _Label5 = new Label();
            _Panel2 = new Panel();
            _Panel1 = new Panel();
            _picPlanner = new PictureBox();
            _picPlanner.MouseUp += new MouseEventHandler(picPlanner_MouseUp);
            _Label7 = new Label();
            _Panel3 = new Panel();
            _Panel4 = new Panel();
            _Label8 = new Label();
            _tabComplexVisit = new TabPage();
            _GroupBox3 = new GroupBox();
            _calComplexVisit = new Pabo.Calendar.MonthCalendar();
            _calComplexVisit.MonthChanged += new Pabo.Calendar.MonthChangedEventHandler(DtpComplexVisit_MonthChanged);
            _Label14 = new Label();
            _Panel5 = new Panel();
            _Label16 = new Label();
            _Panel7 = new Panel();
            _Panel8 = new Panel();
            _Label17 = new Label();
            _btnSaveComplex = new Button();
            _btnSaveComplex.Click += new EventHandler(BtnSaveComplex_Click);
            _btnCancel2 = new Button();
            _btnCancel2.Click += new EventHandler(btnCancel_Click);
            _GroupBox4 = new GroupBox();
            _btnAdditionalVisit = new Button();
            _btnAdditionalVisit.Click += new EventHandler(btnAdditionalVisit_Click);
            _Panel9 = new Panel();
            _pnlLayout = new TableLayoutPanel();
            _Label13 = new Label();
            _ttComplexVisits = new ToolTip(components);
            _tabCtrlVisits.SuspendLayout();
            _tabStandardVisit.SuspendLayout();
            _GroupBox2.SuspendLayout();
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_picPlanner).BeginInit();
            _tabComplexVisit.SuspendLayout();
            _GroupBox3.SuspendLayout();
            _GroupBox4.SuspendLayout();
            _Panel9.SuspendLayout();
            SuspendLayout();
            //
            // tabCtrlVisits
            //
            _tabCtrlVisits.Controls.Add(_tabStandardVisit);
            _tabCtrlVisits.Controls.Add(_tabComplexVisit);
            _tabCtrlVisits.Location = new Point(0, 33);
            _tabCtrlVisits.Name = "tabCtrlVisits";
            _tabCtrlVisits.SelectedIndex = 0;
            _tabCtrlVisits.Size = new Size(569, 450);
            _tabCtrlVisits.TabIndex = 2;
            //
            // tabStandardVisit
            //
            _tabStandardVisit.Controls.Add(_GroupBox2);
            _tabStandardVisit.Controls.Add(_GroupBox1);
            _tabStandardVisit.Location = new Point(4, 22);
            _tabStandardVisit.Name = "tabStandardVisit";
            _tabStandardVisit.Padding = new Padding(3);
            _tabStandardVisit.Size = new Size(561, 424);
            _tabStandardVisit.TabIndex = 0;
            _tabStandardVisit.Text = "Standard Visit";
            _tabStandardVisit.UseVisualStyleBackColor = true;
            //
            // GroupBox2
            //
            _GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox2.Controls.Add(_cboAppointment);
            _GroupBox2.Controls.Add(_Label12);
            _GroupBox2.Controls.Add(_lblAMPM);
            _GroupBox2.Controls.Add(_Label11);
            _GroupBox2.Controls.Add(_Label10);
            _GroupBox2.Controls.Add(_txtEndTimeMinutes);
            _GroupBox2.Controls.Add(_txtEndTimeHours);
            _GroupBox2.Controls.Add(_txtStartTimeMinutes);
            _GroupBox2.Controls.Add(_txtStartTimeHours);
            _GroupBox2.Controls.Add(_Label4);
            _GroupBox2.Controls.Add(_Label3);
            _GroupBox2.Controls.Add(_Label2);
            _GroupBox2.Controls.Add(_Label1);
            _GroupBox2.Controls.Add(_btnSave);
            _GroupBox2.Controls.Add(_btnCancel);
            _GroupBox2.Location = new Point(3, 298);
            _GroupBox2.Name = "GroupBox2";
            _GroupBox2.Size = new Size(552, 120);
            _GroupBox2.TabIndex = 3;
            _GroupBox2.TabStop = false;
            _GroupBox2.Text = "Schedule Visit For";
            //
            // cboAppointment
            //
            _cboAppointment.FormattingEnabled = true;
            _cboAppointment.Location = new Point(150, 86);
            _cboAppointment.Name = "cboAppointment";
            _cboAppointment.Size = new Size(210, 21);
            _cboAppointment.TabIndex = 59;
            //
            // Label12
            //
            _Label12.Location = new Point(10, 89);
            _Label12.Name = "Label12";
            _Label12.Size = new Size(134, 18);
            _Label12.TabIndex = 58;
            _Label12.Text = "Appointment Type:";
            //
            // lblAMPM
            //
            _lblAMPM.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblAMPM.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblAMPM.ForeColor = Color.Red;
            _lblAMPM.Location = new Point(410, 35);
            _lblAMPM.Name = "lblAMPM";
            _lblAMPM.Size = new Size(136, 17);
            _lblAMPM.TabIndex = 57;
            _lblAMPM.TextAlign = ContentAlignment.MiddleRight;
            //
            // Label11
            //
            _Label11.Location = new Point(8, 48);
            _Label11.Name = "Label11";
            _Label11.Size = new Size(176, 17);
            _Label11.TabIndex = 56;
            _Label11.Text = "Blank assumes \"start of day\"";
            //
            // Label10
            //
            _Label10.Location = new Point(200, 48);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(168, 17);
            _Label10.TabIndex = 55;
            _Label10.Text = "Blank assumes \"end of day\"";
            //
            // txtEndTimeMinutes
            //
            _txtEndTimeMinutes.Location = new Point(336, 21);
            _txtEndTimeMinutes.Name = "txtEndTimeMinutes";
            _txtEndTimeMinutes.Size = new Size(24, 21);
            _txtEndTimeMinutes.TabIndex = 3;
            //
            // txtEndTimeHours
            //
            _txtEndTimeHours.Location = new Point(288, 21);
            _txtEndTimeHours.Name = "txtEndTimeHours";
            _txtEndTimeHours.Size = new Size(24, 21);
            _txtEndTimeHours.TabIndex = 3;
            //
            // txtStartTimeMinutes
            //
            _txtStartTimeMinutes.Location = new Point(150, 21);
            _txtStartTimeMinutes.Name = "txtStartTimeMinutes";
            _txtStartTimeMinutes.Size = new Size(24, 21);
            _txtStartTimeMinutes.TabIndex = 2;
            //
            // txtStartTimeHours
            //
            _txtStartTimeHours.Location = new Point(104, 21);
            _txtStartTimeHours.Name = "txtStartTimeHours";
            _txtStartTimeHours.Size = new Size(24, 21);
            _txtStartTimeHours.TabIndex = 1;
            //
            // Label4
            //
            _Label4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label4.Location = new Point(320, 24);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(8, 17);
            _Label4.TabIndex = 4;
            _Label4.Text = ":";
            //
            // Label3
            //
            _Label3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label3.Location = new Point(136, 24);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(8, 17);
            _Label3.TabIndex = 54;
            _Label3.Text = ":";
            //
            // Label2
            //
            _Label2.Location = new Point(200, 24);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(64, 17);
            _Label2.TabIndex = 1;
            _Label2.Text = "End Time";
            //
            // Label1
            //
            _Label1.Location = new Point(8, 24);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(77, 17);
            _Label1.TabIndex = 0;
            _Label1.Text = "Start Time";
            //
            // btnSave
            //
            _btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnSave.Location = new Point(396, 86);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(64, 23);
            _btnSave.TabIndex = 4;
            _btnSave.Text = "Ok";
            //
            // btnCancel
            //
            _btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnCancel.Location = new Point(482, 86);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(64, 23);
            _btnCancel.TabIndex = 5;
            _btnCancel.Text = "Cancel";
            //
            // GroupBox1
            //
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_Label9);
            _GroupBox1.Controls.Add(_Label6);
            _GroupBox1.Controls.Add(_Label5);
            _GroupBox1.Controls.Add(_Panel2);
            _GroupBox1.Controls.Add(_Panel1);
            _GroupBox1.Controls.Add(_picPlanner);
            _GroupBox1.Controls.Add(_Label7);
            _GroupBox1.Controls.Add(_Panel3);
            _GroupBox1.Controls.Add(_Panel4);
            _GroupBox1.Controls.Add(_Label8);
            _GroupBox1.Location = new Point(3, 3);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(555, 289);
            _GroupBox1.TabIndex = 2;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Planner";
            //
            // Label9
            //
            _Label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _Label9.Location = new Point(8, 217);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(533, 16);
            _Label9.TabIndex = 16;
            _Label9.Text = "Hold Shift and LEFT click period for START time or RIGHT click period for END tim" + "e";
            //
            // Label6
            //
            _Label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label6.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label6.Location = new Point(240, 265);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(248, 16);
            _Label6.TabIndex = 15;
            _Label6.Text = "NOT OK - Job or Absence overlap";
            //
            // Label5
            //
            _Label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label5.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label5.Location = new Point(32, 265);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(184, 16);
            _Label5.TabIndex = 14;
            _Label5.Text = "OK - No overlap";
            //
            // Panel2
            //
            _Panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Panel2.BackColor = Color.Salmon;
            _Panel2.Location = new Point(216, 265);
            _Panel2.Name = "Panel2";
            _Panel2.Size = new Size(16, 16);
            _Panel2.TabIndex = 13;
            //
            // Panel1
            //
            _Panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Panel1.BackColor = Color.LightGreen;
            _Panel1.Location = new Point(8, 265);
            _Panel1.Name = "Panel1";
            _Panel1.Size = new Size(16, 16);
            _Panel1.TabIndex = 12;
            //
            // picPlanner
            //
            _picPlanner.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _picPlanner.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)));
            _picPlanner.BorderStyle = BorderStyle.FixedSingle;
            _picPlanner.Location = new Point(8, 23);
            _picPlanner.Name = "picPlanner";
            _picPlanner.Size = new Size(541, 181);
            _picPlanner.TabIndex = 0;
            _picPlanner.TabStop = false;
            //
            // Label7
            //
            _Label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label7.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label7.Location = new Point(32, 241);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(168, 16);
            _Label7.TabIndex = 11;
            _Label7.Text = "Booked Schedule Period";
            //
            // Panel3
            //
            _Panel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Panel3.BackColor = Color.LightSteelBlue;
            _Panel3.Location = new Point(8, 241);
            _Panel3.Name = "Panel3";
            _Panel3.Size = new Size(16, 16);
            _Panel3.TabIndex = 9;
            //
            // Panel4
            //
            _Panel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Panel4.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)), Conversions.ToInteger(Conversions.ToByte(224)));
            _Panel4.Location = new Point(216, 241);
            _Panel4.Name = "Panel4";
            _Panel4.Size = new Size(16, 16);
            _Panel4.TabIndex = 8;
            //
            // Label8
            //
            _Label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label8.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label8.Location = new Point(240, 241);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(176, 16);
            _Label8.TabIndex = 10;
            _Label8.Text = "Free Schedule Period";
            //
            // tabComplexVisit
            //
            _tabComplexVisit.Controls.Add(_GroupBox3);
            _tabComplexVisit.Controls.Add(_btnSaveComplex);
            _tabComplexVisit.Controls.Add(_btnCancel2);
            _tabComplexVisit.Controls.Add(_GroupBox4);
            _tabComplexVisit.Location = new Point(4, 22);
            _tabComplexVisit.Name = "tabComplexVisit";
            _tabComplexVisit.Padding = new Padding(3);
            _tabComplexVisit.Size = new Size(561, 424);
            _tabComplexVisit.TabIndex = 1;
            _tabComplexVisit.Text = "Complex Visit";
            _tabComplexVisit.UseVisualStyleBackColor = true;
            //
            // GroupBox3
            //
            _GroupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox3.Controls.Add(_calComplexVisit);
            _GroupBox3.Controls.Add(_Label14);
            _GroupBox3.Controls.Add(_Panel5);
            _GroupBox3.Controls.Add(_Label16);
            _GroupBox3.Controls.Add(_Panel7);
            _GroupBox3.Controls.Add(_Panel8);
            _GroupBox3.Controls.Add(_Label17);
            _GroupBox3.Location = new Point(3, 3);
            _GroupBox3.Name = "GroupBox3";
            _GroupBox3.Size = new Size(555, 228);
            _GroupBox3.TabIndex = 13;
            _GroupBox3.TabStop = false;
            _GroupBox3.Text = "Planner";
            //
            // calComplexVisit
            //
            _calComplexVisit.ActiveMonth.Month = 1;
            _calComplexVisit.ActiveMonth.Year = 2018;
            _calComplexVisit.BorderColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(197)), Conversions.ToInteger(Conversions.ToByte(198)), Conversions.ToInteger(Conversions.ToByte(214)));
            _calComplexVisit.Culture = new System.Globalization.CultureInfo("en-GB");
            _calComplexVisit.ExtendedSelectionKey = Pabo.Calendar.mcExtendedSelectionKey.Shift;
            _calComplexVisit.Footer.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            _calComplexVisit.Header.BackColor1 = Color.Blue;
            _calComplexVisit.Header.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            _calComplexVisit.Header.TextColor = Color.White;
            _calComplexVisit.ImageList = null;
            _calComplexVisit.Location = new Point(7, 23);
            _calComplexVisit.MaxDate = new DateTime(2027, 5, 10, 12, 28, 13, 983);
            _calComplexVisit.MinDate = new DateTime(2018, 1, 11, 0, 0, 0, 0);
            _calComplexVisit.Month.BackgroundImage = null;
            _calComplexVisit.Month.Colors.Focus.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(211)), Conversions.ToInteger(Conversions.ToByte(213)), Conversions.ToInteger(Conversions.ToByte(224)));
            _calComplexVisit.Month.Colors.Focus.Border = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(197)), Conversions.ToInteger(Conversions.ToByte(198)), Conversions.ToInteger(Conversions.ToByte(214)));
            _calComplexVisit.Month.Colors.Selected.BackColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(128)), Conversions.ToInteger(Conversions.ToByte(128)), Conversions.ToInteger(Conversions.ToByte(255)));
            _calComplexVisit.Month.Colors.Selected.Border = Color.Black;
            _calComplexVisit.Month.Colors.Trailing.BackColor1 = Color.WhiteSmoke;
            _calComplexVisit.Month.Colors.Trailing.Date = Color.DimGray;
            _calComplexVisit.Month.Colors.Trailing.Text = Color.Transparent;
            _calComplexVisit.Month.Colors.Weekend.BackColor1 = Color.DarkOrange;
            _calComplexVisit.Month.DateFont = new Font("Microsoft Sans Serif", 8.25F);
            _calComplexVisit.Month.TextFont = new Font("Microsoft Sans Serif", 8.25F);
            _calComplexVisit.Name = "calComplexVisit";
            _calComplexVisit.SelectionMode = Pabo.Calendar.mcSelectionMode.None;
            _calComplexVisit.ShowFooter = false;
            _calComplexVisit.Size = new Size(541, 168);
            _calComplexVisit.TabIndex = 16;
            _calComplexVisit.Weekdays.Font = new Font("Microsoft Sans Serif", 8.25F);
            _calComplexVisit.Weekdays.TextColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(177)), Conversions.ToInteger(Conversions.ToByte(179)), Conversions.ToInteger(Conversions.ToByte(200)));
            _calComplexVisit.Weeknumbers.Font = new Font("Microsoft Sans Serif", 8.25F);
            _calComplexVisit.Weeknumbers.TextColor = Color.FromArgb(Conversions.ToInteger(Conversions.ToByte(177)), Conversions.ToInteger(Conversions.ToByte(179)), Conversions.ToInteger(Conversions.ToByte(200)));
            //
            // Label14
            //
            _Label14.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label14.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label14.Location = new Point(288, 199);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(248, 16);
            _Label14.TabIndex = 15;
            _Label14.Text = "NOT OK - Job or Absence overlap";
            //
            // Panel5
            //
            _Panel5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Panel5.BackColor = Color.Salmon;
            _Panel5.Location = new Point(264, 199);
            _Panel5.Name = "Panel5";
            _Panel5.Size = new Size(16, 16);
            _Panel5.TabIndex = 13;
            //
            // Label16
            //
            _Label16.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label16.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label16.Location = new Point(40, 199);
            _Label16.Name = "Label16";
            _Label16.Size = new Size(107, 14);
            _Label16.TabIndex = 11;
            _Label16.Text = "Selected Dates";
            //
            // Panel7
            //
            _Panel7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Panel7.BackColor = Color.LightSteelBlue;
            _Panel7.Location = new Point(17, 197);
            _Panel7.Name = "Panel7";
            _Panel7.Size = new Size(16, 16);
            _Panel7.TabIndex = 9;
            //
            // Panel8
            //
            _Panel8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Panel8.BackColor = Color.DarkOrange;
            _Panel8.Location = new Point(160, 199);
            _Panel8.Name = "Panel8";
            _Panel8.Size = new Size(16, 16);
            _Panel8.TabIndex = 8;
            //
            // Label17
            //
            _Label17.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label17.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label17.Location = new Point(184, 199);
            _Label17.Name = "Label17";
            _Label17.Size = new Size(71, 16);
            _Label17.TabIndex = 10;
            _Label17.Text = "Weekend";
            //
            // btnSaveComplex
            //
            _btnSaveComplex.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnSaveComplex.Location = new Point(397, 389);
            _btnSaveComplex.Name = "btnSaveComplex";
            _btnSaveComplex.Size = new Size(64, 23);
            _btnSaveComplex.TabIndex = 4;
            _btnSaveComplex.Text = "Ok";
            //
            // btnCancel2
            //
            _btnCancel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnCancel2.Location = new Point(490, 389);
            _btnCancel2.Name = "btnCancel2";
            _btnCancel2.Size = new Size(64, 23);
            _btnCancel2.TabIndex = 5;
            _btnCancel2.Text = "Cancel";
            //
            // GroupBox4
            //
            _GroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox4.Controls.Add(_btnAdditionalVisit);
            _GroupBox4.Controls.Add(_Panel9);
            _GroupBox4.Location = new Point(3, 237);
            _GroupBox4.Name = "GroupBox4";
            _GroupBox4.Size = new Size(555, 138);
            _GroupBox4.TabIndex = 17;
            _GroupBox4.TabStop = false;
            _GroupBox4.Text = "Schedule Visit For";
            //
            // btnAdditionalVisit
            //
            _btnAdditionalVisit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAdditionalVisit.Location = new Point(505, 20);
            _btnAdditionalVisit.Name = "btnAdditionalVisit";
            _btnAdditionalVisit.Size = new Size(20, 22);
            _btnAdditionalVisit.TabIndex = 66;
            _btnAdditionalVisit.Tag = "";
            _btnAdditionalVisit.Text = "+";
            _ttComplexVisits.SetToolTip(_btnAdditionalVisit, "Add new visit");
            //
            // Panel9
            //
            _Panel9.AutoScroll = true;
            _Panel9.Controls.Add(_pnlLayout);
            _Panel9.Controls.Add(_Label13);
            _Panel9.Dock = DockStyle.Fill;
            _Panel9.Location = new Point(3, 17);
            _Panel9.Name = "Panel9";
            _Panel9.Size = new Size(549, 118);
            _Panel9.TabIndex = 67;
            //
            // pnlLayout
            //
            _pnlLayout.AutoSize = true;
            _pnlLayout.ColumnCount = 6;
            _pnlLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.85714F));
            _pnlLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72.14286F));
            _pnlLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 37.0F));
            _pnlLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 108.0F));
            _pnlLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 45.0F));
            _pnlLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 47.0F));
            _pnlLayout.Location = new Point(12, 28);
            _pnlLayout.Name = "pnlLayout";
            _pnlLayout.RowCount = 1;
            _pnlLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0F));
            _pnlLayout.Size = new Size(371, 30);
            _pnlLayout.TabIndex = 3;
            //
            // Label13
            //
            _Label13.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _Label13.Location = new Point(11, 4);
            _Label13.Name = "Label13";
            _Label13.Size = new Size(421, 21);
            _Label13.TabIndex = 17;
            _Label13.Text = "CLICK + TO ADD VISIT";
            //
            // frmVisit
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(570, 487);
            ControlBox = false;
            Controls.Add(_tabCtrlVisits);
            MaximizeBox = false;
            MaximumSize = new Size(1000, 1000);
            MinimizeBox = false;
            MinimumSize = new Size(560, 450);
            Name = "frmVisit";
            Text = "Schedule Visit";
            Controls.SetChildIndex(_tabCtrlVisits, 0);
            _tabCtrlVisits.ResumeLayout(false);
            _tabStandardVisit.ResumeLayout(false);
            _GroupBox2.ResumeLayout(false);
            _GroupBox2.PerformLayout();
            _GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_picPlanner).EndInit();
            _tabComplexVisit.ResumeLayout(false);
            _GroupBox3.ResumeLayout(false);
            _GroupBox4.ResumeLayout(false);
            _Panel9.ResumeLayout(false);
            _Panel9.PerformLayout();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        private bool isCopy = false;
        private frmDetailsPopup _detailPopup;
        private DataTable timeSlotDt;

        public DataTable DtTimeSlot
        {
            get
            {
                return timeSlotDt;
            }

            set
            {
                timeSlotDt = value;
            }
        }

        private string _engineerID;

        public string engineerID
        {
            get
            {
                return _engineerID;
            }

            set
            {
                _engineerID = value;
            }
        }

        private string _AMPM = "";

        public string AMPM
        {
            get
            {
                return _AMPM;
            }

            set
            {
                _AMPM = value;
                var switchExpr = AMPM;
                switch (switchExpr)
                {
                    case "AM":
                        {
                            lblAMPM.Text = "Due for AM arrival";
                            break;
                        }

                    case "PM":
                        {
                            lblAMPM.Text = "Due for PM arrival";
                            break;
                        }

                    default:
                        {
                            lblAMPM.Text = "";
                            break;
                        }
                }
            }
        }

        private DateTime _theSelectedDay;

        public DateTime theSelectedDay
        {
            get
            {
                return _theSelectedDay;
            }

            set
            {
                _theSelectedDay = value;
            }
        }

        private DateTime _StartDate;

        public DateTime StartDate
        {
            get
            {
                return _StartDate;
            }

            set
            {
                _StartDate = value;
            }
        }

        private DateTime _EndDate;

        public DateTime EndDate
        {
            get
            {
                return _EndDate;
            }

            set
            {
                _EndDate = value;
            }
        }

        private int _AppointmentType;

        public int AppointmentType
        {
            get
            {
                return _AppointmentType;
            }

            set
            {
                _AppointmentType = value;
            }
        }

        private int _SORMinutes;

        private int SORMinutes
        {
            get
            {
                return _SORMinutes;
            }

            set
            {
                _SORMinutes = value;
            }
        }

        public bool IsFormDisposed
        {
            get
            {
                return IsDisposed;
            }
        }

        public PictureBox ThePlanner
        {
            get
            {
                return picPlanner;
            }
        }

        public IntPtr TheHandle
        {
            get
            {
                return Handle;
            }
        }

        public string MyName
        {
            get
            {
                return "frmVisit";
            }
        }

        public string selectedDay()
        {
            return Conversions.ToString(theSelectedDay);
        }

        public bool mulitpleVisits = false;
        private List<List<DateTime>> _visitsList = new List<List<DateTime>>();

        public List<List<DateTime>> VisitsList
        {
            get
            {
                return _visitsList;
            }
        }

        public string EngineerID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public PictureBox PicPlanner => throw new NotImplementedException();

        public DataTable TimeSlotDt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime startTime;
            DateTime endTime;
            var settings = App.DB.Manager.Get();
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboAppointment)) < 1)
            {
                MessageBox.Show("You must select an Appointment Type!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return;
            }

            if (txtStartTimeHours.Text.Trim().Length == 0 & txtStartTimeMinutes.Text.Trim().Length == 0)
            {
                startTime = new DateTime(theSelectedDay.Year, theSelectedDay.Month, theSelectedDay.Day, Conversions.ToInteger(settings.WorkingHoursStart.Substring(0, 2)), Conversions.ToInteger(settings.WorkingHoursStart.Substring(3, 2)), 0);
            }
            else
            {
                if (!(Information.IsNumeric(txtStartTimeHours.Text) && Conversions.ToDouble(txtStartTimeHours.Text) >= 0 && Conversions.ToDouble(txtStartTimeHours.Text) <= 23 && Information.IsNumeric(txtStartTimeMinutes.Text) && Conversions.ToDouble(txtStartTimeMinutes.Text) >= 0 && Conversions.ToDouble(txtStartTimeMinutes.Text) <= 59))
                {
                    MessageBox.Show("Start time is not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    return;
                }

                startTime = new DateTime(theSelectedDay.Year, theSelectedDay.Month, theSelectedDay.Day, Conversions.ToInteger(txtStartTimeHours.Text), Conversions.ToInteger(txtStartTimeMinutes.Text), 0);
            }

            if (txtEndTimeHours.Text.Trim().Length == 0 & txtEndTimeMinutes.Text.Trim().Length == 0)
            {
                endTime = new DateTime(theSelectedDay.Year, theSelectedDay.Month, theSelectedDay.Day, Conversions.ToInteger(settings.WorkingHoursEnd.Substring(0, 2)), Conversions.ToInteger(settings.WorkingHoursEnd.Substring(3, 2)), 0);
            }
            else
            {
                if (!(Information.IsNumeric(txtEndTimeHours.Text) && Conversions.ToDouble(txtEndTimeHours.Text) >= 0 && Conversions.ToDouble(txtEndTimeHours.Text) <= 23 && Information.IsNumeric(txtEndTimeMinutes.Text) && Conversions.ToDouble(txtEndTimeMinutes.Text) >= 0 && Conversions.ToDouble(txtEndTimeMinutes.Text) <= 59))
                {
                    MessageBox.Show("End time is not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    return;
                }

                endTime = new DateTime(theSelectedDay.Year, theSelectedDay.Month, theSelectedDay.Day, Conversions.ToInteger(txtEndTimeHours.Text), Conversions.ToInteger(txtEndTimeMinutes.Text), 0);
            }

            if (DateTime.Compare(startTime, endTime) > 0)
            {
                MessageBox.Show("End date can not be before start date!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return;
            }

            if (!CheckDateAndContinue(startTime))
            {
                return;
            }

            StartDate = startTime;
            EndDate = endTime;
            AppointmentType = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboAppointment));
            DialogResult = DialogResult.OK;
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private bool CheckDateAndContinue(DateTime startTime)
        {
            var switchExpr = AMPM;
            switch (switchExpr)
            {
                case "":
                    {
                        return true;
                    }

                case "AM":
                    {
                        if (startTime > new DateTime(startTime.Year, startTime.Month, startTime.Day, 12, 30, 0))
                        {
                            if (App.ShowMessage("The visit is due for an AM start, (before 12:30)." + Constants.vbCrLf + "Do you wish to continue with " + Strings.Format(startTime, "HH:mm") + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return false;
                            }
                            else
                            {
                                if (isCopy)
                                {
                                    return true;
                                }

                                // Dim dialogue As DLGPasswordOverride
                                // dialogue = checkIfExists(GetType(DLGPasswordOverride).Name, True)
                                // If dialogue Is Nothing Then
                                // dialogue = Activator.CreateInstance(GetType(DLGPasswordOverride))
                                // End If
                                // dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
                                // dialogue.ShowInTaskbar = False

                                // dialogue.ShowDialog()

                                // If dialogue.DialogResult = DialogResult.OK Then
                                // DialogResult = DialogResult.OK
                                return true;
                                // Else
                                // Me.DialogResult = DialogResult.No
                                // ShowMessage("Override Password is required to continue, visit not scheduled.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                // Return False
                                // End If
                            }
                        }
                        else
                        {
                            return true;
                        }

                        break;
                    }

                case "PM":
                    {
                        if (startTime < new DateTime(startTime.Year, startTime.Month, startTime.Day, 12, 30, 0))
                        {
                            if (App.ShowMessage("The visit is due for a PM start, (after 12:30)." + Constants.vbCrLf + "Do you wish to continue with " + Strings.Format(startTime, "HH:mm") + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return false;
                            }
                            else
                            {
                                if (isCopy)
                                {
                                    return true;
                                }

                                // Dim dialogue As DLGPasswordOverride
                                // dialogue = checkIfExists(GetType(DLGPasswordOverride).Name, True)
                                // If dialogue Is Nothing Then
                                // dialogue = Activator.CreateInstance(GetType(DLGPasswordOverride))
                                // End If
                                // dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
                                // dialogue.ShowInTaskbar = False

                                // dialogue.ShowDialog()

                                // If dialogue.DialogResult = DialogResult.OK Then
                                // DialogResult = DialogResult.OK
                                return true;
                                // Else
                                // Me.DialogResult = DialogResult.No
                                // ShowMessage("Override Password is required to continue, visit not scheduled.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                // Return False
                                // End If
                            }
                        }
                        else
                        {
                            return true;
                        }

                        break;
                    }
            }

            return default;
        }

        private Bitmap scheduler_DayTimeSlots_bitmap()
        {
            try
            {
                if (DtTimeSlot is object && picPlanner.Height > 0 && picPlanner.Width > 0)
                {
                    var timeSlots = new Bitmap(picPlanner.Width, picPlanner.Height);
                    var timeSlotGfx = Graphics.FromImage(timeSlots);
                    float slotWidth = Conversions.ToSingle(timeSlots.Width - 9) / Conversions.ToSingle(DtTimeSlot.Columns.Count - 1);
                    var currentHour = default(string);
                    foreach (DataColumn time in DtTimeSlot.Columns)
                    {
                        DateTime theDateTimeColumn = default;
                        DateTime theTimeEnteredStart = default;
                        DateTime theTimeEnteredEnd = default;
                        if (!string.IsNullOrEmpty(txtStartTimeHours.Text) && !string.IsNullOrEmpty(txtStartTimeMinutes.Text) && !string.IsNullOrEmpty(txtEndTimeHours.Text) && !string.IsNullOrEmpty(txtEndTimeMinutes.Text))
                        {
                            theDateTimeColumn = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(time.ColumnName.Substring(1, 2)), Convert.ToInt32(time.ColumnName.Substring(3, 2)), 0);
                            theTimeEnteredStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(txtStartTimeHours.Text.Trim()), Convert.ToInt32(txtStartTimeMinutes.Text.Trim()), 0);
                            theTimeEnteredEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(txtEndTimeHours.Text.Trim()), Convert.ToInt32(txtEndTimeMinutes.Text.Trim()), 0);
                        }

                        Color TheColour;
                        TheColour = Color.WhiteSmoke;
                        if (DtTimeSlot.Rows.Count > 0 && Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(DtTimeSlot.Rows[0][time], 1, false)))
                        {
                            try
                            {
                                if (theTimeEnteredStart <= theDateTimeColumn & theTimeEnteredEnd >= theDateTimeColumn.AddMinutes(App.DB.Manager.Get().TimeSlot))
                                {
                                    TheColour = Color.Salmon;
                                }
                                else
                                {
                                    TheColour = Color.LightSteelBlue;
                                }
                            }
                            catch (Exception ex)
                            {
                                TheColour = Color.LightSteelBlue;
                            }
                        }

                        try
                        {
                            if ((TheColour.Name ?? "") == (Color.WhiteSmoke.Name ?? ""))
                            {
                                if (theDateTimeColumn >= theTimeEnteredStart & theDateTimeColumn < theTimeEnteredEnd)
                                {
                                    TheColour = Color.LightGreen;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // DO NOTHING
                        }

                        timeSlotGfx.FillRectangle(new SolidBrush(TheColour), new RectangleF(slotWidth * Conversions.ToSingle(DtTimeSlot.Columns.IndexOf(time)), 0, slotWidth, Conversions.ToSingle(picPlanner.Height - 15)));
                        if ((time.ColumnName.Substring(1, 2) ?? "") != (currentHour ?? ""))
                        {
                            currentHour = time.ColumnName.Substring(1, 2);
                            timeSlotGfx.DrawLine(new Pen(Color.RoyalBlue), slotWidth * Conversions.ToSingle(DtTimeSlot.Columns.IndexOf(time)), 0, slotWidth * Conversions.ToSingle(DtTimeSlot.Columns.IndexOf(time)), Conversions.ToSingle(picPlanner.Height - 12));
                            var hourFont = new Font(base.Font.Name, 6, FontStyle.Regular);
                            timeSlotGfx.DrawString(currentHour, hourFont, new SolidBrush(Color.Black), slotWidth * Conversions.ToSingle(DtTimeSlot.Columns.IndexOf(time)) - timeSlotGfx.MeasureString(currentHour, hourFont).Width / 2, Conversions.ToSingle(picPlanner.Height - timeSlotGfx.MeasureString(currentHour, hourFont).Height - 1));
                        }
                        else
                        {
                            timeSlotGfx.DrawLine(new Pen(Color.RoyalBlue), slotWidth * Conversions.ToSingle(DtTimeSlot.Columns.IndexOf(time)), 0, slotWidth * Conversions.ToSingle(DtTimeSlot.Columns.IndexOf(time)), Conversions.ToSingle(picPlanner.Height - 13));
                        }
                    }

                    return timeSlots;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void frmVisit_SizeChanged(object sender, EventArgs e)
        {
            picPlanner.Image = scheduler_DayTimeSlots_bitmap();
        }

        private void frmVisit_Load(object sender, EventArgs e)
        {
            LoadForm(this);
            ActiveControl = txtStartTimeHours;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void txtEndTimeHours_TextChanged(object sender, EventArgs e)
        {
            var sequence = new TextBox[] { txtStartTimeHours, txtStartTimeMinutes, txtEndTimeHours, txtEndTimeMinutes };
            TextBox currentBox = (TextBox)sender;
            if (currentBox.Text.Length >= 2 && Array.IndexOf(sequence, currentBox) < sequence.Length - 1)
            {
                sequence[Array.IndexOf(sequence, currentBox) + 1].Focus();
                sequence[Array.IndexOf(sequence, currentBox) + 1].SelectAll();
            }
            else if (currentBox.Text.Length == 0 && Array.IndexOf(sequence, currentBox) - 1 >= 0)
            {
                sequence[Array.IndexOf(sequence, currentBox) - 1].Focus();
                sequence[Array.IndexOf(sequence, currentBox) - 1].SelectAll();
            }

            if (SORMinutes > 0)
            {
                if (((currentBox.Name ?? "") == "txtStartTimeMinutes" | (currentBox.Name ?? "") == "txtStartTimeHours") & txtStartTimeMinutes.Text.Length >= 2 & txtStartTimeHours.Text.Length >= 2)
                {
                    try
                    {
                        DateTime enteredStartTime = Conversions.ToDate("01/01/1980 " + txtStartTimeHours.Text + ":" + txtStartTimeMinutes.Text);
                        DateTime calculatedEndTime;
                        // ADD SOR Minutes
                        calculatedEndTime = enteredStartTime.AddMinutes(SORMinutes);
                        if (calculatedEndTime.Hour.ToString().Length == 1)
                        {
                            txtEndTimeHours.Text = "0" + calculatedEndTime.Hour;
                        }
                        else
                        {
                            txtEndTimeHours.Text = calculatedEndTime.Hour.ToString();
                        }

                        if (calculatedEndTime.Minute.ToString().Length == 1)
                        {
                            txtEndTimeMinutes.Text = "0" + calculatedEndTime.Minute;
                        }
                        else
                        {
                            txtEndTimeMinutes.Text = calculatedEndTime.Minute.ToString();
                        }

                        btnSave.Focus();
                    }
                    catch (Exception ex)
                    {
                        // EMPTY
                    }
                }
            }

            picPlanner.Image = scheduler_DayTimeSlots_bitmap();
        }

        private void picPlanner_MouseUp(object sender, MouseEventArgs e)
        {
            var timeSlots = new Bitmap(picPlanner.Width, picPlanner.Height);
            float slotWidth = Conversions.ToSingle(timeSlots.Width - 9) / Conversions.ToSingle(DtTimeSlot.Columns.Count - 1);
            if (e.Button == MouseButtons.Left)
            {
                int columnNumber = Conversions.ToInteger(Math.Ceiling(e.X / slotWidth)) - 1;
                if (columnNumber < 0)
                {
                    columnNumber = 0;
                }

                if (columnNumber > DtTimeSlot.Columns.Count - 1)
                {
                    columnNumber = DtTimeSlot.Columns.Count - 1;
                }

                string columnName = DtTimeSlot.Columns[columnNumber].ColumnName;
                string hours = columnName.Substring(1, 2);
                string minutes = columnName.Substring(3, 2);
                txtStartTimeHours.Text = hours;
                txtStartTimeMinutes.Text = minutes;
            }
            else if (e.Button == MouseButtons.Right)
            {
                int columnNumber = Conversions.ToInteger(Math.Ceiling(e.X / slotWidth));
                if (columnNumber < 0)
                {
                    columnNumber = 0;
                }

                if (columnNumber > DtTimeSlot.Columns.Count - 1)
                {
                    columnNumber = DtTimeSlot.Columns.Count - 1;
                }

                string columnName = DtTimeSlot.Columns[columnNumber].ColumnName;
                string hours = columnName.Substring(1, 2);
                string minutes = columnName.Substring(3, 2);
                txtEndTimeHours.Text = hours;
                txtEndTimeMinutes.Text = minutes;
            }
        }

        /// <summary>
        /// Initialises the mulitple visits tab
        /// </summary>
        private void InitComplexVisits()
        {
            // set the default properites for calendar
            calComplexVisit.MinDate = DateTime.Now.AddMonths(-1);
            calComplexVisit.SelectDate(DateTime.Today);
            calComplexVisit.ActiveMonth.Month = DateTime.Now.Month;
            calComplexVisit.ActiveMonth.Year = DateTime.Now.Year;
            calComplexVisit.ExtendedSelectionKey = (Pabo.Calendar.mcExtendedSelectionKey)Keys.ControlKey;
            UpdateEngineerSchedule();
        }

        /// <summary>
        /// Gets the engineer's schedule for the selected month and highlights the days they are unavailable
        /// </summary>
        private void UpdateEngineerSchedule()
        {
            // get the month shown and set start and end dates
            var startDate = new DateTime(calComplexVisit.ActiveMonth.Year, calComplexVisit.ActiveMonth.Month, 1);
            var endDate = startDate.AddMonths(1);

            // get the engineer's status
            var dtEngineerJobs = App.DB.Scheduler.getSummaryNEW(engineerID, startDate, endDate);

            // check datatable is not empty
            if (dtEngineerJobs is object)
            {
                int index = 0;
                foreach (DataRow row in dtEngineerJobs.Rows)
                {
                    int workLoad = Entity.Sys.Helper.MakeIntegerValid(row["workCount"]);
                    int absence = Entity.Sys.Helper.MakeIntegerValid(row["AbsenceColumn"]);
                    var busyDate = Entity.Sys.Helper.MakeDateTimeValid(row["dayDate"]);
                    // if the engineer has work that day then they're busy
                    if (workLoad > 0 | absence > 0)
                    {
                        // set date to midnight for calendar control
                        busyDate = new DateTime(busyDate.Year, busyDate.Month, busyDate.Day, 0, 0, 0);
                        var item = calComplexVisit.GetDateInfo(busyDate);
                        if (item.Length > 0)
                        {
                        }
                        // do nothing
                        else
                        {
                            // engineer is busy so highlight red
                            var dateItem = new Pabo.Calendar.DateItem();
                            dateItem.Date = busyDate;
                            dateItem.BackColor1 = Color.Salmon;
                            calComplexVisit.AddDateInfo(dateItem);
                        }
                    }

                    index += 1;
                }
            }
        }

        /// <summary>
        /// Check to see if engineer is busy or absent
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>Boolean</returns>
        private bool IsEngineerWorkingOrAbsent(DateTime startDate, DateTime endDate)
        {
            // get the engineer's status
            bool isBusy = false;
            var dtEngineerJobs = App.DB.Scheduler.getSummaryNEW(engineerID, startDate, endDate);

            // checks if datatable is not empty
            if (dtEngineerJobs is object)
            {
                foreach (DataRow row in dtEngineerJobs.Rows)
                {
                    int workLoad = Entity.Sys.Helper.MakeIntegerValid(row["workCount"]);
                    int absence = Entity.Sys.Helper.MakeIntegerValid(row["AbsenceColumn"]);
                    // if the engineer has work that day then they're busy
                    if (workLoad > 0 | absence > 0)
                    {
                        isBusy = true;
                    }
                }
            }

            return isBusy;
        }

        private void btnAddVisit_Click(object sender, EventArgs e)
        {
            // get settings for default start and end times
            Button senderButton = (Button)sender;
            int index = btnAddVisits.IndexOf(senderButton);
            // get start and end from datepickers
            var dtpStart = dtpMulitpleVisitsStart[index];
            var dtpEnd = dtpMulitpleVisitsEnd[index];
            var startDate = dtpStart.Value;
            var endDate = dtpEnd.Value;
            if (!ValidateSelection(startDate, endDate))
            {
                App.ShowMessage("Dates selected overlap other dates, please check your selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // display engineer may busy on selected dates
            if (IsEngineerWorkingOrAbsent(startDate, endDate))
            {
                App.ShowMessage("Engineer might be unavailable on the dates selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // set current date as we need it for highlighting calender
            var currentDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0);
            var settings = App.DB.Manager.Get();

            // add visit to list
            _visitsList.Add(new List<DateTime>());
            _visitsList[index].Add(new DateTime(startDate.Year, startDate.Month, startDate.Day, Conversions.ToInteger(settings.WorkingHoursStart.Substring(0, 2)), Conversions.ToInteger(settings.WorkingHoursStart.Substring(3, 2)), 0));
            _visitsList[index].Add(new DateTime(endDate.Year, endDate.Month, endDate.Day, Conversions.ToInteger(settings.WorkingHoursEnd.Substring(0, 2)), Conversions.ToInteger(settings.WorkingHoursEnd.Substring(3, 2)), 0));

            // loop through each day between the dates and highlight them as selected in the calender
            while (currentDate <= endDate)
            {
                // if the date is already highlight then we override it
                var item = calComplexVisit.GetDateInfo(currentDate);
                if (item.Length > 0)
                {
                    foreach (Pabo.Calendar.DateItem _item in item)
                    {
                        _item.BackColor1 = Color.LightSteelBlue;
                        calComplexVisit.AddDateInfo(_item);
                    }
                }
                else  // create new highlight
                {
                    var dateItem = new Pabo.Calendar.DateItem();
                    dateItem.Date = currentDate;
                    dateItem.BackColor1 = Color.LightSteelBlue;
                    calComplexVisit.AddDateInfo(dateItem);
                }

                currentDate = currentDate.AddDays(1);
            }

            // disable the datepickers and the save button
            dtpStart.Enabled = false;
            dtpEnd.Enabled = false;
            senderButton.Enabled = false;
        }

        /// <summary>
        /// Validates the user's selection doesn't overlap with dates they have previously selected
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>Boolean</returns>
        private bool ValidateSelection(DateTime startDate, DateTime endDate)
        {
            bool overlap = false;
            foreach (List<DateTime> dates in _visitsList)
            {
                if (!overlap)
                {
                    overlap = dates[0] <= endDate & startDate <= dates[1];
                }
            }

            return Conversions.ToBoolean(Interaction.IIf(overlap, false, true));
        }

        private void DtpComplexVisit_MonthChanged(object sender, Pabo.Calendar.MonthChangedEventArgs e)
        {
            UpdateEngineerSchedule();
        }

        private void BtnSaveComplex_Click(object sender, EventArgs e)
        {
            // check we have visits saved
            if (_visitsList.Count == 0)
            {
                App.ShowMessage("No visits created, please create and save visits to continue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // check if any dates have not been saved
            foreach (DateTimePicker datepicker in dtpMulitpleVisitsStart)
            {
                if (datepicker.Enabled)
                {
                    App.ShowMessage("Visits not saved, please save visits to continue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // set muliplevisits to true for scheduler
            mulitpleVisits = true;

            // order visit list in date order
            _visitsList = _visitsList.OrderBy(i => i.OrderBy(x => x.Date).First()).ToList();
            AppointmentType = (int)Entity.Sys.Enums.Appointments.FirstCall;
            App.ShowMessage("You have successfully created " + _visitsList.Count + " visits", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void dtpMultipleStart_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker senderDtp = (DateTimePicker)sender;
            var dtpEnd = dtpMulitpleVisitsEnd[dtpMulitpleVisitsStart.IndexOf(senderDtp)];

            // update datepicker so dates are valid
            if (senderDtp.Value > dtpEnd.Value)
            {
                dtpEnd.Value = senderDtp.Value;
            }
        }

        private void dtpMultipleEnd_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker senderDtp = (DateTimePicker)sender;
            var dtpStart = dtpMulitpleVisitsStart[dtpMulitpleVisitsEnd.IndexOf(senderDtp)];

            // update datepicker so dates are valid
            if (senderDtp.Value < dtpStart.Value)
            {
                senderDtp.Value = dtpStart.Value;
            }
        }

        private void btnAdditionalVisit_Click(object sender, EventArgs e)
        {
            // we create all visit buttons add datepickers dynamically to ensure a nice ux
            int elementCount = btnRemoveVisits.Count;

            // define start label
            var lblStart = new Label();
            lblStart.Size = new Size(36, 17);
            lblStart.Text = "Start";
            lblStart.Name = "lblStart" + elementCount;
            lblStart.Anchor = AnchorStyles.None;
            lblStarts.Add(lblStart);

            // define start datepicker
            var dtpStart = new DateTimePicker();
            dtpStart.Format = DateTimePickerFormat.Short;
            dtpStart.Size = new Size(87, 21);
            dtpStart.Name = "dtpStart" + elementCount;
            dtpStart.Anchor = AnchorStyles.None;
            dtpStart.ValueChanged += dtpMultipleStart_ValueChanged;
            dtpMulitpleVisitsStart.Add(dtpStart);

            // define end label
            var lblEnd = new Label();
            lblEnd.Size = new Size(36, 17);
            lblEnd.Text = "End";
            lblEnd.Name = "lblEnd" + elementCount;
            lblEnd.Anchor = AnchorStyles.None;
            lblEnds.Add(lblEnd);

            // define end datepicker
            var dtpEnd = new DateTimePicker();
            dtpEnd.Format = DateTimePickerFormat.Short;
            dtpEnd.Size = new Size(87, 21);
            dtpEnd.Name = "dtpEnd" + elementCount;
            dtpEnd.Anchor = AnchorStyles.None;
            dtpEnd.ValueChanged += dtpMultipleEnd_ValueChanged;
            dtpMulitpleVisitsEnd.Add(dtpEnd);

            // define add visit button
            var btnNewVisit = new Button();
            btnNewVisit.ForeColor = Color.Green;
            btnNewVisit.Name = "btnAddVisit" + elementCount.ToString();
            btnNewVisit.Size = new Size(20, 22);
            btnNewVisit.Text = "✓";
            btnNewVisit.Anchor = AnchorStyles.None;
            btnNewVisit.FlatStyle = FlatStyle.Standard;
            btnNewVisit.Click += btnAddVisit_Click;
            btnAddVisits.Add(btnNewVisit);

            // define remove visit button
            var btnDeleteVisit = new Button();
            btnDeleteVisit.ForeColor = Color.Red;
            btnDeleteVisit.Name = "btnRemoveVisit" + elementCount.ToString();
            btnDeleteVisit.Size = new Size(20, 22);
            btnDeleteVisit.Anchor = AnchorStyles.None;
            btnDeleteVisit.FlatStyle = FlatStyle.Standard;
            btnDeleteVisit.Text = "X";
            btnDeleteVisit.Click += btnRemoveVisit_Click;
            btnRemoveVisits.Add(btnDeleteVisit);

            // add tooltips
            ttComplexVisits.SetToolTip(btnNewVisit, "Save selected dates");
            ttComplexVisits.SetToolTip(btnDeleteVisit, "Remove selected visit");

            // define the grid position of the controls
            if (elementCount > 0)
            {
                var ctrlPos = new List<int>();
                for (int i = 0, loopTo = pnlLayout.RowCount; i <= loopTo; i++)
                {
                    foreach (Label lbl in lblStarts)
                        ctrlPos.Add(pnlLayout.GetCellPosition(lbl).Row);
                }

                ctrlPos.Sort();
                if (ctrlPos.Contains(elementCount))
                    elementCount = ctrlPos[ctrlPos.Count - 1] + 1;
            }

            // position controls
            pnlLayout.SetCellPosition(lblStart, new TableLayoutPanelCellPosition(0, elementCount));
            pnlLayout.SetCellPosition(dtpStart, new TableLayoutPanelCellPosition(1, elementCount));
            pnlLayout.SetCellPosition(lblEnd, new TableLayoutPanelCellPosition(2, elementCount));
            pnlLayout.SetCellPosition(dtpEnd, new TableLayoutPanelCellPosition(3, elementCount));
            pnlLayout.SetCellPosition(btnNewVisit, new TableLayoutPanelCellPosition(4, elementCount));
            pnlLayout.SetCellPosition(btnDeleteVisit, new TableLayoutPanelCellPosition(5, elementCount));

            // add all new controls to grid
            pnlLayout.Controls.Add(lblStart);
            pnlLayout.Controls.Add(dtpStart);
            pnlLayout.Controls.Add(lblEnd);
            pnlLayout.Controls.Add(dtpEnd);
            pnlLayout.Controls.Add(btnNewVisit);
            pnlLayout.Controls.Add(btnDeleteVisit);
        }

        private void btnRemoveVisit_Click(object sender, EventArgs e)
        {
            // need to remove dates from form
            // get the relevant controls to delete
            Button senderButton = (Button)sender;
            int index = btnRemoveVisits.IndexOf(senderButton);
            var dtpStart = dtpMulitpleVisitsStart[index];
            var dtpEnd = dtpMulitpleVisitsEnd[index];
            var lblStart = lblStarts[index];
            var lblEnd = lblEnds[index];
            var btnAdd = btnAddVisits[index];

            // remove controls from panel
            pnlLayout.Controls.Remove(senderButton);
            pnlLayout.Controls.Remove(lblStart);
            pnlLayout.Controls.Remove(dtpStart);
            pnlLayout.Controls.Remove(lblEnd);
            pnlLayout.Controls.Remove(dtpEnd);
            pnlLayout.Controls.Remove(btnAdd);

            // remove controls from list
            dtpMulitpleVisitsStart.Remove(dtpStart);
            dtpMulitpleVisitsEnd.Remove(dtpEnd);
            btnRemoveVisits.Remove(senderButton);
            lblStarts.Remove(lblStart);
            lblEnds.Remove(lblEnd);
            btnAddVisits.Remove(btnAdd);

            // remove dates from list
            if (_visitsList.Count > 0 & _visitsList.Count - 1 >= index)
            {
                var startDate = _visitsList[index][0];
                var endDate = _visitsList[index][1];
                var currentDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0);
                _visitsList.RemoveAt(index);

                // update selection on calendar
                while (currentDate <= endDate)
                {
                    var item = calComplexVisit.GetDateInfo(currentDate);
                    if (item.Length > 0)
                    {
                        foreach (Pabo.Calendar.DateItem _item in item)
                            calComplexVisit.RemoveDateInfo(_item.Date);
                    }

                    currentDate = currentDate.AddDays(1);
                }

                UpdateEngineerSchedule();
            }
        }
    }
}