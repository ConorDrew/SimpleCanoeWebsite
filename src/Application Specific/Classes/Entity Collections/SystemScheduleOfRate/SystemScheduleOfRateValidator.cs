using System.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace SystemScheduleOfRates
    {
        // make sure that contact object is valid
        public class SystemScheduleOfRateValidator : BaseValidator
        {
            public void Validate(SystemScheduleOfRate oSystemScheduleOfRate)
            {

                // make sure that contact object is valid
                if (oSystemScheduleOfRate.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oSystemScheduleOfRate.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oSystemScheduleOfRate.Description.Length == 0)
                {
                    AddCriticalMessage("* Description is missing");
                }

                if (oSystemScheduleOfRate.ScheduleOfRatesCategoryID == 0)
                {
                    AddCriticalMessage("* Category is missing");
                }

                if (!Information.IsNumeric(oSystemScheduleOfRate.Price))
                {
                    AddCriticalMessage("* Price must be numeric");
                }

                if (!Information.IsNumeric(oSystemScheduleOfRate.TimeInMins))
                {
                    AddCriticalMessage("* Time must be numeric");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}