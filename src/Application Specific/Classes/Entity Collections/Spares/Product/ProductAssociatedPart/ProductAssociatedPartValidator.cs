using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ProductAssociatedParts
    {
        // make sure that contact object is valid
        public class ProductAssociatedPartValidator : BaseValidator
        {
            public void Validate(ProductAssociatedPart oProductAssociatedPart)
            {
                // make sure that contact object is valid
                if (oProductAssociatedPart.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oProductAssociatedPart.Errors)
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