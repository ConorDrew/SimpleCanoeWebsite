// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetVanServiceSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;

namespace FSM.Entity.FleetVans
{
    public class FleetVanServiceSQL
    {
        private Database _database;

        public FleetVanServiceSQL(Database database)
        {
            this._database = database;
        }

        public DataView GetServices_ByVanId(int vanID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanID", (object)vanID, false);
            DataTable table = this._database.ExecuteSP_DataTable("FleetVanService_GetJobs_ForVan", true);
            table.TableName = Enums.TableNames.tblJob.ToString();
            return new DataView(table);
        }

        public int GetVanId_ByJobId(int jobID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobID", (object)jobID, false);
            return Conversions.ToInteger(this._database.ExecuteSP_OBJECT("FleetVanService_GetVan_ForJob", true));
        }

        public int Update(int jobID, int vanID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanID", (object)vanID, false);
            this._database.AddParameter("@JobID", (object)jobID, false);
            return Conversions.ToInteger(this._database.ExecuteSP_OBJECT("FleetVanService_Update", true));
        }

        public int Insert(int jobID, int vanID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanID", (object)vanID, false);
            this._database.AddParameter("@JobID", (object)jobID, false);
            return Conversions.ToInteger(this._database.ExecuteSP_OBJECT("FleetVanService_Insert", true));
        }

        public void Delete(int jobID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobID", (object)jobID, false);
            this._database.ExecuteSP_NO_Return("FleetVanService_Delete", true);
        }
    }
}