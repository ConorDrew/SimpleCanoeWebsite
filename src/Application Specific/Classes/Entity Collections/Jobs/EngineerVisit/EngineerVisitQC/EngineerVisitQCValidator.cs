using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitQCs
    {
        // make sure that contact object is valid
        public class EngineerVisitQCValidator : BaseValidator
        {
            public void Validate(EngineerVisitQC oEngineerVisitQC)
            {

                // make sure that contact object is valid
                if (oEngineerVisitQC.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oEngineerVisitQC.Errors)
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