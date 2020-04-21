using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitCharges
    {
        // make sure that contact object is valid
        public class EngineerVisitChargeValidator : BaseValidator
        {
            public void Validate(EngineerVisitCharge oEngineerVisitCharge)
            {
                // make sure that contact object is valid
                if (oEngineerVisitCharge.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oEngineerVisitCharge.Errors)
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