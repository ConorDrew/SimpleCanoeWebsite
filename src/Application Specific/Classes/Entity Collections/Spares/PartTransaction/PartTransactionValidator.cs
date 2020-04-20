using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace PartTransactions
    {
        // make sure that contact object is valid
        public class PartTransactionValidator : BaseValidator
        {
            public void Validate(PartTransaction oPartTransaction)
            {

                // make sure that contact object is valid
                if (oPartTransaction.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oPartTransaction.Errors)
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