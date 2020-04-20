// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractAlternatives.QuoteContractAlternativeValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;

namespace FSM.Entity.QuoteContractAlternatives
{
    public class QuoteContractAlternativeValidator : BaseValidator
    {
        public void Validate(QuoteContractAlternative oQuoteContract)
        {
            if (oQuoteContract.Errors.Count > 0)
            {
                foreach (object error in oQuoteContract.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (oQuoteContract.QuoteContractReference.Trim().Length == 0)
                this.AddCriticalMessage("Quote Contract Reference Missing");
            if (oQuoteContract.QuoteContractStatusID == 0)
                this.AddCriticalMessage("Quote Contract Status Missing");
            if (DateTime.Compare(oQuoteContract.ContractEnd, oQuoteContract.ContractStart) <= 0)
                this.AddCriticalMessage("Contract End Date must be greater than Contract Start Date");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}