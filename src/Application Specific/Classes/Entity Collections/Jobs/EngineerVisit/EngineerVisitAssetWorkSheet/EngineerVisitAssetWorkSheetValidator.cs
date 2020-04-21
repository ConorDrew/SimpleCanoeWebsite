using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitAssetWorkSheets
    {
        // make sure that contact object is valid
        public class EngineerVisitAssetWorkSheetValidator : BaseValidator
        {
            public void Validate(EngineerVisitAssetWorkSheet oEngineerVisitAssetWorkSheet, string ApplianceTested)
            {
                // make sure that contact object is valid
                if (oEngineerVisitAssetWorkSheet.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oEngineerVisitAssetWorkSheet.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if ((ApplianceTested ?? "") == "Yes")
                {
                    if (oEngineerVisitAssetWorkSheet.ApplianceSafeID == 0)
                    {
                        AddCriticalMessage("Appliance Safe Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID == 0)
                    {
                        AddCriticalMessage("Appliance Serviced Or Inspected Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.SpillageTestID == 0)
                    {
                        AddCriticalMessage("Flue Spilage Test Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.AssetID == 0)
                    {
                        AddCriticalMessage("Appliance Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.FlueFlowTestID == 0)
                    {
                        AddCriticalMessage("Flue Flow Test Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.CO2 == 0)
                    {
                        AddCriticalMessage("CO2 % Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.CO2CORatio == 0)
                    {
                        AddCriticalMessage("CO2/CO Ratio Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.ColdWaterTemp == 0)
                    {
                        AddCriticalMessage("Cold Water Temp Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.DHWFlowRate == 0)
                    {
                        AddCriticalMessage("DHW Flow Rate Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.DHWTemp == 0)
                    {
                        AddCriticalMessage("DHW Temp Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.FlueFlowTestID == 0)
                    {
                        AddCriticalMessage("Flue Flow Test Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID == 0)
                    {
                        AddCriticalMessage("Flue Termination Satisfactory Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.InletStaticPressure == 0)
                    {
                        AddCriticalMessage("Inlet Static Pressure Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.InletWorkingPressure == 0)
                    {
                        AddCriticalMessage("Inlet Working Pressure Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.LandlordsApplianceID == 0)
                    {
                        AddCriticalMessage("Landlords Appliance Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.MaxBurnerPressure == 0)
                    {
                        AddCriticalMessage("Max Burner Pressure Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.MinBurnerPressure == 0)
                    {
                        AddCriticalMessage("Min Burner Pressure Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.MinBurnerPressure == 0)
                    {
                        AddCriticalMessage("Min Burner Pressure Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID == 0)
                    {
                        AddCriticalMessage("Safety Device Operation Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID == 0)
                    {
                        AddCriticalMessage("Ventilation Provision Satisfactory Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID == 0)
                    {
                        AddCriticalMessage("Visual Condition of Flue Satisfactory Missing");
                    }
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}