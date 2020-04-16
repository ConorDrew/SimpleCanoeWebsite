// Decompiled with JetBrains decompiler
// Type: FSM.pnlScheduleControl
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class pnlScheduleControl : UserControl
  {
    private string _datesString;
    public int textsize;

    internal virtual Button btnClose
    {
      get
      {
        return this._btnClose;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClose_Click);
        Button btnClose1 = this._btnClose;
        if (btnClose1 != null)
          btnClose1.Click -= eventHandler;
        this._btnClose = value;
        Button btnClose2 = this._btnClose;
        if (btnClose2 == null)
          return;
        btnClose2.Click += eventHandler;
      }
    }

    internal virtual Label lblFromDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnGo
    {
      get
      {
        return this._btnGo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnGo_Click);
        Button btnGo1 = this._btnGo;
        if (btnGo1 != null)
          btnGo1.Click -= eventHandler;
        this._btnGo = value;
        Button btnGo2 = this._btnGo;
        if (btnGo2 == null)
          return;
        btnGo2.Click += eventHandler;
      }
    }

    internal virtual Button btnAbsenceLegend
    {
      get
      {
        return this._btnAbsenceLegend;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAbsenceLegend_Click);
        Button btnAbsenceLegend1 = this._btnAbsenceLegend;
        if (btnAbsenceLegend1 != null)
          btnAbsenceLegend1.Click -= eventHandler;
        this._btnAbsenceLegend = value;
        Button btnAbsenceLegend2 = this._btnAbsenceLegend;
        if (btnAbsenceLegend2 == null)
          return;
        btnAbsenceLegend2.Click += eventHandler;
      }
    }

    internal virtual Button btnBack
    {
      get
      {
        return this._btnBack;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnBack_Click);
        Button btnBack1 = this._btnBack;
        if (btnBack1 != null)
          btnBack1.Click -= eventHandler;
        this._btnBack = value;
        Button btnBack2 = this._btnBack;
        if (btnBack2 == null)
          return;
        btnBack2.Click += eventHandler;
      }
    }

    internal virtual Button btnForward
    {
      get
      {
        return this._btnForward;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnForward_Click);
        Button btnForward1 = this._btnForward;
        if (btnForward1 != null)
          btnForward1.Click -= eventHandler;
        this._btnForward = value;
        Button btnForward2 = this._btnForward;
        if (btnForward2 == null)
          return;
        btnForward2.Click += eventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTextSize { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnTextApply
    {
      get
      {
        return this._btnTextApply;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnTextApply_Click);
        Button btnTextApply1 = this._btnTextApply;
        if (btnTextApply1 != null)
          btnTextApply1.Click -= eventHandler;
        this._btnTextApply = value;
        Button btnTextApply2 = this._btnTextApply;
        if (btnTextApply2 == null)
          return;
        btnTextApply2.Click += eventHandler;
      }
    }

    internal virtual Button btnFind
    {
      get
      {
        return this._btnFind;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFind_Click);
        Button btnFind1 = this._btnFind;
        if (btnFind1 != null)
          btnFind1.Click -= eventHandler;
        this._btnFind = value;
        Button btnFind2 = this._btnFind;
        if (btnFind2 == null)
          return;
        btnFind2.Click += eventHandler;
      }
    }

    internal virtual Button btnNewJob
    {
      get
      {
        return this._btnNewJob;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnNewJob_Click);
        Button btnNewJob1 = this._btnNewJob;
        if (btnNewJob1 != null)
          btnNewJob1.Click -= eventHandler;
        this._btnNewJob = value;
        Button btnNewJob2 = this._btnNewJob;
        if (btnNewJob2 == null)
          return;
        btnNewJob2.Click += eventHandler;
      }
    }

    internal virtual Button btnRefresh
    {
      get
      {
        return this._btnRefresh;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRefresh_Click);
        Button btnRefresh1 = this._btnRefresh;
        if (btnRefresh1 != null)
          btnRefresh1.Click -= eventHandler;
        this._btnRefresh = value;
        Button btnRefresh2 = this._btnRefresh;
        if (btnRefresh2 == null)
          return;
        btnRefresh2.Click += eventHandler;
      }
    }

    public pnlScheduleControl()
    {
      this._datesString = string.Empty;
      this.textsize = 0;
      this.InitializeComponent();
      if (App.loggedInUser.SchedulerTextSize > 0)
      {
        this.txtTextSize.Text = Conversions.ToString(App.loggedInUser.SchedulerTextSize);
        this.textsize = Conversions.ToInteger(this.txtTextSize.Text);
      }
      else
      {
        this.txtTextSize.Text = Conversions.ToString(8);
        this.textsize = Conversions.ToInteger(this.txtTextSize.Text);
      }
    }

    public event pnlScheduleControl.dateRangeChangedEventHandler dateRangeChanged;

    public event pnlScheduleControl.refreshSchedulerEventHandler refreshScheduler;

    public event pnlScheduleControl.closeSchedulerEventHandler closeScheduler;

    public event pnlScheduleControl.displayEngineersEventHandler displayEngineers;

    public event pnlScheduleControl.loadEngineerSchedulesEventHandler loadEngineerSchedules;

    public event pnlScheduleControl.ResizeSchedulingAreaEventHandler ResizeSchedulingArea;

    public DateTime dateFrom
    {
      get
      {
        return this.dtpFromDate.Value;
      }
      set
      {
        this.dtpFromDate.Value = value;
      }
    }

    public DateTime dateTo
    {
      get
      {
        return this.dtpToDate.Value;
      }
      set
      {
        this.dtpToDate.Value = value;
      }
    }

    public string datesString
    {
      get
      {
        if (Operators.CompareString(this._datesString, string.Empty, false) == 0)
        {
          DateTime dateTime1 = this.dateTo;
          dateTime1 = dateTime1.Date;
          int days = dateTime1.Subtract(this.dateFrom.Date).Days;
          int num = 0;
          while (num <= days)
          {
            DateTime dateTime2;
            if (num == 0)
            {
              string& local;
              string str1 = ^(local = ref this._datesString);
              dateTime2 = this.dateFrom;
              dateTime2 = dateTime2.AddDays((double) num);
              string str2 = Strings.Format((object) dateTime2.Date, "yyyy-MM-dd");
              string str3 = str1 + str2;
              local = str3;
            }
            else
            {
              string& local;
              string str1 = ^(local = ref this._datesString);
              dateTime2 = this.dateFrom;
              dateTime2 = dateTime2.AddDays((double) num);
              string str2 = Strings.Format((object) dateTime2.Date, "yyyy-MM-dd");
              string str3 = str1 + "," + str2;
              local = str3;
            }
            checked { ++num; }
          }
        }
        return this._datesString;
      }
    }

    internal virtual DateTimePicker dtpFromDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpToDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual PictureBox picBoxCal1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual PictureBox picBoxCal2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlControls { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnDisplayEngineers
    {
      get
      {
        return this._btnDisplayEngineers;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDisplayEngineers_Click);
        Button displayEngineers1 = this._btnDisplayEngineers;
        if (displayEngineers1 != null)
          displayEngineers1.Click -= eventHandler;
        this._btnDisplayEngineers = value;
        Button displayEngineers2 = this._btnDisplayEngineers;
        if (displayEngineers2 == null)
          return;
        displayEngineers2.Click += eventHandler;
      }
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (pnlScheduleControl));
      this.btnClose = new Button();
      this.dtpFromDate = new DateTimePicker();
      this.dtpToDate = new DateTimePicker();
      this.lblFromDate = new Label();
      this.lblTo = new Label();
      this.btnRefresh = new Button();
      this.pnlControls = new Panel();
      this.btnBack = new Button();
      this.btnForward = new Button();
      this.btnGo = new Button();
      this.picBoxCal1 = new PictureBox();
      this.picBoxCal2 = new PictureBox();
      this.btnDisplayEngineers = new Button();
      this.btnAbsenceLegend = new Button();
      this.Label1 = new Label();
      this.txtTextSize = new TextBox();
      this.btnTextApply = new Button();
      this.btnFind = new Button();
      this.btnNewJob = new Button();
      this.pnlControls.SuspendLayout();
      ((ISupportInitialize) this.picBoxCal1).BeginInit();
      ((ISupportInitialize) this.picBoxCal2).BeginInit();
      this.SuspendLayout();
      this.btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnClose.Location = new System.Drawing.Point(1306, 3);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(56, 23);
      this.btnClose.TabIndex = 5;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.dtpFromDate.Location = new System.Drawing.Point(128, 4);
      this.dtpFromDate.Name = "dtpFromDate";
      this.dtpFromDate.Size = new Size(144, 21);
      this.dtpFromDate.TabIndex = 1;
      this.dtpToDate.Location = new System.Drawing.Point(296, 4);
      this.dtpToDate.Name = "dtpToDate";
      this.dtpToDate.Size = new Size(144, 21);
      this.dtpToDate.TabIndex = 2;
      this.lblFromDate.BackColor = Color.Transparent;
      this.lblFromDate.Location = new System.Drawing.Point(56, 8);
      this.lblFromDate.Name = "lblFromDate";
      this.lblFromDate.Size = new Size(76, 14);
      this.lblFromDate.TabIndex = 3;
      this.lblFromDate.Text = "Diary From";
      this.lblTo.BackColor = Color.Transparent;
      this.lblTo.Location = new System.Drawing.Point(272, 8);
      this.lblTo.Name = "lblTo";
      this.lblTo.Size = new Size(24, 16);
      this.lblTo.TabIndex = 4;
      this.lblTo.Text = "To";
      this.btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnRefresh.Location = new System.Drawing.Point(1244, 3);
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.Size = new Size(56, 23);
      this.btnRefresh.TabIndex = 4;
      this.btnRefresh.Text = "Refresh";
      this.btnRefresh.UseVisualStyleBackColor = true;
      this.pnlControls.BackColor = Color.Transparent;
      this.pnlControls.Controls.Add((Control) this.btnBack);
      this.pnlControls.Controls.Add((Control) this.btnForward);
      this.pnlControls.Controls.Add((Control) this.btnGo);
      this.pnlControls.Controls.Add((Control) this.dtpFromDate);
      this.pnlControls.Controls.Add((Control) this.dtpToDate);
      this.pnlControls.Controls.Add((Control) this.lblFromDate);
      this.pnlControls.Controls.Add((Control) this.lblTo);
      this.pnlControls.Location = new System.Drawing.Point(447, 0);
      this.pnlControls.Name = "pnlControls";
      this.pnlControls.Size = new Size(564, 30);
      this.pnlControls.TabIndex = 7;
      this.btnBack.Location = new System.Drawing.Point(14, 3);
      this.btnBack.Name = "btnBack";
      this.btnBack.Size = new Size(36, 23);
      this.btnBack.TabIndex = 7;
      this.btnBack.Text = "<<";
      this.btnBack.UseVisualStyleBackColor = true;
      this.btnForward.Location = new System.Drawing.Point(494, 3);
      this.btnForward.Name = "btnForward";
      this.btnForward.Size = new Size(36, 23);
      this.btnForward.TabIndex = 6;
      this.btnForward.Text = ">>";
      this.btnForward.UseVisualStyleBackColor = true;
      this.btnGo.Location = new System.Drawing.Point(452, 3);
      this.btnGo.Name = "btnGo";
      this.btnGo.Size = new Size(36, 23);
      this.btnGo.TabIndex = 5;
      this.btnGo.Text = "Go";
      this.btnGo.UseVisualStyleBackColor = true;
      this.picBoxCal1.Image = (Image) componentResourceManager.GetObject("picBoxCal1.Image");
      this.picBoxCal1.Location = new System.Drawing.Point(0, 0);
      this.picBoxCal1.Name = "picBoxCal1";
      this.picBoxCal1.Size = new Size(120, 32);
      this.picBoxCal1.TabIndex = 8;
      this.picBoxCal1.TabStop = false;
      this.picBoxCal2.Image = (Image) componentResourceManager.GetObject("picBoxCal2.Image");
      this.picBoxCal2.Location = new System.Drawing.Point(117, 0);
      this.picBoxCal2.Name = "picBoxCal2";
      this.picBoxCal2.Size = new Size(267, 30);
      this.picBoxCal2.SizeMode = PictureBoxSizeMode.StretchImage;
      this.picBoxCal2.TabIndex = 9;
      this.picBoxCal2.TabStop = false;
      this.btnDisplayEngineers.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnDisplayEngineers.Location = new System.Drawing.Point(1182, 3);
      this.btnDisplayEngineers.Name = "btnDisplayEngineers";
      this.btnDisplayEngineers.Size = new Size(56, 23);
      this.btnDisplayEngineers.TabIndex = 3;
      this.btnDisplayEngineers.Text = "Display";
      this.btnDisplayEngineers.UseVisualStyleBackColor = true;
      this.btnAbsenceLegend.Location = new System.Drawing.Point(3, 3);
      this.btnAbsenceLegend.Name = "btnAbsenceLegend";
      this.btnAbsenceLegend.Size = new Size(135, 23);
      this.btnAbsenceLegend.TabIndex = 10;
      this.btnAbsenceLegend.Text = "Absence Colour Key";
      this.btnAbsenceLegend.UseVisualStyleBackColor = true;
      this.Label1.BackColor = Color.Transparent;
      this.Label1.Location = new System.Drawing.Point(162, 10);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(89, 14);
      this.Label1.TabIndex = 11;
      this.Label1.Text = "Text Size 6-12";
      this.txtTextSize.Location = new System.Drawing.Point(257, 5);
      this.txtTextSize.Name = "txtTextSize";
      this.txtTextSize.Size = new Size(41, 21);
      this.txtTextSize.TabIndex = 12;
      this.btnTextApply.Location = new System.Drawing.Point(316, 4);
      this.btnTextApply.Name = "btnTextApply";
      this.btnTextApply.Size = new Size(47, 23);
      this.btnTextApply.TabIndex = 13;
      this.btnTextApply.Text = "Apply";
      this.btnTextApply.UseVisualStyleBackColor = true;
      this.btnFind.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFind.Location = new System.Drawing.Point(1120, 3);
      this.btnFind.Name = "btnFind";
      this.btnFind.Size = new Size(56, 23);
      this.btnFind.TabIndex = 14;
      this.btnFind.Text = "Find";
      this.btnFind.UseVisualStyleBackColor = true;
      this.btnNewJob.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnNewJob.Location = new System.Drawing.Point(1052, 3);
      this.btnNewJob.Name = "btnNewJob";
      this.btnNewJob.Size = new Size(62, 23);
      this.btnNewJob.TabIndex = 15;
      this.btnNewJob.Text = "New Job";
      this.btnNewJob.UseVisualStyleBackColor = true;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.btnNewJob);
      this.Controls.Add((Control) this.btnFind);
      this.Controls.Add((Control) this.btnTextApply);
      this.Controls.Add((Control) this.txtTextSize);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.btnAbsenceLegend);
      this.Controls.Add((Control) this.pnlControls);
      this.Controls.Add((Control) this.btnDisplayEngineers);
      this.Controls.Add((Control) this.picBoxCal2);
      this.Controls.Add((Control) this.picBoxCal1);
      this.Controls.Add((Control) this.btnRefresh);
      this.Controls.Add((Control) this.btnClose);
      this.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = nameof (pnlScheduleControl);
      this.Size = new Size(1370, 30);
      this.pnlControls.ResumeLayout(false);
      ((ISupportInitialize) this.picBoxCal1).EndInit();
      ((ISupportInitialize) this.picBoxCal2).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
      this.dtpToDate.MinDate = this.dtpFromDate.Value;
      this._datesString = string.Empty;
      // ISSUE: reference to a compiler-generated field
      pnlScheduleControl.refreshSchedulerEventHandler refreshSchedulerEvent = this.refreshSchedulerEvent;
      if (refreshSchedulerEvent == null)
        return;
      refreshSchedulerEvent();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      pnlScheduleControl.closeSchedulerEventHandler closeSchedulerEvent = this.closeSchedulerEvent;
      if (closeSchedulerEvent == null)
        return;
      closeSchedulerEvent();
    }

    protected override void OnResize(EventArgs e)
    {
      this.pnlControls.Left = checked ((int) Math.Round(unchecked ((double) this.Width / 2.0 - (double) this.pnlControls.Width / 2.0)));
      this.picBoxCal2.Width = checked ((int) Math.Round(unchecked ((double) this.Width * 0.21)) - this.picBoxCal1.Width);
    }

    private void btnDisplayEngineers_Click(object sender, EventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      pnlScheduleControl.displayEngineersEventHandler displayEngineersEvent = this.displayEngineersEvent;
      if (displayEngineersEvent == null)
        return;
      displayEngineersEvent();
    }

    private void btnDay_Click(object sender, EventArgs e)
    {
      this.dtpFromDate.Value = DateAndTime.Now;
      this.dtpToDate.Value = DateAndTime.Now;
    }

    private void btnWeek_Click(object sender, EventArgs e)
    {
      this.dtpFromDate.Value = DateAndTime.Now;
      this.dtpToDate.Value = DateAndTime.Now.AddDays(7.0);
    }

    private void btnMonth_Click(object sender, EventArgs e)
    {
      this.dtpFromDate.Value = DateAndTime.Now;
      this.dtpToDate.Value = DateAndTime.Now.AddMonths(1);
    }

    private void btnGo_Click(object sender, EventArgs e)
    {
      this.dtpToDate.MinDate = this.dtpFromDate.Value;
      this._datesString = string.Empty;
      // ISSUE: reference to a compiler-generated field
      pnlScheduleControl.dateRangeChangedEventHandler rangeChangedEvent = this.dateRangeChangedEvent;
      if (rangeChangedEvent == null)
        return;
      rangeChangedEvent(this.dtpFromDate.Value, this.dtpToDate.Value);
    }

    private void btnAbsenceLegend_Click(object sender, EventArgs e)
    {
      int num = (int) new FRMAbsenceColourKey().ShowDialog();
    }

    private void btnForward_Click(object sender, EventArgs e)
    {
      DateTimePicker dtpFromDate = this.dtpFromDate;
      DateTime dateTime1 = this.dtpFromDate.Value;
      dateTime1 = dateTime1.AddDays(1.0);
      DateTime date1 = Conversions.ToDate(dateTime1.ToString("dd/MM/yyyy"));
      dtpFromDate.Value = date1;
      DateTimePicker dtpToDate = this.dtpToDate;
      DateTime dateTime2 = this.dtpToDate.Value;
      dateTime2 = dateTime2.AddDays(1.0);
      DateTime date2 = Conversions.ToDate(dateTime2.ToString("dd/MM/yyyy"));
      dtpToDate.Value = date2;
      this._datesString = string.Empty;
      // ISSUE: reference to a compiler-generated field
      pnlScheduleControl.dateRangeChangedEventHandler rangeChangedEvent = this.dateRangeChangedEvent;
      if (rangeChangedEvent == null)
        return;
      rangeChangedEvent(this.dtpFromDate.Value, this.dtpToDate.Value);
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
      DateTimePicker dtpFromDate = this.dtpFromDate;
      DateTime dateTime1 = this.dtpFromDate.Value;
      dateTime1 = dateTime1.AddDays(-1.0);
      DateTime date1 = Conversions.ToDate(dateTime1.ToString("dd/MM/yyyy"));
      dtpFromDate.Value = date1;
      DateTimePicker dtpToDate = this.dtpToDate;
      DateTime dateTime2 = this.dtpToDate.Value;
      dateTime2 = dateTime2.AddDays(-1.0);
      DateTime date2 = Conversions.ToDate(dateTime2.ToString("dd/MM/yyyy"));
      dtpToDate.Value = date2;
      this._datesString = string.Empty;
      // ISSUE: reference to a compiler-generated field
      pnlScheduleControl.dateRangeChangedEventHandler rangeChangedEvent = this.dateRangeChangedEvent;
      if (rangeChangedEvent == null)
        return;
      rangeChangedEvent(this.dtpFromDate.Value, this.dtpToDate.Value);
    }

    private void btnTextApply_Click(object sender, EventArgs e)
    {
      if (((this.txtTextSize.Text.Length <= 0 || !Versioned.IsNumeric((object) this.txtTextSize.Text) ? 0 : (Conversions.ToDouble(this.txtTextSize.Text) > 5.0 ? 1 : 0)) & (Conversions.ToDouble(this.txtTextSize.Text) < 13.0 ? 1 : 0)) != 0)
      {
        App.DB.User.User_Update_TextSize(App.loggedInUser.UserID, Conversions.ToInteger(this.txtTextSize.Text));
        App.loggedInUser.SetSchedulerTextSize = (object) Conversions.ToInteger(this.txtTextSize.Text);
        this.textsize = Conversions.ToInteger(this.txtTextSize.Text);
        // ISSUE: reference to a compiler-generated field
        pnlScheduleControl.ResizeSchedulingAreaEventHandler schedulingAreaEvent = this.ResizeSchedulingAreaEvent;
        if (schedulingAreaEvent == null)
          return;
        schedulingAreaEvent();
      }
      else
      {
        int num = (int) App.ShowMessage("Please enter a valid text Size", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void btnFind_Click(object sender, EventArgs e)
    {
      int num = (int) new FRMSchedulerFind().ShowDialog();
    }

    private void btnNewJob_Click(object sender, EventArgs e)
    {
      using (FRMNewJob frmNewJob = new FRMNewJob(DateTime.MinValue, 0))
      {
        int num = (int) frmNewJob.ShowDialog();
      }
      // ISSUE: reference to a compiler-generated field
      pnlScheduleControl.refreshSchedulerEventHandler refreshSchedulerEvent = this.refreshSchedulerEvent;
      if (refreshSchedulerEvent == null)
        return;
      refreshSchedulerEvent();
    }

    public delegate void dateRangeChangedEventHandler(DateTime fromDate, DateTime toDate);

    public delegate void refreshSchedulerEventHandler();

    public delegate void closeSchedulerEventHandler();

    public delegate void displayEngineersEventHandler();

    public delegate void loadEngineerSchedulesEventHandler(DateTime fromDate, DateTime toDate);

    public delegate void ResizeSchedulingAreaEventHandler();
  }
}
