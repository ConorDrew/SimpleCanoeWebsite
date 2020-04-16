// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Warehouses.WarehouseValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.Warehouses
{
    public class WarehouseValidator : BaseValidator
    {
        public void Validate(Warehouse oWarehouse)
        {
            if (oWarehouse.Errors.Count > 0)
            {
                foreach (object error in oWarehouse.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (oWarehouse.Name.Trim().Length == 0)
                this.AddCriticalMessage("Name Missing");
            if (oWarehouse.Address1.Trim().Length == 0)
                this.AddCriticalMessage("Address1 Missing");
            if (oWarehouse.Postcode.Trim().Length == 0)
                this.AddCriticalMessage("Postcode Missing");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}