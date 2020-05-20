using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisits
    {
        // make sure that contact object is valid
        public class EngineerVisitValidator : BaseValidator
        {
            public void Validate(EngineerVisit oEngineerVisit, int CustomerID)
            {
                // make sure that contact object is valid
                if (oEngineerVisit.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oEngineerVisit.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                int switchExpr = oEngineerVisit.OutcomeEnumID;
                switch (switchExpr)
                {
                    case (int)Sys.Enums.EngineerVisitOutcomes.NOT_SET:
                        {
                            AddCriticalMessage("Outcome Missing");
                            break;
                        }
                    // OK
                    case (int)Sys.Enums.EngineerVisitOutcomes.Complete:
                        {
                            break;
                        }

                    default:
                        {
                            if (oEngineerVisit.OutcomeDetails.Trim().Length == 0)
                            {
                                AddCriticalMessage("Outcome Details Missing");
                            }

                            break;
                        }
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}