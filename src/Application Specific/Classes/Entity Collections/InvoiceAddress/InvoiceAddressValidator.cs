using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace InvoiceAddresss
    {
        // make sure that contact object is valid
        public class InvoiceAddressValidator : BaseValidator
        {
            public void Validate(InvoiceAddress oInvoiceAddress)
            {

                // make sure that contact object is valid
                if (oInvoiceAddress.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oInvoiceAddress.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oInvoiceAddress.Address1.Trim().Length == 0)
                {
                    AddCriticalMessage("Address1 Missing");
                }

                if (oInvoiceAddress.Postcode.Trim().Length == 0)
                {
                    AddCriticalMessage("Postcode Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}