// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetVanTypeValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.FleetVans
{
    public class FleetVanTypeValidator : BaseValidator
    {
        public void Validate(FleetVanType oFleetVanType)
        {
            if (oFleetVanType.Errors.Count > 0)
            {
                foreach (object error in oFleetVanType.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (oFleetVanType.Make.Trim().Length == 0)
                this.AddCriticalMessage("Make Missing");
            if (oFleetVanType.Model.Trim().Length == 0)
                this.AddCriticalMessage("Model Missing");
            if (oFleetVanType.MileageServiceInterval < 0)
                this.AddCriticalMessage("The mileage service intervals cannot be less than 0");
            if (oFleetVanType.DateServiceInterval < 0)
                this.AddCriticalMessage("The date service intervals cannot be less than 0");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}