using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitAssetWorkSheets
    {
        // make sure that contact object is valid
        public class EngineerVisitAssetWorkSheetValidatorHIU : BaseValidator
        {
            public void Validate(EngineerVisitAssetWorkSheet oEngineerVisitAssetWorkSheet)
            {
                // make sure that contact object is valid
                if (oEngineerVisitAssetWorkSheet.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oEngineerVisitAssetWorkSheet.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oEngineerVisitAssetWorkSheet.AssetID == default)
                {
                    AddCriticalMessage("Appliance Missing");
                }

                if (oEngineerVisitAssetWorkSheet.LandlordsApplianceID == default)
                {
                    AddCriticalMessage("Landlord Appliance Missing");
                }

                if (oEngineerVisitAssetWorkSheet.FlueFlowTestID == default)
                {
                    AddCriticalMessage("Check for leaks Missing");
                }

                if (oEngineerVisitAssetWorkSheet.SpillageTestID == default)
                {
                    AddCriticalMessage("Port valves Missing");
                }

                if (oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID == default)
                {
                    AddCriticalMessage("Strainers Missing");
                }

                if (oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID == default)
                {
                    AddCriticalMessage("Pumps Missing");
                }

                if (oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID == default)
                {
                    AddCriticalMessage("System operation Missing");
                }

                if (oEngineerVisitAssetWorkSheet.Nozzle == default)
                {
                    AddCriticalMessage("Recorded results Missing");
                }

                if (oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID == default)
                {
                    AddCriticalMessage("Appliance service Missing");
                }

                if (oEngineerVisitAssetWorkSheet.ApplianceSafeID == default)
                {
                    AddCriticalMessage("Appliance safety Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}