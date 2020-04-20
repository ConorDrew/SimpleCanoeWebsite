using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteOrderProducts
    {
        // make sure that contact object is valid
        public class QuoteOrderProductValidator : BaseValidator
        {
            public void Validate(QuoteOrderProduct oQuoteOrderProduct)
            {

                // make sure that contact object is valid
                if (oQuoteOrderProduct.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oQuoteOrderProduct.Errors)
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