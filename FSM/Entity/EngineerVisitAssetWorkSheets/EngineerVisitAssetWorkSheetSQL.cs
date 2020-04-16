// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheetSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisitAssetWorkSheets
{
  public class EngineerVisitAssetWorkSheetSQL
  {
    private Database _database;

    public EngineerVisitAssetWorkSheetSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int EngineerVisitAssetWorkSheetID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitAssetWorkSheetID", (object) EngineerVisitAssetWorkSheetID, true);
      this._database.ExecuteSP_NO_Return("EngineerVisitAssetWorkSheet_Delete", true);
    }

    public EngineerVisitAssetWorkSheet EngineerVisitAssetWorkSheet_Get(
      int EngineerVisitAssetWorkSheetID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitAssetWorkSheetID", (object) EngineerVisitAssetWorkSheetID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (EngineerVisitAssetWorkSheet_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (EngineerVisitAssetWorkSheet) null;
      EngineerVisitAssetWorkSheet visitAssetWorkSheet1 = new EngineerVisitAssetWorkSheet();
      EngineerVisitAssetWorkSheet visitAssetWorkSheet2 = visitAssetWorkSheet1;
      visitAssetWorkSheet2.IgnoreExceptionsOnSetMethods = true;
      visitAssetWorkSheet2.SetEngineerVisitAssetWorkSheetID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (EngineerVisitAssetWorkSheetID)]);
      visitAssetWorkSheet2.SetEngineerVisitID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerVisitID"]);
      visitAssetWorkSheet2.SetAssetID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AssetID"]);
      visitAssetWorkSheet2.SetFlueTerminationSatisfactoryID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FlueTerminationSatisfactoryID"]);
      visitAssetWorkSheet2.SetFlueFlowTestID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FlueFlowTestID"]);
      visitAssetWorkSheet2.SetSpillageTestID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SpillageTestID"]);
      visitAssetWorkSheet2.SetVentilationProvisionSatisfactoryID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VentilationProvisionSatisfactoryID"]);
      visitAssetWorkSheet2.SetSafetyDeviceOperationID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SafetyDeviceOperationID"]);
      visitAssetWorkSheet2.SetDHWFlowRate = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DHWFlowRate"]);
      visitAssetWorkSheet2.SetColdWaterTemp = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ColdWaterTemp"]);
      visitAssetWorkSheet2.SetDHWTemp = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DHWTemp"]);
      visitAssetWorkSheet2.SetInletStaticPressure = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InletStaticPressure"]);
      visitAssetWorkSheet2.SetInletWorkingPressure = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InletWorkingPressure"]);
      visitAssetWorkSheet2.SetMinBurnerPressure = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MinBurnerPressure"]);
      visitAssetWorkSheet2.SetMaxBurnerPressure = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MaxBurnerPressure"]);
      visitAssetWorkSheet2.SetCO2 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CO2"]);
      visitAssetWorkSheet2.SetCO2CORatio = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CO2CORatio"]);
      visitAssetWorkSheet2.SetLandlordsApplianceID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LandlordsApplianceID"]);
      visitAssetWorkSheet2.SetApplianceServiceOrInspectedID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ApplianceServiceOrInspectedID"]);
      visitAssetWorkSheet2.SetApplianceTestedID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ApplianceTestedID"]);
      visitAssetWorkSheet2.SetApplianceSafeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ApplianceSafeID"]);
      visitAssetWorkSheet2.SetVisualConditionOfFlueSatisfactoryID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VisualConditionOfFlueSatisfactoryID"]);
      visitAssetWorkSheet2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      visitAssetWorkSheet2.SetNozzle = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Nozzle"]);
      visitAssetWorkSheet2.SetReading = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ReadingType"]);
      visitAssetWorkSheet2.SetTankID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TankID"]);
      visitAssetWorkSheet2.SetBMake = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["BurMake"]);
      visitAssetWorkSheet2.SetBModel = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["BurModel"]);
      visitAssetWorkSheet2.SetSweepOutcomeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SweepOutcomeID"]);
      visitAssetWorkSheet2.SetOverallID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OverallID"]);
      visitAssetWorkSheet2.SetDischargeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DischargeID"]);
      visitAssetWorkSheet1.Exists = true;
      return visitAssetWorkSheet1;
    }

    public DataView EngineerVisitAssetWorkSheet_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (EngineerVisitAssetWorkSheet_GetAll), true);
      table.TableName = Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString();
      return new DataView(table);
    }

    public DataView EngineerVisitAssetWorkSheet_GetForVisit(int EngineerVisitID, int Oil = -1)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) EngineerVisitID, true);
      this._database.AddParameter("@Fuel", (object) Oil, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (EngineerVisitAssetWorkSheet_GetForVisit), true);
      table.TableName = Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString();
      return new DataView(table);
    }

    public DataView Get_Friendly(int engineerVisitAssetWorkSheetId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitAssetWorkSheetID", (object) engineerVisitAssetWorkSheetId, true);
      DataTable table = this._database.ExecuteSP_DataTable("EngineerVisitAssetWorkSheet_Get_Friendly", true);
      table.TableName = Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString();
      return new DataView(table);
    }

    public EngineerVisitAssetWorkSheet Insert(
      EngineerVisitAssetWorkSheet oEngineerVisitAssetWorkSheet)
    {
      this._database.ClearParameter();
      this.AddEngineerVisitAssetWorkSheetParametersToCommand(ref oEngineerVisitAssetWorkSheet);
      oEngineerVisitAssetWorkSheet.SetEngineerVisitAssetWorkSheetID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("EngineerVisitAssetWorkSheet_Insert", true)));
      oEngineerVisitAssetWorkSheet.Exists = true;
      return oEngineerVisitAssetWorkSheet;
    }

    public DataView EngineerVisitAssetWorkSheet_Search(string criteria)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Criteria", (object) criteria, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (EngineerVisitAssetWorkSheet_Search), true);
      table.TableName = Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString();
      return new DataView(table);
    }

    public void Update(
      EngineerVisitAssetWorkSheet oEngineerVisitAssetWorkSheet)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitAssetWorkSheetID", (object) oEngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheetID, true);
      this.AddEngineerVisitAssetWorkSheetParametersToCommand(ref oEngineerVisitAssetWorkSheet);
      this._database.ExecuteSP_NO_Return("EngineerVisitAssetWorkSheet_Update", true);
    }

    private void AddEngineerVisitAssetWorkSheetParametersToCommand(
      ref EngineerVisitAssetWorkSheet oEngineerVisitAssetWorkSheet)
    {
      Database database = this._database;
      database.AddParameter("@EngineerVisitID", (object) oEngineerVisitAssetWorkSheet.EngineerVisitID, true);
      database.AddParameter("@AssetID", (object) oEngineerVisitAssetWorkSheet.AssetID, true);
      database.AddParameter("@FlueTerminationSatisfactoryID", (object) oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID, true);
      database.AddParameter("@FlueFlowTestID", (object) oEngineerVisitAssetWorkSheet.FlueFlowTestID, true);
      database.AddParameter("@SpillageTestID", (object) oEngineerVisitAssetWorkSheet.SpillageTestID, true);
      database.AddParameter("@VentilationProvisionSatisfactoryID", (object) oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID, true);
      database.AddParameter("@SafetyDeviceOperationID", (object) oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID, true);
      database.AddParameter("@DHWFlowRate", (object) oEngineerVisitAssetWorkSheet.DHWFlowRate, true);
      database.AddParameter("@ColdWaterTemp", (object) oEngineerVisitAssetWorkSheet.ColdWaterTemp, true);
      database.AddParameter("@DHWTemp", (object) oEngineerVisitAssetWorkSheet.DHWTemp, true);
      database.AddParameter("@InletStaticPressure", (object) oEngineerVisitAssetWorkSheet.InletStaticPressure, true);
      database.AddParameter("@InletWorkingPressure", (object) oEngineerVisitAssetWorkSheet.InletWorkingPressure, true);
      database.AddParameter("@MinBurnerPressure", (object) oEngineerVisitAssetWorkSheet.MinBurnerPressure, true);
      database.AddParameter("@MaxBurnerPressure", (object) oEngineerVisitAssetWorkSheet.MaxBurnerPressure, true);
      database.AddParameter("@CO2", (object) oEngineerVisitAssetWorkSheet.CO2, true);
      database.AddParameter("@CO2CORatio", (object) oEngineerVisitAssetWorkSheet.CO2CORatio, true);
      database.AddParameter("@LandlordsApplianceID", (object) oEngineerVisitAssetWorkSheet.LandlordsApplianceID, true);
      database.AddParameter("@ApplianceServiceOrInspectedID", (object) oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID, true);
      database.AddParameter("@ApplianceSafeID", (object) oEngineerVisitAssetWorkSheet.ApplianceSafeID, true);
      database.AddParameter("@VisualConditionOfFlueSatisfactoryID", (object) oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID, true);
      database.AddParameter("@ApplianceTestedID", (object) oEngineerVisitAssetWorkSheet.ApplianceTestedID, true);
      database.AddParameter("@TankID", (object) oEngineerVisitAssetWorkSheet.TankID, true);
      database.AddParameter("@ReadingType", (object) oEngineerVisitAssetWorkSheet.Reading, true);
      database.AddParameter("@Nozzle", (object) oEngineerVisitAssetWorkSheet.Nozzle, true);
      database.AddParameter("@BurMake", (object) oEngineerVisitAssetWorkSheet.BMake, true);
      database.AddParameter("@BurModel", (object) oEngineerVisitAssetWorkSheet.BModel, true);
      database.AddParameter("@Sweep", (object) oEngineerVisitAssetWorkSheet.SweepOutcomeID, true);
      database.AddParameter("@Overall", (object) oEngineerVisitAssetWorkSheet.OverallID, true);
      database.AddParameter("@Discharge", (object) oEngineerVisitAssetWorkSheet.DischargeID, true);
    }

    public DataView Products_LastGSRDone(
      DateTime dateFrom,
      DateTime dateTo,
      int regionId,
      int customerId = 0,
      int onContract = 0,
      bool tenantsAppliance = false,
      bool printed = false)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@DateFrom", (object) dateFrom, true);
      this._database.AddParameter("@DateTo", (object) dateTo, true);
      this._database.AddParameter("@CustomerID", (object) customerId, true);
      if (regionId > 0)
        this._database.AddParameter("@RegionID", (object) regionId, true);
      if (onContract > 0)
      {
        if (onContract == 1)
          this._database.AddParameter("@OnContract", (object) true, true);
        if (onContract == 2)
          this._database.AddParameter("@OnContract", (object) false, true);
      }
      this._database.AddParameter("@TenantsAppliance", (object) tenantsAppliance, true);
      this._database.AddParameter("@Printed", (object) printed, true);
      DataTable table = this._database.ExecuteSP_DataTable("Products_LastGSRDone_New", true);
      table.TableName = Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString();
      return new DataView(table);
    }

    public void PrintedGSRLettersInsert(int AssetID, DateTime DateDue, bool otherContact = false)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@AssetID", (object) AssetID, true);
      this._database.AddParameter("@DateDue", (object) DateDue, true);
      this._database.AddParameter("PrintedDate", (object) DateAndTime.Now, true);
      if (otherContact)
        this._database.AddParameter("OtherContact", (object) true, true);
      this._database.ExecuteSP_NO_Return(nameof (PrintedGSRLettersInsert), true);
    }
  }
}
