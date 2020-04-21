using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractAlternativeSiteJobOfWorks
    {
        // make sure that contact object is valid
        public class ContractAlternativeSiteJobOfWorkValidator : BaseValidator
        {
            public void Validate(ContractAlternativeSiteJobOfWork oContractAlternativeSiteJobOfWork)
            {
                // make sure that contact object is valid
                if (oContractAlternativeSiteJobOfWork.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oContractAlternativeSiteJobOfWork.Errors)
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