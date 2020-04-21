using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteContractAlternativeSiteJobItems
    {
        // make sure that contact object is valid
        public class QuoteContractAlternativeSiteJobItemsValidator : BaseValidator
        {
            public void Validate(QuoteContractAlternativeSiteJobItems oQuoteContractAlternativeSiteJobItems)
            {
                // make sure that contact object is valid
                if (oQuoteContractAlternativeSiteJobItems.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oQuoteContractAlternativeSiteJobItems.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oQuoteContractAlternativeSiteJobItems.VisitFrequencyID == 0)
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