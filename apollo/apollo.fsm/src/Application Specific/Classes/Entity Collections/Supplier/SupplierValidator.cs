using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Suppliers
    {
        // make sure that contact object is valid
        public class SupplierValidator : BaseValidator
        {
            public void Validate(Supplier oSupplier)
            {
                // make sure that contact object is valid
                if (oSupplier.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oSupplier.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oSupplier.AccountNumber.Trim().Length == 0)
                {
                    AddCriticalMessage("Account Number Missing");
                }

                if (oSupplier.Name.Trim().Length == 0)
                {
                    AddCriticalMessage("Name Missing");
                }

                if (oSupplier.Address1.Trim().Length == 0)
                {
                    AddCriticalMessage("Address 1 Missing");
                }

                if (oSupplier.Postcode.Trim().Length == 0)
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