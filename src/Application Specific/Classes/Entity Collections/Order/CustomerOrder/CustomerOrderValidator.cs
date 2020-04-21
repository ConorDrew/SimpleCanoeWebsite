using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace CustomerOrders
    {
        // make sure that contact object is valid
        public class CustomerOrderValidator : BaseValidator
        {
            public void Validate(CustomerOrder oCustomerOrder)
            {
                // make sure that contact object is valid
                if (oCustomerOrder.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oCustomerOrder.Errors)
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