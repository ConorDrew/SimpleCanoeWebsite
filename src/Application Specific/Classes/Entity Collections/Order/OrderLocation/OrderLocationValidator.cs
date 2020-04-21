using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace OrderLocations
    {
        // make sure that contact object is valid
        public class OrderLocationValidator : BaseValidator
        {
            public void Validate(OrderLocation oOrderLocation)
            {
                // make sure that contact object is valid
                if (oOrderLocation.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oOrderLocation.Errors)
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