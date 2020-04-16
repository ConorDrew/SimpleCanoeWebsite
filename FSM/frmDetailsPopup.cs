// Decompiled with JetBrains decompiler
// Type: FSM.frmDetailsPopup
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace FSM
{
  public class frmDetailsPopup : Form
  {
    private ISchedulerForm _scheduleOwner;
    private IContainer components;
    private DateTime _CurrentPeriod;
    private bool _fadeIn;
    private Thread _fadeThread;

    public frmDetailsPopup(frmEngineerSchedule scheduleOwner)
    {
      this._timer = new System.Windows.Forms.Timer();
      this.InitializeComponent();
      Control.CheckForIllegalCrossThreadCalls = false;
      this.SetUpDg();
      this._timer.Interval = 3000;
      this._timer.Start();
      this._scheduleOwner = (ISchedulerForm) scheduleOwner;
    }

    public frmDetailsPopup(frmVisit scheduleOwner)
    {
      this._timer = new System.Windows.Forms.Timer();
      this.InitializeComponent();
      this.SetUpDg();
      this._timer.Interval = 3000;
      this._timer.Start();
      this._scheduleOwner = (ISchedulerForm) scheduleOwner;
      scheduleOwner.Closed += new EventHandler(this.frmVisitClosed);
    }

    protected override void Dispose(bool disposing)
    {
      try
      {
        if (disposing)
        {
          if (this.components != null)
            this.components.Dispose();
          this._timer.Stop();
          this._timer.Dispose();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      base.Dispose(disposing);
    }

    internal virtual Label lblPeriod { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlPeriod { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgSchedule { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFreePeriod { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.lblPeriod = new Label();
      this.pnlPeriod = new Panel();
      this.lblFreePeriod = new Label();
      this.dgSchedule = new DataGrid();
      this.pnlPeriod.SuspendLayout();
      this.dgSchedule.BeginInit();
      this.SuspendLayout();
      this.lblPeriod.BackColor = Color.SteelBlue;
      this.lblPeriod.Dock = DockStyle.Top;
      this.lblPeriod.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblPeriod.ForeColor = Color.White;
      this.lblPeriod.ImageAlign = ContentAlignment.MiddleLeft;
      this.lblPeriod.Location = new System.Drawing.Point(0, 0);
      this.lblPeriod.Name = "lblPeriod";
      this.lblPeriod.Size = new Size(550, 30);
      this.lblPeriod.TabIndex = 1;
      this.lblPeriod.Text = "Period";
      this.pnlPeriod.Controls.Add((Control) this.lblFreePeriod);
      this.pnlPeriod.Controls.Add((Control) this.dgSchedule);
      this.pnlPeriod.Controls.Add((Control) this.lblPeriod);
      this.pnlPeriod.Dock = DockStyle.Fill;
      this.pnlPeriod.Location = new System.Drawing.Point(0, 0);
      this.pnlPeriod.Name = "pnlPeriod";
      this.pnlPeriod.Size = new Size(550, 112);
      this.pnlPeriod.TabIndex = 2;
      this.lblFreePeriod.BackColor = Color.Transparent;
      this.lblFreePeriod.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblFreePeriod.ForeColor = Color.SteelBlue;
      this.lblFreePeriod.Location = new System.Drawing.Point(442, 111);
      this.lblFreePeriod.Name = "lblFreePeriod";
      this.lblFreePeriod.Size = new Size(256, 42);
      this.lblFreePeriod.TabIndex = 3;
      this.lblFreePeriod.Text = "Free Period";
      this.lblFreePeriod.TextAlign = ContentAlignment.MiddleCenter;
      this.lblFreePeriod.Visible = false;
      this.dgSchedule.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgSchedule.ColumnHeadersVisible = false;
      this.dgSchedule.DataMember = "";
      this.dgSchedule.HeaderForeColor = SystemColors.ControlText;
      this.dgSchedule.Location = new System.Drawing.Point(16, 44);
      this.dgSchedule.Name = "dgSchedule";
      this.dgSchedule.RowHeadersVisible = false;
      this.dgSchedule.Size = new Size(520, 57);
      this.dgSchedule.TabIndex = 2;
      this.AutoScaleBaseSize = new Size(10, 24);
      this.BackColor = Color.White;
      this.ClientSize = new Size(550, 112);
      this.Controls.Add((Control) this.pnlPeriod);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (frmDetailsPopup);
      this.Opacity = 0.0;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.Manual;
      this.Text = nameof (frmDetailsPopup);
      this.pnlPeriod.ResumeLayout(false);
      this.dgSchedule.EndInit();
      this.ResumeLayout(false);
    }

    private bool shiftIsHeldDown
    {
      get
      {
        return Control.ModifierKeys == Keys.Shift;
      }
    }

    public virtual System.Windows.Forms.Timer _timer
    {
      get
      {
        return this.__timer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Timer_tick);
        System.Windows.Forms.Timer timer1 = this.__timer;
        if (timer1 != null)
          timer1.Tick -= eventHandler;
        this.__timer = value;
        System.Windows.Forms.Timer timer2 = this.__timer;
        if (timer2 == null)
          return;
        timer2.Tick += eventHandler;
      }
    }

    public void Timer_tick(object myObject, EventArgs myEventArgs)
    {
      this.Hide();
    }

    public void LoadInfo()
    {
      DataTable table = App.DB.Scheduler.Scheduler_PlannerPopUp(this._CurrentPeriod, this._scheduleOwner.EngineerID);
      table.TableName = "Schedule";
      this.dgSchedule.DataSource = (object) new DataView(table)
      {
        AllowDelete = false,
        AllowEdit = false,
        AllowNew = false
      };
      if (checked (this.lblPeriod.Height + 25 * table.Rows.Count) > 112)
        this.Height = checked (this.lblPeriod.Height + 25 * table.Rows.Count);
      if (table.Rows.Count == 0)
      {
        this.Height = 112;
        this.lblFreePeriod.Visible = true;
      }
      else
        this.lblFreePeriod.Visible = false;
    }

    public Rectangle GetPosition(int handle)
    {
      Rectangle lpRect = new Rectangle();
      frmDetailsPopup.GetWindowRect(handle, ref lpRect);
      return lpRect;
    }

    private void frmVisitClosed(object sender, EventArgs e)
    {
      this._scheduleOwner = (ISchedulerForm) null;
    }

    private void SetUpDg()
    {
      ModScheduler.SetUpSchedulerDataGrid(this.dgSchedule, false);
      DataGridTableStyle tableStyle = this.dgSchedule.TableStyles[0];
      tableStyle.RowHeadersVisible = false;
      tableStyle.ColumnHeadersVisible = false;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.MappingName = "type";
      dataGridLabelColumn1.HeaderText = "type";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 55;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.MappingName = "subType";
      dataGridLabelColumn2.HeaderText = "subType";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 75;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.MappingName = "startTime";
      dataGridLabelColumn3.HeaderText = "Start";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Alignment = HorizontalAlignment.Left;
      dataGridLabelColumn3.Width = 40;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.MappingName = "endTime";
      dataGridLabelColumn4.HeaderText = "End";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Alignment = HorizontalAlignment.Left;
      dataGridLabelColumn4.Width = 40;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.MappingName = "Comments";
      dataGridLabelColumn5.HeaderText = "Comments";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Alignment = HorizontalAlignment.Left;
      dataGridLabelColumn5.Width = 300;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.MappingName = "Schedule";
    }

    public void MoveMoved(System.Drawing.Point ptLocat)
    {
      Control activeControl = Form.ActiveForm?.ActiveControl;
      if (activeControl != null && (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(activeControl.Name, "frmEngineerSchedule", false) > 0U)
      {
        this.Hide();
      }
      else
      {
        if (this._scheduleOwner == null || this._scheduleOwner.IsDisposed)
          return;
        if (this._scheduleOwner.TimeSlotDt == null)
          return;
        IEnumerator enumerator;
        try
        {
          enumerator = Application.OpenForms.GetEnumerator();
          while (enumerator.MoveNext())
          {
            if (((Form) enumerator.Current).Modal)
            {
              this.Hide();
              return;
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        IntPtr handle = this._scheduleOwner.PicPlanner.Handle;
        Rectangle position = this.GetPosition(checked ((int) handle.ToInt64()));
        Rectangle rectangle = new Rectangle(position.X, position.Y, this._scheduleOwner.PicPlanner.Width, this._scheduleOwner.PicPlanner.Height);
        if (rectangle.IntersectsWith(new Rectangle(ptLocat.X, ptLocat.Y, 1, 1)))
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this._scheduleOwner.Name.ToLower(), "frmVisit".ToLower(), false) == 0)
          {
            this.Hide();
          }
          else
          {
            int num1;
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this._scheduleOwner.Name.ToLower(), "frmVisit".ToLower(), false) == 0)
            {
              if (this.shiftIsHeldDown)
              {
                handle = this._scheduleOwner.Handle;
                num1 = checked ((int) (handle.ToInt64() + 1L));
              }
              else
              {
                handle = this._scheduleOwner.Handle;
                num1 = checked ((int) handle.ToInt64());
              }
            }
            else
            {
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this._scheduleOwner.Name.ToLower(), "frmEngineerSchedule".ToLower(), false) != 0)
                return;
              handle = this._scheduleOwner.Handle;
              num1 = checked ((int) handle.ToInt64());
            }
            long num2 = (long) num1;
            handle = this.Handle;
            long int64_1 = handle.ToInt64();
            int num3 = num2 == int64_1 ? 1 : 0;
            long num4 = (long) num1;
            handle = this._scheduleOwner.Handle;
            long int64_2 = handle.ToInt64();
            int num5 = num4 == int64_2 ? 1 : 0;
            int num6 = num3 | num5;
            long num7 = (long) num1;
            handle = this.pnlPeriod.Handle;
            long int64_3 = handle.ToInt64();
            int num8 = num7 == int64_3 ? 1 : 0;
            if ((num6 | num8) != 0)
            {
              this.Hide();
              this.Show();
              int num9 = checked ((int) Math.Round(unchecked ((double) checked (this._scheduleOwner.PicPlanner.Width - 9) / (double) checked (this._scheduleOwner.TimeSlotDt.Columns.Count - 1))));
              int num10 = Math.Abs(checked (rectangle.X - ptLocat.X));
              if (num10 / num9 != checked (this._scheduleOwner.TimeSlotDt.Columns.Count - 1))
              {
                string columnName1 = this._scheduleOwner.TimeSlotDt.Columns[num10 / num9].ColumnName;
                string str1 = columnName1.Substring(1, 2) + ":" + columnName1.Substring(3, 2);
                string columnName2 = this._scheduleOwner.TimeSlotDt.Columns[checked (unchecked (num10 / num9) + 1)].ColumnName;
                string str2 = columnName2.Substring(1, 2) + ":" + columnName2.Substring(3, 2);
                this.lblPeriod.Text = "Period: " + str1 + " - " + str2;
                DateTime t2;
                ref DateTime local = ref t2;
                int year = Conversions.ToDate(this._scheduleOwner.selectedDay()).Year;
                DateTime date = Conversions.ToDate(this._scheduleOwner.selectedDay());
                int month = date.Month;
                date = Conversions.ToDate(this._scheduleOwner.selectedDay());
                int day = date.Day;
                int integer1 = Conversions.ToInteger(str1.Substring(0, 2));
                int integer2 = Conversions.ToInteger(str1.Substring(3, 2));
                local = new DateTime(year, month, day, integer1, integer2, 0);
                if ((uint) DateTime.Compare(this._CurrentPeriod, t2) > 0U)
                {
                  this._CurrentPeriod = t2;
                  this.LoadInfo();
                }
              }
              else
                this.Hide();
            }
            else
              this.Hide();
          }
        }
        else
          this.Hide();
      }
    }

    [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern int WindowFromPoint(int xPoint, int yPoint);

    [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern int GetWindowRect(int hwnd, ref Rectangle lpRect);

    [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern int GetParent(int hwnd);

    [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true)]
    public static extern int BringWindowToTop(int hwnd);

    private void fade()
    {
      if (this._fadeIn & this.Opacity == 0.0)
        Thread.Sleep(250);
      while (this._fadeIn & this.Opacity != 100.0)
      {
        this.Opacity += 0.1;
        Thread.Sleep(50);
      }
      while (!this._fadeIn & this.Opacity != 0.0)
      {
        this.Opacity -= 0.1;
        Thread.Sleep(50);
      }
    }

    public new void Show()
    {
      if (Control.MousePosition.X < checked (Screen.PrimaryScreen.WorkingArea.Width - this.Width))
      {
        System.Drawing.Point mousePosition = Control.MousePosition;
        int x = checked (mousePosition.X + 1);
        mousePosition = Control.MousePosition;
        int y = checked (mousePosition.Y + 1);
        this.Location = new System.Drawing.Point(x, y);
      }
      else
      {
        System.Drawing.Point mousePosition = Control.MousePosition;
        int x = checked (mousePosition.X - this.Width - 1);
        mousePosition = Control.MousePosition;
        int y = checked (mousePosition.Y - 1);
        this.Location = new System.Drawing.Point(x, y);
      }
      frmDetailsPopup.ShowWindow(this.Handle, 4);
      frmDetailsPopup.BringWindowToTop(this.Handle.ToInt32());
      if (this._fadeThread != null && this._fadeThread.ThreadState != System.Threading.ThreadState.Stopped)
        return;
      this._fadeIn = true;
      this._fadeThread = new Thread(new ThreadStart(this.fade));
      this._fadeThread.Start();
    }

    public void Move()
    {
      if (Control.MousePosition.X < checked (Screen.PrimaryScreen.WorkingArea.Width - this.Width))
      {
        System.Drawing.Point mousePosition = Control.MousePosition;
        int x = checked (mousePosition.X + 1);
        mousePosition = Control.MousePosition;
        int y = checked (mousePosition.Y + 1);
        this.Location = new System.Drawing.Point(x, y);
      }
      else
      {
        System.Drawing.Point mousePosition = Control.MousePosition;
        int x = checked (mousePosition.X - this.Width - 1);
        mousePosition = Control.MousePosition;
        int y = checked (mousePosition.Y - 1);
        this.Location = new System.Drawing.Point(x, y);
      }
    }

    public new void Hide()
    {
      if (!this._fadeIn)
        return;
      this._fadeIn = false;
      if (this._fadeThread == null || this._fadeThread.ThreadState == System.Threading.ThreadState.Stopped)
      {
        this._fadeThread = new Thread(new ThreadStart(this.fade));
        this._fadeThread.Start();
      }
    }
  }
}
