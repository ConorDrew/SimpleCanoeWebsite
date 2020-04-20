using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractAlternativePPMVisits
    {
        // make sure that contact object is valid
        public class ContractAlternativePPMVisitValidator : BaseValidator
        {
            public void Validate(ContractAlternativePPMVisit oContractPPMVisit)
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