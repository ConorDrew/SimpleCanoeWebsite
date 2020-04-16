// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitTimeSheets.EngineerVisitTimeSheetValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.EngineerVisitTimeSheets
{
  public class EngineerVisitTimeSheetValidator : BaseValidator
  {
    public void Validate(EngineerVisitTimeSheet oEngineerVisitTimeSheet)
    {
      if (oEngineerVisitTimeSheet.Errors.Count > 0)
      {
        foreach (object error in oEngineerVisitTimeSheet.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
