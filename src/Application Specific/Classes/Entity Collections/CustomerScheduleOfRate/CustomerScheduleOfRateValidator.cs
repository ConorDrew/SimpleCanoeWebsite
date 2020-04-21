using System.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace CustomerScheduleOfRates
    {
        // make sure that contact object is valid
        public class CustomerScheduleOfRateValidator : BaseValidator
        {
            public void Validate(CustomerScheduleOfRate oCustomerScheduleOfRate)
            {
                // make sure that contact object is valid
                if (oCustomerScheduleOfRate.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oCustomerScheduleOfRate.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oCustomerScheduleOfRate.ScheduleOfRatesCategoryID == 0)
                {
                    AddCriticalMessage("* Category is missing");
                }

                if (oCustomerScheduleOfRate.Description.Trim().Length == 0)
                {
                    AddCriticalMessage("* Description is missing");
                }

                if (!Information.IsNumeric(oCustomerScheduleOfRate.Price))
                {
                    AddCriticalMessage("* Price must be numeric");
                }

                if (!Information.IsNumeric(oCustomerScheduleOfRate.TimeInMins))
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