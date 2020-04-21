using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerLevels
    {
        // make sure that contact object is valid
        public class EngineerLevelValidator : BaseValidator
        {
            public void Validate(EngineerLevel oEngineerLevel)
            {
                // make sure that contact object is valid
                if (oEngineerLevel.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oEngineerLevel.Errors)
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