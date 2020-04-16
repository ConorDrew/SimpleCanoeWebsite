// Decompiled with JetBrains decompiler
// Type: FSM.frmEngineerSchedule
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.ContactAttempts;
using FSM.Entity.EngineerVisits;
using FSM.Entity.HeartBeats;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using FSM.Entity.Users;
using FSM.MessageBird;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Threading;
using System.Windows.Forms;

namespace FSM
{
  public class frmEngineerSchedule : Form, ISchedulerForm
  {
    private int TEXTSIZE;
    private IContainer components;
    private string _currentDays;
    private string _startDate;
    private string _endDate;
    private DataSet _dsEngineerSchedule;
    public DateTime CurrentDate;
    public DateTime LastHeartBeat;
    public int LockedVisitId;
    public DateTime HeartLastCheck;
    private ScheduleTest[] _tests;
    private DataTable _dtday;
    private string _engineerID;
    private DataRow _engineer;
    private frmDetailsPopup _detailPopup;
    private bool _opening;
    private EngineerVisit _engineerVisit;
    private DataRow _testRow;
    private IAsyncResult _refreshAsyncResult;
    private IAsyncResult _refreshSummary;
    private DataTable timeSlotDt;

    internal virtual MenuItem btnPrintLsr
    {
      get
      {
        return this._btnPrintLsr;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPrintLsr_Click);
        MenuItem btnPrintLsr1 = this._btnPrintLsr;
        if (btnPrintLsr1 != null)
          btnPrintLsr1.Click -= eventHandler;
        this._btnPrintLsr = value;
        MenuItem btnPrintLsr2 = this._btnPrintLsr;
        if (btnPrintLsr2 == null)
          return;
        btnPrintLsr2.Click += eventHandler;
      }
    }

    internal virtual MenuItem btnReschedule
    {
      get
      {
        return this._btnReschedule;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnReschedule_Click);
        MenuItem btnReschedule1 = this._btnReschedule;
        if (btnReschedule1 != null)
          btnReschedule1.Click -= eventHandler;
        this._btnReschedule = value;
        MenuItem btnReschedule2 = this._btnReschedule;
        if (btnReschedule2 == null)
          return;
        btnReschedule2.Click += eventHandler;
      }
    }

    internal virtual MenuItem btnCreateJob
    {
      get
      {
        return this._btnCreateJob;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCreateJob_Click);
        MenuItem btnCreateJob1 = this._btnCreateJob;
        if (btnCreateJob1 != null)
          btnCreateJob1.Click -= eventHandler;
        this._btnCreateJob = value;
        MenuItem btnCreateJob2 = this._btnCreateJob;
        if (btnCreateJob2 == null)
          return;
        btnCreateJob2.Click += eventHandler;
      }
    }

    internal virtual MenuItem btnSiteReport
    {
      get
      {
        return this._btnSiteReport;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSiteReport_Click);
        MenuItem btnSiteReport1 = this._btnSiteReport;
        if (btnSiteReport1 != null)
          btnSiteReport1.Click -= eventHandler;
        this._btnSiteReport = value;
        MenuItem btnSiteReport2 = this._btnSiteReport;
        if (btnSiteReport2 == null)
          return;
        btnSiteReport2.Click += eventHandler;
      }
    }

    internal virtual ToolTip ttStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual PictureBox pbInfomation
    {
      get
      {
        return this._pbInfomation;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.imgEye_Click);
        PictureBox pbInfomation1 = this._pbInfomation;
        if (pbInfomation1 != null)
          pbInfomation1.Click -= eventHandler;
        this._pbInfomation = value;
        PictureBox pbInfomation2 = this._pbInfomation;
        if (pbInfomation2 == null)
          return;
        pbInfomation2.Click += eventHandler;
      }
    }

    internal virtual MenuItem btnTextMessage
    {
      get
      {
        return this._btnTextMessage;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnTextMessage_Click);
        MenuItem btnTextMessage1 = this._btnTextMessage;
        if (btnTextMessage1 != null)
          btnTextMessage1.Click -= eventHandler;
        this._btnTextMessage = value;
        MenuItem btnTextMessage2 = this._btnTextMessage;
        if (btnTextMessage2 == null)
          return;
        btnTextMessage2.Click += eventHandler;
      }
    }

    internal virtual MenuItem MenuItem1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual MenuItem btnServiceLetter
    {
      get
      {
        return this._btnServiceLetter;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnServiceLetter_Click);
        MenuItem btnServiceLetter1 = this._btnServiceLetter;
        if (btnServiceLetter1 != null)
          btnServiceLetter1.Click -= eventHandler;
        this._btnServiceLetter = value;
        MenuItem btnServiceLetter2 = this._btnServiceLetter;
        if (btnServiceLetter2 == null)
          return;
        btnServiceLetter2.Click += eventHandler;
      }
    }

    internal virtual MenuItem btnSolarInstallation
    {
      get
      {
        return this._btnSolarInstallation;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSolarInstallation_Click);
        MenuItem solarInstallation1 = this._btnSolarInstallation;
        if (solarInstallation1 != null)
          solarInstallation1.Click -= eventHandler;
        this._btnSolarInstallation = value;
        MenuItem solarInstallation2 = this._btnSolarInstallation;
        if (solarInstallation2 == null)
          return;
        solarInstallation2.Click += eventHandler;
      }
    }

    internal virtual MenuItem btnElectricalAppointment
    {
      get
      {
        return this._btnElectricalAppointment;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnElectricalAppointment_Click);
        MenuItem electricalAppointment1 = this._btnElectricalAppointment;
        if (electricalAppointment1 != null)
          electricalAppointment1.Click -= eventHandler;
        this._btnElectricalAppointment = value;
        MenuItem electricalAppointment2 = this._btnElectricalAppointment;
        if (electricalAppointment2 == null)
          return;
        electricalAppointment2.Click += eventHandler;
      }
    }

    public frmEngineerSchedule(
      MouseEventHandler gridMouseDown,
      MouseEventHandler gridMouseMove,
      DragEventHandler gridDragOver,
      DragEventHandler gridDragDrop,
      MouseEventHandler gridMouseUp,
      DataRow Engineer,
      int textsizes)
    {
      this.FormClosing += new FormClosingEventHandler(this.frmEngineerSchedule_FormClosing);
      this.Load += new EventHandler(this.frmEngineerSchedule_Load);
      this.Resize += new EventHandler(this.frmEngineerSchedule_Resize);
      this.SizeChanged += new EventHandler(this.frmVisit_SizeChanged);
      this.TEXTSIZE = 0;
      this.EngineerScheduleTimer = new System.Windows.Forms.Timer();
      this._dsEngineerSchedule = new DataSet();
      this._tests = new ScheduleTest[7]
      {
        (ScheduleTest) new RegionCheck(),
        (ScheduleTest) new PostcodeRegionCheck(),
        (ScheduleTest) new LevelsCheck(),
        (ScheduleTest) new AbsenceOverlapCheck(),
        (ScheduleTest) new SOROverloadCheck(),
        (ScheduleTest) new DueDateCheck(),
        (ScheduleTest) new PriorityCheck()
      };
      this._dtday = new DataTable();
      this.InitializeComponent();
      this.dgDay.MouseDown += gridMouseDown;
      this.dgDay.MouseMove += gridMouseMove;
      this.dgDaySummary.DragOver += gridDragOver;
      this.dgDaySummary.DragDrop += gridDragDrop;
      this.dgDay.MouseUp += gridMouseUp;
      this._engineerID = Conversions.ToString(Engineer[nameof (EngineerID)]);
      this._engineer = Engineer;
      this.TEXTSIZE = textsizes;
    }

    protected override void Dispose(bool disposing)
    {
      try
      {
        this.detailPopup.Dispose();
        if (disposing && this.components != null)
          this.components.Dispose();
        base.Dispose(disposing);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    internal virtual Panel pnlHeader { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTitle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Splitter splitEngineer
    {
      get
      {
        return this._splitEngineer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        SplitterEventHandler splitterEventHandler = new SplitterEventHandler(this.splitEngineer_SplitterMoved);
        Splitter splitEngineer1 = this._splitEngineer;
        if (splitEngineer1 != null)
          splitEngineer1.SplitterMoved -= splitterEventHandler;
        this._splitEngineer = value;
        Splitter splitEngineer2 = this._splitEngineer;
        if (splitEngineer2 == null)
          return;
        splitEngineer2.SplitterMoved += splitterEventHandler;
      }
    }

    internal virtual DataGrid dgDaySummary
    {
      get
      {
        return this._dgDaySummary;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgDaySummary_MouseUp);
        DataGrid dgDaySummary1 = this._dgDaySummary;
        if (dgDaySummary1 != null)
          dgDaySummary1.MouseUp -= mouseEventHandler;
        this._dgDaySummary = value;
        DataGrid dgDaySummary2 = this._dgDaySummary;
        if (dgDaySummary2 == null)
          return;
        dgDaySummary2.MouseUp += mouseEventHandler;
      }
    }

    internal virtual ImageList imgLstIcons { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ContextMenu mnuVisitAction
    {
      get
      {
        return this._mnuVisitAction;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuVisitAction_Popup);
        ContextMenu mnuVisitAction1 = this._mnuVisitAction;
        if (mnuVisitAction1 != null)
          mnuVisitAction1.Popup -= eventHandler;
        this._mnuVisitAction = value;
        ContextMenu mnuVisitAction2 = this._mnuVisitAction;
        if (mnuVisitAction2 == null)
          return;
        mnuVisitAction2.Popup += eventHandler;
      }
    }

    internal virtual MenuItem btnSendText
    {
      get
      {
        return this._btnSendText;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSendText_Click);
        MenuItem btnSendText1 = this._btnSendText;
        if (btnSendText1 != null)
          btnSendText1.Click -= eventHandler;
        this._btnSendText = value;
        MenuItem btnSendText2 = this._btnSendText;
        if (btnSendText2 == null)
          return;
        btnSendText2.Click += eventHandler;
      }
    }

    internal virtual ContextMenu mnuDayAction { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual MenuItem btnExportJobs
    {
      get
      {
        return this._btnExportJobs;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnExportJobs_Click);
        MenuItem btnExportJobs1 = this._btnExportJobs;
        if (btnExportJobs1 != null)
          btnExportJobs1.Click -= eventHandler;
        this._btnExportJobs = value;
        MenuItem btnExportJobs2 = this._btnExportJobs;
        if (btnExportJobs2 == null)
          return;
        btnExportJobs2.Click += eventHandler;
      }
    }

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

    internal virtual DataGrid dgDay
    {
      get
      {
        return this._dgDay;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgDay_DoubleClick);
        MouseEventHandler mouseEventHandler1 = new MouseEventHandler(this.dgDay_MouseUp);
        MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.dgDay_MouseMove);
        DataGrid dgDay1 = this._dgDay;
        if (dgDay1 != null)
        {
          dgDay1.DoubleClick -= eventHandler;
          dgDay1.MouseUp -= mouseEventHandler1;
          dgDay1.MouseMove -= mouseEventHandler2;
        }
        this._dgDay = value;
        DataGrid dgDay2 = this._dgDay;
        if (dgDay2 == null)
          return;
        dgDay2.DoubleClick += eventHandler;
        dgDay2.MouseUp += mouseEventHandler1;
        dgDay2.MouseMove += mouseEventHandler2;
      }
    }

    internal virtual PictureBox picRegion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual PictureBox picPostalRegions { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual PictureBox picVan { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual PictureBox picQuestion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual PictureBox picSpanner { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual PictureBox pbRed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual PictureBox pbGreen { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual PictureBox pbClose
    {
      get
      {
        return this._pbClose;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.PictureBox1_Click);
        PictureBox pbClose1 = this._pbClose;
        if (pbClose1 != null)
          pbClose1.Click -= eventHandler;
        this._pbClose = value;
        PictureBox pbClose2 = this._pbClose;
        if (pbClose2 == null)
          return;
        pbClose2.Click += eventHandler;
      }
    }

    internal virtual PictureBox picLevels { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmEngineerSchedule));
      this.pnlHeader = new Panel();
      this.pbClose = new PictureBox();
      this.pbGreen = new PictureBox();
      this.pbRed = new PictureBox();
      this.picVan = new PictureBox();
      this.picQuestion = new PictureBox();
      this.picSpanner = new PictureBox();
      this.picLevels = new PictureBox();
      this.picPostalRegions = new PictureBox();
      this.picRegion = new PictureBox();
      this.lblTitle = new Label();
      this.pbInfomation = new PictureBox();
      this.dgDaySummary = new DataGrid();
      this.mnuDayAction = new ContextMenu();
      this.btnCreateJob = new MenuItem();
      this.btnExportJobs = new MenuItem();
      this.splitEngineer = new Splitter();
      this.mnuVisitAction = new ContextMenu();
      this.btnSendText = new MenuItem();
      this.btnReschedule = new MenuItem();
      this.btnTextMessage = new MenuItem();
      this.MenuItem1 = new MenuItem();
      this.btnSiteReport = new MenuItem();
      this.btnPrintLsr = new MenuItem();
      this.btnServiceLetter = new MenuItem();
      this.btnSolarInstallation = new MenuItem();
      this.btnElectricalAppointment = new MenuItem();
      this.imgLstIcons = new ImageList(this.components);
      this.dgDay = new DataGrid();
      this.picPlanner = new PictureBox();
      this.ttStatus = new ToolTip(this.components);
      this.pnlHeader.SuspendLayout();
      ((ISupportInitialize) this.pbClose).BeginInit();
      ((ISupportInitialize) this.pbGreen).BeginInit();
      ((ISupportInitialize) this.pbRed).BeginInit();
      ((ISupportInitialize) this.picVan).BeginInit();
      ((ISupportInitialize) this.picQuestion).BeginInit();
      ((ISupportInitialize) this.picSpanner).BeginInit();
      ((ISupportInitialize) this.picLevels).BeginInit();
      ((ISupportInitialize) this.picPostalRegions).BeginInit();
      ((ISupportInitialize) this.picRegion).BeginInit();
      ((ISupportInitialize) this.pbInfomation).BeginInit();
      this.dgDaySummary.BeginInit();
      this.dgDay.BeginInit();
      ((ISupportInitialize) this.picPlanner).BeginInit();
      this.SuspendLayout();
      this.pnlHeader.BackColor = Color.SteelBlue;
      this.pnlHeader.Controls.Add((Control) this.pbClose);
      this.pnlHeader.Controls.Add((Control) this.pbGreen);
      this.pnlHeader.Controls.Add((Control) this.pbRed);
      this.pnlHeader.Controls.Add((Control) this.picVan);
      this.pnlHeader.Controls.Add((Control) this.picQuestion);
      this.pnlHeader.Controls.Add((Control) this.picSpanner);
      this.pnlHeader.Controls.Add((Control) this.picLevels);
      this.pnlHeader.Controls.Add((Control) this.picPostalRegions);
      this.pnlHeader.Controls.Add((Control) this.picRegion);
      this.pnlHeader.Controls.Add((Control) this.lblTitle);
      this.pnlHeader.Controls.Add((Control) this.pbInfomation);
      this.pnlHeader.Dock = DockStyle.Top;
      this.pnlHeader.Location = new System.Drawing.Point(0, 0);
      this.pnlHeader.Name = "pnlHeader";
      this.pnlHeader.Size = new Size(432, 18);
      this.pnlHeader.TabIndex = 1;
      this.pbClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.pbClose.BackColor = Color.Transparent;
      this.pbClose.Cursor = Cursors.Hand;
      this.pbClose.Image = (Image) FSM.My.Resources.Resources.delete;
      this.pbClose.Location = new System.Drawing.Point(410, 1);
      this.pbClose.Name = "pbClose";
      this.pbClose.Size = new Size(19, 17);
      this.pbClose.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbClose.TabIndex = 9;
      this.pbClose.TabStop = false;
      this.pbGreen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.pbGreen.BackColor = Color.Transparent;
      this.pbGreen.Image = (Image) FSM.My.Resources.Resources.green_light;
      this.pbGreen.Location = new System.Drawing.Point(358, 1);
      this.pbGreen.Name = "pbGreen";
      this.pbGreen.Size = new Size(19, 17);
      this.pbGreen.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbGreen.TabIndex = 8;
      this.pbGreen.TabStop = false;
      this.pbGreen.Visible = false;
      this.pbRed.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.pbRed.BackColor = Color.Transparent;
      this.pbRed.Image = (Image) FSM.My.Resources.Resources.red_light;
      this.pbRed.Location = new System.Drawing.Point(358, 1);
      this.pbRed.Name = "pbRed";
      this.pbRed.Size = new Size(19, 17);
      this.pbRed.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbRed.TabIndex = 7;
      this.pbRed.TabStop = false;
      this.pbRed.Visible = false;
      this.picVan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.picVan.BackColor = Color.Transparent;
      this.picVan.Image = (Image) FSM.My.Resources.Resources.Van;
      this.picVan.Location = new System.Drawing.Point(383, 1);
      this.picVan.Name = "picVan";
      this.picVan.Size = new Size(19, 17);
      this.picVan.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picVan.TabIndex = 6;
      this.picVan.TabStop = false;
      this.picVan.Visible = false;
      this.picQuestion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.picQuestion.BackColor = Color.Transparent;
      this.picQuestion.Image = (Image) FSM.My.Resources.Resources.Question_mark_icon;
      this.picQuestion.Location = new System.Drawing.Point(383, 0);
      this.picQuestion.Name = "picQuestion";
      this.picQuestion.Size = new Size(15, 18);
      this.picQuestion.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picQuestion.TabIndex = 5;
      this.picQuestion.TabStop = false;
      this.picQuestion.Visible = false;
      this.picSpanner.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.picSpanner.BackColor = Color.Transparent;
      this.picSpanner.Image = (Image) FSM.My.Resources.Resources.imagesWITCGZO5;
      this.picSpanner.Location = new System.Drawing.Point(383, 1);
      this.picSpanner.Name = "picSpanner";
      this.picSpanner.Size = new Size(16, 16);
      this.picSpanner.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picSpanner.TabIndex = 4;
      this.picSpanner.TabStop = false;
      this.picSpanner.Visible = false;
      this.picLevels.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.picLevels.BackColor = Color.Transparent;
      this.picLevels.Image = (Image) componentResourceManager.GetObject("picLevels.Image");
      this.picLevels.Location = new System.Drawing.Point(306, 1);
      this.picLevels.Name = "picLevels";
      this.picLevels.Size = new Size(16, 16);
      this.picLevels.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picLevels.TabIndex = 3;
      this.picLevels.TabStop = false;
      this.picLevels.Visible = false;
      this.picPostalRegions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.picPostalRegions.BackColor = Color.Transparent;
      this.picPostalRegions.Image = (Image) componentResourceManager.GetObject("picPostalRegions.Image");
      this.picPostalRegions.Location = new System.Drawing.Point(286, 2);
      this.picPostalRegions.Name = "picPostalRegions";
      this.picPostalRegions.Size = new Size(16, 16);
      this.picPostalRegions.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picPostalRegions.TabIndex = 2;
      this.picPostalRegions.TabStop = false;
      this.picPostalRegions.Visible = false;
      this.picRegion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.picRegion.BackColor = Color.Transparent;
      this.picRegion.Image = (Image) componentResourceManager.GetObject("picRegion.Image");
      this.picRegion.Location = new System.Drawing.Point(328, 0);
      this.picRegion.Name = "picRegion";
      this.picRegion.Size = new Size(16, 16);
      this.picRegion.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picRegion.TabIndex = 1;
      this.picRegion.TabStop = false;
      this.picRegion.Visible = false;
      this.lblTitle.AutoSize = true;
      this.lblTitle.Dock = DockStyle.Left;
      this.lblTitle.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblTitle.ForeColor = Color.White;
      this.lblTitle.Location = new System.Drawing.Point(19, 0);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new Size(142, 16);
      this.lblTitle.TabIndex = 0;
      this.lblTitle.Text = "Engineer Schedule";
      this.lblTitle.TextAlign = ContentAlignment.MiddleRight;
      this.pbInfomation.BackColor = Color.Transparent;
      this.pbInfomation.Cursor = Cursors.Hand;
      this.pbInfomation.Dock = DockStyle.Left;
      this.pbInfomation.Image = (Image) componentResourceManager.GetObject("pbInfomation.Image");
      this.pbInfomation.Location = new System.Drawing.Point(0, 0);
      this.pbInfomation.Name = "pbInfomation";
      this.pbInfomation.Size = new Size(19, 18);
      this.pbInfomation.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pbInfomation.TabIndex = 10;
      this.pbInfomation.TabStop = false;
      this.ttStatus.SetToolTip((Control) this.pbInfomation, "View Engineer Information");
      this.dgDaySummary.AllowDrop = true;
      this.dgDaySummary.ContextMenu = this.mnuDayAction;
      this.dgDaySummary.DataMember = "";
      this.dgDaySummary.Dock = DockStyle.Left;
      this.dgDaySummary.HeaderForeColor = SystemColors.ControlText;
      this.dgDaySummary.Location = new System.Drawing.Point(0, 18);
      this.dgDaySummary.Name = "dgDaySummary";
      this.dgDaySummary.Size = new Size(63, 103);
      this.dgDaySummary.TabIndex = 2;
      this.mnuDayAction.MenuItems.AddRange(new MenuItem[2]
      {
        this.btnCreateJob,
        this.btnExportJobs
      });
      this.btnCreateJob.Index = 0;
      this.btnCreateJob.Text = "Create Job";
      this.btnExportJobs.Index = 1;
      this.btnExportJobs.Text = "&Export Jobs";
      this.btnExportJobs.Visible = false;
      this.splitEngineer.Location = new System.Drawing.Point(63, 18);
      this.splitEngineer.Name = "splitEngineer";
      this.splitEngineer.Size = new Size(3, 103);
      this.splitEngineer.TabIndex = 3;
      this.splitEngineer.TabStop = false;
      this.mnuVisitAction.MenuItems.AddRange(new MenuItem[4]
      {
        this.btnSendText,
        this.btnReschedule,
        this.btnTextMessage,
        this.MenuItem1
      });
      this.btnSendText.Index = 0;
      this.btnSendText.Text = "&Send Text";
      this.btnSendText.Visible = false;
      this.btnReschedule.Index = 1;
      this.btnReschedule.Text = "Reschedule";
      this.btnReschedule.Visible = false;
      this.btnTextMessage.Index = 2;
      this.btnTextMessage.Text = "Include In Message Run";
      this.MenuItem1.Index = 3;
      this.MenuItem1.MenuItems.AddRange(new MenuItem[5]
      {
        this.btnSiteReport,
        this.btnPrintLsr,
        this.btnServiceLetter,
        this.btnSolarInstallation,
        this.btnElectricalAppointment
      });
      this.MenuItem1.Text = "Print";
      this.btnSiteReport.Index = 0;
      this.btnSiteReport.Text = "Site Report";
      this.btnPrintLsr.Index = 1;
      this.btnPrintLsr.Text = "LSR";
      this.btnPrintLsr.Visible = false;
      this.btnServiceLetter.Index = 2;
      this.btnServiceLetter.Text = "Service Letter";
      this.btnSolarInstallation.Index = 3;
      this.btnSolarInstallation.Text = "Solar Installation";
      this.btnElectricalAppointment.Index = 4;
      this.btnElectricalAppointment.Text = "Electrical Appointment";
      this.imgLstIcons.ColorDepth = ColorDepth.Depth24Bit;
      this.imgLstIcons.ImageSize = new Size(16, 16);
      this.imgLstIcons.TransparentColor = Color.Transparent;
      this.dgDay.CaptionFont = new Font("Verdana", 6.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dgDay.ContextMenu = this.mnuVisitAction;
      this.dgDay.DataMember = "";
      this.dgDay.Dock = DockStyle.Fill;
      this.dgDay.Font = new Font("Verdana", 5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dgDay.HeaderFont = new Font("Verdana", 6.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.dgDay.HeaderForeColor = SystemColors.ControlText;
      this.dgDay.Location = new System.Drawing.Point(66, 18);
      this.dgDay.Name = "dgDay";
      this.dgDay.PreferredRowHeight = 12;
      this.dgDay.Size = new Size(366, 79);
      this.dgDay.TabIndex = 6;
      this.picPlanner.BackColor = Color.FromArgb(224, 224, 224);
      this.picPlanner.BorderStyle = BorderStyle.Fixed3D;
      this.picPlanner.Dock = DockStyle.Bottom;
      this.picPlanner.Location = new System.Drawing.Point(66, 97);
      this.picPlanner.Name = "picPlanner";
      this.picPlanner.Size = new Size(366, 24);
      this.picPlanner.TabIndex = 5;
      this.picPlanner.TabStop = false;
      this.ClientSize = new Size(432, 121);
      this.ControlBox = false;
      this.Controls.Add((Control) this.dgDay);
      this.Controls.Add((Control) this.picPlanner);
      this.Controls.Add((Control) this.splitEngineer);
      this.Controls.Add((Control) this.dgDaySummary);
      this.Controls.Add((Control) this.pnlHeader);
      this.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.Name = nameof (frmEngineerSchedule);
      this.Opacity = 0.0;
      this.StartPosition = FormStartPosition.Manual;
      this.pnlHeader.ResumeLayout(false);
      this.pnlHeader.PerformLayout();
      ((ISupportInitialize) this.pbClose).EndInit();
      ((ISupportInitialize) this.pbGreen).EndInit();
      ((ISupportInitialize) this.pbRed).EndInit();
      ((ISupportInitialize) this.picVan).EndInit();
      ((ISupportInitialize) this.picQuestion).EndInit();
      ((ISupportInitialize) this.picSpanner).EndInit();
      ((ISupportInitialize) this.picLevels).EndInit();
      ((ISupportInitialize) this.picPostalRegions).EndInit();
      ((ISupportInitialize) this.picRegion).EndInit();
      ((ISupportInitialize) this.pbInfomation).EndInit();
      this.dgDaySummary.EndInit();
      this.dgDay.EndInit();
      ((ISupportInitialize) this.picPlanner).EndInit();
      this.ResumeLayout(false);
    }

    public virtual System.Windows.Forms.Timer EngineerScheduleTimer
    {
      get
      {
        return this._EngineerScheduleTimer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Timer_tick);
        System.Windows.Forms.Timer engineerScheduleTimer1 = this._EngineerScheduleTimer;
        if (engineerScheduleTimer1 != null)
          engineerScheduleTimer1.Tick -= eventHandler;
        this._EngineerScheduleTimer = value;
        System.Windows.Forms.Timer engineerScheduleTimer2 = this._EngineerScheduleTimer;
        if (engineerScheduleTimer2 == null)
          return;
        engineerScheduleTimer2.Tick += eventHandler;
      }
    }

    private DataTable CurrentDayDataTable
    {
      get
      {
        return this._dtday;
      }
      set
      {
        this._dtday = value;
      }
    }

    private DataRow SelectedDataRow
    {
      get
      {
        if (this.dgDay.CurrentRowIndex == -1)
          return (DataRow) null;
        return (DataRow) NewLateBinding.LateGet(NewLateBinding.LateIndexGet(this.dgDay.DataSource, new object[1]
        {
          (object) this.dgDay.CurrentRowIndex
        }, (string[]) null), (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null);
      }
    }

    public string EngineerID
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

    public DataRow Engineer
    {
      get
      {
        return this._engineer;
      }
      set
      {
        this._engineer = value;
      }
    }

    public frmDetailsPopup detailPopup
    {
      get
      {
        return this._detailPopup;
      }
      set
      {
        this._detailPopup = value;
      }
    }

    public bool opening
    {
      get
      {
        return this._opening;
      }
      set
      {
        this._opening = value;
      }
    }

    public EngineerVisit EngineerVisit
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
        return nameof (frmEngineerSchedule);
      }
    }

    private void setUpDayDg()
    {
      ModScheduler.SetUpSchedulerDataGrid(this.dgDay, false);
      DataGridTableStyle tableStyle = this.dgDay.TableStyles[0];
      double num = 0.9;
      switch (this.TEXTSIZE)
      {
        case 7:
          num = 1.0;
          break;
        case 8:
          num = 1.1;
          break;
        case 9:
          num = 1.2;
          break;
        case 10:
          num = 1.25;
          break;
        case 11:
          num = 1.3;
          break;
        case 12:
          num = 1.35;
          break;
      }
      tableStyle.DataGrid.Font = new Font("Verdana", (float) this.TEXTSIZE, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      tableStyle.DataGrid.HeaderFont = new Font("Verdana", (float) this.TEXTSIZE, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      DataGridSchedulerColumn gridSchedulerColumn = new DataGridSchedulerColumn();
      gridSchedulerColumn.Format = "";
      gridSchedulerColumn.FormatInfo = (IFormatProvider) null;
      gridSchedulerColumn.HeaderText = "";
      gridSchedulerColumn.MappingName = "JobStatus";
      gridSchedulerColumn.ReadOnly = true;
      gridSchedulerColumn.Width = checked ((int) Math.Round(unchecked (15.0 * num)));
      gridSchedulerColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridSchedulerColumn);
      DataGridSchedulerJobColumn schedulerJobColumn = new DataGridSchedulerJobColumn();
      schedulerJobColumn.Format = "";
      schedulerJobColumn.FormatInfo = (IFormatProvider) null;
      schedulerJobColumn.HeaderText = "Job No";
      schedulerJobColumn.MappingName = "JobNumber";
      schedulerJobColumn.ReadOnly = true;
      schedulerJobColumn.Width = checked ((int) Math.Round(unchecked (60.0 * num)));
      schedulerJobColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) schedulerJobColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Address 1";
      dataGridLabelColumn1.MappingName = "Address1";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = checked ((int) Math.Round(unchecked (125.0 * num)));
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Postcode";
      dataGridLabelColumn2.MappingName = "PostCode";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = checked ((int) Math.Round(unchecked (65.0 * num)));
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Job Summary";
      dataGridLabelColumn3.MappingName = "JobItems";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = checked ((int) Math.Round(unchecked (100.0 * num)));
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Notes";
      dataGridLabelColumn4.MappingName = "NotesToEngineer";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = checked ((int) Math.Round(unchecked (325.0 * num)));
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "HH:mm";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Start";
      dataGridLabelColumn5.MappingName = "StartDateTime";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = checked ((int) Math.Round(unchecked (40.0 * num)));
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "HH:mm";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "End";
      dataGridLabelColumn6.MappingName = "EndDateTime";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = checked ((int) Math.Round(unchecked (40.0 * num)));
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Status";
      dataGridLabelColumn7.MappingName = "VisitStatus";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = checked ((int) Math.Round(unchecked (80.0 * num)));
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Customer";
      dataGridLabelColumn8.MappingName = "customername";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = checked ((int) Math.Round(unchecked (75.0 * num)));
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridJobTypeColumn gridJobTypeColumn = new DataGridJobTypeColumn();
      gridJobTypeColumn.Format = "";
      gridJobTypeColumn.FormatInfo = (IFormatProvider) null;
      gridJobTypeColumn.HeaderText = "Type";
      gridJobTypeColumn.MappingName = "JobType";
      gridJobTypeColumn.ReadOnly = true;
      gridJobTypeColumn.Width = checked ((int) Math.Round(unchecked (150.0 * num)));
      gridJobTypeColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridJobTypeColumn);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "#";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "SOR";
      dataGridLabelColumn9.MappingName = "SummedSOR";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = checked ((int) Math.Round(unchecked (50.0 * num)));
      dataGridLabelColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
      dataGridLabelColumn10.Format = "dd/MM/yyyy";
      dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn10.HeaderText = "Est Date";
      dataGridLabelColumn10.MappingName = "EstimatedVisitDate";
      dataGridLabelColumn10.ReadOnly = true;
      dataGridLabelColumn10.Width = checked ((int) Math.Round(unchecked (60.0 * num)));
      dataGridLabelColumn10.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      tableStyle.MappingName = "";
    }

    private void setUpSummaryDg()
    {
      ModScheduler.SetUpSchedulerDataGrid(this.dgDaySummary, false);
      double num = 0.9;
      switch (this.TEXTSIZE)
      {
        case 7:
          num = 1.0;
          break;
        case 8:
          num = 1.1;
          break;
        case 9:
          num = 1.2;
          break;
        case 10:
          num = 1.3;
          break;
        case 11:
          num = 1.5;
          break;
        case 12:
          num = 1.7;
          break;
      }
      DataGridTableStyle tableStyle = this.dgDaySummary.TableStyles[0];
      tableStyle.DataGrid.Font = new Font("Verdana", (float) this.TEXTSIZE, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      tableStyle.DataGrid.HeaderFont = new Font("Verdana", (float) this.TEXTSIZE, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      frmEngineerSchedule.unavailableBar unavailableBar = new frmEngineerSchedule.unavailableBar();
      unavailableBar.Format = "";
      unavailableBar.FormatInfo = (IFormatProvider) null;
      unavailableBar.HeaderText = "";
      unavailableBar.MappingName = "AbsenceColumn";
      unavailableBar.ReadOnly = true;
      unavailableBar.Width = checked ((int) Math.Round(unchecked (22.0 * num)));
      unavailableBar.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) unavailableBar);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.MappingName = "dayDate";
      dataGridLabelColumn1.HeaderText = "Date";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = checked ((int) Math.Round(unchecked (70.0 * num)));
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.MappingName = "day";
      dataGridLabelColumn2.HeaderText = "Day";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = checked ((int) Math.Round(unchecked (30.0 * num)));
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.MappingName = "workCount";
      dataGridLabelColumn3.HeaderText = "Work";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Alignment = HorizontalAlignment.Center;
      dataGridLabelColumn3.Width = checked ((int) Math.Round(unchecked (30.0 * num)));
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "#";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "SOR";
      dataGridLabelColumn4.MappingName = "SummedSOR";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = checked ((int) Math.Round(unchecked (30.0 * num)));
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      tableStyle.MappingName = "ScheduleSummary";
    }

    private void frmEngineerSchedule_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (this._refreshAsyncResult != null)
      {
        while (!this._refreshAsyncResult.IsCompleted)
        {
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.BetaFeatures))
            Thread.Sleep(100);
          Application.DoEvents();
        }
      }
      if (this._refreshSummary == null)
        return;
      while (!this._refreshSummary.IsCompleted)
      {
        if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.BetaFeatures))
          Thread.Sleep(100);
        Application.DoEvents();
      }
    }

    private void frmEngineerSchedule_Load(object sender, EventArgs e)
    {
      this.setUpDayDg();
      this.setUpSummaryDg();
      this.detailPopup = new frmDetailsPopup(this);
      this.SetupHeartBeat();
      this.DisplayLastLocation();
      this.EngineerScheduleTimer.Interval = 300000;
      this.EngineerScheduleTimer.Start();
    }

    private void frmEngineerSchedule_Resize(object sender, EventArgs e)
    {
      double num = 0.15;
      switch (this.TEXTSIZE)
      {
        case 7:
          num = 0.16;
          break;
        case 8:
          num = 0.17;
          break;
        case 9:
          num = 0.18;
          break;
        case 10:
          num = 0.19;
          break;
        case 11:
          num = 0.22;
          break;
        case 12:
          num = 0.25;
          break;
      }
      this.dgDaySummary.Width = checked ((int) Math.Round(unchecked ((double) this.Width * num)));
    }

    private void dgDaySummary_MouseUp(object sender, MouseEventArgs e)
    {
      DataGrid.HitTestInfo hitTestInfo = this.dgDaySummary.HitTest(e.X, e.Y);
      if (hitTestInfo.Type != DataGrid.HitTestType.Cell)
        return;
      this.dgDaySummary.CurrentRowIndex = hitTestInfo.Row;
      this.ShowDay(this.SelectedDay());
    }

    private void dgDay_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Please select a visit to open the job", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        FSM.Entity.Sites.Site site = App.DB.Sites.Get(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["SiteID"]), SiteSQL.GetBy.SiteId, (object) null);
        if (site == null || !site.Exists)
        {
          int num2 = (int) App.ShowMessage("Unable to access site!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else
        {
          if (App.loggedInUser.UserRegions.Table.Select("RegionID = " + Conversions.ToString(site.RegionID)).Length < 1)
            throw new SecurityException("You do not have the necessary security permissions.\r\n\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
          App.ShowForm(typeof (FRMLogCallout), true, new object[5]
          {
            this.SelectedDataRow["JobID"],
            this.SelectedDataRow["SiteID"],
            (object) this,
            null,
            this.SelectedDataRow["EngineerVisitID"]
          }, false);
        }
      }
    }

    public void Reset()
    {
      this._dsEngineerSchedule = new DataSet();
      try
      {
        this.dgDay.DataSource = (object) null;
        this.dgDaySummary.DataSource = (object) null;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public void RefreshAcceptance(DataRow testRow)
    {
      this._testRow = testRow;
      this._refreshAsyncResult = new frmEngineerSchedule.refreshAcceptanceDelegate(this.BeginRefreshAcceptance).BeginInvoke(new AsyncCallback(this.refreshAccptanceComplete), (object) null);
    }

    public Hashtable BeginRefreshAcceptance()
    {
      Hashtable hashtable1;
      try
      {
        if (this._testRow != null)
        {
          Hashtable hashtable2 = new Hashtable();
          ScheduleTest[] tests = this._tests;
          int index = 0;
          while (index < tests.Length)
          {
            ScheduleTest scheduleTest = tests[index];
            if (this._testRow != null)
            {
              ScheduleTest.TestResult testResult = scheduleTest.Test(this._testRow, Conversions.ToInteger(this.EngineerID), this.CurrentDate);
              hashtable2.Add((object) scheduleTest, (object) testResult);
              checked { ++index; }
            }
            else
            {
              hashtable1 = (Hashtable) null;
              goto label_10;
            }
          }
          hashtable1 = hashtable2;
        }
        else
          hashtable1 = (Hashtable) null;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        hashtable1 = (Hashtable) null;
        ProjectData.ClearProjectError();
      }
label_10:
      return hashtable1;
    }

    public void refreshAccptanceComplete(IAsyncResult ar)
    {
      Hashtable hashtable = ((frmEngineerSchedule.refreshAcceptanceDelegate) ((AsyncResult) ar).AsyncDelegate).EndInvoke(ar);
      if (this.IsFormDisposed)
        return;
      try
      {
        this.Invoke((Delegate) new frmEngineerSchedule.resultsDisplayDelegate(this.SetResultDisplay), (object) hashtable);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public void SetResultDisplay(Hashtable results)
    {
      try
      {
        this._testRow = (DataRow) null;
        if (results != null)
        {
          bool flag = true;
          ScheduleTest[] tests = this._tests;
          int index = 0;
          while (index < tests.Length)
          {
            ScheduleTest scheduleTest = tests[index];
            ScheduleTest.TestResult result = (ScheduleTest.TestResult) results[(object) scheduleTest];
            if (!result.pass)
              flag = false;
            string lower = scheduleTest.GetType().Name.ToLower();
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "RegionCheck".ToLower(), false) == 0)
              this.picRegion.Visible = result.pass;
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "PostcodeRegionCheck".ToLower(), false) == 0)
              this.picPostalRegions.Visible = result.pass;
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "LevelsCheck".ToLower(), false) == 0)
              this.picLevels.Visible = result.pass;
            checked { ++index; }
          }
          if (flag)
            this.pnlHeader.BackColor = Color.LightGreen;
          else
            this.pnlHeader.BackColor = Color.Salmon;
        }
        else
          this.ResetHeader();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      Application.DoEvents();
    }

    public bool TestAcceptance(DataRow testRow)
    {
      bool flag = true;
      ScheduleTest[] tests = this._tests;
      int index = 0;
      while (index < tests.Length)
      {
        ScheduleTest scheduleTest = tests[index];
        ScheduleTest.TestResult testResult = scheduleTest.Test(testRow, Conversions.ToInteger(this.EngineerID), this.CurrentDate);
        if (!testResult.pass)
          flag = false;
        string lower = scheduleTest.GetType().Name.ToLower();
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "RegionCheck".ToLower(), false) == 0)
          this.picRegion.Visible = testResult.pass;
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "PostcodeRegionCheck".ToLower(), false) == 0)
          this.picPostalRegions.Visible = testResult.pass;
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "LevelsCheck".ToLower(), false) == 0)
          this.picLevels.Visible = testResult.pass;
        checked { ++index; }
      }
      if (flag)
      {
        this.pnlHeader.BackColor = Color.LightGreen;
        return true;
      }
      this.pnlHeader.BackColor = Color.Salmon;
      return false;
    }

    public bool GetAcceptance(DataRow testRow, bool isCopy)
    {
      bool flag = true;
      bool _cancelScheduled = false;
      bool _passwordPrompt = false;
      ArrayList fails = new ArrayList();
      ScheduleTest[] tests = this._tests;
      int index = 0;
      while (index < tests.Length)
      {
        ScheduleTest.TestResult testResult = tests[index].Test(testRow, Conversions.ToInteger(this.EngineerID), this.CurrentDate);
        if (!testResult.pass)
        {
          IEnumerator enumerator;
          if (testResult.failMessages.Count == 0)
          {
            fails.Add((object) testResult.failMessage);
          }
          else
          {
            try
            {
              enumerator = testResult.failMessages.GetEnumerator();
              while (enumerator.MoveNext())
              {
                string str = Conversions.ToString(enumerator.Current);
                fails.Add((object) str);
              }
            }
            finally
            {
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
          }
          flag = false;
        }
        if (testResult.CancelSchedule)
        {
          _cancelScheduled = testResult.CancelSchedule;
          break;
        }
        if (testResult.PasswordPrompt)
        {
          _passwordPrompt = testResult.PasswordPrompt;
          break;
        }
        checked { ++index; }
      }
      return new FrmOverride(fails, Conversions.ToInteger(testRow["EngineerVisitID"]), isCopy, _cancelScheduled, _passwordPrompt).ShowDialog() == DialogResult.OK;
    }

    public void ResetHeader()
    {
      this.pnlHeader.BackColor = Color.SteelBlue;
      this.picRegion.Visible = false;
      this.picPostalRegions.Visible = false;
      this.picLevels.Visible = false;
      this._testRow = (DataRow) null;
    }

    public DataTable GetDay(string date)
    {
      if (this._dsEngineerSchedule.Tables[date] == null)
      {
        DataTable scheduledJobsDay = App.DB.Scheduler.Get_ScheduledJobsDay(Conversions.ToDate(date), this.EngineerID);
        scheduledJobsDay.TableName = date;
        this._dsEngineerSchedule.Tables.Add(scheduledJobsDay);
      }
      this.DtTimeSlot = App.DB.Scheduler.Scheduler_DayTimeSlots(Conversions.ToDate(this.SelectedDay()), this.EngineerID);
      this.picPlanner.Image = (Image) this.Scheduler_DayTimeSlots_Bitmap();
      this.SetupTimeSheetStatus();
      DataRow[] dataRowArray = this._dsEngineerSchedule.Tables[date].Select("VisitStatusID = " + Conversions.ToString(5));
      if (App.IsGasway)
        this.btnSendText.Visible = dataRowArray.Length > 0;
      this.btnReschedule.Visible = this._dsEngineerSchedule.Tables[date].Select("VisitStatusID IN ( " + Conversions.ToString(5) + " , " + Conversions.ToString(6) + ")").Length > 0;
      this.btnPrintLsr.Visible = this._dsEngineerSchedule.Tables[date].Select("OutcomeEnumID = " + Conversions.ToString(1) + " AND JobTypeID In (" + Conversions.ToString(519) + ", " + Conversions.ToString(4702) + ", " + Conversions.ToString(71443) + ")").Length > 0;
      return this.AddJobStatus(this._dsEngineerSchedule.Tables[date], Conversions.ToDate(date));
    }

    private DataTable AddJobStatus(DataTable dt, DateTime date)
    {
      if (!dt.Columns.Contains("JobStatus"))
        dt.Columns.Add(new DataColumn("JobStatus", typeof (int))
        {
          DefaultValue = (object) false
        });
      if (!dt.Columns.Contains("IsServiceOverDue"))
        dt.Columns.Add(new DataColumn("IsServiceOverDue", typeof (bool))
        {
          DefaultValue = (object) false
        });
      IEnumerator enumerator1;
      try
      {
        enumerator1 = dt.Rows.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRow current = (DataRow) enumerator1.Current;
          current["IsServiceOverDue"] = (object) App.DB.Scheduler.IsSiteOverdue(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["SiteID"])));
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      if ((uint) DateTime.Compare(date.Date, DateTime.Today) > 0U)
        return dt;
      if (!dt.Columns.Contains("IsJobLate"))
        dt.Columns.Add(new DataColumn("IsJobLate", typeof (bool))
        {
          DefaultValue = (object) false
        });
      IEnumerator enumerator2;
      try
      {
        enumerator2 = dt.Rows.GetEnumerator();
        while (enumerator2.MoveNext())
        {
          DataRow current = (DataRow) enumerator2.Current;
          if (!current.Table.Columns.Contains("Declined") || !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["Declined"])))
            current["IsJobLate"] = (object) App.DB.Scheduler.IsVisitLate(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["EngineerVisitID"])));
        }
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      return dt;
    }

    public void Timer_tick(object myObject, EventArgs myEventArgs)
    {
      this.SetupHeartBeat();
      this.RefreshDay();
      this.DisplayLastLocation();
    }

    public void RefreshSummary(string start, string endin)
    {
      this._startDate = start;
      this._endDate = endin;
      this._refreshSummary = new frmEngineerSchedule.refreshSummaryDelegate(this.BeginRefreshSummary).BeginInvoke(new AsyncCallback(this.RefreshSummaryComplete), (object) null);
    }

    public DataTable BeginRefreshSummary()
    {
      DataTable dataTable;
      try
      {
        DataTable summaryNew = App.DB.Scheduler.getSummaryNEW(this.EngineerID, Conversions.ToDate(this._startDate), Conversions.ToDate(this._endDate));
        summaryNew.TableName = "ScheduleSummary";
        dataTable = summaryNew;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        dataTable = (DataTable) null;
        ProjectData.ClearProjectError();
      }
      return dataTable;
    }

    public void RefreshSummaryComplete(IAsyncResult ar)
    {
      try
      {
        DataTable dataTable = ((frmEngineerSchedule.refreshSummaryDelegate) ((AsyncResult) ar).AsyncDelegate).EndInvoke(ar);
        if (dataTable != null & !this.IsFormDisposed)
          this.Invoke((Delegate) new frmEngineerSchedule.setSummaryDelegate(this.SetSummary), (object) dataTable);
        this.opening = false;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public void DisplayLastLocation()
    {
      FSM.Entity.Engineers.Engineer engineer = App.DB.Engineer.Engineer_Get(Conversions.ToInteger(this.EngineerID));
      if (engineer == null)
        return;
      User async = App.DB.User.GetAsync(engineer.ManagerUserID);
      string str1 = "N/A";
      if (async != null)
        str1 = async.Fullname;
      DataView engineerLocation = App.DB.Scheduler.Get_EngineerLocation(Conversions.ToInteger(this.EngineerID));
      string str2 = " : Last update N/A";
      if (engineerLocation.Count > 0)
      {
        string Left = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(engineerLocation[0]["TimeSheetType"]));
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "Working", false) == 0)
          Left += " at";
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "Travelling", false) == 0)
          Left += " to";
        string str3 = App.loggedInUser == null || App.loggedInUser.UserRegions.Table.Select("RegionID = " + Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(engineerLocation[0]["RegionID"])))).Length >= 1 ? Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(engineerLocation[0]["Address1"])) + ", " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(engineerLocation[0]["Postcode"])) : "xxx, " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(engineerLocation[0]["Postcode"])).Substring(0, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(engineerLocation[0]["Postcode"])).IndexOf("-")) + "-xxx";
        str2 = " : Last update " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(engineerLocation[0]["ArrivalTime"])) + " - " + Left + " " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(engineerLocation[0]["JobNumber"])) + ", " + str3;
      }
      this.lblTitle.Text = engineer.Name + " :  Manager: " + str1 + str2;
    }

    public void RefreshDay()
    {
      DateTime dateTime1;
      ref DateTime local1 = ref dateTime1;
      DateTime now1 = DateTime.Now;
      int year1 = now1.Year;
      now1 = DateTime.Now;
      int month1 = now1.Month;
      now1 = DateTime.Now;
      int day1 = now1.Day;
      local1 = new DateTime(year1, month1, day1, 11, 30, 0);
      DateTime dateTime2;
      ref DateTime local2 = ref dateTime2;
      DateTime now2 = DateTime.Now;
      int year2 = now2.Year;
      now2 = DateTime.Now;
      int month2 = now2.Month;
      now2 = DateTime.Now;
      int day2 = now2.Day;
      local2 = new DateTime(year2, month2, day2, 13, 0, 0);
      DateTime dateTime3 = DateTime.Now;
      int num1 = dateTime3.Hour == dateTime1.Hour ? 1 : 0;
      dateTime3 = DateTime.Now;
      int num2 = dateTime3.Minute >= dateTime1.Minute ? 1 : 0;
      dateTime3 = DateTime.Now;
      int minute1 = dateTime3.Minute;
      dateTime3 = dateTime1.AddMinutes(5.0);
      int minute2 = dateTime3.Minute;
      int num3 = minute1 <= minute2 ? 1 : 0;
      int num4 = num2 & num3;
      if ((num1 & num4) != 0)
        this.ShowDay(this.SelectedDay());
      DateTime now3 = DateTime.Now;
      int num5 = now3.Hour == dateTime2.Hour ? 1 : 0;
      now3 = DateTime.Now;
      int num6 = now3.Minute >= dateTime2.Minute & DateTime.Now.Minute <= dateTime1.AddMinutes(5.0).Minute ? 1 : 0;
      if ((num5 & num6) == 0)
        return;
      this.ShowDay(this.SelectedDay());
    }

    public void SetSummary(DataTable dtSummary)
    {
      try
      {
        if (this.dgDaySummary.DataSource != null)
        {
          DataTable table = ((DataView) this.dgDaySummary.DataSource).Table;
          DataView dataView1 = new DataView(dtSummary);
          DataView dataView2 = new DataView(table);
          dataView2.Sort = "dayDate";
          IEnumerator enumerator;
          try
          {
            enumerator = dtSummary.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              int index = dataView2.Find(RuntimeHelpers.GetObjectValue(current["dayDate"]));
              if (index != -1)
              {
                DataRow row = table.Rows[index];
                row["workCount"] = RuntimeHelpers.GetObjectValue(current["workCount"]);
                row["SummedSOR"] = RuntimeHelpers.GetObjectValue(current["SummedSOR"]);
              }
              else
                table.ImportRow(current);
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          this.DtTimeSlot = App.DB.Scheduler.Scheduler_DayTimeSlots(Conversions.ToDate(this.SelectedDay()), this.EngineerID);
          this.picPlanner.Image = (Image) this.Scheduler_DayTimeSlots_Bitmap();
        }
        else
        {
          this.dgDaySummary.DataSource = (object) new DataView(dtSummary);
          Application.DoEvents();
        }
        if (App.loggedInUser.SchedulerDayView)
        {
          int currentRowIndex = this.dgDaySummary.CurrentRowIndex;
          this.dgDaySummary.DataSource = (object) new DataView(dtSummary);
          if (currentRowIndex != -1)
          {
            this.dgDaySummary.Select(currentRowIndex);
            this.ShowDay(this.SelectedDay());
            Application.DoEvents();
          }
        }
        this.btnExportJobs.Visible = dtSummary.Select("workCount > 0").Length > 0;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public void ShowDay(string date)
    {
      this.dgDay.TableStyles[0].MappingName = date;
      this.dgDay.DataSource = (object) new DataView(this.GetDay(date));
    }

    public string SelectedDay()
    {
      if (this.dgDaySummary == null)
        return DateAndTime.Now.ToString();
      DataView dataSource = (DataView) this.dgDaySummary.DataSource;
      this.dgDaySummary.Select(this.dgDaySummary.CurrentRowIndex);
      return Conversions.ToString(dataSource[this.dgDaySummary.CurrentRowIndex]["dayDate"]);
    }

    public void ClearSelections()
    {
      if (this.dgDay.DataSource == null)
        return;
      int num = checked (((DataView) this.dgDay.DataSource).Count - 1);
      int row = 0;
      while (row <= num)
      {
        this.dgDay.UnSelect(row);
        checked { ++row; }
      }
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

    private Bitmap Scheduler_DayTimeSlots_Bitmap()
    {
      if (this.DtTimeSlot == null || this.picPlanner.Height <= 0 || this.picPlanner.Width <= 0)
        return (Bitmap) null;
      Bitmap bitmap = new Bitmap(this.picPlanner.Width, this.picPlanner.Height);
      Graphics graphics1 = Graphics.FromImage((Image) bitmap);
      float width = (float) checked (bitmap.Width - 9) / (float) checked (this.DtTimeSlot.Columns.Count - 1);
      string str = "";
      graphics1.FillRectangle((Brush) new SolidBrush(Color.WhiteSmoke), 0, checked (this.picPlanner.Height - 15), this.picPlanner.Width, 15);
      IEnumerator enumerator;
      try
      {
        enumerator = this.DtTimeSlot.Columns.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataColumn current = (DataColumn) enumerator.Current;
          if (this.DtTimeSlot.Rows.Count > 0 && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.DtTimeSlot.Rows[0][current], (object) 1, false))
            graphics1.FillRectangle((Brush) new SolidBrush(Color.LightSteelBlue), new RectangleF(width * (float) this.DtTimeSlot.Columns.IndexOf(current), 0.0f, width, (float) checked (this.picPlanner.Height - 15)));
          if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current.ColumnName.Substring(1, 2), str, false) > 0U)
          {
            str = current.ColumnName.Substring(1, 2);
            graphics1.DrawLine(new Pen(Color.RoyalBlue), width * (float) this.DtTimeSlot.Columns.IndexOf(current), 0.0f, width * (float) this.DtTimeSlot.Columns.IndexOf(current), (float) checked (this.picPlanner.Height - 12));
            Font font1 = new Font(this.dgDay.Font.Name, 6f, FontStyle.Regular);
            Graphics graphics2 = graphics1;
            string s = str;
            Font font2 = font1;
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            double num1 = (double) width * (double) this.DtTimeSlot.Columns.IndexOf(current);
            SizeF sizeF = graphics1.MeasureString(str, font1);
            double num2 = (double) sizeF.Width / 2.0;
            double num3 = num1 - num2;
            double height1 = (double) this.picPlanner.Height;
            sizeF = graphics1.MeasureString(str, font1);
            double height2 = (double) sizeF.Height;
            double num4 = height1 - height2 - 1.0;
            graphics2.DrawString(s, font2, (Brush) solidBrush, (float) num3, (float) num4);
          }
          else
            graphics1.DrawLine(new Pen(Color.RoyalBlue), width * (float) this.DtTimeSlot.Columns.IndexOf(current), 0.0f, width * (float) this.DtTimeSlot.Columns.IndexOf(current), (float) checked (this.picPlanner.Height - 13));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return bitmap;
    }

    private void frmVisit_SizeChanged(object sender, EventArgs e)
    {
      this.picPlanner.Image = (Image) this.Scheduler_DayTimeSlots_Bitmap();
    }

    private void splitEngineer_SplitterMoved(object sender, SplitterEventArgs e)
    {
      this.picPlanner.Image = (Image) this.Scheduler_DayTimeSlots_Bitmap();
    }

    public void SendToPrint(string fileName = "")
    {
      DataView dataView = App.DB.LetterManager.MakeServiceLetter(this.EngineerVisit.EngineerVisitID);
      dataView.Table.Columns.Add("FileName");
      DataRow row1;
      if (dataView.Count > 0 & string.IsNullOrEmpty(fileName))
      {
        row1 = dataView.Table.Rows[0];
      }
      else
      {
        FSM.Entity.Sites.Site site = App.DB.Sites.Get(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["SiteID"]), SiteSQL.GetBy.SiteId, (object) null);
        DataTable dataTable = dataView.Table.Clone();
        DataRow row2 = dataTable.NewRow();
        row2["Name"] = (object) site.Name;
        row2["Address1"] = (object) site.Address1;
        row2["Address2"] = (object) site.Address2;
        row2["Address3"] = (object) site.Address3;
        row2["Address4"] = (object) site.Address4;
        row2["Address5"] = (object) site.Address5;
        row2["Postcode"] = (object) site.Postcode;
        row2["SiteID"] = (object) site.SiteID;
        row2["CustomerID"] = (object) site.CustomerID;
        row2["SolidFuel"] = (object) site.SolidFuel;
        row2["PropertyVoid"] = (object) site.PropertyVoid;
        row2["LastServiceDate"] = (object) site.LastServiceDate;
        row2["CommercialDistrict"] = (object) site.CommercialDistrict;
        row2["SiteFuel"] = (object) site.SiteFuel;
        row2["Type"] = (object) "Generic";
        row2["NextVisitDate"] = RuntimeHelpers.GetObjectValue(this.SelectedDataRow["StartDateTime"]);
        row2["StartDateTime"] = RuntimeHelpers.GetObjectValue(this.SelectedDataRow["StartDateTime"]);
        row2["AMPM"] = (object) "";
        row2["JobID"] = RuntimeHelpers.GetObjectValue(this.SelectedDataRow["JobID"]);
        row2["JobNumber"] = RuntimeHelpers.GetObjectValue(this.SelectedDataRow["JobNumber"]);
        row2["FileName"] = (object) fileName;
        dataTable.Rows.Add(row2);
        row1 = dataTable.Rows[0];
      }
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) row1
      }, "Service Letter", Enums.SystemDocumentType.ServiceLetters, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
    }

    private void SetupTimeSheetStatus()
    {
      switch (App.DB.Scheduler.getTimesheetStatus(Conversions.ToInteger(this.EngineerID), 0))
      {
        case 1:
          this.picQuestion.Visible = false;
          this.picSpanner.Visible = true;
          this.picVan.Visible = false;
          break;
        case 2:
          this.picQuestion.Visible = false;
          this.picSpanner.Visible = false;
          this.picVan.Visible = true;
          break;
        case 3:
          this.picQuestion.Visible = true;
          this.picSpanner.Visible = false;
          this.picVan.Visible = false;
          break;
      }
    }

    public void SetupHeartBeat()
    {
      HeartBeat latestHeartBeat = App.DB.Scheduler.GetLatestHeartBeat(Conversions.ToInteger(this.EngineerID));
      if (Information.IsDBNull((object) latestHeartBeat.LastHeartBeat))
      {
        this.pbGreen.Visible = false;
        this.pbRed.Visible = false;
      }
      this.LastHeartBeat = latestHeartBeat.LastHeartBeat;
      this.LockedVisitId = latestHeartBeat.LockedVisitID;
      this.HeartLastCheck = latestHeartBeat.LastCheck;
      if (DateTime.Compare(DateTime.Now.AddMinutes(-2.0), this.LastHeartBeat) > 0)
      {
        this.pbGreen.Visible = false;
        this.pbRed.Visible = true;
      }
      else
      {
        this.pbGreen.Visible = true;
        this.pbRed.Visible = false;
      }
    }

    private void PictureBox1_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnSendText_Click(object sender, EventArgs e)
    {
      if (this.SelectedDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Please select a visit", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        try
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedDataRow["VisitStatusID"], (object) Enums.VisitStatus.Scheduled, false))
          {
            FSM.Entity.Sites.Site oSite = App.DB.Sites.Get(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["SiteID"]), SiteSQL.GetBy.SiteId, (object) null);
            if (oSite == null || !oSite.Exists)
              throw new Exception("Site missing");
            string str1 = oSite.FaxNum.Trim();
            if (!Helper.ValidatePhoneNumber(str1))
            {
              int num2 = (int) App.ShowMessage("Mobile number invalid, please update!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
              using (FRMContactInfo frmContactInfo = new FRMContactInfo(oSite))
              {
                int num3 = (int) frmContactInfo.ShowDialog();
                str1 = frmContactInfo.CurrentSite.FaxNum.Trim();
                if (frmContactInfo.DialogResult != DialogResult.Yes | !Helper.ValidatePhoneNumber(str1))
                  throw new Exception("Mobile Number invalid!");
              }
            }
            string empty = string.Empty;
            DateTime date = Conversions.ToDate(this.SelectedDataRow["StartDateTime"]);
            string str2;
            switch (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["AppointmentID"])))
            {
              case 1:
              case 69938:
                str2 = "8:00am - 9:00am";
                break;
              case 2:
              case 69939:
                str2 = "8:00am - 12:00pm";
                break;
              case 3:
              case 69940:
                str2 = "10:00am - 2:00pm";
                break;
              case 4:
              case 69941:
                str2 = "12:00pm - 4:00pm";
                break;
              case 5:
              case 69942:
                str2 = "2:00pm - 6:00pm";
                break;
              case 6:
              case 69943:
                str2 = "8:00am - 1:00pm";
                break;
              case 7:
              case 69944:
                str2 = "12:00pm - 6:00pm";
                break;
              case 8:
              case 69945:
                str2 = "08:00am - 6:00pm";
                break;
              default:
                str2 = date.Hour < 12 ? "8:00am - 1:00pm" : "12:00pm - 6:00pm";
                break;
            }
            TextClient textClient = new TextClient();
            string Message = "CONFIRMATION - Hello, we are happy to confirm that your appointment has been booked for " + date.DayOfWeek.ToString() + " " + date.ToLongDateString() + ". The engineer will arrive between " + str2 + ".";
            textClient.MakeCall(Message, str1, App.TheSystem.Configuration.CompanyName);
            App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("INSERT INTO tblText VALUES (0, GETDATE(),'" + str1 + "',"), this.SelectedDataRow["EngineerVisitID"]), (object) ") ")), true, false);
            ContactAttempt contactAttempt1 = new ContactAttempt();
            ContactAttempt contactAttempt2 = contactAttempt1;
            contactAttempt2.ContactMethedID = 7;
            contactAttempt2.LinkID = 50;
            contactAttempt2.LinkRef = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["EngineerVisitID"]));
            contactAttempt2.ContactMade = DateAndTime.Now;
            contactAttempt2.Notes = Message;
            contactAttempt2.ContactMadeByUserId = App.loggedInUser.UserID;
            App.DB.ContactAttempts.Insert(contactAttempt1);
            int num4 = (int) App.ShowMessage("Text message sent!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num2 = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }
    }

    private void btnExportJobs_Click(object sender, EventArgs e)
    {
      if (this.SelectedDay() == null)
      {
        int num1 = (int) App.ShowMessage("Please select a day", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        DataTable day = this.GetDay(Conversions.ToString(Helper.MakeDateTimeValid((object) this.SelectedDay())));
        if (day.Rows.Count == 0)
        {
          int num2 = (int) App.ShowMessage("No Jobs to Export", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        else
        {
          FSM.Entity.Engineers.Engineer engineer = App.DB.Engineer.Engineer_Get(Conversions.ToInteger(this.EngineerID));
          string str = string.Empty;
          if (engineer != null)
            str = engineer.Name + "_";
          DataTable dtData = new DataTable();
          dtData.Columns.Add("Job Number", typeof (string));
          dtData.Columns.Add("Address 1", typeof (string));
          dtData.Columns.Add("Postcode", typeof (string));
          dtData.Columns.Add("Job Summary", typeof (string));
          dtData.Columns.Add("Notes", typeof (string));
          dtData.Columns.Add("Start", typeof (DateTime));
          dtData.Columns.Add("End", typeof (DateTime));
          dtData.Columns.Add("Status", typeof (string));
          dtData.Columns.Add("Customer", typeof (string));
          dtData.Columns.Add("Type", typeof (string));
          dtData.Columns.Add("SOR", typeof (string));
          dtData.Columns.Add("Est Date", typeof (string));
          IEnumerator enumerator;
          try
          {
            enumerator = day.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              DataRow row = dtData.NewRow();
              row["Job Number"] = RuntimeHelpers.GetObjectValue(current["JobNumber"]);
              row["Address 1"] = RuntimeHelpers.GetObjectValue(current["Address1"]);
              row["Postcode"] = RuntimeHelpers.GetObjectValue(current["PostCode"]);
              row["Job Summary"] = RuntimeHelpers.GetObjectValue(current["JobItems"]);
              row["Notes"] = RuntimeHelpers.GetObjectValue(current["NotesToEngineer"]);
              row["Start"] = (object) Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["StartDateTime"]));
              row["End"] = (object) Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["EndDateTime"]));
              row["Status"] = RuntimeHelpers.GetObjectValue(current["VisitStatus"]);
              row["Customer"] = RuntimeHelpers.GetObjectValue(current["CustomerName"]);
              row["Type"] = RuntimeHelpers.GetObjectValue(current["JobType"]);
              row["SOR"] = RuntimeHelpers.GetObjectValue(current["SummedSOR"]);
              row["Est Date"] = RuntimeHelpers.GetObjectValue(current["EstimatedVisitDate"]);
              dtData.Rows.Add(row);
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          ExportHelper.Export(dtData, str + this.SelectedDay() + "_Jobs", Enums.ExportType.XLS);
        }
      }
    }

    private void picPlanner_MouseUp(object sender, MouseEventArgs e)
    {
      this.detailPopup.MoveMoved(Cursor.Position);
    }

    private void btnPrintLsr_Click(object sender, EventArgs e)
    {
      if (this.SelectedDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Please select a visit", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        try
        {
          if (!(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["JobTypeID"])) == 4702 | Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["JobTypeID"])) == 519 | Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["JobTypeID"])) == 71443))
          {
            int num2 = (int) App.ShowMessage("This job does not have an LSR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
          else if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["OutcomeEnumID"])) == 1)
          {
            Printing printing = new Printing((object) new ArrayList()
            {
              (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["EngineerVisitId"])),
              RuntimeHelpers.GetObjectValue(this.SelectedDataRow["CustomerID"])
            }, "Gas Safety Record ", Enums.SystemDocumentType.GSR, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
          }
          else
          {
            int num3 = (int) App.ShowMessage("This job does not have an LSR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num2 = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          ProjectData.ClearProjectError();
        }
      }
    }

    private void btnReschedule_Click(object sender, EventArgs e)
    {
      int JobID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow?["JobID"]));
      int num1 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow?["EngineerVisitID"]));
      int num2 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow?["StatusEnumID"]));
      if (num1 == 0)
      {
        int num3 = (int) App.ShowMessage("Please select a visit", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        switch (num2)
        {
          case 5:
          case 6:
            FSM.Entity.JobLock.JobLock jobLock = App.DB.JobLock.Check(JobID);
            if (jobLock != null)
            {
              int num4 = (int) MessageBox.Show("This visit cannot be rescheduled because is it currently locked:\r\n" + string.Format("Locked by: {0}", (object) jobLock.NameOfUserWhoLocked) + "\r\n" + string.Format("Date Locked: {0}", (object) jobLock.DateLock) + "\r\n", "Job Lock", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
              break;
            }
            frmSchedulerMain frmSchedulerMain = (frmSchedulerMain) null;
            IEnumerator enumerator;
            try
            {
              enumerator = Application.OpenForms.GetEnumerator();
              while (enumerator.MoveNext())
              {
                Form current = (Form) enumerator.Current;
                if ((object) current.GetType() == (object) typeof (frmSchedulerMain))
                  frmSchedulerMain = (frmSchedulerMain) current;
              }
            }
            finally
            {
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
            int actionId = App.DB.EngineerVisits.EngineerVisit_GetActionID(num1);
            string MessageText = frmSchedulerMain?.scheduler.CanMoveDownloadedVisit(this, num1, actionId);
            if (num2 == 5 | string.IsNullOrEmpty(MessageText))
            {
              using (FRMRescheduleVisit frmRescheduleVisit = new FRMRescheduleVisit(num1))
              {
                int num4 = (int) frmRescheduleVisit.ShowDialog();
              }
              frmSchedulerMain?.scheduler.refreshScheduler();
              break;
            }
            int num5 = (int) App.ShowMessage(MessageText, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            break;
          default:
            int num6 = (int) App.ShowMessage("This visit cannot be rescheduled!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            break;
        }
      }
    }

    private void btnCreateJob_Click(object sender, EventArgs e)
    {
      if (this.SelectedDay() == null)
      {
        int num1 = (int) App.ShowMessage("Please select a day", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        frmSchedulerMain frmSchedulerMain = (frmSchedulerMain) null;
        IEnumerator enumerator;
        try
        {
          enumerator = Application.OpenForms.GetEnumerator();
          while (enumerator.MoveNext())
          {
            Form current = (Form) enumerator.Current;
            if ((object) current.GetType() == (object) typeof (frmSchedulerMain))
              frmSchedulerMain = (frmSchedulerMain) current;
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        using (FRMNewJob frmNewJob = new FRMNewJob(Helper.MakeDateTimeValid((object) this.SelectedDay()), Conversions.ToInteger(this.EngineerID)))
        {
          int num2 = (int) frmNewJob.ShowDialog();
          frmSchedulerMain?.scheduler.refreshScheduler();
        }
      }
    }

    private void btnSiteReport_Click(object sender, EventArgs e)
    {
      if (this.SelectedDataRow == null)
      {
        int num1 = (int) App.ShowMessage("Please select a visit to open the site report", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        FSM.Entity.Sites.Site site = App.DB.Sites.Get(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["SiteID"]), SiteSQL.GetBy.SiteId, (object) null);
        if (site == null || !site.Exists)
        {
          int num2 = (int) App.ShowMessage("Unable to access site!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else
        {
          if (App.loggedInUser.UserRegions.Table.Select("RegionID = " + Conversions.ToString(site.RegionID)).Length < 1)
            throw new SecurityException("You do not have the necessary security permissions.\r\n\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
          PdfFactory.GenerateSiteHistoryReport(site);
        }
      }
    }

    private void dgDay_MouseUp(object sender, MouseEventArgs e)
    {
      this.ttStatus.Hide((IWin32Window) this.dgDay);
      if (this.SelectedDataRow == null)
        return;
      string text = "";
      if (this.SelectedDataRow.Table.Columns.Contains("IsJobLate") && Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["IsJobLate"])))
        text = "Engineer is running late to visit!";
      if (this.SelectedDataRow.Table.Columns.Contains("IsServiceOverDue") && Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["IsServiceOverDue"])))
        text = "Service is overdue on site!";
      if (this.SelectedDataRow.Table.Columns.Contains("Declined") && Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["Declined"])))
        text = "Visit has been declined!";
      if (string.IsNullOrWhiteSpace(text))
        return;
      DataGrid.HitTestInfo hitTestInfo = this.dgDay.HitTest(e.X, e.Y);
      if (hitTestInfo.Type == DataGrid.HitTestType.Cell && hitTestInfo.Column == 0 | hitTestInfo.Column == 1)
        this.ttStatus.Show(text, (IWin32Window) this.dgDay, e.X, e.Y);
    }

    private void dgDay_MouseMove(object sender, MouseEventArgs e)
    {
      DataGrid.HitTestInfo hitTestInfo = this.dgDay.HitTest(e.X, e.Y);
      if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
      {
        if (hitTestInfo.Column == 0 || hitTestInfo.Column == 1)
          return;
        this.ttStatus.Hide((IWin32Window) this.dgDay);
      }
      else
        this.ttStatus.Hide((IWin32Window) this.dgDay);
    }

    private void imgEye_Click(object sender, EventArgs e)
    {
      if (this.Engineer == null)
        return;
      DataTable dtEngineer = this.Engineer.Table.Clone();
      dtEngineer.Rows.Add(this.Engineer.ItemArray);
      using (FRMViewEngineer frmViewEngineer = new FRMViewEngineer(dtEngineer))
      {
        int num = (int) frmViewEngineer.ShowDialog();
      }
    }

    private void mnuVisitAction_Popup(object sender, EventArgs e)
    {
      Enums.VisitStatus visitStatus = (Enums.VisitStatus) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["VisitStatusID"]));
      if (visitStatus == Enums.VisitStatus.Scheduled | visitStatus == Enums.VisitStatus.Downloaded)
      {
        this.btnTextMessage.Visible = true;
        this.btnSolarInstallation.Visible = true;
        this.btnElectricalAppointment.Visible = true;
        this.EngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedDataRow["EngineerVisitID"])), false);
        EngineerVisit engineerVisit = this.EngineerVisit;
        this.btnTextMessage.Text = engineerVisit == null || !engineerVisit.ExcludeFromTextMessage ? "Exclude from auto-messages" : "Include in auto-messages";
        if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.OrObject((object) (this.EngineerVisit.VisitNumber > 0), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.SelectedDataRow["JobTypeID"], (object) 4702, false)), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.SelectedDataRow["JobTypeID"], (object) 519, false))))
          this.btnServiceLetter.Visible = true;
        else
          this.btnServiceLetter.Visible = false;
      }
      else
      {
        this.btnTextMessage.Visible = false;
        this.btnServiceLetter.Visible = false;
        this.btnSolarInstallation.Visible = false;
        this.btnElectricalAppointment.Visible = false;
      }
    }

    private void btnTextMessage_Click(object sender, EventArgs e)
    {
      if (this.EngineerVisit == null)
        return;
      this.EngineerVisit.SetExcludeFromTextMessage = (object) !this.EngineerVisit.ExcludeFromTextMessage;
      App.DB.EngineerVisits.Update(this.EngineerVisit, 0, true);
    }

    private void btnServiceLetter_Click(object sender, EventArgs e)
    {
      if (this.SelectedDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select a visit", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
        this.SendToPrint("");
    }

    private void btnSolarInstallation_Click(object sender, EventArgs e)
    {
      if (this.SelectedDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select a visit", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
        this.SendToPrint("\\ServiceLetters\\SolarAppointment.docx");
    }

    private void btnElectricalAppointment_Click(object sender, EventArgs e)
    {
      if (this.SelectedDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select a visit", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
        this.SendToPrint("\\ServiceLetters\\ElectricalTestingLetter.docx");
    }

    public class StatusDependentDataGridCell : DataGridLabelColumn
    {
      private bool _Selected;

      public StatusDependentDataGridCell()
      {
        this._Selected = true;
      }

      private bool Selected
      {
        get
        {
          return this._Selected;
        }
        set
        {
          this._Selected = value;
        }
      }

      protected override void Paint(
        Graphics g,
        Rectangle bounds,
        CurrencyManager source,
        int rowNum,
        Brush backBrush,
        Brush foreBrush,
        bool alignToRight)
      {
        base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
        string empty = string.Empty;
        DataRow dataRow = (DataRow) NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null);
        int integer = Conversions.ToInteger(dataRow["VisitStatusID"]);
        string s = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow[this.MappingName]));
        SolidBrush solidBrush1 = new SolidBrush(Color.LightGreen);
        SolidBrush solidBrush2 = new SolidBrush(Color.Blue);
        if (integer != 4)
          return;
        Rectangle rect = new Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height);
        if (this.TextBox.Focus())
          g.FillRectangle((Brush) solidBrush2, rect);
        else
          g.FillRectangle((Brush) solidBrush1, rect);
        g.DrawString(s, this.TextBox.Font, foreBrush, (float) checked (bounds.X + 2), (float) checked (bounds.Y + 2));
      }

      protected override void ConcedeFocus()
      {
        this.Selected = false;
      }
    }

    public class visitStatusBar : DataGridLabelColumn
    {
      protected override void Paint(
        Graphics g,
        Rectangle bounds,
        CurrencyManager source,
        int rowNum,
        Brush backBrush,
        Brush foreBrush,
        bool alignToRight)
      {
        base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
        Brush brush = !Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectNotEqual(((DataRow) NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null))["VisitStatusID"], (object) 5, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectNotEqual(((DataRow) NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null))["VisitStatusID"], (object) 4, false))) ? backBrush : (Brush) new SolidBrush(Color.LightGreen);
        g.FillRectangle(brush, bounds);
      }
    }

    public class unavailableBar : DataGridLabelColumn
    {
      protected override void Paint(
        Graphics g,
        Rectangle bounds,
        CurrencyManager source,
        int rowNum,
        Brush backBrush,
        Brush foreBrush,
        bool alignToRight)
      {
        base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
        Brush white = Brushes.White;
        Brush brush1 = Brushes.MidnightBlue;
        object Left = NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
        {
          (object) "AbsenceColumn"
        }, (string[]) null, (System.Type[]) null, (bool[]) null);
        Brush brush2;
        string s;
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) 0, false))
        {
          brush2 = Brushes.White;
          s = "";
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) 1, false))
        {
          brush2 = Brushes.Pink;
          s = "HB";
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) 2, false))
        {
          brush2 = Brushes.Red;
          s = "SI";
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) 3, false))
        {
          brush2 = Brushes.White;
          s = "OT";
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) 4, false))
        {
          brush2 = Brushes.Blue;
          s = "UP";
          brush1 = Brushes.White;
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) 5, false))
        {
          brush2 = Brushes.Orange;
          s = "SE";
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) 6, false))
        {
          brush2 = Brushes.Black;
          s = "TR";
          brush1 = Brushes.White;
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) 7, false))
        {
          brush2 = Brushes.Green;
          s = "AP";
          brush1 = Brushes.White;
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) 8, false))
        {
          brush2 = Brushes.Purple;
          s = "HD";
          brush1 = Brushes.White;
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) 9, false))
        {
          brush2 = Brushes.Yellow;
          s = "BH";
        }
        else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Left, (object) 10, false))
        {
          brush2 = Brushes.Orange;
          s = "CO";
        }
        else
        {
          brush2 = Brushes.White;
          s = "";
        }
        Rectangle rect = bounds;
        g.FillRectangle(brush2, rect);
        g.DrawString(s, this.DataGridTableStyle.DataGrid.Font, brush1, RectangleF.FromLTRB((float) rect.X, (float) rect.Y, (float) rect.Right, (float) rect.Bottom));
      }
    }

    public delegate Hashtable refreshAcceptanceDelegate();

    private delegate void resultsDisplayDelegate(Hashtable results);

    private delegate DataTable refreshSummaryDelegate();

    public delegate void setSummaryDelegate(DataTable dtSummary);
  }
}
