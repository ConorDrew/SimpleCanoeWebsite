using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteContractAlternativeSites
    {

        // make sure that contact object is valid
        public class QuoteContractAlternativeSiteValidator : BaseValidator
        {
            public void Validate(QuoteContractAlternativeSite oQuoteContractSite)
            {

                // make sure that contact object is valid
                if (oQuoteContractSite.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oQuoteContractSite.Errors)
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