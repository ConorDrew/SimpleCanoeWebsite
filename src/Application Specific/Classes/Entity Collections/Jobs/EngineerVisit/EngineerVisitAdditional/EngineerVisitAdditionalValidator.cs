using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitAdditionals
    {
        // make sure that contact object is valid
        public class EngineerVisitAdditionalValidator : BaseValidator
        {
            public void Validate(EngineerVisitAdditional oEngineerVisitAdditional)
            {
                // make sure that contact object is valid
                if (oEngineerVisitAdditional.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oEngineerVisitAdditional.Errors)
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