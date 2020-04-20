using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractOriginalSiteRatess
    {
        // make sure that contact object is valid
        public class ContractOriginalSiteRatesValidator : BaseValidator
        {
            public void Validate(ContractOriginalSiteRates oContractOriginalSiteRates)
            {

                // make sure that contact object is valid
                if (oContractOriginalSiteRates.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oContractOriginalSiteRates.Errors)
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