using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitDefectss
    {
        // make sure that contact object is valid
        public class EngineerVisitDefectsValidator : BaseValidator
        {
            public void Validate(EngineerVisitDefects oEngineerVisitDefects)
            {
                // make sure that contact object is valid
                if (oEngineerVisitDefects.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oEngineerVisitDefects.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oEngineerVisitDefects.CategoryID == 0)
                {
                    AddCriticalMessage("Category Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}