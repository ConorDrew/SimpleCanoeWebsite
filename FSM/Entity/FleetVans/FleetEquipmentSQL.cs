// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetEquipmentSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.FleetVans
{
  public class FleetEquipmentSQL
  {
    private Database _database;

    public FleetEquipmentSQL(Database database)
    {
      this._database = database;
    }

    public DataView GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("FleetEquipment_GetAll", true);
      table.TableName = Enums.TableNames.tblFleetEquipment.ToString();
      return new DataView(table);
    }

    public FleetEquipment Get(int equipmentId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EquipmentID", (object) equipmentId, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable("FleetEquipment_Get", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (FleetEquipment) null;
      FleetEquipment fleetEquipment1 = new FleetEquipment();
      FleetEquipment fleetEquipment2 = fleetEquipment1;
      fleetEquipment2.IgnoreExceptionsOnSetMethods = true;
      fleetEquipment2.SetEquipmentID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EquipmentID"]);
      fleetEquipment2.SetName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Name"]);
      fleetEquipment2.SetDescription = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Description"]);
      fleetEquipment2.SetCost = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Cost"]);
      fleetEquipment1.Exists = true;
      return fleetEquipment1;
    }

    public int GetActiveCount(int equipmentId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EquipmentID", (object) equipmentId, true);
      return Conversions.ToInteger(this._database.SP_ExecuteScalar("FleetEquipment_Get_ActiveCount", true));
    }

    public FleetEquipment Insert(FleetEquipment oEquipment)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Name", (object) oEquipment.Name, true);
      this._database.AddParameter("@Description", (object) oEquipment.Description, true);
      this._database.AddParameter("@Cost", (object) oEquipment.Cost, true);
      oEquipment.SetEquipmentID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("FleetEquipment_Insert", true)));
      oEquipment.Exists = true;
      return oEquipment;
    }

    public bool Update(FleetEquipment oEquipment)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EquipmentID", (object) oEquipment.EquipmentID, true);
      this._database.AddParameter("@Name", (object) oEquipment.Name, true);
      this._database.AddParameter("@Description", (object) oEquipment.Description, true);
      this._database.AddParameter("@Cost", (object) oEquipment.Cost, true);
      return Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this._database.ExecuteSP_OBJECT("FleetEquipment_Update", true), (object) 1, false);
    }

    public bool Delete(int equipmentId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EquipmentID", (object) equipmentId, true);
      return Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this._database.ExecuteSP_OBJECT("FleetEquipment_Delete", true), (object) 1, false);
    }

    public DataView Search(string criteria)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SearchString", (object) criteria, true);
      DataTable table = this._database.ExecuteSP_DataTable("FleetEquipment_Search", true);
      table.TableName = Enums.TableNames.tblFleetEquipment.ToString();
      return new DataView(table);
    }
  }
}
