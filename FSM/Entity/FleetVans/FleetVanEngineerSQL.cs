// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetVanEngineerSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FSM.Entity.FleetVans
{
  public class FleetVanEngineerSQL
  {
    private Database _database;

    public FleetVanEngineerSQL(Database database)
    {
      this._database = database;
    }

    private void AddParametersToCommand(ref FleetVanEngineer oFleetVan)
    {
      Database database = this._database;
      database.AddParameter("@VanID", (object) oFleetVan.VanID, true);
      database.AddParameter("@EngineerID", (object) oFleetVan.EngineerID, true);
      database.AddParameter("@StartDateTime", (object) oFleetVan.StartDate, true);
      database.AddParameter("@EndDateTime", RuntimeHelpers.GetObjectValue(Interaction.IIf((uint) DateTime.Compare(oFleetVan.EndDate, DateTime.MinValue) > 0U, (object) oFleetVan.EndDate, (object) DBNull.Value)), true);
    }

    public DataView GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("FleetVanEngineer_GetAll", true);
      table.TableName = Enums.TableNames.tblFleetVanType.ToString();
      return new DataView(table);
    }

    public DataView GetAll_ByVanID(int vanID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@VanID", (object) vanID, false);
      DataTable table = this._database.ExecuteSP_DataTable("FleetVanEngineer_GetAll_ForVan", true);
      table.TableName = Enums.TableNames.tblFleetVanMaintenance.ToString();
      return new DataView(table);
    }

    public DataView GetAll_ByEngineerID(int engineerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerID", (object) engineerID, false);
      DataTable table = this._database.ExecuteSP_DataTable("FleetVanEngineer_Get_EngineerID", true);
      table.TableName = Enums.TableNames.tblFleetVanMaintenance.ToString();
      return new DataView(table);
    }

    public DataView GetAll_Trans(string where)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Where", (object) where, true);
      DataTable table = this._database.ExecuteSP_DataTable("FleetVanEngineer_GetAll_Trans", true);
      table.TableName = Enums.TableNames.tblFleetVanMaintenance.ToString();
      return new DataView(table);
    }

    public FleetVanEngineer Get(int vanEngineerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@VanEngineerID", (object) vanEngineerID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable("FleetVanEngineer_Get", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (FleetVanEngineer) null;
      FleetVanEngineer fleetVanEngineer1 = new FleetVanEngineer();
      FleetVanEngineer fleetVanEngineer2 = fleetVanEngineer1;
      fleetVanEngineer2.IgnoreExceptionsOnSetMethods = true;
      fleetVanEngineer2.SetVanEngineerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanEngineerID"]);
      fleetVanEngineer2.SetVanID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanID"]);
      fleetVanEngineer2.SetEngineerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerID"]);
      fleetVanEngineer2.StartDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StartDateTime"]));
      fleetVanEngineer2.EndDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EndDateTime"]));
      fleetVanEngineer1.Exists = true;
      return fleetVanEngineer1;
    }

    public FleetVanEngineer Get_ByVanID(int vanID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@VanID", (object) vanID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable("FleetVanEngineer_Get_VanID", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (FleetVanEngineer) null;
      FleetVanEngineer fleetVanEngineer1 = new FleetVanEngineer();
      FleetVanEngineer fleetVanEngineer2 = fleetVanEngineer1;
      fleetVanEngineer2.IgnoreExceptionsOnSetMethods = true;
      fleetVanEngineer2.SetVanEngineerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanEngineerID"]);
      fleetVanEngineer2.SetVanID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanID"]);
      fleetVanEngineer2.SetEngineerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerID"]);
      fleetVanEngineer2.StartDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StartDateTime"]));
      fleetVanEngineer2.EndDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EndDateTime"]));
      fleetVanEngineer1.Exists = true;
      return fleetVanEngineer1;
    }

    public bool Update(FleetVanEngineer oVan)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@VanEngineerID", (object) oVan.VanEngineerID, true);
      this.AddParametersToCommand(ref oVan);
      return Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this._database.ExecuteSP_OBJECT("FleetVanEngineer_Update", true), (object) 1, false);
    }

    public FleetVanEngineer Insert(FleetVanEngineer van)
    {
      this._database.ClearParameter();
      this.AddParametersToCommand(ref van);
      van.SetVanEngineerID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("FleetVanEngineer_Insert", true)));
      van.Exists = true;
      return van;
    }

    public bool Delete(int oVanEngineerID, [DateTimeConstant(0), Optional] DateTime endDate)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@VanEngineerID", (object) oVanEngineerID, true);
      if ((uint) DateTime.Compare(endDate, DateTime.MinValue) > 0U)
        this._database.AddParameter("@EndDate", (object) endDate, true);
      return Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this._database.ExecuteSP_OBJECT("FleetVanEngineer_Delete", true), (object) 1, false);
    }
  }
}
