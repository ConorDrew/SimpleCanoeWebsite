using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace JobItems
    {
        // make sure that contact object is valid
        public class JobItemValidator : BaseValidator
        {
            public void Validate(JobItem oJobItem)
            {
                // make sure that contact object is valid
                if (oJobItem.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oJobItem.Errors)
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