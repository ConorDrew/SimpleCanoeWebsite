using System.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace OrderParts
    {
        // make sure that contact object is valid
        public class OrderPartValidator : BaseValidator
        {
            public void Validate(OrderPart oOrderPart)
            {

                // make sure that contact object is valid
                if (oOrderPart.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oOrderPart.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (!(oOrderPart.Quantity > 0))
                {
                    AddCriticalMessage("Quantity must be greater than 0");
                }

                if (Information.IsDBNull(oOrderPart.BuyPrice))
                {
                    AddCriticalMessage("Buy Price not entered");
                }

                if (Information.IsDBNull(oOrderPart.SellPrice))
                {
                    AddCriticalMessage("Sell Price not entered");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}