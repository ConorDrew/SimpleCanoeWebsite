using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitAssetWorkSheets
    {
        // make sure that contact object is valid
        public class EngineerVisitAssetWorkSheetValidatorGSHP : BaseValidator
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
                    AddCriticalMessage("Landlords Appliance Missing");
                }

                if (oEngineerVisitAssetWorkSheet.FlueFlowTestID == default)
                {
                    AddCriticalMessage("Pressure Missing");
                }

                if (oEngineerVisitAssetWorkSheet.SpillageTestID == default)
                {
                    AddCriticalMessage("Operation Missing");
                }

                if (oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID == default)
                {
                    AddCriticalMessage("Safety devices Missing");
                }

                if (oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID == default)
                {
                    AddCriticalMessage("Stability Missing");
                }

                if (oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID == default)
                {
                    AddCriticalMessage("Free air Missing");
                }

                if (oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID == default)
                {
                    AddCriticalMessage("Safety device operation Missing");
                }

                if (oEngineerVisitAssetWorkSheet.SweepOutcomeID == default)
                {
                    AddCriticalMessage("Legionella Missing");
                }

                if (oEngineerVisitAssetWorkSheet.OverallID == default)
                {
                    AddCriticalMessage("Overall condition Missing");
                }

                if (oEngineerVisitAssetWorkSheet.DischargeID == default)
                {
                    AddCriticalMessage("Glycol Missing");
                }

                if (oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID == default)
                {
                    AddCriticalMessage("Appliance service Missing");
                }

                if (oEngineerVisitAssetWorkSheet.ApplianceSafeID == default)
                {
                    AddCriticalMessage("Appliance Safety Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}