using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity.JobImport
{
    public class JobImportTypeValidator : BaseValidator
    {
        public void Validate(JobImportType oJobImportType)
        {

            // make sure that contact object is valid
            if (oJobImportType.Errors.Count > 0)
            {
                DictionaryEntry de;
                foreach (var de in oJobImportType.Errors)
                    AddCriticalMessage(Conversions.ToString(de.Value));
            }

            if (oJobImportType.Name.Trim().Length == 0)
            {
                AddCriticalMessage("Job Import Type missing name");
            }

            if (oJobImportType.JobTypeID == 0)
            {
                AddCriticalMessage("Job Type missing");
            }

            if (oJobImportType.Cycle == 0)
            {
                AddCriticalMessage("Cycle missing");
            }

            if (oJobImportType.Cycle < 0)
            {
                AddCriticalMessage("Cycle incorrect");
            }

            if (oJobImportType.Cycle > 20)
            {
                AddCriticalMessage("Cycle incorrect");
            }

            if (ValidatorMessages.CriticalMessages.Count > 0)
            {
                throw new ValidationException(this);
            }
        }
    }
}