using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteContractAlternatives
    {
        // make sure that contact object is valid
        public class QuoteContractAlternativeValidator : BaseValidator
        {
            public void Validate(QuoteContractAlternative oQuoteContract)
            {
                // make sure that contact object is valid
                if (oQuoteContract.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oQuoteContract.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oQuoteContract.QuoteContractReference.Trim().Length == 0)
                {
                    AddCriticalMessage("Quote Contract Reference Missing");
                }

                if (oQuoteContract.QuoteContractStatusID == 0)
                {
                    AddCriticalMessage("Quote Contract Status Missing");
                }

                if (oQuoteContract.ContractEnd <= oQuoteContract.ContractStart)
                {
                    AddCriticalMessage("Contract End Date must be greater than Contract Start Date");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}