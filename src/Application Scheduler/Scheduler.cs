using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace FSM
{
    // Imports FSM.Entity.EngineerTimeSheets

    public class Scheduler
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private Form __mdiParent;

        private Form _mdiParent
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return __mdiParent;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                __mdiParent = value;
            }
        }

        private pnlUnscheduledCalls __unscheduledCalls;

        private pnlUnscheduledCalls _unscheduledCalls
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return __unscheduledCalls;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                __unscheduledCalls = value;
            }
        }

        private MdiClient __mdiClient;

        private MdiClient _mdiClient
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return __mdiClient;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                __mdiClient = value;
            }
        }

        private ArrayList _engineerSchedules = new ArrayList();
        private pnlScheduleControl _ScheduleControl;
        private double _engineerScheduleColumnCount = 1;
        private double _engineerScheduleHeight = 200;
        public DateTime FromDate = DateAndTime.Now;
        public DateTime ToDate = DateAndTime.Now.AddDays(10);
        private int _OldEngineerVisitID = 0;
        public DataTable DtSummary;
        public int textsize;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public class scheduleComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                frmEngineerSchedule scheduleX = (frmEngineerSchedule)x;
                frmEngineerSchedule scheduleY = (frmEngineerSchedule)y;
                if (Conversions.ToInteger(scheduleX.EngineerID) < Conversions.ToInteger(scheduleY.EngineerID))
                {
                    return -1;
                }
                else if ((scheduleX.EngineerID ?? "") == (scheduleY.EngineerID ?? ""))
                {
                    return 0;
                }
                else if (Conversions.ToInteger(scheduleX.EngineerID) > Conversions.ToInteger(scheduleY.EngineerID))
                {
                    return 1;
                }

                return default;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

        // 'This function gets called when a row is dragged and dropped, forEngineer = 0 when it is dragged onto
        // 'the unscheduled call grid
        // 'Returns true to continue Scheduling row, or false to cancel
        public bool scheduleRowManipulation(ref DataRowView scheduleRow, int forEngineer, DateTime forDate, bool copy, [Optional, DefaultParameterValue(0)] ref int appointment)
        {
            int AMPMEngineerVisitID = Conversions.ToInteger(scheduleRow["EngineerVisitID"]);
            bool @continue;
            scheduleRow.BeginEdit();
            if (copy == true)
            {
                _OldEngineerVisitID = Conversions.ToInteger(scheduleRow["EngineerVisitID"]);
                scheduleRow["EngineerVisitID"] = 0;
            }

            if (forEngineer != 0)
            {
                var visitDialog = new frmVisit(forEngineer, forDate, Entity.Sys.Helper.MakeIntegerValid(scheduleRow["SummedSOR"]), AMPMEngineerVisitID, copy);
                if (visitDialog.ShowDialog() == DialogResult.OK)
                {
                    @continue = true;
                }
                else
                {
                    @continue = false;
                }
                // check if multiple visits were created
                if (visitDialog.mulitpleVisits)
                {
                    int index = 0;

                    // create the visits
                    foreach (List<DateTime> item in visitDialog.VisitsList)
                    {
                        // update the first visit like we used to
                        if (index == 0)
                        {
                            scheduleRow["StartDateTime"] = item[0];
                            scheduleRow["EndDateTime"] = item[1];
                            index += 1;
                        }
                        else
                        {
                            // create new visit
                            var visit = new Entity.EngineerVisits.EngineerVisit();
                            visit.IgnoreExceptionsOnSetMethods = true;
                            visit.SetJobOfWorkID = Entity.Sys.Helper.MakeIntegerValid(scheduleRow["JobOfWorkID"]);
                            visit.SetEngineerID = forEngineer;
                            visit.StartDateTime = item[0];
                            visit.EndDateTime = item[1];
                            visit.SetStatusEnumID = Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Scheduled);
                            visit.SetNotesToEngineer = scheduleRow["NotesToEngineer"];
                            visit.SetAppointmentID = visitDialog.AppointmentType;
                            int jobId = Entity.Sys.Helper.MakeIntegerValid(scheduleRow["JobID"]);
                            visit = App.DB.EngineerVisits.Insert(visit, jobId, visitDialog.AppointmentType);
                        }
                    }
                }
                else
                {
                    scheduleRow["StartDateTime"] = visitDialog.StartDate;
                    scheduleRow["EndDateTime"] = visitDialog.EndDate;
                }

                scheduleRow["visitstatusid"] = Entity.Sys.Enums.VisitStatus.Scheduled;
                scheduleRow["visitstatus"] = "Scheduled";
                scheduleRow["engineerID"] = forEngineer;
                scheduleRow["AppointmentID"] = visitDialog.AppointmentType;
                appointment = visitDialog.AppointmentType;
            }
            else
            {
                scheduleRow["visitstatusid"] = Entity.Sys.Enums.VisitStatus.Ready_For_Schedule;
                scheduleRow["visitstatus"] = "Ready For Schedule";
                scheduleRow["engineerId"] = 0;
                scheduleRow["StartDateTime"] = DBNull.Value;
                scheduleRow["EndDateTime"] = DBNull.Value;
                @continue = true;
            }

            scheduleRow.EndEdit();
            return @continue;
        }

        // This function gets called when a row is dragged
        // Returns true to allow the drag, or false to cancel
        public bool canMoveRow(ref DataRowView scheduleRow, ref bool heartOk)
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(scheduleRow["visitstatusid"], Entity.Sys.Enums.VisitStatus.Scheduled, false) | Operators.ConditionalCompareObjectEqual(scheduleRow["visitstatusid"], Entity.Sys.Enums.VisitStatus.Ready_For_Schedule, false)))
            {
                return true;
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(scheduleRow["visitstatusid"], Entity.Sys.Enums.VisitStatus.Downloaded, false)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataTable _engineers = null;

        public DataTable Engineers
        {
            get
            {
                return _engineers;
            }

            set
            {
                _engineers = value;
            }
        }

        private bool Closing = false;
        private TimeSpan TwoMins = new TimeSpan(0, 2, 0);

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public Scheduler(Form mdiParent)
        {
            foreach (Control ctl in mdiParent.Controls)
            {
                if (ctl is MdiClient)
                {
                    _mdiClient = (MdiClient)ctl;
                    break;
                }
            }

            _mdiParent = mdiParent;
            LoadEngineers();
        }

        public void LoadEngineers()
        {
            var dt = App.DB.Engineer.Engineer_GetAll_Scheduler().Table;
            var c = new DataColumn("Include", typeof(bool));
            c.DefaultValue = true;
            dt.Columns.Add(c);
            dt.AcceptChanges();
            foreach (DataRow r in dt.Rows)
                r["Include"] = false;
            Engineers = dt;
        }

        public class engineerSchedulerComparerByID : IComparer
        {
            public int Compare(object x, object y)
            {
                frmEngineerSchedule xEngineerSchedule = (frmEngineerSchedule)x;
                return Conversions.ToInteger(xEngineerSchedule.EngineerID).CompareTo(y);
            }
        }

        public class engineerSchedulerComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                frmEngineerSchedule xEngineerSchedule = (frmEngineerSchedule)x;
                frmEngineerSchedule yEngineerSchedule = (frmEngineerSchedule)y;
                return Conversions.ToInteger(xEngineerSchedule.EngineerID).CompareTo(Conversions.ToInteger(yEngineerSchedule.EngineerID));
            }
        }

        private bool CheckSchedulesAreOpening()
        {
            bool b = false;
            foreach (frmEngineerSchedule engineerSchedule in _engineerSchedules)
            {
                if (engineerSchedule.opening == true)
                {
                    b = true;
                }
            }

            return b;
        }

        public void loadEngineerSchedules(DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                _mdiClient.Resize -= ControlResize;
                _unscheduledCalls.Resize -= ControlResize;
                FromDate = dateFrom;
                ToDate = dateTo;
                Cursor.Current = Cursors.WaitCursor;
                _mdiClient.Enabled = false;
                var engineerScheduleWidth = default(double);
                int index = 0;
                foreach (DataRow engineer in Engineers.Select("Include"))
                {
                    double newWidth = Conversions.ToDouble((double)_mdiClient.ClientSize.Width / _engineerScheduleColumnCount);
                    if (newWidth != engineerScheduleWidth)
                    {
                        engineerScheduleWidth = Conversions.ToDouble((double)_mdiClient.ClientSize.Width / _engineerScheduleColumnCount);
                        foreach (frmEngineerSchedule schedule in _engineerSchedules)
                            schedule.Width = Conversions.ToInteger(engineerScheduleWidth);
                    }

                    index += 1;
                    int row = Conversions.ToInteger(Math.Ceiling(index / _engineerScheduleColumnCount));
                    int col = Conversions.ToInteger(Math.Floor(index / (double)row));
                    var engineerSchedule = new frmEngineerSchedule(gridMouseDown, gridMouseMove, gridDragOver, gridDragDrop, gridMouseUp, engineer, _ScheduleControl.textsize);
                    engineerSchedule.FormClosing += ScheduleClosing;
                    engineerSchedule.StartPosition = FormStartPosition.Manual;
                    engineerSchedule.MdiParent = _mdiParent;
                    engineerSchedule.Left = Conversions.ToInteger(engineerScheduleWidth * (col - 1));
                    engineerSchedule.Width = Conversions.ToInteger(engineerScheduleWidth);
                    engineerSchedule.Top = Conversions.ToInteger((int)_engineerScheduleHeight * (row - 1));
                    engineerSchedule.Height = Conversions.ToInteger(_engineerScheduleHeight);
                    engineerSchedule.Show();
                    Application.DoEvents();
                    var startDate = dateFrom;
                    _engineerSchedules.Add(engineerSchedule);
                }

                _mdiClient.Resize += ControlResize;
                _unscheduledCalls.Resize += ControlResize;
                _mdiClient.Enabled = true;
                Cursor.Current = Cursors.Default;
                refreshScheduler();
            }
            catch (Exception ex)
            {
            }
        }

        public void ScheduleClosing(object sender, FormClosingEventArgs e)
        {
            while (CheckSchedulesAreOpening() == true | refreshPeopleSchedulesAsyncResult.IsCompleted == false)
            {
                if (!App.loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) == true)
                    System.Threading.Thread.Sleep(100);
            }

            // Closing = True
            e.Cancel = true;
            frmEngineerSchedule engineerSchedule = (frmEngineerSchedule)sender;
            engineerSchedule.Hide();
            _engineerSchedules.Remove(engineerSchedule);
            engineerSchedule.EngineerScheduleTimer.Stop();
            engineerSchedule.EngineerScheduleTimer.Dispose();
            engineerSchedule.Dispose();
            while (engineerSchedule.opening == true)
            {
                if (!App.loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) == true)
                    System.Threading.Thread.Sleep(100);
            }

            orderScheduleWindows();
        }

        public void reset()
        {
            orderScheduleWindows();
            refreshPeopleSchedules();
            loadWork(_ScheduleControl.dateFrom, _ScheduleControl.dateTo);
        }

        public void close()
        {
            while (CheckSchedulesAreOpening() == true | refreshPeopleSchedulesAsyncResult.IsCompleted == false)
            {
                if (!App.loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) == true)
                    System.Threading.Thread.Sleep(100);
            }

            Closing = true;
            foreach (frmEngineerSchedule engineerSchedule in _engineerSchedules)
                engineerSchedule.Dispose();
            if (_unscheduledCalls is object)
            {
                _unscheduledCalls.Hide();
                if (_unscheduledCalls.unscheduledCalls is object)
                {
                    _unscheduledCalls.unscheduledCalls.Clear();
                }
            }

            if (_engineerSchedules is object)
            {
                _engineerSchedules.Clear();
            }

            _mdiParent.Dispose();
        }

        public void ResizeSchedulingArea()
        {
            _mdiParent.Controls.Remove(_unscheduledCalls);
            _mdiParent.Controls.Remove(_ScheduleControl);
            Closing = false;
            int ts = 0;
            if (App.loggedInUser.SchedulerTextSize > 0)
            {
                ts = App.loggedInUser.SchedulerTextSize;
            }
            else
            {
                ts = 8;
            }

            _unscheduledCalls = new pnlUnscheduledCalls(gridMouseDown, gridMouseMove, gridDragOver, gridDragDrop, gridMouseUp, ts);
            _unscheduledCalls.Dock = DockStyle.Left;
            _mdiParent.Controls.Add(_unscheduledCalls);
            _ScheduleControl.Dock = DockStyle.Top;
            _mdiParent.Controls.Add(_ScheduleControl);
            LoadUnscheduledWork();
            foreach (frmEngineerSchedule engineerSchedule in _engineerSchedules.ToArray(typeof(frmEngineerSchedule)))
            {
                engineerSchedule.Close();
                engineerSchedule.Dispose();
            }

            if (Closing == false)
            {
                loadEngineerSchedules(_ScheduleControl.dateFrom, _ScheduleControl.dateTo);
            }

            Application.DoEvents();
            if (App.loggedInUser.SchedulerDayView)
            {
                _ScheduleControl.dateFrom = FromDate;
                _ScheduleControl.dateTo = FromDate;
                _ScheduleControl.btnBack.Visible = true;
                _ScheduleControl.btnForward.Visible = true;
                foreach (DataRow dr in Engineers.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["EngineerGroupID"], App.loggedInUser.DefaultEngineerGroup, false)))
                        dr["include"] = 1;
                }

                if (refreshPeopleSchedulesAsyncResult is object)
                {
                    endSummaryRefresh = true;
                    while (refreshPeopleSchedulesAsyncResult.IsCompleted == false)
                    {
                        if (!App.loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) == true)
                            System.Threading.Thread.Sleep(50);
                        Application.DoEvents();
                    }
                }

                if (ScheduleDropIconsAsyncResult is object)
                {
                    endDropIconsRefresh = true;
                    while (ScheduleDropIconsAsyncResult.IsCompleted == false)
                    {
                        if (!App.loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) == true)
                            System.Threading.Thread.Sleep(50);
                        Application.DoEvents();
                    }
                }

                foreach (frmEngineerSchedule engineerSchedule in _engineerSchedules.ToArray(typeof(frmEngineerSchedule)))
                {
                    engineerSchedule.Close();
                    engineerSchedule.Dispose();
                }

                _mdiClient.ResumeLayout(false);
                _mdiClient.Visible = true;
                _engineerSchedules.Clear();
                loadEngineerSchedules(FromDate, ToDate);
                Application.DoEvents();
                Cursor.Current = Cursors.Default;
            }
            else
            {
                _ScheduleControl.btnBack.Visible = false;
                _ScheduleControl.btnForward.Visible = false;
            }
        }

        public void Open()
        {
            Closing = false;
            int ts = 0;
            if (App.loggedInUser.SchedulerTextSize > 0)
            {
                ts = App.loggedInUser.SchedulerTextSize;
            }
            else
            {
                ts = 7;
            }

            if (_unscheduledCalls is null)
            {
                _unscheduledCalls = new pnlUnscheduledCalls(gridMouseDown, gridMouseMove, gridDragOver, gridDragDrop, gridMouseUp, ts);
                _unscheduledCalls.Dock = DockStyle.Left;
                _mdiParent.Controls.Add(_unscheduledCalls);
            }

            if (_ScheduleControl is null)
            {
                _ScheduleControl = new pnlScheduleControl();
                _ScheduleControl.dateFrom = FromDate;
                _ScheduleControl.dateTo = ToDate;
                _ScheduleControl.dateRangeChanged += loadWork;
                _ScheduleControl.refreshScheduler += refreshScheduler;
                _ScheduleControl.closeScheduler += close;
                _ScheduleControl.displayEngineers += displayEngineers;
                _ScheduleControl.loadEngineerSchedules += loadEngineerSchedules;
                _ScheduleControl.ResizeSchedulingArea += ResizeSchedulingArea;
                _ScheduleControl.Dock = DockStyle.Top;
                _mdiParent.Controls.Add(_ScheduleControl);
            }

            if (Closing == false)
            {
                loadEngineerSchedules(_ScheduleControl.dateFrom, _ScheduleControl.dateTo);
            }

            Application.DoEvents();
            if (App.loggedInUser.SchedulerDayView)
            {
                _ScheduleControl.dateFrom = FromDate;
                _ScheduleControl.dateTo = FromDate;
                _ScheduleControl.btnBack.Visible = true;
                _ScheduleControl.btnForward.Visible = true;
                foreach (DataRow dr in Engineers.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["EngineerGroupID"], App.loggedInUser.DefaultEngineerGroup, false)))
                        dr["include"] = 1;
                }

                if (refreshPeopleSchedulesAsyncResult is object)
                {
                    endSummaryRefresh = true;
                    while (refreshPeopleSchedulesAsyncResult.IsCompleted == false)
                    {
                        if (!App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures))
                            System.Threading.Thread.Sleep(50);
                        Application.DoEvents();
                    }
                }

                if (ScheduleDropIconsAsyncResult is object)
                {
                    endDropIconsRefresh = true;
                    while (ScheduleDropIconsAsyncResult.IsCompleted == false)
                    {
                        if (!App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures))
                            System.Threading.Thread.Sleep(50);
                        Application.DoEvents();
                    }
                }

                foreach (frmEngineerSchedule engineerSchedule in _engineerSchedules.ToArray(typeof(frmEngineerSchedule)))
                {
                    engineerSchedule.Close();
                    engineerSchedule.Dispose();
                }

                _mdiClient.ResumeLayout(false);
                _mdiClient.Visible = true;
                _engineerSchedules.Clear();
                loadEngineerSchedules(FromDate, ToDate);
                Application.DoEvents();
                Cursor.Current = Cursors.Default;
            }
            else
            {
                _ScheduleControl.btnBack.Visible = false;
                _ScheduleControl.btnForward.Visible = false;
            }
        }

        public void displayEngineers()
        {
            Closing = false;
            _mdiClient.Resize -= ControlResize;
            _unscheduledCalls.Resize -= ControlResize;
            var f = new FrmDisplayEngineers();
            f.EngineersDataView = new DataView(Engineers);
            f.ShowDialog();
            _mdiClient.Visible = false;
            _mdiClient.SuspendLayout();
            Cursor.Current = Cursors.WaitCursor;
            if (refreshPeopleSchedulesAsyncResult is object)
            {
                endSummaryRefresh = true;
                while (refreshPeopleSchedulesAsyncResult.IsCompleted == false)
                {
                    if (!App.loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) == true)
                        System.Threading.Thread.Sleep(50);
                    Application.DoEvents();
                }
            }

            if (ScheduleDropIconsAsyncResult is object)
            {
                endDropIconsRefresh = true;
                while (ScheduleDropIconsAsyncResult.IsCompleted == false)
                {
                    if (!App.loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) == true)
                        System.Threading.Thread.Sleep(50);
                    Application.DoEvents();
                }
            }

            foreach (frmEngineerSchedule engineerSchedule in _engineerSchedules.ToArray(typeof(frmEngineerSchedule)))
            {
                engineerSchedule.Close();
                engineerSchedule.Dispose();
            }

            _mdiClient.ResumeLayout(false);
            _mdiClient.Visible = true;
            _engineerSchedules.Clear();
            loadEngineerSchedules(FromDate, ToDate);
            Application.DoEvents();
            Cursor.Current = Cursors.Default;
        }

        public void refreshScheduler()
        {
            if (_ScheduleControl is object)
            {
                loadWork(_ScheduleControl.dateFrom, _ScheduleControl.dateTo);
            }

            LoadUnscheduledWork();
        }

        public void loadWork(DateTime fromDate, DateTime toDate)
        {
            FromDate = fromDate;
            ToDate = toDate;
            refreshPeopleSchedules();
        }

        private delegate void refreshPeopleSchedulesDelegate();

        private bool endSummaryRefresh;
        private IAsyncResult refreshPeopleSchedulesAsyncResult;

        private void refreshPeopleSchedules()
        {
            Cursor.Current = Cursors.WaitCursor;
            var refreshPeople = new refreshPeopleSchedulesDelegate(refreshPeopleSchedulesBegin);
            var refreshCallback = new AsyncCallback(refreshPeopleScheulesComplete);
            if (refreshPeopleSchedulesAsyncResult is object)
            {
                endSummaryRefresh = true;
                while (refreshPeopleSchedulesAsyncResult.IsCompleted == false)
                {
                    Application.DoEvents();
                    if (!App.loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) == true)
                        System.Threading.Thread.Sleep(30);
                }

                endSummaryRefresh = false;
            }

            refreshPeopleSchedulesAsyncResult = refreshPeople.BeginInvoke(refreshCallback, null);
        }

        private void refreshPeopleSchedulesBegin()
        {
            var refreshed = new ArrayList();
            var currentList = _engineerSchedules;
            while (refreshed.Count != currentList.Count & endSummaryRefresh == false)
            {
                try
                {
                    foreach (frmEngineerSchedule engineerSchedule in currentList)
                    {
                        var refreshArea = new Rectangle(0, 0, _mdiClient.Width, _mdiClient.Height);
                        if (Closing == false)
                        {
                            engineerSchedule.Reset();
                            engineerSchedule.RefreshSummary(Conversions.ToString(_ScheduleControl.dateFrom), Conversions.ToString(_ScheduleControl.dateTo));
                            refreshed.Add(engineerSchedule.EngineerID);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    if (ex.InnerException is object)
                    {
                        msg += Constants.vbCrLf + "Inner Exception:" + Constants.vbCrLf + ex.InnerException.Message;
                    }

                    App.LogError(ex.GetType().Name, msg, ex.StackTrace);
                }

                Application.DoEvents();
                if (!App.loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) == true)
                    System.Threading.Thread.Sleep(75);
            }
        }

        private void refreshPeopleScheulesComplete(IAsyncResult ar)
        {
            Cursor.Current = Cursors.Default;
            refreshPeopleSchedulesDelegate o_MyDelegate = (refreshPeopleSchedulesDelegate)((AsyncResult)ar).AsyncDelegate;
            try
            {
                foreach (frmEngineerSchedule engineerSchedule in _engineerSchedules)
                {
                    engineerSchedule.Enabled = true;
                    engineerSchedule.opening = false;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (ex.InnerException is object)
                {
                    msg += Constants.vbCrLf + "Inner Exception:" + Constants.vbCrLf + ex.InnerException.Message;
                }

                App.LogError(ex.GetType().Name, msg, ex.StackTrace);
            }

            endSummaryRefresh = false;
            o_MyDelegate.EndInvoke(ar);
        }

        private delegate DataTable loadUnsheduledWorkDelegate();

        public void LoadUnscheduledWork()
        {
            var loadWork = new loadUnsheduledWorkDelegate(LoadUnsheduledWorkBegin);
            var loadWorkCallback = new AsyncCallback(loadUnsheduledWorkEnd);
            loadWork.BeginInvoke(loadWorkCallback, null);
        }

        public DataTable LoadUnsheduledWorkBegin()
        {
            var dtUnscheduledWork = new DataTable();
            bool viewAll = _unscheduledCalls?.chkViewAll.Checked == true;
            if (viewAll)
            {
                viewAll = App.ShowMessage("Do you wish to continue?" + Constants.vbCrLf + Constants.vbCrLf + "Viewing all visits in the holding area can cause performance issues. " + Constants.vbCrLf + "Please only view all if you need to do so." + Constants.vbCrLf + "Thanks", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
            }

            dtUnscheduledWork = App.DB.Scheduler.GetUnscheduledVisits(viewAll);
            dtUnscheduledWork.TableName = "UnscheduledWork";
            return dtUnscheduledWork;
        }

        public void loadUnsheduledWorkEnd(IAsyncResult ar)
        {
            loadUnsheduledWorkDelegate o_MyDelegate = (loadUnsheduledWorkDelegate)((AsyncResult)ar).AsyncDelegate;
            try
            {
                if (!_mdiParent.IsDisposed)
                {
                    _mdiParent.Invoke(new setUnsheduledCallsDelegate(SetUnsheduledCalls), o_MyDelegate.EndInvoke(ar));
                }
            }
            catch
            {
            }
        }

        private delegate void setUnsheduledCallsDelegate(DataTable dtunscheduledCalls);

        private void SetUnsheduledCalls(DataTable dtunscheduledCalls)
        {
            _unscheduledCalls.unscheduledCalls = dtunscheduledCalls;
            _unscheduledCalls.ApplyFilters();
        }

        public DataTable loadDay(string EngineerID, DateTime date)
        {
            var dtDay = new DataTable();
            dtDay = App.DB.Scheduler.Get_ScheduledJobsDay(date, EngineerID);
            dtDay.TableName = Strings.Format(date, "dd/MM/yyyy").ToString();
            return dtDay;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private const int radius = 3;
        private Point clickedPoint;
        private bool cellDown = false;
        private Point mousePos;

        public class WorkTransport
        {
            public DataRowView sourceDatarowView;
            public DataGrid sourceDataGrid;
            public bool CanCopy;

            public WorkTransport(DataRowView clickedRowView, DataGrid ClickedDatagrid, bool copy)
            {
                sourceDatarowView = clickedRowView;
                sourceDataGrid = ClickedDatagrid;
                CanCopy = copy;
            }
        }

        public void gridMouseDown(object sender, MouseEventArgs e)
        {
            if (sender is object && e is object)
            {
                try
                {
                    DataGrid currentDataGrid = (DataGrid)sender;
                    var hitTestInfo = currentDataGrid.HitTest(e.X, e.Y);
                    if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
                    {
                        cellDown = true;
                        clickedPoint = new Point(e.X, e.Y);
                    }
                    else
                    {
                        cellDown = false;
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    if (ex.InnerException is object)
                    {
                        msg += Constants.vbCrLf + "Inner Exception:" + Constants.vbCrLf + ex.InnerException.Message;
                    }

                    App.LogError(ex.GetType().Name, msg, ex.StackTrace);
                }
            }
        }

        private void gridMouseMove(object sender, MouseEventArgs e)
        {
            if (sender is object && e is object)
            {
                try
                {
                    Application.DoEvents();
                    DataGrid currentDataGrid = (DataGrid)sender;
                    var hitTestInfo = currentDataGrid.HitTest(e.X, e.Y);
                    var heartIs = default(bool);
                    if (cellDown)
                    {
                        if (Control.MouseButtons == MouseButtons.Left & compareCoordinates(e.X, e.Y) & hitTestInfo.Type == DataGrid.HitTestType.Cell)
                        {
                            // Initalise Drag drop
                            if (clickedPoint != default)
                            {
                                var clickHitTest = currentDataGrid.HitTest(clickedPoint.X, clickedPoint.Y);
                                if (e.Button == MouseButtons.Left && clickHitTest is object)
                                {
                                    setScheduleDropIcons(((DataView)currentDataGrid.DataSource)[hitTestInfo.Row].Row);
                                    frmEngineerSchedule engineerSFrom;
                                    if (currentDataGrid.Parent.GetType() == typeof(frmEngineerSchedule))
                                    {
                                        engineerSFrom = (frmEngineerSchedule)currentDataGrid.Parent;
                                    }
                                    else
                                    {
                                        heartIs = false;
                                    }

                                    DataView dvDataGrid = (DataView)currentDataGrid.DataSource;
                                    int clickedRow = clickHitTest.Row;
                                    if (clickedRow > dvDataGrid.Count - 1)
                                    {
                                        clickedRow = dvDataGrid.Count - 1;
                                    }

                                    var argscheduleRow = dvDataGrid[clickedRow];
                                    if (Control.ModifierKeys == Keys.Control)
                                    {
                                        currentDataGrid.DoDragDrop(new WorkTransport(dvDataGrid[clickedRow], currentDataGrid, true), DragDropEffects.Copy);
                                    }
                                    else if (currentDataGrid.VisibleRowCount > 0 && canMoveRow(ref argscheduleRow, ref heartIs)) // Index 0 is either negative or above rows count.
                                    {
                                        currentDataGrid.DoDragDrop(new WorkTransport(dvDataGrid[clickedRow], currentDataGrid, false), DragDropEffects.Move);
                                    }
                                    else
                                    {
                                        currentDataGrid.DoDragDrop(new object(), DragDropEffects.None);
                                    }

                                    Application.DoEvents();
                                }
                            }
                        }
                    }

                    mousePos = new Point(e.X, e.Y);
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    if (ex.InnerException is object)
                    {
                        msg += Constants.vbCrLf + "Inner Exception:" + Constants.vbCrLf + ex.InnerException.Message;
                    }

                    App.LogError(ex.GetType().Name, msg, ex.StackTrace);
                }
            }
        }

        private void gridDragOver(object sender, DragEventArgs e)
        {
            if (sender is object && e is object)
            {
                try
                {
                    if (e.Data.GetDataPresent(typeof(WorkTransport)) == true)
                    {
                        DataGrid dgTo = (DataGrid)sender;
                        var dgFrom = ((WorkTransport)e.Data.GetData(typeof(WorkTransport))).sourceDataGrid;

                        // Dragged Over Engineer schedule summary
                        if (dgTo.Parent.GetType() == typeof(frmEngineerSchedule))
                        {
                            frmEngineerSchedule engineerSchedule = (frmEngineerSchedule)dgTo.Parent;
                            var ptc = engineerSchedule.dgDaySummary.PointToClient(new Point(e.X, e.Y));
                            var hitTestInfo = engineerSchedule.dgDaySummary.HitTest(ptc.X, ptc.Y);
                            if (((WorkTransport)e.Data.GetData(typeof(WorkTransport))).CanCopy == false)
                            {
                                e.Effect = DragDropEffects.Move;
                            }
                            else
                            {
                                e.Effect = DragDropEffects.Copy;
                            }
                        }
                        else if (((WorkTransport)e.Data.GetData(typeof(WorkTransport))).CanCopy == false)
                        {
                            e.Effect = DragDropEffects.Move;
                        }
                        else
                        {
                            e.Effect = DragDropEffects.None;
                        }
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    if (ex.InnerException is object)
                    {
                        msg += Constants.vbCrLf + "Inner Exception:" + Constants.vbCrLf + ex.InnerException.Message;
                    }

                    App.LogError(ex.GetType().Name, msg, ex.StackTrace);
                }
            }
        }

        public string CanMoveDownloadedVisit(frmEngineerSchedule engineerScheduleFrom, int EngineerVisitID, int TabletActionID)
        {
            if (!App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.MoveDownloadedVisit))
            {
                string msg = "You do not have the necessary security permissions." + Constants.vbCrLf + Constants.vbCrLf + "Contact your administrator if you think this is wrong or you need the permissions changing.";
                return msg;
            }

            int lastVisitID = 0;
            DataView lastTimesheet = null;
            var lastTimesheetCheck = DateTime.MinValue;
            // , ByVal startdatetime As DateTime)  /TODO

            if (TabletActionID == 1)  // already marked to be removed
            {
                return "The Downloaded visit has already been marked to be removed from another engineers tablet, you will need to wait for this to complete";
            }

            if (engineerScheduleFrom.HeartLastCheck > DateAndTime.Now.AddMinutes(-5)) // lets reduce the DB calls.
            {
            }
            // skip
            else
            {
                var Heart = App.DB.Scheduler.GetLatestHeartBeat(Conversions.ToInteger(engineerScheduleFrom.EngineerID));
                engineerScheduleFrom.HeartLastCheck = Heart.LastCheck;
                engineerScheduleFrom.LastHeartBeat = Heart.LastHeartBeat;
                engineerScheduleFrom.LockedVisitId = Heart.LockedVisitID;
            }

            if (engineerScheduleFrom.LastHeartBeat <= DateTime.MinValue)
            {
                return "The Downloaded visit has already been marked to be removed from another engineers tablet, you will need to wait for this to complete";
            }

            if (engineerScheduleFrom.LastHeartBeat.AddMinutes(5) > DateTime.Now) // we are good to go '''  engineerScheduleFrom._lastHeartBeat <= DateTime.MinValue OrElse
            {
                if (engineerScheduleFrom.LockedVisitId == EngineerVisitID)
                {
                    return "The downloaded visit cannot be moved as the engineer currently has this visit open on his device";
                }

                if ((lastTimesheet is object && lastVisitID == EngineerVisitID) & lastTimesheetCheck > DateAndTime.Now.AddMinutes(-1)) // and reduce the number of timesheet calls
                {
                }
                // skip
                else
                {
                    lastTimesheet = App.DB.EngineerVisitsTimeSheet.EngineerVisitTimeSheet_Get_For_EngineerVisitID(EngineerVisitID);
                    lastTimesheetCheck = DateAndTime.Now;
                }

                int mins = 0;
                foreach (DataRowView row in lastTimesheet)
                {
                    DateTime start = Conversions.ToDate(row["StartDateTime"]);
                    DateTime enddate;
                    if (Information.IsDBNull(row["EndDateTime"]))
                    {
                        enddate = DateTime.Now;
                    }
                    else
                    {
                        enddate = Conversions.ToDate(row["EndDateTime"]);
                    }

                    mins = Conversions.ToInteger(DateAndTime.DateDiff(DateInterval.Minute, start, enddate));
                }

                if (mins < 2) // Only can be true if we have had signal from the tablet in the last 2 mins'
                {
                    return string.Empty;
                }
                else
                {
                    return "The downloaded visit cannot be moved as the engineer has began traveling or working on this visit";
                }
            }
            else
            {
                return "The downloaded visit cannot be moved as the device has not checked in recently";
            }
        }

        private void gridDragDrop(object sender, DragEventArgs e)
        {
            if (sender is object && e is object)
            {
                try
                {
                    if (e.Data.GetDataPresent(typeof(WorkTransport)) == true)
                    {
                        DataGrid dgTo = (DataGrid)sender;
                        WorkTransport workTransport = (WorkTransport)e.Data.GetData(typeof(WorkTransport));
                        if (workTransport is null)
                            return;
                        var dgFrom = workTransport.sourceDataGrid;
                        DataRowView dropOverRow = null;
                        var JobLock = App.DB.JobLock.Check(Conversions.ToInteger(workTransport.sourceDatarowView["JobID"]));
                        int TabletActionID = App.DB.EngineerVisits.EngineerVisit_GetActionID(Conversions.ToInteger(workTransport.sourceDatarowView["EngineerVisitID"]));
                        if (JobLock is object)
                        {
                            string message = "This job cannot be scheduled because is it currently locked:" + Constants.vbCrLf;
                            message += string.Format("Locked by: {0}", JobLock.NameOfUserWhoLocked) + Constants.vbCrLf;
                            message += string.Format("Date Locked: {0}", JobLock.DateLock) + Constants.vbCrLf;
                            MessageBox.Show(message, "Job Lock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (!(dgTo == dgFrom))
                        {
                            // Physically Move Datarowview to Target datagrid
                            DataView dvTo = null;
                            frmEngineerSchedule engineerScheduleTo = null;
                            frmEngineerSchedule engineerScheduleFrom = null;
                            if (dgFrom.Parent.GetType() == typeof(frmEngineerSchedule))
                            {
                                engineerScheduleFrom = (frmEngineerSchedule)dgFrom.Parent;
                            }

                            // Dragged Over Engineer schedule summary
                            if (dgTo.Parent.GetType() == typeof(frmEngineerSchedule))
                            {
                                engineerScheduleTo = (frmEngineerSchedule)dgTo.Parent;
                                engineerScheduleTo.CurrentDate = default;
                                var ptc = engineerScheduleTo.dgDaySummary.PointToClient(new Point(e.X, e.Y));
                                var hitTestInfo = engineerScheduleTo.dgDaySummary.HitTest(ptc.X, ptc.Y);
                                if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
                                {
                                    dropOverRow = ((DataView)engineerScheduleTo.dgDaySummary.DataSource)[hitTestInfo.Row];
                                    if (dropOverRow is object)
                                    {
                                        engineerScheduleTo.CurrentDate = Conversions.ToDate(dropOverRow["dayDate"]);
                                        dvTo = new DataView(engineerScheduleTo.GetDay(Conversions.ToString(dropOverRow["dayDate"])));
                                        for (int rowindex = 0, loopTo = ((DataView)engineerScheduleTo.dgDaySummary.DataSource).Table.Rows.Count - 1; rowindex <= loopTo; rowindex++)
                                            engineerScheduleTo.dgDaySummary.UnSelect(rowindex);
                                    }

                                    engineerScheduleTo.dgDaySummary.Select(hitTestInfo.Row);
                                    engineerScheduleTo.RefreshSummary(Conversions.ToString(FromDate), Conversions.ToString(ToDate));
                                }
                            }
                            else
                            {
                                dvTo = (DataView)dgTo.DataSource;
                            }

                            if (dvTo is null)
                                return;
                            var newVisitRowView = dvTo.AddNew();
                            foreach (DataColumn column in workTransport.sourceDatarowView.Row.Table.Columns)
                            {
                                try
                                {
                                    if (newVisitRowView.Row.Table.Columns[column.ColumnName] is object)
                                    {
                                        if (newVisitRowView.Row.Table.Columns[column.ColumnName].DataType == workTransport.sourceDatarowView.Row.Table.Columns[column.ColumnName].DataType)
                                        {
                                            newVisitRowView[column.ColumnName] = workTransport.sourceDatarowView[column.ColumnName];
                                        }
                                    }
                                }
                                catch
                                {
                                }
                            }

                            bool @continue = true;
                            var newVisitForCheck = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(newVisitRowView.Row["EngineerVisitID"]));
                            int jobOfWorkStatusID = App.DB.JobOfWorks.JobOfWork_Get(newVisitForCheck.JobOfWorkID).Status;
                            string errorMsg = string.Empty;
                            if (dgFrom.Parent.GetType() == typeof(frmEngineerSchedule) & newVisitForCheck.StatusEnumID == Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Downloaded) & !workTransport.CanCopy)
                            {
                                errorMsg = CanMoveDownloadedVisit(engineerScheduleFrom, Conversions.ToInteger(newVisitRowView.Row["EngineerVisitID"]), TabletActionID);
                                @continue = string.IsNullOrEmpty(errorMsg);
                                if (!@continue)
                                    App.ShowMessage(errorMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            if (@continue)
                            {
                                if (engineerScheduleTo is object)
                                {
                                    if (DateAndTime.Now.Subtract(newVisitForCheck.Downloading) < TwoMins & workTransport.CanCopy == false)
                                    {
                                        App.ShowMessage("This visit has already been recently downloaded to an Engineer's PDA and cannot be rescheduled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        @continue = false;
                                    }
                                    else if (jobOfWorkStatusID == (int)Entity.Sys.Enums.JobOfWorkStatus.Complete & workTransport.CanCopy == true)
                                    {
                                        App.ShowMessage("This visit's job of work has been completed so the visit cannot be copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        @continue = false;
                                        jobOfWorkStatusID = 0;
                                    }
                                    else if (jobOfWorkStatusID == (int)Entity.Sys.Enums.JobOfWorkStatus.Closed & workTransport.CanCopy == true)
                                    {
                                        App.ShowMessage("This visit's job of work has been closed so the visit cannot be copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        @continue = false;
                                        jobOfWorkStatusID = 0;
                                    }
                                    else if (engineerScheduleTo.TestAcceptance(newVisitRowView.Row) == false)
                                    {
                                        @continue = engineerScheduleTo.GetAcceptance(newVisitRowView.Row, workTransport.CanCopy);
                                    }
                                    else
                                    {
                                        @continue = true;
                                    }
                                }
                                else if (DateAndTime.Now.Subtract(newVisitForCheck.Downloading) < TwoMins & workTransport.CanCopy == false)
                                {
                                    App.ShowMessage("This visit has already been recently downloaded to an Engineer's PDA and cannot be rescheduled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    @continue = false;
                                }
                                else if (jobOfWorkStatusID == (int)Entity.Sys.Enums.JobOfWorkStatus.Complete & workTransport.CanCopy == true)
                                {
                                    App.ShowMessage("This visit's job of work has been completed so the visit cannot be copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    @continue = false;
                                    jobOfWorkStatusID = 0;
                                }
                                else if (jobOfWorkStatusID == (int)Entity.Sys.Enums.JobOfWorkStatus.Closed & workTransport.CanCopy == true)
                                {
                                    App.ShowMessage("This visit's job of work has been closed so the visit cannot be copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    @continue = false;
                                    jobOfWorkStatusID = 0;
                                }
                            }

                            // 'Check for where the part is

                            if (@continue == true & engineerScheduleTo is object && !(Conversions.ToDouble(engineerScheduleTo.EngineerID) == 221) && !(Conversions.ToDouble(engineerScheduleTo.EngineerID) == 320) && !(Conversions.ToDouble(engineerScheduleTo.EngineerID) == 314) && !(Conversions.ToDouble(engineerScheduleTo.EngineerID) == 215) && !(Conversions.ToDouble(engineerScheduleTo.EngineerID) == 378) && !(Conversions.ToDouble(engineerScheduleTo.EngineerID) == 386))
                            {
                                var Lastengineer = App.DB.ExecuteWithReturn("select ISNULL(op.ReceivedEngineerID,0) as ReceivedEngineerID,op.OrderID,pa.Quantity, pa.OrderPartID ,e.name as eng, P.Name, p.Number from tblOrderPart op inner join tblEngineerVisitPartAllocated pa ON pa.OrderPartID = op.OrderPartID INNER JOIN tblPart P ON p.PartID = pa.PArtID INNER JOIN tblengineer E ON e.EngineerID = op.ReceivedEngineerID where engineervisitid = " + newVisitForCheck.EngineerVisitID);
                                if (Lastengineer is null || Lastengineer.Rows.Count == 0 || Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(Lastengineer.Rows[0]["ReceivedEngineerID"], engineerScheduleTo.EngineerID, false)) || _OldEngineerVisitID > 0)
                                {
                                }

                                // do nothing
                                else
                                {
                                    App.ShowMessage("This Visit has parts attached which have already been picked up by different engineer, only coordinators and above can action this", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Coordinator))
                                    {
                                        foreach (DataRow d in Lastengineer.Rows)
                                            App.DB.ExecuteScalar(Conversions.ToString("DELETE FROM tblAltReturn WHERE OrderPartID = " + d["OrderPartID"]));
                                        var drs = Lastengineer.Select("ReceivedEngineerID <> 0 AND ReceivedEngineerID <> " + engineerScheduleTo.EngineerID);
                                        if (drs.Length == 0)
                                        {
                                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(Lastengineer.Rows[0]["ReceivedEngineerID"], engineerScheduleTo.EngineerID, false)))
                                            {
                                                bool issue = false;
                                                foreach (DataRow d in Lastengineer.Rows)
                                                {
                                                    int count = Conversions.ToInteger(App.DB.ExecuteScalar(Conversions.ToString("Select COUNT(*) from tblpartcreditparts cp INNER JOIN tblPartsToBeCredited tbc ON tbc.PartsToBeCreditedID = cp.PartsToBeCreditedID WHERE tbc.OrderPArtID = " + d["OrderPartID"])));
                                                    if (count > 0)
                                                    {
                                                        // Credits have been recieved
                                                        issue = true;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                    }
                                                }

                                                if (issue == false)
                                                {
                                                    foreach (DataRow d in Lastengineer.Rows)
                                                    {
                                                        App.DB.ExecuteScalar(Conversions.ToString("Delete From tblPartstobeCredited where OrderPartID = " + d["OrderPartID"]));
                                                        App.DB.ExecuteScalar(Conversions.ToString("UPDATE tblEngineerVisitPartAllocated SET CreditRequested = 0,CreditQty = 0 WHERE ORDERPARTID = " + d["OrderPartID"]));
                                                    }
                                                }
                                            }
                                        }

                                        // do nothing
                                        else
                                        {
                                            // Start the choice pick up from Location/ return to supplier and start new pickup *owch* /

                                            string s = "";
                                            foreach (DataRow d in drs)
                                                s += Conversions.ToString(d["Name"] + "(") + d["Number"] + "), ";
                                            var f = new FRMItemReturn();
                                            f.TextBox1.Text = Conversions.ToString("This visit contains the parts " + s + " - which have been picked up by " + drs[0]["eng"] + ". Please select what action to take.");
                                            f.ShowDialog();
                                            int @out = Conversions.ToInteger(Combo.get_GetSelectedItemValue(f.cboJobType));
                                            string location = f.TextBox2.Text;
                                            switch (@out)
                                            {
                                                case 0:
                                                    {
                                                        @continue = false;
                                                        break;
                                                    }

                                                case 1:
                                                    {
                                                        if (App.ShowMessage("Beware! actioning this return is not reversable, the parts will be marked to be returned to supplier , do you wish to proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                                        {
                                                            foreach (DataRow d in drs)
                                                            {
                                                                int counts = Conversions.ToInteger(App.DB.ExecuteScalar(Conversions.ToString("SELECT COUNT(*) From tblPartsToBeCredited where OrderPArtID = " + d["OrderPartID"])));
                                                                if (counts == 0)
                                                                {
                                                                    int PartsToBeCreditedID = 0;
                                                                    var orderdt = App.DB.ExecuteWithReturn(Conversions.ToString("SELECT tblPartSupplier.PartID, tblOrder.OrderReference, " + "CASE WHEN COALESCE (tblOrderPart.ChildSupplierID, 0) = 0 THEN tblSupplier.SupplierID ELSE tblOrderPart.ChildSupplierID END AS SupplierID," + "CASE WHEN COALESCE (tblOrderPart.ChildSupplierID, 0) = 0 THEN tblSupplier.Name ELSE (SELECT Name FROM tblsupplier AS a WHERE supplierID = tblOrderPart.ChildSupplierID) END AS SupplierName " + "FROM tblOrderPart LEFT OUTER JOIN tblPartSupplier ON tblOrderPart.PartSupplierID = tblPartSupplier.PartSupplierID " + "LEFT OUTER JOIN tblSupplier ON tblSupplier.SupplierID = tblPartSupplier.SupplierID " + "INNER JOIN tblOrder ON tblOrderPart.OrderID = tblOrder.OrderID WHERE (tblOrderPart.OrderPartID = " + d["OrderPartID"] + ")"));
                                                                    PartsToBeCreditedID = App.DB.PartsToBeCredited.PartsToBeCredited_Insert(Conversions.ToInteger(orderdt.Rows[0]["SupplierID"]), Conversions.ToInteger(d["OrderID"]), Conversions.ToInteger(orderdt.Rows[0]["PartID"]), Conversions.ToInteger(d["Quantity"]), Conversions.ToString(orderdt.Rows[0]["OrderReference"]), Conversions.ToInteger(d["ReceivedEngineerID"]), Conversions.ToInteger(d["OrderPartID"]));
                                                                    App.DB.ExecuteScalar(Conversions.ToString("UPDATE tblEngineerVisitPartAllocated SET CreditRequested = 1, CreditQty = " + Conversions.ToInteger(d["Quantity"]) + " WHERE ORDERPARTID = " + d["OrderPartID"]));
                                                                }
                                                                else
                                                                {
                                                                }
                                                            }
                                                        }

                                                        break;
                                                    }

                                                case 2:
                                                    {
                                                        foreach (DataRow d in drs)
                                                        {
                                                            int count = Conversions.ToInteger(App.DB.ExecuteScalar(Conversions.ToString("Select COUNT(*) from tblpartcreditparts cp INNER JOIN tblPartsToBeCredited tbc ON tbc.PartsToBeCreditedID = cp.PartsToBeCreditedID WHERE tbc.OrderPArtID = " + d["OrderPartID"])));
                                                            if (count > 0)
                                                            {
                                                                App.ShowMessage("One or more of the parts have been returned to the supplier already, you can not have these picked up form a location", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                @continue = false;
                                                                break;
                                                            }
                                                            else
                                                            {
                                                            }
                                                        }

                                                        if (@continue == true)
                                                        {
                                                            foreach (DataRow d in drs)
                                                            {
                                                                App.DB.ExecuteScalar(Conversions.ToString("Delete From tblPartstobeCredited where OrderPartID = " + d["OrderPartID"]));
                                                                App.DB.ExecuteScalar(Conversions.ToString("UPDATE tblEngineerVisitPartAllocated SET CreditRequested = 0 ,CreditQty = 0 WHERE ORDERPARTID = " + d["OrderPartID"]));
                                                                App.DB.ExecuteScalar(Conversions.ToString(Conversions.ToString("Insert INTO tblAltReturn (OrderPartID,Location,ReturningEng,CollectingEng) VALUES(" + d["OrderPartID"] + ",'" + location + "',") + d["ReceivedEngineerID"] + "," + engineerScheduleTo.EngineerID + ")"));
                                                            }
                                                        }

                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                    else // override password fail
                                    {
                                        @continue = false;
                                    }
                                }
                            }

                            int appointment = 0;
                            if (@continue)
                            {
                                if (engineerScheduleTo is object)
                                {
                                    @continue = scheduleRowManipulation(ref newVisitRowView, Conversions.ToInteger(engineerScheduleTo.EngineerID), Conversions.ToDate(dropOverRow["dayDate"]), workTransport.CanCopy, ref appointment);
                                }
                                else
                                {
                                    @continue = scheduleRowManipulation(ref newVisitRowView, 0, DateTime.MinValue, workTransport.CanCopy, ref appointment);
                                }
                            }

                            if (@continue)
                            {
                                newVisitForCheck = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(newVisitRowView.Row["EngineerVisitID"]));
                                if ((dgFrom.Parent.GetType() == typeof(frmEngineerSchedule) & newVisitForCheck?.StatusEnumID == Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Downloaded) & !workTransport.CanCopy) == true)
                                {
                                    errorMsg = CanMoveDownloadedVisit(engineerScheduleFrom, Conversions.ToInteger(newVisitRowView.Row["EngineerVisitID"]), TabletActionID);
                                    @continue = string.IsNullOrEmpty(errorMsg);
                                    if (!@continue)
                                        App.ShowMessage(errorMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            if (newVisitForCheck is object & @continue)
                            {
                                if (DateAndTime.Now.Subtract(newVisitForCheck.Downloading) < TwoMins & workTransport.CanCopy == false)
                                {
                                    App.ShowMessage("This visit has already been recently downloaded to an Engineer's PDA and cannot be rescheduled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    @continue = false;
                                }
                                else if (jobOfWorkStatusID == (int)Entity.Sys.Enums.JobOfWorkStatus.Complete & workTransport.CanCopy == true)
                                {
                                    App.ShowMessage("This visit's job of work has been completed so the visit cannot be copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    @continue = false;
                                    jobOfWorkStatusID = 0;
                                }
                                else if (jobOfWorkStatusID == (int)Entity.Sys.Enums.JobOfWorkStatus.Closed & workTransport.CanCopy == true)
                                {
                                    App.ShowMessage("This visit's job of work has been closed so the visit cannot be copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    @continue = false;
                                    jobOfWorkStatusID = 0;
                                }
                            }

                            if (@continue == true)
                            {
                                if (workTransport.CanCopy == false)
                                {
                                    e.Effect = DragDropEffects.Move;
                                    workTransport.sourceDatarowView.Delete();
                                }
                                else if (engineerScheduleTo is object)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                }

                                if (engineerScheduleTo is object)
                                {
                                    var argVisitRow = newVisitRowView.Row;
                                    App.DB.Scheduler.ScheduleVisit(ref argVisitRow, _OldEngineerVisitID, appointment);
                                    _OldEngineerVisitID = 0;
                                }
                                else
                                {
                                    App.DB.Scheduler.unscheduleVisit(newVisitRowView.Row);
                                }

                                Application.DoEvents();
                                if (engineerScheduleTo is object)
                                {
                                    engineerScheduleTo.RefreshSummary(Conversions.ToString(FromDate), Conversions.ToString(ToDate));
                                    dvTo.Table.AcceptChanges();
                                }
                                else if (dvTo.Table.Select("JobOfWorkID=" + Conversions.ToString(newVisitRowView["JobOfWorkID"])).Length <= 1)
                                {
                                    dvTo.Table.AcceptChanges();
                                }
                                else
                                {
                                    dvTo.Table.RejectChanges();
                                }

                                if (engineerScheduleFrom is object)
                                {
                                    engineerScheduleFrom.RefreshSummary(Conversions.ToString(FromDate), Conversions.ToString(ToDate));
                                }
                                else
                                {
                                    _unscheduledCalls.setOverdueLabel();
                                }
                            }
                            else
                            {
                                dvTo.Table.RejectChanges();
                                e.Effect = DragDropEffects.None;
                            }
                        }
                        else
                        {
                            setScheduleDropIcons(null);
                        } ((DataView)dgFrom.DataSource).Table.AcceptChanges();
                        ((DataView)dgTo.DataSource).Table.AcceptChanges();
                    }

                    resetHeaders();
                    clearSelections();
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    if (ex.InnerException is object)
                    {
                        msg += Constants.vbCrLf + "Inner Exception:" + Constants.vbCrLf + ex.InnerException.Message;
                    }

                    App.LogError(ex.GetType().Name, msg, ex.StackTrace);
                }
            }
        }

        private void gridMouseUp(object sender, MouseEventArgs e)
        {
            if (sender is object && e is object)
            {
                try
                {
                    DataGrid dgGrid = (DataGrid)sender;
                    var hitTest = dgGrid.HitTest(e.X, e.Y);
                    if (hitTest.Type == DataGrid.HitTestType.Cell && hitTest.Row > -1)
                    {
                        clearSelections();
                        setScheduleDropIcons(((DataView)dgGrid.DataSource)[hitTest.Row].Row);
                        dgGrid.CurrentRowIndex = hitTest.Row;
                        dgGrid.Select(hitTest.Row);
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    if (ex.InnerException is object)
                    {
                        msg += Constants.vbCrLf + "Inner Exception:" + Constants.vbCrLf + ex.InnerException.Message;
                    }

                    App.LogError(ex.GetType().Name, msg, ex.StackTrace);
                }
            }
        }

        // Return true if the co-ords are greater than 10 from the first co-ords
        private bool compareCoordinates(int x2, int y2)
        {
            if (Math.Abs(x2 - clickedPoint.X) > radius || Math.Abs(y2 - clickedPoint.Y) > radius)
            {
                return true;
            }

            return false;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void resetHeaders()
        {
            foreach (frmEngineerSchedule engineerSchedule in _engineerSchedules.ToArray(typeof(frmEngineerSchedule)))
                engineerSchedule.ResetHeader();
        }

        private delegate void setScheduleDropIconsDelegate(DataRow draggedRow);

        public Scheduler()
        {
            scheduleDropIcons = new setScheduleDropIconsDelegate(SetScheduleDropIconsBegin);
        }

        private setScheduleDropIconsDelegate scheduleDropIcons;
        private IAsyncResult ScheduleDropIconsAsyncResult;
        private bool endDropIconsRefresh;

        private void setScheduleDropIcons(DataRow draggedRow)
        {
            var scheduleDropIcons = new setScheduleDropIconsDelegate(SetScheduleDropIconsBegin);
            var scheduleDropIconsComplete = new AsyncCallback(SetScheduleDropIconsComplete);
            if (ScheduleDropIconsAsyncResult is object)
            {
                endDropIconsRefresh = true;
                while (ScheduleDropIconsAsyncResult is object && ScheduleDropIconsAsyncResult.IsCompleted == false)
                {
                    Application.DoEvents();
                    if (!App.loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) == true)
                        System.Threading.Thread.Sleep(20);
                }

                endDropIconsRefresh = false;
            }

            ScheduleDropIconsAsyncResult = scheduleDropIcons.BeginInvoke(draggedRow, scheduleDropIconsComplete, null);
        }

        private void SetScheduleDropIconsBegin(DataRow draggedRow)
        {
            var refreshed = new ArrayList();
            while (refreshed.Count != _engineerSchedules.Count & endDropIconsRefresh == false)
            {
                foreach (frmEngineerSchedule engineerSchedule in _engineerSchedules.ToArray(typeof(frmEngineerSchedule)))
                {
                    var refreshArea = new Rectangle(0, 0, _mdiClient.Width, _mdiClient.Height);
                    if (!refreshed.Contains(engineerSchedule.EngineerID) && refreshArea.IntersectsWith(engineerSchedule.Bounds))
                    {
                        engineerSchedule.CurrentDate = default;
                        engineerSchedule.RefreshAcceptance(draggedRow);
                        refreshed.Add(engineerSchedule.EngineerID);
                    }
                }

                Application.DoEvents();
                if (refreshed.Count != _engineerSchedules.Count & endDropIconsRefresh == false)
                {
                    if (!App.loggedInUser?.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures) == true)
                        System.Threading.Thread.Sleep(50);
                }
            }
        }

        private void SetScheduleDropIconsComplete(IAsyncResult ar)
        {
            setScheduleDropIconsDelegate o_MyDelegate = (setScheduleDropIconsDelegate)((AsyncResult)ar).AsyncDelegate;
            endDropIconsRefresh = false;
            o_MyDelegate.EndInvoke(ar);
        }

        private void clearSelections()
        {
            _unscheduledCalls.clearSelections();
            foreach (frmEngineerSchedule engineerSchedule in _engineerSchedules.ToArray(typeof(frmEngineerSchedule)))
                engineerSchedule.ClearSelections();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void ControlResize(object sender, EventArgs e)
        {
            orderScheduleWindows();
        }

        private void orderScheduleWindows()
        {
            _mdiClient.Resize -= ControlResize;
            _unscheduledCalls.Resize -= ControlResize;
            double engineerScheduleWidth;
            engineerScheduleWidth = Conversions.ToDouble((double)_mdiClient.ClientSize.Width / _engineerScheduleColumnCount);
            for (int index = 1, loopTo = _engineerSchedules.Count; index <= loopTo; index++)
            {
                double newWidth = Conversions.ToDouble((double)_mdiClient.ClientSize.Width / _engineerScheduleColumnCount);
                if (newWidth != engineerScheduleWidth)
                {
                    engineerScheduleWidth = Conversions.ToDouble((double)_mdiClient.ClientSize.Width / _engineerScheduleColumnCount);
                    foreach (frmEngineerSchedule schedule in _engineerSchedules)
                        schedule.Width = Conversions.ToInteger(engineerScheduleWidth);
                }

                int row = Conversions.ToInteger(Math.Ceiling(index / _engineerScheduleColumnCount));
                int col = Conversions.ToInteger(Math.Floor(index / (double)row));
                frmEngineerSchedule peopleSchedule = (frmEngineerSchedule)_engineerSchedules[index - 1];
                peopleSchedule.Left = Conversions.ToInteger(engineerScheduleWidth * (col - 1));
                peopleSchedule.Width = Conversions.ToInteger(engineerScheduleWidth);
                peopleSchedule.Top = Conversions.ToInteger((int)_engineerScheduleHeight * (row - 1));
                peopleSchedule.Height = Conversions.ToInteger(_engineerScheduleHeight);
            }

            _mdiClient.Resize += ControlResize;
            _unscheduledCalls.Resize += ControlResize;
            Application.DoEvents();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}