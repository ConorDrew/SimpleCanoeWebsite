using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractOption3SiteAsset
    {
        // make sure that contact object is valid
        public class ContractOption3SiteAssetValidator : BaseValidator
        {
            public void Validate(ContractOption3SiteAsset oContractOption3SiteAsset)
            {

                // make sure that contact object is valid
                if (oContractOption3SiteAsset.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oContractOption3SiteAsset.Errors)
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