using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace InvoicedLiness
    {
        // make sure that contact object is valid
        public class InvoicedLinesValidator : BaseValidator
        {
            public void Validate(InvoicedLines oInvoicedLines)
            {
                // make sure that contact object is valid
                if (oInvoicedLines.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oInvoicedLines.Errors)
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