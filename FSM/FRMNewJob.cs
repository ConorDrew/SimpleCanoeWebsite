// Decompiled with JetBrains decompiler
// Type: FSM.FRMNewJob
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Engineers;
using FSM.Entity.EngineerVisits;
using FSM.Entity.JobOfWorks;
using FSM.Entity.Jobs;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using FSM.Entity.Users;
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
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMNewJob : Form
  {
    private IContainer components;
    private FSM.Entity.Sites.Site _site;
    private DataView _dvJobs;
    private Engineer _engineer;
    private User _salesRep;

    public FRMNewJob([DateTimeConstant(0), Optional] DateTime visitDate, int engineerId = 0)
    {
      this.InitializeComponent();
      ComboBox cboJobType = this.cboJobType;
      Combo.SetUpCombo(ref cboJobType, App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboJobType = cboJobType;
      ComboBox cboAppointment1 = this.cboAppointment;
      Combo.SetUpCombo(ref cboAppointment1, App.DB.Appointments.GetAll().Table, "AppointmentID", "Name", Enums.ComboValues.Please_Select);
      this.cboAppointment = cboAppointment1;
      ComboBox cboAppointment2 = this.cboAppointment;
      Combo.SetSelectedComboItem_By_Value(ref cboAppointment2, Conversions.ToString(8));
      this.cboAppointment = cboAppointment2;
      if ((uint) DateTime.Compare(visitDate, DateTime.MinValue) > 0U)
        this.dtpVisitDate.Value = visitDate;
      this.Engineer = App.DB.Engineer.Engineer_Get(engineerId);
      TextBox txtStartTimeHours = this.txtStartTimeHours;
      DateTime dateTime = DateAndTime.Now;
      string str1 = dateTime.ToString("HH");
      txtStartTimeHours.Text = str1;
      TextBox startTimeMinutes = this.txtStartTimeMinutes;
      dateTime = DateAndTime.Now;
      string str2 = dateTime.ToString("mm");
      startTimeMinutes.Text = str2;
      TextBox txtEndTimeHours = this.txtEndTimeHours;
      dateTime = DateAndTime.Now;
      dateTime = dateTime.AddHours(1.0);
      string str3 = dateTime.ToString("HH");
      txtEndTimeHours.Text = str3;
      TextBox txtEndTimeMinutes = this.txtEndTimeMinutes;
      dateTime = DateAndTime.Now;
      string str4 = dateTime.ToString("mm");
      txtEndTimeMinutes.Text = str4;
      this.grpPaymentType.Visible = !App.IsRFT;
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

    internal virtual GroupBox grpVisit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblVisitDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboAppointment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAppointment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpVisitDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnCreate
    {
      get
      {
        return this._btnCreate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCreate_Click);
        Button btnCreate1 = this._btnCreate;
        if (btnCreate1 != null)
          btnCreate1.Click -= eventHandler;
        this._btnCreate = value;
        Button btnCreate2 = this._btnCreate;
        if (btnCreate2 == null)
          return;
        btnCreate2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindSite
    {
      get
      {
        return this._btnFindSite;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindSite_Click);
        Button btnFindSite1 = this._btnFindSite;
        if (btnFindSite1 != null)
          btnFindSite1.Click -= eventHandler;
        this._btnFindSite = value;
        Button btnFindSite2 = this._btnFindSite;
        if (btnFindSite2 == null)
          return;
        btnFindSite2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpJob { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgJobs
    {
      get
      {
        return this._dgJobs;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgJobs_Click);
        DataGrid dgJobs1 = this._dgJobs;
        if (dgJobs1 != null)
          dgJobs1.Click -= eventHandler;
        this._dgJobs = value;
        DataGrid dgJobs2 = this._dgJobs;
        if (dgJobs2 == null)
          return;
        dgJobs2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtNotesToEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox cbNewJob
    {
      get
      {
        return this._cbNewJob;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbNewJob_Click);
        CheckBox cbNewJob1 = this._cbNewJob;
        if (cbNewJob1 != null)
          cbNewJob1.Click -= eventHandler;
        this._cbNewJob = value;
        CheckBox cbNewJob2 = this._cbNewJob;
        if (cbNewJob2 == null)
          return;
        cbNewJob2.Click += eventHandler;
      }
    }

    internal virtual RadioButton rbtnFoc { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpPaymentType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton rbtnOti { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton rbtnPoc { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpSaleRep { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpJobType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindSalesRep
    {
      get
      {
        return this._btnFindSalesRep;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindSalesRep_Click);
        Button btnFindSalesRep1 = this._btnFindSalesRep;
        if (btnFindSalesRep1 != null)
          btnFindSalesRep1.Click -= eventHandler;
        this._btnFindSalesRep = value;
        Button btnFindSalesRep2 = this._btnFindSalesRep;
        if (btnFindSalesRep2 == null)
          return;
        btnFindSalesRep2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtSalesRep { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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
      this.grpVisit = new GroupBox();
      this.txtEndTimeMinutes = new TextBox();
      this.txtEndTimeHours = new TextBox();
      this.txtStartTimeMinutes = new TextBox();
      this.txtStartTimeHours = new TextBox();
      this.Label4 = new Label();
      this.Label3 = new Label();
      this.lblEndTime = new Label();
      this.lblStartTime = new Label();
      this.txtNotesToEngineer = new TextBox();
      this.lblNotes = new Label();
      this.cboAppointment = new ComboBox();
      this.lblAppointment = new Label();
      this.dtpVisitDate = new DateTimePicker();
      this.lblVisitDate = new Label();
      this.btnCreate = new Button();
      this.grpSite = new GroupBox();
      this.btnFindSite = new Button();
      this.txtSite = new TextBox();
      this.grpJob = new GroupBox();
      this.grpSaleRep = new GroupBox();
      this.btnFindSalesRep = new Button();
      this.txtSalesRep = new TextBox();
      this.grpJobType = new GroupBox();
      this.cboJobType = new ComboBox();
      this.grpPaymentType = new GroupBox();
      this.rbtnOti = new RadioButton();
      this.rbtnPoc = new RadioButton();
      this.rbtnFoc = new RadioButton();
      this.cbNewJob = new CheckBox();
      this.dgJobs = new DataGrid();
      this.grpEngineer.SuspendLayout();
      this.grpVisit.SuspendLayout();
      this.grpSite.SuspendLayout();
      this.grpJob.SuspendLayout();
      this.grpSaleRep.SuspendLayout();
      this.grpJobType.SuspendLayout();
      this.grpPaymentType.SuspendLayout();
      this.dgJobs.BeginInit();
      this.SuspendLayout();
      this.grpEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpEngineer.Controls.Add((Control) this.btnfindEngineer);
      this.grpEngineer.Controls.Add((Control) this.txtEngineer);
      this.grpEngineer.Location = new System.Drawing.Point(12, 428);
      this.grpEngineer.Name = "grpEngineer";
      this.grpEngineer.Size = new Size(658, 57);
      this.grpEngineer.TabIndex = 46;
      this.grpEngineer.TabStop = false;
      this.grpEngineer.Text = "Engineer";
      this.btnfindEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnfindEngineer.BackColor = Color.White;
      this.btnfindEngineer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnfindEngineer.Location = new System.Drawing.Point(620, 18);
      this.btnfindEngineer.Name = "btnfindEngineer";
      this.btnfindEngineer.Size = new Size(32, 23);
      this.btnfindEngineer.TabIndex = 18;
      this.btnfindEngineer.Text = "...";
      this.btnfindEngineer.UseVisualStyleBackColor = false;
      this.txtEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtEngineer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtEngineer.Location = new System.Drawing.Point(7, 19);
      this.txtEngineer.Name = "txtEngineer";
      this.txtEngineer.ReadOnly = true;
      this.txtEngineer.Size = new Size(607, 21);
      this.txtEngineer.TabIndex = 17;
      this.grpVisit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpVisit.Controls.Add((Control) this.txtEndTimeMinutes);
      this.grpVisit.Controls.Add((Control) this.txtEndTimeHours);
      this.grpVisit.Controls.Add((Control) this.txtStartTimeMinutes);
      this.grpVisit.Controls.Add((Control) this.txtStartTimeHours);
      this.grpVisit.Controls.Add((Control) this.Label4);
      this.grpVisit.Controls.Add((Control) this.Label3);
      this.grpVisit.Controls.Add((Control) this.lblEndTime);
      this.grpVisit.Controls.Add((Control) this.lblStartTime);
      this.grpVisit.Controls.Add((Control) this.txtNotesToEngineer);
      this.grpVisit.Controls.Add((Control) this.lblNotes);
      this.grpVisit.Controls.Add((Control) this.cboAppointment);
      this.grpVisit.Controls.Add((Control) this.lblAppointment);
      this.grpVisit.Controls.Add((Control) this.dtpVisitDate);
      this.grpVisit.Controls.Add((Control) this.lblVisitDate);
      this.grpVisit.Location = new System.Drawing.Point(12, 293);
      this.grpVisit.Name = "grpVisit";
      this.grpVisit.Size = new Size(658, 129);
      this.grpVisit.TabIndex = 47;
      this.grpVisit.TabStop = false;
      this.grpVisit.Text = "Visit";
      this.txtEndTimeMinutes.Location = new System.Drawing.Point(304, 58);
      this.txtEndTimeMinutes.Name = "txtEndTimeMinutes";
      this.txtEndTimeMinutes.Size = new Size(24, 20);
      this.txtEndTimeMinutes.TabIndex = 70;
      this.txtEndTimeHours.Location = new System.Drawing.Point(273, 58);
      this.txtEndTimeHours.Name = "txtEndTimeHours";
      this.txtEndTimeHours.Size = new Size(24, 20);
      this.txtEndTimeHours.TabIndex = 71;
      this.txtStartTimeMinutes.Location = new System.Drawing.Point(124, 58);
      this.txtStartTimeMinutes.Name = "txtStartTimeMinutes";
      this.txtStartTimeMinutes.Size = new Size(24, 20);
      this.txtStartTimeMinutes.TabIndex = 69;
      this.txtStartTimeHours.Location = new System.Drawing.Point(93, 58);
      this.txtStartTimeHours.Name = "txtStartTimeHours";
      this.txtStartTimeHours.Size = new Size(24, 20);
      this.txtStartTimeHours.TabIndex = 67;
      this.Label4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label4.Location = new System.Drawing.Point(296, 60);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(8, 17);
      this.Label4.TabIndex = 72;
      this.Label4.Text = ":";
      this.Label3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label3.Location = new System.Drawing.Point(115, 60);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(8, 17);
      this.Label3.TabIndex = 73;
      this.Label3.Text = ":";
      this.lblEndTime.Location = new System.Drawing.Point(203, 61);
      this.lblEndTime.Name = "lblEndTime";
      this.lblEndTime.Size = new Size(55, 17);
      this.lblEndTime.TabIndex = 68;
      this.lblEndTime.Text = "End Time";
      this.lblStartTime.Location = new System.Drawing.Point(10, 61);
      this.lblStartTime.Name = "lblStartTime";
      this.lblStartTime.Size = new Size(60, 17);
      this.lblStartTime.TabIndex = 66;
      this.lblStartTime.Text = "Start Time";
      this.txtNotesToEngineer.AcceptsReturn = true;
      this.txtNotesToEngineer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNotesToEngineer.Location = new System.Drawing.Point(403, 19);
      this.txtNotesToEngineer.Multiline = true;
      this.txtNotesToEngineer.Name = "txtNotesToEngineer";
      this.txtNotesToEngineer.ScrollBars = ScrollBars.Vertical;
      this.txtNotesToEngineer.Size = new Size(247, 95);
      this.txtNotesToEngineer.TabIndex = 65;
      this.lblNotes.Location = new System.Drawing.Point(351, 24);
      this.lblNotes.Name = "lblNotes";
      this.lblNotes.Size = new Size(59, 15);
      this.lblNotes.TabIndex = 64;
      this.lblNotes.Text = "Notes";
      this.cboAppointment.FormattingEnabled = true;
      this.cboAppointment.Location = new System.Drawing.Point(92, 93);
      this.cboAppointment.Name = "cboAppointment";
      this.cboAppointment.Size = new Size(236, 21);
      this.cboAppointment.TabIndex = 61;
      this.lblAppointment.Location = new System.Drawing.Point(10, 97);
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
      this.btnCreate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnCreate.Location = new System.Drawing.Point(595, 494);
      this.btnCreate.Name = "btnCreate";
      this.btnCreate.Size = new Size(77, 23);
      this.btnCreate.TabIndex = 48;
      this.btnCreate.Text = "Create";
      this.btnCreate.UseVisualStyleBackColor = true;
      this.grpSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSite.Controls.Add((Control) this.btnFindSite);
      this.grpSite.Controls.Add((Control) this.txtSite);
      this.grpSite.Location = new System.Drawing.Point(12, 12);
      this.grpSite.Name = "grpSite";
      this.grpSite.Size = new Size(658, 55);
      this.grpSite.TabIndex = 49;
      this.grpSite.TabStop = false;
      this.grpSite.Text = "Site";
      this.btnFindSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindSite.BackColor = Color.White;
      this.btnFindSite.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindSite.Location = new System.Drawing.Point(620, 16);
      this.btnFindSite.Name = "btnFindSite";
      this.btnFindSite.Size = new Size(32, 23);
      this.btnFindSite.TabIndex = 18;
      this.btnFindSite.Text = "...";
      this.btnFindSite.UseVisualStyleBackColor = false;
      this.txtSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSite.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSite.Location = new System.Drawing.Point(6, 17);
      this.txtSite.Name = "txtSite";
      this.txtSite.ReadOnly = true;
      this.txtSite.Size = new Size(605, 21);
      this.txtSite.TabIndex = 17;
      this.grpJob.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpJob.Controls.Add((Control) this.grpSaleRep);
      this.grpJob.Controls.Add((Control) this.grpJobType);
      this.grpJob.Controls.Add((Control) this.grpPaymentType);
      this.grpJob.Controls.Add((Control) this.cbNewJob);
      this.grpJob.Controls.Add((Control) this.dgJobs);
      this.grpJob.Location = new System.Drawing.Point(12, 73);
      this.grpJob.Name = "grpJob";
      this.grpJob.Size = new Size(658, 214);
      this.grpJob.TabIndex = 64;
      this.grpJob.TabStop = false;
      this.grpJob.Text = "Job";
      this.grpSaleRep.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSaleRep.Controls.Add((Control) this.btnFindSalesRep);
      this.grpSaleRep.Controls.Add((Control) this.txtSalesRep);
      this.grpSaleRep.Location = new System.Drawing.Point(375, 164);
      this.grpSaleRep.Name = "grpSaleRep";
      this.grpSaleRep.Size = new Size(274, 44);
      this.grpSaleRep.TabIndex = 72;
      this.grpSaleRep.TabStop = false;
      this.grpSaleRep.Text = "Sales Rep";
      this.btnFindSalesRep.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindSalesRep.BackColor = Color.White;
      this.btnFindSalesRep.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindSalesRep.Location = new System.Drawing.Point(236, 16);
      this.btnFindSalesRep.Name = "btnFindSalesRep";
      this.btnFindSalesRep.Size = new Size(32, 23);
      this.btnFindSalesRep.TabIndex = 66;
      this.btnFindSalesRep.Text = "...";
      this.btnFindSalesRep.UseVisualStyleBackColor = false;
      this.txtSalesRep.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSalesRep.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSalesRep.Location = new System.Drawing.Point(6, 17);
      this.txtSalesRep.Name = "txtSalesRep";
      this.txtSalesRep.ReadOnly = true;
      this.txtSalesRep.Size = new Size(224, 21);
      this.txtSalesRep.TabIndex = 65;
      this.grpJobType.Controls.Add((Control) this.cboJobType);
      this.grpJobType.Location = new System.Drawing.Point(176, 164);
      this.grpJobType.Name = "grpJobType";
      this.grpJobType.Size = new Size(193, 44);
      this.grpJobType.TabIndex = 71;
      this.grpJobType.TabStop = false;
      this.grpJobType.Text = "Job Type";
      this.cboJobType.Location = new System.Drawing.Point(6, 17);
      this.cboJobType.Name = "cboJobType";
      this.cboJobType.Size = new Size(181, 21);
      this.cboJobType.TabIndex = 65;
      this.grpPaymentType.Controls.Add((Control) this.rbtnOti);
      this.grpPaymentType.Controls.Add((Control) this.rbtnPoc);
      this.grpPaymentType.Controls.Add((Control) this.rbtnFoc);
      this.grpPaymentType.Location = new System.Drawing.Point(6, 164);
      this.grpPaymentType.Name = "grpPaymentType";
      this.grpPaymentType.Size = new Size(164, 44);
      this.grpPaymentType.TabIndex = 67;
      this.grpPaymentType.TabStop = false;
      this.grpPaymentType.Text = "Payment Type";
      this.rbtnOti.AutoSize = true;
      this.rbtnOti.Location = new System.Drawing.Point(113, 19);
      this.rbtnOti.Name = "rbtnOti";
      this.rbtnOti.Size = new Size(43, 17);
      this.rbtnOti.TabIndex = 70;
      this.rbtnOti.TabStop = true;
      this.rbtnOti.Text = "OTI";
      this.rbtnOti.UseVisualStyleBackColor = true;
      this.rbtnPoc.AutoSize = true;
      this.rbtnPoc.Location = new System.Drawing.Point(59, 19);
      this.rbtnPoc.Name = "rbtnPoc";
      this.rbtnPoc.Size = new Size(47, 17);
      this.rbtnPoc.TabIndex = 69;
      this.rbtnPoc.TabStop = true;
      this.rbtnPoc.Text = "POC";
      this.rbtnPoc.UseVisualStyleBackColor = true;
      this.rbtnFoc.AutoSize = true;
      this.rbtnFoc.Location = new System.Drawing.Point(7, 19);
      this.rbtnFoc.Name = "rbtnFoc";
      this.rbtnFoc.Size = new Size(46, 17);
      this.rbtnFoc.TabIndex = 68;
      this.rbtnFoc.TabStop = true;
      this.rbtnFoc.Text = "FOC";
      this.rbtnFoc.UseVisualStyleBackColor = true;
      this.cbNewJob.AutoCheck = false;
      this.cbNewJob.AutoSize = true;
      this.cbNewJob.Checked = true;
      this.cbNewJob.CheckState = CheckState.Checked;
      this.cbNewJob.Location = new System.Drawing.Point(7, 19);
      this.cbNewJob.Name = "cbNewJob";
      this.cbNewJob.Size = new Size(68, 17);
      this.cbNewJob.TabIndex = 14;
      this.cbNewJob.Text = "New Job";
      this.cbNewJob.UseVisualStyleBackColor = true;
      this.dgJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgJobs.DataMember = "";
      this.dgJobs.Enabled = false;
      this.dgJobs.HeaderForeColor = SystemColors.ControlText;
      this.dgJobs.Location = new System.Drawing.Point(6, 42);
      this.dgJobs.Name = "dgJobs";
      this.dgJobs.Size = new Size(641, 116);
      this.dgJobs.TabIndex = 13;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.BackColor = Color.White;
      this.ClientSize = new Size(684, 529);
      this.Controls.Add((Control) this.grpJob);
      this.Controls.Add((Control) this.grpSite);
      this.Controls.Add((Control) this.btnCreate);
      this.Controls.Add((Control) this.grpVisit);
      this.Controls.Add((Control) this.grpEngineer);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MaximumSize = new Size(1000, 1000);
      this.MinimizeBox = false;
      this.Name = nameof (FRMNewJob);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "New Job";
      this.grpEngineer.ResumeLayout(false);
      this.grpEngineer.PerformLayout();
      this.grpVisit.ResumeLayout(false);
      this.grpVisit.PerformLayout();
      this.grpSite.ResumeLayout(false);
      this.grpSite.PerformLayout();
      this.grpJob.ResumeLayout(false);
      this.grpJob.PerformLayout();
      this.grpSaleRep.ResumeLayout(false);
      this.grpSaleRep.PerformLayout();
      this.grpJobType.ResumeLayout(false);
      this.grpPaymentType.ResumeLayout(false);
      this.grpPaymentType.PerformLayout();
      this.dgJobs.EndInit();
      this.ResumeLayout(false);
    }

    private FSM.Entity.Sites.Site Site
    {
      get
      {
        return this._site;
      }
      set
      {
        this._site = value;
        if (this._site != null)
        {
          string str = string.Empty;
          if (!string.IsNullOrEmpty(this._site.Name))
            str = str + this._site.Name + ", ";
          if (!string.IsNullOrEmpty(this._site.Address1))
            str = str + this._site.Address1 + ", ";
          if (!string.IsNullOrEmpty(this._site.Address2))
            str = str + this._site.Address2 + ", ";
          if (!string.IsNullOrEmpty(this._site.Postcode))
            str += this._site.Postcode;
          this.txtSite.Text = str;
          if (string.IsNullOrEmpty(this._site.ContactAlerts))
            return;
          this.txtNotesToEngineer.Text = this._site.ContactAlerts + " - ";
        }
        else
        {
          this.txtSite.Text = "<Not set>";
          this.txtNotesToEngineer.Text = "";
        }
      }
    }

    private DataView DvJobs
    {
      get
      {
        return this._dvJobs;
      }
      set
      {
        this._dvJobs = value;
        this._dvJobs.Table.TableName = Enums.TableNames.NO_TABLE.ToString();
        this.dgJobs.DataSource = (object) this.DvJobs;
      }
    }

    private DataRow DrSelectedJob
    {
      get
      {
        return this.dgJobs.CurrentRowIndex != -1 ? this.DvJobs[this.dgJobs.CurrentRowIndex].Row : (DataRow) null;
      }
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

    private User SalesRep
    {
      get
      {
        return this._salesRep;
      }
      set
      {
        this._salesRep = value;
        if (this._salesRep != null)
          this.txtSalesRep.Text = this.SalesRep.Fullname;
        else
          this.txtSalesRep.Text = "<Not Set>";
      }
    }

    private Job Job { get; set; }

    private EngineerVisit EngineerVisit { get; set; }

    private DateTime VisitStartDate { get; set; }

    private DateTime VisitEndDate { get; set; }

    private void btnFindSite_Click(object sender, EventArgs e)
    {
      this.FindSite();
    }

    private void cbNewJob_Click(object sender, EventArgs e)
    {
      this.cbNewJob.Checked = !this.cbNewJob.Checked;
      this.CbNewJobClicked();
    }

    private void dgJobs_Click(object sender, EventArgs e)
    {
      this.DgJobsClicked();
    }

    private void btnfindEngineer_Click(object sender, EventArgs e)
    {
      this.FindEngineer();
    }

    private void btnCreate_Click(object sender, EventArgs e)
    {
      this.CreateJob();
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

    private void btnFindSalesRep_Click(object sender, EventArgs e)
    {
      this.FindUser();
    }

    private void FindSite()
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite, 0, "", false));
      if ((uint) integer > 0U)
      {
        this.Site = App.DB.Sites.Get((object) integer, SiteSQL.GetBy.SiteId, (object) null);
        if (this.Site.OnStop)
        {
          int num = (int) App.ShowMessage("This site is ON STOP!\r\n\r\nCannot create new job!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.Site = (FSM.Entity.Sites.Site) null;
        }
        else if (App.DB.Customer.Customer_Get(this.Site.CustomerID)?.Status.Value == 3)
        {
          int num = (int) App.ShowMessage("The customer is ON HOLD!\r\n\r\nCannot create new job!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          this.Site = (FSM.Entity.Sites.Site) null;
        }
        else
        {
          this.cbNewJob.Checked = true;
          this.CbNewJobClicked();
        }
      }
    }

    private void FindJobs()
    {
      if (this.Site == null)
        return;
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = App.DB.Job.Job_GetTop100_For_Site(this.Site.SiteID, this.Site.CustomerID)?.Table;
      DataRowCollection rows = dataTable2.Rows;
      if (rows != null && rows.Count > 0)
      {
        IEnumerable<DataRow> source = dataTable2.AsEnumerable().Take<DataRow>(10);
        dataTable2 = source != null ? source.CopyToDataTable<DataRow>() : (DataTable) null;
      }
      this.DvJobs = new DataView(dataTable2);
      this.ResetJob();
    }

    private void CbNewJobClicked()
    {
      if (!this.cbNewJob.Checked)
      {
        this.SetupDgJobs();
        this.FindJobs();
        this.grpPaymentType.Enabled = false;
        this.grpJobType.Enabled = false;
        this.grpSaleRep.Enabled = false;
      }
      else
      {
        this.DvJobs = new DataView(new DataTable());
        this.ClearDgJobs();
        this.grpPaymentType.Enabled = true;
        this.grpJobType.Enabled = true;
        this.grpSaleRep.Enabled = true;
        this.ResetJob();
      }
    }

    private void FindUser()
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblUser, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.SalesRep = App.DB.User.Get(integer, false);
    }

    private void FindEngineer()
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblEngineer, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.Engineer = App.DB.Engineer.Engineer_Get(integer);
    }

    private void DgJobsClicked()
    {
      if (this.DrSelectedJob == null)
        return;
      this.Job = App.DB.Job.Job_Get(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.DrSelectedJob["JobID"])));
      this.rbtnFoc.Checked = this.Job?.FOC.Value;
      this.rbtnPoc.Checked = this.Job?.POC.Value;
      this.rbtnOti.Checked = this.Job?.OTI.Value;
      ComboBox cboJobType = this.cboJobType;
      Combo.SetSelectedComboItem_By_Value(ref cboJobType, Conversions.ToString(this.Job?.JobTypeID.Value));
      this.cboJobType = cboJobType;
      this.SalesRep = App.DB.User.Get(this.Job?.SalesRepUserID.Value, false);
    }

    private void ResetJob()
    {
      this.rbtnFoc.Checked = App.IsRFT;
      this.rbtnPoc.Checked = false;
      this.rbtnOti.Checked = false;
      ComboBox cboJobType = this.cboJobType;
      Combo.SetSelectedComboItem_By_Value(ref cboJobType, Conversions.ToString(0));
      this.cboJobType = cboJobType;
      this.SalesRep = (User) null;
    }

    private bool IsFormValid()
    {
      if (this.Site == null)
      {
        int num = (int) App.ShowMessage("Please select a site!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
      if (!this.rbtnFoc.Checked & !this.rbtnPoc.Checked & !this.rbtnOti.Checked)
      {
        int num = (int) App.ShowMessage("Please select a payment type!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
      if ((uint) Helper.MakeIntegerValid((object) (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboJobType)) == 0.0)) > 0U)
      {
        int num = (int) App.ShowMessage("Please select a job type!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
      int hour1 = Helper.MakeIntegerValid((object) this.txtStartTimeHours.Text);
      int min1 = Helper.MakeIntegerValid((object) this.txtStartTimeMinutes.Text);
      int hour2 = Helper.MakeIntegerValid((object) this.txtEndTimeHours.Text);
      int min2 = Helper.MakeIntegerValid((object) this.txtEndTimeMinutes.Text);
      if (!this.IsHourAndMinValid(hour1, min1))
      {
        int num = (int) App.ShowMessage("Invalid start time!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
      if (!this.IsHourAndMinValid(hour2, min2))
      {
        int num = (int) App.ShowMessage("Invalid end time!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
      int year1 = this.dtpVisitDate.Value.Year;
      DateTime dateTime = this.dtpVisitDate.Value;
      int month1 = dateTime.Month;
      dateTime = this.dtpVisitDate.Value;
      int day1 = dateTime.Day;
      int hour3 = hour1;
      int minute1 = min1;
      this.VisitStartDate = new DateTime(year1, month1, day1, hour3, minute1, 0);
      dateTime = this.dtpVisitDate.Value;
      int year2 = dateTime.Year;
      dateTime = this.dtpVisitDate.Value;
      int month2 = dateTime.Month;
      dateTime = this.dtpVisitDate.Value;
      int day2 = dateTime.Day;
      int hour4 = hour2;
      int minute2 = min2;
      this.VisitEndDate = new DateTime(year2, month2, day2, hour4, minute2, 0);
      if (DateTime.Compare(this.VisitStartDate, this.VisitEndDate) > 0)
      {
        int num = (int) App.ShowMessage("Start time can not be greater than end time!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
      if (DateTime.Compare(this.VisitStartDate, this.VisitEndDate) == 0)
      {
        int num = (int) App.ShowMessage("Start time can not be equal to end time!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
      if (this.txtNotesToEngineer.Text.Trim().Length == 0)
      {
        int num = (int) App.ShowMessage("Please enter notes for the visit!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
      if (this.Engineer == null)
      {
        int num = (int) App.ShowMessage("Please select an engineer!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
      if (this.IsEngineerQualified(this.Engineer.EngineerID))
        return true;
      int num1 = (int) App.ShowMessage("Engineer is not qualified!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      return false;
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

    private bool IsHourAndMinValid(int hour, int min)
    {
      return hour >= 0 && hour <= 23 && (min >= 0 && min <= 59);
    }

    private void CreateJob()
    {
      try
      {
        if (!this.IsFormValid())
          return;
        Job job1 = this.Job;
        string MessageText = (job1 != null ? (job1.JobID > 0 ? 1 : 0) : 0) != 0 ? "Generate new visit?" : "Create new job?";
        Job job2 = this.Job;
        string str = (job2 != null ? (job2.JobID > 0 ? 1 : 0) : 0) != 0 ? "New visit generated!" : " New job created!";
        if (App.ShowMessage(MessageText, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
          EngineerVisit engineerVisit1 = new EngineerVisit()
          {
            IgnoreExceptionsOnSetMethods = true,
            StartDateTime = this.VisitStartDate,
            EndDateTime = this.VisitEndDate,
            SetEngineerID = (object) this.Engineer?.EngineerID,
            SetStatusEnumID = (object) 5,
            SetAppointmentID = (object) Helper.MakeIntegerValid((object) Combo.get_GetSelectedItemValue(this.cboAppointment)),
            SetNotesToEngineer = (object) this.txtNotesToEngineer.Text.Trim()
          };
          Job job3 = this.Job;
          if (job3 != null && job3.JobID > 0)
          {
            object jobOfWork = this.Job.JobOfWorks[checked (this.Job.JobOfWorks.Count - 1)];
            if (jobOfWork != null)
            {
              object[] objArray;
              bool[] flagArray;
              NewLateBinding.LateCall(NewLateBinding.LateGet(jobOfWork, (System.Type) null, "EngineerVisits", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "Add", objArray = new object[1]
              {
                (object) engineerVisit1
              }, (string[]) null, (System.Type[]) null, flagArray = new bool[1]
              {
                true
              }, true);
              if (flagArray[0])
              {
                EngineerVisit engineerVisit2 = (EngineerVisit) Conversions.ChangeType(RuntimeHelpers.GetObjectValue(objArray[0]), typeof (EngineerVisit));
              }
            }
            this.Job = App.DB.Job.Update(this.Job);
          }
          else
          {
            this.Job = new Job();
            Job job4 = this.Job;
            job4.IgnoreExceptionsOnSetMethods = true;
            job4.SetPropertyID = (object) this.Site.SiteID;
            job4.SetJobTypeID = (object) Helper.MakeIntegerValid((object) Combo.get_GetSelectedItemValue(this.cboJobType));
            job4.SetJobDefinitionEnumID = (object) 3;
            job4.SetStatusEnumID = (object) 1;
            job4.SetCreatedByUserID = (object) App.loggedInUser.UserID;
            job4.SetFOC = (object) this.rbtnFoc.Checked;
            job4.SetPOC = (object) this.rbtnPoc.Checked;
            job4.SetOTI = (object) this.rbtnOti.Checked;
            job4.SetJobCreationType = (object) 0;
            JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Callout);
            job4.SetJobNumber = (object) (nextJobNumber?.Prefix + (nextJobNumber != null ? Conversions.ToString(nextJobNumber.JobNumber) : (string) null));
            job4.SetSalesRepUserID = (object) this.SalesRep?.UserID;
            job4.SetPONumber = (object) "";
            JobOfWork jobOfWork = new JobOfWork()
            {
              SetPONumber = (object) "",
              PriorityDateSet = DateAndTime.Now
            };
            jobOfWork.EngineerVisits.Add((object) engineerVisit1);
            this.Job.JobOfWorks.Add((object) jobOfWork);
            this.Job = App.DB.Job.Insert(this.Job);
          }
          if (App.ShowMessage(str + "\r\n\r\nDo you want to open the job?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            App.ShowForm(typeof (FRMLogCallout), true, new object[2]
            {
              (object) this.Job.JobID,
              (object) this.Job.PropertyID
            }, false);
          if (this.Modal)
            this.Close();
          else
            this.Dispose();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        int num = (int) App.ShowMessage(exception.Message + " - " + exception.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    public void SetupDgJobs()
    {
      this.dgJobs.Enabled = true;
      Helper.SetUpDataGrid(this.dgJobs, false);
      DataGridTableStyle tableStyle = this.dgJobs.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "dd/MM/yyyy";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Created";
      dataGridLabelColumn1.MappingName = "DateCreated";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Job No";
      dataGridLabelColumn2.MappingName = "JobNumber";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 120;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Type";
      dataGridLabelColumn3.MappingName = "Type";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 250;
      dataGridLabelColumn3.NullText = Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "dd/MM/yyyy";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Last Visit's Date";
      dataGridLabelColumn4.MappingName = "LastVisitDate";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 120;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.NO_TABLE.ToString();
      this.dgJobs.TableStyles.Add(tableStyle);
    }

    private void ClearDgJobs()
    {
      Helper.SetUpDataGrid(this.dgJobs, false);
      DataGridTableStyle tableStyle = this.dgJobs.TableStyles[0];
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.NO_TABLE.ToString();
      this.dgJobs.TableStyles.Add(tableStyle);
      this.dgJobs.Enabled = false;
    }
  }
}
