using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace PartSuppliers
    {
        // make sure that contact object is valid
        public class PartSupplierValidator : BaseValidator
        {
            public void Validate(PartSupplier oPartSupplier)
            {
                // make sure that contact object is valid
                if (oPartSupplier.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oPartSupplier.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                // If oPartSupplier.PartCode.Trim.Length = 0 Then
                // Me.AddCriticalMessage("Part Code Missing")
                // End If

                if (oPartSupplier.SupplierID <= 0)
                {
                    AddCriticalMessage("Supplier Missing");
                }

                if (oPartSupplier.QuantityInPack < 1)
                {
                    AddCriticalMessage("Invalid Quantity In Pack");
                }

                if (oPartSupplier.Price <= 0)
                {
                    AddCriticalMessage("Invalid Price");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}