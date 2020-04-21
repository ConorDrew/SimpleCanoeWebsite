using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteContractAlternativeSiteJobOfWorks
    {
        // make sure that contact object is valid
        public class QuoteContractAlternativeSiteJobOfWorkValidator : BaseValidator
        {
            public void Validate(QuoteContractAlternativeSiteJobOfWork oQuoteContractAlternativeSiteJobOfWork)
            {
                // make sure that contact object is valid
                if (oQuoteContractAlternativeSiteJobOfWork.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oQuoteContractAlternativeSiteJobOfWork.Errors)
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