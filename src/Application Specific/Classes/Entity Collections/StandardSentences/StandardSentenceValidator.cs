using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace StandardSentences
    {
        // make sure that  object is valid
        public class StandardSentenceValidator : BaseValidator
        {
            public void Validate(StandardSentence oStandardSentence)
            {

                // make sure that contact object is valid
                if (oStandardSentence.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oStandardSentence.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oStandardSentence.Sentence.Trim().Length == 0)
                {
                    AddCriticalMessage("Sentence Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}