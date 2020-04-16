// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheetValidatorUnvented
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.EngineerVisitAssetWorkSheets
{
  public class EngineerVisitAssetWorkSheetValidatorUnvented : BaseValidator
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
        this.AddCriticalMessage("Appliance Safe Missing");
      if (oEngineerVisitAssetWorkSheet.LandlordsApplianceID == 0)
        this.AddCriticalMessage("Water pressure Missing");
      if (oEngineerVisitAssetWorkSheet.FlueFlowTestID == 0)
        this.AddCriticalMessage("Cylinder integrity Missing");
      if (oEngineerVisitAssetWorkSheet.SpillageTestID == 0)
        this.AddCriticalMessage("Pre-Charge pressure Missing");
      if (oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID == 0)
        this.AddCriticalMessage("Filter/Strainer check  Missing");
      if (oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID == 0)
        this.AddCriticalMessage("Sacrificial anode check Missing");
      if (oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID == 0)
        this.AddCriticalMessage("Expansion Gap check  Missing");
      if (oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID == 0)
        this.AddCriticalMessage("Tundish check Missing");
      if (oEngineerVisitAssetWorkSheet.SweepOutcomeID == 0)
        this.AddCriticalMessage("Connection check Missing");
      if (oEngineerVisitAssetWorkSheet.OverallID == 0)
        this.AddCriticalMessage("Discharge pipe checks Missing");
      if (oEngineerVisitAssetWorkSheet.DischargeID == 0)
        this.AddCriticalMessage("temp/ pressure relief value Missing");
      if (oEngineerVisitAssetWorkSheet.TankID == 0)
        this.AddCriticalMessage("expansion value check Missing");
      if (oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID == 0)
        this.AddCriticalMessage("water pressure / flow rates check  Missing");
      if (oEngineerVisitAssetWorkSheet.ApplianceSafeID == 0)
        this.AddCriticalMessage("Service record  Missing");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
