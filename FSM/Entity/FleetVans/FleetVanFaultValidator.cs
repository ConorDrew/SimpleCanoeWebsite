// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetVanFaultValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.FleetVans
{
    public class FleetVanFaultValidator : BaseValidator
    {
        public void Validate(FleetVanFault oFleetVan)
        {
            if (oFleetVan.Errors.Count > 0)
            {
                foreach (object error in oFleetVan.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            FleetVanFault fleetVanFault = oFleetVan;
            if (fleetVanFault.FaultTypeID == 0)
                this.AddCriticalMessage("Fault type missing");
            if (fleetVanFault.Notes.Trim().Length == 0)
                this.AddCriticalMessage("Notes are missing");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}