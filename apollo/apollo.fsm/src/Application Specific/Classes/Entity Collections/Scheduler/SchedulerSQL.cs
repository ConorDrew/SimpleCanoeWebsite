using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using FSM.Entity.EngineerVisits;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity.Scheduler
{
    public class SchedulerSQL
    {
        private Database _database;

        public SchedulerSQL(Database database)
        {
            _database = database;
        }

        public DataTable getSummaryNEW(string EngineerID, DateTime Start, DateTime Endin)
        {
            // Dim pDays As New SqlClient.SqlParameter("@DataRange", Days)
            // Dim pEngineerID As New SqlClient.SqlParameter("@EngineerID", EngineerID)

            var command = new SqlCommand("Scheduler_GetEngineerWorkLoadForDays_TEST", new SqlConnection(_database.ServerConnectionString));
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 100000;
            command.Parameters.AddWithValue("@Start", Strings.Format(Start, "yyyy/MM/dd"));
            command.Parameters.AddWithValue("@End", Strings.Format(Endin, "yyyy/MM/dd"));
            command.Parameters.AddWithValue("@EngineerID", EngineerID);
            return _database.ExecuteCommand_DataTable(command);
            // Return _database.ExecuteSP_DataTable("Scheduler_GetEngineerWorkLoadForDays", pDays, pEngineerID)
        }

        public bool AbsenceOverlap(string EngineerID, DateTime Day)
        {
            var dt = new DataTable();
            // Dim pEngineerID As New SqlClient.SqlParameter("@EngineerID", EngineerID)
            // Dim pDay As New SqlClient.SqlParameter("@Day", Day)

            var command = new SqlCommand("Scheduler_AbsenceOverlapCheck", new SqlConnection(_database.ServerConnectionString));
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EngineerID", EngineerID);
            command.Parameters.AddWithValue("@Day", Day);
            dt = _database.ExecuteCommand_DataTable(command);
            dt.TableName = "dtAbsenceOverlap";
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable GetUnscheduledVisits(bool viewAll)
        {
            var dt = new DataTable();
            var command = new SqlCommand("UnscheduledVisits_Get_Mk3", new SqlConnection(_database.ServerConnectionString));
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserID", App.loggedInUser.UserID);
            command.Parameters.AddWithValue("@ViewAll", viewAll);
            dt = _database.ExecuteCommand_DataTable(command);
            dt.TableName = "dtUnscheduledVisits";
            return dt;
        }

        public DataTable Scheduler_DayTimeSlots(DateTime day, string engineerid)
        {
            var pVisitDate = new SqlParameter("@VisitDate", Strings.Format(day, "yyyy/MMM/dd").ToString());
            var pEngineerID = new SqlParameter("@EngineerID", engineerid);
            DataTable dt;
            dt = _database.ExecuteSP_DataTable("Scheduler_DayTimeSlots_TEST", pVisitDate, pEngineerID);
            return dt;
        }

        public DataTable Scheduler_PlannerPopUp(DateTime day, string engineerid)
        {
            var pVisitDate = new SqlParameter("@VisitDate", Strings.Format(day, "yyyy/MMM/dd HH:mm:ss").ToString());
            var pEngineerID = new SqlParameter("@EngineerID", engineerid);
            DataTable dt;
            dt = _database.ExecuteSP_DataTable("Scheduler_PlannerPopUp", pVisitDate, pEngineerID);
            return dt;
        }

        public DataTable SORTime_GetForEngineerAndDay(int EngineerID, DateTime DateToCheck)
        {
            var pVisitDate = new SqlParameter("@dateToCheck", DateToCheck); // Format(DateToCheck, "yyyy/MMM/dd").ToString
            var pEngineerID = new SqlParameter("@EngineerID", EngineerID);
            DataTable dt;
            dt = _database.ExecuteSP_DataTable("SORTime_GetForEngineerAndDay", pVisitDate, pEngineerID);
            return dt;
        }

        public DataTable Get_ScheduledJobsDay(DateTime day, string engineerid)
        {
            var pVisitDate = new SqlParameter("@VisitDate", Strings.Format(day, "yyyy/MMM/dd").ToString());
            var pEngineerID = new SqlParameter("@EngineerID", engineerid);
            var pVisitStatusID = new SqlParameter("@VisitStatusID", Conversions.ToInteger(Enums.VisitStatus.Scheduled));
            var userID = new SqlParameter("@UserID", App.loggedInUser.UserID);
            DataTable dt;
            dt = _database.ExecuteSP_DataTable("ScheduledJobsDay_Get_Mk2", pVisitDate, pEngineerID, pVisitStatusID, userID);
            return dt;
        }

        public bool IsSiteOverdue(int siteId)
        {
            var paramSiteId = new SqlParameter("@SiteID", siteId);
            DataTable dt;
            dt = _database.ExecuteSP_DataTable("Scheduler_IsSiteOverdue", paramSiteId);
            bool _isSiteOverdue = false;
            if (Helper.MakeIntegerValid(dt?.Rows.Count) > 0)
            {
                _isSiteOverdue = Helper.MakeBooleanValid(dt.Rows[0]["IsSiteOverdue"]);
            }

            return _isSiteOverdue;
        }

        public bool IsVisitLate(int engineerVisitId)
        {
            var paramEngineerVisitId = new SqlParameter("@EngineerVisitId", engineerVisitId);
            DataTable dt;
            dt = _database.ExecuteSP_DataTable("Scheduler_IsVisitLate", paramEngineerVisitId);
            bool _isVisitLate = false;
            if (Helper.MakeIntegerValid(dt?.Rows.Count) > 0)
            {
                _isVisitLate = Helper.MakeBooleanValid(dt.Rows[0]["IsVisitLate"]);
            }

            return _isVisitLate;
        }

        public void ScheduleVisit(ref DataRow VisitRow, int OldVisitID = 0, int AppointmentID = 0)
        {
            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(VisitRow["EngineerVisitID"], 0, false)))
            {
                // GET OLD VISIT
                var originaldetail = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(VisitRow["EngineerVisitID"]));
                _database.ClearParameter();
                _database.AddParameter("@StartDateTime", Strings.Format(VisitRow["StartDateTime"], "dd-MMM-yyyy HH:mm:ss"), true);
                _database.AddParameter("@EndDateTime", Strings.Format(VisitRow["EndDateTime"], "dd-MMM-yyyy HH:mm:ss"), true);
                _database.AddParameter("@EngineerID", VisitRow["EngineerID"], true);
                _database.AddParameter("@VisitID", VisitRow["EngineerVisitID"], true);
                _database.AddParameter("@AppointmentID", AppointmentID, true);
                if (originaldetail.StatusEnumID == Conversions.ToInteger(Enums.VisitStatus.Downloaded))
                {
                    if (Conversions.ToInteger(VisitRow["EngineerID"]) == originaldetail.EngineerID)
                    {
                        if (Conversions.ToDate(VisitRow["StartDateTime"]) > DateTime.Now.AddHours(24))
                        {
                            _database.AddParameter("@VisitStatusID", Conversions.ToInteger(Enums.VisitStatus.Scheduled), true);
                            _database.AddParameter("@TabletActionID", 1, true); // move only
                            _database.AddParameter("@RemoveEngineerID", originaldetail.EngineerID, true); // who
                        }
                        else
                        {
                            _database.AddParameter("@VisitStatusID", Conversions.ToInteger(Enums.VisitStatus.Downloaded), true);
                            _database.AddParameter("@TabletActionID", 2, true);
                        } // move only
                    }
                    else
                    {
                        _database.AddParameter("@VisitStatusID", Conversions.ToInteger(Enums.VisitStatus.Scheduled), true);
                        _database.AddParameter("@TabletActionID", 1, true); // Remove from old engineer
                        _database.AddParameter("@RemoveEngineerID", originaldetail.EngineerID, true);
                    } // who
                }
                else
                {
                    _database.AddParameter("@TabletActionID", 2, true); // move only
                    _database.AddParameter("@VisitStatusID", Conversions.ToInteger(Enums.VisitStatus.Scheduled), true);
                }

                int jobId = 0;
                if (Helper.MakeBooleanValid(_database.ExecuteSP_OBJECT("scheduleVisit")) == true)
                {
                    // Status Changed enter Job Audit
                    var jA = new JobAudits.JobAudit();
                    jA.SetJobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(Conversions.ToInteger(VisitRow["EngineerVisitID"])).JobID;
                    jobId = jA.JobID;
                    jA.SetActionChange = "Visit Status changed to Scheduled, to Engineer: " + App.DB.Engineer.Engineer_Get(Conversions.ToInteger(VisitRow["EngineerID"])).Name + " For " + Strings.Format(VisitRow["StartDateTime"], "dd-MMM-yyyy HH:mm") + " (Unique Visit ID: " + VisitRow["EngineerVisitID"] + ")";
                    App.DB.JobAudit.Insert(jA);
                }
                else
                {
                    var jA = new JobAudits.JobAudit();
                    jA.SetJobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(Conversions.ToInteger(VisitRow["EngineerVisitID"])).JobID;
                    jobId = jA.JobID;
                    jA.SetActionChange = "Visit moved to Engineer: " + App.DB.Engineer.Engineer_Get(Conversions.ToInteger(VisitRow["EngineerID"])).Name + " For " + Strings.Format(VisitRow["StartDateTime"], "dd-MMM-yyyy HH:mm") + " (Unique Visit ID: " + VisitRow["EngineerVisitID"] + ")";
                    App.DB.JobAudit.Insert(jA);
                }

                // Check if job is an import job
                if (App.DB.JobImports.JobImport_Get_ByJobNumber(Conversions.ToString(VisitRow["JobNumber"])).Count > 0)
                {
                    JobImportUpdate(Conversions.ToString(VisitRow["JobNumber"]), Helper.MakeIntegerValid(VisitRow["EngineerVisitID"]));
                }
            }
            else
            {
                var engineerVisit = new EngineerVisit();
                engineerVisit.SetEngineerID = VisitRow["EngineerID"];
                engineerVisit.StartDateTime = Conversions.ToDate(Strings.Format(VisitRow["StartDateTime"], "dd-MMM-yyyy HH:mm:ss"));
                engineerVisit.EndDateTime = Conversions.ToDate(Strings.Format(VisitRow["EndDateTime"], "dd-MMM-yyyy HH:mm:ss"));
                engineerVisit.SetStatusEnumID = Conversions.ToInteger(Enums.VisitStatus.Scheduled);
                engineerVisit.SetJobOfWorkID = VisitRow["JobOfWorkID"];
                engineerVisit.SetNotesToEngineer = VisitRow["NotesToEngineer"];
                if (OldVisitID > 0)
                {
                    {
                        var withBlock = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(OldVisitID);
                        engineerVisit.SetVisitNumber = withBlock.VisitNumber;
                    }
                }

                engineerVisit = App.DB.EngineerVisits.Insert(engineerVisit, 0, AppointmentID, OldVisitID);
                if (OldVisitID > 0)
                {
                    var dtParts = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(OldVisitID).Table;
                    if (dtParts.Rows.Count > 0)
                    {
                        if (App.ShowMessage("This visit has parts and/or products allocated to it.  Would you like to move them to the new visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            var movedOrders = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAllocated_MoveVisit(OldVisitID, engineerVisit.EngineerVisitID);
                            engineerVisit.SetPartsToFit = true;
                            App.DB.EngineerVisits.Update(engineerVisit, 0, true);
                        }
                    }
                }

                VisitRow["EngineerVisitID"] = engineerVisit.EngineerVisitID;
            }
        }

        public void ScheduleVisit(EngineerVisit visit)
        {
            if (visit is null)
                return;
            var orginialVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(visit.EngineerVisitID);
            _database.ClearParameter();
            _database.AddParameter("@StartDateTime", visit.StartDateTime, true);
            _database.AddParameter("@EndDateTime", visit.EndDateTime, true);
            _database.AddParameter("@EngineerID", visit.EngineerID, true);
            _database.AddParameter("@VisitID", visit.EngineerVisitID, true);
            _database.AddParameter("@AppointmentID", visit.AppointmentID, true);
            if (orginialVisit.StatusEnumID == Conversions.ToInteger(Enums.VisitStatus.Downloaded))
            {
                if (visit.EngineerID == orginialVisit.EngineerID)
                {
                    if (visit.StartDateTime > DateTime.Now.AddHours(24))
                    {
                        _database.AddParameter("@VisitStatusID", Conversions.ToInteger(Enums.VisitStatus.Scheduled), true);
                        _database.AddParameter("@TabletActionID", Conversions.ToInteger(Enums.TabletAction.RemoveFromTablet), true); // move only
                        _database.AddParameter("@RemoveEngineerID", orginialVisit.EngineerID, true); // who
                    }
                    else
                    {
                        _database.AddParameter("@VisitStatusID", Conversions.ToInteger(Enums.VisitStatus.Downloaded), true);
                        _database.AddParameter("@TabletActionID", Conversions.ToInteger(Enums.TabletAction.UpdateTime), true);
                    } // move only
                }
                else
                {
                    _database.AddParameter("@VisitStatusID", Conversions.ToInteger(Enums.VisitStatus.Scheduled), true);
                    _database.AddParameter("@TabletActionID", Conversions.ToInteger(Enums.TabletAction.RemoveFromTablet), true); // Remove from old engineer
                    _database.AddParameter("@RemoveEngineerID", orginialVisit.EngineerID, true);
                } // who
            }
            else
            {
                _database.AddParameter("@TabletActionID", Conversions.ToInteger(Enums.TabletAction.UpdateTime), true); // move only
                _database.AddParameter("@VisitStatusID", Conversions.ToInteger(Enums.VisitStatus.Scheduled), true);
            }

            bool success = Helper.MakeBooleanValid(_database.ExecuteSP_OBJECT("scheduleVisit"));
            var job = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(visit.EngineerVisitID);
            if (success)
            {
                var jA = new JobAudits.JobAudit();
                jA.SetJobID = job?.JobID;
                jA.SetActionChange = "Visit Status changed to Scheduled, to Engineer: " + App.DB.Engineer.Engineer_Get(visit.EngineerID)?.Name + " For " + Strings.Format(visit.StartDateTime, "dd-MMM-yyyy HH:mm") + " (Unique Visit ID: " + visit.EngineerVisitID + ")";
                App.DB.JobAudit.Insert(jA);
            }
            else
            {
                var jA = new JobAudits.JobAudit();
                jA.SetJobID = job?.JobID;
                jA.SetActionChange = "Visit moved to Engineer: " + App.DB.Engineer.Engineer_Get(visit.EngineerID)?.Name + " For " + Strings.Format(visit.StartDateTime, "dd-MMM-yyyy HH:mm") + " (Unique Visit ID: " + visit.EngineerVisitID + ")";
                App.DB.JobAudit.Insert(jA);
            }

            if (App.DB.JobImports.JobImport_Get_ByJobNumber(job?.JobNumber).Count > 0)
            {
                JobImportUpdate(job?.JobNumber, visit.EngineerVisitID);
            }
        }

        public void unscheduleVisit(DataRow visitRow)
        {
            var originaldetail = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(visitRow["EngineerVisitID"]));
            // If DB.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work(visitRow("JobOfWorkID")).Table.Rows.Count > 0 Then
            _database.ClearParameter();
            _database.AddParameter("@VisitStatusID", Conversions.ToInteger(Enums.VisitStatus.Ready_For_Schedule), true);
            _database.AddParameter("@VisitID", visitRow["EngineerVisitID"], true);
            if (originaldetail.StatusEnumID == Conversions.ToInteger(Enums.VisitStatus.Downloaded))
            {
                _database.AddParameter("@TabletActionID", 1, true); // Remove from old engineer
                _database.AddParameter("@RemoveEngineerID", originaldetail.EngineerID, true); // who
            }

            if (Helper.MakeBooleanValid(_database.ExecuteSP_OBJECT("unscheduleVisit")) == true)
            {
                // Status Changed enter Job Audit
                var jA = new JobAudits.JobAudit();
                jA.SetJobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(Conversions.ToInteger(visitRow["EngineerVisitID"])).JobID;
                jA.SetActionChange = "Visit Status changed to Unscheduled" + " (Unique Visit ID: " + visitRow["EngineerVisitID"] + ")";
                App.DB.JobAudit.Insert(jA);
            }

            // Check if job is an import job
            if (App.DB.JobImports.JobImport_Get_ByJobNumber(Conversions.ToString(visitRow["JobNumber"])).Count > 0)
            {
                JobImportUpdate(Conversions.ToString(visitRow["JobNumber"]), Helper.MakeIntegerValid(visitRow["EngineerVisitID"]));
            }
        }

        public void JobImportUpdate(string jobNumber, int engineerVisitId)
        {
            var dt = App.DB.JobImports.JobImport_Get_ByJobNumber(jobNumber)?.Table;
            var visit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(engineerVisitId);
            var email = new Emails();
            email.To = EmailAddress.Electrical;
            email.From = EmailAddress.FSM;
            email.Subject = "Job Adjusted";
            email.Body = "Dear Electrical Team," + Constants.vbCrLf + Constants.vbCrLf;
            email.Body += "The following job: " + jobNumber + " has been adjusted in the scheduler." + Constants.vbCrLf + Constants.vbCrLf;
            if (visit.StatusEnumID == (int)Enums.VisitStatus.Scheduled)
            {
                email.Body += "The job has been rescheduled for: " + visit.StartDateTime.ToLongDateString() + "<br/><br/>";
                email.Body += "Please find the new letter generated attached." + "<br/><br/>";
                email.Body += "Kind regards," + "<br/><br/>";
                email.Body += App.TheSystem.Configuration.CompanyName;
                var details = new ArrayList();
                details.Add(dt);
                var print = new Printing(details, Conversions.ToString(dt?.Rows[0]["Type"]), Enums.SystemDocumentType.JobImportLetters, false, 0, true);
                email.Attachments.Add(print.EmailWP());
            }
            else
            {
                email.Body += "The job has been moved to the holding area." + Constants.vbCrLf + Constants.vbCrLf;
            }

            email.SendMe = true;
            email.Send();
        }

        public int getTimesheetStatus(int EngId, int VisitId = 0)
        {
            int i = 0;
            _database.ClearParameter();
            _database.AddParameter("@EngID", EngId, true);
            _database.AddParameter("@VisitID", VisitId, true);
            i = Conversions.ToInteger(_database.ExecuteSP_OBJECT("Scheduler_Timesheet_Get"));
            return i;
        }

        public HeartBeats.HeartBeat GetLatestHeartBeat(int EngId)
        {
            try
            {
                var hb = new HeartBeats.HeartBeat();
                if (_database is null)
                {
                    return new HeartBeats.HeartBeat();
                }

                _database.ClearParameter();
                _database.AddParameter("@EngID", EngId, true);
                var dt = _database.ExecuteSP_DataTable("Scheduler_GetLatestHeartbeat");
                if (dt.Rows.Count > 0)
                {
                    hb.SetLockedVisitID = dt.Rows[0]["LockVisitID"];
                    hb.LastHeartBeat = Conversions.ToDate(dt.Rows[0]["DateCreated"]);
                }

                hb.LastCheck = DateAndTime.Now;
                return hb;
            }
            catch (Exception ex)
            {
                return new HeartBeats.HeartBeat();
            }
        }

        public DataView Get_EngineerLocation(int engineerId)
        {
            var dt = new DataTable();
            var command = new SqlCommand("Scheduler_Get_EngineerLocation", new SqlConnection(_database.ServerConnectionString));
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EngineerID", engineerId);
                dt = _database.ExecuteCommand_DataTable(command);
                return new DataView(dt);
            }
            catch (Exception ex)
            {
                return new DataView(dt);
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}