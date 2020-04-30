using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FSM.Entity.Engineers;
using FSM.Entity.EngineerVisits;
using FSM.Entity.Jobs;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FRMRescheduleVisit : Form
    {
        public FRMRescheduleVisit()
        {
            
            
            base.Load += FRMSchedulerFind_Load;
        }

        

        public FRMRescheduleVisit(int engineerVisitId) : base()
        {
            base.Load += FRMSchedulerFind_Load;
            InitializeComponent();
            var argc = cboAppointment;
            Combo.SetUpCombo(ref argc, App.DB.Appointments.GetAll().Table, "AppointmentID", "Name", Enums.ComboValues.Please_Select);
            EngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(engineerVisitId);
            Job = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(engineerVisitId);
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

        private Label _lblEngineer;

        internal Label lblEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEngineer != null)
                {
                }

                _lblEngineer = value;
                if (_lblEngineer != null)
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

        private Button _btnUpdate;

        internal Button btnUpdate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnUpdate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnUpdate != null)
                {
                    _btnUpdate.Click -= btnUpdate_Click;
                }

                _btnUpdate = value;
                if (_btnUpdate != null)
                {
                    _btnUpdate.Click += btnUpdate_Click;
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
            _lblEngineer = new Label();
            _grpVisit = new GroupBox();
            _cboAppointment = new ComboBox();
            _lblAppointment = new Label();
            _dtpVisitDate = new DateTimePicker();
            _lblVisitDate = new Label();
            _btnUpdate = new Button();
            _btnUpdate.Click += new EventHandler(btnUpdate_Click);
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
            _grpEngineer.SuspendLayout();
            _grpVisit.SuspendLayout();
            SuspendLayout();
            //
            // grpEngineer
            //
            _grpEngineer.Controls.Add(_btnfindEngineer);
            _grpEngineer.Controls.Add(_txtEngineer);
            _grpEngineer.Controls.Add(_lblEngineer);
            _grpEngineer.Location = new Point(14, 158);
            _grpEngineer.Name = "grpEngineer";
            _grpEngineer.Size = new Size(381, 66);
            _grpEngineer.TabIndex = 46;
            _grpEngineer.TabStop = false;
            _grpEngineer.Text = "Engineer";
            //
            // btnfindEngineer
            //
            _btnfindEngineer.BackColor = Color.White;
            _btnfindEngineer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnfindEngineer.Location = new Point(336, 18);
            _btnfindEngineer.Name = "btnfindEngineer";
            _btnfindEngineer.Size = new Size(32, 23);
            _btnfindEngineer.TabIndex = 18;
            _btnfindEngineer.Text = "...";
            _btnfindEngineer.UseVisualStyleBackColor = false;
            //
            // txtEngineer
            //
            _txtEngineer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtEngineer.Location = new Point(93, 19);
            _txtEngineer.Name = "txtEngineer";
            _txtEngineer.ReadOnly = true;
            _txtEngineer.Size = new Size(235, 21);
            _txtEngineer.TabIndex = 17;
            //
            // lblEngineer
            //
            _lblEngineer.Location = new Point(8, 23);
            _lblEngineer.Name = "lblEngineer";
            _lblEngineer.Size = new Size(85, 13);
            _lblEngineer.TabIndex = 31;
            _lblEngineer.Text = "Engineer";
            //
            // grpVisit
            //
            _grpVisit.Controls.Add(_txtEndTimeMinutes);
            _grpVisit.Controls.Add(_txtEndTimeHours);
            _grpVisit.Controls.Add(_txtStartTimeMinutes);
            _grpVisit.Controls.Add(_txtStartTimeHours);
            _grpVisit.Controls.Add(_Label4);
            _grpVisit.Controls.Add(_Label3);
            _grpVisit.Controls.Add(_lblEndTime);
            _grpVisit.Controls.Add(_lblStartTime);
            _grpVisit.Controls.Add(_cboAppointment);
            _grpVisit.Controls.Add(_lblAppointment);
            _grpVisit.Controls.Add(_dtpVisitDate);
            _grpVisit.Controls.Add(_lblVisitDate);
            _grpVisit.Location = new Point(14, 12);
            _grpVisit.Name = "grpVisit";
            _grpVisit.Size = new Size(381, 140);
            _grpVisit.TabIndex = 47;
            _grpVisit.TabStop = false;
            _grpVisit.Text = "Visit";
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
            _lblAppointment.Location = new Point(8, 96);
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
            // btnUpdate
            //
            _btnUpdate.Location = new Point(318, 233);
            _btnUpdate.Name = "btnUpdate";
            _btnUpdate.Size = new Size(75, 23);
            _btnUpdate.TabIndex = 48;
            _btnUpdate.Text = "Update";
            _btnUpdate.UseVisualStyleBackColor = true;
            //
            // txtEndTimeMinutes
            //
            _txtEndTimeMinutes.Location = new Point(304, 59);
            _txtEndTimeMinutes.Name = "txtEndTimeMinutes";
            _txtEndTimeMinutes.Size = new Size(24, 20);
            _txtEndTimeMinutes.TabIndex = 78;
            //
            // txtEndTimeHours
            //
            _txtEndTimeHours.Location = new Point(273, 59);
            _txtEndTimeHours.Name = "txtEndTimeHours";
            _txtEndTimeHours.Size = new Size(24, 20);
            _txtEndTimeHours.TabIndex = 79;
            //
            // txtStartTimeMinutes
            //
            _txtStartTimeMinutes.Location = new Point(123, 59);
            _txtStartTimeMinutes.Name = "txtStartTimeMinutes";
            _txtStartTimeMinutes.Size = new Size(24, 20);
            _txtStartTimeMinutes.TabIndex = 77;
            //
            // txtStartTimeHours
            //
            _txtStartTimeHours.Location = new Point(92, 59);
            _txtStartTimeHours.Name = "txtStartTimeHours";
            _txtStartTimeHours.Size = new Size(24, 20);
            _txtStartTimeHours.TabIndex = 75;
            //
            // Label4
            //
            _Label4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label4.Location = new Point(296, 61);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(8, 17);
            _Label4.TabIndex = 80;
            _Label4.Text = ":";
            //
            // Label3
            //
            _Label3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label3.Location = new Point(114, 61);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(8, 17);
            _Label3.TabIndex = 81;
            _Label3.Text = ":";
            //
            // lblEndTime
            //
            _lblEndTime.Location = new Point(203, 62);
            _lblEndTime.Name = "lblEndTime";
            _lblEndTime.Size = new Size(55, 17);
            _lblEndTime.TabIndex = 76;
            _lblEndTime.Text = "End Time";
            //
            // lblStartTime
            //
            _lblStartTime.Location = new Point(8, 62);
            _lblStartTime.Name = "lblStartTime";
            _lblStartTime.Size = new Size(60, 17);
            _lblStartTime.TabIndex = 74;
            _lblStartTime.Text = "Start Time";
            //
            // FRMRescheduleVisit
            //
            AutoScaleBaseSize = new Size(5, 13);
            BackColor = Color.White;
            ClientSize = new Size(406, 268);
            Controls.Add(_btnUpdate);
            Controls.Add(_grpVisit);
            Controls.Add(_grpEngineer);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MaximumSize = new Size(1000, 1000);
            MinimizeBox = false;
            Name = "FRMRescheduleVisit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reschedule Visit";
            _grpEngineer.ResumeLayout(false);
            _grpEngineer.PerformLayout();
            _grpVisit.ResumeLayout(false);
            _grpVisit.PerformLayout();
            ResumeLayout(false);
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

        private EngineerVisit _engineerVisit;

        private EngineerVisit EngineerVisit
        {
            get
            {
                return _engineerVisit;
            }

            set
            {
                _engineerVisit = value;
            }
        }

        private Job _job;

        private Job Job
        {
            get
            {
                return _job;
            }

            set
            {
                _job = value;
            }
        }

        private void FRMSchedulerFind_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void btnfindEngineer_Click(object sender, EventArgs e)
        {
            FindEngineer();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateVisit();
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

        
        

        private void Populate()
        {
            int appointmentId = EngineerVisit.AppointmentID == 0 ? Conversions.ToInteger(Enums.Appointments.Anytime) : EngineerVisit.AppointmentID;
            var argcombo = cboAppointment;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, appointmentId.ToString());
            dtpVisitDate.Value = EngineerVisit.StartDateTime;
            txtStartTimeHours.Text = EngineerVisit.StartDateTime.ToString("HH");
            txtStartTimeMinutes.Text = EngineerVisit.StartDateTime.ToString("mm");
            txtEndTimeHours.Text = EngineerVisit.EndDateTime.ToString("HH");
            txtEndTimeMinutes.Text = EngineerVisit.EndDateTime.ToString("mm");
            Engineer = App.DB.Engineer.Engineer_Get(EngineerVisit.EngineerID);
        }

        private void FindEngineer()
        {
            int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblEngineer));
            if (!(ID == 0))
            {
                Engineer = App.DB.Engineer.Engineer_Get(ID);
                if (!IsEngineerQualified(Engineer.EngineerID))
                {
                    App.ShowMessage("Engineer is not qualified!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Engineer = null;
                }
            }
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

        private void UpdateVisit()
        {
            if (App.ShowMessage("Reschedule visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Engineer?.EngineerID == 0 == true)
                {
                    App.ShowMessage("Please select an engineer?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int startHour = Helper.MakeIntegerValid(txtStartTimeHours.Text);
                int startMin = Helper.MakeIntegerValid(txtStartTimeMinutes.Text);
                int endHour = Helper.MakeIntegerValid(txtEndTimeHours.Text);
                int endMin = Helper.MakeIntegerValid(txtEndTimeMinutes.Text);
                if (!IsHourAndMinValid(startHour, startMin))
                {
                    App.ShowMessage("Invalid start time!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!IsHourAndMinValid(endHour, endMin))
                {
                    App.ShowMessage("Invalid end time!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var startDate = new DateTime(dtpVisitDate.Value.Year, dtpVisitDate.Value.Month, dtpVisitDate.Value.Day, startHour, startMin, 0);
                var endDate = new DateTime(dtpVisitDate.Value.Year, dtpVisitDate.Value.Month, dtpVisitDate.Value.Day, endHour, endMin, 0);
                if (startDate > endDate)
                {
                    App.ShowMessage("Start time can not be greater than end time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (startDate == endDate)
                {
                    App.ShowMessage("Start time can not be equal to end time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                EngineerVisit.StartDateTime = startDate;
                EngineerVisit.EndDateTime = endDate;
                EngineerVisit.SetAppointmentID = Helper.MakeIntegerValid(Combo.get_GetSelectedItemValue(cboAppointment));
                EngineerVisit.SetEngineerID = Engineer.EngineerID;
                App.DB.Scheduler.ScheduleVisit(EngineerVisit);
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

        private bool IsHourAndMinValid(int hour, int min)
        {
            return hour >= 0 && hour <= 23 && min >= 0 && min <= 59;
        }

        
    }
}