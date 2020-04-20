using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteOrderParts
    {
        // make sure that contact object is valid
        public class QuoteOrderPartValidator : BaseValidator
        {
            public void Validate(QuoteOrderPart oQuoteOrderPart)
            {

                // make sure that contact object is valid
                if (oQuoteOrderPart.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oQuoteOrderPart.Errors)
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