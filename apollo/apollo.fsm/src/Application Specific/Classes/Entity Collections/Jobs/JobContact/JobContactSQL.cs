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

            public JobContact Insert(JobContact oJobContact)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", oJobContact.JobID, true);
                _database.AddParameter("@ContactType", oJobContact.contactType, true);
                oJobContact.SetjobContactID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobContact_Insert"));
                return oJobContact;
            }
        }
    }
}