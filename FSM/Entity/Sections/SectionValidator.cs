// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sections.SectionValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.Sections
{
  public class SectionValidator : BaseValidator
  {
    public void Validate(Section oSection)
    {
      if (oSection.Errors.Count > 0)
      {
        foreach (object error in oSection.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oSection.Description.Trim().Length == 0)
        this.AddCriticalMessage("Description Missing");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
