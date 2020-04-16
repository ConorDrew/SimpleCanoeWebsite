// Decompiled with JetBrains decompiler
// Type: FSM.Scheduler
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.EngineerVisits;
using FSM.Entity.HeartBeats;
using FSM.Entity.Scheduler;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows.Forms;

namespace FSM
{
  public class Scheduler
  {
    private ArrayList _engineerSchedules;
    private pnlScheduleControl _ScheduleControl;
    private object _engineerScheduleColumnCount;
    private object _engineerScheduleHeight;
    public DateTime FromDate;
    public DateTime ToDate;
    private int _OldEngineerVisitID;
    public DataTable DtSummary;
    public int textsize;
    private DataTable _engineers;
    private bool Closing;
    private TimeSpan TwoMins;
    private bool endSummaryRefresh;
    private IAsyncResult refreshPeopleSchedulesAsyncResult;
    private const int radius = 3;
    private System.Drawing.Point clickedPoint;
    private bool cellDown;
    private System.Drawing.Point mousePos;
    private FSM.Scheduler.setScheduleDropIconsDelegate scheduleDropIcons;
    private IAsyncResult ScheduleDropIconsAsyncResult;
    private bool endDropIconsRefresh;

    private virtual Form _mdiParent { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    private virtual pnlUnscheduledCalls _unscheduledCalls { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    private virtual MdiClient _mdiClient { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public bool scheduleRowManipulation(
      ref DataRowView scheduleRow,
      int forEngineer,
      DateTime forDate,
      bool copy,
      ref int appointment = 0)
    {
      int integer = Conversions.ToInteger(scheduleRow["EngineerVisitID"]);
      scheduleRow.BeginEdit();
      if (copy)
      {
        this._OldEngineerVisitID = Conversions.ToInteger(scheduleRow["EngineerVisitID"]);
        scheduleRow["EngineerVisitID"] = (object) 0;
      }
      bool flag;
      if ((uint) forEngineer > 0U)
      {
        frmVisit frmVisit = new frmVisit(forEngineer, forDate, Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(scheduleRow["SummedSOR"])), integer, copy);
        flag = frmVisit.ShowDialog() == DialogResult.OK;
        if (frmVisit.mulitpleVisits)
        {
          int num = 0;
          try
          {
            foreach (List<DateTime> visits in frmVisit.VisitsList)
            {
              if (num == 0)
              {
                scheduleRow["StartDateTime"] = (object) visits[0];
                scheduleRow["EndDateTime"] = (object) visits[1];
                checked { ++num; }
              }
              else
              {
                EngineerVisit oEngineerVisit = new EngineerVisit();
                oEngineerVisit.IgnoreExceptionsOnSetMethods = true;
                oEngineerVisit.SetJobOfWorkID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(scheduleRow["JobOfWorkID"]));
                oEngineerVisit.SetEngineerID = (object) forEngineer;
                oEngineerVisit.StartDateTime = visits[0];
                oEngineerVisit.EndDateTime = visits[1];
                oEngineerVisit.SetStatusEnumID = (object) 5;
                oEngineerVisit.SetNotesToEngineer = RuntimeHelpers.GetObjectValue(scheduleRow["NotesToEngineer"]);
                oEngineerVisit.SetAppointmentID = (object) frmVisit.AppointmentType;
                int JobID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(scheduleRow["JobID"]));
                App.DB.EngineerVisits.Insert(oEngineerVisit, JobID, frmVisit.AppointmentType, 0);
              }
            }
          }
          finally
          {
            List<List<DateTime>>.Enumerator enumerator;
            enumerator.Dispose();
          }
        }
        else
        {
          scheduleRow["StartDateTime"] = (object) frmVisit.StartDate;
          scheduleRow["EndDateTime"] = (object) frmVisit.EndDate;
        }
        scheduleRow["visitstatusid"] = (object) Enums.VisitStatus.Scheduled;
        scheduleRow["visitstatus"] = (object) "Scheduled";
        scheduleRow["engineerID"] = (object) forEngineer;
        scheduleRow["AppointmentID"] = (object) frmVisit.AppointmentType;
        appointment = frmVisit.AppointmentType;
      }
      else
      {
        scheduleRow["visitstatusid"] = (object) Enums.VisitStatus.Ready_For_Schedule;
        scheduleRow["visitstatus"] = (object) "Ready For Schedule";
        scheduleRow["engineerId"] = (object) 0;
        scheduleRow["StartDateTime"] = (object) DBNull.Value;
        scheduleRow["EndDateTime"] = (object) DBNull.Value;
        flag = true;
      }
      scheduleRow.EndEdit();
      return flag;
    }

    public bool canMoveRow(ref DataRowView scheduleRow, ref bool heartOk)
    {
      return Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(scheduleRow["visitstatusid"], (object) Enums.VisitStatus.Scheduled, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(scheduleRow["visitstatusid"], (object) Enums.VisitStatus.Ready_For_Schedule, false))) || Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(scheduleRow["visitstatusid"], (object) Enums.VisitStatus.Downloaded, false);
    }

    public DataTable Engineers
    {
      get
      {
        return this._engineers;
      }
      set
      {
        this._engineers = value;
      }
    }

    public Scheduler(Form mdiParent)
    {
      this._engineerSchedules = new ArrayList();
      this._engineerScheduleColumnCount = (object) 1;
      this._engineerScheduleHeight = (object) 200;
      this.FromDate = DateAndTime.Now;
      this.ToDate = DateAndTime.Now.AddDays(10.0);
      this._OldEngineerVisitID = 0;
      this._engineers = (DataTable) null;
      this.Closing = false;
      this.TwoMins = new TimeSpan(0, 2, 0);
      this.cellDown = false;
      this.scheduleDropIcons = new FSM.Scheduler.setScheduleDropIconsDelegate(this.SetScheduleDropIconsBegin);
      IEnumerator enumerator;
      try
      {
        enumerator = mdiParent.Controls.GetEnumerator();
        while (enumerator.MoveNext())
        {
          Control current = (Control) enumerator.Current;
          if (current is MdiClient)
          {
            this._mdiClient = (MdiClient) current;
            break;
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this._mdiParent = mdiParent;
      this.LoadEngineers();
    }

    public void LoadEngineers()
    {
      DataTable table = App.DB.Engineer.Engineer_GetAll_Scheduler().Table;
      table.Columns.Add(new DataColumn("Include", typeof (bool))
      {
        DefaultValue = (object) true
      });
      table.AcceptChanges();
      IEnumerator enumerator;
      try
      {
        enumerator = table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRow) enumerator.Current)["Include"] = (object) false;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.Engineers = table;
    }

    private bool CheckSchedulesAreOpening()
    {
      bool flag = false;
      IEnumerator enumerator;
      try
      {
        enumerator = this._engineerSchedules.GetEnumerator();
        while (enumerator.MoveNext())
        {
          if (((frmEngineerSchedule) enumerator.Current).opening)
            flag = true;
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return flag;
    }

    public void loadEngineerSchedules(DateTime dateFrom, DateTime dateTo)
    {
      try
      {
        this._mdiClient.Resize -= new EventHandler(this.ControlResize);
        this._unscheduledCalls.Resize -= new EventHandler(this.ControlResize);
        this.FromDate = dateFrom;
        this.ToDate = dateTo;
        Cursor.Current = Cursors.WaitCursor;
        this._mdiClient.Enabled = false;
        int num1 = 0;
        DataRow[] dataRowArray = this.Engineers.Select("Include");
        int index = 0;
        while (index < dataRowArray.Length)
        {
          DataRow Engineer = dataRowArray[index];
          Size clientSize = this._mdiClient.ClientSize;
          double a;
          if (Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.IntDivideObject((object) clientSize.Width, this._engineerScheduleColumnCount)) != a)
          {
            clientSize = this._mdiClient.ClientSize;
            a = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.IntDivideObject((object) clientSize.Width, this._engineerScheduleColumnCount));
            IEnumerator enumerator;
            try
            {
              enumerator = this._engineerSchedules.GetEnumerator();
              while (enumerator.MoveNext())
                ((Control) enumerator.Current).Width = checked ((int) Math.Round(a));
            }
            finally
            {
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
          }
          checked { ++num1; }
          int integer = Conversions.ToInteger(NewLateBinding.LateGet((object) null, typeof (Math), "Ceiling", new object[1]
          {
            Microsoft.VisualBasic.CompilerServices.Operators.DivideObject((object) num1, this._engineerScheduleColumnCount)
          }, (string[]) null, (System.Type[]) null, (bool[]) null));
          int num2 = checked ((int) Math.Floor(unchecked ((double) num1 / (double) integer)));
          frmEngineerSchedule engineerSchedule = new frmEngineerSchedule(new MouseEventHandler(this.gridMouseDown), new MouseEventHandler(this.gridMouseMove), new DragEventHandler(this.gridDragOver), new DragEventHandler(this.gridDragDrop), new MouseEventHandler(this.gridMouseUp), Engineer, this._ScheduleControl.textsize);
          engineerSchedule.FormClosing += new FormClosingEventHandler(this.ScheduleClosing);
          engineerSchedule.StartPosition = FormStartPosition.Manual;
          engineerSchedule.MdiParent = this._mdiParent;
          engineerSchedule.Left = checked ((int) Math.Round(unchecked (a * (double) checked (num2 - 1))));
          engineerSchedule.Width = checked ((int) Math.Round(a));
          engineerSchedule.Top = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(this._engineerScheduleHeight, (object) checked (integer - 1)));
          engineerSchedule.Height = Conversions.ToInteger(this._engineerScheduleHeight);
          engineerSchedule.Show();
          Application.DoEvents();
          this._engineerSchedules.Add((object) engineerSchedule);
          checked { ++index; }
        }
        this._mdiClient.Resize += new EventHandler(this.ControlResize);
        this._unscheduledCalls.Resize += new EventHandler(this.ControlResize);
        this._mdiClient.Enabled = true;
        Cursor.Current = Cursors.Default;
        this.refreshScheduler();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public void ScheduleClosing(object sender, FormClosingEventArgs e)
    {
      bool? nullable;
      while (this.CheckSchedulesAreOpening() | !this.refreshPeopleSchedulesAsyncResult.IsCompleted)
      {
        nullable = App.loggedInUser?.HasAccessToModule(Enums.SecuritySystemModules.BetaFeatures);
        nullable = nullable.HasValue ? new bool?(!nullable.GetValueOrDefault()) : nullable;
        if (nullable.GetValueOrDefault())
          Thread.Sleep(100);
      }
      e.Cancel = true;
      frmEngineerSchedule engineerSchedule = (frmEngineerSchedule) sender;
      engineerSchedule.Hide();
      this._engineerSchedules.Remove((object) engineerSchedule);
      engineerSchedule.EngineerScheduleTimer.Stop();
      engineerSchedule.EngineerScheduleTimer.Dispose();
      engineerSchedule.Dispose();
      while (engineerSchedule.opening)
      {
        nullable = App.loggedInUser?.HasAccessToModule(Enums.SecuritySystemModules.BetaFeatures);
        nullable = nullable.HasValue ? new bool?(!nullable.GetValueOrDefault()) : nullable;
        if (nullable.GetValueOrDefault())
          Thread.Sleep(100);
      }
      this.orderScheduleWindows();
    }

    public void reset()
    {
      this.orderScheduleWindows();
      this.refreshPeopleSchedules();
      this.loadWork(this._ScheduleControl.dateFrom, this._ScheduleControl.dateTo);
    }

    public void close()
    {
      while (this.CheckSchedulesAreOpening() | !this.refreshPeopleSchedulesAsyncResult.IsCompleted)
      {
        bool? nullable = App.loggedInUser?.HasAccessToModule(Enums.SecuritySystemModules.BetaFeatures);
        nullable = nullable.HasValue ? new bool?(!nullable.GetValueOrDefault()) : nullable;
        if (nullable.GetValueOrDefault())
          Thread.Sleep(100);
      }
      this.Closing = true;
      IEnumerator enumerator;
      try
      {
        enumerator = this._engineerSchedules.GetEnumerator();
        while (enumerator.MoveNext())
          ((Component) enumerator.Current).Dispose();
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      if (this._unscheduledCalls != null)
      {
        this._unscheduledCalls.Hide();
        if (this._unscheduledCalls.unscheduledCalls != null)
          this._unscheduledCalls.unscheduledCalls.Clear();
      }
      if (this._engineerSchedules != null)
        this._engineerSchedules.Clear();
      this._mdiParent.Dispose();
    }

    public void ResizeSchedulingArea()
    {
      this._mdiParent.Controls.Remove((Control) this._unscheduledCalls);
      this._mdiParent.Controls.Remove((Control) this._ScheduleControl);
      this.Closing = false;
      this._unscheduledCalls = new pnlUnscheduledCalls(new MouseEventHandler(this.gridMouseDown), new MouseEventHandler(this.gridMouseMove), new DragEventHandler(this.gridDragOver), new DragEventHandler(this.gridDragDrop), new MouseEventHandler(this.gridMouseUp), App.loggedInUser.SchedulerTextSize <= 0 ? 8 : App.loggedInUser.SchedulerTextSize);
      this._unscheduledCalls.Dock = DockStyle.Left;
      this._mdiParent.Controls.Add((Control) this._unscheduledCalls);
      this._ScheduleControl.Dock = DockStyle.Top;
      this._mdiParent.Controls.Add((Control) this._ScheduleControl);
      this.LoadUnscheduledWork();
      IEnumerator enumerator1;
      try
      {
        enumerator1 = this._engineerSchedules.ToArray(typeof (frmEngineerSchedule)).GetEnumerator();
        while (enumerator1.MoveNext())
        {
          frmEngineerSchedule current = (frmEngineerSchedule) enumerator1.Current;
          current.Close();
          current.Dispose();
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      if (!this.Closing)
        this.loadEngineerSchedules(this._ScheduleControl.dateFrom, this._ScheduleControl.dateTo);
      Application.DoEvents();
      if (App.loggedInUser.SchedulerDayView)
      {
        this._ScheduleControl.dateFrom = this.FromDate;
        this._ScheduleControl.dateTo = this.FromDate;
        this._ScheduleControl.btnBack.Visible = true;
        this._ScheduleControl.btnForward.Visible = true;
        IEnumerator enumerator2;
        try
        {
          enumerator2 = this.Engineers.Rows.GetEnumerator();
          while (enumerator2.MoveNext())
          {
            DataRow current = (DataRow) enumerator2.Current;
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["EngineerGroupID"], (object) App.loggedInUser.DefaultEngineerGroup, false))
              current["include"] = (object) 1;
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
        bool? nullable;
        if (this.refreshPeopleSchedulesAsyncResult != null)
        {
          this.endSummaryRefresh = true;
          while (!this.refreshPeopleSchedulesAsyncResult.IsCompleted)
          {
            nullable = App.loggedInUser?.HasAccessToModule(Enums.SecuritySystemModules.BetaFeatures);
            nullable = nullable.HasValue ? new bool?(!nullable.GetValueOrDefault()) : nullable;
            if (nullable.GetValueOrDefault())
              Thread.Sleep(50);
            Application.DoEvents();
          }
        }
        if (this.ScheduleDropIconsAsyncResult != null)
        {
          this.endDropIconsRefresh = true;
          while (!this.ScheduleDropIconsAsyncResult.IsCompleted)
          {
            nullable = App.loggedInUser?.HasAccessToModule(Enums.SecuritySystemModules.BetaFeatures);
            nullable = nullable.HasValue ? new bool?(!nullable.GetValueOrDefault()) : nullable;
            if (nullable.GetValueOrDefault())
              Thread.Sleep(50);
            Application.DoEvents();
          }
        }
        IEnumerator enumerator3;
        try
        {
          enumerator3 = this._engineerSchedules.ToArray(typeof (frmEngineerSchedule)).GetEnumerator();
          while (enumerator3.MoveNext())
          {
            frmEngineerSchedule current = (frmEngineerSchedule) enumerator3.Current;
            current.Close();
            current.Dispose();
          }
        }
        finally
        {
          if (enumerator3 is IDisposable)
            (enumerator3 as IDisposable).Dispose();
        }
        this._mdiClient.ResumeLayout(false);
        this._mdiClient.Visible = true;
        this._engineerSchedules.Clear();
        this.loadEngineerSchedules(this.FromDate, this.ToDate);
        Application.DoEvents();
        Cursor.Current = Cursors.Default;
      }
      else
      {
        this._ScheduleControl.btnBack.Visible = false;
        this._ScheduleControl.btnForward.Visible = false;
      }
    }

    public void Open()
    {
      this.Closing = false;
      int TEXTSIZEs = App.loggedInUser.SchedulerTextSize <= 0 ? 7 : App.loggedInUser.SchedulerTextSize;
      if (this._unscheduledCalls == null)
      {
        this._unscheduledCalls = new pnlUnscheduledCalls(new MouseEventHandler(this.gridMouseDown), new MouseEventHandler(this.gridMouseMove), new DragEventHandler(this.gridDragOver), new DragEventHandler(this.gridDragDrop), new MouseEventHandler(this.gridMouseUp), TEXTSIZEs);
        this._unscheduledCalls.Dock = DockStyle.Left;
        this._mdiParent.Controls.Add((Control) this._unscheduledCalls);
      }
      if (this._ScheduleControl == null)
      {
        this._ScheduleControl = new pnlScheduleControl();
        this._ScheduleControl.dateFrom = this.FromDate;
        this._ScheduleControl.dateTo = this.ToDate;
        this._ScheduleControl.dateRangeChanged += new pnlScheduleControl.dateRangeChangedEventHandler(this.loadWork);
        this._ScheduleControl.refreshScheduler += new pnlScheduleControl.refreshSchedulerEventHandler(this.refreshScheduler);
        this._ScheduleControl.closeScheduler += new pnlScheduleControl.closeSchedulerEventHandler(this.close);
        this._ScheduleControl.displayEngineers += new pnlScheduleControl.displayEngineersEventHandler(this.displayEngineers);
        this._ScheduleControl.loadEngineerSchedules += new pnlScheduleControl.loadEngineerSchedulesEventHandler(this.loadEngineerSchedules);
        this._ScheduleControl.ResizeSchedulingArea += new pnlScheduleControl.ResizeSchedulingAreaEventHandler(this.ResizeSchedulingArea);
        this._ScheduleControl.Dock = DockStyle.Top;
        this._mdiParent.Controls.Add((Control) this._ScheduleControl);
      }
      if (!this.Closing)
        this.loadEngineerSchedules(this._ScheduleControl.dateFrom, this._ScheduleControl.dateTo);
      Application.DoEvents();
      if (App.loggedInUser.SchedulerDayView)
      {
        this._ScheduleControl.dateFrom = this.FromDate;
        this._ScheduleControl.dateTo = this.FromDate;
        this._ScheduleControl.btnBack.Visible = true;
        this._ScheduleControl.btnForward.Visible = true;
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.Engineers.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["EngineerGroupID"], (object) App.loggedInUser.DefaultEngineerGroup, false))
              current["include"] = (object) 1;
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        if (this.refreshPeopleSchedulesAsyncResult != null)
        {
          this.endSummaryRefresh = true;
          while (!this.refreshPeopleSchedulesAsyncResult.IsCompleted)
          {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.BetaFeatures))
              Thread.Sleep(50);
            Application.DoEvents();
          }
        }
        if (this.ScheduleDropIconsAsyncResult != null)
        {
          this.endDropIconsRefresh = true;
          while (!this.ScheduleDropIconsAsyncResult.IsCompleted)
          {
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.BetaFeatures))
              Thread.Sleep(50);
            Application.DoEvents();
          }
        }
        IEnumerator enumerator2;
        try
        {
          enumerator2 = this._engineerSchedules.ToArray(typeof (frmEngineerSchedule)).GetEnumerator();
          while (enumerator2.MoveNext())
          {
            frmEngineerSchedule current = (frmEngineerSchedule) enumerator2.Current;
            current.Close();
            current.Dispose();
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
        this._mdiClient.ResumeLayout(false);
        this._mdiClient.Visible = true;
        this._engineerSchedules.Clear();
        this.loadEngineerSchedules(this.FromDate, this.ToDate);
        Application.DoEvents();
        Cursor.Current = Cursors.Default;
      }
      else
      {
        this._ScheduleControl.btnBack.Visible = false;
        this._ScheduleControl.btnForward.Visible = false;
      }
    }

    public void displayEngineers()
    {
      this.Closing = false;
      this._mdiClient.Resize -= new EventHandler(this.ControlResize);
      this._unscheduledCalls.Resize -= new EventHandler(this.ControlResize);
      int num = (int) new FrmDisplayEngineers()
      {
        EngineersDataView = new DataView(this.Engineers)
      }.ShowDialog();
      this._mdiClient.Visible = false;
      this._mdiClient.SuspendLayout();
      Cursor.Current = Cursors.WaitCursor;
      bool? nullable;
      if (this.refreshPeopleSchedulesAsyncResult != null)
      {
        this.endSummaryRefresh = true;
        while (!this.refreshPeopleSchedulesAsyncResult.IsCompleted)
        {
          nullable = App.loggedInUser?.HasAccessToModule(Enums.SecuritySystemModules.BetaFeatures);
          nullable = nullable.HasValue ? new bool?(!nullable.GetValueOrDefault()) : nullable;
          if (nullable.GetValueOrDefault())
            Thread.Sleep(50);
          Application.DoEvents();
        }
      }
      if (this.ScheduleDropIconsAsyncResult != null)
      {
        this.endDropIconsRefresh = true;
        while (!this.ScheduleDropIconsAsyncResult.IsCompleted)
        {
          nullable = App.loggedInUser?.HasAccessToModule(Enums.SecuritySystemModules.BetaFeatures);
          nullable = nullable.HasValue ? new bool?(!nullable.GetValueOrDefault()) : nullable;
          if (nullable.GetValueOrDefault())
            Thread.Sleep(50);
          Application.DoEvents();
        }
      }
      IEnumerator enumerator;
      try
      {
        enumerator = this._engineerSchedules.ToArray(typeof (frmEngineerSchedule)).GetEnumerator();
        while (enumerator.MoveNext())
        {
          frmEngineerSchedule current = (frmEngineerSchedule) enumerator.Current;
          current.Close();
          current.Dispose();
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this._mdiClient.ResumeLayout(false);
      this._mdiClient.Visible = true;
      this._engineerSchedules.Clear();
      this.loadEngineerSchedules(this.FromDate, this.ToDate);
      Application.DoEvents();
      Cursor.Current = Cursors.Default;
    }

    public void refreshScheduler()
    {
      if (this._ScheduleControl != null)
        this.loadWork(this._ScheduleControl.dateFrom, this._ScheduleControl.dateTo);
      this.LoadUnscheduledWork();
    }

    public void loadWork(DateTime fromDate, DateTime toDate)
    {
      this.FromDate = fromDate;
      this.ToDate = toDate;
      this.refreshPeopleSchedules();
    }

    private void refreshPeopleSchedules()
    {
      Cursor.Current = Cursors.WaitCursor;
      FSM.Scheduler.refreshPeopleSchedulesDelegate schedulesDelegate = new FSM.Scheduler.refreshPeopleSchedulesDelegate(this.refreshPeopleSchedulesBegin);
      AsyncCallback DelegateCallback = new AsyncCallback(this.refreshPeopleScheulesComplete);
      if (this.refreshPeopleSchedulesAsyncResult != null)
      {
        this.endSummaryRefresh = true;
        while (!this.refreshPeopleSchedulesAsyncResult.IsCompleted)
        {
          Application.DoEvents();
          bool? nullable = App.loggedInUser?.HasAccessToModule(Enums.SecuritySystemModules.BetaFeatures);
          nullable = nullable.HasValue ? new bool?(!nullable.GetValueOrDefault()) : nullable;
          if (nullable.GetValueOrDefault())
            Thread.Sleep(30);
        }
        this.endSummaryRefresh = false;
      }
      this.refreshPeopleSchedulesAsyncResult = schedulesDelegate.BeginInvoke(DelegateCallback, (object) null);
    }

    private void refreshPeopleSchedulesBegin()
    {
      ArrayList arrayList = new ArrayList();
      ArrayList engineerSchedules = this._engineerSchedules;
      while (arrayList.Count != engineerSchedules.Count & !this.endSummaryRefresh)
      {
        try
        {
          IEnumerator enumerator;
          try
          {
            enumerator = engineerSchedules.GetEnumerator();
            while (enumerator.MoveNext())
            {
              frmEngineerSchedule current = (frmEngineerSchedule) enumerator.Current;
              Rectangle rectangle = new Rectangle(0, 0, this._mdiClient.Width, this._mdiClient.Height);
              if (!this.Closing)
              {
                current.Reset();
                current.RefreshSummary(Conversions.ToString(this._ScheduleControl.dateFrom), Conversions.ToString(this._ScheduleControl.dateTo));
                arrayList.Add((object) current.EngineerID);
              }
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          string errorMsg = exception.Message;
          if (exception.InnerException != null)
            errorMsg = errorMsg + "\r\nInner Exception:\r\n" + exception.InnerException.Message;
          App.LogError(exception.GetType().Name, errorMsg, exception.StackTrace);
          ProjectData.ClearProjectError();
        }
        Application.DoEvents();
        bool? nullable = App.loggedInUser?.HasAccessToModule(Enums.SecuritySystemModules.BetaFeatures);
        nullable = nullable.HasValue ? new bool?(!nullable.GetValueOrDefault()) : nullable;
        if (nullable.GetValueOrDefault())
          Thread.Sleep(75);
      }
    }

    private void refreshPeopleScheulesComplete(IAsyncResult ar)
    {
      Cursor.Current = Cursors.Default;
      FSM.Scheduler.refreshPeopleSchedulesDelegate asyncDelegate = (FSM.Scheduler.refreshPeopleSchedulesDelegate) ((AsyncResult) ar).AsyncDelegate;
      try
      {
        IEnumerator enumerator;
        try
        {
          enumerator = this._engineerSchedules.GetEnumerator();
          while (enumerator.MoveNext())
          {
            frmEngineerSchedule current = (frmEngineerSchedule) enumerator.Current;
            current.Enabled = true;
            current.opening = false;
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        string errorMsg = exception.Message;
        if (exception.InnerException != null)
          errorMsg = errorMsg + "\r\nInner Exception:\r\n" + exception.InnerException.Message;
        App.LogError(exception.GetType().Name, errorMsg, exception.StackTrace);
        ProjectData.ClearProjectError();
      }
      this.endSummaryRefresh = false;
      asyncDelegate.EndInvoke(ar);
    }

    public void LoadUnscheduledWork()
    {
      new FSM.Scheduler.loadUnsheduledWorkDelegate(this.LoadUnsheduledWorkBegin).BeginInvoke(new AsyncCallback(this.loadUnsheduledWorkEnd), (object) null);
    }

    public DataTable LoadUnsheduledWorkBegin()
    {
      DataTable dataTable = new DataTable();
      bool viewAll = this._unscheduledCalls?.chkViewAll.Checked.Value;
      if (viewAll)
        viewAll = App.ShowMessage("Do you wish to continue?\r\n\r\nViewing all visits in the holding area can cause performance issues. \r\nPlease only view all if you need to do so.\r\nThanks", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes;
      DataTable unscheduledVisits = App.DB.Scheduler.GetUnscheduledVisits(viewAll);
      unscheduledVisits.TableName = "UnscheduledWork";
      return unscheduledVisits;
    }

    public void loadUnsheduledWorkEnd(IAsyncResult ar)
    {
      FSM.Scheduler.loadUnsheduledWorkDelegate asyncDelegate = (FSM.Scheduler.loadUnsheduledWorkDelegate) ((AsyncResult) ar).AsyncDelegate;
      try
      {
        if (this._mdiParent.IsDisposed)
          return;
        this._mdiParent.Invoke((Delegate) new FSM.Scheduler.setUnsheduledCallsDelegate(this.SetUnsheduledCalls), (object) asyncDelegate.EndInvoke(ar));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private void SetUnsheduledCalls(DataTable dtunscheduledCalls)
    {
      this._unscheduledCalls.unscheduledCalls = dtunscheduledCalls;
      this._unscheduledCalls.ApplyFilters();
    }

    public DataTable loadDay(string EngineerID, DateTime date)
    {
      DataTable dataTable = new DataTable();
      DataTable scheduledJobsDay = App.DB.Scheduler.Get_ScheduledJobsDay(date, EngineerID);
      scheduledJobsDay.TableName = Strings.Format((object) date, "dd/MM/yyyy").ToString();
      return scheduledJobsDay;
    }

    public void gridMouseDown(object sender, MouseEventArgs e)
    {
      if (sender == null || e == null)
        return;
      try
      {
        if (((DataGrid) sender).HitTest(e.X, e.Y).Type == DataGrid.HitTestType.Cell)
        {
          this.cellDown = true;
          this.clickedPoint = new System.Drawing.Point(e.X, e.Y);
        }
        else
          this.cellDown = false;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        string errorMsg = exception.Message;
        if (exception.InnerException != null)
          errorMsg = errorMsg + "\r\nInner Exception:\r\n" + exception.InnerException.Message;
        App.LogError(exception.GetType().Name, errorMsg, exception.StackTrace);
        ProjectData.ClearProjectError();
      }
    }

    private void gridMouseMove(object sender, MouseEventArgs e)
    {
      if (sender == null || e == null)
        return;
      try
      {
        Application.DoEvents();
        DataGrid ClickedDatagrid = (DataGrid) sender;
        DataGrid.HitTestInfo hitTestInfo1 = ClickedDatagrid.HitTest(e.X, e.Y);
        if (this.cellDown && Control.MouseButtons == MouseButtons.Left & this.compareCoordinates(e.X, e.Y) & hitTestInfo1.Type == DataGrid.HitTestType.Cell && this.clickedPoint != new System.Drawing.Point())
        {
          DataGrid.HitTestInfo hitTestInfo2 = ClickedDatagrid.HitTest(this.clickedPoint.X, this.clickedPoint.Y);
          if (e.Button == MouseButtons.Left && hitTestInfo2 != null)
          {
            this.setScheduleDropIcons(((DataView) ClickedDatagrid.DataSource)[hitTestInfo1.Row].Row);
            bool heartOk;
            if ((object) ClickedDatagrid.Parent.GetType() == (object) typeof (frmEngineerSchedule))
            {
              frmEngineerSchedule parent = (frmEngineerSchedule) ClickedDatagrid.Parent;
            }
            else
              heartOk = false;
            DataView dataSource = (DataView) ClickedDatagrid.DataSource;
            int index = hitTestInfo2.Row;
            if (index > checked (dataSource.Count - 1))
              index = checked (dataSource.Count - 1);
            if (Control.ModifierKeys == Keys.Control)
            {
              int num1 = (int) ClickedDatagrid.DoDragDrop((object) new FSM.Scheduler.WorkTransport(dataSource[index], ClickedDatagrid, true), DragDropEffects.Copy);
            }
            else
            {
              int num2;
              if (ClickedDatagrid.VisibleRowCount > 0)
              {
                DataRowView scheduleRow = dataSource[index];
                num2 = this.canMoveRow(ref scheduleRow, ref heartOk) ? 1 : 0;
              }
              else
                num2 = 0;
              if (num2 != 0)
              {
                int num3 = (int) ClickedDatagrid.DoDragDrop((object) new FSM.Scheduler.WorkTransport(dataSource[index], ClickedDatagrid, false), DragDropEffects.Move);
              }
              else
              {
                int num4 = (int) ClickedDatagrid.DoDragDrop(RuntimeHelpers.GetObjectValue(new object()), DragDropEffects.None);
              }
            }
            Application.DoEvents();
          }
        }
        this.mousePos = new System.Drawing.Point(e.X, e.Y);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        string errorMsg = exception.Message;
        if (exception.InnerException != null)
          errorMsg = errorMsg + "\r\nInner Exception:\r\n" + exception.InnerException.Message;
        App.LogError(exception.GetType().Name, errorMsg, exception.StackTrace);
        ProjectData.ClearProjectError();
      }
    }

    private void gridDragOver(object sender, DragEventArgs e)
    {
      if (sender == null || e == null)
        return;
      try
      {
        if (e.Data.GetDataPresent(typeof (FSM.Scheduler.WorkTransport)))
        {
          DataGrid dataGrid = (DataGrid) sender;
          DataGrid sourceDataGrid = ((FSM.Scheduler.WorkTransport) e.Data.GetData(typeof (FSM.Scheduler.WorkTransport))).sourceDataGrid;
          if ((object) dataGrid.Parent.GetType() == (object) typeof (frmEngineerSchedule))
          {
            frmEngineerSchedule parent = (frmEngineerSchedule) dataGrid.Parent;
            System.Drawing.Point client = parent.dgDaySummary.PointToClient(new System.Drawing.Point(e.X, e.Y));
            parent.dgDaySummary.HitTest(client.X, client.Y);
            e.Effect = ((FSM.Scheduler.WorkTransport) e.Data.GetData(typeof (FSM.Scheduler.WorkTransport))).CanCopy ? DragDropEffects.Copy : DragDropEffects.Move;
          }
          else
            e.Effect = ((FSM.Scheduler.WorkTransport) e.Data.GetData(typeof (FSM.Scheduler.WorkTransport))).CanCopy ? DragDropEffects.None : DragDropEffects.Move;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        string errorMsg = exception.Message;
        if (exception.InnerException != null)
          errorMsg = errorMsg + "\r\nInner Exception:\r\n" + exception.InnerException.Message;
        App.LogError(exception.GetType().Name, errorMsg, exception.StackTrace);
        ProjectData.ClearProjectError();
      }
    }

    public string CanMoveDownloadedVisit(
      frmEngineerSchedule engineerScheduleFrom,
      int EngineerVisitID,
      int TabletActionID)
    {
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.MoveDownloadedVisit))
        return "You do not have the necessary security permissions.\r\n\r\nContact your administrator if you think this is wrong or you need the permissions changing.";
      int num1 = 0;
      DataView dataView = (DataView) null;
      DateTime minValue = DateTime.MinValue;
      if (TabletActionID == 1)
        return "The Downloaded visit has already been marked to be removed from another engineers tablet, you will need to wait for this to complete";
      if (DateTime.Compare(engineerScheduleFrom.HeartLastCheck, DateAndTime.Now.AddMinutes(-5.0)) <= 0)
      {
        HeartBeat latestHeartBeat = App.DB.Scheduler.GetLatestHeartBeat(Conversions.ToInteger(engineerScheduleFrom.EngineerID));
        engineerScheduleFrom.HeartLastCheck = latestHeartBeat.LastCheck;
        engineerScheduleFrom.LastHeartBeat = latestHeartBeat.LastHeartBeat;
        engineerScheduleFrom.LockedVisitId = latestHeartBeat.LockedVisitID;
      }
      if (DateTime.Compare(engineerScheduleFrom.LastHeartBeat, DateTime.MinValue) <= 0)
        return "The Downloaded visit has already been marked to be removed from another engineers tablet, you will need to wait for this to complete";
      if (DateTime.Compare(engineerScheduleFrom.LastHeartBeat.AddMinutes(5.0), DateTime.Now) <= 0)
        return "The downloaded visit cannot be moved as the device has not checked in recently";
      if (engineerScheduleFrom.LockedVisitId == EngineerVisitID)
        return "The downloaded visit cannot be moved as the engineer currently has this visit open on his device";
      if (((dataView == null ? 0 : (num1 == EngineerVisitID ? 1 : 0)) & (DateTime.Compare(minValue, DateAndTime.Now.AddMinutes(-1.0)) > 0 ? 1 : 0)) == 0)
      {
        dataView = App.DB.EngineerVisitsTimeSheet.EngineerVisitTimeSheet_Get_For_EngineerVisitID(EngineerVisitID);
        DateTime now = DateAndTime.Now;
      }
      int num2 = 0;
      IEnumerator enumerator;
      try
      {
        enumerator = dataView.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRowView current = (DataRowView) enumerator.Current;
          num2 = checked ((int) DateAndTime.DateDiff(DateInterval.Minute, Conversions.ToDate(current["StartDateTime"]), !Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["EndDateTime"])) ? Conversions.ToDate(current["EndDateTime"]) : DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return num2 < 2 ? string.Empty : "The downloaded visit cannot be moved as the engineer has began traveling or working on this visit";
    }

    private void gridDragDrop(object sender, DragEventArgs e)
    {
      if (sender != null && e != null)
      {
        try
        {
          if (e.Data.GetDataPresent(typeof (FSM.Scheduler.WorkTransport)))
          {
            DataGrid dataGrid = (DataGrid) sender;
            FSM.Scheduler.WorkTransport data = (FSM.Scheduler.WorkTransport) e.Data.GetData(typeof (FSM.Scheduler.WorkTransport));
            if (data == null)
              return;
            DataGrid sourceDataGrid = data.sourceDataGrid;
            DataRowView dataRowView = (DataRowView) null;
            FSM.Entity.JobLock.JobLock jobLock = App.DB.JobLock.Check(Conversions.ToInteger(data.sourceDatarowView["JobID"]));
            int actionId = App.DB.EngineerVisits.EngineerVisit_GetActionID(Conversions.ToInteger(data.sourceDatarowView["EngineerVisitID"]));
            if (jobLock != null)
            {
              int num = (int) MessageBox.Show("This job cannot be scheduled because is it currently locked:\r\n" + string.Format("Locked by: {0}", (object) jobLock.NameOfUserWhoLocked) + "\r\n" + string.Format("Date Locked: {0}", (object) jobLock.DateLock) + "\r\n", "Job Lock", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
              return;
            }
            if (dataGrid != sourceDataGrid)
            {
              DataView dataView = (DataView) null;
              frmEngineerSchedule engineerSchedule = (frmEngineerSchedule) null;
              frmEngineerSchedule engineerScheduleFrom = (frmEngineerSchedule) null;
              if ((object) sourceDataGrid.Parent.GetType() == (object) typeof (frmEngineerSchedule))
                engineerScheduleFrom = (frmEngineerSchedule) sourceDataGrid.Parent;
              if ((object) dataGrid.Parent.GetType() == (object) typeof (frmEngineerSchedule))
              {
                engineerSchedule = (frmEngineerSchedule) dataGrid.Parent;
                engineerSchedule.CurrentDate = DateTime.MinValue;
                System.Drawing.Point client = engineerSchedule.dgDaySummary.PointToClient(new System.Drawing.Point(e.X, e.Y));
                DataGrid.HitTestInfo hitTestInfo = engineerSchedule.dgDaySummary.HitTest(client.X, client.Y);
                if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
                {
                  dataRowView = ((DataView) engineerSchedule.dgDaySummary.DataSource)[hitTestInfo.Row];
                  if (dataRowView != null)
                  {
                    engineerSchedule.CurrentDate = Conversions.ToDate(dataRowView["dayDate"]);
                    dataView = new DataView(engineerSchedule.GetDay(Conversions.ToString(dataRowView["dayDate"])));
                    int num = checked (((DataView) engineerSchedule.dgDaySummary.DataSource).Table.Rows.Count - 1);
                    int row = 0;
                    while (row <= num)
                    {
                      engineerSchedule.dgDaySummary.UnSelect(row);
                      checked { ++row; }
                    }
                  }
                  engineerSchedule.dgDaySummary.Select(hitTestInfo.Row);
                  engineerSchedule.RefreshSummary(Conversions.ToString(this.FromDate), Conversions.ToString(this.ToDate));
                }
              }
              else
                dataView = (DataView) dataGrid.DataSource;
              if (dataView == null)
                return;
              DataRowView scheduleRow = dataView.AddNew();
              IEnumerator enumerator1;
              try
              {
                enumerator1 = data.sourceDatarowView.Row.Table.Columns.GetEnumerator();
                while (enumerator1.MoveNext())
                {
                  DataColumn current = (DataColumn) enumerator1.Current;
                  try
                  {
                    if (scheduleRow.Row.Table.Columns[current.ColumnName] != null)
                    {
                      if ((object) scheduleRow.Row.Table.Columns[current.ColumnName].DataType == (object) data.sourceDatarowView.Row.Table.Columns[current.ColumnName].DataType)
                        scheduleRow[current.ColumnName] = RuntimeHelpers.GetObjectValue(data.sourceDatarowView[current.ColumnName]);
                    }
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    ProjectData.ClearProjectError();
                  }
                }
              }
              finally
              {
                if (enumerator1 is IDisposable)
                  (enumerator1 as IDisposable).Dispose();
              }
              bool flag1 = true;
              EngineerVisit asObject = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(scheduleRow.Row["EngineerVisitID"]), true);
              int num1 = App.DB.JobOfWorks.JobOfWork_Get(asObject.JobOfWorkID).Status;
              string empty = string.Empty;
              if ((object) sourceDataGrid.Parent.GetType() == (object) typeof (frmEngineerSchedule) & asObject.StatusEnumID == 6 & !data.CanCopy)
              {
                string MessageText = this.CanMoveDownloadedVisit(engineerScheduleFrom, Conversions.ToInteger(scheduleRow.Row["EngineerVisitID"]), actionId);
                flag1 = string.IsNullOrEmpty(MessageText);
                if (!flag1)
                {
                  int num2 = (int) App.ShowMessage(MessageText, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
              }
              DateTime now;
              if (flag1)
              {
                if (engineerSchedule != null)
                {
                  now = DateAndTime.Now;
                  if (now.Subtract(asObject.Downloading) < this.TwoMins & !data.CanCopy)
                  {
                    int num2 = (int) App.ShowMessage("This visit has already been recently downloaded to an Engineer's PDA and cannot be rescheduled", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    flag1 = false;
                  }
                  else if (num1 == 3 & data.CanCopy)
                  {
                    int num2 = (int) App.ShowMessage("This visit's job of work has been completed so the visit cannot be copied", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    flag1 = false;
                    num1 = 0;
                  }
                  else if (num1 == 2 & data.CanCopy)
                  {
                    int num2 = (int) App.ShowMessage("This visit's job of work has been closed so the visit cannot be copied", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    flag1 = false;
                    num1 = 0;
                  }
                  else
                    flag1 = engineerSchedule.TestAcceptance(scheduleRow.Row) || engineerSchedule.GetAcceptance(scheduleRow.Row, data.CanCopy);
                }
                else
                {
                  now = DateAndTime.Now;
                  if (now.Subtract(asObject.Downloading) < this.TwoMins & !data.CanCopy)
                  {
                    int num2 = (int) App.ShowMessage("This visit has already been recently downloaded to an Engineer's PDA and cannot be rescheduled", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    flag1 = false;
                  }
                  else if (num1 == 3 & data.CanCopy)
                  {
                    int num2 = (int) App.ShowMessage("This visit's job of work has been completed so the visit cannot be copied", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    flag1 = false;
                    num1 = 0;
                  }
                  else if (num1 == 2 & data.CanCopy)
                  {
                    int num2 = (int) App.ShowMessage("This visit's job of work has been closed so the visit cannot be copied", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    flag1 = false;
                    num1 = 0;
                  }
                }
              }
              if (flag1 & engineerSchedule != null && Conversions.ToDouble(engineerSchedule.EngineerID) != 221.0 && (Conversions.ToDouble(engineerSchedule.EngineerID) != 320.0 && Conversions.ToDouble(engineerSchedule.EngineerID) != 314.0) && (Conversions.ToDouble(engineerSchedule.EngineerID) != 215.0 && Conversions.ToDouble(engineerSchedule.EngineerID) != 378.0) && Conversions.ToDouble(engineerSchedule.EngineerID) != 386.0)
              {
                DataTable dataTable1 = App.DB.ExecuteWithReturn("select ISNULL(op.ReceivedEngineerID,0) as ReceivedEngineerID,op.OrderID,pa.Quantity, pa.OrderPartID ,e.name as eng, P.Name, p.Number from tblOrderPart op inner join tblEngineerVisitPartAllocated pa ON pa.OrderPartID = op.OrderPartID INNER JOIN tblPart P ON p.PartID = pa.PArtID INNER JOIN tblengineer E ON e.EngineerID = op.ReceivedEngineerID where engineervisitid = " + Conversions.ToString(asObject.EngineerVisitID), true);
                if (dataTable1 != null && dataTable1.Rows.Count != 0 && !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataTable1.Rows[0]["ReceivedEngineerID"], (object) engineerSchedule.EngineerID, false) && this._OldEngineerVisitID <= 0)
                {
                  int num2 = (int) App.ShowMessage("This Visit has parts attached which have already been picked up by different engineer, only coordinators and above can action this", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  if (App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Coordinator))
                  {
                    IEnumerator enumerator2;
                    try
                    {
                      enumerator2 = dataTable1.Rows.GetEnumerator();
                      while (enumerator2.MoveNext())
                      {
                        DataRow current = (DataRow) enumerator2.Current;
                        App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "DELETE FROM tblAltReturn WHERE OrderPartID = ", current["OrderPartID"])), true, false);
                      }
                    }
                    finally
                    {
                      if (enumerator2 is IDisposable)
                        (enumerator2 as IDisposable).Dispose();
                    }
                    DataRow[] dataRowArray1 = dataTable1.Select("ReceivedEngineerID <> 0 AND ReceivedEngineerID <> " + engineerSchedule.EngineerID);
                    if (dataRowArray1.Length == 0)
                    {
                      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataTable1.Rows[0]["ReceivedEngineerID"], (object) engineerSchedule.EngineerID, false))
                      {
                        bool flag2 = false;
                        IEnumerator enumerator3;
                        try
                        {
                          enumerator3 = dataTable1.Rows.GetEnumerator();
                          while (enumerator3.MoveNext())
                          {
                            DataRow current = (DataRow) enumerator3.Current;
                            if (Conversions.ToInteger(App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Select COUNT(*) from tblpartcreditparts cp INNER JOIN tblPartsToBeCredited tbc ON tbc.PartsToBeCreditedID = cp.PartsToBeCreditedID WHERE tbc.OrderPArtID = ", current["OrderPartID"])), true, false)) > 0)
                            {
                              flag2 = true;
                              break;
                            }
                          }
                        }
                        finally
                        {
                          if (enumerator3 is IDisposable)
                            (enumerator3 as IDisposable).Dispose();
                        }
                        IEnumerator enumerator4;
                        if (!flag2)
                        {
                          try
                          {
                            enumerator4 = dataTable1.Rows.GetEnumerator();
                            while (enumerator4.MoveNext())
                            {
                              DataRow current = (DataRow) enumerator4.Current;
                              App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Delete From tblPartstobeCredited where OrderPartID = ", current["OrderPartID"])), true, false);
                              App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "UPDATE tblEngineerVisitPartAllocated SET CreditRequested = 0,CreditQty = 0 WHERE ORDERPARTID = ", current["OrderPartID"])), true, false);
                            }
                          }
                          finally
                          {
                            if (enumerator4 is IDisposable)
                              (enumerator4 as IDisposable).Dispose();
                          }
                        }
                      }
                    }
                    else
                    {
                      string str = "";
                      DataRow[] dataRowArray2 = dataRowArray1;
                      int index1 = 0;
                      while (index1 < dataRowArray2.Length)
                      {
                        DataRow dataRow = dataRowArray2[index1];
                        str = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) str, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataRow["Name"], (object) "("), dataRow["Number"]), (object) "), ")));
                        checked { ++index1; }
                      }
                      FRMItemReturn frmItemReturn = new FRMItemReturn();
                      frmItemReturn.TextBox1.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("This visit contains the parts " + str + " - which have been picked up by "), dataRowArray1[0]["eng"]), (object) ". Please select what action to take."));
                      int num3 = (int) frmItemReturn.ShowDialog();
                      int integer = Conversions.ToInteger(Combo.get_GetSelectedItemValue(frmItemReturn.cboJobType));
                      string text = frmItemReturn.TextBox2.Text;
                      switch (integer)
                      {
                        case 0:
                          flag1 = false;
                          break;
                        case 1:
                          if (App.ShowMessage("Beware! actioning this return is not reversable, the parts will be marked to be returned to supplier , do you wish to proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                          {
                            DataRow[] dataRowArray3 = dataRowArray1;
                            int index2 = 0;
                            while (index2 < dataRowArray3.Length)
                            {
                              DataRow dataRow = dataRowArray3[index2];
                              if (Conversions.ToInteger(App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "SELECT COUNT(*) From tblPartsToBeCredited where OrderPArtID = ", dataRow["OrderPartID"])), true, false)) == 0)
                              {
                                int num4 = 0;
                                DataTable dataTable2 = App.DB.ExecuteWithReturn(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "SELECT tblPartSupplier.PartID, tblOrder.OrderReference, CASE WHEN COALESCE (tblOrderPart.ChildSupplierID, 0) = 0 THEN tblSupplier.SupplierID ELSE tblOrderPart.ChildSupplierID END AS SupplierID,CASE WHEN COALESCE (tblOrderPart.ChildSupplierID, 0) = 0 THEN tblSupplier.Name ELSE (SELECT Name FROM tblsupplier AS a WHERE supplierID = tblOrderPart.ChildSupplierID) END AS SupplierName FROM tblOrderPart LEFT OUTER JOIN tblPartSupplier ON tblOrderPart.PartSupplierID = tblPartSupplier.PartSupplierID LEFT OUTER JOIN tblSupplier ON tblSupplier.SupplierID = tblPartSupplier.SupplierID INNER JOIN tblOrder ON tblOrderPart.OrderID = tblOrder.OrderID WHERE (tblOrderPart.OrderPartID = ", dataRow["OrderPartID"]), (object) ")")), true);
                                num4 = App.DB.PartsToBeCredited.PartsToBeCredited_Insert(Conversions.ToInteger(dataTable2.Rows[0]["SupplierID"]), Conversions.ToInteger(dataRow["OrderID"]), Conversions.ToInteger(dataTable2.Rows[0]["PartID"]), Conversions.ToInteger(dataRow["Quantity"]), Conversions.ToString(dataTable2.Rows[0]["OrderReference"]), Conversions.ToInteger(dataRow["ReceivedEngineerID"]), Conversions.ToInteger(dataRow["OrderPartID"]));
                                App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("UPDATE tblEngineerVisitPartAllocated SET CreditRequested = 1, CreditQty = " + Conversions.ToString(Conversions.ToInteger(dataRow["Quantity"])) + " WHERE ORDERPARTID = "), dataRow["OrderPartID"])), true, false);
                              }
                              checked { ++index2; }
                            }
                            break;
                          }
                          break;
                        case 2:
                          DataRow[] dataRowArray4 = dataRowArray1;
                          int index3 = 0;
                          while (index3 < dataRowArray4.Length)
                          {
                            DataRow dataRow = dataRowArray4[index3];
                            if (Conversions.ToInteger(App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Select COUNT(*) from tblpartcreditparts cp INNER JOIN tblPartsToBeCredited tbc ON tbc.PartsToBeCreditedID = cp.PartsToBeCreditedID WHERE tbc.OrderPArtID = ", dataRow["OrderPartID"])), true, false)) > 0)
                            {
                              int num4 = (int) App.ShowMessage("One or more of the parts have been returned to the supplier already, you can not have these picked up form a location", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                              flag1 = false;
                              break;
                            }
                            checked { ++index3; }
                          }
                          if (flag1)
                          {
                            DataRow[] dataRowArray3 = dataRowArray1;
                            int index2 = 0;
                            while (index2 < dataRowArray3.Length)
                            {
                              DataRow dataRow = dataRowArray3[index2];
                              App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Delete From tblPartstobeCredited where OrderPartID = ", dataRow["OrderPartID"])), true, false);
                              App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "UPDATE tblEngineerVisitPartAllocated SET CreditRequested = 0 ,CreditQty = 0 WHERE ORDERPARTID = ", dataRow["OrderPartID"])), true, false);
                              App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Insert INTO tblAltReturn (OrderPartID,Location,ReturningEng,CollectingEng) VALUES(", dataRow["OrderPartID"]), (object) ",'"), (object) text), (object) "',"), dataRow["ReceivedEngineerID"]), (object) ","), (object) engineerSchedule.EngineerID), (object) ")")), true, false);
                              checked { ++index2; }
                            }
                            break;
                          }
                          break;
                      }
                    }
                  }
                  else
                    flag1 = false;
                }
              }
              int appointment = 0;
              if (flag1)
                flag1 = engineerSchedule == null ? this.scheduleRowManipulation(ref scheduleRow, 0, DateTime.MinValue, data.CanCopy, ref appointment) : this.scheduleRowManipulation(ref scheduleRow, Conversions.ToInteger(engineerSchedule.EngineerID), Conversions.ToDate(dataRowView["dayDate"]), data.CanCopy, ref appointment);
              if (flag1)
              {
                asObject = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(scheduleRow.Row["EngineerVisitID"]), true);
                bool? nullable1 = asObject != null ? new bool?(asObject.StatusEnumID == 6) : new bool?();
                bool? nullable2 = (object) sourceDataGrid.Parent.GetType() == (object) typeof (frmEngineerSchedule) ? nullable1 : new bool?(false);
                if ((!data.CanCopy ? nullable2 : new bool?(false)).GetValueOrDefault())
                {
                  string MessageText = this.CanMoveDownloadedVisit(engineerScheduleFrom, Conversions.ToInteger(scheduleRow.Row["EngineerVisitID"]), actionId);
                  flag1 = string.IsNullOrEmpty(MessageText);
                  if (!flag1)
                  {
                    int num2 = (int) App.ShowMessage(MessageText, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                  }
                }
              }
              if (asObject != null & flag1)
              {
                now = DateAndTime.Now;
                int num2;
                if (now.Subtract(asObject.Downloading) < this.TwoMins & !data.CanCopy)
                {
                  int num3 = (int) App.ShowMessage("This visit has already been recently downloaded to an Engineer's PDA and cannot be rescheduled", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                  flag1 = false;
                }
                else if (num1 == 3 & data.CanCopy)
                {
                  int num3 = (int) App.ShowMessage("This visit's job of work has been completed so the visit cannot be copied", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                  flag1 = false;
                  num2 = 0;
                }
                else if (num1 == 2 & data.CanCopy)
                {
                  int num3 = (int) App.ShowMessage("This visit's job of work has been closed so the visit cannot be copied", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                  flag1 = false;
                  num2 = 0;
                }
              }
              if (flag1)
              {
                if (!data.CanCopy)
                {
                  e.Effect = DragDropEffects.Move;
                  data.sourceDatarowView.Delete();
                }
                else if (engineerSchedule != null)
                  e.Effect = DragDropEffects.Copy;
                if (engineerSchedule != null)
                {
                  SchedulerSQL scheduler = App.DB.Scheduler;
                  DataRow row = scheduleRow.Row;
                  ref DataRow local = ref row;
                  int oldEngineerVisitId = this._OldEngineerVisitID;
                  int AppointmentID = appointment;
                  scheduler.ScheduleVisit(ref local, oldEngineerVisitId, AppointmentID);
                  this._OldEngineerVisitID = 0;
                }
                else
                  App.DB.Scheduler.unscheduleVisit(scheduleRow.Row);
                Application.DoEvents();
                if (engineerSchedule != null)
                {
                  engineerSchedule.RefreshSummary(Conversions.ToString(this.FromDate), Conversions.ToString(this.ToDate));
                  dataView.Table.AcceptChanges();
                }
                else if (dataView.Table.Select("JobOfWorkID=" + Conversions.ToString(scheduleRow["JobOfWorkID"])).Length <= 1)
                  dataView.Table.AcceptChanges();
                else
                  dataView.Table.RejectChanges();
                if (engineerScheduleFrom != null)
                  engineerScheduleFrom.RefreshSummary(Conversions.ToString(this.FromDate), Conversions.ToString(this.ToDate));
                else
                  this._unscheduledCalls.setOverdueLabel();
              }
              else
              {
                dataView.Table.RejectChanges();
                e.Effect = DragDropEffects.None;
              }
            }
            else
              this.setScheduleDropIcons((DataRow) null);
            ((DataView) sourceDataGrid.DataSource).Table.AcceptChanges();
            ((DataView) dataGrid.DataSource).Table.AcceptChanges();
          }
          this.resetHeaders();
          this.clearSelections();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          string errorMsg = exception.Message;
          if (exception.InnerException != null)
            errorMsg = errorMsg + "\r\nInner Exception:\r\n" + exception.InnerException.Message;
          App.LogError(exception.GetType().Name, errorMsg, exception.StackTrace);
          ProjectData.ClearProjectError();
        }
      }
    }

    private void gridMouseUp(object sender, MouseEventArgs e)
    {
      if (sender == null || e == null)
        return;
      try
      {
        DataGrid dataGrid = (DataGrid) sender;
        DataGrid.HitTestInfo hitTestInfo = dataGrid.HitTest(e.X, e.Y);
        if (hitTestInfo.Type == DataGrid.HitTestType.Cell && hitTestInfo.Row > -1)
        {
          this.clearSelections();
          this.setScheduleDropIcons(((DataView) dataGrid.DataSource)[hitTestInfo.Row].Row);
          dataGrid.CurrentRowIndex = hitTestInfo.Row;
          dataGrid.Select(hitTestInfo.Row);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        string errorMsg = exception.Message;
        if (exception.InnerException != null)
          errorMsg = errorMsg + "\r\nInner Exception:\r\n" + exception.InnerException.Message;
        App.LogError(exception.GetType().Name, errorMsg, exception.StackTrace);
        ProjectData.ClearProjectError();
      }
    }

    private bool compareCoordinates(int x2, int y2)
    {
      return Math.Abs(checked (x2 - this.clickedPoint.X)) > 3 || Math.Abs(checked (y2 - this.clickedPoint.Y)) > 3;
    }

    private void resetHeaders()
    {
      IEnumerator enumerator;
      try
      {
        enumerator = this._engineerSchedules.ToArray(typeof (frmEngineerSchedule)).GetEnumerator();
        while (enumerator.MoveNext())
          ((frmEngineerSchedule) enumerator.Current).ResetHeader();
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void setScheduleDropIcons(DataRow draggedRow)
    {
      FSM.Scheduler.setScheduleDropIconsDelegate dropIconsDelegate = new FSM.Scheduler.setScheduleDropIconsDelegate(this.SetScheduleDropIconsBegin);
      AsyncCallback DelegateCallback = new AsyncCallback(this.SetScheduleDropIconsComplete);
      if (this.ScheduleDropIconsAsyncResult != null)
      {
        this.endDropIconsRefresh = true;
        while (this.ScheduleDropIconsAsyncResult != null && !this.ScheduleDropIconsAsyncResult.IsCompleted)
        {
          Application.DoEvents();
          bool? nullable = App.loggedInUser?.HasAccessToModule(Enums.SecuritySystemModules.BetaFeatures);
          nullable = nullable.HasValue ? new bool?(!nullable.GetValueOrDefault()) : nullable;
          if (nullable.GetValueOrDefault())
            Thread.Sleep(20);
        }
        this.endDropIconsRefresh = false;
      }
      this.ScheduleDropIconsAsyncResult = dropIconsDelegate.BeginInvoke(draggedRow, DelegateCallback, (object) null);
    }

    private void SetScheduleDropIconsBegin(DataRow draggedRow)
    {
      ArrayList arrayList = new ArrayList();
      while (arrayList.Count != this._engineerSchedules.Count & !this.endDropIconsRefresh)
      {
        IEnumerator enumerator;
        try
        {
          enumerator = this._engineerSchedules.ToArray(typeof (frmEngineerSchedule)).GetEnumerator();
          while (enumerator.MoveNext())
          {
            frmEngineerSchedule current = (frmEngineerSchedule) enumerator.Current;
            Rectangle rectangle = new Rectangle(0, 0, this._mdiClient.Width, this._mdiClient.Height);
            if (!arrayList.Contains((object) current.EngineerID) && rectangle.IntersectsWith(current.Bounds))
            {
              current.CurrentDate = DateTime.MinValue;
              current.RefreshAcceptance(draggedRow);
              arrayList.Add((object) current.EngineerID);
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        Application.DoEvents();
        if (arrayList.Count != this._engineerSchedules.Count & !this.endDropIconsRefresh)
        {
          bool? nullable = App.loggedInUser?.HasAccessToModule(Enums.SecuritySystemModules.BetaFeatures);
          nullable = nullable.HasValue ? new bool?(!nullable.GetValueOrDefault()) : nullable;
          if (nullable.GetValueOrDefault())
            Thread.Sleep(50);
        }
      }
    }

    private void SetScheduleDropIconsComplete(IAsyncResult ar)
    {
      FSM.Scheduler.setScheduleDropIconsDelegate asyncDelegate = (FSM.Scheduler.setScheduleDropIconsDelegate) ((AsyncResult) ar).AsyncDelegate;
      this.endDropIconsRefresh = false;
      asyncDelegate.EndInvoke(ar);
    }

    private void clearSelections()
    {
      this._unscheduledCalls.clearSelections();
      IEnumerator enumerator;
      try
      {
        enumerator = this._engineerSchedules.ToArray(typeof (frmEngineerSchedule)).GetEnumerator();
        while (enumerator.MoveNext())
          ((frmEngineerSchedule) enumerator.Current).ClearSelections();
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void ControlResize(object sender, EventArgs e)
    {
      this.orderScheduleWindows();
    }

    private void orderScheduleWindows()
    {
      this._mdiClient.Resize -= new EventHandler(this.ControlResize);
      this._unscheduledCalls.Resize -= new EventHandler(this.ControlResize);
      double a = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.IntDivideObject((object) this._mdiClient.ClientSize.Width, this._engineerScheduleColumnCount));
      int count = this._engineerSchedules.Count;
      int num1 = 1;
      while (num1 <= count)
      {
        if (Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.IntDivideObject((object) this._mdiClient.ClientSize.Width, this._engineerScheduleColumnCount)) != a)
        {
          a = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.IntDivideObject((object) this._mdiClient.ClientSize.Width, this._engineerScheduleColumnCount));
          IEnumerator enumerator;
          try
          {
            enumerator = this._engineerSchedules.GetEnumerator();
            while (enumerator.MoveNext())
              ((Control) enumerator.Current).Width = checked ((int) Math.Round(a));
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
        }
        int integer = Conversions.ToInteger(NewLateBinding.LateGet((object) null, typeof (Math), "Ceiling", new object[1]
        {
          Microsoft.VisualBasic.CompilerServices.Operators.DivideObject((object) num1, this._engineerScheduleColumnCount)
        }, (string[]) null, (System.Type[]) null, (bool[]) null));
        int num2 = checked ((int) Math.Floor(unchecked ((double) num1 / (double) integer)));
        frmEngineerSchedule engineerSchedule = (frmEngineerSchedule) this._engineerSchedules[checked (num1 - 1)];
        engineerSchedule.Left = checked ((int) Math.Round(unchecked (a * (double) checked (num2 - 1))));
        engineerSchedule.Width = checked ((int) Math.Round(a));
        engineerSchedule.Top = Conversions.ToInteger(Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(this._engineerScheduleHeight, (object) checked (integer - 1)));
        engineerSchedule.Height = Conversions.ToInteger(this._engineerScheduleHeight);
        checked { ++num1; }
      }
      this._mdiClient.Resize += new EventHandler(this.ControlResize);
      this._unscheduledCalls.Resize += new EventHandler(this.ControlResize);
      Application.DoEvents();
    }

    public class scheduleComparer : IComparer
    {
      public int Compare(object x, object y)
      {
        frmEngineerSchedule engineerSchedule1 = (frmEngineerSchedule) x;
        frmEngineerSchedule engineerSchedule2 = (frmEngineerSchedule) y;
        int num;
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(engineerSchedule1.EngineerID, engineerSchedule2.EngineerID, false) < 0)
          num = -1;
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(engineerSchedule1.EngineerID, engineerSchedule2.EngineerID, false) == 0)
          num = 0;
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(engineerSchedule1.EngineerID, engineerSchedule2.EngineerID, false) > 0)
          num = 1;
        return num;
      }
    }

    public class engineerSchedulerComparerByID : IComparer
    {
      public int Compare(object x, object y)
      {
        return Conversions.ToInteger(((frmEngineerSchedule) x).EngineerID).CompareTo(RuntimeHelpers.GetObjectValue(y));
      }
    }

    public class engineerSchedulerComparer : IComparer
    {
      public int Compare(object x, object y)
      {
        return Conversions.ToInteger(((frmEngineerSchedule) x).EngineerID).CompareTo(Conversions.ToInteger(((frmEngineerSchedule) y).EngineerID));
      }
    }

    private delegate void refreshPeopleSchedulesDelegate();

    private delegate DataTable loadUnsheduledWorkDelegate();

    private delegate void setUnsheduledCallsDelegate(DataTable dtunscheduledCalls);

    public class WorkTransport
    {
      public DataRowView sourceDatarowView;
      public DataGrid sourceDataGrid;
      public bool CanCopy;

      public WorkTransport(DataRowView clickedRowView, DataGrid ClickedDatagrid, bool copy)
      {
        this.sourceDatarowView = clickedRowView;
        this.sourceDataGrid = ClickedDatagrid;
        this.CanCopy = copy;
      }
    }

    private delegate void setScheduleDropIconsDelegate(DataRow draggedRow);
  }
}
