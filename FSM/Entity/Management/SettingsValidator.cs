// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Management.SettingsValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;

namespace FSM.Entity.Management
{
  public class SettingsValidator : BaseValidator
  {
    public void Validate(Settings settings)
    {
      if (settings.Errors.Count > 0)
      {
        foreach (object error in settings.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      bool flag = true;
      if (settings.WorkingHoursStart.Trim().Length == 0)
      {
        this.AddCriticalMessage("Working Hours Start Missing");
        flag = true;
      }
      if (settings.WorkingHoursEnd.Trim().Length == 0)
      {
        this.AddCriticalMessage("Working Hours End Missing");
        flag = true;
      }
      if (flag)
      {
        DateTime t1;
        ref DateTime local1 = ref t1;
        DateTime now1 = DateAndTime.Now;
        int year1 = now1.Year;
        now1 = DateAndTime.Now;
        int month1 = now1.Month;
        int day1 = DateAndTime.Now.Day;
        int integer1 = Conversions.ToInteger(settings.WorkingHoursStart.Trim().Substring(0, 2));
        int integer2 = Conversions.ToInteger(settings.WorkingHoursStart.Trim().Substring(3, 2));
        local1 = new DateTime(year1, month1, day1, integer1, integer2, 0);
        DateTime t2;
        ref DateTime local2 = ref t2;
        int year2 = DateAndTime.Now.Year;
        DateTime now2 = DateAndTime.Now;
        int month2 = now2.Month;
        now2 = DateAndTime.Now;
        int day2 = now2.Day;
        int integer3 = Conversions.ToInteger(settings.WorkingHoursEnd.Trim().Substring(0, 2));
        int integer4 = Conversions.ToInteger(settings.WorkingHoursEnd.Trim().Substring(3, 2));
        local2 = new DateTime(year2, month2, day2, integer3, integer4, 0);
        if (DateTime.Compare(t1, t2) >= 0)
          this.AddCriticalMessage("Working Hours End must be after the Start");
      }
      if (settings.MileageRate == 0.0)
        this.AddCriticalMessage("Mileage Rate Missing");
      if (!Versioned.IsNumeric((object) settings.MileageRate))
        this.AddCriticalMessage("Mileage Rate Invalid");
      if (settings.PartsMarkup == 0.0)
        this.AddCriticalMessage("Parts Markup Missing");
      if (!Versioned.IsNumeric((object) settings.PartsMarkup))
        this.AddCriticalMessage("Parts Markup Invalid");
      if (settings.RatesMarkup == 0.0)
        this.AddCriticalMessage("Rates Markup Missing");
      if (!Versioned.IsNumeric((object) settings.RatesMarkup))
        this.AddCriticalMessage("Rates Markup Invalid");
      if (settings.CalloutPrefix.Trim().Length == 0)
        this.AddCriticalMessage("Callout Prefix Missing");
      if (settings.MiscPrefix.Trim().Length == 0)
        this.AddCriticalMessage("Miscellaneous Prefix Missing");
      if (settings.PPMPrefix.Trim().Length == 0)
        this.AddCriticalMessage("PPM Prefix Missing");
      if (settings.QuotePrefix.Trim().Length == 0)
        this.AddCriticalMessage("Quote Prefix Missing");
      if (settings.ServiceFromLetterPrefix.Trim().Length == 0)
        this.AddCriticalMessage("Service From Letter Prefix Missing");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
