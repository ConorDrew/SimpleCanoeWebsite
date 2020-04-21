using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ProductTransactions
    {
        // make sure that contact object is valid
        public class ProductTransactionValidator : BaseValidator
        {
            public void Validate(ProductTransaction oProductTransaction)
            {
                // make sure that contact object is valid
                if (oProductTransaction.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oProductTransaction.Errors)
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