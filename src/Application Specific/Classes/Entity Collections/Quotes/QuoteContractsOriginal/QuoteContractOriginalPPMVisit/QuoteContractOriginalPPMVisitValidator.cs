using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteContractOriginalPPMVisits
    {
        // make sure that contact object is valid
        public class QuoteContractOriginalPPMVisitValidator : BaseValidator
        {
            public void Validate(QuoteContractOriginalPPMVisit oQuoteContractPPMVisit)
            {

                // make sure that contact object is valid
                if (oQuoteContractPPMVisit.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oQuoteContractPPMVisit.Errors)
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