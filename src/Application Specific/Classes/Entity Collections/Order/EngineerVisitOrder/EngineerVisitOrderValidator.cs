using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitOrders
    {
        // make sure that contact object is valid
        public class EngineerVisitOrderValidator : BaseValidator
        {
            public void Validate(EngineerVisitOrder oEngineerVistOrder)
            {
                // make sure that contact object is valid
                if (oEngineerVistOrder.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oEngineerVistOrder.Errors)
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