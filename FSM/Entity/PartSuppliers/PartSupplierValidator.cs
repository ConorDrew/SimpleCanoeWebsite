// Decompiled with JetBrains decompiler
// Type: FSM.Entity.PartSuppliers.PartSupplierValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.PartSuppliers
{
  public class PartSupplierValidator : BaseValidator
  {
    public void Validate(PartSupplier oPartSupplier)
    {
      if (oPartSupplier.Errors.Count > 0)
      {
        foreach (object error in oPartSupplier.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oPartSupplier.SupplierID <= 0)
        this.AddCriticalMessage("Supplier Missing");
      if (oPartSupplier.QuantityInPack < 1.0)
        this.AddCriticalMessage("Invalid Quantity In Pack");
      if (oPartSupplier.Price <= 0.0)
        this.AddCriticalMessage("Invalid Price");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
