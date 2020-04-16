// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVans.EngineerVanValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;

namespace FSM.Entity.EngineerVans
{
  public class EngineerVanValidator : BaseValidator
  {
    public void Validate(EngineerVan oEngineerVan)
    {
      if (oEngineerVan.Errors.Count > 0)
      {
        foreach (object error in oEngineerVan.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oEngineerVan.VanID == 0)
        this.AddCriticalMessage("Van Missing");
      if (oEngineerVan.EngineerID == 0)
        this.AddCriticalMessage("Engineer Missing");
      if ((uint) DateTime.Compare(oEngineerVan.EndDateTime, DateTime.MinValue) > 0U && DateTime.Compare(oEngineerVan.StartDateTime, oEngineerVan.EndDateTime) >= 0)
        this.AddCriticalMessage("Start Date Time Must Be Before End Date Time");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
