// Decompiled with JetBrains decompiler
// Type: FSM.Entity.JobContacts.JobContactSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.JobContacts
{
    public class JobContactSQL
    {
        private Database _database;

        public JobContactSQL(Database database)
        {
            this._database = database;
        }

        public JobContact Insert(JobContact oJobContact)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobID", (object)oJobContact.JobID, true);
            this._database.AddParameter("@ContactType", (object)oJobContact.contactType, true);
            oJobContact.SetjobContactID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("JobContact_Insert", true)));
            return oJobContact;
        }

        public void Update_Access(int JobID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobID", (object)JobID, true);
            this._database.ExecuteSP_OBJECT("JobContact_Update_Access", true);
        }

        public DataView Get_For_Job(int JobID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobID", (object)JobID, true);
            DataTable table = this._database.ExecuteSP_DataTable("JobContact_Get", true);
            table.TableName = Enums.TableNames.tblJobAudit.ToString();
            return new DataView(table);
        }
    }
}