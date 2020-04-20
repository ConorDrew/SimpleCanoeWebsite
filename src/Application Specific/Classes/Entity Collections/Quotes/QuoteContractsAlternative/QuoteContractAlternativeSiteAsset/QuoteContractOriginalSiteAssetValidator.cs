using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteContractAlternativeSiteAssets
    {
        // make sure that contact object is valid
        public class QuoteContractAlternativeSiteAssetValidator : BaseValidator
        {
            public void Validate(QuoteContractAlternativeSiteAsset oQuoteContractSiteAsset)
            {

                // make sure that contact object is valid
                if (oQuoteContractSiteAsset.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oQuoteContractSiteAsset.Errors)
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