// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Accounts.SunFinanceSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;

namespace FSM.Entity.Accounts
{
  public class SunFinanceSQL
  {
    private Database _database;

    public SunFinanceSQL(Database database)
    {
      this._database = database;
    }

    public DataTable GetAllMaps()
    {
      this._database.ClearParameter();
      return this._database.ExecuteSP_DataTable("AccountsMapping_Get_All", true);
    }
  }
}
