using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class frmDetailsPopup : Form
    {
        public frmDetailsPopup()
        {
            _timer = new Timer();
        }

        public frmDetailsPopup(FrmVisit scheduleOwner) : base()
        {
            _timer = new Timer();

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            SetUpDg();
            _timer.Interval = 3000;
            _timer.Start();

            // Add any initialization after the InitializeComponent() call
            _scheduleOwner = scheduleOwner;
            scheduleOwner.Closed += frmVisitClosed;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public frmDetailsPopup(frmEngineerSchedule scheduleOwner) : base()
        {
            _timer = new Timer();

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            SetUpDg();
            _timer.Interval = 3000;
            _timer.Start();

            // Add any initialization after the InitializeComponent() call
            _scheduleOwner = scheduleOwner;
        }

        private ISchedulerForm _scheduleOwner;

        // Form overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (!(components is null))
                    {
                        components.Dispose();
                    }

                    _timer.Stop();
                    _timer.Dispose();
                }
            }
            catch (Exception ex)
            {
            }

            base.Dispose(disposing);
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
        private Label _lblPeriod;

        internal Label lblPeriod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPeriod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPeriod != null)
                {
                }

                _lblPeriod = value;
                if (_lblPeriod != null)
                {
                }
            }
        }

        private Panel _pnlPeriod;

        internal Panel pnlPeriod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlPeriod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlPeriod != null)
                {
                }

                _pnlPeriod = value;
                if (_pnlPeriod != null)
                {
                }
            }
        }

        private DataGrid _dgSchedule;

        internal DataGrid dgSchedule
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgSchedule;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgSchedule != null)
                {
                }

                _dgSchedule = value;
                if (_dgSchedule != null)
                {
                }
            }
        }

        private Label _lblFreePeriod;

        internal Label lblFreePeriod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFreePeriod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFreePeriod != null)
                {
                }

                _lblFreePeriod = value;
                if (_lblFreePeriod != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _lblPeriod = new Label();
            _pnlPeriod = new Panel();
            _lblFreePeriod = new Label();
            _dgSchedule = new DataGrid();
            _pnlPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSchedule).BeginInit();
            SuspendLayout();
            //
            // lblPeriod
            //
            _lblPeriod.BackColor = Color.SteelBlue;
            _lblPeriod.Dock = DockStyle.Top;
            _lblPeriod.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblPeriod.ForeColor = Color.White;
            _lblPeriod.ImageAlign = ContentAlignment.MiddleLeft;
            _lblPeriod.Location = new Point(0, 0);
            _lblPeriod.Name = "lblPeriod";
            _lblPeriod.Size = new Size(550, 30);
            _lblPeriod.TabIndex = 1;
            _lblPeriod.Text = "Period";
            //
            // pnlPeriod
            //
            _pnlPeriod.Controls.Add(_lblFreePeriod);
            _pnlPeriod.Controls.Add(_dgSchedule);
            _pnlPeriod.Controls.Add(_lblPeriod);
            _pnlPeriod.Dock = DockStyle.Fill;
            _pnlPeriod.Location = new Point(0, 0);
            _pnlPeriod.Name = "pnlPeriod";
            _pnlPeriod.Size = new Size(550, 112);
            _pnlPeriod.TabIndex = 2;
            //
            // lblFreePeriod
            //
            _lblFreePeriod.BackColor = Color.Transparent;
            _lblFreePeriod.Font = new Font("Microsoft Sans Serif", 10.0F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblFreePeriod.ForeColor = Color.SteelBlue;
            _lblFreePeriod.Location = new Point(442, 111);
            _lblFreePeriod.Name = "lblFreePeriod";
            _lblFreePeriod.Size = new Size(256, 42);
            _lblFreePeriod.TabIndex = 3;
            _lblFreePeriod.Text = "Free Period";
            _lblFreePeriod.TextAlign = ContentAlignment.MiddleCenter;
            _lblFreePeriod.Visible = false;
            //
            // dgSchedule
            //
            _dgSchedule.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgSchedule.ColumnHeadersVisible = false;
            _dgSchedule.DataMember = "";
            _dgSchedule.HeaderForeColor = SystemColors.ControlText;
            _dgSchedule.Location = new Point(16, 44);
            _dgSchedule.Name = "dgSchedule";
            _dgSchedule.RowHeadersVisible = false;
            _dgSchedule.Size = new Size(520, 57);
            _dgSchedule.TabIndex = 2;
            //
            // frmDetailsPopup
            //
            AutoScaleBaseSize = new Size(10, 24);
            BackColor = Color.White;
            ClientSize = new Size(550, 112);
            Controls.Add(_pnlPeriod);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmDetailsPopup";
            Opacity = 0D;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "frmDetailsPopup";
            _pnlPeriod.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgSchedule).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

        private bool shiftIsHeldDown
        {
            get
            {
                if (ModifierKeys == Keys.Shift)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private DateTime _CurrentPeriod;
        private Timer __timer;

        public Timer _timer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return __timer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (__timer != null)
                {
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    __timer.Tick -= Timer_tick;
                }

                __timer = value;
                if (__timer != null)
                {
                    __timer.Tick += Timer_tick;
                }
            }
        }

        public void Timer_tick(object myObject, EventArgs myEventArgs)
        {
            Hide();
        }

        public void LoadInfo()
        {
            var dtSchedule = App.DB.Scheduler.Scheduler_PlannerPopUp(_CurrentPeriod, _scheduleOwner.EngineerID);
            dtSchedule.TableName = "Schedule";
            var dvSchedule = new DataView(dtSchedule);
            dvSchedule.AllowDelete = false;
            dvSchedule.AllowEdit = false;
            dvSchedule.AllowNew = false;
            dgSchedule.DataSource = dvSchedule;
            if (lblPeriod.Height + 25 * dtSchedule.Rows.Count > 112)
            {
                Height = lblPeriod.Height + 25 * dtSchedule.Rows.Count;
            }

            if (dtSchedule.Rows.Count == 0)
            {
                Height = 112;
                lblFreePeriod.Visible = true;
            }
            else
            {
                lblFreePeriod.Visible = false;
            }
        }

        public Rectangle GetPosition(int handle)
        {
            var rect = new Rectangle();
            GetWindowRect(handle, ref rect);
            return rect;
        }

        private void frmVisitClosed(object sender, EventArgs e)
        {
            _scheduleOwner = null;
        }

        private void SetUpDg()
        {
            ModScheduler.SetUpSchedulerDataGrid(dgSchedule, false);
            var tsSummary = dgSchedule.TableStyles[0];
            tsSummary.RowHeadersVisible = false;
            tsSummary.ColumnHeadersVisible = false;
            var type = new DataGridLabelColumn();
            type.MappingName = "type";
            type.HeaderText = "type";
            type.ReadOnly = true;
            type.Width = 55;
            tsSummary.GridColumnStyles.Add(type);
            var subType = new DataGridLabelColumn();
            subType.MappingName = "subType";
            subType.HeaderText = "subType";
            subType.ReadOnly = true;
            subType.Width = 75;
            tsSummary.GridColumnStyles.Add(subType);
            var startTime = new DataGridLabelColumn();
            startTime.MappingName = "startTime";
            startTime.HeaderText = "Start";
            startTime.ReadOnly = true;
            startTime.Alignment = HorizontalAlignment.Left;
            startTime.Width = 40;
            tsSummary.GridColumnStyles.Add(startTime);
            var endTime = new DataGridLabelColumn();
            endTime.MappingName = "endTime";
            endTime.HeaderText = "End";
            endTime.ReadOnly = true;
            endTime.Alignment = HorizontalAlignment.Left;
            endTime.Width = 40;
            tsSummary.GridColumnStyles.Add(endTime);
            var Comments = new DataGridLabelColumn();
            Comments.MappingName = "Comments";
            Comments.HeaderText = "Comments";
            Comments.ReadOnly = true;
            Comments.Alignment = HorizontalAlignment.Left;
            Comments.Width = 300;
            tsSummary.GridColumnStyles.Add(Comments);
            tsSummary.MappingName = "Schedule";
        }

        public void MoveMoved(Point ptLocat)
        {
            // Exit Sub 'affects the second tab, after discussion with RobD discussed it was not necessary
            var activeForm = ActiveForm;
            var activeControl = activeForm is object ? activeForm.ActiveControl : null;
            if (activeControl is object && (activeControl.Name ?? "") != "frmEngineerSchedule")
            {
                Hide();
                return;
            }

            if (_scheduleOwner is object && !(_scheduleOwner.IsDisposed == true))
            {
                if (_scheduleOwner.TimeSlotDt is object)
                {
                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm.Modal == true)
                        {
                            Hide();
                            return;
                        }
                    }

                    var picPlannerPos = GetPosition(Conversions.ToInteger(_scheduleOwner.PicPlanner.Handle.ToInt64()));
                    var picPlannerLocation = new Rectangle(picPlannerPos.X, picPlannerPos.Y, _scheduleOwner.PicPlanner.Width, _scheduleOwner.PicPlanner.Height);
                    if (picPlannerLocation.IntersectsWith(new Rectangle(ptLocat.X, ptLocat.Y, 1, 1)))
                    {
                        int parentHandle;
                        if ((_scheduleOwner.Name.ToLower() ?? "") == ("frmVisit".ToLower() ?? ""))
                        {
                            Hide();
                            return;
                        }

                        if ((_scheduleOwner.Name.ToLower() ?? "") == ("frmVisit".ToLower() ?? ""))
                        {
                            if (shiftIsHeldDown)
                            {
                                // FORCE IT NOT TO POP UP
                                parentHandle = (int)(_scheduleOwner.Handle.ToInt64() + 1);
                            }
                            else
                            {
                                // FORCE IT TO POP UP
                                parentHandle = Conversions.ToInteger(_scheduleOwner.Handle.ToInt64());
                            }
                        }
                        else if ((_scheduleOwner.Name.ToLower() ?? "") == ("frmEngineerSchedule".ToLower() ?? ""))
                        {
                            parentHandle = Conversions.ToInteger(_scheduleOwner.Handle.ToInt64()); // GetParent(WindowFromPoint(x, y))
                        }
                        else
                        {
                            return;
                        }

                        if (parentHandle == Handle.ToInt64() | parentHandle == _scheduleOwner.Handle.ToInt64() | parentHandle == pnlPeriod.Handle.ToInt64())
                        {
                            Hide();
                            Show();
                            int slotWidth = (int)(Conversions.ToSingle(_scheduleOwner.PicPlanner.Width - 9) / Conversions.ToSingle(_scheduleOwner.TimeSlotDt.Columns.Count - 1));
                            int posInPlanner = Math.Abs(picPlannerLocation.X - ptLocat.X);
                            if (!(Conversions.ToInteger(posInPlanner / slotWidth) == _scheduleOwner.TimeSlotDt.Columns.Count - 1))
                            {
                                string timeColumnFrom = _scheduleOwner.TimeSlotDt.Columns[Conversions.ToInteger(posInPlanner / slotWidth)].ColumnName;
                                timeColumnFrom = timeColumnFrom.Substring(1, 2) + ":" + timeColumnFrom.Substring(3, 2);
                                string timeColumnTo = _scheduleOwner.TimeSlotDt.Columns[Conversions.ToInteger(posInPlanner / slotWidth) + 1].ColumnName;
                                timeColumnTo = timeColumnTo.Substring(1, 2) + ":" + timeColumnTo.Substring(3, 2);
                                lblPeriod.Text = "Period: " + timeColumnFrom + " - " + timeColumnTo;
                                var dateTimefrom = new DateTime(Conversions.ToDate(_scheduleOwner.selectedDay()).Year, Conversions.ToDate(_scheduleOwner.selectedDay()).Month, Conversions.ToDate(_scheduleOwner.selectedDay()).Day, Conversions.ToInteger(timeColumnFrom.Substring(0, 2)), Conversions.ToInteger(timeColumnFrom.Substring(3, 2)), 0);
                                if (DateTime.Compare(_CurrentPeriod, dateTimefrom) != 0)
                                {
                                    _CurrentPeriod = dateTimefrom;
                                    LoadInfo();
                                }
                            }
                            else
                            {
                                Hide();
                            }
                        }
                        else
                        {
                            Hide();
                        }
                    }
                    else
                    {
                        Hide();
                    }
                }
            }
            else
            {
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        [DllImport("user32")]
        private static extern int WindowFromPoint(int xPoint, int yPoint);

        [DllImport("user32")]
        private static extern int GetWindowRect(int hwnd, ref Rectangle lpRect);

        [DllImport("user32")]
        private static extern int GetParent(int hwnd);

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        [DllImport("user32")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32")]
        private static extern int BringWindowToTop(int hwnd);

        private bool _fadeIn;
        private System.Threading.Thread _fadeThread;

        private void fade()
        {
            if (_fadeIn == true & Opacity == 0.0)
            {
                System.Threading.Thread.Sleep(250);
            }

            while (_fadeIn == true & Opacity != 100.0)
            {
                Opacity += 0.1;
                System.Threading.Thread.Sleep(50);
            }

            while (_fadeIn == false & Opacity != 0.0)
            {
                Opacity -= 0.1;
                System.Threading.Thread.Sleep(50);
            }
        }

        public new void Show()
        {
            if (MousePosition.X < Screen.PrimaryScreen.WorkingArea.Width - Width)
            {
                Location = new Point(MousePosition.X + 1, MousePosition.Y + 1);
            }
            else
            {
                Location = new Point(MousePosition.X - Width - 1, MousePosition.Y - 1);
            }

            ShowWindow(Handle, 4); // SW_SHOWNOACTIVATE
            BringWindowToTop(Handle.ToInt32());
            if (_fadeThread is null || _fadeThread.ThreadState == System.Threading.ThreadState.Stopped)
            {
                _fadeIn = true;
                _fadeThread = new System.Threading.Thread(fade);
                _fadeThread.Start();
            }
        }

        public new void Move()
        {
            if (MousePosition.X < Screen.PrimaryScreen.WorkingArea.Width - Width)
            {
                Location = new Point(MousePosition.X + 1, MousePosition.Y + 1);
            }
            else
            {
                Location = new Point(MousePosition.X - Width - 1, MousePosition.Y - 1);
            }
        }

        public new void Hide()
        {
            if (_fadeIn == true)
            {
                _fadeIn = false;
                if (_fadeThread is null || _fadeThread.ThreadState == System.Threading.ThreadState.Stopped)
                {
                    _fadeThread = new System.Threading.Thread(fade);
                    _fadeThread.Start();
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}