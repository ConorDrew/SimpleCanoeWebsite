// Decompiled with JetBrains decompiler
// Type: FSM.Entity.SystemScheduleOfRates.SystemScheduleOfRateValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.SystemScheduleOfRates
{
  public class SystemScheduleOfRateValidator : BaseValidator
  {
    public void Validate(SystemScheduleOfRate oSystemScheduleOfRate)
    {
      if (oSystemScheduleOfRate.Errors.Count > 0)
      {
        foreach (object error in oSystemScheduleOfRate.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oSystemScheduleOfRate.Description.Length == 0)
        this.AddCriticalMessage("* Description is missing");
      if (oSystemScheduleOfRate.ScheduleOfRatesCategoryID == 0)
        this.AddCriticalMessage("* Category is missing");
      if (!Versioned.IsNumeric((object) oSystemScheduleOfRate.Price))
        this.AddCriticalMessage("* Price must be numeric");
      if (!Versioned.IsNumeric((object) oSystemScheduleOfRate.TimeInMins))
        this.AddCriticalMessage("* Time must be numeric");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
