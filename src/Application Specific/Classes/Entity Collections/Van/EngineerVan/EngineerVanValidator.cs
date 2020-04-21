using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVans
    {
        // make sure that contact object is valid
        public class EngineerVanValidator : BaseValidator
        {
            public void Validate(EngineerVan oEngineerVan)
            {
                // make sure that contact object is valid
                if (oEngineerVan.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oEngineerVan.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oEngineerVan.VanID == 0)
                {
                    AddCriticalMessage("Van Missing");
                }

                if (oEngineerVan.EngineerID == 0)
                {
                    AddCriticalMessage("Engineer Missing");
                }

                if (oEngineerVan.EndDateTime != default)
                {
                    if (!(oEngineerVan.StartDateTime < oEngineerVan.EndDateTime))
                    {
                        AddCriticalMessage("Start Date Time Must Be Before End Date Time");
                    }
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}