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

        private TabPage _tabStandardVisit;

        private TabPage _tabComplexVisit;

        private GroupBox _GroupBox2;

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

        private Label _Label10;

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

        private Panel _Panel1;

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

        private Panel _Panel3;

        private Panel _Panel4;

        private Label _Label8;

        private GroupBox _GroupBox3;

        private Label _Label14;

        private Panel _Panel5;

        private Label _Label16;

        private Panel _Panel7;

        private Panel _Panel8;

        private Label _Label17;

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

        private Button _btnSaveComplex;

        private Button _btnCancel2;

        private Button _btnAdditionalVisit;

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

        private Label _Label13;

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
            this.components = new System.ComponentModel.Container();
            this._tabCtrlVisits = new System.Windows.Forms.TabControl();
            this._tabStandardVisit = new System.Windows.Forms.TabPage();
            this._GroupBox2 = new System.Windows.Forms.GroupBox();
            this._cboAppointment = new System.Windows.Forms.ComboBox();
            this._Label12 = new System.Windows.Forms.Label();
            this._lblAMPM = new System.Windows.Forms.Label();
            this._Label11 = new System.Windows.Forms.Label();
            this._Label10 = new System.Windows.Forms.Label();
            this._txtEndTimeMinutes = new System.Windows.Forms.TextBox();
            this._txtEndTimeHours = new System.Windows.Forms.TextBox();
            this._txtStartTimeMinutes = new System.Windows.Forms.TextBox();
            this._txtStartTimeHours = new System.Windows.Forms.TextBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._Label3 = new System.Windows.Forms.Label();
            this._Label2 = new System.Windows.Forms.Label();
            this._Label1 = new System.Windows.Forms.Label();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._Label9 = new System.Windows.Forms.Label();
            this._Label6 = new System.Windows.Forms.Label();
            this._Label5 = new System.Windows.Forms.Label();
            this._Panel2 = new System.Windows.Forms.Panel();
            this._Panel1 = new System.Windows.Forms.Panel();
            this._picPlanner = new System.Windows.Forms.PictureBox();
            this._Label7 = new System.Windows.Forms.Label();
            this._Panel3 = new System.Windows.Forms.Panel();
            this._Panel4 = new System.Windows.Forms.Panel();
            this._Label8 = new System.Windows.Forms.Label();
            this._tabComplexVisit = new System.Windows.Forms.TabPage();
            this._GroupBox3 = new System.Windows.Forms.GroupBox();
            this._calComplexVisit = new Pabo.Calendar.MonthCalendar();
            this._Label14 = new System.Windows.Forms.Label();
            this._Panel5 = new System.Windows.Forms.Panel();
            this._Label16 = new System.Windows.Forms.Label();
            this._Panel7 = new System.Windows.Forms.Panel();
            this._Panel8 = new System.Windows.Forms.Panel();
            this._Label17 = new System.Windows.Forms.Label();
            this._btnSaveComplex = new System.Windows.Forms.Button();
            this._btnCancel2 = new System.Windows.Forms.Button();
            this._GroupBox4 = new System.Windows.Forms.GroupBox();
            this._btnAdditionalVisit = new System.Windows.Forms.Button();
            this._Panel9 = new System.Windows.Forms.Panel();
            this._pnlLayout = new System.Windows.Forms.TableLayoutPanel();
            this._Label13 = new System.Windows.Forms.Label();
            this._ttComplexVisits = new System.Windows.Forms.ToolTip(this.components);
            this._tabCtrlVisits.SuspendLayout();
            this._tabStandardVisit.SuspendLayout();
            this._GroupBox2.SuspendLayout();
            this._GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._picPlanner)).BeginInit();
            this._tabComplexVisit.SuspendLayout();
            this._GroupBox3.SuspendLayout();
            this._GroupBox4.SuspendLayout();
            this._Panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tabCtrlVisits
            // 
            this._tabCtrlVisits.Controls.Add(this._tabStandardVisit);
            this._tabCtrlVisits.Controls.Add(this._tabComplexVisit);
            this._tabCtrlVisits.Location = new System.Drawing.Point(0, 12);
            this._tabCtrlVisits.Name = "_tabCtrlVisits";
            this._tabCtrlVisits.SelectedIndex = 0;
            this._tabCtrlVisits.Size = new System.Drawing.Size(569, 471);
            this._tabCtrlVisits.TabIndex = 2;
            // 
            // _tabStandardVisit
            // 
            this._tabStandardVisit.Controls.Add(this._GroupBox2);
            this._tabStandardVisit.Controls.Add(this._GroupBox1);
            this._tabStandardVisit.Location = new System.Drawing.Point(4, 22);
            this._tabStandardVisit.Name = "_tabStandardVisit";
            this._tabStandardVisit.Padding = new System.Windows.Forms.Padding(3);
            this._tabStandardVisit.Size = new System.Drawing.Size(561, 445);
            this._tabStandardVisit.TabIndex = 0;
            this._tabStandardVisit.Text = "Standard Visit";
            this._tabStandardVisit.UseVisualStyleBackColor = true;
            // 
            // _GroupBox2
            // 
            this._GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox2.Controls.Add(this._cboAppointment);
            this._GroupBox2.Controls.Add(this._Label12);
            this._GroupBox2.Controls.Add(this._lblAMPM);
            this._GroupBox2.Controls.Add(this._Label11);
            this._GroupBox2.Controls.Add(this._Label10);
            this._GroupBox2.Controls.Add(this._txtEndTimeMinutes);
            this._GroupBox2.Controls.Add(this._txtEndTimeHours);
            this._GroupBox2.Controls.Add(this._txtStartTimeMinutes);
            this._GroupBox2.Controls.Add(this._txtStartTimeHours);
            this._GroupBox2.Controls.Add(this._Label4);
            this._GroupBox2.Controls.Add(this._Label3);
            this._GroupBox2.Controls.Add(this._Label2);
            this._GroupBox2.Controls.Add(this._Label1);
            this._GroupBox2.Controls.Add(this._btnSave);
            this._GroupBox2.Controls.Add(this._btnCancel);
            this._GroupBox2.Location = new System.Drawing.Point(3, 319);
            this._GroupBox2.Name = "_GroupBox2";
            this._GroupBox2.Size = new System.Drawing.Size(552, 120);
            this._GroupBox2.TabIndex = 3;
            this._GroupBox2.TabStop = false;
            this._GroupBox2.Text = "Schedule Visit For";
            // 
            // _cboAppointment
            // 
            this._cboAppointment.FormattingEnabled = true;
            this._cboAppointment.Location = new System.Drawing.Point(150, 86);
            this._cboAppointment.Name = "_cboAppointment";
            this._cboAppointment.Size = new System.Drawing.Size(210, 21);
            this._cboAppointment.TabIndex = 59;
            // 
            // _Label12
            // 
            this._Label12.Location = new System.Drawing.Point(10, 89);
            this._Label12.Name = "_Label12";
            this._Label12.Size = new System.Drawing.Size(134, 18);
            this._Label12.TabIndex = 58;
            this._Label12.Text = "Appointment Type:";
            // 
            // _lblAMPM
            // 
            this._lblAMPM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblAMPM.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblAMPM.ForeColor = System.Drawing.Color.Red;
            this._lblAMPM.Location = new System.Drawing.Point(410, 35);
            this._lblAMPM.Name = "_lblAMPM";
            this._lblAMPM.Size = new System.Drawing.Size(136, 17);
            this._lblAMPM.TabIndex = 57;
            this._lblAMPM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _Label11
            // 
            this._Label11.Location = new System.Drawing.Point(8, 48);
            this._Label11.Name = "_Label11";
            this._Label11.Size = new System.Drawing.Size(176, 17);
            this._Label11.TabIndex = 56;
            this._Label11.Text = "Blank assumes \"start of day\"";
            // 
            // _Label10
            // 
            this._Label10.Location = new System.Drawing.Point(200, 48);
            this._Label10.Name = "_Label10";
            this._Label10.Size = new System.Drawing.Size(168, 17);
            this._Label10.TabIndex = 55;
            this._Label10.Text = "Blank assumes \"end of day\"";
            // 
            // _txtEndTimeMinutes
            // 
            this._txtEndTimeMinutes.Location = new System.Drawing.Point(336, 21);
            this._txtEndTimeMinutes.Name = "_txtEndTimeMinutes";
            this._txtEndTimeMinutes.Size = new System.Drawing.Size(24, 21);
            this._txtEndTimeMinutes.TabIndex = 3;
            this._txtEndTimeMinutes.TextChanged += new System.EventHandler(this.txtEndTimeHours_TextChanged);
            // 
            // _txtEndTimeHours
            // 
            this._txtEndTimeHours.Location = new System.Drawing.Point(288, 21);
            this._txtEndTimeHours.Name = "_txtEndTimeHours";
            this._txtEndTimeHours.Size = new System.Drawing.Size(24, 21);
            this._txtEndTimeHours.TabIndex = 3;
            this._txtEndTimeHours.TextChanged += new System.EventHandler(this.txtEndTimeHours_TextChanged);
            // 
            // _txtStartTimeMinutes
            // 
            this._txtStartTimeMinutes.Location = new System.Drawing.Point(150, 21);
            this._txtStartTimeMinutes.Name = "_txtStartTimeMinutes";
            this._txtStartTimeMinutes.Size = new System.Drawing.Size(24, 21);
            this._txtStartTimeMinutes.TabIndex = 2;
            this._txtStartTimeMinutes.TextChanged += new System.EventHandler(this.txtEndTimeHours_TextChanged);
            // 
            // _txtStartTimeHours
            // 
            this._txtStartTimeHours.Location = new System.Drawing.Point(104, 21);
            this._txtStartTimeHours.Name = "_txtStartTimeHours";
            this._txtStartTimeHours.Size = new System.Drawing.Size(24, 21);
            this._txtStartTimeHours.TabIndex = 1;
            this._txtStartTimeHours.TextChanged += new System.EventHandler(this.txtEndTimeHours_TextChanged);
            // 
            // _Label4
            // 
            this._Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label4.Location = new System.Drawing.Point(320, 24);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(8, 17);
            this._Label4.TabIndex = 4;
            this._Label4.Text = ":";
            // 
            // _Label3
            // 
            this._Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label3.Location = new System.Drawing.Point(136, 24);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(8, 17);
            this._Label3.TabIndex = 54;
            this._Label3.Text = ":";
            // 
            // _Label2
            // 
            this._Label2.Location = new System.Drawing.Point(200, 24);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(64, 17);
            this._Label2.TabIndex = 1;
            this._Label2.Text = "End Time";
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(8, 24);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(77, 17);
            this._Label1.TabIndex = 0;
            this._Label1.Text = "Start Time";
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSave.Location = new System.Drawing.Point(396, 86);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(64, 23);
            this._btnSave.TabIndex = 4;
            this._btnSave.Text = "Ok";
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.Location = new System.Drawing.Point(482, 86);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(64, 23);
            this._btnCancel.TabIndex = 5;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._Label9);
            this._GroupBox1.Controls.Add(this._Label6);
            this._GroupBox1.Controls.Add(this._Label5);
            this._GroupBox1.Controls.Add(this._Panel2);
            this._GroupBox1.Controls.Add(this._Panel1);
            this._GroupBox1.Controls.Add(this._picPlanner);
            this._GroupBox1.Controls.Add(this._Label7);
            this._GroupBox1.Controls.Add(this._Panel3);
            this._GroupBox1.Controls.Add(this._Panel4);
            this._GroupBox1.Controls.Add(this._Label8);
            this._GroupBox1.Location = new System.Drawing.Point(3, 3);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(555, 310);
            this._GroupBox1.TabIndex = 2;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Planner";
            // 
            // _Label9
            // 
            this._Label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._Label9.Location = new System.Drawing.Point(8, 238);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(533, 16);
            this._Label9.TabIndex = 16;
            this._Label9.Text = "Hold Shift and LEFT click period for START time or RIGHT click period for END tim" +
    "e";
            // 
            // _Label6
            // 
            this._Label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label6.Location = new System.Drawing.Point(240, 286);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(248, 16);
            this._Label6.TabIndex = 15;
            this._Label6.Text = "NOT OK - Job or Absence overlap";
            // 
            // _Label5
            // 
            this._Label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label5.Location = new System.Drawing.Point(32, 286);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(184, 16);
            this._Label5.TabIndex = 14;
            this._Label5.Text = "OK - No overlap";
            // 
            // _Panel2
            // 
            this._Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Panel2.BackColor = System.Drawing.Color.Salmon;
            this._Panel2.Location = new System.Drawing.Point(216, 286);
            this._Panel2.Name = "_Panel2";
            this._Panel2.Size = new System.Drawing.Size(16, 16);
            this._Panel2.TabIndex = 13;
            // 
            // _Panel1
            // 
            this._Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Panel1.BackColor = System.Drawing.Color.LightGreen;
            this._Panel1.Location = new System.Drawing.Point(8, 286);
            this._Panel1.Name = "_Panel1";
            this._Panel1.Size = new System.Drawing.Size(16, 16);
            this._Panel1.TabIndex = 12;
            // 
            // _picPlanner
            // 
            this._picPlanner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._picPlanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._picPlanner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._picPlanner.Location = new System.Drawing.Point(8, 23);
            this._picPlanner.Name = "_picPlanner";
            this._picPlanner.Size = new System.Drawing.Size(541, 202);
            this._picPlanner.TabIndex = 0;
            this._picPlanner.TabStop = false;
            this._picPlanner.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picPlanner_MouseUp);
            // 
            // _Label7
            // 
            this._Label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label7.Location = new System.Drawing.Point(32, 262);
            this._Label7.Name = "_Label7";
            this._Label7.Size = new System.Drawing.Size(168, 16);
            this._Label7.TabIndex = 11;
            this._Label7.Text = "Booked Schedule Period";
            // 
            // _Panel3
            // 
            this._Panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this._Panel3.Location = new System.Drawing.Point(8, 262);
            this._Panel3.Name = "_Panel3";
            this._Panel3.Size = new System.Drawing.Size(16, 16);
            this._Panel3.TabIndex = 9;
            // 
            // _Panel4
            // 
            this._Panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._Panel4.Location = new System.Drawing.Point(216, 262);
            this._Panel4.Name = "_Panel4";
            this._Panel4.Size = new System.Drawing.Size(16, 16);
            this._Panel4.TabIndex = 8;
            // 
            // _Label8
            // 
            this._Label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label8.Location = new System.Drawing.Point(240, 262);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(176, 16);
            this._Label8.TabIndex = 10;
            this._Label8.Text = "Free Schedule Period";
            // 
            // _tabComplexVisit
            // 
            this._tabComplexVisit.Controls.Add(this._GroupBox3);
            this._tabComplexVisit.Controls.Add(this._btnSaveComplex);
            this._tabComplexVisit.Controls.Add(this._btnCancel2);
            this._tabComplexVisit.Controls.Add(this._GroupBox4);
            this._tabComplexVisit.Location = new System.Drawing.Point(4, 22);
            this._tabComplexVisit.Name = "_tabComplexVisit";
            this._tabComplexVisit.Padding = new System.Windows.Forms.Padding(3);
            this._tabComplexVisit.Size = new System.Drawing.Size(561, 424);
            this._tabComplexVisit.TabIndex = 1;
            this._tabComplexVisit.Text = "Complex Visit";
            this._tabComplexVisit.UseVisualStyleBackColor = true;
            // 
            // _GroupBox3
            // 
            this._GroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox3.Controls.Add(this._calComplexVisit);
            this._GroupBox3.Controls.Add(this._Label14);
            this._GroupBox3.Controls.Add(this._Panel5);
            this._GroupBox3.Controls.Add(this._Label16);
            this._GroupBox3.Controls.Add(this._Panel7);
            this._GroupBox3.Controls.Add(this._Panel8);
            this._GroupBox3.Controls.Add(this._Label17);
            this._GroupBox3.Location = new System.Drawing.Point(3, 3);
            this._GroupBox3.Name = "_GroupBox3";
            this._GroupBox3.Size = new System.Drawing.Size(555, 228);
            this._GroupBox3.TabIndex = 13;
            this._GroupBox3.TabStop = false;
            this._GroupBox3.Text = "Planner";
            // 
            // _calComplexVisit
            // 
            this._calComplexVisit.ActiveMonth.Month = 1;
            this._calComplexVisit.ActiveMonth.Year = 2018;
            this._calComplexVisit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(198)))), ((int)(((byte)(214)))));
            this._calComplexVisit.Culture = new System.Globalization.CultureInfo("en-GB");
            this._calComplexVisit.ExtendedSelectionKey = Pabo.Calendar.mcExtendedSelectionKey.Shift;
            this._calComplexVisit.Footer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this._calComplexVisit.Header.BackColor1 = System.Drawing.Color.Blue;
            this._calComplexVisit.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this._calComplexVisit.Header.TextColor = System.Drawing.Color.White;
            this._calComplexVisit.ImageList = null;
            this._calComplexVisit.Location = new System.Drawing.Point(7, 23);
            this._calComplexVisit.MaxDate = new System.DateTime(2027, 5, 10, 12, 28, 13, 983);
            this._calComplexVisit.MinDate = new System.DateTime(2018, 1, 11, 0, 0, 0, 0);
            this._calComplexVisit.Month.BackgroundImage = null;
            this._calComplexVisit.Month.Colors.Focus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(213)))), ((int)(((byte)(224)))));
            this._calComplexVisit.Month.Colors.Focus.Border = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(198)))), ((int)(((byte)(214)))));
            this._calComplexVisit.Month.Colors.Selected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this._calComplexVisit.Month.Colors.Selected.Border = System.Drawing.Color.Black;
            this._calComplexVisit.Month.Colors.Trailing.BackColor1 = System.Drawing.Color.WhiteSmoke;
            this._calComplexVisit.Month.Colors.Trailing.Date = System.Drawing.Color.DimGray;
            this._calComplexVisit.Month.Colors.Trailing.Text = System.Drawing.Color.Transparent;
            this._calComplexVisit.Month.Colors.Weekend.BackColor1 = System.Drawing.Color.DarkOrange;
            this._calComplexVisit.Month.DateFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this._calComplexVisit.Month.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this._calComplexVisit.Name = "_calComplexVisit";
            this._calComplexVisit.SelectionMode = Pabo.Calendar.mcSelectionMode.None;
            this._calComplexVisit.ShowFooter = false;
            this._calComplexVisit.Size = new System.Drawing.Size(541, 168);
            this._calComplexVisit.TabIndex = 16;
            this._calComplexVisit.Weekdays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this._calComplexVisit.Weekdays.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(200)))));
            this._calComplexVisit.Weeknumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this._calComplexVisit.Weeknumbers.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(179)))), ((int)(((byte)(200)))));
            this._calComplexVisit.MonthChanged += new Pabo.Calendar.MonthChangedEventHandler(this.DtpComplexVisit_MonthChanged);
            // 
            // _Label14
            // 
            this._Label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label14.Location = new System.Drawing.Point(288, 199);
            this._Label14.Name = "_Label14";
            this._Label14.Size = new System.Drawing.Size(248, 16);
            this._Label14.TabIndex = 15;
            this._Label14.Text = "NOT OK - Job or Absence overlap";
            // 
            // _Panel5
            // 
            this._Panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Panel5.BackColor = System.Drawing.Color.Salmon;
            this._Panel5.Location = new System.Drawing.Point(264, 199);
            this._Panel5.Name = "_Panel5";
            this._Panel5.Size = new System.Drawing.Size(16, 16);
            this._Panel5.TabIndex = 13;
            // 
            // _Label16
            // 
            this._Label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label16.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label16.Location = new System.Drawing.Point(40, 199);
            this._Label16.Name = "_Label16";
            this._Label16.Size = new System.Drawing.Size(107, 14);
            this._Label16.TabIndex = 11;
            this._Label16.Text = "Selected Dates";
            // 
            // _Panel7
            // 
            this._Panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Panel7.BackColor = System.Drawing.Color.LightSteelBlue;
            this._Panel7.Location = new System.Drawing.Point(17, 197);
            this._Panel7.Name = "_Panel7";
            this._Panel7.Size = new System.Drawing.Size(16, 16);
            this._Panel7.TabIndex = 9;
            // 
            // _Panel8
            // 
            this._Panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Panel8.BackColor = System.Drawing.Color.DarkOrange;
            this._Panel8.Location = new System.Drawing.Point(160, 199);
            this._Panel8.Name = "_Panel8";
            this._Panel8.Size = new System.Drawing.Size(16, 16);
            this._Panel8.TabIndex = 8;
            // 
            // _Label17
            // 
            this._Label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label17.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label17.Location = new System.Drawing.Point(184, 199);
            this._Label17.Name = "_Label17";
            this._Label17.Size = new System.Drawing.Size(71, 16);
            this._Label17.TabIndex = 10;
            this._Label17.Text = "Weekend";
            // 
            // _btnSaveComplex
            // 
            this._btnSaveComplex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSaveComplex.Location = new System.Drawing.Point(397, 389);
            this._btnSaveComplex.Name = "_btnSaveComplex";
            this._btnSaveComplex.Size = new System.Drawing.Size(64, 23);
            this._btnSaveComplex.TabIndex = 4;
            this._btnSaveComplex.Text = "Ok";
            this._btnSaveComplex.Click += new System.EventHandler(this.BtnSaveComplex_Click);
            // 
            // _btnCancel2
            // 
            this._btnCancel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel2.Location = new System.Drawing.Point(490, 389);
            this._btnCancel2.Name = "_btnCancel2";
            this._btnCancel2.Size = new System.Drawing.Size(64, 23);
            this._btnCancel2.TabIndex = 5;
            this._btnCancel2.Text = "Cancel";
            this._btnCancel2.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // _GroupBox4
            // 
            this._GroupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox4.Controls.Add(this._btnAdditionalVisit);
            this._GroupBox4.Controls.Add(this._Panel9);
            this._GroupBox4.Location = new System.Drawing.Point(3, 237);
            this._GroupBox4.Name = "_GroupBox4";
            this._GroupBox4.Size = new System.Drawing.Size(555, 138);
            this._GroupBox4.TabIndex = 17;
            this._GroupBox4.TabStop = false;
            this._GroupBox4.Text = "Schedule Visit For";
            // 
            // _btnAdditionalVisit
            // 
            this._btnAdditionalVisit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAdditionalVisit.Location = new System.Drawing.Point(505, 20);
            this._btnAdditionalVisit.Name = "_btnAdditionalVisit";
            this._btnAdditionalVisit.Size = new System.Drawing.Size(20, 22);
            this._btnAdditionalVisit.TabIndex = 66;
            this._btnAdditionalVisit.Tag = "";
            this._btnAdditionalVisit.Text = "+";
            this._ttComplexVisits.SetToolTip(this._btnAdditionalVisit, "Add new visit");
            this._btnAdditionalVisit.Click += new System.EventHandler(this.btnAdditionalVisit_Click);
            // 
            // _Panel9
            // 
            this._Panel9.AutoScroll = true;
            this._Panel9.Controls.Add(this._pnlLayout);
            this._Panel9.Controls.Add(this._Label13);
            this._Panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Panel9.Location = new System.Drawing.Point(3, 17);
            this._Panel9.Name = "_Panel9";
            this._Panel9.Size = new System.Drawing.Size(549, 118);
            this._Panel9.TabIndex = 67;
            // 
            // _pnlLayout
            // 
            this._pnlLayout.AutoSize = true;
            this._pnlLayout.ColumnCount = 6;
            this._pnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.85714F));
            this._pnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.14286F));
            this._pnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this._pnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this._pnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this._pnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this._pnlLayout.Location = new System.Drawing.Point(12, 28);
            this._pnlLayout.Name = "_pnlLayout";
            this._pnlLayout.RowCount = 1;
            this._pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._pnlLayout.Size = new System.Drawing.Size(371, 30);
            this._pnlLayout.TabIndex = 3;
            // 
            // _Label13
            // 
            this._Label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._Label13.Location = new System.Drawing.Point(11, 4);
            this._Label13.Name = "_Label13";
            this._Label13.Size = new System.Drawing.Size(421, 21);
            this._Label13.TabIndex = 17;
            this._Label13.Text = "CLICK + TO ADD VISIT";
            // 
            // frmVisit
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(570, 487);
            this.ControlBox = false;
            this.Controls.Add(this._tabCtrlVisits);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(560, 450);
            this.Name = "frmVisit";
            this.Text = "Schedule Visit";
            this._tabCtrlVisits.ResumeLayout(false);
            this._tabStandardVisit.ResumeLayout(false);
            this._GroupBox2.ResumeLayout(false);
            this._GroupBox2.PerformLayout();
            this._GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._picPlanner)).EndInit();
            this._tabComplexVisit.ResumeLayout(false);
            this._GroupBox3.ResumeLayout(false);
            this._GroupBox4.ResumeLayout(false);
            this._Panel9.ResumeLayout(false);
            this._Panel9.PerformLayout();
            this.ResumeLayout(false);

        }

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