// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetVanFaultSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.FleetVans
{
  public class FleetVanFaultSQL
  {
    private Database _database;

    public FleetVanFaultSQL(Database database)
    {
      this._database = database;
    }

    private void AddParametersToCommand(ref FleetVanFault oFleetVan)
    {
      Database database = this._database;
      database.AddParameter("@VanID", (object) oFleetVan.VanID, true);
      database.AddParameter("@FaultTypeID", (object) oFleetVan.FaultTypeID, true);
      database.AddParameter("@FaultDate", (object) oFleetVan.FaultDate, true);
      if ((uint) DateTime.Compare(oFleetVan.ResolvedDate, DateTime.MinValue) > 0U)
        database.AddParameter("@ResolvedDate", (object) oFleetVan.ResolvedDate, true);
      database.AddParameter("@EngineerNotes", (object) oFleetVan.EngineerNotes, true);
      database.AddParameter("@Notes", (object) oFleetVan.Notes, true);
      database.AddParameter("@JobID", (object) oFleetVan.JobID, true);
      database.AddParameter("@UserID", (object) App.loggedInUser.UserID, true);
      database.AddParameter("@Archive", (object) oFleetVan.Archive, true);
    }

    public DataView GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("FleetVanFault_GetAll", true);
      table.TableName = Enums.TableNames.tblFleetVanMaintenance.ToString();
      return new DataView(table);
    }

    public DataView GetAll_Trans(string where)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Where", (object) where, true);
      DataTable table = this._database.ExecuteSP_DataTable("FleetVanFault_GetAll_Trans", true);
      table.TableName = Enums.TableNames.tblFleetVanMaintenance.ToString();
      return new DataView(table);
    }

    public DataView GetAll_Unresolved()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("FleetVanFault_GetAll_Unresolved", true);
      table.TableName = Enums.TableNames.tblFleetVanMaintenance.ToString();
      return new DataView(table);
    }

    public DataView GetAll_Unresolved_WithNoJob()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("FleetVanFault_GetAll_Unresolved_WithNoJob", true);
      table.TableName = Enums.TableNames.tblFleetVanMaintenance.ToString();
      return new DataView(table);
    }

    public DataView GetAll_ByVanID(int vanID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@VanID", (object) vanID, false);
      DataTable table = this._database.ExecuteSP_DataTable("FleetVanFault_GetAll_ForVan", true);
      table.TableName = Enums.TableNames.tblFleetVanMaintenance.ToString();
      return new DataView(table);
    }

    public FleetVanFault Get(int vanFaultID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@VanFaultID", (object) vanFaultID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable("FleetVanFault_Get", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (FleetVanFault) null;
      FleetVanFault fleetVanFault1 = new FleetVanFault();
      FleetVanFault fleetVanFault2 = fleetVanFault1;
      fleetVanFault2.IgnoreExceptionsOnSetMethods = true;
      fleetVanFault2.SetVanFaultID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanFaultID"]);
      fleetVanFault2.SetVanID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanID"]);
      fleetVanFault2.SetFaultTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FaultType"]);
      fleetVanFault2.FaultDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FaultDate"]));
      if (dataTable.Rows[0]["ResolvedDate"] != DBNull.Value)
        fleetVanFault2.ResolvedDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ResolvedDate"]));
      fleetVanFault2.SetEngineerNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerNotes"]);
      fleetVanFault2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
      fleetVanFault2.SetJobID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobID"]);
      fleetVanFault2.SetArchive = Conversions.ToBoolean(dataTable.Rows[0]["Archive"]);
      fleetVanFault1.Exists = true;
      return fleetVanFault1;
    }

    public FleetVanFault Get_ByVanID(int vanID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@VanID", (object) vanID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable("FleetVanFault_Get_ForVan", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (FleetVanFault) null;
      FleetVanFault fleetVanFault1 = new FleetVanFault();
      FleetVanFault fleetVanFault2 = fleetVanFault1;
      fleetVanFault2.IgnoreExceptionsOnSetMethods = true;
      fleetVanFault2.SetVanFaultID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanFaultID"]);
      fleetVanFault2.SetVanID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanID"]);
      fleetVanFault2.SetFaultTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FaultType"]);
      fleetVanFault2.FaultDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FaultDate"]));
      if (dataTable.Rows[0]["ResolvedDate"] != DBNull.Value)
        fleetVanFault2.ResolvedDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ResolvedDate"]));
      fleetVanFault2.SetEngineerNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerNotes"]);
      fleetVanFault2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
      fleetVanFault2.SetJobID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobID"]);
      fleetVanFault2.SetArchive = Conversions.ToBoolean(dataTable.Rows[0]["Archive"]);
      fleetVanFault1.Exists = true;
      return fleetVanFault1;
    }

    public FleetVanFault Get_ByJobID(int jobID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) jobID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable("FleetVanFault_Get_ForJob", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (FleetVanFault) null;
      FleetVanFault fleetVanFault1 = new FleetVanFault();
      FleetVanFault fleetVanFault2 = fleetVanFault1;
      fleetVanFault2.IgnoreExceptionsOnSetMethods = true;
      fleetVanFault2.SetVanFaultID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanFaultID"]);
      fleetVanFault2.SetVanID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanID"]);
      fleetVanFault2.SetFaultTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FaultType"]);
      fleetVanFault2.FaultDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FaultDate"]));
      if (dataTable.Rows[0]["ResolvedDate"] != DBNull.Value)
        fleetVanFault2.ResolvedDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ResolvedDate"]));
      fleetVanFault2.SetEngineerNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerNotes"]);
      fleetVanFault2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
      fleetVanFault2.SetJobID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobID"]);
      fleetVanFault2.SetArchive = Conversions.ToBoolean(dataTable.Rows[0]["Archive"]);
      fleetVanFault1.Exists = true;
      return fleetVanFault1;
    }

    public bool Update(FleetVanFault oVan)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@VanFaultID", (object) oVan.VanFaultID, true);
      this.AddParametersToCommand(ref oVan);
      return Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this._database.ExecuteSP_OBJECT("FleetVanFault_Update", true), (object) 1, false);
    }

    public FleetVanFault Insert(FleetVanFault van)
    {
      this._database.ClearParameter();
      this.AddParametersToCommand(ref van);
      van.SetFaultTypeID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("FleetVanFault_Insert", true)));
      van.Exists = true;
      return van;
    }

    public DataView FaultTypes_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("FleetVanFaultType_GetAll", true);
      table.TableName = Enums.TableNames.tblFleetVanMaintenance.ToString();
      return new DataView(table);
    }
  }
}
