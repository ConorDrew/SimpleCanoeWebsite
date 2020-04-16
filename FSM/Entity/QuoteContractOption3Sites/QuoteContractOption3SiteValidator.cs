// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractOption3Sites.QuoteContractOption3SiteValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;

namespace FSM.Entity.QuoteContractOption3Sites
{
    public class QuoteContractOption3SiteValidator : BaseValidator
    {
        public void Validate(QuoteContractOption3Site oQuoteContractOption3Site, DataView assets)
        {
            if (oQuoteContractOption3Site.Errors.Count > 0)
            {
                foreach (object error in oQuoteContractOption3Site.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (oQuoteContractOption3Site.QuoteContractSiteReference.Trim().Length == 0)
                this.AddCriticalMessage("* Site Reference Required");
            if (DateTime.Compare(oQuoteContractOption3Site.StartDate, oQuoteContractOption3Site.EndDate) >= 0)
                this.AddCriticalMessage("* End Date must be greater than Start Date");
            if (DateTime.Compare(oQuoteContractOption3Site.FirstVisitDate, oQuoteContractOption3Site.StartDate) < 0 | DateTime.Compare(oQuoteContractOption3Site.FirstVisitDate, oQuoteContractOption3Site.EndDate) > 0)
                this.AddCriticalMessage("* First Visit Date must be between Start Date and End Date");
            if (oQuoteContractOption3Site.VisitFrequencyID == 0)
                this.AddCriticalMessage("* Visit Frequency Required");
            if (assets.Table.Columns.Count < 16)
                this.AddCriticalMessage("* Please load and fill in the assets schedule.");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}