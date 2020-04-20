// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Settings.Scheduler.JobTypeColourSql
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Settings.Scheduler
{
    public class JobTypeColourSql
    {
        private Database _database;

        public JobTypeColourSql(Database database)
        {
            this._database = database;
        }

        public List<JobTypeColour> Get_All()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable("JobTypeColour_Get_All", true);
            return table != null && table.Rows.Count > 0 ? ObjectMap.DataTableToList<JobTypeColour>(table) : (List<JobTypeColour>)null;
        }

        public JobTypeColour Insert(JobTypeColour userJobTypeColour)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobTypeId", (object)userJobTypeColour.JobTypeId, false);
            this._database.AddParameter("@Colour", (object)userJobTypeColour.Colour, false);
            userJobTypeColour.Id = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("JobTypeColour_Insert", true)));
            return userJobTypeColour;
        }

        public bool Delete(int Id)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Id", (object)Id, false);
            return this._database.ExecuteSP_ReturnRowsAffected("JobTypeColour_Delete") == 1;
        }
    }
}