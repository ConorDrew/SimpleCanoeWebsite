// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetVanTypeSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.FleetVans
{
  public class FleetVanTypeSQL
  {
    private Database _database;

    public FleetVanTypeSQL(Database database)
    {
      this._database = database;
    }

    private void AddParametersToCommand(ref FleetVanType oFleetVanType)
    {
      Database database = this._database;
      database.AddParameter("@Make", (object) oFleetVanType.Make, true);
      database.AddParameter("@Model", (object) oFleetVanType.Model, true);
      database.AddParameter("@MileageServiceInterval", (object) oFleetVanType.MileageServiceInterval, true);
      database.AddParameter("@DateServiceInterval", (object) oFleetVanType.DateServiceInterval, true);
      database.AddParameter("@GrossVehicleWeight", (object) oFleetVanType.GrossVehicleWeight, true);
      database.AddParameter("@Payload", (object) oFleetVanType.Payload, true);
    }

    public DataView GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("FleetVanType_GetAll", true);
      table.TableName = Enums.TableNames.tblFleetVanType.ToString();
      return new DataView(table);
    }

    public FleetVanType Get(int vanTypeId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@VanTypeID", (object) vanTypeId, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable("FleetVanType_Get", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (FleetVanType) null;
      FleetVanType fleetVanType1 = new FleetVanType();
      FleetVanType fleetVanType2 = fleetVanType1;
      fleetVanType2.IgnoreExceptionsOnSetMethods = true;
      fleetVanType2.SetVanTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanTypeID"]);
      fleetVanType2.SetMake = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Make"]);
      fleetVanType2.SetModel = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Model"]);
      fleetVanType2.SetMileageServiceInterval = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MileageServiceInterval"]);
      fleetVanType2.SetDateServiceInterval = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DateServiceInterval"]);
      if (dataTable.Columns.Contains("GrossVehicleWeight"))
        fleetVanType2.SetGrossVehicleWeight = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["GrossVehicleWeight"]);
      if (dataTable.Columns.Contains("Payload"))
        fleetVanType2.SetPayload = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Payload"]);
      fleetVanType1.Exists = true;
      return fleetVanType1;
    }

    public FleetVanType Insert(FleetVanType vanType)
    {
      this._database.ClearParameter();
      this.AddParametersToCommand(ref vanType);
      vanType.SetVanTypeID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("FleetVanType_Insert", true)));
      vanType.Exists = true;
      return vanType;
    }

    public bool Update(FleetVanType vanType)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@VanTypeID", (object) vanType.VanTypeID, true);
      this.AddParametersToCommand(ref vanType);
      return Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this._database.ExecuteSP_OBJECT("FleetVanType_Update", true), (object) 1, false);
    }

    public bool Delete(int vanTypeID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@VanTypeID", (object) vanTypeID, true);
      return Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this._database.ExecuteSP_OBJECT("FleetVanType_Delete", true), (object) 1, false);
    }

    public DataView Search(string criteria)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SearchString", (object) criteria, true);
      DataTable table = this._database.ExecuteSP_DataTable("FleetVanType_Search", true);
      table.TableName = Enums.TableNames.tblFleetVanType.ToString();
      return new DataView(table);
    }
  }
}
