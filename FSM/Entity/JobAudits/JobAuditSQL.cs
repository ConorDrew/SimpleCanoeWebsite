// Decompiled with JetBrains decompiler
// Type: FSM.Entity.JobAudits.JobAuditSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.JobAudits
{
    public class JobAuditSQL
    {
        private Database _database;

        public JobAuditSQL(Database database)
        {
            this._database = database;
        }

        public JobAudit Insert(JobAudit oJobAudit)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobID", (object)oJobAudit.JobID, true);
            this._database.AddParameter("@ActionChange", (object)oJobAudit.ActionChange, true);
            this._database.AddParameter("@ActionDateTime", (object)DateAndTime.Now, true);
            this._database.AddParameter("@UserID", (object)App.loggedInUser.UserID, true);
            oJobAudit.SetJobAuditID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("JobAudit_Insert", true)));
            return oJobAudit;
        }

        public JobAudit Insert(JobAudit oJobAudit, SqlTransaction trans)
        {
            oJobAudit.SetJobAuditID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(new SqlCommand()
            {
                CommandText = "JobAudit_Insert",
                CommandType = CommandType.StoredProcedure,
                Transaction = trans,
                Connection = trans.Connection,
                Parameters = {
          new SqlParameter("@JobID", (object) oJobAudit.JobID),
          new SqlParameter("@ActionChange", (object) oJobAudit.ActionChange),
          new SqlParameter("@ActionDateTime", (object) DateAndTime.Now),
          new SqlParameter("@UserID", (object) App.loggedInUser.UserID)
        }
            }.ExecuteScalar()));
            return oJobAudit;
        }

        public DataView Get_For_Job(int JobID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobID", (object)JobID, true);
            DataTable table = this._database.ExecuteSP_DataTable("JobAudit_Get", true);
            table.TableName = Enums.TableNames.tblJobAudit.ToString();
            return new DataView(table);
        }
    }
}