using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ProductSupplierPriceRequests
    {
        // make sure that contact object is valid
        public class ProductSupplierPriceRequestValidator : BaseValidator
        {
            public void Validate(ProductSupplierPriceRequest oProductSupplierPriceRequest)
            {
                // make sure that contact object is valid
                if (oProductSupplierPriceRequest.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oProductSupplierPriceRequest.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oProductSupplierPriceRequest.OrderID == 0)
                {
                    AddCriticalMessage("Order missing");
                }

                if (oProductSupplierPriceRequest.SupplierID == 0)
                {
                    AddCriticalMessage("Supplier missing");
                }

                if (oProductSupplierPriceRequest.ProductID == 0)
                {
                    AddCriticalMessage("Product missing");
                }

                if (!(oProductSupplierPriceRequest.QuantityInPack > 0))
                {
                    AddCriticalMessage("Quantity must be greater than 0");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}