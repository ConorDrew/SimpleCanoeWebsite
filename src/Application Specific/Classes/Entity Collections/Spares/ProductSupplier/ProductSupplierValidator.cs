using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ProductSuppliers
    {
        // make sure that contact object is valid
        public class ProductSupplierValidator : BaseValidator
        {
            public void Validate(ProductSupplier oProductSupplier)
            {

                // make sure that contact object is valid
                if (oProductSupplier.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oProductSupplier.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                // If oProductSupplier.ProductCode.Trim.Length = 0 Then
                // Me.AddCriticalMessage("*Product Code Missing")
                // End If

                if (oProductSupplier.SupplierID <= 0)
                {
                    AddCriticalMessage("*Supplier Missing");
                }

                if (oProductSupplier.QuantityInPack < 1)
                {
                    AddCriticalMessage("*Invalid Quantity In Pack");
                }

                if (oProductSupplier.Price <= 0)
                {
                    AddCriticalMessage("*Invalid Price");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}