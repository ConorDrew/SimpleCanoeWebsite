using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    // make sure that contact object is valid
    public class EngineerAbsenceValidator : BaseValidator
    {
        public void Validate(Entity.EngineerAbsence.EngineerAbsence oEA)
        {
            // make sure that contact object is valid
            if (oEA.Errors.Count > 0)
            {
                foreach (DictionaryEntry de in oEA.Errors)
                    AddCriticalMessage(Conversions.ToString(de.Value));
            }

            var e = new Entity.Engineers.Engineer();
            e = App.DB.Engineer.Engineer_Get(Conversions.ToInteger(oEA.EngineerID));
            if ((oEA.EngineerID ?? "") == "-1")
            {
                AddCriticalMessage(ErrorMsg.FieldRequired("Engineer"));
            }

            if (oEA.AbsenceTypeID == -1)
            {
                AddCriticalMessage(ErrorMsg.FieldRequired("Absence Type"));
            }

            if (oEA.MorningSlots < 0)
            {
                AddCriticalMessage(ErrorMsg.NegativeNumber("Morning Slots"));
            }

            if (oEA.AfternoonSlots < 0)
            {
                AddCriticalMessage(ErrorMsg.NegativeNumber("Afternoon Slots"));
            }

            if (ValidatorMessages.CriticalMessages.Count > 0)
            {
                throw new ValidationException(this);
            }
        }
    }
}