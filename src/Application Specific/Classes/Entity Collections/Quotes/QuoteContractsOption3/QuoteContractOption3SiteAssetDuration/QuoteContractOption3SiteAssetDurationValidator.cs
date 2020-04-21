using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteContractOption3SiteAssetDurations
    {
        // make sure that contact object is valid
        public class QuoteContractOption3SiteAssetDurationValidator : BaseValidator
        {
            public void Validate(QuoteContractOption3SiteAssetDuration oQuoteContractOption3SiteAssetDuration)
            {
                // make sure that contact object is valid
                if (oQuoteContractOption3SiteAssetDuration.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oQuoteContractOption3SiteAssetDuration.Errors)
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