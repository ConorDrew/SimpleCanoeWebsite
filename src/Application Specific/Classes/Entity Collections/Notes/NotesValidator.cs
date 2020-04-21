using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Notes
    {
        // make sure that contact object is valid
        public class NotesValidator : BaseValidator
        {
            public void Validate(Notes oNotes)
            {
                // make sure that contact object is valid
                if (oNotes.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oNotes.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (!(oNotes.CategoryID > 0))
                {
                    AddCriticalMessage("* Category Missing");
                }

                if (oNotes.Note.Trim().Length == 0)
                {
                    AddCriticalMessage("* Note Missing");
                }

                if (oNotes.UserIDFor == 0)
                {
                    AddCriticalMessage("* User For Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}