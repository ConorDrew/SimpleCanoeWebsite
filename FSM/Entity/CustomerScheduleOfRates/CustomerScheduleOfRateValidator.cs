// Decompiled with JetBrains decompiler
// Type: FSM.Entity.CustomerScheduleOfRates.CustomerScheduleOfRateValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.CustomerScheduleOfRates
{
  public class CustomerScheduleOfRateValidator : BaseValidator
  {
    public void Validate(CustomerScheduleOfRate oCustomerScheduleOfRate)
    {
      if (oCustomerScheduleOfRate.Errors.Count > 0)
      {
        foreach (object error in oCustomerScheduleOfRate.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oCustomerScheduleOfRate.ScheduleOfRatesCategoryID == 0)
        this.AddCriticalMessage("* Category is missing");
      if (oCustomerScheduleOfRate.Description.Trim().Length == 0)
        this.AddCriticalMessage("* Description is missing");
      if (!Versioned.IsNumeric((object) oCustomerScheduleOfRate.Price))
        this.AddCriticalMessage("* Price must be numeric");
      if (!Versioned.IsNumeric((object) oCustomerScheduleOfRate.TimeInMins))
        this.AddCriticalMessage("* Time must be numeric");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
