using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteContractAlternativePPMVisits
    {
        // make sure that contact object is valid
        public class QuoteContractAlternativePPMVisitValidator : BaseValidator
        {
            public void Validate(QuoteContractAlternativePPMVisit oQuoteContractPPMVisit)
            {
                // make sure that contact object is valid
                if (oQuoteContractPPMVisit.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oQuoteContractPPMVisit.Errors)
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