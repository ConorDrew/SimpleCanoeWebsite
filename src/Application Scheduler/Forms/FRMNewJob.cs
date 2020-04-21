using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FSM.Entity.Engineers;
using FSM.Entity.EngineerVisits;
using FSM.Entity.JobOfWorks;
using FSM.Entity.Jobs;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using FSM.Entity.Users;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FRMNewJob : Form
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMNewJob(DateTime visitDate = default, int engineerId = 0) : base()
        {
            InitializeComponent();
            var argc = cboJobType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc1 = cboAppointment;
            Combo.SetUpCombo(ref argc1, App.DB.Appointments.GetAll().Table, "AppointmentID", "Name", Enums.ComboValues.Please_Select);
            var argcombo = cboAppointment;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(Enums.Appointments.Anytime));
            if (visitDate != default)
                dtpVisitDate.Value = visitDate;
            Engineer = App.DB.Engineer.Engineer_Get(engineerId);
            txtStartTimeHours.Text = DateAndTime.Now.ToString("HH");
            txtStartTimeMinutes.Text = DateAndTime.Now.ToString("mm");
            txtEndTimeHours.Text = DateAndTime.Now.AddHours(1).ToString("HH");
            txtEndTimeMinutes.Text = DateAndTime.Now.ToString("mm");
            grpPaymentType.Visible = !App.IsRFT;
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

        private GroupBox _grpEngineer;

        internal GroupBox grpEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpEngineer != null)
                {
                }

                _grpEngineer = value;
                if (_grpEngineer != null)
                {
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

        private GroupBox _grpVisit;

        internal GroupBox grpVisit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpVisit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpVisit != null)
                {
                }

                _grpVisit = value;
                if (_grpVisit != null)
                {
                }
            }
        }

        private Label _lblVisitDate;

        internal Label lblVisitDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblVisitDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblVisitDate != null)
                {
                }

                _lblVisitDate = value;
                if (_lblVisitDate != null)
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

        private Label _lblAppointment;

        internal Label lblAppointment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAppointment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAppointment != null)
                {
                }

                _lblAppointment = value;
                if (_lblAppointment != null)
                {
                }
            }
        }

        private DateTimePicker _dtpVisitDate;

        internal DateTimePicker dtpVisitDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpVisitDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpVisitDate != null)
                {
                }

                _dtpVisitDate = value;
                if (_dtpVisitDate != null)
                {
                }
            }
        }

        private Button _btnCreate;

        internal Button btnCreate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCreate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCreate != null)
                {
                    _btnCreate.Click -= btnCreate_Click;
                }

                _btnCreate = value;
                if (_btnCreate != null)
                {
                    _btnCreate.Click += btnCreate_Click;
                }
            }
        }

        private GroupBox _grpSite;

        internal GroupBox grpSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSite != null)
                {
                }

                _grpSite = value;
                if (_grpSite != null)
                {
                }
            }
        }

        private Button _btnFindSite;

        internal Button btnFindSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindSite != null)
                {

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _btnFindSite.Click -= btnFindSite_Click;
                }

                _btnFindSite = value;
                if (_btnFindSite != null)
                {
                    _btnFindSite.Click += btnFindSite_Click;
                }
            }
        }

        private TextBox _txtSite;

        internal TextBox txtSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSite != null)
                {
                }

                _txtSite = value;
                if (_txtSite != null)
                {
                }
            }
        }

        private GroupBox _grpJob;

        internal GroupBox grpJob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpJob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpJob != null)
                {
                }

                _grpJob = value;
                if (_grpJob != null)
                {
                }
            }
        }

        private Label _lblNotes;

        internal Label lblNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblNotes != null)
                {
                }

                _lblNotes = value;
                if (_lblNotes != null)
                {
                }
            }
        }

        private DataGrid _dgJobs;

        internal DataGrid dgJobs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgJobs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgJobs != null)
                {
                    _dgJobs.Click -= dgJobs_Click;
                }

                _dgJobs = value;
                if (_dgJobs != null)
                {
                    _dgJobs.Click += dgJobs_Click;
                }
            }
        }

        private TextBox _txtNotesToEngineer;

        internal TextBox txtNotesToEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNotesToEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNotesToEngineer != null)
                {
                }

                _txtNotesToEngineer = value;
                if (_txtNotesToEngineer != null)
                {
                }
            }
        }

        private CheckBox _cbNewJob;

        internal CheckBox cbNewJob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbNewJob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbNewJob != null)
                {
                    _cbNewJob.Click -= cbNewJob_Click;
                }

                _cbNewJob = value;
                if (_cbNewJob != null)
                {
                    _cbNewJob.Click += cbNewJob_Click;
                }
            }
        }

        private RadioButton _rbtnFoc;

        internal RadioButton rbtnFoc
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rbtnFoc;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rbtnFoc != null)
                {
                }

                _rbtnFoc = value;
                if (_rbtnFoc != null)
                {
                }
            }
        }

        private GroupBox _grpPaymentType;

        internal GroupBox grpPaymentType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpPaymentType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpPaymentType != null)
                {
                }

                _grpPaymentType = value;
                if (_grpPaymentType != null)
                {
                }
            }
        }

        private ComboBox _cboJobType;

        internal ComboBox cboJobType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboJobType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboJobType != null)
                {
                }

                _cboJobType = value;
                if (_cboJobType != null)
                {
                }
            }
        }

        private RadioButton _rbtnOti;

        internal RadioButton rbtnOti
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rbtnOti;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rbtnOti != null)
                {
                }

                _rbtnOti = value;
                if (_rbtnOti != null)
                {
                }
            }
        }

        private RadioButton _rbtnPoc;

        internal RadioButton rbtnPoc
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rbtnPoc;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rbtnPoc != null)
                {
                }

                _rbtnPoc = value;
                if (_rbtnPoc != null)
                {
                }
            }
        }

        private GroupBox _grpSaleRep;

        internal GroupBox grpSaleRep
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSaleRep;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSaleRep != null)
                {
                }

                _grpSaleRep = value;
                if (_grpSaleRep != null)
                {
                }
            }
        }

        private GroupBox _grpJobType;

        internal GroupBox grpJobType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpJobType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpJobType != null)
                {
                }

                _grpJobType = value;
                if (_grpJobType != null)
                {
                }
            }
        }

        private Button _btnFindSalesRep;

        internal Button btnFindSalesRep
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindSalesRep;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindSalesRep != null)
                {
                    _btnFindSalesRep.Click -= btnFindSalesRep_Click;
                }

                _btnFindSalesRep = value;
                if (_btnFindSalesRep != null)
                {
                    _btnFindSalesRep.Click += btnFindSalesRep_Click;
                }
            }
        }

        private TextBox _txtSalesRep;

        internal TextBox txtSalesRep
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSalesRep;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSalesRep != null)
                {
                }

                _txtSalesRep = value;
                if (_txtSalesRep != null)
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
                    _txtEndTimeMinutes.TextChanged -= txtTime_TextChanged;
                }

                _txtEndTimeMinutes = value;
                if (_txtEndTimeMinutes != null)
                {
                    _txtEndTimeMinutes.TextChanged += txtTime_TextChanged;
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
                    _txtEndTimeHours.TextChanged -= txtTime_TextChanged;
                }

                _txtEndTimeHours = value;
                if (_txtEndTimeHours != null)
                {
                    _txtEndTimeHours.TextChanged += txtTime_TextChanged;
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
                }

                _txtStartTimeMinutes = value;
                if (_txtStartTimeMinutes != null)
                {
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
                    _txtStartTimeHours.TextChanged -= txtTime_TextChanged;
                }

                _txtStartTimeHours = value;
                if (_txtStartTimeHours != null)
                {
                    _txtStartTimeHours.TextChanged += txtTime_TextChanged;
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

        private Label _lblEndTime;

        internal Label lblEndTime
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEndTime;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEndTime != null)
                {
                }

                _lblEndTime = value;
                if (_lblEndTime != null)
                {
                }
            }
        }

        private Label _lblStartTime;

        internal Label lblStartTime
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblStartTime;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblStartTime != null)
                {
                }

                _lblStartTime = value;
                if (_lblStartTime != null)
                {
                }
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpEngineer = new GroupBox();
            _btnfindEngineer = new Button();
            _btnfindEngineer.Click += new EventHandler(btnfindEngineer_Click);
            _txtEngineer = new TextBox();
            _grpVisit = new GroupBox();
            _txtEndTimeMinutes = new TextBox();
            _txtEndTimeMinutes.TextChanged += new EventHandler(txtTime_TextChanged);
            _txtEndTimeHours = new TextBox();
            _txtEndTimeHours.TextChanged += new EventHandler(txtTime_TextChanged);
            _txtStartTimeMinutes = new TextBox();
            _txtStartTimeHours = new TextBox();
            _txtStartTimeHours.TextChanged += new EventHandler(txtTime_TextChanged);
            _Label4 = new Label();
            _Label3 = new Label();
            _lblEndTime = new Label();
            _lblStartTime = new Label();
            _txtNotesToEngineer = new TextBox();
            _lblNotes = new Label();
            _cboAppointment = new ComboBox();
            _lblAppointment = new Label();
            _dtpVisitDate = new DateTimePicker();
            _lblVisitDate = new Label();
            _btnCreate = new Button();
            _btnCreate.Click += new EventHandler(btnCreate_Click);
            _grpSite = new GroupBox();
            _btnFindSite = new Button();
            _btnFindSite.Click += new EventHandler(btnFindSite_Click);
            _txtSite = new TextBox();
            _grpJob = new GroupBox();
            _grpSaleRep = new GroupBox();
            _btnFindSalesRep = new Button();
            _btnFindSalesRep.Click += new EventHandler(btnFindSalesRep_Click);
            _txtSalesRep = new TextBox();
            _grpJobType = new GroupBox();
            _cboJobType = new ComboBox();
            _grpPaymentType = new GroupBox();
            _rbtnOti = new RadioButton();
            _rbtnPoc = new RadioButton();
            _rbtnFoc = new RadioButton();
            _cbNewJob = new CheckBox();
            _cbNewJob.Click += new EventHandler(cbNewJob_Click);
            _dgJobs = new DataGrid();
            _dgJobs.Click += new EventHandler(dgJobs_Click);
            _grpEngineer.SuspendLayout();
            _grpVisit.SuspendLayout();
            _grpSite.SuspendLayout();
            _grpJob.SuspendLayout();
            _grpSaleRep.SuspendLayout();
            _grpJobType.SuspendLayout();
            _grpPaymentType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgJobs).BeginInit();
            SuspendLayout();
            // 
            // grpEngineer
            // 
            _grpEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpEngineer.Controls.Add(_btnfindEngineer);
            _grpEngineer.Controls.Add(_txtEngineer);
            _grpEngineer.Location = new Point(12, 428);
            _grpEngineer.Name = "grpEngineer";
            _grpEngineer.Size = new Size(658, 57);
            _grpEngineer.TabIndex = 46;
            _grpEngineer.TabStop = false;
            _grpEngineer.Text = "Engineer";
            // 
            // btnfindEngineer
            // 
            _btnfindEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnfindEngineer.BackColor = Color.White;
            _btnfindEngineer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnfindEngineer.Location = new Point(620, 18);
            _btnfindEngineer.Name = "btnfindEngineer";
            _btnfindEngineer.Size = new Size(32, 23);
            _btnfindEngineer.TabIndex = 18;
            _btnfindEngineer.Text = "...";
            _btnfindEngineer.UseVisualStyleBackColor = false;
            // 
            // txtEngineer
            // 
            _txtEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtEngineer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtEngineer.Location = new Point(7, 19);
            _txtEngineer.Name = "txtEngineer";
            _txtEngineer.ReadOnly = true;
            _txtEngineer.Size = new Size(607, 21);
            _txtEngineer.TabIndex = 17;
            // 
            // grpVisit
            // 
            _grpVisit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpVisit.Controls.Add(_txtEndTimeMinutes);
            _grpVisit.Controls.Add(_txtEndTimeHours);
            _grpVisit.Controls.Add(_txtStartTimeMinutes);
            _grpVisit.Controls.Add(_txtStartTimeHours);
            _grpVisit.Controls.Add(_Label4);
            _grpVisit.Controls.Add(_Label3);
            _grpVisit.Controls.Add(_lblEndTime);
            _grpVisit.Controls.Add(_lblStartTime);
            _grpVisit.Controls.Add(_txtNotesToEngineer);
            _grpVisit.Controls.Add(_lblNotes);
            _grpVisit.Controls.Add(_cboAppointment);
            _grpVisit.Controls.Add(_lblAppointment);
            _grpVisit.Controls.Add(_dtpVisitDate);
            _grpVisit.Controls.Add(_lblVisitDate);
            _grpVisit.Location = new Point(12, 293);
            _grpVisit.Name = "grpVisit";
            _grpVisit.Size = new Size(658, 129);
            _grpVisit.TabIndex = 47;
            _grpVisit.TabStop = false;
            _grpVisit.Text = "Visit";
            // 
            // txtEndTimeMinutes
            // 
            _txtEndTimeMinutes.Location = new Point(304, 58);
            _txtEndTimeMinutes.Name = "txtEndTimeMinutes";
            _txtEndTimeMinutes.Size = new Size(24, 20);
            _txtEndTimeMinutes.TabIndex = 70;
            // 
            // txtEndTimeHours
            // 
            _txtEndTimeHours.Location = new Point(273, 58);
            _txtEndTimeHours.Name = "txtEndTimeHours";
            _txtEndTimeHours.Size = new Size(24, 20);
            _txtEndTimeHours.TabIndex = 71;
            // 
            // txtStartTimeMinutes
            // 
            _txtStartTimeMinutes.Location = new Point(124, 58);
            _txtStartTimeMinutes.Name = "txtStartTimeMinutes";
            _txtStartTimeMinutes.Size = new Size(24, 20);
            _txtStartTimeMinutes.TabIndex = 69;
            // 
            // txtStartTimeHours
            // 
            _txtStartTimeHours.Location = new Point(93, 58);
            _txtStartTimeHours.Name = "txtStartTimeHours";
            _txtStartTimeHours.Size = new Size(24, 20);
            _txtStartTimeHours.TabIndex = 67;
            // 
            // Label4
            // 
            _Label4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label4.Location = new Point(296, 60);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(8, 17);
            _Label4.TabIndex = 72;
            _Label4.Text = ":";
            // 
            // Label3
            // 
            _Label3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label3.Location = new Point(115, 60);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(8, 17);
            _Label3.TabIndex = 73;
            _Label3.Text = ":";
            // 
            // lblEndTime
            // 
            _lblEndTime.Location = new Point(203, 61);
            _lblEndTime.Name = "lblEndTime";
            _lblEndTime.Size = new Size(55, 17);
            _lblEndTime.TabIndex = 68;
            _lblEndTime.Text = "End Time";
            // 
            // lblStartTime
            // 
            _lblStartTime.Location = new Point(10, 61);
            _lblStartTime.Name = "lblStartTime";
            _lblStartTime.Size = new Size(60, 17);
            _lblStartTime.TabIndex = 66;
            _lblStartTime.Text = "Start Time";
            // 
            // txtNotesToEngineer
            // 
            _txtNotesToEngineer.AcceptsReturn = true;
            _txtNotesToEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtNotesToEngineer.Location = new Point(403, 19);
            _txtNotesToEngineer.Multiline = true;
            _txtNotesToEngineer.Name = "txtNotesToEngineer";
            _txtNotesToEngineer.ScrollBars = ScrollBars.Vertical;
            _txtNotesToEngineer.Size = new Size(247, 95);
            _txtNotesToEngineer.TabIndex = 65;
            // 
            // lblNotes
            // 
            _lblNotes.Location = new Point(351, 24);
            _lblNotes.Name = "lblNotes";
            _lblNotes.Size = new Size(59, 15);
            _lblNotes.TabIndex = 64;
            _lblNotes.Text = "Notes";
            // 
            // cboAppointment
            // 
            _cboAppointment.FormattingEnabled = true;
            _cboAppointment.Location = new Point(92, 93);
            _cboAppointment.Name = "cboAppointment";
            _cboAppointment.Size = new Size(236, 21);
            _cboAppointment.TabIndex = 61;
            // 
            // lblAppointment
            // 
            _lblAppointment.Location = new Point(10, 97);
            _lblAppointment.Name = "lblAppointment";
            _lblAppointment.Size = new Size(76, 17);
            _lblAppointment.TabIndex = 60;
            _lblAppointment.Text = "Appointment:";
            // 
            // dtpVisitDate
            // 
            _dtpVisitDate.Location = new Point(93, 21);
            _dtpVisitDate.Name = "dtpVisitDate";
            _dtpVisitDate.Size = new Size(235, 20);
            _dtpVisitDate.TabIndex = 32;
            // 
            // lblVisitDate
            // 
            _lblVisitDate.Location = new Point(8, 24);
            _lblVisitDate.Name = "lblVisitDate";
            _lblVisitDate.Size = new Size(59, 15);
            _lblVisitDate.TabIndex = 31;
            _lblVisitDate.Text = "Visit Date";
            // 
            // btnCreate
            // 
            _btnCreate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnCreate.Location = new Point(595, 494);
            _btnCreate.Name = "btnCreate";
            _btnCreate.Size = new Size(77, 23);
            _btnCreate.TabIndex = 48;
            _btnCreate.Text = "Create";
            _btnCreate.UseVisualStyleBackColor = true;
            // 
            // grpSite
            // 
            _grpSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpSite.Controls.Add(_btnFindSite);
            _grpSite.Controls.Add(_txtSite);
            _grpSite.Location = new Point(12, 12);
            _grpSite.Name = "grpSite";
            _grpSite.Size = new Size(658, 55);
            _grpSite.TabIndex = 49;
            _grpSite.TabStop = false;
            _grpSite.Text = "Site";
            // 
            // btnFindSite
            // 
            _btnFindSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindSite.BackColor = Color.White;
            _btnFindSite.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindSite.Location = new Point(620, 16);
            _btnFindSite.Name = "btnFindSite";
            _btnFindSite.Size = new Size(32, 23);
            _btnFindSite.TabIndex = 18;
            _btnFindSite.Text = "...";
            _btnFindSite.UseVisualStyleBackColor = false;
            // 
            // txtSite
            // 
            _txtSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSite.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtSite.Location = new Point(6, 17);
            _txtSite.Name = "txtSite";
            _txtSite.ReadOnly = true;
            _txtSite.Size = new Size(605, 21);
            _txtSite.TabIndex = 17;
            // 
            // grpJob
            // 
            _grpJob.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpJob.Controls.Add(_grpSaleRep);
            _grpJob.Controls.Add(_grpJobType);
            _grpJob.Controls.Add(_grpPaymentType);
            _grpJob.Controls.Add(_cbNewJob);
            _grpJob.Controls.Add(_dgJobs);
            _grpJob.Location = new Point(12, 73);
            _grpJob.Name = "grpJob";
            _grpJob.Size = new Size(658, 214);
            _grpJob.TabIndex = 64;
            _grpJob.TabStop = false;
            _grpJob.Text = "Job";
            // 
            // grpSaleRep
            // 
            _grpSaleRep.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpSaleRep.Controls.Add(_btnFindSalesRep);
            _grpSaleRep.Controls.Add(_txtSalesRep);
            _grpSaleRep.Location = new Point(375, 164);
            _grpSaleRep.Name = "grpSaleRep";
            _grpSaleRep.Size = new Size(274, 44);
            _grpSaleRep.TabIndex = 72;
            _grpSaleRep.TabStop = false;
            _grpSaleRep.Text = "Sales Rep";
            // 
            // btnFindSalesRep
            // 
            _btnFindSalesRep.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindSalesRep.BackColor = Color.White;
            _btnFindSalesRep.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindSalesRep.Location = new Point(236, 16);
            _btnFindSalesRep.Name = "btnFindSalesRep";
            _btnFindSalesRep.Size = new Size(32, 23);
            _btnFindSalesRep.TabIndex = 66;
            _btnFindSalesRep.Text = "...";
            _btnFindSalesRep.UseVisualStyleBackColor = false;
            // 
            // txtSalesRep
            // 
            _txtSalesRep.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSalesRep.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtSalesRep.Location = new Point(6, 17);
            _txtSalesRep.Name = "txtSalesRep";
            _txtSalesRep.ReadOnly = true;
            _txtSalesRep.Size = new Size(224, 21);
            _txtSalesRep.TabIndex = 65;
            // 
            // grpJobType
            // 
            _grpJobType.Controls.Add(_cboJobType);
            _grpJobType.Location = new Point(176, 164);
            _grpJobType.Name = "grpJobType";
            _grpJobType.Size = new Size(193, 44);
            _grpJobType.TabIndex = 71;
            _grpJobType.TabStop = false;
            _grpJobType.Text = "Job Type";
            // 
            // cboJobType
            // 
            _cboJobType.Location = new Point(6, 17);
            _cboJobType.Name = "cboJobType";
            _cboJobType.Size = new Size(181, 21);
            _cboJobType.TabIndex = 65;
            // 
            // grpPaymentType
            // 
            _grpPaymentType.Controls.Add(_rbtnOti);
            _grpPaymentType.Controls.Add(_rbtnPoc);
            _grpPaymentType.Controls.Add(_rbtnFoc);
            _grpPaymentType.Location = new Point(6, 164);
            _grpPaymentType.Name = "grpPaymentType";
            _grpPaymentType.Size = new Size(164, 44);
            _grpPaymentType.TabIndex = 67;
            _grpPaymentType.TabStop = false;
            _grpPaymentType.Text = "Payment Type";
            // 
            // rbtnOti
            // 
            _rbtnOti.AutoSize = true;
            _rbtnOti.Location = new Point(113, 19);
            _rbtnOti.Name = "rbtnOti";
            _rbtnOti.Size = new Size(43, 17);
            _rbtnOti.TabIndex = 70;
            _rbtnOti.TabStop = true;
            _rbtnOti.Text = "OTI";
            _rbtnOti.UseVisualStyleBackColor = true;
            // 
            // rbtnPoc
            // 
            _rbtnPoc.AutoSize = true;
            _rbtnPoc.Location = new Point(59, 19);
            _rbtnPoc.Name = "rbtnPoc";
            _rbtnPoc.Size = new Size(47, 17);
            _rbtnPoc.TabIndex = 69;
            _rbtnPoc.TabStop = true;
            _rbtnPoc.Text = "POC";
            _rbtnPoc.UseVisualStyleBackColor = true;
            // 
            // rbtnFoc
            // 
            _rbtnFoc.AutoSize = true;
            _rbtnFoc.Location = new Point(7, 19);
            _rbtnFoc.Name = "rbtnFoc";
            _rbtnFoc.Size = new Size(46, 17);
            _rbtnFoc.TabIndex = 68;
            _rbtnFoc.TabStop = true;
            _rbtnFoc.Text = "FOC";
            _rbtnFoc.UseVisualStyleBackColor = true;
            // 
            // cbNewJob
            // 
            _cbNewJob.AutoCheck = false;
            _cbNewJob.AutoSize = true;
            _cbNewJob.Checked = true;
            _cbNewJob.CheckState = CheckState.Checked;
            _cbNewJob.Location = new Point(7, 19);
            _cbNewJob.Name = "cbNewJob";
            _cbNewJob.Size = new Size(68, 17);
            _cbNewJob.TabIndex = 14;
            _cbNewJob.Text = "New Job";
            _cbNewJob.UseVisualStyleBackColor = true;
            // 
            // dgJobs
            // 
            _dgJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgJobs.DataMember = "";
            _dgJobs.Enabled = false;
            _dgJobs.HeaderForeColor = SystemColors.ControlText;
            _dgJobs.Location = new Point(6, 42);
            _dgJobs.Name = "dgJobs";
            _dgJobs.Size = new Size(641, 116);
            _dgJobs.TabIndex = 13;
            // 
            // FRMNewJob
            // 
            AutoScaleBaseSize = new Size(5, 13);
            BackColor = Color.White;
            ClientSize = new Size(684, 529);
            Controls.Add(_grpJob);
            Controls.Add(_grpSite);
            Controls.Add(_btnCreate);
            Controls.Add(_grpVisit);
            Controls.Add(_grpEngineer);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MaximumSize = new Size(1000, 1000);
            MinimizeBox = false;
            Name = "FRMNewJob";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New Job";
            _grpEngineer.ResumeLayout(false);
            _grpEngineer.PerformLayout();
            _grpVisit.ResumeLayout(false);
            _grpVisit.PerformLayout();
            _grpSite.ResumeLayout(false);
            _grpSite.PerformLayout();
            _grpJob.ResumeLayout(false);
            _grpJob.PerformLayout();
            _grpSaleRep.ResumeLayout(false);
            _grpSaleRep.PerformLayout();
            _grpJobType.ResumeLayout(false);
            _grpPaymentType.ResumeLayout(false);
            _grpPaymentType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgJobs).EndInit();
            ResumeLayout(false);
        }

        private Site _site;

        private Site Site
        {
            get
            {
                return _site;
            }

            set
            {
                _site = value;
                if (_site is object)
                {
                    string siteInfo = string.Empty;
                    if (!string.IsNullOrEmpty(_site.Name))
                        siteInfo += _site.Name + ", ";
                    if (!string.IsNullOrEmpty(_site.Address1))
                        siteInfo += _site.Address1 + ", ";
                    if (!string.IsNullOrEmpty(_site.Address2))
                        siteInfo += _site.Address2 + ", ";
                    if (!string.IsNullOrEmpty(_site.Postcode))
                        siteInfo += _site.Postcode;
                    txtSite.Text = siteInfo;
                    if (!string.IsNullOrEmpty(_site.ContactAlerts))
                        txtNotesToEngineer.Text = _site.ContactAlerts + " - ";
                }
                else
                {
                    txtSite.Text = "<Not set>";
                    txtNotesToEngineer.Text = "";
                }
            }
        }

        private DataView _dvJobs;

        private DataView DvJobs
        {
            get
            {
                return _dvJobs;
            }

            set
            {
                _dvJobs = value;
                _dvJobs.Table.TableName = Enums.TableNames.NO_TABLE.ToString();
                dgJobs.DataSource = DvJobs;
            }
        }

        private DataRow DrSelectedJob
        {
            get
            {
                if (!(dgJobs.CurrentRowIndex == -1))
                {
                    return DvJobs[dgJobs.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private Engineer _engineer;

        public Engineer Engineer
        {
            get
            {
                return _engineer;
            }

            set
            {
                _engineer = value;
                if (_engineer is object)
                {
                    txtEngineer.Text = Engineer.Name;
                }
                else
                {
                    txtEngineer.Text = "<Not Set>";
                }
            }
        }

        private User _salesRep;

        private User SalesRep
        {
            get
            {
                return _salesRep;
            }

            set
            {
                _salesRep = value;
                if (_salesRep is object)
                {
                    txtSalesRep.Text = SalesRep.Fullname;
                }
                else
                {
                    txtSalesRep.Text = "<Not Set>";
                }
            }
        }

        private Job Job { get; set; }
        private EngineerVisit EngineerVisit { get; set; }
        private DateTime VisitStartDate { get; set; }
        private DateTime VisitEndDate { get; set; }

        private void btnFindSite_Click(object sender, EventArgs e)
        {
            FindSite();
        }

        private void cbNewJob_Click(object sender, EventArgs e)
        {
            cbNewJob.Checked = !cbNewJob.Checked;
            CbNewJobClicked();
        }

        private void dgJobs_Click(object sender, EventArgs e)
        {
            DgJobsClicked();
        }

        private void btnfindEngineer_Click(object sender, EventArgs e)
        {
            FindEngineer();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateJob();
        }

        private void txtTime_TextChanged(object sender, EventArgs e)
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
        }

        private void btnFindSalesRep_Click(object sender, EventArgs e)
        {
            FindUser();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void FindSite()
        {
            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite));
            if (!(ID == 0))
            {
                Site = App.DB.Sites.Get(ID);
                if (Site.OnStop)
                {
                    App.ShowMessage("This site is ON STOP!" + Constants.vbCrLf + Constants.vbCrLf + "Cannot create new job!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Site = null;
                    return;
                }

                int customerStatus = (int)App.DB.Customer.Customer_Get(Site.CustomerID)?.Status;
                if (customerStatus == Conversions.ToInteger(Enums.CustomerStatus.OnHold))
                {
                    App.ShowMessage("The customer is ON HOLD!" + Constants.vbCrLf + Constants.vbCrLf + "Cannot create new job!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Site = null;
                    return;
                }

                cbNewJob.Checked = true;
                CbNewJobClicked();
            }
        }

        private void FindJobs()
        {
            if (Site is null)
                return;
            var dtJobs = new DataTable();
            dtJobs = App.DB.Job.Job_GetTop100_For_Site(Site.SiteID, Site.CustomerID)?.Table;
            if (dtJobs.Rows?.Count > 0 == true)
            {
                dtJobs = dtJobs.AsEnumerable().Take(10)?.CopyToDataTable();
            }

            DvJobs = new DataView(dtJobs);
            ResetJob();
        }

        private void CbNewJobClicked()
        {
            if (!cbNewJob.Checked)
            {
                SetupDgJobs();
                FindJobs();
                grpPaymentType.Enabled = false;
                grpJobType.Enabled = false;
                grpSaleRep.Enabled = false;
            }
            else
            {
                DvJobs = new DataView(new DataTable());
                ClearDgJobs();
                grpPaymentType.Enabled = true;
                grpJobType.Enabled = true;
                grpSaleRep.Enabled = true;
                ResetJob();
            }
        }

        private void FindUser()
        {
            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblUser));
            if (!(ID == 0))
            {
                SalesRep = App.DB.User.Get(ID);
            }
        }

        private void FindEngineer()
        {
            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblEngineer));
            if (!(ID == 0))
            {
                Engineer = App.DB.Engineer.Engineer_Get(ID);
            }
        }

        private void DgJobsClicked()
        {
            if (DrSelectedJob is null)
                return;
            Job = App.DB.Job.Job_Get(Helper.MakeIntegerValid(DrSelectedJob["JobID"]));
            rbtnFoc.Checked = Job?.FOC == true;
            rbtnPoc.Checked = Job?.POC == true;
            rbtnOti.Checked = Job?.OTI == true;
            var argcombo = cboJobType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(Job?.JobTypeID));
            SalesRep = App.DB.User.Get((int)Job?.SalesRepUserID);
        }

        private void ResetJob()
        {
            rbtnFoc.Checked = App.IsRFT ? true : false;
            rbtnPoc.Checked = false;
            rbtnOti.Checked = false;
            var argcombo = cboJobType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            SalesRep = null;
        }

        private bool IsFormValid()
        {
            if (Site is null)
            {
                App.ShowMessage("Please select a site!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!rbtnFoc.Checked & !rbtnPoc.Checked & !rbtnOti.Checked)
            {
                App.ShowMessage("Please select a payment type!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Conversions.ToBoolean(Helper.MakeIntegerValid(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboJobType)) == 0)))
            {
                App.ShowMessage("Please select a job type!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int startHour = Helper.MakeIntegerValid(txtStartTimeHours.Text);
            int startMin = Helper.MakeIntegerValid(txtStartTimeMinutes.Text);
            int endHour = Helper.MakeIntegerValid(txtEndTimeHours.Text);
            int endMin = Helper.MakeIntegerValid(txtEndTimeMinutes.Text);
            if (!IsHourAndMinValid(startHour, startMin))
            {
                App.ShowMessage("Invalid start time!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!IsHourAndMinValid(endHour, endMin))
            {
                App.ShowMessage("Invalid end time!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            VisitStartDate = new DateTime(dtpVisitDate.Value.Year, dtpVisitDate.Value.Month, dtpVisitDate.Value.Day, startHour, startMin, 0);
            VisitEndDate = new DateTime(dtpVisitDate.Value.Year, dtpVisitDate.Value.Month, dtpVisitDate.Value.Day, endHour, endMin, 0);
            if (VisitStartDate > VisitEndDate)
            {
                App.ShowMessage("Start time can not be greater than end time!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (VisitStartDate == VisitEndDate)
            {
                App.ShowMessage("Start time can not be equal to end time!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtNotesToEngineer.Text.Trim().Length == 0)
            {
                App.ShowMessage("Please enter notes for the visit!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Engineer is null)
            {
                App.ShowMessage("Please select an engineer!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!IsEngineerQualified(Engineer.EngineerID))
            {
                App.ShowMessage("Engineer is not qualified!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool IsEngineerQualified(int engineerId)
        {
            var skills = App.DB.EngineerLevel.Get(Engineer.EngineerID)?.Table;
            var mandatorySkills = skills?.Select("Tick = 1 AND Mandatory = 1").ToList();
            if (Job?.JobTypeID == (int?)Enums.JobTypes.QualityControl == true)
            {
                var levelAuditor = skills.Select("ManagerID =" + Conversions.ToInteger(Enums.EngineerQual.AUDITOR) + " AND Tick = 1").FirstOrDefault();
                if (levelAuditor is null)
                {
                    return false;
                }
            }

            foreach (DataRow mandatorySkill in mandatorySkills)
            {
                DateTime expDate = Conversions.ToDate(Interaction.IIf(Information.IsDBNull(mandatorySkill["DateExpires"]), DateAndTime.Now.AddMinutes(1), Conversions.ToDate(mandatorySkill["DateExpires"])));
                if (expDate < Conversions.ToDate(DateAndTime.Today))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsHourAndMinValid(int hour, int min)
        {
            return hour >= 0 && hour <= 23 && min >= 0 && min <= 59;
        }

        private void CreateJob()
        {
            try
            {
                if (!IsFormValid())
                    return;
                string msg = Job?.JobID > 0 == true ? "Generate new visit?" : "Create new job?";
                string successMsg = Job?.JobID > 0 == true ? "New visit generated!" : " New job created!";
                if (App.ShowMessage(msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var ev = new EngineerVisit()
                    {
                        IgnoreExceptionsOnSetMethods = true,
                        StartDateTime = VisitStartDate,
                        EndDateTime = VisitEndDate,
                        SetEngineerID = Engineer?.EngineerID,
                        SetStatusEnumID = Conversions.ToInteger(Enums.VisitStatus.Scheduled),
                        SetAppointmentID = Helper.MakeIntegerValid(Combo.get_GetSelectedItemValue(cboAppointment)),
                        SetNotesToEngineer = txtNotesToEngineer.Text.Trim()
                    };
                    if (Job?.JobID > 0 == true)
                    {
                        Job.JobOfWorks[Job.JobOfWorks.Count - 1]?.EngineerVisits.Add(ev);
                        Job = App.DB.Job.Update(Job);
                    }
                    else
                    {
                        Job = new Job();
                        {
                            var withBlock = Job;
                            withBlock.IgnoreExceptionsOnSetMethods = true;
                            withBlock.SetPropertyID = Site.SiteID;
                            withBlock.SetJobTypeID = Helper.MakeIntegerValid(Combo.get_GetSelectedItemValue(cboJobType));
                            withBlock.SetJobDefinitionEnumID = Conversions.ToInteger(Enums.JobDefinition.Callout);
                            withBlock.SetStatusEnumID = Conversions.ToInteger(Enums.JobStatus.Open);
                            withBlock.SetCreatedByUserID = App.loggedInUser.UserID;
                            withBlock.SetFOC = rbtnFoc.Checked;
                            withBlock.SetPOC = rbtnPoc.Checked;
                            withBlock.SetOTI = rbtnOti.Checked;
                            withBlock.SetJobCreationType = Conversions.ToInteger(Enums.JobCreationType.Manual);
                            var JobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Callout);
                            withBlock.SetJobNumber = JobNumber?.Prefix + JobNumber?.Number;
                            withBlock.SetSalesRepUserID = SalesRep?.UserID;
                            withBlock.SetPONumber = "";
                        }

                        var jow = new JobOfWork() { SetPONumber = "", PriorityDateSet = DateAndTime.Now };
                        jow.EngineerVisits.Add(ev);
                        Job.JobOfWorks.Add(jow);
                        Job = App.DB.Job.Insert(Job);
                    }

                    if (App.ShowMessage(successMsg + Constants.vbCrLf + Constants.vbCrLf + "Do you want to open the job?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        App.ShowForm(typeof(FRMLogCallout), true, new object[] { Job.JobID, Job.PropertyID });
                    }

                    if (Modal)
                    {
                        Close();
                    }
                    else
                    {
                        Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage(ex.Message + " - " + ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void SetupDgJobs()
        {
            dgJobs.Enabled = true;
            Helper.SetUpDataGrid(dgJobs);
            var dgts = dgJobs.TableStyles[0];
            var dateCreated = new DataGridLabelColumn();
            dateCreated.Format = "dd/MM/yyyy";
            dateCreated.FormatInfo = null;
            dateCreated.HeaderText = "Created";
            dateCreated.MappingName = "DateCreated";
            dateCreated.ReadOnly = true;
            dateCreated.Width = 100;
            dateCreated.NullText = "";
            dgts.GridColumnStyles.Add(dateCreated);
            var jobNumber = new DataGridLabelColumn();
            jobNumber.Format = "";
            jobNumber.FormatInfo = null;
            jobNumber.HeaderText = "Job No";
            jobNumber.MappingName = "JobNumber";
            jobNumber.ReadOnly = true;
            jobNumber.Width = 120;
            jobNumber.NullText = "";
            dgts.GridColumnStyles.Add(jobNumber);
            var type = new DataGridLabelColumn();
            type.Format = "";
            type.FormatInfo = null;
            type.HeaderText = "Type";
            type.MappingName = "Type";
            type.ReadOnly = true;
            type.Width = 250;
            type.NullText = Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
            dgts.GridColumnStyles.Add(type);
            var lastVisitDate = new DataGridLabelColumn();
            lastVisitDate.Format = "dd/MM/yyyy";
            lastVisitDate.FormatInfo = null;
            lastVisitDate.HeaderText = "Last Visit's Date";
            lastVisitDate.MappingName = "LastVisitDate";
            lastVisitDate.ReadOnly = true;
            lastVisitDate.Width = 120;
            lastVisitDate.NullText = "";
            dgts.GridColumnStyles.Add(lastVisitDate);
            dgts.ReadOnly = true;
            dgts.MappingName = Enums.TableNames.NO_TABLE.ToString();
            dgJobs.TableStyles.Add(dgts);
        }

        private void ClearDgJobs()
        {
            Helper.SetUpDataGrid(dgJobs);
            var dgts = dgJobs.TableStyles[0];
            dgts.ReadOnly = true;
            dgts.MappingName = Enums.TableNames.NO_TABLE.ToString();
            dgJobs.TableStyles.Add(dgts);
            dgJobs.Enabled = false;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}