// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractOption3Sites.ContractOption3SiteValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;

namespace FSM.Entity.ContractOption3Sites
{
    public class ContractOption3SiteValidator : BaseValidator
    {
        public void Validate(ContractOption3Site oContractOption3Site, DataView assets)
        {
            if (oContractOption3Site.Errors.Count > 0)
            {
                foreach (object error in oContractOption3Site.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (oContractOption3Site.ContractSiteReference.Trim().Length == 0)
                this.AddCriticalMessage("* Property Reference Required");
            if (DateTime.Compare(oContractOption3Site.StartDate, oContractOption3Site.EndDate) >= 0)
                this.AddCriticalMessage("* End Date must be greater than Start Date");
            if (DateTime.Compare(oContractOption3Site.FirstVisitDate, oContractOption3Site.StartDate) < 0 | DateTime.Compare(oContractOption3Site.FirstVisitDate, oContractOption3Site.EndDate) > 0)
                this.AddCriticalMessage("* First Visit Date must be between Start Date and End Date");
            if (oContractOption3Site.InvoiceFrequencyID == 0)
                this.AddCriticalMessage("* Invoice Frequency Required");
            if (oContractOption3Site.VisitFrequencyID == 0)
                this.AddCriticalMessage("* Visit Frequency Required");
            if (assets.Table.Columns.Count < 16)
                this.AddCriticalMessage("* Please load and fill in the assets schedule.");
            if (oContractOption3Site.InvoiceAddressID == 0)
                this.AddCriticalMessage("Invoice Address Missing");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}