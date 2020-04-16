// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetVanContractValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.FleetVans
{
    public class FleetVanContractValidator : BaseValidator
    {
        public void Validate(FleetVanContract oFleetVan)
        {
            if (oFleetVan.Errors.Count > 0)
            {
                foreach (object error in oFleetVan.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            FleetVanContract fleetVanContract = oFleetVan;
            if (fleetVanContract.VanID == 0)
                this.AddCriticalMessage("Van missing");
            if (fleetVanContract.Lessor.Trim().Length == 0)
                this.AddCriticalMessage("Lessor missing");
            if (fleetVanContract.ProcurementMethod == 0)
                this.AddCriticalMessage("Procurement method missing");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}