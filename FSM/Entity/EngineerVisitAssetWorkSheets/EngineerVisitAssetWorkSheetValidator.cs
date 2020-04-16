// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheetValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.EngineerVisitAssetWorkSheets
{
  public class EngineerVisitAssetWorkSheetValidator : BaseValidator
  {
    public void Validate(
      EngineerVisitAssetWorkSheet oEngineerVisitAssetWorkSheet,
      string ApplianceTested)
    {
      if (oEngineerVisitAssetWorkSheet.Errors.Count > 0)
      {
        foreach (object error in oEngineerVisitAssetWorkSheet.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (Operators.CompareString(ApplianceTested, "Yes", false) == 0)
      {
        if (oEngineerVisitAssetWorkSheet.ApplianceSafeID == 0)
          this.AddCriticalMessage("Appliance Safe Missing");
        if (oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID == 0)
          this.AddCriticalMessage("Appliance Serviced Or Inspected Missing");
        if (oEngineerVisitAssetWorkSheet.SpillageTestID == 0)
          this.AddCriticalMessage("Flue Spilage Test Missing");
        if (oEngineerVisitAssetWorkSheet.AssetID == 0)
          this.AddCriticalMessage("Appliance Missing");
        if (oEngineerVisitAssetWorkSheet.FlueFlowTestID == 0)
          this.AddCriticalMessage("Flue Flow Test Missing");
        if (oEngineerVisitAssetWorkSheet.CO2 == 0.0)
          this.AddCriticalMessage("CO2 % Missing");
        if (oEngineerVisitAssetWorkSheet.CO2CORatio == 0.0)
          this.AddCriticalMessage("CO2/CO Ratio Missing");
        if (oEngineerVisitAssetWorkSheet.ColdWaterTemp == 0.0)
          this.AddCriticalMessage("Cold Water Temp Missing");
        if (oEngineerVisitAssetWorkSheet.DHWFlowRate == 0.0)
          this.AddCriticalMessage("DHW Flow Rate Missing");
        if (oEngineerVisitAssetWorkSheet.DHWTemp == 0.0)
          this.AddCriticalMessage("DHW Temp Missing");
        if (oEngineerVisitAssetWorkSheet.FlueFlowTestID == 0)
          this.AddCriticalMessage("Flue Flow Test Missing");
        if (oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID == 0)
          this.AddCriticalMessage("Flue Termination Satisfactory Missing");
        if (oEngineerVisitAssetWorkSheet.InletStaticPressure == 0.0)
          this.AddCriticalMessage("Inlet Static Pressure Missing");
        if (oEngineerVisitAssetWorkSheet.InletWorkingPressure == 0.0)
          this.AddCriticalMessage("Inlet Working Pressure Missing");
        if (oEngineerVisitAssetWorkSheet.LandlordsApplianceID == 0)
          this.AddCriticalMessage("Landlords Appliance Missing");
        if (oEngineerVisitAssetWorkSheet.MaxBurnerPressure == 0.0)
          this.AddCriticalMessage("Max Burner Pressure Missing");
        if (oEngineerVisitAssetWorkSheet.MinBurnerPressure == 0.0)
          this.AddCriticalMessage("Min Burner Pressure Missing");
        if (oEngineerVisitAssetWorkSheet.MinBurnerPressure == 0.0)
          this.AddCriticalMessage("Min Burner Pressure Missing");
        if (oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID == 0)
          this.AddCriticalMessage("Safety Device Operation Missing");
        if (oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID == 0)
          this.AddCriticalMessage("Ventilation Provision Satisfactory Missing");
        if (oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID == 0)
          this.AddCriticalMessage("Visual Condition of Flue Satisfactory Missing");
      }
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
