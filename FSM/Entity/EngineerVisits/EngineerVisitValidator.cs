// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisits.EngineerVisitValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.EngineerVisits
{
  public class EngineerVisitValidator : BaseValidator
  {
    public void Validate(EngineerVisit oEngineerVisit, int CustomerID)
    {
      if (oEngineerVisit.Errors.Count > 0)
      {
        foreach (object error in oEngineerVisit.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      switch (oEngineerVisit.OutcomeEnumID)
      {
        case 0:
          this.AddCriticalMessage("Outcome Missing");
          goto case 1;
        case 1:
          if (this.ValidatorMessages.CriticalMessages.Count <= 0)
            break;
          throw new ValidationException((BaseValidator) this);
        default:
          if (oEngineerVisit.OutcomeDetails.Trim().Length == 0)
          {
            this.AddCriticalMessage("Outcome Details Missing");
            goto case 1;
          }
          else
            goto case 1;
      }
    }
  }
}
