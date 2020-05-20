using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace MaxEngineerTimes
    {
        // make sure that contact object is valid
        public class MaxEngineerTimeValidator : BaseValidator
        {
            public void Validate(MaxEngineerTime oMaxEngineerTime)
            {
                // make sure that contact object is valid
                if (oMaxEngineerTime.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oMaxEngineerTime.Errors)
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