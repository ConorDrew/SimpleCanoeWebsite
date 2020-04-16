// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractOriginalSites.ContractOriginalSiteValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.ContractsOriginal;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;

namespace FSM.Entity.ContractOriginalSites
{
  public class ContractOriginalSiteValidator : BaseValidator
  {
    public void Validate(ContractOriginalSite oContractSite, ContractOriginal contract)
    {
      if (oContractSite.Errors.Count > 0)
      {
        foreach (object error in oContractSite.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oContractSite.VisitFrequencyID == 0)
        this.AddCriticalMessage("Visit Frequency Missing");
      if (oContractSite.VisitDuration < 1)
        this.AddCriticalMessage("Visit Duration must be great than 0");
      if (DateTime.Compare(oContractSite.FirstVisitDate.Date, contract.ContractStartDate.Date) < 0 | DateTime.Compare(oContractSite.FirstVisitDate.Date, contract.ContractEndDate.Date) >= 0)
        this.AddCriticalMessage("First Visit Date must be between Contract Start and End Date");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
