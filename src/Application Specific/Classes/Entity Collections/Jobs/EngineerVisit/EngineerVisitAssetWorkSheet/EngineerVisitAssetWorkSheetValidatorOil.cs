using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitAssetWorkSheets
    {
        // make sure that contact object is valid
        public class EngineerVisitAssetWorkSheetValidatorOil : BaseValidator
        {
            public void Validate(EngineerVisitAssetWorkSheet oEngineerVisitAssetWorkSheet, string ApplianceTested)
            {

                // make sure that contact object is valid
                if (oEngineerVisitAssetWorkSheet.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oEngineerVisitAssetWorkSheet.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if ((ApplianceTested ?? "") != "No")
                {
                    if (oEngineerVisitAssetWorkSheet.AssetID == default)
                    {
                        AddCriticalMessage("Appliance Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.LandlordsApplianceID == default)
                    {
                        AddCriticalMessage("Landlord appliance Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.ApplianceTestedID == default)
                    {
                        AddCriticalMessage("Apliance tested Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.FlueFlowTestID == default)
                    {
                        AddCriticalMessage("Chimney/Flue Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.SpillageTestID == default)
                    {
                        AddCriticalMessage("Burner satisfactory Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID == default)
                    {
                        AddCriticalMessage("Oil storage Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID == default)
                    {
                        AddCriticalMessage("Oil supply Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID == default)
                    {
                        AddCriticalMessage("Air supply Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID == default)
                    {
                        AddCriticalMessage("Safety device Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.TankID == default)
                    {
                        AddCriticalMessage("Tank type Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID == default)
                    {
                        AddCriticalMessage("Appliance service Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.ApplianceSafeID == default)
                    {
                        AddCriticalMessage("Appliance safety Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.Nozzle == default)
                    {
                        AddCriticalMessage("Nozzle size Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.BMake == default)
                    {
                        AddCriticalMessage("CO2 Min Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.BModel == default)
                    {
                        AddCriticalMessage("CO2 Max Missing");
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