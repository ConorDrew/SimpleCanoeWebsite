// Decompiled with JetBrains decompiler
// Type: FSM.Entity.PartsToBeCrediteds.SalesCreditValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.SalesCredits;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.PartsToBeCrediteds
{
  public class SalesCreditValidator : BaseValidator
  {
    public void Validate(SalesCredit oPartsToBeCredited)
    {
      if (oPartsToBeCredited.Errors.Count > 0)
      {
        foreach (object error in oPartsToBeCredited.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
