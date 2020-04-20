using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractOriginalPPMVisits
    {
        // make sure that contact object is valid
        public class ContractOriginalPPMVisitValidator : BaseValidator
        {
            public void Validate(ContractOriginalPPMVisit oContractPPMVisit)
            {

                // make sure that contact object is valid
                if (oContractPPMVisit.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oContractPPMVisit.Errors)
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