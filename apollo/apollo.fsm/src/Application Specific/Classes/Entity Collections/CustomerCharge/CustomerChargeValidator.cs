using System.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace CustomerCharges
    {
        // make sure that contact object is valid
        public class CustomerChargeValidator : BaseValidator
        {
            public void Validate(CustomerCharge oCustomerCharge)
            {
                // make sure that contact object is valid
                if (oCustomerCharge.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oCustomerCharge.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oCustomerCharge.MileageRate == 0)
                {
                    AddCriticalMessage("Mileage Rate Missing");
                }

                if (!Information.IsNumeric(oCustomerCharge.MileageRate))
                {
                    AddCriticalMessage("Mileage Rate Invalid");
                }

                if (!Information.IsNumeric(oCustomerCharge.PartsMarkup))
                {
                    AddCriticalMessage("Parts Markup Invalid");
                }

                if (!Information.IsNumeric(oCustomerCharge.RatesMarkup))
                {
                    AddCriticalMessage("Rates Markup Invalid");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}