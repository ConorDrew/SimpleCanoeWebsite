using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace JobOfWorks
    {
        // make sure that contact object is valid
        public class JobOfWorkValidator : BaseValidator
        {
            public void Validate(JobOfWork oJobOfWork)
            {

                // make sure that contact object is valid
                if (oJobOfWork.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oJobOfWork.Errors)
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