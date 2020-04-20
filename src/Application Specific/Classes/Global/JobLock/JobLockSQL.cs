using System.Data;
using Microsoft.VisualBasic;

namespace FSM.Entity
{
    namespace JobLock
    {
        public class JobLockSQL
        {
            private Sys.Database _database;

            public JobLockSQL(Sys.Database databaseIn)
            {
                _database = databaseIn;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public JobLock Check(int JobID)
            {
                var oJobLock = new JobLock();
                oJobLock.JobID = JobID;
                _database.ClearParameter();
                _database.AddParameter("@JobID", JobID, true);

                // check if the record is already locked
                var t = _database.ExecuteSP_DataTable("JobLock_IsRecordLocked");
                if (t.Rows.Count > 0)
                {
                    var r = t.Rows[0];
                    oJobLock.JobLockID = Sys.Helper.MakeIntegerValid(r["JobLockID"]);
                    oJobLock.UserID = Sys.Helper.MakeIntegerValid(r["UserID"]);
                    oJobLock.DateLock = Sys.Helper.MakeDateTimeValid(r["DateLock"]);
                    oJobLock.NameOfUserWhoLocked = Sys.Helper.MakeStringValid(r["FullName"]);
                    return oJobLock;
                }
                else
                {
                    return null;
                }
            }

            public JobLock JobLock(int JobID)
            {
                var oJobLock = new JobLock();
                oJobLock.JobID = JobID;
                _database.ClearParameter();
                _database.AddParameter("@JobID", JobID, true);

                // check if the record is already locked
                var t = _database.ExecuteSP_DataTable("JobLock_IsRecordLocked");
                if (t.Rows.Count > 0)
                {
                    var r = t.Rows[0];
                    oJobLock.JobLockID = Sys.Helper.MakeIntegerValid(r["JobLockID"]);
                    oJobLock.UserID = Sys.Helper.MakeIntegerValid(r["UserID"]);
                    oJobLock.DateLock = Sys.Helper.MakeDateTimeValid(r["DateLock"]);
                    oJobLock.NameOfUserWhoLocked = Sys.Helper.MakeStringValid(r["FullName"]);
                    if (oJobLock.UserID == App.loggedInUser.UserID)
                    {
                        _database.ClearParameter();
                        _database.AddParameter("@JobID", JobID, true);
                        _database.AddParameter("@UserID", App.loggedInUser.UserID, true);
                        oJobLock.JobLockID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobLock_Insert"));
                    }
                }
                else
                {
                    // the record is not locked, so lock it
                    oJobLock.UserID = App.loggedInUser.UserID;
                    oJobLock.DateLock = DateAndTime.Now;
                    oJobLock.NameOfUserWhoLocked = App.loggedInUser.Fullname;
                    _database.ClearParameter();
                    _database.AddParameter("@JobID", JobID, true);
                    _database.AddParameter("@UserID", App.loggedInUser.UserID, true);
                    oJobLock.JobLockID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobLock_Insert"));
                }

                return oJobLock;
            }

            public DataView GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("JobLock_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblJobLock.ToString();
                return new DataView(dt);
            }

            public void Delete(int JobLockID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobLockID", JobLockID, true);
                _database.ExecuteSP_NO_Return("JobLock_Delete");
            }

            public void DeleteAll()
            {
                _database.ClearParameter();
                _database.AddParameter("@UserID", App.loggedInUser?.UserID, true);
                _database.ExecuteSP_NO_Return("JobLock_DeleteAll");
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}