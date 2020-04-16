// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetVanValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.FleetVans
{
    public class FleetVanValidator : BaseValidator
    {
        public void Validate(FleetVan oFleetVan)
        {
            if (oFleetVan.Errors.Count > 0)
            {
                foreach (object error in oFleetVan.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (oFleetVan.VanTypeID == 0)
                this.AddCriticalMessage("Van type missing");
            if (oFleetVan.Registration.Trim().Length == 0)
                this.AddCriticalMessage("Registration missing");
            if (oFleetVan.Mileage == 0)
                this.AddCriticalMessage("Current mileage missing");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}