using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitNCCGSRs
    {
        // make sure that contact object is valid
        public class EngineerVisitNCCGSRValidator : BaseValidator
        {
            public void Validate(EngineerVisitNCCGSR oEngineerVisitNCCGSR)
            {

                // make sure that contact object is valid
                if (oEngineerVisitNCCGSR.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oEngineerVisitNCCGSR.Errors)
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