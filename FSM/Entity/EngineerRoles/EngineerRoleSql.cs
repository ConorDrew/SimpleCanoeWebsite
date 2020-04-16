// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerRoles.EngineerRoleSql
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerRoles
{
  public class EngineerRoleSql
  {
    private Database _database;

    public EngineerRoleSql(Database database)
    {
      this._database = database;
    }

    public List<EngineerRole> GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("EngineerRole_GetAll", true);
      return table != null && table.Rows.Count > 0 ? ObjectMap.DataTableToList<EngineerRole>(table) : (List<EngineerRole>) null;
    }

    public List<EngineerAssignedToRole> GetEngineersAssignedToRole()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("EngineerRole_GetEngineersAssignedToRole", true);
      return table != null && table.Rows.Count > 0 ? ObjectMap.DataTableToList<EngineerAssignedToRole>(table) : (List<EngineerAssignedToRole>) null;
    }

    public DataView GetLookupData()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("EngineerRole_GetAll", true);
      table.TableName = Enums.TableNames.tblEngineerRole.ToString();
      return new DataView(table);
    }

    public DataView GetEngineersNotAssignedToRole()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("EngineerRole_GetEngineersNotAssignedToRole", true);
      table.TableName = Enums.TableNames.tblEngineerRole.ToString();
      return new DataView(table);
    }

    public EngineerRole Insert(EngineerRole engineerRole)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Name", (object) engineerRole.Name, false);
      this._database.AddParameter("@Description", (object) engineerRole.Description, false);
      this._database.AddParameter("@HourlyCostToCompany", (object) engineerRole.HourlyCostToCompany, false);
      engineerRole.Id = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("EngineerRole_Insert", true)));
      return engineerRole;
    }

    public int Update(EngineerRole engineerRole)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Id", (object) engineerRole.Id, true);
      this._database.AddParameter("@Name", (object) engineerRole.Name, false);
      this._database.AddParameter("@Description", (object) engineerRole.Description, false);
      this._database.AddParameter("@HourlyCostToCompany", (object) engineerRole.HourlyCostToCompany, false);
      return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("EngineerRole_Update", true)));
    }

    public int Delete(int Id)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Id", (object) Id, false);
      return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("EngineerRole_Delete", true)));
    }

    public bool AssignEngineerToRole(int engineerId, int engineerRoleId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerID", (object) engineerId, false);
      this._database.AddParameter("@EngineerRoleId", (object) engineerRoleId, false);
      return this._database.ExecuteSP_ReturnRowsAffected("EngineerRole_AssignEngineer") == 1;
    }

    public EngineerRole GetEngineerRoleId(int engineerId)
    {
      EngineerRole engineerRole = new EngineerRole();
      engineerRole.Id = -1;
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerID", (object) engineerId, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable("EngineerRole_GetEngineerRoleId", true);
      if (!Information.IsNothing((object) dataTable) & dataTable.Rows.Count > 0)
      {
        engineerRole.Id = Conversions.ToInteger(dataTable.Rows[0]["EngineerRoleId"]);
        engineerRole.Name = Conversions.ToString(dataTable.Rows[0]["Name"]);
      }
      return engineerRole;
    }
  }
}
