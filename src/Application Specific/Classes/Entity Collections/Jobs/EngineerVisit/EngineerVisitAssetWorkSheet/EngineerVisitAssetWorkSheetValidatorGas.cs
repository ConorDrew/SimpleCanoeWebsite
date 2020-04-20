using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitAssetWorkSheets
    {
        // make sure that contact object is valid
        public class EngineerVisitAssetWorkSheetValidatorGas : BaseValidator
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
                    if (oEngineerVisitAssetWorkSheet.ApplianceSafeID == default)
                    {
                        AddCriticalMessage("Appliance Safe Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID == default)
                    {
                        AddCriticalMessage("Appliance Serviced Or Inspected Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.SpillageTestID == default)
                    {
                        AddCriticalMessage("Flue Spilage Test Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.AssetID == default)
                    {
                        AddCriticalMessage("Appliance Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.FlueFlowTestID == default)
                    {
                        AddCriticalMessage("Flue Flow Test Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.FlueFlowTestID == default)
                    {
                        AddCriticalMessage("Flue Flow Test Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID == default)
                    {
                        AddCriticalMessage("Flue Termination Satisfactory Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.LandlordsApplianceID == default)
                    {
                        AddCriticalMessage("Landlords Appliance Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID == default)
                    {
                        AddCriticalMessage("Safety Device Operation Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID == default)
                    {
                        AddCriticalMessage("Ventilation Provision Satisfactory Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID == default)
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