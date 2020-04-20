using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractOriginalSiteAssets
    {
        // make sure that contact object is valid
        public class ContractOriginalSiteAssetValidator : BaseValidator
        {
            public void Validate(ContractOriginalSiteAsset oContractSiteAsset)
            {

                // make sure that contact object is valid
                if (oContractSiteAsset.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oContractSiteAsset.Errors)
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