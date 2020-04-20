using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitTimeSheets
    {
        // make sure that contact object is valid
        public class EngineerVisitTimeSheetValidator : BaseValidator
        {
            public void Validate(EngineerVisitTimeSheet oEngineerVisitTimeSheet)
            {

                // make sure that contact object is valid
                if (oEngineerVisitTimeSheet.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oEngineerVisitTimeSheet.Errors)
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