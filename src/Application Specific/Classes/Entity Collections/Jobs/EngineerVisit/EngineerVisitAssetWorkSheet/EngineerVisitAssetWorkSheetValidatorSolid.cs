using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitAssetWorkSheets
    {
        // make sure that contact object is valid
        public class EngineerVisitAssetWorkSheetValidatorSolid : BaseValidator
        {
            public void Validate(EngineerVisitAssetWorkSheet oEngineerVisitAssetWorkSheet)
            {

                // make sure that contact object is valid
                if (oEngineerVisitAssetWorkSheet.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oEngineerVisitAssetWorkSheet.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oEngineerVisitAssetWorkSheet.AssetID == default)
                {
                    AddCriticalMessage("Appliance Missing");
                }

                if (oEngineerVisitAssetWorkSheet.LandlordsApplianceID == default)
                {
                    AddCriticalMessage("Termination Missing");
                }

                if (oEngineerVisitAssetWorkSheet.ApplianceTestedID == default)
                {
                    AddCriticalMessage("Visual Condition Missing");
                }

                if (oEngineerVisitAssetWorkSheet.SpillageTestID == default)
                {
                    AddCriticalMessage("Chimney Structure Missing");
                }

                if (oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID == default)
                {
                    AddCriticalMessage("Chimney Swept Missing");
                }

                if (oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID == default)
                {
                    AddCriticalMessage("Hearth Size Missing");
                }

                if (oEngineerVisitAssetWorkSheet.FlueFlowTestID == default)
                {
                    AddCriticalMessage("Fire guard Missing");
                }

                if (oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID == default)
                {
                    AddCriticalMessage("Flue clear Missing");
                }

                if (oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID == default)
                {
                    AddCriticalMessage("Swept brush Missing");
                }

                if (oEngineerVisitAssetWorkSheet.ColdWaterTemp == default)
                {
                    AddCriticalMessage("Compustion air Missing");
                }

                if (oEngineerVisitAssetWorkSheet.DHWTemp == default)
                {
                    AddCriticalMessage("Flue performance Missing");
                }

                if (oEngineerVisitAssetWorkSheet.InletWorkingPressure == default)
                {
                    AddCriticalMessage("Safety device Missing");
                }

                if (oEngineerVisitAssetWorkSheet.MinBurnerPressure == default)
                {
                    AddCriticalMessage("Appliance serviced Missing");
                }

                if (oEngineerVisitAssetWorkSheet.Nozzle == default)
                {
                    AddCriticalMessage("Immersion heater Missing");
                }

                if (oEngineerVisitAssetWorkSheet.CO2 == default)
                {
                    AddCriticalMessage("Tennant knowlege Missing");
                }

                if (oEngineerVisitAssetWorkSheet.CO2CORatio == default)
                {
                    AddCriticalMessage("Operating instructions Missing");
                }

                if (oEngineerVisitAssetWorkSheet.BMake == default)
                {
                    AddCriticalMessage("Type of cylinder Missing");
                }

                if (oEngineerVisitAssetWorkSheet.BModel == default)
                {
                    AddCriticalMessage("Ventilation type Missing");
                }

                if (oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID == default)
                {
                    AddCriticalMessage("Extractor fans Missing");
                }

                if (oEngineerVisitAssetWorkSheet.ApplianceSafeID == default)
                {
                    AddCriticalMessage("Appliance safe Missing");
                }

                if (oEngineerVisitAssetWorkSheet.DischargeID == default)
                {
                    AddCriticalMessage("Smoke draw test Missing");
                }

                if (oEngineerVisitAssetWorkSheet.SweepOutcomeID == default)
                {
                    AddCriticalMessage("Smoke pressure test Missing");
                }

                if (oEngineerVisitAssetWorkSheet.OverallID == default)
                {
                    AddCriticalMessage("Ventilation air provision Missing");
                }

                if (oEngineerVisitAssetWorkSheet.TankID == default)
                {
                    AddCriticalMessage("Approved fuel Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}