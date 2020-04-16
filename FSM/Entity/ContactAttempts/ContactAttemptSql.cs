// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContactAttempts.ContactAttemptSql
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContactAttempts
{
    public class ContactAttemptSql
    {
        private Database _database;

        public ContactAttemptSql(Database database)
        {
            this._database = database;
        }

        public ContactAttempt Insert(ContactAttempt contactAttempt)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ContactMethedID", (object)contactAttempt.ContactMethedID, false);
            this._database.AddParameter("@LinkID", (object)contactAttempt.LinkID, false);
            this._database.AddParameter("@LinkRef", (object)contactAttempt.LinkRef, false);
            this._database.AddParameter("@ContactMade", (object)contactAttempt.ContactMade, true);
            this._database.AddParameter("@Notes", (object)contactAttempt.Notes, false);
            this._database.AddParameter("@ContactMadeByUserId", (object)contactAttempt.ContactMadeByUserId, false);
            contactAttempt.ContactAttemptID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ContactAttempt_Insert", true)));
            return contactAttempt;
        }

        public List<ContactAttempt> GetAll(Enums.TableNames linkTable, int linkId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@LinkID", (object)(int)linkTable, false);
            this._database.AddParameter("@LinkRef", (object)linkId, false);
            DataTable table = this._database.ExecuteSP_DataTable("ContactAttempt_GetAll", true);
            return table != null && table.Rows.Count > 0 ? ObjectMap.DataTableToList<ContactAttempt>(table) : (List<ContactAttempt>)null;
        }

        public List<ContactAttempt> GetAll_ForJob(int jobId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobID", (object)jobId, false);
            DataTable table = this._database.ExecuteSP_DataTable("ContactAttempt_GetAll_ForJob", true);
            return table != null && table.Rows.Count > 0 ? ObjectMap.DataTableToList<ContactAttempt>(table) : (List<ContactAttempt>)null;
        }

        public DataView ContactMethod_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(ContactMethod_GetAll), true);
            table.TableName = Enums.TableNames.tblContact.ToString();
            return new DataView(table);
        }
    }
}