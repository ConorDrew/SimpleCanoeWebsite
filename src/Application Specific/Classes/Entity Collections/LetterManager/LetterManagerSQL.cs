using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity.LetterManager
{
    public class LetterManagerSQL
    {
        private Sys.Database _database;

        public LetterManagerSQL(Sys.Database database)
        {
            _database = database;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public DataView GetBucketsL1(DateTime LetterManagerFilterDate, int CustomerID)
        {
            _database.ClearParameter();
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, true);
            _database.AddParameter("@CustomerID", CustomerID, true);
            return new DataView(_database.ExecuteSP_DataTable("GetBucketsL1"));
        }

        public DataView MakeServiceLetter(int engineervisitid)
        {
            _database.ClearParameter();
            _database.AddParameter("@EngineerVisitID", engineervisitid, true);
            return new DataView(_database.ExecuteSP_DataTable("MakeServiceLetter"));
        }

        public DataView ClearStuckSite(DateTime Lastservicedate, int SiteID, string Type)
        {
            _database.ClearParameter();
            _database.AddParameter("@LastServiceDate", Lastservicedate.ToString("yyyy-MM-dd"), true);
            _database.AddParameter("@SiteID", SiteID, true);
            _database.AddParameter("@Type", Type, true);
            return new DataView(_database.ExecuteSP_DataTable("LetterManager_ClearStuckSites"));
        }

        public DataView GetLetterScheduledAppointments(DateTime LetterManagerFilterDate, int CustomerID)
        {
            _database.ClearParameter();
            _database.AddParameter("@Date", LetterManagerFilterDate, true);
            _database.AddParameter("@CustomerID", CustomerID, true);
            return new DataView(_database.ExecuteSP_DataTable("GetLetterScheduledAppointments"));
        }

        public DataView Letter1ManagerMK2Profile(DateTime LetterManagerFilterDate, int CustomerID, int top = 0)
        {
            _database.ClearParameter();
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, true);
            _database.AddParameter("@CustomerID", CustomerID, true);
            _database.AddParameter("@top", top, true);
            return new DataView(_database.ExecuteSP_DataTable("LetterManager_1_MK2_Profile_New"));
        }

        public DataView Letter1ManagerMK2(DateTime LetterManagerFilterDate, int CustomerID)
        {
            _database.ClearParameter();
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, true);
            _database.AddParameter("@CustomerID", CustomerID, true);
            return new DataView(_database.ExecuteSP_DataTable("LetterManager_1_MK2_New"));
        }

        public DataView Letter1Manager(DateTime LetterManagerFilterDate, int CustomerID, int Days = -309)
        {
            _database.ClearParameter();
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, true);
            _database.AddParameter("@CustomerID", CustomerID, true);
            _database.AddParameter("@Days", Days, true);
            return new DataView(_database.ExecuteSP_DataTable("LetterManager"));
        }

        public DataTable Letter2Manager(DateTime LetterManagerFilterDate, int CustomerID, int Days = -330)                // 
        {
            _database.ClearParameter();
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, true);
            _database.AddParameter("@CustomerID", CustomerID, true);
            _database.AddParameter("@Days", Days, true);
            return _database.ExecuteSP_DataTable("Letter2Manager");
        }

        public DataView Letter2ManagerMK2(DateTime LetterManagerFilterDate, int CustomerID)                // 
        {
            _database.ClearParameter();
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, true);
            _database.AddParameter("@CustomerID", CustomerID, true);
            return new DataView(_database.ExecuteSP_DataTable("LetterManager_2_MK2_New"));
        }

        public DataView Letter3ManagerMK2(DateTime LetterManagerFilterDate, int CustomerID)                // 
        {
            _database.ClearParameter();
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, true);
            _database.AddParameter("@CustomerID", CustomerID, true);
            return new DataView(_database.ExecuteSP_DataTable("LetterManager_3_MK2_New"));
        }

        public DataTable Letter3Manager(DateTime LetterManagerFilterDate, int CustomerID)                // 
        {
            _database.ClearParameter();
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, true);
            _database.AddParameter("@CustomerID", CustomerID, true);
            return _database.ExecuteSP_DataTable("Letter3Manager");
        }

        public void LetterGenerated(int SiteID, string LetterType, DateTime LastServiceDate, int JobID, string FolderPath, SqlTransaction trans)
        {
            var Command = new SqlCommand();
            Command.CommandText = "LetterGenerated";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Transaction = trans;
            Command.Connection = trans.Connection;
            Command.Parameters.Add(new SqlParameter("@SiteID", SiteID));
            Command.Parameters.Add(new SqlParameter("@LetterType", LetterType));
            Command.Parameters.Add(new SqlParameter("@LastServiceDate", LastServiceDate));
            Command.Parameters.Add(new SqlParameter("@JobID", JobID));
            Command.Parameters.Add(new SqlParameter("@FolderPath", FolderPath));
            Command.ExecuteNonQuery();
        }

        public void LetterGeneratedMK2(int SiteID, string LetterType, DateTime LastServiceDate, int JobID, string FolderPath, int fuelId = 0)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteID", SiteID, true);
            _database.AddParameter("@LetterType", LetterType, true);
            _database.AddParameter("@LastServiceDate", LastServiceDate, true);
            _database.AddParameter("@JobID", JobID, true);
            _database.AddParameter("@FolderPath", FolderPath, true);
            _database.AddParameter("@FuelID", fuelId, true);
            _database.ExecuteSP_NO_Return("LetterGenerated");
        }

        public DataTable LetterReport(int SiteID)                // 
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteID", SiteID, true);
            return _database.ExecuteSP_DataTable("LetterReport");
        }

        public DataTable Letter3_TomorrowsVisit(DateTime tomorrow)                // 
        {
            _database.ClearParameter();
            _database.AddParameter("@TomorrowStart", Conversions.ToDate(Strings.Format(tomorrow, "dd-MMM-yyyy") + " 00:00:00"), true);
            _database.AddParameter("@TomorrowEnd", Conversions.ToDate(Strings.Format(tomorrow, "dd-MMM-yyyy") + " 23:59:59"), true);
            return _database.ExecuteSP_DataTable("Letter3_TomorrowsVisit");
        }

        public void Clear_LetterDays_Table()
        {
            _database.ExecuteWithOutReturn("DELETE FROM tblLetterDays", false);
        }

        public void Update_LetterDays_Table(DateTime MondayDate, DateTime TheDate, int ApptCount, int AM, int PM, int MinsTally, int LoopNumber)
        {
            if (PM == default)
            {
                _database.ExecuteWithOutReturn("UPDATE tblLetterDays SET ApptCount = '" + ApptCount + "', AM = '" + AM + "', MinsTally = '" + MinsTally + "' WHERE MondayDate = '" + Strings.Format(MondayDate, "yyyy-MM-dd") + "' AND TheDate = '" + Strings.Format(TheDate, "yyyy-MM-dd") + "' AND LoopNumber = '" + LoopNumber + "'", false);
            }
            else
            {
                _database.ExecuteWithOutReturn("UPDATE tblLetterDays SET ApptCount = '" + ApptCount + "', PM = '" + PM + "', MinsTally = '" + MinsTally + "' WHERE MondayDate = '" + Strings.Format(MondayDate, "yyyy-MM-dd") + "' AND TheDate = '" + Strings.Format(TheDate, "yyyy-MM-dd") + "' AND LoopNumber = '" + LoopNumber + "'", false);
            }
        }

        public void Insert_LetterDays_Table(DateTime MondayDate, DateTime TheDate, int MinsTally, int LoopNumber)
        {
            _database.ExecuteWithOutReturn("INSERT INTO tblLetterDays (MondayDate, TheDate, ApptCount, AM, PM, MinsTally, LoopNumber) VALUES ('" + Strings.Format(MondayDate, "yyyy-MM-dd") + "','" + Strings.Format(TheDate, "yyyy-MM-dd") + "',1,1,1,'" + MinsTally + "','" + LoopNumber + "')", false);
        }

        public DataView Get_Letter1Jobs(DateTime LetterManagerFilterDate, int CustomerID, bool profile, int top = 0)
        {
            _database.ClearParameter();
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, true);
            _database.AddParameter("@CustomerID", CustomerID, true);
            _database.AddParameter("@Profile", profile, true);
            _database.AddParameter("@Top", top, true);
            return new DataView(_database.ExecuteSP_DataTable("LetterManager_1_Mk4"));
        }

        public DataView Get_Letter1Jobs_MultipleFuel(DateTime LetterManagerFilterDate, int CustomerID)
        {
            _database.ClearParameter();
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, true);
            _database.AddParameter("@CustomerID", CustomerID, true);
            return new DataView(_database.ExecuteSP_DataTable("LetterManager_1_Mk4_MultipleFuel"));
        }

        public DataView Get_Letter2Jobs(DateTime LetterManagerFilterDate, int CustomerID)                // 
        {
            _database.ClearParameter();
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, true);
            _database.AddParameter("@CustomerID", CustomerID, true);
            return new DataView(_database.ExecuteSP_DataTable("LetterManager_2_Mk4"));
        }

        public DataView Get_Letter3Jobs(DateTime LetterManagerFilterDate, int CustomerID, int fuelId = 0)                // 
        {
            _database.ClearParameter();
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, true);
            _database.AddParameter("@CustomerID", CustomerID, true);
            return new DataView(_database.ExecuteSP_DataTable("LetterManager_3_Mk4"));
        }

        public DataView GetLetterScheduledAppointmentsMK3(DateTime LetterManagerFilterDate, int CustomerID)
        {
            _database.ClearParameter();
            _database.AddParameter("@Date", LetterManagerFilterDate, true);
            _database.AddParameter("@CustomerID", CustomerID, true);
            return new DataView(_database.ExecuteSP_DataTable("GetLetterScheduledAppointmentsMK3"));
        }

        public DataTable Get_Appointments_Main_MK3(DateTime StartDate, int TimeReq, int days = 14, int TimeLimit = 240)
        {
            _database.ClearParameter();
            _database.AddParameter("@StartDate", StartDate, true);
            _database.AddParameter("@timereq", TimeReq, true);
            _database.AddParameter("@Days", days, true);
            _database.AddParameter("@TimeLimit", TimeLimit, true);
            var dt = _database.ExecuteSP_DataTable("Get_Appointments_Main");
            dt.TableName = Sys.Enums.TableNames.tblJobItem.ToString();
            return dt;
        }

        public DataTable LetterManager_GetJob_FromSiteAndDate(int siteId, DateTime bookedDate)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteID", siteId, true);
            _database.AddParameter("@VisitDate", bookedDate, true);
            var dt = _database.ExecuteSP_DataTable("LetterManager_GetJob_FromSiteAndDate");
            dt.TableName = Sys.Enums.TableNames.tblJob.ToString();
            return dt;
        }

        public DataTable LetterGenerated_CheckToday(string letterType, int jobId, DateTime genDate)
        {
            _database.ClearParameter();
            _database.AddParameter("@LetterType", letterType, true);
            _database.AddParameter("@JobID", jobId, true);
            _database.AddParameter("@GenDate", genDate, true);
            var dt = _database.ExecuteSP_DataTable("LetterGenerated_CheckToday");
            dt.TableName = Sys.Enums.TableNames.tblJob.ToString();
            return dt;
        }

        public DataView LetterManagerAddSiteMK3(DateTime LetterManagerFilterDate, int SiteID)                // 
        {
            _database.ClearParameter();
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, true);
            _database.AddParameter("@SiteID", SiteID, true);
            return new DataView(_database.ExecuteSP_DataTable("LetterManager_AddSite_MK3"));
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}