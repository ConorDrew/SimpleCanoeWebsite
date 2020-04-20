using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Areas
    {
        // make sure that contact object is valid
        public class AreaValidator : BaseValidator
        {
            public void Validate(Area oArea)
            {

                // make sure that contact object is valid
                if (oArea.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oArea.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oArea.Description.Trim().Length == 0)
                {
                    AddCriticalMessage("Description Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}