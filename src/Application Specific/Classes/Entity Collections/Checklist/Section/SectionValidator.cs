using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Sections
    {
        // make sure that contact object is valid
        public class SectionValidator : BaseValidator
        {
            public void Validate(Section oSection)
            {

                // make sure that contact object is valid
                if (oSection.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oSection.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oSection.Description.Trim().Length == 0)
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