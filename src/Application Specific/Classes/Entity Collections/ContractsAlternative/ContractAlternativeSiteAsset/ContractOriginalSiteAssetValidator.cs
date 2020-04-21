using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractAlternativeSiteAssets
    {
        // make sure that contact object is valid
        public class ContractAlternativeSiteAssetValidator : BaseValidator
        {
            public void Validate(ContractAlternativeSiteAsset oContractSiteAsset)
            {
                // make sure that contact object is valid
                if (oContractSiteAsset.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oContractSiteAsset.Errors)
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