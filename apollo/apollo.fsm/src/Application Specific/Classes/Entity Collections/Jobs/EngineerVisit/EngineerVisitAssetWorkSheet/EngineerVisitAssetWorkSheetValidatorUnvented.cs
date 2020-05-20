using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitAssetWorkSheets
    {
        // make sure that contact object is valid
        public class EngineerVisitAssetWorkSheetValidatorUnvented : BaseValidator
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
                    AddCriticalMessage("Appliance Safe Missing");
                }

                if (oEngineerVisitAssetWorkSheet.LandlordsApplianceID == default)
                {
                    AddCriticalMessage("Water pressure Missing");
                }

                if (oEngineerVisitAssetWorkSheet.FlueFlowTestID == default)
                {
                    AddCriticalMessage("Cylinder integrity Missing");
                }

                if (oEngineerVisitAssetWorkSheet.SpillageTestID == default)
                {
                    AddCriticalMessage("Pre-Charge pressure Missing");
                }

                if (oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID == default)
                {
                    AddCriticalMessage("Filter/Strainer check  Missing");
                }

                if (oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID == default)
                {
                    AddCriticalMessage("Sacrificial anode check Missing");
                }

                if (oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID == default)
                {
                    AddCriticalMessage("Expansion Gap check  Missing");
                }

                if (oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID == default)
                {
                    AddCriticalMessage("Tundish check Missing");
                }

                if (oEngineerVisitAssetWorkSheet.SweepOutcomeID == default)
                {
                    AddCriticalMessage("Connection check Missing");
                }

                if (oEngineerVisitAssetWorkSheet.OverallID == default)
                {
                    AddCriticalMessage("Discharge pipe checks Missing");
                }

                if (oEngineerVisitAssetWorkSheet.DischargeID == default)
                {
                    AddCriticalMessage("temp/ pressure relief value Missing");
                }

                if (oEngineerVisitAssetWorkSheet.TankID == default)
                {
                    AddCriticalMessage("expansion value check Missing");
                }

                if (oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID == default)
                {
                    AddCriticalMessage("water pressure / flow rates check  Missing");
                }

                if (oEngineerVisitAssetWorkSheet.ApplianceSafeID == default)
                {
                    AddCriticalMessage("Service record  Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}