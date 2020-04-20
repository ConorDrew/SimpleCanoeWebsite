using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace OrderProducts
    {
        // make sure that contact object is valid
        public class OrderProductValidator : BaseValidator
        {
            public void Validate(OrderProduct oOrderProduct)
            {

                // make sure that contact object is valid
                if (oOrderProduct.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oOrderProduct.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (!(oOrderProduct.Quantity > 0))
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