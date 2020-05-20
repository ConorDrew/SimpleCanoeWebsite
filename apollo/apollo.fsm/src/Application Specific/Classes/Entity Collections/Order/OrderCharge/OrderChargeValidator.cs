using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace OrderCharges
    {
        // make sure that contact object is valid
        public class OrderChargeValidator : BaseValidator
        {
            public void Validate(OrderCharge oOrderCharge)
            {
                // make sure that contact object is valid
                if (oOrderCharge.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oOrderCharge.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                // If oOrderCharge.OrderID = 0 Then
                // Me.AddCriticalMessage("Order Missing")
                // End If
                if (oOrderCharge.OrderChargeTypeID == 0)
                {
                    AddCriticalMessage("Charge Type Missing");
                }

                if (!(oOrderCharge.Amount > 0))
                {
                    AddCriticalMessage("Amount Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}