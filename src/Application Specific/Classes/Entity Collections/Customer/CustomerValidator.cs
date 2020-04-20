using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Customers
    {
        // make sure that contact object is valid
        public class CustomerValidator : BaseValidator
        {
            public void Validate(Customer oCustomer)
            {

                // make sure that contact object is valid
                if (oCustomer.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oCustomer.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oCustomer.Name.Trim().Length == 0)
                {
                    AddCriticalMessage("Name Missing");
                }

                if (oCustomer.AccountNumber.Trim().Length == 0)
                {
                    AddCriticalMessage("Account Number Missing");
                }

                if (oCustomer.RegionID == 0)
                {
                    AddCriticalMessage("Region Missing");
                }

                if (oCustomer.CustomerTypeID == 0)
                {
                    AddCriticalMessage("Customer Type Missing");
                }

                if (oCustomer.Status == 0)
                {
                    AddCriticalMessage("Status Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}