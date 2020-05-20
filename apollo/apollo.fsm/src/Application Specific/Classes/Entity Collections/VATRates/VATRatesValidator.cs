using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace VATRatess
    {
        // make sure that contact object is valid
        public class VATRatesValidator : BaseValidator
        {
            public void Validate(VATRates oVATRates)
            {
                // make sure that contact object is valid
                if (oVATRates.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oVATRates.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oVATRates.VATRateCode.Trim().Length == 0)
                {
                    AddCriticalMessage("Code Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}