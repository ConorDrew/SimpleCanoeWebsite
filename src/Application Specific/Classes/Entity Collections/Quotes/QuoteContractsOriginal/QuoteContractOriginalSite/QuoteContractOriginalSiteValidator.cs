using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteContractOriginalSites
    {

        // make sure that contact object is valid
        public class QuoteContractOriginalSiteValidator : BaseValidator
        {
            public void Validate(QuoteContractOriginalSite oQuoteContractSite)
            {

                // make sure that contact object is valid
                if (oQuoteContractSite.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oQuoteContractSite.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oQuoteContractSite.VisitFrequencyID == 0)
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