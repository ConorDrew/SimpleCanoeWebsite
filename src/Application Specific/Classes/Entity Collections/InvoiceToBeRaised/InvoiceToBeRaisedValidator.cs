using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace InvoiceToBeRaiseds
    {
        // make sure that contact object is valid
        public class InvoiceToBeRaisedValidator : BaseValidator
        {
            public void Validate(InvoiceToBeRaised oInvoiceToBeRaised)
            {
                // make sure that contact object is valid
                if (oInvoiceToBeRaised.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oInvoiceToBeRaised.Errors)
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