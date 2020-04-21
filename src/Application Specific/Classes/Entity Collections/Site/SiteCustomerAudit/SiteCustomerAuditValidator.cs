using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace SiteCustomerAudits
    {
        // make sure that contact object is valid
        public class SiteCustomerAuditValidator : BaseValidator
        {
            public void Validate(SiteCustomerAudit oSiteCustomerAudit)
            {
                // make sure that contact object is valid
                if (oSiteCustomerAudit.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oSiteCustomerAudit.Errors)
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