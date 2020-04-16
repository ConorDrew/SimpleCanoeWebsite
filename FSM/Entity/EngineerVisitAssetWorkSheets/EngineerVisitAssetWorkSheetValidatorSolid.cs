// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheetValidatorSolid
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.EngineerVisitAssetWorkSheets
{
    public class EngineerVisitAssetWorkSheetValidatorSolid : BaseValidator
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
                this.AddCriticalMessage("Termination Missing");
            if (oEngineerVisitAssetWorkSheet.ApplianceTestedID == 0)
                this.AddCriticalMessage("Visual Condition Missing");
            if (oEngineerVisitAssetWorkSheet.SpillageTestID == 0)
                this.AddCriticalMessage("Chimney Structure Missing");
            if (oEngineerVisitAssetWorkSheet.FlueTerminationSatisfactoryID == 0)
                this.AddCriticalMessage("Chimney Swept Missing");
            if (oEngineerVisitAssetWorkSheet.VisualConditionOfFlueSatisfactoryID == 0)
                this.AddCriticalMessage("Hearth Size Missing");
            if (oEngineerVisitAssetWorkSheet.FlueFlowTestID == 0)
                this.AddCriticalMessage("Fire guard Missing");
            if (oEngineerVisitAssetWorkSheet.VentilationProvisionSatisfactoryID == 0)
                this.AddCriticalMessage("Flue clear Missing");
            if (oEngineerVisitAssetWorkSheet.SafetyDeviceOperationID == 0)
                this.AddCriticalMessage("Swept brush Missing");
            if (oEngineerVisitAssetWorkSheet.ColdWaterTemp == 0.0)
                this.AddCriticalMessage("Compustion air Missing");
            if (oEngineerVisitAssetWorkSheet.DHWTemp == 0.0)
                this.AddCriticalMessage("Flue performance Missing");
            if (oEngineerVisitAssetWorkSheet.InletWorkingPressure == 0.0)
                this.AddCriticalMessage("Safety device Missing");
            if (oEngineerVisitAssetWorkSheet.MinBurnerPressure == 0.0)
                this.AddCriticalMessage("Appliance serviced Missing");
            if (Operators.CompareString(oEngineerVisitAssetWorkSheet.Nozzle, (string)null, false) == 0)
                this.AddCriticalMessage("Immersion heater Missing");
            if (oEngineerVisitAssetWorkSheet.CO2 == 0.0)
                this.AddCriticalMessage("Tennant knowlege Missing");
            if (oEngineerVisitAssetWorkSheet.CO2CORatio == 0.0)
                this.AddCriticalMessage("Operating instructions Missing");
            if (Operators.CompareString(oEngineerVisitAssetWorkSheet.BMake, (string)null, false) == 0)
                this.AddCriticalMessage("Type of cylinder Missing");
            if (Operators.CompareString(oEngineerVisitAssetWorkSheet.BModel, (string)null, false) == 0)
                this.AddCriticalMessage("Ventilation type Missing");
            if (oEngineerVisitAssetWorkSheet.ApplianceServiceOrInspectedID == 0)
                this.AddCriticalMessage("Extractor fans Missing");
            if (oEngineerVisitAssetWorkSheet.ApplianceSafeID == 0)
                this.AddCriticalMessage("Appliance safe Missing");
            if (oEngineerVisitAssetWorkSheet.DischargeID == 0)
                this.AddCriticalMessage("Smoke draw test Missing");
            if (oEngineerVisitAssetWorkSheet.SweepOutcomeID == 0)
                this.AddCriticalMessage("Smoke pressure test Missing");
            if (oEngineerVisitAssetWorkSheet.OverallID == 0)
                this.AddCriticalMessage("Ventilation air provision Missing");
            if (oEngineerVisitAssetWorkSheet.TankID == 0)
                this.AddCriticalMessage("Approved fuel Missing");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}