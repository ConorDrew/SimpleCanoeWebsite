// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractOption3s.QuoteContractOption3Validator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.QuoteContractOption3s
{
    public class QuoteContractOption3Validator : BaseValidator
    {
        public void Validate(QuoteContractOption3 oQuoteContractOption3)
        {
            if (oQuoteContractOption3.Errors.Count > 0)
            {
                foreach (object error in oQuoteContractOption3.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (oQuoteContractOption3.QuoteContractReference.Trim().Length == 0)
                this.AddCriticalMessage("* Quote Contract Referenece is required");
            if (Strings.InStr(oQuoteContractOption3.QuoteContractReference, "-", CompareMethod.Binary) > 0)
                this.AddCriticalMessage("* Quote Contract Referenece cannot contain '-'.");
            if (oQuoteContractOption3.QuoteContractStatusID == 0)
                this.AddCriticalMessage("* Quote Status is required");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}