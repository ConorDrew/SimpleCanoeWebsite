// Decompiled with JetBrains decompiler
// Type: FSM.frmVisit
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Management;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Pabo.Calendar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class frmVisit : FRMBaseForm, ISchedulerForm
  {
    private List<Label> lblStarts;
    private List<DateTimePicker> dtpMulitpleVisitsStart;
    private List<Label> lblEnds;
    private List<DateTimePicker> dtpMulitpleVisitsEnd;
    private List<Button> btnAddVisits;
    private List<Button> btnRemoveVisits;
    private IContainer components;
    private bool isCopy;
    private frmDetailsPopup _detailPopup;
    private DataTable timeSlotDt;
    private string _engineerID;
    private string _AMPM;
    private DateTime _theSelectedDay;
    private DateTime _StartDate;
    private DateTime _EndDate;
    private int _AppointmentType;
    private int _SORMinutes;
    public bool mulitpleVisits;
    private List<List<DateTime>> _visitsList;

    public frmVisit(
      int EngineerIDIn,
      DateTime Date,
      int SORTotal,
      int EngineerVisitID,
      bool isCopyIn)
    {
      this.SizeChanged += new EventHandler(this.frmVisit_SizeChanged);
      this.Load += new EventHandler(this.frmVisit_Load);
      this.isCopy = false;
      this._AMPM = "";
      this.mulitpleVisits = false;
      this._visitsList = new List<List<DateTime>>();
      this.engineerID = Conversions.ToString(EngineerIDIn);
      this.InitializeComponent();
      this.lblStarts = new List<Label>();
      this.dtpMulitpleVisitsStart = new List<DateTimePicker>();
      this.lblEnds = new List<Label>();
      this.dtpMulitpleVisitsEnd = new List<DateTimePicker>();
      this.btnAddVisits = new List<Button>();
      this.btnRemoveVisits = new List<Button>();
      this.theSelectedDay = Date;
      this.DtTimeSlot = App.DB.Scheduler.Scheduler_DayTimeSlots(Date, this.engineerID);
      this.picPlanner.Image = (Image) this.scheduler_DayTimeSlots_bitmap();
      this.SORMinutes = SORTotal;
      this.AMPM = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(EngineerVisitID, true).AMPM;
      ComboBox cboAppointment = this.cboAppointment;
      Combo.SetUpCombo(ref cboAppointment, App.DB.Appointments.GetAll().Table, "AppointmentID", "Name", Enums.ComboValues.Please_Select);
      this.cboAppointment = cboAppointment;
      this.InitComplexVisits();
      this.isCopy = isCopyIn;
      this._detailPopup = new frmDetailsPopup(this);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual TabControl tabCtrlVisits { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabStandardVisit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabComplexVisit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboAppointment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAMPM { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEndTimeMinutes
    {
      get
      {
        return this._txtEndTimeMinutes;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtEndTimeHours_TextChanged);
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
        EventHandler eventHandler = new EventHandler(this.txtEndTimeHours_TextChanged);
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
        EventHandler eventHandler = new EventHandler(this.txtEndTimeHours_TextChanged);
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
        EventHandler eventHandler = new EventHandler(this.txtEndTimeHours_TextChanged);
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

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSave
    {
      get
      {
        return this._btnSave;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSave_Click);
        Button btnSave1 = this._btnSave;
        if (btnSave1 != null)
          btnSave1.Click -= eventHandler;
        this._btnSave = value;
        Button btnSave2 = this._btnSave;
        if (btnSave2 == null)
          return;
        btnSave2.Click += eventHandler;
      }
    }

    internal virtual Button btnCancel
    {
      get
      {
        return this._btnCancel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCancel_Click);
        Button btnCancel1 = this._btnCancel;
        if (btnCancel1 != null)
          btnCancel1.Click -= eventHandler;
        this._btnCancel = value;
        Button btnCancel2 = this._btnCancel;
        if (btnCancel2 == null)
          return;
        btnCancel2.Click += eventHandler;
      }
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual PictureBox picPlanner
    {
      get
      {
        return this._picPlanner;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.picPlanner_MouseUp);
        PictureBox picPlanner1 = this._picPlanner;
        if (picPlanner1 != null)
          picPlanner1.MouseUp -= mouseEventHandler;
        this._picPlanner = value;
        PictureBox picPlanner2 = this._picPlanner;
        if (picPlanner2 == null)
          return;
        picPlanner2.MouseUp += mouseEventHandler;
      }
    }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Pabo.Calendar.MonthCalendar calComplexVisit
    {
      get
      {
        return this._calComplexVisit;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MonthChangedEventHandler changedEventHandler = new MonthChangedEventHandler(this.DtpComplexVisit_MonthChanged);
        Pabo.Calendar.MonthCalendar calComplexVisit1 = this._calComplexVisit;
        if (calComplexVisit1 != null)
          calComplexVisit1.MonthChanged -= changedEventHandler;
        this._calComplexVisit = value;
        Pabo.Calendar.MonthCalendar calComplexVisit2 = this._calComplexVisit;
        if (calComplexVisit2 == null)
          return;
        calComplexVisit2.MonthChanged += changedEventHandler;
      }
    }

    internal virtual GroupBox GroupBox4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSaveComplex
    {
      get
      {
        return this._btnSaveComplex;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.BtnSaveComplex_Click);
        Button btnSaveComplex1 = this._btnSaveComplex;
        if (btnSaveComplex1 != null)
          btnSaveComplex1.Click -= eventHandler;
        this._btnSaveComplex = value;
        Button btnSaveComplex2 = this._btnSaveComplex;
        if (btnSaveComplex2 == null)
          return;
        btnSaveComplex2.Click += eventHandler;
      }
    }

    internal virtual Button btnCancel2
    {
      get
      {
        return this._btnCancel2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCancel_Click);
        Button btnCancel2_1 = this._btnCancel2;
        if (btnCancel2_1 != null)
          btnCancel2_1.Click -= eventHandler;
        this._btnCancel2 = value;
        Button btnCancel2_2 = this._btnCancel2;
        if (btnCancel2_2 == null)
          return;
        btnCancel2_2.Click += eventHandler;
      }
    }

    internal virtual Button btnAdditionalVisit
    {
      get
      {
        return this._btnAdditionalVisit;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAdditionalVisit_Click);
        Button btnAdditionalVisit1 = this._btnAdditionalVisit;
        if (btnAdditionalVisit1 != null)
          btnAdditionalVisit1.Click -= eventHandler;
        this._btnAdditionalVisit = value;
        Button btnAdditionalVisit2 = this._btnAdditionalVisit;
        if (btnAdditionalVisit2 == null)
          return;
        btnAdditionalVisit2.Click += eventHandler;
      }
    }

    internal virtual TableLayoutPanel pnlLayout { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel Panel9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolTip ttComplexVisits { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.tabCtrlVisits = new TabControl();
      this.tabStandardVisit = new TabPage();
      this.GroupBox2 = new GroupBox();
      this.cboAppointment = new ComboBox();
      this.Label12 = new Label();
      this.lblAMPM = new Label();
      this.Label11 = new Label();
      this.Label10 = new Label();
      this.txtEndTimeMinutes = new TextBox();
      this.txtEndTimeHours = new TextBox();
      this.txtStartTimeMinutes = new TextBox();
      this.txtStartTimeHours = new TextBox();
      this.Label4 = new Label();
      this.Label3 = new Label();
      this.Label2 = new Label();
      this.Label1 = new Label();
      this.btnSave = new Button();
      this.btnCancel = new Button();
      this.GroupBox1 = new GroupBox();
      this.Label9 = new Label();
      this.Label6 = new Label();
      this.Label5 = new Label();
      this.Panel2 = new Panel();
      this.Panel1 = new Panel();
      this.picPlanner = new PictureBox();
      this.Label7 = new Label();
      this.Panel3 = new Panel();
      this.Panel4 = new Panel();
      this.Label8 = new Label();
      this.tabComplexVisit = new TabPage();
      this.GroupBox3 = new GroupBox();
      this.calComplexVisit = new Pabo.Calendar.MonthCalendar();
      this.Label14 = new Label();
      this.Panel5 = new Panel();
      this.Label16 = new Label();
      this.Panel7 = new Panel();
      this.Panel8 = new Panel();
      this.Label17 = new Label();
      this.btnSaveComplex = new Button();
      this.btnCancel2 = new Button();
      this.GroupBox4 = new GroupBox();
      this.btnAdditionalVisit = new Button();
      this.Panel9 = new Panel();
      this.pnlLayout = new TableLayoutPanel();
      this.Label13 = new Label();
      this.ttComplexVisits = new ToolTip(this.components);
      this.tabCtrlVisits.SuspendLayout();
      this.tabStandardVisit.SuspendLayout();
      this.GroupBox2.SuspendLayout();
      this.GroupBox1.SuspendLayout();
      ((ISupportInitialize) this.picPlanner).BeginInit();
      this.tabComplexVisit.SuspendLayout();
      this.GroupBox3.SuspendLayout();
      this.GroupBox4.SuspendLayout();
      this.Panel9.SuspendLayout();
      this.SuspendLayout();
      this.tabCtrlVisits.Controls.Add((Control) this.tabStandardVisit);
      this.tabCtrlVisits.Controls.Add((Control) this.tabComplexVisit);
      this.tabCtrlVisits.Location = new System.Drawing.Point(0, 33);
      this.tabCtrlVisits.Name = "tabCtrlVisits";
      this.tabCtrlVisits.SelectedIndex = 0;
      this.tabCtrlVisits.Size = new Size(569, 450);
      this.tabCtrlVisits.TabIndex = 2;
      this.tabStandardVisit.Controls.Add((Control) this.GroupBox2);
      this.tabStandardVisit.Controls.Add((Control) this.GroupBox1);
      this.tabStandardVisit.Location = new System.Drawing.Point(4, 22);
      this.tabStandardVisit.Name = "tabStandardVisit";
      this.tabStandardVisit.Padding = new Padding(3);
      this.tabStandardVisit.Size = new Size(561, 424);
      this.tabStandardVisit.TabIndex = 0;
      this.tabStandardVisit.Text = "Standard Visit";
      this.tabStandardVisit.UseVisualStyleBackColor = true;
      this.GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox2.Controls.Add((Control) this.cboAppointment);
      this.GroupBox2.Controls.Add((Control) this.Label12);
      this.GroupBox2.Controls.Add((Control) this.lblAMPM);
      this.GroupBox2.Controls.Add((Control) this.Label11);
      this.GroupBox2.Controls.Add((Control) this.Label10);
      this.GroupBox2.Controls.Add((Control) this.txtEndTimeMinutes);
      this.GroupBox2.Controls.Add((Control) this.txtEndTimeHours);
      this.GroupBox2.Controls.Add((Control) this.txtStartTimeMinutes);
      this.GroupBox2.Controls.Add((Control) this.txtStartTimeHours);
      this.GroupBox2.Controls.Add((Control) this.Label4);
      this.GroupBox2.Controls.Add((Control) this.Label3);
      this.GroupBox2.Controls.Add((Control) this.Label2);
      this.GroupBox2.Controls.Add((Control) this.Label1);
      this.GroupBox2.Controls.Add((Control) this.btnSave);
      this.GroupBox2.Controls.Add((Control) this.btnCancel);
      this.GroupBox2.Location = new System.Drawing.Point(3, 298);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(552, 120);
      this.GroupBox2.TabIndex = 3;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Schedule Visit For";
      this.cboAppointment.FormattingEnabled = true;
      this.cboAppointment.Location = new System.Drawing.Point(150, 86);
      this.cboAppointment.Name = "cboAppointment";
      this.cboAppointment.Size = new Size(210, 21);
      this.cboAppointment.TabIndex = 59;
      this.Label12.Location = new System.Drawing.Point(10, 89);
      this.Label12.Name = "Label12";
      this.Label12.Size = new Size(134, 18);
      this.Label12.TabIndex = 58;
      this.Label12.Text = "Appointment Type:";
      this.lblAMPM.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblAMPM.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblAMPM.ForeColor = Color.Red;
      this.lblAMPM.Location = new System.Drawing.Point(410, 35);
      this.lblAMPM.Name = "lblAMPM";
      this.lblAMPM.Size = new Size(136, 17);
      this.lblAMPM.TabIndex = 57;
      this.lblAMPM.TextAlign = ContentAlignment.MiddleRight;
      this.Label11.Location = new System.Drawing.Point(8, 48);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(176, 17);
      this.Label11.TabIndex = 56;
      this.Label11.Text = "Blank assumes \"start of day\"";
      this.Label10.Location = new System.Drawing.Point(200, 48);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(168, 17);
      this.Label10.TabIndex = 55;
      this.Label10.Text = "Blank assumes \"end of day\"";
      this.txtEndTimeMinutes.Location = new System.Drawing.Point(336, 21);
      this.txtEndTimeMinutes.Name = "txtEndTimeMinutes";
      this.txtEndTimeMinutes.Size = new Size(24, 21);
      this.txtEndTimeMinutes.TabIndex = 3;
      this.txtEndTimeHours.Location = new System.Drawing.Point(288, 21);
      this.txtEndTimeHours.Name = "txtEndTimeHours";
      this.txtEndTimeHours.Size = new Size(24, 21);
      this.txtEndTimeHours.TabIndex = 3;
      this.txtStartTimeMinutes.Location = new System.Drawing.Point(150, 21);
      this.txtStartTimeMinutes.Name = "txtStartTimeMinutes";
      this.txtStartTimeMinutes.Size = new Size(24, 21);
      this.txtStartTimeMinutes.TabIndex = 2;
      this.txtStartTimeHours.Location = new System.Drawing.Point(104, 21);
      this.txtStartTimeHours.Name = "txtStartTimeHours";
      this.txtStartTimeHours.Size = new Size(24, 21);
      this.txtStartTimeHours.TabIndex = 1;
      this.Label4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label4.Location = new System.Drawing.Point(320, 24);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(8, 17);
      this.Label4.TabIndex = 4;
      this.Label4.Text = ":";
      this.Label3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label3.Location = new System.Drawing.Point(136, 24);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(8, 17);
      this.Label3.TabIndex = 54;
      this.Label3.Text = ":";
      this.Label2.Location = new System.Drawing.Point(200, 24);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(64, 17);
      this.Label2.TabIndex = 1;
      this.Label2.Text = "End Time";
      this.Label1.Location = new System.Drawing.Point(8, 24);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(77, 17);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Start Time";
      this.btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSave.Location = new System.Drawing.Point(396, 86);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(64, 23);
      this.btnSave.TabIndex = 4;
      this.btnSave.Text = "Ok";
      this.btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnCancel.Location = new System.Drawing.Point(482, 86);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(64, 23);
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "Cancel";
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.Label9);
      this.GroupBox1.Controls.Add((Control) this.Label6);
      this.GroupBox1.Controls.Add((Control) this.Label5);
      this.GroupBox1.Controls.Add((Control) this.Panel2);
      this.GroupBox1.Controls.Add((Control) this.Panel1);
      this.GroupBox1.Controls.Add((Control) this.picPlanner);
      this.GroupBox1.Controls.Add((Control) this.Label7);
      this.GroupBox1.Controls.Add((Control) this.Panel3);
      this.GroupBox1.Controls.Add((Control) this.Panel4);
      this.GroupBox1.Controls.Add((Control) this.Label8);
      this.GroupBox1.Location = new System.Drawing.Point(3, 3);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(555, 289);
      this.GroupBox1.TabIndex = 2;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Planner";
      this.Label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.Label9.Location = new System.Drawing.Point(8, 217);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(533, 16);
      this.Label9.TabIndex = 16;
      this.Label9.Text = "Hold Shift and LEFT click period for START time or RIGHT click period for END time";
      this.Label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label6.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label6.Location = new System.Drawing.Point(240, 265);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(248, 16);
      this.Label6.TabIndex = 15;
      this.Label6.Text = "NOT OK - Job or Absence overlap";
      this.Label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label5.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label5.Location = new System.Drawing.Point(32, 265);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(184, 16);
      this.Label5.TabIndex = 14;
      this.Label5.Text = "OK - No overlap";
      this.Panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Panel2.BackColor = Color.Salmon;
      this.Panel2.Location = new System.Drawing.Point(216, 265);
      this.Panel2.Name = "Panel2";
      this.Panel2.Size = new Size(16, 16);
      this.Panel2.TabIndex = 13;
      this.Panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Panel1.BackColor = Color.LightGreen;
      this.Panel1.Location = new System.Drawing.Point(8, 265);
      this.Panel1.Name = "Panel1";
      this.Panel1.Size = new Size(16, 16);
      this.Panel1.TabIndex = 12;
      this.picPlanner.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.picPlanner.BackColor = Color.FromArgb(224, 224, 224);
      this.picPlanner.BorderStyle = BorderStyle.FixedSingle;
      this.picPlanner.Location = new System.Drawing.Point(8, 23);
      this.picPlanner.Name = "picPlanner";
      this.picPlanner.Size = new Size(541, 181);
      this.picPlanner.TabIndex = 0;
      this.picPlanner.TabStop = false;
      this.Label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label7.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label7.Location = new System.Drawing.Point(32, 241);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(168, 16);
      this.Label7.TabIndex = 11;
      this.Label7.Text = "Booked Schedule Period";
      this.Panel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Panel3.BackColor = Color.LightSteelBlue;
      this.Panel3.Location = new System.Drawing.Point(8, 241);
      this.Panel3.Name = "Panel3";
      this.Panel3.Size = new Size(16, 16);
      this.Panel3.TabIndex = 9;
      this.Panel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Panel4.BackColor = Color.FromArgb(224, 224, 224);
      this.Panel4.Location = new System.Drawing.Point(216, 241);
      this.Panel4.Name = "Panel4";
      this.Panel4.Size = new Size(16, 16);
      this.Panel4.TabIndex = 8;
      this.Label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label8.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label8.Location = new System.Drawing.Point(240, 241);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(176, 16);
      this.Label8.TabIndex = 10;
      this.Label8.Text = "Free Schedule Period";
      this.tabComplexVisit.Controls.Add((Control) this.GroupBox3);
      this.tabComplexVisit.Controls.Add((Control) this.btnSaveComplex);
      this.tabComplexVisit.Controls.Add((Control) this.btnCancel2);
      this.tabComplexVisit.Controls.Add((Control) this.GroupBox4);
      this.tabComplexVisit.Location = new System.Drawing.Point(4, 22);
      this.tabComplexVisit.Name = "tabComplexVisit";
      this.tabComplexVisit.Padding = new Padding(3);
      this.tabComplexVisit.Size = new Size(561, 424);
      this.tabComplexVisit.TabIndex = 1;
      this.tabComplexVisit.Text = "Complex Visit";
      this.tabComplexVisit.UseVisualStyleBackColor = true;
      this.GroupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox3.Controls.Add((Control) this.calComplexVisit);
      this.GroupBox3.Controls.Add((Control) this.Label14);
      this.GroupBox3.Controls.Add((Control) this.Panel5);
      this.GroupBox3.Controls.Add((Control) this.Label16);
      this.GroupBox3.Controls.Add((Control) this.Panel7);
      this.GroupBox3.Controls.Add((Control) this.Panel8);
      this.GroupBox3.Controls.Add((Control) this.Label17);
      this.GroupBox3.Location = new System.Drawing.Point(3, 3);
      this.GroupBox3.Name = "GroupBox3";
      this.GroupBox3.Size = new Size(555, 228);
      this.GroupBox3.TabIndex = 13;
      this.GroupBox3.TabStop = false;
      this.GroupBox3.Text = "Planner";
      this.calComplexVisit.ActiveMonth.Month = 1;
      this.calComplexVisit.ActiveMonth.Year = 2018;
      this.calComplexVisit.BorderColor = Color.FromArgb(197, 198, 214);
      this.calComplexVisit.Culture = new CultureInfo("en-GB");
      this.calComplexVisit.ExtendedSelectionKey = mcExtendedSelectionKey.Shift;
      this.calComplexVisit.Footer.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
      this.calComplexVisit.Header.BackColor1 = Color.Blue;
      this.calComplexVisit.Header.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
      this.calComplexVisit.Header.TextColor = Color.White;
      this.calComplexVisit.ImageList = (ImageList) null;
      this.calComplexVisit.Location = new System.Drawing.Point(7, 23);
      this.calComplexVisit.MaxDate = new DateTime(2027, 5, 10, 12, 28, 13, 983);
      this.calComplexVisit.MinDate = new DateTime(2018, 1, 11, 0, 0, 0, 0);
      this.calComplexVisit.Month.BackgroundImage = (Image) null;
      this.calComplexVisit.Month.Colors.Focus.BackColor = Color.FromArgb(211, 213, 224);
      this.calComplexVisit.Month.Colors.Focus.Border = Color.FromArgb(197, 198, 214);
      this.calComplexVisit.Month.Colors.Selected.BackColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.calComplexVisit.Month.Colors.Selected.Border = Color.Black;
      this.calComplexVisit.Month.Colors.Trailing.BackColor1 = Color.WhiteSmoke;
      this.calComplexVisit.Month.Colors.Trailing.Date = Color.DimGray;
      this.calComplexVisit.Month.Colors.Trailing.Text = Color.Transparent;
      this.calComplexVisit.Month.Colors.Weekend.BackColor1 = Color.DarkOrange;
      this.calComplexVisit.Month.DateFont = new Font("Microsoft Sans Serif", 8.25f);
      this.calComplexVisit.Month.TextFont = new Font("Microsoft Sans Serif", 8.25f);
      this.calComplexVisit.Name = "calComplexVisit";
      this.calComplexVisit.SelectionMode = mcSelectionMode.None;
      this.calComplexVisit.ShowFooter = false;
      this.calComplexVisit.Size = new Size(541, 168);
      this.calComplexVisit.TabIndex = 16;
      this.calComplexVisit.Weekdays.Font = new Font("Microsoft Sans Serif", 8.25f);
      this.calComplexVisit.Weekdays.TextColor = Color.FromArgb(177, 179, 200);
      this.calComplexVisit.Weeknumbers.Font = new Font("Microsoft Sans Serif", 8.25f);
      this.calComplexVisit.Weeknumbers.TextColor = Color.FromArgb(177, 179, 200);
      this.Label14.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label14.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label14.Location = new System.Drawing.Point(288, 199);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(248, 16);
      this.Label14.TabIndex = 15;
      this.Label14.Text = "NOT OK - Job or Absence overlap";
      this.Panel5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Panel5.BackColor = Color.Salmon;
      this.Panel5.Location = new System.Drawing.Point(264, 199);
      this.Panel5.Name = "Panel5";
      this.Panel5.Size = new Size(16, 16);
      this.Panel5.TabIndex = 13;
      this.Label16.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label16.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label16.Location = new System.Drawing.Point(40, 199);
      this.Label16.Name = "Label16";
      this.Label16.Size = new Size(107, 14);
      this.Label16.TabIndex = 11;
      this.Label16.Text = "Selected Dates";
      this.Panel7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Panel7.BackColor = Color.LightSteelBlue;
      this.Panel7.Location = new System.Drawing.Point(17, 197);
      this.Panel7.Name = "Panel7";
      this.Panel7.Size = new Size(16, 16);
      this.Panel7.TabIndex = 9;
      this.Panel8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Panel8.BackColor = Color.DarkOrange;
      this.Panel8.Location = new System.Drawing.Point(160, 199);
      this.Panel8.Name = "Panel8";
      this.Panel8.Size = new Size(16, 16);
      this.Panel8.TabIndex = 8;
      this.Label17.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Label17.Font = new Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label17.Location = new System.Drawing.Point(184, 199);
      this.Label17.Name = "Label17";
      this.Label17.Size = new Size(71, 16);
      this.Label17.TabIndex = 10;
      this.Label17.Text = "Weekend";
      this.btnSaveComplex.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSaveComplex.Location = new System.Drawing.Point(397, 389);
      this.btnSaveComplex.Name = "btnSaveComplex";
      this.btnSaveComplex.Size = new Size(64, 23);
      this.btnSaveComplex.TabIndex = 4;
      this.btnSaveComplex.Text = "Ok";
      this.btnCancel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnCancel2.Location = new System.Drawing.Point(490, 389);
      this.btnCancel2.Name = "btnCancel2";
      this.btnCancel2.Size = new Size(64, 23);
      this.btnCancel2.TabIndex = 5;
      this.btnCancel2.Text = "Cancel";
      this.GroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox4.Controls.Add((Control) this.btnAdditionalVisit);
      this.GroupBox4.Controls.Add((Control) this.Panel9);
      this.GroupBox4.Location = new System.Drawing.Point(3, 237);
      this.GroupBox4.Name = "GroupBox4";
      this.GroupBox4.Size = new Size(555, 138);
      this.GroupBox4.TabIndex = 17;
      this.GroupBox4.TabStop = false;
      this.GroupBox4.Text = "Schedule Visit For";
      this.btnAdditionalVisit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAdditionalVisit.Location = new System.Drawing.Point(505, 20);
      this.btnAdditionalVisit.Name = "btnAdditionalVisit";
      this.btnAdditionalVisit.Size = new Size(20, 22);
      this.btnAdditionalVisit.TabIndex = 66;
      this.btnAdditionalVisit.Tag = (object) "";
      this.btnAdditionalVisit.Text = "+";
      this.ttComplexVisits.SetToolTip((Control) this.btnAdditionalVisit, "Add new visit");
      this.Panel9.AutoScroll = true;
      this.Panel9.Controls.Add((Control) this.pnlLayout);
      this.Panel9.Controls.Add((Control) this.Label13);
      this.Panel9.Dock = DockStyle.Fill;
      this.Panel9.Location = new System.Drawing.Point(3, 17);
      this.Panel9.Name = "Panel9";
      this.Panel9.Size = new Size(549, 118);
      this.Panel9.TabIndex = 67;
      this.pnlLayout.AutoSize = true;
      this.pnlLayout.ColumnCount = 6;
      this.pnlLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.85714f));
      this.pnlLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72.14286f));
      this.pnlLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 37f));
      this.pnlLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 108f));
      this.pnlLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 45f));
      this.pnlLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 47f));
      this.pnlLayout.Location = new System.Drawing.Point(12, 28);
      this.pnlLayout.Name = "pnlLayout";
      this.pnlLayout.RowCount = 1;
      this.pnlLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.pnlLayout.Size = new Size(371, 30);
      this.pnlLayout.TabIndex = 3;
      this.Label13.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.Label13.Location = new System.Drawing.Point(11, 4);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(421, 21);
      this.Label13.TabIndex = 17;
      this.Label13.Text = "CLICK + TO ADD VISIT";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(570, 487);
      this.ControlBox = false;
      this.Controls.Add((Control) this.tabCtrlVisits);
      this.MaximizeBox = false;
      this.MaximumSize = new Size(1000, 1000);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(560, 450);
      this.Name = nameof (frmVisit);
      this.Text = "Schedule Visit";
      this.Controls.SetChildIndex((Control) this.tabCtrlVisits, 0);
      this.tabCtrlVisits.ResumeLayout(false);
      this.tabStandardVisit.ResumeLayout(false);
      this.GroupBox2.ResumeLayout(false);
      this.GroupBox2.PerformLayout();
      this.GroupBox1.ResumeLayout(false);
      ((ISupportInitialize) this.picPlanner).EndInit();
      this.tabComplexVisit.ResumeLayout(false);
      this.GroupBox3.ResumeLayout(false);
      this.GroupBox4.ResumeLayout(false);
      this.Panel9.ResumeLayout(false);
      this.Panel9.PerformLayout();
      this.ResumeLayout(false);
    }

    public DataTable DtTimeSlot
    {
      get
      {
        return this.timeSlotDt;
      }
      set
      {
        this.timeSlotDt = value;
      }
    }

    public string engineerID
    {
      get
      {
        return this._engineerID;
      }
      set
      {
        this._engineerID = value;
      }
    }

    public string AMPM
    {
      get
      {
        return this._AMPM;
      }
      set
      {
        this._AMPM = value;
        string ampm = this.AMPM;
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(ampm, "AM", false) != 0)
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(ampm, "PM", false) == 0)
            this.lblAMPM.Text = "Due for PM arrival";
          else
            this.lblAMPM.Text = "";
        }
        else
          this.lblAMPM.Text = "Due for AM arrival";
      }
    }

    public DateTime theSelectedDay
    {
      get
      {
        return this._theSelectedDay;
      }
      set
      {
        this._theSelectedDay = value;
      }
    }

    public DateTime StartDate
    {
      get
      {
        return this._StartDate;
      }
      set
      {
        this._StartDate = value;
      }
    }

    public DateTime EndDate
    {
      get
      {
        return this._EndDate;
      }
      set
      {
        this._EndDate = value;
      }
    }

    public int AppointmentType
    {
      get
      {
        return this._AppointmentType;
      }
      set
      {
        this._AppointmentType = value;
      }
    }

    private int SORMinutes
    {
      get
      {
        return this._SORMinutes;
      }
      set
      {
        this._SORMinutes = value;
      }
    }

    public bool IsFormDisposed
    {
      get
      {
        return this.IsDisposed;
      }
    }

    public PictureBox ThePlanner
    {
      get
      {
        return this.picPlanner;
      }
    }

    public IntPtr TheHandle
    {
      get
      {
        return this.Handle;
      }
    }

    public string MyName
    {
      get
      {
        return nameof (frmVisit);
      }
    }

    public string selectedDay()
    {
      return Conversions.ToString(this.theSelectedDay);
    }

    public List<List<DateTime>> VisitsList
    {
      get
      {
        return this._visitsList;
      }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      Settings settings = App.DB.Manager.Get();
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboAppointment)) < 1.0)
      {
        int num1 = (int) MessageBox.Show("You must select an Appointment Type!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
      }
      else
      {
        DateTime dateTime;
        DateTime theSelectedDay1;
        if (this.txtStartTimeHours.Text.Trim().Length == 0 & this.txtStartTimeMinutes.Text.Trim().Length == 0)
        {
          ref DateTime local = ref dateTime;
          theSelectedDay1 = this.theSelectedDay;
          int year = theSelectedDay1.Year;
          theSelectedDay1 = this.theSelectedDay;
          int month = theSelectedDay1.Month;
          theSelectedDay1 = this.theSelectedDay;
          int day = theSelectedDay1.Day;
          int integer1 = Conversions.ToInteger(settings.WorkingHoursStart.Substring(0, 2));
          int integer2 = Conversions.ToInteger(settings.WorkingHoursStart.Substring(3, 2));
          local = new DateTime(year, month, day, integer1, integer2, 0);
        }
        else
        {
          if (!Versioned.IsNumeric((object) this.txtStartTimeHours.Text) || Conversions.ToDouble(this.txtStartTimeHours.Text) < 0.0 || Conversions.ToDouble(this.txtStartTimeHours.Text) > 23.0 || (!Versioned.IsNumeric((object) this.txtStartTimeMinutes.Text) || Conversions.ToDouble(this.txtStartTimeMinutes.Text) < 0.0 || Conversions.ToDouble(this.txtStartTimeMinutes.Text) > 59.0))
          {
            int num2 = (int) MessageBox.Show("Start time is not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
            return;
          }
          ref DateTime local = ref dateTime;
          DateTime theSelectedDay2 = this.theSelectedDay;
          int year = theSelectedDay2.Year;
          theSelectedDay2 = this.theSelectedDay;
          int month = theSelectedDay2.Month;
          int day = this.theSelectedDay.Day;
          int integer1 = Conversions.ToInteger(this.txtStartTimeHours.Text);
          int integer2 = Conversions.ToInteger(this.txtStartTimeMinutes.Text);
          local = new DateTime(year, month, day, integer1, integer2, 0);
        }
        DateTime t2;
        if (this.txtEndTimeHours.Text.Trim().Length == 0 & this.txtEndTimeMinutes.Text.Trim().Length == 0)
        {
          ref DateTime local = ref t2;
          theSelectedDay1 = this.theSelectedDay;
          int year = theSelectedDay1.Year;
          theSelectedDay1 = this.theSelectedDay;
          int month = theSelectedDay1.Month;
          theSelectedDay1 = this.theSelectedDay;
          int day = theSelectedDay1.Day;
          int integer1 = Conversions.ToInteger(settings.WorkingHoursEnd.Substring(0, 2));
          int integer2 = Conversions.ToInteger(settings.WorkingHoursEnd.Substring(3, 2));
          local = new DateTime(year, month, day, integer1, integer2, 0);
        }
        else
        {
          if (!Versioned.IsNumeric((object) this.txtEndTimeHours.Text) || Conversions.ToDouble(this.txtEndTimeHours.Text) < 0.0 || Conversions.ToDouble(this.txtEndTimeHours.Text) > 23.0 || (!Versioned.IsNumeric((object) this.txtEndTimeMinutes.Text) || Conversions.ToDouble(this.txtEndTimeMinutes.Text) < 0.0 || Conversions.ToDouble(this.txtEndTimeMinutes.Text) > 59.0))
          {
            int num2 = (int) MessageBox.Show("End time is not valid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
            return;
          }
          ref DateTime local = ref t2;
          theSelectedDay1 = this.theSelectedDay;
          int year = theSelectedDay1.Year;
          theSelectedDay1 = this.theSelectedDay;
          int month = theSelectedDay1.Month;
          theSelectedDay1 = this.theSelectedDay;
          int day = theSelectedDay1.Day;
          int integer1 = Conversions.ToInteger(this.txtEndTimeHours.Text);
          int integer2 = Conversions.ToInteger(this.txtEndTimeMinutes.Text);
          local = new DateTime(year, month, day, integer1, integer2, 0);
        }
        if (DateTime.Compare(dateTime, t2) > 0)
        {
          int num3 = (int) MessageBox.Show("End date can not be before start date!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
        }
        else
        {
          if (!this.CheckDateAndContinue(dateTime))
            return;
          this.StartDate = dateTime;
          this.EndDate = t2;
          this.AppointmentType = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboAppointment));
          this.DialogResult = DialogResult.OK;
          if (this.Modal)
            this.Close();
          else
            this.Dispose();
        }
      }
    }

    private bool CheckDateAndContinue(DateTime startTime)
    {
      string ampm = this.AMPM;
      bool flag;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(ampm, "", false) != 0)
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(ampm, "AM", false) != 0)
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(ampm, "PM", false) == 0)
            flag = DateTime.Compare(startTime, new DateTime(startTime.Year, startTime.Month, startTime.Day, 12, 30, 0)) >= 0 || App.ShowMessage("The visit is due for a PM start, (after 12:30).\r\nDo you wish to continue with " + Microsoft.VisualBasic.Strings.Format((object) startTime, "HH:mm") + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No && (this.isCopy || true);
        }
        else
          flag = DateTime.Compare(startTime, new DateTime(startTime.Year, startTime.Month, startTime.Day, 12, 30, 0)) <= 0 || App.ShowMessage("The visit is due for an AM start, (before 12:30).\r\nDo you wish to continue with " + Microsoft.VisualBasic.Strings.Format((object) startTime, "HH:mm") + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No && (this.isCopy || true);
      }
      else
        flag = true;
      return flag;
    }

    private Bitmap scheduler_DayTimeSlots_bitmap()
    {
      Bitmap bitmap1;
      try
      {
        if (this.DtTimeSlot != null && this.picPlanner.Height > 0 && this.picPlanner.Width > 0)
        {
          Bitmap bitmap2 = new Bitmap(this.picPlanner.Width, this.picPlanner.Height);
          Graphics graphics = Graphics.FromImage((Image) bitmap2);
          float width = (float) checked (bitmap2.Width - 9) / (float) checked (this.DtTimeSlot.Columns.Count - 1);
          IEnumerator enumerator;
          try
          {
            enumerator = this.DtTimeSlot.Columns.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataColumn current = (DataColumn) enumerator.Current;
              DateTime dateTime1 = DateTime.MinValue;
              DateTime dateTime2 = DateTime.MinValue;
              DateTime dateTime3 = DateTime.MinValue;
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtStartTimeHours.Text, "", false) != 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtStartTimeMinutes.Text, "", false) != 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtEndTimeHours.Text, "", false) != 0 && (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtEndTimeMinutes.Text, "", false) > 0U)
              {
                dateTime1 = Conversions.ToDate(Conversions.ToString(DateAndTime.Now.Date) + " " + current.ColumnName.Substring(1, 2) + ":" + current.ColumnName.Substring(3, 2) + ":00");
                dateTime2 = Conversions.ToDate(Conversions.ToString(DateAndTime.Now.Date) + " " + this.txtStartTimeHours.Text.Trim() + ":" + this.txtStartTimeMinutes.Text.Trim() + ":00");
                dateTime3 = Conversions.ToDate(Conversions.ToString(DateAndTime.Now.Date) + " " + this.txtEndTimeHours.Text.Trim() + ":" + this.txtEndTimeMinutes.Text.Trim() + ":00");
              }
              Color color = Color.WhiteSmoke;
              if (this.DtTimeSlot.Rows.Count > 0 && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.DtTimeSlot.Rows[0][current], (object) 1, false))
              {
                try
                {
                  color = !(DateTime.Compare(dateTime2, dateTime1) <= 0 & DateTime.Compare(dateTime3, dateTime1.AddMinutes((double) App.DB.Manager.Get().TimeSlot)) >= 0) ? Color.LightSteelBlue : Color.Salmon;
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  color = Color.LightSteelBlue;
                  ProjectData.ClearProjectError();
                }
              }
              try
              {
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(color.Name, Color.WhiteSmoke.Name, false) == 0)
                {
                  if (DateTime.Compare(dateTime1, dateTime2) >= 0 & DateTime.Compare(dateTime1, dateTime3) < 0)
                    color = Color.LightGreen;
                }
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
              }
              graphics.FillRectangle((Brush) new SolidBrush(color), new RectangleF(width * (float) this.DtTimeSlot.Columns.IndexOf(current), 0.0f, width, (float) checked (this.picPlanner.Height - 15)));
              string str;
              if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current.ColumnName.Substring(1, 2), str, false) > 0U)
              {
                str = current.ColumnName.Substring(1, 2);
                graphics.DrawLine(new Pen(Color.RoyalBlue), width * (float) this.DtTimeSlot.Columns.IndexOf(current), 0.0f, width * (float) this.DtTimeSlot.Columns.IndexOf(current), (float) checked (this.picPlanner.Height - 12));
                Font font = new Font(this.Font.Name, 6f, FontStyle.Regular);
                graphics.DrawString(str, font, (Brush) new SolidBrush(Color.Black), (float) ((double) width * (double) this.DtTimeSlot.Columns.IndexOf(current) - (double) graphics.MeasureString(str, font).Width / 2.0), (float) ((double) this.picPlanner.Height - (double) graphics.MeasureString(str, font).Height - 1.0));
              }
              else
                graphics.DrawLine(new Pen(Color.RoyalBlue), width * (float) this.DtTimeSlot.Columns.IndexOf(current), 0.0f, width * (float) this.DtTimeSlot.Columns.IndexOf(current), (float) checked (this.picPlanner.Height - 13));
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          bitmap1 = bitmap2;
        }
        else
          bitmap1 = (Bitmap) null;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        bitmap1 = (Bitmap) null;
        ProjectData.ClearProjectError();
      }
      return bitmap1;
    }

    private void frmVisit_SizeChanged(object sender, EventArgs e)
    {
      this.picPlanner.Image = (Image) this.scheduler_DayTimeSlots_bitmap();
    }

    private void frmVisit_Load(object sender, EventArgs e)
    {
      this.LoadForm((Form) this);
      this.ActiveControl = (Control) this.txtStartTimeHours;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void txtEndTimeHours_TextChanged(object sender, EventArgs e)
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
      else if (textBox.Text.Length == 0 && checked (Array.IndexOf<TextBox>(array, textBox) - 1) >= 0)
      {
        array[checked (Array.IndexOf<TextBox>(array, textBox) - 1)].Focus();
        array[checked (Array.IndexOf<TextBox>(array, textBox) - 1)].SelectAll();
      }
      if (this.SORMinutes > 0)
      {
        if ((Microsoft.VisualBasic.CompilerServices.Operators.CompareString(textBox.Name, "txtStartTimeMinutes", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(textBox.Name, "txtStartTimeHours", false) == 0) & this.txtStartTimeMinutes.Text.Length >= 2 & this.txtStartTimeHours.Text.Length >= 2)
        {
          try
          {
            DateTime dateTime = Conversions.ToDate("01/01/1980 " + this.txtStartTimeHours.Text + ":" + this.txtStartTimeMinutes.Text).AddMinutes((double) this.SORMinutes);
            this.txtEndTimeHours.Text = dateTime.Hour.ToString().Length != 1 ? Conversions.ToString(dateTime.Hour) : "0" + Conversions.ToString(dateTime.Hour);
            this.txtEndTimeMinutes.Text = dateTime.Minute.ToString().Length != 1 ? Conversions.ToString(dateTime.Minute) : "0" + Conversions.ToString(dateTime.Minute);
            this.btnSave.Focus();
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            ProjectData.ClearProjectError();
          }
        }
      }
      this.picPlanner.Image = (Image) this.scheduler_DayTimeSlots_bitmap();
    }

    private void picPlanner_MouseUp(object sender, MouseEventArgs e)
    {
      float num = (float) checked (new Bitmap(this.picPlanner.Width, this.picPlanner.Height).Width - 9) / (float) checked (this.DtTimeSlot.Columns.Count - 1);
      if (e.Button == MouseButtons.Left)
      {
        int index = checked ((int) Math.Ceiling(unchecked ((double) e.X / (double) num)) - 1);
        if (index < 0)
          index = 0;
        if (index > checked (this.DtTimeSlot.Columns.Count - 1))
          index = checked (this.DtTimeSlot.Columns.Count - 1);
        string columnName = this.DtTimeSlot.Columns[index].ColumnName;
        string str1 = columnName.Substring(1, 2);
        string str2 = columnName.Substring(3, 2);
        this.txtStartTimeHours.Text = str1;
        this.txtStartTimeMinutes.Text = str2;
      }
      else
      {
        if (e.Button != MouseButtons.Right)
          return;
        int index = checked ((int) Math.Ceiling(unchecked ((double) e.X / (double) num)));
        if (index < 0)
          index = 0;
        if (index > checked (this.DtTimeSlot.Columns.Count - 1))
          index = checked (this.DtTimeSlot.Columns.Count - 1);
        string columnName = this.DtTimeSlot.Columns[index].ColumnName;
        string str1 = columnName.Substring(1, 2);
        string str2 = columnName.Substring(3, 2);
        this.txtEndTimeHours.Text = str1;
        this.txtEndTimeMinutes.Text = str2;
      }
    }

    private void InitComplexVisits()
    {
      this.calComplexVisit.MinDate = DateTime.Now.AddMonths(-1);
      this.calComplexVisit.SelectDate(DateTime.Today);
      this.calComplexVisit.ActiveMonth.Month = DateTime.Now.Month;
      this.calComplexVisit.ActiveMonth.Year = DateTime.Now.Year;
      this.calComplexVisit.ExtendedSelectionKey = (mcExtendedSelectionKey) 17;
      this.UpdateEngineerSchedule();
    }

    private void UpdateEngineerSchedule()
    {
      DateTime Start = new DateTime(this.calComplexVisit.ActiveMonth.Year, this.calComplexVisit.ActiveMonth.Month, 1);
      DateTime Endin = Start.AddMonths(1);
      DataTable summaryNew = App.DB.Scheduler.getSummaryNEW(this.engineerID, Start, Endin);
      if (summaryNew == null)
        return;
      int num1 = 0;
      IEnumerator enumerator;
      try
      {
        enumerator = summaryNew.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          int num2 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["workCount"]));
          int num3 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["AbsenceColumn"]));
          DateTime dt = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["dayDate"]));
          if (num2 > 0 | num3 > 0)
          {
            dt = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
            if (this.calComplexVisit.GetDateInfo(dt).Length <= 0)
              this.calComplexVisit.AddDateInfo(new DateItem()
              {
                Date = dt,
                BackColor1 = Color.Salmon
              });
          }
          checked { ++num1; }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private bool IsEngineerWorkingOrAbsent(DateTime startDate, DateTime endDate)
    {
      bool flag = false;
      DataTable summaryNew = App.DB.Scheduler.getSummaryNEW(this.engineerID, startDate, endDate);
      IEnumerator enumerator;
      if (summaryNew != null)
      {
        try
        {
          enumerator = summaryNew.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["workCount"])) > 0 | Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["AbsenceColumn"])) > 0)
              flag = true;
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
      return flag;
    }

    private void btnAddVisit_Click(object sender, EventArgs e)
    {
      Button button = (Button) sender;
      int index1 = this.btnAddVisits.IndexOf(button);
      DateTimePicker dateTimePicker1 = this.dtpMulitpleVisitsStart[index1];
      DateTimePicker dateTimePicker2 = this.dtpMulitpleVisitsEnd[index1];
      DateTime startDate = dateTimePicker1.Value;
      DateTime dateTime1 = dateTimePicker2.Value;
      if (!this.ValidateSelection(startDate, dateTime1))
      {
        int num1 = (int) App.ShowMessage("Dates selected overlap other dates, please check your selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        if (this.IsEngineerWorkingOrAbsent(startDate, dateTime1))
        {
          int num2 = (int) App.ShowMessage("Engineer might be unavailable on the dates selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        DateTime dateTime2 = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0);
        Settings settings = App.DB.Manager.Get();
        this._visitsList.Add(new List<DateTime>());
        this._visitsList[index1].Add(new DateTime(startDate.Year, startDate.Month, startDate.Day, Conversions.ToInteger(settings.WorkingHoursStart.Substring(0, 2)), Conversions.ToInteger(settings.WorkingHoursStart.Substring(3, 2)), 0));
        this._visitsList[index1].Add(new DateTime(dateTime1.Year, dateTime1.Month, dateTime1.Day, Conversions.ToInteger(settings.WorkingHoursEnd.Substring(0, 2)), Conversions.ToInteger(settings.WorkingHoursEnd.Substring(3, 2)), 0));
        for (; DateTime.Compare(dateTime2, dateTime1) <= 0; dateTime2 = dateTime2.AddDays(1.0))
        {
          DateItem[] dateInfo = this.calComplexVisit.GetDateInfo(dateTime2);
          if (dateInfo.Length > 0)
          {
            DateItem[] dateItemArray = dateInfo;
            int index2 = 0;
            while (index2 < dateItemArray.Length)
            {
              DateItem info = dateItemArray[index2];
              info.BackColor1 = Color.LightSteelBlue;
              this.calComplexVisit.AddDateInfo(info);
              checked { ++index2; }
            }
          }
          else
            this.calComplexVisit.AddDateInfo(new DateItem()
            {
              Date = dateTime2,
              BackColor1 = Color.LightSteelBlue
            });
        }
        dateTimePicker1.Enabled = false;
        dateTimePicker2.Enabled = false;
        button.Enabled = false;
      }
    }

    private bool ValidateSelection(DateTime startDate, DateTime endDate)
    {
      bool Expression = false;
      try
      {
        foreach (List<DateTime> visits in this._visitsList)
        {
          if (!Expression)
            Expression = DateTime.Compare(visits[0], endDate) <= 0 & DateTime.Compare(startDate, visits[1]) <= 0;
        }
      }
      finally
      {
        List<List<DateTime>>.Enumerator enumerator;
        enumerator.Dispose();
      }
      return Conversions.ToBoolean(Interaction.IIf(Expression, (object) false, (object) true));
    }

    private void DtpComplexVisit_MonthChanged(object sender, MonthChangedEventArgs e)
    {
      this.UpdateEngineerSchedule();
    }

    private void BtnSaveComplex_Click(object sender, EventArgs e)
    {
      if (this._visitsList.Count == 0)
      {
        int num1 = (int) App.ShowMessage("No visits created, please create and save visits to continue", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        try
        {
          foreach (Control control in this.dtpMulitpleVisitsStart)
          {
            if (control.Enabled)
            {
              int num2 = (int) App.ShowMessage("Visits not saved, please save visits to continue", MessageBoxButtons.OK, MessageBoxIcon.Hand);
              return;
            }
          }
        }
        finally
        {
          List<DateTimePicker>.Enumerator enumerator;
          enumerator.Dispose();
        }
        this.mulitpleVisits = true;
        List<List<DateTime>> visitsList = this._visitsList;
        Func<List<DateTime>, DateTime> keySelector1;
        // ISSUE: reference to a compiler-generated field
        if (frmVisit._Closure\u0024__.\u0024I255\u002D0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          keySelector1 = frmVisit._Closure\u0024__.\u0024I255\u002D0;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          frmVisit._Closure\u0024__.\u0024I255\u002D0 = keySelector1 = (Func<List<DateTime>, DateTime>) (i =>
          {
            List<DateTime> source = i;
            Func<DateTime, DateTime> keySelector;
            // ISSUE: reference to a compiler-generated field
            if (frmVisit._Closure\u0024__.\u0024I255\u002D1 != null)
            {
              // ISSUE: reference to a compiler-generated field
              keySelector = frmVisit._Closure\u0024__.\u0024I255\u002D1;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              frmVisit._Closure\u0024__.\u0024I255\u002D1 = keySelector = (Func<DateTime, DateTime>) (x => x.Date);
            }
            return source.OrderBy<DateTime, DateTime>(keySelector).First<DateTime>();
          });
        }
        this._visitsList = visitsList.OrderBy<List<DateTime>, DateTime>(keySelector1).ToList<List<DateTime>>();
        this.AppointmentType = 1;
        int num3 = (int) App.ShowMessage("You have successfully created " + Conversions.ToString(this._visitsList.Count) + " visits", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        this.DialogResult = DialogResult.OK;
        if (this.Modal)
          this.Close();
        else
          this.Dispose();
      }
    }

    private void dtpMultipleStart_ValueChanged(object sender, EventArgs e)
    {
      DateTimePicker dateTimePicker1 = (DateTimePicker) sender;
      DateTimePicker dateTimePicker2 = this.dtpMulitpleVisitsEnd[this.dtpMulitpleVisitsStart.IndexOf(dateTimePicker1)];
      if (DateTime.Compare(dateTimePicker1.Value, dateTimePicker2.Value) <= 0)
        return;
      dateTimePicker2.Value = dateTimePicker1.Value;
    }

    private void dtpMultipleEnd_ValueChanged(object sender, EventArgs e)
    {
      DateTimePicker dateTimePicker1 = (DateTimePicker) sender;
      DateTimePicker dateTimePicker2 = this.dtpMulitpleVisitsStart[this.dtpMulitpleVisitsEnd.IndexOf(dateTimePicker1)];
      if (DateTime.Compare(dateTimePicker1.Value, dateTimePicker2.Value) >= 0)
        return;
      dateTimePicker1.Value = dateTimePicker2.Value;
    }

    private void btnAdditionalVisit_Click(object sender, EventArgs e)
    {
      int row = this.btnRemoveVisits.Count;
      Label label1 = new Label();
      label1.Size = new Size(36, 17);
      label1.Text = "Start";
      label1.Name = "lblStart" + Conversions.ToString(row);
      label1.Anchor = AnchorStyles.None;
      this.lblStarts.Add(label1);
      DateTimePicker dateTimePicker1 = new DateTimePicker();
      dateTimePicker1.Format = DateTimePickerFormat.Short;
      dateTimePicker1.Size = new Size(87, 21);
      dateTimePicker1.Name = "dtpStart" + Conversions.ToString(row);
      dateTimePicker1.Anchor = AnchorStyles.None;
      dateTimePicker1.ValueChanged += new EventHandler(this.dtpMultipleStart_ValueChanged);
      this.dtpMulitpleVisitsStart.Add(dateTimePicker1);
      Label label2 = new Label();
      label2.Size = new Size(36, 17);
      label2.Text = "End";
      label2.Name = "lblEnd" + Conversions.ToString(row);
      label2.Anchor = AnchorStyles.None;
      this.lblEnds.Add(label2);
      DateTimePicker dateTimePicker2 = new DateTimePicker();
      dateTimePicker2.Format = DateTimePickerFormat.Short;
      dateTimePicker2.Size = new Size(87, 21);
      dateTimePicker2.Name = "dtpEnd" + Conversions.ToString(row);
      dateTimePicker2.Anchor = AnchorStyles.None;
      dateTimePicker2.ValueChanged += new EventHandler(this.dtpMultipleEnd_ValueChanged);
      this.dtpMulitpleVisitsEnd.Add(dateTimePicker2);
      Button button1 = new Button();
      button1.ForeColor = Color.Green;
      button1.Name = "btnAddVisit" + row.ToString();
      button1.Size = new Size(20, 22);
      button1.Text = "✓";
      button1.Anchor = AnchorStyles.None;
      button1.FlatStyle = FlatStyle.Standard;
      button1.Click += new EventHandler(this.btnAddVisit_Click);
      this.btnAddVisits.Add(button1);
      Button button2 = new Button();
      button2.ForeColor = Color.Red;
      button2.Name = "btnRemoveVisit" + row.ToString();
      button2.Size = new Size(20, 22);
      button2.Anchor = AnchorStyles.None;
      button2.FlatStyle = FlatStyle.Standard;
      button2.Text = "X";
      button2.Click += new EventHandler(this.btnRemoveVisit_Click);
      this.btnRemoveVisits.Add(button2);
      this.ttComplexVisits.SetToolTip((Control) button1, "Save selected dates");
      this.ttComplexVisits.SetToolTip((Control) button2, "Remove selected visit");
      if (row > 0)
      {
        List<int> intList = new List<int>();
        int rowCount = this.pnlLayout.RowCount;
        int num = 0;
        while (num <= rowCount)
        {
          try
          {
            foreach (Label lblStart in this.lblStarts)
              intList.Add(this.pnlLayout.GetCellPosition((Control) lblStart).Row);
          }
          finally
          {
            List<Label>.Enumerator enumerator;
            enumerator.Dispose();
          }
          checked { ++num; }
        }
        intList.Sort();
        if (intList.Contains(row))
          row = checked (intList[intList.Count - 1] + 1);
      }
      this.pnlLayout.SetCellPosition((Control) label1, new TableLayoutPanelCellPosition(0, row));
      this.pnlLayout.SetCellPosition((Control) dateTimePicker1, new TableLayoutPanelCellPosition(1, row));
      this.pnlLayout.SetCellPosition((Control) label2, new TableLayoutPanelCellPosition(2, row));
      this.pnlLayout.SetCellPosition((Control) dateTimePicker2, new TableLayoutPanelCellPosition(3, row));
      this.pnlLayout.SetCellPosition((Control) button1, new TableLayoutPanelCellPosition(4, row));
      this.pnlLayout.SetCellPosition((Control) button2, new TableLayoutPanelCellPosition(5, row));
      this.pnlLayout.Controls.Add((Control) label1);
      this.pnlLayout.Controls.Add((Control) dateTimePicker1);
      this.pnlLayout.Controls.Add((Control) label2);
      this.pnlLayout.Controls.Add((Control) dateTimePicker2);
      this.pnlLayout.Controls.Add((Control) button1);
      this.pnlLayout.Controls.Add((Control) button2);
    }

    private void btnRemoveVisit_Click(object sender, EventArgs e)
    {
      Button button = (Button) sender;
      int index1 = this.btnRemoveVisits.IndexOf(button);
      DateTimePicker dateTimePicker1 = this.dtpMulitpleVisitsStart[index1];
      DateTimePicker dateTimePicker2 = this.dtpMulitpleVisitsEnd[index1];
      Label lblStart = this.lblStarts[index1];
      Label lblEnd = this.lblEnds[index1];
      Button btnAddVisit = this.btnAddVisits[index1];
      this.pnlLayout.Controls.Remove((Control) button);
      this.pnlLayout.Controls.Remove((Control) lblStart);
      this.pnlLayout.Controls.Remove((Control) dateTimePicker1);
      this.pnlLayout.Controls.Remove((Control) lblEnd);
      this.pnlLayout.Controls.Remove((Control) dateTimePicker2);
      this.pnlLayout.Controls.Remove((Control) btnAddVisit);
      this.dtpMulitpleVisitsStart.Remove(dateTimePicker1);
      this.dtpMulitpleVisitsEnd.Remove(dateTimePicker2);
      this.btnRemoveVisits.Remove(button);
      this.lblStarts.Remove(lblStart);
      this.lblEnds.Remove(lblEnd);
      this.btnAddVisits.Remove(btnAddVisit);
      if (!(this._visitsList.Count > 0 & checked (this._visitsList.Count - 1) >= index1))
        return;
      DateTime dateTime1 = this._visitsList[index1][0];
      DateTime t2 = this._visitsList[index1][1];
      DateTime dateTime2 = new DateTime(dateTime1.Year, dateTime1.Month, dateTime1.Day, 0, 0, 0);
      this._visitsList.RemoveAt(index1);
      for (; DateTime.Compare(dateTime2, t2) <= 0; dateTime2 = dateTime2.AddDays(1.0))
      {
        DateItem[] dateInfo = this.calComplexVisit.GetDateInfo(dateTime2);
        if (dateInfo.Length > 0)
        {
          DateItem[] dateItemArray = dateInfo;
          int index2 = 0;
          while (index2 < dateItemArray.Length)
          {
            this.calComplexVisit.RemoveDateInfo(dateItemArray[index2].Date);
            checked { ++index2; }
          }
        }
      }
      this.UpdateEngineerSchedule();
    }
  }
}
