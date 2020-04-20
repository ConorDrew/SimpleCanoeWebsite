using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteContractOriginalSiteAssets
    {
        // make sure that contact object is valid
        public class QuoteContractOriginalSiteAssetValidator : BaseValidator
        {
            public void Validate(QuoteContractOriginalSiteAsset oQuoteContractSiteAsset)
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