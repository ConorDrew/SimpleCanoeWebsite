using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractAlternativeSiteJobItems
    {
        // make sure that contact object is valid
        public class ContractAlternativeSiteJobItemsValidator : BaseValidator
        {
            public void Validate(ContractAlternativeSiteJobItems oContractAlternativeSiteJobItems)
            {
                // make sure that contact object is valid
                if (oContractAlternativeSiteJobItems.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oContractAlternativeSiteJobItems.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oContractAlternativeSiteJobItems.VisitFrequencyID == 0)
                {
                    AddCriticalMessage("Visit Frequency Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}