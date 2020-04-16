// Decompiled with JetBrains decompiler
// Type: FSM.frmSchedulerMain
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class frmSchedulerMain : Form
  {
    private IContainer components;
    public Scheduler scheduler;

    public frmSchedulerMain()
    {
      this.Load += new EventHandler(this.frmSchedulerMain_Load);
      this.Closing += new CancelEventHandler(this.frmSchedulerMain_Closing);
      this.InitializeComponent();
      Control.CheckForIllegalCrossThreadCalls = false;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual MainMenu mnuMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual MenuItem mnuScheduler { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual MenuItem mnuOpenSchedule
    {
      get
      {
        return this._mnuOpenSchedule;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuOpenSchedule_Click);
        MenuItem mnuOpenSchedule1 = this._mnuOpenSchedule;
        if (mnuOpenSchedule1 != null)
          mnuOpenSchedule1.Click -= eventHandler;
        this._mnuOpenSchedule = value;
        MenuItem mnuOpenSchedule2 = this._mnuOpenSchedule;
        if (mnuOpenSchedule2 == null)
          return;
        mnuOpenSchedule2.Click += eventHandler;
      }
    }

    internal virtual MenuItem mnuResetScheduler
    {
      get
      {
        return this._mnuResetScheduler;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuResetScheduler_Click);
        MenuItem mnuResetScheduler1 = this._mnuResetScheduler;
        if (mnuResetScheduler1 != null)
          mnuResetScheduler1.Click -= eventHandler;
        this._mnuResetScheduler = value;
        MenuItem mnuResetScheduler2 = this._mnuResetScheduler;
        if (mnuResetScheduler2 == null)
          return;
        mnuResetScheduler2.Click += eventHandler;
      }
    }

    internal virtual MenuItem mnuCloseScheduler
    {
      get
      {
        return this._mnuCloseScheduler;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuCloseScheduler_Click);
        MenuItem mnuCloseScheduler1 = this._mnuCloseScheduler;
        if (mnuCloseScheduler1 != null)
          mnuCloseScheduler1.Click -= eventHandler;
        this._mnuCloseScheduler = value;
        MenuItem mnuCloseScheduler2 = this._mnuCloseScheduler;
        if (mnuCloseScheduler2 == null)
          return;
        mnuCloseScheduler2.Click += eventHandler;
      }
    }

    internal virtual MenuItem mnuDividerScheduler { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual MenuItem mnuWeekSchedule { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual MenuItem mnuPrintWeek
    {
      get
      {
        return this._mnuPrintWeek;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuPrintWeek_Click);
        MenuItem mnuPrintWeek1 = this._mnuPrintWeek;
        if (mnuPrintWeek1 != null)
          mnuPrintWeek1.Click -= eventHandler;
        this._mnuPrintWeek = value;
        MenuItem mnuPrintWeek2 = this._mnuPrintWeek;
        if (mnuPrintWeek2 == null)
          return;
        mnuPrintWeek2.Click += eventHandler;
      }
    }

    internal virtual MenuItem MenuItem1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual MenuItem MenuItem2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual MenuItem mnuAbsences
    {
      get
      {
        return this._mnuAbsences;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuAbsences_Click);
        MenuItem mnuAbsences1 = this._mnuAbsences;
        if (mnuAbsences1 != null)
          mnuAbsences1.Click -= eventHandler;
        this._mnuAbsences = value;
        MenuItem mnuAbsences2 = this._mnuAbsences;
        if (mnuAbsences2 == null)
          return;
        mnuAbsences2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmSchedulerMain));
      this.mnuMain = new MainMenu(this.components);
      this.mnuScheduler = new MenuItem();
      this.mnuOpenSchedule = new MenuItem();
      this.mnuResetScheduler = new MenuItem();
      this.mnuDividerScheduler = new MenuItem();
      this.mnuCloseScheduler = new MenuItem();
      this.mnuAbsences = new MenuItem();
      this.mnuWeekSchedule = new MenuItem();
      this.mnuPrintWeek = new MenuItem();
      this.MenuItem1 = new MenuItem();
      this.MenuItem2 = new MenuItem();
      this.SuspendLayout();
      this.mnuMain.MenuItems.AddRange(new MenuItem[4]
      {
        this.mnuScheduler,
        this.mnuAbsences,
        this.mnuWeekSchedule,
        this.MenuItem2
      });
      this.mnuScheduler.Index = 0;
      this.mnuScheduler.MenuItems.AddRange(new MenuItem[4]
      {
        this.mnuOpenSchedule,
        this.mnuResetScheduler,
        this.mnuDividerScheduler,
        this.mnuCloseScheduler
      });
      this.mnuScheduler.Text = "&Scheduler";
      this.mnuOpenSchedule.Index = 0;
      this.mnuOpenSchedule.Shortcut = Shortcut.F2;
      this.mnuOpenSchedule.Text = "&Open";
      this.mnuResetScheduler.Index = 1;
      this.mnuResetScheduler.Shortcut = Shortcut.F3;
      this.mnuResetScheduler.Text = "&Reset";
      this.mnuDividerScheduler.Index = 2;
      this.mnuDividerScheduler.Text = "-";
      this.mnuCloseScheduler.Index = 3;
      this.mnuCloseScheduler.Text = "&Close";
      this.mnuAbsences.Index = 1;
      this.mnuAbsences.Text = "&Absences";
      this.mnuWeekSchedule.Index = 2;
      this.mnuWeekSchedule.MenuItems.AddRange(new MenuItem[2]
      {
        this.mnuPrintWeek,
        this.MenuItem1
      });
      this.mnuWeekSchedule.Text = "&Week Schedule";
      this.mnuWeekSchedule.Visible = false;
      this.mnuPrintWeek.Index = 0;
      this.mnuPrintWeek.Text = "&Print";
      this.MenuItem1.Index = 1;
      this.MenuItem1.Text = "frmVisit";
      this.MenuItem1.Visible = false;
      this.MenuItem2.Index = 3;
      this.MenuItem2.Text = "Development";
      this.MenuItem2.Visible = false;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(744, 371);
      this.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.IsMdiContainer = true;
      this.Menu = this.mnuMain;
      this.MinimumSize = new Size(752, 405);
      this.Name = nameof (frmSchedulerMain);
      this.ShowIcon = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Scheduler";
      this.WindowState = FormWindowState.Maximized;
      this.ResumeLayout(false);
    }

    public event frmSchedulerMain.OnVScrollEventHandler OnVScroll;

    private void mnuOpenSchedule_Click(object sender, EventArgs e)
    {
      this.scheduler.Open();
    }

    private void frmSchedulerMain_Load(object sender, EventArgs e)
    {
      this.scheduler = new Scheduler((Form) this);
      this.scheduler.Open();
    }

    private void mnuResetScheduler_Click(object sender, EventArgs e)
    {
      this.scheduler.reset();
    }

    private void mnuCloseScheduler_Click(object sender, EventArgs e)
    {
      this.scheduler.close();
      this.Dispose();
    }

    private void mnuPrintWeek_Click(object sender, EventArgs e)
    {
    }

    private void mnuAbsences_Click(object sender, EventArgs e)
    {
      frmAbsences frmAbsences = new frmAbsences();
      frmAbsences.Closing += new CancelEventHandler(this.FrmEngineerAbsenceClosing);
      int num = (int) frmAbsences.ShowDialog();
    }

    private void FrmEngineerAbsenceClosing(object sender, CancelEventArgs e)
    {
      this.scheduler.refreshScheduler();
    }

    private void frmSchedulerMain_Closing(object sender, CancelEventArgs e)
    {
      e.Cancel = true;
      this.scheduler.close();
    }

    public delegate void OnVScrollEventHandler(int position);
  }
}
