// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheetValidatorASHP
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.EngineerVisitAssetWorkSheets
{
  public class EngineerVisitAssetWorkSheetValidatorASHP : BaseValidator
  {
    public void Validate(
      EngineerVisitAssetWorkSheet oEngineerVisitAssetWorkSheet)
    {
      if (oEngineerVisitAssetWorkSheet.Errors.Count > 0)
      {
        foreach (object error in oEngineerVisitAssetWorkSheet.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oEngineerVisitAssetWorkSheet.AssetID == 0)
        this.AddCriticalMessage("Appliance Missing");
      if (oEngineerVisitAssetWorkSheet.LandlordsApplianceID == 0)
        this.AddCriticalMessage("Landlords Appliance Missing");
      if (oEngineerVisitAssetWorkSheet.FlueFlowTestID == 0)
        this.AddCriticalMessage("Pressure Missing");
      if (oEngineerVisitAssetWorkSheet.SpillageTestID == 0)
        this.AddCriticalMessage("Operation Missing");
      if (oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID == 0)
        this.AddCriticalMessage("Safety devices Missing");
      if (oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID == 0)
        this.AddCriticalMessage("Stability Missing");
      if (oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID == 0)
        this.AddCriticalMessage("Free air Missing");
      if (oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID == 0)
        this.AddCriticalMessage("Safety device operation Missing");
      if (oEngineerVisitAssetWorkSheet.SweepOutcomeID == 0)
        this.AddCriticalMessage("Legionella Missing");
      if (oEngineerVisitAssetWorkSheet.OverallID == 0)
        this.AddCriticalMessage("Overall condition Missing");
      if (oEngineerVisitAssetWorkSheet.DischargeID == 0)
        this.AddCriticalMessage("Glycol Missing");
      if (oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID == 0)
        this.AddCriticalMessage("Appliance service Missing");
      if (oEngineerVisitAssetWorkSheet.ApplianceSafeID == 0)
        this.AddCriticalMessage("Appliance Safety Missing");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
