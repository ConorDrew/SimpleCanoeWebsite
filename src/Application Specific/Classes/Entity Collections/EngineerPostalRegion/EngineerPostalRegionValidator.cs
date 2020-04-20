using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerPostalRegions
    {
        // make sure that contact object is valid
        public class EngineerPostalRegionValidator : BaseValidator
        {
            public void Validate(EngineerPostalRegion oEngineerPostalRegion)
            {

                // make sure that contact object is valid
                if (oEngineerPostalRegion.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oEngineerPostalRegion.Errors)
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