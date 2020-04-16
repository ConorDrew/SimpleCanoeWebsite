// Decompiled with JetBrains decompiler
// Type: FSM.Entity.CustomerCharges.CustomerChargeValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.CustomerCharges
{
  public class CustomerChargeValidator : BaseValidator
  {
    public void Validate(CustomerCharge oCustomerCharge)
    {
      if (oCustomerCharge.Errors.Count > 0)
      {
        foreach (object error in oCustomerCharge.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oCustomerCharge.MileageRate == 0.0)
        this.AddCriticalMessage("Mileage Rate Missing");
      if (!Versioned.IsNumeric((object) oCustomerCharge.MileageRate))
        this.AddCriticalMessage("Mileage Rate Invalid");
      if (!Versioned.IsNumeric((object) oCustomerCharge.PartsMarkup))
        this.AddCriticalMessage("Parts Markup Invalid");
      if (!Versioned.IsNumeric((object) oCustomerCharge.RatesMarkup))
        this.AddCriticalMessage("Rates Markup Invalid");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
