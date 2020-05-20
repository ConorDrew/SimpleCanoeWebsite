using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitAssetWorkSheets
    {
        // make sure that contact object is valid
        public class EngineerVisitAssetWorkSheetValidatorComCat : BaseValidator
        {
            public void Validate(EngineerVisitAssetWorkSheet oEngineerVisitAssetWorkSheet, string ApplianceTested)
            {
                // make sure that contact object is valid
                if (oEngineerVisitAssetWorkSheet.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oEngineerVisitAssetWorkSheet.Errors)
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
                        AddCriticalMessage("Landlords Appliance  Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.ApplianceTestedID == default)
                    {
                        AddCriticalMessage("Appliance tested Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.FlueFlowTestID == default)
                    {
                        AddCriticalMessage("Gas hose field Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.SpillageTestID == default)
                    {
                        AddCriticalMessage("Electrical isolator field Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID == default)
                    {
                        AddCriticalMessage("Manufactures info field Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID == default)
                    {
                        AddCriticalMessage("Gas isolation Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID == default)
                    {
                        AddCriticalMessage("FSP fitted Missing");
                    }

                    if (oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID == default)
                    {
                        AddCriticalMessage("pipework gastight Missing");
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