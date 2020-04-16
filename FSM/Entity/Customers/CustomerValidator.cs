// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Customers.CustomerValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.Customers
{
  public class CustomerValidator : BaseValidator
  {
    public void Validate(Customer oCustomer)
    {
      if (oCustomer.Errors.Count > 0)
      {
        foreach (object error in oCustomer.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oCustomer.Name.Trim().Length == 0)
        this.AddCriticalMessage("Name Missing");
      if (oCustomer.AccountNumber.Trim().Length == 0)
        this.AddCriticalMessage("Account Number Missing");
      if (oCustomer.RegionID == 0)
        this.AddCriticalMessage("Region Missing");
      if (oCustomer.CustomerTypeID == 0)
        this.AddCriticalMessage("Customer Type Missing");
      if (oCustomer.Status == 0)
        this.AddCriticalMessage("Status Missing");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
