using System.Data;

namespace FSM.Entity
{
    namespace JobContacts
    {
        public class JobContactSQL
        {
            private Sys.Database _database;

            public JobContactSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public JobContact Insert(JobContact oJobContact)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", oJobContact.JobID, true);
                _database.AddParameter("@ContactType", oJobContact.contactType, true);
                oJobContact.SetjobContactID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobContact_Insert"));
                return oJobContact;
            }

            public void Update_Access(int JobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", JobID, true);
                _database.ExecuteSP_OBJECT("JobContact_Update_Access");
            }

            public DataView Get_For_Job(int JobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", JobID, true);
                var dt = _database.ExecuteSP_DataTable("JobContact_Get");
                dt.TableName = Sys.Enums.TableNames.tblJobAudit.ToString();
                return new DataView(dt);
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}