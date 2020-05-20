using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace FSM.Entity
{
    namespace JobAudits
    {
        public class JobAuditSQL
        {
            private Sys.Database _database;

            public JobAuditSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public JobAudit Insert(JobAudit oJobAudit)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", oJobAudit.JobID, true);
                _database.AddParameter("@ActionChange", oJobAudit.ActionChange, true);
                _database.AddParameter("@ActionDateTime", DateAndTime.Now, true);
                _database.AddParameter("@UserID", App.loggedInUser.UserID, true);
                oJobAudit.SetJobAuditID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobAudit_Insert"));
                return oJobAudit;
            }

            public JobAudit Insert(JobAudit oJobAudit, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "JobAudit_Insert";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.Add(new SqlParameter("@JobID", oJobAudit.JobID));
                Command.Parameters.Add(new SqlParameter("@ActionChange", oJobAudit.ActionChange));
                Command.Parameters.Add(new SqlParameter("@ActionDateTime", DateAndTime.Now));
                Command.Parameters.Add(new SqlParameter("@UserID", App.loggedInUser.UserID));
                oJobAudit.SetJobAuditID = Sys.Helper.MakeIntegerValid(Command.ExecuteScalar());
                return oJobAudit;
            }

            public DataView Get_For_Job(int JobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", JobID, true);
                var dt = _database.ExecuteSP_DataTable("JobAudit_Get");
                dt.TableName = Sys.Enums.TableNames.tblJobAudit.ToString();
                return new DataView(dt);
            }

            
        }
    }
}