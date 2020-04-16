// Decompiled with JetBrains decompiler
// Type: FSM.FRMRescheduleVisit
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Engineers;
using FSM.Entity.EngineerVisits;
using FSM.Entity.Jobs;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMRescheduleVisit : Form
  {
    private IContainer components;
    private Engineer _engineer;
    private EngineerVisit _engineerVisit;
    private Job _job;

    public FRMRescheduleVisit(int engineerVisitId)
    {
      this.Load += new EventHandler(this.FRMSchedulerFind_Load);
      this.InitializeComponent();
      ComboBox cboAppointment = this.cboAppointment;
      Combo.SetUpCombo(ref cboAppointment, App.DB.Appointments.GetAll().Table, "AppointmentID", "Name", Enums.ComboValues.Please_Select);
      this.cboAppointment = cboAppointment;
      this.EngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(engineerVisitId, true);
      this.Job = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(engineerVisitId);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnfindEngineer
    {
      get
      {
        return this._btnfindEngineer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnfindEngineer_Click);
        Button btnfindEngineer1 = this._btnfindEngineer;
        if (btnfindEngineer1 != null)
          btnfindEngineer1.Click -= eventHandler;
        this._btnfindEngineer = value;
        Button btnfindEngineer2 = this._btnfindEngineer;
        if (btnfindEngineer2 == null)
          return;
        btnfindEngineer2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpVisit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblVisitDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboAppointment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAppointment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpVisitDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnUpdate
    {
      get
      {
        return this._btnUpdate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUpdate_Click);
        Button btnUpdate1 = this._btnUpdate;
        if (btnUpdate1 != null)
          btnUpdate1.Click -= eventHandler;
        this._btnUpdate = value;
        Button btnUpdate2 = this._btnUpdate;
        if (btnUpdate2 == null)
          return;
        btnUpdate2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtEndTimeMinutes
    {
      get
      {
        return this._txtEndTimeMinutes;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtTime_TextChanged);
        TextBox txtEndTimeMinutes1 = this._txtEndTimeMinutes;
        if (txtEndTimeMinutes1 != null)
          txtEndTimeMinutes1.TextChanged -= eventHandler;
        this._txtEndTimeMinutes = value;
        TextBox txtEndTimeMinutes2 = this._txtEndTimeMinutes;
        if (txtEndTimeMinutes2 == null)
          return;
        txtEndTimeMinutes2.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtEndTimeHours
    {
      get
      {
        return this._txtEndTimeHours;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtTime_TextChanged);
        TextBox txtEndTimeHours1 = this._txtEndTimeHours;
        if (txtEndTimeHours1 != null)
          txtEndTimeHours1.TextChanged -= eventHandler;
        this._txtEndTimeHours = value;
        TextBox txtEndTimeHours2 = this._txtEndTimeHours;
        if (txtEndTimeHours2 == null)
          return;
        txtEndTimeHours2.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtStartTimeMinutes
    {
      get
      {
        return this._txtStartTimeMinutes;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtTime_TextChanged);
        TextBox startTimeMinutes1 = this._txtStartTimeMinutes;
        if (startTimeMinutes1 != null)
          startTimeMinutes1.TextChanged -= eventHandler;
        this._txtStartTimeMinutes = value;
        TextBox startTimeMinutes2 = this._txtStartTimeMinutes;
        if (startTimeMinutes2 == null)
          return;
        startTimeMinutes2.TextChanged += eventHandler;
      }
    }

    internal virtual TextBox txtStartTimeHours
    {
      get
      {
        return this._txtStartTimeHours;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtTime_TextChanged);
        TextBox txtStartTimeHours1 = this._txtStartTimeHours;
        if (txtStartTimeHours1 != null)
          txtStartTimeHours1.TextChanged -= eventHandler;
        this._txtStartTimeHours = value;
        TextBox txtStartTimeHours2 = this._txtStartTimeHours;
        if (txtStartTimeHours2 == null)
          return;
        txtStartTimeHours2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEndTime { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblStartTime { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpEngineer = new GroupBox();
      this.btnfindEngineer = new Button();
      this.txtEngineer = new TextBox();
      this.lblEngineer = new Label();
      this.grpVisit = new GroupBox();
      this.cboAppointment = new ComboBox();
      this.lblAppointment = new Label();
      this.dtpVisitDate = new DateTimePicker();
      this.lblVisitDate = new Label();
      this.btnUpdate = new Button();
      this.txtEndTimeMinutes = new TextBox();
      this.txtEndTimeHours = new TextBox();
      this.txtStartTimeMinutes = new TextBox();
      this.txtStartTimeHours = new TextBox();
      this.Label4 = new Label();
      this.Label3 = new Label();
      this.lblEndTime = new Label();
      this.lblStartTime = new Label();
      this.grpEngineer.SuspendLayout();
      this.grpVisit.SuspendLayout();
      this.SuspendLayout();
      this.grpEngineer.Controls.Add((Control) this.btnfindEngineer);
      this.grpEngineer.Controls.Add((Control) this.txtEngineer);
      this.grpEngineer.Controls.Add((Control) this.lblEngineer);
      this.grpEngineer.Location = new System.Drawing.Point(14, 158);
      this.grpEngineer.Name = "grpEngineer";
      this.grpEngineer.Size = new Size(381, 66);
      this.grpEngineer.TabIndex = 46;
      this.grpEngineer.TabStop = false;
      this.grpEngineer.Text = "Engineer";
      this.btnfindEngineer.BackColor = Color.White;
      this.btnfindEngineer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnfindEngineer.Location = new System.Drawing.Point(336, 18);
      this.btnfindEngineer.Name = "btnfindEngineer";
      this.btnfindEngineer.Size = new Size(32, 23);
      this.btnfindEngineer.TabIndex = 18;
      this.btnfindEngineer.Text = "...";
      this.btnfindEngineer.UseVisualStyleBackColor = false;
      this.txtEngineer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtEngineer.Location = new System.Drawing.Point(93, 19);
      this.txtEngineer.Name = "txtEngineer";
      this.txtEngineer.ReadOnly = true;
      this.txtEngineer.Size = new Size(235, 21);
      this.txtEngineer.TabIndex = 17;
      this.lblEngineer.Location = new System.Drawing.Point(8, 23);
      this.lblEngineer.Name = "lblEngineer";
      this.lblEngineer.Size = new Size(85, 13);
      this.lblEngineer.TabIndex = 31;
      this.lblEngineer.Text = "Engineer";
      this.grpVisit.Controls.Add((Control) this.txtEndTimeMinutes);
      this.grpVisit.Controls.Add((Control) this.txtEndTimeHours);
      this.grpVisit.Controls.Add((Control) this.txtStartTimeMinutes);
      this.grpVisit.Controls.Add((Control) this.txtStartTimeHours);
      this.grpVisit.Controls.Add((Control) this.Label4);
      this.grpVisit.Controls.Add((Control) this.Label3);
      this.grpVisit.Controls.Add((Control) this.lblEndTime);
      this.grpVisit.Controls.Add((Control) this.lblStartTime);
      this.grpVisit.Controls.Add((Control) this.cboAppointment);
      this.grpVisit.Controls.Add((Control) this.lblAppointment);
      this.grpVisit.Controls.Add((Control) this.dtpVisitDate);
      this.grpVisit.Controls.Add((Control) this.lblVisitDate);
      this.grpVisit.Location = new System.Drawing.Point(14, 12);
      this.grpVisit.Name = "grpVisit";
      this.grpVisit.Size = new Size(381, 140);
      this.grpVisit.TabIndex = 47;
      this.grpVisit.TabStop = false;
      this.grpVisit.Text = "Visit";
      this.cboAppointment.FormattingEnabled = true;
      this.cboAppointment.Location = new System.Drawing.Point(92, 93);
      this.cboAppointment.Name = "cboAppointment";
      this.cboAppointment.Size = new Size(236, 21);
      this.cboAppointment.TabIndex = 61;
      this.lblAppointment.Location = new System.Drawing.Point(8, 96);
      this.lblAppointment.Name = "lblAppointment";
      this.lblAppointment.Size = new Size(76, 17);
      this.lblAppointment.TabIndex = 60;
      this.lblAppointment.Text = "Appointment:";
      this.dtpVisitDate.Location = new System.Drawing.Point(93, 21);
      this.dtpVisitDate.Name = "dtpVisitDate";
      this.dtpVisitDate.Size = new Size(235, 20);
      this.dtpVisitDate.TabIndex = 32;
      this.lblVisitDate.Location = new System.Drawing.Point(8, 24);
      this.lblVisitDate.Name = "lblVisitDate";
      this.lblVisitDate.Size = new Size(59, 15);
      this.lblVisitDate.TabIndex = 31;
      this.lblVisitDate.Text = "Visit Date";
      this.btnUpdate.Location = new System.Drawing.Point(318, 233);
      this.btnUpdate.Name = "btnUpdate";
      this.btnUpdate.Size = new Size(75, 23);
      this.btnUpdate.TabIndex = 48;
      this.btnUpdate.Text = "Update";
      this.btnUpdate.UseVisualStyleBackColor = true;
      this.txtEndTimeMinutes.Location = new System.Drawing.Point(304, 59);
      this.txtEndTimeMinutes.Name = "txtEndTimeMinutes";
      this.txtEndTimeMinutes.Size = new Size(24, 20);
      this.txtEndTimeMinutes.TabIndex = 78;
      this.txtEndTimeHours.Location = new System.Drawing.Point(273, 59);
      this.txtEndTimeHours.Name = "txtEndTimeHours";
      this.txtEndTimeHours.Size = new Size(24, 20);
      this.txtEndTimeHours.TabIndex = 79;
      this.txtStartTimeMinutes.Location = new System.Drawing.Point(123, 59);
      this.txtStartTimeMinutes.Name = "txtStartTimeMinutes";
      this.txtStartTimeMinutes.Size = new Size(24, 20);
      this.txtStartTimeMinutes.TabIndex = 77;
      this.txtStartTimeHours.Location = new System.Drawing.Point(92, 59);
      this.txtStartTimeHours.Name = "txtStartTimeHours";
      this.txtStartTimeHours.Size = new Size(24, 20);
      this.txtStartTimeHours.TabIndex = 75;
      this.Label4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label4.Location = new System.Drawing.Point(296, 61);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(8, 17);
      this.Label4.TabIndex = 80;
      this.Label4.Text = ":";
      this.Label3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label3.Location = new System.Drawing.Point(114, 61);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(8, 17);
      this.Label3.TabIndex = 81;
      this.Label3.Text = ":";
      this.lblEndTime.Location = new System.Drawing.Point(203, 62);
      this.lblEndTime.Name = "lblEndTime";
      this.lblEndTime.Size = new Size(55, 17);
      this.lblEndTime.TabIndex = 76;
      this.lblEndTime.Text = "End Time";
      this.lblStartTime.Location = new System.Drawing.Point(8, 62);
      this.lblStartTime.Name = "lblStartTime";
      this.lblStartTime.Size = new Size(60, 17);
      this.lblStartTime.TabIndex = 74;
      this.lblStartTime.Text = "Start Time";
      this.AutoScaleBaseSize = new Size(5, 13);
      this.BackColor = Color.White;
      this.ClientSize = new Size(406, 268);
      this.Controls.Add((Control) this.btnUpdate);
      this.Controls.Add((Control) this.grpVisit);
      this.Controls.Add((Control) this.grpEngineer);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MaximumSize = new Size(1000, 1000);
      this.MinimizeBox = false;
      this.Name = nameof (FRMRescheduleVisit);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Reschedule Visit";
      this.grpEngineer.ResumeLayout(false);
      this.grpEngineer.PerformLayout();
      this.grpVisit.ResumeLayout(false);
      this.grpVisit.PerformLayout();
      this.ResumeLayout(false);
    }

    public Engineer Engineer
    {
      get
      {
        return this._engineer;
      }
      set
      {
        this._engineer = value;
        if (this._engineer != null)
          this.txtEngineer.Text = this.Engineer.Name;
        else
          this.txtEngineer.Text = "<Not Set>";
      }
    }

    private EngineerVisit EngineerVisit
    {
      get
      {
        return this._engineerVisit;
      }
      set
      {
        this._engineerVisit = value;
      }
    }

    private Job Job
    {
      get
      {
        return this._job;
      }
      set
      {
        this._job = value;
      }
    }

    private void FRMSchedulerFind_Load(object sender, EventArgs e)
    {
      this.Populate();
    }

    private void btnfindEngineer_Click(object sender, EventArgs e)
    {
      this.FindEngineer();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
      this.UpdateVisit();
    }

    private void txtTime_TextChanged(object sender, EventArgs e)
    {
      TextBox[] array = new TextBox[4]
      {
        this.txtStartTimeHours,
        this.txtStartTimeMinutes,
        this.txtEndTimeHours,
        this.txtEndTimeMinutes
      };
      TextBox textBox = (TextBox) sender;
      if (textBox.Text.Length >= 2 && Array.IndexOf<TextBox>(array, textBox) < checked (array.Length - 1))
      {
        array[checked (Array.IndexOf<TextBox>(array, textBox) + 1)].Focus();
        array[checked (Array.IndexOf<TextBox>(array, textBox) + 1)].SelectAll();
      }
      else
      {
        if (textBox.Text.Length != 0 || checked (Array.IndexOf<TextBox>(array, textBox) - 1) < 0)
          return;
        array[checked (Array.IndexOf<TextBox>(array, textBox) - 1)].Focus();
        array[checked (Array.IndexOf<TextBox>(array, textBox) - 1)].SelectAll();
      }
    }

    private void Populate()
    {
      int num = this.EngineerVisit.AppointmentID == 0 ? 8 : this.EngineerVisit.AppointmentID;
      ComboBox cboAppointment = this.cboAppointment;
      Combo.SetSelectedComboItem_By_Value(ref cboAppointment, Conversions.ToString(num));
      this.cboAppointment = cboAppointment;
      this.dtpVisitDate.Value = this.EngineerVisit.StartDateTime;
      this.txtStartTimeHours.Text = this.EngineerVisit.StartDateTime.ToString("HH");
      this.txtStartTimeMinutes.Text = this.EngineerVisit.StartDateTime.ToString("mm");
      this.txtEndTimeHours.Text = this.EngineerVisit.EndDateTime.ToString("HH");
      this.txtEndTimeMinutes.Text = this.EngineerVisit.EndDateTime.ToString("mm");
      this.Engineer = App.DB.Engineer.Engineer_Get(this.EngineerVisit.EngineerID);
    }

    private void FindEngineer()
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblEngineer, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.Engineer = App.DB.Engineer.Engineer_Get(integer);
      if (!this.IsEngineerQualified(this.Engineer.EngineerID))
      {
        int num = (int) App.ShowMessage("Engineer is not qualified!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        this.Engineer = (Engineer) null;
      }
    }

    private bool IsEngineerQualified(int engineerId)
    {
      DataTable table = App.DB.EngineerLevel.Get(this.Engineer.EngineerID)?.Table;
      List<DataRow> dataRowList = table != null ? ((IEnumerable<DataRow>) table.Select("Tick = 1 AND Mandatory = 1")).ToList<DataRow>() : (List<DataRow>) null;
      Job job = this.Job;
      if (job != null && job.JobTypeID == 66971 && ((IEnumerable<DataRow>) table.Select("ManagerID =" + Conversions.ToString(71469) + " AND Tick = 1")).FirstOrDefault<DataRow>() == null)
        return false;
      try
      {
        foreach (DataRow dataRow in dataRowList)
        {
          if (DateTime.Compare(Conversions.ToDate(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["DateExpires"])), (object) DateAndTime.Now.AddMinutes(1.0), (object) Conversions.ToDate(dataRow["DateExpires"]))), DateAndTime.Today) < 0)
            return false;
        }
      }
      finally
      {
        List<DataRow>.Enumerator enumerator;
        enumerator.Dispose();
      }
      return true;
    }

    private void UpdateVisit()
    {
      if (App.ShowMessage("Reschedule visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        Engineer engineer = this.Engineer;
        if (engineer != null && engineer.EngineerID == 0)
        {
          int num1 = (int) App.ShowMessage("Please select an engineer?", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else
        {
          int hour1 = Helper.MakeIntegerValid((object) this.txtStartTimeHours.Text);
          int num2 = Helper.MakeIntegerValid((object) this.txtStartTimeMinutes.Text);
          int hour2 = Helper.MakeIntegerValid((object) this.txtEndTimeHours.Text);
          int min = Helper.MakeIntegerValid((object) this.txtEndTimeMinutes.Text);
          if (!this.IsHourAndMinValid(hour1, num2))
          {
            int num3 = (int) App.ShowMessage("Invalid start time!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          }
          else if (!this.IsHourAndMinValid(hour2, min))
          {
            int num4 = (int) App.ShowMessage("Invalid end time!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          }
          else
          {
            DateTime t1 = new DateTime(this.dtpVisitDate.Value.Year, this.dtpVisitDate.Value.Month, this.dtpVisitDate.Value.Day, hour1, num2, 0);
            DateTime t2;
            ref DateTime local = ref t2;
            DateTime dateTime = this.dtpVisitDate.Value;
            int year = dateTime.Year;
            dateTime = this.dtpVisitDate.Value;
            int month = dateTime.Month;
            dateTime = this.dtpVisitDate.Value;
            int day = dateTime.Day;
            int hour3 = hour2;
            int minute = min;
            local = new DateTime(year, month, day, hour3, minute, 0);
            if (DateTime.Compare(t1, t2) > 0)
            {
              int num5 = (int) App.ShowMessage("Start time can not be greater than end time", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (DateTime.Compare(t1, t2) == 0)
            {
              int num6 = (int) App.ShowMessage("Start time can not be equal to end time", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
              this.EngineerVisit.StartDateTime = t1;
              this.EngineerVisit.EndDateTime = t2;
              this.EngineerVisit.SetAppointmentID = (object) Helper.MakeIntegerValid((object) Combo.get_GetSelectedItemValue(this.cboAppointment));
              this.EngineerVisit.SetEngineerID = (object) this.Engineer.EngineerID;
              App.DB.Scheduler.ScheduleVisit(this.EngineerVisit);
              if (this.Modal)
                this.Close();
              else
                this.Dispose();
            }
          }
        }
      }
    }

    private bool IsHourAndMinValid(int hour, int min)
    {
      return hour >= 0 && hour <= 23 && (min >= 0 && min <= 59);
    }
  }
}
