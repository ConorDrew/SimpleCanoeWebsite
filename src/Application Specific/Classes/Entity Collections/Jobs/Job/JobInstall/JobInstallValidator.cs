using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace JobInstalls
    {
        // make sure that contact object is valid
        public class JobInstallValidator : BaseValidator
        {
            public void Validate(JobInstall oJobInstall)
            {

                // make sure that contact object is valid
                if (oJobInstall.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oJobInstall.Errors)
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