using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitAssetWorkSheets
    {
        // make sure that contact object is valid
        public class EngineerVisitAssetWorkSheetValidatorOther : BaseValidator
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
                        AddCriticalMessage("Landlords appliance Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.ApplianceTestedID == default)
                    {
                        AddCriticalMessage("Appliance Tested Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.FlueFlowTestID == default)
                    {
                        AddCriticalMessage("Leaks/Presure Missing");
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
                        AddCriticalMessage("Ventilation Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID == default)
                    {
                        AddCriticalMessage("Safety device operation Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.SweepOutcomeID == default)
                    {
                        AddCriticalMessage("Sweep outcome Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.OverallID == default)
                    {
                        AddCriticalMessage("Overall condition Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.DischargeID == default)
                    {
                        AddCriticalMessage("Discharge Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID == default)
                    {
                        AddCriticalMessage("Appliance service Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.ApplianceSafeID == default)
                    {
                        AddCriticalMessage("Appliance safety Missing");
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