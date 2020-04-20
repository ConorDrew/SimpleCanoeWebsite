using System.Collections.Generic;
using System.Data;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity.ContactAttempts
{
    public class ContactAttemptSql
    {
        private Database _database;

        public ContactAttemptSql(Database database)
        {
            _database = database;
        }

        public ContactAttempt Insert(ContactAttempt contactAttempt)
        {
            _database.ClearParameter();
            _database.AddParameter("@ContactMethedID", contactAttempt.ContactMethedID);
            _database.AddParameter("@LinkID", contactAttempt.LinkID);
            _database.AddParameter("@LinkRef", contactAttempt.LinkRef);
            _database.AddParameter("@ContactMade", contactAttempt.ContactMade, true);
            _database.AddParameter("@Notes", contactAttempt.Notes);
            _database.AddParameter("@ContactMadeByUserId", contactAttempt.ContactMadeByUserId);
            contactAttempt.ContactAttemptID = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContactAttempt_Insert"));
            return contactAttempt;
        }

        public List<ContactAttempt> GetAll(Enums.TableNames linkTable, int linkId)
        {
            _database.ClearParameter();
            _database.AddParameter("@LinkID", Conversions.ToInteger(linkTable));
            _database.AddParameter("@LinkRef", linkId);
            var dt = _database.ExecuteSP_DataTable("ContactAttempt_GetAll");
            if (dt is object && dt.Rows.Count > 0)
            {
                var contactAttempts = ObjectMap.DataTableToList<ContactAttempt>(dt);
                return contactAttempts;
            }
            else
            {
                return null;
            }
        }

        public List<ContactAttempt> GetAll_ForJob(int jobId)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobID", jobId);
            var dt = _database.ExecuteSP_DataTable("ContactAttempt_GetAll_ForJob");
            if (dt is object && dt.Rows.Count > 0)
            {
                var contactAttempts = ObjectMap.DataTableToList<ContactAttempt>(dt);
                return contactAttempts;
            }
            else
            {
                return null;
            }
        }

        public DataView ContactMethod_GetAll()
        {
            _database.ClearParameter();
            var dt = _database.ExecuteSP_DataTable("ContactMethod_GetAll");
            dt.TableName = Enums.TableNames.tblContact.ToString();
            return new DataView(dt);
        }
    }
}