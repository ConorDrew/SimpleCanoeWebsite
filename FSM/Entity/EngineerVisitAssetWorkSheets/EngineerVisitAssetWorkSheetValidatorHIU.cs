// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheetValidatorHIU
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.EngineerVisitAssetWorkSheets
{
    public class EngineerVisitAssetWorkSheetValidatorHIU : BaseValidator
    {
        public void Validate(
          EngineerVisitAssetWorkSheet oEngineerVisitAssetWorkSheet)
        {
            if (oEngineerVisitAssetWorkSheet.Errors.Count > 0)
            {
                foreach (object error in oEngineerVisitAssetWorkSheet.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (oEngineerVisitAssetWorkSheet.AssetID == 0)
                this.AddCriticalMessage("Appliance Missing");
            if (oEngineerVisitAssetWorkSheet.LandlordsApplianceID == 0)
                this.AddCriticalMessage("Landlord Appliance Missing");
            if (oEngineerVisitAssetWorkSheet.FlueFlowTestID == 0)
                this.AddCriticalMessage("Check for leaks Missing");
            if (oEngineerVisitAssetWorkSheet.SpillageTestID == 0)
                this.AddCriticalMessage("Port valves Missing");
            if (oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID == 0)
                this.AddCriticalMessage("Strainers Missing");
            if (oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID == 0)
                this.AddCriticalMessage("Pumps Missing");
            if (oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID == 0)
                this.AddCriticalMessage("System operation Missing");
            if (Operators.CompareString(oEngineerVisitAssetWorkSheet.Nozzle, (string)null, false) == 0)
                this.AddCriticalMessage("Recorded results Missing");
            if (oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID == 0)
                this.AddCriticalMessage("Appliance service Missing");
            if (oEngineerVisitAssetWorkSheet.ApplianceSafeID == 0)
                this.AddCriticalMessage("Appliance safety Missing");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}