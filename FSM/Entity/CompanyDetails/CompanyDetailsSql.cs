// Decompiled with JetBrains decompiler
// Type: FSM.Entity.CompanyDetails.CompanyDetailsSql
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Linq;

namespace FSM.Entity.CompanyDetails
{
    public class CompanyDetailsSql
    {
        private Database _database;

        public CompanyDetailsSql(Database database)
        {
            this._database = database;
        }

        public FSM.Entity.CompanyDetails.CompanyDetails Get()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable("CompanyDetails_Get", true);
            return table != null && table.Rows.Count > 0 ? ObjectMap.DataTableToList<FSM.Entity.CompanyDetails.CompanyDetails>(table).FirstOrDefault<FSM.Entity.CompanyDetails.CompanyDetails>() : (FSM.Entity.CompanyDetails.CompanyDetails)null;
        }
    }
}