using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Invoiceds
    {
        // make sure that contact object is valid
        public class InvoicedValidator : BaseValidator
        {
            public void Validate(Invoiced oInvoiced)
            {
                // make sure that contact object is valid
                if (oInvoiced.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oInvoiced.Errors)
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