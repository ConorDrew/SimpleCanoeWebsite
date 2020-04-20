using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitPartProductAllocateds
    {
        // make sure that contact object is valid
        public class EngineerVisitPartProductAllocatedValidator : BaseValidator
        {
            public void Validate(EngineerVisitPartProductAllocated oEngineerVisitPartAllocated)
            {

                // make sure that contact object is valid
                if (oEngineerVisitPartAllocated.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oEngineerVisitPartAllocated.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oEngineerVisitPartAllocated.Type.Trim().Length == 0)
                {
                    AddCriticalMessage("Item Type Missing");
                }

                if (oEngineerVisitPartAllocated.PartProductID == 0)
                {
                    AddCriticalMessage("Item Missing");
                }

                if (!(oEngineerVisitPartAllocated.Quantity > 0))
                {
                    AddCriticalMessage("Quantity Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}