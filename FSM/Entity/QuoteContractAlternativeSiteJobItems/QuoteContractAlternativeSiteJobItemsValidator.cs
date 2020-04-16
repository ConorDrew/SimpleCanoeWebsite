// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractAlternativeSiteJobItems.QuoteContractAlternativeSiteJobItemsValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.QuoteContractAlternativeSiteJobItems
{
  public class QuoteContractAlternativeSiteJobItemsValidator : BaseValidator
  {
    public void Validate(
      FSM.Entity.QuoteContractAlternativeSiteJobItems.QuoteContractAlternativeSiteJobItems oQuoteContractAlternativeSiteJobItems)
    {
      if (oQuoteContractAlternativeSiteJobItems.Errors.Count > 0)
      {
        foreach (object error in oQuoteContractAlternativeSiteJobItems.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oQuoteContractAlternativeSiteJobItems.VisitFrequencyID == 0)
        this.AddCriticalMessage("Visit Frequency Missing");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
