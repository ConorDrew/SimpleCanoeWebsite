using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace SiteOrders
    {
        // make sure that contact object is valid
        public class SiteOrderValidator : BaseValidator
        {
            public void Validate(SiteOrder oSiteOrder)
            {
                // make sure that contact object is valid
                if (oSiteOrder.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oSiteOrder.Errors)
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