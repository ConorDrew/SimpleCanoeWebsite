using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitPhotos
    {
        // make sure that contact object is valid
        public class EngineerVisitPhotoValidator : BaseValidator
        {
            public void Validate(EngineerVisitPhoto oEngineerVisitPhoto)
            {
                // make sure that contact object is valid
                if (oEngineerVisitPhoto.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oEngineerVisitPhoto.Errors)
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