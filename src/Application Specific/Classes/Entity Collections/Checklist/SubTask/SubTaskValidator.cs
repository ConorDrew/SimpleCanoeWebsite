using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace SubTasks
    {
        // make sure that contact object is valid
        public class SubTaskValidator : BaseValidator
        {
            public void Validate(SubTask oSubTask)
            {
                // make sure that contact object is valid
                if (oSubTask.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oSubTask.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oSubTask.Description.Trim().Length == 0)
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