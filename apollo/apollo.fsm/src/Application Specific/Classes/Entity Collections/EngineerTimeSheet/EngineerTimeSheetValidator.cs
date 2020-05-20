using System.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerTimeSheets
    {
        // make sure that contact object is valid
        public class EngineerTimeSheetValidator : BaseValidator
        {
            public void Validate(EngineerTimeSheet oEngineerTimeSheet)
            {
                // make sure that contact object is valid
                if (oEngineerTimeSheet.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oEngineerTimeSheet.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oEngineerTimeSheet.EngineerID == 0)
                {
                    AddCriticalMessage("Engineer Missing");
                }

                if (oEngineerTimeSheet.TimeSheetTypeID == 0)
                {
                    AddCriticalMessage("Type Missing");
                }

                if (Conversions.ToDate(Strings.Format(oEngineerTimeSheet.StartDateTime, "dd/MM/yyyy HH:mm")) >= Conversions.ToDate(Strings.Format(oEngineerTimeSheet.EndDateTime, "dd/MM/yyyy HH:mm")))
                {
                    AddCriticalMessage("End Date/Time must be greater than Start Date/Time Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}