// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Suppliers.SupplierValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.Suppliers
{
  public class SupplierValidator : BaseValidator
  {
    public void Validate(Supplier oSupplier)
    {
      if (oSupplier.Errors.Count > 0)
      {
        foreach (object error in oSupplier.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oSupplier.AccountNumber.Trim().Length == 0)
        this.AddCriticalMessage("Account Number Missing");
      if (oSupplier.Name.Trim().Length == 0)
        this.AddCriticalMessage("Name Missing");
      if (oSupplier.Address1.Trim().Length == 0)
        this.AddCriticalMessage("Address 1 Missing");
      if (oSupplier.Postcode.Trim().Length == 0)
        this.AddCriticalMessage("Postcode Missing");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
