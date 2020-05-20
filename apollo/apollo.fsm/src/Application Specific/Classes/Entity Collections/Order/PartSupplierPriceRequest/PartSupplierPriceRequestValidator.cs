using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace PartSupplierPriceRequests
    {
        // make sure that contact object is valid
        public class PartSupplierPriceRequestValidator : BaseValidator
        {
            public void Validate(PartSupplierPriceRequest oPartSupplierPriceRequest)
            {
                // make sure that contact object is valid
                if (oPartSupplierPriceRequest.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oPartSupplierPriceRequest.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oPartSupplierPriceRequest.OrderID == 0)
                {
                    AddCriticalMessage("Order missing");
                }

                if (oPartSupplierPriceRequest.SupplierID == 0)
                {
                    AddCriticalMessage("Supplier missing");
                }

                if (oPartSupplierPriceRequest.PartID == 0)
                {
                    AddCriticalMessage("Part missing");
                }

                if (!(oPartSupplierPriceRequest.QuantityInPack > 0))
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