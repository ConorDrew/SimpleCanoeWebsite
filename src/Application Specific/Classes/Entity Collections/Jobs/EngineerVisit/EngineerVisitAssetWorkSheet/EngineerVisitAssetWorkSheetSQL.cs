using System;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitAssetWorkSheets
    {
        public class EngineerVisitAssetWorkSheetSQL
        {
            private Sys.Database _database;

            public EngineerVisitAssetWorkSheetSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public void Delete(int EngineerVisitAssetWorkSheetID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitAssetWorkSheetID", EngineerVisitAssetWorkSheetID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitAssetWorkSheet_Delete");
            }

            public EngineerVisitAssetWorkSheet EngineerVisitAssetWorkSheet_Get(int EngineerVisitAssetWorkSheetID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitAssetWorkSheetID", EngineerVisitAssetWorkSheetID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("EngineerVisitAssetWorkSheet_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oEngineerVisitAssetWorkSheet = new EngineerVisitAssetWorkSheet();
                        oEngineerVisitAssetWorkSheet.IgnoreExceptionsOnSetMethods = true;
                        oEngineerVisitAssetWorkSheet.SetEngineerVisitAssetWorkSheetID = dt.Rows[0]["EngineerVisitAssetWorkSheetID"];
                        oEngineerVisitAssetWorkSheet.SetEngineerVisitID = dt.Rows[0]["EngineerVisitID"];
                        oEngineerVisitAssetWorkSheet.SetAssetID = dt.Rows[0]["AssetID"];
                        oEngineerVisitAssetWorkSheet.SetFlueTerminationSatisfactoryID = dt.Rows[0]["FlueTerminationSatisfactoryID"];
                        oEngineerVisitAssetWorkSheet.SetFlueFlowTestID = dt.Rows[0]["FlueFlowTestID"];
                        oEngineerVisitAssetWorkSheet.SetSpillageTestID = dt.Rows[0]["SpillageTestID"];
                        oEngineerVisitAssetWorkSheet.SetVentilationProvisionSatisfactoryID = dt.Rows[0]["VentilationProvisionSatisfactoryID"];
                        oEngineerVisitAssetWorkSheet.SetSafetyDeviceOperationID = dt.Rows[0]["SafetyDeviceOperationID"];
                        oEngineerVisitAssetWorkSheet.SetDHWFlowRate = dt.Rows[0]["DHWFlowRate"];
                        oEngineerVisitAssetWorkSheet.SetColdWaterTemp = dt.Rows[0]["ColdWaterTemp"];
                        oEngineerVisitAssetWorkSheet.SetDHWTemp = dt.Rows[0]["DHWTemp"];
                        oEngineerVisitAssetWorkSheet.SetInletStaticPressure = dt.Rows[0]["InletStaticPressure"];
                        oEngineerVisitAssetWorkSheet.SetInletWorkingPressure = dt.Rows[0]["InletWorkingPressure"];
                        oEngineerVisitAssetWorkSheet.SetMinBurnerPressure = dt.Rows[0]["MinBurnerPressure"];
                        oEngineerVisitAssetWorkSheet.SetMaxBurnerPressure = dt.Rows[0]["MaxBurnerPressure"];
                        oEngineerVisitAssetWorkSheet.SetCO2 = dt.Rows[0]["CO2"];
                        oEngineerVisitAssetWorkSheet.SetCO2CORatio = dt.Rows[0]["CO2CORatio"];
                        oEngineerVisitAssetWorkSheet.SetLandlordsApplianceID = dt.Rows[0]["LandlordsApplianceID"];
                        oEngineerVisitAssetWorkSheet.SetApplianceServiceOrInspectedID = dt.Rows[0]["ApplianceServiceOrInspectedID"];
                        oEngineerVisitAssetWorkSheet.SetApplianceTestedID = dt.Rows[0]["ApplianceTestedID"];
                        oEngineerVisitAssetWorkSheet.SetApplianceSafeID = dt.Rows[0]["ApplianceSafeID"];
                        oEngineerVisitAssetWorkSheet.SetVisualConditionOfFlueSatisfactoryID = dt.Rows[0]["VisualConditionOfFlueSatisfactoryID"];
                        oEngineerVisitAssetWorkSheet.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oEngineerVisitAssetWorkSheet.SetNozzle = dt.Rows[0]["Nozzle"];
                        oEngineerVisitAssetWorkSheet.SetReading = dt.Rows[0]["ReadingType"];
                        oEngineerVisitAssetWorkSheet.SetTankID = dt.Rows[0]["TankID"];
                        oEngineerVisitAssetWorkSheet.SetBMake = dt.Rows[0]["BurMake"];
                        oEngineerVisitAssetWorkSheet.SetBModel = dt.Rows[0]["BurModel"];
                        oEngineerVisitAssetWorkSheet.SetSweepOutcomeID = dt.Rows[0]["SweepOutcomeID"];
                        oEngineerVisitAssetWorkSheet.SetOverallID = dt.Rows[0]["OverallID"];
                        oEngineerVisitAssetWorkSheet.SetDischargeID = dt.Rows[0]["DischargeID"];
                        oEngineerVisitAssetWorkSheet.Exists = true;
                        return oEngineerVisitAssetWorkSheet;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            public DataView EngineerVisitAssetWorkSheet_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("EngineerVisitAssetWorkSheet_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisitAssetWorkSheet_GetForVisit(int EngineerVisitID, int Oil = -1)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.AddParameter("@Fuel", Oil, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitAssetWorkSheet_GetForVisit");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString();
                return new DataView(dt);
            }

            public DataView Get_Friendly(int engineerVisitAssetWorkSheetId)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitAssetWorkSheetID", engineerVisitAssetWorkSheetId, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitAssetWorkSheet_Get_Friendly");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString();
                return new DataView(dt);
            }

            public EngineerVisitAssetWorkSheet Insert(EngineerVisitAssetWorkSheet oEngineerVisitAssetWorkSheet)
            {
                _database.ClearParameter();
                AddEngineerVisitAssetWorkSheetParametersToCommand(ref oEngineerVisitAssetWorkSheet);
                oEngineerVisitAssetWorkSheet.SetEngineerVisitAssetWorkSheetID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitAssetWorkSheet_Insert"));
                oEngineerVisitAssetWorkSheet.Exists = true;
                return oEngineerVisitAssetWorkSheet;
            }

            public DataView EngineerVisitAssetWorkSheet_Search(string criteria)
            {
                _database.ClearParameter();
                _database.AddParameter("@Criteria", criteria, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitAssetWorkSheet_Search");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString();
                return new DataView(dt);
            }

            public void Update(EngineerVisitAssetWorkSheet oEngineerVisitAssetWorkSheet)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitAssetWorkSheetID", oEngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheetID, true);
                AddEngineerVisitAssetWorkSheetParametersToCommand(ref oEngineerVisitAssetWorkSheet);
                _database.ExecuteSP_NO_Return("EngineerVisitAssetWorkSheet_Update");
            }

            private void AddEngineerVisitAssetWorkSheetParametersToCommand(ref EngineerVisitAssetWorkSheet oEngineerVisitAssetWorkSheet)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@EngineerVisitID", oEngineerVisitAssetWorkSheet.EngineerVisitID, true);
                    withBlock.AddParameter("@AssetID", oEngineerVisitAssetWorkSheet.AssetID, true);
                    withBlock.AddParameter("@FlueTerminationSatisfactoryID", oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID, true);
                    withBlock.AddParameter("@FlueFlowTestID", oEngineerVisitAssetWorkSheet.FlueFlowTestID, true);
                    withBlock.AddParameter("@SpillageTestID", oEngineerVisitAssetWorkSheet.SpillageTestID, true);
                    withBlock.AddParameter("@VentilationProvisionSatisfactoryID", oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID, true);
                    withBlock.AddParameter("@SafetyDeviceOperationID", oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID, true);
                    withBlock.AddParameter("@DHWFlowRate", oEngineerVisitAssetWorkSheet.DHWFlowRate, true);
                    withBlock.AddParameter("@ColdWaterTemp", oEngineerVisitAssetWorkSheet.ColdWaterTemp, true);
                    withBlock.AddParameter("@DHWTemp", oEngineerVisitAssetWorkSheet.DHWTemp, true);
                    withBlock.AddParameter("@InletStaticPressure", oEngineerVisitAssetWorkSheet.InletStaticPressure, true);
                    withBlock.AddParameter("@InletWorkingPressure", oEngineerVisitAssetWorkSheet.InletWorkingPressure, true);
                    withBlock.AddParameter("@MinBurnerPressure", oEngineerVisitAssetWorkSheet.MinBurnerPressure, true);
                    withBlock.AddParameter("@MaxBurnerPressure", oEngineerVisitAssetWorkSheet.MaxBurnerPressure, true);
                    withBlock.AddParameter("@CO2", oEngineerVisitAssetWorkSheet.CO2, true);
                    withBlock.AddParameter("@CO2CORatio", oEngineerVisitAssetWorkSheet.CO2CORatio, true);
                    withBlock.AddParameter("@LandlordsApplianceID", oEngineerVisitAssetWorkSheet.LandlordsApplianceID, true);
                    withBlock.AddParameter("@ApplianceServiceOrInspectedID", oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID, true);
                    withBlock.AddParameter("@ApplianceSafeID", oEngineerVisitAssetWorkSheet.ApplianceSafeID, true);
                    withBlock.AddParameter("@VisualConditionOfFlueSatisfactoryID", oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID, true);
                    withBlock.AddParameter("@ApplianceTestedID", oEngineerVisitAssetWorkSheet.ApplianceTestedID, true);
                    withBlock.AddParameter("@TankID", oEngineerVisitAssetWorkSheet.TankID, true);
                    withBlock.AddParameter("@ReadingType", oEngineerVisitAssetWorkSheet.Reading, true);
                    withBlock.AddParameter("@Nozzle", oEngineerVisitAssetWorkSheet.Nozzle, true);
                    withBlock.AddParameter("@BurMake", oEngineerVisitAssetWorkSheet.BMake, true);
                    withBlock.AddParameter("@BurModel", oEngineerVisitAssetWorkSheet.BModel, true);
                    withBlock.AddParameter("@Sweep", oEngineerVisitAssetWorkSheet.SweepOutcomeID, true);
                    withBlock.AddParameter("@Overall", oEngineerVisitAssetWorkSheet.OverallID, true);
                    withBlock.AddParameter("@Discharge", oEngineerVisitAssetWorkSheet.DischargeID, true);
                }
            }

            public DataView Products_LastGSRDone(DateTime dateFrom, DateTime dateTo, int regionId, int customerId = 0, int onContract = 0, bool tenantsAppliance = false, bool printed = false)
            {
                _database.ClearParameter();
                _database.AddParameter("@DateFrom", dateFrom, true);
                _database.AddParameter("@DateTo", dateTo, true);
                _database.AddParameter("@CustomerID", customerId, true);
                if (regionId > 0)
                    _database.AddParameter("@RegionID", regionId, true);
                if (onContract > 0)
                {
                    if (onContract == 1)
                    {
                        _database.AddParameter("@OnContract", true, true);
                    }

                    if (onContract == 2)
                    {
                        _database.AddParameter("@OnContract", false, true);
                    }
                }

                _database.AddParameter("@TenantsAppliance", tenantsAppliance, true);
                _database.AddParameter("@Printed", printed, true);
                var dt = _database.ExecuteSP_DataTable("Products_LastGSRDone_New");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString();
                return new DataView(dt);
            }

            public void PrintedGSRLettersInsert(int AssetID, DateTime DateDue, bool otherContact = false)
            {
                _database.ClearParameter();
                _database.AddParameter("@AssetID", AssetID, true);
                _database.AddParameter("@DateDue", DateDue, true);
                _database.AddParameter("PrintedDate", DateAndTime.Now, true);
                if (otherContact)
                {
                    _database.AddParameter("OtherContact", true, true);
                }

                _database.ExecuteSP_NO_Return("PrintedGSRLettersInsert");
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}