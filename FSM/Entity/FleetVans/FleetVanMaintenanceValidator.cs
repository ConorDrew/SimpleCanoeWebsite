// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetVanMaintenanceValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;

namespace FSM.Entity.FleetVans
{
    public class FleetVanMaintenanceValidator : BaseValidator
    {
        public void Validate(FleetVanMaintenance oFleetVan)
        {
            if (oFleetVan.Errors.Count > 0)
            {
                foreach (object error in oFleetVan.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            FleetVanMaintenance fleetVanMaintenance = oFleetVan;
            if (fleetVanMaintenance.LastServiceMileage == 0)
                this.AddCriticalMessage("Van last service mileage missing");
            if (DateTime.Compare(fleetVanMaintenance.MOTExpiry, DateTime.Now) < 0)
                this.AddCriticalMessage("MOT has expired");
            if (DateTime.Compare(fleetVanMaintenance.RoadTaxExpiry, DateTime.Now) < 0)
                this.AddCriticalMessage("Road tax has expired");
            if (fleetVanMaintenance.Breakdown.Trim().Length == 0)
                this.AddCriticalMessage("Please add breakdown company");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}