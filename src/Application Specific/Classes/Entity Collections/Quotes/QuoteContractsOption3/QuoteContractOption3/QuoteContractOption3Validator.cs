using System.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteContractOption3s
    {
        // make sure that contact object is valid
        public class QuoteContractOption3Validator : BaseValidator
        {
            public void Validate(QuoteContractOption3 oQuoteContractOption3)
            {
                // make sure that contact object is valid
                if (oQuoteContractOption3.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oQuoteContractOption3.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oQuoteContractOption3.QuoteContractReference.Trim().Length == 0)
                {
                    AddCriticalMessage("* Quote Contract Referenece is required");
                }

                if (Strings.InStr(oQuoteContractOption3.QuoteContractReference, "-") > 0)
                {
                    AddCriticalMessage("* Quote Contract Referenece cannot contain '-'.");
                }

                if (oQuoteContractOption3.QuoteContractStatusID == 0)
                {
                    AddCriticalMessage("* Quote Status is required");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}