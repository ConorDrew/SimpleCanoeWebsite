using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Tasks
    {
        // make sure that contact object is valid
        public class TaskValidator : BaseValidator
        {
            public void Validate(Task oTask)
            {

                // make sure that contact object is valid
                if (oTask.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oTask.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oTask.Description.Trim().Length == 0)
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