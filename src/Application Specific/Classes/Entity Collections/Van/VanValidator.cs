using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Vans
    {
        // make sure that contact object is valid
        public class VanValidator : BaseValidator
        {
            public void Validate(Van oVan)
            {
                // make sure that contact object is valid
                if (oVan.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oVan.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oVan.Registration.Trim().Length == 0)
                {
                    AddCriticalMessage("Profile Name Missing");
                }
                else if (oVan.Registration.Contains("*"))
                {
                    AddCriticalMessage("An asterix (*) cannot be placed in the profile name");
                }
                else if (App.DB.Van.Check_Unique_Registration(oVan.Registration, oVan.VanID) == false)
                {
                    AddCriticalMessage("Profile name already exists");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}