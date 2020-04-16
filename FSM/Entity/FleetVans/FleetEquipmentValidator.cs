// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetEquipmentValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.FleetVans
{
  public class FleetEquipmentValidator : BaseValidator
  {
    public void Validate(FleetEquipment oFleetEquipment)
    {
      if (oFleetEquipment.Errors.Count > 0)
      {
        foreach (object error in oFleetEquipment.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      FleetEquipment fleetEquipment = oFleetEquipment;
      if (fleetEquipment.Name.Trim().Length == 0)
        this.AddCriticalMessage("Name missing");
      if (fleetEquipment.Cost == 0.0)
        this.AddCriticalMessage("Cost missing");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
