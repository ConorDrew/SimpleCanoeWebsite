using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Locationss
    {
        // make sure that contact object is valid
        public class LocationsValidator : BaseValidator
        {
            public void Validate(Locations oLocations)
            {
                // make sure that contact object is valid
                if (oLocations.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oLocations.Errors)
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