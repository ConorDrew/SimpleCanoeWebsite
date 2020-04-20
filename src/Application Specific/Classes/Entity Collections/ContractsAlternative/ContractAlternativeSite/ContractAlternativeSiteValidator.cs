using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractAlternativeSites
    {
        // make sure that contact object is valid
        public class ContractAlternativeSiteValidator : BaseValidator
        {
            public void Validate(ContractAlternativeSite oContractSite, ContractsAlternative.ContractAlternative contract)
            {

                // make sure that contact object is valid
                if (oContractSite.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oContractSite.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}