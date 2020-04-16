// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheetValidatorOil
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.EngineerVisitAssetWorkSheets
{
    public class EngineerVisitAssetWorkSheetValidatorOil : BaseValidator
    {
        public void Validate(
          EngineerVisitAssetWorkSheet oEngineerVisitAssetWorkSheet,
          string ApplianceTested)
        {
            if (oEngineerVisitAssetWorkSheet.Errors.Count > 0)
            {
                foreach (object error in oEngineerVisitAssetWorkSheet.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if ((uint)Operators.CompareString(ApplianceTested, "No", false) > 0U)
            {
                if (oEngineerVisitAssetWorkSheet.AssetID == 0)
                    this.AddCriticalMessage("Appliance Missing");
                if (oEngineerVisitAssetWorkSheet.LandlordsApplianceID == 0)
                    this.AddCriticalMessage("Landlord appliance Missing");
                if (oEngineerVisitAssetWorkSheet.ApplianceTestedID == 0)
                    this.AddCriticalMessage("Apliance tested Missing");
                if (oEngineerVisitAssetWorkSheet.FlueFlowTestID == 0)
                    this.AddCriticalMessage("Chimney/Flue Missing");
                if (oEngineerVisitAssetWorkSheet.SpillageTestID == 0)
                    this.AddCriticalMessage("Burner satisfactory Missing");
                if (oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID == 0)
                    this.AddCriticalMessage("Oil storage Missing");
                if (oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID == 0)
                    this.AddCriticalMessage("Oil supply Missing");
                if (oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID == 0)
                    this.AddCriticalMessage("Air supply Missing");
                if (oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID == 0)
                    this.AddCriticalMessage("Safety device Missing");
                if (oEngineerVisitAssetWorkSheet.TankID == 0)
                    this.AddCriticalMessage("Tank type Missing");
                if (oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID == 0)
                    this.AddCriticalMessage("Appliance service Missing");
                if (oEngineerVisitAssetWorkSheet.ApplianceSafeID == 0)
                    this.AddCriticalMessage("Appliance safety Missing");
                if (Operators.CompareString(oEngineerVisitAssetWorkSheet.Nozzle, (string)null, false) == 0)
                    this.AddCriticalMessage("Nozzle size Missing");
                if (Operators.CompareString(oEngineerVisitAssetWorkSheet.BMake, (string)null, false) == 0)
                    this.AddCriticalMessage("CO2 Min Missing");
                if (Operators.CompareString(oEngineerVisitAssetWorkSheet.BModel, (string)null, false) == 0)
                    this.AddCriticalMessage("CO2 Max Missing");
            }
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}