// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;

namespace FSM.Entity.FleetVans
{
  public class FleetSQL
  {
    private Database _database;

    public FleetSQL(Database database)
    {
      this._database = database;
    }

    public DataView FleetJobType_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (FleetJobType_GetAll), true);
      table.TableName = Enums.TableNames.tblFleetJobType.ToString();
      return new DataView(table);
    }
  }
}
