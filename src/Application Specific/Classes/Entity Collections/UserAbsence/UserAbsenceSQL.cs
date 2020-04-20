using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity.UserAbsence
{
    public class UserAbsenceSQL
    {
        private Sys.Database _database;

        public UserAbsenceSQL(Sys.Database database)
        {
            _database = database;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void Delete(int UserAbsenceID)
        {
            _database.ClearParameter();
            _database.AddParameter("@UserAbsenceID", UserAbsenceID);
            _database.ExecuteSP_NO_Return("UserAbsence_Delete");
        }

        public UserAbsence UserAbsence_Get(int UserAbsenceID)
        {
            var dt = new DataTable();
            var oUserAbsence = new UserAbsence();
            var pUserAbsenceID = new SqlParameter("@UserAbsenceID", UserAbsenceID);

            // Get the datatable from the database store in dt
            dt = _database.ExecuteSP_DataTable("UserAbsence_Get", pUserAbsenceID);
            if (dt is object)
            {
                if (dt.Rows.Count > 0)
                {
                    oUserAbsence.SetUserAbsenceID = dt.Rows[0]["UserAbsenceID"];
                    oUserAbsence.SetUserID = dt.Rows[0]["UserID"];
                    oUserAbsence.SetAbsenceTypeID = dt.Rows[0]["AbsenceTypeID"];
                    oUserAbsence.DateFrom = Conversions.ToDate(dt.Rows[0]["DateFrom"]);
                    oUserAbsence.DateTo = Conversions.ToDate(dt.Rows[0]["DateTo"]);
                    oUserAbsence.SetComments = dt.Rows[0]["Comments"];
                }

                oUserAbsence.Exists = true;
                return oUserAbsence;
            }
            else
            {
                return null;
            }
        }

        public DataTable UserAbsence_GetAll()
        {
            // get the all the UserAbsence data from the 

            DataTable dt;
            dt = _database.ExecuteSP_DataTable("UserAbsence_GetAll");
            dt.TableName = "tblUserAbsence";
            return dt;
        }

        public DataTable UserAbsence_GetAll_ByDates(DateTime startDate, DateTime endDate)
        {
            // get the all the UserAbsence data from the 
            _database.ClearParameter();
            _database.AddParameter("@StartDate", Sys.Helper.MakeDateTimeValid(Strings.Format(startDate, "dd/MMM/yyyy") + " 00:00:00"), true);
            _database.AddParameter("@EndDate", Sys.Helper.MakeDateTimeValid(Strings.Format(endDate, "dd/MMM/yyyy") + " 23:59:59"), true);
            DataTable dt;
            dt = _database.ExecuteSP_DataTable("UserAbsence_GetAll_ByDates");
            dt.TableName = "tblUserAbsence";
            return dt;
        }

        public UserAbsence Insert(UserAbsence oUserAbsence)
        {
            AddUserAbsenceParameters(ref oUserAbsence);
            oUserAbsence.Exists = true;
            oUserAbsence.SetUserAbsenceID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("UserAbsence_Insert"));
            return oUserAbsence;
        }

        public void Update(UserAbsence oUserAbsence)
        {
            _database.ClearParameter();
            AddUserAbsenceParameters(ref oUserAbsence);
            _database.AddParameter("@UserAbsenceID", oUserAbsence.UserAbsenceID, true);
            _database.ExecuteSP_NO_Return("UserAbsence_Update");
        }

        private void AddUserAbsenceParameters(ref UserAbsence oUserAbsence)
        {
            _database.ClearParameter();
            _database.AddParameter("@UserID", oUserAbsence.UserID);
            _database.AddParameter("@AbsenceTypeID", oUserAbsence.AbsenceTypeID);
            _database.AddParameter("@DateFrom", Strings.Format(oUserAbsence.DateFrom, "yyyy-MM-dd HH:mm"));
            _database.AddParameter("@DateTo", Strings.Format(oUserAbsence.DateTo, "yyyy-MM-dd HH:mm"));
            _database.AddParameter("@Comments", oUserAbsence.Comments);
        }

        public DataTable UserAbsenceTypes_GetAll()
        {
            var dt = new DataTable();
            dt = _database.ExecuteSP_DataTable("UserAbsenceTypes_GetAll");
            dt.TableName = "tblUserAbsenceTypes";
            return dt;
        }

        public DataTable AbsenceSearch(string sql)
        {
            var dt = new DataTable();
            dt = _database.ExecuteWithReturn(sql);
            dt.TableName = "tblUserAbsence";
            return dt;
        }


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}