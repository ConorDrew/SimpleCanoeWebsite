using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractOption3SitePPMVisits
    {
        // make sure that contact object is valid
        public class ContractOption3SitePPMVisitValidator : BaseValidator
        {
            public void Validate(ContractOption3SitePPMVisit oContractOption3SitePPMVisit)
            {
                // make sure that contact object is valid
                if (oContractOption3SitePPMVisit.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oContractOption3SitePPMVisit.Errors)
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