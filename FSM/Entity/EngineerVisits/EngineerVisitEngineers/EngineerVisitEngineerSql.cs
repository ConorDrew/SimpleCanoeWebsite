// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisits.EngineerVisitEngineers.EngineerVisitEngineerSql
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.EngineerVisits.EngineerVisitEngineers.Enums;
using FSM.Entity.Sys;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisits.EngineerVisitEngineers
{
  public class EngineerVisitEngineerSql
  {
    private Database _database;

    public EngineerVisitEngineerSql(Database database)
    {
      this._database = database;
    }

    public EngineerVisitEngineer Get(object key, GetBy getBy)
    {
      this._database.ClearParameter();
      DataTable table;
      switch (getBy)
      {
        case GetBy.Id:
          this._database.AddParameter("@Id", (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(key)), true);
          table = this._database.ExecuteSP_DataTable("EngineerVisitEngineer_Get", true);
          break;
        case GetBy.EngineerVisitId:
          this._database.AddParameter("@EngineerVisitId", (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(key)), true);
          table = this._database.ExecuteSP_DataTable("EngineerVisitEngineer_Get_ByEngineerVisitId", true);
          break;
        default:
          return (EngineerVisitEngineer) null;
      }
      if (table == null || table.Rows.Count <= 0)
        return (EngineerVisitEngineer) null;
      List<EngineerVisitEngineer> list = ObjectMap.DataTableToList<EngineerVisitEngineer>(table);
      return list != null ? list.First<EngineerVisitEngineer>() : (EngineerVisitEngineer) null;
    }

    public EngineerVisitEngineer Insert(EngineerVisitEngineer eve)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitId", (object) eve.EngineerVisitId, false);
      this._database.AddParameter("@EngineerId", (object) eve.EngineerId, false);
      this._database.AddParameter("@Department", (object) eve.Department, false);
      this._database.AddParameter("@OftecNo", (object) eve.OftecNo, false);
      this._database.AddParameter("@GasSafeNo", (object) eve.GasSafeNo, false);
      this._database.AddParameter("@ManagerID", (object) eve.ManagerId, false);
      this._database.AddParameter("@CostToCompany", (object) eve.CostToCompany, false);
      eve.Id = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("EngineerVisitEngineer_Insert", true)));
      return eve;
    }

    public bool Delete(object key, DeleteBy deleteBy)
    {
      this._database.ClearParameter();
      string empty = string.Empty;
      string SPName;
      switch (deleteBy)
      {
        case DeleteBy.Id:
          this._database.AddParameter("@Id", (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(key)), true);
          SPName = "EngineerVisitEngineer_Delete";
          break;
        case DeleteBy.EngineerVisitId:
          this._database.AddParameter("@EngineerVisitId", (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(key)), true);
          SPName = "EngineerVisitEngineer_Delete_ByEngineerVisitId";
          break;
        default:
          return false;
      }
      return this._database.ExecuteSP_ReturnRowsAffected(SPName) == 1;
    }
  }
}
