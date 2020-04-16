// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractAlternativeSites.ContractAlternativeSiteValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.ContractsAlternative;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.ContractAlternativeSites
{
    public class ContractAlternativeSiteValidator : BaseValidator
    {
        public void Validate(ContractAlternativeSite oContractSite, ContractAlternative contract)
        {
            if (oContractSite.Errors.Count > 0)
            {
                foreach (object error in oContractSite.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}